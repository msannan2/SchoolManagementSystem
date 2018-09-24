using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows;
using System.Data;
using System.Data.OleDb;

namespace DataBindingDemo.Database
{
    class StudentDB
    {
        public SQLiteConnection conn;

        public StudentDB()
        {
            conn = new SQLiteConnection("Data Source=D:\\db1.db3");
            if (!File.Exists("D:\\db1.db3"))
            {
                SQLiteConnection.CreateFile("db1.db3");
                MessageBox.Show("Done");
                string createTableString = "CREATE TABLE 'Users' ( 'ID' INTEGER PRIMARY KEY AUTOINCREMENT, 'Username' TEXT, 'Password' TEXT )";
                SQLiteCommand cmd1 = new SQLiteCommand(createTableString, conn);
                string query = "INSERT INTO Users ('Username','Password') VALUES (@Username,@Password)";
                SQLiteCommand cmd2 = new SQLiteCommand(query, conn);
                cmd2.Parameters.AddWithValue("@Username", "admin");
                cmd2.Parameters.AddWithValue("@Password", "admin");
                conn.Open();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
            }
            else
            {
                //MessageBox.Show("Already Exists");
            }
        }
    }
}
