namespace AdventOfCode.Y2023.Day3;

public class Part1
{
    public static void Run()
    {
        string[] lines = TextFileReader.ReadLines(3, 1, "test");

        char[,] schematic = BuildSchematic(lines);

        int nrOfRows = schematic.GetLength(0);
        int nrOfCols = schematic.GetLength(1);

        List<int> partNumbers = new();

        for (int rowI = 0; rowI < nrOfRows; rowI++) {
            for (int colI = 0; colI < nrOfCols; colI++) {
                char character = schematic[rowI, colI];

                if (character == '.' || char.IsDigit(character)) {
                    continue;
                }

                // Console.WriteLine($"Character: {character}");

                for (int x = -1; x <= 1; x++) {
                    for (int y = -1; y <= 1; y++) {
                        // Skip position of the symbol itself
                        if (x == 0 && y == 0) {
                            continue;
                        }

                        int xCoord = colI + x;
                        int yCoord = rowI + y;

                        // Make sure we are in bounds
                        if (
                            xCoord < 0 || xCoord > nrOfCols - 1 ||
                            yCoord < 0 || yCoord > nrOfRows - 1
                        ) {
                            continue;
                        }

                        if (!int.TryParse(schematic[yCoord, xCoord].ToString(), out int number)) {
                            continue;
                        }

                        string left = string.Empty;
                        string right = string.Empty;

                        for (int leftI = xCoord - 1; leftI >= 0; leftI--) {
                            if (!int.TryParse(schematic[yCoord, leftI].ToString(), out int leftNumber)) {
                                break;
                            }

                            left += leftNumber;
                        }

                        left = string.Join("", left.Reverse());

                        for (int rightI = xCoord + 1; rightI < nrOfCols; rightI++) {
                            if (!int.TryParse(schematic[yCoord, rightI].ToString(), out int rightNumber)) {
                                break;
                            }

                            right += rightNumber;
                        }

                        int fullNumber = int.Parse($"{left}{number}{right}");

                        // Console.WriteLine(fullNumber);

                        if (!partNumbers.Contains(fullNumber)) {
                            partNumbers.Add(fullNumber);
                        }
                    }
                }
            }
        }

        partNumbers.ForEach(Console.WriteLine);

        Console.WriteLine(partNumbers.Sum());
    }

    private static char[,] BuildSchematic(string[] lines)
    {
        char[,] schematic = new char[lines.Length, lines[0].Length];

        for (int i = 0; i < lines.Length; i++) {
            string line = lines[i];

            for (int j = 0; j < line.Length; j++) {
                schematic[i, j] = line[j];
            }
        }

        return schematic;
    }
}
