#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Input;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct InputData()
{
    internal fixed byte Current[byte.MaxValue];
    internal fixed byte Previous[byte.MaxValue];
    internal fixed byte Keys[byte.MaxValue];

    internal int Mouse_CurrentFrame_Position_X = 0;
    internal int Mouse_CurrentFrame_Position_Y = 0;
    internal int Mouse_PreviousFrame_Position_X = 0;
    internal int Mouse_PreviousFrame_Position_Y = 0;
    internal int Mouse_Wheel = 0;
    internal int Mouse_CurrentFrame_Delta_X = 0;
    internal int Mouse_CurrentFrame_Delta_Y = 0;
    internal void* Handle = null;
}

#endif
