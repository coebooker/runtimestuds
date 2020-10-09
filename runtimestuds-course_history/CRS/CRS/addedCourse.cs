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
    public partial class addedCourse : Form
    {
        public addedCourse(string courseAdded)
        {
            InitializeComponent();
            string tempString = courseAdded + " has been added";
            label1.Text = tempString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addedCourse_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
