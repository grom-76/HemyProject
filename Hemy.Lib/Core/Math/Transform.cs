namespace Hemy.Lib.Core.Math;

using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#if WINDOWS
using static Hemy.Lib.Core.Platform.Windows.Math.MathFuncs ;
#endif

public static class Transform
{
    #region Projection

    public static Matrix4 CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
    {
        Matrix4 result = Matrix4.Identity;

        var yScale = 1.0f / (float)Math.Tan(fieldOfView * 0.5f);
        var xScale = yScale / aspectRatio;
        var negFarRange = float.IsPositiveInfinity(farPlaneDistance) ? -1.0f : farPlaneDistance / (nearPlaneDistance - farPlaneDistance);

        result.M11 = xScale; result.M12 = 0.0f; result.M13 = 0.0f; result.M14 = 0.0f;

        result.M21 = 0.0f; result.M22 = yScale; result.M23 = 0.0f; result.M24 = 0.0f;

        result.M31 = 0.0f; result.M32 = 0.0f; result.M33 = negFarRange; result.M34 = -1.0f;

        result.M41 = 0.0f; result.M42 = 0.0f; result.M44 = 0.0f; result.M43 = nearPlaneDistance * negFarRange;
        return result;
    }

    #endregion

    #region Transform

    public static Matrix4 Scaling(float x, float y, float z)
    {
        Matrix4 result = Matrix4.Identity;
        result.M11 = Math.Abs(x);
        result.M22 = Math.Abs(y);
        result.M33 = Math.Abs(z);
        return result;
    }

    public static Matrix4 RotationX(float angle)
    {
        var cos = (float)Math.Cos(angle);
        var sin = (float)Math.Sin(angle);
        Matrix4 result = Matrix4.Identity;
        result.M22 = cos;
        result.M23 = sin;
        result.M32 = -sin;
        result.M33 = cos;
        return result;
    }

    public static Matrix4 RotationY(float angle)
    {
        var cos = (float)Math.Cos(angle);
        var sin = (float)Math.Sin(angle);
        Matrix4 result = Matrix4.Identity;
        result.M11 = cos;
        result.M13 = -sin;
        result.M31 = sin;
        result.M33 = cos;
        return result;
    }

    public static Matrix4 RotationZ(float angle)
    {
        var cos = (float)Math.Cos(angle);
        var sin = (float)Math.Sin(angle);
        Matrix4 result = Matrix4.Identity;
        result.M11 = cos;
        result.M12 = sin;
        result.M21 = -sin;
        result.M22 = cos;
        return result;
    }

    public static Matrix4 Translation(Vector3 value)
    {
        Matrix4 result = Matrix4.Identity;
        result.M41 = value.X;
        result.M42 = value.Y;
        result.M43 = value.Z;
        return result;
    }

    //TODO : CreateRotation from free axis


    #endregion

    #region Normalize
    public static Vector2 Normalize(Vector2 v)
    {
        float length = Math.InverseSqrt(v.LengthSquared);
        return new(v.X * length, v.Y * length);
    }

    public static Vector3 Normalize(Vector3 v)
    {
        float length = Math.InverseSqrt(v.LengthSquared); // 1.0f / v.Length; 
        return new(v.X * length, v.Y * length, v.Z * length);
    }

    public static Vector4 Normalize(Vector4 v)
    {
        float length = Math.InverseSqrt(v.LengthSquared);
        return new(v.X * length, v.Y * length, v.Z * length, v.W * length);
    }

    #endregion

