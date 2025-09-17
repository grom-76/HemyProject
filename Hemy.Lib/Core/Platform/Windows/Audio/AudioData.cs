#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Audio;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct AudioData()
{
    internal nint AudioModule = 0;
    // internal XAudio_Version Version = XAudio_Version.Unknown;
    // internal float Volume = 1.0f;
    // internal uint ChannelMask = 0;
    // internal uint Channels = 0;
    // internal uint SampleRate = 0;
    // internal float SpeedOfSound = 345.0f;
    internal IXAudio2* AudioInstance = null;
    internal IXAudio2MasteringVoice* MasterVoice = null;
    // internal IXAudio2Voice* VoiceDetails = null;
    // internal XAUDIO2_PERFORMANCE_DATA* Performance = null;

    internal XAUDIO2_DEBUG_CONFIGURATION* Debug;
    internal X3DAUDIO_HANDLE* Handle3D;
}



#endif
