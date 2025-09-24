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
using Hemy.Lib.Core.Sys;
using Hemy.Lib.Core.Graphic;

#endif

/// <summary>
/// Entrypoint for coding like monogame
/// </summary>
[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public unsafe abstract class Base : IDisposable
{
   
#if WINDOWS
    private WindowData* _windowData = null;
    private GraphicData* _graphicData = null;
    private AudioData* _audioData = null;
    private TimeData* _timeData = null;
    private InputData* _inputData = null;
    private ControllerData* _controllers = null;
    private MonitorData* _monitorData = null;
#else

#endif

    private bool _isDisposed = false;
    
    [SkipLocalsInit]
    public Keyboard Keyboard
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        get;
    }
    [SkipLocalsInit]
    public Mouse Mouse
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        get;
    }

    [SkipLocalsInit]
    public Time Time
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        get;
    }

    [SkipLocalsInit]
    public GamePad GetGamePad(ControlerPlayer player) => new(_controllers, (uint)player);

    [SkipLocalsInit]
    public AudioDevice AudioDevice
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        get ;
    }

    [SkipLocalsInit]
    public Window.Window Window
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        get ;
    }


    [SkipLocalsInit]
    public Triggers Triggers  {
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        get ;
    }

    [SkipLocalsInit]
    public GraphicDevice GraphicDevice
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        get ;
    }

    [SkipLocalsInit]
    public Base()
    {
#if WINDOWS
        _windowData = Memory.Memory.New<WindowData>(true);
        _graphicData = Memory.Memory.New<GraphicData>(true);
        _audioData = Memory.Memory.New<AudioData>(true);
        _timeData = Memory.Memory.New<TimeData>(true);
        _inputData = Memory.Memory.New<InputData>(true);
        _controllers = Memory.Memory.New<ControllerData>(true);
        _monitorData = Memory.Memory.New<MonitorData>(true);

        GraphicDevice = new(_graphicData, _windowData);
        Mouse = new(_inputData);
        Keyboard = new(_inputData);
        AudioDevice = new(_audioData);
        Window = new(_windowData);
        Time = new(_timeData);
        Triggers = new(_timeData);
#endif

    }

    public void Dispose()
    {
        if (_isDisposed) return;

#if WINDOWS
        

        AudioImpl.Dispose(_audioData);
        GraphicDeviceImpl.Dispose(_graphicData);
        WindowImpl.Dispose(_windowData);

        Memory.Memory.Dispose(_windowData);
        Memory.Memory.Dispose(_graphicData);
        Memory.Memory.Dispose(_audioData);
        Memory.Memory.Dispose(_timeData);
        Memory.Memory.Dispose(_inputData);
        Memory.Memory.Dispose(_controllers);
        Memory.Memory.Dispose(_monitorData);

        Triggers.Dispose();
#endif

        _isDisposed = true;

        Log.Info(" Memory remaining : " + Memory.Memory.RemainingmEMORY);

        GC.SuppressFinalize(this);

        GC.Collect(GC.MaxGeneration);
        GC.WaitForPendingFinalizers();
    }

    public void Run()
    {

        InternalInit();
        //our init
        Init();
        while (Window.IsRunning())
        {
            InternalUpdate();
            // our update
            Update();

            Draw();
            // GraphicDevice.TestingDraw(Palette.DarkBlue);
        }

    }

    protected abstract void Init();
    protected abstract void Release();
    protected abstract void Update();
    protected abstract void Draw();


    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    private void InternalInit()
    {
#if WINDOWS
        //Convert  settings to internal window settings 
        Platform.Windows.Window.WindowsSettings* settings = Memory.Memory.New<Platform.Windows.Window.WindowsSettings>();

        Platform.Windows.Window.WindowsSettings.Binding(settings, Window.Settings );

        WindowImpl.Init(_windowData, _monitorData, settings, (delegate* unmanaged<void*, uint, uint*, long*, long*>)Marshal.GetFunctionPointerForDelegate(WindowProcMessages));
        GraphicDeviceImpl.Init(_graphicData, _windowData);

        GraphicRenderImpl.CreateRenderPass(_graphicData);
        GraphicRenderImpl.CreateRender(_graphicData);
        AudioImpl.Init(_audioData);
        InputImpl.Init(_inputData, _windowData->Handle, 0);
        ControllerImpl.Init(_controllers);
       
        Memory.Memory.Dispose(settings);

        WindowImpl.Show(_windowData);
        TimeImpl.Init(_timeData);
#endif
    }



    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    private void InternalUpdate()
    {
#if WINDOWS
        WindowImpl.Update(_windowData);

        if (_windowData->IsInPaused) return;

        TimeImpl.Update(_timeData);

        InputImpl.UpdateInput(_inputData);

        ControllerImpl.Update(_controllers);

        Triggers.Update();
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
                int width =  Hemy.Lib.Core.Platform.Windows.Utils.GET_WIDTH(lParam);
                int height =  Hemy.Lib.Core.Platform.Windows.Utils.GET_HEIGHT(lParam);
                _windowData->Width = width; _windowData->Height = height;

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
                // STOP TRACKING MOUSE ? // App in pause 
                Log.Info("Mouse Leave Window");
                return null;

            case WM_MOUSEWHEEL:

                return null;
            case WM_MOUSEHWHEEL:

                return null;

            case WM_INPUT:
                // RAW iNPUT
                return Hemy.Lib.Core.Platform.Windows.Window.WindowImpl.DefWindowProcA(hWnd, message, wParam, lParam);

            case WM_KILLFOCUS:
                Log.Info("App Kill Focus ");
                return null;

            case WM_SETFOCUS:
                Log.Info("App Set Focus ");
                return null;

            case WM_SYSCOMMAND:

                return Hemy.Lib.Core.Platform.Windows.Window.WindowImpl.DefWindowProcA(hWnd, message, wParam, lParam);

            case WM_CHAR:
            case WM_SYSCHAR:

                return null;
            case WM_ACTIVATEAPP:
                // https://learn.microsoft.com/en-us/windows/win32/api/xinput/nf-xinput-xinputenable 

                return null; 
            default:
                return Hemy.Lib.Core.Platform.Windows.Window.WindowImpl.DefWindowProcA(hWnd, message, wParam, lParam);
        }
    }
#endif    

}
