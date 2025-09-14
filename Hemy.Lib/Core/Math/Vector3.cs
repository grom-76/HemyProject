namespace Hemy.Lib.Core.Math;

using System.Runtime.InteropServices;
using System;
using static Math;
using System.Runtime.CompilerServices;
using System.Security;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public struct Vector3 : IEquatable<Vector3> 
{
    #region Default value    
    private static readonly Vector3 zero = new(0.0f,0.0f,0.0f);
    // [SkipLocalsInit]
    public static ref readonly Vector3 Zero => ref zero;
    public static readonly Vector3 one = new(1.0f,1.0f,1.0f);
    // [SkipLocalsInit]
    public static ref readonly Vector3 One => ref one;
    public static readonly int SizeInBytes =sizeof(float) * 3 ;

    #endregion

    #region ACCESSOR

    /// <summary>Axe  Abcisse X  </summary>
    public float X =0.0f;
    /// <summary> Axe Ordonnée  </summary>
    public float Y =0.0f;
    /// <summary> Axe Z ( 3D )  </summary>
    public float Z =0.0f;

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
            _ => float.NaN
        };
        set => _ = index switch
        {
            0 => X = value,
            1 => Y = value,
            2 => Z = value,
            _ => float.NaN
        };
    }
    
    /// <summary>
    /// retourn Vector3 sous forme de tableu de reel float[4]
    /// </summary>
    public readonly float[] ToArray =>  [X, Y, Z]; 

    #endregion

    #region OPERATION BINAIRE

    public static Vector3 operator *(float scale, Vector3 value)
        => new(value.X * scale, value.Y * scale, value.Z *scale);

    public static Vector3 operator *(Vector3 value, float scale)
        => new(value.X * scale, value.Y * scale, value.Z *scale);
    
    public static Vector3 operator *(Vector3 left, Vector3 right)
        => new(left.X * right.X, left.Y * right.Y, left.Z* right.Z);
    
    public static Vector3 operator +(Vector3 left, Vector3 right)
        => new(left.X + right.X, left.Y + right.Y , left.Z+right.Z);

    public static Vector3 operator +(Vector3 value, float scalar)
        => new(value.X + scalar, value.Y + scalar , value.Z + scalar) ;

    public static Vector3 operator +(float scalar, Vector3 value)
        => new(scalar + value.X, scalar + value.Y, scalar + value.Z);

    public static Vector3 operator /(Vector3 value, float scale)
        => new( value.X/scale , value.Y/ scale , value.Z/scale  );
    
    public static Vector3 operator /(Vector3 left,Vector3 right)
        => new( left.X/ right.X , left.Y / right.Y , left.Z / right.Z  );

    public static Vector3 operator -(Vector3 value, float scalar)
        => new(value.X - scalar, value.Y - scalar, value.Z - scalar);

    public static Vector3 operator -(float scalar, Vector3 value)
        => new(scalar - value.X, scalar - value.Y, scalar- value.Z);

    public static Vector3 operator - (Vector3 left, Vector3 right)
        => new(left.X - right.X, left.Y - right.Y,  left.Z - right.Z);

    public static Vector3 operator - (Vector3 value)
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
    /// <returns></returns>
    public Vector3(float x=0.0f, float y=0.0f, float z=0.0f) 
        =>(X, Y, Z) = (x,y,z);

    /// <summary>
    /// Equivelent construteur de Copie
    /// </summary>
    /// <param name="v"></param>
    /// <param name="z"></param>
    /// <param name="w"></param>
    /// <returns></returns>
    public Vector3( Vector2 v, float z=0.0f)
        =>(X,Y,Z) = ( v.X,v.Y, 0.0f);

    /// <summary>
    /// Constrcuteur a partir d'un tableau de flotant
    /// </summary>
    /// <param name="floats"></param>
    /// <returns></returns>
    public Vector3( float[] floats)
        =>(X, Y, Z) =( floats[0],floats[1],floats[2] );

    /// <summary>
    /// Instanciate a partir d'un scalaire
    /// </summary>
    /// <param name="scalar"></param>
    public Vector3(float scalar)
        =>(X, Y, Z) = ( scalar,scalar,scalar);

    public Vector3( Vector3 vec3)
        => (X, Y, Z) = ( vec3.X,vec3.Y,vec3.Z);
    
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
    }
    /// <summary>
    ///  le negatif de chaque valeurs
    /// </summary>
    public void Negate() =>(X, Y, Z) = (-X, -Y, -Z);
    
    /// <summary>
    /// To retrieve the length/magnitude of a vector we use the Pythagoras theorem that you may remember from your math classes. 
    /// A vector forms a triangle when you visualize its individual x and y component as two sides of a triangle:
    /// </summary>
    /// <returns>Magnitude</returns>
    public readonly float Length  =>  Sqrt( LengthSquared );
    /// <summary>
    /// Calculates the squared length of the vector.
    /// </summary>
    /// <returns>The squared length of the vector.</returns>
    /// <remarks>This method may be preferred to <see cref="Length" /> when only a relative length is needed and speed is of the essence.</remarks>
    public readonly float LengthSquared => X * X + Y * Y + Z * Z;

    #endregion      

    #region OVERRIDE        
    public override readonly string ToString()  => $"[X={X:G3};Y={Y:G3};Z={Z:G3}]";
    public override readonly int GetHashCode() => HashCode.Combine(X,Y,Z);
    public override readonly bool Equals(object obj) => obj is Vector3 vec && Equals(vec)  ;
    public readonly bool Equals(Vector3 other) => Abs(X - other.X) <= 0.0f && (Abs(Y - other.Y) <= 0.0f) && Abs(Z - other.Z) <= 0.0f  ;
    public static bool operator ==(Vector3 left, Vector3 right) => left.Equals(right);
    public static bool operator !=(Vector3 left, Vector3 right) => !left.Equals(right);
    #endregion
}