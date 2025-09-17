namespace Hemy.Sample.Sample;

using Hemy.Lib.Core;


public static partial class Example
{

    public static void FirstGamePad()
    {
        using Hemy.Lib.Core.Context window = new();

        window.CreateWindow();
        var joy1 = window.GetGamePad(Lib.Core.Input.ControlerPlayer.Player1);
        var mouse = window.Mouse;
        var keyboard = window.Keyboard;

        Hemy.Lib.Core.Math.Random.MiniPCG32 random = new();
        Lib.Core.Color.Palette clearColor = Lib.Core.Color.Palette.CornflowerBlue;

        while (window.IsRunning())
        {
            window.Update();

            if (joy1.IsPressed(Lib.Core.Input.ControllerButton.A))
            {
                window.RequestClose();
            }

            if (joy1.IsLeftStickMove)
            {
                Log.Info($"Left stickmove : {joy1.StickLeft_X} ; {joy1.StickLeft_Y}");
            }

            if (keyboard.IsPressed(Lib.Core.Input.Key.Escape))
            {
                window.RequestClose();
            }

            if (mouse.IsMouseMove)
            {
                Log.Info("Mouse Move :" + mouse.ToString());
            }

            if (joy1.IsPressed(Lib.Core.Input.ControllerButton.B))
            {
                Array values = Enum.GetValues(typeof(Lib.Core.Color.Palette));
                var c = values.GetValue(random.Next(values.Length));
                clearColor = c == null ? Lib.Core.Color.Palette.Black :(Lib.Core.Color.Palette) c;
            }

            window.TestingDraw(clearColor);
        }

    }
}