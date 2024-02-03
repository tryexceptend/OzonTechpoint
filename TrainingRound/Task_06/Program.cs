int testsCount = GetUserInputToInt();
if (testsCount < 0) return;
List<string> result = new();

for (int i = 0; i < testsCount; i++)
{
    string testInput = Console.ReadLine();
    (int x, int y) cursorPosition = (0, 0);
    List<string> line = new() { "" };
    foreach (char c in testInput)
    {
        if (char.IsNumber(c) || char.IsLower(c))
        {
            if (cursorPosition.x < line[cursorPosition.y].Length)
            {
                line[cursorPosition.y] = line[cursorPosition.y][..cursorPosition.x] + c + line[cursorPosition.y][cursorPosition.x..];
            }
            else
            {
                line[cursorPosition.y] += c;
            }
            cursorPosition.x++;
        }
        if (char.IsUpper(c))
        {
            switch (c)
            {
                case 'L':
                    if (cursorPosition.x > 0)
                        cursorPosition.x--;
                    break;
                case 'R':
                    if (cursorPosition.x < line[cursorPosition.y].Length)
                        cursorPosition.x++;
                    break;
                case 'U':
                    if (cursorPosition.y > 0)
                    {
                        cursorPosition.y--;
                        if (line[cursorPosition.y].Length < cursorPosition.x)
                            cursorPosition.x = line[cursorPosition.y].Length;
                    }
                    break;
                case 'D':
                    if (cursorPosition.y < line.Count - 1)
                    {
                        cursorPosition.y++;
                        if (line[cursorPosition.y].Length < cursorPosition.x)
                            cursorPosition.x = line[cursorPosition.y].Length;
                    }
                    break;
                case 'B':
                    cursorPosition.x = 0;
                    break;
                case 'E':
                    cursorPosition.x = line[cursorPosition.y].Length;
                    break;
                case 'N':
                    line.Add("");
                    //смещение строк
                    for (int r = line.Count - 1; r > cursorPosition.y; r--)
                    {
                        line[r] = line[r - 1];
                    }
                    line[cursorPosition.y + 1] = "";
                    //перенос строки
                    if (cursorPosition.x < line[cursorPosition.y].Length)
                    {
                        line[cursorPosition.y + 1] = line[cursorPosition.y][cursorPosition.x..];
                        line[cursorPosition.y] = line[cursorPosition.y][..cursorPosition.x];
                        cursorPosition.x = 0;
                    }
                    else
                    {
                        cursorPosition.x = line[cursorPosition.y + 1].Length;
                    }
                    cursorPosition.y++;

                    break;
            }
        }
    }
    result.AddRange(line);
    result.Add("-");
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