#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Audio;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using HRESULT = System.UInt32;
using Hemy.Lib.Core.Sys;
using static Hemy.Lib.Core.Platform.Windows.Common.LibrariesName;
using Hemy.Lib.Core;
using Hemy.Lib.Tools.Sound;
using System;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static class AudioResourceImpl
{
    internal static void CreateBufferFromWavFile(AudioBufferData* audioBuffer, string filename)
    {
        audioBuffer->buffer = Memory.Memory.New<XAUDIO2_BUFFER>();
        audioBuffer->wavformat = Memory.Memory.New<WAVEFORMATEX>(); 

        using LazyWaveReader wav = new();
        wav.ReadHeader(filename);

        audioBuffer->RawData = Memory.Memory.NewArray<byte>(wav.Data.DataSize);
        wav.ReadChunk(audioBuffer->RawData);

        audioBuffer->wavformat->cbSize = 0;//no extra info
        audioBuffer->wavformat->nChannels = (ushort)wav.Data.Nbrcanaux; // 1;//2 = stereo
        audioBuffer->wavformat->nSamplesPerSec = wav.Data.Frequence; // 44100;
        audioBuffer->wavformat->wBitsPerSample = (ushort)wav.Data.BitsPerSample;//16; //8 or 24 or 32
        audioBuffer->wavformat->nBlockAlign = (ushort)wav.Data.BytePerBloc;
        audioBuffer->wavformat->nAvgBytesPerSec = wav.Data.BytePerSec;// wfx.nBlockAlign * wfx.nSamplesPerSec;
        audioBuffer->wavformat->wFormatTag = (ushort)wav.Data.AudioFormat;// (ushort)wav.AudioFormat;// 3;//WAVE_FORMAT_PCM;? see list ?


        audioBuffer->buffer->AudioBytes = wav.Data.DataSize;
        audioBuffer->buffer->Flags = AudioConsts.XAUDIO2_END_OF_STREAM;
        audioBuffer->buffer->pAudioData =audioBuffer->RawData;
        audioBuffer->buffer->LoopBegin = 0;
        audioBuffer->buffer->LoopLength = 44100*10;
        audioBuffer->buffer->LoopCount = AudioConsts.XAUDIO2_LOOP_INFINITE;
        audioBuffer->buffer->pContext = null;

        wav.Dispose();
    }

    internal static void SetBuffer()
    {

    }

    internal static void AttachBufferToEmitter(AudioEmiterData* audioEmiter, AudioBufferData* audioBuffer)
    {
        var err = audioEmiter->Sourcevoice->SubmitSourceBuffer(audioBuffer->buffer, null);
        audioEmiter->State = AudioEmiterState.stop;

        if (err != 0)
            Log.Error($"Submit source buffer  Error Code : {err} ");
    }

    internal static void DettachBufferFromEmiter(AudioEmiterData* audioEmiter)
    {
        var err = audioEmiter->Sourcevoice->FlushSourceBuffers();
        // Log.Info($"Submit source buffer  Error Code : {err} ");
    }

    internal static void DisposeBuffer(AudioBufferData* audioBuffer)
    {
        Memory.Memory.Dispose(audioBuffer->buffer);
        Memory.Memory.Dispose(audioBuffer->wavformat);
        Memory.Memory.DisposeArray(audioBuffer->RawData);   
    }
        
    internal static void CreateEmiter( AudioData* audioData , AudioEmiterData* audioEmiter, AudioBufferData* AudioBuffer  )
    {
        // Create source voice  for emitter 

        audioEmiter->Sourcevoice = Memory.Memory.New<IXAudio2SourceVoice>(false);

        IXAudio2SourceVoice* svoice = null;

        uint err = audioData->AudioInstance->CreateSourceVoice(&svoice, AudioBuffer->wavformat);


        IXAudio2SourceVoice temp = new IXAudio2SourceVoice(svoice);

        Memory.Memory.Copy(Memory.Memory.ToPtr(ref temp), audioEmiter->Sourcevoice, (uint)Memory.Memory.Size<IXAudio2SourceVoice>());
        Log.Info($"Create Source voice Error Code : {err} ");

    }

    internal static void UpdateEmiter(AudioEmiterData* audioEmiter, AudioBufferData* audioBuffer)
    {
        XAUDIO2_VOICE_STATE state = default;
        // state.pCurrentBufferContext = audioBuffer->buffer;
        audioEmiter->Sourcevoice->GetState(&state, 0);

        if (state.BuffersQueued == 0)
        {
            audioEmiter->State = AudioEmiterState.stop;
            var err = audioEmiter->Sourcevoice->Discontinuity();
            if (err != 0)
                Log.Error(" Discontinuity ");
        }
            

        // execute command  if (state != playing) command = PLay() 
        // execute command  Stop()
        // ecexute command SetVolume 
        // execute command Empty Void(){} 

        // when finish reset : Command = Empty();
    }

    internal static void EmiterSetVolume(AudioEmiterData* audioEmiter, float volume)
    {       
       // Send Command SetVolume 

        audioEmiter->Sourcevoice->SetVolume(volume);
    }

    internal static float EmiterGetVolume(AudioEmiterData* audioEmiter)
    {
        // Send Command SetVolume 
        float volume = 0.0f;
        audioEmiter->Sourcevoice->GetVolume(&volume);
        return volume;
    }

    internal static void PlayEmiter(AudioEmiterData* audioEmiter)
    {
        // Send Command Start 
        if (audioEmiter->State == AudioEmiterState.playing || audioEmiter->State == AudioEmiterState.notready) return;

        audioEmiter->Sourcevoice->Start();
    }
    internal static void StopEmiter( AudioEmiterData* audioEmiter)
    {
        // Send Command Stop
        audioEmiter->Sourcevoice->Stop();
    }

    internal static void DisposeEmiter( AudioEmiterData* audioEmiter )
    {
        audioEmiter->Sourcevoice->Stop();
        audioEmiter->Sourcevoice->DestroyVoice();

        Memory.Memory.Dispose(audioEmiter->Sourcevoice);
    }

}

#endif