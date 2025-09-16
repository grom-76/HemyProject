using Hemy.Lib.Core;

namespace Hemy.Sample;


public class Program
{
    public static void Main()
    {

        // TestLog();
        // FirstWindow();
        // FirstGraphic();
        // FirstInput();
        // FirstGamePad();
        FirstCommand();
    }

    public static void TestLog()
    {

        Hemy.Lib.Core.Log.Warning("Bonjour");
    }

    public static void FirstWindow()
    {
        using Hemy.Lib.Core.Window.Window window = new();

        window.CreateWindow();

        while (window.IsRunning())
        {
            window.Update();
        }

    }

    public static void FirstGraphic()
    {
        using Hemy.Lib.Core.Window.Window window = new();

        window.CreateWindow();

        while (window.IsRunning())
        {
            window.Update();


            window.TestingDraw(Lib.Core.Color.Palette.CornflowerBlue);
        }

    }

    public static void FirstInput()
    {
        using Hemy.Lib.Core.Window.Window window = new();

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

    public static void FirstGamePad()
    {
        using Hemy.Lib.Core.Window.Window window = new();

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
                clearColor = (Lib.Core.Color.Palette)values.GetValue(random.Next(values.Length));
            }

            window.TestingDraw(clearColor);
        }

    }
    public static void FirstCommand()
    {
        const string Jump = "JUMP";
        using Hemy.Lib.Core.Window.Window window = new();

        window.CreateWindow();
        var joy1 = window.GetGamePad(Lib.Core.Input.ControlerPlayer.Player1);
        var mouse = window.Mouse;
        var keyboard = window.Keyboard;

        var cmd = new Hemy.Lib.Core.Input.Commands();

        cmd.Add(Jump, keyboard.IsPressed , Lib.Core.Input.Key.Space );
        cmd.Add(Jump, joy1.IsPressed , Lib.Core.Input.ControllerButton.A );


        while (window.IsRunning())
        {
            window.Update();

            if (keyboard.IsPressed(Lib.Core.Input.Key.Escape))
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
