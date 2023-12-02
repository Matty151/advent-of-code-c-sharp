namespace AdventOfCode.Y2023.Day2;

public class Part1
{
    public static void Run()
    {
        string[] lines = TextFileReader.ReadLines(2, 1, "puzzle");

        Bag bag = new(new Dictionary<Color, int> {
            { Color.Red, 12 },
            { Color.Green, 13 },
            { Color.Blue, 14 },
        });

        List<Game> games = lines.Select(Game.CreateFromString).ToList();

        List<Game> possibleGames = games.Where(game => game.IsPossible(bag)).ToList();

        Console.WriteLine(possibleGames.Select(game => game.Id).Sum());
    }
}
