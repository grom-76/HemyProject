/*
            ██████   █████  ███    ██ ██████   ██████  ███    ███
            ██   ██ ██   ██ ████   ██ ██   ██ ██    ██ ████  ████
            ██████  ███████ ██ ██  ██ ██   ██ ██    ██ ██ ████ ██
            ██   ██ ██   ██ ██  ██ ██ ██   ██ ██    ██ ██  ██  ██
            ██   ██ ██   ██ ██   ████ ██████   ██████  ██      ██

## DESCRIPTION 
    STAND ALONE STATIC CLASS FOR SIMPLY LOG 

## Créer le : par : 
    5/11/2023 v0.1

## REVISION :
   05 12 2023 v0.1.3 
    -  clean code & refactor 
	- add some new algo The Lehmer Algorithm
	- The Wichmann-Hill
	- The Lagged Fibonacci Algorithm
## TODO 
    [ ] - Faire un Randoms  avec Randoms random = new( Algrithm Selected )  random.Next random.Next(min, max );
    

## METHODS HELPER 
    - function NAME   // ( description )
        params IN - OUT ( min max default value )
        Return
        Exception
        Example code 

## SOURCES LIENS UTILISER :
A VOIR :
    https://itecnote.com/tecnote/c-simple-pseudo-random-algorithm/
    https://www.programmingalgorithms.com/algorithm/random-jitter/ ( pour les photos )
    https://learn.microsoft.com/en-us/archive/msdn-magazine/2016/august/test-run-lightweight-random-number-generation
    http://www.csharphelper.com/howtos/howto_one_self_avoiding_walk.html
    https://istacee.wordpress.com/2013/10/13/truly-random-algorithm-in-c-the-chaotic-user/
    https://codereview.stackexchange.com/questions/273390/c-prng-class-based-on-xoshiro256 ( Fractal terrain ) 
    https://github.com/zanaptak/PcgRandom/blob/main/src/Pcg.fs
    https://github.com/uranium62/xxHash/tree/master/src/Standart.Hash.xxHash
*/

namespace Hemy.Lib.Core.Math.Random;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

