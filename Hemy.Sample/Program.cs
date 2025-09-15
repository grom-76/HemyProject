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
        FirstGamePad();

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


            window.TestingDraw();
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


            window.TestingDraw();
        }

    }
    
     public static void FirstGamePad()
    {
        using Hemy.Lib.Core.Window.Window window = new();

        window.CreateWindow();
        var joy1 = window.GetGamePad(Lib.Core.Input.ControlerPlayer.Player1);
        

        while (window.IsRunning())
        {
            window.Update();

            if (joy1.IsPressed(Lib.Core.Input.ControllerButton.A) )
            {
                window.RequestClose();
            }

            if (joy1.IsLeftStickMove)
            {
                Log.Info($"Left stickmove : { joy1.StickLeft_X } ; {joy1.StickLeft_Y}");
            }

            if (window.Keyboard.IsPressed(Lib.Core.Input.Key.Escape))
            {
                window.RequestClose();
            }


            window.TestingDraw();
        }
        
    }
}
