namespace Hemy.Sample.Classic;

using System;
using Hemy.Lib.Core;
using Hemy.Lib.Core.Input;
using Hemy.Lib.Core.Sys;

public static class C009_TestTriggers
{

    public static void Run()
    {
        using Hemy.Lib.Core.Context context = new();

        context.Window.Settings.Resolution = Lib.Core.Window.WindowResolution.SVGA_800x600;
        
        context.Create();

        TestExternalClass testExternalClass = new(context);


        context.Triggers.Add("Close", context.Keyboard.IsPressed, Lib.Core.Input.Key.Escape, testExternalClass.Close );
        context.Triggers.Add("Close", context.Keyboard.IsPressed, Lib.Core.Input.Key.Space, testExternalClass.Start );
        context.Triggers.Add("Bombe", 5000, 3, testExternalClass.Boom);


        while (context.Window.IsRunning())
        {
            context.Update();


            // context.GraphicDevice.TestingDraw(Lib.Core.Color.Palette.SeaGreen);
        }

    }

    public class TestExternalClass(Hemy.Lib.Core.Context context)
    {
        public void Boom()
        {
            Log.Info($" !!!!  BOOOOMMMM !!!! { context.Time.DeltaTime } ms Fram Time {context.Time.CurrentFrameTime}  ms Prvious Time {context.Time.PreviousFrameTime} ms UTc {context.Time.TimeStamp }  sec count {context.Time.FrameCount}" );
        }

        public void Close()
        {
            context.Window.RequestClose();
        }

        internal void Start()
        {
            context.Triggers.StartTimer("Bombe");

        }
    }

   
}
