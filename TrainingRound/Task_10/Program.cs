int testsCount = GetUserInputToInt();
if (testsCount < 0) return;
List<string> result = new();

for (int i = 0; i < testsCount; i++)
{
    int commentsCount = GetUserInputToInt();
    List<Tree> resultTree = new()
    {
        new Tree()
    };
    SortedList<int,string> messages = new SortedList<int,string>();
    for (int c = 0;c< commentsCount; c++)
    {
        string input = Console.ReadLine();
        string[] commentInfo = input.Split(new char[] { ' ' });
        int Id = int.Parse(commentInfo[0]);
        messages.Add(Id, input);
    }
    foreach(var input in messages)
    {
        Node node = new(input.Value);
        Node? parent = null;
        foreach (Tree tree in resultTree)
        {
            parent = resultTree[0].AddNodeReturnParent(node);
            if (parent != null) break;
        }
        if (parent == null)
        {
            resultTree.Add(new Tree(node));
        }
    }
    messages = null;
    GC.Collect();
    int count = resultTree.Count;
    do
    {
        if (count > 1)
        {
            int pos = 1;
            for (int p = 1; p < count; p++)
            {
                Node? parent = resultTree[0].AddNodeReturnParent(resultTree[pos].root);
                if (parent!=null)
                {
                    resultTree.RemoveAt(pos);
                }
                else
                {
                    pos++;
                }
            }
        }
        count = resultTree.Count;
    } while (count > 1);
    
    result.AddRange(resultTree[0].PrintTree());
}
result.RemoveAt(0);
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


class Node
{
    public Node(
        int _id,
        int _parentId,
        string _message = "")
    {
        Id = _id;
        ParentId = _parentId;
        Message = _message;
        Childrens = new SortedList<int, Node>();
    }
    public Node(string _messageInput)
    {
        string[] commentInfo = _messageInput.Split(new char[] { ' ' });
        Id = int.Parse(commentInfo[0]);
        ParentId = int.Parse(commentInfo[1]);
        Message = _messageInput.Replace(commentInfo[0] + " " + commentInfo[1] + " ", "");
        Childrens = new SortedList<int, Node>();
    }

    public int Id { get; set; }
    public int ParentId { get; set; }
    public string Message { get; set; }
    public SortedList<int, Node> Childrens { get; set; }
}
class Tree
{
    public Node? root = null;
    public Tree() {
        root = new(-1, -1);
    }
    public Tree(Node _root)
    {
        root = _root;
    }

    public Node? AddNodeReturnParent(Node _node)
    {
        Node? parent = GetNodeById(_node.ParentId, root);
        if (parent != null)
        {
            parent.Childrens.Add(_node.Id,_node);
            return parent;
        }
        return null;
    }
    public Node? GetNodeById(
        int _findNodeId,
        Node _currentNode)
    {
        if (_currentNode.Id == _findNodeId)
        {
            return _currentNode;
        }
        foreach (var _node in _currentNode.Childrens)
        {
            Node _temp = GetNodeById(_findNodeId, _node.Value);
            if (_temp != null) { return _temp; }
        }
        return null;
    }
    public List<string> PrintTree()
    {
        return PrintTreeLevel("", root);
    }
    private List<string> PrintTreeLevel(
        string _levels,
        Node _currentNode)
    {
        List<string> result = new List<string>();
        int n = 0;

        foreach (var _node in _currentNode.Childrens)
        {
            result.Add(PrintTreeBranchs(_levels));
            result.Add(PrintTreeBranchs(_levels) + (_levels != "" ? "--" : "") + _node.Value.Message);
            result.AddRange(PrintTreeLevel(_levels + (n == _currentNode.Childrens.Count - 1 ? "0" : "1"), _node.Value));
            n++;
        }
        return result;
    }
    private string PrintTreeBranchs(string levels)
    {
        if (!string.IsNullOrEmpty(levels))
        {
            string row = "";
            foreach (char i in levels)
                row += i == '1' ? "|  " : "   ";
            return row[3..] + "|";
        }
        return "";
    }
}