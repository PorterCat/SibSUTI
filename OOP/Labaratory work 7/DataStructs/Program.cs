DataStructs.Stack<int> stack = new();
DataStructs.Queue<int> queue = new();
Action<int> action = (x) =>
{
    Console.Write($"{x} ");
};

queue.Show(action);
Console.WriteLine();
queue.Remove();

