// add package
// dotnet add package BenchmarkDotNet --version 0.15.2

namespace Hemy.Benchmark;


using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

public static class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<  TestGetterVsFunctionCall  >(
            //  ManualConfig
            //         .Create(DefaultConfig.Instance)
            //         .WithOptions(ConfigOptions.DisableOptimizationsValidator)
        );
    }
}
