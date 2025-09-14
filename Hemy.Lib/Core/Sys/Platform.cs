namespace Hemy.Lib.Core.Sys;
#if WINDOWS
/// <summary> liste des platforms disponible </summary>
public enum Platform : byte
{
    AutoDetect = byte.MaxValue,
    Unknow = 0,
    Window = 1,
    Linux = 2,
    Mac = 3,
    IOS = 4,
    Android = 5,
    WEB = 6,
    PS2 = 7,
    NES = 8,
    SWITCH = 9,
    MEGADRIVE = 10,
    UWP = 11,
    ATARIST,
}
