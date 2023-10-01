using System.Reflection;

namespace RandomTree.Data_structs
{
    public class TreeRand<T> where T : IComparable<T>
    {
        public TreeNode<T> _root;
        private TreeNode<T> _pointer;

        public TreeRand(T value)
        {
            _root = new TreeNode<T>(value);
        }

        public void Add(T value) //добавление с двойной косвенностью
        {
            _pointer = _root;
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

        public void AddRec(T value) => AddRec(ref _root, value);


        private void AddRec(ref TreeNode<T> currentNode, T value)
        {
            if(currentNode is null)
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
                else if(_pointer.Value.CompareTo(value) < 0)
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

        /*public TreeNode<T> Delete(TreeNode<T> treeNode, T key)
        {
            
            
        }*/

        public void Show()
        {
            if (_root != null)
            {
                Show(_root.Left);
                Console.Write(_root.Value + " ");
                Show(_root.Right);
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
