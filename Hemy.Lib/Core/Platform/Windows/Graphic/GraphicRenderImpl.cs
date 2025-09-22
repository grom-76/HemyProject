#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Graphic;

using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Hemy.Lib.Core.Platform.Vulkan;
using Hemy.Lib.Core.Platform.Windows.Window;


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class GraphicRenderImpl
{

    internal static void GetMemoryPropeties(GraphicData* graphicData)
    {
        VkPhysicalDeviceMemoryProperties2* mem2 = stackalloc VkPhysicalDeviceMemoryProperties2[1];

        // if (graphicData->DeviceExtensions->IsExist(VK.VK_KHR_GET_PHYSICAL_DEVICE_PROPERTIES_2_EXTENSION_NAME))
        // {
        // 	Vk.vkGetPhysicalDeviceMemoryProperties2KHR(graphicData->DevicePhysical, &mem2);
        // 	graphicData->DeviceMemoryProperties = mem2.memoryProperties;
        // }
        // else
        // {
        Vk.vkGetPhysicalDeviceMemoryProperties2(graphicData->DevicePhysical, &mem2[0]);
        // graphicData->DeviceMemoryProperties = mem2.memoryProperties;
        // }

        // Vk.vkGetPhysicalDeviceMemoryProperties(graphicData->DevicePhysical, &graphicData->DeviceMemoryProperties);
    }

    internal static float[] PaletteToFloatRGBA(uint color)
    {
        // TODO Attention color Format SI ARGB Ou RGBA ??????
        float[] cc = [
            (float)Get_r(color)  / byte.MaxValue,
            (float)Get_g(color)  / byte.MaxValue,
            (float)Get_b(color)  / byte.MaxValue,
            (float)Get_a(color)  / byte.MaxValue
        ];
        return cc;
    }

    static byte Get_a(uint argbcolor) => (byte)(argbcolor >> 24);
    static byte Get_r(uint argbcolor) => (byte)(argbcolor >> 16);
    static byte Get_g(uint argbcolor) => (byte)(argbcolor >> 8);
    static byte Get_b(uint argbcolor) => (byte)(argbcolor & 0x000000FF);

    internal static void ChangeBackGroundColor(GraphicData* contextData, uint color)
    {
        var cl = PaletteToFloatRGBA(color); // TODO : be careful with color RGBA ARGBA ( 16 or 32bit ) see ColorFormat in GraphicDevice
        // contextData->RenderPassClearValues[0].color = new(cl);
        contextData->RenderPassClearValues[0].color.float32[0] = cl[0];
        contextData->RenderPassClearValues[0].color.float32[1] = cl[1];
        contextData->RenderPassClearValues[0].color.float32[2] = cl[2];
        contextData->RenderPassClearValues[0].color.float32[3] = cl[3];

        // if (graphicData->IsUseDepthBuffer)
        // {
        //     renderData->RenderPassClearValues[1].depthStencil = new();
        //     renderData->RenderPassClearValues[1].depthStencil.depth = 1.0f;
        //     renderData->RenderPassClearValues[1].depthStencil.stencil = 0;
        // }

    }

    internal static void CreateRenderPass(GraphicData* contextData) // + renderpass   + syncobj + command
    {
        // WindowsGraphicRender.CreateShader(contextData);
        // RENDER PASS AREA 
        // if 2 joeur split screen 
        if (contextData->RenderPassClearValues == null)
            contextData->RenderPassClearValues = Memory.Memory.NewArray<VkClearValue>(/*depth buffer =2*/ 1);
        // contextData->RenderPassClearValues = (VkClearValue*)NativeMemory.Alloc(1 * (uint)Unsafe.SizeOf<VkClearValue>());

        ChangeBackGroundColor(contextData, 4284782061u);

        // COLOR 
        VkAttachmentDescription* colorAttachment = stackalloc VkAttachmentDescription[1];

        colorAttachment[0].format = contextData->SwapChainImageFormat;
        colorAttachment[0].samples = VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT;
        colorAttachment[0].loadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_CLEAR;
        colorAttachment[0].storeOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_STORE;
        colorAttachment[0].stencilLoadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_DONT_CARE;
        colorAttachment[0].stencilStoreOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_DONT_CARE;
        colorAttachment[0].initialLayout = VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED;// TODO when depth buffer
        colorAttachment[0].finalLayout = VkImageLayout.VK_IMAGE_LAYOUT_PRESENT_SRC_KHR;
        colorAttachment[0].flags = (uint)VkAttachmentDescriptionFlagBits.VK_ATTACHMENT_DESCRIPTION_MAY_ALIAS_BIT;

        // SUBPASS  -> COLOR POST PROCESSING       
        VkAttachmentReference* colorAttachmentRef = stackalloc VkAttachmentReference[1];

        colorAttachmentRef[0].attachment = 0;
        colorAttachmentRef[0].layout = VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL;

        // SUBPASS
        VkSubpassDescription* subpass = stackalloc VkSubpassDescription[1];

        subpass[0].pipelineBindPoint = VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS;
        subpass[0].colorAttachmentCount = 1;
        subpass[0].pColorAttachments = &colorAttachmentRef[0];
        subpass[0].pDepthStencilAttachment = null; //&depthAttachmentRef;
        subpass[0].flags = 0;
        subpass[0].inputAttachmentCount = 0;
        subpass[0].pInputAttachments = null;
        subpass[0].pPreserveAttachments = null;
        subpass[0].preserveAttachmentCount = 0;
        subpass[0].pResolveAttachments = null;

        VkSubpassDependency* dependency = stackalloc VkSubpassDependency[1];

        dependency[0].srcSubpass = VK.VK_SUBPASS_EXTERNAL;
        dependency[0].dstSubpass = 0;
        dependency[0].srcStageMask = (uint)VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT;
        dependency[0].srcAccessMask = 0;//(uint)VkAccessFlagBits.VK_ACCESS_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT,
        dependency[0].dstStageMask = (uint)VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT;
        dependency[0].dstAccessMask = (uint)VkAccessFlagBits.VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT;
        dependency[0].dependencyFlags = 0;

        VkRenderPassCreateInfo* renderPassInfo = stackalloc VkRenderPassCreateInfo[1];

        renderPassInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO;
        // renderPassInfo[0].pAttachments = attachmentsDesc;
        renderPassInfo[0].attachmentCount = 1 /*isDepthStencil ? 2 : 1 */;
        renderPassInfo[0].pAttachments = &colorAttachment[0];
        renderPassInfo[0].subpassCount = 1;
        renderPassInfo[0].pSubpasses = &subpass[0];
        renderPassInfo[0].dependencyCount = 1;
        renderPassInfo[0].pDependencies = &dependency[0];
        renderPassInfo[0].flags = 0;
        renderPassInfo[0].pNext = null;

        VkResult result = Vk.vkCreateRenderPass(contextData->Device, &renderPassInfo[0], null, &contextData->RenderPass);//;//.Check("failed to create render pass!");

        // _ = Log.Check(result != VkResult.VK_SUCCESS, $"Create Render Pass : {contextData->RenderPass}") ? 1 : 0;

        CreateFrameBufer(contextData);
    }

    private static void CreateFrameBufer(GraphicData* contextData)
    {
        VkResult result = VkResult.VK_SUCCESS;

        if (contextData->Framebuffers == null)
            contextData->Framebuffers = Memory.Memory.NewArray<VkFramebuffer>(contextData->SwapChainImageViewsCount);
        // contextData->Framebuffers = (VkFramebuffer*)NativeMemory.Alloc(contextData->SwapChainImageViewsCount * (uint)Unsafe.SizeOf<VkFramebuffer>());

        // VkImageView* attachments2 = (VkImageView*)NativeMemory.Alloc(1 * (uint)Unsafe.SizeOf<VkImageView>());
        // TODO : replace attachements alloc par stackalloc 
        VkFramebufferCreateInfo* framebufferInfo = stackalloc VkFramebufferCreateInfo[1];
        for (int i = 0; i < contextData->SwapChainImageViewsCount; i++)
        {
            // attachments2[0] = contextData->SwapChainImageViews[i];
            // if( contextData->IsUseDepthBuffer )
            //     attachments2[1]  = contextData->DephtBufferImageViews[i] ;
            framebufferInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_FRAMEBUFFER_CREATE_INFO;
            framebufferInfo[0].renderPass = contextData->RenderPass;
            framebufferInfo[0].attachmentCount = 1;
            framebufferInfo[0].width = contextData->RenderPassArea->extent.width;
            framebufferInfo[0].height = contextData->RenderPassArea->extent.height;
            framebufferInfo[0].layers = 1;
            framebufferInfo[0].pAttachments = &contextData->SwapChainImageViews[i];
            framebufferInfo[0].pNext = null;
            // framebufferInfo[0].flags= (uint)VkFramebufferCreateFlagBits.VK_FRAMEBUFFER_CREATE_IMAGELESS_BIT_KHR;
            framebufferInfo[0].flags = 0;

            result = Vk.vkCreateFramebuffer(contextData->Device, &framebufferInfo[0], null, &contextData->Framebuffers[i]);//;//.Check("failed to create framebuffer!"); 

            if (VkResult.VK_SUCCESS != result)
            {
                Log.Error($"-{i} Create FrameBuffer {contextData->Framebuffers[i]}");
            }
        }
    }

    internal static void DisposeFrameBuffer(GraphicData* contextData)
    {
        if (contextData->Device.IsNotNull && contextData->Framebuffers != null)
        {
            for (int i = 0; i < contextData->SwapChainImageViewsCount; i++)
            {
                if (contextData->Framebuffers[i].IsNotNull)
                {
                    Vk.vkDestroyFramebuffer(contextData->Device, contextData->Framebuffers[i], null);
                }
            }
        }
    }

    internal static void CreateRender(GraphicData* contextData) // + renderpass   + syncobj + command
    {
        VkResult result;

        if (contextData->ImageAvailableSemaphores == null)
            // contextData->ImageAvailableSemaphores = (VkSemaphore*)NativeMemory.Alloc(contextData->MaxFrameInFlight * (uint)Unsafe.SizeOf<VkSemaphore>());
            contextData->ImageAvailableSemaphores = Memory.Memory.NewArray<VkSemaphore>(contextData->MaxFrameInFlight);
        //TODO : change NAtiveMEmor

        if (contextData->RenderFinishedSemaphores == null)
            // contextData->RenderFinishedSemaphores = (VkSemaphore*)NativeMemory.Alloc(contextData->MaxFrameInFlight * (uint)Unsafe.SizeOf<VkSemaphore>());
            contextData->RenderFinishedSemaphores = Memory.Memory.NewArray<VkSemaphore>(contextData->MaxFrameInFlight);

        VkSemaphoreCreateInfo* semaphoreInfo = stackalloc VkSemaphoreCreateInfo[1];
        semaphoreInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_SEMAPHORE_CREATE_INFO;
        semaphoreInfo[0].flags = 0;
        semaphoreInfo[0].pNext = null;

        for (uint i = 0; i < contextData->MaxFrameInFlight; i++)
        {
            result = Vk.vkCreateSemaphore(contextData->Device, &semaphoreInfo[0], null, &contextData->ImageAvailableSemaphores[i]);

            // _ = Log.Check(result != VkResult.VK_SUCCESS, $"-{i}  Create Image Semaphore Available : {contextData->ImageAvailableSemaphores[i]}");

            result = Vk.vkCreateSemaphore(contextData->Device, &semaphoreInfo[0], null, &contextData->RenderFinishedSemaphores[i]);

            // _ = Log.Check(result != VkResult.VK_SUCCESS, $"-{i}  Create Render Semaphore Available : {contextData->RenderFinishedSemaphores[i]}");

        }

        if (contextData->InFlightFences == null)
            // contextData->InFlightFences = (VkFence*)NativeMemory.Alloc(contextData->MaxFrameInFlight * (uint)Unsafe.SizeOf<VkFence>());
            contextData->InFlightFences = Memory.Memory.NewArray<VkFence>(contextData->MaxFrameInFlight);

        VkFenceCreateInfo* fenceInfo = stackalloc VkFenceCreateInfo[1];
        fenceInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_FENCE_CREATE_INFO;
        fenceInfo[0].flags = (uint)VkFenceCreateFlagBits.VK_FENCE_CREATE_SIGNALED_BIT;
        fenceInfo[0].pNext = null;

        for (uint i = 0; i < contextData->MaxFrameInFlight; i++)
        {
            result = Vk.vkCreateFence(contextData->Device, &fenceInfo[0], null, &contextData->InFlightFences[i]);//;//.Check("Failed to create Fence InFlightFence");

            // _ = Log.Check(result != VkResult.VK_SUCCESS, $"-{i}  Create Fence  : {contextData->InFlightFences[i]}");
        }

        VkCommandPoolCreateInfo* poolInfoCompute = stackalloc VkCommandPoolCreateInfo[1];
        poolInfoCompute[0].sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO;
        poolInfoCompute[0].flags = (uint)VkCommandPoolCreateFlagBits.VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT;
        poolInfoCompute[0].queueFamilyIndex = contextData->GraphicQueueIndex;
        poolInfoCompute[0].pNext = null;

        result = Vk.vkCreateCommandPool(contextData->Device, &poolInfoCompute[0], null, &contextData->CommandPool);

        // _ = Log.Check(result != VkResult.VK_SUCCESS, $"Create Command Pool {contextData->CommandPool}") ? 1 : 0;

        if (contextData->CommandBuffers == null)
            contextData->CommandBuffers = Memory.Memory.NewArray<VkCommandBuffer>(contextData->MaxFrameInFlight);
        // contextData->CommandBuffers = (VkCommandBuffer*)NativeMemory.Alloc(contextData->MaxFrameInFlight * (uint)Unsafe.SizeOf<VkCommandBuffer>());

        VkCommandBufferAllocateInfo* allocInfo = stackalloc VkCommandBufferAllocateInfo[1];
        allocInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_BUFFER_ALLOCATE_INFO;
        allocInfo[0].commandPool = contextData->CommandPool;
        allocInfo[0].level = VkCommandBufferLevel.VK_COMMAND_BUFFER_LEVEL_PRIMARY;
        allocInfo[0].commandBufferCount = (uint)contextData->MaxFrameInFlight;
        allocInfo[0].pNext = null;

        result = Vk.vkAllocateCommandBuffers(contextData->Device, &allocInfo[0], contextData->CommandBuffers);

        // _ = Log.Check(result != VkResult.VK_SUCCESS, "Create  Command buffer ") ? 1 : 0;
    }

    internal static void DisposeRender(GraphicData* contextData) // + renderpass   + syncobj + command
    {
        if (contextData->Device.IsNotNull && contextData->RenderPass.IsNotNull)
        {
            // Log.Info("INFO",$"Destroy Render Pass : {graphicData->RenderPass}");
            Vk.vkDestroyRenderPass(contextData->Device, contextData->RenderPass, null);
        }

        if (contextData->Device.IsNotNull && contextData->ImageAvailableSemaphores != null)
        {
            for (uint i = 0; i < contextData->MaxFrameInFlight; i++)
            {
                if (!contextData->ImageAvailableSemaphores[i].IsNull)
                {
                    // Log.Info($"-{i}  dispose Semaphore render Finish : {contextData->ImageAvailableSemaphores[i]}");
                    Vk.vkDestroySemaphore(contextData->Device, contextData->ImageAvailableSemaphores[i], null);
                }
            }
        }

        if (contextData->Device.IsNotNull && contextData->RenderFinishedSemaphores != null)
        {
            for (uint i = 0; i < contextData->MaxFrameInFlight; i++)
            {
                if (!contextData->RenderFinishedSemaphores[i].IsNull)
                {
                    // Log.Info($"-{i}  dispose Semaphore render Finish : {contextData->RenderFinishedSemaphores[i]}");
                    Vk.vkDestroySemaphore(contextData->Device, contextData->RenderFinishedSemaphores[i], null);
                }
            }
        }

        if (contextData->Device.IsNotNull && contextData->InFlightFences != null)
        {
            for (uint i = 0; i < contextData->MaxFrameInFlight; i++)
            {
                if (!contextData->InFlightFences[i].IsNull)
                {
                    // Log.Info($"-{i}  dispose Fence  : {contextData->InFlightFences[i]}");
                    Vk.vkDestroyFence(contextData->Device, contextData->InFlightFences[i], null);
                }
            }
        }

        if (contextData->CommandPool.IsNotNull)
        {
            // Log.Info($"Destroy Command Pool {contextData->CommandPool}");
            Vk.vkDestroyCommandPool(contextData->Device, contextData->CommandPool, null);
        }


    }

    static volatile uint currentFrame = 0;

    internal static void Draw(GraphicData* contextData)
    {
        uint* waitStages = stackalloc uint[1] { (uint)VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT | (uint)VkPipelineStageFlagBits.VK_PIPELINE_STAGE_EARLY_FRAGMENT_TESTS_BIT };
        VkFence CurrentinFlightFence = contextData->InFlightFences[currentFrame];
        ref VkSemaphore CurrentImageAvailableSemaphore = ref contextData->ImageAvailableSemaphores[currentFrame];
        ref VkSemaphore CurrentRenderFinishedSemaphore = ref contextData->RenderFinishedSemaphores[currentFrame];
        VkSemaphore* waitSemaphores = stackalloc VkSemaphore[1] { CurrentImageAvailableSemaphore };
        VkSemaphore* signalSemaphores = stackalloc VkSemaphore[1] { CurrentRenderFinishedSemaphore };
        VkSwapchainKHR* swapChains = stackalloc VkSwapchainKHR[1] { contextData->SwapChain };
        uint CurrentImageIndex = 0;
        contextData->CurrentCommandBuffer =  contextData->CommandBuffers[currentFrame] ;

        VkResult result = Vk.vkWaitForFences(contextData->Device, 1, &CurrentinFlightFence, /*VK_TRUE*/1, contextData->Ticktimeout);//;//.Check("Acquire Image");
        result = Vk.vkResetFences(contextData->Device, 1, &CurrentinFlightFence);
        //now that we are sure that the commands finished executing, we can safely reset the command buffer to begin recording again.
        result = Vk.vkResetCommandBuffer(contextData->CommandBuffers[currentFrame], (uint)VkCommandBufferResetFlagBits.VK_COMMAND_BUFFER_RESET_RELEASE_RESOURCES_BIT);
        //request image from the swapchain =>  // Acquire an index of drawing image for this frame.
        result = Vk.vkAcquireNextImageKHR(contextData->Device, contextData->SwapChain, contextData->Ticktimeout, CurrentImageAvailableSemaphore, VkFence.Null, &CurrentImageIndex);

        if (result == VkResult.VK_ERROR_OUT_OF_DATE_KHR)
        {
            // RecreateSwapChain(contextData);
            Log.Error("Draw error out of date");
            return;
        }
        else if (result != VkResult.VK_SUCCESS && result != VkResult.VK_SUBOPTIMAL_KHR)
        {
            return;
        }

        RecordCommandBuffer(contextData, CurrentImageIndex);

        VkSubmitInfo* submitInfo = stackalloc VkSubmitInfo[1];
        submitInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_SUBMIT_INFO;
        submitInfo[0].waitSemaphoreCount = 1;
        submitInfo[0].pWaitSemaphores = waitSemaphores;
        submitInfo[0].pWaitDstStageMask = waitStages;
        submitInfo[0].commandBufferCount = 1;
        submitInfo[0].pCommandBuffers = &contextData->CommandBuffers[currentFrame];
        submitInfo[0].signalSemaphoreCount = 1;
        submitInfo[0].pSignalSemaphores = signalSemaphores;
        submitInfo[0].pNext = null;

        result = Vk.vkQueueSubmit(contextData->GraphicQueue, 1, &submitInfo[0], CurrentinFlightFence);

        VkPresentInfoKHR* presentInfo = stackalloc VkPresentInfoKHR[1];
        presentInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_PRESENT_INFO_KHR;
        presentInfo[0].waitSemaphoreCount = 1;
        presentInfo[0].pWaitSemaphores = signalSemaphores;
        presentInfo[0].pImageIndices = &CurrentImageIndex;
        presentInfo[0].swapchainCount = 1;
        presentInfo[0].pSwapchains = swapChains;
        presentInfo[0].pNext = null;
        presentInfo[0].pResults = null;

        result = Vk.vkQueuePresentKHR(contextData->PresentQueue, &presentInfo[0]);

        if (result == VkResult.VK_ERROR_OUT_OF_DATE_KHR || result == VkResult.VK_SUBOPTIMAL_KHR)
        {
            // RecreateSwapChain(contextData);
            return;
        }
        else if (result != VkResult.VK_SUCCESS)
        {
            return;
        }

        currentFrame = (currentFrame + 1) % contextData->MaxFrameInFlight;
    }

    static void RecordCommandBuffer(GraphicData* contextData, uint currentImageIndex)
    {
        int renderPasses = 1;

        VkCommandBufferBeginInfo* beginInfo = stackalloc VkCommandBufferBeginInfo[1];
        beginInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_BUFFER_BEGIN_INFO;
        beginInfo[0].pNext = null;
        beginInfo[0].flags = (uint)VkCommandBufferUsageFlagBits.VK_COMMAND_BUFFER_USAGE_ONE_TIME_SUBMIT_BIT;
        beginInfo[0].pInheritanceInfo = null;

        var result = Vk.vkBeginCommandBuffer(contextData->CommandBuffers[currentFrame], &beginInfo[0]);

        // FOREACH RENDER PASS 
        VkRenderPassBeginInfo* renderPassInfo = stackalloc VkRenderPassBeginInfo[renderPasses];

        for (int i = 0; i < renderPasses; i++)
        {
            renderPassInfo[i].sType = VkStructureType.VK_STRUCTURE_TYPE_RENDER_PASS_BEGIN_INFO;
            renderPassInfo[i].pNext = null;
            renderPassInfo[i].renderArea = *contextData->RenderPassArea;
            renderPassInfo[i].renderPass = contextData->RenderPass;
            renderPassInfo[i].framebuffer = contextData->Framebuffers[currentImageIndex];
            renderPassInfo[i].clearValueCount = 1;/* contextData->IsUseDepthBuffer ? (uint)2 : (uint)1;*/
            renderPassInfo[i].pClearValues = contextData->RenderPassClearValues;

            Vk.vkCmdBeginRenderPass(contextData->CommandBuffers[currentFrame], &renderPassInfo[i], VkSubpassContents.VK_SUBPASS_CONTENTS_INLINE);
            // Vk.vkCmdBeginRenderPass2(currentCommandBuffer, &renderPassInfo[i], null);

            contextData->RenderPipeline();

            Vk.vkCmdEndRenderPass(contextData->CommandBuffers[currentFrame]);
        } // END FOREACH RENDER PASS 

        result = Vk.vkEndCommandBuffer(contextData->CommandBuffers[currentFrame]);
    }

  

    public static void EmptyDrawPipeline()
    {
       
    }
    


}

#endif