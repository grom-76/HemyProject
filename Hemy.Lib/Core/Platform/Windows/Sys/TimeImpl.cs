#if WINDOWS

namespace Hemy.Lib.Core.Platform.Sys.Sys;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using static Hemy.Lib.Core.Platform.Windows.Common.LibrariesName;


// [SkipLocalsInit]
// [SuppressUnmanagedCodeSecurity]
// [StructLayout(LayoutKind.Sequential)]
// internal static unsafe partial class SystemImplement
// {
//     [SkipLocalsInit]
//     internal static Platform CurrentOsPlatform => Platform.Window;
//     [SkipLocalsInit]
//     internal static uint CurrentThreadId => GetCurrentThreadId();
//     [SkipLocalsInit]
//     internal static uint CurrentProcessId => GetCurrentProcessId();
//     [SkipLocalsInit]
//     internal static uint CurrentProcessor => GetCurrentProcessorNumber();
//     [SkipLocalsInit]
//     internal static void* Hinstance => GetModuleHandleA(null);

//     [SkipLocalsInit]
//     [SuppressGCTransition]
//     [SuppressUnmanagedCodeSecurity]
//     internal static ulong InstalledMemory()
//     {
//         GetPhysicallyInstalledSystemMemory(out long memKb);
//         return (ulong)(memKb); // In GB  =>  / (1024 * 1024 * 1024)  pour MB  value / (1024 * 1024) 1073741824
//     }

//     [SkipLocalsInit]
//     [SuppressGCTransition]
//     [SuppressUnmanagedCodeSecurity]
//     internal static HE2.Core.Architecture GetArchitecture()
//     => RuntimeInformation.ProcessArchitecture switch
//     {
//         System.Runtime.InteropServices.Architecture.X86 => HE2.Core.Architecture.x86,
//         System.Runtime.InteropServices.Architecture.X64 => HE2.Core.Architecture.x64,
//         System.Runtime.InteropServices.Architecture.Arm => HE2.Core.Architecture.Arm,
//         System.Runtime.InteropServices.Architecture.Arm64 => HE2.Core.Architecture.Arm,
//         _ => HE2.Core.Architecture.Unsupported,
//     };
    
//      [SkipLocalsInit]
//     // [SuppressGCTransition]
//     [SuppressUnmanagedCodeSecurity]
//     [LibraryImport(Kernel, SetLastError = false)]
//     [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
//     [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
//     private static partial uint GetCurrentProcessId();

//     [SkipLocalsInit]
//     // [SuppressGCTransition]
//     [SuppressUnmanagedCodeSecurity]
//     [LibraryImport(Kernel, SetLastError = false)]
//     [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
//     [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
//     private static partial uint GetCurrentThreadId();
  
//     [SkipLocalsInit]
//     [SuppressGCTransition]
//     [SuppressUnmanagedCodeSecurity]
//     [LibraryImport(Kernel, SetLastError = false, EntryPoint = "GetModuleHandleA")]
//     [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
//     [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
//     private static partial void* GetModuleHandleA( /*LPCSTR*/ byte* lpModuleName);

//     [SkipLocalsInit]
//     [SuppressGCTransition]
//     [SuppressUnmanagedCodeSecurity]
//     [LibraryImport(Kernel, SetLastError = false)]
//     [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
//     [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
//     private static partial uint GetCurrentProcessorNumber();

//     // [SkipLocalsInit]
//     // [SuppressGCTransition]
//     // [SuppressUnmanagedCodeSecurity]
//     // [LibraryImport(Kernel, SetLastError = false)]
//     // [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
//     // [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
//     // private static partial uint GetActiveProcessorCount(uint count);

//     [SkipLocalsInit]
//     [SuppressGCTransition]
//     [SuppressUnmanagedCodeSecurity]
//     [LibraryImport(Kernel, SetLastError = false)]
//     [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
//     [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
//     private static partial int GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);
// }

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static unsafe partial class TimeImpl
{
    [SkipLocalsInit]
    internal static ulong TimeStamp
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining|MethodImplOptions.AggressiveOptimization )]
        get
        {
            _ = QueryPerformanceCounter(out ulong count);
            return count;
        }
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
