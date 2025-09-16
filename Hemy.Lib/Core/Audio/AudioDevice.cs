namespace Hemy.Lib.Core.Audio;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#if WINDOWS
using Hemy.Lib.Core.Platform.Windows.Audio;
#endif

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe sealed class AudioDevice(
#if WINDOWS
    AudioData* audioData
#endif    
    )
{

    public void SetVolume(float volume)
    {
#if WINDOWS
        Hemy.Lib.Core.Platform.Windows.Audio.AudioImpl.SetVolume(audioData, volume);
#endif
    }

    public Sound2D GetSound2D()
    {
        return new Sound2D(audioData);
    }

}