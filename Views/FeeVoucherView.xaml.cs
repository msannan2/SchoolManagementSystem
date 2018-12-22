using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataBindingDemo
{
    /// <summary>
    /// Interaction logic for FeeVoucherView.xaml
    /// </summary>
    public partial class FeeVoucherView : Window
    {
        Student student;
        public FeeVoucherView(Student p)
        {
            InitializeComponent();
            student = p;
            DataContext = student;

        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            btn.Visibility = Visibility.Hidden;
            PrintCharts(ReportPanel);
        }
        private void PrintCharts(Grid grid)
        {

            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() == true)
            {
                PrintCapabilities capabilities = print.PrintQueue.GetPrintCapabilities(print.PrintTicket);

                double scale = 1.1;
                Transform oldTransform = grid.LayoutTransform;

                grid.LayoutTransform = new ScaleTransform(scale, scale);

                Size oldSize = new Size(grid.ActualWidth, grid.ActualHeight);
                Size sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);
                grid.Measure(sz);
                ((UIElement)grid).Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight),
                    sz));

                print.PrintVisual(grid, "Print Results");
                grid.LayoutTransform = oldTransform;
                grid.Measure(oldSize);

                ((UIElement)grid).Arrange(new Rect(new Point(0, 0),
                    oldSize));
            }
        }
    }
}
