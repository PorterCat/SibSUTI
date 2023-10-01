using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    internal class Tree<T> where T : IComparable<T> 
    {
        private readonly TreeNode<T> _root;
        private TreeNode<T> _currentNode;

        public Tree(T value)
        {
            TreeNode<T> newNode = new TreeNode<T>(value);
            _root = newNode;
            _currentNode = _root;
            _currentNode.Right = null;
            _currentNode.Left = null;
        }

        public Tree(TreeNode<T> value)
        {
            _root = value;
        }

            public void BackToRoot()
        {
            _currentNode = _root;
        }

        public void ShowUpToDown()
        {
            if(_root != null)
            {
                Console.Write(_root.Value + " ");
                ShowUpToDown(_root.Left);
                ShowUpToDown(_root.Right);
            }
        }

        public void ShowUpToDown(TreeNode<T> treeNode)
        {
            if (treeNode != null)
            {
                Console.Write(treeNode.Value + " ");
                ShowUpToDown(treeNode.Left);
                ShowUpToDown(treeNode.Right);
            }
        }

        public void ShowLUpToR()
        {
            if (_root != null)
            {
                ShowLUpToR(_root.Left);
                Console.Write(_root.Value + " ");
                ShowLUpToR(_root.Right);
            }
        }

        public void ShowLUpToR(TreeNode<T> treeNode)
        {
            if (treeNode != null)
            {
                ShowLToR(treeNode.Left);
                Console.Write(treeNode.Value + " ");
                ShowLUpToR(treeNode.Right);
            }
        }


        public void ShowLToR()
        {
            if (_root != null)
            {
                ShowLToR(_root.Left);
                ShowLToR(_root.Right);
                Console.Write(_root.Value + " ");
            }
        }

        public void ShowLToR(TreeNode<T> treeNode)
        {
            if (treeNode != null)
            {
                ShowLToR(treeNode.Left);
                ShowLToR(treeNode.Right);
                Console.Write(treeNode.Value + " ");
            }
        }


        public int Size(TreeNode<T> treeNode)
        {
            if (treeNode != null)
            {
                _currentNode = treeNode;
                return 1 + Size(_currentNode.Left) + Size(_currentNode.Right);
            }
            else
            {
               return 0;
            }
        }

        public int Size()
        {
            if (_root != null)
            {
                _currentNode = _root;
                return 1 + Size(_currentNode.Left) + Size(_currentNode.Right);
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
                _currentNode = treeNode;
                return Convert.ToInt32(_currentNode.Value) + CheckSum(_currentNode.Left) + CheckSum(_currentNode.Right);
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
                _currentNode = _root;
                return Convert.ToInt32(_currentNode.Value) + CheckSum(_currentNode.Left) + CheckSum(_currentNode.Right);
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
            return (SumOfLenPaths(_root, 1)/(double)Size(_root));
        }


    }
}
