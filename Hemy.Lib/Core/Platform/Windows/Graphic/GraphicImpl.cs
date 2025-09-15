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
internal unsafe static class GraphicImpl
{
// TODO: Placer le code GraphicImpl dans Vulkan ?? ne garder que le Init Dispose et draw ...

    internal static int Init(GraphicData* contextData, WindowData* windowData)
    {
        CreateDevice(contextData, windowData);
        CreateSwapChain(contextData, windowData);
        return 0;
    }

    internal static void Dispose(GraphicData* contextData)
    {
        Pause(contextData);

        DisposeSwapChain(contextData);

        RenderImpl.DisposeRender(contextData);

        DisposeDevice(contextData);
        
        Memory.Memory.DisposeArray(contextData->InFlightFences);
        Memory.Memory.DisposeArray(contextData->ImageAvailableSemaphores);
        Memory.Memory.DisposeArray(contextData->RenderFinishedSemaphores);
        Memory.Memory.DisposeArray(contextData->CommandBuffers);
        Memory.Memory.DisposeArray(contextData->RenderPassClearValues);
        Memory.Memory.DisposeArray(contextData->RenderPassArea);
        Memory.Memory.DisposeArray(contextData->SwapChainImages);
        Memory.Memory.DisposeArray(contextData->SwapChainImageViews);
        Memory.Memory.DisposeArray(contextData->Framebuffers);
    }


