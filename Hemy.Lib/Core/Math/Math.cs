namespace Hemy.Lib.Core.Math;

using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#if WINDOWS
using static Hemy.Lib.Core.Platform.Windows.Math.MathFuncs ;
#endif

public static class Math
{
    public const double E = 2.7182818284590452354;
    public const double PI = 3.14159265358979323846264338327950288;
    public const double _2PI = 6.283185307179586476925286766559;
    public const double PIOver2 = 1.5707963267948966192313216916398;
    public const float PIf = 3.14159265358979323846264338327950288f;
    public const float _2PIf = 6.283185307179586476925286766559f;
    public const float PIOver2f = 1.5707963267948966192313216916398f;
    public const double Tau = 6.283185307179586476925;

    const double RADIAN_TO_DEGREE_DOUBLE = 57.295779513082320876798154814105;
    const float RADIAN_TO_DEGREE_FLOAT = 57.295779513082320876798154814105f;
    const double DEGREE_TO_RADIAN_DOUBLE = 0.01745329251994329576923690768489;
    const float DEGREE_TO_RADIAN_FLOAT = 0.01745329251994329576923690768489f;


    [SkipLocalsInit]
    public static float NearZeroEpsilon2 => 4.7683716E-07f;

    /// <summary> Retourne l' Arc cosinus de l'angle spécifié en radian </summary>
    /// <param name="x"> angle in rafian format double</param>
    /// <returns>The cosine of d. If d is equal to double.NaN, double.NegativeInfinity, or double.PositiveInfinity, this method returns double.NaN</returns>
    public static double ACos(double x)
#if WINDOWS
    => acos(x);
#endif

    /// <summary> Retourne l' Arc cosinus de l'angle spécifié en radian </summary>
    /// <param name="x"> angle in rafian format float</param>
    /// <returns>The cosine of d. If d is equal to float.NaN, float.NegativeInfinity, or float.PositiveInfinity, this method returns float.NaN</returns>
    public static float ACos(float x)
#if WINDOWS
    => acosf(x);
#endif

    /// <summary> Retourne le cosinus de l'angle spécifié en radian </summary>
    /// <param name="x"> angle in rafian format double</param>
    /// <returns>The cosine of d. If d is equal to double.NaN, double.NegativeInfinity, or double.PositiveInfinity, this method returns double.NaN</returns>
    public static double Cos(double x)
#if WINDOWS
    => cos(x);
#endif

    /// <summary> Retourne le cosinus de l'angle spécifié en radian </summary>
    /// <param name="x"> angle in rafian format float</param>
    /// <returns>The cosine of d. If d is equal to float.NaN, float.NegativeInfinity, or float.PositiveInfinity, this method returns float.NaN</returns>
    public static float Cos(float x)
#if WINDOWS
    => cosf(x);
#endif

    /// <summary> Retourne le sinus de l'angle spécifié en radian </summary>
    /// <param name="x"> angle in rafian format double</param>
    /// <returns>The cosine of d. If d is equal to double.NaN, double.NegativeInfinity, or double.PositiveInfinity, this method returns double.NaN</returns>
    public static double Sin(double x)
#if WINDOWS
    => sin(x);
#endif

    /// <summary> Retourne le sinus de l'angle spécifié en radian </summary>
    /// <param name="x"> angle in rafian format float</param>
    /// <returns>The cosine of d. If d is equal to float.NaN, float.NegativeInfinity, or float.PositiveInfinity, this method returns float.NaN</returns>
    public static float Sin(float x)
#if WINDOWS
    => sinf(x);
#endif

    /// <summary> Retourne la tangente de l'angle spécifié en radian </summary>
    /// <param name="x"> angle in rafian format double</param>
    /// <returns>The cosine of d. If d is equal to double.NaN, double.NegativeInfinity, or double.PositiveInfinity, this method returns double.NaN</returns>
    public static double Tan(double x)
#if WINDOWS
    => tan(x);
#endif

