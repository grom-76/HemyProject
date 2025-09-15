using System;
using Hemy.Lib.Core.Math;
using Hemy.Lib.Core.Platform.Windows.Audio;

namespace Hemy.Lib.Core.Audio;


// see  AudioEmitter  :  https://www.maxicours.com/se/cours/caracteristiques-des-sons-musicaux/

/*

AUDIO
    Native/Backend/Interop/ 
    
    
    Sounds
        Ogg
        Wav
        Mp3
        Flac
        Xm
        ....
        NoiseGenerator
    Filters/ see miniaudio engine???             
  

    AudioEngine.cs(Need AudioDevice )
        Init( ILoader? AudioConfig )
        AudioDevice.cs ( load() ,init() , release() , config , capabilities/infos , data )
        AudioRender
        
        => SetMasterVolume(0.0 to1.0f log );
        => var sound = ImportSound2D(waveFile) [ use struct Sound ]
        => var source = CreateSound2D(source) [ use struct Source ]
        => PlaySound2D(source, loop, volume) 
        => advanced system for game 
        => sttream music , load many sources ...


*/
  /*
    RitaEngine.Audio ( need SystemsDevice ; Math ; IO )

USE NAUDIO => no longer maintien https://github.com/naudio/NAudio

    Render => need SystemDevice Graphic Init
    Listenr
    Source / Emiters
    Buffer
    Capture
    Encode/Decoder
    Effects
    Filters
    Generators ( noise)
    Mixer / Equalizer 
    DSP
    FastFourierTransform ( see math)
    SoundEnveloppe
        Attaque
        Declin
        Maintien 
        Extincion
        Hauteur
        RaylibBindings  https://github.com/raysan5/rfxgen
        Need MAth Rand ( Xoshiro128** SplitMix64)
        BaseType WaveParams 
            // Random seed used to generate the wave => int randSeed;
            // Wave type (square, sawtooth, sine, noise)    int waveTypeValue;
            // Wave envelope parameters   float attackTimeValue; float sustainTimeValue;  float sustainPunchValue;  float decayTimeValue;
            // Frequency parameters   float startFrequencyValue;   float minFrequencyValue;   float slideValue;    float deltaSlideValue;   float vibratoDepthValue;   float vibratoSpeedValue;//float vibratoPhaseDelayValue;
            // Tone change parameters    float changeAmountValue;    float changeSpeedValue;    
            // Square wave parameters    float squareDutyValue;    float dutySweepValue;
            // Repeat parameters    float repeatSpeedValue;
            // Phaser parameters    float phaserOffsetValue;    float phaserSweepValue;
            // Filter parameters    float lpfCutoffValue;    float lpfCutoffSweepValue;    float lpfResonanceValue;    float hpfCutoffValue;    float hpfCutoffSweepValue;
            // Sound generation functions
                WaveParams GenPickupCoin(void);      // Generate sound: Pickup/Coin
                WaveParams GenLaserShoot(void);      // Generate sound: Laser shoot
                WaveParams GenExplosion(void);       // Generate sound: Explosion
                WaveParams GenPowerup(void);         // Generate sound: Powerup
                WaveParams GenHitHurt(void);         // Generate sound: Hit/Hurt
                WaveParams GenJump(void);            // Generate sound: Jump
                WaveParams GenBlipSelect(void);      // Generate sound: Blip/Select
                WaveParams GenRandomize(void);       // Generate random sound
                void WaveMutate(WaveParams *params); // Mutate current sound
                */
/// <summary>
/// Applique un effets que pour les buffers ? 
/// </summary>
public class Effects
{
 //BarGates , Chorus Flanger Glitcher WahWah
    
