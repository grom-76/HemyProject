namespace Hemy.Lib.Core.IO;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;


#if WINDOWS
using Hemy.Lib.Core.Platform.Windows.IO;
#endif

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static partial class Directories
{
	internal static void Create(string directory)
#if WINDOWS
		=> IoImpl.CreateDirectory(directory);
#endif

	internal static void Delete(string directory)
#if WINDOWS
		=> IoImpl.DeleteDirectory(directory);
#endif
	internal static bool Exist(string directory)
#if WINDOWS
		=> IoImpl.DirectoryExist(directory);
#endif
	internal static string[] GetDirectories(string patternmatching = "")
#if WINDOWS
		=> IoImpl.GetDirectories(patternmatching);
#endif
}


