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
    public partial class facultySchedule : Form
    {
        public facultySchedule(List<course> crsLst, string username)
        {
            InitializeComponent();

            DataTable table = new DataTable();

            table.Columns.Add("Course ID", typeof(string));   
            table.Columns.Add("Course Name", typeof(string)); 
            table.Columns.Add("Credits", typeof(string));     
            table.Columns.Add("Total Seats", typeof(string)); 
            table.Columns.Add("Class times", typeof(string)); 

            foreach (course crs in crsLst)
                if (crs.getInstructor().ToLower() == username)
                    table.Rows.Add(crs.getCode(), crs.getTitle(), crs.getCredit(), crs.getSeats(), crs.getBlocks());

            dataGridView1.DataSource = table;
        }

        private void buttonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
