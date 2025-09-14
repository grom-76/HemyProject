#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Sys;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal unsafe struct TimeData()
{
    internal ulong PreviousTick = 0L;
    internal ulong BaseTime = 0L;
    internal ulong StopTime = 0L;
    internal ulong PausedTime = 0L;
    internal double ElapsedInMiliSec = 0.0;
    internal double Cycles = 1.0 / (double)TimeImpl.GetFrequency();
    internal double TimeCurrent = 0.0;
    internal bool IsInPause = false;
}

#endif
