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

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

/// <summary>
/// The Lagged Fibonacci Algorithm
// The lagged Fibonacci algorithm, expressed as an equation, is: X(i) = X(i-7) + X(i-10) mod m
/// </summary>
[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public class LaggedFibRng
{
    private const int k = 10; // Largest magnitude"-index"
    private const int j = 7; // Other "-index"
    private const int m = 2147483647;  // 2^31 - 1 = maxint
    private List<int> vals = null!;
    private int seed;

    public LaggedFibRng(int seed)
    {
        vals = new List<int>();
        for (int i = 0; i < k + 1; ++i)
            vals.Add(seed);
        if (seed % 2 == 0) vals[0] = 11;
        // Burn some values away
        for (int ct = 0; ct < 1000; ++ct)
        {
            double dummy = this.Next();
        }
    }  // ctor
    public double Next()
    {
        // (a + b) mod n = [(a mod n) + (b mod n)] mod n
        int left = vals[0] % m;    // [x-big]
        int right = vals[k - j] % m; // [x-other]
        long sum = (long)left + (long)right;  // prevent overflow
        seed = (int)(sum % m);  // Because m is int, result has int range
        vals.Insert(k + 1, seed);  // Add new val at end
        vals.RemoveAt(0);  // Delete now irrelevant [0] val
        return (1.0 * seed) / m;
    }
}
