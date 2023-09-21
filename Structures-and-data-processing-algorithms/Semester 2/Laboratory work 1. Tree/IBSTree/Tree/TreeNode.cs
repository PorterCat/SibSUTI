using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSTree.Tree
{
    public class TreeNode<T> where T: IComparable<T>
    {
        public int Value;
        public TreeNode<T> Left;
        public TreeNode<T> Right;

        public TreeNode()
        {
            Left = null;
            Right = null;
        }

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
}
