﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRS
{
    public partial class AdminFacultyList : Form
    {
        public AdminFacultyList()
        {
            InitializeComponent();
            userDatabase usrDB = new userDatabase();
            usrDB.readInData(@"C:\Users\81802\Desktop\userDB.in");

            DataTable table = new DataTable();
            List<faculty> facultyDBInstance = usrDB.getFacultyList();
            table.Columns.Add("Username", typeof(string));
            table.Columns.Add("First name", typeof(string));
            table.Columns.Add("Middle name", typeof(string));
            table.Columns.Add("Last name", typeof(string));

            foreach (faculty usr in facultyDBInstance)
            {
                table.Rows.Add(usr.username, usr.fname, usr.mname, usr.lname);
            }

            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            courseDatabase crsDB = new courseDatabase();
            crsDB.readInCourse(@"C:\Users\81802\Desktop\courseDB.in");
            new FacultyCourses(crsDB.GetCourses(), dataGridView1.SelectedRows[0].Cells["Username"].FormattedValue.ToString()).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}