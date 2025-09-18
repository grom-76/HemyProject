#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Common;

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using static Hemy.Lib.Core.Platform.Windows.LibrariesName;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static unsafe partial class Log
{
	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static void Display(string header, string message, string file, string method, int line)
#if !DEBUG
        => puts($"{header,-6}[TH:{GetCurrentThreadId()}_{GetFileName(file)}.{method.PadRight(5)}:{line}] {message}\n");
#else
		=> Debug.WriteLine($"{header,-6}[{GetFileName(file)}.{method.PadRight(5)}:{line}] {message}\n");
#endif

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    private static string GetFileName(string path)
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
    [LibraryImport(Ucrt, SetLastError = false, StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(System.Runtime.InteropServices.Marshalling.AnsiStringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int puts( /* const char *str*/ string str);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial uint GetCurrentThreadId();
  
}


#endif
