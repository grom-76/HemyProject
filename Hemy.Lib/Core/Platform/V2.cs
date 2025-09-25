namespace Hemy.Lib.Core.Platform.V2;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;


using const_char = System.Byte;
using BOOL = System.Int32;
using System.Threading;
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
using static Hemy.Lib.Core.Platform.V2.WindowsContextGraphicDevice;

internal unsafe struct WindowsContextDataPerFrame()
{
	internal uint State = 0;
	internal uint Error = 0;

}


internal unsafe struct WindowsContextDataInfos() // = Settings  
{
	internal fixed byte GameName[256];
	internal fixed byte EngineName[16];
	// internal void* Handle = null;
	// internal void* HInstance = null;
	internal VkInstance* VkInstance = null;
	internal VkDebugUtilsMessengerEXT* VkDebugUtilsMessenger = null;
	internal int Width = 1280;
	internal int Height = 720;
#if DEBUG
	internal bool EnableDebugMode = true;
#else
	internal bool EnableDebugMode = false;
#endif
	internal WindowsContextStrArray* ValidationLayers = null;
	internal WindowsContextStrArray* InstanceExtensions = null;
}

internal unsafe struct WindowsContextDataGraphicPipeline()
{
	// Materials  : shader , texture
	// Vertices
	// FixedFunction Dynamic states
	// RenderPAss ?
	//Camera? 
   
}

internal unsafe struct WindowsContextDataAudioPipeline()
{
   // Materials  : shader , texture
   // Vertices
	// FixedFunction Dynamic states
   // RenderPAss ?
}


[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal struct Hwnd;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal struct VkInstance;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal struct VkDebugUtilsMessengerEXT;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static unsafe class WindowsContextUtils
{

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static void FillBytesWithString(byte* bytes, string text)
	{
		int i = 0;
		while (i < text.Length)
		{
			*(bytes + i) = unchecked((byte)(text[i++] & 0x7f));
		}
		*(bytes + i) = 0;// dans le cas ou il n'y ait pas de zero en fin de chaine calloc
	}

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static uint Length(byte* source) // UTF8 ONLY
	{
		byte* ptr = source;
		while (*ptr != '\0') { ptr++; }
		return (uint)(ptr - source);
	}

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static string BytesToString(byte* bytes, uint length)
	{
		string response = string.Empty;
		for (int pos = 0; pos < length; pos++)
		{
			response += (char)bytes[pos];
		}
		return response;
	}
	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
	internal static bool IsPow2(nuint value) => (value & (value - 1)) == 0 && value != 0;

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
	internal static nuint GetByteCount(nuint elementCount, nuint elementSize)
	{
		nuint multiplyNoOverflow = (nuint)1 << (4 * sizeof(nuint));

		return ((elementSize >= multiplyNoOverflow) || (elementCount >= multiplyNoOverflow)) && (elementSize > 0) && ((nuint.MaxValue / elementSize) < elementCount) ? nuint.MaxValue : (elementCount * elementSize);
	}
}


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static partial class WindowsContextEvents
{

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static void Update(WindowsContextDataPerFrame* contextData)
	{
		MSG msg;
		if (PeekMessageA(&msg, null, 0, 0, PM_REMOVE) > 0)
		{
			_ = TranslateMessage(&msg);
			_ = DispatchMessageA(&msg);

			contextData->State = msg.message != WM_QUIT ? 0U : 1U;
		}
	}
	private const uint PM_REMOVE = 0x0001;
	internal const uint WM_QUIT = 0x0012;
	private const string User = "user32";

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(User, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof( CallConvSuppressGCTransition)  ])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial int TranslateMessage(MSG* lpMsg);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(User, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof( CallConvSuppressGCTransition)  ])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial long DispatchMessageA(MSG* lpMsg);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(User, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof( CallConvSuppressGCTransition)  ])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial int PeekMessageA(MSG* lpMsg, Hwnd* hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct MSG
	{
		internal void* hwnd;
		internal uint message;
		internal uint* wParam;
		internal long* lParam;
		internal ulong time;
		internal POINT pt;
		internal ulong lPrivate;
	}

	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	internal struct POINT(int x, int y)
	{
		internal int X = x;
		internal int Y = y;
	}
}

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static unsafe partial class Log
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
    [LibraryImport(Ucrt, SetLastError = false
	, StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(System.Runtime.InteropServices.Marshalling.AnsiStringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int puts( /* const char *str*/ string str);

	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Ucrt, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
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
internal unsafe static partial class WindowsContextMemory
{
	internal const int DataAlignementSize = 8;
	internal const string Ucrt = "ucrtbase";

	[SkipLocalsInit]
	internal static long ReminingMemory => _allocations;
	static volatile int _allocations;

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static size_t Size<T>() where T : unmanaged
		=> (size_t)Unsafe.SizeOf<T>();

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static T* ToPtr<T>(ref T instance) where T : unmanaged
		=> (T*)Unsafe.AsPointer(ref instance);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static void* Copy(void* ptrSource, void* ptrDestination, nuint size)
		=> memmove(ptrDestination, ptrSource, size);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static byte* New(string text) // FOr STRINGS
	{
		byte* bytes = New<byte>((uint)text.Length + 1);
		WindowsContextUtils.FillBytesWithString(bytes, text);
		return bytes;
	}

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity] // FOR ARRAY
	internal static T* New<T>(nuint count) where T : unmanaged
	{
		size_t size = WindowsContextUtils.GetByteCount(Size<T>(), count);
		T* result = (T*)_aligned_malloc(size , DataAlignementSize);
		
		Interlocked.Increment(ref _allocations);

		return result;
	}
	
	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity] // FOR STRUCT
	internal static T* New<T>() where T : unmanaged
	=> (T*)New<T>(1);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static void* Fill(void* destination, int valueToFill, nuint bytesCount)
		=> memset(destination, valueToFill, bytesCount);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static void Dispose(void* pointer) 
	{
		if (pointer == null) return;

		_aligned_free(pointer);
		Interlocked.Decrement(ref _allocations);
	}

	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial void* _aligned_malloc(nuint size, nuint alignment);

	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial void* _aligned_realloc(void* memblock, nuint size, nuint alignment);

	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial void _aligned_free(void* ptr);

	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial void* memmove(void* dest, void* src, nuint size);

	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial void* memset(void* dest, int c, nuint count);
}

internal unsafe static partial class WindowsContextSystem
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
		return FreeLibrary(module) ;
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
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial uint FreeLibrary(nint hModule);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false, StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(System.Runtime.InteropServices.Marshalling.AnsiStringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial nint GetProcAddress(nint hModule, string lpProcName);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false, EntryPoint = "LoadLibraryA", StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(System.Runtime.InteropServices.Marshalling.AnsiStringMarshaller))]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial nint LoadLibrary(string lpFileName);
}

