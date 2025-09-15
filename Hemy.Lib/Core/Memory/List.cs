namespace Hemy.Lib.Core.Memory;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;



/// <summary>  Unmanaged Array  same functionality than  T[] </summary>
[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Array<T> where T : unmanaged
{

    readonly T* poolData = null;
    readonly uint itemSize = 0;
    readonly uint itemCapacity = 0;
    uint itemCount = 0;

    public readonly uint Count => itemCount;
    public readonly uint Capacity => itemCapacity;
    public readonly uint Size => itemSize;
    public readonly uint Length => itemSize * itemCount;

    public Array() : this(10) { }

    public Array(int capacity, int size = 0)
    {
        itemSize = size == 0 ? (uint)Memory.Size<T>() : (uint)Memory.Size<T>() * (uint)size;
        itemCapacity = (uint)capacity; // count x size 
        itemCount = 0;

        poolData = (T*)Memory.NewArray<T>(itemCount);
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public unsafe void AddAt(int index, T value)
    {
        if ( index < 0 || index > itemCapacity)
            return;

        Memory.Copy(&value, poolData + (index * itemSize),  itemSize);// for copy defautl values of struct
        itemCount++;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public readonly unsafe T GetAt(int index)
    {
        // Guard.ThrowIf( index < 0 || index > itemCapacity ) ;
        return *(poolData + (index * itemSize));
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public void RemoveAt(uint index)
    {
        if ( index < 0 || index > itemCount) return;

        for (uint i = index; i < (itemCount - index + 1); i++)
            Memory.Copy(poolData + ((i + 1) * itemSize), poolData + (i * itemSize),  itemSize);

        itemCount--;
    }

    // public void Swap( int indexSource , int indexDestination )
    // {
    //     T copy =  GetAt(indexDestination);
    //     Interop.Copy ( poolData + indexSource* itemSize  ,  poolData +( indexDestination  * itemSize ), itemSize );

    // }

    // public readonly void Fill(T* value)
    // {
        
    //     // NativeMemory.Fill(poolData,itemCapacity *  itemSize  , (byte)value);
    // }

    // [ MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public void Clear()
    {
        Memory.Fill(poolData  ,0,itemCapacity *  itemSize  );
        itemCount = 0;
    }

    [SkipLocalsInit]
    public T this[int index]
    {
        [SkipLocalsInit]
        [SuppressGCTransition]
        [SuppressUnmanagedCodeSecurity]
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        readonly get => GetAt(index);

        set => AddAt(index, value);
    }


    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public readonly T? Find(System.Predicate<T> match)
    {
        for (uint i = 0; i < itemCount; i++)
        {
            T* result = poolData + (itemSize * i);
            if (match(*result))
                return *result;
        }
        return null;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public readonly void Dispose()
    {
        if (poolData is null) return;

        Memory.DisposeArray(poolData);
    }

    public static implicit operator T**(Array<T> array) => array.ToPointer();
    public static implicit operator T[](Array<T> array) => array.ToArray();

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public readonly T[] ToArray()
    {
        T[] result = new T[itemCount];

        for (int i = 0; i < itemCount; i++)
        {
            result[i] = *(poolData + (i * itemSize));
        }

        return result;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public readonly T** ToPointer()
    {
        T** Pointer = (T**)Memory.NewArray<T>(itemCount);

        for (int i = 0; i < Count; i++)
            Pointer[i] = poolData + (i * itemSize);

        return Pointer;
    }

}
