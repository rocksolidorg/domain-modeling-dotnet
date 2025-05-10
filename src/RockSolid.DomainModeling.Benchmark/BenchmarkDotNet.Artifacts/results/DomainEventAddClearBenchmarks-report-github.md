```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.5189/23H2/2023Update/SunValley3)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 9.0.203
  [Host]     : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.4 (9.0.425.16305), X64 RyuJIT AVX2


```
| Method                 | EventCount | Mean         | Error       | StdDev      | Gen0    | Gen1    | Gen2    | Allocated |
|----------------------- |----------- |-------------:|------------:|------------:|--------:|--------:|--------:|----------:|
| **AddAndClear_DirectList** | **10**         |     **207.7 ns** |     **2.26 ns** |     **1.89 ns** |  **0.0904** |       **-** |       **-** |     **568 B** |
| **AddAndClear_DirectList** | **100**        |   **1,110.1 ns** |    **21.62 ns** |    **28.12 ns** |  **0.7305** |  **0.0076** |       **-** |    **4592 B** |
| **AddAndClear_DirectList** | **1000**       |   **9,845.8 ns** |   **187.65 ns** |   **365.99 ns** |  **6.4697** |  **0.4578** |       **-** |   **40600 B** |
| **AddAndClear_DirectList** | **10000**      | **208,596.6 ns** | **2,207.99 ns** | **1,957.33 ns** | **83.0078** | **82.7637** | **41.5039** |  **502470 B** |
