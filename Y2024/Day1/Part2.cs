namespace AdventOfCode.Y2024.Day1;

public class Part2
{
    public static void Run()
    {
        string[] lines = TextFileReader.ReadLines(2024, 1, 2, "puzzle");

        (List<int> left, List<int> right) = ParseLines(lines);

        int result = left.Sum(l => l * right.Count(r => r == l));

        Console.WriteLine(result);
    }

    private static (List<int>, List<int>) ParseLines(string[] lines)
    {
        List<int> left = [];
        List<int> right = [];

        foreach (string line in lines) {
            List<int> numbers = line.Split(" ", 2, StringSplitOptions.TrimEntries)
                .Select(int.Parse)
                .ToList();

            left.Add(numbers[0]);
            right.Add(numbers[1]);
        }

        return (left, right);
    }
}
