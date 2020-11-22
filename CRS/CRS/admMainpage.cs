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
    public partial class admMainpage : Form
    {
        public userDatabase usrDB;
        public courseDatabase crsDB;
        string nextSemester = "S15";
        string currentSemester = "F14";
        string stdUsername = "";
        List<int> addCrsLst = new List<int>();
        List<int> dropCrsLst = new List<int>();
        List<string> manSelectedCrsLst = new List<string>();
        List<string> manSelectedStdLst = new List<string>();
        List<int> manSelectedFacLst = new List<int>();

        public admMainpage(userDatabase usrDB, string cpath, string ppath, string usertype)
        {
            InitializeComponent();
            crsDB = new courseDatabase(cpath, ref usrDB);
            usrDB.addPrevCourses(ppath, ref crsDB, nextSemester);
            this.usrDB = usrDB;
            if (usertype == "admin")
                manSelect.Visible = false;
            foreach (student std in usrDB.getStudentList())
            {
                stdSearchBox.AutoCompleteCustomSource.Add(std.username);
                manStdSearchText.AutoCompleteCustomSource.Add(std.username);
            }
        }
        public admMainpage(userDatabase usrDB, courseDatabase crsDB, string usertype)
        {
            this.usrDB = usrDB;
            this.crsDB = crsDB;
            InitializeComponent();
            if (usertype == "admin")
                manSelect.Visible = false;
        }

        public void createCrsLst()
        {
            if (crsLst.DataSource == null)
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

                DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
                btn.ValueType = typeof(bool);
                crsLst.Columns.Insert(0, btn);
                crsLst.Columns[0].HeaderText = "Add";
                crsLst.Columns[0].Name = "Add";
            }
        }
        public void createManCrsLst()
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

            manCrsLst.DataSource = table;
            manCrsLst.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            manCrsLst.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            int width = manCrsLst.Columns[5].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            manCrsLst.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            manCrsLst.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            manCrsLst.Columns[5].Width = width;

            DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
            btn.ValueType = typeof(bool);
            manCrsLst.Columns.Insert(0, btn);
            manCrsLst.Columns[0].HeaderText = "Select";
            manCrsLst.Columns[0].Name = "Select";
        }
        public void createManStdLst()
        {
            if (manStdLst.DataSource == null)
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
            }
        }
        public void createManFacLst()
        {

        }


        // Create tables for students' interactions
        //--------------------------------------------------------------------
        public void createStdLst()
        {
            if (stdLst.DataSource == null)
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
            }
        } // Create the frame of the table
        public void createStdSch()
        {
            if (stdSch.DataSource == null)
            {
                DataTable table = new DataTable();
                table.Columns.Add("Course ID", typeof(string));
                table.Columns.Add("Title", typeof(string));
                table.Columns.Add("Instructor", typeof(string));
                table.Columns.Add("Credits", typeof(string));
                table.Columns.Add("Seats", typeof(string));
                table.Columns.Add("Schedule", typeof(string));

                stdSch.DataSource = table;

                DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
                stdSch.Columns.Insert(0, btn);
                stdSch.Columns[0].HeaderText = "Drop";
                stdSch.Columns[0].Name = "Drop";
                stdSch.ClearSelection();
            }
        } // Create the frame of the table
        public void createGradeHist()
        {
            if (gradeHist.DataSource == null)
            {
                DataTable table = new DataTable();
                table.Columns.Add("Course ID", typeof(string));
                table.Columns.Add("Semester", typeof(string));
                table.Columns.Add("Credits", typeof(string));
                table.Columns.Add("Grade", typeof(string));

                gradeHist.DataSource = table;
            }
        }// Create the frame of the table



        // Create tables for faculties' interactions
        //----------------------------------------------------------------------
        public void createFacLst()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Username");
            table.Columns.Add("First Name");
            table.Columns.Add("Last Name");
            //table.Columns.Add("Number of Courses teaching");

            foreach (faculty fac in usrDB.getFacultyList())
                table.Rows.Add(fac.username, fac.fname, fac.lname);

            stdLst.DataSource = table;
            stdLst.Columns["Username"].Visible = false;
        }
        public void createFacSch()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Schedule", typeof(string));

            facSch.DataSource = table;
        }   // Create the frame of the table


        // Select the user type
        //-----------------------------------------------------------------
        private void stdSelectClick(object sender, System.EventArgs e)
        {
            // Populate the student list
            createStdLst();
            DataTable table = (DataTable)stdLst.DataSource;
            table.Rows.Clear();
            foreach (student std in usrDB.getStudentList())
                table.Rows.Add(std.username, std.fname, std.lname, std.advisor, std.GPA, std.totalCredits);
            
            createStdSch();
            createGradeHist();

            // Populate the list of courses
            createCrsLst();
            table = (DataTable)crsLst.DataSource;
            table.Rows.Clear();
            foreach (course crs in crsDB.getCourseList())
                table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.seats, crs.getBlocks());
            crsLst.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            crsLst.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            int width = crsLst.Columns[5].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            crsLst.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            crsLst.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            crsLst.Columns[5].Width = width;


            stdSelect.BackColor = Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            facSelect.BackColor = Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            manSelect.BackColor = Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));

            // Display tables for students' interactions
            stdLstContainer.Visible = true;
            crsLstContainer.Visible = true;
            stdActions.Visible = true;
            stdActions.BringToFront();
            stdLst.ClearSelection();
            stdSch.ClearSelection();

            // Hide tables
            manActions.Visible = false;
            manCrsLstContainer.Visible = false;
            manStdLstContainer.Visible = false;
            manFacLstContainer.Visible = false;
            facLstContainer.Visible = false;
        }
        private void facSelectClick(object sender, System.EventArgs e)
        {
            createFacLst();
            createFacSch();

            facSelect.BackColor = Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            stdSelect.BackColor = Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            manSelect.BackColor = Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));


            // Hide everything of students' interactions
            stdLstContainer.Visible = false;
            stdActions.Visible = false;

            facLstContainer.Visible = true;
            //facActions.Visible = true;
            //facActions.BringToFront();
            stdSearch.Visible = true;
            stdSearchBox.Visible = true;
            stdSearchLabel.Visible = true;
            crsLst.Columns["Remove"].Visible = false;

            gradeHist.Visible = false;
        }
        private void manSelectClick(object sender, EventArgs e)
        {
            // Populate the course list for managers
            if (manCrsLst.DataSource == null)
                createManCrsLst();
            DataTable table = (DataTable)manCrsLst.DataSource;
            table.Rows.Clear();
            foreach (course crs in crsDB.getCourseList())
                table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.seats, crs.getBlocks());

            // Populate the student list for managers
            if (manStdLst.DataSource == null)
                createManStdLst();
            table = (DataTable)manStdLst.DataSource;
            table.Rows.Clear();
            foreach (student std in usrDB.getStudentList())
                table.Rows.Add(std.username, std.fname, std.lname, std.advisor, std.GPA, std.totalCredits);


            if (manFacLst.DataSource == null)
                createManFacLst();

            manSelect.BackColor = Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            facSelect.BackColor = Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            stdSelect.BackColor = Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));

            crsLstContainer.Visible = false;
            stdLstContainer.Visible = false;
            stdSchContainer.Visible = false;
            gradeHistContainer.Visible = false;
            stdActions.Visible = false;
            manCrsLstContainer.Visible = true;
            manStdLstContainer.Visible = true;
            manFacLstContainer.Visible = true;
            manActions.Visible = true;
           
        }


        // Student interactions
        //---------------------------------------------------------
        private void crsSearchClick(object sender, EventArgs e)
        {
            string crsID = crsIDBox.Text.Trim();

            if (stdActions.Visible)
                for (int i = 0; i < stdLst.RowCount; i++)
                    if (crsLst.Rows[i].Cells["Course ID"].Value.ToString().Trim() == crsID)
                    {
                        if (addCrsLst.Contains(i))
                        {
                            addCrsLst.Remove(i);
                            for (int l = 0; l < addCrsLst.Count; l++)
                                if (addCrsLst[l] < i)
                                    addCrsLst[l] += 1;
                            addCrsLst.Add(0);
                        }
                        else
                            for (int l = 0; l < addCrsLst.Count; l++)
                                if (addCrsLst[l] < i)
                                    addCrsLst[l] += 1;
                        DataTable table = (DataTable)crsLst.DataSource;
                        DataRow dr = table.Rows[i];
                        DataRow nr = table.NewRow();
                        nr.ItemArray = dr.ItemArray;
                        table.Rows.Remove(dr);
                        table.Rows.InsertAt(nr, 0);
                        break;
                    }
        }
        private void stdConfirmClick(object sender, EventArgs e)
        {
            if (stdLst.SelectedRows.Count == 0)
                MessageBox.Show("Select a student from the list",
                    "No student selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            else
            {
                stdUsername = stdLst.SelectedRows[0].Cells["Username"].Value.ToString();
                student std = usrDB.getStudent(stdUsername);

                // Update the student schedule
                DataTable table = (DataTable)stdSch.DataSource;
                if (table != null)
                    table.Rows.Clear();
                foreach (course crs in std.registeredCrs)
                    table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.seats, crs.getBlocks());

                stdSch.DataSource = table;

                // Update the student's course history
                DataTable t = (DataTable)gradeHist.DataSource;
                if (t != null)
                    t.Rows.Clear();
                foreach (previousCourse pcrs in std.pastCrs)
                    t.Rows.Add(pcrs.crsID, pcrs.semester, pcrs.credit, pcrs.grade);

                gradeHist.DataSource = t;
                crsLstContainer.Visible = true;
                stdLstContainer.Visible = false;
                stdSchContainer.Visible = true;
                gradeHistContainer.Visible = true;
            }
        }
        private void addCrsClick(object sender, EventArgs e)
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
                    // Get the course id
                    DataGridViewRow r = rowList[i];
                    string crsID = r.Cells["Course ID"].Value.ToString().Trim();

                    // Add the course to the student
                    student std = usrDB.getStudent(stdUsername);
                    usrDB.addCrsToStd(crsID, "S15", ref crsDB, std);

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

                    course Crs = crsDB.getCourse(crsID);
                    DataTable table = (DataTable)stdSch.DataSource;
                    table.Rows.Add(Crs.crsID, Crs.title, Crs.instructor, Crs.credit, Crs.seats, Crs.getBlocks());
                }

                for (int i = 0; i < stdSch.Rows.Count; i++)
                    crsLst.Rows[i].Cells["Add"].Value = null;

                dropCrsLst.Clear();
                stdSch.ClearSelection();

                stdSch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                stdSch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                stdSch.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                int width = stdSch.Columns[5].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                stdSch.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                stdSch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                stdSch.Columns[5].Width = width;
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
                List<DataGridViewRow> rowList = new List<DataGridViewRow>();
                foreach (int i in dropCrsLst)
                    rowList.Add(stdSch.Rows[i]);

                for (int i = 0; i < count; i++)
                {
                    // Get the course id
                    DataGridViewRow r = rowList[i];
                    string crsID = r.Cells["Course ID"].Value.ToString().Trim();

                    // Drop the course from the student
                    student std = usrDB.getStudent(stdUsername);
                    usrDB.dropCrsFromStd(crsID, ref crsDB, std);

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
                        if (row.Cells["Course ID"].Value.ToString().Trim() == stdSch.Rows[l].Cells["Course ID"].Value.ToString().Trim())
                        {
                            stdSch.Rows.RemoveAt(l);
                            break;
                        }

                for (int i = 0; i < stdSch.Rows.Count; i++)
                    stdSch.Rows[i].Cells["Drop"].Value = null;

                dropCrsLst.Clear();
                stdSch.ClearSelection();

                stdSch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                stdSch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                stdSch.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                int width = stdSch.Columns[5].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                stdSch.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                stdSch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                stdSch.Columns[5].Width = width;
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
        private void crsLstCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex == -1)
                return;
            if (Convert.ToBoolean(crsLst.Rows[rowIndex].Cells["Add"].Value) == true && !addCrsLst.Contains(rowIndex))
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
        private void stdLstCurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (stdLst.IsCurrentCellDirty)
            {
                stdLst.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
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
                    stdLst.Rows[i].Cells[0].Value = false;
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
            string username = stdSearchBox.Text.ToLower().Trim();

            if (stdActions.Visible)
                for (int i = 0; i < stdLst.RowCount; i++)
                    if (stdLst.Rows[i].Cells["Username"].Value.ToString().Trim().ToLower() == username)
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
            crsLstContainer.Visible = true;
            ScrollControlIntoView(crsLst);
        }



        // Faculty interactions
        //----------------------------------------------------------------------
        private void facSelected(object sender, DataGridViewCellEventArgs e)
        {
            if (stdLst.SelectedRows.Count == 1)
            {
                string username = stdLst.SelectedRows[0].Cells["Username"].Value.ToString().Trim();

                // Get the list of courses the faculty is scheduled to teach
                List<course> crsLst = new List<course>();
                foreach (course crs in crsDB.getCourseList())
                    if (crs.instructor.Trim() == username)
                        crsLst.Add(crs);

                // Update the faculty schedule table
                DataTable table = (DataTable)facSch.DataSource;
                table.Rows.Clear();
                foreach (course crs in crsLst)
                    table.Rows.Add(crs.crsID, crs.title, crs.getBlocks());
            }
        }
        private void showEnrolledStdClick(object sender, EventArgs e)
        {
            if (facSch.SelectedRows.Count == 1)
            {
                string crsID = facSch.SelectedRows[0].Cells["Course ID"].Value.ToString();
                course crs = crsDB.getCourse(crsID);
                new admEnrolledStd(crs).Show();
            }
            else
                MessageBox.Show("Select a class from the schedule list",
                    "No class selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
        private void showAdviseesClick(object sender, EventArgs e)
        {
            if (stdLst.SelectedRows.Count == 1)
            {
                string username = stdLst.SelectedRows[0].Cells["Username"].Value.ToString();
                faculty fac = usrDB.getFaculty(username);
                new admAdvisees(fac, usrDB).Show();
            }
            else
                MessageBox.Show("Select a faculty from the faculties list",
                    "No faculty selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
        private void checkAdviseeScheduleClick(object sender, EventArgs e)
        {
            if (stdLst.SelectedRows.Count == 1)
            {
                string username = stdLst.SelectedRows[0].Cells["Username"].Value.ToString();
                faculty fac = usrDB.getFaculty(username);
                new admAdvisees(fac, usrDB);
            }
            else
                MessageBox.Show("Select a faculty from the faculties list",
                    "No faculty selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }


        // Manager interactions
        //----------------------------------------------------------------------
        private void removeFacClick(object sender, EventArgs e)
        {
            if (stdLst.SelectedRows.Count == 1)
            {
                string username = stdLst.SelectedRows[0].Cells["Username"].Visible.ToString();
                usrDB.removeStd(username, ref crsDB, "filepath");
            }
            else
                MessageBox.Show("Select a faculty from the faculties list",
                    "No faculty selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
                    std.setAdvisor(newAdvisor);

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
        private void createUserClick(object sender, EventArgs e)
        {
            var form = new admCreateUser(usrDB);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                usrDB.addUser(form.uname, form.pword, form.fName, form.mName, form.lName, form.uType, @"..\..\userDB.in");
                if (form.uType.ToLower().Trim() == "student")
                {
                    List<student> tempLst = usrDB.getStudentList();
                    int length = tempLst.Count;
                    student newStd = tempLst[length - 1];

                    // Update the student list table
                    DataTable table = (DataTable)manStdLst.DataSource;
                    table.Rows.Add(newStd.username, newStd.fname, newStd.lname, newStd.advisor, newStd.GPA, newStd.totalCredits);
                }
            }
            else
                MessageBox.Show("No users have been added.",
                        "No change made",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
        }
        private void createCrsClick(object sender, EventArgs e)
        {
            var form = new admCreateCrs(crsDB, usrDB);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
                crsDB.addCrs(form.crs, @"..\..\courseDB.in");
            else
                MessageBox.Show("No courses have been added.",
                        "No change made",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
        }
        private void changeCrsClick(object sender, EventArgs e)
        {

        }
        private void manCrsSearchClick(object sender, EventArgs e)
        {
            string crsID = manCrsIDBox.Text.Trim();

            if (manActions.Visible)
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


        // Confirmed
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
                message += "    " + uname + "\n";
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
                            usrDB.removeStd(uname, ref crsDB, @"..\..\userDB.in");
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

                manSelectedStdLst.Clear();
                manStdLst.ClearSelection();

                MessageBox.Show("Removal succesfully executed.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
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
                    message += "    " + crsID + "\n";
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



        // Utilities 
        private void stdScrollToTopClick(object sender, EventArgs e)
        {
            ScrollControlIntoView(header);
        }





        // Don't change these
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
        private void logoutClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}