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
/// Random Number Generator based on Permutation-Congruential-Generator (PCG), which is a fancy wording to
/// describe a family of RNG which are simple, fast, statistically excellent, and hardly predictable.
/// 
/// More interestingly, PCG allows to generate multiple sequences with the same seed, which is very handy
/// in game development to have a unique seed per game session while using different streams for each
/// RNG which requires an isolated context (e.g. generating a procedural level, but we don't want the loot
/// generation to affect subsequent level generations).
/// 
/// https://www.pcg-random.org/
/// 
/// This code is derived from the minimal C implementation.
/// https://github.com/imneme/pcg-c-basic
/// take on site : //https://gist.github.com/mrhelmut
/// </summary>
[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public sealed class MiniPCG32 : IDisposable, IEquatable<MiniPCG32>
{
    // state
    private ulong _state;
    private readonly ulong _inc;

    /// <summary>
    /// Initiaze a random number generator.
    /// </summary>
    public MiniPCG32() : this((ulong)System.Environment.TickCount) { }

    /// <summary>
    /// Initiaze a random number generator. Specified in two parts, state initializer (a.k.a. seed) and a sequence selection constant (a.k.a. stream id).
    /// </summary>
    /// <param name="state">State initializer (a.k.a. seed).</param>
    /// <param name="streamID">Sequence selection constant (a.k.a. stream id). Defaults to 0.</param>
    public MiniPCG32(ulong state, ulong streamID = 0)
    {
        _state = 0ul;
        _inc = (streamID << 1) | 1ul;
        PCG32();
        _state += state;
        PCG32();
    }

    /// <summary>
    /// Generate a uniformly distributed number.
    /// </summary>
    /// <returns>A uniformly distributed 32bit unsigned integer.</returns>
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    private uint PCG32()
    {
        ulong oldState = _state;
        // Advance public state
        _state = unchecked(_state * 6364136223846793005ul + _inc);
        // Calculate output function (XSH RR), uses old state for max ILP
        uint xorshifted = (uint)(((oldState >> 18) ^ oldState) >> 27);
        int rot = (int)(oldState >> 59);
        return (xorshifted >> rot) | (xorshifted << ((-rot) & 31));
    }

    /// <summary>
    /// Generate a uniformly distributed number, r, where 0 inferieur ou egal à r et inferieur à  <paramref name="bound"/>.
    /// </summary>
    /// <param name="bound">Exclusive upper bound of the number to generate.</param>
    /// <returns>A uniformly distributed 32bit unsigned integer strictly less than <paramref name="bound"/>.</returns>
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    private uint PCG32(uint bound)
    {
        // To avoid bias, we need to make the range of the RNG a multiple of
        // bound, which we do by dropping output less than a threshold.
        uint threshold = ((uint)-bound) % bound;

        // Uniformity guarantees that this loop will terminate.  In practice, it
        // should usually terminate quickly; on average (assuming all bounds are
        // equally likely), 82.25% of the time, we can expect it to require just
        // one iteration.  In the worst case, someone passes a bound of 2^31 + 1
        // (i.e., 2147483649), which invalidates almost 50% of the range.  In 
        // practice, bounds are typically small and only a tiny amount of the range
        // is eliminated.
        while (true)
        {
            uint r = PCG32();
            if (r >= threshold)
                return r % bound;
        }
    }

    /// <summary>
    /// Generate a random positive number.
    /// </summary>
    /// <returns>A random positive number.</returns>
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public int Next() => Next(int.MaxValue);

    /// <summary>
    /// Generate a random number with an exclusive <paramref name="maxValue"/> upperbound.
    /// </summary>
    /// <param name="maxValue">Exclusive upper bound.</param>
    /// <returns>A random number with an exclusive <paramref name="maxValue"/> upperbound.</returns>
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public int Next(int maxValue)
    {
        if (maxValue < 0)
            maxValue = 0;

        return (int)PCG32((uint)maxValue);
    }

    /// <summary>
    /// Generate a random number ranging from <paramref name="minValue"/> to <paramref name="maxValue"/>.
    /// </summary>
    /// <param name="minValue">Lower bound.</param>
    /// <param name="maxValue">Upper bound.</param>
    /// <returns>A random number ranging from <paramref name="minValue"/> to <paramref name="maxValue"/>.</returns>
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public int Next(int minValue, int maxValue)
    {
        if (maxValue < minValue)
            maxValue = minValue;

        return (int)(minValue + PCG32((uint)((long)maxValue - minValue)));
    }

    /// <summary>
    /// Generate a random float ranging from 0.0f to 1.0f.
    /// </summary>
    /// <returns>A random float ranging from 0.0f to 1.0f.</returns>
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public float NextFloat()
    {
        // This is quite hackish because we want to avoid BitConverter, but who cares?
        int bound = int.MaxValue / 2 - 1;
        return Next(bound) * 1.0f / bound;
    }

    /// <summary>
    /// Generate a random float ranging from <paramref name="minValue"/> to <paramref name="maxValue"/>.
    /// </summary>
    /// <param name="minValue">Lower bound.</param>
    /// <param name="maxValue">Upper bound.</param>
    /// <returns>A random float ranging from <paramref name="minValue"/> to <paramref name="maxValue"/>.</returns>
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public float NextFloat(float minValue, float maxValue)
    {
        if (maxValue < minValue)
            maxValue = minValue;

        return minValue + (maxValue - minValue) * NextFloat();
    }

    // private T CheckMinMax<T>(T minValue, T maxValue ) => (maxValue < minValue) ? minValue : maxValue ;

    ///<inherit />
    public void Dispose() => GC.SuppressFinalize(this);

    /// <summary>
    /// Generate a random bool.
    /// </summary>
    /// <returns>A random bool.</returns>
    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
    public bool NextBool() => NextFloat() <= 0.5f;

    #region [ public OVERRIDE ]
    ///<inherit />
    public bool Equals(MiniPCG32? other) => false;
    ///<inherit />
    public static bool operator ==(MiniPCG32 left, MiniPCG32 right) => false;
    ///<inherit />
    public static bool operator !=(MiniPCG32 left, MiniPCG32 right) => true;
    ///<inherit />
    public override bool Equals(object? obj) => false;
    ///<inherit />
    public override string ToString() => $"-Random Generator  : MinPCG32 - {this._state} ";
    ///<inherit />
    public override int GetHashCode() => this._state.GetHashCode() ^ 32 + this._inc.GetHashCode() ^ 325;

    #endregion
}
