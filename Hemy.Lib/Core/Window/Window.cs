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


#endif

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]    
public unsafe sealed class Window : IDisposable
{
#if WINDOWS
    private WindowData* _windowData = null;
    private GraphicData* _graphicData = null;
    private AudioData* _audioData = null;
    private TimeData* _timeData = null;
    private InputData* _inputData = null;
#else
#endif
    private bool _isDisposed = false;

    [SkipLocalsInit]
    public Keyboard Keyboard
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization| MethodImplOptions.AggressiveInlining)]
        get;
    }

    [SkipLocalsInit]
    public Window()
    {
#if WINDOWS
        _windowData = Memory.Memory.New<WindowData>(true);
        _graphicData = Memory.Memory.New<GraphicData>(true);
        _audioData = Memory.Memory.New<AudioData>(true);
        _timeData = Memory.Memory.New<TimeData>(true);
        _inputData = Memory.Memory.New<InputData>(true);


        Keyboard = new(_inputData);
#endif
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public void CreateWindow()
    {
#if WINDOWS
        WindowImpl.Init(_windowData, null, (delegate* unmanaged<void*, uint, uint*, long*, long*>)Marshal.GetFunctionPointerForDelegate(WindowProcMessages));
        GraphicImpl.Init(_graphicData, _windowData);

        RenderImpl.CreateRenderPass(_graphicData);
        RenderImpl.CreateRender(_graphicData);

        AudioImpl.Init(_audioData);
        InputImpl.MapKeys(_inputData, 0);

        WindowImpl.Show(_windowData);
        TimeImpl.Start(_timeData);
#endif

    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool IsRunning()
#if WINDOWS 
        => _windowData->IsRunning;
#else
        => false;
#endif

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public void RequestClose()
    {
#if WINDOWS
        WindowImpl.RequestClose(_windowData);
#else
        
#endif
    }


    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public void TestingDraw()
#if WINDOWS 
        => RenderImpl.Draw(_graphicData);
#else
        => false;
#endif

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public void Dispose()
    {
        if (_isDisposed) return;

#if WINDOWS
        
        AudioImpl.Dispose(_audioData);
        GraphicImpl.Dispose(_graphicData);
        WindowImpl.Dispose(_windowData);

        Memory.Memory.Dispose(_windowData);
        Memory.Memory.Dispose(_graphicData);
        Memory.Memory.Dispose(_audioData);
        Memory.Memory.Dispose(_timeData);
        Memory.Memory.Dispose(_inputData);
#endif

        _isDisposed = true;

        GC.SuppressFinalize(this);
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public void Update()
    {
#if WINDOWS
        WindowImpl.Update(_windowData);
        TimeImpl.Update(_timeData);
        InputImpl.UpdateInput(_inputData);
#endif
    }

#if WINDOWS
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    private long* WindowProcMessages(void* hWnd, uint message, uint* wParam, long* lParam) // ProcesEvents
    {
        switch (message)
        {
            // case WM_QUIT:
            case WM_CLOSE:
                Hemy.Lib.Core.Platform.Windows.Window.WindowImpl.PostQuitMessage(0);
                _windowData->IsRunning = false;
                // _eventsData->OnQuit(wParam, lParam);
                return null;

            case WM_SIZE:
                // TODO AdjustWindowSize ( Wide Screen => 16/9 )
                // int width = Utils.GET_WIDTH(lParam);
                // int height = Utils.GET_HEIGHT(lParam);
                return null;

            case WM_KEYDOWN:
            case WM_SYSKEYDOWN:
            case WM_KEYUP:
            case WM_SYSKEYUP:

                return Hemy.Lib.Core.Platform.Windows.Window.WindowImpl.DefWindowProcA(hWnd, message, wParam, lParam);

            case WM_LBUTTONDOWN:
            case WM_RBUTTONDOWN:
            case WM_MBUTTONDOWN:
            case WM_XBUTTONDOWN:
            case WM_LBUTTONUP:
            case WM_RBUTTONUP:
            case WM_MBUTTONUP:
            case WM_XBUTTONUP:

                return null;

            case WM_MOUSEMOVE:

                return null;

            case WM_MOUSELEAVE:
                // STOP TRACKING MOUSE ?
                return null;

            case WM_MOUSEWHEEL:

                return null;
            case WM_MOUSEHWHEEL:

                return null;

            case WM_INPUT:
                // RAW iNPUT
                return Hemy.Lib.Core.Platform.Windows.Window.WindowImpl.DefWindowProcA(hWnd, message, wParam, lParam);

            case WM_KILLFOCUS:

                return null;

            case WM_SETFOCUS:

                return null;

            case WM_SYSCOMMAND:

                return Hemy.Lib.Core.Platform.Windows.Window.WindowImpl.DefWindowProcA(hWnd, message, wParam, lParam);

            case WM_CHAR:
            case WM_SYSCHAR:

                return null;

            default:
                return Hemy.Lib.Core.Platform.Windows.Window.WindowImpl.DefWindowProcA(hWnd, message, wParam, lParam);
        }
    }
#endif    
}