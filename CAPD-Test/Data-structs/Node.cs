namespace CAPD_Test.Data_structs
{
    internal class Node<T> 
    {
        public Node<T> Next;
        public T Value;

        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }
}
