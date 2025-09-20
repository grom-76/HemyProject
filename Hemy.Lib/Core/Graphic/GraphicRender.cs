namespace Hemy.Lib.Core.Graphic;

using Hemy.Lib.Core.Color;
using Hemy.Lib.Core.Platform.Windows.Graphic;
using Hemy.Lib.Core.Platform.Windows.Window;

public unsafe struct GraphicRender(
#if WINDOWS
        GraphicData* graphicData,
        WindowData* windowData
#endif
)
{
    // GraphicRenderData _renderData

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
}