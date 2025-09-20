#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Input;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using DWORD = System.UInt32; // A 32-bit unsigned integer. The range is 0 through 4294967295 decimal.

using static Hemy.Lib.Core.Platform.Windows.LibrariesName;
using Hemy.Lib.Core.Input;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static partial class ControllerImpl
{
    internal unsafe static void Init(ControllerData* controllersData)
    {
        InitController(controllersData, 0);
        InitController(controllersData, 1);
        InitController(controllersData, 2);
        InitController(controllersData, 3);
    }

    internal unsafe static void Update(ControllerData* controllersData)
    {
        UpdateController(controllersData, 0);
        UpdateController(controllersData, 1);
        UpdateController(controllersData, 2);
        UpdateController(controllersData, 3);
    }


    private unsafe static void InitController(ControllerData* controllersData, uint player)
    {
        XINPUT_CAPABILITIES pCapabilities = default;

        uint error = XInputGetCapabilities((uint)player, ControllerConsts.XINPUT_FLAG_GAMEPAD, &pCapabilities);
        controllersData->IsConntected[player] = error == 0;

        if (!controllersData->IsConntected[player]) return;

        // TODO : Verifier l'utilite de Feature Type SubType
        // controllersData->Features[id] = /*(CapabilitieFeatures) */pCapabilities.Flags;
        // controllersData->Type[id] = /*(CapabilitiesDevType)*/pCapabilities.Type;
        // controllersData->SubType[id] = /*(CapabilitiesDevSubType)*/pCapabilities.SubType;

        // XINPUT_VIBRATION vibration = pCapabilities.Vibration;

        // if (vibration.wLeftMotorSpeed > 0 || vibration.wRightMotorSpeed > 0)
        // {
        //     // controllersData->HaveVibration[id] = true;  // TODO: IsHaveRumble =  LeftMotorSpeedMax !=0 && RightMotorSpeedMax !=0
        //     // controllersData->LeftMotorSpeedMax[player] = vibration.wLeftMotorSpeed;
        //     // controllersData->RightMotorSpeedMax[player] = vibration.wRightMotorSpeed;
        // }

        uint ID = player * 32;
        controllersData->Buttons[(int)ControllerButton.A + ID] = ControllerConsts.XINPUT_GAMEPAD_A;
        controllersData->Buttons[(int)ControllerButton.B + ID] = ControllerConsts.XINPUT_GAMEPAD_B;
        controllersData->Buttons[(int)ControllerButton.X + ID] = ControllerConsts.XINPUT_GAMEPAD_X;
        controllersData->Buttons[(int)ControllerButton.Y + ID] = ControllerConsts.XINPUT_GAMEPAD_Y;
        controllersData->Buttons[(int)ControllerButton.Start + ID] = ControllerConsts.XINPUT_GAMEPAD_START;
        controllersData->Buttons[(int)ControllerButton.Back + ID] = ControllerConsts.XINPUT_GAMEPAD_BACK;
        controllersData->Buttons[(int)ControllerButton.RightShoulder + ID] = ControllerConsts.XINPUT_GAMEPAD_RIGHT_SHOULDER;
        controllersData->Buttons[(int)ControllerButton.LeftShoulder + ID] = ControllerConsts.XINPUT_GAMEPAD_LEFT_SHOULDER;
        controllersData->Buttons[(int)ControllerButton.RightThumb + ID] = ControllerConsts.XINPUT_GAMEPAD_RIGHT_THUMB;
        controllersData->Buttons[(int)ControllerButton.LefThumb + ID] = ControllerConsts.XINPUT_GAMEPAD_LEFT_THUMB;
    }

    private static void UpdateController(ControllerData* controllersData, uint player)
    {
        if (controllersData->IsConntected[player] == false) return;

        XINPUT_STATE state = default;

        var error = XInputGetState(player, &state );
        if (error != 0) return;

        controllersData->Previous[player] = controllersData->Current[player];
        controllersData->Current[player] = state.Gamepad.wButtons;
        controllersData->Left_Trigger[player] = state.Gamepad.bLeftTrigger * 0.00392156862f; // equivalent à  / 255.0f
        controllersData->Right_Trigger[player] = state.Gamepad.bRightTrigger * 0.00392156862f;
        controllersData->Left_X[player] = Deadzone((float)state.Gamepad.sThumbLX * 0.0000305185f);
        controllersData->Left_Y[player] = Deadzone((float)state.Gamepad.sThumbLY * 0.0000305185f);
        controllersData->Right_X[player] = Deadzone((float)state.Gamepad.sThumbRX * 0.0000305185f); 
        controllersData->Right_Y[player] = -Deadzone((float)state.Gamepad.sThumbRY * 0.0000305185f ); 
    }

    internal const float XboxOneThumbDeadZone = 0.24f;  // Recommended Xbox One controller deadzone 

    internal static ushort Clamp(ushort value, ushort min, ushort max) => value < min ? min : value > max ? max : value;

    internal static float Deadzone(float x)
        => x > -XboxOneThumbDeadZone && x < XboxOneThumbDeadZone ? 0.0f : x < -1.0f ? -1.0f : x > 1.0f ? 1.0f : x;


    internal static void GetCapabilities( ControllerData* controllersData, uint player )
    {
        XINPUT_CAPABILITIES pCapabilities = default;
        
        uint error = XInputGetCapabilities((uint)player, ControllerConsts.XINPUT_FLAG_GAMEPAD, &pCapabilities);
        controllersData->IsConntected[player] = error == 0;

        // if (!controllersData->IsConntected[id]) return;

        // TODO : Verifier l'utilite de Feature Type SubType
        // controllersData->Features[id] = /*(CapabilitieFeatures) */pCapabilities.Flags;
        // controllersData->Type[id] = /*(CapabilitiesDevType)*/pCapabilities.Type;
        // controllersData->SubType[id] = /*(CapabilitiesDevSubType)*/pCapabilities.SubType;

        XINPUT_VIBRATION vibration = pCapabilities.Vibration;

        if (vibration.wLeftMotorSpeed > 0 || vibration.wRightMotorSpeed > 0)
        {
            // controllersData->HaveVibration[id] = true;  // TODO: IsHaveRumble =  LeftMotorSpeedMax !=0 && RightMotorSpeedMax !=0
            // controllersData->LeftMotorSpeedMax[player] = vibration.wLeftMotorSpeed;
            // controllersData->RightMotorSpeedMax[player] = vibration.wRightMotorSpeed;
        }

    }

    internal static bool SetVibration(ControllerData* controllersData, uint player, float leftMotor, float rightMotor)
    {
        XINPUT_CAPABILITIES pCapabilities = default;

        uint error = XInputGetCapabilities((uint)player, ControllerConsts.XINPUT_FLAG_GAMEPAD, &pCapabilities);
        if (error != 0) return false;

        XINPUT_VIBRATION vibration = pCapabilities.Vibration;

        if (vibration.wLeftMotorSpeed <= 0 || vibration.wRightMotorSpeed <= 0) return false;

        int left = (int)leftMotor * 65535;
        int right = (int)rightMotor * 65535;
        vibration.wLeftMotorSpeed = Clamp((ushort)left, 0, vibration.wLeftMotorSpeed); // use any value between 0-65535 here
        vibration.wRightMotorSpeed = Clamp((ushort)right, 0, vibration.wRightMotorSpeed); // use any value between 0-65535 here

        error = XInputSetState(player, &vibration);
        return true;
    }

    internal static bool SuspendVibration( ControllerData* controllersData, uint player, ushort leftMotor, ushort rightMotor)
    {
        XInputEnable(0); // Sets the reporting state of XInput.
        /*
        If enable is FALSE, XInput will only send neutral data in response to XInputGetState (all buttons up, axes centered, and triggers at 0). XInputSetState calls will be registered but not sent to the device. Sending any value other than FALSE will restore reading and writing functionality to normal.

        */
        return false;
    }

    internal static bool ResumeVibration(ControllerData* controllersData, uint player, ushort leftMotor, ushort rightMotor)
    {
        XInputEnable(1);

        return false;
    }

    internal static bool AddController()
    {

        return false;
    }

    internal static bool RemoveController()
    {
        
        return false;
    }

    internal static string GetControllerName( uint player )
    {
        
        return string.Empty;
    }


    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(XInput, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial DWORD XInputGetState(DWORD dwUserIndex, XINPUT_STATE* pState);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(XInput, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial DWORD XInputSetState(DWORD dwUserIndex, XINPUT_VIBRATION* pVibration);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(XInput, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial DWORD XInputGetCapabilities(DWORD dwUserIndex, uint dwFlags, XINPUT_CAPABILITIES* pCapabilities);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(XInput, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial void XInputEnable(int enable);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(XInput, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial uint XInputGetAudioDeviceIds(uint dwUserIndex, char* pRenderDeviceId, uint* pRenderCount, char* pCaptureDeviceId, uint* pCaptureCount);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(XInput, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial uint XInputGetBatteryInformation(uint dwUserIndex, byte devType, XINPUT_BATTERY_INFORMATION* pBatteryInformation);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(XInput, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial uint XInputGetKeystroke(uint dwUserIndex, uint dwReserved, XINPUT_KEYSTROKE* pKeystroke);
}

#endif
