```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4460/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
  ShortRun : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method  | Mean     | Error     | StdDev   | Gen0   | Allocated |
|-------- |---------:|----------:|---------:|-------:|----------:|
| PartOne | 58.35 μs |  5.161 μs | 0.283 μs | 0.6104 |   7.86 KB |
| PartTwo | 97.52 μs | 31.667 μs | 1.736 μs | 0.6104 |   7.86 KB |
