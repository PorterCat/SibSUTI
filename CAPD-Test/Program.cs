using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
            List<Note> notes = new List<Note>();  
            ParseFile(notes);

            notes = DigitalSort(notes);

            for (int i = 0; i < 4000; i++)
            {
                Console.Write((i + 1) + ". ");
                notes[i].Show();
            }

            Console.ReadKey();
            
        }

        private static List<Note> ParseFile(List<Note> notes)
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
                note.Amount = BitConverter.ToUInt16(fileElements[i + 1].GetRange(0, 2).ToArray(), 0);
                note.Date = _cpp866.GetString(fileElements[i + 1].GetRange(2, fileElements[i + 1].Count - 2).ToArray());
                note.Lawyer = _cpp866.GetString(fileElements[i + 2].ToArray());

                notes.Add(note);
            }
            return notes;
        }

        private static List<Note> DigitalSort(List<Note> notes)
        {
            //Алгороитм:
            // 1. Получаем исходный массив с нотами (сортировать их будем по индексам => следовательно формируем словарь (или индексный массив)
            // 2. Сортировка по 3 первым ФИО адвоката и сумма вклада. Ключ поиска для дерево кстати K = 3 буквы ФИО адвоката
            // 3. Представляем данные через байты и работаем через очереди.
            // 4.1 Более глубокий алгоритм для себя

            var list = new List<int>(); // Лист последовательности 

            Dictionary<int, byte[]> byteLawyer = new Dictionary<int, byte[]>();
            for (int i = 0; i < notes.Count; i++)
            {

                list.Add(i);
                int size = notes[i].Lawyer.Length;
                byte[] bytes = new byte[size];
                for (int j = 0; j < size; j++)
                {
                    bytes[j] = (byte)notes[i].Lawyer[j]; // Заносим буквы как байты в массив байтов
                }
                byteLawyer.Add(i, bytes);
            }

            for (int j = 3; j >= 0; j--) //Каждый байт анализируется справа налево <-
            {

                var qList = new List<Queue<int>>(256); //Создаём 256 очередей для работы с байтами
                for (int i = 0; i < 256; i++)
                {
                    qList.Add(new Queue<int>());
                }

                for (int i = 0; i < notes.Count; i++)
                {
                    int k = list[i];
                    qList[(int)byteLawyer[k][j]].Enqueue(k);
                }

                list.Clear(); // Очищаем лист. Каждый раз в нём формируется новая последовательность, которая рано или поздно станет упорядоченной

                for (int i = 0; i < 256; i++)
                {
                    if (qList[i].Count > 0)
                    {
                        list.AddRange(qList[i]);
                    }
                    // Вот наши очереди 1->2->3 и 4->5->6       Лист пуст |->Null   Но с помощью AddRange мы последовательно добавляем структуры очередей в него
                    // итого: лист |-1->2->3->4->5->6->Null и так далее.
                }
            }

            List<Note> sortedNotes = new List<Note>();

            var forSecondParametr = new List<Note>(); //Формируем лист из одинаковых значений, чтобы отсортировать их по второму параметру по сумме вклада
            int index = 1;
            while (index < notes.Count)
            {

                if (notes[list[index]].Lawyer == notes[list[index - 1]].Lawyer)
                {
                    while (notes[list[index]].Lawyer == notes[list[index - 1]].Lawyer)
                    {
                        forSecondParametr.Add(notes[list[index-1]]);
                        index++;
                        if(index == 4000)
                        {
                            forSecondParametr.Add(notes[list[index-1]]);
                            sortedNotes.AddRange(DigitalSort2(forSecondParametr));
                            forSecondParametr.Clear();
                            return sortedNotes;
                        }
                    }

                    forSecondParametr.Add(notes[list[index-1]]);
                    sortedNotes.AddRange(DigitalSort2(forSecondParametr));
                    forSecondParametr.Clear();
                    index++;
                    if(index == 4000)
                    {
                        sortedNotes.Add(notes[list[index-1]]);
                        break;
                    }
                }
                else
                {
                    sortedNotes.Add(notes[list[index-1]]);
                    index++;
                    if(index == 4000)
                    {
                        sortedNotes.Add(notes[list[index - 1]]);
                        break;
                    }
                }
            }

            return sortedNotes;
        }

        private static List<Note> DigitalSort2(List<Note> notes)
        {
            var list = new List<int>(); 

            Dictionary<int, string> strLawyer = new Dictionary<int, string>();
            for (int i = 0; i < notes.Count; i++)
            {
                list.Add(i); 
                string str = notes[i].Amount.ToString("D5");
                strLawyer.Add(i, str);
            }

            for (int j = 4; j >= 0; j--)
            {

                var qList = new List<Queue<int>>(256); 
                for (int i = 0; i < 256; i++)
                {
                    qList.Add(new Queue<int>());
                }

                for (int i = 0; i < notes.Count; i++)
                {
                    int k = list[i];
                    qList[(int)strLawyer[k][j]].Enqueue(k);
                }

                list.Clear(); 

                for (int i = 0; i < 256; i++)
                {
                    if (qList[i].Count > 0)
                    {
                        list.AddRange(qList[i]);
                    }
                }
            }

            List<Note> sortedNotes = new List<Note>();

            for (int i = 0; i < notes.Count; i++)
            {
                sortedNotes.Add(notes[list[i]]);
            }

            return sortedNotes;
        }
    }
}