namespace Hemy.Lib.Core;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System;

#if WINDOWS
using Hemy.Lib.Core.Platform.Windows.Window;
using Hemy.Lib.Core.Platform.Windows.Graphic;
using static Hemy.Lib.Core.Platform.Windows.Window.WindowConsts;
using Hemy.Lib.Core.Platform.Windows.Audio;
using Hemy.Lib.Core.Platform.Windows.Sys;
using Hemy.Lib.Core.Platform.Windows.Input;
using Hemy.Lib.Core.Input;
using Hemy.Lib.Core.Platform.Windows.Monitor;
using Hemy.Lib.Core.Color;
using Hemy.Lib.Core.Audio;

#endif

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public unsafe sealed class Settings : IDisposable
{
    public Hemy.Lib.Core.Window.WindowResolution Resolution = Window.WindowResolution.HD_720p_1280x720;
    public Window.WindowStyle Style = Window.WindowStyle.standard;
    public string GameName = "My First Game ";

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
