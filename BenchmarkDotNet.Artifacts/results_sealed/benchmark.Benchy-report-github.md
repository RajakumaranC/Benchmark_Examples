``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.521)
11th Gen Intel Core i7-1185G7 3.00GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100-preview.6.22352.1
  [Host]        : .NET Core 3.1.29 (CoreCLR 4.700.22.41602, CoreFX 4.700.22.41702), X64 RyuJIT AVX2
  .NET 6.0      : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2
  .NET Core 3.1 : .NET Core 3.1.29 (CoreCLR 4.700.22.41602, CoreFX 4.700.22.41702), X64 RyuJIT AVX2


```
|    Method |           Job |       Runtime |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |
|---------- |-------------- |-------------- |----------:|----------:|----------:|----------:|------:|--------:|
| NonSealed |      .NET 6.0 |      .NET 6.0 | 1.4345 ns | 0.0509 ns | 0.0545 ns | 1.4413 ns |  1.00 |    0.00 |
|    Sealed |      .NET 6.0 |      .NET 6.0 | 0.0166 ns | 0.0168 ns | 0.0157 ns | 0.0134 ns |  0.01 |    0.01 |
|           |               |               |           |           |           |           |       |         |
| NonSealed | .NET Core 3.1 | .NET Core 3.1 | 1.2202 ns | 0.0323 ns | 0.0302 ns | 1.2236 ns | 1.000 |    0.00 |
|    Sealed | .NET Core 3.1 | .NET Core 3.1 | 0.0125 ns | 0.0146 ns | 0.0185 ns | 0.0000 ns | 0.009 |    0.02 |
