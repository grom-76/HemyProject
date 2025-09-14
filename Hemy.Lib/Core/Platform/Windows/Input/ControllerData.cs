#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Input;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

using WORD = System.UInt16;
using DWORD = System.UInt32; // A 32-bit unsigned integer. The range is 0 through 4294967295 decimal.
using HRESULT = System.UInt32;
using BOOL = System.Int32;
using LONG = System.Int32;

using static Hemy.Lib.Core.Platform.Windows.Common.LibrariesName;
using Hemy.Lib.Core.Input;
using Hemy.Lib.Core.Math;



public unsafe readonly struct GamePad(NewControllerData* data, uint id)
{
    public bool IsPressed(int button) => ((data->Previous[id] & (data->Buttons[button])) == 0) && ((data->Current[id] & (data->Buttons[button])) != 0);
    public bool IsDown(int button) => ((data->Previous[id] & (data->Buttons[button])) == 0) && ((data->Current[id] & (data->Buttons[button])) != 0);
    public bool IsReleased(int button) => ((data->Previous[id] & (data->Buttons[button])) == 0) && ((data->Current[id] & (data->Buttons[button])) != 0); 
    public bool IsUp(int button ) =>  ((data->Previous[id] & ( data->Buttons[button] )) == 0) && ((data->Current[id] & (data->Buttons[button])) != 0); 


    public float GetJoytick_RightStick_X => (float)data->Right_X[id] * 0.0000305185f ; // =>  / 32767.0f ;
    public float GetJoytick_Right_Stick_Y => (float)data->Right_Y[id] * 0.0000305185f ;
    public float GetJoytick_LeftStick_X => (float)data->Left_X[id] * 0.0000305185f ; // =>  / 32767.0f ;
    public float GetJoytick_LeftStick_Y => (float)data->Left_Y[id] * 0.0000305185f ;
    public float GetJoytick_Left_Trigger => (float)data->Left_Trigger[id] *0.00392156862f;// = Left_Trigger / 255.0f
    public float GetJoytick_Right_Trigger => (float)data->Right_Trigger[id] *0.00392156862f;// = Left_Trigger / 255.0f



    // 	// public void SetFeedback(int id ,ushort left, ushort right) => controller_commands.SetFeedback(ref this, left,right);
    //     // public void StopFeedback(int id ,ushort left, ushort right) => controller_commands.SetFeedback(ref this, left,right);
    //     // ISLeftStickXMove
    //     // ISLeftStickYMove
    //     // ISRightStickXMove
    //     // ISRightStickYMove
    //     // IsJoystickPressLeftStickButton
    //     // IsJoystickPressRightStickButton
    //     //public string GetJoytickName(int id ){ return "NoName";} // TODO : GetJoystickNAme
    // }

    //     // #region Joystik


    //     // public GamePad GetGamePad()
    //     // {
    //     //     // is Connected 
    //     //     // GetCapabilites
    //     //     // getname
    //     //     //Mapping joytickbuton en fonction du nom 

    //     //     return new(0, this);
    //     // }

}



