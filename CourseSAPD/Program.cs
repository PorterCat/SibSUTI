using CourseSAPD.NavigationSystem.Scenes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CourseSAPD
{
    internal class Program
    {
        private static readonly string _filePath = @"C:\Programming\SibSUTI\CourseSAPD\testBase3.dat";

        static void Main(string[] args)
        {
            Parser parser = new Parser(_filePath, Encoding.GetEncoding("cp866"));
            MyQueue<Note> list = parser.ParseFile();

            MainScene mainScene = new MainScene(list);
            mainScene.Start();

            Console.ReadLine();
        }

        /*public static void DigitalSort(ref MyQueue<Note> notes)
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
        }*/

    }
}
