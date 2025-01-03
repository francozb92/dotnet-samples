### dotnet-samples

## dotnet runtime

# feature switches

- Base Feature Switches Example

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

- API Feature Switch Example

This example using feature switches in dotnet 9 effectively demonstrates a different way of versioning an API (Obsolete, Deprecated, Outdated, NotRelevant, etc.) when publishing to different consumers and their requirements where an exposed endpoint does not need to be available thus reducing application size and conformance.

**Note that feature switches are only available with minimal APIs and not for controller based APIs**

**Software teams benefit tremendously when adopting minimal APIs due to modern ways of architecting solutions (microservices architecture) and their ability to adapt to change in high paced agile environments**

The following table demonstrates the resulting API when using feature switches for OnlyCompleted items and OnlyTodo items

* OnlyCompleted

| HTTP Verb  | OnlyCompleted         |
| ---------- | --------------------- |
| GET        | "/todoitems/complete" |

* OnlyTodo

| HTTP Verb  | OnlyTodo          |
| ---------- | ----------------- |
| GET        | "/todoitems"      |
| GET        | "/todoitems/{id}" |
| POST       | "/todoitems"      |
| PUT        | "/todoitems/{id}" |
| DELETE     | "/todoitems/{id}" |
