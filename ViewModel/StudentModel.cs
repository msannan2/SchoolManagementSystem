using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SQLite;
using DataBindingDemo.Database;
using System.Reflection;

namespace DataBindingDemo
{
    public class StudentModel
    {
        public DataTable Students { get; set; }
        public List<Student> EStudents { get; set; }
        public StudentModel()
        {
            AltConstructor();
        }
        public void AltConstructor()
        {
            EStudents = new List<Student>();
            Students = this.GetStudents();
        }
        public DataTable GetStudents()
        {
            StudentDB student = new StudentDB();
            DataTable dt = new DataTable();
            student.conn.Open();
            var adapter = new SQLiteDataAdapter("SELECT * FROM Student", student.conn);
            adapter.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Student temp = new Student();
                temp.StudentID = Convert.ToInt32(dt.Rows[i]["StudentID"]);
                temp.FirstName = dt.Rows[i]["FirstName"].ToString();
                temp.LastName = dt.Rows[i]["LastName"].ToString();
                temp.Gender = dt.Rows[i]["Gender"].ToString();
                temp.DateOfBirth = dt.Rows[i]["DateOfBirth"].ToString();
                temp.ParentID = Convert.ToInt32(dt.Rows[i]["ParentID"]);
                EStudents.Add(temp);
            }

            return dt;
        }
        
    }

}
