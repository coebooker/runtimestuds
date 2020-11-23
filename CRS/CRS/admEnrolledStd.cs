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
    public partial class admEnrolledStd : Form
    {
        public admEnrolledStd(course crs)
        {
            InitializeComponent();
            label1.Text += crs.crsID;

            DataTable table = new DataTable();
            table.Columns.Add("First Name");
            table.Columns.Add("Last Name");
            table.Columns.Add("Advisor");

            foreach (student std in crs.getStudents())
                table.Rows.Add(std.fname, std.lname, std.advisor);

            lst.DataSource = table;
        }
    }
}