    /// <summary> Retourne la tangente  de l'angle spécifié en radian </summary>
    /// <param name="x"> angle in rafian format float</param>
    /// <returns>The cosine of d. If d is equal to float.NaN, float.NegativeInfinity, or float.PositiveInfinity, this method returns float.NaN</returns>
    public static float Tan(float x)
#if WINDOWS
    => tanf(x);
#endif

    /// <summary> Retourne la tangente de l'angle spécifié en radian </summary>
    /// <param name="x"> angle in rafian format double</param>
    /// <param name="y"> angle in rafian format double</param>
    /// <returns>The cosine of d. If d is equal to double.NaN, double.NegativeInfinity, or double.PositiveInfinity, this method returns double.NaN</returns>
    public static double ATan2(double x,double y)
#if WINDOWS
    => atan2(x,y);
#endif

    /// <summary> Retourne la tangente  de l'angle spécifié en radian </summary>
    /// <param name="x"> angle in rafian format float</param>
    /// <param name="y"> angle in rafian format double</param>
    /// <returns>The cosine of d. If d is equal to float.NaN, float.NegativeInfinity, or float.PositiveInfinity, this method returns float.NaN</returns>
    public static float ATan2(float x, float y)
#if WINDOWS
    => atan2f(x,y);
#endif
    /// <summary> Convert radians to degrees  use : angleIndegree =  Math.IntoDegree( angleInRadian ) ;</summary>
    /// <param name="radians">An angle in radians format float</param>
    /// <returns>The angle expressed in degrees</returns>
    public static float IntoDegree(float radians) => radians * RADIAN_TO_DEGREE_FLOAT;
    /// <summary> Convert radians to degrees  use : angleIndegree =  Math.IntoDegree( angleInRadian ) ;</summary>
    /// <param name="radians">An angle in radians format double</param>
    /// <returns>The angle expressed in degrees</returns>
    public static double IntoDegree(double radians) => radians * RADIAN_TO_DEGREE_DOUBLE;
    /// <summary> Convert radians to degrees  use : angleIndegree =   angleInRadian.ToDegree() ;</summary>
    /// <param name="radians">An angle in radians format double</param>
    /// <returns>The angle expressed in degrees</returns>
    public static double ToDegree(this double radians) => radians * RADIAN_TO_DEGREE_DOUBLE;
   
    /// <summary> Convert radians to degrees  use : angleIndegree =   angleInRadian.ToDegree() ;</summary>
    /// <param name="radians">An angle in radians format float</param>
    /// <returns>The angle expressed in degrees</returns>
    public static float ToDegree(this float radians) => radians * RADIAN_TO_DEGREE_FLOAT;
    /// <summary> Convert degrees to radians  use :  angleInRadian = Math.IntoRadian( angleInDegree ) ;</summary>
    /// <param name="degrees">An angle in degrees in double</param>
    /// <returns>The angle expressed in radians</returns>
    public static double IntoRadian(double degrees) => degrees * DEGREE_TO_RADIAN_DOUBLE;
    /// <summary> Convert degrees to radians use like this :  angleInRadian =  angleInDegree.ToRadian() ; </summary>
    /// <param name="degrees">An angle in degrees in double</param>
    /// <returns>The angle expressed in radians</returns>
    public static double ToRadian(this double degrees) => degrees * DEGREE_TO_RADIAN_DOUBLE;
    /// <summary> Convert degrees to radians  use :  angleInRadian = Math.IntoRadian( angleInDegree ) ;</summary>
    /// <param name="degrees">An angle in degrees in double</param>
    /// <returns>The angle expressed in radians</returns>
    public static float IntoRadian(float degrees) => degrees * DEGREE_TO_RADIAN_FLOAT;
    /// <summary> Convert degrees to radians use like this :  angleInRadian =  angleInDegree.ToRadian() ; </summary>
    /// <param name="degrees">An angle in degrees in float</param>
    /// <returns>The angle expressed in radians</returns>
    public static float ToRadian(this float degrees) => degrees * DEGREE_TO_RADIAN_FLOAT;
    
