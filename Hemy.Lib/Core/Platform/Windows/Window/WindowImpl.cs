#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Window;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using static Hemy.Lib.Core.Platform.Windows.LibrariesName;
using static Hemy.Lib.Core.Platform.Windows.Window.WindowConsts;

using WORD = System.UInt16;
using DWORD = System.UInt32; // A 32-bit unsigned integer. The range is 0 through 4294967295 decimal.
using HRESULT = System.UInt32;
using BOOL = System.Int32;
using Hemy.Lib.Core.Memory;
using Hemy.Lib.Core.Platform.Windows.Monitor;
using Hemy.Lib.Core.Window;


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static partial class WindowImpl
{
 

    internal static uint Init(WindowData* contextData, MonitorData* monitorData, WindowsSettings* info, delegate* unmanaged<void*, uint, uint*, long*, long*> WinMessageProcedure)
    {
        WindowStyle WinStyle =info->Style;

        Str.StringToBytes(contextData->GameName, Str.BytesToString(info->GameName));
        Str.StringToBytes(contextData->EngineName, "Hemy Engine");
        byte* LogoIcon = Str.New("Logo.ico");
        contextData->HInstance = GetModuleHandleA(null);

        var styleEx = WS_EX_LEFT | WS_EX_WINDOWEDGE | WS_EX_APPWINDOW;
        int Left = CW_USEDEFAULT;
        int Top = CW_USEDEFAULT;
        uint Style = Utils.StyleToValue(WinStyle);  // WS_CAPTION | WS_DLGFRAME | WS_BORDER | WS_SYSMENU | WS_THICKFRAME | WS_SIZEFRAME;
        contextData->IsRunning = true;
        contextData->Width = info->PreferredWidth;
        contextData->Height = info->PreferredHeight;

        MonitorImpl.MonitorsInfo(monitorData);

        if (WinStyle == WindowStyle.None)
        {
            styleEx &= ~(uint)WS_EX_WINDOWEDGE;
        }

        if (WinStyle == WindowStyle.Fullscreen)
        {
            contextData->Width = monitorData->ScreenWidth;
            contextData->Height = monitorData->ScreenHeight;
            Left = monitorData->ScreenLeft;
            Top = monitorData->ScreenTop;
            // contextData->WindowState = Consts.SW_SHOWMAXIMIZED;
        }
        else
        {
            AdjustAreaSize(contextData, Left, Top, Style, WinStyle != WindowStyle.Fullscreen || WinStyle != WindowStyle.Fixed);
            CenterWindow(contextData, &Left, &Top);
            // data->WindowState = Consts.SW_SHOWNORMAL;
        }

        WndClassExA* wndClassExA = stackalloc WndClassExA[1];
        wndClassExA->cbSize = (uint)Unsafe.SizeOf<WndClassExA>();
        wndClassExA->style = CS_HREDRAW | CS_VREDRAW | CS_DBLCLKS | CS_OWNDC;
        wndClassExA->WindowPrecedureMessage = WinMessageProcedure;
        wndClassExA->cbClsExtra = 0;
        wndClassExA->cbWndExtra = 0;
        wndClassExA->hIcon = LoadImageA(contextData->HInstance, LogoIcon, WindowConsts.IMAGE_ICON, 0, 0, WindowConsts.LR_DEFAULTSIZE | WindowConsts.LR_LOADFROMFILE);//WIN.LoadIcon(data->HInstance, data->LogoIcon );
        wndClassExA->hCursor = LoadCursorA(null, WindowConsts.IDC_ARROW);
        wndClassExA->hIconSm = null;
        wndClassExA->hbrBackground = ((nint)6 /*COLOR_WINDOW*/).ToPointer();
        wndClassExA->lpszMenuName = null;
        wndClassExA->hInstance = contextData->HInstance;
        wndClassExA->lpszClassName = contextData->EngineName;

        if (RegisterClassExA(wndClassExA) == 0)
        {
            Log.Error("Failed to Register Wnd class");
            return 1;
        }

        contextData->Handle = CreateWindowExA(
            styleEx,
            contextData->EngineName,
            contextData->GameName,
            Style,
            Left, Top,
            contextData->Width, contextData->Height,// <= VIEWPORT
            null, null,
            contextData->HInstance, null);

        Str.Dispose(LogoIcon);

        if (contextData->Handle == null)
        {
            Log.Error("Failed to create Handle");
            return 1;
        }
        return 0;
    }
    
    public unsafe static void UpdateCaptionTitleBar(WindowData* contextData , string title)
    {
		byte* bytes = Str.New(title);
		int result = SetWindowTextA(contextData->Handle , bytes );
		Str.Dispose(bytes);

		if (result == 0)
			Log.Error($"Change caption title to {title}");
    }

    internal static void Dispose(WindowData* contextData)
    {
        Monitor.MonitorImpl.Monitors.Clear();
        Monitor.MonitorImpl.Monitors = null;

        if (contextData->Handle != null)
        {
            if (0 == DestroyWindow(contextData->Handle))
                Log.Warning("Destroy Window  ");
        }

        if (0 == UnregisterClassA(contextData->EngineName, contextData->HInstance))
            Log.Warning("Unregister Window   ");
    }

    [SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
    internal static void Update(WindowData* contextData)
    {
        MSG msg;
        if (PeekMessageA(&msg, null, 0, 0, WindowConsts.PM_REMOVE) > 0)
        {
            _ = TranslateMessage(&msg);
            _ = DispatchMessageA(&msg);

            contextData->IsRunning = msg.message != WM_QUIT;
        }
    }

    internal static void RequestClose(WindowData* contextData)
    {
        if (contextData->IsRunning == false) return;
        
        contextData->IsRunning = false;
        PostQuitMessage(0);
    }

    internal static void Show(WindowData* contextData)
    {
        if (contextData->Handle == null) return;// Debug if hancle  null

        _ = ShowWindow(contextData->Handle, SW_SHOWNORMAL);
        if ( UpdateWindow(contextData->Handle) == 0 ) Log.Warning( "Update Window  ");// Send WM_PAINT ?
        if ( SetForegroundWindow(contextData->Handle) == 0) Log.Warning( "Set Foreground  ");
    }

    
    internal static void Settings(WindowData* windowData, MonitorData* monitorData)
    {
        /*  FIRST INIT CONVERT GENERAL systemSettings TO SPECIFIC DATA/INFO */
        // data->Handle = null;
        // data->GameVersion = Hemy.Core.HemySystem.Version.StrToUint(systemSettings.GameVersion);
        // data->LogoIcon = Mem.NewBytesFromString(systemSettings.LogoIcon);
        // data->GameName = Mem.NewBytesFromString(systemSettings.GameTitle);
        // data->EngineName = Mem.NewBytesFromString(HemySystem.Name);
        // data->EngineVersion = Hemy.Core.HemySystem.Version.StrToUint(HemySystem.Ver);
        // data->HInstance = GetModuleHandleA(null);
        // data->StyleCs = Consts.CS_HREDRAW | Consts.CS_VREDRAW | Consts.CS_DBLCLKS | Consts.CS_OWNDC;
        // data->StyleEx = Consts.WS_EX_LEFT | Consts.WS_EX_LTRREADING | Consts.WS_EX_WINDOWEDGE | Consts.WS_EX_APPWINDOW;
       
        // (data->Width, data->Height) = GraphicsWindowImpl.ResolutionToSize(systemSettings.Resolution);

        // data->Left = Consts.CW_USEDEFAULT;
        // data->Top = Consts.CW_USEDEFAULT;

        // data->Style = GraphicsWindowImpl.StyleToValue(systemSettings.Style);
        // MonitorImpl.MonitorsInfo(monitorData);

        // if (systemSettings.Style == WindowStyle.None)
        // {
        //     data->StyleEx &= ~(uint)Consts.WS_EX_WINDOWEDGE;
        // }

        // if (systemSettings.Style == WindowStyle.Fullscreen)
        // {
        //     data->Width = monitorData->ScreenWidth;
        //     data->Height = monitorData->ScreenHeight;
        //     data->Left = monitorData->ScreenLeft;
        //     data->Top = monitorData->ScreenTop;
        //     data->WindowState = Consts.SW_SHOWMAXIMIZED;
        // }
        // else
        // {
        //     GraphicsWindowImpl.AdjustAreaSize(data, systemSettings.Style != WindowStyle.Fullscreen || systemSettings.Style != WindowStyle.Fixed);
        //     GraphicsWindowImpl.CenterWindow(data);
        //     data->WindowState = Consts.SW_SHOWNORMAL;
        // }
    }

    internal static void AdjustAreaSize(WindowData* contextData, int left, int top, uint style, bool menu)
    {
        RECT rect = new(left, top, contextData->Width + left, contextData->Height + top);
        _ = AdjustWindowRect(&rect, style, menu ? 0 : 1);
        contextData->Width = rect.Right - rect.Left;
        contextData->Height = rect.Bottom - rect.Top;
    }

	internal static void CenterWindow(WindowData* contextData , int* left, int* top )
	{
		int screenX = GetSystemMetrics(WindowConsts.SM_CXSCREEN);
		int screenY = GetSystemMetrics(WindowConsts.SM_CYSCREEN);
		*left = (screenX / 2) - (contextData->Width / 2);
		*top = (screenY / 2) - (contextData->Height / 2);
	}

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial long* DefWindowProcA(void* hWnd, uint Msg, uint* wParam, long* lParam);

    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial void PostQuitMessage(int wRemoveMsg);

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int TranslateMessage(MSG* lpMsg);

    [SkipLocalsInit]
    // // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial long DispatchMessageA(MSG* lpMsg);

    [SkipLocalsInit]
    // // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int PeekMessageA(MSG* lpMsg, void* hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial void* GetModuleHandleA( /*LPCSTR*/ byte* lpModuleName);

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial ushort RegisterClassExA(WndClassExA* unnamedParam1);

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int DestroyWindow(void* hWnd);

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int UnregisterClassA(byte* lpszClassName, void* hWnd);

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial void* CreateWindowExA(uint dwExStyle, byte* lpClassName, byte* lpWindowName, uint dwStyle, int X, int Y, int nWidth, int nHeight, void* hWndParent, void* hMenu, void* hInstance, void* lpParam);

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int ShowWindow(void* hWnd, int nCmdShow);

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int UpdateWindow(void* hWnd);

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial void* LoadCursorA(void* hInstance, int lpCursorName);

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial void* LoadImageA(void* hInstance, byte* lpIconName, uint type, int cx, int cy, uint fuLoad);

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int SetForegroundWindow(void* hWnd);

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial void* SetWindowLongPtrA(void* hWnd, int nIndex, long* dwNewLong);

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int SetWindowPos(void* hWnd, void* hWndInsertAfter, int X, int Y, int CX, int CY, uint uFlags);

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int SetWindowTextA(void* hWnd, /*[NativeTypeName("LPCSTR")]*/ byte* lpString);

    // [LibraryImport(User, SetLastError = false)]
    // private static partial int GetClientRect(void* hWnd, RECT* lpRect);

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int AdjustWindowRect(RECT* lpRect, uint dwStyle, int bMenu);

    [SkipLocalsInit]
    // [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int GetSystemMetrics(int nIndex);

}


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class WindowConsts
{
    internal const int CW_USEDEFAULT = unchecked((int)(0x80000000));
    internal const uint IMAGE_BITMAP = 0;
    internal const uint IMAGE_ICON = 1;
    internal const uint IMAGE_CURSOR = 2;
    internal const uint IMAGE_ENHMETAFILE = 3;

    internal const uint LR_DEFAULTCOLOR = 0x0000;
    internal const uint LR_MONOCHROME = 0x0001;
    internal const uint LR_COLOR = 0x0002;
    internal const uint LR_COPYRETURNORG = 0x0004;
    internal const uint LR_COPYDELETEORG = 0x0008;
    internal const uint LR_LOADFROMFILE = 0x0010;
    internal const uint LR_LOADTRANSPARENT = 0x0020;
    internal const uint LR_DEFAULTSIZE = 0x0040;

    internal const int IDI_APPLICATION = 32512;
    internal const int IDI_HAND = 32513;
    internal const int IDI_EXCLAMATION = 32515;
    internal const int IDI_ASTERISK = 32516;

    internal const int IDC_ARROW = 32512;

    internal const int GWL_WNDPROC = -4;
    internal const int GWL_HINSTANCE = -6;
    internal const int GWL_HWNDPARENT = -8;
    internal const int GWL_STYLE = -16;
    internal const int GWL_EXSTYLE = -20;
    internal const int GWL_USERDATA = -21;
    internal const int GWL_ID = -12;

    internal const nint HWND_BOTTOM = 1;// Places la fenêtre située en bas de l’ordre Z. Si le paramètre hWnd identifie une fenêtre la plus haute, la fenêtre perd sa status supérieure et est placée au bas de toutes les autres fenêtres.
    internal const nint HWND_NOTOPMOST = -2;// Places la fenêtre au-dessus de toutes les fenêtres non supérieures (c’est-à-dire derrière toutes les fenêtres les plus haut). Cet indicateur n’a aucun effet si la fenêtre est déjà une fenêtre non supérieure.
    internal const nint HWND_TOP = 0;// Places la fenêtre située en haut de l’ordre Z.
    internal const nint HWND_TOPMOST = -1;// Places la fenêtre au-dessus de toutes les fenêtres non supérieures. La fenêtre conserve sa position la plus haute, même lorsqu’elle est désactivée.

    internal const uint SWP_NOZORDER = 0x0004;
    internal const uint SWP_NOREDRAW = 0x0008;
    internal const uint SWP_NOACTIVATE = 0x0010;
    internal const uint SWP_FRAMECHANGED = 0x0020;
    internal const uint SWP_SHOWWINDOW = 0x0040;
    internal const uint SWP_HIDEWINDOW = 0x0080;
    internal const uint SWP_NOOWNERZORDER = 0x0200;
    internal const uint SWP_NOSENDCHANGING = 0x0400;
    internal const uint SWP_DRAWFRAME = SWP_FRAMECHANGED;
    internal const uint SWP_NOREPOSITION = SWP_NOOWNERZORDER;

    internal const int SM_CXSCREEN = 0;  // 0x00
    internal const int SM_CYSCREEN = 1;  // 0x0

    internal const uint PM_REMOVE = 0x0001;

    internal const uint CS_VREDRAW = 0x0001;
    internal const uint CS_HREDRAW = 0x0002;
    internal const uint CS_DBLCLKS = 0x0008;
    internal const uint CS_OWNDC = 0x0020;
    internal const uint CS_CLASSDC = 0x0040;
    internal const uint CS_PARENTDC = 0x0080;
    internal const uint CS_NOCLOSE = 0x0200;
    internal const uint CS_SAVEBITS = 0x0800;
    internal const uint CS_BYTEALIGNCLIENT = 0x1000;
    internal const uint CS_BYTEALIGNWINDOW = 0x2000;
    internal const uint CS_GLOBALCLASS = 0x4000;
    internal const uint CS_IME = 0x00010000;
    internal const uint CS_DROPSHADOW = 0x00020000;

    internal const uint WS_EX_None = 0;
    internal const uint WS_EX_LEFT = WS_EX_None;
    internal const uint WS_EX_LTRREADING = WS_EX_None;
    internal const uint WS_EX_RIGHTSCROLLBAR = WS_EX_None;
    internal const uint WS_EX_DLGMODALFRAME = 0x00000001;
    internal const uint WS_EX_NOPARENTNOTIFY = 0x00000004;
    internal const uint WS_EX_TOPMOST = 0x00000008;
    internal const uint WS_EX_ACCEPTFILES = 0x00000010;
    internal const uint WS_EX_TRANSPARENT = 0x00000020;
    internal const uint WS_EX_MDICHILD = 0x00000040;
    internal const uint WS_EX_TOOLWINDOW = 0x00000080;
    internal const uint WS_EX_WINDOWEDGE = 0x00000100;
    internal const uint WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST;
    internal const uint WS_EX_CLIENTEDGE = 0x00000200;
    internal const uint WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE;
    internal const uint WS_EX_CONTEXTHELP = 0x00000400;
    internal const uint WS_EX_RIGHT = 0x00001000;
    internal const uint WS_EX_RTLREADING = 0x00002000;
    internal const uint WS_EX_LEFTSCROLLBAR = 0x00004000;
    internal const uint WS_EX_WCONTROLPARENT = 0x00010000;
    internal const uint WS_EX_STATICEDGE = 0x00020000;
    internal const uint WS_EX_APPWINDOW = 0x00040000;
    internal const uint WS_EX_LAYERED = 0x00080000;
    internal const uint WS_EX_NOINHERITLAYOUT = 0x00100000;
    internal const uint WS_EX_LAYOUTRTL = 0x00400000;
    internal const uint WS_EX_COMPOSITED = 0x02000000;
    internal const uint WS_EX_NOACTIVATE = 0x08000000;

    internal const int SW_HIDE = 0;
    internal const int SW_SHOWNORMAL = 1;
    internal const int SW_NORMAL = 1;
    internal const int SW_SHOWMINIMIZED = 2;
    internal const int SW_SHOWMAXIMIZED = 3;
    internal const int SW_MAXIMIZE = 3;
    internal const int SW_SHOWNOACTIVATE = 4;
    internal const int SW_SHOW = 5;
    internal const int SW_MINIMIZE = 6;
    internal const int SW_SHOWMINNOACTIVE = 7;
    internal const int SW_SHOWNA = 8;
    internal const int SW_RESTORE = 9;
    internal const int SW_SHOWDEFAULT = 10;
    internal const int SW_FORCEMINIMIZE = 11;

    internal const uint WS_OVERLAPPED = 0x0;
    internal const uint WS_MAXIMIZEBOX = 0x10000;
    internal const uint WS_TABSTOP = WS_MAXIMIZEBOX;
    internal const uint WS_GROUP = 0x20000;
    internal const uint WS_MINIMIZEBOX = WS_GROUP;
    internal const uint WS_SIZEFRAME = 0x40000;
    internal const uint WS_SYSMENU = 0x80000;
    internal const uint WS_HSCROLL = 0x100000;
    internal const uint WS_VSCROLL = 0x200000;
    internal const uint WS_DLGFRAME = 0x400000;
    internal const uint WS_BORDER = 0x800000;
    internal const uint WS_CAPTION = WS_DLGFRAME | WS_BORDER;
    internal const uint WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_SIZEFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX;
    internal const uint WS_MAXIMIZE = 0x1000000;
    internal const uint WS_CLIPCHILDREN = 0x2000000;
    internal const uint WS_CLIPSIBLINGS = 0x4000000;
    internal const uint WS_DISABLED = 0x8000000;
    internal const uint WS_VISIBLE = 0x10000000;
    internal const uint WS_MINIMIZE = 0x20000000;
    internal const uint WS_CHILD = 0x40000000;
    internal const uint WS_POPUP = 0x80000000u;
    internal const uint WS_THICKFRAME = 0x00040000;
    internal const uint WS_POPUPWINDOW = WS_POPUP | WS_BORDER | WS_SYSMENU;
    internal const uint WS_TILED = WS_OVERLAPPED;
    internal const uint WS_ICONIC = WS_MINIMIZE;
    internal const uint WS_SIZEBOX = WS_THICKFRAME;
    internal const uint WS_TILEDWINDOW = WS_OVERLAPPEDWINDOW;

    internal const uint WM_INPUT = 0x00FF;
    internal const uint WM_ACTIVATE = 0x0006;
    internal const uint WM_ACTIVATEAPP = 0x001C;
    internal const uint WM_AFXFIRST = 0x0360;
    internal const uint WM_AFXLAST = 0x037F;
    internal const uint WM_APP = 0x8000;
    internal const uint WM_ASKCBFORMATNAME = 0x030C;
    internal const uint WM_CANCELJOURNAL = 0x004B;
    internal const uint WM_CANCELMODE = 0x001F;
    internal const uint WM_CAPTURECHANGED = 0x0215;
    internal const uint WM_CHANGECBCHAIN = 0x030D;
    internal const uint WM_CHANGEUISTATE = 0x0127;
    internal const uint WM_CHAR = 0x0102;
    internal const uint WM_CHARTOITEM = 0x002F;
    internal const uint WM_CHILDACTIVATE = 0x0022;
    internal const uint WM_CLEAR = 0x0303;
    internal const uint WM_CLOSE = 0x0010;
    internal const uint WM_CLIPBOARDUPDATE = 0x031D;
    internal const uint WM_COMMAND = 0x0111;
    internal const uint WM_COMPACTING = 0x0041;
    internal const uint WM_COMPAREITEM = 0x0039;
    internal const uint WM_CONTEXTMENU = 0x007B;
    internal const uint WM_COPY = 0x0301;
    internal const uint WM_COPYDATA = 0x004A;
    internal const uint WM_CREATE = 0x0001;
    internal const uint WM_CTLCOLORBTN = 0x0135;
    internal const uint WM_CTLCOLORDLG = 0x0136;
    internal const uint WM_CTLCOLOREDIT = 0x0133;
    internal const uint WM_CTLCOLORLISTBOX = 0x0134;
    internal const uint WM_CTLCOLORMSGBOX = 0x0132;
    internal const uint WM_CTLCOLORSCROLLBAR = 0x0137;
    internal const uint WM_CTLCOLORSTATIC = 0x0138;
    internal const uint WM_CUT = 0x0300;
    internal const uint WM_DEADCHAR = 0x0103;
    internal const uint WM_DELETEITEM = 0x002D;
    internal const uint WM_DESTROY = 0x0002;
    internal const uint WM_DESTROYCLIPBOARD = 0x0307;
    internal const uint WM_DEVICECHANGE = 0x0219;
    internal const uint WM_DEVMODECHANGE = 0x001B;
    internal const uint WM_DISPLAYCHANGE = 0x007E;
    internal const uint WM_DRAWCLIPBOARD = 0x0308;
    internal const uint WM_DRAWITEM = 0x002B;
    internal const uint WM_DROPFILES = 0x0233;
    internal const uint WM_ENABLE = 0x000A;
    internal const uint WM_ENDSESSION = 0x0016;
    internal const uint WM_ENTERIDLE = 0x0121;
    internal const uint WM_ENTERMENULOOP = 0x0211;
    internal const uint WM_ENTERSIZEMOVE = 0x0231;
    internal const uint WM_ERASEBKGND = 0x0014;
    internal const uint WM_EXITMENULOOP = 0x0212;
    internal const uint WM_EXITSIZEMOVE = 0x0232;
    internal const uint WM_FONTCHANGE = 0x001D;
    internal const uint WM_GETDLGCODE = 0x0087;
    internal const uint WM_GETFONT = 0x0031;
    internal const uint WM_GETHOTKEY = 0x0033;
    internal const uint WM_GETICON = 0x007F;
    internal const uint WM_GETMINMAXINFO = 0x0024;
    internal const uint WM_GETOBJECT = 0x003D;
    internal const uint WM_GETTEXT = 0x000D;
    internal const uint WM_GETTEXTLENGTH = 0x000E;
    internal const uint WM_HANDHELDFIRST = 0x0358;
    internal const uint WM_HANDHELDLAST = 0x035F;
    internal const uint WM_HELP = 0x0053;
    internal const uint WM_HOTKEY = 0x0312;
    internal const uint WM_HSCROLL = 0x0114;
    internal const uint WM_HSCROLLCLIPBOARD = 0x030E;
    internal const uint WM_ICONERASEBKGND = 0x0027;
    internal const uint WM_IME_CHAR = 0x0286;
    internal const uint WM_IME_COMPOSITION = 0x010F;
    internal const uint WM_IME_COMPOSITIONFULL = 0x0284;
    internal const uint WM_IME_CONTROL = 0x0283;
    internal const uint WM_IME_ENDCOMPOSITION = 0x010E;
    internal const uint WM_IME_KEYDOWN = 0x0290;
    internal const uint WM_IME_KEYLAST = 0x010F;
    internal const uint WM_IME_KEYUP = 0x0291;
    internal const uint WM_IME_NOTIFY = 0x0282;
    internal const uint WM_IME_REQUEST = 0x0288;
    internal const uint WM_IME_SELECT = 0x0285;
    internal const uint WM_IME_SETCONTEXT = 0x0281;
    internal const uint WM_IME_STARTCOMPOSITION = 0x010D;
    internal const uint WM_INITDIALOG = 0x0110;
    internal const uint WM_INITMENU = 0x0116;
    internal const uint WM_INITMENUPOPUP = 0x0117;
    internal const uint WM_INPUTLANGCHANGE = 0x0051;
    internal const uint WM_INPUTLANGCHANGEREQUEST = 0x0050;
    internal const uint WM_KEYDOWN = 0x0100;
    internal const uint WM_KEYFIRST = 0x0100;
    internal const uint WM_KEYLAST = 0x0108;
    internal const uint WM_KEYUP = 0x0101;
    internal const uint WM_KILLFOCUS = 0x0008;
    internal const uint WM_LBUTTONDBLCLK = 0x0203;
    internal const uint WM_LBUTTONDOWN = 0x0201;
    internal const uint WM_LBUTTONUP = 0x0202;
    internal const uint WM_MBUTTONDBLCLK = 0x0209;
    internal const uint WM_MBUTTONDOWN = 0x0207;
    internal const uint WM_MBUTTONUP = 0x0208;
    internal const uint WM_MDIACTIVATE = 0x0222;
    internal const uint WM_MDICASCADE = 0x0227;
    internal const uint WM_MDICREATE = 0x0220;
    internal const uint WM_MDIDESTROY = 0x0221;
    internal const uint WM_MDIGETACTIVE = 0x0229;
    internal const uint WM_MDIICONARRANGE = 0x0228;
    internal const uint WM_MDIMAXIMIZE = 0x0225;
    internal const uint WM_MDINEXT = 0x0224;
    internal const uint WM_MDIREFRESHMENU = 0x0234;
    internal const uint WM_MDIRESTORE = 0x0223;
    internal const uint WM_MDISETMENU = 0x0230;
    internal const uint WM_MDITILE = 0x0226;
    internal const uint WM_MEASUREITEM = 0x002C;
    internal const uint WM_MENUCHAR = 0x0120;
    internal const uint WM_MENUCOMMAND = 0x0126;
    internal const uint WM_MENUDRAG = 0x0123;
    internal const uint WM_MENUGETOBJECT = 0x0124;
    internal const uint WM_MENURBUTTONUP = 0x0122;
    internal const uint WM_MENUSELECT = 0x011F;
    internal const uint WM_MOUSEACTIVATE = 0x0021;
    internal const uint WM_MOUSEFIRST = 0x0200;
    internal const uint WM_MOUSEHOVER = 0x02A1;
    internal const uint WM_MOUSELAST = 0x020D;
    internal const uint WM_MOUSELEAVE = 0x02A3;
    internal const uint WM_MOUSEMOVE = 0x0200;
    internal const uint WM_MOUSEWHEEL = 0x020A;
    internal const uint WM_MOUSEHWHEEL = 0x020E;
    internal const uint WM_MOVE = 0x0003;
    internal const uint WM_MOVING = 0x0216;
    internal const uint WM_NCACTIVATE = 0x0086;
    internal const uint WM_NCCALCSIZE = 0x0083;
    internal const uint WM_NCCREATE = 0x0081;
    internal const uint WM_NCDESTROY = 0x0082;
    internal const uint WM_NCHITTEST = 0x0084;
    internal const uint WM_NCLBUTTONDBLCLK = 0x00A3;
    internal const uint WM_NCLBUTTONDOWN = 0x00A1;
    internal const uint WM_NCLBUTTONUP = 0x00A2;
    internal const uint WM_NCMBUTTONDBLCLK = 0x00A9;
    internal const uint WM_NCMBUTTONDOWN = 0x00A7;
    internal const uint WM_NCMBUTTONUP = 0x00A8;
    internal const uint WM_NCMOUSEHOVER = 0x02A0;
    internal const uint WM_NCMOUSELEAVE = 0x02A2;
    internal const uint WM_NCMOUSEMOVE = 0x00A0;
    internal const uint WM_NCPAINT = 0x0085;
    internal const uint WM_NCRBUTTONDBLCLK = 0x00A6;
    internal const uint WM_NCRBUTTONDOWN = 0x00A4;
    internal const uint WM_NCRBUTTONUP = 0x00A5;
    internal const uint WM_NCXBUTTONDBLCLK = 0x00AD;
    internal const uint WM_NCXBUTTONDOWN = 0x00AB;
    internal const uint WM_NCXBUTTONUP = 0x00AC;
    internal const uint WM_NCUAHDRAWCAPTION = 0x00AE;
    internal const uint WM_NCUAHDRAWFRAME = 0x00AF;
    internal const uint WM_NEXTDLGCTL = 0x0028;
    internal const uint WM_NEXTMENU = 0x0213;
    internal const uint WM_NOTIFY = 0x004E;
    internal const uint WM_NOTIFYFORMAT = 0x0055;
    internal const uint WM_NULL = 0x0000;
    internal const uint WM_PAINT = 0x000F;
    internal const uint WM_PAINTCLIPBOARD = 0x0309;
    internal const uint WM_PAINTICON = 0x0026;
    internal const uint WM_PALETTECHANGED = 0x0311;
    internal const uint WM_PALETTEISCHANGING = 0x0310;
    internal const uint WM_PARENTNOTIFY = 0x0210;
    internal const uint WM_PASTE = 0x0302;
    internal const uint WM_PENWINFIRST = 0x0380;
    internal const uint WM_PENWINLAST = 0x038F;
    internal const uint WM_POWER = 0x0048;
    internal const uint WM_POWERBROADCAST = 0x0218;
    internal const uint WM_PRINT = 0x0317;
    internal const uint WM_PRINTCLIENT = 0x0318;
    internal const uint WM_QUERYDRAGICON = 0x0037;
    internal const uint WM_QUERYENDSESSION = 0x0011;
    internal const uint WM_QUERYNEWPALETTE = 0x030F;
    internal const uint WM_QUERYOPEN = 0x0013;
    internal const uint WM_QUEUESYNC = 0x0023;
    internal const uint WM_QUIT = 0x0012;
    internal const uint WM_RBUTTONDBLCLK = 0x0206;
    internal const uint WM_RBUTTONDOWN = 0x0204;
    internal const uint WM_RBUTTONUP = 0x0205;
    internal const uint WM_RENDERALLFORMATS = 0x0306;
    internal const uint WM_RENDERFORMAT = 0x0305;
    internal const uint WM_SETCURSOR = 0x0020;
    internal const uint WM_SETFOCUS = 0x0007;
    internal const uint WM_SETFONT = 0x0030;
    internal const uint WM_SETHOTKEY = 0x0032;
    internal const uint WM_SETICON = 0x0080;
    internal const uint WM_SETREDRAW = 0x000B;
    internal const uint WM_SETTEXT = 0x000C;
    internal const uint WM_SETTINGCHANGE = 0x001A;
    internal const uint WM_SHOWWINDOW = 0x0018;
    internal const uint WM_SIZE = 0x0005;
    internal const uint WM_SIZECLIPBOARD = 0x030B;
    internal const uint WM_SIZING = 0x0214;
    internal const uint WM_SPOOLERSTATUS = 0x002A;
    internal const uint WM_STYLECHANGED = 0x007D;
    internal const uint WM_STYLECHANGING = 0x007C;
    internal const uint WM_SYNCPAINT = 0x0088;
    internal const uint WM_SYSCHAR = 0x0106;
    internal const uint WM_SYSCOLORCHANGE = 0x0015;
    internal const uint WM_SYSCOMMAND = 0x0112;
    internal const uint WM_SYSDEADCHAR = 0x0107;
    internal const uint WM_SYSKEYDOWN = 0x0104;
    internal const uint WM_SYSKEYUP = 0x0105;
    internal const uint WM_TCARD = 0x0052;
    internal const uint WM_TIMECHANGE = 0x001E;
    internal const uint WM_TIMER = 0x0113;
    internal const uint WM_UNDO = 0x0304;
    internal const uint WM_UNINITMENUPOPUP = 0x0125;
    internal const uint WM_USER = 0x0400;
    internal const uint WM_USERCHANGED = 0x0054;
    internal const uint WM_VKEYTOITEM = 0x002E;
    internal const uint WM_VSCROLL = 0x0115;
    internal const uint WM_VSCROLLCLIPBOARD = 0x030A;
    internal const uint WM_WINDOWPOSCHANGED = 0x0047;
    internal const uint WM_WINDOWPOSCHANGING = 0x0046;
    internal const uint WM_WININICHANGE = 0x001A;
    internal const uint WM_XBUTTONDBLCLK = 0x020D;
    internal const uint WM_XBUTTONDOWN = 0x020B;
    internal const uint WM_XBUTTONUP = 0x020C;
}


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

[StructLayout(LayoutKind.Sequential)]
internal struct WndClassExA
{
    internal uint cbSize;
    internal uint style;
    internal unsafe delegate* unmanaged<void* /*hWnd*/, uint /*msg*/, uint* /*wParam*/, long* /*lpParam*/, long* /*LRESULT*/> WindowPrecedureMessage;
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

[StructLayout(LayoutKind.Sequential)]
internal struct POINT(int x, int y)
{
    internal int X = x;
    internal int Y = y;
}

[StructLayout(LayoutKind.Sequential)]
internal struct RECT(int left, int top, int right, int bottom)
{
    /// <summary>
    /// X
    /// </summary>
    internal int Left = left;
    /// <summary>
    /// Y
    /// </summary>
    internal int Top = top;
    /// <summary>
    /// Width
    /// </summary>
    internal int Right = right;
    /// <summary>
    /// Height 
    /// </summary>
    internal int Bottom = bottom;

    internal int X { readonly get => Left; set => Left = value; }
    internal int Y { readonly get => Top; set => Top = value; }
    internal int Width { readonly get => Right; set => Right = value; }
    internal int Height { readonly get =>Bottom; set => Bottom = value; }

}



#endif
