namespace Hemy.Lib.Core.Platform.Vulkan;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security; 
using System;

using uint32_t = System.UInt32;
using uint64_t = System.UInt64;
using uint8_t = System.Byte;
using int32_t = System.Int32;
using int64_t = System.Int64;
using uint16_t = System.UInt16;
using ConstChar = System.Byte;
// using /* size_t */ nuint = System.UInt64;//

using VkPipelineStageFlagBits2 = System.UInt64;
using VkAccessFlagBits2 = System.UInt64;
using VkFormatFeatureFlagBits2 = System.UInt64;
using VkPipelineCreateFlagBits2 = System.UInt64;
using  VkBufferUsageFlagBits2 =  System.UInt64 ;
using VkAccessFlagBits3KHR = System.UInt64;
using VkPhysicalDeviceSchedulingControlsFlagBitsARM = System.UInt64; 
using  VkMemoryDecompressionMethodFlagBitsNV =  System.UInt64 ; 

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

// [SkipLocalsInit]
// [SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE)]
public unsafe static partial class Vk
{
	const string Vulkan =
#if WINDOWS
    "vulkan-1.dll";
#endif

    #region VK_VERSION_1_0
    [LibraryImport(Vulkan, SetLastError = true)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateInstance(VkInstanceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkInstance* pInstance);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyInstance(VkInstance instance, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkEnumeratePhysicalDevices(VkInstance instance, uint32_t* pPhysicalDeviceCount, VkPhysicalDevice* pPhysicalDevices);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPhysicalDeviceFeatures(VkPhysicalDevice physicalDevice, VkPhysicalDeviceFeatures* pFeatures);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPhysicalDeviceFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkFormatProperties* pFormatProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkGetPhysicalDeviceImageFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkImageTiling tiling, VkImageUsageFlags usage, VkImageCreateFlags flags, VkImageFormatProperties* pImageFormatProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPhysicalDeviceProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceProperties* pProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPhysicalDeviceQueueFamilyProperties(VkPhysicalDevice physicalDevice, uint32_t* pQueueFamilyPropertyCount, VkQueueFamilyProperties* pQueueFamilyProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPhysicalDeviceMemoryProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceMemoryProperties* pMemoryProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void* vkGetInstanceProcAddr(VkInstance instance, ConstChar* pName);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void* vkGetDeviceProcAddr(VkDevice device, ConstChar* pName);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateDevice(VkPhysicalDevice physicalDevice, VkDeviceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDevice* pDevice);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyDevice(VkDevice device, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkEnumerateInstanceExtensionProperties(ConstChar* pLayerName, uint32_t* pPropertyCount, VkExtensionProperties* pProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkEnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice, ConstChar* pLayerName, uint32_t* pPropertyCount, VkExtensionProperties* pProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkEnumerateInstanceLayerProperties(uint32_t* pPropertyCount, VkLayerProperties* pProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkEnumerateDeviceLayerProperties(VkPhysicalDevice physicalDevice, uint32_t* pPropertyCount, VkLayerProperties* pProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetDeviceQueue(VkDevice device, uint32_t queueFamilyIndex, uint32_t queueIndex, VkQueue* pQueue);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkQueueSubmit(VkQueue queue, uint32_t submitCount, VkSubmitInfo* pSubmits, VkFence fence);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkQueueWaitIdle(VkQueue queue);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkDeviceWaitIdle(VkDevice device);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkAllocateMemory(VkDevice device, VkMemoryAllocateInfo* pAllocateInfo, VkAllocationCallbacks* pAllocator, VkDeviceMemory* pMemory);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkFreeMemory(VkDevice device, VkDeviceMemory memory, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkMapMemory(VkDevice device, VkDeviceMemory memory, VkDeviceSize offset, VkDeviceSize size, VkMemoryMapFlags flags, void** ppData);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkUnmapMemory(VkDevice device, VkDeviceMemory memory);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkFlushMappedMemoryRanges(VkDevice device, uint32_t memoryRangeCount, VkMappedMemoryRange* pMemoryRanges);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkInvalidateMappedMemoryRanges(VkDevice device, uint32_t memoryRangeCount, VkMappedMemoryRange* pMemoryRanges);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetDeviceMemoryCommitment(VkDevice device, VkDeviceMemory memory, VkDeviceSize* pCommittedMemoryInBytes);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkBindBufferMemory(VkDevice device, VkBuffer buffer, VkDeviceMemory memory, VkDeviceSize memoryOffset);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkBindImageMemory(VkDevice device, VkImage image, VkDeviceMemory memory, VkDeviceSize memoryOffset);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetBufferMemoryRequirements(VkDevice device, VkBuffer buffer, VkMemoryRequirements* pMemoryRequirements);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetImageMemoryRequirements(VkDevice device, VkImage image, VkMemoryRequirements* pMemoryRequirements);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetImageSparseMemoryRequirements(VkDevice device, VkImage image, uint32_t* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements* pSparseMemoryRequirements);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPhysicalDeviceSparseImageFormatProperties(VkPhysicalDevice physicalDevice, VkFormat format, VkImageType type, VkSampleCountFlagBits samples, VkImageUsageFlags usage, VkImageTiling tiling, uint32_t* pPropertyCount, VkSparseImageFormatProperties* pProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkQueueBindSparse(VkQueue queue, uint32_t bindInfoCount, VkBindSparseInfo* pBindInfo, VkFence fence);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateFence(VkDevice device, VkFenceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkFence* pFence);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyFence(VkDevice device, VkFence fence, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkResetFences(VkDevice device, uint32_t fenceCount, VkFence* pFences);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkGetFenceStatus(VkDevice device, VkFence fence);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkWaitForFences(VkDevice device, uint32_t fenceCount, VkFence* pFences, VkBool32 waitAll, uint64_t timeout);
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]

	internal static unsafe partial VkResult vkCreateSemaphore(VkDevice device, VkSemaphoreCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSemaphore* pSemaphore);
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]

	internal static unsafe partial void vkDestroySemaphore(VkDevice device, VkSemaphore semaphore, VkAllocationCallbacks* pAllocator);
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]

	internal static unsafe partial VkResult vkCreateEvent(VkDevice device, VkEventCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkEvent* pEvent);
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyEvent(VkDevice device, VkEvent @event, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkGetEventStatus(VkDevice device, VkEvent @event);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkSetEvent(VkDevice device, VkEvent @event);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkResetEvent(VkDevice device, VkEvent @event);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateQueryPool(VkDevice device, VkQueryPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkQueryPool* pQueryPool);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyQueryPool(VkDevice device, VkQueryPool queryPool, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkGetQueryPoolResults(VkDevice device, VkQueryPool queryPool, uint32_t firstQuery, uint32_t queryCount, /* size_t */ nuint dataSize, void* pData, VkDeviceSize stride, VkQueryResultFlags flags);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateBuffer(VkDevice device, VkBufferCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkBuffer* pBuffer);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyBuffer(VkDevice device, VkBuffer buffer, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateBufferView(VkDevice device, VkBufferViewCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkBufferView* pView);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyBufferView(VkDevice device, VkBufferView bufferView, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateImage(VkDevice device, VkImageCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkImage* pImage);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyImage(VkDevice device, VkImage image, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetImageSubresourceLayout(VkDevice device, VkImage image, VkImageSubresource* pSubresource, VkSubresourceLayout* pLayout);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateImageView(VkDevice device, VkImageViewCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkImageView* pView);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyImageView(VkDevice device, VkImageView imageView, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateShaderModule(VkDevice device, VkShaderModuleCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkShaderModule* pShaderModule);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyShaderModule(VkDevice device, VkShaderModule shaderModule, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreatePipelineCache(VkDevice device, VkPipelineCacheCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkPipelineCache* pPipelineCache);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyPipelineCache(VkDevice device, VkPipelineCache pipelineCache, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkGetPipelineCacheData(VkDevice device, VkPipelineCache pipelineCache, /* size_t* */ nuint  pDataSize, void* pData);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkMergePipelineCaches(VkDevice device, VkPipelineCache dstCache, uint32_t srcCacheCount, VkPipelineCache* pSrcCaches);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateGraphicsPipelines(VkDevice device, VkPipelineCache pipelineCache, uint32_t createInfoCount, VkGraphicsPipelineCreateInfo* pCreateInfos, VkAllocationCallbacks* pAllocator, VkPipeline* pPipelines);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateComputePipelines(VkDevice device, VkPipelineCache pipelineCache, uint32_t createInfoCount, VkComputePipelineCreateInfo* pCreateInfos, VkAllocationCallbacks* pAllocator, VkPipeline* pPipelines);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyPipeline(VkDevice device, VkPipeline pipeline, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreatePipelineLayout(VkDevice device, VkPipelineLayoutCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkPipelineLayout* pPipelineLayout);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyPipelineLayout(VkDevice device, VkPipelineLayout pipelineLayout, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateSampler(VkDevice device, VkSamplerCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSampler* pSampler);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroySampler(VkDevice device, VkSampler sampler, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateDescriptorSetLayout(VkDevice device, VkDescriptorSetLayoutCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorSetLayout* pSetLayout);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyDescriptorSetLayout(VkDevice device, VkDescriptorSetLayout descriptorSetLayout, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateDescriptorPool(VkDevice device, VkDescriptorPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorPool* pDescriptorPool);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyDescriptorPool(VkDevice device, VkDescriptorPool descriptorPool, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]

	internal static unsafe partial VkResult vkResetDescriptorPool(VkDevice device, VkDescriptorPool descriptorPool, VkDescriptorPoolResetFlags flags);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkAllocateDescriptorSets(VkDevice device, VkDescriptorSetAllocateInfo* pAllocateInfo, VkDescriptorSet* pDescriptorSets);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkFreeDescriptorSets(VkDevice device, VkDescriptorPool descriptorPool, uint32_t descriptorSetCount, VkDescriptorSet* pDescriptorSets);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkUpdateDescriptorSets(VkDevice device, uint32_t descriptorWriteCount, VkWriteDescriptorSet* pDescriptorWrites, uint32_t descriptorCopyCount, VkCopyDescriptorSet* pDescriptorCopies);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateFramebuffer(VkDevice device, VkFramebufferCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkFramebuffer* pFramebuffer);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyFramebuffer(VkDevice device, VkFramebuffer framebuffer, VkAllocationCallbacks* pAllocator);

    // // [SkipLocalsInit]
    // // [SuppressGCTransition]
    // // [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateRenderPass(VkDevice device, VkRenderPassCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkRenderPass* pRenderPass);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyRenderPass(VkDevice device, VkRenderPass renderPass, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetRenderAreaGranularity(VkDevice device, VkRenderPass renderPass, VkExtent2D* pGranularity);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateCommandPool(VkDevice device, VkCommandPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkCommandPool* pCommandPool);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyCommandPool(VkDevice device, VkCommandPool commandPool, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkResetCommandPool(VkDevice device, VkCommandPool commandPool, VkCommandPoolResetFlags flags);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkAllocateCommandBuffers(VkDevice device, VkCommandBufferAllocateInfo* pAllocateInfo, VkCommandBuffer* pCommandBuffers);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkFreeCommandBuffers(VkDevice device, VkCommandPool commandPool, uint32_t commandBufferCount, VkCommandBuffer* pCommandBuffers);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkBeginCommandBuffer(VkCommandBuffer commandBuffer, VkCommandBufferBeginInfo* pBeginInfo);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkEndCommandBuffer(VkCommandBuffer commandBuffer);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkResetCommandBuffer(VkCommandBuffer commandBuffer, VkCommandBufferResetFlags flags);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdBindPipeline(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipeline pipeline);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetViewport(VkCommandBuffer commandBuffer, uint32_t firstViewport, uint32_t viewportCount, VkViewport* pViewports);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetScissor(VkCommandBuffer commandBuffer, uint32_t firstScissor, uint32_t scissorCount, VkRect2D* pScissors);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetLineWidth(VkCommandBuffer commandBuffer, float lineWidth);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetDepthBias(VkCommandBuffer commandBuffer, float depthBiasConstantFactor, float depthBiasClamp, float depthBiasSlopeFactor);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetBlendConstants(VkCommandBuffer commandBuffer, float[] blendConstants);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetDepthBounds(VkCommandBuffer commandBuffer, float minDepthBounds, float maxDepthBounds);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetStencilCompareMask(VkCommandBuffer commandBuffer, VkStencilFaceFlags faceMask, uint32_t compareMask);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetStencilWriteMask(VkCommandBuffer commandBuffer, VkStencilFaceFlags faceMask, uint32_t writeMask);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetStencilReference(VkCommandBuffer commandBuffer, VkStencilFaceFlags faceMask, uint32_t reference);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdBindDescriptorSets(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipelineLayout layout, uint32_t firstSet, uint32_t descriptorSetCount, VkDescriptorSet* pDescriptorSets, uint32_t dynamicOffsetCount, uint32_t* pDynamicOffsets);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdBindIndexBuffer(VkCommandBuffer commandBuffer, VkBuffer buffer, VkDeviceSize offset, VkIndexType indexType);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdBindVertexBuffers(VkCommandBuffer commandBuffer, uint32_t firstBinding, uint32_t bindingCount, VkBuffer* pBuffers, VkDeviceSize* pOffsets);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdDraw(VkCommandBuffer commandBuffer, uint32_t vertexCount, uint32_t instanceCount, uint32_t firstVertex, uint32_t firstInstance);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdDrawIndexed(VkCommandBuffer commandBuffer, uint32_t indexCount, uint32_t instanceCount, uint32_t firstIndex, int32_t vertexOffset, uint32_t firstInstance);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]

	internal static unsafe partial void vkCmdDrawIndirect(VkCommandBuffer commandBuffer, VkBuffer buffer, VkDeviceSize offset, uint32_t drawCount, uint32_t stride);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdDrawIndexedIndirect(VkCommandBuffer commandBuffer, VkBuffer buffer, VkDeviceSize offset, uint32_t drawCount, uint32_t stride);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdDispatch(VkCommandBuffer commandBuffer, uint32_t groupCountX, uint32_t groupCountY, uint32_t groupCountZ);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdDispatchIndirect(VkCommandBuffer commandBuffer, VkBuffer buffer, VkDeviceSize offset);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdCopyBuffer(VkCommandBuffer commandBuffer, VkBuffer srcBuffer, VkBuffer dstBuffer, uint32_t regionCount, VkBufferCopy* pRegions);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdCopyImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint32_t regionCount, VkImageCopy* pRegions);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdBlitImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint32_t regionCount, VkImageBlit* pRegions, VkFilter filter);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdCopyBufferToImage(VkCommandBuffer commandBuffer, VkBuffer srcBuffer, VkImage dstImage, VkImageLayout dstImageLayout, uint32_t regionCount, VkBufferImageCopy* pRegions);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdCopyImageToBuffer(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkBuffer dstBuffer, uint32_t regionCount, VkBufferImageCopy* pRegions);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdUpdateBuffer(VkCommandBuffer commandBuffer, VkBuffer dstBuffer, VkDeviceSize dstOffset, VkDeviceSize dataSize, void* pData);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdFillBuffer(VkCommandBuffer commandBuffer, VkBuffer dstBuffer, VkDeviceSize dstOffset, VkDeviceSize size, uint32_t data);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdClearColorImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, VkClearColorValue* pColor, uint32_t rangeCount, VkImageSubresourceRange* pRanges);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdClearDepthStencilImage(VkCommandBuffer commandBuffer, VkImage image, VkImageLayout imageLayout, VkClearDepthStencilValue* pDepthStencil, uint32_t rangeCount, VkImageSubresourceRange* pRanges);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdClearAttachments(VkCommandBuffer commandBuffer, uint32_t attachmentCount, VkClearAttachment* pAttachments, uint32_t rectCount, VkClearRect* pRects);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdResolveImage(VkCommandBuffer commandBuffer, VkImage srcImage, VkImageLayout srcImageLayout, VkImage dstImage, VkImageLayout dstImageLayout, uint32_t regionCount, VkImageResolve* pRegions);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetEvent(VkCommandBuffer commandBuffer, VkEvent @event, VkPipelineStageFlags stageMask);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdResetEvent(VkCommandBuffer commandBuffer, VkEvent @event, VkPipelineStageFlags stageMask);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdWaitEvents(VkCommandBuffer commandBuffer, uint32_t @eventCount, VkEvent* pEvents, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, uint32_t memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint32_t bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint32_t imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdPipelineBarrier(VkCommandBuffer commandBuffer, VkPipelineStageFlags srcStageMask, VkPipelineStageFlags dstStageMask, VkDependencyFlags dependencyFlags, uint32_t memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint32_t bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint32_t imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdBeginQuery(VkCommandBuffer commandBuffer, VkQueryPool queryPool, uint32_t query, VkQueryControlFlags flags);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdEndQuery(VkCommandBuffer commandBuffer, VkQueryPool queryPool, uint32_t query);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdResetQueryPool(VkCommandBuffer commandBuffer, VkQueryPool queryPool, uint32_t firstQuery, uint32_t queryCount);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdWriteTimestamp(VkCommandBuffer commandBuffer, VkPipelineStageFlagBits pipelineStage, VkQueryPool queryPool, uint32_t query);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdCopyQueryPoolResults(VkCommandBuffer commandBuffer, VkQueryPool queryPool, uint32_t firstQuery, uint32_t queryCount, VkBuffer dstBuffer, VkDeviceSize dstOffset, VkDeviceSize stride, VkQueryResultFlags flags);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdPushConstants(VkCommandBuffer commandBuffer, VkPipelineLayout layout, VkShaderStageFlags stageFlags, uint32_t offset, uint32_t size, void* pValues);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdBeginRenderPass(VkCommandBuffer commandBuffer, VkRenderPassBeginInfo* pRenderPassBegin, VkSubpassContents contents);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdNextSubpass(VkCommandBuffer commandBuffer, VkSubpassContents contents);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdEndRenderPass(VkCommandBuffer commandBuffer);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdExecuteCommands(VkCommandBuffer commandBuffer, uint32_t commandBufferCount, VkCommandBuffer* pCommandBuffers);

#endregion

	#region VK_VERSION_1_1 

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkEnumerateInstanceVersion(uint32_t* pApiVersion);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]

	internal static unsafe partial VkResult vkBindBufferMemory2(VkDevice device, uint32_t bindInfoCount, VkBindBufferMemoryInfo* pBindInfos);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkBindImageMemory2(VkDevice device, uint32_t bindInfoCount, VkBindImageMemoryInfo* pBindInfos);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetDeviceGroupPeerMemoryFeatures(VkDevice device, uint32_t heapIndex, uint32_t localDeviceIndex, uint32_t remoteDeviceIndex, VkPeerMemoryFeatureFlags* pPeerMemoryFeatures);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetDeviceMask(VkCommandBuffer commandBuffer, uint32_t deviceMask);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdDispatchBase(VkCommandBuffer commandBuffer, uint32_t baseGroupX, uint32_t baseGroupY, uint32_t baseGroupZ, uint32_t groupCountX, uint32_t groupCountY, uint32_t groupCountZ);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkEnumeratePhysicalDeviceGroups(VkInstance instance, uint32_t* pPhysicalDeviceGroupCount, VkPhysicalDeviceGroupProperties* pPhysicalDeviceGroupProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetImageMemoryRequirements2(VkDevice device, VkImageMemoryRequirementsInfo2* pInfo, VkMemoryRequirements2* pMemoryRequirements);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetBufferMemoryRequirements2(VkDevice device, VkBufferMemoryRequirementsInfo2* pInfo, VkMemoryRequirements2* pMemoryRequirements);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetImageSparseMemoryRequirements2(VkDevice device, VkImageSparseMemoryRequirementsInfo2* pInfo, uint32_t* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2* pSparseMemoryRequirements);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPhysicalDeviceFeatures2(VkPhysicalDevice physicalDevice, VkPhysicalDeviceFeatures2* pFeatures);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPhysicalDeviceProperties2(VkPhysicalDevice physicalDevice, VkPhysicalDeviceProperties2* pProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPhysicalDeviceFormatProperties2(VkPhysicalDevice physicalDevice, VkFormat format, VkFormatProperties2* pFormatProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkGetPhysicalDeviceImageFormatProperties2(VkPhysicalDevice physicalDevice, VkPhysicalDeviceImageFormatInfo2* pImageFormatInfo, VkImageFormatProperties2* pImageFormatProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPhysicalDeviceQueueFamilyProperties2(VkPhysicalDevice physicalDevice, uint32_t* pQueueFamilyPropertyCount, VkQueueFamilyProperties2* pQueueFamilyProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPhysicalDeviceMemoryProperties2(VkPhysicalDevice physicalDevice, VkPhysicalDeviceMemoryProperties2* pMemoryProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPhysicalDeviceSparseImageFormatProperties2(VkPhysicalDevice physicalDevice, VkPhysicalDeviceSparseImageFormatInfo2* pFormatInfo, uint32_t* pPropertyCount, VkSparseImageFormatProperties2* pProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkTrimCommandPool(VkDevice device, VkCommandPool commandPool, VkCommandPoolTrimFlags flags);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetDeviceQueue2(VkDevice device, VkDeviceQueueInfo2* pQueueInfo, VkQueue* pQueue);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateSamplerYcbcrConversion(VkDevice device, VkSamplerYcbcrConversionCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkSamplerYcbcrConversion* pYcbcrConversion);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroySamplerYcbcrConversion(VkDevice device, VkSamplerYcbcrConversion ycbcrConversion, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateDescriptorUpdateTemplate(VkDevice device, VkDescriptorUpdateTemplateCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkDescriptorUpdateTemplate* pDescriptorUpdateTemplate);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyDescriptorUpdateTemplate(VkDevice device, VkDescriptorUpdateTemplate descriptorUpdateTemplate, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkUpdateDescriptorSetWithTemplate(VkDevice device, VkDescriptorSet descriptorSet, VkDescriptorUpdateTemplate descriptorUpdateTemplate, void* pData);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPhysicalDeviceExternalBufferProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceExternalBufferInfo* pExternalBufferInfo, VkExternalBufferProperties* pExternalBufferProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPhysicalDeviceExternalFenceProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceExternalFenceInfo* pExternalFenceInfo, VkExternalFenceProperties* pExternalFenceProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPhysicalDeviceExternalSemaphoreProperties(VkPhysicalDevice physicalDevice, VkPhysicalDeviceExternalSemaphoreInfo* pExternalSemaphoreInfo, VkExternalSemaphoreProperties* pExternalSemaphoreProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetDescriptorSetLayoutSupport(VkDevice device, VkDescriptorSetLayoutCreateInfo* pCreateInfo, VkDescriptorSetLayoutSupport* pSupport);

	#endregion

	#region VK_VERSION_1_2
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdDrawIndirectCount(VkCommandBuffer commandBuffer, VkBuffer buffer, VkDeviceSize offset, VkBuffer countBuffer, VkDeviceSize countBufferOffset, uint32_t maxDrawCount, uint32_t stride);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdDrawIndexedIndirectCount(VkCommandBuffer commandBuffer, VkBuffer buffer, VkDeviceSize offset, VkBuffer countBuffer, VkDeviceSize countBufferOffset, uint32_t maxDrawCount, uint32_t stride);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreateRenderPass2(VkDevice device, VkRenderPassCreateInfo2* pCreateInfo, VkAllocationCallbacks* pAllocator, VkRenderPass* pRenderPass);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdBeginRenderPass2(VkCommandBuffer commandBuffer, VkRenderPassBeginInfo* pRenderPassBegin, VkSubpassBeginInfo* pSubpassBeginInfo);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdNextSubpass2(VkCommandBuffer commandBuffer, VkSubpassBeginInfo* pSubpassBeginInfo, VkSubpassEndInfo* pSubpassEndInfo);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdEndRenderPass2(VkCommandBuffer commandBuffer, VkSubpassEndInfo* pSubpassEndInfo);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkResetQueryPool(VkDevice device, VkQueryPool queryPool, uint32_t firstQuery, uint32_t queryCount);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkGetSemaphoreCounterValue(VkDevice device, VkSemaphore semaphore, uint64_t* pValue);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkWaitSemaphores(VkDevice device, VkSemaphoreWaitInfo* pWaitInfo, uint64_t timeout);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkSignalSemaphore(VkDevice device, VkSemaphoreSignalInfo* pSignalInfo);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkDeviceAddress vkGetBufferDeviceAddress(VkDevice device, VkBufferDeviceAddressInfo* pInfo);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial uint64_t vkGetBufferOpaqueCaptureAddress(VkDevice device, VkBufferDeviceAddressInfo* pInfo);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial uint64_t vkGetDeviceMemoryOpaqueCaptureAddress(VkDevice device, VkDeviceMemoryOpaqueCaptureAddressInfo* pInfo);

	#endregion

	#region VK_VERSION_1_3

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkGetPhysicalDeviceToolProperties(VkPhysicalDevice physicalDevice, uint32_t* pToolCount, VkPhysicalDeviceToolProperties* pToolProperties);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCreatePrivateDataSlot(VkDevice device, VkPrivateDataSlotCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, VkPrivateDataSlot* pPrivateDataSlot);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkDestroyPrivateDataSlot(VkDevice device, VkPrivateDataSlot privateDataSlot, VkAllocationCallbacks* pAllocator);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkSetPrivateData(VkDevice device, VkObjectType @objectType, uint64_t @objectHandle, VkPrivateDataSlot privateDataSlot, uint64_t data);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetPrivateData(VkDevice device, VkObjectType @objectType, uint64_t @objectHandle, VkPrivateDataSlot privateDataSlot, uint64_t* pData);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetEvent2(VkCommandBuffer commandBuffer, VkEvent @event, VkDependencyInfo* pDependencyInfo);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdResetEvent2(VkCommandBuffer commandBuffer, VkEvent @event, VkPipelineStageFlags2 stageMask);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdWaitEvents2(VkCommandBuffer commandBuffer, uint32_t @eventCount, VkEvent* pEvents, VkDependencyInfo* pDependencyInfos);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdPipelineBarrier2(VkCommandBuffer commandBuffer, VkDependencyInfo* pDependencyInfo);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdWriteTimestamp2(VkCommandBuffer commandBuffer, VkPipelineStageFlags2 stage, VkQueryPool queryPool, uint32_t query);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkQueueSubmit2(VkQueue queue, uint32_t submitCount, VkSubmitInfo2* pSubmits, VkFence fence);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdCopyBuffer2(VkCommandBuffer commandBuffer, VkCopyBufferInfo2* pCopyBufferInfo);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdCopyImage2(VkCommandBuffer commandBuffer, VkCopyImageInfo2* pCopyImageInfo);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdCopyBufferToImage2(VkCommandBuffer commandBuffer, VkCopyBufferToImageInfo2* pCopyBufferToImageInfo);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdCopyImageToBuffer2(VkCommandBuffer commandBuffer, VkCopyImageToBufferInfo2* pCopyImageToBufferInfo);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdBlitImage2(VkCommandBuffer commandBuffer, VkBlitImageInfo2* pBlitImageInfo);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdResolveImage2(VkCommandBuffer commandBuffer, VkResolveImageInfo2* pResolveImageInfo);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdBeginRendering(VkCommandBuffer commandBuffer, VkRenderingInfo* pRenderingInfo);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdEndRendering(VkCommandBuffer commandBuffer);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetCullMode(VkCommandBuffer commandBuffer, VkCullModeFlags cullMode);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetFrontFace(VkCommandBuffer commandBuffer, VkFrontFace frontFace);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetPrimitiveTopology(VkCommandBuffer commandBuffer, VkPrimitiveTopology primitiveTopology);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetViewportWithCount(VkCommandBuffer commandBuffer, uint32_t viewportCount, VkViewport* pViewports);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetScissorWithCount(VkCommandBuffer commandBuffer, uint32_t scissorCount, VkRect2D* pScissors);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdBindVertexBuffers2(VkCommandBuffer commandBuffer, uint32_t firstBinding, uint32_t bindingCount, VkBuffer* pBuffers, VkDeviceSize* pOffsets, VkDeviceSize* pSizes, VkDeviceSize* pStrides);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetDepthTestEnable(VkCommandBuffer commandBuffer, VkBool32 depthTestEnable);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetDepthWriteEnable(VkCommandBuffer commandBuffer, VkBool32 depthWriteEnable);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetDepthCompareOp(VkCommandBuffer commandBuffer, VkCompareOp depthCompareOp);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetDepthBoundsTestEnable(VkCommandBuffer commandBuffer, VkBool32 depthBoundsTestEnable);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetStencilTestEnable(VkCommandBuffer commandBuffer, VkBool32 stencilTestEnable);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetStencilOp(VkCommandBuffer commandBuffer, VkStencilFaceFlags faceMask, VkStencilOp failOp, VkStencilOp passOp, VkStencilOp depthFailOp, VkCompareOp compareOp);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetRasterizerDiscardEnable(VkCommandBuffer commandBuffer, VkBool32 rasterizerDiscardEnable);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetDepthBiasEnable(VkCommandBuffer commandBuffer, VkBool32 depthBiasEnable);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetPrimitiveRestartEnable(VkCommandBuffer commandBuffer, VkBool32 primitiveRestartEnable);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetDeviceBufferMemoryRequirements(VkDevice device, VkDeviceBufferMemoryRequirements* pInfo, VkMemoryRequirements2* pMemoryRequirements);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetDeviceImageMemoryRequirements(VkDevice device, VkDeviceImageMemoryRequirements* pInfo, VkMemoryRequirements2* pMemoryRequirements);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetDeviceImageSparseMemoryRequirements(VkDevice device, VkDeviceImageMemoryRequirements* pInfo, uint32_t* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2* pSparseMemoryRequirements);

	#endregion

	#region VK_VERSION_1_4

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetLineStipple(VkCommandBuffer commandBuffer, uint32_t lineStippleFactor, uint16_t lineStipplePattern);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkMapMemory2(VkDevice device, VkMemoryMapInfo* pMemoryMapInfo, void** ppData);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkUnmapMemory2(VkDevice device, VkMemoryUnmapInfo* pMemoryUnmapInfo);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdBindIndexBuffer2(VkCommandBuffer commandBuffer, VkBuffer buffer, VkDeviceSize offset, VkDeviceSize size, VkIndexType indexType);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetRenderingAreaGranularity(VkDevice device, VkRenderingAreaInfo* pRenderingAreaInfo, VkExtent2D* pGranularity);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetDeviceImageSubresourceLayout(VkDevice device, VkDeviceImageSubresourceInfo* pInfo, VkSubresourceLayout2* pLayout);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkGetImageSubresourceLayout2(VkDevice device, VkImage image, VkImageSubresource2* pSubresource, VkSubresourceLayout2* pLayout);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdPushDescriptorSet(VkCommandBuffer commandBuffer, VkPipelineBindPoint pipelineBindPoint, VkPipelineLayout layout, uint32_t set, uint32_t descriptorWriteCount, VkWriteDescriptorSet* pDescriptorWrites);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdPushDescriptorSetWithTemplate(VkCommandBuffer commandBuffer, VkDescriptorUpdateTemplate descriptorUpdateTemplate, VkPipelineLayout layout, uint32_t set, void* pData);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetRenderingAttachmentLocations(VkCommandBuffer commandBuffer, VkRenderingAttachmentLocationInfo* pLocationInfo);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdSetRenderingInputAttachmentIndices(VkCommandBuffer commandBuffer, VkRenderingInputAttachmentIndexInfo* pInputAttachmentIndexInfo);
	
	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdBindDescriptorSets2(VkCommandBuffer commandBuffer, VkBindDescriptorSetsInfo* pBindDescriptorSetsInfo);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdPushConstants2(VkCommandBuffer commandBuffer, VkPushConstantsInfo* pPushConstantsInfo);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdPushDescriptorSet2(VkCommandBuffer commandBuffer, VkPushDescriptorSetInfo* pPushDescriptorSetInfo);


	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial void vkCmdPushDescriptorSetWithTemplate2(VkCommandBuffer commandBuffer, VkPushDescriptorSetWithTemplateInfo* pPushDescriptorSetWithTemplateInfo);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCopyMemoryToImage(VkDevice device, VkCopyMemoryToImageInfo* pCopyMemoryToImageInfo);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCopyImageToMemory(VkDevice device, VkCopyImageToMemoryInfo* pCopyImageToMemoryInfo);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkCopyImageToImage(VkDevice device, VkCopyImageToImageInfo* pCopyImageToImageInfo);

	[LibraryImport(Vulkan, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static unsafe partial VkResult vkTransitionImageLayout(VkDevice device, uint32_t transitionCount, VkHostImageLayoutTransitionInfo* pTransitions);

    #endregion
    
	// VK_KHR_surface
    public static /* readonly */  delegate* unmanaged<VkInstance, VkSurfaceKHR, VkAllocationCallbacks*, void> vkDestroySurfaceKHR = null;
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t, VkSurfaceKHR, VkBool32*, VkResult> vkGetPhysicalDeviceSurfaceSupportKHR = null;
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkSurfaceKHR, VkSurfaceCapabilitiesKHR*, VkResult> vkGetPhysicalDeviceSurfaceCapabilitiesKHR = null;
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkSurfaceKHR, uint32_t*, VkSurfaceFormatKHR*, VkResult> vkGetPhysicalDeviceSurfaceFormatsKHR = null;
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkSurfaceKHR, uint32_t*, VkPresentModeKHR*, VkResult> vkGetPhysicalDeviceSurfacePresentModesKHR = null;
    // VK_KHR_swapchain
    public static /* readonly */  delegate* unmanaged<VkDevice, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult> vkCreateSwapchainKHR = null;
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSwapchainKHR, VkAllocationCallbacks*, void> vkDestroySwapchainKHR = null;
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSwapchainKHR, uint32_t*, VkImage*, VkResult> vkGetSwapchainImagesKHR = null;
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSwapchainKHR, uint64_t, VkSemaphore, VkFence, uint32_t*, VkResult> vkAcquireNextImageKHR = null;
	public static /* readonly */  delegate* unmanaged<VkQueue, VkPresentInfoKHR*, VkResult> vkQueuePresentKHR = null;
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeviceGroupPresentCapabilitiesKHR*, VkResult> vkGetDeviceGroupPresentCapabilitiesKHR = null;
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSurfaceKHR, VkDeviceGroupPresentModeFlagsKHR*, VkResult> vkGetDeviceGroupSurfacePresentModesKHR = null;
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkSurfaceKHR, uint32_t*, VkRect2D*, VkResult> vkGetPhysicalDevicePresentRectanglesKHR = null;
	public static /* readonly */  delegate* unmanaged<VkDevice, VkAcquireNextImageInfoKHR*, uint32_t*, VkResult> vkAcquireNextImage2KHR = null;
	// VK_KHR_display
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkDisplayPropertiesKHR*, VkResult> vkGetPhysicalDeviceDisplayPropertiesKHR = null;
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkDisplayPlanePropertiesKHR*, VkResult> vkGetPhysicalDeviceDisplayPlanePropertiesKHR = null;
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t, uint32_t*, VkDisplayKHR*, VkResult> vkGetDisplayPlaneSupportedDisplaysKHR = null;
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkDisplayKHR, uint32_t*, VkDisplayModePropertiesKHR*, VkResult> vkGetDisplayModePropertiesKHR = null;
	// VK_KHR_display
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkDisplayKHR, VkDisplayModeCreateInfoKHR*, VkAllocationCallbacks*, VkDisplayModeKHR*, VkResult> vkCreateDisplayModeKHR = null;
	// VK_KHR_display
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkDisplayModeKHR, uint32_t, VkDisplayPlaneCapabilitiesKHR*, VkResult> vkGetDisplayPlaneCapabilitiesKHR = null;
	// VK_KHR_display
	public static /* readonly */  delegate* unmanaged<VkInstance, VkDisplaySurfaceCreateInfoKHR*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult> vkCreateDisplayPlaneSurfaceKHR = null;
	// VK_KHR_display_swapchain
	public static /* readonly */  delegate* unmanaged<VkDevice, uint32_t, VkSwapchainCreateInfoKHR*, VkAllocationCallbacks*, VkSwapchainKHR*, VkResult> vkCreateSharedSwapchainsKHR = null;
	// VK_KHR_video_queue
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkVideoProfileInfoKHR*, VkVideoCapabilitiesKHR*, VkResult> vkGetPhysicalDeviceVideoCapabilitiesKHR = null;
	// VK_KHR_video_queue
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceVideoFormatInfoKHR*, uint32_t*, VkVideoFormatPropertiesKHR*, VkResult> vkGetPhysicalDeviceVideoFormatPropertiesKHR = null;
	// VK_KHR_video_queue
	public static /* readonly */  delegate* unmanaged<VkDevice, VkVideoSessionCreateInfoKHR*, VkAllocationCallbacks*, VkVideoSessionKHR*, VkResult> vkCreateVideoSessionKHR = null;
	// VK_KHR_video_queue
	public static /* readonly */  delegate* unmanaged<VkDevice, VkVideoSessionKHR, VkAllocationCallbacks*, void> vkDestroyVideoSessionKHR = null;
	// VK_KHR_video_queue
	public static /* readonly */  delegate* unmanaged<VkDevice, VkVideoSessionKHR, uint32_t*, VkVideoSessionMemoryRequirementsKHR*, VkResult> vkGetVideoSessionMemoryRequirementsKHR = null;
	// VK_KHR_video_queue
	public static /* readonly */  delegate* unmanaged<VkDevice, VkVideoSessionKHR, uint32_t, VkBindVideoSessionMemoryInfoKHR*, VkResult> vkBindVideoSessionMemoryKHR = null;
	// VK_KHR_video_queue
	public static /* readonly */  delegate* unmanaged<VkDevice, VkVideoSessionParametersCreateInfoKHR*, VkAllocationCallbacks*, VkVideoSessionParametersKHR*, VkResult> vkCreateVideoSessionParametersKHR = null;
	// VK_KHR_video_queue
	public static /* readonly */  delegate* unmanaged<VkDevice, VkVideoSessionParametersKHR, VkVideoSessionParametersUpdateInfoKHR*, VkResult> vkUpdateVideoSessionParametersKHR = null;
	// VK_KHR_video_queue
	public static /* readonly */  delegate* unmanaged<VkDevice, VkVideoSessionParametersKHR, VkAllocationCallbacks*, void> vkDestroyVideoSessionParametersKHR = null;
	// VK_KHR_video_queue
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkVideoBeginCodingInfoKHR*, void> vkCmdBeginVideoCodingKHR = null;
	// VK_KHR_video_queue
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkVideoEndCodingInfoKHR*, void> vkCmdEndVideoCodingKHR = null;
	// VK_KHR_video_queue
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkVideoCodingControlInfoKHR*, void> vkCmdControlVideoCodingKHR = null;
	// VK_KHR_video_decode_queue
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkVideoDecodeInfoKHR*, void> vkCmdDecodeVideoKHR = null;
	// VK_KHR_dynamic_rendering
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkRenderingInfo*, void> vkCmdBeginRenderingKHR = null;
	// VK_KHR_dynamic_rendering
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, void> vkCmdEndRenderingKHR = null;
	// VK_KHR_get_physical_device_properties2
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceFeatures2*, void> vkGetPhysicalDeviceFeatures2KHR = null;
	// VK_KHR_get_physical_device_properties2
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceProperties2*, void> vkGetPhysicalDeviceProperties2KHR = null;
	// VK_KHR_get_physical_device_properties2
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkFormat, VkFormatProperties2*, void> vkGetPhysicalDeviceFormatProperties2KHR = null;
	// VK_KHR_get_physical_device_properties2
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceImageFormatInfo2*, VkImageFormatProperties2*, VkResult> vkGetPhysicalDeviceImageFormatProperties2KHR = null;
	// VK_KHR_get_physical_device_properties2
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkQueueFamilyProperties2*, void> vkGetPhysicalDeviceQueueFamilyProperties2KHR = null;
	// VK_KHR_get_physical_device_properties2
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceMemoryProperties2*, void> vkGetPhysicalDeviceMemoryProperties2KHR = null;
	// VK_KHR_get_physical_device_properties2
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceSparseImageFormatInfo2*, uint32_t*, VkSparseImageFormatProperties2*, void> vkGetPhysicalDeviceSparseImageFormatProperties2KHR = null;
	// VK_KHR_device_group
	public static /* readonly */  delegate* unmanaged<VkDevice, uint32_t, uint32_t, uint32_t, VkPeerMemoryFeatureFlags*, void> vkGetDeviceGroupPeerMemoryFeaturesKHR = null;
	// VK_KHR_device_group
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, void> vkCmdSetDeviceMaskKHR = null;
	// VK_KHR_device_group
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, uint32_t, uint32_t, uint32_t, uint32_t, void> vkCmdDispatchBaseKHR = null;
	// VK_KHR_maintenance1
	public static /* readonly */  delegate* unmanaged<VkDevice, VkCommandPool, VkCommandPoolTrimFlags, void> vkTrimCommandPoolKHR = null;
	// VK_KHR_device_group_creation
	public static /* readonly */  delegate* unmanaged<VkInstance, uint32_t*, VkPhysicalDeviceGroupProperties*, VkResult> vkEnumeratePhysicalDeviceGroupsKHR = null;
	// VK_KHR_external_memory_capabilities
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceExternalBufferInfo*, VkExternalBufferProperties*, void> vkGetPhysicalDeviceExternalBufferPropertiesKHR = null;
	// VK_KHR_external_memory_fd
	public static /* readonly */  delegate* unmanaged<VkDevice, VkMemoryGetFdInfoKHR*, int*, VkResult> vkGetMemoryFdKHR = null;
	// VK_KHR_external_memory_fd
	public static /* readonly */  delegate* unmanaged<VkDevice, VkExternalMemoryHandleTypeFlagBits, int, VkMemoryFdPropertiesKHR*, VkResult> vkGetMemoryFdPropertiesKHR = null;
	// VK_KHR_external_semaphore_capabilities
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceExternalSemaphoreInfo*, VkExternalSemaphoreProperties*, void> vkGetPhysicalDeviceExternalSemaphorePropertiesKHR = null;
	// VK_KHR_external_semaphore_fd
	public static /* readonly */  delegate* unmanaged<VkDevice, VkImportSemaphoreFdInfoKHR*, VkResult> vkImportSemaphoreFdKHR = null;
	// VK_KHR_external_semaphore_fd
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSemaphoreGetFdInfoKHR*, int*, VkResult> vkGetSemaphoreFdKHR = null;
	// VK_KHR_push_descriptor
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint32_t, uint32_t, VkWriteDescriptorSet*, void> vkCmdPushDescriptorSetKHR = null;
	// VK_KHR_push_descriptor
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkDescriptorUpdateTemplate, VkPipelineLayout, uint32_t, void*, void> vkCmdPushDescriptorSetWithTemplateKHR = null;
	// VK_KHR_descriptor_update_template
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDescriptorUpdateTemplateCreateInfo*, VkAllocationCallbacks*, VkDescriptorUpdateTemplate*, VkResult> vkCreateDescriptorUpdateTemplateKHR = null;
	// VK_KHR_descriptor_update_template
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDescriptorUpdateTemplate, VkAllocationCallbacks*, void> vkDestroyDescriptorUpdateTemplateKHR = null;
	// VK_KHR_descriptor_update_template
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDescriptorSet, VkDescriptorUpdateTemplate, void*, void> vkUpdateDescriptorSetWithTemplateKHR = null;
	// VK_KHR_create_renderpass2
	public static /* readonly */  delegate* unmanaged<VkDevice, VkRenderPassCreateInfo2*, VkAllocationCallbacks*, VkRenderPass*, VkResult> vkCreateRenderPass2KHR = null;
	// VK_KHR_create_renderpass2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkRenderPassBeginInfo*, VkSubpassBeginInfo*, void> vkCmdBeginRenderPass2KHR = null;
	// VK_KHR_create_renderpass2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkSubpassBeginInfo*, VkSubpassEndInfo*, void> vkCmdNextSubpass2KHR = null;
	// VK_KHR_create_renderpass2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkSubpassEndInfo*, void> vkCmdEndRenderPass2KHR = null;
	// VK_KHR_shared_presentable_image
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSwapchainKHR, VkResult> vkGetSwapchainStatusKHR = null;
	// VK_KHR_external_fence_capabilities
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceExternalFenceInfo*, VkExternalFenceProperties*, void> vkGetPhysicalDeviceExternalFencePropertiesKHR = null;
	// VK_KHR_external_fence_fd
	public static /* readonly */  delegate* unmanaged<VkDevice, VkImportFenceFdInfoKHR*, VkResult> vkImportFenceFdKHR = null;
	// VK_KHR_external_fence_fd
	public static /* readonly */  delegate* unmanaged<VkDevice, VkFenceGetFdInfoKHR*, int*, VkResult> vkGetFenceFdKHR = null;
	// VK_KHR_performance_query
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t, uint32_t*, VkPerformanceCounterKHR*, VkPerformanceCounterDescriptionKHR*, VkResult> vkEnumeratePhysicalDeviceQueueFamilyPerformanceQueryCountersKHR = null;
	// VK_KHR_performance_query
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkQueryPoolPerformanceCreateInfoKHR*, uint32_t*, void> vkGetPhysicalDeviceQueueFamilyPerformanceQueryPassesKHR = null;
	// VK_KHR_performance_query
	public static /* readonly */  delegate* unmanaged<VkDevice, VkAcquireProfilingLockInfoKHR*, VkResult> vkAcquireProfilingLockKHR = null;
	// VK_KHR_performance_query
	public static /* readonly */  delegate* unmanaged<VkDevice, void> vkReleaseProfilingLockKHR = null;
	// VK_KHR_get_surface_capabilities2
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, VkSurfaceCapabilities2KHR*, VkResult> vkGetPhysicalDeviceSurfaceCapabilities2KHR = null;
	// VK_KHR_get_surface_capabilities2
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceSurfaceInfo2KHR*, uint32_t*, VkSurfaceFormat2KHR*, VkResult> vkGetPhysicalDeviceSurfaceFormats2KHR = null;
	// VK_KHR_get_display_properties2
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkDisplayProperties2KHR*, VkResult> vkGetPhysicalDeviceDisplayProperties2KHR = null;
	// VK_KHR_get_display_properties2
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkDisplayPlaneProperties2KHR*, VkResult> vkGetPhysicalDeviceDisplayPlaneProperties2KHR = null;
	// VK_KHR_get_display_properties2
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkDisplayKHR, uint32_t*, VkDisplayModeProperties2KHR*, VkResult> vkGetDisplayModeProperties2KHR = null;
	// VK_KHR_get_display_properties2
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkDisplayPlaneInfo2KHR*, VkDisplayPlaneCapabilities2KHR*, VkResult> vkGetDisplayPlaneCapabilities2KHR = null;
	// VK_KHR_get_memory_requirements2
	public static /* readonly */  delegate* unmanaged<VkDevice, VkImageMemoryRequirementsInfo2*, VkMemoryRequirements2*, void> vkGetImageMemoryRequirements2KHR = null;
	// VK_KHR_get_memory_requirements2
	public static /* readonly */  delegate* unmanaged<VkDevice, VkBufferMemoryRequirementsInfo2*, VkMemoryRequirements2*, void> vkGetBufferMemoryRequirements2KHR = null;
	// VK_KHR_get_memory_requirements2
	public static /* readonly */  delegate* unmanaged<VkDevice, VkImageSparseMemoryRequirementsInfo2*, uint32_t*, VkSparseImageMemoryRequirements2*, void> vkGetImageSparseMemoryRequirements2KHR = null;
	// VK_KHR_sampler_ycbcr_conversion
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSamplerYcbcrConversionCreateInfo*, VkAllocationCallbacks*, VkSamplerYcbcrConversion*, VkResult> vkCreateSamplerYcbcrConversionKHR = null;
	// VK_KHR_sampler_ycbcr_conversion
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSamplerYcbcrConversion, VkAllocationCallbacks*, void> vkDestroySamplerYcbcrConversionKHR = null;
	// VK_KHR_bind_memory2
	public static /* readonly */  delegate* unmanaged<VkDevice, uint32_t, VkBindBufferMemoryInfo*, VkResult> vkBindBufferMemory2KHR = null;
	// VK_KHR_bind_memory2
	public static /* readonly */  delegate* unmanaged<VkDevice, uint32_t, VkBindImageMemoryInfo*, VkResult> vkBindImageMemory2KHR = null;
	// VK_KHR_maintenance3
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDescriptorSetLayoutCreateInfo*, VkDescriptorSetLayoutSupport*, void> vkGetDescriptorSetLayoutSupportKHR = null;
	// VK_KHR_draw_indirect_count
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void> vkCmdDrawIndirectCountKHR = null;
	// VK_KHR_draw_indirect_count
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void> vkCmdDrawIndexedIndirectCountKHR = null;
	// VK_KHR_timeline_semaphore
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSemaphore, uint64_t*, VkResult> vkGetSemaphoreCounterValueKHR = null;
	// VK_KHR_timeline_semaphore
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSemaphoreWaitInfo*, uint64_t, VkResult> vkWaitSemaphoresKHR = null;
	// VK_KHR_timeline_semaphore
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSemaphoreSignalInfo*, VkResult> vkSignalSemaphoreKHR = null;
	// VK_KHR_fragment_shading_rate
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkPhysicalDeviceFragmentShadingRateKHR*, VkResult> vkGetPhysicalDeviceFragmentShadingRatesKHR = null;
	// VK_KHR_fragment_shading_rate
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkExtent2D*, VkFragmentShadingRateCombinerOpKHR, void> vkCmdSetFragmentShadingRateKHR = null;
	// VK_KHR_dynamic_rendering_local_read
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkRenderingAttachmentLocationInfo*, void> vkCmdSetRenderingAttachmentLocationsKHR = null;
	// VK_KHR_dynamic_rendering_local_read
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkRenderingInputAttachmentIndexInfo*, void> vkCmdSetRenderingInputAttachmentIndicesKHR = null;
	// VK_KHR_present_wait
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSwapchainKHR, uint64_t, uint64_t, VkResult> vkWaitForPresentKHR = null;
	// VK_KHR_buffer_device_address
	public static /* readonly */  delegate* unmanaged<VkDevice, VkBufferDeviceAddressInfo*, VkDeviceAddress> vkGetBufferDeviceAddressKHR = null;
	// VK_KHR_buffer_device_address
	public static /* readonly */  delegate* unmanaged<VkDevice, VkBufferDeviceAddressInfo*, uint64_t> vkGetBufferOpaqueCaptureAddressKHR = null;
	// VK_KHR_buffer_device_address
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeviceMemoryOpaqueCaptureAddressInfo*, uint64_t> vkGetDeviceMemoryOpaqueCaptureAddressKHR = null;
	// VK_KHR_deferred_host_operations
	public static /* readonly */  delegate* unmanaged<VkDevice, VkAllocationCallbacks*, VkDeferredOperationKHR*, VkResult> vkCreateDeferredOperationKHR = null;
	// VK_KHR_deferred_host_operations
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkAllocationCallbacks*, void> vkDestroyDeferredOperationKHR = null;
	// VK_KHR_deferred_host_operations
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeferredOperationKHR, uint32_t> vkGetDeferredOperationMaxConcurrencyKHR = null;
	// VK_KHR_deferred_host_operations
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkResult> vkGetDeferredOperationResultKHR = null;
	// VK_KHR_deferred_host_operations
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkResult> vkDeferredOperationJoinKHR = null;
	// VK_KHR_pipeline_executable_properties
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPipelineInfoKHR*, uint32_t*, VkPipelineExecutablePropertiesKHR*, VkResult> vkGetPipelineExecutablePropertiesKHR = null;
	// VK_KHR_pipeline_executable_properties
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPipelineExecutableInfoKHR*, uint32_t*, VkPipelineExecutableStatisticKHR*, VkResult> vkGetPipelineExecutableStatisticsKHR = null;
	// VK_KHR_pipeline_executable_properties
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPipelineExecutableInfoKHR*, uint32_t*, VkPipelineExecutableInternalRepresentationKHR*, VkResult> vkGetPipelineExecutableInternalRepresentationsKHR = null;
	// VK_KHR_map_memory2
	public static /* readonly */  delegate* unmanaged<VkDevice, VkMemoryMapInfo*, void**, VkResult> vkMapMemory2KHR = null;
	// VK_KHR_map_memory2
	public static /* readonly */  delegate* unmanaged<VkDevice, VkMemoryUnmapInfo*, VkResult> vkUnmapMemory2KHR = null;
	// VK_KHR_video_encode_queue
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkPhysicalDeviceVideoEncodeQualityLevelInfoKHR*, VkVideoEncodeQualityLevelPropertiesKHR*, VkResult> vkGetPhysicalDeviceVideoEncodeQualityLevelPropertiesKHR = null;
	// VK_KHR_video_encode_queue
	public static /* readonly */  delegate* unmanaged<VkDevice, VkVideoEncodeSessionParametersGetInfoKHR*, VkVideoEncodeSessionParametersFeedbackInfoKHR*, /* size_t* */ nuint , void*, VkResult> vkGetEncodedVideoSessionParametersKHR = null;
	// VK_KHR_video_encode_queue
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkVideoEncodeInfoKHR*, void> vkCmdEncodeVideoKHR = null;
	// VK_KHR_synchronization2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkEvent, VkDependencyInfo*, void> vkCmdSetEvent2KHR = null;
	// VK_KHR_synchronization2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkEvent, VkPipelineStageFlags2, void> vkCmdResetEvent2KHR = null;
	// VK_KHR_synchronization2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkEvent*, VkDependencyInfo*, void> vkCmdWaitEvents2KHR = null;
	// VK_KHR_synchronization2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkDependencyInfo*, void> vkCmdPipelineBarrier2KHR = null;
	// VK_KHR_synchronization2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPipelineStageFlags2, VkQueryPool, uint32_t, void> vkCmdWriteTimestamp2KHR = null;
	// VK_KHR_synchronization2
	public static /* readonly */  delegate* unmanaged<VkQueue, uint32_t, VkSubmitInfo2*, VkFence, VkResult> vkQueueSubmit2KHR = null;
	// VK_KHR_copy_commands2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCopyBufferInfo2*, void> vkCmdCopyBuffer2KHR = null;
	// VK_KHR_copy_commands2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCopyImageInfo2*, void> vkCmdCopyImage2KHR = null;
	// VK_KHR_copy_commands2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCopyBufferToImageInfo2*, void> vkCmdCopyBufferToImage2KHR = null;
	// VK_KHR_copy_commands2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCopyImageToBufferInfo2*, void> vkCmdCopyImageToBuffer2KHR = null;
	// VK_KHR_copy_commands2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBlitImageInfo2*, void> vkCmdBlitImage2KHR = null;
	// VK_KHR_copy_commands2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkResolveImageInfo2*, void> vkCmdResolveImage2KHR = null;
	// VK_KHR_ray_tracing_maintenance1
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkDeviceAddress, void> vkCmdTraceRaysIndirect2KHR = null;
	// VK_KHR_maintenance4
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeviceBufferMemoryRequirements*, VkMemoryRequirements2*, void> vkGetDeviceBufferMemoryRequirementsKHR = null;
	// VK_KHR_maintenance4
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeviceImageMemoryRequirements*, VkMemoryRequirements2*, void> vkGetDeviceImageMemoryRequirementsKHR = null;
	// VK_KHR_maintenance4
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeviceImageMemoryRequirements*, uint32_t*, VkSparseImageMemoryRequirements2*, void> vkGetDeviceImageSparseMemoryRequirementsKHR = null;
	// VK_KHR_maintenance5
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkDeviceSize, VkIndexType, void> vkCmdBindIndexBuffer2KHR = null;
	// VK_KHR_maintenance5
	public static /* readonly */  delegate* unmanaged<VkDevice, VkRenderingAreaInfo*, VkExtent2D*, void> vkGetRenderingAreaGranularityKHR = null;
	// VK_KHR_maintenance5
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeviceImageSubresourceInfo*, VkSubresourceLayout2*, void> vkGetDeviceImageSubresourceLayoutKHR = null;
	// VK_KHR_maintenance5
	public static /* readonly */  delegate* unmanaged<VkDevice, VkImage, VkImageSubresource2*, VkSubresourceLayout2*, void> vkGetImageSubresourceLayout2KHR = null;
	// VK_KHR_pipeline_binary
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPipelineBinaryCreateInfoKHR*, VkAllocationCallbacks*, VkPipelineBinaryHandlesInfoKHR*, VkResult> vkCreatePipelineBinariesKHR = null;
	// VK_KHR_pipeline_binary
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPipelineBinaryKHR, VkAllocationCallbacks*, void> vkDestroyPipelineBinaryKHR = null;
	// VK_KHR_pipeline_binary
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPipelineCreateInfoKHR*, VkPipelineBinaryKeyKHR*, VkResult> vkGetPipelineKeyKHR = null;
	// VK_KHR_pipeline_binary
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPipelineBinaryDataInfoKHR*, VkPipelineBinaryKeyKHR*, /* size_t* */ nuint , void*, VkResult> vkGetPipelineBinaryDataKHR = null;
	// VK_KHR_pipeline_binary
	public static /* readonly */  delegate* unmanaged<VkDevice, VkReleaseCapturedPipelineDataInfoKHR*, VkAllocationCallbacks*, VkResult> vkReleaseCapturedPipelineDataKHR = null;
	// VK_KHR_cooperative_matrix
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkCooperativeMatrixPropertiesKHR*, VkResult> vkGetPhysicalDeviceCooperativeMatrixPropertiesKHR = null;
	// VK_KHR_line_rasterization
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint16_t, void> vkCmdSetLineStippleKHR = null;
	// VK_KHR_calibrated_timestamps
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkTimeDomainKHR*, VkResult> vkGetPhysicalDeviceCalibrateableTimeDomainsKHR = null;
	// VK_KHR_calibrated_timestamps
	public static /* readonly */  delegate* unmanaged<VkDevice, uint32_t, VkCalibratedTimestampInfoKHR*, uint64_t*, uint64_t*, VkResult> vkGetCalibratedTimestampsKHR = null;
	// VK_KHR_maintenance6
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBindDescriptorSetsInfo*, void> vkCmdBindDescriptorSets2KHR = null;
	// VK_KHR_maintenance6
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPushConstantsInfo*, void> vkCmdPushConstants2KHR = null;
	// VK_KHR_maintenance6
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPushDescriptorSetInfo*, void> vkCmdPushDescriptorSet2KHR = null;
	// VK_KHR_maintenance6
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPushDescriptorSetWithTemplateInfo*, void> vkCmdPushDescriptorSetWithTemplate2KHR = null;
	// VK_KHR_maintenance6
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkSetDescriptorBufferOffsetsInfoEXT*, void> vkCmdSetDescriptorBufferOffsets2EXT = null;
	// VK_KHR_maintenance6
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBindDescriptorBufferEmbeddedSamplersInfoEXT*, void> vkCmdBindDescriptorBufferEmbeddedSamplers2EXT = null;
	// VK_EXT_debug_report
	public static /* readonly */  delegate* unmanaged<VkInstance, VkDebugReportCallbackCreateInfoEXT*, VkAllocationCallbacks*, VkDebugReportCallbackEXT*, VkResult> vkCreateDebugReportCallbackEXT = null;
	// VK_EXT_debug_report
	public static /* readonly */  delegate* unmanaged<VkInstance, VkDebugReportCallbackEXT, VkAllocationCallbacks*, void> vkDestroyDebugReportCallbackEXT = null;
	// VK_EXT_debug_report
	public static /* readonly */  delegate* unmanaged<VkInstance, VkDebugReportFlagsEXT, VkDebugReportObjectTypeEXT, uint64_t, /* size_t */ nuint , int32_t, ConstChar*, ConstChar*, void> vkDebugReportMessageEXT = null;
	// VK_EXT_debug_marker
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDebugMarkerObjectTagInfoEXT*, VkResult> vkDebugMarkerSetObjectTagEXT = null;
	// VK_EXT_debug_marker
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDebugMarkerObjectNameInfoEXT*, VkResult> vkDebugMarkerSetObjectNameEXT = null;
	// VK_EXT_debug_marker
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkDebugMarkerMarkerInfoEXT*, void> vkCmdDebugMarkerBeginEXT = null;
	// VK_EXT_debug_marker
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, void> vkCmdDebugMarkerEndEXT = null;
	// VK_EXT_debug_marker
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkDebugMarkerMarkerInfoEXT*, void> vkCmdDebugMarkerInsertEXT = null;
	// VK_EXT_transform_feedback
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBuffer*, VkDeviceSize*, VkDeviceSize*, void> vkCmdBindTransformFeedbackBuffersEXT = null;
	// VK_EXT_transform_feedback
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBuffer*, VkDeviceSize*, void> vkCmdBeginTransformFeedbackEXT = null;
	// VK_EXT_transform_feedback
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBuffer*, VkDeviceSize*, void> vkCmdEndTransformFeedbackEXT = null;
	// VK_EXT_transform_feedback
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkQueryPool, uint32_t, VkQueryControlFlags, uint32_t, void> vkCmdBeginQueryIndexedEXT = null;
	// VK_EXT_transform_feedback
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkQueryPool, uint32_t, uint32_t, void> vkCmdEndQueryIndexedEXT = null;
	// VK_EXT_transform_feedback
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void> vkCmdDrawIndirectByteCountEXT = null;
	// VK_NVX_binary_import
	public static /* readonly */  delegate* unmanaged<VkDevice, VkCuModuleCreateInfoNVX*, VkAllocationCallbacks*, VkCuModuleNVX*, VkResult> vkCreateCuModuleNVX = null;
	// VK_NVX_binary_import
	public static /* readonly */  delegate* unmanaged<VkDevice, VkCuFunctionCreateInfoNVX*, VkAllocationCallbacks*, VkCuFunctionNVX*, VkResult> vkCreateCuFunctionNVX = null;
	// VK_NVX_binary_import
	public static /* readonly */  delegate* unmanaged<VkDevice, VkCuModuleNVX, VkAllocationCallbacks*, void> vkDestroyCuModuleNVX = null;
	// VK_NVX_binary_import
	public static /* readonly */  delegate* unmanaged<VkDevice, VkCuFunctionNVX, VkAllocationCallbacks*, void> vkDestroyCuFunctionNVX = null;
	// VK_NVX_binary_import
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCuLaunchInfoNVX*, void> vkCmdCuLaunchKernelNVX = null;
	// VK_NVX_image_view_handle
	public static /* readonly */  delegate* unmanaged<VkDevice, VkImageViewHandleInfoNVX*, uint32_t> vkGetImageViewHandleNVX = null;
	// VK_NVX_image_view_handle
	public static /* readonly */  delegate* unmanaged<VkDevice, VkImageViewHandleInfoNVX*, uint64_t> vkGetImageViewHandle64NVX = null;
	// VK_NVX_image_view_handle
	public static /* readonly */  delegate* unmanaged<VkDevice, VkImageView, VkImageViewAddressPropertiesNVX*, VkResult> vkGetImageViewAddressNVX = null;
	// VK_AMD_draw_indirect_count
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void> vkCmdDrawIndirectCountAMD = null;
	// VK_AMD_draw_indirect_count
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void> vkCmdDrawIndexedIndirectCountAMD = null;
	// VK_AMD_shader_info
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPipeline, VkShaderStageFlagBits, VkShaderInfoTypeAMD, /* size_t* */ nuint , void*, VkResult> vkGetShaderInfoAMD = null;
	// VK_NV_external_memory_capabilities
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkFormat, VkImageType, VkImageTiling, VkImageUsageFlags, VkImageCreateFlags, VkExternalMemoryHandleTypeFlagsNV, VkExternalImageFormatPropertiesNV*, VkResult> vkGetPhysicalDeviceExternalImageFormatPropertiesNV = null;
	// VK_EXT_conditional_rendering
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkConditionalRenderingBeginInfoEXT*, void> vkCmdBeginConditionalRenderingEXT = null;
	// VK_EXT_conditional_rendering
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, void> vkCmdEndConditionalRenderingEXT = null;
	// VK_NV_clip_space_w_scaling
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkViewportWScalingNV*, void> vkCmdSetViewportWScalingNV = null;
	// VK_EXT_direct_mode_display
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkDisplayKHR, VkResult> vkReleaseDisplayEXT = null;
	// VK_EXT_display_surface_counter
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkSurfaceKHR, VkSurfaceCapabilities2EXT*, VkResult> vkGetPhysicalDeviceSurfaceCapabilities2EXT = null;
	// VK_EXT_display_control
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDisplayKHR, VkDisplayPowerInfoEXT*, VkResult> vkDisplayPowerControlEXT = null;
	// VK_EXT_display_control
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeviceEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult> vkRegisterDeviceEventEXT = null;
	// VK_EXT_display_control
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDisplayKHR, VkDisplayEventInfoEXT*, VkAllocationCallbacks*, VkFence*, VkResult> vkRegisterDisplayEventEXT = null;
	// VK_EXT_display_control
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSwapchainKHR, VkSurfaceCounterFlagBitsEXT, uint64_t*, VkResult> vkGetSwapchainCounterEXT = null;
	// VK_GOOGLE_display_timing
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSwapchainKHR, VkRefreshCycleDurationGOOGLE*, VkResult> vkGetRefreshCycleDurationGOOGLE = null;
	// VK_GOOGLE_display_timing
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSwapchainKHR, uint32_t*, VkPastPresentationTimingGOOGLE*, VkResult> vkGetPastPresentationTimingGOOGLE = null;
	// VK_EXT_discard_rectangles
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkRect2D*, void> vkCmdSetDiscardRectangleEXT = null;
	// VK_EXT_discard_rectangles
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetDiscardRectangleEnableEXT = null;
	// VK_EXT_discard_rectangles
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkDiscardRectangleModeEXT, void> vkCmdSetDiscardRectangleModeEXT = null;
	// VK_EXT_hdr_metadata
	public static /* readonly */  delegate* unmanaged<VkDevice, uint32_t, VkSwapchainKHR*, VkHdrMetadataEXT*, void> vkSetHdrMetadataEXT = null;
	// VK_EXT_debug_utils
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDebugUtilsObjectNameInfoEXT*, VkResult> vkSetDebugUtilsObjectNameEXT = null;
	// VK_EXT_debug_utils
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDebugUtilsObjectTagInfoEXT*, VkResult> vkSetDebugUtilsObjectTagEXT = null;
	// VK_EXT_debug_utils
	public static /* readonly */  delegate* unmanaged<VkQueue, VkDebugUtilsLabelEXT*, void> vkQueueBeginDebugUtilsLabelEXT = null;
	// VK_EXT_debug_utils
	public static /* readonly */  delegate* unmanaged<VkQueue, void> vkQueueEndDebugUtilsLabelEXT = null;
	// VK_EXT_debug_utils
	public static /* readonly */  delegate* unmanaged<VkQueue, VkDebugUtilsLabelEXT*, void> vkQueueInsertDebugUtilsLabelEXT = null;
	// VK_EXT_debug_utils
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkDebugUtilsLabelEXT*, void> vkCmdBeginDebugUtilsLabelEXT = null;
	// VK_EXT_debug_utils
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, void> vkCmdEndDebugUtilsLabelEXT = null;
	// VK_EXT_debug_utils
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkDebugUtilsLabelEXT*, void> vkCmdInsertDebugUtilsLabelEXT = null;
	// VK_EXT_debug_utils
	public static /* readonly */  delegate* unmanaged<VkInstance, VkDebugUtilsMessengerCreateInfoEXT*, VkAllocationCallbacks*, VkDebugUtilsMessengerEXT*, VkResult> vkCreateDebugUtilsMessengerEXT = null;
	// VK_EXT_debug_utils
	public static /* readonly */  delegate* unmanaged<VkInstance, VkDebugUtilsMessengerEXT, VkAllocationCallbacks*, void> vkDestroyDebugUtilsMessengerEXT = null;
	// VK_EXT_debug_utils
	public static /* readonly */  delegate* unmanaged<VkInstance, VkDebugUtilsMessageSeverityFlagBitsEXT, VkDebugUtilsMessageTypeFlagsEXT, VkDebugUtilsMessengerCallbackDataEXT*, void> vkSubmitDebugUtilsMessageEXT = null;
	// VK_EXT_sample_locations
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkSampleLocationsInfoEXT*, void> vkCmdSetSampleLocationsEXT = null;
	// VK_EXT_sample_locations
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkSampleCountFlagBits, VkMultisamplePropertiesEXT*, void> vkGetPhysicalDeviceMultisamplePropertiesEXT = null;
	// VK_EXT_image_drm_format_modifier
	public static /* readonly */  delegate* unmanaged<VkDevice, VkImage, VkImageDrmFormatModifierPropertiesEXT*, VkResult> vkGetImageDrmFormatModifierPropertiesEXT = null;
	// VK_EXT_validation_cache
	public static /* readonly */  delegate* unmanaged<VkDevice, VkValidationCacheCreateInfoEXT*, VkAllocationCallbacks*, VkValidationCacheEXT*, VkResult> vkCreateValidationCacheEXT = null;
	// VK_EXT_validation_cache
	public static /* readonly */  delegate* unmanaged<VkDevice, VkValidationCacheEXT, VkAllocationCallbacks*, void> vkDestroyValidationCacheEXT = null;
	// VK_EXT_validation_cache
	public static /* readonly */  delegate* unmanaged<VkDevice, VkValidationCacheEXT, uint32_t, VkValidationCacheEXT*, VkResult> vkMergeValidationCachesEXT = null;
	// VK_EXT_validation_cache
	public static /* readonly */  delegate* unmanaged<VkDevice, VkValidationCacheEXT, /* size_t* */ nuint , void*, VkResult> vkGetValidationCacheDataEXT = null;
	// VK_NV_shading_rate_image
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkImageView, VkImageLayout, void> vkCmdBindShadingRateImageNV = null;
	// VK_NV_shading_rate_image
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkShadingRatePaletteNV*, void> vkCmdSetViewportShadingRatePaletteNV = null;
	// VK_NV_shading_rate_image
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCoarseSampleOrderTypeNV, uint32_t, VkCoarseSampleOrderCustomNV*, void> vkCmdSetCoarseSampleOrderNV = null;
	// VK_NV_ray_tracing
	public static /* readonly */  delegate* unmanaged<VkDevice, VkAccelerationStructureCreateInfoNV*, VkAllocationCallbacks*, VkAccelerationStructureNV*, VkResult> vkCreateAccelerationStructureNV = null;
	// VK_NV_ray_tracing
	public static /* readonly */  delegate* unmanaged<VkDevice, VkAccelerationStructureNV, VkAllocationCallbacks*, void> vkDestroyAccelerationStructureNV = null;
	// VK_NV_ray_tracing
	public static /* readonly */  delegate* unmanaged<VkDevice, VkAccelerationStructureMemoryRequirementsInfoNV*, VkMemoryRequirements2KHR*, void> vkGetAccelerationStructureMemoryRequirementsNV = null;
	// VK_NV_ray_tracing
	public static /* readonly */  delegate* unmanaged<VkDevice, uint32_t, VkBindAccelerationStructureMemoryInfoNV*, VkResult> vkBindAccelerationStructureMemoryNV = null;
	// VK_NV_ray_tracing
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkAccelerationStructureInfoNV*, VkBuffer, VkDeviceSize, VkBool32, VkAccelerationStructureNV, VkAccelerationStructureNV, VkBuffer, VkDeviceSize, void> vkCmdBuildAccelerationStructureNV = null;
	// VK_NV_ray_tracing
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkAccelerationStructureNV, VkAccelerationStructureNV, VkCopyAccelerationStructureModeKHR, void> vkCmdCopyAccelerationStructureNV = null;
	// VK_NV_ray_tracing
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, VkDeviceSize, VkBuffer, VkDeviceSize, VkDeviceSize, VkBuffer, VkDeviceSize, VkDeviceSize, uint32_t, uint32_t, uint32_t, void> vkCmdTraceRaysNV = null;
	// VK_NV_ray_tracing
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPipelineCache, uint32_t, VkRayTracingPipelineCreateInfoNV*, VkAllocationCallbacks*, VkPipeline*, VkResult> vkCreateRayTracingPipelinesNV = null;
	// VK_NV_ray_tracing
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPipeline, uint32_t, uint32_t, /* size_t */ nuint , void*, VkResult> vkGetRayTracingShaderGroupHandlesKHR = null;
	// VK_NV_ray_tracing
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPipeline, uint32_t, uint32_t, /* size_t */ nuint , void*, VkResult> vkGetRayTracingShaderGroupHandlesNV = null;
	// VK_NV_ray_tracing
	public static /* readonly */  delegate* unmanaged<VkDevice, VkAccelerationStructureNV, /* size_t */ nuint , void*, VkResult> vkGetAccelerationStructureHandleNV = null;
	// VK_NV_ray_tracing
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkAccelerationStructureNV*, VkQueryType, VkQueryPool, uint32_t, void> vkCmdWriteAccelerationStructuresPropertiesNV = null;
	// VK_NV_ray_tracing
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPipeline, uint32_t, VkResult> vkCompileDeferredNV = null;
	// VK_EXT_external_memory_host
	public static /* readonly */  delegate* unmanaged<VkDevice, VkExternalMemoryHandleTypeFlagBits, void*, VkMemoryHostPointerPropertiesEXT*, VkResult> vkGetMemoryHostPointerPropertiesEXT = null;
	// VK_AMD_buffer_marker
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPipelineStageFlagBits, VkBuffer, VkDeviceSize, uint32_t, void> vkCmdWriteBufferMarkerAMD = null;
	// VK_AMD_buffer_marker
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPipelineStageFlags2, VkBuffer, VkDeviceSize, uint32_t, void> vkCmdWriteBufferMarker2AMD = null;
	// VK_EXT_calibrated_timestamps
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkTimeDomainKHR*, VkResult> vkGetPhysicalDeviceCalibrateableTimeDomainsEXT = null;
	// VK_EXT_calibrated_timestamps
	public static /* readonly */  delegate* unmanaged<VkDevice, uint32_t, VkCalibratedTimestampInfoKHR*, uint64_t*, uint64_t*, VkResult> vkGetCalibratedTimestampsEXT = null;
	// VK_NV_mesh_shader
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, void> vkCmdDrawMeshTasksNV = null;
	// VK_NV_mesh_shader
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void> vkCmdDrawMeshTasksIndirectNV = null;
	// VK_NV_mesh_shader
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void> vkCmdDrawMeshTasksIndirectCountNV = null;
	// VK_NV_scissor_exclusive
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBool32*, void> vkCmdSetExclusiveScissorEnableNV = null;
	// VK_NV_scissor_exclusive
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkRect2D*, void> vkCmdSetExclusiveScissorNV = null;
	// VK_NV_device_diagnostic_checkpoints
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, void*, void> vkCmdSetCheckpointNV = null;
	// VK_NV_device_diagnostic_checkpoints
	public static /* readonly */  delegate* unmanaged<VkQueue, uint32_t*, VkCheckpointDataNV*, void> vkGetQueueCheckpointDataNV = null;
	// VK_NV_device_diagnostic_checkpoints
	public static /* readonly */  delegate* unmanaged<VkQueue, uint32_t*, VkCheckpointData2NV*, void> vkGetQueueCheckpointData2NV = null;
	// VK_INTEL_performance_query
	public static /* readonly */  delegate* unmanaged<VkDevice, VkInitializePerformanceApiInfoINTEL*, VkResult> vkInitializePerformanceApiINTEL = null;
	// VK_INTEL_performance_query
	public static /* readonly */  delegate* unmanaged<VkDevice, void> vkUninitializePerformanceApiINTEL = null;
	// VK_INTEL_performance_query
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPerformanceMarkerInfoINTEL*, VkResult> vkCmdSetPerformanceMarkerINTEL = null;
	// VK_INTEL_performance_query
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPerformanceStreamMarkerInfoINTEL*, VkResult> vkCmdSetPerformanceStreamMarkerINTEL = null;
	// VK_INTEL_performance_query
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPerformanceOverrideInfoINTEL*, VkResult> vkCmdSetPerformanceOverrideINTEL = null;
	// VK_INTEL_performance_query
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPerformanceConfigurationAcquireInfoINTEL*, VkPerformanceConfigurationINTEL*, VkResult> vkAcquirePerformanceConfigurationINTEL = null;
	// VK_INTEL_performance_query
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPerformanceConfigurationINTEL, VkResult> vkReleasePerformanceConfigurationINTEL = null;
	// VK_INTEL_performance_query
	public static /* readonly */  delegate* unmanaged<VkQueue, VkPerformanceConfigurationINTEL, VkResult> vkQueueSetPerformanceConfigurationINTEL = null;
	// VK_INTEL_performance_query
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPerformanceParameterTypeINTEL, VkPerformanceValueINTEL*, VkResult> vkGetPerformanceParameterINTEL = null;
	// VK_AMD_display_native_hdr
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSwapchainKHR, VkBool32, void> vkSetLocalDimmingAMD = null;
	// VK_EXT_buffer_device_address
	public static /* readonly */  delegate* unmanaged<VkDevice, VkBufferDeviceAddressInfo*, VkDeviceAddress> vkGetBufferDeviceAddressEXT = null;
	// VK_EXT_tooling_info
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkPhysicalDeviceToolProperties*, VkResult> vkGetPhysicalDeviceToolPropertiesEXT = null;
	// VK_NV_cooperative_matrix
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkCooperativeMatrixPropertiesNV*, VkResult> vkGetPhysicalDeviceCooperativeMatrixPropertiesNV = null;
	// VK_NV_coverage_reduction_mode
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkFramebufferMixedSamplesCombinationNV*, VkResult> vkGetPhysicalDeviceSupportedFramebufferMixedSamplesCombinationsNV = null;
	// VK_EXT_headless_surface
	public static /* readonly */  delegate* unmanaged<VkInstance, VkHeadlessSurfaceCreateInfoEXT*, VkAllocationCallbacks*, VkSurfaceKHR*, VkResult> vkCreateHeadlessSurfaceEXT = null;
	// VK_EXT_line_rasterization
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint16_t, void> vkCmdSetLineStippleEXT = null;
	// VK_EXT_host_query_reset
	public static /* readonly */  delegate* unmanaged<VkDevice, VkQueryPool, uint32_t, uint32_t, void> vkResetQueryPoolEXT = null;
	// VK_EXT_extended_dynamic_state
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCullModeFlags, void> vkCmdSetCullModeEXT = null;
	// VK_EXT_extended_dynamic_state
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkFrontFace, void> vkCmdSetFrontFaceEXT = null;
	// VK_EXT_extended_dynamic_state
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPrimitiveTopology, void> vkCmdSetPrimitiveTopologyEXT = null;
	// VK_EXT_extended_dynamic_state
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkViewport*, void> vkCmdSetViewportWithCountEXT = null;
	// VK_EXT_extended_dynamic_state
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkRect2D*, void> vkCmdSetScissorWithCountEXT = null;
	// VK_EXT_extended_dynamic_state
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBuffer*, VkDeviceSize*, VkDeviceSize*, VkDeviceSize*, void> vkCmdBindVertexBuffers2EXT = null;
	// VK_EXT_extended_dynamic_state
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetDepthTestEnableEXT = null;
	// VK_EXT_extended_dynamic_state
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetDepthWriteEnableEXT = null;
	// VK_EXT_extended_dynamic_state
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCompareOp, void> vkCmdSetDepthCompareOpEXT = null;
	// VK_EXT_extended_dynamic_state
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetDepthBoundsTestEnableEXT = null;
	// VK_EXT_extended_dynamic_state
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetStencilTestEnableEXT = null;
	// VK_EXT_extended_dynamic_state
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkStencilFaceFlags, VkStencilOp, VkStencilOp, VkStencilOp, VkCompareOp, void> vkCmdSetStencilOpEXT = null;
	// VK_EXT_host_image_copy
	public static /* readonly */  delegate* unmanaged<VkDevice, VkCopyMemoryToImageInfo*, VkResult> vkCopyMemoryToImageEXT = null;
	// VK_EXT_host_image_copy
	public static /* readonly */  delegate* unmanaged<VkDevice, VkCopyImageToMemoryInfo*, VkResult> vkCopyImageToMemoryEXT = null;
	// VK_EXT_host_image_copy
	public static /* readonly */  delegate* unmanaged<VkDevice, VkCopyImageToImageInfo*, VkResult> vkCopyImageToImageEXT = null;
	// VK_EXT_host_image_copy
	public static /* readonly */  delegate* unmanaged<VkDevice, uint32_t, VkHostImageLayoutTransitionInfo*, VkResult> vkTransitionImageLayoutEXT = null;
	// VK_EXT_host_image_copy
	public static /* readonly */  delegate* unmanaged<VkDevice, VkImage, VkImageSubresource2*, VkSubresourceLayout2*, void> vkGetImageSubresourceLayout2EXT = null;
	// VK_EXT_swapchain_maintenance1
	public static /* readonly */  delegate* unmanaged<VkDevice, VkReleaseSwapchainImagesInfoEXT*, VkResult> vkReleaseSwapchainImagesEXT = null;
	// VK_NV_device_generated_commands
	public static /* readonly */  delegate* unmanaged<VkDevice, VkGeneratedCommandsMemoryRequirementsInfoNV*, VkMemoryRequirements2*, void> vkGetGeneratedCommandsMemoryRequirementsNV = null;
	// VK_NV_device_generated_commands
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkGeneratedCommandsInfoNV*, void> vkCmdPreprocessGeneratedCommandsNV = null;
	// VK_NV_device_generated_commands
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, VkGeneratedCommandsInfoNV*, void> vkCmdExecuteGeneratedCommandsNV = null;
	// VK_NV_device_generated_commands
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPipelineBindPoint, VkPipeline, uint32_t, void> vkCmdBindPipelineShaderGroupNV = null;
	// VK_NV_device_generated_commands
	public static /* readonly */  delegate* unmanaged<VkDevice, VkIndirectCommandsLayoutCreateInfoNV*, VkAllocationCallbacks*, VkIndirectCommandsLayoutNV*, VkResult> vkCreateIndirectCommandsLayoutNV = null;
	// VK_NV_device_generated_commands
	public static /* readonly */  delegate* unmanaged<VkDevice, VkIndirectCommandsLayoutNV, VkAllocationCallbacks*, void> vkDestroyIndirectCommandsLayoutNV = null;
	// VK_EXT_depth_bias_control
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkDepthBiasInfoEXT*, void> vkCmdSetDepthBias2EXT = null;
	// VK_EXT_acquire_drm_display
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, int32_t, VkDisplayKHR, VkResult> vkAcquireDrmDisplayEXT = null;
	// VK_EXT_acquire_drm_display
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, int32_t, uint32_t, VkDisplayKHR*, VkResult> vkGetDrmDisplayEXT = null;
	// VK_EXT_private_data
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPrivateDataSlotCreateInfo*, VkAllocationCallbacks*, VkPrivateDataSlot*, VkResult> vkCreatePrivateDataSlotEXT = null;
	// VK_EXT_private_data
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPrivateDataSlot, VkAllocationCallbacks*, void> vkDestroyPrivateDataSlotEXT = null;
	// VK_EXT_private_data
	public static /* readonly */  delegate* unmanaged<VkDevice, VkObjectType, uint64_t, VkPrivateDataSlot, uint64_t, VkResult> vkSetPrivateDataEXT = null;
	// VK_EXT_private_data
	public static /* readonly */  delegate* unmanaged<VkDevice, VkObjectType, uint64_t, VkPrivateDataSlot, uint64_t*, void> vkGetPrivateDataEXT = null;
	// VK_NV_cuda_kernel_launch
	public static /* readonly */  delegate* unmanaged<VkDevice, VkCudaModuleCreateInfoNV*, VkAllocationCallbacks*, VkCudaModuleNV*, VkResult> vkCreateCudaModuleNV = null;
	// VK_NV_cuda_kernel_launch
	public static /* readonly */  delegate* unmanaged<VkDevice, VkCudaModuleNV, /* size_t* */ nuint , void*, VkResult> vkGetCudaModuleCacheNV = null;
	// VK_NV_cuda_kernel_launch
	public static /* readonly */  delegate* unmanaged<VkDevice, VkCudaFunctionCreateInfoNV*, VkAllocationCallbacks*, VkCudaFunctionNV*, VkResult> vkCreateCudaFunctionNV = null;
	// VK_NV_cuda_kernel_launch
	public static /* readonly */  delegate* unmanaged<VkDevice, VkCudaModuleNV, VkAllocationCallbacks*, void> vkDestroyCudaModuleNV = null;
	// VK_NV_cuda_kernel_launch
	public static /* readonly */  delegate* unmanaged<VkDevice, VkCudaFunctionNV, VkAllocationCallbacks*, void> vkDestroyCudaFunctionNV = null;
	// VK_NV_cuda_kernel_launch
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCudaLaunchInfoNV*, void> vkCmdCudaLaunchKernelNV = null;
	// VK_QCOM_tile_shading
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, void> vkCmdDispatchTileQCOM = null;
	// VK_QCOM_tile_shading
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPerTileBeginInfoQCOM*, void> vkCmdBeginPerTileExecutionQCOM = null;
	// VK_QCOM_tile_shading
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPerTileEndInfoQCOM*, void> vkCmdEndPerTileExecutionQCOM = null;
	// VK_EXT_descriptor_buffer
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDescriptorSetLayout, VkDeviceSize*, void> vkGetDescriptorSetLayoutSizeEXT = null;
	// VK_EXT_descriptor_buffer
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDescriptorSetLayout, uint32_t, VkDeviceSize*, void> vkGetDescriptorSetLayoutBindingOffsetEXT = null;
	// VK_EXT_descriptor_buffer
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDescriptorGetInfoEXT*, /* size_t */ nuint , void*, void> vkGetDescriptorEXT = null;
	// VK_EXT_descriptor_buffer
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkDescriptorBufferBindingInfoEXT*, void> vkCmdBindDescriptorBuffersEXT = null;
	// VK_EXT_descriptor_buffer
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint32_t, uint32_t, uint32_t*, VkDeviceSize*, void> vkCmdSetDescriptorBufferOffsetsEXT = null;
	// VK_EXT_descriptor_buffer
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPipelineBindPoint, VkPipelineLayout, uint32_t, void> vkCmdBindDescriptorBufferEmbeddedSamplersEXT = null;
	// VK_EXT_descriptor_buffer
	public static /* readonly */  delegate* unmanaged<VkDevice, VkBufferCaptureDescriptorDataInfoEXT*, void*, VkResult> vkGetBufferOpaqueCaptureDescriptorDataEXT = null;
	// VK_EXT_descriptor_buffer
	public static /* readonly */  delegate* unmanaged<VkDevice, VkImageCaptureDescriptorDataInfoEXT*, void*, VkResult> vkGetImageOpaqueCaptureDescriptorDataEXT = null;
	// VK_EXT_descriptor_buffer
	public static /* readonly */  delegate* unmanaged<VkDevice, VkImageViewCaptureDescriptorDataInfoEXT*, void*, VkResult> vkGetImageViewOpaqueCaptureDescriptorDataEXT = null;
	// VK_EXT_descriptor_buffer
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSamplerCaptureDescriptorDataInfoEXT*, void*, VkResult> vkGetSamplerOpaqueCaptureDescriptorDataEXT = null;
	// VK_EXT_descriptor_buffer
	public static /* readonly */  delegate* unmanaged<VkDevice, VkAccelerationStructureCaptureDescriptorDataInfoEXT*, void*, VkResult> vkGetAccelerationStructureOpaqueCaptureDescriptorDataEXT = null;
	// VK_NV_fragment_shading_rate_enums
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkFragmentShadingRateNV, VkFragmentShadingRateCombinerOpKHR, void> vkCmdSetFragmentShadingRateEnumNV = null;
	// VK_EXT_device_fault
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeviceFaultCountsEXT*, VkDeviceFaultInfoEXT*, VkResult> vkGetDeviceFaultInfoEXT = null;
	// VK_EXT_vertex_input_dynamic_state
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkVertexInputBindingDescription2EXT*, uint32_t, VkVertexInputAttributeDescription2EXT*, void> vkCmdSetVertexInputEXT = null;
	// VK_HUAWEI_subpass_shading
	public static /* readonly */  delegate* unmanaged<VkDevice, VkRenderPass, VkExtent2D*, VkResult> vkGetDeviceSubpassShadingMaxWorkgroupSizeHUAWEI = null;
	// VK_HUAWEI_subpass_shading
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, void> vkCmdSubpassShadingHUAWEI = null;
	// VK_HUAWEI_invocation_mask
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkImageView, VkImageLayout, void> vkCmdBindInvocationMaskHUAWEI = null;
	// VK_NV_external_memory_rdma
	public static /* readonly */  delegate* unmanaged<VkDevice, VkMemoryGetRemoteAddressInfoNV*, VkRemoteAddressNV*, VkResult> vkGetMemoryRemoteAddressNV = null;
	// VK_EXT_pipeline_properties
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPipelineInfoEXT*, VkBaseOutStructure*, VkResult> vkGetPipelinePropertiesEXT = null;
	// VK_EXT_extended_dynamic_state2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, void> vkCmdSetPatchControlPointsEXT = null;
	// VK_EXT_extended_dynamic_state2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetRasterizerDiscardEnableEXT = null;
	// VK_EXT_extended_dynamic_state2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetDepthBiasEnableEXT = null;
	// VK_EXT_extended_dynamic_state2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkLogicOp, void> vkCmdSetLogicOpEXT = null;
	// VK_EXT_extended_dynamic_state2
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetPrimitiveRestartEnableEXT = null;
	// VK_EXT_color_write_enable
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkBool32*, void> vkCmdSetColorWriteEnableEXT = null;
	// VK_EXT_multi_draw
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkMultiDrawInfoEXT*, uint32_t, uint32_t, uint32_t, void> vkCmdDrawMultiEXT = null;
	// VK_EXT_multi_draw
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkMultiDrawIndexedInfoEXT*, uint32_t, uint32_t, uint32_t, int32_t*, void> vkCmdDrawMultiIndexedEXT = null;
	// VK_EXT_opacity_micromap
	public static /* readonly */  delegate* unmanaged<VkDevice, VkMicromapCreateInfoEXT*, VkAllocationCallbacks*, VkMicromapEXT*, VkResult> vkCreateMicromapEXT = null;
	// VK_EXT_opacity_micromap
	public static /* readonly */  delegate* unmanaged<VkDevice, VkMicromapEXT, VkAllocationCallbacks*, void> vkDestroyMicromapEXT = null;
	// VK_EXT_opacity_micromap
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkMicromapBuildInfoEXT*, void> vkCmdBuildMicromapsEXT = null;
	// VK_EXT_opacity_micromap
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeferredOperationKHR, uint32_t, VkMicromapBuildInfoEXT*, VkResult> vkBuildMicromapsEXT = null;
	// VK_EXT_opacity_micromap
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyMicromapInfoEXT*, VkResult> vkCopyMicromapEXT = null;
	// VK_EXT_opacity_micromap
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyMicromapToMemoryInfoEXT*, VkResult> vkCopyMicromapToMemoryEXT = null;
	// VK_EXT_opacity_micromap
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyMemoryToMicromapInfoEXT*, VkResult> vkCopyMemoryToMicromapEXT = null;
	// VK_EXT_opacity_micromap
	public static /* readonly */  delegate* unmanaged<VkDevice, uint32_t, VkMicromapEXT*, VkQueryType, /* size_t */ nuint , void*, /* size_t */ nuint , VkResult> vkWriteMicromapsPropertiesEXT = null;
	// VK_EXT_opacity_micromap
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCopyMicromapInfoEXT*, void> vkCmdCopyMicromapEXT = null;
	// VK_EXT_opacity_micromap
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCopyMicromapToMemoryInfoEXT*, void> vkCmdCopyMicromapToMemoryEXT = null;
	// VK_EXT_opacity_micromap
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCopyMemoryToMicromapInfoEXT*, void> vkCmdCopyMemoryToMicromapEXT = null;
	// VK_EXT_opacity_micromap
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkMicromapEXT*, VkQueryType, VkQueryPool, uint32_t, void> vkCmdWriteMicromapsPropertiesEXT = null;
	// VK_EXT_opacity_micromap
	public static /* readonly */  delegate* unmanaged<VkDevice, VkMicromapVersionInfoEXT*, VkAccelerationStructureCompatibilityKHR*, void> vkGetDeviceMicromapCompatibilityEXT = null;
	// VK_EXT_opacity_micromap
	public static /* readonly */  delegate* unmanaged<VkDevice, VkAccelerationStructureBuildTypeKHR, VkMicromapBuildInfoEXT*, VkMicromapBuildSizesInfoEXT*, void> vkGetMicromapBuildSizesEXT = null;
	// VK_HUAWEI_cluster_culling_shader
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, uint32_t, void> vkCmdDrawClusterHUAWEI = null;
	// VK_HUAWEI_cluster_culling_shader
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, void> vkCmdDrawClusterIndirectHUAWEI = null;
	// VK_EXT_pageable_device_local_memory
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeviceMemory, float, void> vkSetDeviceMemoryPriorityEXT = null;
	// VK_VALVE_descriptor_set_host_mapping
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDescriptorSetBindingReferenceVALVE*, VkDescriptorSetLayoutHostMappingInfoVALVE*, void> vkGetDescriptorSetLayoutHostMappingInfoVALVE = null;
	// VK_VALVE_descriptor_set_host_mapping
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDescriptorSet, void**, void> vkGetDescriptorSetHostMappingVALVE = null;
	// VK_NV_copy_memory_indirect
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkDeviceAddress, uint32_t, uint32_t, void> vkCmdCopyMemoryIndirectNV = null;
	// VK_NV_copy_memory_indirect
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkDeviceAddress, uint32_t, uint32_t, VkImage, VkImageLayout, VkImageSubresourceLayers*, void> vkCmdCopyMemoryToImageIndirectNV = null;
	// VK_NV_memory_decompression
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkDecompressMemoryRegionNV*, void> vkCmdDecompressMemoryNV = null;
	// VK_NV_memory_decompression
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkDeviceAddress, VkDeviceAddress, uint32_t, void> vkCmdDecompressMemoryIndirectCountNV = null;
	// VK_NV_device_generated_commands_compute
	public static /* readonly */  delegate* unmanaged<VkDevice, VkComputePipelineCreateInfo*, VkMemoryRequirements2*, void> vkGetPipelineIndirectMemoryRequirementsNV = null;
	// VK_NV_device_generated_commands_compute
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPipelineBindPoint, VkPipeline, void> vkCmdUpdatePipelineIndirectBufferNV = null;
	// VK_NV_device_generated_commands_compute
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPipelineIndirectDeviceAddressInfoNV*, VkDeviceAddress> vkGetPipelineIndirectDeviceAddressNV = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetDepthClampEnableEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkPolygonMode, void> vkCmdSetPolygonModeEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkSampleCountFlagBits, void> vkCmdSetRasterizationSamplesEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkSampleCountFlagBits, VkSampleMask*, void> vkCmdSetSampleMaskEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetAlphaToCoverageEnableEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetAlphaToOneEnableEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetLogicOpEnableEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkBool32*, void> vkCmdSetColorBlendEnableEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkColorBlendEquationEXT*, void> vkCmdSetColorBlendEquationEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkColorComponentFlags*, void> vkCmdSetColorWriteMaskEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkTessellationDomainOrigin, void> vkCmdSetTessellationDomainOriginEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, void> vkCmdSetRasterizationStreamEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkConservativeRasterizationModeEXT, void> vkCmdSetConservativeRasterizationModeEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, float, void> vkCmdSetExtraPrimitiveOverestimationSizeEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetDepthClipEnableEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetSampleLocationsEnableEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkColorBlendAdvancedEXT*, void> vkCmdSetColorBlendAdvancedEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkProvokingVertexModeEXT, void> vkCmdSetProvokingVertexModeEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkLineRasterizationModeEXT, void> vkCmdSetLineRasterizationModeEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetLineStippleEnableEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetDepthClipNegativeOneToOneEXT = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetViewportWScalingEnableNV = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, VkViewportSwizzleNV*, void> vkCmdSetViewportSwizzleNV = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetCoverageToColorEnableNV = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, void> vkCmdSetCoverageToColorLocationNV = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCoverageModulationModeNV, void> vkCmdSetCoverageModulationModeNV = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetCoverageModulationTableEnableNV = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, float*, void> vkCmdSetCoverageModulationTableNV = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetShadingRateImageEnableNV = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, void> vkCmdSetRepresentativeFragmentTestEnableNV = null;
	// VK_EXT_extended_dynamic_state3
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCoverageReductionModeNV, void> vkCmdSetCoverageReductionModeNV = null;
	// VK_EXT_shader_module_identifier
	public static /* readonly */  delegate* unmanaged<VkDevice, VkShaderModule, VkShaderModuleIdentifierEXT*, void> vkGetShaderModuleIdentifierEXT = null;
	// VK_EXT_shader_module_identifier
	public static /* readonly */  delegate* unmanaged<VkDevice, VkShaderModuleCreateInfo*, VkShaderModuleIdentifierEXT*, void> vkGetShaderModuleCreateInfoIdentifierEXT = null;
	// VK_NV_optical_flow
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, VkOpticalFlowImageFormatInfoNV*, uint32_t*, VkOpticalFlowImageFormatPropertiesNV*, VkResult> vkGetPhysicalDeviceOpticalFlowImageFormatsNV = null;
	// VK_NV_optical_flow
	public static /* readonly */  delegate* unmanaged<VkDevice, VkOpticalFlowSessionCreateInfoNV*, VkAllocationCallbacks*, VkOpticalFlowSessionNV*, VkResult> vkCreateOpticalFlowSessionNV = null;
	// VK_NV_optical_flow
	public static /* readonly */  delegate* unmanaged<VkDevice, VkOpticalFlowSessionNV, VkAllocationCallbacks*, void> vkDestroyOpticalFlowSessionNV = null;
	// VK_NV_optical_flow
	public static /* readonly */  delegate* unmanaged<VkDevice, VkOpticalFlowSessionNV, VkOpticalFlowSessionBindingPointNV, VkImageView, VkImageLayout, VkResult> vkBindOpticalFlowSessionImageNV = null;
	// VK_NV_optical_flow
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkOpticalFlowSessionNV, VkOpticalFlowExecuteInfoNV*, void> vkCmdOpticalFlowExecuteNV = null;
	// VK_AMD_anti_lag
	public static /* readonly */  delegate* unmanaged<VkDevice, VkAntiLagDataAMD*, void> vkAntiLagUpdateAMD = null;
	// VK_EXT_shader_object
	public static /* readonly */  delegate* unmanaged<VkDevice, uint32_t, VkShaderCreateInfoEXT*, VkAllocationCallbacks*, VkShaderEXT*, VkResult> vkCreateShadersEXT = null;
	// VK_EXT_shader_object
	public static /* readonly */  delegate* unmanaged<VkDevice, VkShaderEXT, VkAllocationCallbacks*, void> vkDestroyShaderEXT = null;
	// VK_EXT_shader_object
	public static /* readonly */  delegate* unmanaged<VkDevice, VkShaderEXT, /* size_t* */ nuint , void*, VkResult> vkGetShaderBinaryDataEXT = null;
	// VK_EXT_shader_object
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkShaderStageFlagBits*, VkShaderEXT*, void> vkCmdBindShadersEXT = null;
	// VK_EXT_shader_object
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkDepthClampModeEXT, VkDepthClampRangeEXT*, void> vkCmdSetDepthClampRangeEXT = null;
	// VK_QCOM_tile_properties
	public static /* readonly */  delegate* unmanaged<VkDevice, VkFramebuffer, uint32_t*, VkTilePropertiesQCOM*, VkResult> vkGetFramebufferTilePropertiesQCOM = null;
	// VK_QCOM_tile_properties
	public static /* readonly */  delegate* unmanaged<VkDevice, VkRenderingInfo*, VkTilePropertiesQCOM*, VkResult> vkGetDynamicRenderingTilePropertiesQCOM = null;
	// VK_NV_cooperative_vector
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkCooperativeVectorPropertiesNV*, VkResult> vkGetPhysicalDeviceCooperativeVectorPropertiesNV = null;
	// VK_NV_cooperative_vector
	public static /* readonly */  delegate* unmanaged<VkDevice, VkConvertCooperativeVectorMatrixInfoNV*, VkResult> vkConvertCooperativeVectorMatrixNV = null;
	// VK_NV_cooperative_vector
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkConvertCooperativeVectorMatrixInfoNV*, void> vkCmdConvertCooperativeVectorMatrixNV = null;
	// VK_NV_low_latency2
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSwapchainKHR, VkLatencySleepModeInfoNV*, VkResult> vkSetLatencySleepModeNV = null;
	// VK_NV_low_latency2
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSwapchainKHR, VkLatencySleepInfoNV*, VkResult> vkLatencySleepNV = null;
	// VK_NV_low_latency2
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSwapchainKHR, VkSetLatencyMarkerInfoNV*, void> vkSetLatencyMarkerNV = null;
	// VK_NV_low_latency2
	public static /* readonly */  delegate* unmanaged<VkDevice, VkSwapchainKHR, VkGetLatencyMarkerInfoNV*, void> vkGetLatencyTimingsNV = null;
	// VK_NV_low_latency2
	public static /* readonly */  delegate* unmanaged<VkQueue, VkOutOfBandQueueTypeInfoNV*, void> vkQueueNotifyOutOfBandNV = null;
	// VK_EXT_attachment_feedback_loop_dynamic_state
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkImageAspectFlags, void> vkCmdSetAttachmentFeedbackLoopEnableEXT = null;
	// VK_QCOM_tile_memory_heap
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkTileMemoryBindInfoQCOM*, void> vkCmdBindTileMemoryQCOM = null;
	// VK_NV_external_compute_queue
	public static /* readonly */  delegate* unmanaged<VkDevice, VkExternalComputeQueueCreateInfoNV*, VkAllocationCallbacks*, VkExternalComputeQueueNV*, VkResult> vkCreateExternalComputeQueueNV = null;
	// VK_NV_external_compute_queue
	public static /* readonly */  delegate* unmanaged<VkDevice, VkExternalComputeQueueNV, VkAllocationCallbacks*, void> vkDestroyExternalComputeQueueNV = null;
	// VK_NV_external_compute_queue
	public static /* readonly */  delegate* unmanaged<VkExternalComputeQueueNV, VkExternalComputeQueueDataParamsNV*, void*, void> vkGetExternalComputeQueueDataNV = null;
	// VK_NV_cluster_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkDevice, VkClusterAccelerationStructureInputInfoNV*, VkAccelerationStructureBuildSizesInfoKHR*, void> vkGetClusterAccelerationStructureBuildSizesNV = null;
	// VK_NV_cluster_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkClusterAccelerationStructureCommandsInfoNV*, void> vkCmdBuildClusterAccelerationStructureIndirectNV = null;
	// VK_NV_partitioned_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPartitionedAccelerationStructureInstancesInputNV*, VkAccelerationStructureBuildSizesInfoKHR*, void> vkGetPartitionedAccelerationStructuresBuildSizesNV = null;
	// VK_NV_partitioned_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBuildPartitionedAccelerationStructureInfoNV*, void> vkCmdBuildPartitionedAccelerationStructuresNV = null;
	// VK_EXT_device_generated_commands
	public static /* readonly */  delegate* unmanaged<VkDevice, VkGeneratedCommandsMemoryRequirementsInfoEXT*, VkMemoryRequirements2*, void> vkGetGeneratedCommandsMemoryRequirementsEXT = null;
	// VK_EXT_device_generated_commands
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkGeneratedCommandsInfoEXT*, VkCommandBuffer, void> vkCmdPreprocessGeneratedCommandsEXT = null;
	// VK_EXT_device_generated_commands
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBool32, VkGeneratedCommandsInfoEXT*, void> vkCmdExecuteGeneratedCommandsEXT = null;
	// VK_EXT_device_generated_commands
	public static /* readonly */  delegate* unmanaged<VkDevice, VkIndirectCommandsLayoutCreateInfoEXT*, VkAllocationCallbacks*, VkIndirectCommandsLayoutEXT*, VkResult> vkCreateIndirectCommandsLayoutEXT = null;
	// VK_EXT_device_generated_commands
	public static /* readonly */  delegate* unmanaged<VkDevice, VkIndirectCommandsLayoutEXT, VkAllocationCallbacks*, void> vkDestroyIndirectCommandsLayoutEXT = null;
	// VK_EXT_device_generated_commands
	public static /* readonly */  delegate* unmanaged<VkDevice, VkIndirectExecutionSetCreateInfoEXT*, VkAllocationCallbacks*, VkIndirectExecutionSetEXT*, VkResult> vkCreateIndirectExecutionSetEXT = null;
	// VK_EXT_device_generated_commands
	public static /* readonly */  delegate* unmanaged<VkDevice, VkIndirectExecutionSetEXT, VkAllocationCallbacks*, void> vkDestroyIndirectExecutionSetEXT = null;
	// VK_EXT_device_generated_commands
	public static /* readonly */  delegate* unmanaged<VkDevice, VkIndirectExecutionSetEXT, uint32_t, VkWriteIndirectExecutionSetPipelineEXT*, void> vkUpdateIndirectExecutionSetPipelineEXT = null;
	// VK_EXT_device_generated_commands
	public static /* readonly */  delegate* unmanaged<VkDevice, VkIndirectExecutionSetEXT, uint32_t, VkWriteIndirectExecutionSetShaderEXT*, void> vkUpdateIndirectExecutionSetShaderEXT = null;
	// VK_NV_cooperative_matrix2
	public static /* readonly */  delegate* unmanaged<VkPhysicalDevice, uint32_t*, VkCooperativeMatrixFlexibleDimensionsPropertiesNV*, VkResult> vkGetPhysicalDeviceCooperativeMatrixFlexibleDimensionsPropertiesNV = null;
	// VK_EXT_fragment_density_map_offset
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkRenderingEndInfoEXT*, void> vkCmdEndRendering2EXT = null;
	// VK_KHR_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkDevice, VkAccelerationStructureCreateInfoKHR*, VkAllocationCallbacks*, VkAccelerationStructureKHR*, VkResult> vkCreateAccelerationStructureKHR = null;
	// VK_KHR_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkDevice, VkAccelerationStructureKHR, VkAllocationCallbacks*, void> vkDestroyAccelerationStructureKHR = null;
	// VK_KHR_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkAccelerationStructureBuildGeometryInfoKHR*, VkAccelerationStructureBuildRangeInfoKHR*, void> vkCmdBuildAccelerationStructuresKHR = null;
	// VK_KHR_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkAccelerationStructureBuildGeometryInfoKHR*, VkDeviceAddress*, uint32_t*, uint32_t*, void> vkCmdBuildAccelerationStructuresIndirectKHR = null;
	// VK_KHR_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeferredOperationKHR, uint32_t, VkAccelerationStructureBuildGeometryInfoKHR*, VkAccelerationStructureBuildRangeInfoKHR*, VkResult> vkBuildAccelerationStructuresKHR = null;
	// VK_KHR_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyAccelerationStructureInfoKHR*, VkResult> vkCopyAccelerationStructureKHR = null;
	// VK_KHR_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyAccelerationStructureToMemoryInfoKHR*, VkResult> vkCopyAccelerationStructureToMemoryKHR = null;
	// VK_KHR_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkCopyMemoryToAccelerationStructureInfoKHR*, VkResult> vkCopyMemoryToAccelerationStructureKHR = null;
	// VK_KHR_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkDevice, uint32_t, VkAccelerationStructureKHR*, VkQueryType, /* size_t */ nuint , void*, /* size_t */ nuint , VkResult> vkWriteAccelerationStructuresPropertiesKHR = null;
	// VK_KHR_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCopyAccelerationStructureInfoKHR*, void> vkCmdCopyAccelerationStructureKHR = null;
	// VK_KHR_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCopyAccelerationStructureToMemoryInfoKHR*, void> vkCmdCopyAccelerationStructureToMemoryKHR = null;
	// VK_KHR_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkCopyMemoryToAccelerationStructureInfoKHR*, void> vkCmdCopyMemoryToAccelerationStructureKHR = null;
	// VK_KHR_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkDevice, VkAccelerationStructureDeviceAddressInfoKHR*, VkDeviceAddress> vkGetAccelerationStructureDeviceAddressKHR = null;
	// VK_KHR_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, VkAccelerationStructureKHR*, VkQueryType, VkQueryPool, uint32_t, void> vkCmdWriteAccelerationStructuresPropertiesKHR = null;
	// VK_KHR_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkDevice, VkAccelerationStructureVersionInfoKHR*, VkAccelerationStructureCompatibilityKHR*, void> vkGetDeviceAccelerationStructureCompatibilityKHR = null;
	// VK_KHR_acceleration_structure
	public static /* readonly */  delegate* unmanaged<VkDevice, VkAccelerationStructureBuildTypeKHR, VkAccelerationStructureBuildGeometryInfoKHR*, uint32_t*, VkAccelerationStructureBuildSizesInfoKHR*, void> vkGetAccelerationStructureBuildSizesKHR = null;
	// VK_KHR_ray_tracing_pipeline
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, uint32_t, uint32_t, uint32_t, void> vkCmdTraceRaysKHR = null;
	// VK_KHR_ray_tracing_pipeline
	public static /* readonly */  delegate* unmanaged<VkDevice, VkDeferredOperationKHR, VkPipelineCache, uint32_t, VkRayTracingPipelineCreateInfoKHR*, VkAllocationCallbacks*, VkPipeline*, VkResult> vkCreateRayTracingPipelinesKHR = null;
	// VK_KHR_ray_tracing_pipeline
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPipeline, uint32_t, uint32_t, /* size_t */ nuint , void*, VkResult> vkGetRayTracingCaptureReplayShaderGroupHandlesKHR = null;
	// VK_KHR_ray_tracing_pipeline
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, VkStridedDeviceAddressRegionKHR*, VkDeviceAddress, void> vkCmdTraceRaysIndirectKHR = null;
	// VK_KHR_ray_tracing_pipeline
	public static /* readonly */  delegate* unmanaged<VkDevice, VkPipeline, uint32_t, VkShaderGroupShaderKHR, VkDeviceSize> vkGetRayTracingShaderGroupStackSizeKHR = null;
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, void> vkCmdSetRayTracingPipelineStackSizeKHR = null;
	// VK_EXT_mesh_shader
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, uint32_t, uint32_t, uint32_t, void> vkCmdDrawMeshTasksEXT = null;
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void> vkCmdDrawMeshTasksIndirectEXT = null;
	public static /* readonly */  delegate* unmanaged<VkCommandBuffer, VkBuffer, VkDeviceSize, VkBuffer, VkDeviceSize, uint32_t, uint32_t, void> vkCmdDrawMeshTasksIndirectCountEXT = null;
}

#region VK_VERSION_1_0
// [SkipLocalsInit]
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE)]
public /* readonly */  unsafe struct VkBuffer : IEquatable<VkBuffer>
{
    public static /* readonly */  VkBuffer Null = (VkBuffer)null;
    public bool IsNull => _ptr ==0; public bool IsNotNull => _ptr !=0;
    private /* readonly */  ulong _ptr;

    public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();
    public bool Equals(VkBuffer obj) => obj._ptr == _ptr;

    public override bool Equals(object obj) => obj is VkBuffer VkBuffer && Equals(VkBuffer);

    public static bool operator ==(VkBuffer left, VkBuffer right) => left._ptr == right._ptr;

    public static bool operator !=(VkBuffer left, VkBuffer right) => left._ptr != right._ptr;

    public static explicit operator ulong(VkBuffer value) => value._ptr;

    public static explicit operator VkBuffer(void* ptr) => *(VkBuffer*)&ptr;

    public override string ToString() => $"VkBuffer [0x{((nint)_ptr).ToString("X")}]";
}

// [SkipLocalsInit]
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE)]
public /* readonly */  unsafe struct VkImage : IEquatable<VkImage>
{
	public static /* readonly */  VkImage Null = (VkImage)null;
	public bool IsNull => _ptr ==0; public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkImage obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkImage VkImage && Equals(VkImage);

	public static bool operator ==(VkImage left, VkImage right) => left._ptr == right._ptr;

	public static bool operator !=(VkImage left, VkImage right) => left._ptr != right._ptr;

	public static explicit operator ulong(VkImage value) => value._ptr;

	public static explicit operator VkImage(void* ptr) => *(VkImage*)&ptr;

	public override string ToString() => string.Format("VkImage [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

// [SkipLocalsInit]
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkInstance : IEquatable<VkInstance> 
{
	public static /* readonly */  VkInstance Null = (VkInstance)null;
	public bool IsNull => _ptr == 0;	public bool IsNotNull => _ptr != 0;
	private /* readonly */  nint _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkInstance obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkInstance VkInstance && Equals(VkInstance);

	public static bool operator ==(VkInstance left, VkInstance right) => left._ptr == right._ptr;

	public static bool operator !=(VkInstance left, VkInstance right)=> left._ptr != right._ptr;

	public static explicit operator nint(VkInstance value) =>value._ptr;

	public static explicit operator void*(VkInstance value) =>(void*)value._ptr;

	public static explicit operator VkInstance(void* ptr)=> *(VkInstance*)&ptr;

	public static explicit operator VkInstance(nint ptr)=> *(VkInstance*)&ptr;

	public override string ToString() => string.Format("VkInstance [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

// [SkipLocalsInit]
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkPhysicalDevice() : IEquatable<VkPhysicalDevice> {
	public static /* readonly */  VkPhysicalDevice Null = (VkPhysicalDevice)null;
	public bool IsNull => _ptr == 0;	public bool IsNotNull => _ptr != 0;
	private /* readonly */  nint _ptr ;

	public override int GetHashCode() => ((nint)_ptr).GetHashCode();

	public bool Equals(VkPhysicalDevice obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkPhysicalDevice VkPhysicalDevice && Equals(VkPhysicalDevice);

	public static bool operator ==(VkPhysicalDevice left, VkPhysicalDevice right) => left._ptr == right._ptr;

	public static bool operator !=(VkPhysicalDevice left, VkPhysicalDevice right)=> left._ptr != right._ptr;

	public static explicit operator nint(VkPhysicalDevice value) =>value._ptr;

	public static explicit operator VkPhysicalDevice(void* ptr)=> *(VkPhysicalDevice*)&ptr;

	public override string ToString() => string.Format("VkPhysicalDevice [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

// [SkipLocalsInit]
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkDevice : IEquatable<VkDevice> {
	public static /* readonly */  VkDevice Null = (VkDevice)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  nint _ptr;
	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();
	public bool Equals(VkDevice obj) => obj._ptr == _ptr;
	public override bool Equals(object obj) => obj is VkDevice VkDevice && Equals(VkDevice);

	public static bool operator ==(VkDevice left, VkDevice right) => left._ptr == right._ptr;

	public static bool operator !=(VkDevice left, VkDevice right)=> left._ptr != right._ptr;

	public static explicit operator void*(VkDevice value) =>value._ptr.ToPointer();

	public static explicit operator VkDevice(void* ptr)=> *(VkDevice*)&ptr;

	public static implicit operator VkDevice(nint ptr)=> *(VkDevice*)&ptr;

	public static implicit operator nint(VkDevice ptr)=> ptr;

	public override string ToString() => string.Format("VkDevice [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

// [SkipLocalsInit]
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkQueue : IEquatable<VkQueue> {
	public static /* readonly */  VkQueue Null = (VkQueue)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  nint _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkQueue obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkQueue VkQueue && Equals(VkQueue);

	public static bool operator ==(VkQueue left, VkQueue right) => left._ptr == right._ptr;

	public static bool operator !=(VkQueue left, VkQueue right)=> left._ptr != right._ptr;

	public static explicit operator nint(VkQueue value) =>value._ptr;

	public static explicit operator VkQueue(void* ptr)=> *(VkQueue*)&ptr;

	public override string ToString() => string.Format("VkQueue [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

// [SkipLocalsInit]
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkSemaphore : IEquatable<VkSemaphore> {
	public static /* readonly */  VkSemaphore Null = (VkSemaphore)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkSemaphore obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkSemaphore VkSemaphore && Equals(VkSemaphore);

	public static bool operator ==(VkSemaphore left, VkSemaphore right) => left._ptr == right._ptr;

	public static bool operator !=(VkSemaphore left, VkSemaphore right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkSemaphore value) =>value._ptr;

	public static explicit operator VkSemaphore(void* ptr)=> *(VkSemaphore*)&ptr;

	public override string ToString() => string.Format("VkSemaphore [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

// [SkipLocalsInit]
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkCommandBuffer : IEquatable<VkCommandBuffer> {
	public static /* readonly */  VkCommandBuffer Null = (VkCommandBuffer)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  nint _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkCommandBuffer obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkCommandBuffer VkCommandBuffer && Equals(VkCommandBuffer);

	public static bool operator ==(VkCommandBuffer left, VkCommandBuffer right) => left._ptr == right._ptr;

	public static bool operator !=(VkCommandBuffer left, VkCommandBuffer right)=> left._ptr != right._ptr;

	public static explicit operator nint(VkCommandBuffer value) => value._ptr;

	public static explicit operator VkCommandBuffer(void* ptr)=> *(VkCommandBuffer*)&ptr;

	public override string ToString() => string.Format("VkCommandBuffer [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkFence : IEquatable<VkFence> {
	public static /* readonly */  VkFence Null = (VkFence)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkFence obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkFence VkFence && Equals(VkFence);

	public static bool operator ==(VkFence left, VkFence right) => left._ptr == right._ptr;

	public static bool operator !=(VkFence left, VkFence right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkFence value) =>value._ptr;

	public static explicit operator VkFence(void* ptr)=> *(VkFence*)&ptr;

	public override string ToString() => string.Format("VkFence [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkDeviceMemory : IEquatable<VkDeviceMemory> {
	public static /* readonly */  VkDeviceMemory Null = (VkDeviceMemory)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkDeviceMemory obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkDeviceMemory VkDeviceMemory && Equals(VkDeviceMemory);

	public static bool operator ==(VkDeviceMemory left, VkDeviceMemory right) => left._ptr == right._ptr;

	public static bool operator !=(VkDeviceMemory left, VkDeviceMemory right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkDeviceMemory value) =>value._ptr;

	public static explicit operator VkDeviceMemory(void* ptr)=> *(VkDeviceMemory*)&ptr;

	public override string ToString() => string.Format("VkDeviceMemory [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkEvent : IEquatable<VkEvent> {
	public static /* readonly */  VkEvent Null = (VkEvent)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkEvent obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkEvent VkEvent && Equals(VkEvent);

	public static bool operator ==(VkEvent left, VkEvent right) => left._ptr == right._ptr;

	public static bool operator !=(VkEvent left, VkEvent right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkEvent value) =>value._ptr;

	public static explicit operator VkEvent(void* ptr)=> *(VkEvent*)&ptr;

	public override string ToString() => string.Format("VkEvent [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkQueryPool : IEquatable<VkQueryPool> {
	public static /* readonly */  VkQueryPool Null = (VkQueryPool)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkQueryPool obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkQueryPool VkQueryPool && Equals(VkQueryPool);

	public static bool operator ==(VkQueryPool left, VkQueryPool right) => left._ptr == right._ptr;

	public static bool operator !=(VkQueryPool left, VkQueryPool right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkQueryPool value) =>value._ptr;

	public static explicit operator VkQueryPool(void* ptr)=> *(VkQueryPool*)&ptr;

	public override string ToString() => string.Format("VkQueryPool [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkBufferView : IEquatable<VkBufferView> {
	public static /* readonly */  VkBufferView Null = (VkBufferView)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkBufferView obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkBufferView VkBufferView && Equals(VkBufferView);

	public static bool operator ==(VkBufferView left, VkBufferView right) => left._ptr == right._ptr;

	public static bool operator !=(VkBufferView left, VkBufferView right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkBufferView value) =>value._ptr;

	public static explicit operator VkBufferView(void* ptr)=> *(VkBufferView*)&ptr;

	public override string ToString() => string.Format("VkBufferView [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkImageView : IEquatable<VkImageView> {
	public static /* readonly */  VkImageView Null = (VkImageView)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkImageView obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkImageView VkImageView && Equals(VkImageView);

	public static bool operator ==(VkImageView left, VkImageView right) => left._ptr == right._ptr;

	public static bool operator !=(VkImageView left, VkImageView right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkImageView value) =>value._ptr;

	public static explicit operator VkImageView(void* ptr)=> *(VkImageView*)&ptr;

	public override string ToString() => string.Format("VkImageView [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkShaderModule : IEquatable<VkShaderModule> {
	public static /* readonly */  VkShaderModule Null = (VkShaderModule)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkShaderModule obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkShaderModule VkShaderModule && Equals(VkShaderModule);

	public static bool operator ==(VkShaderModule left, VkShaderModule right) => left._ptr == right._ptr;

	public static bool operator !=(VkShaderModule left, VkShaderModule right)=> left._ptr != right._ptr;

	// public static explicit operator void*(VkShaderModule value) =>(void*)value._ptr;

	public static explicit operator VkShaderModule(void* ptr)=> *(VkShaderModule*)&ptr;

	public override string ToString() => string.Format("VkShaderModule [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkPipelineCache : IEquatable<VkPipelineCache> {
	public static /* readonly */  VkPipelineCache Null = (VkPipelineCache)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkPipelineCache obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkPipelineCache VkPipelineCache && Equals(VkPipelineCache);

	public static bool operator ==(VkPipelineCache left, VkPipelineCache right) => left._ptr == right._ptr;

	public static bool operator !=(VkPipelineCache left, VkPipelineCache right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkPipelineCache value) =>value._ptr;

	public static explicit operator VkPipelineCache(void* ptr)=> *(VkPipelineCache*)&ptr;

	public override string ToString() => string.Format("VkPipelineCache [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkPipelineLayout : IEquatable<VkPipelineLayout> {
	public static /* readonly */  VkPipelineLayout Null = (VkPipelineLayout)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkPipelineLayout obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkPipelineLayout VkPipelineLayout && Equals(VkPipelineLayout);

	public static bool operator ==(VkPipelineLayout left, VkPipelineLayout right) => left._ptr == right._ptr;

	public static bool operator !=(VkPipelineLayout left, VkPipelineLayout right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkPipelineLayout value) =>value._ptr;

	public static explicit operator VkPipelineLayout(void* ptr)=> *(VkPipelineLayout*)&ptr;

	public override string ToString() => string.Format("VkPipelineLayout [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkPipeline : IEquatable<VkPipeline> {
	public static /* readonly */  VkPipeline Null = (VkPipeline)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkPipeline obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkPipeline VkPipeline && Equals(VkPipeline);

	public static bool operator ==(VkPipeline left, VkPipeline right) => left._ptr == right._ptr;

	public static bool operator !=(VkPipeline left, VkPipeline right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkPipeline value) =>value._ptr;

	public static explicit operator VkPipeline(void* ptr)=> *(VkPipeline*)&ptr;

	public override string ToString() => string.Format("VkPipeline [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkRenderPass : IEquatable<VkRenderPass> {
	public static /* readonly */  VkRenderPass Null = (VkRenderPass)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkRenderPass obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkRenderPass VkRenderPass && Equals(VkRenderPass);

	public static bool operator ==(VkRenderPass left, VkRenderPass right) => left._ptr == right._ptr;

	public static bool operator !=(VkRenderPass left, VkRenderPass right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkRenderPass value) =>value._ptr;

	public static explicit operator VkRenderPass(void* ptr)=> *(VkRenderPass*)&ptr;

	public override string ToString() => string.Format("VkRenderPass [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkDescriptorSetLayout : IEquatable<VkDescriptorSetLayout> {
	public static /* readonly */  VkDescriptorSetLayout Null = (VkDescriptorSetLayout)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkDescriptorSetLayout obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkDescriptorSetLayout VkDescriptorSetLayout && Equals(VkDescriptorSetLayout);

	public static bool operator ==(VkDescriptorSetLayout left, VkDescriptorSetLayout right) => left._ptr == right._ptr;

	public static bool operator !=(VkDescriptorSetLayout left, VkDescriptorSetLayout right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkDescriptorSetLayout value) =>value._ptr;

	public static explicit operator VkDescriptorSetLayout(void* ptr)=> *(VkDescriptorSetLayout*)&ptr;

	public override string ToString() => string.Format("VkDescriptorSetLayout [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkSampler : IEquatable<VkSampler> {
	public static /* readonly */  VkSampler Null = (VkSampler)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkSampler obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkSampler VkSampler && Equals(VkSampler);

	public static bool operator ==(VkSampler left, VkSampler right) => left._ptr == right._ptr;

	public static bool operator !=(VkSampler left, VkSampler right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkSampler value) =>value._ptr;

	public static explicit operator VkSampler(void* ptr)=> *(VkSampler*)&ptr;

	public override string ToString() => string.Format("VkSampler [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkDescriptorSet : IEquatable<VkDescriptorSet> {
	public static /* readonly */  VkDescriptorSet Null = (VkDescriptorSet)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkDescriptorSet obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkDescriptorSet VkDescriptorSet && Equals(VkDescriptorSet);

	public static bool operator ==(VkDescriptorSet left, VkDescriptorSet right) => left._ptr == right._ptr;

	public static bool operator !=(VkDescriptorSet left, VkDescriptorSet right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkDescriptorSet value) =>value._ptr;

	public static explicit operator VkDescriptorSet(void* ptr)=> *(VkDescriptorSet*)&ptr;

	public override string ToString() => string.Format("VkDescriptorSet [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkDescriptorPool : IEquatable<VkDescriptorPool> {
	public static /* readonly */  VkDescriptorPool Null = (VkDescriptorPool)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkDescriptorPool obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkDescriptorPool VkDescriptorPool && Equals(VkDescriptorPool);

	public static bool operator ==(VkDescriptorPool left, VkDescriptorPool right) => left._ptr == right._ptr;

	public static bool operator !=(VkDescriptorPool left, VkDescriptorPool right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkDescriptorPool value) =>value._ptr;

	public static explicit operator VkDescriptorPool(void* ptr)=> *(VkDescriptorPool*)&ptr;

	public override string ToString() => string.Format("VkDescriptorPool [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkFramebuffer : IEquatable<VkFramebuffer> {
	public static /* readonly */  VkFramebuffer Null = (VkFramebuffer)null;
	public bool IsNull => _ptr == 0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkFramebuffer obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkFramebuffer VkFramebuffer && Equals(VkFramebuffer);

	public static bool operator ==(VkFramebuffer left, VkFramebuffer right) => left._ptr == right._ptr;

	public static bool operator !=(VkFramebuffer left, VkFramebuffer right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkFramebuffer value) =>value._ptr;

	public static explicit operator VkFramebuffer(void* ptr)=> *(VkFramebuffer*)&ptr;

	public override string ToString() => string.Format("VkFramebuffer [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

// [SkipLocalsInit]
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE)]
public /* readonly */  unsafe struct VkCommandPool : IEquatable<VkCommandPool>
{
    public static /* readonly */  VkCommandPool Null = (VkCommandPool)null;
    public bool IsNull => _ptr == 0; public bool IsNotNull => _ptr != 0;
    private /* readonly */  ulong _ptr;

    public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

    public bool Equals(VkCommandPool obj) => obj._ptr == _ptr;

    public override bool Equals(object obj) => obj is VkCommandPool VkCommandPool && Equals(VkCommandPool);

    public static bool operator ==(VkCommandPool left, VkCommandPool right) => left._ptr == right._ptr;

    public static bool operator !=(VkCommandPool left, VkCommandPool right) => left._ptr != right._ptr;

    public static explicit operator ulong(VkCommandPool value) => value._ptr;

    public static explicit operator VkCommandPool(void* ptr) => *(VkCommandPool*)&ptr;

    public override string ToString() => string.Format("VkCommandPool [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
#endregion

#region VK_VERSION_1_1
 [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkSamplerYcbcrConversion : IEquatable<VkSamplerYcbcrConversion> {
	public static /* readonly */  VkSamplerYcbcrConversion Null = (VkSamplerYcbcrConversion)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkSamplerYcbcrConversion obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkSamplerYcbcrConversion VkSamplerYcbcrConversion && Equals(VkSamplerYcbcrConversion);

	public static bool operator ==(VkSamplerYcbcrConversion left, VkSamplerYcbcrConversion right) => left._ptr == right._ptr;

	public static bool operator !=(VkSamplerYcbcrConversion left, VkSamplerYcbcrConversion right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkSamplerYcbcrConversion value) =>value._ptr;

	public static explicit operator VkSamplerYcbcrConversion(void* ptr)=> *(VkSamplerYcbcrConversion*)&ptr;

	public override string ToString() => string.Format("VkSamplerYcbcrConversion [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkDescriptorUpdateTemplate : IEquatable<VkDescriptorUpdateTemplate> {
	public static /* readonly */  VkDescriptorUpdateTemplate Null = (VkDescriptorUpdateTemplate)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkDescriptorUpdateTemplate obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkDescriptorUpdateTemplate VkDescriptorUpdateTemplate && Equals(VkDescriptorUpdateTemplate);

	public static bool operator ==(VkDescriptorUpdateTemplate left, VkDescriptorUpdateTemplate right) => left._ptr == right._ptr;

	public static bool operator !=(VkDescriptorUpdateTemplate left, VkDescriptorUpdateTemplate right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkDescriptorUpdateTemplate value) =>value._ptr;

	public static explicit operator VkDescriptorUpdateTemplate(void* ptr)=> *(VkDescriptorUpdateTemplate*)&ptr;

	public override string ToString() => string.Format("VkDescriptorUpdateTemplate [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_VERSION_1_3
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkPrivateDataSlot : IEquatable<VkPrivateDataSlot> {
	public static /* readonly */  VkPrivateDataSlot Null = (VkPrivateDataSlot)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkPrivateDataSlot obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkPrivateDataSlot VkPrivateDataSlot && Equals(VkPrivateDataSlot);

	public static bool operator ==(VkPrivateDataSlot left, VkPrivateDataSlot right) => left._ptr == right._ptr;

	public static bool operator !=(VkPrivateDataSlot left, VkPrivateDataSlot right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkPrivateDataSlot value) =>value._ptr;

	public static explicit operator VkPrivateDataSlot(void* ptr)=> *(VkPrivateDataSlot*)&ptr;

	public override string ToString() => string.Format("VkPrivateDataSlot [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_KHR_surface
// [SkipLocalsInit]
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE)]
public /* readonly */  unsafe struct VkSurfaceKHR : IEquatable<VkSurfaceKHR>
{
    public static /* readonly */  VkSurfaceKHR Null = (VkSurfaceKHR)null;
    public bool IsNull => _ptr == 0; public bool IsNotNull => _ptr != 0;
    private /* readonly */  ulong _ptr;

    public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

    public bool Equals(VkSurfaceKHR obj) => obj._ptr == _ptr;

    public override bool Equals(object obj) => obj is VkSurfaceKHR VkSurfaceKHR && Equals(VkSurfaceKHR);

    public static bool operator ==(VkSurfaceKHR left, VkSurfaceKHR right) => left._ptr == right._ptr;

    public static bool operator !=(VkSurfaceKHR left, VkSurfaceKHR right) => left._ptr != right._ptr;

    public static explicit operator ulong(VkSurfaceKHR value) => value._ptr;

    public static explicit operator VkSurfaceKHR(void* ptr) => *(VkSurfaceKHR*)&ptr;

    public override string ToString() => string.Format("VkSurfaceKHR [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

#endregion
// VK_KHR_swapchain
 [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkSwapchainKHR : IEquatable<VkSwapchainKHR> {
	public static /* readonly */  VkSwapchainKHR Null = (VkSwapchainKHR)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkSwapchainKHR obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkSwapchainKHR VkSwapchainKHR && Equals(VkSwapchainKHR);

	public static bool operator ==(VkSwapchainKHR left, VkSwapchainKHR right) => left._ptr == right._ptr;

	public static bool operator !=(VkSwapchainKHR left, VkSwapchainKHR right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkSwapchainKHR value) =>value._ptr;

	public static explicit operator VkSwapchainKHR(void* ptr)=> *(VkSwapchainKHR*)&ptr;

	public override string ToString() => string.Format("VkSwapchainKHR [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_KHR_display
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkDisplayKHR : IEquatable<VkDisplayKHR> {
	public static /* readonly */  VkDisplayKHR Null = (VkDisplayKHR)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkDisplayKHR obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkDisplayKHR VkDisplayKHR && Equals(VkDisplayKHR);

	public static bool operator ==(VkDisplayKHR left, VkDisplayKHR right) => left._ptr == right._ptr;

	public static bool operator !=(VkDisplayKHR left, VkDisplayKHR right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkDisplayKHR value) =>value._ptr;

	public static explicit operator VkDisplayKHR(void* ptr)=> *(VkDisplayKHR*)&ptr;

	public override string ToString() => string.Format("VkDisplayKHR [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_KHR_display ------------------------------------------------------------------------------------------------------------------
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkDisplayModeKHR : IEquatable<VkDisplayModeKHR> {
	public static /* readonly */  VkDisplayModeKHR Null = (VkDisplayModeKHR)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkDisplayModeKHR obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkDisplayModeKHR VkDisplayModeKHR && Equals(VkDisplayModeKHR);

	public static bool operator ==(VkDisplayModeKHR left, VkDisplayModeKHR right) => left._ptr == right._ptr;

	public static bool operator !=(VkDisplayModeKHR left, VkDisplayModeKHR right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkDisplayModeKHR value) =>value._ptr;

	public static explicit operator VkDisplayModeKHR(void* ptr)=> *(VkDisplayModeKHR*)&ptr;

	public override string ToString() => string.Format("VkDisplayModeKHR [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_KHR_video_queue
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkVideoSessionKHR : IEquatable<VkVideoSessionKHR> {
	public static /* readonly */  VkVideoSessionKHR Null = (VkVideoSessionKHR)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkVideoSessionKHR obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkVideoSessionKHR VkVideoSessionKHR && Equals(VkVideoSessionKHR);

	public static bool operator ==(VkVideoSessionKHR left, VkVideoSessionKHR right) => left._ptr == right._ptr;

	public static bool operator !=(VkVideoSessionKHR left, VkVideoSessionKHR right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkVideoSessionKHR value) =>value._ptr;

	public static explicit operator VkVideoSessionKHR(void* ptr)=> *(VkVideoSessionKHR*)&ptr;

	public override string ToString() => string.Format("VkVideoSessionKHR [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// // VK_KHR_video_queue
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkVideoSessionParametersKHR : IEquatable<VkVideoSessionParametersKHR> {
	public static /* readonly */  VkVideoSessionParametersKHR Null = (VkVideoSessionParametersKHR)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkVideoSessionParametersKHR obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkVideoSessionParametersKHR VkVideoSessionParametersKHR && Equals(VkVideoSessionParametersKHR);

	public static bool operator ==(VkVideoSessionParametersKHR left, VkVideoSessionParametersKHR right) => left._ptr == right._ptr;

	public static bool operator !=(VkVideoSessionParametersKHR left, VkVideoSessionParametersKHR right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkVideoSessionParametersKHR value) =>value._ptr;

	public static explicit operator VkVideoSessionParametersKHR(void* ptr)=> *(VkVideoSessionParametersKHR*)&ptr;

	public override string ToString() => string.Format("VkVideoSessionParametersKHR [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_KHR_deferred_host_operations
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkDeferredOperationKHR : IEquatable<VkDeferredOperationKHR> {
	public static /* readonly */  VkDeferredOperationKHR Null = (VkDeferredOperationKHR)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkDeferredOperationKHR obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkDeferredOperationKHR VkDeferredOperationKHR && Equals(VkDeferredOperationKHR);

	public static bool operator ==(VkDeferredOperationKHR left, VkDeferredOperationKHR right) => left._ptr == right._ptr;

	public static bool operator !=(VkDeferredOperationKHR left, VkDeferredOperationKHR right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkDeferredOperationKHR value) =>value._ptr;

	public static explicit operator VkDeferredOperationKHR(void* ptr)=> *(VkDeferredOperationKHR*)&ptr;

	public override string ToString() => string.Format("VkDeferredOperationKHR [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_KHR_pipeline_binary
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkPipelineBinaryKHR : IEquatable<VkPipelineBinaryKHR> {
	public static /* readonly */  VkPipelineBinaryKHR Null = (VkPipelineBinaryKHR)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkPipelineBinaryKHR obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkPipelineBinaryKHR VkPipelineBinaryKHR && Equals(VkPipelineBinaryKHR);

	public static bool operator ==(VkPipelineBinaryKHR left, VkPipelineBinaryKHR right) => left._ptr == right._ptr;

	public static bool operator !=(VkPipelineBinaryKHR left, VkPipelineBinaryKHR right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkPipelineBinaryKHR value) =>value._ptr;

	public static explicit operator VkPipelineBinaryKHR(void* ptr)=> *(VkPipelineBinaryKHR*)&ptr;

	public override string ToString() => string.Format("VkPipelineBinaryKHR [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_EXT_debug_report
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkDebugReportCallbackEXT : IEquatable<VkDebugReportCallbackEXT> {
	public static /* readonly */  VkDebugReportCallbackEXT Null = (VkDebugReportCallbackEXT)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkDebugReportCallbackEXT obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkDebugReportCallbackEXT VkDebugReportCallbackEXT && Equals(VkDebugReportCallbackEXT);

	public static bool operator ==(VkDebugReportCallbackEXT left, VkDebugReportCallbackEXT right) => left._ptr == right._ptr;

	public static bool operator !=(VkDebugReportCallbackEXT left, VkDebugReportCallbackEXT right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkDebugReportCallbackEXT value) =>value._ptr;

	public static explicit operator VkDebugReportCallbackEXT(void* ptr)=> *(VkDebugReportCallbackEXT*)&ptr;

	public override string ToString() => string.Format("VkDebugReportCallbackEXT [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_NVX_binary_import
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkCuModuleNVX : IEquatable<VkCuModuleNVX> {
	public static /* readonly */  VkCuModuleNVX Null = (VkCuModuleNVX)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkCuModuleNVX obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkCuModuleNVX VkCuModuleNVX && Equals(VkCuModuleNVX);

	public static bool operator ==(VkCuModuleNVX left, VkCuModuleNVX right) => left._ptr == right._ptr;

	public static bool operator !=(VkCuModuleNVX left, VkCuModuleNVX right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkCuModuleNVX value) =>value._ptr;

	public static explicit operator VkCuModuleNVX(void* ptr)=> *(VkCuModuleNVX*)&ptr;

	public override string ToString() => string.Format("VkCuModuleNVX [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_NVX_binary_import
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkCuFunctionNVX : IEquatable<VkCuFunctionNVX> {
	public static /* readonly */  VkCuFunctionNVX Null = (VkCuFunctionNVX)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkCuFunctionNVX obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkCuFunctionNVX VkCuFunctionNVX && Equals(VkCuFunctionNVX);

	public static bool operator ==(VkCuFunctionNVX left, VkCuFunctionNVX right) => left._ptr == right._ptr;

	public static bool operator !=(VkCuFunctionNVX left, VkCuFunctionNVX right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkCuFunctionNVX value) =>value._ptr;

	public static explicit operator VkCuFunctionNVX(void* ptr)=> *(VkCuFunctionNVX*)&ptr;

	public override string ToString() => string.Format("VkCuFunctionNVX [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_EXT_debug_utils
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkDebugUtilsMessengerEXT : IEquatable<VkDebugUtilsMessengerEXT> {
	public static /* readonly */  VkDebugUtilsMessengerEXT Null = (VkDebugUtilsMessengerEXT)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkDebugUtilsMessengerEXT obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkDebugUtilsMessengerEXT VkDebugUtilsMessengerEXT && Equals(VkDebugUtilsMessengerEXT);

	public static bool operator ==(VkDebugUtilsMessengerEXT left, VkDebugUtilsMessengerEXT right) => left._ptr == right._ptr;

	public static bool operator !=(VkDebugUtilsMessengerEXT left, VkDebugUtilsMessengerEXT right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkDebugUtilsMessengerEXT value) =>value._ptr;

	public static explicit operator VkDebugUtilsMessengerEXT(void* ptr)=> *(VkDebugUtilsMessengerEXT*)&ptr;

	public override string ToString() => string.Format("VkDebugUtilsMessengerEXT [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_EXT_validation_cache
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkValidationCacheEXT : IEquatable<VkValidationCacheEXT> {
	public static /* readonly */  VkValidationCacheEXT Null = (VkValidationCacheEXT)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkValidationCacheEXT obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkValidationCacheEXT VkValidationCacheEXT && Equals(VkValidationCacheEXT);

	public static bool operator ==(VkValidationCacheEXT left, VkValidationCacheEXT right) => left._ptr == right._ptr;

	public static bool operator !=(VkValidationCacheEXT left, VkValidationCacheEXT right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkValidationCacheEXT value) =>value._ptr;

	public static explicit operator VkValidationCacheEXT(void* ptr)=> *(VkValidationCacheEXT*)&ptr;

	public override string ToString() => string.Format("VkValidationCacheEXT [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_NV_ray_tracing
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkAccelerationStructureNV : IEquatable<VkAccelerationStructureNV> {
	public static /* readonly */  VkAccelerationStructureNV Null = (VkAccelerationStructureNV)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkAccelerationStructureNV obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkAccelerationStructureNV VkAccelerationStructureNV && Equals(VkAccelerationStructureNV);

	public static bool operator ==(VkAccelerationStructureNV left, VkAccelerationStructureNV right) => left._ptr == right._ptr;

	public static bool operator !=(VkAccelerationStructureNV left, VkAccelerationStructureNV right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkAccelerationStructureNV value) =>value._ptr;

	public static explicit operator VkAccelerationStructureNV(void* ptr)=> *(VkAccelerationStructureNV*)&ptr;

	public override string ToString() => string.Format("VkAccelerationStructureNV [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_INTEL_performance_query
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkPerformanceConfigurationINTEL : IEquatable<VkPerformanceConfigurationINTEL> {
	public static /* readonly */  VkPerformanceConfigurationINTEL Null = (VkPerformanceConfigurationINTEL)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkPerformanceConfigurationINTEL obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkPerformanceConfigurationINTEL VkPerformanceConfigurationINTEL && Equals(VkPerformanceConfigurationINTEL);

	public static bool operator ==(VkPerformanceConfigurationINTEL left, VkPerformanceConfigurationINTEL right) => left._ptr == right._ptr;

	public static bool operator !=(VkPerformanceConfigurationINTEL left, VkPerformanceConfigurationINTEL right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkPerformanceConfigurationINTEL value) =>value._ptr;

	public static explicit operator VkPerformanceConfigurationINTEL(void* ptr)=> *(VkPerformanceConfigurationINTEL*)&ptr;

	public override string ToString() => string.Format("VkPerformanceConfigurationINTEL [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_NV_device_generated_commands
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkIndirectCommandsLayoutNV : IEquatable<VkIndirectCommandsLayoutNV> {
	public static /* readonly */  VkIndirectCommandsLayoutNV Null = (VkIndirectCommandsLayoutNV)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkIndirectCommandsLayoutNV obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkIndirectCommandsLayoutNV VkIndirectCommandsLayoutNV && Equals(VkIndirectCommandsLayoutNV);

	public static bool operator ==(VkIndirectCommandsLayoutNV left, VkIndirectCommandsLayoutNV right) => left._ptr == right._ptr;

	public static bool operator !=(VkIndirectCommandsLayoutNV left, VkIndirectCommandsLayoutNV right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkIndirectCommandsLayoutNV value) =>value._ptr;

	public static explicit operator VkIndirectCommandsLayoutNV(void* ptr)=> *(VkIndirectCommandsLayoutNV*)&ptr;

	public override string ToString() => string.Format("VkIndirectCommandsLayoutNV [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_NV_cuda_kernel_launch
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkCudaModuleNV : IEquatable<VkCudaModuleNV> {
	public static /* readonly */  VkCudaModuleNV Null = (VkCudaModuleNV)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  nint _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkCudaModuleNV obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkCudaModuleNV VkCudaModuleNV && Equals(VkCudaModuleNV);

	public static bool operator ==(VkCudaModuleNV left, VkCudaModuleNV right) => left._ptr == right._ptr;

	public static bool operator !=(VkCudaModuleNV left, VkCudaModuleNV right)=> left._ptr != right._ptr;

	public static explicit operator nint(VkCudaModuleNV value) =>value._ptr;

	public static explicit operator VkCudaModuleNV(void* ptr)=> *(VkCudaModuleNV*)&ptr;

	public override string ToString() => string.Format("VkCudaModuleNV [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_NV_cuda_kernel_launch
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkCudaFunctionNV : IEquatable<VkCudaFunctionNV> {
	public static /* readonly */  VkCudaFunctionNV Null = (VkCudaFunctionNV)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  nint _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkCudaFunctionNV obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkCudaFunctionNV VkCudaFunctionNV && Equals(VkCudaFunctionNV);

	public static bool operator ==(VkCudaFunctionNV left, VkCudaFunctionNV right) => left._ptr == right._ptr;

	public static bool operator !=(VkCudaFunctionNV left, VkCudaFunctionNV right)=> left._ptr != right._ptr;

	public static explicit operator nint(VkCudaFunctionNV value) =>value._ptr;

	public static explicit operator VkCudaFunctionNV(void* ptr)=> *(VkCudaFunctionNV*)&ptr;

	public override string ToString() => string.Format("VkCudaFunctionNV [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_EXT_descriptor_buffer
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkAccelerationStructureKHR : IEquatable<VkAccelerationStructureKHR> {
	public static /* readonly */  VkAccelerationStructureKHR Null = (VkAccelerationStructureKHR)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkAccelerationStructureKHR obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkAccelerationStructureKHR VkAccelerationStructureKHR && Equals(VkAccelerationStructureKHR);

	public static bool operator ==(VkAccelerationStructureKHR left, VkAccelerationStructureKHR right) => left._ptr == right._ptr;

	public static bool operator !=(VkAccelerationStructureKHR left, VkAccelerationStructureKHR right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkAccelerationStructureKHR value) =>value._ptr;

	public static explicit operator VkAccelerationStructureKHR(void* ptr)=> *(VkAccelerationStructureKHR*)&ptr;

	public override string ToString() => string.Format("VkAccelerationStructureKHR [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_EXT_opacity_micromap
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkMicromapEXT : IEquatable<VkMicromapEXT> {
	public static /* readonly */  VkMicromapEXT Null = (VkMicromapEXT)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  nint _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkMicromapEXT obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkMicromapEXT VkMicromapEXT && Equals(VkMicromapEXT);

	public static bool operator ==(VkMicromapEXT left, VkMicromapEXT right) => left._ptr == right._ptr;

	public static bool operator !=(VkMicromapEXT left, VkMicromapEXT right)=> left._ptr != right._ptr;

	public static explicit operator nint(VkMicromapEXT value) =>value._ptr;

	public static explicit operator VkMicromapEXT(void* ptr)=> *(VkMicromapEXT*)&ptr;

	public override string ToString() => string.Format("VkMicromapEXT [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_NV_optical_flow
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkOpticalFlowSessionNV : IEquatable<VkOpticalFlowSessionNV> {
	public static /* readonly */  VkOpticalFlowSessionNV Null = (VkOpticalFlowSessionNV)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkOpticalFlowSessionNV obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkOpticalFlowSessionNV VkOpticalFlowSessionNV && Equals(VkOpticalFlowSessionNV);

	public static bool operator ==(VkOpticalFlowSessionNV left, VkOpticalFlowSessionNV right) => left._ptr == right._ptr;

	public static bool operator !=(VkOpticalFlowSessionNV left, VkOpticalFlowSessionNV right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkOpticalFlowSessionNV value) =>value._ptr;

	public static explicit operator VkOpticalFlowSessionNV(void* ptr)=> *(VkOpticalFlowSessionNV*)&ptr;

	public override string ToString() => string.Format("VkOpticalFlowSessionNV [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_EXT_shader_object
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkShaderEXT : IEquatable<VkShaderEXT> {
	public static /* readonly */  VkShaderEXT Null = (VkShaderEXT)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkShaderEXT obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkShaderEXT VkShaderEXT && Equals(VkShaderEXT);

	public static bool operator ==(VkShaderEXT left, VkShaderEXT right) => left._ptr == right._ptr;

	public static bool operator !=(VkShaderEXT left, VkShaderEXT right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkShaderEXT value) =>value._ptr;

	public static explicit operator VkShaderEXT(void* ptr)=> *(VkShaderEXT*)&ptr;

	public override string ToString() => string.Format("VkShaderEXT [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_NV_external_compute_queue
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkExternalComputeQueueNV : IEquatable<VkExternalComputeQueueNV> {
	public static /* readonly */  VkExternalComputeQueueNV Null = (VkExternalComputeQueueNV)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkExternalComputeQueueNV obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkExternalComputeQueueNV VkExternalComputeQueueNV && Equals(VkExternalComputeQueueNV);

	public static bool operator ==(VkExternalComputeQueueNV left, VkExternalComputeQueueNV right) => left._ptr == right._ptr;

	public static bool operator !=(VkExternalComputeQueueNV left, VkExternalComputeQueueNV right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkExternalComputeQueueNV value) =>value._ptr;

	public static explicit operator VkExternalComputeQueueNV(void* ptr)=> *(VkExternalComputeQueueNV*)&ptr;

	public override string ToString() => string.Format("VkExternalComputeQueueNV [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_EXT_device_generated_commands
  [SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE ) ]
public /* readonly */  unsafe struct VkIndirectExecutionSetEXT : IEquatable<VkIndirectExecutionSetEXT> {
	public static /* readonly */  VkIndirectExecutionSetEXT Null = (VkIndirectExecutionSetEXT)null;
	public bool IsNull => _ptr ==0;	public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkIndirectExecutionSetEXT obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkIndirectExecutionSetEXT VkIndirectExecutionSetEXT && Equals(VkIndirectExecutionSetEXT);

	public static bool operator ==(VkIndirectExecutionSetEXT left, VkIndirectExecutionSetEXT right) => left._ptr == right._ptr;

	public static bool operator !=(VkIndirectExecutionSetEXT left, VkIndirectExecutionSetEXT right)=> left._ptr != right._ptr;

	public static explicit operator ulong(VkIndirectExecutionSetEXT value) =>value._ptr;

	public static explicit operator VkIndirectExecutionSetEXT(void* ptr)=> *(VkIndirectExecutionSetEXT*)&ptr;

	public override string ToString() => string.Format("VkIndirectExecutionSetEXT [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}
// VK_EXT_device_generated_commands
[SkipLocalsInit] [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE)]
public /* readonly */  unsafe struct VkIndirectCommandsLayoutEXT : IEquatable<VkIndirectCommandsLayoutEXT> {
	public static /* readonly */  VkIndirectCommandsLayoutEXT Null = (VkIndirectCommandsLayoutEXT)null;
	public bool IsNull => _ptr==0; public bool IsNotNull => _ptr !=0;
	private /* readonly */  ulong _ptr;

	public override int GetHashCode() => ((IntPtr)_ptr).GetHashCode();

	public bool Equals(VkIndirectCommandsLayoutEXT obj) => obj._ptr == _ptr;

	public override bool Equals(object obj) => obj is VkIndirectCommandsLayoutEXT VkIndirectCommandsLayoutEXT && Equals(VkIndirectCommandsLayoutEXT);

	public static bool operator ==(VkIndirectCommandsLayoutEXT left, VkIndirectCommandsLayoutEXT right) => left._ptr == right._ptr;

	public static bool operator !=(VkIndirectCommandsLayoutEXT left, VkIndirectCommandsLayoutEXT right) => left._ptr != right._ptr;

	public static explicit operator ulong(VkIndirectCommandsLayoutEXT value) => value._ptr;

	public static explicit operator VkIndirectCommandsLayoutEXT(void* ptr) => *(VkIndirectCommandsLayoutEXT*)&ptr;

	public override string ToString() => string.Format("VkIndirectCommandsLayoutEXT [0x{0}]", ((IntPtr)_ptr).ToString("X"));
}

// [SkipLocalsInit][StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE)]
public static partial class VK
{
	public const int DATA_ALIGNEMENT_SIZE = 8;
	public const string VK_KHR_SURFACE_EXTENSION_NAME = "VK_KHR_surface";
	public const string VK_KHR_SWAPCHAIN_EXTENSION_NAME = "VK_KHR_swapchain";
	public const string VK_KHR_DISPLAY_EXTENSION_NAME = "VK_KHR_display";
	public const string VK_KHR_DISPLAY_SWAPCHAIN_EXTENSION_NAME = "VK_KHR_display_swapchain";
	public const string VK_KHR_SAMPLER_MIRROR_CLAMP_TO_EDGE_EXTENSION_NAME = "VK_KHR_sampler_mirror_clamp_to_edge";
	public const string VK_KHR_VIDEO_QUEUE_EXTENSION_NAME = "VK_KHR_video_queue";
	public const string VK_KHR_VIDEO_DECODE_QUEUE_EXTENSION_NAME = "VK_KHR_video_decode_queue";
	public const string VK_KHR_VIDEO_ENCODE_H264_EXTENSION_NAME = "VK_KHR_video_encode_h264";
	public const string VK_KHR_VIDEO_ENCODE_H265_EXTENSION_NAME = "VK_KHR_video_encode_h265";
	public const string VK_KHR_VIDEO_DECODE_H264_EXTENSION_NAME = "VK_KHR_video_decode_h264";
	public const string VK_KHR_DYNAMIC_RENDERING_EXTENSION_NAME = "VK_KHR_dynamic_rendering";
	public const string VK_KHR_MULTIVIEW_EXTENSION_NAME = "VK_KHR_multiview";
	public const string VK_KHR_GET_PHYSICAL_DEVICE_PROPERTIES_2_EXTENSION_NAME = "VK_KHR_get_physical_device_properties2";
	public const string VK_KHR_DEVICE_GROUP_EXTENSION_NAME = "VK_KHR_device_group";
	public const string VK_KHR_SHADER_DRAW_PARAMETERS_EXTENSION_NAME = "VK_KHR_shader_draw_parameters";
	public const string VK_KHR_MAINTENANCE_1_EXTENSION_NAME = "VK_KHR_maintenance1";
	public const string VK_KHR_MAINTENANCE1_EXTENSION_NAME = VK_KHR_MAINTENANCE_1_EXTENSION_NAME;
	public const string VK_KHR_DEVICE_GROUP_CREATION_EXTENSION_NAME = "VK_KHR_device_group_creation";
	public const string VK_KHR_EXTERNAL_MEMORY_CAPABILITIES_EXTENSION_NAME = "VK_KHR_external_memory_capabilities";
	public const string VK_KHR_EXTERNAL_MEMORY_EXTENSION_NAME = "VK_KHR_external_memory";
	public const string VK_KHR_EXTERNAL_MEMORY_FD_EXTENSION_NAME = "VK_KHR_external_memory_fd";
	public const string VK_KHR_EXTERNAL_SEMAPHORE_CAPABILITIES_EXTENSION_NAME = "VK_KHR_external_semaphore_capabilities";
	public const string VK_KHR_EXTERNAL_SEMAPHORE_EXTENSION_NAME = "VK_KHR_external_semaphore";
	public const string VK_KHR_EXTERNAL_SEMAPHORE_FD_EXTENSION_NAME = "VK_KHR_external_semaphore_fd";
	public const string VK_KHR_PUSH_DESCRIPTOR_EXTENSION_NAME = "VK_KHR_push_descriptor";
	public const string VK_KHR_SHADER_FLOAT16_INT8_EXTENSION_NAME = "VK_KHR_shader_float16_int8";
	public const string VK_KHR_16BIT_STORAGE_EXTENSION_NAME = "VK_KHR_16bit_storage";
	public const string VK_KHR_INCREMENTAL_PRESENT_EXTENSION_NAME = "VK_KHR_incremental_present";
	public const string VK_KHR_DESCRIPTOR_UPDATE_TEMPLATE_EXTENSION_NAME = "VK_KHR_descriptor_update_template";
	public const string VK_KHR_IMAGELESS_FRAMEBUFFER_EXTENSION_NAME = "VK_KHR_imageless_framebuffer";
	public const string VK_KHR_CREATE_RENDERPASS_2_EXTENSION_NAME = "VK_KHR_create_renderpass2";
	public const string VK_KHR_SHARED_PRESENTABLE_IMAGE_EXTENSION_NAME = "VK_KHR_shared_presentable_image";
	public const string VK_KHR_EXTERNAL_FENCE_CAPABILITIES_EXTENSION_NAME = "VK_KHR_external_fence_capabilities";
	public const string VK_KHR_EXTERNAL_FENCE_EXTENSION_NAME = "VK_KHR_external_fence";
	public const string VK_KHR_EXTERNAL_FENCE_FD_EXTENSION_NAME = "VK_KHR_external_fence_fd";
	public const string VK_KHR_PERFORMANCE_QUERY_EXTENSION_NAME = "VK_KHR_performance_query";
	public const string VK_KHR_MAINTENANCE_2_EXTENSION_NAME = "VK_KHR_maintenance2";
	public const string VK_KHR_MAINTENANCE2_EXTENSION_NAME = VK_KHR_MAINTENANCE_2_EXTENSION_NAME;
	public const string VK_KHR_GET_SURFACE_CAPABILITIES_2_EXTENSION_NAME = "VK_KHR_get_surface_capabilities2";
	public const string VK_KHR_VARIABLE_POINTERS_EXTENSION_NAME = "VK_KHR_variable_pointers";
	public const string VK_KHR_GET_DISPLAY_PROPERTIES_2_EXTENSION_NAME = "VK_KHR_get_display_properties2";
	public const string VK_KHR_DEDICATED_ALLOCATION_EXTENSION_NAME = "VK_KHR_dedicated_allocation";
	public const string VK_KHR_STORAGE_BUFFER_STORAGE_CLASS_EXTENSION_NAME = "VK_KHR_storage_buffer_storage_class";
	public const string VK_KHR_SHADER_BFLOAT16_EXTENSION_NAME = "VK_KHR_shader_bfloat16";
	public const string VK_KHR_RELAXED_BLOCK_LAYOUT_EXTENSION_NAME = "VK_KHR_relaxed_block_layout";
	public const string VK_KHR_GET_MEMORY_REQUIREMENTS_2_EXTENSION_NAME = "VK_KHR_get_memory_requirements2";
	public const string VK_KHR_IMAGE_FORMAT_LIST_EXTENSION_NAME = "VK_KHR_image_format_list";
	public const string VK_KHR_SAMPLER_YCBCR_CONVERSION_EXTENSION_NAME = "VK_KHR_sampler_ycbcr_conversion";
	public const string VK_KHR_BIND_MEMORY_2_EXTENSION_NAME = "VK_KHR_bind_memory2";
	public const string VK_KHR_MAINTENANCE_3_EXTENSION_NAME = "VK_KHR_maintenance3";
	public const string VK_KHR_MAINTENANCE3_EXTENSION_NAME = VK_KHR_MAINTENANCE_3_EXTENSION_NAME;
	public const string VK_KHR_DRAW_INDIRECT_COUNT_EXTENSION_NAME = "VK_KHR_draw_indirect_count";
	public const string VK_KHR_SHADER_SUBGROUP_EXTENDED_TYPES_EXTENSION_NAME = "VK_KHR_shader_subgroup_extended_types";
	public const string VK_KHR_8BIT_STORAGE_EXTENSION_NAME = "VK_KHR_8bit_storage";
	public const string VK_KHR_SHADER_ATOMIC_INT64_EXTENSION_NAME = "VK_KHR_shader_atomic_int64";
	public const string VK_KHR_SHADER_CLOCK_EXTENSION_NAME = "VK_KHR_shader_clock";
	public const string VK_KHR_VIDEO_DECODE_H265_EXTENSION_NAME = "VK_KHR_video_decode_h265";
	public const string VK_KHR_GLOBAL_PRIORITY_EXTENSION_NAME = "VK_KHR_global_priority";
	public const string VK_KHR_DRIVER_PROPERTIES_EXTENSION_NAME = "VK_KHR_driver_properties";
	public const string VK_KHR_SHADER_FLOAT_CONTROLS_EXTENSION_NAME = "VK_KHR_shader_float_controls";
	public const string VK_KHR_DEPTH_STENCIL_RESOLVE_EXTENSION_NAME = "VK_KHR_depth_stencil_resolve";
	public const string VK_KHR_SWAPCHAIN_MUTABLE_FORMAT_EXTENSION_NAME = "VK_KHR_swapchain_mutable_format";
	public const string VK_KHR_TIMELINE_SEMAPHORE_EXTENSION_NAME = "VK_KHR_timeline_semaphore";
	public const string VK_KHR_VULKAN_MEMORY_MODEL_EXTENSION_NAME = "VK_KHR_vulkan_memory_model";
	public const string VK_KHR_SHADER_TERMINATE_INVOCATION_EXTENSION_NAME = "VK_KHR_shader_terminate_invocation";
	public const string VK_KHR_FRAGMENT_SHADING_RATE_EXTENSION_NAME = "VK_KHR_fragment_shading_rate";
	public const string VK_KHR_DYNAMIC_RENDERING_LOCAL_READ_EXTENSION_NAME = "VK_KHR_dynamic_rendering_local_read";
	public const string VK_KHR_SHADER_QUAD_CONTROL_EXTENSION_NAME = "VK_KHR_shader_quad_control";
	public const string VK_KHR_SPIRV_1_4_EXTENSION_NAME = "VK_KHR_spirv_1_4";
	public const string VK_KHR_SURFACE_PROTECTED_CAPABILITIES_EXTENSION_NAME = "VK_KHR_surface_protected_capabilities";
	public const string VK_KHR_SEPARATE_DEPTH_STENCIL_LAYOUTS_EXTENSION_NAME = "VK_KHR_separate_depth_stencil_layouts";
	public const string VK_KHR_PRESENT_WAIT_EXTENSION_NAME = "VK_KHR_present_wait";
	public const string VK_KHR_UNIFORM_BUFFER_STANDARD_LAYOUT_EXTENSION_NAME = "VK_KHR_uniform_buffer_standard_layout";
	public const string VK_KHR_BUFFER_DEVICE_ADDRESS_EXTENSION_NAME = "VK_KHR_buffer_device_address";
	public const string VK_KHR_DEFERRED_HOST_OPERATIONS_EXTENSION_NAME = "VK_KHR_deferred_host_operations";
	public const string VK_KHR_PIPELINE_EXECUTABLE_PROPERTIES_EXTENSION_NAME = "VK_KHR_pipeline_executable_properties";
	public const string VK_KHR_MAP_MEMORY_2_EXTENSION_NAME = "VK_KHR_map_memory2";
	public const string VK_KHR_SHADER_INTEGER_DOT_PRODUCT_EXTENSION_NAME = "VK_KHR_shader_integer_dot_product";
	public const string VK_KHR_PIPELINE_LIBRARY_EXTENSION_NAME = "VK_KHR_pipeline_library";
	public const string VK_KHR_SHADER_NON_SEMANTIC_INFO_EXTENSION_NAME = "VK_KHR_shader_non_semantic_info";
	public const string VK_KHR_PRESENT_ID_EXTENSION_NAME = "VK_KHR_present_id";
	public const string VK_KHR_VIDEO_ENCODE_QUEUE_EXTENSION_NAME = "VK_KHR_video_encode_queue";
	public const string VK_KHR_SYNCHRONIZATION_2_EXTENSION_NAME = "VK_KHR_synchronization2";
	public const string VK_KHR_FRAGMENT_SHADER_BARYCENTRIC_EXTENSION_NAME = "VK_KHR_fragment_shader_barycentric";
	public const string VK_KHR_SHADER_SUBGROUP_UNIFORM_CONTROL_FLOW_EXTENSION_NAME = "VK_KHR_shader_subgroup_uniform_control_flow";
	public const string VK_KHR_ZERO_INITIALIZE_WORKGROUP_MEMORY_EXTENSION_NAME = "VK_KHR_zero_initialize_workgroup_memory";
	public const string VK_KHR_WORKGROUP_MEMORY_EXPLICIT_LAYOUT_EXTENSION_NAME = "VK_KHR_workgroup_memory_explicit_layout";
	public const string VK_KHR_COPY_COMMANDS_2_EXTENSION_NAME = "VK_KHR_copy_commands2";
	public const string VK_KHR_FORMAT_FEATURE_FLAGS_2_EXTENSION_NAME = "VK_KHR_format_feature_flags2";
	public const string VK_KHR_RAY_TRACING_MAINTENANCE_1_EXTENSION_NAME = "VK_KHR_ray_tracing_maintenance1";
	public const string VK_KHR_PORTABILITY_ENUMERATION_EXTENSION_NAME = "VK_KHR_portability_enumeration";
	public const string VK_KHR_MAINTENANCE_4_EXTENSION_NAME = "VK_KHR_maintenance4";
	public const string VK_KHR_SHADER_SUBGROUP_ROTATE_EXTENSION_NAME = "VK_KHR_shader_subgroup_rotate";
	public const string VK_KHR_SHADER_MAXIMAL_RECONVERGENCE_EXTENSION_NAME = "VK_KHR_shader_maximal_reconvergence";
	public const string VK_KHR_MAINTENANCE_5_EXTENSION_NAME = "VK_KHR_maintenance5";
	public const string VK_KHR_RAY_TRACING_POSITION_FETCH_EXTENSION_NAME = "VK_KHR_ray_tracing_position_fetch";
	public const string VK_KHR_PIPELINE_BINARY_EXTENSION_NAME = "VK_KHR_pipeline_binary";
	public const string VK_KHR_COOPERATIVE_MATRIX_EXTENSION_NAME = "VK_KHR_cooperative_matrix";
	public const string VK_KHR_COMPUTE_SHADER_DERIVATIVES_EXTENSION_NAME = "VK_KHR_compute_shader_derivatives";
	public const string VK_KHR_VIDEO_DECODE_AV1_EXTENSION_NAME = "VK_KHR_video_decode_av1";
	public const string VK_KHR_VIDEO_ENCODE_AV1_EXTENSION_NAME = "VK_KHR_video_encode_av1";
	public const string VK_KHR_VIDEO_MAINTENANCE_1_EXTENSION_NAME = "VK_KHR_video_maintenance1";
	public const string VK_KHR_VERTEX_ATTRIBUTE_DIVISOR_EXTENSION_NAME = "VK_KHR_vertex_attribute_divisor";
	public const string VK_KHR_LOAD_STORE_OP_NONE_EXTENSION_NAME = "VK_KHR_load_store_op_none";
	public const string VK_KHR_SHADER_FLOAT_CONTROLS_2_EXTENSION_NAME = "VK_KHR_shader_float_controls2";
	public const string VK_KHR_INDEX_TYPE_UINT8_EXTENSION_NAME = "VK_KHR_index_type_uint8";
	public const string VK_KHR_LINE_RASTERIZATION_EXTENSION_NAME = "VK_KHR_line_rasterization";
	public const string VK_KHR_CALIBRATED_TIMESTAMPS_EXTENSION_NAME = "VK_KHR_calibrated_timestamps";
	public const string VK_KHR_SHADER_EXPECT_ASSUME_EXTENSION_NAME = "VK_KHR_shader_expect_assume";
	public const string VK_KHR_MAINTENANCE_6_EXTENSION_NAME = "VK_KHR_maintenance6";
	public const string VK_KHR_VIDEO_ENCODE_QUANTIZATION_MAP_EXTENSION_NAME = "VK_KHR_video_encode_quantization_map";
	public const string VK_KHR_SHADER_RELAXED_EXTENDED_INSTRUCTION_EXTENSION_NAME = "VK_KHR_shader_relaxed_extended_instruction";
	public const string VK_KHR_MAINTENANCE_7_EXTENSION_NAME = "VK_KHR_maintenance7";
	public const string VK_KHR_MAINTENANCE_8_EXTENSION_NAME = "VK_KHR_maintenance8";
	public const string VK_KHR_VIDEO_MAINTENANCE_2_EXTENSION_NAME = "VK_KHR_video_maintenance2";
	public const string VK_KHR_DEPTH_CLAMP_ZERO_ONE_EXTENSION_NAME = "VK_KHR_depth_clamp_zero_one";
	public const string VK_KHR_ROBUSTNESS_2_EXTENSION_NAME = "VK_KHR_robustness2";
	public const string VK_EXT_DEBUG_REPORT_EXTENSION_NAME = "VK_EXT_debug_report";
	public const string VK_NV_GLSL_SHADER_EXTENSION_NAME = "VK_NV_glsl_shader";
	public const string VK_EXT_DEPTH_RANGE_UNRESTRICTED_EXTENSION_NAME = "VK_EXT_depth_range_unrestricted";
	public const string VK_IMG_FILTER_CUBIC_EXTENSION_NAME = "VK_IMG_filter_cubic";
	public const string VK_AMD_RASTERIZATION_ORDER_EXTENSION_NAME = "VK_AMD_rasterization_order";
	public const string VK_AMD_SHADER_TRINARY_MINMAX_EXTENSION_NAME = "VK_AMD_shader_trinary_minmax";
	public const string VK_AMD_SHADER_EXPLICIT_VERTEX_PARAMETER_EXTENSION_NAME = "VK_AMD_shader_explicit_vertex_parameter";
	public const string VK_EXT_DEBUG_MARKER_EXTENSION_NAME = "VK_EXT_debug_marker";
	public const string VK_AMD_GCN_SHADER_EXTENSION_NAME = "VK_AMD_gcn_shader";
	public const string VK_NV_DEDICATED_ALLOCATION_EXTENSION_NAME = "VK_NV_dedicated_allocation";
	public const string VK_EXT_TRANSFORM_FEEDBACK_EXTENSION_NAME = "VK_EXT_transform_feedback";
	public const string VK_NVX_BINARY_IMPORT_EXTENSION_NAME = "VK_NVX_binary_import";
	public const string VK_NVX_IMAGE_VIEW_HANDLE_EXTENSION_NAME = "VK_NVX_image_view_handle";
	public const string VK_AMD_DRAW_INDIRECT_COUNT_EXTENSION_NAME = "VK_AMD_draw_indirect_count";
	public const string VK_AMD_NEGATIVE_VIEWPORT_HEIGHT_EXTENSION_NAME = "VK_AMD_negative_viewport_height";
	public const string VK_AMD_GPU_SHADER_HALF_FLOAT_EXTENSION_NAME = "VK_AMD_gpu_shader_half_float";
	public const string VK_AMD_SHADER_BALLOT_EXTENSION_NAME = "VK_AMD_shader_ballot";
	public const string VK_AMD_TEXTURE_GATHER_BIAS_LOD_EXTENSION_NAME = "VK_AMD_texture_gather_bias_lod";
	public const string VK_AMD_SHADER_INFO_EXTENSION_NAME = "VK_AMD_shader_info";
	public const string VK_AMD_SHADER_IMAGE_LOAD_STORE_LOD_EXTENSION_NAME = "VK_AMD_shader_image_load_store_lod";
	public const string VK_NV_CORNER_SAMPLED_IMAGE_EXTENSION_NAME = "VK_NV_corner_sampled_image";
	public const string VK_IMG_FORMAT_PVRTC_EXTENSION_NAME = "VK_IMG_format_pvrtc";
	public const string VK_NV_EXTERNAL_MEMORY_CAPABILITIES_EXTENSION_NAME = "VK_NV_external_memory_capabilities";
	public const string VK_NV_EXTERNAL_MEMORY_EXTENSION_NAME = "VK_NV_external_memory";
	public const string VK_EXT_VALIDATION_FLAGS_EXTENSION_NAME = "VK_EXT_validation_flags";
	public const string VK_EXT_SHADER_SUBGROUP_BALLOT_EXTENSION_NAME = "VK_EXT_shader_subgroup_ballot";
	public const string VK_EXT_SHADER_SUBGROUP_VOTE_EXTENSION_NAME = "VK_EXT_shader_subgroup_vote";
	public const string VK_EXT_TEXTURE_COMPRESSION_ASTC_HDR_EXTENSION_NAME = "VK_EXT_texture_compression_astc_hdr";
	public const string VK_EXT_ASTC_DECODE_MODE_EXTENSION_NAME = "VK_EXT_astc_decode_mode";
	public const string VK_EXT_PIPELINE_ROBUSTNESS_EXTENSION_NAME = "VK_EXT_pipeline_robustness";
	public const string VK_EXT_CONDITIONAL_RENDERING_EXTENSION_NAME = "VK_EXT_conditional_rendering";
	public const string VK_NV_CLIP_SPACE_W_SCALING_EXTENSION_NAME = "VK_NV_clip_space_w_scaling";
	public const string VK_EXT_DIRECT_MODE_DISPLAY_EXTENSION_NAME = "VK_EXT_direct_mode_display";
	public const string VK_EXT_DISPLAY_SURFACE_COUNTER_EXTENSION_NAME = "VK_EXT_display_surface_counter";
	public const string VK_EXT_DISPLAY_CONTROL_EXTENSION_NAME = "VK_EXT_display_control";
	public const string VK_GOOGLE_DISPLAY_TIMING_EXTENSION_NAME = "VK_GOOGLE_display_timing";
	public const string VK_NV_SAMPLE_MASK_OVERRIDE_COVERAGE_EXTENSION_NAME = "VK_NV_sample_mask_override_coverage";
	public const string VK_NV_GEOMETRY_SHADER_PASSTHROUGH_EXTENSION_NAME = "VK_NV_geometry_shader_passthrough";
	public const string VK_NV_VIEWPORT_ARRAY_2_EXTENSION_NAME = "VK_NV_viewport_array2";
	public const string VK_NV_VIEWPORT_ARRAY2_EXTENSION_NAME = VK_NV_VIEWPORT_ARRAY_2_EXTENSION_NAME;
	public const string VK_NVX_MULTIVIEW_PER_VIEW_ATTRIBUTES_EXTENSION_NAME = "VK_NVX_multiview_per_view_attributes";
	public const string VK_NV_VIEWPORT_SWIZZLE_EXTENSION_NAME = "VK_NV_viewport_swizzle";
	public const string VK_EXT_DISCARD_RECTANGLES_EXTENSION_NAME = "VK_EXT_discard_rectangles";
	public const string VK_EXT_CONSERVATIVE_RASTERIZATION_EXTENSION_NAME = "VK_EXT_conservative_rasterization";
	public const string VK_EXT_DEPTH_CLIP_ENABLE_EXTENSION_NAME = "VK_EXT_depth_clip_enable";
	public const string VK_EXT_SWAPCHAIN_COLOR_SPACE_EXTENSION_NAME = "VK_EXT_swapchain_colorspace";
	public const string VK_EXT_HDR_METADATA_EXTENSION_NAME = "VK_EXT_hdr_metadata";
	public const string VK_IMG_RELAXED_LINE_RASTERIZATION_EXTENSION_NAME = "VK_IMG_relaxed_line_rasterization";
	public const string VK_EXT_EXTERNAL_MEMORY_DMA_BUF_EXTENSION_NAME = "VK_EXT_external_memory_dma_buf";
	public const string VK_EXT_QUEUE_FAMILY_FOREIGN_EXTENSION_NAME = "VK_EXT_queue_family_foreign";
	public const string VK_EXT_DEBUG_UTILS_EXTENSION_NAME = "VK_EXT_debug_utils";
	public const string VK_EXT_SAMPLER_FILTER_MINMAX_EXTENSION_NAME = "VK_EXT_sampler_filter_minmax";
	public const string VK_AMD_GPU_SHADER_INT16_EXTENSION_NAME = "VK_AMD_gpu_shader_int16";
	public const string VK_AMD_MIXED_ATTACHMENT_SAMPLES_EXTENSION_NAME = "VK_AMD_mixed_attachment_samples";
	public const string VK_AMD_SHADER_FRAGMENT_MASK_EXTENSION_NAME = "VK_AMD_shader_fragment_mask";
	public const string VK_EXT_INLINE_UNIFORM_BLOCK_EXTENSION_NAME = "VK_EXT_inline_uniform_block";
	public const string VK_EXT_SHADER_STENCIL_EXPORT_EXTENSION_NAME = "VK_EXT_shader_stencil_export";
	public const string VK_EXT_SAMPLE_LOCATIONS_EXTENSION_NAME = "VK_EXT_sample_locations";
	public const string VK_EXT_BLEND_OPERATION_ADVANCED_EXTENSION_NAME = "VK_EXT_blend_operation_advanced";
	public const string VK_NV_FRAGMENT_COVERAGE_TO_COLOR_EXTENSION_NAME = "VK_NV_fragment_coverage_to_color";
	public const string VK_NV_FRAMEBUFFER_MIXED_SAMPLES_EXTENSION_NAME = "VK_NV_framebuffer_mixed_samples";
	public const string VK_NV_FILL_RECTANGLE_EXTENSION_NAME = "VK_NV_fill_rectangle";
	public const string VK_NV_SHADER_SM_BUILTINS_EXTENSION_NAME = "VK_NV_shader_sm_builtins";
	public const string VK_EXT_POST_DEPTH_COVERAGE_EXTENSION_NAME = "VK_EXT_post_depth_coverage";
	public const string VK_EXT_IMAGE_DRM_FORMAT_MODIFIER_EXTENSION_NAME = "VK_EXT_image_drm_format_modifier";
	public const string VK_EXT_VALIDATION_CACHE_EXTENSION_NAME = "VK_EXT_validation_cache";
	public const string VK_EXT_DESCRIPTOR_INDEXING_EXTENSION_NAME = "VK_EXT_descriptor_indexing";
	public const string VK_EXT_SHADER_VIEWPORT_INDEX_LAYER_EXTENSION_NAME = "VK_EXT_shader_viewport_index_layer";
	public const string VK_NV_SHADING_RATE_IMAGE_EXTENSION_NAME = "VK_NV_shading_rate_image";
	public const string VK_NV_RAY_TRACING_EXTENSION_NAME = "VK_NV_ray_tracing";
	public const string VK_NV_REPRESENTATIVE_FRAGMENT_TEST_EXTENSION_NAME = "VK_NV_representative_fragment_test";
	public const string VK_EXT_FILTER_CUBIC_EXTENSION_NAME = "VK_EXT_filter_cubic";
	public const string VK_QCOM_RENDER_PASS_SHADER_RESOLVE_EXTENSION_NAME = "VK_QCOM_render_pass_shader_resolve";
	public const string VK_EXT_GLOBAL_PRIORITY_EXTENSION_NAME = "VK_EXT_global_priority";
	public const string VK_EXT_EXTERNAL_MEMORY_HOST_EXTENSION_NAME = "VK_EXT_external_memory_host";
	public const string VK_AMD_BUFFER_MARKER_EXTENSION_NAME = "VK_AMD_buffer_marker";
	public const string VK_AMD_PIPELINE_COMPILER_CONTROL_EXTENSION_NAME = "VK_AMD_pipeline_compiler_control";
	public const string VK_EXT_CALIBRATED_TIMESTAMPS_EXTENSION_NAME = "VK_EXT_calibrated_timestamps";
	public const string VK_AMD_SHADER_CORE_PROPERTIES_EXTENSION_NAME = "VK_AMD_shader_core_properties";
	public const string VK_AMD_MEMORY_OVERALLOCATION_BEHAVIOR_EXTENSION_NAME = "VK_AMD_memory_overallocation_behavior";
	public const string VK_EXT_VERTEX_ATTRIBUTE_DIVISOR_EXTENSION_NAME = "VK_EXT_vertex_attribute_divisor";
	public const string VK_EXT_PIPELINE_CREATION_FEEDBACK_EXTENSION_NAME = "VK_EXT_pipeline_creation_feedback";
	public const string VK_NV_SHADER_SUBGROUP_PARTITIONED_EXTENSION_NAME = "VK_NV_shader_subgroup_partitioned";
	public const string VK_NV_COMPUTE_SHADER_DERIVATIVES_EXTENSION_NAME = "VK_NV_compute_shader_derivatives";
	public const string VK_NV_MESH_SHADER_EXTENSION_NAME = "VK_NV_mesh_shader";
	public const string VK_NV_FRAGMENT_SHADER_BARYCENTRIC_EXTENSION_NAME = "VK_NV_fragment_shader_barycentric";
	public const string VK_NV_SHADER_IMAGE_FOOTPRINT_EXTENSION_NAME = "VK_NV_shader_image_footprint";
	public const string VK_NV_SCISSOR_EXCLUSIVE_EXTENSION_NAME = "VK_NV_scissor_exclusive";
	public const string VK_NV_DEVICE_DIAGNOSTIC_CHECKPOINTS_EXTENSION_NAME = "VK_NV_device_diagnostic_checkpoints";
	public const string VK_INTEL_SHADER_INTEGER_FUNCTIONS_2_EXTENSION_NAME = "VK_INTEL_shader_integer_functions2";
	public const string VK_INTEL_PERFORMANCE_QUERY_EXTENSION_NAME = "VK_INTEL_performance_query";
	public const string VK_EXT_PCI_BUS_INFO_EXTENSION_NAME = "VK_EXT_pci_bus_info";
	public const string VK_AMD_DISPLAY_NATIVE_HDR_EXTENSION_NAME = "VK_AMD_display_native_hdr";
	public const string VK_EXT_FRAGMENT_DENSITY_MAP_EXTENSION_NAME = "VK_EXT_fragment_density_map";
	public const string VK_EXT_SCALAR_BLOCK_LAYOUT_EXTENSION_NAME = "VK_EXT_scalar_block_layout";
	public const string VK_GOOGLE_HLSL_FUNCTIONALITY_1_EXTENSION_NAME = "VK_GOOGLE_hlsl_functionality1";
	public const string VK_GOOGLE_HLSL_FUNCTIONALITY1_EXTENSION_NAME = VK_GOOGLE_HLSL_FUNCTIONALITY_1_EXTENSION_NAME;
	public const string VK_GOOGLE_DECORATE_STRING_EXTENSION_NAME = "VK_GOOGLE_decorate_string";
	public const string VK_EXT_SUBGROUP_SIZE_CONTROL_EXTENSION_NAME = "VK_EXT_subgroup_size_control";
	public const string VK_AMD_SHADER_CORE_PROPERTIES_2_EXTENSION_NAME = "VK_AMD_shader_core_properties2";
	public const string VK_AMD_DEVICE_COHERENT_MEMORY_EXTENSION_NAME = "VK_AMD_device_coherent_memory";
	public const string VK_EXT_SHADER_IMAGE_ATOMIC_INT64_EXTENSION_NAME = "VK_EXT_shader_image_atomic_int64";
	public const string VK_EXT_MEMORY_BUDGET_EXTENSION_NAME = "VK_EXT_memory_budget";
	public const string VK_EXT_MEMORY_PRIORITY_EXTENSION_NAME = "VK_EXT_memory_priority";
	public const string VK_NV_DEDICATED_ALLOCATION_IMAGE_ALIASING_EXTENSION_NAME = "VK_NV_dedicated_allocation_image_aliasing";
	public const string VK_EXT_BUFFER_DEVICE_ADDRESS_EXTENSION_NAME = "VK_EXT_buffer_device_address";
	public const string VK_EXT_TOOLING_INFO_EXTENSION_NAME = "VK_EXT_tooling_info";
	public const string VK_EXT_SEPARATE_STENCIL_USAGE_EXTENSION_NAME = "VK_EXT_separate_stencil_usage";
	public const string VK_EXT_VALIDATION_FEATURES_EXTENSION_NAME = "VK_EXT_validation_features";
	public const string VK_NV_COOPERATIVE_MATRIX_EXTENSION_NAME = "VK_NV_cooperative_matrix";
	public const string VK_NV_COVERAGE_REDUCTION_MODE_EXTENSION_NAME = "VK_NV_coverage_reduction_mode";
	public const string VK_EXT_FRAGMENT_SHADER_INTERLOCK_EXTENSION_NAME = "VK_EXT_fragment_shader_interlock";
	public const string VK_EXT_YCBCR_IMAGE_ARRAYS_EXTENSION_NAME = "VK_EXT_ycbcr_image_arrays";
	public const string VK_EXT_PROVOKING_VERTEX_EXTENSION_NAME = "VK_EXT_provoking_vertex";
	public const string VK_EXT_HEADLESS_SURFACE_EXTENSION_NAME = "VK_EXT_headless_surface";
	public const string VK_EXT_LINE_RASTERIZATION_EXTENSION_NAME = "VK_EXT_line_rasterization";
	public const string VK_EXT_SHADER_ATOMIC_FLOAT_EXTENSION_NAME = "VK_EXT_shader_atomic_float";
	public const string VK_EXT_HOST_QUERY_RESET_EXTENSION_NAME = "VK_EXT_host_query_reset";
	public const string VK_EXT_INDEX_TYPE_UINT8_EXTENSION_NAME = "VK_EXT_index_type_uint8";
	public const string VK_EXT_EXTENDED_DYNAMIC_STATE_EXTENSION_NAME = "VK_EXT_extended_dynamic_state";
	public const string VK_EXT_HOST_IMAGE_COPY_EXTENSION_NAME = "VK_EXT_host_image_copy";
	public const string VK_EXT_MAP_MEMORY_PLACED_EXTENSION_NAME = "VK_EXT_map_memory_placed";
	public const string VK_EXT_SHADER_ATOMIC_FLOAT_2_EXTENSION_NAME = "VK_EXT_shader_atomic_float2";
	public const string VK_EXT_SURFACE_MAINTENANCE_1_EXTENSION_NAME = "VK_EXT_surface_maintenance1";
	public const string VK_EXT_SWAPCHAIN_MAINTENANCE_1_EXTENSION_NAME = "VK_EXT_swapchain_maintenance1";
	public const string VK_EXT_SHADER_DEMOTE_TO_HELPER_INVOCATION_EXTENSION_NAME = "VK_EXT_shader_demote_to_helper_invocation";
	public const string VK_NV_DEVICE_GENERATED_COMMANDS_EXTENSION_NAME = "VK_NV_device_generated_commands";
	public const string VK_NV_INHERITED_VIEWPORT_SCISSOR_EXTENSION_NAME = "VK_NV_inherited_viewport_scissor";
	public const string VK_EXT_TEXEL_BUFFER_ALIGNMENT_EXTENSION_NAME = "VK_EXT_texel_buffer_alignment";
	public const string VK_QCOM_RENDER_PASS_TRANSFORM_EXTENSION_NAME = "VK_QCOM_render_pass_transform";
	public const string VK_EXT_DEPTH_BIAS_CONTROL_EXTENSION_NAME = "VK_EXT_depth_bias_control";
	public const string VK_EXT_DEVICE_MEMORY_REPORT_EXTENSION_NAME = "VK_EXT_device_memory_report";
	public const string VK_EXT_ACQUIRE_DRM_DISPLAY_EXTENSION_NAME = "VK_EXT_acquire_drm_display";
	public const string VK_EXT_ROBUSTNESS_2_EXTENSION_NAME = "VK_EXT_robustness2";
	public const string VK_EXT_CUSTOM_BORDER_COLOR_EXTENSION_NAME = "VK_EXT_custom_border_color";
	public const string VK_GOOGLE_USER_TYPE_EXTENSION_NAME = "VK_GOOGLE_user_type";
	public const string VK_NV_PRESENT_BARRIER_EXTENSION_NAME = "VK_NV_present_barrier";
	public const string VK_EXT_PRIVATE_DATA_EXTENSION_NAME = "VK_EXT_private_data";
	public const string VK_EXT_PIPELINE_CREATION_CACHE_CONTROL_EXTENSION_NAME = "VK_EXT_pipeline_creation_cache_control";
	public const string VK_NV_DEVICE_DIAGNOSTICS_CONFIG_EXTENSION_NAME = "VK_NV_device_diagnostics_config";
	public const string VK_QCOM_RENDER_PASS_STORE_OPS_EXTENSION_NAME = "VK_QCOM_render_pass_store_ops";
	public const string VK_NV_CUDA_KERNEL_LAUNCH_EXTENSION_NAME = "VK_NV_cuda_kernel_launch";
	public const string VK_QCOM_TILE_SHADING_EXTENSION_NAME = "VK_QCOM_tile_shading";
	public const string VK_NV_LOW_LATENCY_EXTENSION_NAME = "VK_NV_low_latency";
	public const string VK_EXT_DESCRIPTOR_BUFFER_EXTENSION_NAME = "VK_EXT_descriptor_buffer";
	public const string VK_EXT_GRAPHICS_PIPELINE_LIBRARY_EXTENSION_NAME = "VK_EXT_graphics_pipeline_library";
	public const string VK_AMD_SHADER_EARLY_AND_LATE_FRAGMENT_TESTS_EXTENSION_NAME = "VK_AMD_shader_early_and_late_fragment_tests";
	public const string VK_NV_FRAGMENT_SHADING_RATE_ENUMS_EXTENSION_NAME = "VK_NV_fragment_shading_rate_enums";
	public const string VK_NV_RAY_TRACING_MOTION_BLUR_EXTENSION_NAME = "VK_NV_ray_tracing_motion_blur";
	public const string VK_EXT_YCBCR_2PLANE_444_FORMATS_EXTENSION_NAME = "VK_EXT_ycbcr_2plane_444_formats";
	public const string VK_EXT_FRAGMENT_DENSITY_MAP_2_EXTENSION_NAME = "VK_EXT_fragment_density_map2";
	public const string VK_QCOM_ROTATED_COPY_COMMANDS_EXTENSION_NAME = "VK_QCOM_rotated_copy_commands";
	public const string VK_EXT_IMAGE_ROBUSTNESS_EXTENSION_NAME = "VK_EXT_image_robustness";
	public const string VK_EXT_IMAGE_COMPRESSION_CONTROL_EXTENSION_NAME = "VK_EXT_image_compression_control";
	public const string VK_EXT_ATTACHMENT_FEEDBACK_LOOP_LAYOUT_EXTENSION_NAME = "VK_EXT_attachment_feedback_loop_layout";
	public const string VK_EXT_4444_FORMATS_EXTENSION_NAME = "VK_EXT_4444_formats";
	public const string VK_EXT_DEVICE_FAULT_EXTENSION_NAME = "VK_EXT_device_fault";
	public const string VK_ARM_RASTERIZATION_ORDER_ATTACHMENT_ACCESS_EXTENSION_NAME = "VK_ARM_rasterization_order_attachment_access";
	public const string VK_EXT_RGBA10X6_FORMATS_EXTENSION_NAME = "VK_EXT_rgba10x6_formats";
	public const string VK_VALVE_MUTABLE_DESCRIPTOR_TYPE_EXTENSION_NAME = "VK_VALVE_mutable_descriptor_type";
	public const string VK_EXT_VERTEX_INPUT_DYNAMIC_STATE_EXTENSION_NAME = "VK_EXT_vertex_input_dynamic_state";
	public const string VK_EXT_PHYSICAL_DEVICE_DRM_EXTENSION_NAME = "VK_EXT_physical_device_drm";
	public const string VK_EXT_DEVICE_ADDRESS_BINDING_REPORT_EXTENSION_NAME = "VK_EXT_device_address_binding_report";
	public const string VK_EXT_DEPTH_CLIP_CONTROL_EXTENSION_NAME = "VK_EXT_depth_clip_control";
	public const string VK_EXT_PRIMITIVE_TOPOLOGY_LIST_RESTART_EXTENSION_NAME = "VK_EXT_primitive_topology_list_restart";
	public const string VK_EXT_PRESENT_MODE_FIFO_LATEST_READY_EXTENSION_NAME = "VK_EXT_present_mode_fifo_latest_ready";
	public const string VK_HUAWEI_SUBPASS_SHADING_EXTENSION_NAME = "VK_HUAWEI_subpass_shading";
	public const string VK_HUAWEI_INVOCATION_MASK_EXTENSION_NAME = "VK_HUAWEI_invocation_mask";
	public const string VK_NV_EXTERNAL_MEMORY_RDMA_EXTENSION_NAME = "VK_NV_external_memory_rdma";
	public const string VK_EXT_PIPELINE_PROPERTIES_EXTENSION_NAME = "VK_EXT_pipeline_properties";
	public const string VK_EXT_FRAME_BOUNDARY_EXTENSION_NAME = "VK_EXT_frame_boundary";
	public const string VK_EXT_MULTISAMPLED_RENDER_TO_SINGLE_SAMPLED_EXTENSION_NAME = "VK_EXT_multisampled_render_to_single_sampled";
	public const string VK_EXT_EXTENDED_DYNAMIC_STATE_2_EXTENSION_NAME = "VK_EXT_extended_dynamic_state2";
	public const string VK_EXT_COLOR_WRITE_ENABLE_EXTENSION_NAME = "VK_EXT_color_write_enable";
	public const string VK_EXT_PRIMITIVES_GENERATED_QUERY_EXTENSION_NAME = "VK_EXT_primitives_generated_query";
	public const string VK_EXT_GLOBAL_PRIORITY_QUERY_EXTENSION_NAME = "VK_EXT_global_priority_query";
	public const string VK_EXT_IMAGE_VIEW_MIN_LOD_EXTENSION_NAME = "VK_EXT_image_view_min_lod";
	public const string VK_EXT_MULTI_DRAW_EXTENSION_NAME = "VK_EXT_multi_draw";
	public const string VK_EXT_IMAGE_2D_VIEW_OF_3D_EXTENSION_NAME = "VK_EXT_image_2d_view_of_3d";
	public const string VK_EXT_SHADER_TILE_IMAGE_EXTENSION_NAME = "VK_EXT_shader_tile_image";
	public const string VK_EXT_OPACITY_MICROMAP_EXTENSION_NAME = "VK_EXT_opacity_micromap";
	public const string VK_EXT_LOAD_STORE_OP_NONE_EXTENSION_NAME = "VK_EXT_load_store_op_none";
	public const string VK_HUAWEI_CLUSTER_CULLING_SHADER_EXTENSION_NAME = "VK_HUAWEI_cluster_culling_shader";
	public const string VK_EXT_BORDER_COLOR_SWIZZLE_EXTENSION_NAME = "VK_EXT_border_color_swizzle";
	public const string VK_EXT_PAGEABLE_DEVICE_LOCAL_MEMORY_EXTENSION_NAME = "VK_EXT_pageable_device_local_memory";
	public const string VK_ARM_SHADER_CORE_PROPERTIES_EXTENSION_NAME = "VK_ARM_shader_core_properties";
	public const string VK_ARM_SCHEDULING_CONTROLS_EXTENSION_NAME = "VK_ARM_scheduling_controls";
	public const string VK_EXT_IMAGE_SLICED_VIEW_OF_3D_EXTENSION_NAME = "VK_EXT_image_sliced_view_of_3d";
	public const string VK_VALVE_DESCRIPTOR_SET_HOST_MAPPING_EXTENSION_NAME = "VK_VALVE_descriptor_set_host_mapping";
	public const string VK_EXT_DEPTH_CLAMP_ZERO_ONE_EXTENSION_NAME = "VK_EXT_depth_clamp_zero_one";
	public const string VK_EXT_NON_SEAMLESS_CUBE_MAP_EXTENSION_NAME = "VK_EXT_non_seamless_cube_map";
	public const string VK_ARM_RENDER_PASS_STRIPED_EXTENSION_NAME = "VK_ARM_render_pass_striped";
	public const string VK_QCOM_FRAGMENT_DENSITY_MAP_OFFSET_EXTENSION_NAME = "VK_QCOM_fragment_density_map_offset";
	public const string VK_NV_COPY_MEMORY_INDIRECT_EXTENSION_NAME = "VK_NV_copy_memory_indirect";
	public const string VK_NV_MEMORY_DECOMPRESSION_EXTENSION_NAME = "VK_NV_memory_decompression";
	public const string VK_NV_DEVICE_GENERATED_COMMANDS_COMPUTE_EXTENSION_NAME = "VK_NV_device_generated_commands_compute";
	public const string VK_NV_RAY_TRACING_LINEAR_SWEPT_SPHERES_EXTENSION_NAME = "VK_NV_ray_tracing_linear_swept_spheres";
	public const string VK_NV_LINEAR_COLOR_ATTACHMENT_EXTENSION_NAME = "VK_NV_linear_color_attachment";
	public const string VK_GOOGLE_SURFACELESS_QUERY_EXTENSION_NAME = "VK_GOOGLE_surfaceless_query";
	public const string VK_EXT_IMAGE_COMPRESSION_CONTROL_SWAPCHAIN_EXTENSION_NAME = "VK_EXT_image_compression_control_swapchain";
	public const string VK_QCOM_IMAGE_PROCESSING_EXTENSION_NAME = "VK_QCOM_image_processing";
	public const string VK_EXT_NESTED_COMMAND_BUFFER_EXTENSION_NAME = "VK_EXT_nested_command_buffer";
	public const string VK_EXT_EXTERNAL_MEMORY_ACQUIRE_UNMODIFIED_EXTENSION_NAME = "VK_EXT_external_memory_acquire_unmodified";
	public const string VK_EXT_EXTENDED_DYNAMIC_STATE_3_EXTENSION_NAME = "VK_EXT_extended_dynamic_state3";
	public const string VK_EXT_SUBPASS_MERGE_FEEDBACK_EXTENSION_NAME = "VK_EXT_subpass_merge_feedback";
	public const string VK_LUNARG_DIRECT_DRIVER_LOADING_EXTENSION_NAME = "VK_LUNARG_direct_driver_loading";
	public const string VK_EXT_SHADER_MODULE_IDENTIFIER_EXTENSION_NAME = "VK_EXT_shader_module_identifier";
	public const string VK_EXT_RASTERIZATION_ORDER_ATTACHMENT_ACCESS_EXTENSION_NAME = "VK_EXT_rasterization_order_attachment_access";
	public const string VK_NV_OPTICAL_FLOW_EXTENSION_NAME = "VK_NV_optical_flow";
	public const string VK_EXT_LEGACY_DITHERING_EXTENSION_NAME = "VK_EXT_legacy_dithering";
	public const string VK_EXT_PIPELINE_PROTECTED_ACCESS_EXTENSION_NAME = "VK_EXT_pipeline_protected_access";
	public const string VK_AMD_ANTI_LAG_EXTENSION_NAME = "VK_AMD_anti_lag";
	public const string VK_EXT_SHADER_OBJECT_EXTENSION_NAME = "VK_EXT_shader_object";
	public const string VK_QCOM_TILE_PROPERTIES_EXTENSION_NAME = "VK_QCOM_tile_properties";
	public const string VK_SEC_AMIGO_PROFILING_EXTENSION_NAME = "VK_SEC_amigo_profiling";
	public const string VK_QCOM_MULTIVIEW_PER_VIEW_VIEWPORTS_EXTENSION_NAME = "VK_QCOM_multiview_per_view_viewports";
	public const string VK_NV_RAY_TRACING_INVOCATION_REORDER_EXTENSION_NAME = "VK_NV_ray_tracing_invocation_reorder";
	public const string VK_NV_COOPERATIVE_VECTOR_EXTENSION_NAME = "VK_NV_cooperative_vector";
	public const string VK_NV_EXTENDED_SPARSE_ADDRESS_SPACE_EXTENSION_NAME = "VK_NV_extended_sparse_address_space";
	public const string VK_EXT_MUTABLE_DESCRIPTOR_TYPE_EXTENSION_NAME = "VK_EXT_mutable_descriptor_type";
	public const string VK_EXT_LEGACY_VERTEX_ATTRIBUTES_EXTENSION_NAME = "VK_EXT_legacy_vertex_attributes";
	public const string VK_EXT_LAYER_SETTINGS_EXTENSION_NAME = "VK_EXT_layer_settings";
	public const string VK_ARM_SHADER_CORE_BUILTINS_EXTENSION_NAME = "VK_ARM_shader_core_builtins";
	public const string VK_EXT_PIPELINE_LIBRARY_GROUP_HANDLES_EXTENSION_NAME = "VK_EXT_pipeline_library_group_handles";
	public const string VK_EXT_DYNAMIC_RENDERING_UNUSED_ATTACHMENTS_EXTENSION_NAME = "VK_EXT_dynamic_rendering_unused_attachments";
	public const string VK_NV_LOW_LATENCY_2_EXTENSION_NAME = "VK_NV_low_latency2";
	public const string VK_QCOM_MULTIVIEW_PER_VIEW_RENDER_AREAS_EXTENSION_NAME = "VK_QCOM_multiview_per_view_render_areas";
	public const string VK_NV_PER_STAGE_DESCRIPTOR_SET_EXTENSION_NAME = "VK_NV_per_stage_descriptor_set";
	public const string VK_QCOM_IMAGE_PROCESSING_2_EXTENSION_NAME = "VK_QCOM_image_processing2";
	public const string VK_QCOM_FILTER_CUBIC_WEIGHTS_EXTENSION_NAME = "VK_QCOM_filter_cubic_weights";
	public const string VK_QCOM_YCBCR_DEGAMMA_EXTENSION_NAME = "VK_QCOM_ycbcr_degamma";
	public const string VK_QCOM_FILTER_CUBIC_CLAMP_EXTENSION_NAME = "VK_QCOM_filter_cubic_clamp";
	public const string VK_EXT_ATTACHMENT_FEEDBACK_LOOP_DYNAMIC_STATE_EXTENSION_NAME = "VK_EXT_attachment_feedback_loop_dynamic_state";
	public const string VK_MSFT_LAYERED_DRIVER_EXTENSION_NAME = "VK_MSFT_layered_driver";
	public const string VK_NV_DESCRIPTOR_POOL_OVERALLOCATION_EXTENSION_NAME = "VK_NV_descriptor_pool_overallocation";
	public const string VK_QCOM_TILE_MEMORY_HEAP_EXTENSION_NAME = "VK_QCOM_tile_memory_heap";
	public const string VK_NV_DISPLAY_STEREO_EXTENSION_NAME = "VK_NV_display_stereo";
	public const string VK_NV_RAW_ACCESS_CHAINS_EXTENSION_NAME = "VK_NV_raw_access_chains";
	public const string VK_NV_EXTERNAL_COMPUTE_QUEUE_EXTENSION_NAME = "VK_NV_external_compute_queue";
	public const string VK_NV_COMMAND_BUFFER_INHERITANCE_EXTENSION_NAME = "VK_NV_command_buffer_inheritance";
	public const string VK_NV_SHADER_ATOMIC_FLOAT16_VECTOR_EXTENSION_NAME = "VK_NV_shader_atomic_float16_vector";
	public const string VK_EXT_SHADER_REPLICATED_COMPOSITES_EXTENSION_NAME = "VK_EXT_shader_replicated_composites";
	public const string VK_NV_RAY_TRACING_VALIDATION_EXTENSION_NAME = "VK_NV_ray_tracing_validation";
	public const string VK_NV_CLUSTER_ACCELERATION_STRUCTURE_EXTENSION_NAME = "VK_NV_cluster_acceleration_structure";
	public const string VK_NV_PARTITIONED_ACCELERATION_STRUCTURE_EXTENSION_NAME = "VK_NV_partitioned_acceleration_structure";
	public const string VK_EXT_DEVICE_GENERATED_COMMANDS_EXTENSION_NAME = "VK_EXT_device_generated_commands";
	public const string VK_MESA_IMAGE_ALIGNMENT_CONTROL_EXTENSION_NAME = "VK_MESA_image_alignment_control";
	public const string VK_EXT_DEPTH_CLAMP_CONTROL_EXTENSION_NAME = "VK_EXT_depth_clamp_control";
	public const string VK_HUAWEI_HDR_VIVID_EXTENSION_NAME = "VK_HUAWEI_hdr_vivid";
	public const string VK_NV_COOPERATIVE_MATRIX_2_EXTENSION_NAME = "VK_NV_cooperative_matrix2";
	public const string VK_ARM_PIPELINE_OPACITY_MICROMAP_EXTENSION_NAME = "VK_ARM_pipeline_opacity_micromap";
	public const string VK_EXT_VERTEX_ATTRIBUTE_ROBUSTNESS_EXTENSION_NAME = "VK_EXT_vertex_attribute_robustness";
	public const string VK_NV_PRESENT_METERING_EXTENSION_NAME = "VK_NV_present_metering";
	public const string VK_EXT_FRAGMENT_DENSITY_MAP_OFFSET_EXTENSION_NAME = "VK_EXT_fragment_density_map_offset";
	public const string VK_EXT_ZERO_INITIALIZE_DEVICE_MEMORY_EXTENSION_NAME = "VK_EXT_zero_initialize_device_memory";
	public const string VK_KHR_ACCELERATION_STRUCTURE_EXTENSION_NAME = "VK_KHR_acceleration_structure";
	public const string VK_KHR_RAY_TRACING_PIPELINE_EXTENSION_NAME = "VK_KHR_ray_tracing_pipeline";
	public const string VK_KHR_RAY_QUERY_EXTENSION_NAME = "VK_KHR_ray_query";
	public const string VK_EXT_MESH_SHADER_EXTENSION_NAME = "VK_EXT_mesh_shader";
	// public const uint  VK_DEFINE_HANDLE(object) = typedef ;
	public const uint  VK_HEADER_VERSION = 315 ;
	// public const uint VK_VERSION_MAJOR(version) = ((uint32_t)(version) ;
	// public const uint VK_VERSION_MINOR(version) = (((uint32_t)(version) ;
	// public const uint VK_VERSION_PATCH(version) = ((uint32_t)(version) ;
	public const uint VK_ATTACHMENT_UNUSED = (~0U);
	public const uint VK_FALSE = 0U;
	public const float VK_LOD_CLAMP_NONE = 1000.0F;
	public const uint VK_QUEUE_FAMILY_IGNORED = (~0U);
	public const uint VK_REMAINING_ARRAY_LAYERS = (~0U);
	public const uint VK_REMAINING_MIP_LEVELS = (~0U);
	public const uint VK_SUBPASS_EXTERNAL = (~0U);
	public const uint VK_TRUE = 1U;
	public const ulong VK_WHOLE_SIZE = (~0UL);
	public const uint VK_MAX_MEMORY_TYPES = 32U;
	public const uint VK_MAX_PHYSICAL_DEVICE_NAME_SIZE = 256U;
	public const uint VK_UUID_SIZE = 16U;
	public const uint VK_MAX_EXTENSION_NAME_SIZE = 256U;
	public const uint VK_MAX_DESCRIPTION_SIZE = 256U;
	public const uint VK_MAX_MEMORY_HEAPS = 16U;
	public const uint VK_MAX_DEVICE_GROUP_SIZE = 32U;
	public const uint VK_LUID_SIZE = 8U;
	public const uint VK_QUEUE_FAMILY_EXTERNAL = (~1U);
	public const uint VK_MAX_DRIVER_NAME_SIZE = 256U;
	public const uint VK_MAX_DRIVER_INFO_SIZE = 256U;
	public const uint VK_MAX_GLOBAL_PRIORITY_SIZE = 16U;
	public const uint VK_MAX_DEVICE_GROUP_SIZE_KHR = VK_MAX_DEVICE_GROUP_SIZE;
	public const uint VK_LUID_SIZE_KHR = VK_LUID_SIZE;
	public const uint VK_QUEUE_FAMILY_EXTERNAL_KHR = VK_QUEUE_FAMILY_EXTERNAL;
	public const uint VK_MAX_GLOBAL_PRIORITY_SIZE_KHR = VK_MAX_GLOBAL_PRIORITY_SIZE;
	public const uint VK_MAX_DRIVER_NAME_SIZE_KHR = VK_MAX_DRIVER_NAME_SIZE;
	public const uint VK_MAX_DRIVER_INFO_SIZE_KHR = VK_MAX_DRIVER_INFO_SIZE;
	public const uint VK_MAX_PIPELINE_BINARY_KEY_SIZE_KHR = 32U;
	public const uint VK_MAX_VIDEO_AV1_REFERENCES_PER_FRAME_KHR = 7U;
	public const uint VK_QUEUE_FAMILY_FOREIGN_EXT = (~2U);
	public const uint VK_SHADER_UNUSED_KHR = (~0U);
	public const uint VK_SHADER_UNUSED_NV = VK_SHADER_UNUSED_KHR;
	public const uint VK_MAX_GLOBAL_PRIORITY_SIZE_EXT = VK_MAX_GLOBAL_PRIORITY_SIZE;
	public const uint VK_REMAINING_3D_SLICES_EXT = (~0U);
	public const uint VK_MAX_SHADER_MODULE_IDENTIFIER_SIZE_EXT = 32U;
	public const uint VK_PARTITIONED_ACCELERATION_STRUCTURE_PARTITION_INDEX_GLOBAL_NV = (~0U);
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_NONE = 0UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_TOP_OF_PIPE_BIT = 0x00000001UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_DRAW_INDIRECT_BIT = 0x00000002UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_VERTEX_INPUT_BIT = 0x00000004UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_VERTEX_SHADER_BIT = 0x00000008UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_TESSELLATION_CONTROL_SHADER_BIT = 0x00000010UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_TESSELLATION_EVALUATION_SHADER_BIT = 0x00000020UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_GEOMETRY_SHADER_BIT = 0x00000040UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_FRAGMENT_SHADER_BIT = 0x00000080UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_EARLY_FRAGMENT_TESTS_BIT = 0x00000100UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_LATE_FRAGMENT_TESTS_BIT = 0x00000200UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_COLOR_ATTACHMENT_OUTPUT_BIT = 0x00000400UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_COMPUTE_SHADER_BIT = 0x00000800UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_ALL_TRANSFER_BIT = 0x00001000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_TRANSFER_BIT = 0x00001000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_BOTTOM_OF_PIPE_BIT = 0x00002000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_HOST_BIT = 0x00004000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_ALL_GRAPHICS_BIT = 0x00008000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_ALL_COMMANDS_BIT = 0x00010000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_COPY_BIT = 0x100000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_RESOLVE_BIT = 0x200000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_BLIT_BIT = 0x400000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_CLEAR_BIT = 0x800000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_INDEX_INPUT_BIT = 0x1000000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_VERTEX_ATTRIBUTE_INPUT_BIT = 0x2000000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_PRE_RASTERIZATION_SHADERS_BIT = 0x4000000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_VIDEO_DECODE_BIT_KHR = 0x04000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_VIDEO_ENCODE_BIT_KHR = 0x08000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_NONE_KHR = 0UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_TOP_OF_PIPE_BIT_KHR = 0x00000001UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_DRAW_INDIRECT_BIT_KHR = 0x00000002UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_VERTEX_INPUT_BIT_KHR = 0x00000004UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_VERTEX_SHADER_BIT_KHR = 0x00000008UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_TESSELLATION_CONTROL_SHADER_BIT_KHR = 0x00000010UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_TESSELLATION_EVALUATION_SHADER_BIT_KHR = 0x00000020UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_GEOMETRY_SHADER_BIT_KHR = 0x00000040UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_FRAGMENT_SHADER_BIT_KHR = 0x00000080UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_EARLY_FRAGMENT_TESTS_BIT_KHR = 0x00000100UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_LATE_FRAGMENT_TESTS_BIT_KHR = 0x00000200UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_COLOR_ATTACHMENT_OUTPUT_BIT_KHR = 0x00000400UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_COMPUTE_SHADER_BIT_KHR = 0x00000800UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_ALL_TRANSFER_BIT_KHR = 0x00001000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_TRANSFER_BIT_KHR = 0x00001000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_BOTTOM_OF_PIPE_BIT_KHR = 0x00002000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_HOST_BIT_KHR = 0x00004000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_ALL_GRAPHICS_BIT_KHR = 0x00008000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_ALL_COMMANDS_BIT_KHR = 0x00010000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_COPY_BIT_KHR = 0x100000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_RESOLVE_BIT_KHR = 0x200000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_BLIT_BIT_KHR = 0x400000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_CLEAR_BIT_KHR = 0x800000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_INDEX_INPUT_BIT_KHR = 0x1000000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_VERTEX_ATTRIBUTE_INPUT_BIT_KHR = 0x2000000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_PRE_RASTERIZATION_SHADERS_BIT_KHR = 0x4000000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_TRANSFORM_FEEDBACK_BIT_EXT = 0x01000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_CONDITIONAL_RENDERING_BIT_EXT = 0x00040000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_COMMAND_PREPROCESS_BIT_NV = 0x00020000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_COMMAND_PREPROCESS_BIT_EXT = 0x00020000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR = 0x00400000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_SHADING_RATE_IMAGE_BIT_NV = 0x00400000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_ACCELERATION_STRUCTURE_BUILD_BIT_KHR = 0x02000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_RAY_TRACING_SHADER_BIT_KHR = 0x00200000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_RAY_TRACING_SHADER_BIT_NV = 0x00200000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_ACCELERATION_STRUCTURE_BUILD_BIT_NV = 0x02000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_FRAGMENT_DENSITY_PROCESS_BIT_EXT = 0x00800000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_TASK_SHADER_BIT_NV = 0x00080000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_MESH_SHADER_BIT_NV = 0x00100000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_TASK_SHADER_BIT_EXT = 0x00080000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_MESH_SHADER_BIT_EXT = 0x00100000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_SUBPASS_SHADER_BIT_HUAWEI = 0x8000000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_SUBPASS_SHADING_BIT_HUAWEI = 0x8000000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_INVOCATION_MASK_BIT_HUAWEI = 0x10000000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_ACCELERATION_STRUCTURE_COPY_BIT_KHR = 0x10000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_MICROMAP_BUILD_BIT_EXT = 0x40000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_CLUSTER_CULING_SHADER_BIT_HUAWEI = 0x20000000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_OPTICAL_FLOW_BIT_NV = 0x20000000UL;
	public const VkPipelineStageFlagBits2 VK_PIPELINE_STAGE_2_CONVERT_COOPERATIVE_VECTOR_MATRIX_BIT_NV = 0x100000000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_NONE = 0UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_INDIRECT_COMMAND_READ_BIT = 0x00000001UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_INDEX_READ_BIT = 0x00000002UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_VERTEX_ATTRIBUTE_READ_BIT = 0x00000004UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_UNIFORM_READ_BIT = 0x00000008UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_INPUT_ATTACHMENT_READ_BIT = 0x00000010UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_SHADER_READ_BIT = 0x00000020UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_SHADER_WRITE_BIT = 0x00000040UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_COLOR_ATTACHMENT_READ_BIT = 0x00000080UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_COLOR_ATTACHMENT_WRITE_BIT = 0x00000100UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_DEPTH_STENCIL_ATTACHMENT_READ_BIT = 0x00000200UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT = 0x00000400UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_TRANSFER_READ_BIT = 0x00000800UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_TRANSFER_WRITE_BIT = 0x00001000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_HOST_READ_BIT = 0x00002000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_HOST_WRITE_BIT = 0x00004000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_MEMORY_READ_BIT = 0x00008000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_MEMORY_WRITE_BIT = 0x00010000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_SHADER_SAMPLED_READ_BIT = 0x100000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_SHADER_STORAGE_READ_BIT = 0x200000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_SHADER_STORAGE_WRITE_BIT = 0x400000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_VIDEO_DECODE_READ_BIT_KHR = 0x800000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_VIDEO_DECODE_WRITE_BIT_KHR = 0x1000000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_VIDEO_ENCODE_READ_BIT_KHR = 0x2000000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_VIDEO_ENCODE_WRITE_BIT_KHR = 0x4000000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_SHADER_TILE_ATTACHMENT_READ_BIT_QCOM = 0x8000000000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_SHADER_TILE_ATTACHMENT_WRITE_BIT_QCOM = 0x10000000000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_NONE_KHR = 0UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_INDIRECT_COMMAND_READ_BIT_KHR = 0x00000001UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_INDEX_READ_BIT_KHR = 0x00000002UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_VERTEX_ATTRIBUTE_READ_BIT_KHR = 0x00000004UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_UNIFORM_READ_BIT_KHR = 0x00000008UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_INPUT_ATTACHMENT_READ_BIT_KHR = 0x00000010UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_SHADER_READ_BIT_KHR = 0x00000020UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_SHADER_WRITE_BIT_KHR = 0x00000040UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_COLOR_ATTACHMENT_READ_BIT_KHR = 0x00000080UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_COLOR_ATTACHMENT_WRITE_BIT_KHR = 0x00000100UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_DEPTH_STENCIL_ATTACHMENT_READ_BIT_KHR = 0x00000200UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT_KHR = 0x00000400UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_TRANSFER_READ_BIT_KHR = 0x00000800UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_TRANSFER_WRITE_BIT_KHR = 0x00001000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_HOST_READ_BIT_KHR = 0x00002000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_HOST_WRITE_BIT_KHR = 0x00004000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_MEMORY_READ_BIT_KHR = 0x00008000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_MEMORY_WRITE_BIT_KHR = 0x00010000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_SHADER_SAMPLED_READ_BIT_KHR = 0x100000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_SHADER_STORAGE_READ_BIT_KHR = 0x200000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_SHADER_STORAGE_WRITE_BIT_KHR = 0x400000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_TRANSFORM_FEEDBACK_WRITE_BIT_EXT = 0x02000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_TRANSFORM_FEEDBACK_COUNTER_READ_BIT_EXT = 0x04000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_TRANSFORM_FEEDBACK_COUNTER_WRITE_BIT_EXT = 0x08000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_CONDITIONAL_RENDERING_READ_BIT_EXT = 0x00100000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_COMMAND_PREPROCESS_READ_BIT_NV = 0x00020000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_COMMAND_PREPROCESS_WRITE_BIT_NV = 0x00040000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_COMMAND_PREPROCESS_READ_BIT_EXT = 0x00020000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_COMMAND_PREPROCESS_WRITE_BIT_EXT = 0x00040000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_FRAGMENT_SHADING_RATE_ATTACHMENT_READ_BIT_KHR = 0x00800000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_SHADING_RATE_IMAGE_READ_BIT_NV = 0x00800000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_ACCELERATION_STRUCTURE_READ_BIT_KHR = 0x00200000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_ACCELERATION_STRUCTURE_WRITE_BIT_KHR = 0x00400000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_ACCELERATION_STRUCTURE_READ_BIT_NV = 0x00200000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_ACCELERATION_STRUCTURE_WRITE_BIT_NV = 0x00400000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_FRAGMENT_DENSITY_MAP_READ_BIT_EXT = 0x01000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_COLOR_ATTACHMENT_READ_NONCOHERENT_BIT_EXT = 0x00080000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_DESCRIPTOR_BUFFER_READ_BIT_EXT = 0x20000000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_INVOCATION_MASK_READ_BIT_HUAWEI = 0x8000000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_SHADER_BINDING_TABLE_READ_BIT_KHR = 0x10000000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_MICROMAP_READ_BIT_EXT = 0x100000000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_MICROMAP_WRITE_BIT_EXT = 0x200000000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_OPTICAL_FLOW_READ_BIT_NV = 0x40000000000UL;
	public const VkAccessFlagBits2 VK_ACCESS_2_OPTICAL_FLOW_WRITE_BIT_NV = 0x80000000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_BIT = 0x00000001UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_STORAGE_IMAGE_BIT = 0x00000002UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_STORAGE_IMAGE_ATOMIC_BIT = 0x00000004UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_UNIFORM_TEXEL_BUFFER_BIT = 0x00000008UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_STORAGE_TEXEL_BUFFER_BIT = 0x00000010UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_STORAGE_TEXEL_BUFFER_ATOMIC_BIT = 0x00000020UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_VERTEX_BUFFER_BIT = 0x00000040UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_COLOR_ATTACHMENT_BIT = 0x00000080UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_COLOR_ATTACHMENT_BLEND_BIT = 0x00000100UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_DEPTH_STENCIL_ATTACHMENT_BIT = 0x00000200UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_BLIT_SRC_BIT = 0x00000400UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_BLIT_DST_BIT = 0x00000800UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_LINEAR_BIT = 0x00001000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_TRANSFER_SRC_BIT = 0x00004000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_TRANSFER_DST_BIT = 0x00008000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_MINMAX_BIT = 0x00010000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_MIDPOINT_CHROMA_SAMPLES_BIT = 0x00020000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_LINEAR_FILTER_BIT = 0x00040000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_SEPARATE_RECONSTRUCTION_FILTER_BIT = 0x00080000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_BIT = 0x00100000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_FORCEABLE_BIT = 0x00200000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_DISJOINT_BIT = 0x00400000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_COSITED_CHROMA_SAMPLES_BIT = 0x00800000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_STORAGE_READ_WITHOUT_FORMAT_BIT = 0x80000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_STORAGE_WRITE_WITHOUT_FORMAT_BIT = 0x100000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_DEPTH_COMPARISON_BIT = 0x200000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_CUBIC_BIT = 0x00002000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_HOST_IMAGE_TRANSFER_BIT = 0x400000000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_VIDEO_DECODE_OUTPUT_BIT_KHR = 0x02000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_VIDEO_DECODE_DPB_BIT_KHR = 0x04000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_ACCELERATION_STRUCTURE_VERTEX_BUFFER_BIT_KHR = 0x20000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_FRAGMENT_DENSITY_MAP_BIT_EXT = 0x01000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR = 0x40000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_HOST_IMAGE_TRANSFER_BIT_EXT = 0x400000000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_VIDEO_ENCODE_INPUT_BIT_KHR = 0x08000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_VIDEO_ENCODE_DPB_BIT_KHR = 0x10000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_BIT_KHR = 0x00000001UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_STORAGE_IMAGE_BIT_KHR = 0x00000002UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_STORAGE_IMAGE_ATOMIC_BIT_KHR = 0x00000004UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_UNIFORM_TEXEL_BUFFER_BIT_KHR = 0x00000008UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_STORAGE_TEXEL_BUFFER_BIT_KHR = 0x00000010UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_STORAGE_TEXEL_BUFFER_ATOMIC_BIT_KHR = 0x00000020UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_VERTEX_BUFFER_BIT_KHR = 0x00000040UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_COLOR_ATTACHMENT_BIT_KHR = 0x00000080UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_COLOR_ATTACHMENT_BLEND_BIT_KHR = 0x00000100UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_DEPTH_STENCIL_ATTACHMENT_BIT_KHR = 0x00000200UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_BLIT_SRC_BIT_KHR = 0x00000400UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_BLIT_DST_BIT_KHR = 0x00000800UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_LINEAR_BIT_KHR = 0x00001000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_TRANSFER_SRC_BIT_KHR = 0x00004000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_TRANSFER_DST_BIT_KHR = 0x00008000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_MIDPOINT_CHROMA_SAMPLES_BIT_KHR = 0x00020000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_LINEAR_FILTER_BIT_KHR = 0x00040000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_SEPARATE_RECONSTRUCTION_FILTER_BIT_KHR = 0x00080000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_BIT_KHR = 0x00100000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_FORCEABLE_BIT_KHR = 0x00200000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_DISJOINT_BIT_KHR = 0x00400000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_COSITED_CHROMA_SAMPLES_BIT_KHR = 0x00800000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_STORAGE_READ_WITHOUT_FORMAT_BIT_KHR = 0x80000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_STORAGE_WRITE_WITHOUT_FORMAT_BIT_KHR = 0x100000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_DEPTH_COMPARISON_BIT_KHR = 0x200000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_MINMAX_BIT_KHR = 0x00010000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_CUBIC_BIT_EXT = 0x00002000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_ACCELERATION_STRUCTURE_RADIUS_BUFFER_BIT_NV = 0x8000000000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_LINEAR_COLOR_ATTACHMENT_BIT_NV = 0x4000000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_WEIGHT_IMAGE_BIT_QCOM = 0x400000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_WEIGHT_SAMPLED_IMAGE_BIT_QCOM = 0x800000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_BLOCK_MATCHING_BIT_QCOM = 0x1000000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_BOX_FILTER_SAMPLED_BIT_QCOM = 0x2000000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_OPTICAL_FLOW_IMAGE_BIT_NV = 0x10000000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_OPTICAL_FLOW_VECTOR_BIT_NV = 0x20000000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_OPTICAL_FLOW_COST_BIT_NV = 0x40000000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_VIDEO_ENCODE_QUANTIZATION_DELTA_MAP_BIT_KHR = 0x2000000000000UL;
	public const VkFormatFeatureFlagBits2 VK_FORMAT_FEATURE_2_VIDEO_ENCODE_EMPHASIS_MAP_BIT_KHR = 0x4000000000000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_DISABLE_OPTIMIZATION_BIT = 0x00000001UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_ALLOW_DERIVATIVES_BIT = 0x00000002UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_DERIVATIVE_BIT = 0x00000004UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_VIEW_INDEX_FROM_DEVICE_INDEX_BIT = 0x00000008UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_DISPATCH_BASE_BIT = 0x00000010UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_FAIL_ON_PIPELINE_COMPILE_REQUIRED_BIT = 0x00000100UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_EARLY_RETURN_ON_FAILURE_BIT = 0x00000200UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_NO_PROTECTED_ACCESS_BIT = 0x08000000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_PROTECTED_ACCESS_ONLY_BIT = 0x40000000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_EXECUTION_GRAPH_BIT_AMDX = 0x100000000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_RAY_TRACING_SKIP_BUILT_IN_PRIMITIVES_BIT_KHR = 0x00001000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_RAY_TRACING_ALLOW_SPHERES_AND_LINEAR_SWEPT_SPHERES_BIT_NV = 0x200000000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_ENABLE_LEGACY_DITHERING_BIT_EXT = 0x400000000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_DISABLE_OPTIMIZATION_BIT_KHR = 0x00000001UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_ALLOW_DERIVATIVES_BIT_KHR = 0x00000002UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_DERIVATIVE_BIT_KHR = 0x00000004UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_VIEW_INDEX_FROM_DEVICE_INDEX_BIT_KHR = 0x00000008UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_DISPATCH_BASE_BIT_KHR = 0x00000010UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_DEFER_COMPILE_BIT_NV = 0x00000020UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_CAPTURE_STATISTICS_BIT_KHR = 0x00000040UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_CAPTURE_INTERNAL_REPRESENTATIONS_BIT_KHR = 0x00000080UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_FAIL_ON_PIPELINE_COMPILE_REQUIRED_BIT_KHR = 0x00000100UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_EARLY_RETURN_ON_FAILURE_BIT_KHR = 0x00000200UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_LINK_TIME_OPTIMIZATION_BIT_EXT = 0x00000400UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_RETAIN_LINK_TIME_OPTIMIZATION_INFO_BIT_EXT = 0x00800000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_LIBRARY_BIT_KHR = 0x00000800UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_RAY_TRACING_SKIP_TRIANGLES_BIT_KHR = 0x00001000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_RAY_TRACING_SKIP_AABBS_BIT_KHR = 0x00002000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_RAY_TRACING_NO_NUL_ANY_HIT_SHADERS_BIT_KHR = 0x00004000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_RAY_TRACING_NO_NUL_CLOSEST_HIT_SHADERS_BIT_KHR = 0x00008000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_RAY_TRACING_NO_NUL_MISS_SHADERS_BIT_KHR = 0x00010000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_RAY_TRACING_NO_NUL_INTERSECTION_SHADERS_BIT_KHR = 0x00020000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_RAY_TRACING_SHADER_GROUP_HANDLE_CAPTURE_REPLAY_BIT_KHR = 0x00080000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_INDIRECT_BINDABLE_BIT_NV = 0x00040000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_RAY_TRACING_ALLOW_MOTION_BIT_NV = 0x00100000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_RENDERING_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR = 0x00200000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_RENDERING_FRAGMENT_DENSITY_MAP_ATTACHMENT_BIT_EXT = 0x00400000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_RAY_TRACING_OPACITY_MICROMAP_BIT_EXT = 0x01000000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_COLOR_ATTACHMENT_FEEDBACK_LOOP_BIT_EXT = 0x02000000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_DEPTH_STENCIL_ATTACHMENT_FEEDBACK_LOOP_BIT_EXT = 0x04000000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_NO_PROTECTED_ACCESS_BIT_EXT = 0x08000000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_PROTECTED_ACCESS_ONLY_BIT_EXT = 0x40000000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_RAY_TRACING_DISPLACEMENT_MICROMAP_BIT_NV = 0x10000000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_DESCRIPTOR_BUFFER_BIT_EXT = 0x20000000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_DISALLOW_OPACITY_MICROMAP_BIT_ARM = 0x2000000000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_CAPTURE_DATA_BIT_KHR = 0x80000000UL;
	public const VkPipelineCreateFlagBits2 VK_PIPELINE_CREATE_2_INDIRECT_BINDABLE_BIT_EXT = 0x4000000000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_TRANSFER_SRC_BIT = 0x00000001UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_TRANSFER_DST_BIT = 0x00000002UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_UNIFORM_TEXEL_BUFFER_BIT = 0x00000004UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_STORAGE_TEXEL_BUFFER_BIT = 0x00000008UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_UNIFORM_BUFFER_BIT = 0x00000010UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_STORAGE_BUFFER_BIT = 0x00000020UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_INDEX_BUFFER_BIT = 0x00000040UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_VERTEX_BUFFER_BIT = 0x00000080UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_INDIRECT_BUFFER_BIT = 0x00000100UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_SHADER_DEVICE_ADDRESS_BIT = 0x00020000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_EXECUTION_GRAPH_SCRATCH_BIT_AMDX = 0x02000000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_TRANSFER_SRC_BIT_KHR = 0x00000001UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_TRANSFER_DST_BIT_KHR = 0x00000002UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_UNIFORM_TEXEL_BUFFER_BIT_KHR = 0x00000004UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_STORAGE_TEXEL_BUFFER_BIT_KHR = 0x00000008UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_UNIFORM_BUFFER_BIT_KHR = 0x00000010UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_STORAGE_BUFFER_BIT_KHR = 0x00000020UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_INDEX_BUFFER_BIT_KHR = 0x00000040UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_VERTEX_BUFFER_BIT_KHR = 0x00000080UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_INDIRECT_BUFFER_BIT_KHR = 0x00000100UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_CONDITIONAL_RENDERING_BIT_EXT = 0x00000200UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_SHADER_BINDING_TABLE_BIT_KHR = 0x00000400UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_RAY_TRACING_BIT_NV = 0x00000400UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_TRANSFORM_FEEDBACK_BUFFER_BIT_EXT = 0x00000800UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_TRANSFORM_FEEDBACK_COUNTER_BUFFER_BIT_EXT = 0x00001000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_VIDEO_DECODE_SRC_BIT_KHR = 0x00002000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_VIDEO_DECODE_DST_BIT_KHR = 0x00004000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_VIDEO_ENCODE_DST_BIT_KHR = 0x00008000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_VIDEO_ENCODE_SRC_BIT_KHR = 0x00010000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_SHADER_DEVICE_ADDRESS_BIT_KHR = 0x00020000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_ACCELERATION_STRUCTURE_BUILD_INPUT_READ_ONLY_BIT_KHR = 0x00080000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_ACCELERATION_STRUCTURE_STORAGE_BIT_KHR = 0x00100000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_SAMPLER_DESCRIPTOR_BUFFER_BIT_EXT = 0x00200000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_RESOURCE_DESCRIPTOR_BUFFER_BIT_EXT = 0x00400000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_PUSH_DESCRIPTORS_DESCRIPTOR_BUFFER_BIT_EXT = 0x04000000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_MICROMAP_BUILD_INPUT_READ_ONLY_BIT_EXT = 0x00800000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_MICROMAP_STORAGE_BIT_EXT = 0x01000000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_TILE_MEMORY_BIT_QCOM = 0x08000000UL;
	public const VkBufferUsageFlagBits2 VK_BUFFER_USAGE_2_PREPROCESS_BUFFER_BIT_EXT = 0x80000000UL;
	public const VkAccessFlagBits3KHR VK_ACCESS_3_NONE_KHR = 0UL;
	public const VkPhysicalDeviceSchedulingControlsFlagBitsARM VK_PHYSICAL_DEVICE_SCHEDULING_CONTROLS_SHADER_CORE_COUNT_ARM = 0x00000001UL;
	public const VkMemoryDecompressionMethodFlagBitsNV VK_MEMORY_DECOMPRESSION_METHOD_GDEFLATE_1_0_BIT_NV = 0x00000001UL;

}


public enum VkResult    {
    VK_SUCCESS = 0, 
    VK_NOT_READY = 1, 
    VK_TIMEOUT = 2, 
    VK_EVENT_SET = 3, 
    VK_EVENT_RESET = 4, 
    VK_INCOMPLETE = 5, 
    VK_ERROR_OUT_OF_HOST_MEMORY = -1, 
    VK_ERROR_OUT_OF_DEVICE_MEMORY = -2, 
    VK_ERROR_INITIALIZATION_FAILED = -3, 
    VK_ERROR_DEVICE_LOST = -4, 
    VK_ERROR_MEMORY_MAP_FAILED = -5, 
    VK_ERROR_LAYER_NOT_PRESENT = -6, 
    VK_ERROR_EXTENSION_NOT_PRESENT = -7, 
    VK_ERROR_FEATURE_NOT_PRESENT = -8, 
    VK_ERROR_INCOMPATIBLE_DRIVER = -9, 
    VK_ERROR_TOO_MANY_OBJECTS = -10, 
    VK_ERROR_FORMAT_NOT_SUPPORTED = -11, 
    VK_ERROR_FRAGMENTED_POOL = -12, 
    VK_ERROR_UNKNOWN = -13, 
    VK_ERROR_OUT_OF_POOL_MEMORY = -1000069000, 
    VK_ERROR_INVALID_EXTERNAL_HANDLE = -1000072003, 
    VK_ERROR_FRAGMENTATION = -1000161000, 
    VK_ERROR_INVALID_OPAQUE_CAPTURE_ADDRESS = -1000257000, 
    VK_PIPELINE_COMPILE_REQUIRED = 1000297000, 
    VK_ERROR_NOT_PERMITTED = -1000174001, 
    VK_ERROR_SURFACE_LOST_KHR = -1000000000, 
    VK_ERROR_NATIVE_WINDOW_IN_USE_KHR = -1000000001, 
    VK_SUBOPTIMAL_KHR = 1000001003, 
    VK_ERROR_OUT_OF_DATE_KHR = -1000001004, 
    VK_ERROR_INCOMPATIBLE_DISPLAY_KHR = -1000003001, 
    VK_ERROR_VALIDATION_FAILED_EXT = -1000011001, 
    VK_ERROR_INVALID_SHADER_NV = -1000012000, 
    VK_ERROR_IMAGE_USAGE_NOT_SUPPORTED_KHR = -1000023000, 
    VK_ERROR_VIDEO_PICTURE_LAYOUT_NOT_SUPPORTED_KHR = -1000023001, 
    VK_ERROR_VIDEO_PROFILE_OPERATION_NOT_SUPPORTED_KHR = -1000023002, 
    VK_ERROR_VIDEO_PROFILE_FORMAT_NOT_SUPPORTED_KHR = -1000023003, 
    VK_ERROR_VIDEO_PROFILE_CODEC_NOT_SUPPORTED_KHR = -1000023004, 
    VK_ERROR_VIDEO_STD_VERSION_NOT_SUPPORTED_KHR = -1000023005, 
    VK_ERROR_INVALID_DRM_FORMAT_MODIFIER_PLANE_LAYOUT_EXT = -1000158000, 
    VK_ERROR_FULL_SCREEN_EXCLUSIVE_MODE_LOST_EXT = -1000255000, 
    VK_THREAD_IDLE_KHR = 1000268000, 
    VK_THREAD_DONE_KHR = 1000268001, 
    VK_OPERATION_DEFERRED_KHR = 1000268002, 
    VK_OPERATION_NOT_DEFERRED_KHR = 1000268003, 
    VK_ERROR_INVALID_VIDEO_STD_PARAMETERS_KHR = -1000299000, 
    VK_ERROR_COMPRESSION_EXHAUSTED_EXT = -1000338000, 
    VK_INCOMPATIBLE_SHADER_BINARY_EXT = 1000482000, 
    VK_PIPELINE_BINARY_MISSING_KHR = 1000483000, 
    VK_ERROR_NOT_ENOUGH_SPACE_KHR = -1000483000, 
    VK_ERROR_OUT_OF_POOL_MEMORY_KHR = VK_ERROR_OUT_OF_POOL_MEMORY, 
    VK_ERROR_INVALID_EXTERNAL_HANDLE_KHR = VK_ERROR_INVALID_EXTERNAL_HANDLE, 
    VK_ERROR_FRAGMENTATION_EXT = VK_ERROR_FRAGMENTATION, 
    VK_ERROR_NOT_PERMITTED_EXT = VK_ERROR_NOT_PERMITTED, 
    VK_ERROR_NOT_PERMITTED_KHR = VK_ERROR_NOT_PERMITTED, 
    VK_ERROR_INVALID_DEVICE_ADDRESS_EXT = VK_ERROR_INVALID_OPAQUE_CAPTURE_ADDRESS, 
    VK_ERROR_INVALID_OPAQUE_CAPTURE_ADDRESS_KHR = VK_ERROR_INVALID_OPAQUE_CAPTURE_ADDRESS, 
    VK_PIPELINE_COMPILE_REQUIRED_EXT = VK_PIPELINE_COMPILE_REQUIRED, 
    VK_ERROR_PIPELINE_COMPILE_REQUIRED_EXT = VK_PIPELINE_COMPILE_REQUIRED, 
  // VK_ERROR_INCOMPATIBLE_SHADER_BINARY_EXT is a deprecated alias 
    VK_ERROR_INCOMPATIBLE_SHADER_BINARY_EXT = VK_INCOMPATIBLE_SHADER_BINARY_EXT, 
    VK_RESULT_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkStructureType : uint   {
    VK_STRUCTURE_TYPE_APPLICATION_INFO = 0, 
    VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO = 1, 
    VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO = 2, 
    VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO = 3, 
    VK_STRUCTURE_TYPE_SUBMIT_INFO = 4, 
    VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_INFO = 5, 
    VK_STRUCTURE_TYPE_MAPPED_MEMORY_RANGE = 6, 
    VK_STRUCTURE_TYPE_BIND_SPARSE_INFO = 7, 
    VK_STRUCTURE_TYPE_FENCE_CREATE_INFO = 8, 
    VK_STRUCTURE_TYPE_SEMAPHORE_CREATE_INFO = 9, 
    VK_STRUCTURE_TYPE_EVENT_CREATE_INFO = 10, 
    VK_STRUCTURE_TYPE_QUERY_POOL_CREATE_INFO = 11, 
    VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO = 12, 
    VK_STRUCTURE_TYPE_BUFFER_VIEW_CREATE_INFO = 13, 
    VK_STRUCTURE_TYPE_IMAGE_CREATE_INFO = 14, 
    VK_STRUCTURE_TYPE_IMAGE_VIEW_CREATE_INFO = 15, 
    VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO = 16, 
    VK_STRUCTURE_TYPE_PIPELINE_CACHE_CREATE_INFO = 17, 
    VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO = 18, 
    VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_STATE_CREATE_INFO = 19, 
    VK_STRUCTURE_TYPE_PIPELINE_INPUT_ASSEMBLY_STATE_CREATE_INFO = 20, 
    VK_STRUCTURE_TYPE_PIPELINE_TESSELLATION_STATE_CREATE_INFO = 21, 
    VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_STATE_CREATE_INFO = 22, 
    VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_CREATE_INFO = 23, 
    VK_STRUCTURE_TYPE_PIPELINE_MULTISAMPLE_STATE_CREATE_INFO = 24, 
    VK_STRUCTURE_TYPE_PIPELINE_DEPTH_STENCIL_STATE_CREATE_INFO = 25, 
    VK_STRUCTURE_TYPE_PIPELINE_COLOR_BLEND_STATE_CREATE_INFO = 26, 
    VK_STRUCTURE_TYPE_PIPELINE_DYNAMIC_STATE_CREATE_INFO = 27, 
    VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_CREATE_INFO = 28, 
    VK_STRUCTURE_TYPE_COMPUTE_PIPELINE_CREATE_INFO = 29, 
    VK_STRUCTURE_TYPE_PIPELINE_LAYOUT_CREATE_INFO = 30, 
    VK_STRUCTURE_TYPE_SAMPLER_CREATE_INFO = 31, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO = 32, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_CREATE_INFO = 33, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO = 34, 
    VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET = 35, 
    VK_STRUCTURE_TYPE_COPY_DESCRIPTOR_SET = 36, 
    VK_STRUCTURE_TYPE_FRAMEBUFFER_CREATE_INFO = 37, 
    VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO = 38, 
    VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO = 39, 
    VK_STRUCTURE_TYPE_COMMAND_BUFFER_ALLOCATE_INFO = 40, 
    VK_STRUCTURE_TYPE_COMMAND_BUFFER_INHERITANCE_INFO = 41, 
    VK_STRUCTURE_TYPE_COMMAND_BUFFER_BEGIN_INFO = 42, 
    VK_STRUCTURE_TYPE_RENDER_PASS_BEGIN_INFO = 43, 
    VK_STRUCTURE_TYPE_BUFFER_MEMORY_BARRIER = 44, 
    VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER = 45, 
    VK_STRUCTURE_TYPE_MEMORY_BARRIER = 46, 
    VK_STRUCTURE_TYPE_LOADER_INSTANCE_CREATE_INFO = 47, 
    VK_STRUCTURE_TYPE_LOADER_DEVICE_CREATE_INFO = 48, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SUBGROUP_PROPERTIES = 1000094000, 
    VK_STRUCTURE_TYPE_BIND_BUFFER_MEMORY_INFO = 1000157000, 
    VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_INFO = 1000157001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_16BIT_STORAGE_FEATURES = 1000083000, 
    VK_STRUCTURE_TYPE_MEMORY_DEDICATED_REQUIREMENTS = 1000127000, 
    VK_STRUCTURE_TYPE_MEMORY_DEDICATED_ALLOCATE_INFO = 1000127001, 
    VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_FLAGS_INFO = 1000060000, 
    VK_STRUCTURE_TYPE_DEVICE_GROUP_RENDER_PASS_BEGIN_INFO = 1000060003, 
    VK_STRUCTURE_TYPE_DEVICE_GROUP_COMMAND_BUFFER_BEGIN_INFO = 1000060004, 
    VK_STRUCTURE_TYPE_DEVICE_GROUP_SUBMIT_INFO = 1000060005, 
    VK_STRUCTURE_TYPE_DEVICE_GROUP_BIND_SPARSE_INFO = 1000060006, 
    VK_STRUCTURE_TYPE_BIND_BUFFER_MEMORY_DEVICE_GROUP_INFO = 1000060013, 
    VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_DEVICE_GROUP_INFO = 1000060014, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_GROUP_PROPERTIES = 1000070000, 
    VK_STRUCTURE_TYPE_DEVICE_GROUP_DEVICE_CREATE_INFO = 1000070001, 
    VK_STRUCTURE_TYPE_BUFFER_MEMORY_REQUIREMENTS_INFO_2 = 1000146000, 
    VK_STRUCTURE_TYPE_IMAGE_MEMORY_REQUIREMENTS_INFO_2 = 1000146001, 
    VK_STRUCTURE_TYPE_IMAGE_SPARSE_MEMORY_REQUIREMENTS_INFO_2 = 1000146002, 
    VK_STRUCTURE_TYPE_MEMORY_REQUIREMENTS_2 = 1000146003, 
    VK_STRUCTURE_TYPE_SPARSE_IMAGE_MEMORY_REQUIREMENTS_2 = 1000146004, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FEATURES_2 = 1000059000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROPERTIES_2 = 1000059001, 
    VK_STRUCTURE_TYPE_FORMAT_PROPERTIES_2 = 1000059002, 
    VK_STRUCTURE_TYPE_IMAGE_FORMAT_PROPERTIES_2 = 1000059003, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_FORMAT_INFO_2 = 1000059004, 
    VK_STRUCTURE_TYPE_QUEUE_FAMILY_PROPERTIES_2 = 1000059005, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MEMORY_PROPERTIES_2 = 1000059006, 
    VK_STRUCTURE_TYPE_SPARSE_IMAGE_FORMAT_PROPERTIES_2 = 1000059007, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SPARSE_IMAGE_FORMAT_INFO_2 = 1000059008, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_POINT_CLIPPING_PROPERTIES = 1000117000, 
    VK_STRUCTURE_TYPE_RENDER_PASS_INPUT_ATTACHMENT_ASPECT_CREATE_INFO = 1000117001, 
    VK_STRUCTURE_TYPE_IMAGE_VIEW_USAGE_CREATE_INFO = 1000117002, 
    VK_STRUCTURE_TYPE_PIPELINE_TESSELLATION_DOMAIN_ORIGIN_STATE_CREATE_INFO = 1000117003, 
    VK_STRUCTURE_TYPE_RENDER_PASS_MULTIVIEW_CREATE_INFO = 1000053000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_FEATURES = 1000053001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_PROPERTIES = 1000053002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTERS_FEATURES = 1000120000, 
    VK_STRUCTURE_TYPE_PROTECTED_SUBMIT_INFO = 1000145000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROTECTED_MEMORY_FEATURES = 1000145001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROTECTED_MEMORY_PROPERTIES = 1000145002, 
    VK_STRUCTURE_TYPE_DEVICE_QUEUE_INFO_2 = 1000145003, 
    VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_CREATE_INFO = 1000156000, 
    VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_INFO = 1000156001, 
    VK_STRUCTURE_TYPE_BIND_IMAGE_PLANE_MEMORY_INFO = 1000156002, 
    VK_STRUCTURE_TYPE_IMAGE_PLANE_MEMORY_REQUIREMENTS_INFO = 1000156003, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLER_YCBCR_CONVERSION_FEATURES = 1000156004, 
    VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_IMAGE_FORMAT_PROPERTIES = 1000156005, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_UPDATE_TEMPLATE_CREATE_INFO = 1000085000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_IMAGE_FORMAT_INFO = 1000071000, 
    VK_STRUCTURE_TYPE_EXTERNAL_IMAGE_FORMAT_PROPERTIES = 1000071001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_BUFFER_INFO = 1000071002, 
    VK_STRUCTURE_TYPE_EXTERNAL_BUFFER_PROPERTIES = 1000071003, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ID_PROPERTIES = 1000071004, 
    VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_BUFFER_CREATE_INFO = 1000072000, 
    VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_IMAGE_CREATE_INFO = 1000072001, 
    VK_STRUCTURE_TYPE_EXPORT_MEMORY_ALLOCATE_INFO = 1000072002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_FENCE_INFO = 1000112000, 
    VK_STRUCTURE_TYPE_EXTERNAL_FENCE_PROPERTIES = 1000112001, 
    VK_STRUCTURE_TYPE_EXPORT_FENCE_CREATE_INFO = 1000113000, 
    VK_STRUCTURE_TYPE_EXPORT_SEMAPHORE_CREATE_INFO = 1000077000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_SEMAPHORE_INFO = 1000076000, 
    VK_STRUCTURE_TYPE_EXTERNAL_SEMAPHORE_PROPERTIES = 1000076001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_3_PROPERTIES = 1000168000, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_SUPPORT = 1000168001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_DRAW_PARAMETERS_FEATURES = 1000063000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_1_FEATURES = 49, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_1_PROPERTIES = 50, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_2_FEATURES = 51, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_2_PROPERTIES = 52, 
    VK_STRUCTURE_TYPE_IMAGE_FORMAT_LIST_CREATE_INFO = 1000147000, 
    VK_STRUCTURE_TYPE_ATTACHMENT_DESCRIPTION_2 = 1000109000, 
    VK_STRUCTURE_TYPE_ATTACHMENT_REFERENCE_2 = 1000109001, 
    VK_STRUCTURE_TYPE_SUBPASS_DESCRIPTION_2 = 1000109002, 
    VK_STRUCTURE_TYPE_SUBPASS_DEPENDENCY_2 = 1000109003, 
    VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO_2 = 1000109004, 
    VK_STRUCTURE_TYPE_SUBPASS_BEGIN_INFO = 1000109005, 
    VK_STRUCTURE_TYPE_SUBPASS_END_INFO = 1000109006, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_8BIT_STORAGE_FEATURES = 1000177000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DRIVER_PROPERTIES = 1000196000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_ATOMIC_INT64_FEATURES = 1000180000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_FLOAT16_INT8_FEATURES = 1000082000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FLOAT_CONTROLS_PROPERTIES = 1000197000, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_BINDING_FLAGS_CREATE_INFO = 1000161000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_INDEXING_FEATURES = 1000161001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_INDEXING_PROPERTIES = 1000161002, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_SET_VARIABLE_DESCRIPTOR_COUNT_ALLOCATE_INFO = 1000161003, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_SET_VARIABLE_DESCRIPTOR_COUNT_LAYOUT_SUPPORT = 1000161004, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEPTH_STENCIL_RESOLVE_PROPERTIES = 1000199000, 
    VK_STRUCTURE_TYPE_SUBPASS_DESCRIPTION_DEPTH_STENCIL_RESOLVE = 1000199001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SCALAR_BLOCK_LAYOUT_FEATURES = 1000221000, 
    VK_STRUCTURE_TYPE_IMAGE_STENCIL_USAGE_CREATE_INFO = 1000246000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLER_FILTER_MINMAX_PROPERTIES = 1000130000, 
    VK_STRUCTURE_TYPE_SAMPLER_REDUCTION_MODE_CREATE_INFO = 1000130001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_MEMORY_MODEL_FEATURES = 1000211000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGELESS_FRAMEBUFFER_FEATURES = 1000108000, 
    VK_STRUCTURE_TYPE_FRAMEBUFFER_ATTACHMENTS_CREATE_INFO = 1000108001, 
    VK_STRUCTURE_TYPE_FRAMEBUFFER_ATTACHMENT_IMAGE_INFO = 1000108002, 
    VK_STRUCTURE_TYPE_RENDER_PASS_ATTACHMENT_BEGIN_INFO = 1000108003, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_UNIFORM_BUFFER_STANDARD_LAYOUT_FEATURES = 1000253000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_SUBGROUP_EXTENDED_TYPES_FEATURES = 1000175000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SEPARATE_DEPTH_STENCIL_LAYOUTS_FEATURES = 1000241000, 
    VK_STRUCTURE_TYPE_ATTACHMENT_REFERENCE_STENCIL_LAYOUT = 1000241001, 
    VK_STRUCTURE_TYPE_ATTACHMENT_DESCRIPTION_STENCIL_LAYOUT = 1000241002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_HOST_QUERY_RESET_FEATURES = 1000261000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TIMELINE_SEMAPHORE_FEATURES = 1000207000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TIMELINE_SEMAPHORE_PROPERTIES = 1000207001, 
    VK_STRUCTURE_TYPE_SEMAPHORE_TYPE_CREATE_INFO = 1000207002, 
    VK_STRUCTURE_TYPE_TIMELINE_SEMAPHORE_SUBMIT_INFO = 1000207003, 
    VK_STRUCTURE_TYPE_SEMAPHORE_WAIT_INFO = 1000207004, 
    VK_STRUCTURE_TYPE_SEMAPHORE_SIGNAL_INFO = 1000207005, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BUFFER_DEVICE_ADDRESS_FEATURES = 1000257000, 
    VK_STRUCTURE_TYPE_BUFFER_DEVICE_ADDRESS_INFO = 1000244001, 
    VK_STRUCTURE_TYPE_BUFFER_OPAQUE_CAPTURE_ADDRESS_CREATE_INFO = 1000257002, 
    VK_STRUCTURE_TYPE_MEMORY_OPAQUE_CAPTURE_ADDRESS_ALLOCATE_INFO = 1000257003, 
    VK_STRUCTURE_TYPE_DEVICE_MEMORY_OPAQUE_CAPTURE_ADDRESS_INFO = 1000257004, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_3_FEATURES = 53, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_3_PROPERTIES = 54, 
    VK_STRUCTURE_TYPE_PIPELINE_CREATION_FEEDBACK_CREATE_INFO = 1000192000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_TERMINATE_INVOCATION_FEATURES = 1000215000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TOOL_PROPERTIES = 1000245000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_DEMOTE_TO_HELPER_INVOCATION_FEATURES = 1000276000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PRIVATE_DATA_FEATURES = 1000295000, 
    VK_STRUCTURE_TYPE_DEVICE_PRIVATE_DATA_CREATE_INFO = 1000295001, 
    VK_STRUCTURE_TYPE_PRIVATE_DATA_SLOT_CREATE_INFO = 1000295002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_CREATION_CACHE_CONTROL_FEATURES = 1000297000, 
    VK_STRUCTURE_TYPE_MEMORY_BARRIER_2 = 1000314000, 
    VK_STRUCTURE_TYPE_BUFFER_MEMORY_BARRIER_2 = 1000314001, 
    VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER_2 = 1000314002, 
    VK_STRUCTURE_TYPE_DEPENDENCY_INFO = 1000314003, 
    VK_STRUCTURE_TYPE_SUBMIT_INFO_2 = 1000314004, 
    VK_STRUCTURE_TYPE_SEMAPHORE_SUBMIT_INFO = 1000314005, 
    VK_STRUCTURE_TYPE_COMMAND_BUFFER_SUBMIT_INFO = 1000314006, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SYNCHRONIZATION_2_FEATURES = 1000314007, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ZERO_INITIALIZE_WORKGROUP_MEMORY_FEATURES = 1000325000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_ROBUSTNESS_FEATURES = 1000335000, 
    VK_STRUCTURE_TYPE_COPY_BUFFER_INFO_2 = 1000337000, 
    VK_STRUCTURE_TYPE_COPY_IMAGE_INFO_2 = 1000337001, 
    VK_STRUCTURE_TYPE_COPY_BUFFER_TO_IMAGE_INFO_2 = 1000337002, 
    VK_STRUCTURE_TYPE_COPY_IMAGE_TO_BUFFER_INFO_2 = 1000337003, 
    VK_STRUCTURE_TYPE_BLIT_IMAGE_INFO_2 = 1000337004, 
    VK_STRUCTURE_TYPE_RESOLVE_IMAGE_INFO_2 = 1000337005, 
    VK_STRUCTURE_TYPE_BUFFER_COPY_2 = 1000337006, 
    VK_STRUCTURE_TYPE_IMAGE_COPY_2 = 1000337007, 
    VK_STRUCTURE_TYPE_IMAGE_BLIT_2 = 1000337008, 
    VK_STRUCTURE_TYPE_BUFFER_IMAGE_COPY_2 = 1000337009, 
    VK_STRUCTURE_TYPE_IMAGE_RESOLVE_2 = 1000337010, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SUBGROUP_SIZE_CONTROL_PROPERTIES = 1000225000, 
    VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_REQUIRED_SUBGROUP_SIZE_CREATE_INFO = 1000225001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SUBGROUP_SIZE_CONTROL_FEATURES = 1000225002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INLINE_UNIFORM_BLOCK_FEATURES = 1000138000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INLINE_UNIFORM_BLOCK_PROPERTIES = 1000138001, 
    VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET_INLINE_UNIFORM_BLOCK = 1000138002, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_INLINE_UNIFORM_BLOCK_CREATE_INFO = 1000138003, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TEXTURE_COMPRESSION_ASTC_HDR_FEATURES = 1000066000, 
    VK_STRUCTURE_TYPE_RENDERING_INFO = 1000044000, 
    VK_STRUCTURE_TYPE_RENDERING_ATTACHMENT_INFO = 1000044001, 
    VK_STRUCTURE_TYPE_PIPELINE_RENDERING_CREATE_INFO = 1000044002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DYNAMIC_RENDERING_FEATURES = 1000044003, 
    VK_STRUCTURE_TYPE_COMMAND_BUFFER_INHERITANCE_RENDERING_INFO = 1000044004, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_INTEGER_DOT_PRODUCT_FEATURES = 1000280000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_INTEGER_DOT_PRODUCT_PROPERTIES = 1000280001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TEXEL_BUFFER_ALIGNMENT_PROPERTIES = 1000281001, 
    VK_STRUCTURE_TYPE_FORMAT_PROPERTIES_3 = 1000360000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_4_FEATURES = 1000413000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_4_PROPERTIES = 1000413001, 
    VK_STRUCTURE_TYPE_DEVICE_BUFFER_MEMORY_REQUIREMENTS = 1000413002, 
    VK_STRUCTURE_TYPE_DEVICE_IMAGE_MEMORY_REQUIREMENTS = 1000413003, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_4_FEATURES = 55, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_4_PROPERTIES = 56, 
    VK_STRUCTURE_TYPE_DEVICE_QUEUE_GLOBAL_PRIORITY_CREATE_INFO = 1000174000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_GLOBAL_PRIORITY_QUERY_FEATURES = 1000388000, 
    VK_STRUCTURE_TYPE_QUEUE_FAMILY_GLOBAL_PRIORITY_PROPERTIES = 1000388001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_SUBGROUP_ROTATE_FEATURES = 1000416000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_FLOAT_CONTROLS_2_FEATURES = 1000528000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_EXPECT_ASSUME_FEATURES = 1000544000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LINE_RASTERIZATION_FEATURES = 1000259000, 
    VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_LINE_STATE_CREATE_INFO = 1000259001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LINE_RASTERIZATION_PROPERTIES = 1000259002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VERTEX_ATTRIBUTE_DIVISOR_PROPERTIES = 1000525000, 
    VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_DIVISOR_STATE_CREATE_INFO = 1000190001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VERTEX_ATTRIBUTE_DIVISOR_FEATURES = 1000190002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INDEX_TYPE_UINT8_FEATURES = 1000265000, 
    VK_STRUCTURE_TYPE_MEMORY_MAP_INFO = 1000271000, 
    VK_STRUCTURE_TYPE_MEMORY_UNMAP_INFO = 1000271001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_5_FEATURES = 1000470000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_5_PROPERTIES = 1000470001, 
    VK_STRUCTURE_TYPE_RENDERING_AREA_INFO = 1000470003, 
    VK_STRUCTURE_TYPE_DEVICE_IMAGE_SUBRESOURCE_INFO = 1000470004, 
    VK_STRUCTURE_TYPE_SUBRESOURCE_LAYOUT_2 = 1000338002, 
    VK_STRUCTURE_TYPE_IMAGE_SUBRESOURCE_2 = 1000338003, 
    VK_STRUCTURE_TYPE_PIPELINE_CREATE_FLAGS_2_CREATE_INFO = 1000470005, 
    VK_STRUCTURE_TYPE_BUFFER_USAGE_FLAGS_2_CREATE_INFO = 1000470006, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PUSH_DESCRIPTOR_PROPERTIES = 1000080000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DYNAMIC_RENDERING_LOCAL_READ_FEATURES = 1000232000, 
    VK_STRUCTURE_TYPE_RENDERING_ATTACHMENT_LOCATION_INFO = 1000232001, 
    VK_STRUCTURE_TYPE_RENDERING_INPUT_ATTACHMENT_INDEX_INFO = 1000232002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_6_FEATURES = 1000545000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_6_PROPERTIES = 1000545001, 
    VK_STRUCTURE_TYPE_BIND_MEMORY_STATUS = 1000545002, 
    VK_STRUCTURE_TYPE_BIND_DESCRIPTOR_SETS_INFO = 1000545003, 
    VK_STRUCTURE_TYPE_PUSH_CONSTANTS_INFO = 1000545004, 
    VK_STRUCTURE_TYPE_PUSH_DESCRIPTOR_SET_INFO = 1000545005, 
    VK_STRUCTURE_TYPE_PUSH_DESCRIPTOR_SET_WITH_TEMPLATE_INFO = 1000545006, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_PROTECTED_ACCESS_FEATURES = 1000466000, 
    VK_STRUCTURE_TYPE_PIPELINE_ROBUSTNESS_CREATE_INFO = 1000068000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_ROBUSTNESS_FEATURES = 1000068001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_ROBUSTNESS_PROPERTIES = 1000068002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_HOST_IMAGE_COPY_FEATURES = 1000270000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_HOST_IMAGE_COPY_PROPERTIES = 1000270001, 
    VK_STRUCTURE_TYPE_MEMORY_TO_IMAGE_COPY = 1000270002, 
    VK_STRUCTURE_TYPE_IMAGE_TO_MEMORY_COPY = 1000270003, 
    VK_STRUCTURE_TYPE_COPY_IMAGE_TO_MEMORY_INFO = 1000270004, 
    VK_STRUCTURE_TYPE_COPY_MEMORY_TO_IMAGE_INFO = 1000270005, 
    VK_STRUCTURE_TYPE_HOST_IMAGE_LAYOUT_TRANSITION_INFO = 1000270006, 
    VK_STRUCTURE_TYPE_COPY_IMAGE_TO_IMAGE_INFO = 1000270007, 
    VK_STRUCTURE_TYPE_SUBRESOURCE_HOST_MEMCPY_SIZE = 1000270008, 
    VK_STRUCTURE_TYPE_HOST_IMAGE_COPY_DEVICE_PERFORMANCE_QUERY = 1000270009, 
    VK_STRUCTURE_TYPE_SWAPCHAIN_CREATE_INFO_KHR = 1000001000, 
    VK_STRUCTURE_TYPE_PRESENT_INFO_KHR = 1000001001, 
    VK_STRUCTURE_TYPE_DEVICE_GROUP_PRESENT_CAPABILITIES_KHR = 1000060007, 
    VK_STRUCTURE_TYPE_IMAGE_SWAPCHAIN_CREATE_INFO_KHR = 1000060008, 
    VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_SWAPCHAIN_INFO_KHR = 1000060009, 
    VK_STRUCTURE_TYPE_ACQUIRE_NEXT_IMAGE_INFO_KHR = 1000060010, 
    VK_STRUCTURE_TYPE_DEVICE_GROUP_PRESENT_INFO_KHR = 1000060011, 
    VK_STRUCTURE_TYPE_DEVICE_GROUP_SWAPCHAIN_CREATE_INFO_KHR = 1000060012, 
    VK_STRUCTURE_TYPE_DISPLAY_MODE_CREATE_INFO_KHR = 1000002000, 
    VK_STRUCTURE_TYPE_DISPLAY_SURFACE_CREATE_INFO_KHR = 1000002001, 
    VK_STRUCTURE_TYPE_DISPLAY_PRESENT_INFO_KHR = 1000003000, 
    VK_STRUCTURE_TYPE_XLIB_SURFACE_CREATE_INFO_KHR = 1000004000, 
    VK_STRUCTURE_TYPE_XCB_SURFACE_CREATE_INFO_KHR = 1000005000, 
    VK_STRUCTURE_TYPE_WAYLAND_SURFACE_CREATE_INFO_KHR = 1000006000, 
    VK_STRUCTURE_TYPE_ANDROID_SURFACE_CREATE_INFO_KHR = 1000008000, 
    VK_STRUCTURE_TYPE_WIN32_SURFACE_CREATE_INFO_KHR = 1000009000, 
    VK_STRUCTURE_TYPE_DEBUG_REPORT_CALLBACK_CREATE_INFO_EXT = 1000011000, 
    VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_RASTERIZATION_ORDER_AMD = 1000018000, 
    VK_STRUCTURE_TYPE_DEBUG_MARKER_OBJECT_NAME_INFO_EXT = 1000022000, 
    VK_STRUCTURE_TYPE_DEBUG_MARKER_OBJECT_TAG_INFO_EXT = 1000022001, 
    VK_STRUCTURE_TYPE_DEBUG_MARKER_MARKER_INFO_EXT = 1000022002, 
    VK_STRUCTURE_TYPE_VIDEO_PROFILE_INFO_KHR = 1000023000, 
    VK_STRUCTURE_TYPE_VIDEO_CAPABILITIES_KHR = 1000023001, 
    VK_STRUCTURE_TYPE_VIDEO_PICTURE_RESOURCE_INFO_KHR = 1000023002, 
    VK_STRUCTURE_TYPE_VIDEO_SESSION_MEMORY_REQUIREMENTS_KHR = 1000023003, 
    VK_STRUCTURE_TYPE_BIND_VIDEO_SESSION_MEMORY_INFO_KHR = 1000023004, 
    VK_STRUCTURE_TYPE_VIDEO_SESSION_CREATE_INFO_KHR = 1000023005, 
    VK_STRUCTURE_TYPE_VIDEO_SESSION_PARAMETERS_CREATE_INFO_KHR = 1000023006, 
    VK_STRUCTURE_TYPE_VIDEO_SESSION_PARAMETERS_UPDATE_INFO_KHR = 1000023007, 
    VK_STRUCTURE_TYPE_VIDEO_BEGIN_CODING_INFO_KHR = 1000023008, 
    VK_STRUCTURE_TYPE_VIDEO_END_CODING_INFO_KHR = 1000023009, 
    VK_STRUCTURE_TYPE_VIDEO_CODING_CONTROL_INFO_KHR = 1000023010, 
    VK_STRUCTURE_TYPE_VIDEO_REFERENCE_SLOT_INFO_KHR = 1000023011, 
    VK_STRUCTURE_TYPE_QUEUE_FAMILY_VIDEO_PROPERTIES_KHR = 1000023012, 
    VK_STRUCTURE_TYPE_VIDEO_PROFILE_LIST_INFO_KHR = 1000023013, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VIDEO_FORMAT_INFO_KHR = 1000023014, 
    VK_STRUCTURE_TYPE_VIDEO_FORMAT_PROPERTIES_KHR = 1000023015, 
    VK_STRUCTURE_TYPE_QUEUE_FAMILY_QUERY_RESULT_STATUS_PROPERTIES_KHR = 1000023016, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_INFO_KHR = 1000024000, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_CAPABILITIES_KHR = 1000024001, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_USAGE_INFO_KHR = 1000024002, 
    VK_STRUCTURE_TYPE_DEDICATED_ALLOCATION_IMAGE_CREATE_INFO_NV = 1000026000, 
    VK_STRUCTURE_TYPE_DEDICATED_ALLOCATION_BUFFER_CREATE_INFO_NV = 1000026001, 
    VK_STRUCTURE_TYPE_DEDICATED_ALLOCATION_MEMORY_ALLOCATE_INFO_NV = 1000026002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TRANSFORM_FEEDBACK_FEATURES_EXT = 1000028000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TRANSFORM_FEEDBACK_PROPERTIES_EXT = 1000028001, 
    VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_STREAM_CREATE_INFO_EXT = 1000028002, 
    VK_STRUCTURE_TYPE_CU_MODULE_CREATE_INFO_NVX = 1000029000, 
    VK_STRUCTURE_TYPE_CU_FUNCTION_CREATE_INFO_NVX = 1000029001, 
    VK_STRUCTURE_TYPE_CU_LAUNCH_INFO_NVX = 1000029002, 
    VK_STRUCTURE_TYPE_CU_MODULE_TEXTURING_MODE_CREATE_INFO_NVX = 1000029004, 
    VK_STRUCTURE_TYPE_IMAGE_VIEW_HANDLE_INFO_NVX = 1000030000, 
    VK_STRUCTURE_TYPE_IMAGE_VIEW_ADDRESS_PROPERTIES_NVX = 1000030001, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_CAPABILITIES_KHR = 1000038000, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_SESSION_PARAMETERS_CREATE_INFO_KHR = 1000038001, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_SESSION_PARAMETERS_ADD_INFO_KHR = 1000038002, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_PICTURE_INFO_KHR = 1000038003, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_DPB_SLOT_INFO_KHR = 1000038004, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_NALU_SLICE_INFO_KHR = 1000038005, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_GOP_REMAINING_FRAME_INFO_KHR = 1000038006, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_PROFILE_INFO_KHR = 1000038007, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_RATE_CONTROL_INFO_KHR = 1000038008, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_RATE_CONTROL_LAYER_INFO_KHR = 1000038009, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_SESSION_CREATE_INFO_KHR = 1000038010, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_QUALITY_LEVEL_PROPERTIES_KHR = 1000038011, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_SESSION_PARAMETERS_GET_INFO_KHR = 1000038012, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_SESSION_PARAMETERS_FEEDBACK_INFO_KHR = 1000038013, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H265_CAPABILITIES_KHR = 1000039000, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H265_SESSION_PARAMETERS_CREATE_INFO_KHR = 1000039001, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H265_SESSION_PARAMETERS_ADD_INFO_KHR = 1000039002, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H265_PICTURE_INFO_KHR = 1000039003, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H265_DPB_SLOT_INFO_KHR = 1000039004, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H265_NALU_SLICE_SEGMENT_INFO_KHR = 1000039005, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H265_GOP_REMAINING_FRAME_INFO_KHR = 1000039006, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H265_PROFILE_INFO_KHR = 1000039007, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H265_RATE_CONTROL_INFO_KHR = 1000039009, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H265_RATE_CONTROL_LAYER_INFO_KHR = 1000039010, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H265_SESSION_CREATE_INFO_KHR = 1000039011, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H265_QUALITY_LEVEL_PROPERTIES_KHR = 1000039012, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H265_SESSION_PARAMETERS_GET_INFO_KHR = 1000039013, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H265_SESSION_PARAMETERS_FEEDBACK_INFO_KHR = 1000039014, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_H264_CAPABILITIES_KHR = 1000040000, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_H264_PICTURE_INFO_KHR = 1000040001, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_H264_PROFILE_INFO_KHR = 1000040003, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_H264_SESSION_PARAMETERS_CREATE_INFO_KHR = 1000040004, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_H264_SESSION_PARAMETERS_ADD_INFO_KHR = 1000040005, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_H264_DPB_SLOT_INFO_KHR = 1000040006, 
    VK_STRUCTURE_TYPE_TEXTURE_LOD_GATHER_FORMAT_PROPERTIES_AMD = 1000041000, 
    VK_STRUCTURE_TYPE_STREAM_DESCRIPTOR_SURFACE_CREATE_INFO_GGP = 1000049000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CORNER_SAMPLED_IMAGE_FEATURES_NV = 1000050000, 
    VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_IMAGE_CREATE_INFO_NV = 1000056000, 
    VK_STRUCTURE_TYPE_EXPORT_MEMORY_ALLOCATE_INFO_NV = 1000056001, 
    VK_STRUCTURE_TYPE_IMPORT_MEMORY_WIN32_HANDLE_INFO_NV = 1000057000, 
    VK_STRUCTURE_TYPE_EXPORT_MEMORY_WIN32_HANDLE_INFO_NV = 1000057001, 
    VK_STRUCTURE_TYPE_WIN32_KEYED_MUTEX_ACQUIRE_RELEASE_INFO_NV = 1000058000, 
    VK_STRUCTURE_TYPE_VALIDATION_FLAGS_EXT = 1000061000, 
    VK_STRUCTURE_TYPE_VI_SURFACE_CREATE_INFO_NN = 1000062000, 
    VK_STRUCTURE_TYPE_IMAGE_VIEW_ASTC_DECODE_MODE_EXT = 1000067000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ASTC_DECODE_FEATURES_EXT = 1000067001, 
    VK_STRUCTURE_TYPE_IMPORT_MEMORY_WIN32_HANDLE_INFO_KHR = 1000073000, 
    VK_STRUCTURE_TYPE_EXPORT_MEMORY_WIN32_HANDLE_INFO_KHR = 1000073001, 
    VK_STRUCTURE_TYPE_MEMORY_WIN32_HANDLE_PROPERTIES_KHR = 1000073002, 
    VK_STRUCTURE_TYPE_MEMORY_GET_WIN32_HANDLE_INFO_KHR = 1000073003, 
    VK_STRUCTURE_TYPE_IMPORT_MEMORY_FD_INFO_KHR = 1000074000, 
    VK_STRUCTURE_TYPE_MEMORY_FD_PROPERTIES_KHR = 1000074001, 
    VK_STRUCTURE_TYPE_MEMORY_GET_FD_INFO_KHR = 1000074002, 
    VK_STRUCTURE_TYPE_WIN32_KEYED_MUTEX_ACQUIRE_RELEASE_INFO_KHR = 1000075000, 
    VK_STRUCTURE_TYPE_IMPORT_SEMAPHORE_WIN32_HANDLE_INFO_KHR = 1000078000, 
    VK_STRUCTURE_TYPE_EXPORT_SEMAPHORE_WIN32_HANDLE_INFO_KHR = 1000078001, 
    VK_STRUCTURE_TYPE_D3D12_FENCE_SUBMIT_INFO_KHR = 1000078002, 
    VK_STRUCTURE_TYPE_SEMAPHORE_GET_WIN32_HANDLE_INFO_KHR = 1000078003, 
    VK_STRUCTURE_TYPE_IMPORT_SEMAPHORE_FD_INFO_KHR = 1000079000, 
    VK_STRUCTURE_TYPE_SEMAPHORE_GET_FD_INFO_KHR = 1000079001, 
    VK_STRUCTURE_TYPE_COMMAND_BUFFER_INHERITANCE_CONDITIONAL_RENDERING_INFO_EXT = 1000081000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CONDITIONAL_RENDERING_FEATURES_EXT = 1000081001, 
    VK_STRUCTURE_TYPE_CONDITIONAL_RENDERING_BEGIN_INFO_EXT = 1000081002, 
    VK_STRUCTURE_TYPE_PRESENT_REGIONS_KHR = 1000084000, 
    VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_W_SCALING_STATE_CREATE_INFO_NV = 1000087000, 
    VK_STRUCTURE_TYPE_SURFACE_CAPABILITIES_2_EXT = 1000090000, 
    VK_STRUCTURE_TYPE_DISPLAY_POWER_INFO_EXT = 1000091000, 
    VK_STRUCTURE_TYPE_DEVICE_EVENT_INFO_EXT = 1000091001, 
    VK_STRUCTURE_TYPE_DISPLAY_EVENT_INFO_EXT = 1000091002, 
    VK_STRUCTURE_TYPE_SWAPCHAIN_COUNTER_CREATE_INFO_EXT = 1000091003, 
    VK_STRUCTURE_TYPE_PRESENT_TIMES_INFO_GOOGLE = 1000092000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_PER_VIEW_ATTRIBUTES_PROPERTIES_NVX = 1000097000, 
    VK_STRUCTURE_TYPE_MULTIVIEW_PER_VIEW_ATTRIBUTES_INFO_NVX = 1000044009, 
    VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_SWIZZLE_STATE_CREATE_INFO_NV = 1000098000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DISCARD_RECTANGLE_PROPERTIES_EXT = 1000099000, 
    VK_STRUCTURE_TYPE_PIPELINE_DISCARD_RECTANGLE_STATE_CREATE_INFO_EXT = 1000099001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CONSERVATIVE_RASTERIZATION_PROPERTIES_EXT = 1000101000, 
    VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_CONSERVATIVE_STATE_CREATE_INFO_EXT = 1000101001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEPTH_CLIP_ENABLE_FEATURES_EXT = 1000102000, 
    VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_DEPTH_CLIP_STATE_CREATE_INFO_EXT = 1000102001, 
    VK_STRUCTURE_TYPE_HDR_METADATA_EXT = 1000105000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RELAXED_LINE_RASTERIZATION_FEATURES_IMG = 1000110000, 
    VK_STRUCTURE_TYPE_SHARED_PRESENT_SURFACE_CAPABILITIES_KHR = 1000111000, 
    VK_STRUCTURE_TYPE_IMPORT_FENCE_WIN32_HANDLE_INFO_KHR = 1000114000, 
    VK_STRUCTURE_TYPE_EXPORT_FENCE_WIN32_HANDLE_INFO_KHR = 1000114001, 
    VK_STRUCTURE_TYPE_FENCE_GET_WIN32_HANDLE_INFO_KHR = 1000114002, 
    VK_STRUCTURE_TYPE_IMPORT_FENCE_FD_INFO_KHR = 1000115000, 
    VK_STRUCTURE_TYPE_FENCE_GET_FD_INFO_KHR = 1000115001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PERFORMANCE_QUERY_FEATURES_KHR = 1000116000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PERFORMANCE_QUERY_PROPERTIES_KHR = 1000116001, 
    VK_STRUCTURE_TYPE_QUERY_POOL_PERFORMANCE_CREATE_INFO_KHR = 1000116002, 
    VK_STRUCTURE_TYPE_PERFORMANCE_QUERY_SUBMIT_INFO_KHR = 1000116003, 
    VK_STRUCTURE_TYPE_ACQUIRE_PROFILING_LOCK_INFO_KHR = 1000116004, 
    VK_STRUCTURE_TYPE_PERFORMANCE_COUNTER_KHR = 1000116005, 
    VK_STRUCTURE_TYPE_PERFORMANCE_COUNTER_DESCRIPTION_KHR = 1000116006, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SURFACE_INFO_2_KHR = 1000119000, 
    VK_STRUCTURE_TYPE_SURFACE_CAPABILITIES_2_KHR = 1000119001, 
    VK_STRUCTURE_TYPE_SURFACE_FORMAT_2_KHR = 1000119002, 
    VK_STRUCTURE_TYPE_DISPLAY_PROPERTIES_2_KHR = 1000121000, 
    VK_STRUCTURE_TYPE_DISPLAY_PLANE_PROPERTIES_2_KHR = 1000121001, 
    VK_STRUCTURE_TYPE_DISPLAY_MODE_PROPERTIES_2_KHR = 1000121002, 
    VK_STRUCTURE_TYPE_DISPLAY_PLANE_INFO_2_KHR = 1000121003, 
    VK_STRUCTURE_TYPE_DISPLAY_PLANE_CAPABILITIES_2_KHR = 1000121004, 
    VK_STRUCTURE_TYPE_IOS_SURFACE_CREATE_INFO_MVK = 1000122000, 
    VK_STRUCTURE_TYPE_MACOS_SURFACE_CREATE_INFO_MVK = 1000123000, 
    VK_STRUCTURE_TYPE_DEBUG_UTILS_OBJECT_NAME_INFO_EXT = 1000128000, 
    VK_STRUCTURE_TYPE_DEBUG_UTILS_OBJECT_TAG_INFO_EXT = 1000128001, 
    VK_STRUCTURE_TYPE_DEBUG_UTILS_LABEL_EXT = 1000128002, 
    VK_STRUCTURE_TYPE_DEBUG_UTILS_MESSENGER_CALLBACK_DATA_EXT = 1000128003, 
    VK_STRUCTURE_TYPE_DEBUG_UTILS_MESSENGER_CREATE_INFO_EXT = 1000128004, 
    VK_STRUCTURE_TYPE_ANDROID_HARDWARE_BUFFER_USAGE_ANDROID = 1000129000, 
    VK_STRUCTURE_TYPE_ANDROID_HARDWARE_BUFFER_PROPERTIES_ANDROID = 1000129001, 
    VK_STRUCTURE_TYPE_ANDROID_HARDWARE_BUFFER_FORMAT_PROPERTIES_ANDROID = 1000129002, 
    VK_STRUCTURE_TYPE_IMPORT_ANDROID_HARDWARE_BUFFER_INFO_ANDROID = 1000129003, 
    VK_STRUCTURE_TYPE_MEMORY_GET_ANDROID_HARDWARE_BUFFER_INFO_ANDROID = 1000129004, 
    VK_STRUCTURE_TYPE_EXTERNAL_FORMAT_ANDROID = 1000129005, 
    VK_STRUCTURE_TYPE_ANDROID_HARDWARE_BUFFER_FORMAT_PROPERTIES_2_ANDROID = 1000129006, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_ENQUEUE_FEATURES_AMDX = 1000134000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_ENQUEUE_PROPERTIES_AMDX = 1000134001, 
    VK_STRUCTURE_TYPE_EXECUTION_GRAPH_PIPELINE_SCRATCH_SIZE_AMDX = 1000134002, 
    VK_STRUCTURE_TYPE_EXECUTION_GRAPH_PIPELINE_CREATE_INFO_AMDX = 1000134003, 
    VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_NODE_CREATE_INFO_AMDX = 1000134004, 
    VK_STRUCTURE_TYPE_ATTACHMENT_SAMPLE_COUNT_INFO_AMD = 1000044008, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_BFLOAT16_FEATURES_KHR = 1000141000, 
    VK_STRUCTURE_TYPE_SAMPLE_LOCATIONS_INFO_EXT = 1000143000, 
    VK_STRUCTURE_TYPE_RENDER_PASS_SAMPLE_LOCATIONS_BEGIN_INFO_EXT = 1000143001, 
    VK_STRUCTURE_TYPE_PIPELINE_SAMPLE_LOCATIONS_STATE_CREATE_INFO_EXT = 1000143002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLE_LOCATIONS_PROPERTIES_EXT = 1000143003, 
    VK_STRUCTURE_TYPE_MULTISAMPLE_PROPERTIES_EXT = 1000143004, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BLEND_OPERATION_ADVANCED_FEATURES_EXT = 1000148000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BLEND_OPERATION_ADVANCED_PROPERTIES_EXT = 1000148001, 
    VK_STRUCTURE_TYPE_PIPELINE_COLOR_BLEND_ADVANCED_STATE_CREATE_INFO_EXT = 1000148002, 
    VK_STRUCTURE_TYPE_PIPELINE_COVERAGE_TO_COLOR_STATE_CREATE_INFO_NV = 1000149000, 
    VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET_ACCELERATION_STRUCTURE_KHR = 1000150007, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_BUILD_GEOMETRY_INFO_KHR = 1000150000, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_DEVICE_ADDRESS_INFO_KHR = 1000150002, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_GEOMETRY_AABBS_DATA_KHR = 1000150003, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_GEOMETRY_INSTANCES_DATA_KHR = 1000150004, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_GEOMETRY_TRIANGLES_DATA_KHR = 1000150005, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_GEOMETRY_KHR = 1000150006, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_VERSION_INFO_KHR = 1000150009, 
    VK_STRUCTURE_TYPE_COPY_ACCELERATION_STRUCTURE_INFO_KHR = 1000150010, 
    VK_STRUCTURE_TYPE_COPY_ACCELERATION_STRUCTURE_TO_MEMORY_INFO_KHR = 1000150011, 
    VK_STRUCTURE_TYPE_COPY_MEMORY_TO_ACCELERATION_STRUCTURE_INFO_KHR = 1000150012, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ACCELERATION_STRUCTURE_FEATURES_KHR = 1000150013, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ACCELERATION_STRUCTURE_PROPERTIES_KHR = 1000150014, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_CREATE_INFO_KHR = 1000150017, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_BUILD_SIZES_INFO_KHR = 1000150020, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAY_TRACING_PIPELINE_FEATURES_KHR = 1000347000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAY_TRACING_PIPELINE_PROPERTIES_KHR = 1000347001, 
    VK_STRUCTURE_TYPE_RAY_TRACING_PIPELINE_CREATE_INFO_KHR = 1000150015, 
    VK_STRUCTURE_TYPE_RAY_TRACING_SHADER_GROUP_CREATE_INFO_KHR = 1000150016, 
    VK_STRUCTURE_TYPE_RAY_TRACING_PIPELINE_INTERFACE_CREATE_INFO_KHR = 1000150018, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAY_QUERY_FEATURES_KHR = 1000348013, 
    VK_STRUCTURE_TYPE_PIPELINE_COVERAGE_MODULATION_STATE_CREATE_INFO_NV = 1000152000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_SM_BUILTINS_FEATURES_NV = 1000154000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_SM_BUILTINS_PROPERTIES_NV = 1000154001, 
    VK_STRUCTURE_TYPE_DRM_FORMAT_MODIFIER_PROPERTIES_LIST_EXT = 1000158000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_DRM_FORMAT_MODIFIER_INFO_EXT = 1000158002, 
    VK_STRUCTURE_TYPE_IMAGE_DRM_FORMAT_MODIFIER_LIST_CREATE_INFO_EXT = 1000158003, 
    VK_STRUCTURE_TYPE_IMAGE_DRM_FORMAT_MODIFIER_EXPLICIT_CREATE_INFO_EXT = 1000158004, 
    VK_STRUCTURE_TYPE_IMAGE_DRM_FORMAT_MODIFIER_PROPERTIES_EXT = 1000158005, 
    VK_STRUCTURE_TYPE_DRM_FORMAT_MODIFIER_PROPERTIES_LIST_2_EXT = 1000158006, 
    VK_STRUCTURE_TYPE_VALIDATION_CACHE_CREATE_INFO_EXT = 1000160000, 
    VK_STRUCTURE_TYPE_SHADER_MODULE_VALIDATION_CACHE_CREATE_INFO_EXT = 1000160001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PORTABILITY_SUBSET_FEATURES_KHR = 1000163000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PORTABILITY_SUBSET_PROPERTIES_KHR = 1000163001, 
    VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_SHADING_RATE_IMAGE_STATE_CREATE_INFO_NV = 1000164000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADING_RATE_IMAGE_FEATURES_NV = 1000164001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADING_RATE_IMAGE_PROPERTIES_NV = 1000164002, 
    VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_COARSE_SAMPLE_ORDER_STATE_CREATE_INFO_NV = 1000164005, 
    VK_STRUCTURE_TYPE_RAY_TRACING_PIPELINE_CREATE_INFO_NV = 1000165000, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_CREATE_INFO_NV = 1000165001, 
    VK_STRUCTURE_TYPE_GEOMETRY_NV = 1000165003, 
    VK_STRUCTURE_TYPE_GEOMETRY_TRIANGLES_NV = 1000165004, 
    VK_STRUCTURE_TYPE_GEOMETRY_AABB_NV = 1000165005, 
    VK_STRUCTURE_TYPE_BIND_ACCELERATION_STRUCTURE_MEMORY_INFO_NV = 1000165006, 
    VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET_ACCELERATION_STRUCTURE_NV = 1000165007, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_MEMORY_REQUIREMENTS_INFO_NV = 1000165008, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAY_TRACING_PROPERTIES_NV = 1000165009, 
    VK_STRUCTURE_TYPE_RAY_TRACING_SHADER_GROUP_CREATE_INFO_NV = 1000165011, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_INFO_NV = 1000165012, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_REPRESENTATIVE_FRAGMENT_TEST_FEATURES_NV = 1000166000, 
    VK_STRUCTURE_TYPE_PIPELINE_REPRESENTATIVE_FRAGMENT_TEST_STATE_CREATE_INFO_NV = 1000166001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_VIEW_IMAGE_FORMAT_INFO_EXT = 1000170000, 
    VK_STRUCTURE_TYPE_FILTER_CUBIC_IMAGE_VIEW_IMAGE_FORMAT_PROPERTIES_EXT = 1000170001, 
    VK_STRUCTURE_TYPE_IMPORT_MEMORY_HOST_POINTER_INFO_EXT = 1000178000, 
    VK_STRUCTURE_TYPE_MEMORY_HOST_POINTER_PROPERTIES_EXT = 1000178001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_MEMORY_HOST_PROPERTIES_EXT = 1000178002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_CLOCK_FEATURES_KHR = 1000181000, 
    VK_STRUCTURE_TYPE_PIPELINE_COMPILER_CONTROL_CREATE_INFO_AMD = 1000183000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_CORE_PROPERTIES_AMD = 1000185000, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_H265_CAPABILITIES_KHR = 1000187000, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_H265_SESSION_PARAMETERS_CREATE_INFO_KHR = 1000187001, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_H265_SESSION_PARAMETERS_ADD_INFO_KHR = 1000187002, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_H265_PROFILE_INFO_KHR = 1000187003, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_H265_PICTURE_INFO_KHR = 1000187004, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_H265_DPB_SLOT_INFO_KHR = 1000187005, 
    VK_STRUCTURE_TYPE_DEVICE_MEMORY_OVERALLOCATION_CREATE_INFO_AMD = 1000189000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VERTEX_ATTRIBUTE_DIVISOR_PROPERTIES_EXT = 1000190000, 
    VK_STRUCTURE_TYPE_PRESENT_FRAME_TOKEN_GGP = 1000191000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MESH_SHADER_FEATURES_NV = 1000202000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MESH_SHADER_PROPERTIES_NV = 1000202001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_IMAGE_FOOTPRINT_FEATURES_NV = 1000204000, 
    VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_EXCLUSIVE_SCISSOR_STATE_CREATE_INFO_NV = 1000205000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXCLUSIVE_SCISSOR_FEATURES_NV = 1000205002, 
    VK_STRUCTURE_TYPE_CHECKPOINT_DATA_NV = 1000206000, 
    VK_STRUCTURE_TYPE_QUEUE_FAMILY_CHECKPOINT_PROPERTIES_NV = 1000206001, 
    VK_STRUCTURE_TYPE_QUEUE_FAMILY_CHECKPOINT_PROPERTIES_2_NV = 1000314008, 
    VK_STRUCTURE_TYPE_CHECKPOINT_DATA_2_NV = 1000314009, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_INTEGER_FUNCTIONS_2_FEATURES_INTEL = 1000209000, 
    VK_STRUCTURE_TYPE_QUERY_POOL_PERFORMANCE_QUERY_CREATE_INFO_INTEL = 1000210000, 
    VK_STRUCTURE_TYPE_INITIALIZE_PERFORMANCE_API_INFO_INTEL = 1000210001, 
    VK_STRUCTURE_TYPE_PERFORMANCE_MARKER_INFO_INTEL = 1000210002, 
    VK_STRUCTURE_TYPE_PERFORMANCE_STREAM_MARKER_INFO_INTEL = 1000210003, 
    VK_STRUCTURE_TYPE_PERFORMANCE_OVERRIDE_INFO_INTEL = 1000210004, 
    VK_STRUCTURE_TYPE_PERFORMANCE_CONFIGURATION_ACQUIRE_INFO_INTEL = 1000210005, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PCI_BUS_INFO_PROPERTIES_EXT = 1000212000, 
    VK_STRUCTURE_TYPE_DISPLAY_NATIVE_HDR_SURFACE_CAPABILITIES_AMD = 1000213000, 
    VK_STRUCTURE_TYPE_SWAPCHAIN_DISPLAY_NATIVE_HDR_CREATE_INFO_AMD = 1000213001, 
    VK_STRUCTURE_TYPE_IMAGEPIPE_SURFACE_CREATE_INFO_FUCHSIA = 1000214000, 
    VK_STRUCTURE_TYPE_METAL_SURFACE_CREATE_INFO_EXT = 1000217000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_DENSITY_MAP_FEATURES_EXT = 1000218000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_DENSITY_MAP_PROPERTIES_EXT = 1000218001, 
    VK_STRUCTURE_TYPE_RENDER_PASS_FRAGMENT_DENSITY_MAP_CREATE_INFO_EXT = 1000218002, 
    VK_STRUCTURE_TYPE_RENDERING_FRAGMENT_DENSITY_MAP_ATTACHMENT_INFO_EXT = 1000044007, 
    VK_STRUCTURE_TYPE_FRAGMENT_SHADING_RATE_ATTACHMENT_INFO_KHR = 1000226000, 
    VK_STRUCTURE_TYPE_PIPELINE_FRAGMENT_SHADING_RATE_STATE_CREATE_INFO_KHR = 1000226001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADING_RATE_PROPERTIES_KHR = 1000226002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADING_RATE_FEATURES_KHR = 1000226003, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADING_RATE_KHR = 1000226004, 
    VK_STRUCTURE_TYPE_RENDERING_FRAGMENT_SHADING_RATE_ATTACHMENT_INFO_KHR = 1000044006, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_CORE_PROPERTIES_2_AMD = 1000227000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COHERENT_MEMORY_FEATURES_AMD = 1000229000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_IMAGE_ATOMIC_INT64_FEATURES_EXT = 1000234000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_QUAD_CONTROL_FEATURES_KHR = 1000235000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MEMORY_BUDGET_PROPERTIES_EXT = 1000237000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MEMORY_PRIORITY_FEATURES_EXT = 1000238000, 
    VK_STRUCTURE_TYPE_MEMORY_PRIORITY_ALLOCATE_INFO_EXT = 1000238001, 
    VK_STRUCTURE_TYPE_SURFACE_PROTECTED_CAPABILITIES_KHR = 1000239000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEDICATED_ALLOCATION_IMAGE_ALIASING_FEATURES_NV = 1000240000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BUFFER_DEVICE_ADDRESS_FEATURES_EXT = 1000244000, 
    VK_STRUCTURE_TYPE_BUFFER_DEVICE_ADDRESS_CREATE_INFO_EXT = 1000244002, 
    VK_STRUCTURE_TYPE_VALIDATION_FEATURES_EXT = 1000247000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PRESENT_WAIT_FEATURES_KHR = 1000248000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COOPERATIVE_MATRIX_FEATURES_NV = 1000249000, 
    VK_STRUCTURE_TYPE_COOPERATIVE_MATRIX_PROPERTIES_NV = 1000249001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COOPERATIVE_MATRIX_PROPERTIES_NV = 1000249002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COVERAGE_REDUCTION_MODE_FEATURES_NV = 1000250000, 
    VK_STRUCTURE_TYPE_PIPELINE_COVERAGE_REDUCTION_STATE_CREATE_INFO_NV = 1000250001, 
    VK_STRUCTURE_TYPE_FRAMEBUFFER_MIXED_SAMPLES_COMBINATION_NV = 1000250002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADER_INTERLOCK_FEATURES_EXT = 1000251000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_YCBCR_IMAGE_ARRAYS_FEATURES_EXT = 1000252000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROVOKING_VERTEX_FEATURES_EXT = 1000254000, 
    VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_PROVOKING_VERTEX_STATE_CREATE_INFO_EXT = 1000254001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROVOKING_VERTEX_PROPERTIES_EXT = 1000254002, 
    VK_STRUCTURE_TYPE_SURFACE_FULL_SCREEN_EXCLUSIVE_INFO_EXT = 1000255000, 
    VK_STRUCTURE_TYPE_SURFACE_CAPABILITIES_FULL_SCREEN_EXCLUSIVE_EXT = 1000255002, 
    VK_STRUCTURE_TYPE_SURFACE_FULL_SCREEN_EXCLUSIVE_WIN32_INFO_EXT = 1000255001, 
    VK_STRUCTURE_TYPE_HEADLESS_SURFACE_CREATE_INFO_EXT = 1000256000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_ATOMIC_FLOAT_FEATURES_EXT = 1000260000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTENDED_DYNAMIC_STATE_FEATURES_EXT = 1000267000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_EXECUTABLE_PROPERTIES_FEATURES_KHR = 1000269000, 
    VK_STRUCTURE_TYPE_PIPELINE_INFO_KHR = 1000269001, 
    VK_STRUCTURE_TYPE_PIPELINE_EXECUTABLE_PROPERTIES_KHR = 1000269002, 
    VK_STRUCTURE_TYPE_PIPELINE_EXECUTABLE_INFO_KHR = 1000269003, 
    VK_STRUCTURE_TYPE_PIPELINE_EXECUTABLE_STATISTIC_KHR = 1000269004, 
    VK_STRUCTURE_TYPE_PIPELINE_EXECUTABLE_INTERNAL_REPRESENTATION_KHR = 1000269005, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAP_MEMORY_PLACED_FEATURES_EXT = 1000272000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAP_MEMORY_PLACED_PROPERTIES_EXT = 1000272001, 
    VK_STRUCTURE_TYPE_MEMORY_MAP_PLACED_INFO_EXT = 1000272002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_ATOMIC_FLOAT_2_FEATURES_EXT = 1000273000, 
    VK_STRUCTURE_TYPE_SURFACE_PRESENT_MODE_EXT = 1000274000, 
    VK_STRUCTURE_TYPE_SURFACE_PRESENT_SCALING_CAPABILITIES_EXT = 1000274001, 
    VK_STRUCTURE_TYPE_SURFACE_PRESENT_MODE_COMPATIBILITY_EXT = 1000274002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SWAPCHAIN_MAINTENANCE_1_FEATURES_EXT = 1000275000, 
    VK_STRUCTURE_TYPE_SWAPCHAIN_PRESENT_FENCE_INFO_EXT = 1000275001, 
    VK_STRUCTURE_TYPE_SWAPCHAIN_PRESENT_MODES_CREATE_INFO_EXT = 1000275002, 
    VK_STRUCTURE_TYPE_SWAPCHAIN_PRESENT_MODE_INFO_EXT = 1000275003, 
    VK_STRUCTURE_TYPE_SWAPCHAIN_PRESENT_SCALING_CREATE_INFO_EXT = 1000275004, 
    VK_STRUCTURE_TYPE_RELEASE_SWAPCHAIN_IMAGES_INFO_EXT = 1000275005, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEVICE_GENERATED_COMMANDS_PROPERTIES_NV = 1000277000, 
    VK_STRUCTURE_TYPE_GRAPHICS_SHADER_GROUP_CREATE_INFO_NV = 1000277001, 
    VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_SHADER_GROUPS_CREATE_INFO_NV = 1000277002, 
    VK_STRUCTURE_TYPE_INDIRECT_COMMANDS_LAYOUT_TOKEN_NV = 1000277003, 
    VK_STRUCTURE_TYPE_INDIRECT_COMMANDS_LAYOUT_CREATE_INFO_NV = 1000277004, 
    VK_STRUCTURE_TYPE_GENERATED_COMMANDS_INFO_NV = 1000277005, 
    VK_STRUCTURE_TYPE_GENERATED_COMMANDS_MEMORY_REQUIREMENTS_INFO_NV = 1000277006, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEVICE_GENERATED_COMMANDS_FEATURES_NV = 1000277007, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INHERITED_VIEWPORT_SCISSOR_FEATURES_NV = 1000278000, 
    VK_STRUCTURE_TYPE_COMMAND_BUFFER_INHERITANCE_VIEWPORT_SCISSOR_INFO_NV = 1000278001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TEXEL_BUFFER_ALIGNMENT_FEATURES_EXT = 1000281000, 
    VK_STRUCTURE_TYPE_COMMAND_BUFFER_INHERITANCE_RENDER_PASS_TRANSFORM_INFO_QCOM = 1000282000, 
    VK_STRUCTURE_TYPE_RENDER_PASS_TRANSFORM_BEGIN_INFO_QCOM = 1000282001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEPTH_BIAS_CONTROL_FEATURES_EXT = 1000283000, 
    VK_STRUCTURE_TYPE_DEPTH_BIAS_INFO_EXT = 1000283001, 
    VK_STRUCTURE_TYPE_DEPTH_BIAS_REPRESENTATION_INFO_EXT = 1000283002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEVICE_MEMORY_REPORT_FEATURES_EXT = 1000284000, 
    VK_STRUCTURE_TYPE_DEVICE_DEVICE_MEMORY_REPORT_CREATE_INFO_EXT = 1000284001, 
    VK_STRUCTURE_TYPE_DEVICE_MEMORY_REPORT_CALLBACK_DATA_EXT = 1000284002, 
    VK_STRUCTURE_TYPE_SAMPLER_CUSTOM_BORDER_COLOR_CREATE_INFO_EXT = 1000287000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CUSTOM_BORDER_COLOR_PROPERTIES_EXT = 1000287001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CUSTOM_BORDER_COLOR_FEATURES_EXT = 1000287002, 
    VK_STRUCTURE_TYPE_PIPELINE_LIBRARY_CREATE_INFO_KHR = 1000290000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PRESENT_BARRIER_FEATURES_NV = 1000292000, 
    VK_STRUCTURE_TYPE_SURFACE_CAPABILITIES_PRESENT_BARRIER_NV = 1000292001, 
    VK_STRUCTURE_TYPE_SWAPCHAIN_PRESENT_BARRIER_CREATE_INFO_NV = 1000292002, 
    VK_STRUCTURE_TYPE_PRESENT_ID_KHR = 1000294000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PRESENT_ID_FEATURES_KHR = 1000294001, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_INFO_KHR = 1000299000, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_RATE_CONTROL_INFO_KHR = 1000299001, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_RATE_CONTROL_LAYER_INFO_KHR = 1000299002, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_CAPABILITIES_KHR = 1000299003, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_USAGE_INFO_KHR = 1000299004, 
    VK_STRUCTURE_TYPE_QUERY_POOL_VIDEO_ENCODE_FEEDBACK_CREATE_INFO_KHR = 1000299005, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VIDEO_ENCODE_QUALITY_LEVEL_INFO_KHR = 1000299006, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_QUALITY_LEVEL_PROPERTIES_KHR = 1000299007, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_QUALITY_LEVEL_INFO_KHR = 1000299008, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_SESSION_PARAMETERS_GET_INFO_KHR = 1000299009, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_SESSION_PARAMETERS_FEEDBACK_INFO_KHR = 1000299010, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DIAGNOSTICS_CONFIG_FEATURES_NV = 1000300000, 
    VK_STRUCTURE_TYPE_DEVICE_DIAGNOSTICS_CONFIG_CREATE_INFO_NV = 1000300001, 
    VK_STRUCTURE_TYPE_CUDA_MODULE_CREATE_INFO_NV = 1000307000, 
    VK_STRUCTURE_TYPE_CUDA_FUNCTION_CREATE_INFO_NV = 1000307001, 
    VK_STRUCTURE_TYPE_CUDA_LAUNCH_INFO_NV = 1000307002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CUDA_KERNEL_LAUNCH_FEATURES_NV = 1000307003, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CUDA_KERNEL_LAUNCH_PROPERTIES_NV = 1000307004, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TILE_SHADING_FEATURES_QCOM = 1000309000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TILE_SHADING_PROPERTIES_QCOM = 1000309001, 
    VK_STRUCTURE_TYPE_RENDER_PASS_TILE_SHADING_CREATE_INFO_QCOM = 1000309002, 
    VK_STRUCTURE_TYPE_PER_TILE_BEGIN_INFO_QCOM = 1000309003, 
    VK_STRUCTURE_TYPE_PER_TILE_END_INFO_QCOM = 1000309004, 
    VK_STRUCTURE_TYPE_DISPATCH_TILE_INFO_QCOM = 1000309005, 
    VK_STRUCTURE_TYPE_QUERY_LOW_LATENCY_SUPPORT_NV = 1000310000, 
    VK_STRUCTURE_TYPE_EXPORT_METAL_OBJECT_CREATE_INFO_EXT = 1000311000, 
    VK_STRUCTURE_TYPE_EXPORT_METAL_OBJECTS_INFO_EXT = 1000311001, 
    VK_STRUCTURE_TYPE_EXPORT_METAL_DEVICE_INFO_EXT = 1000311002, 
    VK_STRUCTURE_TYPE_EXPORT_METAL_COMMAND_QUEUE_INFO_EXT = 1000311003, 
    VK_STRUCTURE_TYPE_EXPORT_METAL_BUFFER_INFO_EXT = 1000311004, 
    VK_STRUCTURE_TYPE_IMPORT_METAL_BUFFER_INFO_EXT = 1000311005, 
    VK_STRUCTURE_TYPE_EXPORT_METAL_TEXTURE_INFO_EXT = 1000311006, 
    VK_STRUCTURE_TYPE_IMPORT_METAL_TEXTURE_INFO_EXT = 1000311007, 
    VK_STRUCTURE_TYPE_EXPORT_METAL_IO_SURFACE_INFO_EXT = 1000311008, 
    VK_STRUCTURE_TYPE_IMPORT_METAL_IO_SURFACE_INFO_EXT = 1000311009, 
    VK_STRUCTURE_TYPE_EXPORT_METAL_SHARED_EVENT_INFO_EXT = 1000311010, 
    VK_STRUCTURE_TYPE_IMPORT_METAL_SHARED_EVENT_INFO_EXT = 1000311011, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_BUFFER_PROPERTIES_EXT = 1000316000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_BUFFER_DENSITY_MAP_PROPERTIES_EXT = 1000316001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_BUFFER_FEATURES_EXT = 1000316002, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_ADDRESS_INFO_EXT = 1000316003, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_GET_INFO_EXT = 1000316004, 
    VK_STRUCTURE_TYPE_BUFFER_CAPTURE_DESCRIPTOR_DATA_INFO_EXT = 1000316005, 
    VK_STRUCTURE_TYPE_IMAGE_CAPTURE_DESCRIPTOR_DATA_INFO_EXT = 1000316006, 
    VK_STRUCTURE_TYPE_IMAGE_VIEW_CAPTURE_DESCRIPTOR_DATA_INFO_EXT = 1000316007, 
    VK_STRUCTURE_TYPE_SAMPLER_CAPTURE_DESCRIPTOR_DATA_INFO_EXT = 1000316008, 
    VK_STRUCTURE_TYPE_OPAQUE_CAPTURE_DESCRIPTOR_DATA_CREATE_INFO_EXT = 1000316010, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_BUFFER_BINDING_INFO_EXT = 1000316011, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_BUFFER_BINDING_PUSH_DESCRIPTOR_BUFFER_HANDLE_EXT = 1000316012, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_CAPTURE_DESCRIPTOR_DATA_INFO_EXT = 1000316009, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_GRAPHICS_PIPELINE_LIBRARY_FEATURES_EXT = 1000320000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_GRAPHICS_PIPELINE_LIBRARY_PROPERTIES_EXT = 1000320001, 
    VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_LIBRARY_CREATE_INFO_EXT = 1000320002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_EARLY_AND_LATE_FRAGMENT_TESTS_FEATURES_AMD = 1000321000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADER_BARYCENTRIC_FEATURES_KHR = 1000203000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADER_BARYCENTRIC_PROPERTIES_KHR = 1000322000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_SUBGROUP_UNIFORM_CONTROL_FLOW_FEATURES_KHR = 1000323000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADING_RATE_ENUMS_PROPERTIES_NV = 1000326000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADING_RATE_ENUMS_FEATURES_NV = 1000326001, 
    VK_STRUCTURE_TYPE_PIPELINE_FRAGMENT_SHADING_RATE_ENUM_STATE_CREATE_INFO_NV = 1000326002, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_GEOMETRY_MOTION_TRIANGLES_DATA_NV = 1000327000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAY_TRACING_MOTION_BLUR_FEATURES_NV = 1000327001, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_MOTION_INFO_NV = 1000327002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MESH_SHADER_FEATURES_EXT = 1000328000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MESH_SHADER_PROPERTIES_EXT = 1000328001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_YCBCR_2_PLANE_444_FORMATS_FEATURES_EXT = 1000330000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_DENSITY_MAP_2_FEATURES_EXT = 1000332000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_DENSITY_MAP_2_PROPERTIES_EXT = 1000332001, 
    VK_STRUCTURE_TYPE_COPY_COMMAND_TRANSFORM_INFO_QCOM = 1000333000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_WORKGROUP_MEMORY_EXPLICIT_LAYOUT_FEATURES_KHR = 1000336000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_COMPRESSION_CONTROL_FEATURES_EXT = 1000338000, 
    VK_STRUCTURE_TYPE_IMAGE_COMPRESSION_CONTROL_EXT = 1000338001, 
    VK_STRUCTURE_TYPE_IMAGE_COMPRESSION_PROPERTIES_EXT = 1000338004, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ATTACHMENT_FEEDBACK_LOOP_LAYOUT_FEATURES_EXT = 1000339000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_4444_FORMATS_FEATURES_EXT = 1000340000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FAULT_FEATURES_EXT = 1000341000, 
    VK_STRUCTURE_TYPE_DEVICE_FAULT_COUNTS_EXT = 1000341001, 
    VK_STRUCTURE_TYPE_DEVICE_FAULT_INFO_EXT = 1000341002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RGBA10X6_FORMATS_FEATURES_EXT = 1000344000, 
    VK_STRUCTURE_TYPE_DIRECTFB_SURFACE_CREATE_INFO_EXT = 1000346000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VERTEX_INPUT_DYNAMIC_STATE_FEATURES_EXT = 1000352000, 
    VK_STRUCTURE_TYPE_VERTEX_INPUT_BINDING_DESCRIPTION_2_EXT = 1000352001, 
    VK_STRUCTURE_TYPE_VERTEX_INPUT_ATTRIBUTE_DESCRIPTION_2_EXT = 1000352002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DRM_PROPERTIES_EXT = 1000353000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ADDRESS_BINDING_REPORT_FEATURES_EXT = 1000354000, 
    VK_STRUCTURE_TYPE_DEVICE_ADDRESS_BINDING_CALLBACK_DATA_EXT = 1000354001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEPTH_CLIP_CONTROL_FEATURES_EXT = 1000355000, 
    VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_DEPTH_CLIP_CONTROL_CREATE_INFO_EXT = 1000355001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PRIMITIVE_TOPOLOGY_LIST_RESTART_FEATURES_EXT = 1000356000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PRESENT_MODE_FIFO_LATEST_READY_FEATURES_EXT = 1000361000, 
    VK_STRUCTURE_TYPE_IMPORT_MEMORY_ZIRCON_HANDLE_INFO_FUCHSIA = 1000364000, 
    VK_STRUCTURE_TYPE_MEMORY_ZIRCON_HANDLE_PROPERTIES_FUCHSIA = 1000364001, 
    VK_STRUCTURE_TYPE_MEMORY_GET_ZIRCON_HANDLE_INFO_FUCHSIA = 1000364002, 
    VK_STRUCTURE_TYPE_IMPORT_SEMAPHORE_ZIRCON_HANDLE_INFO_FUCHSIA = 1000365000, 
    VK_STRUCTURE_TYPE_SEMAPHORE_GET_ZIRCON_HANDLE_INFO_FUCHSIA = 1000365001, 
    VK_STRUCTURE_TYPE_BUFFER_COLLECTION_CREATE_INFO_FUCHSIA = 1000366000, 
    VK_STRUCTURE_TYPE_IMPORT_MEMORY_BUFFER_COLLECTION_FUCHSIA = 1000366001, 
    VK_STRUCTURE_TYPE_BUFFER_COLLECTION_IMAGE_CREATE_INFO_FUCHSIA = 1000366002, 
    VK_STRUCTURE_TYPE_BUFFER_COLLECTION_PROPERTIES_FUCHSIA = 1000366003, 
    VK_STRUCTURE_TYPE_BUFFER_CONSTRAINTS_INFO_FUCHSIA = 1000366004, 
    VK_STRUCTURE_TYPE_BUFFER_COLLECTION_BUFFER_CREATE_INFO_FUCHSIA = 1000366005, 
    VK_STRUCTURE_TYPE_IMAGE_CONSTRAINTS_INFO_FUCHSIA = 1000366006, 
    VK_STRUCTURE_TYPE_IMAGE_FORMAT_CONSTRAINTS_INFO_FUCHSIA = 1000366007, 
    VK_STRUCTURE_TYPE_SYSMEM_COLOR_SPACE_FUCHSIA = 1000366008, 
    VK_STRUCTURE_TYPE_BUFFER_COLLECTION_CONSTRAINTS_INFO_FUCHSIA = 1000366009, 
    VK_STRUCTURE_TYPE_SUBPASS_SHADING_PIPELINE_CREATE_INFO_HUAWEI = 1000369000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SUBPASS_SHADING_FEATURES_HUAWEI = 1000369001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SUBPASS_SHADING_PROPERTIES_HUAWEI = 1000369002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INVOCATION_MASK_FEATURES_HUAWEI = 1000370000, 
    VK_STRUCTURE_TYPE_MEMORY_GET_REMOTE_ADDRESS_INFO_NV = 1000371000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_MEMORY_RDMA_FEATURES_NV = 1000371001, 
    VK_STRUCTURE_TYPE_PIPELINE_PROPERTIES_IDENTIFIER_EXT = 1000372000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_PROPERTIES_FEATURES_EXT = 1000372001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAME_BOUNDARY_FEATURES_EXT = 1000375000, 
    VK_STRUCTURE_TYPE_FRAME_BOUNDARY_EXT = 1000375001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTISAMPLED_RENDER_TO_SINGLE_SAMPLED_FEATURES_EXT = 1000376000, 
    VK_STRUCTURE_TYPE_SUBPASS_RESOLVE_PERFORMANCE_QUERY_EXT = 1000376001, 
    VK_STRUCTURE_TYPE_MULTISAMPLED_RENDER_TO_SINGLE_SAMPLED_INFO_EXT = 1000376002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTENDED_DYNAMIC_STATE_2_FEATURES_EXT = 1000377000, 
    VK_STRUCTURE_TYPE_SCREEN_SURFACE_CREATE_INFO_QNX = 1000378000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COLOR_WRITE_ENABLE_FEATURES_EXT = 1000381000, 
    VK_STRUCTURE_TYPE_PIPELINE_COLOR_WRITE_CREATE_INFO_EXT = 1000381001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PRIMITIVES_GENERATED_QUERY_FEATURES_EXT = 1000382000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAY_TRACING_MAINTENANCE_1_FEATURES_KHR = 1000386000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_VIEW_MIN_LOD_FEATURES_EXT = 1000391000, 
    VK_STRUCTURE_TYPE_IMAGE_VIEW_MIN_LOD_CREATE_INFO_EXT = 1000391001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTI_DRAW_FEATURES_EXT = 1000392000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTI_DRAW_PROPERTIES_EXT = 1000392001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_2D_VIEW_OF_3D_FEATURES_EXT = 1000393000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_TILE_IMAGE_FEATURES_EXT = 1000395000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_TILE_IMAGE_PROPERTIES_EXT = 1000395001, 
    VK_STRUCTURE_TYPE_MICROMAP_BUILD_INFO_EXT = 1000396000, 
    VK_STRUCTURE_TYPE_MICROMAP_VERSION_INFO_EXT = 1000396001, 
    VK_STRUCTURE_TYPE_COPY_MICROMAP_INFO_EXT = 1000396002, 
    VK_STRUCTURE_TYPE_COPY_MICROMAP_TO_MEMORY_INFO_EXT = 1000396003, 
    VK_STRUCTURE_TYPE_COPY_MEMORY_TO_MICROMAP_INFO_EXT = 1000396004, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_OPACITY_MICROMAP_FEATURES_EXT = 1000396005, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_OPACITY_MICROMAP_PROPERTIES_EXT = 1000396006, 
    VK_STRUCTURE_TYPE_MICROMAP_CREATE_INFO_EXT = 1000396007, 
    VK_STRUCTURE_TYPE_MICROMAP_BUILD_SIZES_INFO_EXT = 1000396008, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_TRIANGLES_OPACITY_MICROMAP_EXT = 1000396009, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DISPLACEMENT_MICROMAP_FEATURES_NV = 1000397000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DISPLACEMENT_MICROMAP_PROPERTIES_NV = 1000397001, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_TRIANGLES_DISPLACEMENT_MICROMAP_NV = 1000397002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CLUSTER_CULLING_SHADER_FEATURES_HUAWEI = 1000404000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CLUSTER_CULLING_SHADER_PROPERTIES_HUAWEI = 1000404001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CLUSTER_CULLING_SHADER_VRS_FEATURES_HUAWEI = 1000404002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BORDER_COLOR_SWIZZLE_FEATURES_EXT = 1000411000, 
    VK_STRUCTURE_TYPE_SAMPLER_BORDER_COLOR_COMPONENT_MAPPING_CREATE_INFO_EXT = 1000411001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PAGEABLE_DEVICE_LOCAL_MEMORY_FEATURES_EXT = 1000412000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_CORE_PROPERTIES_ARM = 1000415000, 
    VK_STRUCTURE_TYPE_DEVICE_QUEUE_SHADER_CORE_CONTROL_CREATE_INFO_ARM = 1000417000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SCHEDULING_CONTROLS_FEATURES_ARM = 1000417001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SCHEDULING_CONTROLS_PROPERTIES_ARM = 1000417002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_SLICED_VIEW_OF_3D_FEATURES_EXT = 1000418000, 
    VK_STRUCTURE_TYPE_IMAGE_VIEW_SLICED_CREATE_INFO_EXT = 1000418001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_SET_HOST_MAPPING_FEATURES_VALVE = 1000420000, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_SET_BINDING_REFERENCE_VALVE = 1000420001, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_HOST_MAPPING_INFO_VALVE = 1000420002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_NON_SEAMLESS_CUBE_MAP_FEATURES_EXT = 1000422000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RENDER_PASS_STRIPED_FEATURES_ARM = 1000424000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RENDER_PASS_STRIPED_PROPERTIES_ARM = 1000424001, 
    VK_STRUCTURE_TYPE_RENDER_PASS_STRIPE_BEGIN_INFO_ARM = 1000424002, 
    VK_STRUCTURE_TYPE_RENDER_PASS_STRIPE_INFO_ARM = 1000424003, 
    VK_STRUCTURE_TYPE_RENDER_PASS_STRIPE_SUBMIT_INFO_ARM = 1000424004, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COPY_MEMORY_INDIRECT_FEATURES_NV = 1000426000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COPY_MEMORY_INDIRECT_PROPERTIES_NV = 1000426001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MEMORY_DECOMPRESSION_FEATURES_NV = 1000427000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MEMORY_DECOMPRESSION_PROPERTIES_NV = 1000427001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEVICE_GENERATED_COMMANDS_COMPUTE_FEATURES_NV = 1000428000, 
    VK_STRUCTURE_TYPE_COMPUTE_PIPELINE_INDIRECT_BUFFER_INFO_NV = 1000428001, 
    VK_STRUCTURE_TYPE_PIPELINE_INDIRECT_DEVICE_ADDRESS_INFO_NV = 1000428002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAY_TRACING_LINEAR_SWEPT_SPHERES_FEATURES_NV = 1000429008, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_GEOMETRY_LINEAR_SWEPT_SPHERES_DATA_NV = 1000429009, 
    VK_STRUCTURE_TYPE_ACCELERATION_STRUCTURE_GEOMETRY_SPHERES_DATA_NV = 1000429010, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LINEAR_COLOR_ATTACHMENT_FEATURES_NV = 1000430000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_MAXIMAL_RECONVERGENCE_FEATURES_KHR = 1000434000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_COMPRESSION_CONTROL_SWAPCHAIN_FEATURES_EXT = 1000437000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_PROCESSING_FEATURES_QCOM = 1000440000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_PROCESSING_PROPERTIES_QCOM = 1000440001, 
    VK_STRUCTURE_TYPE_IMAGE_VIEW_SAMPLE_WEIGHT_CREATE_INFO_QCOM = 1000440002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_NESTED_COMMAND_BUFFER_FEATURES_EXT = 1000451000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_NESTED_COMMAND_BUFFER_PROPERTIES_EXT = 1000451001, 
    VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_ACQUIRE_UNMODIFIED_EXT = 1000453000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTENDED_DYNAMIC_STATE_3_FEATURES_EXT = 1000455000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTENDED_DYNAMIC_STATE_3_PROPERTIES_EXT = 1000455001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SUBPASS_MERGE_FEEDBACK_FEATURES_EXT = 1000458000, 
    VK_STRUCTURE_TYPE_RENDER_PASS_CREATION_CONTROL_EXT = 1000458001, 
    VK_STRUCTURE_TYPE_RENDER_PASS_CREATION_FEEDBACK_CREATE_INFO_EXT = 1000458002, 
    VK_STRUCTURE_TYPE_RENDER_PASS_SUBPASS_FEEDBACK_CREATE_INFO_EXT = 1000458003, 
    VK_STRUCTURE_TYPE_DIRECT_DRIVER_LOADING_INFO_LUNARG = 1000459000, 
    VK_STRUCTURE_TYPE_DIRECT_DRIVER_LOADING_LIST_LUNARG = 1000459001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_MODULE_IDENTIFIER_FEATURES_EXT = 1000462000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_MODULE_IDENTIFIER_PROPERTIES_EXT = 1000462001, 
    VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_MODULE_IDENTIFIER_CREATE_INFO_EXT = 1000462002, 
    VK_STRUCTURE_TYPE_SHADER_MODULE_IDENTIFIER_EXT = 1000462003, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RASTERIZATION_ORDER_ATTACHMENT_ACCESS_FEATURES_EXT = 1000342000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_OPTICAL_FLOW_FEATURES_NV = 1000464000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_OPTICAL_FLOW_PROPERTIES_NV = 1000464001, 
    VK_STRUCTURE_TYPE_OPTICAL_FLOW_IMAGE_FORMAT_INFO_NV = 1000464002, 
    VK_STRUCTURE_TYPE_OPTICAL_FLOW_IMAGE_FORMAT_PROPERTIES_NV = 1000464003, 
    VK_STRUCTURE_TYPE_OPTICAL_FLOW_SESSION_CREATE_INFO_NV = 1000464004, 
    VK_STRUCTURE_TYPE_OPTICAL_FLOW_EXECUTE_INFO_NV = 1000464005, 
    VK_STRUCTURE_TYPE_OPTICAL_FLOW_SESSION_CREATE_PRIVATE_DATA_INFO_NV = 1000464010, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LEGACY_DITHERING_FEATURES_EXT = 1000465000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_FORMAT_RESOLVE_FEATURES_ANDROID = 1000468000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_FORMAT_RESOLVE_PROPERTIES_ANDROID = 1000468001, 
    VK_STRUCTURE_TYPE_ANDROID_HARDWARE_BUFFER_FORMAT_RESOLVE_PROPERTIES_ANDROID = 1000468002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ANTI_LAG_FEATURES_AMD = 1000476000, 
    VK_STRUCTURE_TYPE_ANTI_LAG_DATA_AMD = 1000476001, 
    VK_STRUCTURE_TYPE_ANTI_LAG_PRESENTATION_INFO_AMD = 1000476002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAY_TRACING_POSITION_FETCH_FEATURES_KHR = 1000481000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_OBJECT_FEATURES_EXT = 1000482000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_OBJECT_PROPERTIES_EXT = 1000482001, 
    VK_STRUCTURE_TYPE_SHADER_CREATE_INFO_EXT = 1000482002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_BINARY_FEATURES_KHR = 1000483000, 
    VK_STRUCTURE_TYPE_PIPELINE_BINARY_CREATE_INFO_KHR = 1000483001, 
    VK_STRUCTURE_TYPE_PIPELINE_BINARY_INFO_KHR = 1000483002, 
    VK_STRUCTURE_TYPE_PIPELINE_BINARY_KEY_KHR = 1000483003, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_BINARY_PROPERTIES_KHR = 1000483004, 
    VK_STRUCTURE_TYPE_RELEASE_CAPTURED_PIPELINE_DATA_INFO_KHR = 1000483005, 
    VK_STRUCTURE_TYPE_PIPELINE_BINARY_DATA_INFO_KHR = 1000483006, 
    VK_STRUCTURE_TYPE_PIPELINE_CREATE_INFO_KHR = 1000483007, 
    VK_STRUCTURE_TYPE_DEVICE_PIPELINE_BINARY_INTERNAL_CACHE_CONTROL_KHR = 1000483008, 
    VK_STRUCTURE_TYPE_PIPELINE_BINARY_HANDLES_INFO_KHR = 1000483009, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TILE_PROPERTIES_FEATURES_QCOM = 1000484000, 
    VK_STRUCTURE_TYPE_TILE_PROPERTIES_QCOM = 1000484001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_AMIGO_PROFILING_FEATURES_SEC = 1000485000, 
    VK_STRUCTURE_TYPE_AMIGO_PROFILING_SUBMIT_INFO_SEC = 1000485001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_PER_VIEW_VIEWPORTS_FEATURES_QCOM = 1000488000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAY_TRACING_INVOCATION_REORDER_FEATURES_NV = 1000490000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAY_TRACING_INVOCATION_REORDER_PROPERTIES_NV = 1000490001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COOPERATIVE_VECTOR_FEATURES_NV = 1000491000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COOPERATIVE_VECTOR_PROPERTIES_NV = 1000491001, 
    VK_STRUCTURE_TYPE_COOPERATIVE_VECTOR_PROPERTIES_NV = 1000491002, 
    VK_STRUCTURE_TYPE_CONVERT_COOPERATIVE_VECTOR_MATRIX_INFO_NV = 1000491004, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTENDED_SPARSE_ADDRESS_SPACE_FEATURES_NV = 1000492000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTENDED_SPARSE_ADDRESS_SPACE_PROPERTIES_NV = 1000492001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MUTABLE_DESCRIPTOR_TYPE_FEATURES_EXT = 1000351000, 
    VK_STRUCTURE_TYPE_MUTABLE_DESCRIPTOR_TYPE_CREATE_INFO_EXT = 1000351002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LEGACY_VERTEX_ATTRIBUTES_FEATURES_EXT = 1000495000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LEGACY_VERTEX_ATTRIBUTES_PROPERTIES_EXT = 1000495001, 
    VK_STRUCTURE_TYPE_LAYER_SETTINGS_CREATE_INFO_EXT = 1000496000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_CORE_BUILTINS_FEATURES_ARM = 1000497000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_CORE_BUILTINS_PROPERTIES_ARM = 1000497001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_LIBRARY_GROUP_HANDLES_FEATURES_EXT = 1000498000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DYNAMIC_RENDERING_UNUSED_ATTACHMENTS_FEATURES_EXT = 1000499000, 
    VK_STRUCTURE_TYPE_LATENCY_SLEEP_MODE_INFO_NV = 1000505000, 
    VK_STRUCTURE_TYPE_LATENCY_SLEEP_INFO_NV = 1000505001, 
    VK_STRUCTURE_TYPE_SET_LATENCY_MARKER_INFO_NV = 1000505002, 
    VK_STRUCTURE_TYPE_GET_LATENCY_MARKER_INFO_NV = 1000505003, 
    VK_STRUCTURE_TYPE_LATENCY_TIMINGS_FRAME_REPORT_NV = 1000505004, 
    VK_STRUCTURE_TYPE_LATENCY_SUBMISSION_PRESENT_ID_NV = 1000505005, 
    VK_STRUCTURE_TYPE_OUT_OF_BAND_QUEUE_TYPE_INFO_NV = 1000505006, 
    VK_STRUCTURE_TYPE_SWAPCHAIN_LATENCY_CREATE_INFO_NV = 1000505007, 
    VK_STRUCTURE_TYPE_LATENCY_SURFACE_CAPABILITIES_NV = 1000505008, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COOPERATIVE_MATRIX_FEATURES_KHR = 1000506000, 
    VK_STRUCTURE_TYPE_COOPERATIVE_MATRIX_PROPERTIES_KHR = 1000506001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COOPERATIVE_MATRIX_PROPERTIES_KHR = 1000506002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_PER_VIEW_RENDER_AREAS_FEATURES_QCOM = 1000510000, 
    VK_STRUCTURE_TYPE_MULTIVIEW_PER_VIEW_RENDER_AREAS_RENDER_PASS_BEGIN_INFO_QCOM = 1000510001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COMPUTE_SHADER_DERIVATIVES_FEATURES_KHR = 1000201000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COMPUTE_SHADER_DERIVATIVES_PROPERTIES_KHR = 1000511000, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_AV1_CAPABILITIES_KHR = 1000512000, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_AV1_PICTURE_INFO_KHR = 1000512001, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_AV1_PROFILE_INFO_KHR = 1000512003, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_AV1_SESSION_PARAMETERS_CREATE_INFO_KHR = 1000512004, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_AV1_DPB_SLOT_INFO_KHR = 1000512005, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_AV1_CAPABILITIES_KHR = 1000513000, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_AV1_SESSION_PARAMETERS_CREATE_INFO_KHR = 1000513001, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_AV1_PICTURE_INFO_KHR = 1000513002, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_AV1_DPB_SLOT_INFO_KHR = 1000513003, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VIDEO_ENCODE_AV1_FEATURES_KHR = 1000513004, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_AV1_PROFILE_INFO_KHR = 1000513005, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_AV1_RATE_CONTROL_INFO_KHR = 1000513006, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_AV1_RATE_CONTROL_LAYER_INFO_KHR = 1000513007, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_AV1_QUALITY_LEVEL_PROPERTIES_KHR = 1000513008, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_AV1_SESSION_CREATE_INFO_KHR = 1000513009, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_AV1_GOP_REMAINING_FRAME_INFO_KHR = 1000513010, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VIDEO_MAINTENANCE_1_FEATURES_KHR = 1000515000, 
    VK_STRUCTURE_TYPE_VIDEO_INLINE_QUERY_INFO_KHR = 1000515001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PER_STAGE_DESCRIPTOR_SET_FEATURES_NV = 1000516000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_PROCESSING_2_FEATURES_QCOM = 1000518000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_PROCESSING_2_PROPERTIES_QCOM = 1000518001, 
    VK_STRUCTURE_TYPE_SAMPLER_BLOCK_MATCH_WINDOW_CREATE_INFO_QCOM = 1000518002, 
    VK_STRUCTURE_TYPE_SAMPLER_CUBIC_WEIGHTS_CREATE_INFO_QCOM = 1000519000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CUBIC_WEIGHTS_FEATURES_QCOM = 1000519001, 
    VK_STRUCTURE_TYPE_BLIT_IMAGE_CUBIC_WEIGHTS_INFO_QCOM = 1000519002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_YCBCR_DEGAMMA_FEATURES_QCOM = 1000520000, 
    VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_YCBCR_DEGAMMA_CREATE_INFO_QCOM = 1000520001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CUBIC_CLAMP_FEATURES_QCOM = 1000521000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ATTACHMENT_FEEDBACK_LOOP_DYNAMIC_STATE_FEATURES_EXT = 1000524000, 
    VK_STRUCTURE_TYPE_SCREEN_BUFFER_PROPERTIES_QNX = 1000529000, 
    VK_STRUCTURE_TYPE_SCREEN_BUFFER_FORMAT_PROPERTIES_QNX = 1000529001, 
    VK_STRUCTURE_TYPE_IMPORT_SCREEN_BUFFER_INFO_QNX = 1000529002, 
    VK_STRUCTURE_TYPE_EXTERNAL_FORMAT_QNX = 1000529003, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_MEMORY_SCREEN_BUFFER_FEATURES_QNX = 1000529004, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LAYERED_DRIVER_PROPERTIES_MSFT = 1000530000, 
    VK_STRUCTURE_TYPE_CALIBRATED_TIMESTAMP_INFO_KHR = 1000184000, 
    VK_STRUCTURE_TYPE_SET_DESCRIPTOR_BUFFER_OFFSETS_INFO_EXT = 1000545007, 
    VK_STRUCTURE_TYPE_BIND_DESCRIPTOR_BUFFER_EMBEDDED_SAMPLERS_INFO_EXT = 1000545008, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_POOL_OVERALLOCATION_FEATURES_NV = 1000546000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TILE_MEMORY_HEAP_FEATURES_QCOM = 1000547000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TILE_MEMORY_HEAP_PROPERTIES_QCOM = 1000547001, 
    VK_STRUCTURE_TYPE_TILE_MEMORY_REQUIREMENTS_QCOM = 1000547002, 
    VK_STRUCTURE_TYPE_TILE_MEMORY_BIND_INFO_QCOM = 1000547003, 
    VK_STRUCTURE_TYPE_TILE_MEMORY_SIZE_INFO_QCOM = 1000547004, 
    VK_STRUCTURE_TYPE_DISPLAY_SURFACE_STEREO_CREATE_INFO_NV = 1000551000, 
    VK_STRUCTURE_TYPE_DISPLAY_MODE_STEREO_PROPERTIES_NV = 1000551001, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_QUANTIZATION_MAP_CAPABILITIES_KHR = 1000553000, 
    VK_STRUCTURE_TYPE_VIDEO_FORMAT_QUANTIZATION_MAP_PROPERTIES_KHR = 1000553001, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_QUANTIZATION_MAP_INFO_KHR = 1000553002, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_QUANTIZATION_MAP_SESSION_PARAMETERS_CREATE_INFO_KHR = 1000553005, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VIDEO_ENCODE_QUANTIZATION_MAP_FEATURES_KHR = 1000553009, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H264_QUANTIZATION_MAP_CAPABILITIES_KHR = 1000553003, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_H265_QUANTIZATION_MAP_CAPABILITIES_KHR = 1000553004, 
    VK_STRUCTURE_TYPE_VIDEO_FORMAT_H265_QUANTIZATION_MAP_PROPERTIES_KHR = 1000553006, 
    VK_STRUCTURE_TYPE_VIDEO_ENCODE_AV1_QUANTIZATION_MAP_CAPABILITIES_KHR = 1000553007, 
    VK_STRUCTURE_TYPE_VIDEO_FORMAT_AV1_QUANTIZATION_MAP_PROPERTIES_KHR = 1000553008, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAW_ACCESS_CHAINS_FEATURES_NV = 1000555000, 
    VK_STRUCTURE_TYPE_EXTERNAL_COMPUTE_QUEUE_DEVICE_CREATE_INFO_NV = 1000556000, 
    VK_STRUCTURE_TYPE_EXTERNAL_COMPUTE_QUEUE_CREATE_INFO_NV = 1000556001, 
    VK_STRUCTURE_TYPE_EXTERNAL_COMPUTE_QUEUE_DATA_PARAMS_NV = 1000556002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_COMPUTE_QUEUE_PROPERTIES_NV = 1000556003, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_RELAXED_EXTENDED_INSTRUCTION_FEATURES_KHR = 1000558000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COMMAND_BUFFER_INHERITANCE_FEATURES_NV = 1000559000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_7_FEATURES_KHR = 1000562000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_7_PROPERTIES_KHR = 1000562001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LAYERED_API_PROPERTIES_LIST_KHR = 1000562002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LAYERED_API_PROPERTIES_KHR = 1000562003, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LAYERED_API_VULKAN_PROPERTIES_KHR = 1000562004, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_ATOMIC_FLOAT16_VECTOR_FEATURES_NV = 1000563000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_REPLICATED_COMPOSITES_FEATURES_EXT = 1000564000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RAY_TRACING_VALIDATION_FEATURES_NV = 1000568000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CLUSTER_ACCELERATION_STRUCTURE_FEATURES_NV = 1000569000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_CLUSTER_ACCELERATION_STRUCTURE_PROPERTIES_NV = 1000569001, 
    VK_STRUCTURE_TYPE_CLUSTER_ACCELERATION_STRUCTURE_CLUSTERS_BOTTOM_LEVEL_INPUT_NV = 1000569002, 
    VK_STRUCTURE_TYPE_CLUSTER_ACCELERATION_STRUCTURE_TRIANGLE_CLUSTER_INPUT_NV = 1000569003, 
    VK_STRUCTURE_TYPE_CLUSTER_ACCELERATION_STRUCTURE_MOVE_OBJECTS_INPUT_NV = 1000569004, 
    VK_STRUCTURE_TYPE_CLUSTER_ACCELERATION_STRUCTURE_INPUT_INFO_NV = 1000569005, 
    VK_STRUCTURE_TYPE_CLUSTER_ACCELERATION_STRUCTURE_COMMANDS_INFO_NV = 1000569006, 
    VK_STRUCTURE_TYPE_RAY_TRACING_PIPELINE_CLUSTER_ACCELERATION_STRUCTURE_CREATE_INFO_NV = 1000569007, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PARTITIONED_ACCELERATION_STRUCTURE_FEATURES_NV = 1000570000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PARTITIONED_ACCELERATION_STRUCTURE_PROPERTIES_NV = 1000570001, 
    VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET_PARTITIONED_ACCELERATION_STRUCTURE_NV = 1000570002, 
    VK_STRUCTURE_TYPE_PARTITIONED_ACCELERATION_STRUCTURE_INSTANCES_INPUT_NV = 1000570003, 
    VK_STRUCTURE_TYPE_BUILD_PARTITIONED_ACCELERATION_STRUCTURE_INFO_NV = 1000570004, 
    VK_STRUCTURE_TYPE_PARTITIONED_ACCELERATION_STRUCTURE_FLAGS_NV = 1000570005, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEVICE_GENERATED_COMMANDS_FEATURES_EXT = 1000572000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEVICE_GENERATED_COMMANDS_PROPERTIES_EXT = 1000572001, 
    VK_STRUCTURE_TYPE_GENERATED_COMMANDS_MEMORY_REQUIREMENTS_INFO_EXT = 1000572002, 
    VK_STRUCTURE_TYPE_INDIRECT_EXECUTION_SET_CREATE_INFO_EXT = 1000572003, 
    VK_STRUCTURE_TYPE_GENERATED_COMMANDS_INFO_EXT = 1000572004, 
    VK_STRUCTURE_TYPE_INDIRECT_COMMANDS_LAYOUT_CREATE_INFO_EXT = 1000572006, 
    VK_STRUCTURE_TYPE_INDIRECT_COMMANDS_LAYOUT_TOKEN_EXT = 1000572007, 
    VK_STRUCTURE_TYPE_WRITE_INDIRECT_EXECUTION_SET_PIPELINE_EXT = 1000572008, 
    VK_STRUCTURE_TYPE_WRITE_INDIRECT_EXECUTION_SET_SHADER_EXT = 1000572009, 
    VK_STRUCTURE_TYPE_INDIRECT_EXECUTION_SET_PIPELINE_INFO_EXT = 1000572010, 
    VK_STRUCTURE_TYPE_INDIRECT_EXECUTION_SET_SHADER_INFO_EXT = 1000572011, 
    VK_STRUCTURE_TYPE_INDIRECT_EXECUTION_SET_SHADER_LAYOUT_INFO_EXT = 1000572012, 
    VK_STRUCTURE_TYPE_GENERATED_COMMANDS_PIPELINE_INFO_EXT = 1000572013, 
    VK_STRUCTURE_TYPE_GENERATED_COMMANDS_SHADER_INFO_EXT = 1000572014, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_8_FEATURES_KHR = 1000574000, 
    VK_STRUCTURE_TYPE_MEMORY_BARRIER_ACCESS_FLAGS_3_KHR = 1000574002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_ALIGNMENT_CONTROL_FEATURES_MESA = 1000575000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_ALIGNMENT_CONTROL_PROPERTIES_MESA = 1000575001, 
    VK_STRUCTURE_TYPE_IMAGE_ALIGNMENT_CONTROL_CREATE_INFO_MESA = 1000575002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEPTH_CLAMP_CONTROL_FEATURES_EXT = 1000582000, 
    VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_DEPTH_CLAMP_CONTROL_CREATE_INFO_EXT = 1000582001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VIDEO_MAINTENANCE_2_FEATURES_KHR = 1000586000, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_H264_INLINE_SESSION_PARAMETERS_INFO_KHR = 1000586001, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_H265_INLINE_SESSION_PARAMETERS_INFO_KHR = 1000586002, 
    VK_STRUCTURE_TYPE_VIDEO_DECODE_AV1_INLINE_SESSION_PARAMETERS_INFO_KHR = 1000586003, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_HDR_VIVID_FEATURES_HUAWEI = 1000590000, 
    VK_STRUCTURE_TYPE_HDR_VIVID_DYNAMIC_METADATA_HUAWEI = 1000590001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COOPERATIVE_MATRIX_2_FEATURES_NV = 1000593000, 
    VK_STRUCTURE_TYPE_COOPERATIVE_MATRIX_FLEXIBLE_DIMENSIONS_PROPERTIES_NV = 1000593001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COOPERATIVE_MATRIX_2_PROPERTIES_NV = 1000593002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_OPACITY_MICROMAP_FEATURES_ARM = 1000596000, 
    VK_STRUCTURE_TYPE_IMPORT_MEMORY_METAL_HANDLE_INFO_EXT = 1000602000, 
    VK_STRUCTURE_TYPE_MEMORY_METAL_HANDLE_PROPERTIES_EXT = 1000602001, 
    VK_STRUCTURE_TYPE_MEMORY_GET_METAL_HANDLE_INFO_EXT = 1000602002, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEPTH_CLAMP_ZERO_ONE_FEATURES_KHR = 1000421000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VERTEX_ATTRIBUTE_ROBUSTNESS_FEATURES_EXT = 1000608000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ROBUSTNESS_2_FEATURES_KHR = 1000286000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ROBUSTNESS_2_PROPERTIES_KHR = 1000286001, 
    VK_STRUCTURE_TYPE_SET_PRESENT_CONFIG_NV = 1000613000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PRESENT_METERING_FEATURES_NV = 1000613001, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_DENSITY_MAP_OFFSET_FEATURES_EXT = 1000425000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_DENSITY_MAP_OFFSET_PROPERTIES_EXT = 1000425001, 
    VK_STRUCTURE_TYPE_RENDER_PASS_FRAGMENT_DENSITY_MAP_OFFSET_END_INFO_EXT = 1000425002, 
    VK_STRUCTURE_TYPE_RENDERING_END_INFO_EXT = 1000619003, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ZERO_INITIALIZE_DEVICE_MEMORY_FEATURES_EXT = 1000620000, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTER_FEATURES = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTERS_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_DRAW_PARAMETER_FEATURES = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_DRAW_PARAMETERS_FEATURES, 
  // VK_STRUCTURE_TYPE_DEBUG_REPORT_CREATE_INFO_EXT is a deprecated alias 
    VK_STRUCTURE_TYPE_DEBUG_REPORT_CREATE_INFO_EXT = VK_STRUCTURE_TYPE_DEBUG_REPORT_CALLBACK_CREATE_INFO_EXT, 
    VK_STRUCTURE_TYPE_RENDERING_INFO_KHR = VK_STRUCTURE_TYPE_RENDERING_INFO, 
    VK_STRUCTURE_TYPE_RENDERING_ATTACHMENT_INFO_KHR = VK_STRUCTURE_TYPE_RENDERING_ATTACHMENT_INFO, 
    VK_STRUCTURE_TYPE_PIPELINE_RENDERING_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_PIPELINE_RENDERING_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DYNAMIC_RENDERING_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DYNAMIC_RENDERING_FEATURES, 
    VK_STRUCTURE_TYPE_COMMAND_BUFFER_INHERITANCE_RENDERING_INFO_KHR = VK_STRUCTURE_TYPE_COMMAND_BUFFER_INHERITANCE_RENDERING_INFO, 
    VK_STRUCTURE_TYPE_RENDER_PASS_MULTIVIEW_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_RENDER_PASS_MULTIVIEW_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_PROPERTIES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_PROPERTIES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FEATURES_2_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FEATURES_2, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROPERTIES_2_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROPERTIES_2, 
    VK_STRUCTURE_TYPE_FORMAT_PROPERTIES_2_KHR = VK_STRUCTURE_TYPE_FORMAT_PROPERTIES_2, 
    VK_STRUCTURE_TYPE_IMAGE_FORMAT_PROPERTIES_2_KHR = VK_STRUCTURE_TYPE_IMAGE_FORMAT_PROPERTIES_2, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_FORMAT_INFO_2_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_FORMAT_INFO_2, 
    VK_STRUCTURE_TYPE_QUEUE_FAMILY_PROPERTIES_2_KHR = VK_STRUCTURE_TYPE_QUEUE_FAMILY_PROPERTIES_2, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MEMORY_PROPERTIES_2_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MEMORY_PROPERTIES_2, 
    VK_STRUCTURE_TYPE_SPARSE_IMAGE_FORMAT_PROPERTIES_2_KHR = VK_STRUCTURE_TYPE_SPARSE_IMAGE_FORMAT_PROPERTIES_2, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SPARSE_IMAGE_FORMAT_INFO_2_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SPARSE_IMAGE_FORMAT_INFO_2, 
    VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_FLAGS_INFO_KHR = VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_FLAGS_INFO, 
    VK_STRUCTURE_TYPE_DEVICE_GROUP_RENDER_PASS_BEGIN_INFO_KHR = VK_STRUCTURE_TYPE_DEVICE_GROUP_RENDER_PASS_BEGIN_INFO, 
    VK_STRUCTURE_TYPE_DEVICE_GROUP_COMMAND_BUFFER_BEGIN_INFO_KHR = VK_STRUCTURE_TYPE_DEVICE_GROUP_COMMAND_BUFFER_BEGIN_INFO, 
    VK_STRUCTURE_TYPE_DEVICE_GROUP_SUBMIT_INFO_KHR = VK_STRUCTURE_TYPE_DEVICE_GROUP_SUBMIT_INFO, 
    VK_STRUCTURE_TYPE_DEVICE_GROUP_BIND_SPARSE_INFO_KHR = VK_STRUCTURE_TYPE_DEVICE_GROUP_BIND_SPARSE_INFO, 
    VK_STRUCTURE_TYPE_BIND_BUFFER_MEMORY_DEVICE_GROUP_INFO_KHR = VK_STRUCTURE_TYPE_BIND_BUFFER_MEMORY_DEVICE_GROUP_INFO, 
    VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_DEVICE_GROUP_INFO_KHR = VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_DEVICE_GROUP_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TEXTURE_COMPRESSION_ASTC_HDR_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TEXTURE_COMPRESSION_ASTC_HDR_FEATURES, 
    VK_STRUCTURE_TYPE_PIPELINE_ROBUSTNESS_CREATE_INFO_EXT = VK_STRUCTURE_TYPE_PIPELINE_ROBUSTNESS_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_ROBUSTNESS_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_ROBUSTNESS_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_ROBUSTNESS_PROPERTIES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_ROBUSTNESS_PROPERTIES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_GROUP_PROPERTIES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_GROUP_PROPERTIES, 
    VK_STRUCTURE_TYPE_DEVICE_GROUP_DEVICE_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_DEVICE_GROUP_DEVICE_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_IMAGE_FORMAT_INFO_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_IMAGE_FORMAT_INFO, 
    VK_STRUCTURE_TYPE_EXTERNAL_IMAGE_FORMAT_PROPERTIES_KHR = VK_STRUCTURE_TYPE_EXTERNAL_IMAGE_FORMAT_PROPERTIES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_BUFFER_INFO_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_BUFFER_INFO, 
    VK_STRUCTURE_TYPE_EXTERNAL_BUFFER_PROPERTIES_KHR = VK_STRUCTURE_TYPE_EXTERNAL_BUFFER_PROPERTIES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ID_PROPERTIES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ID_PROPERTIES, 
    VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_BUFFER_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_BUFFER_CREATE_INFO, 
    VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_IMAGE_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_IMAGE_CREATE_INFO, 
    VK_STRUCTURE_TYPE_EXPORT_MEMORY_ALLOCATE_INFO_KHR = VK_STRUCTURE_TYPE_EXPORT_MEMORY_ALLOCATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_SEMAPHORE_INFO_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_SEMAPHORE_INFO, 
    VK_STRUCTURE_TYPE_EXTERNAL_SEMAPHORE_PROPERTIES_KHR = VK_STRUCTURE_TYPE_EXTERNAL_SEMAPHORE_PROPERTIES, 
    VK_STRUCTURE_TYPE_EXPORT_SEMAPHORE_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_EXPORT_SEMAPHORE_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PUSH_DESCRIPTOR_PROPERTIES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PUSH_DESCRIPTOR_PROPERTIES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_FLOAT16_INT8_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_FLOAT16_INT8_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FLOAT16_INT8_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_FLOAT16_INT8_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_16BIT_STORAGE_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_16BIT_STORAGE_FEATURES, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_UPDATE_TEMPLATE_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_DESCRIPTOR_UPDATE_TEMPLATE_CREATE_INFO, 
  // VK_STRUCTURE_TYPE_SURFACE_CAPABILITIES2_EXT is a deprecated alias 
    VK_STRUCTURE_TYPE_SURFACE_CAPABILITIES2_EXT = VK_STRUCTURE_TYPE_SURFACE_CAPABILITIES_2_EXT, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGELESS_FRAMEBUFFER_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGELESS_FRAMEBUFFER_FEATURES, 
    VK_STRUCTURE_TYPE_FRAMEBUFFER_ATTACHMENTS_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_FRAMEBUFFER_ATTACHMENTS_CREATE_INFO, 
    VK_STRUCTURE_TYPE_FRAMEBUFFER_ATTACHMENT_IMAGE_INFO_KHR = VK_STRUCTURE_TYPE_FRAMEBUFFER_ATTACHMENT_IMAGE_INFO, 
    VK_STRUCTURE_TYPE_RENDER_PASS_ATTACHMENT_BEGIN_INFO_KHR = VK_STRUCTURE_TYPE_RENDER_PASS_ATTACHMENT_BEGIN_INFO, 
    VK_STRUCTURE_TYPE_ATTACHMENT_DESCRIPTION_2_KHR = VK_STRUCTURE_TYPE_ATTACHMENT_DESCRIPTION_2, 
    VK_STRUCTURE_TYPE_ATTACHMENT_REFERENCE_2_KHR = VK_STRUCTURE_TYPE_ATTACHMENT_REFERENCE_2, 
    VK_STRUCTURE_TYPE_SUBPASS_DESCRIPTION_2_KHR = VK_STRUCTURE_TYPE_SUBPASS_DESCRIPTION_2, 
    VK_STRUCTURE_TYPE_SUBPASS_DEPENDENCY_2_KHR = VK_STRUCTURE_TYPE_SUBPASS_DEPENDENCY_2, 
    VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO_2_KHR = VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO_2, 
    VK_STRUCTURE_TYPE_SUBPASS_BEGIN_INFO_KHR = VK_STRUCTURE_TYPE_SUBPASS_BEGIN_INFO, 
    VK_STRUCTURE_TYPE_SUBPASS_END_INFO_KHR = VK_STRUCTURE_TYPE_SUBPASS_END_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_FENCE_INFO_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_FENCE_INFO, 
    VK_STRUCTURE_TYPE_EXTERNAL_FENCE_PROPERTIES_KHR = VK_STRUCTURE_TYPE_EXTERNAL_FENCE_PROPERTIES, 
    VK_STRUCTURE_TYPE_EXPORT_FENCE_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_EXPORT_FENCE_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_POINT_CLIPPING_PROPERTIES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_POINT_CLIPPING_PROPERTIES, 
    VK_STRUCTURE_TYPE_RENDER_PASS_INPUT_ATTACHMENT_ASPECT_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_RENDER_PASS_INPUT_ATTACHMENT_ASPECT_CREATE_INFO, 
    VK_STRUCTURE_TYPE_IMAGE_VIEW_USAGE_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_IMAGE_VIEW_USAGE_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PIPELINE_TESSELLATION_DOMAIN_ORIGIN_STATE_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_PIPELINE_TESSELLATION_DOMAIN_ORIGIN_STATE_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTERS_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTERS_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTER_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTERS_FEATURES_KHR, 
    VK_STRUCTURE_TYPE_MEMORY_DEDICATED_REQUIREMENTS_KHR = VK_STRUCTURE_TYPE_MEMORY_DEDICATED_REQUIREMENTS, 
    VK_STRUCTURE_TYPE_MEMORY_DEDICATED_ALLOCATE_INFO_KHR = VK_STRUCTURE_TYPE_MEMORY_DEDICATED_ALLOCATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLER_FILTER_MINMAX_PROPERTIES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLER_FILTER_MINMAX_PROPERTIES, 
    VK_STRUCTURE_TYPE_SAMPLER_REDUCTION_MODE_CREATE_INFO_EXT = VK_STRUCTURE_TYPE_SAMPLER_REDUCTION_MODE_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INLINE_UNIFORM_BLOCK_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INLINE_UNIFORM_BLOCK_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INLINE_UNIFORM_BLOCK_PROPERTIES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INLINE_UNIFORM_BLOCK_PROPERTIES, 
    VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET_INLINE_UNIFORM_BLOCK_EXT = VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET_INLINE_UNIFORM_BLOCK, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_INLINE_UNIFORM_BLOCK_CREATE_INFO_EXT = VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_INLINE_UNIFORM_BLOCK_CREATE_INFO, 
    VK_STRUCTURE_TYPE_BUFFER_MEMORY_REQUIREMENTS_INFO_2_KHR = VK_STRUCTURE_TYPE_BUFFER_MEMORY_REQUIREMENTS_INFO_2, 
    VK_STRUCTURE_TYPE_IMAGE_MEMORY_REQUIREMENTS_INFO_2_KHR = VK_STRUCTURE_TYPE_IMAGE_MEMORY_REQUIREMENTS_INFO_2, 
    VK_STRUCTURE_TYPE_IMAGE_SPARSE_MEMORY_REQUIREMENTS_INFO_2_KHR = VK_STRUCTURE_TYPE_IMAGE_SPARSE_MEMORY_REQUIREMENTS_INFO_2, 
    VK_STRUCTURE_TYPE_MEMORY_REQUIREMENTS_2_KHR = VK_STRUCTURE_TYPE_MEMORY_REQUIREMENTS_2, 
    VK_STRUCTURE_TYPE_SPARSE_IMAGE_MEMORY_REQUIREMENTS_2_KHR = VK_STRUCTURE_TYPE_SPARSE_IMAGE_MEMORY_REQUIREMENTS_2, 
    VK_STRUCTURE_TYPE_IMAGE_FORMAT_LIST_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_IMAGE_FORMAT_LIST_CREATE_INFO, 
    VK_STRUCTURE_TYPE_ATTACHMENT_SAMPLE_COUNT_INFO_NV = VK_STRUCTURE_TYPE_ATTACHMENT_SAMPLE_COUNT_INFO_AMD, 
    VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_CREATE_INFO, 
    VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_INFO_KHR = VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_INFO, 
    VK_STRUCTURE_TYPE_BIND_IMAGE_PLANE_MEMORY_INFO_KHR = VK_STRUCTURE_TYPE_BIND_IMAGE_PLANE_MEMORY_INFO, 
    VK_STRUCTURE_TYPE_IMAGE_PLANE_MEMORY_REQUIREMENTS_INFO_KHR = VK_STRUCTURE_TYPE_IMAGE_PLANE_MEMORY_REQUIREMENTS_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLER_YCBCR_CONVERSION_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLER_YCBCR_CONVERSION_FEATURES, 
    VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_IMAGE_FORMAT_PROPERTIES_KHR = VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_IMAGE_FORMAT_PROPERTIES, 
    VK_STRUCTURE_TYPE_BIND_BUFFER_MEMORY_INFO_KHR = VK_STRUCTURE_TYPE_BIND_BUFFER_MEMORY_INFO, 
    VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_INFO_KHR = VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_INFO, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_BINDING_FLAGS_CREATE_INFO_EXT = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_BINDING_FLAGS_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_INDEXING_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_INDEXING_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_INDEXING_PROPERTIES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_INDEXING_PROPERTIES, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_SET_VARIABLE_DESCRIPTOR_COUNT_ALLOCATE_INFO_EXT = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_VARIABLE_DESCRIPTOR_COUNT_ALLOCATE_INFO, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_SET_VARIABLE_DESCRIPTOR_COUNT_LAYOUT_SUPPORT_EXT = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_VARIABLE_DESCRIPTOR_COUNT_LAYOUT_SUPPORT, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_3_PROPERTIES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_3_PROPERTIES, 
    VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_SUPPORT_KHR = VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_SUPPORT, 
    VK_STRUCTURE_TYPE_DEVICE_QUEUE_GLOBAL_PRIORITY_CREATE_INFO_EXT = VK_STRUCTURE_TYPE_DEVICE_QUEUE_GLOBAL_PRIORITY_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_SUBGROUP_EXTENDED_TYPES_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_SUBGROUP_EXTENDED_TYPES_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_8BIT_STORAGE_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_8BIT_STORAGE_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_ATOMIC_INT64_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_ATOMIC_INT64_FEATURES, 
    VK_STRUCTURE_TYPE_CALIBRATED_TIMESTAMP_INFO_EXT = VK_STRUCTURE_TYPE_CALIBRATED_TIMESTAMP_INFO_KHR, 
    VK_STRUCTURE_TYPE_DEVICE_QUEUE_GLOBAL_PRIORITY_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_DEVICE_QUEUE_GLOBAL_PRIORITY_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_GLOBAL_PRIORITY_QUERY_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_GLOBAL_PRIORITY_QUERY_FEATURES, 
    VK_STRUCTURE_TYPE_QUEUE_FAMILY_GLOBAL_PRIORITY_PROPERTIES_KHR = VK_STRUCTURE_TYPE_QUEUE_FAMILY_GLOBAL_PRIORITY_PROPERTIES, 
    VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_DIVISOR_STATE_CREATE_INFO_EXT = VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_DIVISOR_STATE_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VERTEX_ATTRIBUTE_DIVISOR_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VERTEX_ATTRIBUTE_DIVISOR_FEATURES, 
    VK_STRUCTURE_TYPE_PIPELINE_CREATION_FEEDBACK_CREATE_INFO_EXT = VK_STRUCTURE_TYPE_PIPELINE_CREATION_FEEDBACK_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DRIVER_PROPERTIES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DRIVER_PROPERTIES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FLOAT_CONTROLS_PROPERTIES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FLOAT_CONTROLS_PROPERTIES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEPTH_STENCIL_RESOLVE_PROPERTIES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEPTH_STENCIL_RESOLVE_PROPERTIES, 
    VK_STRUCTURE_TYPE_SUBPASS_DESCRIPTION_DEPTH_STENCIL_RESOLVE_KHR = VK_STRUCTURE_TYPE_SUBPASS_DESCRIPTION_DEPTH_STENCIL_RESOLVE, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COMPUTE_SHADER_DERIVATIVES_FEATURES_NV = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_COMPUTE_SHADER_DERIVATIVES_FEATURES_KHR, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADER_BARYCENTRIC_FEATURES_NV = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_SHADER_BARYCENTRIC_FEATURES_KHR, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TIMELINE_SEMAPHORE_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TIMELINE_SEMAPHORE_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TIMELINE_SEMAPHORE_PROPERTIES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TIMELINE_SEMAPHORE_PROPERTIES, 
    VK_STRUCTURE_TYPE_SEMAPHORE_TYPE_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_SEMAPHORE_TYPE_CREATE_INFO, 
    VK_STRUCTURE_TYPE_TIMELINE_SEMAPHORE_SUBMIT_INFO_KHR = VK_STRUCTURE_TYPE_TIMELINE_SEMAPHORE_SUBMIT_INFO, 
    VK_STRUCTURE_TYPE_SEMAPHORE_WAIT_INFO_KHR = VK_STRUCTURE_TYPE_SEMAPHORE_WAIT_INFO, 
    VK_STRUCTURE_TYPE_SEMAPHORE_SIGNAL_INFO_KHR = VK_STRUCTURE_TYPE_SEMAPHORE_SIGNAL_INFO, 
  // VK_STRUCTURE_TYPE_QUERY_POOL_CREATE_INFO_INTEL is a deprecated alias 
    VK_STRUCTURE_TYPE_QUERY_POOL_CREATE_INFO_INTEL = VK_STRUCTURE_TYPE_QUERY_POOL_PERFORMANCE_QUERY_CREATE_INFO_INTEL, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_MEMORY_MODEL_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_MEMORY_MODEL_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_TERMINATE_INVOCATION_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_TERMINATE_INVOCATION_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SCALAR_BLOCK_LAYOUT_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SCALAR_BLOCK_LAYOUT_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SUBGROUP_SIZE_CONTROL_PROPERTIES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SUBGROUP_SIZE_CONTROL_PROPERTIES, 
    VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_REQUIRED_SUBGROUP_SIZE_CREATE_INFO_EXT = VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_REQUIRED_SUBGROUP_SIZE_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SUBGROUP_SIZE_CONTROL_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SUBGROUP_SIZE_CONTROL_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DYNAMIC_RENDERING_LOCAL_READ_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DYNAMIC_RENDERING_LOCAL_READ_FEATURES, 
    VK_STRUCTURE_TYPE_RENDERING_ATTACHMENT_LOCATION_INFO_KHR = VK_STRUCTURE_TYPE_RENDERING_ATTACHMENT_LOCATION_INFO, 
    VK_STRUCTURE_TYPE_RENDERING_INPUT_ATTACHMENT_INDEX_INFO_KHR = VK_STRUCTURE_TYPE_RENDERING_INPUT_ATTACHMENT_INDEX_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SEPARATE_DEPTH_STENCIL_LAYOUTS_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SEPARATE_DEPTH_STENCIL_LAYOUTS_FEATURES, 
    VK_STRUCTURE_TYPE_ATTACHMENT_REFERENCE_STENCIL_LAYOUT_KHR = VK_STRUCTURE_TYPE_ATTACHMENT_REFERENCE_STENCIL_LAYOUT, 
    VK_STRUCTURE_TYPE_ATTACHMENT_DESCRIPTION_STENCIL_LAYOUT_KHR = VK_STRUCTURE_TYPE_ATTACHMENT_DESCRIPTION_STENCIL_LAYOUT, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BUFFER_ADDRESS_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BUFFER_DEVICE_ADDRESS_FEATURES_EXT, 
    VK_STRUCTURE_TYPE_BUFFER_DEVICE_ADDRESS_INFO_EXT = VK_STRUCTURE_TYPE_BUFFER_DEVICE_ADDRESS_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TOOL_PROPERTIES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TOOL_PROPERTIES, 
    VK_STRUCTURE_TYPE_IMAGE_STENCIL_USAGE_CREATE_INFO_EXT = VK_STRUCTURE_TYPE_IMAGE_STENCIL_USAGE_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_UNIFORM_BUFFER_STANDARD_LAYOUT_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_UNIFORM_BUFFER_STANDARD_LAYOUT_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BUFFER_DEVICE_ADDRESS_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BUFFER_DEVICE_ADDRESS_FEATURES, 
    VK_STRUCTURE_TYPE_BUFFER_DEVICE_ADDRESS_INFO_KHR = VK_STRUCTURE_TYPE_BUFFER_DEVICE_ADDRESS_INFO, 
    VK_STRUCTURE_TYPE_BUFFER_OPAQUE_CAPTURE_ADDRESS_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_BUFFER_OPAQUE_CAPTURE_ADDRESS_CREATE_INFO, 
    VK_STRUCTURE_TYPE_MEMORY_OPAQUE_CAPTURE_ADDRESS_ALLOCATE_INFO_KHR = VK_STRUCTURE_TYPE_MEMORY_OPAQUE_CAPTURE_ADDRESS_ALLOCATE_INFO, 
    VK_STRUCTURE_TYPE_DEVICE_MEMORY_OPAQUE_CAPTURE_ADDRESS_INFO_KHR = VK_STRUCTURE_TYPE_DEVICE_MEMORY_OPAQUE_CAPTURE_ADDRESS_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LINE_RASTERIZATION_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LINE_RASTERIZATION_FEATURES, 
    VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_LINE_STATE_CREATE_INFO_EXT = VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_LINE_STATE_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LINE_RASTERIZATION_PROPERTIES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LINE_RASTERIZATION_PROPERTIES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_HOST_QUERY_RESET_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_HOST_QUERY_RESET_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INDEX_TYPE_UINT8_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INDEX_TYPE_UINT8_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_HOST_IMAGE_COPY_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_HOST_IMAGE_COPY_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_HOST_IMAGE_COPY_PROPERTIES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_HOST_IMAGE_COPY_PROPERTIES, 
    VK_STRUCTURE_TYPE_MEMORY_TO_IMAGE_COPY_EXT = VK_STRUCTURE_TYPE_MEMORY_TO_IMAGE_COPY, 
    VK_STRUCTURE_TYPE_IMAGE_TO_MEMORY_COPY_EXT = VK_STRUCTURE_TYPE_IMAGE_TO_MEMORY_COPY, 
    VK_STRUCTURE_TYPE_COPY_IMAGE_TO_MEMORY_INFO_EXT = VK_STRUCTURE_TYPE_COPY_IMAGE_TO_MEMORY_INFO, 
    VK_STRUCTURE_TYPE_COPY_MEMORY_TO_IMAGE_INFO_EXT = VK_STRUCTURE_TYPE_COPY_MEMORY_TO_IMAGE_INFO, 
    VK_STRUCTURE_TYPE_HOST_IMAGE_LAYOUT_TRANSITION_INFO_EXT = VK_STRUCTURE_TYPE_HOST_IMAGE_LAYOUT_TRANSITION_INFO, 
    VK_STRUCTURE_TYPE_COPY_IMAGE_TO_IMAGE_INFO_EXT = VK_STRUCTURE_TYPE_COPY_IMAGE_TO_IMAGE_INFO, 
    VK_STRUCTURE_TYPE_SUBRESOURCE_HOST_MEMCPY_SIZE_EXT = VK_STRUCTURE_TYPE_SUBRESOURCE_HOST_MEMCPY_SIZE, 
    VK_STRUCTURE_TYPE_HOST_IMAGE_COPY_DEVICE_PERFORMANCE_QUERY_EXT = VK_STRUCTURE_TYPE_HOST_IMAGE_COPY_DEVICE_PERFORMANCE_QUERY, 
    VK_STRUCTURE_TYPE_MEMORY_MAP_INFO_KHR = VK_STRUCTURE_TYPE_MEMORY_MAP_INFO, 
    VK_STRUCTURE_TYPE_MEMORY_UNMAP_INFO_KHR = VK_STRUCTURE_TYPE_MEMORY_UNMAP_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_DEMOTE_TO_HELPER_INVOCATION_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_DEMOTE_TO_HELPER_INVOCATION_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_INTEGER_DOT_PRODUCT_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_INTEGER_DOT_PRODUCT_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_INTEGER_DOT_PRODUCT_PROPERTIES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_INTEGER_DOT_PRODUCT_PROPERTIES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TEXEL_BUFFER_ALIGNMENT_PROPERTIES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TEXEL_BUFFER_ALIGNMENT_PROPERTIES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ROBUSTNESS_2_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ROBUSTNESS_2_FEATURES_KHR, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ROBUSTNESS_2_PROPERTIES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ROBUSTNESS_2_PROPERTIES_KHR, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PRIVATE_DATA_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PRIVATE_DATA_FEATURES, 
    VK_STRUCTURE_TYPE_DEVICE_PRIVATE_DATA_CREATE_INFO_EXT = VK_STRUCTURE_TYPE_DEVICE_PRIVATE_DATA_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PRIVATE_DATA_SLOT_CREATE_INFO_EXT = VK_STRUCTURE_TYPE_PRIVATE_DATA_SLOT_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_CREATION_CACHE_CONTROL_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_CREATION_CACHE_CONTROL_FEATURES, 
    VK_STRUCTURE_TYPE_MEMORY_BARRIER_2_KHR = VK_STRUCTURE_TYPE_MEMORY_BARRIER_2, 
    VK_STRUCTURE_TYPE_BUFFER_MEMORY_BARRIER_2_KHR = VK_STRUCTURE_TYPE_BUFFER_MEMORY_BARRIER_2, 
    VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER_2_KHR = VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER_2, 
    VK_STRUCTURE_TYPE_DEPENDENCY_INFO_KHR = VK_STRUCTURE_TYPE_DEPENDENCY_INFO, 
    VK_STRUCTURE_TYPE_SUBMIT_INFO_2_KHR = VK_STRUCTURE_TYPE_SUBMIT_INFO_2, 
    VK_STRUCTURE_TYPE_SEMAPHORE_SUBMIT_INFO_KHR = VK_STRUCTURE_TYPE_SEMAPHORE_SUBMIT_INFO, 
    VK_STRUCTURE_TYPE_COMMAND_BUFFER_SUBMIT_INFO_KHR = VK_STRUCTURE_TYPE_COMMAND_BUFFER_SUBMIT_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SYNCHRONIZATION_2_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SYNCHRONIZATION_2_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ZERO_INITIALIZE_WORKGROUP_MEMORY_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ZERO_INITIALIZE_WORKGROUP_MEMORY_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_ROBUSTNESS_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_ROBUSTNESS_FEATURES, 
    VK_STRUCTURE_TYPE_COPY_BUFFER_INFO_2_KHR = VK_STRUCTURE_TYPE_COPY_BUFFER_INFO_2, 
    VK_STRUCTURE_TYPE_COPY_IMAGE_INFO_2_KHR = VK_STRUCTURE_TYPE_COPY_IMAGE_INFO_2, 
    VK_STRUCTURE_TYPE_COPY_BUFFER_TO_IMAGE_INFO_2_KHR = VK_STRUCTURE_TYPE_COPY_BUFFER_TO_IMAGE_INFO_2, 
    VK_STRUCTURE_TYPE_COPY_IMAGE_TO_BUFFER_INFO_2_KHR = VK_STRUCTURE_TYPE_COPY_IMAGE_TO_BUFFER_INFO_2, 
    VK_STRUCTURE_TYPE_BLIT_IMAGE_INFO_2_KHR = VK_STRUCTURE_TYPE_BLIT_IMAGE_INFO_2, 
    VK_STRUCTURE_TYPE_RESOLVE_IMAGE_INFO_2_KHR = VK_STRUCTURE_TYPE_RESOLVE_IMAGE_INFO_2, 
    VK_STRUCTURE_TYPE_BUFFER_COPY_2_KHR = VK_STRUCTURE_TYPE_BUFFER_COPY_2, 
    VK_STRUCTURE_TYPE_IMAGE_COPY_2_KHR = VK_STRUCTURE_TYPE_IMAGE_COPY_2, 
    VK_STRUCTURE_TYPE_IMAGE_BLIT_2_KHR = VK_STRUCTURE_TYPE_IMAGE_BLIT_2, 
    VK_STRUCTURE_TYPE_BUFFER_IMAGE_COPY_2_KHR = VK_STRUCTURE_TYPE_BUFFER_IMAGE_COPY_2, 
    VK_STRUCTURE_TYPE_IMAGE_RESOLVE_2_KHR = VK_STRUCTURE_TYPE_IMAGE_RESOLVE_2, 
    VK_STRUCTURE_TYPE_SUBRESOURCE_LAYOUT_2_EXT = VK_STRUCTURE_TYPE_SUBRESOURCE_LAYOUT_2, 
    VK_STRUCTURE_TYPE_IMAGE_SUBRESOURCE_2_EXT = VK_STRUCTURE_TYPE_IMAGE_SUBRESOURCE_2, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RASTERIZATION_ORDER_ATTACHMENT_ACCESS_FEATURES_ARM = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_RASTERIZATION_ORDER_ATTACHMENT_ACCESS_FEATURES_EXT, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MUTABLE_DESCRIPTOR_TYPE_FEATURES_VALVE = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MUTABLE_DESCRIPTOR_TYPE_FEATURES_EXT, 
    VK_STRUCTURE_TYPE_MUTABLE_DESCRIPTOR_TYPE_CREATE_INFO_VALVE = VK_STRUCTURE_TYPE_MUTABLE_DESCRIPTOR_TYPE_CREATE_INFO_EXT, 
    VK_STRUCTURE_TYPE_FORMAT_PROPERTIES_3_KHR = VK_STRUCTURE_TYPE_FORMAT_PROPERTIES_3, 
    VK_STRUCTURE_TYPE_PIPELINE_INFO_EXT = VK_STRUCTURE_TYPE_PIPELINE_INFO_KHR, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_GLOBAL_PRIORITY_QUERY_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_GLOBAL_PRIORITY_QUERY_FEATURES, 
    VK_STRUCTURE_TYPE_QUEUE_FAMILY_GLOBAL_PRIORITY_PROPERTIES_EXT = VK_STRUCTURE_TYPE_QUEUE_FAMILY_GLOBAL_PRIORITY_PROPERTIES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_4_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_4_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_4_PROPERTIES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_4_PROPERTIES, 
    VK_STRUCTURE_TYPE_DEVICE_BUFFER_MEMORY_REQUIREMENTS_KHR = VK_STRUCTURE_TYPE_DEVICE_BUFFER_MEMORY_REQUIREMENTS, 
    VK_STRUCTURE_TYPE_DEVICE_IMAGE_MEMORY_REQUIREMENTS_KHR = VK_STRUCTURE_TYPE_DEVICE_IMAGE_MEMORY_REQUIREMENTS, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_SUBGROUP_ROTATE_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_SUBGROUP_ROTATE_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEPTH_CLAMP_ZERO_ONE_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEPTH_CLAMP_ZERO_ONE_FEATURES_KHR, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_DENSITY_MAP_OFFSET_FEATURES_QCOM = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_DENSITY_MAP_OFFSET_FEATURES_EXT, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_DENSITY_MAP_OFFSET_PROPERTIES_QCOM = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FRAGMENT_DENSITY_MAP_OFFSET_PROPERTIES_EXT, 
    VK_STRUCTURE_TYPE_SUBPASS_FRAGMENT_DENSITY_MAP_OFFSET_END_INFO_QCOM = VK_STRUCTURE_TYPE_RENDER_PASS_FRAGMENT_DENSITY_MAP_OFFSET_END_INFO_EXT, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_PROTECTED_ACCESS_FEATURES_EXT = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PIPELINE_PROTECTED_ACCESS_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_5_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_5_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_5_PROPERTIES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_5_PROPERTIES, 
    VK_STRUCTURE_TYPE_RENDERING_AREA_INFO_KHR = VK_STRUCTURE_TYPE_RENDERING_AREA_INFO, 
    VK_STRUCTURE_TYPE_DEVICE_IMAGE_SUBRESOURCE_INFO_KHR = VK_STRUCTURE_TYPE_DEVICE_IMAGE_SUBRESOURCE_INFO, 
    VK_STRUCTURE_TYPE_SUBRESOURCE_LAYOUT_2_KHR = VK_STRUCTURE_TYPE_SUBRESOURCE_LAYOUT_2, 
    VK_STRUCTURE_TYPE_IMAGE_SUBRESOURCE_2_KHR = VK_STRUCTURE_TYPE_IMAGE_SUBRESOURCE_2, 
    VK_STRUCTURE_TYPE_PIPELINE_CREATE_FLAGS_2_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_PIPELINE_CREATE_FLAGS_2_CREATE_INFO, 
    VK_STRUCTURE_TYPE_BUFFER_USAGE_FLAGS_2_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_BUFFER_USAGE_FLAGS_2_CREATE_INFO, 
    VK_STRUCTURE_TYPE_SHADER_REQUIRED_SUBGROUP_SIZE_CREATE_INFO_EXT = VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_REQUIRED_SUBGROUP_SIZE_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VERTEX_ATTRIBUTE_DIVISOR_PROPERTIES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VERTEX_ATTRIBUTE_DIVISOR_PROPERTIES, 
    VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_DIVISOR_STATE_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_DIVISOR_STATE_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VERTEX_ATTRIBUTE_DIVISOR_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VERTEX_ATTRIBUTE_DIVISOR_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_FLOAT_CONTROLS_2_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_FLOAT_CONTROLS_2_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INDEX_TYPE_UINT8_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_INDEX_TYPE_UINT8_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LINE_RASTERIZATION_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LINE_RASTERIZATION_FEATURES, 
    VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_LINE_STATE_CREATE_INFO_KHR = VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_LINE_STATE_CREATE_INFO, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LINE_RASTERIZATION_PROPERTIES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_LINE_RASTERIZATION_PROPERTIES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_EXPECT_ASSUME_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_EXPECT_ASSUME_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_6_FEATURES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_6_FEATURES, 
    VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_6_PROPERTIES_KHR = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_6_PROPERTIES, 
    VK_STRUCTURE_TYPE_BIND_MEMORY_STATUS_KHR = VK_STRUCTURE_TYPE_BIND_MEMORY_STATUS, 
    VK_STRUCTURE_TYPE_BIND_DESCRIPTOR_SETS_INFO_KHR = VK_STRUCTURE_TYPE_BIND_DESCRIPTOR_SETS_INFO, 
    VK_STRUCTURE_TYPE_PUSH_CONSTANTS_INFO_KHR = VK_STRUCTURE_TYPE_PUSH_CONSTANTS_INFO, 
    VK_STRUCTURE_TYPE_PUSH_DESCRIPTOR_SET_INFO_KHR = VK_STRUCTURE_TYPE_PUSH_DESCRIPTOR_SET_INFO, 
    VK_STRUCTURE_TYPE_PUSH_DESCRIPTOR_SET_WITH_TEMPLATE_INFO_KHR = VK_STRUCTURE_TYPE_PUSH_DESCRIPTOR_SET_WITH_TEMPLATE_INFO, 
    VK_STRUCTURE_TYPE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkPipelineCacheHeaderVersion : uint   {
    VK_PIPELINE_CACHE_HEADER_VERSION_ONE = 1, 
    VK_PIPELINE_CACHE_HEADER_VERSION_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkImageLayout : uint   {
    VK_IMAGE_LAYOUT_UNDEFINED = 0, 
    VK_IMAGE_LAYOUT_GENERAL = 1, 
    VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL = 2, 
    VK_IMAGE_LAYOUT_DEPTH_STENCIL_ATTACHMENT_OPTIMAL = 3, 
    VK_IMAGE_LAYOUT_DEPTH_STENCIL_READ_ONLY_OPTIMAL = 4, 
    VK_IMAGE_LAYOUT_SHADER_READ_ONLY_OPTIMAL = 5, 
    VK_IMAGE_LAYOUT_TRANSFER_SRC_OPTIMAL = 6, 
    VK_IMAGE_LAYOUT_TRANSFER_DST_OPTIMAL = 7, 
    VK_IMAGE_LAYOUT_PREINITIALIZED = 8, 
    VK_IMAGE_LAYOUT_DEPTH_READ_ONLY_STENCIL_ATTACHMENT_OPTIMAL = 1000117000, 
    VK_IMAGE_LAYOUT_DEPTH_ATTACHMENT_STENCIL_READ_ONLY_OPTIMAL = 1000117001, 
    VK_IMAGE_LAYOUT_DEPTH_ATTACHMENT_OPTIMAL = 1000241000, 
    VK_IMAGE_LAYOUT_DEPTH_READ_ONLY_OPTIMAL = 1000241001, 
    VK_IMAGE_LAYOUT_STENCIL_ATTACHMENT_OPTIMAL = 1000241002, 
    VK_IMAGE_LAYOUT_STENCIL_READ_ONLY_OPTIMAL = 1000241003, 
    VK_IMAGE_LAYOUT_READ_ONLY_OPTIMAL = 1000314000, 
    VK_IMAGE_LAYOUT_ATTACHMENT_OPTIMAL = 1000314001, 
    VK_IMAGE_LAYOUT_RENDERING_LOCAL_READ = 1000232000, 
    VK_IMAGE_LAYOUT_PRESENT_SRC_KHR = 1000001002, 
    VK_IMAGE_LAYOUT_VIDEO_DECODE_DST_KHR = 1000024000, 
    VK_IMAGE_LAYOUT_VIDEO_DECODE_SRC_KHR = 1000024001, 
    VK_IMAGE_LAYOUT_VIDEO_DECODE_DPB_KHR = 1000024002, 
    VK_IMAGE_LAYOUT_SHARED_PRESENT_KHR = 1000111000, 
    VK_IMAGE_LAYOUT_FRAGMENT_DENSITY_MAP_OPTIMAL_EXT = 1000218000, 
    VK_IMAGE_LAYOUT_FRAGMENT_SHADING_RATE_ATTACHMENT_OPTIMAL_KHR = 1000164003, 
    VK_IMAGE_LAYOUT_VIDEO_ENCODE_DST_KHR = 1000299000, 
    VK_IMAGE_LAYOUT_VIDEO_ENCODE_SRC_KHR = 1000299001, 
    VK_IMAGE_LAYOUT_VIDEO_ENCODE_DPB_KHR = 1000299002, 
    VK_IMAGE_LAYOUT_ATTACHMENT_FEEDBACK_LOOP_OPTIMAL_EXT = 1000339000, 
    VK_IMAGE_LAYOUT_VIDEO_ENCODE_QUANTIZATION_MAP_KHR = 1000553000, 
    VK_IMAGE_LAYOUT_ZERO_INITIALIZED_EXT = 1000620000, 
    VK_IMAGE_LAYOUT_DEPTH_READ_ONLY_STENCIL_ATTACHMENT_OPTIMAL_KHR = VK_IMAGE_LAYOUT_DEPTH_READ_ONLY_STENCIL_ATTACHMENT_OPTIMAL, 
    VK_IMAGE_LAYOUT_DEPTH_ATTACHMENT_STENCIL_READ_ONLY_OPTIMAL_KHR = VK_IMAGE_LAYOUT_DEPTH_ATTACHMENT_STENCIL_READ_ONLY_OPTIMAL, 
    VK_IMAGE_LAYOUT_SHADING_RATE_OPTIMAL_NV = VK_IMAGE_LAYOUT_FRAGMENT_SHADING_RATE_ATTACHMENT_OPTIMAL_KHR, 
    VK_IMAGE_LAYOUT_RENDERING_LOCAL_READ_KHR = VK_IMAGE_LAYOUT_RENDERING_LOCAL_READ, 
    VK_IMAGE_LAYOUT_DEPTH_ATTACHMENT_OPTIMAL_KHR = VK_IMAGE_LAYOUT_DEPTH_ATTACHMENT_OPTIMAL, 
    VK_IMAGE_LAYOUT_DEPTH_READ_ONLY_OPTIMAL_KHR = VK_IMAGE_LAYOUT_DEPTH_READ_ONLY_OPTIMAL, 
    VK_IMAGE_LAYOUT_STENCIL_ATTACHMENT_OPTIMAL_KHR = VK_IMAGE_LAYOUT_STENCIL_ATTACHMENT_OPTIMAL, 
    VK_IMAGE_LAYOUT_STENCIL_READ_ONLY_OPTIMAL_KHR = VK_IMAGE_LAYOUT_STENCIL_READ_ONLY_OPTIMAL, 
    VK_IMAGE_LAYOUT_READ_ONLY_OPTIMAL_KHR = VK_IMAGE_LAYOUT_READ_ONLY_OPTIMAL, 
    VK_IMAGE_LAYOUT_ATTACHMENT_OPTIMAL_KHR = VK_IMAGE_LAYOUT_ATTACHMENT_OPTIMAL, 
    VK_IMAGE_LAYOUT_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkObjectType : uint   {
    VK_OBJECT_TYPE_UNKNOWN = 0, 
    VK_OBJECT_TYPE_INSTANCE = 1, 
    VK_OBJECT_TYPE_PHYSICAL_DEVICE = 2, 
    VK_OBJECT_TYPE_DEVICE = 3, 
    VK_OBJECT_TYPE_QUEUE = 4, 
    VK_OBJECT_TYPE_SEMAPHORE = 5, 
    VK_OBJECT_TYPE_COMMAND_BUFFER = 6, 
    VK_OBJECT_TYPE_FENCE = 7, 
    VK_OBJECT_TYPE_DEVICE_MEMORY = 8, 
    VK_OBJECT_TYPE_BUFFER = 9, 
    VK_OBJECT_TYPE_IMAGE = 10, 
    VK_OBJECT_TYPE_EVENT = 11, 
    VK_OBJECT_TYPE_QUERY_POOL = 12, 
    VK_OBJECT_TYPE_BUFFER_VIEW = 13, 
    VK_OBJECT_TYPE_IMAGE_VIEW = 14, 
    VK_OBJECT_TYPE_SHADER_MODULE = 15, 
    VK_OBJECT_TYPE_PIPELINE_CACHE = 16, 
    VK_OBJECT_TYPE_PIPELINE_LAYOUT = 17, 
    VK_OBJECT_TYPE_RENDER_PASS = 18, 
    VK_OBJECT_TYPE_PIPELINE = 19, 
    VK_OBJECT_TYPE_DESCRIPTOR_SET_LAYOUT = 20, 
    VK_OBJECT_TYPE_SAMPLER = 21, 
    VK_OBJECT_TYPE_DESCRIPTOR_POOL = 22, 
    VK_OBJECT_TYPE_DESCRIPTOR_SET = 23, 
    VK_OBJECT_TYPE_FRAMEBUFFER = 24, 
    VK_OBJECT_TYPE_COMMAND_POOL = 25, 
    VK_OBJECT_TYPE_SAMPLER_YCBCR_CONVERSION = 1000156000, 
    VK_OBJECT_TYPE_DESCRIPTOR_UPDATE_TEMPLATE = 1000085000, 
    VK_OBJECT_TYPE_PRIVATE_DATA_SLOT = 1000295000, 
    VK_OBJECT_TYPE_SURFACE_KHR = 1000000000, 
    VK_OBJECT_TYPE_SWAPCHAIN_KHR = 1000001000, 
    VK_OBJECT_TYPE_DISPLAY_KHR = 1000002000, 
    VK_OBJECT_TYPE_DISPLAY_MODE_KHR = 1000002001, 
    VK_OBJECT_TYPE_DEBUG_REPORT_CALLBACK_EXT = 1000011000, 
    VK_OBJECT_TYPE_VIDEO_SESSION_KHR = 1000023000, 
    VK_OBJECT_TYPE_VIDEO_SESSION_PARAMETERS_KHR = 1000023001, 
    VK_OBJECT_TYPE_CU_MODULE_NVX = 1000029000, 
    VK_OBJECT_TYPE_CU_FUNCTION_NVX = 1000029001, 
    VK_OBJECT_TYPE_DEBUG_UTILS_MESSENGER_EXT = 1000128000, 
    VK_OBJECT_TYPE_ACCELERATION_STRUCTURE_KHR = 1000150000, 
    VK_OBJECT_TYPE_VALIDATION_CACHE_EXT = 1000160000, 
    VK_OBJECT_TYPE_ACCELERATION_STRUCTURE_NV = 1000165000, 
    VK_OBJECT_TYPE_PERFORMANCE_CONFIGURATION_INTEL = 1000210000, 
    VK_OBJECT_TYPE_DEFERRED_OPERATION_KHR = 1000268000, 
    VK_OBJECT_TYPE_INDIRECT_COMMANDS_LAYOUT_NV = 1000277000, 
    VK_OBJECT_TYPE_CUDA_MODULE_NV = 1000307000, 
    VK_OBJECT_TYPE_CUDA_FUNCTION_NV = 1000307001, 
    VK_OBJECT_TYPE_BUFFER_COLLECTION_FUCHSIA = 1000366000, 
    VK_OBJECT_TYPE_MICROMAP_EXT = 1000396000, 
    VK_OBJECT_TYPE_OPTICAL_FLOW_SESSION_NV = 1000464000, 
    VK_OBJECT_TYPE_SHADER_EXT = 1000482000, 
    VK_OBJECT_TYPE_PIPELINE_BINARY_KHR = 1000483000, 
    VK_OBJECT_TYPE_EXTERNAL_COMPUTE_QUEUE_NV = 1000556000, 
    VK_OBJECT_TYPE_INDIRECT_COMMANDS_LAYOUT_EXT = 1000572000, 
    VK_OBJECT_TYPE_INDIRECT_EXECUTION_SET_EXT = 1000572001, 
    VK_OBJECT_TYPE_DESCRIPTOR_UPDATE_TEMPLATE_KHR = VK_OBJECT_TYPE_DESCRIPTOR_UPDATE_TEMPLATE, 
    VK_OBJECT_TYPE_SAMPLER_YCBCR_CONVERSION_KHR = VK_OBJECT_TYPE_SAMPLER_YCBCR_CONVERSION, 
    VK_OBJECT_TYPE_PRIVATE_DATA_SLOT_EXT = VK_OBJECT_TYPE_PRIVATE_DATA_SLOT, 
    VK_OBJECT_TYPE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkVendorId : uint   {
    VK_VENDOR_ID_KHRONOS = 0x10000, 
    VK_VENDOR_ID_VIV = 0x10001, 
    VK_VENDOR_ID_VSI = 0x10002, 
    VK_VENDOR_ID_KAZAN = 0x10003, 
    VK_VENDOR_ID_CODEPLAY = 0x10004, 
    VK_VENDOR_ID_MESA = 0x10005, 
    VK_VENDOR_ID_POCL = 0x10006, 
    VK_VENDOR_ID_MOBILEYE = 0x10007, 
    VK_VENDOR_ID_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkSystemAllocationScope : uint   {
    VK_SYSTEM_ALLOCATION_SCOPE_COMMAND = 0, 
    VK_SYSTEM_ALLOCATION_SCOPE_OBJECT = 1, 
    VK_SYSTEM_ALLOCATION_SCOPE_CACHE = 2, 
    VK_SYSTEM_ALLOCATION_SCOPE_DEVICE = 3, 
    VK_SYSTEM_ALLOCATION_SCOPE_INSTANCE = 4, 
    VK_SYSTEM_ALLOCATION_SCOPE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkInternalAllocationType : uint   {
    VK_INTERNAL_ALLOCATION_TYPE_EXECUTABLE = 0, 
    VK_INTERNAL_ALLOCATION_TYPE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkFormat : uint   {
    VK_FORMAT_UNDEFINED = 0, 
    VK_FORMAT_R4G4_UNORM_PACK8 = 1, 
    VK_FORMAT_R4G4B4A4_UNORM_PACK16 = 2, 
    VK_FORMAT_B4G4R4A4_UNORM_PACK16 = 3, 
    VK_FORMAT_R5G6B5_UNORM_PACK16 = 4, 
    VK_FORMAT_B5G6R5_UNORM_PACK16 = 5, 
    VK_FORMAT_R5G5B5A1_UNORM_PACK16 = 6, 
    VK_FORMAT_B5G5R5A1_UNORM_PACK16 = 7, 
    VK_FORMAT_A1R5G5B5_UNORM_PACK16 = 8, 
    VK_FORMAT_R8_UNORM = 9, 
    VK_FORMAT_R8_SNORM = 10, 
    VK_FORMAT_R8_USCALED = 11, 
    VK_FORMAT_R8_SSCALED = 12, 
    VK_FORMAT_R8_UINT = 13, 
    VK_FORMAT_R8_SINT = 14, 
    VK_FORMAT_R8_SRGB = 15, 
    VK_FORMAT_R8G8_UNORM = 16, 
    VK_FORMAT_R8G8_SNORM = 17, 
    VK_FORMAT_R8G8_USCALED = 18, 
    VK_FORMAT_R8G8_SSCALED = 19, 
    VK_FORMAT_R8G8_UINT = 20, 
    VK_FORMAT_R8G8_SINT = 21, 
    VK_FORMAT_R8G8_SRGB = 22, 
    VK_FORMAT_R8G8B8_UNORM = 23, 
    VK_FORMAT_R8G8B8_SNORM = 24, 
    VK_FORMAT_R8G8B8_USCALED = 25, 
    VK_FORMAT_R8G8B8_SSCALED = 26, 
    VK_FORMAT_R8G8B8_UINT = 27, 
    VK_FORMAT_R8G8B8_SINT = 28, 
    VK_FORMAT_R8G8B8_SRGB = 29, 
    VK_FORMAT_B8G8R8_UNORM = 30, 
    VK_FORMAT_B8G8R8_SNORM = 31, 
    VK_FORMAT_B8G8R8_USCALED = 32, 
    VK_FORMAT_B8G8R8_SSCALED = 33, 
    VK_FORMAT_B8G8R8_UINT = 34, 
    VK_FORMAT_B8G8R8_SINT = 35, 
    VK_FORMAT_B8G8R8_SRGB = 36, 
    VK_FORMAT_R8G8B8A8_UNORM = 37, 
    VK_FORMAT_R8G8B8A8_SNORM = 38, 
    VK_FORMAT_R8G8B8A8_USCALED = 39, 
    VK_FORMAT_R8G8B8A8_SSCALED = 40, 
    VK_FORMAT_R8G8B8A8_UINT = 41, 
    VK_FORMAT_R8G8B8A8_SINT = 42, 
    VK_FORMAT_R8G8B8A8_SRGB = 43, 
    VK_FORMAT_B8G8R8A8_UNORM = 44, 
    VK_FORMAT_B8G8R8A8_SNORM = 45, 
    VK_FORMAT_B8G8R8A8_USCALED = 46, 
    VK_FORMAT_B8G8R8A8_SSCALED = 47, 
    VK_FORMAT_B8G8R8A8_UINT = 48, 
    VK_FORMAT_B8G8R8A8_SINT = 49, 
    VK_FORMAT_B8G8R8A8_SRGB = 50, 
    VK_FORMAT_A8B8G8R8_UNORM_PACK32 = 51, 
    VK_FORMAT_A8B8G8R8_SNORM_PACK32 = 52, 
    VK_FORMAT_A8B8G8R8_USCALED_PACK32 = 53, 
    VK_FORMAT_A8B8G8R8_SSCALED_PACK32 = 54, 
    VK_FORMAT_A8B8G8R8_UINT_PACK32 = 55, 
    VK_FORMAT_A8B8G8R8_SINT_PACK32 = 56, 
    VK_FORMAT_A8B8G8R8_SRGB_PACK32 = 57, 
    VK_FORMAT_A2R10G10B10_UNORM_PACK32 = 58, 
    VK_FORMAT_A2R10G10B10_SNORM_PACK32 = 59, 
    VK_FORMAT_A2R10G10B10_USCALED_PACK32 = 60, 
    VK_FORMAT_A2R10G10B10_SSCALED_PACK32 = 61, 
    VK_FORMAT_A2R10G10B10_UINT_PACK32 = 62, 
    VK_FORMAT_A2R10G10B10_SINT_PACK32 = 63, 
    VK_FORMAT_A2B10G10R10_UNORM_PACK32 = 64, 
    VK_FORMAT_A2B10G10R10_SNORM_PACK32 = 65, 
    VK_FORMAT_A2B10G10R10_USCALED_PACK32 = 66, 
    VK_FORMAT_A2B10G10R10_SSCALED_PACK32 = 67, 
    VK_FORMAT_A2B10G10R10_UINT_PACK32 = 68, 
    VK_FORMAT_A2B10G10R10_SINT_PACK32 = 69, 
    VK_FORMAT_R16_UNORM = 70, 
    VK_FORMAT_R16_SNORM = 71, 
    VK_FORMAT_R16_USCALED = 72, 
    VK_FORMAT_R16_SSCALED = 73, 
    VK_FORMAT_R16_UINT = 74, 
    VK_FORMAT_R16_SINT = 75, 
    VK_FORMAT_R16_SFLOAT = 76, 
    VK_FORMAT_R16G16_UNORM = 77, 
    VK_FORMAT_R16G16_SNORM = 78, 
    VK_FORMAT_R16G16_USCALED = 79, 
    VK_FORMAT_R16G16_SSCALED = 80, 
    VK_FORMAT_R16G16_UINT = 81, 
    VK_FORMAT_R16G16_SINT = 82, 
    VK_FORMAT_R16G16_SFLOAT = 83, 
    VK_FORMAT_R16G16B16_UNORM = 84, 
    VK_FORMAT_R16G16B16_SNORM = 85, 
    VK_FORMAT_R16G16B16_USCALED = 86, 
    VK_FORMAT_R16G16B16_SSCALED = 87, 
    VK_FORMAT_R16G16B16_UINT = 88, 
    VK_FORMAT_R16G16B16_SINT = 89, 
    VK_FORMAT_R16G16B16_SFLOAT = 90, 
    VK_FORMAT_R16G16B16A16_UNORM = 91, 
    VK_FORMAT_R16G16B16A16_SNORM = 92, 
    VK_FORMAT_R16G16B16A16_USCALED = 93, 
    VK_FORMAT_R16G16B16A16_SSCALED = 94, 
    VK_FORMAT_R16G16B16A16_UINT = 95, 
    VK_FORMAT_R16G16B16A16_SINT = 96, 
    VK_FORMAT_R16G16B16A16_SFLOAT = 97, 
    VK_FORMAT_R32_UINT = 98, 
    VK_FORMAT_R32_SINT = 99, 
    VK_FORMAT_R32_SFLOAT = 100, 
    VK_FORMAT_R32G32_UINT = 101, 
    VK_FORMAT_R32G32_SINT = 102, 
    VK_FORMAT_R32G32_SFLOAT = 103, 
    VK_FORMAT_R32G32B32_UINT = 104, 
    VK_FORMAT_R32G32B32_SINT = 105, 
    VK_FORMAT_R32G32B32_SFLOAT = 106, 
    VK_FORMAT_R32G32B32A32_UINT = 107, 
    VK_FORMAT_R32G32B32A32_SINT = 108, 
    VK_FORMAT_R32G32B32A32_SFLOAT = 109, 
    VK_FORMAT_R64_UINT = 110, 
    VK_FORMAT_R64_SINT = 111, 
    VK_FORMAT_R64_SFLOAT = 112, 
    VK_FORMAT_R64G64_UINT = 113, 
    VK_FORMAT_R64G64_SINT = 114, 
    VK_FORMAT_R64G64_SFLOAT = 115, 
    VK_FORMAT_R64G64B64_UINT = 116, 
    VK_FORMAT_R64G64B64_SINT = 117, 
    VK_FORMAT_R64G64B64_SFLOAT = 118, 
    VK_FORMAT_R64G64B64A64_UINT = 119, 
    VK_FORMAT_R64G64B64A64_SINT = 120, 
    VK_FORMAT_R64G64B64A64_SFLOAT = 121, 
    VK_FORMAT_B10G11R11_UFLOAT_PACK32 = 122, 
    VK_FORMAT_E5B9G9R9_UFLOAT_PACK32 = 123, 
    VK_FORMAT_D16_UNORM = 124, 
    VK_FORMAT_X8_D24_UNORM_PACK32 = 125, 
    VK_FORMAT_D32_SFLOAT = 126, 
    VK_FORMAT_S8_UINT = 127, 
    VK_FORMAT_D16_UNORM_S8_UINT = 128, 
    VK_FORMAT_D24_UNORM_S8_UINT = 129, 
    VK_FORMAT_D32_SFLOAT_S8_UINT = 130, 
    VK_FORMAT_BC1_RGB_UNORM_BLOCK = 131, 
    VK_FORMAT_BC1_RGB_SRGB_BLOCK = 132, 
    VK_FORMAT_BC1_RGBA_UNORM_BLOCK = 133, 
    VK_FORMAT_BC1_RGBA_SRGB_BLOCK = 134, 
    VK_FORMAT_BC2_UNORM_BLOCK = 135, 
    VK_FORMAT_BC2_SRGB_BLOCK = 136, 
    VK_FORMAT_BC3_UNORM_BLOCK = 137, 
    VK_FORMAT_BC3_SRGB_BLOCK = 138, 
    VK_FORMAT_BC4_UNORM_BLOCK = 139, 
    VK_FORMAT_BC4_SNORM_BLOCK = 140, 
    VK_FORMAT_BC5_UNORM_BLOCK = 141, 
    VK_FORMAT_BC5_SNORM_BLOCK = 142, 
    VK_FORMAT_BC6H_UFLOAT_BLOCK = 143, 
    VK_FORMAT_BC6H_SFLOAT_BLOCK = 144, 
    VK_FORMAT_BC7_UNORM_BLOCK = 145, 
    VK_FORMAT_BC7_SRGB_BLOCK = 146, 
    VK_FORMAT_ETC2_R8G8B8_UNORM_BLOCK = 147, 
    VK_FORMAT_ETC2_R8G8B8_SRGB_BLOCK = 148, 
    VK_FORMAT_ETC2_R8G8B8A1_UNORM_BLOCK = 149, 
    VK_FORMAT_ETC2_R8G8B8A1_SRGB_BLOCK = 150, 
    VK_FORMAT_ETC2_R8G8B8A8_UNORM_BLOCK = 151, 
    VK_FORMAT_ETC2_R8G8B8A8_SRGB_BLOCK = 152, 
    VK_FORMAT_EAC_R11_UNORM_BLOCK = 153, 
    VK_FORMAT_EAC_R11_SNORM_BLOCK = 154, 
    VK_FORMAT_EAC_R11G11_UNORM_BLOCK = 155, 
    VK_FORMAT_EAC_R11G11_SNORM_BLOCK = 156, 
    VK_FORMAT_ASTC_4x4_UNORM_BLOCK = 157, 
    VK_FORMAT_ASTC_4x4_SRGB_BLOCK = 158, 
    VK_FORMAT_ASTC_5x4_UNORM_BLOCK = 159, 
    VK_FORMAT_ASTC_5x4_SRGB_BLOCK = 160, 
    VK_FORMAT_ASTC_5x5_UNORM_BLOCK = 161, 
    VK_FORMAT_ASTC_5x5_SRGB_BLOCK = 162, 
    VK_FORMAT_ASTC_6x5_UNORM_BLOCK = 163, 
    VK_FORMAT_ASTC_6x5_SRGB_BLOCK = 164, 
    VK_FORMAT_ASTC_6x6_UNORM_BLOCK = 165, 
    VK_FORMAT_ASTC_6x6_SRGB_BLOCK = 166, 
    VK_FORMAT_ASTC_8x5_UNORM_BLOCK = 167, 
    VK_FORMAT_ASTC_8x5_SRGB_BLOCK = 168, 
    VK_FORMAT_ASTC_8x6_UNORM_BLOCK = 169, 
    VK_FORMAT_ASTC_8x6_SRGB_BLOCK = 170, 
    VK_FORMAT_ASTC_8x8_UNORM_BLOCK = 171, 
    VK_FORMAT_ASTC_8x8_SRGB_BLOCK = 172, 
    VK_FORMAT_ASTC_10x5_UNORM_BLOCK = 173, 
    VK_FORMAT_ASTC_10x5_SRGB_BLOCK = 174, 
    VK_FORMAT_ASTC_10x6_UNORM_BLOCK = 175, 
    VK_FORMAT_ASTC_10x6_SRGB_BLOCK = 176, 
    VK_FORMAT_ASTC_10x8_UNORM_BLOCK = 177, 
    VK_FORMAT_ASTC_10x8_SRGB_BLOCK = 178, 
    VK_FORMAT_ASTC_10x10_UNORM_BLOCK = 179, 
    VK_FORMAT_ASTC_10x10_SRGB_BLOCK = 180, 
    VK_FORMAT_ASTC_12x10_UNORM_BLOCK = 181, 
    VK_FORMAT_ASTC_12x10_SRGB_BLOCK = 182, 
    VK_FORMAT_ASTC_12x12_UNORM_BLOCK = 183, 
    VK_FORMAT_ASTC_12x12_SRGB_BLOCK = 184, 
    VK_FORMAT_G8B8G8R8_422_UNORM = 1000156000, 
    VK_FORMAT_B8G8R8G8_422_UNORM = 1000156001, 
    VK_FORMAT_G8_B8_R8_3PLANE_420_UNORM = 1000156002, 
    VK_FORMAT_G8_B8R8_2PLANE_420_UNORM = 1000156003, 
    VK_FORMAT_G8_B8_R8_3PLANE_422_UNORM = 1000156004, 
    VK_FORMAT_G8_B8R8_2PLANE_422_UNORM = 1000156005, 
    VK_FORMAT_G8_B8_R8_3PLANE_444_UNORM = 1000156006, 
    VK_FORMAT_R10X6_UNORM_PACK16 = 1000156007, 
    VK_FORMAT_R10X6G10X6_UNORM_2PACK16 = 1000156008, 
    VK_FORMAT_R10X6G10X6B10X6A10X6_UNORM_4PACK16 = 1000156009, 
    VK_FORMAT_G10X6B10X6G10X6R10X6_422_UNORM_4PACK16 = 1000156010, 
    VK_FORMAT_B10X6G10X6R10X6G10X6_422_UNORM_4PACK16 = 1000156011, 
    VK_FORMAT_G10X6_B10X6_R10X6_3PLANE_420_UNORM_3PACK16 = 1000156012, 
    VK_FORMAT_G10X6_B10X6R10X6_2PLANE_420_UNORM_3PACK16 = 1000156013, 
    VK_FORMAT_G10X6_B10X6_R10X6_3PLANE_422_UNORM_3PACK16 = 1000156014, 
    VK_FORMAT_G10X6_B10X6R10X6_2PLANE_422_UNORM_3PACK16 = 1000156015, 
    VK_FORMAT_G10X6_B10X6_R10X6_3PLANE_444_UNORM_3PACK16 = 1000156016, 
    VK_FORMAT_R12X4_UNORM_PACK16 = 1000156017, 
    VK_FORMAT_R12X4G12X4_UNORM_2PACK16 = 1000156018, 
    VK_FORMAT_R12X4G12X4B12X4A12X4_UNORM_4PACK16 = 1000156019, 
    VK_FORMAT_G12X4B12X4G12X4R12X4_422_UNORM_4PACK16 = 1000156020, 
    VK_FORMAT_B12X4G12X4R12X4G12X4_422_UNORM_4PACK16 = 1000156021, 
    VK_FORMAT_G12X4_B12X4_R12X4_3PLANE_420_UNORM_3PACK16 = 1000156022, 
    VK_FORMAT_G12X4_B12X4R12X4_2PLANE_420_UNORM_3PACK16 = 1000156023, 
    VK_FORMAT_G12X4_B12X4_R12X4_3PLANE_422_UNORM_3PACK16 = 1000156024, 
    VK_FORMAT_G12X4_B12X4R12X4_2PLANE_422_UNORM_3PACK16 = 1000156025, 
    VK_FORMAT_G12X4_B12X4_R12X4_3PLANE_444_UNORM_3PACK16 = 1000156026, 
    VK_FORMAT_G16B16G16R16_422_UNORM = 1000156027, 
    VK_FORMAT_B16G16R16G16_422_UNORM = 1000156028, 
    VK_FORMAT_G16_B16_R16_3PLANE_420_UNORM = 1000156029, 
    VK_FORMAT_G16_B16R16_2PLANE_420_UNORM = 1000156030, 
    VK_FORMAT_G16_B16_R16_3PLANE_422_UNORM = 1000156031, 
    VK_FORMAT_G16_B16R16_2PLANE_422_UNORM = 1000156032, 
    VK_FORMAT_G16_B16_R16_3PLANE_444_UNORM = 1000156033, 
    VK_FORMAT_G8_B8R8_2PLANE_444_UNORM = 1000330000, 
    VK_FORMAT_G10X6_B10X6R10X6_2PLANE_444_UNORM_3PACK16 = 1000330001, 
    VK_FORMAT_G12X4_B12X4R12X4_2PLANE_444_UNORM_3PACK16 = 1000330002, 
    VK_FORMAT_G16_B16R16_2PLANE_444_UNORM = 1000330003, 
    VK_FORMAT_A4R4G4B4_UNORM_PACK16 = 1000340000, 
    VK_FORMAT_A4B4G4R4_UNORM_PACK16 = 1000340001, 
    VK_FORMAT_ASTC_4x4_SFLOAT_BLOCK = 1000066000, 
    VK_FORMAT_ASTC_5x4_SFLOAT_BLOCK = 1000066001, 
    VK_FORMAT_ASTC_5x5_SFLOAT_BLOCK = 1000066002, 
    VK_FORMAT_ASTC_6x5_SFLOAT_BLOCK = 1000066003, 
    VK_FORMAT_ASTC_6x6_SFLOAT_BLOCK = 1000066004, 
    VK_FORMAT_ASTC_8x5_SFLOAT_BLOCK = 1000066005, 
    VK_FORMAT_ASTC_8x6_SFLOAT_BLOCK = 1000066006, 
    VK_FORMAT_ASTC_8x8_SFLOAT_BLOCK = 1000066007, 
    VK_FORMAT_ASTC_10x5_SFLOAT_BLOCK = 1000066008, 
    VK_FORMAT_ASTC_10x6_SFLOAT_BLOCK = 1000066009, 
    VK_FORMAT_ASTC_10x8_SFLOAT_BLOCK = 1000066010, 
    VK_FORMAT_ASTC_10x10_SFLOAT_BLOCK = 1000066011, 
    VK_FORMAT_ASTC_12x10_SFLOAT_BLOCK = 1000066012, 
    VK_FORMAT_ASTC_12x12_SFLOAT_BLOCK = 1000066013, 
    VK_FORMAT_A1B5G5R5_UNORM_PACK16 = 1000470000, 
    VK_FORMAT_A8_UNORM = 1000470001, 
    VK_FORMAT_PVRTC1_2BPP_UNORM_BLOCK_IMG = 1000054000, 
    VK_FORMAT_PVRTC1_4BPP_UNORM_BLOCK_IMG = 1000054001, 
    VK_FORMAT_PVRTC2_2BPP_UNORM_BLOCK_IMG = 1000054002, 
    VK_FORMAT_PVRTC2_4BPP_UNORM_BLOCK_IMG = 1000054003, 
    VK_FORMAT_PVRTC1_2BPP_SRGB_BLOCK_IMG = 1000054004, 
    VK_FORMAT_PVRTC1_4BPP_SRGB_BLOCK_IMG = 1000054005, 
    VK_FORMAT_PVRTC2_2BPP_SRGB_BLOCK_IMG = 1000054006, 
    VK_FORMAT_PVRTC2_4BPP_SRGB_BLOCK_IMG = 1000054007, 
    VK_FORMAT_R16G16_SFIXED5_NV = 1000464000, 
    VK_FORMAT_ASTC_4x4_SFLOAT_BLOCK_EXT = VK_FORMAT_ASTC_4x4_SFLOAT_BLOCK, 
    VK_FORMAT_ASTC_5x4_SFLOAT_BLOCK_EXT = VK_FORMAT_ASTC_5x4_SFLOAT_BLOCK, 
    VK_FORMAT_ASTC_5x5_SFLOAT_BLOCK_EXT = VK_FORMAT_ASTC_5x5_SFLOAT_BLOCK, 
    VK_FORMAT_ASTC_6x5_SFLOAT_BLOCK_EXT = VK_FORMAT_ASTC_6x5_SFLOAT_BLOCK, 
    VK_FORMAT_ASTC_6x6_SFLOAT_BLOCK_EXT = VK_FORMAT_ASTC_6x6_SFLOAT_BLOCK, 
    VK_FORMAT_ASTC_8x5_SFLOAT_BLOCK_EXT = VK_FORMAT_ASTC_8x5_SFLOAT_BLOCK, 
    VK_FORMAT_ASTC_8x6_SFLOAT_BLOCK_EXT = VK_FORMAT_ASTC_8x6_SFLOAT_BLOCK, 
    VK_FORMAT_ASTC_8x8_SFLOAT_BLOCK_EXT = VK_FORMAT_ASTC_8x8_SFLOAT_BLOCK, 
    VK_FORMAT_ASTC_10x5_SFLOAT_BLOCK_EXT = VK_FORMAT_ASTC_10x5_SFLOAT_BLOCK, 
    VK_FORMAT_ASTC_10x6_SFLOAT_BLOCK_EXT = VK_FORMAT_ASTC_10x6_SFLOAT_BLOCK, 
    VK_FORMAT_ASTC_10x8_SFLOAT_BLOCK_EXT = VK_FORMAT_ASTC_10x8_SFLOAT_BLOCK, 
    VK_FORMAT_ASTC_10x10_SFLOAT_BLOCK_EXT = VK_FORMAT_ASTC_10x10_SFLOAT_BLOCK, 
    VK_FORMAT_ASTC_12x10_SFLOAT_BLOCK_EXT = VK_FORMAT_ASTC_12x10_SFLOAT_BLOCK, 
    VK_FORMAT_ASTC_12x12_SFLOAT_BLOCK_EXT = VK_FORMAT_ASTC_12x12_SFLOAT_BLOCK, 
    VK_FORMAT_G8B8G8R8_422_UNORM_KHR = VK_FORMAT_G8B8G8R8_422_UNORM, 
    VK_FORMAT_B8G8R8G8_422_UNORM_KHR = VK_FORMAT_B8G8R8G8_422_UNORM, 
    VK_FORMAT_G8_B8_R8_3PLANE_420_UNORM_KHR = VK_FORMAT_G8_B8_R8_3PLANE_420_UNORM, 
    VK_FORMAT_G8_B8R8_2PLANE_420_UNORM_KHR = VK_FORMAT_G8_B8R8_2PLANE_420_UNORM, 
    VK_FORMAT_G8_B8_R8_3PLANE_422_UNORM_KHR = VK_FORMAT_G8_B8_R8_3PLANE_422_UNORM, 
    VK_FORMAT_G8_B8R8_2PLANE_422_UNORM_KHR = VK_FORMAT_G8_B8R8_2PLANE_422_UNORM, 
    VK_FORMAT_G8_B8_R8_3PLANE_444_UNORM_KHR = VK_FORMAT_G8_B8_R8_3PLANE_444_UNORM, 
    VK_FORMAT_R10X6_UNORM_PACK16_KHR = VK_FORMAT_R10X6_UNORM_PACK16, 
    VK_FORMAT_R10X6G10X6_UNORM_2PACK16_KHR = VK_FORMAT_R10X6G10X6_UNORM_2PACK16, 
    VK_FORMAT_R10X6G10X6B10X6A10X6_UNORM_4PACK16_KHR = VK_FORMAT_R10X6G10X6B10X6A10X6_UNORM_4PACK16, 
    VK_FORMAT_G10X6B10X6G10X6R10X6_422_UNORM_4PACK16_KHR = VK_FORMAT_G10X6B10X6G10X6R10X6_422_UNORM_4PACK16, 
    VK_FORMAT_B10X6G10X6R10X6G10X6_422_UNORM_4PACK16_KHR = VK_FORMAT_B10X6G10X6R10X6G10X6_422_UNORM_4PACK16, 
    VK_FORMAT_G10X6_B10X6_R10X6_3PLANE_420_UNORM_3PACK16_KHR = VK_FORMAT_G10X6_B10X6_R10X6_3PLANE_420_UNORM_3PACK16, 
    VK_FORMAT_G10X6_B10X6R10X6_2PLANE_420_UNORM_3PACK16_KHR = VK_FORMAT_G10X6_B10X6R10X6_2PLANE_420_UNORM_3PACK16, 
    VK_FORMAT_G10X6_B10X6_R10X6_3PLANE_422_UNORM_3PACK16_KHR = VK_FORMAT_G10X6_B10X6_R10X6_3PLANE_422_UNORM_3PACK16, 
    VK_FORMAT_G10X6_B10X6R10X6_2PLANE_422_UNORM_3PACK16_KHR = VK_FORMAT_G10X6_B10X6R10X6_2PLANE_422_UNORM_3PACK16, 
    VK_FORMAT_G10X6_B10X6_R10X6_3PLANE_444_UNORM_3PACK16_KHR = VK_FORMAT_G10X6_B10X6_R10X6_3PLANE_444_UNORM_3PACK16, 
    VK_FORMAT_R12X4_UNORM_PACK16_KHR = VK_FORMAT_R12X4_UNORM_PACK16, 
    VK_FORMAT_R12X4G12X4_UNORM_2PACK16_KHR = VK_FORMAT_R12X4G12X4_UNORM_2PACK16, 
    VK_FORMAT_R12X4G12X4B12X4A12X4_UNORM_4PACK16_KHR = VK_FORMAT_R12X4G12X4B12X4A12X4_UNORM_4PACK16, 
    VK_FORMAT_G12X4B12X4G12X4R12X4_422_UNORM_4PACK16_KHR = VK_FORMAT_G12X4B12X4G12X4R12X4_422_UNORM_4PACK16, 
    VK_FORMAT_B12X4G12X4R12X4G12X4_422_UNORM_4PACK16_KHR = VK_FORMAT_B12X4G12X4R12X4G12X4_422_UNORM_4PACK16, 
    VK_FORMAT_G12X4_B12X4_R12X4_3PLANE_420_UNORM_3PACK16_KHR = VK_FORMAT_G12X4_B12X4_R12X4_3PLANE_420_UNORM_3PACK16, 
    VK_FORMAT_G12X4_B12X4R12X4_2PLANE_420_UNORM_3PACK16_KHR = VK_FORMAT_G12X4_B12X4R12X4_2PLANE_420_UNORM_3PACK16, 
    VK_FORMAT_G12X4_B12X4_R12X4_3PLANE_422_UNORM_3PACK16_KHR = VK_FORMAT_G12X4_B12X4_R12X4_3PLANE_422_UNORM_3PACK16, 
    VK_FORMAT_G12X4_B12X4R12X4_2PLANE_422_UNORM_3PACK16_KHR = VK_FORMAT_G12X4_B12X4R12X4_2PLANE_422_UNORM_3PACK16, 
    VK_FORMAT_G12X4_B12X4_R12X4_3PLANE_444_UNORM_3PACK16_KHR = VK_FORMAT_G12X4_B12X4_R12X4_3PLANE_444_UNORM_3PACK16, 
    VK_FORMAT_G16B16G16R16_422_UNORM_KHR = VK_FORMAT_G16B16G16R16_422_UNORM, 
    VK_FORMAT_B16G16R16G16_422_UNORM_KHR = VK_FORMAT_B16G16R16G16_422_UNORM, 
    VK_FORMAT_G16_B16_R16_3PLANE_420_UNORM_KHR = VK_FORMAT_G16_B16_R16_3PLANE_420_UNORM, 
    VK_FORMAT_G16_B16R16_2PLANE_420_UNORM_KHR = VK_FORMAT_G16_B16R16_2PLANE_420_UNORM, 
    VK_FORMAT_G16_B16_R16_3PLANE_422_UNORM_KHR = VK_FORMAT_G16_B16_R16_3PLANE_422_UNORM, 
    VK_FORMAT_G16_B16R16_2PLANE_422_UNORM_KHR = VK_FORMAT_G16_B16R16_2PLANE_422_UNORM, 
    VK_FORMAT_G16_B16_R16_3PLANE_444_UNORM_KHR = VK_FORMAT_G16_B16_R16_3PLANE_444_UNORM, 
    VK_FORMAT_G8_B8R8_2PLANE_444_UNORM_EXT = VK_FORMAT_G8_B8R8_2PLANE_444_UNORM, 
    VK_FORMAT_G10X6_B10X6R10X6_2PLANE_444_UNORM_3PACK16_EXT = VK_FORMAT_G10X6_B10X6R10X6_2PLANE_444_UNORM_3PACK16, 
    VK_FORMAT_G12X4_B12X4R12X4_2PLANE_444_UNORM_3PACK16_EXT = VK_FORMAT_G12X4_B12X4R12X4_2PLANE_444_UNORM_3PACK16, 
    VK_FORMAT_G16_B16R16_2PLANE_444_UNORM_EXT = VK_FORMAT_G16_B16R16_2PLANE_444_UNORM, 
    VK_FORMAT_A4R4G4B4_UNORM_PACK16_EXT = VK_FORMAT_A4R4G4B4_UNORM_PACK16, 
    VK_FORMAT_A4B4G4R4_UNORM_PACK16_EXT = VK_FORMAT_A4B4G4R4_UNORM_PACK16, 
  // VK_FORMAT_R16G16_S10_5_NV is a deprecated alias 
    VK_FORMAT_R16G16_S10_5_NV = VK_FORMAT_R16G16_SFIXED5_NV, 
    VK_FORMAT_A1B5G5R5_UNORM_PACK16_KHR = VK_FORMAT_A1B5G5R5_UNORM_PACK16, 
    VK_FORMAT_A8_UNORM_KHR = VK_FORMAT_A8_UNORM, 
    VK_FORMAT_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkImageTiling : uint   {
    VK_IMAGE_TILING_OPTIMAL = 0, 
    VK_IMAGE_TILING_LINEAR = 1, 
    VK_IMAGE_TILING_DRM_FORMAT_MODIFIER_EXT = 1000158000, 
    VK_IMAGE_TILING_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkImageType : uint   {
    VK_IMAGE_TYPE_1D = 0, 
    VK_IMAGE_TYPE_2D = 1, 
    VK_IMAGE_TYPE_3D = 2, 
    VK_IMAGE_TYPE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkPhysicalDeviceType : uint   {
    VK_PHYSICAL_DEVICE_TYPE_OTHER = 0, 
    VK_PHYSICAL_DEVICE_TYPE_INTEGRATED_GPU = 1, 
    VK_PHYSICAL_DEVICE_TYPE_DISCRETE_GPU = 2, 
    VK_PHYSICAL_DEVICE_TYPE_VIRTUAL_GPU = 3, 
    VK_PHYSICAL_DEVICE_TYPE_CPU = 4, 
    VK_PHYSICAL_DEVICE_TYPE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkQueryType : uint   {
    VK_QUERY_TYPE_OCCLUSION = 0, 
    VK_QUERY_TYPE_PIPELINE_STATISTICS = 1, 
    VK_QUERY_TYPE_TIMESTAMP = 2, 
    VK_QUERY_TYPE_RESULT_STATUS_ONLY_KHR = 1000023000, 
    VK_QUERY_TYPE_TRANSFORM_FEEDBACK_STREAM_EXT = 1000028004, 
    VK_QUERY_TYPE_PERFORMANCE_QUERY_KHR = 1000116000, 
    VK_QUERY_TYPE_ACCELERATION_STRUCTURE_COMPACTED_SIZE_KHR = 1000150000, 
    VK_QUERY_TYPE_ACCELERATION_STRUCTURE_SERIALIZATION_SIZE_KHR = 1000150001, 
    VK_QUERY_TYPE_ACCELERATION_STRUCTURE_COMPACTED_SIZE_NV = 1000165000, 
    VK_QUERY_TYPE_PERFORMANCE_QUERY_INTEL = 1000210000, 
    VK_QUERY_TYPE_VIDEO_ENCODE_FEEDBACK_KHR = 1000299000, 
    VK_QUERY_TYPE_MESH_PRIMITIVES_GENERATED_EXT = 1000328000, 
    VK_QUERY_TYPE_PRIMITIVES_GENERATED_EXT = 1000382000, 
    VK_QUERY_TYPE_ACCELERATION_STRUCTURE_SERIALIZATION_BOTTOM_LEVEL_POINTERS_KHR = 1000386000, 
    VK_QUERY_TYPE_ACCELERATION_STRUCTURE_SIZE_KHR = 1000386001, 
    VK_QUERY_TYPE_MICROMAP_SERIALIZATION_SIZE_EXT = 1000396000, 
    VK_QUERY_TYPE_MICROMAP_COMPACTED_SIZE_EXT = 1000396001, 
    VK_QUERY_TYPE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkSharingMode : uint   {
    VK_SHARING_MODE_EXCLUSIVE = 0, 
    VK_SHARING_MODE_CONCURRENT = 1, 
    VK_SHARING_MODE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkComponentSwizzle : uint   {
    VK_COMPONENT_SWIZZLE_IDENTITY = 0, 
    VK_COMPONENT_SWIZZLE_ZERO = 1, 
    VK_COMPONENT_SWIZZLE_ONE = 2, 
    VK_COMPONENT_SWIZZLE_R = 3, 
    VK_COMPONENT_SWIZZLE_G = 4, 
    VK_COMPONENT_SWIZZLE_B = 5, 
    VK_COMPONENT_SWIZZLE_A = 6, 
    VK_COMPONENT_SWIZZLE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkImageViewType : uint   {
    VK_IMAGE_VIEW_TYPE_1D = 0, 
    VK_IMAGE_VIEW_TYPE_2D = 1, 
    VK_IMAGE_VIEW_TYPE_3D = 2, 
    VK_IMAGE_VIEW_TYPE_CUBE = 3, 
    VK_IMAGE_VIEW_TYPE_1D_ARRAY = 4, 
    VK_IMAGE_VIEW_TYPE_2D_ARRAY = 5, 
    VK_IMAGE_VIEW_TYPE_CUBE_ARRAY = 6, 
    VK_IMAGE_VIEW_TYPE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkBlendFactor : uint   {
    VK_BLEND_FACTOR_ZERO = 0, 
    VK_BLEND_FACTOR_ONE = 1, 
    VK_BLEND_FACTOR_SRC_COLOR = 2, 
    VK_BLEND_FACTOR_ONE_MINUS_SRC_COLOR = 3, 
    VK_BLEND_FACTOR_DST_COLOR = 4, 
    VK_BLEND_FACTOR_ONE_MINUS_DST_COLOR = 5, 
    VK_BLEND_FACTOR_SRC_ALPHA = 6, 
    VK_BLEND_FACTOR_ONE_MINUS_SRC_ALPHA = 7, 
    VK_BLEND_FACTOR_DST_ALPHA = 8, 
    VK_BLEND_FACTOR_ONE_MINUS_DST_ALPHA = 9, 
    VK_BLEND_FACTOR_CONSTANT_COLOR = 10, 
    VK_BLEND_FACTOR_ONE_MINUS_CONSTANT_COLOR = 11, 
    VK_BLEND_FACTOR_CONSTANT_ALPHA = 12, 
    VK_BLEND_FACTOR_ONE_MINUS_CONSTANT_ALPHA = 13, 
    VK_BLEND_FACTOR_SRC_ALPHA_SATURATE = 14, 
    VK_BLEND_FACTOR_SRC1_COLOR = 15, 
    VK_BLEND_FACTOR_ONE_MINUS_SRC1_COLOR = 16, 
    VK_BLEND_FACTOR_SRC1_ALPHA = 17, 
    VK_BLEND_FACTOR_ONE_MINUS_SRC1_ALPHA = 18, 
    VK_BLEND_FACTOR_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkBlendOp : uint   {
    VK_BLEND_OP_ADD = 0, 
    VK_BLEND_OP_SUBTRACT = 1, 
    VK_BLEND_OP_REVERSE_SUBTRACT = 2, 
    VK_BLEND_OP_MIN = 3, 
    VK_BLEND_OP_MAX = 4, 
    VK_BLEND_OP_ZERO_EXT = 1000148000, 
    VK_BLEND_OP_SRC_EXT = 1000148001, 
    VK_BLEND_OP_DST_EXT = 1000148002, 
    VK_BLEND_OP_SRC_OVER_EXT = 1000148003, 
    VK_BLEND_OP_DST_OVER_EXT = 1000148004, 
    VK_BLEND_OP_SRC_IN_EXT = 1000148005, 
    VK_BLEND_OP_DST_IN_EXT = 1000148006, 
    VK_BLEND_OP_SRC_OUT_EXT = 1000148007, 
    VK_BLEND_OP_DST_OUT_EXT = 1000148008, 
    VK_BLEND_OP_SRC_ATOP_EXT = 1000148009, 
    VK_BLEND_OP_DST_ATOP_EXT = 1000148010, 
    VK_BLEND_OP_XOR_EXT = 1000148011, 
    VK_BLEND_OP_MULTIPLY_EXT = 1000148012, 
    VK_BLEND_OP_SCREEN_EXT = 1000148013, 
    VK_BLEND_OP_OVERLAY_EXT = 1000148014, 
    VK_BLEND_OP_DARKEN_EXT = 1000148015, 
    VK_BLEND_OP_LIGHTEN_EXT = 1000148016, 
    VK_BLEND_OP_COLORDODGE_EXT = 1000148017, 
    VK_BLEND_OP_COLORBURN_EXT = 1000148018, 
    VK_BLEND_OP_HARDLIGHT_EXT = 1000148019, 
    VK_BLEND_OP_SOFTLIGHT_EXT = 1000148020, 
    VK_BLEND_OP_DIFFERENCE_EXT = 1000148021, 
    VK_BLEND_OP_EXCLUSION_EXT = 1000148022, 
    VK_BLEND_OP_INVERT_EXT = 1000148023, 
    VK_BLEND_OP_INVERT_RGB_EXT = 1000148024, 
    VK_BLEND_OP_LINEARDODGE_EXT = 1000148025, 
    VK_BLEND_OP_LINEARBURN_EXT = 1000148026, 
    VK_BLEND_OP_VIVIDLIGHT_EXT = 1000148027, 
    VK_BLEND_OP_LINEARLIGHT_EXT = 1000148028, 
    VK_BLEND_OP_PINLIGHT_EXT = 1000148029, 
    VK_BLEND_OP_HARDMIX_EXT = 1000148030, 
    VK_BLEND_OP_HSL_HUE_EXT = 1000148031, 
    VK_BLEND_OP_HSL_SATURATION_EXT = 1000148032, 
    VK_BLEND_OP_HSL_COLOR_EXT = 1000148033, 
    VK_BLEND_OP_HSL_LUMINOSITY_EXT = 1000148034, 
    VK_BLEND_OP_PLUS_EXT = 1000148035, 
    VK_BLEND_OP_PLUS_CLAMPED_EXT = 1000148036, 
    VK_BLEND_OP_PLUS_CLAMPED_ALPHA_EXT = 1000148037, 
    VK_BLEND_OP_PLUS_DARKER_EXT = 1000148038, 
    VK_BLEND_OP_MINUS_EXT = 1000148039, 
    VK_BLEND_OP_MINUS_CLAMPED_EXT = 1000148040, 
    VK_BLEND_OP_CONTRAST_EXT = 1000148041, 
    VK_BLEND_OP_INVERT_OVG_EXT = 1000148042, 
    VK_BLEND_OP_RED_EXT = 1000148043, 
    VK_BLEND_OP_GREEN_EXT = 1000148044, 
    VK_BLEND_OP_BLUE_EXT = 1000148045, 
    VK_BLEND_OP_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkCompareOp : uint   {
    VK_COMPARE_OP_NEVER = 0, 
    VK_COMPARE_OP_LESS = 1, 
    VK_COMPARE_OP_EQUAL = 2, 
    VK_COMPARE_OP_LESS_OR_EQUAL = 3, 
    VK_COMPARE_OP_GREATER = 4, 
    VK_COMPARE_OP_NOT_EQUAL = 5, 
    VK_COMPARE_OP_GREATER_OR_EQUAL = 6, 
    VK_COMPARE_OP_ALWAYS = 7, 
    VK_COMPARE_OP_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkDynamicState : uint   {
    VK_DYNAMIC_STATE_VIEWPORT = 0, 
    VK_DYNAMIC_STATE_SCISSOR = 1, 
    VK_DYNAMIC_STATE_LINE_WIDTH = 2, 
    VK_DYNAMIC_STATE_DEPTH_BIAS = 3, 
    VK_DYNAMIC_STATE_BLEND_CONSTANTS = 4, 
    VK_DYNAMIC_STATE_DEPTH_BOUNDS = 5, 
    VK_DYNAMIC_STATE_STENCIL_COMPARE_MASK = 6, 
    VK_DYNAMIC_STATE_STENCIL_WRITE_MASK = 7, 
    VK_DYNAMIC_STATE_STENCIL_REFERENCE = 8, 
    VK_DYNAMIC_STATE_CULL_MODE = 1000267000, 
    VK_DYNAMIC_STATE_FRONT_FACE = 1000267001, 
    VK_DYNAMIC_STATE_PRIMITIVE_TOPOLOGY = 1000267002, 
    VK_DYNAMIC_STATE_VIEWPORT_WITH_COUNT = 1000267003, 
    VK_DYNAMIC_STATE_SCISSOR_WITH_COUNT = 1000267004, 
    VK_DYNAMIC_STATE_VERTEX_INPUT_BINDING_STRIDE = 1000267005, 
    VK_DYNAMIC_STATE_DEPTH_TEST_ENABLE = 1000267006, 
    VK_DYNAMIC_STATE_DEPTH_WRITE_ENABLE = 1000267007, 
    VK_DYNAMIC_STATE_DEPTH_COMPARE_OP = 1000267008, 
    VK_DYNAMIC_STATE_DEPTH_BOUNDS_TEST_ENABLE = 1000267009, 
    VK_DYNAMIC_STATE_STENCIL_TEST_ENABLE = 1000267010, 
    VK_DYNAMIC_STATE_STENCIL_OP = 1000267011, 
    VK_DYNAMIC_STATE_RASTERIZER_DISCARD_ENABLE = 1000377001, 
    VK_DYNAMIC_STATE_DEPTH_BIAS_ENABLE = 1000377002, 
    VK_DYNAMIC_STATE_PRIMITIVE_RESTART_ENABLE = 1000377004, 
    VK_DYNAMIC_STATE_LINE_STIPPLE = 1000259000, 
    VK_DYNAMIC_STATE_VIEWPORT_W_SCALING_NV = 1000087000, 
    VK_DYNAMIC_STATE_DISCARD_RECTANGLE_EXT = 1000099000, 
    VK_DYNAMIC_STATE_DISCARD_RECTANGLE_ENABLE_EXT = 1000099001, 
    VK_DYNAMIC_STATE_DISCARD_RECTANGLE_MODE_EXT = 1000099002, 
    VK_DYNAMIC_STATE_SAMPLE_LOCATIONS_EXT = 1000143000, 
    VK_DYNAMIC_STATE_RAY_TRACING_PIPELINE_STACK_SIZE_KHR = 1000347000, 
    VK_DYNAMIC_STATE_VIEWPORT_SHADING_RATE_PALETTE_NV = 1000164004, 
    VK_DYNAMIC_STATE_VIEWPORT_COARSE_SAMPLE_ORDER_NV = 1000164006, 
    VK_DYNAMIC_STATE_EXCLUSIVE_SCISSOR_ENABLE_NV = 1000205000, 
    VK_DYNAMIC_STATE_EXCLUSIVE_SCISSOR_NV = 1000205001, 
    VK_DYNAMIC_STATE_FRAGMENT_SHADING_RATE_KHR = 1000226000, 
    VK_DYNAMIC_STATE_VERTEX_INPUT_EXT = 1000352000, 
    VK_DYNAMIC_STATE_PATCH_CONTROL_POINTS_EXT = 1000377000, 
    VK_DYNAMIC_STATE_LOGIC_OP_EXT = 1000377003, 
    VK_DYNAMIC_STATE_COLOR_WRITE_ENABLE_EXT = 1000381000, 
    VK_DYNAMIC_STATE_DEPTH_CLAMP_ENABLE_EXT = 1000455003, 
    VK_DYNAMIC_STATE_POLYGON_MODE_EXT = 1000455004, 
    VK_DYNAMIC_STATE_RASTERIZATION_SAMPLES_EXT = 1000455005, 
    VK_DYNAMIC_STATE_SAMPLE_MASK_EXT = 1000455006, 
    VK_DYNAMIC_STATE_ALPHA_TO_COVERAGE_ENABLE_EXT = 1000455007, 
    VK_DYNAMIC_STATE_ALPHA_TO_ONE_ENABLE_EXT = 1000455008, 
    VK_DYNAMIC_STATE_LOGIC_OP_ENABLE_EXT = 1000455009, 
    VK_DYNAMIC_STATE_COLOR_BLEND_ENABLE_EXT = 1000455010, 
    VK_DYNAMIC_STATE_COLOR_BLEND_EQUATION_EXT = 1000455011, 
    VK_DYNAMIC_STATE_COLOR_WRITE_MASK_EXT = 1000455012, 
    VK_DYNAMIC_STATE_TESSELLATION_DOMAIN_ORIGIN_EXT = 1000455002, 
    VK_DYNAMIC_STATE_RASTERIZATION_STREAM_EXT = 1000455013, 
    VK_DYNAMIC_STATE_CONSERVATIVE_RASTERIZATION_MODE_EXT = 1000455014, 
    VK_DYNAMIC_STATE_EXTRA_PRIMITIVE_OVERESTIMATION_SIZE_EXT = 1000455015, 
    VK_DYNAMIC_STATE_DEPTH_CLIP_ENABLE_EXT = 1000455016, 
    VK_DYNAMIC_STATE_SAMPLE_LOCATIONS_ENABLE_EXT = 1000455017, 
    VK_DYNAMIC_STATE_COLOR_BLEND_ADVANCED_EXT = 1000455018, 
    VK_DYNAMIC_STATE_PROVOKING_VERTEX_MODE_EXT = 1000455019, 
    VK_DYNAMIC_STATE_LINE_RASTERIZATION_MODE_EXT = 1000455020, 
    VK_DYNAMIC_STATE_LINE_STIPPLE_ENABLE_EXT = 1000455021, 
    VK_DYNAMIC_STATE_DEPTH_CLIP_NEGATIVE_ONE_TO_ONE_EXT = 1000455022, 
    VK_DYNAMIC_STATE_VIEWPORT_W_SCALING_ENABLE_NV = 1000455023, 
    VK_DYNAMIC_STATE_VIEWPORT_SWIZZLE_NV = 1000455024, 
    VK_DYNAMIC_STATE_COVERAGE_TO_COLOR_ENABLE_NV = 1000455025, 
    VK_DYNAMIC_STATE_COVERAGE_TO_COLOR_LOCATION_NV = 1000455026, 
    VK_DYNAMIC_STATE_COVERAGE_MODULATION_MODE_NV = 1000455027, 
    VK_DYNAMIC_STATE_COVERAGE_MODULATION_TABLE_ENABLE_NV = 1000455028, 
    VK_DYNAMIC_STATE_COVERAGE_MODULATION_TABLE_NV = 1000455029, 
    VK_DYNAMIC_STATE_SHADING_RATE_IMAGE_ENABLE_NV = 1000455030, 
    VK_DYNAMIC_STATE_REPRESENTATIVE_FRAGMENT_TEST_ENABLE_NV = 1000455031, 
    VK_DYNAMIC_STATE_COVERAGE_REDUCTION_MODE_NV = 1000455032, 
    VK_DYNAMIC_STATE_ATTACHMENT_FEEDBACK_LOOP_ENABLE_EXT = 1000524000, 
    VK_DYNAMIC_STATE_DEPTH_CLAMP_RANGE_EXT = 1000582000, 
    VK_DYNAMIC_STATE_LINE_STIPPLE_EXT = VK_DYNAMIC_STATE_LINE_STIPPLE, 
    VK_DYNAMIC_STATE_CULL_MODE_EXT = VK_DYNAMIC_STATE_CULL_MODE, 
    VK_DYNAMIC_STATE_FRONT_FACE_EXT = VK_DYNAMIC_STATE_FRONT_FACE, 
    VK_DYNAMIC_STATE_PRIMITIVE_TOPOLOGY_EXT = VK_DYNAMIC_STATE_PRIMITIVE_TOPOLOGY, 
    VK_DYNAMIC_STATE_VIEWPORT_WITH_COUNT_EXT = VK_DYNAMIC_STATE_VIEWPORT_WITH_COUNT, 
    VK_DYNAMIC_STATE_SCISSOR_WITH_COUNT_EXT = VK_DYNAMIC_STATE_SCISSOR_WITH_COUNT, 
    VK_DYNAMIC_STATE_VERTEX_INPUT_BINDING_STRIDE_EXT = VK_DYNAMIC_STATE_VERTEX_INPUT_BINDING_STRIDE, 
    VK_DYNAMIC_STATE_DEPTH_TEST_ENABLE_EXT = VK_DYNAMIC_STATE_DEPTH_TEST_ENABLE, 
    VK_DYNAMIC_STATE_DEPTH_WRITE_ENABLE_EXT = VK_DYNAMIC_STATE_DEPTH_WRITE_ENABLE, 
    VK_DYNAMIC_STATE_DEPTH_COMPARE_OP_EXT = VK_DYNAMIC_STATE_DEPTH_COMPARE_OP, 
    VK_DYNAMIC_STATE_DEPTH_BOUNDS_TEST_ENABLE_EXT = VK_DYNAMIC_STATE_DEPTH_BOUNDS_TEST_ENABLE, 
    VK_DYNAMIC_STATE_STENCIL_TEST_ENABLE_EXT = VK_DYNAMIC_STATE_STENCIL_TEST_ENABLE, 
    VK_DYNAMIC_STATE_STENCIL_OP_EXT = VK_DYNAMIC_STATE_STENCIL_OP, 
    VK_DYNAMIC_STATE_RASTERIZER_DISCARD_ENABLE_EXT = VK_DYNAMIC_STATE_RASTERIZER_DISCARD_ENABLE, 
    VK_DYNAMIC_STATE_DEPTH_BIAS_ENABLE_EXT = VK_DYNAMIC_STATE_DEPTH_BIAS_ENABLE, 
    VK_DYNAMIC_STATE_PRIMITIVE_RESTART_ENABLE_EXT = VK_DYNAMIC_STATE_PRIMITIVE_RESTART_ENABLE, 
    VK_DYNAMIC_STATE_LINE_STIPPLE_KHR = VK_DYNAMIC_STATE_LINE_STIPPLE, 
    VK_DYNAMIC_STATE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkFrontFace : uint   {
    VK_FRONT_FACE_COUNTER_CLOCKWISE = 0, 
    VK_FRONT_FACE_CLOCKWISE = 1, 
    VK_FRONT_FACE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkVertexInputRate : uint   {
    VK_VERTEX_INPUT_RATE_VERTEX = 0, 
    VK_VERTEX_INPUT_RATE_INSTANCE = 1, 
    VK_VERTEX_INPUT_RATE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkPrimitiveTopology : uint   {
    VK_PRIMITIVE_TOPOLOGY_POINT_LIST = 0, 
    VK_PRIMITIVE_TOPOLOGY_LINE_LIST = 1, 
    VK_PRIMITIVE_TOPOLOGY_LINE_STRIP = 2, 
    VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST = 3, 
    VK_PRIMITIVE_TOPOLOGY_TRIANGLE_STRIP = 4, 
    VK_PRIMITIVE_TOPOLOGY_TRIANGLE_FAN = 5, 
    VK_PRIMITIVE_TOPOLOGY_LINE_LIST_WITH_ADJACENCY = 6, 
    VK_PRIMITIVE_TOPOLOGY_LINE_STRIP_WITH_ADJACENCY = 7, 
    VK_PRIMITIVE_TOPOLOGY_TRIANGLE_LIST_WITH_ADJACENCY = 8, 
    VK_PRIMITIVE_TOPOLOGY_TRIANGLE_STRIP_WITH_ADJACENCY = 9, 
    VK_PRIMITIVE_TOPOLOGY_PATCH_LIST = 10, 
    VK_PRIMITIVE_TOPOLOGY_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkPolygonMode : uint   {
    VK_POLYGON_MODE_FILL = 0, 
    VK_POLYGON_MODE_LINE = 1, 
    VK_POLYGON_MODE_POINT = 2, 
    VK_POLYGON_MODE_FILL_RECTANGLE_NV = 1000153000, 
    VK_POLYGON_MODE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkStencilOp : uint   {
    VK_STENCIL_OP_KEEP = 0, 
    VK_STENCIL_OP_ZERO = 1, 
    VK_STENCIL_OP_REPLACE = 2, 
    VK_STENCIL_OP_INCREMENT_AND_CLAMP = 3, 
    VK_STENCIL_OP_DECREMENT_AND_CLAMP = 4, 
    VK_STENCIL_OP_INVERT = 5, 
    VK_STENCIL_OP_INCREMENT_AND_WRAP = 6, 
    VK_STENCIL_OP_DECREMENT_AND_WRAP = 7, 
    VK_STENCIL_OP_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkLogicOp : uint   {
    VK_LOGIC_OP_CLEAR = 0, 
    VK_LOGIC_OP_AND = 1, 
    VK_LOGIC_OP_AND_REVERSE = 2, 
    VK_LOGIC_OP_COPY = 3, 
    VK_LOGIC_OP_AND_INVERTED = 4, 
    VK_LOGIC_OP_NO_OP = 5, 
    VK_LOGIC_OP_XOR = 6, 
    VK_LOGIC_OP_OR = 7, 
    VK_LOGIC_OP_NOR = 8, 
    VK_LOGIC_OP_EQUIVALENT = 9, 
    VK_LOGIC_OP_INVERT = 10, 
    VK_LOGIC_OP_OR_REVERSE = 11, 
    VK_LOGIC_OP_COPY_INVERTED = 12, 
    VK_LOGIC_OP_OR_INVERTED = 13, 
    VK_LOGIC_OP_NAND = 14, 
    VK_LOGIC_OP_SET = 15, 
    VK_LOGIC_OP_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkBorderColor : uint   {
    VK_BORDER_COLOR_FLOAT_TRANSPARENT_BLACK = 0, 
    VK_BORDER_COLOR_INT_TRANSPARENT_BLACK = 1, 
    VK_BORDER_COLOR_FLOAT_OPAQUE_BLACK = 2, 
    VK_BORDER_COLOR_INT_OPAQUE_BLACK = 3, 
    VK_BORDER_COLOR_FLOAT_OPAQUE_WHITE = 4, 
    VK_BORDER_COLOR_INT_OPAQUE_WHITE = 5, 
    VK_BORDER_COLOR_FLOAT_CUSTOM_EXT = 1000287003, 
    VK_BORDER_COLOR_INT_CUSTOM_EXT = 1000287004, 
    VK_BORDER_COLOR_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkFilter : uint   {
    VK_FILTER_NEAREST = 0, 
    VK_FILTER_LINEAR = 1, 
    VK_FILTER_CUBIC_EXT = 1000015000, 
    VK_FILTER_CUBIC_IMG = VK_FILTER_CUBIC_EXT, 
    VK_FILTER_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkSamplerAddressMode : uint   {
    VK_SAMPLER_ADDRESS_MODE_REPEAT = 0, 
    VK_SAMPLER_ADDRESS_MODE_MIRRORED_REPEAT = 1, 
    VK_SAMPLER_ADDRESS_MODE_CLAMP_TO_EDGE = 2, 
    VK_SAMPLER_ADDRESS_MODE_CLAMP_TO_BORDER = 3, 
    VK_SAMPLER_ADDRESS_MODE_MIRROR_CLAMP_TO_EDGE = 4, 
  // VK_SAMPLER_ADDRESS_MODE_MIRROR_CLAMP_TO_EDGE_KHR is a deprecated alias 
    VK_SAMPLER_ADDRESS_MODE_MIRROR_CLAMP_TO_EDGE_KHR = VK_SAMPLER_ADDRESS_MODE_MIRROR_CLAMP_TO_EDGE, 
    VK_SAMPLER_ADDRESS_MODE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkSamplerMipmapMode : uint   {
    VK_SAMPLER_MIPMAP_MODE_NEAREST = 0, 
    VK_SAMPLER_MIPMAP_MODE_LINEAR = 1, 
    VK_SAMPLER_MIPMAP_MODE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkDescriptorType : uint   {
    VK_DESCRIPTOR_TYPE_SAMPLER = 0, 
    VK_DESCRIPTOR_TYPE_COMBINED_IMAGE_SAMPLER = 1, 
    VK_DESCRIPTOR_TYPE_SAMPLED_IMAGE = 2, 
    VK_DESCRIPTOR_TYPE_STORAGE_IMAGE = 3, 
    VK_DESCRIPTOR_TYPE_UNIFORM_TEXEL_BUFFER = 4, 
    VK_DESCRIPTOR_TYPE_STORAGE_TEXEL_BUFFER = 5, 
    VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER = 6, 
    VK_DESCRIPTOR_TYPE_STORAGE_BUFFER = 7, 
    VK_DESCRIPTOR_TYPE_UNIFORM_BUFFER_DYNAMIC = 8, 
    VK_DESCRIPTOR_TYPE_STORAGE_BUFFER_DYNAMIC = 9, 
    VK_DESCRIPTOR_TYPE_INPUT_ATTACHMENT = 10, 
    VK_DESCRIPTOR_TYPE_INLINE_UNIFORM_BLOCK = 1000138000, 
    VK_DESCRIPTOR_TYPE_ACCELERATION_STRUCTURE_KHR = 1000150000, 
    VK_DESCRIPTOR_TYPE_ACCELERATION_STRUCTURE_NV = 1000165000, 
    VK_DESCRIPTOR_TYPE_SAMPLE_WEIGHT_IMAGE_QCOM = 1000440000, 
    VK_DESCRIPTOR_TYPE_BLOCK_MATCH_IMAGE_QCOM = 1000440001, 
    VK_DESCRIPTOR_TYPE_MUTABLE_EXT = 1000351000, 
    VK_DESCRIPTOR_TYPE_PARTITIONED_ACCELERATION_STRUCTURE_NV = 1000570000, 
    VK_DESCRIPTOR_TYPE_INLINE_UNIFORM_BLOCK_EXT = VK_DESCRIPTOR_TYPE_INLINE_UNIFORM_BLOCK, 
    VK_DESCRIPTOR_TYPE_MUTABLE_VALVE = VK_DESCRIPTOR_TYPE_MUTABLE_EXT, 
    VK_DESCRIPTOR_TYPE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkAttachmentLoadOp : uint   {
    VK_ATTACHMENT_LOAD_OP_LOAD = 0, 
    VK_ATTACHMENT_LOAD_OP_CLEAR = 1, 
    VK_ATTACHMENT_LOAD_OP_DONT_CARE = 2, 
    VK_ATTACHMENT_LOAD_OP_NONE = 1000400000, 
    VK_ATTACHMENT_LOAD_OP_NONE_EXT = VK_ATTACHMENT_LOAD_OP_NONE, 
    VK_ATTACHMENT_LOAD_OP_NONE_KHR = VK_ATTACHMENT_LOAD_OP_NONE, 
    VK_ATTACHMENT_LOAD_OP_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkAttachmentStoreOp : uint   {
    VK_ATTACHMENT_STORE_OP_STORE = 0, 
    VK_ATTACHMENT_STORE_OP_DONT_CARE = 1, 
    VK_ATTACHMENT_STORE_OP_NONE = 1000301000, 
    VK_ATTACHMENT_STORE_OP_NONE_KHR = VK_ATTACHMENT_STORE_OP_NONE, 
    VK_ATTACHMENT_STORE_OP_NONE_QCOM = VK_ATTACHMENT_STORE_OP_NONE, 
    VK_ATTACHMENT_STORE_OP_NONE_EXT = VK_ATTACHMENT_STORE_OP_NONE, 
    VK_ATTACHMENT_STORE_OP_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkPipelineBindPoint : uint   {
    VK_PIPELINE_BIND_POINT_GRAPHICS = 0, 
    VK_PIPELINE_BIND_POINT_COMPUTE = 1, 
    VK_PIPELINE_BIND_POINT_EXECUTION_GRAPH_AMDX = 1000134000, 
    VK_PIPELINE_BIND_POINT_RAY_TRACING_KHR = 1000165000, 
    VK_PIPELINE_BIND_POINT_SUBPASS_SHADING_HUAWEI = 1000369003, 
    VK_PIPELINE_BIND_POINT_RAY_TRACING_NV = VK_PIPELINE_BIND_POINT_RAY_TRACING_KHR, 
    VK_PIPELINE_BIND_POINT_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkCommandBufferLevel : uint   {
    VK_COMMAND_BUFFER_LEVEL_PRIMARY = 0, 
    VK_COMMAND_BUFFER_LEVEL_SECONDARY = 1, 
    VK_COMMAND_BUFFER_LEVEL_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkIndexType : uint   {
    VK_INDEX_TYPE_UINT16 = 0, 
    VK_INDEX_TYPE_UINT32 = 1, 
    VK_INDEX_TYPE_UINT8 = 1000265000, 
    VK_INDEX_TYPE_NONE_KHR = 1000165000, 
    VK_INDEX_TYPE_NONE_NV = VK_INDEX_TYPE_NONE_KHR, 
    VK_INDEX_TYPE_UINT8_EXT = VK_INDEX_TYPE_UINT8, 
    VK_INDEX_TYPE_UINT8_KHR = VK_INDEX_TYPE_UINT8, 
    VK_INDEX_TYPE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkSubpassContents : uint   {
    VK_SUBPASS_CONTENTS_INLINE = 0, 
    VK_SUBPASS_CONTENTS_SECONDARY_COMMAND_BUFFERS = 1, 
    VK_SUBPASS_CONTENTS_INLINE_AND_SECONDARY_COMMAND_BUFFERS_KHR = 1000451000, 
    VK_SUBPASS_CONTENTS_INLINE_AND_SECONDARY_COMMAND_BUFFERS_EXT = VK_SUBPASS_CONTENTS_INLINE_AND_SECONDARY_COMMAND_BUFFERS_KHR, 
    VK_SUBPASS_CONTENTS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkAccessFlagBits : uint   {
    VK_ACCESS_INDIRECT_COMMAND_READ_BIT = 0x00000001, 
    VK_ACCESS_INDEX_READ_BIT = 0x00000002, 
    VK_ACCESS_VERTEX_ATTRIBUTE_READ_BIT = 0x00000004, 
    VK_ACCESS_UNIFORM_READ_BIT = 0x00000008, 
    VK_ACCESS_INPUT_ATTACHMENT_READ_BIT = 0x00000010, 
    VK_ACCESS_SHADER_READ_BIT = 0x00000020, 
    VK_ACCESS_SHADER_WRITE_BIT = 0x00000040, 
    VK_ACCESS_COLOR_ATTACHMENT_READ_BIT = 0x00000080, 
    VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT = 0x00000100, 
    VK_ACCESS_DEPTH_STENCIL_ATTACHMENT_READ_BIT = 0x00000200, 
    VK_ACCESS_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT = 0x00000400, 
    VK_ACCESS_TRANSFER_READ_BIT = 0x00000800, 
    VK_ACCESS_TRANSFER_WRITE_BIT = 0x00001000, 
    VK_ACCESS_HOST_READ_BIT = 0x00002000, 
    VK_ACCESS_HOST_WRITE_BIT = 0x00004000, 
    VK_ACCESS_MEMORY_READ_BIT = 0x00008000, 
    VK_ACCESS_MEMORY_WRITE_BIT = 0x00010000, 
    VK_ACCESS_NONE = 0, 
    VK_ACCESS_TRANSFORM_FEEDBACK_WRITE_BIT_EXT = 0x02000000, 
    VK_ACCESS_TRANSFORM_FEEDBACK_COUNTER_READ_BIT_EXT = 0x04000000, 
    VK_ACCESS_TRANSFORM_FEEDBACK_COUNTER_WRITE_BIT_EXT = 0x08000000, 
    VK_ACCESS_CONDITIONAL_RENDERING_READ_BIT_EXT = 0x00100000, 
    VK_ACCESS_COLOR_ATTACHMENT_READ_NONCOHERENT_BIT_EXT = 0x00080000, 
    VK_ACCESS_ACCELERATION_STRUCTURE_READ_BIT_KHR = 0x00200000, 
    VK_ACCESS_ACCELERATION_STRUCTURE_WRITE_BIT_KHR = 0x00400000, 
    VK_ACCESS_FRAGMENT_DENSITY_MAP_READ_BIT_EXT = 0x01000000, 
    VK_ACCESS_FRAGMENT_SHADING_RATE_ATTACHMENT_READ_BIT_KHR = 0x00800000, 
    VK_ACCESS_COMMAND_PREPROCESS_READ_BIT_EXT = 0x00020000, 
    VK_ACCESS_COMMAND_PREPROCESS_WRITE_BIT_EXT = 0x00040000, 
    VK_ACCESS_SHADING_RATE_IMAGE_READ_BIT_NV = VK_ACCESS_FRAGMENT_SHADING_RATE_ATTACHMENT_READ_BIT_KHR, 
    VK_ACCESS_ACCELERATION_STRUCTURE_READ_BIT_NV = VK_ACCESS_ACCELERATION_STRUCTURE_READ_BIT_KHR, 
    VK_ACCESS_ACCELERATION_STRUCTURE_WRITE_BIT_NV = VK_ACCESS_ACCELERATION_STRUCTURE_WRITE_BIT_KHR, 
    VK_ACCESS_COMMAND_PREPROCESS_READ_BIT_NV = VK_ACCESS_COMMAND_PREPROCESS_READ_BIT_EXT, 
    VK_ACCESS_COMMAND_PREPROCESS_WRITE_BIT_NV = VK_ACCESS_COMMAND_PREPROCESS_WRITE_BIT_EXT, 
    VK_ACCESS_NONE_KHR = VK_ACCESS_NONE, 
    VK_ACCESS_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkImageAspectFlagBits : uint   {
    VK_IMAGE_ASPECT_COLOR_BIT = 0x00000001, 
    VK_IMAGE_ASPECT_DEPTH_BIT = 0x00000002, 
    VK_IMAGE_ASPECT_STENCIL_BIT = 0x00000004, 
    VK_IMAGE_ASPECT_METADATA_BIT = 0x00000008, 
    VK_IMAGE_ASPECT_PLANE_0_BIT = 0x00000010, 
    VK_IMAGE_ASPECT_PLANE_1_BIT = 0x00000020, 
    VK_IMAGE_ASPECT_PLANE_2_BIT = 0x00000040, 
    VK_IMAGE_ASPECT_NONE = 0, 
    VK_IMAGE_ASPECT_MEMORY_PLANE_0_BIT_EXT = 0x00000080, 
    VK_IMAGE_ASPECT_MEMORY_PLANE_1_BIT_EXT = 0x00000100, 
    VK_IMAGE_ASPECT_MEMORY_PLANE_2_BIT_EXT = 0x00000200, 
    VK_IMAGE_ASPECT_MEMORY_PLANE_3_BIT_EXT = 0x00000400, 
    VK_IMAGE_ASPECT_PLANE_0_BIT_KHR = VK_IMAGE_ASPECT_PLANE_0_BIT, 
    VK_IMAGE_ASPECT_PLANE_1_BIT_KHR = VK_IMAGE_ASPECT_PLANE_1_BIT, 
    VK_IMAGE_ASPECT_PLANE_2_BIT_KHR = VK_IMAGE_ASPECT_PLANE_2_BIT, 
    VK_IMAGE_ASPECT_NONE_KHR = VK_IMAGE_ASPECT_NONE, 
    VK_IMAGE_ASPECT_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkFormatFeatureFlagBits : uint   {
    VK_FORMAT_FEATURE_SAMPLED_IMAGE_BIT = 0x00000001, 
    VK_FORMAT_FEATURE_STORAGE_IMAGE_BIT = 0x00000002, 
    VK_FORMAT_FEATURE_STORAGE_IMAGE_ATOMIC_BIT = 0x00000004, 
    VK_FORMAT_FEATURE_UNIFORM_TEXEL_BUFFER_BIT = 0x00000008, 
    VK_FORMAT_FEATURE_STORAGE_TEXEL_BUFFER_BIT = 0x00000010, 
    VK_FORMAT_FEATURE_STORAGE_TEXEL_BUFFER_ATOMIC_BIT = 0x00000020, 
    VK_FORMAT_FEATURE_VERTEX_BUFFER_BIT = 0x00000040, 
    VK_FORMAT_FEATURE_COLOR_ATTACHMENT_BIT = 0x00000080, 
    VK_FORMAT_FEATURE_COLOR_ATTACHMENT_BLEND_BIT = 0x00000100, 
    VK_FORMAT_FEATURE_DEPTH_STENCIL_ATTACHMENT_BIT = 0x00000200, 
    VK_FORMAT_FEATURE_BLIT_SRC_BIT = 0x00000400, 
    VK_FORMAT_FEATURE_BLIT_DST_BIT = 0x00000800, 
    VK_FORMAT_FEATURE_SAMPLED_IMAGE_FILTER_LINEAR_BIT = 0x00001000, 
    VK_FORMAT_FEATURE_TRANSFER_SRC_BIT = 0x00004000, 
    VK_FORMAT_FEATURE_TRANSFER_DST_BIT = 0x00008000, 
    VK_FORMAT_FEATURE_MIDPOINT_CHROMA_SAMPLES_BIT = 0x00020000, 
    VK_FORMAT_FEATURE_SAMPLED_IMAGE_YCBCR_CONVERSION_LINEAR_FILTER_BIT = 0x00040000, 
    VK_FORMAT_FEATURE_SAMPLED_IMAGE_YCBCR_CONVERSION_SEPARATE_RECONSTRUCTION_FILTER_BIT = 0x00080000, 
    VK_FORMAT_FEATURE_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_BIT = 0x00100000, 
    VK_FORMAT_FEATURE_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_FORCEABLE_BIT = 0x00200000, 
    VK_FORMAT_FEATURE_DISJOINT_BIT = 0x00400000, 
    VK_FORMAT_FEATURE_COSITED_CHROMA_SAMPLES_BIT = 0x00800000, 
    VK_FORMAT_FEATURE_SAMPLED_IMAGE_FILTER_MINMAX_BIT = 0x00010000, 
    VK_FORMAT_FEATURE_VIDEO_DECODE_OUTPUT_BIT_KHR = 0x02000000, 
    VK_FORMAT_FEATURE_VIDEO_DECODE_DPB_BIT_KHR = 0x04000000, 
    VK_FORMAT_FEATURE_ACCELERATION_STRUCTURE_VERTEX_BUFFER_BIT_KHR = 0x20000000, 
    VK_FORMAT_FEATURE_SAMPLED_IMAGE_FILTER_CUBIC_BIT_EXT = 0x00002000, 
    VK_FORMAT_FEATURE_FRAGMENT_DENSITY_MAP_BIT_EXT = 0x01000000, 
    VK_FORMAT_FEATURE_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR = 0x40000000, 
    VK_FORMAT_FEATURE_VIDEO_ENCODE_INPUT_BIT_KHR = 0x08000000, 
    VK_FORMAT_FEATURE_VIDEO_ENCODE_DPB_BIT_KHR = 0x10000000, 
    VK_FORMAT_FEATURE_SAMPLED_IMAGE_FILTER_CUBIC_BIT_IMG = VK_FORMAT_FEATURE_SAMPLED_IMAGE_FILTER_CUBIC_BIT_EXT, 
    VK_FORMAT_FEATURE_TRANSFER_SRC_BIT_KHR = VK_FORMAT_FEATURE_TRANSFER_SRC_BIT, 
    VK_FORMAT_FEATURE_TRANSFER_DST_BIT_KHR = VK_FORMAT_FEATURE_TRANSFER_DST_BIT, 
    VK_FORMAT_FEATURE_SAMPLED_IMAGE_FILTER_MINMAX_BIT_EXT = VK_FORMAT_FEATURE_SAMPLED_IMAGE_FILTER_MINMAX_BIT, 
    VK_FORMAT_FEATURE_MIDPOINT_CHROMA_SAMPLES_BIT_KHR = VK_FORMAT_FEATURE_MIDPOINT_CHROMA_SAMPLES_BIT, 
    VK_FORMAT_FEATURE_SAMPLED_IMAGE_YCBCR_CONVERSION_LINEAR_FILTER_BIT_KHR = VK_FORMAT_FEATURE_SAMPLED_IMAGE_YCBCR_CONVERSION_LINEAR_FILTER_BIT, 
    VK_FORMAT_FEATURE_SAMPLED_IMAGE_YCBCR_CONVERSION_SEPARATE_RECONSTRUCTION_FILTER_BIT_KHR = VK_FORMAT_FEATURE_SAMPLED_IMAGE_YCBCR_CONVERSION_SEPARATE_RECONSTRUCTION_FILTER_BIT, 
    VK_FORMAT_FEATURE_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_BIT_KHR = VK_FORMAT_FEATURE_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_BIT, 
    VK_FORMAT_FEATURE_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_FORCEABLE_BIT_KHR = VK_FORMAT_FEATURE_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_FORCEABLE_BIT, 
    VK_FORMAT_FEATURE_DISJOINT_BIT_KHR = VK_FORMAT_FEATURE_DISJOINT_BIT, 
    VK_FORMAT_FEATURE_COSITED_CHROMA_SAMPLES_BIT_KHR = VK_FORMAT_FEATURE_COSITED_CHROMA_SAMPLES_BIT, 
    VK_FORMAT_FEATURE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkImageCreateFlagBits : uint   {
    VK_IMAGE_CREATE_SPARSE_BINDING_BIT = 0x00000001, 
    VK_IMAGE_CREATE_SPARSE_RESIDENCY_BIT = 0x00000002, 
    VK_IMAGE_CREATE_SPARSE_ALIASED_BIT = 0x00000004, 
    VK_IMAGE_CREATE_MUTABLE_FORMAT_BIT = 0x00000008, 
    VK_IMAGE_CREATE_CUBE_COMPATIBLE_BIT = 0x00000010, 
    VK_IMAGE_CREATE_ALIAS_BIT = 0x00000400, 
    VK_IMAGE_CREATE_SPLIT_INSTANCE_BIND_REGIONS_BIT = 0x00000040, 
    VK_IMAGE_CREATE_2D_ARRAY_COMPATIBLE_BIT = 0x00000020, 
    VK_IMAGE_CREATE_BLOCK_TEXEL_VIEW_COMPATIBLE_BIT = 0x00000080, 
    VK_IMAGE_CREATE_EXTENDED_USAGE_BIT = 0x00000100, 
    VK_IMAGE_CREATE_PROTECTED_BIT = 0x00000800, 
    VK_IMAGE_CREATE_DISJOINT_BIT = 0x00000200, 
    VK_IMAGE_CREATE_CORNER_SAMPLED_BIT_NV = 0x00002000, 
    VK_IMAGE_CREATE_SAMPLE_LOCATIONS_COMPATIBLE_DEPTH_BIT_EXT = 0x00001000, 
    VK_IMAGE_CREATE_SUBSAMPLED_BIT_EXT = 0x00004000, 
    VK_IMAGE_CREATE_DESCRIPTOR_BUFFER_CAPTURE_REPLAY_BIT_EXT = 0x00010000, 
    VK_IMAGE_CREATE_MULTISAMPLED_RENDER_TO_SINGLE_SAMPLED_BIT_EXT = 0x00040000, 
    VK_IMAGE_CREATE_2D_VIEW_COMPATIBLE_BIT_EXT = 0x00020000, 
    VK_IMAGE_CREATE_VIDEO_PROFILE_INDEPENDENT_BIT_KHR = 0x00100000, 
    VK_IMAGE_CREATE_FRAGMENT_DENSITY_MAP_OFFSET_BIT_EXT = 0x00008000, 
    VK_IMAGE_CREATE_SPLIT_INSTANCE_BIND_REGIONS_BIT_KHR = VK_IMAGE_CREATE_SPLIT_INSTANCE_BIND_REGIONS_BIT, 
    VK_IMAGE_CREATE_2D_ARRAY_COMPATIBLE_BIT_KHR = VK_IMAGE_CREATE_2D_ARRAY_COMPATIBLE_BIT, 
    VK_IMAGE_CREATE_BLOCK_TEXEL_VIEW_COMPATIBLE_BIT_KHR = VK_IMAGE_CREATE_BLOCK_TEXEL_VIEW_COMPATIBLE_BIT, 
    VK_IMAGE_CREATE_EXTENDED_USAGE_BIT_KHR = VK_IMAGE_CREATE_EXTENDED_USAGE_BIT, 
    VK_IMAGE_CREATE_DISJOINT_BIT_KHR = VK_IMAGE_CREATE_DISJOINT_BIT, 
    VK_IMAGE_CREATE_ALIAS_BIT_KHR = VK_IMAGE_CREATE_ALIAS_BIT, 
    VK_IMAGE_CREATE_FRAGMENT_DENSITY_MAP_OFFSET_BIT_QCOM = VK_IMAGE_CREATE_FRAGMENT_DENSITY_MAP_OFFSET_BIT_EXT, 
    VK_IMAGE_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkSampleCountFlagBits : uint   {
    VK_SAMPLE_COUNT_1_BIT = 0x00000001, 
    VK_SAMPLE_COUNT_2_BIT = 0x00000002, 
    VK_SAMPLE_COUNT_4_BIT = 0x00000004, 
    VK_SAMPLE_COUNT_8_BIT = 0x00000008, 
    VK_SAMPLE_COUNT_16_BIT = 0x00000010, 
    VK_SAMPLE_COUNT_32_BIT = 0x00000020, 
    VK_SAMPLE_COUNT_64_BIT = 0x00000040, 
    VK_SAMPLE_COUNT_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkImageUsageFlagBits : uint   {
    VK_IMAGE_USAGE_TRANSFER_SRC_BIT = 0x00000001, 
    VK_IMAGE_USAGE_TRANSFER_DST_BIT = 0x00000002, 
    VK_IMAGE_USAGE_SAMPLED_BIT = 0x00000004, 
    VK_IMAGE_USAGE_STORAGE_BIT = 0x00000008, 
    VK_IMAGE_USAGE_COLOR_ATTACHMENT_BIT = 0x00000010, 
    VK_IMAGE_USAGE_DEPTH_STENCIL_ATTACHMENT_BIT = 0x00000020, 
    VK_IMAGE_USAGE_TRANSIENT_ATTACHMENT_BIT = 0x00000040, 
    VK_IMAGE_USAGE_INPUT_ATTACHMENT_BIT = 0x00000080, 
    VK_IMAGE_USAGE_HOST_TRANSFER_BIT = 0x00400000, 
    VK_IMAGE_USAGE_VIDEO_DECODE_DST_BIT_KHR = 0x00000400, 
    VK_IMAGE_USAGE_VIDEO_DECODE_SRC_BIT_KHR = 0x00000800, 
    VK_IMAGE_USAGE_VIDEO_DECODE_DPB_BIT_KHR = 0x00001000, 
    VK_IMAGE_USAGE_FRAGMENT_DENSITY_MAP_BIT_EXT = 0x00000200, 
    VK_IMAGE_USAGE_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR = 0x00000100, 
    VK_IMAGE_USAGE_VIDEO_ENCODE_DST_BIT_KHR = 0x00002000, 
    VK_IMAGE_USAGE_VIDEO_ENCODE_SRC_BIT_KHR = 0x00004000, 
    VK_IMAGE_USAGE_VIDEO_ENCODE_DPB_BIT_KHR = 0x00008000, 
    VK_IMAGE_USAGE_ATTACHMENT_FEEDBACK_LOOP_BIT_EXT = 0x00080000, 
    VK_IMAGE_USAGE_INVOCATION_MASK_BIT_HUAWEI = 0x00040000, 
    VK_IMAGE_USAGE_SAMPLE_WEIGHT_BIT_QCOM = 0x00100000, 
    VK_IMAGE_USAGE_SAMPLE_BLOCK_MATCH_BIT_QCOM = 0x00200000, 
    VK_IMAGE_USAGE_TILE_MEMORY_BIT_QCOM = 0x08000000, 
    VK_IMAGE_USAGE_VIDEO_ENCODE_QUANTIZATION_DELTA_MAP_BIT_KHR = 0x02000000, 
    VK_IMAGE_USAGE_VIDEO_ENCODE_EMPHASIS_MAP_BIT_KHR = 0x04000000, 
    VK_IMAGE_USAGE_SHADING_RATE_IMAGE_BIT_NV = VK_IMAGE_USAGE_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR, 
    VK_IMAGE_USAGE_HOST_TRANSFER_BIT_EXT = VK_IMAGE_USAGE_HOST_TRANSFER_BIT, 
    VK_IMAGE_USAGE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkInstanceCreateFlagBits : uint   {
    VK_INSTANCE_CREATE_ENUMERATE_PORTABILITY_BIT_KHR = 0x00000001, 
    VK_INSTANCE_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkMemoryHeapFlagBits : uint   {
    VK_MEMORY_HEAP_DEVICE_LOCAL_BIT = 0x00000001, 
    VK_MEMORY_HEAP_MULTI_INSTANCE_BIT = 0x00000002, 
    VK_MEMORY_HEAP_TILE_MEMORY_BIT_QCOM = 0x00000008, 
    VK_MEMORY_HEAP_MULTI_INSTANCE_BIT_KHR = VK_MEMORY_HEAP_MULTI_INSTANCE_BIT, 
    VK_MEMORY_HEAP_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkMemoryPropertyFlagBits : uint   {
    VK_MEMORY_PROPERTY_DEVICE_LOCAL_BIT = 0x00000001, 
    VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT = 0x00000002, 
    VK_MEMORY_PROPERTY_HOST_COHERENT_BIT = 0x00000004, 
    VK_MEMORY_PROPERTY_HOST_CACHED_BIT = 0x00000008, 
    VK_MEMORY_PROPERTY_LAZILY_ALLOCATED_BIT = 0x00000010, 
    VK_MEMORY_PROPERTY_PROTECTED_BIT = 0x00000020, 
    VK_MEMORY_PROPERTY_DEVICE_COHERENT_BIT_AMD = 0x00000040, 
    VK_MEMORY_PROPERTY_DEVICE_UNCACHED_BIT_AMD = 0x00000080, 
    VK_MEMORY_PROPERTY_RDMA_CAPABLE_BIT_NV = 0x00000100, 
    VK_MEMORY_PROPERTY_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkQueueFlagBits : uint   {
    VK_QUEUE_GRAPHICS_BIT = 0x00000001, 
    VK_QUEUE_COMPUTE_BIT = 0x00000002, 
    VK_QUEUE_TRANSFER_BIT = 0x00000004, 
    VK_QUEUE_SPARSE_BINDING_BIT = 0x00000008, 
    VK_QUEUE_PROTECTED_BIT = 0x00000010, 
    VK_QUEUE_VIDEO_DECODE_BIT_KHR = 0x00000020, 
    VK_QUEUE_VIDEO_ENCODE_BIT_KHR = 0x00000040, 
    VK_QUEUE_OPTICAL_FLOW_BIT_NV = 0x00000100, 
    VK_QUEUE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkDeviceQueueCreateFlagBits : uint   {
    VK_DEVICE_QUEUE_CREATE_PROTECTED_BIT = 0x00000001, 
    VK_DEVICE_QUEUE_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkPipelineStageFlagBits : uint   {
    VK_PIPELINE_STAGE_TOP_OF_PIPE_BIT = 0x00000001, 
    VK_PIPELINE_STAGE_DRAW_INDIRECT_BIT = 0x00000002, 
    VK_PIPELINE_STAGE_VERTEX_INPUT_BIT = 0x00000004, 
    VK_PIPELINE_STAGE_VERTEX_SHADER_BIT = 0x00000008, 
    VK_PIPELINE_STAGE_TESSELLATION_CONTROL_SHADER_BIT = 0x00000010, 
    VK_PIPELINE_STAGE_TESSELLATION_EVALUATION_SHADER_BIT = 0x00000020, 
    VK_PIPELINE_STAGE_GEOMETRY_SHADER_BIT = 0x00000040, 
    VK_PIPELINE_STAGE_FRAGMENT_SHADER_BIT = 0x00000080, 
    VK_PIPELINE_STAGE_EARLY_FRAGMENT_TESTS_BIT = 0x00000100, 
    VK_PIPELINE_STAGE_LATE_FRAGMENT_TESTS_BIT = 0x00000200, 
    VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT = 0x00000400, 
    VK_PIPELINE_STAGE_COMPUTE_SHADER_BIT = 0x00000800, 
    VK_PIPELINE_STAGE_TRANSFER_BIT = 0x00001000, 
    VK_PIPELINE_STAGE_BOTTOM_OF_PIPE_BIT = 0x00002000, 
    VK_PIPELINE_STAGE_HOST_BIT = 0x00004000, 
    VK_PIPELINE_STAGE_ALL_GRAPHICS_BIT = 0x00008000, 
    VK_PIPELINE_STAGE_ALL_COMMANDS_BIT = 0x00010000, 
    VK_PIPELINE_STAGE_NONE = 0, 
    VK_PIPELINE_STAGE_TRANSFORM_FEEDBACK_BIT_EXT = 0x01000000, 
    VK_PIPELINE_STAGE_CONDITIONAL_RENDERING_BIT_EXT = 0x00040000, 
    VK_PIPELINE_STAGE_ACCELERATION_STRUCTURE_BUILD_BIT_KHR = 0x02000000, 
    VK_PIPELINE_STAGE_RAY_TRACING_SHADER_BIT_KHR = 0x00200000, 
    VK_PIPELINE_STAGE_FRAGMENT_DENSITY_PROCESS_BIT_EXT = 0x00800000, 
    VK_PIPELINE_STAGE_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR = 0x00400000, 
    VK_PIPELINE_STAGE_TASK_SHADER_BIT_EXT = 0x00080000, 
    VK_PIPELINE_STAGE_MESH_SHADER_BIT_EXT = 0x00100000, 
    VK_PIPELINE_STAGE_COMMAND_PREPROCESS_BIT_EXT = 0x00020000, 
    VK_PIPELINE_STAGE_SHADING_RATE_IMAGE_BIT_NV = VK_PIPELINE_STAGE_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR, 
    VK_PIPELINE_STAGE_RAY_TRACING_SHADER_BIT_NV = VK_PIPELINE_STAGE_RAY_TRACING_SHADER_BIT_KHR, 
    VK_PIPELINE_STAGE_ACCELERATION_STRUCTURE_BUILD_BIT_NV = VK_PIPELINE_STAGE_ACCELERATION_STRUCTURE_BUILD_BIT_KHR, 
    VK_PIPELINE_STAGE_TASK_SHADER_BIT_NV = VK_PIPELINE_STAGE_TASK_SHADER_BIT_EXT, 
    VK_PIPELINE_STAGE_MESH_SHADER_BIT_NV = VK_PIPELINE_STAGE_MESH_SHADER_BIT_EXT, 
    VK_PIPELINE_STAGE_COMMAND_PREPROCESS_BIT_NV = VK_PIPELINE_STAGE_COMMAND_PREPROCESS_BIT_EXT, 
    VK_PIPELINE_STAGE_NONE_KHR = VK_PIPELINE_STAGE_NONE, 
    VK_PIPELINE_STAGE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkMemoryMapFlagBits : uint   {
    VK_MEMORY_MAP_PLACED_BIT_EXT = 0x00000001, 
    VK_MEMORY_MAP_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkSparseMemoryBindFlagBits : uint   {
    VK_SPARSE_MEMORY_BIND_METADATA_BIT = 0x00000001, 
    VK_SPARSE_MEMORY_BIND_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkSparseImageFormatFlagBits : uint   {
    VK_SPARSE_IMAGE_FORMAT_SINGLE_MIPTAIL_BIT = 0x00000001, 
    VK_SPARSE_IMAGE_FORMAT_ALIGNED_MIP_SIZE_BIT = 0x00000002, 
    VK_SPARSE_IMAGE_FORMAT_NONSTANDARD_BLOCK_SIZE_BIT = 0x00000004, 
    VK_SPARSE_IMAGE_FORMAT_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkFenceCreateFlagBits : uint   {
    VK_FENCE_CREATE_SIGNALED_BIT = 0x00000001, 
    VK_FENCE_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkEventCreateFlagBits : uint   {
    VK_EVENT_CREATE_DEVICE_ONLY_BIT = 0x00000001, 
    VK_EVENT_CREATE_DEVICE_ONLY_BIT_KHR = VK_EVENT_CREATE_DEVICE_ONLY_BIT, 
    VK_EVENT_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkQueryPipelineStatisticFlagBits : uint   {
    VK_QUERY_PIPELINE_STATISTIC_INPUT_ASSEMBLY_VERTICES_BIT = 0x00000001, 
    VK_QUERY_PIPELINE_STATISTIC_INPUT_ASSEMBLY_PRIMITIVES_BIT = 0x00000002, 
    VK_QUERY_PIPELINE_STATISTIC_VERTEX_SHADER_INVOCATIONS_BIT = 0x00000004, 
    VK_QUERY_PIPELINE_STATISTIC_GEOMETRY_SHADER_INVOCATIONS_BIT = 0x00000008, 
    VK_QUERY_PIPELINE_STATISTIC_GEOMETRY_SHADER_PRIMITIVES_BIT = 0x00000010, 
    VK_QUERY_PIPELINE_STATISTIC_CLIPPING_INVOCATIONS_BIT = 0x00000020, 
    VK_QUERY_PIPELINE_STATISTIC_CLIPPING_PRIMITIVES_BIT = 0x00000040, 
    VK_QUERY_PIPELINE_STATISTIC_FRAGMENT_SHADER_INVOCATIONS_BIT = 0x00000080, 
    VK_QUERY_PIPELINE_STATISTIC_TESSELLATION_CONTROL_SHADER_PATCHES_BIT = 0x00000100, 
    VK_QUERY_PIPELINE_STATISTIC_TESSELLATION_EVALUATION_SHADER_INVOCATIONS_BIT = 0x00000200, 
    VK_QUERY_PIPELINE_STATISTIC_COMPUTE_SHADER_INVOCATIONS_BIT = 0x00000400, 
    VK_QUERY_PIPELINE_STATISTIC_TASK_SHADER_INVOCATIONS_BIT_EXT = 0x00000800, 
    VK_QUERY_PIPELINE_STATISTIC_MESH_SHADER_INVOCATIONS_BIT_EXT = 0x00001000, 
    VK_QUERY_PIPELINE_STATISTIC_CLUSTER_CULLING_SHADER_INVOCATIONS_BIT_HUAWEI = 0x00002000, 
    VK_QUERY_PIPELINE_STATISTIC_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkQueryResultFlagBits : uint   {
    VK_QUERY_RESULT_64_BIT = 0x00000001, 
    VK_QUERY_RESULT_WAIT_BIT = 0x00000002, 
    VK_QUERY_RESULT_WITH_AVAILABILITY_BIT = 0x00000004, 
    VK_QUERY_RESULT_PARTIAL_BIT = 0x00000008, 
    VK_QUERY_RESULT_WITH_STATUS_BIT_KHR = 0x00000010, 
    VK_QUERY_RESULT_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkBufferCreateFlagBits : uint   {
    VK_BUFFER_CREATE_SPARSE_BINDING_BIT = 0x00000001, 
    VK_BUFFER_CREATE_SPARSE_RESIDENCY_BIT = 0x00000002, 
    VK_BUFFER_CREATE_SPARSE_ALIASED_BIT = 0x00000004, 
    VK_BUFFER_CREATE_PROTECTED_BIT = 0x00000008, 
    VK_BUFFER_CREATE_DEVICE_ADDRESS_CAPTURE_REPLAY_BIT = 0x00000010, 
    VK_BUFFER_CREATE_DESCRIPTOR_BUFFER_CAPTURE_REPLAY_BIT_EXT = 0x00000020, 
    VK_BUFFER_CREATE_VIDEO_PROFILE_INDEPENDENT_BIT_KHR = 0x00000040, 
    VK_BUFFER_CREATE_DEVICE_ADDRESS_CAPTURE_REPLAY_BIT_EXT = VK_BUFFER_CREATE_DEVICE_ADDRESS_CAPTURE_REPLAY_BIT, 
    VK_BUFFER_CREATE_DEVICE_ADDRESS_CAPTURE_REPLAY_BIT_KHR = VK_BUFFER_CREATE_DEVICE_ADDRESS_CAPTURE_REPLAY_BIT, 
    VK_BUFFER_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkBufferUsageFlagBits : uint   {
    VK_BUFFER_USAGE_TRANSFER_SRC_BIT = 0x00000001, 
    VK_BUFFER_USAGE_TRANSFER_DST_BIT = 0x00000002, 
    VK_BUFFER_USAGE_UNIFORM_TEXEL_BUFFER_BIT = 0x00000004, 
    VK_BUFFER_USAGE_STORAGE_TEXEL_BUFFER_BIT = 0x00000008, 
    VK_BUFFER_USAGE_UNIFORM_BUFFER_BIT = 0x00000010, 
    VK_BUFFER_USAGE_STORAGE_BUFFER_BIT = 0x00000020, 
    VK_BUFFER_USAGE_INDEX_BUFFER_BIT = 0x00000040, 
    VK_BUFFER_USAGE_VERTEX_BUFFER_BIT = 0x00000080, 
    VK_BUFFER_USAGE_INDIRECT_BUFFER_BIT = 0x00000100, 
    VK_BUFFER_USAGE_SHADER_DEVICE_ADDRESS_BIT = 0x00020000, 
    VK_BUFFER_USAGE_VIDEO_DECODE_SRC_BIT_KHR = 0x00002000, 
    VK_BUFFER_USAGE_VIDEO_DECODE_DST_BIT_KHR = 0x00004000, 
    VK_BUFFER_USAGE_TRANSFORM_FEEDBACK_BUFFER_BIT_EXT = 0x00000800, 
    VK_BUFFER_USAGE_TRANSFORM_FEEDBACK_COUNTER_BUFFER_BIT_EXT = 0x00001000, 
    VK_BUFFER_USAGE_CONDITIONAL_RENDERING_BIT_EXT = 0x00000200, 
    VK_BUFFER_USAGE_EXECUTION_GRAPH_SCRATCH_BIT_AMDX = 0x02000000, 
    VK_BUFFER_USAGE_ACCELERATION_STRUCTURE_BUILD_INPUT_READ_ONLY_BIT_KHR = 0x00080000, 
    VK_BUFFER_USAGE_ACCELERATION_STRUCTURE_STORAGE_BIT_KHR = 0x00100000, 
    VK_BUFFER_USAGE_SHADER_BINDING_TABLE_BIT_KHR = 0x00000400, 
    VK_BUFFER_USAGE_VIDEO_ENCODE_DST_BIT_KHR = 0x00008000, 
    VK_BUFFER_USAGE_VIDEO_ENCODE_SRC_BIT_KHR = 0x00010000, 
    VK_BUFFER_USAGE_SAMPLER_DESCRIPTOR_BUFFER_BIT_EXT = 0x00200000, 
    VK_BUFFER_USAGE_RESOURCE_DESCRIPTOR_BUFFER_BIT_EXT = 0x00400000, 
    VK_BUFFER_USAGE_PUSH_DESCRIPTORS_DESCRIPTOR_BUFFER_BIT_EXT = 0x04000000, 
    VK_BUFFER_USAGE_MICROMAP_BUILD_INPUT_READ_ONLY_BIT_EXT = 0x00800000, 
    VK_BUFFER_USAGE_MICROMAP_STORAGE_BIT_EXT = 0x01000000, 
    VK_BUFFER_USAGE_TILE_MEMORY_BIT_QCOM = 0x08000000, 
    VK_BUFFER_USAGE_RAY_TRACING_BIT_NV = VK_BUFFER_USAGE_SHADER_BINDING_TABLE_BIT_KHR, 
    VK_BUFFER_USAGE_SHADER_DEVICE_ADDRESS_BIT_EXT = VK_BUFFER_USAGE_SHADER_DEVICE_ADDRESS_BIT, 
    VK_BUFFER_USAGE_SHADER_DEVICE_ADDRESS_BIT_KHR = VK_BUFFER_USAGE_SHADER_DEVICE_ADDRESS_BIT, 
    VK_BUFFER_USAGE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkImageViewCreateFlagBits : uint   {
    VK_IMAGE_VIEW_CREATE_FRAGMENT_DENSITY_MAP_DYNAMIC_BIT_EXT = 0x00000001, 
    VK_IMAGE_VIEW_CREATE_DESCRIPTOR_BUFFER_CAPTURE_REPLAY_BIT_EXT = 0x00000004, 
    VK_IMAGE_VIEW_CREATE_FRAGMENT_DENSITY_MAP_DEFERRED_BIT_EXT = 0x00000002, 
    VK_IMAGE_VIEW_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkPipelineCacheCreateFlagBits : uint   {
    VK_PIPELINE_CACHE_CREATE_EXTERNALLY_SYNCHRONIZED_BIT = 0x00000001, 
    VK_PIPELINE_CACHE_CREATE_INTERNALLY_SYNCHRONIZED_MERGE_BIT_KHR = 0x00000008, 
    VK_PIPELINE_CACHE_CREATE_EXTERNALLY_SYNCHRONIZED_BIT_EXT = VK_PIPELINE_CACHE_CREATE_EXTERNALLY_SYNCHRONIZED_BIT, 
    VK_PIPELINE_CACHE_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkColorComponentFlagBits : uint   {
    VK_COLOR_COMPONENT_R_BIT = 0x00000001, 
    VK_COLOR_COMPONENT_G_BIT = 0x00000002, 
    VK_COLOR_COMPONENT_B_BIT = 0x00000004, 
    VK_COLOR_COMPONENT_A_BIT = 0x00000008, 
    VK_COLOR_COMPONENT_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkPipelineCreateFlagBits : uint   {
    VK_PIPELINE_CREATE_DISABLE_OPTIMIZATION_BIT = 0x00000001, 
    VK_PIPELINE_CREATE_ALLOW_DERIVATIVES_BIT = 0x00000002, 
    VK_PIPELINE_CREATE_DERIVATIVE_BIT = 0x00000004, 
    VK_PIPELINE_CREATE_VIEW_INDEX_FROM_DEVICE_INDEX_BIT = 0x00000008, 
    VK_PIPELINE_CREATE_DISPATCH_BASE_BIT = 0x00000010, 
    VK_PIPELINE_CREATE_FAIL_ON_PIPELINE_COMPILE_REQUIRED_BIT = 0x00000100, 
    VK_PIPELINE_CREATE_EARLY_RETURN_ON_FAILURE_BIT = 0x00000200, 
    VK_PIPELINE_CREATE_NO_PROTECTED_ACCESS_BIT = 0x08000000, 
    VK_PIPELINE_CREATE_PROTECTED_ACCESS_ONLY_BIT = 0x40000000, 
    VK_PIPELINE_CREATE_RAY_TRACING_NO_NULL_ANY_HIT_SHADERS_BIT_KHR = 0x00004000, 
    VK_PIPELINE_CREATE_RAY_TRACING_NO_NULL_CLOSEST_HIT_SHADERS_BIT_KHR = 0x00008000, 
    VK_PIPELINE_CREATE_RAY_TRACING_NO_NULL_MISS_SHADERS_BIT_KHR = 0x00010000, 
    VK_PIPELINE_CREATE_RAY_TRACING_NO_NULL_INTERSECTION_SHADERS_BIT_KHR = 0x00020000, 
    VK_PIPELINE_CREATE_RAY_TRACING_SKIP_TRIANGLES_BIT_KHR = 0x00001000, 
    VK_PIPELINE_CREATE_RAY_TRACING_SKIP_AABBS_BIT_KHR = 0x00002000, 
    VK_PIPELINE_CREATE_RAY_TRACING_SHADER_GROUP_HANDLE_CAPTURE_REPLAY_BIT_KHR = 0x00080000, 
    VK_PIPELINE_CREATE_DEFER_COMPILE_BIT_NV = 0x00000020, 
    VK_PIPELINE_CREATE_RENDERING_FRAGMENT_DENSITY_MAP_ATTACHMENT_BIT_EXT = 0x00400000, 
    VK_PIPELINE_CREATE_RENDERING_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR = 0x00200000, 
    VK_PIPELINE_CREATE_CAPTURE_STATISTICS_BIT_KHR = 0x00000040, 
    VK_PIPELINE_CREATE_CAPTURE_INTERNAL_REPRESENTATIONS_BIT_KHR = 0x00000080, 
    VK_PIPELINE_CREATE_INDIRECT_BINDABLE_BIT_NV = 0x00040000, 
    VK_PIPELINE_CREATE_LIBRARY_BIT_KHR = 0x00000800, 
    VK_PIPELINE_CREATE_DESCRIPTOR_BUFFER_BIT_EXT = 0x20000000, 
    VK_PIPELINE_CREATE_RETAIN_LINK_TIME_OPTIMIZATION_INFO_BIT_EXT = 0x00800000, 
    VK_PIPELINE_CREATE_LINK_TIME_OPTIMIZATION_BIT_EXT = 0x00000400, 
    VK_PIPELINE_CREATE_RAY_TRACING_ALLOW_MOTION_BIT_NV = 0x00100000, 
    VK_PIPELINE_CREATE_COLOR_ATTACHMENT_FEEDBACK_LOOP_BIT_EXT = 0x02000000, 
    VK_PIPELINE_CREATE_DEPTH_STENCIL_ATTACHMENT_FEEDBACK_LOOP_BIT_EXT = 0x04000000, 
    VK_PIPELINE_CREATE_RAY_TRACING_OPACITY_MICROMAP_BIT_EXT = 0x01000000, 
    VK_PIPELINE_CREATE_RAY_TRACING_DISPLACEMENT_MICROMAP_BIT_NV = 0x10000000, 
    VK_PIPELINE_CREATE_DISPATCH_BASE = VK_PIPELINE_CREATE_DISPATCH_BASE_BIT, 
    VK_PIPELINE_CREATE_VIEW_INDEX_FROM_DEVICE_INDEX_BIT_KHR = VK_PIPELINE_CREATE_VIEW_INDEX_FROM_DEVICE_INDEX_BIT, 
    VK_PIPELINE_CREATE_DISPATCH_BASE_KHR = VK_PIPELINE_CREATE_DISPATCH_BASE, 
  // VK_PIPELINE_RASTERIZATION_STATE_CREATE_FRAGMENT_DENSITY_MAP_ATTACHMENT_BIT_EXT is a deprecated alias 
    VK_PIPELINE_RASTERIZATION_STATE_CREATE_FRAGMENT_DENSITY_MAP_ATTACHMENT_BIT_EXT = VK_PIPELINE_CREATE_RENDERING_FRAGMENT_DENSITY_MAP_ATTACHMENT_BIT_EXT, 
  // VK_PIPELINE_RASTERIZATION_STATE_CREATE_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR is a deprecated alias 
    VK_PIPELINE_RASTERIZATION_STATE_CREATE_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR = VK_PIPELINE_CREATE_RENDERING_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR, 
    VK_PIPELINE_CREATE_FAIL_ON_PIPELINE_COMPILE_REQUIRED_BIT_EXT = VK_PIPELINE_CREATE_FAIL_ON_PIPELINE_COMPILE_REQUIRED_BIT, 
    VK_PIPELINE_CREATE_EARLY_RETURN_ON_FAILURE_BIT_EXT = VK_PIPELINE_CREATE_EARLY_RETURN_ON_FAILURE_BIT, 
    VK_PIPELINE_CREATE_NO_PROTECTED_ACCESS_BIT_EXT = VK_PIPELINE_CREATE_NO_PROTECTED_ACCESS_BIT, 
    VK_PIPELINE_CREATE_PROTECTED_ACCESS_ONLY_BIT_EXT = VK_PIPELINE_CREATE_PROTECTED_ACCESS_ONLY_BIT, 
    VK_PIPELINE_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkPipelineShaderStageCreateFlagBits : uint   {
    VK_PIPELINE_SHADER_STAGE_CREATE_ALLOW_VARYING_SUBGROUP_SIZE_BIT = 0x00000001, 
    VK_PIPELINE_SHADER_STAGE_CREATE_REQUIRE_FULL_SUBGROUPS_BIT = 0x00000002, 
    VK_PIPELINE_SHADER_STAGE_CREATE_ALLOW_VARYING_SUBGROUP_SIZE_BIT_EXT = VK_PIPELINE_SHADER_STAGE_CREATE_ALLOW_VARYING_SUBGROUP_SIZE_BIT, 
    VK_PIPELINE_SHADER_STAGE_CREATE_REQUIRE_FULL_SUBGROUPS_BIT_EXT = VK_PIPELINE_SHADER_STAGE_CREATE_REQUIRE_FULL_SUBGROUPS_BIT, 
    VK_PIPELINE_SHADER_STAGE_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkShaderStageFlagBits : uint   {
    VK_SHADER_STAGE_VERTEX_BIT = 0x00000001, 
    VK_SHADER_STAGE_TESSELLATION_CONTROL_BIT = 0x00000002, 
    VK_SHADER_STAGE_TESSELLATION_EVALUATION_BIT = 0x00000004, 
    VK_SHADER_STAGE_GEOMETRY_BIT = 0x00000008, 
    VK_SHADER_STAGE_FRAGMENT_BIT = 0x00000010, 
    VK_SHADER_STAGE_COMPUTE_BIT = 0x00000020, 
    VK_SHADER_STAGE_ALL_GRAPHICS = 0x0000001F, 
    VK_SHADER_STAGE_ALL = 0x7FFFFFFF, 
    VK_SHADER_STAGE_RAYGEN_BIT_KHR = 0x00000100, 
    VK_SHADER_STAGE_ANY_HIT_BIT_KHR = 0x00000200, 
    VK_SHADER_STAGE_CLOSEST_HIT_BIT_KHR = 0x00000400, 
    VK_SHADER_STAGE_MISS_BIT_KHR = 0x00000800, 
    VK_SHADER_STAGE_INTERSECTION_BIT_KHR = 0x00001000, 
    VK_SHADER_STAGE_CALLABLE_BIT_KHR = 0x00002000, 
    VK_SHADER_STAGE_TASK_BIT_EXT = 0x00000040, 
    VK_SHADER_STAGE_MESH_BIT_EXT = 0x00000080, 
    VK_SHADER_STAGE_SUBPASS_SHADING_BIT_HUAWEI = 0x00004000, 
    VK_SHADER_STAGE_CLUSTER_CULLING_BIT_HUAWEI = 0x00080000, 
    VK_SHADER_STAGE_RAYGEN_BIT_NV = VK_SHADER_STAGE_RAYGEN_BIT_KHR, 
    VK_SHADER_STAGE_ANY_HIT_BIT_NV = VK_SHADER_STAGE_ANY_HIT_BIT_KHR, 
    VK_SHADER_STAGE_CLOSEST_HIT_BIT_NV = VK_SHADER_STAGE_CLOSEST_HIT_BIT_KHR, 
    VK_SHADER_STAGE_MISS_BIT_NV = VK_SHADER_STAGE_MISS_BIT_KHR, 
    VK_SHADER_STAGE_INTERSECTION_BIT_NV = VK_SHADER_STAGE_INTERSECTION_BIT_KHR, 
    VK_SHADER_STAGE_CALLABLE_BIT_NV = VK_SHADER_STAGE_CALLABLE_BIT_KHR, 
    VK_SHADER_STAGE_TASK_BIT_NV = VK_SHADER_STAGE_TASK_BIT_EXT, 
    VK_SHADER_STAGE_MESH_BIT_NV = VK_SHADER_STAGE_MESH_BIT_EXT, 
    VK_SHADER_STAGE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkCullModeFlagBits : uint   {
    VK_CULL_MODE_NONE = 0, 
    VK_CULL_MODE_FRONT_BIT = 0x00000001, 
    VK_CULL_MODE_BACK_BIT = 0x00000002, 
    VK_CULL_MODE_FRONT_AND_BACK = 0x00000003, 
    VK_CULL_MODE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkPipelineDepthStencilStateCreateFlagBits : uint   {
    VK_PIPELINE_DEPTH_STENCIL_STATE_CREATE_RASTERIZATION_ORDER_ATTACHMENT_DEPTH_ACCESS_BIT_EXT = 0x00000001, 
    VK_PIPELINE_DEPTH_STENCIL_STATE_CREATE_RASTERIZATION_ORDER_ATTACHMENT_STENCIL_ACCESS_BIT_EXT = 0x00000002, 
    VK_PIPELINE_DEPTH_STENCIL_STATE_CREATE_RASTERIZATION_ORDER_ATTACHMENT_DEPTH_ACCESS_BIT_ARM = VK_PIPELINE_DEPTH_STENCIL_STATE_CREATE_RASTERIZATION_ORDER_ATTACHMENT_DEPTH_ACCESS_BIT_EXT, 
    VK_PIPELINE_DEPTH_STENCIL_STATE_CREATE_RASTERIZATION_ORDER_ATTACHMENT_STENCIL_ACCESS_BIT_ARM = VK_PIPELINE_DEPTH_STENCIL_STATE_CREATE_RASTERIZATION_ORDER_ATTACHMENT_STENCIL_ACCESS_BIT_EXT, 
    VK_PIPELINE_DEPTH_STENCIL_STATE_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkPipelineColorBlendStateCreateFlagBits : uint   {
    VK_PIPELINE_COLOR_BLEND_STATE_CREATE_RASTERIZATION_ORDER_ATTACHMENT_ACCESS_BIT_EXT = 0x00000001, 
    VK_PIPELINE_COLOR_BLEND_STATE_CREATE_RASTERIZATION_ORDER_ATTACHMENT_ACCESS_BIT_ARM = VK_PIPELINE_COLOR_BLEND_STATE_CREATE_RASTERIZATION_ORDER_ATTACHMENT_ACCESS_BIT_EXT, 
    VK_PIPELINE_COLOR_BLEND_STATE_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkPipelineLayoutCreateFlagBits : uint   {
    VK_PIPELINE_LAYOUT_CREATE_INDEPENDENT_SETS_BIT_EXT = 0x00000002, 
    VK_PIPELINE_LAYOUT_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkSamplerCreateFlagBits : uint   {
    VK_SAMPLER_CREATE_SUBSAMPLED_BIT_EXT = 0x00000001, 
    VK_SAMPLER_CREATE_SUBSAMPLED_COARSE_RECONSTRUCTION_BIT_EXT = 0x00000002, 
    VK_SAMPLER_CREATE_DESCRIPTOR_BUFFER_CAPTURE_REPLAY_BIT_EXT = 0x00000008, 
    VK_SAMPLER_CREATE_NON_SEAMLESS_CUBE_MAP_BIT_EXT = 0x00000004, 
    VK_SAMPLER_CREATE_IMAGE_PROCESSING_BIT_QCOM = 0x00000010, 
    VK_SAMPLER_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkDescriptorPoolCreateFlagBits : uint   {
    VK_DESCRIPTOR_POOL_CREATE_FREE_DESCRIPTOR_SET_BIT = 0x00000001, 
    VK_DESCRIPTOR_POOL_CREATE_UPDATE_AFTER_BIND_BIT = 0x00000002, 
    VK_DESCRIPTOR_POOL_CREATE_HOST_ONLY_BIT_EXT = 0x00000004, 
    VK_DESCRIPTOR_POOL_CREATE_ALLOW_OVERALLOCATION_SETS_BIT_NV = 0x00000008, 
    VK_DESCRIPTOR_POOL_CREATE_ALLOW_OVERALLOCATION_POOLS_BIT_NV = 0x00000010, 
    VK_DESCRIPTOR_POOL_CREATE_UPDATE_AFTER_BIND_BIT_EXT = VK_DESCRIPTOR_POOL_CREATE_UPDATE_AFTER_BIND_BIT, 
    VK_DESCRIPTOR_POOL_CREATE_HOST_ONLY_BIT_VALVE = VK_DESCRIPTOR_POOL_CREATE_HOST_ONLY_BIT_EXT, 
    VK_DESCRIPTOR_POOL_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkDescriptorSetLayoutCreateFlagBits : uint   {
    VK_DESCRIPTOR_SET_LAYOUT_CREATE_UPDATE_AFTER_BIND_POOL_BIT = 0x00000002, 
    VK_DESCRIPTOR_SET_LAYOUT_CREATE_PUSH_DESCRIPTOR_BIT = 0x00000001, 
    VK_DESCRIPTOR_SET_LAYOUT_CREATE_DESCRIPTOR_BUFFER_BIT_EXT = 0x00000010, 
    VK_DESCRIPTOR_SET_LAYOUT_CREATE_EMBEDDED_IMMUTABLE_SAMPLERS_BIT_EXT = 0x00000020, 
    VK_DESCRIPTOR_SET_LAYOUT_CREATE_INDIRECT_BINDABLE_BIT_NV = 0x00000080, 
    VK_DESCRIPTOR_SET_LAYOUT_CREATE_HOST_ONLY_POOL_BIT_EXT = 0x00000004, 
    VK_DESCRIPTOR_SET_LAYOUT_CREATE_PER_STAGE_BIT_NV = 0x00000040, 
    VK_DESCRIPTOR_SET_LAYOUT_CREATE_PUSH_DESCRIPTOR_BIT_KHR = VK_DESCRIPTOR_SET_LAYOUT_CREATE_PUSH_DESCRIPTOR_BIT, 
    VK_DESCRIPTOR_SET_LAYOUT_CREATE_UPDATE_AFTER_BIND_POOL_BIT_EXT = VK_DESCRIPTOR_SET_LAYOUT_CREATE_UPDATE_AFTER_BIND_POOL_BIT, 
    VK_DESCRIPTOR_SET_LAYOUT_CREATE_HOST_ONLY_POOL_BIT_VALVE = VK_DESCRIPTOR_SET_LAYOUT_CREATE_HOST_ONLY_POOL_BIT_EXT, 
    VK_DESCRIPTOR_SET_LAYOUT_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkAttachmentDescriptionFlagBits : uint   {
    VK_ATTACHMENT_DESCRIPTION_MAY_ALIAS_BIT = 0x00000001, 
    VK_ATTACHMENT_DESCRIPTION_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkDependencyFlagBits : uint   {
    VK_DEPENDENCY_BY_REGION_BIT = 0x00000001, 
    VK_DEPENDENCY_DEVICE_GROUP_BIT = 0x00000004, 
    VK_DEPENDENCY_VIEW_LOCAL_BIT = 0x00000002, 
    VK_DEPENDENCY_FEEDBACK_LOOP_BIT_EXT = 0x00000008, 
    VK_DEPENDENCY_QUEUE_FAMILY_OWNERSHIP_TRANSFER_USE_ALL_STAGES_BIT_KHR = 0x00000020, 
    VK_DEPENDENCY_VIEW_LOCAL_BIT_KHR = VK_DEPENDENCY_VIEW_LOCAL_BIT, 
    VK_DEPENDENCY_DEVICE_GROUP_BIT_KHR = VK_DEPENDENCY_DEVICE_GROUP_BIT, 
    VK_DEPENDENCY_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkFramebufferCreateFlagBits : uint   {
    VK_FRAMEBUFFER_CREATE_IMAGELESS_BIT = 0x00000001, 
    VK_FRAMEBUFFER_CREATE_IMAGELESS_BIT_KHR = VK_FRAMEBUFFER_CREATE_IMAGELESS_BIT, 
    VK_FRAMEBUFFER_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkRenderPassCreateFlagBits : uint   {
    VK_RENDER_PASS_CREATE_TRANSFORM_BIT_QCOM = 0x00000002, 
    VK_RENDER_PASS_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkSubpassDescriptionFlagBits : uint   {
    VK_SUBPASS_DESCRIPTION_PER_VIEW_ATTRIBUTES_BIT_NVX = 0x00000001, 
    VK_SUBPASS_DESCRIPTION_PER_VIEW_POSITION_X_ONLY_BIT_NVX = 0x00000002, 
    VK_SUBPASS_DESCRIPTION_FRAGMENT_REGION_BIT_QCOM = 0x00000004, 
    VK_SUBPASS_DESCRIPTION_SHADER_RESOLVE_BIT_QCOM = 0x00000008, 
    VK_SUBPASS_DESCRIPTION_TILE_SHADING_APRON_BIT_QCOM = 0x00000100, 
    VK_SUBPASS_DESCRIPTION_RASTERIZATION_ORDER_ATTACHMENT_COLOR_ACCESS_BIT_EXT = 0x00000010, 
    VK_SUBPASS_DESCRIPTION_RASTERIZATION_ORDER_ATTACHMENT_DEPTH_ACCESS_BIT_EXT = 0x00000020, 
    VK_SUBPASS_DESCRIPTION_RASTERIZATION_ORDER_ATTACHMENT_STENCIL_ACCESS_BIT_EXT = 0x00000040, 
    VK_SUBPASS_DESCRIPTION_ENABLE_LEGACY_DITHERING_BIT_EXT = 0x00000080, 
    VK_SUBPASS_DESCRIPTION_RASTERIZATION_ORDER_ATTACHMENT_COLOR_ACCESS_BIT_ARM = VK_SUBPASS_DESCRIPTION_RASTERIZATION_ORDER_ATTACHMENT_COLOR_ACCESS_BIT_EXT, 
    VK_SUBPASS_DESCRIPTION_RASTERIZATION_ORDER_ATTACHMENT_DEPTH_ACCESS_BIT_ARM = VK_SUBPASS_DESCRIPTION_RASTERIZATION_ORDER_ATTACHMENT_DEPTH_ACCESS_BIT_EXT, 
    VK_SUBPASS_DESCRIPTION_RASTERIZATION_ORDER_ATTACHMENT_STENCIL_ACCESS_BIT_ARM = VK_SUBPASS_DESCRIPTION_RASTERIZATION_ORDER_ATTACHMENT_STENCIL_ACCESS_BIT_EXT, 
    VK_SUBPASS_DESCRIPTION_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkCommandPoolCreateFlagBits : uint   {
    VK_COMMAND_POOL_CREATE_TRANSIENT_BIT = 0x00000001, 
    VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT = 0x00000002, 
    VK_COMMAND_POOL_CREATE_PROTECTED_BIT = 0x00000004, 
    VK_COMMAND_POOL_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkCommandPoolResetFlagBits : uint   {
    VK_COMMAND_POOL_RESET_RELEASE_RESOURCES_BIT = 0x00000001, 
    VK_COMMAND_POOL_RESET_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkCommandBufferUsageFlagBits : uint   {
    VK_COMMAND_BUFFER_USAGE_ONE_TIME_SUBMIT_BIT = 0x00000001, 
    VK_COMMAND_BUFFER_USAGE_RENDER_PASS_CONTINUE_BIT = 0x00000002, 
    VK_COMMAND_BUFFER_USAGE_SIMULTANEOUS_USE_BIT = 0x00000004, 
    VK_COMMAND_BUFFER_USAGE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkQueryControlFlagBits : uint   {
    VK_QUERY_CONTROL_PRECISE_BIT = 0x00000001, 
    VK_QUERY_CONTROL_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkCommandBufferResetFlagBits : uint   {
    VK_COMMAND_BUFFER_RESET_RELEASE_RESOURCES_BIT = 0x00000001, 
    VK_COMMAND_BUFFER_RESET_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkStencilFaceFlagBits : uint   {
    VK_STENCIL_FACE_FRONT_BIT = 0x00000001, 
    VK_STENCIL_FACE_BACK_BIT = 0x00000002, 
    VK_STENCIL_FACE_FRONT_AND_BACK = 0x00000003, 
  // VK_STENCIL_FRONT_AND_BACK is a deprecated alias 
    VK_STENCIL_FRONT_AND_BACK = VK_STENCIL_FACE_FRONT_AND_BACK, 
    VK_STENCIL_FACE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkPointClippingBehavior : uint   {
    VK_POINT_CLIPPING_BEHAVIOR_ALL_CLIP_PLANES = 0, 
    VK_POINT_CLIPPING_BEHAVIOR_USER_CLIP_PLANES_ONLY = 1, 
    VK_POINT_CLIPPING_BEHAVIOR_ALL_CLIP_PLANES_KHR = VK_POINT_CLIPPING_BEHAVIOR_ALL_CLIP_PLANES, 
    VK_POINT_CLIPPING_BEHAVIOR_USER_CLIP_PLANES_ONLY_KHR = VK_POINT_CLIPPING_BEHAVIOR_USER_CLIP_PLANES_ONLY, 
    VK_POINT_CLIPPING_BEHAVIOR_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkTessellationDomainOrigin : uint   {
    VK_TESSELLATION_DOMAIN_ORIGIN_UPPER_LEFT = 0, 
    VK_TESSELLATION_DOMAIN_ORIGIN_LOWER_LEFT = 1, 
    VK_TESSELLATION_DOMAIN_ORIGIN_UPPER_LEFT_KHR = VK_TESSELLATION_DOMAIN_ORIGIN_UPPER_LEFT, 
    VK_TESSELLATION_DOMAIN_ORIGIN_LOWER_LEFT_KHR = VK_TESSELLATION_DOMAIN_ORIGIN_LOWER_LEFT, 
    VK_TESSELLATION_DOMAIN_ORIGIN_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkSamplerYcbcrModelConversion : uint   {
    VK_SAMPLER_YCBCR_MODEL_CONVERSION_RGB_IDENTITY = 0, 
    VK_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_IDENTITY = 1, 
    VK_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_709 = 2, 
    VK_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_601 = 3, 
    VK_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_2020 = 4, 
    VK_SAMPLER_YCBCR_MODEL_CONVERSION_RGB_IDENTITY_KHR = VK_SAMPLER_YCBCR_MODEL_CONVERSION_RGB_IDENTITY, 
    VK_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_IDENTITY_KHR = VK_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_IDENTITY, 
    VK_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_709_KHR = VK_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_709, 
    VK_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_601_KHR = VK_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_601, 
    VK_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_2020_KHR = VK_SAMPLER_YCBCR_MODEL_CONVERSION_YCBCR_2020, 
    VK_SAMPLER_YCBCR_MODEL_CONVERSION_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkSamplerYcbcrRange : uint   {
    VK_SAMPLER_YCBCR_RANGE_ITU_FULL = 0, 
    VK_SAMPLER_YCBCR_RANGE_ITU_NARROW = 1, 
    VK_SAMPLER_YCBCR_RANGE_ITU_FULL_KHR = VK_SAMPLER_YCBCR_RANGE_ITU_FULL, 
    VK_SAMPLER_YCBCR_RANGE_ITU_NARROW_KHR = VK_SAMPLER_YCBCR_RANGE_ITU_NARROW, 
    VK_SAMPLER_YCBCR_RANGE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkChromaLocation : uint   {
    VK_CHROMA_LOCATION_COSITED_EVEN = 0, 
    VK_CHROMA_LOCATION_MIDPOINT = 1, 
    VK_CHROMA_LOCATION_COSITED_EVEN_KHR = VK_CHROMA_LOCATION_COSITED_EVEN, 
    VK_CHROMA_LOCATION_MIDPOINT_KHR = VK_CHROMA_LOCATION_MIDPOINT, 
    VK_CHROMA_LOCATION_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkDescriptorUpdateTemplateType : uint   {
    VK_DESCRIPTOR_UPDATE_TEMPLATE_TYPE_DESCRIPTOR_SET = 0, 
    VK_DESCRIPTOR_UPDATE_TEMPLATE_TYPE_PUSH_DESCRIPTORS = 1, 
    VK_DESCRIPTOR_UPDATE_TEMPLATE_TYPE_PUSH_DESCRIPTORS_KHR = VK_DESCRIPTOR_UPDATE_TEMPLATE_TYPE_PUSH_DESCRIPTORS, 
    VK_DESCRIPTOR_UPDATE_TEMPLATE_TYPE_DESCRIPTOR_SET_KHR = VK_DESCRIPTOR_UPDATE_TEMPLATE_TYPE_DESCRIPTOR_SET, 
    VK_DESCRIPTOR_UPDATE_TEMPLATE_TYPE_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkSubgroupFeatureFlagBits : uint   {
    VK_SUBGROUP_FEATURE_BASIC_BIT = 0x00000001, 
    VK_SUBGROUP_FEATURE_VOTE_BIT = 0x00000002, 
    VK_SUBGROUP_FEATURE_ARITHMETIC_BIT = 0x00000004, 
    VK_SUBGROUP_FEATURE_BALLOT_BIT = 0x00000008, 
    VK_SUBGROUP_FEATURE_SHUFFLE_BIT = 0x00000010, 
    VK_SUBGROUP_FEATURE_SHUFFLE_RELATIVE_BIT = 0x00000020, 
    VK_SUBGROUP_FEATURE_CLUSTERED_BIT = 0x00000040, 
    VK_SUBGROUP_FEATURE_QUAD_BIT = 0x00000080, 
    VK_SUBGROUP_FEATURE_ROTATE_BIT = 0x00000200, 
    VK_SUBGROUP_FEATURE_ROTATE_CLUSTERED_BIT = 0x00000400, 
    VK_SUBGROUP_FEATURE_PARTITIONED_BIT_NV = 0x00000100, 
    VK_SUBGROUP_FEATURE_ROTATE_BIT_KHR = VK_SUBGROUP_FEATURE_ROTATE_BIT, 
    VK_SUBGROUP_FEATURE_ROTATE_CLUSTERED_BIT_KHR = VK_SUBGROUP_FEATURE_ROTATE_CLUSTERED_BIT, 
    VK_SUBGROUP_FEATURE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkPeerMemoryFeatureFlagBits : uint   {
    VK_PEER_MEMORY_FEATURE_COPY_SRC_BIT = 0x00000001, 
    VK_PEER_MEMORY_FEATURE_COPY_DST_BIT = 0x00000002, 
    VK_PEER_MEMORY_FEATURE_GENERIC_SRC_BIT = 0x00000004, 
    VK_PEER_MEMORY_FEATURE_GENERIC_DST_BIT = 0x00000008, 
    VK_PEER_MEMORY_FEATURE_COPY_SRC_BIT_KHR = VK_PEER_MEMORY_FEATURE_COPY_SRC_BIT, 
    VK_PEER_MEMORY_FEATURE_COPY_DST_BIT_KHR = VK_PEER_MEMORY_FEATURE_COPY_DST_BIT, 
    VK_PEER_MEMORY_FEATURE_GENERIC_SRC_BIT_KHR = VK_PEER_MEMORY_FEATURE_GENERIC_SRC_BIT, 
    VK_PEER_MEMORY_FEATURE_GENERIC_DST_BIT_KHR = VK_PEER_MEMORY_FEATURE_GENERIC_DST_BIT, 
    VK_PEER_MEMORY_FEATURE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkMemoryAllocateFlagBits : uint   {
    VK_MEMORY_ALLOCATE_DEVICE_MASK_BIT = 0x00000001, 
    VK_MEMORY_ALLOCATE_DEVICE_ADDRESS_BIT = 0x00000002, 
    VK_MEMORY_ALLOCATE_DEVICE_ADDRESS_CAPTURE_REPLAY_BIT = 0x00000004, 
    VK_MEMORY_ALLOCATE_ZERO_INITIALIZE_BIT_EXT = 0x00000008, 
    VK_MEMORY_ALLOCATE_DEVICE_MASK_BIT_KHR = VK_MEMORY_ALLOCATE_DEVICE_MASK_BIT, 
    VK_MEMORY_ALLOCATE_DEVICE_ADDRESS_BIT_KHR = VK_MEMORY_ALLOCATE_DEVICE_ADDRESS_BIT, 
    VK_MEMORY_ALLOCATE_DEVICE_ADDRESS_CAPTURE_REPLAY_BIT_KHR = VK_MEMORY_ALLOCATE_DEVICE_ADDRESS_CAPTURE_REPLAY_BIT, 
    VK_MEMORY_ALLOCATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkExternalMemoryHandleTypeFlagBits : uint   {
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_OPAQUE_FD_BIT = 0x00000001, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_OPAQUE_WIN32_BIT = 0x00000002, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_OPAQUE_WIN32_KMT_BIT = 0x00000004, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D11_TEXTURE_BIT = 0x00000008, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D11_TEXTURE_KMT_BIT = 0x00000010, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D12_HEAP_BIT = 0x00000020, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D12_RESOURCE_BIT = 0x00000040, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_DMA_BUF_BIT_EXT = 0x00000200, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_ANDROID_HARDWARE_BUFFER_BIT_ANDROID = 0x00000400, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_HOST_ALLOCATION_BIT_EXT = 0x00000080, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_HOST_MAPPED_FOREIGN_MEMORY_BIT_EXT = 0x00000100, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_ZIRCON_VMO_BIT_FUCHSIA = 0x00000800, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_RDMA_ADDRESS_BIT_NV = 0x00001000, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_SCREEN_BUFFER_BIT_QNX = 0x00004000, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_MTLBUFFER_BIT_EXT = 0x00010000, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_MTLTEXTURE_BIT_EXT = 0x00020000, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_MTLHEAP_BIT_EXT = 0x00040000, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_OPAQUE_FD_BIT_KHR = VK_EXTERNAL_MEMORY_HANDLE_TYPE_OPAQUE_FD_BIT, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_OPAQUE_WIN32_BIT_KHR = VK_EXTERNAL_MEMORY_HANDLE_TYPE_OPAQUE_WIN32_BIT, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_OPAQUE_WIN32_KMT_BIT_KHR = VK_EXTERNAL_MEMORY_HANDLE_TYPE_OPAQUE_WIN32_KMT_BIT, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D11_TEXTURE_BIT_KHR = VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D11_TEXTURE_BIT, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D11_TEXTURE_KMT_BIT_KHR = VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D11_TEXTURE_KMT_BIT, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D12_HEAP_BIT_KHR = VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D12_HEAP_BIT, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D12_RESOURCE_BIT_KHR = VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D12_RESOURCE_BIT, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkExternalMemoryFeatureFlagBits : uint   {
    VK_EXTERNAL_MEMORY_FEATURE_DEDICATED_ONLY_BIT = 0x00000001, 
    VK_EXTERNAL_MEMORY_FEATURE_EXPORTABLE_BIT = 0x00000002, 
    VK_EXTERNAL_MEMORY_FEATURE_IMPORTABLE_BIT = 0x00000004, 
    VK_EXTERNAL_MEMORY_FEATURE_DEDICATED_ONLY_BIT_KHR = VK_EXTERNAL_MEMORY_FEATURE_DEDICATED_ONLY_BIT, 
    VK_EXTERNAL_MEMORY_FEATURE_EXPORTABLE_BIT_KHR = VK_EXTERNAL_MEMORY_FEATURE_EXPORTABLE_BIT, 
    VK_EXTERNAL_MEMORY_FEATURE_IMPORTABLE_BIT_KHR = VK_EXTERNAL_MEMORY_FEATURE_IMPORTABLE_BIT, 
    VK_EXTERNAL_MEMORY_FEATURE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkExternalFenceHandleTypeFlagBits : uint   {
    VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_FD_BIT = 0x00000001, 
    VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_WIN32_BIT = 0x00000002, 
    VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_WIN32_KMT_BIT = 0x00000004, 
    VK_EXTERNAL_FENCE_HANDLE_TYPE_SYNC_FD_BIT = 0x00000008, 
    VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_FD_BIT_KHR = VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_FD_BIT, 
    VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_WIN32_BIT_KHR = VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_WIN32_BIT, 
    VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_WIN32_KMT_BIT_KHR = VK_EXTERNAL_FENCE_HANDLE_TYPE_OPAQUE_WIN32_KMT_BIT, 
    VK_EXTERNAL_FENCE_HANDLE_TYPE_SYNC_FD_BIT_KHR = VK_EXTERNAL_FENCE_HANDLE_TYPE_SYNC_FD_BIT, 
    VK_EXTERNAL_FENCE_HANDLE_TYPE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkExternalFenceFeatureFlagBits : uint   {
    VK_EXTERNAL_FENCE_FEATURE_EXPORTABLE_BIT = 0x00000001, 
    VK_EXTERNAL_FENCE_FEATURE_IMPORTABLE_BIT = 0x00000002, 
    VK_EXTERNAL_FENCE_FEATURE_EXPORTABLE_BIT_KHR = VK_EXTERNAL_FENCE_FEATURE_EXPORTABLE_BIT, 
    VK_EXTERNAL_FENCE_FEATURE_IMPORTABLE_BIT_KHR = VK_EXTERNAL_FENCE_FEATURE_IMPORTABLE_BIT, 
    VK_EXTERNAL_FENCE_FEATURE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkFenceImportFlagBits : uint   {
    VK_FENCE_IMPORT_TEMPORARY_BIT = 0x00000001, 
    VK_FENCE_IMPORT_TEMPORARY_BIT_KHR = VK_FENCE_IMPORT_TEMPORARY_BIT, 
    VK_FENCE_IMPORT_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkSemaphoreImportFlagBits : uint   {
    VK_SEMAPHORE_IMPORT_TEMPORARY_BIT = 0x00000001, 
    VK_SEMAPHORE_IMPORT_TEMPORARY_BIT_KHR = VK_SEMAPHORE_IMPORT_TEMPORARY_BIT, 
    VK_SEMAPHORE_IMPORT_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkExternalSemaphoreHandleTypeFlagBits : uint   {
    VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_OPAQUE_FD_BIT = 0x00000001, 
    VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_OPAQUE_WIN32_BIT = 0x00000002, 
    VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_OPAQUE_WIN32_KMT_BIT = 0x00000004, 
    VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_D3D12_FENCE_BIT = 0x00000008, 
    VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_SYNC_FD_BIT = 0x00000010, 
    VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_ZIRCON_EVENT_BIT_FUCHSIA = 0x00000080, 
    VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_D3D11_FENCE_BIT = VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_D3D12_FENCE_BIT, 
    VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_OPAQUE_FD_BIT_KHR = VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_OPAQUE_FD_BIT, 
    VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_OPAQUE_WIN32_BIT_KHR = VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_OPAQUE_WIN32_BIT, 
    VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_OPAQUE_WIN32_KMT_BIT_KHR = VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_OPAQUE_WIN32_KMT_BIT, 
    VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_D3D12_FENCE_BIT_KHR = VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_D3D12_FENCE_BIT, 
    VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_SYNC_FD_BIT_KHR = VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_SYNC_FD_BIT, 
    VK_EXTERNAL_SEMAPHORE_HANDLE_TYPE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};

[Flags] public enum VkExternalSemaphoreFeatureFlagBits : uint   {
    VK_EXTERNAL_SEMAPHORE_FEATURE_EXPORTABLE_BIT = 0x00000001, 
    VK_EXTERNAL_SEMAPHORE_FEATURE_IMPORTABLE_BIT = 0x00000002, 
    VK_EXTERNAL_SEMAPHORE_FEATURE_EXPORTABLE_BIT_KHR = VK_EXTERNAL_SEMAPHORE_FEATURE_EXPORTABLE_BIT, 
    VK_EXTERNAL_SEMAPHORE_FEATURE_IMPORTABLE_BIT_KHR = VK_EXTERNAL_SEMAPHORE_FEATURE_IMPORTABLE_BIT, 
    VK_EXTERNAL_SEMAPHORE_FEATURE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_2
[Flags] public enum VkDriverId : uint   {
    VK_DRIVER_ID_AMD_PROPRIETARY = 1, 
    VK_DRIVER_ID_AMD_OPEN_SOURCE = 2, 
    VK_DRIVER_ID_MESA_RADV = 3, 
    VK_DRIVER_ID_NVIDIA_PROPRIETARY = 4, 
    VK_DRIVER_ID_INTEL_PROPRIETARY_WINDOWS = 5, 
    VK_DRIVER_ID_INTEL_OPEN_SOURCE_MESA = 6, 
    VK_DRIVER_ID_IMAGINATION_PROPRIETARY = 7, 
    VK_DRIVER_ID_QUALCOMM_PROPRIETARY = 8, 
    VK_DRIVER_ID_ARM_PROPRIETARY = 9, 
    VK_DRIVER_ID_GOOGLE_SWIFTSHADER = 10, 
    VK_DRIVER_ID_GGP_PROPRIETARY = 11, 
    VK_DRIVER_ID_BROADCOM_PROPRIETARY = 12, 
    VK_DRIVER_ID_MESA_LLVMPIPE = 13, 
    VK_DRIVER_ID_MOLTENVK = 14, 
    VK_DRIVER_ID_COREAVI_PROPRIETARY = 15, 
    VK_DRIVER_ID_JUICE_PROPRIETARY = 16, 
    VK_DRIVER_ID_VERISILICON_PROPRIETARY = 17, 
    VK_DRIVER_ID_MESA_TURNIP = 18, 
    VK_DRIVER_ID_MESA_V3DV = 19, 
    VK_DRIVER_ID_MESA_PANVK = 20, 
    VK_DRIVER_ID_SAMSUNG_PROPRIETARY = 21, 
    VK_DRIVER_ID_MESA_VENUS = 22, 
    VK_DRIVER_ID_MESA_DOZEN = 23, 
    VK_DRIVER_ID_MESA_NVK = 24, 
    VK_DRIVER_ID_IMAGINATION_OPEN_SOURCE_MESA = 25, 
    VK_DRIVER_ID_MESA_HONEYKRISP = 26, 
    VK_DRIVER_ID_VULKAN_SC_EMULATION_ON_VULKAN = 27, 
    VK_DRIVER_ID_AMD_PROPRIETARY_KHR = VK_DRIVER_ID_AMD_PROPRIETARY, 
    VK_DRIVER_ID_AMD_OPEN_SOURCE_KHR = VK_DRIVER_ID_AMD_OPEN_SOURCE, 
    VK_DRIVER_ID_MESA_RADV_KHR = VK_DRIVER_ID_MESA_RADV, 
    VK_DRIVER_ID_NVIDIA_PROPRIETARY_KHR = VK_DRIVER_ID_NVIDIA_PROPRIETARY, 
    VK_DRIVER_ID_INTEL_PROPRIETARY_WINDOWS_KHR = VK_DRIVER_ID_INTEL_PROPRIETARY_WINDOWS, 
    VK_DRIVER_ID_INTEL_OPEN_SOURCE_MESA_KHR = VK_DRIVER_ID_INTEL_OPEN_SOURCE_MESA, 
    VK_DRIVER_ID_IMAGINATION_PROPRIETARY_KHR = VK_DRIVER_ID_IMAGINATION_PROPRIETARY, 
    VK_DRIVER_ID_QUALCOMM_PROPRIETARY_KHR = VK_DRIVER_ID_QUALCOMM_PROPRIETARY, 
    VK_DRIVER_ID_ARM_PROPRIETARY_KHR = VK_DRIVER_ID_ARM_PROPRIETARY, 
    VK_DRIVER_ID_GOOGLE_SWIFTSHADER_KHR = VK_DRIVER_ID_GOOGLE_SWIFTSHADER, 
    VK_DRIVER_ID_GGP_PROPRIETARY_KHR = VK_DRIVER_ID_GGP_PROPRIETARY, 
    VK_DRIVER_ID_BROADCOM_PROPRIETARY_KHR = VK_DRIVER_ID_BROADCOM_PROPRIETARY, 
    VK_DRIVER_ID_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_2
[Flags] public enum VkShaderFloatControlsIndependence : uint   {
    VK_SHADER_FLOAT_CONTROLS_INDEPENDENCE_32_BIT_ONLY = 0, 
    VK_SHADER_FLOAT_CONTROLS_INDEPENDENCE_ALL = 1, 
    VK_SHADER_FLOAT_CONTROLS_INDEPENDENCE_NONE = 2, 
    VK_SHADER_FLOAT_CONTROLS_INDEPENDENCE_32_BIT_ONLY_KHR = VK_SHADER_FLOAT_CONTROLS_INDEPENDENCE_32_BIT_ONLY, 
    VK_SHADER_FLOAT_CONTROLS_INDEPENDENCE_ALL_KHR = VK_SHADER_FLOAT_CONTROLS_INDEPENDENCE_ALL, 
    VK_SHADER_FLOAT_CONTROLS_INDEPENDENCE_NONE_KHR = VK_SHADER_FLOAT_CONTROLS_INDEPENDENCE_NONE, 
    VK_SHADER_FLOAT_CONTROLS_INDEPENDENCE_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_2
[Flags] public enum VkSamplerReductionMode : uint   {
    VK_SAMPLER_REDUCTION_MODE_WEIGHTED_AVERAGE = 0, 
    VK_SAMPLER_REDUCTION_MODE_MIN = 1, 
    VK_SAMPLER_REDUCTION_MODE_MAX = 2, 
    VK_SAMPLER_REDUCTION_MODE_WEIGHTED_AVERAGE_RANGECLAMP_QCOM = 1000521000, 
    VK_SAMPLER_REDUCTION_MODE_WEIGHTED_AVERAGE_EXT = VK_SAMPLER_REDUCTION_MODE_WEIGHTED_AVERAGE, 
    VK_SAMPLER_REDUCTION_MODE_MIN_EXT = VK_SAMPLER_REDUCTION_MODE_MIN, 
    VK_SAMPLER_REDUCTION_MODE_MAX_EXT = VK_SAMPLER_REDUCTION_MODE_MAX, 
    VK_SAMPLER_REDUCTION_MODE_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_2
[Flags] public enum VkSemaphoreType : uint   {
    VK_SEMAPHORE_TYPE_BINARY = 0, 
    VK_SEMAPHORE_TYPE_TIMELINE = 1, 
    VK_SEMAPHORE_TYPE_BINARY_KHR = VK_SEMAPHORE_TYPE_BINARY, 
    VK_SEMAPHORE_TYPE_TIMELINE_KHR = VK_SEMAPHORE_TYPE_TIMELINE, 
    VK_SEMAPHORE_TYPE_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_2
[Flags] public enum VkResolveModeFlagBits : uint   {
    VK_RESOLVE_MODE_NONE = 0, 
    VK_RESOLVE_MODE_SAMPLE_ZERO_BIT = 0x00000001, 
    VK_RESOLVE_MODE_AVERAGE_BIT = 0x00000002, 
    VK_RESOLVE_MODE_MIN_BIT = 0x00000004, 
    VK_RESOLVE_MODE_MAX_BIT = 0x00000008, 
    VK_RESOLVE_MODE_EXTERNAL_FORMAT_DOWNSAMPLE_ANDROID = 0x00000010, 
    VK_RESOLVE_MODE_NONE_KHR = VK_RESOLVE_MODE_NONE, 
    VK_RESOLVE_MODE_SAMPLE_ZERO_BIT_KHR = VK_RESOLVE_MODE_SAMPLE_ZERO_BIT, 
    VK_RESOLVE_MODE_AVERAGE_BIT_KHR = VK_RESOLVE_MODE_AVERAGE_BIT, 
    VK_RESOLVE_MODE_MIN_BIT_KHR = VK_RESOLVE_MODE_MIN_BIT, 
    VK_RESOLVE_MODE_MAX_BIT_KHR = VK_RESOLVE_MODE_MAX_BIT, 
    VK_RESOLVE_MODE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_2
[Flags] public enum VkDescriptorBindingFlagBits : uint   {
    VK_DESCRIPTOR_BINDING_UPDATE_AFTER_BIND_BIT = 0x00000001, 
    VK_DESCRIPTOR_BINDING_UPDATE_UNUSED_WHILE_PENDING_BIT = 0x00000002, 
    VK_DESCRIPTOR_BINDING_PARTIALLY_BOUND_BIT = 0x00000004, 
    VK_DESCRIPTOR_BINDING_VARIABLE_DESCRIPTOR_COUNT_BIT = 0x00000008, 
    VK_DESCRIPTOR_BINDING_UPDATE_AFTER_BIND_BIT_EXT = VK_DESCRIPTOR_BINDING_UPDATE_AFTER_BIND_BIT, 
    VK_DESCRIPTOR_BINDING_UPDATE_UNUSED_WHILE_PENDING_BIT_EXT = VK_DESCRIPTOR_BINDING_UPDATE_UNUSED_WHILE_PENDING_BIT, 
    VK_DESCRIPTOR_BINDING_PARTIALLY_BOUND_BIT_EXT = VK_DESCRIPTOR_BINDING_PARTIALLY_BOUND_BIT, 
    VK_DESCRIPTOR_BINDING_VARIABLE_DESCRIPTOR_COUNT_BIT_EXT = VK_DESCRIPTOR_BINDING_VARIABLE_DESCRIPTOR_COUNT_BIT, 
    VK_DESCRIPTOR_BINDING_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_2
[Flags] public enum VkSemaphoreWaitFlagBits : uint   {
    VK_SEMAPHORE_WAIT_ANY_BIT = 0x00000001, 
    VK_SEMAPHORE_WAIT_ANY_BIT_KHR = VK_SEMAPHORE_WAIT_ANY_BIT, 
    VK_SEMAPHORE_WAIT_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_3
[Flags] public enum VkPipelineCreationFeedbackFlagBits : uint   {
    VK_PIPELINE_CREATION_FEEDBACK_VALID_BIT = 0x00000001, 
    VK_PIPELINE_CREATION_FEEDBACK_APPLICATION_PIPELINE_CACHE_HIT_BIT = 0x00000002, 
    VK_PIPELINE_CREATION_FEEDBACK_BASE_PIPELINE_ACCELERATION_BIT = 0x00000004, 
    VK_PIPELINE_CREATION_FEEDBACK_VALID_BIT_EXT = VK_PIPELINE_CREATION_FEEDBACK_VALID_BIT, 
    VK_PIPELINE_CREATION_FEEDBACK_APPLICATION_PIPELINE_CACHE_HIT_BIT_EXT = VK_PIPELINE_CREATION_FEEDBACK_APPLICATION_PIPELINE_CACHE_HIT_BIT, 
    VK_PIPELINE_CREATION_FEEDBACK_BASE_PIPELINE_ACCELERATION_BIT_EXT = VK_PIPELINE_CREATION_FEEDBACK_BASE_PIPELINE_ACCELERATION_BIT, 
    VK_PIPELINE_CREATION_FEEDBACK_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_3
[Flags] public enum VkToolPurposeFlagBits : uint   {
    VK_TOOL_PURPOSE_VALIDATION_BIT = 0x00000001, 
    VK_TOOL_PURPOSE_PROFILING_BIT = 0x00000002, 
    VK_TOOL_PURPOSE_TRACING_BIT = 0x00000004, 
    VK_TOOL_PURPOSE_ADDITIONAL_FEATURES_BIT = 0x00000008, 
    VK_TOOL_PURPOSE_MODIFYING_FEATURES_BIT = 0x00000010, 
    VK_TOOL_PURPOSE_DEBUG_REPORTING_BIT_EXT = 0x00000020, 
    VK_TOOL_PURPOSE_DEBUG_MARKERS_BIT_EXT = 0x00000040, 
    VK_TOOL_PURPOSE_VALIDATION_BIT_EXT = VK_TOOL_PURPOSE_VALIDATION_BIT, 
    VK_TOOL_PURPOSE_PROFILING_BIT_EXT = VK_TOOL_PURPOSE_PROFILING_BIT, 
    VK_TOOL_PURPOSE_TRACING_BIT_EXT = VK_TOOL_PURPOSE_TRACING_BIT, 
    VK_TOOL_PURPOSE_ADDITIONAL_FEATURES_BIT_EXT = VK_TOOL_PURPOSE_ADDITIONAL_FEATURES_BIT, 
    VK_TOOL_PURPOSE_MODIFYING_FEATURES_BIT_EXT = VK_TOOL_PURPOSE_MODIFYING_FEATURES_BIT, 
    VK_TOOL_PURPOSE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_3
[Flags] public enum VkSubmitFlagBits : uint   {
    VK_SUBMIT_PROTECTED_BIT = 0x00000001, 
    VK_SUBMIT_PROTECTED_BIT_KHR = VK_SUBMIT_PROTECTED_BIT, 
    VK_SUBMIT_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_3
[Flags] public enum VkRenderingFlagBits : uint   {
    VK_RENDERING_CONTENTS_SECONDARY_COMMAND_BUFFERS_BIT = 0x00000001, 
    VK_RENDERING_SUSPENDING_BIT = 0x00000002, 
    VK_RENDERING_RESUMING_BIT = 0x00000004, 
    VK_RENDERING_ENABLE_LEGACY_DITHERING_BIT_EXT = 0x00000008, 
    VK_RENDERING_CONTENTS_INLINE_BIT_KHR = 0x00000010, 
    VK_RENDERING_CONTENTS_SECONDARY_COMMAND_BUFFERS_BIT_KHR = VK_RENDERING_CONTENTS_SECONDARY_COMMAND_BUFFERS_BIT, 
    VK_RENDERING_SUSPENDING_BIT_KHR = VK_RENDERING_SUSPENDING_BIT, 
    VK_RENDERING_RESUMING_BIT_KHR = VK_RENDERING_RESUMING_BIT, 
    VK_RENDERING_CONTENTS_INLINE_BIT_EXT = VK_RENDERING_CONTENTS_INLINE_BIT_KHR, 
    VK_RENDERING_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_4
[Flags] public enum VkPipelineRobustnessBufferBehavior : uint   {
    VK_PIPELINE_ROBUSTNESS_BUFFER_BEHAVIOR_DEVICE_DEFAULT = 0, 
    VK_PIPELINE_ROBUSTNESS_BUFFER_BEHAVIOR_DISABLED = 1, 
    VK_PIPELINE_ROBUSTNESS_BUFFER_BEHAVIOR_ROBUST_BUFFER_ACCESS = 2, 
    VK_PIPELINE_ROBUSTNESS_BUFFER_BEHAVIOR_ROBUST_BUFFER_ACCESS_2 = 3, 
    VK_PIPELINE_ROBUSTNESS_BUFFER_BEHAVIOR_DEVICE_DEFAULT_EXT = VK_PIPELINE_ROBUSTNESS_BUFFER_BEHAVIOR_DEVICE_DEFAULT, 
    VK_PIPELINE_ROBUSTNESS_BUFFER_BEHAVIOR_DISABLED_EXT = VK_PIPELINE_ROBUSTNESS_BUFFER_BEHAVIOR_DISABLED, 
    VK_PIPELINE_ROBUSTNESS_BUFFER_BEHAVIOR_ROBUST_BUFFER_ACCESS_EXT = VK_PIPELINE_ROBUSTNESS_BUFFER_BEHAVIOR_ROBUST_BUFFER_ACCESS, 
    VK_PIPELINE_ROBUSTNESS_BUFFER_BEHAVIOR_ROBUST_BUFFER_ACCESS_2_EXT = VK_PIPELINE_ROBUSTNESS_BUFFER_BEHAVIOR_ROBUST_BUFFER_ACCESS_2, 
    VK_PIPELINE_ROBUSTNESS_BUFFER_BEHAVIOR_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_4
[Flags] public enum VkPipelineRobustnessImageBehavior : uint   {
    VK_PIPELINE_ROBUSTNESS_IMAGE_BEHAVIOR_DEVICE_DEFAULT = 0, 
    VK_PIPELINE_ROBUSTNESS_IMAGE_BEHAVIOR_DISABLED = 1, 
    VK_PIPELINE_ROBUSTNESS_IMAGE_BEHAVIOR_ROBUST_IMAGE_ACCESS = 2, 
    VK_PIPELINE_ROBUSTNESS_IMAGE_BEHAVIOR_ROBUST_IMAGE_ACCESS_2 = 3, 
    VK_PIPELINE_ROBUSTNESS_IMAGE_BEHAVIOR_DEVICE_DEFAULT_EXT = VK_PIPELINE_ROBUSTNESS_IMAGE_BEHAVIOR_DEVICE_DEFAULT, 
    VK_PIPELINE_ROBUSTNESS_IMAGE_BEHAVIOR_DISABLED_EXT = VK_PIPELINE_ROBUSTNESS_IMAGE_BEHAVIOR_DISABLED, 
    VK_PIPELINE_ROBUSTNESS_IMAGE_BEHAVIOR_ROBUST_IMAGE_ACCESS_EXT = VK_PIPELINE_ROBUSTNESS_IMAGE_BEHAVIOR_ROBUST_IMAGE_ACCESS, 
    VK_PIPELINE_ROBUSTNESS_IMAGE_BEHAVIOR_ROBUST_IMAGE_ACCESS_2_EXT = VK_PIPELINE_ROBUSTNESS_IMAGE_BEHAVIOR_ROBUST_IMAGE_ACCESS_2, 
    VK_PIPELINE_ROBUSTNESS_IMAGE_BEHAVIOR_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_4
[Flags] public enum VkQueueGlobalPriority : uint   {
    VK_QUEUE_GLOBAL_PRIORITY_LOW = 128, 
    VK_QUEUE_GLOBAL_PRIORITY_MEDIUM = 256, 
    VK_QUEUE_GLOBAL_PRIORITY_HIGH = 512, 
    VK_QUEUE_GLOBAL_PRIORITY_REALTIME = 1024, 
    VK_QUEUE_GLOBAL_PRIORITY_LOW_EXT = VK_QUEUE_GLOBAL_PRIORITY_LOW, 
    VK_QUEUE_GLOBAL_PRIORITY_MEDIUM_EXT = VK_QUEUE_GLOBAL_PRIORITY_MEDIUM, 
    VK_QUEUE_GLOBAL_PRIORITY_HIGH_EXT = VK_QUEUE_GLOBAL_PRIORITY_HIGH, 
    VK_QUEUE_GLOBAL_PRIORITY_REALTIME_EXT = VK_QUEUE_GLOBAL_PRIORITY_REALTIME, 
    VK_QUEUE_GLOBAL_PRIORITY_LOW_KHR = VK_QUEUE_GLOBAL_PRIORITY_LOW, 
    VK_QUEUE_GLOBAL_PRIORITY_MEDIUM_KHR = VK_QUEUE_GLOBAL_PRIORITY_MEDIUM, 
    VK_QUEUE_GLOBAL_PRIORITY_HIGH_KHR = VK_QUEUE_GLOBAL_PRIORITY_HIGH, 
    VK_QUEUE_GLOBAL_PRIORITY_REALTIME_KHR = VK_QUEUE_GLOBAL_PRIORITY_REALTIME, 
    VK_QUEUE_GLOBAL_PRIORITY_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_4
[Flags] public enum VkLineRasterizationMode : uint   {
    VK_LINE_RASTERIZATION_MODE_DEFAULT = 0, 
    VK_LINE_RASTERIZATION_MODE_RECTANGULAR = 1, 
    VK_LINE_RASTERIZATION_MODE_BRESENHAM = 2, 
    VK_LINE_RASTERIZATION_MODE_RECTANGULAR_SMOOTH = 3, 
    VK_LINE_RASTERIZATION_MODE_DEFAULT_EXT = VK_LINE_RASTERIZATION_MODE_DEFAULT, 
    VK_LINE_RASTERIZATION_MODE_RECTANGULAR_EXT = VK_LINE_RASTERIZATION_MODE_RECTANGULAR, 
    VK_LINE_RASTERIZATION_MODE_BRESENHAM_EXT = VK_LINE_RASTERIZATION_MODE_BRESENHAM, 
    VK_LINE_RASTERIZATION_MODE_RECTANGULAR_SMOOTH_EXT = VK_LINE_RASTERIZATION_MODE_RECTANGULAR_SMOOTH, 
    VK_LINE_RASTERIZATION_MODE_DEFAULT_KHR = VK_LINE_RASTERIZATION_MODE_DEFAULT, 
    VK_LINE_RASTERIZATION_MODE_RECTANGULAR_KHR = VK_LINE_RASTERIZATION_MODE_RECTANGULAR, 
    VK_LINE_RASTERIZATION_MODE_BRESENHAM_KHR = VK_LINE_RASTERIZATION_MODE_BRESENHAM, 
    VK_LINE_RASTERIZATION_MODE_RECTANGULAR_SMOOTH_KHR = VK_LINE_RASTERIZATION_MODE_RECTANGULAR_SMOOTH, 
    VK_LINE_RASTERIZATION_MODE_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_4
[Flags] public enum VkMemoryUnmapFlagBits : uint   {
    VK_MEMORY_UNMAP_RESERVE_BIT_EXT = 0x00000001, 
    VK_MEMORY_UNMAP_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};
// VK_VERSION_1_4
[Flags] public enum VkHostImageCopyFlagBits : uint   {
    VK_HOST_IMAGE_COPY_MEMCPY = 0x00000001, 
    VK_HOST_IMAGE_COPY_MEMCPY_EXT = VK_HOST_IMAGE_COPY_MEMCPY, 
    VK_HOST_IMAGE_COPY_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF 
};
// VK_KHR_surface
[Flags] public enum VkPresentModeKHR : uint   {
    VK_PRESENT_MODE_IMMEDIATE_KHR = 0, 
    VK_PRESENT_MODE_MAILBOX_KHR = 1, 
    VK_PRESENT_MODE_FIFO_KHR = 2, 
    VK_PRESENT_MODE_FIFO_RELAXED_KHR = 3, 
    VK_PRESENT_MODE_SHARED_DEMAND_REFRESH_KHR = 1000111000, 
    VK_PRESENT_MODE_SHARED_CONTINUOUS_REFRESH_KHR = 1000111001, 
    VK_PRESENT_MODE_FIFO_LATEST_READY_EXT = 1000361000, 
    VK_PRESENT_MODE_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_surface
[Flags] public enum VkColorSpaceKHR : uint   {
    VK_COLOR_SPACE_SRGB_NONLINEAR_KHR = 0, 
    VK_COLOR_SPACE_DISPLAY_P3_NONLINEAR_EXT = 1000104001, 
    VK_COLOR_SPACE_EXTENDED_SRGB_LINEAR_EXT = 1000104002, 
    VK_COLOR_SPACE_DISPLAY_P3_LINEAR_EXT = 1000104003, 
    VK_COLOR_SPACE_DCI_P3_NONLINEAR_EXT = 1000104004, 
    VK_COLOR_SPACE_BT709_LINEAR_EXT = 1000104005, 
    VK_COLOR_SPACE_BT709_NONLINEAR_EXT = 1000104006, 
    VK_COLOR_SPACE_BT2020_LINEAR_EXT = 1000104007, 
    VK_COLOR_SPACE_HDR10_ST2084_EXT = 1000104008, 
  // VK_COLOR_SPACE_DOLBYVISION_EXT is deprecated, but no reason was given in the API XML 
    VK_COLOR_SPACE_DOLBYVISION_EXT = 1000104009, 
    VK_COLOR_SPACE_HDR10_HLG_EXT = 1000104010, 
    VK_COLOR_SPACE_ADOBERGB_LINEAR_EXT = 1000104011, 
    VK_COLOR_SPACE_ADOBERGB_NONLINEAR_EXT = 1000104012, 
    VK_COLOR_SPACE_PASS_THROUGH_EXT = 1000104013, 
    VK_COLOR_SPACE_EXTENDED_SRGB_NONLINEAR_EXT = 1000104014, 
    VK_COLOR_SPACE_DISPLAY_NATIVE_AMD = 1000213000, 
  // VK_COLORSPACE_SRGB_NONLINEAR_KHR is a deprecated alias 
    VK_COLORSPACE_SRGB_NONLINEAR_KHR = VK_COLOR_SPACE_SRGB_NONLINEAR_KHR, 
  // VK_COLOR_SPACE_DCI_P3_LINEAR_EXT is a deprecated alias 
    VK_COLOR_SPACE_DCI_P3_LINEAR_EXT = VK_COLOR_SPACE_DISPLAY_P3_LINEAR_EXT, 
    VK_COLOR_SPACE_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_surface
[Flags] public enum VkSurfaceTransformFlagBitsKHR : uint   {
    VK_SURFACE_TRANSFORM_IDENTITY_BIT_KHR = 0x00000001, 
    VK_SURFACE_TRANSFORM_ROTATE_90_BIT_KHR = 0x00000002, 
    VK_SURFACE_TRANSFORM_ROTATE_180_BIT_KHR = 0x00000004, 
    VK_SURFACE_TRANSFORM_ROTATE_270_BIT_KHR = 0x00000008, 
    VK_SURFACE_TRANSFORM_HORIZONTAL_MIRROR_BIT_KHR = 0x00000010, 
    VK_SURFACE_TRANSFORM_HORIZONTAL_MIRROR_ROTATE_90_BIT_KHR = 0x00000020, 
    VK_SURFACE_TRANSFORM_HORIZONTAL_MIRROR_ROTATE_180_BIT_KHR = 0x00000040, 
    VK_SURFACE_TRANSFORM_HORIZONTAL_MIRROR_ROTATE_270_BIT_KHR = 0x00000080, 
    VK_SURFACE_TRANSFORM_INHERIT_BIT_KHR = 0x00000100, 
    VK_SURFACE_TRANSFORM_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_surface
[Flags] public enum VkCompositeAlphaFlagBitsKHR : uint   {
    VK_COMPOSITE_ALPHA_OPAQUE_BIT_KHR = 0x00000001, 
    VK_COMPOSITE_ALPHA_PRE_MULTIPLIED_BIT_KHR = 0x00000002, 
    VK_COMPOSITE_ALPHA_POST_MULTIPLIED_BIT_KHR = 0x00000004, 
    VK_COMPOSITE_ALPHA_INHERIT_BIT_KHR = 0x00000008, 
    VK_COMPOSITE_ALPHA_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_swapchain
[Flags] public enum VkSwapchainCreateFlagBitsKHR : uint   {
    VK_SWAPCHAIN_CREATE_SPLIT_INSTANCE_BIND_REGIONS_BIT_KHR = 0x00000001, 
    VK_SWAPCHAIN_CREATE_PROTECTED_BIT_KHR = 0x00000002, 
    VK_SWAPCHAIN_CREATE_MUTABLE_FORMAT_BIT_KHR = 0x00000004, 
    VK_SWAPCHAIN_CREATE_DEFERRED_MEMORY_ALLOCATION_BIT_EXT = 0x00000008, 
    VK_SWAPCHAIN_CREATE_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_swapchain
[Flags] public enum VkDeviceGroupPresentModeFlagBitsKHR : uint   {
    VK_DEVICE_GROUP_PRESENT_MODE_LOCAL_BIT_KHR = 0x00000001, 
    VK_DEVICE_GROUP_PRESENT_MODE_REMOTE_BIT_KHR = 0x00000002, 
    VK_DEVICE_GROUP_PRESENT_MODE_SUM_BIT_KHR = 0x00000004, 
    VK_DEVICE_GROUP_PRESENT_MODE_LOCAL_MULTI_DEVICE_BIT_KHR = 0x00000008, 
    VK_DEVICE_GROUP_PRESENT_MODE_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_display
[Flags] public enum VkDisplayPlaneAlphaFlagBitsKHR : uint   {
    VK_DISPLAY_PLANE_ALPHA_OPAQUE_BIT_KHR = 0x00000001, 
    VK_DISPLAY_PLANE_ALPHA_GLOBAL_BIT_KHR = 0x00000002, 
    VK_DISPLAY_PLANE_ALPHA_PER_PIXEL_BIT_KHR = 0x00000004, 
    VK_DISPLAY_PLANE_ALPHA_PER_PIXEL_PREMULTIPLIED_BIT_KHR = 0x00000008, 
    VK_DISPLAY_PLANE_ALPHA_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_queue
 public enum VkQueryResultStatusKHR    {
    VK_QUERY_RESULT_STATUS_ERROR_KHR = -1, 
    VK_QUERY_RESULT_STATUS_NOT_READY_KHR = 0, 
    VK_QUERY_RESULT_STATUS_COMPLETE_KHR = 1, 
    VK_QUERY_RESULT_STATUS_INSUFFICIENT_BITSTREAM_BUFFER_RANGE_KHR = -1000299000, 
    VK_QUERY_RESULT_STATUS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_queue
[Flags] public enum VkVideoCodecOperationFlagBitsKHR : uint   {
    VK_VIDEO_CODEC_OPERATION_NONE_KHR = 0, 
    VK_VIDEO_CODEC_OPERATION_ENCODE_H264_BIT_KHR = 0x00010000, 
    VK_VIDEO_CODEC_OPERATION_ENCODE_H265_BIT_KHR = 0x00020000, 
    VK_VIDEO_CODEC_OPERATION_DECODE_H264_BIT_KHR = 0x00000001, 
    VK_VIDEO_CODEC_OPERATION_DECODE_H265_BIT_KHR = 0x00000002, 
    VK_VIDEO_CODEC_OPERATION_DECODE_AV1_BIT_KHR = 0x00000004, 
    VK_VIDEO_CODEC_OPERATION_ENCODE_AV1_BIT_KHR = 0x00040000, 
    VK_VIDEO_CODEC_OPERATION_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_queue
[Flags] public enum VkVideoChromaSubsamplingFlagBitsKHR : uint   {
    VK_VIDEO_CHROMA_SUBSAMPLING_INVALID_KHR = 0, 
    VK_VIDEO_CHROMA_SUBSAMPLING_MONOCHROME_BIT_KHR = 0x00000001, 
    VK_VIDEO_CHROMA_SUBSAMPLING_420_BIT_KHR = 0x00000002, 
    VK_VIDEO_CHROMA_SUBSAMPLING_422_BIT_KHR = 0x00000004, 
    VK_VIDEO_CHROMA_SUBSAMPLING_444_BIT_KHR = 0x00000008, 
    VK_VIDEO_CHROMA_SUBSAMPLING_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_queue
[Flags] public enum VkVideoComponentBitDepthFlagBitsKHR : uint   {
    VK_VIDEO_COMPONENT_BIT_DEPTH_INVALID_KHR = 0, 
    VK_VIDEO_COMPONENT_BIT_DEPTH_8_BIT_KHR = 0x00000001, 
    VK_VIDEO_COMPONENT_BIT_DEPTH_10_BIT_KHR = 0x00000004, 
    VK_VIDEO_COMPONENT_BIT_DEPTH_12_BIT_KHR = 0x00000010, 
    VK_VIDEO_COMPONENT_BIT_DEPTH_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_queue
[Flags] public enum VkVideoCapabilityFlagBitsKHR : uint   {
    VK_VIDEO_CAPABILITY_PROTECTED_CONTENT_BIT_KHR = 0x00000001, 
    VK_VIDEO_CAPABILITY_SEPARATE_REFERENCE_IMAGES_BIT_KHR = 0x00000002, 
    VK_VIDEO_CAPABILITY_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_queue
[Flags] public enum VkVideoSessionCreateFlagBitsKHR : uint   {
    VK_VIDEO_SESSION_CREATE_PROTECTED_CONTENT_BIT_KHR = 0x00000001, 
    VK_VIDEO_SESSION_CREATE_ALLOW_ENCODE_PARAMETER_OPTIMIZATIONS_BIT_KHR = 0x00000002, 
    VK_VIDEO_SESSION_CREATE_INLINE_QUERIES_BIT_KHR = 0x00000004, 
    VK_VIDEO_SESSION_CREATE_ALLOW_ENCODE_QUANTIZATION_DELTA_MAP_BIT_KHR = 0x00000008, 
    VK_VIDEO_SESSION_CREATE_ALLOW_ENCODE_EMPHASIS_MAP_BIT_KHR = 0x00000010, 
    VK_VIDEO_SESSION_CREATE_INLINE_SESSION_PARAMETERS_BIT_KHR = 0x00000020, 
    VK_VIDEO_SESSION_CREATE_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_queue
[Flags] public enum VkVideoSessionParametersCreateFlagBitsKHR : uint   {
    VK_VIDEO_SESSION_PARAMETERS_CREATE_QUANTIZATION_MAP_COMPATIBLE_BIT_KHR = 0x00000001, 
    VK_VIDEO_SESSION_PARAMETERS_CREATE_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_queue
[Flags] public enum VkVideoCodingControlFlagBitsKHR : uint   {
    VK_VIDEO_CODING_CONTROL_RESET_BIT_KHR = 0x00000001, 
    VK_VIDEO_CODING_CONTROL_ENCODE_RATE_CONTROL_BIT_KHR = 0x00000002, 
    VK_VIDEO_CODING_CONTROL_ENCODE_QUALITY_LEVEL_BIT_KHR = 0x00000004, 
    VK_VIDEO_CODING_CONTROL_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_decode_queue
[Flags] public enum VkVideoDecodeCapabilityFlagBitsKHR : uint   {
    VK_VIDEO_DECODE_CAPABILITY_DPB_AND_OUTPUT_COINCIDE_BIT_KHR = 0x00000001, 
    VK_VIDEO_DECODE_CAPABILITY_DPB_AND_OUTPUT_DISTINCT_BIT_KHR = 0x00000002, 
    VK_VIDEO_DECODE_CAPABILITY_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_decode_queue
[Flags] public enum VkVideoDecodeUsageFlagBitsKHR : uint   {
    VK_VIDEO_DECODE_USAGE_DEFAULT_KHR = 0, 
    VK_VIDEO_DECODE_USAGE_TRANSCODING_BIT_KHR = 0x00000001, 
    VK_VIDEO_DECODE_USAGE_OFFLINE_BIT_KHR = 0x00000002, 
    VK_VIDEO_DECODE_USAGE_STREAMING_BIT_KHR = 0x00000004, 
    VK_VIDEO_DECODE_USAGE_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_h264
[Flags] public enum VkVideoEncodeH264CapabilityFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_H264_CAPABILITY_HRD_COMPLIANCE_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_H264_CAPABILITY_PREDICTION_WEIGHT_TABLE_GENERATED_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_H264_CAPABILITY_ROW_UNALIGNED_SLICE_BIT_KHR = 0x00000004, 
    VK_VIDEO_ENCODE_H264_CAPABILITY_DIFFERENT_SLICE_TYPE_BIT_KHR = 0x00000008, 
    VK_VIDEO_ENCODE_H264_CAPABILITY_B_FRAME_IN_L0_LIST_BIT_KHR = 0x00000010, 
    VK_VIDEO_ENCODE_H264_CAPABILITY_B_FRAME_IN_L1_LIST_BIT_KHR = 0x00000020, 
    VK_VIDEO_ENCODE_H264_CAPABILITY_PER_PICTURE_TYPE_MIN_MAX_QP_BIT_KHR = 0x00000040, 
    VK_VIDEO_ENCODE_H264_CAPABILITY_PER_SLICE_CONSTANT_QP_BIT_KHR = 0x00000080, 
    VK_VIDEO_ENCODE_H264_CAPABILITY_GENERATE_PREFIX_NALU_BIT_KHR = 0x00000100, 
    VK_VIDEO_ENCODE_H264_CAPABILITY_MB_QP_DIFF_WRAPAROUND_BIT_KHR = 0x00000200, 
    VK_VIDEO_ENCODE_H264_CAPABILITY_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_h264
[Flags] public enum VkVideoEncodeH264StdFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_H264_STD_SEPARATE_COLOR_PLANE_FLAG_SET_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_H264_STD_QPPRIME_Y_ZERO_TRANSFORM_BYPASS_FLAG_SET_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_H264_STD_SCALING_MATRIX_PRESENT_FLAG_SET_BIT_KHR = 0x00000004, 
    VK_VIDEO_ENCODE_H264_STD_CHROMA_QP_INDEX_OFFSET_BIT_KHR = 0x00000008, 
    VK_VIDEO_ENCODE_H264_STD_SECOND_CHROMA_QP_INDEX_OFFSET_BIT_KHR = 0x00000010, 
    VK_VIDEO_ENCODE_H264_STD_PIC_INIT_QP_MINUS26_BIT_KHR = 0x00000020, 
    VK_VIDEO_ENCODE_H264_STD_WEIGHTED_PRED_FLAG_SET_BIT_KHR = 0x00000040, 
    VK_VIDEO_ENCODE_H264_STD_WEIGHTED_BIPRED_IDC_EXPLICIT_BIT_KHR = 0x00000080, 
    VK_VIDEO_ENCODE_H264_STD_WEIGHTED_BIPRED_IDC_IMPLICIT_BIT_KHR = 0x00000100, 
    VK_VIDEO_ENCODE_H264_STD_TRANSFORM_8X8_MODE_FLAG_SET_BIT_KHR = 0x00000200, 
    VK_VIDEO_ENCODE_H264_STD_DIRECT_SPATIAL_MV_PRED_FLAG_UNSET_BIT_KHR = 0x00000400, 
    VK_VIDEO_ENCODE_H264_STD_ENTROPY_CODING_MODE_FLAG_UNSET_BIT_KHR = 0x00000800, 
    VK_VIDEO_ENCODE_H264_STD_ENTROPY_CODING_MODE_FLAG_SET_BIT_KHR = 0x00001000, 
    VK_VIDEO_ENCODE_H264_STD_DIRECT_8X8_INFERENCE_FLAG_UNSET_BIT_KHR = 0x00002000, 
    VK_VIDEO_ENCODE_H264_STD_CONSTRAINED_INTRA_PRED_FLAG_SET_BIT_KHR = 0x00004000, 
    VK_VIDEO_ENCODE_H264_STD_DEBLOCKING_FILTER_DISABLED_BIT_KHR = 0x00008000, 
    VK_VIDEO_ENCODE_H264_STD_DEBLOCKING_FILTER_ENABLED_BIT_KHR = 0x00010000, 
    VK_VIDEO_ENCODE_H264_STD_DEBLOCKING_FILTER_PARTIAL_BIT_KHR = 0x00020000, 
    VK_VIDEO_ENCODE_H264_STD_SLICE_QP_DELTA_BIT_KHR = 0x00080000, 
    VK_VIDEO_ENCODE_H264_STD_DIFFERENT_SLICE_QP_DELTA_BIT_KHR = 0x00100000, 
    VK_VIDEO_ENCODE_H264_STD_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_h264
[Flags] public enum VkVideoEncodeH264RateControlFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_H264_RATE_CONTROL_ATTEMPT_HRD_COMPLIANCE_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_H264_RATE_CONTROL_REGULAR_GOP_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_H264_RATE_CONTROL_REFERENCE_PATTERN_FLAT_BIT_KHR = 0x00000004, 
    VK_VIDEO_ENCODE_H264_RATE_CONTROL_REFERENCE_PATTERN_DYADIC_BIT_KHR = 0x00000008, 
    VK_VIDEO_ENCODE_H264_RATE_CONTROL_TEMPORAL_LAYER_PATTERN_DYADIC_BIT_KHR = 0x00000010, 
    VK_VIDEO_ENCODE_H264_RATE_CONTROL_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_h265
[Flags] public enum VkVideoEncodeH265CapabilityFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_H265_CAPABILITY_HRD_COMPLIANCE_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_H265_CAPABILITY_PREDICTION_WEIGHT_TABLE_GENERATED_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_H265_CAPABILITY_ROW_UNALIGNED_SLICE_SEGMENT_BIT_KHR = 0x00000004, 
    VK_VIDEO_ENCODE_H265_CAPABILITY_DIFFERENT_SLICE_SEGMENT_TYPE_BIT_KHR = 0x00000008, 
    VK_VIDEO_ENCODE_H265_CAPABILITY_B_FRAME_IN_L0_LIST_BIT_KHR = 0x00000010, 
    VK_VIDEO_ENCODE_H265_CAPABILITY_B_FRAME_IN_L1_LIST_BIT_KHR = 0x00000020, 
    VK_VIDEO_ENCODE_H265_CAPABILITY_PER_PICTURE_TYPE_MIN_MAX_QP_BIT_KHR = 0x00000040, 
    VK_VIDEO_ENCODE_H265_CAPABILITY_PER_SLICE_SEGMENT_CONSTANT_QP_BIT_KHR = 0x00000080, 
    VK_VIDEO_ENCODE_H265_CAPABILITY_MULTIPLE_TILES_PER_SLICE_SEGMENT_BIT_KHR = 0x00000100, 
    VK_VIDEO_ENCODE_H265_CAPABILITY_MULTIPLE_SLICE_SEGMENTS_PER_TILE_BIT_KHR = 0x00000200, 
    VK_VIDEO_ENCODE_H265_CAPABILITY_CU_QP_DIFF_WRAPAROUND_BIT_KHR = 0x00000400, 
    VK_VIDEO_ENCODE_H265_CAPABILITY_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_h265
[Flags] public enum VkVideoEncodeH265StdFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_H265_STD_SEPARATE_COLOR_PLANE_FLAG_SET_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_H265_STD_SAMPLE_ADAPTIVE_OFFSET_ENABLED_FLAG_SET_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_H265_STD_SCALING_LIST_DATA_PRESENT_FLAG_SET_BIT_KHR = 0x00000004, 
    VK_VIDEO_ENCODE_H265_STD_PCM_ENABLED_FLAG_SET_BIT_KHR = 0x00000008, 
    VK_VIDEO_ENCODE_H265_STD_SPS_TEMPORAL_MVP_ENABLED_FLAG_SET_BIT_KHR = 0x00000010, 
    VK_VIDEO_ENCODE_H265_STD_INIT_QP_MINUS26_BIT_KHR = 0x00000020, 
    VK_VIDEO_ENCODE_H265_STD_WEIGHTED_PRED_FLAG_SET_BIT_KHR = 0x00000040, 
    VK_VIDEO_ENCODE_H265_STD_WEIGHTED_BIPRED_FLAG_SET_BIT_KHR = 0x00000080, 
    VK_VIDEO_ENCODE_H265_STD_LOG2_PARALLEL_MERGE_LEVEL_MINUS2_BIT_KHR = 0x00000100, 
    VK_VIDEO_ENCODE_H265_STD_SIGN_DATA_HIDING_ENABLED_FLAG_SET_BIT_KHR = 0x00000200, 
    VK_VIDEO_ENCODE_H265_STD_TRANSFORM_SKIP_ENABLED_FLAG_SET_BIT_KHR = 0x00000400, 
    VK_VIDEO_ENCODE_H265_STD_TRANSFORM_SKIP_ENABLED_FLAG_UNSET_BIT_KHR = 0x00000800, 
    VK_VIDEO_ENCODE_H265_STD_PPS_SLICE_CHROMA_QP_OFFSETS_PRESENT_FLAG_SET_BIT_KHR = 0x00001000, 
    VK_VIDEO_ENCODE_H265_STD_TRANSQUANT_BYPASS_ENABLED_FLAG_SET_BIT_KHR = 0x00002000, 
    VK_VIDEO_ENCODE_H265_STD_CONSTRAINED_INTRA_PRED_FLAG_SET_BIT_KHR = 0x00004000, 
    VK_VIDEO_ENCODE_H265_STD_ENTROPY_CODING_SYNC_ENABLED_FLAG_SET_BIT_KHR = 0x00008000, 
    VK_VIDEO_ENCODE_H265_STD_DEBLOCKING_FILTER_OVERRIDE_ENABLED_FLAG_SET_BIT_KHR = 0x00010000, 
    VK_VIDEO_ENCODE_H265_STD_DEPENDENT_SLICE_SEGMENTS_ENABLED_FLAG_SET_BIT_KHR = 0x00020000, 
    VK_VIDEO_ENCODE_H265_STD_DEPENDENT_SLICE_SEGMENT_FLAG_SET_BIT_KHR = 0x00040000, 
    VK_VIDEO_ENCODE_H265_STD_SLICE_QP_DELTA_BIT_KHR = 0x00080000, 
    VK_VIDEO_ENCODE_H265_STD_DIFFERENT_SLICE_QP_DELTA_BIT_KHR = 0x00100000, 
    VK_VIDEO_ENCODE_H265_STD_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_h265
[Flags] public enum VkVideoEncodeH265CtbSizeFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_H265_CTB_SIZE_16_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_H265_CTB_SIZE_32_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_H265_CTB_SIZE_64_BIT_KHR = 0x00000004, 
    VK_VIDEO_ENCODE_H265_CTB_SIZE_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_h265
[Flags] public enum VkVideoEncodeH265TransformBlockSizeFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_H265_TRANSFORM_BLOCK_SIZE_4_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_H265_TRANSFORM_BLOCK_SIZE_8_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_H265_TRANSFORM_BLOCK_SIZE_16_BIT_KHR = 0x00000004, 
    VK_VIDEO_ENCODE_H265_TRANSFORM_BLOCK_SIZE_32_BIT_KHR = 0x00000008, 
    VK_VIDEO_ENCODE_H265_TRANSFORM_BLOCK_SIZE_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_h265
[Flags] public enum VkVideoEncodeH265RateControlFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_H265_RATE_CONTROL_ATTEMPT_HRD_COMPLIANCE_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_H265_RATE_CONTROL_REGULAR_GOP_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_H265_RATE_CONTROL_REFERENCE_PATTERN_FLAT_BIT_KHR = 0x00000004, 
    VK_VIDEO_ENCODE_H265_RATE_CONTROL_REFERENCE_PATTERN_DYADIC_BIT_KHR = 0x00000008, 
    VK_VIDEO_ENCODE_H265_RATE_CONTROL_TEMPORAL_SUB_LAYER_PATTERN_DYADIC_BIT_KHR = 0x00000010, 
    VK_VIDEO_ENCODE_H265_RATE_CONTROL_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_decode_h264
[Flags] public enum VkVideoDecodeH264PictureLayoutFlagBitsKHR : uint   {
    VK_VIDEO_DECODE_H264_PICTURE_LAYOUT_PROGRESSIVE_KHR = 0, 
    VK_VIDEO_DECODE_H264_PICTURE_LAYOUT_INTERLACED_INTERLEAVED_LINES_BIT_KHR = 0x00000001, 
    VK_VIDEO_DECODE_H264_PICTURE_LAYOUT_INTERLACED_SEPARATE_PLANES_BIT_KHR = 0x00000002, 
    VK_VIDEO_DECODE_H264_PICTURE_LAYOUT_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_performance_query
[Flags] public enum VkPerformanceCounterUnitKHR : uint   {
    VK_PERFORMANCE_COUNTER_UNIT_GENERIC_KHR = 0, 
    VK_PERFORMANCE_COUNTER_UNIT_PERCENTAGE_KHR = 1, 
    VK_PERFORMANCE_COUNTER_UNIT_NANOSECONDS_KHR = 2, 
    VK_PERFORMANCE_COUNTER_UNIT_BYTES_KHR = 3, 
    VK_PERFORMANCE_COUNTER_UNIT_BYTES_PER_SECOND_KHR = 4, 
    VK_PERFORMANCE_COUNTER_UNIT_KELVIN_KHR = 5, 
    VK_PERFORMANCE_COUNTER_UNIT_WATTS_KHR = 6, 
    VK_PERFORMANCE_COUNTER_UNIT_VOLTS_KHR = 7, 
    VK_PERFORMANCE_COUNTER_UNIT_AMPS_KHR = 8, 
    VK_PERFORMANCE_COUNTER_UNIT_HERTZ_KHR = 9, 
    VK_PERFORMANCE_COUNTER_UNIT_CYCLES_KHR = 10, 
    VK_PERFORMANCE_COUNTER_UNIT_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_performance_query
[Flags] public enum VkPerformanceCounterScopeKHR : uint   {
    VK_PERFORMANCE_COUNTER_SCOPE_COMMAND_BUFFER_KHR = 0, 
    VK_PERFORMANCE_COUNTER_SCOPE_RENDER_PASS_KHR = 1, 
    VK_PERFORMANCE_COUNTER_SCOPE_COMMAND_KHR = 2, 
  // VK_QUERY_SCOPE_COMMAND_BUFFER_KHR is a deprecated alias 
    VK_QUERY_SCOPE_COMMAND_BUFFER_KHR = VK_PERFORMANCE_COUNTER_SCOPE_COMMAND_BUFFER_KHR, 
  // VK_QUERY_SCOPE_RENDER_PASS_KHR is a deprecated alias 
    VK_QUERY_SCOPE_RENDER_PASS_KHR = VK_PERFORMANCE_COUNTER_SCOPE_RENDER_PASS_KHR, 
  // VK_QUERY_SCOPE_COMMAND_KHR is a deprecated alias 
    VK_QUERY_SCOPE_COMMAND_KHR = VK_PERFORMANCE_COUNTER_SCOPE_COMMAND_KHR, 
    VK_PERFORMANCE_COUNTER_SCOPE_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_performance_query
[Flags] public enum VkPerformanceCounterStorageKHR : uint   {
    VK_PERFORMANCE_COUNTER_STORAGE_INT32_KHR = 0, 
    VK_PERFORMANCE_COUNTER_STORAGE_INT64_KHR = 1, 
    VK_PERFORMANCE_COUNTER_STORAGE_UINT32_KHR = 2, 
    VK_PERFORMANCE_COUNTER_STORAGE_UINT64_KHR = 3, 
    VK_PERFORMANCE_COUNTER_STORAGE_FLOAT32_KHR = 4, 
    VK_PERFORMANCE_COUNTER_STORAGE_FLOAT64_KHR = 5, 
    VK_PERFORMANCE_COUNTER_STORAGE_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_performance_query
[Flags] public enum VkPerformanceCounterDescriptionFlagBitsKHR : uint   {
    VK_PERFORMANCE_COUNTER_DESCRIPTION_PERFORMANCE_IMPACTING_BIT_KHR = 0x00000001, 
    VK_PERFORMANCE_COUNTER_DESCRIPTION_CONCURRENTLY_IMPACTED_BIT_KHR = 0x00000002, 
  // VK_PERFORMANCE_COUNTER_DESCRIPTION_PERFORMANCE_IMPACTING_KHR is a deprecated alias 
    VK_PERFORMANCE_COUNTER_DESCRIPTION_PERFORMANCE_IMPACTING_KHR = VK_PERFORMANCE_COUNTER_DESCRIPTION_PERFORMANCE_IMPACTING_BIT_KHR, 
  // VK_PERFORMANCE_COUNTER_DESCRIPTION_CONCURRENTLY_IMPACTED_KHR is a deprecated alias 
    VK_PERFORMANCE_COUNTER_DESCRIPTION_CONCURRENTLY_IMPACTED_KHR = VK_PERFORMANCE_COUNTER_DESCRIPTION_CONCURRENTLY_IMPACTED_BIT_KHR, 
    VK_PERFORMANCE_COUNTER_DESCRIPTION_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_performance_query
[Flags] public enum VkAcquireProfilingLockFlagBitsKHR : uint   {
    VK_ACQUIRE_PROFILING_LOCK_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_fragment_shading_rate
[Flags] public enum VkFragmentShadingRateCombinerOpKHR : uint   {
    VK_FRAGMENT_SHADING_RATE_COMBINER_OP_KEEP_KHR = 0, 
    VK_FRAGMENT_SHADING_RATE_COMBINER_OP_REPLACE_KHR = 1, 
    VK_FRAGMENT_SHADING_RATE_COMBINER_OP_MIN_KHR = 2, 
    VK_FRAGMENT_SHADING_RATE_COMBINER_OP_MAX_KHR = 3, 
    VK_FRAGMENT_SHADING_RATE_COMBINER_OP_MUL_KHR = 4, 
    VK_FRAGMENT_SHADING_RATE_COMBINER_OP_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_pipeline_executable_properties
[Flags] public enum VkPipelineExecutableStatisticFormatKHR : uint   {
    VK_PIPELINE_EXECUTABLE_STATISTIC_FORMAT_BOOL32_KHR = 0, 
    VK_PIPELINE_EXECUTABLE_STATISTIC_FORMAT_INT64_KHR = 1, 
    VK_PIPELINE_EXECUTABLE_STATISTIC_FORMAT_UINT64_KHR = 2, 
    VK_PIPELINE_EXECUTABLE_STATISTIC_FORMAT_FLOAT64_KHR = 3, 
    VK_PIPELINE_EXECUTABLE_STATISTIC_FORMAT_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_queue
[Flags] public enum VkVideoEncodeTuningModeKHR : uint   {
    VK_VIDEO_ENCODE_TUNING_MODE_DEFAULT_KHR = 0, 
    VK_VIDEO_ENCODE_TUNING_MODE_HIGH_QUALITY_KHR = 1, 
    VK_VIDEO_ENCODE_TUNING_MODE_LOW_LATENCY_KHR = 2, 
    VK_VIDEO_ENCODE_TUNING_MODE_ULTRA_LOW_LATENCY_KHR = 3, 
    VK_VIDEO_ENCODE_TUNING_MODE_LOSSLESS_KHR = 4, 
    VK_VIDEO_ENCODE_TUNING_MODE_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_queue
[Flags] public enum VkVideoEncodeFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_WITH_QUANTIZATION_DELTA_MAP_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_WITH_EMPHASIS_MAP_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_queue
[Flags] public enum VkVideoEncodeCapabilityFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_CAPABILITY_PRECEDING_EXTERNALLY_ENCODED_BYTES_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_CAPABILITY_INSUFFICIENT_BITSTREAM_BUFFER_RANGE_DETECTION_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_CAPABILITY_QUANTIZATION_DELTA_MAP_BIT_KHR = 0x00000004, 
    VK_VIDEO_ENCODE_CAPABILITY_EMPHASIS_MAP_BIT_KHR = 0x00000008, 
    VK_VIDEO_ENCODE_CAPABILITY_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_queue
[Flags] public enum VkVideoEncodeRateControlModeFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_RATE_CONTROL_MODE_DEFAULT_KHR = 0, 
    VK_VIDEO_ENCODE_RATE_CONTROL_MODE_DISABLED_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_RATE_CONTROL_MODE_CBR_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_RATE_CONTROL_MODE_VBR_BIT_KHR = 0x00000004, 
    VK_VIDEO_ENCODE_RATE_CONTROL_MODE_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_queue
[Flags] public enum VkVideoEncodeFeedbackFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_FEEDBACK_BITSTREAM_BUFFER_OFFSET_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_FEEDBACK_BITSTREAM_BYTES_WRITTEN_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_FEEDBACK_BITSTREAM_HAS_OVERRIDES_BIT_KHR = 0x00000004, 
    VK_VIDEO_ENCODE_FEEDBACK_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_queue
[Flags] public enum VkVideoEncodeUsageFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_USAGE_DEFAULT_KHR = 0, 
    VK_VIDEO_ENCODE_USAGE_TRANSCODING_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_USAGE_STREAMING_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_USAGE_RECORDING_BIT_KHR = 0x00000004, 
    VK_VIDEO_ENCODE_USAGE_CONFERENCING_BIT_KHR = 0x00000008, 
    VK_VIDEO_ENCODE_USAGE_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_queue
[Flags] public enum VkVideoEncodeContentFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_CONTENT_DEFAULT_KHR = 0, 
    VK_VIDEO_ENCODE_CONTENT_CAMERA_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_CONTENT_DESKTOP_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_CONTENT_RENDERED_BIT_KHR = 0x00000004, 
    VK_VIDEO_ENCODE_CONTENT_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_cooperative_matrix
[Flags] public enum VkComponentTypeKHR : uint   {
    VK_COMPONENT_TYPE_FLOAT16_KHR = 0, 
    VK_COMPONENT_TYPE_FLOAT32_KHR = 1, 
    VK_COMPONENT_TYPE_FLOAT64_KHR = 2, 
    VK_COMPONENT_TYPE_SINT8_KHR = 3, 
    VK_COMPONENT_TYPE_SINT16_KHR = 4, 
    VK_COMPONENT_TYPE_SINT32_KHR = 5, 
    VK_COMPONENT_TYPE_SINT64_KHR = 6, 
    VK_COMPONENT_TYPE_UINT8_KHR = 7, 
    VK_COMPONENT_TYPE_UINT16_KHR = 8, 
    VK_COMPONENT_TYPE_UINT32_KHR = 9, 
    VK_COMPONENT_TYPE_UINT64_KHR = 10, 
    VK_COMPONENT_TYPE_BFLOAT16_KHR = 1000141000, 
    VK_COMPONENT_TYPE_SINT8_PACKED_NV = 1000491000, 
    VK_COMPONENT_TYPE_UINT8_PACKED_NV = 1000491001, 
    VK_COMPONENT_TYPE_FLOAT_E4M3_NV = 1000491002, 
    VK_COMPONENT_TYPE_FLOAT_E5M2_NV = 1000491003, 
    VK_COMPONENT_TYPE_FLOAT16_NV = VK_COMPONENT_TYPE_FLOAT16_KHR, 
    VK_COMPONENT_TYPE_FLOAT32_NV = VK_COMPONENT_TYPE_FLOAT32_KHR, 
    VK_COMPONENT_TYPE_FLOAT64_NV = VK_COMPONENT_TYPE_FLOAT64_KHR, 
    VK_COMPONENT_TYPE_SINT8_NV = VK_COMPONENT_TYPE_SINT8_KHR, 
    VK_COMPONENT_TYPE_SINT16_NV = VK_COMPONENT_TYPE_SINT16_KHR, 
    VK_COMPONENT_TYPE_SINT32_NV = VK_COMPONENT_TYPE_SINT32_KHR, 
    VK_COMPONENT_TYPE_SINT64_NV = VK_COMPONENT_TYPE_SINT64_KHR, 
    VK_COMPONENT_TYPE_UINT8_NV = VK_COMPONENT_TYPE_UINT8_KHR, 
    VK_COMPONENT_TYPE_UINT16_NV = VK_COMPONENT_TYPE_UINT16_KHR, 
    VK_COMPONENT_TYPE_UINT32_NV = VK_COMPONENT_TYPE_UINT32_KHR, 
    VK_COMPONENT_TYPE_UINT64_NV = VK_COMPONENT_TYPE_UINT64_KHR, 
    VK_COMPONENT_TYPE_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_cooperative_matrix
[Flags] public enum VkScopeKHR : uint   {
    VK_SCOPE_DEVICE_KHR = 1, 
    VK_SCOPE_WORKGROUP_KHR = 2, 
    VK_SCOPE_SUBGROUP_KHR = 3, 
    VK_SCOPE_QUEUE_FAMILY_KHR = 5, 
    VK_SCOPE_DEVICE_NV = VK_SCOPE_DEVICE_KHR, 
    VK_SCOPE_WORKGROUP_NV = VK_SCOPE_WORKGROUP_KHR, 
    VK_SCOPE_SUBGROUP_NV = VK_SCOPE_SUBGROUP_KHR, 
    VK_SCOPE_QUEUE_FAMILY_NV = VK_SCOPE_QUEUE_FAMILY_KHR, 
    VK_SCOPE_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_av1
[Flags] public enum VkVideoEncodeAV1PredictionModeKHR : uint   {
    VK_VIDEO_ENCODE_AV1_PREDICTION_MODE_INTRA_ONLY_KHR = 0, 
    VK_VIDEO_ENCODE_AV1_PREDICTION_MODE_SINGLE_REFERENCE_KHR = 1, 
    VK_VIDEO_ENCODE_AV1_PREDICTION_MODE_UNIDIRECTIONAL_COMPOUND_KHR = 2, 
    VK_VIDEO_ENCODE_AV1_PREDICTION_MODE_BIDIRECTIONAL_COMPOUND_KHR = 3, 
    VK_VIDEO_ENCODE_AV1_PREDICTION_MODE_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_av1
[Flags] public enum VkVideoEncodeAV1RateControlGroupKHR : uint   {
    VK_VIDEO_ENCODE_AV1_RATE_CONTROL_GROUP_INTRA_KHR = 0, 
    VK_VIDEO_ENCODE_AV1_RATE_CONTROL_GROUP_PREDICTIVE_KHR = 1, 
    VK_VIDEO_ENCODE_AV1_RATE_CONTROL_GROUP_BIPREDICTIVE_KHR = 2, 
    VK_VIDEO_ENCODE_AV1_RATE_CONTROL_GROUP_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_av1
[Flags] public enum VkVideoEncodeAV1CapabilityFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_AV1_CAPABILITY_PER_RATE_CONTROL_GROUP_MIN_MAX_Q_INDEX_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_AV1_CAPABILITY_GENERATE_OBU_EXTENSION_HEADER_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_AV1_CAPABILITY_PRIMARY_REFERENCE_CDF_ONLY_BIT_KHR = 0x00000004, 
    VK_VIDEO_ENCODE_AV1_CAPABILITY_FRAME_SIZE_OVERRIDE_BIT_KHR = 0x00000008, 
    VK_VIDEO_ENCODE_AV1_CAPABILITY_MOTION_VECTOR_SCALING_BIT_KHR = 0x00000010, 
    VK_VIDEO_ENCODE_AV1_CAPABILITY_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_av1
[Flags] public enum VkVideoEncodeAV1StdFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_AV1_STD_UNIFORM_TILE_SPACING_FLAG_SET_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_AV1_STD_SKIP_MODE_PRESENT_UNSET_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_AV1_STD_PRIMARY_REF_FRAME_BIT_KHR = 0x00000004, 
    VK_VIDEO_ENCODE_AV1_STD_DELTA_Q_BIT_KHR = 0x00000008, 
    VK_VIDEO_ENCODE_AV1_STD_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_av1
[Flags] public enum VkVideoEncodeAV1SuperblockSizeFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_AV1_SUPERBLOCK_SIZE_64_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_AV1_SUPERBLOCK_SIZE_128_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_AV1_SUPERBLOCK_SIZE_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_video_encode_av1
[Flags] public enum VkVideoEncodeAV1RateControlFlagBitsKHR : uint   {
    VK_VIDEO_ENCODE_AV1_RATE_CONTROL_REGULAR_GOP_BIT_KHR = 0x00000001, 
    VK_VIDEO_ENCODE_AV1_RATE_CONTROL_TEMPORAL_LAYER_PATTERN_DYADIC_BIT_KHR = 0x00000002, 
    VK_VIDEO_ENCODE_AV1_RATE_CONTROL_REFERENCE_PATTERN_FLAT_BIT_KHR = 0x00000004, 
    VK_VIDEO_ENCODE_AV1_RATE_CONTROL_REFERENCE_PATTERN_DYADIC_BIT_KHR = 0x00000008, 
    VK_VIDEO_ENCODE_AV1_RATE_CONTROL_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_calibrated_timestamps
[Flags] public enum VkTimeDomainKHR : uint   {
    VK_TIME_DOMAIN_DEVICE_KHR = 0, 
    VK_TIME_DOMAIN_CLOCK_MONOTONIC_KHR = 1, 
    VK_TIME_DOMAIN_CLOCK_MONOTONIC_RAW_KHR = 2, 
    VK_TIME_DOMAIN_QUERY_PERFORMANCE_COUNTER_KHR = 3, 
    VK_TIME_DOMAIN_DEVICE_EXT = VK_TIME_DOMAIN_DEVICE_KHR, 
    VK_TIME_DOMAIN_CLOCK_MONOTONIC_EXT = VK_TIME_DOMAIN_CLOCK_MONOTONIC_KHR, 
    VK_TIME_DOMAIN_CLOCK_MONOTONIC_RAW_EXT = VK_TIME_DOMAIN_CLOCK_MONOTONIC_RAW_KHR, 
    VK_TIME_DOMAIN_QUERY_PERFORMANCE_COUNTER_EXT = VK_TIME_DOMAIN_QUERY_PERFORMANCE_COUNTER_KHR, 
    VK_TIME_DOMAIN_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_maintenance7
[Flags] public enum VkPhysicalDeviceLayeredApiKHR : uint   {
    VK_PHYSICAL_DEVICE_LAYERED_API_VULKAN_KHR = 0, 
    VK_PHYSICAL_DEVICE_LAYERED_API_D3D12_KHR = 1, 
    VK_PHYSICAL_DEVICE_LAYERED_API_METAL_KHR = 2, 
    VK_PHYSICAL_DEVICE_LAYERED_API_OPENGL_KHR = 3, 
    VK_PHYSICAL_DEVICE_LAYERED_API_OPENGLES_KHR = 4, 
    VK_PHYSICAL_DEVICE_LAYERED_API_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_EXT_debug_report
[Flags] public enum VkDebugReportObjectTypeEXT : uint   {
    VK_DEBUG_REPORT_OBJECT_TYPE_UNKNOWN_EXT = 0, 
    VK_DEBUG_REPORT_OBJECT_TYPE_INSTANCE_EXT = 1, 
    VK_DEBUG_REPORT_OBJECT_TYPE_PHYSICAL_DEVICE_EXT = 2, 
    VK_DEBUG_REPORT_OBJECT_TYPE_DEVICE_EXT = 3, 
    VK_DEBUG_REPORT_OBJECT_TYPE_QUEUE_EXT = 4, 
    VK_DEBUG_REPORT_OBJECT_TYPE_SEMAPHORE_EXT = 5, 
    VK_DEBUG_REPORT_OBJECT_TYPE_COMMAND_BUFFER_EXT = 6, 
    VK_DEBUG_REPORT_OBJECT_TYPE_FENCE_EXT = 7, 
    VK_DEBUG_REPORT_OBJECT_TYPE_DEVICE_MEMORY_EXT = 8, 
    VK_DEBUG_REPORT_OBJECT_TYPE_BUFFER_EXT = 9, 
    VK_DEBUG_REPORT_OBJECT_TYPE_IMAGE_EXT = 10, 
    VK_DEBUG_REPORT_OBJECT_TYPE_EVENT_EXT = 11, 
    VK_DEBUG_REPORT_OBJECT_TYPE_QUERY_POOL_EXT = 12, 
    VK_DEBUG_REPORT_OBJECT_TYPE_BUFFER_VIEW_EXT = 13, 
    VK_DEBUG_REPORT_OBJECT_TYPE_IMAGE_VIEW_EXT = 14, 
    VK_DEBUG_REPORT_OBJECT_TYPE_SHADER_MODULE_EXT = 15, 
    VK_DEBUG_REPORT_OBJECT_TYPE_PIPELINE_CACHE_EXT = 16, 
    VK_DEBUG_REPORT_OBJECT_TYPE_PIPELINE_LAYOUT_EXT = 17, 
    VK_DEBUG_REPORT_OBJECT_TYPE_RENDER_PASS_EXT = 18, 
    VK_DEBUG_REPORT_OBJECT_TYPE_PIPELINE_EXT = 19, 
    VK_DEBUG_REPORT_OBJECT_TYPE_DESCRIPTOR_SET_LAYOUT_EXT = 20, 
    VK_DEBUG_REPORT_OBJECT_TYPE_SAMPLER_EXT = 21, 
    VK_DEBUG_REPORT_OBJECT_TYPE_DESCRIPTOR_POOL_EXT = 22, 
    VK_DEBUG_REPORT_OBJECT_TYPE_DESCRIPTOR_SET_EXT = 23, 
    VK_DEBUG_REPORT_OBJECT_TYPE_FRAMEBUFFER_EXT = 24, 
    VK_DEBUG_REPORT_OBJECT_TYPE_COMMAND_POOL_EXT = 25, 
    VK_DEBUG_REPORT_OBJECT_TYPE_SURFACE_KHR_EXT = 26, 
    VK_DEBUG_REPORT_OBJECT_TYPE_SWAPCHAIN_KHR_EXT = 27, 
    VK_DEBUG_REPORT_OBJECT_TYPE_DEBUG_REPORT_CALLBACK_EXT_EXT = 28, 
    VK_DEBUG_REPORT_OBJECT_TYPE_DISPLAY_KHR_EXT = 29, 
    VK_DEBUG_REPORT_OBJECT_TYPE_DISPLAY_MODE_KHR_EXT = 30, 
    VK_DEBUG_REPORT_OBJECT_TYPE_VALIDATION_CACHE_EXT_EXT = 33, 
    VK_DEBUG_REPORT_OBJECT_TYPE_SAMPLER_YCBCR_CONVERSION_EXT = 1000156000, 
    VK_DEBUG_REPORT_OBJECT_TYPE_DESCRIPTOR_UPDATE_TEMPLATE_EXT = 1000085000, 
    VK_DEBUG_REPORT_OBJECT_TYPE_CU_MODULE_NVX_EXT = 1000029000, 
    VK_DEBUG_REPORT_OBJECT_TYPE_CU_FUNCTION_NVX_EXT = 1000029001, 
    VK_DEBUG_REPORT_OBJECT_TYPE_ACCELERATION_STRUCTURE_KHR_EXT = 1000150000, 
    VK_DEBUG_REPORT_OBJECT_TYPE_ACCELERATION_STRUCTURE_NV_EXT = 1000165000, 
    VK_DEBUG_REPORT_OBJECT_TYPE_CUDA_MODULE_NV_EXT = 1000307000, 
    VK_DEBUG_REPORT_OBJECT_TYPE_CUDA_FUNCTION_NV_EXT = 1000307001, 
    VK_DEBUG_REPORT_OBJECT_TYPE_BUFFER_COLLECTION_FUCHSIA_EXT = 1000366000, 
  // VK_DEBUG_REPORT_OBJECT_TYPE_DEBUG_REPORT_EXT is a deprecated alias 
    VK_DEBUG_REPORT_OBJECT_TYPE_DEBUG_REPORT_EXT = VK_DEBUG_REPORT_OBJECT_TYPE_DEBUG_REPORT_CALLBACK_EXT_EXT, 
  // VK_DEBUG_REPORT_OBJECT_TYPE_VALIDATION_CACHE_EXT is a deprecated alias 
    VK_DEBUG_REPORT_OBJECT_TYPE_VALIDATION_CACHE_EXT = VK_DEBUG_REPORT_OBJECT_TYPE_VALIDATION_CACHE_EXT_EXT, 
    VK_DEBUG_REPORT_OBJECT_TYPE_DESCRIPTOR_UPDATE_TEMPLATE_KHR_EXT = VK_DEBUG_REPORT_OBJECT_TYPE_DESCRIPTOR_UPDATE_TEMPLATE_EXT, 
    VK_DEBUG_REPORT_OBJECT_TYPE_SAMPLER_YCBCR_CONVERSION_KHR_EXT = VK_DEBUG_REPORT_OBJECT_TYPE_SAMPLER_YCBCR_CONVERSION_EXT, 
    VK_DEBUG_REPORT_OBJECT_TYPE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_debug_report
[Flags] public enum VkDebugReportFlagBitsEXT : uint   {
    VK_DEBUG_REPORT_INFORMATION_BIT_EXT = 0x00000001, 
    VK_DEBUG_REPORT_WARNING_BIT_EXT = 0x00000002, 
    VK_DEBUG_REPORT_PERFORMANCE_WARNING_BIT_EXT = 0x00000004, 
    VK_DEBUG_REPORT_ERROR_BIT_EXT = 0x00000008, 
    VK_DEBUG_REPORT_DEBUG_BIT_EXT = 0x00000010, 
    VK_DEBUG_REPORT_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_AMD_rasterization_order
[Flags] public enum VkRasterizationOrderAMD : uint   {
    VK_RASTERIZATION_ORDER_STRICT_AMD = 0, 
    VK_RASTERIZATION_ORDER_RELAXED_AMD = 1, 
    VK_RASTERIZATION_ORDER_MAX_ENUM_AMD = 0x7FFFFFFF 
};
// VK_AMD_shader_info
[Flags] public enum VkShaderInfoTypeAMD : uint   {
    VK_SHADER_INFO_TYPE_STATISTICS_AMD = 0, 
    VK_SHADER_INFO_TYPE_BINARY_AMD = 1, 
    VK_SHADER_INFO_TYPE_DISASSEMBLY_AMD = 2, 
    VK_SHADER_INFO_TYPE_MAX_ENUM_AMD = 0x7FFFFFFF 
};
// VK_NV_external_memory_capabilities
[Flags] public enum VkExternalMemoryHandleTypeFlagBitsNV : uint   {
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_OPAQUE_WIN32_BIT_NV = 0x00000001, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_OPAQUE_WIN32_KMT_BIT_NV = 0x00000002, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D11_IMAGE_BIT_NV = 0x00000004, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_D3D11_IMAGE_KMT_BIT_NV = 0x00000008, 
    VK_EXTERNAL_MEMORY_HANDLE_TYPE_FLAG_BITS_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_external_memory_capabilities
[Flags] public enum VkExternalMemoryFeatureFlagBitsNV : uint   {
    VK_EXTERNAL_MEMORY_FEATURE_DEDICATED_ONLY_BIT_NV = 0x00000001, 
    VK_EXTERNAL_MEMORY_FEATURE_EXPORTABLE_BIT_NV = 0x00000002, 
    VK_EXTERNAL_MEMORY_FEATURE_IMPORTABLE_BIT_NV = 0x00000004, 
    VK_EXTERNAL_MEMORY_FEATURE_FLAG_BITS_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_EXT_validation_flags
[Flags] public enum VkValidationCheckEXT : uint   {
    VK_VALIDATION_CHECK_ALL_EXT = 0, 
    VK_VALIDATION_CHECK_SHADERS_EXT = 1, 
    VK_VALIDATION_CHECK_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_conditional_rendering
[Flags] public enum VkConditionalRenderingFlagBitsEXT : uint   {
    VK_CONDITIONAL_RENDERING_INVERTED_BIT_EXT = 0x00000001, 
    VK_CONDITIONAL_RENDERING_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_display_surface_counter
[Flags] public enum VkSurfaceCounterFlagBitsEXT : uint   {
    VK_SURFACE_COUNTER_VBLANK_BIT_EXT = 0x00000001, 
  // VK_SURFACE_COUNTER_VBLANK_EXT is a deprecated alias 
    VK_SURFACE_COUNTER_VBLANK_EXT = VK_SURFACE_COUNTER_VBLANK_BIT_EXT, 
    VK_SURFACE_COUNTER_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_display_control
[Flags] public enum VkDisplayPowerStateEXT : uint   {
    VK_DISPLAY_POWER_STATE_OFF_EXT = 0, 
    VK_DISPLAY_POWER_STATE_SUSPEND_EXT = 1, 
    VK_DISPLAY_POWER_STATE_ON_EXT = 2, 
    VK_DISPLAY_POWER_STATE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_display_control
[Flags] public enum VkDeviceEventTypeEXT : uint   {
    VK_DEVICE_EVENT_TYPE_DISPLAY_HOTPLUG_EXT = 0, 
    VK_DEVICE_EVENT_TYPE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_display_control
[Flags] public enum VkDisplayEventTypeEXT : uint   {
    VK_DISPLAY_EVENT_TYPE_FIRST_PIXEL_OUT_EXT = 0, 
    VK_DISPLAY_EVENT_TYPE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_NV_viewport_swizzle
[Flags] public enum VkViewportCoordinateSwizzleNV : uint   {
    VK_VIEWPORT_COORDINATE_SWIZZLE_POSITIVE_X_NV = 0, 
    VK_VIEWPORT_COORDINATE_SWIZZLE_NEGATIVE_X_NV = 1, 
    VK_VIEWPORT_COORDINATE_SWIZZLE_POSITIVE_Y_NV = 2, 
    VK_VIEWPORT_COORDINATE_SWIZZLE_NEGATIVE_Y_NV = 3, 
    VK_VIEWPORT_COORDINATE_SWIZZLE_POSITIVE_Z_NV = 4, 
    VK_VIEWPORT_COORDINATE_SWIZZLE_NEGATIVE_Z_NV = 5, 
    VK_VIEWPORT_COORDINATE_SWIZZLE_POSITIVE_W_NV = 6, 
    VK_VIEWPORT_COORDINATE_SWIZZLE_NEGATIVE_W_NV = 7, 
    VK_VIEWPORT_COORDINATE_SWIZZLE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_EXT_discard_rectangles
[Flags] public enum VkDiscardRectangleModeEXT : uint   {
    VK_DISCARD_RECTANGLE_MODE_INCLUSIVE_EXT = 0, 
    VK_DISCARD_RECTANGLE_MODE_EXCLUSIVE_EXT = 1, 
    VK_DISCARD_RECTANGLE_MODE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_conservative_rasterization
[Flags] public enum VkConservativeRasterizationModeEXT : uint   {
    VK_CONSERVATIVE_RASTERIZATION_MODE_DISABLED_EXT = 0, 
    VK_CONSERVATIVE_RASTERIZATION_MODE_OVERESTIMATE_EXT = 1, 
    VK_CONSERVATIVE_RASTERIZATION_MODE_UNDERESTIMATE_EXT = 2, 
    VK_CONSERVATIVE_RASTERIZATION_MODE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_debug_utils
[Flags] public enum VkDebugUtilsMessageSeverityFlagBitsEXT : uint   {
    VK_DEBUG_UTILS_MESSAGE_SEVERITY_VERBOSE_BIT_EXT = 0x00000001, 
    VK_DEBUG_UTILS_MESSAGE_SEVERITY_INFO_BIT_EXT = 0x00000010, 
    VK_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT = 0x00000100, 
    VK_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT = 0x00001000, 
    VK_DEBUG_UTILS_MESSAGE_SEVERITY_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_debug_utils
[Flags] public enum VkDebugUtilsMessageTypeFlagBitsEXT : uint   {
    VK_DEBUG_UTILS_MESSAGE_TYPE_GENERAL_BIT_EXT = 0x00000001, 
    VK_DEBUG_UTILS_MESSAGE_TYPE_VALIDATION_BIT_EXT = 0x00000002, 
    VK_DEBUG_UTILS_MESSAGE_TYPE_PERFORMANCE_BIT_EXT = 0x00000004, 
    VK_DEBUG_UTILS_MESSAGE_TYPE_DEVICE_ADDRESS_BINDING_BIT_EXT = 0x00000008, 
    VK_DEBUG_UTILS_MESSAGE_TYPE_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_blend_operation_advanced
[Flags] public enum VkBlendOverlapEXT : uint   {
    VK_BLEND_OVERLAP_UNCORRELATED_EXT = 0, 
    VK_BLEND_OVERLAP_DISJOINT_EXT = 1, 
    VK_BLEND_OVERLAP_CONJOINT_EXT = 2, 
    VK_BLEND_OVERLAP_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_NV_framebuffer_mixed_samples
[Flags] public enum VkCoverageModulationModeNV : uint   {
    VK_COVERAGE_MODULATION_MODE_NONE_NV = 0, 
    VK_COVERAGE_MODULATION_MODE_RGB_NV = 1, 
    VK_COVERAGE_MODULATION_MODE_ALPHA_NV = 2, 
    VK_COVERAGE_MODULATION_MODE_RGBA_NV = 3, 
    VK_COVERAGE_MODULATION_MODE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_EXT_validation_cache
[Flags] public enum VkValidationCacheHeaderVersionEXT : uint   {
    VK_VALIDATION_CACHE_HEADER_VERSION_ONE_EXT = 1, 
    VK_VALIDATION_CACHE_HEADER_VERSION_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_NV_shading_rate_image
[Flags] public enum VkShadingRatePaletteEntryNV : uint   {
    VK_SHADING_RATE_PALETTE_ENTRY_NO_INVOCATIONS_NV = 0, 
    VK_SHADING_RATE_PALETTE_ENTRY_16_INVOCATIONS_PER_PIXEL_NV = 1, 
    VK_SHADING_RATE_PALETTE_ENTRY_8_INVOCATIONS_PER_PIXEL_NV = 2, 
    VK_SHADING_RATE_PALETTE_ENTRY_4_INVOCATIONS_PER_PIXEL_NV = 3, 
    VK_SHADING_RATE_PALETTE_ENTRY_2_INVOCATIONS_PER_PIXEL_NV = 4, 
    VK_SHADING_RATE_PALETTE_ENTRY_1_INVOCATION_PER_PIXEL_NV = 5, 
    VK_SHADING_RATE_PALETTE_ENTRY_1_INVOCATION_PER_2X1_PIXELS_NV = 6, 
    VK_SHADING_RATE_PALETTE_ENTRY_1_INVOCATION_PER_1X2_PIXELS_NV = 7, 
    VK_SHADING_RATE_PALETTE_ENTRY_1_INVOCATION_PER_2X2_PIXELS_NV = 8, 
    VK_SHADING_RATE_PALETTE_ENTRY_1_INVOCATION_PER_4X2_PIXELS_NV = 9, 
    VK_SHADING_RATE_PALETTE_ENTRY_1_INVOCATION_PER_2X4_PIXELS_NV = 10, 
    VK_SHADING_RATE_PALETTE_ENTRY_1_INVOCATION_PER_4X4_PIXELS_NV = 11, 
    VK_SHADING_RATE_PALETTE_ENTRY_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_shading_rate_image
[Flags] public enum VkCoarseSampleOrderTypeNV : uint   {
    VK_COARSE_SAMPLE_ORDER_TYPE_DEFAULT_NV = 0, 
    VK_COARSE_SAMPLE_ORDER_TYPE_CUSTOM_NV = 1, 
    VK_COARSE_SAMPLE_ORDER_TYPE_PIXEL_MAJOR_NV = 2, 
    VK_COARSE_SAMPLE_ORDER_TYPE_SAMPLE_MAJOR_NV = 3, 
    VK_COARSE_SAMPLE_ORDER_TYPE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_ray_tracing
[Flags] public enum VkRayTracingShaderGroupTypeKHR : uint   {
    VK_RAY_TRACING_SHADER_GROUP_TYPE_GENERAL_KHR = 0, 
    VK_RAY_TRACING_SHADER_GROUP_TYPE_TRIANGLES_HIT_GROUP_KHR = 1, 
    VK_RAY_TRACING_SHADER_GROUP_TYPE_PROCEDURAL_HIT_GROUP_KHR = 2, 
    VK_RAY_TRACING_SHADER_GROUP_TYPE_GENERAL_NV = VK_RAY_TRACING_SHADER_GROUP_TYPE_GENERAL_KHR, 
    VK_RAY_TRACING_SHADER_GROUP_TYPE_TRIANGLES_HIT_GROUP_NV = VK_RAY_TRACING_SHADER_GROUP_TYPE_TRIANGLES_HIT_GROUP_KHR, 
    VK_RAY_TRACING_SHADER_GROUP_TYPE_PROCEDURAL_HIT_GROUP_NV = VK_RAY_TRACING_SHADER_GROUP_TYPE_PROCEDURAL_HIT_GROUP_KHR, 
    VK_RAY_TRACING_SHADER_GROUP_TYPE_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_NV_ray_tracing
[Flags] public enum VkGeometryTypeKHR : uint   {
    VK_GEOMETRY_TYPE_TRIANGLES_KHR = 0, 
    VK_GEOMETRY_TYPE_AABBS_KHR = 1, 
    VK_GEOMETRY_TYPE_INSTANCES_KHR = 2, 
    VK_GEOMETRY_TYPE_SPHERES_NV = 1000429004, 
    VK_GEOMETRY_TYPE_LINEAR_SWEPT_SPHERES_NV = 1000429005, 
    VK_GEOMETRY_TYPE_TRIANGLES_NV = VK_GEOMETRY_TYPE_TRIANGLES_KHR, 
    VK_GEOMETRY_TYPE_AABBS_NV = VK_GEOMETRY_TYPE_AABBS_KHR, 
    VK_GEOMETRY_TYPE_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_NV_ray_tracing
[Flags] public enum VkAccelerationStructureTypeKHR : uint   {
    VK_ACCELERATION_STRUCTURE_TYPE_TOP_LEVEL_KHR = 0, 
    VK_ACCELERATION_STRUCTURE_TYPE_BOTTOM_LEVEL_KHR = 1, 
    VK_ACCELERATION_STRUCTURE_TYPE_GENERIC_KHR = 2, 
    VK_ACCELERATION_STRUCTURE_TYPE_TOP_LEVEL_NV = VK_ACCELERATION_STRUCTURE_TYPE_TOP_LEVEL_KHR, 
    VK_ACCELERATION_STRUCTURE_TYPE_BOTTOM_LEVEL_NV = VK_ACCELERATION_STRUCTURE_TYPE_BOTTOM_LEVEL_KHR, 
    VK_ACCELERATION_STRUCTURE_TYPE_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_NV_ray_tracing
[Flags] public enum VkCopyAccelerationStructureModeKHR : uint   {
    VK_COPY_ACCELERATION_STRUCTURE_MODE_CLONE_KHR = 0, 
    VK_COPY_ACCELERATION_STRUCTURE_MODE_COMPACT_KHR = 1, 
    VK_COPY_ACCELERATION_STRUCTURE_MODE_SERIALIZE_KHR = 2, 
    VK_COPY_ACCELERATION_STRUCTURE_MODE_DESERIALIZE_KHR = 3, 
    VK_COPY_ACCELERATION_STRUCTURE_MODE_CLONE_NV = VK_COPY_ACCELERATION_STRUCTURE_MODE_CLONE_KHR, 
    VK_COPY_ACCELERATION_STRUCTURE_MODE_COMPACT_NV = VK_COPY_ACCELERATION_STRUCTURE_MODE_COMPACT_KHR, 
    VK_COPY_ACCELERATION_STRUCTURE_MODE_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_NV_ray_tracing
[Flags] public enum VkAccelerationStructureMemoryRequirementsTypeNV : uint   {
    VK_ACCELERATION_STRUCTURE_MEMORY_REQUIREMENTS_TYPE_OBJECT_NV = 0, 
    VK_ACCELERATION_STRUCTURE_MEMORY_REQUIREMENTS_TYPE_BUILD_SCRATCH_NV = 1, 
    VK_ACCELERATION_STRUCTURE_MEMORY_REQUIREMENTS_TYPE_UPDATE_SCRATCH_NV = 2, 
    VK_ACCELERATION_STRUCTURE_MEMORY_REQUIREMENTS_TYPE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_ray_tracing
[Flags] public enum VkGeometryFlagBitsKHR : uint   {
    VK_GEOMETRY_OPAQUE_BIT_KHR = 0x00000001, 
    VK_GEOMETRY_NO_DUPLICATE_ANY_HIT_INVOCATION_BIT_KHR = 0x00000002, 
    VK_GEOMETRY_OPAQUE_BIT_NV = VK_GEOMETRY_OPAQUE_BIT_KHR, 
    VK_GEOMETRY_NO_DUPLICATE_ANY_HIT_INVOCATION_BIT_NV = VK_GEOMETRY_NO_DUPLICATE_ANY_HIT_INVOCATION_BIT_KHR, 
    VK_GEOMETRY_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_NV_ray_tracing
[Flags] public enum VkGeometryInstanceFlagBitsKHR : uint   {
    VK_GEOMETRY_INSTANCE_TRIANGLE_FACING_CULL_DISABLE_BIT_KHR = 0x00000001, 
    VK_GEOMETRY_INSTANCE_TRIANGLE_FLIP_FACING_BIT_KHR = 0x00000002, 
    VK_GEOMETRY_INSTANCE_FORCE_OPAQUE_BIT_KHR = 0x00000004, 
    VK_GEOMETRY_INSTANCE_FORCE_NO_OPAQUE_BIT_KHR = 0x00000008, 
    VK_GEOMETRY_INSTANCE_FORCE_OPACITY_MICROMAP_2_STATE_EXT = 0x00000010, 
    VK_GEOMETRY_INSTANCE_DISABLE_OPACITY_MICROMAPS_EXT = 0x00000020, 
    VK_GEOMETRY_INSTANCE_TRIANGLE_FRONT_COUNTERCLOCKWISE_BIT_KHR = VK_GEOMETRY_INSTANCE_TRIANGLE_FLIP_FACING_BIT_KHR, 
    VK_GEOMETRY_INSTANCE_TRIANGLE_CULL_DISABLE_BIT_NV = VK_GEOMETRY_INSTANCE_TRIANGLE_FACING_CULL_DISABLE_BIT_KHR, 
    VK_GEOMETRY_INSTANCE_TRIANGLE_FRONT_COUNTERCLOCKWISE_BIT_NV = VK_GEOMETRY_INSTANCE_TRIANGLE_FRONT_COUNTERCLOCKWISE_BIT_KHR, 
    VK_GEOMETRY_INSTANCE_FORCE_OPAQUE_BIT_NV = VK_GEOMETRY_INSTANCE_FORCE_OPAQUE_BIT_KHR, 
    VK_GEOMETRY_INSTANCE_FORCE_NO_OPAQUE_BIT_NV = VK_GEOMETRY_INSTANCE_FORCE_NO_OPAQUE_BIT_KHR, 
    VK_GEOMETRY_INSTANCE_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_NV_ray_tracing
[Flags] public enum VkBuildAccelerationStructureFlagBitsKHR : uint   {
    VK_BUILD_ACCELERATION_STRUCTURE_ALLOW_UPDATE_BIT_KHR = 0x00000001, 
    VK_BUILD_ACCELERATION_STRUCTURE_ALLOW_COMPACTION_BIT_KHR = 0x00000002, 
    VK_BUILD_ACCELERATION_STRUCTURE_PREFER_FAST_TRACE_BIT_KHR = 0x00000004, 
    VK_BUILD_ACCELERATION_STRUCTURE_PREFER_FAST_BUILD_BIT_KHR = 0x00000008, 
    VK_BUILD_ACCELERATION_STRUCTURE_LOW_MEMORY_BIT_KHR = 0x00000010, 
    VK_BUILD_ACCELERATION_STRUCTURE_MOTION_BIT_NV = 0x00000020, 
    VK_BUILD_ACCELERATION_STRUCTURE_ALLOW_OPACITY_MICROMAP_UPDATE_EXT = 0x00000040, 
    VK_BUILD_ACCELERATION_STRUCTURE_ALLOW_DISABLE_OPACITY_MICROMAPS_EXT = 0x00000080, 
    VK_BUILD_ACCELERATION_STRUCTURE_ALLOW_OPACITY_MICROMAP_DATA_UPDATE_EXT = 0x00000100, 
    VK_BUILD_ACCELERATION_STRUCTURE_ALLOW_DISPLACEMENT_MICROMAP_UPDATE_NV = 0x00000200, 
    VK_BUILD_ACCELERATION_STRUCTURE_ALLOW_DATA_ACCESS_KHR = 0x00000800, 
    VK_BUILD_ACCELERATION_STRUCTURE_ALLOW_UPDATE_BIT_NV = VK_BUILD_ACCELERATION_STRUCTURE_ALLOW_UPDATE_BIT_KHR, 
    VK_BUILD_ACCELERATION_STRUCTURE_ALLOW_COMPACTION_BIT_NV = VK_BUILD_ACCELERATION_STRUCTURE_ALLOW_COMPACTION_BIT_KHR, 
    VK_BUILD_ACCELERATION_STRUCTURE_PREFER_FAST_TRACE_BIT_NV = VK_BUILD_ACCELERATION_STRUCTURE_PREFER_FAST_TRACE_BIT_KHR, 
    VK_BUILD_ACCELERATION_STRUCTURE_PREFER_FAST_BUILD_BIT_NV = VK_BUILD_ACCELERATION_STRUCTURE_PREFER_FAST_BUILD_BIT_KHR, 
    VK_BUILD_ACCELERATION_STRUCTURE_LOW_MEMORY_BIT_NV = VK_BUILD_ACCELERATION_STRUCTURE_LOW_MEMORY_BIT_KHR, 
    VK_BUILD_ACCELERATION_STRUCTURE_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_AMD_pipeline_compiler_control
[Flags] public enum VkPipelineCompilerControlFlagBitsAMD : uint   {
    VK_PIPELINE_COMPILER_CONTROL_FLAG_BITS_MAX_ENUM_AMD = 0x7FFFFFFF 
};
// VK_AMD_memory_overallocation_behavior
[Flags] public enum VkMemoryOverallocationBehaviorAMD : uint   {
    VK_MEMORY_OVERALLOCATION_BEHAVIOR_DEFAULT_AMD = 0, 
    VK_MEMORY_OVERALLOCATION_BEHAVIOR_ALLOWED_AMD = 1, 
    VK_MEMORY_OVERALLOCATION_BEHAVIOR_DISALLOWED_AMD = 2, 
    VK_MEMORY_OVERALLOCATION_BEHAVIOR_MAX_ENUM_AMD = 0x7FFFFFFF 
};
// VK_INTEL_performance_query
[Flags] public enum VkPerformanceConfigurationTypeINTEL : uint   {
    VK_PERFORMANCE_CONFIGURATION_TYPE_COMMAND_QUEUE_METRICS_DISCOVERY_ACTIVATED_INTEL = 0, 
    VK_PERFORMANCE_CONFIGURATION_TYPE_MAX_ENUM_INTEL = 0x7FFFFFFF 
};
// VK_INTEL_performance_query
[Flags] public enum VkQueryPoolSamplingModeINTEL : uint   {
    VK_QUERY_POOL_SAMPLING_MODE_MANUAL_INTEL = 0, 
    VK_QUERY_POOL_SAMPLING_MODE_MAX_ENUM_INTEL = 0x7FFFFFFF 
};
// VK_INTEL_performance_query
[Flags] public enum VkPerformanceOverrideTypeINTEL : uint   {
    VK_PERFORMANCE_OVERRIDE_TYPE_NULL_HARDWARE_INTEL = 0, 
    VK_PERFORMANCE_OVERRIDE_TYPE_FLUSH_GPU_CACHES_INTEL = 1, 
    VK_PERFORMANCE_OVERRIDE_TYPE_MAX_ENUM_INTEL = 0x7FFFFFFF 
};
// VK_INTEL_performance_query
[Flags] public enum VkPerformanceParameterTypeINTEL : uint   {
    VK_PERFORMANCE_PARAMETER_TYPE_HW_COUNTERS_SUPPORTED_INTEL = 0, 
    VK_PERFORMANCE_PARAMETER_TYPE_STREAM_MARKER_VALID_BITS_INTEL = 1, 
    VK_PERFORMANCE_PARAMETER_TYPE_MAX_ENUM_INTEL = 0x7FFFFFFF 
};
// VK_INTEL_performance_query
[Flags] public enum VkPerformanceValueTypeINTEL : uint   {
    VK_PERFORMANCE_VALUE_TYPE_UINT32_INTEL = 0, 
    VK_PERFORMANCE_VALUE_TYPE_UINT64_INTEL = 1, 
    VK_PERFORMANCE_VALUE_TYPE_FLOAT_INTEL = 2, 
    VK_PERFORMANCE_VALUE_TYPE_BOOL_INTEL = 3, 
    VK_PERFORMANCE_VALUE_TYPE_STRING_INTEL = 4, 
    VK_PERFORMANCE_VALUE_TYPE_MAX_ENUM_INTEL = 0x7FFFFFFF 
};
// VK_AMD_shader_core_properties2
[Flags] public enum VkShaderCorePropertiesFlagBitsAMD : uint   {
    VK_SHADER_CORE_PROPERTIES_FLAG_BITS_MAX_ENUM_AMD = 0x7FFFFFFF 
};
// VK_EXT_validation_features
[Flags] public enum VkValidationFeatureEnableEXT : uint   {
    VK_VALIDATION_FEATURE_ENABLE_GPU_ASSISTED_EXT = 0, 
    VK_VALIDATION_FEATURE_ENABLE_GPU_ASSISTED_RESERVE_BINDING_SLOT_EXT = 1, 
    VK_VALIDATION_FEATURE_ENABLE_BEST_PRACTICES_EXT = 2, 
    VK_VALIDATION_FEATURE_ENABLE_DEBUG_PRINTF_EXT = 3, 
    VK_VALIDATION_FEATURE_ENABLE_SYNCHRONIZATION_VALIDATION_EXT = 4, 
    VK_VALIDATION_FEATURE_ENABLE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_validation_features
[Flags] public enum VkValidationFeatureDisableEXT : uint   {
    VK_VALIDATION_FEATURE_DISABLE_ALL_EXT = 0, 
    VK_VALIDATION_FEATURE_DISABLE_SHADERS_EXT = 1, 
    VK_VALIDATION_FEATURE_DISABLE_THREAD_SAFETY_EXT = 2, 
    VK_VALIDATION_FEATURE_DISABLE_API_PARAMETERS_EXT = 3, 
    VK_VALIDATION_FEATURE_DISABLE_OBJECT_LIFETIMES_EXT = 4, 
    VK_VALIDATION_FEATURE_DISABLE_CORE_CHECKS_EXT = 5, 
    VK_VALIDATION_FEATURE_DISABLE_UNIQUE_HANDLES_EXT = 6, 
    VK_VALIDATION_FEATURE_DISABLE_SHADER_VALIDATION_CACHE_EXT = 7, 
    VK_VALIDATION_FEATURE_DISABLE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_NV_coverage_reduction_mode
[Flags] public enum VkCoverageReductionModeNV : uint   {
    VK_COVERAGE_REDUCTION_MODE_MERGE_NV = 0, 
    VK_COVERAGE_REDUCTION_MODE_TRUNCATE_NV = 1, 
    VK_COVERAGE_REDUCTION_MODE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_EXT_provoking_vertex
[Flags] public enum VkProvokingVertexModeEXT : uint   {
    VK_PROVOKING_VERTEX_MODE_FIRST_VERTEX_EXT = 0, 
    VK_PROVOKING_VERTEX_MODE_LAST_VERTEX_EXT = 1, 
    VK_PROVOKING_VERTEX_MODE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_surface_maintenance1
[Flags] public enum VkPresentScalingFlagBitsEXT : uint   {
    VK_PRESENT_SCALING_ONE_TO_ONE_BIT_EXT = 0x00000001, 
    VK_PRESENT_SCALING_ASPECT_RATIO_STRETCH_BIT_EXT = 0x00000002, 
    VK_PRESENT_SCALING_STRETCH_BIT_EXT = 0x00000004, 
    VK_PRESENT_SCALING_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_surface_maintenance1
[Flags] public enum VkPresentGravityFlagBitsEXT : uint   {
    VK_PRESENT_GRAVITY_MIN_BIT_EXT = 0x00000001, 
    VK_PRESENT_GRAVITY_MAX_BIT_EXT = 0x00000002, 
    VK_PRESENT_GRAVITY_CENTERED_BIT_EXT = 0x00000004, 
    VK_PRESENT_GRAVITY_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_NV_device_generated_commands
[Flags] public enum VkIndirectCommandsTokenTypeNV : uint   {
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_SHADER_GROUP_NV = 0, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_STATE_FLAGS_NV = 1, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_INDEX_BUFFER_NV = 2, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_VERTEX_BUFFER_NV = 3, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_PUSH_CONSTANT_NV = 4, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_DRAW_INDEXED_NV = 5, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_DRAW_NV = 6, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_DRAW_TASKS_NV = 7, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_DRAW_MESH_TASKS_NV = 1000328000, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_PIPELINE_NV = 1000428003, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_DISPATCH_NV = 1000428004, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_device_generated_commands
[Flags] public enum VkIndirectStateFlagBitsNV : uint   {
    VK_INDIRECT_STATE_FLAG_FRONTFACE_BIT_NV = 0x00000001, 
    VK_INDIRECT_STATE_FLAG_BITS_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_device_generated_commands
[Flags] public enum VkIndirectCommandsLayoutUsageFlagBitsNV : uint   {
    VK_INDIRECT_COMMANDS_LAYOUT_USAGE_EXPLICIT_PREPROCESS_BIT_NV = 0x00000001, 
    VK_INDIRECT_COMMANDS_LAYOUT_USAGE_INDEXED_SEQUENCES_BIT_NV = 0x00000002, 
    VK_INDIRECT_COMMANDS_LAYOUT_USAGE_UNORDERED_SEQUENCES_BIT_NV = 0x00000004, 
    VK_INDIRECT_COMMANDS_LAYOUT_USAGE_FLAG_BITS_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_EXT_depth_bias_control
[Flags] public enum VkDepthBiasRepresentationEXT : uint   {
    VK_DEPTH_BIAS_REPRESENTATION_LEAST_REPRESENTABLE_VALUE_FORMAT_EXT = 0, 
    VK_DEPTH_BIAS_REPRESENTATION_LEAST_REPRESENTABLE_VALUE_FORCE_UNORM_EXT = 1, 
    VK_DEPTH_BIAS_REPRESENTATION_FLOAT_EXT = 2, 
    VK_DEPTH_BIAS_REPRESENTATION_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_device_memory_report
[Flags] public enum VkDeviceMemoryReportEventTypeEXT : uint   {
    VK_DEVICE_MEMORY_REPORT_EVENT_TYPE_ALLOCATE_EXT = 0, 
    VK_DEVICE_MEMORY_REPORT_EVENT_TYPE_FREE_EXT = 1, 
    VK_DEVICE_MEMORY_REPORT_EVENT_TYPE_IMPORT_EXT = 2, 
    VK_DEVICE_MEMORY_REPORT_EVENT_TYPE_UNIMPORT_EXT = 3, 
    VK_DEVICE_MEMORY_REPORT_EVENT_TYPE_ALLOCATION_FAILED_EXT = 4, 
    VK_DEVICE_MEMORY_REPORT_EVENT_TYPE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_NV_device_diagnostics_config
[Flags] public enum VkDeviceDiagnosticsConfigFlagBitsNV : uint   {
    VK_DEVICE_DIAGNOSTICS_CONFIG_ENABLE_SHADER_DEBUG_INFO_BIT_NV = 0x00000001, 
    VK_DEVICE_DIAGNOSTICS_CONFIG_ENABLE_RESOURCE_TRACKING_BIT_NV = 0x00000002, 
    VK_DEVICE_DIAGNOSTICS_CONFIG_ENABLE_AUTOMATIC_CHECKPOINTS_BIT_NV = 0x00000004, 
    VK_DEVICE_DIAGNOSTICS_CONFIG_ENABLE_SHADER_ERROR_REPORTING_BIT_NV = 0x00000008, 
    VK_DEVICE_DIAGNOSTICS_CONFIG_FLAG_BITS_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_QCOM_tile_shading
[Flags] public enum VkTileShadingRenderPassFlagBitsQCOM : uint   {
    VK_TILE_SHADING_RENDER_PASS_ENABLE_BIT_QCOM = 0x00000001, 
    VK_TILE_SHADING_RENDER_PASS_PER_TILE_EXECUTION_BIT_QCOM = 0x00000002, 
    VK_TILE_SHADING_RENDER_PASS_FLAG_BITS_MAX_ENUM_QCOM = 0x7FFFFFFF 
};
// VK_EXT_graphics_pipeline_library
[Flags] public enum VkGraphicsPipelineLibraryFlagBitsEXT : uint   {
    VK_GRAPHICS_PIPELINE_LIBRARY_VERTEX_INPUT_INTERFACE_BIT_EXT = 0x00000001, 
    VK_GRAPHICS_PIPELINE_LIBRARY_PRE_RASTERIZATION_SHADERS_BIT_EXT = 0x00000002, 
    VK_GRAPHICS_PIPELINE_LIBRARY_FRAGMENT_SHADER_BIT_EXT = 0x00000004, 
    VK_GRAPHICS_PIPELINE_LIBRARY_FRAGMENT_OUTPUT_INTERFACE_BIT_EXT = 0x00000008, 
    VK_GRAPHICS_PIPELINE_LIBRARY_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_NV_fragment_shading_rate_enums
[Flags] public enum VkFragmentShadingRateTypeNV : uint   {
    VK_FRAGMENT_SHADING_RATE_TYPE_FRAGMENT_SIZE_NV = 0, 
    VK_FRAGMENT_SHADING_RATE_TYPE_ENUMS_NV = 1, 
    VK_FRAGMENT_SHADING_RATE_TYPE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_fragment_shading_rate_enums
[Flags] public enum VkFragmentShadingRateNV : uint   {
    VK_FRAGMENT_SHADING_RATE_1_INVOCATION_PER_PIXEL_NV = 0, 
    VK_FRAGMENT_SHADING_RATE_1_INVOCATION_PER_1X2_PIXELS_NV = 1, 
    VK_FRAGMENT_SHADING_RATE_1_INVOCATION_PER_2X1_PIXELS_NV = 4, 
    VK_FRAGMENT_SHADING_RATE_1_INVOCATION_PER_2X2_PIXELS_NV = 5, 
    VK_FRAGMENT_SHADING_RATE_1_INVOCATION_PER_2X4_PIXELS_NV = 6, 
    VK_FRAGMENT_SHADING_RATE_1_INVOCATION_PER_4X2_PIXELS_NV = 9, 
    VK_FRAGMENT_SHADING_RATE_1_INVOCATION_PER_4X4_PIXELS_NV = 10, 
    VK_FRAGMENT_SHADING_RATE_2_INVOCATIONS_PER_PIXEL_NV = 11, 
    VK_FRAGMENT_SHADING_RATE_4_INVOCATIONS_PER_PIXEL_NV = 12, 
    VK_FRAGMENT_SHADING_RATE_8_INVOCATIONS_PER_PIXEL_NV = 13, 
    VK_FRAGMENT_SHADING_RATE_16_INVOCATIONS_PER_PIXEL_NV = 14, 
    VK_FRAGMENT_SHADING_RATE_NO_INVOCATIONS_NV = 15, 
    VK_FRAGMENT_SHADING_RATE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_ray_tracing_motion_blur
[Flags] public enum VkAccelerationStructureMotionInstanceTypeNV : uint   {
    VK_ACCELERATION_STRUCTURE_MOTION_INSTANCE_TYPE_STATIC_NV = 0, 
    VK_ACCELERATION_STRUCTURE_MOTION_INSTANCE_TYPE_MATRIX_MOTION_NV = 1, 
    VK_ACCELERATION_STRUCTURE_MOTION_INSTANCE_TYPE_SRT_MOTION_NV = 2, 
    VK_ACCELERATION_STRUCTURE_MOTION_INSTANCE_TYPE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_EXT_image_compression_control
[Flags] public enum VkImageCompressionFlagBitsEXT : uint   {
    VK_IMAGE_COMPRESSION_DEFAULT_EXT = 0, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_DEFAULT_EXT = 0x00000001, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_EXPLICIT_EXT = 0x00000002, 
    VK_IMAGE_COMPRESSION_DISABLED_EXT = 0x00000004, 
    VK_IMAGE_COMPRESSION_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_image_compression_control
[Flags] public enum VkImageCompressionFixedRateFlagBitsEXT : uint   {
    VK_IMAGE_COMPRESSION_FIXED_RATE_NONE_EXT = 0, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_1BPC_BIT_EXT = 0x00000001, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_2BPC_BIT_EXT = 0x00000002, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_3BPC_BIT_EXT = 0x00000004, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_4BPC_BIT_EXT = 0x00000008, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_5BPC_BIT_EXT = 0x00000010, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_6BPC_BIT_EXT = 0x00000020, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_7BPC_BIT_EXT = 0x00000040, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_8BPC_BIT_EXT = 0x00000080, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_9BPC_BIT_EXT = 0x00000100, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_10BPC_BIT_EXT = 0x00000200, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_11BPC_BIT_EXT = 0x00000400, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_12BPC_BIT_EXT = 0x00000800, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_13BPC_BIT_EXT = 0x00001000, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_14BPC_BIT_EXT = 0x00002000, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_15BPC_BIT_EXT = 0x00004000, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_16BPC_BIT_EXT = 0x00008000, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_17BPC_BIT_EXT = 0x00010000, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_18BPC_BIT_EXT = 0x00020000, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_19BPC_BIT_EXT = 0x00040000, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_20BPC_BIT_EXT = 0x00080000, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_21BPC_BIT_EXT = 0x00100000, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_22BPC_BIT_EXT = 0x00200000, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_23BPC_BIT_EXT = 0x00400000, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_24BPC_BIT_EXT = 0x00800000, 
    VK_IMAGE_COMPRESSION_FIXED_RATE_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_device_fault
[Flags] public enum VkDeviceFaultAddressTypeEXT : uint   {
    VK_DEVICE_FAULT_ADDRESS_TYPE_NONE_EXT = 0, 
    VK_DEVICE_FAULT_ADDRESS_TYPE_READ_INVALID_EXT = 1, 
    VK_DEVICE_FAULT_ADDRESS_TYPE_WRITE_INVALID_EXT = 2, 
    VK_DEVICE_FAULT_ADDRESS_TYPE_EXECUTE_INVALID_EXT = 3, 
    VK_DEVICE_FAULT_ADDRESS_TYPE_INSTRUCTION_POINTER_UNKNOWN_EXT = 4, 
    VK_DEVICE_FAULT_ADDRESS_TYPE_INSTRUCTION_POINTER_INVALID_EXT = 5, 
    VK_DEVICE_FAULT_ADDRESS_TYPE_INSTRUCTION_POINTER_FAULT_EXT = 6, 
    VK_DEVICE_FAULT_ADDRESS_TYPE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_device_fault
[Flags] public enum VkDeviceFaultVendorBinaryHeaderVersionEXT : uint   {
    VK_DEVICE_FAULT_VENDOR_BINARY_HEADER_VERSION_ONE_EXT = 1, 
    VK_DEVICE_FAULT_VENDOR_BINARY_HEADER_VERSION_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_device_address_binding_report
[Flags] public enum VkDeviceAddressBindingTypeEXT : uint   {
    VK_DEVICE_ADDRESS_BINDING_TYPE_BIND_EXT = 0, 
    VK_DEVICE_ADDRESS_BINDING_TYPE_UNBIND_EXT = 1, 
    VK_DEVICE_ADDRESS_BINDING_TYPE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_device_address_binding_report
[Flags] public enum VkDeviceAddressBindingFlagBitsEXT : uint   {
    VK_DEVICE_ADDRESS_BINDING_INTERNAL_OBJECT_BIT_EXT = 0x00000001, 
    VK_DEVICE_ADDRESS_BINDING_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_frame_boundary
[Flags] public enum VkFrameBoundaryFlagBitsEXT : uint   {
    VK_FRAME_BOUNDARY_FRAME_END_BIT_EXT = 0x00000001, 
    VK_FRAME_BOUNDARY_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_opacity_micromap
[Flags] public enum VkMicromapTypeEXT : uint   {
    VK_MICROMAP_TYPE_OPACITY_MICROMAP_EXT = 0, 
    VK_MICROMAP_TYPE_DISPLACEMENT_MICROMAP_NV = 1000397000, 
    VK_MICROMAP_TYPE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_opacity_micromap
[Flags] public enum VkBuildMicromapModeEXT : uint   {
    VK_BUILD_MICROMAP_MODE_BUILD_EXT = 0, 
    VK_BUILD_MICROMAP_MODE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_opacity_micromap
[Flags] public enum VkCopyMicromapModeEXT : uint   {
    VK_COPY_MICROMAP_MODE_CLONE_EXT = 0, 
    VK_COPY_MICROMAP_MODE_SERIALIZE_EXT = 1, 
    VK_COPY_MICROMAP_MODE_DESERIALIZE_EXT = 2, 
    VK_COPY_MICROMAP_MODE_COMPACT_EXT = 3, 
    VK_COPY_MICROMAP_MODE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_opacity_micromap
[Flags] public enum VkOpacityMicromapFormatEXT : uint   {
    VK_OPACITY_MICROMAP_FORMAT_2_STATE_EXT = 1, 
    VK_OPACITY_MICROMAP_FORMAT_4_STATE_EXT = 2, 
    VK_OPACITY_MICROMAP_FORMAT_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_opacity_micromap
public enum VkOpacityMicromapSpecialIndexEXT   {
    VK_OPACITY_MICROMAP_SPECIAL_INDEX_FULLY_TRANSPARENT_EXT = -1, 
    VK_OPACITY_MICROMAP_SPECIAL_INDEX_FULLY_OPAQUE_EXT = -2, 
    VK_OPACITY_MICROMAP_SPECIAL_INDEX_FULLY_UNKNOWN_TRANSPARENT_EXT = -3, 
    VK_OPACITY_MICROMAP_SPECIAL_INDEX_FULLY_UNKNOWN_OPAQUE_EXT = -4, 
    VK_OPACITY_MICROMAP_SPECIAL_INDEX_CLUSTER_GEOMETRY_DISABLE_OPACITY_MICROMAP_NV = -5, 
    VK_OPACITY_MICROMAP_SPECIAL_INDEX_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_opacity_micromap
[Flags] public enum VkAccelerationStructureCompatibilityKHR : uint   {
    VK_ACCELERATION_STRUCTURE_COMPATIBILITY_COMPATIBLE_KHR = 0, 
    VK_ACCELERATION_STRUCTURE_COMPATIBILITY_INCOMPATIBLE_KHR = 1, 
    VK_ACCELERATION_STRUCTURE_COMPATIBILITY_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_EXT_opacity_micromap
[Flags] public enum VkAccelerationStructureBuildTypeKHR : uint   {
    VK_ACCELERATION_STRUCTURE_BUILD_TYPE_HOST_KHR = 0, 
    VK_ACCELERATION_STRUCTURE_BUILD_TYPE_DEVICE_KHR = 1, 
    VK_ACCELERATION_STRUCTURE_BUILD_TYPE_HOST_OR_DEVICE_KHR = 2, 
    VK_ACCELERATION_STRUCTURE_BUILD_TYPE_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_EXT_opacity_micromap
[Flags] public enum VkBuildMicromapFlagBitsEXT : uint   {
    VK_BUILD_MICROMAP_PREFER_FAST_TRACE_BIT_EXT = 0x00000001, 
    VK_BUILD_MICROMAP_PREFER_FAST_BUILD_BIT_EXT = 0x00000002, 
    VK_BUILD_MICROMAP_ALLOW_COMPACTION_BIT_EXT = 0x00000004, 
    VK_BUILD_MICROMAP_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_opacity_micromap
[Flags] public enum VkMicromapCreateFlagBitsEXT : uint   {
    VK_MICROMAP_CREATE_DEVICE_ADDRESS_CAPTURE_REPLAY_BIT_EXT = 0x00000001, 
    VK_MICROMAP_CREATE_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_NV_ray_tracing_linear_swept_spheres
[Flags] public enum VkRayTracingLssIndexingModeNV : uint   {
    VK_RAY_TRACING_LSS_INDEXING_MODE_LIST_NV = 0, 
    VK_RAY_TRACING_LSS_INDEXING_MODE_SUCCESSIVE_NV = 1, 
    VK_RAY_TRACING_LSS_INDEXING_MODE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_ray_tracing_linear_swept_spheres
[Flags] public enum VkRayTracingLssPrimitiveEndCapsModeNV : uint   {
    VK_RAY_TRACING_LSS_PRIMITIVE_END_CAPS_MODE_NONE_NV = 0, 
    VK_RAY_TRACING_LSS_PRIMITIVE_END_CAPS_MODE_CHAINED_NV = 1, 
    VK_RAY_TRACING_LSS_PRIMITIVE_END_CAPS_MODE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_EXT_subpass_merge_feedback
[Flags] public enum VkSubpassMergeStatusEXT : uint   {
    VK_SUBPASS_MERGE_STATUS_MERGED_EXT = 0, 
    VK_SUBPASS_MERGE_STATUS_DISALLOWED_EXT = 1, 
    VK_SUBPASS_MERGE_STATUS_NOT_MERGED_SIDE_EFFECTS_EXT = 2, 
    VK_SUBPASS_MERGE_STATUS_NOT_MERGED_SAMPLES_MISMATCH_EXT = 3, 
    VK_SUBPASS_MERGE_STATUS_NOT_MERGED_VIEWS_MISMATCH_EXT = 4, 
    VK_SUBPASS_MERGE_STATUS_NOT_MERGED_ALIASING_EXT = 5, 
    VK_SUBPASS_MERGE_STATUS_NOT_MERGED_DEPENDENCIES_EXT = 6, 
    VK_SUBPASS_MERGE_STATUS_NOT_MERGED_INCOMPATIBLE_INPUT_ATTACHMENT_EXT = 7, 
    VK_SUBPASS_MERGE_STATUS_NOT_MERGED_TOO_MANY_ATTACHMENTS_EXT = 8, 
    VK_SUBPASS_MERGE_STATUS_NOT_MERGED_INSUFFICIENT_STORAGE_EXT = 9, 
    VK_SUBPASS_MERGE_STATUS_NOT_MERGED_DEPTH_STENCIL_COUNT_EXT = 10, 
    VK_SUBPASS_MERGE_STATUS_NOT_MERGED_RESOLVE_ATTACHMENT_REUSE_EXT = 11, 
    VK_SUBPASS_MERGE_STATUS_NOT_MERGED_SINGLE_SUBPASS_EXT = 12, 
    VK_SUBPASS_MERGE_STATUS_NOT_MERGED_UNSPECIFIED_EXT = 13, 
    VK_SUBPASS_MERGE_STATUS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_LUNARG_direct_driver_loading
[Flags] public enum VkDirectDriverLoadingModeLUNARG : uint   {
    VK_DIRECT_DRIVER_LOADING_MODE_EXCLUSIVE_LUNARG = 0, 
    VK_DIRECT_DRIVER_LOADING_MODE_INCLUSIVE_LUNARG = 1, 
    VK_DIRECT_DRIVER_LOADING_MODE_MAX_ENUM_LUNARG = 0x7FFFFFFF 
};
// VK_NV_optical_flow
[Flags] public enum VkOpticalFlowPerformanceLevelNV : uint   {
    VK_OPTICAL_FLOW_PERFORMANCE_LEVEL_UNKNOWN_NV = 0, 
    VK_OPTICAL_FLOW_PERFORMANCE_LEVEL_SLOW_NV = 1, 
    VK_OPTICAL_FLOW_PERFORMANCE_LEVEL_MEDIUM_NV = 2, 
    VK_OPTICAL_FLOW_PERFORMANCE_LEVEL_FAST_NV = 3, 
    VK_OPTICAL_FLOW_PERFORMANCE_LEVEL_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_optical_flow
[Flags] public enum VkOpticalFlowSessionBindingPointNV : uint   {
    VK_OPTICAL_FLOW_SESSION_BINDING_POINT_UNKNOWN_NV = 0, 
    VK_OPTICAL_FLOW_SESSION_BINDING_POINT_INPUT_NV = 1, 
    VK_OPTICAL_FLOW_SESSION_BINDING_POINT_REFERENCE_NV = 2, 
    VK_OPTICAL_FLOW_SESSION_BINDING_POINT_HINT_NV = 3, 
    VK_OPTICAL_FLOW_SESSION_BINDING_POINT_FLOW_VECTOR_NV = 4, 
    VK_OPTICAL_FLOW_SESSION_BINDING_POINT_BACKWARD_FLOW_VECTOR_NV = 5, 
    VK_OPTICAL_FLOW_SESSION_BINDING_POINT_COST_NV = 6, 
    VK_OPTICAL_FLOW_SESSION_BINDING_POINT_BACKWARD_COST_NV = 7, 
    VK_OPTICAL_FLOW_SESSION_BINDING_POINT_GLOBAL_FLOW_NV = 8, 
    VK_OPTICAL_FLOW_SESSION_BINDING_POINT_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_optical_flow
[Flags] public enum VkOpticalFlowGridSizeFlagBitsNV : uint   {
    VK_OPTICAL_FLOW_GRID_SIZE_UNKNOWN_NV = 0, 
    VK_OPTICAL_FLOW_GRID_SIZE_1X1_BIT_NV = 0x00000001, 
    VK_OPTICAL_FLOW_GRID_SIZE_2X2_BIT_NV = 0x00000002, 
    VK_OPTICAL_FLOW_GRID_SIZE_4X4_BIT_NV = 0x00000004, 
    VK_OPTICAL_FLOW_GRID_SIZE_8X8_BIT_NV = 0x00000008, 
    VK_OPTICAL_FLOW_GRID_SIZE_FLAG_BITS_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_optical_flow
[Flags] public enum VkOpticalFlowUsageFlagBitsNV : uint   {
    VK_OPTICAL_FLOW_USAGE_UNKNOWN_NV = 0, 
    VK_OPTICAL_FLOW_USAGE_INPUT_BIT_NV = 0x00000001, 
    VK_OPTICAL_FLOW_USAGE_OUTPUT_BIT_NV = 0x00000002, 
    VK_OPTICAL_FLOW_USAGE_HINT_BIT_NV = 0x00000004, 
    VK_OPTICAL_FLOW_USAGE_COST_BIT_NV = 0x00000008, 
    VK_OPTICAL_FLOW_USAGE_GLOBAL_FLOW_BIT_NV = 0x00000010, 
    VK_OPTICAL_FLOW_USAGE_FLAG_BITS_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_optical_flow
[Flags] public enum VkOpticalFlowSessionCreateFlagBitsNV : uint   {
    VK_OPTICAL_FLOW_SESSION_CREATE_ENABLE_HINT_BIT_NV = 0x00000001, 
    VK_OPTICAL_FLOW_SESSION_CREATE_ENABLE_COST_BIT_NV = 0x00000002, 
    VK_OPTICAL_FLOW_SESSION_CREATE_ENABLE_GLOBAL_FLOW_BIT_NV = 0x00000004, 
    VK_OPTICAL_FLOW_SESSION_CREATE_ALLOW_REGIONS_BIT_NV = 0x00000008, 
    VK_OPTICAL_FLOW_SESSION_CREATE_BOTH_DIRECTIONS_BIT_NV = 0x00000010, 
    VK_OPTICAL_FLOW_SESSION_CREATE_FLAG_BITS_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_optical_flow
[Flags] public enum VkOpticalFlowExecuteFlagBitsNV : uint   {
    VK_OPTICAL_FLOW_EXECUTE_DISABLE_TEMPORAL_HINTS_BIT_NV = 0x00000001, 
    VK_OPTICAL_FLOW_EXECUTE_FLAG_BITS_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_AMD_anti_lag
[Flags] public enum VkAntiLagModeAMD : uint   {
    VK_ANTI_LAG_MODE_DRIVER_CONTROL_AMD = 0, 
    VK_ANTI_LAG_MODE_ON_AMD = 1, 
    VK_ANTI_LAG_MODE_OFF_AMD = 2, 
    VK_ANTI_LAG_MODE_MAX_ENUM_AMD = 0x7FFFFFFF 
};
// VK_AMD_anti_lag
[Flags] public enum VkAntiLagStageAMD : uint   {
    VK_ANTI_LAG_STAGE_INPUT_AMD = 0, 
    VK_ANTI_LAG_STAGE_PRESENT_AMD = 1, 
    VK_ANTI_LAG_STAGE_MAX_ENUM_AMD = 0x7FFFFFFF 
};
// VK_EXT_shader_object
[Flags] public enum VkShaderCodeTypeEXT : uint   {
    VK_SHADER_CODE_TYPE_BINARY_EXT = 0, 
    VK_SHADER_CODE_TYPE_SPIRV_EXT = 1, 
    VK_SHADER_CODE_TYPE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_shader_object
[Flags] public enum VkDepthClampModeEXT : uint   {
    VK_DEPTH_CLAMP_MODE_VIEWPORT_RANGE_EXT = 0, 
    VK_DEPTH_CLAMP_MODE_USER_DEFINED_RANGE_EXT = 1, 
    VK_DEPTH_CLAMP_MODE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_shader_object
[Flags] public enum VkShaderCreateFlagBitsEXT : uint   {
    VK_SHADER_CREATE_LINK_STAGE_BIT_EXT = 0x00000001, 
    VK_SHADER_CREATE_ALLOW_VARYING_SUBGROUP_SIZE_BIT_EXT = 0x00000002, 
    VK_SHADER_CREATE_REQUIRE_FULL_SUBGROUPS_BIT_EXT = 0x00000004, 
    VK_SHADER_CREATE_NO_TASK_SHADER_BIT_EXT = 0x00000008, 
    VK_SHADER_CREATE_DISPATCH_BASE_BIT_EXT = 0x00000010, 
    VK_SHADER_CREATE_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_EXT = 0x00000020, 
    VK_SHADER_CREATE_FRAGMENT_DENSITY_MAP_ATTACHMENT_BIT_EXT = 0x00000040, 
    VK_SHADER_CREATE_INDIRECT_BINDABLE_BIT_EXT = 0x00000080, 
    VK_SHADER_CREATE_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_NV_ray_tracing_invocation_reorder
[Flags] public enum VkRayTracingInvocationReorderModeNV : uint   {
    VK_RAY_TRACING_INVOCATION_REORDER_MODE_NONE_NV = 0, 
    VK_RAY_TRACING_INVOCATION_REORDER_MODE_REORDER_NV = 1, 
    VK_RAY_TRACING_INVOCATION_REORDER_MODE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_cooperative_vector
[Flags] public enum VkCooperativeVectorMatrixLayoutNV : uint   {
    VK_COOPERATIVE_VECTOR_MATRIX_LAYOUT_ROW_MAJOR_NV = 0, 
    VK_COOPERATIVE_VECTOR_MATRIX_LAYOUT_COLUMN_MAJOR_NV = 1, 
    VK_COOPERATIVE_VECTOR_MATRIX_LAYOUT_INFERENCING_OPTIMAL_NV = 2, 
    VK_COOPERATIVE_VECTOR_MATRIX_LAYOUT_TRAINING_OPTIMAL_NV = 3, 
    VK_COOPERATIVE_VECTOR_MATRIX_LAYOUT_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_EXT_layer_settings
[Flags] public enum VkLayerSettingTypeEXT : uint   {
    VK_LAYER_SETTING_TYPE_BOOL32_EXT = 0, 
    VK_LAYER_SETTING_TYPE_INT32_EXT = 1, 
    VK_LAYER_SETTING_TYPE_INT64_EXT = 2, 
    VK_LAYER_SETTING_TYPE_UINT32_EXT = 3, 
    VK_LAYER_SETTING_TYPE_UINT64_EXT = 4, 
    VK_LAYER_SETTING_TYPE_FLOAT32_EXT = 5, 
    VK_LAYER_SETTING_TYPE_FLOAT64_EXT = 6, 
    VK_LAYER_SETTING_TYPE_STRING_EXT = 7, 
    VK_LAYER_SETTING_TYPE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_NV_low_latency2
[Flags] public enum VkLatencyMarkerNV : uint   {
    VK_LATENCY_MARKER_SIMULATION_START_NV = 0, 
    VK_LATENCY_MARKER_SIMULATION_END_NV = 1, 
    VK_LATENCY_MARKER_RENDERSUBMIT_START_NV = 2, 
    VK_LATENCY_MARKER_RENDERSUBMIT_END_NV = 3, 
    VK_LATENCY_MARKER_PRESENT_START_NV = 4, 
    VK_LATENCY_MARKER_PRESENT_END_NV = 5, 
    VK_LATENCY_MARKER_INPUT_SAMPLE_NV = 6, 
    VK_LATENCY_MARKER_TRIGGER_FLASH_NV = 7, 
    VK_LATENCY_MARKER_OUT_OF_BAND_RENDERSUBMIT_START_NV = 8, 
    VK_LATENCY_MARKER_OUT_OF_BAND_RENDERSUBMIT_END_NV = 9, 
    VK_LATENCY_MARKER_OUT_OF_BAND_PRESENT_START_NV = 10, 
    VK_LATENCY_MARKER_OUT_OF_BAND_PRESENT_END_NV = 11, 
    VK_LATENCY_MARKER_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_low_latency2
[Flags] public enum VkOutOfBandQueueTypeNV : uint   {
    VK_OUT_OF_BAND_QUEUE_TYPE_RENDER_NV = 0, 
    VK_OUT_OF_BAND_QUEUE_TYPE_PRESENT_NV = 1, 
    VK_OUT_OF_BAND_QUEUE_TYPE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_QCOM_image_processing2
[Flags] public enum VkBlockMatchWindowCompareModeQCOM : uint   {
    VK_BLOCK_MATCH_WINDOW_COMPARE_MODE_MIN_QCOM = 0, 
    VK_BLOCK_MATCH_WINDOW_COMPARE_MODE_MAX_QCOM = 1, 
    VK_BLOCK_MATCH_WINDOW_COMPARE_MODE_MAX_ENUM_QCOM = 0x7FFFFFFF 
};
// VK_QCOM_filter_cubic_weights
[Flags] public enum VkCubicFilterWeightsQCOM : uint   {
    VK_CUBIC_FILTER_WEIGHTS_CATMULL_ROM_QCOM = 0, 
    VK_CUBIC_FILTER_WEIGHTS_ZERO_TANGENT_CARDINAL_QCOM = 1, 
    VK_CUBIC_FILTER_WEIGHTS_B_SPLINE_QCOM = 2, 
    VK_CUBIC_FILTER_WEIGHTS_MITCHELL_NETRAVALI_QCOM = 3, 
    VK_CUBIC_FILTER_WEIGHTS_MAX_ENUM_QCOM = 0x7FFFFFFF 
};
// VK_MSFT_layered_driver
[Flags] public enum VkLayeredDriverUnderlyingApiMSFT : uint   {
    VK_LAYERED_DRIVER_UNDERLYING_API_NONE_MSFT = 0, 
    VK_LAYERED_DRIVER_UNDERLYING_API_D3D12_MSFT = 1, 
    VK_LAYERED_DRIVER_UNDERLYING_API_MAX_ENUM_MSFT = 0x7FFFFFFF 
};
// VK_NV_display_stereo
[Flags] public enum VkDisplaySurfaceStereoTypeNV : uint   {
    VK_DISPLAY_SURFACE_STEREO_TYPE_NONE_NV = 0, 
    VK_DISPLAY_SURFACE_STEREO_TYPE_ONBOARD_DIN_NV = 1, 
    VK_DISPLAY_SURFACE_STEREO_TYPE_HDMI_3D_NV = 2, 
    VK_DISPLAY_SURFACE_STEREO_TYPE_INBAND_DISPLAYPORT_NV = 3, 
    VK_DISPLAY_SURFACE_STEREO_TYPE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_cluster_acceleration_structure
[Flags] public enum VkClusterAccelerationStructureTypeNV : uint   {
    VK_CLUSTER_ACCELERATION_STRUCTURE_TYPE_CLUSTERS_BOTTOM_LEVEL_NV = 0, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_TYPE_TRIANGLE_CLUSTER_NV = 1, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_TYPE_TRIANGLE_CLUSTER_TEMPLATE_NV = 2, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_TYPE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_cluster_acceleration_structure
[Flags] public enum VkClusterAccelerationStructureOpTypeNV : uint   {
    VK_CLUSTER_ACCELERATION_STRUCTURE_OP_TYPE_MOVE_OBJECTS_NV = 0, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_OP_TYPE_BUILD_CLUSTERS_BOTTOM_LEVEL_NV = 1, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_OP_TYPE_BUILD_TRIANGLE_CLUSTER_NV = 2, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_OP_TYPE_BUILD_TRIANGLE_CLUSTER_TEMPLATE_NV = 3, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_OP_TYPE_INSTANTIATE_TRIANGLE_CLUSTER_NV = 4, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_OP_TYPE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_cluster_acceleration_structure
[Flags] public enum VkClusterAccelerationStructureOpModeNV : uint   {
    VK_CLUSTER_ACCELERATION_STRUCTURE_OP_MODE_IMPLICIT_DESTINATIONS_NV = 0, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_OP_MODE_EXPLICIT_DESTINATIONS_NV = 1, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_OP_MODE_COMPUTE_SIZES_NV = 2, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_OP_MODE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_cluster_acceleration_structure
[Flags] public enum VkClusterAccelerationStructureAddressResolutionFlagBitsNV : uint   {
    VK_CLUSTER_ACCELERATION_STRUCTURE_ADDRESS_RESOLUTION_INDIRECTED_DST_IMPLICIT_DATA_BIT_NV = 0x00000001, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_ADDRESS_RESOLUTION_INDIRECTED_SCRATCH_DATA_BIT_NV = 0x00000002, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_ADDRESS_RESOLUTION_INDIRECTED_DST_ADDRESS_ARRAY_BIT_NV = 0x00000004, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_ADDRESS_RESOLUTION_INDIRECTED_DST_SIZES_ARRAY_BIT_NV = 0x00000008, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_ADDRESS_RESOLUTION_INDIRECTED_SRC_INFOS_ARRAY_BIT_NV = 0x00000010, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_ADDRESS_RESOLUTION_INDIRECTED_SRC_INFOS_COUNT_BIT_NV = 0x00000020, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_ADDRESS_RESOLUTION_FLAG_BITS_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_cluster_acceleration_structure
[Flags] public enum VkClusterAccelerationStructureClusterFlagBitsNV : uint   {
    VK_CLUSTER_ACCELERATION_STRUCTURE_CLUSTER_ALLOW_DISABLE_OPACITY_MICROMAPS_NV = 0x00000001, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_CLUSTER_FLAG_BITS_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_cluster_acceleration_structure
[Flags] public enum VkClusterAccelerationStructureGeometryFlagBitsNV : uint   {
    VK_CLUSTER_ACCELERATION_STRUCTURE_GEOMETRY_CULL_DISABLE_BIT_NV = 0x00000001, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_GEOMETRY_NO_DUPLICATE_ANYHIT_INVOCATION_BIT_NV = 0x00000002, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_GEOMETRY_OPAQUE_BIT_NV = 0x00000004, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_GEOMETRY_FLAG_BITS_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_cluster_acceleration_structure
[Flags] public enum VkClusterAccelerationStructureIndexFormatFlagBitsNV : uint   {
    VK_CLUSTER_ACCELERATION_STRUCTURE_INDEX_FORMAT_8BIT_NV = 0x00000001, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_INDEX_FORMAT_16BIT_NV = 0x00000002, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_INDEX_FORMAT_32BIT_NV = 0x00000004, 
    VK_CLUSTER_ACCELERATION_STRUCTURE_INDEX_FORMAT_FLAG_BITS_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_partitioned_acceleration_structure
[Flags] public enum VkPartitionedAccelerationStructureOpTypeNV : uint   {
    VK_PARTITIONED_ACCELERATION_STRUCTURE_OP_TYPE_WRITE_INSTANCE_NV = 0, 
    VK_PARTITIONED_ACCELERATION_STRUCTURE_OP_TYPE_UPDATE_INSTANCE_NV = 1, 
    VK_PARTITIONED_ACCELERATION_STRUCTURE_OP_TYPE_WRITE_PARTITION_TRANSLATION_NV = 2, 
    VK_PARTITIONED_ACCELERATION_STRUCTURE_OP_TYPE_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_NV_partitioned_acceleration_structure
[Flags] public enum VkPartitionedAccelerationStructureInstanceFlagBitsNV : uint   {
    VK_PARTITIONED_ACCELERATION_STRUCTURE_INSTANCE_FLAG_TRIANGLE_FACING_CULL_DISABLE_BIT_NV = 0x00000001, 
    VK_PARTITIONED_ACCELERATION_STRUCTURE_INSTANCE_FLAG_TRIANGLE_FLIP_FACING_BIT_NV = 0x00000002, 
    VK_PARTITIONED_ACCELERATION_STRUCTURE_INSTANCE_FLAG_FORCE_OPAQUE_BIT_NV = 0x00000004, 
    VK_PARTITIONED_ACCELERATION_STRUCTURE_INSTANCE_FLAG_FORCE_NO_OPAQUE_BIT_NV = 0x00000008, 
    VK_PARTITIONED_ACCELERATION_STRUCTURE_INSTANCE_FLAG_ENABLE_EXPLICIT_BOUNDING_BOX_NV = 0x00000010, 
    VK_PARTITIONED_ACCELERATION_STRUCTURE_INSTANCE_FLAG_BITS_MAX_ENUM_NV = 0x7FFFFFFF 
};
// VK_EXT_device_generated_commands
[Flags] public enum VkIndirectExecutionSetInfoTypeEXT : uint   {
    VK_INDIRECT_EXECUTION_SET_INFO_TYPE_PIPELINES_EXT = 0, 
    VK_INDIRECT_EXECUTION_SET_INFO_TYPE_SHADER_OBJECTS_EXT = 1, 
    VK_INDIRECT_EXECUTION_SET_INFO_TYPE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_device_generated_commands
[Flags] public enum VkIndirectCommandsTokenTypeEXT : uint   {
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_EXECUTION_SET_EXT = 0, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_PUSH_CONSTANT_EXT = 1, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_SEQUENCE_INDEX_EXT = 2, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_INDEX_BUFFER_EXT = 3, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_VERTEX_BUFFER_EXT = 4, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_DRAW_INDEXED_EXT = 5, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_DRAW_EXT = 6, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_DRAW_INDEXED_COUNT_EXT = 7, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_DRAW_COUNT_EXT = 8, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_DISPATCH_EXT = 9, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_DRAW_MESH_TASKS_NV_EXT = 1000202002, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_DRAW_MESH_TASKS_COUNT_NV_EXT = 1000202003, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_DRAW_MESH_TASKS_EXT = 1000328000, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_DRAW_MESH_TASKS_COUNT_EXT = 1000328001, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_TRACE_RAYS2_EXT = 1000386004, 
    VK_INDIRECT_COMMANDS_TOKEN_TYPE_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_device_generated_commands
[Flags] public enum VkIndirectCommandsInputModeFlagBitsEXT : uint   {
    VK_INDIRECT_COMMANDS_INPUT_MODE_VULKAN_INDEX_BUFFER_EXT = 0x00000001, 
    VK_INDIRECT_COMMANDS_INPUT_MODE_DXGI_INDEX_BUFFER_EXT = 0x00000002, 
    VK_INDIRECT_COMMANDS_INPUT_MODE_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_EXT_device_generated_commands
[Flags] public enum VkIndirectCommandsLayoutUsageFlagBitsEXT : uint   {
    VK_INDIRECT_COMMANDS_LAYOUT_USAGE_EXPLICIT_PREPROCESS_BIT_EXT = 0x00000001, 
    VK_INDIRECT_COMMANDS_LAYOUT_USAGE_UNORDERED_SEQUENCES_BIT_EXT = 0x00000002, 
    VK_INDIRECT_COMMANDS_LAYOUT_USAGE_FLAG_BITS_MAX_ENUM_EXT = 0x7FFFFFFF 
};
// VK_KHR_acceleration_structure
[Flags] public enum VkBuildAccelerationStructureModeKHR : uint   {
    VK_BUILD_ACCELERATION_STRUCTURE_MODE_BUILD_KHR = 0, 
    VK_BUILD_ACCELERATION_STRUCTURE_MODE_UPDATE_KHR = 1, 
    VK_BUILD_ACCELERATION_STRUCTURE_MODE_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_acceleration_structure
[Flags] public enum VkAccelerationStructureCreateFlagBitsKHR : uint   {
    VK_ACCELERATION_STRUCTURE_CREATE_DEVICE_ADDRESS_CAPTURE_REPLAY_BIT_KHR = 0x00000001, 
    VK_ACCELERATION_STRUCTURE_CREATE_DESCRIPTOR_BUFFER_CAPTURE_REPLAY_BIT_EXT = 0x00000008, 
    VK_ACCELERATION_STRUCTURE_CREATE_MOTION_BIT_NV = 0x00000004, 
    VK_ACCELERATION_STRUCTURE_CREATE_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF 
};
// VK_KHR_ray_tracing_pipeline
[Flags] public enum VkShaderGroupShaderKHR : uint   {
    VK_SHADER_GROUP_SHADER_GENERAL_KHR = 0, 
    VK_SHADER_GROUP_SHADER_CLOSEST_HIT_KHR = 1, 
    VK_SHADER_GROUP_SHADER_ANY_HIT_KHR = 2, 
    VK_SHADER_GROUP_SHADER_INTERSECTION_KHR = 3, 
    VK_SHADER_GROUP_SHADER_MAX_ENUM_KHR = 0x7FFFFFFF 
};

