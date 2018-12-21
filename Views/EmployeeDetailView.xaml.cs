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
using System.Net;
using System.Xml.Linq;
using System.Windows.Threading;
using Syncfusion.Windows.Shared;
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid.Helpers;
using Syncfusion.UI.Xaml.Grid;
using System.Data.SQLite;

namespace DataBindingDemo
{
    /// <summary>
    /// Interaction logic for EmployeeDetailView.xaml
    /// </summary>
    public partial class EmployeeDetailView : UserControl
    {

        public List<string> Tags;
        mainEntities entities = new mainEntities();
        private void loadData()
        {
            datagrid_empdetail.DataContext = entities.Employees;
            datagrid_empdetail.ItemsSource = entities.Employees.ToList();
        }

        public EmployeeDetailView()
        {
            InitializeComponent();
            Tags = new List<string> { "FirstName", "LastName", "Gender" };
            search.ItemsSource = Tags;
            loadData();

        }

        private void Btn1_Click_empdetail(object sender, RoutedEventArgs e)
        {
            if (search.SelectedItem != null)
            {
                datagrid_empdetail.ClearFilters();
                datagrid_empdetail.Columns[search.SelectedItem.ToString()].FilterPredicates.Add(new FilterPredicate() { FilterType = FilterType.Contains, FilterValue = filter_empdetail.Text.ToString(), FilterBehavior = FilterBehavior.StringTyped });

            }

        }

        private void Btn2_Click_empdetail(object sender, RoutedEventArgs e)
        {
            if (search.SelectedItem != null)
            {
                datagrid_empdetail.ClearFilters();

            }

        }

        private void BtnRefresh_Click_empdetail(object sender, RoutedEventArgs e)
        {
            loadData();
            datagrid_empdetail.View.Refresh();
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var visualcontainer = this.datagrid_empdetail.GetVisualContainer();
            
            // get the row and column index based on the pointer position 
            var rowColumnIndex = visualcontainer.PointToCellRowColumnIndex(e.GetPosition(visualcontainer));
            if (rowColumnIndex.IsEmpty)
                return;
            var colindex = this.datagrid_empdetail.ResolveToGridVisibleColumnIndex(rowColumnIndex.ColumnIndex);
            if (colindex < 0 || colindex >= this.datagrid_empdetail.Columns.Count)
                return;

            var recordindex = this.datagrid_empdetail.ResolveToRecordIndex(rowColumnIndex.RowIndex);
            if (recordindex < 0)
                return;

            var recordentry = this.datagrid_empdetail.View.GroupDescriptions.Count == 0 ? this.datagrid_empdetail.View.Records[recordindex] : this.datagrid_empdetail.View.TopLevelGroup.DisplayElements[recordindex];

            //Returns if caption summary or group summary row encountered.
            if (!recordentry.IsRecords)
                return;

            //Underlying business data (In this case OrderInfo)
            var record = (recordentry as RecordEntry).Data;
            var profile = new ProfileView((Student)record);
            profile.Show();

        }
    }
}
