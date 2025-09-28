namespace Hemy.Lib.V2.Platform.Windows;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

using const_char = System.Byte;
using BOOL = System.Int32;

// https://learn.microsoft.com/en-us/windows/win32/winprog/windows-data-types
using size_t = System.UIntPtr;
using uint32_t = System.UInt32;
using uint64_t = System.UInt64;
using uint8_t = System.Byte;
using int32_t = System.Int32;
using int64_t = System.Int64;
using uint16_t = System.UInt16;

using VkBool32 = System.UInt32;
using VkDeviceAddress = System.UInt64;
using VkDeviceSize = System.UInt64;
using Flag = System.Int32;

using HRESULT = System.Int32;

using static Hemy.Lib.V2.Platform.Windows.WindowsGraphicCommon;
using static Hemy.Lib.V2.Platform.Windows.WindowsWindowCommon;
using Hemy.Lib.V2.Core;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static unsafe partial class WindowsLog
{
	internal const string Ucrt = "ucrtbase";
	internal const string Kernel = "kernel32";

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static void Display(string header, string message, string file, string method, int line)
        => puts($"{header,-6}[TH:{GetCurrentThreadId()}_{GetFileName(file)}.{method.PadRight(5)}:{line}] {message}\n");

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static void Display(string header, byte* message)
        => puts(message);		

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static string GetFileName(string path)
    {
        ReadOnlySpan<char> fileName = path.AsSpan();
        int lastPeriod = fileName.LastIndexOf('.');
        int lastslash = fileName.LastIndexOf('\\');
        return lastPeriod < 0 ?
            fileName.ToString() : // No extension was found
            fileName.Slice(lastslash + 1, lastPeriod - lastslash - 1).ToString();
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Ucrt, SetLastError = false
	, StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(System.Runtime.InteropServices.Marshalling.AnsiStringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int puts( /* const char *str*/ string str);

	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Ucrt, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int puts( const_char* str);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial uint GetCurrentThreadId();
  
}

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class WindowsMonitors
{


}
