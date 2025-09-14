namespace Hemy.Lib.Core.Graphic;


#region GRAPHIC 
public enum PreferredVsync
{
    Activate,
    Disable,
    Auto,
}

public enum PreferredImageFormat : byte
{
	RGBA_uint,
	BGRA_uint,
	RGB_ushort,
	RGBA_byte,
	RGBA_sbyte,
	RGBA_short,
	RGBA_ushort,
	RGBA_float
}

public enum BufferMode
{
    ///  <summary>One pass GPU wit cpu finish </summary>
    SimpleBuffering = 1,
    ///  <summary>CPU and GPU work in thread </summary>
    DoubleBuffering = 2 ,
    ///  <summary>One pass GPU wit cpu finish </summary>
    TripleBuffering = 3 ,
}

enum PreferredDeviceType
{
    other = 0,
    integrated = 1,
    discrete = 2,
    virtual_gpu = 3,
    cpu = 4
};

enum QueueType
{
    present,
    graphics,
    compute,
    transfer
};

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

// GRAPHIC CAPABILITIES

/// <summary> Pour le calcul mathématique des transform et clip volum </summary>
public enum ClipVolume
{
    ///<summary>NO in glm Opengl definition </summary>       
    NegativeOneToPlusOne,
    ///<summary>ZO in glm Dorect3D definition </summary>       
    ZeroToOne,
}

/// <summary> main utiliser pour le system de coordonnée </summary>
public enum Handled
{
    ///<summary>RH main droite OPengl </summary>      
    RightHand,
        ///<summary>LH main gauche dIRECTX </summary>      
    LeftHand
}

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

public enum PreferredColorFormat : byte
{
	HDR10,
	BT709,
	sRGB,
}

#endregion

