using System;
using System.Diagnostics;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using JoinPerformanceTests;

BenchmarkRunner.Run<Werkbank>();

namespace JoinPerformanceTests
{
    [MemoryDiagnoser]
    public class Werkbank
    {
        private readonly GuidContext guids;
        private readonly IntContext ints;

        public Werkbank()
        {
            guids = new GuidContext();
            ints = new IntContext();
            guids.Database.EnsureDeleted();
            guids.Database.EnsureCreated();
            ints.Database.EnsureDeleted();
            ints.Database.EnsureCreated();
            guids.Seed();
            ints.Seed();
        }

        [Benchmark]
        public void JoinAllGuids()
        {
            var stopwatch = Stopwatch.StartNew();
            
            var people = guids.People.Take(100).ToList();
            foreach (var person in people)
            {
                person.Emails.ToList();
            }

            Console.WriteLine(stopwatch.Elapsed.Milliseconds);
        }

        [Benchmark]
        public void JoinAllInts()
        {
            var stopwatch = Stopwatch.StartNew();

            var people = ints.People.Take(100).ToList();
            foreach (var person in people)
            {
                person.Emails.ToList();
            }
            
            Console.WriteLine(stopwatch.Elapsed.Milliseconds);
        }
    }
}