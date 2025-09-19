#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Graphic;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Hemy.Lib.Core.Graphic;
using Hemy.Lib.Core.Platform.Vulkan;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct GraphicData()
{
    internal VkInstance Instance = VkInstance.Null;
#if DEBUG
    internal bool EnableDebugMode = true;
#else
	internal bool EnableDebugMode = false;
#endif
    internal VkDebugUtilsMessengerEXT DebugMessenger = VkDebugUtilsMessengerEXT.Null;
    internal VkSurfaceKHR Surface = VkSurfaceKHR.Null;
    internal VkPhysicalDevice DevicePhysical = VkPhysicalDevice.Null;
    internal VkDevice Device = VkDevice.Null;
    internal uint GraphicQueueIndex = uint.MaxValue;
    internal uint PresentQueueIndex = uint.MaxValue;
    internal VkQueue GraphicQueue = VkQueue.Null;
    internal VkQueue PresentQueue = VkQueue.Null;

    internal VkFormat SwapChainImageFormat = VkFormat.VK_FORMAT_B8G8R8A8_SRGB;
    internal VkSwapchainKHR SwapChain = VkSwapchainKHR.Null;
    internal VkImage* SwapChainImages = null!;//dispose
    internal VkImageView* SwapChainImageViews = null!;//dispose 
    internal VkFramebuffer* Framebuffers = null!;//dispose
    internal uint SwapChainImageViewsCount = 0;
    //DRAW
    internal uint MaxFrameInFlight = 2;
    internal ulong Ticktimeout = 1_000_000_000;//  1 seconde en nano ou VKDEviceSize ( in wait fences )
    internal VkRenderPass RenderPass = VkRenderPass.Null;
    internal VkRect2D* RenderPassArea = null;
    internal VkClearValue* RenderPassClearValues = null;
    internal VkSemaphore* ImageAvailableSemaphores = null;
    internal VkSemaphore* RenderFinishedSemaphores = null;
    internal VkFence* InFlightFences = null!;
    internal VkCommandPool CommandPool = VkCommandPool.Null;
    internal VkCommandBuffer* CommandBuffers = null!;
    internal delegate* unmanaged<void> RenderPipeline = (delegate* unmanaged<void>)Marshal.GetFunctionPointerForDelegate(RenderImpl.EmptyDrawPipeline);
}

#if TODO


public unsafe struct GraphicRenderData()
{
    internal MemoryPool* Pool = null; 
    internal uint BackGroundColor = 4284782061u;
    internal int State = 0; // 0 = EMpty , 1 OnlyShader , 2 Vertex + shader ....
    //Herited from GraphicDevice 
    // internal VkDevice Device = VkDevice.Null;
    // internal uint MaxFrameInFlight = 2;
    //  .Render PAss
    internal VkRenderPass RenderPass = VkRenderPass.Null; // need for create framebuffers 
    internal VkClearValue* RenderPassClearValues = null;//new(){ color= new(0.1f,0.2f,0.5f,1.0f)};

    internal ShaderData* ShaderData = null;
    internal DynamicStateData* DynamicState = null;
    internal VertexData* VertexData = null;

    internal VkPipeline Pipeline = VkPipeline.Null;
}

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

}

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


internal static unsafe class PipelineImplement
{
    #region Pipeline

    internal static void CreatePipeline(GraphicData* graphicData, GraphicRenderData* renderData)
    {
        // graphic Data uniquement pour le render pass ?????????????
        #region SHADERS BUILDING MODULES

        // VkShaderModule* shaderModules = renderData->Pool->NewArray<VkShaderModule>(2);
        // shaderModules[0] = CreateShaderModule(graphicData, renderData->ShaderData->Shader_FragmentCode, (uint)renderData->ShaderData->Shader_FragmentCodeLength);
        // shaderModules[1] = CreateShaderModule(graphicData, renderData->ShaderData->Shader_VertexCode, (uint)renderData->ShaderData->Shader_VertexCodeLength);
        var frag = CreateShaderModule(graphicData, (uint*)renderData->ShaderData->Shader_FragmentCode, (uint)renderData->ShaderData->Shader_FragmentCodeLength);
        var vert = CreateShaderModule(graphicData, (uint*)renderData->ShaderData->Shader_VertexCode, (uint)renderData->ShaderData->Shader_VertexCodeLength);

        VkPipelineShaderStageCreateInfo* shaderStages = renderData->Pool->NewArray<VkPipelineShaderStageCreateInfo>(2);

        shaderStages[0] = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO,
            stage = VkShaderStageFlagBits.VK_SHADER_STAGE_FRAGMENT_BIT,
            module = frag,
            pName = renderData->ShaderData->Shader_FragmentEntryPoint,
            flags = 0,
            pNext = null,
            pSpecializationInfo = null
        };

