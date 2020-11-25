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
    public partial class stdMainpage : Form
    {
        public userDatabase usrDB;
        public courseDatabase crsDB;
        student std;
        List<string> addCrsLst = new List<string>();
        List<string> dropCrsLst = new List<string>();

        public stdMainpage(string username, userDatabase usrDB)
        {
            // Store attributes
            InitializeComponent();
            crsDB = new courseDatabase(ref usrDB);
            crsDB.getPreReqs(@"..\..\preReq.in");
            this.usrDB = usrDB;
            this.usrDB.addPrevCourses(ref this.crsDB, "S15");
            std = usrDB.getStudent(username);


            // Change texts
            welcome.Text += std.fname + " " + std.lname;
            gpa.Text += " " + std.GPA;
            credits.Text += " " + std.totalCredits;

            // Create all the tables
            createCrsLst();
            createGradeHist();
            createStdSch();

            // Clear selections on tables
            gradeHist.ClearSelection();
            stdSch.ClearSelection();

            foreach (course crs in crsDB.getCourseList())
                crsIDBox.AutoCompleteCustomSource.Add(crs.crsID);
        }
        public stdMainpage(string username, userDatabase usrDB, courseDatabase crsDB)
        {
            // Store attributes
            InitializeComponent();
            this.crsDB = crsDB;
            this.usrDB = usrDB;
            std = usrDB.getStudent(username);

            // Change texts
            welcome.Text += std.fname + " " + std.lname;
            gpa.Text += " " + std.GPA;
            credits.Text += " " + std.totalCredits;

            // Create all the tables
            createCrsLst();
            createGradeHist();
            createStdSch();

            // Clear selections on tables
            gradeHist.ClearSelection();
            stdSch.ClearSelection();

            // Auto completion source
            foreach (course crs in crsDB.getCourseList())
                crsIDBox.AutoCompleteCustomSource.Add(crs.crsID);
        }


        // Functions for all the tables
        private void createCrsLst()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Instructor", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Seats", typeof(string));
            table.Columns.Add("Schedule", typeof(string));

            foreach (course crs in crsDB.getCourseList())
                table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.seats + " / " + crs.maxSeats, crs.getBlocks());

            crsLst.DataSource = table;
            crsLst.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            crsLst.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            int width = crsLst.Columns["Schedule"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            crsLst.Columns["Schedule"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            crsLst.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            crsLst.Columns["Schedule"].Width = width;

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
        private void createGradeHist()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Semester", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Grade", typeof(string));

            gradeHist.DataSource = table;
            foreach (previousCourse pcrs in std.pastCrs)
                table.Rows.Add(pcrs.crsID, pcrs.semester, pcrs.credit, pcrs.grade);
        }
        private void createStdSch()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Instructor", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Schedule", typeof(string));

            foreach (course crs in std.registeredCrs)
                table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.getBlocks());

            stdSch.DataSource = table;
            stdSch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            stdSch.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            int width = stdSch.Columns["Schedule"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            stdSch.Columns["Schedule"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            stdSch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            stdSch.Columns["Schedule"].Width = width;

            DataGridViewCheckBoxColumn btn = new DataGridViewCheckBoxColumn();
            stdSch.Columns.Insert(0, btn);
            stdSch.Columns[0].HeaderText = "Drop";
            stdSch.Columns[0].Name = "Drop";
            stdSch.ClearSelection();
        }



        // Event handlers
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
                    Dictionary<string, float> gradeDict = new Dictionary<string, float>()
                        {
                            {"A",4.0f},
                            {"A-",3.7f},
                            {"B+",3.3f},
                            {"B",3.0f},
                            {"B-",2.7f},
                            {"C+",2.3f},
                            {"C",2.0f},
                            {"C-",1.7f},
                            {"D+",1.3f},
                            {"D",1.0f},
                            {"D-",0.7f}
                        };
                    course crs = crsDB.getCourse(crsID);
                    bool preReq = true;
                    List<string> preReqLst = crs.preReqLst;
                    foreach (string courseID in preReqLst)
                    {
                        bool temp = false;
                        foreach (previousCourse pcrs in std.pastCrs)
                            if (courseID == pcrs.crsID.Substring(0, courseID.Length) && gradeDict.ContainsKey(pcrs.grade))
                            {
                                temp = true;
                                break;
                            }
                        if (!temp)
                        {
                            foreach (previousCourse pcrs in std.currentCrs)
                                if (courseID == pcrs.crsID.Substring(0, courseID.Length))
                                {
                                    temp = true;
                                    break;
                                }
                            if (!temp)
                            {
                                preReq = false;
                                break;
                            }
                        }
                    }
                    if (!preReq)
                    {
                        MessageBox.Show("You're missing prerequisites.", "Requirement", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }    
                    validity v = std.isValidAdd(crs);
                    if (v.valid)
                    {
                        if (v.warning)
                            MessageBox.Show(crsID + "\n" + v.message, "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Add the course to the student
                        usrDB.addCrsToStd(crsID, "S15", ref crsDB, std);

                        // Update the course list and student schedule
                        foreach (DataGridViewRow row in crsLst.Rows)
                            if (row.Cells["Course ID"].Value.ToString().ToString() == crsID)
                                if (row.Visible)
                                {
                                    crs = crsDB.getCourse(crsID);
                                    row.Cells["Seats"].Value = crs.seats + " / " + crs.maxSeats;
                                    DataTable table = (DataTable)stdSch.DataSource;
                                    table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.getBlocks());
                                    break;
                                }
                    }
                    else
                    {
                        MessageBox.Show(crsID + "\n" + v.message + "\n" + "The course was not added.", "Invalid add",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
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
                    usrDB.dropCrsFromStd(crsID, ref crsDB, std);

                    // Update the course list
                    foreach (DataGridViewRow row in crsLst.Rows)
                        if (row.Cells["Course ID"].Value.ToString().Trim() == crsID)
                            if (row.Visible)
                            {
                                course crs = crsDB.getCourse(crsID);
                                row.Cells["Seats"].Value = crs.seats + " / " + crs.maxSeats;
                                break;
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

        private void showGradeHistClick(object sender, EventArgs e)
        {
            ScrollControlIntoView(gradeHist);
        }
        private void showDropCrsClick(object sender, System.EventArgs e)
        {
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
            MessageBox.Show(std.timeCheck(),
                    "Time Check",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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

        private void scrollToTopClick(object sender, EventArgs e)
        {
            this.ScrollControlIntoView(logout);
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
        private void LogoutClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void curSchClick(object sender, EventArgs e)
        {
            string message = "You are taking the following courses :\n";
            foreach (previousCourse pcrs in std.currentCrs)
                message += "    " + pcrs.crsID + "   " + pcrs.credit + " credits" + "\n";
            MessageBox.Show(message, "Current Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
