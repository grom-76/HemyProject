#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.IO;


using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using HRESULT = System.UInt32;
using static Hemy.Lib.Core.Platform.Windows.Common.LibrariesName;


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static partial class IoImpl
{
	
	// delegate void PFN_FileIOCompletionRoutine(DWORD dwErrorCode, DWORD dwNumberOfBytesTransfered, OVERLAPPED* lpOverlapped);

	// internal static void OpenFileRead(FileData* data, string filename, uint chunksize)
	// {
	// 	// data->Chunk = null;
	// 	// data = WindowsMemory.NewStruct<BinaryFileData>();0x000001ea23482318
	// 	data->FileSize = 0;
	// 	data->ChunkSize = chunksize;
	// 	data->Position = 0;
	// 	data->FileHandle = null;
	// 	data->LpoverlappedCompletionRoutine = null;
	// 	data->Chunk = null;

	// 	//Setdata????

	// 	var strfile = Memory.Memory.NewStr(filename);

	// 	// src : https://learn.microsoft.com/en-us/windows/win32/fileio/opening-a-file-for-reading-or-writing
	// 	data->FileHandle = CreateFileA(strfile,                // name of the write
	// 				   GENERIC_READ,          // open for writing
	// 				   FILE_SHARE_READ,                      // do not share
	// 				   null,                   // default security
	// 				   OPEN_EXISTING,             // create new file only
	// 				   FILE_ATTRIBUTE_NORMAL | FILE_FLAG_OVERLAPPED,  // normal file
	// 				   null);                  // no attr. template

	// 	// Log.Check(data->FileHandle == null, "Error opening file ");

	// 	 Memory.Memory.DisposeStr(strfile);

	// 	_ = GetFileSizeEx(data->FileHandle, &data->FileSize);

	// 	if (data->ChunkSize != 0)
	// 		ReadHeader(data, 4096);
	// }

	// internal static void OpenFileWrited(FileData* data, string filename, uint headersize)
	// {
	// 	// data->Chunk = null;
	// 	// data = WindowsMemory.NewStruct<BinaryFileData>();0x000001ea23482318
	// 	data->FileSize = 0;
	// 	data->ChunkSize = headersize;
	// 	data->Position = 0;
	// 	data->FileHandle = null;
	// 	data->LpoverlappedCompletionRoutine = null;
	// 	data->Chunk = null;

	// 	//Setdata????

	// 	var strfile = Memory.Memory.NewStr(filename);

	// 	// src : https://learn.microsoft.com/en-us/windows/win32/fileio/opening-a-file-for-reading-or-writing
	// 	data->FileHandle = CreateFileA(strfile,                // name of the write
	// 				   GENERIC_READ,          // open for writing
	// 				   FILE_SHARE_READ,                      // do not share
	// 				   null,                   // default security
	// 				   OPEN_EXISTING,             // create new file only
	// 				   FILE_ATTRIBUTE_NORMAL | FILE_FLAG_OVERLAPPED,  // normal file
	// 				   null);                  // no attr. template

	// 	// Log.Check(data->FileHandle == null, "Error opening file ");

	// 	 Memory.Memory.DisposeStr(strfile);

	// 	_ = GetFileSizeEx(data->FileHandle, &data->FileSize);

	// 	if (data->ChunkSize != 0)
	// 		ReadHeader(data, 4096);

	// 	// strfile.Dispose();
	// }

	// internal static void FileIOCompletionRoutine(DWORD dwErrorCode, DWORD dwNumberOfBytesTransfered, OVERLAPPED* lpOverlapped)
	// {
	// 	// _tprintf(TEXT("Error code:\t%x\n"), dwErrorCode);
	// 	// _tprintf(TEXT("Number of bytes:\t%x\n"), dwNumberOfBytesTransfered);
	// 	// g_BytesTransferred = dwNumberOfBytesTransfered;
	// 	Log.Info("File Reader", $"Finish read err [{dwErrorCode}  bytes read  {dwNumberOfBytesTransfered}]");
	// }

	// internal static byte ReadChar(FileData* data)
	// {
	// 	//Test if eand of chunk read another one ???? 
	// 	return data->Chunk[data->Position++];
	// }

	// internal static void ReadHeader(FileData* data, uint size)
	// {
	// 	data->Position = 0;
	// 	data->ChunkSize = size;
	// 	data->Chunk = Memory.Memory.NewArray<byte>(size);
	// 	data->LpoverlappedCompletionRoutine = (delegate* unmanaged<uint, uint, OVERLAPPED*, void>)Marshal.GetFunctionPointerForDelegate((PFN_FileIOCompletionRoutine)FileIOCompletionRoutine);

	// 	OVERLAPPED ol = default;

	// 	if (ReadFileEx(data->FileHandle, data->Chunk, data->ChunkSize - 1, &ol, data->LpoverlappedCompletionRoutine) == 0)
	// 	{
	// 		CloseHandle(data->FileHandle);
	// 	}
	// 	// WWait until it finish ?????

	// }

	// internal static void WriteChunk(FileData* data, uint size)
	// {
	// 	data->Position = 0;
	// 	data->ChunkSize = size;
	// 	// data->Chunk = WindowsMemory.NewArray<byte>(size);
	// 	// data->LpoverlappedCompletionRoutine = (delegate* unmanaged<uint, uint, OVERLAPPED*, void>)Marshal.GetFunctionPointerForDelegate((PFN_FileIOCompletionRoutine)FileIOCompletionRoutine);

	// 	// OVERLAPPED ol = default;

	// 	// if (ReadFileEx(data->FileHandle, data->Chunk, data->ChunkSize - 1, &ol, data->LpoverlappedCompletionRoutine) == 0)
	// 	// {

	// 	// }
	// 	// WWait until it finish ?????
	// 	uint bytesWritten = 0;
	// 	_ = WriteFile(data->FileHandle, data->Chunk, data->ChunkSize, &bytesWritten, null);
	// }

	// internal static void CloseFile(FileData* data)
	// {
	// 	_ = CloseHandle(data->FileHandle); //Log.Check(CloseHandle(data->FileHandle) == 0, "Error close File : filenam....");
	// 	Memory.Memory.DisposeArray(data->Chunk);
	// }


	const int MAX_PATH = 260;

	internal static string DRIVERLETTER = "c:";

	internal static void CreateDirectory(string directory)
	{
		// string v = directory;
		// Str d = "test"; 
	}

	internal static void DeleteDirectory(string directory)
	{

	}

	internal static bool DirectoryExist(string directory)
	{
		// string v = directory;
		// Str d = "test"; 
		return false;
	}

	internal static string[] GetDirectories(string patternmatching = "")
	{
		return null;
	}

	internal static void CreateFile(string file)
	{
		// string v = directory;
		// Str d = "test"; 
	}

	internal static void DeleteFile(string file)
	{

	}

	internal static bool FileExist(string file)
	{
		//https://learn.microsoft.com/fr-fr/cpp/c-runtime-library/reference/access-s-waccess-s?view=msvc-170 
		// TODO convert string to bytes file exist
		int err = _access_s(null, 0);

		return err == 0;
	}

	internal static string[] GetFiles(string patternmatching = "")
	{
		return null;
	}

	static string CheckEndPath(string path)
	{
		if (path[^1] != '\\')
		{
			path += '\\';
		}

		if (path[0] == '\\')
		{
			// path += '\\';
			path = path.Remove(0, 1);
		}
		// IsDirectoryEndSeparator
		// IsDirectoryStartSeparator
		// si le dernier car est \ alors return path  sinon on l'ajoute al a fin
		return path;
	}

	internal static string Combine(string path1, string path2)
	{
		if (string.IsNullOrEmpty(path1)) return CheckEndPath(path2);
		if (string.IsNullOrEmpty(path2)) return CheckEndPath(path1);
		return CheckEndPath(path1) + CheckEndPath(path2);
	}

	internal static string Combine(string path1, string path2, string path3)
	{
		if (string.IsNullOrEmpty(path2)) return CheckEndPath(path1);
		if (string.IsNullOrEmpty(path3)) return CheckEndPath(path1);
		return string.Concat(CheckEndPath(path1), CheckEndPath(path2));
	}

	internal static unsafe string VolumeLabel()
	{
		char* volumeName = stackalloc char[MAX_PATH + 1]; // https://github.com/dotnet/runtime/blob/main/src/libraries/Common/src/Interop/Windows/Kernel32/Interop.MAX_PATH.cs

		if (!GetVolumeInformation("c:\\", volumeName, MAX_PATH + 1, null, null, out int fileSystemFlags, null, 0))
		{
			return string.Empty;
		}
		return new string(volumeName);
	}

	internal static long TotalFreeSpace()
	{
		//         bool success = Interop.Kernel32.SetThreadErrorMode(Interop.Kernel32.SEM_FAILCRITICALERRORS, out uint oldMode);
		bool r = GetDiskFreeSpaceEx(DRIVERLETTER, out long userBytes, out long totalBytes, out long freeBytes);
		//  Interop.Kernel32.SetThreadErrorMode(oldMode, out _);
		return freeBytes;
	}

	internal static long AvailableFreeSpace()
	{
		//         bool success = Interop.Kernel32.SetThreadErrorMode(Interop.Kernel32.SEM_FAILCRITICALERRORS, out uint oldMode);
		bool r = GetDiskFreeSpaceEx(DRIVERLETTER, out long userBytes, out long totalBytes, out long freeBytes);
		//  Interop.Kernel32.SetThreadErrorMode(oldMode, out _);
		return userBytes;
	}


	
    // [SkipLocalsInit]
    // [SuppressGCTransition]
    // [SuppressUnmanagedCodeSecurity]
    // [LibraryImport(Ucrt, SetLastError = false, StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(System.Runtime.InteropServices.Marshalling.AnsiStringMarshaller))]
    // internal static partial int puts( /* const char *str*/ string str);



    [LibraryImport(Kernel, EntryPoint = "GetVolumeInformationW", SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static unsafe partial bool GetVolumeInformation(
        string drive,
        char* volumeName,
        int volumeNameBufLen,
        int* volSerialNumber,
        int* maxFileNameLen,
        out int fileSystemFlags,
        char* fileSystemName,
        int fileSystemNameBufLen);

    internal const uint FILE_SUPPORTS_ENCRYPTION = 0x00020000;

    [LibraryImport(Kernel, EntryPoint = "GetDiskFreeSpaceExW", SetLastError = false, StringMarshalling = StringMarshalling.Utf16)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool GetDiskFreeSpaceEx(string drive, out long freeBytesForUser, out long totalBytes, out long freeBytes);

    [LibraryImport(Ucrt, SetLastError = false)]
    internal static partial int _access_s(byte* path, int mode);

}




[SkipLocalsInit, StructLayout(LayoutKind.Explicit, Size = OVERLAPPED_SIZE)]
internal unsafe struct OVERLAPPED
{
#if X86
	const int OVERLAPPED_SIZE = 32;
#else
    const int OVERLAPPED_SIZE = 40;
#endif
    [FieldOffset(0)]
    internal uint* Internal;

    [FieldOffset(4)]
    internal uint* InternalHigh;

    [FieldOffset(8)]
    internal uint Offset;

    [FieldOffset(12)]
    internal uint OffsetHigh;

    [FieldOffset(8)]
    internal void* Pointer;

    [FieldOffset(16)]
    internal void* hEvent;
}

[SkipLocalsInit, StructLayout(LayoutKind.Sequential)]
internal unsafe struct SECURITY_ATTRIBUTES
{
	internal uint nLength;
	internal void* lpSecurityDescriptor;
	internal int bInheritHandle;
};

#endif