    /// <summary>
    /// Calcul  la valeur de x élever a la puissance de y  ( float result = valueX.PowerOf( valueY );)
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static float PowerOf(this float x, float y)
#if WINDOWS    
     => powf(x, y);
#endif

    public static double PowerOf(this double x, double y)
#if WINDOWS    
     => pow(x, y);
#endif

    /// <summary>
    /// Returns the natural (base e) logarithm of a specified number.
    /// Retourne :One of the values in the following table.
    /// d parameter – Return value
    /// Positive – The natural logarithm of d; that is, ln d, or log e d
    /// Zero –double.NegativeInfinity
    /// Negative –double.NaN
    /// Equal to double.NaN –double.NaN
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    [Pure]
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public static double Log(double x) => clog(x);

    /// <summary>
    /// Returns the natural (base e) logarithm of a specified number.
    /// Retourne :One of the values in the following table.
    /// d parameter – Return value
    /// Positive – The natural logarithm of d; that is, ln d, or log e d
    /// Zero –double.NegativeInfinity
    /// Negative –double.NaN
    /// Equal to double.NaN –double.NaN
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    [Pure]
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    public static float Log(float x) => clogf(x);


    /// <summary>
    ///  Approximation de 1 sur racine carré de, Utilisé dans quake 
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public static unsafe float InverseSqrt(float x)
    {
        float xhalf = 0.5f * x;
        int i = *(int*)&x; // Read bits as integer.
        i = 0x5f375a86 - (i >> 1); // Make an initial guess for Newton-Raphson approximation
        x = *(float*)&i; // Convert bits back to float
        x *= 1.5f - (xhalf * x * x); // Perform left single Newton-Raphson step.
        x *= 1.5f - (xhalf * x * x); // repeat for better precision
        x *= 1.5f - (xhalf * x * x); // repeat for better precision
        return x;
        // code take in : https://github.com/opentk/opentk/blob/master/src/OpenTK.Mathematics/MathHelper.cs
    }

    /// <summary>  Retourne la racine carré du nombre spécifié  </summary>
    /// <param name="scalar"></param>
    /// <returns></returns>
    public static float Sqrt(float scalar)
#if WINDOWS
    => sqrtf(scalar);
#endif
    /// <summary>  Retourne la racine carré du nombre spécifié  </summary>
    /// <param name="scalar"></param>
    /// <returns></returns>
    public static double Sqrt(double scalar)
#if WINDOWS
    => sqrt(scalar);
#endif

    #region ARRONDIE
    /// <summary>
    /// Rounds a floating-point value to the nearest integer value.
    /// </summary>
    /// <param name="n">A single-precision floating-point number</param>
    /// <returns>Returns the largest integral value less than or equal to the specified decimal number.</returns>
    [Pure]
    public static float Round(float n)
#if WINDOWS
    => roundf(n);
#endif
    /// <summary>
    /// Rounds a floating-point value to the nearest integer value.
    /// </summary>
    /// <param name="n">A double-precision floating-point number.</param>
    /// <returns>Returns the largest integral value less than or equal to the specified double-precision floating-point number.</returns>
    [Pure]
    public static double Round(double n)
#if WINDOWS
    => round(n);
#endif
    /// <summary>
    /// Returns the largest integral value less than or equal to the specified number.
    /// </summary>
    /// <param name="n">A single-precision floating-point number</param>
    /// <returns>Returns the largest integral value less than or equal to the specified decimal number.</returns>
    [Pure]
    public static float Floor(float n)
#if WINDOWS
    => floorf(n);
#endif
    /// <summary>
    /// Returns the largest integral value less than or equal to the specified number.
    /// </summary>
    /// <param name="n">A double-precision floating-point number.</param>
    /// <returns>Returns the largest integral value less than or equal to the specified double-precision floating-point number.</returns>
    [Pure]
    public static double Floor(double n)
#if WINDOWS
    => floor(n);
#endif
    /// <summary>
    /// Returns the smallest integral value greater than or equal to the specified number.
    /// </summary>
    /// <param name="n">A decimal number.</param>
    /// <returns>The smallest integral value that is greater than or equal to n. Note that this method returns a Decimal instead of an integral type.</returns>
    [Pure]
    public static float Ceiling(float n)
#if WINDOWS
    => ceilf(n);
#endif
    /// <summary>
    /// Returns the smallest integral value greater than or equal to the specified number.
    /// </summary>
    /// <param name="n">A double-precision floating-point number.</param>
    /// <returns>The smallest integral value that is greater than or equal to n. If n is equal to NaN, NegativeInfinity, or PositiveInfinity, that value is returned.
    /// Note that this method returns a Double instead of an integral type.</returns>
    [Pure]
    public static double Ceiling(double n)
#if WINDOWS
    => ceil(n);
#endif

