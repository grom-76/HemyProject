namespace Hemy.Sample.Classic;

using System;
using Hemy.Lib.Core;
using Hemy.Lib.Core.Input;

public static class C009_TestTimer
{

    public static void Run()
    {

        // const string Quit = "QUIT";
        // const string StartTimer = "StartT1";
        using Hemy.Lib.Core.Context context = new();

        context.Settings.Resolution = Lib.Core.Window.WindowResolution.SVGA_800x600;
        
        context.Create();

        // var player1 = new Hemy.Lib.Core.Input.Commands(2);

        // player1.Add(Quit, context.Keyboard.IsPressed, Lib.Core.Input.Key.Escape);
        // player1.Add(StartTimer, context.Keyboard.IsPressed, Lib.Core.Input.Key.Space);
        TestExternalClass testExternalClass = new(context);


        Triggers triggers = new();

        triggers.Add(0, context.Keyboard.IsPressed, Lib.Core.Input.Key.Escape, testExternalClass.Close );
        triggers.Add(1, 1000, 5, testExternalClass.Boom);
        // var t1 = new Hemy.Lib.Core.Sys.Timer(1000, 5);

        // var t2 = new Hemy.Lib.Core.Sys.TimerTrigger(1000, 3, testExternalClass.Boom);

        while (context.IsRunning())
        {
            context.Update();

            triggers.Update();
            // t2.Update();

            // if (player1.IsAction(Quit)) { context.RequestClose(); }

            // if (player1.IsAction(StartTimer))
            // {
            //     Log.Info("Start Timer ");
            //     // t1.Start();
            //     t2.Start();
            // }


            context.TestingDraw(Lib.Core.Color.Palette.CornflowerBlue);

            // if (t1.IsDone())
            // {
            //     Log.Info("Timer OK ");
            // }
        }


        // player1.Dispose();

    }

    public class TestExternalClass(Hemy.Lib.Core.Context context)
    {
        public void Boom()
        {
            Log.Info("BOOM at : " + context.Time.DeltaTime);
        }

        public void Close()
        {
            context.RequestClose();
        }
    }

   
}
