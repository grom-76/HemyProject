#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Sys;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using Hemy.Lib.Core.Sys;
using static Hemy.Lib.Core.Platform.Windows.LibrariesName;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static unsafe partial class TimeImpl
{
    internal static ulong cycles_ms = 0;
    public static void Init(TimeData* timeData)
    {
        int isHight = QueryPerformanceFrequency(out ulong count);
        timeData->IsHighPrecision = isHight != 0;
        timeData->Frequency  = timeData->IsHighPrecision ? count : 10_000;
        cycles_ms = timeData->Frequency/1000;
        timeData->Cycles_ms = cycles_ms;

        Start(timeData);
    }


    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static void Update(TimeData* timerData) // Tick 
    {

        timerData->CurrentFrameTime = GetTick() / cycles_ms;
        timerData->DeltaTime = timerData->CurrentFrameTime - timerData->PreviousFrameTime;

        timerData->FrameCount = timerData->FrameCount + 1;
        timerData->PreviousFrameTime =  timerData->CurrentFrameTime;
        //NEW 
    }

    // internal static double GetTotalTime(TimeData* timerData)
    //    => timerData->IsInPause
    //        ? (float)((timerData->StopTime - timerData->PausedTime - timerData->BaseTime) * timerData->Cycles)
    //        : (float)((timerData->TimeCurrent - timerData->PausedTime - timerData->BaseTime) * timerData->Cycles);

    internal static void Resume(TimeData* timerData) //unpause
    {
        if (timerData->State == TimeData.STOPPED) return;

        timerData->PreviousFrameTime = GetTick() / cycles_ms ;
        timerData->BaseTime = timerData->PreviousFrameTime;
        timerData->StopTime = 0;
        timerData->State = TimeData.RUNNING;
    }

    internal static void Start(TimeData* timerData) // Reset .????
    {
        if (timerData->State == TimeData.PAUSED)
        {
            Resume(timerData);
            return;
        }

        timerData->CurrentFrameTime = GetTick()  / cycles_ms ;
        timerData->PausedTime += timerData->CurrentFrameTime - timerData->StopTime;
        timerData->PreviousFrameTime = timerData->CurrentFrameTime; //timerData->BaseTime = timerData->CurrentFrameTime;
        timerData->StopTime = 0;
        timerData->State = TimeData.RUNNING;
    }

    internal static void Pause(TimeData* timerData) // STOP ???
    {
        if (timerData->State == TimeData.PAUSED) return;

        timerData->StopTime = GetTick() / cycles_ms ;
        timerData->State = TimeData.PAUSED;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static ulong GetTick()
    {
        _ = QueryPerformanceCounter(out ulong count);
        return count ;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int QueryPerformanceCounter(out ulong lpPerformanceCount);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int QueryPerformanceFrequency(out ulong frequency);

}

#endif
