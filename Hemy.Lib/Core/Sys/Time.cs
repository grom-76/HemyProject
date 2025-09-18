namespace Hemy.Lib.Core.Sys;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#if WINDOWS
using Hemy.Lib.Core.Platform.Windows.Sys;
#endif

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Time(
#if WINDOWS
    TimeData* timeData
#endif
)
{
    /// <summary>
    /// Get elapsed time since the previous Update call.
    /// </summary>
    public ulong Ticks => TimeImpl.GetTick();

    // /// <summary>
    // /// Get elapsed time since the previous Update call.
    // /// </summary>
    // public ulong ElapsedSeconds => timeData->ElapsedInSec;

    // /// <summary>
    // /// Get total time since the start of the program.
    // /// </summary>
    // public double TotalTime => TimeImpl.GetTotalTime(timeData);

    // /// <summary>
    // /// Get total number of updates since start of the program.
    // /// </summary>
    public ulong FrameCount => timeData->FrameCount;

    // /// <summary>
    // /// Get the current framerate.
    // /// </summary>
    // public uint FramesPerSecond { get; private set; }

    // /// <summary>
    // /// Gets a value indicating whether or not the time is in fixed mode.
    // /// </summary>
    // public bool IsFixedTimeStep { get; private set; }
    [SkipLocalsInit]
    public double DeltaTime
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        get => timeData->DeltaTime/10000;
    }

    /// <summary>
    /// Interrupt elapsed time.
    /// </summary>
    public void Pause()
    {
#if WINDOWS
        TimeImpl.Pause(timeData);
#endif        
    }
    
     // After an intentional timing discontinuity (for instance a blocking IO operation)
    // call this to avoid having the fixed timestep logic attempt a set of catch-up
    // Update calls.
    public void Resume()
    {
#if WINDOWS
        TimeImpl.Resume(timeData);
#endif   
    }
}

