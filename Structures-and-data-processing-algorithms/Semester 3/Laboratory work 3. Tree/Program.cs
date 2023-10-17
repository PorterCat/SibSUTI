using RandomTree2.Data_structs;
using System.ComponentModel.DataAnnotations;

namespace RandomTree2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random random = new();

            TreeRand<int> randomTree = new();


            for(int i = 0; i < 10; i++)
            {
                randomTree.Add(random.Next(1, 20));
            }    

            randomTree.PrintTree();

            for(int i = 0; i < 100; i++)
            {
                Console.WriteLine("Enter the key: ");
                string x = Console.ReadLine();

                randomTree.Root = randomTree.Delete(randomTree.Root, int.Parse(x));
                randomTree.PrintTree();
            }

            Console.WriteLine();
        }
    }
}
