using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.Day4;

public class Card
{
    public int[] WinningNumbers { get; }

    public int[] Numbers { get; }

    public Card(int[] winningNumbers, int[] numbers)
    {
        WinningNumbers = winningNumbers;
        Numbers = numbers;
    }

    public static Card CreateFromString(string input)
    {
        string[] lines = input.Split(" | ");

        MatchCollection winningNumbers = Regex.Matches(lines[0], @"\d+");
        MatchCollection numbers = Regex.Matches(lines[1], @"\d+");

        return new Card(
            winningNumbers.Select(match => int.Parse(match.Value)).ToArray(),
            numbers.Select(match => int.Parse(match.Value)).ToArray()
        );
    }

    public double GetPoints()
    {
        int[] matchingNumbers = Numbers.Intersect(WinningNumbers).ToArray();

        if (matchingNumbers.Length == 0) {
            return 0;
        }

        return Math.Pow(2, matchingNumbers.Length - 1);
    }
}
