using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data_structs
{
    public class Tree<T> where T : IComparable<T>
    {
        private TreeNode<T> _root;
        private TreeNode<T> _pointer;

        public Tree()
        {
            _pointer = new TreeNode<T>();
            _root = _pointer;
        }

        public void Add(int L, int R)
        {
            int m = (L + R) / 2;
            _root.Value = m;
            _root.Left = Add2(L, m - 1);
            _root.Right = Add2(m + 1, R);
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
            if (_root != null)
            {
                Show(_root.Left);
                Console.Write(_root.Value + " ");
                Show(_root.Right);
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
            if (_root != null)
            {
                _pointer = _root;
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
            if (_root != null)
            {
                return Convert.ToInt32(_root.Value) + CheckSum(_root.Left) + CheckSum(_root.Right);
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
            if (_root != null)
            {
                return 1 + Math.Max(HeightsOfTree(_root.Left), HeightsOfTree(_root.Right));
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
            if (_root != null)
            {
                return L + SumOfLenPaths(_root.Left, L + 1) + SumOfLenPaths(_root.Right, L + 1);
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
            return (SumOfLenPaths(_root, 1) / (double)Size(_root));
        }


    }
}
