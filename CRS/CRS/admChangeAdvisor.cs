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
    public partial class admChangeAdvisor : Form
    {
        public string newAdvisor;

        public admChangeAdvisor(userDatabase usrDB, string advisor)
        {
            InitializeComponent();
            foreach (faculty fac in usrDB.getFacultyList())
            {
                facLst.Items.Add(fac.username);
                facLst.AutoCompleteCustomSource.Add(fac.username);
            }

            curAdv.Text += advisor;
        }

        private void confirmClick(object sender, EventArgs e)
        {
            newAdvisor = facLst.Text.Trim().ToLower();  // Needed ToLower()
            if (newAdvisor == "")
                MessageBox.Show("Select a new advisor.",
                    "No advisor selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
