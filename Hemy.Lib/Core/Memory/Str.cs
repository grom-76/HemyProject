namespace Hemy.Lib.Core.Memory;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public unsafe sealed partial class Str : IEquatable<Str>, IDisposable
{
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    internal static void StringToBytes(byte* bytes, string text)
#if WINDOWS
        => Hemy.Lib.Core.Platform.Windows.Memory.Memory.FillBytesWithString(bytes, text);
#else
        {  }
#endif

    /// <summary>
	/// Calculate the length of string with null terminated
	/// </summary>
	/// <param name="source"></param>
	/// <param name="UTF8"> if true indicate 8bits UTF8 count else  16bits count (unicode ) </param>
	/// <returns></returns>
	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static uint Length(byte* source)
#if WINDOWS
        => Hemy.Lib.Core.Platform.Windows.Memory.Memory.Length(source);
#else
        => 0 ;
#endif

    /// <summary>  Convert a byte pointer to managed string format UTF8 only  </summary>
	/// <param name="bytes"> pointer byte to convert </param>
	/// <param name="length"> length of bytes to convert if zero auto calculate size </param>
	/// <returns> a managed string </returns>
	[SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public static string BytesToString(byte* bytes, uint length = 0)
#if WINDOWS
        => Hemy.Lib.Core.Platform.Windows.Memory.Memory.BytesToString(bytes, length);
#else
        => string.Empty ;
#endif

    #region CODE
    byte* Pointer = null;
    uint Size = 0;
    uint currentPosition = 0;

    [SkipLocalsInit]
    public Str(string chaine)
    {
        Size = (uint)chaine.Length + 1;

        Pointer = Memory.NewArray<byte>(Size);

        StringToBytes(Pointer, chaine);
    }

    [SkipLocalsInit]
    public Str(byte* chaine)
    {
        bool utf16 = chaine[1] == '\0';

        Size = Length(chaine) + 1;//+1 pour '\0'
        int increment = utf16 ? 2 : 1;

        Pointer = Memory.NewArray<byte>(Size);

        for (int i = 0, index = 0; index < Size - 1; i += increment, index++)
        { *(Pointer + index) = chaine[i]; }
    }

    [SkipLocalsInit]
    public Str(System.ReadOnlySpan<byte> bytes)
    {
        Size = currentPosition = (uint)bytes.Length + 1;
#if WINDOWS 
        Pointer = Hemy.Lib.Core.Platform.Windows.Memory.Memory.NewArray<byte>(Size);
#endif
        fixed (byte* ptr = &bytes[0])
        {
#if WINDOWS
            Hemy.Lib.Core.Platform.Windows.Memory.Memory.Copy(ptr, Pointer, Size);
#endif
        }
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public void Dispose()
#if WINDOWS 
     => Hemy.Lib.Core.Platform.Windows.Memory.Memory.DisposeArray(Pointer);
#else
    { }
#endif


    [SkipLocalsInit]
    public Str(int capacity)
    {
        if (Pointer != null && capacity <= 0) return;

        Size = (uint)capacity;
#if WINDOWS 
        Pointer = Hemy.Lib.Core.Platform.Windows.Memory.Memory.NewArray<byte>(Size);
#endif
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append(string text)
    {
        if (string.IsNullOrEmpty(text) || currentPosition + text.Length >= Size)
        { return this; }

        int i = 0;
        while (i < text.Length)
        { *(Pointer + currentPosition++) = (byte)(text[i++] & 0x7f); }

        return this;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append(uint value)
    {
#if WINDOWS
        Hemy.Lib.Core.Platform.Windows.Memory.Memory._ultoa(value, Pointer, 10);
#endif
        return this;
    }
    // => Append(value.ToString());

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append(int value)
    {
#if WINDOWS
        Hemy.Lib.Core.Platform.Windows.Memory.Memory._itoa(value, Pointer, 10);
#endif
        return this;
    }
    //  => Append(value.ToString());

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append(long value)
    {
#if WINDOWS
        Hemy.Lib.Core.Platform.Windows.Memory.Memory._ltoa(value, Pointer, 10);
#endif
        return this;
    }
    //  => Append(value.ToString());

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append(ulong value)
    {
#if WINDOWS
        Hemy.Lib.Core.Platform.Windows.Memory.Memory._ultoa(value, Pointer, 10);
#endif
        return this;
    }
    //   => Append(value.ToString());

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append(char value)
    {
        *(Pointer + currentPosition++) = unchecked((byte)(value & 0x7f)); ;
        return this;
    }
    // => Append(value.ToString());

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append(byte value)
    {
        *(Pointer + currentPosition++) = value;
        return this;
    }
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append(sbyte value)
    {
        *(Pointer + currentPosition++) = (byte)value;
        return this;
    }
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append(float value) => Append(value.ToString());

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append(double value) => Append(value.ToString());

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append(Str value)
    {
#if WINDOWS
        Hemy.Lib.Core.Platform.Windows.Memory.Memory.Copy(value.Pointer, Pointer, value.Size);
#endif
        return this;
    }
    // => Append(value.ToString());    // TODO: Append str use copy instead


    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append<T1>(T1 value1) where T1 : notnull
        => Append(value1);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append<T1, T2>(T1 value1, T2 value2) where T1 : notnull where T2 : notnull
        => Append(value1).Append(value2);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append<T1, T2, T3>(T1 value1, T2 value2, T3 value3) where T1 : notnull where T2 : notnull where T3 : notnull
        => Append(value1, value2).Append(value3);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
        => Append(value1, value2, value3).Append(value4);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append<T1, T2, T3, T4, T5>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull
        => Append(value1, value2, value3, value4).Append(value5);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append<T1, T2, T3, T4, T5, T6>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull
        => Append(value1, value2, value3, value4, value5).Append(value6);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append<T1, T2, T3, T4, T5, T6, T7>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull
    => Append(value1, value2, value3, value4, value5, value6).Append(value7);


    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append<T1, T2, T3, T4, T5, T6, T7, T8>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull
        => Append(value1, value2, value3, value4, value5, value6, value7).Append(value8);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public Str Append<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6, T7 value7, T8 value8, T9 value9)
        where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull
        => Append(value1, value2, value3, value4, value5, value6, value7, value8).Append(value9);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public void Clear()
    {
        NativeMemory.Clear(Pointer, Size);
#if WINDOWS

#endif
        currentPosition = 0;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public static unsafe implicit operator byte*(Str value) => value.Pointer;

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public static implicit operator string(Str str) => str.ToString();

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public static implicit operator Str(string str) => new(str);


    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public override string ToString()
    => BytesToString(Pointer, currentPosition != Size ? currentPosition : Size - 1);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public bool Equals(Str other) => false;// TODO if lenght == length and test all car exit if diff

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public override bool Equals(object obj) => obj is Str && Equals((Str)obj);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public static bool operator ==(Str left, Str right) => left.Equals(right);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public static bool operator !=(Str left, Str right) => !(left == right);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public override int GetHashCode() => (int)Size ^ 357;

    #endregion
}