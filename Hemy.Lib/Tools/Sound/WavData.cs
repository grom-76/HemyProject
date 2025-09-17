namespace Hemy.Lib.Tools.Sound;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public struct WavData()
{
    /// <summary>  FileSize (4 octets) : Taille du fichier moins 8 octets </summary>
    public uint FileSize = 0;
    /// <summary> BlocSize  (4 octets) : Nombre d'octets du bloc - 16  (0x10)Chunk Size </summary>
    public uint BlocSize = 0;
    /// <summary> Frequence      (4 octets) : Fréquence d'échantillonnage (en hertz) [Valeurs standardis�es : 11025, 22050, 44100 et éventuellement 48000 et 96000] </summary>
    public uint Frequence = 0;
    /// <summary> Nombre d'octets à lire par seconde (i.e., Frequence * BytePerBloc). </summary>
    public uint Octetparseconde = 0;
    /// <summary> BytePerSec  (4 octets) : Nombre d'octets � lire par seconde (i.e., Frequence * BytePerBloc). </summary>
    public uint BytePerSec = 0;
    /// <summary> DataSize  (4 octets) : Nombre d'octets des donn�es (i.e. "Data[]", i.e. taille_du_fichier - taille_de_l'ent�te  (qui fait 44 octets normalement). </summary>
    public uint DataSize = 0;
    /// <summary> BytePerBloc     (2 octets) : Nombre d'octets par bloc d'�chantillonnage (i.e., tous canaux confondus : NbrCanaux * BitsPerSample/8). </summary>
    public short BytePerBloc = 0;
    /// <summary> BitsPerSample(2 octets) : Nombre de bits utilis�s pour le codage de chaque �chantillon (8, 16, 24) </summary>
    public short BitsPerSample = 0;
    /// <summary> AudioFormat     (2 octets) : Format du stockage dans le fichier (1: PCM, 2: ADPCM  , ...) </summary>
    public short AudioFormat = 0;
    /// <summary> Channels  NbrCanaux (2 octets) : Nombre de canaux (de 1 à 6, cf. ci-dessous ). </summary>
    public short Nbrcanaux = 0;
}


/*
WAVE FORMAT 
//  [Bloc de d�claration d'un fichier au format WAVE]
//      FileTypeBlocID  (4 octets) : Constante �RIFF�  (0x52,0x49,0x46,0x46)
//      FileSize        (4 octets) : Taille du fichier moins 8 octets
//      FileFormatID    (4 octets) : Format = �WAVE�  (0x57,0x41,0x56,0x45)

// [Bloc d�crivant le format audio]
//    FormatBlocID    (4 octets) : Identifiant �fmt �  (0x66,0x6D, 0x74,0x20)
//    BlocSize        (4 octets) : Nombre d'octets du bloc - 16  (0x10)
//    AudioFormat     (2 octets) : Format du stockage dans le fichier (1: PCM, 2: ADPCM  , ...)
//    NbrCanaux       (2 octets) : Nombre de canaux (de 1 � 6, cf. ci-dessous)
//    Frequence       (4 octets) : Fr�quence d'�chantillonnage (en hertz) [Valeurs standardis�es : 11025, 22050, 44100 et �ventuellement 48000 et 96000]
//    BytePerSec      (4 octets) : Nombre d'octets � lire par seconde (i.e., Frequence * BytePerBloc).
//    BytePerBloc     (2 octets) : Nombre d'octets par bloc d'�chantillonnage (i.e., tous canaux confondus : NbrCanaux * BitsPerSample/8).
//    BitsPerSample   (2 octets) : Nombre de bits utilis�s pour le codage de chaque �chantillon (8, 16, 24)
// [Bloc des donn�es]
//    DataBlocID      (4 octets) : Constante �data�  (0x64,0x61,0x74,0x61)
//    DataSize        (4 octets) : Nombre d'octets des donn�es (i.e. "Data[]", i.e. taille_du_fichier - taille_de_l'ent�te  (qui fait 44 octets normalement).
//    DATAS[] : [Octets du Sample 1 du Canal 1] [Octets du Sample 1 du Canal 2] [Octets du Sample 2 du Canal 1] [Octets du Sample 2 du Canal 2]

//    * Les Canaux :
//       1 pour mono,
//       2 pour st�r�o
//       3 pour gauche, droit et centre
//       4 pour face gauche, face droit, arri�re gauche, arri�re droit
//       5 pour gauche, centre, droit, surround (ambiant)
//       6 pour centre gauche, gauche, centre, centre droit, droit, surround (ambiant)

// NOTES IMPORTANTES :  Les octets des mots sont stock�s sous la forme  (i.e., en "little endian")
// [87654321][16..9][24..17] [8..1][16..9][24..17] [...
*/