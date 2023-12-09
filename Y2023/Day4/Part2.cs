namespace AdventOfCode.Y2023.Day4;

public class Part2
{
    public static void Run()
    {
        string[] lines = TextFileReader.ReadLines(4, 1, "puzzle");

        Dictionary<int, Card> cards = lines
            .Select(Card.CreateFromString)
            .ToDictionary(card => card.Number, card => card);

        Dictionary<int, int> cardCopies = cards
            .ToDictionary(card => card.Value.Number, _ => 1);

        foreach (KeyValuePair<int, int> cardCopy in cardCopies) {
            for (int j = 0; j < cardCopy.Value; j++) {
                for (int i = 1; i <= cards[cardCopy.Key].MatchingNumbers.Length; i++) {
                    // TODO: Check if in bounds.
                    cardCopies[cardCopy.Key + i] += 1;
                }
            }
        }

        Console.WriteLine(cardCopies.Sum(card => card.Value));
    }
}
