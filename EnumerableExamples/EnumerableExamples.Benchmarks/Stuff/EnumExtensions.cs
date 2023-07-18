using System.Collections.Generic;

namespace EnumerableExamples.Benchmarks.Stuff;

public static class EnumExtensions
{
    public static void ForceEnum<T>(this IEnumerable<T> self)
    {
        foreach (var _ in self)
        {
        }
    }
}
