namespace Hemy.Sample.Sample;

using Hemy.Lib.Core;


public static partial class Example
{

    public static void FirstWindow()
    {
        using Hemy.Lib.Core.Context context = new();

        context.Create();

        while (context.IsRunning())
        {
            context.Update();
        }

    }
}