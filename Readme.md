# HEMY ENGINE

Light-weight cross platform Game Engine Purly in C# ( vulkan native )
I re-invent  wheel just for fun.

- Use my own implementation of API : vulkan, window, xlib, pulse, directx, ...
- Few dependencies just : assimp  for Models loader and shader_compiler for compil and check shaders.
- Only One DLL for reference in your project
- Minimal code, fast   , low memory use.
- Inspired by : TerraFx, GODOT , stride3D , raylib , Vortice Vulkan, MonoGame.... and many other
- Support Many platforms without pain : Window, Linux, Mac(WIP) , IOS(Not Yet), ANDRoiD(Not Yet), Web(WIP), Nintendo NES(Wip) ,Megadrive(Wip) Builder+ SDK  in progress


## Prerequis 

    - Dotnet 9.0 
    - Visual Studio Code
    - Extension pour visual studio code : Dev Kit , Test Explorer, other you want
    - Optionnel : Build ( for  web , mobile and console version)
    - need graphic card with vulkan driver 
    - Install [MSBuildTool](https://aka.ms/vs/17/release/vs_BuildTools.exe) for publish
    - in commmand  prompt  type : dotnet nuget add source "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet9/nuget/v3/index.json" 
    - in command prompt for build project in  release mode  type : dotnet build -c Release /p:Configuration=Release /p:Platform=x64  
    - in command prompt for pulish your game : dotnet publish -c Release -r win-x64  -p:PublishAot=true 

## Get Starting

For writing 2D or 3D game, in differents way.
2 In 1 , advanced game engine include Resources manager, editor with integrate GUI, and basic framework.

Like Raylib  :

```C#

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
```

Like monogame :

```C#


```

## Features  ( CheatSheet )

- 
