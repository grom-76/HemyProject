namespace Hemy.Lib.Core.Graphic;

using System;

public unsafe sealed class GraphicDeviceSettings : IDisposable
{
    public BufferMode BufferMode = BufferMode.DoubleBuffering;
    public PreferredColorFormat preferredColorFormat = PreferredColorFormat.sRGB;
    public PreferredVsync PreferredVsync = PreferredVsync.Activate;
    public PreferredImageFormat PreferredImageFormat = PreferredImageFormat.RGBA_byte;

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
