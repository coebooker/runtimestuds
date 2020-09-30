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
    public partial class Mainpage : Form
    {
        private List<course> crsDBinstance;
        private string userName;

        public Mainpage(courseDatabase crsDB, string userType, string userNameInput)
        {
            InitializeComponent();
            crsDBinstance = crsDB.GetCourses();
            userName = userNameInput;

            DataTable table = new DataTable();

            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Course Name", typeof(string));
            table.Columns.Add("Instructor", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Total Seats", typeof(string));
            table.Columns.Add("Class times", typeof(string));

            foreach (course crs in crsDBinstance)
            {
                table.Rows.Add(crs.getCode(), crs.getName(), crs.getInstructor(), crs.getCredit(), crs.getSeats(), crs.getBlocks());
            }

            dataGridView1.DataSource = table;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(225)))));
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Visible = false;

            if (userType == "student")
            {
                button2.Hide();
                AddCourseAdmin.Hide();
                ViewScheduleAdmin.Hide();
            }
            if (userType == "faculty")
            {
                AddCourseStudent.Hide();
                AddCourseAdmin.Hide();
                ViewScheduleAdmin.Hide();
            }
            if (userType == "admin")
            {
                AddCourseStudent.Hide();
                button2.Hide();
            }
        }

        private void Mainpage_Load(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
        {
            new FacultyCourses(crsDBinstance, userName).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
                new AdminStudentSelect(dataGridView1.SelectedRows[0].Cells["Course ID"].FormattedValue.ToString()).Show();
            else
            {
                MessageBox.Show("Select a class",
                    "No Class",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                if (dataGridView1.Visible == false)
                {
                    dataGridView1.Visible = true;
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LogoutClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCourseStudentClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
                new addedCourse(dataGridView1.SelectedRows[0].Cells["Course ID"].FormattedValue.ToString()).Show();
            else
            {
                MessageBox.Show("Select a class",
                    "No Class",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                if (dataGridView1.Visible == false)
                {
                    dataGridView1.Visible = true;
                }
            }
        }

        private void ViewScheduleAdminClick(object sender, EventArgs e)
        {
            new AdminFacultyList().Show();
        }

        private void ViewCourseListClick(object sender, EventArgs e)
        {
            if (dataGridView1.Visible == false)
            {
                dataGridView1.Visible = true;
            }
            else
                dataGridView1.Visible = false;
        }
    }
}
