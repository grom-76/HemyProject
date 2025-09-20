namespace Hemy.Lib.Core.Window;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System;


[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe sealed class WindowSettings() : IDisposable
{
    public WindowResolution Resolution = WindowResolution.HD_720p_1280x720;
    public WindowStyle Style = WindowStyle.standard;
    public string GameName = "My First Game ";

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
