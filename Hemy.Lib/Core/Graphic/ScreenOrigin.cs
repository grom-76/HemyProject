namespace Hemy.Lib.Core.Graphic;

/// <summary> Point d'origin de l'écran  le ( 0,0 ) </summary>
public enum ScreenOrigin
{
    ///<summary>Bas droite  origin in Opengl </summary>       
    lowerLeft,
    ///<summary>haut a gauche pour directx </summary>       
    UpperLeft,
    ///<summary>pour transform , models mesh  au centre </summary>       
    Center
}
