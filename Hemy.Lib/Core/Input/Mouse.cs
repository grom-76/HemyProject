namespace Hemy.Lib.Core.Input;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#if WINDOWS
using Hemy.Lib.Core.Platform.Windows.Input;
#endif


[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct Mouse(
#if WINDOWS
    InputData* data
#endif    
    )
{
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsPressed(MouseButton button)
        => (data->Current[data->Keys[(short)button] & 0xff] & 0x80) != 0 && (data->Previous[data->Keys[(short)button] & 0xff] & 0x80) == 0;

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsReleased(MouseButton button)
        => (data->Current[data->Keys[(short)button] & 0xff] & 0x80) == 0 && (data->Previous[data->Keys[(short)button] & 0xff] & 0x80) != 0;

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsDown(MouseButton button)
        => (data->Current[data->Keys[(short)button] & 0xff] & 0x80) != 0 && (data->Previous[data->Keys[(short)button] & 0xff] & 0x80) != 0;

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsUp(MouseButton button)
        => (data->Current[data->Keys[(short)button] & 0xff] & 0x80) == 0 && (data->Previous[data->Keys[(short)button] & 0xff] & 0x80) == 0;

    [SkipLocalsInit]
    public bool IsMouseMove =>( data->Mouse_CurrentFrame_Delta_X > 0 ||  data->Mouse_CurrentFrame_Delta_X < 0)  && (data->Mouse_CurrentFrame_Delta_Y > 0 || data->Mouse_CurrentFrame_Delta_Y < 0);

    [SkipLocalsInit]
    public int X => data->Mouse_CurrentFrame_Position_X;

    [SkipLocalsInit]
    public int Y => data->Mouse_CurrentFrame_Position_Y;

    [SkipLocalsInit]
    public int Delta_X => data->Mouse_CurrentFrame_Delta_X;

    [SkipLocalsInit]
    public int Delta_Y => data->Mouse_CurrentFrame_Delta_Y;

    public override string ToString()
         => $"[{data->Mouse_CurrentFrame_Position_X};{data->Mouse_CurrentFrame_Position_X}] Delta {data->Mouse_CurrentFrame_Delta_X} - {data->Mouse_CurrentFrame_Delta_Y} ";

    public void SetPostion(int x, int y)
    {
#if WINDOWS        
        InputImpl.SetMousePos(data, x, y);
#endif 
    }
}