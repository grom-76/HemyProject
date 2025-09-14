namespace Hemy.Lib.Core.Sys;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#if WINDOWS
using Hemy.Lib.Core.Platform.Windows.Sys;
#endif

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public unsafe static class Sys
{
    /// <summary> Os current  </summary> 
    public static Platform CurrentOsPlatform
#if WINDOWS    
     => SystemImpl.CurrentOsPlatform;
#endif
    /// <summary> Ram installé en GB </summary>
    public static ulong RAM
#if WINDOWS   
    => SystemImpl.InstalledMemory();
#endif
    /// <summary> Architecture system  ( <see> Is64Bits </see>) </summary>
    public static Architecture Architecture
#if WINDOWS
    => SystemImpl.GetArchitecture();
#endif
    /// <summary> Indique si le system est 64 bits ou non  </summary>
    public readonly static bool Is64Bit = System.IntPtr.Size * 8 == 64;// public static bool Is64Bit = System.Environment.Is64BitOperatingSystem;

    /// <summary> Indique si le system est en big endian  Byte : 0x00001  et non 0x1000 </summary>
    // public readonly static bool IsBigEndian = !System.BitConverter.IsLittleEndian;
    public readonly static bool IsBigEndian
#if WINDOWS
        = true;
#else
        = false;
#endif

    /// <summary> Retreive the current instance of process </summary>
    public unsafe static void* Hinstance
#if WINDOWS
    => SystemImpl.Hinstance;
#endif
    /// <summary>  For log get the id for this thread </summary>
    public static uint CurrentThreadId
#if WINDOWS
    => SystemImpl.CurrentThreadId;
#endif
    /// <summary>  get the id process to start   </summary>
    public static uint CurrentProcessId
#if WINDOWS
    => SystemImpl.CurrentProcessId;
#endif
    public static uint CurrentProcessor
#if WINDOWS
    => SystemImpl.CurrentProcessor;
#endif

}
