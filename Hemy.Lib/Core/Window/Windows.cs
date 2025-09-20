namespace Hemy.Lib.Core.Window;

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
[StructLayout(LayoutKind.Sequential)]
public unsafe sealed class Window(
#if WINDOWS
    WindowData* data
#endif    
    )
{

    public WindowSettings Settings = new();

    public void SetTitle(string title)
    {
#if WINDOWS
        WindowImpl.UpdateCaptionTitleBar(data, title);
#endif    
    }

    public void RequestClose()
    {
#if WINDOWS
        WindowImpl.RequestClose(data);
#else        
#endif  
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsRunning()
#if WINDOWS 
        => data->IsRunning;
#else
        => false;
#endif

    internal void Dispose()
    {
        Settings.Dispose();
    }


}