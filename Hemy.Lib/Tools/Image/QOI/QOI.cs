/*
https://github.com/h2oboi89/qoi (4 ans) nulle

https://github.com/rkm/QOI.Net (4 ans )  => pixel 'union'  1fichier encode 1 fichier decode 

https://github.com/NUlliiON/QoiSharp ( 4 ans ) good code
    https://github.com/HenryHo2006/QoiSharpNoGc
    https://github.com/Multithread/QoiSharp

https://github.com/RGgt/Qoi.NetStandard (4 ans )

https://github.com/mareek/QOI.NET ( 4ans)


Using : src :https://github.com/HenryHo2006/QoiSharpNoGc 
write 15/09/2025  ( ver  20/07/2025 )
*/
namespace Hemy.Lib.Tools.Image.QOI;

using System;
using System.Buffers.Binary;
// using System.Drawing;
// using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public enum Channels : byte
{
    /// <summary>
    /// 3-channel format containing data for Red, Green, Blue.
    /// </summary>
    Rgb = 3,

    /// <summary>
    /// 4-channel format containing data for Red, Green, Blue, and Alpha.
    /// </summary>
    RgbWithAlpha = 4
}

public enum ColorSpace : byte
{
    /// <summary>
    /// Gamma scaled RGB channels and a linear alpha channel.
    /// </summary>
    SRgb = 0,

    /// <summary>
    /// All channels are linear.
    /// </summary>
    Linear = 1
}

public class QoiDecodingException : Exception
{
    public QoiDecodingException(string message) : base(message)
    {
    }
}

public class QoiEncodingException : Exception
{
    public QoiEncodingException(string message) : base(message)
    {
    }
}

public struct Size
{

    private int width; // Do not rename (binary serialization)
    private int height; // Do not rename (binary serialization)

    public Size(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
     /// <summary>
    /// Represents the horizontal component of this <see cref='System.Drawing.Size'/>.
    /// </summary>
    public int Width
    {
        readonly get => width;
        set => width = value;
    }

    /// <summary>
    /// Represents the vertical component of this <see cref='System.Drawing.Size'/>.
    /// </summary>
    public int Height
    {
        readonly get => height;
        set => height = value;
    }

}

/// <summary>
/// QOI Codec.
/// </summary>
public static class QoiCodec
{
    public const byte Index = 0x00;
    public const byte Diff = 0x40;
    public const byte Luma = 0x80;
    public const byte Run = 0xC0;
    public const byte Rgb = 0xFE;
    public const byte Rgba = 0xFF;
    public const byte Mask2 = 0xC0;

    /// <summary>
    /// 2GB is the max file size that this implementation can safely handle. We guard
    /// against anything larger than that, assuming the worst case with 5 bytes per 
    /// pixel, rounded down to a nice clean value. 400 million pixels ought to be 
    /// enough for anybody.
    /// </summary>
    public static long MaxPixels = 400_000_000;

    public const int HashTableSize = 64;

    public const byte HeaderSize = 14;
    public const string MagicString = "qoif";

    public static readonly int Magic = CalculateMagic(MagicString.AsSpan());
    public static readonly byte[] Padding = { 0, 0, 0, 0, 0, 0, 0, 1 };

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CalculateHashTableIndex(int r, int g, int b, int a)
    {
        return ((r & 0xFF) * 3 + (g & 0xFF) * 5 + (b & 0xFF) * 7 + (a & 0xFF) * 11) % HashTableSize * 4;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CalculateHashTableRgbaIndex(int packedPixel)
    {
        // Extract components and calculate hash in one expression
        return (((packedPixel >> 24) * 3) +
                (((packedPixel >> 16) & 0xFF) * 5) +
                (((packedPixel >> 8) & 0xFF) * 7) +
                ((packedPixel & 0xFF) * 11)) & 63;
    }

    public static bool IsValidMagic(byte[] magic) => CalculateMagic(magic) == Magic;
    public static bool IsValidMagic(ReadOnlySpan<byte> magic) => CalculateMagic(magic) == Magic;

    private static int CalculateMagic(ReadOnlySpan<char> chars) => chars[0] << 24 | chars[1] << 16 | chars[2] << 8 | chars[3];
    private static int CalculateMagic(ReadOnlySpan<byte> data) => data[0] << 24 | data[1] << 16 | data[2] << 8 | data[3];
}

/// <summary>
/// QOI image.
/// </summary>
public class QoiImage
{
    /// <summary>
    /// Raw pixel data.
    /// </summary>
    public byte[] Data { get; }

    /// <summary>
    /// Image width.
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// Image height
    /// </summary>
    public int Height { get; }

    /// <summary>
    /// Channels.
    /// </summary>
    public Channels Channels { get; }