    #region DOT
    /// <summary>
    /// dot product cosinus de l'angle entre les deux vecteurs
    /// The dot product of two vectors is equal to the scalar product of their lengths times the cosine of the angle between them.
    /// si le resultat est 1 ( cos 90°) les deux vecteur sont orthogonaux  si result =0  angle =0 il sont parallel
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization), SuppressGCTransition, SuppressUnmanagedCodeSecurity, SkipLocalsInit]
    public static float Dot(ref Vector2 v1, ref Vector2 v2)
        => (v1.X * v2.X) + (v1.Y * v2.Y);

    /// <summary>
    /// dot product cosinus de l'angle entre les deux vecteurs
    /// The dot product of two vectors is equal to the scalar product of their lengths times the cosine of the angle between them.
    /// si le resultat est 1 ( cos 90°) les deux vecteur sont orthogonaux  si result =0  angle =0 il sont parallel
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Dot(ref Vector3 left, ref Vector3 right)
        => (left.X * right.X) + (left.Y * right.Y) + (left.Z * right.Z);

    /// <summary>
    /// dot product cosinus de l'angle entre les deux vecteurs
    /// The dot product of two vectors is equal to the scalar product of their lengths times the cosine of the angle between them.
    /// si le resultat est 1 ( cos 90°) les deux vecteur sont orthogonaux  si result =0  angle =0 il sont parallel
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Dot(ref Vector4 v1, ref Vector4 v2)
        => (v1.X * v2.X) + (v1.Y * v2.Y) + (v1.Z * v2.Z) + (v1.W * v2.W);

    #endregion

    #region  LENGTH

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization), SuppressGCTransition, SuppressUnmanagedCodeSecurity, SkipLocalsInit]
    public static float Length(ref Vector2 vec2) => Math.Sqrt((vec2.X * vec2.X) + (vec2.Y * vec2.Y));

    /// <summary>
    /// To retrieve the length/magnitude of a vector we use the Pythagoras theorem that you may remember from your math classes. 
    /// A vector forms a triangle when you visualize its individual x and y component as two sides of a triangle:
    /// </summary>
    /// <returns>Magnitude</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization), SuppressGCTransition, SuppressUnmanagedCodeSecurity, SkipLocalsInit]
    public unsafe static float Length(Vector2* vec2) => Math.Sqrt((vec2->X * vec2->X) + (vec2->Y * vec2->Y));

    #endregion

    #region Distance 

    /// <summary>
    /// Distance entre deux vecteur 
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization), SuppressGCTransition, SuppressUnmanagedCodeSecurity, SkipLocalsInit]
    public static float Distance(ref Vector2 value1, ref Vector2 value2)
        => Math.Sqrt(((value1.X - value2.X) * (value1.X - value2.X)) + ((value1.Y - value2.Y) * (value1.Y - value2.Y)));

    /// <summary>
    /// Distance entre deux vecteur 
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Distance(ref Vector3 value1, ref Vector3 value2)
        => Math.Sqrt(((value1.X - value2.X) * (value1.X - value2.X)) + ((value1.Y - value2.Y) * (value1.Y - value2.Y)) + ((value1.Z - value2.Z) * (value1.Z - value2.Z)));

    /// <summary>
    /// Distance entre deux vecteur 
    /// </summary>
    /// <param name="value1"></param>
    /// <param name="value2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Distance(ref Vector4 value1, ref Vector4 value2)
        => Math.Sqrt(((value1.X - value2.X) * (value1.X - value2.X)) + ((value1.Y - value2.Y) * (value1.Y - value2.Y)) + ((value1.Z - value2.Z) * (value1.Z - value2.Z)) + ((value1.W - value2.W) * (value1.W - value2.W)));

    #endregion

    #region CROSS 
    public static Vector3 Cross(ref Vector3 left, ref Vector3 right)
        => new(left.Y * right.Z - left.Z * right.Y,
                left.Z * right.X - left.X * right.Z,
                left.X * right.Y - left.Y * right.X);

    /// <summary>
    /// Produit de 2 vecteur  cross product pour trouver la perpendiculaire a 2 vecteur ( normale)
    /// The cross product is only defined in 3D space and takes two non-parallel vectors as input and produces a third vector that is orthogonal to both the input vectors. If both the input vectors are orthogonal to each other as well, a cross product would result in 3 orthogonal vectors; this will prove useful in the upcoming chapters. The following image shows what this looks like in 3D space:
    /// </summary>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    public static Vector4 Cross(ref Vector4 v1, ref Vector4 v2)
        => new((v1.Y * v2.Z) - (v1.Z * v2.Y),
                (v1.Z * v2.X) - (v1.X * v2.Z),
                (v1.X * v2.Y) - (v1.Y * v2.X),
                (v1.W * v2.Z) - v1.Z);
    /// <summary>
    /// Produit de 2 vecteur  cross product pour trouver la perpendiculaire a 2 vecteur ( normale)
    /// </summary>
    public static void Cross(ref Vector4 result, ref Vector4 v1, ref Vector4 v2)
        => (result.X, result.Y, result.Z, result.W) = (
            (v1.Y * v2.Z) - (v1.Z * v2.Y),
            (v1.Z * v2.X) - (v1.X * v2.Z),
            (v1.X * v2.Y) - (v1.Y * v2.X),
            (v1.W * v2.Z) - v1.Z);


    #endregion

    #region RFLECT REFRACT 

    //code source from :         https://github.com/Philip-Trettner/GlmSharp/blob/master/GlmSharp/GlmSharp/Vec3/vec3.cs
    /// <summary>
    /// Calculate the reflection direction for an incident vector (N should be normalized in order to achieve the desired result).
    /// </summary>
    public static Vector3 Reflect(ref Vector3 I, ref Vector3 N)
        => I - 2 * Dot(ref N, ref I) * N;

    /// <summary>
    /// Calculate the refraction direction for an incident vector (The input parameters I and N should be normalized in order to achieve the desired result).
    /// </summary>
    public static Vector3 Refract(ref Vector3 I, ref Vector3 N, float eta)
    {
        var dNI = Dot(ref N, ref I);
        var k = 1 - eta * eta * (1 - dNI * dNI);
        if (k < 0) return Vector3.Zero;
        return eta * I - (eta * dNI + (float)Math.Sqrt(k)) * N;
    }

    #endregion

    /// <summary>
    /// Returns a vector pointing in the same direction as another (faceforward orients a vector to point away from a surface as defined by its normal. If dot(Nref, I) is negative faceforward returns N, otherwise it returns -N).
    /// </summary>
    public static Vector3 FaceForward(ref Vector3 N, ref Vector3 I, ref Vector3 Nref)
        => Dot(ref Nref, ref I) < 0 ? N : -N;


    #region MATH OPERATION  ADD SUBSTRACT MULTIPLY DIVIDE 

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization), SuppressGCTransition, SuppressUnmanagedCodeSecurity, SkipLocalsInit]
    public static void Multiply(ref Vector2 result, ref Vector2 left, ref Vector2 right)
        => (result.X, result.Y) = (left.X * right.X, left.Y * right.Y);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization), SuppressGCTransition, SuppressUnmanagedCodeSecurity, SkipLocalsInit]
    public static void Multiply(ref Vector2 result, ref Vector2 value, float scalar)
        => (result.X, result.Y) = (value.X * scalar, value.Y * scalar);

    public static void Multiply(ref Vector3 result, ref Vector3 left, ref Vector3 right)
     => (result.X, result.Y, result.Z) = (left.X * right.X, left.Y * right.Y, left.Z * right.Z);

    public static void Multiply(ref Vector3 result, ref Vector3 value, float scalar)
        => (result.X, result.Y, result.Z) = (value.X * scalar, value.Y * scalar, value.Z * scalar);

    public static void Multiply(ref Vector4 result, ref Vector4 value, float scalar)
        => (result.X, result.Y, result.Z, result.W) = (value.X * scalar, value.Y * scalar, value.Z * scalar, value.W * scalar);

    public static void Multiply(ref Vector4 result, ref Vector4 left, ref Vector4 right)
        => (result.X, result.Y, result.Z, result.W) = (left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);

    /// <summary>
    /// Scales a matrix by the given value.
    /// </summary>
    /// <param name="left">The matrix to scale.</param>
    /// <param name="right">The amount by which to scale.</param>
    /// <param name="result">When the method completes, contains the scaled matrix.</param>
    public static void Multiply(ref Matrix4 left, float right, out Matrix4 result)
    {
        result.M11 = left.M11 * right;
        result.M12 = left.M12 * right;
        result.M13 = left.M13 * right;
        result.M14 = left.M14 * right;
        result.M21 = left.M21 * right;
        result.M22 = left.M22 * right;
        result.M23 = left.M23 * right;
        result.M24 = left.M24 * right;
        result.M31 = left.M31 * right;
        result.M32 = left.M32 * right;
        result.M33 = left.M33 * right;
        result.M34 = left.M34 * right;
        result.M41 = left.M41 * right;
        result.M42 = left.M42 * right;
        result.M43 = left.M43 * right;
        result.M44 = left.M44 * right;
    }

    /// <summary>
    /// Scales a matrix by the given value.
    /// </summary>
    /// <param name="left">The matrix to scale.</param>
    /// <param name="right">The amount by which to scale.</param>
    /// <returns>The scaled matrix.</returns>
    public static Matrix4 Multiply(Matrix4 left, float right)
    {
        Multiply(ref left, right, out var result);
        return result;
    }

    /// <summary>
    /// Determines the product of two matrices.
    /// </summary>
    /// <param name="left">The first matrix to multiply.</param>
    /// <param name="right">The second matrix to multiply.</param>
    /// <param name="result">The product of the two matrices.</param>
    public static void Multiply(ref Matrix4 left, ref Matrix4 right, out Matrix4 result)
    {
        result = new Matrix4
        {
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
    }

    /// <summary>
    /// Determines the product of two matrices.
    /// </summary>
    /// <param name="left">The first matrix to multiply.</param>
    /// <param name="right">The second matrix to multiply.</param>
    /// <returns>The product of the two matrices.</returns>
    public static Matrix4 Multiply(Matrix4 left, Matrix4 right)
    {
        Multiply(ref left, ref right, out var result);
        return result;
    }



    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization), SuppressGCTransition, SuppressUnmanagedCodeSecurity, SkipLocalsInit]
    public static void Add(ref Vector2 result, ref Vector2 left, ref Vector2 right)
        => (result.X, result.Y) = (left.X + right.X, left.Y + right.Y);

    public static void Add(ref Vector3 result, ref Vector3 left, ref Vector3 right)
       => (result.X, result.Y, result.Z) = (left.X + right.X, left.Y + right.Y, left.Z + right.Z);

    public static void Add(ref Vector3 result, ref Vector3 left, float scalar)
        => (result.X, result.Y, result.Z) = (left.X + scalar, left.Y + scalar, left.Z + scalar);

    public static void Add(ref Vector4 result, ref Vector4 left, ref Vector4 right)
        => (result.X, result.Y, result.Z, result.W) = (left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);

    public static void Add(ref Matrix4 left, ref Matrix4 right, out Matrix4 result)
    {
        result.M11 = left.M11 + right.M11;
        result.M12 = left.M12 + right.M12;
        result.M13 = left.M13 + right.M13;
        result.M14 = left.M14 + right.M14;
        result.M21 = left.M21 + right.M21;
        result.M22 = left.M22 + right.M22;
        result.M23 = left.M23 + right.M23;
        result.M24 = left.M24 + right.M24;
        result.M31 = left.M31 + right.M31;
        result.M32 = left.M32 + right.M32;
        result.M33 = left.M33 + right.M33;
        result.M34 = left.M34 + right.M34;
        result.M41 = left.M41 + right.M41;
        result.M42 = left.M42 + right.M42;
        result.M43 = left.M43 + right.M43;
        result.M44 = left.M44 + right.M44;
    }

    /// <summary>
    /// Determines the sum of two matrices.
    /// </summary>
    /// <param name="left">The first matrix to add.</param>
    /// <param name="right">The second matrix to add.</param>
    /// <returns>The sum of the two matrices.</returns>
    public static Matrix4 Add(Matrix4 left, Matrix4 right)
    {
        Add(ref left, ref right, out Matrix4 result);
        return result;
    }

    public static void Substract(ref Vector3 result, ref Vector3 left, float scalar)
        => (result.X, result.Y, result.Z) = (left.X - scalar, left.Y - scalar, left.Z - scalar);

    public static void Substract(ref Vector3 result, float scalar, ref Vector3 right)
        => (result.X, result.Y, result.Z) = (scalar - right.X, scalar - right.Y, scalar - right.Z);

    public static void Substract(ref Vector3 result, ref Vector3 left, ref Vector3 right)
        => (result.X, result.Y, result.Z) = (left.X - right.X, left.Y - right.Y, left.Z - right.Z);

    public static void Subtract(ref Matrix4 left, ref Matrix4 right, out Matrix4 result)
    {
        result.M11 = left.M11 - right.M11;
        result.M12 = left.M12 - right.M12;
        result.M13 = left.M13 - right.M13;
        result.M14 = left.M14 - right.M14;
        result.M21 = left.M21 - right.M21;
        result.M22 = left.M22 - right.M22;
        result.M23 = left.M23 - right.M23;
        result.M24 = left.M24 - right.M24;
        result.M31 = left.M31 - right.M31;
        result.M32 = left.M32 - right.M32;
        result.M33 = left.M33 - right.M33;
        result.M34 = left.M34 - right.M34;
        result.M41 = left.M41 - right.M41;
        result.M42 = left.M42 - right.M42;
        result.M43 = left.M43 - right.M43;
        result.M44 = left.M44 - right.M44;
    }

    /// <summary>
    /// Determines the difference between two matrices.
    /// </summary>
    /// <param name="left">The first matrix to subtract.</param>
    /// <param name="right">The second matrix to subtract.</param>
    /// <returns>The difference between the two matrices.</returns>
    public static Matrix4 Subtract(Matrix4 left, Matrix4 right)
    {
        Subtract(ref left, ref right, out var result);
        return result;
    }


    public static void Divide(ref Vector3 result, ref Vector3 left, ref Vector3 right)
       => (result.X, result.Y, result.Z) = (left.X / right.X, left.Y / right.Y, left.Z / right.Z);

    public static void Divide(ref Vector3 result, ref Vector3 left, float scalar)
        => (result.X, result.Y, result.Z) = (left.X / scalar, left.Y / scalar, left.Z / scalar);

    /// <summary>
    /// Scales a matrix by the given value.
    /// </summary>
    /// <param name="left">The matrix to scale.</param>
    /// <param name="right">The amount by which to scale.</param>
    /// <param name="result">When the method completes, contains the scaled matrix.</param>
    public static void Divide(ref Matrix4 left, float right, out Matrix4 result)
    {
        float inv = 1.0f / right;
        result.M11 = left.M11 * inv;
        result.M12 = left.M12 * inv;
        result.M13 = left.M13 * inv;
        result.M14 = left.M14 * inv;
        result.M21 = left.M21 * inv;
        result.M22 = left.M22 * inv;
        result.M23 = left.M23 * inv;
        result.M24 = left.M24 * inv;
        result.M31 = left.M31 * inv;
        result.M32 = left.M32 * inv;
        result.M33 = left.M33 * inv;
        result.M34 = left.M34 * inv;
        result.M41 = left.M41 * inv;
        result.M42 = left.M42 * inv;
        result.M43 = left.M43 * inv;
        result.M44 = left.M44 * inv;
    }

    /// <summary>
    /// Scales a matrix by the given value.
    /// </summary>
    /// <param name="left">The matrix to scale.</param>
    /// <param name="right">The amount by which to scale.</param>
    /// <returns>The scaled matrix.</returns>
    public static Matrix4 Divide(Matrix4 left, float right)
    {
        Divide(ref left, right, out var result);
        return result;
    }

    /// <summary>
    /// Determines the quotient of two matrices.
    /// </summary>
    /// <param name="left">The first matrix to divide.</param>
    /// <param name="right">The second matrix to divide.</param>
    /// <param name="result">When the method completes, contains the quotient of the two matrices.</param>
    public static void Divide(ref Matrix4 left, ref Matrix4 right, out Matrix4 result)
    {
        result.M11 = left.M11 / right.M11;
        result.M12 = left.M12 / right.M12;
        result.M13 = left.M13 / right.M13;
        result.M14 = left.M14 / right.M14;
        result.M21 = left.M21 / right.M21;
        result.M22 = left.M22 / right.M22;
        result.M23 = left.M23 / right.M23;
        result.M24 = left.M24 / right.M24;
        result.M31 = left.M31 / right.M31;
        result.M32 = left.M32 / right.M32;
        result.M33 = left.M33 / right.M33;
        result.M34 = left.M34 / right.M34;
        result.M41 = left.M41 / right.M41;
        result.M42 = left.M42 / right.M42;
        result.M43 = left.M43 / right.M43;
        result.M44 = left.M44 / right.M44;
    }

    /// <summary>
    /// Determines the quotient of two matrices.
    /// </summary>
    /// <param name="left">The first matrix to divide.</param>
    /// <param name="right">The second matrix to divide.</param>
    /// <returns>The quotient of the two matrices.</returns>
    public static Matrix4 Divide(Matrix4 left, Matrix4 right)
    {
        Divide(ref left, ref right, out var result);
        return result;
    }

    #endregion

    #region EXPONENT


    // /// <summary>
    // /// Performs the exponential operation on a matrix.
    // /// </summary>
    // /// <param name="value">The matrix to perform the operation on.</param>
    // /// <param name="exponent">The exponent to raise the matrix to.</param>
    // /// <param name="result">When the method completes, contains the exponential matrix.</param>
    // /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the <paramref name="exponent" /> is negative.</exception>
    // public static void Exponent(ref Matrix4 value, int exponent, out Matrix4 result)
    // {
    //     // Source: http://rosettacode.org
    //     // Reference: http://rosettacode.org/wiki/Matrix4-exponentiation_operator

    //     if (exponent < 0)
    //         throw new ArgumentOutOfRangeException(nameof(exponent), "The exponent can not be negative.");
    //     if (exponent == 0)
    //     {
    //         result = Identity;
    //         return;
    //     }
    //     if (exponent == 1)
    //     {
    //         result = value;
    //         return;
    //     }

    //     Matrix4 identity = Identity;
    //     Matrix4 temp = value;

    //     while (true)
    //     {
    //         if ((exponent & 1) != 0)
    //             identity *= temp;

    //         exponent /= 2;

    //         if (exponent > 0)
    //             temp *= temp;
    //         else
    //             break;
    //     }

    //     result = identity;
    // }

    // /// <summary>
    // /// Performs the exponential operation on a matrix.
    // /// </summary>
    // /// <param name="value">The matrix to perform the operation on.</param>
    // /// <param name="exponent">The exponent to raise the matrix to.</param>
    // /// <returns>The exponential matrix.</returns>
    // /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the <paramref name="exponent" /> is negative.</exception>
    // public static Matrix4 Exponent(Matrix4 value, int exponent)
    // {
    //     Exponent(ref value, exponent, out var result);
    //     return result;
    // }

    #endregion

    #region NEGATE

    // /// <summary>
    // /// Negates a matrix.
    // /// </summary>
    // /// <param name="value">The matrix to be negated.</param>
    // /// <param name="result">When the method completes, contains the negated matrix.</param>
    // public static void Negate(ref Matrix4 value, out Matrix4 result)
    // {
    //     result.M11 = -value.M11;
    //     result.M12 = -value.M12;
    //     result.M13 = -value.M13;
    //     result.M14 = -value.M14;
    //     result.M21 = -value.M21;
    //     result.M22 = -value.M22;
    //     result.M23 = -value.M23;
    //     result.M24 = -value.M24;
    //     result.M31 = -value.M31;
    //     result.M32 = -value.M32;
    //     result.M33 = -value.M33;
    //     result.M34 = -value.M34;
    //     result.M41 = -value.M41;
    //     result.M42 = -value.M42;
    //     result.M43 = -value.M43;
    //     result.M44 = -value.M44;
    // }

    // /// <summary>
    // /// Negates a matrix.
    // /// </summary>
    // /// <param name="value">The matrix to be negated.</param>
    // /// <returns>The negated matrix.</returns>
    // public static Matrix4 Negate(Matrix4 value)
    // {
    //     Negate(ref value, out var result);
    //     return result;
    // }

    #endregion

    #region TRANSPOSE

    /// <summary>
    /// Calculates the transpose of the specified matrix.
    /// </summary>
    /// <param name="value">The matrix whose transpose is to be calculated.</param>
    /// <returns>The transpose of the specified matrix.</returns>
    public static Matrix4 Transpose(Matrix4 value)
    {
        Transpose(ref value, out var result);
        return result;
    }

    /// <summary>
    /// Calculates the transpose of the specified matrix.
    /// </summary>
    /// <param name="value">The matrix whose transpose is to be calculated.</param>
    /// <param name="result">When the method completes, contains the transpose of the specified matrix.</param>
    public static void Transpose(ref Matrix4 value, out Matrix4 result)
    {
        result = new Matrix4
        {
            M11 = value.M11,
            M12 = value.M21,
            M13 = value.M31,
            M14 = value.M41,
            M21 = value.M12,
            M22 = value.M22,
            M23 = value.M32,
            M24 = value.M42,
            M31 = value.M13,
            M32 = value.M23,
            M33 = value.M33,
            M34 = value.M43,
            M41 = value.M14,
            M42 = value.M24,
            M43 = value.M34,
            M44 = value.M44
        };
    }

    /// <summary>
    /// Calculates the transpose of the specified matrix.
    /// </summary>
    /// <param name="value">The matrix whose transpose is to be calculated.</param>
    /// <param name="result">When the method completes, contains the transpose of the specified matrix.</param>
    public static void TransposeByRef(ref Matrix4 value, ref Matrix4 result)
    {
        result.M11 = value.M11;
        result.M12 = value.M21;
        result.M13 = value.M31;
        result.M14 = value.M41;
        result.M21 = value.M12;
        result.M22 = value.M22;
        result.M23 = value.M32;
        result.M24 = value.M42;
        result.M31 = value.M13;
        result.M32 = value.M23;
        result.M33 = value.M33;
        result.M34 = value.M43;
        result.M41 = value.M14;
        result.M42 = value.M24;
        result.M43 = value.M34;
        result.M44 = value.M44;
    }

    #endregion

    #region INVERT

    /// <summary>
    /// Calculates the inverse of the specified matrix.
    /// </summary>
    /// <param name="value">The matrix whose inverse is to be calculated.</param>
    /// <param name="result">When the method completes, contains the inverse of the specified matrix.</param>
    public static void Invert(ref Matrix4 value, out Matrix4 result)
    {
        float b0 = value.M31 * value.M42 - value.M32 * value.M41;
        float b1 = value.M31 * value.M43 - value.M33 * value.M41;
        float b2 = value.M34 * value.M41 - value.M31 * value.M44;
        float b3 = value.M32 * value.M43 - value.M33 * value.M42;
        float b4 = value.M34 * value.M42 - value.M32 * value.M44;
        float b5 = value.M33 * value.M44 - value.M34 * value.M43;

        float d11 = value.M22 * b5 + value.M23 * b4 + value.M24 * b3;
        float d12 = value.M21 * b5 + value.M23 * b2 + value.M24 * b1;
        float d13 = value.M21 * -b4 + value.M22 * b2 + value.M24 * b0;
        float d14 = value.M21 * b3 + value.M22 * -b1 + value.M23 * b0;

        float det = value.M11 * d11 - value.M12 * d12 + value.M13 * d13 - value.M14 * d14;
        // if (Math.Abs(det) < 1e-12f)
        // {
        //     result = Zero;
        //     return;
        // }

        det = 1f / det;

        float a0 = value.M11 * value.M22 - value.M12 * value.M21;
        float a1 = value.M11 * value.M23 - value.M13 * value.M21;
        float a2 = value.M14 * value.M21 - value.M11 * value.M24;
        float a3 = value.M12 * value.M23 - value.M13 * value.M22;
        float a4 = value.M14 * value.M22 - value.M12 * value.M24;
        float a5 = value.M13 * value.M24 - value.M14 * value.M23;

        float d21 = value.M12 * b5 + value.M13 * b4 + value.M14 * b3;
        float d22 = value.M11 * b5 + value.M13 * b2 + value.M14 * b1;
        float d23 = value.M11 * -b4 + value.M12 * b2 + value.M14 * b0;
        float d24 = value.M11 * b3 + value.M12 * -b1 + value.M13 * b0;

        float d31 = value.M42 * a5 + value.M43 * a4 + value.M44 * a3;
        float d32 = value.M41 * a5 + value.M43 * a2 + value.M44 * a1;
        float d33 = value.M41 * -a4 + value.M42 * a2 + value.M44 * a0;
        float d34 = value.M41 * a3 + value.M42 * -a1 + value.M43 * a0;

        float d41 = value.M32 * a5 + value.M33 * a4 + value.M34 * a3;
        float d42 = value.M31 * a5 + value.M33 * a2 + value.M34 * a1;
        float d43 = value.M31 * -a4 + value.M32 * a2 + value.M34 * a0;
        float d44 = value.M31 * a3 + value.M32 * -a1 + value.M33 * a0;

        result.M11 = +d11 * det;
        result.M12 = -d21 * det;
        result.M13 = +d31 * det;
        result.M14 = -d41 * det;
        result.M21 = -d12 * det;
        result.M22 = +d22 * det;
        result.M23 = -d32 * det;
        result.M24 = +d42 * det;
        result.M31 = +d13 * det;
        result.M32 = -d23 * det;
        result.M33 = +d33 * det;
        result.M34 = -d43 * det;
        result.M41 = -d14 * det;
        result.M42 = +d24 * det;
        result.M43 = -d34 * det;
        result.M44 = +d44 * det;
    }

    /// <summary>
    /// Calculates the inverse of the specified matrix.
    /// </summary>
    /// <param name="value">The matrix whose inverse is to be calculated.</param>
    /// <returns>The inverse of the specified matrix.</returns>
    public static Matrix4 Invert(Matrix4 value)
    {
        Invert(ref value, out Matrix4 result);
        return result;
    }

    #endregion

    #region PROJECT / UNPROJECT 

    //TODO : transform 2D screen points in 3D world 

    // TODO : pick point in 3d  convert into 2d Screen


    //Source : https://github.com/isadorasophia/murder/blob/main/src/Murder/Core/Graphics/Camera2D.cs

    // public Vector2 ScreenToWorldPosition(Vector2 screenPosition)
    // {
    //     return Microsoft.Xna.Framework.Vector2.Transform(
    //         screenPosition.ToXnaVector2(),
    //         Matrix.Invert(WorldViewProjection)).ToSysVector2();
    // }
    /// <summary>
    /// Creates a new <see cref="Vector2"/> that contains a transformation of the specified normal by the specified <see cref="Matrix"/>.
    /// </summary>
    /// <param name="normal">Source <see cref="Vector2"/> which represents a normal vector.</param>
    /// <param name="matrix">The transformation <see cref="Matrix"/>.</param>
    /// <param name="result">Transformed normal as an output parameter.</param>
    // public static void TransformNormal(
    // 		ref Vector2 normal,
    // 		ref Matrix matrix,
    // 		out Vector2 result
    // 	) {
    // 		float x = (normal.X * matrix.M11) + (normal.Y * matrix.M21);
    // 		float y = (normal.X * matrix.M12) + (normal.Y * matrix.M22);
    // 		result.X = x;
    // 		result.Y = y;
    // 	}

    // public Vector2 WorldToScreenPosition(Vector2 screenPosition)
    // {
    //     return Microsoft.Xna.Framework.Vector2.Transform(
    //         screenPosition.ToXnaVector2(),
    //         WorldViewProjection).ToSysVector2();
    // }

    // // source : https://github.com/FNA-XNA/FNA/blob/master/src/Graphics/Viewport.cs

    //     /// <summary>
    //     /// Projects a <see cref="Vector3"/> from world space into screen space.
    //     /// </summary>
    //     /// <param name="source">The <see cref="Vector3"/> to project.</param>
    //     /// <param name="projection">The projection <see cref="Matrix"/>.</param>
    //     /// <param name="view">The view <see cref="Matrix"/>.</param>
    //     /// <param name="world">The world <see cref="Matrix"/>.</param>
    //     /// <returns></returns>
    //     public Vector3 Project(
    //         Vector3 source,
    //         Matrix projection,
    //         Matrix view,
    //         Matrix world
    //     )
    //     {
    //         Matrix matrix = Matrix.Multiply(
    //             Matrix.Multiply(world, view),
    //             projection
    //         );
    //         Vector3 vector = Vector3.Transform(source, matrix);

    //         float a = (((source.X * matrix.M14) + (source.Y * matrix.M24)) + (source.Z * matrix.M34)) + matrix.M44;
    //         if (!MathHelper.WithinEpsilon(a, 1.0f))
    //         {
    //             vector.X = vector.X / a;
    //             vector.Y = vector.Y / a;
    //             vector.Z = vector.Z / a;
    //         }

    //         vector.X = (((vector.X + 1f) * 0.5f) * Width) + X;
    //         vector.Y = (((-vector.Y + 1f) * 0.5f) * Height) + Y;
    //         vector.Z = (vector.Z * (MaxDepth - MinDepth)) + MinDepth;
    //         return vector;
    //     }

    // 		/// <summary>
    // 		/// Unprojects a <see cref="Vector3"/> from screen space into world space.
    // 		/// </summary>
    // 		/// <param name="source">The <see cref="Vector3"/> to unproject.</param>
    // 		/// <param name="projection">The projection <see cref="Matrix"/>.</param>
    // 		/// <param name="view">The view <see cref="Matrix"/>.</param>
    // 		/// <param name="world">The world <see cref="Matrix"/>.</param>
    // 		/// <returns></returns>
    // 		public Vector3 Unproject(Vector3 source, Matrix projection, Matrix view, Matrix world)
    // 		{
    // 			Matrix matrix = Matrix.Invert(
    // 				Matrix.Multiply(
    // 					Matrix.Multiply(world, view),
    // 					projection
    // 				)
    // 			);
    // 			source.X = (((source.X - X) / ((float) Width)) * 2f) - 1f;
    // 			source.Y = -((((source.Y - Y) / ((float) Height)) * 2f) - 1f);
    // 			source.Z = (source.Z - MinDepth) / (MaxDepth - MinDepth);
    // 			Vector3 vector = Vector3.Transform(source, matrix);

    // 			float a = (
    // 				((source.X * matrix.M14) + (source.Y * matrix.M24)) +
    // 				(source.Z * matrix.M34)
    // 			) + matrix.M44;
    // 			if (!MathHelper.WithinEpsilon(a, 1.0f))
    // 			{
    // 				vector.X = vector.X / a;
    // 				vector.Y = vector.Y / a;
    // 				vector.Z = vector.Z / a;
    // 			}

    // 			return vector;
    // 		}

      // /// <summary>Map the specified object coordinates (obj.x, obj.y, obj.z) into window coordinates.
    // /// The near and far clip planes correspond to z normalized device coordinates of -1 and +1 respectively. (OpenGL clip volume definition)
    // /// @param obj Specify the object coordinates.
    // /// @param model Specifies the current modelview matrix
    // /// @param proj Specifies the current projection matrix
    // /// @param viewport Specifies the current viewport
    // /// @return Return the computed window coordinates.
    // /// @tparam T Native type used for the computation. Currently supported: half (not recommended), float or double.
    // /// @tparam U Currently supported: Floating-point types and integer types.
    // /// @see <a href="https://www.khronos.org/registry/OpenGL-Refpages/gl2.1/xhtml/gluProject.xml">gluProject man page</a>
    // /// </summary>
    // public static Vector4 ProjectNO(Vector4 objPosition,Matrix4 modelview,Matrix4 projection ,Vector4 viewport)
    // {
    //     Vector4 tmp = new(objPosition.X, objPosition.Y, objPosition.Z,1.0f);
    //     tmp = modelview * tmp;//tmp = MultiplyMat4ByVec4( modelview ,tmp); //
    //     tmp = projection * tmp;

    //     tmp /= tmp.W;
    //     tmp = (tmp * 0.5f) + 0.5f;
    //     tmp.Y = (tmp.Y * 0.5f) + 0.5f;
    //     tmp.X = (tmp.X * 0.5f) + 0.5f;
    //     tmp[0] = (tmp[0] *  viewport[2]) + viewport[0];
    //     tmp[1] = (tmp[1] *  viewport[3]) + viewport[1];
    //     return tmp;
    // }

    // /// <summary> Map the specified window coordinates (win.x, win.y, win.z) into object coordinates.
    // /// The near and far clip planes correspond to z normalized device coordinates of -1 and +1 respectively. (OpenGL clip volume definition)
    // /// @param win Specify the window coordinates to be mapped.
    // /// @param model Specifies the modelview matrix
    // /// @param proj Specifies the projection matrix
    // /// @param viewport Specifies the viewport
    // /// @return Returns the computed object coordinates.
    // /// @see <a href="https://www.khronos.org/registry/OpenGL-Refpages/gl2.1/xhtml/gluUnProject.xml">gluUnProject man page</a>
    // /// </summary>
    // public static Vector4 UnProjectNO(ref Vector4 window,ref Camera camera,ref Vector4 viewport)
    // {
    //     Matrix4 vp =  camera.Clip ;//view * projection  ;
    //     Matrix4.Invert(ref vp, out Matrix4 inverse);

    //     Vector4 tmp = new(window.X,window.Y,window.Z, 1.0f);

    //     tmp.X = (tmp.X - viewport[0]) / viewport[2];
    //     tmp.Y = (tmp.Y - viewport[1]) / viewport[3];
    //     tmp.Z = (tmp.Z - 0.1f) / (0.1f - 1000f);
    //     tmp = (tmp*2.0f) - 1.0f ;

    //     Vector4 obj =tmp * inverse ;//  inverse * tmp;
    //     obj /= obj.W;
    //     return obj;
    // }
    #endregion

   

}