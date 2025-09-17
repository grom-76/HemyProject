namespace Hemy.Lib.Core.IO;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#if WINDOWS
using Hemy.Lib.Core.Platform.Windows.IO;
#endif


[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
[Obsolete]
public unsafe struct BinaryFileReader()
{
#if WINDOWS
	IoFileData* _data = Memory.Memory.New<IoFileData>(true);
#endif
	byte* Buffer = null;
	int* BufferPosition = null;
	uint BufferSize = 0;

	public enum Mode : uint
	{
		Begin = IoFileRWImpl.SEEK_BEGIN,
		End= IoFileRWImpl.SEEK_END,
		Current= IoFileRWImpl.SEEK_CURRENT,
	}

	public void Open(string filename)
	{
		if (!Files.Exist(filename))
		{
			Log.Error($"File {filename} Not exist");
			return;
		}
#if WINDOWS
		IoFileRWImpl.Open(_data, filename);
#endif
	}

	public void Close()
	{
#if WINDOWS		
		IoFileRWImpl.Close(_data);
#endif

		Memory.Memory.Dispose(_data);
		_data = null;
		Memory.Memory.DisposeArray(Buffer);
		Buffer = null;
	}

	public void ReadChunk(uint size)
	{
		if (size > BufferSize) return;

		if (Buffer != null)
		{
			Memory.Memory.DisposeArray(Buffer);
			Buffer = null;
		}
		Buffer = Memory.Memory.NewArray<byte>(size);

		*BufferPosition = 0;
		BufferSize = size;

#if WINDOWS
		_ = IoFileRWImpl.Read(_data, Buffer, size);
#endif

	}

	public void Seek(long offset, Mode mode)
	{
#if WINDOWS
		IoFileRWImpl.Seek(_data, offset, (uint)mode);
#endif
	}

	public readonly byte Byte()
#if WINDOWS	
	=> IoFileRWImpl.Byte(Buffer, BufferPosition);
#endif

	public readonly sbyte SByte() => IoFileRWImpl.SByte(Buffer, BufferPosition);
	public readonly uint UInt() => IoFileRWImpl.UInt(Buffer, BufferPosition);
	public readonly int Int() => IoFileRWImpl.Int(Buffer, BufferPosition);
	public readonly long Long() => IoFileRWImpl.Long(Buffer, BufferPosition);
	public readonly ulong ULong() => IoFileRWImpl.ULong(Buffer, BufferPosition);
	public readonly short Short() => IoFileRWImpl.Short(Buffer, BufferPosition);
	public readonly ushort UShort() => IoFileRWImpl.UShort(Buffer, BufferPosition);
}