internal unsafe static partial class WindowsContextIO
{
	internal const string Ucrt = "ucrtbase";

	internal static bool IsFileExist(string file)
	{
		//https://learn.microsoft.com/fr-fr/cpp/c-runtime-library/reference/access-s-waccess-s?view=msvc-170 
		// TODO convert string to bytes file exist
		int err = _access_s(null, 0);

		return err == 0;
	}

	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	[LibraryImport(Ucrt, SetLastError = false)]
    internal static partial int _access_s(byte* path, int mode);
}

internal unsafe static class WindowsContextMaths
{

}

internal unsafe static class WindowsContextGraphicMonitors
{


}

internal unsafe static class WindowsContextGraphicWindow
{


}

internal unsafe static class WindowsContextGraphicDevice
{
	internal const string Vulkan =
#if WINDOWS
    "vulkan-1.dll";
#endif

	internal const uint VK_TRUE = 1U; 
	internal const uint VK_FALSE = 0U; 

	internal static uint ToUint(uint major, uint minor, uint patch) => (major << 22) | (minor << 12) | patch;
// 
// 		"INSTANCE",
// 		"PHYSICAL_DEVICE",
// 		"DEVICE",
// 		"QUEUE",
// 		"SEMAPHORE",
// 		"COMMAND_BUFFER",
// 		"FENCE",
// 		"DEVICE_MEMORY",
// 		"BUFFER",
// 		"IMAGE",
// 		"EVENT",
// 		"QUERY_POOL",
// 		"BUFFER_VIEW",
// 		"IMAGE_VIEW",
// 		"SHADER_MODULE",
// 		"PIPELINE_CACHE",
// 		"PIPELINE_LAYOUT",
// 		"RENDER_PASS",
// 		"PIPELINE",
// 		"DESCRIPTOR_SET_LAYOUT",
// 		"SAMPLER",
// 		"DESCRIPTOR_POOL",
// 		"DESCRIPTOR_SET",
// 		"FRAMEBUFFER",
// 		"COMMAND_POOL",
// 		"DESCRIPTOR_UPDATE_TEMPLATE_KHR",
// 		"SURFACE_KHR",
// 		"SWAPCHAIN_KHR",
// 		"DEBUG_UTILS_MESSENGER_EXT",
// 		"DEBUG_REPORT_CALLBACK_EXT",
// 		"ACCELERATION_STRUCTURE",
// 		"VMA_BUFFER_OR_IMAGE" };

