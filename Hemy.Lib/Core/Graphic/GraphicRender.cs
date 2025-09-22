namespace Hemy.Lib.Core.Graphic;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Hemy.Lib.Core.Color;
using Hemy.Lib.Core.Platform.Vulkan;
using Hemy.Lib.Core.Platform.Windows.Graphic;
using Hemy.Lib.Core.Platform.Windows.Window;
using Hemy.Lib.Tools.Shaders.ShaderCompiler;

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


    public void BuildRender(YourDraw yourDraw = null)
    {
        //CreatePipeline  redo RenderPass ..... 
        if (yourDraw != null)
            _graphic->RenderPipeline = (delegate* unmanaged<void>)Marshal.GetFunctionPointerForDelegate((YourDraw)yourDraw);

        _graphic->RenderPipeline = (delegate* unmanaged<void>)Marshal.GetFunctionPointerForDelegate((YourDraw)SpeficiDataToDraw);
#if WINDOWS
        ShaderData* shader = Memory.Memory.New<ShaderData>();

        shader->DescriptorSetLayoutCount = 0;
        shader->FragmentBytesCode = null;
        shader->FragmentBytesCodeLength = 0;
        shader->FragmentEntryPoint = null;
        shader->HasPushConstant = false;
        shader->HasVerticesEmbbeded = true;
        shader->InstanceCount = 1;
        shader->VertexCount = 3;
        shader->ShaderDescribe_DescriptorSetLayout =  VkDescriptorSetLayout.Null;
        shader->ShaderStageCount = 2;
        shader->VertexBytesCode = null;
        shader->VertexBytesCodeLength = 0;
        shader->VertexEntryPoint = null; 

        //USE TOOLS SHADERCOMPILER 
        // string vertexfilename = @"Shader_Base.vert";
        string fragmentfilename = @"Shader_Base.vert";

        // string vertexSource =  ShadersImpl.VertexBaseShader();
        string FragmentSource = ShadersImpl.FragmentBaseShader();

        // using var compilerVertex = new Compiler();

        // compilerVertex.Options.ShaderStage = ShaderKind.VertexShader;
        // compilerVertex.Options.EntryPoint = "main";
        // compilerVertex.Options.SourceLanguage = SourceLanguage.GLSL;
        // // compilerVertex.Options.TargetEnv = TargetEnvironmentVersion.Vulkan_1_0;
        // // compilerVertex.Options.TargetSpv = SpirVVersion.Version_1_0;

        // CompileResult resultVertex = compilerVertex.Compile(vertexSource, vertexfilename );

        // shader->VertexBytesCodeLength = resultVertex.BytesSize;
        // shader->VertexBytesCode = (uint*)resultVertex.Bytes;

        using var compilerFragment = new Compiler();

        compilerFragment.Options.ShaderStage = ShaderKind.FragmentShader;
        compilerFragment.Options.EntryPoint = "main";
        compilerFragment.Options.SourceLanguage = SourceLanguage.GLSL;
        compilerFragment.Options.TargetEnv = TargetEnvironmentVersion.Vulkan_1_0;
        compilerFragment.Options.TargetSpv = SpirVVersion.Version_1_0;

        CompileResult resultFragment = compilerFragment.Compile(FragmentSource, fragmentfilename);

        shader->FragmentBytesCodeLength = resultFragment.BytesSize;
        shader->FragmentBytesCode = (uint*)resultFragment.Bytes;

        GraphicDescriptor.CreatePipelineLayout(_graphic,_descriptor,shader);
        GraphicDescriptor.CreateShaderStage(_graphic,_descriptor,shader);
        GraphicDescriptor.CreateDynamicStates(_graphic,_descriptor);

        GraphicDescriptor.CreatePipeline(_graphic,_descriptor);


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
        if (_window->SysPaused) return;

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