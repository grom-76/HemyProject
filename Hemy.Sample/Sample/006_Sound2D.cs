namespace Hemy.Sample.Sample;

using Hemy.Lib.Core;


public static partial class Example
{



    public static void FirstSound()
    {
        const string Play = "PLAY";
        const string Quit = "QUIT";
        using Hemy.Lib.Core.Window.Window window = new();

        window.CreateWindow();
        var keyboard = window.Keyboard;
        var cmd = new Hemy.Lib.Core.Input.Commands();
        cmd.Add(Play, keyboard.IsPressed, Lib.Core.Input.Key.Space);
        cmd.Add(Quit, keyboard.IsPressed, Lib.Core.Input.Key.Escape);

        var snd = window.AudioDevice.GetSound2D();

        snd.Load(@"C:\Users\Admin\Documents\HemyProject\Hemy.Sample\Assets\demo.wav");


        while (window.IsRunning())
        {
            window.Update();

            if (cmd.IsAction(Quit))
            {
                window.RequestClose();
            }

            if (cmd.IsAction(Play))
            {
                snd.Play();
            }

            window.TestingDraw(Lib.Core.Color.Palette.CornflowerBlue);
        }

        snd.Dispose();
        cmd.Dispose();
        
    }
}