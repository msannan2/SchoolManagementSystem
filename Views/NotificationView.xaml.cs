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
    
    public partial class NotificationView : UserControl
    {
        NotificationViewModel notify;
        string message, subject;
        public NotificationView()
        {
            InitializeComponent();
            notify = new NotificationViewModel();
            DataContext = notify;
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            message = msg.Text.ToString();
            subject = sub.Text.ToString();
            notify.recipients.Clear();
            if((bool)(chkemployees.IsChecked))
            {
                notify.recipients.Add(notify.employee);
            }
            if ((bool)(chkparents.IsChecked))
            {
                notify.recipients.Add(notify.parent);
            }
            if ((bool)(chkteachers.IsChecked))
            {
                notify.recipients.Add(notify.teacher);
            }
            if(message!=null)
            notify.UpdateAll(message,subject);
            else
            {
                MessageBox.Show("Please Enter a Message");
            }
        }
    }
}