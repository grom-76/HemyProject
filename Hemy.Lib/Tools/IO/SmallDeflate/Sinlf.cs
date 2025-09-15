namespace Hemy.Lib.Tools.IO.SmallDeflate;

using System;

/// <summary>
/// SInfl is a small bare bone lossless decompression library that implements the Deflate (RFC 1951) standard.
/// </summary>
public class SInfl
{
    // State for bit operations
    private int bits;
    private int bitCount;

    // Huffman trees
    private readonly uint[] literalTree = new uint[288];
    private readonly uint[] distanceTree = new uint[32];
    private readonly uint[] codeLengthTree = new uint[19];

    private int tableLiteralSize;
    private int tableDistanceSize;
    private int tableCodeLengthSize;

    // Lookup table for bit reflection
    private static readonly byte[] Mirror = {
        #region Mirror Table
        0, 128, 64, 192, 32, 160, 96, 224, 16, 144, 80, 208, 48, 176, 112, 240,
        8, 136, 72, 200, 40, 168, 104, 232, 24, 152, 88, 216, 56, 184, 120, 248,
        4, 132, 68, 196, 36, 164, 100, 228, 20, 148, 84, 212, 52, 180, 116, 244,
        12, 140, 76, 204, 44, 172, 108, 236, 28, 156, 92, 220, 60, 188, 124, 252,
        2, 130, 66, 194, 34, 162, 98, 226, 18, 146, 82, 210, 50, 178, 114, 242,
        10, 138, 74, 202, 42, 170, 106, 234, 26, 154, 90, 218, 58, 186, 122, 250,
        6, 134, 70, 198, 38, 166, 102, 230, 22, 150, 86, 214, 54, 182, 118, 246,
        14, 142, 78, 206, 46, 174, 110, 238, 30, 158, 94, 222, 62, 190, 126, 254,
        1, 129, 65, 193, 33, 161, 97, 225, 17, 145, 81, 209, 49, 177, 113, 241,
        9, 137, 73, 201, 41, 169, 105, 233, 25, 153, 89, 217, 57, 185, 121, 249,
        5, 133, 69, 197, 37, 165, 101, 229, 21, 149, 85, 213, 53, 181, 117, 245,
        13, 141, 77, 205, 45, 173, 109, 237, 29, 157, 93, 221, 61, 189, 125, 253,
        3, 131, 67, 195, 35, 163, 99, 227, 19, 147, 83, 211, 51, 179, 115, 243,
        11, 139, 75, 203, 43, 171, 107, 235, 27, 155, 91, 219, 59, 187, 123, 251,
        7, 135, 71, 199, 39, 167, 103, 231, 23, 151, 87, 215, 55, 183, 119, 247,
        15, 143, 79, 207, 47, 175, 111, 239, 31, 159, 95, 223, 63, 191, 127, 255
        #endregion
    };

    /// <summary>
    /// Initializes a new instance of the SInfl decompression class.
    /// </summary>
    public SInfl()
    {
    }

    // Extract bits from the input stream
    private int GetBits(ref int inputIndex, byte[] input, int inputEnd, int n)
    {
        int value = bits & ((1 << n) - 1);
        bits >>= n;
        bitCount -= n;

        if (bitCount < 0)
        {
            bitCount = 0;
        }

        while (bitCount < 16 && inputIndex < inputEnd)
        {
            bits |= input[inputIndex++] << bitCount;
            bitCount += 8;
        }

        return value;
    }

    // Build a Huffman tree
    private int BuildHuffmanTree(uint[] tree, byte[] lengths, int symbolCount)
    {
        int[] counts = new int[16];
        int[] firstCodes = new int[16];
        int[] codes = new int[16];

        // Count occurrences of each code length
        for (int i = 0; i < symbolCount; i++)
        {
            counts[lengths[i]]++;
        }

        counts[0] = firstCodes[0] = codes[0] = 0;

        // Calculate first code for each length
        for (int i = 1; i <= 15; i++)
        {
            codes[i] = (codes[i - 1] + counts[i - 1]) << 1;
            firstCodes[i] = firstCodes[i - 1] + counts[i - 1];
        }

        // Assign codes to symbols
        for (int i = 0; i < symbolCount; i++)
        {
            int len = lengths[i];
            if (len != 0)
            {
                int code = codes[len]++;
                int slot = firstCodes[len]++;
                tree[slot] = (uint)((code << (32 - len)) | (i << 4) | len);
            }
        }

        return firstCodes[15];
    }

