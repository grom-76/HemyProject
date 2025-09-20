#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Monitor;

using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static Hemy.Lib.Core.Platform.Windows.LibrariesName;
using WORD = System.UInt16;
using DWORD = System.UInt32; // A 32-bit unsigned integer. The range is 0 through 4294967295 decimal.
using HRESULT = System.UInt32;
using BOOL = System.Int32;
using LONG = System.Int32;
using System.Security;
using System.Collections.Generic;
using Hemy.Lib.Core.Platform.Windows.Window;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static partial class MonitorImpl
{
    internal static delegate*<void*, void*, RECT*, long*, BOOL> MONITORENUMPROC = null;

    internal struct MonitorMode(int id, DEVMODEW devmod)
    {
        public int Mode = id;
        public int Width = devmod.dmPelsWidth;
        public int Height = devmod.dmPelsHeight;
        public int BitDepth = devmod.dmBitsPerPel;
        public int Frequency = devmod.dmDisplayFrequency;

    }
    //Log.Info($"Mode {iMode}: {devmod.dmPelsWidth}x{devmod.dmPelsHeight}, {devmod.dmBitsPerPel} bits, {devmod.dmDisplayFrequency} Hz");

    internal struct Monitor(MONITORINFOEX monitorInfo )
    {
        string DeviceName = new (monitorInfo.DeviceName);
        public uint Flags = monitorInfo.Flags;
        public int Width = monitorInfo.Monitor.Right;
        public int Height = monitorInfo.Monitor.Bottom;
        public int Left = monitorInfo.Monitor.Left;
        public int Top = monitorInfo.Monitor.Top;
        public int WorkAreaRight = monitorInfo.Work.Right;
        public int WorkAreaBottom =  monitorInfo.Work.Bottom;
        public int WorkAreaLeft =  monitorInfo.Work.Left;
        public int WorkAreaTop =  monitorInfo.Work.Top;
        public List<MonitorMode> Modes = [];

    }

    internal static List<Monitor> Monitors = [] ;

    private static int MonitorEnumProc(void* hMonitor, void* hdcMonitor, RECT* lprcMonitor, long* dwData)
    {
        MONITORINFOEX monitorInfo = new MONITORINFOEX();
        monitorInfo.Size = MONITORINFOEX.SizeInBytes; //Marshal.SizeOf(typeof(MONITORINFOEX));
        int res = GetMonitorInfoW((void*)hMonitor, &monitorInfo);
        if (res != 0)
        {
            // string deviceName = new(monitorInfo.DeviceName);

            // Log.Info($"Monitor: {deviceName}, Resolution: Resolution: {monitorInfo.Monitor.Right}x{monitorInfo.Monitor.Bottom}, Position: {monitorInfo.Monitor.Left},{monitorInfo.Monitor.Top}");
            Monitor m = new(monitorInfo);

            // GET VIDEOS MODES 
            DEVMODEW devmod = new();
            devmod.dmSize = DEVMODEW.SizeInBytes;
            int iMode = 0;
            do
            {
                res = EnumDisplaySettingsW((char*)monitorInfo.DeviceName, iMode, &devmod);
                if (res != 0)
                {
                    // Log.Info($"Mode {iMode}: {devmod.dmPelsWidth}x{devmod.dmPelsHeight}, {devmod.dmBitsPerPel} bits, {devmod.dmDisplayFrequency} Hz");
                    m.Modes.Add(new(iMode, devmod));
                }
                iMode++;
            } while (res != 0);

            Monitors.Add(m);
        }

        return 1;
    }

    internal unsafe static void MonitorsInfo(MonitorData* monitorData)
    {
        // LIST ALL MONITORS
        _ = EnumDisplayMonitors(null, null, &MonitorEnumProc, null);

        void* hdc = GetDC(null);
        monitorData->ScreenHeight = GetDeviceCaps(hdc, (int)MonitorConsts.VERTRES);
        int PhysicalScreenHeight = GetDeviceCaps(hdc, (int)MonitorConsts.DESKTOPVERTRES);
        monitorData->ScreenWidth = GetDeviceCaps(hdc, (int)MonitorConsts.HORZRES);
        int PhysicalScreenWidth = GetDeviceCaps(hdc, (int)MonitorConsts.DESKTOPHORZRES);

        float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)monitorData->ScreenHeight;
        // _ = Log.Check(ScreenScalingFactor != 1.0f, "Scaling factor != 100% ");
        // int Xdpi = GetDeviceCaps(hdc, (int)MonitorConsts.LOGPIXELSX);
        // int Ydpi = GetDeviceCaps(hdc, (int)MonitorConsts.LOGPIXELSY);
        if (1 != ReleaseDC(null, hdc)){
            Log.Error("Error Release DC ");    
        }
    }

    internal static void RestoreVideoMode(byte* adapterName, bool* modeChanged)
    {
        if (*modeChanged)
        {
            ChangeDisplaySettingsExW(adapterName, null, null, MonitorConsts.CDS_FULLSCREEN, null);
            *modeChanged = false;
        }
    }

    internal unsafe static void GetMonitorViewport(MonitorData* monitorData, void* windowHandle)
    {
        var monitor = MonitorFromWindow(windowHandle, MonitorConsts.MONITOR_DEFAULTTONEAREST);

        if (monitor != null)
        {
            MONITORINFOEX monitorInfo = new MONITORINFOEX();
            _ = GetMonitorInfoW(monitor, &monitorInfo);

            monitorData->ScreenLeft = monitorInfo.Monitor.Left;
            monitorData->ScreenTop = monitorInfo.Monitor.Top;
            monitorData->ScreenWidth = (monitorInfo.Monitor.Right - monitorInfo.Monitor.Left);
            monitorData->ScreenHeight = (monitorInfo.Monitor.Bottom - monitorInfo.Monitor.Top);
        }
    }

    public unsafe static void SetFullscreen(MonitorData* monitorData)
    {
        // src : https://github.com/FaberSanZ/Xultaik/blob/main/Src/Xultaik.Desktop/Window.cs

        // long FullScreenStyle = Consts.WS_VISIBLE | graphicsData->Style;
        // _ = SetWindowLongPtrA(graphicsData->Handle, Consts.GWL_STYLE, &FullScreenStyle);
        // _ = SetWindowPos(graphicsData->Handle, (void*)Consts.HWND_TOP,
        //     graphicsData->ScreenLeft, graphicsData->ScreenTop,
        //     graphicsData->ScreenWidth,
        //     graphicsData->ScreenHeight,
        //     Consts.SWP_NOZORDER | Consts.SWP_FRAMECHANGED | Consts.SWP_SHOWWINDOW | Consts.SWP_DRAWFRAME);
    }


    /// <summary>
    /// // To make SetForegroundWindow work as we want, we need to fiddle
    ///    // with the FOREGROUNDLOCKTIMEOUT system setting (we do this as early
    ///    // as possible in the hope of still being the foreground process)
    /// </summary>
    /// <param name="foregroundLockTimeout"></param>
    public static void SetForeground(void* foregroundLockTimeout)
    {
        _ = SystemParametersInfoA((int)MonitorConsts.SPI_GETFOREGROUNDLOCKTIMEOUT, 0, foregroundLockTimeout, 0);
        _ = SystemParametersInfoA((int)MonitorConsts.SPI_SETFOREGROUNDLOCKTIMEOUT, 0, (void*)0, MonitorConsts.SPIF_SENDCHANGE);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="hwnd"></param>       
    public static void SetDpiAwarness(void* handle)
    {
        _ = SetProcessDPIAware();
        _ = SetProcessDpiAwareness(MonitorConsts.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE);
        var ptr = GetWindowDpiAwarenessContext(handle);
        _ = SetProcessDpiAwarenessContext(ptr - 4);
    }

    public static void OnMonitorChange(MonitorData* monitorData)
    {
                        //    _glfwPollMonitorsWin32();
    }


    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial int GetSystemMetrics(int nIndex);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial BOOL GetMonitorInfoW(void* hMonitor, MONITORINFOEX* lpmi);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial BOOL EnumDisplaySettingsW(char* deviceName, int modeNum, DEVMODEW* devMode);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial BOOL EnumDisplayMonitors(/*HDC*/void* hdc, RECT* lprcClip, delegate*<void*, void*, RECT*, long*, BOOL> lpfnEnum, long* dwData);

    [SkipLocalsInit] 
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial BOOL SetProcessDpiAwarenessContext(nuint value);

    [SkipLocalsInit] 
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial BOOL SetProcessDPIAware();

    [SkipLocalsInit] 
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial BOOL SystemParametersInfoA(uint uiAction, uint uiParam, void* pvParam, uint fWinIni);

    [SkipLocalsInit] 
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial BOOL SystemParametersInfoW(uint uiAction, uint uiParam, void* pvParam, uint fWinIni);

    [SkipLocalsInit] 
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial BOOL SystemParametersInfoForDpi(uint uiAction, uint uiParam, void* pvParam, uint fWinIni, uint dpi);

    [SkipLocalsInit] 
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial nuint GetWindowDpiAwarenessContext(void* hWnd);

    [SkipLocalsInit] 
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial int GetDpiForWindow(void* hWnd);

    [SkipLocalsInit] 
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial int GetAwarenessFromDpiAwarenessContext(void* dpiContext);

    [SkipLocalsInit] 
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial /*BOOL*/ int AreDpiAwarenessContextsEqual(void* dpiContextA, void* dpiContextB);

    [SkipLocalsInit] 
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(SHCore, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial BOOL SetProcessDpiAwareness(nuint awareness);

    [SkipLocalsInit] 
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(SHCore, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial void GetProcessDpiAwareness(void* hprocess, out nuint awareness);

    [SkipLocalsInit] 
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial void* MonitorFromWindow(void* handle, DWORD flags);

    // [SkipLocalsInit] 
    // [SuppressGCTransition]
    // [SuppressUnmanagedCodeSecurity]
    // [LibraryImport(User, SetLastError = false)]
    // internal static partial void* MonitorFromPoint(POINT p, DWORD dwflags);

    // [SkipLocalsInit] 
    // [SuppressGCTransition]
    // [SuppressUnmanagedCodeSecurity]
    // [LibraryImport(User, SetLastError = false)]
    // internal static partial void* MonitorFromRect(RECT* lprc, DWORD dwflags);

    [SkipLocalsInit] 
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial int ReleaseDC(void* hWnd, void* hDC);

    [SkipLocalsInit] 
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial void* GetDC(void* hWnd);

    [SkipLocalsInit] 
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Gdi, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial int GetDeviceCaps(void* hdc, int nIndex);

    // [LibraryImport(User, SetLastError = false)]
    // internal static partial int AdjustWindowRect(ref RECT lpRect, int dwStyle, int bMenu);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial LONG ChangeDisplaySettingsExW(byte* lpszDeviceName, DEVMODEW* lpDevMode, void* hwnd, DWORD dwflags, void* lParam);

}

internal static class MonitorConsts
{
    public const int ENUM_CURRENT_SETTINGS = -1;
    public const int ENUM_REGISTRY_SETTINGS = -2;

    // dwFlags of EnumDisplaySettingsEx (default is 0)
    public const uint EDS_RAWMODE = 0x00000002;
    public const uint EDS_ROTATEDMODE = 0x00000004;

    // dwflags of ChangeDisplaySettingsEx (default is 0)
    public const uint CDS_UPDATEREGISTRY = 0x00000001;
    public const uint CDS_TEST = 0x00000002;
    public const uint CDS_FULLSCREEN = 0x00000004;
    public const uint CDS_GLOBAL = 0x00000008;
    public const uint CDS_SET_PRIMARY = 0x00000010;
    public const uint CDS_VIDEOPARAMETERS = 0x00000020;
    public const uint CDS_ENABLE_UNSAFE_MODES = 0x00000100;
    public const uint CDS_DISABLE_UNSAFE_MODES = 0x00000200;
    public const uint CDS_RESET = 0x40000000;
    public const uint CDS_RESET_EX = 0x20000000;
    public const uint CDS_NORESET = 0x10000000;

    // Result of ChangeDisplaySettingsEx
    public const int DISP_CHANGE_SUCCESSFUL = 0;   // The settings change was successful.
    public const int DISP_CHANGE_RESTART = 1;      // The computer must be restarted for the graphics mode to work.
    public const int DISP_CHANGE_FAILED = -1;      // The display driver failed the specified graphics mode.
    public const int DISP_CHANGE_BADMODE = -2;     // The graphics mode is not supported.
    public const int DISP_CHANGE_NOTUPDATED = -3;  // Unable to write settings to the registry.
    public const int DISP_CHANGE_BADFLAGS = -4;    // An invalid set of flags was passed in.
    public const int DISP_CHANGE_BADPARAM = -5;    // An invalid parameter was passed in. This can include an invalid flag or combination of flags.
    public const int DISP_CHANGE_BADDUALVIEW = -6; // The settings change was unsuccessful because the system is DualView capable.

    public const int SPIF_SENDCHANGE = 0x02;
    public const int SPI_NONE = 0;
    public const int SPI_ONE = 1;
    public const int SPI_GETFOREGROUNDLOCKTIMEOUT = 0x2000;
    public const int SPI_SETFOREGROUNDLOCKTIMEOUT = SPI_ONE | SPI_GETFOREGROUNDLOCKTIMEOUT;

    public static nuint DPI_AWARENESS_CONTEXT_UNAWARE = unchecked((nuint)(-1));
    public static nuint DPI_AWARENESS_CONTEXT_SYSTEM_AWARE = unchecked((nuint)(-2));
    public static nuint DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE = unchecked((nuint)(-3));
    public static nuint DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2 = unchecked((nuint)(-4));
    public static nuint DPI_AWARENESS_CONTEXT_UNAWARE_GDISCALED = unchecked((nuint)(-5));


    /// <summary>
    /// Device driver version
    /// </summary>
    public const int DRIVERVERSION = 0;
    /// <summary>
    /// Device classification
    /// </summary>
    public const int TECHNOLOGY = 2;
    /// <summary>
    /// Horizontal size in millimeters
    /// </summary>
    public const int HORZSIZE = 4;
    /// <summary>
    /// Vertical size in millimeters
    /// </summary>
    public const int VERTSIZE = 6;
    /// <summary>
    /// Horizontal width in pixels
    /// </summary>
    public const int HORZRES = 8;
    /// <summary>
    /// Vertical height in pixels
    /// </summary>
    public const int VERTRES = 10;
    /// <summary>
    /// Number of bits per pixel
    /// </summary>
    public const int BITSPIXEL = 12;
    /// <summary>
    /// Number of planes
    /// </summary>
    public const int PLANES = 14;
    /// <summary>
    /// Number of brushes the device has
    /// </summary>
    public const int NUMBRUSHES = 16;
    /// <summary>
    /// Number of pens the device has
    /// </summary>
    public const int NUMPENS = 18;
    /// <summary>
    /// Number of markers the device has
    /// </summary>
    public const int NUMMARKERS = 20;
    /// <summary>
    /// Number of fonts the device has
    /// </summary>
    public const int NUMFONTS = 22;
    /// <summary>
    /// Number of colors the device supports
    /// </summary>
    public const int NUMCOLORS = 24;
    /// <summary>
    /// Size required for device descriptor
    /// </summary>
    public const int PDEVICESIZE = 26;
    /// <summary>
    /// Curve capabilities
    /// </summary>
    public const int CURVECAPS = 28;
    /// <summary>
    /// Line capabilities
    /// </summary>
    public const int LINECAPS = 30;
    /// <summary>
    /// Polygonal capabilities
    /// </summary>
    public const int POLYGONALCAPS = 32;
    /// <summary>
    /// Text capabilities
    /// </summary>
    public const int TEXTCAPS = 34;
    /// <summary>
    /// Clipping capabilities
    /// </summary>
    public const int CLIPCAPS = 36;
    /// <summary>
    /// Bitblt capabilities
    /// </summary>
    public const int RASTERCAPS = 38;
    /// <summary>
    /// Length of the X leg
    /// </summary>
    public const int ASPECTX = 40;
    /// <summary>
    /// Length of the Y leg
    /// </summary>
    public const int ASPECTY = 42;
    /// <summary>
    /// Length of the hypotenuse
    /// </summary>
    public const int ASPECTXY = 44;
    /// <summary>
    /// Shading and Blending caps
    /// </summary>
    public const int SHADEBLENDCAPS = 45;

    /// <summary>
    /// Logical pixels inch in X
    /// </summary>
    public const int LOGPIXELSX = 88;
    /// <summary>
    /// Logical pixels inch in Y
    /// </summary>
    public const int LOGPIXELSY = 90;

    /// <summary>
    /// Number of entries in physical palette
    /// </summary>
    public const int SIZEPALETTE = 104;
    /// <summary>
    /// Number of reserved entries in palette
    /// </summary>
    public const int NUMRESERVED = 106;
    /// <summary>
    /// Actual color resolution
    /// </summary>
    public const int COLORRES = 108;

    // Printing related DeviceCaps. These replace the appropriate Escapes
    /// <summary>
    /// Physical Width in device units
    /// </summary>
    public const int PHYSICALWIDTH = 110;
    /// <summary>
    /// Physical Height in device units
    /// </summary>
    public const int PHYSICALHEIGHT = 111;
    /// <summary>
    /// Physical Printable Area x margin
    /// </summary>
    public const int PHYSICALOFFSETX = 112;
    /// <summary>
    /// Physical Printable Area y margin
    /// </summary>
    public const int PHYSICALOFFSETY = 113;
    /// <summary>
    /// Scaling factor x
    /// </summary>
    public const int SCALINGFACTORX = 114;
    /// <summary>
    /// Scaling factor y
    /// </summary>
    public const int SCALINGFACTORY = 115;

    /// <summary>
    /// Current vertical refresh rate of the display device (for displays only) in Hz
    /// </summary>
    public const int VREFRESH = 116;
    /// <summary>
    /// Vertical height of entire desktop in pixels
    /// </summary>
    public const int DESKTOPVERTRES = 117;
    /// <summary>
    /// Horizontal width of entire desktop in pixels
    /// </summary>
    public const int DESKTOPHORZRES = 118;
    /// <summary>
    /// Preferred blt alignment
    /// </summary>
    public const int BLTALIGNMENT = 119;


    public const uint MONITOR_DEFAULTTONULL = 0x00000000; //Returns NULL.
    public const uint MONITOR_DEFAULTTOPRIMARY = 0x00000001; //Returns a handle to the primary display monitor.
    public const uint MONITOR_DEFAULTTONEAREST = 0x00000002; // Returns a handle to the display monitor that is nearest to the point.


    public const int GWL_WNDPROC = -4;
    public const int GWL_HINSTANCE = -6;
    public const int GWL_HWNDPARENT = -8;
    public const int GWL_STYLE = -16;
    public const int GWL_EXSTYLE = -20;
    public const int GWL_USERDATA = -21;
    public const int GWL_ID = -12;

    public const nint HWND_BOTTOM = 1;// Places la fenêtre située en bas de l’ordre Z. Si le paramètre hWnd identifie une fenêtre la plus haute, la fenêtre perd sa status supérieure et est placée au bas de toutes les autres fenêtres.
    public const nint HWND_NOTOPMOST = -2;// Places la fenêtre au-dessus de toutes les fenêtres non supérieures (c’est-à-dire derrière toutes les fenêtres les plus haut). Cet indicateur n’a aucun effet si la fenêtre est déjà une fenêtre non supérieure.
    public const nint HWND_TOP = 0;// Places la fenêtre située en haut de l’ordre Z.
    public const nint HWND_TOPMOST = -1;// Places la fenêtre au-dessus de toutes les fenêtres non supérieures. La fenêtre conserve sa position la plus haute, même lorsqu’elle est désactivée.

    public const uint SWP_NOSIZE = 0x0001;
    public const uint SWP_NOMOVE = 0x0002;
    public const uint SWP_NOZORDER = 0x0004;
    public const uint SWP_NOREDRAW = 0x0008;
    public const uint SWP_NOACTIVATE = 0x0010;
    public const uint SWP_FRAMECHANGED = 0x0020;
    public const uint SWP_SHOWWINDOW = 0x0040;
    public const uint SWP_HIDEWINDOW = 0x0080;
    public const uint SWP_NOCOPYBITS = 0x0100;
    public const uint SWP_NOOWNERZORDER = 0x0200;
    public const uint SWP_NOSENDCHANGING = 0x0400;
    public const uint SWP_DRAWFRAME = SWP_FRAMECHANGED;
    public const uint SWP_NOREPOSITION = SWP_NOOWNERZORDER;
    public const uint SWP_DEFERERASE = 0x2000;
    public const uint SWP_ASYNCWINDOWPOS = 0x4000;


    public const int SM_CXSCREEN = 0;  // 0x00
    public const int SM_CYSCREEN = 1;  // 0x01
    public const int SM_CXVSCROLL = 2;  // 0x02
    public const int SM_CYHSCROLL = 3;  // 0x03
    public const int SM_CYCAPTION = 4;  // 0x04
    public const int SM_CXBORDER = 5;  // 0x05
    public const int SM_CYBORDER = 6;  // 0x06
    public const int SM_CXDLGFRAME = 7;  // 0x07
    public const int SM_CXFIXEDFRAME = 7;  // 0x07
    public const int SM_CYDLGFRAME = 8;  // 0x08
    public const int SM_CYFIXEDFRAME = 8;  // 0x08
    public const int SM_CYVTHUMB = 9;  // 0x09
    public const int SM_CXHTHUMB = 10; // 0x0A
    public const int SM_CXICON = 11; // 0x0B
    public const int SM_CYICON = 12; // 0x0C
    public const int SM_CXCURSOR = 13; // 0x0D
    public const int SM_CYCURSOR = 14; // 0x0E
    public const int SM_CYMENU = 15; // 0x0F
    public const int SM_CXFULLSCREEN = 16; // 0x10
    public const int SM_CYFULLSCREEN = 17; // 0x11
    public const int SM_CYKANJIWINDOW = 18; // 0x12
    public const int SM_MOUSEPRESENT = 19; // 0x13
    public const int SM_CYVSCROLL = 20; // 0x14
    public const int SM_CXHSCROLL = 21; // 0x15
    public const int SM_DEBUG = 22; // 0x16
    public const int SM_SWAPBUTTON = 23; // 0x17
    public const int SM_CXMIN = 28; // 0x1C
    public const int SM_CYMIN = 29; // 0x1D
    public const int SM_CXSIZE = 30; // 0x1E
    public const int SM_CYSIZE = 31; // 0x1F
    public const int SM_CXSIZEFRAME = 32; // 0x20
    public const int SM_CXFRAME = 32; // 0x20
    public const int SM_CYSIZEFRAME = 33; // 0x21
    public const int SM_CYFRAME = 33; // 0x21
    public const int SM_CXMINTRACK = 34; // 0x22
    public const int SM_CYMINTRACK = 35; // 0x23
    public const int SM_CXDOUBLECLK = 36; // 0x24
    public const int SM_CYDOUBLECLK = 37; // 0x25
    public const int SM_CXICONSPACING = 38; // 0x26
    public const int SM_CYICONSPACING = 39; // 0x27
    public const int SM_MENUDROPALIGNMENT = 40; // 0x28
    public const int SM_PENWINDOWS = 41; // 0x29
    public const int SM_DBCSENABLED = 42; // 0x2A
    public const int SM_CMOUSEBUTTONS = 43; // 0x2B
    public const int SM_SECURE = 44; // 0x2C
    public const int SM_CXEDGE = 45; // 0x2D
    public const int SM_CYEDGE = 46; // 0x2E
    public const int SM_CXMINSPACING = 47; // 0x2F
    public const int SM_CYMINSPACING = 48; // 0x30
    public const int SM_CXSMICON = 49; // 0x31
    public const int SM_CYSMICON = 50; // 0x32
    public const int SM_CYSMCAPTION = 51; // 0x33
    public const int SM_CXSMSIZE = 52; // 0x34
    public const int SM_CYSMSIZE = 53; // 0x35
    public const int SM_CXMENUSIZE = 54; // 0x36
    public const int SM_CYMENUSIZE = 55; // 0x37
    public const int SM_ARRANGE = 56; // 0x38
    public const int SM_CXMINIMIZED = 57; // 0x39
    public const int SM_CYMINIMIZED = 58; // 0x3A
    public const int SM_CXMAXTRACK = 59; // 0x3B
    public const int SM_CYMAXTRACK = 60; // 0x3C
    public const int SM_CXMAXIMIZED = 61; // 0x3D
    public const int SM_CYMAXIMIZED = 62; // 0x3E
    public const int SM_NETWORK = 63; // 0x3F
    public const int SM_CLEANBOOT = 67; // 0x43
    public const int SM_CXDRAG = 68; // 0x44
    public const int SM_CYDRAG = 69; // 0x45
    public const int SM_SHOWSOUNDS = 70; // 0x46
    public const int SM_CXMENUCHECK = 71; // 0x47
    public const int SM_CYMENUCHECK = 72; // 0x48
    public const int SM_SLOWMACHINE = 73; // 0x49
    public const int SM_MIDEASTENABLED = 74; // 0x4A
    public const int SM_MOUSEWHEELPRESENT = 75; // 0x4B
    public const int SM_XVIRTUALSCREEN = 76; // 0x4C
    public const int SM_YVIRTUALSCREEN = 77; // 0x4D
    public const int SM_CXVIRTUALSCREEN = 78; // 0x4E
    public const int SM_CYVIRTUALSCREEN = 79; // 0x4F
    public const int SM_CMONITORS = 80; // 0x50
    public const int SM_SAMEDISPLAYFORMAT = 81; // 0x51
    public const int SM_IMMENABLED = 82; // 0x52
    public const int SM_CXFOCUSBORDER = 83; // 0x53
    public const int SM_CYFOCUSBORDER = 84; // 0x54
    public const int SM_TABLETPC = 86; // 0x56
    public const int SM_MEDIACENTER = 87; // 0x57
    public const int SM_STARTER = 88; // 0x58
    public const int SM_SERVERR2 = 89; // 0x59
    public const int SM_MOUSEHORIZONTALWHEELPRESENT = 91; // 0x5B
    public const int SM_CXPADDEDBORDER = 92; // 0x5C
    public const int SM_DIGITIZER = 94; // 0x5E
    public const int SM_MAXIMUMTOUCHES = 95; // 0x5F
    public const int SM_REMOTESESSION = 0x1000; // 0x1000
    public const int SM_SHUTTINGDOWN = 0x2000; // 0x2000
    public const int SM_REMOTECONTROL = 0x2001; // 0x2001
    public const int SM_CONVERTABLESLATEMODE = 0x2003;
    public const int SM_SYSTEMDOCKED = 0x2004;
}



[StructLayout(LayoutKind.Sequential)]
internal struct MONITORINFOEX
{
    internal static readonly uint SizeInBytes = (uint)  Unsafe.SizeOf<MONITORINFOEX>();
    internal uint Size ;
    internal RECT Monitor;
    internal RECT Work;
    /// <summary>
    ///  Si = 1 This member can be the following value:   1 : MONITORINFOF_PRIMARY
    /// </summary>
    internal uint Flags;
    internal unsafe fixed char DeviceName[32];
}



[StructLayout(LayoutKind.Sequential)]
internal unsafe struct DEVMODEW
{
    internal const int CCHDEVICENAME = 32;
    internal const int CCHFORMNAME = 32;
    internal static readonly ushort SizeInBytes = (ushort)Unsafe.SizeOf<DEVMODEW>();
    internal fixed ushort dmDeviceName[CCHDEVICENAME];
    internal ushort dmSpecVersion;
    internal ushort dmDriverVersion;
    internal ushort dmSize;
    internal ushort dmDriverExtra;
    internal uint dmFields;
    internal int dmPositionX;
    internal int dmPositionY;
    internal int dmDisplayOrientation;
    internal int dmDisplayFixedOutput;
    internal short dmColor;
    internal short dmDuplex;
    internal short dmYResolution;
    internal short dmTTOption;
    internal short dmCollate;
    internal fixed ushort dmFormName[CCHFORMNAME];
    internal short dmLogPixels;
    internal int dmBitsPerPel;
    internal int dmPelsWidth;
    internal int dmPelsHeight;
    internal int dmDisplayFlags;
    internal int dmDisplayFrequency;
    internal int dmICMMethod;
    internal int dmICMIntent;
    internal int dmMediaType;
    internal int dmDitherType;
    internal int dmReserved1;
    internal int dmReserved2;
    internal int dmPanningWidth;
    internal int dmPanningHeight;
}


#endif