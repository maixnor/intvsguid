
# Welcome

### TL;DR 
Guids seem to be slightly slower in SQLite,
but not a considerable chunk as some runs even 
were faster with guids than with ints.

### Test Procedure

An empty sqlite database is created and filled with 10.000 emails which are 
assigned via n:m to 10.000 users.

The data access is done via EF Core.

For the benchmark the first 100 users are selected
and for each user all emails are loaded.

### How to run 

1. Run on release mode 
2. Grab a coffee, it takes a bit
3. scroll up a bit to see the results

### Conclusions

If every microsecond counts in your application you might want to have integers 
as your primary keys. For most applications however I would reason for guids as 
they can be created on the server without having to worry about duplicate keys
and this marginal loss in performance cannot outweigh the benefits of using guids.

### Results

For more elaborate metrics run the tests yourself and have 
a look the full statistics.

Here are my results on 4 separate runs: (lower = better)

```
BenchmarkDotNet=v0.13.1, OS=garuda
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET SDK=6.0.100
    [Host]     : .NET 6.0.0 (6.0.21.56401), X64 RyuJIT
    DefaultJob : .NET 6.0.0 (6.0.21.56401), X64 RyuJIT
```

| Method    |     Mean |    Error |   StdDev |    Gen 0 |   Gen 1 | Allocated |
|-----------|---------:|---------:|---------:|---------:|--------:|----------:|
| JoinGuids | 750.4 us | 13.96 us | 20.03 us | 683.5938 | 78.1250 |      4 MB |
| JoinInts  | 680.4 us | 12.85 us | 14.80 us | 666.0156 | 66.4063 |      4 MB |

| Method    |     Mean |    Error |   StdDev |    Gen 0 |   Gen 1 | Allocated |
|-----------|---------:|---------:|---------:|---------:|--------:|----------:|
| JoinGuids | 682.1 us | 10.94 us | 10.23 us | 590.8203 | 67.3828 |      4 MB |
| JoinInts  | 696.2 us | 13.89 us | 23.21 us | 674.8047 | 74.2188 |      4 MB |

| Method    |     Mean |    Error |   StdDev |    Gen 0 |   Gen 1 | Allocated |
|-----------|---------:|---------:|---------:|---------:|--------:|----------:|
| JoinGuids | 712.3 us | 13.76 us | 16.38 us | 663.0859 | 73.2422 |      4 MB |
| JoinInts  | 645.8 us | 12.84 us | 17.14 us | 635.7422 | 89.8438 |      4 MB |

| Method    |     Mean |    Error |   StdDev |    Gen 0 |   Gen 1 | Allocated |
|-----------|---------:|---------:|---------:|---------:|--------:|----------:|
| JoinGuids | 658.4 us | 12.91 us | 12.68 us | 646.4844 | 73.2422 |      4 MB |
| JoinInts  | 700.4 us | 15.41 us | 45.21 us | 689.4531 | 77.1484 |      4 MB |

### Nuget upgrade

By upgrading the EF Core version from 6.0.0 to 6.0.2 the runtimes went down 
considerably

|    Method |     Mean |    Error |   StdDev |    Gen 0 |   Gen 1 | Allocated |
|---------- |---------:|---------:|---------:|---------:|--------:|----------:|
| JoinGuids | 588.3 us | 11.65 us | 13.86 us | 606.4453 | 71.2891 |      4 MB |
|  JoinInts | 539.8 us | 10.79 us | 14.40 us | 563.4766 | 63.4766 |      3 MB |

|    Method |     Mean |    Error |   StdDev |    Gen 0 |   Gen 1 | Allocated |
|---------- |---------:|---------:|---------:|---------:|--------:|----------:|
| JoinGuids | 596.4 us | 11.90 us | 25.35 us | 591.7969 | 73.2422 |      4 MB |
|  JoinInts | 607.0 us |  9.41 us |  8.80 us | 626.9531 | 67.3828 |      4 MB |
