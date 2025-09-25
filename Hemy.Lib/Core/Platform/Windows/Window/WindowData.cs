#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Window;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct WindowData()
{
    internal fixed byte GameName[256];
    internal fixed byte EngineName[16];
    internal void* Handle = null;
    internal void* HInstance = null;
    internal int Width = 1280;
    internal int Height = 720;
    internal bool IsRunning = false;
    internal bool IsInPaused = false; 

    /*Replace bool by one uint  State : 0  Disposed , 2 Init Stopped 3 Running 4 Paused  0xFFFFFFFF Error   */
}

#endif
