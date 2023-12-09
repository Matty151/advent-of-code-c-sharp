namespace AdventOfCode.Y2023.Day4;

public class Part2
{
    public static void Run()
    {
        string[] lines = TextFileReader.ReadLines(4, 1, "test");

        Card[] cards = lines
            .Select(Card.CreateFromString)
            .ToArray();
    }
}
