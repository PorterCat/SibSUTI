using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data_structs;
using Test.Extensions;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new Tree<int>(); // Создаем дерево без корня

            tree.Add(1, 100); //на обработку передаем цифры в массиве
            tree.Show();
            Console.WriteLine($"\nSize: {tree.Size()} CheckSum: {tree.CheckSum()} Height: {tree.HeightsOfTree()} Avr. height: {tree.AverageHeight()}");
            Console.ReadLine();
        }
    }
}
