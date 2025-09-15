namespace Hemy.Lib.Core.Input;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#if WINDOWS
using Hemy.Lib.Core.Platform.Windows.Input;
#endif


[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe sealed class Keyboard(
#if WINDOWS
    InputData* data
#endif    
    )
{
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsPressed(Key key)
        => (data->Current[data->Keys[(short)key] & 0xff] & 0x80) != 0 && (data->Previous[data->Keys[(short)key] & 0xff] & 0x80) == 0;

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsReleased(Key key)
        => (data->Current[data->Keys[(short)key] & 0xff] & 0x80) == 0 && (data->Previous[data->Keys[(short)key] & 0xff] & 0x80) != 0;

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsDown(Key key)
        => (data->Current[data->Keys[(short)key] & 0xff] & 0x80) != 0 && (data->Previous[data->Keys[(short)key] & 0xff] & 0x80) != 0;

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsUp(Key key)
        => (data->Current[data->Keys[(short)key] & 0xff] & 0x80) == 0 && (data->Previous[data->Keys[(short)key] & 0xff] & 0x80) == 0;

    internal static Key KeyMapper(uint k)
#if WINDOWS
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
#else
    => key.Unknown;
#endif
}
