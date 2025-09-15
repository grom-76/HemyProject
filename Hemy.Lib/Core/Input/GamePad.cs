namespace Hemy.Lib.Core.Input;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#if WINDOWS
using Hemy.Lib.Core.Platform.Windows.Input;
#endif

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe readonly struct GamePad(
#if WINDOWS    
    ControllerData* data, uint player
#endif    
    )
{
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsPressed(ControllerButton button)
        => (data->Current[player] & data->Buttons[(int)button + (player * 32)]) != 0
            && (data->Previous[player] & data->Buttons[(int)button + (player * 32)]) == 0 ;
    
    
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsDown(int button) => (data->Current[player] & data->Buttons[(int)button + (player * 32)]) != 0
            && (data->Previous[player] & data->Buttons[(int)button + (player * 32)]) != 0 ;

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsReleased(int button) => (data->Current[player] & data->Buttons[(int)button + (player * 32)]) == 0
            && (data->Previous[player] & data->Buttons[(int)button + (player * 32)]) != 0 ;

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsUp(int button) => (data->Current[player] & data->Buttons[(int)button + (player * 32)]) == 0
            && (data->Previous[player] & data->Buttons[(int)button + (player * 32)]) == 0 ;

    [SkipLocalsInit]
    public float StickRight_X => data->Right_X[player];
    [SkipLocalsInit]
    public float StickRight_Y => data->Right_Y[player];
    [SkipLocalsInit]
    public float StickLeft_X => data->Left_X[player];
    [SkipLocalsInit]
    public float StickLeft_Y => data->Left_Y[player];
    [SkipLocalsInit]
    public float TriggerLeft => data->Left_Trigger[player];
    [SkipLocalsInit]
    public float TriggerRight => data->Right_Trigger[player];

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public void SetVibration(float leftMotor, float rightMotor)
    {
#if WINDOWS
        ControllerImpl.SetVibration(data, player, leftMotor, rightMotor);
#endif
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public void SuspendVibration()
    {
#if WINDOWS
        ControllerImpl.SetVibration(data, player, 0.0f, 0.0f);
#endif
    }

    public void ResumeVibration(ushort leftMotor, ushort rightMotor)
    {
#if WINDOWS
        ControllerImpl.ResumeVibration(data, player, leftMotor, rightMotor);
#endif
    }

    [SkipLocalsInit]
    public bool IsLeftStickMove => data->Left_X[player] > 0.0f && data->Left_Y[player] > 0.0f;
    [SkipLocalsInit]
    public bool IsRightStickMove => data->Right_X[player] > 0.0f && data->Right_Y[player] > 0.0f;
    [SkipLocalsInit]
    public bool IsTriggerPressed => data->Left_Trigger[player] > 0.0f && data->Right_Trigger[player] > 0.0f;
    [SkipLocalsInit]
    public bool IsConntected => data->IsConntected[player];
    
    //     //public string GetJoytickName(int id ){ return "NoName";} // TODO : GetJoystickNAme
    //     //     // is Connected 
    //     //     // GetCapabilites

}
