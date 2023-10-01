using System;

namespace Tree
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T Value;
        public TreeNode<T> Left;
        public TreeNode<T> Right;


        public TreeNode(T value) 
        { 
            Value = value;
        }
    }
}