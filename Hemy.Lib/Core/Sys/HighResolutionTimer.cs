namespace Hemy.Lib.Core.Sys;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#if WINDOWS
using Hemy.Lib.Core.Platform.Windows.Sys;
#endif

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public static class HighResolutionTimer
{
    [SkipLocalsInit]
    public static ulong TimeStamp
#if WINDOWS
    => TimeImpl.GetTick();
#else
    => 0;
#endif

    [SkipLocalsInit]
    public static ulong Frequency
#if WINDOWS
    => TimeImpl.GetFrequency();
#else
    => 0;
#endif

    [SkipLocalsInit]
    public static bool IsHighPrecision
#if WINDOWS
    => TimeImpl.IsHighTimer();
#else
    => false;
#endif

    
}
