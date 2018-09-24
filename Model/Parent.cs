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
    public partial class Parent : NotificationObject, IDataErrorInfo
    {

        #region RegisterCommandValidation
        public bool Validate()
        {
          
            if (string.IsNullOrEmpty(fName.ToString()))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
            if (string.IsNullOrEmpty(cnic.ToString()))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
            else if (string.IsNullOrEmpty(lName.ToString()))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
            else if (string.IsNullOrEmpty(address.ToString()))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
            else if (string.IsNullOrEmpty(parentID.ToString()) || Convert.ToInt32(parentID.ToString()) <= 0)
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                return false;
            }
            else if (string.IsNullOrEmpty(cn1.ToString()))
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

        private string address;
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
        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                this.RaisePropertyChanged(() => this.Email);
            }
        }
        private string cn1;
        public string ContactNo1
        {
            get
            {
                return cn1;
            }
            set
            {
                cn1 = value;
                this.RaisePropertyChanged(() => this.ContactNo1);
            }
        }
        private string cn2;
        public string ContactNo2
        {
            get
            {
                return cn2;
            }
            set
            {
                cn2 = value;
                this.RaisePropertyChanged(() => this.ContactNo2);
            }
        }
        private string cnic;
        public string CNIC
        {
            get
            {
                return cnic;
            }
            set
            {
                cnic = value;
                this.RaisePropertyChanged(() => this.CNIC);
            }
        }
        private Nullable<long> income;
        public Nullable<long> Income
        {
            get
            {
                return income;
            }
            set
            {
                income = value;
                this.RaisePropertyChanged(() => this.Income);
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

        private long parentID = 56789;
        public long ParentID
        {
            get
            {
                return parentID;
            }
            set
            {
                parentID = value;
                this.RaisePropertyChanged(() => this.ParentID);
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
                    case "ContactNo1":
                        if (string.IsNullOrEmpty(cn1))
                        {
                            error = "Contact 1 is required.";
                        }
                        break;
                    case "CNIC":
                        if (string.IsNullOrEmpty(cnic))
                        {
                            error = "CNIC is required.";
                        }
                        break;
                    case "Address":
                        if (string.IsNullOrEmpty(address))
                        {
                            error = "CNIC is required.";
                        }
                        break;
                    case "ParentID":
                        if (parentID <= 0 || parentID > 10000000)
                        {
                            error = "Parent ID must be in range";
                        }
                        break;
                }
                return error;
            }
        }
        #endregion

    }



}