    internal static int CreateDevice(GraphicData* contextData, WindowData* windowData)
    {
        // 	//Enumarate instance Layer 
        uint layerCount = 0;
        VkResult result = Vk.vkEnumerateInstanceLayerProperties(&layerCount, null);
        if (result != VkResult.VK_SUCCESS || layerCount == 0) { return 1; }

        VkLayerProperties* layerProperties = stackalloc VkLayerProperties[(int)layerCount];

        result = Vk.vkEnumerateInstanceLayerProperties(&layerCount, layerProperties);
        if (result != VkResult.VK_SUCCESS || layerCount == 0) { return 1; }

        Hemy.Lib.Core.Memory.StrArray ValidationLayers = new(layerCount, VK.VK_MAX_DESCRIPTION_SIZE);

        for (uint i = 0; i < layerCount; i++)
        {
            ValidationLayers.Add(layerProperties[i].layerName, i);
        }

        //Enumarate Instrance Extension ( loader instance )
        uint instanceExtCount = 0;

        result = Vk.vkEnumerateInstanceExtensionProperties(null, &instanceExtCount, null);
        if (result != VkResult.VK_SUCCESS || instanceExtCount == 0) { return 1; }

        VkExtensionProperties* props = stackalloc VkExtensionProperties[(int)instanceExtCount];

        result = Vk.vkEnumerateInstanceExtensionProperties(null, &instanceExtCount, props);
        if (result != VkResult.VK_SUCCESS) { return 1; }

        Hemy.Lib.Core.Memory.StrArray InstanceExtensions = new(instanceExtCount, VK.VK_MAX_DESCRIPTION_SIZE);

        for (uint i = 0; i < instanceExtCount; i++)
        {
            InstanceExtensions.Add(props[i].extensionName, i);
        }

        // 	// Create debug 
        VkDebugUtilsMessengerCreateInfoEXT* debugCreateInfo = stackalloc VkDebugUtilsMessengerCreateInfoEXT[1];
        debugCreateInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_DEBUG_UTILS_MESSENGER_CREATE_INFO_EXT;
        debugCreateInfo[0].pNext = null;
        debugCreateInfo[0].messageSeverity = (uint)(VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_VERBOSE_BIT_EXT
                                        | VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT
                                        | VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT
                                        | VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_INFO_BIT_EXT);
        debugCreateInfo[0].messageType = (uint)(VkDebugUtilsMessageTypeFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_TYPE_GENERAL_BIT_EXT
                                        | VkDebugUtilsMessageTypeFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_TYPE_VALIDATION_BIT_EXT
                                        | VkDebugUtilsMessageTypeFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_TYPE_PERFORMANCE_BIT_EXT);

        debugCreateInfo[0].pfnUserCallback = &DebugMessengerCallback;
        debugCreateInfo[0].pUserData = null;
        debugCreateInfo[0].flags = 0;

        // Create Instance
        VkApplicationInfo* appInfo = stackalloc VkApplicationInfo[1];
        appInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_APPLICATION_INFO;
        appInfo[0].apiVersion = ToUint(1, 4, 0);
        appInfo[0].applicationVersion = ToUint(1, 0, 0); ;
        appInfo[0].engineVersion = ToUint(1, 0, 0); ;
        appInfo[0].pNext = null;
        appInfo[0].pApplicationName = windowData->GameName;
        appInfo[0].pEngineName = windowData->EngineName;

        VkInstanceCreateInfo* instanceCreateInfo = stackalloc VkInstanceCreateInfo[1];
        instanceCreateInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO;
        instanceCreateInfo[0].flags = (uint)VkInstanceCreateFlagBits.VK_INSTANCE_CREATE_ENUMERATE_PORTABILITY_BIT_KHR;
        instanceCreateInfo[0].pApplicationInfo = &appInfo[0];
        instanceCreateInfo[0].pNext = !contextData->EnableDebugMode ? null : &debugCreateInfo[0];
        instanceCreateInfo[0].ppEnabledExtensionNames = (byte**)InstanceExtensions.Pointer;
        instanceCreateInfo[0].enabledExtensionCount = InstanceExtensions.Count;
        instanceCreateInfo[0].enabledLayerCount = contextData->EnableDebugMode ? ValidationLayers.Count : 0;
        instanceCreateInfo[0].ppEnabledLayerNames = contextData->EnableDebugMode ? (byte**)ValidationLayers.Pointer : null;

        result = Vk.vkCreateInstance(&instanceCreateInfo[0], null, &contextData->Instance);

        if (result != VkResult.VK_SUCCESS)
        {
            Log.Error("Failed To Create VKInstance");
            return 1;
        }

        Loader.LoadFunction load = Loader.LoadInstanceFunc;
        Loader.Load(load, (void*)contextData->Instance, &InstanceExtensions);

        Log.Info("Try to create Debug Mode ");
        if (contextData->EnableDebugMode)
        {
#if DEBUG
            result = Vk.vkCreateDebugUtilsMessengerEXT(contextData->Instance, &debugCreateInfo[0], null, &contextData->DebugMessenger);
            Log.Info("Create Debug ");
#endif
        }
#if WINDOWS
        WindowsVulkan.Loader(load, (void*)contextData->Instance);

        Log.Info("Try to create Surface");
        VkWin32SurfaceCreateInfoKHR* sci = stackalloc VkWin32SurfaceCreateInfoKHR[1];
        sci[0].hinstance = windowData->HInstance;
        sci[0].hwnd = windowData->Handle;
        sci[0].pNext = null;
        sci[0].flags = 0;
        sci[0].sType = VkStructureType.VK_STRUCTURE_TYPE_WIN32_SURFACE_CREATE_INFO_KHR;

        result = WindowsVulkan.vkCreateWin32SurfaceKHR(contextData->Instance, &sci[0], null, &contextData->Surface);
        // if (Log.Check(result != VkResult.VK_SUCCESS, "Error Create Surface : " + result)) return 1;
#else
        //         if (Log.Check(result != VkResult.VK_SUCCESS, "Error Surface Unknown doon't use Vulkan Backend: " + result)) return 1;
#endif
        // Enumerate physical Device
        uint deviceCount = 0;
        result = Vk.vkEnumeratePhysicalDevices(contextData->Instance, &deviceCount, null);
        // if (Log.Check(result != VkResult.VK_SUCCESS, "Error Enumerate Physical Device : " + result)) { return 1; }

        VkPhysicalDevice* devices = stackalloc VkPhysicalDevice[(int)deviceCount];

        result = Vk.vkEnumeratePhysicalDevices(contextData->Instance, &deviceCount, devices);
        // if (Log.Check(result != VkResult.VK_SUCCESS, "Error Create Enumerate Physical Device" + result)) { return 1; }

        // 	// Find best physical device         //  : select in options your favorite device
        for (int i = 0; i < (int)deviceCount; i++)
        {
            contextData->DevicePhysical = IsSuitable(contextData, devices[i]);

            if (!contextData->DevicePhysical.IsNull)
                break;
        }

        if (contextData->DevicePhysical.IsNull) return 1;

        // Get Devicxe Extensions
        uint devicePropertiesExtCount = 0;
        result = Vk.vkEnumerateDeviceExtensionProperties(contextData->DevicePhysical, null, &devicePropertiesExtCount, null);
        // if (Log.Check(result != VkResult.VK_SUCCESS || devicePropertiesExtCount == 0, "Error Create Enumerate Physical Device" + result)) { return 1; }

        VkExtensionProperties* properties = stackalloc VkExtensionProperties[(int)devicePropertiesExtCount];
        result = Vk.vkEnumerateDeviceExtensionProperties(contextData->DevicePhysical, null, &devicePropertiesExtCount, properties);
        // if (Log.Check(result != VkResult.VK_SUCCESS, "Error Create Enumerate Physical Device" + result)) { return 1; }

        Hemy.Lib.Core.Memory.StrArray DeviceExtensions = new(devicePropertiesExtCount, VK.VK_MAX_DESCRIPTION_SIZE);

        for (uint i = 0; i < devicePropertiesExtCount; i++)
        {
            DeviceExtensions.Add(properties[i].extensionName, i);
            // _ = Log.Check(DeviceExtensions.Add(properties[i].extensionName, i) == false, "error not add device extension  at index : " + i);
            // Log.Info("Device Extensions : "+ DeviceExtensions.GetString(i));
        }

        // 	// Get Queue Families
        uint queueFamiliesCount = contextData->GraphicQueueIndex == contextData->PresentQueueIndex ? (uint)1 : (uint)2;

        VkDeviceQueueCreateInfo* queueCreateInfos = stackalloc VkDeviceQueueCreateInfo[(int)queueFamiliesCount];

        float queuePriority = 1.0f;
        uint index = 0;

        queueCreateInfos[index++] = new VkDeviceQueueCreateInfo
        {
            sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO,
            queueFamilyIndex = contextData->GraphicQueueIndex,
            queueCount = 1,
            pQueuePriorities = &queuePriority
        };

        if (contextData->PresentQueueIndex != contextData->GraphicQueueIndex)
        {
            queueCreateInfos[index++] = new VkDeviceQueueCreateInfo
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO,
                queueFamilyIndex = contextData->PresentQueueIndex,
                queueCount = 1,
                pQueuePriorities = &queuePriority
            };
        }

