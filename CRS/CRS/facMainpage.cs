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
    public partial class facMainpage : Form
    {
        public courseDatabase crsDB;
        public userDatabase usrDB;
        faculty fac;

        public facMainpage(string username, userDatabase usrDB)
        {
            InitializeComponent();
            crsDB = new courseDatabase(ref usrDB);
            this.usrDB = usrDB;
            this.usrDB.addPrevCourses(ref crsDB, "S15");
            fac = this.usrDB.getFaculty(username);

            // Change texts
            welcome.Text += fac.fname + " " + fac.lname;

            // Create all the tables
            createCrsLst();
            createFacSch();
            createAdviseeLst();

            // Auto complete
            foreach (course crs in crsDB.getCourseList())
                crsIDBox.AutoCompleteCustomSource.Add(crs.crsID);

            facSch.ClearSelection();
            adviseeLst.ClearSelection();
        }
        public facMainpage(string username, userDatabase usrDB, courseDatabase crsDB)
        {
            InitializeComponent();
            this.usrDB = usrDB;
            this.crsDB = crsDB;
            fac = usrDB.getFaculty(username);

            // Change texts
            welcome.Text += fac.fname + " " + fac.lname;

            // Create all the tables
            createCrsLst();
            createFacSch();
            createAdviseeLst();

            // Auto complete
            foreach (course crs in crsDB.getCourseList())
                crsIDBox.AutoCompleteCustomSource.Add(crs.crsID);
        }

        public void createCrsLst()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Instructor", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Seats", typeof(string));
            table.Columns.Add("Schedule", typeof(string));

            crsLst.DataSource = table;
            foreach (course crs in crsDB.getCourseList())
                table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.seats + " / " + crs.maxSeats, crs.getBlocks());
            crsLst.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            crsLst.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            int width = crsLst.Columns["Schedule"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            crsLst.Columns["Schedule"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            crsLst.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            crsLst.Columns["Schedule"].Width = width;
        }
        public void createFacSch()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Schedule", typeof(string));

            facSch.DataSource = table;

            foreach (course crs in fac.nextSemesterCourses)
                table.Rows.Add(crs.crsID, crs.title, crs.getBlocks());

            facSch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            facSch.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            int width = facSch.Columns["Schedule"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            facSch.Columns["Schedule"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            facSch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            facSch.Columns["Schedule"].Width = width;

            DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
            btn.ValueType = typeof(bool);
            facSch.Columns.Insert(0, btn);
            facSch.Columns[0].HeaderText = "Select";
            facSch.Columns[0].Name = "Select";
            facSch.ClearSelection();

            foreach (DataGridViewColumn col in facSch.Columns)
                col.ReadOnly = true;
            facSch.Columns[0].ReadOnly = false;
        }
        public void createAdviseeLst()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Username", typeof(string));
            table.Columns.Add("First Name", typeof(string));
            table.Columns.Add("Last Name", typeof(string));
            table.Columns.Add("GPA", typeof(string));
            table.Columns.Add("Credits", typeof(string));

            adviseeLst.DataSource = table;

            foreach (student std in fac.adviseesLst)
                table.Rows.Add(std.username, std.fname, std.lname, std.GPA, std.totalCredits);

            DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
            btn.ValueType = typeof(bool);
            adviseeLst.Columns.Insert(0, btn);
            adviseeLst.Columns[0].HeaderText = "Select";
            adviseeLst.Columns[0].Name = "Select";
            adviseeLst.ClearSelection();

            foreach (DataGridViewColumn col in adviseeLst.Columns)
                col.ReadOnly = true;
            adviseeLst.Columns[0].ReadOnly = false;
        }


        private void viewEnrolledStdsClick(object sender, EventArgs e)
        {
            if (facSch.SelectedRows.Count == 0)
                MessageBox.Show("Select a class from the schedule list",
                                "No class selected",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            else
            {
                string crsID = facSch.SelectedRows[0].Cells["Course ID"].Value.ToString();
                course crs = crsDB.getCourse(crsID);
                new admEnrolledStd(crs).Show();
            }
        }
        private void checkAdviseeScheduleClick(object sender, EventArgs e)
        {
            if (adviseeLst.SelectedRows.Count == 0)
                MessageBox.Show("Select a student from the adivsees list.",
                    "No student selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
                string username = adviseeLst.SelectedRows[0].Cells["Username"].Value.ToString();
                student std = usrDB.getStudent(username);
                new admAdviseeSch(std).ShowDialog();
            }
        }
        private void curAdviseeSchClick(object sender, EventArgs e)
        {
            if (adviseeLst.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an advisee from the list.",
                    "No advisee selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            string username = adviseeLst.SelectedRows[0].Cells["Username"].Value.ToString().Trim();
            student std = usrDB.getStudent(username);

            string message = std.fname + " " + std.lname + " is taking the following courses :\n";
            foreach (previousCourse pcrs in std.currentCrs)
                message += "    " + pcrs.crsID + "   " + pcrs.credit + " credits" + "\n";
            MessageBox.Show(message, "Current Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void facViewCrsLstClick(object sender, EventArgs e)
        {
            ScrollControlIntoView(crsLst);
        }
        private void facViewSchClick(object sender, EventArgs e)
        {
            ScrollControlIntoView(facSch);
        }
        private void facViewAdviseesClick(object sender, EventArgs e)
        {
            ScrollControlIntoView(adviseeLst);
        }
        private void facScrollToTopClick(object sender, EventArgs e)
        {
            ScrollControlIntoView(header);
        }

        private void facSchCellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;
            for (int i = 0; i < facSch.RowCount; i++)
            {
                if (i == rowIndex)
                {
                    facSch.Rows[rowIndex].Selected = true;
                    facSch.Rows[rowIndex].Cells["Select"].Value = true;
                }
                else
                    facSch.Rows[i].Cells["Select"].Value = null;
            }
        }
        private void adviseeLstCellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;
            for (int i = 0; i < adviseeLst.RowCount; i++)
            {
                if (i == rowIndex)
                {
                    adviseeLst.Rows[rowIndex].Selected = true;
                    adviseeLst.Rows[rowIndex].Cells["Select"].Value = true;
                }
                else
                    adviseeLst.Rows[i].Cells["Select"].Value = null;
            }
        }
        private void facSchCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (facSch.IsCurrentCellDirty)
                facSch.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void adviseeLstCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (adviseeLst.IsCurrentCellDirty)
                adviseeLst.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void logoutClick(object sender, EventArgs e)
        {
            Close();
        }
        private void crsSearchClick(object sender, EventArgs e)
        {
            string crsID = crsIDBox.Text.Trim();

            if (crsLst.Visible)
                for (int i = 0; i < crsLst.RowCount; i++)
                    if (crsLst.Rows[i].Cells["Course ID"].Value.ToString().Trim() == crsID)
                    {
                        DataTable table = (DataTable)crsLst.DataSource;
                        DataRow dr = table.Rows[i];
                        DataRow nr = table.NewRow();
                        nr.ItemArray = dr.ItemArray;
                        table.Rows.Remove(dr);
                        table.Rows.InsertAt(nr, 0);
                        break;
                    }
        }
    }
}
