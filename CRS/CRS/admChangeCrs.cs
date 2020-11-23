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

            schedule.DataSource = table;

            DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
            btn.ValueType = typeof(bool);
            schedule.Columns.Insert(0, btn);
            schedule.Columns[0].HeaderText = "Remove";
            schedule.Columns[0].Name = "Remove";

            foreach (DataGridViewColumn col in schedule.Columns)
                col.ReadOnly = true;
            schedule.Columns[0].ReadOnly = false;
            schedule.Columns["Code"].Visible = false;

            foreach(faculty fac in usrDB.getFacultyList())
            {
                facLst.Items.Add(fac.fname + " " + fac.lname);
                facLst.AutoCompleteCustomSource.Add(fac.fname + " " + fac.lname);
            }
            this.crs = crs;
            this.usrDB = usrDB;
        }

        private void scheduleCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == -1)
                return;
            string timeSlot = schedule.Rows[rowIndex].Cells["Code"].Value.ToString().Trim();
            if (Convert.ToBoolean(schedule.Rows[rowIndex].Cells["Remove"].Value) == true)
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
            if (schedule.IsCurrentCellDirty)
            {
                schedule.CommitEdit(DataGridViewDataErrorContexts.Commit);
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

                if (facLst.Text != "")
                    foreach (faculty fac in usrDB.getFacultyList())
                        if (fac.fname + " " + fac.lname == facLst.Text.Trim())
                            crs.setInstructor(fac.username);

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
