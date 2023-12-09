using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.Day4;

public class Card
{
    public int Number;

    public int[] MatchingNumbers => Numbers.Intersect(WinningNumbers).ToArray();

    public double Points => MatchingNumbers.Length > 0 ? Math.Pow(2, MatchingNumbers.Length - 1) : 0;

    private int[] WinningNumbers { get; }

    private int[] Numbers { get; }

    private Card(int number, int[] winningNumbers, int[] numbers)
    {
        Number = number;
        WinningNumbers = winningNumbers;
        Numbers = numbers;
    }

    public static Card CreateFromString(string input)
    {
        Regex cardNumberRegex = new(@"Card +(?<cardNumber>\d+): ");

        int cardNumber = int.Parse(cardNumberRegex.Match(input).Groups["cardNumber"].Value);

        string[] lines = cardNumberRegex.Replace(input, "").Split(" | ");

        MatchCollection winningNumbers = Regex.Matches(lines[0], @"\d+");
        MatchCollection numbers = Regex.Matches(lines[1], @"\d+");

        return new Card(
            cardNumber,
            winningNumbers.Select(match => int.Parse(match.Value)).ToArray(),
            numbers.Select(match => int.Parse(match.Value)).ToArray()
        );
    }
}
