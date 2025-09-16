  ~~~C#
  
Console.WriteLine("Small Deflate C# Example");
Console.WriteLine("-----------------------");

// Example text to compress
string testString = "This is a test string that will be compressed and then decompressed to verify that everything is working correctly. " +
    "The original C code was written as a small, portable implementation of the Deflate algorithm. " +
    "This text will be repeated to provide a better compression example. " +
    "This is a test string that will be compressed and then decompressed to verify that everything is working correctly. " +
    "The original C code was written as a small, portable implementation of the Deflate algorithm. " +
    "This text will be repeated to provide a better compression example.";

byte[] inputData = Encoding.UTF8.GetBytes(testString);
Console.WriteLine($"Original size: {inputData.Length} bytes");

// Compression
SDefl deflater = new SDefl();
int maxCompressedSize = SDefl.Bound(inputData.Length);
byte[] compressedData = new byte[maxCompressedSize];

Stopwatch sw = Stopwatch.StartNew();
int compressedSize = deflater.Deflate(compressedData, inputData, inputData.Length, SDefl.LVL_DEF);
sw.Stop();

Console.WriteLine($"Compressed size: {compressedSize} bytes");
Console.WriteLine($"Compression ratio: {(float)compressedSize / inputData.Length:F2}");
Console.WriteLine($"Compression time: {sw.ElapsedMilliseconds} ms");

// Decompression
SInfl inflater = new SInfl();
byte[] decompressedData = new byte[inputData.Length];

sw.Restart();
int decompressedSize = inflater.Inflate(decompressedData, compressedData, compressedSize);
sw.Stop();

Console.WriteLine($"Decompressed size: {decompressedSize} bytes");
Console.WriteLine($"Decompression time: {sw.ElapsedMilliseconds} ms");

// Verify result
string resultString = Encoding.UTF8.GetString(decompressedData, 0, decompressedSize);
bool isEqual = testString.Equals(resultString);
Console.WriteLine($"Decompressed data matches original: {isEqual}");

~~~