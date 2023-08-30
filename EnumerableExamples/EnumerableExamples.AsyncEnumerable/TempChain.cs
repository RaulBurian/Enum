namespace EnumerableExamples.AsyncEnumerable;

public static class TempChain
{
    public static async IAsyncEnumerable<Person> PrintPeople(this IAsyncEnumerable<Person> people)
    {
        await foreach (var person in people)
        {
            Console.WriteLine(person);

            yield return person;
        }
    }
}
