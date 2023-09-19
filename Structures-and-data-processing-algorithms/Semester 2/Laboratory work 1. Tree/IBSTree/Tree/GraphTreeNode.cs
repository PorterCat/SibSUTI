using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace IBSTree.Tree
{
    public class GraphTreeNode : UserControl
    {
        public GraphTreeNode()
        {
            
        }

        public Ellipse Ellipse { get; set; }
        public string Text { get; set; }

    }
}
