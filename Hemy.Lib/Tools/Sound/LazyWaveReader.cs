namespace Hemy.Lib.Tools.Sound;

using System;
using System.IO;
using Hemy.Lib.Core.Platform.Windows.IO;
using Hemy.Lib.Core.Memory;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Hemy.Lib.Core;

/// <summary>
/// Simple class lecture fichier wav
/// </summary>
[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe sealed class LazyWaveReader : IDisposable
{
    const uint WavHeaderSize = 44;

    const uint WAVE_RIFF_LE
#if WINDOWS
    = 0x46464952; // Constante RIFF RIFF�  (0x52,0x49,0x46,0x46) LE = little endian et BE big endian ....
#else
    = 0x52494646;
#endif

    const uint WAVE_WAVE_LE
#if WINDOWS
    = 0x45564157; // Format = �WAVE�  (0x57,0x41,0x56,0x45)
#else
    = 0x57415645;
#endif

    const uint WAVE_FMT_LE
#if WINDOWS
    = 0x20746D66; // Identifiant �fmt �  (0x66,0x6D, 0x74,0x20)
#else
    = 0x666D7420;
#endif 
    const uint WAVE_DATA_LE
#if WINDOWS
     = 0x61746164; //Constante �data�  (0x64,0x61,0x74,0x61)
#else
    = 0x64617461;
#endif

    private WavData* _wavData = null;
    private IoFileData* _fileData = null;

    /// <summary> . </summary>
    public LazyWaveReader()
    {
        _wavData = Memory.New<WavData>();
        _fileData = Memory.New<IoFileData>();
    }

    /// <summary> . </summary>
    public void ReadHeader(string filename)
    {
        IoFileRWImpl.Open(_fileData, filename);

        byte* buffer = Memory.NewArray<byte>(44);
        IoFileRWImpl.Read(_fileData, buffer, 44);
        int position = 0;


        if (IoFileRWImpl.UInt(buffer, &position) != 0x46464952) return;

        _wavData->FileSize = IoFileRWImpl.UInt(buffer, &position);

        if (IoFileRWImpl.UInt(buffer, &position) != 0x45564157) return;

        if (IoFileRWImpl.UInt(buffer, &position) != 0x20746D66) return;

        _wavData->BlocSize = IoFileRWImpl.UInt(buffer, &position);
        _wavData->AudioFormat = IoFileRWImpl.Short(buffer, &position);
        _wavData->Nbrcanaux = IoFileRWImpl.Short(buffer, &position);
        _wavData->Frequence = IoFileRWImpl.UInt(buffer, &position);
        _wavData->BytePerSec = IoFileRWImpl.UInt(buffer, &position);
        _wavData->BytePerBloc = IoFileRWImpl.Short(buffer, &position);
        _wavData->BitsPerSample = IoFileRWImpl.Short(buffer, &position);

        if (IoFileRWImpl.UInt(buffer, &position) != 0x61746164) return;

        _wavData->DataSize = IoFileRWImpl.UInt(buffer, &position) - 44;
        _wavData->Octetparseconde = _wavData->Frequence * (uint)_wavData->BytePerBloc;

        Memory.DisposeArray(buffer);
    }

    public WavData Data => *_wavData;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="size"></param>
    public void ReadChunk(byte* buffer )
    {
        // byte* buffer = Memory.NewArray<byte>(_wavData->DataSize);
        IoFileRWImpl.Read(_fileData, buffer, _wavData->DataSize);
        // return buffer;
    }
    private bool _isDisposed = false;
    public void Dispose()
    {
        if (_isDisposed) return;

        _isDisposed = true;
        Log.Info("Dispose WaveReader");
        IoFileRWImpl.Close(_fileData);
        Memory.Dispose(_fileData);
        Memory.Dispose(_wavData);
        GC.SuppressFinalize(this);
    }
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