``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.521)
11th Gen Intel Core i7-1185G7 3.00GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=7.0.100-preview.6.22352.1
  [Host]     : .NET Core 3.1.29 (CoreCLR 4.700.22.41602, CoreFX 4.700.22.41702), X64 RyuJIT AVX2
  DefaultJob : .NET Core 3.1.29 (CoreCLR 4.700.22.41602, CoreFX 4.700.22.41702), X64 RyuJIT AVX2


```
|                    Method |     Mean |    Error |    StdDev |   Median | Ratio | RatioSD |      Gen0 |      Gen1 |     Gen2 | Allocated | Alloc Ratio |
|-------------------------- |---------:|---------:|----------:|---------:|------:|--------:|----------:|----------:|---------:|----------:|------------:|
|      Deserialize_ToJArray | 91.70 ms | 8.013 ms | 23.627 ms | 86.64 ms |  1.00 |    0.00 | 3750.0000 | 1500.0000 | 500.0000 |  20.52 MB |        1.00 |
| Deserialize_ConcreteClass | 23.96 ms | 1.898 ms |  5.536 ms | 21.06 ms |  0.27 |    0.07 |  625.0000 |  312.5000 |        - |   3.87 MB |        0.19 |
