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
    public partial class ProfileView : Window
    {

        public Student temp;
        public Student student;
        public ProfileView(Student p)
        {
            temp = p;
            InitializeComponent();
            
            
            using (var context = new mainEntities())
            {
                student = context.Students
                                   .Where(s => s.StudentID == temp.StudentID)
                                   .FirstOrDefault<Student>();
            }
            DataContext = student;


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1()
        {

        }
    }
}
