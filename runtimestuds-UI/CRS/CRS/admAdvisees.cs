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
    public partial class admAdvisees : Form
    {
        private userDatabase usrDB;
        public admAdvisees(faculty fac, userDatabase usrDB)
        {
            this.usrDB = usrDB;
            InitializeComponent();

            DataTable table = new DataTable();
            table.Columns.Add("Username");
            table.Columns.Add("First Name");
            table.Columns.Add("Last Name");
            table.Columns.Add("GPA");
            table.Columns.Add("Credits");

            foreach (student std in fac.getAdviseesLst())
                table.Rows.Add(std.username, std.fname, std.lname, std.GPA, std.totalCredits);

            advissesLst.DataSource = table;
            advissesLst.Columns["Username"].Visible = false;
        }

        private void timeConflictClick(object sender, EventArgs e)
        {
            if (advissesLst.SelectedRows.Count == 1)
            {
                string username = advissesLst.SelectedRows[0].Cells["Username"].Visible.ToString();
                MessageBox.Show(usrDB.getStudent(username).timeCheck(),
                    "Time Check",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