    private const long  L_OFFSET_MAX = int.MaxValue + 1L;
    /// <summary>
    ///     Returns the smallest integer greater than or equal to the specified floating-point number.
    /// </summary>
    /// <param name="f"> A floating-point number with single precision. </param>
    /// <returns>
    ///     The smallest integer, which is greater than or equal to f.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Ceiling2(double f)
    => (int)(L_OFFSET_MAX - (long)(L_OFFSET_MAX - f));

    /// <summary>
    ///     Returns the largest integer less than or equal to the specified floating-point number.
    /// </summary>
    /// <param name="f"> A floating-point number with single precision. </param>
    /// <returns>
    ///     The largest integer, which is less than or equal to f.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Floor2(double f)
    {
        return (int)((long)(f + L_OFFSET_MAX) - L_OFFSET_MAX);
    }

    #endregion

    #region  ABSOLUE
    /// <summary>  Retourne la valeur absolue d'un float   </summary>
    /// <param name="scalar">float valeur comprise entre 0 et float.MaxValue </param>
    /// <returns></returns>
    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    [Pure]
    public static float Abs(float scalar)
#if WINDOWS
    => fabsf(scalar);
#endif
    /// <summary>  Retourne la valeur absolue d'un float   </summary>
    /// <param name="scalar">float valeur comprise entre 0 et float.MaxValue </param>
    /// <returns></returns>
    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    [Pure]
    public static double Abs(double scalar)
#if WINDOWS    
    => fabs(scalar);
#endif

    /// <summary>
    ///     calculates the absolute value of x.
    /// </summary>
    /// <param name="x"> value. </param>
    /// <returns>
    ///     positive x.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Abs(int x) => (x + (x >> 31)) ^ (x >> 31);

    #endregion

    #region LIMIT => MIN MAX
    private const int CH_BIT = 8;

    /// <summary>
    /// Donne la valeur Min entre deux entiers
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    [Pure] 
    public static int Min(int x, int y)
        =>  y + ((x - y) & ((x - y) >> ((sizeof(int) * CH_BIT) - 1))); // min(x, y)

    /// <summary>
    /// Donne la valeur max entre deux entiers
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    [Pure] 
    public static int Max(int x , int y )
        =>x - ((x - y) & ((x - y) >> ((sizeof(int) * CH_BIT) - 1))); // max(x, y)

    // TODO MIN MAX for byte sbyte short long uint ulong ushort 


    /// <summary>  Retourne la valeur min d'un float  entre les deux valeurs spécifiées </summary>

    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    [Pure]
    public static float Min(float x,float y)
#if WINDOWS
    => fminf(x,y);
#endif
    /// <summary>   Retourne la valeur min d'un float  entre les deux valeurs spécifiées    </summary>
    
    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    [Pure]
    public static double Min(double x,double y)
#if WINDOWS    
    => fmin(x,y);
#endif

        /// <summary>  Retourne la valeur min d'un float  entre les deux valeurs spécifiées </summary>
  
    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    [Pure]
    public static float Max(float x,float y)
#if WINDOWS
    => fmaxf(x,y);
#endif
    /// <summary>   Retourne la valeur min d'un float  entre les deux valeurs spécifiées    </summary>
    
    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    [Pure]
    public static double Max(double x,double y)
#if WINDOWS    
    => fmax(x,y);
#endif

#endregion

#region CLAMP

