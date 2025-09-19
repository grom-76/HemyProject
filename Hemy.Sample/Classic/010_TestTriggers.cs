namespace Hemy.Sample.Classic;

using System;
using Hemy.Lib.Core;
using Hemy.Lib.Core.Input;

public static class C009_TestTriggers
{

    public static void Run()
    {
        using Hemy.Lib.Core.Context context = new();

        context.Settings.Resolution = Lib.Core.Window.WindowResolution.SVGA_800x600;
        
        context.Create();

        TestExternalClass testExternalClass = new(context);


        context.Triggers.Add(0, context.Keyboard.IsPressed, Lib.Core.Input.Key.Escape, testExternalClass.Close );
        context.Triggers.Add(1, context.Keyboard.IsPressed, Lib.Core.Input.Key.Space, testExternalClass.Start );
        context.Triggers.Add(2, 2000, 3, testExternalClass.Boom);


        while (context.IsRunning())
        {
            context.Update();


            context.TestingDraw(Lib.Core.Color.Palette.SeaGreen);
        }

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

        internal void Start()
        {
            context.Triggers.StartTimer(2);
        }
    }

   
}
