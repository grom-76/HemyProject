namespace Hemy.Sample.Sample;

using Hemy.Lib.Core;


public static partial class Example
{

    public static void FirstSound()
    {

        const string Play = "PLAY";
        const string Quit = "QUIT";
        using Hemy.Lib.Core.Context window = new();
        window.Create();

        var player1 = new Hemy.Lib.Core.Input.Commands(10);
        player1.Add(Play,  window.Keyboard.IsPressed, Lib.Core.Input.Key.Space);
        player1.Add(Quit,  window.Keyboard.IsPressed, Lib.Core.Input.Key.Escape);


        var sound2D = window.AudioDevice.GetSound2D();
        sound2D.CreateFromFile(@"C:\Users\Admin\Documents\HemyProject\Hemy.Sample\Assets\demo.wav");
        sound2D.SetVolume(0.5f);

        while (window.IsRunning())
        {
            window.Update();
            sound2D.Update();

            if (player1.IsAction(Quit))
            {
                window.RequestClose();
            }

            if (player1.IsAction(Play))
            {
                sound2D.Play();
            }

            window.TestingDraw(Lib.Core.Color.Palette.CornflowerBlue);
        }

        sound2D.Dispose();
        player1.Dispose();
        
    }
}