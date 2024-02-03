string testsCountInput = Console.ReadLine();
int testsCount = int.Parse(s: testsCountInput);
List<string> result = new();
for (int i = 0; i < testsCount; i++)
{
    string testInput = Console.ReadLine();
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
foreach (string res in result)
{
    Console.WriteLine(res);
}