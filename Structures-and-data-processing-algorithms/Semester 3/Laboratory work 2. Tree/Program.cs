using RandomTree.Data_structs;
using System.ComponentModel.DataAnnotations;

namespace RandomTree
{
    internal class Program
    {
        public unsafe static void Main(string[] args)
        {
            TreeRand<int> randomTree = new(1);
            randomTree.Delete(randomTree._root, );

            Console.ReadLine();
        }
    }
}
