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
    public partial class changeAdvisor : Form
    {
        public string facName;
        public changeAdvisor(string username, ref userDatabase usrDB)
        {
            InitializeComponent();

            DataTable table = new DataTable();
            table.Columns.Add("Username");
            table.Columns.Add("First Name");
            table.Columns.Add("Last Name");
            //table.Columns.Add("Count");

            foreach (faculty fac in usrDB.getFacultyList())
                table.Rows.Add(fac.username, fac.fname, fac.lname);

            facLst.DataSource = table;
            facLst.Columns["Username"].Visible = false;
        }

        private void confirmClick(object sender, EventArgs e)
        {
            if (facLst.SelectedRows.Count == 1)
            {
                facName = facLst.SelectedRows[0].Cells["Username"].Value.ToString();
                this.Close();
            }
        }
    }
}
