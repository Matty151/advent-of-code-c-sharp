using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.Day1;

public class Part2
{
    public static void Run()
    {
        Regex regex = new(@"(?=(one|two|three|four|five|six|seven|eight|nine))|\d");

        List<int> calibrationValues = new();

        foreach (string line in File.ReadLines(Path.Join(AppDomain.CurrentDomain.BaseDirectory, "../../../Y2023/Day1/input/part2/puzzle.txt"))) {
            List<string> matches = regex.Matches(line)
                .Select(match => match.Value != string.Empty ? match.Value : match.Groups[1].ToString())
                .ToList();

            if (matches.Count == 0) {
                continue;
            }

            int first = ParseNumber(matches[0]);
            int number = int.Parse($"{first}{(matches.Count > 1 ? ParseNumber(matches.Last()) : first)}");

            calibrationValues.Add(number);
        }

        int total = calibrationValues.Sum();

        Console.WriteLine(total);
    }

    private static int ParseNumber(string potentialNumber)
    {
        if (int.TryParse(potentialNumber, out int digit)) {
            return digit;
        }

        return new Dictionary<string, int> {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
        }[potentialNumber];
    }
}
