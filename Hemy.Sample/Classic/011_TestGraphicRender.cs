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
        TestExternalClass testExternalClass = new(context);
        
        context.Triggers.Add("Start", context.Keyboard.IsPressed, Lib.Core.Input.Key.Space, testExternalClass.TimerStart );
        context.Triggers.Add("Bombe", 5000, 3, testExternalClass.Boom);
        
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

        internal void TimerStart()
        {
            context.Triggers.StartTimer("Bombe");
            
            context.Triggers.StartTimer("Unknow");
        }
    }
}
