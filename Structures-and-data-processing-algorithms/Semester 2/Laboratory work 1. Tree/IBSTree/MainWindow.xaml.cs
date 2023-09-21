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

            var tree = new Tree<int>();
            tree.Add(1, 100);

            Canvas canvas = new Canvas();
            Grid1.Children.Add(canvas);

            int left = (int)this.Width / 2;
            int top = 0;

            Ellipse nodeRoot = new Ellipse { Width = 20, Height = 20, Fill = Brushes.Red }; //Корень
            canvas.SetLeft(nodeRoot, left);
            canvas.SetTop(nodeRoot, top);
            canvas.Children.Add(nodeRoot);
            top += 50;

            //С помощью высоты узнаем выоту дерева. Выделяем примерно одинаковое количество место под в пределах [0; Width]

            int height = tree.HeightsOfTree();

            for (int i = 1; i < height - 1; i++)
            {
                int interval = (int)((int)this.Width / (Math.Pow(2, i) + 1));
                left = interval;
                for (int j = 0; j < Math.Pow(2, i); j++)
                {
                    Ellipse nodeEl = new Ellipse { Width = 20, Height = 20, Fill = Brushes.Red };
                    canvas.SetLeft(nodeEl, left);
                    canvas.SetTop(nodeEl, top);
                    canvas.Children.Add(nodeEl);
                    left += interval;
                }
                top += 50;
            }

        }
    }
}
