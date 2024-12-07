namespace AdventOfCode;

public class TextFileReader
{
    public static string[] ReadLines(int year, int day, int part, string file)
    {
        return File.ReadAllLines(Path.Join(AppDomain.CurrentDomain.BaseDirectory, $"../../../Y{year}/Day{day}/input/part{part}/{file}.txt"));
    }
}
