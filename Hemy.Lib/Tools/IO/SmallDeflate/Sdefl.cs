namespace Hemy.Lib.Tools.IO.SmallDeflate;

using System;

/// <summary>
/// SDefl is a small bare bone lossless compression library that implements the Deflate (RFC 1951) standard.
/// </summary>
public class SDefl
{
    // Constants that match the C version
    private const int SDEFL_MAX_OFF = 1 << 15;
    private const int SDEFL_WIN_SIZ = SDEFL_MAX_OFF;
    private const int SDEFL_WIN_MSK = SDEFL_WIN_SIZ - 1;

    private const int SDEFL_MIN_MATCH = 4;
    private const int SDEFL_MAX_MATCH = 258;

    private const int SDEFL_HASH_BITS = 19;
    private const int SDEFL_HASH_SIZ = 1 << SDEFL_HASH_BITS;
    private const int SDEFL_HASH_MSK = SDEFL_HASH_SIZ - 1;
    private const int SDEFL_NIL = -1;

    /// <summary>
    /// Minimum compression level (0)
    /// </summary>
    public const int LVL_MIN = 0;

    /// <summary>
    /// Default compression level (5)
    /// </summary>
    public const int LVL_DEF = 5;

    /// <summary>
    /// Maximum compression level (8)
    /// </summary>
    public const int LVL_MAX = 8;

    private int bits;
    private int cnt;
    private readonly int[] tbl;
    private readonly int[] prv;

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
    /// Initializes a new instance of the SDefl compression class.
    /// </summary>
    public SDefl()
    {
        tbl = new int[SDEFL_HASH_SIZ];
        prv = new int[SDEFL_WIN_SIZ];
    }

    private static int NextPowerOfTwo(int n)
    {
        n--;
        n |= n >> 1;
        n |= n >> 2;
        n |= n >> 4;
        n |= n >> 8;
        n |= n >> 16;
        return ++n;
    }

    private static int Log2Integer(int n)
    {
        if (n == 0) return -1;

        int log = 0;
        if ((n & 0xFFFF0000) != 0) { log += 16; n >>= 16; }
        if ((n & 0xFF00) != 0) { log += 8; n >>= 8; }
        if ((n & 0xF0) != 0) { log += 4; n >>= 4; }
        if ((n & 0xC) != 0) { log += 2; n >>= 2; }
        if ((n & 0x2) != 0) { log += 1; }

        return log;
    }

    private static uint ULoad32(byte[] data, int offset)
    {
        return BitConverter.IsLittleEndian
            ? BitConverter.ToUInt32(data, offset)
            : (uint)(data[offset] | (data[offset + 1] << 8) | (data[offset + 2] << 16) | (data[offset + 3] << 24));
    }

    private static uint Hash32(byte[] data, int offset)
    {
        uint n = ULoad32(data, offset);
        return (n * 0x9E377989) >> (32 - SDEFL_HASH_BITS);
    }

    private int Put(byte[] dst, ref int dstIndex, int code, int bitCount)
    {
        bits |= (code << cnt);
        cnt += bitCount;

        while (cnt >= 8)
        {
            dst[dstIndex++] = (byte)(bits & 0xFF);
            bits >>= 8;
            cnt -= 8;
        }

        return dstIndex;
    }

    private int EncodeLiteral(byte[] dst, ref int dstIndex, int c)
    {
        if (c <= 143)
        {
            dstIndex = Put(dst, ref dstIndex, Mirror[0x30 + c], 8);
        }
        else
        {
            dstIndex = Put(dst, ref dstIndex, 1 + 2 * Mirror[0x90 - 144 + c], 9);
        }

        return dstIndex;
    }

    private int EncodeMatch(byte[] dst, ref int dstIndex, int dist, int len)
    {
        // Length encoding tables
        int[] lxmin = { 0, 11, 19, 35, 67, 131 };
        int[] dxmax = { 0, 6, 12, 24, 48, 96, 192, 384, 768, 1536, 3072, 6144, 12288, 24576 };
        int[] lmin = { 11, 13, 15, 17, 19, 23, 27, 31, 35, 43, 51, 59, 67, 83, 99, 115, 131, 163, 195, 227 };
        int[] dmin = { 1, 2, 3, 4, 5, 7, 9, 13, 17, 25, 33, 49, 65, 97, 129, 193, 257,
            385, 513, 769, 1025, 1537, 2049, 3073, 4097, 6145, 8193, 12289, 16385, 24577 };

        // Length encoding
        int lc = len;
        int lx = Log2Integer(len - 3) - 2;
        if ((lx = (lx < 0) ? 0 : lx) == 0)
        {
            lc += 254;
        }
        else if (len >= 258)
        {
            lx = 0;
            lc = 285;
        }
        else
        {
            lc = ((lx - 1) << 2) + 265 + ((len - lxmin[lx]) >> lx);
        }

        if (lc <= 279)
        {
            dstIndex = Put(dst, ref dstIndex, Mirror[(lc - 256) << 1], 7);
        }
        else
        {
            dstIndex = Put(dst, ref dstIndex, Mirror[0xc0 - 280 + lc], 8);
        }

        if (lx > 0)
        {
            dstIndex = Put(dst, ref dstIndex, len - lmin[lc - 265], lx);
        }

        // Distance encoding
        int dc = dist - 1;
        int dx = Log2Integer(NextPowerOfTwo(dist) >> 2);
        if ((dx = (dx < 0) ? 0 : dx) > 0)
        {
            dc = ((dx + 1) << 1) + (dist > dxmax[dx] ? 1 : 0);
        }

        dstIndex = Put(dst, ref dstIndex, Mirror[dc << 3], 5);

        if (dx > 0)
        {
            dstIndex = Put(dst, ref dstIndex, dist - dmin[dc], dx);
        }

        return dstIndex;
    }

