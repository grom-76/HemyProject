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
internal static partial class Storage
{
	internal static string RootPath
#if WINDOWS
	=> System.AppDomain.CurrentDomain.BaseDirectory;
#endif
	internal static unsafe string DriveLetter
#if WINDOWS
		=> "c:";
#endif
	internal static long AvailableFreeSpace
#if WINDOWS
	=> IoImpl.AvailableFreeSpace();
#endif
	internal static long TotalFreeSpace
#if WINDOWS
	=> IoImpl.TotalFreeSpace();
#endif
	internal static unsafe string VolumeLabel
#if WINDOWS
	=> IoImpl.VolumeLabel();
#endif
}


