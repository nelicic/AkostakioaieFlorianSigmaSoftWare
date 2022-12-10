``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19045.2251)
Unknown processor
.NET SDK=6.0.201
  [Host]     : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2


```
|    Method |   A |  B |     Mean |   Error |  StdDev |
|---------- |---- |--- |---------:|--------:|--------:|
| **Benchmark** | **100** | **10** | **123.6 ms** | **0.60 ms** | **0.56 ms** |
| **Benchmark** | **100** | **20** | **138.1 ms** | **1.85 ms** | **1.73 ms** |
| **Benchmark** | **200** | **10** | **219.3 ms** | **1.72 ms** | **1.61 ms** |
| **Benchmark** | **200** | **20** | **232.4 ms** | **0.85 ms** | **0.79 ms** |
