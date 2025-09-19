using Hemy.Lib.Core.Color;
using Hemy.Lib.Core.Math;
using Hemy.Lib.Core.Platform.Windows.Graphic;
using Hemy.Lib.Core.Platform.Windows.Window;

namespace Hemy.Lib.Core.Graphic;


public unsafe struct Shape
{
    public void CreateTriangle(Vector3 position, Vector4 color, uint borderColor = 0)
    {
        

    }

    public void Modify()
    {

    }
}


public unsafe struct GraphicRender(
#if WINDOWS
        GraphicData* graphicData,
        WindowData* windowData 
#endif
)
{
    // GraphicRenderData _renderData

    public void Add(Shape shape)
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
        if (windowData->SysPaused ) return;
        RenderImpl.ChangeBackGroundColor(graphicData, (uint)clearColor);
        RenderImpl.Draw(graphicData);
#endif
    }
}