    /// <summary>
    /// Clamp (borne ) angle en radian entre 0 et 2PI
    /// </summary>
    /// <param name="radian">angle en radian</param>
    /// <returns>angle borné entre 0 et 2PI</returns>
    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    [Pure]
    public static float ClampRadian(float radian) => Abs(radian %= _2PIf);

    /// <summary>
    /// Clamp (borne ) angle en radian entre 0 et 2PI
    /// </summary>
    /// <param name="radian">angle en radian</param>
    /// <returns>angle borné entre 0 et 2PI</returns>
    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    [Pure]
    public static double ClampRadian(double radian) => Abs(radian %= _2PI);

    /// <summary>
    /// Clamp (borne ) angle en degré entre 0 et 360
    /// </summary>
    /// <param name="degre">angle en degre</param>
    /// <returns>angle borné entre 0 et 360</returns>
    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    [Pure]
    public static float ClampDegree(float degre) => Abs(degre %= 360.000f);

    /// <summary>
    /// Clamp (borne ) angle en degré entre 0 et 360
    /// </summary>
    /// <param name="degre">angle en degre</param>
    /// <returns>angle borné entre 0 et 360</returns>
    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    [Pure]
    public static double ClampDegree(double degre) => Abs(degre %= 360.000);

 	/// <summary>
    /// Borne une valeur coprise entre min et max 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    [SuppressUnmanagedCodeSecurity]
    [SuppressGCTransition]
    [SkipLocalsInit]
    [Pure] 
    public static float Clamp(float value, float min , float max)
        => value < min ? min : value > max ? max : value;

    /// <summary>
    /// Borne une valeur coprise entre min et max 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    [SuppressUnmanagedCodeSecurity]
    [SuppressGCTransition]
    [SkipLocalsInit]
    [Pure] 
    public static double Clamp(double value, double min , double max)
        => value < min ? min : value > max ? max : value;

    //     /// <summary>
    //     /// Borne une valeur coprise entre min et max 
    //     /// </summary>
    //     /// <param name="value"></param>
    //     /// <param name="min"></param>
    //     /// <param name="max"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static short Clamp(short value, short min, short max)
    //         => value < min ? min : value > max ? max : value;

    //     /// <summary>
    //     /// Borne une valeur coprise entre min et max 
    //     /// </summary>
    //     /// <param name="value"></param>
    //     /// <param name="min"></param>
    //     /// <param name="max"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static int Clamp(int value, int min, int max)
    //         => value < min ? min : value > max ? max : value;

    //     /// <summary>
    //     /// Borne une valeur coprise entre min et max 
    //     /// </summary>
    //     /// <param name="value"></param>
    //     /// <param name="min"></param>
    //     /// <param name="max"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static uint Clamp(uint value, uint min, uint max) 
    //         => value < min ? min : value > max ? max : value;

    //     /// <summary>
    //     /// borne une valeur entre min et max en utilisant une reférence
    //     /// </summary>
    //     /// <param name="value"></param>
    //     /// <param name="min"></param>
    //     /// <param name="max"></param>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static void Clamp(ref float value, float min, float max)
    //         => value =	value < min ? min : value > max ? max : value;

    //     /// <summary>
    //     /// borne une valeur entre min et max en utilisant une reférence
    //     /// </summary>
    //     /// <param name="value"></param>
    //     /// <param name="min"></param>
    //     /// <param name="max"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static void Clamp(ref double value, double min , double max)
    //         => value =  value < min ? min : value > max ? max : value;

    //     /// <summary>
    //     /// borne une valeur entre min et max en utilisant une reférence
    //     /// </summary>
    //     /// <param name="value"></param>
    //     /// <param name="min"></param>
    //     /// <param name="max"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static void Clamp(ref short value, short min, short max)
    //         => value = value < min ? min : value > max ? max : value;