	internal enum VkResult    {
		VK_SUCCESS = 0, 
		VK_NOT_READY = 1, 
		VK_TIMEOUT = 2, 
		VK_EVENT_SET = 3, 
		VK_EVENT_RESET = 4, 
		VK_INCOMPLETE = 5, 
		VK_ERROR_OUT_OF_HOST_MEMORY = -1, 
		VK_ERROR_OUT_OF_DEVICE_MEMORY = -2, 
		VK_ERROR_INITIALIZATION_FAILED = -3, 
		VK_ERROR_DEVICE_LOST = -4, 
		VK_ERROR_MEMORY_MAP_FAILED = -5, 
		VK_ERROR_LAYER_NOT_PRESENT = -6, 
		VK_ERROR_EXTENSION_NOT_PRESENT = -7, 
		VK_ERROR_FEATURE_NOT_PRESENT = -8, 
		VK_ERROR_INCOMPATIBLE_DRIVER = -9, 
		VK_ERROR_TOO_MANY_OBJECTS = -10, 
		VK_ERROR_FORMAT_NOT_SUPPORTED = -11, 
		VK_ERROR_FRAGMENTED_POOL = -12, 
		VK_ERROR_UNKNOWN = -13, 
		VK_ERROR_OUT_OF_POOL_MEMORY = -1000069000, 
		VK_ERROR_INVALID_EXTERNAL_HANDLE = -1000072003, 
		VK_ERROR_FRAGMENTATION = -1000161000, 
		VK_ERROR_INVALID_OPAQUE_CAPTURE_ADDRESS = -1000257000, 
		VK_PIPELINE_COMPILE_REQUIRED = 1000297000, 
		VK_ERROR_NOT_PERMITTED = -1000174001, 
		VK_ERROR_SURFACE_LOST_KHR = -1000000000, 
		VK_ERROR_NATIVE_WINDOW_IN_USE_KHR = -1000000001, 
		VK_SUBOPTIMAL_KHR = 1000001003, 
		VK_ERROR_OUT_OF_DATE_KHR = -1000001004, 
		VK_ERROR_INCOMPATIBLE_DISPLAY_KHR = -1000003001, 
		VK_ERROR_VALIDATION_FAILED_EXT = -1000011001, 
		VK_ERROR_INVALID_SHADER_NV = -1000012000, 
		VK_ERROR_IMAGE_USAGE_NOT_SUPPORTED_KHR = -1000023000, 
		VK_ERROR_VIDEO_PICTURE_LAYOUT_NOT_SUPPORTED_KHR = -1000023001, 
		VK_ERROR_VIDEO_PROFILE_OPERATION_NOT_SUPPORTED_KHR = -1000023002, 
		VK_ERROR_VIDEO_PROFILE_FORMAT_NOT_SUPPORTED_KHR = -1000023003, 
		VK_ERROR_VIDEO_PROFILE_CODEC_NOT_SUPPORTED_KHR = -1000023004, 
		VK_ERROR_VIDEO_STD_VERSION_NOT_SUPPORTED_KHR = -1000023005, 
		VK_ERROR_INVALID_DRM_FORMAT_MODIFIER_PLANE_LAYOUT_EXT = -1000158000, 
		VK_ERROR_FULL_SCREEN_EXCLUSIVE_MODE_LOST_EXT = -1000255000, 
		VK_THREAD_IDLE_KHR = 1000268000, 
		VK_THREAD_DONE_KHR = 1000268001, 
		VK_OPERATION_DEFERRED_KHR = 1000268002, 
		VK_OPERATION_NOT_DEFERRED_KHR = 1000268003, 
		VK_ERROR_INVALID_VIDEO_STD_PARAMETERS_KHR = -1000299000, 
		VK_ERROR_COMPRESSION_EXHAUSTED_EXT = -1000338000, 
		VK_INCOMPATIBLE_SHADER_BINARY_EXT = 1000482000, 
		VK_PIPELINE_BINARY_MISSING_KHR = 1000483000, 
		VK_ERROR_NOT_ENOUGH_SPACE_KHR = -1000483000, 
		VK_ERROR_OUT_OF_POOL_MEMORY_KHR = VK_ERROR_OUT_OF_POOL_MEMORY, 
		VK_ERROR_INVALID_EXTERNAL_HANDLE_KHR = VK_ERROR_INVALID_EXTERNAL_HANDLE, 
		VK_ERROR_FRAGMENTATION_EXT = VK_ERROR_FRAGMENTATION, 
		VK_ERROR_NOT_PERMITTED_EXT = VK_ERROR_NOT_PERMITTED, 
		VK_ERROR_NOT_PERMITTED_KHR = VK_ERROR_NOT_PERMITTED, 
		VK_ERROR_INVALID_DEVICE_ADDRESS_EXT = VK_ERROR_INVALID_OPAQUE_CAPTURE_ADDRESS, 
		VK_ERROR_INVALID_OPAQUE_CAPTURE_ADDRESS_KHR = VK_ERROR_INVALID_OPAQUE_CAPTURE_ADDRESS, 
		VK_PIPELINE_COMPILE_REQUIRED_EXT = VK_PIPELINE_COMPILE_REQUIRED, 
		VK_ERROR_PIPELINE_COMPILE_REQUIRED_EXT = VK_PIPELINE_COMPILE_REQUIRED, 
	// VK_ERROR_INCOMPATIBLE_SHADER_BINARY_EXT is a deprecated alias 
		VK_ERROR_INCOMPATIBLE_SHADER_BINARY_EXT = VK_INCOMPATIBLE_SHADER_BINARY_EXT, 
		VK_RESULT_MAX_ENUM = 0x7FFFFFFF 
	};

