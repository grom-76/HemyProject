#if WINDOWS

namespace Hemy.Lib.Core.Platform.Windows.Memory;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using static Hemy.Lib.Core.Platform.Windows.Common.LibrariesName;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static unsafe partial class Memory
{
    internal const int DataAlignementSize = 8;
    internal const uint CacheLineSize = 128U;

    [SkipLocalsInit]
    internal static long ReminingMemory => _allocations;
    static volatile int _allocations;

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static void Increment() => Interlocked.Increment(ref _allocations);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static void Decrement() => Interlocked.Decrement(ref _allocations);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static nuint Size<T>() where T : unmanaged => (nuint)Unsafe.SizeOf<T>();

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static T* ToPtr<T>(ref T instance) where T : unmanaged => (T*)Unsafe.AsPointer(ref instance);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static void Copy(void* ptrSource, void* ptrDestination, nuint size)
    {
        void* result = memmove(ptrDestination, ptrSource, size);
        if (result != ptrDestination) Log.Error("Erreur copy");
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static byte* NewStr(string text)
    {
        //Equivalent a NewArray<byte> 
        byte* bytes = (byte*)calloc((uint)text.Length + 1, Size<byte>());
        // byte* bytes = (byte*)NativeMemory.AllocZeroed( (uint)text.Length + 1, sizeof(byte) );
        if (bytes == null)
        {
            Log.Error("Alloc Str Failed  ");
            return null;
        }

        int i = 0;
        while (i < text.Length)
        {
            *(bytes + i) = unchecked((byte)(text[i++] & 0x7f));
        }
        *(bytes + i) = 0;// dans le cas ou il n'y ait pas de zero en fin de chaine calloc

        Increment();
        return bytes;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static T* NewArray<T>(nuint count) where T : unmanaged
    {
        T* result = (T*)calloc(count, Size<T>());

        if (result == null)
        {
            Log.Error("Alloc Failed for type:  " + typeof(T).Assembly.GetName());
            return null;
        }
        Increment();

        return result;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static T* New<T>(bool withCopyInstance = true) where T : unmanaged
    {
        T* result = (T*)malloc(Size<T>());

        if (result == null)
        {
            Log.Error("Alloc Failed for type:  " + typeof(T).Assembly.GetName());
            return null;
        }
        Increment();

        if (withCopyInstance)
        {
            T _context = new();
            Copy(ToPtr(ref _context), result, Size<T>());
        }

        return result;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public static void Dispose<T>(T* pointer) where T : unmanaged
    {
        if (pointer == null) return;

        free(pointer);
        Decrement();
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public static void DisposeArray<T>(T* pointer) where T : unmanaged
    {
        if (pointer == null) return;

        free(pointer);
        Decrement();
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public static void DisposeStr<T>(T* pointer) where T : unmanaged
    {
        if (pointer == null) return;

        free(pointer);
        Decrement();
    }

    [LibraryImport(Ucrt, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial void* _aligned_malloc(nuint size, nuint alignment);

    [LibraryImport(Ucrt, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial void _aligned_free(void* ptr);

    [LibraryImport(Ucrt, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial void* memmove(void* dest, void* src, nuint size);

    [LibraryImport(Ucrt, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial void* _aligned_realloc(void* memblock, nuint size, nuint alignment);

    [LibraryImport(Ucrt, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial void* calloc(nuint number, nuint size);

    [LibraryImport(Ucrt, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial void* malloc(nuint size);

    [LibraryImport(Ucrt, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial void* realloc(void* memblock,nuint size);

    [LibraryImport(Ucrt, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial void free(void* ptr);

    [LibraryImport(Ucrt, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    internal static partial void* memset(void* dest,int c,nuint count );
}

#endif
