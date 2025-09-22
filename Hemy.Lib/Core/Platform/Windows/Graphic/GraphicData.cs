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
    internal VkCommandBuffer CurrentCommandBuffer = VkCommandBuffer.Null;
    internal delegate* unmanaged<void> RenderPipeline = (delegate* unmanaged<void>)Marshal.GetFunctionPointerForDelegate(GraphicRenderImpl.EmptyDrawPipeline);
}

#endif