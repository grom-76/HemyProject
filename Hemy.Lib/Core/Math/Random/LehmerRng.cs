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
/// The Lehmer Algorithm
/// The simplest reasonable random number generation technique is the Lehmer algorithm. (I use the term “random number generation” rather than the more accurate “pseudo-random number generation” for simplicity.) Expressed symbolically, the Lehmer algorithm is:
/// </summary>
/// <example> 
/// int hi = 10;
/// int lo = 0;
/// int[] counts = new int[10];
/// LehmerRng lehmer = new LehmerRng(1);
/// for (int i = 0; i < 1000; ++i) {
///   double x = lehmer.Next();
///   int ri = (int)((hi - lo) * x + lo); // 0 to 9
///   ++counts[ri];
/// }
/// </example>
[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public class LehmerRng
{
    private const int a = 16807;
    private const int m = 2147483647;
    private const int q = 127773;
    private const int r = 2836;
    private int seed;
    public LehmerRng(int seed)
    {
        if (seed <= 0 || seed == int.MaxValue)
            throw new Exception("Bad seed");
        this.seed = seed;
    }
    public double Next()
    {
        int hi = seed / q;
        int lo = seed % q;
        seed = (a * lo) - (r * hi);
        if (seed <= 0)
            seed = seed + m;
        return (seed * 1.0) / m;
    }
}