    // Reverse 16 bits
    private static uint Reverse16(int n)
    {
        return (uint)((Mirror[n & 0xff] << 8) | Mirror[(n >> 8) & 0xff]);
    }

    // Decode a symbol using a Huffman tree
    private int DecodeSymbol(ref int inputIndex, byte[] input, int inputEnd, uint[] tree, int max)
    {
        // Binary search to find the code
        uint search = (Reverse16(bits) << 16) | 0xffff;
        uint key;
        int lo = 0, hi = max;

        while (lo < hi)
        {
            int mid = (lo + hi) / 2;
            if (search < tree[mid])
            {
                hi = mid;
            }
            else
            {
                lo = mid + 1;
            }
        }

        // Pull out and check the key
        key = tree[lo - 1];
        GetBits(ref inputIndex, input, inputEnd, (int)(key & 0x0f));

        return (int)((key >> 4) & 0x0fff);
    }

    // // State machine states
    enum InflateState { Header, Stored, Fixed, Dynamic, Block }

    /// <summary>
    /// Decompresses Deflate-compressed data.
    /// </summary>
    /// <param name="output">Output buffer for decompressed data</param>
    /// <param name="input">Input buffer containing compressed data</param>
    /// <param name="inputSize">Size of the input data</param>
    /// <returns>Size of the decompressed data</returns>
    public int Inflate(byte[] output, byte[] input, int inputSize)
    {
        // Order of code length codes
        int[] order = { 16, 17, 18, 0, 8, 7, 9, 6, 10, 5, 11, 4, 12, 3, 13, 2, 14, 1, 15 };

        // Base values and extra bits for distances
        int[] distanceBases = {
            1, 2, 3, 4, 5, 7, 9, 13, 17, 25, 33, 49, 65, 97, 129, 193,
            257, 385, 513, 769, 1025, 1537, 2049, 3073, 4097, 6145, 8193, 12289, 16385, 24577
        };

        byte[] distanceExtraBits = {
            0, 0, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9,
            10, 10, 11, 11, 12, 12, 13, 13, 0, 0
        };

        // Base values and extra bits for lengths
        int[] lengthBases = {
            3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 15, 17, 19, 23, 27, 31, 35,
            43, 51, 59, 67, 83, 99, 115, 131, 163, 195, 227, 258, 0, 0
        };

        byte[] lengthExtraBits = {
            0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4,
            4, 4, 4, 5, 5, 5, 5, 0, 0, 0
        };

        int inputEnd = inputSize;
        int inputIndex = 0;
        int outputStart = 0;
        int outputIndex = 0;
        bool lastBlock = false;


        InflateState state = InflateState.Header;

        bits = 0;
        bitCount = 0;

        // // Buffer input
        GetBits(ref inputIndex, input, inputEnd, 0);

        while (inputIndex < inputEnd || bitCount > 0)
        {
            switch (state)
            {
                case InflateState.Header:
                    // Block header
                    lastBlock = GetBits(ref inputIndex, input, inputEnd, 1) == 1;
                    int blockType = GetBits(ref inputIndex, input, inputEnd, 2);

                    switch (blockType)
                    {
                        case 0x00: // No compression
                            state = InflateState.Stored;
                            break;
                        case 0x01: // Fixed Huffman
                            state = InflateState.Fixed;
                            break;
                        case 0x02: // Dynamic Huffman
                            state = InflateState.Dynamic;
                            break;
                        default: // Error or reserved
                            return outputIndex - outputStart;
                    }
                    break;

                case InflateState.Stored:
                    // Uncompressed block
                    GetBits(ref inputIndex, input, inputEnd, bitCount & 7); // Align to byte

                    int blockLen = GetBits(ref inputIndex, input, inputEnd, 16);
                    int blockLenComplement = GetBits(ref inputIndex, input, inputEnd, 16);

                    inputIndex -= 2; // Backup as we consumed too much
                    bitCount = 0;    // Reset bit buffer

                    if (blockLen > (inputEnd - inputIndex) || blockLen == 0)
                    {
                        return outputIndex - outputStart;
                    }

                    // Copy raw data
                    Array.Copy(input, inputIndex, output, outputIndex, blockLen);
                    inputIndex += blockLen;
                    outputIndex += blockLen;

                    state = InflateState.Header;
                    break;

                case InflateState.Fixed:
                    // Fixed Huffman codes
                    byte[] fixedLengths = new byte[288 + 32];

                    // Set code lengths for fixed Huffman table
                    for (int n = 0; n <= 143; n++) fixedLengths[n] = 8;
                    for (int n = 144; n <= 255; n++) fixedLengths[n] = 9;
                    for (int n = 256; n <= 279; n++) fixedLengths[n] = 7;
                    for (int n = 280; n <= 287; n++) fixedLengths[n] = 8;
                    for (int n = 0; n < 32; n++) fixedLengths[288 + n] = 5;

                    // Build Huffman trees
                    tableLiteralSize = BuildHuffmanTree(literalTree, fixedLengths, 288);
                    tableDistanceSize = BuildHuffmanTree(distanceTree, fixedLengths, 288 + 32);

                    state = InflateState.Block;
                    break;

                case InflateState.Dynamic:
                    // Dynamic Huffman codes
                    int literalCount = 257 + GetBits(ref inputIndex, input, inputEnd, 5);
                    int distanceCount = 1 + GetBits(ref inputIndex, input, inputEnd, 5);
                    int codeLengthCount = 4 + GetBits(ref inputIndex, input, inputEnd, 4);

                    byte[] codeLengths = new byte[19];

                    // Read code lengths for the code length alphabet
                    for (int i = 0; i < codeLengthCount; i++)
                    {
                        codeLengths[order[i]] = (byte)GetBits(ref inputIndex, input, inputEnd, 3);
                    }

                    // Build code length tree
                    tableCodeLengthSize = BuildHuffmanTree(codeLengthTree, codeLengths, 19);

                    // Read code lengths for literal/length and distance alphabets
                    byte[] treeLengths = new byte[288 + 32];
                    int codeIndex = 0;

                    while (codeIndex < literalCount + distanceCount)
                    {
                        int symbol = DecodeSymbol(ref inputIndex, input, inputEnd, codeLengthTree, tableCodeLengthSize);

                        switch (symbol)
                        {
                            case 16: // Copy previous code length 3-6 times
                                {
                                    int repeat = 3 + GetBits(ref inputIndex, input, inputEnd, 2);
                                    while (repeat-- > 0 && codeIndex < literalCount + distanceCount)
                                    {
                                        treeLengths[codeIndex] = treeLengths[codeIndex - 1];
                                        codeIndex++;
                                    }
                                    break;
                                }
                            case 17: // Repeat code length 0 for 3-10 times
                                {
                                    int repeat = 3 + GetBits(ref inputIndex, input, inputEnd, 3);
                                    while (repeat-- > 0 && codeIndex < literalCount + distanceCount)
                                    {
                                        treeLengths[codeIndex++] = 0;
                                    }
                                    break;
                                }
                            case 18: // Repeat code length 0 for 11-138 times
                                {
                                    int repeat = 11 + GetBits(ref inputIndex, input, inputEnd, 7);
                                    while (repeat-- > 0 && codeIndex < literalCount + distanceCount)
                                    {
                                        treeLengths[codeIndex++] = 0;
                                    }
                                    break;
                                }
                            default: // Regular code length 0-15
                                treeLengths[codeIndex++] = (byte)symbol;
                                break;
                        }
                    }

                    // Build trees
                    tableLiteralSize = BuildHuffmanTree(literalTree, treeLengths, literalCount);
                    tableDistanceSize = BuildHuffmanTree(distanceTree, treeLengths.AsSpan(literalCount, distanceCount).ToArray(), distanceCount);

                    state = InflateState.Block;
                    break;

                case InflateState.Block:
                    // Decompress block data
                    int sym = DecodeSymbol(ref inputIndex, input, inputEnd, literalTree, tableLiteralSize);

                    if (sym > 256) // Match symbol
                    {
                        sym -= 257;

                        int len = GetBits(ref inputIndex, input, inputEnd, lengthExtraBits[sym]) + lengthBases[sym];
                        int distSym = DecodeSymbol(ref inputIndex, input, inputEnd, distanceTree, tableDistanceSize);
                        int dist = GetBits(ref inputIndex, input, inputEnd, distanceExtraBits[distSym]) + distanceBases[distSym];

                        if (dist > outputIndex - outputStart)
                        {
                            return outputIndex - outputStart; // Invalid distance
                        }

                        // Copy match data
                        while (len-- > 0)
                        {
                            output[outputIndex] = output[outputIndex - dist];
                            outputIndex++;
                        }
                    }
                    else if (sym == 256) // End of block
                    {
                        if (lastBlock)
                        {
                            return outputIndex - outputStart;
                        }

                        state = InflateState.Header;
                    }
                    else // Literal byte
                    {
                        output[outputIndex++] = (byte)sym;
                    }
                    break;
            }
        }

        return outputIndex - outputStart;
    }


}
