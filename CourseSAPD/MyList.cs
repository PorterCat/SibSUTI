using System;
using System.Collections;
using System.Collections.Generic;

namespace CourseSAPD
{
    public class MyList<T>
    {
        public T this[int index]
        {
            get
            {
                if(CheckIndexInBounds(index) == false)
                    throw new IndexOutOfRangeException();
                return _array[index];
            }
            set
            {
                if (CheckIndexInBounds(index) == false)
                    throw new IndexOutOfRangeException();
                _array[index] = value;
            }
        }

        public int Count { get; private set; }

        public int Capacity => _array.Length;

        private T[] _array;
        
        public MyList()
        {
            _array = new T[4];
        }

        public MyList(int capacity)
        {
            _array = new T[capacity];
        }

        public void Add(T item)
        {
            if(CheckIndexInBounds(Count) == false)
            {
                ExtendArray(Capacity * 2);
            }
            _array[Count] = item;
            Count++;
        }

        public void Clear()
        {
            _array = new T[Capacity];
            Count = 0;
        }


        private void ExtendArray(int capacity) 
        {
            var newArray = new T[capacity];

            for(int i = 0; i < _array.Length; i++)
            {
                newArray[i] = _array[i];
            }

            _array = newArray;
        }

        private bool CheckIndexInBounds(int index)
        {
            if (index < 0 && index > Count)
            {
                return false;
            }
            return true;
        }
    }
}
