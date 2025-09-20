namespace Hemy.Lib.Core.Graphic;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Hemy.Lib.Core.Color;
using Hemy.Lib.Core.Platform.Windows.Graphic;
using Hemy.Lib.Core.Platform.Windows.Window;


[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct GraphicDevice
{
    private readonly GraphicData* _graphicData = null;
    private readonly WindowData* _windowData = null;
    
    public GraphicDevice(
#if WINDOWS
        GraphicData* graphicData,
        WindowData* windowData
#endif
)
    {
        _graphicData = graphicData;
        _windowData = windowData;
        GraphicRender = new(_graphicData, _windowData);
        Settings = new();
    }


    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public void TestingDraw(Palette screenColor)
    {
#if WINDOWS
        if (_windowData->SysPaused) return;

        RenderImpl.ChangeBackGroundColor(_graphicData, (uint)screenColor);
        RenderImpl.Draw(_graphicData);
#else
        
#endif

    }

    internal void Dispose()
    {
        // GraphicRender.Dispose();
        Settings.Dispose();
    }

    [SkipLocalsInit]
    public GraphicRender GraphicRender
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        get;
    }
    
    [SkipLocalsInit]
    public GraphicDeviceSettings Settings  {
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        get ;
    }

    public uint Width => _graphicData->RenderPassArea->extent.width;
    public uint Height => _graphicData->RenderPassArea->extent.height;
    public ClipVolume ClipVolume = ClipVolume.NegativeOneToPlusOne;
    public Handled Handled = Handled.RightHand;
    public ScreenOrigin ScreenOrigin = ScreenOrigin.lowerLeft;

}