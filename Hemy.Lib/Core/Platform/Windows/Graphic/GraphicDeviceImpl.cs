#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Graphic;

using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Hemy.Lib.Core.Platform.Vulkan;
using Hemy.Lib.Core.Platform.Windows.Window;


// 
// 		"INSTANCE",
// 		"PHYSICAL_DEVICE",
// 		"DEVICE",
// 		"QUEUE",
// 		"SEMAPHORE",
// 		"COMMAND_BUFFER",
// 		"FENCE",
// 		"DEVICE_MEMORY",
// 		"BUFFER",
// 		"IMAGE",
// 		"EVENT",
// 		"QUERY_POOL",
// 		"BUFFER_VIEW",
// 		"IMAGE_VIEW",
// 		"SHADER_MODULE",
// 		"PIPELINE_CACHE",
// 		"PIPELINE_LAYOUT",
// 		"RENDER_PASS",
// 		"PIPELINE",
// 		"DESCRIPTOR_SET_LAYOUT",
// 		"SAMPLER",
// 		"DESCRIPTOR_POOL",
// 		"DESCRIPTOR_SET",
// 		"FRAMEBUFFER",
// 		"COMMAND_POOL",
// 		"DESCRIPTOR_UPDATE_TEMPLATE_KHR",
// 		"SURFACE_KHR",
// 		"SWAPCHAIN_KHR",
// 		"DEBUG_UTILS_MESSENGER_EXT",
// 		"DEBUG_REPORT_CALLBACK_EXT",
// 		"ACCELERATION_STRUCTURE",
// 		"VMA_BUFFER_OR_IMAGE" };

[SkipLocalsInit] 
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class GraphicDeviceImpl
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

        GraphicRenderImpl.DisposeRender(contextData);

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

        // if (contextData->Instance.IsNotNull)        {
        //     Vk.vkDestroyInstance(contextData->Instance, null);
        // }

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

#endif