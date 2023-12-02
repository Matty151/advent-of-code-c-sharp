namespace AdventOfCode.Y2023.Day2;

public class Round
{
    public List<Cube> Cubes { get; }

    public Dictionary<Color, int> CubeQuantities { get; }

    public Round(List<Cube> cubes)
    {
        Cubes = cubes;
        CubeQuantities = cubes.GroupBy(cube => cube.Color).ToDictionary(group => group.Key, group => group.Count());
    }

    public bool IsPossible(Bag bag)
    {
        foreach (KeyValuePair<Color, int> cube in bag.Cubes) {
            if (CubeQuantities.ContainsKey(cube.Key) && CubeQuantities[cube.Key] > cube.Value) {
                return false;
            }
        }

        return true;
    }

    public override string ToString()
    {
        return string.Join(", ", CubeQuantities.Select(cube => $"{cube.Value} {cube.Key}"));
    }
}
