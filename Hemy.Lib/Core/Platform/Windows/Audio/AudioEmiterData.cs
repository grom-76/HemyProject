#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Audio;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct AudioEmiterData()
{
	internal IXAudio2SourceVoice* Sourcevoice = null;

	internal int BufferAttach = -1; //if -1 no attach  if >= 0 equal ID buffer 

	internal AudioEmiterState State = AudioEmiterState.notready;
}

internal enum AudioEmiterState
{
	notready,
	playing,
	stop,
}
#endif