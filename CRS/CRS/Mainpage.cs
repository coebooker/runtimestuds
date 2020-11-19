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
        Point p;

        public mainpage(string usertype, string username, userDatabase usrDB, string cpath, string ppath)
        {
            InitializeComponent();
            this.username = username;
            crsDB = new courseDatabase(cpath, ref depBox, ref titleBox);
            usrDB.addPrevCourses(ppath, ref this.crsDB, nextSemester);
            this.usrDB = usrDB;

            createCrsLst();
            p = crsLst.Location;

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
        public mainpage(string usertype, string username, userDatabase usrDB, courseDatabase crsDB)
        {
            InitializeComponent();
            this.username = username;
            this.usrDB = usrDB;
            this.crsDB = crsDB;

            createCrsLst();
            p = crsLst.Location;

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
            table.Columns.Add("Course", typeof(string));
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
            crsLst.Columns.Insert(0, btn);
            crsLst.Columns[0].HeaderText = "Add";
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
            List<previousCourse> crsHist = std.crsHist;

            foreach (previousCourse pcrs in crsHist)
                table.Rows.Add(pcrs.crsID, pcrs.semester, pcrs.credit, pcrs.grade);

            crs_hist_table.DataSource = table;
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
                stdDropCrs.Visible = true;
                crsHist.Visible = true;
            }
            else if (userType == "faculty")
            {
                viewFacSch.Visible = true;
            }
        }


        // Event handlers
        private void LogoutClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void crsHistClick(object sender, EventArgs e)
        {
            createCrsHist();
            credits.Text = "Total Credits: " + usrDB.getStudent(username).totalCredits.ToString();
            credits.Visible = true;
            gpa.Text = "GPA: " + usrDB.getStudent(username).calculateGPA().ToString();
            gpa.Visible = true;
            if (crs_hist_table.Visible == false)
                crs_hist_table.Visible = true;
            else
            {
                crs_hist_table.Visible = false;
                credits.Visible = false; gpa.Visible = false;
            }
                
        }

        private void delCrsClickStd(object sender, EventArgs e)
        {
            credits.Visible = false;
            gpa.Visible = false;
            if (crs_hist_table.Visible == true)
                crs_hist_table.Visible = false;

            if (stdSch.Visible == false)
            {
                student currentStd = usrDB.getStudent(username);
                List<course> stdCrsLst = currentStd.registeredCrs;
                createStdSch(stdCrsLst);
                stdSch.Visible = true;
            }

            if (stdSch.SelectedRows.Count == 1)
            {
                student curStd = usrDB.getStudent(username);
                usrDB.dropCrsFromStd(stdSch.SelectedRows[0].Cells["Course ID"].FormattedValue.ToString().Trim(), currentSemester, ref crsDB,curStd);
                DataGridViewRow row = crsLst.SelectedRows[0];
                course crs = crsDB.getCourse(row.Cells["Course"].Value.ToString());
                row.Cells["Seats"].Value = crs.seats + " / " + crs.maxSeats;
                //createCrsLstTable();
                createCrsHist();
                List<course> studentCrsLst = curStd.registeredCrs;
                createStdSch(studentCrsLst);
            }
    }
        private void viewFacSchClick(object sender, EventArgs e)
        {
            if (facSchTable.Visible == false)
                facSchTable.Visible = true;
            else
                facSchTable.Visible = false;
        }

        private void dropDownValueChanged(object sender, EventArgs e)
        {
            string course = facDropDown.SelectedItem.ToString();
            if (course == "")
                enrolledStdTable.Visible = false;
            createEnrolledStdTable(enrolledStdTable, course);
            enrolledStdTable.Visible = true;
        }

        private void crsLstCellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = crsLst.CurrentCell.RowIndex;
            for (int i = 0; i < crsLst.Rows.Count; i++)
                if (i != rowIndex)
                    crsLst.Rows[i].Cells[0].Value = false;
            crsLst.ClearSelection();
            crsLst.Rows[rowIndex].Selected = true;
        }
        private void crsSearchClick(object sender, EventArgs e)
        {
            string dep = depBox.Text;
            string title = titleBox.Text;
            bool empty = yesButton.Checked;
        }
        private void stdAddCrsClick(object sender, EventArgs e)
        {
            if (crsLst.SelectedRows.Count == 1)
            {
                validityResult = usrDB.getStudent(username).isValidAdd(currentSemester, crsDB.getCourse(crsLst.SelectedRows[0].Cells["Course"].FormattedValue.ToString()));
                if (validityResult.valid)
                {
                    if (validityResult.warning)
                    {
                        //Pop up warning message
                        MessageBox.Show(validityResult.message,
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                        if (crsLst.Visible == false)
                        {
                            crsLst.Visible = true;
                        }
                    }

                    // THINGS TO DO

                    // Actually add course to student account DONE

                    // -> Add it to RegisteredCourse List under the student class DONE

                    // -> Add it to course history with X as status under the student class DONE

                    // Decrement number of seats for the class DONE

                    // All the above should be done with pass by reference to mitigate data-overwrite every course addition/deletion

                    // For Admin account, probably pass by reference the student instance into AdminStudentSelect form DONE
                    student currentStd = usrDB.getStudent(username);
                    usrDB.addCrsToStd(crsLst.SelectedRows[0].Cells["Course"].FormattedValue.ToString().Trim(), currentSemester, ref crsDB, currentStd);

                    new addedCourse(crsLst.SelectedRows[0].Cells["Course"].FormattedValue.ToString()).Show();
                    DataGridViewRow row = crsLst.SelectedRows[0];
                    course crs = crsDB.getCourse(row.Cells["Course"].Value.ToString());
                    row.Cells["Seats"].Value = crs.seats + " / " + crs.maxSeats;
                    //createCrsLstTable(crsLstTable);
                    createCrsHist();
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
            else
            {
                MessageBox.Show("Select a class",
                    "No Class",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                if (crsLst.Visible == false)
                {
                    if (stdSch.Visible == true)
                        stdSch.Visible = false;
                    crsLst.Visible = true;
                }
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

            crsLst.Location = p;
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

            crsLst.Location = new Point(16, 77);
        }

        private void mainpageClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
    }
}
