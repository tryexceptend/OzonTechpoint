int testsCount = GetUserInputToInt();
if (testsCount < 0) return;
List<string> result = new();

for (int i = 0; i < testsCount; i++)
{
    List<string> res = new();
    HashSet<string> deck = new(){ "2S", "3S", "4S", "5S", "6S", "7S", "8S", "9S", "TS", "JS", "QS", "KS", "AS", "2C", "3C", "4C", "5C", "6C", "7C", "8C", "9C", "TC", "JC", "QC", "KC", "AC", "2D", "3D", "4D", "5D", "6D", "7D", "8D", "9D", "TD", "JD", "QD", "KD", "AD", "2H", "3H", "4H", "5H", "6H", "7H", "8H", "9H", "TH", "JH", "QH", "KH", "AH" };
    int playersCount = GetUserInputToInt();
    List<(string,string)> players = new ();
    for (int p =0; p< playersCount; p++)
    {
        string playerCardsInput = Console.ReadLine();
        List<string> tableCards = playerCardsInput.Split(new char[] { ' ' }).ToList();
        players.Add((tableCards[0], tableCards[1]));
        deck.Remove(tableCards[0]);
        deck.Remove(tableCards[1]);
    }
    foreach (string card in deck)
    {
        int muCombination = CalcCombination(players[0].Item1, players[0].Item2, card);
        int otherCombination = muCombination;
        for (int p = 1; p < playersCount; p++)
        {
            otherCombination = Math.Max(otherCombination, CalcCombination(players[p].Item1, players[p].Item2, card));
        }
        if (muCombination>= otherCombination)
        {
            res.Add(card);
        }
    }
    result.Add(res.Count.ToString());
    result.AddRange(res);
}
foreach (string res in result)
{
    Console.WriteLine(res);
}

static int GetUserInputToInt()
{
    string userInput = Console.ReadLine();
    if (string.IsNullOrEmpty(userInput))
    {
        Console.WriteLine("ERR");
        return -1;
    }
    return int.Parse(userInput);
}

static int CalcCombination(
    string _card1,
    string _card2,
    string _card3)
{
    if (_card1[0] == _card2[0] && _card2[0] == _card3[0])
    {
        return 300+ _card1[0].CardToInt();
    }
    int max = 0;
    if (_card1[0] == _card2[0] || _card1[0] == _card3[0])
    {
        max = _card1[0].CardToInt()>max ? _card1[0].CardToInt() : max;
    }
    if (_card2[0] == _card3[0])
    {
        max = _card2[0].CardToInt() > max ? _card2[0].CardToInt() : max;
    }
    if (max > 0)
    {
        return 200 + max;
    }
    max = _card1[0].CardToInt() > max ? _card1[0].CardToInt() : max;
    max = _card2[0].CardToInt() > max ? _card2[0].CardToInt() : max;
    max = _card3[0].CardToInt() > max ? _card3[0].CardToInt() : max;
    return 100+max;
}

public static class Utils
{
    public static int CardToInt(this char _val)
    {
        return _val switch
        {
            '2' => 2,
            '3' => 3,
            '4' => 4,
            '5' => 5,
            '6' => 6,
            '7' => 7,
            '8' => 8,
            '9' => 9,
            'T' => 10,
            'J' => 11,
            'Q' => 12,
            'K' => 13,
            'A' => 14,
            _ => 0,
        };
    }
}
