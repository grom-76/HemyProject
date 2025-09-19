#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Sys;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TimeData()
{
    internal ulong PreviousFrameTime = 0L;
    internal ulong CurrentFrameTime = 0L;

    internal ulong BaseTime = 0L;
    internal ulong StopTime = 0L;
    internal ulong PausedTime = 0L;

    internal ulong DeltaTime = 0UL;
    internal ulong FrameCount = 0;
    internal uint State = STOPPED; //Stopped, = 0  ;  Running = 1 ;   Paused 2 ;  Reset = remise a zero =stop puis start ;  Resume = unpause

    internal const uint STOPPED = 0;
    internal const uint RUNNING = 1;
    internal const uint PAUSED = 2;

}

#endif
