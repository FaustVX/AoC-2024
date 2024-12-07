```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2314)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
  ShortRun : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method  | Mean       | Error      | StdDev    | Gen0   | Allocated |
|-------- |-----------:|-----------:|----------:|-------:|----------:|
| PartOne |   837.3 μs |   108.9 μs |   5.97 μs | 1.9531 |  29.18 KB |
| PartTwo | 9,544.7 μs | 2,623.9 μs | 143.82 μs |      - |  29.19 KB |
