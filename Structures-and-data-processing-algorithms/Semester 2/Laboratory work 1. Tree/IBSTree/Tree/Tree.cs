using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSTree.Tree
{
    public class Tree<T> where T : IComparable<T>
    {

        private TreeNode<T> _pointer;

        public TreeNode<T> Root { get; set; }

        public Tree()
        {
            _pointer = new TreeNode<T>();
            Root = _pointer;
        }

        public void Add(int L, int R)
        {
            int m = (L + R) / 2;
            Root.Value = m;
            Root.Left = Add2(L, m - 1);
            Root.Right = Add2(m + 1, R);
        }

        public TreeNode<T> Add2(int L, int R)
        {
            if (L > R)
            {
                return null;
            }
            else
            {
                int number = (L + R) / 2;
                var newNode = new TreeNode<T>(number);
                newNode.Left = Add2(L, number - 1);
                newNode.Right = Add2(number + 1, R);
                return newNode;
            }
        }

        public void Show()
        {
            if (Root != null)
            {
                Show(Root.Left);
                Console.Write(Root.Value + " ");
                Show(Root.Right);
            }
        }

        public void Show(TreeNode<T> treeNode)
        {
            if (treeNode != null)
            {
                Show(treeNode.Left);
                Console.Write(treeNode.Value + " ");
                Show(treeNode.Right);
            }
        }

        public int Size()
        {
            if (Root != null)
            {
                _pointer = Root;
                return 1 + Size(_pointer.Left) + Size(_pointer.Right);
            }
            else
            {
                return 0;
            }
        }

        public int Size(TreeNode<T> treeNode)
        {
            if (treeNode != null)
            {
                return 1 + Size(treeNode.Left) + Size(treeNode.Right);
            }
            else
            {
                return 0;
            }
        }

        public int CheckSum()
        {
            if (Root != null)
            {
                return Convert.ToInt32(Root.Value) + CheckSum(Root.Left) + CheckSum(Root.Right);
            }
            else
            {
                return 0;
            }
        }

        public int CheckSum(TreeNode<T> treeNode)
        {
            if (treeNode != null)
            {
                return Convert.ToInt32(treeNode.Value) + CheckSum(treeNode.Left) + CheckSum(treeNode.Right);
            }
            else
            {
                return 0;
            }
        }

        public int HeightsOfTree()
        {
            if (Root != null)
            {
                return 1 + Math.Max(HeightsOfTree(Root.Left), HeightsOfTree(Root.Right));
            }
            else
            {
                return 0;
            }
        }

        public int HeightsOfTree(TreeNode<T> treeNode)
        {
            if (treeNode != null)
            {
                return 1 + Math.Max(HeightsOfTree(treeNode.Left), HeightsOfTree(treeNode.Right));
            }
            else
            {
                return 0;
            }
        }

        public int SumOfLenPaths(int L)
        {
            if (Root != null)
            {
                return L + SumOfLenPaths(Root.Left, L + 1) + SumOfLenPaths(Root.Right, L + 1);
            }
            else
            {
                return 0;
            }
        }

        public int SumOfLenPaths(TreeNode<T> treeNode, int L)
        {
            if (treeNode != null)
            {
                return L + SumOfLenPaths(treeNode.Left, L + 1) + SumOfLenPaths(treeNode.Right, L + 1);
            }
            else
            {
                return 0;
            }
        }

        public double AverageHeight()
        {
            return (SumOfLenPaths(Root, 1) / (double)Size(Root));
        }
    }
}
