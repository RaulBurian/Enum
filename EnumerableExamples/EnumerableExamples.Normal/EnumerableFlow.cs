using System;
using System.Collections.Generic;
using System.Linq;
using EnumerableExamples.Normal.Stuff;

namespace EnumerableExamples.Normal;

public static class EnumerableFlow
{
    public static void EnumerableFlowExample()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        // var numbers = Enumerable.Range(1, 10);

        numbers.PassLog().Where(num =>
        {
            Console.WriteLine($"Where {num}");

            return num % 2 is 0;
        }).Select(num =>
        {
            Console.WriteLine($"Select {num}");

            return new Dummy(num);
        }).ForceEnum();
    }
}

public record Dummy(int Number);
