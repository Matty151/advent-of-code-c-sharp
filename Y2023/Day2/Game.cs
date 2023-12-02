using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.Day2;

public class Game
{
    public Bag Bag { get; }

    public int Id { get; }

    public List<Round> Rounds { get; }

    public Game(Bag bag, int id, List<Round> rounds)
    {
        Bag = bag;
        Id = id;
        Rounds = rounds;
    }

    public static Game CreateFromString(Bag bag, string input)
    {
        Regex gameRegex = new(@"^Game (?<id>\d+):");

        int gameId = int.Parse(gameRegex.Match(input).Groups["id"].Value);

        string[] cubeSubsets = gameRegex.Replace(input, "")
            .Split(";")
            .Select(s => s.Trim())
            .ToArray();

        List<Round> rounds = new();

        foreach (string set in cubeSubsets) {
            List<Cube> curRoundCubes = new();

            foreach (string cubeString in set.Split(",").Select(s => s.Trim())) {
                Match cubeData = Regex.Match(cubeString, @"(?<quantity>^\d+) (?<color>\w+$)");

                int quantity = int.Parse(cubeData.Groups["quantity"].Value);
                Enum.TryParse(cubeData.Groups["color"].Value, true, out Color color);

                for (int i = 0; i < quantity; i++) {
                    curRoundCubes.Add(new Cube(color));
                }
            }

            rounds.Add(new Round(curRoundCubes));
        }

        return new Game(bag, gameId, rounds);
    }

    public bool IsPossible()
    {
        return Rounds.Count == GetPossibleRounds().Count;
    }

    public List<Round> GetPossibleRounds()
    {
        return Rounds.Where(round => round.IsPossible(Bag)).ToList();
    }

    public override string ToString()
    {
        return $"Game: {Id}: {string.Join("; ", Rounds)}";
    }
}
