using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IBSTree.Tree
{
    public class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;

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
