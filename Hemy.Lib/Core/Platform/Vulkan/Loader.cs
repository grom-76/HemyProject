namespace Hemy.Lib.Core.Platform.Vulkan;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security; 

using uint32_t = System.UInt32;
using uint64_t = System.UInt64;
using uint8_t = System.Byte;
using int32_t = System.Int32;
using int64_t = System.Int64;
using uint16_t = System.UInt16;
using ConstChar = System.Byte;
using size_t = System.UInt64;//ulong

using VkBool32 = System.UInt32;
using VkDeviceAddress = System.UInt64;
using VkDeviceSize = System.UInt64;
using VkSampleMask = System.UInt32;
using VkImageAspectFlags = System.UInt32;
using VkImageCreateFlags = System.UInt32;
using VkImageUsageFlags = System.UInt32;
using VkPipelineStageFlags = System.UInt32;
using VkMemoryMapFlags = System.UInt32;
using VkQueryResultFlags = System.UInt32;
using VkColorComponentFlags = System.UInt32;
using VkCullModeFlags = System.UInt32;
using VkShaderStageFlags = System.UInt32;
using VkDescriptorPoolResetFlags = System.UInt32;
using VkDependencyFlags = System.UInt32;
using VkCommandPoolResetFlags = System.UInt32;
using VkQueryControlFlags = System.UInt32;
using VkCommandBufferResetFlags = System.UInt32;
using VkStencilFaceFlags = System.UInt32;
using VkPeerMemoryFeatureFlags = System.UInt32;
using VkCommandPoolTrimFlags = System.UInt32;
using VkPipelineStageFlags2 = System.UInt64;
using VkDeviceGroupPresentModeFlagsKHR = System.UInt32;
using VkMemoryRequirements2KHR = VkMemoryRequirements2;
using VkDebugReportFlagsEXT = System.UInt32;
using VkExternalMemoryHandleTypeFlagsNV = System.UInt32;
using VkDebugUtilsMessageTypeFlagsEXT = System.UInt32;
using VkLineRasterizationModeEXT = VkLineRasterizationMode;
using VkRemoteAddressNV = System.IntPtr;
using VkPipelineInfoEXT = VkPipelineInfoKHR;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE)]
public static class Loader
{
    public unsafe static void* LoadInstanceFunc(void* vkInstance, string name)
    {
#if WINDOWS        
        byte* str = Hemy.Lib.Core.Memory.Memory.NewStr(name);
        void* result = Vk.vkGetInstanceProcAddr((VkInstance)vkInstance, str);
        Hemy.Lib.Core.Memory.Memory.DisposeStr(str);
        if ( result == null)
            Log.Warning( "Instance function pointer not found for : " + name);
#endif
        return result;
    }

    public unsafe static void* LoadDeviceFunc(void* vkDevice, string name)
    {
#if WINDOWS
        byte* str = Hemy.Lib.Core.Memory.Memory.NewStr(name);
        void* result = Vk.vkGetDeviceProcAddr((VkDevice)vkDevice, str);
        Hemy.Lib.Core.Memory.Memory.DisposeStr(str);
        if ( result == null)
            Log.Warning( "Instance function pointer not found for : " + name);
#endif
        return result;
    }

    public unsafe delegate void* LoadFunction(void* ptr, string name);

