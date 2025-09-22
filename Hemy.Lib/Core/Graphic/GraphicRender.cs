namespace Hemy.Lib.Core.Graphic;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Hemy.Lib.Core.Color;
using Hemy.Lib.Core.Platform.Windows.Graphic;
using Hemy.Lib.Core.Platform.Windows.Window;


[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct GraphicRender(
#if WINDOWS
        GraphicData* graphicData,
        WindowData* windowData
#endif
)
{
    // GraphicRenderSettings  => change RenderPass Values 

    public void Add(Shape2D shape)
    {
        // see if shader exist else  create One 

    }


    public void BuildRender()
    {
        //CreatePipeline  redo RenderPass ..... 

    }

    public void Draw(Palette clearColor)
    {
#if WINDOWS
        if (windowData->SysPaused) return;
        RenderImpl.ChangeBackGroundColor(graphicData, (uint)clearColor);
        RenderImpl.Draw(graphicData);
#endif
    }

    public void Dispose()
    {
        
    }
}