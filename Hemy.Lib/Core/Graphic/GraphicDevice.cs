namespace Hemy.Lib.Core.Graphic;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Hemy.Lib.Core.Color;
using Hemy.Lib.Core.Platform.Windows.Graphic;
using Hemy.Lib.Core.Platform.Windows.Window;


[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public readonly unsafe struct GraphicDevice
{
    private readonly GraphicData* _graphicData = null;
    private readonly WindowData* _windowData = null;
    private readonly GraphicRender* _render = null;


    public GraphicDevice(
#if WINDOWS
        GraphicData* graphicData,
        WindowData* windowData
#endif
)
    {
        Settings = new();
        _graphicData = graphicData;
        _windowData = windowData;

        _render = Memory.Memory.New<GraphicRender>(false);
        GraphicRender temp = new(graphicData, windowData);
        Memory.Memory.Copy(Memory.Memory.ToPtr(ref temp), _render, (uint)Memory.Memory.Size<GraphicRender>());
        temp.Dispose();
    }


    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public readonly void TestingDraw(Palette screenColor)
    {
#if WINDOWS
        if (_windowData->SysPaused) return;

        RenderImpl.ChangeBackGroundColor(_graphicData, (uint)screenColor);
        RenderImpl.Draw(_graphicData);
#else
        
#endif

    }

    internal readonly void Dispose()
    {
        _render->Dispose();
        Settings.Dispose();

        Memory.Memory.Dispose(_render);
    }

    [SkipLocalsInit]
    public readonly GraphicRender GraphicRender => *_render;

    [SkipLocalsInit]
    public GraphicDeviceSettings Settings
    {
        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        get;
    }

    public readonly uint Width => _graphicData->RenderPassArea->extent.width;
    public readonly uint Height => _graphicData->RenderPassArea->extent.height;
    public readonly ClipVolume ClipVolume => ClipVolume.NegativeOneToPlusOne;
    public readonly Handled Handled => Handled.RightHand;
    public readonly ScreenOrigin ScreenOrigin => ScreenOrigin.lowerLeft;

    public readonly int WindowWidth => _windowData->Width;
    public readonly int WindowHeight => _windowData->Height;

}