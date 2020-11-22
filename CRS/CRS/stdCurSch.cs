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
    public partial class stdCurSch : Form
    {
        public stdCurSch(List<previousCourse> lst)
        {
            InitializeComponent();
            foreach (previousCourse pcrs in lst)
                label2.Text += pcrs.crsID + "   " + pcrs.credit + " credits" + "\n";
        }
    }
}
