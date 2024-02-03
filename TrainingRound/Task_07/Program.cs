int testsCount = GetUserInputToInt();
if (testsCount < 0) return;
List<string> result = new();

for (int i = 0; i < testsCount; i++)
{
    int sheetCount = GetUserInputToInt();
    List<int> sheet = new List<int>(sheetCount);
    for (int p = 0; p < sheetCount; p++)
        sheet.Add(0);

    string sheetPrintetInput = Console.ReadLine();
    List<string> sheetPrintet = sheetPrintetInput.Split(",").ToList();
    foreach (string sheetPrint in sheetPrintet)
    {
        if (sheetPrint.Contains("-"))
        {
            int[] forParam = sheetPrint.Split("-").Select(p => int.Parse(p)).ToArray();
            for (int p = forParam[0]; p <= forParam[1]; p++)
            {
                sheet[p - 1] = 1;
            }
        }
        else
        {
            sheet[int.Parse(sheetPrint) - 1] = 1;
        }
    }
    int point1 = 0;
    int point2 = 0;
    List<string> resAdd = new();
    while (point2 < sheetCount - 1)
    {
        if (sheet[point1] == 0)
        {
            if (sheet[point2 + 1] == 0)
            {
                point2++;
            }
            else
            {
                if (point1 == point2)
                {
                    resAdd.Add((point1 + 1).ToString());
                }
                else
                {
                    resAdd.Add((point1 + 1).ToString() + "-" + (point2 + 1).ToString());
                }
                point1 = point2 + 1;
                point2 = point1;
            }
        }
        else
        {
            point1++;
            point2 = point1;
        }
    }
    if (sheet[point1] == 0)
    {
        point2 = sheet[sheetCount - 1] == 0 ? sheetCount - 1 : point2;
        if (point1 == point2)
        {
            resAdd.Add((point1 + 1).ToString());
        }
        else
        {
            resAdd.Add((point1 + 1).ToString() + "-" + (point2 + 1).ToString());
        }
    }
    else
    {
        if (sheet[sheetCount - 1] == 0)
        {
            resAdd.Add(sheetCount.ToString());
        }
    }
    result.Add(string.Join(',', resAdd));
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