``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19045.2251)
Unknown processor
.NET SDK=6.0.201
  [Host]     : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.9 (6.0.922.41905), X64 RyuJIT AVX2


```
|          Method |  Size |          Mean |         Error |        StdDev |        Median |       Gen0 |  Allocated |
|---------------- |------ |--------------:|--------------:|--------------:|--------------:|-----------:|-----------:|
|   **QuickSortLeft** |   **100** |      **70.67 μs** |      **1.407 μs** |      **3.850 μs** |      **70.33 μs** |     **6.1035** |    **25608 B** |
|  QuickSortRight |   100 |      73.30 μs |      1.458 μs |      4.206 μs |      71.75 μs |     6.1035 |    25607 B |
| QuickSortRandom |   100 |   1,395.83 μs |     31.136 μs |     91.806 μs |   1,389.73 μs |   134.7656 |   564658 B |
|   **QuickSortLeft** |  **1000** |   **4,903.28 μs** |    **109.819 μs** |    **323.802 μs** |   **4,866.95 μs** |    **54.6875** |   **258391 B** |
|  QuickSortRight |  1000 |   5,379.17 μs |    130.046 μs |    377.288 μs |   5,367.45 μs |    54.6875 |   258410 B |
| QuickSortRandom |  1000 | 626,202.63 μs | 21,190.844 μs | 62,149.077 μs | 620,434.00 μs | 13000.0000 | 57637176 B |
|   **QuickSortLeft** | **10000** |            **NA** |            **NA** |            **NA** |            **NA** |          **-** |          **-** |
|  QuickSortRight | 10000 |            NA |            NA |            NA |            NA |          - |          - |
| QuickSortRandom | 10000 |            NA |            NA |            NA |            NA |          - |          - |

Benchmarks with issues:
  BenchMark.QuickSortLeft: DefaultJob [Size=10000]
  BenchMark.QuickSortRight: DefaultJob [Size=10000]
  BenchMark.QuickSortRandom: DefaultJob [Size=10000]
