namespace Hemy.Lib.V2.Platform.Windows;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

using const_char = System.Byte;
using BOOL = System.Int32;

// https://learn.microsoft.com/en-us/windows/win32/winprog/windows-data-types
using size_t = System.UIntPtr;
using uint32_t = System.UInt32;
using uint64_t = System.UInt64;
using uint8_t = System.Byte;
using int32_t = System.Int32;
using int64_t = System.Int64;
using uint16_t = System.UInt16;

using VkBool32 = System.UInt32;
using VkDeviceAddress = System.UInt64;
using VkDeviceSize = System.UInt64;
using Flag = System.Int32;

using HRESULT = System.Int32;

using static Hemy.Lib.V2.Platform.Windows.WindowsGraphicCommon;
using static Hemy.Lib.V2.Platform.Windows.WindowsWindowCommon;
using Hemy.Lib.V2.Core;



[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal unsafe struct WindowsData() // = Settings +Data + Infos  
{

	internal uint State = 0;
	internal uint Error = 0;

	//WINDOW
	internal Hwnd* WindowHandle = null;
	internal fixed byte GameName[256];
	internal fixed byte EngineName[16];
	internal fixed byte LogoIcon[32];
	internal Hwnd* HInstance = null;
	internal uint Style = 0;
	internal int Width = 1280;
	internal int Height = 720;

	//GRAPHIC
	internal VkInstance* VkInstance = null;
	internal VkSurfaceKHR* VkSurface = null;
	internal VkDebugUtilsMessengerEXT* VkDebugUtilsMessenger = null;

#if DEBUG
	internal bool EnableDebugMode = true;
#else
	internal bool EnableDebugMode = false;
#endif
	internal WindowsStrArray* ValidationLayers = null;
	internal WindowsStrArray* InstanceExtensions = null;
	internal WindowsStrArray* DeviceExtensions = null;

	internal ulong VkEnxtensions = 0UL;
	internal VkPhysicalDevice* PhysicalDevice = null;

	internal uint GraphicQueueIndex = uint.MaxValue;
	internal uint PresentQueueIndex = uint.MaxValue;
	internal VkDevice* VkDevice = null;
	internal VkQueue* GraphicQueue = null;
	internal VkQueue* PresentQueue = null;
	// AUDIO
	internal nint AudioModule = 0;



}

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal unsafe struct WindowsGraphicPipelineData()
{
	// Materials  : shader , texture
	// Vertices
	// FixedFunction Dynamic states
	// RenderPAss ?
	//Camera? 

}

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal unsafe struct WindowsAudioPipelineData()
{
	// Materials  : shader , texture
	// Vertices
	// FixedFunction Dynamic states
	// RenderPAss ?
}

