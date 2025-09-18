#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows;


using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using static Hemy.Lib.Core.Platform.Windows.Common.LibrariesName;
using static Hemy.Lib.Core.Platform.Windows.Window.WindowConsts;

using WORD = System.UInt16;
using DWORD = System.UInt32; // A 32-bit unsigned integer. The range is 0 through 4294967295 decimal.
using HRESULT = System.UInt32;
using BOOL = System.Int32;
using Hemy.Lib.Core.Memory;
using Hemy.Lib.Core.Platform.Windows.Monitor;
using Hemy.Lib.Core.Window;
using Hemy.Lib.Core.Input;
using Hemy.Lib.Core.Platform.Windows.Input;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class Utils
{
    internal delegate void EventDelegate(uint* wp, long* lp);

    internal static void EmptyEvent(uint* wp, long* lp) { _ = wp; _ = lp; }

    // internal static long MakeDWord (int lowPart, int highPart) => (long)( (uint)lowPart | (ulong)(highPart << 16));

    // Source for following : https://github.com/Syncaidius/MoltenEngine/blob/master/Molten.Engine/Input/Keyboard/KeyboardEvents.cs 

    /// <summary>Gets the raw window message loop parameter value.</summary>
    internal static long Param(nint lp) => lp.ToInt64();

    /// <summary>Gets the number of times the character has been repeated since the last update.</summary>
    internal static long RepeatCount(nint lParam) => lParam & 0xffff;

    /// <summary>Gets whether or not the character or key is from an extended set.</summary>
    internal static bool ExtendedKey(nint lParam) => (lParam & (1 << 24)) > 0;

    /// <summary>Gets whether or not ALT is held down while the character key is being pressed..</summary>
    internal static bool AltPressed(nint lParam) => (lParam & (1 << 29)) > 0;

    /// <summary>Gets the previous state of the character key (pressed or unpressed).</summary>
    internal static bool PreviousState(nint lParam) => (lParam & (1 << 30)) > 0;

    /// <summary>Gets the transition state of the key. True if being released. False if being pressed.</summary>
    internal static bool TransitionState(nint lParam) => (lParam & (1 << 31)) > 0;

    internal const int MK_SHIFT = 0x0004; // Source : https://github.com/FaberSanZ/Xultaik/blob/main/Src/Xultaik.Desktop/Window.cs

    internal static ushort GET_KEYSTATE_WPARAM(nuint wParam) => (ushort)((wParam) & 0xFFFF);

    internal static ushort GET_XBUTTON_WPARAM(uint* wParam) => HIWORD(wParam);

    internal static int GET_X_LPARAM(long* lParam) => (short)LOWORD((uint*)lParam);

    internal static int GET_Y_LPARAM(long* lParam) => (short)HIWORD((uint*)lParam);

    internal static short GET_WHEEL_DELTA_WPARAM(uint* wPARAM) => (short)HIWORD(wPARAM);

    internal static ushort HIWORD(uint* wParam) => (ushort)((*wParam >> 16) & 0xFFFF);

    internal static ushort LOWORD(uint* wParam) => (ushort)(*wParam & 0xFFFF);


    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl((MethodImplOptions)768)]
    internal static int GET_WIDTH(long* lParam) => (int)lParam & 0xFFFF; //LOWORD

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl((MethodImplOptions)768)]
    internal static int GET_HEIGHT(long* lParam) => (int)lParam >> 16; // HIWORD


    internal static uint StyleToValue(WindowStyle style)
        => style switch
        {
            WindowStyle.standard => WS_CAPTION | WS_DLGFRAME | WS_BORDER | WS_SYSMENU | WS_THICKFRAME | WS_SIZEFRAME,
            WindowStyle.None => WS_OVERLAPPED,
            WindowStyle.Fixed => WS_CAPTION | WS_SYSMENU | WS_OVERLAPPED | WS_MINIMIZEBOX | WS_MAXIMIZEBOX,
            WindowStyle.Sizable => WS_CAPTION | WS_SYSMENU | WS_OVERLAPPED | WS_MINIMIZEBOX | WS_MAXIMIZEBOX | WS_SIZEFRAME,
            WindowStyle.Fullscreen => WS_POPUP,
            _ => 0,
        };


    internal static (int width, int height) ResolutionToSize(WindowResolution resolution)
    => resolution switch
    {
        WindowResolution.FHD_1080p_1920x1080 => new(1920, 1080),
        WindowResolution.HD_720p_1280x720 => new(1280, 720),
        WindowResolution.Megadrive_320x224 => new(320, 224),
        WindowResolution.SVGA_800x600 => new(800, 600),
        WindowResolution.VGA_640x480 => new(640, 480),
        WindowResolution.Fullscreen => new(0, 0),
        WindowResolution.GameBoy_160x144 => new(160, 144),
        WindowResolution.GameGear_160x144 => new(160, 144),
        WindowResolution.QuarterQuarterVGA_160x120 => new(1920, 1080),
        WindowResolution.GameBoyAdvance_160x120 => new(1920, 1080),
        WindowResolution.AtariST_160x100 => new(1920, 1080),
        WindowResolution.AtariLynx_160x102 => new(1920, 1080),
        WindowResolution.GameCube_320x240 => new(1920, 1080),
        WindowResolution.NEOGEOAES_320x224 => new(1920, 1080),
        WindowResolution.SuperNintendo_320x240 => new(1920, 1080),
        WindowResolution.NintendoDS_320x240 => new(1920, 1080),
        WindowResolution.Nintendo64_320x240 => new(1920, 1080),
        WindowResolution.MasterSystem_256x192 => new(1920, 1080),
        WindowResolution.NES_256x224 => new(1920, 1080),
        WindowResolution.QVGA_320x240 => new(1920, 1080),
        WindowResolution.WQVGA_400x240 => new(1920, 1080),
        WindowResolution.CGA_640x200 => new(1920, 1080),
        WindowResolution.WGA_800x480 => new(1920, 1080),
        WindowResolution.WXGA_1280x800 => new(1280, 800),
        WindowResolution._4K_3840x1600 => new(3840, 1600),
        _ => new(800, 600)
    };

  

    internal static Key KeyMapper(uint k)
        => k switch
        {
            VirtualKeys.VK_SPACE => Key.Space,
            VirtualKeys.VK_LBUTTON => Key.LeftButton,
            VirtualKeys.VK_RBUTTON => Key.RightButton,
            VirtualKeys.VK_CANCEL => Key.Cancel,
            VirtualKeys.VK_MBUTTON => Key.MiddleButton,
            VirtualKeys.VK_XBUTTON1 => Key.ExtraButton1,
            VirtualKeys.VK_XBUTTON2 => Key.ExtraButton2,
            VirtualKeys.VK_BACK => Key.Back,
            VirtualKeys.VK_TAB => Key.Tab,
            VirtualKeys.VK_CLEAR => Key.Clear,
            VirtualKeys.VK_RETURN => Key.Return,
            VirtualKeys.VK_SHIFT => Key.Shift,
            VirtualKeys.VK_CONTROL => Key.Control,
            VirtualKeys.VK_MENU => Key.Menu,
            VirtualKeys.VK_PAUSE => Key.Pause,
            VirtualKeys.VK_CAPITAL => Key.CapsLock,
            VirtualKeys.VK_HANGUL => Key.Hangul,
            VirtualKeys.VK_JUNJA => Key.Junja,
            VirtualKeys.VK_FINAL => Key.Final,
            VirtualKeys.VK_KANJI => Key.Kanji,
            VirtualKeys.VK_ESCAPE => Key.Escape,
            VirtualKeys.VK_CONVERT => Key.Convert,
            VirtualKeys.VK_NONCONVERT => Key.NonConvert,
            VirtualKeys.VK_ACCEPT => Key.Accept,
            VirtualKeys.VK_MODECHANGE => Key.ModeChange,
            VirtualKeys.VK_PRIOR => Key.Prior,
            VirtualKeys.VK_NEXT => Key.Next,
            VirtualKeys.VK_END => Key.End,
            VirtualKeys.VK_HOME => Key.Home,
            VirtualKeys.VK_LEFT => Key.Left,
            VirtualKeys.VK_UP => Key.Up,
            VirtualKeys.VK_RIGHT => Key.Right,
            VirtualKeys.VK_DOWN => Key.Down,
            VirtualKeys.VK_SELECT => Key.Select,
            VirtualKeys.VK_PRINT => Key.Print,
            VirtualKeys.VK_EXECUTE => Key.Execute,
            VirtualKeys.VK_SNAPSHOT => Key.Snapshot,
            VirtualKeys.VK_INSERT => Key.Insert,
            VirtualKeys.VK_DELETE => Key.Delete,
            VirtualKeys.VK_HELP => Key.Help,
            VirtualKeys.VK_0 => Key._0,
            VirtualKeys.VK_1 => Key._1,
            VirtualKeys.VK_2 => Key._2,
            VirtualKeys.VK_3 => Key._3,
            VirtualKeys.VK_4 => Key._4,
            VirtualKeys.VK_5 => Key._5,
            VirtualKeys.VK_6 => Key._6,
            VirtualKeys.VK_7 => Key._7,
            VirtualKeys.VK_8 => Key._8,
            VirtualKeys.VK_9 => Key._9,
            VirtualKeys.VK_A => Key.A,
            VirtualKeys.VK_B => Key.B,
            VirtualKeys.VK_C => Key.C,
            VirtualKeys.VK_D => Key.D,
            VirtualKeys.VK_E => Key.E,
            VirtualKeys.VK_F => Key.F,
            VirtualKeys.VK_G => Key.G,
            VirtualKeys.VK_H => Key.H,
            VirtualKeys.VK_I => Key.I,
            VirtualKeys.VK_J => Key.J,
            VirtualKeys.VK_K => Key.K,
            VirtualKeys.VK_L => Key.L,
            VirtualKeys.VK_M => Key.M,
            VirtualKeys.VK_N => Key.N,
            VirtualKeys.VK_O => Key.O,
            VirtualKeys.VK_P => Key.P,
            VirtualKeys.VK_Q => Key.Q,
            VirtualKeys.VK_R => Key.R,
            VirtualKeys.VK_S => Key.S,
            VirtualKeys.VK_T => Key.T,
            VirtualKeys.VK_U => Key.U,
            VirtualKeys.VK_V => Key.V,
            VirtualKeys.VK_W => Key.W,
            VirtualKeys.VK_X => Key.X,
            VirtualKeys.VK_Y => Key.Y,
            VirtualKeys.VK_Z => Key.Z,
            VirtualKeys.VK_LWIN => Key.LeftWindows,
            VirtualKeys.VK_RWIN => Key.RightWindows,
            VirtualKeys.VK_APPS => Key.Application,
            VirtualKeys.VK_SLEEP => Key.Sleep,
            VirtualKeys.VK_NUMPAD0 => Key.Numpad0,
            VirtualKeys.VK_NUMPAD1 => Key.Numpad1,
            VirtualKeys.VK_NUMPAD2 => Key.Numpad2,
            VirtualKeys.VK_NUMPAD3 => Key.Numpad3,
            VirtualKeys.VK_NUMPAD4 => Key.Numpad4,
            VirtualKeys.VK_NUMPAD5 => Key.Numpad5,
            VirtualKeys.VK_NUMPAD6 => Key.Numpad6,
            VirtualKeys.VK_NUMPAD7 => Key.Numpad7,
            VirtualKeys.VK_NUMPAD8 => Key.Numpad8,
            VirtualKeys.VK_NUMPAD9 => Key.Numpad9,
            VirtualKeys.VK_MULTIPLY => Key.Multiply,
            VirtualKeys.VK_ADD => Key.Add,
            VirtualKeys.VK_SEPARATOR => Key.Separator,
            VirtualKeys.VK_SUBTRACT => Key.Subtract,
            VirtualKeys.VK_DECIMAL => Key.Decimal,
            VirtualKeys.VK_DIVIDE => Key.Divide,
            VirtualKeys.VK_F1 => Key.F1,
            VirtualKeys.VK_F2 => Key.F2,
            VirtualKeys.VK_F3 => Key.F3,
            VirtualKeys.VK_F4 => Key.F4,
            VirtualKeys.VK_F5 => Key.F5,
            VirtualKeys.VK_F6 => Key.F6,
            VirtualKeys.VK_F7 => Key.F7,
            VirtualKeys.VK_F8 => Key.F8,
            VirtualKeys.VK_F9 => Key.F9,
            VirtualKeys.VK_F10 => Key.F10,
            VirtualKeys.VK_F11 => Key.F11,
            VirtualKeys.VK_F12 => Key.F12,
            VirtualKeys.VK_F13 => Key.F13,
            VirtualKeys.VK_F14 => Key.F14,
            VirtualKeys.VK_F15 => Key.F15,
            VirtualKeys.VK_F16 => Key.F16,
            VirtualKeys.VK_F17 => Key.F17,
            VirtualKeys.VK_F18 => Key.F18,
            VirtualKeys.VK_F19 => Key.F19,
            VirtualKeys.VK_F20 => Key.F20,
            VirtualKeys.VK_F21 => Key.F21,
            VirtualKeys.VK_F22 => Key.F22,
            VirtualKeys.VK_F23 => Key.F23,
            VirtualKeys.VK_F24 => Key.F24,
            VirtualKeys.VK_NUMLOCK => Key.NumLock,
            VirtualKeys.VK_SCROLL => Key.ScrollLock,
            VirtualKeys.VK_OEM_NEC_EQUAL => Key.NEC_Equal,
            VirtualKeys.VK_OEM_FJ_MASSHOU => Key.OEM2,
            VirtualKeys.VK_OEM_FJ_TOUROKU => Key.A,
            VirtualKeys.VK_OEM_FJ_LOYA => Key.A,
            VirtualKeys.VK_OEM_FJ_ROYA => Key.A,
            VirtualKeys.VK_LSHIFT => Key.LeftShift,
            VirtualKeys.VK_RSHIFT => Key.RightShift,
            VirtualKeys.VK_LCONTROL => Key.LeftControl,
            VirtualKeys.VK_RCONTROL => Key.RightControl,
            VirtualKeys.VK_LMENU => Key.LeftMenu,
            VirtualKeys.VK_RMENU => Key.RightMenu,
            VirtualKeys.VK_BROWSER_BACK => Key.BrowserBack,
            VirtualKeys.VK_BROWSER_FORWARD => Key.BrowserForward,
            VirtualKeys.VK_BROWSER_REFRESH => Key.BrowserRefresh,
            VirtualKeys.VK_BROWSER_STOP => Key.BrowserStop,
            VirtualKeys.VK_BROWSER_SEARCH => Key.BrowserSearch,
            VirtualKeys.VK_BROWSER_FAVORITES => Key.BrowserFavorites,
            VirtualKeys.VK_BROWSER_HOME => Key.BrowserHome,
            // VirtualKeys.VK_VOLUME_MUTE => Key.A,
            // VirtualKeys.VK_VOLUME_DOWN => Key.A,
            // VirtualKeys.VK_VOLUME_UP => Key.A,
            // VirtualKeys.VK_MEDIA_NEXT_TRACK => Key.A,
            // VirtualKeys.VK_MEDIA_PREV_TRACK => Key.A,
            // VirtualKeys.VK_MEDIA_STOP => Key.A,
            // VirtualKeys.VK_MEDIA_PLAY_PAUSE => Key.A,
            // VirtualKeys.VK_LAUNCH_MAIL => Key.A,
            // VirtualKeys.VK_LAUNCH_MEDIA_SELECT => Key.A,
            // VirtualKeys.VK_LAUNCH_APP1 => Key.A,
            // VirtualKeys.VK_LAUNCH_APP2 => Key.A,
            // VirtualKeys.VK_OEM_1 => Key.A,
            // VirtualKeys.VK_OEM_PLUS => Key.A,
            // VirtualKeys.VK_OEM_COMMA => Key.A,
            // VirtualKeys.VK_OEM_MINUS => Key.A,
            // VirtualKeys.VK_OEM_PERIOD => Key.A,
            // VirtualKeys.VK_OEM_2 => Key.A,
            // VirtualKeys.VK_OEM_3 => Key.A,
            // VirtualKeys.VK_OEM_4 => Key.A,
            // VirtualKeys.VK_OEM_5 => Key.A,
            // VirtualKeys.VK_OEM_6 => Key.A,
            // VirtualKeys.VK_OEM_7 => Key.A,
            // VirtualKeys.VK_OEM_8 => Key.A,
            // VirtualKeys.VK_OEM_AX => Key.A,
            // VirtualKeys.VK_OEM_102 => Key.A,
            // VirtualKeys.VK_ICO_HELP => Key.A,
            // VirtualKeys.VK_ICO_00 => Key.A,
            // VirtualKeys.VK_PROCESSKEY => Key.A,
            // VirtualKeys.VK_ICO_CLEAR => Key.A,
            // VirtualKeys.VK_PACKET => Key.A,
            // VirtualKeys.VK_OEM_RESET => Key.A,
            // VirtualKeys.VK_OEM_JUMP => Key.A,
            // VirtualKeys.VK_OEM_PA1 => Key.A,
            // VirtualKeys.VK_OEM_PA2 => Key.A,
            // VirtualKeys.VK_OEM_PA3 => Key.A,
            // VirtualKeys.VK_OEM_WSCTRL => Key.A,
            // VirtualKeys.VK_OEM_CUSEL => Key.A,
            // VirtualKeys.VK_OEM_ATTN => Key.A,
            // VirtualKeys.VK_OEM_FINISH => Key.A,
            // VirtualKeys.VK_OEM_COPY => Key.A,
            // VirtualKeys.VK_OEM_AUTO => Key.A,
            // VirtualKeys.VK_OEM_ENLW => Key.A,
            // VirtualKeys.VK_OEM_BACKTAB => Key.A,
            // VirtualKeys.VK_ATTN => Key.A,
            // VirtualKeys.VK_CRSEL => Key.A,
            // VirtualKeys.VK_EXSEL => Key.A,
            // VirtualKeys.VK_EREOF => Key.A,
            // VirtualKeys.VK_PLAY => Key.A,
            // VirtualKeys.VK_ZOOM => Key.A,
            // VirtualKeys.VK_NONAME => Key.A,
            // VirtualKeys.VK_PA1 => Key.A,
            // VirtualKeys.VK_OEM_CLEAR => Key.A,
            _ => 0
        };



}

#endif


