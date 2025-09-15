namespace Hemy.Lib.Core.Graphic;


/// <summary> Api graphic utilisé pour l'affichage </summary>
public enum PreferedGraphicAPI : byte //GraphicAPI
{
    /// <summary>  Directx pour window pas encore implémenté </summary>
    Directx,
    /// <summary>  OPengl api in progress </summary>
    Opengl,
    /// <summary> Vulkan API de BAse </summary>
    Vulkan,
    /// <summary> Use external API like ogre </summary>
    Api,
    /// <summary> Metal for mac only </summary>
    Metal
}

