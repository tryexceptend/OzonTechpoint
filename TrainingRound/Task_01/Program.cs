using System;
using System.Diagnostics;

string? path = args.Length > 0 ? args[0] : null;
if (path == null)
{
    var result = Task_01(new List<string>(0));
    result.ForEach(x => Console.WriteLine(x));
}
else
{
    FileInfo file = new (path);
    if (file.Attributes == FileAttributes.Directory)
    {
        string[] fileEntries = Directory.GetFiles(file.FullName);
        foreach (string fileName in fileEntries)
        {
            if (fileName[^2..] == ".a") continue;
            TestFromFileData(fileName);
        }
    }
    if (file.Attributes == FileAttributes.Normal)
    {
        TestFromFileData(file.FullName);
    }
}
List<string> Task_01(List<string> userInputs)
{
    int inputPos = 0;
    int testsCount = GetUserInputToInt(userInputs,ref inputPos);
    List<string> result = new();
    for (int i = 0; i < testsCount; i++)
    {
        string testInput = GetUserInputToString(userInputs,ref inputPos);
        int[] test = testInput.Split(new char[] { ' ' }).Select(c => int.Parse(c)).ToArray();
        if (test == null || test.Length != 10)
        {
            result.Add("NO");
        }
        else
        {
            Dictionary<int, int> mask = new()
        {
            {1, 4},
            {2, 3},
            {3, 2},
            {4, 1}
        };
            foreach (int c in test)
            {
                mask[c]--;
                if (mask[c] < 0)
                {
                    break;
                }
            }
            result.Add(mask[1] == 0 && mask[2] == 0 && mask[3] == 0 && mask[4] == 0 ? "YES" : "NO");
        }
    }
    return result;
}

int GetUserInputToInt(List<string> _inputs, ref int inputRow)
{
    string? userInput = (_inputs.Count > 0)
        ? _inputs[inputRow]
        : Console.ReadLine();
    inputRow++;
    if (string.IsNullOrEmpty(userInput))
    {
        Console.WriteLine("ERR");
        return -1;
    }
    return int.Parse(userInput);
}

string GetUserInputToString(List<string> _inputs, ref int inputRow)
{
    string? userInput = (_inputs.Count > 0)
        ? _inputs[inputRow]
        : Console.ReadLine();
    inputRow++;
    return userInput;
}

void TestFromFileData(string fileName)
{
    string resultTestsPath = fileName+".a";
    List<string> inputs = new ();
    List<string> outputs = new ();
    using StreamReader sr = new(fileName);
    while (!sr.EndOfStream)
    {
        inputs.Add(sr.ReadLine());
    }
    if (File.Exists(resultTestsPath))
    {
        using StreamReader srout = new(resultTestsPath);
        while (!srout.EndOfStream)
        {
            outputs.Add(srout.ReadLine());
        }
    }
    Stopwatch stopwatch = Stopwatch.StartNew();
    var result = Task_01(inputs);
    stopwatch.Stop();
    if (resultTestsPath == null)
    {
        result.ForEach(x => Console.WriteLine(x));
    }
    else
    {
        if (result.Count != outputs.Count)
        {
            Console.WriteLine(Process.GetCurrentProcess().MainModule.ModuleName + " false");
            Console.WriteLine(stopwatch.Elapsed);
        }
        else
        {
            bool itog = true;
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] != outputs[i])
                {
                    itog = false;
                    break;
                }
            }
            Console.WriteLine(Process.GetCurrentProcess().MainModule.ModuleName + " - " + itog);
            Console.WriteLine(stopwatch.Elapsed);
        }
    }
}