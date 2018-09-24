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
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Syncfusion.Windows.Shared;
using Syncfusion.XlsIO;

namespace DataBindingDemo
{
    public class Person : NotificationObject, IDataErrorInfo
    {

        #region RegisterCommandValidation
        public void Fo()
        {
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
            else if (string.IsNullOrEmpty(fname))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
            else if (string.IsNullOrEmpty(grade) || grade.ToString() == "None")
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
            else if (string.IsNullOrEmpty(section) || section.ToString() == "None")
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
            else if (string.IsNullOrEmpty(age.ToString()) || age == 0)
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
            else if (string.IsNullOrEmpty(dob.ToString()) || (dob.Date <= DateTime.Parse("1/1/0001") || dob.Date >= DateTime.Today))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
            else if ((mobileno.ToString().Length < 10))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
            else if ((phoneno.ToString().Length < 10))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
            else if (string.IsNullOrEmpty(address.ToString()))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
            else if (string.IsNullOrEmpty(rollno))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
            else if (string.IsNullOrEmpty(stdid.ToString()) || stdid.ToString() == "0")
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
            else if (string.IsNullOrEmpty(fid.ToString()) || fid.ToString() == "0")
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                int err = Register();
                MessageBox.Show("Successfully Registered", "Information", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }
        #endregion

        public int Register()
        {
            string filename = "boggie2988.xlsx";
            ExcelEngine excelEngine = new ExcelEngine();

            IApplication application = excelEngine.Excel;
            IWorkbook workbook;
            IWorksheet mySheet;
            try
            {
                workbook = application.Workbooks.Open(filename);
                mySheet = workbook.Worksheets["Students"];
            }
            catch
            {
                application.DefaultVersion = ExcelVersion.Excel2013;

                //The new workbook will have 5 worksheets.

                workbook = application.Workbooks.Create(1);

                //Creating a Sheet.

                //Creating a Sheet with name “Sample”

                mySheet = workbook.Worksheets.Create("Students");
                mySheet.Range["A1"].Text = "Student ID";
                mySheet.Range["B1"].Text = "Name";
                mySheet.Range["C1"].Text = "Age";
                mySheet.Range["D1"].Text = "DOB";
                mySheet.Range["E1"].Text = "Father Name";
                mySheet.Range["F1"].Text = "Address";
                mySheet.Range["G1"].Text = "Roll No";
                mySheet.Range["H1"].Text = "Family ID";
                mySheet.Range["I1"].Text = "Class";
                mySheet.Range["J1"].Text = "Section";
                mySheet.Range["K1"].Text = "Phone No";
                mySheet.Range["L1"].Text = "Mobile No";
                
            }
            int i = mySheet.UsedRange.LastRow + 1;
            mySheet.Range[i, 1].Value2 = stdid;
            mySheet.Range[i, 2].Text = name;
            mySheet.Range[i, 3].Value2 = age;
            mySheet.Range[i, 4].Value2 = dob;
            mySheet.Range[i, 5].Text = fname;
            mySheet.Range[i, 6].Text = address;
            mySheet.Range[i, 7].Text = rollno;
            mySheet.Range[i, 8].Value2 = fid;
            mySheet.Range[i, 9].Text = grade;
            mySheet.Range[i, 10].Text = section;
            mySheet.Range[i, 11].Text = phoneno;
            mySheet.Range[i, 12].Text = mobileno;
            workbook.SaveAs(filename);
            workbook.Close();

            excelEngine.Dispose();
            return 0;
        }

        #region properties       
        private ObservableCollection<string> gradearr;

        public ObservableCollection<string> ClassArr
        {
            get
            {
                return gradearr;
            }
            set
            {
              
                gradearr = value;
                this.RaisePropertyChanged(() => this.ClassArr);
            }
        }
        private ObservableCollection<string> sectionarr;
        public ObservableCollection<string> SectionArr
        {
            get
            {
                return sectionarr;
            }
            set
            {
                sectionarr = value;
                this.RaisePropertyChanged(() => this.SectionArr);
            }
        }
        private string name="Carl Johnson";
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                this.RaisePropertyChanged(() => this.Name);
            }
        }
        private string fname = "Johnson Carl";
        public string Fname
        {
            get
            {
                return fname;
            }
            set
            {
                fname = value;
                this.RaisePropertyChanged(() => this.Fname);
            }
        }
        private int age = 25;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                this.RaisePropertyChanged(() => this.Age);
            }
        }

        private DateTime dob = DateTime.Parse("10/27/1985", new System.Globalization.CultureInfo("en-US", true));
        public DateTime DOB
        {
            get
            {
                return dob;
            }
            set
            {
                dob = value;
                this.RaisePropertyChanged(() => this.DOB);
            }
        }

        private String mobileno="03123456789";
        public String MobileNo
        {
            get
            {
                return mobileno;
            }
            set
            {
                mobileno = value;
                this.RaisePropertyChanged(() => this.MobileNo);
            }
        }
        private String phoneno = "01234567890";
        public String PhoneNo
        {
            get
            {
                return phoneno;
            }
            set
            {
                phoneno = value;
                this.RaisePropertyChanged(() => this.PhoneNo);
            }
        }
        private string address="HNo# 000,St# XX, example, example.";
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                this.RaisePropertyChanged(() => this.Address);
            }
        }

        private string rollno="ABC12345";
        public string RollNo
        {
            get
            {
                return rollno;
            }
            set
            {
                rollno = value;
                this.RaisePropertyChanged(() => this.RollNo);
            }
        }

        private int stdid =12345;
        public int Stdid 
        {
            get
            {
                return stdid;
            }
            set
            {
                stdid = value;
                this.RaisePropertyChanged(() => this.Stdid);
            }
        }
        private string grade="None";
        public string Grade
        {
            get
            {
                return grade;
            }
            set
            {
                grade = value.Substring(value.LastIndexOf(':') + 2);
                this.RaisePropertyChanged(() => this.Grade);
            }
        }
        private string section="X";
        public string Section
        {
            get
            {
                return section;
            }
            set
            {
                section = value.Substring(value.LastIndexOf(':') + 2);
                this.RaisePropertyChanged(() => this.Section);
            }
        }
        private int fid = 12345;
        public int Fid
        {
            get
            {
                return fid;
            }
            set
            {
                fid = value;
                this.RaisePropertyChanged(() => this.Fid);
            }
        }

        #endregion


        #region error
        public string Error
        {
            get { return null; }
        }
       
        public string this[string columnName]
        {
         
            get
            {
                string error = null;
                switch (columnName)
                {

                    case "Name":
                        {
                            if (string.IsNullOrEmpty(name))
                            {
                                error = "Name field required.";
                            }

                        }
                        break;
                    case "Grade":
                        {
                            if (string.IsNullOrEmpty(grade)|| grade.ToString() == "None")
                            {
                                error = "Class field required.";
                            }

                        }
                        break;
                    case "Section":
                        {
                            if (string.IsNullOrEmpty(section)|| section.ToString() == "None")
                            {
                                error = "Section field required.";
                            }

                        }
                        break;
                    case "Fname":
                        {
                            if (string.IsNullOrEmpty(fname))
                            {
                                error = "Father Name field required.";
                            }

                        }
                        break;
                    case "Age":
                        {
                            if (age <= 0 || age > 100)
                            {
                                error = "Age must be in the range [0,100]";
                            }
                        }
                        break;
                    case "DOB":
                        {
                            if (dob.Date <= DateTime.Parse("1/1/0001") || dob.Date >= DateTime.Today)
                            {
                                error = "Valid Date of Birth required.";
                            }
                        }
                        break;
                    case "MobileNo":
                        {
                           if (string.IsNullOrEmpty(mobileno.ToString()) || (mobileno.ToString()).Length < 10 )
                           {
                                   error = "Valid Mobile No. required. " +(mobileno.Length) +" numbers are not enough.";
                            }
                        }
                        break;
                    case "PhoneNo":
                        {
                            if (string.IsNullOrEmpty(mobileno.ToString()) || (phoneno.ToString()).Length < 10)
                            {
                                error = "Valid Phone No. required. " + (phoneno.Length) + " numbers are not enough.";
                            }
                        }
                        break;
                    case "Address":
                        {
                            if (string.IsNullOrEmpty(address.ToString()))
                            {
                                error = "Valid Address required.";
                            }
                        }
                        break;
                    case "RollNo":
                        {
                            if (string.IsNullOrEmpty(rollno))
                            {
                                error = "Roll Number field required.";
                            }
                        }
                        break;
                    case "Stdid":
                        {
                            if(stdid <= 0 ||stdid >10000000)
                                error = "Student ID must be in range";
                        }
                        break;
                    case "Fid":
                        {
                            if (fid <= 0 || fid> 10000000)
                            {
                                error = "Family ID must be in range";
                            }
                        }
                        break;                     
                }
                return error;
            }
        }
        #endregion

    }



}

