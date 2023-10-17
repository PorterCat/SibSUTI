using System;

namespace AVLTree.Data_structs
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T Value;
        public int Height;
        public TreeNode<T> Left;
        public TreeNode<T> Right;

        public TreeNode()
        {
            Left = null;
            Right = null;
        }

        public TreeNode(T value)
        {
            Value = value;
            Height = 0;
            Left = null;
            Right = null;
        }

    }
}
