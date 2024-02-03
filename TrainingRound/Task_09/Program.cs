List<string> inputs = new List<string>();
int inputRow = 0;
if (args.Length > 0)
{
    using StreamReader sr = new(args[0]);
    inputs.AddRange(sr.ReadToEnd().Split("\n"));
}

int testsCount = GetUserInputToInt(inputs);
if (testsCount < 0) return;
List<string> result = new();

for (int i = 0; i < testsCount; i++)
{
    string[] areaSizeInput = GetUserInputToString(inputs).Split(new char[] { ' ' });
    int height = int.Parse(areaSizeInput[0]);
    int width = int.Parse(areaSizeInput[1]);
    List<string> areaInput = new();
    for (int r = 0; r < height; r++)
    {
        areaInput.Add(GetUserInputToString(inputs));
    }
    List<int> res = new();
    Area areaTree = new();
    for (int r = 0; r < height; r++)
    {
        int point1 = 0;
        int point2 = 0;
        while (point2 < width)
        {
            if (areaInput[r][point2] == '*')
            {
                point2++;
            }
            else
            {
                if (point1 < point2)
                {
                    if (point2 - point1 > 1)
                    {
                        int pointH = r;
                        while (pointH < areaInput.Count && areaInput[pointH][point2 - 1] == '*')
                        {
                            pointH++;
                        }
                        if (pointH - r > 1)
                        {
                            areaTree.Add(new Rectangle(point1, point2 - point1, r, pointH - r));
                            res.AddRange(areaTree.Scan(r));
                        }
                    }
                    point1 = point2;
                }
                else
                {
                    point1++;
                    point2++;
                }
            }
        }
        if (point1 < point2)
        {
            if (point2 - point1 > 1)
            {
                int pointH = r;
                while (pointH < areaInput.Count && areaInput[pointH][point2 - 1] == '*')
                {
                    pointH++;
                }
                if (pointH - r > 1)
                {
                    areaTree.Add(new Rectangle(point1, point2 - point1, r, pointH - r));
                    res.AddRange(areaTree.Scan(r));
                }
            }
        }
    }
    res.AddRange(areaTree.Scan());
    res.Sort();
    result.Add(string.Join(" ", res));
}
foreach (string res in result)
{
    Console.WriteLine(res);
}

int GetUserInputToInt(List<string> _inputs)
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

string GetUserInputToString(List<string> _inputs)
{
    string? userInput = (_inputs.Count > 0)
        ? _inputs[inputRow]
        : Console.ReadLine();
    inputRow++;
    return userInput;
}
class Rectangle
{
    public Rectangle(
        int _x,
        int _width,
        int _y,
        int _height)
    {
        X = _x;
        Height = _height;
        Y = _y;
        Width = _width;
        Childrens = new();
    }
    public int X { get; set; }
    public int Height { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }

    public List<Rectangle> Childrens { get; set; }
    public bool IsInside(Rectangle _rectangle2) =>
           X > _rectangle2.X
        && X < (_rectangle2.Width + _rectangle2.X)
        && Y > _rectangle2.Y
        && Y < (_rectangle2.Height + _rectangle2.Y);
}

class Area
{
    public Area()
    {
        Rectangles = new();
    }
    List<Rectangle> Rectangles { get; set; }

    public void Add(Rectangle _rectangle)
    {
        Rectangle? parent = FindParent(_rectangle);
        if (parent == null)
        {
            Rectangles.Add(_rectangle);
        }
        else
        {
            parent.Childrens.Add(_rectangle);
        }
    }

    public Rectangle? FindParent(Rectangle _rectangle)
    {
        foreach (Rectangle child in Rectangles)
        {
            Rectangle? tmp2 = FindParentRecursively(_rectangle, child);
            if (tmp2 != null) return tmp2;
        }
        return null;
    }
    public static Rectangle? FindParentRecursively(
        Rectangle _rectangle,
        Rectangle _node)
    {
        if (_rectangle.IsInside(_node))
        {
            foreach (Rectangle child in _node.Childrens)
            {
                Rectangle? tmp2 = FindParentRecursively(_rectangle, child);
                if (tmp2 != null) return tmp2;
            }
            return _node;
        }
        else
        {
            return null;
        }
    }

    public List<int> Scan()
    {
        List<int> res = new();
        int lvl = 0;
        foreach (Rectangle node in Rectangles)
        {
            res.Add(lvl);
            ScanRecursively(node, lvl, res);
        }
        return res;
    }

    public List<int> Scan(int _lvl)
    {
        List<int> res = new();
        int lvl = 0;
        int p = 0;
        while (p < Rectangles.Count)
        {
            if (Rectangles[p].Y + Rectangles[p].Height < _lvl)
            {
                res.Add(lvl);
                ScanRecursively(Rectangles[p], lvl, res);
                Rectangles.RemoveAt(p);
            }
            else
            {
                p++;
            }
        }
        return res;
    }
    public static void ScanRecursively(
        Rectangle _node,
        int _lvl,
        List<int> _res)
    {
        foreach (Rectangle node in _node.Childrens)
        {
            _res.Add(_lvl + 1);
            ScanRecursively(node, _lvl + 1, _res);
        }
    }
}