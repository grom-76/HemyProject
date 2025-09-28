namespace Hemy.Sample.V2;

using System;
using Hemy.Lib.V2.Core;


/// <summary>
/// Startup v2 essai
/// </summary>
public static class V2_001
{

    public static void Run()
    {
        Hemy.Lib.V2.Core.Context ctx = new();

        ctx.Settings
            .Graphic
                .SetBuffer(2).Build()
            .Window
                .Resolution(Window.WindowResolution.HD_720p_1280x720)
                .Style(Window.WindowStyle.standard)
                .Title("V2_001").Build();
        ctx.Create();


        while (ctx.Events.IsRunning())
        {

        }


        ctx.Dispose();
    }


}
