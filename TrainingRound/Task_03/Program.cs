string testsCountInput = Console.ReadLine();
if (string.IsNullOrEmpty(testsCountInput))
{
    Console.WriteLine("ERR");
    return;
}
int testsCount = int.Parse(s: testsCountInput);
List<string> result = new();

for (int i = 0; i < testsCount; i++)
{
    string testInput = Console.ReadLine();
    string carNumbers = "";
    if (string.IsNullOrEmpty(testInput))
    {
        result.Add("-");
        continue;
    }
    int point1 = 0;
    int point2 = testInput.Length>4 ? 4: testInput.Length;
    string tmpNumber = "";
    while (point2 <= testInput.Length)
    {
        tmpNumber = testInput[point1..point2];
        if (ValideCarNumber(tmpNumber))
        {
            carNumbers += tmpNumber + " ";
            point1 = point2;
            point2 = point1+4;
            if (point2> testInput.Length)
            {
                point2 = testInput.Length;
            }
        }
        else
        {
            point2++;
            if (point2 - point1 > 5)
            {
                tmpNumber = "";
                carNumbers = "";
                result.Add("-");
                break;
            }
        }
    }
    if (!string.IsNullOrEmpty(tmpNumber))
    {
        carNumbers = "";
        result.Add("-");
    }
    if (!string.IsNullOrEmpty(carNumbers) && carNumbers[^1] == ' ')
    {
        result.Add(carNumbers[..^1]);
    }
}
foreach (string res in result)
{
    Console.WriteLine(res);
}


bool ValideCarNumber(string _carNumber)
{
    if (_carNumber.Length == 4)
    {
        return char.IsLetter(_carNumber[0]) 
            && char.IsNumber(_carNumber[1]) 
            && char.IsLetter(_carNumber[2]) 
            && char.IsLetter(_carNumber[3]);
    }
    if (_carNumber.Length == 5)
    {
        return char.IsLetter(_carNumber[0])
            && char.IsNumber(_carNumber[1])
            && char.IsNumber(_carNumber[2])
            && char.IsLetter(_carNumber[3])
            && char.IsLetter(_carNumber[4]);
    }
    return false;
}