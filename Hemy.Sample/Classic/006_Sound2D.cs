namespace Hemy.Sample.Classic;


using Hemy.Lib.Core;


public static partial class C006_Sound2D
{

    public static void Run()
    {

        const string Play = "PLAY";
        const string Quit = "QUIT";
        using Hemy.Lib.Core.Context context = new();
        context.Create();

        var player1 = new Hemy.Lib.Core.Input.Commands(10);
        player1.Add(Play,  context.Keyboard.IsPressed, Lib.Core.Input.Key.Space);
        player1.Add(Quit,  context.Keyboard.IsPressed, Lib.Core.Input.Key.Escape);


        var sound2D = context.AudioDevice.GetSound2D();
        sound2D.CreateFromFile(@"C:\Users\Admin\Documents\HemyProject\Hemy.Sample\Assets\demo.wav");
        sound2D.SetVolume(0.5f);

        while (context.Window.IsRunning())
        {
            context.Update();
            sound2D.Update();

            if (player1.IsAction(Quit))
            {
                context.Window.RequestClose();
            }

            if (player1.IsAction(Play))
            {
                sound2D.Play();
            }

            context.GraphicDevice.TestingDraw(Lib.Core.Color.Palette.CornflowerBlue);
        }

        sound2D.Dispose();
        player1.Dispose();
        
    }
}