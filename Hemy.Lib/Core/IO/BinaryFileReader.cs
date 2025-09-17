namespace Hemy.Lib.Core.IO;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#if WINDOWS
using Hemy.Lib.Core.Platform.Windows.IO;
#endif

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal unsafe struct BinaryFileReader()
{
#if WINDOWS
	FileData* _data = null;
#endif

	internal void Open(string filename, uint chunksize = 0)
	{
		_data = Memory.Memory.New<FileData>(true);

		if (!Files.Exist(filename))
		{
			Log.Error($"File {filename} Not exist");
			return;
		}

		IoImpl.OpenFileRead(_data, filename, chunksize);
	}

	internal void Close()
	{
		IoImpl.CloseFile(_data);

		Memory.Memory.Dispose(_data->Chunk);
		Memory.Memory.Dispose(_data);

		_data = null;
	}
	internal readonly byte* ReadChunk(uint size)
	{
		IoImpl.ReadHeader(_data, size);
		return _data->Chunk;
	}

	internal readonly byte Byte() => IoImpl.ReadChar(_data);
	internal readonly sbyte SByte() => (sbyte)Byte();
	internal readonly uint UInt() => (uint)(Byte() + (Byte() << 8) + ((Byte() + (Byte() << 8)) << 16));
	internal readonly short Short() => (short)(SByte() + (SByte() << 8));
}


