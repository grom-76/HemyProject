namespace Hemy.Lib.Core.Platform.V2;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

using const_char = System.Byte;
using BOOL = System.Int32;

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

using static Hemy.Lib.Core.Platform.V2.WindowsContextGraphicDeviceCommon;


public sealed class WindowSettings
{
	public uint Resolution = 0;
}


internal unsafe struct WindowsContextDataPerFrame()
{
	internal uint State = 0;
	internal uint Error = 0;
	internal Hwnd* WindowHandle = null;

}


internal unsafe struct WindowsContextDataInfos() // = Settings  
{
	internal fixed byte GameName[256];
	internal fixed byte EngineName[16];
	internal fixed byte LogoIcon[32];
	internal void* Handle = null;
	internal Hwnd* HInstance = null;
	internal uint Style = 0;
	internal VkInstance* VkInstance = null;
	internal VkSurfaceKHR* VkSurface = null;
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
	internal WindowsContextStrArray* DeviceExtensions = null;

	internal ulong VkEnxtensions = 0UL;
	internal VkPhysicalDevice* PhysicalDevice = null;

	internal uint GraphicQueueIndex = uint.MaxValue;
	internal uint PresentQueueIndex = uint.MaxValue;
	internal VkDevice* VkDevice = null;
	internal VkQueue* GraphicQueue = null;
	internal VkQueue* PresentQueue = null;

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
internal struct VkDevice;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal struct VkDebugUtilsMessengerEXT;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal struct VkPhysicalDevice;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal struct VkSurfaceKHR;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal struct VkQueue;


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

	internal static void RequestClose(WindowsContextDataPerFrame* contextData)
    {
        if (contextData->State == 0) return;
        
        contextData->State = 1;
        PostQuitMessage(0);
    }

	private const uint PM_REMOVE = 0x0001;
	internal const uint WM_QUIT = 0x0012;
	private const string User = "user32";


	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial long* DefWindowProcA(void* hWnd, uint Msg, uint* wParam, long* lParam);

	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial void PostQuitMessage(int wRemoveMsg);

	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial int TranslateMessage(MSG* lpMsg);

	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial long DispatchMessageA(MSG* lpMsg);

	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)])]
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
	internal static void Dispose(void* pointer) 
	{
		if (pointer == null) return;

		_aligned_free(pointer);
		Interlocked.Decrement(ref _allocations);
	}
	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static void* Copy(void* ptrSource, void* ptrDestination, nuint size)
		=> memmove(ptrDestination, ptrSource, size);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static void* Fill(void* destination, int valueToFill, nuint bytesCount)
		=> memset(destination, valueToFill, bytesCount);

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
		var bytes = WindowsContextMemory.New(file);
		int err = _access_s(bytes, 0);
		WindowsContextMemory.Dispose(bytes);
		return err == 0;
	}

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	[LibraryImport(Ucrt, SetLastError = false)]
	internal static partial int _access_s(const_char* path, int mode);
}

internal unsafe static class WindowsContextMaths
{

}

internal unsafe static class WindowsContextGraphicMonitors
{


}

internal unsafe static partial class WindowsContextGraphicWindow
{
	internal const string Kernel = "kernel32";// https://www.geoffchappell.com/studies/windows/win32/kernel32/api/index.htm
	internal const string User = "user32";// https://learn.microsoft.com/en-us/windows/win32/api/winuser/

	internal static int CreateWindowSettings(WindowsContextDataInfos* infos, WindowSettings settingsWindow )
	{
		// WindowStyle WinStyle =infos->Style;

		// Str.StringToBytes(contextData->GameName, Str.BytesToString(info->GameName));
		// Str.StringToBytes(contextData->EngineName, "Hemy Engine");
		// byte* LogoIcon = Str.New("Logo.ico");
		// contextData->HInstance = GetModuleHandleA(null);
		WindowsContextUtils.FillBytesWithString(infos->LogoIcon, "LogoIcon");

		// WS_EX_LEFT | WS_EX_WINDOWEDGE | WS_EX_APPWINDOW;
		// int Left = CW_USEDEFAULT;
		// int Top = CW_USEDEFAULT;
		// uint Style = Utils.StyleToValue(WinStyle);  // WS_CAPTION | WS_DLGFRAME | WS_BORDER | WS_SYSMENU | WS_THICKFRAME | WS_SIZEFRAME;
		// contextData->IsRunning = true;
		// contextData->Width = info->PreferredWidth;
		// contextData->Height = info->PreferredHeight;

		// MonitorImpl.MonitorsInfo(monitorData);

		// if (WinStyle == WindowStyle.None)
		// {
		//     styleEx &= ~(uint)WS_EX_WINDOWEDGE;
		// }

		// if (WinStyle == WindowStyle.Fullscreen)
		// {
		//     contextData->Width = monitorData->ScreenWidth;
		//     contextData->Height = monitorData->ScreenHeight;
		//     Left = monitorData->ScreenLeft;
		//     Top = monitorData->ScreenTop;
		//     // contextData->WindowState = Consts.SW_SHOWMAXIMIZED;
		// }
		// else
		// {
		//     AdjustAreaSize(contextData, Left, Top, Style, WinStyle != WindowStyle.Fullscreen || WinStyle != WindowStyle.Fixed);
		//     CenterWindow(contextData, &Left, &Top);
		//     // data->WindowState = Consts.SW_SHOWNORMAL;
		// }
		return 0;	
	}

	internal static int CreateWindow(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos, delegate* unmanaged[Stdcall, SuppressGCTransition]<void*, uint, uint*, long*, long*> WinMessageProcedure)
	{
		var styleEx = 23589U; 

		WndClassExA* wndClassExA = stackalloc WndClassExA[1];
		wndClassExA->cbSize = (uint)Unsafe.SizeOf<WndClassExA>();
		wndClassExA->style = /* CS_HREDRAW */0x0001 | /* CS_VREDRAW */0x0002 | /* CS_DBLCLKS */ 0x0008 | /* CS_OWNDC */ 0x0020;
		wndClassExA->WindowPrecedureMessage = WinMessageProcedure;
		wndClassExA->cbClsExtra = 0;
		wndClassExA->cbWndExtra = 0;
		wndClassExA->hIcon = LoadImageA(infos->HInstance, infos->LogoIcon, /* IMAGE_ICON */ 1, 0, 0, /* LR_DEFAULTSIZE */0x0040 | /* LR_LOADFROMFILE */  0x0010);//WIN.LoadIcon(data->HInstance, data->LogoIcon );
		wndClassExA->hCursor = LoadCursorA(null, 32512/* IDC_ARROW */ );
		wndClassExA->hIconSm = null;
		wndClassExA->hbrBackground = ((nint)6 /*COLOR_WINDOW*/).ToPointer();
		wndClassExA->lpszMenuName = null;
		wndClassExA->hInstance = infos->HInstance;
		wndClassExA->lpszClassName = infos->EngineName;

		if (RegisterClassExA(wndClassExA) == 0)	{ return 1;	}

		perframe->WindowHandle = CreateWindowExA(
			styleEx,
			infos->EngineName,
			infos->GameName,
			infos->Style,
			unchecked((int)(0x80000000)),
			unchecked((int)(0x80000000)),//Top,
			infos->Width, infos->Height,// <= VIEWPORT
			null, null,
			infos->HInstance, null);

		return perframe->WindowHandle == null ? 1:0;
	}
	
