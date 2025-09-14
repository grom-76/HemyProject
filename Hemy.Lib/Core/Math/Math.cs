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
    public static float NearZeroEpsilon {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => 4.7683716E-07f;
    }

    [SkipLocalsInit]
    public static float NearZeroEpsilon2 => 4.7683716E-07f;


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
    /// <param name="radians">An angle in radians format double</param>
    /// <returns>The angle expressed in degrees</returns>
    public static double InToDegree(double radians) => radians * RADIAN_TO_DEGREE_DOUBLE;
    /// <summary> Convert radians to degrees  use : angleIndegree =   angleInRadian.ToDegree() ;</summary>
    /// <param name="radians">An angle in radians format double</param>
    /// <returns>The angle expressed in degrees</returns>
    public static double ToDegree(this double radians) => radians * RADIAN_TO_DEGREE_DOUBLE;
    /// <summary> Convert radians to degrees  use : angleIndegree =  Math.IntoDegree( angleInRadian ) ;</summary>
    /// <param name="radians">An angle in radians format float</param>
    /// <returns>The angle expressed in degrees</returns>
    public static float IntoDegree(float radians) => radians * RADIAN_TO_DEGREE_FLOAT;
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
    {
        return (int)(L_OFFSET_MAX - (long)(L_OFFSET_MAX - f));
    }

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

    // #endregion



    // MATH
    //     ALGODATASTRUCTURE
    //         quadtree
    //         octree
    //         bdp
    //         portal
    //         graph
    //     ALGO
    //         LOD
    //         MeshOptim

    // IA
    // PHYSICS

    // Geometric Folder must contain

    // Angles
    // Shapes
    //     Curves, Polygon, 3D shapes
    // Triangles
    // Quadrilaterals
    // Plane
    //     quadrants, reflecting
    // Area
    // Volume, surface
    // Transformation
    //     Translation, rotation, reflections  refraction symetry , resizing  congruent / Similar   Symetrie  geometrie ...
    // Trigonometry
    //     Sin , cos, ...exp log , 
    // //  MATH https://github.com/aldriangintingsuka/GlmSharp
    // // https://github.com/FlaxEngine/FlaxEngine/tree/master/Source/Engine/Core/Math
    // //https://github.com/Syncaidius/MoltenEngine/blob/master/Molten.Math/MathHelper.cs for GAUSS 
    // /// All functions or constantes need for math algebra
    // /// https://github.com/MachineCognitis/C.math.NET/blob/master/C.math/math.cs
    ///  https://github.com/opentk/opentk/blob/master/src/OpenTK.Mathematics/MathHelper.cs
    /// https://github.com/MachineCognitis/C.math.NET


    // #region FOR STBIMAGE
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure]
    //     public static double Ldexp(double number, int exponent) =>    number * Pow(2, exponent);

    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure]
    //     public static uint Lrotl(uint x, int y) => (x << y) | (x >> (32 - y));

    // #endregion    

    // #region CONSTANTES

    //     private const int CH_BIT = 8;

    //     /// <summary>Repréente une valeur proche de zéro </summary>
    //     public const float FLT_ZERO_TOLERANCE = 1E-06f;

    //     /// <summary>Représente une valeur proche de zéro , la plus petite valeur possible d'un float </summary>
    //     public const float FLT_EPSILON = float.Epsilon;
    //     /// <summary>Représente une valeur proche de zéro , la plus petite valeur possible d'un double </summary>
    //     public const double DBL_EPSILON = double.Epsilon;

    //     /// <summary>2 x PI  </summary>
    //     public const float FLT_2_PI = 6.28318530718f;
    //     /// <summary>PI / 2 </summary>
    //     public const float FLT_HALF_PI = 1.57079632679489661923132169163975144f;
    //     /// <summary>PI x PI </summary>
    //     public const float FLT_PI_SQUARED = 9.86960440109f;
    //     /// <summary>Racine carré de PI  </summary>
    //     public const float FLT_SQUARE_ROOT_PI = 1.772453850905516027f;
    //     /// <summary>1 / PI  </summary>
    //     public const float FLT_INV_PI = 0.318309886183790671537767526745028724f;
    //     /// <summary>PI / 180 </summary>
    //     public const float FLT_PI_OVER_180 = 0.01745329252165517991444444444444f;
    //     /// <summary>PI / 2  </summary>
    //     public const float FLT_PI_OVER_2 = 1.57079632679489661923132169163975144f;
    //     /// <summary>PI / 4 </summary>
    //     public const float FLT_PI_OVER_4 = FLT_PI / 4;

    //      /// <summary>2 x PI  </summary>
    //     public const double DBL_2_PI = 6.28318530718;
    //     /// <summary>PI / 2 </summary>
    //     public const double DBL_HALF_PI = 1.57079632679489661923132169163975144;
    //     /// <summary>PI x PI </summary>
    //     public const double DBL_PI_SQUARED = 9.86960440109;
    //     /// <summary>Racine carré de PI  </summary>
    //     public const double DBL_SQUARE_ROOT_PI = 1.772453850905516027;
    //     /// <summary>1 / PI  </summary>
    //     public const double DBL_INV_PI = 0.318309886183790671537767526745028724;
    //     /// <summary>PI / 180 </summary>
    //     public const double DBL_PI_OVER_180 = 0.01745329252165517991444444444444;
    //     /// <summary>PI / 2  </summary>
    //     public const double DBL_PI_OVER_2 = 1.57079632679489661923132169163975144;
    //     /// <summary>PI / 4 </summary>
    //     public const double DBL_PI_OVER_4 = DBL_PI / 4;
    //     #endregion

    //     #region CONVERSION ANGLE


    // #region ABS    


    //     /// <summary>
    //     /// Retourne a valeur absolue ( sans le signe) d'un entier
    //     /// </summary>
    //     /// <param name="val"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static int Abs(int val)
    //     {
    //         int mask = val >> (sizeof(int) * CH_BIT) - 1;
    //         return (val + mask) ^ mask;
    //         // Patented variation:  r = (valeur ^ mask) - mask;   
    //     }
    // #endregion



    // #endregion

    // #region FLOAT DOUBLE PROPERTIES

    //     /// <summary>
    //     /// Determines whether the specified value is close to zero (0.0f).
    //     /// </summary>
    //     /// <param name="a">The floating value.</param>
    //     /// <returns><c>true</c> if the specified value is close to zero (0.0f); otherwise, <c>false</c>.</returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static bool IsZero(float a) => Abs(a) < FLT_EPSILON;

    //     /// <summary>
    //     /// Checks if a and b are almost equals, taking into account the magnitude of floating point numbers (unlike <see cref="WithinEpsilon(float,float,float)" /> method).
    //     /// </summary>
    //     /// <param name="a">The left value to compare.</param>
    //     /// <param name="b">The right value to compare.</param>
    //     /// <returns><c>true</c> if a almost equal to b, <c>false</c> otherwise</returns>
    //     /// <remarks>The code is using the technique described by Bruce Dawson in <a href="http://randomascii.wordpress.com/2012/02/25/comparing-floating-point-numbers-2012-edition/">Comparing Floating point numbers 2012 edition</a>.</remarks>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static unsafe bool NearEqual(float a, float b)
    //     {
    //         // var t = a.GetType() == typeof(float)  ? FLT_EPSILON : DBL_EPSILON ;

    //         // Check if the numbers are really close -- needed when comparing numbers near zero.
    //         if (Abs(a - b) < FLT_EPSILON)
    //             return true;

    //         // Original from Bruce Dawson: http://randomascii.wordpress.com/2012/02/25/comparing-floating-point-numbers-2012-edition/
    //         int aInt = *(int*)&a;
    //         int bInt = *(int*)&b;

    //         // Different signs means they do not match.
    //         if (aInt < 0 != bInt < 0)
    //             return false;

    //         // Find the difference in ULPs.
    //         int ulp = Abs(aInt - bInt);

    //         // Choose of maxUlp = 4
    //         // according to http://code.google.com/p/googletest/source/browse/trunk/include/gtest/internal/gtest-internal.h
    //         const int maxUlp = 4;
    //         return ulp <= maxUlp;
    //     }

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="f"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float NegF(float f) =>  (int)f ^ 0x80000000   ;

    //     /// <summary>
    //     /// redonne +1 pour 0 ou des nombres positifs , -1 pour les nombres n�gatifs
    //     /// </summary>
    //     /// <param name="valeur"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static int Sign( float valeur) => float.Sign(valeur);// 1 + ((((int)valeur) >> 31) << 1);

    //     /// <summary>
    //     /// redonne +1 pour 0 ou des nombres positifs , -1 pour les nombres n�gatifs
    //     /// </summary>
    //     /// <param name="valeur"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static int Sign( double valeur) => double.Sign(valeur);// 1 + ((((int)valeur) >> 31) << 1);

    // #endregion

    // #region APPROXIMATION ARRONDI

    //     /// <summary>   Arrondi à la valeur la plus proche  </summary>
    //     /// <param name="value"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float Round(float value) => System.MathF.Round( value);

    //     /// <summary>   Arrondi à la valeur la plus proche  </summary>
    //     /// <param name="value"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double Round(double value) => System.Math.Round( value);

    //     /// <summary>   Arrondi à la valeur la plus proche  </summary>
    //     /// <param name="value"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float Round(float value, int digits) => System.MathF.Round( value, digits);

    //     /// <summary>   Arrondi à la valeur la plus proche  </summary>
    //     /// <param name="value"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double Round(double value, int digits) => System.Math.Round( value, digits);

    //     /// <summary>
    //     /// Returns the largest integral value less than or equal to the specified single-precision floating-point number.
    //     /// </summary>
    //     /// <param name="f"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float Floor(float f) => System.MathF.Floor(f);

    //     /// <summary>
    //     /// Returns the largest integral value less than or equal to the specified single-precision floating-point number.
    //     /// </summary>
    //     /// <param name="d"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double Floor(double d) => System.Math.Floor(d);

    //     /// <summary>
    //     /// Donne l'arrondie au chiffre supérieur
    //     /// </summary>
    //     /// <param name="fp"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static int FloorFast(float fp) => (int)(fp + 32768.0f) - 32768;

    //     /// <summary>
    //     /// Donne l'arrondie au chiffre inférieur
    //     /// </summary>
    //     /// <param name="fp"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static int CeilingFast(float fp) => 32768 - (int)(32768.0f - fp);

    //     /// <summary>
    //     /// Donne l'arrondie au chiffre inférieur
    //     /// </summary>
    //     /// <param name="fp"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double Ceiling(double fp) =>System.Math.Ceiling(fp);

    //     /// <summary>
    //     /// Donne l'arrondie au chiffre inférieur
    //     /// </summary>
    //     /// <param name="fp"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float Ceiling(float fp) =>System.MathF.Ceiling(fp);

    //     #endregion

    //     #region TRIGONOMETRIE ANGLES

    //     /// <summary> Retourne la Tangeante de l'angle spécifié ( Cos / Sin )  </summary>
    //     /// <param name="x"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float Tan(float x) => System.MathF.Tan(x);

    //     /// <summary> Retourne la Tangeante de l'angle spécifié ( Cos / Sin )  </summary>
    //     /// <param name="x"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double Tan(double x) => System.Math.Tan(x);

    //     /// <summary> Retourne le cosinus de l'angle spécifié  </summary>
    //     /// <param name="x"></param>
    //     /// <returns>The cosine of d. If d is equal to double.NaN, double.NegativeInfinity, or double.PositiveInfinity, this method returns double.NaN</returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float Cos(float x) => System.MathF.Cos(x);
    //      /// <summary> Retourne le cosinus de l'angle spécifié en radians  </summary>
    //     /// <param name="x"></param>
    //     /// <returns>The cosine of d. If d is equal to double.NaN, double.NegativeInfinity, or double.PositiveInfinity, this method returns double.NaN</returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double Cos(double x) => System.Math.Cos(x);

    //     /// <summary> Retourne le sinuss de l'angle spécifié  </summary>
    //     /// <param name="x"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float Sin(float x) => System.MathF.Sin(x);
    //       /// <summary> Retourne le sinuss de l'angle spécifié  </summary>
    //     /// <param name="x"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double Sin(double x) => System.Math.Sin(x);

    //     /// <summary>
    //     /// entre pi et -pi Returns the angle whose tangent is the quotient of two specified numbers.
    //     /// </summary>
    //     /// <param name="x"></param>
    //     /// <param name="y"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float ATan2(float x, float y) => System.MathF.Atan2(x,y);

    //       /// <summary>
    //     /// entre pi et -pi Returns the angle whose tangent is the quotient of two specified numbers.
    //     /// </summary>
    //     /// <param name="x"></param>
    //     /// <param name="y"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double ATan2(double x, double y) => System.Math.Atan2(x,y);

    //     /// <summary>
    //     /// Returns the angle whose tangent is the specified number.
    //     /// </summary>
    //     /// <param name="x"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float ATan(float x) => System.MathF.Atan(x);

    //     /// <summary>
    //     /// Returns the angle whose tangent is the specified number.
    //     /// </summary>
    //     /// <param name="x"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double ATan(double x) => System.Math.Atan(x);

    //     /// <summary>
    //     /// Returns the angle whose cosine is the specified number.
    //     /// </summary>
    //     /// <param name="x"></param>
    //     /// <returns>An angle, θ, measured in radians, such that 0 ≤ θ ≤ π. -or- double.NaN if d < -1 or d > 1 or d equals double.NaN</returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float ACos(float x) => System.MathF.Acos(x);
    //     /// <summary>
    //     /// Returns the angle whose cosine is the specified number.
    //     /// </summary>
    //     /// <param name="x"></param>
    //     /// <returns>An angle, θ, measured in radians, such that 0 ≤ θ ≤ π. -or- double.NaN if d < -1 or d > 1 or d equals double.NaN</returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double ACos(double x) => System.Math.Acos(x);

    //     /// <summary>
    //     /// Returns the angle whose sine is the specified number.
    //     /// </summary>
    //     /// <param name="x"></param>
    //     /// <returns>An angle, θ, measured in radians, such that -π/2 ≤ θ ≤ π/2. -or- float.NaN if x < -1 or x > 1 or x equals float.NaN</returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float ASin(float x) => System.MathF.Asin(x);

    //     // / <summary>
    //     // / Returns the angle whose sine is the specified number.
    //     // / </summary>
    //     // / <param name="x"></param>
    //     // / <returns>An angle, θ, measured in radians, such that -π/2 ≤ θ ≤ π/2. -or- float.NaN if x < -1 or x > 1 or x equals float.NaN </returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double ASin(double x) => System.Math.Asin(x);

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="val"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public	static float SinFast(float val)
    //     {
    //         float angleSqr = val * val;
    //         float result = -2.39e-08f;
    //         result *= angleSqr;
    //         result += 2.7526e-06f;
    //         result *= angleSqr;
    //         result -= 1.98409e-04f;
    //         result *= angleSqr;
    //         result += 8.3333315e-03f;
    //         result *= angleSqr;
    //         result -= 1.666666664e-01f;
    //         result *= angleSqr;
    //         result++;
    //         result *= val;
    //         return result;
    //     }

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="val"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public	static double SinFast(double val)
    //     {
    //         double angleSqr = val * val;
    //         double result = -2.39e-08;
    //         result *= angleSqr;
    //         result += 2.7526e-06;
    //         result *= angleSqr;
    //         result -= 1.98409e-04;
    //         result *= angleSqr;
    //         result += 8.3333315e-03;
    //         result *= angleSqr;
    //         result -= 1.666666664e-01;
    //         result *= angleSqr;
    //         result++;
    //         result *= val;
    //         return result;
    //     }

    //     /// <summary>
    //     /// Fast sinus en valeur approché <see href="http://forum.devmaster.net/t/fast-and-accurate-sine-cosine/9648" />
    //     /// </summary>
    //     /// <param name="x"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static   float SinFaster(float x) {
    //         float y = (1.27323954474f * x) - (0.40528473456f * x * Abs(x));
    //         return (0.225f * ((y * Abs(y)) - y)) + y;   // Q * y + P * y * abs(y)
    //     }

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="val"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float CosFast(float val)
    //     {
    //         float angleSqr = val * val;
    //         float result = -2.605e-07f;
    //         result *= angleSqr;
    //         result += 2.47609e-05f;
    //         result *= angleSqr;
    //         result -= 1.3888397e-03f;
    //         result *= angleSqr;
    //         result += 4.16666418e-02f;
    //         result *= angleSqr;
    //         result -= 4.999999963e-01f;
    //         result *= angleSqr;
    //         result++;

    //         return result;
    //     }

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="val"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double CosFast(double val)
    //     {
    //         double angleSqr = val * val;
    //         double result = -2.605e-07;
    //         result *= angleSqr;
    //         result += 2.47609e-05;
    //         result *= angleSqr;
    //         result -= 1.3888397e-03;
    //         result *= angleSqr;
    //         result += 4.16666418e-02;
    //         result *= angleSqr;
    //         result -= 4.999999963e-01;
    //         result *= angleSqr;
    //         result++;

    //         return result;
    //     }

    //     /// <summary>
    //     /// Fast tangante
    //     /// </summary>
    //     /// <param name="val"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float TanFast(float val)
    //     {
    //         float angleSqr = val * val;
    //         float result = 9.5168091e-03f;

    //         result *= angleSqr;
    //         result += 2.900525e-03f;
    //         result *= angleSqr;
    //         result += 2.45650893e-02f;
    //         result *= angleSqr;
    //         result += 5.33740603e-02f;
    //         result *= angleSqr;
    //         result += 1.333923995e-01f;
    //         result *= angleSqr;
    //         result += 3.333314036e-01f;
    //         result *= angleSqr;
    //         result++;
    //         result *= val;

    //         return result;
    //     }

    //     /// <summary>
    //     /// Fast tangante
    //     /// </summary>
    //     /// <param name="val"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double TanFast(double val)
    //     {
    //         double angleSqr = val * val;
    //         double result = 9.5168091e-03f;

    //         result *= angleSqr;
    //         result += 2.900525e-03f;
    //         result *= angleSqr;
    //         result += 2.45650893e-02f;
    //         result *= angleSqr;
    //         result += 5.33740603e-02f;
    //         result *= angleSqr;
    //         result += 1.333923995e-01f;
    //         result *= angleSqr;
    //         result += 3.333314036e-01f;
    //         result *= angleSqr;
    //         result++;
    //         result *= val;

    //         return result;
    //     }

    // #endregion

    // #region LOG POW EXP

    //     /// <summary> Retourne la valeur x élevé  à la puissance de y  </summary>
    //     /// <param name="x"></param>
    //     /// <param name="y"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float Pow(float x , float y ) => System.MathF.Pow(x,y);

    //     /// <summary> Retourne la valeur x élevé  à la puissance de y  </summary>
    //     /// <param name="x"></param>
    //     /// <param name="y"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double Pow(double x , double y ) => System.Math.Pow(x,y);

    //     /// <summary>
    //     /// eleve la valeur e a la puissance
    //     /// </summary>
    //     /// <param name="e"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float Exp(float e) => System.MathF.Exp(e);
    //     /// <summary>
    //     /// eleve la valeur e a la puissance
    //     /// </summary>
    //     /// <param name="e"></param>
    //     /// <returns>The number e raised to the power d. If d equals double.NaN or double.PositiveInfinity, that value is returned. If d equals double.NegativeInfinity, 0 is returned</returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double Exp(double e) => System.Math.Exp(e);

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="x"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float Log(float x) => System.MathF.Log( x);

    //     /// <summary>
    //     /// Returns the natural (base e) logarithm of a specified number.
    //     /// Retourne :One of the values in the following table.
    //     /// d parameter – Return value
    //     /// Positive – The natural logarithm of d; that is, ln d, or log e d
    //     /// Zero –double.NegativeInfinity
    //     /// Negative –double.NaN
    //     /// Equal to double.NaN –double.NaN
    //     /// </summary>
    //     /// <param name="x"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static double Log(double x) => System.Math.Log( x);

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="p"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static unsafe float Pow2Faster(float p)
    //     {
    //         float clipp = (p < -126) ? -126.0f : p;
    //         uint ui = *(uint*)&clipp;
    //         return (ui<< 23) * (clipp + 126.94269504f);
    //     }

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="p"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float ExpFaster(float p) => Pow2Faster(1.442695040f * p);

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="x"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static unsafe float Log2Faster(float x) 
    //     {
    //         int i = *(int*)&x;
    //         float y = *(float*)&i;
    //         y *= 1.1920928955078125e-7f;
    //         return y - 126.94269504f;
    //     }

    //     /// <summary>
    //     /// 
    //     /// </summary>
    //     /// <param name="x"></param>
    //     /// <returns></returns>
    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static  unsafe float LogFaster(float x) =>  0.69314718f * Log2Faster (x);

    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static unsafe  float Log2Fast(float x) 
    //     {
    //         int i = *(int*)&x;
    //         var mx = i & 0x007FFFFF | 0x3f000000 ;
    //         float y = *(float*)&mx;

    //         y *= 1.1920928955078125e-7f;

    //     	return y - 124.22551499f
    //     		- 1.498030302f * y
    //     		- 1.72587999f / (0.3520887068f + y);
    //     }

    //     // [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float LogFast(float x) =>  0.69314718f * Log2Fast(x);

    // 	#endregion

    // 	#region CLAMP 

    // 	/// <summary>
    // 	/// Borne une valeur coprise entre min et max 
    // 	/// </summary>
    // 	/// <param name="value"></param>
    // 	/// <param name="min"></param>
    // 	/// <param name="max"></param>
    // 	/// <returns></returns>
    // 	// [SuppressUnmanagedCodeSecurity]
    //     // [SuppressGCTransition]
    //     // [SkipLocalsInit]
    //     [Pure] 
    //     public static float Clamp(float value, float min , float max)
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
    //     public static double Clamp(double value, double min , double max)
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