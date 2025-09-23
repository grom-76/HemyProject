#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Graphic;

using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Hemy.Lib.Core.Platform.Vulkan;
using Hemy.Lib.Core.Platform.Windows.Window;

public unsafe struct ShaderData()
{
	internal byte* FragmentEntryPoint = null;
	internal byte* VertexEntryPoint = null;

	internal uint* FragmentBytesCode = null;
	internal uint* VertexBytesCode = null;

	internal uint FragmentBytesCodeLength = 0;
	internal uint VertexBytesCodeLength = 0;

	internal uint ShaderStageCount = 2;

	//attributeDescriptions for Vertex  if Vertex has Embedded in shader
	internal bool HasVerticesEmbbeded = true;
	// internal uint Vertex_Stride = 0;
	// internal uint Vertex_Offset = 0;
	internal uint VertexCount = 3;
	internal uint InstanceCount = 1;
	//
	internal VkDescriptorSetLayout ShaderDescribe_DescriptorSetLayout = VkDescriptorSetLayout.Null;
	internal uint DescriptorSetLayoutCount = 0;
	// internal VkDescriptorPool ShaderDescribe_DescriptorPool = VkDescriptorPool.Null;
	// internal VkDescriptorSet* ShaderDescribe_DescriptorSets = null;

	// internal bool HasUniform = false; // USE CAMERA ...
	internal bool HasPushConstant = false; // USE PUSH CONSTANT ....
	
}

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class ShadersImpl
{

	internal static string VertexBaseShader()
	{
		return @"
#version 450

layout(location = 0) out vec3 fragColor;

vec2 positions[3] = vec2[]
(
    vec2(0.0, -0.5),
    vec2(0.5, 0.5),
    vec2(-0.5, 0.5)
);

vec3 colors[3] = vec3[]
(
    vec3(1.0, 0.0, 0.0),
    vec3(0.0, 1.0, 0.0),
    vec3(0.0, 0.0, 1.0)
);

void main() 
{
    gl_Position = vec4(positions[gl_VertexIndex], 0.0, 1.0);
    fragColor = colors[gl_VertexIndex];
}
";
	}

	internal static string FragmentBaseShader()
	{
		return @"#version 450

layout(location = 0) in vec3 fragColor;

layout(location = 0) out vec4 outColor;

void main()
{
    outColor = vec4(fragColor, 1.0);
}
";
	}

	/*
		string glsl = @"		#version 450

		layout(location = 0) in vec3 fragColor;

		layout(location = 0) out vec4 outColor;

		void main()
		{
			outColor = vec4(fragColor, 1.0);

		}
		";
	*/
	private static void Add_Glsl_Fragment_Header(string includes = "")
	{
		_ = @"
		#version 450
		";
	}
	
	public static void Add_Glsl_Fragment_Layout( int location,bool inout ,uint type /*vec*/ , string name	)
	{
		_ = @"layout(location = 0) in vec3 fragColor;

	layout(location = 0) out vec4 outColor;";

	}

	public static void Add_Glsl_Fragment_EntryPoint(string content, string name = "main")
	{
		_ = @"void main() 
{
    gl_Position = vec4(positions[gl_VertexIndex], 0.0, 1.0);
    fragColor = colors[gl_VertexIndex];
}";
	}


	private static void Add_Glsl_Vertex_Header(string includes = "")
	{
		_ = @"
		#version 460
		#extension GL_ARB_separate_shader_objects : enable
		";
	}

	public static void Add_Glsl_Vertex_Layout( int location,bool inout ,uint type /*vec*/ , string name	)
	{
		_ = "layout(location = 0) out vec3 fragColor;";

	}

	public static void Add_Glsl_Vertex_EmbedddedValues( string descriptions)
	{
		_ = @" vec2 positions[3] = vec2[]
(
    vec2(0.0, -0.5),
    vec2(0.5, 0.5),
    vec2(-0.5, 0.5)
);";
		_ = @" vec3 colors[3] = vec3[]
(
    vec3(1.0, 0.0, 0.0),
    vec3(0.0, 1.0, 0.0),
    vec3(0.0, 0.0, 1.0)
);";
	}

	public static void Add_Glsl_Vertex_EntryPoint(string content, string name = "main")
	{
		_ = @"void main() 
{
    gl_Position = vec4(positions[gl_VertexIndex], 0.0, 1.0);
    fragColor = colors[gl_VertexIndex];
}";
	}


	public static void Build()
	{
		//Add All string in one stream string 
		//Use shaderc to compil
		// create resource file ?

		// Create byteCode SPIRV with shaderc Compiler 
	}

	 // internal static void CreateShader(GraphicData* contextData)
    // {
    //     string vertexfilename = @"C:\Users\Admin\Documents\ProjectHE2\Assets\Shader_Base.vert";

    //     string vertexSource = File.ReadAllText(vertexfilename);

    //     using var compiler = new Compiler();

    //     compiler.Options.ShaderStage = ShaderKind.VertexShader;
    //     compiler.Options.EntryPoint = "main";
    //     compiler.Options.SourceLanguage = SourceLanguage.GLSL;
    //     compiler.Options.TargetEnv = TargetEnvironmentVersion.Vulkan_1_0;
    //     compiler.Options.TargetSpv = SpirVVersion.Version_1_0;

    //     CompileResult result = compiler.Compile(vertexSource, vertexfilename);

    //     VkShaderModuleCreateInfo* createInfoFrag = stackalloc VkShaderModuleCreateInfo[1];
    //     createInfoFrag[0].sType = VkStructureType.VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO;
    //     createInfoFrag[0].codeSize = result.BytesSize;
    //     createInfoFrag[0].pNext = null;
    //     createInfoFrag[0].flags = 0;
    //     createInfoFrag[0].pCode = (uint*)result.Bytes;

    //     VkShaderModule ShaderModule = VkShaderModule.Null;

    //     var error = Vk.vkCreateShaderModule(contextData->Device, &createInfoFrag[0], null, &ShaderModule);

    //     _ = Log.Check(error != VkResult.VK_SUCCESS, $"could not create vertex shader module : {error} ");

    //     byte* entryPt = WindowsMemory.New("main");

    //     VkPipelineShaderStageCreateInfo* shaderStages = stackalloc VkPipelineShaderStageCreateInfo[1];

    //     shaderStages[0].sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO;
    //     shaderStages[0].stage = VkShaderStageFlagBits.VK_SHADER_STAGE_FRAGMENT_BIT;
    //     shaderStages[0].module = ShaderModule;
    //     shaderStages[0].pName = entryPt;
    //     shaderStages[0].flags = 0;
    //     shaderStages[0].pNext = null;
    //     shaderStages[0].pSpecializationInfo = null;

    //     WindowsMemory.Dispose(entryPt);
    // }

	public static void AddShader(string vertex, string fragment, string entrypoint = "main")
	{

		// _renderData->ShaderData = _renderData->Pool->New<ShaderData>(new());
		// _renderData->VertexData = _renderData->Pool->New<VertexData>(new());
		// _renderData->DynamicState = _renderData->Pool->New<DynamicStateData>(new());
		// _renderData->VertexData->InstanceCount = 1;
		// _renderData->VertexData->VertexCount = 3;
		// _renderData->State = 1;
		// Test if file exist

		// HE.Tools.ShaderHelper.Compile(vertex, Tools.ShaderHelper.ShaderType.VertexShader);
		// HE.Tools.ShaderHelper.Compile(fragment, Tools.ShaderHelper.ShaderType.FragmentShader);
		// HE.Tools.ShaderHelper.Compile(vertex, fragment, _renderData->ShaderData, _renderData->Pool);

		// _renderData->ShaderData->Shader_VertexEntryPoint = _renderData->Pool->NewArray<byte>(5);
		// _renderData->ShaderData->Shader_FragmentEntryPoint = _renderData->Pool->NewArray<byte>(5);
		// HE.Context.Windows.Utils.FillBytesFromString(_renderData->ShaderData->Shader_VertexEntryPoint, "main");
		// HE.Context.Windows.Utils.FillBytesFromString(_renderData->ShaderData->Shader_FragmentEntryPoint, "main");
		// PipelineImplement.CreatePipelineLayout(graphicData, _renderData->ShaderData);

		// PipelineImplement.CreatePipeline(graphicData, _renderData);

		// /*        
		//         string vertexSource = File.ReadAllText(vertex);
		//         using var compiler = new Compiler();
		//         var options = new CompilerOptions
		//         {
		//             ShaderStage = ShaderKind.VertexShader,
		//             EntryPoint = "main",
		//             SourceLanguage = SourceLanguage.GLSL,
		//             // TargetEnv = TargetEnvironmentVersion.Vulkan_1_3
		//             // TargetSpv = SpirVVersion.Version_1_0
		//         };

		//         CompileResult result = compiler.Compile(vertexSource, vertex, options);
		// */
		// File.WriteAllBytes("vertex_base.spv", result.Bytecode);
		// Span<byte> span = new(result.Bytes, (int)result.BytesSize);
		// byte[] byteArray = span.ToArray();

		// uint* spirvBytes = MemoryImplement.NewArray<uint>(result.BytesSize + 1);
		// CopySpirv(result.Bytes, spirvBytes, result.BytesSize);

		// var vert = File.ReadAllBytes("vert.spv");

		// VkShaderModuleCreateInfo* createInfoFrag = stackalloc VkShaderModuleCreateInfo[1];

		// createInfoFrag[0].sType = VkStructureType.VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO;
		// createInfoFrag[0].pNext = null;
		// createInfoFrag[0].flags = 0;
		// createInfoFrag[0].codeSize = (uint)vert.Length;

		// fixed (byte* ptr = vert)
		// {
		// 	createInfoFrag[0].pCode = (uint*)ptr;
		// }

		// /*
		//                 createInfoFrag.codeSize = result.BytesSize ;

		//                 createInfoFrag.pCode = (uint*)result.Bytes;
		//            */
		// VkShaderModule ShaderModule = VkShaderModule.Null;

		// var error = Vk.vkCreateShaderModule(graphicData->Device, &createInfoFrag[0], null, &ShaderModule);//.Check($"Create  Shader Module Failed"); 

		// _ = HE.Context.Windows.Utils.Check(error != VkResult.VK_SUCCESS, $"could not create vertex shader module : {error} ");

		// byte* entryPt = MemoryImplement.NewStr(entrypoint);

		// VkPipelineShaderStageCreateInfo shaderStages = new()
		// {
		// 	sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO,
		// 	stage = VkShaderStageFlagBits.VK_SHADER_STAGE_FRAGMENT_BIT,
		// 	module = ShaderModule,
		// 	pName = entryPt,
		// 	flags = 0,
		// 	pNext = null,
		// 	pSpecializationInfo = null
		// };
	}

	/*
        Pipeline (shader unique )
            ShaderStages => ( count : fragement vertex ....) 
                ShaderModules => [ Create ]   BytesCodes  + Length
                entrypoint + type
            PipelineLayout => [ Create ] ( all sahder for pipeline )
                PushConstant
                DescriptorSetLayout +Count 
                    List LayoutBinding
                        Type - uniform, sampler , accelered  structure
                        shaderKind  - vertex fragment                


        DescriptorWrites
            DescriptoSet => Creates 
                DescritporPool ( DoubleBuffer = x 2)
                    List of PoolSize See  / equal Layoutbinding 
                DescriptorSetLayout
            SetDescriptorWrite 
                Type ( bufer , image , storage , .... )
                Descirpotr Type Inof
                    if buffer => VkBuffer + Size + Elements
                    if image => VKImage + Size + sampler
    */


	//     public static unsafe void CopySpirv(byte* shaderCode, uint* destination, uint size)
	//     {
	//         for (int i = 0; i < size; i++)
	//         {
	//             destination[i] = (uint)shaderCode[i];
	//         }
	//     }

	
// // REPLACE WITH CLASS MATERIALS ( Shader info + texture )
// public unsafe struct ShaderData
// {
//     // Shader INfo


//     // shader Texture


// }

// public unsafe struct ShaderSamplerData(Shaders* shaders )
// {
//     readonly Shaders* _shaders = shaders;
//     public ShaderSamplerData WithMipmap(int mipmapMode = 0)
//     {

//         return this;
//     }

//     public ShaderSamplerData WithFilterMode(int filtermod = 0)
//     {

//         return this;
//     }

//     public ShaderSamplerData WithAdressMode(int filtermod = 0)
//     {

//         return this;
//     }

//     public Shaders BuildSampler() => *_shaders;
// }

// public unsafe struct Shaders()
// {
//     readonly ShaderData* _data = Mem.New<ShaderData>();

//     public Shaders AddFragment(ShaderLanguage shaderLAnguage, Str name)
//     {
//         // CreateShaderModule()
//         return this;
//     }


//     public Shaders AddVertex(ShaderLanguage shaderLAnguage, Str name)
//     {

//         return this;
//     }

//     public Shaders AddVsLayout(int location, VertexKindType type, Str name)
//     {

//         return this;
//     }

//     public ShaderSamplerData AddFsSampler(int location, Str name)
//     {

//         return new();
//     }

   




//     public Shaders Build()
//     {
//         // Shader Compil in 
//         return this;
//     }


//     public void ActiveCurentShader()
//     {

//     }

//     public void UnActiveCurrentShader()
//     {

//     }

//     public void UpdateUniform<TUniformType>(uint Id, TUniformType value) where TUniformType  : unmanaged
//     {
//         // byte* pData;
//         uint taille = (uint)sizeof(TUniformType);

//         // Vk.vkMapMemory(data->Device,vkPipeline.UniformCameraMemory[vkRender.CurrentFrame], 0,taille, 0, (void**)&pData );//.Check("Map Memeory Unifommr pb");

//         // var m = vkPipeline.uboVS;
//         // Unsafe.CopyBlock(pData, &m, (uint)taille);
//         // // Unmap after data has been copied
//         // // Note: Since we requested a host coherent memory type for the uniform buffer, the write is instantly visible to the GPU

//         // Vk.vkUnmapMemory(data->Device,vkPipeline.UniformCameraMemory[vkRender.CurrentFrame]);// dont do thaht with uniform    
//     }


//     public static void TestShader()
//     {
//         var s = new Shaders().
//                 AddFsSampler(0, "")
//                     .WithAdressMode(0)
//                     .WithFilterMode(0)
//                     .WithMipmap(0)
//                     .BuildSampler();

//         s.ActiveCurentShader();

//         s.UpdateUniform<uint>(0, 10  );
//     }
//     // private static unsafe VkShaderModule CreateShaderModule(VulkanDevice_Data* data, uint* bytescode , uint length)
//     // {
//     //     VkShaderModuleCreateInfo createInfoFrag = new()
//     //     {
//     //         sType = VkStructureType.VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO,
//     //         codeSize = length,
//     //         pCode = bytescode,
//     //         pNext = null,
//     //         flags = 0
//     //     };

//     //     VkShaderModule ShaderModule = VkShaderModule.Null;
//     //     Vk.vkCreateShaderModule(data->Device, &createInfoFrag, null,  &ShaderModule );//.Check($"Create  Shader Module Failed"); 
//     //     return ShaderModule;
//     // }

//     //  public unsafe static VkSampler CreateSampler(VulkanDevice_Data* data , VkSamplerAddressMode addressMode , VkFilter filter   )
//     // {
//     //     VkSamplerCreateInfo samplerInfo = new() {
//     //         sType = VkStructureType.VK_STRUCTURE_TYPE_SAMPLER_CREATE_INFO,
//     //         magFilter = filter,//VkFilter.VK_FILTER_LINEAR;
//     //         minFilter = filter,//VkFilter.VK_FILTER_LINEAR;
//     //         addressModeU = addressMode,//VkSamplerAddressMode.VK_SAMPLER_ADDRESS_MODE_REPEAT;
//     //         addressModeV = addressMode,//VkSamplerAddressMode.VK_SAMPLER_ADDRESS_MODE_REPEAT;
//     //         addressModeW = addressMode,//VkSamplerAddressMode.VK_SAMPLER_ADDRESS_MODE_REPEAT;
//     //         anisotropyEnable = 1,// data->VK_TRUE;
//     //         maxAnisotropy = data->DeviceProperties.limits.maxSamplerAnisotropy,
//     //         borderColor = VkBorderColor.VK_BORDER_COLOR_INT_OPAQUE_BLACK,
//     //         unnormalizedCoordinates = 0,//data->VK_FALSE;
//     //         compareEnable = 0,// data->VK_FALSE;
//     //         compareOp = VkCompareOp.VK_COMPARE_OP_ALWAYS,
//     //         mipmapMode = VkSamplerMipmapMode.VK_SAMPLER_MIPMAP_MODE_LINEAR
//     //     };

//     //     VkSampler textureSampler = VkSampler.Null;

//     //     Vk.vkCreateSampler(data->Device, &samplerInfo, null, &textureSampler);//.Check("failed to create texture sampler!");

//     //     Log.Info($"Create Texture sampler {textureSampler}");
//     //     return textureSampler;
//     // }

//     // public unsafe static  void DisposeSampler( VulkanDevice_Data* data , ref VkSampler textureSampler)
//     // {
//     //     if( textureSampler.IsNull) return ;

//     //     Log.Info($"Destroy Texture sampler {textureSampler}");
//     //     Vk.vkDestroySampler(data->Device,textureSampler, null);
//     // }
// }

}

#endif
