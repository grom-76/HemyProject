namespace Hemy.Sample.Classic;

using System;
using Hemy.Lib.Core;
using Hemy.Lib.Core.Input;

public static class C012_TestShaderC
{

    public static void Run()
    {
        using Hemy.Lib.Core.Context context = new();
        context.Create();

        context.GraphicDevice.GraphicRender.BuildShader();
       
    }

   
}
