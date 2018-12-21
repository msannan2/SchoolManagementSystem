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
    public class NewUserViewModel : NotificationObject
    {
        ObservableCollection<Class> classlist;
        public NewUserViewModel()
        {

            Model_Student = new Student();
            Model_Class = new Class();
            Model_Parent = new Parent();
            SectionArr = new ObservableCollection<string>();
            using (var context = new mainEntities())
            {
                ClassArr = new ObservableCollection<string>(context.Classes.Select(p => p.ClassName).Distinct().ToList());
                ParentArr = new ObservableCollection<long>(context.Parents.Select(p => p.ParentID).ToList());
            }
        }
        private bool _newParent;
        public bool NewParent
        {
            get { return _newParent; }
            set
            {
                _newParent = value;
                this.RaisePropertyChanged(() => this.NewParent);
            }
        }
        private string _classselected;
        public string ClassSelected
        {
            get { return _classselected; }
            set
            {
                _classselected = value;
                this.RaisePropertyChanged(() => this.ClassSelected);
            }
        }
        private string _sectionselected;
        public string SectionSelected
        {
            get { return _sectionselected; }
            set
            {
                _sectionselected = value;
                this.RaisePropertyChanged(() => this.SectionSelected);
            }
        }
        private ObservableCollection<long> _parentarr;
        public ObservableCollection<long> ParentArr
        {
            get { return _parentarr; }
            set
            {
                _parentarr = value;
                this.RaisePropertyChanged(() => this.ParentArr);
            }
        }
        private ObservableCollection<string> _classarr;
        public ObservableCollection<string> ClassArr
        {
            get { return _classarr; }
            set
            {
                _classarr = value;
                this.RaisePropertyChanged(() => this.ClassArr);
            }
        }

        private ObservableCollection<string> _sectionarr;
        public ObservableCollection<string> SectionArr
        {
            get { return _sectionarr; }
            set
            {
                _sectionarr = value;
                this.RaisePropertyChanged(() => this.SectionArr);
            }
        }
        private Student _modelstudent;
        public Student Model_Student
        {
            get { return _modelstudent; }
            set
            {
                _modelstudent = value;
                this.RaisePropertyChanged(() => this.Model_Student);
            }
        }
        private Parent _modelparent;
        public Parent Model_Parent
        {
            get { return _modelparent; }
            set
            {
                _modelparent = value;
                this.RaisePropertyChanged(() => this.Model_Parent);
            }
        }
        private Class _modelclass;
        public Class Model_Class
        {
            get { return _modelclass; }
            set
            {
                _modelclass = value;
                this.RaisePropertyChanged(() => this.Model_Class);
            }
        }
        private ICommand _addStudentCommand;
        public ICommand AddStudentCommand
        {
            get
            {
                if (_addStudentCommand == null)
                {
                    _addStudentCommand = new DelegateCommand<object>(AddStudent);
                }
                return _addStudentCommand;
            }

        }

        private ICommand _selectedCommand;
        public ICommand ClassSelectedCommand
        {
            get
            {
                if (_selectedCommand == null)
                {
                    _selectedCommand = new DelegateCommand<object>(UpdateSections);
                }
                return _selectedCommand;
            }

        }
        public void UpdateSections(object param)
        {
            if (ClassSelected != null)
            {
                using (var context = new mainEntities())
                {
                    classlist = new ObservableCollection<Class>(context.Classes.Where(p => p.ClassName == ClassSelected).ToList());
                }
                SectionArr.Clear();
                foreach (Class str in classlist)
                {
                    SectionArr.Add(str.Section);
                }

            }
        }
        public void AddStudent(object param)
        {
            if (NewParent)
            {
                if (Model_Student.Validate() && Model_Parent.Validate())
                {
                    using (var context = new mainEntities())
                    {
                        context.Parents.Add(Model_Parent);
                        Model_Parent.Students.Add(Model_Student);
                        // Model_Student.ParentID = Model_Parent.ParentID;
                        //Model_Student.Parent.
                        // context.Students.Add(Model_Student);
                        context.SaveChanges();
                    }
                }
            }
            else
            {
                if (Model_Student.Validate() && Model_Student.ValidateParentID())
                {
                    using (var context = new mainEntities())
                    {
                        context.Students.Add(Model_Student);
                        context.SaveChanges();
                    }
                }
            }
        }

    }

}
