``` ini

BenchmarkDotNet=v0.13.1, OS=garuda 
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.100
  [Host]     : .NET 6.0.0 (6.0.21.56401), X64 RyuJIT
  DefaultJob : .NET 6.0.0 (6.0.21.56401), X64 RyuJIT


```
|       Method |     Mean |    Error |   StdDev |    Gen 0 |   Gen 1 | Allocated |
|------------- |---------:|---------:|---------:|---------:|--------:|----------:|
| JoinAllGuids | 712.3 μs | 13.76 μs | 16.38 μs | 663.0859 | 73.2422 |      4 MB |
|  JoinAllInts | 645.8 μs | 12.84 μs | 17.14 μs | 635.7422 | 89.8438 |      4 MB |
