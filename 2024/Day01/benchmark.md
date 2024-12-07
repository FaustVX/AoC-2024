```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2314)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2


```
| Method  | Mean     | Error    | StdDev   | Allocated |
|-------- |---------:|---------:|---------:|----------:|
| PartOne | 63.23 μs | 0.588 μs | 0.459 μs |      24 B |
| PartTwo | 93.45 μs | 1.674 μs | 1.861 μs |      24 B |
