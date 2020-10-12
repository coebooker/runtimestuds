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
    public partial class FacultyCourses : Form
    {
        public FacultyCourses(List<course> crsDB, string userNameIn)
        {
            InitializeComponent();
            List<course> crsDBinstance = crsDB;

            DataTable table = new DataTable();

            table.Columns.Add("Course ID", typeof(string));   
            table.Columns.Add("Course Name", typeof(string)); 
            table.Columns.Add("Credits", typeof(string));     
            table.Columns.Add("Total Seats", typeof(string)); 
            table.Columns.Add("Class times", typeof(string)); 

            foreach (course crs in crsDBinstance)
            {
                if (crs.getInstructor() == userNameIn)
                {
                    table.Rows.Add(crs.getCode(), crs.getTitle(), crs.getCredit(), crs.getSeats(), crs.getBlocks());
                }
            }

            dataGridView1.DataSource = table;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(225)))));
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
