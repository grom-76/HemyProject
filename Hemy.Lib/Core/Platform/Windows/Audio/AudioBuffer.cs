#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Audio;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Hemy.Lib.Tools.Sound;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct AudioBuffer()
{
        internal XAUDIO2_BUFFER* buffer = null;
        internal WAVEFORMATEX* wavformat = null;//wfx
        internal byte* RawData = null;

        internal static void LoadWaveFromFileInBuffer( AudioBuffer* audioBuffer , string filename)
        {
            //  DECODE WAV 
            using LazyWaveReader wav = new(filename);
            wav.ReadHeader();


            uint Size = wav.DataSize;
            byte[] Data = new byte[Size];
            wav.ReadChunk(ref Data, Size);
            Log.Info(wav.ToString());

            // CREATE SOURCE
            // WAVEFORMATEX wfx = new();
            audioBuffer->wavformat->cbSize = 0;//no extra info
            audioBuffer->wavformat->nChannels = (ushort)wav.Nbrcanaux; // 1;//2 = stereo
            audioBuffer->wavformat->nSamplesPerSec = wav.Frequence; // 44100;
            audioBuffer->wavformat->wBitsPerSample = (ushort)wav.BitsPerSample;//16; //8 or 24 or 32
            audioBuffer->wavformat->nBlockAlign = (ushort)wav.BytePerBloc;
            audioBuffer->wavformat->nAvgBytesPerSec = wav.BytePerSec;// wfx.nBlockAlign * wfx.nSamplesPerSec;
            audioBuffer->wavformat->wFormatTag = (ushort)wav.AudioFormat;// (ushort)wav.AudioFormat;// 3;//WAVE_FORMAT_PCM;? see list ?
            
            audioBuffer->buffer->AudioBytes = Size;
            audioBuffer->buffer->LoopBegin =1 ;
            audioBuffer->buffer->LoopLength =0;
            audioBuffer->buffer->LoopCount = AudioConsts.XAUDIO2_LOOP_INFINITE;
            audioBuffer->buffer->pContext = null;
            audioBuffer->buffer->Flags = AudioConsts.XAUDIO2_END_OF_STREAM;

            fixed (byte* bytes = &Data[0])
            {
                audioBuffer->buffer->pAudioData = bytes;
            }          

        }

        internal void AttachBufferToEmitter(AudioEmiter* audioEmiter ,  AudioBuffer* audioBuffer )
        {
            var err = audioEmiter->Sourcevoice->SubmitSourceBuffer(audioBuffer->buffer, null);
            Log.Info($"Submit source buffer  Error Code : {err} ");
        }

        internal void DettachBufferFromEmiter(AudioEmiter* audioEmiter  )
        {
            var err = audioEmiter->Sourcevoice->FlushSourceBuffers();
            Log.Info($"Submit source buffer  Error Code : {err} ");
        }

        internal void DisposeBuffer(AudioBuffer* audioBuffer)
        {
            Memory.Memory.Dispose(audioBuffer->buffer);
            Memory.Memory.Dispose(audioBuffer->wavformat);
            Memory.Memory.Dispose(audioBuffer->RawData);
        }
}

#endif