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
/// The Wichmann-Hill Algorithm The Wichmann-Hill algorithm dates from 1982. The idea of Wichmann-Hill is to generate three preliminary results and then combine those results into a single, final result. The code that implements Wichmann-Hill is presented in Figure 3. The demo code is based on the paper, “Algorithm AS 183: An Efficient and Portable Pseudo-­Random Number Generator,” by B. A. Wichmann and I. D. Hill.
/// </summary>
/// <example> 
/// WichmannRng wich = new WichmannRng(1);
/// for (int i = 0; i < 1000; ++i) {
///   double x = wich.Next();
///   int ri = (int)((hi - lo) * x + lo); // 0 to 9
///   ++counts[ri];
/// }
/// </example>
[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
public class WichmannRng
{
    int s1;
    int s2;
    int s3;

    public WichmannRng(int seed)
    {
        if (seed <= 0 || seed > 30000)
            throw new Exception("Bad seed");
        s1 = seed;
        s2 = seed + 1;
        s3 = seed + 2;
    }

    public double Next()
    {
        s1 = 171 * (s1 % 177) - 2 * (s1 / 177);
        if (s1 < 0) { s1 += 30269; }
        s2 = 172 * (s2 % 176) - 35 * (s2 / 176);
        if (s2 < 0) { s2 += 30307; }
        s3 = 170 * (s3 % 178) - 63 * (s3 / 178);
        if (s3 < 0) { s3 += 30323; }
        double r = (s1 * 1.0) / 30269 + (s2 * 1.0) / 30307 + (s3 * 1.0) / 30323;
        return r - Math.Truncate(r);  // orig uses % 1.0
    }
}
