namespace RandomTree.Data_structs
{
    public class IBSTree<T> where T : IComparable<T>
    {
        private TreeNode<int> _root;
        private TreeNode<int> _pointer;

        public IBSTree()
        {
            _root = new TreeNode<int>();
        }

        public void Add(int L, int R)
        {
            int m = (L + R) / 2;
            _root.Value = m;
            _root.Left = Add2(L, m - 1);
            _root.Right = Add2(m + 1, R);
        }

        public TreeNode<int> Add2(int L, int R)
        {
            if (L > R)
            {
                return null;
            }
            else
            {
                int number = (L + R) / 2;
                var newNode = new TreeNode<int>(number);
                newNode.Left = Add2(L, number - 1);
                newNode.Right = Add2(number + 1, R);
                return newNode;
            }
        }

        public bool FindNode(T value)
        {
            _pointer = _root;
            while (true)
            {
                if (_pointer.Value.CompareTo(value) > 0)
                {
                    if (_pointer.Left is null)
                    {
                        break;
                    }
                    else
                    {
                        _pointer = _pointer.Left;
                    }
                }
                else if (_pointer.Value.CompareTo(value) < 0)
                {
                    if (_pointer.Right is null)
                    {
                        break;
                    }
                    else
                    {
                        _pointer = _pointer.Right;
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
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

        public void Show(TreeNode<int> treeNode)
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

        public int Size(TreeNode<int> treeNode)
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

        public int CheckSum(TreeNode<int> treeNode)
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

        public int HeightsOfTree(TreeNode<int> treeNode)
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

        public int SumOfLenPaths(TreeNode<int> treeNode, int L)
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
