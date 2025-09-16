namespace Hemy.Sample.Sample;

using Hemy.Lib.Core;


public static partial class Example
{

   

    public static void FirstCommand()
    {
        const string Jump = "JUMP";
        const string Quit = "QUIT";
        using Hemy.Lib.Core.Window.Window window = new();

        window.CreateWindow();
        var joy1 = window.GetGamePad(Lib.Core.Input.ControlerPlayer.Player1);
        var mouse = window.Mouse;
        var keyboard = window.Keyboard;

        var cmd = new Hemy.Lib.Core.Input.Commands();

        cmd.Add(Jump, keyboard.IsPressed , Lib.Core.Input.Key.Space );
        cmd.Add(Jump, joy1.IsPressed , Lib.Core.Input.ControllerButton.A );
        cmd.Add(Quit, keyboard.IsPressed , Lib.Core.Input.Key.Escape );

        while (window.IsRunning())
        {
            window.Update();

            if (cmd.IsAction(Quit) )
            {
                window.RequestClose();
            }

            if (cmd.IsAction(Jump))
            {
                Log.Info("Jump ....." + window.DeltaTime );
            }

            window.TestingDraw(Lib.Core.Color.Palette.CornflowerBlue);
        }
        
    }
}