        // VkPhysicalDeviceFeatures deviceFeatures = new();
        // Create Device
        VkDeviceCreateInfo createInfo = new();
        createInfo.sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO;
        createInfo.queueCreateInfoCount = queueFamiliesCount;
        createInfo.pQueueCreateInfos = queueCreateInfos;
        createInfo.enabledExtensionCount = DeviceExtensions.Count;
        createInfo.ppEnabledExtensionNames = (byte**)DeviceExtensions.Pointer;
        createInfo.pNext = null;
        createInfo.pEnabledFeatures = null;
        createInfo.enabledLayerCount = contextData->EnableDebugMode ? ValidationLayers.Count : 0;
        createInfo.ppEnabledLayerNames = contextData->EnableDebugMode ? (byte**)ValidationLayers.Pointer : null;

        createInfo.flags = 0;

        result = Vk.vkCreateDevice(contextData->DevicePhysical, &createInfo, null, &contextData->Device);

        // if (Log.Check(result != VkResult.VK_SUCCESS, "Error Create Device" + result)) { return 1; }

        load = Loader.LoadDeviceFunc;
        Loader.Load(load, (void*)contextData->Device, &DeviceExtensions);

        Vk.vkGetDeviceQueue(contextData->Device, contextData->GraphicQueueIndex, 0, &contextData->GraphicQueue);
        // _ = Log.Check(contextData->GraphicQueue.IsNull, $"Graphic Queue : indice :{contextData->GraphicQueue.ToString()} ");

        Vk.vkGetDeviceQueue(contextData->Device, contextData->PresentQueueIndex, 0, &contextData->PresentQueue);
        // _ = Log.Check(contextData->PresentQueue.IsNull, $"Present Queue : indice :{contextData->PresentQueue.ToString()} ");

        ValidationLayers.Dispose();
        InstanceExtensions.Dispose();
        DeviceExtensions.Dispose();

