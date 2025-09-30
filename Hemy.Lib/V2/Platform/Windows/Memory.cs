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
	private const string Ucrt = "ucrtbase";

	[SkipLocalsInit]
	internal static long ReminingMemory => _allocations;
	static volatile int _allocations;

	[MethodImpl((MethodImplOptions)768), SkipLocalsInit, SuppressGCTransition, SuppressUnmanagedCodeSecurity]
	internal static size_t Size<T>() where T : unmanaged
		=> (size_t)Unsafe.SizeOf<T>();

	[MethodImpl((MethodImplOptions)768), SkipLocalsInit, SuppressGCTransition, SuppressUnmanagedCodeSecurity]
	internal static T* ToPtr<T>(ref T instance) where T : unmanaged
		=> (T*)Unsafe.AsPointer(ref instance);

	[SkipLocalsInit] [SuppressGCTransition]	[SuppressUnmanagedCodeSecurity]
	internal static byte* New(string text) // FOr STRINGS
	{
		byte* bytes = New<byte>((uint)text.Length + 1);
		WindowsUtils.FillBytesWithString(bytes, text);
		return bytes;
	}

	[SkipLocalsInit] [SuppressGCTransition]	[SuppressUnmanagedCodeSecurity] 
	internal static T* New<T>(nuint count) where T : unmanaged // FOR ARRAY
	{
		size_t size = WindowsUtils.GetByteCount(Size<T>(), count);
		T* result = (T*)_aligned_malloc(size, DataAlignementSize);

		Interlocked.Increment(ref _allocations);

		return result;
	}

	[MethodImpl((MethodImplOptions)768), SkipLocalsInit, SuppressGCTransition, SuppressUnmanagedCodeSecurity]
	internal static T* New<T>() where T : unmanaged // For struct
		=> (T*)New<T>(1);

	[SkipLocalsInit] [SuppressGCTransition]	[SuppressUnmanagedCodeSecurity]
	internal static void Dispose(void* pointer)
	{
		if (pointer == null) {return;}

		_aligned_free(pointer);
		Interlocked.Decrement(ref _allocations);
	}
	[SkipLocalsInit] [SuppressGCTransition]	[SuppressUnmanagedCodeSecurity]
	internal static void* Copy(void* ptrSource, void* ptrDestination, nuint size)
		=> memmove(ptrDestination, ptrSource, size);

	[SkipLocalsInit] [SuppressGCTransition]	[SuppressUnmanagedCodeSecurity]
	internal static void* Fill(void* destination, int valueToFill, nuint bytesCount)
		=> memset(destination, valueToFill, bytesCount);

	[SkipLocalsInit] [SuppressGCTransition]	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial void* _aligned_malloc(nuint size, nuint alignment);

	[SkipLocalsInit] [SuppressGCTransition]	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial void* _aligned_realloc(void* memblock, nuint size, nuint alignment);

	[SkipLocalsInit] [SuppressGCTransition]	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial void _aligned_free(void* ptr);

	[SkipLocalsInit] [SuppressGCTransition]	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial void* memmove(void* dest, void* src, nuint size);

	[SkipLocalsInit] [SuppressGCTransition]	[SuppressUnmanagedCodeSecurity]
	[LibraryImport(Ucrt, SetLastError = false)]
	[UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl), typeof(CallConvSuppressGCTransition)])]
	[DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
	internal static partial void* memset(void* dest, int c, nuint count);

}

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
internal unsafe struct WindowsStrArray(uint count, uint itemMaxSize)
{
	private byte* _array  =null;
    private byte* _pointer = null;

	internal readonly uint Count => count;
    internal readonly byte* Pointer => _pointer;

	[SkipLocalsInit] [SuppressGCTransition]	[SuppressUnmanagedCodeSecurity]
	internal void Init(uint ncount, uint nitemMaxSize)
	{
		_array = WindowsMemory.New<byte>(ncount * nitemMaxSize);
		_pointer = WindowsMemory.New<byte>(ncount * (uint)Unsafe.SizeOf<IntPtr>());
	}

    [SkipLocalsInit] [SuppressGCTransition]	[SuppressUnmanagedCodeSecurity]
    internal readonly bool Add(byte* value, uint index)
    {
        if ((value is null) || ( index <= 0 && index >= count) )return false;

        uint size = WindowsUtils.Length(value) + 1;

        WindowsMemory.Copy(value, _array + (itemMaxSize * index), size);

        ((byte**)_pointer)[index] = _array + (itemMaxSize * index);

        return true;
    }

	[MethodImpl((MethodImplOptions)768), SkipLocalsInit, SuppressGCTransition, SuppressUnmanagedCodeSecurity]
	internal readonly string GetString(uint index)
		=> WindowsUtils.BytesToString(_array + (itemMaxSize * index), itemMaxSize);

    [SkipLocalsInit] [SuppressGCTransition]	[SuppressUnmanagedCodeSecurity]
    internal readonly bool IsExist(string match)
    {
        for (uint i = 0; i < Count; i++)
        {
            string extension = GetString(i);

            if (extension.Contains(match))
                return true;
        }
        return false;
    }

	[ SkipLocalsInit ]
    internal readonly byte* this[uint index]
    {
        [MethodImpl((MethodImplOptions)768), SkipLocalsInit, SuppressGCTransition, SuppressUnmanagedCodeSecurity]
        get => _array + (itemMaxSize * index);
        set => Add(value, index);
    }

    [SkipLocalsInit] [SuppressGCTransition]	[SuppressUnmanagedCodeSecurity]
    internal readonly void Dispose()
    {
        WindowsMemory.Dispose(_array);
        WindowsMemory.Dispose(_pointer);
    }

    public static implicit operator byte**(WindowsStrArray array) => (byte**)array._pointer;
}
