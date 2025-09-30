// namespace Hemy.Lib.V2.Platform.Windows;

// using System;
// using System.Runtime.CompilerServices;
// using System.Runtime.InteropServices;
// using System.Security;
// using System.Threading;

// using const_char = System.Byte;
// using BOOL = System.Int32;

// // https://learn.microsoft.com/en-us/windows/win32/winprog/windows-data-types
// using size_t = System.UIntPtr;
// using uint32_t = System.UInt32;
// using uint64_t = System.UInt64;
// using uint8_t = System.Byte;
// using int32_t = System.Int32;
// using int64_t = System.Int64;
// using uint16_t = System.UInt16;

// using VkBool32 = System.UInt32;
// using VkDeviceAddress = System.UInt64;
// using VkDeviceSize = System.UInt64;
// using Flag = System.Int32;

// using HRESULT = System.Int32;

// using static Hemy.Lib.V2.Platform.Windows.WindowsGraphicCommon;
// using static Hemy.Lib.V2.Platform.Windows.WindowsWindowCommon;
// using Hemy.Lib.V2.Core;
// using Bool32 = System.Int32;

// [SkipLocalsInit]
// [SuppressUnmanagedCodeSecurity]
// [StructLayout(LayoutKind.Sequential)]
// internal unsafe static partial class Images // https://github.com/SixLabors/ImageSharp/tree/main/src/ImageSharp/Formats/Png
// {

//     [MethodImpl(MethodImplOptions.AggressiveInlining)]
//     public static int ComputeColumns(int width, int passIndex)
//     {
//         uint w = (uint)width;

//         uint result = passIndex switch
//         {
//             0 => (w + 7) / 8,
//             1 => (w + 3) / 8,
//             2 => (w + 3) / 4,
//             3 => (w + 1) / 4,
//             4 => (w + 1) / 2,
//             5 => w / 2,
//             6 => w,
//             _ => int.MaxValue
//         };

//         return (int)result;

//     }

//     [MethodImpl(MethodImplOptions.AggressiveInlining)] /// Gets the height of the block.
//     public static int ComputeBlockHeight(int height, int pass)
//      => (height + RowIncrement[pass] - 1 - FirstRow[pass]) / RowIncrement[pass];

//     [MethodImpl(MethodImplOptions.AggressiveInlining)]
//     public static int ComputeBlockWidth(int width, int pass)
//     => (width + ColumnIncrement[pass] - 1 - FirstColumn[pass]) / ColumnIncrement[pass];

//     public static readonly int[] RowIncrement = [8, 8, 8, 4, 4, 2, 2];
//     public static readonly int[] FirstRow = [0, 0, 4, 0, 2, 0, 1];
//     public static readonly int[] FirstColumn = [0, 4, 0, 2, 0, 1, 0];
//     public static readonly int[] ColumnIncrement = [8, 8, 4, 4, 2, 2, 1];
//     /// <summary> The header bytes as a big-endian coded ulong. </summary>
//     public const ulong HeaderValue = 0x89504E470D0A1A0AUL;

//     /// <summary> The dictionary of available color types. </summary>
//     public static readonly Dictionary<PngColorType, byte[]> ColorTypes = new()
//     {
//         [PngColorType.Grayscale] = [1, 2, 4, 8, 16],
//         [PngColorType.Rgb] = [8, 16],
//         [PngColorType.Palette] = [1, 2, 4, 8],
//         [PngColorType.GrayscaleWithAlpha] = [8, 16],
//         [PngColorType.RgbWithAlpha] = [8, 16]
//     };
//     public const int MaxTextKeywordLength = 79;
//     public const int MinTextKeywordLength = 1;
//     public static ReadOnlySpan<byte> HeaderBytes =>
//     [
//         0x89, // Set the high bit.
//         0x50, // P
//         0x4E, // N
//         0x47, // G
//         0x0D, // Line ending CRLF
//         0x0A, // Line ending CRLF
//         0x1A, // EOF
//         0x0A // LF
//     ];
//     // Gets the keyword of the XMP metadata, encoded in an iTXT chunk.
//     public static ReadOnlySpan<byte> XmpKeyword =>
//     [
//         (byte)'X',
//         (byte)'M',
//         (byte)'L',
//         (byte)':',
//         (byte)'c',
//         (byte)'o',
//         (byte)'m',
//         (byte)'.',
//         (byte)'a',
//         (byte)'d',
//         (byte)'o',
//         (byte)'b',
//         (byte)'e',
//         (byte)'.',
//         (byte)'x',
//         (byte)'m',
//         (byte)'p'
//     ];

