#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Window;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal unsafe struct WindowData()
{
    internal fixed byte GameName[256];
    internal fixed byte EngineName[16];
    internal bool IsRunning = false;
    internal void* Handle = null;
    internal void* HInstance = null;
    internal int Width = 1280;
    internal int Height = 720;
}



#endif
