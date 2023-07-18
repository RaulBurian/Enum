using System;
using EnumerableExamples.Normal;

#region E
// ReSharper disable PossibleMultipleEnumeration
#endregion

// foreach (var sieveEntry in EasyMyEnumerable.GetSieveUpTo(20))
// {
//     Console.WriteLine(sieveEntry);
// }

// EnumerableFlow.EnumerableFlowExample();

string[] names = { "Mike", "Johnnatan", "Daniel", "Luke", "Freightman" };

var sampledNames = MultipleEnum.MultipleEnumFlow(names);

foreach (var sampledName in sampledNames)
{
    Console.WriteLine(sampledName);
}

foreach (var sampledName in sampledNames)
{
    Console.WriteLine(sampledName);
}

Console.WriteLine(MultipleEnum.NumberOfPasses);

var falsePosMultiple = MultipleEnum.FalsePosMultipleEnum();

foreach (var s in falsePosMultiple)
{
    Console.WriteLine(s);
}

foreach (var s in falsePosMultiple)
{
    Console.WriteLine(s);
}
