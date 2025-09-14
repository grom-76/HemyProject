namespace Hemy.Lib.Core.Color;


using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


/// <summary>
/// Represente une couleur 32 bits RGBA => PIxelFormat : R8G8B8A8 non compresse
/// </summary>
[SkipLocalsInit]
[StructLayout(LayoutKind.Explicit)]
public ref partial struct Pixel // TODO : Appeler aussi Dot  => DPI dot per inch; 1 inch = 2.54 cm
{
    [FieldOffset(0)] public byte R;
    [FieldOffset(1)] public byte G;
    [FieldOffset(2)] public byte B;
    [FieldOffset(3)] public byte A;

    [FieldOffset(0)] public uint Color;

    public override string ToString() => $"({R},{G},{B},{A}) [0x{Color:X}]";

    public static class Convert
    {
        public static byte R(uint color) => Sys.Sys.IsBigEndian ? (byte)(color >> 16) : (byte)(color >> 8);
        public static byte G(uint color) => Sys.Sys.IsBigEndian ? (byte)(color >> 8) : (byte)(color >> 15);
        public static byte B(uint color) => Sys.Sys.IsBigEndian ? (byte)(color & 0x000000FF) : (byte)(color >> 24);
        public static byte A(uint color) => Sys.Sys.IsBigEndian ? (byte)(color >> 24) : (byte)(color & 0x000000FF);
    }
}
