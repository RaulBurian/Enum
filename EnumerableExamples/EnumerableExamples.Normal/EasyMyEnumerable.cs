using System.Collections.Generic;
using EnumerableExamples.Normal.Stuff;

namespace EnumerableExamples.Normal;

public static class EasyMyEnumerable
{
    public static IEnumerable<SieveEntry> GetSieveUpTo(int limit)
    {
        foreach (var number in ..limit)
        {
            if (number.IsPrime())
            {
                yield return new SieveEntry(number);
            }
        }
    }
}

public record SieveEntry(int Number);
