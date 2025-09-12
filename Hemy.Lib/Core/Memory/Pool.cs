namespace Hemy.Lib.Core.Memory;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Pool
{
    readonly byte* _startPositionInPool = null;
    byte* _currentPositionInPool = null;

    public Pool(uint capacity = 8192)
    {
        _startPositionInPool = (byte*)Memory.NewArray<byte>(capacity);
        _currentPositionInPool = _startPositionInPool + capacity;
    }

    public void Dispose()
    {
        Memory.DisposeArray(_startPositionInPool);
        _currentPositionInPool = null;
    }

    public T* New<T>( T newInstance, uint itemCount = 1) where T : unmanaged
    {
        uint itemSize = (uint)Memory.Size<T>();

        _currentPositionInPool -= (itemSize * itemCount);

        for (uint i = 0; i < itemCount; i++)
        {
            Memory.Copy(Memory.ToPtr(ref newInstance), _currentPositionInPool + (itemSize * i), itemSize);
        }

        return (T*)_currentPositionInPool;
    }
}