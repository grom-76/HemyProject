namespace Hemy.Sample.Classic;

using System;
using Hemy.Lib.Core;
using Hemy.Lib.Core.Input;

public static class C011_TestGraphicRender
{

    public static void Run()
    {
        using Hemy.Lib.Core.Context context = new();

        context.Window.Settings.Resolution = Lib.Core.Window.WindowResolution.SVGA_800x600;
        context.Create();

        var render = context.GraphicDevice.GraphicRender;
        render.Add(new());
        render.BuildRender();

        while (context.Window.IsRunning())
        {
            context.Update();

            if (context.Keyboard.IsPressed(Key.Escape)) context.Window.RequestClose();


            render.Draw(Lib.Core.Color.Palette.CornflowerBlue);
        }

    }



   
}
