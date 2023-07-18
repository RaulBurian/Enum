using System;
using System.Collections.Generic;

namespace EnumerableExamples.Normal.Stuff;

public static class EnumExtensions
{
    public static IEnumerable<T> PassLog<T>(this IEnumerable<T> self)
    {
        foreach (var item in self)
        {
            Console.WriteLine($"PassLog {item}");

            yield return item;
        }
    }

    public static void ForceEnum<T>(this IEnumerable<T> self)
    {
        foreach (var _ in self)
        {
        }
    }
}
