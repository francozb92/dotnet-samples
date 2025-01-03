### dotnet-samples

## dotnet runtime

# feature switches

- Running and testing feature switches with benchmarking capabilities using BenchmarkDotNet

* Results

```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19042.1348/20H2/October2020Update)
Intel Core i7-2620M CPU 2.70GHz (Sandy Bridge), 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.101
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX


```
| Method                    | IsSupported | Mean            | Error           | StdDev          | Median          | Allocated |
|-------------------------- |------------ |----------------:|----------------:|----------------:|----------------:|----------:|
| **FeatureSwitches_Benchmark** | **False**       |       **0.7187 ns** |       **0.1819 ns** |       **0.5040 ns** |       **0.9856 ns** |         **-** |
| **FeatureSwitches_Benchmark** | **True**        | **746,077.2467 ns** | **198,860.3743 ns** | **537,630.6247 ns** | **589,153.7598 ns** |         **-** |

- We can conclude there is a significant percentage difference between both benchmarks