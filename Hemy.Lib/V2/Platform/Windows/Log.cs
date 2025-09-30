namespace Hemy.Lib.V2.Platform.Windows;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

using const_char = System.Byte;
using BOOL = System.Int32;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static unsafe partial class WindowsLog
{
	internal const string Ucrt = "ucrtbase";
	internal const string Kernel = "kernel32";

	internal const string INFO = "INFO";
	internal const string WARNING = "WARN";
	internal const string ERROR = "ERROR";

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static void Display(string header, string message)
		=> _ = _cputs($"{header,-6}[TH:{GetCurrentThreadId()}] {message}\n");

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static void Display(string header, byte* message)
		=>_ = _cputs(message);		

	// [SkipLocalsInit]
	// [SuppressGCTransition]
	// [SuppressUnmanagedCodeSecurity]
	// internal static string GetFileName(string path)
	// {
	// 	ReadOnlySpan<char> fileName = path.AsSpan();
	// 	int lastPeriod = fileName.LastIndexOf('.');
	// 	int lastslash = fileName.LastIndexOf('\\');
	// 	return lastPeriod < 0 ?
	// 		fileName.ToString() : // No extension was found
	// 		fileName.Slice(lastslash + 1, lastPeriod - lastslash - 1).ToString();
	// }

	// private const int EOF = -1;

	// [SkipLocalsInit]
	// [SuppressGCTransition]
	// [SuppressUnmanagedCodeSecurity]
	// [LibraryImport(Ucrt, SetLastError = false
	// , StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(System.Runtime.InteropServices.Marshalling.AnsiStringMarshaller))]
	// [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	// [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	// private static partial int puts( /* const char *str*/ string str);// return EOF if error 

	// [SkipLocalsInit]
	// [SuppressGCTransition]
	// [SuppressUnmanagedCodeSecurity]
	// [LibraryImport(Ucrt, SetLastError = false)]
	// [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	// [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	// private static partial int puts( const_char* str);

	  [SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false
	, StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(System.Runtime.InteropServices.Marshalling.AnsiStringMarshaller))]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial int _cputs( /* const char *str*/ string str);// return EOF if error 

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial int _cputs( const_char* str);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Kernel, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial uint GetCurrentThreadId();
  
}
