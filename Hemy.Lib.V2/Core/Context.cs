namespace Hemy.Lib.V2.Core;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

#if WINDOWS
using Hemy.Lib.V2.Platform.Windows;
#endif


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public static class Graphic
{
    public interface IGraphicDevice
    {

    }

    public interface IGraphicRender
    {

    }

}


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public static class Time
{
    public const ulong MiliSecond_Per_Second = 1000UL;
 
 

}

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public static class Monitor
{
    public enum Orientation
    {
        Vertical, Horizontal, Landscape
    }

}

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public sealed class ConntextSettings : IDisposable
{
    internal Window.WindowSettings window => new(this);
    internal GraphicSettings graphic => new(this);

    public Window.WindowSettings Window => window;
    public GraphicSettings Graphic => graphic;

    public void Dispose()
    {
        window.Dispose();
        graphic.Dispose();
        GC.SuppressFinalize(this);
    }


  
    
    public sealed class GraphicSettings(ConntextSettings ctx): IDisposable
    {
        internal string Title = "";

        public GraphicSettings SetBuffer(int doubleBuffered)
        {
            // ctx.Resolution = (uint)x;
            return this;
        }
        
        public ConntextSettings Build(){ return ctx; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public unsafe sealed class Context : IDisposable
{
    // only Context hawe new ....
    private readonly ConntextSettings settings = new();
    public ConntextSettings Settings => settings;


    [SkipLocalsInit]
    public Events.IEvents Events
    {
        [MethodImpl((MethodImplOptions)768), SkipLocalsInit, SuppressGCTransition, SuppressUnmanagedCodeSecurity]
        get;
    } = null;


    public Context()
    {
#if WINDOWS
        _data = WindowsMemory.New<WindowsData>();
        _events = WindowsMemory.New<WindowsEvents>();

        Events = *_events;
#endif



    }

    public void Create()
    {
#if WINDOWS
        // Binding client settings to specific platform 
#endif
        settings.Dispose();//sert à rien de garder ces valeurs en mémoire
    }

    public void Update()
    {
#if WINDOWS

#endif
    }

    public void Dispose()
    {
        // _windowSettings.Dispose();
#if WINDOWS

        WindowsMemory.Dispose(_data);
#endif
        GC.SuppressFinalize(this);
    }

#if WINDOWS

    private readonly WindowsData* _data = null;
    internal readonly WindowsEvents* _events = null;
    
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    private long* WindowProcMessages(void* hWnd, uint message, uint* wParam, long* lParam) // ProcesEvents
    {
        switch (message)
        {
            // case WM_QUIT:
            // case WM_CLOSE:
            //     Hemy.Lib.Core.Platform.Windows.Window.WindowImpl.PostQuitMessage(0);
            //     _windowData->IsRunning = false;
            //     // _eventsData->OnQuit(wParam, lParam);
            //     return null;

            // case WM_SIZE:
            //    { // TODO AdjustWindowSize ( Wide Screen => 16/9 )
            //     int width = Hemy.Lib.Core.Platform.Windows.Utils.GET_WIDTH(lParam);
            //     int height = Hemy.Lib.Core.Platform.Windows.Utils.GET_HEIGHT(lParam);
            //     _windowData->Width = width; _windowData->Height = height;}

            //     return null;

            // case WM_KEYDOWN:
            // case WM_SYSKEYDOWN:
            // case WM_KEYUP:
            // case WM_SYSKEYUP:

            //     return Hemy.Lib.Core.Platform.Windows.Window.WindowImpl.DefWindowProcA(hWnd, message, wParam, lParam);

            // case WM_LBUTTONDOWN:
            // case WM_RBUTTONDOWN:
            // case WM_MBUTTONDOWN:
            // case WM_XBUTTONDOWN:
            // case WM_LBUTTONUP:
            // case WM_RBUTTONUP:
            // case WM_MBUTTONUP:
            // case WM_XBUTTONUP:

            //     return null;

            // case WM_MOUSEMOVE:

            //     return null;

            // case WM_MOUSELEAVE:
            //     // STOP TRACKING MOUSE ? // App in pause 
            //     Log.Info("Mouse Leave Window");
            //     return null;

            // case WM_MOUSEWHEEL:

            //     return null;
            // case WM_MOUSEHWHEEL:

            //     return null;

            // case WM_INPUT:
            //     // RAW iNPUT
            //     return Hemy.Lib.Core.Platform.Windows.Window.WindowImpl.DefWindowProcA(hWnd, message, wParam, lParam);

            // case WM_KILLFOCUS:
            //    { Log.Info("App Kill Focus ");
            //     _windowData->IsInPaused = true;
            //     TimeImpl.Pause(_timeData);}
            //     return null;

            // case WM_SETFOCUS:
            //     {Log.Info("App Set Focus ");
            //     _windowData->IsInPaused = false;
            //     TimeImpl.Resume(_timeData);}
            //     return null;

            // case WM_SYSCOMMAND:

            //     return Hemy.Lib.Core.Platform.Windows.Window.WindowImpl.DefWindowProcA(hWnd, message, wParam, lParam);

            // case WM_CHAR:
            // case WM_SYSCHAR:

            //     return null;
            // case WM_ACTIVATEAPP:
            //     // https://learn.microsoft.com/en-us/windows/win32/api/xinput/nf-xinput-xinputenable  only Windows 10

            //     return null; 
            // case WM_DEVICECHANGE:
            //     InputImpl.OnInputDeviceChange(_inputData, _controllers);
            //     return Hemy.Lib.Core.Platform.Windows.Window.WindowImpl.DefWindowProcA(hWnd, message, wParam, lParam);
            //  case WM_DISPLAYCHANGE:
            //     MonitorImpl.OnMonitorChange(_monitorData);
            //     return Hemy.Lib.Core.Platform.Windows.Window.WindowImpl.DefWindowProcA(hWnd, message, wParam, lParam);

            default:
                return WindowsEventsImpl.DefWindowProcA(hWnd, message, wParam, lParam);
        }
    }


#endif
}