    /// <summary>
    /// Calculates the maximum size of the compressed data based on the input length.
    /// </summary>
    /// <param name="inLen">Length of the input data</param>
    /// <returns>Maximum size of the compressed output</returns>
    public static int Bound(int inLen)
    {
        int a = 128 + (inLen * 110) / 100;
        int b = 128 + inLen + ((inLen / (31 * 1024)) + 1) * 5;
        return Math.Max(a, b);
    }

    /// <summary>
    /// Compresses the input data using the Deflate algorithm.
    /// </summary>
    /// <param name="output">Output buffer to store compressed data</param>
    /// <param name="input">Input data to compress</param>
    /// <param name="inputLength">Length of the input data</param>
    /// <param name="compressionLevel">Compression level (0-8)</param>
    /// <returns>Size of the compressed data</returns>
    public int Deflate(byte[] output, byte[] input, int inputLength, int compressionLevel)
    {
        int p = 0;
        int maxChain = (compressionLevel < 8) ? (1 << (compressionLevel + 1)) : (1 << 13);
        int dstIndex = 0;

        bits = 0;
        cnt = 0;

        // Initialize hash table
        for (p = 0; p < SDEFL_HASH_SIZ; ++p)
        {
            tbl[p] = SDEFL_NIL;
        }

        p = 0;

        // Block header (static Huffman)
        dstIndex = Put(output, ref dstIndex, 0x01, 1); // Block type: last block
        dstIndex = Put(output, ref dstIndex, 0x01, 2); // Block type: static Huffman

        while (p < inputLength)
        {
            int run;
            int bestLen = 0;
            int dist = 0;

            int maxMatch = Math.Min(inputLength - p, SDEFL_MAX_MATCH);

            if (maxMatch > SDEFL_MIN_MATCH)
            {
                int limit = (p - SDEFL_WIN_SIZ < SDEFL_NIL) ? SDEFL_NIL : (p - SDEFL_WIN_SIZ);
                int chainLen = maxChain;
                int i = (int)tbl[Hash32(input, p)];

                while (i > limit)
                {
                    if (input[i + bestLen] == input[p + bestLen] &&
                        ULoad32(input, i) == ULoad32(input, p))
                    {
                        int n = SDEFL_MIN_MATCH;
                        while (n < maxMatch && input[i + n] == input[p + n])
                        {
                            n++;
                        }

                        if (n > bestLen)
                        {
                            bestLen = n;
                            dist = p - i;
                            if (n == maxMatch)
                            {
                                break;
                            }
                        }
                    }

                    if (--chainLen == 0)
                    {
                        break;
                    }

                    i = prv[i & SDEFL_WIN_MSK];
                }
            }

            // Look ahead to see if we can get a better match by skipping one byte
            if (compressionLevel >= 5 && bestLen >= SDEFL_MIN_MATCH && bestLen < maxMatch)
            {
                int x = p + 1;
                int targetLen = bestLen + 1;
                int limit = (x - SDEFL_WIN_SIZ < SDEFL_NIL) ? SDEFL_NIL : (x - SDEFL_WIN_SIZ);
                int chainLen = maxChain;
                int i = (int)tbl[Hash32(input, x)];

                while (i > limit)
                {
                    if (input[i + bestLen] == input[x + bestLen] &&
                        ULoad32(input, i) == ULoad32(input, x))
                    {
                        int n = SDEFL_MIN_MATCH;
                        while (n < targetLen && input[i + n] == input[x + n])
                        {
                            n++;
                        }

                        if (n == targetLen)
                        {
                            bestLen = 0;
                            break;
                        }
                    }

                    if (--chainLen == 0)
                    {
                        break;
                    }

                    i = prv[i & SDEFL_WIN_MSK];
                }
            }

            if (bestLen >= SDEFL_MIN_MATCH)
            {
                dstIndex = EncodeMatch(output, ref dstIndex, dist, bestLen);
                run = bestLen;
            }
            else
            {
                dstIndex = EncodeLiteral(output, ref dstIndex, input[p]);
                run = 1;
            }

            // Update hash table
            while (run-- > 0)
            {
                uint h = Hash32(input, p);
                prv[p & SDEFL_WIN_MSK] = tbl[h];
                tbl[h] = p++;
            }
        }

        // Flush remaining bits (partial flush)
        dstIndex = Put(output, ref dstIndex, 0, 7);
        dstIndex = Put(output, ref dstIndex, 2, 10);
        dstIndex = Put(output, ref dstIndex, 2, 3);

        return dstIndex;
    }
}
