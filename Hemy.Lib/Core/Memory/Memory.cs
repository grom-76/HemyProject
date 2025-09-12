namespace Hemy.Lib.Core.Memory;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public unsafe static class Memory
{
    /// <summary> Alloc new memory for structure  </summary>
    /// <returns>Pointer for this type of structure</returns>
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static T* New<T>(bool withCopyInstance = true) where T : unmanaged
#if WINDOWS
        => Hemy.Lib.Core.Platform.Windows.Memory.Memory.New<T>(withCopyInstance);
#else   
        => null;
#endif

    /// <summary> For array </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="count"></param>
    /// <returns></returns>
    public static T* NewArray<T>(uint count) where T : unmanaged
#if WINDOWS
        => Hemy.Lib.Core.Platform.Windows.Memory.Memory.NewArray<T>(count);
#else   
        => null;
#endif

    /// <summary> convert string to UTF8 byte </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static byte* NewStr(string text)
#if WINDOWS
        => Hemy.Lib.Core.Platform.Windows.Memory.Memory.NewStr(text);
#else   
        => null;
#endif

    public static void Dispose<T>(T* pointer) where T : unmanaged
#if WINDOWS
        => Hemy.Lib.Core.Platform.Windows.Memory.Memory.Dispose<T>(pointer);
#else   
        {}
#endif

    public static void DisposeStr(byte* pointer)
#if WINDOWS
        => Hemy.Lib.Core.Platform.Windows.Memory.Memory.DisposeStr(pointer);
#else   
       {}
#endif

    public static void DisposeArray<T>(T* pointer) where T : unmanaged
#if WINDOWS
        => Hemy.Lib.Core.Platform.Windows.Memory.Memory.DisposeArray<T>(pointer);
#else   
        => null;
#endif

    public static void Copy(void* source, void* destination, uint size)
#if WINDOWS
        => Hemy.Lib.Core.Platform.Windows.Memory.Memory.Copy(source,destination,size);
#else   
        => null;
#endif

    public static nuint Size<T>() where T : unmanaged
#if WINDOWS
        => Hemy.Lib.Core.Platform.Windows.Memory.Memory.Size<T>();
#else   
        => null;
#endif

    public static T* ToPtr<T>(ref T instance) where T : unmanaged
#if WINDOWS
        => Hemy.Lib.Core.Platform.Windows.Memory.Memory.ToPtr<T>(ref instance);
#else   
        => null;
#endif

    public static bool IsPow2(nuint value) => (value & (value - 1)) == 0 && value != 0;

    public static nuint GetByteCount(nuint elementCount, nuint elementSize)
    {
        nuint multiplyNoOverflow = (nuint)1 << (4 * sizeof(nuint));

        return ((elementSize >= multiplyNoOverflow) || (elementCount >= multiplyNoOverflow)) && (elementSize > 0) && ((nuint.MaxValue / elementSize) < elementCount) ? nuint.MaxValue : (elementCount * elementSize);
    }
}
