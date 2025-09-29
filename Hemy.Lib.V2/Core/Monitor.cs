namespace Hemy.Lib.V2.Core;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#if WINDOWS
#endif

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public static class Monitor
{
	public enum Orientation
	{
		Vertical, Horizontal, Landscape
	}

}