    /// <summary>
    /// Color space.
    /// </summary>
    public ColorSpace ColorSpace { get; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public QoiImage(byte[] data, int width, int height, Channels channels, ColorSpace colorSpace = ColorSpace.SRgb)
    {
        Data = data;
        Width = width;
        Height = height;
        Channels = channels;
        ColorSpace = colorSpace;
    }
}

/// <summary>
/// QOI decoder.
/// </summary>
public static class QoiDecoder
{
    /// <summary>
    /// Decodes QOI data into raw pixel data.
    /// </summary>
    /// <param name="qoiData">QOI data</param>
    /// <returns>Decoding result.</returns>
    /// <exception cref="QoiDecodingException">Thrown when data is invalid.</exception>
    public static QoiImage Decode(byte[] qoiData)
    {
        if (qoiData.Length < QoiCodec.HeaderSize + QoiCodec.Padding.Length)
        {
            throw new QoiDecodingException("File too short");
        }

        if (!QoiCodec.IsValidMagic(qoiData[..4]))
        {
            throw new QoiDecodingException("Invalid file magic");
        }

        int width = BinaryPrimitives.ReadInt32BigEndian(qoiData.AsSpan(4, 4));
        int height = BinaryPrimitives.ReadInt32BigEndian(qoiData.AsSpan(8, 4));
        byte channels = qoiData[12];
        var colorSpace = (ColorSpace)qoiData[13];

        if (width == 0)
        {
            throw new QoiDecodingException($"Invalid width: {width}");
        }
        if (height == 0 || height >= QoiCodec.MaxPixels / width)
        {
            throw new QoiDecodingException($"Invalid height: {height}. Maximum for this image is {QoiCodec.MaxPixels / width - 1}");
        }
        if (channels is not 3 and not 4)
        {
            throw new QoiDecodingException($"Invalid number of channels: {channels}");
        }

        int[] intIndex = new int[QoiCodec.HashTableSize];
        if (channels == 3)
        {
            for (int indexPos = 0; indexPos < intIndex.Length; indexPos++)
            {
                intIndex[indexPos] = 255;
            }
        }

        byte[] pixels = new byte[width * height * channels];
        int p = QoiCodec.HeaderSize;

        int currentPixel = 255;

        for (int pxPos = 0; pxPos < pixels.Length; pxPos += channels)
        {
            byte b1 = qoiData[p++];
            if (b1 >> 6 == 3)
            {
                if (b1 == QoiCodec.Rgb)
                {
                    currentPixel = qoiData[p++] << 24 | qoiData[p++] << 16 | qoiData[p++] << 8 | (currentPixel & 0xFF);
                }
                else if (b1 == QoiCodec.Rgba)
                {
                    currentPixel = BinaryPrimitives.ReadInt32BigEndian(qoiData.AsSpan(p, 4));
                    p += 4;
                }
                else
                {
                    var runLength = b1 & 0x3F;
                    for (int i = runLength; i > 0; i--)
                    {
                        SetPixels(channels, pixels, currentPixel, pxPos);
                        pxPos += channels;
                    }
                    SetPixels(channels, pixels, currentPixel, pxPos);
                    continue;
                }
            }
            else
            {
                byte r;
                byte g;
                byte b;
                if ((b1 & QoiCodec.Mask2) == QoiCodec.Diff)
                {
                    r = (byte)(currentPixel >> 24);
                    g = (byte)(currentPixel >> 16);
                    b = (byte)(currentPixel >> 8);
                    r += (byte)(((b1 >> 4) & 0x03) - 2);
                    g += (byte)(((b1 >> 2) & 0x03) - 2);
                    b += (byte)((b1 & 0x03) - 2);
                    currentPixel = r << 24 | g << 16 | b << 8 | (currentPixel & 0xFF);
                }
                else if ((b1 & QoiCodec.Mask2) == QoiCodec.Luma)
                {
                    int b2 = qoiData[p++];
                    int vg = (b1 & 0x3F) - 32;
                    r = (byte)(currentPixel >> 24);
                    g = (byte)(currentPixel >> 16);
                    b = (byte)(currentPixel >> 8);
                    r += (byte)(vg - 8 + ((b2 >> 4) & 0x0F));
                    g += (byte)vg;
                    b += (byte)(vg - 8 + (b2 & 0x0F));
                    currentPixel = r << 24 | g << 16 | b << 8 | (currentPixel & 0xFF);
                }
                else //b1 is an QoiCodec.Index
                {
                    currentPixel = intIndex[b1 & ~QoiCodec.Mask2];
                    SetPixels(channels, pixels, currentPixel, pxPos);
                    continue;
                }
            }
            var indexPos3 = QoiCodec.CalculateHashTableRgbaIndex(currentPixel);
            intIndex[indexPos3] = currentPixel;

            SetPixels(channels, pixels, currentPixel, pxPos);
        }

        int pixelsEnd = qoiData.Length - QoiCodec.Padding.Length;
        for (int padIdx = 0; padIdx < QoiCodec.Padding.Length; padIdx++)
        {
            if (qoiData[pixelsEnd + padIdx] != QoiCodec.Padding[padIdx])
            {
                throw new InvalidOperationException("Invalid padding");
            }
        }

        return new QoiImage(pixels, width, height, (Channels)channels, colorSpace);
    }