	internal static int DisposeWindow(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
    {
        
        if (perframe->WindowHandle != null)
        {
			if (0 == DestroyWindow(perframe->WindowHandle))
				return 1;
        }

		if (0 == UnregisterClassA(infos->EngineName, infos->HInstance))
			return 1;
		return 0;
    }

	internal static void ShowWindow(WindowsContextDataInfos* infos)
	{
		if (infos->Handle == null) return;// Debug if hancle  null

		_ = ShowWindow(infos->Handle, 5);
	}


	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Kernel, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial void* GetModuleHandleA( /*LPCSTR*/ byte* lpModuleName);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(User, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial ushort RegisterClassExA(WndClassExA* unnamedParam1);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(User, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial int DestroyWindow(Hwnd* hWnd);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(User, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial int UnregisterClassA(byte* lpszClassName, Hwnd* hWnd);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(User, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	private static partial Hwnd* CreateWindowExA(uint dwExStyle, byte* lpClassName, byte* lpWindowName, uint dwStyle, int X, int Y, int nWidth, int nHeight, void* hWndParent, void* hMenu, void* hInstance, void* lpParam);

	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int ShowWindow(void* hWnd, int nCmdShow);


	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial void* LoadCursorA(void* hInstance, int lpCursorName);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvStdcall), typeof(CallConvSuppressGCTransition)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial void* LoadImageA(void* hInstance, byte* lpIconName, uint type, int cx, int cy, uint fuLoad);


	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	internal struct WndClassExA
	{
		internal uint cbSize;
		internal uint style;
		internal unsafe delegate* unmanaged[Stdcall,SuppressGCTransition ]<Hwnd* /*hWnd*/, uint /*msg*/, uint* /*wParam*/, long* /*lpParam*/, long* /*LRESULT*/> WindowPrecedureMessage;
		internal int cbClsExtra;
		internal int cbWndExtra;
		internal unsafe void* hInstance;
		internal unsafe void* hIcon;
		internal unsafe void* hCursor;
		internal unsafe void* hbrBackground;
		internal unsafe byte* lpszMenuName;
		internal unsafe byte* lpszClassName;  // internal fixed char lpszClassName[256];
		internal unsafe void* hIconSm;
	}

}

internal unsafe static partial class WindowsContextGraphicDeviceCommon
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
	public unsafe static void* LoadInstanceFunc(VkInstance* vkInstance, string name)
	{
		byte* str = WindowsContextMemory.New(name);
		void* result = vkGetInstanceProcAddr(*vkInstance, str);
		WindowsContextMemory.Dispose(str);

		return result;
	}

	public unsafe static void* LoadDeviceFunc(VkDevice* vkDevice, string name)
	{
		byte* str = WindowsContextMemory.New(name);
		void* result = vkGetDeviceProcAddr(*vkDevice, str);
		WindowsContextMemory.Dispose(str);
		return result;
	}

	[LibraryImport(Vulkan, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void* vkGetInstanceProcAddr(VkInstance instance, const_char* pName);

	[LibraryImport(Vulkan, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void* vkGetDeviceProcAddr(VkDevice device, const_char* pName);

	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct VkAllocationCallbacks
	{
		public void* pUserData;
		public delegate* unmanaged[Cdecl, SuppressGCTransition]<void*, nuint, nuint, VkSystemAllocationScope, void*> pfnAllocation;
		public delegate* unmanaged[Cdecl, SuppressGCTransition]<void*, void*, nuint, nuint, VkSystemAllocationScope, void*> pfnReallocation;
		public delegate* unmanaged[Cdecl, SuppressGCTransition]<void*, void*, void> pfnFree;
		public delegate* unmanaged[Cdecl, SuppressGCTransition]<void*, nuint, VkInternalAllocationType, VkSystemAllocationScope, void> pfnInternalAllocation;
		public delegate* unmanaged[Cdecl, SuppressGCTransition]<void*, nuint, VkInternalAllocationType, VkSystemAllocationScope, void> pfnInternalFree;
	}

	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	internal struct VkExtent3D
	{
		uint32_t width;
		uint32_t height;
		uint32_t depth;
	}

	public enum VkSystemAllocationScope
	{
		VK_SYSTEM_ALLOCATION_SCOPE_COMMAND = 0,
		VK_SYSTEM_ALLOCATION_SCOPE_OBJECT = 1,
		VK_SYSTEM_ALLOCATION_SCOPE_CACHE = 2,
		VK_SYSTEM_ALLOCATION_SCOPE_DEVICE = 3,
		VK_SYSTEM_ALLOCATION_SCOPE_INSTANCE = 4,
		VK_SYSTEM_ALLOCATION_SCOPE_MAX_ENUM = 0x7FFFFFFF // 2147483647= int.MAx
	};

	public enum VkInternalAllocationType
	{
		VK_INTERNAL_ALLOCATION_TYPE_EXECUTABLE = 0,
		VK_INTERNAL_ALLOCATION_TYPE_MAX_ENUM = 0x7FFFFFFF
	};



	internal enum VkResult
	{
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

	internal enum VkStructureType
	{

		VK_STRUCTURE_TYPE_APPLICATION_INFO = 0,
		VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO = 1,
		VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO = 2,
		VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO = 3,
		VK_STRUCTURE_TYPE_WIN32_SURFACE_CREATE_INFO_KHR = 1000009000,
		VK_STRUCTURE_TYPE_DEBUG_UTILS_MESSENGER_CREATE_INFO_EXT = 1000128004,
	}

	internal enum VkExtension
	{
		VK_EXT_DEBUG_UTILS_EXTENSION_NAME = 0,
		VK_KHR_WIN32_SURFACE_EXTENSION_NAME,
		VK_KHR_SURFACE_EXTENSION_NAME,
	}

	internal static int ReadBit(this ulong value, VkExtension mask)
	{
		return ((value >> (int)mask) & 1) == 0 ? 0 : 1;
	}

	internal const uint VK_MAX_EXTENSION_NAME_SIZE = 256U;
	internal const uint VK_MAX_DESCRIPTION_SIZE = 256U;
	// internal const uint VK_MAX_EXTENSION_NAME_SIZE = 256U;

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
		=> WindowsContextUtils.BytesToString( _array + (itemMaxSize * index),itemMaxSize );

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

		for (uint i = 0; i < layerCount; i++)
		{
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

	internal static int LoadDebug(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		vkDestroyDebugUtilsMessengerEXT = ( delegate* unmanaged[Cdecl, SuppressGCTransition]<VkInstance, VkDebugUtilsMessengerEXT, VkAllocationCallbacks*, void>)LoadInstanceFunc(infos->VkInstance, "vkDestroyDebugUtilsMessengerEXT");
		vkCreateDebugUtilsMessengerEXT = ( delegate* unmanaged[Cdecl, SuppressGCTransition]<VkInstance, VkDebugUtilsMessengerCreateInfoEXT*, VkAllocationCallbacks*, VkDebugUtilsMessengerEXT*, VkResult>)LoadInstanceFunc(infos->VkInstance, "vkCreateDebugUtilsMessengerEXT");
		
		return 0;
	}

	internal static int CreateDebug(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos, VkDebugUtilsMessengerCreateInfoEXT* debugCreateInfo)
	{
		if (infos->EnableDebugMode == false) return 0;

		VkResult result = vkCreateDebugUtilsMessengerEXT(*infos->VkInstance, &debugCreateInfo[0], null, infos->VkDebugUtilsMessenger);
		if (result != VkResult.VK_SUCCESS) return 1;

		return 0;
	}

	internal static int DisposeDebug(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		if (infos->VkInstance == null || infos->VkDebugUtilsMessenger == null) return 1;

		vkDestroyDebugUtilsMessengerEXT(*infos->VkInstance, *infos->VkDebugUtilsMessenger, null);

		return 0;
	}

	internal static delegate* unmanaged[Cdecl, SuppressGCTransition]<VkInstance, VkDebugUtilsMessengerCreateInfoEXT*, VkAllocationCallbacks*, VkDebugUtilsMessengerEXT*, VkResult> vkCreateDebugUtilsMessengerEXT = null;

	internal static delegate* unmanaged[Cdecl, SuppressGCTransition]<VkInstance, VkDebugUtilsMessengerEXT, VkAllocationCallbacks*, void> vkDestroyDebugUtilsMessengerEXT = null;


	[UnmanagedCallersOnly]
	static uint DebugMessengerCallback(VkDebugUtilsMessageSeverityFlagBitsEXT messageSeverity,
		VkDebugUtilsMessageTypeFlagBitsEXT messageTypes,
		VkDebugUtilsMessengerCallbackDataEXT* pCallbackData, void* pUserData)
	{
		string Header = messageSeverity == VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT ?
			"ERROR" : messageSeverity == VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT ?
				"WARNING" : "INFO";

		Log.Display(Header, pCallbackData->pMessage);
		return VK_FALSE;
	}

	private const string VK_EXT_DEBUG_UTILS_EXTENSION_NAME = "VK_EXT_debug_utils";

	[LibraryImport(Vulkan, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkEnumerateInstanceLayerProperties(uint32_t* pPropertyCount, VkLayerProperties* pProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkEnumerateInstanceExtensionProperties(const_char* pLayerName, uint32_t* pPropertyCount, VkExtensionProperties* pProperties);

	[LibraryImport(Vulkan, SetLastError = true)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateInstance(VkInstanceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkInstance* pInstance);

	[LibraryImport(Vulkan, SetLastError = true)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
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

	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	internal struct VkExtensionProperties
	{
		internal fixed byte extensionName[(int)VK_MAX_EXTENSION_NAME_SIZE];
		internal uint32_t specVersion;
	}

	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	internal struct VkDebugUtilsMessengerCreateInfoEXT
	{
		internal VkStructureType sType;
		internal void* pNext;
		internal uint flags;
		internal uint messageSeverity;
		internal uint messageType;
		internal delegate* unmanaged<VkDebugUtilsMessageSeverityFlagBitsEXT, VkDebugUtilsMessageTypeFlagBitsEXT, VkDebugUtilsMessengerCallbackDataEXT*, void*, uint> pfnUserCallback;
		internal void* pUserData;
	}

	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct VkDebugUtilsMessengerCallbackDataEXT
	{
		internal VkStructureType sType;
		internal const_char* pMessageIdName;
		internal int/* VkDebugUtilsMessengerCallbackDataFlagsEXT */    flags;// alwways 0 
		internal int32_t messageIdNumber;
		internal void* pNext;
		internal const_char* pMessage;
		internal uint32_t queueLabelCount;
		internal VkDebugUtilsLabelEXT* pQueueLabels;
		internal uint32_t cmdBufLabelCount;
		internal VkDebugUtilsLabelEXT* pCmdBufLabels;
		internal uint32_t @objectCount;
		internal VkDebugUtilsObjectNameInfoEXT* pObjects;
	}

	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct VkDebugUtilsLabelEXT
	{
		public VkStructureType sType;
		public void* pNext;
		public const_char* pLabelName;
		public fixed float color[4];
	}

	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct VkDebugUtilsObjectNameInfoEXT
	{
		public VkStructureType sType;
		public void* pNext;
		public VkObjectType @objectType;
		public uint64_t @objectHandle;
		public const_char* pObjectName;
	}

	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct VkApplicationInfo
	{
		internal VkStructureType sType;
		internal void* pNext;
		internal const_char* pApplicationName;
		internal uint32_t applicationVersion;
		internal const_char* pEngineName;
		internal uint32_t engineVersion;
		internal uint32_t apiVersion;
	}

	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct VkInstanceCreateInfo
	{
		internal VkStructureType sType;
		internal void* pNext;
		internal VkInstanceCreateFlagBits flags;
		internal VkApplicationInfo* pApplicationInfo;
		internal uint32_t enabledLayerCount;
		internal const_char** ppEnabledLayerNames;
		internal uint32_t enabledExtensionCount;
		internal const_char** ppEnabledExtensionNames;
	}

	

internal enum VkDebugUtilsMessageSeverityFlagBitsEXT    {
    VK_DEBUG_UTILS_MESSAGE_SEVERITY_VERBOSE_BIT_EXT = 0x00000001, 
    VK_DEBUG_UTILS_MESSAGE_SEVERITY_INFO_BIT_EXT = 0x00000010, 
    VK_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT = 0x00000100, 
    VK_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT = 0x00001000, 
    VK_DEBUG_UTILS_MESSAGE_SEVERITY_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};

	internal enum VkDebugUtilsMessageTypeFlagBitsEXT
	{
		VK_DEBUG_UTILS_MESSAGE_TYPE_GENERAL_BIT_EXT = 0x00000001,
		VK_DEBUG_UTILS_MESSAGE_TYPE_VALIDATION_BIT_EXT = 0x00000002,
		VK_DEBUG_UTILS_MESSAGE_TYPE_PERFORMANCE_BIT_EXT = 0x00000004,
		VK_DEBUG_UTILS_MESSAGE_TYPE_DEVICE_ADDRESS_BINDING_BIT_EXT = 0x00000008,
		VK_DEBUG_UTILS_MESSAGE_TYPE_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF
	};

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

}

internal unsafe static partial class WindowsContextGraphicDeviceSurface
{
	internal static int LoadSurface(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		vkCreateWin32SurfaceKHR = (delegate* unmanaged[Cdecl, SuppressGCTransition]<VkInstance, VkWin32SurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)LoadInstanceFunc(infos->VkInstance, "vkCreateWin32SurfaceKHR");

		vkGetPhysicalDeviceWin32PresentationSupportKHR = (delegate* unmanaged[Cdecl, SuppressGCTransition]<VkPhysicalDevice,  UInt32, VkBool32>)LoadInstanceFunc(infos->VkInstance, "vkGetPhysicalDeviceWin32PresentationSupportKHR");

		vkDestroySurfaceKHR = (delegate* unmanaged[Cdecl, SuppressGCTransition]<VkInstance, VkSurfaceKHR, VkAllocationCallbacks*, void>)LoadInstanceFunc(infos->VkInstance, "vkDestroySurfaceKHR");

		return 0;
	}

	internal static int CreateSurface(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		VkWin32SurfaceCreateInfoKHR* sci = stackalloc VkWin32SurfaceCreateInfoKHR[1];
		sci[0].hinstance = infos->HInstance;
		sci[0].hwnd = infos->Handle;
		sci[0].pNext = null;
		sci[0].flags = 0;
		sci[0].sType = VkStructureType.VK_STRUCTURE_TYPE_WIN32_SURFACE_CREATE_INFO_KHR;

		var result = vkCreateWin32SurfaceKHR(*infos->VkInstance, &sci[0], null, infos->VkSurface);

		return result == VkResult.VK_SUCCESS ? 0 : 1;
	}

	internal static int DisposeSurface(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		if (infos->VkInstance == null || infos->VkSurface == null) return 0;
        
		vkDestroySurfaceKHR(*infos->VkInstance, *infos->VkSurface, null);

		return 0;
	}
	private const string VK_KHR_WIN32_SURFACE_EXTENSION_NAME = "VK_KHR_win32_surface";
	public const string VK_KHR_SURFACE_EXTENSION_NAME = "VK_KHR_surface";
	private static delegate* unmanaged[Cdecl, SuppressGCTransition]<VkInstance, VkWin32SurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult> vkCreateWin32SurfaceKHR = null;
	internal static delegate* unmanaged[Cdecl, SuppressGCTransition]<VkPhysicalDevice, UInt32, VkBool32> vkGetPhysicalDeviceWin32PresentationSupportKHR = null;
	
	private static delegate* unmanaged[Cdecl, SuppressGCTransition]<VkInstance, VkSurfaceKHR, VkAllocationCallbacks*, void> vkDestroySurfaceKHR = null;
	
[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct VkWin32SurfaceCreateInfoKHR
{
    public VkStructureType sType;
    public void* pNext;
    public uint/*VkWin32SurfaceCreateFlagsKHR*/    flags;
    public void*/*HINSTANCE*/                       hinstance;
    public void*/*HWND*/                            hwnd;
};
}

internal unsafe static partial class WindowsContextGraphicDevicePhysicalDevice
{
	internal static int SelectPhysicalDevice(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		// Enumerate physical Device
		uint deviceCount = 0;
		VkResult result = vkEnumeratePhysicalDevices(*infos->VkInstance, &deviceCount, null);
		// if (Log.Check(result != VkResult.VK_SUCCESS, "Error Enumerate Physical Device : " + result)) { return 1; }

		VkPhysicalDevice* devices = stackalloc VkPhysicalDevice[(int)deviceCount];

		result = vkEnumeratePhysicalDevices(*infos->VkInstance, &deviceCount, devices);
		// if (Log.Check(result != VkResult.VK_SUCCESS, "Error Create Enumerate Physical Device" + result)) { return 1; }

		// 	// Find best physical device         //  : select in options your favorite device
		for (int i = 0; i < (int)deviceCount; i++)
		{
			
			infos->PhysicalDevice = IsSuitable(infos, devices[i] );

			if (infos->PhysicalDevice != null)
				break;
		}

		if (infos->PhysicalDevice == null) return 1;

		// Get Devicxe Extensions
		uint devicePropertiesExtCount = 0;
		result = vkEnumerateDeviceExtensionProperties(*infos->PhysicalDevice, null, &devicePropertiesExtCount, null);
		// if (Log.Check(result != VkResult.VK_SUCCESS || devicePropertiesExtCount == 0, "Error Create Enumerate Physical Device" + result)) { return 1; }

		VkExtensionProperties* properties = stackalloc VkExtensionProperties[(int)devicePropertiesExtCount];
		result = vkEnumerateDeviceExtensionProperties(*infos->PhysicalDevice, null, &devicePropertiesExtCount, properties);
		// if (Log.Check(result != VkResult.VK_SUCCESS, "Error Create Enumerate Physical Device" + result)) { return 1; }

		// infos->DeviceExtensions = new(devicePropertiesExtCount, VK_MAX_DESCRIPTION_SIZE);

		for (uint i = 0; i < devicePropertiesExtCount; i++)
		{
			infos->DeviceExtensions->Add(properties[i].extensionName, i);
		}

		return 0;
	}

	internal static VkPhysicalDevice* IsSuitable(WindowsContextDataInfos* infos, VkPhysicalDevice physical)
	{
		uint queueFamilyPropertyCount = 0;
		vkGetPhysicalDeviceQueueFamilyProperties(physical, &queueFamilyPropertyCount, null);

		VkQueueFamilyProperties* queueFamilyProperties = stackalloc VkQueueFamilyProperties[(int)queueFamilyPropertyCount];

		vkGetPhysicalDeviceQueueFamilyProperties(physical, &queueFamilyPropertyCount, queueFamilyProperties);

		for (uint i = 0; i < queueFamilyPropertyCount; i++)
		{

			var queue = queueFamilyProperties[i];

			if ((queue.queueFlags & VkQueueFlags.VK_QUEUE_GRAPHICS_BIT) != 0)
			{
				infos->GraphicQueueIndex = i;

				uint presentSupport = WindowsContextGraphicDeviceSurface.vkGetPhysicalDeviceWin32PresentationSupportKHR(physical, infos->GraphicQueueIndex);

				if (presentSupport == VK_TRUE)
				{
					infos->PresentQueueIndex = i;
				}
			}

		}
		// Log.Info("Is Suitable");
		//  bool extensionsSupported = checkDeviceExtensionSupport(device);
		// SwapChainSupportDetails querySwapChainSupport(VkPhysicalDevice device)

		return (infos->GraphicQueueIndex == uint.MaxValue && infos->PresentQueueIndex == uint.MaxValue) ? null : &physical;
	}

	[LibraryImport(Vulkan, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkEnumeratePhysicalDevices(VkInstance instance, uint32_t* pPhysicalDeviceCount, VkPhysicalDevice* pPhysicalDevices);


	[LibraryImport(Vulkan, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, const_char* pLayerName, uint32_t* pPropertyCount, VkExtensionProperties* pProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPhysicalDeviceQueueFamilyProperties(VkPhysicalDevice physicalDevice, uint32_t* pQueueFamilyPropertyCount, VkQueueFamilyProperties* pQueueFamilyProperties);

	// [LibraryImport(Vulkan, SetLastError = false)]
	// [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	// [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	// internal static unsafe partial void vkGetPhysicalDeviceQueueFamilyProperties2(VkPhysicalDevice physicalDevice, uint32_t* pQueueFamilyPropertyCount, VkQueueFamilyProperties2* pQueueFamilyProperties);

	// public static delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkQueueFamilyProperties2*, void> vkGetPhysicalDeviceQueueFamilyProperties2KHR = null;

	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct VkExtensionProperties
	{
		public fixed byte extensionName[(int)VK_MAX_EXTENSION_NAME_SIZE];
		public uint32_t specVersion;
	}

	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct VkQueueFamilyProperties2
	{
		public VkStructureType sType;
		public void* pNext;
		public VkQueueFamilyProperties queueFamilyProperties;
	}

	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct VkQueueFamilyProperties
	{
		public VkQueueFlags queueFlags;
		public uint32_t queueCount;
		public uint32_t timestampValidBits;
		public VkExtent3D minImageTransferGranularity;
	}

[Flags] internal enum VkQueueFlags {
    VK_QUEUE_GRAPHICS_BIT = 0x00000001,
    VK_QUEUE_COMPUTE_BIT = 0x00000002,
    VK_QUEUE_TRANSFER_BIT = 0x00000004,
    VK_QUEUE_SPARSE_BINDING_BIT = 0x00000008,
  // Provided by VK_VERSION_1_1
    VK_QUEUE_PROTECTED_BIT = 0x00000010,
  // Provided by VK_KHR_video_decode_queue
    VK_QUEUE_VIDEO_DECODE_BIT_KHR = 0x00000020,
  // Provided by VK_KHR_video_encode_queue
    VK_QUEUE_VIDEO_ENCODE_BIT_KHR = 0x00000040,
  // Provided by VK_NV_optical_flow
    VK_QUEUE_OPTICAL_FLOW_BIT_NV = 0x00000100,
  // Provided by VK_ARM_data_graph
    VK_QUEUE_DATA_GRAPH_BIT_ARM = 0x00000400,
} 
}

internal unsafe static partial class WindowsContextGraphicDevice
{

	internal static int CreateDevice(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		 // Get Devicxe Extensions
        uint devicePropertiesExtCount = 0;
        VkResult result = vkEnumerateDeviceExtensionProperties(*infos->PhysicalDevice, null, &devicePropertiesExtCount, null);
        // if (Log.Check(result != VkResult.VK_SUCCESS || devicePropertiesExtCount == 0, "Error Create Enumerate Physical Device" + result)) { return 1; }

        VkExtensionProperties* properties = stackalloc VkExtensionProperties[(int)devicePropertiesExtCount];
        result = vkEnumerateDeviceExtensionProperties(*infos->PhysicalDevice, null, &devicePropertiesExtCount, properties);
        // if (Log.Check(result != VkResult.VK_SUCCESS, "Error Create Enumerate Physical Device" + result)) { return 1; }

        // Hemy.Lib.Core.Memory.StrArray DeviceExtensions = new(devicePropertiesExtCount, VK_MAX_DESCRIPTION_SIZE);

        for (uint i = 0; i < devicePropertiesExtCount; i++)
        {
            infos->DeviceExtensions->Add(properties[i].extensionName, i);
            // _ = Log.Check(DeviceExtensions.Add(properties[i].extensionName, i) == false, "error not add device extension  at index : " + i);
            // Log.Info("Device Extensions : "+ DeviceExtensions.GetString(i));
        }

        // 	// Get Queue Families
        uint queueFamiliesCount = infos->GraphicQueueIndex == infos->PresentQueueIndex ? (uint)1 : (uint)2;

        VkDeviceQueueCreateInfo* queueCreateInfos = stackalloc VkDeviceQueueCreateInfo[(int)queueFamiliesCount];

        float queuePriority = 1.0f;
        uint index = 0;

        queueCreateInfos[index++] = new VkDeviceQueueCreateInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO,
            queueFamilyIndex = infos->GraphicQueueIndex,
            queueCount = 1,
            pQueuePriorities = &queuePriority
        };

        if (infos->PresentQueueIndex != infos->GraphicQueueIndex)
        {
            queueCreateInfos[index++] = new VkDeviceQueueCreateInfo
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO,
                queueFamilyIndex = infos->PresentQueueIndex,
                queueCount = 1,
                pQueuePriorities = &queuePriority
            };
        }

        VkDeviceCreateInfo createInfo = new();
        createInfo.sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO;
        createInfo.queueCreateInfoCount = queueFamiliesCount;
        createInfo.pQueueCreateInfos = queueCreateInfos;
        createInfo.enabledExtensionCount = infos->DeviceExtensions->Count;
        createInfo.ppEnabledExtensionNames = (byte**)infos->DeviceExtensions->Pointer;
        createInfo.pNext = null;
        createInfo.pEnabledFeatures = null;
        createInfo.enabledLayerCount =  0;
        createInfo.ppEnabledLayerNames =null;

        createInfo.flags = 0;

        result = vkCreateDevice(*infos->PhysicalDevice, &createInfo, null, infos->VkDevice );
		return 0;
	}

	internal static void DisposeDevice(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		if (infos->VkDevice == null) return;

		vkDestroyDevice(*infos->VkDevice, null);
	}

	internal static void Pause(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		if (infos->VkDevice == null) return;

		if (VkResult.VK_SUCCESS != vkDeviceWaitIdle(*infos->VkDevice))
		{
			// Log.Warning("PAuse Device Wait Idle");
		}
	}

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkDeviceWaitIdle(VkDevice device);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, const_char* pLayerName, uint32_t* pPropertyCount, VkExtensionProperties* pProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, VkDeviceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDevice* pDevice);

	[LibraryImport(Vulkan, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyDevice(VkDevice device, VkAllocationCallbacks* pAllocator);

	internal struct VkDeviceCreateInfo
	{
		internal VkStructureType sType;
		internal void* pNext;
		internal Flag flags;//flags is reserved for future use.
		internal uint32_t queueCreateInfoCount;
		internal VkDeviceQueueCreateInfo* pQueueCreateInfos;
		internal uint32_t enabledLayerCount;// enabledLayerCount is deprecated and should not be used
		internal const_char* ppEnabledLayerNames;// ppEnabledLayerNames is deprecated and should not be used
		internal uint32_t enabledExtensionCount;
		internal const_char** ppEnabledExtensionNames;
		internal VkPhysicalDeviceFeatures* pEnabledFeatures;
	}

	internal struct VkExtensionProperties {
    internal fixed byte  extensionName[(int)VK_MAX_EXTENSION_NAME_SIZE];
    internal uint32_t    specVersion;
}

	internal struct VkDeviceQueueCreateInfo
	{
		internal VkStructureType sType;
		internal void* pNext;
		internal VkDeviceQueueCreateFlags flags; // is a bitmask indicating behavior of the queues.
		internal uint32_t queueFamilyIndex;
		internal uint32_t queueCount;
		internal float* pQueuePriorities;
	}
	
	internal enum VkDeviceQueueCreateFlags
	{
		// Provided by VK_VERSION_1_1
		VK_DEVICE_QUEUE_CREATE_PROTECTED_BIT = 0x00000001,
	}

internal struct VkPhysicalDeviceFeatures {
    VkBool32    robustBufferAccess;
    VkBool32    fullDrawIndexUint32;
    VkBool32    imageCubeArray;
    VkBool32    independentBlend;
    VkBool32    geometryShader;
    VkBool32    tessellationShader;
    VkBool32    sampleRateShading;
    VkBool32    dualSrcBlend;
    VkBool32    logicOp;
    VkBool32    multiDrawIndirect;
    VkBool32    drawIndirectFirstInstance;
    VkBool32    depthClamp;
    VkBool32    depthBiasClamp;
    VkBool32    fillModeNonSolid;
    VkBool32    depthBounds;
    VkBool32    wideLines;
    VkBool32    largePoints;
    VkBool32    alphaToOne;
    VkBool32    multiViewport;
    VkBool32    samplerAnisotropy;
    VkBool32    textureCompressionETC2;
    VkBool32    textureCompressionASTC_LDR;
    VkBool32    textureCompressionBC;
    VkBool32    occlusionQueryPrecise;
    VkBool32    pipelineStatisticsQuery;
    VkBool32    vertexPipelineStoresAndAtomics;
    VkBool32    fragmentStoresAndAtomics;
    VkBool32    shaderTessellationAndGeometryPointSize;
    VkBool32    shaderImageGatherExtended;
    VkBool32    shaderStorageImageExtendedFormats;
    VkBool32    shaderStorageImageMultisample;
    VkBool32    shaderStorageImageReadWithoutFormat;
    VkBool32    shaderStorageImageWriteWithoutFormat;
    VkBool32    shaderUniformBufferArrayDynamicIndexing;
    VkBool32    shaderSampledImageArrayDynamicIndexing;
    VkBool32    shaderStorageBufferArrayDynamicIndexing;
    VkBool32    shaderStorageImageArrayDynamicIndexing;
    VkBool32    shaderClipDistance;
    VkBool32    shaderCullDistance;
    VkBool32    shaderFloat64;
    VkBool32    shaderInt64;
    VkBool32    shaderInt16;
    VkBool32    shaderResourceResidency;
    VkBool32    shaderResourceMinLod;
    VkBool32    sparseBinding;
    VkBool32    sparseResidencyBuffer;
    VkBool32    sparseResidencyImage2D;
    VkBool32    sparseResidencyImage3D;
    VkBool32    sparseResidency2Samples;
    VkBool32    sparseResidency4Samples;
    VkBool32    sparseResidency8Samples;
    VkBool32    sparseResidency16Samples;
    VkBool32    sparseResidencyAliased;
    VkBool32    variableMultisampleRate;
    VkBool32    inheritedQueries;
}

}

internal unsafe static partial class WindowsContextGraphicDeviceQueue
{

	internal static int CreateQueue(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{

		vkGetDeviceQueue(*infos->VkDevice, infos->GraphicQueueIndex, 0, infos->GraphicQueue);
		// _ = Log.Check(contextData->GraphicQueue.IsNull, $"Graphic Queue : indice :{contextData->GraphicQueue.ToString()} ");

		vkGetDeviceQueue(*infos->VkDevice, infos->PresentQueueIndex, 0, infos->PresentQueue);
		// _ = Log.Check(contextData->PresentQueue.IsNull, $"Present Queue : indice :{contextData->PresentQueue.ToString()} ");
		return 0;
	}

	internal static int DisposeQueue(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{

		return 0;
	}
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetDeviceQueue(VkDevice device, uint32_t queueFamilyIndex, uint32_t queueIndex, VkQueue* pQueue);

	// [LibraryImport(Vulkan, SetLastError = false)]
    // [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	// [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	// internal static unsafe partial VkResult vkQueueSubmit(VkQueue queue, uint32_t submitCount, VkSubmitInfo* pSubmits, VkFence fence);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkQueueWaitIdle(VkQueue queue);
}

internal unsafe static partial class WindowsContextGraphicDeviceSwapchain
{
	internal static int FindBestValues(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		// // querySwapChainSupport
		// VkSurfaceCapabilitiesKHR Capabilities = new();

		// VkExtent2D SwapChainSurfaceSize = new();
		// _ = Vk.vkGetPhysicalDeviceSurfaceCapabilitiesKHR(infos->DevicePhysical, infos->Surface, &Capabilities);

		// if (Capabilities.currentExtent.width != uint.MaxValue)
		// {
		// 	SwapChainSurfaceSize = Capabilities.currentExtent;
		// }
		// else
		// {
		// 	SwapChainSurfaceSize.width = Clamp((uint)windowData->Width, Capabilities.minImageExtent.width, Capabilities.maxImageExtent.width);
		// 	SwapChainSurfaceSize.height = Clamp((uint)windowData->Height, Capabilities.minImageExtent.height, Capabilities.maxImageExtent.height);
		// }

		// var SwapChainImageCount = Capabilities.minImageCount + 1;

		// if (Capabilities.maxImageCount > 0 && SwapChainImageCount > Capabilities.maxImageCount)
		// {
		// 	SwapChainImageCount = Capabilities.maxImageCount;
		// }



		// uint surfaceFormatCount = 0;
		// Vk.vkGetPhysicalDeviceSurfaceFormatsKHR(infos->DevicePhysical, infos->Surface, &surfaceFormatCount, null);

		// VkSurfaceFormatKHR* surfaceFormats = stackalloc VkSurfaceFormatKHR[(int)surfaceFormatCount];

		// Vk.vkGetPhysicalDeviceSurfaceFormatsKHR(infos->DevicePhysical, infos->Surface, &surfaceFormatCount, surfaceFormats);
		return 0;
	}

	internal static void CreateSwapChain(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos) // + depth
	{


		// VkSwapchainCreateInfoKHR* createInfo = stackalloc VkSwapchainCreateInfoKHR[1];

		// bool isSharingMode = infos->GraphicQueueIndex != infos->PresentQueueIndex;
		// createInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_SWAPCHAIN_CREATE_INFO_KHR;
		// createInfo[0].pNext = null;
		// createInfo[0].surface = infos->Surface;
		// createInfo[0].minImageCount = SwapChainImageCount;
		// createInfo[0].imageFormat = VkFormat.VK_FORMAT_B8G8R8A8_SRGB;
		// createInfo[0].imageColorSpace = VkColorSpaceKHR.VK_COLOR_SPACE_SRGB_NONLINEAR_KHR;
		// createInfo[0].imageExtent = SwapChainSurfaceSize;
		// createInfo[0].imageArrayLayers = 1;// no stereoscopi;
		// createInfo[0].imageUsage = (uint)VkImageUsageFlagBits.VK_IMAGE_USAGE_COLOR_ATTACHMENT_BIT;
		// createInfo[0].preTransform = Capabilities.currentTransform;
		// createInfo[0].compositeAlpha = VkCompositeAlphaFlagBitsKHR.VK_COMPOSITE_ALPHA_OPAQUE_BIT_KHR;
		// createInfo[0].presentMode = VkPresentModeKHR.VK_PRESENT_MODE_FIFO_KHR;
		// createInfo[0].clipped = VK.VK_TRUE;
		// createInfo[0].oldSwapchain = VkSwapchainKHR.Null;
		// createInfo[0].imageSharingMode = isSharingMode ? VkSharingMode.VK_SHARING_MODE_CONCURRENT : VkSharingMode.VK_SHARING_MODE_EXCLUSIVE;
		// createInfo[0].queueFamilyIndexCount = (uint)(isSharingMode ? 2 : 1);
		// if (isSharingMode)
		// {
		// 	uint* queueFamilyIndices = stackalloc uint[2] { infos->GraphicQueueIndex, infos->PresentQueueIndex };
		// 	createInfo[0].imageSharingMode = VkSharingMode.VK_SHARING_MODE_CONCURRENT;
		// }

		// //  Log.Info("Create SwaPchain" + infos->Device + " : " + infos->SwapChain +" : "+ createInfo[0].imageSharingMode +" : " +infos->Surface + " : " + SwapChainImageCount);
		// var result = vkCreateSwapchainKHR(infos->Device, &createInfo[0], null, &infos->SwapChain);

		// _ = Log.Check(result != VkResult.VK_SUCCESS, "SwapChain Creation :");

		// contextData->SwapChainImageViewsCount = SwapChainImageViewsCount;
		// contextData->SwapChainImageFormat = VkFormat.VK_FORMAT_B8G8R8A8_SRGB;

		// contextData->RenderPassArea = Memory.Memory.NewArray<VkRect2D>(1);
		// // contextData->RenderPassArea = (VkRect2D*)NativeMemory.Alloc(1 * (uint)Unsafe.SizeOf<VkRect2D>());
		// contextData->RenderPassArea->extent = SwapChainSurfaceSize;
		// contextData->RenderPassArea->offset.x = 0;
		// contextData->RenderPassArea->offset.y = 0;
	}

	internal static void CreateSwapChainImages(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos) // + depth
	{

		// uint SwapChainImageViewsCount = 0;
		// Vk.vkGetSwapchainImagesKHR(infos->Device, infos->SwapChain, &SwapChainImageViewsCount, null);

		// if (infos->SwapChainImageViews == null)
		// 	infos->SwapChainImages = Memory.Memory.NewArray<VkImage>(SwapChainImageViewsCount);
		// // infos->SwapChainImages = (VkImage*)NativeMemory.Alloc(SwapChainImageViewsCount * (uint)Unsafe.SizeOf<VkImage>());

		// result = Vk.vkGetSwapchainImagesKHR(infos->Device, infos->SwapChain, &SwapChainImageViewsCount, infos->SwapChainImages);
		// // _ = Log.Check(result != VkResult.VK_SUCCESS, $" SwapChain image  ");

		// // SWWAP CHAIN IMAGES  VIEWS FOR FRAMEBUFFER ----------------------------------------------------------------------
		// if (infos->SwapChainImageViews == null)
		// 	infos->SwapChainImageViews = Memory.Memory.NewArray<VkImageView>(SwapChainImageCount);
		// // contextData->SwapChainImageViews = (VkImageView*)NativeMemory.Alloc(SwapChainImageViewsCount * (uint)Unsafe.SizeOf<VkImageView>());

		// VkImageViewCreateInfo* viewInfo = stackalloc VkImageViewCreateInfo[1];
		// for (uint i = 0; i < SwapChainImageViewsCount; i++)
		// {
		// 	viewInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_IMAGE_VIEW_CREATE_INFO;
		// 	viewInfo[0].pNext = null;
		// 	viewInfo[0].image = contextData->SwapChainImages[i];
		// 	viewInfo[0].viewType = VkImageViewType.VK_IMAGE_VIEW_TYPE_2D;
		// 	viewInfo[0].format = VkFormat.VK_FORMAT_B8G8R8A8_SRGB;

		// 	viewInfo[0].components.r = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY;
		// 	viewInfo[0].components.g = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY;
		// 	viewInfo[0].components.b = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY;
		// 	viewInfo[0].components.a = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY;
		// 	viewInfo[0].subresourceRange.aspectMask = (uint)VkImageAspectFlagBits.VK_IMAGE_ASPECT_COLOR_BIT;
		// 	viewInfo[0].subresourceRange.baseMipLevel = 0;
		// 	viewInfo[0].subresourceRange.levelCount = 1;
		// 	viewInfo[0].subresourceRange.baseArrayLayer = 0;
		// 	viewInfo[0].subresourceRange.layerCount = 1;

		// 	result = Vk.vkCreateImageView(contextData->Device, &viewInfo[0], null, &contextData->SwapChainImageViews[i]);
		// 	// _ = Log.Check(result != VkResult.VK_SUCCESS, $"Create image view :{contextData->SwapChainImageViews[i].ToString()} ");
		// }

	}

	private static void CreateFrameBufer(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		// VkResult result = VkResult.VK_SUCCESS;

		// if (contextData->Framebuffers == null)
		// 	contextData->Framebuffers = Memory.Memory.NewArray<VkFramebuffer>(contextData->SwapChainImageViewsCount);
		// // contextData->Framebuffers = (VkFramebuffer*)NativeMemory.Alloc(contextData->SwapChainImageViewsCount * (uint)Unsafe.SizeOf<VkFramebuffer>());

		// // VkImageView* attachments2 = (VkImageView*)NativeMemory.Alloc(1 * (uint)Unsafe.SizeOf<VkImageView>());
		// // TODO : replace attachements alloc par stackalloc 
		// VkFramebufferCreateInfo* framebufferInfo = stackalloc VkFramebufferCreateInfo[1];
		// for (int i = 0; i < contextData->SwapChainImageViewsCount; i++)
		// {
		// 	// attachments2[0] = contextData->SwapChainImageViews[i];
		// 	// if( contextData->IsUseDepthBuffer )
		// 	//     attachments2[1]  = contextData->DephtBufferImageViews[i] ;
		// 	framebufferInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_FRAMEBUFFER_CREATE_INFO;
		// 	framebufferInfo[0].renderPass = contextData->RenderPass;
		// 	framebufferInfo[0].attachmentCount = 1;
		// 	framebufferInfo[0].width = contextData->RenderPassArea->extent.width;
		// 	framebufferInfo[0].height = contextData->RenderPassArea->extent.height;
		// 	framebufferInfo[0].layers = 1;
		// 	framebufferInfo[0].pAttachments = &contextData->SwapChainImageViews[i];
		// 	framebufferInfo[0].pNext = null;
		// 	// framebufferInfo[0].flags= (uint)VkFramebufferCreateFlagBits.VK_FRAMEBUFFER_CREATE_IMAGELESS_BIT_KHR;
		// 	framebufferInfo[0].flags = 0;

		// 	result = Vk.vkCreateFramebuffer(contextData->Device, &framebufferInfo[0], null, &contextData->Framebuffers[i]);//;//.Check("failed to create framebuffer!"); 

		// 	if (VkResult.VK_SUCCESS != result)
		// 	{
		// 		Log.Error($"-{i} Create FrameBuffer {contextData->Framebuffers[i]}");
		// 	}
		// }
	}

	internal static void DisposeSwapChainFramebuffer(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		// if (contextData->Device.IsNotNull && contextData->Framebuffers != null)
		// {
		// 	for (int i = 0; i < contextData->SwapChainImageViewsCount; i++)
		// 	{
		// 		if (contextData->Framebuffers[i].IsNotNull)
		// 		{
		// 			Vk.vkDestroyFramebuffer(contextData->Device, contextData->Framebuffers[i], null);
		// 		}
		// 	}
		// }
	}

	internal static void DisposeSwapChainImages(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		// if (contextData->Device.IsNotNull && contextData->SwapChainImageViews != null)
		// {
		// 	for (uint i = 0; i < contextData->SwapChainImageViewsCount; i++)
		// 	{
		// 		Vk.vkDestroyImageView(contextData->Device, contextData->SwapChainImageViews[i], null);
		// 	}
		// }
	}

	internal static void DisposeSwapChain(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		// if (contextData->Device.IsNotNull && contextData->SwapChain.IsNotNull)
		// {
		// 	Vk.vkDestroySwapchainKHR(contextData->Device, contextData->SwapChain, null);
		// }
	}

	internal static void RecreateSwapchain(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{

	}


}


internal unsafe static class WindowsContextGraphicSync
{


	internal static void DisposeSemaphore(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos) // + renderpass   + syncobj + command
	{

		// if (contextData->Device.IsNotNull && contextData->ImageAvailableSemaphores != null)
		// {
		// 	for (uint i = 0; i < contextData->MaxFrameInFlight; i++)
		// 	{
		// 		if (!contextData->ImageAvailableSemaphores[i].IsNull)
		// 		{
		// 			// Log.Info($"-{i}  dispose Semaphore render Finish : {contextData->ImageAvailableSemaphores[i]}");
		// 			Vk.vkDestroySemaphore(contextData->Device, contextData->ImageAvailableSemaphores[i], null);
		// 		}
		// 	}
		// }

		// if (contextData->Device.IsNotNull && contextData->RenderFinishedSemaphores != null)
		// {
		// 	for (uint i = 0; i < contextData->MaxFrameInFlight; i++)
		// 	{
		// 		if (!contextData->RenderFinishedSemaphores[i].IsNull)
		// 		{
		// 			// Log.Info($"-{i}  dispose Semaphore render Finish : {contextData->RenderFinishedSemaphores[i]}");
		// 			Vk.vkDestroySemaphore(contextData->Device, contextData->RenderFinishedSemaphores[i], null);
		// 		}
		// 	}
		// }	
	}
	
	internal static void DisposeFence(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos) // + renderpass   + syncobj + command
    {
        // if (contextData->Device.IsNotNull && contextData->InFlightFences != null)
        // {
        //     for (uint i = 0; i < contextData->MaxFrameInFlight; i++)
        //     {
        //         if (!contextData->InFlightFences[i].IsNull)
        //         {
        //             // Log.Info($"-{i}  dispose Fence  : {contextData->InFlightFences[i]}");
        //             Vk.vkDestroyFence(contextData->Device, contextData->InFlightFences[i], null);
        //         }
        //     }
        // }
    }
}


internal unsafe static class WindowsContextGraphicCommandAbdBarrier
{

	internal static void CreateSemaphore( WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos ) // + renderpass   + syncobj + command
    {
        VkResult result;

        if (contextData->ImageAvailableSemaphores == null)
            // contextData->ImageAvailableSemaphores = (VkSemaphore*)NativeMemory.Alloc(contextData->MaxFrameInFlight * (uint)Unsafe.SizeOf<VkSemaphore>());
            contextData->ImageAvailableSemaphores = Memory.Memory.NewArray<VkSemaphore>(contextData->MaxFrameInFlight);
        //TODO : change NAtiveMEmor

        if (contextData->RenderFinishedSemaphores == null)
            // contextData->RenderFinishedSemaphores = (VkSemaphore*)NativeMemory.Alloc(contextData->MaxFrameInFlight * (uint)Unsafe.SizeOf<VkSemaphore>());
            contextData->RenderFinishedSemaphores = Memory.Memory.NewArray<VkSemaphore>(contextData->MaxFrameInFlight);

        VkSemaphoreCreateInfo* semaphoreInfo = stackalloc VkSemaphoreCreateInfo[1];
        semaphoreInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_SEMAPHORE_CREATE_INFO;
        semaphoreInfo[0].flags = 0;
        semaphoreInfo[0].pNext = null;

        for (uint i = 0; i < contextData->MaxFrameInFlight; i++)
        {
            result = Vk.vkCreateSemaphore(contextData->Device, &semaphoreInfo[0], null, &contextData->ImageAvailableSemaphores[i]);

            // _ = Log.Check(result != VkResult.VK_SUCCESS, $"-{i}  Create Image Semaphore Available : {contextData->ImageAvailableSemaphores[i]}");

            result = Vk.vkCreateSemaphore(contextData->Device, &semaphoreInfo[0], null, &contextData->RenderFinishedSemaphores[i]);

            // _ = Log.Check(result != VkResult.VK_SUCCESS, $"-{i}  Create Render Semaphore Available : {contextData->RenderFinishedSemaphores[i]}");

        }

        if (contextData->InFlightFences == null)
            // contextData->InFlightFences = (VkFence*)NativeMemory.Alloc(contextData->MaxFrameInFlight * (uint)Unsafe.SizeOf<VkFence>());
            contextData->InFlightFences = Memory.Memory.NewArray<VkFence>(contextData->MaxFrameInFlight);

        VkFenceCreateInfo* fenceInfo = stackalloc VkFenceCreateInfo[1];
        fenceInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_FENCE_CREATE_INFO;
        fenceInfo[0].flags = (uint)VkFenceCreateFlagBits.VK_FENCE_CREATE_SIGNALED_BIT;
        fenceInfo[0].pNext = null;

        for (uint i = 0; i < contextData->MaxFrameInFlight; i++)
        {
            result = Vk.vkCreateFence(contextData->Device, &fenceInfo[0], null, &contextData->InFlightFences[i]);//;//.Check("Failed to create Fence InFlightFence");

            // _ = Log.Check(result != VkResult.VK_SUCCESS, $"-{i}  Create Fence  : {contextData->InFlightFences[i]}");
        }

        VkCommandPoolCreateInfo* poolInfoCompute = stackalloc VkCommandPoolCreateInfo[1];
        poolInfoCompute[0].sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO;
        poolInfoCompute[0].flags = (uint)VkCommandPoolCreateFlagBits.VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT;
        poolInfoCompute[0].queueFamilyIndex = contextData->GraphicQueueIndex;
        poolInfoCompute[0].pNext = null;

        result = Vk.vkCreateCommandPool(contextData->Device, &poolInfoCompute[0], null, &contextData->CommandPool);

        // _ = Log.Check(result != VkResult.VK_SUCCESS, $"Create Command Pool {contextData->CommandPool}") ? 1 : 0;

        if (contextData->CommandBuffers == null)
            contextData->CommandBuffers = Memory.Memory.NewArray<VkCommandBuffer>(contextData->MaxFrameInFlight);
        // contextData->CommandBuffers = (VkCommandBuffer*)NativeMemory.Alloc(contextData->MaxFrameInFlight * (uint)Unsafe.SizeOf<VkCommandBuffer>());

        VkCommandBufferAllocateInfo* allocInfo = stackalloc VkCommandBufferAllocateInfo[1];
        allocInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_BUFFER_ALLOCATE_INFO;
        allocInfo[0].commandPool = contextData->CommandPool;
        allocInfo[0].level = VkCommandBufferLevel.VK_COMMAND_BUFFER_LEVEL_PRIMARY;
        allocInfo[0].commandBufferCount = (uint)contextData->MaxFrameInFlight;
        allocInfo[0].pNext = null;

        result = Vk.vkAllocateCommandBuffers(contextData->Device, &allocInfo[0], contextData->CommandBuffers);

        // _ = Log.Check(result != VkResult.VK_SUCCESS, "Create  Command buffer ") ? 1 : 0;
    }


	internal static void DisposeCommandPool(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos) // + renderpass   + syncobj + command
	{
		// if (contextData->CommandPool.IsNotNull)
		// {
		// 	// Log.Info($"Destroy Command Pool {contextData->CommandPool}");
		// 	Vk.vkDestroyCommandPool(contextData->Device, contextData->CommandPool, null);
		// }
	}
}

internal unsafe static class WindowsContextGraphicRenderPass
{


	internal static void CreateRenderPass(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos) // + renderpass   + syncobj + command
	{
		// // WindowsGraphicRender.CreateShader(contextData);
		// // RENDER PASS AREA 
		// // if 2 joeur split screen 
		// if (contextData->RenderPassClearValues == null)
		//     contextData->RenderPassClearValues = Memory.Memory.NewArray<VkClearValue>(/*depth buffer =2*/ 1);
		// // contextData->RenderPassClearValues = (VkClearValue*)NativeMemory.Alloc(1 * (uint)Unsafe.SizeOf<VkClearValue>());

		// ChangeBackGroundColor(contextData, 4284782061u);

		// // COLOR 
		// VkAttachmentDescription* colorAttachment = stackalloc VkAttachmentDescription[1];

		// colorAttachment[0].format = contextData->SwapChainImageFormat;
		// colorAttachment[0].samples = VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT;
		// colorAttachment[0].loadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_CLEAR;
		// colorAttachment[0].storeOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_STORE;
		// colorAttachment[0].stencilLoadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_DONT_CARE;
		// colorAttachment[0].stencilStoreOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_DONT_CARE;
		// colorAttachment[0].initialLayout = VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED;// TODO when depth buffer
		// colorAttachment[0].finalLayout = VkImageLayout.VK_IMAGE_LAYOUT_PRESENT_SRC_KHR;
		// colorAttachment[0].flags = (uint)VkAttachmentDescriptionFlagBits.VK_ATTACHMENT_DESCRIPTION_MAY_ALIAS_BIT;

		// // SUBPASS  -> COLOR POST PROCESSING       
		// VkAttachmentReference* colorAttachmentRef = stackalloc VkAttachmentReference[1];

		// colorAttachmentRef[0].attachment = 0;
		// colorAttachmentRef[0].layout = VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL;

		// // SUBPASS
		// VkSubpassDescription* subpass = stackalloc VkSubpassDescription[1];

		// subpass[0].pipelineBindPoint = VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS;
		// subpass[0].colorAttachmentCount = 1;
		// subpass[0].pColorAttachments = &colorAttachmentRef[0];
		// subpass[0].pDepthStencilAttachment = null; //&depthAttachmentRef;
		// subpass[0].flags = 0;
		// subpass[0].inputAttachmentCount = 0;
		// subpass[0].pInputAttachments = null;
		// subpass[0].pPreserveAttachments = null;
		// subpass[0].preserveAttachmentCount = 0;
		// subpass[0].pResolveAttachments = null;

		// VkSubpassDependency* dependency = stackalloc VkSubpassDependency[1];

		// dependency[0].srcSubpass = VK.VK_SUBPASS_EXTERNAL;
		// dependency[0].dstSubpass = 0;
		// dependency[0].srcStageMask = (uint)VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT;
		// dependency[0].srcAccessMask = 0;//(uint)VkAccessFlagBits.VK_ACCESS_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT,
		// dependency[0].dstStageMask = (uint)VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT;
		// dependency[0].dstAccessMask = (uint)VkAccessFlagBits.VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT;
		// dependency[0].dependencyFlags = 0;

		// VkRenderPassCreateInfo* renderPassInfo = stackalloc VkRenderPassCreateInfo[1];

		// renderPassInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO;
		// // renderPassInfo[0].pAttachments = attachmentsDesc;
		// renderPassInfo[0].attachmentCount = 1 /*isDepthStencil ? 2 : 1 */;
		// renderPassInfo[0].pAttachments = &colorAttachment[0];
		// renderPassInfo[0].subpassCount = 1;
		// renderPassInfo[0].pSubpasses = &subpass[0];
		// renderPassInfo[0].dependencyCount = 1;
		// renderPassInfo[0].pDependencies = &dependency[0];
		// renderPassInfo[0].flags = 0;
		// renderPassInfo[0].pNext = null;

		// VkResult result = Vk.vkCreateRenderPass(contextData->Device, &renderPassInfo[0], null, &contextData->RenderPass);//;//.Check("failed to create render pass!");

		// // _ = Log.Check(result != VkResult.VK_SUCCESS, $"Create Render Pass : {contextData->RenderPass}") ? 1 : 0;
	}

	internal static void DisposeRenderPass(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos) // + renderpass   + syncobj + command
	{
		// if (contextData->Device.IsNotNull && contextData->RenderPass.IsNotNull)
		// {
		// 	// Log.Info("INFO",$"Destroy Render Pass : {graphicData->RenderPass}");
		// 	Vk.vkDestroyRenderPass(contextData->Device, contextData->RenderPass, null);
		// }

	}

	


}


internal unsafe static partial class WindowsContextGraphicRenderDrawings
{

	static volatile uint currentFrame = 0;

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [UnmanagedCallConv]
    internal static void Draw( WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos )
    {
        // uint* waitStages = stackalloc uint[1] { (uint)VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT | (uint)VkPipelineStageFlagBits.VK_PIPELINE_STAGE_EARLY_FRAGMENT_TESTS_BIT };
        // VkFence CurrentinFlightFence = contextData->InFlightFences[currentFrame];
        // ref VkSemaphore CurrentImageAvailableSemaphore = ref contextData->ImageAvailableSemaphores[currentFrame];
        // ref VkSemaphore CurrentRenderFinishedSemaphore = ref contextData->RenderFinishedSemaphores[currentFrame];
        // VkSemaphore* waitSemaphores = stackalloc VkSemaphore[1] { CurrentImageAvailableSemaphore };
        // VkSemaphore* signalSemaphores = stackalloc VkSemaphore[1] { CurrentRenderFinishedSemaphore };
        // VkSwapchainKHR* swapChains = stackalloc VkSwapchainKHR[1] { contextData->SwapChain };
        // uint CurrentImageIndex = 0;
        // contextData->CurrentCommandBuffer = contextData->CommandBuffers[currentFrame];

        // VkResult result = Vk.vkWaitForFences(contextData->Device, 1, &CurrentinFlightFence, /*VK_TRUE*/1, contextData->Ticktimeout);//;//.Check("Acquire Image");
        // result = Vk.vkResetFences(contextData->Device, 1, &CurrentinFlightFence);
        // //now that we are sure that the commands finished executing, we can safely reset the command buffer to begin recording again.
        // result = Vk.vkResetCommandBuffer(contextData->CommandBuffers[currentFrame], (uint)VkCommandBufferResetFlagBits.VK_COMMAND_BUFFER_RESET_RELEASE_RESOURCES_BIT);
        // //request image from the swapchain =>  // Acquire an index of drawing image for this frame.
        // result = Vk.vkAcquireNextImageKHR(contextData->Device, contextData->SwapChain, contextData->Ticktimeout, CurrentImageAvailableSemaphore, VkFence.Null, &CurrentImageIndex);

        // if (result == VkResult.VK_ERROR_OUT_OF_DATE_KHR)
        // {
        //     // RecreateSwapChain(contextData);
        //     Log.Error("Draw error out of date");
        //     return;
        // }
        // else if (result != VkResult.VK_SUCCESS && result != VkResult.VK_SUBOPTIMAL_KHR)
        // {
        //     return;
        // }

        // RecordCommandBuffer(contextData, CurrentImageIndex);

        // VkSubmitInfo* submitInfo = stackalloc VkSubmitInfo[1];
        // submitInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_SUBMIT_INFO;
        // submitInfo[0].waitSemaphoreCount = 1;
        // submitInfo[0].pWaitSemaphores = waitSemaphores;
        // submitInfo[0].pWaitDstStageMask = waitStages;
        // submitInfo[0].commandBufferCount = 1;
        // submitInfo[0].pCommandBuffers = &contextData->CommandBuffers[currentFrame];
        // submitInfo[0].signalSemaphoreCount = 1;
        // submitInfo[0].pSignalSemaphores = signalSemaphores;
        // submitInfo[0].pNext = null;

        // result = Vk.vkQueueSubmit(contextData->GraphicQueue, 1, &submitInfo[0], CurrentinFlightFence);

        // VkPresentInfoKHR* presentInfo = stackalloc VkPresentInfoKHR[1];
        // presentInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_PRESENT_INFO_KHR;
        // presentInfo[0].waitSemaphoreCount = 1;
        // presentInfo[0].pWaitSemaphores = signalSemaphores;
        // presentInfo[0].pImageIndices = &CurrentImageIndex;
        // presentInfo[0].swapchainCount = 1;
        // presentInfo[0].pSwapchains = swapChains;
        // presentInfo[0].pNext = null;
        // presentInfo[0].pResults = null;

        // result = Vk.vkQueuePresentKHR(contextData->PresentQueue, &presentInfo[0]);

        // if (result == VkResult.VK_ERROR_OUT_OF_DATE_KHR || result == VkResult.VK_SUBOPTIMAL_KHR)
        // {
        //     // RecreateSwapChain(contextData);
        //     return;
        // }
        // else if (result != VkResult.VK_SUCCESS)
        // {
        //     return;
        // }

        // currentFrame = (currentFrame + 1) % contextData->MaxFrameInFlight;
    }

    [UnmanagedCallConv]

    static void RecordCommandBuffer(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos , uint currentImageIndex)
    {
        // int renderPasses = 1;

        // VkCommandBufferBeginInfo* beginInfo = stackalloc VkCommandBufferBeginInfo[1];
        // beginInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_BUFFER_BEGIN_INFO;
        // beginInfo[0].pNext = null;
        // beginInfo[0].flags = (uint)VkCommandBufferUsageFlagBits.VK_COMMAND_BUFFER_USAGE_ONE_TIME_SUBMIT_BIT;
        // beginInfo[0].pInheritanceInfo = null;

        // var result = Vk.vkBeginCommandBuffer(contextData->CommandBuffers[currentFrame], &beginInfo[0]);

        // // FOREACH RENDER PASS 
        // VkRenderPassBeginInfo* renderPassInfo = stackalloc VkRenderPassBeginInfo[renderPasses];

        // for (int i = 0; i < renderPasses; i++)
        // {
        //     renderPassInfo[i].sType = VkStructureType.VK_STRUCTURE_TYPE_RENDER_PASS_BEGIN_INFO;
        //     renderPassInfo[i].pNext = null;
        //     renderPassInfo[i].renderArea = *contextData->RenderPassArea;
        //     renderPassInfo[i].renderPass = contextData->RenderPass;
        //     renderPassInfo[i].framebuffer = contextData->Framebuffers[currentImageIndex];
        //     renderPassInfo[i].clearValueCount = 1;/* contextData->IsUseDepthBuffer ? (uint)2 : (uint)1;*/
        //     renderPassInfo[i].pClearValues = contextData->RenderPassClearValues;

        //     Vk.vkCmdBeginRenderPass(contextData->CommandBuffers[currentFrame], &renderPassInfo[i], VkSubpassContents.VK_SUBPASS_CONTENTS_INLINE);
        //     // Vk.vkCmdBeginRenderPass2(currentCommandBuffer, &renderPassInfo[i], null);

        //     contextData->RenderPipeline();

        //     Vk.vkCmdEndRenderPass(contextData->CommandBuffers[currentFrame]);
        // } // END FOREACH RENDER PASS 

        // result = Vk.vkEndCommandBuffer(contextData->CommandBuffers[currentFrame]);
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
