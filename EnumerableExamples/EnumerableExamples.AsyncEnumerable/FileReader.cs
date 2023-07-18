#region E

// ReSharper disable ConvertTypeCheckPatternToNullCheck

#endregion

namespace EnumerableExamples.AsyncEnumerable;

public static class FileReader
{
    public static async IAsyncEnumerable<Person> ReadPeople()
    {
        var fileStream = File.OpenRead("Records.txt");
        var reader = new StreamReader(fileStream);

        while (await reader.ReadLineAsync() is string line)
        {
            yield return ProcessLine(line);
        }
    }

    private static Person ProcessLine(string line)
    {
        var span = line.AsSpan();

        var sectionSeparatorIndex = span.IndexOf(';');

        return new Person(span[..sectionSeparatorIndex].ToString(), int.Parse(span[(sectionSeparatorIndex + 1)..]));
    }
}

public record Person(string Name, int Score);
