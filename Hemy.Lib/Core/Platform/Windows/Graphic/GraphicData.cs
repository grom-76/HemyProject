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
#endif


#endif