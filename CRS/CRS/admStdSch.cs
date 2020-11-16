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
    public partial class admStdSch : Form
    {
        public admStdSch(student std)
        {
            InitializeComponent();

            DataTable table = new DataTable();
            table.Columns.Add("Course ID");
            table.Columns.Add("Credits");

            foreach (previousCourse crs in std.currentCrs)
                table.Rows.Add(crs.crsID, crs.credit);
        }
    }
}
