# Hemy ENGINE

Light-weight cross platform Game Engine Purly in C#

- Use my own implementation of API : vulkan, window, xlib, pulse, directx, ...
- Few dependencies just : assimp  for Models loadder and shader compiler for compil and check shaders.
- Only One DLL for reference in your project
- Minimal code, fast , low memory use.
- Inspired by : TerraFx, GODOT , stride3D , raylib , Vortice Vulkan, MonoGame.... and many other
- Support Many platforms without pain : Window, Linux, Mac(WIP) , IOS(Not Yet), ANDRoiD(Not Yet), Web(WIP), Nintendo NES(Wip) ,Megadrive(Wip) Builder+ SDK  in progress

Light-weight cross platform Game Engine Purly in C#

Re-invent  wheel just for fun

Specific with  for Vulkan / Dx 12( in progress) / GL( in progress) 

For writing 2D or 3D game, in differents way.
2 In 1 , advanced game engine include Resources manager, editor with integrate GUI, and basic framework.

- Use my own implementation of API : vulkan, window, xlib, pulse, directx, ...
- Few dependencies just : assimp  for Models loadder and shader compiler for compil and check shaders.
- Only One DLL for reference in your project
- Minimal code, fast , low memory use.
- Inspired by : TerraFx, GODOT , stride3D , raylib , Vortice Vulkan, MonoGame.... and many other
- Support Many platforms without pain : Window, Linux, Mac(WIP) , IOS(Not Yet), ANDRoiD(Not Yet), Web(WIP), Nintendo NES(Wip) ,Megadrive(Wip) Builder+ SDK  in progress

## Prerequis 

    - Dotnet 9.0 
    - Visual Studio Code
    - Extension pour visual studio code : Dev Kit , Test Explorer
    - Optionnel : Build ( for  web , mobile and console version)
    - need graphic card with vulkan driver 
    - Install [MSBuildTool](https://aka.ms/vs/17/release/vs_BuildTools.exe) for publish


## Get Starting

    - First  like Raylib 

code~

~

    - Second like monogame

code```


## Features 

- 

## Exemples

-

INSTALL BEFORE PUBLISH :  https://aka.ms/vs/17/release/vs_BuildTools.exe  
 dotnet nuget add source "https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet9/nuget/v3/index.json" 
 dotnet build -c Release /p:Configuration=Release /p:Platform=x64  
 dotnet publish -c Release -r win-x64  -p:PublishAot=true 