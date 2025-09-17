namespace Hemy.Lib.Core.Audio;

using System;
using Hemy.Lib.Core.Platform.Windows.Audio;
using Hemy.Lib.Tools.Sound;

/// <summary>
/// Class de base pour jouer un son stéréo à valeur de test
/// </summary>
public unsafe readonly struct Sound2D(
#if WINDOWS    
    AudioData* audioData
#endif
    ) 
{

#if WINDOWS
    private readonly Hemy.Lib.Core.Platform.Windows.Audio.AudioBufferData* _buffer = Memory.Memory.New<AudioBufferData>();
    private readonly Hemy.Lib.Core.Platform.Windows.Audio.AudioEmiterData* _emiter= Memory.Memory.New<AudioEmiterData>();
#endif

    public float Volume
    {
        get => GetVolume();
        set => SetVolume(value);
    }
    public void CreateFromFile(string filename)
    {
#if WINDOWS
        AudioResourceImpl.CreateBufferFromWavFile(_buffer, filename);
        AudioResourceImpl.CreateEmiter(audioData, _emiter, _buffer);
        AudioResourceImpl.AttachBufferToEmitter(_emiter, _buffer);
#endif
    }

    public void Update()
    {
#if WINDOWS
        AudioResourceImpl.UpdateEmiter(_emiter, _buffer);
#endif        
    }
    public void SetVolume(float volume)
    {
#if WINDOWS
        AudioResourceImpl.EmiterSetVolume(_emiter, volume);
#endif        
    }

    public void SetSound()
    {
        
    }   

    public float GetVolume()
    {
#if WINDOWS
        return AudioResourceImpl.EmiterGetVolume(_emiter);
#endif        
    }

    public void Play()
    {
#if WINDOWS
        AudioResourceImpl.PlayEmiter(_emiter);
#endif        
    }
    
    public void Stop()
    {
#if WINDOWS
        AudioResourceImpl.StopEmiter(_emiter);
#endif        
    }

    public void Dispose()
    {
        Stop();
#if WINDOWS
        AudioResourceImpl.DisposeEmiter(_emiter);
        AudioResourceImpl.DisposeBuffer(_buffer);

        Memory.Memory.Dispose(_emiter);
        Memory.Memory.Dispose(_buffer);
#endif

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
