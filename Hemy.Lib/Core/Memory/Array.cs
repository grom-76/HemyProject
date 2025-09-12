namespace HE2.Core;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;




public readonly unsafe struct Array(uint count, uint itemMaxSize)
{
    readonly uint _count = count;
    readonly uint _maxSizeItem = itemMaxSize;
#if WINDOWS
    readonly byte* _array = (byte*)NativeMemory.AllocZeroed(count * itemMaxSize);
    readonly byte* _pointer = (byte*)NativeMemory.AllocZeroed(count, (nuint)Unsafe.SizeOf<IntPtr>());
#endif
    /// <summary> le nombre de ligne du tableau </summary>
    public readonly uint Count => _count;

    /// <summary> Acces direct en lecture seule au debut du tableau ligne zéro caractère zéro </summary>
    public readonly byte* Pointer => _pointer;

    /// <summary> Ajoute un nouvel élément au tableau  </summary>
    /// <param name="value"> pointeur au format byte  de la chaine d'entrée</param>
    /// <param name="index">specifie la ligne d'insertion doit être superieur à zéro ou inferieur a count </param>
    /// <returns></returns> 
    public readonly bool Add(byte* value, uint index)
    {
        if (value is null) return false;

        if (index <= 0 && index >= _count) return false;

        uint size = Str.Length(value) + 1;
#if WINDOWS
        // Memory.Copy(value, _array + ((uint)_maxSizeItem * index), size);
        NativeMemory.Copy(value, _array + ((uint)_maxSizeItem * index), size);
#endif
        ((byte**)_pointer)[index] = _array + ((uint)_maxSizeItem * index);

        return true;
    }

    /// <summary> Ajoute un nouvel élément au tableau  </summary>
    /// <param name="value"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public readonly bool Add(string value, uint index)
    {
        if (string.IsNullOrEmpty(value)) return false;

        if (index <= 0 && index >= _count) return false;

        uint size = (uint)value.Length + 1;

        uint position = (uint)_maxSizeItem * index;

        int i = 0;
        while (i < value.Length)
        {
            *(_array + position + i) = (byte)value[i++];
        }
        *(_array + position + i) = 0;

        ((byte**)_pointer)[index] = _array + position;

        return true;
    }

    /// <summary> Retourne au format string c# la chaine à la ligne spécifié. </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public readonly string GetString(uint index)
    {
        var bytes = _array + (_maxSizeItem * index);
        // REPLACE  System.text (no dependencies )  var r = System.Text.Encoding.UTF8.GetString(bytes, (int)Str.Length(bytes));
        string response = string.Empty;

        int position = 0;
        char c = (char)bytes[position++];

        while (c != '\0' && position <= _maxSizeItem)
        {
            response += c;
            c = (char)bytes[position++];
        }

        return response;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="match"></param>
    /// <returns></returns>
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
        get => _array + (_maxSizeItem * index);
        set => Add(value, index);
    }

    /// <summary> Quitter proprement  </summary>
    public readonly void Dispose()
    {
#if WINDOWS
        NativeMemory.Free(_array);
        NativeMemory.Free(_pointer);
#endif
    }

    public static implicit operator byte**(Array array) => (byte**)array._pointer;
}
