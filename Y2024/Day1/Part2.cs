namespace AdventOfCode.Y2024.Day1;

public class Part2
{
    public static void Run()
    {
        string[] lines = TextFileReader.ReadLines(2024, 1, 2, "puzzle");

        List<int> left = [];
        List<int> right = [];

        foreach (string line in lines) {
            List<int> numbers = line.Split(" ", 2, StringSplitOptions.TrimEntries)
                .Select(int.Parse)
                .ToList();

            left.Add(numbers[0]);
            right.Add(numbers[1]);
        }

        int result = left.Select(l => (l, count: right.Count(r => r == l)))
            .Sum(tuple => tuple.l * tuple.count);

        Console.WriteLine(result);
    }
}
