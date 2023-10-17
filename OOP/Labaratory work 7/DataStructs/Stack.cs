namespace DataStructs
{
    internal class Stack<T> : LinkedList<T>
    {
        public override void Add(T value) => _root = new(value) { Next = _root };
    }
}
