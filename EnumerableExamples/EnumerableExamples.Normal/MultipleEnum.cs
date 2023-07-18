using System;
using System.Collections.Generic;
using System.Linq;

# region  E
// ReSharper disable PossibleMultipleEnumeration
#endregion

namespace EnumerableExamples.Normal;

public static class MultipleEnum
{
    public static int NumberOfPasses;

    public static IEnumerable<SampleObj> MultipleEnumFlow(IEnumerable<string> names)
    {
        var shortNames = names.Where(name =>
        {
            NumberOfPasses++;

            return name.Length < 5;
        });

        return names.Where(name =>
        {
            NumberOfPasses++;

            return !shortNames.Contains(name);
        }).Select(name => new SampleObj(Random.Shared.Next(), name));
    }

    public static IEnumerable<string> FalsePosMultipleEnum()
    {
        return new[] { "a", "b", "c", "d" };
    }
}

public record SampleObj(int Id, string Name);
