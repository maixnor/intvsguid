using System;
using System.Diagnostics;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace JoinPerformanceTests;

[MemoryDiagnoser]
public class Werkbank
{
    private readonly GuidContext _guids;
    private readonly IntContext _ints;

    public Werkbank()
    {
        _guids = new GuidContext();
        _ints = new IntContext();
        _guids.Database.EnsureDeleted();
        _guids.Database.EnsureCreated();
        _ints.Database.EnsureDeleted();
        _ints.Database.EnsureCreated();
        _guids.Seed();
        _ints.Seed();
    }

    [Benchmark]
    public void JoinGuids()
    {
        var people = _guids.People.Take(100).ToList();
        foreach (var person in people)
        {
            _ = person.Emails.ToList();
        }
    }

    [Benchmark]
    public void JoinInts()
    {
        var people = _ints.People.Take(100).ToList();
        foreach (var person in people)
        {
            _ = person.Emails.ToList();
        }
    }
}