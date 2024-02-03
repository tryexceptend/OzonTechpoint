int testsCount = GetUserInputToInt();
if (testsCount < 0) return;
List<string> result = new();

for (int i = 0; i < testsCount; i++)
{
    List<int> res = new();
    int arrayCount = GetUserInputToInt();
    int minLength = arrayCount * 2 + 1;
    int minIndex = -1;
    string dataArrayInput = Console.ReadLine();
    List<int> dataArray = dataArrayInput.Split(' ').Select(x => int.Parse(x)).ToList();
    if (arrayCount == 1)
    {
        res.AddRange(new int[] { dataArray[0], 0 });
        result.Add("2");
        result.Add(string.Join(" ", res));
        continue;
    }

    //for(int head = 0; head< arrayCount-1; head++)
    {
        int p1 = 0;
        int p2 = 1;
        List<int> tmpRes = new();
        while (p1 < arrayCount)
        {
            (int, int) value = (dataArray[p1], 0);
            while (p2 < arrayCount)
            {
                int orientir = IsSequence(dataArray, p1, p2);
                if (orientir == 0)
                {
                    break;
                }
                else
                {
                    if (value.Item2 != 0)
                    {
                        if (value.Item2 < 0 && orientir < 0 || value.Item2 > 0 && orientir > 0)
                        {
                            value.Item2 += orientir;
                            p2++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        value.Item2 += orientir;
                        p2++;
                    }
                }
            }
            tmpRes.AddRange(new int[] { value.Item1, value.Item2 });
            p1 = p2;
            p2++;
        }
        if (tmpRes.Count < minLength)
        {
            minLength = tmpRes.Count;
            minIndex = tmpRes.Count - 1;
            res = tmpRes;
        }
    }
    result.Add(res.Count.ToString());
    result.Add(string.Join(" ", res));
}
foreach (string res in result)
{
    Console.WriteLine(res);
}

static int IsSequence(List<int> arr, int p1, int p2)
{
    int orientation = arr[p1] - arr[p1 + 1];
    if (orientation == 0) return orientation;
    if (Math.Abs(orientation) > 1) return 0;
    for (int i = p1; i < p2; i++)
    {
        if (arr[i] - arr[i + 1] != orientation) return 0;
    }
    return orientation * (-1);
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