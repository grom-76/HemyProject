namespace Hemy.Lib.V2.Core;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public static class Window
{
    public enum WindowResolution : byte
    {
        Fullscreen = 0,
        FHD_1080p_1920x1080,
        HD_720p_1280x720,
        VGA_640x480,
        SVGA_800x600,
    }

    // <summary> BORDER STYLE </summary>
    public enum WindowStyle : byte
    {
        Fullscreen = 0,
        standard,
        None,
        Fixed,
        Popup,
        Sizable,
    }

    [SkipLocalsInit]
    [SuppressUnmanagedCodeSecurity]
    [StructLayout(LayoutKind.Sequential)]
    public sealed class WindowSettings(ConntextSettings ctx) : IDisposable
    {
        internal string caption = "First Game V2";
        internal uint width = 0;
        internal uint height = 0;
        internal uint style = 0;

        public WindowSettings Resolution(WindowResolution resolution)
        {
            switch (resolution)
            {
                case WindowResolution.Fullscreen:
                    width = uint.MaxValue; height = uint.MaxValue;
                    break;
                case WindowResolution.FHD_1080p_1920x1080:
                    width = 1920; height = 1080;
                    break;
                case WindowResolution.HD_720p_1280x720:
                    width = 1280; height = 720;
                    break;
                case WindowResolution.VGA_640x480:
                    width = 640; height = 480;
                    break;
                case WindowResolution.SVGA_800x600:
                    width = 800; height = 600;
                    break;
                default:
                    break;
            }
            return this;
        }

        public WindowSettings Title(string title)
        {
            if (!string.IsNullOrEmpty(title))
                this.caption = title;
            return this;
        }

        public WindowSettings Style(WindowStyle style)
        {
            this.style = (uint)style;
            return this;
        }

        public ConntextSettings Build() { return ctx; }

        public void Dispose()
        {
            caption = null;
            GC.SuppressFinalize(this);
        }
    }

    [SkipLocalsInit]
    [SuppressUnmanagedCodeSecurity]
    public interface IWindow
    {
        void SetTitle(string title);


    }
}
