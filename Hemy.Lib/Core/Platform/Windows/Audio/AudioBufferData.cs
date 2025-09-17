#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Audio;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Hemy.Lib.Tools.Sound;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct AudioBufferData()
{
        internal XAUDIO2_BUFFER* buffer = null;
        internal WAVEFORMATEX* wavformat = null;//wfx
        internal byte* RawData = null;

}

#endif