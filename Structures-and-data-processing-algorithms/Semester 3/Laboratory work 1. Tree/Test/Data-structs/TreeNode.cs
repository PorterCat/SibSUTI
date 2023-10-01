using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Test.Data_structs
{
    public class TreeNode<T> where T : IComparable<T>
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
