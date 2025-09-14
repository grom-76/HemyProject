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
internal static partial class Files
{
	internal static void Create(string file)
#if WINDOWS
		=> IoImpl.CreateFile(file);
#endif
	internal static void Delete(string file)
#if WINDOWS
		=> IoImpl.DeleteFile(file);
#endif
	internal static bool Exist(string file)
#if WINDOWS
		=> IoImpl.FileExist(file);
#endif
	internal static string[] GetFiles(string patternmatching = "")
#if WINDOWS
		=> IoImpl.GetFiles(patternmatching);
#endif
}


