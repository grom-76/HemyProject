#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.IO;


using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// [SkipLocalsInit]
// [StructLayout(LayoutKind.Sequential)]
// internal unsafe struct FileData()
// {
//     internal long FileSize = 0;
//     internal uint ChunkSize = 4096;
//     internal uint Position = 0;
//     internal void* FileHandle = null;
//     internal delegate* unmanaged<uint, uint, OVERLAPPED*, void> LpoverlappedCompletionRoutine = null;
//     internal byte* Chunk = null;
//     // internal byte* Filename = null;  //filename fileSize 
// }

#endif