	internal enum VkDebugUtilsMessageSeverityFlagBitsEXT    {
    VK_DEBUG_UTILS_MESSAGE_SEVERITY_VERBOSE_BIT_EXT = 0x00000001, 
    VK_DEBUG_UTILS_MESSAGE_SEVERITY_INFO_BIT_EXT = 0x00000010, 
    VK_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT = 0x00000100, 
    VK_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT = 0x00001000, 
    VK_DEBUG_UTILS_MESSAGE_SEVERITY_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
internal enum VkDebugUtilsMessageTypeFlagBitsEXT   {
    VK_DEBUG_UTILS_MESSAGE_TYPE_GENERAL_BIT_EXT = 0x00000001, 
    VK_DEBUG_UTILS_MESSAGE_TYPE_VALIDATION_BIT_EXT = 0x00000002, 
    VK_DEBUG_UTILS_MESSAGE_TYPE_PERFORMANCE_BIT_EXT = 0x00000004, 
    VK_DEBUG_UTILS_MESSAGE_TYPE_DEVICE_ADDRESS_BINDING_BIT_EXT = 0x00000008, 
    VK_DEBUG_UTILS_MESSAGE_TYPE_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};

internal enum VkStructureType 
{
	VK_STRUCTURE_TYPE_DEBUG_UTILS_MESSENGER_CREATE_INFO_EXT = 1000128004, 
	VK_STRUCTURE_TYPE_APPLICATION_INFO = 0, 
    VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO = 1, 

}

public enum VkInstanceCreateFlagBits    {
    VK_INSTANCE_CREATE_ENUMERATE_PORTABILITY_BIT_KHR = 0x00000001, 
    VK_INSTANCE_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF  // 2147483647= int.MAx
};

public enum VkObjectType    {
    VK_OBJECT_TYPE_UNKNOWN = 0, 
    VK_OBJECT_TYPE_INSTANCE = 1, 
    VK_OBJECT_TYPE_PHYSICAL_DEVICE = 2, 
    VK_OBJECT_TYPE_DEVICE = 3, 
    VK_OBJECT_TYPE_QUEUE = 4, 
    VK_OBJECT_TYPE_SEMAPHORE = 5, 
    VK_OBJECT_TYPE_COMMAND_BUFFER = 6, 
    VK_OBJECT_TYPE_FENCE = 7, 
    VK_OBJECT_TYPE_DEVICE_MEMORY = 8, 
    VK_OBJECT_TYPE_BUFFER = 9, 
    VK_OBJECT_TYPE_IMAGE = 10, 
    VK_OBJECT_TYPE_EVENT = 11, 
    VK_OBJECT_TYPE_QUERY_POOL = 12, 
    VK_OBJECT_TYPE_BUFFER_VIEW = 13, 
    VK_OBJECT_TYPE_IMAGE_VIEW = 14, 
    VK_OBJECT_TYPE_SHADER_MODULE = 15, 
    VK_OBJECT_TYPE_PIPELINE_CACHE = 16, 
    VK_OBJECT_TYPE_PIPELINE_LAYOUT = 17, 
    VK_OBJECT_TYPE_RENDER_PASS = 18, 
    VK_OBJECT_TYPE_PIPELINE = 19, 
    VK_OBJECT_TYPE_DESCRIPTOR_SET_LAYOUT = 20, 
    VK_OBJECT_TYPE_SAMPLER = 21, 
    VK_OBJECT_TYPE_DESCRIPTOR_POOL = 22, 
    VK_OBJECT_TYPE_DESCRIPTOR_SET = 23, 
    VK_OBJECT_TYPE_FRAMEBUFFER = 24, 
    VK_OBJECT_TYPE_COMMAND_POOL = 25, 
    VK_OBJECT_TYPE_SAMPLER_YCBCR_CONVERSION = 1000156000, 
    VK_OBJECT_TYPE_DESCRIPTOR_UPDATE_TEMPLATE = 1000085000, 
    VK_OBJECT_TYPE_PRIVATE_DATA_SLOT = 1000295000, 
    VK_OBJECT_TYPE_SURFACE_KHR = 1000000000, 
    VK_OBJECT_TYPE_SWAPCHAIN_KHR = 1000001000, 
    VK_OBJECT_TYPE_DISPLAY_KHR = 1000002000, 
    VK_OBJECT_TYPE_DISPLAY_MODE_KHR = 1000002001, 
    VK_OBJECT_TYPE_DEBUG_REPORT_CALLBACK_EXT = 1000011000, 
    VK_OBJECT_TYPE_VIDEO_SESSION_KHR = 1000023000, 
    VK_OBJECT_TYPE_VIDEO_SESSION_PARAMETERS_KHR = 1000023001, 
    VK_OBJECT_TYPE_CU_MODULE_NVX = 1000029000, 
    VK_OBJECT_TYPE_CU_FUNCTION_NVX = 1000029001, 
    VK_OBJECT_TYPE_DEBUG_UTILS_MESSENGER_EXT = 1000128000, 
    VK_OBJECT_TYPE_ACCELERATION_STRUCTURE_KHR = 1000150000, 
    VK_OBJECT_TYPE_VALIDATION_CACHE_EXT = 1000160000, 
    VK_OBJECT_TYPE_ACCELERATION_STRUCTURE_NV = 1000165000, 
    VK_OBJECT_TYPE_PERFORMANCE_CONFIGURATION_INTEL = 1000210000, 
    VK_OBJECT_TYPE_DEFERRED_OPERATION_KHR = 1000268000, 
    VK_OBJECT_TYPE_INDIRECT_COMMANDS_LAYOUT_NV = 1000277000, 
    VK_OBJECT_TYPE_CUDA_MODULE_NV = 1000307000, 
    VK_OBJECT_TYPE_CUDA_FUNCTION_NV = 1000307001, 
    VK_OBJECT_TYPE_BUFFER_COLLECTION_FUCHSIA = 1000366000, 
    VK_OBJECT_TYPE_MICROMAP_EXT = 1000396000, 
    VK_OBJECT_TYPE_OPTICAL_FLOW_SESSION_NV = 1000464000, 
    VK_OBJECT_TYPE_SHADER_EXT = 1000482000, 
    VK_OBJECT_TYPE_PIPELINE_BINARY_KHR = 1000483000, 
    VK_OBJECT_TYPE_EXTERNAL_COMPUTE_QUEUE_NV = 1000556000, 
    VK_OBJECT_TYPE_INDIRECT_COMMANDS_LAYOUT_EXT = 1000572000, 
    VK_OBJECT_TYPE_INDIRECT_EXECUTION_SET_EXT = 1000572001, 
    VK_OBJECT_TYPE_DESCRIPTOR_UPDATE_TEMPLATE_KHR = VK_OBJECT_TYPE_DESCRIPTOR_UPDATE_TEMPLATE, 
    VK_OBJECT_TYPE_SAMPLER_YCBCR_CONVERSION_KHR = VK_OBJECT_TYPE_SAMPLER_YCBCR_CONVERSION, 
    VK_OBJECT_TYPE_PRIVATE_DATA_SLOT_EXT = VK_OBJECT_TYPE_PRIVATE_DATA_SLOT, 
    VK_OBJECT_TYPE_MAX_ENUM = 0x7FFFFFFF 
};

public enum VkSystemAllocationScope    {
    VK_SYSTEM_ALLOCATION_SCOPE_COMMAND = 0, 
    VK_SYSTEM_ALLOCATION_SCOPE_OBJECT = 1, 
    VK_SYSTEM_ALLOCATION_SCOPE_CACHE = 2, 
    VK_SYSTEM_ALLOCATION_SCOPE_DEVICE = 3, 
    VK_SYSTEM_ALLOCATION_SCOPE_INSTANCE = 4, 
    VK_SYSTEM_ALLOCATION_SCOPE_MAX_ENUM = 0x7FFFFFFF // 2147483647= int.MAx
};

public enum VkInternalAllocationType  {
    VK_INTERNAL_ALLOCATION_TYPE_EXECUTABLE = 0, 
    VK_INTERNAL_ALLOCATION_TYPE_MAX_ENUM = 0x7FFFFFFF 
};

}


[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct WindowsContextStrArray(uint count, uint itemMaxSize)
{
	byte* _array = WindowsContextMemory.New<byte>(count * itemMaxSize);
    byte* _pointer = WindowsContextMemory.New<byte>( count * (uint)Unsafe.SizeOf<IntPtr>() );

	internal void Init(uint ncount, uint nitemMaxSize )
	{
		_array = WindowsContextMemory.New<byte>(ncount * nitemMaxSize);
		_pointer = WindowsContextMemory.New<byte>( ncount * (uint)Unsafe.SizeOf<IntPtr>() );
	}

    /// <summary> le nombre de ligne du tableau </summary>
    public readonly uint Count => count;

    /// <summary> Acces direct en lecture seule au debut du tableau ligne zéro caractère zéro </summary>
    public readonly byte* Pointer => _pointer;

    /// <summary> Ajoute un nouvel élément au tableau  </summary>
    /// <param name="value"> pointeur au format byte  de la chaine d'entrée</param>
    /// <param name="index">specifie la ligne d'insertion doit être superieur à zéro ou inferieur a count </param>
    /// <returns></returns> 
    [SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
    public readonly bool Add(byte* value, uint index)
    {
        if (value is null) return false;

        if (index <= 0 && index >= count) return false;

        uint size = WindowsContextUtils.Length(value) + 1;

        WindowsContextMemory.Copy(value, _array + (itemMaxSize * index), size);

        ((byte**)_pointer)[index] = _array + (itemMaxSize * index);

        return true;
    }

    /// <summary> Retourne au format string c# la chaine à la ligne spécifié. </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public readonly string GetString(uint index)
    {
        return WindowsContextUtils.BytesToString( _array + (itemMaxSize * index),itemMaxSize );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="match"></param>
    /// <returns></returns>
    [SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
    public readonly bool IsExist(string match)
    {
        for (uint i = 0; i < Count; i++)
        {
            string extension = GetString(i);

            if (extension.Contains(match))
                return true;
        }
        return false;
    }

    /// <summary> Retourne le pointeur a ladresse du début de la ligne spécifier </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public readonly byte* this[uint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => _array + (itemMaxSize * index);
        set => Add(value, index);
    }

    /// <summary> Quitter proprement  </summary>
    [SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
    public readonly void Dispose()
    {
        WindowsContextMemory.Dispose(_array);
        WindowsContextMemory.Dispose(_pointer);
    }

    public static implicit operator byte**(WindowsContextStrArray array) => (byte**)array._pointer;
}


internal unsafe static partial class WindowsContextGraphicDeviceInstance
{

	internal static int CreateInstance(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		// 	//Enumarate instance Layer 
		uint layerCount = 0;
		VkResult result = vkEnumerateInstanceLayerProperties(&layerCount, null);
		if (result != VkResult.VK_SUCCESS || layerCount == 0) { return 1; }

		VkLayerProperties* layerProperties = stackalloc VkLayerProperties[(int)layerCount];

		result = vkEnumerateInstanceLayerProperties(&layerCount, layerProperties);
		if (result != VkResult.VK_SUCCESS || layerCount == 0) { return 1; }

		// infos->ValidationLayers = new(layerCount, VK_MAX_DESCRIPTION_SIZE);
		
		for (uint i = 0; i < layerCount; i++) {
			infos->ValidationLayers->Add(layerProperties[i].layerName, i);
		}

		//Enumarate Instrance Extension ( loader instance )
		uint instanceExtCount = 0;

		result = vkEnumerateInstanceExtensionProperties(null, &instanceExtCount, null);
		if (result != VkResult.VK_SUCCESS || instanceExtCount == 0) { return 1; }

		VkExtensionProperties* props = stackalloc VkExtensionProperties[(int)instanceExtCount];

		result = vkEnumerateInstanceExtensionProperties(null, &instanceExtCount, props);
		if (result != VkResult.VK_SUCCESS) { return 1; }

		// infos->InstanceExtensions = new(instanceExtCount, VK_MAX_DESCRIPTION_SIZE);

		for (uint i = 0; i < instanceExtCount; i++)
		{
			infos->InstanceExtensions->Add(props[i].extensionName, i);
		}

		// 	// Create debug 
		VkDebugUtilsMessengerCreateInfoEXT* debugCreateInfo = stackalloc VkDebugUtilsMessengerCreateInfoEXT[1];
		debugCreateInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_DEBUG_UTILS_MESSENGER_CREATE_INFO_EXT;
		debugCreateInfo[0].pNext = null;
		debugCreateInfo[0].messageSeverity = (uint)(VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_VERBOSE_BIT_EXT
										| VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT
										| VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT
										| VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_INFO_BIT_EXT);
		debugCreateInfo[0].messageType = (uint)(VkDebugUtilsMessageTypeFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_TYPE_GENERAL_BIT_EXT
										| VkDebugUtilsMessageTypeFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_TYPE_VALIDATION_BIT_EXT
										| VkDebugUtilsMessageTypeFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_TYPE_PERFORMANCE_BIT_EXT);

		debugCreateInfo[0].pfnUserCallback = &DebugMessengerCallback;
		debugCreateInfo[0].pUserData = null;
		debugCreateInfo[0].flags = 0;

		// Create Instance
		VkApplicationInfo* appInfo = stackalloc VkApplicationInfo[1];
		appInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_APPLICATION_INFO;
		appInfo[0].apiVersion = ToUint(1, 4, 0);
		appInfo[0].applicationVersion = ToUint(1, 0, 0);
		appInfo[0].engineVersion = ToUint(1, 0, 0);
		appInfo[0].pNext = null;
		appInfo[0].pApplicationName = infos->GameName;
		appInfo[0].pEngineName = infos->EngineName;

		VkInstanceCreateInfo* instanceCreateInfo = stackalloc VkInstanceCreateInfo[1];
		instanceCreateInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO;
		instanceCreateInfo[0].flags = VkInstanceCreateFlagBits.VK_INSTANCE_CREATE_ENUMERATE_PORTABILITY_BIT_KHR;
		instanceCreateInfo[0].pApplicationInfo = &appInfo[0];
		instanceCreateInfo[0].pNext = !infos->EnableDebugMode ? null : &debugCreateInfo[0];
		instanceCreateInfo[0].ppEnabledExtensionNames = (byte**)infos->InstanceExtensions->Pointer;
		instanceCreateInfo[0].enabledExtensionCount = infos->InstanceExtensions->Count;
		instanceCreateInfo[0].enabledLayerCount = infos->EnableDebugMode ? infos->ValidationLayers->Count : 0U;
		instanceCreateInfo[0].ppEnabledLayerNames = infos->EnableDebugMode ? (byte**)infos->ValidationLayers->Pointer : null;

		result = vkCreateInstance(&instanceCreateInfo[0], null, infos->VkInstance);

		return result != VkResult.VK_SUCCESS ? 0 : 1;
	}

	internal static int DisposeInstance(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		if (infos->VkInstance == null) return 1;

		vkDestroyInstance(*infos->VkInstance, pAllocator: null);

		return 0;
	}

	internal static int CreateDebug(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos ,VkDebugUtilsMessengerCreateInfoEXT* debugCreateInfo)
	{
		if (infos->EnableDebugMode)
        {
            VkResult result = vkCreateDebugUtilsMessengerEXT(*infos->VkInstance, &debugCreateInfo[0], null, infos->VkDebugUtilsMessenger);
			if (result != VkResult.VK_SUCCESS) return 1;
        }

		return 0;
	}
	
	internal static int DisposeDebug(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		if (infos->VkInstance == null && infos->VkDebugUtilsMessenger == null) return 1;       
        
		vkDestroyDebugUtilsMessengerEXT(infos->VkInstance, infos->VkDebugUtilsMessenger , null);
        

		return 0;
	}
	 
	internal static delegate* unmanaged<VkInstance, VkDebugUtilsMessengerCreateInfoEXT*, VkAllocationCallbacks*, VkDebugUtilsMessengerEXT*, VkResult> vkCreateDebugUtilsMessengerEXT = null;

	internal static delegate* unmanaged<VkInstance, VkDebugUtilsMessengerEXT, VkAllocationCallbacks*, void> vkDestroyDebugUtilsMessengerEXT = null;


	[UnmanagedCallersOnly]
    static uint DebugMessengerCallback(VkDebugUtilsMessageSeverityFlagBitsEXT messageSeverity,
        VkDebugUtilsMessageTypeFlagBitsEXT messageTypes,
        VkDebugUtilsMessengerCallbackDataEXT* pCallbackData, void* pUserData)
    {
        string Header = messageSeverity == VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT ?
            "ERROR" : messageSeverity == VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT ?
            	"WARNING" :  "INFO";

		Log.Display( Header, pCallbackData->pMessage );
        return VK_FALSE;
    }

	[LibraryImport(WindowsContextGraphicDevice.Vulkan, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition) ])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkEnumerateInstanceLayerProperties(uint32_t* pPropertyCount, VkLayerProperties* pProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition) ])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkEnumerateInstanceExtensionProperties(const_char* pLayerName, uint32_t* pPropertyCount, VkExtensionProperties* pProperties);

	[LibraryImport(Vulkan, SetLastError = true)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition) ])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateInstance(VkInstanceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkInstance* pInstance);

