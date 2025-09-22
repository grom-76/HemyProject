#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Graphic;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Hemy.Lib.Core.Graphic;
using Hemy.Lib.Core.Platform.Vulkan;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct GraphicDeviceSettings()
{

	internal static void Binding(GraphicDeviceSettings* windowSettings, Hemy.Lib.Core.Graphic.GraphicDeviceSettings settings)
	{
		
	}
}

#endif