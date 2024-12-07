```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2314)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2


```
| Method  | Mean     | Error    | StdDev   | Gen0   | Allocated |
|-------- |---------:|---------:|---------:|-------:|----------:|
| PartOne | 59.97 μs | 0.895 μs | 0.793 μs | 0.6104 |   7.86 KB |
| PartTwo | 86.44 μs | 0.604 μs | 0.565 μs | 0.6104 |   7.86 KB |