[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ControllerData(uint id)
{
    internal fixed uint Buttons[32];// private static int GamepadButtons_Flags_Fixed_Size = (int)Enum.GetNames(typeof(GamepadButton)).Length ;
    internal bool IsAssigned = false;
    internal uint Id = id;
    internal uint GamepadButtons_Current = 0;
    internal uint GamepadButtons_Previous = 0;
    internal bool IsConntected = false;
    internal bool HaveVibration = false;
    internal VirtualKey keystroke = 0;
    internal KeystrokeFlags KeystrokState = 0;
    internal BatteryLevelInformation BatteryLevel = 0;//BATTERY_LEVEL_EMPTY
    internal BatteryTypeInformation BatteryType = 0;// BATTERY_TYPE_WIRED
    internal CapabilitiesDevType Type = CapabilitiesDevType.XINPUT_DEVTYPE_GAMEPAD;//XINPUT_DEVTYPE_GAMEPAD
    internal CapabilitiesDevSubType SubType = CapabilitiesDevSubType.XINPUT_DEVSUBTYPE_UNKNOWN; //XINPUT_DEVSUBTYPE_GAMEPAD
    internal CapabilitieFeatures Features = 0; // XINPUT_CAPS_FFB_SUPPORTED 
    internal short Left_X = 0;
    internal short Left_Y = 0;
    internal short Right_X = 0;
    internal short Right_Y = 0;
    internal ushort LeftMotorSpeedMax = 0;
    internal ushort RightMotorSpeedMax = 0;
    internal byte Left_Trigger = 0;
    internal byte Right_Trigger = 0;
}

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct NewControllerData()
{
    const int COUNT = 4;
    internal fixed uint Buttons[32 * COUNT ];// private static int GamepadButtons_Flags_Fixed_Size = (int)Enum.GetNames(typeof(GamepadButton)).Length ;
    internal fixed uint Current [COUNT];
    internal fixed uint Previous[COUNT] ;
    internal fixed bool IsConntected[COUNT] ;
    // internal fixed bool HaveVibration[COUNT];
    // internal VirtualKey keystroke = 0;
    // internal KeystrokeFlags KeystrokState = 0;
    // internal BatteryLevelInformation BatteryLevel = 0;//BATTERY_LEVEL_EMPTY
    // internal BatteryTypeInformation BatteryType = 0;// BATTERY_TYPE_WIRED
    // internal fixed byte Type[COUNT] ;//= CapabilitiesDevType.XINPUT_DEVTYPE_GAMEPAD;//XINPUT_DEVTYPE_GAMEPAD
    // internal fixed byte SubType[COUNT];// = CapabilitiesDevSubType.XINPUT_DEVSUBTYPE_UNKNOWN; //XINPUT_DEVSUBTYPE_GAMEPAD
    // internal fixed uint Features [COUNT]; // XINPUT_CAPS_FFB_SUPPORTED 
    internal fixed short Left_X[COUNT];
    internal fixed short Left_Y [COUNT];
    internal fixed short Right_X [COUNT];
    internal fixed short Right_Y [COUNT];
    internal fixed ushort LeftMotorSpeedMax [COUNT];
    internal fixed ushort RightMotorSpeedMax [COUNT];
    internal fixed byte Left_Trigger [COUNT];
    internal fixed byte Right_Trigger [COUNT];
}

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static partial class ControllerImpl
{
     internal static ushort Clamp(ushort value, ushort min, ushort max) => value < min ? min : value > max ? max : value;

    internal const int FALSE = 0;
    internal const int TRUE = 1;

	internal static void DisposeControllers()
    {
    	XInputEnable(FALSE);
    }

    internal static void InitControllers()
    {
        XInputEnable(TRUE);
   
    }

    internal unsafe static void Init(ControllerData* controllerData, uint id)
    {
        controllerData->Id = id;
        MapControllerButtonsToXbox360(controllerData);
        GetCapabilities(controllerData);
    }

    internal unsafe static void NEWInit(NewControllerData* controllersData, uint id)
    {
        // MapControllerButtonsToXbox360(controllersData[0]);
        // GetCapabilities(controllerData);
        uint ID = id * 32;
        controllersData->Buttons[(int)ControllerButton.A * ID] = ControllerConsts.XINPUT_GAMEPAD_A;
        controllersData->Buttons[(int)ControllerButton.B * ID] = ControllerConsts.XINPUT_GAMEPAD_B;
        controllersData->Buttons[(int)ControllerButton.X * ID] = ControllerConsts.XINPUT_GAMEPAD_X;
        controllersData->Buttons[(int)ControllerButton.Y * ID] = ControllerConsts.XINPUT_GAMEPAD_Y;
        controllersData->Buttons[(int)ControllerButton.Start * ID] = ControllerConsts.XINPUT_GAMEPAD_START;
        controllersData->Buttons[(int)ControllerButton.Back * ID] = ControllerConsts.XINPUT_GAMEPAD_BACK;
        controllersData->Buttons[(int)ControllerButton.RightShoulder * ID] = ControllerConsts.XINPUT_GAMEPAD_RIGHT_SHOULDER;
        controllersData->Buttons[(int)ControllerButton.LeftShoulder * ID] = ControllerConsts.XINPUT_GAMEPAD_LEFT_SHOULDER;
        controllersData->Buttons[(int)ControllerButton.RightThumb * ID] = ControllerConsts.XINPUT_GAMEPAD_RIGHT_THUMB;
        controllersData->Buttons[(int)ControllerButton.LefThumb * ID] = ControllerConsts.XINPUT_GAMEPAD_LEFT_THUMB;
        // ID = 1 * 32;
        // controllersData->Buttons[(int)ControllerButton.A * ID] = ControllerConsts.XINPUT_GAMEPAD_A;
        // ...

        XINPUT_CAPABILITIES pCapabilities = default;

        
        uint error = XInputGetCapabilities((uint)id, ControllerConsts.XINPUT_FLAG_GAMEPAD, &pCapabilities);
        controllersData->IsConntected[id] = error == 0;

        if (!controllersData->IsConntected[id]) return;

        // TODO : Verifier l'utilite de Feature Type SubType
        // controllersData->Features[id] = /*(CapabilitieFeatures) */pCapabilities.Flags;
        // controllersData->Type[id] = /*(CapabilitiesDevType)*/pCapabilities.Type;
        // controllersData->SubType[id] = /*(CapabilitiesDevSubType)*/pCapabilities.SubType;

        XINPUT_VIBRATION vibration = pCapabilities.Vibration;

        if (vibration.wLeftMotorSpeed > 0 || vibration.wRightMotorSpeed > 0)
        {
            // controllersData->HaveVibration[id] = true;  // TODO: IsHaveRumble =  LeftMotorSpeedMax !=0 && RightMotorSpeedMax !=0
            controllersData->LeftMotorSpeedMax[id] = vibration.wLeftMotorSpeed;
            controllersData->RightMotorSpeedMax[id] = vibration.wRightMotorSpeed;
        }

        //   ApplyLinearDeadZone
        
    }

    internal static void NEWUpdateController(NewControllerData* controllersData, uint id)
    {
        if (controllersData->IsConntected[id] == false) return;

        XINPUT_STATE* state = stackalloc XINPUT_STATE[0];//default;

        if (XInputGetState(id, &state[0]) != 0) return;

        controllersData->Previous[id] = controllersData->Current[id];
        controllersData->Current[id] = state[0].Gamepad.wButtons;
        controllersData->Left_Trigger[id] = state[0].Gamepad.bLeftTrigger;
        controllersData->Right_Trigger[id] = state[0].Gamepad.bRightTrigger;
        controllersData->Left_X[id] = state[0].Gamepad.sThumbLX;
        controllersData->Left_Y[id] = state[0].Gamepad.sThumbLY;
        controllersData->Right_X[id] = state[0].Gamepad.sThumbRX;
        controllersData->Right_Y[id] = state[0].Gamepad.sThumbRY;
        // GeKeysStateXInput(data);

        float triggers_left = ApplyLinearDeadZone((float)state[0].Gamepad.bLeftTrigger, 255.0f, 0.0f);
        float triggers_right = ApplyLinearDeadZone((float)state[0].Gamepad.bRightTrigger, 255.0f, 0.0f);

        float thumb_leftX = 0.0f;
        float thumb_leftY = 0.0f;
        ApplyStickDeadZone((float)state[0].Gamepad.sThumbLX, (float)state[0].Gamepad.sThumbLX,
                    deadZoneMode: 1, 32767.0f, (float)ControllerConsts.XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE,
                    &thumb_leftX, &thumb_leftY);

        float thumb_rightX = 0.0f;
        float thumb_rightY = 0.0f; 
        ApplyStickDeadZone((float)state[0].Gamepad.sThumbRX, (float)state[0].Gamepad.sThumbRX,
                    deadZoneMode:1, 32767.0f, (float) ControllerConsts.XINPUT_GAMEPAD_RIGHT_THUMB_DEADZONE,
                    &thumb_rightX, &thumb_rightY);                  
    }

    internal static void UpdateController(ControllerData* controllerData)
    {
        if (controllerData->IsConntected == false) return;

        XINPUT_STATE* state = stackalloc XINPUT_STATE[0];//default;

        if (XInputGetState(controllerData->Id, &state[0]) != 0) return;

        controllerData->GamepadButtons_Previous = controllerData->GamepadButtons_Current;
        controllerData->GamepadButtons_Current = state[0].Gamepad.wButtons;
        controllerData->Left_Trigger = state[0].Gamepad.bLeftTrigger;
        controllerData->Right_Trigger = state[0].Gamepad.bRightTrigger;
        controllerData->Left_X = state[0].Gamepad.sThumbLX;
        controllerData->Left_Y = state[0].Gamepad.sThumbLY;
        controllerData->Right_X = state[0].Gamepad.sThumbRX;
        controllerData->Right_Y = state[0].Gamepad.sThumbRY;
        // GeKeysStateXInput(data);


    }
	
    internal static void GetCapabilities(ControllerData* controllerData)
    {
        XINPUT_CAPABILITIES pCapabilities = default;

        uint error = XInputGetCapabilities(controllerData->Id, ControllerConsts.XINPUT_FLAG_GAMEPAD, &pCapabilities);
        controllerData->IsConntected = error == 0;

        if (controllerData->IsConntected)
        {
            controllerData->Features = (CapabilitieFeatures)pCapabilities.Flags;
            controllerData->Type = (CapabilitiesDevType)pCapabilities.Type;
            controllerData->SubType = (CapabilitiesDevSubType)pCapabilities.SubType;

            XINPUT_VIBRATION vibration = pCapabilities.Vibration;
            if (vibration.wLeftMotorSpeed > 0 || vibration.wRightMotorSpeed > 0)
            {
                controllerData->HaveVibration = true;
                controllerData->LeftMotorSpeedMax = vibration.wLeftMotorSpeed;
                controllerData->RightMotorSpeedMax = vibration.wRightMotorSpeed;
            }

        }
        GetBatteryInformation(controllerData);
    }

    internal static void GetBatteryInformation(ControllerData* controllerData)
    {
        XINPUT_BATTERY_INFORMATION batterie = default;
        _ = XInputGetBatteryInformation(controllerData->Id, ControllerConsts.BATTERY_DEVTYPE_GAMEPAD, &batterie);
        controllerData->BatteryLevel = (BatteryLevelInformation)batterie.BatteryLevel;
        controllerData->BatteryType = (BatteryTypeInformation)batterie.BatteryType;
    }

    internal static void GeKeysStateXInput(ControllerData* controllerData)
    {
        XINPUT_KEYSTROKE keystroke = default;
        _ = XInputGetKeystroke(controllerData->Id, 0, &keystroke);
        controllerData->keystroke = (VirtualKey)keystroke.VirtualKey;
        controllerData->KeystrokState = (KeystrokeFlags)keystroke.Flags;
        // WCHAR Unicode;always 0
        // BYTE  UserIndex;
        // BYTE  HidCode;
    }

    internal static void VibrationEffectXInput(ControllerData* controllerData, ushort leftMotor, ushort rightMotor)
    {
        XINPUT_VIBRATION vibration = default;
        vibration.wLeftMotorSpeed = Clamp(leftMotor, 0, controllerData->LeftMotorSpeedMax); // use any value between 0-65535 here
        vibration.wRightMotorSpeed = Clamp(rightMotor, 0, controllerData->RightMotorSpeedMax); // use any value between 0-65535 here
        _ = XInputSetState(controllerData->Id, &vibration);
    }

    //Circular DeadZone (https://github.com/microsoft/DirectXTK/blob/main/Src/GamePad.cpp)
    public const float XboxOneThumbDeadZone = 0.24f;  // Recommended Xbox One controller deadzone
    private static float ApplyLinearDeadZone(float value, float maxValue, float deadZoneSize)
    {
        if (value < -deadZoneSize)
        {
            // Increase negative values to remove the deadzone discontinuity.
            value += deadZoneSize;
        }
        else if (value > deadZoneSize)
        {
            // Decrease positive values to remove the deadzone discontinuity.
            value -= deadZoneSize;
        }
        else
        {
            // Values inside the deadzone come out zero.
            return 0;
        }

        // Scale into 0-1 range.
        float scaledValue = value / (maxValue - deadZoneSize);
        return Math.Max(-1.0f, Math.Min(scaledValue, 1.0f));
    }


    //Linear DeadZone
    private static void ApplyCircularDeadZone(float x,float y, float maxValue, float deadZoneSize,float* resultX, float* resultY) 
    {

        float dist = Math.Sqrt( x*x + y * y);
        float wanted = ApplyLinearDeadZone(dist, maxValue, deadZoneSize);

        float scale = (wanted > 0.0f) ? (wanted / dist) : 0.0f;

        *resultX = Math.Max(-1.0f, Math.Min(x * scale, 1.0f));
        *resultY = Math.Max(-1.0f, Math.Min(y * scale, 1.0f));
    }

    public static void ApplyStickDeadZone( float x, float y, int deadZoneMode, float maxValue,  float deadZoneSize,float* resultX, float* resultY) 
    {
        switch (deadZoneMode)
        {

            case 0://GamePad::DEAD_ZONE_INDEPENDENT_AXES:
            *resultX = ApplyLinearDeadZone(x, maxValue, deadZoneSize);
            *resultY = ApplyLinearDeadZone(y, maxValue, deadZoneSize);
            break;

            case 1://GamePad::DEAD_ZONE_CIRCULAR:
            {
                float dist = Math.Sqrt(x*x + y * y);
                float wanted = ApplyLinearDeadZone(dist, maxValue, deadZoneSize);

                float scale = (wanted > 0.0f) ? (wanted / dist) : 0.0f;

                *resultX = Math.Max(-1.0f, Math.Min(x * scale, 1.0f));
                *resultY = Math.Max(-1.0f, Math.Min(y * scale, 1.0f));
            }
            break;

        default: // GamePad::DEAD_ZONE_NONE
            *resultX = ApplyLinearDeadZone(x, maxValue, deadZoneSize);
            *resultY = ApplyLinearDeadZone(y, maxValue, deadZoneSize);
            break;
        }
    }

    internal static void StopFeedbackXInput(ControllerData* controllerData)
    {
        VibrationEffectXInput(controllerData, 0, 0);
    }

    // internal static float DeadZone(float x, float deadzone = 0.24f, float max = 1.0f)// var value = x < -max ? -max : x > max ? max : x;
    //     => x > -deadzone && x < deadzone ? 0 : x;

	internal static void MapControllerButtonsToXbox360(ControllerData* controllerData)
    {
        controllerData->Buttons[(int)ControllerButton.A] = ControllerConsts.XINPUT_GAMEPAD_A;
        controllerData->Buttons[(int)ControllerButton.B] = ControllerConsts.XINPUT_GAMEPAD_B;
        controllerData->Buttons[(int)ControllerButton.X] = ControllerConsts.XINPUT_GAMEPAD_X;
        controllerData->Buttons[(int)ControllerButton.Y] = ControllerConsts.XINPUT_GAMEPAD_Y;
        controllerData->Buttons[(int)ControllerButton.Start] = ControllerConsts.XINPUT_GAMEPAD_START;
        controllerData->Buttons[(int)ControllerButton.Back] = ControllerConsts.XINPUT_GAMEPAD_BACK;
        controllerData->Buttons[(int)ControllerButton.RightShoulder] = ControllerConsts.XINPUT_GAMEPAD_RIGHT_SHOULDER;
        controllerData->Buttons[(int)ControllerButton.LeftShoulder] = ControllerConsts.XINPUT_GAMEPAD_LEFT_SHOULDER;
        controllerData->Buttons[(int)ControllerButton.RightThumb] = ControllerConsts.XINPUT_GAMEPAD_RIGHT_THUMB;
        controllerData->Buttons[(int)ControllerButton.LefThumb] = ControllerConsts.XINPUT_GAMEPAD_LEFT_THUMB;

        // controllerData->Buttons[(int)ControllerButton.LefThumb] = XU;
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


internal static class ControllerConsts
{
    internal const int XUSER_INDEX_ANY = 0x000000FF;
    internal const int XUSER_MAX_COUNT = 4;

    internal const uint XINPUT_GAMEPAD_DPAD_UP = 0x0001;
    internal const uint XINPUT_GAMEPAD_DPAD_DOWN = 0x0002;
    internal const uint XINPUT_GAMEPAD_DPAD_LEFT = 0x0004;
    internal const uint XINPUT_GAMEPAD_DPAD_RIGHT = 0x0008;
    internal const uint XINPUT_GAMEPAD_START = 0x0010;
    internal const uint XINPUT_GAMEPAD_BACK = 0x0020;
    internal const uint XINPUT_GAMEPAD_LEFT_THUMB = 0x0040;
    internal const uint XINPUT_GAMEPAD_RIGHT_THUMB = 0x0080;
    internal const uint XINPUT_GAMEPAD_LEFT_SHOULDER = 0x0100;
    internal const uint XINPUT_GAMEPAD_RIGHT_SHOULDER = 0x0200;
    internal const uint XINPUT_GAMEPAD_A = 0x1000;
    internal const uint XINPUT_GAMEPAD_B = 0x2000;
    internal const uint XINPUT_GAMEPAD_X = 0x4000;
    internal const uint XINPUT_GAMEPAD_Y = 0x8000;
    internal const uint XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE = 7849;
    internal const uint XINPUT_GAMEPAD_RIGHT_THUMB_DEADZONE = 8689;
    internal const uint XINPUT_GAMEPAD_TRIGGER_THRESHOLD = 30;
    internal const uint XINPUT_FLAG_GAMEPAD = 0x00000001;

    internal const int BATTERY_DEVTYPE_GAMEPAD = 0x00;
    internal const int BATTERY_DEVTYPE_HEADSET = 0x01;
}


[StructLayout(LayoutKind.Sequential)]
internal partial struct XINPUT_BATTERY_INFORMATION
{
    internal byte BatteryType;
    internal byte BatteryLevel;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XINPUT_CAPABILITIES
{
    internal byte Type;
    internal byte SubType;
    internal ushort Flags;
    internal XINPUT_GAMEPAD Gamepad;
    internal XINPUT_VIBRATION Vibration;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XINPUT_GAMEPAD
{
    internal ushort wButtons;
    internal byte bLeftTrigger;
    internal byte bRightTrigger;
    internal short sThumbLX;
    internal short sThumbLY;
    internal short sThumbRX;
    internal short sThumbRY;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XINPUT_KEYSTROKE
{
    internal ushort VirtualKey;
    internal ushort Unicode;
    internal ushort Flags;
    internal byte UserIndex;
    internal byte HidCode;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XINPUT_STATE
{
    internal uint dwPacketNumber;
    internal XINPUT_GAMEPAD Gamepad;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XINPUT_VIBRATION
{
    internal ushort wLeftMotorSpeed;
    internal ushort wRightMotorSpeed;
}

internal enum CapabilitiesDevType
{
    XINPUT_DEVTYPE_GAMEPAD = 0x01
}

internal enum CapabilitiesDevSubType : uint
{
    XINPUT_DEVSUBTYPE_GAMEPAD = 0x01,
    XINPUT_DEVSUBTYPE_UNKNOWN = 0x00,
    XINPUT_DEVSUBTYPE_WHEEL = 0x02,
    XINPUT_DEVSUBTYPE_ARCADE_STICK = 0x03,
    XINPUT_DEVSUBTYPE_FLIGHT_STICK = 0x04,
    XINPUT_DEVSUBTYPE_DANCE_PAD = 0x05,
    XINPUT_DEVSUBTYPE_GUITAR = 0x06,
    XINPUT_DEVSUBTYPE_GUITAR_ALTERNATE = 0x07,
    XINPUT_DEVSUBTYPE_DRUM_KIT = 0x08,
    XINPUT_DEVSUBTYPE_GUITAR_BASS = 0x0B,
    XINPUT_DEVSUBTYPE_ARCADE_PAD = 0x13,
}

internal enum CapabilitieFeatures : uint
{
    XINPUT_CAPS_VOICE_SUPPORTED = 0x0004,
    XINPUT_CAPS_FFB_SUPPORTED = 0x0001,
    XINPUT_CAPS_WIRELESS = 0x0002,
    XINPUT_CAPS_PMD_SUPPORTED = 0x0008,
    XINPUT_CAPS_NO_NAVIGATION = 0x0010,
}

internal enum KeystrokeFlags : uint
{
    XINPUT_KEYSTROKE_KEYDOWN = 0x0001,
    XINPUT_KEYSTROKE_KEYUP = 0x0002,
    XINPUT_KEYSTROKE_REPEAT = 0x0004
}

internal enum VirtualKey : uint
{
    VK_PAD_A = 0x5800,
    VK_PAD_B = 0x5801,
    VK_PAD_X = 0x5802,
    VK_PAD_Y = 0x5803,
    VK_PAD_RSHOULDER = 0x5804,
    VK_PAD_LSHOULDER = 0x5805,
    VK_PAD_LTRIGGER = 0x5806,
    VK_PAD_RTRIGGER = 0x5807,
    VK_PAD_DPAD_UP = 0x5810,
    VK_PAD_DPAD_DOWN = 0x5811,
    VK_PAD_DPAD_LEFT = 0x5812,
    VK_PAD_DPAD_RIGHT = 0x5813,
    VK_PAD_START = 0x5814,
    VK_PAD_BACK = 0x5815,
    VK_PAD_LTHUMB_PRESS = 0x5816,
    VK_PAD_RTHUMB_PRESS = 0x5817,
    VK_PAD_LTHUMB_UP = 0x5820,
    VK_PAD_LTHUMB_DOWN = 0x5821,
    VK_PAD_LTHUMB_RIGHT = 0x5822,
    VK_PAD_LTHUMB_LEFT = 0x5823,
    VK_PAD_LTHUMB_UPLEFT = 0x5824,
    VK_PAD_LTHUMB_UPRIGHT = 0x5825,
    VK_PAD_LTHUMB_DOWNRIGHT = 0x5826,
    VK_PAD_LTHUMB_DOWNLEFT = 0x5827,
    VK_PAD_RTHUMB_UP = 0x5830,
    VK_PAD_RTHUMB_DOWN = 0x5831,
    VK_PAD_RTHUMB_RIGHT = 0x5832,
    VK_PAD_RTHUMB_LEFT = 0x5833,
    VK_PAD_RTHUMB_UPLEFT = 0x5834,
    VK_PAD_RTHUMB_UPRIGHT = 0x5835,
    VK_PAD_RTHUMB_DOWNRIGHT = 0x5836,
    VK_PAD_RTHUMB_DOWNLEFT = 0x5837,
}

internal enum BatteryTypeInformation : uint
{
    BATTERY_TYPE_DISCONNECTED = 0x00,
    BATTERY_TYPE_WIRED = 0x01,
    BATTERY_TYPE_ALKALINE = 0x02,
    BATTERY_TYPE_NIMH = 0x03,
    BATTERY_TYPE_UNKNOWN = 0xFF,
}

internal enum BatteryLevelInformation : uint
{
    BATTERY_LEVEL_EMPTY = 0x00,
    BATTERY_LEVEL_LOW = 0x01,
    BATTERY_LEVEL_MEDIUM = 0x02,
    BATTERY_LEVEL_FULL = 0x03,
}

#endif
