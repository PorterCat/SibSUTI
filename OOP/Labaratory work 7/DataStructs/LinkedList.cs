using System.Linq.Expressions;

namespace DataStructs
{
    public abstract class LinkedList<T>
    {
        protected Node<T> _root;

        public abstract void Add(T value);

        public void Remove()
        {
            try
            {
                if (_root == null)
                {
                    throw new Exception("Stack is empty");
                }
                _root = _root.Next;
            }
            catch
            {
                Console.WriteLine("Stack is empty");
            }
        }

        public virtual void Clear() => _root = null;

        public void Show(Action<T> action)
        {
            Node<T> node = _root;
            try
            {
                if (_root == null)
                {
                    throw new Exception("Stack is empty");
                }
            }
            catch
            {
                Console.WriteLine("Stack is empty");
            }

            while (node != null)
            {
                action(node.Value);
                node = node.Next;
            }
        }

        protected class Node<T>
        {
            public T Value;
            public Node<T>? Next;

            public Node(T value) => Value = value;
        }
    }
}
