#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Graphic;

using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Hemy.Lib.Core.Platform.Vulkan;
using Hemy.Lib.Core.Platform.Windows.Window;

// using HE2.Tools.Shaders.ShaderCompiler;

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
}


// [SkipLocalsInit]
// TODO: pourquoi skiplocaalinit a un fonctionnement eratique dans graphics device
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class GraphicImpl
{
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

        DisposeRender(contextData);

        DisposeDevice(contextData);

        
        Memory.Memory.DisposeArray(contextData->InFlightFences);
        Memory.Memory.DisposeArray(contextData->ImageAvailableSemaphores);
        Memory.Memory.DisposeArray(contextData->RenderFinishedSemaphores);
        Memory.Memory.DisposeArray(contextData->CommandBuffers);
        Memory.Memory.DisposeArray(contextData->RenderPassClearValues);
        Memory.Memory.DisposeArray(contextData->RenderPassArea);
        // NativeMemory.Free(contextData->InFlightFences);
        // NativeMemory.Free(contextData->ImageAvailableSemaphores);
        // NativeMemory.Free(contextData->RenderFinishedSemaphores);
        // NativeMemory.Free(contextData->CommandBuffers);
        // NativeMemory.Free(contextData->RenderPassClearValues);
        // NativeMemory.Free(contextData->RenderPassArea);
        NativeMemory.Free(contextData->SwapChainImageViews);
        NativeMemory.Free(contextData->SwapChainImages);
        NativeMemory.Free(contextData->Framebuffers);
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

        Hemy.Lib.Core.Memory.Array ValidationLayers = new(layerCount, VK.VK_MAX_DESCRIPTION_SIZE);

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

        Hemy.Lib.Core.Memory.Array InstanceExtensions = new(instanceExtCount, VK.VK_MAX_DESCRIPTION_SIZE);

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

        Hemy.Lib.Core.Memory.Array DeviceExtensions = new(devicePropertiesExtCount, VK.VK_MAX_DESCRIPTION_SIZE);

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
        Vk.vkGetPhysicalDeviceSurfaceCapabilitiesKHR(contextData->DevicePhysical, contextData->Surface, &Capabilities); //;//;//.Check("vkGetPhysicalDeviceSurfaceCapabilitiesKHR");

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

        // contextData->SwapChainTransform = Capabilities.currentTransform;

        uint surfaceFormatCount = 0;
        Vk.vkGetPhysicalDeviceSurfaceFormatsKHR(contextData->DevicePhysical, contextData->Surface, &surfaceFormatCount, null);

        VkSurfaceFormatKHR* surfaceFormats = stackalloc VkSurfaceFormatKHR[(int)surfaceFormatCount];

        Vk.vkGetPhysicalDeviceSurfaceFormatsKHR(contextData->DevicePhysical, contextData->Surface, &surfaceFormatCount, surfaceFormats);

        VkSwapchainCreateInfoKHR* createInfo = stackalloc VkSwapchainCreateInfoKHR[1];

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

        if (contextData->GraphicQueueIndex != contextData->PresentQueueIndex)
        {
            uint* queueFamilyIndices = stackalloc uint[2] { contextData->GraphicQueueIndex, contextData->PresentQueueIndex };
            createInfo[0].imageSharingMode = VkSharingMode.VK_SHARING_MODE_CONCURRENT;
            createInfo[0].queueFamilyIndexCount = 2;
            createInfo[0].pQueueFamilyIndices = queueFamilyIndices;
        }
        else
        {
            createInfo[0].imageSharingMode = VkSharingMode.VK_SHARING_MODE_EXCLUSIVE;
        }
        //  Log.Info("Create SwaPchain" + contextData->Device + " : " + contextData->SwapChain +" : "+ createInfo[0].imageSharingMode +" : " +contextData->Surface + " : " + SwapChainImageCount);
        var result = Vk.vkCreateSwapchainKHR(contextData->Device, &createInfo[0], null, &contextData->SwapChain);

        // _ = Log.Check(result != VkResult.VK_SUCCESS, "SwapChain Creation :");

        uint SwapChainImageViewsCount = 0;
        Vk.vkGetSwapchainImagesKHR(contextData->Device, contextData->SwapChain, &SwapChainImageViewsCount, null);

        if (contextData->SwapChainImageViews == null)
            contextData->SwapChainImages = (VkImage*)NativeMemory.Alloc(SwapChainImageViewsCount * (uint)Unsafe.SizeOf<VkImage>());

        result = Vk.vkGetSwapchainImagesKHR(contextData->Device, contextData->SwapChain, &SwapChainImageViewsCount, contextData->SwapChainImages);
        // _ = Log.Check(result != VkResult.VK_SUCCESS, $" SwapChain image  ");

        // SWWAP CHAIN IMAGES  VIEWS FOR FRAMEBUFFER ----------------------------------------------------------------------
        // if (contextData->SwapChainImageViews == null)
        contextData->SwapChainImageViews = (VkImageView*)NativeMemory.Alloc(SwapChainImageViewsCount * (uint)Unsafe.SizeOf<VkImageView>());

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
                if (contextData->Framebuffers[i].IsNotNull)
                {
                    Vk.vkDestroyFramebuffer(contextData->Device, contextData->Framebuffers[i], null);
                }
            }
        }

        if (contextData->Device.IsNotNull && contextData->SwapChainImageViews != null)
        {
            for (uint i = 0; i < contextData->SwapChainImageViewsCount; i++)
            {
                Vk.vkDestroyImageView(contextData->Device, contextData->SwapChainImageViews[i], null);
            }
        }

        if (!contextData->Device.IsNull && !contextData->SwapChain.IsNull)
        {
            Vk.vkDestroySwapchainKHR(contextData->Device, contextData->SwapChain, null);
        }

    }

    internal static void DisposeDevice(GraphicData* contextData)
    {

        if (contextData->Device.IsNotNull)
        {
            Vk.vkDestroyDevice(contextData->Device, null);
        }

        if (contextData->Instance.IsNotNull && contextData->Surface.IsNotNull)
        {
            Vk.vkDestroySurfaceKHR(contextData->Instance, contextData->Surface, null);
        }

        if (contextData->Instance.IsNotNull && contextData->DebugMessenger.IsNotNull)
        {
            Vk.vkDestroyDebugUtilsMessengerEXT(contextData->Instance, contextData->DebugMessenger, null);
        }

        if (contextData->Instance.IsNotNull)
        {
            Vk.vkDestroyInstance(contextData->Instance, null);
        }

    }

    internal static void Pause(GraphicData* contextData)
    {
        if (contextData->Device.IsNull) return;

        _ = Vk.vkDeviceWaitIdle(contextData->Device);
        // _ = Log.Check(Vk.vkDeviceWaitIdle(contextData->Device) != VkResult.VK_SUCCESS, $"PAuse Device Wait Idle  Failed ");
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

        string Header = messageSeverity == VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT ?
            "ERROR" : messageSeverity == VkDebugUtilsMessageSeverityFlagBitsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT ?
            "WARNING" :
            "INFO";
        string message = string.Empty;

        int position = 0;
        char c = (char)pCallbackData->pMessage[position++];

        while (c != '\0' && position <= 512)
        {
            message += c;
            c = (char)pCallbackData->pMessage[position++];
        }
        Log.Display(Header, message);
        return VK.VK_FALSE;
    }

    internal static uint ToUint(uint major, uint minor, uint patch) => (major << 22) | (minor << 12) | patch;
    internal static uint Clamp(uint value, uint min, uint max) => value < min ? min : value > max ? max : value;

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

    // internal static void CreateShader(GraphicData* contextData)
    // {
    //     string vertexfilename = @"C:\Users\Admin\Documents\ProjectHE2\Assets\Shader_Base.vert";

    //     string vertexSource = File.ReadAllText(vertexfilename);

    //     using var compiler = new Compiler();

    //     compiler.Options.ShaderStage = ShaderKind.VertexShader;
    //     compiler.Options.EntryPoint = "main";
    //     compiler.Options.SourceLanguage = SourceLanguage.GLSL;
    //     compiler.Options.TargetEnv = TargetEnvironmentVersion.Vulkan_1_0;
    //     compiler.Options.TargetSpv = SpirVVersion.Version_1_0;

    //     CompileResult result = compiler.Compile(vertexSource, vertexfilename);

    //     VkShaderModuleCreateInfo* createInfoFrag = stackalloc VkShaderModuleCreateInfo[1];
    //     createInfoFrag[0].sType = VkStructureType.VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO;
    //     createInfoFrag[0].codeSize = result.BytesSize;
    //     createInfoFrag[0].pNext = null;
    //     createInfoFrag[0].flags = 0;
    //     createInfoFrag[0].pCode = (uint*)result.Bytes;

    //     VkShaderModule ShaderModule = VkShaderModule.Null;

    //     var error = Vk.vkCreateShaderModule(contextData->Device, &createInfoFrag[0], null, &ShaderModule);

    //     _ = Log.Check(error != VkResult.VK_SUCCESS, $"could not create vertex shader module : {error} ");

    //     byte* entryPt = WindowsMemory.New("main");

    //     VkPipelineShaderStageCreateInfo* shaderStages = stackalloc VkPipelineShaderStageCreateInfo[1];

    //     shaderStages[0].sType = VkStructureType.VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO;
    //     shaderStages[0].stage = VkShaderStageFlagBits.VK_SHADER_STAGE_FRAGMENT_BIT;
    //     shaderStages[0].module = ShaderModule;
    //     shaderStages[0].pName = entryPt;
    //     shaderStages[0].flags = 0;
    //     shaderStages[0].pNext = null;
    //     shaderStages[0].pSpecializationInfo = null;

    //     WindowsMemory.Dispose(entryPt);
    // }

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

    internal static void ChangeBackGroundColor(GraphicData* contextData)
    {
        var cl = PaletteToFloatRGBA(4284782061u); // TODO : be careful with color RGBA ARGBA ( 16 or 32bit ) see ColorFormat in GraphicDevice
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

        ChangeBackGroundColor(contextData);

        // COLOR 
        VkAttachmentDescription* colorAttachment = stackalloc VkAttachmentDescription[1];

        colorAttachment[0].format = contextData->SwapChainImageFormat;
        colorAttachment[0].samples = VkSampleCountFlagBits.VK_SAMPLE_COUNT_1_BIT;
        colorAttachment[0].loadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_CLEAR;
        colorAttachment[0].storeOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_STORE;
        colorAttachment[0].stencilLoadOp = VkAttachmentLoadOp.VK_ATTACHMENT_LOAD_OP_DONT_CARE;
        colorAttachment[0].stencilStoreOp = VkAttachmentStoreOp.VK_ATTACHMENT_STORE_OP_DONT_CARE;
        colorAttachment[0].initialLayout = VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED;// TODO when depth buffer
        colorAttachment[0].finalLayout = VkImageLayout.VK_IMAGE_LAYOUT_PRESENT_SRC_KHR;// VkImageLayout.VK_IMAGE_LAYOUT_PRESENT_SRC_KHR
        // colorAttachment.flags = (uint)VkAttachmentDescriptionFlagBits.VK_ATTACHMENT_DESCRIPTION_MAY_ALIAS_BIT;

        // SUBPASS  -> COLOR POST PROCESSING       
        VkAttachmentReference* colorAttachmentRef = stackalloc VkAttachmentReference[1];

        colorAttachmentRef[0].attachment = 0;
        colorAttachmentRef[0].layout = VkImageLayout.VK_IMAGE_LAYOUT_COLOR_ATTACHMENT_OPTIMAL;

        // SUBPASS
        VkSubpassDescription* subpass = stackalloc VkSubpassDescription[1];

        subpass[0].pipelineBindPoint = VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS;
        subpass[0].colorAttachmentCount = 1;
        subpass[0].pColorAttachments = &colorAttachmentRef[0];
        // subpass[0].pDepthStencilAttachment = &depthAttachmentRef,
        // subpass[0].flags = 0,
        // subpass[0].inputAttachmentCount = 0,
        // subpass[0].pInputAttachments = null,
        // subpass[0].pPreserveAttachments = null,
        // subpass[0].preserveAttachmentCount = 0

        VkSubpassDependency* dependency = stackalloc VkSubpassDependency[1];

        dependency[0].srcSubpass = VK.VK_SUBPASS_EXTERNAL;
        dependency[0].dstSubpass = 0;
        dependency[0].srcStageMask = (uint)VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT;//| (uint)VkPipelineStageFlagBits.VK_PIPELINE_STAGE_EARLY_FRAGMENT_TESTS_BIT,
        dependency[0].srcAccessMask = 0;//(uint)VkAccessFlagBits.VK_ACCESS_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT,
        dependency[0].dstStageMask = (uint)VkPipelineStageFlagBits.VK_PIPELINE_STAGE_COLOR_ATTACHMENT_OUTPUT_BIT;//| (uint)VkPipelineStageFlagBits.VK_PIPELINE_STAGE_LATE_FRAGMENT_TESTS_BIT,
        dependency[0].dstAccessMask = (uint)VkAccessFlagBits.VK_ACCESS_COLOR_ATTACHMENT_WRITE_BIT;// | (uint)VkAccessFlagBits.VK_ACCESS_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT,
        dependency[0].dependencyFlags = 0;


        VkRenderPassCreateInfo* renderPassInfo = stackalloc VkRenderPassCreateInfo[1];

        renderPassInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO;
        // renderPassInfo[0].attachmentCount = 2;
        // renderPassInfo[0].pAttachments = attachmentsDesc;
        renderPassInfo[0].attachmentCount = 1;
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
            contextData->Framebuffers = (VkFramebuffer*)NativeMemory.Alloc(contextData->SwapChainImageViewsCount * (uint)Unsafe.SizeOf<VkFramebuffer>());

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

            result = Vk.vkCreateFramebuffer(contextData->Device, &framebufferInfo[0], null, &contextData->Framebuffers[i]);//;//.Check("failed to create framebuffer!"); 

            if (VkResult.VK_SUCCESS != result) {
                Log.Error($"-{i} Create FrameBuffer {contextData->Framebuffers[i]}"); }
        }
    }

    internal static void DisposeFrameBuffer(GraphicData* contextData)
    {

    }

    internal static void CreateRender(GraphicData* contextData) // + renderpass   + syncobj + command
    {
        VkResult result;

        if (contextData->ImageAvailableSemaphores == null)
        // contextData->ImageAvailableSemaphores = (VkSemaphore*)NativeMemory.Alloc(contextData->MaxFrameInFlight * (uint)Unsafe.SizeOf<VkSemaphore>());
            contextData->ImageAvailableSemaphores = Memory.Memory.NewArray<VkSemaphore> (contextData->MaxFrameInFlight );
        //TODO : change NAtiveMEmor

        if (contextData->RenderFinishedSemaphores == null)
        // contextData->RenderFinishedSemaphores = (VkSemaphore*)NativeMemory.Alloc(contextData->MaxFrameInFlight * (uint)Unsafe.SizeOf<VkSemaphore>());
            contextData->RenderFinishedSemaphores = Memory.Memory.NewArray<VkSemaphore> (contextData->MaxFrameInFlight );

        VkSemaphoreCreateInfo* semaphoreInfo = stackalloc VkSemaphoreCreateInfo[1];
        semaphoreInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_SEMAPHORE_CREATE_INFO;
        semaphoreInfo[0].flags = 0;
        semaphoreInfo[0].pNext = null;

        for (uint i = 0; i < contextData->MaxFrameInFlight; i++)
        {
            result = Vk.vkCreateSemaphore(contextData->Device, &semaphoreInfo[0], null, &contextData->ImageAvailableSemaphores[i]);//;//.Check("Failed to create Semaphore ImageAvailableSemaphore");

            // _ = Log.Check(result != VkResult.VK_SUCCESS, $"-{i}  Create Image Semaphore Available : {contextData->ImageAvailableSemaphores[i]}");

            result = Vk.vkCreateSemaphore(contextData->Device, &semaphoreInfo[0], null, &contextData->RenderFinishedSemaphores[i]);//;//.Check("Failed to create Semaphore ImageAvailableSemaphore");

            // _ = Log.Check(result != VkResult.VK_SUCCESS, $"-{i}  Create Render Semaphore Available : {contextData->RenderFinishedSemaphores[i]}");

        }

        if (contextData->InFlightFences == null)
            // contextData->InFlightFences = (VkFence*)NativeMemory.Alloc(contextData->MaxFrameInFlight * (uint)Unsafe.SizeOf<VkFence>());
            contextData->InFlightFences =  Memory.Memory.NewArray<VkFence>(contextData->MaxFrameInFlight );

        VkFenceCreateInfo* fenceInfo = stackalloc VkFenceCreateInfo[1];
        fenceInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_FENCE_CREATE_INFO;
        fenceInfo[0].flags = (uint)VkFenceCreateFlagBits.VK_FENCE_CREATE_SIGNALED_BIT;

        for (uint i = 0; i < contextData->MaxFrameInFlight; i++)
        {
            result = Vk.vkCreateFence(contextData->Device, &fenceInfo[0], null, &contextData->InFlightFences[i]);//;//.Check("Failed to create Fence InFlightFence");

            // _ = Log.Check(result != VkResult.VK_SUCCESS, $"-{i}  Create Fence  : {contextData->InFlightFences[i]}");
        }

        VkCommandPoolCreateInfo* poolInfoCompute = stackalloc VkCommandPoolCreateInfo[1];
        poolInfoCompute[0].sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO;
        poolInfoCompute[0].flags = (uint)VkCommandPoolCreateFlagBits.VK_COMMAND_POOL_CREATE_RESET_COMMAND_BUFFER_BIT;
        poolInfoCompute[0].queueFamilyIndex = contextData->GraphicQueueIndex;

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
        VkCommandBuffer* currentCommandBuffer = stackalloc VkCommandBuffer[1] { contextData->CommandBuffers[currentFrame] };

        VkResult result = Vk.vkWaitForFences(contextData->Device, 1, &CurrentinFlightFence, /*VK_TRUE*/1, contextData->Ticktimeout);//;//.Check("Acquire Image");
        result = Vk.vkResetFences(contextData->Device, 1, &CurrentinFlightFence);
        //now that we are sure that the commands finished executing, we can safely reset the command buffer to begin recording again.
        result = Vk.vkResetCommandBuffer(*currentCommandBuffer, (uint)VkCommandBufferResetFlagBits.VK_COMMAND_BUFFER_RESET_RELEASE_RESOURCES_BIT);
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

        RecordCommandBuffer(contextData, *currentCommandBuffer, CurrentImageIndex);

        VkSubmitInfo* submitInfo = stackalloc VkSubmitInfo[1];
        submitInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_SUBMIT_INFO;
        submitInfo[0].waitSemaphoreCount = 1;
        submitInfo[0].pWaitSemaphores = waitSemaphores;
        submitInfo[0].pWaitDstStageMask = waitStages;
        submitInfo[0].commandBufferCount = 1;
        submitInfo[0].pCommandBuffers = currentCommandBuffer;
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

    static void RecordCommandBuffer(GraphicData* contextData, VkCommandBuffer currentCommandBuffer, uint currentImageIndex)
    {
        int renderPasses = 1;
        VkCommandBufferBeginInfo* beginInfo = stackalloc VkCommandBufferBeginInfo[1];
        beginInfo[0].sType = VkStructureType.VK_STRUCTURE_TYPE_COMMAND_BUFFER_BEGIN_INFO;
        beginInfo[0].pNext = null;
        beginInfo[0].flags = (uint)VkCommandBufferUsageFlagBits.VK_COMMAND_BUFFER_USAGE_ONE_TIME_SUBMIT_BIT;
        beginInfo[0].pInheritanceInfo = null;

        var result = Vk.vkBeginCommandBuffer(currentCommandBuffer, &beginInfo[0]);

        //     // FOREACH RENDER PASS 
        VkRenderPassBeginInfo* renderPassInfo = stackalloc VkRenderPassBeginInfo[renderPasses];
        int i = 0;
        // for (int i = 0; i < renderPasses; i++)
        // {
        renderPassInfo[i].sType = VkStructureType.VK_STRUCTURE_TYPE_RENDER_PASS_BEGIN_INFO;
        renderPassInfo[i].pNext = null;
        renderPassInfo[i].renderArea = *contextData->RenderPassArea;
        renderPassInfo[i].renderPass = contextData->RenderPass;
        renderPassInfo[i].framebuffer = contextData->Framebuffers[currentImageIndex];
        renderPassInfo[i].clearValueCount = 1;/* contextData->IsUseDepthBuffer ? (uint)2 : (uint)1;*/
        renderPassInfo[i].pClearValues = contextData->RenderPassClearValues;

        Vk.vkCmdBeginRenderPass(currentCommandBuffer, &renderPassInfo[i], VkSubpassContents.VK_SUBPASS_CONTENTS_INLINE);
        // Vk.vkCmdBeginRenderPass2(currentCommandBuffer, &renderPassInfo[i], null);

        DrawPipeline(contextData);

        Vk.vkCmdEndRenderPass(currentCommandBuffer);
        // } // END FOREACH RENDER PASS 

        result = Vk.vkEndCommandBuffer(currentCommandBuffer);
    }

    static void DrawPipeline(GraphicData* contextData)
    {
        // if (renderData->State == 0) return;

        // PUSH CONSTANTS ---------- ( do before bin pipeline)
        // fixed(void* ptr = &data->Selected ) 
        // {
        //     Vk.vkCmdPushConstants(data->CurrentCommandBuffer, data->PipelineLayout, 
        //         (uint) VkShaderStageFlagBits.VK_SHADER_STAGE_VERTEX_BIT, 0,PushConstantsBool.SizeInBytes, ptr );
        // }

        // SEND DATA To SHADER UNIFORM
        // fixed ( VkDescriptorSet* desc = &data->ShaderDescribe_DescriptorSets[data->CurrentFrame])
        // {
        //     Vk.vkCmdBindDescriptorSets(data->CurrentCommandBuffer, VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS,data->PipelineLayout, 0, 1, desc, 0, null);
        // }

        // USE SHADER  ENABLE
        // Vk.vkCmdBindPipeline(graphicData->CurrentCommandBuffer, VkPipelineBindPoint.VK_PIPELINE_BIND_POINT_GRAPHICS, renderData-> Pipeline);

        // SET DYNAMIC STATES
        // renderData->DynamicState-> DynamicStates_Viewport.x = 0.0f;
        // renderData->DynamicState-> DynamicStates_Viewport.y = 0.0f;
        // renderData->DynamicState-> DynamicStates_Viewport.width =  graphicData->SwapChainSurfaceSize.width;
        // renderData->DynamicState-> DynamicStates_Viewport.height =  graphicData->SwapChainSurfaceSize.height;
        // renderData->DynamicState-> DynamicStates_Viewport.minDepth = 0.0f;
        // renderData->DynamicState-> DynamicStates_Viewport.maxDepth = 1.0f;
        // Vk.vkCmdSetViewport(graphicData->CurrentCommandBuffer, 0, 1, &renderData->DynamicState->DynamicStates_Viewport );

        // renderData->DynamicState-> DynamicStates_Scissor.offset = new() {x=0, y=0};
        // renderData->DynamicState-> DynamicStates_Scissor.extent = graphicData->SwapChainSurfaceSize;
        // Vk.vkCmdSetScissor(graphicData->CurrentCommandBuffer, 0, 1, &renderData->DynamicState->DynamicStates_Scissor);

        // Vk.vkCmdSetLineWidth( _perFrame.CurrentCommandBuffer,data.Handles.DynamicStatee_LineWidth);

        // BIND VERTEX AND INDICES
        // VkDeviceSize* offsets = stackalloc VkDeviceSize[]{0};
        // VkBuffer* vertexBuffers = stackalloc VkBuffer[] { settings.VertexBuffer};
        // Vk.vkCmdBindVertexBuffers(graphicData->CurrentCommandBuffer, 0, 1, vertexBuffers, offsets);
        // Vk.vkCmdBindIndexBuffer(graphicData->CurrentCommandBuffer, settings.IndicesBuffer, 0, VkIndexType.VK_INDEX_TYPE_UINT16);
        // Vk.vkCmdDrawIndaexed(graphicData->CurrentCommandBuffer, renderData.IndicesSize, 1, 0, 0, 0);

        // Vk.vkCmdDraw(graphicData->CurrentCommandBuffer, renderData->VertexData->VertexCount, renderData->VertexData->InstanceCount, 0, 0);
    }

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