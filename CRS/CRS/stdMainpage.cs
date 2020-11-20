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
        student std;
        validity validityResult;
        Point startPosCrsLst;
        List<int> addCrsLst = new List<int>();
        List<int> dropCrsLst = new List<int>();

        // Utility variables
        string curDep = "";
        string curTitle = "";

        public mainpage(string usertype, string username, userDatabase usrDB, string cpath, string ppath)
        {
            // Store attributes
            InitializeComponent();
            this.username = username;
            crsDB = new courseDatabase(cpath, ref depBox, ref titleBox, ref usrDB);
            usrDB.addPrevCourses(ppath, ref this.crsDB, nextSemester);
            this.usrDB = usrDB;
            std = usrDB.getStudent(username);
            startPosCrsLst = crsLst.Location;


            // Change texts
            welcome.Text += std.fname + " " + std.lname;
            std.calculateGPA();
            gpa.Text += " " + std.GPA;
            credits.Text += " " + std.totalCredits;


            // Create all the tables
            createCrsLst("All");
            createCrsHist();
            createStdSch();

            if (usertype == "faculty")
            {
                createFacSchTable(facSchTable);
                createFacDropDown(facDropDown);
                createAdviseesTable(adviseeTable);
                adviseeTable.Visible = true;
                facSchTable.Visible = true;
            }
        }
        public mainpage(string usertype, string username, userDatabase usrDB, courseDatabase crsDB)
        {
            // Store attributes
            InitializeComponent();
            this.username = username;
            this.crsDB = crsDB;
            this.usrDB = usrDB;
            std = usrDB.getStudent(username);
            startPosCrsLst = crsLst.Location;


            // Change texts
            welcome.Text += std.fname + " " + std.lname;
            std.calculateGPA();
            gpa.Text += " " + std.GPA;
            credits.Text += " " + std.totalCredits;


            // Create all the tables
            createCrsLst("All");
            createCrsHist();
            createStdSch();

            if (usertype == "faculty")
            {
                createFacSchTable(facSchTable);
                createFacDropDown(facDropDown);
                createAdviseesTable(adviseeTable);
                adviseeTable.Visible = true;
                facSchTable.Visible = true;
            }
        }


        // Functions for all the tables
        private void createCrsLst(string dep)
        {
            if (crsLst.DataSource != null)
            {
                DataTable table = (DataTable)crsLst.DataSource;
                table.Rows.Clear();

                foreach (course crs in crsDB.getCourseList())
                    if (crs.crsID.Trim().StartsWith(dep) || dep == "All")
                        table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.seats + " / " + crs.maxSeats, crs.getBlocks());

                crsLst.DataSource = table;
                crsLst.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                crsLst.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                int width = crsLst.Columns[5].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                crsLst.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                crsLst.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                crsLst.Columns[5].Width = width;
            }
            else
            {
                DataTable table = new DataTable();
                table.Columns.Add("Course ID", typeof(string));
                table.Columns.Add("Title", typeof(string));
                table.Columns.Add("Faculty", typeof(string));
                table.Columns.Add("Credits", typeof(string));
                table.Columns.Add("Seats", typeof(string));
                table.Columns.Add("Schedule", typeof(string));

                foreach (course crs in crsDB.getCourseList())
                    if (crs.crsID.Trim().StartsWith(dep) || dep == "All")
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
            
        }
        private void createCrsHist()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course Name", typeof(string));
            table.Columns.Add("Semester", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Grade", typeof(string));

            foreach (previousCourse pcrs in std.pastCrs)
                table.Rows.Add(pcrs.crsID, pcrs.semester, pcrs.credit, pcrs.grade);

            crsHistTable.DataSource = table;
        }
        private void createStdSch()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Instructor", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Class times", typeof(string));

            foreach (course crs in std.registeredCrs)
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


        // Event handlers
        private void LogoutClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void gradeHistClick(object sender, EventArgs e)
        {
            this.ScrollControlIntoView(gradeHistContainer);
        }
        private void viewFacSchClick(object sender, EventArgs e)
        {
        }


        private void viewCrsLstClick(object sender, EventArgs e)
        {
            if (!crsLstContainer.Visible)
                crsLstContainer.Visible = true;
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
            MessageBox.Show(this.std.timeCheck(),
                    "Time Check",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            if (this.std.currentCrs.Count != 0)
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

            if (dep != curDep)
                createCrsLst(dep);

            //if (title != curTitle)
            //{
            //    for (int i = 0; i < crsLst.Rows.Count; i++)
            //    {
            //        string crsTitle = crsLst.Rows[i].Cells[2].Value.ToString();
            //        if (crsTitle.Trim() == title.Trim())
            //        {
            //            DataTable table = (DataTable)crsLst.DataSource;
            //            DataRow row = table.Rows[i];
            //            DataRow nr = table.NewRow();
            //            nr.ItemArray = row.ItemArray;   // Copy the row
            //            table.Rows.Remove(row);
            //            table.Rows.InsertAt(nr, 0);
            //            break;
            //        }
            //    }
            //    curTitle = title;
            //}
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
                List<DataGridViewRow> rowList = new List<DataGridViewRow>();
                foreach (int i in addCrsLst)
                    rowList.Add(crsLst.Rows[i]);

                for (int i = 0; i < count; i++)
                {
                    string crsID = rowList[i].Cells[1].Value.ToString().Trim();
                    int index = addCrsLst[i];
                    validityResult = std.isValidAdd(crsDB.getCourse(crsID));
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

                        usrDB.addCrsToStd(crsID, currentSemester, ref crsDB, std);

                        new addedCourse(crsID).Show();

                        // Update the course list table
                        DataGridViewRow row = crsLst.Rows[addCrsLst[i]];
                        course crs = crsDB.getCourse(row.Cells["Course ID"].Value.ToString());
                        if (row.Visible)
                            row.Cells["Seats"].Value = crs.seats + " / " + crs.maxSeats;
                        if (!addCrsLst.Contains(index))
                            addCrsLst.Insert(i, index);

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
                    }
                }

                for (int i = 0; i<addCrsLst.Count();i++)
                {
                    int index = addCrsLst[i];
                    crsLst.Rows[index].Cells[0].Value = null;
                    if (!addCrsLst.Contains(index))
                        addCrsLst.Insert(i, index);
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
                List<DataGridViewRow> rowList = new List<DataGridViewRow>();
                foreach (int i in dropCrsLst)
                    rowList.Add(stdSch.Rows[i]);

                for (int i = 0; i < count; i++)
                {
                    // Get the course id
                    DataGridViewRow r = rowList[i];
                    string crsID = r.Cells[1].Value.ToString().Trim();

                    // Drop the course from the student
                    usrDB.dropCrsFromStd(crsID, currentSemester, ref crsDB, std);

                    // Update the course list table
                    foreach (DataGridViewRow row in crsLst.Rows)
                    {
                        if (row.Cells["Course ID"].Value.ToString().Trim() == crsID)
                        {
                            if (row.Visible)
                            {
                                course crs = crsDB.getCourse(row.Cells["Course ID"].Value.ToString());
                                row.Cells["Seats"].Value = crs.seats + " / " + crs.maxSeats;
                                break;
                            }
                        }
                    }

                }

                foreach (DataGridViewRow row in rowList)
                    for (int l = 0; l < stdSch.Rows.Count; l++)
                        if (row.Cells[1].Value.ToString().Trim() == stdSch.Rows[l].Cells[1].Value.ToString().Trim())
                        {
                            stdSch.Rows.RemoveAt(l);
                            break;
                        }

                for (int i = 0; i < stdSch.Rows.Count; i++)
                    stdSch.Rows[i].Cells[0].Value = null;

                dropCrsLst.Clear();
                stdSch.ClearSelection();

                stdSch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                stdSch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                stdSch.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                int width = stdSch.Columns[4].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                stdSch.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                stdSch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                stdSch.Columns[4].Width = width;
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
            if (Convert.ToBoolean(crsLst.Rows[rowIndex].Cells[0].Value) == true && !addCrsLst.Contains(rowIndex))
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
