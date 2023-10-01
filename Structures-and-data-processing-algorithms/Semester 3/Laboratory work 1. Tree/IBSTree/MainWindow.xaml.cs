using IBSTree.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace IBSTree
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var treeRoot = new TreeNode(1);
            treeRoot.Left = new TreeNode(2);
            treeRoot.Right = new TreeNode(3);
            treeRoot.Left.Left = new TreeNode(4);

            var rootNode = new TreeNodeVM { Name = treeRoot.Value.ToString() };
            var rootChildLeft = new TreeNodeVM { Name = treeRoot.Left.Value.ToString() };
            var rootChildRight = new TreeNodeVM { Name = treeRoot.Right.Value.ToString() };
            var rootChildLeftLeft = new TreeNodeVM { Name = treeRoot.Left.Left.Value.ToString() };

            rootNode.Children.Add(rootChildLeft);
            rootNode.Children.Add(rootChildRight);
            rootChildLeft.Children.Add(rootChildLeftLeft);

            AddNodeToTreeView(rootNode, treeView);
            AddNodeToTreeView(rootChildLeft, treeView);
            AddNodeToTreeView(rootChildRight, treeView);
            AddNodeToTreeView(rootChildLeftLeft, treeView);

        }

        private void AddNodeToTreeView(TreeNodeVM node, TreeView treeView)
        {
            var newItem = new TreeViewItem()
            {
                Header = node.Name
            };
            treeView.Items.Add(newItem);
        }
    }
}
