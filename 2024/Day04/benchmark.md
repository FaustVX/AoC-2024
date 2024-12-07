```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2314)
12th Gen Intel Core i7-12700H, 1 CPU, 20 logical and 14 physical cores
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.0 (9.0.24.52809), X64 RyuJIT AVX2


```
| Method  | Mean      | Error    | StdDev   | Allocated |
|-------- |----------:|---------:|---------:|----------:|
| PartOne | 289.86 μs | 2.836 μs | 2.514 μs |      24 B |
| PartTwo |  92.51 μs | 1.777 μs | 1.576 μs |      24 B |
