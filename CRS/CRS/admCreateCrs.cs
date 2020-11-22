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
    public partial class admCreateCrs : Form
    {
        public course crs;
        private courseDatabase crsDB;
        private userDatabase usrDB;
        public admCreateCrs(courseDatabase crsDB, userDatabase usrDB)
        {
            InitializeComponent();
            this.crsDB = crsDB;
            this.usrDB = usrDB;


            foreach (course crs in crsDB.getCourseList())
                crsIDBox.AutoCompleteCustomSource.Add(crs.crsID);

            foreach (faculty fac in usrDB.getFacultyList())
            {
                facLst.Items.Add(fac.fname + " " + fac.lname);
                facLst.AutoCompleteCustomSource.Add(fac.fname + " " + fac.lname);
            }
        }

        private void confirmClick(object sender, EventArgs e)
        {
            // Search for missing fields
            if (crsIDBox.Text == "" || titleBox.Text == "" || facLst.Text == "" ||
                creditBox.Text == "" || seatBox.Text == "")
            {
                MessageBox.Show("Required fields missing.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (!MA.Checked && !MB.Checked && !TA.Checked && !TB.Checked && !WA.Checked && !WB.Checked
                && !RA.Checked && !RB.Checked && !FA.Checked && !FB.Checked)
            {
                MessageBox.Show("Specify a time slot.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if ((MA.Checked && MB.Checked) || (TA.Checked && TB.Checked) || (WA.Checked && WB.Checked)
                || (RA.Checked && RB.Checked) || (FA.Checked && FB.Checked))
            {
                MessageBox.Show("Cannot have the same day over two slots",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (MA.Checked || TA.Checked || WA.Checked || RA.Checked || FA.Checked)
                if (startingTimeA.Text == "" || endingTimeA.Text == "")
                {
                    MessageBox.Show("Specify the starting and ending time.",
                        "Invalid input",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

            string crsID = crsIDBox.Text;
            // Search for duplicate course ID
            foreach (course crs in crsDB.getCourseList())
                if (crsID.Trim() == crs.crsID)
                {
                    MessageBox.Show("The course ID is already taken.",
                        "Duplicate",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

            string title = titleBox.Text;
            string instructor = facLst.Text.Trim();
            faculty inst = usrDB.getFacultyList()[0];
            foreach (faculty fac in usrDB.getFacultyList())
                if (fac.fname + " " + fac.lname == instructor)
                {
                    inst = fac;
                    break;
                }
            string credits = creditBox.Text;
            try
            {
                if (Convert.ToSingle(credits) == 0)
                {
                    MessageBox.Show("No credits given.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                };
            }
            catch
            {
                MessageBox.Show("Credits have to be number.",
                    "Invalid input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            int seats = 0;
            try
            {
                seats = Convert.ToInt32(seatBox.Text);
            }
            catch
            {
                MessageBox.Show("Seats have to be number.",
                    "Invalid input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            // Get the course time block
            int dd = 0;
            if (MA.Checked)
                dd += 1;
            if (TA.Checked)
                dd += 2;
            if (WA.Checked)
                dd += 4;
            if (RA.Checked)
                dd += 8;
            if (FA.Checked)
                dd += 16;

            string day = dd.ToString();
            if (day.Length < 2)
                day = "0" + day;

            string timeBlockA = day + UF.utilities.encodeTime(startingTimeA.Text, endingTimeA.Text);


            if (MB.Checked || TB.Checked || WB.Checked || RB.Checked || FB.Checked)
            {
                // Get the course time block
                dd = 0;
                if (MB.Checked)
                    dd += 1;
                if (TB.Checked)
                    dd += 2;
                if (WB.Checked)
                    dd += 4;
                if (RB.Checked)
                    dd += 8;
                if (FB.Checked)
                    dd += 16;

                day = dd.ToString();
                if (day.Length < 2)
                    day = "0" + day;

                string timeBlockB = day + UF.utilities.encodeTime(startingTimeB.Text, endingTimeB.Text);

                List<string> lst = new List<string>();
                lst.Add(timeBlockA);
                lst.Add(timeBlockB);
                crs = new course(crsID, title, inst.username, credits, seats, 2, lst);
            }
            else
            {
                List<string> lst = new List<string>();
                lst.Add(timeBlockA);
                crs = new course(crsID, title, instructor, credits, seats, 1, lst);
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