	[LibraryImport(Vulkan, SetLastError = true)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyInstance(VkInstance instance, VkAllocationCallbacks* pAllocator);

	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	internal struct VkLayerProperties
	{
		internal fixed byte layerName[(int)VK_MAX_EXTENSION_NAME_SIZE];
		internal uint32_t specVersion;
		internal uint32_t implementationVersion;
		internal fixed byte description[(int)VK_MAX_DESCRIPTION_SIZE];
	}
	
	[ SkipLocalsInit ]
	[StructLayout(LayoutKind.Sequential)]  
	internal struct VkExtensionProperties {
		internal fixed byte        extensionName[(int)VK_MAX_EXTENSION_NAME_SIZE]; 
		internal     uint32_t    specVersion; 
	}

	[ SkipLocalsInit ]
	[StructLayout(LayoutKind.Sequential)]  
	internal struct VkDebugUtilsMessengerCreateInfoEXT 
	{
		internal  VkStructureType  sType;
		internal  void*  pNext;
		internal  uint  flags;
		internal  uint  messageSeverity;
		internal  uint  messageType;
		internal  delegate* unmanaged< VkDebugUtilsMessageSeverityFlagBitsEXT,VkDebugUtilsMessageTypeFlagBitsEXT,VkDebugUtilsMessengerCallbackDataEXT*,void*,uint >  pfnUserCallback;
		internal  void*  pUserData;
	}

	[ SkipLocalsInit ]
	[StructLayout(LayoutKind.Sequential)]  
	internal unsafe  struct VkDebugUtilsMessengerCallbackDataEXT
	{
		internal VkStructureType  sType;
		internal const_char*  pMessageIdName;
		internal int/* VkDebugUtilsMessengerCallbackDataFlagsEXT */    flags;// alwways 0 
		internal int32_t  messageIdNumber;
		internal void*   pNext;
		internal const_char* pMessage; 
		internal uint32_t queueLabelCount; 
		internal VkDebugUtilsLabelEXT* pQueueLabels; 
		internal uint32_t cmdBufLabelCount; 
		internal VkDebugUtilsLabelEXT* pCmdBufLabels; 
		internal uint32_t @objectCount; 
		internal VkDebugUtilsObjectNameInfoEXT* pObjects; 
	}

	[ SkipLocalsInit ]
	[StructLayout(LayoutKind.Sequential)]  
	public unsafe  struct VkDebugUtilsLabelEXT {
		public     VkStructureType    sType; 
		public      void*        pNext; 
		public      const_char*        pLabelName; 
		public fixed     float              color[4]; 
	}

	[ SkipLocalsInit ]
	[StructLayout(LayoutKind.Sequential)]  
	public unsafe  struct VkDebugUtilsObjectNameInfoEXT {
		public     VkStructureType    sType; 
		public      void*        pNext; 
		public     VkObjectType       @objectType; 
		public     uint64_t           @objectHandle; 
		public      const_char*        pObjectName; 
	}
	
	[ SkipLocalsInit ]
	[StructLayout(LayoutKind.Sequential)]  
	internal unsafe  struct VkApplicationInfo {
		internal     VkStructureType    sType; 
		internal      void*        pNext; 
		internal      const_char*        pApplicationName; 
		internal     uint32_t           applicationVersion; 
		internal      const_char*        pEngineName; 
		internal     uint32_t           engineVersion; 
		internal     uint32_t           apiVersion; 
	}
	
	[ SkipLocalsInit ]
	[StructLayout(LayoutKind.Sequential)]  
	internal unsafe  struct VkInstanceCreateInfo {
		internal     VkStructureType             sType; 
		internal     void*                 pNext; 
		internal     VkInstanceCreateFlagBits       flags; 
		internal     VkApplicationInfo*    pApplicationInfo; 
		internal     uint32_t                    enabledLayerCount; 
		internal     const_char**          ppEnabledLayerNames; 
		internal     uint32_t                    enabledExtensionCount; 
		internal     const_char**          ppEnabledExtensionNames; 
	}

	[ SkipLocalsInit ]
	[StructLayout(LayoutKind.Sequential)]  
	public unsafe  struct VkAllocationCallbacks {
		public  void*  pUserData;
		public  delegate* unmanaged[Cdecl,SuppressGCTransition]< void*,nuint,nuint,VkSystemAllocationScope,void* >  pfnAllocation;
		public  delegate* unmanaged[Cdecl,SuppressGCTransition]< void*,void*,nuint,nuint,VkSystemAllocationScope,void* >  pfnReallocation;
		public  delegate* unmanaged[Cdecl,SuppressGCTransition]< void*,void*,void >  pfnFree;
		public  delegate* unmanaged[Cdecl,SuppressGCTransition]< void*,nuint,VkInternalAllocationType,VkSystemAllocationScope,void >  pfnInternalAllocation;
		public  delegate* unmanaged[Cdecl,SuppressGCTransition]< void*,nuint,VkInternalAllocationType,VkSystemAllocationScope,void >  pfnInternalFree;
	}

	internal const uint VK_MAX_EXTENSION_NAME_SIZE = 256U;
	internal const uint VK_MAX_DESCRIPTION_SIZE = 256U;

}


internal unsafe static partial class WindowsContextGraphicDeviceSurface
{


}


	internal unsafe static class WindowsContextGraphicRender
	{
		internal unsafe static class RenderPassCreation
		{


		}

		internal unsafe static class PipelineCreation
		{


		}

		internal unsafe static class Drawings
		{


		}

	}

internal unsafe static class WindowsContextGraphicPipelineCreation
{

	internal unsafe static class ShaderCreation
	{


	}
	internal unsafe static class TextureCreation
	{


	}
	internal unsafe static class VertexCreation
	{


	}

}

internal unsafe static class WindowsContextInputs
{
	internal unsafe static class Mouses
	{


	}
	internal unsafe static class Keyboards
	{


	}

	//Mouse 

	//Keyboard

	//Gampad ?
}

internal unsafe static class WindowsContextGamepads
{


}

internal unsafe static class WindowsContextAudioDevice
{

	internal unsafe static class AudioDeviceInit
	{


	}
	internal unsafe static class Sound2DCreation
	{


	}
	internal unsafe static class Sound3DCreation
	{


	}

}
