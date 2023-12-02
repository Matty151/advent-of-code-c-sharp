using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.Day2;

public class Game
{
    public int Id { get; }

    public List<Round> Rounds { get; }

    public Game(int id, List<Round> rounds)
    {
        Id = id;
        Rounds = rounds;
    }

    public static Game CreateFromString(string input)
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

        return new Game(gameId, rounds);
    }

    public bool IsPossible(Bag bag)
    {
        return Rounds.Count == Rounds.Count(round => round.IsPossible(bag));
    }

    public Dictionary<Color, int> GetMinimum()
    {
        Dictionary<Color, int> minimums = new();

        foreach (Round round in Rounds) {
            foreach (KeyValuePair<Color, int> cubeQuantity in round.CubeQuantities) {
                if (!minimums.ContainsKey(cubeQuantity.Key) || cubeQuantity.Value > minimums[cubeQuantity.Key]) {
                    minimums[cubeQuantity.Key] = cubeQuantity.Value;
                }
            }
        }

        return minimums;
    }

    public override string ToString()
    {
        return $"Game: {Id}: {string.Join("; ", Rounds)}";
    }
}
