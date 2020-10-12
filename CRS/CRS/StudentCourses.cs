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
    public partial class StudentCourses : Form
    {
        public StudentCourses(List<course> crsLst)
        {
            InitializeComponent();

            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Course Name", typeof(string));
            table.Columns.Add("Instructor", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Total Seats", typeof(string));
            table.Columns.Add("Class times", typeof(string));

            foreach (course crs in crsLst)
            {
                table.Rows.Add(crs.getCode(), crs.getTitle(), crs.getInstructor(), crs.getCredit(), crs.getSeats(), crs.getClassTime());
            }

            dataGridView1.DataSource = table;
            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
