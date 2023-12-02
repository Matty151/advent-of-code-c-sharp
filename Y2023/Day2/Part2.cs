namespace AdventOfCode.Y2023.Day2;

public class Part2
{
    public static void Run()
    {
        string[] lines = TextFileReader.ReadLines(2, 2, "puzzle");

        List<Game> games = lines.Select(Game.CreateFromString).ToList();

        int total = games
            .Select(
                game => game.GetMinimum().ToList()
                    .Select(minimum => minimum.Value)
                    .Aggregate((a, b) => a * b)
            )
            .Sum();

        Console.WriteLine(total);
    }
}
