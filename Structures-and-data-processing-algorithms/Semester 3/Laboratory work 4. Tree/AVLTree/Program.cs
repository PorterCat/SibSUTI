using AVLTree.Data_structs;
using System.ComponentModel.DataAnnotations;

namespace AVLTree
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string str = "мищукандрейв";

            AVLTree<char> tree = new();

            Random random = new Random();

            for (int i = 0; i < str.Length; i++)
            {
                tree.Add(str[i]);
            }

            tree.PrintTree();

            Console.WriteLine();

            //tree.PrintTree();
            //Console.WriteLine($"Средняя высота: {tree.AverageHeight()}");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Enter the key: ");
                string x = Console.ReadLine();

                tree.Root = tree.Delete(tree.Root, Char.Parse(x));
                tree.PrintTree();
            }



            Console.ReadLine();
        }
    }
}