    /// <summary>
    /// Decodes QOI data into raw pixel data.
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="image"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="channels"></param>
    /// <param name="color_space"></param>
    /// <exception cref="QoiDecodingException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static void Decode(ReadOnlySpan<byte> buffer, Span<byte> image, out int width, out int height,
        out Channels channels, out ColorSpace color_space)
    {
        if (buffer.Length < QoiCodec.HeaderSize + QoiCodec.Padding.Length)
            throw new QoiDecodingException("File too short");

        if (!QoiCodec.IsValidMagic(buffer.Slice(0, 4)))
            throw new QoiDecodingException("Invalid file magic");

        width = BinaryPrimitives.ReadInt32BigEndian(buffer.Slice(4, 4));
        height = BinaryPrimitives.ReadInt32BigEndian(buffer.Slice(8, 4));
        channels = (Channels)buffer[12];
        color_space = (ColorSpace)buffer[13];

        if (width == 0)
            throw new QoiDecodingException($"Invalid width: {width}");
        if (height == 0 || height >= QoiCodec.MaxPixels / width)
            throw new QoiDecodingException($"Invalid height: {height}. Maximum for this image is {QoiCodec.MaxPixels / width - 1}");
        if (channels is not Channels.Rgb and not Channels.RgbWithAlpha)
            throw new QoiDecodingException($"Invalid number of channels: {channels}");

        int[] intIndex = new int[QoiCodec.HashTableSize];
        if (channels == Channels.Rgb)
        {
            for (int indexPos = 0; indexPos < intIndex.Length; indexPos++)
            {
                intIndex[indexPos] = 255;
            }
        }

        int p = QoiCodec.HeaderSize;

        int currentPixel = 255;

        for (int pxPos = 0; pxPos < image.Length; pxPos += (byte)channels)
        {
            byte b1 = buffer[p++];
            if (b1 >> 6 == 3)
            {
                if (b1 == QoiCodec.Rgb)
                {
                    currentPixel = buffer[p++] << 24 | buffer[p++] << 16 | buffer[p++] << 8 | (currentPixel & 0xFF);
                }
                else if (b1 == QoiCodec.Rgba)
                {
                    currentPixel = BinaryPrimitives.ReadInt32BigEndian(buffer.Slice(p, 4));
                    p += 4;
                }
                else
                {
                    var runLength = b1 & 0x3F;
                    for (int i = runLength; i > 0; i--)
                    {
                        SetPixels(channels, image.Slice(pxPos, (byte)channels), currentPixel);
                        pxPos += (byte)channels;
                    }
                    SetPixels(channels, image.Slice(pxPos, (byte)channels), currentPixel);
                    continue;
                }
            }
            else
            {
                byte r, g, b;
                if ((b1 & QoiCodec.Mask2) == QoiCodec.Diff)
                {
                    r = (byte)(currentPixel >> 24);
                    g = (byte)(currentPixel >> 16);
                    b = (byte)(currentPixel >> 8);
                    r += (byte)(((b1 >> 4) & 0x03) - 2);
                    g += (byte)(((b1 >> 2) & 0x03) - 2);
                    b += (byte)((b1 & 0x03) - 2);
                    currentPixel = r << 24 | g << 16 | b << 8 | (currentPixel & 0xFF);
                }
                else if ((b1 & QoiCodec.Mask2) == QoiCodec.Luma)
                {
                    int b2 = buffer[p++];
                    int vg = (b1 & 0x3F) - 32;
                    r = (byte)(currentPixel >> 24);
                    g = (byte)(currentPixel >> 16);
                    b = (byte)(currentPixel >> 8);
                    r += (byte)(vg - 8 + ((b2 >> 4) & 0x0F));
                    g += (byte)vg;
                    b += (byte)(vg - 8 + (b2 & 0x0F));
                    currentPixel = r << 24 | g << 16 | b << 8 | (currentPixel & 0xFF);
                }
                else //b1 is an QoiCodec.Index
                {
                    currentPixel = intIndex[b1 & ~QoiCodec.Mask2];
                    SetPixels(channels, image.Slice(pxPos, (byte)channels), currentPixel);
                    continue;
                }
            }
            var indexPos3 = QoiCodec.CalculateHashTableRgbaIndex(currentPixel);
            intIndex[indexPos3] = currentPixel;

            SetPixels(channels, image.Slice(pxPos, (byte)channels), currentPixel);
        }

        int pixelsEnd = buffer.Length - QoiCodec.Padding.Length;
        for (int padIdx = 0; padIdx < QoiCodec.Padding.Length; padIdx++)
        {
            if (buffer[pixelsEnd + padIdx] != QoiCodec.Padding[padIdx])
            {
                throw new InvalidOperationException("Invalid padding");
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void SetPixels(byte channels, byte[] pixels, int rgba, int pxPos)
    {
        pixels[pxPos] = (byte)(rgba >> 24);
        pixels[pxPos + 1] = (byte)(rgba >> 16);
        pixels[pxPos + 2] = (byte)(rgba >> 8);
        if (channels == 4)
        {
            pixels[pxPos + 3] = (byte)rgba;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void SetPixels(Channels channels, Span<byte> pixels, int rgba)
    {
        pixels[0] = (byte)(rgba >> 24);
        pixels[1] = (byte)(rgba >> 16);
        pixels[2] = (byte)(rgba >> 8);
        if ((byte)channels == 4)
        {
            pixels[3] = (byte)rgba;
        }
    }
}

/// <summary>
/// QOI encoder.
/// </summary>
public static class QoiEncoder
{
    /// <summary>
    /// Encodes raw pixel data into QOI.
    /// </summary>
    /// <param name="image">QOI image.</param>
    /// <returns>Encoded image.</returns>
    /// <exception cref="QoiEncodingException">Thrown when image information is invalid.</exception>
    public static byte[] Encode(QoiImage image)
    {
        if (image.Width == 0)
        {
            throw new QoiEncodingException($"Invalid width: {image.Width}");
        }

        if (image.Height == 0 || image.Height >= QoiCodec.MaxPixels / (long)image.Width)
        {
            throw new QoiEncodingException($"Invalid height: {image.Height}. Maximum for this image is {QoiCodec.MaxPixels / image.Width - 1}");
        }

        long imagePixelCount = image.Width * (long)image.Height;
        byte channels = (byte)image.Channels;
        long pixelsLength = imagePixelCount * channels;
        byte[] pixels = image.Data;

        if (pixels.Length != pixelsLength)
        {
            throw new QoiEncodingException($"Invalid pixel data length: {pixels.Length}. Expected: {pixelsLength}");
        }

        byte[] bytes = new byte[QoiCodec.HeaderSize + QoiCodec.Padding.Length + (imagePixelCount * (channels + 1))];
        QoiEncoderInternal.WriteHeader(bytes, image);
        int p = QoiCodec.HeaderSize;

        (_, int run, p) = channels == 4
            ? QoiEncoderInternal.RunRgbaCompression(pixels, bytes, p, pixels.Length, 0, 255, stackalloc int[QoiCodec.HashTableSize])
            : QoiEncoderInternal.RunRgbCompression(pixels, bytes, p, pixels.Length, 0, 0, stackalloc int[QoiCodec.HashTableSize]);
        //Check if the last pixel was a run, if so, write it out
        if (run > 0)
        {
            bytes[p++] = (byte)(QoiCodec.Run | (run - 1));
        }
        //Add Padding
        for (int padIdx = 0; padIdx < QoiCodec.Padding.Length; padIdx++)
        {
            bytes[p + padIdx] = QoiCodec.Padding[padIdx];
        }
        //return relevant bytes
        p += QoiCodec.Padding.Length;
        return bytes[..p];
    }

    /// <summary>
    /// Encode with external buffer, without new alloc
    /// </summary>
    /// <param name="image"></param>
    /// <param name="stride"></param>
    /// <param name="roi_width"></param>
    /// <param name="roi_height"></param>
    /// <param name="buffer"></param>
    /// <param name="channels"></param>
    /// <param name="color_space"></param>
    /// <returns>return encoder used length</returns>
    public static int Encode(ReadOnlySpan<byte> image, int stride, int roi_width, int roi_height,
        Span<byte> buffer, Channels channels = Channels.Rgb, ColorSpace color_space = ColorSpace.Linear)
    {
        if (roi_width == 0)
            throw new QoiEncodingException($"Invalid width: {roi_width}");

        if (roi_height == 0 || roi_height >= QoiCodec.MaxPixels / roi_width)
            throw new QoiEncodingException($"Invalid height: {roi_height}. Maximum for this image is {QoiCodec.MaxPixels / roi_width - 1}");

        if (stride < roi_width * (byte)channels)
            throw new QoiEncodingException($"Invalid stride: {stride}, minimum is {roi_width * (byte)channels}");

        if (stride != roi_width * (byte)channels)
            throw new NotImplementedException("support different stride in future");   // todo

        if (image.Length < stride * roi_height)
            throw new QoiEncodingException($"Invalid pixel data length: {image.Length}. Expected: {stride * roi_height}");

        QoiEncoderInternal.WriteHeader(buffer, roi_width, roi_height, channels, color_space);
        int p = QoiCodec.HeaderSize;

        (_, int run, p) = channels == Channels.RgbWithAlpha
            ? QoiEncoderInternal.RunRgbaCompression(image, buffer, p, 0, 255, stackalloc int[QoiCodec.HashTableSize])
            : QoiEncoderInternal.RunRgbCompression(image, buffer, p, 0, 0, stackalloc int[QoiCodec.HashTableSize]);
        //Check if the last pixel was a run, if so, write it out
        if (run > 0)
        {
            buffer[p++] = (byte)(QoiCodec.Run | (run - 1));
        }
        //Add Padding
        for (int padIdx = 0; padIdx < QoiCodec.Padding.Length; padIdx++)
        {
            buffer[p + padIdx] = QoiCodec.Padding[padIdx];
        }
        //return relevant bytes
        p += QoiCodec.Padding.Length;
        return p;
    }

}


/// <summary>
/// QOI encoder.
/// </summary>
internal static class QoiEncoderInternal
{
    /// <summary>
    /// Encodes raw rgba pixel data into QOI.
    /// </summary>  
    internal static (int previousPixel, int run, int bytesPos) RunRgbaCompression
        (byte[] pixelsToCompress, byte[] outputBytes, int bytesPos, int pixelsLength, int run, int previousPixel, Span<int> pixelHashTable)
    {
        int currentPixel;
        for (int pxPos = 0; pxPos < pixelsLength; pxPos += 4)
        {
            currentPixel = BinaryPrimitives.ReadInt32BigEndian(pixelsToCompress.AsSpan(pxPos, 4));
            if (previousPixel == currentPixel)
            {
                run++;
                if (run == 62)
                {
                    outputBytes[bytesPos++] = (byte)(QoiCodec.Run | (run - 1));
                    run = 0;
                }
            }
            else
            {
                if (run > 0)
                {
                    outputBytes[bytesPos++] = (byte)(QoiCodec.Run | (run - 1));
                    run = 0;
                }
                int indexPos = QoiCodec.CalculateHashTableRgbaIndex(currentPixel);
                if (currentPixel == pixelHashTable[indexPos])
                {
                    outputBytes[bytesPos++] = (byte)(QoiCodec.Index | (indexPos));
                }
                else
                {
                    pixelHashTable[indexPos] = currentPixel;
                    if ((currentPixel & 0xFF) == (previousPixel & 0xFF))
                    {
                        int vr = (currentPixel >> 24) - (previousPixel >> 24) + 2;
                        int vg = ((currentPixel >> 16) & 0xFF) - ((previousPixel >> 16) & 0xFF) + 2;
                        int vb = ((currentPixel >> 8) & 0xFF) - ((previousPixel >> 8) & 0xFF) + 2;
                        if ((uint)vr < 4 &&
                            (uint)vg < 4 &&
                            (uint)vb < 4)
                        {
                            outputBytes[bytesPos++] = (byte)(QoiCodec.Diff | vr << 4 | vg << 2 | vb);
                        }
                        else
                        {
                            int vgr = vr - vg + 8;
                            int vgb = vb - vg + 8;
                            vg += 30; // -2 from the previous calculation and +32 to fit into the range of -32 to 31
                            if ((uint)vgr < 16 &&
                                 (uint)vgb < 16 &&
                                 (uint)vg < 64)
                            {
                                outputBytes[bytesPos++] = (byte)(QoiCodec.Luma | vg);
                                outputBytes[bytesPos++] = (byte)(vgr << 4 | vgb);
                            }
                            else
                            {
                                outputBytes[bytesPos++] = QoiCodec.Rgb;
                                outputBytes[bytesPos++] = (byte)(currentPixel >> 24);
                                outputBytes[bytesPos++] = (byte)(currentPixel >> 16);
                                outputBytes[bytesPos++] = (byte)(currentPixel >> 8);
                            }
                        }
                    }
                    else
                    {
                        outputBytes[bytesPos++] = QoiCodec.Rgba;
                        BinaryPrimitives.WriteInt32BigEndian(outputBytes.AsSpan(bytesPos, 4), currentPixel);
                        bytesPos += 4;
                    }
                }
            }
            previousPixel = currentPixel;
        }
        return (previousPixel, run, bytesPos);
    }

    /// <summary>
    /// Encodes raw rgba pixel data into QOI.
    /// </summary>  
    internal static (int previousPixel, int run, int bytesPos) RunRgbaCompression
        (ReadOnlySpan<byte> pixelsToCompress, Span<byte> outputBytes, int bytesPos, int run, int previousPixel, Span<int> pixelHashTable)
    {
        for (int pxPos = 0; pxPos < pixelsToCompress.Length; pxPos += 4)
        {
            var currentPixel = BinaryPrimitives.ReadInt32BigEndian(pixelsToCompress.Slice(pxPos, 4));
            if (previousPixel == currentPixel)
            {
                run++;
                if (run == 62)
                {
                    outputBytes[bytesPos++] = (byte)(QoiCodec.Run | (run - 1));
                    run = 0;
                }
            }
            else
            {
                if (run > 0)
                {
                    outputBytes[bytesPos++] = (byte)(QoiCodec.Run | (run - 1));
                    run = 0;
                }
                int indexPos = QoiCodec.CalculateHashTableRgbaIndex(currentPixel);
                if (currentPixel == pixelHashTable[indexPos])
                {
                    outputBytes[bytesPos++] = (byte)(QoiCodec.Index | (indexPos));
                }
                else
                {
                    pixelHashTable[indexPos] = currentPixel;
                    if ((currentPixel & 0xFF) == (previousPixel & 0xFF))
                    {
                        int vr = (currentPixel >> 24) - (previousPixel >> 24) + 2;
                        int vg = ((currentPixel >> 16) & 0xFF) - ((previousPixel >> 16) & 0xFF) + 2;
                        int vb = ((currentPixel >> 8) & 0xFF) - ((previousPixel >> 8) & 0xFF) + 2;
                        if ((uint)vr < 4 &&
                            (uint)vg < 4 &&
                            (uint)vb < 4)
                        {
                            outputBytes[bytesPos++] = (byte)(QoiCodec.Diff | vr << 4 | vg << 2 | vb);
                        }
                        else
                        {
                            int vgr = vr - vg + 8;
                            int vgb = vb - vg + 8;
                            vg += 30; // -2 from the previous calculation and +32 to fit into the range of -32 to 31
                            if ((uint)vgr < 16 &&
                                 (uint)vgb < 16 &&
                                 (uint)vg < 64)
                            {
                                outputBytes[bytesPos++] = (byte)(QoiCodec.Luma | vg);
                                outputBytes[bytesPos++] = (byte)(vgr << 4 | vgb);
                            }
                            else
                            {
                                outputBytes[bytesPos++] = QoiCodec.Rgb;
                                outputBytes[bytesPos++] = (byte)(currentPixel >> 24);
                                outputBytes[bytesPos++] = (byte)(currentPixel >> 16);
                                outputBytes[bytesPos++] = (byte)(currentPixel >> 8);
                            }
                        }
                    }
                    else
                    {
                        outputBytes[bytesPos++] = QoiCodec.Rgba;
                        BinaryPrimitives.WriteInt32BigEndian(outputBytes.Slice(bytesPos, 4), currentPixel);
                        bytesPos += 4;
                    }
                }
            }
            previousPixel = currentPixel;
        }
        return (previousPixel, run, bytesPos);
    }

    /// <summary>
    /// Encodes raw rgb pixel data into QOI.
    /// </summary>  
    internal static (int previousPixel, int run, int bytesPos) RunRgbCompression
        (byte[] pixelsToCompress, byte[] outputBytes, int bytesPos, int pixelsLength, int run, int previousPixel, Span<int> pixelHashTable)
    {
        int currentPixel;
        for (int pxPos = 0; pxPos < pixelsLength; pxPos += 3)
        {
            currentPixel = pixelsToCompress[pxPos] << 16 | pixelsToCompress[pxPos + 1] << 8 | pixelsToCompress[pxPos + 2];
            if (previousPixel == currentPixel)
            {
                run++;
                if (run == 62)
                {
                    outputBytes[bytesPos++] = (byte)(QoiCodec.Run | (run - 1));
                    run = 0;
                }
            }
            else
            {
                if (run > 0)
                {
                    outputBytes[bytesPos++] = (byte)(QoiCodec.Run | (run - 1));
                    run = 0;
                }

                int indexPos = CalculateHashTableRgbIndex(currentPixel);
                if (currentPixel == pixelHashTable[indexPos])
                {
                    outputBytes[bytesPos++] = (byte)(QoiCodec.Index | (indexPos));
                }
                else
                {
                    pixelHashTable[indexPos] = currentPixel;
                    int vr = (currentPixel >> 16) - (previousPixel >> 16) + 2;
                    int vg = ((currentPixel >> 8) & 0xFF) - ((previousPixel >> 8) & 0xFF) + 2;
                    int vb = (currentPixel & 0xFF) - (previousPixel & 0xFF) + 2;
                    if ((uint)vr < 4 &&
                        (uint)vg < 4 &&
                        (uint)vb < 4)
                    {
                        outputBytes[bytesPos++] = (byte)(QoiCodec.Diff | vr << 4 | vg << 2 | vb);
                    }
                    else
                    {
                        int vgr = vr - vg + 8;
                        int vgb = vb - vg + 8;
                        vg += 30; // -2 from the previous calculation and +32 to fit into the range of -32 to 31
                        if ((uint)vgr < 16 &&
                             (uint)vgb < 16 &&
                             (uint)vg < 64)
                        {
                            outputBytes[bytesPos++] = (byte)(QoiCodec.Luma | vg);
                            outputBytes[bytesPos++] = (byte)(vgr << 4 | vgb);
                        }
                        else
                        {
                            BinaryPrimitives.WriteInt32BigEndian(outputBytes.AsSpan(bytesPos, 4), currentPixel | (QoiCodec.Rgb << 24));
                            bytesPos += 4;
                        }
                    }
                }
            }
            previousPixel = currentPixel;
        }
        return (previousPixel, run, bytesPos);
    }

    /// <summary>
    /// Encodes raw rgb pixel data into QOI.
    /// </summary>  
    internal static (int previousPixel, int run, int bytesPos) RunRgbCompression
        (ReadOnlySpan<byte> pixelsToCompress, Span<byte> outputBytes, int bytesPos, int run, int previousPixel, Span<int> pixelHashTable)
    {
        for (int pxPos = 0; pxPos < pixelsToCompress.Length; pxPos += 3)
        {
            var currentPixel = pixelsToCompress[pxPos] << 16 | pixelsToCompress[pxPos + 1] << 8 | pixelsToCompress[pxPos + 2];
            if (previousPixel == currentPixel)
            {
                run++;
                if (run == 62)
                {
                    outputBytes[bytesPos++] = (byte)(QoiCodec.Run | (run - 1));
                    run = 0;
                }
            }
            else
            {
                if (run > 0)
                {
                    outputBytes[bytesPos++] = (byte)(QoiCodec.Run | (run - 1));
                    run = 0;
                }

                int indexPos = CalculateHashTableRgbIndex(currentPixel);
                if (currentPixel == pixelHashTable[indexPos])
                {
                    outputBytes[bytesPos++] = (byte)(QoiCodec.Index | (indexPos));
                }
                else
                {
                    pixelHashTable[indexPos] = currentPixel;
                    int vr = (currentPixel >> 16) - (previousPixel >> 16) + 2;
                    int vg = ((currentPixel >> 8) & 0xFF) - ((previousPixel >> 8) & 0xFF) + 2;
                    int vb = (currentPixel & 0xFF) - (previousPixel & 0xFF) + 2;
                    if ((uint)vr < 4 &&
                        (uint)vg < 4 &&
                        (uint)vb < 4)
                    {
                        outputBytes[bytesPos++] = (byte)(QoiCodec.Diff | vr << 4 | vg << 2 | vb);
                    }
                    else
                    {
                        int vgr = vr - vg + 8;
                        int vgb = vb - vg + 8;
                        vg += 30; // -2 from the previous calculation and +32 to fit into the range of -32 to 31
                        if ((uint)vgr < 16 &&
                             (uint)vgb < 16 &&
                             (uint)vg < 64)
                        {
                            outputBytes[bytesPos++] = (byte)(QoiCodec.Luma | vg);
                            outputBytes[bytesPos++] = (byte)(vgr << 4 | vgb);
                        }
                        else
                        {
                            BinaryPrimitives.WriteInt32BigEndian(outputBytes.Slice(bytesPos, 4), currentPixel | (QoiCodec.Rgb << 24));
                            bytesPos += 4;
                        }
                    }
                }
            }
            previousPixel = currentPixel;
        }
        return (previousPixel, run, bytesPos);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CalculateHashTableRgbIndex(int packedPixel)
    {
        // Extract components and calculate hash in one expression
        return (((packedPixel >> 16) * 3) +
                (((packedPixel >> 8) & 0xFF) * 5) +
                ((packedPixel & 0xFF) * 7) + 2805/*result of Alpha 255 * 11*/) & 63;
    }

    /// <summary>
    /// Writes the QOI header to the output byte array.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void WriteHeader(byte[] outputBytes, QoiImage image)
    {
        WriteHeader(outputBytes, image.Width, image.Height, image.Channels, image.ColorSpace);
    }

    /// <summary>
    /// Writes the QOI header to the output byte array.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void WriteHeader(byte[] outputBytes, int width, int height, Channels channels, ColorSpace colorSpace)
    {
        outputBytes[0] = (byte)(QoiCodec.Magic >> 24);
        outputBytes[1] = (byte)(QoiCodec.Magic >> 16);
        outputBytes[2] = (byte)(QoiCodec.Magic >> 8);
        outputBytes[3] = (byte)QoiCodec.Magic;

        outputBytes[4] = (byte)(width >> 24);
        outputBytes[5] = (byte)(width >> 16);
        outputBytes[6] = (byte)(width >> 8);
        outputBytes[7] = (byte)width;

        outputBytes[8] = (byte)(height >> 24);
        outputBytes[9] = (byte)(height >> 16);
        outputBytes[10] = (byte)(height >> 8);
        outputBytes[11] = (byte)height;

        outputBytes[12] = (byte)channels;
        outputBytes[13] = (byte)colorSpace;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static void WriteHeader(Span<byte> outputBytes, int width, int height, Channels channels, ColorSpace colorSpace)
    {
        outputBytes[0] = (byte)(QoiCodec.Magic >> 24);
        outputBytes[1] = (byte)(QoiCodec.Magic >> 16);
        outputBytes[2] = (byte)(QoiCodec.Magic >> 8);
        outputBytes[3] = (byte)QoiCodec.Magic;

        outputBytes[4] = (byte)(width >> 24);
        outputBytes[5] = (byte)(width >> 16);
        outputBytes[6] = (byte)(width >> 8);
        outputBytes[7] = (byte)width;

        outputBytes[8] = (byte)(height >> 24);
        outputBytes[9] = (byte)(height >> 16);
        outputBytes[10] = (byte)(height >> 8);
        outputBytes[11] = (byte)height;

        outputBytes[12] = (byte)channels;
        outputBytes[13] = (byte)colorSpace;
    }

}


// /// <summary>
// /// QOI decoder.
// /// </summary>
// public class QoiDecoderStream : Stream
// {
//     public QoiDecoderStream(Stream qoiStream)
//     {
//         byte[] qoiData = new byte[QoiCodec.HeaderSize];
//         if (qoiStream.Read(qoiData, 0, qoiData.Length) != qoiData.Length)
//         {
//             throw new QoiDecodingException("QOI header too short");
//         }

//         if (!QoiCodec.IsValidMagic(qoiData[..4]))
//         {
//             throw new QoiDecodingException("Invalid file magic");
//         }

//         Width = BinaryPrimitives.ReadInt32BigEndian(qoiData.AsSpan(4, 4));
//         Height = BinaryPrimitives.ReadInt32BigEndian(qoiData.AsSpan(8, 4));
//         Channels = (Channels)qoiData[12];
//         ColorSpace = (ColorSpace)qoiData[13];

//         if (Width < 1)
//         {
//             throw new QoiDecodingException($"Invalid width: {Width}");
//         }
//         if (Height < 1)
//         {
//             throw new QoiDecodingException($"Invalid height: {Height}");
//         }
//         if (Channels is not Channels.Rgb and not Channels.RgbWithAlpha)
//         {
//             throw new QoiDecodingException($"Invalid number of channels: {Channels}");
//         }

//         qoiDataStream = qoiStream;

//         pixelOutputBuffer = new byte[3600]; //this number must be dividable by 12, because 3*4 = 12
//         qoiInputBuffer = new byte[4096];
//         pixelsLeftToWrite = (long)Width * Height * (long)Channels;
//     }

//     public override bool CanRead => true;
//     public override bool CanSeek => false;
//     public override bool CanWrite => false;
//     public override long Length => throw new NotSupportedException();
//     public override long Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }

//     private Stream qoiDataStream = new MemoryStream([]);
//     public ColorSpace ColorSpace { get; private set; }
//     public int Width { get; private set; }
//     public int Height { get; private set; }
//     public Channels Channels { get; private set; }
//     private byte[] pixelOutputBuffer = [];
//     private byte[] qoiInputBuffer = [];
//     private int qoiInputBufferPosition = 0;
//     private int qoiInputBufferLength = 0;
//     private int outputPixelStartPos = 0;
//     private int outputPixelLength = 0;
//     private long pixelsLeftToWrite = 0;
//     private int[] pixelHashTable = new int[QoiCodec.HashTableSize];
//     private int currentPixel = 255;
//     private int runLength = -1;
//     private bool reachedEndOfStream = false;

//     public override int Read(byte[] buffer, int offset, int count)
//     {
//         int bytesWrittenTotal = 0;
//         var bytesToWriteToBuffer = count - offset;
//         int remainingBytesToWriteBack = count - offset;
//         if (outputPixelLength > 0)
//         {
//             bytesWrittenTotal = CopyBytesToOutputBuffer(buffer, offset, bytesWrittenTotal, remainingBytesToWriteBack);
//             if (bytesWrittenTotal == bytesToWriteToBuffer)
//             {
//                 return bytesWrittenTotal;
//             }
//             remainingBytesToWriteBack = count - offset - bytesWrittenTotal;
//         }
//         if (reachedEndOfStream)
//         {
//             return bytesWrittenTotal;
//         }
//         byte r = 0;
//         byte g = 0;
//         byte b = 0;

//         //Caching the pixel here improeves performance
//         var pixel = currentPixel;
//         do
//         {
//             var bytesToWrite = Math.Min(remainingBytesToWriteBack, (int)Math.Min(pixelsLeftToWrite, pixelOutputBuffer.Length));
//             int pxPos = 0;
//             for (; runLength >= 0; runLength--)
//             {
//                 SetPixels(Channels, pixelOutputBuffer, pixel, pxPos);
//                 pxPos += (byte)Channels;
//             }
//             for (; pxPos < bytesToWrite; pxPos += (byte)Channels)
//             {
//                 ReadMoreBytesFromInputIfNecessary();

//                 byte b1 = qoiInputBuffer[qoiInputBufferPosition++];
//                 if (b1 >> 6 == 3)
//                 {
//                     if (b1 == QoiCodec.Rgb)
//                     {
//                         pixel = qoiInputBuffer[qoiInputBufferPosition++] << 24 | qoiInputBuffer[qoiInputBufferPosition++] << 16
//                             | qoiInputBuffer[qoiInputBufferPosition++] << 8 | (pixel & 0xFF);
//                     }
//                     else if (b1 == QoiCodec.Rgba)
//                     {
//                         pixel = BinaryPrimitives.ReadInt32BigEndian(qoiInputBuffer.AsSpan(qoiInputBufferPosition, 4));
//                         qoiInputBufferPosition += 4;
//                     }
//                     else //QoiCodec.Run
//                     {
//                         runLength = b1 & 0x3F;
//                         if ((pxPos + (runLength + 1) * (byte)Channels) < bytesToWrite)
//                         {
//                             for (; runLength >= 0; runLength--)
//                             {
//                                 SetPixels(Channels, pixelOutputBuffer, pixel, pxPos);
//                                 pxPos += (byte)Channels;
//                             }
//                             pxPos -= (byte)Channels;
//                         }
//                         else
//                         {
//                             for (; runLength > 0 && pxPos < bytesToWrite; runLength--)
//                             {
//                                 SetPixels(Channels, pixelOutputBuffer, pixel, pxPos);
//                                 pxPos += (byte)Channels;
//                             }
//                             if (pxPos < bytesToWrite)
//                             {
//                                 runLength--;
//                                 SetPixels(Channels, pixelOutputBuffer, pixel, pxPos);
//                             }
//                             else
//                             {
//                                 break;
//                             }
//                         }
//                         continue;
//                     }
//                 }
//                 else
//                 {
//                     if ((b1 & QoiCodec.Mask2) == QoiCodec.Diff)
//                     {
//                         r = (byte)(pixel >> 24);
//                         g = (byte)(pixel >> 16);
//                         b = (byte)(pixel >> 8);
//                         r += (byte)(((b1 >> 4) & 0x03) - 2);
//                         g += (byte)(((b1 >> 2) & 0x03) - 2);
//                         b += (byte)((b1 & 0x03) - 2);
//                         pixel = r << 24 | g << 16 | b << 8 | (pixel & 0xFF);
//                     }
//                     else if ((b1 & QoiCodec.Mask2) == QoiCodec.Luma)
//                     {
//                         int b2 = qoiInputBuffer[qoiInputBufferPosition++];
//                         int vg = (b1 & 0x3F) - 32;
//                         r = (byte)(pixel >> 24);
//                         g = (byte)(pixel >> 16);
//                         b = (byte)(pixel >> 8);
//                         r += (byte)(vg - 8 + ((b2 >> 4) & 0x0F));
//                         g += (byte)vg;
//                         b += (byte)(vg - 8 + (b2 & 0x0F));
//                         pixel = r << 24 | g << 16 | b << 8 | (pixel & 0xFF);
//                     }
//                     else //b1 is an index
//                     {
//                         pixel = pixelHashTable[b1 & ~QoiCodec.Mask2];
//                         SetPixels(Channels, pixelOutputBuffer, pixel, pxPos);
//                         continue;
//                     }
//                 }
//                 var indexPos3 = QoiCodec.CalculateHashTableRgbaIndex(pixel);
//                 pixelHashTable[indexPos3] = pixel;

//                 SetPixels(Channels, pixelOutputBuffer, pixel, pxPos);
//             }
//             outputPixelLength = pxPos;
//             bytesWrittenTotal = CopyBytesToOutputBuffer(buffer, offset, bytesWrittenTotal, remainingBytesToWriteBack);
//             if (bytesWrittenTotal == bytesToWriteToBuffer)
//             {
//                 currentPixel = pixel;
//                 return bytesWrittenTotal;
//             }
//             remainingBytesToWriteBack = (int)Math.Min(pixelsLeftToWrite, count - offset - bytesWrittenTotal);
//         }
//         while (remainingBytesToWriteBack > 0 && pixelsLeftToWrite > 0);

//         //Check the end of the stream
//         currentPixel = pixel;
//         reachedEndOfStream = true;
//         if (qoiInputBufferLength - qoiInputBufferPosition < QoiCodec.Padding.Length)
//         {
//             qoiInputBufferLength = ReadMoreBytesFromInput();
//         }
//         if (qoiInputBufferLength - qoiInputBufferPosition < QoiCodec.Padding.Length)
//         {
//             throw new QoiDecodingException($"Input stream ended abruptly.");
//         }
//         var qoiData = qoiInputBuffer.AsSpan(qoiInputBufferPosition, QoiCodec.Padding.Length);
//         for (int padIdx = 0; padIdx < QoiCodec.Padding.Length; padIdx++)
//         {
//             if (qoiData[padIdx] != QoiCodec.Padding[padIdx])
//             {
//                 throw new QoiDecodingException("Invalid padding");
//             }
//         }
//         return bytesWrittenTotal;
//     }

//     [MethodImpl(MethodImplOptions.AggressiveInlining)]
//     private void ReadMoreBytesFromInputIfNecessary()
//     {
//         //Longest possible QOI block is 5 bytes, so we need to ensure that we have at least 5 bytes available
//         if (qoiInputBufferPosition + 5 >= qoiInputBufferLength)
//         {
//             qoiInputBufferLength = ReadMoreBytesFromInput();
//             if (qoiInputBufferLength < QoiCodec.Padding.Length)
//             {
//                 throw new QoiDecodingException($"Input stream added abruptly.");
//             }
//         }
//     }

//     [MethodImpl(MethodImplOptions.AggressiveInlining)]
//     private int ReadMoreBytesFromInput()
//     {
//         var remainingBytes = qoiInputBufferLength - qoiInputBufferPosition;
//         qoiInputBuffer.AsSpan(qoiInputBufferPosition, remainingBytes)
//             .CopyTo(qoiInputBuffer.AsSpan(0, remainingBytes));
//         qoiInputBufferLength = qoiDataStream.Read(qoiInputBuffer, remainingBytes, qoiInputBuffer.Length - remainingBytes);
//         qoiInputBufferLength += remainingBytes;
//         qoiInputBufferPosition = 0;
//         return qoiInputBufferLength;
//     }

//     [MethodImpl(MethodImplOptions.AggressiveInlining)]
//     private int CopyBytesToOutputBuffer(byte[] buffer, int bufferOffset, int bytesWrittenTotal, int remainingBytesToWriteBack)
//     {
//         var bytesToWriteOut = Math.Min(remainingBytesToWriteBack, outputPixelLength - outputPixelStartPos);
//         pixelOutputBuffer.AsMemory(outputPixelStartPos, bytesToWriteOut).CopyTo(buffer.AsMemory(bufferOffset + bytesWrittenTotal, bytesToWriteOut));
//         outputPixelStartPos = bytesToWriteOut == outputPixelLength - outputPixelStartPos
//             ? 0
//             //we have some more bytes to write out, so cache them for the next read
//             : bytesToWriteOut + outputPixelStartPos;
//         bytesWrittenTotal += bytesToWriteOut;
//         if (outputPixelStartPos == 0 || remainingBytesToWriteBack == 0)
//         {
//             outputPixelLength = 0; // Reset if the end of the output buffer was reached
//         }
//         pixelsLeftToWrite -= bytesToWriteOut;
//         return bytesWrittenTotal;
//     }

//     [MethodImpl(MethodImplOptions.AggressiveInlining)]
//     private static void SetPixels(Channels channels, byte[] pixels, int currentPixel, int pxPos)
//     {
//         pixels[pxPos] = (byte)(currentPixel >> 24);
//         pixels[pxPos + 1] = (byte)(currentPixel >> 16);
//         pixels[pxPos + 2] = (byte)(currentPixel >> 8);
//         if (channels == Channels.RgbWithAlpha)
//         {
//             pixels[pxPos + 3] = (byte)currentPixel;
//         }
//     }

//     public override void Flush()
//     {
//         //Does nothing, since this is a read based stream
//     }

//     public override long Seek(long offset, SeekOrigin origin)
//     {
//         throw new NotSupportedException();
//     }

//     public override void SetLength(long value)
//     {
//         throw new NotSupportedException();
//     }

//     public override void Write(byte[] buffer, int offset, int count)
//     {
//         throw new NotSupportedException();
//     }
// }



// /// <summary>
// /// QOI encoder stream.
// /// This stream reads raw pixel data and encodes it into QOI format on demand
// /// </summary>
// public class QoiEncoderStream : Stream
// {
//     public QoiEncoderStream(Stream pixelStream, int width, int height, Channels channels, ColorSpace colorSpace = ColorSpace.SRgb)
//     {
//         if (width < 1)
//         {
//             throw new QoiEncodingException($"Invalid width: {width}");
//         }
//         if (height < 1)
//         {
//             throw new QoiEncodingException($"Invalid height: {height}.");
//         }

//         PixelStream = pixelStream;
//         ImageSize = new Size(width, height);
//         Channels = channels;
//         var readArraySize = bufferSize / 4 * 3;
//         if (channels == Channels.RgbWithAlpha)
//         {
//             readArraySize = bufferSize / 5 * 4;
//             previousPixel = 255;
//         }

//         pixelInputBuffer = new byte[readArraySize];
//         //Write the header, ready to be read
//         QoiEncoderInternal.WriteHeader(outputBytesBuffer, ImageSize.Width, ImageSize.Height, channels, colorSpace);
//         outputPixelLength = QoiCodec.HeaderSize;
//     }

//     public override bool CanRead => true;
//     public override bool CanSeek => false;
//     public override bool CanWrite => false;
//     public override long Length => throw new NotSupportedException();
//     public override long Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }

//     /// <summary>
//     /// Size of the internal buffer used internaly
//     /// This number needs to be dividable by 60 (dividable by 3, 4 and 5)
//     /// </summary>
//     private const int bufferSize = 3000;
//     private Size ImageSize;
//     private Stream PixelStream;
//     private Channels Channels;

//     //Work variables:
//     private int previousPixel = 0;
//     private int equalPixelRun = 0;
//     private int readPixels = 0;
//     private byte[] pixelInputBuffer;
//     private byte[] outputBytesBuffer = new byte[bufferSize];
//     private int outputPixelStartPos = 0;
//     private int outputPixelLength = 0;
//     int[] pixelHashTable = new int[QoiCodec.HashTableSize];
//     private bool endOfStreamWritteToBuffer = false;

//     public override int Read(byte[] buffer, int offset, int count)
//     {
//         int read;
//         int bytesWrittenTotal = 0;
//         var bytesToWriteToBuffer = count - offset;
//         int remainingBytesToWriteBack = count - offset;
//         if (outputPixelLength > 0)
//         {
//             bytesWrittenTotal = CopyBytesToOutputBuffer(buffer, offset, bytesWrittenTotal, remainingBytesToWriteBack);
//             if (bytesWrittenTotal == bytesToWriteToBuffer)
//             {
//                 return bytesWrittenTotal;
//             }
//             remainingBytesToWriteBack = bytesToWriteToBuffer - bytesWrittenTotal;
//         }
//         if (endOfStreamWritteToBuffer)
//         {
//             return bytesWrittenTotal; // If the end of stream was already written to the buffer, return immediately
//         }
//         do
//         {
//             //Read from the image byte stream into the pixel buffer
//             read = PixelStream.Read(pixelInputBuffer, 0, pixelInputBuffer.Length);
//             if (read == 0)
//             {
//                 break; // End of stream
//             }
//             readPixels += read;
//             (previousPixel, equalPixelRun, outputPixelLength) = Channels == Channels.RgbWithAlpha
//                ? QoiEncoderInternal.RunRgbaCompression(pixelInputBuffer, outputBytesBuffer, 0, read, equalPixelRun, previousPixel, pixelHashTable)
//                : QoiEncoderInternal.RunRgbCompression(pixelInputBuffer, outputBytesBuffer, 0, read, equalPixelRun, previousPixel, pixelHashTable);
//             //Write the output bytes from the encoded block to the stream
//             bytesWrittenTotal = CopyBytesToOutputBuffer(buffer, offset, bytesWrittenTotal, remainingBytesToWriteBack);
//             if (bytesWrittenTotal == bytesToWriteToBuffer)
//             {
//                 return bytesWrittenTotal;
//             }
//             remainingBytesToWriteBack = bytesToWriteToBuffer - bytesWrittenTotal;
//         }
//         while (true);
//         long expectedPixelLength = (long)ImageSize.Width * ImageSize.Height * (int)Channels;
//         if (readPixels != expectedPixelLength)
//         {
//             throw new QoiEncodingException($"Invalid pixel data length: {readPixels}. Expected: {expectedPixelLength}");
//         }
//         //If the last block was a run, write it out
//         if (equalPixelRun > 0)
//         {
//             outputBytesBuffer[0] = (byte)(QoiCodec.Run | (equalPixelRun - 1));
//             outputPixelLength = 1;
//             equalPixelRun = 0;
//             bytesWrittenTotal = CopyBytesToOutputBuffer(buffer, offset, bytesWrittenTotal, remainingBytesToWriteBack);
//             if (bytesWrittenTotal == bytesToWriteToBuffer)
//             {
//                 return bytesWrittenTotal;
//             }
//             remainingBytesToWriteBack = bytesToWriteToBuffer - bytesWrittenTotal;
//         }

//         QoiCodec.Padding.AsMemory().CopyTo(outputBytesBuffer.AsMemory(0, QoiCodec.Padding.Length));
//         outputPixelLength = QoiCodec.Padding.Length;
//         endOfStreamWritteToBuffer = true;

//         bytesWrittenTotal = CopyBytesToOutputBuffer(buffer, offset, bytesWrittenTotal, remainingBytesToWriteBack);
//         return bytesWrittenTotal;
//     }

//     private int CopyBytesToOutputBuffer(byte[] buffer, int bufferOffset, int bytesWrittenTotal, int remainingBytesToWriteBack)
//     {
//         var bytesToWriteOut = Math.Min(remainingBytesToWriteBack, outputPixelLength - outputPixelStartPos);
//         outputBytesBuffer.AsMemory(outputPixelStartPos, bytesToWriteOut)
//             .CopyTo(buffer.AsMemory(bufferOffset + bytesWrittenTotal, bytesToWriteOut));
//         outputPixelStartPos = bytesToWriteOut == outputPixelLength - outputPixelStartPos
//             ? 0
//             //we have some more bytes to write out, so cache them for the next read
//             : bytesToWriteOut + outputPixelStartPos;
//         bytesWrittenTotal += bytesToWriteOut;
//         if (outputPixelStartPos == 0)
//         {
//             outputPixelLength = 0; // Reset if the end of the output buffer was reached
//         }
//         return bytesWrittenTotal;
//     }

//     public override void Flush()
//     {
//         //Does nothing, since this is a read based stream
//     }

//     public override long Seek(long offset, SeekOrigin origin)
//     {
//         throw new NotSupportedException();
//     }

//     public override void SetLength(long value)
//     {
//         throw new NotSupportedException();
//     }

//     public override void Write(byte[] buffer, int offset, int count)
//     {
//         throw new NotSupportedException();
//     }
// }

