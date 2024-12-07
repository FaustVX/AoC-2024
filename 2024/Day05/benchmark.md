```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2314)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2


```
| Method  | Mean        | Error     | StdDev    | Allocated |
|-------- |------------:|----------:|----------:|----------:|
| PartOne |    935.4 μs |  13.75 μs |  17.88 μs |      25 B |
| PartTwo | 10,544.5 μs | 133.20 μs | 118.08 μs |      36 B |
