namespace Hemy.Sample;


public class Program
{
    public static void Main()
    {

        // TestLog();
        // FirstWindow();
        // FirstGraphic();
        FirstInput();

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
}
