namespace Hemy.Lib.V2.Platform.Windows;

using System;

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
using System.Diagnostics.Contracts;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static unsafe class WindowsUtils
{

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static void FillBytesWithString(byte* bytes, string text,int offset =0, int size = 1024 )
	{
		while (offset <= text.Length && offset <= size)
		{
			*(bytes + offset) = unchecked((byte)(text[offset++] & 0x7f));
		}
		*(bytes + offset) = 0;// dans le cas ou il n'y ait pas de zero en fin de chaine calloc
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
internal static unsafe class WindowsWindowCommon
{

	[SkipLocalsInit]
	[StructLayout(LayoutKind.Sequential)]
	internal struct Hwnd;

	internal const uint STATE_INIT = 1;
	internal const uint STATE_RUNNING = 2;
	internal const uint STATE_DISPOSED = 3;
	internal const uint STATE_QUIT = 4;
	internal const int NO_ERROR = 0;
	internal const int ERROR = 1;

	internal static readonly byte[] WM_ARRAY =
	[   0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 50
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 100
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 150
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 200
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 300
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 400
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 500
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 600
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 700
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 800
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 900
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 1000
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 1100
	];
	
}

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal unsafe readonly struct WindowsEvents( WindowsData* windowData  ) : Events.IEvents // = Settings +Data + Infos  
{

	[MethodImpl((MethodImplOptions)768), SkipLocalsInit, SuppressGCTransition, SuppressUnmanagedCodeSecurity]
	public readonly bool IsRunning()
		=> windowData->State == 1 && windowData->Error == 0;

	[MethodImpl((MethodImplOptions)768), SkipLocalsInit, SuppressGCTransition, SuppressUnmanagedCodeSecurity]
	public readonly void RequestClose()
		=> Windows.WindowsEventsImpl.RequestClose(&windowData->State);
}

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static partial class WindowsEventsImpl
{
	[SkipLocalsInit][SuppressGCTransition][SuppressUnmanagedCodeSecurity]
	internal static void Update(uint* state)
	{
		MSG msg;
		if (PeekMessageA(&msg, null, 0, 0, PM_REMOVE) > 0)
		{
			_ = TranslateMessage(&msg);
			_ = DispatchMessageA(&msg);

			*state = msg.message != WM_QUIT ? WindowsWindowCommon.STATE_RUNNING : WindowsWindowCommon.STATE_QUIT;
		}
	}

	[SkipLocalsInit][SuppressGCTransition][SuppressUnmanagedCodeSecurity]
	internal static void RequestClose(uint* state)
	{
		if (*state == 0) return;

		*state = 1;
		PostQuitMessage(0);
	}

	private const uint PM_REMOVE = 0x0001;
	internal const uint WM_QUIT = 0x0012;
	internal const uint WM_CLOSE = 0x0010;
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
internal unsafe static partial class WindowsWindowImpl
{
	internal const string Kernel = "kernel32";// https://www.geoffchappell.com/studies/windows/win32/kernel32/api/index.htm
	internal const string User = "user32";// https://learn.microsoft.com/en-us/windows/win32/api/winuser/

	internal static int CreateWindowSettings(WindowsData* infos)
	{

		// WindowStyle WinStyle =infos->Style;
		// Str.StringToBytes(contextData->GameName, Str.BytesToString(info->GameName));
		// Str.StringToBytes(contextData->EngineName, "Hemy Engine");
		// byte* LogoIcon = Str.New("Logo.ico");
		// contextData->HInstance = GetModuleHandleA(null);
		WindowsUtils.FillBytesWithString(infos->LogoIcon, "LogoIcon");

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

	internal static int CreateWindow(WindowsData* infos, delegate* unmanaged[Stdcall, SuppressGCTransition]<void*, uint, uint*, long*, long*> WinMessageProcedure)
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

		if (RegisterClassExA(wndClassExA) == 0) { return 1; }

		infos->WindowHandle = CreateWindowExA(
			styleEx,
			infos->EngineName,
			infos->GameName,
			infos->Style,
			unchecked((int)(0x80000000)),
			unchecked((int)(0x80000000)),//Top,
			infos->Width, infos->Height,// <= VIEWPORT
			null, null,
			infos->HInstance, null);

		return infos->WindowHandle == null ? 1 : 0;
	}

	internal static int DisposeWindow(WindowsData* infos)
	{

		if (infos->WindowHandle != null)
		{
			if (0 == DestroyWindow(infos->WindowHandle))
				return 1;
		}

		if (0 == UnregisterClassA(infos->EngineName, infos->HInstance))
			return 1;
		return 0;
	}

	internal static void ShowWindow(WindowsData* infos)
	{
		if (infos->WindowHandle == null) return;// Debug if hancle  null

		_ = ShowWindow(infos->WindowHandle, 5);
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
		internal unsafe delegate* unmanaged[Stdcall, SuppressGCTransition]<Hwnd* /*hWnd*/, uint /*msg*/, uint* /*wParam*/, long* /*lpParam*/, long* /*LRESULT*/> WindowPrecedureMessage;
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
