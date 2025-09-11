using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using BenchmarkDotNet.Attributes;

namespace Hemy.Benchmark;


[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[StructLayout(LayoutKind.Sequential)]
internal static unsafe partial class TimeImplement
{
    [SkipLocalsInit]
    internal static ulong Clock => GetTick();

    [SkipLocalsInit]
    internal static ulong TimeStamp
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get
        {
            _ = QueryPerformanceCounter(out ulong count);
            return count;
        }
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal static ulong GetTick()
    {
        _ = QueryPerformanceCounter(out ulong count);
        return count;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static ulong GetFrequency()
    {
        _ = QueryPerformanceFrequency(out ulong count);
        return count;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    internal static bool IsHighTimer()
    {
        int isHight = QueryPerformanceFrequency(out ulong count);
        return isHight != 0;
    }

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int QueryPerformanceCounter(out ulong lpPerformanceCount);

    [SkipLocalsInit]
    [SuppressGCTransition]
    [SuppressUnmanagedCodeSecurity]
    [LibraryImport(Kernel, SetLastError = false)]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial int QueryPerformanceFrequency(out ulong frequency);

    internal const string Kernel = "kernel32";
}


public class TestGetterVsFunctionCall
{
    [Params(100_000, 1_000_000, 10_000_000)]
    public int N;

    // [GlobalSetup]
    // public void Setup()
    // {
    // }

    [Benchmark]
    public unsafe void Getter()
    {
        ulong elpased = 0L;
        ulong previous = 0L;
        for (int i = 0; i < N; i++)
        {
            elpased = TimeImplement.TimeStamp;
            previous -= elpased;

        }

        // Console.WriteLine(elpased );
    }

    [Benchmark]
    public unsafe void FunctionCall()
    {
        ulong elpased = 0L;
        ulong previous = 0L;
        for (int i = 0; i < N; i++)
        {
            elpased = TimeImplement.GetTick();
            previous -= elpased;

        }

    }
    
    [Benchmark]
    public unsafe void Lambda()
    {
        ulong elpased = 0L;
        ulong previous =0L;
        for ( int i = 0 ; i < N ; i++)
        {
            elpased = TimeImplement.Clock;
            previous -= elpased;

        }
   
    }

}
/*


BenchmarkDotNet v0.15.2, Windows 11 (10.0.26100.4946/24H2/2024Update/HudsonValley)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2


| Method       | N          | Mean          | Error       | StdDev      |
|------------- |----------- |--------------:|------------:|------------:|
| Getter       | 100000     |      2.132 ms |   0.0426 ms |   0.0611 ms |
| FunctionCall | 100000     |      2.084 ms |   0.0326 ms |   0.0305 ms |
| Lambda       | 100000     |      2.233 ms |   0.0442 ms |   0.1041 ms |
| Getter       | 1000000    |     22.246 ms |   0.4445 ms |   0.7177 ms |
| FunctionCall | 1000000    |     22.058 ms |   0.4384 ms |   0.9895 ms |
| Lambda       | 1000000    |     21.911 ms |   0.4322 ms |   0.9487 ms |
| Getter       | 1000000000 | 20,902.312 ms | 244.9052 ms | 204.5069 ms |
| FunctionCall | 1000000000 | 21,465.287 ms | 342.1032 ms | 320.0035 ms |
| Lambda       | 1000000000 | 21,905.347 ms | 434.3399 ms | 517.0508 ms |


BenchmarkDotNet v0.15.2, Windows 11 (10.0.26100.4946/24H2/2024Update/HudsonValley)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2


| Method       | N         | Mean         | Error      | StdDev     |
|------------- |---------- |-------------:|-----------:|-----------:|
| Getter       | 100000    |     2.184 ms |  0.0424 ms |  0.0376 ms |
| FunctionCall | 100000    |     2.179 ms |  0.0426 ms |  0.0746 ms |
| Lambda       | 100000    |     2.192 ms |  0.0426 ms |  0.0860 ms |
| Getter       | 1000000   |    22.195 ms |  0.4438 ms |  0.5450 ms |
| FunctionCall | 1000000   |    21.501 ms |  0.4079 ms |  0.5583 ms |
| Lambda       | 1000000   |    21.368 ms |  0.3593 ms |  0.3361 ms |
| Getter       | 100000000 | 2,130.986 ms | 28.6837 ms | 25.4273 ms |
| FunctionCall | 100000000 | 2,110.967 ms |  6.9680 ms |  6.5179 ms |
| Lambda       | 100000000 | 2,099.136 ms |  8.6946 ms |  7.7076 ms |


BenchmarkDotNet v0.15.2, Windows 11 (10.0.26100.4946/24H2/2024Update/HudsonValley)
Unknown processor
.NET SDK 9.0.301
  [Host]     : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.6 (9.0.625.26613), X64 RyuJIT AVX2


| Method       | N        | Mean       | Error     | StdDev     | Median     |
|------------- |--------- |-----------:|----------:|-----------:|-----------:|
| Getter       | 100000   |   2.175 ms | 0.0429 ms |  0.0629 ms |   2.157 ms |
| FunctionCall | 100000   |   2.462 ms | 0.0806 ms |  0.2377 ms |   2.419 ms |
| Lambda       | 100000   |   2.114 ms | 0.0368 ms |  0.0326 ms |   2.109 ms |
| Getter       | 1000000  |  22.122 ms | 0.4320 ms |  0.7218 ms |  22.031 ms |
| FunctionCall | 1000000  |  22.727 ms | 0.4768 ms |  1.3758 ms |  22.296 ms |
| Lambda       | 1000000  |  21.653 ms | 0.4226 ms |  0.7061 ms |  21.466 ms |
| Getter       | 10000000 | 228.656 ms | 6.1843 ms | 18.2346 ms | 223.277 ms |
| FunctionCall | 10000000 | 216.812 ms | 4.2387 ms |  6.3442 ms | 216.187 ms |
| Lambda       | 10000000 | 214.561 ms | 4.2351 ms |  5.6537 ms | 214.018 ms |

*/