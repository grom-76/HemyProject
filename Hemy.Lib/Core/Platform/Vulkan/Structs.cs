namespace Hemy.Lib.Core.Platform.Vulkan;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System;

using uint32_t = System.UInt32;
using uint64_t = System.UInt64;
using uint8_t = System.Byte;
using int32_t = System.Int32;
using int64_t = System.Int64;
using uint16_t = System.UInt16;
using ConstChar = System.Byte;
// using /* size_t */ nuint = System.UInt64;

using VkBool32 = System.UInt32;
using VkDeviceAddress = System.UInt64;
using VkDeviceSize = System.UInt64;
using VkSampleMask = System.UInt32;
using VkAccessFlags = System.UInt32;
using VkImageAspectFlags = System.UInt32;
using VkFormatFeatureFlags = System.UInt32;
using VkImageCreateFlags = System.UInt32;
using VkSampleCountFlags = System.UInt32;
using VkImageUsageFlags = System.UInt32;
using VkInstanceCreateFlags = System.UInt32;
using VkMemoryHeapFlags = System.UInt32;
using VkMemoryPropertyFlags = System.UInt32;
using VkQueueFlags = System.UInt32;
using VkDeviceCreateFlags = System.UInt32;
using VkDeviceQueueCreateFlags = System.UInt32;
using VkPipelineStageFlags = System.UInt32;
using VkMemoryMapFlags = System.UInt32;
using VkSparseMemoryBindFlags = System.UInt32;
using VkSparseImageFormatFlags = System.UInt32;
using VkFenceCreateFlags = System.UInt32;
using VkSemaphoreCreateFlags = System.UInt32;
using VkEventCreateFlags = System.UInt32;
using VkQueryPipelineStatisticFlags = System.UInt32;
using VkQueryPoolCreateFlags = System.UInt32;
using VkBufferCreateFlags = System.UInt32;
using VkBufferUsageFlags = System.UInt32;
using VkBufferViewCreateFlags = System.UInt32;
using VkImageViewCreateFlags = System.UInt32;
using VkShaderModuleCreateFlags = System.UInt32;
using VkPipelineCacheCreateFlags = System.UInt32;
using VkColorComponentFlags = System.UInt32;
using VkPipelineCreateFlags = System.UInt32;
using VkPipelineShaderStageCreateFlags = System.UInt32;
using VkCullModeFlags = System.UInt32;
using VkPipelineVertexInputStateCreateFlags = System.UInt32;
using VkPipelineInputAssemblyStateCreateFlags = System.UInt32;
using VkPipelineTessellationStateCreateFlags = System.UInt32;
using VkPipelineViewportStateCreateFlags = System.UInt32;
using VkPipelineRasterizationStateCreateFlags = System.UInt32;
using VkPipelineMultisampleStateCreateFlags = System.UInt32;
using VkPipelineDepthStencilStateCreateFlags = System.UInt32;
using VkPipelineColorBlendStateCreateFlags = System.UInt32;
using VkPipelineDynamicStateCreateFlags = System.UInt32;
using VkPipelineLayoutCreateFlags = System.UInt32;
using VkShaderStageFlags = System.UInt32;
using VkSamplerCreateFlags = System.UInt32;
using VkDescriptorPoolCreateFlags = System.UInt32;
using VkDescriptorSetLayoutCreateFlags = System.UInt32;
using VkAttachmentDescriptionFlags = System.UInt32;
using VkDependencyFlags = System.UInt32;
using VkFramebufferCreateFlags = System.UInt32;
using VkRenderPassCreateFlags = System.UInt32;
using VkSubpassDescriptionFlags = System.UInt32;
using VkCommandPoolCreateFlags = System.UInt32;
using VkCommandBufferUsageFlags = System.UInt32;
using VkQueryControlFlags = System.UInt32;
using VkSubgroupFeatureFlags = System.UInt32;
using VkMemoryAllocateFlags = System.UInt32;
using VkDescriptorUpdateTemplateCreateFlags = System.UInt32;
using VkExternalMemoryHandleTypeFlags = System.UInt32;
using VkExternalMemoryFeatureFlags = System.UInt32;
using VkExternalFenceHandleTypeFlags = System.UInt32;
using VkExternalFenceFeatureFlags = System.UInt32;
using VkFenceImportFlags = System.UInt32;
using VkSemaphoreImportFlags = System.UInt32;
using VkExternalSemaphoreHandleTypeFlags = System.UInt32;
using VkExternalSemaphoreFeatureFlags = System.UInt32;
using VkResolveModeFlags = System.UInt32;
using VkDescriptorBindingFlags = System.UInt32;
using VkSemaphoreWaitFlags = System.UInt32;
using VkPipelineCreationFeedbackFlags = System.UInt32;
using VkToolPurposeFlags = System.UInt32;
using VkPrivateDataSlotCreateFlags = System.UInt32;
using VkPipelineStageFlags2 = System.UInt64;
using VkAccessFlags2 = System.UInt64;
using VkSubmitFlags = System.UInt32;
using VkRenderingFlags = System.UInt32;
using VkFormatFeatureFlags2 = System.UInt64;
using VkMemoryUnmapFlags = System.UInt32;
using VkPipelineCreateFlags2 = System.UInt64;
using VkBufferUsageFlags2 = System.UInt64;
using VkHostImageCopyFlags = System.UInt32;
using VkCompositeAlphaFlagsKHR = System.UInt32;
using VkSurfaceTransformFlagsKHR = System.UInt32;
using VkSwapchainCreateFlagsKHR = System.UInt32;
using VkDeviceGroupPresentModeFlagsKHR = System.UInt32;
using VkDisplayModeCreateFlagsKHR = System.UInt32;
using VkDisplayPlaneAlphaFlagsKHR = System.UInt32;
using VkDisplaySurfaceCreateFlagsKHR = System.UInt32;
using VkVideoCodecOperationFlagsKHR = System.UInt32;
using VkVideoChromaSubsamplingFlagsKHR = System.UInt32;
using VkVideoComponentBitDepthFlagsKHR = System.UInt32;
using VkVideoCapabilityFlagsKHR = System.UInt32;
using VkVideoSessionCreateFlagsKHR = System.UInt32;
using VkVideoSessionParametersCreateFlagsKHR = System.UInt32;
using VkVideoBeginCodingFlagsKHR = System.UInt32;
using VkVideoEndCodingFlagsKHR = System.UInt32;
using VkVideoCodingControlFlagsKHR = System.UInt32;
using VkVideoDecodeCapabilityFlagsKHR = System.UInt32;
using VkVideoDecodeUsageFlagsKHR = System.UInt32;
using VkVideoDecodeFlagsKHR = System.UInt32;
using VkVideoEncodeH265CtbSizeFlagsKHR = System.UInt32;
using VkPerformanceCounterDescriptionFlagsKHR = System.UInt32;
using VkAcquireProfilingLockFlagsKHR = System.UInt32;
using VkVideoEncodeFlagsKHR = System.UInt32;
using VkVideoEncodeCapabilityFlagsKHR = System.UInt32;
using VkVideoEncodeRateControlModeFlagsKHR = System.UInt32;
using VkVideoEncodeFeedbackFlagsKHR = System.UInt32;
using VkVideoEncodeUsageFlagsKHR = System.UInt32;
using VkVideoEncodeContentFlagsKHR = System.UInt32;
using VkVideoEncodeRateControlFlagsKHR = System.UInt32;
using VkVideoEncodeAV1SuperblockSizeFlagsKHR = System.UInt32;
using VkAccessFlags3KHR = System.UInt64;
using VkPipelineRasterizationStateStreamCreateFlagsEXT = System.UInt32;
using VkExternalMemoryHandleTypeFlagsNV = System.UInt32;
using VkExternalMemoryFeatureFlagsNV = System.UInt32;
using VkConditionalRenderingFlagsEXT = System.UInt32;
using VkSurfaceCounterFlagsEXT = System.UInt32;
using VkPipelineViewportSwizzleStateCreateFlagsNV = System.UInt32;
using VkPipelineDiscardRectangleStateCreateFlagsEXT = System.UInt32;
using VkPipelineRasterizationConservativeStateCreateFlagsEXT = System.UInt32;
using VkPipelineRasterizationDepthClipStateCreateFlagsEXT = System.UInt32;
using VkDebugUtilsMessengerCallbackDataFlagsEXT = System.UInt32;
using VkPipelineCoverageToColorStateCreateFlagsNV = System.UInt32;
using VkPipelineCoverageModulationStateCreateFlagsNV = System.UInt32;
using VkValidationCacheCreateFlagsEXT = System.UInt32;
using VkAccelerationStructureTypeNV = VkAccelerationStructureTypeKHR;
using VkGeometryFlagsKHR = System.UInt32;
using VkBuildAccelerationStructureFlagsKHR = System.UInt32;
using VkBuildAccelerationStructureFlagsNV = System.UInt32;
using VkPipelineCompilerControlFlagsAMD = System.UInt32;
using VkShaderCorePropertiesFlagsAMD = System.UInt32;
using VkComponentTypeNV = VkComponentTypeKHR;
using VkScopeNV = VkScopeKHR;
using VkPipelineCoverageReductionStateCreateFlagsNV = System.UInt32;
using VkHeadlessSurfaceCreateFlagsEXT = System.UInt32;
using VkPresentScalingFlagsEXT = System.UInt32;
using VkPresentGravityFlagsEXT = System.UInt32;
using VkIndirectStateFlagsNV = System.UInt32;
using VkIndirectCommandsLayoutUsageFlagsNV = System.UInt32;
using VkDeviceMemoryReportFlagsEXT = System.UInt32;
using VkDeviceDiagnosticsConfigFlagsNV = System.UInt32;
using VkTileShadingRenderPassFlagsQCOM = System.UInt32;
using VkGraphicsPipelineLibraryFlagsEXT = System.UInt32;
using VkAccelerationStructureMotionInfoFlagsNV = System.UInt32;
using VkAccelerationStructureMotionInstanceFlagsNV = System.UInt32;
using VkImageCompressionFlagsEXT = System.UInt32;
using VkImageCompressionFixedRateFlagsEXT = System.UInt32;
using VkDeviceAddressBindingFlagsEXT = System.UInt32;
using VkFrameBoundaryFlagsEXT = System.UInt32;
using VkBuildMicromapFlagsEXT = System.UInt32;
using VkMicromapCreateFlagsEXT = System.UInt32;
using VkPhysicalDeviceSchedulingControlsFlagsARM = System.UInt64;
using VkMemoryDecompressionMethodFlagsNV = System.UInt64;
using VkDirectDriverLoadingFlagsLUNARG = System.UInt32;
using VkOpticalFlowGridSizeFlagsNV = System.UInt32;
using VkOpticalFlowUsageFlagsNV = System.UInt32;
using VkOpticalFlowSessionCreateFlagsNV = System.UInt32;
using VkOpticalFlowExecuteFlagsNV = System.UInt32;
using VkShaderCreateFlagsEXT = System.UInt32;
using VkClusterAccelerationStructureAddressResolutionFlagsNV = System.UInt32;
using VkClusterAccelerationStructureClusterFlagsNV = System.UInt32;
using VkPartitionedAccelerationStructureInstanceFlagsNV = System.UInt32;
using VkIndirectCommandsInputModeFlagsEXT = System.UInt32;
using VkIndirectCommandsLayoutUsageFlagsEXT = System.UInt32;
using VkAccelerationStructureCreateFlagsKHR = System.UInt32;

#region Unions

#region VK_KHR_performance_query
[StructLayout(LayoutKind.Explicit)]
public unsafe  struct VkPerformanceCounterResultKHR {
	[FieldOffset(0)]public  int  int32;
	[FieldOffset(0)]public  long  int64;
	[FieldOffset(0)]public  uint  uint32;
	[FieldOffset(0)]public  ulong  uint64;
	[FieldOffset(0)]public  float  float32;
	[FieldOffset(0)]public  double  float64;
}

#endregion

#region VK_KHR_pipeline_executable_properties
[StructLayout(LayoutKind.Explicit)]
public unsafe  struct VkPipelineExecutableStatisticValueKHR {
	[FieldOffset(0)]public  uint  b32;
	[FieldOffset(0)]public  long  i64;
	[FieldOffset(0)]public  ulong  u64;
	[FieldOffset(0)]public  double  f64;
}

#endregion

#region VK_INTEL_performance_query
[StructLayout(LayoutKind.Explicit)]
public unsafe  struct VkPerformanceValueDataINTEL {
	[FieldOffset(0)]public  uint  value32;
	[FieldOffset(0)]public  ulong  value64;
	[FieldOffset(0)]public  float  valueFloat;
	[FieldOffset(0)]public  uint  valueBool;
	[FieldOffset(0)]public  ConstChar*  valueString;
}

#endregion
#region VK_NV_ray_tracing_motion_blur
[StructLayout(LayoutKind.Explicit)]
public unsafe  struct VkDeviceOrHostAddressConstKHR {
	[FieldOffset(0)]public  ulong  deviceAddress;
	[FieldOffset(0)]public  void*  hostAddress;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe  struct VkAccelerationStructureMotionInstanceDataNV {
	[FieldOffset(0)]public  VkAccelerationStructureInstanceKHR  staticInstance;
	[FieldOffset(0)]public  VkAccelerationStructureMatrixMotionInstanceNV  matrixMotionInstance;
	[FieldOffset(0)]public  VkAccelerationStructureSRTMotionInstanceNV  srtMotionInstance;
}

#endregion
#region VK_EXT_opacity_micromap
[StructLayout(LayoutKind.Explicit)]
public unsafe  struct VkDeviceOrHostAddressKHR {
	[FieldOffset(0)]public  ulong  deviceAddress;
	[FieldOffset(0)]public  void*  hostAddress;
}

#endregion
#region VK_KHR_acceleration_structure
[StructLayout(LayoutKind.Explicit)]
public unsafe  struct VkAccelerationStructureGeometryDataKHR {
	[FieldOffset(0)]public  VkAccelerationStructureGeometryTrianglesDataKHR  triangles;
	[FieldOffset(0)]public  VkAccelerationStructureGeometryAabbsDataKHR  aabbs;
	[FieldOffset(0)]public  VkAccelerationStructureGeometryInstancesDataKHR  instances;
}

#endregion
#endregion

#region VK_VERSION_1_0

[StructLayout(LayoutKind.Explicit)]
public unsafe  struct VkClearColorValue {
	[FieldOffset(0)]public fixed float  float32[4];
	[FieldOffset(0)]public fixed int  int32[4];
	[FieldOffset(0)]public fixed uint  uint32[4];
	
	public VkClearColorValue(float r, float g, float b, float a = 1.0f): this()
    {     float32[0] = r;  float32[1] = g;   float32[2] = b;     float32[3] = a;    }
  	
	public VkClearColorValue(float[] color): this()
    {     float32[0] = color[0];  float32[1] = color[1];   float32[2] = color[2];     float32[3] = color[3];    }

	public VkClearColorValue(int r, int g, int b, int a = 255): this()
    {     int32[0] =r ;    int32[1] =g ; int32[2] =b ; int32[3] =a ;}

	public VkClearColorValue(uint r, uint g, uint b, uint a = 255): this()
    {     uint32[0] =r ;    uint32[1] =g ; uint32[2] =b ; uint32[3] =a ;}
    
	public VkClearColorValue(int[] color): this()
    {     int32[0] = color[0];  int32[1] = color[1];   int32[2] = color[2];    int32[3] = 255;    }

	public VkClearColorValue(uint[] color): this()
    {     uint32[0] = color[0];  uint32[1] = color[1];   uint32[2] = color[2];    uint32[3] = 255;    }
}

[StructLayout(LayoutKind.Explicit)]
public unsafe  struct VkClearValue {
	[FieldOffset(0)]public  VkClearColorValue  color;
	[FieldOffset(0)]public  VkClearDepthStencilValue  depthStencil;

	
	// public VkClearValue( float depth =0.0f, uint stencil=0)
    // {
    //     depthStencil =new(depth,stencil);
    // }

	public VkClearValue(float[] rgba  )
	{
        color = new(rgba);
	}

	public VkClearValue(int[] rgba  )
	{
        color = new(rgba);
	}

	public VkClearValue(uint[] rgba  )
	{
        color = new(rgba);
	}
}

#endregion

// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExtent2D {
	public     uint32_t    width; 
	public     uint32_t    height; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExtent3D {
	public     uint32_t    width; 
	public     uint32_t    height; 
	public     uint32_t    depth; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkOffset2D {
	public     int32_t    x; 
	public     int32_t    y; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkOffset3D {
	public     int32_t    x; 
	public     int32_t    y; 
	public     int32_t    z; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRect2D {
	public     VkOffset2D    offset; 
	public     VkExtent2D    extent; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBaseInStructure {
	public     VkStructureType                    sType; 
	public      VkBaseInStructure*    pNext; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBaseOutStructure {
	public     VkStructureType               sType; 
	public     VkBaseOutStructure*    pNext; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBufferMemoryBarrier {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkAccessFlags      srcAccessMask; 
	public     VkAccessFlags      dstAccessMask; 
	public     uint32_t           srcQueueFamilyIndex; 
	public     uint32_t           dstQueueFamilyIndex; 
	public     VkBuffer           buffer; 
	public     VkDeviceSize       offset; 
	public     VkDeviceSize       size; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDispatchIndirectCommand {
	public     uint32_t    x; 
	public     uint32_t    y; 
	public     uint32_t    z; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDrawIndexedIndirectCommand {
	public     uint32_t    indexCount; 
	public     uint32_t    instanceCount; 
	public     uint32_t    firstIndex; 
	public     int32_t     vertexOffset; 
	public     uint32_t    firstInstance; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDrawIndirectCommand {
	public     uint32_t    vertexCount; 
	public     uint32_t    instanceCount; 
	public     uint32_t    firstVertex; 
	public     uint32_t    firstInstance; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageSubresourceRange {
	public     VkImageAspectFlags    aspectMask; 
	public     uint32_t              baseMipLevel; 
	public     uint32_t              levelCount; 
	public     uint32_t              baseArrayLayer; 
	public     uint32_t              layerCount; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageMemoryBarrier {
	public     VkStructureType            sType; 
	public      void*                pNext; 
	public     VkAccessFlags              srcAccessMask; 
	public     VkAccessFlags              dstAccessMask; 
	public     VkImageLayout              oldLayout; 
	public     VkImageLayout              newLayout; 
	public     uint32_t                   srcQueueFamilyIndex; 
	public     uint32_t                   dstQueueFamilyIndex; 
	public     VkImage                    image; 
	public     VkImageSubresourceRange    subresourceRange; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryBarrier {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkAccessFlags      srcAccessMask; 
	public     VkAccessFlags      dstAccessMask; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineCacheHeaderVersionOne {
	public     uint32_t                        headerSize; 
	public     VkPipelineCacheHeaderVersion    headerVersion; 
	public     uint32_t                        vendorID; 
	public     uint32_t                        deviceID; 
	public fixed     uint8_t                         pipelineCacheUUID[(int)VK.VK_UUID_SIZE]; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAllocationCallbacks {
	public  void*  pUserData;
	public  delegate* unmanaged< void*,nuint,nuint,VkSystemAllocationScope,void* >  pfnAllocation;
	public  delegate* unmanaged< void*,void*,nuint,nuint,VkSystemAllocationScope,void* >  pfnReallocation;
	public  delegate* unmanaged< void*,void*,void >  pfnFree;
	public  delegate* unmanaged< void*,nuint,VkInternalAllocationType,VkSystemAllocationScope,void >  pfnInternalAllocation;
	public  delegate* unmanaged< void*,nuint,VkInternalAllocationType,VkSystemAllocationScope,void >  pfnInternalFree;
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkApplicationInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public      ConstChar*        pApplicationName; 
	public     uint32_t           applicationVersion; 
	public      ConstChar*        pEngineName; 
	public     uint32_t           engineVersion; 
	public     uint32_t           apiVersion; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkFormatProperties {
	public     VkFormatFeatureFlags    linearTilingFeatures; 
	public     VkFormatFeatureFlags    optimalTilingFeatures; 
	public     VkFormatFeatureFlags    bufferFeatures; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageFormatProperties {
	public     VkExtent3D            maxExtent; 
	public     uint32_t              maxMipLevels; 
	public     uint32_t              maxArrayLayers; 
	public     VkSampleCountFlags    sampleCounts; 
	public     VkDeviceSize          maxResourceSize; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkInstanceCreateInfo {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkInstanceCreateFlags       flags; 
	public      VkApplicationInfo*    pApplicationInfo; 
	public     uint32_t                    enabledLayerCount; 
	public      ConstChar**          ppEnabledLayerNames; 
	public     uint32_t                    enabledExtensionCount; 
	public      ConstChar**          ppEnabledExtensionNames; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryHeap {
	public     VkDeviceSize         size; 
	public     VkMemoryHeapFlags    flags; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryType {
	public     VkMemoryPropertyFlags    propertyFlags; 
	public     uint32_t                 heapIndex; 
}
// VK_VERSION_1_0
// [ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFeatures {
	public     VkBool32    robustBufferAccess; 
	public     VkBool32    fullDrawIndexUint32; 
	public     VkBool32    imageCubeArray; 
	public     VkBool32    independentBlend; 
	public     VkBool32    geometryShader; 
	public     VkBool32    tessellationShader; 
	public     VkBool32    sampleRateShading; 
	public     VkBool32    dualSrcBlend; 
	public     VkBool32    logicOp; 
	public     VkBool32    multiDrawIndirect; 
	public     VkBool32    drawIndirectFirstInstance; 
	public     VkBool32    depthClamp; 
	public     VkBool32    depthBiasClamp; 
	public     VkBool32    fillModeNonSolid; 
	public     VkBool32    depthBounds; 
	public     VkBool32    wideLines; 
	public     VkBool32    largePoints; 
	public     VkBool32    alphaToOne; 
	public     VkBool32    multiViewport; 
	public     VkBool32    samplerAnisotropy; 
	public     VkBool32    textureCompressionETC2; 
	public     VkBool32    textureCompressionASTC_LDR; 
	public     VkBool32    textureCompressionBC; 
	public     VkBool32    occlusionQueryPrecise; 
	public     VkBool32    pipelineStatisticsQuery; 
	public     VkBool32    vertexPipelineStoresAndAtomics; 
	public     VkBool32    fragmentStoresAndAtomics; 
	public     VkBool32    shaderTessellationAndGeometryPointSize; 
	public     VkBool32    shaderImageGatherExtended; 
	public     VkBool32    shaderStorageImageExtendedFormats; 
	public     VkBool32    shaderStorageImageMultisample; 
	public     VkBool32    shaderStorageImageReadWithoutFormat; 
	public     VkBool32    shaderStorageImageWriteWithoutFormat; 
	public     VkBool32    shaderUniformBufferArrayDynamicIndexing; 
	public     VkBool32    shaderSampledImageArrayDynamicIndexing; 
	public     VkBool32    shaderStorageBufferArrayDynamicIndexing; 
	public     VkBool32    shaderStorageImageArrayDynamicIndexing; 
	public     VkBool32    shaderClipDistance; 
	public     VkBool32    shaderCullDistance; 
	public     VkBool32    shaderFloat64; 
	public     VkBool32    shaderInt64; 
	public     VkBool32    shaderInt16; 
	public     VkBool32    shaderResourceResidency; 
	public     VkBool32    shaderResourceMinLod; 
	public     VkBool32    sparseBinding; 
	public     VkBool32    sparseResidencyBuffer; 
	public     VkBool32    sparseResidencyImage2D; 
	public     VkBool32    sparseResidencyImage3D; 
	public     VkBool32    sparseResidency2Samples; 
	public     VkBool32    sparseResidency4Samples; 
	public     VkBool32    sparseResidency8Samples; 
	public     VkBool32    sparseResidency16Samples; 
	public     VkBool32    sparseResidencyAliased; 
	public     VkBool32    variableMultisampleRate; 
	public     VkBool32    inheritedQueries; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceLimits {
	public     uint32_t              maxImageDimension1D; 
	public     uint32_t              maxImageDimension2D; 
	public     uint32_t              maxImageDimension3D; 
	public     uint32_t              maxImageDimensionCube; 
	public     uint32_t              maxImageArrayLayers; 
	public     uint32_t              maxTexelBufferElements; 
	public     uint32_t              maxUniformBufferRange; 
	public     uint32_t              maxStorageBufferRange; 
	public     uint32_t              maxPushConstantsSize; 
	public     uint32_t              maxMemoryAllocationCount; 
	public     uint32_t              maxSamplerAllocationCount; 
	public     VkDeviceSize          bufferImageGranularity; 
	public     VkDeviceSize          sparseAddressSpaceSize; 
	public     uint32_t              maxBoundDescriptorSets; 
	public     uint32_t              maxPerStageDescriptorSamplers; 
	public     uint32_t              maxPerStageDescriptorUniformBuffers; 
	public     uint32_t              maxPerStageDescriptorStorageBuffers; 
	public     uint32_t              maxPerStageDescriptorSampledImages; 
	public     uint32_t              maxPerStageDescriptorStorageImages; 
	public     uint32_t              maxPerStageDescriptorInputAttachments; 
	public     uint32_t              maxPerStageResources; 
	public     uint32_t              maxDescriptorSetSamplers; 
	public     uint32_t              maxDescriptorSetUniformBuffers; 
	public     uint32_t              maxDescriptorSetUniformBuffersDynamic; 
	public     uint32_t              maxDescriptorSetStorageBuffers; 
	public     uint32_t              maxDescriptorSetStorageBuffersDynamic; 
	public     uint32_t              maxDescriptorSetSampledImages; 
	public     uint32_t              maxDescriptorSetStorageImages; 
	public     uint32_t              maxDescriptorSetInputAttachments; 
	public     uint32_t              maxVertexInputAttributes; 
	public     uint32_t              maxVertexInputBindings; 
	public     uint32_t              maxVertexInputAttributeOffset; 
	public     uint32_t              maxVertexInputBindingStride; 
	public     uint32_t              maxVertexOutputComponents; 
	public     uint32_t              maxTessellationGenerationLevel; 
	public     uint32_t              maxTessellationPatchSize; 
	public     uint32_t              maxTessellationControlPerVertexInputComponents; 
	public     uint32_t              maxTessellationControlPerVertexOutputComponents; 
	public     uint32_t              maxTessellationControlPerPatchOutputComponents; 
	public     uint32_t              maxTessellationControlTotalOutputComponents; 
	public     uint32_t              maxTessellationEvaluationInputComponents; 
	public     uint32_t              maxTessellationEvaluationOutputComponents; 
	public     uint32_t              maxGeometryShaderInvocations; 
	public     uint32_t              maxGeometryInputComponents; 
	public     uint32_t              maxGeometryOutputComponents; 
	public     uint32_t              maxGeometryOutputVertices; 
	public     uint32_t              maxGeometryTotalOutputComponents; 
	public     uint32_t              maxFragmentInputComponents; 
	public     uint32_t              maxFragmentOutputAttachments; 
	public     uint32_t              maxFragmentDualSrcAttachments; 
	public     uint32_t              maxFragmentCombinedOutputResources; 
	public     uint32_t              maxComputeSharedMemorySize; 
	public fixed     uint32_t              maxComputeWorkGroupCount[3]; 
	public     uint32_t              maxComputeWorkGroupInvocations; 
	public fixed     uint32_t              maxComputeWorkGroupSize[3]; 
	public     uint32_t              subPixelPrecisionBits; 
	public     uint32_t              subTexelPrecisionBits; 
	public     uint32_t              mipmapPrecisionBits; 
	public     uint32_t              maxDrawIndexedIndexValue; 
	public     uint32_t              maxDrawIndirectCount; 
	public     float                 maxSamplerLodBias; 
	public     float                 maxSamplerAnisotropy; 
	public     uint32_t              maxViewports; 
	public fixed     uint32_t              maxViewportDimensions[2]; 
	public fixed     float                 viewportBoundsRange[2]; 
	public     uint32_t              viewportSubPixelBits; 
	public     /* size_t */ nuint                minMemoryMapAlignment; 
	public     VkDeviceSize          minTexelBufferOffsetAlignment; 
	public     VkDeviceSize          minUniformBufferOffsetAlignment; 
	public     VkDeviceSize          minStorageBufferOffsetAlignment; 
	public     int32_t               minTexelOffset; 
	public     uint32_t              maxTexelOffset; 
	public     int32_t               minTexelGatherOffset; 
	public     uint32_t              maxTexelGatherOffset; 
	public     float                 minInterpolationOffset; 
	public     float                 maxInterpolationOffset; 
	public     uint32_t              subPixelInterpolationOffsetBits; 
	public     uint32_t              maxFramebufferWidth; 
	public     uint32_t              maxFramebufferHeight; 
	public     uint32_t              maxFramebufferLayers; 
	public     VkSampleCountFlags    framebufferColorSampleCounts; 
	public     VkSampleCountFlags    framebufferDepthSampleCounts; 
	public     VkSampleCountFlags    framebufferStencilSampleCounts; 
	public     VkSampleCountFlags    framebufferNoAttachmentsSampleCounts; 
	public     uint32_t              maxColorAttachments; 
	public     VkSampleCountFlags    sampledImageColorSampleCounts; 
	public     VkSampleCountFlags    sampledImageIntegerSampleCounts; 
	public     VkSampleCountFlags    sampledImageDepthSampleCounts; 
	public     VkSampleCountFlags    sampledImageStencilSampleCounts; 
	public     VkSampleCountFlags    storageImageSampleCounts; 
	public     uint32_t              maxSampleMaskWords; 
	public     VkBool32              timestampComputeAndGraphics; 
	public     float                 timestampPeriod; 
	public     uint32_t              maxClipDistances; 
	public     uint32_t              maxCullDistances; 
	public     uint32_t              maxCombinedClipAndCullDistances; 
	public     uint32_t              discreteQueuePriorities; 
	public fixed     float                 pointSizeRange[2]; 
	public fixed     float                 lineWidthRange[2]; 
	public     float                 pointSizeGranularity; 
	public     float                 lineWidthGranularity; 
	public     VkBool32              strictLines; 
	public     VkBool32              standardSampleLocations; 
	public     VkDeviceSize          optimalBufferCopyOffsetAlignment; 
	public     VkDeviceSize          optimalBufferCopyRowPitchAlignment; 
	public     VkDeviceSize          nonCoherentAtomSize; 
}
// VK_VERSION_1_0
// [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE), SkipLocalsInit]
// public unsafe struct VkPhysicalDeviceMemoryProperties
// {
// 	public uint32_t memoryTypeCount;
// 	public VkMemoryType** memoryTypes; //[(int)VK.VK_MAX_MEMORY_TYPES]; 
// 	public uint32_t memoryHeapCount;
// 	public VkMemoryHeap** memoryHeaps; //[(int)VK.VK_MAX_MEMORY_HEAPS]; 
// }
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE), SkipLocalsInit]
public partial struct VkPhysicalDeviceMemoryProperties
{
	public uint memoryTypeCount;
	public memoryTypes__FixedBuffer memoryTypes;

	[InlineArray((int)VK.VK_MAX_MEMORY_TYPES)]
	public partial struct memoryTypes__FixedBuffer
	{
		public VkMemoryType e0;
	}
	public uint memoryHeapCount;
	public memoryHeaps__FixedBuffer memoryHeaps;

	[InlineArray((int)VK.VK_MAX_MEMORY_HEAPS)]
	public partial struct memoryHeaps__FixedBuffer
	{
		public VkMemoryHeap e0;
	}
}
// VK_VERSION_1_0
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE), SkipLocalsInit]
public unsafe  struct VkPhysicalDeviceSparseProperties {
	public     VkBool32    residencyStandard2DBlockShape; 
	public     VkBool32    residencyStandard2DMultisampleBlockShape; 
	public     VkBool32    residencyStandard3DBlockShape; 
	public     VkBool32    residencyAlignedMipSize; 
	public     VkBool32    residencyNonResidentStrict; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceProperties {
	public     uint32_t                            apiVersion; 
	public     uint32_t                            driverVersion; 
	public     uint32_t                            vendorID; 
	public     uint32_t                            deviceID; 
	public     VkPhysicalDeviceType                deviceType; 
	public fixed byte                                deviceName[(int)VK.VK_MAX_PHYSICAL_DEVICE_NAME_SIZE]; 
	public fixed     uint8_t                             pipelineCacheUUID[(int)VK.VK_UUID_SIZE]; 
	public     VkPhysicalDeviceLimits              limits; 
	public     VkPhysicalDeviceSparseProperties    sparseProperties; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkQueueFamilyProperties {
	public     VkQueueFlags    queueFlags; 
	public     uint32_t        queueCount; 
	public     uint32_t        timestampValidBits; 
	public     VkExtent3D      minImageTransferGranularity; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceQueueCreateInfo {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkDeviceQueueCreateFlags    flags; 
	public     uint32_t                    queueFamilyIndex; 
	public     uint32_t                    queueCount; 
	public      float*                pQueuePriorities; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceCreateInfo {
	public     VkStructureType                    sType; 
	public      void*                        pNext; 
	public     VkDeviceCreateFlags                flags; 
	public     uint32_t                           queueCreateInfoCount; 
	public      VkDeviceQueueCreateInfo*     pQueueCreateInfos; 
	 // enabledLayerCount is deprecated and should not be used 
	public     uint32_t                           enabledLayerCount; 
	// ppEnabledLayerNames is deprecated and should not be used 
	public      ConstChar**                 ppEnabledLayerNames; 
	public     uint32_t                           enabledExtensionCount; 
	public      ConstChar**                 ppEnabledExtensionNames; 
	public      VkPhysicalDeviceFeatures*    pEnabledFeatures; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExtensionProperties {
	public fixed byte        extensionName[(int)VK.VK_MAX_EXTENSION_NAME_SIZE]; 
	public     uint32_t    specVersion; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkLayerProperties {
	public fixed byte        layerName[(int)VK.VK_MAX_EXTENSION_NAME_SIZE]; 
	public     uint32_t    specVersion; 
	public     uint32_t    implementationVersion; 
	public fixed byte        description[(int)VK.VK_MAX_DESCRIPTION_SIZE]; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSubmitInfo {
	public     VkStructureType                sType; 
	public      void*                    pNext; 
	public     uint32_t                       waitSemaphoreCount; 
	public      VkSemaphore*             pWaitSemaphores; 
	public      VkPipelineStageFlags*    pWaitDstStageMask; 
	public     uint32_t                       commandBufferCount; 
	public      VkCommandBuffer*         pCommandBuffers; 
	public     uint32_t                       signalSemaphoreCount; 
	public      VkSemaphore*             pSignalSemaphores; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMappedMemoryRange {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkDeviceMemory     memory; 
	public     VkDeviceSize       offset; 
	public     VkDeviceSize       size; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryAllocateInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkDeviceSize       allocationSize; 
	public     uint32_t           memoryTypeIndex; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryRequirements {
	public     VkDeviceSize    size; 
	public     VkDeviceSize    alignment; 
	public     uint32_t        memoryTypeBits; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSparseMemoryBind {
	public     VkDeviceSize               resourceOffset; 
	public     VkDeviceSize               size; 
	public     VkDeviceMemory             memory; 
	public     VkDeviceSize               memoryOffset; 
	public     VkSparseMemoryBindFlags    flags; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSparseBufferMemoryBindInfo {
	public     VkBuffer                     buffer; 
	public     uint32_t                     bindCount; 
	public      VkSparseMemoryBind*    pBinds; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSparseImageOpaqueMemoryBindInfo {
	public     VkImage                      image; 
	public     uint32_t                     bindCount; 
	public      VkSparseMemoryBind*    pBinds; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageSubresource {
	public     VkImageAspectFlags    aspectMask; 
	public     uint32_t              mipLevel; 
	public     uint32_t              arrayLayer; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSparseImageMemoryBind {
	public     VkImageSubresource         subresource; 
	public     VkOffset3D                 offset; 
	public     VkExtent3D                 extent; 
	public     VkDeviceMemory             memory; 
	public     VkDeviceSize               memoryOffset; 
	public     VkSparseMemoryBindFlags    flags; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSparseImageMemoryBindInfo {
	public     VkImage                           image; 
	public     uint32_t                          bindCount; 
	public      VkSparseImageMemoryBind*    pBinds; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindSparseInfo {
	public     VkStructureType                             sType; 
	public      void*                                 pNext; 
	public     uint32_t                                    waitSemaphoreCount; 
	public      VkSemaphore*                          pWaitSemaphores; 
	public     uint32_t                                    bufferBindCount; 
	public      VkSparseBufferMemoryBindInfo*         pBufferBinds; 
	public     uint32_t                                    imageOpaqueBindCount; 
	public      VkSparseImageOpaqueMemoryBindInfo*    pImageOpaqueBinds; 
	public     uint32_t                                    imageBindCount; 
	public      VkSparseImageMemoryBindInfo*          pImageBinds; 
	public     uint32_t                                    signalSemaphoreCount; 
	public      VkSemaphore*                          pSignalSemaphores; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSparseImageFormatProperties {
	public     VkImageAspectFlags          aspectMask; 
	public     VkExtent3D                  imageGranularity; 
	public     VkSparseImageFormatFlags    flags; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSparseImageMemoryRequirements {
	public     VkSparseImageFormatProperties    formatProperties; 
	public     uint32_t                         imageMipTailFirstLod; 
	public     VkDeviceSize                     imageMipTailSize; 
	public     VkDeviceSize                     imageMipTailOffset; 
	public     VkDeviceSize                     imageMipTailStride; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkFenceCreateInfo {
	public     VkStructureType       sType; 
	public      void*           pNext; 
	public     VkFenceCreateFlags    flags; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  // [StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE),
public unsafe  struct VkSemaphoreCreateInfo {
	public     VkStructureType           sType; 
	public      void*               pNext; 
	public     VkSemaphoreCreateFlags    flags; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkEventCreateInfo {
	public     VkStructureType       sType; 
	public      void*           pNext; 
	public     VkEventCreateFlags    flags; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkQueryPoolCreateInfo {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkQueryPoolCreateFlags           flags; 
	public     VkQueryType                      queryType; 
	public     uint32_t                         queryCount; 
	public     VkQueryPipelineStatisticFlags    pipelineStatistics; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBufferCreateInfo {
	public     VkStructureType        sType; 
	public      void*            pNext; 
	public     VkBufferCreateFlags    flags; 
	public     VkDeviceSize           size; 
	public     VkBufferUsageFlags     usage; 
	public     VkSharingMode          sharingMode; 
	public     uint32_t               queueFamilyIndexCount; 
	public      uint32_t*        pQueueFamilyIndices; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBufferViewCreateInfo {
	public     VkStructureType            sType; 
	public      void*                pNext; 
	public     VkBufferViewCreateFlags    flags; 
	public     VkBuffer                   buffer; 
	public     VkFormat                   format; 
	public     VkDeviceSize               offset; 
	public     VkDeviceSize               range; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageCreateInfo {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     VkImageCreateFlags       flags; 
	public     VkImageType              imageType; 
	public     VkFormat                 format; 
	public     VkExtent3D               extent; 
	public     uint32_t                 mipLevels; 
	public     uint32_t                 arrayLayers; 
	public     VkSampleCountFlagBits    samples; 
	public     VkImageTiling            tiling; 
	public     VkImageUsageFlags        usage; 
	public     VkSharingMode            sharingMode; 
	public     uint32_t                 queueFamilyIndexCount; 
	public      uint32_t*          pQueueFamilyIndices; 
	public     VkImageLayout            initialLayout; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSubresourceLayout {
	public     VkDeviceSize    offset; 
	public     VkDeviceSize    size; 
	public     VkDeviceSize    rowPitch; 
	public     VkDeviceSize    arrayPitch; 
	public     VkDeviceSize    depthPitch; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkComponentMapping {
	public     VkComponentSwizzle    r; 
	public     VkComponentSwizzle    g; 
	public     VkComponentSwizzle    b; 
	public     VkComponentSwizzle    a; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageViewCreateInfo {
	public     VkStructureType            sType; 
	public      void*                pNext; 
	public     VkImageViewCreateFlags     flags; 
	public     VkImage                    image; 
	public     VkImageViewType            viewType; 
	public     VkFormat                   format; 
	public     VkComponentMapping         components; 
	public     VkImageSubresourceRange    subresourceRange; 
}
// VK_VERSION_1_0
[StructLayout(LayoutKind.Sequential )]
public unsafe struct VkShaderModuleCreateInfo
{
	public VkStructureType sType;
	public void* pNext;
	public uint flags;
	public nuint codeSize;
	public uint32_t* pCode;
}

// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineCacheCreateInfo {
	public     VkStructureType               sType; 
	public      void*                   pNext; 
	public     VkPipelineCacheCreateFlags    flags; 
	public     /* size_t */ nuint                        initialDataSize; 
	public      void*                   pInitialData; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSpecializationMapEntry {
	public     uint32_t    constantID; 
	public     uint32_t    offset; 
	public     /* size_t */ nuint      size; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSpecializationInfo {
	public     uint32_t                           mapEntryCount; 
	public      VkSpecializationMapEntry*    pMapEntries; 
	public     /* size_t */ nuint                             dataSize; 
	public      void*                        pData; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineShaderStageCreateInfo {
	public     VkStructureType                     sType; 
	public      void*                         pNext; 
	public     VkPipelineShaderStageCreateFlags    flags; 
	public     VkShaderStageFlagBits               stage; 
	public     VkShaderModule                      module; 
	public      ConstChar*                         pName; 
	public      VkSpecializationInfo*         pSpecializationInfo; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkComputePipelineCreateInfo {
	public     VkStructureType                    sType; 
	public      void*                        pNext; 
	public     VkPipelineCreateFlags              flags; 
	public     VkPipelineShaderStageCreateInfo    stage; 
	public     VkPipelineLayout                   layout; 
	public     VkPipeline                         basePipelineHandle; 
	public     int32_t                            basePipelineIndex; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVertexInputBindingDescription {
	public     uint32_t             binding; 
	public     uint32_t             stride; 
	public     VkVertexInputRate    inputRate; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVertexInputAttributeDescription {
	public     uint32_t    location; 
	public     uint32_t    binding; 
	public     VkFormat    format; 
	public     uint32_t    offset; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineVertexInputStateCreateInfo {
	public     VkStructureType                             sType; 
	public      void*                                 pNext; 
	public     VkPipelineVertexInputStateCreateFlags       flags; 
	public     uint32_t                                    vertexBindingDescriptionCount; 
	public      VkVertexInputBindingDescription*      pVertexBindingDescriptions; 
	public     uint32_t                                    vertexAttributeDescriptionCount; 
	public      VkVertexInputAttributeDescription*    pVertexAttributeDescriptions; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineInputAssemblyStateCreateInfo {
	public     VkStructureType                            sType; 
	public      void*                                pNext; 
	public     VkPipelineInputAssemblyStateCreateFlags    flags; 
	public     VkPrimitiveTopology                        topology; 
	public     VkBool32                                   primitiveRestartEnable; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineTessellationStateCreateInfo {
	public     VkStructureType                           sType; 
	public      void*                               pNext; 
	public     VkPipelineTessellationStateCreateFlags    flags; 
	public     uint32_t                                  patchControlPoints; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkViewport {
	public     float    x; 
	public     float    y; 
	public     float    width; 
	public     float    height; 
	public     float    minDepth; 
	public     float    maxDepth; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineViewportStateCreateInfo {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkPipelineViewportStateCreateFlags    flags; 
	public     uint32_t                              viewportCount; 
	public      VkViewport*                     pViewports; 
	public     uint32_t                              scissorCount; 
	public      VkRect2D*                       pScissors; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineRasterizationStateCreateInfo {
	public     VkStructureType                            sType; 
	public      void*                                pNext; 
	public     VkPipelineRasterizationStateCreateFlags    flags; 
	public     VkBool32                                   depthClampEnable; 
	public     VkBool32                                   rasterizerDiscardEnable; 
	public     VkPolygonMode                              polygonMode; 
	public     VkCullModeFlags                            cullMode; 
	public     VkFrontFace                                frontFace; 
	public     VkBool32                                   depthBiasEnable; 
	public     float                                      depthBiasConstantFactor; 
	public     float                                      depthBiasClamp; 
	public     float                                      depthBiasSlopeFactor; 
	public     float                                      lineWidth; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineMultisampleStateCreateInfo {
	public     VkStructureType                          sType; 
	public      void*                              pNext; 
	public     VkPipelineMultisampleStateCreateFlags    flags; 
	public     VkSampleCountFlagBits                    rasterizationSamples; 
	public     VkBool32                                 sampleShadingEnable; 
	public     float                                    minSampleShading; 
	public      VkSampleMask*                      pSampleMask; 
	public     VkBool32                                 alphaToCoverageEnable; 
	public     VkBool32                                 alphaToOneEnable; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkStencilOpState {
	public     VkStencilOp    failOp; 
	public     VkStencilOp    passOp; 
	public     VkStencilOp    depthFailOp; 
	public     VkCompareOp    compareOp; 
	public     uint32_t       compareMask; 
	public     uint32_t       writeMask; 
	public     uint32_t       reference; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineDepthStencilStateCreateInfo {
	public     VkStructureType                           sType; 
	public      void*                               pNext; 
	public     VkPipelineDepthStencilStateCreateFlags    flags; 
	public     VkBool32                                  depthTestEnable; 
	public     VkBool32                                  depthWriteEnable; 
	public     VkCompareOp                               depthCompareOp; 
	public     VkBool32                                  depthBoundsTestEnable; 
	public     VkBool32                                  stencilTestEnable; 
	public     VkStencilOpState                          front; 
	public     VkStencilOpState                          back; 
	public     float                                     minDepthBounds; 
	public     float                                     maxDepthBounds; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineColorBlendAttachmentState {
	public     VkBool32                 blendEnable; 
	public     VkBlendFactor            srcColorBlendFactor; 
	public     VkBlendFactor            dstColorBlendFactor; 
	public     VkBlendOp                colorBlendOp; 
	public     VkBlendFactor            srcAlphaBlendFactor; 
	public     VkBlendFactor            dstAlphaBlendFactor; 
	public     VkBlendOp                alphaBlendOp; 
	public     VkColorComponentFlags    colorWriteMask; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineColorBlendStateCreateInfo {
	public     VkStructureType                               sType; 
	public      void*                                   pNext; 
	public     VkPipelineColorBlendStateCreateFlags          flags; 
	public     VkBool32                                      logicOpEnable; 
	public     VkLogicOp                                     logicOp; 
	public     uint32_t                                      attachmentCount; 
	public      VkPipelineColorBlendAttachmentState*    pAttachments; 
	public fixed     float                                         blendConstants[4]; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineDynamicStateCreateInfo {
	public     VkStructureType                      sType; 
	public      void*                          pNext; 
	public     VkPipelineDynamicStateCreateFlags    flags; 
	public     uint32_t                             dynamicStateCount; 
	public      VkDynamicState*                pDynamicStates; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkGraphicsPipelineCreateInfo {
	public     VkStructureType                                  sType; 
	public      void*                                      pNext; 
	public     VkPipelineCreateFlags                            flags; 
	public     uint32_t                                         stageCount; 
	public      VkPipelineShaderStageCreateInfo*           pStages; 
	public      VkPipelineVertexInputStateCreateInfo*      pVertexInputState; 
	public      VkPipelineInputAssemblyStateCreateInfo*    pInputAssemblyState; 
	public      VkPipelineTessellationStateCreateInfo*     pTessellationState; 
	public      VkPipelineViewportStateCreateInfo*         pViewportState; 
	public      VkPipelineRasterizationStateCreateInfo*    pRasterizationState; 
	public      VkPipelineMultisampleStateCreateInfo*      pMultisampleState; 
	public      VkPipelineDepthStencilStateCreateInfo*     pDepthStencilState; 
	public      VkPipelineColorBlendStateCreateInfo*       pColorBlendState; 
	public      VkPipelineDynamicStateCreateInfo*          pDynamicState; 
	public     VkPipelineLayout                                 layout; 
	public     VkRenderPass                                     renderPass; 
	public     uint32_t                                         subpass; 
	public     VkPipeline                                       basePipelineHandle; 
	public     int32_t                                          basePipelineIndex; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPushConstantRange {
	public     VkShaderStageFlags    stageFlags; 
	public     uint32_t              offset; 
	public     uint32_t              size; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineLayoutCreateInfo {
	public     VkStructureType                 sType; 
	public      void*                     pNext; 
	public     VkPipelineLayoutCreateFlags     flags; 
	public     uint32_t                        setLayoutCount; 
	public      VkDescriptorSetLayout*    pSetLayouts; 
	public     uint32_t                        pushConstantRangeCount; 
	public      VkPushConstantRange*      pPushConstantRanges; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSamplerCreateInfo {
	public     VkStructureType         sType; 
	public      void*             pNext; 
	public     VkSamplerCreateFlags    flags; 
	public     VkFilter                magFilter; 
	public     VkFilter                minFilter; 
	public     VkSamplerMipmapMode     mipmapMode; 
	public     VkSamplerAddressMode    addressModeU; 
	public     VkSamplerAddressMode    addressModeV; 
	public     VkSamplerAddressMode    addressModeW; 
	public     float                   mipLodBias; 
	public     VkBool32                anisotropyEnable; 
	public     float                   maxAnisotropy; 
	public     VkBool32                compareEnable; 
	public     VkCompareOp             compareOp; 
	public     float                   minLod; 
	public     float                   maxLod; 
	public     VkBorderColor           borderColor; 
	public     VkBool32                unnormalizedCoordinates; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyDescriptorSet {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkDescriptorSet    srcSet; 
	public     uint32_t           srcBinding; 
	public     uint32_t           srcArrayElement; 
	public     VkDescriptorSet    dstSet; 
	public     uint32_t           dstBinding; 
	public     uint32_t           dstArrayElement; 
	public     uint32_t           descriptorCount; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorBufferInfo {
	public     VkBuffer        buffer; 
	public     VkDeviceSize    offset; 
	public     VkDeviceSize    range; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorImageInfo {
	public     VkSampler        sampler; 
	public     VkImageView      imageView; 
	public     VkImageLayout    imageLayout; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorPoolSize {
	public     VkDescriptorType    type; 
	public     uint32_t            descriptorCount; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorPoolCreateInfo {
	public     VkStructureType                sType; 
	public      void*                    pNext; 
	public     VkDescriptorPoolCreateFlags    flags; 
	public     uint32_t                       maxSets; 
	public     uint32_t                       poolSizeCount; 
	public      VkDescriptorPoolSize*    pPoolSizes; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorSetAllocateInfo {
	public     VkStructureType                 sType; 
	public      void*                     pNext; 
	public     VkDescriptorPool                descriptorPool; 
	public     uint32_t                        descriptorSetCount; 
	public      VkDescriptorSetLayout*    pSetLayouts; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorSetLayoutBinding {
	public     uint32_t              binding; 
	public     VkDescriptorType      descriptorType; 
	public     uint32_t              descriptorCount; 
	public     VkShaderStageFlags    stageFlags; 
	public      VkSampler*      pImmutableSamplers; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorSetLayoutCreateInfo {
	public     VkStructureType                        sType; 
	public      void*                            pNext; 
	public     VkDescriptorSetLayoutCreateFlags       flags; 
	public     uint32_t                               bindingCount; 
	public      VkDescriptorSetLayoutBinding*    pBindings; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkWriteDescriptorSet {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkDescriptorSet                  dstSet; 
	public     uint32_t                         dstBinding; 
	public     uint32_t                         dstArrayElement; 
	public     uint32_t                         descriptorCount; 
	public     VkDescriptorType                 descriptorType; 
	public      VkDescriptorImageInfo*     pImageInfo; 
	public      VkDescriptorBufferInfo*    pBufferInfo; 
	public      VkBufferView*              pTexelBufferView; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAttachmentDescription {
	public     VkAttachmentDescriptionFlags    flags; 
	public     VkFormat                        format; 
	public     VkSampleCountFlagBits           samples; 
	public     VkAttachmentLoadOp              loadOp; 
	public     VkAttachmentStoreOp             storeOp; 
	public     VkAttachmentLoadOp              stencilLoadOp; 
	public     VkAttachmentStoreOp             stencilStoreOp; 
	public     VkImageLayout                   initialLayout; 
	public     VkImageLayout                   finalLayout; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAttachmentReference {
	public     uint32_t         attachment; 
	public     VkImageLayout    layout; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkFramebufferCreateInfo {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkFramebufferCreateFlags    flags; 
	public     VkRenderPass                renderPass; 
	public     uint32_t                    attachmentCount; 
	public      VkImageView*          pAttachments; 
	public     uint32_t                    width; 
	public     uint32_t                    height; 
	public     uint32_t                    layers; 
}
// VK_VERSION_1_0
// [SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSubpassDescription {
	public     VkSubpassDescriptionFlags       flags; 
	public     VkPipelineBindPoint             pipelineBindPoint; 
	public     uint32_t                        inputAttachmentCount; 
	public      VkAttachmentReference*    pInputAttachments; 
	public     uint32_t                        colorAttachmentCount; 
	public      VkAttachmentReference*    pColorAttachments; 
	public      VkAttachmentReference*    pResolveAttachments; 
	public      VkAttachmentReference*    pDepthStencilAttachment; 
	public     uint32_t                        preserveAttachmentCount; 
	public      uint32_t*                 pPreserveAttachments; 
}
// VK_VERSION_1_0
// [SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSubpassDependency {
	public     uint32_t                srcSubpass; 
	public     uint32_t                dstSubpass; 
	public     VkPipelineStageFlags    srcStageMask; 
	public     VkPipelineStageFlags    dstStageMask; 
	public     VkAccessFlags           srcAccessMask; 
	public     VkAccessFlags           dstAccessMask; 
	public     VkDependencyFlags       dependencyFlags; 
}
// VK_VERSION_1_0
 
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassCreateInfo {
	public     VkStructureType                   sType; 
	public      void*                       pNext; 
	public     VkRenderPassCreateFlags           flags; 
	public     uint32_t                          attachmentCount; 
	public      VkAttachmentDescription*    pAttachments; 
	public     uint32_t                          subpassCount; 
	public      VkSubpassDescription*       pSubpasses; 
	public     uint32_t                          dependencyCount; 
	public      VkSubpassDependency*        pDependencies; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCommandPoolCreateInfo {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkCommandPoolCreateFlags    flags; 
	public     uint32_t                    queueFamilyIndex; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCommandBufferAllocateInfo {
	public     VkStructureType         sType; 
	public      void*             pNext; 
	public     VkCommandPool           commandPool; 
	public     VkCommandBufferLevel    level; 
	public     uint32_t                commandBufferCount; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCommandBufferInheritanceInfo {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkRenderPass                     renderPass; 
	public     uint32_t                         subpass; 
	public     VkFramebuffer                    framebuffer; 
	public     VkBool32                         occlusionQueryEnable; 
	public     VkQueryControlFlags              queryFlags; 
	public     VkQueryPipelineStatisticFlags    pipelineStatistics; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCommandBufferBeginInfo {
	public     VkStructureType                          sType; 
	public      void*                              pNext; 
	public     VkCommandBufferUsageFlags                flags; 
	public      VkCommandBufferInheritanceInfo*    pInheritanceInfo; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBufferCopy {
	public     VkDeviceSize    srcOffset; 
	public     VkDeviceSize    dstOffset; 
	public     VkDeviceSize    size; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageSubresourceLayers {
	public     VkImageAspectFlags    aspectMask; 
	public     uint32_t              mipLevel; 
	public     uint32_t              baseArrayLayer; 
	public     uint32_t              layerCount; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBufferImageCopy {
	public     VkDeviceSize                bufferOffset; 
	public     uint32_t                    bufferRowLength; 
	public     uint32_t                    bufferImageHeight; 
	public     VkImageSubresourceLayers    imageSubresource; 
	public     VkOffset3D                  imageOffset; 
	public     VkExtent3D                  imageExtent; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkClearDepthStencilValue {
	public     float       depth; 
	public     uint32_t    stencil; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkClearAttachment {
	public     VkImageAspectFlags    aspectMask; 
	public     uint32_t              colorAttachment; 
	public     VkClearValue          clearValue; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkClearRect {
	public     VkRect2D    rect; 
	public     uint32_t    baseArrayLayer; 
	public     uint32_t    layerCount; 
}
// VK_VERSION_1_0
[ StructLayout(LayoutKind.Sequential, Pack =  VK.DATA_ALIGNEMENT_SIZE ),SkipLocalsInit]
public unsafe  struct VkImageBlit {
	public  VkImageSubresourceLayers  srcSubresource;
	public VkOffset3D**  srcOffsets;//[2];
	public  VkImageSubresourceLayers  dstSubresource;
	public VkOffset3D**  dstOffsets;//[2];
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageCopy {
	public     VkImageSubresourceLayers    srcSubresource; 
	public     VkOffset3D                  srcOffset; 
	public     VkImageSubresourceLayers    dstSubresource; 
	public     VkOffset3D                  dstOffset; 
	public     VkExtent3D                  extent; 
}
// VK_VERSION_1_0
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageResolve {
	public     VkImageSubresourceLayers    srcSubresource; 
	public     VkOffset3D                  srcOffset; 
	public     VkImageSubresourceLayers    dstSubresource; 
	public     VkOffset3D                  dstOffset; 
	public     VkExtent3D                  extent; 
}
// VK_VERSION_1_0
// [ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassBeginInfo {
	public     VkStructureType        sType; 
	public      void*            pNext; 
	public     VkRenderPass           renderPass; 
	public     VkFramebuffer          framebuffer; 
	public     VkRect2D               renderArea; 
	public     uint32_t               clearValueCount; 
	public      VkClearValue*    pClearValues; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceSubgroupProperties {
	public     VkStructureType           sType; 
	public     void*                     pNext; 
	public     uint32_t                  subgroupSize; 
	public     VkShaderStageFlags        supportedStages; 
	public     VkSubgroupFeatureFlags    supportedOperations; 
	public     VkBool32                  quadOperationsInAllStages; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindBufferMemoryInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBuffer           buffer; 
	public     VkDeviceMemory     memory; 
	public     VkDeviceSize       memoryOffset; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindImageMemoryInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkImage            image; 
	public     VkDeviceMemory     memory; 
	public     VkDeviceSize       memoryOffset; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevice16BitStorageFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           storageBuffer16BitAccess; 
	public     VkBool32           uniformAndStorageBuffer16BitAccess; 
	public     VkBool32           storagePushConstant16; 
	public     VkBool32           storageInputOutput16; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryDedicatedRequirements {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           prefersDedicatedAllocation; 
	public     VkBool32           requiresDedicatedAllocation; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryDedicatedAllocateInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkImage            image; 
	public     VkBuffer           buffer; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryAllocateFlagsInfo {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     VkMemoryAllocateFlags    flags; 
	public     uint32_t                 deviceMask; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceGroupRenderPassBeginInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           deviceMask; 
	public     uint32_t           deviceRenderAreaCount; 
	public      VkRect2D*    pDeviceRenderAreas; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceGroupCommandBufferBeginInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           deviceMask; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceGroupSubmitInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           waitSemaphoreCount; 
	public      uint32_t*    pWaitSemaphoreDeviceIndices; 
	public     uint32_t           commandBufferCount; 
	public      uint32_t*    pCommandBufferDeviceMasks; 
	public     uint32_t           signalSemaphoreCount; 
	public      uint32_t*    pSignalSemaphoreDeviceIndices; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceGroupBindSparseInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           resourceDeviceIndex; 
	public     uint32_t           memoryDeviceIndex; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindBufferMemoryDeviceGroupInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           deviceIndexCount; 
	public      uint32_t*    pDeviceIndices; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindImageMemoryDeviceGroupInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           deviceIndexCount; 
	public      uint32_t*    pDeviceIndices; 
	public     uint32_t           splitInstanceBindRegionCount; 
	public      VkRect2D*    pSplitInstanceBindRegions; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceGroupProperties {
	public     VkStructureType     sType; 
	public     void*               pNext; 
	public     uint32_t            physicalDeviceCount;
	public VkPhysicalDevice** physicalDevices; //[(int)VK.VK_MAX_DEVICE_GROUP_SIZE]; 
	public     VkBool32            subsetAllocation; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceGroupDeviceCreateInfo {
	public     VkStructureType            sType; 
	public      void*                pNext; 
	public     uint32_t                   physicalDeviceCount; 
	public      VkPhysicalDevice*    pPhysicalDevices; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBufferMemoryRequirementsInfo2 {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBuffer           buffer; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageMemoryRequirementsInfo2 {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkImage            image; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageSparseMemoryRequirementsInfo2 {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkImage            image; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryRequirements2 {
	public     VkStructureType         sType; 
	public     void*                   pNext; 
	public     VkMemoryRequirements    memoryRequirements; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSparseImageMemoryRequirements2 {
	public     VkStructureType                    sType; 
	public     void*                              pNext; 
	public     VkSparseImageMemoryRequirements    memoryRequirements; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFeatures2 {
	public     VkStructureType             sType; 
	public     void*                       pNext; 
	public     VkPhysicalDeviceFeatures    features; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceProperties2 {
	public     VkStructureType               sType; 
	public     void*                         pNext; 
	public     VkPhysicalDeviceProperties    properties; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkFormatProperties2 {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     VkFormatProperties    formatProperties; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageFormatProperties2 {
	public     VkStructureType            sType; 
	public     void*                      pNext; 
	public     VkImageFormatProperties    imageFormatProperties; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceImageFormatInfo2 {
	public     VkStructureType       sType; 
	public      void*           pNext; 
	public     VkFormat              format; 
	public     VkImageType           type; 
	public     VkImageTiling         tiling; 
	public     VkImageUsageFlags     usage; 
	public     VkImageCreateFlags    flags; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkQueueFamilyProperties2 {
	public     VkStructureType            sType; 
	public     void*                      pNext; 
	public     VkQueueFamilyProperties    queueFamilyProperties; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMemoryProperties2 {
	public     VkStructureType                     sType; 
	public     void*                               pNext; 
	public     VkPhysicalDeviceMemoryProperties    memoryProperties; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSparseImageFormatProperties2 {
	public     VkStructureType                  sType; 
	public     void*                            pNext; 
	public     VkSparseImageFormatProperties    properties; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceSparseImageFormatInfo2 {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     VkFormat                 format; 
	public     VkImageType              type; 
	public     VkSampleCountFlagBits    samples; 
	public     VkImageUsageFlags        usage; 
	public     VkImageTiling            tiling; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePointClippingProperties {
	public     VkStructureType            sType; 
	public     void*                      pNext; 
	public     VkPointClippingBehavior    pointClippingBehavior; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkInputAttachmentAspectReference {
	public     uint32_t              subpass; 
	public     uint32_t              inputAttachmentIndex; 
	public     VkImageAspectFlags    aspectMask; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassInputAttachmentAspectCreateInfo {
	public     VkStructureType                            sType; 
	public      void*                                pNext; 
	public     uint32_t                                   aspectReferenceCount; 
	public      VkInputAttachmentAspectReference*    pAspectReferences; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageViewUsageCreateInfo {
	public     VkStructureType      sType; 
	public      void*          pNext; 
	public     VkImageUsageFlags    usage; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineTessellationDomainOriginStateCreateInfo {
	public     VkStructureType               sType; 
	public      void*                   pNext; 
	public     VkTessellationDomainOrigin    domainOrigin; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassMultiviewCreateInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           subpassCount; 
	public      uint32_t*    pViewMasks; 
	public     uint32_t           dependencyCount; 
	public      int32_t*     pViewOffsets; 
	public     uint32_t           correlationMaskCount; 
	public      uint32_t*    pCorrelationMasks; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMultiviewFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           multiview; 
	public     VkBool32           multiviewGeometryShader; 
	public     VkBool32           multiviewTessellationShader; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMultiviewProperties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxMultiviewViewCount; 
	public     uint32_t           maxMultiviewInstanceIndex; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVariablePointersFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           variablePointersStorageBuffer; 
	public     VkBool32           variablePointers; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceProtectedMemoryFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           protectedMemory; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceProtectedMemoryProperties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           protectedNoFault; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceQueueInfo2 {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkDeviceQueueCreateFlags    flags; 
	public     uint32_t                    queueFamilyIndex; 
	public     uint32_t                    queueIndex; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkProtectedSubmitInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBool32           protectedSubmit; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSamplerYcbcrConversionCreateInfo {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkFormat                         format; 
	public     VkSamplerYcbcrModelConversion    ycbcrModel; 
	public     VkSamplerYcbcrRange              ycbcrRange; 
	public     VkComponentMapping               components; 
	public     VkChromaLocation                 xChromaOffset; 
	public     VkChromaLocation                 yChromaOffset; 
	public     VkFilter                         chromaFilter; 
	public     VkBool32                         forceExplicitReconstruction; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSamplerYcbcrConversionInfo {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkSamplerYcbcrConversion    conversion; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindImagePlaneMemoryInfo {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     VkImageAspectFlagBits    planeAspect; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImagePlaneMemoryRequirementsInfo {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     VkImageAspectFlagBits    planeAspect; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceSamplerYcbcrConversionFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           samplerYcbcrConversion; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSamplerYcbcrConversionImageFormatProperties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           combinedImageSamplerDescriptorCount; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorUpdateTemplateEntry {
	public     uint32_t            dstBinding; 
	public     uint32_t            dstArrayElement; 
	public     uint32_t            descriptorCount; 
	public     VkDescriptorType    descriptorType; 
	public     /* size_t */ nuint              offset; 
	public     /* size_t */ nuint              stride; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorUpdateTemplateCreateInfo {
	public     VkStructureType                           sType; 
	public      void*                               pNext; 
	public     VkDescriptorUpdateTemplateCreateFlags     flags; 
	public     uint32_t                                  descriptorUpdateEntryCount; 
	public      VkDescriptorUpdateTemplateEntry*    pDescriptorUpdateEntries; 
	public     VkDescriptorUpdateTemplateType            templateType; 
	public     VkDescriptorSetLayout                     descriptorSetLayout; 
	public     VkPipelineBindPoint                       pipelineBindPoint; 
	public     VkPipelineLayout                          pipelineLayout; 
	public     uint32_t                                  set; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExternalMemoryProperties {
	public     VkExternalMemoryFeatureFlags       externalMemoryFeatures; 
	public     VkExternalMemoryHandleTypeFlags    exportFromImportedHandleTypes; 
	public     VkExternalMemoryHandleTypeFlags    compatibleHandleTypes; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceExternalImageFormatInfo {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkExternalMemoryHandleTypeFlagBits    handleType; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExternalImageFormatProperties {
	public     VkStructureType               sType; 
	public     void*                         pNext; 
	public     VkExternalMemoryProperties    externalMemoryProperties; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceExternalBufferInfo {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkBufferCreateFlags                   flags; 
	public     VkBufferUsageFlags                    usage; 
	public     VkExternalMemoryHandleTypeFlagBits    handleType; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExternalBufferProperties {
	public     VkStructureType               sType; 
	public     void*                         pNext; 
	public     VkExternalMemoryProperties    externalMemoryProperties; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceIDProperties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public fixed     uint8_t            deviceUUID[(int)VK.VK_UUID_SIZE]; 
	public fixed     uint8_t            driverUUID[(int)VK.VK_UUID_SIZE]; 
	public fixed     uint8_t            deviceLUID[(int)VK.VK_LUID_SIZE]; 
	public     uint32_t           deviceNodeMask; 
	public     VkBool32           deviceLUIDValid; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExternalMemoryImageCreateInfo {
	public     VkStructureType                    sType; 
	public      void*                        pNext; 
	public     VkExternalMemoryHandleTypeFlags    handleTypes; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExternalMemoryBufferCreateInfo {
	public     VkStructureType                    sType; 
	public      void*                        pNext; 
	public     VkExternalMemoryHandleTypeFlags    handleTypes; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExportMemoryAllocateInfo {
	public     VkStructureType                    sType; 
	public      void*                        pNext; 
	public     VkExternalMemoryHandleTypeFlags    handleTypes; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceExternalFenceInfo {
	public     VkStructureType                      sType; 
	public      void*                          pNext; 
	public     VkExternalFenceHandleTypeFlagBits    handleType; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExternalFenceProperties {
	public     VkStructureType                   sType; 
	public     void*                             pNext; 
	public     VkExternalFenceHandleTypeFlags    exportFromImportedHandleTypes; 
	public     VkExternalFenceHandleTypeFlags    compatibleHandleTypes; 
	public     VkExternalFenceFeatureFlags       externalFenceFeatures; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExportFenceCreateInfo {
	public     VkStructureType                   sType; 
	public      void*                       pNext; 
	public     VkExternalFenceHandleTypeFlags    handleTypes; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExportSemaphoreCreateInfo {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkExternalSemaphoreHandleTypeFlags    handleTypes; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceExternalSemaphoreInfo {
	public     VkStructureType                          sType; 
	public      void*                              pNext; 
	public     VkExternalSemaphoreHandleTypeFlagBits    handleType; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExternalSemaphoreProperties {
	public     VkStructureType                       sType; 
	public     void*                                 pNext; 
	public     VkExternalSemaphoreHandleTypeFlags    exportFromImportedHandleTypes; 
	public     VkExternalSemaphoreHandleTypeFlags    compatibleHandleTypes; 
	public     VkExternalSemaphoreFeatureFlags       externalSemaphoreFeatures; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMaintenance3Properties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxPerSetDescriptors; 
	public     VkDeviceSize       maxMemoryAllocationSize; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorSetLayoutSupport {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           supported; 
}
// VK_VERSION_1_1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderDrawParametersFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderDrawParameters; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVulkan11Features {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           storageBuffer16BitAccess; 
	public     VkBool32           uniformAndStorageBuffer16BitAccess; 
	public     VkBool32           storagePushConstant16; 
	public     VkBool32           storageInputOutput16; 
	public     VkBool32           multiview; 
	public     VkBool32           multiviewGeometryShader; 
	public     VkBool32           multiviewTessellationShader; 
	public     VkBool32           variablePointersStorageBuffer; 
	public     VkBool32           variablePointers; 
	public     VkBool32           protectedMemory; 
	public     VkBool32           samplerYcbcrConversion; 
	public     VkBool32           shaderDrawParameters; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVulkan11Properties {
	public     VkStructureType            sType; 
	public     void*                      pNext; 
	public fixed     uint8_t                    deviceUUID[(int)VK.VK_UUID_SIZE]; 
	public fixed     uint8_t                    driverUUID[(int)VK.VK_UUID_SIZE]; 
	public fixed     uint8_t                    deviceLUID[(int)VK.VK_LUID_SIZE]; 
	public     uint32_t                   deviceNodeMask; 
	public     VkBool32                   deviceLUIDValid; 
	public     uint32_t                   subgroupSize; 
	public     VkShaderStageFlags         subgroupSupportedStages; 
	public     VkSubgroupFeatureFlags     subgroupSupportedOperations; 
	public     VkBool32                   subgroupQuadOperationsInAllStages; 
	public     VkPointClippingBehavior    pointClippingBehavior; 
	public     uint32_t                   maxMultiviewViewCount; 
	public     uint32_t                   maxMultiviewInstanceIndex; 
	public     VkBool32                   protectedNoFault; 
	public     uint32_t                   maxPerSetDescriptors; 
	public     VkDeviceSize               maxMemoryAllocationSize; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVulkan12Features {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           samplerMirrorClampToEdge; 
	public     VkBool32           drawIndirectCount; 
	public     VkBool32           storageBuffer8BitAccess; 
	public     VkBool32           uniformAndStorageBuffer8BitAccess; 
	public     VkBool32           storagePushConstant8; 
	public     VkBool32           shaderBufferInt64Atomics; 
	public     VkBool32           shaderSharedInt64Atomics; 
	public     VkBool32           shaderFloat16; 
	public     VkBool32           shaderInt8; 
	public     VkBool32           descriptorIndexing; 
	public     VkBool32           shaderInputAttachmentArrayDynamicIndexing; 
	public     VkBool32           shaderUniformTexelBufferArrayDynamicIndexing; 
	public     VkBool32           shaderStorageTexelBufferArrayDynamicIndexing; 
	public     VkBool32           shaderUniformBufferArrayNonUniformIndexing; 
	public     VkBool32           shaderSampledImageArrayNonUniformIndexing; 
	public     VkBool32           shaderStorageBufferArrayNonUniformIndexing; 
	public     VkBool32           shaderStorageImageArrayNonUniformIndexing; 
	public     VkBool32           shaderInputAttachmentArrayNonUniformIndexing; 
	public     VkBool32           shaderUniformTexelBufferArrayNonUniformIndexing; 
	public     VkBool32           shaderStorageTexelBufferArrayNonUniformIndexing; 
	public     VkBool32           descriptorBindingUniformBufferUpdateAfterBind; 
	public     VkBool32           descriptorBindingSampledImageUpdateAfterBind; 
	public     VkBool32           descriptorBindingStorageImageUpdateAfterBind; 
	public     VkBool32           descriptorBindingStorageBufferUpdateAfterBind; 
	public     VkBool32           descriptorBindingUniformTexelBufferUpdateAfterBind; 
	public     VkBool32           descriptorBindingStorageTexelBufferUpdateAfterBind; 
	public     VkBool32           descriptorBindingUpdateUnusedWhilePending; 
	public     VkBool32           descriptorBindingPartiallyBound; 
	public     VkBool32           descriptorBindingVariableDescriptorCount; 
	public     VkBool32           runtimeDescriptorArray; 
	public     VkBool32           samplerFilterMinmax; 
	public     VkBool32           scalarBlockLayout; 
	public     VkBool32           imagelessFramebuffer; 
	public     VkBool32           uniformBufferStandardLayout; 
	public     VkBool32           shaderSubgroupExtendedTypes; 
	public     VkBool32           separateDepthStencilLayouts; 
	public     VkBool32           hostQueryReset; 
	public     VkBool32           timelineSemaphore; 
	public     VkBool32           bufferDeviceAddress; 
	public     VkBool32           bufferDeviceAddressCaptureReplay; 
	public     VkBool32           bufferDeviceAddressMultiDevice; 
	public     VkBool32           vulkanMemoryModel; 
	public     VkBool32           vulkanMemoryModelDeviceScope; 
	public     VkBool32           vulkanMemoryModelAvailabilityVisibilityChains; 
	public     VkBool32           shaderOutputViewportIndex; 
	public     VkBool32           shaderOutputLayer; 
	public     VkBool32           subgroupBroadcastDynamicId; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkConformanceVersion {
	public     uint8_t    major; 
	public     uint8_t    minor; 
	public     uint8_t    subminor; 
	public     uint8_t    patch; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVulkan12Properties {
	public     VkStructureType                      sType; 
	public     void*                                pNext; 
	public     VkDriverId                           driverID; 
	public fixed byte                                 driverName[(int)VK.VK_MAX_DRIVER_NAME_SIZE]; 
	public fixed byte                                 driverInfo[(int)VK.VK_MAX_DRIVER_INFO_SIZE]; 
	public     VkConformanceVersion                 conformanceVersion; 
	public     VkShaderFloatControlsIndependence    denormBehaviorIndependence; 
	public     VkShaderFloatControlsIndependence    roundingModeIndependence; 
	public     VkBool32                             shaderSignedZeroInfNanPreserveFloat16; 
	public     VkBool32                             shaderSignedZeroInfNanPreserveFloat32; 
	public     VkBool32                             shaderSignedZeroInfNanPreserveFloat64; 
	public     VkBool32                             shaderDenormPreserveFloat16; 
	public     VkBool32                             shaderDenormPreserveFloat32; 
	public     VkBool32                             shaderDenormPreserveFloat64; 
	public     VkBool32                             shaderDenormFlushToZeroFloat16; 
	public     VkBool32                             shaderDenormFlushToZeroFloat32; 
	public     VkBool32                             shaderDenormFlushToZeroFloat64; 
	public     VkBool32                             shaderRoundingModeRTEFloat16; 
	public     VkBool32                             shaderRoundingModeRTEFloat32; 
	public     VkBool32                             shaderRoundingModeRTEFloat64; 
	public     VkBool32                             shaderRoundingModeRTZFloat16; 
	public     VkBool32                             shaderRoundingModeRTZFloat32; 
	public     VkBool32                             shaderRoundingModeRTZFloat64; 
	public     uint32_t                             maxUpdateAfterBindDescriptorsInAllPools; 
	public     VkBool32                             shaderUniformBufferArrayNonUniformIndexingNative; 
	public     VkBool32                             shaderSampledImageArrayNonUniformIndexingNative; 
	public     VkBool32                             shaderStorageBufferArrayNonUniformIndexingNative; 
	public     VkBool32                             shaderStorageImageArrayNonUniformIndexingNative; 
	public     VkBool32                             shaderInputAttachmentArrayNonUniformIndexingNative; 
	public     VkBool32                             robustBufferAccessUpdateAfterBind; 
	public     VkBool32                             quadDivergentImplicitLod; 
	public     uint32_t                             maxPerStageDescriptorUpdateAfterBindSamplers; 
	public     uint32_t                             maxPerStageDescriptorUpdateAfterBindUniformBuffers; 
	public     uint32_t                             maxPerStageDescriptorUpdateAfterBindStorageBuffers; 
	public     uint32_t                             maxPerStageDescriptorUpdateAfterBindSampledImages; 
	public     uint32_t                             maxPerStageDescriptorUpdateAfterBindStorageImages; 
	public     uint32_t                             maxPerStageDescriptorUpdateAfterBindInputAttachments; 
	public     uint32_t                             maxPerStageUpdateAfterBindResources; 
	public     uint32_t                             maxDescriptorSetUpdateAfterBindSamplers; 
	public     uint32_t                             maxDescriptorSetUpdateAfterBindUniformBuffers; 
	public     uint32_t                             maxDescriptorSetUpdateAfterBindUniformBuffersDynamic; 
	public     uint32_t                             maxDescriptorSetUpdateAfterBindStorageBuffers; 
	public     uint32_t                             maxDescriptorSetUpdateAfterBindStorageBuffersDynamic; 
	public     uint32_t                             maxDescriptorSetUpdateAfterBindSampledImages; 
	public     uint32_t                             maxDescriptorSetUpdateAfterBindStorageImages; 
	public     uint32_t                             maxDescriptorSetUpdateAfterBindInputAttachments; 
	public     VkResolveModeFlags                   supportedDepthResolveModes; 
	public     VkResolveModeFlags                   supportedStencilResolveModes; 
	public     VkBool32                             independentResolveNone; 
	public     VkBool32                             independentResolve; 
	public     VkBool32                             filterMinmaxSingleComponentFormats; 
	public     VkBool32                             filterMinmaxImageComponentMapping; 
	public     uint64_t                             maxTimelineSemaphoreValueDifference; 
	public     VkSampleCountFlags                   framebufferIntegerColorSampleCounts; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageFormatListCreateInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           viewFormatCount; 
	public      VkFormat*    pViewFormats; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAttachmentDescription2 {
	public     VkStructureType                 sType; 
	public      void*                     pNext; 
	public     VkAttachmentDescriptionFlags    flags; 
	public     VkFormat                        format; 
	public     VkSampleCountFlagBits           samples; 
	public     VkAttachmentLoadOp              loadOp; 
	public     VkAttachmentStoreOp             storeOp; 
	public     VkAttachmentLoadOp              stencilLoadOp; 
	public     VkAttachmentStoreOp             stencilStoreOp; 
	public     VkImageLayout                   initialLayout; 
	public     VkImageLayout                   finalLayout; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAttachmentReference2 {
	public     VkStructureType       sType; 
	public      void*           pNext; 
	public     uint32_t              attachment; 
	public     VkImageLayout         layout; 
	public     VkImageAspectFlags    aspectMask; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSubpassDescription2 {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkSubpassDescriptionFlags        flags; 
	public     VkPipelineBindPoint              pipelineBindPoint; 
	public     uint32_t                         viewMask; 
	public     uint32_t                         inputAttachmentCount; 
	public      VkAttachmentReference2*    pInputAttachments; 
	public     uint32_t                         colorAttachmentCount; 
	public      VkAttachmentReference2*    pColorAttachments; 
	public      VkAttachmentReference2*    pResolveAttachments; 
	public      VkAttachmentReference2*    pDepthStencilAttachment; 
	public     uint32_t                         preserveAttachmentCount; 
	public      uint32_t*                  pPreserveAttachments; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSubpassDependency2 {
	public     VkStructureType         sType; 
	public      void*             pNext; 
	public     uint32_t                srcSubpass; 
	public     uint32_t                dstSubpass; 
	public     VkPipelineStageFlags    srcStageMask; 
	public     VkPipelineStageFlags    dstStageMask; 
	public     VkAccessFlags           srcAccessMask; 
	public     VkAccessFlags           dstAccessMask; 
	public     VkDependencyFlags       dependencyFlags; 
	public     int32_t                 viewOffset; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassCreateInfo2 {
	public     VkStructureType                    sType; 
	public      void*                        pNext; 
	public     VkRenderPassCreateFlags            flags; 
	public     uint32_t                           attachmentCount; 
	public      VkAttachmentDescription2*    pAttachments; 
	public     uint32_t                           subpassCount; 
	public      VkSubpassDescription2*       pSubpasses; 
	public     uint32_t                           dependencyCount; 
	public      VkSubpassDependency2*        pDependencies; 
	public     uint32_t                           correlatedViewMaskCount; 
	public      uint32_t*                    pCorrelatedViewMasks; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSubpassBeginInfo {
	public     VkStructureType      sType; 
	public      void*          pNext; 
	public     VkSubpassContents    contents; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSubpassEndInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevice8BitStorageFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           storageBuffer8BitAccess; 
	public     VkBool32           uniformAndStorageBuffer8BitAccess; 
	public     VkBool32           storagePushConstant8; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDriverProperties {
	public     VkStructureType         sType; 
	public     void*                   pNext; 
	public     VkDriverId              driverID; 
	public fixed byte                    driverName[(int)VK.VK_MAX_DRIVER_NAME_SIZE]; 
	public fixed byte                    driverInfo[(int)VK.VK_MAX_DRIVER_INFO_SIZE]; 
	public     VkConformanceVersion    conformanceVersion; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderAtomicInt64Features {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderBufferInt64Atomics; 
	public     VkBool32           shaderSharedInt64Atomics; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderFloat16Int8Features {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderFloat16; 
	public     VkBool32           shaderInt8; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFloatControlsProperties {
	public     VkStructureType                      sType; 
	public     void*                                pNext; 
	public     VkShaderFloatControlsIndependence    denormBehaviorIndependence; 
	public     VkShaderFloatControlsIndependence    roundingModeIndependence; 
	public     VkBool32                             shaderSignedZeroInfNanPreserveFloat16; 
	public     VkBool32                             shaderSignedZeroInfNanPreserveFloat32; 
	public     VkBool32                             shaderSignedZeroInfNanPreserveFloat64; 
	public     VkBool32                             shaderDenormPreserveFloat16; 
	public     VkBool32                             shaderDenormPreserveFloat32; 
	public     VkBool32                             shaderDenormPreserveFloat64; 
	public     VkBool32                             shaderDenormFlushToZeroFloat16; 
	public     VkBool32                             shaderDenormFlushToZeroFloat32; 
	public     VkBool32                             shaderDenormFlushToZeroFloat64; 
	public     VkBool32                             shaderRoundingModeRTEFloat16; 
	public     VkBool32                             shaderRoundingModeRTEFloat32; 
	public     VkBool32                             shaderRoundingModeRTEFloat64; 
	public     VkBool32                             shaderRoundingModeRTZFloat16; 
	public     VkBool32                             shaderRoundingModeRTZFloat32; 
	public     VkBool32                             shaderRoundingModeRTZFloat64; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorSetLayoutBindingFlagsCreateInfo {
	public     VkStructureType                    sType; 
	public      void*                        pNext; 
	public     uint32_t                           bindingCount; 
	public      VkDescriptorBindingFlags*    pBindingFlags; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDescriptorIndexingFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderInputAttachmentArrayDynamicIndexing; 
	public     VkBool32           shaderUniformTexelBufferArrayDynamicIndexing; 
	public     VkBool32           shaderStorageTexelBufferArrayDynamicIndexing; 
	public     VkBool32           shaderUniformBufferArrayNonUniformIndexing; 
	public     VkBool32           shaderSampledImageArrayNonUniformIndexing; 
	public     VkBool32           shaderStorageBufferArrayNonUniformIndexing; 
	public     VkBool32           shaderStorageImageArrayNonUniformIndexing; 
	public     VkBool32           shaderInputAttachmentArrayNonUniformIndexing; 
	public     VkBool32           shaderUniformTexelBufferArrayNonUniformIndexing; 
	public     VkBool32           shaderStorageTexelBufferArrayNonUniformIndexing; 
	public     VkBool32           descriptorBindingUniformBufferUpdateAfterBind; 
	public     VkBool32           descriptorBindingSampledImageUpdateAfterBind; 
	public     VkBool32           descriptorBindingStorageImageUpdateAfterBind; 
	public     VkBool32           descriptorBindingStorageBufferUpdateAfterBind; 
	public     VkBool32           descriptorBindingUniformTexelBufferUpdateAfterBind; 
	public     VkBool32           descriptorBindingStorageTexelBufferUpdateAfterBind; 
	public     VkBool32           descriptorBindingUpdateUnusedWhilePending; 
	public     VkBool32           descriptorBindingPartiallyBound; 
	public     VkBool32           descriptorBindingVariableDescriptorCount; 
	public     VkBool32           runtimeDescriptorArray; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDescriptorIndexingProperties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxUpdateAfterBindDescriptorsInAllPools; 
	public     VkBool32           shaderUniformBufferArrayNonUniformIndexingNative; 
	public     VkBool32           shaderSampledImageArrayNonUniformIndexingNative; 
	public     VkBool32           shaderStorageBufferArrayNonUniformIndexingNative; 
	public     VkBool32           shaderStorageImageArrayNonUniformIndexingNative; 
	public     VkBool32           shaderInputAttachmentArrayNonUniformIndexingNative; 
	public     VkBool32           robustBufferAccessUpdateAfterBind; 
	public     VkBool32           quadDivergentImplicitLod; 
	public     uint32_t           maxPerStageDescriptorUpdateAfterBindSamplers; 
	public     uint32_t           maxPerStageDescriptorUpdateAfterBindUniformBuffers; 
	public     uint32_t           maxPerStageDescriptorUpdateAfterBindStorageBuffers; 
	public     uint32_t           maxPerStageDescriptorUpdateAfterBindSampledImages; 
	public     uint32_t           maxPerStageDescriptorUpdateAfterBindStorageImages; 
	public     uint32_t           maxPerStageDescriptorUpdateAfterBindInputAttachments; 
	public     uint32_t           maxPerStageUpdateAfterBindResources; 
	public     uint32_t           maxDescriptorSetUpdateAfterBindSamplers; 
	public     uint32_t           maxDescriptorSetUpdateAfterBindUniformBuffers; 
	public     uint32_t           maxDescriptorSetUpdateAfterBindUniformBuffersDynamic; 
	public     uint32_t           maxDescriptorSetUpdateAfterBindStorageBuffers; 
	public     uint32_t           maxDescriptorSetUpdateAfterBindStorageBuffersDynamic; 
	public     uint32_t           maxDescriptorSetUpdateAfterBindSampledImages; 
	public     uint32_t           maxDescriptorSetUpdateAfterBindStorageImages; 
	public     uint32_t           maxDescriptorSetUpdateAfterBindInputAttachments; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorSetVariableDescriptorCountAllocateInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           descriptorSetCount; 
	public      uint32_t*    pDescriptorCounts; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorSetVariableDescriptorCountLayoutSupport {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxVariableDescriptorCount; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSubpassDescriptionDepthStencilResolve {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkResolveModeFlagBits            depthResolveMode; 
	public     VkResolveModeFlagBits            stencilResolveMode; 
	public      VkAttachmentReference2*    pDepthStencilResolveAttachment; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDepthStencilResolveProperties {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     VkResolveModeFlags    supportedDepthResolveModes; 
	public     VkResolveModeFlags    supportedStencilResolveModes; 
	public     VkBool32              independentResolveNone; 
	public     VkBool32              independentResolve; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceScalarBlockLayoutFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           scalarBlockLayout; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageStencilUsageCreateInfo {
	public     VkStructureType      sType; 
	public      void*          pNext; 
	public     VkImageUsageFlags    stencilUsage; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSamplerReductionModeCreateInfo {
	public     VkStructureType           sType; 
	public      void*               pNext; 
	public     VkSamplerReductionMode    reductionMode; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceSamplerFilterMinmaxProperties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           filterMinmaxSingleComponentFormats; 
	public     VkBool32           filterMinmaxImageComponentMapping; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVulkanMemoryModelFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           vulkanMemoryModel; 
	public     VkBool32           vulkanMemoryModelDeviceScope; 
	public     VkBool32           vulkanMemoryModelAvailabilityVisibilityChains; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceImagelessFramebufferFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           imagelessFramebuffer; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkFramebufferAttachmentImageInfo {
	public     VkStructureType       sType; 
	public      void*           pNext; 
	public     VkImageCreateFlags    flags; 
	public     VkImageUsageFlags     usage; 
	public     uint32_t              width; 
	public     uint32_t              height; 
	public     uint32_t              layerCount; 
	public     uint32_t              viewFormatCount; 
	public      VkFormat*       pViewFormats; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkFramebufferAttachmentsCreateInfo {
	public     VkStructureType                            sType; 
	public      void*                                pNext; 
	public     uint32_t                                   attachmentImageInfoCount; 
	public      VkFramebufferAttachmentImageInfo*    pAttachmentImageInfos; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassAttachmentBeginInfo {
	public     VkStructureType       sType; 
	public      void*           pNext; 
	public     uint32_t              attachmentCount; 
	public      VkImageView*    pAttachments; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceUniformBufferStandardLayoutFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           uniformBufferStandardLayout; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderSubgroupExtendedTypesFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderSubgroupExtendedTypes; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceSeparateDepthStencilLayoutsFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           separateDepthStencilLayouts; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAttachmentReferenceStencilLayout {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkImageLayout      stencilLayout; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAttachmentDescriptionStencilLayout {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkImageLayout      stencilInitialLayout; 
	public     VkImageLayout      stencilFinalLayout; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceHostQueryResetFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           hostQueryReset; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceTimelineSemaphoreFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           timelineSemaphore; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceTimelineSemaphoreProperties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint64_t           maxTimelineSemaphoreValueDifference; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSemaphoreTypeCreateInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkSemaphoreType    semaphoreType; 
	public     uint64_t           initialValue; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkTimelineSemaphoreSubmitInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           waitSemaphoreValueCount; 
	public      uint64_t*    pWaitSemaphoreValues; 
	public     uint32_t           signalSemaphoreValueCount; 
	public      uint64_t*    pSignalSemaphoreValues; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSemaphoreWaitInfo {
	public     VkStructureType         sType; 
	public      void*             pNext; 
	public     VkSemaphoreWaitFlags    flags; 
	public     uint32_t                semaphoreCount; 
	public      VkSemaphore*      pSemaphores; 
	public      uint64_t*         pValues; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSemaphoreSignalInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkSemaphore        semaphore; 
	public     uint64_t           value; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceBufferDeviceAddressFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           bufferDeviceAddress; 
	public     VkBool32           bufferDeviceAddressCaptureReplay; 
	public     VkBool32           bufferDeviceAddressMultiDevice; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBufferDeviceAddressInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBuffer           buffer; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBufferOpaqueCaptureAddressCreateInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint64_t           opaqueCaptureAddress; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryOpaqueCaptureAddressAllocateInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint64_t           opaqueCaptureAddress; 
}
// VK_VERSION_1_2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceMemoryOpaqueCaptureAddressInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkDeviceMemory     memory; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVulkan13Features {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           robustImageAccess; 
	public     VkBool32           inlineUniformBlock; 
	public     VkBool32           descriptorBindingInlineUniformBlockUpdateAfterBind; 
	public     VkBool32           pipelineCreationCacheControl; 
	public     VkBool32           privateData; 
	public     VkBool32           shaderDemoteToHelperInvocation; 
	public     VkBool32           shaderTerminateInvocation; 
	public     VkBool32           subgroupSizeControl; 
	public     VkBool32           computeFullSubgroups; 
	public     VkBool32           synchronization2; 
	public     VkBool32           textureCompressionASTC_HDR; 
	public     VkBool32           shaderZeroInitializeWorkgroupMemory; 
	public     VkBool32           dynamicRendering; 
	public     VkBool32           shaderIntegerDotProduct; 
	public     VkBool32           maintenance4; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVulkan13Properties {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     uint32_t              minSubgroupSize; 
	public     uint32_t              maxSubgroupSize; 
	public     uint32_t              maxComputeWorkgroupSubgroups; 
	public     VkShaderStageFlags    requiredSubgroupSizeStages; 
	public     uint32_t              maxInlineUniformBlockSize; 
	public     uint32_t              maxPerStageDescriptorInlineUniformBlocks; 
	public     uint32_t              maxPerStageDescriptorUpdateAfterBindInlineUniformBlocks; 
	public     uint32_t              maxDescriptorSetInlineUniformBlocks; 
	public     uint32_t              maxDescriptorSetUpdateAfterBindInlineUniformBlocks; 
	public     uint32_t              maxInlineUniformTotalSize; 
	public     VkBool32              integerDotProduct8BitUnsignedAccelerated; 
	public     VkBool32              integerDotProduct8BitSignedAccelerated; 
	public     VkBool32              integerDotProduct8BitMixedSignednessAccelerated; 
	public     VkBool32              integerDotProduct4x8BitPackedUnsignedAccelerated; 
	public     VkBool32              integerDotProduct4x8BitPackedSignedAccelerated; 
	public     VkBool32              integerDotProduct4x8BitPackedMixedSignednessAccelerated; 
	public     VkBool32              integerDotProduct16BitUnsignedAccelerated; 
	public     VkBool32              integerDotProduct16BitSignedAccelerated; 
	public     VkBool32              integerDotProduct16BitMixedSignednessAccelerated; 
	public     VkBool32              integerDotProduct32BitUnsignedAccelerated; 
	public     VkBool32              integerDotProduct32BitSignedAccelerated; 
	public     VkBool32              integerDotProduct32BitMixedSignednessAccelerated; 
	public     VkBool32              integerDotProduct64BitUnsignedAccelerated; 
	public     VkBool32              integerDotProduct64BitSignedAccelerated; 
	public     VkBool32              integerDotProduct64BitMixedSignednessAccelerated; 
	public     VkBool32              integerDotProductAccumulatingSaturating8BitUnsignedAccelerated; 
	public     VkBool32              integerDotProductAccumulatingSaturating8BitSignedAccelerated; 
	public     VkBool32              integerDotProductAccumulatingSaturating8BitMixedSignednessAccelerated; 
	public     VkBool32              integerDotProductAccumulatingSaturating4x8BitPackedUnsignedAccelerated; 
	public     VkBool32              integerDotProductAccumulatingSaturating4x8BitPackedSignedAccelerated; 
	public     VkBool32              integerDotProductAccumulatingSaturating4x8BitPackedMixedSignednessAccelerated; 
	public     VkBool32              integerDotProductAccumulatingSaturating16BitUnsignedAccelerated; 
	public     VkBool32              integerDotProductAccumulatingSaturating16BitSignedAccelerated; 
	public     VkBool32              integerDotProductAccumulatingSaturating16BitMixedSignednessAccelerated; 
	public     VkBool32              integerDotProductAccumulatingSaturating32BitUnsignedAccelerated; 
	public     VkBool32              integerDotProductAccumulatingSaturating32BitSignedAccelerated; 
	public     VkBool32              integerDotProductAccumulatingSaturating32BitMixedSignednessAccelerated; 
	public     VkBool32              integerDotProductAccumulatingSaturating64BitUnsignedAccelerated; 
	public     VkBool32              integerDotProductAccumulatingSaturating64BitSignedAccelerated; 
	public     VkBool32              integerDotProductAccumulatingSaturating64BitMixedSignednessAccelerated; 
	public     VkDeviceSize          storageTexelBufferOffsetAlignmentBytes; 
	public     VkBool32              storageTexelBufferOffsetSingleTexelAlignment; 
	public     VkDeviceSize          uniformTexelBufferOffsetAlignmentBytes; 
	public     VkBool32              uniformTexelBufferOffsetSingleTexelAlignment; 
	public     VkDeviceSize          maxBufferSize; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineCreationFeedback {
	public     VkPipelineCreationFeedbackFlags    flags; 
	public     uint64_t                           duration; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineCreationFeedbackCreateInfo {
	public     VkStructureType                sType; 
	public      void*                    pNext; 
	public     VkPipelineCreationFeedback*    pPipelineCreationFeedback; 
	public     uint32_t                       pipelineStageCreationFeedbackCount; 
	public     VkPipelineCreationFeedback*    pPipelineStageCreationFeedbacks; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderTerminateInvocationFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderTerminateInvocation; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceToolProperties {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public fixed byte                  name[(int)VK.VK_MAX_EXTENSION_NAME_SIZE]; 
	public fixed byte                  version[(int)VK.VK_MAX_EXTENSION_NAME_SIZE]; 
	public     VkToolPurposeFlags    purposes; 
	public fixed byte                  description[(int)VK.VK_MAX_DESCRIPTION_SIZE]; 
	public fixed byte                  layer[(int)VK.VK_MAX_EXTENSION_NAME_SIZE]; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderDemoteToHelperInvocationFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderDemoteToHelperInvocation; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePrivateDataFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           privateData; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDevicePrivateDataCreateInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           privateDataSlotRequestCount; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPrivateDataSlotCreateInfo {
	public     VkStructureType                 sType; 
	public      void*                     pNext; 
	public     VkPrivateDataSlotCreateFlags    flags; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePipelineCreationCacheControlFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           pipelineCreationCacheControl; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryBarrier2 {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     VkPipelineStageFlags2    srcStageMask; 
	public     VkAccessFlags2           srcAccessMask; 
	public     VkPipelineStageFlags2    dstStageMask; 
	public     VkAccessFlags2           dstAccessMask; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBufferMemoryBarrier2 {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     VkPipelineStageFlags2    srcStageMask; 
	public     VkAccessFlags2           srcAccessMask; 
	public     VkPipelineStageFlags2    dstStageMask; 
	public     VkAccessFlags2           dstAccessMask; 
	public     uint32_t                 srcQueueFamilyIndex; 
	public     uint32_t                 dstQueueFamilyIndex; 
	public     VkBuffer                 buffer; 
	public     VkDeviceSize             offset; 
	public     VkDeviceSize             size; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageMemoryBarrier2 {
	public     VkStructureType            sType; 
	public      void*                pNext; 
	public     VkPipelineStageFlags2      srcStageMask; 
	public     VkAccessFlags2             srcAccessMask; 
	public     VkPipelineStageFlags2      dstStageMask; 
	public     VkAccessFlags2             dstAccessMask; 
	public     VkImageLayout              oldLayout; 
	public     VkImageLayout              newLayout; 
	public     uint32_t                   srcQueueFamilyIndex; 
	public     uint32_t                   dstQueueFamilyIndex; 
	public     VkImage                    image; 
	public     VkImageSubresourceRange    subresourceRange; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDependencyInfo {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkDependencyFlags                dependencyFlags; 
	public     uint32_t                         memoryBarrierCount; 
	public      VkMemoryBarrier2*          pMemoryBarriers; 
	public     uint32_t                         bufferMemoryBarrierCount; 
	public      VkBufferMemoryBarrier2*    pBufferMemoryBarriers; 
	public     uint32_t                         imageMemoryBarrierCount; 
	public      VkImageMemoryBarrier2*     pImageMemoryBarriers; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSemaphoreSubmitInfo {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     VkSemaphore              semaphore; 
	public     uint64_t                 value; 
	public     VkPipelineStageFlags2    stageMask; 
	public     uint32_t                 deviceIndex; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCommandBufferSubmitInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkCommandBuffer    commandBuffer; 
	public     uint32_t           deviceMask; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSubmitInfo2 {
	public     VkStructureType                     sType; 
	public      void*                         pNext; 
	public     VkSubmitFlags                       flags; 
	public     uint32_t                            waitSemaphoreInfoCount; 
	public      VkSemaphoreSubmitInfo*        pWaitSemaphoreInfos; 
	public     uint32_t                            commandBufferInfoCount; 
	public      VkCommandBufferSubmitInfo*    pCommandBufferInfos; 
	public     uint32_t                            signalSemaphoreInfoCount; 
	public      VkSemaphoreSubmitInfo*        pSignalSemaphoreInfos; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceSynchronization2Features {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           synchronization2; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceZeroInitializeWorkgroupMemoryFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderZeroInitializeWorkgroupMemory; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceImageRobustnessFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           robustImageAccess; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBufferCopy2 {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkDeviceSize       srcOffset; 
	public     VkDeviceSize       dstOffset; 
	public     VkDeviceSize       size; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyBufferInfo2 {
	public     VkStructureType         sType; 
	public      void*             pNext; 
	public     VkBuffer                srcBuffer; 
	public     VkBuffer                dstBuffer; 
	public     uint32_t                regionCount; 
	public      VkBufferCopy2*    pRegions; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageCopy2 {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkImageSubresourceLayers    srcSubresource; 
	public     VkOffset3D                  srcOffset; 
	public     VkImageSubresourceLayers    dstSubresource; 
	public     VkOffset3D                  dstOffset; 
	public     VkExtent3D                  extent; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyImageInfo2 {
	public     VkStructureType        sType; 
	public      void*            pNext; 
	public     VkImage                srcImage; 
	public     VkImageLayout          srcImageLayout; 
	public     VkImage                dstImage; 
	public     VkImageLayout          dstImageLayout; 
	public     uint32_t               regionCount; 
	public      VkImageCopy2*    pRegions; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBufferImageCopy2 {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkDeviceSize                bufferOffset; 
	public     uint32_t                    bufferRowLength; 
	public     uint32_t                    bufferImageHeight; 
	public     VkImageSubresourceLayers    imageSubresource; 
	public     VkOffset3D                  imageOffset; 
	public     VkExtent3D                  imageExtent; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyBufferToImageInfo2 {
	public     VkStructureType              sType; 
	public      void*                  pNext; 
	public     VkBuffer                     srcBuffer; 
	public     VkImage                      dstImage; 
	public     VkImageLayout                dstImageLayout; 
	public     uint32_t                     regionCount; 
	public      VkBufferImageCopy2*    pRegions; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyImageToBufferInfo2 {
	public     VkStructureType              sType; 
	public      void*                  pNext; 
	public     VkImage                      srcImage; 
	public     VkImageLayout                srcImageLayout; 
	public     VkBuffer                     dstBuffer; 
	public     uint32_t                     regionCount; 
	public      VkBufferImageCopy2*    pRegions; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageBlit2 {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkImageSubresourceLayers    srcSubresource;
	public VkOffset3D** srcOffsets;//[2]; 
	public     VkImageSubresourceLayers    dstSubresource;
	public VkOffset3D** dstOffsets;//[2]; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBlitImageInfo2 {
	public     VkStructureType        sType; 
	public      void*            pNext; 
	public     VkImage                srcImage; 
	public     VkImageLayout          srcImageLayout; 
	public     VkImage                dstImage; 
	public     VkImageLayout          dstImageLayout; 
	public     uint32_t               regionCount; 
	public      VkImageBlit2*    pRegions; 
	public     VkFilter               filter; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageResolve2 {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkImageSubresourceLayers    srcSubresource; 
	public     VkOffset3D                  srcOffset; 
	public     VkImageSubresourceLayers    dstSubresource; 
	public     VkOffset3D                  dstOffset; 
	public     VkExtent3D                  extent; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkResolveImageInfo2 {
	public     VkStructureType           sType; 
	public      void*               pNext; 
	public     VkImage                   srcImage; 
	public     VkImageLayout             srcImageLayout; 
	public     VkImage                   dstImage; 
	public     VkImageLayout             dstImageLayout; 
	public     uint32_t                  regionCount; 
	public      VkImageResolve2*    pRegions; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceSubgroupSizeControlFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           subgroupSizeControl; 
	public     VkBool32           computeFullSubgroups; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceSubgroupSizeControlProperties {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     uint32_t              minSubgroupSize; 
	public     uint32_t              maxSubgroupSize; 
	public     uint32_t              maxComputeWorkgroupSubgroups; 
	public     VkShaderStageFlags    requiredSubgroupSizeStages; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineShaderStageRequiredSubgroupSizeCreateInfo {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           requiredSubgroupSize; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceInlineUniformBlockFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           inlineUniformBlock; 
	public     VkBool32           descriptorBindingInlineUniformBlockUpdateAfterBind; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceInlineUniformBlockProperties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxInlineUniformBlockSize; 
	public     uint32_t           maxPerStageDescriptorInlineUniformBlocks; 
	public     uint32_t           maxPerStageDescriptorUpdateAfterBindInlineUniformBlocks; 
	public     uint32_t           maxDescriptorSetInlineUniformBlocks; 
	public     uint32_t           maxDescriptorSetUpdateAfterBindInlineUniformBlocks; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkWriteDescriptorSetInlineUniformBlock {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           dataSize; 
	public      void*        pData; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorPoolInlineUniformBlockCreateInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           maxInlineUniformBlockBindings; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceTextureCompressionASTCHDRFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           textureCompressionASTC_HDR; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderingAttachmentInfo {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     VkImageView              imageView; 
	public     VkImageLayout            imageLayout; 
	public     VkResolveModeFlagBits    resolveMode; 
	public     VkImageView              resolveImageView; 
	public     VkImageLayout            resolveImageLayout; 
	public     VkAttachmentLoadOp       loadOp; 
	public     VkAttachmentStoreOp      storeOp; 
	public     VkClearValue             clearValue; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderingInfo {
	public     VkStructureType                     sType; 
	public      void*                         pNext; 
	public     VkRenderingFlags                    flags; 
	public     VkRect2D                            renderArea; 
	public     uint32_t                            layerCount; 
	public     uint32_t                            viewMask; 
	public     uint32_t                            colorAttachmentCount; 
	public      VkRenderingAttachmentInfo*    pColorAttachments; 
	public      VkRenderingAttachmentInfo*    pDepthAttachment; 
	public      VkRenderingAttachmentInfo*    pStencilAttachment; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineRenderingCreateInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           viewMask; 
	public     uint32_t           colorAttachmentCount; 
	public      VkFormat*    pColorAttachmentFormats; 
	public     VkFormat           depthAttachmentFormat; 
	public     VkFormat           stencilAttachmentFormat; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDynamicRenderingFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           dynamicRendering; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCommandBufferInheritanceRenderingInfo {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     VkRenderingFlags         flags; 
	public     uint32_t                 viewMask; 
	public     uint32_t                 colorAttachmentCount; 
	public      VkFormat*          pColorAttachmentFormats; 
	public     VkFormat                 depthAttachmentFormat; 
	public     VkFormat                 stencilAttachmentFormat; 
	public     VkSampleCountFlagBits    rasterizationSamples; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderIntegerDotProductFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderIntegerDotProduct; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderIntegerDotProductProperties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           integerDotProduct8BitUnsignedAccelerated; 
	public     VkBool32           integerDotProduct8BitSignedAccelerated; 
	public     VkBool32           integerDotProduct8BitMixedSignednessAccelerated; 
	public     VkBool32           integerDotProduct4x8BitPackedUnsignedAccelerated; 
	public     VkBool32           integerDotProduct4x8BitPackedSignedAccelerated; 
	public     VkBool32           integerDotProduct4x8BitPackedMixedSignednessAccelerated; 
	public     VkBool32           integerDotProduct16BitUnsignedAccelerated; 
	public     VkBool32           integerDotProduct16BitSignedAccelerated; 
	public     VkBool32           integerDotProduct16BitMixedSignednessAccelerated; 
	public     VkBool32           integerDotProduct32BitUnsignedAccelerated; 
	public     VkBool32           integerDotProduct32BitSignedAccelerated; 
	public     VkBool32           integerDotProduct32BitMixedSignednessAccelerated; 
	public     VkBool32           integerDotProduct64BitUnsignedAccelerated; 
	public     VkBool32           integerDotProduct64BitSignedAccelerated; 
	public     VkBool32           integerDotProduct64BitMixedSignednessAccelerated; 
	public     VkBool32           integerDotProductAccumulatingSaturating8BitUnsignedAccelerated; 
	public     VkBool32           integerDotProductAccumulatingSaturating8BitSignedAccelerated; 
	public     VkBool32           integerDotProductAccumulatingSaturating8BitMixedSignednessAccelerated; 
	public     VkBool32           integerDotProductAccumulatingSaturating4x8BitPackedUnsignedAccelerated; 
	public     VkBool32           integerDotProductAccumulatingSaturating4x8BitPackedSignedAccelerated; 
	public     VkBool32           integerDotProductAccumulatingSaturating4x8BitPackedMixedSignednessAccelerated; 
	public     VkBool32           integerDotProductAccumulatingSaturating16BitUnsignedAccelerated; 
	public     VkBool32           integerDotProductAccumulatingSaturating16BitSignedAccelerated; 
	public     VkBool32           integerDotProductAccumulatingSaturating16BitMixedSignednessAccelerated; 
	public     VkBool32           integerDotProductAccumulatingSaturating32BitUnsignedAccelerated; 
	public     VkBool32           integerDotProductAccumulatingSaturating32BitSignedAccelerated; 
	public     VkBool32           integerDotProductAccumulatingSaturating32BitMixedSignednessAccelerated; 
	public     VkBool32           integerDotProductAccumulatingSaturating64BitUnsignedAccelerated; 
	public     VkBool32           integerDotProductAccumulatingSaturating64BitSignedAccelerated; 
	public     VkBool32           integerDotProductAccumulatingSaturating64BitMixedSignednessAccelerated; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceTexelBufferAlignmentProperties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkDeviceSize       storageTexelBufferOffsetAlignmentBytes; 
	public     VkBool32           storageTexelBufferOffsetSingleTexelAlignment; 
	public     VkDeviceSize       uniformTexelBufferOffsetAlignmentBytes; 
	public     VkBool32           uniformTexelBufferOffsetSingleTexelAlignment; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkFormatProperties3 {
	public     VkStructureType          sType; 
	public     void*                    pNext; 
	public     VkFormatFeatureFlags2    linearTilingFeatures; 
	public     VkFormatFeatureFlags2    optimalTilingFeatures; 
	public     VkFormatFeatureFlags2    bufferFeatures; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMaintenance4Features {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           maintenance4; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMaintenance4Properties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkDeviceSize       maxBufferSize; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceBufferMemoryRequirements {
	public     VkStructureType              sType; 
	public      void*                  pNext; 
	public      VkBufferCreateInfo*    pCreateInfo; 
}
// VK_VERSION_1_3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceImageMemoryRequirements {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public      VkImageCreateInfo*    pCreateInfo; 
	public     VkImageAspectFlagBits       planeAspect; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVulkan14Features {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           globalPriorityQuery; 
	public     VkBool32           shaderSubgroupRotate; 
	public     VkBool32           shaderSubgroupRotateClustered; 
	public     VkBool32           shaderFloatControls2; 
	public     VkBool32           shaderExpectAssume; 
	public     VkBool32           rectangularLines; 
	public     VkBool32           bresenhamLines; 
	public     VkBool32           smoothLines; 
	public     VkBool32           stippledRectangularLines; 
	public     VkBool32           stippledBresenhamLines; 
	public     VkBool32           stippledSmoothLines; 
	public     VkBool32           vertexAttributeInstanceRateDivisor; 
	public     VkBool32           vertexAttributeInstanceRateZeroDivisor; 
	public     VkBool32           indexTypeUint8; 
	public     VkBool32           dynamicRenderingLocalRead; 
	public     VkBool32           maintenance5; 
	public     VkBool32           maintenance6; 
	public     VkBool32           pipelineProtectedAccess; 
	public     VkBool32           pipelineRobustness; 
	public     VkBool32           hostImageCopy; 
	public     VkBool32           pushDescriptor; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVulkan14Properties {
	public     VkStructureType                       sType; 
	public     void*                                 pNext; 
	public     uint32_t                              lineSubPixelPrecisionBits; 
	public     uint32_t                              maxVertexAttribDivisor; 
	public     VkBool32                              supportsNonZeroFirstInstance; 
	public     uint32_t                              maxPushDescriptors; 
	public     VkBool32                              dynamicRenderingLocalReadDepthStencilAttachments; 
	public     VkBool32                              dynamicRenderingLocalReadMultisampledAttachments; 
	public     VkBool32                              earlyFragmentMultisampleCoverageAfterSampleCounting; 
	public     VkBool32                              earlyFragmentSampleMaskTestBeforeSampleCounting; 
	public     VkBool32                              depthStencilSwizzleOneSupport; 
	public     VkBool32                              polygonModePointSize; 
	public     VkBool32                              nonStrictSinglePixelWideLinesUseParallelogram; 
	public     VkBool32                              nonStrictWideLinesUseParallelogram; 
	public     VkBool32                              blockTexelViewCompatibleMultipleLayers; 
	public     uint32_t                              maxCombinedImageSamplerDescriptorCount; 
	public     VkBool32                              fragmentShadingRateClampCombinerInputs; 
	public     VkPipelineRobustnessBufferBehavior    defaultRobustnessStorageBuffers; 
	public     VkPipelineRobustnessBufferBehavior    defaultRobustnessUniformBuffers; 
	public     VkPipelineRobustnessBufferBehavior    defaultRobustnessVertexInputs; 
	public     VkPipelineRobustnessImageBehavior     defaultRobustnessImages; 
	public     uint32_t                              copySrcLayoutCount; 
	public     VkImageLayout*                        pCopySrcLayouts; 
	public     uint32_t                              copyDstLayoutCount; 
	public     VkImageLayout*                        pCopyDstLayouts; 
	public fixed     uint8_t                               optimalTilingLayoutUUID[(int)VK.VK_UUID_SIZE]; 
	public     VkBool32                              identicalMemoryTypeRequirements; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceQueueGlobalPriorityCreateInfo {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     VkQueueGlobalPriority    globalPriority; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceGlobalPriorityQueryFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           globalPriorityQuery; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkQueueFamilyGlobalPriorityProperties {
	public     VkStructureType          sType; 
	public     void*                    pNext; 
	public     uint32_t                 priorityCount;
	public VkQueueGlobalPriority** priorities; //[(int)VK.VK_MAX_GLOBAL_PRIORITY_SIZE]; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderSubgroupRotateFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderSubgroupRotate; 
	public     VkBool32           shaderSubgroupRotateClustered; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderFloatControls2Features {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderFloatControls2; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderExpectAssumeFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderExpectAssume; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceLineRasterizationFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           rectangularLines; 
	public     VkBool32           bresenhamLines; 
	public     VkBool32           smoothLines; 
	public     VkBool32           stippledRectangularLines; 
	public     VkBool32           stippledBresenhamLines; 
	public     VkBool32           stippledSmoothLines; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceLineRasterizationProperties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           lineSubPixelPrecisionBits; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineRasterizationLineStateCreateInfo {
	public     VkStructureType            sType; 
	public      void*                pNext; 
	public     VkLineRasterizationMode    lineRasterizationMode; 
	public     VkBool32                   stippledLineEnable; 
	public     uint32_t                   lineStippleFactor; 
	public     uint16_t                   lineStipplePattern; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVertexAttributeDivisorProperties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxVertexAttribDivisor; 
	public     VkBool32           supportsNonZeroFirstInstance; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVertexInputBindingDivisorDescription {
	public     uint32_t    binding; 
	public     uint32_t    divisor; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineVertexInputDivisorStateCreateInfo {
	public     VkStructureType                                  sType; 
	public      void*                                      pNext; 
	public     uint32_t                                         vertexBindingDivisorCount; 
	public      VkVertexInputBindingDivisorDescription*    pVertexBindingDivisors; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVertexAttributeDivisorFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           vertexAttributeInstanceRateDivisor; 
	public     VkBool32           vertexAttributeInstanceRateZeroDivisor; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceIndexTypeUint8Features {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           indexTypeUint8; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryMapInfo {
	public     VkStructureType     sType; 
	public      void*         pNext; 
	public     VkMemoryMapFlags    flags; 
	public     VkDeviceMemory      memory; 
	public     VkDeviceSize        offset; 
	public     VkDeviceSize        size; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryUnmapInfo {
	public     VkStructureType       sType; 
	public      void*           pNext; 
	public     VkMemoryUnmapFlags    flags; 
	public     VkDeviceMemory        memory; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMaintenance5Features {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           maintenance5; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMaintenance5Properties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           earlyFragmentMultisampleCoverageAfterSampleCounting; 
	public     VkBool32           earlyFragmentSampleMaskTestBeforeSampleCounting; 
	public     VkBool32           depthStencilSwizzleOneSupport; 
	public     VkBool32           polygonModePointSize; 
	public     VkBool32           nonStrictSinglePixelWideLinesUseParallelogram; 
	public     VkBool32           nonStrictWideLinesUseParallelogram; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderingAreaInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           viewMask; 
	public     uint32_t           colorAttachmentCount; 
	public      VkFormat*    pColorAttachmentFormats; 
	public     VkFormat           depthAttachmentFormat; 
	public     VkFormat           stencilAttachmentFormat; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageSubresource2 {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     VkImageSubresource    imageSubresource; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceImageSubresourceInfo {
	public     VkStructureType               sType; 
	public      void*                   pNext; 
	public      VkImageCreateInfo*      pCreateInfo; 
	public      VkImageSubresource2*    pSubresource; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSubresourceLayout2 {
	public     VkStructureType        sType; 
	public     void*                  pNext; 
	public     VkSubresourceLayout    subresourceLayout; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineCreateFlags2CreateInfo {
	public     VkStructureType           sType; 
	public      void*               pNext; 
	public     VkPipelineCreateFlags2    flags; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBufferUsageFlags2CreateInfo {
	public     VkStructureType        sType; 
	public      void*            pNext; 
	public     VkBufferUsageFlags2    usage; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePushDescriptorProperties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxPushDescriptors; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDynamicRenderingLocalReadFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           dynamicRenderingLocalRead; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderingAttachmentLocationInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           colorAttachmentCount; 
	public      uint32_t*    pColorAttachmentLocations; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderingInputAttachmentIndexInfo {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           colorAttachmentCount; 
	public      uint32_t*    pColorAttachmentInputIndices; 
	public      uint32_t*    pDepthInputAttachmentIndex; 
	public      uint32_t*    pStencilInputAttachmentIndex; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMaintenance6Features {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           maintenance6; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMaintenance6Properties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           blockTexelViewCompatibleMultipleLayers; 
	public     uint32_t           maxCombinedImageSamplerDescriptorCount; 
	public     VkBool32           fragmentShadingRateClampCombinerInputs; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindMemoryStatus {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkResult*          pResult; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindDescriptorSetsInfo {
	public     VkStructureType           sType; 
	public      void*               pNext; 
	public     VkShaderStageFlags        stageFlags; 
	public     VkPipelineLayout          layout; 
	public     uint32_t                  firstSet; 
	public     uint32_t                  descriptorSetCount; 
	public      VkDescriptorSet*    pDescriptorSets; 
	public     uint32_t                  dynamicOffsetCount; 
	public      uint32_t*           pDynamicOffsets; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPushConstantsInfo {
	public     VkStructureType       sType; 
	public      void*           pNext; 
	public     VkPipelineLayout      layout; 
	public     VkShaderStageFlags    stageFlags; 
	public     uint32_t              offset; 
	public     uint32_t              size; 
	public      void*           pValues; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPushDescriptorSetInfo {
	public     VkStructureType                sType; 
	public      void*                    pNext; 
	public     VkShaderStageFlags             stageFlags; 
	public     VkPipelineLayout               layout; 
	public     uint32_t                       set; 
	public     uint32_t                       descriptorWriteCount; 
	public      VkWriteDescriptorSet*    pDescriptorWrites; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPushDescriptorSetWithTemplateInfo {
	public     VkStructureType               sType; 
	public      void*                   pNext; 
	public     VkDescriptorUpdateTemplate    descriptorUpdateTemplate; 
	public     VkPipelineLayout              layout; 
	public     uint32_t                      set; 
	public      void*                   pData; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePipelineProtectedAccessFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           pipelineProtectedAccess; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePipelineRobustnessFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           pipelineRobustness; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePipelineRobustnessProperties {
	public     VkStructureType                       sType; 
	public     void*                                 pNext; 
	public     VkPipelineRobustnessBufferBehavior    defaultRobustnessStorageBuffers; 
	public     VkPipelineRobustnessBufferBehavior    defaultRobustnessUniformBuffers; 
	public     VkPipelineRobustnessBufferBehavior    defaultRobustnessVertexInputs; 
	public     VkPipelineRobustnessImageBehavior     defaultRobustnessImages; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineRobustnessCreateInfo {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkPipelineRobustnessBufferBehavior    storageBuffers; 
	public     VkPipelineRobustnessBufferBehavior    uniformBuffers; 
	public     VkPipelineRobustnessBufferBehavior    vertexInputs; 
	public     VkPipelineRobustnessImageBehavior     images; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceHostImageCopyFeatures {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           hostImageCopy; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceHostImageCopyProperties {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           copySrcLayoutCount; 
	public     VkImageLayout*     pCopySrcLayouts; 
	public     uint32_t           copyDstLayoutCount; 
	public     VkImageLayout*     pCopyDstLayouts; 
	public fixed     uint8_t            optimalTilingLayoutUUID[(int)VK.VK_UUID_SIZE]; 
	public     VkBool32           identicalMemoryTypeRequirements; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryToImageCopy {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public      void*                 pHostPointer; 
	public     uint32_t                    memoryRowLength; 
	public     uint32_t                    memoryImageHeight; 
	public     VkImageSubresourceLayers    imageSubresource; 
	public     VkOffset3D                  imageOffset; 
	public     VkExtent3D                  imageExtent; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageToMemoryCopy {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     void*                       pHostPointer; 
	public     uint32_t                    memoryRowLength; 
	public     uint32_t                    memoryImageHeight; 
	public     VkImageSubresourceLayers    imageSubresource; 
	public     VkOffset3D                  imageOffset; 
	public     VkExtent3D                  imageExtent; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyMemoryToImageInfo {
	public     VkStructureType               sType; 
	public      void*                   pNext; 
	public     VkHostImageCopyFlags          flags; 
	public     VkImage                       dstImage; 
	public     VkImageLayout                 dstImageLayout; 
	public     uint32_t                      regionCount; 
	public      VkMemoryToImageCopy*    pRegions; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyImageToMemoryInfo {
	public     VkStructureType               sType; 
	public      void*                   pNext; 
	public     VkHostImageCopyFlags          flags; 
	public     VkImage                       srcImage; 
	public     VkImageLayout                 srcImageLayout; 
	public     uint32_t                      regionCount; 
	public      VkImageToMemoryCopy*    pRegions; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyImageToImageInfo {
	public     VkStructureType         sType; 
	public      void*             pNext; 
	public     VkHostImageCopyFlags    flags; 
	public     VkImage                 srcImage; 
	public     VkImageLayout           srcImageLayout; 
	public     VkImage                 dstImage; 
	public     VkImageLayout           dstImageLayout; 
	public     uint32_t                regionCount; 
	public      VkImageCopy2*     pRegions; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkHostImageLayoutTransitionInfo {
	public     VkStructureType            sType; 
	public      void*                pNext; 
	public     VkImage                    image; 
	public     VkImageLayout              oldLayout; 
	public     VkImageLayout              newLayout; 
	public     VkImageSubresourceRange    subresourceRange; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSubresourceHostMemcpySize {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkDeviceSize       size; 
}
// VK_VERSION_1_4
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkHostImageCopyDevicePerformanceQuery {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           optimalDeviceAccess; 
	public     VkBool32           identicalMemoryLayout; 
}
// VK_KHR_surface
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSurfaceCapabilitiesKHR {
	public     uint32_t                         minImageCount; 
	public     uint32_t                         maxImageCount; 
	public     VkExtent2D                       currentExtent; 
	public     VkExtent2D                       minImageExtent; 
	public     VkExtent2D                       maxImageExtent; 
	public     uint32_t                         maxImageArrayLayers; 
	public     VkSurfaceTransformFlagsKHR       supportedTransforms; 
	public     VkSurfaceTransformFlagBitsKHR    currentTransform; 
	public     VkCompositeAlphaFlagsKHR         supportedCompositeAlpha; 
	public     VkImageUsageFlags                supportedUsageFlags; 
}
// VK_KHR_surface
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSurfaceFormatKHR {
	public     VkFormat           format; 
	public     VkColorSpaceKHR    colorSpace; 
}
// VK_KHR_swapchain
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSwapchainCreateInfoKHR {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkSwapchainCreateFlagsKHR        flags; 
	public     VkSurfaceKHR                     surface; 
	public     uint32_t                         minImageCount; 
	public     VkFormat                         imageFormat; 
	public     VkColorSpaceKHR                  imageColorSpace; 
	public     VkExtent2D                       imageExtent; 
	public     uint32_t                         imageArrayLayers; 
	public     VkImageUsageFlags                imageUsage; 
	public     VkSharingMode                    imageSharingMode; 
	public     uint32_t                         queueFamilyIndexCount; 
	public      uint32_t*                  pQueueFamilyIndices; 
	public     VkSurfaceTransformFlagBitsKHR    preTransform; 
	public     VkCompositeAlphaFlagBitsKHR      compositeAlpha; 
	public     VkPresentModeKHR                 presentMode; 
	public     VkBool32                         clipped; 
	public     VkSwapchainKHR                   oldSwapchain; 
}
// VK_KHR_swapchain
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPresentInfoKHR {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     uint32_t                 waitSemaphoreCount; 
	public      VkSemaphore*       pWaitSemaphores; 
	public     uint32_t                 swapchainCount; 
	public      VkSwapchainKHR*    pSwapchains; 
	public      uint32_t*          pImageIndices; 
	public     VkResult*                pResults; 
}
// VK_KHR_swapchain
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageSwapchainCreateInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkSwapchainKHR     swapchain; 
}
// VK_KHR_swapchain
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindImageMemorySwapchainInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkSwapchainKHR     swapchain; 
	public     uint32_t           imageIndex; 
}
// VK_KHR_swapchain
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAcquireNextImageInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkSwapchainKHR     swapchain; 
	public     uint64_t           timeout; 
	public     VkSemaphore        semaphore; 
	public     VkFence            fence; 
	public     uint32_t           deviceMask; 
}
// VK_KHR_swapchain
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceGroupPresentCapabilitiesKHR {
	public     VkStructureType                     sType; 
	public     void*                               pNext; 
	public fixed     uint32_t                            presentMask[(int)VK.VK_MAX_DEVICE_GROUP_SIZE]; 
	public     VkDeviceGroupPresentModeFlagsKHR    modes; 
}
// VK_KHR_swapchain
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceGroupPresentInfoKHR {
	public     VkStructureType                        sType; 
	public      void*                            pNext; 
	public     uint32_t                               swapchainCount; 
	public      uint32_t*                        pDeviceMasks; 
	public     VkDeviceGroupPresentModeFlagBitsKHR    mode; 
}
// VK_KHR_swapchain
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceGroupSwapchainCreateInfoKHR {
	public     VkStructureType                     sType; 
	public      void*                         pNext; 
	public     VkDeviceGroupPresentModeFlagsKHR    modes; 
}
// VK_KHR_display
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplayModeParametersKHR {
	public     VkExtent2D    visibleRegion; 
	public     uint32_t      refreshRate; 
}
// VK_KHR_display
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplayModeCreateInfoKHR {
	public     VkStructureType                sType; 
	public      void*                    pNext; 
	public     VkDisplayModeCreateFlagsKHR    flags; 
	public     VkDisplayModeParametersKHR     parameters; 
}
// VK_KHR_display
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplayModePropertiesKHR {
	public     VkDisplayModeKHR              displayMode; 
	public     VkDisplayModeParametersKHR    parameters; 
}
// VK_KHR_display
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplayPlaneCapabilitiesKHR {
	public     VkDisplayPlaneAlphaFlagsKHR    supportedAlpha; 
	public     VkOffset2D                     minSrcPosition; 
	public     VkOffset2D                     maxSrcPosition; 
	public     VkExtent2D                     minSrcExtent; 
	public     VkExtent2D                     maxSrcExtent; 
	public     VkOffset2D                     minDstPosition; 
	public     VkOffset2D                     maxDstPosition; 
	public     VkExtent2D                     minDstExtent; 
	public     VkExtent2D                     maxDstExtent; 
}
// VK_KHR_display
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplayPlanePropertiesKHR {
	public     VkDisplayKHR    currentDisplay; 
	public     uint32_t        currentStackIndex; 
}
// VK_KHR_display
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplayPropertiesKHR {
	public     VkDisplayKHR                  display; 
	public      ConstChar*                   displayName; 
	public     VkExtent2D                    physicalDimensions; 
	public     VkExtent2D                    physicalResolution; 
	public     VkSurfaceTransformFlagsKHR    supportedTransforms; 
	public     VkBool32                      planeReorderPossible; 
	public     VkBool32                      persistentContent; 
}
// VK_KHR_display
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplaySurfaceCreateInfoKHR {
	public     VkStructureType                   sType; 
	public      void*                       pNext; 
	public     VkDisplaySurfaceCreateFlagsKHR    flags; 
	public     VkDisplayModeKHR                  displayMode; 
	public     uint32_t                          planeIndex; 
	public     uint32_t                          planeStackIndex; 
	public     VkSurfaceTransformFlagBitsKHR     transform; 
	public     float                             globalAlpha; 
	public     VkDisplayPlaneAlphaFlagBitsKHR    alphaMode; 
	public     VkExtent2D                        imageExtent; 
}
// VK_KHR_display_swapchain
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplayPresentInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkRect2D           srcRect; 
	public     VkRect2D           dstRect; 
	public     VkBool32           persistent; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkQueueFamilyQueryResultStatusPropertiesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           queryResultStatusSupport; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkQueueFamilyVideoPropertiesKHR {
	public     VkStructureType                  sType; 
	public     void*                            pNext; 
	public     VkVideoCodecOperationFlagsKHR    videoCodecOperations; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoProfileInfoKHR {
	public     VkStructureType                     sType; 
	public      void*                         pNext; 
	public     VkVideoCodecOperationFlagBitsKHR    videoCodecOperation; 
	public     VkVideoChromaSubsamplingFlagsKHR    chromaSubsampling; 
	public     VkVideoComponentBitDepthFlagsKHR    lumaBitDepth; 
	public     VkVideoComponentBitDepthFlagsKHR    chromaBitDepth; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoProfileListInfoKHR {
	public     VkStructureType                 sType; 
	public      void*                     pNext; 
	public     uint32_t                        profileCount; 
	public      VkVideoProfileInfoKHR*    pProfiles; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoCapabilitiesKHR {
	public     VkStructureType              sType; 
	public     void*                        pNext; 
	public     VkVideoCapabilityFlagsKHR    flags; 
	public     VkDeviceSize                 minBitstreamBufferOffsetAlignment; 
	public     VkDeviceSize                 minBitstreamBufferSizeAlignment; 
	public     VkExtent2D                   pictureAccessGranularity; 
	public     VkExtent2D                   minCodedExtent; 
	public     VkExtent2D                   maxCodedExtent; 
	public     uint32_t                     maxDpbSlots; 
	public     uint32_t                     maxActiveReferencePictures; 
	public     VkExtensionProperties        stdHeaderVersion; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVideoFormatInfoKHR {
	public     VkStructureType      sType; 
	public      void*          pNext; 
	public     VkImageUsageFlags    imageUsage; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoFormatPropertiesKHR {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     VkFormat              format; 
	public     VkComponentMapping    componentMapping; 
	public     VkImageCreateFlags    imageCreateFlags; 
	public     VkImageType           imageType; 
	public     VkImageTiling         imageTiling; 
	public     VkImageUsageFlags     imageUsageFlags; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoPictureResourceInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkOffset2D         codedOffset; 
	public     VkExtent2D         codedExtent; 
	public     uint32_t           baseArrayLayer; 
	public     VkImageView        imageViewBinding; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoReferenceSlotInfoKHR {
	public     VkStructureType                         sType; 
	public      void*                             pNext; 
	public     int32_t                                 slotIndex; 
	public      VkVideoPictureResourceInfoKHR*    pPictureResource; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoSessionMemoryRequirementsKHR {
	public     VkStructureType         sType; 
	public     void*                   pNext; 
	public     uint32_t                memoryBindIndex; 
	public     VkMemoryRequirements    memoryRequirements; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindVideoSessionMemoryInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           memoryBindIndex; 
	public     VkDeviceMemory     memory; 
	public     VkDeviceSize       memoryOffset; 
	public     VkDeviceSize       memorySize; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoSessionCreateInfoKHR {
	public     VkStructureType                 sType; 
	public      void*                     pNext; 
	public     uint32_t                        queueFamilyIndex; 
	public     VkVideoSessionCreateFlagsKHR    flags; 
	public      VkVideoProfileInfoKHR*    pVideoProfile; 
	public     VkFormat                        pictureFormat; 
	public     VkExtent2D                      maxCodedExtent; 
	public     VkFormat                        referencePictureFormat; 
	public     uint32_t                        maxDpbSlots; 
	public     uint32_t                        maxActiveReferencePictures; 
	public      VkExtensionProperties*    pStdHeaderVersion; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoSessionParametersCreateInfoKHR {
	public     VkStructureType                           sType; 
	public      void*                               pNext; 
	public     VkVideoSessionParametersCreateFlagsKHR    flags; 
	public     VkVideoSessionParametersKHR               videoSessionParametersTemplate; 
	public     VkVideoSessionKHR                         videoSession; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoSessionParametersUpdateInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           updateSequenceCount; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoBeginCodingInfoKHR {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkVideoBeginCodingFlagsKHR            flags; 
	public     VkVideoSessionKHR                     videoSession; 
	public     VkVideoSessionParametersKHR           videoSessionParameters; 
	public     uint32_t                              referenceSlotCount; 
	public      VkVideoReferenceSlotInfoKHR*    pReferenceSlots; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoEndCodingInfoKHR {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkVideoEndCodingFlagsKHR    flags; 
}
// VK_KHR_video_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoCodingControlInfoKHR {
	public     VkStructureType                 sType; 
	public      void*                     pNext; 
	public     VkVideoCodingControlFlagsKHR    flags; 
}
// VK_KHR_video_decode_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoDecodeCapabilitiesKHR {
	public     VkStructureType                    sType; 
	public     void*                              pNext; 
	public     VkVideoDecodeCapabilityFlagsKHR    flags; 
}
// VK_KHR_video_decode_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoDecodeUsageInfoKHR {
	public     VkStructureType               sType; 
	public      void*                   pNext; 
	public     VkVideoDecodeUsageFlagsKHR    videoUsageHints; 
}
// VK_KHR_video_decode_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoDecodeInfoKHR {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkVideoDecodeFlagsKHR                 flags; 
	public     VkBuffer                              srcBuffer; 
	public     VkDeviceSize                          srcBufferOffset; 
	public     VkDeviceSize                          srcBufferRange; 
	public     VkVideoPictureResourceInfoKHR         dstPictureResource; 
	public      VkVideoReferenceSlotInfoKHR*    pSetupReferenceSlot; 
	public     uint32_t                              referenceSlotCount; 
	public      VkVideoReferenceSlotInfoKHR*    pReferenceSlots; 
}
// // VK_KHR_video_encode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH264CapabilitiesKHR {
// 	public     VkStructureType                        sType; 
// 	public     void*                                  pNext; 
// 	public     VkVideoEncodeH264CapabilityFlagsKHR    flags; 
// 	public     StdVideoH264LevelIdc                   maxLevelIdc; 
// 	public     uint32_t                               maxSliceCount; 
// 	public     uint32_t                               maxPPictureL0ReferenceCount; 
// 	public     uint32_t                               maxBPictureL0ReferenceCount; 
// 	public     uint32_t                               maxL1ReferenceCount; 
// 	public     uint32_t                               maxTemporalLayerCount; 
// 	public     VkBool32                               expectDyadicTemporalLayerPattern; 
// 	public     int32_t                                minQp; 
// 	public     int32_t                                maxQp; 
// 	public     VkBool32                               prefersGopRemainingFrames; 
// 	public     VkBool32                               requiresGopRemainingFrames; 
// 	public     VkVideoEncodeH264StdFlagsKHR           stdSyntaxFlags; 
// }
// // VK_KHR_video_encode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  
// public unsafe  struct VkVideoEncodeH264QpKHR {
// 	public     int32_t    qpI; 
// 	public     int32_t    qpP; 
// 	public     int32_t    qpB; 
// }
// // VK_KHR_video_encode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  
// public unsafe  struct VkVideoEncodeH264QualityLevelPropertiesKHR {
// 	public     VkStructureType                         sType; 
// 	public     void*                                   pNext; 
// 	public     VkVideoEncodeH264RateControlFlagsKHR    preferredRateControlFlags; 
// 	public     uint32_t                                preferredGopFrameCount; 
// 	public     uint32_t                                preferredIdrPeriod; 
// 	public     uint32_t                                preferredConsecutiveBFrameCount; 
// 	public     uint32_t                                preferredTemporalLayerCount; 
// 	public     VkVideoEncodeH264QpKHR                  preferredConstantQp; 
// 	public     uint32_t                                preferredMaxL0ReferenceCount; 
// 	public     uint32_t                                preferredMaxL1ReferenceCount; 
// 	public     VkBool32                                preferredStdEntropyCodingModeFlag; 
// }
// // VK_KHR_video_encode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  
// public unsafe  struct VkVideoEncodeH264SessionCreateInfoKHR {
// 	public     VkStructureType         sType; 
// 	public      void*             pNext; 
// 	public     VkBool32                useMaxLevelIdc; 
// 	public     StdVideoH264LevelIdc    maxLevelIdc; 
// }
// // VK_KHR_video_encode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  
// public unsafe  struct VkVideoEncodeH264SessionParametersAddInfoKHR {
// 	public     VkStructureType                            sType; 
// 	public      void*                                pNext; 
// 	public     uint32_t                                   stdSPSCount; 
// 	public      StdVideoH264SequenceParameterSet*    pStdSPSs; 
// 	public     uint32_t                                   stdPPSCount; 
// 	public      StdVideoH264PictureParameterSet*     pStdPPSs; 
// }
// // VK_KHR_video_encode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  
// public unsafe  struct VkVideoEncodeH264SessionParametersCreateInfoKHR {
// 	public     VkStructureType                                        sType; 
// 	public      void*                                            pNext; 
// 	public     uint32_t                                               maxStdSPSCount; 
// 	public     uint32_t                                               maxStdPPSCount; 
// 	public      VkVideoEncodeH264SessionParametersAddInfoKHR*    pParametersAddInfo; 
// }
// // VK_KHR_video_encode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  
// public unsafe  struct VkVideoEncodeH264SessionParametersGetInfoKHR {
// 	public     VkStructureType    sType; 
// 	public      void*        pNext; 
// 	public     VkBool32           writeStdSPS; 
// 	public     VkBool32           writeStdPPS; 
// 	public     uint32_t           stdSPSId; 
// 	public     uint32_t           stdPPSId; 
// }
// // VK_KHR_video_encode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  
// public unsafe  struct VkVideoEncodeH264SessionParametersFeedbackInfoKHR {
// 	public     VkStructureType    sType; 
// 	public     void*              pNext; 
// 	public     VkBool32           hasStdSPSOverrides; 
// 	public     VkBool32           hasStdPPSOverrides; 
// }
// // VK_KHR_video_encode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  
// public unsafe  struct VkVideoEncodeH264NaluSliceInfoKHR {
// 	public     VkStructureType                         sType; 
// 	public      void*                             pNext; 
// 	public     int32_t                                 constantQp; 
// 	public      StdVideoEncodeH264SliceHeader*    pStdSliceHeader; 
// }
// // VK_KHR_video_encode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH264PictureInfoKHR {
// 	public     VkStructureType                             sType; 
// 	public      void*                                 pNext; 
// 	public     uint32_t                                    naluSliceEntryCount; 
// 	public      VkVideoEncodeH264NaluSliceInfoKHR*    pNaluSliceEntries; 
// 	public      StdVideoEncodeH264PictureInfo*        pStdPictureInfo; 
// 	public     VkBool32                                    generatePrefixNalu; 
// }
// // VK_KHR_video_encode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH264DpbSlotInfoKHR {
// 	public     VkStructureType                           sType; 
// 	public      void*                               pNext; 
// 	public      StdVideoEncodeH264ReferenceInfo*    pStdReferenceInfo; 
// }
// // VK_KHR_video_encode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH264ProfileInfoKHR {
// 	public     VkStructureType           sType; 
// 	public      void*               pNext; 
// 	public     StdVideoH264ProfileIdc    stdProfileIdc; 
// }
// // VK_KHR_video_encode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH264RateControlInfoKHR {
// 	public     VkStructureType                         sType; 
// 	public      void*                             pNext; 
// 	public     VkVideoEncodeH264RateControlFlagsKHR    flags; 
// 	public     uint32_t                                gopFrameCount; 
// 	public     uint32_t                                idrPeriod; 
// 	public     uint32_t                                consecutiveBFrameCount; 
// 	public     uint32_t                                temporalLayerCount; 
// }
// // VK_KHR_video_encode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH264FrameSizeKHR {
// 	public     uint32_t    frameISize; 
// 	public     uint32_t    framePSize; 
// 	public     uint32_t    frameBSize; 
// }
// // VK_KHR_video_encode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH264RateControlLayerInfoKHR {
// 	public     VkStructureType                  sType; 
// 	public      void*                      pNext; 
// 	public     VkBool32                         useMinQp; 
// 	public     VkVideoEncodeH264QpKHR           minQp; 
// 	public     VkBool32                         useMaxQp; 
// 	public     VkVideoEncodeH264QpKHR           maxQp; 
// 	public     VkBool32                         useMaxFrameSize; 
// 	public     VkVideoEncodeH264FrameSizeKHR    maxFrameSize; 
// }
// // VK_KHR_video_encode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH264GopRemainingFrameInfoKHR {
// 	public     VkStructureType    sType; 
// 	public      void*        pNext; 
// 	public     VkBool32           useGopRemainingFrames; 
// 	public     uint32_t           gopRemainingI; 
// 	public     uint32_t           gopRemainingP; 
// 	public     uint32_t           gopRemainingB; 
// }
// // VK_KHR_video_encode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH265CapabilitiesKHR {
// 	public     VkStructureType                                sType; 
// 	public     void*                                          pNext; 
// 	public     VkVideoEncodeH265CapabilityFlagsKHR            flags; 
// 	public     StdVideoH265LevelIdc                           maxLevelIdc; 
// 	public     uint32_t                                       maxSliceSegmentCount; 
// 	public     VkExtent2D                                     maxTiles; 
// 	public     VkVideoEncodeH265CtbSizeFlagsKHR               ctbSizes; 
// 	public     VkVideoEncodeH265TransformBlockSizeFlagsKHR    transformBlockSizes; 
// 	public     uint32_t                                       maxPPictureL0ReferenceCount; 
// 	public     uint32_t                                       maxBPictureL0ReferenceCount; 
// 	public     uint32_t                                       maxL1ReferenceCount; 
// 	public     uint32_t                                       maxSubLayerCount; 
// 	public     VkBool32                                       expectDyadicTemporalSubLayerPattern; 
// 	public     int32_t                                        minQp; 
// 	public     int32_t                                        maxQp; 
// 	public     VkBool32                                       prefersGopRemainingFrames; 
// 	public     VkBool32                                       requiresGopRemainingFrames; 
// 	public     VkVideoEncodeH265StdFlagsKHR                   stdSyntaxFlags; 
// }
// // VK_KHR_video_encode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH265SessionCreateInfoKHR {
// 	public     VkStructureType         sType; 
// 	public      void*             pNext; 
// 	public     VkBool32                useMaxLevelIdc; 
// 	public     StdVideoH265LevelIdc    maxLevelIdc; 
// }
// // VK_KHR_video_encode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH265QpKHR {
// 	public     int32_t    qpI; 
// 	public     int32_t    qpP; 
// 	public     int32_t    qpB; 
// }
// // VK_KHR_video_encode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH265QualityLevelPropertiesKHR {
// 	public     VkStructureType                         sType; 
// 	public     void*                                   pNext; 
// 	public     VkVideoEncodeH265RateControlFlagsKHR    preferredRateControlFlags; 
// 	public     uint32_t                                preferredGopFrameCount; 
// 	public     uint32_t                                preferredIdrPeriod; 
// 	public     uint32_t                                preferredConsecutiveBFrameCount; 
// 	public     uint32_t                                preferredSubLayerCount; 
// 	public     VkVideoEncodeH265QpKHR                  preferredConstantQp; 
// 	public     uint32_t                                preferredMaxL0ReferenceCount; 
// 	public     uint32_t                                preferredMaxL1ReferenceCount; 
// }
// // VK_KHR_video_encode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH265SessionParametersAddInfoKHR {
// 	public     VkStructureType                            sType; 
// 	public      void*                                pNext; 
// 	public     uint32_t                                   stdVPSCount; 
// 	public      StdVideoH265VideoParameterSet*       pStdVPSs; 
// 	public     uint32_t                                   stdSPSCount; 
// 	public      StdVideoH265SequenceParameterSet*    pStdSPSs; 
// 	public     uint32_t                                   stdPPSCount; 
// 	public      StdVideoH265PictureParameterSet*     pStdPPSs; 
// }
// // VK_KHR_video_encode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH265SessionParametersCreateInfoKHR {
// 	public     VkStructureType                                        sType; 
// 	public      void*                                            pNext; 
// 	public     uint32_t                                               maxStdVPSCount; 
// 	public     uint32_t                                               maxStdSPSCount; 
// 	public     uint32_t                                               maxStdPPSCount; 
// 	public      VkVideoEncodeH265SessionParametersAddInfoKHR*    pParametersAddInfo; 
// }
// // VK_KHR_video_encode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH265SessionParametersGetInfoKHR {
// 	public     VkStructureType    sType; 
// 	public      void*        pNext; 
// 	public     VkBool32           writeStdVPS; 
// 	public     VkBool32           writeStdSPS; 
// 	public     VkBool32           writeStdPPS; 
// 	public     uint32_t           stdVPSId; 
// 	public     uint32_t           stdSPSId; 
// 	public     uint32_t           stdPPSId; 
// }
// // VK_KHR_video_encode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH265SessionParametersFeedbackInfoKHR {
// 	public     VkStructureType    sType; 
// 	public     void*              pNext; 
// 	public     VkBool32           hasStdVPSOverrides; 
// 	public     VkBool32           hasStdSPSOverrides; 
// 	public     VkBool32           hasStdPPSOverrides; 
// }
// // VK_KHR_video_encode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH265NaluSliceSegmentInfoKHR {
// 	public     VkStructureType                                sType; 
// 	public      void*                                    pNext; 
// 	public     int32_t                                        constantQp; 
// 	public      StdVideoEncodeH265SliceSegmentHeader*    pStdSliceSegmentHeader; 
// }
// // VK_KHR_video_encode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH265PictureInfoKHR {
// 	public     VkStructureType                                    sType; 
// 	public      void*                                        pNext; 
// 	public     uint32_t                                           naluSliceSegmentEntryCount; 
// 	public      VkVideoEncodeH265NaluSliceSegmentInfoKHR*    pNaluSliceSegmentEntries; 
// 	public      StdVideoEncodeH265PictureInfo*               pStdPictureInfo; 
// }
// // VK_KHR_video_encode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH265DpbSlotInfoKHR {
// 	public     VkStructureType                           sType; 
// 	public      void*                               pNext; 
// 	public      StdVideoEncodeH265ReferenceInfo*    pStdReferenceInfo; 
// }
// // VK_KHR_video_encode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH265ProfileInfoKHR {
// 	public     VkStructureType           sType; 
// 	public      void*               pNext; 
// 	public     StdVideoH265ProfileIdc    stdProfileIdc; 
// }
// // VK_KHR_video_encode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH265RateControlInfoKHR {
// 	public     VkStructureType                         sType; 
// 	public      void*                             pNext; 
// 	public     VkVideoEncodeH265RateControlFlagsKHR    flags; 
// 	public     uint32_t                                gopFrameCount; 
// 	public     uint32_t                                idrPeriod; 
// 	public     uint32_t                                consecutiveBFrameCount; 
// 	public     uint32_t                                subLayerCount; 
// }
// // VK_KHR_video_encode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH265FrameSizeKHR {
// 	public     uint32_t    frameISize; 
// 	public     uint32_t    framePSize; 
// 	public     uint32_t    frameBSize; 
// }
// // VK_KHR_video_encode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH265RateControlLayerInfoKHR {
// 	public     VkStructureType                  sType; 
// 	public      void*                      pNext; 
// 	public     VkBool32                         useMinQp; 
// 	public     VkVideoEncodeH265QpKHR           minQp; 
// 	public     VkBool32                         useMaxQp; 
// 	public     VkVideoEncodeH265QpKHR           maxQp; 
// 	public     VkBool32                         useMaxFrameSize; 
// 	public     VkVideoEncodeH265FrameSizeKHR    maxFrameSize; 
// }
// // VK_KHR_video_encode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeH265GopRemainingFrameInfoKHR {
// 	public     VkStructureType    sType; 
// 	public      void*        pNext; 
// 	public     VkBool32           useGopRemainingFrames; 
// 	public     uint32_t           gopRemainingI; 
// 	public     uint32_t           gopRemainingP; 
// 	public     uint32_t           gopRemainingB; 
// }
// // VK_KHR_video_decode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeH264ProfileInfoKHR {
// 	public     VkStructureType                              sType; 
// 	public      void*                                  pNext; 
// 	public     StdVideoH264ProfileIdc                       stdProfileIdc; 
// 	public     VkVideoDecodeH264PictureLayoutFlagBitsKHR    pictureLayout; 
// }
// // VK_KHR_video_decode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeH264CapabilitiesKHR {
// 	public     VkStructureType         sType; 
// 	public     void*                   pNext; 
// 	public     StdVideoH264LevelIdc    maxLevelIdc; 
// 	public     VkOffset2D              fieldOffsetGranularity; 
// }
// // VK_KHR_video_decode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeH264SessionParametersAddInfoKHR {
// 	public     VkStructureType                            sType; 
// 	public      void*                                pNext; 
// 	public     uint32_t                                   stdSPSCount; 
// 	public      StdVideoH264SequenceParameterSet*    pStdSPSs; 
// 	public     uint32_t                                   stdPPSCount; 
// 	public      StdVideoH264PictureParameterSet*     pStdPPSs; 
// }
// // VK_KHR_video_decode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeH264SessionParametersCreateInfoKHR {
// 	public     VkStructureType                                        sType; 
// 	public      void*                                            pNext; 
// 	public     uint32_t                                               maxStdSPSCount; 
// 	public     uint32_t                                               maxStdPPSCount; 
// 	public      VkVideoDecodeH264SessionParametersAddInfoKHR*    pParametersAddInfo; 
// }
// // VK_KHR_video_decode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeH264PictureInfoKHR {
// 	public     VkStructureType                         sType; 
// 	public      void*                             pNext; 
// 	public      StdVideoDecodeH264PictureInfo*    pStdPictureInfo; 
// 	public     uint32_t                                sliceCount; 
// 	public      uint32_t*                         pSliceOffsets; 
// }
// // VK_KHR_video_decode_h264
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeH264DpbSlotInfoKHR {
// 	public     VkStructureType                           sType; 
// 	public      void*                               pNext; 
// 	public      StdVideoDecodeH264ReferenceInfo*    pStdReferenceInfo; 
// }
// VK_KHR_external_memory_fd
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImportMemoryFdInfoKHR {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkExternalMemoryHandleTypeFlagBits    handleType; 
	public     int                                   fd; 
}
// VK_KHR_external_memory_fd
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryFdPropertiesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           memoryTypeBits; 
}
// VK_KHR_external_memory_fd
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryGetFdInfoKHR {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkDeviceMemory                        memory; 
	public     VkExternalMemoryHandleTypeFlagBits    handleType; 
}
// VK_KHR_external_semaphore_fd
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImportSemaphoreFdInfoKHR {
	public     VkStructureType                          sType; 
	public      void*                              pNext; 
	public     VkSemaphore                              semaphore; 
	public     VkSemaphoreImportFlags                   flags; 
	public     VkExternalSemaphoreHandleTypeFlagBits    handleType; 
	public     int                                      fd; 
}
// VK_KHR_external_semaphore_fd
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSemaphoreGetFdInfoKHR {
	public     VkStructureType                          sType; 
	public      void*                              pNext; 
	public     VkSemaphore                              semaphore; 
	public     VkExternalSemaphoreHandleTypeFlagBits    handleType; 
}
// VK_KHR_incremental_present
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRectLayerKHR {
	public     VkOffset2D    offset; 
	public     VkExtent2D    extent; 
	public     uint32_t      layer; 
}
// VK_KHR_incremental_present
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPresentRegionKHR {
	public     uint32_t                 rectangleCount; 
	public      VkRectLayerKHR*    pRectangles; 
}
// VK_KHR_incremental_present
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPresentRegionsKHR {
	public     VkStructureType              sType; 
	public      void*                  pNext; 
	public     uint32_t                     swapchainCount; 
	public      VkPresentRegionKHR*    pRegions; 
}
// VK_KHR_shared_presentable_image
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSharedPresentSurfaceCapabilitiesKHR {
	public     VkStructureType      sType; 
	public     void*                pNext; 
	public     VkImageUsageFlags    sharedPresentSupportedUsageFlags; 
}
// VK_KHR_external_fence_fd
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImportFenceFdInfoKHR {
	public     VkStructureType                      sType; 
	public      void*                          pNext; 
	public     VkFence                              fence; 
	public     VkFenceImportFlags                   flags; 
	public     VkExternalFenceHandleTypeFlagBits    handleType; 
	public     int                                  fd; 
}
// VK_KHR_external_fence_fd
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkFenceGetFdInfoKHR {
	public     VkStructureType                      sType; 
	public      void*                          pNext; 
	public     VkFence                              fence; 
	public     VkExternalFenceHandleTypeFlagBits    handleType; 
}
// VK_KHR_performance_query
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePerformanceQueryFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           performanceCounterQueryPools; 
	public     VkBool32           performanceCounterMultipleQueryPools; 
}
// VK_KHR_performance_query
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePerformanceQueryPropertiesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           allowCommandBufferQueryCopies; 
}
// VK_KHR_performance_query
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPerformanceCounterKHR {
	public     VkStructureType                   sType; 
	public     void*                             pNext; 
	public     VkPerformanceCounterUnitKHR       unit; 
	public     VkPerformanceCounterScopeKHR      scope; 
	public     VkPerformanceCounterStorageKHR    storage; 
	public fixed     uint8_t                           uuid[(int)VK.VK_UUID_SIZE]; 
}
// VK_KHR_performance_query
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPerformanceCounterDescriptionKHR {
	public     VkStructureType                            sType; 
	public     void*                                      pNext; 
	public     VkPerformanceCounterDescriptionFlagsKHR    flags; 
	public fixed byte                                       name[(int)VK.VK_MAX_DESCRIPTION_SIZE]; 
	public fixed byte                                       category[(int)VK.VK_MAX_DESCRIPTION_SIZE]; 
	public fixed byte                                       description[(int)VK.VK_MAX_DESCRIPTION_SIZE]; 
}
// VK_KHR_performance_query
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkQueryPoolPerformanceCreateInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           queueFamilyIndex; 
	public     uint32_t           counterIndexCount; 
	public      uint32_t*    pCounterIndices; 
}
// VK_KHR_performance_query
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAcquireProfilingLockInfoKHR {
	public     VkStructureType                   sType; 
	public      void*                       pNext; 
	public     VkAcquireProfilingLockFlagsKHR    flags; 
	public     uint64_t                          timeout; 
}
// VK_KHR_performance_query
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPerformanceQuerySubmitInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           counterPassIndex; 
}
// VK_KHR_get_surface_capabilities2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceSurfaceInfo2KHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkSurfaceKHR       surface; 
}
// VK_KHR_get_surface_capabilities2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSurfaceCapabilities2KHR {
	public     VkStructureType             sType; 
	public     void*                       pNext; 
	public     VkSurfaceCapabilitiesKHR    surfaceCapabilities; 
}
// VK_KHR_get_surface_capabilities2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSurfaceFormat2KHR {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     VkSurfaceFormatKHR    surfaceFormat; 
}
// VK_KHR_get_display_properties2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplayProperties2KHR {
	public     VkStructureType           sType; 
	public     void*                     pNext; 
	public     VkDisplayPropertiesKHR    displayProperties; 
}
// VK_KHR_get_display_properties2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplayPlaneProperties2KHR {
	public     VkStructureType                sType; 
	public     void*                          pNext; 
	public     VkDisplayPlanePropertiesKHR    displayPlaneProperties; 
}
// VK_KHR_get_display_properties2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplayModeProperties2KHR {
	public     VkStructureType               sType; 
	public     void*                         pNext; 
	public     VkDisplayModePropertiesKHR    displayModeProperties; 
}
// VK_KHR_get_display_properties2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplayPlaneInfo2KHR {
	public     VkStructureType     sType; 
	public      void*         pNext; 
	public     VkDisplayModeKHR    mode; 
	public     uint32_t            planeIndex; 
}
// VK_KHR_get_display_properties2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplayPlaneCapabilities2KHR {
	public     VkStructureType                  sType; 
	public     void*                            pNext; 
	public     VkDisplayPlaneCapabilitiesKHR    capabilities; 
}
// VK_KHR_shader_bfloat16
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderBfloat16FeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderBFloat16Type; 
	public     VkBool32           shaderBFloat16DotProduct; 
	public     VkBool32           shaderBFloat16CooperativeMatrix; 
}
// VK_KHR_shader_clock
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderClockFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderSubgroupClock; 
	public     VkBool32           shaderDeviceClock; 
}
// // VK_KHR_video_decode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeH265ProfileInfoKHR {
// 	public     VkStructureType           sType; 
// 	public      void*               pNext; 
// 	public     StdVideoH265ProfileIdc    stdProfileIdc; 
// }
// // VK_KHR_video_decode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeH265CapabilitiesKHR {
// 	public     VkStructureType         sType; 
// 	public     void*                   pNext; 
// 	public     StdVideoH265LevelIdc    maxLevelIdc; 
// }
// // VK_KHR_video_decode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeH265SessionParametersAddInfoKHR {
// 	public     VkStructureType                            sType; 
// 	public      void*                                pNext; 
// 	public     uint32_t                                   stdVPSCount; 
// 	public      StdVideoH265VideoParameterSet*       pStdVPSs; 
// 	public     uint32_t                                   stdSPSCount; 
// 	public      StdVideoH265SequenceParameterSet*    pStdSPSs; 
// 	public     uint32_t                                   stdPPSCount; 
// 	public      StdVideoH265PictureParameterSet*     pStdPPSs; 
// }
// // VK_KHR_video_decode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeH265SessionParametersCreateInfoKHR {
// 	public     VkStructureType                                        sType; 
// 	public      void*                                            pNext; 
// 	public     uint32_t                                               maxStdVPSCount; 
// 	public     uint32_t                                               maxStdSPSCount; 
// 	public     uint32_t                                               maxStdPPSCount; 
// 	public      VkVideoDecodeH265SessionParametersAddInfoKHR*    pParametersAddInfo; 
// }
// // VK_KHR_video_decode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeH265PictureInfoKHR {
// 	public     VkStructureType                         sType; 
// 	public      void*                             pNext; 
// 	public      StdVideoDecodeH265PictureInfo*    pStdPictureInfo; 
// 	public     uint32_t                                sliceSegmentCount; 
// 	public      uint32_t*                         pSliceSegmentOffsets; 
// }
// // VK_KHR_video_decode_h265
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeH265DpbSlotInfoKHR {
// 	public     VkStructureType                           sType; 
// 	public      void*                               pNext; 
// 	public      StdVideoDecodeH265ReferenceInfo*    pStdReferenceInfo; 
// }
// VK_KHR_fragment_shading_rate
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkFragmentShadingRateAttachmentInfoKHR {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public      VkAttachmentReference2*    pFragmentShadingRateAttachment; 
	public     VkExtent2D                       shadingRateAttachmentTexelSize; 
}
// VK_KHR_fragment_shading_rate
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineFragmentShadingRateStateCreateInfoKHR {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkExtent2D                            fragmentSize; 
	public     VkFragmentShadingRateCombinerOpKHR[]    combinerOps; 
}
// VK_KHR_fragment_shading_rate
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFragmentShadingRateFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           pipelineFragmentShadingRate; 
	public     VkBool32           primitiveFragmentShadingRate; 
	public     VkBool32           attachmentFragmentShadingRate; 
}
// VK_KHR_fragment_shading_rate
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFragmentShadingRatePropertiesKHR {
	public     VkStructureType          sType; 
	public     void*                    pNext; 
	public     VkExtent2D               minFragmentShadingRateAttachmentTexelSize; 
	public     VkExtent2D               maxFragmentShadingRateAttachmentTexelSize; 
	public     uint32_t                 maxFragmentShadingRateAttachmentTexelSizeAspectRatio; 
	public     VkBool32                 primitiveFragmentShadingRateWithMultipleViewports; 
	public     VkBool32                 layeredShadingRateAttachments; 
	public     VkBool32                 fragmentShadingRateNonTrivialCombinerOps; 
	public     VkExtent2D               maxFragmentSize; 
	public     uint32_t                 maxFragmentSizeAspectRatio; 
	public     uint32_t                 maxFragmentShadingRateCoverageSamples; 
	public     VkSampleCountFlagBits    maxFragmentShadingRateRasterizationSamples; 
	public     VkBool32                 fragmentShadingRateWithShaderDepthStencilWrites; 
	public     VkBool32                 fragmentShadingRateWithSampleMask; 
	public     VkBool32                 fragmentShadingRateWithShaderSampleMask; 
	public     VkBool32                 fragmentShadingRateWithConservativeRasterization; 
	public     VkBool32                 fragmentShadingRateWithFragmentShaderInterlock; 
	public     VkBool32                 fragmentShadingRateWithCustomSampleLocations; 
	public     VkBool32                 fragmentShadingRateStrictMultiplyCombiner; 
}
// VK_KHR_fragment_shading_rate
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFragmentShadingRateKHR {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     VkSampleCountFlags    sampleCounts; 
	public     VkExtent2D            fragmentSize; 
}
// VK_KHR_fragment_shading_rate
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderingFragmentShadingRateAttachmentInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkImageView        imageView; 
	public     VkImageLayout      imageLayout; 
	public     VkExtent2D         shadingRateAttachmentTexelSize; 
}
// VK_KHR_shader_quad_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderQuadControlFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderQuadControl; 
}
// VK_KHR_surface_protected_capabilities
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSurfaceProtectedCapabilitiesKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBool32           supportsProtected; 
}
// VK_KHR_present_wait
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePresentWaitFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           presentWait; 
}
// VK_KHR_pipeline_executable_properties
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePipelineExecutablePropertiesFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           pipelineExecutableInfo; 
}
// VK_KHR_pipeline_executable_properties
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkPipeline         pipeline; 
}
// VK_KHR_pipeline_executable_properties
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineExecutablePropertiesKHR {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     VkShaderStageFlags    stages; 
	public fixed byte                  name[(int)VK.VK_MAX_DESCRIPTION_SIZE]; 
	public fixed byte                  description[(int)VK.VK_MAX_DESCRIPTION_SIZE]; 
	public     uint32_t              subgroupSize; 
}
// VK_KHR_pipeline_executable_properties
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineExecutableInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkPipeline         pipeline; 
	public     uint32_t           executableIndex; 
}
// VK_KHR_pipeline_executable_properties
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineExecutableStatisticKHR {
	public     VkStructureType                           sType; 
	public     void*                                     pNext; 
	public fixed byte                                      name[(int)VK.VK_MAX_DESCRIPTION_SIZE]; 
	public fixed byte                                      description[(int)VK.VK_MAX_DESCRIPTION_SIZE]; 
	public     VkPipelineExecutableStatisticFormatKHR    format; 
	public     VkPipelineExecutableStatisticValueKHR     value; 
}
// VK_KHR_pipeline_executable_properties
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineExecutableInternalRepresentationKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public fixed byte               name[(int)VK.VK_MAX_DESCRIPTION_SIZE]; 
	public fixed byte               description[(int)VK.VK_MAX_DESCRIPTION_SIZE]; 
	public     VkBool32           isText; 
	public     /* size_t */ nuint             dataSize; 
	public     void*              pData; 
}
// VK_KHR_pipeline_library
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineLibraryCreateInfoKHR {
	public     VkStructureType      sType; 
	public      void*          pNext; 
	public     uint32_t             libraryCount; 
	public      VkPipeline*    pLibraries; 
}
// VK_KHR_present_id
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPresentIdKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           swapchainCount; 
	public      uint64_t*    pPresentIds; 
}
// VK_KHR_present_id
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePresentIdFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           presentId; 
}
// VK_KHR_video_encode_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoEncodeInfoKHR {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkVideoEncodeFlagsKHR                 flags; 
	public     VkBuffer                              dstBuffer; 
	public     VkDeviceSize                          dstBufferOffset; 
	public     VkDeviceSize                          dstBufferRange; 
	public     VkVideoPictureResourceInfoKHR         srcPictureResource; 
	public      VkVideoReferenceSlotInfoKHR*    pSetupReferenceSlot; 
	public     uint32_t                              referenceSlotCount; 
	public      VkVideoReferenceSlotInfoKHR*    pReferenceSlots; 
	public     uint32_t                              precedingExternallyEncodedBytes; 
}
// VK_KHR_video_encode_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoEncodeCapabilitiesKHR {
	public     VkStructureType                         sType; 
	public     void*                                   pNext; 
	public     VkVideoEncodeCapabilityFlagsKHR         flags; 
	public     VkVideoEncodeRateControlModeFlagsKHR    rateControlModes; 
	public     uint32_t                                maxRateControlLayers; 
	public     uint64_t                                maxBitrate; 
	public     uint32_t                                maxQualityLevels; 
	public     VkExtent2D                              encodeInputPictureGranularity; 
	public     VkVideoEncodeFeedbackFlagsKHR           supportedEncodeFeedbackFlags; 
}
// VK_KHR_video_encode_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkQueryPoolVideoEncodeFeedbackCreateInfoKHR {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkVideoEncodeFeedbackFlagsKHR    encodeFeedbackFlags; 
}
// VK_KHR_video_encode_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoEncodeUsageInfoKHR {
	public     VkStructureType                 sType; 
	public      void*                     pNext; 
	public     VkVideoEncodeUsageFlagsKHR      videoUsageHints; 
	public     VkVideoEncodeContentFlagsKHR    videoContentHints; 
	public     VkVideoEncodeTuningModeKHR      tuningMode; 
}
// VK_KHR_video_encode_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoEncodeRateControlLayerInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint64_t           averageBitrate; 
	public     uint64_t           maxBitrate; 
	public     uint32_t           frameRateNumerator; 
	public     uint32_t           frameRateDenominator; 
}
// VK_KHR_video_encode_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoEncodeRateControlInfoKHR {
	public     VkStructureType                                sType; 
	public      void*                                    pNext; 
	public     VkVideoEncodeRateControlFlagsKHR               flags; 
	public     VkVideoEncodeRateControlModeFlagBitsKHR        rateControlMode; 
	public     uint32_t                                       layerCount; 
	public      VkVideoEncodeRateControlLayerInfoKHR*    pLayers; 
	public     uint32_t                                       virtualBufferSizeInMs; 
	public     uint32_t                                       initialVirtualBufferSizeInMs; 
}
// VK_KHR_video_encode_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVideoEncodeQualityLevelInfoKHR {
	public     VkStructureType                 sType; 
	public      void*                     pNext; 
	public      VkVideoProfileInfoKHR*    pVideoProfile; 
	public     uint32_t                        qualityLevel; 
}
// VK_KHR_video_encode_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoEncodeQualityLevelPropertiesKHR {
	public     VkStructureType                            sType; 
	public     void*                                      pNext; 
	public     VkVideoEncodeRateControlModeFlagBitsKHR    preferredRateControlMode; 
	public     uint32_t                                   preferredRateControlLayerCount; 
}
// VK_KHR_video_encode_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoEncodeQualityLevelInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           qualityLevel; 
}
// VK_KHR_video_encode_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoEncodeSessionParametersGetInfoKHR {
	public     VkStructureType                sType; 
	public      void*                    pNext; 
	public     VkVideoSessionParametersKHR    videoSessionParameters; 
}
// VK_KHR_video_encode_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoEncodeSessionParametersFeedbackInfoKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           hasOverrides; 
}
// VK_KHR_fragment_shader_barycentric
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFragmentShaderBarycentricFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           fragmentShaderBarycentric; 
}
// VK_KHR_fragment_shader_barycentric
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFragmentShaderBarycentricPropertiesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           triStripVertexOrderIndependentOfProvokingVertex; 
}
// VK_KHR_shader_subgroup_uniform_control_flow
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderSubgroupUniformControlFlowFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderSubgroupUniformControlFlow; 
}
// VK_KHR_workgroup_memory_explicit_layout
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceWorkgroupMemoryExplicitLayoutFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           workgroupMemoryExplicitLayout; 
	public     VkBool32           workgroupMemoryExplicitLayoutScalarBlockLayout; 
	public     VkBool32           workgroupMemoryExplicitLayout8BitAccess; 
	public     VkBool32           workgroupMemoryExplicitLayout16BitAccess; 
}
// VK_KHR_ray_tracing_maintenance1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRayTracingMaintenance1FeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           rayTracingMaintenance1; 
	public     VkBool32           rayTracingPipelineTraceRaysIndirect2; 
}
// VK_KHR_ray_tracing_maintenance1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkTraceRaysIndirectCommand2KHR {
	public     VkDeviceAddress    raygenShaderRecordAddress; 
	public     VkDeviceSize       raygenShaderRecordSize; 
	public     VkDeviceAddress    missShaderBindingTableAddress; 
	public     VkDeviceSize       missShaderBindingTableSize; 
	public     VkDeviceSize       missShaderBindingTableStride; 
	public     VkDeviceAddress    hitShaderBindingTableAddress; 
	public     VkDeviceSize       hitShaderBindingTableSize; 
	public     VkDeviceSize       hitShaderBindingTableStride; 
	public     VkDeviceAddress    callableShaderBindingTableAddress; 
	public     VkDeviceSize       callableShaderBindingTableSize; 
	public     VkDeviceSize       callableShaderBindingTableStride; 
	public     uint32_t           width; 
	public     uint32_t           height; 
	public     uint32_t           depth; 
}
// VK_KHR_shader_maximal_reconvergence
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderMaximalReconvergenceFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderMaximalReconvergence; 
}
// VK_KHR_ray_tracing_position_fetch
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRayTracingPositionFetchFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           rayTracingPositionFetch; 
}
// VK_KHR_pipeline_binary
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePipelineBinaryFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           pipelineBinaries; 
}
// VK_KHR_pipeline_binary
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePipelineBinaryPropertiesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           pipelineBinaryInternalCache; 
	public     VkBool32           pipelineBinaryInternalCacheControl; 
	public     VkBool32           pipelineBinaryPrefersInternalCache; 
	public     VkBool32           pipelineBinaryPrecompiledInternalCache; 
	public     VkBool32           pipelineBinaryCompressedData; 
}
// VK_KHR_pipeline_binary
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDevicePipelineBinaryInternalCacheControlKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBool32           disableInternalCache; 
}
// VK_KHR_pipeline_binary
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineBinaryKeyKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           keySize; 
	public fixed     uint8_t            key[(int)VK.VK_MAX_PIPELINE_BINARY_KEY_SIZE_KHR]; 
}
// VK_KHR_pipeline_binary
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineBinaryDataKHR {
	public     /* size_t */ nuint    dataSize; 
	public     void*     pData; 
}
// VK_KHR_pipeline_binary
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineBinaryKeysAndDataKHR {
	public     uint32_t                          binaryCount; 
	public      VkPipelineBinaryKeyKHR*     pPipelineBinaryKeys; 
	public      VkPipelineBinaryDataKHR*    pPipelineBinaryData; 
}
// VK_KHR_pipeline_binary
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineCreateInfoKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
}
// VK_KHR_pipeline_binary
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineBinaryCreateInfoKHR {
	public     VkStructureType                          sType; 
	public      void*                              pNext; 
	public      VkPipelineBinaryKeysAndDataKHR*    pKeysAndDataInfo; 
	public     VkPipeline                               pipeline; 
	public      VkPipelineCreateInfoKHR*           pPipelineCreateInfo; 
}
// VK_KHR_pipeline_binary
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineBinaryInfoKHR {
	public     VkStructureType               sType; 
	public      void*                   pNext; 
	public     uint32_t                      binaryCount; 
	public      VkPipelineBinaryKHR*    pPipelineBinaries; 
}
// VK_KHR_pipeline_binary
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkReleaseCapturedPipelineDataInfoKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkPipeline         pipeline; 
}
// VK_KHR_pipeline_binary
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineBinaryDataInfoKHR {
	public     VkStructureType        sType; 
	public     void*                  pNext; 
	public     VkPipelineBinaryKHR    pipelineBinary; 
}
// VK_KHR_pipeline_binary
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineBinaryHandlesInfoKHR {
	public     VkStructureType         sType; 
	public      void*             pNext; 
	public     uint32_t                pipelineBinaryCount; 
	public     VkPipelineBinaryKHR*    pPipelineBinaries; 
}
// VK_KHR_cooperative_matrix
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCooperativeMatrixPropertiesKHR {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     uint32_t              MSize; 
	public     uint32_t              NSize; 
	public     uint32_t              KSize; 
	public     VkComponentTypeKHR    AType; 
	public     VkComponentTypeKHR    BType; 
	public     VkComponentTypeKHR    CType; 
	public     VkComponentTypeKHR    ResultType; 
	public     VkBool32              saturatingAccumulation; 
	public     VkScopeKHR            scope; 
}
// VK_KHR_cooperative_matrix
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCooperativeMatrixFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           cooperativeMatrix; 
	public     VkBool32           cooperativeMatrixRobustBufferAccess; 
}
// VK_KHR_cooperative_matrix
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCooperativeMatrixPropertiesKHR {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     VkShaderStageFlags    cooperativeMatrixSupportedStages; 
}
// VK_KHR_compute_shader_derivatives
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceComputeShaderDerivativesFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           computeDerivativeGroupQuads; 
	public     VkBool32           computeDerivativeGroupLinear; 
}
// VK_KHR_compute_shader_derivatives
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceComputeShaderDerivativesPropertiesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           meshAndTaskShaderDerivatives; 
}
// // VK_KHR_video_decode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeAV1ProfileInfoKHR {
// 	public     VkStructureType       sType; 
// 	public      void*           pNext; 
// 	public     StdVideoAV1Profile    stdProfile; 
// 	public     VkBool32              filmGrainSupport; 
// }
// // VK_KHR_video_decode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeAV1CapabilitiesKHR {
// 	public     VkStructureType     sType; 
// 	public     void*               pNext; 
// 	public     StdVideoAV1Level    maxLevel; 
// }
// // VK_KHR_video_decode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeAV1SessionParametersCreateInfoKHR {
// 	public     VkStructureType                     sType; 
// 	public      void*                         pNext; 
// 	public      StdVideoAV1SequenceHeader*    pStdSequenceHeader; 
// }
// // VK_KHR_video_decode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeAV1PictureInfoKHR {
// 	public     VkStructureType                        sType; 
// 	public      void*                            pNext; 
// 	public      StdVideoDecodeAV1PictureInfo*    pStdPictureInfo; 
// 	public fixed     int32_t                                referenceNameSlotIndices[VK_MAX_VIDEO_AV1_REFERENCES_PER_FRAME_KHR]; 
// 	public     uint32_t                               frameHeaderOffset; 
// 	public     uint32_t                               tileCount; 
// 	public      uint32_t*                        pTileOffsets; 
// 	public      uint32_t*                        pTileSizes; 
// }
// // VK_KHR_video_decode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeAV1DpbSlotInfoKHR {
// 	public     VkStructureType                          sType; 
// 	public      void*                              pNext; 
// 	public      StdVideoDecodeAV1ReferenceInfo*    pStdReferenceInfo; 
// }
// // VK_KHR_video_encode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkPhysicalDeviceVideoEncodeAV1FeaturesKHR {
// 	public     VkStructureType    sType; 
// 	public     void*              pNext; 
// 	public     VkBool32           videoEncodeAV1; 
// }
// // VK_KHR_video_encode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeAV1CapabilitiesKHR {
// 	public     VkStructureType                           sType; 
// 	public     void*                                     pNext; 
// 	public     VkVideoEncodeAV1CapabilityFlagsKHR        flags; 
// 	public     StdVideoAV1Level                          maxLevel; 
// 	public     VkExtent2D                                codedPictureAlignment; 
// 	public     VkExtent2D                                maxTiles; 
// 	public     VkExtent2D                                minTileSize; 
// 	public     VkExtent2D                                maxTileSize; 
// 	public     VkVideoEncodeAV1SuperblockSizeFlagsKHR    superblockSizes; 
// 	public     uint32_t                                  maxSingleReferenceCount; 
// 	public     uint32_t                                  singleReferenceNameMask; 
// 	public     uint32_t                                  maxUnidirectionalCompoundReferenceCount; 
// 	public     uint32_t                                  maxUnidirectionalCompoundGroup1ReferenceCount; 
// 	public     uint32_t                                  unidirectionalCompoundReferenceNameMask; 
// 	public     uint32_t                                  maxBidirectionalCompoundReferenceCount; 
// 	public     uint32_t                                  maxBidirectionalCompoundGroup1ReferenceCount; 
// 	public     uint32_t                                  maxBidirectionalCompoundGroup2ReferenceCount; 
// 	public     uint32_t                                  bidirectionalCompoundReferenceNameMask; 
// 	public     uint32_t                                  maxTemporalLayerCount; 
// 	public     uint32_t                                  maxSpatialLayerCount; 
// 	public     uint32_t                                  maxOperatingPoints; 
// 	public     uint32_t                                  minQIndex; 
// 	public     uint32_t                                  maxQIndex; 
// 	public     VkBool32                                  prefersGopRemainingFrames; 
// 	public     VkBool32                                  requiresGopRemainingFrames; 
// 	public     VkVideoEncodeAV1StdFlagsKHR               stdSyntaxFlags; 
// }
// // VK_KHR_video_encode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeAV1QIndexKHR {
// 	public     uint32_t    intraQIndex; 
// 	public     uint32_t    predictiveQIndex; 
// 	public     uint32_t    bipredictiveQIndex; 
// }
// // VK_KHR_video_encode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeAV1QualityLevelPropertiesKHR {
// 	public     VkStructureType                        sType; 
// 	public     void*                                  pNext; 
// 	public     VkVideoEncodeAV1RateControlFlagsKHR    preferredRateControlFlags; 
// 	public     uint32_t                               preferredGopFrameCount; 
// 	public     uint32_t                               preferredKeyFramePeriod; 
// 	public     uint32_t                               preferredConsecutiveBipredictiveFrameCount; 
// 	public     uint32_t                               preferredTemporalLayerCount; 
// 	public     VkVideoEncodeAV1QIndexKHR              preferredConstantQIndex; 
// 	public     uint32_t                               preferredMaxSingleReferenceCount; 
// 	public     uint32_t                               preferredSingleReferenceNameMask; 
// 	public     uint32_t                               preferredMaxUnidirectionalCompoundReferenceCount; 
// 	public     uint32_t                               preferredMaxUnidirectionalCompoundGroup1ReferenceCount; 
// 	public     uint32_t                               preferredUnidirectionalCompoundReferenceNameMask; 
// 	public     uint32_t                               preferredMaxBidirectionalCompoundReferenceCount; 
// 	public     uint32_t                               preferredMaxBidirectionalCompoundGroup1ReferenceCount; 
// 	public     uint32_t                               preferredMaxBidirectionalCompoundGroup2ReferenceCount; 
// 	public     uint32_t                               preferredBidirectionalCompoundReferenceNameMask; 
// }
// // VK_KHR_video_encode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeAV1SessionCreateInfoKHR {
// 	public     VkStructureType     sType; 
// 	public      void*         pNext; 
// 	public     VkBool32            useMaxLevel; 
// 	public     StdVideoAV1Level    maxLevel; 
// }
// // VK_KHR_video_encode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeAV1SessionParametersCreateInfoKHR {
// 	public     VkStructureType                               sType; 
// 	public      void*                                   pNext; 
// 	public      StdVideoAV1SequenceHeader*              pStdSequenceHeader; 
// 	public      StdVideoEncodeAV1DecoderModelInfo*      pStdDecoderModelInfo; 
// 	public     uint32_t                                      stdOperatingPointCount; 
// 	public      StdVideoEncodeAV1OperatingPointInfo*    pStdOperatingPoints; 
// }
// // VK_KHR_video_encode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeAV1PictureInfoKHR {
// 	public     VkStructureType                        sType; 
// 	public      void*                            pNext; 
// 	public     VkVideoEncodeAV1PredictionModeKHR      predictionMode; 
// 	public     VkVideoEncodeAV1RateControlGroupKHR    rateControlGroup; 
// 	public     uint32_t                               constantQIndex; 
// 	public      StdVideoEncodeAV1PictureInfo*    pStdPictureInfo; 
// 	public fixed     int32_t                                referenceNameSlotIndices[VK_MAX_VIDEO_AV1_REFERENCES_PER_FRAME_KHR]; 
// 	public     VkBool32                               primaryReferenceCdfOnly; 
// 	public     VkBool32                               generateObuExtensionHeader; 
// }
// // VK_KHR_video_encode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeAV1DpbSlotInfoKHR {
// 	public     VkStructureType                          sType; 
// 	public      void*                              pNext; 
// 	public      StdVideoEncodeAV1ReferenceInfo*    pStdReferenceInfo; 
// }
// // VK_KHR_video_encode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeAV1ProfileInfoKHR {
// 	public     VkStructureType       sType; 
// 	public      void*           pNext; 
// 	public     StdVideoAV1Profile    stdProfile; 
// }
// // VK_KHR_video_encode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeAV1FrameSizeKHR {
// 	public     uint32_t    intraFrameSize; 
// 	public     uint32_t    predictiveFrameSize; 
// 	public     uint32_t    bipredictiveFrameSize; 
// }
// // VK_KHR_video_encode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeAV1GopRemainingFrameInfoKHR {
// 	public     VkStructureType    sType; 
// 	public      void*        pNext; 
// 	public     VkBool32           useGopRemainingFrames; 
// 	public     uint32_t           gopRemainingIntra; 
// 	public     uint32_t           gopRemainingPredictive; 
// 	public     uint32_t           gopRemainingBipredictive; 
// }
// // VK_KHR_video_encode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeAV1RateControlInfoKHR {
// 	public     VkStructureType                        sType; 
// 	public      void*                            pNext; 
// 	public     VkVideoEncodeAV1RateControlFlagsKHR    flags; 
// 	public     uint32_t                               gopFrameCount; 
// 	public     uint32_t                               keyFramePeriod; 
// 	public     uint32_t                               consecutiveBipredictiveFrameCount; 
// 	public     uint32_t                               temporalLayerCount; 
// }
// // VK_KHR_video_encode_av1
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoEncodeAV1RateControlLayerInfoKHR {
// 	public     VkStructureType                 sType; 
// 	public      void*                     pNext; 
// 	public     VkBool32                        useMinQIndex; 
// 	public     VkVideoEncodeAV1QIndexKHR       minQIndex; 
// 	public     VkBool32                        useMaxQIndex; 
// 	public     VkVideoEncodeAV1QIndexKHR       maxQIndex; 
// 	public     VkBool32                        useMaxFrameSize; 
// 	public     VkVideoEncodeAV1FrameSizeKHR    maxFrameSize; 
// }
// VK_KHR_video_maintenance1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVideoMaintenance1FeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           videoMaintenance1; 
}
// VK_KHR_video_maintenance1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoInlineQueryInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkQueryPool        queryPool; 
	public     uint32_t           firstQuery; 
	public     uint32_t           queryCount; 
}
// VK_KHR_calibrated_timestamps
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCalibratedTimestampInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkTimeDomainKHR    timeDomain; 
}
// VK_KHR_maintenance6
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSetDescriptorBufferOffsetsInfoEXT {
	public     VkStructureType        sType; 
	public      void*            pNext; 
	public     VkShaderStageFlags     stageFlags; 
	public     VkPipelineLayout       layout; 
	public     uint32_t               firstSet; 
	public     uint32_t               setCount; 
	public      uint32_t*        pBufferIndices; 
	public      VkDeviceSize*    pOffsets; 
}
// VK_KHR_maintenance6
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindDescriptorBufferEmbeddedSamplersInfoEXT {
	public     VkStructureType       sType; 
	public      void*           pNext; 
	public     VkShaderStageFlags    stageFlags; 
	public     VkPipelineLayout      layout; 
	public     uint32_t              set; 
}
// VK_KHR_video_encode_quantization_map
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoEncodeQuantizationMapCapabilitiesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkExtent2D         maxQuantizationMapExtent; 
}
// VK_KHR_video_encode_quantization_map
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoFormatQuantizationMapPropertiesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkExtent2D         quantizationMapTexelSize; 
}
// VK_KHR_video_encode_quantization_map
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoEncodeQuantizationMapInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkImageView        quantizationMap; 
	public     VkExtent2D         quantizationMapExtent; 
}
// VK_KHR_video_encode_quantization_map
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoEncodeQuantizationMapSessionParametersCreateInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkExtent2D         quantizationMapTexelSize; 
}
// VK_KHR_video_encode_quantization_map
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVideoEncodeQuantizationMapFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           videoEncodeQuantizationMap; 
}
// VK_KHR_video_encode_quantization_map
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoEncodeH264QuantizationMapCapabilitiesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     int32_t            minQpDelta; 
	public     int32_t            maxQpDelta; 
}
// VK_KHR_video_encode_quantization_map
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoEncodeH265QuantizationMapCapabilitiesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     int32_t            minQpDelta; 
	public     int32_t            maxQpDelta; 
}
// VK_KHR_video_encode_quantization_map
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoFormatH265QuantizationMapPropertiesKHR {
	public     VkStructureType                     sType; 
	public     void*                               pNext; 
	public     VkVideoEncodeH265CtbSizeFlagsKHR    compatibleCtbSizes; 
}
// VK_KHR_video_encode_quantization_map
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoEncodeAV1QuantizationMapCapabilitiesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     int32_t            minQIndexDelta; 
	public     int32_t            maxQIndexDelta; 
}
// VK_KHR_video_encode_quantization_map
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVideoFormatAV1QuantizationMapPropertiesKHR {
	public     VkStructureType                           sType; 
	public     void*                                     pNext; 
	public     VkVideoEncodeAV1SuperblockSizeFlagsKHR    compatibleSuperblockSizes; 
}
// VK_KHR_shader_relaxed_extended_instruction
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderRelaxedExtendedInstructionFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderRelaxedExtendedInstruction; 
}
// VK_KHR_maintenance7
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMaintenance7FeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           maintenance7; 
}
// VK_KHR_maintenance7
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMaintenance7PropertiesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           robustFragmentShadingRateAttachmentAccess; 
	public     VkBool32           separateDepthStencilAttachmentAccess; 
	public     uint32_t           maxDescriptorSetTotalUniformBuffersDynamic; 
	public     uint32_t           maxDescriptorSetTotalStorageBuffersDynamic; 
	public     uint32_t           maxDescriptorSetTotalBuffersDynamic; 
	public     uint32_t           maxDescriptorSetUpdateAfterBindTotalUniformBuffersDynamic; 
	public     uint32_t           maxDescriptorSetUpdateAfterBindTotalStorageBuffersDynamic; 
	public     uint32_t           maxDescriptorSetUpdateAfterBindTotalBuffersDynamic; 
}
// VK_KHR_maintenance7
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceLayeredApiPropertiesKHR {
	public     VkStructureType                  sType; 
	public     void*                            pNext; 
	public     uint32_t                         vendorID; 
	public     uint32_t                         deviceID; 
	public     VkPhysicalDeviceLayeredApiKHR    layeredAPI; 
	public fixed byte                             deviceName[(int)VK.VK_MAX_PHYSICAL_DEVICE_NAME_SIZE]; 
}
// VK_KHR_maintenance7
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceLayeredApiPropertiesListKHR {
	public     VkStructureType                             sType; 
	public     void*                                       pNext; 
	public     uint32_t                                    layeredApiCount; 
	public     VkPhysicalDeviceLayeredApiPropertiesKHR*    pLayeredApis; 
}
// VK_KHR_maintenance7
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceLayeredApiVulkanPropertiesKHR {
	public     VkStructureType                sType; 
	public     void*                          pNext; 
	public     VkPhysicalDeviceProperties2    properties; 
}
// VK_KHR_maintenance8
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMaintenance8FeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           maintenance8; 
}
// VK_KHR_maintenance8
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryBarrierAccessFlags3KHR {
	public     VkStructureType      sType; 
	public      void*          pNext; 
	public     VkAccessFlags3KHR    srcAccessMask3; 
	public     VkAccessFlags3KHR    dstAccessMask3; 
}
// VK_KHR_video_maintenance2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVideoMaintenance2FeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           videoMaintenance2; 
}
// // VK_KHR_video_maintenance2
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeH264InlineSessionParametersInfoKHR {
// 	public     VkStructureType                            sType; 
// 	public      void*                                pNext; 
// 	public      StdVideoH264SequenceParameterSet*    pStdSPS; 
// 	public      StdVideoH264PictureParameterSet*     pStdPPS; 
// }
// // VK_KHR_video_maintenance2
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeH265InlineSessionParametersInfoKHR {
// 	public     VkStructureType                            sType; 
// 	public      void*                                pNext; 
// 	public      StdVideoH265VideoParameterSet*       pStdVPS; 
// 	public      StdVideoH265SequenceParameterSet*    pStdSPS; 
// 	public      StdVideoH265PictureParameterSet*     pStdPPS; 
// }
// // VK_KHR_video_maintenance2
// [ SkipLocalsInit ]
// [StructLayout(LayoutKind.Sequential)]  

// public unsafe  struct VkVideoDecodeAV1InlineSessionParametersInfoKHR {
// 	public     VkStructureType                     sType; 
// 	public      void*                         pNext; 
// 	public      StdVideoAV1SequenceHeader*    pStdSequenceHeader; 
// }
// VK_KHR_depth_clamp_zero_one
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDepthClampZeroOneFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           depthClampZeroOne; 
}
// VK_KHR_robustness2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRobustness2FeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           robustBufferAccess2; 
	public     VkBool32           robustImageAccess2; 
	public     VkBool32           nullDescriptor; 
}
// VK_KHR_robustness2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRobustness2PropertiesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkDeviceSize       robustStorageBufferAccessSizeAlignment; 
	public     VkDeviceSize       robustUniformBufferAccessSizeAlignment; 
}
// VK_EXT_debug_report
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDebugReportCallbackCreateInfoEXT {
	public  VkStructureType  sType;
	public  void*  pNext;
	public  uint  flags;
	public  delegate* unmanaged< uint,VkDebugReportObjectTypeEXT,long,Int32,Int32,char*,char*,void*,uint >  pfnCallback;
	public  void*  pUserData;
}
// VK_AMD_rasterization_order
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineRasterizationStateRasterizationOrderAMD {
	public     VkStructureType            sType; 
	public      void*                pNext; 
	public     VkRasterizationOrderAMD    rasterizationOrder; 
}
// VK_EXT_debug_marker
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDebugMarkerObjectNameInfoEXT {
	public     VkStructureType               sType; 
	public      void*                   pNext; 
	public     VkDebugReportObjectTypeEXT    @objectType; 
	public     uint64_t                      @object; 
	public      ConstChar*                   pObjectName; 
}
// VK_EXT_debug_marker
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDebugMarkerObjectTagInfoEXT {
	public     VkStructureType               sType; 
	public      void*                   pNext; 
	public     VkDebugReportObjectTypeEXT    @objectType; 
	public     uint64_t                      @object; 
	public     uint64_t                      tagName; 
	public     /* size_t */ nuint                        tagSize; 
	public      void*                   pTag; 
}
// VK_EXT_debug_marker
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDebugMarkerMarkerInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public      ConstChar*        pMarkerName; 
	public fixed     float              color[4]; 
}
// VK_NV_dedicated_allocation
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDedicatedAllocationImageCreateInfoNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBool32           dedicatedAllocation; 
}
// VK_NV_dedicated_allocation
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDedicatedAllocationBufferCreateInfoNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBool32           dedicatedAllocation; 
}
// VK_NV_dedicated_allocation
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDedicatedAllocationMemoryAllocateInfoNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkImage            image; 
	public     VkBuffer           buffer; 
}
// VK_EXT_transform_feedback
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceTransformFeedbackFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           transformFeedback; 
	public     VkBool32           geometryStreams; 
}
// VK_EXT_transform_feedback
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceTransformFeedbackPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxTransformFeedbackStreams; 
	public     uint32_t           maxTransformFeedbackBuffers; 
	public     VkDeviceSize       maxTransformFeedbackBufferSize; 
	public     uint32_t           maxTransformFeedbackStreamDataSize; 
	public     uint32_t           maxTransformFeedbackBufferDataSize; 
	public     uint32_t           maxTransformFeedbackBufferDataStride; 
	public     VkBool32           transformFeedbackQueries; 
	public     VkBool32           transformFeedbackStreamsLinesTriangles; 
	public     VkBool32           transformFeedbackRasterizationStreamSelect; 
	public     VkBool32           transformFeedbackDraw; 
}
// VK_EXT_transform_feedback
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineRasterizationStateStreamCreateInfoEXT {
	public     VkStructureType                                     sType; 
	public      void*                                         pNext; 
	public     VkPipelineRasterizationStateStreamCreateFlagsEXT    flags; 
	public     uint32_t                                            rasterizationStream; 
}
// VK_NVX_binary_import
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCuModuleCreateInfoNVX {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     /* size_t */ nuint             dataSize; 
	public      void*        pData; 
}
// VK_NVX_binary_import
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCuModuleTexturingModeCreateInfoNVX {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBool32           use64bitTexturing; 
}
// VK_NVX_binary_import
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCuFunctionCreateInfoNVX {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkCuModuleNVX      module; 
	public      ConstChar*        pName; 
}
// VK_NVX_binary_import
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCuLaunchInfoNVX {
	public     VkStructureType        sType; 
	public      void*            pNext; 
	public     VkCuFunctionNVX        function; 
	public     uint32_t               gridDimX; 
	public     uint32_t               gridDimY; 
	public     uint32_t               gridDimZ; 
	public     uint32_t               blockDimX; 
	public     uint32_t               blockDimY; 
	public     uint32_t               blockDimZ; 
	public     uint32_t               sharedMemBytes; 
	public     /* size_t */ nuint                 paramCount; 
	public      void*  *    pParams; 
	public     /* size_t */ nuint                 extraCount; 
	public      void*  *    pExtras; 
}
// VK_NVX_image_view_handle
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageViewHandleInfoNVX {
	public     VkStructureType     sType; 
	public      void*         pNext; 
	public     VkImageView         imageView; 
	public     VkDescriptorType    descriptorType; 
	public     VkSampler           sampler; 
}
// VK_NVX_image_view_handle
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageViewAddressPropertiesNVX {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkDeviceAddress    deviceAddress; 
	public     VkDeviceSize       size; 
}
// VK_AMD_texture_gather_bias_lod
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkTextureLODGatherFormatPropertiesAMD {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           supportsTextureGatherLODBiasAMD; 
}
// VK_AMD_shader_info
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkShaderResourceUsageAMD {
	public     uint32_t    numUsedVgprs; 
	public     uint32_t    numUsedSgprs; 
	public     uint32_t    ldsSizePerLocalWorkGroup; 
	public     /* size_t */ nuint      ldsUsageSizeInBytes; 
	public     /* size_t */ nuint      scratchMemUsageInBytes; 
}
// VK_AMD_shader_info
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkShaderStatisticsInfoAMD {
	public     VkShaderStageFlags          shaderStageMask; 
	public     VkShaderResourceUsageAMD    resourceUsage; 
	public     uint32_t                    numPhysicalVgprs; 
	public     uint32_t                    numPhysicalSgprs; 
	public     uint32_t                    numAvailableVgprs; 
	public     uint32_t                    numAvailableSgprs; 
	public fixed     uint32_t                    computeWorkGroupSize[3]; 
}
// VK_NV_corner_sampled_image
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCornerSampledImageFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           cornerSampledImage; 
}
// VK_NV_external_memory_capabilities
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExternalImageFormatPropertiesNV {
	public     VkImageFormatProperties              imageFormatProperties; 
	public     VkExternalMemoryFeatureFlagsNV       externalMemoryFeatures; 
	public     VkExternalMemoryHandleTypeFlagsNV    exportFromImportedHandleTypes; 
	public     VkExternalMemoryHandleTypeFlagsNV    compatibleHandleTypes; 
}
// VK_NV_external_memory
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExternalMemoryImageCreateInfoNV {
	public     VkStructureType                      sType; 
	public      void*                          pNext; 
	public     VkExternalMemoryHandleTypeFlagsNV    handleTypes; 
}
// VK_NV_external_memory
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExportMemoryAllocateInfoNV {
	public     VkStructureType                      sType; 
	public      void*                          pNext; 
	public     VkExternalMemoryHandleTypeFlagsNV    handleTypes; 
}
// VK_EXT_validation_flags
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkValidationFlagsEXT {
	public     VkStructureType                sType; 
	public      void*                    pNext; 
	public     uint32_t                       disabledValidationCheckCount; 
	public      VkValidationCheckEXT*    pDisabledValidationChecks; 
}
// VK_EXT_astc_decode_mode
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageViewASTCDecodeModeEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkFormat           decodeMode; 
}
// VK_EXT_astc_decode_mode
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceASTCDecodeFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           decodeModeSharedExponent; 
}
// VK_EXT_conditional_rendering
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkConditionalRenderingBeginInfoEXT {
	public     VkStructureType                   sType; 
	public      void*                       pNext; 
	public     VkBuffer                          buffer; 
	public     VkDeviceSize                      offset; 
	public     VkConditionalRenderingFlagsEXT    flags; 
}
// VK_EXT_conditional_rendering
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceConditionalRenderingFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           conditionalRendering; 
	public     VkBool32           inheritedConditionalRendering; 
}
// VK_EXT_conditional_rendering
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCommandBufferInheritanceConditionalRenderingInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBool32           conditionalRenderingEnable; 
}
// VK_NV_clip_space_w_scaling
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkViewportWScalingNV {
	public     float    xcoeff; 
	public     float    ycoeff; 
}
// VK_NV_clip_space_w_scaling
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineViewportWScalingStateCreateInfoNV {
	public     VkStructureType                sType; 
	public      void*                    pNext; 
	public     VkBool32                       viewportWScalingEnable; 
	public     uint32_t                       viewportCount; 
	public      VkViewportWScalingNV*    pViewportWScalings; 
}
// VK_EXT_display_surface_counter
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSurfaceCapabilities2EXT {
	public     VkStructureType                  sType; 
	public     void*                            pNext; 
	public     uint32_t                         minImageCount; 
	public     uint32_t                         maxImageCount; 
	public     VkExtent2D                       currentExtent; 
	public     VkExtent2D                       minImageExtent; 
	public     VkExtent2D                       maxImageExtent; 
	public     uint32_t                         maxImageArrayLayers; 
	public     VkSurfaceTransformFlagsKHR       supportedTransforms; 
	public     VkSurfaceTransformFlagBitsKHR    currentTransform; 
	public     VkCompositeAlphaFlagsKHR         supportedCompositeAlpha; 
	public     VkImageUsageFlags                supportedUsageFlags; 
	public     VkSurfaceCounterFlagsEXT         supportedSurfaceCounters; 
}
// VK_EXT_display_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplayPowerInfoEXT {
	public     VkStructureType           sType; 
	public      void*               pNext; 
	public     VkDisplayPowerStateEXT    powerState; 
}
// VK_EXT_display_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceEventInfoEXT {
	public     VkStructureType         sType; 
	public      void*             pNext; 
	public     VkDeviceEventTypeEXT    deviceEvent; 
}
// VK_EXT_display_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplayEventInfoEXT {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     VkDisplayEventTypeEXT    displayEvent; 
}
// VK_EXT_display_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSwapchainCounterCreateInfoEXT {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkSurfaceCounterFlagsEXT    surfaceCounters; 
}
// VK_GOOGLE_display_timing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRefreshCycleDurationGOOGLE {
	public     uint64_t    refreshDuration; 
}
// VK_GOOGLE_display_timing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPastPresentationTimingGOOGLE {
	public     uint32_t    presentID; 
	public     uint64_t    desiredPresentTime; 
	public     uint64_t    actualPresentTime; 
	public     uint64_t    earliestPresentTime; 
	public     uint64_t    presentMargin; 
}
// VK_GOOGLE_display_timing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPresentTimeGOOGLE {
	public     uint32_t    presentID; 
	public     uint64_t    desiredPresentTime; 
}
// VK_GOOGLE_display_timing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPresentTimesInfoGOOGLE {
	public     VkStructureType               sType; 
	public      void*                   pNext; 
	public     uint32_t                      swapchainCount; 
	public      VkPresentTimeGOOGLE*    pTimes; 
}
// VK_NVX_multiview_per_view_attributes
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMultiviewPerViewAttributesPropertiesNVX {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           perViewPositionAllComponents; 
}
// VK_NVX_multiview_per_view_attributes
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMultiviewPerViewAttributesInfoNVX {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBool32           perViewAttributes; 
	public     VkBool32           perViewAttributesPositionXOnly; 
}
// VK_NV_viewport_swizzle
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkViewportSwizzleNV {
	public     VkViewportCoordinateSwizzleNV    x; 
	public     VkViewportCoordinateSwizzleNV    y; 
	public     VkViewportCoordinateSwizzleNV    z; 
	public     VkViewportCoordinateSwizzleNV    w; 
}
// VK_NV_viewport_swizzle
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineViewportSwizzleStateCreateInfoNV {
	public     VkStructureType                                sType; 
	public      void*                                    pNext; 
	public     VkPipelineViewportSwizzleStateCreateFlagsNV    flags; 
	public     uint32_t                                       viewportCount; 
	public      VkViewportSwizzleNV*                     pViewportSwizzles; 
}
// VK_EXT_discard_rectangles
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDiscardRectanglePropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxDiscardRectangles; 
}
// VK_EXT_discard_rectangles
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineDiscardRectangleStateCreateInfoEXT {
	public     VkStructureType                                  sType; 
	public      void*                                      pNext; 
	public     VkPipelineDiscardRectangleStateCreateFlagsEXT    flags; 
	public     VkDiscardRectangleModeEXT                        discardRectangleMode; 
	public     uint32_t                                         discardRectangleCount; 
	public      VkRect2D*                                  pDiscardRectangles; 
}
// VK_EXT_conservative_rasterization
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceConservativeRasterizationPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     float              primitiveOverestimationSize; 
	public     float              maxExtraPrimitiveOverestimationSize; 
	public     float              extraPrimitiveOverestimationSizeGranularity; 
	public     VkBool32           primitiveUnderestimation; 
	public     VkBool32           conservativePointAndLineRasterization; 
	public     VkBool32           degenerateTrianglesRasterized; 
	public     VkBool32           degenerateLinesRasterized; 
	public     VkBool32           fullyCoveredFragmentShaderInputVariable; 
	public     VkBool32           conservativeRasterizationPostDepthCoverage; 
}
// VK_EXT_conservative_rasterization
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineRasterizationConservativeStateCreateInfoEXT {
	public     VkStructureType                                           sType; 
	public      void*                                               pNext; 
	public     VkPipelineRasterizationConservativeStateCreateFlagsEXT    flags; 
	public     VkConservativeRasterizationModeEXT                        conservativeRasterizationMode; 
	public     float                                                     extraPrimitiveOverestimationSize; 
}
// VK_EXT_depth_clip_enable
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDepthClipEnableFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           depthClipEnable; 
}
// VK_EXT_depth_clip_enable
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineRasterizationDepthClipStateCreateInfoEXT {
	public     VkStructureType                                        sType; 
	public      void*                                            pNext; 
	public     VkPipelineRasterizationDepthClipStateCreateFlagsEXT    flags; 
	public     VkBool32                                               depthClipEnable; 
}
// VK_EXT_hdr_metadata
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkXYColorEXT {
	public     float    x; 
	public     float    y; 
}
// VK_EXT_hdr_metadata
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkHdrMetadataEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkXYColorEXT       displayPrimaryRed; 
	public     VkXYColorEXT       displayPrimaryGreen; 
	public     VkXYColorEXT       displayPrimaryBlue; 
	public     VkXYColorEXT       whitePoint; 
	public     float              maxLuminance; 
	public     float              minLuminance; 
	public     float              maxContentLightLevel; 
	public     float              maxFrameAverageLightLevel; 
}
// VK_IMG_relaxed_line_rasterization
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRelaxedLineRasterizationFeaturesIMG {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           relaxedLineRasterization; 
}
// VK_EXT_debug_utils
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDebugUtilsLabelEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public      ConstChar*        pLabelName; 
	public fixed     float              color[4]; 
}
// VK_EXT_debug_utils
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDebugUtilsObjectNameInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkObjectType       @objectType; 
	public     uint64_t           @objectHandle; 
	public      ConstChar*        pObjectName; 
}
// VK_EXT_debug_utils
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDebugUtilsMessengerCallbackDataEXT {
	public     VkStructureType                              sType; 
	public      void*                                  pNext; 
	public     VkDebugUtilsMessengerCallbackDataFlagsEXT    flags; 
	public      ConstChar*                                  pMessageIdName; 
	public     int32_t                                      messageIdNumber; 
	public      ConstChar*                                  pMessage; 
	public     uint32_t                                     queueLabelCount; 
	public      VkDebugUtilsLabelEXT*                  pQueueLabels; 
	public     uint32_t                                     cmdBufLabelCount; 
	public      VkDebugUtilsLabelEXT*                  pCmdBufLabels; 
	public     uint32_t                                     @objectCount; 
	public      VkDebugUtilsObjectNameInfoEXT*         pObjects; 
}
// VK_EXT_debug_utils
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe ref struct VkDebugUtilsMessengerCreateInfoEXT {
	public  VkStructureType  sType;
	public  void*  pNext;
	public  uint  flags;
	public  uint  messageSeverity;
	public  uint  messageType;
	public  delegate* unmanaged< VkDebugUtilsMessageSeverityFlagBitsEXT,VkDebugUtilsMessageTypeFlagBitsEXT,VkDebugUtilsMessengerCallbackDataEXT*,void*,uint >  pfnUserCallback;
	public  void*  pUserData;
}
// VK_EXT_debug_utils
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDebugUtilsObjectTagInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkObjectType       @objectType; 
	public     uint64_t           @objectHandle; 
	public     uint64_t           tagName; 
	public     /* size_t */ nuint             tagSize; 
	public      void*        pTag; 
}
// VK_AMD_mixed_attachment_samples
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAttachmentSampleCountInfoAMD {
	public     VkStructureType                 sType; 
	public      void*                     pNext; 
	public     uint32_t                        colorAttachmentCount; 
	public      VkSampleCountFlagBits*    pColorAttachmentSamples; 
	public     VkSampleCountFlagBits           depthStencilAttachmentSamples; 
}
// VK_EXT_sample_locations
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSampleLocationEXT {
	public     float    x; 
	public     float    y; 
}
// VK_EXT_sample_locations
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSampleLocationsInfoEXT {
	public     VkStructureType               sType; 
	public      void*                   pNext; 
	public     VkSampleCountFlagBits         sampleLocationsPerPixel; 
	public     VkExtent2D                    sampleLocationGridSize; 
	public     uint32_t                      sampleLocationsCount; 
	public      VkSampleLocationEXT*    pSampleLocations; 
}
// VK_EXT_sample_locations
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAttachmentSampleLocationsEXT {
	public     uint32_t                    attachmentIndex; 
	public     VkSampleLocationsInfoEXT    sampleLocationsInfo; 
}
// VK_EXT_sample_locations
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSubpassSampleLocationsEXT {
	public     uint32_t                    subpassIndex; 
	public     VkSampleLocationsInfoEXT    sampleLocationsInfo; 
}
// VK_EXT_sample_locations
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassSampleLocationsBeginInfoEXT {
	public     VkStructureType                          sType; 
	public      void*                              pNext; 
	public     uint32_t                                 attachmentInitialSampleLocationsCount; 
	public      VkAttachmentSampleLocationsEXT*    pAttachmentInitialSampleLocations; 
	public     uint32_t                                 postSubpassSampleLocationsCount; 
	public      VkSubpassSampleLocationsEXT*       pPostSubpassSampleLocations; 
}
// VK_EXT_sample_locations
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineSampleLocationsStateCreateInfoEXT {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkBool32                    sampleLocationsEnable; 
	public     VkSampleLocationsInfoEXT    sampleLocationsInfo; 
}
// VK_EXT_sample_locations
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceSampleLocationsPropertiesEXT {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     VkSampleCountFlags    sampleLocationSampleCounts; 
	public     VkExtent2D            maxSampleLocationGridSize; 
	public fixed     float                 sampleLocationCoordinateRange[2]; 
	public     uint32_t              sampleLocationSubPixelBits; 
	public     VkBool32              variableSampleLocations; 
}
// VK_EXT_sample_locations
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMultisamplePropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkExtent2D         maxSampleLocationGridSize; 
}
// VK_EXT_blend_operation_advanced
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceBlendOperationAdvancedFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           advancedBlendCoherentOperations; 
}
// VK_EXT_blend_operation_advanced
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceBlendOperationAdvancedPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           advancedBlendMaxColorAttachments; 
	public     VkBool32           advancedBlendIndependentBlend; 
	public     VkBool32           advancedBlendNonPremultipliedSrcColor; 
	public     VkBool32           advancedBlendNonPremultipliedDstColor; 
	public     VkBool32           advancedBlendCorrelatedOverlap; 
	public     VkBool32           advancedBlendAllOperations; 
}
// VK_EXT_blend_operation_advanced
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineColorBlendAdvancedStateCreateInfoEXT {
	public     VkStructureType      sType; 
	public      void*          pNext; 
	public     VkBool32             srcPremultiplied; 
	public     VkBool32             dstPremultiplied; 
	public     VkBlendOverlapEXT    blendOverlap; 
}
// VK_NV_fragment_coverage_to_color
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineCoverageToColorStateCreateInfoNV {
	public     VkStructureType                                sType; 
	public      void*                                    pNext; 
	public     VkPipelineCoverageToColorStateCreateFlagsNV    flags; 
	public     VkBool32                                       coverageToColorEnable; 
	public     uint32_t                                       coverageToColorLocation; 
}
// VK_NV_framebuffer_mixed_samples
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineCoverageModulationStateCreateInfoNV {
	public     VkStructureType                                   sType; 
	public      void*                                       pNext; 
	public     VkPipelineCoverageModulationStateCreateFlagsNV    flags; 
	public     VkCoverageModulationModeNV                        coverageModulationMode; 
	public     VkBool32                                          coverageModulationTableEnable; 
	public     uint32_t                                          coverageModulationTableCount; 
	public      float*                                      pCoverageModulationTable; 
}
// VK_NV_shader_sm_builtins
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderSMBuiltinsPropertiesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           shaderSMCount; 
	public     uint32_t           shaderWarpsPerSM; 
}
// VK_NV_shader_sm_builtins
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderSMBuiltinsFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderSMBuiltins; 
}
// VK_EXT_image_drm_format_modifier
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDrmFormatModifierPropertiesEXT {
	public     uint64_t                drmFormatModifier; 
	public     uint32_t                drmFormatModifierPlaneCount; 
	public     VkFormatFeatureFlags    drmFormatModifierTilingFeatures; 
}
// VK_EXT_image_drm_format_modifier
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDrmFormatModifierPropertiesListEXT {
	public     VkStructureType                      sType; 
	public     void*                                pNext; 
	public     uint32_t                             drmFormatModifierCount; 
	public     VkDrmFormatModifierPropertiesEXT*    pDrmFormatModifierProperties; 
}
// VK_EXT_image_drm_format_modifier
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceImageDrmFormatModifierInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint64_t           drmFormatModifier; 
	public     VkSharingMode      sharingMode; 
	public     uint32_t           queueFamilyIndexCount; 
	public      uint32_t*    pQueueFamilyIndices; 
}
// VK_EXT_image_drm_format_modifier
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageDrmFormatModifierListCreateInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           drmFormatModifierCount; 
	public      uint64_t*    pDrmFormatModifiers; 
}
// VK_EXT_image_drm_format_modifier
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageDrmFormatModifierExplicitCreateInfoEXT {
	public     VkStructureType               sType; 
	public      void*                   pNext; 
	public     uint64_t                      drmFormatModifier; 
	public     uint32_t                      drmFormatModifierPlaneCount; 
	public      VkSubresourceLayout*    pPlaneLayouts; 
}
// VK_EXT_image_drm_format_modifier
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageDrmFormatModifierPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint64_t           drmFormatModifier; 
}
// VK_EXT_image_drm_format_modifier
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDrmFormatModifierProperties2EXT {
	public     uint64_t                 drmFormatModifier; 
	public     uint32_t                 drmFormatModifierPlaneCount; 
	public     VkFormatFeatureFlags2    drmFormatModifierTilingFeatures; 
}
// VK_EXT_image_drm_format_modifier
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDrmFormatModifierPropertiesList2EXT {
	public     VkStructureType                       sType; 
	public     void*                                 pNext; 
	public     uint32_t                              drmFormatModifierCount; 
	public     VkDrmFormatModifierProperties2EXT*    pDrmFormatModifierProperties; 
}
// VK_EXT_validation_cache
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkValidationCacheCreateInfoEXT {
	public     VkStructureType                    sType; 
	public      void*                        pNext; 
	public     VkValidationCacheCreateFlagsEXT    flags; 
	public     /* size_t */ nuint                             initialDataSize; 
	public      void*                        pInitialData; 
}
// VK_EXT_validation_cache
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkShaderModuleValidationCacheCreateInfoEXT {
	public     VkStructureType         sType; 
	public      void*             pNext; 
	public     VkValidationCacheEXT    validationCache; 
}
// VK_NV_shading_rate_image
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkShadingRatePaletteNV {
	public     uint32_t                              shadingRatePaletteEntryCount; 
	public      VkShadingRatePaletteEntryNV*    pShadingRatePaletteEntries; 
}
// VK_NV_shading_rate_image
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineViewportShadingRateImageStateCreateInfoNV {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkBool32                         shadingRateImageEnable; 
	public     uint32_t                         viewportCount; 
	public      VkShadingRatePaletteNV*    pShadingRatePalettes; 
}
// VK_NV_shading_rate_image
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShadingRateImageFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shadingRateImage; 
	public     VkBool32           shadingRateCoarseSampleOrder; 
}
// VK_NV_shading_rate_image
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShadingRateImagePropertiesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkExtent2D         shadingRateTexelSize; 
	public     uint32_t           shadingRatePaletteSize; 
	public     uint32_t           shadingRateMaxCoarseSamples; 
}
// VK_NV_shading_rate_image
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCoarseSampleLocationNV {
	public     uint32_t    pixelX; 
	public     uint32_t    pixelY; 
	public     uint32_t    sample; 
}
// VK_NV_shading_rate_image
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCoarseSampleOrderCustomNV {
	public     VkShadingRatePaletteEntryNV        shadingRate; 
	public     uint32_t                           sampleCount; 
	public     uint32_t                           sampleLocationCount; 
	public      VkCoarseSampleLocationNV*    pSampleLocations; 
}
// VK_NV_shading_rate_image
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineViewportCoarseSampleOrderStateCreateInfoNV {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkCoarseSampleOrderTypeNV             sampleOrderType; 
	public     uint32_t                              customSampleOrderCount; 
	public      VkCoarseSampleOrderCustomNV*    pCustomSampleOrders; 
}
// VK_NV_ray_tracing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRayTracingShaderGroupCreateInfoNV {
	public     VkStructureType                   sType; 
	public      void*                       pNext; 
	public     VkRayTracingShaderGroupTypeKHR    type; 
	public     uint32_t                          generalShader; 
	public     uint32_t                          closestHitShader; 
	public     uint32_t                          anyHitShader; 
	public     uint32_t                          intersectionShader; 
}
// VK_NV_ray_tracing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRayTracingPipelineCreateInfoNV {
	public     VkStructureType                               sType; 
	public      void*                                   pNext; 
	public     VkPipelineCreateFlags                         flags; 
	public     uint32_t                                      stageCount; 
	public      VkPipelineShaderStageCreateInfo*        pStages; 
	public     uint32_t                                      groupCount; 
	public      VkRayTracingShaderGroupCreateInfoNV*    pGroups; 
	public     uint32_t                                      maxRecursionDepth; 
	public     VkPipelineLayout                              layout; 
	public     VkPipeline                                    basePipelineHandle; 
	public     int32_t                                       basePipelineIndex; 
}
// VK_NV_ray_tracing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkGeometryTrianglesNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBuffer           vertexData; 
	public     VkDeviceSize       vertexOffset; 
	public     uint32_t           vertexCount; 
	public     VkDeviceSize       vertexStride; 
	public     VkFormat           vertexFormat; 
	public     VkBuffer           indexData; 
	public     VkDeviceSize       indexOffset; 
	public     uint32_t           indexCount; 
	public     VkIndexType        indexType; 
	public     VkBuffer           transformData; 
	public     VkDeviceSize       transformOffset; 
}
// VK_NV_ray_tracing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkGeometryAABBNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBuffer           aabbData; 
	public     uint32_t           numAABBs; 
	public     uint32_t           stride; 
	public     VkDeviceSize       offset; 
}
// VK_NV_ray_tracing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkGeometryDataNV {
	public     VkGeometryTrianglesNV    triangles; 
	public     VkGeometryAABBNV         aabbs; 
}
// VK_NV_ray_tracing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkGeometryNV {
	public     VkStructureType       sType; 
	public      void*           pNext; 
	public     VkGeometryTypeKHR     geometryType; 
	public     VkGeometryDataNV      geometry; 
	public     VkGeometryFlagsKHR    flags; 
}
// VK_NV_ray_tracing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureInfoNV {
	public     VkStructureType                        sType; 
	public      void*                            pNext; 
	public     VkAccelerationStructureTypeNV          type; 
	public     VkBuildAccelerationStructureFlagsNV    flags; 
	public     uint32_t                               instanceCount; 
	public     uint32_t                               geometryCount; 
	public      VkGeometryNV*                    pGeometries; 
}
// VK_NV_ray_tracing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureCreateInfoNV {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkDeviceSize                     compactedSize; 
	public     VkAccelerationStructureInfoNV    info; 
}
// VK_NV_ray_tracing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindAccelerationStructureMemoryInfoNV {
	public     VkStructureType              sType; 
	public      void*                  pNext; 
	public     VkAccelerationStructureNV    accelerationStructure; 
	public     VkDeviceMemory               memory; 
	public     VkDeviceSize                 memoryOffset; 
	public     uint32_t                     deviceIndexCount; 
	public      uint32_t*              pDeviceIndices; 
}
// VK_NV_ray_tracing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkWriteDescriptorSetAccelerationStructureNV {
	public     VkStructureType                     sType; 
	public      void*                         pNext; 
	public     uint32_t                            accelerationStructureCount; 
	public      VkAccelerationStructureNV*    pAccelerationStructures; 
}
// VK_NV_ray_tracing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureMemoryRequirementsInfoNV {
	public     VkStructureType                                    sType; 
	public      void*                                        pNext; 
	public     VkAccelerationStructureMemoryRequirementsTypeNV    type; 
	public     VkAccelerationStructureNV                          accelerationStructure; 
}
// VK_NV_ray_tracing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRayTracingPropertiesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           shaderGroupHandleSize; 
	public     uint32_t           maxRecursionDepth; 
	public     uint32_t           maxShaderGroupStride; 
	public     uint32_t           shaderGroupBaseAlignment; 
	public     uint64_t           maxGeometryCount; 
	public     uint64_t           maxInstanceCount; 
	public     uint64_t           maxTriangleCount; 
	public     uint32_t           maxDescriptorSetAccelerationStructures; 
}
// VK_NV_ray_tracing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkTransformMatrixKHR {
	public fixed     float    matrix[12]; 
}
// VK_NV_ray_tracing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAabbPositionsKHR {
	public     float    minX; 
	public     float    minY; 
	public     float    minZ; 
	public     float    maxX; 
	public     float    maxY; 
	public     float    maxZ; 
}
// VK_NV_ray_tracing
[SkipLocalsInit]
[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct VkAccelerationStructureInstanceKHR {
    [FieldOffset(0)]public VkTransformMatrixKHR transform;
    [FieldOffset(48)]public uint instanceCustomIndex;
    [FieldOffset(51)]public uint mask;
    [FieldOffset(52)]public uint instanceShaderBindingTableRecordOffset;
    [FieldOffset(55)]public uint flags;
    [FieldOffset(56)]public ulong accelerationStructureReference;
}
// VK_NV_representative_fragment_test
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRepresentativeFragmentTestFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           representativeFragmentTest; 
}
// VK_NV_representative_fragment_test
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineRepresentativeFragmentTestStateCreateInfoNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBool32           representativeFragmentTestEnable; 
}
// VK_EXT_filter_cubic
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceImageViewImageFormatInfoEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkImageViewType    imageViewType; 
}
// VK_EXT_filter_cubic
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkFilterCubicImageViewImageFormatPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           filterCubic; 
	public     VkBool32           filterCubicMinmax; 
}
// VK_EXT_external_memory_host
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImportMemoryHostPointerInfoEXT {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkExternalMemoryHandleTypeFlagBits    handleType; 
	public     void*                                 pHostPointer; 
}
// VK_EXT_external_memory_host
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryHostPointerPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           memoryTypeBits; 
}
// VK_EXT_external_memory_host
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceExternalMemoryHostPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkDeviceSize       minImportedHostPointerAlignment; 
}
// VK_AMD_pipeline_compiler_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineCompilerControlCreateInfoAMD {
	public     VkStructureType                      sType; 
	public      void*                          pNext; 
	public     VkPipelineCompilerControlFlagsAMD    compilerControlFlags; 
}
// VK_AMD_shader_core_properties
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderCorePropertiesAMD {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           shaderEngineCount; 
	public     uint32_t           shaderArraysPerEngineCount; 
	public     uint32_t           computeUnitsPerShaderArray; 
	public     uint32_t           simdPerComputeUnit; 
	public     uint32_t           wavefrontsPerSimd; 
	public     uint32_t           wavefrontSize; 
	public     uint32_t           sgprsPerSimd; 
	public     uint32_t           minSgprAllocation; 
	public     uint32_t           maxSgprAllocation; 
	public     uint32_t           sgprAllocationGranularity; 
	public     uint32_t           vgprsPerSimd; 
	public     uint32_t           minVgprAllocation; 
	public     uint32_t           maxVgprAllocation; 
	public     uint32_t           vgprAllocationGranularity; 
}
// VK_AMD_memory_overallocation_behavior
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceMemoryOverallocationCreateInfoAMD {
	public     VkStructureType                      sType; 
	public      void*                          pNext; 
	public     VkMemoryOverallocationBehaviorAMD    overallocationBehavior; 
}
// VK_EXT_vertex_attribute_divisor
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVertexAttributeDivisorPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxVertexAttribDivisor; 
}
// VK_NV_mesh_shader
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMeshShaderFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           taskShader; 
	public     VkBool32           meshShader; 
}
// VK_NV_mesh_shader
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMeshShaderPropertiesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxDrawMeshTasksCount; 
	public     uint32_t           maxTaskWorkGroupInvocations; 
	public fixed     uint32_t           maxTaskWorkGroupSize[3]; 
	public     uint32_t           maxTaskTotalMemorySize; 
	public     uint32_t           maxTaskOutputCount; 
	public     uint32_t           maxMeshWorkGroupInvocations; 
	public fixed     uint32_t           maxMeshWorkGroupSize[3]; 
	public     uint32_t           maxMeshTotalMemorySize; 
	public     uint32_t           maxMeshOutputVertices; 
	public     uint32_t           maxMeshOutputPrimitives; 
	public     uint32_t           maxMeshMultiviewViewCount; 
	public     uint32_t           meshOutputPerVertexGranularity; 
	public     uint32_t           meshOutputPerPrimitiveGranularity; 
}
// VK_NV_mesh_shader
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDrawMeshTasksIndirectCommandNV {
	public     uint32_t    taskCount; 
	public     uint32_t    firstTask; 
}
// VK_NV_shader_image_footprint
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderImageFootprintFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           imageFootprint; 
}
// VK_NV_scissor_exclusive
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineViewportExclusiveScissorStateCreateInfoNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           exclusiveScissorCount; 
	public      VkRect2D*    pExclusiveScissors; 
}
// VK_NV_scissor_exclusive
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceExclusiveScissorFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           exclusiveScissor; 
}
// VK_NV_device_diagnostic_checkpoints
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkQueueFamilyCheckpointPropertiesNV {
	public     VkStructureType         sType; 
	public     void*                   pNext; 
	public     VkPipelineStageFlags    checkpointExecutionStageMask; 
}
// VK_NV_device_diagnostic_checkpoints
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCheckpointDataNV {
	public     VkStructureType            sType; 
	public     void*                      pNext; 
	public     VkPipelineStageFlagBits    stage; 
	public     void*                      pCheckpointMarker; 
}
// VK_NV_device_diagnostic_checkpoints
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkQueueFamilyCheckpointProperties2NV {
	public     VkStructureType          sType; 
	public     void*                    pNext; 
	public     VkPipelineStageFlags2    checkpointExecutionStageMask; 
}
// VK_NV_device_diagnostic_checkpoints
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCheckpointData2NV {
	public     VkStructureType          sType; 
	public     void*                    pNext; 
	public     VkPipelineStageFlags2    stage; 
	public     void*                    pCheckpointMarker; 
}
// VK_INTEL_shader_integer_functions2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderIntegerFunctions2FeaturesINTEL {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderIntegerFunctions2; 
}
// VK_INTEL_performance_query
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPerformanceValueINTEL {
	public     VkPerformanceValueTypeINTEL    type; 
	public     VkPerformanceValueDataINTEL    data; 
}
// VK_INTEL_performance_query
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkInitializePerformanceApiInfoINTEL {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     void*              pUserData; 
}
// VK_INTEL_performance_query
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkQueryPoolPerformanceQueryCreateInfoINTEL {
	public     VkStructureType                 sType; 
	public      void*                     pNext; 
	public     VkQueryPoolSamplingModeINTEL    performanceCountersSampling; 
}
// VK_INTEL_performance_query
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPerformanceMarkerInfoINTEL {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint64_t           marker; 
}
// VK_INTEL_performance_query
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPerformanceStreamMarkerInfoINTEL {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           marker; 
}
// VK_INTEL_performance_query
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPerformanceOverrideInfoINTEL {
	public     VkStructureType                   sType; 
	public      void*                       pNext; 
	public     VkPerformanceOverrideTypeINTEL    type; 
	public     VkBool32                          enable; 
	public     uint64_t                          parameter; 
}
// VK_INTEL_performance_query
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPerformanceConfigurationAcquireInfoINTEL {
	public     VkStructureType                        sType; 
	public      void*                            pNext; 
	public     VkPerformanceConfigurationTypeINTEL    type; 
}
// VK_EXT_pci_bus_info
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePCIBusInfoPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           pciDomain; 
	public     uint32_t           pciBus; 
	public     uint32_t           pciDevice; 
	public     uint32_t           pciFunction; 
}
// VK_AMD_display_native_hdr
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplayNativeHdrSurfaceCapabilitiesAMD {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           localDimmingSupport; 
}
// VK_AMD_display_native_hdr
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSwapchainDisplayNativeHdrCreateInfoAMD {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBool32           localDimmingEnable; 
}
// VK_EXT_fragment_density_map
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFragmentDensityMapFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           fragmentDensityMap; 
	public     VkBool32           fragmentDensityMapDynamic; 
	public     VkBool32           fragmentDensityMapNonSubsampledImages; 
}
// VK_EXT_fragment_density_map
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFragmentDensityMapPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkExtent2D         minFragmentDensityTexelSize; 
	public     VkExtent2D         maxFragmentDensityTexelSize; 
	public     VkBool32           fragmentDensityInvocations; 
}
// VK_EXT_fragment_density_map
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassFragmentDensityMapCreateInfoEXT {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     VkAttachmentReference    fragmentDensityMapAttachment; 
}
// VK_EXT_fragment_density_map
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderingFragmentDensityMapAttachmentInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkImageView        imageView; 
	public     VkImageLayout      imageLayout; 
}
// VK_AMD_shader_core_properties2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderCoreProperties2AMD {
	public     VkStructureType                   sType; 
	public     void*                             pNext; 
	public     VkShaderCorePropertiesFlagsAMD    shaderCoreFeatures; 
	public     uint32_t                          activeComputeUnitCount; 
}
// VK_AMD_device_coherent_memory
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCoherentMemoryFeaturesAMD {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           deviceCoherentMemory; 
}
// VK_EXT_shader_image_atomic_int64
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderImageAtomicInt64FeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderImageInt64Atomics; 
	public     VkBool32           sparseImageInt64Atomics; 
}
// VK_EXT_memory_budget
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMemoryBudgetPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public fixed     VkDeviceSize       heapBudget[(int)VK.VK_MAX_MEMORY_HEAPS]; 
	public fixed     VkDeviceSize       heapUsage[(int)VK.VK_MAX_MEMORY_HEAPS]; 
}
// VK_EXT_memory_priority
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMemoryPriorityFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           memoryPriority; 
}
// VK_EXT_memory_priority
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryPriorityAllocateInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     float              priority; 
}
// VK_NV_dedicated_allocation_image_aliasing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDedicatedAllocationImageAliasingFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           dedicatedAllocationImageAliasing; 
}
// VK_EXT_buffer_device_address
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceBufferDeviceAddressFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           bufferDeviceAddress; 
	public     VkBool32           bufferDeviceAddressCaptureReplay; 
	public     VkBool32           bufferDeviceAddressMultiDevice; 
}
// VK_EXT_buffer_device_address
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBufferDeviceAddressCreateInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkDeviceAddress    deviceAddress; 
}
// VK_EXT_validation_features
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkValidationFeaturesEXT {
	public     VkStructureType                         sType; 
	public      void*                             pNext; 
	public     uint32_t                                enabledValidationFeatureCount; 
	public      VkValidationFeatureEnableEXT*     pEnabledValidationFeatures; 
	public     uint32_t                                disabledValidationFeatureCount; 
	public      VkValidationFeatureDisableEXT*    pDisabledValidationFeatures; 
}
// VK_NV_cooperative_matrix
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCooperativeMatrixPropertiesNV {
	public     VkStructureType      sType; 
	public     void*                pNext; 
	public     uint32_t             MSize; 
	public     uint32_t             NSize; 
	public     uint32_t             KSize; 
	public     VkComponentTypeNV    AType; 
	public     VkComponentTypeNV    BType; 
	public     VkComponentTypeNV    CType; 
	public     VkComponentTypeNV    DType; 
	public     VkScopeNV            scope; 
}
// VK_NV_cooperative_matrix
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCooperativeMatrixFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           cooperativeMatrix; 
	public     VkBool32           cooperativeMatrixRobustBufferAccess; 
}
// VK_NV_cooperative_matrix
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCooperativeMatrixPropertiesNV {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     VkShaderStageFlags    cooperativeMatrixSupportedStages; 
}
// VK_NV_coverage_reduction_mode
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCoverageReductionModeFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           coverageReductionMode; 
}
// VK_NV_coverage_reduction_mode
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineCoverageReductionStateCreateInfoNV {
	public     VkStructureType                                  sType; 
	public      void*                                      pNext; 
	public     VkPipelineCoverageReductionStateCreateFlagsNV    flags; 
	public     VkCoverageReductionModeNV                        coverageReductionMode; 
}
// VK_NV_coverage_reduction_mode
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkFramebufferMixedSamplesCombinationNV {
	public     VkStructureType              sType; 
	public     void*                        pNext; 
	public     VkCoverageReductionModeNV    coverageReductionMode; 
	public     VkSampleCountFlagBits        rasterizationSamples; 
	public     VkSampleCountFlags           depthStencilSamples; 
	public     VkSampleCountFlags           colorSamples; 
}
// VK_EXT_fragment_shader_interlock
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFragmentShaderInterlockFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           fragmentShaderSampleInterlock; 
	public     VkBool32           fragmentShaderPixelInterlock; 
	public     VkBool32           fragmentShaderShadingRateInterlock; 
}
// VK_EXT_ycbcr_image_arrays
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceYcbcrImageArraysFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           ycbcrImageArrays; 
}
// VK_EXT_provoking_vertex
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceProvokingVertexFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           provokingVertexLast; 
	public     VkBool32           transformFeedbackPreservesProvokingVertex; 
}
// VK_EXT_provoking_vertex
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceProvokingVertexPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           provokingVertexModePerPipeline; 
	public     VkBool32           transformFeedbackPreservesTriangleFanProvokingVertex; 
}
// VK_EXT_provoking_vertex
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineRasterizationProvokingVertexStateCreateInfoEXT {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkProvokingVertexModeEXT    provokingVertexMode; 
}
// VK_EXT_headless_surface
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkHeadlessSurfaceCreateInfoEXT {
	public     VkStructureType                    sType; 
	public      void*                        pNext; 
	public     VkHeadlessSurfaceCreateFlagsEXT    flags; 
}
// VK_EXT_shader_atomic_float
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderAtomicFloatFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderBufferFloat32Atomics; 
	public     VkBool32           shaderBufferFloat32AtomicAdd; 
	public     VkBool32           shaderBufferFloat64Atomics; 
	public     VkBool32           shaderBufferFloat64AtomicAdd; 
	public     VkBool32           shaderSharedFloat32Atomics; 
	public     VkBool32           shaderSharedFloat32AtomicAdd; 
	public     VkBool32           shaderSharedFloat64Atomics; 
	public     VkBool32           shaderSharedFloat64AtomicAdd; 
	public     VkBool32           shaderImageFloat32Atomics; 
	public     VkBool32           shaderImageFloat32AtomicAdd; 
	public     VkBool32           sparseImageFloat32Atomics; 
	public     VkBool32           sparseImageFloat32AtomicAdd; 
}
// VK_EXT_extended_dynamic_state
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceExtendedDynamicStateFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           extendedDynamicState; 
}
// VK_EXT_map_memory_placed
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMapMemoryPlacedFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           memoryMapPlaced; 
	public     VkBool32           memoryMapRangePlaced; 
	public     VkBool32           memoryUnmapReserve; 
}
// VK_EXT_map_memory_placed
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMapMemoryPlacedPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkDeviceSize       minPlacedMemoryMapAlignment; 
}
// VK_EXT_map_memory_placed
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryMapPlacedInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     void*              pPlacedAddress; 
}
// VK_EXT_shader_atomic_float2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderAtomicFloat2FeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderBufferFloat16Atomics; 
	public     VkBool32           shaderBufferFloat16AtomicAdd; 
	public     VkBool32           shaderBufferFloat16AtomicMinMax; 
	public     VkBool32           shaderBufferFloat32AtomicMinMax; 
	public     VkBool32           shaderBufferFloat64AtomicMinMax; 
	public     VkBool32           shaderSharedFloat16Atomics; 
	public     VkBool32           shaderSharedFloat16AtomicAdd; 
	public     VkBool32           shaderSharedFloat16AtomicMinMax; 
	public     VkBool32           shaderSharedFloat32AtomicMinMax; 
	public     VkBool32           shaderSharedFloat64AtomicMinMax; 
	public     VkBool32           shaderImageFloat32AtomicMinMax; 
	public     VkBool32           sparseImageFloat32AtomicMinMax; 
}
// VK_EXT_surface_maintenance1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSurfacePresentModeEXT {
	public     VkStructureType     sType; 
	public     void*               pNext; 
	public     VkPresentModeKHR    presentMode; 
}
// VK_EXT_surface_maintenance1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSurfacePresentScalingCapabilitiesEXT {
	public     VkStructureType             sType; 
	public     void*                       pNext; 
	public     VkPresentScalingFlagsEXT    supportedPresentScaling; 
	public     VkPresentGravityFlagsEXT    supportedPresentGravityX; 
	public     VkPresentGravityFlagsEXT    supportedPresentGravityY; 
	public     VkExtent2D                  minScaledImageExtent; 
	public     VkExtent2D                  maxScaledImageExtent; 
}
// VK_EXT_surface_maintenance1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSurfacePresentModeCompatibilityEXT {
	public     VkStructureType      sType; 
	public     void*                pNext; 
	public     uint32_t             presentModeCount; 
	public     VkPresentModeKHR*    pPresentModes; 
}
// VK_EXT_swapchain_maintenance1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceSwapchainMaintenance1FeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           swapchainMaintenance1; 
}
// VK_EXT_swapchain_maintenance1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSwapchainPresentFenceInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           swapchainCount; 
	public      VkFence*     pFences; 
}
// VK_EXT_swapchain_maintenance1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSwapchainPresentModesCreateInfoEXT {
	public     VkStructureType            sType; 
	public      void*                pNext; 
	public     uint32_t                   presentModeCount; 
	public      VkPresentModeKHR*    pPresentModes; 
}
// VK_EXT_swapchain_maintenance1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSwapchainPresentModeInfoEXT {
	public     VkStructureType            sType; 
	public      void*                pNext; 
	public     uint32_t                   swapchainCount; 
	public      VkPresentModeKHR*    pPresentModes; 
}
// VK_EXT_swapchain_maintenance1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSwapchainPresentScalingCreateInfoEXT {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkPresentScalingFlagsEXT    scalingBehavior; 
	public     VkPresentGravityFlagsEXT    presentGravityX; 
	public     VkPresentGravityFlagsEXT    presentGravityY; 
}
// VK_EXT_swapchain_maintenance1
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkReleaseSwapchainImagesInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkSwapchainKHR     swapchain; 
	public     uint32_t           imageIndexCount; 
	public      uint32_t*    pImageIndices; 
}
// VK_NV_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDeviceGeneratedCommandsPropertiesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxGraphicsShaderGroupCount; 
	public     uint32_t           maxIndirectSequenceCount; 
	public     uint32_t           maxIndirectCommandsTokenCount; 
	public     uint32_t           maxIndirectCommandsStreamCount; 
	public     uint32_t           maxIndirectCommandsTokenOffset; 
	public     uint32_t           maxIndirectCommandsStreamStride; 
	public     uint32_t           minSequencesCountBufferOffsetAlignment; 
	public     uint32_t           minSequencesIndexBufferOffsetAlignment; 
	public     uint32_t           minIndirectCommandsBufferOffsetAlignment; 
}
// VK_NV_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDeviceGeneratedCommandsFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           deviceGeneratedCommands; 
}
// VK_NV_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkGraphicsShaderGroupCreateInfoNV {
	public     VkStructureType                                 sType; 
	public      void*                                     pNext; 
	public     uint32_t                                        stageCount; 
	public      VkPipelineShaderStageCreateInfo*          pStages; 
	public      VkPipelineVertexInputStateCreateInfo*     pVertexInputState; 
	public      VkPipelineTessellationStateCreateInfo*    pTessellationState; 
}
// VK_NV_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkGraphicsPipelineShaderGroupsCreateInfoNV {
	public     VkStructureType                             sType; 
	public      void*                                 pNext; 
	public     uint32_t                                    groupCount; 
	public      VkGraphicsShaderGroupCreateInfoNV*    pGroups; 
	public     uint32_t                                    pipelineCount; 
	public      VkPipeline*                           pPipelines; 
}
// VK_NV_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindShaderGroupIndirectCommandNV {
	public     uint32_t    groupIndex; 
}
// VK_NV_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindIndexBufferIndirectCommandNV {
	public     VkDeviceAddress    bufferAddress; 
	public     uint32_t           size; 
	public     VkIndexType        indexType; 
}
// VK_NV_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindVertexBufferIndirectCommandNV {
	public     VkDeviceAddress    bufferAddress; 
	public     uint32_t           size; 
	public     uint32_t           stride; 
}
// VK_NV_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSetStateFlagsIndirectCommandNV {
	public     uint32_t    data; 
}
// VK_NV_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkIndirectCommandsStreamNV {
	public     VkBuffer        buffer; 
	public     VkDeviceSize    offset; 
}
// VK_NV_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkIndirectCommandsLayoutTokenNV {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkIndirectCommandsTokenTypeNV    tokenType; 
	public     uint32_t                         stream; 
	public     uint32_t                         offset; 
	public     uint32_t                         vertexBindingUnit; 
	public     VkBool32                         vertexDynamicStride; 
	public     VkPipelineLayout                 pushconstantPipelineLayout; 
	public     VkShaderStageFlags               pushconstantShaderStageFlags; 
	public     uint32_t                         pushconstantOffset; 
	public     uint32_t                         pushconstantSize; 
	public     VkIndirectStateFlagsNV           indirectStateFlags; 
	public     uint32_t                         indexTypeCount; 
	public      VkIndexType*               pIndexTypes; 
	public      uint32_t*                  pIndexTypeValues; 
}
// VK_NV_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkIndirectCommandsLayoutCreateInfoNV {
	public     VkStructureType                           sType; 
	public      void*                               pNext; 
	public     VkIndirectCommandsLayoutUsageFlagsNV      flags; 
	public     VkPipelineBindPoint                       pipelineBindPoint; 
	public     uint32_t                                  tokenCount; 
	public      VkIndirectCommandsLayoutTokenNV*    pTokens; 
	public     uint32_t                                  streamCount; 
	public      uint32_t*                           pStreamStrides; 
}
// VK_NV_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkGeneratedCommandsInfoNV {
	public     VkStructureType                      sType; 
	public      void*                          pNext; 
	public     VkPipelineBindPoint                  pipelineBindPoint; 
	public     VkPipeline                           pipeline; 
	public     VkIndirectCommandsLayoutNV           indirectCommandsLayout; 
	public     uint32_t                             streamCount; 
	public      VkIndirectCommandsStreamNV*    pStreams; 
	public     uint32_t                             sequencesCount; 
	public     VkBuffer                             preprocessBuffer; 
	public     VkDeviceSize                         preprocessOffset; 
	public     VkDeviceSize                         preprocessSize; 
	public     VkBuffer                             sequencesCountBuffer; 
	public     VkDeviceSize                         sequencesCountOffset; 
	public     VkBuffer                             sequencesIndexBuffer; 
	public     VkDeviceSize                         sequencesIndexOffset; 
}
// VK_NV_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkGeneratedCommandsMemoryRequirementsInfoNV {
	public     VkStructureType               sType; 
	public      void*                   pNext; 
	public     VkPipelineBindPoint           pipelineBindPoint; 
	public     VkPipeline                    pipeline; 
	public     VkIndirectCommandsLayoutNV    indirectCommandsLayout; 
	public     uint32_t                      maxSequencesCount; 
}
// VK_NV_inherited_viewport_scissor
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceInheritedViewportScissorFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           inheritedViewportScissor2D; 
}
// VK_NV_inherited_viewport_scissor
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCommandBufferInheritanceViewportScissorInfoNV {
	public     VkStructureType      sType; 
	public      void*          pNext; 
	public     VkBool32             viewportScissor2D; 
	public     uint32_t             viewportDepthCount; 
	public      VkViewport*    pViewportDepths; 
}
// VK_EXT_texel_buffer_alignment
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceTexelBufferAlignmentFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           texelBufferAlignment; 
}
// VK_QCOM_render_pass_transform
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassTransformBeginInfoQCOM {
	public     VkStructureType                  sType; 
	public     void*                            pNext; 
	public     VkSurfaceTransformFlagBitsKHR    transform; 
}
// VK_QCOM_render_pass_transform
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCommandBufferInheritanceRenderPassTransformInfoQCOM {
	public     VkStructureType                  sType; 
	public     void*                            pNext; 
	public     VkSurfaceTransformFlagBitsKHR    transform; 
	public     VkRect2D                         renderArea; 
}
// VK_EXT_depth_bias_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDepthBiasControlFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           depthBiasControl; 
	public     VkBool32           leastRepresentableValueForceUnormRepresentation; 
	public     VkBool32           floatRepresentation; 
	public     VkBool32           depthBiasExact; 
}
// VK_EXT_depth_bias_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDepthBiasInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     float              depthBiasConstantFactor; 
	public     float              depthBiasClamp; 
	public     float              depthBiasSlopeFactor; 
}
// VK_EXT_depth_bias_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDepthBiasRepresentationInfoEXT {
	public     VkStructureType                 sType; 
	public      void*                     pNext; 
	public     VkDepthBiasRepresentationEXT    depthBiasRepresentation; 
	public     VkBool32                        depthBiasExact; 
}
// VK_EXT_device_memory_report
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDeviceMemoryReportFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           deviceMemoryReport; 
}
// VK_EXT_device_memory_report
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceMemoryReportCallbackDataEXT {
	public     VkStructureType                     sType; 
	public     void*                               pNext; 
	public     VkDeviceMemoryReportFlagsEXT        flags; 
	public     VkDeviceMemoryReportEventTypeEXT    type; 
	public     uint64_t                            memoryObjectId; 
	public     VkDeviceSize                        size; 
	public     VkObjectType                        @objectType; 
	public     uint64_t                            @objectHandle; 
	public     uint32_t                            heapIndex; 
}
// VK_EXT_device_memory_report
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceDeviceMemoryReportCreateInfoEXT {
	public  VkStructureType  sType;
	public  void*  pNext;
	public  uint  flags;
	public  delegate* unmanaged< VkDeviceMemoryReportCallbackDataEXT*,void*,void >  pfnUserCallback;
	public  void*  pUserData;
}
// VK_EXT_custom_border_color
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSamplerCustomBorderColorCreateInfoEXT {
	public     VkStructureType      sType; 
	public      void*          pNext; 
	public     VkClearColorValue    customBorderColor; 
	public     VkFormat             format; 
}
// VK_EXT_custom_border_color
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCustomBorderColorPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxCustomBorderColorSamplers; 
}
// VK_EXT_custom_border_color
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCustomBorderColorFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           customBorderColors; 
	public     VkBool32           customBorderColorWithoutFormat; 
}
// VK_NV_present_barrier
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePresentBarrierFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           presentBarrier; 
}
// VK_NV_present_barrier
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSurfaceCapabilitiesPresentBarrierNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           presentBarrierSupported; 
}
// VK_NV_present_barrier
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSwapchainPresentBarrierCreateInfoNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           presentBarrierEnable; 
}
// VK_NV_device_diagnostics_config
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDiagnosticsConfigFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           diagnosticsConfig; 
}
// VK_NV_device_diagnostics_config
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceDiagnosticsConfigCreateInfoNV {
	public     VkStructureType                     sType; 
	public      void*                         pNext; 
	public     VkDeviceDiagnosticsConfigFlagsNV    flags; 
}
// VK_NV_cuda_kernel_launch
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCudaModuleCreateInfoNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     /* size_t */ nuint             dataSize; 
	public      void*        pData; 
}
// VK_NV_cuda_kernel_launch
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCudaFunctionCreateInfoNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkCudaModuleNV     module; 
	public      ConstChar*        pName; 
}
// VK_NV_cuda_kernel_launch
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCudaLaunchInfoNV {
	public     VkStructureType        sType; 
	public      void*            pNext; 
	public     VkCudaFunctionNV       function; 
	public     uint32_t               gridDimX; 
	public     uint32_t               gridDimY; 
	public     uint32_t               gridDimZ; 
	public     uint32_t               blockDimX; 
	public     uint32_t               blockDimY; 
	public     uint32_t               blockDimZ; 
	public     uint32_t               sharedMemBytes; 
	public     /* size_t */ nuint                 paramCount; 
	public      void*  *    pParams; 
	public     /* size_t */ nuint                 extraCount; 
	public      void*  *    pExtras; 
}
// VK_NV_cuda_kernel_launch
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCudaKernelLaunchFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           cudaKernelLaunchFeatures; 
}
// VK_NV_cuda_kernel_launch
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCudaKernelLaunchPropertiesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           computeCapabilityMinor; 
	public     uint32_t           computeCapabilityMajor; 
}
// VK_QCOM_tile_shading
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceTileShadingFeaturesQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           tileShading; 
	public     VkBool32           tileShadingFragmentStage; 
	public     VkBool32           tileShadingColorAttachments; 
	public     VkBool32           tileShadingDepthAttachments; 
	public     VkBool32           tileShadingStencilAttachments; 
	public     VkBool32           tileShadingInputAttachments; 
	public     VkBool32           tileShadingSampledAttachments; 
	public     VkBool32           tileShadingPerTileDraw; 
	public     VkBool32           tileShadingPerTileDispatch; 
	public     VkBool32           tileShadingDispatchTile; 
	public     VkBool32           tileShadingApron; 
	public     VkBool32           tileShadingAnisotropicApron; 
	public     VkBool32           tileShadingAtomicOps; 
	public     VkBool32           tileShadingImageProcessing; 
}
// VK_QCOM_tile_shading
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceTileShadingPropertiesQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxApronSize; 
	public     VkBool32           preferNonCoherent; 
	public     VkExtent2D         tileGranularity; 
	public     VkExtent2D         maxTileShadingRate; 
}
// VK_QCOM_tile_shading
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassTileShadingCreateInfoQCOM {
	public     VkStructureType                     sType; 
	public      void*                         pNext; 
	public     VkTileShadingRenderPassFlagsQCOM    flags; 
	public     VkExtent2D                          tileApronSize; 
}
// VK_QCOM_tile_shading
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPerTileBeginInfoQCOM {
	public     VkStructureType    sType; 
	public      void*        pNext; 
}
// VK_QCOM_tile_shading
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPerTileEndInfoQCOM {
	public     VkStructureType    sType; 
	public      void*        pNext; 
}
// VK_QCOM_tile_shading
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDispatchTileInfoQCOM {
	public     VkStructureType    sType; 
	public      void*        pNext; 
}
// VK_NV_low_latency
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkQueryLowLatencySupportNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     void*              pQueriedLowLatencyData; 
}
// VK_EXT_descriptor_buffer
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDescriptorBufferPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           combinedImageSamplerDescriptorSingleArray; 
	public     VkBool32           bufferlessPushDescriptors; 
	public     VkBool32           allowSamplerImageViewPostSubmitCreation; 
	public     VkDeviceSize       descriptorBufferOffsetAlignment; 
	public     uint32_t           maxDescriptorBufferBindings; 
	public     uint32_t           maxResourceDescriptorBufferBindings; 
	public     uint32_t           maxSamplerDescriptorBufferBindings; 
	public     uint32_t           maxEmbeddedImmutableSamplerBindings; 
	public     uint32_t           maxEmbeddedImmutableSamplers; 
	public     /* size_t */ nuint             bufferCaptureReplayDescriptorDataSize; 
	public     /* size_t */ nuint             imageCaptureReplayDescriptorDataSize; 
	public     /* size_t */ nuint             imageViewCaptureReplayDescriptorDataSize; 
	public     /* size_t */ nuint             samplerCaptureReplayDescriptorDataSize; 
	public     /* size_t */ nuint             accelerationStructureCaptureReplayDescriptorDataSize; 
	public     /* size_t */ nuint             samplerDescriptorSize; 
	public     /* size_t */ nuint             combinedImageSamplerDescriptorSize; 
	public     /* size_t */ nuint             sampledImageDescriptorSize; 
	public     /* size_t */ nuint             storageImageDescriptorSize; 
	public     /* size_t */ nuint             uniformTexelBufferDescriptorSize; 
	public     /* size_t */ nuint             robustUniformTexelBufferDescriptorSize; 
	public     /* size_t */ nuint             storageTexelBufferDescriptorSize; 
	public     /* size_t */ nuint             robustStorageTexelBufferDescriptorSize; 
	public     /* size_t */ nuint             uniformBufferDescriptorSize; 
	public     /* size_t */ nuint             robustUniformBufferDescriptorSize; 
	public     /* size_t */ nuint             storageBufferDescriptorSize; 
	public     /* size_t */ nuint             robustStorageBufferDescriptorSize; 
	public     /* size_t */ nuint             inputAttachmentDescriptorSize; 
	public     /* size_t */ nuint             accelerationStructureDescriptorSize; 
	public     VkDeviceSize       maxSamplerDescriptorBufferRange; 
	public     VkDeviceSize       maxResourceDescriptorBufferRange; 
	public     VkDeviceSize       samplerDescriptorBufferAddressSpaceSize; 
	public     VkDeviceSize       resourceDescriptorBufferAddressSpaceSize; 
	public     VkDeviceSize       descriptorBufferAddressSpaceSize; 
}
// VK_EXT_descriptor_buffer
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDescriptorBufferDensityMapPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     /* size_t */ nuint             combinedImageSamplerDensityMapDescriptorSize; 
}
// VK_EXT_descriptor_buffer
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDescriptorBufferFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           descriptorBuffer; 
	public     VkBool32           descriptorBufferCaptureReplay; 
	public     VkBool32           descriptorBufferImageLayoutIgnored; 
	public     VkBool32           descriptorBufferPushDescriptors; 
}
// VK_EXT_descriptor_buffer
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorAddressInfoEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkDeviceAddress    address; 
	public     VkDeviceSize       range; 
	public     VkFormat           format; 
}
// VK_EXT_descriptor_buffer
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorBufferBindingInfoEXT {
	public     VkStructureType       sType; 
	public      void*           pNext; 
	public     VkDeviceAddress       address; 
	public     VkBufferUsageFlags    usage; 
}
// VK_EXT_descriptor_buffer
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE), SkipLocalsInit]
public unsafe struct VkDescriptorBufferBindingPushDescriptorBufferHandleEXT {
	public VkStructureType sType;
	public void* pNext;
	public VkBuffer buffer;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct VkDescriptorDataEXT
{
	[FieldOffset(0)]
	public VkSampler* pSampler;
	[FieldOffset(0)]
	public VkDescriptorImageInfo* pCombinedImageSampler;
	[FieldOffset(0)]
	public VkDescriptorImageInfo* pInputAttachmentImage;
	[FieldOffset(0)]
	public VkDescriptorImageInfo* pSampledImage;
	[FieldOffset(0)]
	public VkDescriptorImageInfo* pStorageImage;
	[FieldOffset(0)]
	public VkDescriptorAddressInfoEXT* pUniformTexelBuffer;
	[FieldOffset(0)]
	public VkDescriptorAddressInfoEXT* pStorageTexelBuffer;
	[FieldOffset(0)]
	public VkDescriptorAddressInfoEXT* pUniformBuffer;
	[FieldOffset(0)]
	public VkDescriptorAddressInfoEXT* pStorageBuffer;
	[FieldOffset(0)]
	public ulong accelerationStructure;
}
// VK_EXT_descriptor_buffer
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE), SkipLocalsInit]
public unsafe  struct VkDescriptorGetInfoEXT {
	public     VkStructureType        sType; 
	public      void*            pNext; 
	public     VkDescriptorType       type; 
	public     VkDescriptorDataEXT    data; 
}
// VK_EXT_descriptor_buffer
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBufferCaptureDescriptorDataInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBuffer           buffer; 
}
// VK_EXT_descriptor_buffer
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageCaptureDescriptorDataInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkImage            image; 
}
// VK_EXT_descriptor_buffer
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageViewCaptureDescriptorDataInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkImageView        imageView; 
}
// VK_EXT_descriptor_buffer
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSamplerCaptureDescriptorDataInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkSampler          sampler; 
}
// VK_EXT_descriptor_buffer
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkOpaqueCaptureDescriptorDataCreateInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public      void*        opaqueCaptureDescriptorData; 
}
// VK_EXT_descriptor_buffer
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureCaptureDescriptorDataInfoEXT {
	public     VkStructureType               sType; 
	public      void*                   pNext; 
	public     VkAccelerationStructureKHR    accelerationStructure; 
	public     VkAccelerationStructureNV     accelerationStructureNV; 
}
// VK_EXT_graphics_pipeline_library
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceGraphicsPipelineLibraryFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           graphicsPipelineLibrary; 
}
// VK_EXT_graphics_pipeline_library
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceGraphicsPipelineLibraryPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           graphicsPipelineLibraryFastLinking; 
	public     VkBool32           graphicsPipelineLibraryIndependentInterpolationDecoration; 
}
// VK_EXT_graphics_pipeline_library
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkGraphicsPipelineLibraryCreateInfoEXT {
	public     VkStructureType                      sType; 
	public      void*                          pNext; 
	public     VkGraphicsPipelineLibraryFlagsEXT    flags; 
}
// VK_AMD_shader_early_and_late_fragment_tests
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderEarlyAndLateFragmentTestsFeaturesAMD {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderEarlyAndLateFragmentTests; 
}
// VK_NV_fragment_shading_rate_enums
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFragmentShadingRateEnumsFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           fragmentShadingRateEnums; 
	public     VkBool32           supersampleFragmentShadingRates; 
	public     VkBool32           noInvocationFragmentShadingRates; 
}
// VK_NV_fragment_shading_rate_enums
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFragmentShadingRateEnumsPropertiesNV {
	public     VkStructureType          sType; 
	public     void*                    pNext; 
	public     VkSampleCountFlagBits    maxFragmentShadingRateInvocationCount; 
}
// VK_NV_fragment_shading_rate_enums
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineFragmentShadingRateEnumStateCreateInfoNV {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkFragmentShadingRateTypeNV           shadingRateType; 
	public     VkFragmentShadingRateNV               shadingRate;
	public VkFragmentShadingRateCombinerOpKHR** combinerOps;//[2]; 
}
// VK_NV_ray_tracing_motion_blur
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureGeometryMotionTrianglesDataNV {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkDeviceOrHostAddressConstKHR    vertexData; 
}
// VK_NV_ray_tracing_motion_blur
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureMotionInfoNV {
	public     VkStructureType                             sType; 
	public      void*                                 pNext; 
	public     uint32_t                                    maxInstances; 
	public     VkAccelerationStructureMotionInfoFlagsNV    flags; 
}
// VK_NV_ray_tracing_motion_blur
[StructLayout(LayoutKind.Explicit)]
public unsafe  struct VkAccelerationStructureMatrixMotionInstanceNV {
	[FieldOffset(0)] public  VkTransformMatrixKHR  transformT0;
	[FieldOffset(64)]public  VkTransformMatrixKHR  transformT1;
	[FieldOffset(128)]public  uint  instanceCustomIndex;
	[FieldOffset(131)]public  uint  mask;
	[FieldOffset(132)]public  uint  instanceShaderBindingTableRecordOffset;
	[FieldOffset(133)]public  uint  flags;
	[FieldOffset(136)]public  long  accelerationStructureReference;
}
// VK_NV_ray_tracing_motion_blur
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSRTDataNV {
	public     float    sx; 
	public     float    a; 
	public     float    b; 
	public     float    pvx; 
	public     float    sy; 
	public     float    c; 
	public     float    pvy; 
	public     float    sz; 
	public     float    pvz; 
	public     float    qx; 
	public     float    qy; 
	public     float    qz; 
	public     float    qw; 
	public     float    tx; 
	public     float    ty; 
	public     float    tz; 
}
// VK_NV_ray_tracing_motion_blur
[StructLayout(LayoutKind.Explicit)]
public unsafe  struct VkAccelerationStructureSRTMotionInstanceNV {
	[FieldOffset(0)]public  VkSRTDataNV  transformT0;
	[FieldOffset(0)]public  VkSRTDataNV  transformT1;
	[FieldOffset(0)]public  uint  instanceCustomIndex;
	[FieldOffset(0)]public  uint  mask;
	[FieldOffset(0)]public  uint  instanceShaderBindingTableRecordOffset;
	[FieldOffset(0)]public  uint  flags;
	[FieldOffset(0)]public  long  accelerationStructureReference;
}
// VK_NV_ray_tracing_motion_blur
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureMotionInstanceNV {
	public     VkAccelerationStructureMotionInstanceTypeNV     type; 
	public     VkAccelerationStructureMotionInstanceFlagsNV    flags; 
	public     VkAccelerationStructureMotionInstanceDataNV     data; 
}
// VK_NV_ray_tracing_motion_blur
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRayTracingMotionBlurFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           rayTracingMotionBlur; 
	public     VkBool32           rayTracingMotionBlurPipelineTraceRaysIndirect; 
}
// VK_EXT_ycbcr_2plane_444_formats
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceYcbcr2Plane444FormatsFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           ycbcr2plane444Formats; 
}
// VK_EXT_fragment_density_map2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFragmentDensityMap2FeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           fragmentDensityMapDeferred; 
}
// VK_EXT_fragment_density_map2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFragmentDensityMap2PropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           subsampledLoads; 
	public     VkBool32           subsampledCoarseReconstructionEarlyAccess; 
	public     uint32_t           maxSubsampledArrayLayers; 
	public     uint32_t           maxDescriptorSetSubsampledSamplers; 
}
// VK_QCOM_rotated_copy_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyCommandTransformInfoQCOM {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkSurfaceTransformFlagBitsKHR    transform; 
}
// VK_EXT_image_compression_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceImageCompressionControlFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           imageCompressionControl; 
}
// VK_EXT_image_compression_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageCompressionControlEXT {
	public     VkStructureType                         sType; 
	public      void*                             pNext; 
	public     VkImageCompressionFlagsEXT              flags; 
	public     uint32_t                                compressionControlPlaneCount; 
	public     VkImageCompressionFixedRateFlagsEXT*    pFixedRateFlags; 
}
// VK_EXT_image_compression_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageCompressionPropertiesEXT {
	public     VkStructureType                        sType; 
	public     void*                                  pNext; 
	public     VkImageCompressionFlagsEXT             imageCompressionFlags; 
	public     VkImageCompressionFixedRateFlagsEXT    imageCompressionFixedRateFlags; 
}
// VK_EXT_attachment_feedback_loop_layout
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceAttachmentFeedbackLoopLayoutFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           attachmentFeedbackLoopLayout; 
}
// VK_EXT_4444_formats
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevice4444FormatsFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           formatA4R4G4B4; 
	public     VkBool32           formatA4B4G4R4; 
}
// VK_EXT_device_fault
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFaultFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           deviceFault; 
	public     VkBool32           deviceFaultVendorBinary; 
}
// VK_EXT_device_fault
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceFaultCountsEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           addressInfoCount; 
	public     uint32_t           vendorInfoCount; 
	public     VkDeviceSize       vendorBinarySize; 
}
// VK_EXT_device_fault
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceFaultAddressInfoEXT {
	public     VkDeviceFaultAddressTypeEXT    addressType; 
	public     VkDeviceAddress                reportedAddress; 
	public     VkDeviceSize                   addressPrecision; 
}
// VK_EXT_device_fault
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceFaultVendorInfoEXT {
	public fixed byte        description[(int)VK.VK_MAX_DESCRIPTION_SIZE]; 
	public     uint64_t    vendorFaultCode; 
	public     uint64_t    vendorFaultData; 
}
// VK_EXT_device_fault
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceFaultInfoEXT {
	public     VkStructureType                 sType; 
	public     void*                           pNext; 
	public fixed byte                            description[(int)VK.VK_MAX_DESCRIPTION_SIZE]; 
	public     VkDeviceFaultAddressInfoEXT*    pAddressInfos; 
	public     VkDeviceFaultVendorInfoEXT*     pVendorInfos; 
	public     void*                           pVendorBinaryData; 
}
// VK_EXT_device_fault
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceFaultVendorBinaryHeaderVersionOneEXT {
	public     uint32_t                                     headerSize; 
	public     VkDeviceFaultVendorBinaryHeaderVersionEXT    headerVersion; 
	public     uint32_t                                     vendorID; 
	public     uint32_t                                     deviceID; 
	public     uint32_t                                     driverVersion; 
	public fixed     uint8_t                                      pipelineCacheUUID[(int)VK.VK_UUID_SIZE]; 
	public     uint32_t                                     applicationNameOffset; 
	public     uint32_t                                     applicationVersion; 
	public     uint32_t                                     engineNameOffset; 
	public     uint32_t                                     engineVersion; 
	public     uint32_t                                     apiVersion; 
}
// VK_ARM_rasterization_order_attachment_access
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRasterizationOrderAttachmentAccessFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           rasterizationOrderColorAttachmentAccess; 
	public     VkBool32           rasterizationOrderDepthAttachmentAccess; 
	public     VkBool32           rasterizationOrderStencilAttachmentAccess; 
}
// VK_EXT_rgba10x6_formats
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRGBA10X6FormatsFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           formatRgba10x6WithoutYCbCrSampler; 
}
// VK_VALVE_mutable_descriptor_type
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMutableDescriptorTypeFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           mutableDescriptorType; 
}
// VK_VALVE_mutable_descriptor_type
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMutableDescriptorTypeListEXT {
	public     uint32_t                   descriptorTypeCount; 
	public      VkDescriptorType*    pDescriptorTypes; 
}
// VK_VALVE_mutable_descriptor_type
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMutableDescriptorTypeCreateInfoEXT {
	public     VkStructureType                          sType; 
	public      void*                              pNext; 
	public     uint32_t                                 mutableDescriptorTypeListCount; 
	public      VkMutableDescriptorTypeListEXT*    pMutableDescriptorTypeLists; 
}
// VK_EXT_vertex_input_dynamic_state
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVertexInputDynamicStateFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           vertexInputDynamicState; 
}
// VK_EXT_vertex_input_dynamic_state
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVertexInputBindingDescription2EXT {
	public     VkStructureType      sType; 
	public     void*                pNext; 
	public     uint32_t             binding; 
	public     uint32_t             stride; 
	public     VkVertexInputRate    inputRate; 
	public     uint32_t             divisor; 
}
// VK_EXT_vertex_input_dynamic_state
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkVertexInputAttributeDescription2EXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           location; 
	public     uint32_t           binding; 
	public     VkFormat           format; 
	public     uint32_t           offset; 
}
// VK_EXT_physical_device_drm
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDrmPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           hasPrimary; 
	public     VkBool32           hasRender; 
	public     int64_t            primaryMajor; 
	public     int64_t            primaryMinor; 
	public     int64_t            renderMajor; 
	public     int64_t            renderMinor; 
}
// VK_EXT_device_address_binding_report
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceAddressBindingReportFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           reportAddressBinding; 
}
// VK_EXT_device_address_binding_report
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceAddressBindingCallbackDataEXT {
	public     VkStructureType                   sType; 
	public     void*                             pNext; 
	public     VkDeviceAddressBindingFlagsEXT    flags; 
	public     VkDeviceAddress                   baseAddress; 
	public     VkDeviceSize                      size; 
	public     VkDeviceAddressBindingTypeEXT     bindingType; 
}
// VK_EXT_depth_clip_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDepthClipControlFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           depthClipControl; 
}
// VK_EXT_depth_clip_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineViewportDepthClipControlCreateInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBool32           negativeOneToOne; 
}
// VK_EXT_primitive_topology_list_restart
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePrimitiveTopologyListRestartFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           primitiveTopologyListRestart; 
	public     VkBool32           primitiveTopologyPatchListRestart; 
}
// VK_EXT_present_mode_fifo_latest_ready
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePresentModeFifoLatestReadyFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           presentModeFifoLatestReady; 
}
// VK_HUAWEI_subpass_shading
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSubpassShadingPipelineCreateInfoHUAWEI {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkRenderPass       renderPass; 
	public     uint32_t           subpass; 
}
// VK_HUAWEI_subpass_shading
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceSubpassShadingFeaturesHUAWEI {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           subpassShading; 
}
// VK_HUAWEI_subpass_shading
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceSubpassShadingPropertiesHUAWEI {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxSubpassShadingWorkgroupSizeAspectRatio; 
}
// VK_HUAWEI_invocation_mask
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceInvocationMaskFeaturesHUAWEI {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           invocationMask; 
}
// VK_NV_external_memory_rdma
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMemoryGetRemoteAddressInfoNV {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkDeviceMemory                        memory; 
	public     VkExternalMemoryHandleTypeFlagBits    handleType; 
}
// VK_NV_external_memory_rdma
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceExternalMemoryRDMAFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           externalMemoryRDMA; 
}
// VK_EXT_pipeline_properties
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelinePropertiesIdentifierEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public fixed     uint8_t            pipelineIdentifier[(int)VK.VK_UUID_SIZE]; 
}
// VK_EXT_pipeline_properties
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePipelinePropertiesFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           pipelinePropertiesIdentifier; 
}
// VK_EXT_frame_boundary
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFrameBoundaryFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           frameBoundary; 
}
// VK_EXT_frame_boundary
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkFrameBoundaryEXT {
	public     VkStructureType            sType; 
	public      void*                pNext; 
	public     VkFrameBoundaryFlagsEXT    flags; 
	public     uint64_t                   frameID; 
	public     uint32_t                   imageCount; 
	public      VkImage*             pImages; 
	public     uint32_t                   bufferCount; 
	public      VkBuffer*            pBuffers; 
	public     uint64_t                   tagName; 
	public     /* size_t */ nuint                     tagSize; 
	public      void*                pTag; 
}
// VK_EXT_multisampled_render_to_single_sampled
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMultisampledRenderToSingleSampledFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           multisampledRenderToSingleSampled; 
}
// VK_EXT_multisampled_render_to_single_sampled
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSubpassResolvePerformanceQueryEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           optimal; 
}
// VK_EXT_multisampled_render_to_single_sampled
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMultisampledRenderToSingleSampledInfoEXT {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     VkBool32                 multisampledRenderToSingleSampledEnable; 
	public     VkSampleCountFlagBits    rasterizationSamples; 
}
// VK_EXT_extended_dynamic_state2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceExtendedDynamicState2FeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           extendedDynamicState2; 
	public     VkBool32           extendedDynamicState2LogicOp; 
	public     VkBool32           extendedDynamicState2PatchControlPoints; 
}
// VK_EXT_color_write_enable
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceColorWriteEnableFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           colorWriteEnable; 
}
// VK_EXT_color_write_enable
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineColorWriteCreateInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           attachmentCount; 
	public      VkBool32*    pColorWriteEnables; 
}
// VK_EXT_primitives_generated_query
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePrimitivesGeneratedQueryFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           primitivesGeneratedQuery; 
	public     VkBool32           primitivesGeneratedQueryWithRasterizerDiscard; 
	public     VkBool32           primitivesGeneratedQueryWithNonZeroStreams; 
}
// VK_EXT_image_view_min_lod
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceImageViewMinLodFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           minLod; 
}
// VK_EXT_image_view_min_lod
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageViewMinLodCreateInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     float              minLod; 
}
// VK_EXT_multi_draw
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMultiDrawFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           multiDraw; 
}
// VK_EXT_multi_draw
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMultiDrawPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxMultiDrawCount; 
}
// VK_EXT_multi_draw
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMultiDrawInfoEXT {
	public     uint32_t    firstVertex; 
	public     uint32_t    vertexCount; 
}
// VK_EXT_multi_draw
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMultiDrawIndexedInfoEXT {
	public     uint32_t    firstIndex; 
	public     uint32_t    indexCount; 
	public     int32_t     vertexOffset; 
}
// VK_EXT_image_2d_view_of_3d
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceImage2DViewOf3DFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           image2DViewOf3D; 
	public     VkBool32           sampler2DViewOf3D; 
}
// VK_EXT_shader_tile_image
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderTileImageFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderTileImageColorReadAccess; 
	public     VkBool32           shaderTileImageDepthReadAccess; 
	public     VkBool32           shaderTileImageStencilReadAccess; 
}
// VK_EXT_shader_tile_image
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderTileImagePropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderTileImageCoherentReadAccelerated; 
	public     VkBool32           shaderTileImageReadSampleFromPixelRateInvocation; 
	public     VkBool32           shaderTileImageReadFromHelperInvocation; 
}
// VK_EXT_opacity_micromap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMicromapUsageEXT {
	public     uint32_t    count; 
	public     uint32_t    subdivisionLevel; 
	public     uint32_t    format; 
}
// VK_EXT_opacity_micromap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMicromapBuildInfoEXT {
	public     VkStructureType                     sType; 
	public      void*                         pNext; 
	public     VkMicromapTypeEXT                   type; 
	public     VkBuildMicromapFlagsEXT             flags; 
	public     VkBuildMicromapModeEXT              mode; 
	public     VkMicromapEXT                       dstMicromap; 
	public     uint32_t                            usageCountsCount; 
	public      VkMicromapUsageEXT*           pUsageCounts; 
	public      VkMicromapUsageEXT**    ppUsageCounts; 
	public     VkDeviceOrHostAddressConstKHR       data; 
	public     VkDeviceOrHostAddressKHR            scratchData; 
	public     VkDeviceOrHostAddressConstKHR       triangleArray; 
	public     VkDeviceSize                        triangleArrayStride; 
}
// VK_EXT_opacity_micromap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMicromapCreateInfoEXT {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkMicromapCreateFlagsEXT    createFlags; 
	public     VkBuffer                    buffer; 
	public     VkDeviceSize                offset; 
	public     VkDeviceSize                size; 
	public     VkMicromapTypeEXT           type; 
	public     VkDeviceAddress             deviceAddress; 
}
// VK_EXT_opacity_micromap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceOpacityMicromapFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           micromap; 
	public     VkBool32           micromapCaptureReplay; 
	public     VkBool32           micromapHostCommands; 
}
// VK_EXT_opacity_micromap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceOpacityMicromapPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxOpacity2StateSubdivisionLevel; 
	public     uint32_t           maxOpacity4StateSubdivisionLevel; 
}
// VK_EXT_opacity_micromap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMicromapVersionInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public      uint8_t*     pVersionData; 
}
// VK_EXT_opacity_micromap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyMicromapToMemoryInfoEXT {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkMicromapEXT               src; 
	public     VkDeviceOrHostAddressKHR    dst; 
	public     VkCopyMicromapModeEXT       mode; 
}
// VK_EXT_opacity_micromap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyMemoryToMicromapInfoEXT {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkDeviceOrHostAddressConstKHR    src; 
	public     VkMicromapEXT                    dst; 
	public     VkCopyMicromapModeEXT            mode; 
}
// VK_EXT_opacity_micromap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyMicromapInfoEXT {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     VkMicromapEXT            src; 
	public     VkMicromapEXT            dst; 
	public     VkCopyMicromapModeEXT    mode; 
}
// VK_EXT_opacity_micromap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMicromapBuildSizesInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkDeviceSize       micromapSize; 
	public     VkDeviceSize       buildScratchSize; 
	public     VkBool32           discardable; 
}
// VK_EXT_opacity_micromap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureTrianglesOpacityMicromapEXT {
	public     VkStructureType                     sType; 
	public     void*                               pNext; 
	public     VkIndexType                         indexType; 
	public     VkDeviceOrHostAddressConstKHR       indexBuffer; 
	public     VkDeviceSize                        indexStride; 
	public     uint32_t                            baseTriangle; 
	public     uint32_t                            usageCountsCount; 
	public      VkMicromapUsageEXT*           pUsageCounts; 
	public      VkMicromapUsageEXT**    ppUsageCounts; 
	public     VkMicromapEXT                       micromap; 
}
// VK_EXT_opacity_micromap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMicromapTriangleEXT {
	public     uint32_t    dataOffset; 
	public     uint16_t    subdivisionLevel; 
	public     uint16_t    format; 
}
// VK_HUAWEI_cluster_culling_shader
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceClusterCullingShaderFeaturesHUAWEI {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           clustercullingShader; 
	public     VkBool32           multiviewClusterCullingShader; 
}
// VK_HUAWEI_cluster_culling_shader
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceClusterCullingShaderPropertiesHUAWEI {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public fixed     uint32_t           maxWorkGroupCount[3]; 
	public fixed     uint32_t           maxWorkGroupSize[3]; 
	public     uint32_t           maxOutputClusterCount; 
	public     VkDeviceSize       indirectBufferOffsetAlignment; 
}
// VK_HUAWEI_cluster_culling_shader
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceClusterCullingShaderVrsFeaturesHUAWEI {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           clusterShadingRate; 
}
// VK_EXT_border_color_swizzle
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceBorderColorSwizzleFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           borderColorSwizzle; 
	public     VkBool32           borderColorSwizzleFromImage; 
}
// VK_EXT_border_color_swizzle
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSamplerBorderColorComponentMappingCreateInfoEXT {
	public     VkStructureType       sType; 
	public      void*           pNext; 
	public     VkComponentMapping    components; 
	public     VkBool32              srgb; 
}
// VK_EXT_pageable_device_local_memory
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePageableDeviceLocalMemoryFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           pageableDeviceLocalMemory; 
}
// VK_ARM_shader_core_properties
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderCorePropertiesARM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           pixelRate; 
	public     uint32_t           texelRate; 
	public     uint32_t           fmaRate; 
}
// VK_ARM_scheduling_controls
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDeviceQueueShaderCoreControlCreateInfoARM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           shaderCoreCount; 
}
// VK_ARM_scheduling_controls
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceSchedulingControlsFeaturesARM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           schedulingControls; 
}
// VK_ARM_scheduling_controls
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceSchedulingControlsPropertiesARM {
	public     VkStructureType                               sType; 
	public     void*                                         pNext; 
	public     VkPhysicalDeviceSchedulingControlsFlagsARM    schedulingControlsFlags; 
}
// VK_EXT_image_sliced_view_of_3d
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceImageSlicedViewOf3DFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           imageSlicedViewOf3D; 
}
// VK_EXT_image_sliced_view_of_3d
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageViewSlicedCreateInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           sliceOffset; 
	public     uint32_t           sliceCount; 
}
// VK_VALVE_descriptor_set_host_mapping
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDescriptorSetHostMappingFeaturesVALVE {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           descriptorSetHostMapping; 
}
// VK_VALVE_descriptor_set_host_mapping
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorSetBindingReferenceVALVE {
	public     VkStructureType          sType; 
	public      void*              pNext; 
	public     VkDescriptorSetLayout    descriptorSetLayout; 
	public     uint32_t                 binding; 
}
// VK_VALVE_descriptor_set_host_mapping
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDescriptorSetLayoutHostMappingInfoVALVE {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     /* size_t */ nuint             descriptorOffset; 
	public     uint32_t           descriptorSize; 
}
// VK_EXT_non_seamless_cube_map
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceNonSeamlessCubeMapFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           nonSeamlessCubeMap; 
}
// VK_ARM_render_pass_striped
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRenderPassStripedFeaturesARM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           renderPassStriped; 
}
// VK_ARM_render_pass_striped
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRenderPassStripedPropertiesARM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkExtent2D         renderPassStripeGranularity; 
	public     uint32_t           maxRenderPassStripes; 
}
// VK_ARM_render_pass_striped
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassStripeInfoARM {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkRect2D           stripeArea; 
}
// VK_ARM_render_pass_striped
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassStripeBeginInfoARM {
	public     VkStructureType                     sType; 
	public      void*                         pNext; 
	public     uint32_t                            stripeInfoCount; 
	public      VkRenderPassStripeInfoARM*    pStripeInfos; 
}
// VK_ARM_render_pass_striped
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassStripeSubmitInfoARM {
	public     VkStructureType                 sType; 
	public      void*                     pNext; 
	public     uint32_t                        stripeSemaphoreInfoCount; 
	public      VkSemaphoreSubmitInfo*    pStripeSemaphoreInfos; 
}
// VK_QCOM_fragment_density_map_offset
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFragmentDensityMapOffsetFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           fragmentDensityMapOffset; 
}
// VK_QCOM_fragment_density_map_offset
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceFragmentDensityMapOffsetPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkExtent2D         fragmentDensityOffsetGranularity; 
}
// VK_QCOM_fragment_density_map_offset
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassFragmentDensityMapOffsetEndInfoEXT {
	public     VkStructureType      sType; 
	public      void*          pNext; 
	public     uint32_t             fragmentDensityOffsetCount; 
	public      VkOffset2D*    pFragmentDensityOffsets; 
}
// VK_NV_copy_memory_indirect
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyMemoryIndirectCommandNV {
	public     VkDeviceAddress    srcAddress; 
	public     VkDeviceAddress    dstAddress; 
	public     VkDeviceSize       size; 
}
// VK_NV_copy_memory_indirect
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyMemoryToImageIndirectCommandNV {
	public     VkDeviceAddress             srcAddress; 
	public     uint32_t                    bufferRowLength; 
	public     uint32_t                    bufferImageHeight; 
	public     VkImageSubresourceLayers    imageSubresource; 
	public     VkOffset3D                  imageOffset; 
	public     VkExtent3D                  imageExtent; 
}
// VK_NV_copy_memory_indirect
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCopyMemoryIndirectFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           indirectCopy; 
}
// VK_NV_copy_memory_indirect
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCopyMemoryIndirectPropertiesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkQueueFlags       supportedQueues; 
}
// VK_NV_memory_decompression
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDecompressMemoryRegionNV {
	public     VkDeviceAddress                       srcAddress; 
	public     VkDeviceAddress                       dstAddress; 
	public     VkDeviceSize                          compressedSize; 
	public     VkDeviceSize                          decompressedSize; 
	public     VkMemoryDecompressionMethodFlagsNV    decompressionMethod; 
}
// VK_NV_memory_decompression
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMemoryDecompressionFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           memoryDecompression; 
}
// VK_NV_memory_decompression
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMemoryDecompressionPropertiesNV {
	public     VkStructureType                       sType; 
	public     void*                                 pNext; 
	public     VkMemoryDecompressionMethodFlagsNV    decompressionMethods; 
	public     uint64_t                              maxDecompressionIndirectCount; 
}
// VK_NV_device_generated_commands_compute
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDeviceGeneratedCommandsComputeFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           deviceGeneratedCompute; 
	public     VkBool32           deviceGeneratedComputePipelines; 
	public     VkBool32           deviceGeneratedComputeCaptureReplay; 
}
// VK_NV_device_generated_commands_compute
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkComputePipelineIndirectBufferInfoNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkDeviceAddress    deviceAddress; 
	public     VkDeviceSize       size; 
	public     VkDeviceAddress    pipelineDeviceAddressCaptureReplay; 
}
// VK_NV_device_generated_commands_compute
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineIndirectDeviceAddressInfoNV {
	public     VkStructureType        sType; 
	public      void*            pNext; 
	public     VkPipelineBindPoint    pipelineBindPoint; 
	public     VkPipeline             pipeline; 
}
// VK_NV_device_generated_commands_compute
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindPipelineIndirectCommandNV {
	public     VkDeviceAddress    pipelineAddress; 
}
// VK_NV_ray_tracing_linear_swept_spheres
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRayTracingLinearSweptSpheresFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           spheres; 
	public     VkBool32           linearSweptSpheres; 
}
// VK_NV_ray_tracing_linear_swept_spheres
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureGeometryLinearSweptSpheresDataNV {
	public     VkStructureType                          sType; 
	public      void*                              pNext; 
	public     VkFormat                                 vertexFormat; 
	public     VkDeviceOrHostAddressConstKHR            vertexData; 
	public     VkDeviceSize                             vertexStride; 
	public     VkFormat                                 radiusFormat; 
	public     VkDeviceOrHostAddressConstKHR            radiusData; 
	public     VkDeviceSize                             radiusStride; 
	public     VkIndexType                              indexType; 
	public     VkDeviceOrHostAddressConstKHR            indexData; 
	public     VkDeviceSize                             indexStride; 
	public     VkRayTracingLssIndexingModeNV            indexingMode; 
	public     VkRayTracingLssPrimitiveEndCapsModeNV    endCapsMode; 
}
// VK_NV_ray_tracing_linear_swept_spheres
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureGeometrySpheresDataNV {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkFormat                         vertexFormat; 
	public     VkDeviceOrHostAddressConstKHR    vertexData; 
	public     VkDeviceSize                     vertexStride; 
	public     VkFormat                         radiusFormat; 
	public     VkDeviceOrHostAddressConstKHR    radiusData; 
	public     VkDeviceSize                     radiusStride; 
	public     VkIndexType                      indexType; 
	public     VkDeviceOrHostAddressConstKHR    indexData; 
	public     VkDeviceSize                     indexStride; 
}
// VK_NV_linear_color_attachment
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceLinearColorAttachmentFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           linearColorAttachment; 
}
// VK_EXT_image_compression_control_swapchain
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceImageCompressionControlSwapchainFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           imageCompressionControlSwapchain; 
}
// VK_QCOM_image_processing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageViewSampleWeightCreateInfoQCOM {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkOffset2D         filterCenter; 
	public     VkExtent2D         filterSize; 
	public     uint32_t           numPhases; 
}
// VK_QCOM_image_processing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceImageProcessingFeaturesQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           textureSampleWeighted; 
	public     VkBool32           textureBoxFilter; 
	public     VkBool32           textureBlockMatch; 
}
// VK_QCOM_image_processing
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceImageProcessingPropertiesQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxWeightFilterPhases; 
	public     VkExtent2D         maxWeightFilterDimension; 
	public     VkExtent2D         maxBlockMatchRegion; 
	public     VkExtent2D         maxBoxFilterBlockSize; 
}
// VK_EXT_nested_command_buffer
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceNestedCommandBufferFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           nestedCommandBuffer; 
	public     VkBool32           nestedCommandBufferRendering; 
	public     VkBool32           nestedCommandBufferSimultaneousUse; 
}
// VK_EXT_nested_command_buffer
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceNestedCommandBufferPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxCommandBufferNestingLevel; 
}
// VK_EXT_external_memory_acquire_unmodified
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExternalMemoryAcquireUnmodifiedEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBool32           acquireUnmodifiedMemory; 
}
// VK_EXT_extended_dynamic_state3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceExtendedDynamicState3FeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           extendedDynamicState3TessellationDomainOrigin; 
	public     VkBool32           extendedDynamicState3DepthClampEnable; 
	public     VkBool32           extendedDynamicState3PolygonMode; 
	public     VkBool32           extendedDynamicState3RasterizationSamples; 
	public     VkBool32           extendedDynamicState3SampleMask; 
	public     VkBool32           extendedDynamicState3AlphaToCoverageEnable; 
	public     VkBool32           extendedDynamicState3AlphaToOneEnable; 
	public     VkBool32           extendedDynamicState3LogicOpEnable; 
	public     VkBool32           extendedDynamicState3ColorBlendEnable; 
	public     VkBool32           extendedDynamicState3ColorBlendEquation; 
	public     VkBool32           extendedDynamicState3ColorWriteMask; 
	public     VkBool32           extendedDynamicState3RasterizationStream; 
	public     VkBool32           extendedDynamicState3ConservativeRasterizationMode; 
	public     VkBool32           extendedDynamicState3ExtraPrimitiveOverestimationSize; 
	public     VkBool32           extendedDynamicState3DepthClipEnable; 
	public     VkBool32           extendedDynamicState3SampleLocationsEnable; 
	public     VkBool32           extendedDynamicState3ColorBlendAdvanced; 
	public     VkBool32           extendedDynamicState3ProvokingVertexMode; 
	public     VkBool32           extendedDynamicState3LineRasterizationMode; 
	public     VkBool32           extendedDynamicState3LineStippleEnable; 
	public     VkBool32           extendedDynamicState3DepthClipNegativeOneToOne; 
	public     VkBool32           extendedDynamicState3ViewportWScalingEnable; 
	public     VkBool32           extendedDynamicState3ViewportSwizzle; 
	public     VkBool32           extendedDynamicState3CoverageToColorEnable; 
	public     VkBool32           extendedDynamicState3CoverageToColorLocation; 
	public     VkBool32           extendedDynamicState3CoverageModulationMode; 
	public     VkBool32           extendedDynamicState3CoverageModulationTableEnable; 
	public     VkBool32           extendedDynamicState3CoverageModulationTable; 
	public     VkBool32           extendedDynamicState3CoverageReductionMode; 
	public     VkBool32           extendedDynamicState3RepresentativeFragmentTestEnable; 
	public     VkBool32           extendedDynamicState3ShadingRateImageEnable; 
}
// VK_EXT_extended_dynamic_state3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceExtendedDynamicState3PropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           dynamicPrimitiveTopologyUnrestricted; 
}
// VK_EXT_extended_dynamic_state3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkColorBlendEquationEXT {
	public     VkBlendFactor    srcColorBlendFactor; 
	public     VkBlendFactor    dstColorBlendFactor; 
	public     VkBlendOp        colorBlendOp; 
	public     VkBlendFactor    srcAlphaBlendFactor; 
	public     VkBlendFactor    dstAlphaBlendFactor; 
	public     VkBlendOp        alphaBlendOp; 
}
// VK_EXT_extended_dynamic_state3
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkColorBlendAdvancedEXT {
	public     VkBlendOp            advancedBlendOp; 
	public     VkBool32             srcPremultiplied; 
	public     VkBool32             dstPremultiplied; 
	public     VkBlendOverlapEXT    blendOverlap; 
	public     VkBool32             clampResults; 
}
// VK_EXT_subpass_merge_feedback
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceSubpassMergeFeedbackFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           subpassMergeFeedback; 
}
// VK_EXT_subpass_merge_feedback
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassCreationControlEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBool32           disallowMerging; 
}
// VK_EXT_subpass_merge_feedback
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassCreationFeedbackInfoEXT {
	public     uint32_t    postMergeSubpassCount; 
}
// VK_EXT_subpass_merge_feedback
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassCreationFeedbackCreateInfoEXT {
	public     VkStructureType                         sType; 
	public      void*                             pNext; 
	public     VkRenderPassCreationFeedbackInfoEXT*    pRenderPassFeedback; 
}
// VK_EXT_subpass_merge_feedback
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassSubpassFeedbackInfoEXT {
	public     VkSubpassMergeStatusEXT    subpassMergeStatus; 
	public fixed byte                       description[(int)VK.VK_MAX_DESCRIPTION_SIZE]; 
	public     uint32_t                   postMergeIndex; 
}
// VK_EXT_subpass_merge_feedback
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderPassSubpassFeedbackCreateInfoEXT {
	public     VkStructureType                        sType; 
	public      void*                            pNext; 
	public     VkRenderPassSubpassFeedbackInfoEXT*    pSubpassFeedback; 
}
// VK_LUNARG_direct_driver_loading
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDirectDriverLoadingInfoLUNARG {
	public     VkStructureType                     sType; 
	public     void*                               pNext; 
	public     VkDirectDriverLoadingFlagsLUNARG    flags; 
	public     delegate* unmanaged<VkInstance, byte*, void*>     pfnGetInstanceProcAddr; 
}
// VK_LUNARG_direct_driver_loading
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDirectDriverLoadingListLUNARG {
	public     VkStructureType                           sType; 
	public      void*                               pNext; 
	public     VkDirectDriverLoadingModeLUNARG           mode; 
	public     uint32_t                                  driverCount; 
	public      VkDirectDriverLoadingInfoLUNARG*    pDrivers; 
}
// VK_EXT_shader_module_identifier
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderModuleIdentifierFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderModuleIdentifier; 
}
// VK_EXT_shader_module_identifier
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderModuleIdentifierPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public fixed     uint8_t            shaderModuleIdentifierAlgorithmUUID[(int)VK.VK_UUID_SIZE]; 
}
// VK_EXT_shader_module_identifier
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineShaderStageModuleIdentifierCreateInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           identifierSize; 
	public      uint8_t*     pIdentifier; 
}
// VK_EXT_shader_module_identifier
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkShaderModuleIdentifierEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           identifierSize; 
	public fixed     uint8_t            identifier[(int)VK.VK_MAX_SHADER_MODULE_IDENTIFIER_SIZE_EXT]; 
}
// VK_NV_optical_flow
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceOpticalFlowFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           opticalFlow; 
}
// VK_NV_optical_flow
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceOpticalFlowPropertiesNV {
	public     VkStructureType                 sType; 
	public     void*                           pNext; 
	public     VkOpticalFlowGridSizeFlagsNV    supportedOutputGridSizes; 
	public     VkOpticalFlowGridSizeFlagsNV    supportedHintGridSizes; 
	public     VkBool32                        hintSupported; 
	public     VkBool32                        costSupported; 
	public     VkBool32                        bidirectionalFlowSupported; 
	public     VkBool32                        globalFlowSupported; 
	public     uint32_t                        minWidth; 
	public     uint32_t                        minHeight; 
	public     uint32_t                        maxWidth; 
	public     uint32_t                        maxHeight; 
	public     uint32_t                        maxNumRegionsOfInterest; 
}
// VK_NV_optical_flow
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkOpticalFlowImageFormatInfoNV {
	public     VkStructureType              sType; 
	public      void*                  pNext; 
	public     VkOpticalFlowUsageFlagsNV    usage; 
}
// VK_NV_optical_flow
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkOpticalFlowImageFormatPropertiesNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkFormat           format; 
}
// VK_NV_optical_flow
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkOpticalFlowSessionCreateInfoNV {
	public     VkStructureType                      sType; 
	public     void*                                pNext; 
	public     uint32_t                             width; 
	public     uint32_t                             height; 
	public     VkFormat                             imageFormat; 
	public     VkFormat                             flowVectorFormat; 
	public     VkFormat                             costFormat; 
	public     VkOpticalFlowGridSizeFlagsNV         outputGridSize; 
	public     VkOpticalFlowGridSizeFlagsNV         hintGridSize; 
	public     VkOpticalFlowPerformanceLevelNV      performanceLevel; 
	public     VkOpticalFlowSessionCreateFlagsNV    flags; 
}
// VK_NV_optical_flow
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkOpticalFlowSessionCreatePrivateDataInfoNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           id; 
	public     uint32_t           size; 
	public      void*        pPrivateData; 
}
// VK_NV_optical_flow
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkOpticalFlowExecuteInfoNV {
	public     VkStructureType                sType; 
	public     void*                          pNext; 
	public     VkOpticalFlowExecuteFlagsNV    flags; 
	public     uint32_t                       regionCount; 
	public      VkRect2D*                pRegions; 
}
// VK_EXT_legacy_dithering
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceLegacyDitheringFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           legacyDithering; 
}
// VK_AMD_anti_lag
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceAntiLagFeaturesAMD {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           antiLag; 
}
// VK_AMD_anti_lag
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAntiLagPresentationInfoAMD {
	public     VkStructureType      sType; 
	public     void*                pNext; 
	public     VkAntiLagStageAMD    stage; 
	public     uint64_t             frameIndex; 
}
// VK_AMD_anti_lag
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAntiLagDataAMD {
	public     VkStructureType                        sType; 
	public      void*                            pNext; 
	public     VkAntiLagModeAMD                       mode; 
	public     uint32_t                               maxFPS; 
	public      VkAntiLagPresentationInfoAMD*    pPresentationInfo; 
}
// VK_EXT_shader_object
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderObjectFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderObject; 
}
// VK_EXT_shader_object
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderObjectPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public fixed     uint8_t            shaderBinaryUUID[(int)VK.VK_UUID_SIZE]; 
	public     uint32_t           shaderBinaryVersion; 
}
// VK_EXT_shader_object
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkShaderCreateInfoEXT {
	public     VkStructureType                 sType; 
	public      void*                     pNext; 
	public     VkShaderCreateFlagsEXT          flags; 
	public     VkShaderStageFlagBits           stage; 
	public     VkShaderStageFlags              nextStage; 
	public     VkShaderCodeTypeEXT             codeType; 
	public     /* size_t */ nuint                          codeSize; 
	public      void*                     pCode; 
	public      ConstChar*                     pName; 
	public     uint32_t                        setLayoutCount; 
	public      VkDescriptorSetLayout*    pSetLayouts; 
	public     uint32_t                        pushConstantRangeCount; 
	public      VkPushConstantRange*      pPushConstantRanges; 
	public      VkSpecializationInfo*     pSpecializationInfo; 
}
// VK_EXT_shader_object
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDepthClampRangeEXT {
	public     float    minDepthClamp; 
	public     float    maxDepthClamp; 
}
// VK_QCOM_tile_properties
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceTilePropertiesFeaturesQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           tileProperties; 
}
// VK_QCOM_tile_properties
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkTilePropertiesQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkExtent3D         tileSize; 
	public     VkExtent2D         apronSize; 
	public     VkOffset2D         origin; 
}
// VK_SEC_amigo_profiling
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceAmigoProfilingFeaturesSEC {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           amigoProfiling; 
}
// VK_SEC_amigo_profiling
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAmigoProfilingSubmitInfoSEC {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint64_t           firstDrawTimestamp; 
	public     uint64_t           swapBufferTimestamp; 
}
// VK_QCOM_multiview_per_view_viewports
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMultiviewPerViewViewportsFeaturesQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           multiviewPerViewViewports; 
}
// VK_NV_ray_tracing_invocation_reorder
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRayTracingInvocationReorderPropertiesNV {
	public     VkStructureType                        sType; 
	public     void*                                  pNext; 
	public     VkRayTracingInvocationReorderModeNV    rayTracingInvocationReorderReorderingHint; 
}
// VK_NV_ray_tracing_invocation_reorder
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRayTracingInvocationReorderFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           rayTracingInvocationReorder; 
}
// VK_NV_cooperative_vector
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCooperativeVectorPropertiesNV {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     VkShaderStageFlags    cooperativeVectorSupportedStages; 
	public     VkBool32              cooperativeVectorTrainingFloat16Accumulation; 
	public     VkBool32              cooperativeVectorTrainingFloat32Accumulation; 
	public     uint32_t              maxCooperativeVectorComponents; 
}
// VK_NV_cooperative_vector
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCooperativeVectorFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           cooperativeVector; 
	public     VkBool32           cooperativeVectorTraining; 
}
// VK_NV_cooperative_vector
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCooperativeVectorPropertiesNV {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     VkComponentTypeKHR    inputType; 
	public     VkComponentTypeKHR    inputInterpretation; 
	public     VkComponentTypeKHR    matrixInterpretation; 
	public     VkComponentTypeKHR    biasInterpretation; 
	public     VkComponentTypeKHR    resultType; 
	public     VkBool32              transpose; 
}
// VK_NV_cooperative_vector
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkConvertCooperativeVectorMatrixInfoNV {
	public     VkStructureType                      sType; 
	public      void*                          pNext; 
	public     /* size_t */ nuint                               srcSize; 
	public     VkDeviceOrHostAddressConstKHR        srcData; 
	public     /* size_t* */ nuint                              pDstSize; 
	public     VkDeviceOrHostAddressKHR             dstData; 
	public     VkComponentTypeKHR                   srcComponentType; 
	public     VkComponentTypeKHR                   dstComponentType; 
	public     uint32_t                             numRows; 
	public     uint32_t                             numColumns; 
	public     VkCooperativeVectorMatrixLayoutNV    srcLayout; 
	public     /* size_t */ nuint                               srcStride; 
	public     VkCooperativeVectorMatrixLayoutNV    dstLayout; 
	public     /* size_t */ nuint                               dstStride; 
}
// VK_NV_extended_sparse_address_space
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceExtendedSparseAddressSpaceFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           extendedSparseAddressSpace; 
}
// VK_NV_extended_sparse_address_space
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceExtendedSparseAddressSpacePropertiesNV {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     VkDeviceSize          extendedSparseAddressSpaceSize; 
	public     VkImageUsageFlags     extendedSparseImageUsageFlags; 
	public     VkBufferUsageFlags    extendedSparseBufferUsageFlags; 
}
// VK_EXT_legacy_vertex_attributes
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceLegacyVertexAttributesFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           legacyVertexAttributes; 
}
// VK_EXT_legacy_vertex_attributes
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceLegacyVertexAttributesPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           nativeUnalignedPerformance; 
}
// VK_EXT_layer_settings
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkLayerSettingEXT {
	public      ConstChar*              pLayerName; 
	public      ConstChar*              pSettingName; 
	public     VkLayerSettingTypeEXT    type; 
	public     uint32_t                 valueCount; 
	public      void*              pValues; 
}
// VK_EXT_layer_settings
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkLayerSettingsCreateInfoEXT {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     uint32_t                    settingCount; 
	public      VkLayerSettingEXT*    pSettings; 
}
// VK_ARM_shader_core_builtins
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderCoreBuiltinsFeaturesARM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderCoreBuiltins; 
}
// VK_ARM_shader_core_builtins
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderCoreBuiltinsPropertiesARM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint64_t           shaderCoreMask; 
	public     uint32_t           shaderCoreCount; 
	public     uint32_t           shaderWarpsPerCore; 
}
// VK_EXT_pipeline_library_group_handles
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePipelineLibraryGroupHandlesFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           pipelineLibraryGroupHandles; 
}
// VK_EXT_dynamic_rendering_unused_attachments
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDynamicRenderingUnusedAttachmentsFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           dynamicRenderingUnusedAttachments; 
}
// VK_NV_low_latency2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkLatencySleepModeInfoNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBool32           lowLatencyMode; 
	public     VkBool32           lowLatencyBoost; 
	public     uint32_t           minimumIntervalUs; 
}
// VK_NV_low_latency2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkLatencySleepInfoNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkSemaphore        signalSemaphore; 
	public     uint64_t           value; 
}
// VK_NV_low_latency2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSetLatencyMarkerInfoNV {
	public     VkStructureType      sType; 
	public      void*          pNext; 
	public     uint64_t             presentID; 
	public     VkLatencyMarkerNV    marker; 
}
// VK_NV_low_latency2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkLatencyTimingsFrameReportNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint64_t           presentID; 
	public     uint64_t           inputSampleTimeUs; 
	public     uint64_t           simStartTimeUs; 
	public     uint64_t           simEndTimeUs; 
	public     uint64_t           renderSubmitStartTimeUs; 
	public     uint64_t           renderSubmitEndTimeUs; 
	public     uint64_t           presentStartTimeUs; 
	public     uint64_t           presentEndTimeUs; 
	public     uint64_t           driverStartTimeUs; 
	public     uint64_t           driverEndTimeUs; 
	public     uint64_t           osRenderQueueStartTimeUs; 
	public     uint64_t           osRenderQueueEndTimeUs; 
	public     uint64_t           gpuRenderStartTimeUs; 
	public     uint64_t           gpuRenderEndTimeUs; 
}
// VK_NV_low_latency2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkGetLatencyMarkerInfoNV {
	public     VkStructureType                   sType; 
	public      void*                       pNext; 
	public     uint32_t                          timingCount; 
	public     VkLatencyTimingsFrameReportNV*    pTimings; 
}
// VK_NV_low_latency2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkLatencySubmissionPresentIdNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint64_t           presentID; 
}
// VK_NV_low_latency2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSwapchainLatencyCreateInfoNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBool32           latencyModeEnable; 
}
// VK_NV_low_latency2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkOutOfBandQueueTypeInfoNV {
	public     VkStructureType           sType; 
	public      void*               pNext; 
	public     VkOutOfBandQueueTypeNV    queueType; 
}
// VK_NV_low_latency2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkLatencySurfaceCapabilitiesNV {
	public     VkStructureType      sType; 
	public      void*          pNext; 
	public     uint32_t             presentModeCount; 
	public     VkPresentModeKHR*    pPresentModes; 
}
// VK_QCOM_multiview_per_view_render_areas
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMultiviewPerViewRenderAreasFeaturesQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           multiviewPerViewRenderAreas; 
}
// VK_QCOM_multiview_per_view_render_areas
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkMultiviewPerViewRenderAreasRenderPassBeginInfoQCOM {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           perViewRenderAreaCount; 
	public      VkRect2D*    pPerViewRenderAreas; 
}
// VK_NV_per_stage_descriptor_set
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePerStageDescriptorSetFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           perStageDescriptorSet; 
	public     VkBool32           dynamicPipelineLayout; 
}
// VK_QCOM_image_processing2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceImageProcessing2FeaturesQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           textureBlockMatch2; 
}
// VK_QCOM_image_processing2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceImageProcessing2PropertiesQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkExtent2D         maxBlockMatchWindow; 
}
// VK_QCOM_image_processing2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSamplerBlockMatchWindowCreateInfoQCOM {
	public     VkStructureType                      sType; 
	public      void*                          pNext; 
	public     VkExtent2D                           windowExtent; 
	public     VkBlockMatchWindowCompareModeQCOM    windowCompareMode; 
}
// VK_QCOM_filter_cubic_weights
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCubicWeightsFeaturesQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           selectableCubicWeights; 
}
// VK_QCOM_filter_cubic_weights
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSamplerCubicWeightsCreateInfoQCOM {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkCubicFilterWeightsQCOM    cubicWeights; 
}
// VK_QCOM_filter_cubic_weights
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBlitImageCubicWeightsInfoQCOM {
	public     VkStructureType             sType; 
	public      void*                 pNext; 
	public     VkCubicFilterWeightsQCOM    cubicWeights; 
}
// VK_QCOM_ycbcr_degamma
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceYcbcrDegammaFeaturesQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           ycbcrDegamma; 
}
// VK_QCOM_ycbcr_degamma
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSamplerYcbcrConversionYcbcrDegammaCreateInfoQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           enableYDegamma; 
	public     VkBool32           enableCbCrDegamma; 
}
// VK_QCOM_filter_cubic_clamp
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCubicClampFeaturesQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           cubicRangeClamp; 
}
// VK_EXT_attachment_feedback_loop_dynamic_state
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceAttachmentFeedbackLoopDynamicStateFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           attachmentFeedbackLoopDynamicState; 
}
// VK_MSFT_layered_driver
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceLayeredDriverPropertiesMSFT {
	public     VkStructureType                     sType; 
	public     void*                               pNext; 
	public     VkLayeredDriverUnderlyingApiMSFT    underlyingAPI; 
}
// VK_NV_descriptor_pool_overallocation
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDescriptorPoolOverallocationFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           descriptorPoolOverallocation; 
}
// VK_QCOM_tile_memory_heap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceTileMemoryHeapFeaturesQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           tileMemoryHeap; 
}
// VK_QCOM_tile_memory_heap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceTileMemoryHeapPropertiesQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           queueSubmitBoundary; 
	public     VkBool32           tileBufferTransfers; 
}
// VK_QCOM_tile_memory_heap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkTileMemoryRequirementsQCOM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkDeviceSize       size; 
	public     VkDeviceSize       alignment; 
}
// VK_QCOM_tile_memory_heap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkTileMemoryBindInfoQCOM {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkDeviceMemory     memory; 
}
// VK_QCOM_tile_memory_heap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkTileMemorySizeInfoQCOM {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkDeviceSize       size; 
}
// VK_NV_display_stereo
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplaySurfaceStereoCreateInfoNV {
	public     VkStructureType                 sType; 
	public      void*                     pNext; 
	public     VkDisplaySurfaceStereoTypeNV    stereoType; 
}
// VK_NV_display_stereo
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDisplayModeStereoPropertiesNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkBool32           hdmi3DSupported; 
}
// VK_NV_raw_access_chains
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRawAccessChainsFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderRawAccessChains; 
}
// VK_NV_external_compute_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExternalComputeQueueDeviceCreateInfoNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           reservedExternalQueues; 
}
// VK_NV_external_compute_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExternalComputeQueueCreateInfoNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkQueue            preferredQueue; 
}
// VK_NV_external_compute_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkExternalComputeQueueDataParamsNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           deviceIndex; 
}
// VK_NV_external_compute_queue
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceExternalComputeQueuePropertiesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           externalDataSize; 
	public     uint32_t           maxExternalQueues; 
}
// VK_NV_command_buffer_inheritance
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCommandBufferInheritanceFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           commandBufferInheritance; 
}
// VK_NV_shader_atomic_float16_vector
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderAtomicFloat16VectorFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderFloat16VectorAtomics; 
}
// VK_EXT_shader_replicated_composites
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceShaderReplicatedCompositesFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           shaderReplicatedComposites; 
}
// VK_NV_ray_tracing_validation
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRayTracingValidationFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           rayTracingValidation; 
}
// VK_NV_cluster_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceClusterAccelerationStructureFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           clusterAccelerationStructure; 
}
// VK_NV_cluster_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceClusterAccelerationStructurePropertiesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxVerticesPerCluster; 
	public     uint32_t           maxTrianglesPerCluster; 
	public     uint32_t           clusterScratchByteAlignment; 
	public     uint32_t           clusterByteAlignment; 
	public     uint32_t           clusterTemplateByteAlignment; 
	public     uint32_t           clusterBottomLevelByteAlignment; 
	public     uint32_t           clusterTemplateBoundsByteAlignment; 
	public     uint32_t           maxClusterGeometryIndex; 
}
// VK_NV_cluster_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkClusterAccelerationStructureClustersBottomLevelInputNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxTotalClusterCount; 
	public     uint32_t           maxClusterCountPerAccelerationStructure; 
}
// VK_NV_cluster_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkClusterAccelerationStructureTriangleClusterInputNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkFormat           vertexFormat; 
	public     uint32_t           maxGeometryIndexValue; 
	public     uint32_t           maxClusterUniqueGeometryCount; 
	public     uint32_t           maxClusterTriangleCount; 
	public     uint32_t           maxClusterVertexCount; 
	public     uint32_t           maxTotalTriangleCount; 
	public     uint32_t           maxTotalVertexCount; 
	public     uint32_t           minPositionTruncateBitCount; 
}
// VK_NV_cluster_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkClusterAccelerationStructureMoveObjectsInputNV {
	public     VkStructureType                         sType; 
	public     void*                                   pNext; 
	public     VkClusterAccelerationStructureTypeNV    type; 
	public     VkBool32                                noMoveOverlap; 
	public     VkDeviceSize                            maxMovedBytes; 
}
// VK_NV_cluster_acceleration_structure

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct VkClusterAccelerationStructureOpInputNV
{
	[FieldOffset(0)]
	public VkClusterAccelerationStructureClustersBottomLevelInputNV* pClustersBottomLevel;
	[FieldOffset(0)]
	public VkClusterAccelerationStructureTriangleClusterInputNV* pTriangleClusters;
	[FieldOffset(0)]
	public VkClusterAccelerationStructureMoveObjectsInputNV* pMoveObjects;
}

[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE), SkipLocalsInit]
public unsafe  struct VkClusterAccelerationStructureInputInfoNV {
	public     VkStructureType                            sType; 
	public     void*                                      pNext; 
	public     uint32_t                                   maxAccelerationStructureCount; 
	public     VkBuildAccelerationStructureFlagsKHR       flags; 
	public     VkClusterAccelerationStructureOpTypeNV     opType; 
	public     VkClusterAccelerationStructureOpModeNV     opMode; 
	public     VkClusterAccelerationStructureOpInputNV    opInput; 
}
// VK_NV_cluster_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkStridedDeviceAddressRegionKHR {
	public     VkDeviceAddress    deviceAddress; 
	public     VkDeviceSize       stride; 
	public     VkDeviceSize       size; 
}
// VK_NV_cluster_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkClusterAccelerationStructureCommandsInfoNV {
	public     VkStructureType                                           sType; 
	public     void*                                                     pNext; 
	public     VkClusterAccelerationStructureInputInfoNV                 input; 
	public     VkDeviceAddress                                           dstImplicitData; 
	public     VkDeviceAddress                                           scratchData; 
	public     VkStridedDeviceAddressRegionKHR                           dstAddressesArray; 
	public     VkStridedDeviceAddressRegionKHR                           dstSizesArray; 
	public     VkStridedDeviceAddressRegionKHR                           srcInfosArray; 
	public     VkDeviceAddress                                           srcInfosCount; 
	public     VkClusterAccelerationStructureAddressResolutionFlagsNV    addressResolutionFlags; 
}
// VK_NV_cluster_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkStridedDeviceAddressNV {
	public     VkDeviceAddress    startAddress; 
	public     VkDeviceSize       strideInBytes; 
}
// VK_NV_cluster_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkClusterAccelerationStructureGeometryIndexAndGeometryFlagsNV {
	public     fixed uint32_t    geometryIndex[24]; 
	public     fixed uint32_t    reserved[5]; 
	public     fixed uint32_t    geometryFlags[3]; 
}
// VK_NV_cluster_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkClusterAccelerationStructureMoveObjectsInfoNV {
	public     VkDeviceAddress    srcAccelerationStructure; 
}
// VK_NV_cluster_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkClusterAccelerationStructureBuildClustersBottomLevelInfoNV {
	public     uint32_t           clusterReferencesCount; 
	public     uint32_t           clusterReferencesStride; 
	public     VkDeviceAddress    clusterReferences; 
}
// VK_NV_cluster_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkClusterAccelerationStructureBuildTriangleClusterInfoNV {
	public     uint32_t                                                         clusterID; 
	public     VkClusterAccelerationStructureClusterFlagsNV                     clusterFlags; 
	public     fixed uint32_t                                                         triangleCount[9]; 
	public     fixed uint32_t                                                         vertexCount[9]; 
	public     fixed uint32_t                                                         positionTruncateBitCount[6]; 
	public     fixed uint32_t                                                         indexType[4]; 
	public     fixed uint32_t                                                         opacityMicromapIndexType[4]; 
	public     VkClusterAccelerationStructureGeometryIndexAndGeometryFlagsNV    baseGeometryIndexAndGeometryFlags; 
	public     uint16_t                                                         indexBufferStride; 
	public     uint16_t                                                         vertexBufferStride; 
	public     uint16_t                                                         geometryIndexAndFlagsBufferStride; 
	public     uint16_t                                                         opacityMicromapIndexBufferStride; 
	public     VkDeviceAddress                                                  indexBuffer; 
	public     VkDeviceAddress                                                  vertexBuffer; 
	public     VkDeviceAddress                                                  geometryIndexAndFlagsBuffer; 
	public     VkDeviceAddress                                                  opacityMicromapArray; 
	public     VkDeviceAddress                                                  opacityMicromapIndexBuffer; 
}
// VK_NV_cluster_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkClusterAccelerationStructureBuildTriangleClusterTemplateInfoNV {
	public     uint32_t                                                         clusterID; 
	public     VkClusterAccelerationStructureClusterFlagsNV                     clusterFlags; 
	public     fixed uint32_t                                                         triangleCount[9]; 
	public     fixed uint32_t                                                         vertexCount[9]; 
	public     fixed uint32_t                                                         positionTruncateBitCount[6]; 
	public     fixed uint32_t                                                         indexType[4]; 
	public     fixed uint32_t                                                         opacityMicromapIndexType[4]; 
	public     VkClusterAccelerationStructureGeometryIndexAndGeometryFlagsNV    baseGeometryIndexAndGeometryFlags; 
	public     uint16_t                                                         indexBufferStride; 
	public     uint16_t                                                         vertexBufferStride; 
	public     uint16_t                                                         geometryIndexAndFlagsBufferStride; 
	public     uint16_t                                                         opacityMicromapIndexBufferStride; 
	public     VkDeviceAddress                                                  indexBuffer; 
	public     VkDeviceAddress                                                  vertexBuffer; 
	public     VkDeviceAddress                                                  geometryIndexAndFlagsBuffer; 
	public     VkDeviceAddress                                                  opacityMicromapArray; 
	public     VkDeviceAddress                                                  opacityMicromapIndexBuffer; 
	public     VkDeviceAddress                                                  instantiationBoundingBoxLimit; 
}
// VK_NV_cluster_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkClusterAccelerationStructureInstantiateClusterInfoNV {
	public     uint32_t                    clusterIdOffset; 
	public     fixed uint32_t                    geometryIndexOffset[24]; 
	public     fixed uint32_t                    reserved[8]; 
	public     VkDeviceAddress             clusterTemplateAddress; 
	public     VkStridedDeviceAddressNV    vertexBuffer; 
}
// VK_NV_cluster_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureBuildSizesInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkDeviceSize       accelerationStructureSize; 
	public     VkDeviceSize       updateScratchSize; 
	public     VkDeviceSize       buildScratchSize; 
}
// VK_NV_cluster_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRayTracingPipelineClusterAccelerationStructureCreateInfoNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           allowClusterAccelerationStructure; 
}
// VK_NV_partitioned_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePartitionedAccelerationStructureFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           partitionedAccelerationStructure; 
}
// VK_NV_partitioned_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePartitionedAccelerationStructurePropertiesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxPartitionCount; 
}
// VK_NV_partitioned_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPartitionedAccelerationStructureFlagsNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           enablePartitionTranslation; 
}
// VK_NV_partitioned_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBuildPartitionedAccelerationStructureIndirectCommandNV {
	public     VkPartitionedAccelerationStructureOpTypeNV    opType; 
	public     uint32_t                                      argCount; 
	public     VkStridedDeviceAddressNV                      argData; 
}
// VK_NV_partitioned_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPartitionedAccelerationStructureWriteInstanceDataNV {
	public     VkTransformMatrixKHR                                 transform; 
	public fixed     float                                                explicitAABB[6]; 
	public     uint32_t                                             instanceID; 
	public     uint32_t                                             instanceMask; 
	public     uint32_t                                             instanceContributionToHitGroupIndex; 
	public     VkPartitionedAccelerationStructureInstanceFlagsNV    instanceFlags; 
	public     uint32_t                                             instanceIndex; 
	public     uint32_t                                             partitionIndex; 
	public     VkDeviceAddress                                      accelerationStructure; 
}
// VK_NV_partitioned_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPartitionedAccelerationStructureUpdateInstanceDataNV {
	public     uint32_t           instanceIndex; 
	public     uint32_t           instanceContributionToHitGroupIndex; 
	public     VkDeviceAddress    accelerationStructure; 
}
// VK_NV_partitioned_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPartitionedAccelerationStructureWritePartitionTranslationDataNV {
	public     uint32_t    partitionIndex; 
	public fixed     float       partitionTranslation[3]; 
}
// VK_NV_partitioned_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkWriteDescriptorSetPartitionedAccelerationStructureNV {
	public     VkStructureType           sType; 
	public     void*                     pNext; 
	public     uint32_t                  accelerationStructureCount; 
	public      VkDeviceAddress*    pAccelerationStructures; 
}
// VK_NV_partitioned_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPartitionedAccelerationStructureInstancesInputNV {
	public     VkStructureType                         sType; 
	public     void*                                   pNext; 
	public     VkBuildAccelerationStructureFlagsKHR    flags; 
	public     uint32_t                                instanceCount; 
	public     uint32_t                                maxInstancePerPartitionCount; 
	public     uint32_t                                partitionCount; 
	public     uint32_t                                maxInstanceInGlobalPartitionCount; 
}
// VK_NV_partitioned_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBuildPartitionedAccelerationStructureInfoNV {
	public     VkStructureType                                       sType; 
	public     void*                                                 pNext; 
	public     VkPartitionedAccelerationStructureInstancesInputNV    input; 
	public     VkDeviceAddress                                       srcAccelerationStructureData; 
	public     VkDeviceAddress                                       dstAccelerationStructureData; 
	public     VkDeviceAddress                                       scratchData; 
	public     VkDeviceAddress                                       srcInfos; 
	public     VkDeviceAddress                                       srcInfosCount; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDeviceGeneratedCommandsFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           deviceGeneratedCommands; 
	public     VkBool32           dynamicGeneratedPipelineLayout; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDeviceGeneratedCommandsPropertiesEXT {
	public     VkStructureType                        sType; 
	public     void*                                  pNext; 
	public     uint32_t                               maxIndirectPipelineCount; 
	public     uint32_t                               maxIndirectShaderObjectCount; 
	public     uint32_t                               maxIndirectSequenceCount; 
	public     uint32_t                               maxIndirectCommandsTokenCount; 
	public     uint32_t                               maxIndirectCommandsTokenOffset; 
	public     uint32_t                               maxIndirectCommandsIndirectStride; 
	public     VkIndirectCommandsInputModeFlagsEXT    supportedIndirectCommandsInputModes; 
	public     VkShaderStageFlags                     supportedIndirectCommandsShaderStages; 
	public     VkShaderStageFlags                     supportedIndirectCommandsShaderStagesPipelineBinding; 
	public     VkShaderStageFlags                     supportedIndirectCommandsShaderStagesShaderBinding; 
	public     VkBool32                               deviceGeneratedCommandsTransformFeedback; 
	public     VkBool32                               deviceGeneratedCommandsMultiDrawIndirectCount; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkGeneratedCommandsMemoryRequirementsInfoEXT {
	public     VkStructureType                sType; 
	public      void*                    pNext; 
	public     VkIndirectExecutionSetEXT      indirectExecutionSet; 
	public     VkIndirectCommandsLayoutEXT    indirectCommandsLayout; 
	public     uint32_t                       maxSequenceCount; 
	public     uint32_t                       maxDrawCount; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkIndirectExecutionSetPipelineInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     VkPipeline         initialPipeline; 
	public     uint32_t           maxPipelineCount; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkIndirectExecutionSetShaderLayoutInfoEXT {
	public     VkStructureType                 sType; 
	public      void*                     pNext; 
	public     uint32_t                        setLayoutCount; 
	public      VkDescriptorSetLayout*    pSetLayouts; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkIndirectExecutionSetShaderInfoEXT {
	public     VkStructureType                                     sType; 
	public      void*                                         pNext; 
	public     uint32_t                                            shaderCount; 
	public      VkShaderEXT*                                  pInitialShaders; 
	public      VkIndirectExecutionSetShaderLayoutInfoEXT*    pSetLayoutInfos; 
	public     uint32_t                                            maxShaderCount; 
	public     uint32_t                                            pushConstantRangeCount; 
	public      VkPushConstantRange*                          pPushConstantRanges; 
}
// VK_EXT_device_generated_commands


[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct VkIndirectExecutionSetInfoEXT
{
	[FieldOffset(0)]
	public VkIndirectExecutionSetPipelineInfoEXT* pPipelineInfo;
	[FieldOffset(0)]
	public VkIndirectExecutionSetShaderInfoEXT* pShaderInfo;
}

[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE), SkipLocalsInit]
public unsafe  struct VkIndirectExecutionSetCreateInfoEXT {
	public     VkStructureType                      sType; 
	public      void*                          pNext; 
	public     VkIndirectExecutionSetInfoTypeEXT    type; 
	public     VkIndirectExecutionSetInfoEXT        info; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkGeneratedCommandsInfoEXT {
	public     VkStructureType                sType; 
	public      void*                    pNext; 
	public     VkShaderStageFlags             shaderStages; 
	public     VkIndirectExecutionSetEXT      indirectExecutionSet; 
	public     VkIndirectCommandsLayoutEXT    indirectCommandsLayout; 
	public     VkDeviceAddress                indirectAddress; 
	public     VkDeviceSize                   indirectAddressSize; 
	public     VkDeviceAddress                preprocessAddress; 
	public     VkDeviceSize                   preprocessSize; 
	public     uint32_t                       maxSequenceCount; 
	public     VkDeviceAddress                sequenceCountAddress; 
	public     uint32_t                       maxDrawCount; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkWriteIndirectExecutionSetPipelineEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           index; 
	public     VkPipeline         pipeline; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkIndirectCommandsPushConstantTokenEXT {
	public     VkPushConstantRange    updateRange; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkIndirectCommandsVertexBufferTokenEXT {
	public     uint32_t    vertexBindingUnit; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkIndirectCommandsIndexBufferTokenEXT {
	public     VkIndirectCommandsInputModeFlagBitsEXT    mode; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkIndirectCommandsExecutionSetTokenEXT {
	public     VkIndirectExecutionSetInfoTypeEXT    type; 
	public     VkShaderStageFlags                   shaderStages; 
}
// VK_EXT_device_generated_commands

[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct VkIndirectCommandsTokenDataEXT
{
	[FieldOffset(0)]
	public VkIndirectCommandsPushConstantTokenEXT* pPushConstant;
	[FieldOffset(0)]
	public VkIndirectCommandsVertexBufferTokenEXT* pVertexBuffer;
	[FieldOffset(0)]
	public VkIndirectCommandsIndexBufferTokenEXT* pIndexBuffer;
	[FieldOffset(0)]
	public VkIndirectCommandsExecutionSetTokenEXT* pExecutionSet;
}
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE), SkipLocalsInit]
public unsafe  struct VkIndirectCommandsLayoutTokenEXT {
	public     VkStructureType                   sType; 
	public      void*                       pNext; 
	public     VkIndirectCommandsTokenTypeEXT    type; 
	public     VkIndirectCommandsTokenDataEXT    data; 
	public     uint32_t                          offset; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkIndirectCommandsLayoutCreateInfoEXT {
	public     VkStructureType                            sType; 
	public      void*                                pNext; 
	public     VkIndirectCommandsLayoutUsageFlagsEXT      flags; 
	public     VkShaderStageFlags                         shaderStages; 
	public     uint32_t                                   indirectStride; 
	public     VkPipelineLayout                           pipelineLayout; 
	public     uint32_t                                   tokenCount; 
	public      VkIndirectCommandsLayoutTokenEXT*    pTokens; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkDrawIndirectCountIndirectCommandEXT {
	public     VkDeviceAddress    bufferAddress; 
	public     uint32_t           stride; 
	public     uint32_t           commandCount; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindVertexBufferIndirectCommandEXT {
	public     VkDeviceAddress    bufferAddress; 
	public     uint32_t           size; 
	public     uint32_t           stride; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkBindIndexBufferIndirectCommandEXT {
	public     VkDeviceAddress    bufferAddress; 
	public     uint32_t           size; 
	public     VkIndexType        indexType; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkGeneratedCommandsPipelineInfoEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkPipeline         pipeline; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkGeneratedCommandsShaderInfoEXT {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     uint32_t              shaderCount; 
	public      VkShaderEXT*    pShaders; 
}
// VK_EXT_device_generated_commands
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkWriteIndirectExecutionSetShaderEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           index; 
	public     VkShaderEXT        shader; 
}
// VK_MESA_image_alignment_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceImageAlignmentControlFeaturesMESA {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           imageAlignmentControl; 
}
// VK_MESA_image_alignment_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceImageAlignmentControlPropertiesMESA {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           supportedImageAlignmentMask; 
}
// VK_MESA_image_alignment_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkImageAlignmentControlCreateInfoMESA {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           maximumRequestedAlignment; 
}
// VK_EXT_depth_clamp_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceDepthClampControlFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           depthClampControl; 
}
// VK_EXT_depth_clamp_control
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPipelineViewportDepthClampControlCreateInfoEXT {
	public     VkStructureType                sType; 
	public      void*                    pNext; 
	public     VkDepthClampModeEXT            depthClampMode; 
	public      VkDepthClampRangeEXT*    pDepthClampRange; 
}
// VK_HUAWEI_hdr_vivid
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceHdrVividFeaturesHUAWEI {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           hdrVivid; 
}
// VK_HUAWEI_hdr_vivid
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkHdrVividDynamicMetadataHUAWEI {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     /* size_t */ nuint             dynamicMetadataSize; 
	public      void*        pDynamicMetadata; 
}
// VK_NV_cooperative_matrix2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCooperativeMatrixFlexibleDimensionsPropertiesNV {
	public     VkStructureType       sType; 
	public     void*                 pNext; 
	public     uint32_t              MGranularity; 
	public     uint32_t              NGranularity; 
	public     uint32_t              KGranularity; 
	public     VkComponentTypeKHR    AType; 
	public     VkComponentTypeKHR    BType; 
	public     VkComponentTypeKHR    CType; 
	public     VkComponentTypeKHR    ResultType; 
	public     VkBool32              saturatingAccumulation; 
	public     VkScopeKHR            scope; 
	public     uint32_t              workgroupInvocations; 
}
// VK_NV_cooperative_matrix2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCooperativeMatrix2FeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           cooperativeMatrixWorkgroupScope; 
	public     VkBool32           cooperativeMatrixFlexibleDimensions; 
	public     VkBool32           cooperativeMatrixReductions; 
	public     VkBool32           cooperativeMatrixConversions; 
	public     VkBool32           cooperativeMatrixPerElementOperations; 
	public     VkBool32           cooperativeMatrixTensorAddressing; 
	public     VkBool32           cooperativeMatrixBlockLoads; 
}
// VK_NV_cooperative_matrix2
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceCooperativeMatrix2PropertiesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           cooperativeMatrixWorkgroupScopeMaxWorkgroupSize; 
	public     uint32_t           cooperativeMatrixFlexibleDimensionsMaxDimension; 
	public     uint32_t           cooperativeMatrixWorkgroupScopeReservedSharedMemory; 
}
// VK_ARM_pipeline_opacity_micromap
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePipelineOpacityMicromapFeaturesARM {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           pipelineOpacityMicromap; 
}
// VK_EXT_vertex_attribute_robustness
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceVertexAttributeRobustnessFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           vertexAttributeRobustness; 
}
// VK_NV_present_metering
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkSetPresentConfigNV {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           numFramesPerBatch; 
	public     uint32_t           presentConfigFeedback; 
}
// VK_NV_present_metering
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDevicePresentMeteringFeaturesNV {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           presentMetering; 
}
// VK_EXT_fragment_density_map_offset
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRenderingEndInfoEXT {
	public     VkStructureType    sType; 
	public      void*        pNext; 
}
// VK_EXT_zero_initialize_device_memory
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceZeroInitializeDeviceMemoryFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           zeroInitializeDeviceMemory; 
}
// VK_KHR_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureBuildRangeInfoKHR {
	public     uint32_t    primitiveCount; 
	public     uint32_t    primitiveOffset; 
	public     uint32_t    firstVertex; 
	public     uint32_t    transformOffset; 
}
// VK_KHR_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureGeometryTrianglesDataKHR {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkFormat                         vertexFormat; 
	public     VkDeviceOrHostAddressConstKHR    vertexData; 
	public     VkDeviceSize                     vertexStride; 
	public     uint32_t                         maxVertex; 
	public     VkIndexType                      indexType; 
	public     VkDeviceOrHostAddressConstKHR    indexData; 
	public     VkDeviceOrHostAddressConstKHR    transformData; 
}
// VK_KHR_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureGeometryAabbsDataKHR {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkDeviceOrHostAddressConstKHR    data; 
	public     VkDeviceSize                     stride; 
}
// VK_KHR_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureGeometryInstancesDataKHR {
	public     VkStructureType                  sType; 
	public      void*                      pNext; 
	public     VkBool32                         arrayOfPointers; 
	public     VkDeviceOrHostAddressConstKHR    data; 
}
// VK_KHR_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureGeometryKHR {
	public     VkStructureType                           sType; 
	public      void*                               pNext; 
	public     VkGeometryTypeKHR                         geometryType; 
	public     VkAccelerationStructureGeometryDataKHR    geometry; 
	public     VkGeometryFlagsKHR                        flags; 
}
// VK_KHR_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureBuildGeometryInfoKHR {
	public     VkStructureType                                     sType; 
	public      void*                                         pNext; 
	public     VkAccelerationStructureTypeKHR                      type; 
	public     VkBuildAccelerationStructureFlagsKHR                flags; 
	public     VkBuildAccelerationStructureModeKHR                 mode; 
	public     VkAccelerationStructureKHR                          srcAccelerationStructure; 
	public     VkAccelerationStructureKHR                          dstAccelerationStructure; 
	public     uint32_t                                            geometryCount; 
	public      VkAccelerationStructureGeometryKHR*           pGeometries; 
	public      VkAccelerationStructureGeometryKHR**    ppGeometries; 
	public     VkDeviceOrHostAddressKHR                            scratchData; 
}
// VK_KHR_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureCreateInfoKHR {
	public     VkStructureType                          sType; 
	public      void*                              pNext; 
	public     VkAccelerationStructureCreateFlagsKHR    createFlags; 
	public     VkBuffer                                 buffer; 
	public     VkDeviceSize                             offset; 
	public     VkDeviceSize                             size; 
	public     VkAccelerationStructureTypeKHR           type; 
	public     VkDeviceAddress                          deviceAddress; 
}
// VK_KHR_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkWriteDescriptorSetAccelerationStructureKHR {
	public     VkStructureType                      sType; 
	public      void*                          pNext; 
	public     uint32_t                             accelerationStructureCount; 
	public      VkAccelerationStructureKHR*    pAccelerationStructures; 
}
// VK_KHR_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceAccelerationStructureFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           accelerationStructure; 
	public     VkBool32           accelerationStructureCaptureReplay; 
	public     VkBool32           accelerationStructureIndirectBuild; 
	public     VkBool32           accelerationStructureHostCommands; 
	public     VkBool32           descriptorBindingAccelerationStructureUpdateAfterBind; 
}
// VK_KHR_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceAccelerationStructurePropertiesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint64_t           maxGeometryCount; 
	public     uint64_t           maxInstanceCount; 
	public     uint64_t           maxPrimitiveCount; 
	public     uint32_t           maxPerStageDescriptorAccelerationStructures; 
	public     uint32_t           maxPerStageDescriptorUpdateAfterBindAccelerationStructures; 
	public     uint32_t           maxDescriptorSetAccelerationStructures; 
	public     uint32_t           maxDescriptorSetUpdateAfterBindAccelerationStructures; 
	public     uint32_t           minAccelerationStructureScratchOffsetAlignment; 
}
// VK_KHR_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureDeviceAddressInfoKHR {
	public     VkStructureType               sType; 
	public      void*                   pNext; 
	public     VkAccelerationStructureKHR    accelerationStructure; 
}
// VK_KHR_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkAccelerationStructureVersionInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public      uint8_t*     pVersionData; 
}
// VK_KHR_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyAccelerationStructureToMemoryInfoKHR {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkAccelerationStructureKHR            src; 
	public     VkDeviceOrHostAddressKHR              dst; 
	public     VkCopyAccelerationStructureModeKHR    mode; 
}
// VK_KHR_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyMemoryToAccelerationStructureInfoKHR {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkDeviceOrHostAddressConstKHR         src; 
	public     VkAccelerationStructureKHR            dst; 
	public     VkCopyAccelerationStructureModeKHR    mode; 
}
// VK_KHR_acceleration_structure
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkCopyAccelerationStructureInfoKHR {
	public     VkStructureType                       sType; 
	public      void*                           pNext; 
	public     VkAccelerationStructureKHR            src; 
	public     VkAccelerationStructureKHR            dst; 
	public     VkCopyAccelerationStructureModeKHR    mode; 
}
// VK_KHR_ray_tracing_pipeline
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRayTracingShaderGroupCreateInfoKHR {
	public     VkStructureType                   sType; 
	public      void*                       pNext; 
	public     VkRayTracingShaderGroupTypeKHR    type; 
	public     uint32_t                          generalShader; 
	public     uint32_t                          closestHitShader; 
	public     uint32_t                          anyHitShader; 
	public     uint32_t                          intersectionShader; 
	public      void*                       pShaderGroupCaptureReplayHandle; 
}
// VK_KHR_ray_tracing_pipeline
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRayTracingPipelineInterfaceCreateInfoKHR {
	public     VkStructureType    sType; 
	public      void*        pNext; 
	public     uint32_t           maxPipelineRayPayloadSize; 
	public     uint32_t           maxPipelineRayHitAttributeSize; 
}
// VK_KHR_ray_tracing_pipeline
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkRayTracingPipelineCreateInfoKHR {
	public     VkStructureType                                      sType; 
	public      void*                                          pNext; 
	public     VkPipelineCreateFlags                                flags; 
	public     uint32_t                                             stageCount; 
	public      VkPipelineShaderStageCreateInfo*               pStages; 
	public     uint32_t                                             groupCount; 
	public      VkRayTracingShaderGroupCreateInfoKHR*          pGroups; 
	public     uint32_t                                             maxPipelineRayRecursionDepth; 
	public      VkPipelineLibraryCreateInfoKHR*                pLibraryInfo; 
	public      VkRayTracingPipelineInterfaceCreateInfoKHR*    pLibraryInterface; 
	public      VkPipelineDynamicStateCreateInfo*              pDynamicState; 
	public     VkPipelineLayout                                     layout; 
	public     VkPipeline                                           basePipelineHandle; 
	public     int32_t                                              basePipelineIndex; 
}
// VK_KHR_ray_tracing_pipeline
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRayTracingPipelineFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           rayTracingPipeline; 
	public     VkBool32           rayTracingPipelineShaderGroupHandleCaptureReplay; 
	public     VkBool32           rayTracingPipelineShaderGroupHandleCaptureReplayMixed; 
	public     VkBool32           rayTracingPipelineTraceRaysIndirect; 
	public     VkBool32           rayTraversalPrimitiveCulling; 
}
// VK_KHR_ray_tracing_pipeline
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRayTracingPipelinePropertiesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           shaderGroupHandleSize; 
	public     uint32_t           maxRayRecursionDepth; 
	public     uint32_t           maxShaderGroupStride; 
	public     uint32_t           shaderGroupBaseAlignment; 
	public     uint32_t           shaderGroupHandleCaptureReplaySize; 
	public     uint32_t           maxRayDispatchInvocationCount; 
	public     uint32_t           shaderGroupHandleAlignment; 
	public     uint32_t           maxRayHitAttributeSize; 
}
// VK_KHR_ray_tracing_pipeline
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkTraceRaysIndirectCommandKHR {
	public     uint32_t    width; 
	public     uint32_t    height; 
	public     uint32_t    depth; 
}
// VK_KHR_ray_query
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceRayQueryFeaturesKHR {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           rayQuery; 
}
// VK_EXT_mesh_shader
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMeshShaderFeaturesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     VkBool32           taskShader; 
	public     VkBool32           meshShader; 
	public     VkBool32           multiviewMeshShader; 
	public     VkBool32           primitiveFragmentShadingRateMeshShader; 
	public     VkBool32           meshShaderQueries; 
}
// VK_EXT_mesh_shader
[ SkipLocalsInit ]
[StructLayout(LayoutKind.Sequential)]  
public unsafe  struct VkPhysicalDeviceMeshShaderPropertiesEXT {
	public     VkStructureType    sType; 
	public     void*              pNext; 
	public     uint32_t           maxTaskWorkGroupTotalCount; 
	public fixed     uint32_t           maxTaskWorkGroupCount[3]; 
	public     uint32_t           maxTaskWorkGroupInvocations; 
	public fixed     uint32_t           maxTaskWorkGroupSize[3]; 
	public     uint32_t           maxTaskPayloadSize; 
	public     uint32_t           maxTaskSharedMemorySize; 
	public     uint32_t           maxTaskPayloadAndSharedMemorySize; 
	public     uint32_t           maxMeshWorkGroupTotalCount; 
	public fixed     uint32_t           maxMeshWorkGroupCount[3]; 
	public     uint32_t           maxMeshWorkGroupInvocations; 
	public fixed     uint32_t           maxMeshWorkGroupSize[3]; 
	public     uint32_t           maxMeshSharedMemorySize; 
	public     uint32_t           maxMeshPayloadAndSharedMemorySize; 
	public     uint32_t           maxMeshOutputMemorySize; 
	public     uint32_t           maxMeshPayloadAndOutputMemorySize; 
	public     uint32_t           maxMeshOutputComponents; 
	public     uint32_t           maxMeshOutputVertices; 
	public     uint32_t           maxMeshOutputPrimitives; 
	public     uint32_t           maxMeshOutputLayers; 
	public     uint32_t           maxMeshMultiviewViewCount; 
	public     uint32_t           meshOutputPerVertexGranularity; 
	public     uint32_t           meshOutputPerPrimitiveGranularity; 
	public     uint32_t           maxPreferredTaskWorkGroupInvocations; 
	public     uint32_t           maxPreferredMeshWorkGroupInvocations; 
	public     VkBool32           prefersLocalInvocationVertexOutput; 
	public     VkBool32           prefersLocalInvocationPrimitiveOutput; 
	public     VkBool32           prefersCompactVertexOutput; 
	public     VkBool32           prefersCompactPrimitiveOutput; 
}
// VK_EXT_mesh_shader
[StructLayout(LayoutKind.Sequential, Pack = VK.DATA_ALIGNEMENT_SIZE), SkipLocalsInit]
public unsafe struct VkDrawMeshTasksIndirectCommandEXT
{
    public uint32_t groupCountX;
    public uint32_t groupCountY;
    public uint32_t groupCountZ;
}

