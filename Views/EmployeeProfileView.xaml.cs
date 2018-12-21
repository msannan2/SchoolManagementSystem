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
using System.Windows.Shapes;

namespace DataBindingDemo
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class EmployeeProfileView : Window
    {
        
        public Employee employee;

        public EmployeeProfileView(Employee p)
        {
            InitializeComponent();

            employee = p;

            DataContext = employee;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1()
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MaskedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
