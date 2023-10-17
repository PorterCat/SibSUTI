using System;

namespace CAPD_Test.Data_structs
{
    public class MyLinkedList<T>
    {
        public int Count { get; private set; }

        private Node<T> _root;
        private Node<T> _tail;

        public MyLinkedList(T value)
        {
            _root = new Node<T>(value);
            _tail = _root;
            Count++;
        }

        public MyLinkedList()
        {
            _root = null;
            _tail = null;
        }

        public void Add(T value)
        {
            Count++;
            if ( _root == null )
            {
                _root = new Node<T>(value);
                _tail = _root;
                
                return;
            }

            var newNode = new Node<T>(value);
            _tail.Next = newNode;
            _tail = _tail.Next;
        }

        public void AddRange(MyLinkedList<T> collection)
        { 
            if (_root == null)
            {
                _root = collection._root;
                _tail = collection._tail;
            }
            else
            {
                _tail.Next = collection._root;
                _tail = collection._tail;
            }
            Count += collection.Count;
        }

        public T this[int index]
        {
            get
            {
                if( index > Count )
                {
                    throw new IndexOutOfRangeException();
                }
                var current = _root;
                for(int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Value;   
            }
        }

        public void Clear()
        {
            _root = null;
            _tail = null;
            Count = 0;
        }

        private class Node<T>
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
}
