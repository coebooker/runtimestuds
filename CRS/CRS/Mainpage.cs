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

            if (userType == "student")
            {
                button2.Hide();
                button3.Hide();
                button4.Hide();
            }
            if (userType == "faculty")
            {
                button1.Hide();
                button3.Hide();
                button4.Hide();
            }
            if (userType == "admin")
            {
                button1.Hide();
                button2.Hide();
            }
        }

        private void Mainpage_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new addedCourse(dataGridView1.SelectedRows[0].Cells["Course ID"].FormattedValue.ToString()).Show();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            new FacultyCourses(crsDBinstance, userName).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new AdminStudentSelect(dataGridView1.SelectedRows[0].Cells["Course ID"].FormattedValue.ToString()).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new AdminFacultyList().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
