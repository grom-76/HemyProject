#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Audio;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct AudioEmiter()
{
  internal IXAudio2SourceVoice* Sourcevoice = null;

        internal int BufferAttach = -1; //if -1 no attach  if >= 0 equal ID buffer 


        internal static void CreateEmiter( AudioData* audioData , AudioEmiter* audioEmiter, AudioBuffer* AudioBuffer  )
        {
            // Create source voice  for emitter 

            audioEmiter->Sourcevoice = Memory.Memory.New<IXAudio2SourceVoice>(false);
            IXAudio2SourceVoice* svoice = null;

            uint err = audioData->AudioInstance->CreateSourceVoice(&svoice, AudioBuffer->wavformat);


            IXAudio2SourceVoice temp = new IXAudio2SourceVoice(svoice);

            Memory.Memory.Copy(Memory.Memory.ToPtr(ref temp), audioEmiter->Sourcevoice, (uint)Memory.Memory.Size<IXAudio2SourceVoice>());
            Log.Info($"Create Source voice Error Code : {err} ");

        }

        internal static void UpdateEmiter(AudioEmiter* audioEmiter ,  AudioBuffer* audioBuffer )
        {
            XAUDIO2_VOICE_STATE state = default;
            state.pCurrentBufferContext = audioBuffer->buffer;
            audioEmiter->Sourcevoice->GetState(&state, 0);
        }

        internal static void PlayEmiter(AudioEmiter* audioEmiter)
        {
            XAUDIO2_VOICE_STATE state = default;
            audioEmiter->Sourcevoice->GetState(&state);

            if (audioEmiter->BufferAttach == -1 || state.BuffersQueued==0 ) return;

            audioEmiter->Sourcevoice->Start();
        }
        internal static void StopEmiter( AudioEmiter* audioEmiter)
        {
            audioEmiter->Sourcevoice->Start();
        }

        internal static void DisposeEmiter( AudioEmiter* audioEmiter )
        {
            audioEmiter->Sourcevoice->Stop();
            audioEmiter->Sourcevoice->DestroyVoice();

            Memory.Memory.Dispose(audioEmiter->Sourcevoice);
        }


}

#endif