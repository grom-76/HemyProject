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
/// The Linear Congruential Algorithm
/// As it turns out, both the Lehmer algorithm and the Wichmann-Hill algorithm can be considered special cases of what’s called the linear congruential (LC) algorithm. Expressed as an equation, LC is:
/// </summary>
/// 
/// 
/// LinearConRng lincon = new LinearConRng(0);
/// for (int i = 0; i < 1000; ++i) {
///   double x = lincon.Next();
///   int ri = (int)((hi - lo) * x + lo); // 0 to 9
///   ++counts[ri];
/// }
[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public sealed class LinearConRng
{
    private const long a = 25214903917;
    private const long c = 11;
    private long seed;
    public LinearConRng(long seed)
    {
        if (seed < 0)
            throw new Exception("Bad seed");
        this.seed = seed;
    }
    private int next(int bits) // helper
    {
        seed = (seed * a + c) & ((1L << 48) - 1);
        return (int)(seed >> (48 - bits));
    }
    public double Next()
    {
        return (((long)next(26) << 27) + next(27)) / (double)(1L << 53);
    }
}
