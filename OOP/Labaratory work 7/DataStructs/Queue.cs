namespace DataStructs
{
    public class Queue<T> : LinkedList<T>
    {
        private Node<T>? _tail;

        public Queue()
        {
            _root = null;
            _tail = _root;
        }
        public override void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);
            if ( _tail == null)
            {
                _root = newNode;
                _tail = _root;
                return;
            }
            _tail.Next = newNode;
            _tail = newNode;
        }

        public override void Clear()
        {
            base.Clear();
            _tail = null;
        }
    }
}
