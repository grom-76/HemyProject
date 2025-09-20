namespace Hemy.Sample.Classic;


using Hemy.Lib.Core;


public static class C008_TestSettings
{

    public static void Run()
    {

        const string Quit = "QUIT";
        using Hemy.Lib.Core.Context context = new();

        context.Window.Settings.Resolution = Lib.Core.Window.WindowResolution.SVGA_800x600;
        
        context.Create();

        var player1 = new Hemy.Lib.Core.Input.Commands(2);

        player1.Add(Quit, context.Keyboard.IsPressed, Lib.Core.Input.Key.Escape);

        while (context.Window.IsRunning())
        {
            context.Update();

            if (player1.IsAction(Quit)) { context.Window.RequestClose(); }


            context.GraphicDevice.TestingDraw(Lib.Core.Color.Palette.CornflowerBlue);
        }


        player1.Dispose();

    }
}