    // https://github.com/piRepos/pEngine-del/
    // AUdio ( a voir ???? ) DSP Mixing  effect WahWah 
}// Echo reverb delay

    /// <summary>
    ///  creé des bruits spécifique 
    /// </summary>
    public class Noises
    {
        /// <summary>
        /// Bruit blanc bruit rose ..
        /// </summary>
        public static class WaveForm
        {

        }
    }

   
    /// <summary>
    /// Class Harmonisation du son pour le mixer
    /// </summary>
    public class Equalizer
    {

    }

 

    /// <summary>
    /// Sons 
    /// </summary>
    public class Source
    {
        private Buffer[] Buffers = null!;

        public enum Format{ F32,S16,S24,S32,U8 }
        
    }

    public class Buffer
    {
        public enum BufferState{ Compressed, stream, normal, fixe , circle}

        //USe sounds 
        public void Create( BufferState state)
        {
            // Sounds.LoadSound();
        }

        public void RingBuffer(){}
        
    }

    public class Engine
    {
        //AudioDevice => Init  IN
        //AudioRendder =>  Render OUT
        //AudioVoice
        //AudioCapture

        public void Init() { }

        public void Dispose()
        {
            //Release
        }
        public bool IsReady => false;
        public void Start() { }
        public void Stop() { }

    }

    public class Voice
    {
        //Speech recognition
    }

    public class Capture
    {

    }

  

    /// <summary>
    ///  applique des filtre sur le son 
    /// </summary>
    public class Filter
    {
        //Low Pass first second high order

        //High Pass 

        //band pass

        //Notch filtering

        // Peaking EQ filtering

        //Low shelf filtering 

        //High shelf filtering

    }
    
 
   



/// <summary>
/// Mixe le sons des différents sources 
/// Applique effets et filtres
/// </summary>
public class Mixer
{
    // private Equalizer Equalizer=null!;
    // private Filter[] Filters=null!;
    // private Effects[] Effects=null!;
    //https://github.com/piRepos/pEngine-del/blob/master/pEngine/Audio/Mixing/Mixer.cs


    //         // private Equalizer Equalizer=null!;
    //         // private Filter[] Filters=null!;
    //         // private Effects[] Effects=null!;
}



/// <summary>
/// persone ou objet ou autre qui emet un son( source dans openal)
/// </summary>
public class Emiter//source
{
          //see https://github.com/raysan5/rfxgen/blob/master/src/rfxgen.h
    public struct EmitterParams//WAVE/DATA/RAW PARAMS 
    {
        public string Name;

        public int size;

        // Random seed used to generate the wave
        public int randSeed;

        // Wave type (square, sawtooth, sine, noise)
        public int waveTypeValue;

        // Wave envelope parameters
        public float attackTimeValue;
        public float sustainTimeValue;
        public float sustainPunchValue;
        public float decayTimeValue;

        // Frequency parameters
        public float startFrequencyValue;
        public float minFrequencyValue;
        public float slideValue;
        public float deltaSlideValue;
        public float vibratoDepthValue;
        public float vibratoSpeedValue;
        //float vibratoPhaseDelayValue;

        // Tone change parameters
        public float changeAmountValue;
        public float changeSpeedValue;

        // Square wave parameters
        public float squareDutyValue;
        public float dutySweepValue;

        // Repeat parameters
        public float repeatSpeedValue;

        // Phaser parameters
        public float phaserOffsetValue;
        public float phaserSweepValue;

        // Filter parameters
        public float lpfCutoffValue;
        public float lpfCutoffSweepValue;
        public float lpfResonanceValue;
        public float hpfCutoffValue;
        public float hpfCutoffSweepValue;
 
    }
 
    public uint Id;
    public Vector3 Position;// position de départ en 3D
    public Vector3 Velocity;// vitesse deplacement de la source en 3D
    public float Pitch = 1.0f; // vitesse play
    public float Gain =1.0f; // egal volume
    public bool Loop =false;// repeat
    public bool IsBufferAttached = false;
    public uint BufferID=0;
    //         public uint Order;
//         public int Id;
//         public bool IsPlayable;//indique si l'emitter n'est pas disparu/mort => mise en cache en cas de réutilisation
//         public bool IsPlaying;
//         public long Loop;
//         public float Volume;
//         public float Pitch;
//         public float Pan;
//         public float Reverb;//For effects
        private Source[] Sources = null!;

        // private Buffers[] Buffers = null!;
    // void Play();                                    // Play a sound
    // void Stop(Sound sound);                                    // Stop playing a sound
    // void Pause(Sound sound);                                   // Pause a sound
    // void Resume(Sound sound);                                  // Resume a paused sound
    // all functions add effects .....
    // Create, Cache , dispose , 
}

    public class Buffers
    {
        public enum BufferState{ Compressed, stream, normal, fixe , circular, ring}

        //USe sounds 
        public void Create( BufferState state)
        {
            // Sounds.Decode.ReadPCMFrame();
        }

        public void RingBuffer(){}

        public void CreatePool(){
            //Size
            //id or name
            //used
            // sample, format ,...
            // length
        }
        public struct AudioBuffer<TDataFormat>
        {
            // Buffer sound
            public uint Id = 0;// TODO : ALL Id Are GUID 
            public TDataFormat[] data = null!;
            public int Frequence=0;
            //         public int BufferId;//Pool stream size  name, crop  +>start  end  size
        //         public long SizeKBytes;
        //         public int SampleRate;
        //         public int SampleSize;
        //         public int CurrentPosition;
        //         public int Channel ; //always 1 MOno for 3D sound

            public AudioBuffer()
            {
            }

            // public AudioFormat Format = 0;

            /// <summary>
            /// Tailledu buffer en byte
            /// </summary>
            public int Length => data==null ? 0: data.Length;
        }
    }
    


    /// <summary>
