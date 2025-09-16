namespace Hemy.Lib.Core.Audio;

using System;
using Hemy.Lib.Core.Platform.Windows.Audio;

/// <summary>
/// Class de base pour jouer un son stéréo à valeur de test
/// </summary>
public unsafe sealed class Sound2D : IDisposable
{
    private string filename = string.Empty;
    // private XAUDIO2_BUFFER Buffer= new();
    // private WAVEFORMATEX wfx=new();
    private IXAudio2SourceVoice* Sourcevoice = null;
    // private byte[] Data= null!;
    // private uint Size =0;

    public Sound2D() { }
    public void Init(AudioData* audiodevice, string filename)
    {
        Log.Info("Init Source Win32");

        //  DECODE WAV 
        LazyWaveReader wav = new(filename);
        wav.ReadHeader();
        //use own readfile wav ?
        // uint wavSizeInBytes = wav.DataSize;
        uint Size = wav.DataSize;
        byte[] Data = new byte[Size];
        wav.ReadChunk(ref Data, Size);
        Log.Info(wav.ToString());

        // CREATE SOURCE
        WAVEFORMATEX wfx = new();
        wfx.cbSize = 0;//no extra info
        wfx.nChannels = (ushort)wav.Nbrcanaux; // 1;//2 = stereo
        wfx.nSamplesPerSec = wav.Frequence; // 44100;
        wfx.wBitsPerSample = (ushort)wav.BitsPerSample;//16; //8 or 24 or 32
        wfx.nBlockAlign = (ushort)wav.BytePerBloc;
        wfx.nAvgBytesPerSec = wav.BytePerSec;// wfx.nBlockAlign * wfx.nSamplesPerSec;
        wfx.wFormatTag = (ushort)wav.AudioFormat;// (ushort)wav.AudioFormat;// 3;//WAVE_FORMAT_PCM;? see list ?

        //CREATE BUFFER AND SATTACH TO SOURC
        XAUDIO2_BUFFER buffer = new();
        buffer.AudioBytes = Size;

        fixed (byte* bytes = &Data[0])
        {
            buffer.pAudioData = bytes;
        }
        buffer.Flags = AudioConsts.XAUDIO2_END_OF_STREAM;

        // Buffer.LoopBegin =1 ;
        // Buffer.LoopLength =0;
        // Buffer.LoopCount =XAUDIO2_LOOP_INFINITE;
        // Buffer.pContext = null;

        IXAudio2SourceVoice* sourcevoice = null;
        uint err = audiodevice->AudioInstance->CreateSourceVoice(&sourcevoice, &wfx);

        Sourcevoice = Memory.Memory.New<IXAudio2SourceVoice>(false);
        IXAudio2SourceVoice temp = new IXAudio2SourceVoice(sourcevoice);
        Memory.Memory.Copy(Memory.Memory.ToPtr(ref temp), Sourcevoice, (uint)Memory.Memory.Size<IXAudio2SourceVoice>());
        Log.Info($"Create Source voice Error Code : {err} ");

        err = sourcevoice->SubmitSourceBuffer(&buffer, null);
        Log.Info($"Submit source buffer  Error Code : {err} ");
    }

    public void PlaySource() => Sourcevoice->Start();
    public void Stop() => Sourcevoice->Stop();

    public void Dispose()
    {
        Log.Info(" Dispose PlayerSound2D");
        Sourcevoice->Stop();
        Sourcevoice->DestroyVoice();

        GC.SuppressFinalize(this);
    }

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
