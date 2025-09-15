#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Monitor;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MonitorData()
{
    internal bool IsPrimary = true;
    internal int ScreenWidth = 0;
    internal int ScreenHeight = 0;
    internal int ScreenLeft = 0;
    internal int ScreenTop = 0;
}


#endif