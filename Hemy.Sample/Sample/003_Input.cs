namespace Hemy.Sample.Sample;

using Hemy.Lib.Core;


public static partial class Example
{

 
    public static void FirstInput()
    {
        using Hemy.Lib.Core.Context window = new();

        window.CreateWindow();


        while (window.IsRunning())
        {
            window.Update();

            if (window.Keyboard.IsPressed(Lib.Core.Input.Key.Escape))
            {
                window.RequestClose();
            }


            window.TestingDraw(Lib.Core.Color.Palette.CornflowerBlue);
        }

    }
}