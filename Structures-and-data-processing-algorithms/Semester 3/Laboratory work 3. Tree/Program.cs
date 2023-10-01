using RandomTree2.Data_structs;
using System.ComponentModel.DataAnnotations;

namespace RandomTree2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TreeRand<int> randomTree = new();

            randomTree.Add(2);
            randomTree.Add(8);
            randomTree.Add(11);
            randomTree.Add(5);
            randomTree.Add(1);
            randomTree.Add(6);

            randomTree.PrintTree();
            Console.WriteLine();

            randomTree.Delete(8);
            randomTree.PrintTree();

            Console.ReadLine();
        }
    }
}
