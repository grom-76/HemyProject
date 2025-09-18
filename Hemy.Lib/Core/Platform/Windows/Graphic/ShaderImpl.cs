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
    internal byte* Shader_FragmentEntryPoint = null;
    internal byte* Shader_VertexEntryPoint = null;
    internal uint* Shader_FragmentCode = null;
    internal uint* Shader_VertexCode = null;
    internal uint Shader_FragmentCodeLength = 0;
    internal uint Shader_VertexCodeLength = 0;
    internal uint Shader_ShaderStageCount = 2;

    //attributeDescriptions for Vertex 
    internal uint Vertex_Stride = 0;
    internal uint Vertex_Offset = 0;
    //
    internal VkDescriptorSetLayout ShaderDescribe_DescriptorSetLayout = VkDescriptorSetLayout.Null;
    internal uint DescriptorSetLayoutCount = 0;
    internal VkDescriptorPool ShaderDescribe_DescriptorPool = VkDescriptorPool.Null;
    internal VkDescriptorSet* ShaderDescribe_DescriptorSets = null;

    internal bool HasUniform = false; // USE CAMERA ...
    internal bool HasPushConstant = false; // USE PUSH CONSTANT ....


    internal VkPipelineLayout PipelineLayout = VkPipelineLayout.Null;

    

    internal unsafe struct VertexData()
    {
        //attributeDescriptions for Vertex 
        internal bool HasMesh = false;
        internal uint Vertex_Stride = 0;
        internal uint Vertex_Offset = 0;
        //STATE
        internal uint VertexCount = 3;
        internal uint InstanceCount = 1;
        internal VkPrimitiveTopology PrimitiveTopology = VkPrimitiveTopology.VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST;

    }

    internal unsafe struct DynamicStateData()
    {
        internal uint DynamicStates_Count = 2;
        internal VkViewport DynamicStates_Viewport = new();
        internal VkRect2D DynamicStates_Scissor = new();
        // 
}
}

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class ShadersImpl
{
	internal static void TestSHaderCompil()
	{

	}

	public static void AddSampler2D(string name)
	{
		//descriptor layout
		// in fragmentshader add Line texture2d sampler2d
	}

	public static void AddLayout(int location, uint type, string name)
	{

	}



	public static void AddEntryPoint(string content, string name = "main")
	{

	}

	public static void Build()
	{
		//Add All string in one stream string 
		//Use shaderc to compil
		// create resource file ?
	}

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
