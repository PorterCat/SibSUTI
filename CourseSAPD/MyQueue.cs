using System;
using System.Collections.Generic;

namespace CourseSAPD
{
    public class MyQueue<T>
    {
        public int Count { get; private set; }

        private Node<T> _root;
        private Node<T> _tail;

        public MyQueue(T value)
        {
            _root = new Node<T>(value);
            _tail = _root;
            Count++;
        }

        public MyQueue()
        {
            _root = null;
            _tail = null;
        }

        public void Add(T value)
        {
            Count++;
            if (_root == null)
            {
                _root = new Node<T>(value);
                _tail = _root;

                return;
            }

            var newNode = new Node<T>(value);
            _tail.Next = newNode;
            _tail = _tail.Next;
        }

        public void AddRange(MyQueue<T> collection)
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
                if (index > Count)
                {
                    throw new IndexOutOfRangeException();
                }
                var current = _root;
                for (int i = 0; i < index; i++)
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

        public void DigitalSort(ref MyQueue<Note> notes)
        {
            int size = notes[0].ByteAmountLawyer.Length;

            MyQueue<Note> list = new MyQueue<Note>();
            for (int i = 0; i < notes.Count; i++)
            {
                list.Add(notes[i]);
            }

            MyQueue<Note>[] qList = new MyQueue<Note>[256]; //Создаём массив из 256 очередей для работы с байтами

            for (int i = 0; i < 256; i++)
            {
                qList[i] = new MyQueue<Note>();
            }

            for (int j = size - 1; j >= 0; j--) //Каждый байт анализируется справа налево <-
            {
                for (int i = 0; i < notes.Count; i++)
                {
                    byte bt;

                    bt = list[i].ByteAmountLawyer[j];
                    qList[bt].Add(list[i]);
                }

                list.Clear(); // Очищаем лист. Каждый раз в нём формируется новая последовательность, которая рано или поздно станет упорядоченной

                for (int i = 0; i < 256; i++)
                {
                    if (qList[i].Count > 0)
                    {
                        list.AddRange(qList[i]); //Заносим очередь 
                        qList[i].Clear();
                    }
                    //Вот наши очереди 1->2->3 и 4->5->6       Лист пуст |->Null   Но с помощью AddRange мы последовательно добавляем структуры очередей в него
                    //итого: лист |-1->2->3->4->5->6->Null и так далее.
                }
            }
            notes = list;
        }


        private class Node<T>
        {
            public T Value;
            public Node<T> Next;
            public Node(T value) => Value = value;
        }
    }
}