/// Simple wrapper class to decode or encode sound data format ( see namespace) and just play sound 
/// Resource management for loading and streaming sounds.
/// </summary>
public class Sound
{
    public void SimmplePlaySound(Audio.Engine engine, string filename, bool loop)
    {
        //Decode sound
    }

    public static void LoadSound() { }

    public static void WriteSound() { }
    //      Wave LoadWave(const char *fileName);                            // Load wave data from file
    // Wave LoadWaveFromMemory(const char *fileType, const unsigned char *fileData, int dataSize); // Load wave from memory buffer, fileType refers to extension: i.e. '.wav'
    // Sound LoadSound(const char *fileName);                          // Load sound from file
    // Sound LoadSoundFromWave(Wave wave);                             // Load sound from wave data
    // void UpdateSound(Sound sound, const void *data, int sampleCount); // Update sound buffer with new data
    // void UnloadWave(Wave wave);                                     // Unload wave data
    // void UnloadSound(Sound sound);                                  // Unload sound
    // bool ExportWave(Wave wave, const char *fileName);               // Export wave data to file, returns true on success
    // bool ExportWaveAsCode(Wave wave, const char *fileName);         // Export wave sample data to code (.h), returns true on success
}

    /// <summary>
    /// 
    /// A node graph system for advanced mixing and effect processing.
    ///  TODO : like blueprint 
    /// </summary>
    public class NodesGraph
    {
        //See pipeline audio ???? 
    //      void PlaySound(Sound sound);                                    // Play a sound
    // void StopSound(Sound sound);                                    // Stop playing a sound
    // void PauseSound(Sound sound);                                   // Pause a sound
    // void ResumeSound(Sound sound);                                  // Resume a paused sound
    // void PlaySoundMulti(Sound sound);                               // Play a sound (using multichannel buffer pool)
    // void StopSoundMulti(void);                                      // Stop any sound playing (using multichannel buffer pool)
    // int GetSoundsPlaying(void);                                     // Get number of sounds playing in the multichannel
    // bool IsSoundPlaying(Sound sound);                               // Check if a sound is currently playing
    // void SetSoundVolume(Sound sound, float volume);                 // Set volume for a sound (1.0 is max level)
    // void SetSoundPitch(Sound sound, float pitch);                   // Set pitch for a sound (1.0 is base level)
    // void SetSoundPan(Sound sound, float pan);                       // Set pan for a sound (0.5 is center)
    // Wave WaveCopy(Wave wave);                                       // Copy a wave to a new wave
    // void WaveCrop(Wave *wave, int initSample, int finalSample);     // Crop a wave to defined samples range
    // void WaveFormat(Wave *wave, int sampleRate, int sampleSize, int channels); // Convert wave data to desired format
    // float *LoadWaveSamples(Wave wave);                              // Load samples data from wave as a 32bit float data array
    // void UnloadWaveSamples(float *samples);                         // Unload samples data loaded with LoadWaveSamples()

    }


public static class AudioGenerator // TODO : Rename AudioGenerator en AudioNoise  ?
{

    //white

    //pink

    //brownian

    //sine , 

    //square, 

    //triangle, 

    //swtooth

