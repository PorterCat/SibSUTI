using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IBSTree.Tree
{
    internal class TreeNodeVM
    {        
        public string Name { get; set; }
        public List<TreeNodeVM> Children { get; set; } = new List<TreeNodeVM>();
    }

}
