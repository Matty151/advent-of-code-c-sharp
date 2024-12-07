namespace AdventOfCode.Y2024.Day1;

public class Part1
{
    public static void Run()
    {
        string[] lines = TextFileReader.ReadLines(2024, 1, 1, "puzzle");

        List<int> left = [];
        List<int> right = [];

        foreach (string line in lines) {
            List<int> numbers = line.Split(" ", 2, StringSplitOptions.TrimEntries)
                .Select(int.Parse)
                .ToList();

            left.Add(numbers[0]);
            right.Add(numbers[1]);
        }

        left = left.OrderBy(x => x).ToList();
        right = right.OrderBy(x => x).ToList();

        int result = left.Zip(right, (l, r) => (l, r))
            .Select((tuple, _) => Math.Abs(tuple.l - tuple.r))
            .Sum();

        Console.WriteLine(result);
    }
}