    /// <summary>
    /// Creé un son sinusoidal en fonction de la fréquence 
    /// </summary>
    /// <param name="frequence"> audible 500 à 5000</param>
    /// <param name="sampleRate"> 44100 = 1sec </param>
    /// <param name="amplitude"> max 1.0f </param>
    /// <returns></returns>
    public static short[] SinusWave(float frequence = 1500/* */ , int durationInSec = 1, int sampleRate = 44100, float amplitude = 0.5f)
    {
        int _sampleRate = sampleRate;
        short[] buffer = new short[_sampleRate * durationInSec];
        float _amplitude = amplitude * short.MaxValue;
        float frequency = frequence;
        float dt = Math.Math._2PIf / (float)_sampleRate;
        for (int n = 0; n < buffer.Length; n++)
        {
            buffer[n] = (short)(_amplitude * Math.Math.Sin(n * dt * frequency));
        }
        return buffer;
    }



}

 public static class Convert
    {
        
        /*Sample COnversion 
            S16=> U8 , ...
            ChannelConversion
            ChannelMappiong
        */
    }

    public static class Resampling
    {
        //Algorithm : linear , custom , ...
    }   

    public static class Encode{}

    public static class Decode
    {
        public static void ReadPCMFrame(){}
    }

    /// <summary>
    /// Bruit blanc bruit rose ..
    /// </summary>
    public static class WaveFormGenerator
    {

    }

    public static class NoiseGenerator{
            //white
            //pink
            //brownian
    }

    public static class OGG{}
    public static class WAV{}
    public static class MP3 {}
    public static class FLAC{}
    public static class XM{}
    public static class Midi{}
    public static class OPUS{}
    public static class MOD{}



/// <summary>
/// Class de base pour jouer un son stéréo à valeur de test
/// </summary>
public unsafe sealed class PlayerSound2D : IDisposable
{
    private string filename=string.Empty;
    // private XAUDIO2_BUFFER Buffer= new();
    // private WAVEFORMATEX wfx=new();
    private IXAudio2SourceVoice* Sourcevoice = null;
    // private byte[] Data= null!;
    // private uint Size =0;

