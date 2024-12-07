```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2314)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2


```
| Method  | Mean       | Error    | StdDev   | Gen0   | Allocated |
|-------- |-----------:|---------:|---------:|-------:|----------:|
| PartOne |   837.4 μs |  3.44 μs |  2.88 μs | 1.9531 |  29.18 KB |
| PartTwo | 9,722.5 μs | 55.07 μs | 48.81 μs |      - |  29.19 KB |
