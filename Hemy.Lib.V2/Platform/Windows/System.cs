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
internal unsafe static partial class WindowsSystem
{
	internal const string Kernel = "kernel32";
	//BigEndian
	//Utf8
	//CPU
	//RAM
	//LibrariesLoaders 

	// internal static void Init(TimeData* timeData)
	// {
	//     int isHight = QueryPerformanceFrequency(out ulong count);
	//     timeData->IsHighPrecision = isHight != 0;
	//     timeData->Frequency  = timeData->IsHighPrecision ? count : 10_000;
	//     cycles_ms = timeData->Frequency/1000;
	//     timeData->Cycles_ms = cycles_ms;

	// }

	// [SkipLocalsInit]
	// [SuppressGCTransition]
	// [SuppressUnmanagedCodeSecurity]
	// internal static void Update(TimeData* timerData) // Tick 
	// {
	//     timerData->CurrentFrameTime = GetTick() / cycles_ms;
	//     timerData->DeltaTime = timerData->CurrentFrameTime - timerData->PreviousFrameTime;
	//     timerData->FrameCount = timerData->FrameCount + 1;
	//     timerData->PreviousFrameTime =  timerData->CurrentFrameTime;
	// }

	// internal static void Resume(TimeData* timerData) //unpause
	// {
	//     if (timerData->State == TimeData.STOPPED) return;

	//     timerData->PreviousFrameTime = GetTick() / cycles_ms ;
	//     timerData->BaseTime = timerData->PreviousFrameTime;
	//     timerData->StopTime = 0;
	//     timerData->State = TimeData.RUNNING;
	// }

	// internal static void Start(TimeData* timerData) // Reset .????
	// {
	//     timerData->CurrentFrameTime = GetTick()  / cycles_ms ;
	//     timerData->PausedTime += timerData->CurrentFrameTime - timerData->StopTime;
	//     timerData->PreviousFrameTime = timerData->CurrentFrameTime; //timerData->BaseTime = timerData->CurrentFrameTime;
	//     timerData->StopTime = 0;
	//     timerData->State = TimeData.RUNNING;
	// }

	// internal static void Pause(TimeData* timerData) // STOP ???
	// {
	//     if (timerData->State == TimeData.PAUSED) return;

	//     timerData->StopTime = GetTick() / cycles_ms ;
	//     timerData->State = TimeData.PAUSED;
	// }

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
	[LibraryImport(Kernel, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial int QueryPerformanceCounter(out ulong lpPerformanceCount);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Kernel, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial int QueryPerformanceFrequency(out ulong frequency);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static nint Load(string libraryName)
	{
		nint dll = LoadLibrary(libraryName);
		return dll;
	}

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static uint Unload(nint module)
	{
		return FreeLibrary(module);
	}

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static nint GetSymbol(nint library, string symbolName)
	{
		nint proc = GetProcAddress(library, symbolName);
		return proc;
	}

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Kernel, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial uint FreeLibrary(nint hModule);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Kernel, SetLastError = false, StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(System.Runtime.InteropServices.Marshalling.AnsiStringMarshaller))]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial nint GetProcAddress(nint hModule, string lpProcName);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Kernel, SetLastError = false, EntryPoint = "LoadLibraryA", StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(System.Runtime.InteropServices.Marshalling.AnsiStringMarshaller))]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial nint LoadLibrary(string lpFileName);
}