        shaderStages[1] = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO,
            stage = VkShaderStageFlagBits.VK_SHADER_STAGE_VERTEX_BIT,
            module = vert,
            pName = renderData->ShaderData->Shader_VertexEntryPoint,
            flags = 0,
            pNext = null,
            pSpecializationInfo = null
        };

        #endregion

        #region VERTEX DEFINITIONS : ATTRIBUTS & BINDINGS  For SHADERS


        // VkVertexInputBindingDescription bindingDescription = new()
        // {
        //     binding = 0, // layout 
        //     stride = renderData->ShaderData->Vertex_Stride,
        //     inputRate = VkVertexInputRate.VK_VERTEX_INPUT_RATE_VERTEX
        // };

        // // TODO take this info inside Resource File ?

        // VkVertexInputAttributeDescription* attributeDescriptions = stackalloc VkVertexInputAttributeDescription[3];
        // attributeDescriptions[0].binding = 0;
        // attributeDescriptions[0].location = 0;
        // attributeDescriptions[0].format = VkFormat.VK_FORMAT_R32G32B32_SFLOAT;
        // attributeDescriptions[0].offset = renderData->VertexData->Vertex_Offset;

        // attributeDescriptions[1].binding = 0;
        // attributeDescriptions[1].location = 1;
        // attributeDescriptions[1].format = VkFormat.VK_FORMAT_R32G32B32_SFLOAT;
        // attributeDescriptions[1].offset = 3;

        // attributeDescriptions[2].binding = 0;
        // attributeDescriptions[2].location = 2;
        // attributeDescriptions[2].format = VkFormat.VK_FORMAT_R32G32_SFLOAT;
        // attributeDescriptions[2].offset = 3;

        VkPipelineVertexInputStateCreateInfo vertexInputInfo = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_STATE_CREATE_INFO,
            pNext = null,
            flags = 0,
            vertexBindingDescriptionCount = renderData->VertexData->HasMesh ? renderData->VertexData->InstanceCount : (uint)0,
            vertexAttributeDescriptionCount = renderData->VertexData->HasMesh ? renderData->VertexData->VertexCount : (uint)0,
            // pVertexAttributeDescriptions = renderData->VertexData->HasMesh ? attributeDescriptions : null,
            // pVertexBindingDescriptions = renderData->VertexData->HasMesh ? &bindingDescription : null
        };

        #endregion

        #region PIPELINE LAYOUT SHADERS DEFINITIONS

        // See coresponding Function => PushConstant , Uniform Buffer

        #endregion

        #region FIXED FUNCTION INPUT ASSEMBLY

        VkPipelineInputAssemblyStateCreateInfo inputAssembly = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_INPUT_ASSEMBLY_STATE_CREATE_INFO,
            topology = renderData->VertexData->PrimitiveTopology,
            primitiveRestartEnable = VK.VK_FALSE,
            flags = 0,
            pNext = null
        };

        #endregion

        #region FIXED FUNCTION COLOR bLEndING 

        VkPipelineColorBlendAttachmentState colorBlendAttachment = new()
        {
            colorWriteMask = (uint)(VkColorComponentFlagBits.VK_COLOR_COMPONENT_R_BIT | VkColorComponentFlagBits.VK_COLOR_COMPONENT_G_BIT | VkColorComponentFlagBits.VK_COLOR_COMPONENT_B_BIT | VkColorComponentFlagBits.VK_COLOR_COMPONENT_A_BIT),
            blendEnable = VK.VK_FALSE,
            srcColorBlendFactor = VkBlendFactor.VK_BLEND_FACTOR_ZERO,
            srcAlphaBlendFactor = VkBlendFactor.VK_BLEND_FACTOR_ZERO,
            alphaBlendOp = VkBlendOp.VK_BLEND_OP_ADD,
            colorBlendOp = VkBlendOp.VK_BLEND_OP_ADD,
            dstAlphaBlendFactor = VkBlendFactor.VK_BLEND_FACTOR_ZERO,
            dstColorBlendFactor = VkBlendFactor.VK_BLEND_FACTOR_ZERO
        };

        VkPipelineColorBlendStateCreateInfo colorBlending = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_COLOR_BLEND_STATE_CREATE_INFO,
            logicOpEnable = VK.VK_FALSE,
            logicOp = VkLogicOp.VK_LOGIC_OP_COPY,
            attachmentCount = 1,
            pAttachments = &colorBlendAttachment,
            flags = 0,
            pNext = null
        };
        colorBlending.blendConstants[0] = 0.0f;
        colorBlending.blendConstants[1] = 0.0f;
        colorBlending.blendConstants[2] = 0.0f;
        colorBlending.blendConstants[3] = 0.0f;

        #endregion

        #region FIXED FUNCTION RASTERIZATION

        VkPipelineRasterizationStateCreateInfo rasterizer = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_CREATE_INFO,
            rasterizerDiscardEnable = VK.VK_FALSE,// config.RasterizerDiscardEnable?  1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
            polygonMode = VkPolygonMode.VK_POLYGON_MODE_FILL,
            lineWidth = 1.0f,
            cullMode = (uint)VkCullModeFlagBits.VK_CULL_MODE_NONE,
            frontFace = VkFrontFace.VK_FRONT_FACE_CLOCKWISE,
            flags = 0,
            pNext = null,
            depthBiasEnable = VK.VK_FALSE,// config.DepthBiasEnable? 1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
            // depthClampEnable = data->VK_FALSE,// config.DepthClampEnable?  1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
            // depthBiasClamp = 0.0f,//config.DepthBiasClamp ; // 0.0f;
            // depthBiasConstantFactor = 1.0f,// config.DepthBiasConstantFactor ;  // 1.0f;
            // depthBiasSlopeFactor = 1.0f// config.DepthBiasSlopeFactor ;   //1.0f;
        };

        #endregion

        #region FIXED FUNCTION MULTISAMPLING ( ANTIALIASING ? )

        VkPipelineMultisampleStateCreateInfo multisampling = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_MULTISAMPLE_STATE_CREATE_INFO,
            pNext = null,
            flags = 0,
            sampleShadingEnable = VK.VK_FALSE,// config.SampleShadingEnable ?  1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
            rasterizationSamples = VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT,
            // alphaToCoverageEnable = data->VK_FALSE,//  config.AlphaToCoverageEnable ? 1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
            // alphaToOneEnable = data->VK_FALSE,//config.AlphaToOneEnable  ?  1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;       
            // minSampleShading = 0.0f,
            // pSampleMask = null
        };

        #endregion

        #region FIXED FUNCTION DETPH & STENCIL 


        VkPipelineDepthStencilStateCreateInfo depthStencilStateCreateInfo = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_DEPTH_STENCIL_STATE_CREATE_INFO,
            pNext = null,
            depthTestEnable = graphicData->IsUseDepthBuffer ? VK.VK_TRUE : VK.VK_FALSE,// config.DepthTestEnable ?   1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
            depthWriteEnable = 0, // config.DepthWriteEnable  ?  1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
            depthCompareOp = VkCompareOp.VK_COMPARE_OP_LESS,
            depthBoundsTestEnable = 0,//config.DepthBoundsTestEnable ?  1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
            stencilTestEnable = 0,// config.DepthStencilTestEnable ? 1 /*data->VK_TRUE*/ :0 /*data->VK_FALSE*/ ;
            maxDepthBounds = 1.0f,// config.DepthMaxDepthBounds;
            minDepthBounds = 0.0f,// config.DepthMinDepthBounds;
                                  // flags = (uint)VkPipelineDepthStencilStateCreateFlagBits.VK_PIPELINE_DEPTH_STENCIL_STATE_CREATE_RASTERIZATION_ORDER_ATTACHMENT_DEPTH_ACCESS_BIT_ARM
        };
        if (graphicData->IsUseDepthBuffer)
        {

            // depthStencilStateCreateInfo.front = config.DepthFront ;
            // depthStencilStateCreateInfo.back = config.DepthBack ;
        }


        #endregion

        #region FIXED FUNCTION DYNAMIC STATE

        VkDynamicState* dynamicStates2 = renderData->Pool->NewArray<VkDynamicState>(renderData->DynamicState->DynamicStates_Count);

        dynamicStates2[0] = VkDynamicState.VK_DYNAMIC_STATE_VIEWPORT;
        dynamicStates2[1] = VkDynamicState.VK_DYNAMIC_STATE_SCISSOR;

        VkPipelineDynamicStateCreateInfo dynamicStateCreateInfo = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_DYNAMIC_STATE_CREATE_INFO,
            pNext = null,
            flags = 0,
            dynamicStateCount = renderData->DynamicState->DynamicStates_Count,
            pDynamicStates = dynamicStates2
        };


        #endregion

        #region FIXED FUNCTION VIEWPORT SCISSOR

        VkPipelineViewportStateCreateInfo viewportState = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_STATE_CREATE_INFO,
            flags = 0,
            pNext = null,
            viewportCount = 1,
            pViewports = &renderData->DynamicState->DynamicStates_Viewport,
            scissorCount = 1,
            pScissors = &renderData->DynamicState->DynamicStates_Scissor
        };


        #endregion

        #region FIXED FUNCTION TESSLATION 

        VkPipelineTessellationStateCreateInfo tessellationStateCreateInfo = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_TESSELLATION_STATE_CREATE_INFO,
            pNext = null,
            flags = 0,
            patchControlPoints = 0
        };

        #endregion

        VkGraphicsPipelineCreateInfo pipelineInfo = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_CREATE_INFO,
            pNext = null,
            flags = (uint)VkPipelineCreateFlagBits.VK_PIPELINE_CREATE_DISABLE_OPTIMIZATION_BIT,
            renderPass = renderData->RenderPass,
            subpass = 0,

            pVertexInputState = &vertexInputInfo,
            pInputAssemblyState = &inputAssembly,

            pColorBlendState = &colorBlending,

            pViewportState = &viewportState,

            pRasterizationState = &rasterizer,

            pMultisampleState = &multisampling,

            layout = renderData->ShaderData->PipelineLayout,

            pTessellationState = &tessellationStateCreateInfo,

            pDepthStencilState = graphicData->IsUseDepthBuffer ? &depthStencilStateCreateInfo : null,

            pDynamicState = &dynamicStateCreateInfo,

            basePipelineIndex = 0,
            basePipelineHandle = VkPipeline.Null,

            stageCount = renderData->ShaderData->Shader_ShaderStageCount,
            pStages = shaderStages,
        };

        Vk.vkCreateGraphicsPipelines(graphicData->Device, VkPipelineCache.Null, 1, &pipelineInfo, null, &renderData->Pipeline);//.Check("failed to create graphics pipeline!");

        // for (int i = 0; i < renderData->ShaderData->Shader_ShaderStageCount; i++)
        // {
        //     DisposeShaderModule(graphicData, shaderModules[i]);
        // }
        DisposeShaderModule(graphicData, frag);
        DisposeShaderModule(graphicData, vert);
        // Log.Info("INFO", $"Create PIPELINE : {renderData->Pipeline}");
    }

    internal static void DisposePipeline(GraphicData* graphicData)
    {
        // if (renderData->Pipeline.IsNull) return;

        // // Log.Info("INFO",$"Destroy PIPELINE : {renderData->Pipeline}");
        // Vk.vkDestroyPipeline(graphicData->Device, renderData->Pipeline, null);
    }

    #endregion

    static VkShaderModule CreateShaderModule(GraphicData* graphicData, uint* bytescode, uint length)
    {
        VkShaderModuleCreateInfo createInfoFrag = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO,
            codeSize = length,
            pCode = bytescode,
            pNext = null,
            flags = 0
        };

        VkShaderModule ShaderModule = VkShaderModule.Null;
        var result = Vk.vkCreateShaderModule(graphicData->Device, &createInfoFrag, null, &ShaderModule);//.Check($"Create  Shader Module Failed"); 
        _ = Log.Check(result != VkResult.VK_SUCCESS, $"Create shader module : {result} ");
        return ShaderModule;
    }

    static void DisposeShaderModule(GraphicData* graphicData, VkShaderModule shaderModule)
    {
        if (shaderModule.IsNull) return;

        Log.Info("INFO", $"Destroy Shader Module : {shaderModule}");
        Vk.vkDestroyShaderModule(graphicData->Device, shaderModule, null);
    }

    #region ReSOURCE DESCRIPTOR FOR SHADER 
    static void CreateDescriptorSets(GraphicData* graphicData, ShaderData* ShaderData)
    {

        VkDescriptorSetLayout* layouts = stackalloc VkDescriptorSetLayout[2] { ShaderData->ShaderDescribe_DescriptorSetLayout, ShaderData->ShaderDescribe_DescriptorSetLayout };

        VkDescriptorSetAllocateInfo allocInfo = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO,
            descriptorPool = ShaderData->ShaderDescribe_DescriptorPool,
            descriptorSetCount = graphicData->MaxFrameInFlight,
            pSetLayouts = layouts,
            pNext = null
        };

        Vk.vkAllocateDescriptorSets(graphicData->Device, &allocInfo, ShaderData->ShaderDescribe_DescriptorSets);//.Check("failed to allocate descriptor sets!");

        VkWriteDescriptorSet* descriptorWrites = MemoryImplement.NewArray<VkWriteDescriptorSet>(1);
        // uint index = 0;
        for (int i = 0; i < graphicData->MaxFrameInFlight; i++)
        {

            // VkDescriptorBufferInfo bufferInfo = new ();
            // bufferInfo.buffer = settings.UniformCameraBuffers[i];
            // bufferInfo.offset = 0;
            // bufferInfo.range = UboVS.SizeInBytes ;// sizeof UNIFORM_MVP

            descriptorWrites[0].sType = VkStructureType.VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET;
            descriptorWrites[0].dstSet = ShaderData->ShaderDescribe_DescriptorSets[i];
            descriptorWrites[0].dstBinding = 0;
            descriptorWrites[0].dstArrayElement = 0;
            descriptorWrites[0].descriptorType = VkDescriptorType.VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER;
            descriptorWrites[0].descriptorCount = 1;
            // descriptorWrites[0].pBufferInfo =&bufferInfo;

            // descriptorWrites[1].sType = VkStructureType.VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET;
            // descriptorWrites[1].dstSet = descriptorSets[i];
            // descriptorWrites[1].dstBinding = 1;
            // descriptorWrites[1].dstArrayElement = 0;
            // descriptorWrites[1].descriptorType =VkDescriptorType.VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER;
            // descriptorWrites[1].descriptorCount = 1;
            // fixed(VkDescriptorImageInfo* iI =  &imageInfo)
            // {
            //     descriptorWrites[1].pImageInfo = iI;
            // }

            Vk.vkUpdateDescriptorSets(graphicData->Device, 1, descriptorWrites, 0, null);

        }

        MemoryImplement.DisposeArray(descriptorWrites);

    }

    internal static void DisposeDescriptorSet(GraphicData* graphicData, ShaderData* ShaderData)
    {
        if (ShaderData->ShaderDescribe_DescriptorPool.IsNull || ShaderData->ShaderDescribe_DescriptorSets == null) return;

        for (int i = 0; i < graphicData->MaxFrameInFlight; i++)
        {
            Vk.vkFreeDescriptorSets(graphicData->Device, ShaderData->ShaderDescribe_DescriptorPool, 0, &ShaderData->ShaderDescribe_DescriptorSets[i]);//.Check("Error Free Descriptor Sets");
        }
    }

    internal static void CreateDescriptorPool(GraphicData* graphicData, ShaderData* ShaderData)
    {

        VkDescriptorPoolSize* poolSizes = stackalloc VkDescriptorPoolSize[(int)1];

        poolSizes[0].type = VkDescriptorType.VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER;
        poolSizes[0].descriptorCount = graphicData->MaxFrameInFlight;

        // if TextureActive
        // index--;
        // poolSizes[1].type = VkDescriptorType.VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER;
        // poolSizes[1].descriptorCount =(uint)(config.Render.MAX_FRAMES_IN_FLIGHT);

        VkDescriptorPoolCreateInfo poolInfo = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_CREATE_INFO,
            poolSizeCount = 1,
            maxSets = graphicData->MaxFrameInFlight,
            pPoolSizes = poolSizes
        };

        Vk.vkCreateDescriptorPool(graphicData->Device, &poolInfo, null, &ShaderData->ShaderDescribe_DescriptorPool);//.Check("failed to create descriptor pool!");

        Log.Info("INFO", $"Create Descriptor Pool : {ShaderData->ShaderDescribe_DescriptorPool}");

    }

    internal static void DisposeDescriptorsPool(GraphicData* graphicData, ShaderData* ShaderData)
    {
        if (ShaderData->ShaderDescribe_DescriptorPool.IsNull) return;

        Log.Info("INFO", $"Destroy Descriptor Pool : {ShaderData->ShaderDescribe_DescriptorPool}");
        Vk.vkDestroyDescriptorPool(graphicData->Device, ShaderData->ShaderDescribe_DescriptorPool, null);
    }

    internal static void CreateDescriptorSetLayout(GraphicData* graphicData, ShaderData* shaderData)
    {

        VkDescriptorSetLayoutBinding* LayoutBinding = stackalloc VkDescriptorSetLayoutBinding[(int)1];

        LayoutBinding[0].binding = 0;
        LayoutBinding[0].descriptorCount = 1;
        LayoutBinding[0].descriptorType = VkDescriptorType.VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER;
        LayoutBinding[0].pImmutableSamplers = null;
        LayoutBinding[0].stageFlags = (uint)VkShaderStageFlagBits.VK_SHADER_STAGE_VERTEX_BIT;

        VkDescriptorSetLayoutCreateInfo layoutInfo = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO,
            bindingCount = 1, //2;
            pBindings = LayoutBinding
        };

        Vk.vkCreateDescriptorSetLayout(graphicData->Device, &layoutInfo, null, &shaderData->ShaderDescribe_DescriptorSetLayout);//.Check("failed to create descriptor set layout!");

        Log.Info("INFO", $"Create Descriptor Set layout : {shaderData->ShaderDescribe_DescriptorSetLayout}");

    }

    internal static unsafe void DisposeDescriptorSetLayout(GraphicData* graphicData, ShaderData* shaderData)
    {
        if (shaderData->ShaderDescribe_DescriptorSetLayout.IsNull) return;

        Log.Info("INFO", $"Destroy Descriptor Set layout : {shaderData->ShaderDescribe_DescriptorSetLayout}");
        Vk.vkDestroyDescriptorSetLayout(graphicData->Device, shaderData->ShaderDescribe_DescriptorSetLayout, null);
    }

    internal static void CreatePipelineLayout(GraphicData* graphicData, ShaderData* shaderData)
    //  ref VkDescriptorSetLayout descriptorSetLayout,ref VkPushConstantRange[] push_constants )
    {
        VkPushConstantRange push_constant;
        if (shaderData->HasPushConstant)
        {
            // PUSH CONSTANT
            //this push constant range starts at the beginning
            push_constant.offset = 0;
            //this push constant range takes up the size of a MeshPushConstants struct
            // push_constant.size =  Rita.Lib.Math.Geometry.PushConstantsBool.SizeInBytes ;
            //this push constant range is accessible only in the vertex shader
            push_constant.stageFlags = (uint)VkShaderStageFlagBits.VK_SHADER_STAGE_VERTEX_BIT;
        }


        VkPipelineLayoutCreateInfo pipelineLayoutInfo = new()
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_LAYOUT_CREATE_INFO,
            flags = 0,
            pNext = null,
            pSetLayouts = &shaderData->ShaderDescribe_DescriptorSetLayout,
            setLayoutCount = shaderData->DescriptorSetLayoutCount,
            pushConstantRangeCount = shaderData->HasPushConstant ? 1 : (uint)0,    // Optionnel
            pPushConstantRanges = shaderData->HasPushConstant ? &push_constant : null
        };

        Vk.vkCreatePipelineLayout(graphicData->Device, &pipelineLayoutInfo, null, &shaderData->PipelineLayout);//.Check ("failed to create pipeline layout!");

        Log.Info("INFO", $"Create Pipeline Layout : {shaderData->PipelineLayout}");
    }

    internal static void DisposePipelineLayout(GraphicData* graphicData, ShaderData* shaderData)
    // ref VkPipelineLayout pipelineLayout)
    {
        if (shaderData->PipelineLayout.IsNull) return;

        Log.Info("INFO", $"Destroy Pipeline Layout : {shaderData->PipelineLayout}");
        Vk.vkDestroyPipelineLayout(graphicData->Device, shaderData->PipelineLayout, null);
    }

    #endregion
}



#endif // TODO : Graphic Resource Creation

#endif