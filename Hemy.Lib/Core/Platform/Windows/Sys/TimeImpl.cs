#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Sys;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using static Hemy.Lib.Core.Platform.Windows.LibrariesName;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static unsafe partial class TimeImpl
{

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static void Update(TimeData* timerData)
    {
        // ulong curTime = GetTick();
        // timerData->TimeCurrent = curTime * timerData->Cycles;
        // timerData->ElapsedInSec = timerData->IsInPause ? 0.0 : (curTime - timerData->PreviousTick) * timerData->Cycles;
        timerData->CurrentTick =  GetTick();

        timerData->DeltaTime =  timerData->IsInPause ? 0UL : timerData->CurrentTick - timerData->PreviousTick;

        timerData->PreviousTick = timerData->IsInPause ? timerData->PreviousTick : timerData->CurrentTick;

        timerData->FrameCount = timerData->IsInPause ? timerData->FrameCount : timerData->FrameCount + 1;
        //NEW 
        

    }

    // internal static double GetTotalTime(TimeData* timerData)
    //    => timerData->IsInPause
    //        ? (float)((timerData->StopTime - timerData->PausedTime - timerData->BaseTime) * timerData->Cycles)
    //        : (float)((timerData->TimeCurrent - timerData->PausedTime - timerData->BaseTime) * timerData->Cycles);

    internal static void Resume(TimeData* timerData)
    {
        timerData->PreviousTick = GetTick();
        timerData->BaseTime = timerData->PreviousTick;
        // timerData->TimeCurrent = timerData->PreviousTick * timerData->Cycles;
        timerData->StopTime = 0;
        timerData->IsInPause = false;
    }

    internal static void Start(TimeData* timerData)
    {
        if (!timerData->IsInPause) return;

        ulong startTime = GetTick();
        timerData->CurrentTick =  startTime;

        timerData->PausedTime += startTime - timerData->StopTime;

        timerData->PreviousTick = timerData->BaseTime = startTime;

        // timerData->TimeCurrent = timerData->PreviousTick * timerData->Cycles;
        timerData->StopTime = 0;
        timerData->IsInPause = false;
    }

    internal static void Pause(TimeData* timerData)
    {
        if (timerData->IsInPause) return;

        timerData->StopTime = GetTick();
        timerData->IsInPause = true;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static ulong GetTick()
    {
        _ = QueryPerformanceCounter(out ulong count);
        return count;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static ulong GetFrequency()
    {
        _ = QueryPerformanceFrequency(out ulong count);
        return count;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static bool IsHighTimer()
    {
        int isHight = QueryPerformanceFrequency(out ulong count);
        return isHight != 0;
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
