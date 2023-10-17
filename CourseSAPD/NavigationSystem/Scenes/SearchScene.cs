using CourseSAPD.NavigationSystem.Enums;
using CourseSAPD.NavigationSystem.Interface;
using CourseSAPD.NavigationSystem.Modules;
using System;
using System.Collections.Generic;
using System.Threading;
using static System.Collections.Specialized.BitVector32;

namespace CourseSAPD.NavigationSystem.Scenes
{
    internal class SearchScene : IScene
    {
        private MyQueue<Note> _notes;
        private int[] _indexArray = new int[4000];
        private string _key;
        private int _index = 0;

        public SearchScene(MyQueue<Note> notes)
        {
            _notes = notes;
        }

        public void ShowScene(out SceneType returnScene, out MyQueue<Note> returnNotes)
        {
            returnScene = SceneType.ListScene;
            returnNotes = _notes;
            ActionPoints selectedPoint = default;
            Console.WriteLine("Введите ключ поиска:");
            _key = Console.ReadLine();

            for(int i = 0; i < _notes.Count - 1; i++)
            {
                _indexArray[i] = i;
            }

            int firstIndex = BinSearch(_indexArray, _key);
            if (firstIndex == -1)
            {
                Console.WriteLine("Не найдено");
                Thread.Sleep(1000);
                returnScene = SceneType.ListScene;
                return;
            }
            FindAllIndex(firstIndex);

            /*ShowList(_indexArray);*/

            ConsoleKeyInfo key = Console.ReadKey();
            switch(key)
            {
                default:
                    return;
            }
        }

        private void ShowList(int[] indexArray)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("...:");

            for(int i = 0; i < indexArray.Length - 1; i++)
            {
                _notes[indexArray[i]].Show();
            }

        }

        public int BinSearch(int[] ints, string key)
        {
            int left = 0, right = ints.Length;
            int mid;
            while (left < right)
            {
                mid = (left + right) / 2;
                if (Compare(_notes[_indexArray[mid]].Lawyer.Substring(0, 3), key) < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            if (Equals(_notes[_indexArray[right]].Lawyer.Substring(0, 3), key))
            {
                return right;
            }
            return -1;
        }

        public void FindAllIndex(int m)
        {
            while (Equals(_notes[m].Lawyer.Substring(0, 3), _key))
            {
                _notes[m].Show();
                m++;
                if(m == 4000)
                {
                    return;
                }    
            }
            return;
        }

        public bool Equals(string a, string b) => 0 == Compare(a, b);

        public int Compare(string a, string b)
        {
            int result = 0;
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] < b[i])
                {
                    result--;
                }
                else if (a[i] > b[i])
                {
                    result++;
                }
            }
            return result;
        }
    }
}
