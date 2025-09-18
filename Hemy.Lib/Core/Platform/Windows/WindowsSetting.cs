#if WINDOWS

using System;

namespace Hemy.Lib.Core.Platform.Windows;

internal unsafe struct WindowsSetting()
{
    internal fixed byte GameName[256];
    internal int PreferredWidth = 1280;
    internal int PreferredHeight = 720;
    internal Hemy.Lib.Core.Window.WindowStyle Style = Core.Window.WindowStyle.standard;

    internal static void Binding(WindowsSetting* windowSettings, Hemy.Lib.Core.Settings settings)
    {
        Memory.Memory.FillBytesWithString(windowSettings->GameName, settings.GameName);

        (windowSettings->PreferredWidth,windowSettings-> PreferredHeight) = Utils.ResolutionToSize(settings.Resolution);

        windowSettings->Style = settings.Style; 
    }
}

#endif


