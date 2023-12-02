namespace AdventOfCode.Y2023.Day2;

public class Bag
{
    public readonly Dictionary<Color, int> Cubes;

    public Bag(Dictionary<Color, int> cubes)
    {
        Cubes = cubes;
    }
}
