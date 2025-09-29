namespace Hemy.Lib.V2.Platform.Windows;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

using const_char = System.Byte;
using BOOL = System.Int32;

// https://learn.microsoft.com/en-us/windows/win32/winprog/windows-data-types
using size_t = System.UIntPtr;
using uint32_t = System.UInt32;
using uint64_t = System.UInt64;
using uint8_t = System.Byte;
using int32_t = System.Int32;
using int64_t = System.Int64;
using uint16_t = System.UInt16;

using VkBool32 = System.UInt32;
using VkDeviceAddress = System.UInt64;
using VkDeviceSize = System.UInt64;
using Flag = System.Int32;

using HRESULT = System.Int32;

using static Hemy.Lib.V2.Platform.Windows.WindowsGraphicCommon;
using static Hemy.Lib.V2.Platform.Windows.WindowsWindowCommon;
using Hemy.Lib.V2.Core;


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal unsafe static partial class WindowsMemory
{
	internal const int DataAlignementSize = 8;
	internal const string Ucrt = "ucrtbase";

	[SkipLocalsInit]
	internal static long ReminingMemory => _allocations;
	static volatile int _allocations;

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static size_t Size<T>() where T : unmanaged
		=> (size_t)Unsafe.SizeOf<T>();

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static T* ToPtr<T>(ref T instance) where T : unmanaged
		=> (T*)Unsafe.AsPointer(ref instance);


	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static byte* New(string text) // FOr STRINGS
	{
		byte* bytes = New<byte>((uint)text.Length + 1);
		WindowsUtils.FillBytesWithString(bytes, text);
		return bytes;
	}

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity] // FOR ARRAY
	internal static T* New<T>(nuint count) where T : unmanaged
	{
		size_t size = WindowsUtils.GetByteCount(Size<T>(), count);
		T* result = (T*)_aligned_malloc(size, DataAlignementSize);

		Interlocked.Increment(ref _allocations);

		return result;
	}

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity] // FOR STRUCT
	internal static T* New<T>() where T : unmanaged
		=> (T*)New<T>(1);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static void Dispose(void* pointer)
	{
		if (pointer == null) return;

		_aligned_free(pointer);
		Interlocked.Decrement(ref _allocations);
	}
	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static void* Copy(void* ptrSource, void* ptrDestination, nuint size)
		=> memmove(ptrDestination, ptrSource, size);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	internal static void* Fill(void* destination, int valueToFill, nuint bytesCount)
		=> memset(destination, valueToFill, bytesCount);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial void* _aligned_malloc(nuint size, nuint alignment);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial void* _aligned_realloc(void* memblock, nuint size, nuint alignment);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial void _aligned_free(void* ptr);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial void* memmove(void* dest, void* src, nuint size);

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial void* memset(void* dest, int c, nuint count);

	//   [DllImport("kernel32.dll", SetLastError = true)]
	//     public static extern IntPtr HeapCreate(HeapFlags flOptions, uint dwInitialsize, uint dwMaximumSize);

	//     [DllImport("kernel32.dll", SetLastError = true)]
	//     public static extern IntPtr HeapAlloc(IntPtr hHeap, HeapFlags dwFlags, uint dwSize);

	//     [DllImport("kernel32.dll", SetLastError = true)]
	//     public static extern bool HeapDestroy(IntPtr hHeap);
	//  [Flags]
    // public enum HeapFlags
    // {
    //     HEAP_NO_SERIALIZE = 0x1,
    //     HEAP_GENERATE_EXCEPTIONS = 0x4,
    //     HEAP_ZERO_MEMORY = 0x8
    // }
}


[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct WindowsStrArray(uint count, uint itemMaxSize)
{
	byte* _array = WindowsMemory.New<byte>(count * itemMaxSize);
    byte* _pointer = WindowsMemory.New<byte>( count * (uint)Unsafe.SizeOf<IntPtr>() );

	internal void Init(uint ncount, uint nitemMaxSize )
	{
		_array = WindowsMemory.New<byte>(ncount * nitemMaxSize);
		_pointer = WindowsMemory.New<byte>( ncount * (uint)Unsafe.SizeOf<IntPtr>() );
	}

    /// <summary> le nombre de ligne du tableau </summary>
    public readonly uint Count => count;

    /// <summary> Acces direct en lecture seule au debut du tableau ligne zéro caractère zéro </summary>
    public readonly byte* Pointer => _pointer;

    /// <summary> Ajoute un nouvel élément au tableau  </summary>
    /// <param name="value"> pointeur au format byte  de la chaine d'entrée</param>
    /// <param name="index">specifie la ligne d'insertion doit être superieur à zéro ou inferieur a count </param>
    /// <returns></returns> 
    [SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
    public readonly bool Add(byte* value, uint index)
    {
        if (value is null) return false;

        if (index <= 0 && index >= count) return false;

        uint size = WindowsUtils.Length(value) + 1;

        WindowsMemory.Copy(value, _array + (itemMaxSize * index), size);

        ((byte**)_pointer)[index] = _array + (itemMaxSize * index);

        return true;
    }

    /// <summary> Retourne au format string c# la chaine à la ligne spécifié. </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public readonly string GetString(uint index)
		=> WindowsUtils.BytesToString( _array + (itemMaxSize * index),itemMaxSize );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="match"></param>
    /// <returns></returns>
    [SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
    public readonly bool IsExist(string match)
    {
        for (uint i = 0; i < Count; i++)
        {
            string extension = GetString(i);

            if (extension.Contains(match))
                return true;
        }
        return false;
    }

    /// <summary> Retourne le pointeur a ladresse du début de la ligne spécifier </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public readonly byte* this[uint index]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => _array + (itemMaxSize * index);
        set => Add(value, index);
    }

    /// <summary> Quitter proprement  </summary>
    [SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
    public readonly void Dispose()
    {
        WindowsMemory.Dispose(_array);
        WindowsMemory.Dispose(_pointer);
    }

    public static implicit operator byte**(WindowsStrArray array) => (byte**)array._pointer;
}
