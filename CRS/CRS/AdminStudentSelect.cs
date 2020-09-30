using System;
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
    
    public partial class AdminStudentSelect : Form
    {
        string coursePass;
        public AdminStudentSelect(string courseAdding)
        {
            InitializeComponent();
            userDatabase usrDB = new userDatabase();
            usrDB.readInData(@"C:\Users\mikit\Downloads\userDB.in");

            coursePass = courseAdding;

            DataTable table = new DataTable();
            List<student> studentDBInstance = usrDB.getStudentList();
            table.Columns.Add("Username", typeof(string));
            table.Columns.Add("First name", typeof(string));
            table.Columns.Add("Middle name", typeof(string));
            table.Columns.Add("Last name", typeof(string));

            foreach (student usr in studentDBInstance)
            {
                 table.Rows.Add(usr.username, usr.fname, usr.mname, usr.lname);
            }

            dataGridView1.DataSource = table;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(225)))));
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void AdminStudentSelect_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentPass = dataGridView1.SelectedRows[0].Cells["First Name"].FormattedValue.ToString() +" "+ dataGridView1.SelectedRows[0].Cells["Middle Name"].FormattedValue.ToString() +" "+ dataGridView1.SelectedRows[0].Cells["Last Name"].FormattedValue.ToString();
            new AdminStudentCourse(coursePass, studentPass).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
