using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using EnumerableExamples.Benchmarks.Stuff;

namespace EnumerableExamples.Benchmarks;

[MemoryDiagnoser]
public class Benchmarks2
{
    private List<int> _numbers = null!;

    private Random _random = new Random(999);

    [Params(10000, 100000, 1000000)]
    public int ItemCount { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _numbers = Enumerable.Range(1, ItemCount).Select(_ => _random.Next()).ToList();
    }

    [Benchmark]
    public void SortEnum()
    {
        _numbers.OrderBy(x=>x).ForceEnum();
    }

    [Benchmark]
    public void SortList()
    {
        _numbers.Sort();

        _numbers.ForceEnum();
    }
}
