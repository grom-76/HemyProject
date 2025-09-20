namespace Hemy.Lib.Core.Sys;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#if WINDOWS
using Hemy.Lib.Core.Platform.Windows.Sys;
#endif

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct Time(
#if WINDOWS
    TimeData* timeData
#endif
)
{
    /// <summary>
    ///  Genral Clock  Time from system in milisec need CretaContext beferoe sinon = 0
    /// </summary>
    [SkipLocalsInit]
    public readonly ulong TimeStamp => TimeImpl.GetTick() ;

   
    // /// </summary>
    // public double TotalTime => TimeImpl.GetTotalTime(timeData);

    // /// <summary>
    // /// Get total number of updates since start of the program.
    // /// </summary>
    [SkipLocalsInit]
    public readonly ulong FrameCount => timeData->FrameCount;


    // /// <summary>
    // /// Gets a value indicating whether or not the time is in fixed mode.
    // /// </summary>
    // public bool IsFixedTimeStep { get; private set; }

    /// <summary>
    /// Delta Time in miliseconde
    /// </summary>
    [SkipLocalsInit]
    public readonly double DeltaTime => timeData->DeltaTime ;
    
    /// <summary>
    /// Current Frame Time in miliseocond  
    /// </summary>
    [SkipLocalsInit]
    public readonly double CurrentFrameTime => timeData->CurrentFrameTime ;

     /// <summary>
    /// Previous Frame Time in miliseocond  
    /// </summary>
    [SkipLocalsInit]
    public readonly double PreviousFrameTime => timeData->PreviousFrameTime ;
 
    /// <summary>
    /// Interrupt elapsed time.
    /// </summary>
    public readonly void Pause()
    {
#if WINDOWS
        TimeImpl.Pause(timeData);
#endif        
    }

    // After an intentional timing discontinuity (for instance a blocking IO operation)
    // call this to avoid having the fixed timestep logic attempt a set of catch-up
    // Update calls.
    public readonly void Resume()
    {
#if WINDOWS
        TimeImpl.Resume(timeData);
#endif   
    }

    public enum TimerState : uint
    {
        Stopped = 0,
        Running = 1,
        Paused = 2
    }

    public readonly TimerState State => (TimerState)timeData->State;
}

