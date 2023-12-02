namespace AdventOfCode;

public class TextFileReader
{
    public static string[] ReadLines(int day, int part, string file)
    {
        return File.ReadAllLines(Path.Join(AppDomain.CurrentDomain.BaseDirectory, $"../../../Y2023/Day{day}/input/part{part}/{file}.txt"));
    }
}
