namespace Hemy.Lib.Core.Graphic;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Hemy.Lib.Core.Color;
using Hemy.Lib.Core.Platform.Vulkan;
using Hemy.Lib.Core.Platform.Windows.Graphic;
using Hemy.Lib.Core.Platform.Windows.Window;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct GraphicRender
{
    public delegate void YourDraw( );

    public GraphicRender(
#if WINDOWS
        GraphicData* graphicData,
        WindowData* windowData
#endif
    )
    {
        _graphic = graphicData;
        _window = windowData;
        _descriptor = Memory.Memory.New<GraphicDescriptorData>();
    }

    private readonly GraphicDescriptorData* _descriptor = null;
    private readonly GraphicData* _graphic = null;
    private readonly WindowData* _window = null;
    public void Add(Shape2D shape)
    {
        // see if shader exist else  create One 
        //Create shader Byte code ?

    }

    public void BuildShader()
    {
        
        _graphic->RenderPipeline = (delegate* unmanaged<void>)Marshal.GetFunctionPointerForDelegate((YourDraw)SpeficiDataToDraw);
        _descriptor->ShaderStageCount = 2;
        _descriptor->InstanceCount = 1;
        _descriptor->VertexCount = 3;
        _descriptor->Entrypoint = Memory.Memory.NewStr("main");
        _descriptor->DynamicStatesCount = 2;
        _descriptor->PrimitiveTopology = VkPrimitiveTopology.VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST;
#if DEBUG        
        System.GC.KeepAlive(this);
#endif
        Tools.Shaders.ShaderCompiler.ShadercImpl.CompilVertx(_graphic, _descriptor);
        Tools.Shaders.ShaderCompiler.ShadercImpl.CompilFrag(_graphic, _descriptor);

        GraphicDescriptor.CreateShaderStage(_graphic, _descriptor);
        GraphicDescriptor.CreatePipelineLayout(_graphic, _descriptor);
        GraphicDescriptor.CreateDynamicStates(_graphic, _descriptor);

        GraphicDescriptor.CreatePipeline(_graphic, _descriptor);
        
        Memory.Memory.DisposeStr(_descriptor->Entrypoint);
    }

    public void BuildRender(YourDraw yourDraw = null)
    {
        //CreatePipeline  redo RenderPass ..... 
        if (yourDraw != null)
            _graphic->RenderPipeline = (delegate* unmanaged<void>)Marshal.GetFunctionPointerForDelegate((YourDraw)yourDraw);

        _graphic->RenderPipeline = (delegate* unmanaged<void>)Marshal.GetFunctionPointerForDelegate((YourDraw)SpeficiDataToDraw);
#if WINDOWS
        ShaderData* shader = Memory.Memory.New<ShaderData>();

        // shader->DescriptorSetLayoutCount = 0;
        // shader->FragmentBytesCode = null;
        // shader->FragmentBytesCodeLength = 0;
        // shader->FragmentEntryPoint = null;
        // shader->HasPushConstant = false;
        // shader->HasVerticesEmbbeded = true;
        // shader->InstanceCount = 1;
        // shader->VertexCount = 3;
        // shader->ShaderDescribe_DescriptorSetLayout = VkDescriptorSetLayout.Null;
        // shader->ShaderStageCount = 2;
        // shader->VertexBytesCode = null;
        // shader->VertexBytesCodeLength = 0;
        // shader->VertexEntryPoint = null;

        


        // GraphicDescriptor.CreateShaderStage(_graphic, _descriptor, shader);
        // GraphicDescriptor.CreatePipelineLayout(_graphic, _descriptor, shader);
        // GraphicDescriptor.CreateDynamicStates(_graphic, _descriptor);

        // GraphicDescriptor.CreatePipeline(_graphic, _descriptor);


        Memory.Memory.Dispose(shader);
#endif

    }

    private void SpeficiDataToDraw()
    {
#if WINDOWS
        GraphicDescriptor.DrawOnlyShader(_graphic, _descriptor);
#endif
    }

    public void UpdateClearColor(Palette clearColor)
    {
        GraphicRenderImpl.ChangeBackGroundColor(_graphic, (uint)clearColor);
    }

    public void Draw(Palette clearColor)
    {
#if WINDOWS
        if (_window->IsInPaused) return;

        GraphicRenderImpl.Draw(_graphic);
#endif
    }

    public void Dispose()
    {
#if WINDOWS
        GraphicDescriptor.Dispose(_graphic, _descriptor);
#endif
        
        Memory.Memory.Dispose(_descriptor);
    }
}