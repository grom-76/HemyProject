/**/
namespace Hemy.Lib.Core.Sys;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TriggerData()
{
    public delegate* unmanaged<void> ActionExecute = null;//(delegate* unmanaged<void>)Marshal.GetFunctionPointerForDelegate(action) ; 
    public delegate* unmanaged<byte, bool> InputAction = null;
    public ulong Id = 0;
    public ulong StartTime = 0;
    public ulong Duration = 0;
    public int Loop = 0;
    public int LoopCount = 0;
    public int Type = 0;
    public byte Key = 0;  // correspond MouseButton, Keys, Joystick_Button

    public override string ToString()
    {
        return $"Id {Id} : Key {Key} StartTime {StartTime} Duration {Duration} LoopCount {LoopCount} MaxLoop {Loop} Type {Type} ";
    }

  
}
