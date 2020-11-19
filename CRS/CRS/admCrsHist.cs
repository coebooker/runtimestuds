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
    public partial class admCrsHist : Form
    {
        public admCrsHist(student std)
        {
            InitializeComponent();

            DataTable table = new DataTable();

            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Semester", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Grade", typeof(string));

            List<previousCourse> crsHistLst = std.pastCrs;

            foreach (previousCourse pcrs in crsHistLst)
                table.Rows.Add(pcrs.crsID, pcrs.semester, pcrs.credit, pcrs.grade);

            crsHist.DataSource = table;
        }
    }
}
