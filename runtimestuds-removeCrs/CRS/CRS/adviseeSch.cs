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
    public partial class adviseeSch : Form
    {
        student advisee;
        public adviseeSch(student stuIn)
        {
            advisee = stuIn;
            InitializeComponent();
            label1.Text = advisee.getUName();
            createStdSchTable(dataGridView1, advisee.getRegisteredCrs());
            createCrntSchTable(dataGridView2, advisee.GetCurrentTermList());

        }


        private void createStdSchTable(DataGridView dgv, List<course> crsLst)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Course Name", typeof(string));
            table.Columns.Add("Instructor", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Class times", typeof(string));

            foreach (course crs in crsLst)
            {
                table.Rows.Add(crs.getCode(), crs.getTitle(), crs.getInstructor(), crs.getCredit(), crs.getBlocks());
            }

            dataGridView1.DataSource = table;
            dataGridView1.EnableHeadersVisualStyles = false;
        }


        private void createCrntSchTable(DataGridView dgv, List<previousCourse> crsLst)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));

            foreach (previousCourse crs in crsLst)
            {
                table.Rows.Add(crs.coursename);
            }

            dataGridView2.DataSource = table;
            dataGridView2.EnableHeadersVisualStyles = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(advisee.timeCheck(),
                    "Time Check",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            
        }
    }
}
