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
    public partial class AdminFacultyList : Form
    {
        courseDatabase crsDB;
        public AdminFacultyList(userDatabase userDB, courseDatabase courseDB)
        {
            InitializeComponent();
            userDatabase usrDB = userDB;
            crsDB = courseDB;

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
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(225)))));
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FacultyCourses(crsDB.GetCourseList(), dataGridView1.SelectedRows[0].Cells["Username"].FormattedValue.ToString().Trim()).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdminFacultyList_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
