namespace Hemy.Lib.Core.Input;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#if WINDOWS
using Hemy.Lib.Core.Platform.Windows.Input;
#endif


[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct  Keyboard(
#if WINDOWS
    InputData* data
#endif    
    )
{
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsPressed(Key key)
        => (data->Current[data->Keys[(short)key] & 0xff] & 0x80) != 0 && (data->Previous[data->Keys[(short)key] & 0xff] & 0x80) == 0;

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsReleased(Key key)
        => (data->Current[data->Keys[(short)key] & 0xff] & 0x80) == 0 && (data->Previous[data->Keys[(short)key] & 0xff] & 0x80) != 0;

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsDown(Key key)
        => (data->Current[data->Keys[(short)key] & 0xff] & 0x80) != 0 && (data->Previous[data->Keys[(short)key] & 0xff] & 0x80) != 0;

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsUp(Key key)
        => (data->Current[data->Keys[(short)key] & 0xff] & 0x80) == 0 && (data->Previous[data->Keys[(short)key] & 0xff] & 0x80) == 0;

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl((MethodImplOptions)768 )]
    internal static Key KeyMapper(uint k)
#if WINDOWS
    => Hemy.Lib.Core.Platform.Windows.Utils.KeyMapper(k);
#else
    => key.Unknown;
#endif
}
