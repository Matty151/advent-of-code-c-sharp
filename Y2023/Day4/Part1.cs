namespace AdventOfCode.Y2023.Day4;

public class Part1
{
    public static void Run()
    {
        string[] lines = TextFileReader.ReadLines(4, 1, "puzzle");

        double total = lines
            .Select(Card.CreateFromString)
            .Select(card => card.Points)
            .Sum();

        Console.WriteLine(total);
    }
}
