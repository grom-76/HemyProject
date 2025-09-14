namespace Hemy.Lib.Core.Math;

using System.Runtime.InteropServices;
using System;
using static Math;
using System.Runtime.CompilerServices;
using System.Security;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public struct Vector2 : IEquatable<Vector2>
{
    #region Default value        

    private static readonly Vector2 zero = new(0.0f, 0.0f);
    // [SkipLocalsInit]
    public static ref readonly Vector2 Zero => ref zero;
    public static readonly Vector2 one = new(1.0f, 1.0f);
    // [SkipLocalsInit]
    public static ref readonly Vector2 One => ref one;
    public static readonly int SizeInBytes = sizeof(float) * 2;

    #endregion

    #region ACCESSOR

    /// <summary>Axe  Abcisse X  </summary>
    public float X = 0.0f;
    /// <summary> Axe Ordonnée  </summary>
    public float Y = 0.0f;

    /// <summary>
    /// Retourne la valeur abcisse ou ordonée utilisation comme un tableau  vecteur2[0] ou vecteur2[1]
    /// </summary>
    /// <value></value>
    public float this[int index]
    {
        readonly get => index switch
        {
            0 => X,
            1 => Y,
            _ => float.NaN
        };
        set => _ = index switch
        {
            0 => X = value,
            1 => Y = value,
            _ => float.NaN
        };
    }

    /// <summary>
    /// retourn Vector2 sous forme de tableu de reel float[4]
    /// </summary>
    /// <value></value>
    public readonly float[] ToArray => [X, Y];
    #endregion  

    #region OPERATION BINAIRE

    public static Vector2 operator *(Vector2 left, Vector2 right)
        => new(left.X * right.X, left.Y * right.Y);

    public static Vector2 operator *(float scale, Vector2 value)
        => new(value.X * scale, value.Y * scale);

    public static Vector2 operator *(Vector2 value, float scale)
        => new(value.X * scale, value.Y * scale);

    public static Vector2 operator +(Vector2 left, Vector2 right)
        => new(left.X + right.X, left.Y + right.Y);

    public static Vector2 operator +(Vector2 value, float scalar)
        => new(value.X + scalar, value.Y + scalar);

    public static Vector2 operator +(float scalar, Vector2 value)
        => new(scalar + value.X, scalar + value.Y);

    public static Vector2 operator /(Vector2 value, float scale)
        => new(value.X / scale, value.Y / scale);

    public static Vector2 operator -(Vector2 value, float scalar)
        => new(value.X - scalar, value.Y - scalar);

    public static Vector2 operator -(float scalar, Vector2 value)
        => new(scalar - value.X, scalar - value.Y);

    public static Vector2 operator -(Vector2 left, Vector2 right)
        => new(left.X - right.X, left.Y - right.Y);

    public static Vector2 operator -(Vector2 value) => -value;

    #endregion

    #region Mutatable   

    /// <summary>
    /// Normalize un vecteur
    /// </summary>
    public void Normalize()
    {
        float length = InverseSqrt(Length);
        X *= length;
        Y *= length;
    }

    /// <summary>
    ///  le negatif de chaque valeurs
    /// </summary>
    public void Negate() => (X, Y) = (-X, -Y);

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
    public readonly float LengthSquared => X * X + Y * Y;

    #endregion

    #region CONSTRUCTOR

    /// <summary>
    /// Constructeur complet 
    /// </summary>
    /// <param name="x"> axe x </param>
    /// <param name="y">axe y </param>
    /// <param name="z"></param>
    /// <returns></returns>
    public Vector2(float x = 0.0f, float y = 0.0f) => (X, Y) = (x, y);

    /// <summary>
    /// Equivelent construteur de Copie
    /// </summary>
    /// <param name="v"></param>
    /// <param name="z"></param>
    /// <param name="w"></param>
    /// <returns></returns>
    public Vector2(Vector2 v) => (X, Y) = (v.X, v.Y);

    /// <summary>
    /// Constrcuteur a partir d'un tableau de flotant
    /// </summary>
    /// <param name="floats"></param>
    /// <returns></returns>
    public Vector2(float[] floats) => (X, Y) = (floats[0], floats[1]);

    /// <summary>
    /// Instanciate a partir d'un scalaire
    /// </summary>
    /// <param name="scalar"></param>
    public Vector2(float scalar) => (X, Y) = (scalar, scalar);

    #endregion        

    #region OVERRIDE        

    public readonly override string ToString() => $"[{X:G3};{Y:G3}]";
    public readonly override int GetHashCode() => HashCode.Combine(X, Y);
    public readonly override bool Equals(object obj) => obj is Vector2 vec && Equals(vec);
    public readonly bool Equals(Vector2 other) => Abs(X - other.X) <= 0.0f && Abs(Y - other.Y) <= 0.0f;
    public static bool operator ==(Vector2 left, Vector2 right) => left.Equals(right);
    public static bool operator !=(Vector2 left, Vector2 right) => !left.Equals(right);

    #endregion
    
    
}


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public static class Vector2DExt
{
    #region VECTOR2 EXTENSION
    // Source : https://github.com/exomia/framework/blob/master/src/Exomia.Framework/Mathematics/Extensions/Vector/Vector2Extensions.cs

    /// <summary>
    ///     Calculate the angle from the anchor point to another point vector.
    /// </summary>
    /// <param name="anchor"> This anchor <see cref="Vector2" />. </param>
    /// <param name="point"> The point <see cref="Vector2" />. </param>
    /// <returns>
    ///     The angle from anchor vector to the point vector in radians.
    /// </returns>
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double AngleTo(this Vector2 anchor, in Vector2 point)
        => ATan2(point.Y - anchor.Y, point.X - anchor.X);

    /// <summary>
    ///     Calculate the angle between two vectors.
    /// </summary>
    /// <param name="vec1"> This <see cref="Vector2" />. </param>
    /// <param name="vec2"> The <see cref="Vector2" />. </param>
    /// <returns>
    ///     The angle between the two vectors in radians.
    /// </returns>
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double AngleBetween(this Vector2 vec1, in Vector2 vec2)
    => ATan2((vec1.X * vec2.Y) - (vec2.X * vec1.Y), (vec1.X * vec2.X) + (vec1.Y * vec2.Y));

    /// <summary>
    ///     Calculates the horizontal angle of a <see cref="Vector2" />.
    /// </summary>
    /// <param name="vec"> This <see cref="Vector2" />. </param>
    /// <returns>
    ///     The angle horizontal.
    /// </returns>
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double AngleHorizontal(this Vector2 vec)
        => ATan2(vec.Y, vec.X);

    /// <summary>
    ///     Calculates the vertical angle of a <see cref="Vector2" />.
    /// </summary>
    /// <param name="vec"> This <see cref="Vector2" />. </param>
    /// <returns>
    ///     The angle vertical.
    /// </returns>
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static double AngleVertical(this Vector2 vec)
        => ATan2(vec.X, vec.Y);


    /// <summary>
    ///     Rotate a <see cref="Vector2" /> by an angle (in radian)
    /// </summary>
    /// <param name="vec">   This <see cref="Vector2" />. </param>
    /// <param name="angle"> angle. </param>
    /// <returns>
    ///     The new rotated <see cref="Vector2" />.
    /// </returns>
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector2 Rotate(this Vector2 vec, double angle)
    {
        double sin = Sin(angle);
        double cos = Cos(angle);
        return new Vector2((float)((vec.X * cos) - (vec.Y * sin)), (float)((vec.X * sin) + (vec.Y * cos)));
    }

    /// <summary>
    ///     Transforms the <see cref="Vector2" /> with a transform <see cref="Matrix" />.
    /// </summary>
    /// <param name="vec">       this vec. </param>
    /// <param name="transform"> transform. </param>
    /// <returns>
    ///     the new <see cref="Vector2" />.
    /// </returns>
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector2 Transform(this Vector2 vec, in Matrix transform)
    {
        return new Vector2(
            (vec.X * transform.M11) + (vec.Y * transform.M21) + transform.M41,
            (vec.X * transform.M12) + (vec.Y * transform.M22) + transform.M42);
    }
    
    #endregion

}