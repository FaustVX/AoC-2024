```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2314)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2


```
| Method  | Mean     | Error   | StdDev  | Allocated |
|-------- |---------:|--------:|--------:|----------:|
| PartOne | 103.5 μs | 0.69 μs | 0.64 μs |      24 B |
| PartTwo | 129.7 μs | 0.76 μs | 0.71 μs |      24 B |
