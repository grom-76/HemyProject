#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Graphic;

using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Hemy.Lib.Core.Platform.Vulkan;
using Hemy.Lib.Core.Platform.Windows.Window;


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


[SkipLocalsInit] // TODO: pourquoi skiplocaalinit a un fonctionnement eratique dans graphics device
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class MeshImpl
{




}

#endif
