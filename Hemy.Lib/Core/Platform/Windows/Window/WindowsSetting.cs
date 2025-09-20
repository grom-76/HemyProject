#if WINDOWS



namespace Hemy.Lib.Core.Platform.Windows.Window;

internal unsafe struct WindowsSettings()
{
    internal fixed byte GameName[256];
    internal int PreferredWidth = 1280;
    internal int PreferredHeight = 720;
    internal Hemy.Lib.Core.Window.WindowStyle Style = Core.Window.WindowStyle.standard;

    internal static void Binding(WindowsSettings* windowSettings, Hemy.Lib.Core.Window.WindowSettings settings)
    {
        Memory.Memory.FillBytesWithString(windowSettings->GameName, settings.GameName);

        (windowSettings->PreferredWidth,windowSettings-> PreferredHeight) = Utils.ResolutionToSize(settings.Resolution);

        windowSettings->Style = settings.Style; 
    }
}

#endif


