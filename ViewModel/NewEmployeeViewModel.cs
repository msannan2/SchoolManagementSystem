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
using Syncfusion.Windows.Shared;
using System.Windows.Input;

namespace DataBindingDemo
{
    public class NewEmployeeViewModel : NotificationObject
    {
        ObservableCollection<Class> classlist;
        public NewEmployeeViewModel()
        {
            Model_Employee = new Employee();
        }

        private ICommand _addEmployeeCommand;
        public ICommand AddEmployeeCommand
        {
            get
            {
                if (_addEmployeeCommand == null)
                {
                    _addEmployeeCommand = new DelegateCommand<object>(ValidateAll);
                }
                return _addEmployeeCommand;
            }

        }

        private Employee _model_emp;
        public Employee Model_Employee
        {
            get { return _model_emp; }
            set
            {
                _model_emp = value;
                this.RaisePropertyChanged(() => this.Model_Employee);
            }
        }

        public void ValidateAll(object param)
        {
            using (var context = new mainEntities())
            {
                    context.Employees.Add(Model_Employee);
                    context.SaveChanges();
            }

        }
    }
}



//{
//if(NewParent)
//    {
//      if(Model_Student.Validate() && Model_Parent.Validate())
//        {
//            using (var context = new mainEntities())
//            {
//                context.Parents.Add(Model_Parent);
//                Model_Parent.Students.Add(Model_Student);
//               // Model_Student.ParentID = Model_Parent.ParentID;
//                //Model_Student.Parent.
//               // context.Students.Add(Model_Student);
//                context.SaveChanges();
//            }
//        }
//    }
//else
//    {
//        if (Model_Student.Validate() && Model_Student.ValidateParentID())
//        {
//            using (var context = new mainEntities())
//            {
//                context.Students.Add(Model_Student);
//                context.SaveChanges();
//            }
//        }
//    }

