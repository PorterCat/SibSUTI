using CAPD_Test.Data_structs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CAPD_Test
{
    internal class Program
    {
        private static readonly Encoding _cpp866 = Encoding.GetEncoding("cp866");

        private static readonly string _filePath = @"C:\Programming\SibSUTI\CAPD-Test\testBase3.dat";

        private static MyLinkedList<int> _keySearchIndexArray;

        static void Main(string[] args)
        {

            MyLinkedList<Note> notesSummon = new MyLinkedList<Note>();  
            
            ParseFile(notesSummon);


            int t = 0;
            int b = 19;
            bool IsShown = true;
            bool IsAlreadySorted = false;
            bool IsKeySearched = false;
            PrintList(notesSummon, t, b);

            MyLinkedList<Note> notes;
            while (true)
            {
                if(IsKeySearched)
                {
                    notes = _keySearchIndexArray;
                }
                else
                {
                    notes = notesSummon;
                }
                
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.KeyChar)
                {
                    case '1':
                        if(IsShown == false)
                        {
                            break;
                        }

                        if (t != 0)
                        {
                            t -= 20;
                            b -= 20;
                        }

                        PrintList(notes, t, b);
                        break;
                    case '2':
                        if (IsShown == false)
                        {
                            break;
                        }

                        if (b != 3999)
                        {
                            t += 20;
                            b += 20;
                        }

                        PrintList(notes, t, b);
                        break;

                    case '3':
                        if(IsShown == false)
                        {
                            PrintList(notes, t, b);
                            IsShown = true;
                        }
                        else
                        {
                            IsShown = false;
                            Console.Clear();
                            Console.SetCursorPosition(0, 20);
                            Console.WriteLine("===================================Введите команду:================================");
                            Console.WriteLine("1: <-   2: ->   3: Вкл/выкл отображение БД 4: Отсортировать БД  5: Поиск по ключу");
                        }
                        break;

                    case '4':
                        if(IsAlreadySorted == false)
                        { 
                            DigitalSort(ref notes);
                            if(IsShown)
                            {
                                PrintList(notes, t, b);
                            }
                            IsAlreadySorted = true;
                        }
                        break;

                    case '5':
                        Console.Clear();
                        if (IsAlreadySorted)
                        {
                            Console.WriteLine("Введите ключ поиска");
                            string key = Console.ReadLine();
                            MyLinkedList<int> indexArr = new MyLinkedList<int>();
                            _keySearchIndexArray = Search(notes, key);
                            if(_keySearchIndexArray == null)
                            {
                                Console.Clear();
                                Console.WriteLine("Ничего не найдено");
                                System.Threading.Thread.Sleep(1000);
                                PrintList(notes, t, b);
                                break;

                            }
                            PrintList(myLinkedList, t, b);
                        }
                        else
                        {
                            Console.WriteLine("Сначала отсортируй массив");
                            System.Threading.Thread.Sleep(1000);
                            PrintList(notes, t, b);
                        }
                        break;

                }
            }


        }

        private static void PrintList(MyLinkedList<Note> notes, int t, int b) //Вывод страницы
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            for(int i = t; i <= b; i++)
            {
                Console.Write($"{i+1}. ");
                notes[i].Show();
            }

            Console.WriteLine("===================================Введите команду:================================");
            Console.WriteLine("1: <-   2: ->   3: Вкл/выкл отображение БД 4: Отсортировать БД  5: Поиск по ключу");
        }

        private static Data_structs.MyLinkedList<Note> ParseFile(Data_structs.MyLinkedList<Note> notes)
        {
            var fileBytes = File.ReadAllBytes(_filePath);

            var fileElements = new List<List<byte>>();
            var tempElement = new List<byte>();

            foreach (var currentByte in fileBytes)
            {
                if(currentByte == 0)
                {
                    fileElements.Add(tempElement);
                    tempElement = new List<byte>();
                    continue;
                }
                tempElement.Add(currentByte);
            }


            for (int i = 0; i < fileElements.Count; i += 3)
            {
                var note = new Note();

                note.Name = _cpp866.GetString(fileElements[i].ToArray());
                note.Amount = fileElements[i + 1].GetRange(0, 2).ToArray();
                note.Date = _cpp866.GetString(fileElements[i + 1].GetRange(2, fileElements[i + 1].Count - 2).ToArray());
                note.Lawyer = fileElements[i + 2].ToArray();

                notes.Add(note);
            }
            return notes;
        }

        private static void DigitalSort(ref MyLinkedList<Note> notes)
        {
            int size = notes[0].Lawyer.Length + 2;

            MyLinkedList<Note> list = new MyLinkedList<Note>();
            for (int i = 0; i < notes.Count; i++)
            {
                list.Add(notes[i]);
            }

            MyLinkedList<Note>[] qList = new MyLinkedList<Note>[256]; //Создаём массив из 256 очередей для работы с байтами

            for (int i = 0; i < 256; i++)
            {
                qList[i] = new MyLinkedList<Note>();
            }

            for (int j = size - 1; j >= 0; j--) //Каждый байт анализируется справа налево <-
            {
                for (int i = 0; i < notes.Count; i++)
                {
                    byte bt;
                    if (j >= size - 2)
                    {
                        bt = list[i].Amount[size - j - 1];
                    }
                    else
                    {
                        bt = list[i].Lawyer[j];
                    }
                    qList[(int)bt].Add(list[i]);
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

        private static MyLinkedList<int> Search(MyLinkedList<Note> notes, string key)
        {
            MyLinkedList<int> queue = new MyLinkedList<int>();

            var left = 0;
            var right = notes.Count - 1;
            var m = 0;
            byte[] bytes = new byte[3];
            string lawyerStr3 = String.Empty;

            while (left < right)
            {
                m = (left + right) / 2;
                bytes[0] = notes[m].Lawyer[0];
                bytes[1] = notes[m].Lawyer[1];
                bytes[2] = notes[m].Lawyer[2];

                lawyerStr3 = Encoding.GetEncoding("cp866").GetString(bytes);
                if (String.Compare(lawyerStr3, key) < 0)
                {
                    left = m + 1;
                }
                else
                {
                    right = m;
                }
            }
            m++;
            bytes[0] = notes[m].Lawyer[0];
            bytes[1] = notes[m].Lawyer[1];
            bytes[2] = notes[m].Lawyer[2];
            lawyerStr3 = Encoding.GetEncoding("cp866").GetString(bytes);

            if (String.Equals(lawyerStr3, key))
            {
                while (String.Equals(Encoding.GetEncoding("cp866").GetString(bytes), key))
                {
                    queue.Add(m++);
                    bytes[0] = notes[m].Lawyer[0];
                    bytes[1] = notes[m].Lawyer[1];
                    bytes[2] = notes[m].Lawyer[2];
                }
                return queue;
            }

            return null;
        }

        /*private static MyLinkedList<Note> DigitalSort(MyLinkedList<Note> notes)
        {
            int size = notes[0].Lawyer.Length + 2;

            MyLinkedList<int> list = new MyLinkedList<int>();
            for(int i = 0; i < notes.Count; i++)
            {
                list.Add(i);
            }

            MyLinkedList<int>[] qList = new MyLinkedList<int>[256]; //Создаём массив из 256 очередей для работы с байтами

            for (int i = 0; i < 256; i++)
            {
                qList[i] = new MyLinkedList<int>();
            }

            for (int j = size - 1; j >= 0; j--) //Каждый байт анализируется справа налево <-
            {
                for (int i = 0; i < notes.Count; i++)
                {
                    int k = list[i];
                    byte bt;
                    if(j >= size - 2)
                    {
                        bt = notes[k].Amount[size - j - 1];
                    }
                    else
                    {
                        bt = notes[k].Lawyer[j];
                    }
                    qList[(int)bt].Add(k);
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

            MyLinkedList<Note> sortedNotes = new MyLinkedList<Note>();

            for (int i = 0; i < notes.Count; i++)
            {
                sortedNotes.Add(notes[list[i]]);
            }
            return sortedNotes;
        }*/
    }
}