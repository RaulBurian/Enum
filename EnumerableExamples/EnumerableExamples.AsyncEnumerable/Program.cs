using EnumerableExamples.AsyncEnumerable;

await foreach (var person in FileReader.ReadPeople())
{
    if (person.Score < 7)
    {
        break;
    }

    Console.WriteLine(person);
}
