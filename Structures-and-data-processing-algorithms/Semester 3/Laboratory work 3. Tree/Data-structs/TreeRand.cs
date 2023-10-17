using System;
using System.Drawing;
using System.Reflection;
using System.Xml.Linq;

namespace RandomTree2.Data_structs
{
    public class TreeRand<T> where T : IComparable<T>
    {
        public TreeNode<T>? Root;
        private TreeNode<T>? _pointer;

        public TreeRand(T value)
        {
            Root = new TreeNode<T>(value);
        }

        public TreeRand()
        {
 
        }

        //Методы с перегрузками: ===============================================================================================

        public int Size() => Size(Root); //Количество узлов в дереве

        public void AddRec(T value) => AddRec(ref Root, value); //Метод рекурентного добавления узла

        public TreeNode<T> Delete(T key) => Delete(Root, key); //Удаление узла дерева по ключу key

        public void Show() => Show(Root); // Вывод дерева с лева на право 

        public int CheckSum() => CheckSum(Root); // Контрольная сумма

        public int HeightsOfTree() => HeightsOfTree(Root); //Высота дерева

        public void PrintTree() => PrintTree(Root); //Графический вывод дерева

        //Основные алгоритмы методов с передачей ссылок в параметрах: ==========================================================

        public void PrintTree(TreeNode<T> startNode, string indent = "", Side? side = null)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Value}");
                indent += new string(' ', 3);
                PrintTree(startNode.Left, indent, Side.Left);
                PrintTree(startNode.Right, indent, Side.Right);
            }
        }

        public void Add(T value) //добавление с двойной косвенностью
        {
            if (Root == null)
            {
                Root = new TreeNode<T>(value);
                return;
            }

            _pointer = Root;
            var newNode = new TreeNode<T>(value);

            while (true)
            {
                if (_pointer.Value.CompareTo(value) > 0)
                {
                    if(_pointer.Left is null)
                    {
                        _pointer.Left = newNode;
                        break;
                    }
                    else
                    {
                        _pointer = _pointer.Left;
                    }
                }
                else 
                {
                    if (_pointer.Right is null)
                    {
                        _pointer.Right = newNode;
                        break;
                    }
                    else
                    {
                        _pointer = _pointer.Right;
                    }
                }
            }
        }

        public TreeNode<T> Delete(TreeNode<T> node, T key)
        {
            if(node == null)
            {
                return null;
            }
            else if(node.Value.CompareTo(key) > 0)
            {
                node.Left = Delete(node.Left, key);
            }
            else if(node.Value.CompareTo(key) < 0)
            {
                node.Right = Delete(node.Right, key);
            }
            else
            {
                if(node.Left == null || node.Right == null)
                {
                    node = (node.Left == null) ? node.Right : node.Left;
                }
                else
                {
                    TreeNode<T> maxInLeft = GetMax(node.Left);
                    node.Value = maxInLeft.Value;
                    node.Left = Delete(node.Left, maxInLeft.Value);
                }
            }
            return node;
        }

        private TreeNode<T> GetMin(TreeNode<T> node) //Поиск минимального элемента
        {
            if (node == null)
            {
                return null;
            }
            if(node.Left == null)
            {
                return node;
            }
            return GetMin(node.Left);
        }

        private TreeNode<T> GetMax(TreeNode<T> node) //Поиск максимального элемента
        {
            if (node == null)
            {
                return null;
            }
            if (node.Right == null)
            {
                return node;
            }
            return GetMax(node.Right);
        }

        public TreeNode<T> Find(TreeNode<T> node, T key)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value.CompareTo(key) == 0)
            {
                return node;
            }
            else
            {
                return (node.Value.CompareTo(key) < 0) ? Find(node.Right, key) : Find(node.Left, key);
            }
        }

        private void AddRec(ref TreeNode<T> currentNode, T value)
        {
            if(currentNode ==  null)
            {
                currentNode = new TreeNode<T>(value);
                return;
            }
            if(currentNode.Value.CompareTo(value) > 0)
            {   
                AddRec(ref currentNode.Left, value);
            }
            else
            {
                AddRec(ref currentNode.Right, value);
            }
        }

        private void Show(TreeNode<T> treeNode)
        {
            if (treeNode != null)
            {
                Show(treeNode.Left);
                Console.Write(treeNode.Value + " ");
                Show(treeNode.Right);
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

        private int CheckSum(TreeNode<T> treeNode)
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

        private int HeightsOfTree(TreeNode<T> treeNode)
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

        private int SumOfLenPaths(TreeNode<T> treeNode, int L)
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
            return SumOfLenPaths(Root, 1) / (double)Size(Root);
        }
    }

    public enum Side
    {
        Left,
        Right
    }
}
