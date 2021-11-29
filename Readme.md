
# Welcome

###TL;DR 
Guids seem to be slightly better in SQLite,
but not a considerable chunk as one run even was
faster with guids than with ints.

### How to run 

1. Run on release mode 
2. Grab a coffee, it takes a bit
3. scroll up a bit to see the results

### Results

Here are my results on 3 separate runs:

BenchmarkDotNet=v0.13.1, OS=garuda
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.100
[Host]     : .NET 6.0.0 (6.0.21.56401), X64 RyuJIT
DefaultJob : .NET 6.0.0 (6.0.21.56401), X64 RyuJIT


|       Method |     Mean |    Error |   StdDev |    Gen 0 |   Gen 1 | Allocated |
|------------- |---------:|---------:|---------:|---------:|--------:|----------:|
| JoinAllGuids | 750.4 us | 13.96 us | 20.03 us | 683.5938 | 78.1250 |      4 MB |
|  JoinAllInts | 680.4 us | 12.85 us | 14.80 us | 666.0156 | 66.4063 |      4 MB |

|       Method |     Mean |    Error |   StdDev |    Gen 0 |   Gen 1 | Allocated |
|------------- |---------:|---------:|---------:|---------:|--------:|----------:|
| JoinAllGuids | 682.1 us | 10.94 us | 10.23 us | 590.8203 | 67.3828 |      4 MB |
|  JoinAllInts | 696.2 us | 13.89 us | 23.21 us | 674.8047 | 74.2188 |      4 MB |

|       Method |     Mean |    Error |   StdDev |    Gen 0 |   Gen 1 | Allocated |
|------------- |---------:|---------:|---------:|---------:|--------:|----------:|
| JoinAllGuids | 712.3 us | 13.76 us | 16.38 us | 663.0859 | 73.2422 |      4 MB |
|  JoinAllInts | 645.8 us | 12.84 us | 17.14 us | 635.7422 | 89.8438 |      4 MB |