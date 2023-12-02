namespace AdventOfCode.Y2023.Day2;

public class Part1
{
    public static void run()
    {
        string[] lines = TextFileReader.ReadLines(2, 1, "puzzle");

        Bag bag = new(new Dictionary<Color, int> {
            { Color.Red, 12 },
            { Color.Green, 13 },
            { Color.Blue, 14 },
        });

        List<Game> games = lines.Select(line => Game.CreateFromString(bag, line)).ToList();

        List<Game> possibleGames = games.Where(game => game.IsPossible()).ToList();

        Console.WriteLine(possibleGames.Select(game => game.Id).Sum());
    }
}
