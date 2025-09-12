namespace Hemy.Sample;


public class Program
{
    public static void Main()
    {

        // TestLog();
        FirstWindow();

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
}
