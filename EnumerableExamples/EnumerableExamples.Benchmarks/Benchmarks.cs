using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using EnumerableExamples.Benchmarks.Stuff;

namespace EnumerableExamples.Benchmarks;

[MemoryDiagnoser]
public class Benchmarks
{
    private IEnumerable<int> _numbers = null!;

    [Params(10000, 100000, 1000000)]
    public int ItemCount { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _numbers = GetNumbersBetween(1, ItemCount);
    }

    [Benchmark]
    public void SmallOpsMultipleEnumeration()
    {
        var multiplesOfThree = _numbers.Where(number => number % 3 == 0).Select(multiple => new NumberRec("Fizz", multiple));

        var multiplesOfFifteen = multiplesOfThree.Where(rec => rec.Number % 5 == 0).Select(rec => rec with { Name = "FizzBuzz" });

        multiplesOfThree.ForceEnum();
        multiplesOfFifteen.ForceEnum();
    }

    [Benchmark]
    public void SmallOpsArray()
    {
        var multiplesOfThree = _numbers.Where(number => number % 3 == 0).Select(multiple => new NumberRec("Fizz", multiple)).ToArray();

        var multiplesOfFifteen = multiplesOfThree.Where(rec => rec.Number % 5 == 0).Select(rec => rec with { Name = "FizzBuzz" });

        multiplesOfThree.ForceEnum();
        multiplesOfFifteen.ForceEnum();
    }

    [Benchmark]
    public void ComplexOpsMultipleEnumeration()
    {
        var primeNumbers = _numbers.Where(number => number.IsPrime());

        var xNumbers = primeNumbers.Where(number => number % 3 == 1);

        var yNumbers = primeNumbers.Where(number => number % 5 == 1);

        primeNumbers.ForceEnum();
        xNumbers.ForceEnum();
        yNumbers.ForceEnum();
    }

    [Benchmark]
    public void ComplexOpsArray()
    {
        var primeNumbers = _numbers.Where(number => number.IsPrime()).ToArray();

        var xNumbers = primeNumbers.Where(number => number % 3 == 1);

        var yNumbers = primeNumbers.Where(number => number % 5 == 1);

        primeNumbers.ForceEnum();
        xNumbers.ForceEnum();
        yNumbers.ForceEnum();
    }

    private static IEnumerable<int> GetNumbersBetween(int start, int end)
    {
        foreach (var number in start..end)
        {
            yield return number;
        }
    }
}

public record NumberRec(string Name, int Number);
