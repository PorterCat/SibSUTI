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
        static void Main(string[] args)
        {

            MyLinkedList<Note> notes = new MyLinkedList<Note>();  
            ParseFile(notes);

            notes = DigitalSort(notes);

            for (int i = 0; i < 4000; i++)
            {
                Console.Write((i + 1) + ". ");
                notes[i].Show();
            }

            Console.ReadKey();
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

        private static MyLinkedList<Note> DigitalSort(MyLinkedList<Note> notes)
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
        }
    }
}