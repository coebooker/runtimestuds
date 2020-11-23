using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CRS
{
    public partial class admMainpage : Form
    {
        public userDatabase usrDB;
        public courseDatabase crsDB;
        string nextSemester = "S15";
        string stdUsername = "";
        string facUsername = "";
        List<string> addCrsLst = new List<string>();
        List<string> dropCrsLst = new List<string>();
        List<string> manSelectedCrsLst = new List<string>();
        List<string> manSelectedStdLst = new List<string>();
        List<string> manSelectedFacLst = new List<string>();

        public admMainpage(userDatabase usrDB, string ppath, string usertype)
        {
            // Store attributes
            InitializeComponent();
            crsDB = new courseDatabase(ref usrDB);
            usrDB.addPrevCourses(ref crsDB, nextSemester);
            this.usrDB = usrDB;

            // If the user is admin, hide managers' interactions
            if (usertype == "admin")
                manSelect.Visible = false;

            // Add usernames to search boxes for auto completion
            foreach (student std in usrDB.getStudentList())
            {
                stdSearchBox.AutoCompleteCustomSource.Add(std.username);
                manStdSearchBox.AutoCompleteCustomSource.Add(std.username);
            }
            foreach(faculty fac in usrDB.getFacultyList())
            {
                facSearchBox.AutoCompleteCustomSource.Add(fac.username);
                manFacSearchBox.AutoCompleteCustomSource.Add(fac.username);
            }
            foreach (course crs in crsDB.getCourseList())
            {
                crsIDBox.AutoCompleteCustomSource.Add(crs.crsID);
                manCrsIDBox.AutoCompleteCustomSource.Add(crs.crsID);
            }
        }
        public admMainpage(userDatabase usrDB, courseDatabase crsDB, string usertype)
        {
            InitializeComponent();
            this.usrDB = usrDB;
            this.crsDB = crsDB;

            // Hide managers' interactions if the user is an administrator
            if (usertype == "admin")
                manSelect.Visible = false;

            // Add usernames to search boxes for auto completion
            foreach (student std in usrDB.getStudentList())
            {
                stdSearchBox.AutoCompleteCustomSource.Add(std.username);
                manStdSearchBox.AutoCompleteCustomSource.Add(std.username);
            }
            foreach (faculty fac in usrDB.getFacultyList())
            {
                facSearchBox.AutoCompleteCustomSource.Add(fac.username);
                manFacSearchBox.AutoCompleteCustomSource.Add(fac.username);
            }
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

            DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
            btn.ValueType = typeof(bool);
            crsLst.Columns.Insert(0, btn);
            crsLst.Columns[0].HeaderText = "Add";
            crsLst.Columns[0].Name = "Add";
            crsLst.ClearSelection();

            foreach (DataGridViewColumn col in crsLst.Columns)
                col.ReadOnly = true;
            crsLst.Columns[0].ReadOnly = false;
        }

        // Create table frames for students' interactions (Not populating)
        //--------------------------------------------------------------------
        public void createStdLst()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Username");
            table.Columns.Add("First Name");
            table.Columns.Add("Last Name");
            table.Columns.Add("Advisor");
            table.Columns.Add("GPA");
            table.Columns.Add("Credits");

            stdLst.DataSource = table;

            DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
            btn.ValueType = typeof(bool);
            stdLst.Columns.Insert(0, btn);
            stdLst.Columns[0].HeaderText = "Select";
            stdLst.Columns[0].Name = "Select";
            stdLst.ClearSelection();

            foreach (DataGridViewColumn col in stdLst.Columns)
                col.ReadOnly = true;
            stdLst.Columns[0].ReadOnly = false;
        } 
        public void createStdSch()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Instructor", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Schedule", typeof(string));

            stdSch.DataSource = table;

            DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
            stdSch.Columns.Insert(0, btn);
            stdSch.Columns[0].HeaderText = "Drop";
            stdSch.Columns[0].Name = "Drop";
            stdSch.ClearSelection();

            foreach (DataGridViewColumn col in stdSch.Columns)
                col.ReadOnly = true;
            stdSch.Columns[0].ReadOnly = false;
        } 
        public void createGradeHist()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Semester", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Grade", typeof(string));

            gradeHist.DataSource = table;
        }


        // Create table frames for faculties' interactions (Not populating)
        //----------------------------------------------------------------------
        public void createFacLst()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Username");
            table.Columns.Add("First Name");
            table.Columns.Add("Last Name");

            facLst.DataSource = table;

            DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
            btn.ValueType = typeof(bool);
            facLst.Columns.Insert(0, btn);
            facLst.Columns[0].HeaderText = "Select";
            facLst.Columns[0].Name = "Select";
            facLst.ClearSelection();

            foreach (DataGridViewColumn col in facLst.Columns)
                col.ReadOnly = true;
            facLst.Columns[0].ReadOnly = false;
        }
        public void createFacSch()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Schedule", typeof(string));

            facSch.DataSource = table;

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


        // Create table frames for managers' interactions (Not populating)
        //--------------------------------------------------------------------
        public void createManCrsLst()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Instructor", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Seats", typeof(string));
            table.Columns.Add("Schedule", typeof(string));

            manCrsLst.DataSource = table;

            DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
            btn.ValueType = typeof(bool);
            manCrsLst.Columns.Insert(0, btn);
            manCrsLst.Columns[0].HeaderText = "Select";
            manCrsLst.Columns[0].Name = "Select";

            foreach (DataGridViewColumn col in manCrsLst.Columns)
                col.ReadOnly = true;
            manCrsLst.Columns[0].ReadOnly = false;
        }
        public void createManStdLst()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Username");
            table.Columns.Add("First Name");
            table.Columns.Add("Last Name");
            table.Columns.Add("Advisor");
            table.Columns.Add("GPA");
            table.Columns.Add("Credits");

            manStdLst.DataSource = table;

            DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
            btn.ValueType = typeof(bool);
            manStdLst.Columns.Insert(0, btn);
            manStdLst.Columns[0].HeaderText = "Select";
            manStdLst.Columns[0].Name = "Select";
            manStdLst.ClearSelection();

            foreach (DataGridViewColumn col in manStdLst.Columns)
                col.ReadOnly = true;
            manStdLst.Columns[0].ReadOnly = false;
        }
        public void createManFacLst()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Username");
            table.Columns.Add("First Name");
            table.Columns.Add("Last Name");

            manFacLst.DataSource = table;

            DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
            btn.ValueType = typeof(bool);
            manFacLst.Columns.Insert(0, btn);
            manFacLst.Columns[0].HeaderText = "Select";
            manFacLst.Columns[0].Name = "Select";
            manFacLst.ClearSelection();

            foreach (DataGridViewColumn col in manFacLst.Columns)
                col.ReadOnly = true;
            manFacLst.Columns[0].ReadOnly = false;
        }


        // Select the user type (Populate tables at the same time)
        //-----------------------------------------------------------------
        private void stdSelectClick(object sender, System.EventArgs e)
        {
            // Populate the student list
            if (stdLst.DataSource == null)
                createStdLst();
            DataTable table = (DataTable)stdLst.DataSource;
            table.Rows.Clear();
            foreach (student std in usrDB.getStudentList())
                table.Rows.Add(std.username, std.fname, std.lname, std.advisor, std.GPA, std.totalCredits);

            // Populate the list of courses
            if (crsLst.DataSource == null)
                createCrsLst();
            table = (DataTable)crsLst.DataSource;
            table.Rows.Clear();
            foreach (course crs in crsDB.getCourseList())
                table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.seats + " / " + crs.maxSeats, crs.getBlocks());
            crsLst.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            crsLst.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            int width = crsLst.Columns["Schedule"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            crsLst.Columns["Schedule"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            crsLst.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            crsLst.Columns["Schedule"].Width = width;

            // Mark student tag button
            stdSelect.BackColor = Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            facSelect.BackColor = Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            manSelect.BackColor = Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));

            // Display tables for students' interactions
            stdLstContainer.Visible = true;
            crsLstContainer.Visible = true;
            addCrs.Visible = true;
            crsLst.Columns[0].Visible = true;
            stdActions.Visible = true;

            // Hide tables
            stdSchContainer.Visible = false;
            gradeHistContainer.Visible = false;
            manActions.Visible = false;
            manCrsLstContainer.Visible = false;
            manStdLstContainer.Visible = false;
            manFacLstContainer.Visible = false;
            //facActions.Visible = false;
            facLstContainer.Visible = false;
            facSchContainer.Visible = false;
            adviseeLstContainer.Visible = false;
            addCrsLst.Clear();
            dropCrsLst.Clear();
            manSelectedCrsLst.Clear();
            manSelectedStdLst.Clear();
            manSelectedFacLst.Clear();
            stdUsername = "";
            facUsername = "";

            stdLst.ClearSelection();
        }
        private void facSelectClick(object sender, System.EventArgs e)
        {
            // Populate the list of faculties
            if (facLst.DataSource == null)
                createFacLst();
            DataTable table = (DataTable)facLst.DataSource;
            table.Rows.Clear();
            foreach (faculty fac in usrDB.getFacultyList())
                table.Rows.Add(fac.username, fac.fname, fac.lname);

            // Populate the list of courses
            if (crsLst.DataSource == null)
                createCrsLst();
            table = (DataTable)crsLst.DataSource;
            table.Rows.Clear();
            foreach (course crs in crsDB.getCourseList())
                table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.seats + " / " + crs.maxSeats, crs.getBlocks());
            crsLst.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            crsLst.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            int width = crsLst.Columns["Schedule"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            crsLst.Columns["Schedule"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            crsLst.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            crsLst.Columns["Schedule"].Width = width;

            // Mark faculty tag
            facSelect.BackColor = Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            stdSelect.BackColor = Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            manSelect.BackColor = Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));

            // Hide everything else
            crsLst.Columns[0].Visible = false;
            addCrs.Visible = false;
            facSchContainer.Visible = false;
            adviseeLstContainer.Visible = false;
            stdLstContainer.Visible = false;
            gradeHistContainer.Visible = false;
            stdActions.Visible = false;
            stdSchContainer.Visible = false;
            manActions.Visible = false;
            manStdLstContainer.Visible = false;
            manCrsLstContainer.Visible = false;
            manFacLstContainer.Visible = false;

            facLstContainer.Visible = true;
            crsLstContainer.Visible = true;
            facActions.Visible = true;
            addCrsLst.Clear();
            dropCrsLst.Clear();
            manSelectedCrsLst.Clear();
            manSelectedStdLst.Clear();
            manSelectedFacLst.Clear();
            stdUsername = "";
            facUsername = "";
        }
        private void manSelectClick(object sender, EventArgs e)
        {
            // Populate the course list for managers
            if (manCrsLst.DataSource == null)
                createManCrsLst();
            DataTable table = (DataTable)manCrsLst.DataSource;
            table.Rows.Clear();
            foreach (course crs in crsDB.getCourseList())
                table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.seats + " / " + crs.maxSeats, crs.getBlocks());

            manCrsLst.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            manCrsLst.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            int width = manCrsLst.Columns["Schedule"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            manCrsLst.Columns["Schedule"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            manCrsLst.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            manCrsLst.Columns["Schedule"].Width = width;

            // Populate the student list for managers
            if (manStdLst.DataSource == null)
                createManStdLst();
            table = (DataTable)manStdLst.DataSource;
            table.Rows.Clear();
            foreach (student std in usrDB.getStudentList())
                table.Rows.Add(std.username, std.fname, std.lname, std.advisor, std.GPA, std.totalCredits);

            // Populate the faculty list for managers
            if (manFacLst.DataSource == null)
                createManFacLst();
            table = (DataTable)manFacLst.DataSource;
            table.Rows.Clear();
            foreach (faculty fac in usrDB.getFacultyList())
                table.Rows.Add(fac.username, fac.fname, fac.lname);

            // Mark manager tag
            manSelect.BackColor = Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            facSelect.BackColor = Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            stdSelect.BackColor = Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));

            //
            crsLstContainer.Visible = false;
            stdLstContainer.Visible = false;
            stdSchContainer.Visible = false;
            gradeHistContainer.Visible = false;
            stdActions.Visible = false;
            facLstContainer.Visible = false;
            facSchContainer.Visible = false;
            adviseeLstContainer.Visible = false;
            facActions.Visible = false;
            manCrsLstContainer.Visible = true;
            manStdLstContainer.Visible = true;
            manFacLstContainer.Visible = true;
            manActions.Visible = true;
            addCrsLst.Clear();
            dropCrsLst.Clear();
            manSelectedCrsLst.Clear();
            manSelectedStdLst.Clear();
            manSelectedFacLst.Clear();
            stdUsername = "";
            facUsername = "";
        }


        // Student interactions
        //---------------------------------------------------------
        private void stdConfirmClick(object sender, EventArgs e)
        {
            if (stdLst.SelectedRows.Count == 0)
                MessageBox.Show("Select a student from the list below.",
                    "No student selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
                stdUsername = stdLst.SelectedRows[0].Cells["Username"].Value.ToString().Trim();
                student std = usrDB.getStudent(stdUsername);

                // Populate the student schedule
                if (stdSch.DataSource == null)
                    createStdSch();
                DataTable table = (DataTable)stdSch.DataSource;
                table.Rows.Clear();
                foreach (course crs in std.registeredCrs)
                    table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.getBlocks());

                // Populate the student's course history
                if (gradeHist.DataSource == null)
                    createGradeHist();
                table = (DataTable)gradeHist.DataSource;
                foreach (previousCourse pcrs in std.pastCrs)
                    table.Rows.Add(pcrs.crsID, pcrs.semester, pcrs.credit, pcrs.grade);
                gpa.Text = "GPA :" + std.GPA.ToString();
                credits.Text = "Credits :" + std.totalCredits.ToString();

                stdLstContainer.Visible = false;
                stdSchContainer.Visible = true;
                gradeHistContainer.Visible = true;
            }
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
        private void addCrsClick(object sender, EventArgs e)
        {
            int count = addCrsLst.Count;
            if (count == 0)
                MessageBox.Show("Select classes",
                    "No class selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
                foreach (string crsID in addCrsLst)
                {
                    // Add the course to the student
                    student std = usrDB.getStudent(stdUsername);
                    validity v = std.isValidAdd(crsDB.getCourse(crsID.Trim()));
                    if (!v.valid)
                    {
                        if (MessageBox.Show(crsID + "\n" + v.message + "\n\nAre you sure you want to continue?", "Invalid Add", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                            ;
                        else
                        {
                            MessageBox.Show("No courses have been added.",
                                "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    if (v.warning)
                        MessageBox.Show(v.message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    usrDB.addCrsToStd(crsID, nextSemester, ref crsDB, std);

                    // Update the course list and student schedule
                    foreach (DataGridViewRow row in crsLst.Rows)
                        if (row.Cells["Course ID"].Value.ToString().ToString() == crsID)
                            if (row.Visible)
                            {
                                course crs = crsDB.getCourse(crsID);
                                row.Cells["Seats"].Value = crs.seats + " / " + crs.maxSeats;
                                DataTable table = (DataTable)stdSch.DataSource;
                                table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.getBlocks());
                                break;
                            }
                }

                crsLst.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                crsLst.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                crsLst.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                int width = crsLst.Columns["Schedule"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                crsLst.Columns["Schedule"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                crsLst.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                crsLst.Columns["Schedule"].Width = width;

                crsLst.ClearSelection();
                for (int i = 0; i < crsLst.Rows.Count; i++)
                    crsLst.Rows[i].Cells["Add"].Value = null;
                addCrsLst.Clear();
                MessageBox.Show("The process completed.",
                    "Done",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private void dropCrsClick(object sender, EventArgs e)
        {
            int count = dropCrsLst.Count;

            if (count == 0)
                MessageBox.Show("Select a class",
                    "No Class",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
                foreach (string crsID in dropCrsLst)
                {
                    // Drop the course from the student
                    student std = usrDB.getStudent(stdUsername);
                    usrDB.dropCrsFromStd(crsID, ref crsDB, std);

                    // Update the course list
                    foreach (DataGridViewRow row in crsLst.Rows)
                        if (row.Cells["Course ID"].Value.ToString().Trim() == crsID)
                            if (row.Visible)
                            {
                                course crs = crsDB.getCourse(crsID);
                                row.Cells["Seats"].Value = crs.seats + " / " + crs.maxSeats;
                            }

                    // Update the student table
                    foreach (DataGridViewRow row in stdSch.Rows)
                        if (row.Cells["Course ID"].Value.ToString().Trim() == crsID)
                        {
                            stdSch.Rows.Remove(row);
                            break;
                        }
                }

                // Update the course list too because when we made the change to the table above
                // It messed up things
                for (int i = 0; i < stdSch.Rows.Count; i++)
                    stdSch.Rows[i].Cells["Drop"].Value = null;
                for (int i = 0; i < crsLst.RowCount; i++)
                    crsLst.Rows[i].Cells["Add"].Value = null;

                dropCrsLst.Clear();
                addCrsLst.Clear();
                stdSch.ClearSelection();
            }
        }
        private void curSchClick(object sender, EventArgs e)
        {
            if (stdLst.SelectedRows.Count == 0)
                MessageBox.Show("Select a student from the list",
                    "No student selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
                string username = stdLst.SelectedRows[0].Cells["Username"].Value.ToString().Trim();
                student std = usrDB.getStudent(username);

                string message = std.fname + " " + std.lname + " is taking the following courses :\n";
                foreach (previousCourse pcrs in std.currentCrs)
                    message += "    " + pcrs.crsID + "   " + pcrs.credit + " credits" + "\n";
                MessageBox.Show(message, "Current Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void showGradeHistClick(object sender, EventArgs e)
        {
            if (stdLst.SelectedRows.Count == 0)
                MessageBox.Show("Select a student from the list",
                    "No student selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
                ScrollControlIntoView(gradeHist);
        }
        private void showDropCrsClick(object sender, System.EventArgs e)
        {
            if (stdLst.Visible)
            {
                MessageBox.Show("Select a student from the list of students",
                    "No student selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (dropCrsLst.Count == 0)
            {
                MessageBox.Show("Select a course from the student schedule.",
                    "No class selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else
                MessageBox.Show("Press the button above the student schedule.",
                    "Wrong button",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
        private void showAddCrsClick(object sender, System.EventArgs e)
        {
            if (stdLst.Visible)
            {
                MessageBox.Show("Select a student from the list of students",
                    "No student selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (addCrsLst.Count == 0)
            {
                MessageBox.Show("Select a course from the list of offerings.",
                    "No class selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Press the button above the course list.",
                    "Different button",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
        private void conflictCheckClick(object sender, System.EventArgs e)
        {
            if (stdLst.SelectedRows.Count == 0)
                MessageBox.Show("Select a student from the list",
                    "No student selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
                MessageBox.Show(usrDB.getStudent(stdUsername).timeCheck(),
                    "Time Check",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private void stdSearchClick(object sender, EventArgs e)
        {
            string username = stdSearchBox.Text.Trim().ToLower();   // Needed ToLower()

            if (stdActions.Visible)
                for (int i = 0; i < stdLst.RowCount; i++)
                    if (stdLst.Rows[i].Cells["Username"].Value.ToString().Trim() == username)
                    {
                        DataTable table = (DataTable)stdLst.DataSource;
                        DataRow dr = table.Rows[i];
                        DataRow nr = table.NewRow();
                        nr.ItemArray = dr.ItemArray;
                        table.Rows.Remove(dr);
                        table.Rows.InsertAt(nr, 0);
                        break;
                    }
        }
        private void stdViewCrsLstClick(object sender, EventArgs e)
        {
            ScrollControlIntoView(crsLst);
        }

        private void crsLstCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;
            string crsID = crsLst.Rows[rowIndex].Cells["Course ID"].Value.ToString().Trim();
            if (Convert.ToBoolean(crsLst.Rows[rowIndex].Cells["Add"].Value) == true)
            {
                if (!addCrsLst.Contains(crsID))
                    addCrsLst.Add(crsID);
                else
                    return;
            }
            else
                addCrsLst.Remove(crsID);
        }
        private void stdSchCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;
            string crsID = stdSch.Rows[rowIndex].Cells["Course ID"].Value.ToString().Trim();
            if (Convert.ToBoolean(stdSch.Rows[rowIndex].Cells["Drop"].Value) == true)
            {
                if (!dropCrsLst.Contains(crsID))
                    dropCrsLst.Add(crsID);
                else
                    return;
            }
            else
                dropCrsLst.Remove(crsID);
        }
        private void stdLstCellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;
            for (int i = 0; i < stdLst.RowCount; i++)
            {
                if (i == rowIndex)
                {
                    stdLst.Rows[rowIndex].Selected = true;
                    stdLst.Rows[rowIndex].Cells[0].Value = true;
                }
                else
                    stdLst.Rows[i].Cells[0].Value = null;
            }
        }

        private void stdSchCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (stdSch.IsCurrentCellDirty)
                stdSch.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void crsLstCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (crsLst.IsCurrentCellDirty)
                crsLst.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void stdLstCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (stdLst.IsCurrentCellDirty)
            {
                stdLst.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }


        // Faculty interactions
        //----------------------------------------------------------------------
        private void facConfirmClick(object sender, EventArgs e)
        {
            if (facLst.SelectedRows.Count == 0)
                MessageBox.Show("Select a faculty from the list",
                    "No faculty selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
                facUsername = facLst.SelectedRows[0].Cells["Username"].Value.ToString();
                faculty fac = usrDB.getFaculty(facUsername);

                // Populate the faculty schedule
                if (facSch.DataSource == null)
                    createFacSch();
                DataTable table = (DataTable)facSch.DataSource;
                table.Rows.Clear();
                foreach (course crs in fac.nextSemesterCourses)
                    table.Rows.Add(crs.crsID, crs.title, crs.getBlocks());

                facSch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                facSch.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                int width = facSch.Columns["Schedule"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                facSch.Columns["Schedule"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                facSch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                facSch.Columns["Schedule"].Width = width;

                // Populate the advisees list
                if (adviseeLst.DataSource == null)
                    createAdviseeLst();
                table = (DataTable)adviseeLst.DataSource;
                table.Rows.Clear();
                foreach (student std in fac.adviseesLst)
                    table.Rows.Add(std.username, std.fname, std.lname, std.GPA, std.totalCredits);

                facSchContainer.Visible = true;
                adviseeLstContainer.Visible = true;
                facLstContainer.Visible = false;
            }
        }
        private void facSearchClick(object sender, EventArgs e)
        {
            string username = facSearchBox.Text.ToLower().Trim();

            if (facActions.Visible)
                for (int i = 0; i < facLst.RowCount; i++)
                    if (facLst.Rows[i].Cells["Username"].Value.ToString().Trim() == username)
                    {
                        DataTable table = (DataTable)facLst.DataSource;
                        DataRow dr = table.Rows[i];
                        DataRow nr = table.NewRow();
                        nr.ItemArray = dr.ItemArray;
                        table.Rows.Remove(dr);
                        table.Rows.InsertAt(nr, 0);
                        break;
                    }
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
            if (!facSch.Visible)
                MessageBox.Show("Select a faculty from the list.",
                    "No faculty selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                ScrollControlIntoView(facSch);
        }
        private void facViewAdviseesClick(object sender, EventArgs e)
        {
            if (!adviseeLst.Visible)
                MessageBox.Show("Select a faculty from the list.",
                    "No faculty selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                ScrollControlIntoView(adviseeLst);
        }
        private void facScrollToTopClick(object sender, EventArgs e)
        {
            ScrollControlIntoView(header);
        }


        private void facLstCellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;
            for (int i = 0; i < facLst.RowCount; i++)
            {
                if (i == rowIndex)
                {
                    facLst.Rows[rowIndex].Selected = true;
                    facLst.Rows[rowIndex].Cells["Select"].Value = true;
                }
                else
                    facLst.Rows[i].Cells["Select"].Value = null;
            }
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


        private void facLstCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (facLst.IsCurrentCellDirty)
                facLst.CommitEdit(DataGridViewDataErrorContexts.Commit);
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


        // Manager interactions
        //----------------------------------------------------------------------
        private void removeCrsClick(object sender, EventArgs e)
        {
            int count = manSelectedCrsLst.Count;
            if (count == 0)
            {
                MessageBox.Show("Select courses from the list below",
                        "No course selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                ScrollControlIntoView(manCrsLst);
            }
            else
            {
                string message = "Are you sure you want to remove :\n";
                foreach (string crsID in manSelectedCrsLst)
                    message += "     " + crsID + "\n";
                if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    MessageBox.Show("No courses have been removed.",
                        "Cancel",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                // Remove the courses from the database
                List<int> indexList = new List<int>();  // For later when removing rows
                foreach (string crsID in manSelectedCrsLst)
                    foreach (DataGridViewRow row in manCrsLst.Rows)
                        if (row.Cells["Course ID"].Value.ToString().Trim() == crsID)
                        {
                            crsDB.removeCrs(crsID, @"..\..\courseDB.in", ref usrDB);
                            indexList.Add(row.Index);
                            break;
                        }

                // Remove the courses from the table
                for (int i = 0; i < indexList.Count; i++)
                {
                    manCrsLst.Rows.RemoveAt(indexList[i]);
                    for (int l = i + 1; l < indexList.Count; l++)
                        if (indexList[l] > indexList[i])
                            indexList[l] -= 1;
                }

                manSelectedCrsLst.Clear();
                manCrsLst.ClearSelection();

                MessageBox.Show("Removal successfully executed.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private void admChangeAdvisorClick(object sender, EventArgs e)
        {
            if (stdLst.SelectedRows.Count == 0)
                MessageBox.Show("Select a student from the list",
                    "No student selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
                stdUsername = stdLst.SelectedRows[0].Cells["Username"].Value.ToString().Trim();
                student std = usrDB.getStudent(stdUsername);
                var form = new admChangeAdvisor(usrDB, std.advisor);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    string newAdvisor = form.newAdvisor;
                    usrDB.changeAdvisor(std.username.Trim(), newAdvisor.Trim());

                    stdLst.SelectedRows[0].Cells["Advisor"].Value = std.advisor;
                    stdLst.SelectedRows[0].Cells["Select"].Value = null;

                    MessageBox.Show("The advisor has been changed.",
                        "Advisor changed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("The advisor was not changed.",
                        "No change made",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
        }
        private void manChangeAdvisorClick(object sender, EventArgs e)
        {
            int count = manSelectedStdLst.Count;
            if (count == 0)
                MessageBox.Show("Select a student from the list below",
                    "No student selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else if (count >= 2)
            {
                MessageBox.Show("To change advisor, select one student at a time",
                    "Vague",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else
            {
                stdUsername = manSelectedStdLst[0];
                student std = usrDB.getStudent(stdUsername);
                var form = new admChangeAdvisor(usrDB, std.advisor);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    string message = "Are you sure you want to change " + std.username + "'s advisor?";
                    if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        MessageBox.Show("No students have been removed.",
                            "Cancel",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        usrDB.changeAdvisor(stdUsername, form.newAdvisor.Trim());
                        foreach (DataGridViewRow row in manStdLst.Rows)
                            if (row.Cells["Username"].Value.ToString().Trim() == stdUsername)
                            {
                                row.Cells["Advisor"].Value = std.advisor;
                                row.Cells["Select"].Value = null;
                                break;
                            }
                        MessageBox.Show("Change successfully made.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("The advisor was not changed.",
                        "No change made",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
        }
        private void createCrsClick(object sender, EventArgs e)
        {
            var form = new admCreateCrs(crsDB, usrDB);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                crsDB.addCrs(form.crs, @"..\..\courseDB.in");
                MessageBox.Show("Course successfully created.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                DataTable table = (DataTable)manCrsLst.DataSource;
                table.Rows.Add(form.crs.crsID, form.crs.title, form.crs.instructor, form.crs.credit, form.crs.seats + " / " + form.crs.seats, form.crs.getBlocks());
                manCrsIDBox.AutoCompleteCustomSource.Add(form.crs.crsID.Trim());
                crsIDBox.AutoCompleteCustomSource.Add(form.crs.crsID.Trim());
            }
            else
                MessageBox.Show("No courses have been added.",
                        "No change made",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
        }
        private void removeStdClick(object sender, EventArgs e)
        {
            int count = manSelectedStdLst.Count;
            if (count == 0)
            {
                MessageBox.Show("Select students from the list below",
                    "No student selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Confirmation
            string message = "Are you sure you want to remove :\n";
            foreach (string uname in manSelectedStdLst)
                message += "       " + uname + "\n";
            if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                MessageBox.Show("No students have been removed.",
                    "Cancel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                List<int> indexList = new List<int>();  // For later when removing rows
                foreach (string uname in manSelectedStdLst)
                    foreach (DataGridViewRow row in manStdLst.Rows)
                        if (row.Cells["Username"].Value.ToString().Trim() == uname.Trim())
                        {
                            usrDB.removeStd(uname, ref crsDB);
                            indexList.Add(row.Index);
                            break;
                        }

                // Remove the students from table
                for (int i = 0; i < indexList.Count; i++)
                {
                    manStdLst.Rows.RemoveAt(indexList[i]);
                    for (int l = i + 1; l < indexList.Count; l++)
                        if (indexList[l] > indexList[i])
                            indexList[l] -= 1;
                }

                // Update the course list

                manSelectedStdLst.Clear();
                manStdLst.ClearSelection();

                MessageBox.Show("Removal succesfully executed.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void removeFacClick(object sender, EventArgs e)
        {
            int count = manSelectedFacLst.Count;
            if (count == 0)
            {
                MessageBox.Show("Select faculties from the list below",
                    "No faculty selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Confirmation
            string message = "Are you sure you want to remove :\n";
            foreach (string uname in manSelectedFacLst)
                message += "              " + uname + "\n";
            if (MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                MessageBox.Show("No faculties have been removed.",
                    "Cancel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                foreach (string uname in manSelectedFacLst)
                    foreach (DataGridViewRow row in manFacLst.Rows)
                        if (row.Cells["Username"].Value.ToString().Trim() == uname.Trim())
                        {
                            usrDB.removeFac(uname);
                            crsDB.removeFac(uname); // Lowered in the function
                            break;
                        }

                // Remove the faculties from table and update the course list
                foreach (string fac in manSelectedFacLst)
                {
                    foreach (DataGridViewRow row in manFacLst.Rows)
                        if (fac.Trim() == row.Cells["Username"].Value.ToString().Trim())
                        {
                            manFacLst.Rows.Remove(row);
                            break;
                        }
                    
                    foreach(DataGridViewRow row in manCrsLst.Rows)
                        if (row.Cells["Instructor"].Value.ToString().Trim() == fac.Trim())
                            row.Cells["Instructor"].Value = "Staff";

                    foreach (DataGridViewRow row in manStdLst.Rows)
                        if (row.Cells["Advisor"].Value.ToString().Trim() == fac.Trim())
                            row.Cells["Advisor"].Value = "Staff";
                }

                foreach (DataGridViewRow row in manCrsLst.Rows)
                    row.Cells["Select"].Value = null;
                foreach (DataGridViewRow row in manFacLst.Rows)
                    row.Cells["Select"].Value = null;
                foreach (DataGridViewRow row in manStdLst.Rows)
                    row.Cells["Select"].Value = null;

                manSelectedCrsLst.Clear();
                manSelectedFacLst.Clear();
                manSelectedStdLst.Clear();
                manFacLst.ClearSelection();

                MessageBox.Show("Process complete.",
                    "Complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private void createUserClick(object sender, EventArgs e)
        {
            var form = new admCreateUser(usrDB);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
                usrDB.addUser(form.uname, form.pword, form.fName, form.mName, form.lName, form.uType, @"..\..\userDB.in");
            else
                MessageBox.Show("No users have been added.",
                        "No change made",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
        }
        private void manCrsSearchClick(object sender, EventArgs e)
        {
            string crsID = manCrsIDBox.Text.Trim();

            if (manCrsLst.Visible)
                for (int i = 0; i < manCrsLst.RowCount; i++)
                    if (manCrsLst.Rows[i].Cells["Course ID"].Value.ToString().Trim() == crsID)
                    {
                        DataTable table = (DataTable)manCrsLst.DataSource;
                        DataRow dr = table.Rows[i];
                        DataRow nr = table.NewRow();
                        nr.ItemArray = dr.ItemArray;
                        table.Rows.Remove(dr);
                        table.Rows.InsertAt(nr, 0);
                        break;
                    }
        }
        private void changeCrsClick(object sender, EventArgs e)
        {
            if (manSelectedCrsLst.Count == 0)
            {
                MessageBox.Show("Select a course from the list below",
                        "No course selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                ScrollControlIntoView(manCrsLst);
            }
            else if (manSelectedCrsLst.Count >= 2)
            {
                MessageBox.Show("To change a course, select one at a time",
                    "Vague",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                course crs = crsDB.getCourse(manSelectedCrsLst[0]);
                string oldInstructor = crs.instructor;
                var form = new admChangeCrs(crs, usrDB);
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    if (crs.instructor != oldInstructor)
                    {
                        crsDB.changeCourse(crs.crsID, crs.instructor, form.crs.timeBlocks);
                        foreach (DataGridViewRow row in manCrsLst.Rows)
                            if (row.Cells["Course ID"].Value.ToString().Trim() == crs.crsID.Trim())
                            {
                                row.Cells["Schedule"].Value = crs.getBlocks();
                                row.Cells["Instructor"].Value = crs.instructor;
                                row.Cells["Select"].Value = null;
                                break;
                            }
                        usrDB.changeInstrutor(crsDB, crs.instructor.ToLower(), oldInstructor, crs.crsID);
                    }
                    else
                    {
                        crsDB.changeCourse(crs.crsID, form.crs.instructor, form.crs.timeBlocks);
                        foreach (DataGridViewRow row in manCrsLst.Rows)
                            if (row.Cells["Course ID"].Value.ToString().Trim() == crs.crsID.Trim())
                            {
                                row.Cells["Schedule"].Value = crs.getBlocks();
                                row.Cells["Instructor"].Value = crs.instructor;
                                row.Cells["Select"].Value = null;
                                break;
                            }
                        usrDB.changeTime(crs.crsID, crs.instructor, crsDB);
                    }
                    MessageBox.Show("The process complete.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("No changes have been added.",
                        "No change made",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }

        }
        private void manStdSearchClick(object sender, EventArgs e)
        {
            string username = manStdSearchBox.Text.ToLower().Trim();    // Needed ToLower()

            if (manStdLst.Visible)
                for (int i = 0; i < manStdLst.RowCount; i++)
                    if (manStdLst.Rows[i].Cells["Username"].Value.ToString().Trim() == username)
                    {
                        DataTable table = (DataTable)manStdLst.DataSource;
                        DataRow dr = table.Rows[i];
                        DataRow nr = table.NewRow();
                        nr.ItemArray = dr.ItemArray;
                        table.Rows.Remove(dr);
                        table.Rows.InsertAt(nr, 0);
                        break;
                    }
        }

        private void manCrsLstCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == -1)
                return;
            string crsID = manCrsLst.Rows[rowIndex].Cells["Course ID"].Value.ToString().Trim();
            if (Convert.ToBoolean(manCrsLst.Rows[rowIndex].Cells["Select"].Value) == true)
            {
                if (!manSelectedCrsLst.Contains(crsID))
                    manSelectedCrsLst.Add(crsID);
                else
                    return;
            }
            else
                manSelectedCrsLst.Remove(crsID);
        }
        private void manStdLstCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == -1)
                return;
            string uname = manStdLst.Rows[rowIndex].Cells["Username"].Value.ToString().Trim();
            if (Convert.ToBoolean(manStdLst.Rows[rowIndex].Cells["Select"].Value) == true)
            {
                if (!manSelectedStdLst.Contains(uname))
                    manSelectedStdLst.Add(uname);
                else
                    return;
            }
            else
                manSelectedStdLst.Remove(uname);
        }
        private void manFacLstCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == -1)
                return;
            string uname = manFacLst.Rows[rowIndex].Cells["Username"].Value.ToString().Trim();
            if (Convert.ToBoolean(manFacLst.Rows[rowIndex].Cells["Select"].Value) == true)
            {
                if (!manSelectedFacLst.Contains(uname))
                    manSelectedFacLst.Add(uname);
                else
                    return;
            }
            else
                manSelectedFacLst.Remove(uname);
        }

        private void manStdLstCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (manStdLst.IsCurrentCellDirty)
            {
                manStdLst.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void manCrsLstCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (manCrsLst.IsCurrentCellDirty)
            {
                manCrsLst.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void manFacCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (manFacLst.IsCurrentCellDirty)
            {
                manFacLst.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void logoutClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void stdScrollToTopClick(object sender, EventArgs e)
        {
            ScrollControlIntoView(header);
        }
        private void manScrollToTopCLick(object sender, EventArgs e)
        {
            ScrollControlIntoView(header);
        }
    }
}