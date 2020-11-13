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
        userDatabase usrDB;
        public admAdvisees(faculty fac, userDatabase usrDB)
        {
            this.usrDB = usrDB;
            InitializeComponent();

            // Get the list of advisees
            List<student> adviseesLst = fac.getAdviseesLst();

            // Construct the table
            DataTable table = new DataTable();
            table.Columns.Add("Username");
            table.Columns.Add("First Name");
            table.Columns.Add("Last Name");
            table.Columns.Add("GPA");
            table.Columns.Add("Credits");

            foreach (student std in adviseesLst)
                table.Rows.Add(std.username, std.fname, std.lname, std.getGPA(), std.getCredits());

            adviseeLst.DataSource = table;
            adviseeLst.Columns["Username"].Visible = false;
        }

        private void checkAdviseeScheduleClick(object sender, EventArgs e)
        {
            if (adviseeLst.SelectedRows.Count == 1)
            {
                string username = adviseeLst.SelectedRows[0].Cells["Username"].Value.ToString();

                MessageBox.Show(usrDB.getStudent(username).timeCheck(),
                    "Time Check",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Select a student from the list of advisees",
                    "No advisee selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
    }
}