    public PlayerSound2D(){}
    public void Init( AudioData* audiodevice, string filename )
    {
        Log.Info("Init Source Win32");
            
            //  DECODE WAV 
            WaveReader wav = new( filename );
            wav.ReadHeader();
            //use own readfile wav ?
            // uint wavSizeInBytes = wav.DataSize;
            uint Size =  wav.DataSize;
            byte[] Data =new byte[Size];
            wav.ReadChunk(ref Data, Size);
            Log.Info(wav.ToString());
     
            // CREATE SOURCE
            WAVEFORMATEX wfx=new();
            wfx.cbSize =0;//no extra info
            wfx.nChannels = (ushort)wav.Nbrcanaux; // 1;//2 = stereo
            wfx.nSamplesPerSec = wav.Frequence; // 44100;
            wfx.wBitsPerSample =(ushort)wav.BitsPerSample;//16; //8 or 24 or 32
            wfx.nBlockAlign = (ushort)wav.BytePerBloc;
            wfx.nAvgBytesPerSec = wav.BytePerSec;// wfx.nBlockAlign * wfx.nSamplesPerSec;
            wfx.wFormatTag =(ushort)wav.AudioFormat ;// (ushort)wav.AudioFormat;// 3;//WAVE_FORMAT_PCM;? see list ?
            
            //CREATE BUFFER AND SATTACH TO SOURC
            XAUDIO2_BUFFER buffer= new();
            buffer.AudioBytes = Size;

            fixed( byte* bytes = &Data[0] ){
                buffer.pAudioData = bytes;
            }
            buffer.Flags = AudioConsts.XAUDIO2_END_OF_STREAM;

            // Buffer.LoopBegin =1 ;
            // Buffer.LoopLength =0;
            // Buffer.LoopCount =XAUDIO2_LOOP_INFINITE;
            // Buffer.pContext = null;
            IXAudio2SourceVoice* sourcevoice = null;
            uint err = audiodevice->AudioInstance->CreateSourceVoice( &sourcevoice , &wfx );

            Sourcevoice = Memory.Memory.New<IXAudio2SourceVoice>( false );
            IXAudio2SourceVoice temp = new IXAudio2SourceVoice(sourcevoice);
            Memory.Memory.Copy(Memory.Memory.ToPtr(ref temp), Sourcevoice, (uint)Memory.Memory.Size<IXAudio2SourceVoice>() ); 
           Log.Info ($"Create Source voice Error Code : {err} ");

            err = sourcevoice->SubmitSourceBuffer( &buffer ,null);
            Log.Info ($"Submit source buffer  Error Code : {err} ");   
    }
    
    
    public unsafe static  uint CreateSource2D(AudioData* data  ,  string filename )
    {
        Log.Info("Init Source Win32");
        // sounds->SoundData = data->MemoryPool->Add<WavSoundData>();

        // ResultSound.re
        // var context = audiodevice.GetData();
        //  DECODE WAV 
        // WavSound wav = new( filename, sounds->SoundData ,  sounds->MemorySoundBuffer );
       
        // WAVEFORMATEX wfx = new()
        // {
        //     cbSize = 0,//no extra info
        //     nChannels =2,//  sounds->SoundData->Nbrcanaux, // 1;//2 = stereo
        //     nSamplesPerSec = 44100,// sounds->SoundData->Frequence, // 44100;
        //     wBitsPerSample = 16,// sounds->SoundData->BitsPerSample,//16; //8 or 24 or 32
        //     nBlockAlign = 4,// sounds->SoundData->BytePerBloc,
        //     nAvgBytesPerSec =  176400,//sounds->SoundData->BytePerSec,// wfx.nBlockAlign * wfx.nSamplesPerSec;
        //     wFormatTag = 1 ,//sounds->SoundData->AudioFormat// (ushort)wav.AudioFormat;// 3;//WAVE_FORMAT_PCM;? see list ?
        // };

        // IXAudio2SourceVoice* sourcevoice = null;
        
        // uint err = data->Instance->CreateSourceVoice( &sourcevoice , &wfx );

        // sounds->Sourcevoice = data->MemoryPool->Add( new IXAudio2SourceVoice(sourcevoice));
    
        // Log.Info ($"Create Source voice Error Code : {err} adr : 0X{(long)sounds->Sourcevoice:X}");

        // // byte[] Data =new byte[ wav.Data.DataSize];
        // // wav.ReadChunk(ref Data,  wav.Data.DataSize);
        // // wav.ReadData(sounds->SoundData,  sounds->MemorySoundBuffer) ;
        
        // var bytes = System.IO.File.ReadAllBytes( filename) ;
        // sounds->SoundData->Data =  sounds->MemorySoundBuffer->Add(sounds->SoundData->Data ,(uint)bytes.Length);
        // // var bytesSnd = new byte[data->DataSize ];
        // // data->Data = Mem.New<byte>(data->DataSize , sizeof(byte) , true);
        // for (int i = 0; i < bytes.Length ; i++)
        // {
        //    sounds->SoundData->Data[i] = bytes[i];
        //     // bytesSnd[i] = data->Data[i] ;
        // }

        // //CREATE BUFFER AND SATTACH TO SOURC
        // XAUDIO2_BUFFER Buffer = new()
        // {
        //     AudioBytes =(uint)bytes.Length,// sounds->SoundData->DataSize,
        //     Flags = XAUDIO2.XAUDIO2_END_OF_STREAM,
        //     pAudioData = sounds->SoundData->Data
        //     // LoopBegin =1 ,
        //     // LoopLength =0,
        //     // LoopCount =XAUDIO2_LOOP_INFINITE,
        //     // pContext = null,
        // };

        // err = sounds->Sourcevoice->SubmitSourceBuffer(&Buffer);
        // Log.Info ($"Submit source buffer  Error Code : {err} "); 

        // wav.Dispose();
        return 0;  
    }
    // public static void PlaySource(uint source, SoundsDataWin64* sounds)=> sounds->Sourcevoice->Start();
    // public static void StopSource(uint source, SoundsDataWin64* sounds)=> sounds->Sourcevoice->Stop(); //sounds->Sourcevoice[source ]->Stop();


    // static float ClampBetweenZeroPlusOne(float volume )=>volume < 0.0f ? 0.0f: volume > 1.0f? 1.0f: volume ;

    public void PlaySource() => Sourcevoice->Start();
    public void Stop()=> Sourcevoice->Stop();

    public void Dispose()
    {
        Log.Info(" Dispose PlayerSound2D");
        Sourcevoice->Stop();
        Sourcevoice->DestroyVoice();

        GC.SuppressFinalize(this);
    }
}

/// <summary>
/// Simple class lecture fichier wav
/// </summary>
public sealed class WaveReader  : IDisposable
{
    /// <summary> . </summary>
    public const uint WAVE_RIFF_LE = 0x46464952 ; // Constante RIFF RIFF�  (0x52,0x49,0x46,0x46) LE = little endian et BE big endian ....
    /// <summary> . </summary>
    public const uint WAVE_WAVE_LE = 0x45564157 ; // Format = �WAVE�  (0x57,0x41,0x56,0x45)
    /// <summary> . </summary>
    public const uint WAVE_FMT_LE  = 0x20746D66 ; // Identifiant �fmt �  (0x66,0x6D, 0x74,0x20)
    /// <summary> . </summary>
    public const uint WAVE_DATA_LE = 0x61746164 ; //Constante �data�  (0x64,0x61,0x74,0x61)

