#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.IO;


using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal unsafe struct IoFileData()
{
	internal void* Handle = null;
	internal long Size = 0;
	internal nuint Mode = 0; //0 = close , 1 = open  2 openread , 3 =open write
							 // Filename 
}

#endif