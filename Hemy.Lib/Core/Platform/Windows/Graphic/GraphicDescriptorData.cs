#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Graphic;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Hemy.Lib.Core.Graphic;
using Hemy.Lib.Core.Platform.Vulkan;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct GraphicDescriptorData()
{
    internal VkPipeline Pipeline = VkPipeline.Null;
    internal VkPipelineLayout PipelineLayout = VkPipelineLayout.Null;

    internal VkPipelineShaderStageCreateInfo* shaderStages = null;
    internal VkShaderModule ShaderModulesVertex = VkShaderModule.Null;
    internal VkShaderModule ShaderModulesFragment = VkShaderModule.Null;
    internal uint ShaderStageCount = 2;

    internal VkDynamicState* DynamicStates = null;
    internal uint DynamicStatesCount = 2;

    internal VkViewport* DynamicStateViewport = null;
    internal VkRect2D* DynamicStateScissor = null;

    //
    // internal VkDescriptorSetLayout ShaderDescribe_DescriptorSetLayout = VkDescriptorSetLayout.Null;
    // internal uint DescriptorSetLayoutCount = 0;
    // internal VkDescriptorPool ShaderDescribe_DescriptorPool = VkDescriptorPool.Null;
    // internal VkDescriptorSet* ShaderDescribe_DescriptorSets = null;
    // internal bool HasUniform = false; // USE CAMERA ...
    // internal bool HasPushConstant = false; // USE PUSH CONSTANT ....

    //attributeDescriptions for Vertex 
    // internal bool HasMesh = false;
    // internal uint Vertex_Stride = 0;
    // internal uint Vertex_Offset = 0;
    //STATE
    internal uint VertexCount = 3;
    internal uint InstanceCount = 1;
    internal VkPrimitiveTopology PrimitiveTopology = VkPrimitiveTopology.VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST;

    
   
}

#endif