    public unsafe static void Load(LoadFunction load, void* ptr, Hemy.Lib.Core.Memory.StrArray* extensions)
    {
        
        for (uint i = 0; i < extensions->Count; i++)
        {
            string extension = extensions->GetString(i);

            if (extension.Contains(VK.VK_KHR_SURFACE_EXTENSION_NAME,System.StringComparison.InvariantCulture))
            {

                fixed (delegate* unmanaged<VkInstance, VkSurfaceKHR, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroySurfaceKHR)
                {
                    *pointer = (delegate* unmanaged<VkInstance, VkSurfaceKHR, VkAllocationCallbacks*, void>)load(ptr, "vkDestroySurfaceKHR");
                }

            }
            if (extension.Contains(VK.VK_KHR_SWAPCHAIN_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>* pointer = &Vk.vkCreateSwapchainKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)load(ptr, "vkCreateSwapchainKHR");
                }

                fixed (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroySwapchainKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkAllocationCallbacks*, void>)load(ptr, "vkDestroySwapchainKHR");
                }

                fixed (delegate* unmanaged<VkDevice, VkSwapchainKHR, uint32_t*, VkImage*, VkResult>* pointer = &Vk.vkGetSwapchainImagesKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSwapchainKHR, uint32_t*, VkImage*, VkResult>)load(ptr, "vkGetSwapchainImagesKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkSwapchainKHR, uint64_t, VkSemaphore, VkFence, uint32_t*, VkResult>* pointer = &Vk.vkAcquireNextImageKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSwapchainKHR, uint64_t, VkSemaphore, VkFence, uint32_t*, VkResult>)load(ptr, "vkAcquireNextImageKHR");
                }
                fixed (delegate* unmanaged<VkQueue, VkPresentInfoKHR*, VkResult>* pointer = &Vk.vkQueuePresentKHR)
                {
                    *pointer = (delegate* unmanaged<VkQueue, VkPresentInfoKHR*, VkResult>)load(ptr, "vkQueuePresentKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkAcquireNextImageInfoKHR*, uint32_t*, VkResult>* pointer = &Vk.vkAcquireNextImage2KHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkAcquireNextImageInfoKHR*, uint32_t*, VkResult>)load(ptr, "vkAcquireNextImage2KHR");
                }

            }
            if (extension.Contains(VK.VK_KHR_DISPLAY_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t, uint32_t*, VkDisplayKHR*, VkResult>* pointer = &Vk.vkGetDisplayPlaneSupportedDisplaysKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t, uint32_t*, VkDisplayKHR*, VkResult>)load(ptr, "vkGetDisplayPlaneSupportedDisplaysKHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, VkDisplayKHR, uint32_t*, VkDisplayModePropertiesKHR*, VkResult>* pointer = &Vk.vkGetDisplayModePropertiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkDisplayKHR, uint32_t*, VkDisplayModePropertiesKHR*, VkResult>)load(ptr, "vkGetDisplayModePropertiesKHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, VkDisplayKHR, VkDisplayModeCreateInfoKHR*, VkAllocationCallbacks*, VkDisplayModeKHR*, VkResult>* pointer = &Vk.vkCreateDisplayModeKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkDisplayKHR, VkDisplayModeCreateInfoKHR*, VkAllocationCallbacks*, VkDisplayModeKHR*, VkResult>)load(ptr, "vkCreateDisplayModeKHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, VkDisplayModeKHR, uint32_t, VkDisplayPlaneCapabilitiesKHR*, VkResult>* pointer = &Vk.vkGetDisplayPlaneCapabilitiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkDisplayModeKHR, uint32_t, VkDisplayPlaneCapabilitiesKHR*, VkResult>)load(ptr, "vkGetDisplayPlaneCapabilitiesKHR");
                }
                fixed (delegate* unmanaged<VkInstance, VkDisplaySurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>* pointer = &Vk.vkCreateDisplayPlaneSurfaceKHR)
                {
                    *pointer = (delegate* unmanaged<VkInstance, VkDisplaySurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)load(ptr, "vkCreateDisplayPlaneSurfaceKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_DISPLAY_SWAPCHAIN_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, uint32_t, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>* pointer = &Vk.vkCreateSharedSwapchainsKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, uint32_t, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult>)load(ptr, "vkCreateSharedSwapchainsKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_VIDEO_QUEUE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkVideoSessionCreateInfoKHR*, VkAllocationCallbacks*, VkVideoSessionKHR*, VkResult>* pointer = &Vk.vkCreateVideoSessionKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkVideoSessionCreateInfoKHR*, VkAllocationCallbacks*, VkVideoSessionKHR*, VkResult>)load(ptr, "vkCreateVideoSessionKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkVideoSessionKHR, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyVideoSessionKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkVideoSessionKHR, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyVideoSessionKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkVideoSessionKHR, uint32_t*, VkVideoSessionMemoryRequirementsKHR*, VkResult>* pointer = &Vk.vkGetVideoSessionMemoryRequirementsKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkVideoSessionKHR, uint32_t*, VkVideoSessionMemoryRequirementsKHR*, VkResult>)load(ptr, "vkGetVideoSessionMemoryRequirementsKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkVideoSessionKHR, uint32_t, VkBindVideoSessionMemoryInfoKHR*, VkResult>* pointer = &Vk.vkBindVideoSessionMemoryKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkVideoSessionKHR, uint32_t, VkBindVideoSessionMemoryInfoKHR*, VkResult>)load(ptr, "vkBindVideoSessionMemoryKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkVideoSessionParametersCreateInfoKHR*, VkAllocationCallbacks*, VkVideoSessionParametersKHR*, VkResult>* pointer = &Vk.vkCreateVideoSessionParametersKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkVideoSessionParametersCreateInfoKHR*, VkAllocationCallbacks*, VkVideoSessionParametersKHR*, VkResult>)load(ptr, "vkCreateVideoSessionParametersKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkVideoSessionParametersKHR, VkVideoSessionParametersUpdateInfoKHR*, VkResult>* pointer = &Vk.vkUpdateVideoSessionParametersKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkVideoSessionParametersKHR, VkVideoSessionParametersUpdateInfoKHR*, VkResult>)load(ptr, "vkUpdateVideoSessionParametersKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkVideoSessionParametersKHR, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyVideoSessionParametersKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkVideoSessionParametersKHR, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyVideoSessionParametersKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkVideoBeginCodingInfoKHR*, void>* pointer = &Vk.vkCmdBeginVideoCodingKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkVideoBeginCodingInfoKHR*, void>)load(ptr, "vkCmdBeginVideoCodingKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkVideoEndCodingInfoKHR*, void>* pointer = &Vk.vkCmdEndVideoCodingKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkVideoEndCodingInfoKHR*, void>)load(ptr, "vkCmdEndVideoCodingKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkVideoCodingControlInfoKHR*, void>* pointer = &Vk.vkCmdControlVideoCodingKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkVideoCodingControlInfoKHR*, void>)load(ptr, "vkCmdControlVideoCodingKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_VIDEO_DECODE_QUEUE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkVideoDecodeInfoKHR*, void>* pointer = &Vk.vkCmdDecodeVideoKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkVideoDecodeInfoKHR*, void>)load(ptr, "vkCmdDecodeVideoKHR");
                }

            }
            if (extension.Contains(VK.VK_KHR_DYNAMIC_RENDERING_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkRenderingInfo*, void>* pointer = &Vk.vkCmdBeginRenderingKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkRenderingInfo*, void>)load(ptr, "vkCmdBeginRenderingKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, void>* pointer = &Vk.vkCmdEndRenderingKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, void>)load(ptr, "vkCmdEndRenderingKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_DEVICE_GROUP_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, uint32_t, uint32_t, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdDispatchBaseKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, uint32_t, uint32_t, uint32_t, uint32_t, void>)load(ptr, "vkCmdDispatchBaseKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_MAINTENANCE1_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkCommandPool, VkCommandPoolTrimFlags, void>* pointer = &Vk.vkTrimCommandPoolKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkCommandPool, VkCommandPoolTrimFlags, void>)load(ptr, "vkTrimCommandPoolKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_EXTERNAL_MEMORY_FD_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkMemoryGetFdInfoKHR*, int*, VkResult>* pointer = &Vk.vkGetMemoryFdKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkMemoryGetFdInfoKHR*, int*, VkResult>)load(ptr, "vkGetMemoryFdKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkExternalMemoryHandleTypeFlagBits, int, VkMemoryFdPropertiesKHR*, VkResult>* pointer = &Vk.vkGetMemoryFdPropertiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkExternalMemoryHandleTypeFlagBits, int, VkMemoryFdPropertiesKHR*, VkResult>)load(ptr, "vkGetMemoryFdPropertiesKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_EXTERNAL_SEMAPHORE_FD_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkImportSemaphoreFdInfoKHR*, VkResult>* pointer = &Vk.vkImportSemaphoreFdKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkImportSemaphoreFdInfoKHR*, VkResult>)load(ptr, "vkImportSemaphoreFdKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkSemaphoreGetFdInfoKHR*, int*, VkResult>* pointer = &Vk.vkGetSemaphoreFdKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSemaphoreGetFdInfoKHR*, int*, VkResult>)load(ptr, "vkGetSemaphoreFdKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_PUSH_DESCRIPTOR_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint32_t, uint32_t, VkWriteDescriptorSet*, void>* pointer = &Vk.vkCmdPushDescriptorSetKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint32_t, uint32_t, VkWriteDescriptorSet*, void>)load(ptr, "vkCmdPushDescriptorSetKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkDescriptorUpdateTemplate, VkPipelineLayout, uint32_t, void*, void>* pointer = &Vk.vkCmdPushDescriptorSetWithTemplateKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkDescriptorUpdateTemplate, VkPipelineLayout, uint32_t, void*, void>)load(ptr, "vkCmdPushDescriptorSetWithTemplateKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_DESCRIPTOR_UPDATE_TEMPLATE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkDescriptorUpdateTemplateCreateInfo*, VkAllocationCallbacks*, VkDescriptorUpdateTemplate*, VkResult>* pointer = &Vk.vkCreateDescriptorUpdateTemplateKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDescriptorUpdateTemplateCreateInfo*, VkAllocationCallbacks*, VkDescriptorUpdateTemplate*, VkResult>)load(ptr, "vkCreateDescriptorUpdateTemplateKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkDescriptorUpdateTemplate, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyDescriptorUpdateTemplateKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDescriptorUpdateTemplate, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyDescriptorUpdateTemplateKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkDescriptorSet, VkDescriptorUpdateTemplate, void*, void>* pointer = &Vk.vkUpdateDescriptorSetWithTemplateKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDescriptorSet, VkDescriptorUpdateTemplate, void*, void>)load(ptr, "vkUpdateDescriptorSetWithTemplateKHR");
                }
            }

            if (extension.Contains(VK.VK_KHR_CREATE_RENDERPASS_2_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkRenderPassCreateInfo2*, VkAllocationCallbacks*, VkRenderPass*, VkResult>* pointer = &Vk.vkCreateRenderPass2KHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkRenderPassCreateInfo2*, VkAllocationCallbacks*, VkRenderPass*, VkResult>)load(ptr, "vkCreateRenderPass2KHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkRenderPassBeginInfo*, VkSubpassBeginInfo*, void>* pointer = &Vk.vkCmdBeginRenderPass2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkRenderPassBeginInfo*, VkSubpassBeginInfo*, void>)load(ptr, "vkCmdBeginRenderPass2KHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkSubpassBeginInfo*, VkSubpassEndInfo*, void>* pointer = &Vk.vkCmdNextSubpass2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkSubpassBeginInfo*, VkSubpassEndInfo*, void>)load(ptr, "vkCmdNextSubpass2KHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkSubpassEndInfo*, void>* pointer = &Vk.vkCmdEndRenderPass2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkSubpassEndInfo*, void>)load(ptr, "vkCmdEndRenderPass2KHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_SHARED_PRESENTABLE_IMAGE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkResult>* pointer = &Vk.vkGetSwapchainStatusKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkResult>)load(ptr, "vkGetSwapchainStatusKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_EXTERNAL_FENCE_FD_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkImportFenceFdInfoKHR*, VkResult>* pointer = &Vk.vkImportFenceFdKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkImportFenceFdInfoKHR*, VkResult>)load(ptr, "vkImportFenceFdKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkFenceGetFdInfoKHR*, int*, VkResult>* pointer = &Vk.vkGetFenceFdKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkFenceGetFdInfoKHR*, int*, VkResult>)load(ptr, "vkGetFenceFdKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_PERFORMANCE_QUERY_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkAcquireProfilingLockInfoKHR*, VkResult>* pointer = &Vk.vkAcquireProfilingLockKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkAcquireProfilingLockInfoKHR*, VkResult>)load(ptr, "vkAcquireProfilingLockKHR");
                }
                fixed (delegate* unmanaged<VkDevice, void>* pointer = &Vk.vkReleaseProfilingLockKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, void>)load(ptr, "vkReleaseProfilingLockKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_GET_DISPLAY_PROPERTIES_2_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, VkDisplayKHR, uint32_t*, VkDisplayModeProperties2KHR*, VkResult>* pointer = &Vk.vkGetDisplayModeProperties2KHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkDisplayKHR, uint32_t*, VkDisplayModeProperties2KHR*, VkResult>)load(ptr, "vkGetDisplayModeProperties2KHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, VkDisplayPlaneInfo2KHR*, VkDisplayPlaneCapabilities2KHR*, VkResult>* pointer = &Vk.vkGetDisplayPlaneCapabilities2KHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkDisplayPlaneInfo2KHR*, VkDisplayPlaneCapabilities2KHR*, VkResult>)load(ptr, "vkGetDisplayPlaneCapabilities2KHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_GET_MEMORY_REQUIREMENTS_2_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkImageMemoryRequirementsInfo2*, VkMemoryRequirements2*, void>* pointer = &Vk.vkGetImageMemoryRequirements2KHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkImageMemoryRequirementsInfo2*, VkMemoryRequirements2*, void>)load(ptr, "vkGetImageMemoryRequirements2KHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkBufferMemoryRequirementsInfo2*, VkMemoryRequirements2*, void>* pointer = &Vk.vkGetBufferMemoryRequirements2KHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkBufferMemoryRequirementsInfo2*, VkMemoryRequirements2*, void>)load(ptr, "vkGetBufferMemoryRequirements2KHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkImageSparseMemoryRequirementsInfo2*, uint32_t*, VkSparseImageMemoryRequirements2*, void>* pointer = &Vk.vkGetImageSparseMemoryRequirements2KHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkImageSparseMemoryRequirementsInfo2*, uint32_t*, VkSparseImageMemoryRequirements2*, void>)load(ptr, "vkGetImageSparseMemoryRequirements2KHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_SAMPLER_YCBCR_CONVERSION_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkSamplerYcbcrConversionCreateInfo*, VkAllocationCallbacks*, VkSamplerYcbcrConversion*, VkResult>* pointer = &Vk.vkCreateSamplerYcbcrConversionKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSamplerYcbcrConversionCreateInfo*, VkAllocationCallbacks*, VkSamplerYcbcrConversion*, VkResult>)load(ptr, "vkCreateSamplerYcbcrConversionKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkSamplerYcbcrConversion, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroySamplerYcbcrConversionKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSamplerYcbcrConversion, VkAllocationCallbacks*, void>)load(ptr, "vkDestroySamplerYcbcrConversionKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_BIND_MEMORY_2_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, uint32_t, VkBindBufferMemoryInfo*, VkResult>* pointer = &Vk.vkBindBufferMemory2KHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, uint32_t, VkBindBufferMemoryInfo*, VkResult>)load(ptr, "vkBindBufferMemory2KHR");
                }
                fixed (delegate* unmanaged<VkDevice, uint32_t, VkBindImageMemoryInfo*, VkResult>* pointer = &Vk.vkBindImageMemory2KHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, uint32_t, VkBindImageMemoryInfo*, VkResult>)load(ptr, "vkBindImageMemory2KHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_MAINTENANCE3_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkDescriptorSetLayoutCreateInfo*, VkDescriptorSetLayoutSupport*, void>* pointer = &Vk.vkGetDescriptorSetLayoutSupportKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDescriptorSetLayoutCreateInfo*, VkDescriptorSetLayoutSupport*, void>)load(ptr, "vkGetDescriptorSetLayoutSupportKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_DRAW_INDIRECT_COUNT_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdDrawIndirectCountKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>)load(ptr, "vkCmdDrawIndirectCountKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdDrawIndexedIndirectCountKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>)load(ptr, "vkCmdDrawIndexedIndirectCountKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_TIMELINE_SEMAPHORE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkSemaphore, uint64_t*, VkResult>* pointer = &Vk.vkGetSemaphoreCounterValueKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSemaphore, uint64_t*, VkResult>)load(ptr, "vkGetSemaphoreCounterValueKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkSemaphoreWaitInfo*, uint64_t, VkResult>* pointer = &Vk.vkWaitSemaphoresKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSemaphoreWaitInfo*, uint64_t, VkResult>)load(ptr, "vkWaitSemaphoresKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkSemaphoreSignalInfo*, VkResult>* pointer = &Vk.vkSignalSemaphoreKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSemaphoreSignalInfo*, VkResult>)load(ptr, "vkSignalSemaphoreKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_FRAGMENT_SHADING_RATE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkExtent2D*, VkFragmentShadingRateCombinerOpKHR, void>* pointer = &Vk.vkCmdSetFragmentShadingRateKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkExtent2D*, VkFragmentShadingRateCombinerOpKHR, void>)load(ptr, "vkCmdSetFragmentShadingRateKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_DYNAMIC_RENDERING_LOCAL_READ_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkRenderingAttachmentLocationInfo*, void>* pointer = &Vk.vkCmdSetRenderingAttachmentLocationsKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkRenderingAttachmentLocationInfo*, void>)load(ptr, "vkCmdSetRenderingAttachmentLocationsKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkRenderingInputAttachmentIndexInfo*, void>* pointer = &Vk.vkCmdSetRenderingInputAttachmentIndicesKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkRenderingInputAttachmentIndexInfo*, void>)load(ptr, "vkCmdSetRenderingInputAttachmentIndicesKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_PRESENT_WAIT_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkSwapchainKHR, uint64_t, uint64_t, VkResult>* pointer = &Vk.vkWaitForPresentKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSwapchainKHR, uint64_t, uint64_t, VkResult>)load(ptr, "vkWaitForPresentKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_BUFFER_DEVICE_ADDRESS_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkBufferDeviceAddressInfo*, uint64_t>* pointer = &Vk.vkGetBufferOpaqueCaptureAddressKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkBufferDeviceAddressInfo*, uint64_t>)load(ptr, "vkGetBufferOpaqueCaptureAddressKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_DEFERRED_HOST_OPERATIONS_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkAllocationCallbacks*, VkDeferredOperationKHR*, VkResult>* pointer = &Vk.vkCreateDeferredOperationKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkAllocationCallbacks*, VkDeferredOperationKHR*, VkResult>)load(ptr, "vkCreateDeferredOperationKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyDeferredOperationKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyDeferredOperationKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, uint32_t>* pointer = &Vk.vkGetDeferredOperationMaxConcurrencyKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, uint32_t>)load(ptr, "vkGetDeferredOperationMaxConcurrencyKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkResult>* pointer = &Vk.vkGetDeferredOperationResultKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkResult>)load(ptr, "vkGetDeferredOperationResultKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkResult>* pointer = &Vk.vkDeferredOperationJoinKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkResult>)load(ptr, "vkDeferredOperationJoinKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_PIPELINE_EXECUTABLE_PROPERTIES_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkPipelineInfoKHR*, uint32_t*, VkPipelineExecutablePropertiesKHR*, VkResult>* pointer = &Vk.vkGetPipelineExecutablePropertiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPipelineInfoKHR*, uint32_t*, VkPipelineExecutablePropertiesKHR*, VkResult>)load(ptr, "vkGetPipelineExecutablePropertiesKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkPipelineExecutableInfoKHR*, uint32_t*, VkPipelineExecutableStatisticKHR*, VkResult>* pointer = &Vk.vkGetPipelineExecutableStatisticsKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPipelineExecutableInfoKHR*, uint32_t*, VkPipelineExecutableStatisticKHR*, VkResult>)load(ptr, "vkGetPipelineExecutableStatisticsKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkPipelineExecutableInfoKHR*, uint32_t*, VkPipelineExecutableInternalRepresentationKHR*, VkResult>* pointer = &Vk.vkGetPipelineExecutableInternalRepresentationsKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPipelineExecutableInfoKHR*, uint32_t*, VkPipelineExecutableInternalRepresentationKHR*, VkResult>)load(ptr, "vkGetPipelineExecutableInternalRepresentationsKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_MAP_MEMORY_2_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkMemoryMapInfo*, void**, VkResult>* pointer = &Vk.vkMapMemory2KHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkMemoryMapInfo*, void**, VkResult>)load(ptr, "vkMapMemory2KHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkMemoryUnmapInfo*, VkResult>* pointer = &Vk.vkUnmapMemory2KHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkMemoryUnmapInfo*, VkResult>)load(ptr, "vkUnmapMemory2KHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_VIDEO_ENCODE_QUEUE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkVideoEncodeSessionParametersGetInfoKHR*, VkVideoEncodeSessionParametersFeedbackInfoKHR*, /* size_t* */ nuint , void*, VkResult>* pointer = &Vk.vkGetEncodedVideoSessionParametersKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkVideoEncodeSessionParametersGetInfoKHR*, VkVideoEncodeSessionParametersFeedbackInfoKHR*, /* size_t* */ nuint , void*, VkResult>)load(ptr, "vkGetEncodedVideoSessionParametersKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkVideoEncodeInfoKHR*, void>* pointer = &Vk.vkCmdEncodeVideoKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkVideoEncodeInfoKHR*, void>)load(ptr, "vkCmdEncodeVideoKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_SYNCHRONIZATION_2_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkEvent, VkDependencyInfo*, void>* pointer = &Vk.vkCmdSetEvent2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkEvent, VkDependencyInfo*, void>)load(ptr, "vkCmdSetEvent2KHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkEvent, VkPipelineStageFlags2, void>* pointer = &Vk.vkCmdResetEvent2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkEvent, VkPipelineStageFlags2, void>)load(ptr, "vkCmdResetEvent2KHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkEvent*, VkDependencyInfo*, void>* pointer = &Vk.vkCmdWaitEvents2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkEvent*, VkDependencyInfo*, void>)load(ptr, "vkCmdWaitEvents2KHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkDependencyInfo*, void>* pointer = &Vk.vkCmdPipelineBarrier2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkDependencyInfo*, void>)load(ptr, "vkCmdPipelineBarrier2KHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkPipelineStageFlags2, VkQueryPool, uint32_t, void>* pointer = &Vk.vkCmdWriteTimestamp2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPipelineStageFlags2, VkQueryPool, uint32_t, void>)load(ptr, "vkCmdWriteTimestamp2KHR");
                }
                fixed (delegate* unmanaged<VkQueue, uint32_t, VkSubmitInfo2*, VkFence, VkResult>* pointer = &Vk.vkQueueSubmit2KHR)
                {
                    *pointer = (delegate* unmanaged<VkQueue, uint32_t, VkSubmitInfo2*, VkFence, VkResult>)load(ptr, "vkQueueSubmit2KHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_COPY_COMMANDS_2_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkCopyBufferInfo2*, void>* pointer = &Vk.vkCmdCopyBuffer2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkCopyBufferInfo2*, void>)load(ptr, "vkCmdCopyBuffer2KHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkCopyImageInfo2*, void>* pointer = &Vk.vkCmdCopyImage2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkCopyImageInfo2*, void>)load(ptr, "vkCmdCopyImage2KHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkCopyBufferToImageInfo2*, void>* pointer = &Vk.vkCmdCopyBufferToImage2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkCopyBufferToImageInfo2*, void>)load(ptr, "vkCmdCopyBufferToImage2KHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkCopyImageToBufferInfo2*, void>* pointer = &Vk.vkCmdCopyImageToBuffer2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkCopyImageToBufferInfo2*, void>)load(ptr, "vkCmdCopyImageToBuffer2KHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBlitImageInfo2*, void>* pointer = &Vk.vkCmdBlitImage2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBlitImageInfo2*, void>)load(ptr, "vkCmdBlitImage2KHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkResolveImageInfo2*, void>* pointer = &Vk.vkCmdResolveImage2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkResolveImageInfo2*, void>)load(ptr, "vkCmdResolveImage2KHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_RAY_TRACING_MAINTENANCE_1_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkDeviceAddress, void>* pointer = &Vk.vkCmdTraceRaysIndirect2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkDeviceAddress, void>)load(ptr, "vkCmdTraceRaysIndirect2KHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_MAINTENANCE_5_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkDeviceSize, VkIndexType, void>* pointer = &Vk.vkCmdBindIndexBuffer2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkDeviceSize, VkIndexType, void>)load(ptr, "vkCmdBindIndexBuffer2KHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkRenderingAreaInfo*, VkExtent2D*, void>* pointer = &Vk.vkGetRenderingAreaGranularityKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkRenderingAreaInfo*, VkExtent2D*, void>)load(ptr, "vkGetRenderingAreaGranularityKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkImage, VkImageSubresource2*, VkSubresourceLayout2*, void>* pointer = &Vk.vkGetImageSubresourceLayout2KHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkImage, VkImageSubresource2*, VkSubresourceLayout2*, void>)load(ptr, "vkGetImageSubresourceLayout2KHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_PIPELINE_BINARY_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkPipelineBinaryCreateInfoKHR*, VkAllocationCallbacks*, VkPipelineBinaryHandlesInfoKHR*, VkResult>* pointer = &Vk.vkCreatePipelineBinariesKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPipelineBinaryCreateInfoKHR*, VkAllocationCallbacks*, VkPipelineBinaryHandlesInfoKHR*, VkResult>)load(ptr, "vkCreatePipelineBinariesKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkPipelineBinaryKHR, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyPipelineBinaryKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPipelineBinaryKHR, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyPipelineBinaryKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkPipelineCreateInfoKHR*, VkPipelineBinaryKeyKHR*, VkResult>* pointer = &Vk.vkGetPipelineKeyKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPipelineCreateInfoKHR*, VkPipelineBinaryKeyKHR*, VkResult>)load(ptr, "vkGetPipelineKeyKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkPipelineBinaryDataInfoKHR*, VkPipelineBinaryKeyKHR*, /* size_t* */ nuint , void*, VkResult>* pointer = &Vk.vkGetPipelineBinaryDataKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPipelineBinaryDataInfoKHR*, VkPipelineBinaryKeyKHR*, /* size_t* */ nuint , void*, VkResult>)load(ptr, "vkGetPipelineBinaryDataKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkReleaseCapturedPipelineDataInfoKHR*, VkAllocationCallbacks*, VkResult>* pointer = &Vk.vkReleaseCapturedPipelineDataKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkReleaseCapturedPipelineDataInfoKHR*, VkAllocationCallbacks*, VkResult>)load(ptr, "vkReleaseCapturedPipelineDataKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_LINE_RASTERIZATION_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint16_t, void>* pointer = &Vk.vkCmdSetLineStippleKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint16_t, void>)load(ptr, "vkCmdSetLineStippleKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_CALIBRATED_TIMESTAMPS_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, uint32_t, VkCalibratedTimestampInfoKHR*, uint64_t*, uint64_t*, VkResult>* pointer = &Vk.vkGetCalibratedTimestampsKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, uint32_t, VkCalibratedTimestampInfoKHR*, uint64_t*, uint64_t*, VkResult>)load(ptr, "vkGetCalibratedTimestampsKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_MAINTENANCE_6_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkBindDescriptorSetsInfo*, void>* pointer = &Vk.vkCmdBindDescriptorSets2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBindDescriptorSetsInfo*, void>)load(ptr, "vkCmdBindDescriptorSets2KHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkPushConstantsInfo*, void>* pointer = &Vk.vkCmdPushConstants2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPushConstantsInfo*, void>)load(ptr, "vkCmdPushConstants2KHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkPushDescriptorSetInfo*, void>* pointer = &Vk.vkCmdPushDescriptorSet2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPushDescriptorSetInfo*, void>)load(ptr, "vkCmdPushDescriptorSet2KHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkPushDescriptorSetWithTemplateInfo*, void>* pointer = &Vk.vkCmdPushDescriptorSetWithTemplate2KHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPushDescriptorSetWithTemplateInfo*, void>)load(ptr, "vkCmdPushDescriptorSetWithTemplate2KHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkSetDescriptorBufferOffsetsInfoEXT*, void>* pointer = &Vk.vkCmdSetDescriptorBufferOffsets2EXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkSetDescriptorBufferOffsetsInfoEXT*, void>)load(ptr, "vkCmdSetDescriptorBufferOffsets2EXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBindDescriptorBufferEmbeddedSamplersInfoEXT*, void>* pointer = &Vk.vkCmdBindDescriptorBufferEmbeddedSamplers2EXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBindDescriptorBufferEmbeddedSamplersInfoEXT*, void>)load(ptr, "vkCmdBindDescriptorBufferEmbeddedSamplers2EXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_DEBUG_REPORT_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkInstance, VkDebugReportCallbackCreateInfoEXT*, VkAllocationCallbacks*, VkDebugReportCallbackEXT*, VkResult>* pointer = &Vk.vkCreateDebugReportCallbackEXT)
                {
                    *pointer = (delegate* unmanaged<VkInstance, VkDebugReportCallbackCreateInfoEXT*, VkAllocationCallbacks*, VkDebugReportCallbackEXT*, VkResult>)load(ptr, "vkCreateDebugReportCallbackEXT");
                }
                fixed (delegate* unmanaged<VkInstance, VkDebugReportCallbackEXT, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyDebugReportCallbackEXT)
                {
                    *pointer = (delegate* unmanaged<VkInstance, VkDebugReportCallbackEXT, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyDebugReportCallbackEXT");
                }
                fixed (delegate* unmanaged<VkInstance, VkDebugReportFlagsEXT, VkDebugReportObjectTypeEXT, uint64_t, /* size_t, */ nuint , int32_t, ConstChar*, ConstChar*, void>* pointer = &Vk.vkDebugReportMessageEXT)
                {
                    *pointer = (delegate* unmanaged<VkInstance, VkDebugReportFlagsEXT, VkDebugReportObjectTypeEXT, uint64_t, /* size_t, */ nuint , int32_t, ConstChar*, ConstChar*, void>)load(ptr, "vkDebugReportMessageEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_DEBUG_MARKER_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkDebugMarkerObjectTagInfoEXT*, VkResult>* pointer = &Vk.vkDebugMarkerSetObjectTagEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDebugMarkerObjectTagInfoEXT*, VkResult>)load(ptr, "vkDebugMarkerSetObjectTagEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkDebugMarkerObjectNameInfoEXT*, VkResult>* pointer = &Vk.vkDebugMarkerSetObjectNameEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDebugMarkerObjectNameInfoEXT*, VkResult>)load(ptr, "vkDebugMarkerSetObjectNameEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkDebugMarkerMarkerInfoEXT*, void>* pointer = &Vk.vkCmdDebugMarkerBeginEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkDebugMarkerMarkerInfoEXT*, void>)load(ptr, "vkCmdDebugMarkerBeginEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, void>* pointer = &Vk.vkCmdDebugMarkerEndEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, void>)load(ptr, "vkCmdDebugMarkerEndEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkDebugMarkerMarkerInfoEXT*, void>* pointer = &Vk.vkCmdDebugMarkerInsertEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkDebugMarkerMarkerInfoEXT*, void>)load(ptr, "vkCmdDebugMarkerInsertEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_TRANSFORM_FEEDBACK_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBuffer*, VkDeviceSize*, VkDeviceSize*, void>* pointer = &Vk.vkCmdBindTransformFeedbackBuffersEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBuffer*, VkDeviceSize*, VkDeviceSize*, void>)load(ptr, "vkCmdBindTransformFeedbackBuffersEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBuffer*, VkDeviceSize*, void>* pointer = &Vk.vkCmdBeginTransformFeedbackEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBuffer*, VkDeviceSize*, void>)load(ptr, "vkCmdBeginTransformFeedbackEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBuffer*, VkDeviceSize*, void>* pointer = &Vk.vkCmdEndTransformFeedbackEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBuffer*, VkDeviceSize*, void>)load(ptr, "vkCmdEndTransformFeedbackEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkQueryPool, uint32_t, VkQueryControlFlags, uint32_t, void>* pointer = &Vk.vkCmdBeginQueryIndexedEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkQueryPool, uint32_t, VkQueryControlFlags, uint32_t, void>)load(ptr, "vkCmdBeginQueryIndexedEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkQueryPool, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdEndQueryIndexedEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkQueryPool, uint32_t, uint32_t, void>)load(ptr, "vkCmdEndQueryIndexedEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdDrawIndirectByteCountEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>)load(ptr, "vkCmdDrawIndirectByteCountEXT");
                }
            }
            if (extension.Contains(VK.VK_NVX_BINARY_IMPORT_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkCuModuleCreateInfoNVX*, VkAllocationCallbacks*, VkCuModuleNVX*, VkResult>* pointer = &Vk.vkCreateCuModuleNVX)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkCuModuleCreateInfoNVX*, VkAllocationCallbacks*, VkCuModuleNVX*, VkResult>)load(ptr, "vkCreateCuModuleNVX");
                }
                fixed (delegate* unmanaged<VkDevice, VkCuFunctionCreateInfoNVX*, VkAllocationCallbacks*, VkCuFunctionNVX*, VkResult>* pointer = &Vk.vkCreateCuFunctionNVX)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkCuFunctionCreateInfoNVX*, VkAllocationCallbacks*, VkCuFunctionNVX*, VkResult>)load(ptr, "vkCreateCuFunctionNVX");
                }
                fixed (delegate* unmanaged<VkDevice, VkCuModuleNVX, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyCuModuleNVX)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkCuModuleNVX, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyCuModuleNVX");
                }
                fixed (delegate* unmanaged<VkDevice, VkCuFunctionNVX, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyCuFunctionNVX)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkCuFunctionNVX, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyCuFunctionNVX");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkCuLaunchInfoNVX*, void>* pointer = &Vk.vkCmdCuLaunchKernelNVX)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkCuLaunchInfoNVX*, void>)load(ptr, "vkCmdCuLaunchKernelNVX");
                }
            }
            if (extension.Contains(VK.VK_NVX_IMAGE_VIEW_HANDLE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkImageViewHandleInfoNVX*, uint32_t>* pointer = &Vk.vkGetImageViewHandleNVX)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkImageViewHandleInfoNVX*, uint32_t>)load(ptr, "vkGetImageViewHandleNVX");
                }
                fixed (delegate* unmanaged<VkDevice, VkImageViewHandleInfoNVX*, uint64_t>* pointer = &Vk.vkGetImageViewHandle64NVX)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkImageViewHandleInfoNVX*, uint64_t>)load(ptr, "vkGetImageViewHandle64NVX");
                }
                fixed (delegate* unmanaged<VkDevice, VkImageView, VkImageViewAddressPropertiesNVX*, VkResult>* pointer = &Vk.vkGetImageViewAddressNVX)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkImageView, VkImageViewAddressPropertiesNVX*, VkResult>)load(ptr, "vkGetImageViewAddressNVX");
                }
            }
            if (extension.Contains(VK.VK_AMD_DRAW_INDIRECT_COUNT_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdDrawIndirectCountAMD)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>)load(ptr, "vkCmdDrawIndirectCountAMD");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdDrawIndexedIndirectCountAMD)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>)load(ptr, "vkCmdDrawIndexedIndirectCountAMD");
                }
            }
            if (extension.Contains(VK.VK_AMD_SHADER_INFO_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkPipeline, VkShaderStageFlagBits, VkShaderInfoTypeAMD, /* size_t* */ nuint , void*, VkResult>* pointer = &Vk.vkGetShaderInfoAMD)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPipeline, VkShaderStageFlagBits, VkShaderInfoTypeAMD, /* size_t* */ nuint , void*, VkResult>)load(ptr, "vkGetShaderInfoAMD");
                }
            }
            if (extension.Contains(VK.VK_EXT_CONDITIONAL_RENDERING_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkConditionalRenderingBeginInfoEXT*, void>* pointer = &Vk.vkCmdBeginConditionalRenderingEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkConditionalRenderingBeginInfoEXT*, void>)load(ptr, "vkCmdBeginConditionalRenderingEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, void>* pointer = &Vk.vkCmdEndConditionalRenderingEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, void>)load(ptr, "vkCmdEndConditionalRenderingEXT");
                }
            }
            if (extension.Contains(VK.VK_NV_CLIP_SPACE_W_SCALING_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkViewportWScalingNV*, void>* pointer = &Vk.vkCmdSetViewportWScalingNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkViewportWScalingNV*, void>)load(ptr, "vkCmdSetViewportWScalingNV");
                }
            }
            if (extension.Contains(VK.VK_EXT_DIRECT_MODE_DISPLAY_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, VkDisplayKHR, VkResult>* pointer = &Vk.vkReleaseDisplayEXT)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkDisplayKHR, VkResult>)load(ptr, "vkReleaseDisplayEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_DISPLAY_CONTROL_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkDisplayKHR, VkDisplayPowerInfoEXT*, VkResult>* pointer = &Vk.vkDisplayPowerControlEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDisplayKHR, VkDisplayPowerInfoEXT*, VkResult>)load(ptr, "vkDisplayPowerControlEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>* pointer = &Vk.vkRegisterDisplayEventEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)load(ptr, "vkRegisterDisplayEventEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkSurfaceCounterFlagBitsEXT, uint64_t*, VkResult>* pointer = &Vk.vkGetSwapchainCounterEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkSurfaceCounterFlagBitsEXT, uint64_t*, VkResult>)load(ptr, "vkGetSwapchainCounterEXT");
                }
            }
            if (extension.Contains(VK.VK_GOOGLE_DISPLAY_TIMING_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkRefreshCycleDurationGOOGLE*, VkResult>* pointer = &Vk.vkGetRefreshCycleDurationGOOGLE)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkRefreshCycleDurationGOOGLE*, VkResult>)load(ptr, "vkGetRefreshCycleDurationGOOGLE");
                }
                fixed (delegate* unmanaged<VkDevice, VkSwapchainKHR, uint32_t*, VkPastPresentationTimingGOOGLE*, VkResult>* pointer = &Vk.vkGetPastPresentationTimingGOOGLE)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSwapchainKHR, uint32_t*, VkPastPresentationTimingGOOGLE*, VkResult>)load(ptr, "vkGetPastPresentationTimingGOOGLE");
                }
            }
            if (extension.Contains(VK.VK_EXT_DISCARD_RECTANGLES_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkRect2D*, void>* pointer = &Vk.vkCmdSetDiscardRectangleEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkRect2D*, void>)load(ptr, "vkCmdSetDiscardRectangleEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetDiscardRectangleEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetDiscardRectangleEnableEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkDiscardRectangleModeEXT, void>* pointer = &Vk.vkCmdSetDiscardRectangleModeEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkDiscardRectangleModeEXT, void>)load(ptr, "vkCmdSetDiscardRectangleModeEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_HDR_METADATA_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, uint32_t, VkSwapchainKHR*, VkHdrMetadataEXT*, void>* pointer = &Vk.vkSetHdrMetadataEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, uint32_t, VkSwapchainKHR*, VkHdrMetadataEXT*, void>)load(ptr, "vkSetHdrMetadataEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_DEBUG_UTILS_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkDebugUtilsObjectNameInfoEXT*, VkResult>* pointer = &Vk.vkSetDebugUtilsObjectNameEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDebugUtilsObjectNameInfoEXT*, VkResult>)load(ptr, "vkSetDebugUtilsObjectNameEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkDebugUtilsObjectTagInfoEXT*, VkResult>* pointer = &Vk.vkSetDebugUtilsObjectTagEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDebugUtilsObjectTagInfoEXT*, VkResult>)load(ptr, "vkSetDebugUtilsObjectTagEXT");
                }
                fixed (delegate* unmanaged<VkQueue, VkDebugUtilsLabelEXT*, void>* pointer = &Vk.vkQueueBeginDebugUtilsLabelEXT)
                {
                    *pointer = (delegate* unmanaged<VkQueue, VkDebugUtilsLabelEXT*, void>)load(ptr, "vkQueueBeginDebugUtilsLabelEXT");
                }
                fixed (delegate* unmanaged<VkQueue, void>* pointer = &Vk.vkQueueEndDebugUtilsLabelEXT)
                {
                    *pointer = (delegate* unmanaged<VkQueue, void>)load(ptr, "vkQueueEndDebugUtilsLabelEXT");
                }
                fixed (delegate* unmanaged<VkQueue, VkDebugUtilsLabelEXT*, void>* pointer = &Vk.vkQueueInsertDebugUtilsLabelEXT)
                {
                    *pointer = (delegate* unmanaged<VkQueue, VkDebugUtilsLabelEXT*, void>)load(ptr, "vkQueueInsertDebugUtilsLabelEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkDebugUtilsLabelEXT*, void>* pointer = &Vk.vkCmdBeginDebugUtilsLabelEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkDebugUtilsLabelEXT*, void>)load(ptr, "vkCmdBeginDebugUtilsLabelEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, void>* pointer = &Vk.vkCmdEndDebugUtilsLabelEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, void>)load(ptr, "vkCmdEndDebugUtilsLabelEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkDebugUtilsLabelEXT*, void>* pointer = &Vk.vkCmdInsertDebugUtilsLabelEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkDebugUtilsLabelEXT*, void>)load(ptr, "vkCmdInsertDebugUtilsLabelEXT");
                }
                fixed (delegate* unmanaged<VkInstance, VkDebugUtilsMessengerCreateInfoEXT*, VkAllocationCallbacks*, VkDebugUtilsMessengerEXT*, VkResult>* pointer = &Vk.vkCreateDebugUtilsMessengerEXT)
                {
                    *pointer = (delegate* unmanaged<VkInstance, VkDebugUtilsMessengerCreateInfoEXT*, VkAllocationCallbacks*, VkDebugUtilsMessengerEXT*, VkResult>)load(ptr, "vkCreateDebugUtilsMessengerEXT");
                }
                fixed (delegate* unmanaged<VkInstance, VkDebugUtilsMessengerEXT, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyDebugUtilsMessengerEXT)
                {
                    *pointer = (delegate* unmanaged<VkInstance, VkDebugUtilsMessengerEXT, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyDebugUtilsMessengerEXT");
                }
                fixed (delegate* unmanaged<VkInstance, VkDebugUtilsMessageSeverityFlagBitsEXT, VkDebugUtilsMessageTypeFlagsEXT, VkDebugUtilsMessengerCallbackDataEXT*, void>* pointer = &Vk.vkSubmitDebugUtilsMessageEXT)
                {
                    *pointer = (delegate* unmanaged<VkInstance, VkDebugUtilsMessageSeverityFlagBitsEXT, VkDebugUtilsMessageTypeFlagsEXT, VkDebugUtilsMessengerCallbackDataEXT*, void>)load(ptr, "vkSubmitDebugUtilsMessageEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_SAMPLE_LOCATIONS_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkSampleLocationsInfoEXT*, void>* pointer = &Vk.vkCmdSetSampleLocationsEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkSampleLocationsInfoEXT*, void>)load(ptr, "vkCmdSetSampleLocationsEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_IMAGE_DRM_FORMAT_MODIFIER_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkImage, VkImageDrmFormatModifierPropertiesEXT*, VkResult>* pointer = &Vk.vkGetImageDrmFormatModifierPropertiesEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkImage, VkImageDrmFormatModifierPropertiesEXT*, VkResult>)load(ptr, "vkGetImageDrmFormatModifierPropertiesEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_VALIDATION_CACHE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkValidationCacheCreateInfoEXT*, VkAllocationCallbacks*, VkValidationCacheEXT*, VkResult>* pointer = &Vk.vkCreateValidationCacheEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkValidationCacheCreateInfoEXT*, VkAllocationCallbacks*, VkValidationCacheEXT*, VkResult>)load(ptr, "vkCreateValidationCacheEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkValidationCacheEXT, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyValidationCacheEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkValidationCacheEXT, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyValidationCacheEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkValidationCacheEXT, uint32_t, VkValidationCacheEXT*, VkResult>* pointer = &Vk.vkMergeValidationCachesEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkValidationCacheEXT, uint32_t, VkValidationCacheEXT*, VkResult>)load(ptr, "vkMergeValidationCachesEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkValidationCacheEXT, /* size_t* */ nuint , void*, VkResult>* pointer = &Vk.vkGetValidationCacheDataEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkValidationCacheEXT, /* size_t* */ nuint , void*, VkResult>)load(ptr, "vkGetValidationCacheDataEXT");
                }
            }
            if (extension.Contains(VK.VK_NV_SHADING_RATE_IMAGE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkImageView, VkImageLayout, void>* pointer = &Vk.vkCmdBindShadingRateImageNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkImageView, VkImageLayout, void>)load(ptr, "vkCmdBindShadingRateImageNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkShadingRatePaletteNV*, void>* pointer = &Vk.vkCmdSetViewportShadingRatePaletteNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkShadingRatePaletteNV*, void>)load(ptr, "vkCmdSetViewportShadingRatePaletteNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkCoarseSampleOrderTypeNV, uint32_t, VkCoarseSampleOrderCustomNV*, void>* pointer = &Vk.vkCmdSetCoarseSampleOrderNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkCoarseSampleOrderTypeNV, uint32_t, VkCoarseSampleOrderCustomNV*, void>)load(ptr, "vkCmdSetCoarseSampleOrderNV");
                }
            }
            if (extension.Contains(VK.VK_NV_RAY_TRACING_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkAccelerationStructureCreateInfoNV*, VkAllocationCallbacks*, VkAccelerationStructureNV*, VkResult>* pointer = &Vk.vkCreateAccelerationStructureNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkAccelerationStructureCreateInfoNV*, VkAllocationCallbacks*, VkAccelerationStructureNV*, VkResult>)load(ptr, "vkCreateAccelerationStructureNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkAccelerationStructureNV, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyAccelerationStructureNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkAccelerationStructureNV, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyAccelerationStructureNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkAccelerationStructureMemoryRequirementsInfoNV*, VkMemoryRequirements2KHR*, void>* pointer = &Vk.vkGetAccelerationStructureMemoryRequirementsNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkAccelerationStructureMemoryRequirementsInfoNV*, VkMemoryRequirements2KHR*, void>)load(ptr, "vkGetAccelerationStructureMemoryRequirementsNV");
                }
                fixed (delegate* unmanaged<VkDevice, uint32_t, VkBindAccelerationStructureMemoryInfoNV*, VkResult>* pointer = &Vk.vkBindAccelerationStructureMemoryNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, uint32_t, VkBindAccelerationStructureMemoryInfoNV*, VkResult>)load(ptr, "vkBindAccelerationStructureMemoryNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkAccelerationStructureInfoNV*, VkBuffer, VkDeviceSize, VkBool32, VkAccelerationStructureNV, VkAccelerationStructureNV, VkBuffer, VkDeviceSize, void>* pointer = &Vk.vkCmdBuildAccelerationStructureNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkAccelerationStructureInfoNV*, VkBuffer, VkDeviceSize, VkBool32, VkAccelerationStructureNV, VkAccelerationStructureNV, VkBuffer, VkDeviceSize, void>)load(ptr, "vkCmdBuildAccelerationStructureNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkAccelerationStructureNV, VkAccelerationStructureNV, VkCopyAccelerationStructureModeKHR, void>* pointer = &Vk.vkCmdCopyAccelerationStructureNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkAccelerationStructureNV, VkAccelerationStructureNV, VkCopyAccelerationStructureModeKHR, void>)load(ptr, "vkCmdCopyAccelerationStructureNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, VkDeviceSize, VkBuffer, VkDeviceSize, VkDeviceSize, VkBuffer, VkDeviceSize, VkDeviceSize, uint32_t, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdTraceRaysNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, VkDeviceSize, VkBuffer, VkDeviceSize, VkDeviceSize, VkBuffer, VkDeviceSize, VkDeviceSize, uint32_t, uint32_t, uint32_t, void>)load(ptr, "vkCmdTraceRaysNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkPipelineCache, uint32_t, VkRayTracingPipelineCreateInfoNV*, VkAllocationCallbacks*, VkPipeline*, VkResult>* pointer = &Vk.vkCreateRayTracingPipelinesNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPipelineCache, uint32_t, VkRayTracingPipelineCreateInfoNV*, VkAllocationCallbacks*, VkPipeline*, VkResult>)load(ptr, "vkCreateRayTracingPipelinesNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkPipeline, uint32_t, uint32_t, /* size_t, */ nuint , void*, VkResult>* pointer = &Vk.vkGetRayTracingShaderGroupHandlesKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPipeline, uint32_t, uint32_t, /* size_t, */ nuint , void*, VkResult>)load(ptr, "vkGetRayTracingShaderGroupHandlesKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkPipeline, uint32_t, uint32_t, /* size_t, */ nuint , void*, VkResult>* pointer = &Vk.vkGetRayTracingShaderGroupHandlesNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPipeline, uint32_t, uint32_t, /* size_t, */ nuint , void*, VkResult>)load(ptr, "vkGetRayTracingShaderGroupHandlesNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkAccelerationStructureNV, /* size_t, */ nuint , void*, VkResult>* pointer = &Vk.vkGetAccelerationStructureHandleNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkAccelerationStructureNV, /* size_t, */ nuint , void*, VkResult>)load(ptr, "vkGetAccelerationStructureHandleNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkAccelerationStructureNV*, VkQueryType, VkQueryPool, uint32_t, void>* pointer = &Vk.vkCmdWriteAccelerationStructuresPropertiesNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkAccelerationStructureNV*, VkQueryType, VkQueryPool, uint32_t, void>)load(ptr, "vkCmdWriteAccelerationStructuresPropertiesNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkPipeline, uint32_t, VkResult>* pointer = &Vk.vkCompileDeferredNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPipeline, uint32_t, VkResult>)load(ptr, "vkCompileDeferredNV");
                }
            }
            if (extension.Contains(VK.VK_EXT_EXTERNAL_MEMORY_HOST_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkExternalMemoryHandleTypeFlagBits, void*, VkMemoryHostPointerPropertiesEXT*, VkResult>* pointer = &Vk.vkGetMemoryHostPointerPropertiesEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkExternalMemoryHandleTypeFlagBits, void*, VkMemoryHostPointerPropertiesEXT*, VkResult>)load(ptr, "vkGetMemoryHostPointerPropertiesEXT");
                }
            }
            if (extension.Contains(VK.VK_AMD_BUFFER_MARKER_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkPipelineStageFlagBits, VkBuffer, VkDeviceSize, uint32_t, void>* pointer = &Vk.vkCmdWriteBufferMarkerAMD)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPipelineStageFlagBits, VkBuffer, VkDeviceSize, uint32_t, void>)load(ptr, "vkCmdWriteBufferMarkerAMD");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkPipelineStageFlags2, VkBuffer, VkDeviceSize, uint32_t, void>* pointer = &Vk.vkCmdWriteBufferMarker2AMD)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPipelineStageFlags2, VkBuffer, VkDeviceSize, uint32_t, void>)load(ptr, "vkCmdWriteBufferMarker2AMD");
                }
            }
            if (extension.Contains(VK.VK_EXT_CALIBRATED_TIMESTAMPS_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, uint32_t, VkCalibratedTimestampInfoKHR*, uint64_t*, uint64_t*, VkResult>* pointer = &Vk.vkGetCalibratedTimestampsEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, uint32_t, VkCalibratedTimestampInfoKHR*, uint64_t*, uint64_t*, VkResult>)load(ptr, "vkGetCalibratedTimestampsEXT");
                }
            }
            if (extension.Contains(VK.VK_NV_MESH_SHADER_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdDrawMeshTasksNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, void>)load(ptr, "vkCmdDrawMeshTasksNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdDrawMeshTasksIndirectNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>)load(ptr, "vkCmdDrawMeshTasksIndirectNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdDrawMeshTasksIndirectCountNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>)load(ptr, "vkCmdDrawMeshTasksIndirectCountNV");
                }
            }
            if (extension.Contains(VK.VK_NV_SCISSOR_EXCLUSIVE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBool32*, void>* pointer = &Vk.vkCmdSetExclusiveScissorEnableNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBool32*, void>)load(ptr, "vkCmdSetExclusiveScissorEnableNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkRect2D*, void>* pointer = &Vk.vkCmdSetExclusiveScissorNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkRect2D*, void>)load(ptr, "vkCmdSetExclusiveScissorNV");
                }
            }
            if (extension.Contains(VK.VK_NV_DEVICE_DIAGNOSTIC_CHECKPOINTS_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, void*, void>* pointer = &Vk.vkCmdSetCheckpointNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, void*, void>)load(ptr, "vkCmdSetCheckpointNV");
                }
                fixed (delegate* unmanaged<VkQueue, uint32_t*, VkCheckpointDataNV*, void>* pointer = &Vk.vkGetQueueCheckpointDataNV)
                {
                    *pointer = (delegate* unmanaged<VkQueue, uint32_t*, VkCheckpointDataNV*, void>)load(ptr, "vkGetQueueCheckpointDataNV");
                }
                fixed (delegate* unmanaged<VkQueue, uint32_t*, VkCheckpointData2NV*, void>* pointer = &Vk.vkGetQueueCheckpointData2NV)
                {
                    *pointer = (delegate* unmanaged<VkQueue, uint32_t*, VkCheckpointData2NV*, void>)load(ptr, "vkGetQueueCheckpointData2NV");
                }
            }
            if (extension.Contains(VK.VK_INTEL_PERFORMANCE_QUERY_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkInitializePerformanceApiInfoINTEL*, VkResult>* pointer = &Vk.vkInitializePerformanceApiINTEL)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkInitializePerformanceApiInfoINTEL*, VkResult>)load(ptr, "vkInitializePerformanceApiINTEL");
                }
                fixed (delegate* unmanaged<VkDevice, void>* pointer = &Vk.vkUninitializePerformanceApiINTEL)
                {
                    *pointer = (delegate* unmanaged<VkDevice, void>)load(ptr, "vkUninitializePerformanceApiINTEL");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkPerformanceMarkerInfoINTEL*, VkResult>* pointer = &Vk.vkCmdSetPerformanceMarkerINTEL)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPerformanceMarkerInfoINTEL*, VkResult>)load(ptr, "vkCmdSetPerformanceMarkerINTEL");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkPerformanceStreamMarkerInfoINTEL*, VkResult>* pointer = &Vk.vkCmdSetPerformanceStreamMarkerINTEL)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPerformanceStreamMarkerInfoINTEL*, VkResult>)load(ptr, "vkCmdSetPerformanceStreamMarkerINTEL");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkPerformanceOverrideInfoINTEL*, VkResult>* pointer = &Vk.vkCmdSetPerformanceOverrideINTEL)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPerformanceOverrideInfoINTEL*, VkResult>)load(ptr, "vkCmdSetPerformanceOverrideINTEL");
                }
                fixed (delegate* unmanaged<VkDevice, VkPerformanceConfigurationAcquireInfoINTEL*, VkPerformanceConfigurationINTEL*, VkResult>* pointer = &Vk.vkAcquirePerformanceConfigurationINTEL)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPerformanceConfigurationAcquireInfoINTEL*, VkPerformanceConfigurationINTEL*, VkResult>)load(ptr, "vkAcquirePerformanceConfigurationINTEL");
                }
                fixed (delegate* unmanaged<VkDevice, VkPerformanceConfigurationINTEL, VkResult>* pointer = &Vk.vkReleasePerformanceConfigurationINTEL)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPerformanceConfigurationINTEL, VkResult>)load(ptr, "vkReleasePerformanceConfigurationINTEL");
                }
                fixed (delegate* unmanaged<VkQueue, VkPerformanceConfigurationINTEL, VkResult>* pointer = &Vk.vkQueueSetPerformanceConfigurationINTEL)
                {
                    *pointer = (delegate* unmanaged<VkQueue, VkPerformanceConfigurationINTEL, VkResult>)load(ptr, "vkQueueSetPerformanceConfigurationINTEL");
                }
                fixed (delegate* unmanaged<VkDevice, VkPerformanceParameterTypeINTEL, VkPerformanceValueINTEL*, VkResult>* pointer = &Vk.vkGetPerformanceParameterINTEL)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPerformanceParameterTypeINTEL, VkPerformanceValueINTEL*, VkResult>)load(ptr, "vkGetPerformanceParameterINTEL");
                }
            }
            if (extension.Contains(VK.VK_AMD_DISPLAY_NATIVE_HDR_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkBool32, void>* pointer = &Vk.vkSetLocalDimmingAMD)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkBool32, void>)load(ptr, "vkSetLocalDimmingAMD");
                }
            }
            if (extension.Contains(VK.VK_EXT_HEADLESS_SURFACE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkInstance, VkHeadlessSurfaceCreateInfoEXT*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>* pointer = &Vk.vkCreateHeadlessSurfaceEXT)
                {
                    *pointer = (delegate* unmanaged<VkInstance, VkHeadlessSurfaceCreateInfoEXT*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult>)load(ptr, "vkCreateHeadlessSurfaceEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_LINE_RASTERIZATION_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint16_t, void>* pointer = &Vk.vkCmdSetLineStippleEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint16_t, void>)load(ptr, "vkCmdSetLineStippleEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_HOST_QUERY_RESET_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkQueryPool, uint32_t, uint32_t, void>* pointer = &Vk.vkResetQueryPoolEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkQueryPool, uint32_t, uint32_t, void>)load(ptr, "vkResetQueryPoolEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_EXTENDED_DYNAMIC_STATE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkCullModeFlags, void>* pointer = &Vk.vkCmdSetCullModeEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkCullModeFlags, void>)load(ptr, "vkCmdSetCullModeEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkFrontFace, void>* pointer = &Vk.vkCmdSetFrontFaceEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkFrontFace, void>)load(ptr, "vkCmdSetFrontFaceEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkPrimitiveTopology, void>* pointer = &Vk.vkCmdSetPrimitiveTopologyEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPrimitiveTopology, void>)load(ptr, "vkCmdSetPrimitiveTopologyEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkViewport*, void>* pointer = &Vk.vkCmdSetViewportWithCountEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkViewport*, void>)load(ptr, "vkCmdSetViewportWithCountEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkRect2D*, void>* pointer = &Vk.vkCmdSetScissorWithCountEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkRect2D*, void>)load(ptr, "vkCmdSetScissorWithCountEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBuffer*, VkDeviceSize*, VkDeviceSize*, VkDeviceSize*, void>* pointer = &Vk.vkCmdBindVertexBuffers2EXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBuffer*, VkDeviceSize*, VkDeviceSize*, VkDeviceSize*, void>)load(ptr, "vkCmdBindVertexBuffers2EXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetDepthTestEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetDepthTestEnableEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetDepthWriteEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetDepthWriteEnableEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkCompareOp, void>* pointer = &Vk.vkCmdSetDepthCompareOpEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkCompareOp, void>)load(ptr, "vkCmdSetDepthCompareOpEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetDepthBoundsTestEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetDepthBoundsTestEnableEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetStencilTestEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetStencilTestEnableEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkStencilFaceFlags, VkStencilOp, VkStencilOp, VkStencilOp, VkCompareOp, void>* pointer = &Vk.vkCmdSetStencilOpEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkStencilFaceFlags, VkStencilOp, VkStencilOp, VkStencilOp, VkCompareOp, void>)load(ptr, "vkCmdSetStencilOpEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_HOST_IMAGE_COPY_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkCopyMemoryToImageInfo*, VkResult>* pointer = &Vk.vkCopyMemoryToImageEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkCopyMemoryToImageInfo*, VkResult>)load(ptr, "vkCopyMemoryToImageEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkCopyImageToMemoryInfo*, VkResult>* pointer = &Vk.vkCopyImageToMemoryEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkCopyImageToMemoryInfo*, VkResult>)load(ptr, "vkCopyImageToMemoryEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkCopyImageToImageInfo*, VkResult>* pointer = &Vk.vkCopyImageToImageEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkCopyImageToImageInfo*, VkResult>)load(ptr, "vkCopyImageToImageEXT");
                }
                fixed (delegate* unmanaged<VkDevice, uint32_t, VkHostImageLayoutTransitionInfo*, VkResult>* pointer = &Vk.vkTransitionImageLayoutEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, uint32_t, VkHostImageLayoutTransitionInfo*, VkResult>)load(ptr, "vkTransitionImageLayoutEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkImage, VkImageSubresource2*, VkSubresourceLayout2*, void>* pointer = &Vk.vkGetImageSubresourceLayout2EXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkImage, VkImageSubresource2*, VkSubresourceLayout2*, void>)load(ptr, "vkGetImageSubresourceLayout2EXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_SWAPCHAIN_MAINTENANCE_1_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkReleaseSwapchainImagesInfoEXT*, VkResult>* pointer = &Vk.vkReleaseSwapchainImagesEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkReleaseSwapchainImagesInfoEXT*, VkResult>)load(ptr, "vkReleaseSwapchainImagesEXT");
                }
            }
            if (extension.Contains(VK.VK_NV_DEVICE_GENERATED_COMMANDS_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkGeneratedCommandsMemoryRequirementsInfoNV*, VkMemoryRequirements2*, void>* pointer = &Vk.vkGetGeneratedCommandsMemoryRequirementsNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkGeneratedCommandsMemoryRequirementsInfoNV*, VkMemoryRequirements2*, void>)load(ptr, "vkGetGeneratedCommandsMemoryRequirementsNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkGeneratedCommandsInfoNV*, void>* pointer = &Vk.vkCmdPreprocessGeneratedCommandsNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkGeneratedCommandsInfoNV*, void>)load(ptr, "vkCmdPreprocessGeneratedCommandsNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, VkGeneratedCommandsInfoNV*, void>* pointer = &Vk.vkCmdExecuteGeneratedCommandsNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, VkGeneratedCommandsInfoNV*, void>)load(ptr, "vkCmdExecuteGeneratedCommandsNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkPipelineBindPoint, VkPipeline, uint32_t, void>* pointer = &Vk.vkCmdBindPipelineShaderGroupNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPipelineBindPoint, VkPipeline, uint32_t, void>)load(ptr, "vkCmdBindPipelineShaderGroupNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkIndirectCommandsLayoutCreateInfoNV*, VkAllocationCallbacks*, VkIndirectCommandsLayoutNV*, VkResult>* pointer = &Vk.vkCreateIndirectCommandsLayoutNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkIndirectCommandsLayoutCreateInfoNV*, VkAllocationCallbacks*, VkIndirectCommandsLayoutNV*, VkResult>)load(ptr, "vkCreateIndirectCommandsLayoutNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkIndirectCommandsLayoutNV, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyIndirectCommandsLayoutNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkIndirectCommandsLayoutNV, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyIndirectCommandsLayoutNV");
                }
            }
            if (extension.Contains(VK.VK_EXT_DEPTH_BIAS_CONTROL_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkDepthBiasInfoEXT*, void>* pointer = &Vk.vkCmdSetDepthBias2EXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkDepthBiasInfoEXT*, void>)load(ptr, "vkCmdSetDepthBias2EXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_ACQUIRE_DRM_DISPLAY_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, int32_t, VkDisplayKHR, VkResult>* pointer = &Vk.vkAcquireDrmDisplayEXT)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, int32_t, VkDisplayKHR, VkResult>)load(ptr, "vkAcquireDrmDisplayEXT");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, int32_t, uint32_t, VkDisplayKHR*, VkResult>* pointer = &Vk.vkGetDrmDisplayEXT)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, int32_t, uint32_t, VkDisplayKHR*, VkResult>)load(ptr, "vkGetDrmDisplayEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_PRIVATE_DATA_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkPrivateDataSlotCreateInfo*, VkAllocationCallbacks*, VkPrivateDataSlot*, VkResult>* pointer = &Vk.vkCreatePrivateDataSlotEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPrivateDataSlotCreateInfo*, VkAllocationCallbacks*, VkPrivateDataSlot*, VkResult>)load(ptr, "vkCreatePrivateDataSlotEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkPrivateDataSlot, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyPrivateDataSlotEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPrivateDataSlot, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyPrivateDataSlotEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkObjectType, uint64_t, VkPrivateDataSlot, uint64_t, VkResult>* pointer = &Vk.vkSetPrivateDataEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkObjectType, uint64_t, VkPrivateDataSlot, uint64_t, VkResult>)load(ptr, "vkSetPrivateDataEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkObjectType, uint64_t, VkPrivateDataSlot, uint64_t*, void>* pointer = &Vk.vkGetPrivateDataEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkObjectType, uint64_t, VkPrivateDataSlot, uint64_t*, void>)load(ptr, "vkGetPrivateDataEXT");
                }
            }
            if (extension.Contains(VK.VK_NV_CUDA_KERNEL_LAUNCH_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkCudaModuleCreateInfoNV*, VkAllocationCallbacks*, VkCudaModuleNV*, VkResult>* pointer = &Vk.vkCreateCudaModuleNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkCudaModuleCreateInfoNV*, VkAllocationCallbacks*, VkCudaModuleNV*, VkResult>)load(ptr, "vkCreateCudaModuleNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkCudaModuleNV, /* size_t* */ nuint , void*, VkResult>* pointer = &Vk.vkGetCudaModuleCacheNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkCudaModuleNV, /* size_t* */ nuint , void*, VkResult>)load(ptr, "vkGetCudaModuleCacheNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkCudaFunctionCreateInfoNV*, VkAllocationCallbacks*, VkCudaFunctionNV*, VkResult>* pointer = &Vk.vkCreateCudaFunctionNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkCudaFunctionCreateInfoNV*, VkAllocationCallbacks*, VkCudaFunctionNV*, VkResult>)load(ptr, "vkCreateCudaFunctionNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkCudaModuleNV, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyCudaModuleNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkCudaModuleNV, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyCudaModuleNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkCudaFunctionNV, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyCudaFunctionNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkCudaFunctionNV, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyCudaFunctionNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkCudaLaunchInfoNV*, void>* pointer = &Vk.vkCmdCudaLaunchKernelNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkCudaLaunchInfoNV*, void>)load(ptr, "vkCmdCudaLaunchKernelNV");
                }
            }
            if (extension.Contains(VK.VK_QCOM_TILE_SHADING_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, void>* pointer = &Vk.vkCmdDispatchTileQCOM)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, void>)load(ptr, "vkCmdDispatchTileQCOM");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkPerTileBeginInfoQCOM*, void>* pointer = &Vk.vkCmdBeginPerTileExecutionQCOM)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPerTileBeginInfoQCOM*, void>)load(ptr, "vkCmdBeginPerTileExecutionQCOM");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkPerTileEndInfoQCOM*, void>* pointer = &Vk.vkCmdEndPerTileExecutionQCOM)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPerTileEndInfoQCOM*, void>)load(ptr, "vkCmdEndPerTileExecutionQCOM");
                }
            }
            if (extension.Contains(VK.VK_EXT_DESCRIPTOR_BUFFER_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkDescriptorSetLayout, VkDeviceSize*, void>* pointer = &Vk.vkGetDescriptorSetLayoutSizeEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDescriptorSetLayout, VkDeviceSize*, void>)load(ptr, "vkGetDescriptorSetLayoutSizeEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkDescriptorSetLayout, uint32_t, VkDeviceSize*, void>* pointer = &Vk.vkGetDescriptorSetLayoutBindingOffsetEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDescriptorSetLayout, uint32_t, VkDeviceSize*, void>)load(ptr, "vkGetDescriptorSetLayoutBindingOffsetEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkDescriptorGetInfoEXT*, /* size_t, */ nuint , void*, void>* pointer = &Vk.vkGetDescriptorEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDescriptorGetInfoEXT*, /* size_t, */ nuint , void*, void>)load(ptr, "vkGetDescriptorEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkDescriptorBufferBindingInfoEXT*, void>* pointer = &Vk.vkCmdBindDescriptorBuffersEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkDescriptorBufferBindingInfoEXT*, void>)load(ptr, "vkCmdBindDescriptorBuffersEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint32_t, uint32_t, uint32_t*, VkDeviceSize*, void>* pointer = &Vk.vkCmdSetDescriptorBufferOffsetsEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint32_t, uint32_t, uint32_t*, VkDeviceSize*, void>)load(ptr, "vkCmdSetDescriptorBufferOffsetsEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint32_t, void>* pointer = &Vk.vkCmdBindDescriptorBufferEmbeddedSamplersEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint32_t, void>)load(ptr, "vkCmdBindDescriptorBufferEmbeddedSamplersEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkBufferCaptureDescriptorDataInfoEXT*, void*, VkResult>* pointer = &Vk.vkGetBufferOpaqueCaptureDescriptorDataEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkBufferCaptureDescriptorDataInfoEXT*, void*, VkResult>)load(ptr, "vkGetBufferOpaqueCaptureDescriptorDataEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkImageCaptureDescriptorDataInfoEXT*, void*, VkResult>* pointer = &Vk.vkGetImageOpaqueCaptureDescriptorDataEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkImageCaptureDescriptorDataInfoEXT*, void*, VkResult>)load(ptr, "vkGetImageOpaqueCaptureDescriptorDataEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkImageViewCaptureDescriptorDataInfoEXT*, void*, VkResult>* pointer = &Vk.vkGetImageViewOpaqueCaptureDescriptorDataEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkImageViewCaptureDescriptorDataInfoEXT*, void*, VkResult>)load(ptr, "vkGetImageViewOpaqueCaptureDescriptorDataEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkSamplerCaptureDescriptorDataInfoEXT*, void*, VkResult>* pointer = &Vk.vkGetSamplerOpaqueCaptureDescriptorDataEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSamplerCaptureDescriptorDataInfoEXT*, void*, VkResult>)load(ptr, "vkGetSamplerOpaqueCaptureDescriptorDataEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkAccelerationStructureCaptureDescriptorDataInfoEXT*, void*, VkResult>* pointer = &Vk.vkGetAccelerationStructureOpaqueCaptureDescriptorDataEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkAccelerationStructureCaptureDescriptorDataInfoEXT*, void*, VkResult>)load(ptr, "vkGetAccelerationStructureOpaqueCaptureDescriptorDataEXT");
                }
            }
            if (extension.Contains(VK.VK_NV_FRAGMENT_SHADING_RATE_ENUMS_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkFragmentShadingRateNV, VkFragmentShadingRateCombinerOpKHR, void>* pointer = &Vk.vkCmdSetFragmentShadingRateEnumNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkFragmentShadingRateNV, VkFragmentShadingRateCombinerOpKHR, void>)load(ptr, "vkCmdSetFragmentShadingRateEnumNV");
                }
            }
            if (extension.Contains(VK.VK_EXT_VERTEX_INPUT_DYNAMIC_STATE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkVertexInputBindingDescription2EXT*, uint32_t, VkVertexInputAttributeDescription2EXT*, void>* pointer = &Vk.vkCmdSetVertexInputEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkVertexInputBindingDescription2EXT*, uint32_t, VkVertexInputAttributeDescription2EXT*, void>)load(ptr, "vkCmdSetVertexInputEXT");
                }
            }
            if (extension.Contains(VK.VK_HUAWEI_SUBPASS_SHADING_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, void>* pointer = &Vk.vkCmdSubpassShadingHUAWEI)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, void>)load(ptr, "vkCmdSubpassShadingHUAWEI");
                }
            }
            if (extension.Contains(VK.VK_HUAWEI_INVOCATION_MASK_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkImageView, VkImageLayout, void>* pointer = &Vk.vkCmdBindInvocationMaskHUAWEI)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkImageView, VkImageLayout, void>)load(ptr, "vkCmdBindInvocationMaskHUAWEI");
                }
            }
            if (extension.Contains(VK.VK_NV_EXTERNAL_MEMORY_RDMA_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkMemoryGetRemoteAddressInfoNV*, VkRemoteAddressNV*, VkResult>* pointer = &Vk.vkGetMemoryRemoteAddressNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkMemoryGetRemoteAddressInfoNV*, VkRemoteAddressNV*, VkResult>)load(ptr, "vkGetMemoryRemoteAddressNV");
                }
            }
            if (extension.Contains(VK.VK_EXT_PIPELINE_PROPERTIES_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkPipelineInfoEXT*, VkBaseOutStructure*, VkResult>* pointer = &Vk.vkGetPipelinePropertiesEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPipelineInfoEXT*, VkBaseOutStructure*, VkResult>)load(ptr, "vkGetPipelinePropertiesEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_EXTENDED_DYNAMIC_STATE_2_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, void>* pointer = &Vk.vkCmdSetPatchControlPointsEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, void>)load(ptr, "vkCmdSetPatchControlPointsEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetRasterizerDiscardEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetRasterizerDiscardEnableEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetDepthBiasEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetDepthBiasEnableEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkLogicOp, void>* pointer = &Vk.vkCmdSetLogicOpEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkLogicOp, void>)load(ptr, "vkCmdSetLogicOpEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetPrimitiveRestartEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetPrimitiveRestartEnableEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_COLOR_WRITE_ENABLE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkBool32*, void>* pointer = &Vk.vkCmdSetColorWriteEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkBool32*, void>)load(ptr, "vkCmdSetColorWriteEnableEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_MULTI_DRAW_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkMultiDrawInfoEXT*, uint32_t, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdDrawMultiEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkMultiDrawInfoEXT*, uint32_t, uint32_t, uint32_t, void>)load(ptr, "vkCmdDrawMultiEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkMultiDrawIndexedInfoEXT*, uint32_t, uint32_t, uint32_t, int32_t*, void>* pointer = &Vk.vkCmdDrawMultiIndexedEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkMultiDrawIndexedInfoEXT*, uint32_t, uint32_t, uint32_t, int32_t*, void>)load(ptr, "vkCmdDrawMultiIndexedEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_OPACITY_MICROMAP_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkMicromapCreateInfoEXT*, VkAllocationCallbacks*, VkMicromapEXT*, VkResult>* pointer = &Vk.vkCreateMicromapEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkMicromapCreateInfoEXT*, VkAllocationCallbacks*, VkMicromapEXT*, VkResult>)load(ptr, "vkCreateMicromapEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkMicromapEXT, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyMicromapEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkMicromapEXT, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyMicromapEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkMicromapBuildInfoEXT*, void>* pointer = &Vk.vkCmdBuildMicromapsEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkMicromapBuildInfoEXT*, void>)load(ptr, "vkCmdBuildMicromapsEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, uint32_t, VkMicromapBuildInfoEXT*, VkResult>* pointer = &Vk.vkBuildMicromapsEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, uint32_t, VkMicromapBuildInfoEXT*, VkResult>)load(ptr, "vkBuildMicromapsEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyMicromapInfoEXT*, VkResult>* pointer = &Vk.vkCopyMicromapEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyMicromapInfoEXT*, VkResult>)load(ptr, "vkCopyMicromapEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyMicromapToMemoryInfoEXT*, VkResult>* pointer = &Vk.vkCopyMicromapToMemoryEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyMicromapToMemoryInfoEXT*, VkResult>)load(ptr, "vkCopyMicromapToMemoryEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyMemoryToMicromapInfoEXT*, VkResult>* pointer = &Vk.vkCopyMemoryToMicromapEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyMemoryToMicromapInfoEXT*, VkResult>)load(ptr, "vkCopyMemoryToMicromapEXT");
                }
                fixed (delegate* unmanaged<VkDevice, uint32_t, VkMicromapEXT*, VkQueryType, /* size_t, */ nuint , void*, /* size_t, */ nuint , VkResult>* pointer = &Vk.vkWriteMicromapsPropertiesEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, uint32_t, VkMicromapEXT*, VkQueryType, /* size_t, */ nuint , void*, /* size_t, */ nuint , VkResult>)load(ptr, "vkWriteMicromapsPropertiesEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkCopyMicromapInfoEXT*, void>* pointer = &Vk.vkCmdCopyMicromapEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkCopyMicromapInfoEXT*, void>)load(ptr, "vkCmdCopyMicromapEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkCopyMicromapToMemoryInfoEXT*, void>* pointer = &Vk.vkCmdCopyMicromapToMemoryEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkCopyMicromapToMemoryInfoEXT*, void>)load(ptr, "vkCmdCopyMicromapToMemoryEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkCopyMemoryToMicromapInfoEXT*, void>* pointer = &Vk.vkCmdCopyMemoryToMicromapEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkCopyMemoryToMicromapInfoEXT*, void>)load(ptr, "vkCmdCopyMemoryToMicromapEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkMicromapEXT*, VkQueryType, VkQueryPool, uint32_t, void>* pointer = &Vk.vkCmdWriteMicromapsPropertiesEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkMicromapEXT*, VkQueryType, VkQueryPool, uint32_t, void>)load(ptr, "vkCmdWriteMicromapsPropertiesEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkAccelerationStructureBuildTypeKHR, VkMicromapBuildInfoEXT*, VkMicromapBuildSizesInfoEXT*, void>* pointer = &Vk.vkGetMicromapBuildSizesEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkAccelerationStructureBuildTypeKHR, VkMicromapBuildInfoEXT*, VkMicromapBuildSizesInfoEXT*, void>)load(ptr, "vkGetMicromapBuildSizesEXT");
                }
            }
            if (extension.Contains(VK.VK_HUAWEI_CLUSTER_CULLING_SHADER_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdDrawClusterHUAWEI)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, uint32_t, void>)load(ptr, "vkCmdDrawClusterHUAWEI");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, void>* pointer = &Vk.vkCmdDrawClusterIndirectHUAWEI)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, void>)load(ptr, "vkCmdDrawClusterIndirectHUAWEI");
                }
            }
            if (extension.Contains(VK.VK_VALVE_DESCRIPTOR_SET_HOST_MAPPING_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkDescriptorSetBindingReferenceVALVE*, VkDescriptorSetLayoutHostMappingInfoVALVE*, void>* pointer = &Vk.vkGetDescriptorSetLayoutHostMappingInfoVALVE)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDescriptorSetBindingReferenceVALVE*, VkDescriptorSetLayoutHostMappingInfoVALVE*, void>)load(ptr, "vkGetDescriptorSetLayoutHostMappingInfoVALVE");
                }
                fixed (delegate* unmanaged<VkDevice, VkDescriptorSet, void**, void>* pointer = &Vk.vkGetDescriptorSetHostMappingVALVE)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDescriptorSet, void**, void>)load(ptr, "vkGetDescriptorSetHostMappingVALVE");
                }
            }
            if (extension.Contains(VK.VK_NV_COPY_MEMORY_INDIRECT_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkDeviceAddress, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdCopyMemoryIndirectNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkDeviceAddress, uint32_t, uint32_t, void>)load(ptr, "vkCmdCopyMemoryIndirectNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkDeviceAddress, uint32_t, uint32_t, VkImage, VkImageLayout, VkImageSubresourceLayers*, void>* pointer = &Vk.vkCmdCopyMemoryToImageIndirectNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkDeviceAddress, uint32_t, uint32_t, VkImage, VkImageLayout, VkImageSubresourceLayers*, void>)load(ptr, "vkCmdCopyMemoryToImageIndirectNV");
                }
            }
            if (extension.Contains(VK.VK_NV_MEMORY_DECOMPRESSION_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkDecompressMemoryRegionNV*, void>* pointer = &Vk.vkCmdDecompressMemoryNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkDecompressMemoryRegionNV*, void>)load(ptr, "vkCmdDecompressMemoryNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkDeviceAddress, VkDeviceAddress, uint32_t, void>* pointer = &Vk.vkCmdDecompressMemoryIndirectCountNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkDeviceAddress, VkDeviceAddress, uint32_t, void>)load(ptr, "vkCmdDecompressMemoryIndirectCountNV");
                }
            }
            if (extension.Contains(VK.VK_NV_DEVICE_GENERATED_COMMANDS_COMPUTE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkComputePipelineCreateInfo*, VkMemoryRequirements2*, void>* pointer = &Vk.vkGetPipelineIndirectMemoryRequirementsNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkComputePipelineCreateInfo*, VkMemoryRequirements2*, void>)load(ptr, "vkGetPipelineIndirectMemoryRequirementsNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkPipelineBindPoint, VkPipeline, void>* pointer = &Vk.vkCmdUpdatePipelineIndirectBufferNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPipelineBindPoint, VkPipeline, void>)load(ptr, "vkCmdUpdatePipelineIndirectBufferNV");
                }
            }
            if (extension.Contains(VK.VK_EXT_EXTENDED_DYNAMIC_STATE_3_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetDepthClampEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetDepthClampEnableEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkPolygonMode, void>* pointer = &Vk.vkCmdSetPolygonModeEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkPolygonMode, void>)load(ptr, "vkCmdSetPolygonModeEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkSampleCountFlagBits, void>* pointer = &Vk.vkCmdSetRasterizationSamplesEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkSampleCountFlagBits, void>)load(ptr, "vkCmdSetRasterizationSamplesEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkSampleCountFlagBits, VkSampleMask*, void>* pointer = &Vk.vkCmdSetSampleMaskEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkSampleCountFlagBits, VkSampleMask*, void>)load(ptr, "vkCmdSetSampleMaskEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetAlphaToCoverageEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetAlphaToCoverageEnableEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetAlphaToOneEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetAlphaToOneEnableEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetLogicOpEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetLogicOpEnableEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBool32*, void>* pointer = &Vk.vkCmdSetColorBlendEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBool32*, void>)load(ptr, "vkCmdSetColorBlendEnableEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkColorBlendEquationEXT*, void>* pointer = &Vk.vkCmdSetColorBlendEquationEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkColorBlendEquationEXT*, void>)load(ptr, "vkCmdSetColorBlendEquationEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkColorComponentFlags*, void>* pointer = &Vk.vkCmdSetColorWriteMaskEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkColorComponentFlags*, void>)load(ptr, "vkCmdSetColorWriteMaskEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkTessellationDomainOrigin, void>* pointer = &Vk.vkCmdSetTessellationDomainOriginEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkTessellationDomainOrigin, void>)load(ptr, "vkCmdSetTessellationDomainOriginEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, void>* pointer = &Vk.vkCmdSetRasterizationStreamEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, void>)load(ptr, "vkCmdSetRasterizationStreamEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkConservativeRasterizationModeEXT, void>* pointer = &Vk.vkCmdSetConservativeRasterizationModeEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkConservativeRasterizationModeEXT, void>)load(ptr, "vkCmdSetConservativeRasterizationModeEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, float, void>* pointer = &Vk.vkCmdSetExtraPrimitiveOverestimationSizeEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, float, void>)load(ptr, "vkCmdSetExtraPrimitiveOverestimationSizeEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetDepthClipEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetDepthClipEnableEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetSampleLocationsEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetSampleLocationsEnableEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkColorBlendAdvancedEXT*, void>* pointer = &Vk.vkCmdSetColorBlendAdvancedEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkColorBlendAdvancedEXT*, void>)load(ptr, "vkCmdSetColorBlendAdvancedEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkProvokingVertexModeEXT, void>* pointer = &Vk.vkCmdSetProvokingVertexModeEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkProvokingVertexModeEXT, void>)load(ptr, "vkCmdSetProvokingVertexModeEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkLineRasterizationModeEXT, void>* pointer = &Vk.vkCmdSetLineRasterizationModeEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkLineRasterizationModeEXT, void>)load(ptr, "vkCmdSetLineRasterizationModeEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetLineStippleEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetLineStippleEnableEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetDepthClipNegativeOneToOneEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetDepthClipNegativeOneToOneEXT");
                }
            }
            // if (extension.Contains(VK.VK_EXT_EXTENDED_DYNAMIC_STATE_3_EXTENSION_NAME ))
            // {

            //     fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetViewportWScalingEnableNV)
            //     {
            //         *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetViewportWScalingEnableNV");
            //     }
            //     fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkViewportSwizzleNV*, void>* pointer = &Vk.vkCmdSetViewportSwizzleNV)
            //     {
            //         *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkViewportSwizzleNV*, void>)load(ptr, "vkCmdSetViewportSwizzleNV");
            //     }
            //     fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetCoverageToColorEnableNV)
            //     {
            //         *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetCoverageToColorEnableNV");
            //     }
            //     fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, void>* pointer = &Vk.vkCmdSetCoverageToColorLocationNV)
            //     {
            //         *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, void>)load(ptr, "vkCmdSetCoverageToColorLocationNV");
            //     }
            //     fixed (delegate* unmanaged<VkCommandBuffer, VkCoverageModulationModeNV, void>* pointer = &Vk.vkCmdSetCoverageModulationModeNV)
            //     {
            //         *pointer = (delegate* unmanaged<VkCommandBuffer, VkCoverageModulationModeNV, void>)load(ptr, "vkCmdSetCoverageModulationModeNV");
            //     }
            //     fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetCoverageModulationTableEnableNV)
            //     {
            //         *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetCoverageModulationTableEnableNV");
            //     }
            //     fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, float*, void>* pointer = &Vk.vkCmdSetCoverageModulationTableNV)
            //     {
            //         *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, float*, void>)load(ptr, "vkCmdSetCoverageModulationTableNV");
            //     }
            //     fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetShadingRateImageEnableNV)
            //     {
            //         *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetShadingRateImageEnableNV");
            //     }
            //     fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, void>* pointer = &Vk.vkCmdSetRepresentativeFragmentTestEnableNV)
            //     {
            //         *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, void>)load(ptr, "vkCmdSetRepresentativeFragmentTestEnableNV");
            //     }
            //     fixed (delegate* unmanaged<VkCommandBuffer, VkCoverageReductionModeNV, void>* pointer = &Vk.vkCmdSetCoverageReductionModeNV)
            //     {
            //         *pointer = (delegate* unmanaged<VkCommandBuffer, VkCoverageReductionModeNV, void>)load(ptr, "vkCmdSetCoverageReductionModeNV");
            //     }
            // }
            if (extension.Contains(VK.VK_EXT_SHADER_MODULE_IDENTIFIER_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkShaderModule, VkShaderModuleIdentifierEXT*, void>* pointer = &Vk.vkGetShaderModuleIdentifierEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkShaderModule, VkShaderModuleIdentifierEXT*, void>)load(ptr, "vkGetShaderModuleIdentifierEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkShaderModuleCreateInfo*, VkShaderModuleIdentifierEXT*, void>* pointer = &Vk.vkGetShaderModuleCreateInfoIdentifierEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkShaderModuleCreateInfo*, VkShaderModuleIdentifierEXT*, void>)load(ptr, "vkGetShaderModuleCreateInfoIdentifierEXT");
                }
            }
            if (extension.Contains(VK.VK_NV_OPTICAL_FLOW_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkOpticalFlowSessionCreateInfoNV*, VkAllocationCallbacks*, VkOpticalFlowSessionNV*, VkResult>* pointer = &Vk.vkCreateOpticalFlowSessionNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkOpticalFlowSessionCreateInfoNV*, VkAllocationCallbacks*, VkOpticalFlowSessionNV*, VkResult>)load(ptr, "vkCreateOpticalFlowSessionNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkOpticalFlowSessionNV, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyOpticalFlowSessionNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkOpticalFlowSessionNV, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyOpticalFlowSessionNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkOpticalFlowSessionNV, VkOpticalFlowSessionBindingPointNV, VkImageView, VkImageLayout, VkResult>* pointer = &Vk.vkBindOpticalFlowSessionImageNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkOpticalFlowSessionNV, VkOpticalFlowSessionBindingPointNV, VkImageView, VkImageLayout, VkResult>)load(ptr, "vkBindOpticalFlowSessionImageNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkOpticalFlowSessionNV, VkOpticalFlowExecuteInfoNV*, void>* pointer = &Vk.vkCmdOpticalFlowExecuteNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkOpticalFlowSessionNV, VkOpticalFlowExecuteInfoNV*, void>)load(ptr, "vkCmdOpticalFlowExecuteNV");
                }
            }
            if (extension.Contains(VK.VK_AMD_ANTI_LAG_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkAntiLagDataAMD*, void>* pointer = &Vk.vkAntiLagUpdateAMD)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkAntiLagDataAMD*, void>)load(ptr, "vkAntiLagUpdateAMD");
                }
            }
            if (extension.Contains(VK.VK_EXT_SHADER_OBJECT_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, uint32_t, VkShaderCreateInfoEXT*, VkAllocationCallbacks*, VkShaderEXT*, VkResult>* pointer = &Vk.vkCreateShadersEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, uint32_t, VkShaderCreateInfoEXT*, VkAllocationCallbacks*, VkShaderEXT*, VkResult>)load(ptr, "vkCreateShadersEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkShaderEXT, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyShaderEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkShaderEXT, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyShaderEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkShaderEXT, /* size_t* */ nuint , void*, VkResult>* pointer = &Vk.vkGetShaderBinaryDataEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkShaderEXT, /* size_t* */ nuint , void*, VkResult>)load(ptr, "vkGetShaderBinaryDataEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkShaderStageFlagBits*, VkShaderEXT*, void>* pointer = &Vk.vkCmdBindShadersEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkShaderStageFlagBits*, VkShaderEXT*, void>)load(ptr, "vkCmdBindShadersEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkDepthClampModeEXT, VkDepthClampRangeEXT*, void>* pointer = &Vk.vkCmdSetDepthClampRangeEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkDepthClampModeEXT, VkDepthClampRangeEXT*, void>)load(ptr, "vkCmdSetDepthClampRangeEXT");
                }
            }
            if (extension.Contains(VK.VK_QCOM_TILE_PROPERTIES_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkFramebuffer, uint32_t*, VkTilePropertiesQCOM*, VkResult>* pointer = &Vk.vkGetFramebufferTilePropertiesQCOM)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkFramebuffer, uint32_t*, VkTilePropertiesQCOM*, VkResult>)load(ptr, "vkGetFramebufferTilePropertiesQCOM");
                }
                fixed (delegate* unmanaged<VkDevice, VkRenderingInfo*, VkTilePropertiesQCOM*, VkResult>* pointer = &Vk.vkGetDynamicRenderingTilePropertiesQCOM)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkRenderingInfo*, VkTilePropertiesQCOM*, VkResult>)load(ptr, "vkGetDynamicRenderingTilePropertiesQCOM");
                }
            }
            if (extension.Contains(VK.VK_NV_COOPERATIVE_VECTOR_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkConvertCooperativeVectorMatrixInfoNV*, VkResult>* pointer = &Vk.vkConvertCooperativeVectorMatrixNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkConvertCooperativeVectorMatrixInfoNV*, VkResult>)load(ptr, "vkConvertCooperativeVectorMatrixNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkConvertCooperativeVectorMatrixInfoNV*, void>* pointer = &Vk.vkCmdConvertCooperativeVectorMatrixNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkConvertCooperativeVectorMatrixInfoNV*, void>)load(ptr, "vkCmdConvertCooperativeVectorMatrixNV");
                }
            }

            if (extension.Contains(VK.VK_NV_LOW_LATENCY_2_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkLatencySleepModeInfoNV*, VkResult>* pointer = &Vk.vkSetLatencySleepModeNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkLatencySleepModeInfoNV*, VkResult>)load(ptr, "vkSetLatencySleepModeNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkLatencySleepInfoNV*, VkResult>* pointer = &Vk.vkLatencySleepNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkLatencySleepInfoNV*, VkResult>)load(ptr, "vkLatencySleepNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkSetLatencyMarkerInfoNV*, void>* pointer = &Vk.vkSetLatencyMarkerNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkSetLatencyMarkerInfoNV*, void>)load(ptr, "vkSetLatencyMarkerNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkGetLatencyMarkerInfoNV*, void>* pointer = &Vk.vkGetLatencyTimingsNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSwapchainKHR, VkGetLatencyMarkerInfoNV*, void>)load(ptr, "vkGetLatencyTimingsNV");
                }
                fixed (delegate* unmanaged<VkQueue, VkOutOfBandQueueTypeInfoNV*, void>* pointer = &Vk.vkQueueNotifyOutOfBandNV)
                {
                    *pointer = (delegate* unmanaged<VkQueue, VkOutOfBandQueueTypeInfoNV*, void>)load(ptr, "vkQueueNotifyOutOfBandNV");
                }
            }
            if (extension.Contains(VK.VK_EXT_ATTACHMENT_FEEDBACK_LOOP_DYNAMIC_STATE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkImageAspectFlags, void>* pointer = &Vk.vkCmdSetAttachmentFeedbackLoopEnableEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkImageAspectFlags, void>)load(ptr, "vkCmdSetAttachmentFeedbackLoopEnableEXT");
                }
            }
            if (extension.Contains(VK.VK_QCOM_TILE_MEMORY_HEAP_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkTileMemoryBindInfoQCOM*, void>* pointer = &Vk.vkCmdBindTileMemoryQCOM)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkTileMemoryBindInfoQCOM*, void>)load(ptr, "vkCmdBindTileMemoryQCOM");
                }
            }
            if (extension.Contains(VK.VK_NV_EXTERNAL_COMPUTE_QUEUE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkExternalComputeQueueCreateInfoNV*, VkAllocationCallbacks*, VkExternalComputeQueueNV*, VkResult>* pointer = &Vk.vkCreateExternalComputeQueueNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkExternalComputeQueueCreateInfoNV*, VkAllocationCallbacks*, VkExternalComputeQueueNV*, VkResult>)load(ptr, "vkCreateExternalComputeQueueNV");
                }
                fixed (delegate* unmanaged<VkDevice, VkExternalComputeQueueNV, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyExternalComputeQueueNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkExternalComputeQueueNV, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyExternalComputeQueueNV");
                }
                fixed (delegate* unmanaged<VkExternalComputeQueueNV, VkExternalComputeQueueDataParamsNV*, void*, void>* pointer = &Vk.vkGetExternalComputeQueueDataNV)
                {
                    *pointer = (delegate* unmanaged<VkExternalComputeQueueNV, VkExternalComputeQueueDataParamsNV*, void*, void>)load(ptr, "vkGetExternalComputeQueueDataNV");
                }
            }
            if (extension.Contains(VK.VK_NV_CLUSTER_ACCELERATION_STRUCTURE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkClusterAccelerationStructureInputInfoNV*, VkAccelerationStructureBuildSizesInfoKHR*, void>* pointer = &Vk.vkGetClusterAccelerationStructureBuildSizesNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkClusterAccelerationStructureInputInfoNV*, VkAccelerationStructureBuildSizesInfoKHR*, void>)load(ptr, "vkGetClusterAccelerationStructureBuildSizesNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkClusterAccelerationStructureCommandsInfoNV*, void>* pointer = &Vk.vkCmdBuildClusterAccelerationStructureIndirectNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkClusterAccelerationStructureCommandsInfoNV*, void>)load(ptr, "vkCmdBuildClusterAccelerationStructureIndirectNV");
                }
            }
            if (extension.Contains(VK.VK_NV_PARTITIONED_ACCELERATION_STRUCTURE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkPartitionedAccelerationStructureInstancesInputNV*, VkAccelerationStructureBuildSizesInfoKHR*, void>* pointer = &Vk.vkGetPartitionedAccelerationStructuresBuildSizesNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPartitionedAccelerationStructureInstancesInputNV*, VkAccelerationStructureBuildSizesInfoKHR*, void>)load(ptr, "vkGetPartitionedAccelerationStructuresBuildSizesNV");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBuildPartitionedAccelerationStructureInfoNV*, void>* pointer = &Vk.vkCmdBuildPartitionedAccelerationStructuresNV)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBuildPartitionedAccelerationStructureInfoNV*, void>)load(ptr, "vkCmdBuildPartitionedAccelerationStructuresNV");
                }
            }
            if (extension.Contains(VK.VK_EXT_DEVICE_GENERATED_COMMANDS_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkGeneratedCommandsMemoryRequirementsInfoEXT*, VkMemoryRequirements2*, void>* pointer = &Vk.vkGetGeneratedCommandsMemoryRequirementsEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkGeneratedCommandsMemoryRequirementsInfoEXT*, VkMemoryRequirements2*, void>)load(ptr, "vkGetGeneratedCommandsMemoryRequirementsEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkGeneratedCommandsInfoEXT*, VkCommandBuffer, void>* pointer = &Vk.vkCmdPreprocessGeneratedCommandsEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkGeneratedCommandsInfoEXT*, VkCommandBuffer, void>)load(ptr, "vkCmdPreprocessGeneratedCommandsEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBool32, VkGeneratedCommandsInfoEXT*, void>* pointer = &Vk.vkCmdExecuteGeneratedCommandsEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBool32, VkGeneratedCommandsInfoEXT*, void>)load(ptr, "vkCmdExecuteGeneratedCommandsEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkIndirectCommandsLayoutCreateInfoEXT*, VkAllocationCallbacks*, VkIndirectCommandsLayoutEXT*, VkResult>* pointer = &Vk.vkCreateIndirectCommandsLayoutEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkIndirectCommandsLayoutCreateInfoEXT*, VkAllocationCallbacks*, VkIndirectCommandsLayoutEXT*, VkResult>)load(ptr, "vkCreateIndirectCommandsLayoutEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkIndirectCommandsLayoutEXT, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyIndirectCommandsLayoutEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkIndirectCommandsLayoutEXT, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyIndirectCommandsLayoutEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkIndirectExecutionSetCreateInfoEXT*, VkAllocationCallbacks*, VkIndirectExecutionSetEXT*, VkResult>* pointer = &Vk.vkCreateIndirectExecutionSetEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkIndirectExecutionSetCreateInfoEXT*, VkAllocationCallbacks*, VkIndirectExecutionSetEXT*, VkResult>)load(ptr, "vkCreateIndirectExecutionSetEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkIndirectExecutionSetEXT, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyIndirectExecutionSetEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkIndirectExecutionSetEXT, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyIndirectExecutionSetEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkIndirectExecutionSetEXT, uint32_t, VkWriteIndirectExecutionSetPipelineEXT*, void>* pointer = &Vk.vkUpdateIndirectExecutionSetPipelineEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkIndirectExecutionSetEXT, uint32_t, VkWriteIndirectExecutionSetPipelineEXT*, void>)load(ptr, "vkUpdateIndirectExecutionSetPipelineEXT");
                }
                fixed (delegate* unmanaged<VkDevice, VkIndirectExecutionSetEXT, uint32_t, VkWriteIndirectExecutionSetShaderEXT*, void>* pointer = &Vk.vkUpdateIndirectExecutionSetShaderEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkIndirectExecutionSetEXT, uint32_t, VkWriteIndirectExecutionSetShaderEXT*, void>)load(ptr, "vkUpdateIndirectExecutionSetShaderEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_FRAGMENT_DENSITY_MAP_OFFSET_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkRenderingEndInfoEXT*, void>* pointer = &Vk.vkCmdEndRendering2EXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkRenderingEndInfoEXT*, void>)load(ptr, "vkCmdEndRendering2EXT");
                }
            }
            if (extension.Contains(VK.VK_KHR_ACCELERATION_STRUCTURE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkAccelerationStructureCreateInfoKHR*, VkAllocationCallbacks*, VkAccelerationStructureKHR*, VkResult>* pointer = &Vk.vkCreateAccelerationStructureKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkAccelerationStructureCreateInfoKHR*, VkAllocationCallbacks*, VkAccelerationStructureKHR*, VkResult>)load(ptr, "vkCreateAccelerationStructureKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkAccelerationStructureKHR, VkAllocationCallbacks*, void>* pointer = &Vk.vkDestroyAccelerationStructureKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkAccelerationStructureKHR, VkAllocationCallbacks*, void>)load(ptr, "vkDestroyAccelerationStructureKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkAccelerationStructureBuildGeometryInfoKHR*, VkAccelerationStructureBuildRangeInfoKHR*, void>* pointer = &Vk.vkCmdBuildAccelerationStructuresKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkAccelerationStructureBuildGeometryInfoKHR*, VkAccelerationStructureBuildRangeInfoKHR*, void>)load(ptr, "vkCmdBuildAccelerationStructuresKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkAccelerationStructureBuildGeometryInfoKHR*, VkDeviceAddress*, uint32_t*, uint32_t*, void>* pointer = &Vk.vkCmdBuildAccelerationStructuresIndirectKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkAccelerationStructureBuildGeometryInfoKHR*, VkDeviceAddress*, uint32_t*, uint32_t*, void>)load(ptr, "vkCmdBuildAccelerationStructuresIndirectKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, uint32_t, VkAccelerationStructureBuildGeometryInfoKHR*, VkAccelerationStructureBuildRangeInfoKHR*, VkResult>* pointer = &Vk.vkBuildAccelerationStructuresKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, uint32_t, VkAccelerationStructureBuildGeometryInfoKHR*, VkAccelerationStructureBuildRangeInfoKHR*, VkResult>)load(ptr, "vkBuildAccelerationStructuresKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyAccelerationStructureInfoKHR*, VkResult>* pointer = &Vk.vkCopyAccelerationStructureKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyAccelerationStructureInfoKHR*, VkResult>)load(ptr, "vkCopyAccelerationStructureKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyAccelerationStructureToMemoryInfoKHR*, VkResult>* pointer = &Vk.vkCopyAccelerationStructureToMemoryKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyAccelerationStructureToMemoryInfoKHR*, VkResult>)load(ptr, "vkCopyAccelerationStructureToMemoryKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyMemoryToAccelerationStructureInfoKHR*, VkResult>* pointer = &Vk.vkCopyMemoryToAccelerationStructureKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyMemoryToAccelerationStructureInfoKHR*, VkResult>)load(ptr, "vkCopyMemoryToAccelerationStructureKHR");
                }
                fixed (delegate* unmanaged<VkDevice, uint32_t, VkAccelerationStructureKHR*, VkQueryType, /* size_t, */ nuint , void*, /* size_t, */ nuint , VkResult>* pointer = &Vk.vkWriteAccelerationStructuresPropertiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, uint32_t, VkAccelerationStructureKHR*, VkQueryType, /* size_t, */ nuint , void*, /* size_t, */ nuint , VkResult>)load(ptr, "vkWriteAccelerationStructuresPropertiesKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkCopyAccelerationStructureInfoKHR*, void>* pointer = &Vk.vkCmdCopyAccelerationStructureKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkCopyAccelerationStructureInfoKHR*, void>)load(ptr, "vkCmdCopyAccelerationStructureKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkCopyAccelerationStructureToMemoryInfoKHR*, void>* pointer = &Vk.vkCmdCopyAccelerationStructureToMemoryKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkCopyAccelerationStructureToMemoryInfoKHR*, void>)load(ptr, "vkCmdCopyAccelerationStructureToMemoryKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkCopyMemoryToAccelerationStructureInfoKHR*, void>* pointer = &Vk.vkCmdCopyMemoryToAccelerationStructureKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkCopyMemoryToAccelerationStructureInfoKHR*, void>)load(ptr, "vkCmdCopyMemoryToAccelerationStructureKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, VkAccelerationStructureKHR*, VkQueryType, VkQueryPool, uint32_t, void>* pointer = &Vk.vkCmdWriteAccelerationStructuresPropertiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, VkAccelerationStructureKHR*, VkQueryType, VkQueryPool, uint32_t, void>)load(ptr, "vkCmdWriteAccelerationStructuresPropertiesKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkAccelerationStructureBuildTypeKHR, VkAccelerationStructureBuildGeometryInfoKHR*, uint32_t*, VkAccelerationStructureBuildSizesInfoKHR*, void>* pointer = &Vk.vkGetAccelerationStructureBuildSizesKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkAccelerationStructureBuildTypeKHR, VkAccelerationStructureBuildGeometryInfoKHR*, uint32_t*, VkAccelerationStructureBuildSizesInfoKHR*, void>)load(ptr, "vkGetAccelerationStructureBuildSizesKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_RAY_TRACING_PIPELINE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, uint32_t, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdTraceRaysKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, uint32_t, uint32_t, uint32_t, void>)load(ptr, "vkCmdTraceRaysKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkPipelineCache, uint32_t, VkRayTracingPipelineCreateInfoKHR*, VkAllocationCallbacks*, VkPipeline*, VkResult>* pointer = &Vk.vkCreateRayTracingPipelinesKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkPipelineCache, uint32_t, VkRayTracingPipelineCreateInfoKHR*, VkAllocationCallbacks*, VkPipeline*, VkResult>)load(ptr, "vkCreateRayTracingPipelinesKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkPipeline, uint32_t, uint32_t, /* size_t, */ nuint , void*, VkResult>* pointer = &Vk.vkGetRayTracingCaptureReplayShaderGroupHandlesKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPipeline, uint32_t, uint32_t, /* size_t, */ nuint , void*, VkResult>)load(ptr, "vkGetRayTracingCaptureReplayShaderGroupHandlesKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, VkDeviceAddress, void>* pointer = &Vk.vkCmdTraceRaysIndirectKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, VkDeviceAddress, void>)load(ptr, "vkCmdTraceRaysIndirectKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkPipeline, uint32_t, VkShaderGroupShaderKHR, VkDeviceSize>* pointer = &Vk.vkGetRayTracingShaderGroupStackSizeKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPipeline, uint32_t, VkShaderGroupShaderKHR, VkDeviceSize>)load(ptr, "vkGetRayTracingShaderGroupStackSizeKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, void>* pointer = &Vk.vkCmdSetRayTracingPipelineStackSizeKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, void>)load(ptr, "vkCmdSetRayTracingPipelineStackSizeKHR");
                }
            }
            if (extension.Contains(VK.VK_EXT_MESH_SHADER_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdDrawMeshTasksEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, uint32_t, void>)load(ptr, "vkCmdDrawMeshTasksEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdDrawMeshTasksIndirectEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>)load(ptr, "vkCmdDrawMeshTasksIndirectEXT");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>* pointer = &Vk.vkCmdDrawMeshTasksIndirectCountEXT)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void>)load(ptr, "vkCmdDrawMeshTasksIndirectCountEXT");
                }
            }

            if (extension.Contains(VK.VK_KHR_SURFACE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t, VkSurfaceKHR, VkBool32*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceSurfaceSupportKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t, VkSurfaceKHR, VkBool32*, VkResult>)load(ptr, "vkGetPhysicalDeviceSurfaceSupportKHR");
                    Log.Info("vkGetPhysicalDeviceSurfaceSupportKHR : value = " + new System.IntPtr(pointer));
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, VkSurfaceKHR, VkSurfaceCapabilitiesKHR*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceSurfaceCapabilitiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkSurfaceKHR, VkSurfaceCapabilitiesKHR*, VkResult>)load(ptr, "vkGetPhysicalDeviceSurfaceCapabilitiesKHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, VkSurfaceKHR, uint32_t*, VkSurfaceFormatKHR*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceSurfaceFormatsKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkSurfaceKHR, uint32_t*, VkSurfaceFormatKHR*, VkResult>)load(ptr, "vkGetPhysicalDeviceSurfaceFormatsKHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, VkSurfaceKHR, uint32_t*, VkPresentModeKHR*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceSurfacePresentModesKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkSurfaceKHR, uint32_t*, VkPresentModeKHR*, VkResult>)load(ptr, "vkGetPhysicalDeviceSurfacePresentModesKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_SWAPCHAIN_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkDeviceGroupPresentCapabilitiesKHR*, VkResult>* pointer = &Vk.vkGetDeviceGroupPresentCapabilitiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeviceGroupPresentCapabilitiesKHR*, VkResult>)load(ptr, "vkGetDeviceGroupPresentCapabilitiesKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkSurfaceKHR, VkDeviceGroupPresentModeFlagsKHR*, VkResult>* pointer = &Vk.vkGetDeviceGroupSurfacePresentModesKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkSurfaceKHR, VkDeviceGroupPresentModeFlagsKHR*, VkResult>)load(ptr, "vkGetDeviceGroupSurfacePresentModesKHR");
                }
                // fixed (delegate* unmanaged<VkPhysicalDevice, VkSurfaceKHR, uint32_t*, VkRect2D*, VkResult>* pointer = &Vk.vkGetPhysicalDevicePresentRectanglesKHR)
                // {
                //     *pointer = (delegate* unmanaged<VkPhysicalDevice, VkSurfaceKHR, uint32_t*, VkRect2D*, VkResult>)load(ptr, "vkGetPhysicalDevicePresentRectanglesKHR");
                // }

            }
            if (extension.Contains(VK.VK_KHR_DISPLAY_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkDisplayPropertiesKHR*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceDisplayPropertiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkDisplayPropertiesKHR*, VkResult>)load(ptr, "vkGetPhysicalDeviceDisplayPropertiesKHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkDisplayPlanePropertiesKHR*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceDisplayPlanePropertiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkDisplayPlanePropertiesKHR*, VkResult>)load(ptr, "vkGetPhysicalDeviceDisplayPlanePropertiesKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_VIDEO_QUEUE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, VkVideoProfileInfoKHR*, VkVideoCapabilitiesKHR*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceVideoCapabilitiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkVideoProfileInfoKHR*, VkVideoCapabilitiesKHR*, VkResult>)load(ptr, "vkGetPhysicalDeviceVideoCapabilitiesKHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceVideoFormatInfoKHR*, uint32_t*, VkVideoFormatPropertiesKHR*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceVideoFormatPropertiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceVideoFormatInfoKHR*, uint32_t*, VkVideoFormatPropertiesKHR*, VkResult>)load(ptr, "vkGetPhysicalDeviceVideoFormatPropertiesKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_GET_PHYSICAL_DEVICE_PROPERTIES_2_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceFeatures2*, void>* pointer = &Vk.vkGetPhysicalDeviceFeatures2KHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceFeatures2*, void>)load(ptr, "vkGetPhysicalDeviceFeatures2KHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceProperties2*, void>* pointer = &Vk.vkGetPhysicalDeviceProperties2KHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceProperties2*, void>)load(ptr, "vkGetPhysicalDeviceProperties2KHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, VkFormat, VkFormatProperties2*, void>* pointer = &Vk.vkGetPhysicalDeviceFormatProperties2KHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkFormat, VkFormatProperties2*, void>)load(ptr, "vkGetPhysicalDeviceFormatProperties2KHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceImageFormatInfo2*, VkImageFormatProperties2*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceImageFormatProperties2KHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceImageFormatInfo2*, VkImageFormatProperties2*, VkResult>)load(ptr, "vkGetPhysicalDeviceImageFormatProperties2KHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkQueueFamilyProperties2*, void>* pointer = &Vk.vkGetPhysicalDeviceQueueFamilyProperties2KHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkQueueFamilyProperties2*, void>)load(ptr, "vkGetPhysicalDeviceQueueFamilyProperties2KHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceMemoryProperties2*, void>* pointer = &Vk.vkGetPhysicalDeviceMemoryProperties2KHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceMemoryProperties2*, void>)load(ptr, "vkGetPhysicalDeviceMemoryProperties2KHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceSparseImageFormatInfo2*, uint32_t*, VkSparseImageFormatProperties2*, void>* pointer = &Vk.vkGetPhysicalDeviceSparseImageFormatProperties2KHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceSparseImageFormatInfo2*, uint32_t*, VkSparseImageFormatProperties2*, void>)load(ptr, "vkGetPhysicalDeviceSparseImageFormatProperties2KHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_DEVICE_GROUP_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, uint32_t, uint32_t, uint32_t, VkPeerMemoryFeatureFlags*, void>* pointer = &Vk.vkGetDeviceGroupPeerMemoryFeaturesKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, uint32_t, uint32_t, uint32_t, VkPeerMemoryFeatureFlags*, void>)load(ptr, "vkGetDeviceGroupPeerMemoryFeaturesKHR");
                }
                fixed (delegate* unmanaged<VkCommandBuffer, uint32_t, void>* pointer = &Vk.vkCmdSetDeviceMaskKHR)
                {
                    *pointer = (delegate* unmanaged<VkCommandBuffer, uint32_t, void>)load(ptr, "vkCmdSetDeviceMaskKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_DEVICE_GROUP_CREATION_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkInstance, uint32_t*, VkPhysicalDeviceGroupProperties*, VkResult>* pointer = &Vk.vkEnumeratePhysicalDeviceGroupsKHR)
                {
                    *pointer = (delegate* unmanaged<VkInstance, uint32_t*, VkPhysicalDeviceGroupProperties*, VkResult>)load(ptr, "vkEnumeratePhysicalDeviceGroupsKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_EXTERNAL_MEMORY_CAPABILITIES_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceExternalBufferInfo*, VkExternalBufferProperties*, void>* pointer = &Vk.vkGetPhysicalDeviceExternalBufferPropertiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceExternalBufferInfo*, VkExternalBufferProperties*, void>)load(ptr, "vkGetPhysicalDeviceExternalBufferPropertiesKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_EXTERNAL_SEMAPHORE_CAPABILITIES_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceExternalSemaphoreInfo*, VkExternalSemaphoreProperties*, void>* pointer = &Vk.vkGetPhysicalDeviceExternalSemaphorePropertiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceExternalSemaphoreInfo*, VkExternalSemaphoreProperties*, void>)load(ptr, "vkGetPhysicalDeviceExternalSemaphorePropertiesKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_EXTERNAL_FENCE_CAPABILITIES_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceExternalFenceInfo*, VkExternalFenceProperties*, void>* pointer = &Vk.vkGetPhysicalDeviceExternalFencePropertiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceExternalFenceInfo*, VkExternalFenceProperties*, void>)load(ptr, "vkGetPhysicalDeviceExternalFencePropertiesKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_PERFORMANCE_QUERY_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t, uint32_t*, VkPerformanceCounterKHR*, VkPerformanceCounterDescriptionKHR*, VkResult>* pointer = &Vk.vkEnumeratePhysicalDeviceQueueFamilyPerformanceQueryCountersKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t, uint32_t*, VkPerformanceCounterKHR*, VkPerformanceCounterDescriptionKHR*, VkResult>)load(ptr, "vkEnumeratePhysicalDeviceQueueFamilyPerformanceQueryCountersKHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, VkQueryPoolPerformanceCreateInfoKHR*, uint32_t*, void>* pointer = &Vk.vkGetPhysicalDeviceQueueFamilyPerformanceQueryPassesKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkQueryPoolPerformanceCreateInfoKHR*, uint32_t*, void>)load(ptr, "vkGetPhysicalDeviceQueueFamilyPerformanceQueryPassesKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_GET_SURFACE_CAPABILITIES_2_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, VkSurfaceCapabilities2KHR*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceSurfaceCapabilities2KHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, VkSurfaceCapabilities2KHR*, VkResult>)load(ptr, "vkGetPhysicalDeviceSurfaceCapabilities2KHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, uint32_t*, VkSurfaceFormat2KHR*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceSurfaceFormats2KHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, uint32_t*, VkSurfaceFormat2KHR*, VkResult>)load(ptr, "vkGetPhysicalDeviceSurfaceFormats2KHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_GET_DISPLAY_PROPERTIES_2_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkDisplayProperties2KHR*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceDisplayProperties2KHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkDisplayProperties2KHR*, VkResult>)load(ptr, "vkGetPhysicalDeviceDisplayProperties2KHR");
                }
                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkDisplayPlaneProperties2KHR*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceDisplayPlaneProperties2KHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkDisplayPlaneProperties2KHR*, VkResult>)load(ptr, "vkGetPhysicalDeviceDisplayPlaneProperties2KHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_FRAGMENT_SHADING_RATE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkPhysicalDeviceFragmentShadingRateKHR*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceFragmentShadingRatesKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkPhysicalDeviceFragmentShadingRateKHR*, VkResult>)load(ptr, "vkGetPhysicalDeviceFragmentShadingRatesKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_BUFFER_DEVICE_ADDRESS_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkBufferDeviceAddressInfo*, VkDeviceAddress>* pointer = &Vk.vkGetBufferDeviceAddressKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkBufferDeviceAddressInfo*, VkDeviceAddress>)load(ptr, "vkGetBufferDeviceAddressKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkDeviceMemoryOpaqueCaptureAddressInfo*, uint64_t>* pointer = &Vk.vkGetDeviceMemoryOpaqueCaptureAddressKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeviceMemoryOpaqueCaptureAddressInfo*, uint64_t>)load(ptr, "vkGetDeviceMemoryOpaqueCaptureAddressKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_VIDEO_ENCODE_QUEUE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceVideoEncodeQualityLevelInfoKHR*, VkVideoEncodeQualityLevelPropertiesKHR*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceVideoEncodeQualityLevelPropertiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceVideoEncodeQualityLevelInfoKHR*, VkVideoEncodeQualityLevelPropertiesKHR*, VkResult>)load(ptr, "vkGetPhysicalDeviceVideoEncodeQualityLevelPropertiesKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_MAINTENANCE_4_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkDeviceBufferMemoryRequirements*, VkMemoryRequirements2*, void>* pointer = &Vk.vkGetDeviceBufferMemoryRequirementsKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeviceBufferMemoryRequirements*, VkMemoryRequirements2*, void>)load(ptr, "vkGetDeviceBufferMemoryRequirementsKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkDeviceImageMemoryRequirements*, VkMemoryRequirements2*, void>* pointer = &Vk.vkGetDeviceImageMemoryRequirementsKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeviceImageMemoryRequirements*, VkMemoryRequirements2*, void>)load(ptr, "vkGetDeviceImageMemoryRequirementsKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkDeviceImageMemoryRequirements*, uint32_t*, VkSparseImageMemoryRequirements2*, void>* pointer = &Vk.vkGetDeviceImageSparseMemoryRequirementsKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeviceImageMemoryRequirements*, uint32_t*, VkSparseImageMemoryRequirements2*, void>)load(ptr, "vkGetDeviceImageSparseMemoryRequirementsKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_MAINTENANCE_5_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkDeviceImageSubresourceInfo*, VkSubresourceLayout2*, void>* pointer = &Vk.vkGetDeviceImageSubresourceLayoutKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeviceImageSubresourceInfo*, VkSubresourceLayout2*, void>)load(ptr, "vkGetDeviceImageSubresourceLayoutKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_COOPERATIVE_MATRIX_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkCooperativeMatrixPropertiesKHR*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceCooperativeMatrixPropertiesKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkCooperativeMatrixPropertiesKHR*, VkResult>)load(ptr, "vkGetPhysicalDeviceCooperativeMatrixPropertiesKHR");
                }
            }
            if (extension.Contains(VK.VK_KHR_CALIBRATED_TIMESTAMPS_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkTimeDomainKHR*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceCalibrateableTimeDomainsKHR)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkTimeDomainKHR*, VkResult>)load(ptr, "vkGetPhysicalDeviceCalibrateableTimeDomainsKHR");
                }
            }
            if (extension.Contains(VK.VK_NV_EXTERNAL_MEMORY_CAPABILITIES_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, VkFormat, VkImageType, VkImageTiling, VkImageUsageFlags, VkImageCreateFlags, VkExternalMemoryHandleTypeFlagsNV, VkExternalImageFormatPropertiesNV*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceExternalImageFormatPropertiesNV)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkFormat, VkImageType, VkImageTiling, VkImageUsageFlags, VkImageCreateFlags, VkExternalMemoryHandleTypeFlagsNV, VkExternalImageFormatPropertiesNV*, VkResult>)load(ptr, "vkGetPhysicalDeviceExternalImageFormatPropertiesNV");
                }
            }
            if (extension.Contains(VK.VK_EXT_DISPLAY_SURFACE_COUNTER_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, VkSurfaceKHR, VkSurfaceCapabilities2EXT*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceSurfaceCapabilities2EXT)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkSurfaceKHR, VkSurfaceCapabilities2EXT*, VkResult>)load(ptr, "vkGetPhysicalDeviceSurfaceCapabilities2EXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_DISPLAY_CONTROL_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkDeviceEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>* pointer = &Vk.vkRegisterDeviceEventEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeviceEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult>)load(ptr, "vkRegisterDeviceEventEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_SAMPLE_LOCATIONS_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, VkSampleCountFlagBits, VkMultisamplePropertiesEXT*, void>* pointer = &Vk.vkGetPhysicalDeviceMultisamplePropertiesEXT)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkSampleCountFlagBits, VkMultisamplePropertiesEXT*, void>)load(ptr, "vkGetPhysicalDeviceMultisamplePropertiesEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_CALIBRATED_TIMESTAMPS_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkTimeDomainKHR*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceCalibrateableTimeDomainsEXT)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkTimeDomainKHR*, VkResult>)load(ptr, "vkGetPhysicalDeviceCalibrateableTimeDomainsEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_BUFFER_DEVICE_ADDRESS_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkBufferDeviceAddressInfo*, VkDeviceAddress>* pointer = &Vk.vkGetBufferDeviceAddressEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkBufferDeviceAddressInfo*, VkDeviceAddress>)load(ptr, "vkGetBufferDeviceAddressEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_TOOLING_INFO_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkPhysicalDeviceToolProperties*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceToolPropertiesEXT)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkPhysicalDeviceToolProperties*, VkResult>)load(ptr, "vkGetPhysicalDeviceToolPropertiesEXT");
                }
            }
            if (extension.Contains(VK.VK_NV_COOPERATIVE_MATRIX_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkCooperativeMatrixPropertiesNV*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceCooperativeMatrixPropertiesNV)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkCooperativeMatrixPropertiesNV*, VkResult>)load(ptr, "vkGetPhysicalDeviceCooperativeMatrixPropertiesNV");
                }
            }
            if (extension.Contains(VK.VK_NV_COVERAGE_REDUCTION_MODE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkFramebufferMixedSamplesCombinationNV*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceSupportedFramebufferMixedSamplesCombinationsNV)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkFramebufferMixedSamplesCombinationNV*, VkResult>)load(ptr, "vkGetPhysicalDeviceSupportedFramebufferMixedSamplesCombinationsNV");
                }
            }
            if (extension.Contains(VK.VK_EXT_DEVICE_FAULT_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkDeviceFaultCountsEXT*, VkDeviceFaultInfoEXT*, VkResult>* pointer = &Vk.vkGetDeviceFaultInfoEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeviceFaultCountsEXT*, VkDeviceFaultInfoEXT*, VkResult>)load(ptr, "vkGetDeviceFaultInfoEXT");
                }
            }
            if (extension.Contains(VK.VK_HUAWEI_SUBPASS_SHADING_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkRenderPass, VkExtent2D*, VkResult>* pointer = &Vk.vkGetDeviceSubpassShadingMaxWorkgroupSizeHUAWEI)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkRenderPass, VkExtent2D*, VkResult>)load(ptr, "vkGetDeviceSubpassShadingMaxWorkgroupSizeHUAWEI");
                }
            }
            if (extension.Contains(VK.VK_EXT_OPACITY_MICROMAP_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkMicromapVersionInfoEXT*, VkAccelerationStructureCompatibilityKHR*, void>* pointer = &Vk.vkGetDeviceMicromapCompatibilityEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkMicromapVersionInfoEXT*, VkAccelerationStructureCompatibilityKHR*, void>)load(ptr, "vkGetDeviceMicromapCompatibilityEXT");
                }
            }
            if (extension.Contains(VK.VK_EXT_PAGEABLE_DEVICE_LOCAL_MEMORY_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkDeviceMemory, float, void>* pointer = &Vk.vkSetDeviceMemoryPriorityEXT)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkDeviceMemory, float, void>)load(ptr, "vkSetDeviceMemoryPriorityEXT");
                }
            }
            if (extension.Contains(VK.VK_NV_DEVICE_GENERATED_COMMANDS_COMPUTE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkPipelineIndirectDeviceAddressInfoNV*, VkDeviceAddress>* pointer = &Vk.vkGetPipelineIndirectDeviceAddressNV)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkPipelineIndirectDeviceAddressInfoNV*, VkDeviceAddress>)load(ptr, "vkGetPipelineIndirectDeviceAddressNV");
                }
            }
            if (extension.Contains(VK.VK_NV_OPTICAL_FLOW_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, VkOpticalFlowImageFormatInfoNV*, uint32_t*, VkOpticalFlowImageFormatPropertiesNV*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceOpticalFlowImageFormatsNV)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, VkOpticalFlowImageFormatInfoNV*, uint32_t*, VkOpticalFlowImageFormatPropertiesNV*, VkResult>)load(ptr, "vkGetPhysicalDeviceOpticalFlowImageFormatsNV");
                }
            }
            if (extension.Contains(VK.VK_NV_COOPERATIVE_VECTOR_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkCooperativeVectorPropertiesNV*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceCooperativeVectorPropertiesNV)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkCooperativeVectorPropertiesNV*, VkResult>)load(ptr, "vkGetPhysicalDeviceCooperativeVectorPropertiesNV");
                }
            }
            if (extension.Contains(VK.VK_NV_COOPERATIVE_MATRIX_2_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkCooperativeMatrixFlexibleDimensionsPropertiesNV*, VkResult>* pointer = &Vk.vkGetPhysicalDeviceCooperativeMatrixFlexibleDimensionsPropertiesNV)
                {
                    *pointer = (delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkCooperativeMatrixFlexibleDimensionsPropertiesNV*, VkResult>)load(ptr, "vkGetPhysicalDeviceCooperativeMatrixFlexibleDimensionsPropertiesNV");
                }
            }
            if (extension.Contains(VK.VK_KHR_ACCELERATION_STRUCTURE_EXTENSION_NAME))
            {

                fixed (delegate* unmanaged<VkDevice, VkAccelerationStructureDeviceAddressInfoKHR*, VkDeviceAddress>* pointer = &Vk.vkGetAccelerationStructureDeviceAddressKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkAccelerationStructureDeviceAddressInfoKHR*, VkDeviceAddress>)load(ptr, "vkGetAccelerationStructureDeviceAddressKHR");
                }
                fixed (delegate* unmanaged<VkDevice, VkAccelerationStructureVersionInfoKHR*, VkAccelerationStructureCompatibilityKHR*, void>* pointer = &Vk.vkGetDeviceAccelerationStructureCompatibilityKHR)
                {
                    *pointer = (delegate* unmanaged<VkDevice, VkAccelerationStructureVersionInfoKHR*, VkAccelerationStructureCompatibilityKHR*, void>)load(ptr, "vkGetDeviceAccelerationStructureCompatibilityKHR");
                }
            }

        } // END FOR  LOOP
    } // END FUNC TION LOAD
}
