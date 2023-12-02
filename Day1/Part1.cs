using System.Text.RegularExpressions;

namespace AdventOfCode.Day1;

public class Part1
{
    public static void Run()
    {
        Regex regex = new(@"\d");

        List<int> calibrationValues = new();

        foreach (string line in File.ReadLines(Path.Join(AppDomain.CurrentDomain.BaseDirectory, "../../../Day1/input/part1/puzzle.txt"))) {
            MatchCollection digits = regex.Matches(line);

            if (digits.Count == 0) {
                continue;
            }

            int number = int.Parse($"{digits[0]}{(digits.Count > 1 ? digits.Last() : digits[0])}");

            calibrationValues.Add(number);
        }

        int total = calibrationValues.Sum();

        Console.WriteLine(total);
    }
}
