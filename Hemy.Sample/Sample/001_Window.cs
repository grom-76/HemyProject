namespace Hemy.Sample.Sample;

using Hemy.Lib.Core;


public static partial class Example
{

    public static void FirstWindow()
    {
        using Hemy.Lib.Core.Window.Window window = new();

        window.CreateWindow();

        while (window.IsRunning())
        {
            window.Update();
        }

    }
}