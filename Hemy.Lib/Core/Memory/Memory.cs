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
	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
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
	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
	public static T* NewArray<T>(uint count) where T : unmanaged
#if WINDOWS
		=> Hemy.Lib.Core.Platform.Windows.Memory.Memory.NewArray<T>(count);
#else
        => null;
#endif

	/// <summary> convert string to UTF8 byte </summary>
	/// <param name="text"></param>
	/// <returns></returns>
	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
	public static byte* NewStr(string text)
#if WINDOWS
		=> Hemy.Lib.Core.Platform.Windows.Memory.Memory.NewStr(text);
#else
        => null;
#endif

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
	public static void Dispose<T>(T* pointer) where T : unmanaged
#if WINDOWS
		=> Hemy.Lib.Core.Platform.Windows.Memory.Memory.Dispose<T>(pointer);
#else
        {}
#endif

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
	public static void DisposeStr(byte* pointer)
#if WINDOWS
		=> Hemy.Lib.Core.Platform.Windows.Memory.Memory.DisposeStr(pointer);
#else
       {}
#endif

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
	public static void DisposeArray<T>(T* pointer) where T : unmanaged
#if WINDOWS
		=> Hemy.Lib.Core.Platform.Windows.Memory.Memory.DisposeArray<T>(pointer);
#else
        => null;
#endif

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
	public static void Copy(void* source, void* destination, uint size)
#if WINDOWS
		=> Hemy.Lib.Core.Platform.Windows.Memory.Memory.Copy(source, destination, size);
#else
        => null;
#endif

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
	public static nuint Size<T>() where T : unmanaged
#if WINDOWS
		=> Hemy.Lib.Core.Platform.Windows.Memory.Memory.Size<T>();
#else
        => null;
#endif

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
	public static T* ToPtr<T>(ref T instance) where T : unmanaged
#if WINDOWS
		=> Hemy.Lib.Core.Platform.Windows.Memory.Memory.ToPtr<T>(ref instance);
#else
        => null;
#endif

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
	public static bool IsPow2(nuint value) => (value & (value - 1)) == 0 && value != 0;

	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
	public static nuint GetByteCount(nuint elementCount, nuint elementSize)
	{
		nuint multiplyNoOverflow = (nuint)1 << (4 * sizeof(nuint));

		return ((elementSize >= multiplyNoOverflow) || (elementCount >= multiplyNoOverflow)) && (elementSize > 0) && ((nuint.MaxValue / elementSize) < elementCount) ? nuint.MaxValue : (elementCount * elementSize);
	}

	/// <summary>
	/// Rempli un bloc de mémoire averc une valeur particuliere
	/// </summary>
	/// <param name="destination">block de mémoire </param>
	/// <param name="valueToFill">valeur particuliere</param>
	/// <param name="bytesCount">taille du bloc à remplir en byte </param>
	[SkipLocalsInit]
	[SuppressGCTransition]
	[SuppressUnmanagedCodeSecurity]
	[MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    internal static void Fill(void* destination, int valueToFill, nuint bytesCount)
#if WINDOWS
		=> Hemy.Lib.Core.Platform.Windows.Memory.Memory.Fill(destination,valueToFill,bytesCount);
#else
        => null;
#endif
}
