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
           
            TreeNode<int> root = new TreeNode<int>(2);

            root.Left =  new TreeNode<int>(1);
            root.Right = new TreeNode<int>(3);
            root.Right.Left = new TreeNode<int>(4);
            root.Right.Right = new TreeNode<int>(6);
            root.Right.Left.Right = new TreeNode<int>(5);
            root.Right.Right.Left = new TreeNode<int>(7);

            Tree<int> tree = new Tree<int>(root);
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
