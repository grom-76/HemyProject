#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Sys;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using static Hemy.Lib.Core.Platform.Windows.LibrariesName;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static unsafe partial class SystemImpl
{
    [SkipLocalsInit]
    internal static Hemy.Lib.Core.Sys. Platform CurrentOsPlatform => Hemy.Lib.Core.Sys.Platform.Window;

    [SkipLocalsInit]
    internal static uint CurrentThreadId => GetCurrentThreadId();
    [SkipLocalsInit]
    internal static uint CurrentProcessId => GetCurrentProcessId();
    [SkipLocalsInit]
    internal static uint CurrentProcessor => GetCurrentProcessorNumber();
    [SkipLocalsInit]
    internal static void* Hinstance => GetModuleHandleA(null);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static ulong InstalledMemory()
    {
        GetPhysicallyInstalledSystemMemory(out long memKb);
        return (ulong)(memKb); // In GB  =>  / (1024 * 1024 * 1024)  pour MB  value / (1024 * 1024) 1073741824
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static Hemy.Lib.Core.Sys.Architecture GetArchitecture()
    => RuntimeInformation.ProcessArchitecture switch
    {
        System.Runtime.InteropServices.Architecture.X86 => Hemy.Lib.Core.Sys.Architecture.x86,
        System.Runtime.InteropServices.Architecture.X64 => Hemy.Lib.Core.Sys.Architecture.x64,
        System.Runtime.InteropServices.Architecture.Arm => Hemy.Lib.Core.Sys.Architecture.Arm,
        System.Runtime.InteropServices.Architecture.Arm64 => Hemy.Lib.Core.Sys.Architecture.Arm,
        _ => Hemy.Lib.Core.Sys.Architecture.Unsupported,
    };
    
     [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial uint GetCurrentProcessId();

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial uint GetCurrentThreadId();
  
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false, EntryPoint = "GetModuleHandleA")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial void* GetModuleHandleA( /*LPCSTR*/ byte* lpModuleName);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial uint GetCurrentProcessorNumber();

    // [SkipLocalsInit]
    // [SuppressGCTransition]
    // [SuppressUnmanagedCodeSecurity]
    // [LibraryImport(Kernel, SetLastError = false)]
    // [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    // [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    // private static partial uint GetActiveProcessorCount(uint count);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);
}

#endif