    //     /// <summary>
    //     /// borne une valeur entre min et max en utilisant une reférence
    //     /// </summary>
    //     /// <param name="value"></param>
    //     /// <param name="min"></param>
    //     /// <param name="max"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static void Clamp(ref int value, int min, int max)
    //         => value =  value < min ? min : value > max ? max : value;

    //     /// <summary>
    //     /// borne une valeur entre min et max en utilisant une reférence
    //     /// </summary>
    //     /// <param name="value"></param>
    //     /// <param name="min"></param>
    //     /// <param name="max"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static void Clamp(ref uint value, uint min, uint max) 
    //         => value = value < min ? min : value > max ? max : value;


    #endregion

    /// <summary>
    /// Borne entre -180° et 180°
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    [Pure]
    public static float NormalizeDegre(float angle) => angle - Ceiling(angle / 360.0f - 0.5f) * 360.0f;

    /// <summary>
    /// Borne entre -180° et 180°
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    [Pure]
    public static double NormalizeDegre(double angle) => angle - Ceiling(angle / 360.0 - 0.5) * 360.0;
    /// <summary>
    /// borne entre -PI et PI
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    [Pure]
    public static float NormalizeRadian(float angle)
    {
        angle = ClampRadian(angle);  // shift angle to range (-π, π]
        return (angle > PIOver2f) ? angle - _2PIf : angle;
    }

    /// <summary>
    /// borne entre -PI et PI
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    // [SuppressUnmanagedCodeSecurity]
    // [SuppressGCTransition]
    // [SkipLocalsInit]
    [Pure]
    public static double NormalizeRadian(double angle)
    {
        angle = ClampRadian(angle);  // shift angle to range (-π, π]
        return (angle > PIOver2) ? angle - _2PI : angle;
    }
   

    // #region INTERPOLATION  =>  LERP, SMOOTH

    //     /// <summary>
    //     /// Linear interpolation
    //     /// </summary>
    //     /// <param name="from"></param>
    //     /// <param name="to"></param>
    //     /// <param name="amount"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float Lerp(float from, float to, float amount) => ((1 - amount) * from) + (amount * to);

    //     /// <summary>
    //     /// Performs smooth (cubic Hermite) interpolation between 0 and 1.
    //     /// </summary>
    //     /// <param name="amount"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float SmoothStep(float amount)
    //         => (amount <= 0) ? 0
    //             : (amount >= 1) ? 1
    //             : amount * amount * (3 - (2 * amount));

    //     /// <summary>
    //     /// Performs a smooth(er) interpolation between 0 and 1 with 1st and 2nd order derivatives of zero at endpoints.
    //     /// </summary>
    //     /// <param name="amount"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float SmootherStep(float amount) => (amount <= 0) ? 0
    //             : (amount >= 1) ? 1
    //             : amount * amount * amount * ((amount * ((amount * 6) - 15)) + 10);

    //     /// <summary>
    //     /// Linear interpolation
    //     /// </summary>
    //     /// <param name="from"></param>
    //     /// <param name="to"></param>
    //     /// <param name="amount"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double Lerp(double from, double to, double amount) => ((1 - amount) * from) + (amount * to);

    //     /// <summary>
    //     /// Performs smooth (cubic Hermite) interpolation between 0 and 1.
    //     /// </summary>
    //     /// <param name="amount"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double SmoothStep(double amount)
    //         => (amount <= 0) ? 0
    //             : (amount >= 1) ? 1
    //             : amount * amount * (3 - (2 * amount));

    //     /// <summary>
    //     /// Performs a smooth(er) interpolation between 0 and 1 with 1st and 2nd order derivatives of zero at endpoints.
    //     /// </summary>
    //     /// <param name="amount"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double SmootherStep(double amount) => (amount <= 0) ? 0
    //             : (amount >= 1) ? 1
    //             : amount * amount * amount * ((amount * ((amount * 6) - 15)) + 10);


    // #endregion

}