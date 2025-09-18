namespace Hemy.Lib.Core.Math;

using System.Runtime.InteropServices;
using System;
using static Math;
using System.Runtime.CompilerServices;
using System.Security;

[SkipLocalsInit]
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Matrix4 : IEquatable<Matrix4>
{
    /// <summary> The size of the <see cref="Matrix" /> type, in bytes. </summary>
    
    public static readonly int SizeInBytes = 16 * sizeof(float);
    
    private static readonly Matrix4 identity =  new() {  M11 = 1.0f,  M22 = 1.0f,  M33 = 1.0f, M44 = 1.0f };

    // [SkipLocalsInit]
    public static ref readonly Matrix4 Identity => ref identity;

    /// <summary> Value at row 1 column 1 of the matrix. </summary>
    public float M11 = 0.0f;

    /// <summary> Value at row 1 column 2 of the matrix. </summary>
    public float M12 = 0.0f;

    /// <summary> Value at row 1 column 3 of the matrix. </summary>
    public float M13= 0.0f;

    /// <summary> Value at row 1 column 4 of the matrix. </summary>
    public float M14= 0.0f;

    /// <summary> Value at row 2 column 1 of the matrix. </summary>
    public float M21= 0.0f;

    /// <summary> Value at row 2 column 2 of the matrix. </summary>
    public float M22= 0.0f;

    /// <summary> Value at row 2 column 3 of the matrix. </summary>
    public float M23= 0.0f;

    /// <summary> Value at row 2 column 4 of the matrix. </summary>
    public float M24= 0.0f;

    /// <summary> Value at row 3 column 1 of the matrix. </summary>
    public float M31= 0.0f;

    /// <summary> Value at row 3 column 2 of the matrix. </summary>
    public float M32= 0.0f;

    /// <summary> Value at row 3 column 3 of the matrix. </summary>
    public float M33= 0.0f;

    /// <summary> Value at row 3 column 4 of the matrix. </summary>
    public float M34= 0.0f;

    /// <summary> Value at row 4 column 1 of the matrix. </summary>
    public float M41= 0.0f;

    /// <summary> Value at row 4 column 2 of the matrix. </summary>
    public float M42= 0.0f;

    /// <summary> Value at row 4 column 3 of the matrix. </summary>
    public float M43= 0.0f;

    /// <summary> Value at row 4 column 4 of the matrix. </summary>
    public float M44= 0.0f;


    #region ACCESSOR
    /// <summary>
    /// Gets or sets the up <see cref="Vector3" /> of the matrix; that is M21, M22, and M23.
    /// </summary>
    public Vector3 Up
    {
        readonly get => new(M21, M22, M23);
        set
        {
            M21 = value.X;
            M22 = value.Y;
            M23 = value.Z;
        }
    }

    /// <summary>
    /// Gets or sets the down <see cref="Vector3" /> of the matrix; that is -M21, -M22, and -M23.
    /// </summary>
    public Vector3 Down
    {
        readonly get => new (-M21, -M22, -M23);
        set
        {
            M21 = -value.X;
            M22 = -value.Y;
            M23 = -value.Z;
        }
    }

    /// <summary>
    /// Gets or sets the right <see cref="Vector3" /> of the matrix; that is M11, M12, and M13.
    /// </summary>
    public Vector3 Right
    {
        readonly get => new(M11, M12, M13);
        set
        {
            M11 = value.X;
            M12 = value.Y;
            M13 = value.Z;
        }
    }

    /// <summary>
    /// Gets or sets the left <see cref="Vector3" /> of the matrix; that is -M11, -M12, and -M13.
    /// </summary>
    public Vector3 Left
    {
        readonly get => new(-M11, -M12, -M13);
        set
        {
            M11 = -value.X;
            M12 = -value.Y;
            M13 = -value.Z;
        }
    }

    /// <summary>
    /// Gets or sets the forward <see cref="Vector3" /> of the matrix; that is -M31, -M32, and -M33.
    /// </summary>
    public Vector3 Forward
    {
        readonly get => new(-M31, -M32, -M33);
        set
        {
            M31 = -value.X;
            M32 = -value.Y;
            M33 = -value.Z;
        }
    }

    /// <summary>
    /// Gets or sets the backward <see cref="Vector3" /> of the matrix; that is M31, M32, and M33.
    /// </summary>
    public Vector3 Backward
    {
        readonly get => new(M31, M32, M33);
        set
        {
            M31 = value.X;
            M32 = value.Y;
            M33 = value.Z;
        }
    }

    /// <summary>
    /// Gets or sets the translation of the matrix; that is M41, M42, and M43.
    /// </summary>
    public Vector3 Translation
    {
        readonly get => new(M41, M42, M43);
        set
        {
            M41 = value.X;
            M42 = value.Y;
            M43 = value.Z;
        }
    }
        /// <summary>
    /// Gets or sets the scale of the matrix; that is M11, M22, and M33.
    /// </summary>
    public Vector3 Scale
    {
        readonly get => new (M11, M22, M33);
        set
        {
            M11 = value.X;
            M22 = value.Y;
            M33 = value.Z;
        }
    }

     /// <summary>
    /// Retourne la valeur abcisse ou ordonée utilisation comme un tableau  vecteur2[0] ou vecteur2[1]
    /// </summary>
    /// <value></value>
    public float this[int index]
    { 
        readonly get => index switch
        {
            0 => M11,
            1 => M12,
            2 => M13,
            3 => M14,

            4 => M21,
            5 => M22,
            6 => M23,
            7 => M24,

            8  => M31,
            9  => M32,
            10 => M33,
            11 => M34,

            12 => M41,
            13 => M42,
            14 => M43,
            15 => M44,

            _ => throw new ArgumentOutOfRangeException(nameof(index), "Indices for Matrix run from 0 to 15, inclusive.")
        };
        set => _ = index switch
        {
            0 => M11 = value,
            1 => M12 = value,
            2 => M13 = value,
            3 => M14 = value,

            4 => M21 = value,
            5 => M22 = value,
            6 => M23 = value,
            7 => M24 = value,

            8  => M31 = value,
            9  => M32 = value,
            10 => M33 = value,
            11 => M34 = value,

            12 => M41 = value,
            13 => M42 = value,
            14 => M43 = value,
            15 => M44 = value,

            _ => throw new ArgumentOutOfRangeException(nameof(index), "Indices for Matrix run from 0 to 15, inclusive.")
        };
    }

    /// <summary>
    /// Gets or sets the component at the specified index.
    /// </summary>
    /// <value>The value of the matrix component, depending on the index.</value>
    /// <param name="row">The row of the matrix to access.</param>
    /// <param name="column">The column of the matrix to access.</param>
    /// <returns>The value of the component at the specified index.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the <paramref name="row" /> or <paramref name="column" />is out of the range [0, 3].</exception>
    public float this[int row, int column]
    {
        readonly get
        {
            if (row < 0 || row > 3)throw new ArgumentOutOfRangeException(nameof(row), "Rows and columns for matrices run from 0 to 3, inclusive.");
            if (column < 0 || column > 3)throw new ArgumentOutOfRangeException(nameof(column), "Rows and columns for matrices run from 0 to 3, inclusive.");
            return this[row * 4 + column];
        }
        set
        {
            if (row < 0 || row > 3) throw new ArgumentOutOfRangeException(nameof(row), "Rows and columns for matrices run from 0 to 3, inclusive.");
            if (column < 0 || column > 3) throw new ArgumentOutOfRangeException(nameof(column), "Rows and columns for matrices run from 0 to 3, inclusive.");
            this[row * 4 + column] = value;
        }
    }

    /// <summary>
    /// Creates an array containing the elements of the matrix.
    /// </summary>
    /// <returns>A sixteen-element array containing the components of the matrix.</returns>
    public readonly float[] ToArray=> [M11,M12,M13,M14,M21,M22,M23,M24,M31,M32,M33,M34,M41,M42,M43,M44];

    

    #endregion

    #region CONSTRUCTOR 
    /// <summary>
    /// Initializes a new instance of the <see cref="Matrix" /> struct.
    /// </summary>
    /// <param name="value">The value that will be assigned to all components.</param>
    public Matrix4(float value)
    {
        M11 = M12 = M13 = M14 = M21 = M22 = M23 = M24 = M31 = M32 = M33 = M34 = M41 = M42 = M43 = M44 = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Matrix" /> struct.
    /// </summary>
    /// <param name="m11">The value to assign at row 1 column 1 of the matrix.</param>
    /// <param name="m12">The value to assign at row 1 column 2 of the matrix.</param>
    /// <param name="m13">The value to assign at row 1 column 3 of the matrix.</param>
    /// <param name="m14">The value to assign at row 1 column 4 of the matrix.</param>
    /// <param name="m21">The value to assign at row 2 column 1 of the matrix.</param>
    /// <param name="m22">The value to assign at row 2 column 2 of the matrix.</param>
    /// <param name="m23">The value to assign at row 2 column 3 of the matrix.</param>
    /// <param name="m24">The value to assign at row 2 column 4 of the matrix.</param>
    /// <param name="m31">The value to assign at row 3 column 1 of the matrix.</param>
    /// <param name="m32">The value to assign at row 3 column 2 of the matrix.</param>
    /// <param name="m33">The value to assign at row 3 column 3 of the matrix.</param>
    /// <param name="m34">The value to assign at row 3 column 4 of the matrix.</param>
    /// <param name="m41">The value to assign at row 4 column 1 of the matrix.</param>
    /// <param name="m42">The value to assign at row 4 column 2 of the matrix.</param>
    /// <param name="m43">The value to assign at row 4 column 3 of the matrix.</param>
    /// <param name="m44">The value to assign at row 4 column 4 of the matrix.</param>
    public Matrix4(float m11, float m12, float m13, float m14,
                    float m21, float m22, float m23, float m24,
                    float m31, float m32, float m33, float m34,
                    float m41, float m42, float m43, float m44)
    {
        M11 = m11;
        M12 = m12;
        M13 = m13;
        M14 = m14;
        M21 = m21;
        M22 = m22;
        M23 = m23;
        M24 = m24;
        M31 = m31;
        M32 = m32;
        M33 = m33;
        M34 = m34;
        M41 = m41;
        M42 = m42;
        M43 = m43;
        M44 = m44;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Matrix" /> struct.
    /// </summary>
    /// <param name="values">The values to assign to the components of the matrix. This must be an array with sixteen elements.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="values" /> is <c>null</c>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="values" /> contains more or less than sixteen
    /// elements.
    /// </exception>
    public Matrix4(float[] values)
    {
        // Guard if (values == null) throw new ArgumentNullException(nameof(values));
        // if (values.Length != 16) throw new ArgumentOutOfRangeException(nameof(values), "There must be sixteen and only sixteen input values for Matrix.");

        M11 = values[0]; M21 = values[4]; M31 = values[8]; M41 = values[12];
        M12 = values[1]; M22 = values[5]; M32 = values[9]; M42 = values[13];
        M13 = values[2]; M23 = values[6]; M33 = values[10]; M43 = values[14];
        M14 = values[3]; M24 = values[7]; M34 = values[11]; M44 = values[15];
    }
    
    #endregion


    /// <summary>
    /// Gets a value indicating whether this instance is an identity matrix.
    /// </summary>
    public readonly bool IsIdentity => Equals(Identity);

    /// <summary>
    /// Calculates the determinant of the matrix.
    /// </summary>
    /// <returns>The determinant of the matrix.</returns>
    public readonly float Determinant()
    {
        float temp1 = M33 * M44 - M34 * M43;
        float temp2 = M32 * M44 - M34 * M42;
        float temp3 = M32 * M43 - M33 * M42;
        float temp4 = M31 * M44 - M34 * M41;
        float temp5 = M31 * M43 - M33 * M41;
        float temp6 = M31 * M42 - M32 * M41;
        return M11 * (M22 * temp1 - M23 * temp2 + M24 * temp3) - M12 * (M21 * temp1 - M23 * temp4 + M24 * temp5) + M13 * (M21 * temp2 - M22 * temp4 + M24 * temp6) - M14 * (M21 * temp3 - M22 * temp5 + M23 * temp6);
    }

    #region OPERATORS
    
    // /// <summary>
    // /// Adds two matrices.
    // /// </summary>
    // /// <param name="left">The first matrix to add.</param>
    // /// <param name="right">The second matrix to add.</param>
    // /// <returns>The sum of the two matrices.</returns>
    public static Matrix4 operator + (Matrix4 left, Matrix4 right)
    => new() {
            M11 = left.M11 + right.M11,
            M12 = left.M12 + right.M12,
            M13 = left.M13 + right.M13,
            M14 = left.M14 + right.M14,
            M21 = left.M21 + right.M21,
            M22 = left.M22 + right.M22,
            M23 = left.M23 + right.M23,
            M24 = left.M24 + right.M24,
            M31 = left.M31 + right.M31,
            M32 = left.M32 + right.M32,
            M33 = left.M33 + right.M33,
            M34 = left.M34 + right.M34,
            M41 = left.M41 + right.M41,
            M42 = left.M42 + right.M42,
            M43 = left.M43 + right.M43,
            M44 = left.M44 + right.M44
        };

   
    public static Matrix4 operator - (Matrix4 left, Matrix4 right)
    => new() {
            M11 = left.M11 - right.M11,
            M12 = left.M12 - right.M12,
            M13 = left.M13 - right.M13,
            M14 = left.M14 - right.M14,
            M21 = left.M21 - right.M21,
            M22 = left.M22 - right.M22,
            M23 = left.M23 - right.M23,
            M24 = left.M24 - right.M24,
            M31 = left.M31 - right.M31,
            M32 = left.M32 - right.M32,
            M33 = left.M33 - right.M33,
            M34 = left.M34 - right.M34,
            M41 = left.M41 - right.M41,
            M42 = left.M42 - right.M42,
            M43 = left.M43 - right.M43,
            M44 = left.M44 - right.M44
        };


   
    // /// <summary>
    // /// Scales a matrix by a given value.
    // /// </summary>
    // /// <param name="left">The matrix to scale.</param>
    // /// <param name="right">The amount by which to scale.</param>
    // /// <returns>The scaled matrix.</returns>
    public static Matrix4 operator *(Matrix4 left, Matrix4 right)
    => new(){
            M11 = left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31 + left.M14 * right.M41,
            M12 = left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32 + left.M14 * right.M42,
            M13 = left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33 + left.M14 * right.M43,
            M14 = left.M11 * right.M14 + left.M12 * right.M24 + left.M13 * right.M34 + left.M14 * right.M44,
            M21 = left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31 + left.M24 * right.M41,
            M22 = left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32 + left.M24 * right.M42,
            M23 = left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33 + left.M24 * right.M43,
            M24 = left.M21 * right.M14 + left.M22 * right.M24 + left.M23 * right.M34 + left.M24 * right.M44,
            M31 = left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31 + left.M34 * right.M41,
            M32 = left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32 + left.M34 * right.M42,
            M33 = left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33 + left.M34 * right.M43,
            M34 = left.M31 * right.M14 + left.M32 * right.M24 + left.M33 * right.M34 + left.M34 * right.M44,
            M41 = left.M41 * right.M11 + left.M42 * right.M21 + left.M43 * right.M31 + left.M44 * right.M41,
            M42 = left.M41 * right.M12 + left.M42 * right.M22 + left.M43 * right.M32 + left.M44 * right.M42,
            M43 = left.M41 * right.M13 + left.M42 * right.M23 + left.M43 * right.M33 + left.M44 * right.M43,
            M44 = left.M41 * right.M14 + left.M42 * right.M24 + left.M43 * right.M34 + left.M44 * right.M44
        };

    
    public static Matrix4 operator /(Matrix4 left, Matrix4 right)
    => new()  {
            M11 = left.M11 / right.M11,
            M12 = left.M12 / right.M12,
            M13 = left.M13 / right.M13,
            M14 = left.M14 / right.M14,
            M21 = left.M21 / right.M21,
            M22 = left.M22 / right.M22,
            M23 = left.M23 / right.M23,
            M24 = left.M24 / right.M24,
            M31 = left.M31 / right.M31,
            M32 = left.M32 / right.M32,
            M33 = left.M33 / right.M33,
            M34 = left.M34 / right.M34,
            M41 = left.M41 / right.M41,
            M42 = left.M42 / right.M42,
            M43 = left.M43 / right.M43,
            M44 = left.M44 / right.M44
        } ;


    #endregion


    // /// <summary>
    // /// Returns a <see cref="System.String" /> that represents this instance.
    // /// </summary>
    // /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    public override readonly string ToString() 
        => string.Format( "[M11:{0} M12:{1} M13:{2} M14:{3}] [M21:{4} M22:{5} M23:{6} M24:{7}] [M31:{8} M32:{9} M33:{10} M34:{11}] [M41:{12} M42:{13} M43:{14} M44:{15}]",
                            M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44);
    

    public readonly bool EqualWith(ref Matrix4 other)
        =>  NearEqual(other.M11, M11) && NearEqual(other.M12, M12) &&  NearEqual(other.M13, M13) && NearEqual(other.M14, M14) &&
            NearEqual(other.M21, M21) && NearEqual(other.M22, M22) && NearEqual(other.M23, M23) && NearEqual(other.M24, M24) &&
            NearEqual(other.M31, M31) && NearEqual(other.M32, M32) && NearEqual(other.M33, M33) && NearEqual(other.M34, M34) &&
            NearEqual(other.M41, M41) && NearEqual(other.M42, M42) && NearEqual(other.M43, M43) && NearEqual(other.M44, M44);


    static bool NearEqual(float a,float b ) => Abs(a - b) <= 0.0f;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    static float Abs(float value)
    {
        const uint mask = 0x7FFFFFFF;
        uint raw = BitConverter.SingleToUInt32Bits(value);

        return BitConverter.UInt32BitsToSingle(raw & mask);
    }

    public readonly bool Equals(Matrix4 other) => EqualWith(ref other);
    public override readonly bool Equals(object value)=> value is Matrix4 mat && EqualWith(ref mat)  ;
    public static bool operator ==(Matrix4 left, Matrix4 right)  =>left.Equals(right);
   
    public static bool operator !=(Matrix4 left, Matrix4 right) => !left.Equals(right);
    public override readonly int GetHashCode() => HashCode.Combine(M11,M12,M13,M14) + HashCode.Combine(M21,M22,M23,M24) + HashCode.Combine(M31,M32,M33,M34) + HashCode.Combine(M41,M42,M43,M44);
    
}
