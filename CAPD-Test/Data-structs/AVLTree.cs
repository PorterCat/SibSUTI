using System;

namespace AVLTree.Data_structs
{
    public class AVLTree<T> where T : IComparable<T>
    {
        public TreeNode<T> Root;

        public AVLTree(T value)
        {
            Root = new TreeNode<T>(value);
        }

        public AVLTree()
        {

        }

        //Методы с перегрузками: ===============================================================================================

        public int Size() => Size(Root); //Количество узлов в дереве

        public void Add(T value) => Add(ref Root, value); //Метод рекурентного добавления узла

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

        //Методы АВЛ-дерева: ==========================================================

        private void Add(ref TreeNode<T> node, T value)
        {
            if (node == null)
            {
                node = new TreeNode<T>(value);
                return;
            }

            if (node.Value.CompareTo(value) > 0)
            {
                Add(ref node.Left, value);
            }
            else
            {
                Add(ref node.Right, value);
            }

            UpdateHeight(node);
            Balance(node);

        }

        private TreeNode<T> Delete(TreeNode<T> node, T key)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.Value.CompareTo(key) > 0)
            {
                node.Left = Delete(node.Left, key);
            }
            else if (node.Value.CompareTo(key) < 0)
            {
                node.Right = Delete(node.Right, key);
            }
            else
            {
                if (node.Left == null || node.Right == null)
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
            if(node != null)
            {
                UpdateHeight(node);
                Balance(node);
            }

            return node;
        }

        private void UpdateHeight(TreeNode<T> node)
        {
            node.Height = Math.Max(GetHeight(node.Left), GetHeight(node.Right)) + 1;
        }

        private int GetHeight(TreeNode<T> node)
        {
            return (node == null) ? -1 : node.Height;
        }

        private int GetBalance(TreeNode<T> node)
        {
            return (node == null) ? 0 : GetHeight(node.Right) - GetHeight(node.Left);
        }

        private void SwapNodes(TreeNode<T> a, TreeNode<T> b)
        {
            T t_value = a.Value;
            a.Value = b.Value;
            b.Value = t_value;
        }

        private void Balance(TreeNode<T> node)
        {
            int balance = GetBalance(node);
            if(balance == -2)
            {
                if(GetBalance(node.Left) == 1)
                {
                    LeftRotate(node.Left);
                }
                RightRotate(node);
            }
            else if(balance == 2)
            {
                if (GetBalance(node.Right) == -1)
                {
                    RightRotate(node.Right);
                }
                LeftRotate(node);
            }
        }

        private void RightRotate(TreeNode<T> node)
        {
            SwapNodes(node, node.Left);
            TreeNode<T> buffer = node.Right;
            node.Right = node.Left;
            node.Left = node.Right.Left;
            node.Right.Left = node.Right.Right;
            node.Right.Right = buffer;
            UpdateHeight(node.Right);
            UpdateHeight(node);
        }

        private void LeftRotate(TreeNode<T> node)
        {
            SwapNodes(node, node.Right);
            TreeNode<T> buffer = node.Left;
            node.Left = node.Right;
            node.Right = node.Left.Right;
            node.Left.Right = node.Left.Left;
            node.Left.Left = buffer;
            UpdateHeight(node.Left);
            UpdateHeight(node);
        }



    }

    public enum Side
    {
        Left,
        Right
    }
}
