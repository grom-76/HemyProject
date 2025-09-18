namespace Hemy.Sample.Classic;

using Hemy.Lib.Core;


public static partial class C007_FirstModifyTitleBarple
{

    public static void Run()
    {
        const string Play = "PLAY";
        const string Quit = "QUIT";
        using Hemy.Lib.Core.Context context = new();
        context.Create();

        var player1 = new Hemy.Lib.Core.Input.Commands();
        player1.Add(Play,  context.Keyboard.IsPressed, Lib.Core.Input.Key.Space);
        player1.Add(Quit,  context.Keyboard.IsPressed, Lib.Core.Input.Key.Escape);

        while (context.IsRunning())
        {
            context.Update();

            if (player1.IsAction(Quit))
            {
                context.RequestClose();
            }

            if (player1.IsAction(Play))
            {
                context.Window.SetTitle("New title qui pete");
            }

            context.TestingDraw(Lib.Core.Color.Palette.CornflowerBlue);
        }

       
        player1.Dispose();

    }
}