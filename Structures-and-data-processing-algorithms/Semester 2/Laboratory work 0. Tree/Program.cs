using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Tree<int> tree = new Tree<int>(10);

            tree.AddRight(20);
            tree.AddLeft(15);
            tree.AddRight(19);
            tree.AddLeft(18);
            tree.AddLeft(17);

            tree.ShowUpToDown();
            Console.Write('\n');
            tree.ShowLUpToR();
            Console.Write('\n');
            tree.ShowLToR();
            Console.Write('\n');


            Console.Write('\n');
            Console.WriteLine("Size: " + tree.Size());
            Console.WriteLine("CheckSum: " + tree.CheckSum());
            Console.WriteLine("Height: " + tree.HeightsOfTree());
            Console.WriteLine("Lens " + tree.SumOfLenPaths(1));
            Console.WriteLine("Avr height: " + tree.AverageHeight());

            Console.ReadLine();
        }
    }
}
