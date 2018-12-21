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
    public partial class Employee : NotificationObject, IDataErrorInfo
    {

        #region RegisterCommandValidation

        public bool Validate()
        {
            if (string.IsNullOrEmpty(fName.ToString()))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }

            else if (string.IsNullOrEmpty(lName.ToString()))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }

            else if (string.IsNullOrEmpty(dob.ToString()) || (DateTime.Parse(dob.ToString()) <= DateTime.Parse("1/1/0001") || DateTime.Parse(dob.ToString()) >= DateTime.Today))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }

            else if (string.IsNullOrEmpty(cnic_info.ToString()))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }

            else if (string.IsNullOrEmpty(contact_no_1.ToString()))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }

            else if (string.IsNullOrEmpty(contact_no_2.ToString()))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }

            else if (string.IsNullOrEmpty(email_id.ToString()))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }

            else if (string.IsNullOrEmpty(salary.ToString()) || Convert.ToInt32(salary.ToString()) < 0)
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }

            else if (string.IsNullOrEmpty(userID.ToString()) || Convert.ToInt32(userID.ToString()) < 0)
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }

            else if (string.IsNullOrEmpty(gender.ToString()))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }

            else if (string.IsNullOrEmpty(address.ToString()))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }

            else if (string.IsNullOrEmpty(join_date.ToString()) || (DateTime.Parse(join_date.ToString()) <= DateTime.Parse("1/1/0001") || DateTime.Parse(join_date.ToString()) >= DateTime.Today))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }

            else if(string.IsNullOrEmpty(father_name.ToString()))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }

            else
            {
                return true;
            }
        }

        #endregion

        #region properties

        private long empID = 12345;

        public long EmployeeID
        {
            get
            {
                return empID;
            }
            set
            {
                empID = value;
                this.RaisePropertyChanged(() => this.EmployeeID);
            }
        }

        private string fName = "Carl";

        public string FirstName
        {
            get
            {
                return fName;
            }
            set
            {
                fName = value;
                this.RaisePropertyChanged(() => this.FirstName);
            }
        }

        private string lName = "Johnson";
        public string LastName
        {
            get
            {
                return lName;
            }
            set
            {
                lName = value;
                this.RaisePropertyChanged(() => this.LastName);
            }
        }

        private string dob = DateTime.Parse("10/27/2002", new System.Globalization.CultureInfo("en-US", true)).ToString();
        public string DateOfBirth
        {
            get
            {
                return dob;
            }
            set
            {
                dob = value;
                this.RaisePropertyChanged(() => this.DateOfBirth);
            }
        }

        private string cnic_info = "35202-xxxxxxx-x";
        public string CNIC
        {
            get
            {
                return cnic_info;
            }
            set
            {
                cnic_info = value;
                this.RaisePropertyChanged(() => this.CNIC);
            }
        }

        private string contact_no_1 = "03xx-xxxxxxx";
        public string ContactNo1
        {
            get
            {
                return contact_no_1;
            }
            set
            {
                contact_no_1 = value;
                this.RaisePropertyChanged(() => this.ContactNo1);
            }
        }

        private string contact_no_2 = "03yy-yyyyyyy";
        public string ContactNo2
        {
            get
            {
                return contact_no_2;
            }
            set
            {
                contact_no_2 = value;
                this.RaisePropertyChanged(() => this.ContactNo2);
            }
        }


        private string email_id = "xxxx@aol.com";
        public string EmailID
        {
            get
            {
                return email_id;
            }
            set
            {
                email_id = value;
                this.RaisePropertyChanged(() => this.EmailID);
            }
        }

        private long salary = 20000;
        public long Salary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
                this.RaisePropertyChanged(() => this.Salary);
            }
        }

        private long userID = 56789;
        public long UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
                this.RaisePropertyChanged(() => this.UserID);
            }
        }

        private string gender = "not defined";
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
                this.RaisePropertyChanged(() => this.Gender);
            }
        }

        private string address = " this is an address, Lahore. ";
        public string Address
        {
            get { return address; }
            set { this.RaisePropertyChanged(() => this.Address); }
        }

        private Nullable<bool> active;
        public Nullable<bool> isEmployed
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
                this.RaisePropertyChanged(() => this.isEmployed);
            }
        }

        private string join_date = DateTime.Parse("10/27/2002", new System.Globalization.CultureInfo("en-US", true)).ToString();
        public string Joining_date
        {
            get
            {
                return join_date;
            }
            set
            {
                join_date = value;
                this.RaisePropertyChanged(() => this.Joining_date);
            }
        }

        private string father_name = "Carl Johnson";
        public string FatherName
        {
            get {return father_name; }
            set { father_name = value; this.RaisePropertyChanged(() => this.FatherName); }
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
                    case "StudentID":
                        if (empID <= 0 || empID > 10000000)
                        {
                            error = "Student ID must be in range";
                        }
                        break;
                    case "FirstName":
                        if (string.IsNullOrEmpty(fName))
                        {
                            error = "First Name is required.";
                        }
                        break;
                    case "LastName":
                        if (string.IsNullOrEmpty(lName))
                        {
                            error = "Last Name is required.";
                        }
                        break;
                    case "DOB":
                        if (DateTime.Parse(dob) <= DateTime.Parse("1/1/0001") || DateTime.Parse(dob) >= DateTime.Today)
                        {
                            error = "Valid Date of Birth required.";
                        }
                        break;

                    case "CNIC":
                        if (string.IsNullOrEmpty(cnic_info))
                        {
                            error = "CNIC information is missing";
                        }
                        break;

                    case "ContactNo1":
                        if (string.IsNullOrEmpty(contact_no_1))
                        {
                            error = "Contact No. 1 is required.";
                        }
                        break;
                    case "ContactNo2":
                        if (string.IsNullOrEmpty(contact_no_2))
                        {
                            error = "Contact No. 1 is required.";
                        }
                        break;
                    case "EmailID":
                        if (string.IsNullOrEmpty(email_id))
                        {
                            error = "Email information is empty.";
                        }
                        break;
                    case "Salary":
                        if(salary <= 0 || salary >= 200000)
                        {
                            error = "Salary not in range. ";
                        }
                        break;
                    case "UserID":
                        if( userID <= 0 || userID >= 10000000)
                        {
                            error = "UserID not in range. ";
                        }
                        break;
                    case "Gender":
                        if( string.IsNullOrEmpty(gender))
                        {
                            error = "Gender field is empty.";
                        }
                        break;
                    case "Address":
                       if( string.IsNullOrEmpty(address))
                        {
                            error = "Address field is empty.";
                        }
                        break;
                    case "Joining_date":
                        if (DateTime.Parse(join_date) <= DateTime.Parse("1/1/0001") || DateTime.Parse(join_date) >= DateTime.Today)
                        {
                            error = "Valid Joining Date is required.";
                        }
                        break;
                    case "FatherName":
                        if (string.IsNullOrEmpty(father_name))
                        {
                            error = "Father Name field is empty.";
                        }
                        break;
                }
                return error;
            }
        }
        #endregion

    }



}

