```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.4460/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 9.0.100
  [Host]   : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
  ShortRun : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
| Method  | Mean      | Error    | StdDev   | Allocated |
|-------- |----------:|---------:|---------:|----------:|
| PartOne | 290.28 μs | 22.28 μs | 1.221 μs |      24 B |
| PartTwo |  92.74 μs | 20.66 μs | 1.132 μs |      24 B |
