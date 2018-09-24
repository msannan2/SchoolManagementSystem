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
using System.Collections.ObjectModel;

namespace DataBindingDemo
{
    public class ViewModel
    {
        private ObservableCollection<ApplicationTile> apps;

        public ObservableCollection<ApplicationTile> Applications
        {
            get { return apps; }
            set { apps = value; }
        }

        public ViewModel()
        {
            Applications = new ObservableCollection<ApplicationTile>();
            Applications.Add(new ApplicationTile() { Name = "Admissions", Color = "#FF4DAEB5", View = new NewsView(), Header = "New Admission", Icon = "/Images/account-multiple-plus-(1).png", Description = "Add a Student Record" });
            Applications.Add(new ApplicationTile() { Name = "Fee", Color = "#FF36377C", Icon = "/Images/file-document-box.png", Header = "Fee Vouchers", Description = "Print Fee Vouchers and Fee Collection  ", View = new WeatherView() });
            Applications.Add(new ApplicationTile() { Name = "Stats", Color = "#FFD68513", Icon = "/Images/chart-areaspline.png", View = new StockView(), Description = "School Statistics and Reports  ", Header = "School Report"});
            Applications.Add(new ApplicationTile() { Name = "Records", Color = "#FF555BBE", Icon = "/Images/file-account.png", Header="Student Records", Description = "Manage Student Records", View = new TwitterView() });
            Applications.Add(new ApplicationTile() { Name = "Staff", Color = "green", Icon = "/Images/account-card-details.png", View = new GalleryView(), Header = "Teachers", Description = "Manage Staff Records", CanSlide = false});
            Applications.Add(new ApplicationTile() { Name = "Schedule", Color = "#FF02478A", Icon = "/Images/calendar-clock.png", View = new BrowserView(), Header = "Time Table" , Description = "Manage Time Tables and Academic Calendar  " });
            Applications.Add(new ApplicationTile() { Name = "Attendance", Header = "Attendance", Color = "#FF9AB534", Icon = "/Images/calendar-multiple-check.png", View = new ComputerView(),Description = "Manage Student and Staff attendance  " });
            Applications.Add(new ApplicationTile() { Name = "Notifications", Color = "#FF7D35B2", Icon = "/Images/email-alert.png", Header = "Send SMS", View = new StoreView(), Description = "Send Anouncements and Reminders via SMS  " });
            Applications.Add(new ApplicationTile() { Name = "Settings", Color = "#FF781768", View = new VideosView(), Icon = "/Images/wrench.png", Description = "Change Application Settings", Header = "Preferences" });
        }
       
    }
}
