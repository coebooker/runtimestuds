using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CRS
{
    public partial class admChangeCrs : Form
    {
        List<string> timeSlots = new List<string>();
        public course crs;
        userDatabase usrDB;
        public admChangeCrs(course crs, userDatabase usrDB)
        {
            InitializeComponent();

            // Create the schedule table
            DataTable table = new DataTable();
            table.Columns.Add("Schedule");
            table.Columns.Add("Code");
            foreach (string crsBlock in crs.timeBlocks)
                table.Rows.Add(course.Decode(crsBlock), crsBlock);

            crsSch.DataSource = table;

            DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
            btn.ValueType = typeof(bool);
            crsSch.Columns.Insert(0, btn);
            crsSch.Columns[0].HeaderText = "Remove";
            crsSch.Columns[0].Name = "Remove";

            foreach (DataGridViewColumn col in crsSch.Columns)
                col.ReadOnly = true;
            crsSch.Columns[0].ReadOnly = false;
            crsSch.Columns["Code"].Visible = false;

            foreach(faculty fac in usrDB.getFacultyList())
            {
                facDropDown.Items.Add(fac.fname + " " + fac.lname);
                facDropDown.AutoCompleteCustomSource.Add(fac.fname + " " + fac.lname);
            }
            this.crs = crs;
            this.usrDB = usrDB;
        }

        private void scheduleCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == -1)
                return;
            string timeSlot = crsSch.Rows[rowIndex].Cells["Code"].Value.ToString().Trim();
            if (Convert.ToBoolean(crsSch.Rows[rowIndex].Cells["Remove"].Value) == true)
            {
                if (!timeSlots.Contains(timeSlot))
                    timeSlots.Add(timeSlot);
                else
                    return;
            }
            else
                timeSlots.Remove(timeSlot);
        }
        private void schduleCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (crsSch.IsCurrentCellDirty)
            {
                crsSch.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void confirmClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmation : \nMake sure you input the right information.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Remove specified time slots
                foreach (string timeslot in timeSlots)
                {
                    crs.timeBlocks.Remove(timeslot);
                    crs.num_time -= 1;
                }

                // Check if time is specified
                if (MA.Checked || TA.Checked || WA.Checked || RA.Checked || FA.Checked)
                {
                    if (startingTimeA.Text == "" || endingTimeA.Text == "")
                    {
                        MessageBox.Show("Specify the starting and ending time.",
                            "No time specified",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
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

                        string day;
                        if (dd < 10)
                            day = "0" + dd.ToString();
                        else
                            day = dd.ToString();

                        string timeBlock = day + UF.utilities.encodeTime(startingTimeA.Text, endingTimeA.Text);
                        crs.timeBlocks.Add(timeBlock);
                    }
                }

                if (facDropDown.Text != "")
                    foreach (faculty fac in usrDB.getFacultyList())
                        if (fac.fname + " " + fac.lname == facDropDown.Text.Trim())
                            crs.setInstructor(fac.username);

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
