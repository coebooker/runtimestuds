using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRS
{
    public partial class mainpage : Form
    {
        public userDatabase usrDB;
        public courseDatabase crsDB;
        private string username;
        string currentSemester = "F14";
        string nextSemester = "S15";
        validity validityResult;
        Point startPosCrsLst;
        List<int> addCrsLst = new List<int>();
        List<int> dropCrsLst = new List<int>();

        public mainpage(string usertype, string username, userDatabase usrDB, string cpath, string ppath)
        {
            InitializeComponent();
            this.username = username;
            crsDB = new courseDatabase(cpath, ref depBox, ref titleBox, ref usrDB);
            usrDB.addPrevCourses(ppath, ref this.crsDB, nextSemester);
            this.usrDB = usrDB;

            createCrsLst();
            startPosCrsLst = crsLst.Location;

            if (usertype == "student")
            {
                student std = usrDB.getStudent(this.username);
                createCrsHist();
                createStdSch(std.registeredCrs);
                stdSch.Visible = true;
                stdSchLabel.Visible = true;
                conflictCheck.Visible = true;
                std.calculateGPA();
                gpa.Text += " " + std.GPA;
                credits.Text += " " + std.totalCredits;
            }
            else if (usertype == "faculty")
            {
                createFacSchTable(facSchTable);
                createFacDropDown(facDropDown);
                createAdviseesTable(adviseeTable);
                adviseeTable.Visible = true;
                facSchTable.Visible = true;
            }
            alignButtons(usertype, 53);
        }
        public mainpage(string usertype, string username, userDatabase usrDB, courseDatabase crsDB)
        {
            InitializeComponent();
            this.username = username;
            this.usrDB = usrDB;
            this.crsDB = crsDB;

            createCrsLst();
            startPosCrsLst = crsLst.Location;

            if (usertype == "student")
            {
                student std = usrDB.getStudent(this.username);
                createCrsHist();
                createStdSch(std.registeredCrs);
                stdSch.Visible = true;
                stdSchLabel.Visible = true;
            }
            else if (usertype == "faculty")
            {
                createFacSchTable(facSchTable);
                createFacDropDown(facDropDown);
                createAdviseesTable(adviseeTable);
                adviseeTable.Visible = true;
                facSchTable.Visible = true;
            }
            alignButtons(usertype, 53);
        }

        private void createCrsLst()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Faculty", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Seats", typeof(string));
            table.Columns.Add("Schedule", typeof(string));

            foreach (course crs in crsDB.getCourseList())
                table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.seats + " / " + crs.maxSeats, crs.getBlocks());

            crsLst.DataSource = table;
            crsLst.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            crsLst.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            int width = crsLst.Columns[5].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            crsLst.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            crsLst.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            crsLst.Columns[5].Width = width;

            DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
            btn.ValueType = typeof(bool);
            crsLst.Columns.Insert(0, btn);
            crsLst.Columns[0].HeaderText = "Add";
            crsLst.ClearSelection();
        }
        private void sortCrsLst(string dep)
        {
            foreach (DataGridViewRow row in crsLst.Rows)
            {
                string crsID = row.Cells[1].Value.ToString();
                if (dep != "All")
                {
                    if (!crsID.StartsWith(dep))
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[crsLst.DataSource];
                        currencyManager1.SuspendBinding();
                        row.Visible = false;
                        currencyManager1.ResumeBinding();
                    }
                    else
                    {
                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[crsLst.DataSource];
                        currencyManager1.SuspendBinding();
                        row.Visible = true;
                        currencyManager1.ResumeBinding();
                    }
                }
                else
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[crsLst.DataSource];
                    currencyManager1.SuspendBinding();
                    row.Visible = true;
                    currencyManager1.ResumeBinding();
                }
            }
        }

        // Create tables for students
        private void createCrsHist()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course Name", typeof(string));
            table.Columns.Add("Semester", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Grade", typeof(string));

            student std = usrDB.getStudent(username);
            List<previousCourse> crsHist = std.pastCrs;

            foreach (previousCourse pcrs in crsHist)
                table.Rows.Add(pcrs.crsID, pcrs.semester, pcrs.credit, pcrs.grade);

            crsHistTable.DataSource = table;
        }
        private void createStdSch(List<course> crsLst)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Instructor", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Class times", typeof(string));

            foreach (course crs in crsLst)
                table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.getBlocks());

            stdSch.DataSource = table;
            stdSch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            stdSch.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            int width = stdSch.Columns[4].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            stdSch.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            stdSch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            stdSch.Columns[4].Width = width;

            DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
            stdSch.Columns.Insert(0, btn);
            stdSch.Columns[0].HeaderText = "Drop";
            stdSch.Columns[0].Visible = false;
            stdSch.ClearSelection();
        }


        // Create tables for faculties
        private void createFacSchTable(DataGridView dgv)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Course", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Schedule", typeof(string));

            foreach (course crs in crsDB.getNextFacCrsLst(username))
                table.Rows.Add(crs.crsID, crs.title, crs.getBlocks());

            dgv.DataSource = table;
        }
        private void createFacDropDown(ComboBox dd)
        {
            List<course> crsLst = crsDB.getNextFacCrsLst(username);
            foreach (course crs in crsLst)
                dd.Items.Add(crs.crsID);
            dd.Items.Add("");
        }
        private void createEnrolledStdTable(DataGridView dgv, string course)
        {
            List<course> crsLst = crsDB.getNextFacCrsLst(username);
            course crs = crsLst.Find(s => s.crsID == course);
            DataTable table = new DataTable();
            table.Columns.Add("First Name");
            table.Columns.Add("Middle Name");
            table.Columns.Add("Last Name");

            List<student> stdLst = crs.getStudents();
            foreach (student std in stdLst)
                table.Rows.Add(std.fname, std.mname, std.lname);

            dgv.DataSource = table;
        }
        private void createAdviseesTable(DataGridView dgv)
        {
            faculty fac = usrDB.getFaculty(username);
            List<student> adviseesLst = fac.getAdviseesLst();

            DataTable table = new DataTable();
            table.Columns.Add("First Name");
            table.Columns.Add("Middle Name");
            table.Columns.Add("Last Name");

            foreach (student std in adviseesLst)
                table.Rows.Add(std.fname, std.mname, std.lname);

            adviseeTable.DataSource = table;
        }

        private void alignButtons(string userType, int addition)
        {
            if (userType == "student")
            {
                viewCrsLst.Visible = true;

                stdAddCrsShow.Visible = true;
                stdDropCrsShow.Visible = true;
                gradeHist.Visible = true;
            }
            else if (userType == "faculty")
            {
                facViewSch.Visible = true;
            }
        }


        // Event handlers
        private void LogoutClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void crsHistClick(object sender, EventArgs e)
        {
        }
        private void viewFacSchClick(object sender, EventArgs e)
        {
            if (facSchTable.Visible == false)
                facSchTable.Visible = true;
            else
                facSchTable.Visible = false;
        }


        private void viewCrsLstClick(object sender, EventArgs e)
        {
            if (!crsLstContainer.Visible)
                crsLstContainer.Visible = true;
            Size margin = Size.Subtract(crsLstContainer.Size, crsLstLabelContainer.Size);
            depBox.Visible = false;
            depLabel.Visible = false;
            titleBox.Visible = false;
            titleLabel.Visible = false;
            emptyLabel.Visible = false;
            emptyContainer.Visible = false;
            crsSearch.Visible = false;
            stdAddCrs.Visible = false;
            crsLst.Columns[0].Visible = false;

            crsLst.Location = new Point(startPosCrsLst.X, 77);
        }
        private void dropDownValueChanged(object sender, EventArgs e)
        {
            string course = facDropDown.SelectedItem.ToString();
            if (course == "")
                enrolledStdTable.Visible = false;
            createEnrolledStdTable(enrolledStdTable, course);
            enrolledStdTable.Visible = true;
        }
        private void conflictCheckClick(object sender, EventArgs e)
        {
            MessageBox.Show(usrDB.getStudent(username).timeCheck(),
                    "Time Check",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            student std = usrDB.getStudent(username);
            if (std.currentCrs.Count != 0)
            {
                string temp = "You're taking the following courses: \n\n";
                foreach (previousCourse pcrs in std.currentCrs)
                    temp += "\t" + pcrs.crsID + "\n";
                MessageBox.Show(temp,
                    "Current Semester",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("You are not enrolling in any courses this semester",
                    "Current Semester",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
        private void crsSearchClick(object sender, EventArgs e)
        {
            string dep = depBox.Text;
            string title = titleBox.Text;
            bool empty = yesButton.Checked;
            sortCrsLst(dep);
        }


        private void stdAddCrsClick(object sender, EventArgs e)
        {
            int count = addCrsLst.Count;
            
            if (count == 0)
                MessageBox.Show("Select a class",
                    "No Class",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
                for (int i = 0; i < count; i++)
                {
                    string crsID = crsLst.Rows[i].Cells[1].Value.ToString().Trim();
                    validityResult = usrDB.getStudent(username).isValidAdd(crsDB.getCourse(crsID));
                    if (validityResult.valid)
                    {
                        if (validityResult.warning)
                        {
                            //Pop up warning message
                            MessageBox.Show(validityResult.message,
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        }

                        student currentStd = usrDB.getStudent(username);
                        usrDB.addCrsToStd(crsID, currentSemester, ref crsDB, currentStd);

                        new addedCourse(crsID).Show();

                        // Update the course list table
                        DataGridViewRow row = crsLst.Rows[i];
                        course crs = crsDB.getCourse(row.Cells["Course ID"].Value.ToString());
                        row.Cells["Seats"].Value = crs.seats + " / " + crs.maxSeats;

                        // Update the student schedule table
                        DataTable table = (DataTable)stdSch.DataSource;
                        table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.getBlocks());
                        stdSch.DataSource = table;
                    }
                    else
                    {
                        // Display that it's a invalid add
                        MessageBox.Show(validityResult.message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        if (crsLst.Visible == false)
                        {
                            crsLst.Visible = true;
                        }
                    }
                }
                for (int i =0; i < count; i++)
                {
                    crsLst.Rows[i].Cells[0].Value = null;
                }
                addCrsLst.Clear();
                crsLst.ClearSelection();
            }
        }
        private void stdAddCrsShowClick(object sender, EventArgs e)
        {
            crsLstContainer.Visible = true;
            depBox.Visible = true;
            depLabel.Visible = true;
            titleBox.Visible = true;
            titleLabel.Visible = true;
            emptyLabel.Visible = true;
            emptyContainer.Visible = true;
            crsSearch.Visible = true;
            stdAddCrs.Visible = true;
            crsLst.Columns[0].Visible = true;

            crsLst.Location = startPosCrsLst;
            crsLst.ClearSelection();
        }
        private void stdDropCrsClick(object sender, EventArgs e)
        {
            int count = dropCrsLst.Count;

            if (count == 0)
                MessageBox.Show("Select a class",
                    "No Class",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
                for (int i = 0; i < count; i++)
                {
                    // Get the course id
                    string crsID = stdSch.Rows[i].Cells["Course ID"].Value.ToString().Trim();

                    // Drop the course from the student
                    student curStd = usrDB.getStudent(username);
                    usrDB.dropCrsFromStd(crsID, currentSemester, ref crsDB, curStd);

                    // Update the course list table
                    foreach (DataGridViewRow row in crsLst.Rows)
                    {
                        if (row.Cells["Course ID"].Value.ToString().Trim() == crsID)
                        {
                            course crs = crsDB.getCourse(row.Cells["Course ID"].Value.ToString());
                            row.Cells["Seats"].Value = crs.seats + " / " + crs.maxSeats;
                        }
                    }

                    // Remove the course from the student schedule
                    stdSch.Rows.Remove(stdSch.Rows[i]);
                }

                for (int i = 0; i < count; i++)
                    stdSch.Rows[i].Cells[0].Value = null;

                dropCrsLst.Clear();
                stdSch.ClearSelection();
            }
        }
        private void stdDropShowClick(object sender, EventArgs e)
        {
            stdDropCrs.Visible = true;
            stdSch.Columns[0].Visible = true;
            stdSch.ClearSelection();
        }
        private void crsLstCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == -1)
                return;
            if (Convert.ToBoolean(crsLst.Rows[rowIndex].Cells[0].Value) == true)
                addCrsLst.Add(rowIndex);
            else
                addCrsLst.Remove(rowIndex);
        }
        private void crsLstCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (crsLst.IsCurrentCellDirty)
            {
                crsLst.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void stdSchCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == -1)
                return;
            if (Convert.ToBoolean(stdSch.Rows[rowIndex].Cells[0].Value) == true)
                dropCrsLst.Add(rowIndex);
            else
                dropCrsLst.Remove(rowIndex);
        }
        private void stdSchCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (stdSch.IsCurrentCellDirty)
            {
                stdSch.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