    /// <summary>  FileSize (4 octets) : Taille du fichier moins 8 octets </summary>
    public uint FileSize =0;      
    /// <summary> BlocSize  (4 octets) : Nombre d'octets du bloc - 16  (0x10)Chunk Size </summary>
    public uint BlocSize =0;   
    /// <summary> Frequence      (4 octets) : Fréquence d'échantillonnage (en hertz) [Valeurs standardis�es : 11025, 22050, 44100 et éventuellement 48000 et 96000] </summary>
    public uint Frequence =0;    
    /// <summary> Nombre d'octets à lire par seconde (i.e., Frequence * BytePerBloc). </summary>
    public uint Octetparseconde =0; 
    /// <summary> BytePerSec  (4 octets) : Nombre d'octets � lire par seconde (i.e., Frequence * BytePerBloc). </summary>
    public uint BytePerSec=0 ; 
    /// <summary> DataSize  (4 octets) : Nombre d'octets des donn�es (i.e. "Data[]", i.e. taille_du_fichier - taille_de_l'ent�te  (qui fait 44 octets normalement). </summary>
    public uint DataSize   =0;   
    /// <summary> BytePerBloc     (2 octets) : Nombre d'octets par bloc d'�chantillonnage (i.e., tous canaux confondus : NbrCanaux * BitsPerSample/8). </summary>
    public short BytePerBloc =0;  
    /// <summary> BitsPerSample(2 octets) : Nombre de bits utilis�s pour le codage de chaque �chantillon (8, 16, 24) </summary>
    public short BitsPerSample =0; 
    /// <summary> AudioFormat     (2 octets) : Format du stockage dans le fichier (1: PCM, 2: ADPCM  , ...) </summary>
    public short AudioFormat =0;       
    /// <summary> Channels  NbrCanaux (2 octets) : Nombre de canaux (de 1 à 6, cf. ci-dessous ). </summary>
    public short Nbrcanaux =0;  


    // public BasicWavData Data = new();
    private string _filename ;
    private readonly System.IO.FileStream fs;
    /// <summary> . </summary>
    public WaveReader(string filename)
    {
        fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        _filename = filename;
    }
    
    private byte Byte() => System.Convert.ToByte(fs!.ReadByte());
    private sbyte SByte() => System.Convert.ToSByte(fs!.ReadByte());
    private uint UInt() => (uint)( (Byte() + (Byte() << 8) ) + ( (Byte() + (Byte() << 8)) << 16));
    private short Short() => (short)(SByte() + (SByte() << 8));
    private void Bytes(ref byte[] buffer, in int size)
    {
        for (int i = 0; i < size; i++)
            buffer[i] = Byte();
    }
    
    /// <summary> . </summary>
    public void ReadHeader()
    {
        if( UInt() != WAVE_RIFF_LE) return;
        
        FileSize = UInt();

        if( UInt() != WAVE_WAVE_LE )return;

        if( UInt() != WAVE_FMT_LE )return;

        BlocSize = UInt();
        AudioFormat = Short();
        Nbrcanaux = Short();
        Frequence = UInt();
        BytePerSec = UInt();
        BytePerBloc = Short();
        BitsPerSample = Short();

        if( UInt() != WAVE_DATA_LE )return;
   
        DataSize  = UInt() -44 ;
        Octetparseconde =   Frequence * (uint)BytePerBloc ;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="size"></param>
    public void ReadChunk(ref byte[] buffer, uint size )
    {
        Bytes(ref buffer, (int)size);
    }

    public override string ToString()
    {
        string result = $"wav :[{ FileSize} kb] {_filename}";
        result +=$"\n\tFrequence : {Frequence}Hz \n\tOctets Par Seconde : {Octetparseconde} \n\tBytes par Seconde : {BytePerSec} \n\tNombre de canaux : {Nbrcanaux}";
        result +=$"\n\tData size : {DataSize}Hz \n\tFormat Tag : {AudioFormat } \n\tBit par Samples : {BitsPerSample} (8,16,24)\n\tBytes par bloc : {BytePerBloc}";   
        return result;
    }

    public void Dispose()
    {
        fs!.Close();
        fs.Dispose();
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