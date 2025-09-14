namespace Hemy.Lib.Core.Math;

using System.Runtime.InteropServices;
using System;
using static Math;
using System.Runtime.CompilerServices;


[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public struct Vector4 : IEquatable<Vector4>
{
    #region Default value    
     public static readonly int SizeInBytes =sizeof(float) * 3 ;
    private static readonly Vector4 zero = new(0.0f, 0.0f, 0.0f, 0.0f);
    // [SkipLocalsInit]
    public static ref readonly Vector4 Zero => ref zero;
    public static readonly Vector4 one = new(1.0f, 1.0f, 1.0f, 1.0f);
    // [SkipLocalsInit]
    public static ref readonly Vector4 One => ref one;
    //     public static readonly Vector4 UnitX = new(1.0f, 0.0f, 0.0f, 0.0f);
    //     public static readonly Vector4 UnitY = new(0.0f, 1.0f, 0.0f, 0.0f);
    //     public static readonly Vector4 UnitZ = new(0.0f, 0.0f, 1.0f, 0.0f);
    //     public static readonly Vector4 UnitW = new(0.0f, 0.0f, 0.0f, 0.0f);

    #endregion

    #region ACCESSOR

    /// <summary>Axe  Abcisse X  </summary>
    public float X = 0.0f;
    /// <summary> Axe Ordonnée  </summary>
    public float Y = 0.0f;
    /// <summary> Axe Z ( 3D )  </summary>
    public float Z = 0.0f;
    /// <summary> Direction  </summary>
    public float W = 0.0f;

    /// <summary>
    /// Retourne la valeur abcisse ou ordonée utilisation comme un tableau  vecteur2[0] ou vecteur2[1]
    /// </summary>
    /// <value></value>
    // [SkipLocalsInit]
    public float this[int index]
    {
        readonly get => index switch
        {
            0 => X,
            1 => Y,
            2 => Z,
            3 => W,
            _ => float.NaN
        };
        set => _ = index switch
        {
            0 => X = value,
            1 => Y = value,
            2 => Z = value,
            3 => W = value,
            _ => float.NaN
        };
    }

    /// <summary>  retourn Vector4 sous forme de tableu de reel float[4] </summary>
    public readonly float[] ToArray => [X, Y, Z, W];

    #endregion

    #region OPERATION BINAIRE

    public static Vector4 operator *(Vector4 left, Vector4 right)
        => new(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);

    public static Vector4 operator *(float scale, Vector4 value)
        => new(value.X * scale, value.Y * scale, value.Z * scale, value.W * scale);

    public static Vector4 operator *(Vector4 value, float scale)
        => new(value.X * scale, value.Y * scale, value.Z * scale, value.W * scale);

    public static Vector4 operator +(Vector4 left, Vector4 right)
        => new(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

    public static Vector4 operator +(Vector4 value, float scalar)
        => new(value.X + scalar, value.Y + scalar, value.Z + scalar, value.W + scalar);

    public static Vector4 operator +(float scalar, Vector4 value)
        => new(scalar + value.X, scalar + value.Y, scalar + value.Z, scalar + value.W);

    public static Vector4 operator /(Vector4 value, float scale)
        => new(value.X / scale, value.Y / scale, value.Z / scale, value.W / scale);

    public static Vector4 operator -(Vector4 value, float scalar)
        => new(value.X - scalar, value.Y - scalar, value.Z - scalar, value.W - scalar);

    public static Vector4 operator -(float scalar, Vector4 value)
        => new(scalar - value.X, scalar - value.Y, scalar - value.Z, scalar - value.W);

    public static Vector4 operator -(Vector4 left, Vector4 right)
        => new(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);

    public static Vector4 operator -(Vector4 value)
    {
        value.Negate();
        return value;
    }
    #endregion

    #region CONSTRUCTOR
    /// <summary>
    /// Constructeur complet 
    /// </summary>
    /// <param name="x"> axe x </param>
    /// <param name="y">axe y </param>
    /// <param name="z"></param>
    /// <param name="w"></param>
    /// <returns></returns>
    public Vector4(float x = 0.0f, float y = 0.0f, float z = 0.0f, float w = 0.0f)
        => (X, Y, Z, W) = (x, y, z, w);

    /// <summary>
    /// Constrcuteur a partir d'un tableau de flotant
    /// </summary>
    /// <param name="floats"></param>
    /// <returns></returns>
    public Vector4(float[] floats)
        => (X, Y, Z, W) = (floats[0], floats[1], floats[2], floats[3]);

    /// <summary>
    /// Instanciate a partir d'un scalaire
    /// </summary>
    /// <param name="scalar"></param>
    public Vector4(float scalar)
        => (X, Y, Z, W) = (scalar, scalar, scalar, scalar);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="vec4"></param>
    public Vector4(Vector4 vec4)
        => (X, Y, Z, W) = (vec4.X, vec4.Y, vec4.Z, vec4.W);

    #endregion

    #region Mutable
    /// <summary>
    /// Normalize un vecteur
    /// </summary>
    public void Normalize()
    {
        float length = InverseSqrt(Length);
        X *= length;
        Y *= length;
        Z *= length;
        W *= length;
    }
    /// <summary>
    ///  le negatif de chaque valeurs
    /// </summary>
    public void Negate() => (X, Y, Z, W) = (-X, -Y, -Z, -W);

    /// <summary>
    /// To retrieve the length/magnitude of a vector we use the Pythagoras theorem that you may remember from your math classes. 
    /// A vector forms a triangle when you visualize its individual x and y component as two sides of a triangle:
    /// </summary>
    /// <returns>Magnitude</returns>
    public readonly float Length => Sqrt(LengthSquared);
    /// <summary>
    /// Calculates the squared length of the vector.
    /// </summary>
    /// <returns>The squared length of the vector.</returns>
    /// <remarks>This method may be preferred to <see cref="Length" /> when only a relative length is needed and speed is of the essence.</remarks>
    public readonly float LengthSquared => X * X + Y * Y + Z * Z + W * W;

    #endregion      

    #region OVERRIDE        
    public override readonly string ToString() => $"[X={X:G3};Y={Y:G3};Z={Z:G3};W={W:G3}]";
    public override readonly int GetHashCode() => HashCode.Combine(X, Y, Z, W);
    public override readonly bool Equals(object obj) => obj is Vector4 vec && Equals(vec);
    public readonly bool Equals(Vector4 other) => (Abs(X - other.X) <= 0.0f)
        && (Abs(Y - other.Y) <= 0.0f)
        && (Abs(Z - other.Z) <= 0.0f)
        && (Abs(W - other.W) <= 0.0f);
    public static bool operator ==(Vector4 left, Vector4 right) => left.Equals(right);
    public static bool operator !=(Vector4 left, Vector4 right) => !left.Equals(right);

    #endregion
}