``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.521)
11th Gen Intel Core i7-1185G7 3.00GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100-preview.6.22352.1
  [Host]        : .NET Core 3.1.29 (CoreCLR 4.700.22.41602, CoreFX 4.700.22.41702), X64 RyuJIT AVX2
  .NET 6.0      : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2
  .NET 7.0      : .NET 7.0.0 (7.0.22.32404), X64 RyuJIT AVX2
  .NET Core 3.1 : .NET Core 3.1.29 (CoreCLR 4.700.22.41602, CoreFX 4.700.22.41702), X64 RyuJIT AVX2


```
|    Method |                  Job |              Runtime |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |
|---------- |--------------------- |--------------------- |----------:|----------:|----------:|----------:|------:|--------:|
| NonSealed |             .NET 6.0 |             .NET 6.0 | 1.2182 ns | 0.0494 ns | 0.0485 ns | 1.2268 ns |  1.00 |    0.00 |
|    Sealed |             .NET 6.0 |             .NET 6.0 | 0.0134 ns | 0.0166 ns | 0.0185 ns | 0.0000 ns |  0.01 |    0.02 |
|           |                      |                      |           |           |           |           |       |         |
| NonSealed |             .NET 7.0 |             .NET 7.0 | 1.2483 ns | 0.0505 ns | 0.0582 ns | 1.2543 ns |  1.00 |    0.00 |
|    Sealed |             .NET 7.0 |             .NET 7.0 | 0.0306 ns | 0.0236 ns | 0.0221 ns | 0.0350 ns |  0.02 |    0.02 |
|           |                      |                      |           |           |           |           |       |         |
| NonSealed |        .NET Core 3.1 |        .NET Core 3.1 | 1.1785 ns | 0.0439 ns | 0.0571 ns | 1.1946 ns |  1.00 |    0.00 |
|    Sealed |        .NET Core 3.1 |        .NET Core 3.1 | 0.3344 ns | 0.1146 ns | 0.3287 ns | 0.2282 ns |  0.05 |    0.04 |
|           |                      |                      |           |           |           |           |       |         |
| NonSealed | .NET Framework 4.7.1 | .NET Framework 4.7.1 |        NA |        NA |        NA |        NA |     ? |       ? |
|    Sealed | .NET Framework 4.7.1 | .NET Framework 4.7.1 |        NA |        NA |        NA |        NA |     ? |       ? |

Benchmarks with issues:
  SealedTest.NonSealed: .NET Framework 4.7.1(Runtime=.NET Framework 4.7.1)
  SealedTest.Sealed: .NET Framework 4.7.1(Runtime=.NET Framework 4.7.1)
