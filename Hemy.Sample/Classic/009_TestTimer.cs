namespace Hemy.Sample.Classic;


using Hemy.Lib.Core;


public static class C009_TestTimer
{

    public static void Run()
    {

        const string Quit = "QUIT";
        const string StartTimer = "StartT1";
        using Hemy.Lib.Core.Context context = new();

        context.Settings.Resolution = Lib.Core.Window.WindowResolution.SVGA_800x600;
        
        context.Create();

        var player1 = new Hemy.Lib.Core.Input.Commands(2);

        player1.Add(Quit, context.Keyboard.IsPressed, Lib.Core.Input.Key.Escape);
        player1.Add(StartTimer, context.Keyboard.IsPressed, Lib.Core.Input.Key.Space);

        var t1 = new Hemy.Lib.Core.Sys.Timer(1000, 5);


        while (context.IsRunning())
        {
            context.Update();

            if (player1.IsAction(Quit)) { context.RequestClose(); }

            if (player1.IsAction(StartTimer))
            {
                    Log.Info("Start Timer ");
                t1.Start();
            }


            context.TestingDraw(Lib.Core.Color.Palette.CornflowerBlue);

            if (t1.IsDone())
            {
                Log.Info("Timer OK ");
            }
        }


        player1.Dispose();

    }
}