        return 0;
    }

    internal static void CreateSwapChain(GraphicData* contextData,  WindowData* windowData) // + depth
    {
        // querySwapChainSupport
        VkSurfaceCapabilitiesKHR Capabilities = new();

        VkExtent2D SwapChainSurfaceSize = new();
        _ = Vk.vkGetPhysicalDeviceSurfaceCapabilitiesKHR(contextData->DevicePhysical, contextData->Surface, &Capabilities); 

        if (Capabilities.currentExtent.width != uint.MaxValue)
        {
            SwapChainSurfaceSize = Capabilities.currentExtent;
        }
        else
        {
            SwapChainSurfaceSize.width = Clamp((uint)windowData->Width, Capabilities.minImageExtent.width, Capabilities.maxImageExtent.width);
            SwapChainSurfaceSize.height = Clamp((uint)windowData->Height, Capabilities.minImageExtent.height, Capabilities.maxImageExtent.height);
        }

        var SwapChainImageCount = Capabilities.minImageCount + 1;

        if (Capabilities.maxImageCount > 0 && SwapChainImageCount > Capabilities.maxImageCount)
        {
            SwapChainImageCount = Capabilities.maxImageCount;
        }



        uint surfaceFormatCount = 0;
        Vk.vkGetPhysicalDeviceSurfaceFormatsKHR(contextData->DevicePhysical, contextData->Surface, &surfaceFormatCount, null);

        VkSurfaceFormatKHR* surfaceFormats = stackalloc VkSurfaceFormatKHR[(int)surfaceFormatCount];

        Vk.vkGetPhysicalDeviceSurfaceFormatsKHR(contextData->DevicePhysical, contextData->Surface, &surfaceFormatCount, surfaceFormats);

        VkSwapchainCreateInfoKHR* createInfo = stackalloc VkSwapchainCreateInfoKHR[1];

		bool isSharingMode = contextData->GraphicQueueIndex != contextData->PresentQueueIndex;
		createInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_SWAPCHAIN_CREATE_INFO_KHR;
        createInfo[0].pNext = null;
        createInfo[0].surface = contextData->Surface;
        createInfo[0].minImageCount = SwapChainImageCount;
        createInfo[0].imageFormat = VkFormat.VK_FORMAT_B8G8R8A8_SRGB;
        createInfo[0].imageColorSpace = VkColorSpaceKHR.VK_COLOR_SPACE_SRGB_NONLINEAR_KHR;
        createInfo[0].imageExtent = SwapChainSurfaceSize;
        createInfo[0].imageArrayLayers = 1;// no stereoscopi;
        createInfo[0].imageUsage = (uint)VkImageUsageFlagBits.VK_IMAGE_USAGE_COLOR_ATTACHMENT_BIT;
        createInfo[0].preTransform = Capabilities.currentTransform;
        createInfo[0].compositeAlpha = VkCompositeAlphaFlagBitsKHR.VK_COMPOSITE_ALPHA_OPAQUE_BIT_KHR;
        createInfo[0].presentMode = VkPresentModeKHR.VK_PRESENT_MODE_FIFO_KHR;
        createInfo[0].clipped = VK.VK_TRUE;
        createInfo[0].oldSwapchain = VkSwapchainKHR.Null;
		createInfo[0].imageSharingMode = isSharingMode ? VkSharingMode.VK_SHARING_MODE_CONCURRENT : VkSharingMode.VK_SHARING_MODE_EXCLUSIVE;
		createInfo[0].queueFamilyIndexCount = (uint)(isSharingMode ? 2 : 1);
        if (isSharingMode)
        {
            uint* queueFamilyIndices = stackalloc uint[2] { contextData->GraphicQueueIndex, contextData->PresentQueueIndex };
            createInfo[0].imageSharingMode = VkSharingMode.VK_SHARING_MODE_CONCURRENT;
        }

        //  Log.Info("Create SwaPchain" + contextData->Device + " : " + contextData->SwapChain +" : "+ createInfo[0].imageSharingMode +" : " +contextData->Surface + " : " + SwapChainImageCount);
        var result = Vk.vkCreateSwapchainKHR(contextData->Device, &createInfo[0], null, &contextData->SwapChain);

        // _ = Log.Check(result != VkResult.VK_SUCCESS, "SwapChain Creation :");

        uint SwapChainImageViewsCount = 0;
        Vk.vkGetSwapchainImagesKHR(contextData->Device, contextData->SwapChain, &SwapChainImageViewsCount, null);

        if (contextData->SwapChainImageViews == null)
            contextData->SwapChainImages = Memory.Memory.NewArray<VkImage>(SwapChainImageViewsCount );
            // contextData->SwapChainImages = (VkImage*)NativeMemory.Alloc(SwapChainImageViewsCount * (uint)Unsafe.SizeOf<VkImage>());

        result = Vk.vkGetSwapchainImagesKHR(contextData->Device, contextData->SwapChain, &SwapChainImageViewsCount, contextData->SwapChainImages);
        // _ = Log.Check(result != VkResult.VK_SUCCESS, $" SwapChain image  ");

        // SWWAP CHAIN IMAGES  VIEWS FOR FRAMEBUFFER ----------------------------------------------------------------------
        if (contextData->SwapChainImageViews == null)
            contextData->SwapChainImageViews = Memory.Memory.NewArray<VkImageView>(SwapChainImageCount);
            // contextData->SwapChainImageViews = (VkImageView*)NativeMemory.Alloc(SwapChainImageViewsCount * (uint)Unsafe.SizeOf<VkImageView>());

		VkImageViewCreateInfo* viewInfo = stackalloc VkImageViewCreateInfo[1];
        for (uint i = 0; i < SwapChainImageViewsCount; i++)
        {
            viewInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_IMAGE_VIEW_CREATE_INFO;
            viewInfo[0].pNext = null;
            viewInfo[0].image = contextData->SwapChainImages[i];
            viewInfo[0].viewType = VkImageViewType.VK_IMAGE_VIEW_TYPE_2D;
            viewInfo[0].format = VkFormat.VK_FORMAT_B8G8R8A8_SRGB;

            viewInfo[0].components.r = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY;
            viewInfo[0].components.g = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY;
            viewInfo[0].components.b = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY;
            viewInfo[0].components.a = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY;
            viewInfo[0].subresourceRange.aspectMask = (uint)VkImageAspectFlagBits.VK_IMAGE_ASPECT_COLOR_BIT;
            viewInfo[0].subresourceRange.baseMipLevel = 0;
            viewInfo[0].subresourceRange.levelCount = 1;
            viewInfo[0].subresourceRange.baseArrayLayer = 0;
            viewInfo[0].subresourceRange.layerCount = 1;

            result = Vk.vkCreateImageView(contextData->Device, &viewInfo[0], null, &contextData->SwapChainImageViews[i]);
            // _ = Log.Check(result != VkResult.VK_SUCCESS, $"Create image view :{contextData->SwapChainImageViews[i].ToString()} ");
        }

        contextData->SwapChainImageViewsCount = SwapChainImageViewsCount;
        contextData->SwapChainImageFormat = VkFormat.VK_FORMAT_B8G8R8A8_SRGB;

        contextData->RenderPassArea = Memory.Memory.NewArray<VkRect2D>(1);
        // contextData->RenderPassArea = (VkRect2D*)NativeMemory.Alloc(1 * (uint)Unsafe.SizeOf<VkRect2D>());
        contextData->RenderPassArea->extent = SwapChainSurfaceSize;
        contextData->RenderPassArea->offset.x = 0;
        contextData->RenderPassArea->offset.y = 0;
    }

    internal static void DisposeSwapChain(GraphicData* contextData)
    {
        if (contextData->Device.IsNotNull && contextData->Framebuffers != null)
		{
            for (int i = 0; i < contextData->SwapChainImageViewsCount; i++)
            {
                if (contextData->Framebuffers[i].IsNotNull) {
                    Vk.vkDestroyFramebuffer(contextData->Device, contextData->Framebuffers[i], null);
                }
            }
        }

        if (contextData->Device.IsNotNull && contextData->SwapChainImageViews != null)
        {
            for (uint i = 0; i < contextData->SwapChainImageViewsCount; i++) {
                Vk.vkDestroyImageView(contextData->Device, contextData->SwapChainImageViews[i], null);
            }
        }

        if (contextData->Device.IsNotNull && contextData->SwapChain.IsNotNull) {
            Vk.vkDestroySwapchainKHR(contextData->Device, contextData->SwapChain, null);
        }

    }

    internal static void DisposeDevice(GraphicData* contextData)
    {

        if (contextData->Device.IsNotNull) {
            Vk.vkDestroyDevice(contextData->Device, null);
        }

        if (contextData->Instance.IsNotNull && contextData->Surface.IsNotNull)  {
            Vk.vkDestroySurfaceKHR(contextData->Instance, contextData->Surface, null);
        }

        if (contextData->Instance.IsNotNull && contextData->DebugMessenger.IsNotNull)        {
            Vk.vkDestroyDebugUtilsMessengerEXT(contextData->Instance, contextData->DebugMessenger, null);
        }

        if (contextData->Instance.IsNotNull)        {
            Vk.vkDestroyInstance(contextData->Instance, null);
        }

    }

    internal static void Pause(GraphicData* contextData)
    {
        if (contextData->Device.IsNull) return;

        if (VkResult.VK_SUCCESS != Vk.vkDeviceWaitIdle(contextData->Device)){
            Log.Warning("PAuse Device Wait Idle");}
    }

    static VkPhysicalDevice IsSuitable(GraphicData* contextData, VkPhysicalDevice physical)
    {
        uint queueFamilyPropertyCount = 0;
        Vk.vkGetPhysicalDeviceQueueFamilyProperties(physical, &queueFamilyPropertyCount, null);

        VkQueueFamilyProperties* queueFamilyProperties2 = stackalloc VkQueueFamilyProperties[(int)queueFamilyPropertyCount];

        Vk.vkGetPhysicalDeviceQueueFamilyProperties(physical, &queueFamilyPropertyCount, queueFamilyProperties2);

        for (uint i = 0; i < queueFamilyPropertyCount; i++)
        {

            var queue = queueFamilyProperties2[i];
            Log.Info("Queue Familly property : " + queue.queueFlags.ToString());

            if ((queue.queueFlags & (uint)VkQueueFlagBits.VK_QUEUE_GRAPHICS_BIT) != 0)
            {
                contextData->GraphicQueueIndex = i;

                uint presentSupport = VK.VK_FALSE;
                _ = Vk.vkGetPhysicalDeviceSurfaceSupportKHR(physical, i, contextData->Surface, &presentSupport);
                Log.Info("presentSupport : " + presentSupport);

                if (presentSupport == VK.VK_TRUE)
                {
                    contextData->PresentQueueIndex = i;
                }

                if (contextData->GraphicQueueIndex != uint.MaxValue && contextData->PresentQueueIndex != uint.MaxValue)
                {
                    break;
                }
            }

        }
        // Log.Info("Is Suitable");
        //  bool extensionsSupported = checkDeviceExtensionSupport(device);
        // SwapChainSupportDetails querySwapChainSupport(VkPhysicalDevice device)

        return (contextData->GraphicQueueIndex == uint.MaxValue && contextData->PresentQueueIndex == uint.MaxValue) ? VkPhysicalDevice.Null : physical;
    }

    [UnmanagedCallersOnly]
    static uint DebugMessengerCallback(VkDebugUtilsMessageSeverityFlagBitsEXT messageSeverity,
        VkDebugUtilsMessageTypeFlagBitsEXT messageTypes,
        VkDebugUtilsMessengerCallbackDataEXT* pCallbackData, void* pUserData)
    {
		const int MaxCaracterInLine = 512;
        string Header = messageSeverity == VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT ?
            "ERROR" : messageSeverity == VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT ?
            	"WARNING" :  "INFO";
        string message = string.Empty;

        int position = 0;
        char c = (char)pCallbackData->pMessage[position++];

        while (c != '\0' && position <= MaxCaracterInLine)
        {
            message += c;
            c = (char)pCallbackData->pMessage[position++];
        }
        Log.Display(Header, message);
        return VK.VK_FALSE;
    }

    internal static uint ToUint(uint major, uint minor, uint patch) => (major << 22) | (minor << 12) | patch;
    internal static uint Clamp(uint value, uint min, uint max) => value < min ? min : value > max ? max : value;

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