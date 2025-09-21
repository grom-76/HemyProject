/**/
namespace Hemy.Lib.Core.Sys;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Hemy.Lib.Core.Input;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct TriggerData(string id, int type, byte key, ulong duration_ms, int loop, delegate* unmanaged<byte, bool> inputEvent, delegate* unmanaged<void> actionExecute)
{
    public delegate* unmanaged<void> ActionExecute = (delegate* unmanaged<void>)actionExecute;
    public delegate* unmanaged<byte, bool> InputAction = (delegate* unmanaged<byte, bool>)inputEvent;
    public ulong Id = Triggers.BytesToULong(id);
    public ulong StartTime = 0;
    public ulong Duration = duration_ms;
    public int Loop = 0;
    public int LoopCount = loop;
    public int Type = type;
    public byte Key = key;  

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public override string ToString()
        => $"Id {UlongToStr(Id)} : Key {Key} StartTime {StartTime} Duration {Duration} LoopCount {LoopCount} MaxLoop {Loop} Type {Type} ";

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    private static string UlongToStr(ulong mot)
    {
        string result = string.Empty;
        char c1 = (char)((mot >> 56) & 0xFF);
        char c2 = (char)((mot >> 48) & 0xFF);
        char c3 = (char)((mot >> 40) & 0xFF);
        char c4 = (char)((mot >> 32) & 0xFF);
        char c5 = (char)((mot >> 24) & 0xFF);
        char c6 = (char)((mot >> 16) & 0xFF);
        char c7 = (char)((mot >> 8) & 0xFF);
        char c8 = (char)((mot >> 0) & 0xFF);
        result += c8 == '\0' ? "" : c8;
        result += c7 == '\0' ? "" : c7;
        result += c6 == '\0' ? "" : c6;
        result += c5 == '\0' ? "" : c5;
        result += c4 == '\0' ? "" : c4;
        result += c3 == '\0' ? "" : c3;
        result += c2 == '\0' ? "" : c2;
        result += c1 == '\0' ? "" : c1;
        return result;
    }
}
