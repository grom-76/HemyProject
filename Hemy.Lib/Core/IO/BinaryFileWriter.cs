namespace Hemy.Lib.Core.IO;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


#if WINDOWS
using Hemy.Lib.Core.Platform.Windows.IO;
#endif

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal unsafe struct BinaryFileWriter()
{

#if WINDOWS
	FileData* _data = null;
#endif

	internal void Open(string filename, uint chunksize = 0)
	{
		_data = Memory.Memory.New<FileData>(true);

		if (!Files.Exist(filename))
		{
			// Log.Error($"File {filename} Not exist");
			// return;
			// TODO CreateFile ????
		}

		IoImpl.OpenFileWrited(_data, filename, chunksize);
	}

	internal void Close()
	{
		IoImpl.CloseFile(_data);

		Memory.Memory.Dispose(_data);

		_data = null;
	}

}


