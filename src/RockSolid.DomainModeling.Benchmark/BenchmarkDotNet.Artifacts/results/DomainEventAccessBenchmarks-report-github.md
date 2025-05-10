```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.5189/23H2/2023Update/SunValley3)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.203
  [Host]     : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2


```
| Method           | Mean      | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|----------------- |----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| ReturnDirectList | 0.7190 ns | 0.0390 ns | 0.0365 ns |  1.00 |    0.07 |      - |         - |          NA |
| ReturnAsReadOnly | 4.7129 ns | 0.1447 ns | 0.1354 ns |  6.57 |    0.36 | 0.0038 |      24 B |          NA |
