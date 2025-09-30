namespace Hemy.Lib.V2.Graphics;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Hemy.Lib.V2.Core;

#if WINDOWS
#endif


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public static class Graphic
{
	public interface IGraphicDevice
	{

	}

	public interface IGraphicRender
	{
		void Draw();
	}

	public sealed class GraphicSettings(ConntextSettings ctx): IDisposable
	{
		internal string Title = "";

		public GraphicSettings SetBuffer(int doubleBuffered)
		{
			// ctx.Resolution = (uint)x;
			var memPtr = (nint)Marshal.AllocHGlobal(1024);
			return this;
		}
		
		public ConntextSettings Build(){ return ctx; }

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
	}
}
