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
        private userDatabase usrDB;
        private courseDatabase crsDB;
        //private List<course> crsLst;
        private string username;
        string upath;
        string cpath;
        string ppath;
        string nextSemester = "S15";
        validity validityResult;

        public mainpage(string usertype, string username, userDatabase usrDB, string upath, string cpath, string ppath)
        {
            this.upath = upath;
            this.cpath = cpath;
            this.ppath = ppath;
            this.username = username;
            crsDB = new courseDatabase(cpath);
            usrDB.addPrevCourses(ppath, ref crsDB);
            this.usrDB = usrDB;

            InitializeComponent();

            createCrsLstTable(crsLstTable);

            dataGridView1.Visible = false;
            dataGridView1.ColumnHeadersVisible = false;
            crntSmstLabel.Visible = false;
            facCrsDropDown.Visible = false;
            conflictCheck.Visible = false;
            adviseesConflictCheck.Visible = false;

            if (usertype == "student")
            {
                createCrsHistTable(crsHistTable);
                conflictCheck.Visible = true;
            }
            else if (usertype == "faculty")
            {
                createFacSchTable(facSchTable, "Spring 2015");
                createFacDropDown(facCrsDropDown);
                createAdviseesTable(adviseesTable);
                adviseesTable.Visible = true;
                facCrsDropDown.Visible = true;
                adviseesConflictCheck.Visible = true;
                adviseesTableLabel.Visible = true;
                enrolledStdsLabel.Visible = true;
            }
            alignButtons(usertype, 53);
        }

        private void createCrsLstTable(DataGridView dataGridView)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Faculty", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Seats", typeof(string));
            table.Columns.Add("Schedule", typeof(string));

            foreach (course crs in crsDB.getCourseList())
                table.Rows.Add(crs.getCode(), crs.getTitle(), crs.getInstructor(), crs.getCredit(), crs.getSeats() + " / " + crs.getMaxSeats(), crs.getBlocks());

            dataGridView.DataSource = table;
        }
        private void createCrsHistTable(DataGridView dgv)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course Name", typeof(string));
            table.Columns.Add("Semester", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Grade", typeof(string));

            student std = usrDB.getStudent(username);
            List<previousCourse> crsHist = std.getCrsHist();

            foreach (previousCourse pcrs in crsHist)
            {
                table.Rows.Add(pcrs.coursename, pcrs.semester, pcrs.credit, pcrs.grade);
            }

            crsHistTable.DataSource = table;
        }
        private void createCrntSchTable(DataGridView dgv, List<previousCourse> crsLst)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));

            foreach (previousCourse crs in crsLst)
                table.Rows.Add(crs.coursename);
            dataGridView1.DataSource = table;
            dataGridView1.EnableHeadersVisualStyles = false;
        }
        private void createEnrolledStdTable(DataGridView dgv, string course)
        {
            List<course> crsLst = crsDB.getNextFacCrsLst(username);
            course crs = crsLst.Find(s => s.getCode().ToLower() == course.ToLower());
            DataTable table = new DataTable();
            table.Columns.Add("First Name");
            table.Columns.Add("Middle Name");
            table.Columns.Add("Last Name");

            List<student> stdLst = crs.getStudents();
            foreach (student std in stdLst)
                table.Rows.Add(std.getFName(), std.getMName(), std.getLName());

            dgv.DataSource = table;
        }
        private void createFacSchTable(DataGridView dgv, string semester)
        {
            DataTable table = new DataTable();

            table.Columns.Add("Course", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Schedule", typeof(string));
            table.Columns.Add("Location", typeof(string));
            if (semester == "Spring 2015")
                foreach (course crs in crsDB.getNextFacCrsLst(username))
                    table.Rows.Add(crs.getCode(), crs.getTitle(), crs.getBlocks(), "TBA");
            else if (semester == "Fall 2014")
                ;
            dgv.DataSource = table;
        }
        private void createFacDropDown(ComboBox dd)
        {
            List<course> crsLst = crsDB.getNextFacCrsLst(username);
            foreach (course crs in crsLst)
                dd.Items.Add(crs.getCode());
        }
        private void createAdviseesTable(DataGridView dgv)
        {
            faculty fac = usrDB.getFaculty(username);
            List<student> adviseesLst = fac.getAdviseesLst();

            DataTable table = new DataTable();
            table.Columns.Add("Username");
            table.Columns.Add("First Name");
            table.Columns.Add("Last Name");
            table.Columns.Add("Total Credits");
            table.Columns.Add("GPA");

            foreach (student std in adviseesLst)
                table.Rows.Add(std.getUName(), std.getFName(), std.getLName(), std.getCredits(), std.getGPA());

            adviseesTable.DataSource = table;
            adviseesTable.Columns["Username"].Visible = false;
        }
        private void createStdSchTable(DataGridView dgv, List<course> crsLst)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Course Name", typeof(string));
            table.Columns.Add("Instructor", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Class times", typeof(string));

            foreach (course crs in crsLst)
            {
                table.Rows.Add(crs.getCode(), crs.getTitle(), crs.getInstructor(), crs.getCredit(), crs.getBlocks());
            }

            stdSchTable.DataSource = table;
            stdSchTable.EnableHeadersVisualStyles = false;
        }
        private void alignButtons(string userType, int addition)
        {
            Point start = viewCrsLst.Location;
            Point sec_btn = Point.Add(start, new Size(0, addition));
            Point trd_btn = Point.Add(sec_btn, new Size(0, addition));
            Point fth_btn = Point.Add(trd_btn, new Size(0, addition));
            Point fft_btn = Point.Add(fth_btn, new Size(0, addition));
            Point six_btn = Point.Add(fft_btn, new Size(0, addition));

            if (userType == "student")
            {
                addCrsStd.Visible = true;
                addCrsStd.Location = sec_btn;
                del_crs_std.Visible = true;
                del_crs_std.Location = trd_btn;
                crsHist.Visible = true;
                crsHist.Location = fth_btn;
                viewStdSch.Visible = true;
                viewStdSch.Location = fft_btn;
                conflictCheck.Visible = true;
                conflictCheck.Location = six_btn;
            }
            else if (userType == "faculty")
            {
                viewFacSch.Visible = true;
                viewFacSch.Location = sec_btn;
                adviseesConflictCheck.Visible = true;
                adviseesConflictCheck.Location = trd_btn;
            }
            else if (userType == "admin")
            {
                addCrsAdm.Visible = true;
                addCrsAdm.Location = sec_btn;
                view_sch_admin.Visible = true;
                view_sch_admin.Location = trd_btn;
            }
        }


        // Event handlers
        private void addCrsClickAdm(object sender, EventArgs e)
        {
            if (crsLstTable.SelectedRows.Count == 1)
            {
                new AdminStudentSelect(crsLstTable.SelectedRows[0].Cells["Course ID"].FormattedValue.ToString(), ref usrDB, ref crsDB, nextSemester).Show();
            }
            else
            {
                MessageBox.Show("Select a class",
                    "No Class",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                if (crsLstTable.Visible == false)
                {
                    crsLstTable.Visible = true;
                }
            }
            createCrsLstTable(crsLstTable);
            createCrsHistTable(crsHistTable);
        }
        private void addCrsClickStd(object sender, EventArgs e)
        {
            credits.Visible = false;
            gpa.Visible = false;
            if (crsLstTable.SelectedRows.Count == 1)
            {
                validityResult = usrDB.getStudent(username).isValidAdd(nextSemester, crsDB.getCourse(crsLstTable.SelectedRows[0].Cells["Course"].FormattedValue.ToString()));
                if (validityResult.valid)
                {
                    if (validityResult.warning)
                    {
                        //Pop up warning message
                        MessageBox.Show(validityResult.message,
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                        if (crsLstTable.Visible == false)
                        {
                            crsLstTable.Visible = true;
                        }
                    }


                    student currentStd = usrDB.getStudent(username);
                    usrDB.addCourseToStudent(username, crsLstTable.SelectedRows[0].Cells["Course"].FormattedValue.ToString().Trim(), nextSemester, ref crsDB, currentStd);

                    new addedCourse(crsLstTable.SelectedRows[0].Cells["Course"].FormattedValue.ToString()).Show();
                    DataGridViewRow row = crsLstTable.SelectedRows[0];
                    course crs = crsDB.getCourse(row.Cells["Course"].Value.ToString());
                    row.Cells["Seats"].Value = crs.getSeats() + " / " + crs.getMaxSeats();
                    //createCrsLstTable(crsLstTable);
                    createCrsHistTable(crsHistTable);
                }
                else
                {
                    // Display that it's a invalid add
                    MessageBox.Show(validityResult.message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    if (crsLstTable.Visible == false)
                    {
                        crsLstTable.Visible = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a class",
                    "No Class",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                if (crsLstTable.Visible == false)
                {
                    if (stdSchTable.Visible == true)
                    {
                        stdSchTable.Visible = false;
                        crntSmstLabel.Visible = false;
                        crsLstLabel.Visible = false;
                    }

                    crsLstTable.Visible = true;
                }
            }
        }
        private void advSchButtonClick(object sender, EventArgs e)
        {
            if (adviseesTable.SelectedRows.Count == 1)
                new adviseeSch(usrDB.getStudent(adviseesTable.SelectedRows[0].Cells["Username"].FormattedValue.ToString())).Show();
            else
                MessageBox.Show("Select an advisee",
                    "No selected advisee",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
        private void crsHistClick(object sender, EventArgs e)
        {
            createCrsHistTable(crsHistTable);
            if (crsLstTable.Visible == true)
                crsLstTable.Visible = false;
            credits.Text = "Total Credits: " + usrDB.getStudent(username).getCredits().ToString();
            credits.Visible = true;
            gpa.Text = "GPA: " + usrDB.getStudent(username).getGPA().ToString();
            gpa.Visible = true;
            if (stdSchTable.Visible == true)
            {
                stdSchTable.Visible = false;
                crntSmstLabel.Visible = false;
                crsLstLabel.Visible = false;
            }

            if (crsHistTable.Visible == false)
                crsHistTable.Visible = true;
            else
            {
                crsHistTable.Visible = false;
                credits.Visible = false; gpa.Visible = false;
            }

        }
        private void LogoutClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ViewCourseListClick(object sender, EventArgs e)
        {
            credits.Visible = false;
            gpa.Visible = false;
            if (crsHistTable.Visible == true)
                crsHistTable.Visible = false;
            if (stdSchTable.Visible == true)
            {
                stdSchTable.Visible = false;
                dataGridView1.Visible = false;
                crntSmstLabel.Visible = false;
                crsLstLabel.Visible = false;
            }
                
            if (crsLstTable.Visible == false)
                crsLstTable.Visible = true;
            else
                crsLstTable.Visible = false;
        }
        private void view_sch_std_click(object sender, EventArgs e)
        {
            credits.Visible = false;
            gpa.Visible = false;
            student currentStd = usrDB.getStudent(username);
            List<course> stdCrsLst = currentStd.getRegisteredCrs();
            createStdSchTable(stdSchTable, stdCrsLst);
            createCrntSchTable(dataGridView1, currentStd.GetCurrentTermList());

            if (crsLstTable.Visible == true)
            {
                crsLstTable.Visible = false;
            }

            if (crsHistTable.Visible == true)
                crsHistTable.Visible = false;

            if (stdSchTable.Visible == false)
            {
                crntSmstLabel.Visible = true;
                crsLstLabel.Visible = true;
                stdSchTable.Visible = true;
                dataGridView1.Visible = true;
            }
      
            else
            {
                crntSmstLabel.Visible = false;
                crsLstLabel.Visible = false;
                stdSchTable.Visible = false;
                dataGridView1.Visible = false;
            }
                
        }

        private void ViewScheduleAdminClick(object sender, EventArgs e)
        {
            new AdminFacultyList(usrDB, crsDB).Show();
        }

        private void delCrsClickStd(object sender, EventArgs e)
        {
            credits.Visible = false;
            gpa.Visible = false;
            if (crsHistTable.Visible == true)
                crsHistTable.Visible = false;
            if (crsLstTable.Visible == true)
                crsLstTable.Visible = false;

            if (stdSchTable.Visible == false)
            {
                student currentStd = usrDB.getStudent(username);
                List<course> stdCrsLst = currentStd.getRegisteredCrs();
                createStdSchTable(stdSchTable, stdCrsLst);
                createCrntSchTable(dataGridView1, currentStd.GetCurrentTermList());
                stdSchTable.Visible = true;
                dataGridView1.Visible = true;
                crntSmstLabel.Visible = true;
                crsLstLabel.Visible = true;
            }

            if (stdSchTable.SelectedRows.Count == 1)
            {
                student curStd = usrDB.getStudent(username);
                usrDB.deleteCourseFromStudent(username, stdSchTable.SelectedRows[0].Cells["Course ID"].FormattedValue.ToString().Trim(), nextSemester, ref crsDB,curStd);
                DataGridViewRow row = crsLstTable.SelectedRows[0];
                course crs = crsDB.getCourse(row.Cells["Course"].Value.ToString());
                row.Cells["Seats"].Value = crs.getSeats() + " / " + crs.getMaxSeats();
                //createCrsLstTable();
                createCrsHistTable(crsHistTable);
                List<course> studentCrsLst = curStd.getRegisteredCrs();
                createStdSchTable(stdSchTable, studentCrsLst);
            }
    }

        private void viewFacSchClick(object sender, EventArgs e)
        {
            if (facSchTable.Visible == false)
                facSchTable.Visible = true;
            else
                facSchTable.Visible = false;
        }
        private void facCrsDropDownTextChanged(object sender, EventArgs e)
        {
            string course = facCrsDropDown.SelectedItem.ToString();
            createEnrolledStdTable(enrolledStdTable, course);
            enrolledStdTable.Visible = true;
        }
        private void facSchSmstSelectValueChanged(object sender, EventArgs e)
        {
            if (facSchTable.VirtualMode == false)
                facSchTable.Visible = true;
            string smst = facSchSmstSelect.SelectedItem.ToString();
            createFacSchTable(facSchTable, smst);
        }
        private void conflictCheckButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(usrDB.getStudent(username).timeCheck(),
                    "Time Check",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
    }
}
