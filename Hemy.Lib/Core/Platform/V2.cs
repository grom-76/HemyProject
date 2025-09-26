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

using HRESULT = System.Int32;
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
	internal static void CreateFence(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos) // + renderpass   + syncobj + command
	{
		// if (contextData->InFlightFences == null)
		// 	// contextData->InFlightFences = (VkFence*)NativeMemory.Alloc(contextData->MaxFrameInFlight * (uint)Unsafe.SizeOf<VkFence>());
		// 	contextData->InFlightFences = Memory.Memory.NewArray<VkFence>(contextData->MaxFrameInFlight);

		// VkFenceCreateInfo* fenceInfo = stackalloc VkFenceCreateInfo[1];
		// fenceInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_FENCE_CREATE_INFO;
		// fenceInfo[0].flags = (uint)VkFenceCreateFlagBits.VK_FENCE_CREATE_SIGNALED_BIT;
		// fenceInfo[0].pNext = null;

		// for (uint i = 0; i < contextData->MaxFrameInFlight; i++)
		// {
		// 	result = Vk.vkCreateFence(contextData->Device, &fenceInfo[0], null, &contextData->InFlightFences[i]);//;//.Check("Failed to create Fence InFlightFence");

		// 	// _ = Log.Check(result != VkResult.VK_SUCCESS, $"-{i}  Create Fence  : {contextData->InFlightFences[i]}");
		// }

	}

	internal static void CreateSemaphore(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos) // + renderpass   + syncobj + command
	{
		// VkResult result;

		// if (contextData->ImageAvailableSemaphores == null)
		// 	// contextData->ImageAvailableSemaphores = (VkSemaphore*)NativeMemory.Alloc(contextData->MaxFrameInFlight * (uint)Unsafe.SizeOf<VkSemaphore>());
		// 	contextData->ImageAvailableSemaphores = Memory.Memory.NewArray<VkSemaphore>(contextData->MaxFrameInFlight);
		// //TODO : change NAtiveMEmor

		// if (contextData->RenderFinishedSemaphores == null)
		// 	// contextData->RenderFinishedSemaphores = (VkSemaphore*)NativeMemory.Alloc(contextData->MaxFrameInFlight * (uint)Unsafe.SizeOf<VkSemaphore>());
		// 	contextData->RenderFinishedSemaphores = Memory.Memory.NewArray<VkSemaphore>(contextData->MaxFrameInFlight);

		// VkSemaphoreCreateInfo* semaphoreInfo = stackalloc VkSemaphoreCreateInfo[1];
		// semaphoreInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_SEMAPHORE_CREATE_INFO;
		// semaphoreInfo[0].flags = 0;
		// semaphoreInfo[0].pNext = null;

		// for (uint i = 0; i < contextData->MaxFrameInFlight; i++)
		// {
		// 	result = Vk.vkCreateSemaphore(contextData->Device, &semaphoreInfo[0], null, &contextData->ImageAvailableSemaphores[i]);

		// 	// _ = Log.Check(result != VkResult.VK_SUCCESS, $"-{i}  Create Image Semaphore Available : {contextData->ImageAvailableSemaphores[i]}");

		// 	result = Vk.vkCreateSemaphore(contextData->Device, &semaphoreInfo[0], null, &contextData->RenderFinishedSemaphores[i]);

		// 	// _ = Log.Check(result != VkResult.VK_SUCCESS, $"-{i}  Create Render Semaphore Available : {contextData->RenderFinishedSemaphores[i]}");

		// }
		
	}



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

	internal static void CreateCommandPool(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos) // + renderpass   + syncobj + command
	{
		// VkCommandPoolCreateInfo* poolInfoCompute = stackalloc VkCommandPoolCreateInfo[1];
		// poolInfoCompute[0].sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO;
		// poolInfoCompute[0].flags = (uint)VkCommandPoolCreateFlagBits.VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT;
		// poolInfoCompute[0].queueFamilyIndex = contextData->GraphicQueueIndex;
		// poolInfoCompute[0].pNext = null;

		// result = Vk.vkCreateCommandPool(contextData->Device, &poolInfoCompute[0], null, &contextData->CommandPool);

		// _ = Log.Check(result != VkResult.VK_SUCCESS, $"Create Command Pool {contextData->CommandPool}") ? 1 : 0;

	}

	internal static void CreateCommandBuffers(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos) // + renderpass   + syncobj + command
	{
		// if (contextData->CommandBuffers == null)
		// 	contextData->CommandBuffers = Memory.Memory.NewArray<VkCommandBuffer>(contextData->MaxFrameInFlight);
		// // contextData->CommandBuffers = (VkCommandBuffer*)NativeMemory.Alloc(contextData->MaxFrameInFlight * (uint)Unsafe.SizeOf<VkCommandBuffer>());

		// VkCommandBufferAllocateInfo* allocInfo = stackalloc VkCommandBufferAllocateInfo[1];
		// allocInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_BUFFER_ALLOCATE_INFO;
		// allocInfo[0].commandPool = contextData->CommandPool;
		// allocInfo[0].level = VkCommandBufferLevel.VK_COMMAND_BUFFER_LEVEL_PRIMARY;
		// allocInfo[0].commandBufferCount = (uint)contextData->MaxFrameInFlight;
		// allocInfo[0].pNext = null;

		// result = Vk.vkAllocateCommandBuffers(contextData->Device, &allocInfo[0], contextData->CommandBuffers);

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
	internal static void Draw(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
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

	static void RecordCommandBuffer(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos, uint currentImageIndex)
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

	public static void DrawOnlyShader( )
    {
       // if (renderData->State == 0) return;

        // PUSH CONSTANTS ---------- ( do before bin pipeline)
        // fixed(void* ptr = &data->Selected ) 
        // {
        //     Vk.vkCmdPushConstants(data->CurrentCommandBuffer, data->PipelineLayout, 
        //         (uint) VkShaderStageFlagBits.VK_SHADER_STAGE_VERTEX_BIT, 0,PushConstantsBool.SizeInBytes, ptr );
        // }

        // SEND DATA To SHADER UNIFORM
        // fixed ( VkDescriptorSet* desc = &graphicData->ShaderDescribe_DescriptorSets[data->CurrentFrame])
        // {
        //     Vk.vkCmdBindDescriptorSets(graphicData->CurrentCommandBuffer, VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS,data->PipelineLayout, 0, 1, desc, 0, null);
        // }

        // USE SHADER  ENABLE
        // Vk.vkCmdBindPipeline(graphicData->CurrentCommandBuffer, VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS, descriptorData-> Pipeline);

        // SET DYNAMIC STATES
        // descriptorData-> DynamicStateViewport->x = 0.0f;
        // descriptorData-> DynamicStateViewport->y = 0.0f;
        // descriptorData-> DynamicStateViewport->width =  graphicData->RenderPassArea->extent.width;
        // descriptorData-> DynamicStateViewport->height =  graphicData->RenderPassArea->extent.height;
        // descriptorData-> DynamicStateViewport->minDepth = 0.0f;
        // descriptorData-> DynamicStateViewport->maxDepth = 1.0f;
        // Vk.vkCmdSetViewport(graphicData->CurrentCommandBuffer, 0, 1, descriptorData->DynamicStateViewport );

        // descriptorData-> DynamicStateScissor->offset = new() {x=0, y=0};
        // descriptorData-> DynamicStateScissor->extent =graphicData->RenderPassArea->extent ;
        // Vk.vkCmdSetScissor(graphicData->CurrentCommandBuffer, 0, 1, descriptorData->DynamicStateScissor);

        // Vk.vkCmdSetLineWidth( _perFrame.CurrentCommandBuffer,data.Handles.DynamicStatee_LineWidth);

        // BIND VERTEX AND INDICES
        // VkDeviceSize* offsets = stackalloc VkDeviceSize[]{0};
        // VkBuffer* vertexBuffers = stackalloc VkBuffer[] { settings.VertexBuffer};
        // Vk.vkCmdBindVertexBuffers(graphicData->CurrentCommandBuffer, 0, 1, vertexBuffers, offsets);
        // Vk.vkCmdBindIndexBuffer(graphicData->CurrentCommandBuffer, settings.IndicesBuffer, 0, VkIndexType.VK_INDEX_TYPE_UINT16);
        // Vk.vkCmdDrawIndaexed(graphicData->CurrentCommandBuffer, renderData.IndicesSize, 1, 0, 0, 0);

        // Vk.vkCmdDraw(graphicData->CurrentCommandBuffer, descriptorData->VertexCount, descriptorData->InstanceCount, 0, 0);
    }

}


internal unsafe static class WindowsContextGraphicPipelineCreation
{
	internal static void CreatePipeline()
	{
		#region VERTEX DEFINITIONS : ATTRIBUTS & BINDINGS  For SHADERS

		// VkVertexInputBindingDescription bindingDescription = new()
		// {
		//     binding = 0, // layout 
		//     stride = renderData->ShaderData->Vertex_Stride,
		//     inputRate = VkVertexInputRate.VK_VERTEX_INPUT_RATE_VERTEX
		// };

		// // TODO take this info inside Resource File ?

		// VkVertexInputAttributeDescription* attributeDescriptions = stackalloc VkVertexInputAttributeDescription[3];
		// attributeDescriptions[0].binding = 0;
		// attributeDescriptions[0].location = 0;
		// attributeDescriptions[0].format = VkFormat.VK_FORMAT_R32G32B32_SFLOAT;
		// attributeDescriptions[0].offset = renderData->VertexData->Vertex_Offset;

		// attributeDescriptions[1].binding = 0;
		// attributeDescriptions[1].location = 1;
		// attributeDescriptions[1].format = VkFormat.VK_FORMAT_R32G32B32_SFLOAT;
		// attributeDescriptions[1].offset = 3;

		// attributeDescriptions[2].binding = 0;
		// attributeDescriptions[2].location = 2;
		// attributeDescriptions[2].format = VkFormat.VK_FORMAT_R32G32_SFLOAT;
		// attributeDescriptions[2].offset = 3;

		// VkPipelineVertexInputStateCreateInfo vertexInputInfo = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_STATE_CREATE_INFO,
		// 	pNext = null,
		// 	flags = 0,
		// 	vertexBindingDescriptionCount = 0 , //descriptorData->InstanceCount ,
		// 	vertexAttributeDescriptionCount =0  //  descriptorData->VertexCount ,
		// 	// pVertexAttributeDescriptions = renderData->VertexData->HasMesh ? attributeDescriptions : null,
		// 	// pVertexBindingDescriptions = renderData->VertexData->HasMesh ? &bindingDescription : null
		// };

		#endregion

		#region FIXED FUNCTION INPUT ASSEMBLY

		// VkPipelineInputAssemblyStateCreateInfo inputAssembly = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_INPUT_ASSEMBLY_STATE_CREATE_INFO,
		// 	topology = descriptorData->PrimitiveTopology,
		// 	primitiveRestartEnable = VK.VK_FALSE,
		// 	flags = 0,
		// 	pNext = null
		// };

		#endregion

		#region FIXED FUNCTION COLOR bLEndING 

		// VkPipelineColorBlendAttachmentState colorBlendAttachment = new()
		// {
		// 	colorWriteMask = (uint)(VkColorComponentFlagBits.VK_COLOR_COMPONENT_R_BIT | VkColorComponentFlagBits.VK_COLOR_COMPONENT_G_BIT | VkColorComponentFlagBits.VK_COLOR_COMPONENT_B_BIT | VkColorComponentFlagBits.VK_COLOR_COMPONENT_A_BIT),
		// 	blendEnable = VK.VK_FALSE,
		// 	srcColorBlendFactor = VkBlendFactor.VK_BLEND_FACTOR_ZERO,
		// 	srcAlphaBlendFactor = VkBlendFactor.VK_BLEND_FACTOR_ZERO,
		// 	alphaBlendOp = VkBlendOp.VK_BLEND_OP_ADD,
		// 	colorBlendOp = VkBlendOp.VK_BLEND_OP_ADD,
		// 	dstAlphaBlendFactor = VkBlendFactor.VK_BLEND_FACTOR_ZERO,
		// 	dstColorBlendFactor = VkBlendFactor.VK_BLEND_FACTOR_ZERO
		// };

		// VkPipelineColorBlendStateCreateInfo colorBlending = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_COLOR_BLEND_STATE_CREATE_INFO,
		// 	logicOpEnable = VK.VK_FALSE,
		// 	logicOp = VkLogicOp.VK_LOGIC_OP_COPY,
		// 	attachmentCount = 1,
		// 	pAttachments = &colorBlendAttachment,
		// 	flags = 0,
		// 	pNext = null
		// };
		// colorBlending.blendConstants[0] = 0.0f;
		// colorBlending.blendConstants[1] = 0.0f;
		// colorBlending.blendConstants[2] = 0.0f;
		// colorBlending.blendConstants[3] = 0.0f;

		#endregion

		#region FIXED FUNCTION RASTERIZATION

		// VkPipelineRasterizationStateCreateInfo rasterizer = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_CREATE_INFO,
		// 	rasterizerDiscardEnable = VK.VK_FALSE,// config.RasterizerDiscardEnable?  1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
		// 	polygonMode = VkPolygonMode.VK_POLYGON_MODE_FILL,
		// 	lineWidth = 1.0f,
		// 	cullMode = (uint)VkCullModeFlagBits.VK_CULL_MODE_NONE,
		// 	frontFace = VkFrontFace.VK_FRONT_FACE_CLOCKWISE,
		// 	flags = 0,
		// 	pNext = null,
		// 	depthBiasEnable = VK.VK_FALSE,// config.DepthBiasEnable? 1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
		// 								  // depthClampEnable = data->VK_FALSE,// config.DepthClampEnable?  1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
		// 								  // depthBiasClamp = 0.0f,//config.DepthBiasClamp ; // 0.0f;
		// 								  // depthBiasConstantFactor = 1.0f,// config.DepthBiasConstantFactor ;  // 1.0f;
		// 								  // depthBiasSlopeFactor = 1.0f// config.DepthBiasSlopeFactor ;   //1.0f;
		// };

		#endregion

		#region FIXED FUNCTION MULTISAMPLING ( ANTIALIASING ? )

		// VkPipelineMultisampleStateCreateInfo multisampling = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_MULTISAMPLE_STATE_CREATE_INFO,
		// 	pNext = null,
		// 	flags = 0,
		// 	sampleShadingEnable = VK.VK_FALSE,// config.SampleShadingEnable ?  1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
		// 	rasterizationSamples = VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT,
		// 	// alphaToCoverageEnable = data->VK_FALSE,//  config.AlphaToCoverageEnable ? 1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
		// 	// alphaToOneEnable = data->VK_FALSE,//config.AlphaToOneEnable  ?  1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;       
		// 	// minSampleShading = 0.0f,
		// 	// pSampleMask = null
		// };

		#endregion

		#region FIXED FUNCTION DETPH & STENCIL 

		// VkPipelineDepthStencilStateCreateInfo depthStencilStateCreateInfo = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_DEPTH_STENCIL_STATE_CREATE_INFO,
		// 	pNext = null,
		// 	depthTestEnable = VK.VK_FALSE, //graphicData->IsUseDepthBuffer ? VK.VK_TRUE : VK.VK_FALSE,// config.DepthTestEnable ?   1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
		// 	depthWriteEnable = 0, // config.DepthWriteEnable  ?  1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
		// 	depthCompareOp = VkCompareOp.VK_COMPARE_OP_LESS,
		// 	depthBoundsTestEnable = 0,//config.DepthBoundsTestEnable ?  1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
		// 	stencilTestEnable = 0,// config.DepthStencilTestEnable ? 1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
		// 	maxDepthBounds = 1.0f,// config.DepthMaxDepthBounds;
		// 	minDepthBounds = 0.0f,// config.DepthMinDepthBounds;
		// 						  // flags = (uint)VkPipelineDepthStencilStateCreateFlagBits.VK_PIPELINE_DEPTH_STENCIL_STATE_CREATE_RASTERIZATION_ORDER_ATTACHMENT_DEPTH_ACCESS_BIT_ARM
		// };
		// if (graphicData->IsUseDepthBuffer)
		// {

		//     // depthStencilStateCreateInfo.front = config.DepthFront ;
		//     // depthStencilStateCreateInfo.back = config.DepthBack ;
		// }


		#endregion

		#region FIXED FUNCTION DYNAMIC STATE

		// CreateDynamicStates(descriptorData);
		
		// VkPipelineDynamicStateCreateInfo dynamicStateCreateInfo = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_DYNAMIC_STATE_CREATE_INFO,
		// 	pNext = null,
		// 	flags = 0,
		// 	dynamicStateCount = descriptorData->DynamicStatesCount,
		// 	pDynamicStates = descriptorData->DynamicStates
		// };

		#endregion

		#region FIXED FUNCTION VIEWPORT SCISSOR

		// descriptorData-> DynamicStateViewport->x = 0.0f;
        // descriptorData-> DynamicStateViewport->y = 0.0f;
        // descriptorData-> DynamicStateViewport->width =  graphicData->RenderPassArea->extent.width;
        // descriptorData-> DynamicStateViewport->height =  graphicData->RenderPassArea->extent.height;
        // descriptorData-> DynamicStateViewport->minDepth = 0.0f;
        // descriptorData-> DynamicStateViewport->maxDepth = 1.0f;
        // Vk.vkCmdSetViewport(graphicData->CurrentCommandBuffer, 0, 1, descriptorData->DynamicStateViewport );

        // descriptorData-> DynamicStateScissor->offset = new() {x=0, y=0};
        // descriptorData-> DynamicStateScissor->extent =graphicData->RenderPassArea->extent ;
        // Vk.vkCmdSetScissor(graphicData->CurrentCommandBuffer, 0, 1, descriptorData->DynamicStateScissor);

		// VkPipelineViewportStateCreateInfo viewportState = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_STATE_CREATE_INFO,
		// 	flags = 0,
		// 	pNext = null,
		// 	viewportCount = 1,
		// 	pViewports = descriptorData->DynamicStateViewport,
		// 	scissorCount = 1,
		// 	pScissors = descriptorData->DynamicStateScissor
		// };

		#endregion

		#region FIXED FUNCTION TESSLATION 

		// VkPipelineTessellationStateCreateInfo tessellationStateCreateInfo = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_TESSELLATION_STATE_CREATE_INFO,
		// 	pNext = null,
		// 	flags = 0,
		// 	patchControlPoints = 0
		// };

		#endregion

		// VkGraphicsPipelineCreateInfo pipelineInfo = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_CREATE_INFO,
		// 	pNext = null,
		// 	flags = (uint)VkPipelineCreateFlagBits.VK_PIPELINE_CREATE_DISABLE_OPTIMIZATION_BIT,
		// 	renderPass = graphicData->RenderPass,
		// 	subpass = 0,

		// 	pVertexInputState = &vertexInputInfo,
		// 	pInputAssemblyState = &inputAssembly,

		// 	pColorBlendState = &colorBlending,

		// 	pViewportState = &viewportState,

		// 	pRasterizationState = &rasterizer,

		// 	pMultisampleState = &multisampling,

		// 	layout = descriptorData->PipelineLayout,

		// 	pTessellationState = &tessellationStateCreateInfo,

		// 	pDepthStencilState = /*graphicData->IsUseDepthBuffer ? &depthStencilStateCreateInfo : */null,

		// 	pDynamicState = &dynamicStateCreateInfo,

		// 	basePipelineIndex = 0,
		// 	basePipelineHandle = VkPipeline.Null,

		// 	stageCount = descriptorData->ShaderStageCount,
		// 	pStages = descriptorData->shaderStages,
		// };

		// var err = Vk.vkCreateGraphicsPipelines(graphicData->Device, VkPipelineCache.Null, 1, &pipelineInfo, null, &descriptorData->Pipeline);

		// if (err != VkResult.VK_SUCCESS) Log.Error("Create Pipeline");

		// DisposeShaderModules(graphicData, descriptorData);
	}


	internal static void DisposePipeline()
	{
		// if (descriptorData->Pipeline.IsNull) return;

		// // Log.Info("INFO",$"Destroy PIPELINE : {renderData->Pipeline}");
		// Vk.vkDestroyPipeline(graphicData->Device, descriptorData->Pipeline, null);
	}



}


internal unsafe static class GraphicPipelineFixedFunction
{

	internal static void CreateDynamicStates()
	{
		// descriptorData->DynamicStates = Memory.Memory.NewArray<VkDynamicState>(descriptorData->DynamicStatesCount);

		// descriptorData->DynamicStates[0] = VkDynamicState.VK_DYNAMIC_STATE_VIEWPORT;
		// descriptorData->DynamicStates[1] = VkDynamicState.VK_DYNAMIC_STATE_SCISSOR;

		// descriptorData->DynamicStateViewport = Memory.Memory.New<VkViewport>();
		// descriptorData->DynamicStateScissor = Memory.Memory.New<VkRect2D>();
	}

	internal static void DispsoseDynamicStates()
	{
		// Memory.Memory.Dispose(descriptorData->DynamicStates);

		// Memory.Memory.Dispose(descriptorData->DynamicStateScissor);
		// Memory.Memory.Dispose(descriptorData->DynamicStateViewport);
	}




}


internal unsafe static class GraphicPipelineCreationShaders
{
	internal static void CreateShaderModule()
	{
		// string vertexfilename = @"Shader_Base.vert";
		// // string fragmentfilename = @"Shader_Base.vert";

		// string vertexSource = ShadersImpl.VertexBaseShader();
		// // string FragmentSource = ShadersImpl.FragmentBaseShader();

		// using var compilerVertex = new Compiler();

		// compilerVertex.Options.ShaderStage = ShaderKind.GLSL_DefaultVertexShader;
		// compilerVertex.Options.EntryPoint = "main";
		// // compilerVertex.Options.SourceLanguage = SourceLanguage.GLSL;
		// // compilerVertex.Options.TargetEnv = TargetEnvironmentVersion.Vulkan_1_3;
		// // compilerVertex.Options.TargetSpv = SpirVVersion.Version_1_0;

		// CompileResult resultVertex = compilerVertex.Compile(vertexSource, vertexfilename);

		// byte* entryPt = Memory.Memory.NewStr("main");

		// VkShaderModuleCreateInfo* createInfoVert = stackalloc VkShaderModuleCreateInfo[1];

		// createInfoVert[0].sType = VkStructureType.VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO;
		// createInfoVert[0].codeSize = resultVertex.BytesSize;  
		// createInfoVert[0].pCode = (uint*)resultVertex.Bytes;
		// createInfoVert[0].pNext = null;
		// createInfoVert[0].flags = 0;


		// VkShaderModule shaderModule = VkShaderModule.Null;
		// var result = Vk.vkCreateShaderModule(graphicData->Device, &createInfoVert[0], null, &shaderModule);
		// if (result != VkResult.VK_SUCCESS) Log.Error("Vertex ShaderModule ");

		// descriptorData->ShaderModulesVertex = shaderModule ;
	}

	internal static void CreateShaderStage()
	{
		// CreateShaderModuleVertex(graphicData, descriptorData, shaderData);
		// CreateShaderModuleFragment(graphicData, descriptorData, shaderData);

		// descriptorData->shaderStages = Memory.Memory.NewArray<VkPipelineShaderStageCreateInfo>(descriptorData->ShaderStageCount);

		// descriptorData->shaderStages[0] = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO,
		// 	stage = VkShaderStageFlagBits.VK_SHADER_STAGE_VERTEX_BIT,
		// 	module = descriptorData->ShaderModulesVertex,
		// 	pName = descriptorData->Entrypoint,
		// 	flags = 0,
		// 	pNext = null,
		// 	pSpecializationInfo = null
		// };

		// descriptorData->shaderStages[1] = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO,
		// 	stage = VkShaderStageFlagBits.VK_SHADER_STAGE_FRAGMENT_BIT,
		// 	module = descriptorData->ShaderModulesFragment,
		// 	pName = descriptorData->Entrypoint,
		// 	flags = 0,
		// 	pNext = null,
		// 	pSpecializationInfo = null
		// };

	}

	internal static void DisposeShaderModules()
	{

		// if (descriptorData->ShaderModulesFragment.IsNotNull)
		// {
		// 	Vk.vkDestroyShaderModule(graphicData->Device, descriptorData->ShaderModulesFragment, null);
		// 	descriptorData->ShaderModulesFragment = VkShaderModule.Null;
		// }	
		// if (descriptorData->ShaderModulesVertex.IsNotNull)
		// {
		// 	Vk.vkDestroyShaderModule(graphicData->Device, descriptorData->ShaderModulesVertex, null);
		// 	descriptorData->ShaderModulesVertex = VkShaderModule.Null;
		// }

	}

	internal static void DisposeShader()
	{
		// DisposeShaderModules(graphicData, descriptorData);

		// Memory.Memory.Dispose(descriptorData->shaderStages);
	}

	internal static void CreatePipelineLayout()
	//  ref VkDescriptorSetLayout descriptorSetLayout,ref VkPushConstantRange[] push_constants )
	{
		// VkPushConstantRange push_constant;
		// if (shaderData->HasPushConstant)
		// {
		// 	// PUSH CONSTANT
		// 	//this push constant range starts at the beginning
		// 	push_constant.offset = 0;
		// 	//this push constant range takes up the size of a MeshPushConstants struct
		// 	// push_constant.size =  Rita.Lib.Math.Geometry.PushConstantsBool.SizeInBytes ;
		// 	//this push constant range is accessible only in the vertex shader
		// 	push_constant.stageFlags = (uint)VkShaderStageFlagBits.VK_SHADER_STAGE_VERTEX_BIT;
		// }


		// VkPipelineLayoutCreateInfo pipelineLayoutInfo = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_LAYOUT_CREATE_INFO,
		// 	flags = 0,
		// 	pNext = null,
		// 	pSetLayouts =null,// &shaderData->ShaderDescribe_DescriptorSetLayout,
		// 	setLayoutCount =0, //shaderData->DescriptorSetLayoutCount,
		// 	pushConstantRangeCount =0, //shaderData->HasPushConstant ? 1 : (uint)0,    // Optionnel
		// 	pPushConstantRanges = /*shaderData->HasPushConstant ? &push_constant :*/ null
		// };

		// var result = Vk.vkCreatePipelineLayout(graphicData->Device, &pipelineLayoutInfo, null, &descriptorData->PipelineLayout);//.Check ("failed to create pipeline layout!");

		// if (result != VkResult.VK_SUCCESS) Log.Error($"Create Pipeline Layout ");
	}

	internal static void DisposePipelineLayout()// ref VkPipelineLayout pipelineLayout)
	{
		// if (descriptorData->PipelineLayout.IsNull) return;

		// Log.Info("INFO", $"Destroy Pipeline Layout : {descriptorData->PipelineLayout}");
		// Vk.vkDestroyPipelineLayout(graphicData->Device, descriptorData->PipelineLayout, null);
	}

	internal static void CreateDescriptorSets()
	{

		// VkDescriptorSetLayout* layouts = stackalloc VkDescriptorSetLayout[2] { ShaderData->ShaderDescribe_DescriptorSetLayout, ShaderData->ShaderDescribe_DescriptorSetLayout };

		// VkDescriptorSetAllocateInfo allocInfo = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO,
		// 	descriptorPool = ShaderData->ShaderDescribe_DescriptorPool,
		// 	descriptorSetCount = graphicData->MaxFrameInFlight,
		// 	pSetLayouts = layouts,
		// 	pNext = null
		// };

		// Vk.vkAllocateDescriptorSets(graphicData->Device, &allocInfo, ShaderData->ShaderDescribe_DescriptorSets);//.Check("failed to allocate descriptor sets!");

		// VkWriteDescriptorSet* descriptorWrites = Memory.Memory.NewArray<VkWriteDescriptorSet>(1);
		// // uint index = 0;
		// for (int i = 0; i < graphicData->MaxFrameInFlight; i++)
		// {

		// 	// VkDescriptorBufferInfo bufferInfo = new ();
		// 	// bufferInfo.buffer = settings.UniformCameraBuffers[i];
		// 	// bufferInfo.offset = 0;
		// 	// bufferInfo.range = UboVS.SizeInBytes ;// sizeof UNIFORM_MVP

		// 	descriptorWrites[0].sType = VkStructureType.VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET;
		// 	descriptorWrites[0].dstSet = ShaderData->ShaderDescribe_DescriptorSets[i];
		// 	descriptorWrites[0].dstBinding = 0;
		// 	descriptorWrites[0].dstArrayElement = 0;
		// 	descriptorWrites[0].descriptorType = VkDescriptorType.VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER;
		// 	descriptorWrites[0].descriptorCount = 1;
		// 	// descriptorWrites[0].pBufferInfo =&bufferInfo;

		// 	// descriptorWrites[1].sType = VkStructureType.VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET;
		// 	// descriptorWrites[1].dstSet = descriptorSets[i];
		// 	// descriptorWrites[1].dstBinding = 1;
		// 	// descriptorWrites[1].dstArrayElement = 0;
		// 	// descriptorWrites[1].descriptorType =VkDescriptorType.VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER;
		// 	// descriptorWrites[1].descriptorCount = 1;
		// 	// fixed(VkDescriptorImageInfo* iI =  &imageInfo)
		// 	// {
		// 	//     descriptorWrites[1].pImageInfo = iI;
		// 	// }

		// 	Vk.vkUpdateDescriptorSets(graphicData->Device, 1, descriptorWrites, 0, null);

		// }

		// Memory.Memory.DisposeArray(descriptorWrites);

	}

	internal static void DisposeDescriptorSet()
	{
		// if (ShaderData->ShaderDescribe_DescriptorPool.IsNull || ShaderData->ShaderDescribe_DescriptorSets == null) return;

		// for (int i = 0; i < graphicData->MaxFrameInFlight; i++)
		// {
		// 	Vk.vkFreeDescriptorSets(graphicData->Device, ShaderData->ShaderDescribe_DescriptorPool, 0, &ShaderData->ShaderDescribe_DescriptorSets[i]);//.Check("Error Free Descriptor Sets");
		// }
	}

	internal static void CreateDescriptorPool()
	{
		// VkDescriptorPoolSize* poolSizes = stackalloc VkDescriptorPoolSize[(int)1];

		// poolSizes[0].type = VkDescriptorType.VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER;
		// poolSizes[0].descriptorCount = graphicData->MaxFrameInFlight;

		// if TextureActive
		// index--;
		// poolSizes[1].type = VkDescriptorType.VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER;
		// poolSizes[1].descriptorCount =(uint)(config.Render.MAX_FRAMES_IN_FLIGHT);

		// VkDescriptorPoolCreateInfo poolInfo = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_CREATE_INFO,
		// 	poolSizeCount = 1,
		// 	maxSets = graphicData->MaxFrameInFlight,
		// 	pPoolSizes = poolSizes
		// };

		// Vk.vkCreateDescriptorPool(graphicData->Device, &poolInfo, null, &ShaderData->ShaderDescribe_DescriptorPool);//.Check("failed to create descriptor pool!");

		// Log.Info("INFO", $"Create Descriptor Pool : {ShaderData->ShaderDescribe_DescriptorPool}");

	}

	internal static void DisposeDescriptorsPool()
	{
		// if (ShaderData->ShaderDescribe_DescriptorPool.IsNull) return;

		// Log.Info("INFO", $"Destroy Descriptor Pool : {ShaderData->ShaderDescribe_DescriptorPool}");
		// Vk.vkDestroyDescriptorPool(graphicData->Device, ShaderData->ShaderDescribe_DescriptorPool, null);
	}

	internal static void CreateDescriptorSetLayout()
	{
		// VkDescriptorSetLayoutBinding* LayoutBinding = stackalloc VkDescriptorSetLayoutBinding[(int)1];

		// LayoutBinding[0].binding = 0;
		// LayoutBinding[0].descriptorCount = 1;
		// LayoutBinding[0].descriptorType = VkDescriptorType.VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER;
		// LayoutBinding[0].pImmutableSamplers = null;
		// LayoutBinding[0].stageFlags = (uint)VkShaderStageFlagBits.VK_SHADER_STAGE_VERTEX_BIT;

		// VkDescriptorSetLayoutCreateInfo layoutInfo = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO,
		// 	bindingCount = 1, //2;
		// 	pBindings = LayoutBinding
		// };

		// Vk.vkCreateDescriptorSetLayout(graphicData->Device, &layoutInfo, null, &shaderData->ShaderDescribe_DescriptorSetLayout);//.Check("failed to create descriptor set layout!");

		// Log.Info("INFO", $"Create Descriptor Set layout : {shaderData->ShaderDescribe_DescriptorSetLayout}");
	}

	internal static unsafe void DisposeDescriptorSetLayout()
	{
		// if (shaderData->ShaderDescribe_DescriptorSetLayout.IsNull) return;

		// Log.Info("INFO", $"Destroy Descriptor Set layout : {shaderData->ShaderDescribe_DescriptorSetLayout}");
		// Vk.vkDestroyDescriptorSetLayout(graphicData->Device, shaderData->ShaderDescribe_DescriptorSetLayout, null);
	}


}

internal unsafe static class GraphicPipelineCreationTextureCreation
{


}


internal unsafe static class GraphicPipelineCreationVertexCreation
{

	internal static void GetMemoryPropeties(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		// VkPhysicalDeviceMemoryProperties2* mem2 = stackalloc VkPhysicalDeviceMemoryProperties2[1];

		// if (graphicData->DeviceExtensions->IsExist(VK.VK_KHR_GET_PHYSICAL_DEVICE_PROPERTIES_2_EXTENSION_NAME))
		// {
		// 	Vk.vkGetPhysicalDeviceMemoryProperties2KHR(graphicData->DevicePhysical, &mem2);
		// 	graphicData->DeviceMemoryProperties = mem2.memoryProperties;
		// }
		// else
		// {
		// Vk.vkGetPhysicalDeviceMemoryProperties2(graphicData->DevicePhysical, &mem2[0]);
		// graphicData->DeviceMemoryProperties = mem2.memoryProperties;
		// }

		// Vk.vkGetPhysicalDeviceMemoryProperties(graphicData->DevicePhysical, &graphicData->DeviceMemoryProperties);
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

	internal static int Init(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		// const float SpeedOfSound = 345.0f;

		// contextData->AudioModule = GetAudioModuleDLL();
		// if (contextData->AudioModule == nint.Zero)
		// {
		// 	Log.Error("Load XAUDIO2 DLL");
		// 	return 1;
		// }

		// Load(LibraryLoader.GetSymbol, contextData->AudioModule);

		// IXAudio2* Instance = null;
		// var err = XAudio2Create(&Instance, 0, AudioConsts.XAUDIO2_DEFAULT_PROCESSOR);

		// // if ( Instance == null || err != (uint)XAUDIO2_ERRORS.XAUDIO2_SUCESS, "Create Xaudio2 INSTANCE ")) { return 1; }

		// IXAudio2 iXAudio2Temp = new(Instance);
		// contextData->AudioInstance = Memory.Memory.New<IXAudio2>(withCopyInstance: false);//pool->New<IXAudio2>( );
		// Memory.Memory.Copy(Memory.Memory.ToPtr(ref iXAudio2Temp), contextData->AudioInstance, Memory.Memory.Size<IXAudio2>());

		// contextData->Debug = Memory.Memory.New<XAUDIO2_DEBUG_CONFIGURATION>(false);// pool->New<XAUDIO2_DEBUG_CONFIGURATION>( new() );	
		// contextData->Debug->LogThreadID = 0;
		// contextData->Debug->LogFileline = 0;
		// contextData->Debug->LogFunctionName = 0;
		// contextData->Debug->LogTiming = 0;
		// contextData->Debug->TraceMask = AudioConsts.XAUDIO2_LOG_ERRORS | AudioConsts.XAUDIO2_LOG_WARNINGS | AudioConsts.XAUDIO2_LOG_INFO;
		// contextData->Debug->BreakMask = AudioConsts.XAUDIO2_LOG_ERRORS;
		// contextData->AudioInstance->SetDebugConfiguration(contextData->Debug, null);

		// if (contextData->Debug == null) { Log.Error("Create Xaudio2 Debug "); return 1; }

		// // IXAudio2EngineCallback mEngineCallback;
		// // err = contextData->AudioInstance->RegisterForCallbacks( &mEngineCallback );
		// // if ( Log.Check(err != 0, "Create Xaudio2 Debug ")) { return 1; }

		// WAVEFORMATEX waveFormatEx = default;
		// waveFormatEx.nChannels = 2;
		// waveFormatEx.nSamplesPerSec = 0;
		// IXAudio2MasteringVoice* tempMaster = null;
		// err = contextData->AudioInstance->CreateMasteringVoice(&tempMaster, 2, 0, 0, null, null, AudioConsts.AUDIO_STREAM_CATEGORY_GameEffects);

		// if (tempMaster == null) { Log.Error("Create Xaudio2 Master Voice"); return 1; }

		// IXAudio2MasteringVoice iXAudio2MasteringVoice = new(tempMaster);
		// contextData->MasterVoice = Memory.Memory.New<IXAudio2MasteringVoice>(false);
		// Memory.Memory.Copy(Memory.Memory.ToPtr(ref iXAudio2MasteringVoice), contextData->MasterVoice, Memory.Memory.Size<IXAudio2MasteringVoice>());


		// uint channelMask = 0;
		// err = contextData->MasterVoice->GetChannelMask(&channelMask);

		// if (err != 0) { Log.Error("GetChannel MAsk "); return 1; }

		// X3DAUDIO_HANDLE* Handle3D;
		// err = (uint)X3DAudioInitialize(channelMask, SpeedOfSound, &Handle3D);

		// contextData->Handle3D = Handle3D;

		// if (Handle3D == null) { Log.Error("X3D Audio "); return 1; }

		return 0;
	}

	internal static void Dispose(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		// if (audioData->AudioInstance == null) return;

		// if (audioData->MasterVoice != null)
		// 	audioData->MasterVoice->DestroyVoice();

		// var error = audioData->AudioInstance->Release();

		// Memory.Memory.Dispose(audioData->AudioInstance);
		// Memory.Memory.Dispose(audioData->Debug);
		// Memory.Memory.Dispose(audioData->MasterVoice);
		// // Memory.Dispose(audioData->Handle3D); // TODO ne pas faire dispose Pourquoi ?

		// LibraryLoader.Unload(audioData->AudioModule);
	}

	internal static void SetVolume(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos, float value)
	{
		//clamp  value < min ? min : value > max ? max : value
		// audioData->Volume = value;
		// var err = audioData->MasterVoice->SetVolume(value);
		// if (err != 0)
		// 	Log.Error("Set Volume failed");
	}

	internal static void Suspend(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		// if (audioData->AudioInstance == null) return;

		// audioData->AudioInstance->StopEngine();
	}

	internal static void Resume(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		// if (audioData->AudioInstance == null) return;

		// var result = audioData->AudioInstance->StartEngine();
		// if (result != 0)
		// {
		// 	Log.Error("Resume of the audio engine failed; running in 'silent mode");
		// 	//Silent MOde
		// }
	}

	internal static void Reset(WindowsContextDataPerFrame* perframe, WindowsContextDataInfos* infos)
	{
		// if (audioData->AudioInstance != null)
		// 	Dispose(audioData: audioData);

		// Init(audioData);
	}

	static nint GetAudioModuleDLL()
	{
		var AudioModule = WindowsContextSystem.Load(XAudio2_9);

		if (AudioModule != nint.Zero) { return AudioModule; }

		AudioModule = WindowsContextSystem.Load(XAudio2_8);

		if (AudioModule != nint.Zero) { return AudioModule; }

		AudioModule = WindowsContextSystem.Load(XAudio1_7);

		if (AudioModule != nint.Zero) { return AudioModule; }

		return nint.Zero;
	}

	internal const string XAudio2_9 = "XAudio2_9";
	internal const string XAudio2_8 = "XAudio2_8";
	internal const string XAudio1_7 = "XAudio1_7";


	// // TODO replace System.MAth by own method  ( Log10 , Sin POw ASin )
	// public static float XAudio2DecibelsToAmplitudeRatio(float Decibels)
	// 	=> Math.MathFuncs.powf(10.0f, Decibels / 20.0f);

	// /// <summary>
	// /// // Inline function that converts an amplitude ratio value to a decibel value.
	// /// </summary>
	// /// <param name="Volume"></param>
	// /// <returns></returns>
	// public static float XAudio2AmplitudeRatioToDecibels(float Volume)
	// 	=> Volume == 0.0f ? -3.402823466e+38f : 20.0f * Math.MathFuncs.clog10f(Volume);

	// public static float XAudio2SemitonesToFrequencyRatio(float Semitones)
	// 	=> Math.MathFuncs.powf(2.0f, Semitones / 12.0f);

	// public static float XAudio2FrequencyRatioToSemitones(float FrequencyRatio)
	// 	=> 39.86313713864835f * Math.MathFuncs.clog10f(FrequencyRatio);

	// public static float XAudio2CutoffFrequencyToRadians(float CutoffFrequency, uint SampleRate)
	// 	=> (uint)(CutoffFrequency * 6.0f) >= SampleRate ? 1.0f : 2.0f * Math.MathFuncs.sinf((float)3.14159265358979323846 * CutoffFrequency / SampleRate);

	// public static float XAudio2RadiansToCutoffFrequency(float Radians, float SampleRate)
	// 	=> SampleRate * Math.MathFuncs.asinf(Radians / 2.0f) / (float)3.14159265358979323846;

	// public static float XAudio2CutoffFrequencyToOnePoleCoefficient(float CutoffFrequency, uint SampleRate)
	// 	=> (uint)CutoffFrequency >= SampleRate ? 1.0f : 1.0f - Math.MathFuncs.powf(1.0f - (2.0f * CutoffFrequency / SampleRate), 2.0f);


	/// <summary> Creates a new XAudio2 object and returns a pointer to its IXAudio2 interface. </summary>
	// private static delegate* unmanaged[MemberFunction]<IXAudio2**, uint, uint, HRESULT> PFN_XAudio2Create = null;
	private static delegate* unmanaged[MemberFunction]<void**, uint, HRESULT> PFN_CreateAudioReverb = null;
	private static delegate* unmanaged[MemberFunction]<void**, uint, HRESULT> PFN_CreateAudioVolumeMeter = null;
	private static delegate* unmanaged[MemberFunction]<uint, float, X3DAUDIO_HANDLE**, HRESULT> PFN_X3DAudioInitialize = null;
	private static delegate* unmanaged[MemberFunction]<void*, void*, void*, uint, void*, void> PFN_X3DAudioCalculate = null;

	public unsafe delegate nint LoadFunction(nint ptr, string name);

	public static void Load(LoadFunction load, nint module)
	{
		// PFN_XAudio2Create = (delegate* unmanaged[MemberFunction]<IXAudio2**, uint, uint, HRESULT>)load(module, "XAudio2Create");
		PFN_CreateAudioReverb = (delegate* unmanaged[MemberFunction]<void**, uint, HRESULT>)load(module, "CreateAudioReverb");
		PFN_CreateAudioVolumeMeter = (delegate* unmanaged[MemberFunction]<void**, uint, HRESULT>)load(module, "CreateAudioVolumeMeter");
		PFN_X3DAudioInitialize = (delegate* unmanaged[MemberFunction]<uint, float, X3DAUDIO_HANDLE**, HRESULT>)load(module, "X3DAudioInitialize");
		PFN_X3DAudioCalculate = (delegate* unmanaged[MemberFunction]<void*, void*, void*, uint, void*, void>)load(module, "X3DAudioCalculate");

	}

	// XAUDIO2 
	// [SuppressGCTransition]
	// [SkipLocalsInit]
	// [SuppressUnmanagedCodeSecurity]
	// internal static HRESULT XAudio2Create(IXAudio2** ppXAudio2, uint Flags = 0, uint XAudio2Processor = XAUDIO2_DEFAULT_PROCESSOR)
	// 	=> PFN_XAudio2Create(ppXAudio2, Flags, XAudio2Processor);

	// XAUDIO 3D
	[SuppressGCTransition]
	[SkipLocalsInit]
	[SuppressUnmanagedCodeSecurity]
	internal static HRESULT X3DAudioInitialize(uint SpeakerChannelMask, float SpeedOfSound, X3DAUDIO_HANDLE** Instance)
		=> PFN_X3DAudioInitialize(SpeakerChannelMask, SpeedOfSound, Instance);

	// [SuppressGCTransition]
	// [SkipLocalsInit]
	// [SuppressUnmanagedCodeSecurity]
	// internal static void X3DAudioCalculate(X3DAUDIO_HANDLE* Instance, X3DAUDIO_LISTENER* pListener, X3DAUDIO_EMITTER* pEmitter, uint Flags, X3DAUDIO_DSP_SETTINGS* pDSPSettings)
	// 	=> PFN_X3DAudioCalculate(Instance, pListener, pEmitter, Flags, pDSPSettings);

	//XAUDIO2 FX
	[SuppressGCTransition]
	[SkipLocalsInit]
	[SuppressUnmanagedCodeSecurity]
	internal static HRESULT CreateAudioReverb(void** ppApo, uint flags)
		=> PFN_CreateAudioReverb(ppApo, flags);

	[SuppressGCTransition]
	[SkipLocalsInit]
	[SuppressUnmanagedCodeSecurity]
	internal static HRESULT CreateVolumeMeter(void** ppApo, uint flags)
		=> PFN_CreateAudioVolumeMeter(ppApo, flags);

	internal const int XAUDIO2_DEFAULT_PROCESSOR = 0x00000001;
	
	[StructLayout(LayoutKind.Explicit, Size = 20)]
	internal readonly struct X3DAUDIO_HANDLE;


}

	


internal unsafe static class Sound2DCreation
{


}
	internal unsafe static class Sound3DCreation
	{


	}
