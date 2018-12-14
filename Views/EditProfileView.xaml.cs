#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Shared;

namespace DataBindingDemo
{
    /// <summary>
    /// Interaction logic for NewsView.xaml
    /// </summary>
    public partial class EditProfileView : UserControl
    {
        public EditProfileView()
        {
            InitializeComponent();
        }
        private void NameMask_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.Key >= 44 && (int)e.Key <= 69 || e.Key == Key.Space)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void RollNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((int)e.Key >= 74 && (int)e.Key <= 83)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void MaskedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void MaskedTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
