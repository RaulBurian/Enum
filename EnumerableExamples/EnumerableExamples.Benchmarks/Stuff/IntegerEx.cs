using System;

namespace EnumerableExamples.Benchmarks.Stuff;

public static class IntegerEx
{
    public static bool IsPrime(this int number)
    {
        switch (number)
        {
            case <= 1:
                return false;
            case 2:
                return true;
        }

        if (number % 2 == 0)
        {
            return false;
        }

        var boundary = (int)Math.Floor(Math.Sqrt(number));

        for (var i = 3; i <= boundary; i += 2)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
