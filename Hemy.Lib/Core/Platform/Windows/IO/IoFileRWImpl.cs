#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.IO;


using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using DWORD = System.UInt32; // A 32-bit unsigned integer. The range is 0 through 4294967295 decimal.
using BOOL = System.Int32;
using static Hemy.Lib.Core.Platform.Windows.Common.LibrariesName;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static partial class IoFileRWImpl
{

	// S'affiche quand le thread en Cours et Fini 
	internal static void FileIOCompletionRoutine(DWORD dwErrorCode, DWORD dwNumberOfBytesTransfered, OVERLAPPED* lpOverlapped)
	{
		Log.Info("File Reader", $"Finish read err [{dwErrorCode}  bytes read  {dwNumberOfBytesTransfered}]");
	}

	public static void TestReadBinaryFile(string filename)
	{
	
		IoFileData* fileData = Memory.Memory.New<IoFileData>();

		Open(fileData, filename);

		byte* buffer = Memory.Memory.NewArray<byte>(44);
		Read(fileData, buffer, 44);
		int position = 0;


		if (UInt(buffer, &position) != 0x46464952) return;

		var FileSize = UInt(buffer, &position);

		if (UInt(buffer, &position) != 0x45564157) return;

		if (UInt(buffer, &position) != 0x20746D66) return;

		var BlocSize = UInt(buffer, &position);
		var AudioFormat = Short(buffer, &position);
		var Nbrcanaux = Short(buffer, &position);
		var Frequence = UInt(buffer, &position);
		var BytePerSec = UInt(buffer, &position);
		var BytePerBloc = Short(buffer, &position);
		var BitsPerSample = Short(buffer, &position);

		if (UInt(buffer, &position) != 0x61746164) return;

		var DataSize = UInt(buffer, &position) - 44;
		var Octetparseconde = Frequence * (uint)BytePerBloc;
		//  Frequence : 44100Hz
		// Octets Par Seconde : 176400
		// Bytes par Seconde : 176400
		// Nombre de canaux : 2
		// Data size : 2116756Hz
		// Format Tag : 1
		// Bit par Samples : 16 (8,16,24)
		// Bytes par bloc : 4

		Close(fileData);

		Memory.Memory.DisposeArray(buffer);
		Memory.Memory.Dispose(fileData);
	}

	internal static byte Byte(byte* buffer, int* position)
	{
		byte b1 = buffer[*position];
		*position += 1;
		return b1;
	}
	internal static ushort UShort(byte* buffer, int* position)
	{
		byte b1 = buffer[*position];
		byte b2 = buffer[*position + 1];

		*position += 2;
		return (ushort)((b1 << 0) | (b2 << 8) );
	}
	internal static uint UInt(byte* buffer, int* position)
	{
		byte b1 = buffer[*position];
		byte b2 = buffer[*position + 1];
		byte b3 = buffer[*position + 2];
		byte b4 = buffer[*position + 3];

		*position += 4;
		return (uint)((b1 << 0) | (b2 << 8) | (b3 << 16) | (b4 << 24));
	}

	internal static ulong ULong(byte* buffer, int* position)
	{
		byte b1 = buffer[*position] ;
		byte b2 = buffer[*position + 1] ;
		byte b3 = buffer[*position + 2] ;
		byte b4 = buffer[*position + 3] ;
		byte b5 = buffer[*position + 4] ;
		byte b6 = buffer[*position + 5] ;
		byte b7 = buffer[*position + 6] ;
		byte b8 = buffer[*position + 7] ;

		*position += 8;
		return (ulong)((b1 << 0) | (b2 << 8) | ( b3 << 16) | (4 << 24) |
		   ( b5 << 32) | (b6 << 40) | (b7 << 48) | (b8 << 56));
	}

	internal static sbyte SByte(byte* buffer, int* position)
	{
		sbyte b1 = unchecked((sbyte)(buffer[*position] - 256));
		*position += 1;
		return b1;
	}

	internal static short Short(byte* buffer, int* position)
	{
		sbyte b1 = unchecked((sbyte)(buffer[*position] - 256));
		sbyte b2 = unchecked((sbyte)(buffer[*position + 1] - 256));

		*position += 2;
		return (short)(b1 + (b2 << 8));
	}

	internal static int Int(byte* buffer, int* position)
	{
		sbyte b1 = (sbyte)(buffer[*position] - 256);
		sbyte b2 = (sbyte)(buffer[*position + 1] - 256);
		sbyte b3 = (sbyte)(buffer[*position + 2] - 256);
		sbyte b4 = (sbyte)(buffer[*position + 3] - 256);

		*position += 4;
		
		//  return (int)((b1 << 24) | (b2 << 16) | (b3 << 8) | (b4 << 0)); // Little En
		 return (int)((b1 << 0) | (b2 << 8) | (b3 << 16) | (b4 << 24)); // BigEndian
	}

	internal static float Float(byte* buffer, int* position)
	{
		sbyte b1 = (sbyte)(buffer[*position] - 256);
		sbyte b2 = (sbyte)(buffer[*position + 1] - 256);
		sbyte b3 = (sbyte)(buffer[*position + 2] - 256);
		sbyte b4 = (sbyte)(buffer[*position + 3] - 256);

		*position += 4;
		// int value = (int)((b1 << 24) | (b2 << 16) | (b3 <<8) | (b4 << 0));
		int value = (int)((b1 << 0) | (b2 << 8) | (b3 << 16) | (b4 << 24)); // Le 
		return IntToFloat(value);
	}

	internal static long Long(byte* buffer, int* position)
	{
		sbyte b1 = unchecked((sbyte)(buffer[*position] - 256));
		sbyte b2 = unchecked((sbyte)(buffer[*position + 1] - 256));
		sbyte b3 = unchecked((sbyte)(buffer[*position + 2] - 256));
		sbyte b4 = unchecked((sbyte)(buffer[*position + 3] - 256));
		sbyte b5 = unchecked((sbyte)(buffer[*position + 4] - 256));
		sbyte b6 = unchecked((sbyte)(buffer[*position + 5] - 256));
		sbyte b7 = unchecked((sbyte)(buffer[*position + 6] - 256));
		sbyte b8 = unchecked((sbyte)(buffer[*position + 7] - 256));

		*position += 8;
		return ((long)b1 << 0) | ((long)b2 << 8) | ((long)b3 << 16) | ((long)b4 << 24) |
		   ((long)b5 << 32) | ((long)b6 << 40) | ((long)b7 << 48) | ((long)b8 << 56);
	}

	// public static void WriteInt(int value, byte* buffer, int* position)
	// {
	// 	buffer[*position] = (byte)(value << 0);
	// 	buffer[*position] = (byte)(value << 8);
	// 	buffer[*position] = (byte)(value << 16);
	// 	buffer[*position] = (byte)(value << 24);
	// 	*position += 4;
	// }

	// public static void WriteFloat(float single, byte* buffer, int* position)
	// {
	// 	int value = FloatToInt(single); // 1090416280
	// 	buffer[*position] = (byte)(value >> 24);
	// 	buffer[*position+1] = (byte)(value >> 16);
	// 	buffer[*position+2] = (byte)(value >> 8);
	// 	buffer[*position+3] = (byte)(value >> 0);
	// 	*position += 4;
	// }


	public unsafe static int FloatToInt(float value) => *((int*)&value);
	public unsafe static float IntToFloat(int value)=> *((float*)&value);

	internal static void Open(IoFileData* fileData, string filename)
	{
		//Check if file Exist ??? return error    Mode =-1 file not exist

		var strfile = Hemy.Lib.Core.Memory.Str.New(filename);

		// src : https://learn.microsoft.com/en-us/windows/win32/fileio/opening-a-file-for-reading-or-writing
		fileData->Handle = CreateFileA(strfile,                // name of the write
					   GENERIC_READ,          // open for writing
					   FILE_SHARE_READ,                      // do not share
					   null,                   // default security
					   OPEN_EXISTING,             // create new file only
					   FILE_ATTRIBUTE_NORMAL | FILE_FLAG_OVERLAPPED,  // normal file
					   null);                  // no attr. template

		if (fileData->Handle == null) Log.Error("Open file Handle null ");

		 Hemy.Lib.Core.Memory.Str.Dispose(strfile);


		var err = GetFileSizeEx(fileData->Handle, &fileData->Size);

		if (err == 0 /*err == Size ???*/) Log.Error("Open File Size =0");
	}

	internal static void Close(IoFileData* fileData)
	{

		var err = CloseHandle(fileData->Handle);

		if (err == 0) Log.Error("Close File ");

	}

	internal static int Read(IoFileData* fileData, byte* buffer, uint size, PFN_FileIOCompletionRoutine fileIOCompletionRoutine = null)
	{
		delegate* unmanaged<uint, uint, OVERLAPPED*, void> LpoverlappedCompletionRoutine = null;
		if (fileIOCompletionRoutine != null)
		 	LpoverlappedCompletionRoutine = (delegate* unmanaged<uint, uint, OVERLAPPED*, void>)Marshal.GetFunctionPointerForDelegate((PFN_FileIOCompletionRoutine)fileIOCompletionRoutine);
		else
		 	LpoverlappedCompletionRoutine = (delegate* unmanaged<uint, uint, OVERLAPPED*, void>)Marshal.GetFunctionPointerForDelegate((PFN_FileIOCompletionRoutine)FileIOCompletionRoutine);

		OVERLAPPED ol = default;
		if (ReadFileEx(fileData->Handle, buffer, size, &ol, LpoverlappedCompletionRoutine) == 0)
		{
			Close(fileData);
			return 1;
		}
		return 0;
	}

	internal const uint SEEK_BEGIN = 0;
	internal const uint SEEK_CURRENT = 1;
	internal const uint SEEK_END = 2;
	internal static void Seek(IoFileData* fileData, long offset, uint moveMethod)
	{
		const DWORD INVALID_SET_FILE_POINTER = unchecked(0xFFFFFFFF);
		var err = SetFilePointer(fileData->Handle, offset, null, moveMethod);
		if (err == INVALID_SET_FILE_POINTER)
		{
			Log.Error("Seek File");
		}

	}
	internal delegate void PFN_FileIOCompletionRoutine(DWORD dwErrorCode, DWORD dwNumberOfBytesTransfered, OVERLAPPED* lpOverlapped);

	[LibraryImport(Kernel, SetLastError = false)]
	private static partial void* CreateFileA(
	  byte* lpFileName,
	  long dwDesiredAccess,
	  uint dwShareMode,
	  SECURITY_ATTRIBUTES* lpSecurityAttributes,
	  uint dwCreationDisposition,
	  uint dwFlagsAndAttributes,
	  void* hTemplateFile);

	[LibraryImport(Kernel, SetLastError = false)]
	private static partial int ReadFileEx(void* hFile,
		byte* lpBuffer,
		uint nNumberOfBytesToRead,
		OVERLAPPED* lpOverlapped,
		delegate* unmanaged<uint, uint, OVERLAPPED*, void> lpCompletionRoutine);

	[LibraryImport(Kernel, SetLastError = false)]
	private static partial int WriteFile(void* hFile,
			byte* lpBuffer,
			uint nNumberOfBytesToWrite,
			uint* lpNumberOfBytesWritten,
			void* lpOverlapped
	);

	[LibraryImport(Kernel, SetLastError = false)]
	private static partial BOOL CloseHandle(void* hFile);

	[LibraryImport(Kernel, SetLastError = false)]
	private static partial DWORD SetFilePointer(void* hFile, long lDistanceToMove, long* lpDistanceToMoveHigh, DWORD dwMoveMethod);

	[LibraryImport(Kernel, SetLastError = false)]
	private static partial BOOL GetFileSizeEx(void* hFile, long* lpFileSize);

	public const long GENERIC_READ = 31;
	public const long GENERIC_WRITE = 30;
	public const long READ_CONTROL = (0x00020000L);
	public const int CREATE_NEW = 1;
	public const int OPEN_EXISTING = 3;
	public const uint FILE_ATTRIBUTE_NORMAL = (0x80);
    public const uint FILE_FLAG_OVERLAPPED = 0x40000000;
    public const int FILE_SHARE_READ = 0x00000001;

}

#endif