/// <summary>
/// Class permet de generer des nombre pseudo aléatoire a besoin d'une graine pour etre aléatoir (seed )
/// Utilise => XorShift128Generator
/// </summary>
/// 
[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public sealed class XorShift128 : IDisposable, IEquatable<XorShift128>
{
    #region class fields
    /// <summary>
    /// Represents the seed for the <see cref="y"/> variable. This field is constant.
    /// </summary>
    /// <remarks>The value of this constant is 362436069.</remarks>
    private const uint SeedY = 362436069;

    /// <summary>
    /// Represents the seed for the <see cref="z"/> variable. This field is constant.
    /// </summary>
    /// <remarks>The value of this constant is 521288629.</remarks>
    private const uint SeedZ = 521288629;

    /// <summary>
    /// Represents the seed for the <see cref="w"/> variable. This field is constant.
    /// </summary>
    /// <remarks>The value of this constant is 88675123.</remarks>
    private const uint SeedW = 88675123;

    /// <summary>
    /// Represents the multiplier that computes a double-precision floating point number greater than or equal to 0.0 
    ///   and less than 1.0 when it gets applied to a nonnegative 32-bit signed integer.
    /// </summary>
    private const double IntToDoubleMultiplier = 1.0 / ((double)int.MaxValue + 1.0);

    /// <summary>
    /// Represents the multiplier that computes a double-precision floating point number greater than or equal to 0.0 
    ///   and less than 1.0  when it gets applied to a 32-bit unsigned integer.
    /// </summary>
    private const double UIntToDoubleMultiplier = 1.0 / ((double)uint.MaxValue + 1.0);
    #endregion

    #region instance fields
    /// <summary>
    /// Stores the last but three unsigned random number. 
    /// </summary>
    private uint x;

    /// <summary>
    /// Stores the last but two unsigned random number. 
    /// </summary>
    private uint y;

    /// <summary>
    /// Stores the last but one unsigned random number. 
    /// </summary>
    private uint z;

    /// <summary>
    /// Stores the last generated unsigned random number. 
    /// </summary>
    private uint w;

    /// <summary>
    /// Stores the used seed value.
    /// </summary>
    private uint seed;

    /// <summary>
    /// Stores an <see cref="uint"/> used to generate up to 32 random <see cref="Boolean"/> values.
    /// </summary>
    private uint bitBuffer;

    /// <summary>
    /// Stores how many random <see cref="Boolean"/> values still can be generated from <see cref="bitBuffer"/>.
    /// </summary>
    private int bitCount;
    #endregion

    #region construction
    /// <summary>
    /// Initializes a new instance of the <see cref="Random"/> class, using a time-dependent default 
    ///   seed value.
    /// </summary>
    public XorShift128()
    {
        this.seed = (uint)System.Math.Abs(System.Environment.TickCount);
        this.ResetGenerator();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Random"/> class, using the specified seed value.
    /// </summary>
    /// <param name="seed">
    /// A number used to calculate a starting value for the pseudo-random number sequence.
    /// If a negative number is specified, the absolute value of the number is used. 
    /// </param>
    public XorShift128(int seed)
    {
        this.seed = (uint)System.Math.Abs(seed);
        this.ResetGenerator();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Random"/> class, using the specified seed value.
    /// </summary>
    /// <param name="seed">
    /// An unsigned number used to calculate a starting value for the pseudo-random number sequence.
    /// </param>
    public XorShift128(uint seed)
    {
        this.seed = seed;
        this.ResetGenerator();
    }

    ///<inherit />
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    #endregion

    #region instance methods
    /// <summary>
    /// Resets the <see cref="Random"/>, so that it produces the same pseudo-random number sequence again.
    /// </summary>
    private void ResetGenerator()
    {
        // "The seed set for xor128 is four 32-bit integers x,y,z,w not all 0, ..." (George Marsaglia)
        // To meet that requirement the y, z, w seeds are constant values greater 0.
        this.x = this.seed;
        this.y = XorShift128.SeedY;
        this.z = XorShift128.SeedZ;
        this.w = XorShift128.SeedW;

        // Reset helper variables used for generation of random bools.
        this.bitBuffer = 0;
        this.bitCount = 0;
    }

    /// <summary>
    /// Returns an unsigned random number.
    /// </summary>
    /// <returns>
    /// A 32-bit unsigned integer greater than or equal to <see cref="UInt32.MinValue"/> and 
    ///   less than or equal to <see cref="UInt32.MaxValue"/>.
    /// </returns>
    public uint NextUInt()
    {
        uint t = (this.x ^ (this.x << 11));
        this.x = this.y;
        this.y = this.z;
        this.z = this.w;
        return (this.w = (this.w ^ (this.w >> 19)) ^ (t ^ (t >> 8)));
    }

    /// <summary>
    /// Returns a nonnegative random number less than or equal to <see cref="Int32.MaxValue"/>.
    /// </summary>
    /// <returns>
    /// A 32-bit signed integer greater than or equal to 0, and less than or equal to <see cref="Int32.MaxValue"/>; 
    ///   that is, the range of return values includes 0 and "Int32.MaxValue"/>.
    /// </returns>
    public int NextInclusiveMaxValue()
    {
        // Its faster to explicitly calculate the unsigned random number than simply call NextUInt().
        uint t = (this.x ^ (this.x << 11));
        this.x = this.y;
        this.y = this.z;
        this.z = this.w;
        uint w = (this.w = (this.w ^ (this.w >> 19)) ^ (t ^ (t >> 8)));

        return (int)(w >> 1);
    }
    #endregion

    #region overridden Generator members

    /// <summary>
    /// Resets the <see cref="Random"/>, so that it produces the same pseudo-random number sequence again.
    /// </summary>
    /// <returns><see langword="true"/>.</returns>
    public bool Reset()
    {
        this.ResetGenerator();
        return true;
    }

    /// <summary>
    /// Returns a nonnegative random number less than <see cref="Int32.MaxValue"/>.
    /// </summary>
    /// <returns>
    /// A 32-bit signed integer greater than or equal to 0, and less than <see cref="Int32.MaxValue"/>; that is, 
    ///   the range of return values includes 0 but not "Int32.MaxValue">.
    /// </returns>
    public int Next()
    {
        // Its faster to explicitly calculate the unsigned random number than simply call NextUInt().
        uint t = (this.x ^ (this.x << 11));
        this.x = this.y;
        this.y = this.z;
        this.z = this.w;
        uint w = (this.w = (this.w ^ (this.w >> 19)) ^ (t ^ (t >> 8)));

        int result = (int)(w >> 1);
        // Exclude Int32.MaxValue from the range of return values.
        if (result == Int32.MaxValue)
        {
            return this.Next();
        }
        else
        {
            return result;
        }
    }

    /// <summary>
    /// Returns a nonnegative random number less than the specified maximum.
    /// </summary>
    /// <param name="maxValue">
    /// The exclusive upper bound of the random number to be generated. 
    /// <paramref name="maxValue"/> must be greater than or equal to 0. 
    /// </param>
    /// <returns>
    /// A 32-bit signed integer greater than or equal to 0, and less than <paramref name="maxValue"/>; that is, 
    ///   the range of return values includes 0 but not <paramref name="maxValue"/>. 
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="maxValue"/> is less than 0. 
    /// </exception>
    public int Next(int maxValue)
    {
        if (maxValue < 0)
        {
            // string message = string.Format(null, ExceptionMessages.ArgumentOutOfRangeGreaterEqual,
            //     "maxValue", "0");
            // throw new ArgumentOutOfRangeException("maxValue", maxValue, message);
            return 0;
        }

        // Its faster to explicitly calculate the unsigned random number than simply call NextUInt().
        uint t = (this.x ^ (this.x << 11));
        this.x = this.y;
        this.y = this.z;
        this.z = this.w;
        uint w = (this.w = (this.w ^ (this.w >> 19)) ^ (t ^ (t >> 8)));

        // The shift operation and extra int cast before the first multiplication give better performance.
        // See comment in NextDouble().
        return (int)((double)(int)(w >> 1) * XorShift128.IntToDoubleMultiplier * (double)maxValue);
    }

    /// <summary>
    /// Returns a random number within the specified range. 
    /// </summary>
    /// <param name="minValue">
    /// The inclusive lower bound of the random number to be generated. 
    /// </param>
    /// <param name="maxValue">
    /// The exclusive upper bound of the random number to be generated. 
    /// <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>. 
    /// </param>
    /// <returns>
    /// A 32-bit signed integer greater than or equal to <paramref name="minValue"/>, and less than 
    ///   <paramref name="maxValue"/>; that is, the range of return values includes <paramref name="minValue"/> but 
    ///   not <paramref name="maxValue"/>. 
    /// If <paramref name="minValue"/> equals <paramref name="maxValue"/>, <paramref name="minValue"/> is returned.  
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="minValue"/> is greater than <paramref name="maxValue"/>.
    /// </exception>
    public int Next(int minValue, int maxValue)
    {
        if (minValue > maxValue)
        {
            // string message = string.Format(null, ExceptionMessages.ArgumentOutOfRangeGreaterEqual,
            //    "maxValue", "minValue");
            // throw new ArgumentOutOfRangeException("maxValue", maxValue, message);
            return 0;
        }

        // Its faster to explicitly calculate the unsigned random number than simply call NextUInt().
        uint t = (this.x ^ (this.x << 11));
        this.x = this.y;
        this.y = this.z;
        this.z = this.w;
        uint w = (this.w = (this.w ^ (this.w >> 19)) ^ (t ^ (t >> 8)));

        int range = maxValue - minValue;
        if (range < 0)
        {
            // The range is greater than Int32.MaxValue, so we have to use slower floating point arithmetic.
            // Also all 32 random bits (uint) have to be used which again is slower (See comment in NextDouble()).
            return minValue + (int)
                ((double)w * XorShift128.UIntToDoubleMultiplier * ((double)maxValue - (double)minValue));
        }
        else
        {
            // 31 random bits (int) will suffice which allows us to shift and cast to an int before the first multiplication and gain better performance.
            // See comment in NextDouble().
            return minValue + (int)((double)(int)(w >> 1) * XorShift128.IntToDoubleMultiplier * (double)range);
        }
    }

    /// <summary>
    /// Returns a nonnegative floating point random number less than 1.0.
    /// </summary>
    /// <returns>
    /// A double-precision floating point number greater than or equal to 0.0, and less than 1.0; that is, 
    ///   the range of return values includes 0.0 but not 1.0.
    /// </returns>
    public double NextDouble()
    {
        // Its faster to explicitly calculate the unsigned random number than simply call NextUInt().
        uint t = (this.x ^ (this.x << 11));
        this.x = this.y;
        this.y = this.z;
        this.z = this.w;
        uint w = (this.w = (this.w ^ (this.w >> 19)) ^ (t ^ (t >> 8)));

        // Here a ~2x speed improvement is gained by computing a value that can be cast to an int 
        //   before casting to a double to perform the multiplication.
        // Casting a double from an int is a lot faster than from an uint and the extra shift operation 
        //   and cast to an int are very fast (the allocated bits remain the same), so overall there's 
        //   a significant performance improvement.
        return (double)(int)(w >> 1) * XorShift128.IntToDoubleMultiplier;
    }

    /// <summary>
    /// Returns a nonnegative floating point random number less than the specified maximum.
    /// </summary>
    /// <param name="maxValue">
    /// The exclusive upper bound of the random number to be generated. 
    /// <paramref name="maxValue"/> must be greater than or equal to 0.0. 
    /// </param>
    /// <returns>
    /// A double-precision floating point number greater than or equal to 0.0, and less than <paramref name="maxValue"/>; 
    ///   that is, the range of return values includes 0 but not <paramref name="maxValue"/>. 
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="maxValue"/> is less than 0. 
    /// </exception>
    public double NextDouble(double maxValue)
    {
        if (maxValue < 0.0)
        {
            // string message = string.Format(null, ExceptionMessages.ArgumentOutOfRangeGreaterEqual,
            //     "maxValue", "0.0");
            // throw new ArgumentOutOfRangeException("maxValue", maxValue, message);
            return 0.0;
        }

        // Its faster to explicitly calculate the unsigned random number than simply call NextUInt().
        uint t = (this.x ^ (this.x << 11));
        this.x = this.y;
        this.y = this.z;
        this.z = this.w;
        uint w = (this.w = (this.w ^ (this.w >> 19)) ^ (t ^ (t >> 8)));

        // The shift operation and extra int cast before the first multiplication give better performance.
        // See comment in NextDouble().
        return (double)(int)(w >> 1) * XorShift128.IntToDoubleMultiplier * maxValue;
    }

    /// <summary>
    /// Returns a floating point random number within the specified range. 
    /// </summary>
    /// <param name="minValue">
    /// The inclusive lower bound of the random number to be generated. 
    /// The range between <paramref name="minValue"/> and <paramref name="maxValue"/> must be less than or equal to
    ///   <see cref="Double.MaxValue"/>
    /// </param>
    /// <param name="maxValue">
    /// The exclusive upper bound of the random number to be generated. 
    /// <paramref name="maxValue"/> must be greater than or equal to <paramref name="minValue"/>.
    /// The range between <paramref name="minValue"/> and <paramref name="maxValue"/> must be less than or equal to
    ///   <see cref="Double.MaxValue"/>.
    /// </param>
    /// <returns>
    /// A double-precision floating point number greater than or equal to <paramref name="minValue"/>, and less than 
    ///   <paramref name="maxValue"/>; that is, the range of return values includes <paramref name="minValue"/> but 
    ///   not <paramref name="maxValue"/>. 
    /// If <paramref name="minValue"/> equals <paramref name="maxValue"/>, <paramref name="minValue"/> is returned.  
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="minValue"/> is greater than <paramref name="maxValue"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// The range between <paramref name="minValue"/> and <paramref name="maxValue"/> is greater than
    ///   <see cref="Double.MaxValue"/>.
    /// </exception>
    public double NextDouble(double minValue, double maxValue)
    {
        if (minValue > maxValue)
        {
            // string message = string.Format(null, ExceptionMessages.ArgumentOutOfRangeGreaterEqual,
            //     "maxValue", "minValue");
            // throw new ArgumentOutOfRangeException("maxValue", maxValue, message);
            return 0.0;
        }

        double range = maxValue - minValue;

        if (range == double.PositiveInfinity)
        {
            // string message = string.Format(null, ExceptionMessages.ArgumentRangeLessEqual,
            //     "minValue", "maxValue", "Double.MaxValue");
            // throw new ArgumentException(message);
            return 0.0;
        }

        // Its faster to explicitly calculate the unsigned random number than simply call NextUInt().
        uint t = (this.x ^ (this.x << 11));
        this.x = this.y;
        this.y = this.z;
        this.z = this.w;
        uint w = (this.w = (this.w ^ (this.w >> 19)) ^ (t ^ (t >> 8)));

        // The shift operation and extra int cast before the first multiplication give better performance.
        // See comment in NextDouble().
        return minValue + (double)(int)(w >> 1) * XorShift128.IntToDoubleMultiplier * range;
    }

    /// <summary>
    /// Returns a random Boolean value.
    /// </summary>
    /// <remarks>
    /// <remarks>
    /// Buffers 32 random bits (1 uint) for future calls, so a new random number is only generated every 32 calls.
    /// </remarks>
    /// </remarks>
    /// <returns>A <see cref="Boolean"/> value.</returns>
    public bool NextBoolean()
    {
        if (this.bitCount == 0)
        {
            // Generate 32 more bits (1 uint) and store it for future calls.
            // Its faster to explicitly calculate the unsigned random number than simply call NextUInt().
            uint t = (this.x ^ (this.x << 11));
            this.x = this.y;
            this.y = this.z;
            this.z = this.w;
            this.bitBuffer = (this.w = (this.w ^ (this.w >> 19)) ^ (t ^ (t >> 8)));

            // Reset the bitCount and use rightmost bit of buffer to generate random bool.
            this.bitCount = 31;
            return (this.bitBuffer & 0x1) == 1;
        }

        // Decrease the bitCount and use rightmost bit of shifted buffer to generate random bool.
        this.bitCount--;
        return ((this.bitBuffer >>= 1) & 0x1) == 1;
    }

    /// <summary>
    /// Fills the elements of a specified array of bytes with random numbers. 
    /// </summary>
    /// <remarks>
    /// Each element of the array of bytes is set to a random number greater than or equal to 0, and less than or 
    ///   equal to <see cref="byte.MaxValue"/>.
    /// </remarks>
    /// <param name="buffer">An array of bytes to contain random numbers.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="buffer"/> is a null reference (<see langword="Nothing"/> in Visual Basic). 
    /// </exception>
    public void NextBytes(byte[] buffer)
    {
        if (buffer == null)
        {
            // string message = string.Format(null, ExceptionMessages.ArgumentNull, "buffer");
            // throw new ArgumentNullException("buffer", message);
        }

        // Use local copies of x,y,z and w for better performance.
        uint x = this.x;
        uint y = this.y;
        uint z = this.z;
        uint w = this.w;

        // Fill the buffer with 4 bytes (1 uint) at a time.
        int i = 0;
        uint t;
        while (i < buffer!.Length - 3)
        {
            // Its faster to explicitly calculate the unsigned random number than simply call NextUInt().
            t = (x ^ (x << 11));
            x = y;
            y = z;
            z = w;
            w = (w ^ (w >> 19)) ^ (t ^ (t >> 8));

            buffer[i++] = (byte)w;
            buffer[i++] = (byte)(w >> 8);
            buffer[i++] = (byte)(w >> 16);
            buffer[i++] = (byte)(w >> 24);
        }

        // Fill up any remaining bytes in the buffer.
        if (i < buffer.Length)
        {
            // Its faster to explicitly calculate the unsigned random number than simply call NextUInt().
            t = (x ^ (x << 11));
            x = y;
            y = z;
            z = w;
            w = (w ^ (w >> 19)) ^ (t ^ (t >> 8));

            buffer[i++] = (byte)w;
            if (i < buffer.Length)
            {
                buffer[i++] = (byte)(w >> 8);
                if (i < buffer.Length)
                {
                    buffer[i++] = (byte)(w >> 16);
                    if (i < buffer.Length)
                    {
                        buffer[i] = (byte)(w >> 24);
                    }
                }
            }
        }
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }


    #endregion

    #region [ public OVERRIDE ]
    ///<inherit />
    public bool Equals(XorShift128 other) => false;
    ///<inherit />
    public static bool operator ==(XorShift128 left, XorShift128 right) => false;
    ///<inherit />
    public static bool operator !=(XorShift128 left, XorShift128 right) => true;
    ///<inherit />
    public override bool Equals(object obj) => false;
    ///<inherit />
    public override string ToString() => $"-Random Generator  : XorShift128 - {this.seed} ";
    ///<inherit />
    public override int GetHashCode() => this.seed.GetHashCode() ^ 32 + this.x.GetHashCode() ^ 325;

    #endregion
}
