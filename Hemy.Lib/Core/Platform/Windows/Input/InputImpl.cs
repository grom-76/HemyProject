#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Input;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Hemy.Lib.Core.Input;
using Hemy.Lib.Core.Platform.Windows.Window;
using static Hemy.Lib.Core.Platform.Windows.Common.LibrariesName;


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static partial class InputImpl
{
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static void UpdateInput(InputData* inputData)
    {
        POINT p = default;
        Memory.Memory.Copy(inputData->Current, inputData->Previous, byte.MaxValue);
        _ = GetKeyboardState(inputData->Current);

        inputData->Mouse_PreviousFrame_Position_X = inputData->Mouse_CurrentFrame_Position_X;
        inputData->Mouse_PreviousFrame_Position_Y = inputData->Mouse_CurrentFrame_Position_Y;

        _ = GetCursorPos(&p);
        _ = ScreenToClient(inputData->Handle, &p);

        inputData->Mouse_CurrentFrame_Position_X = p.X;
        inputData->Mouse_CurrentFrame_Position_Y = p.Y;

        inputData->Mouse_CurrentFrame_Delta_X = inputData->Mouse_CurrentFrame_Position_X - inputData->Mouse_PreviousFrame_Position_X;
        inputData->Mouse_CurrentFrame_Delta_Y = inputData->Mouse_CurrentFrame_Position_Y - inputData->Mouse_PreviousFrame_Position_Y;
    }

    internal static void GetMousePos(void* hwnd, int* x, int* y)
    {
        POINT* p = null;

        _ = GetCursorPos(p);
        _ = ScreenToClient(hwnd, p);

        x = &p->X;
        y = &p->Y;
    }

    internal static int[] GetKeysPressed(InputData* inputData)
    {
        int count = 0;
        for (int i = 0; i < 256; i++)
        {
            if (inputData->Current[i] == 1) count++;
        }
        if (count == 0) return null!;

        int[] list = new int[count];

        int index = 0;
        for (int i = 0; i < 256; i++)
        {
            if (inputData->Current[i] == 1) list[index++] = i;
        }

        return list;
    }

    internal static void SetMousePos(InputData* inputData, int x, int y)
    {
        POINT p = new(x, y);
        _ = ClientToScreen(inputData->Handle, &p);

        inputData->Mouse_CurrentFrame_Position_X = x;
        inputData->Mouse_CurrentFrame_Position_Y = y;
    }

    internal static void MapKeys(InputData* inputData, uint keyboardType = 0)
    {
        inputData->Keys[(byte)Key.LeftButton] = keyboardType == 0 ? (byte)VirtualKeys.VK_LBUTTON : (byte)VirtualKeys.VK_LBUTTON;
        inputData->Keys[(byte)Key.RightButton] = (byte)VirtualKeys.VK_RBUTTON;
        inputData->Keys[(byte)Key.Cancel] = (byte)VirtualKeys.VK_CANCEL;
        inputData->Keys[(byte)Key.MiddleButton] = (byte)VirtualKeys.VK_MBUTTON;
        inputData->Keys[(byte)Key.ExtraButton1] = (byte)VirtualKeys.VK_XBUTTON1;
        inputData->Keys[(byte)Key.ExtraButton2] = (byte)VirtualKeys.VK_XBUTTON2;
        inputData->Keys[(byte)Key.Back] = (byte)VirtualKeys.VK_BACK;
        inputData->Keys[(byte)Key.Tab] = (byte)VirtualKeys.VK_TAB;
        inputData->Keys[(byte)Key.Clear] = (byte)VirtualKeys.VK_CLEAR;
        inputData->Keys[(byte)Key.Return] = (byte)VirtualKeys.VK_RETURN;
        inputData->Keys[(byte)Key.Shift] = (byte)VirtualKeys.VK_SHIFT;
        inputData->Keys[(byte)Key.Control] = (byte)VirtualKeys.VK_CONTROL;
        inputData->Keys[(byte)Key.Menu] = (byte)VirtualKeys.VK_MENU;
        inputData->Keys[(byte)Key.Pause] = (byte)VirtualKeys.VK_PAUSE;
        inputData->Keys[(byte)Key.CapsLock] = (byte)VirtualKeys.VK_CRSEL;
        inputData->Keys[(byte)Key.Kana] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.Hangeul] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.Hangul] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.Junja] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.Final] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.Hanja] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.Kanji] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.Escape] = (byte)VirtualKeys.VK_ESCAPE;
        inputData->Keys[(byte)Key.Convert] = (byte)VirtualKeys.VK_CONVERT;
        inputData->Keys[(byte)Key.NonConvert] = (byte)VirtualKeys.VK_NONCONVERT;
        inputData->Keys[(byte)Key.Accept] = (byte)VirtualKeys.VK_ACCEPT;
        inputData->Keys[(byte)Key.ModeChange] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.Space] = (byte)VirtualKeys.VK_SPACE;
        inputData->Keys[(byte)Key.Prior] = (byte)VirtualKeys.VK_PRIOR;
        inputData->Keys[(byte)Key.Next] = (byte)VirtualKeys.VK_NEXT;
        inputData->Keys[(byte)Key.End] = (byte)VirtualKeys.VK_END;
        inputData->Keys[(byte)Key.Home] = (byte)VirtualKeys.VK_HOME;
        inputData->Keys[(byte)Key.Left] = (byte)VirtualKeys.VK_LEFT;
        inputData->Keys[(byte)Key.Up] = (byte)VirtualKeys.VK_UP;
        inputData->Keys[(byte)Key.Right] = (byte)VirtualKeys.VK_RIGHT;
        inputData->Keys[(byte)Key.Down] = (byte)VirtualKeys.VK_DOWN;
        inputData->Keys[(byte)Key.Select] = (byte)VirtualKeys.VK_SELECT;
        inputData->Keys[(byte)Key.Print] = (byte)VirtualKeys.VK_PRINT;
        inputData->Keys[(byte)Key.Execute] = (byte)VirtualKeys.VK_EXECUTE;
        inputData->Keys[(byte)Key.Snapshot] = (byte)VirtualKeys.VK_SNAPSHOT;
        inputData->Keys[(byte)Key.Insert] = (byte)VirtualKeys.VK_INSERT;
        inputData->Keys[(byte)Key.Delete] = (byte)VirtualKeys.VK_DELETE;
        inputData->Keys[(byte)Key.Help] = (byte)VirtualKeys.VK_HELP;
        inputData->Keys[(byte)Key._0] = (byte)VirtualKeys.VK_0;
        inputData->Keys[(byte)Key._1] = (byte)VirtualKeys.VK_1;
        inputData->Keys[(byte)Key._2] = (byte)VirtualKeys.VK_2;
        inputData->Keys[(byte)Key._3] = (byte)VirtualKeys.VK_3;
        inputData->Keys[(byte)Key._4] = (byte)VirtualKeys.VK_4;
        inputData->Keys[(byte)Key._5] = (byte)VirtualKeys.VK_5;
        inputData->Keys[(byte)Key._6] = (byte)VirtualKeys.VK_6;
        inputData->Keys[(byte)Key._7] = (byte)VirtualKeys.VK_7;
        inputData->Keys[(byte)Key._8] = (byte)VirtualKeys.VK_8;
        inputData->Keys[(byte)Key._9] = (byte)VirtualKeys.VK_9;
        inputData->Keys[(byte)Key.A] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.B] = (byte)VirtualKeys.VK_B;
        inputData->Keys[(byte)Key.C] = (byte)VirtualKeys.VK_C;
        inputData->Keys[(byte)Key.D] = (byte)VirtualKeys.VK_D;
        inputData->Keys[(byte)Key.E] = (byte)VirtualKeys.VK_E;
        inputData->Keys[(byte)Key.F] = (byte)VirtualKeys.VK_F;
        inputData->Keys[(byte)Key.G] = (byte)VirtualKeys.VK_G;
        inputData->Keys[(byte)Key.H] = (byte)VirtualKeys.VK_H;
        inputData->Keys[(byte)Key.I] = (byte)VirtualKeys.VK_I;
        inputData->Keys[(byte)Key.J] = (byte)VirtualKeys.VK_J;
        inputData->Keys[(byte)Key.K] = (byte)VirtualKeys.VK_K;
        inputData->Keys[(byte)Key.L] = (byte)VirtualKeys.VK_L;
        inputData->Keys[(byte)Key.M] = (byte)VirtualKeys.VK_M;
        inputData->Keys[(byte)Key.N] = (byte)VirtualKeys.VK_N;
        inputData->Keys[(byte)Key.O] = (byte)VirtualKeys.VK_O;
        inputData->Keys[(byte)Key.P] = (byte)VirtualKeys.VK_P;
        inputData->Keys[(byte)Key.Q] = (byte)VirtualKeys.VK_Q;
        inputData->Keys[(byte)Key.R] = (byte)VirtualKeys.VK_R;
        inputData->Keys[(byte)Key.S] = (byte)VirtualKeys.VK_S;
        inputData->Keys[(byte)Key.T] = (byte)VirtualKeys.VK_T;
        inputData->Keys[(byte)Key.U] = (byte)VirtualKeys.VK_U;
        inputData->Keys[(byte)Key.V] = (byte)VirtualKeys.VK_V;
        inputData->Keys[(byte)Key.W] = (byte)VirtualKeys.VK_W;
        inputData->Keys[(byte)Key.X] = (byte)VirtualKeys.VK_X;
        inputData->Keys[(byte)Key.Y] = (byte)VirtualKeys.VK_Y;
        inputData->Keys[(byte)Key.Z] = (byte)VirtualKeys.VK_Z;
        inputData->Keys[(byte)Key.LeftWindows] = (byte)VirtualKeys.VK_LWIN;
        inputData->Keys[(byte)Key.RightWindows] = (byte)VirtualKeys.VK_RWIN;
        inputData->Keys[(byte)Key.Application] = (byte)VirtualKeys.VK_APPS;
        inputData->Keys[(byte)Key.Sleep] = (byte)VirtualKeys.VK_SLEEP;
        inputData->Keys[(byte)Key.Numpad0] = (byte)VirtualKeys.VK_NUMPAD0;
        inputData->Keys[(byte)Key.Numpad1] = (byte)VirtualKeys.VK_NUMPAD1;
        inputData->Keys[(byte)Key.Numpad2] = (byte)VirtualKeys.VK_NUMPAD2;
        inputData->Keys[(byte)Key.Numpad3] = (byte)VirtualKeys.VK_NUMPAD3;
        inputData->Keys[(byte)Key.Numpad4] = (byte)VirtualKeys.VK_NUMPAD4;
        inputData->Keys[(byte)Key.Numpad5] = (byte)VirtualKeys.VK_NUMPAD5;
        inputData->Keys[(byte)Key.Numpad6] = (byte)VirtualKeys.VK_NUMPAD6;
        inputData->Keys[(byte)Key.Numpad7] = (byte)VirtualKeys.VK_NUMPAD7;
        inputData->Keys[(byte)Key.Numpad8] = (byte)VirtualKeys.VK_NUMPAD8;
        inputData->Keys[(byte)Key.Numpad9] = (byte)VirtualKeys.VK_NUMPAD9;
        inputData->Keys[(byte)Key.Multiply] = (byte)VirtualKeys.VK_MULTIPLY;
        inputData->Keys[(byte)Key.Add] = (byte)VirtualKeys.VK_ADD;
        inputData->Keys[(byte)Key.Separator] = (byte)VirtualKeys.VK_SEPARATOR;
        inputData->Keys[(byte)Key.Subtract] = (byte)VirtualKeys.VK_SUBTRACT;
        inputData->Keys[(byte)Key.Decimal] = (byte)VirtualKeys.VK_DECIMAL;
        inputData->Keys[(byte)Key.Divide] = (byte)VirtualKeys.VK_DIVIDE;
        inputData->Keys[(byte)Key.F1] = (byte)VirtualKeys.VK_F1;
        inputData->Keys[(byte)Key.F2] = (byte)VirtualKeys.VK_F2;
        inputData->Keys[(byte)Key.F3] = (byte)VirtualKeys.VK_F3;
        inputData->Keys[(byte)Key.F4] = (byte)VirtualKeys.VK_F4;
        inputData->Keys[(byte)Key.F5] = (byte)VirtualKeys.VK_F5;
        inputData->Keys[(byte)Key.F6] = (byte)VirtualKeys.VK_F6;
        inputData->Keys[(byte)Key.F7] = (byte)VirtualKeys.VK_F7;
        inputData->Keys[(byte)Key.F8] = (byte)VirtualKeys.VK_F8;
        inputData->Keys[(byte)Key.F9] = (byte)VirtualKeys.VK_F9;
        inputData->Keys[(byte)Key.F10] = (byte)VirtualKeys.VK_F10;
        inputData->Keys[(byte)Key.F11] = (byte)VirtualKeys.VK_F11;
        inputData->Keys[(byte)Key.F12] = (byte)VirtualKeys.VK_F12;
        inputData->Keys[(byte)Key.F13] = (byte)VirtualKeys.VK_F13;
        inputData->Keys[(byte)Key.F14] = (byte)VirtualKeys.VK_F14;
        inputData->Keys[(byte)Key.F15] = (byte)VirtualKeys.VK_F15;
        inputData->Keys[(byte)Key.F16] = (byte)VirtualKeys.VK_F16;
        inputData->Keys[(byte)Key.F17] = (byte)VirtualKeys.VK_F17;
        inputData->Keys[(byte)Key.F18] = (byte)VirtualKeys.VK_F18;
        inputData->Keys[(byte)Key.F19] = (byte)VirtualKeys.VK_F19;
        inputData->Keys[(byte)Key.F20] = (byte)VirtualKeys.VK_F20;
        inputData->Keys[(byte)Key.F21] = (byte)VirtualKeys.VK_F21;
        inputData->Keys[(byte)Key.F22] = (byte)VirtualKeys.VK_F22;
        inputData->Keys[(byte)Key.F23] = (byte)VirtualKeys.VK_F23;
        inputData->Keys[(byte)Key.F24] = (byte)VirtualKeys.VK_F24;
        inputData->Keys[(byte)Key.NumLock] = (byte)VirtualKeys.VK_NUMLOCK;
        inputData->Keys[(byte)Key.ScrollLock] = (byte)VirtualKeys.VK_SCROLL;
        inputData->Keys[(byte)Key.NEC_Equal] = (byte)VirtualKeys.VK_OEM_NEC_EQUAL;
        inputData->Keys[(byte)Key.Fujitsu_Jisho] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.Fujitsu_Masshou] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.Fujitsu_Touroku] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.Fujitsu_Loya] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.Fujitsu_Roya] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.LeftShift] = (byte)VirtualKeys.VK_LSHIFT;
        inputData->Keys[(byte)Key.RightShift] = (byte)VirtualKeys.VK_RSHIFT;
        inputData->Keys[(byte)Key.LeftControl] = (byte)VirtualKeys.VK_LCONTROL;
        inputData->Keys[(byte)Key.RightControl] = (byte)VirtualKeys.VK_RCONTROL;
        inputData->Keys[(byte)Key.LeftMenu] = (byte)VirtualKeys.VK_LMENU;
        inputData->Keys[(byte)Key.RightMenu] = (byte)VirtualKeys.VK_RMENU;
        inputData->Keys[(byte)Key.BrowserBack] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.BrowserForward] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.BrowserRefresh] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.BrowserStop] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.BrowserSearch] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.BrowserFavorites] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.BrowserHome] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.VolumeMute] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.VolumeDown] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.VolumeUp] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.MediaNextTrack] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.MediaPrevTrack] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.MediaStop] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.MediaPlayPause] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.LaunchMail] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.LaunchMediaSelect] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.LaunchApplication1] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.LaunchApplication2] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEM1] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMPlus] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMComma] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMMinus] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMPeriod] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEM2] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEM3] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEM4] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEM5] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEM6] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEM7] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEM8] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMAX] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEM102] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.ICOHelp] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.ICO00] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.ProcessKey] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.ICOClear] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.Packet] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMReset] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMJump] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMPA1] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMPA2] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMPA3] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMWSCtrl] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMCUSel] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMATTN] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMFinish] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMCopy] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMAuto] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMENLW] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMBackTab] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.ATTN] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.CRSel] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.EXSel] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.EREOF] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.Play] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.Zoom] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.Noname] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.PA1] = (byte)VirtualKeys.VK_A;
        inputData->Keys[(byte)Key.OEMClear] = (byte)VirtualKeys.VK_A;
    }




    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int GetKeyboardState(byte* lpKeyState);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int/*BOOL*/ GetCursorPos(POINT* point);

    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int/*BOOL*/ SetCursorPos(int x, int y);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int ClientToScreen(void* hWnd, /*[NativeTypeName("LPPOINT")]*/ POINT* lpPoint);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int ScreenToClient(void* hWnd, /*[NativeTypeName("LPPOINT")]*/ POINT* lpPoint);

    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int ClipCursor( /*[[in, optional]*/ RECT* lpRect);

    [LibraryImport(User, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int ShowCursor( /*[[in, optional]*/ int bShow);
}


/// <summary> Virtual Keys, Standard Set  </summary>
[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static class VirtualKeys
{
    internal const uint VK_LBUTTON = 0x01;
    internal const uint VK_RBUTTON = 0x02;
    internal const uint VK_CANCEL = 0x03;
    internal const uint VK_MBUTTON = 0x04;    /* NOT contiguous with L & RBUTTON */
    internal const uint VK_XBUTTON1 = 0x05;    /* NOT contiguous with L & RBUTTON */
    internal const uint VK_XBUTTON2 = 0x06;    /* NOT contiguous with L & RBUTTON */
    internal const uint VK_BACK = 0x08;    /** 0x07 : unassigned */
    internal const uint VK_TAB = 0x09;
    /** 0x0A - 0x0B : reserved */
    internal const uint VK_CLEAR = 0x0C;
    internal const uint VK_RETURN = 0x0D;
    internal const uint VK_SHIFT = 0x10;
    internal const uint VK_CONTROL = 0x11;
    internal const uint VK_MENU = 0x12;
    internal const uint VK_PAUSE = 0x13;
    internal const uint VK_CAPITAL = 0x14;
    internal const uint VK_KANA = 0x15;
    internal const uint VK_HANGEUL = 0x15;  /* old name - should be here for compatibility */
    internal const uint VK_HANGUL = 0x15;
    internal const uint VK_JUNJA = 0x17;
    internal const uint VK_FINAL = 0x18;
    internal const uint VK_HANJA = 0x19;
    internal const uint VK_KANJI = 0x19;
    internal const uint VK_ESCAPE = 0x1B;
    internal const uint VK_CONVERT = 0x1C;
    internal const uint VK_NONCONVERT = 0x1D;
    internal const uint VK_ACCEPT = 0x1E;
    internal const uint VK_MODECHANGE = 0x1F;
    internal const uint VK_SPACE = 0x20;
    internal const uint VK_PRIOR = 0x21;
    internal const uint VK_NEXT = 0x22;
    internal const uint VK_END = 0x23;
    internal const uint VK_HOME = 0x24;
    internal const uint VK_LEFT = 0x25;
    internal const uint VK_UP = 0x26;
    internal const uint VK_RIGHT = 0x27;
    internal const uint VK_DOWN = 0x28;
    internal const uint VK_SELECT = 0x29;
    internal const uint VK_PRINT = 0x2A;
    internal const uint VK_EXECUTE = 0x2B;
    internal const uint VK_SNAPSHOT = 0x2C;
    internal const uint VK_INSERT = 0x2D;
    internal const uint VK_DELETE = 0x2E;
    internal const uint VK_HELP = 0x2F;
    /*   internal const uint VK_LWIN = 0x5B;CII '0' - '9' (0x30 - 0x39) 0x40 : unassigned * VK_A - VK_Z are the same as ASCII 'A' - 'Z' (0x41 - 0x5A) */
    internal const uint VK_LWIN = 0x5B;
    internal const uint VK_RWIN = 0x5C;
    internal const uint VK_APPS = 0x5D;
    /* 0x5E : reserved */
    internal const uint VK_SLEEP = 0x5F;
    internal const uint VK_NUMPAD0 = 0x60;
    internal const uint VK_NUMPAD1 = 0x61;
    internal const uint VK_NUMPAD2 = 0x62;
    internal const uint VK_NUMPAD3 = 0x63;
    internal const uint VK_NUMPAD4 = 0x64;
    internal const uint VK_NUMPAD5 = 0x65;
    internal const uint VK_NUMPAD6 = 0x66;
    internal const uint VK_NUMPAD7 = 0x67;
    internal const uint VK_NUMPAD8 = 0x68;
    internal const uint VK_NUMPAD9 = 0x69;
    internal const uint VK_MULTIPLY = 0x6A;
    internal const uint VK_ADD = 0x6B;
    internal const uint VK_SEPARATOR = 0x6C;
    internal const uint VK_SUBTRACT = 0x6D;
    internal const uint VK_DECIMAL = 0x6E;
    internal const uint VK_DIVIDE = 0x6F;
    internal const uint VK_F1 = 0x70;
    internal const uint VK_F2 = 0x71;
    internal const uint VK_F3 = 0x72;
    internal const uint VK_F4 = 0x73;
    internal const uint VK_F5 = 0x74;
    internal const uint VK_F6 = 0x75;
    internal const uint VK_F7 = 0x76;
    internal const uint VK_F8 = 0x77;
    internal const uint VK_F9 = 0x78;
    internal const uint VK_F10 = 0x79;
    internal const uint VK_F11 = 0x7A;
    internal const uint VK_F12 = 0x7B;
    internal const uint VK_F13 = 0x7C;
    internal const uint VK_F14 = 0x7D;
    internal const uint VK_F15 = 0x7E;
    internal const uint VK_F16 = 0x7F;
    internal const uint VK_F17 = 0x80;
    internal const uint VK_F18 = 0x81;
    internal const uint VK_F19 = 0x82;
    internal const uint VK_F20 = 0x83;
    internal const uint VK_F21 = 0x84;
    internal const uint VK_F22 = 0x85;
    internal const uint VK_F23 = 0x86;
    internal const uint VK_F24 = 0x87;
    /* 0x88 - 0x8F : unassigned */
    internal const uint VK_NUMLOCK = 0x90;
    internal const uint VK_SCROLL = 0x91;
    /* NEC PC-9800 kbd definitions */
    internal const uint VK_OEM_NEC_EQUAL = 0x92;   // '=' key on numpad
    /* Fujitsu/OASYS kbd definitions */
    internal const uint VK_OEM_FJ_JISHO = 0x92;   // 'Dictionary' key
    internal const uint VK_OEM_FJ_MASSHOU = 0x93;   // 'Unregister word' key
    internal const uint VK_OEM_FJ_TOUROKU = 0x94;   // 'Register word' key
    internal const uint VK_OEM_FJ_LOYA = 0x95;   // 'Left OYAYUBI' key
    internal const uint VK_OEM_FJ_ROYA = 0x96;   // 'Right OYAYUBI' key
    /* 0x97 - 0x9F : unassigned */
    /* VK_L* & VK_R* - left and right Alt, Ctrl and Shift virtual keys. * Used only as parameters to GetAsyncKeyState() and GetKeyState(). * No other API or message will distinguish left and right keys in this way. */
    internal const uint VK_LSHIFT = 0xA0;
    internal const uint VK_RSHIFT = 0xA1;
    internal const uint VK_LCONTROL = 0xA2;
    internal const uint VK_RCONTROL = 0xA3;
    internal const uint VK_LMENU = 0xA4;
    internal const uint VK_RMENU = 0xA5;
    //#if(_WIN32_WINNT >= 0x0500)
    internal const uint VK_BROWSER_BACK = 0xA6;
    internal const uint VK_BROWSER_FORWARD = 0xA7;
    internal const uint VK_BROWSER_REFRESH = 0xA8;
    internal const uint VK_BROWSER_STOP = 0xA9;
    internal const uint VK_BROWSER_SEARCH = 0xAA;
    internal const uint VK_BROWSER_FAVORITES = 0xAB;
    internal const uint VK_BROWSER_HOME = 0xAC;
    internal const uint VK_VOLUME_MUTE = 0xAD;
    internal const uint VK_VOLUME_DOWN = 0xAE;
    internal const uint VK_VOLUME_UP = 0xAF;
    internal const uint VK_MEDIA_NEXT_TRACK = 0xB0;
    internal const uint VK_MEDIA_PREV_TRACK = 0xB1;
    internal const uint VK_MEDIA_STOP = 0xB2;
    internal const uint VK_MEDIA_PLAY_PAUSE = 0xB3;
    internal const uint VK_LAUNCH_MAIL = 0xB4;
    internal const uint VK_LAUNCH_MEDIA_SELECT = 0xB5;
    internal const uint VK_LAUNCH_APP1 = 0xB6;
    internal const uint VK_LAUNCH_APP2 = 0xB7;
    //#endif /* _WIN32_WINNT >= 0x0500 */
    /* 0xB8 - 0xB9 : reserved */
    internal const uint VK_OEM_1 = 0xBA;   // ';:' for US
    internal const uint VK_OEM_PLUS = 0xBB;   // '+' any country
    internal const uint VK_OEM_COMMA = 0xBC;   // ',' any country
    internal const uint VK_OEM_MINUS = 0xBD;   // '-' any country
    internal const uint VK_OEM_PERIOD = 0xBE;   // '.' any country
    internal const uint VK_OEM_2 = 0xBF;   // '/?' for US
    internal const uint VK_OEM_3 = 0xC0;   // '`~' for US
    /* 0xC1 - 0xD7 : reserved */
    /* 0xD8 - 0xDA : unassigned */
    internal const uint VK_OEM_4 = 0xDB;  //  '[{' for US
    internal const uint VK_OEM_5 = 0xDC;  //  '\|' for US
    internal const uint VK_OEM_6 = 0xDD;  //  ']}' for US
    internal const uint VK_OEM_7 = 0xDE;  //  ''"' for US
    internal const uint VK_OEM_8 = 0xDF;
    /* 0xE0 : reserved */
    /* Various extended or enhanced keyboards */
    internal const uint VK_OEM_AX = 0xE1;  //  'AX' key on Japanese AX kbd
    internal const uint VK_OEM_102 = 0xE2;  //  "<>" or "\|" on RT 102-key kbd.
    internal const uint VK_ICO_HELP = 0xE3;  //  Help key on ICO
    internal const uint VK_ICO_00 = 0xE4;  //  00 key on ICO
                                           //#if(WINVER >= 0x0400)
    internal const uint VK_PROCESSKEY = 0xE5;
    //#endif /* WINVER >= 0x0400 */
    internal const uint VK_ICO_CLEAR = 0xE6;
    //#if(_WIN32_WINNT >= 0x0500)
    internal const uint VK_PACKET = 0xE7;
    //#endif /* _WIN32_WINNT >= 0x0500 */
    /* 0xE8 : unassigned */
    /* Nokia/Ericsson definitions */
    internal const uint VK_OEM_RESET = 0xE9;
    internal const uint VK_OEM_JUMP = 0xEA;
    internal const uint VK_OEM_PA1 = 0xEB;
    internal const uint VK_OEM_PA2 = 0xEC;
    internal const uint VK_OEM_PA3 = 0xED;
    internal const uint VK_OEM_WSCTRL = 0xEE;
    internal const uint VK_OEM_CUSEL = 0xEF;
    internal const uint VK_OEM_ATTN = 0xF0;
    internal const uint VK_OEM_FINISH = 0xF1;
    internal const uint VK_OEM_COPY = 0xF2;
    internal const uint VK_OEM_AUTO = 0xF3;
    internal const uint VK_OEM_ENLW = 0xF4;
    internal const uint VK_OEM_BACKTAB = 0xF5;
    internal const uint VK_ATTN = 0xF6;
    internal const uint VK_CRSEL = 0xF7;
    internal const uint VK_EXSEL = 0xF8;
    internal const uint VK_EREOF = 0xF9;
    internal const uint VK_PLAY = 0xFA;
    internal const uint VK_ZOOM = 0xFB;
    internal const uint VK_NONAME = 0xFC;
    internal const uint VK_PA1 = 0xFD;
    internal const uint VK_OEM_CLEAR = 0xFE;
    /* 0xFF : reserved */
    /* missing letters and numbers for convenience*/
    internal const int VK_0 = 0x30;
    internal const int VK_1 = 0x31;
    internal const int VK_2 = 0x32;
    internal const int VK_3 = 0x33;
    internal const int VK_4 = 0x34;
    internal const int VK_5 = 0x35;
    internal const int VK_6 = 0x36;
    internal const int VK_7 = 0x37;
    internal const int VK_8 = 0x38;
    internal const int VK_9 = 0x39;
    /* 0x40 : unassigned*/
    internal const int VK_A = 0x41;
    internal const int VK_B = 0x42;
    internal const int VK_C = 0x43;
    internal const int VK_D = 0x44;
    internal const int VK_E = 0x45;
    internal const int VK_F = 0x46;
    internal const int VK_G = 0x47;
    internal const int VK_H = 0x48;
    internal const int VK_I = 0x49;
    internal const int VK_J = 0x4A;
    internal const int VK_K = 0x4B;
    internal const int VK_L = 0x4C;
    internal const int VK_M = 0x4D;
    internal const int VK_N = 0x4E;
    internal const int VK_O = 0x4F;
    internal const int VK_P = 0x50;
    internal const int VK_Q = 0x51;
    internal const int VK_R = 0x52;
    internal const int VK_S = 0x53;
    internal const int VK_T = 0x54;
    internal const int VK_U = 0x55;
    internal const int VK_V = 0x56;
    internal const int VK_W = 0x57;
    internal const int VK_X = 0x58;
    internal const int VK_Y = 0x59;
    internal const int VK_Z = 0x5A;
}

#endif
