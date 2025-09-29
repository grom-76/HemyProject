namespace Hemy.Lib.V2.Core;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#if WINDOWS
#endif


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public static class Time
{
	public const ulong MiliSecond_Per_Second = 1000UL;

	[SkipLocalsInit]
	public static ulong GetTicks => Platform.Windows.WindowsSystem.GetTick();

	public static ulong Frequency = Platform.Windows.WindowsSystem.GetFrequency();

	public sealed class TimeSettings(ConntextSettings ctx) : IDisposable
	{
		internal ulong FixedTimeStepIn_milisec = 0;

		public TimeSettings SetBuffer(int doubleBuffered)
		{
			// ctx.Resolution = (uint)x;
			return this;
		}

		public ConntextSettings Build() { return ctx; }

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}

}