//     public enum PngBitDepth : byte    /// 1 bit per sample or per palette index (not per pixel).
//     {
//         Bit1 = 1,
//         Bit2 = 2,
//         Bit4 = 4,
//         Bit8 = 8,
//         Bit16 = 16
//     }
//     internal enum PngChunkType : uint
//     {
//         Data = 0x49444154U,
//         End = 0x49454E44U,
//         Header = 0x49484452U,
//         Palette = 0x504C5445U,
//         Exif = 0x65584966U,
//         Gamma = 0x67414D41U,
//         Physical = 0x70485973U,
//         Text = 0x74455874U,
//         CompressedText = 0x7A545874U,
//         InternationalText = 0x69545874U,
//         Transparency = 0x74524E53U,
//         Time = 0x74494d45,
//         Background = 0x624b4744,
//         EmbeddedColorProfile = 0x69434350,
//         SignificantBits = 0x73424954,
//         StandardRgbColourSpace = 0x73524742,
//         Histogram = 0x68495354,
//         SuggestedPalette = 0x73504c54,
//         Chroma = 0x6348524d,
//         Cicp = 0x63494350,
//         AnimationControl = 0x6163544cU,
//         FrameControl = 0x6663544cU,
//         FrameData = 0x66644154U,
//         ProprietaryApple = 0x43674249
//     }

//     [Flags]
//     public enum PngChunkFilter
//     {
//         None = 0,
//         ExcludePhysicalChunk = 1 << 0,
//         ExcludeGammaChunk = 1 << 1,
//         ExcludeExifChunk = 1 << 2,
//         ExcludeTextChunks = 1 << 3,
//         ExcludeAll = ~None
//     }

//     public enum PngColorType : byte
//     {
//         Grayscale = 0,
//         Rgb = 2,
//         Palette = 3,
//         GrayscaleWithAlpha = 4,
//         RgbWithAlpha = 6
//     }

//     public enum PngCompressionLevel
//     {
//         Level0 = 0,
//         NoCompression = Level0,
//         Level1 = 1,
//         BestSpeed = Level1,
//         Level2 = 2,
//         Level3 = 3,
//         Level4 = 4,
//         Level5 = 5,
//         Level6 = 6,
//         DefaultCompression = Level6,
//         Level7 = 7,
//         Level8 = 8,
//         Level9 = 9,
//         BestCompression = Level9,
//     }

//     public enum PngFilterMethod
//     {
//         None,
//         Sub,
//         Up,
//         Average,
//         Paeth,
//         Adaptive,
//     }
//     public enum PngInterlaceMode : byte
//     {
//         None = 0,
//         Adam7 = 1
//     }

//     internal readonly struct PngChunk
//     {
//         public int Length { get; }
//         public PngChunkType Type { get; }
//         public byte* Data { get; }
//     }

//     public const int MaxUncompressedAncillaryChunkSizeBytes = 8 * 1024 * 1024; // 8MB
//     public const int HeaderSize = 8;

//     private static bool IsSupportedFileFormat(ReadOnlySpan<byte> header)
//     {
//         return header.Length >= HeaderSize && System.Buffers.Binary.BinaryPrimitives.ReadUInt64BigEndian(header) == HeaderValue;
//     }

//     internal struct Image;

//     internal static Image* Decode(Stream stream, CancellationToken cancellationToken)
//     {
//         // Guard.NotNull(options, nameof(options));
//         // Guard.NotNull(stream, nameof(stream));

//         // PngDecoderCore decoder = new(options, true);
//         // ImageInfo info = decoder.Identify(options.GeneralOptions.Configuration, stream, cancellationToken);
//         // stream.Position = 0;

//         // PngMetadata meta = info.Metadata.GetPngMetadata();
//         // PngColorType color = meta.ColorType;
//         // PngBitDepth bits = meta.BitDepth;

//         // switch (color)
//         // {
//         //     case PngColorType.Grayscale:
//         //         if (bits == PngBitDepth.Bit16)
//         //         {
//         //             return !meta.TransparentColor.HasValue
//         //                 ? this.Decode<L16>(options, stream, cancellationToken)
//         //                 : this.Decode<La32>(options, stream, cancellationToken);
//         //         }

//         //         return !meta.TransparentColor.HasValue
//         //             ? this.Decode<L8>(options, stream, cancellationToken)
//         //             : this.Decode<La16>(options, stream, cancellationToken);

//         //     case PngColorType.Rgb:
//         //         if (bits == PngBitDepth.Bit16)
//         //         {
//         //             return !meta.TransparentColor.HasValue
//         //                 ? this.Decode<Rgb48>(options, stream, cancellationToken)
//         //                 : this.Decode<Rgba64>(options, stream, cancellationToken);
//         //         }

//         //         return !meta.TransparentColor.HasValue
//         //             ? this.Decode<Rgb24>(options, stream, cancellationToken)
//         //             : this.Decode<Rgba32>(options, stream, cancellationToken);

//         //     case PngColorType.Palette:
//         //         return this.Decode<Rgba32>(options, stream, cancellationToken);

//         //     case PngColorType.GrayscaleWithAlpha:
//         //         return (bits == PngBitDepth.Bit16)
//         //         ? this.Decode<La32>(options, stream, cancellationToken)
//         //         : this.Decode<La16>(options, stream, cancellationToken);

//         //     case PngColorType.RgbWithAlpha:
//         //         return (bits == PngBitDepth.Bit16)
//         //         ? this.Decode<Rgba64>(options, stream, cancellationToken)
//         //         : this.Decode<Rgba32>(options, stream, cancellationToken);

//         //     default:
//         //         return this.Decode<Rgba32>(options, stream, cancellationToken);
//         // }

//         return null;
//     }
    
   
// }