int testsCount = GetUserInputToInt();
if (testsCount < 0) return;
List<string> result = new();

for (int i = 0; i < testsCount; i++)
{
    int peoplesCount = GetUserInputToInt();
    if (peoplesCount < 0) return;
    (int min, int max) temperatures2 = (15, 30);
    for (int people = 0; people < peoplesCount; people++)
    {
        string temperatureException = Console.ReadLine();
        string[] temperature = temperatureException.Split(new char[] { ' ' });
        if (temperature[0]== ">=")
        {
            int temp2 = int.Parse(temperature[1]);
            if (temp2 >= temperatures2.min && temp2 <= temperatures2.max)
            {
                temperatures2.min = temp2;
            }
            if (temp2 > temperatures2.max)
            {
                temperatures2.min = 100;
                temperatures2.max = 100;
            }
        }
        if (temperature[0] == "<=")
        {
            int temp2 = int.Parse(temperature[1]);
            if (temp2 <= temperatures2.max && temp2 >= temperatures2.min)
            {
                temperatures2.max = temp2;
            }
            if (temp2 < temperatures2.min)
            {
                temperatures2.min = 100;
                temperatures2.max = 100;
            }
        }
        result.Add(temperatures2.min == 100 ? "-1" : temperatures2.min.ToString());
    }
    result.Add("");
}
foreach (string res in result)
{
    Console.WriteLine(res);
}


int GetUserInputToInt()
{
    string userInput = Console.ReadLine();
    if (string.IsNullOrEmpty(userInput))
    {
        Console.WriteLine("ERR");
        return-1;
    }
    return int.Parse(userInput);
}

/*
 int testsCount = GetUserInputToInt();
if (testsCount < 0) return;
List<string> result = new();

for (int i = 0; i < testsCount; i++)
{
    int peoplesCount = GetUserInputToInt();
    if (peoplesCount < 0) return;
    int[] temperatures = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    (int min, int max) temperatures2 = (15, 30);
    for (int people = 0; people < peoplesCount; people++)
    {
        string temperatureException = Console.ReadLine();
        string[] temperature = temperatureException.Split(new char[] { ' ' });
        int point1 = 0;
        int point2 = 0;
        if (temperature[0]== ">=")
        {
            point1 = 15;
            point2 = int.Parse(temperature[1])-1;
            int temp2 = int.Parse(temperature[1]);
            if (temp2 >= temperatures2.min && temp2 <= temperatures2.max)
            {
                temperatures2.min = temp2;
            }
            if (temp2 > temperatures2.max)
            {
                temperatures2.min = 100;
                temperatures2.max = 100;
            }
        }
        if (temperature[0] == "<=")
        {
            point1 = int.Parse(temperature[1])+1;
            point2 = 30;
            int temp2 = int.Parse(temperature[1]);
            if (temp2 <= temperatures2.max && temp2 >= temperatures2.min)
            {
                temperatures2.max = temp2;
            }
            if (temp2 < temperatures2.min)
            {
                temperatures2.min = 100;
                temperatures2.max = 100;
            }
        }
        int temp = 0;
        for(int t = 15; t < 31; t++)
        {
            if (point1<=t && t<=point2)
                temperatures[t-15] = 0;
            if (temperatures[t - 15] == 1)
                temp = t;
        }
        //result.Add(temp == 0 ? "-1" : temp.ToString());
        result.Add(temperatures2.min == 100 ? "-1" : temperatures2.min.ToString());
    }
    result.Add("");
}
foreach (string res in result)
{
    Console.WriteLine(res);
}


int GetUserInputToInt()
{
    string userInput = Console.ReadLine();
    if (string.IsNullOrEmpty(userInput))
    {
        Console.WriteLine("ERR");
        return-1;
    }
    return int.Parse(userInput);
}
 */