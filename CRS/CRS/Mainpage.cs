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
        private string username;
        string currentSemester = "F14";
        string nextSemester = "S15";
        validity validityResult;

        public mainpage(string usertype, string username, userDatabase usrDB, string upath, string cpath, string ppath)
        {
            this.username = username;
            crsDB = new courseDatabase(cpath);
            usrDB.addPrevCourses(ppath, ref this.crsDB, nextSemester);
            this.usrDB = usrDB;
            InitializeComponent();

            createCrsLstTable(crsLstTable);

            if (usertype == "student")
                createCrsHistTable(crs_hist_table);
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
                table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.seats + " / " + crs.maxSeats, crs.getBlocks());

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
            List<previousCourse> crsHist = std.crsHist;

            foreach (previousCourse pcrs in crsHist)
            {
                table.Rows.Add(pcrs.crsID, pcrs.semester, pcrs.credit, pcrs.grade);
            }

            crs_hist_table.DataSource = table;
        }
        private void createStdSchTable(DataGridView dgv, List<course> crsLst)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Course Name", typeof(string));
            table.Columns.Add("Instructor", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Total Seats", typeof(string));
            table.Columns.Add("Class times", typeof(string));

            foreach (course crs in crsLst)
            {
                table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.seats, crs.getBlocks());
            }

            stdSchTable.DataSource = table;
            stdSchTable.EnableHeadersVisualStyles = false;
        }
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
            Point start = view_crs_lst.Location;
            Point sec_btn = Point.Add(start, new Size(0, addition));
            Point trd_btn = Point.Add(sec_btn, new Size(0, addition));
            Point fth_btn = Point.Add(trd_btn, new Size(0, addition));
            Point fft_btn = Point.Add(fth_btn, new Size(0, addition));

            if (userType == "student")
            {
                add_crs_std.Visible = true;
                add_crs_std.Location = sec_btn;
                del_crs_std.Visible = true;
                del_crs_std.Location = trd_btn;
                crs_hist.Visible = true;
                crs_hist.Location = fth_btn;
                view_sch_std.Visible = true;
                view_sch_std.Location = fft_btn;
            }
            else if (userType == "faculty")
            {
                viewFacSch.Visible = true;
                viewFacSch.Location = sec_btn;
            }
            else if (userType == "admin")
            {
                view_sch_admin.Visible = true;
                view_sch_admin.Location = trd_btn;
            }
        }


        // Event handlers
        private void LogoutClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ViewCourseListClick(object sender, EventArgs e)
        {
            credits.Visible = false;
            gpa.Visible = false;
            if (crs_hist_table.Visible == true)
                crs_hist_table.Visible = false;
            if (stdSchTable.Visible == true)
                stdSchTable.Visible = false;
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
            List<course> stdCrsLst = currentStd.registeredCrs;
            createStdSchTable(stdSchTable, stdCrsLst);

            if (crsLstTable.Visible == true)
            {
                crsLstTable.Visible = false;
            }

            if (crs_hist_table.Visible == true)
                crs_hist_table.Visible = false;

            if (stdSchTable.Visible == false)
                stdSchTable.Visible = true;
            else
                stdSchTable.Visible = false;
        }
        private void crs_hist_click(object sender, EventArgs e)
        {
            createCrsHistTable(crs_hist_table);
            if (crsLstTable.Visible == true)
                crsLstTable.Visible = false;
            credits.Text = "Total Credits: " + usrDB.getStudent(username).totalCredits.ToString();
            credits.Visible = true;
            gpa.Text = "GPA: " + usrDB.getStudent(username).calculateGPA().ToString();
            gpa.Visible = true;
            if (stdSchTable.Visible == true)
                stdSchTable.Visible = false;
            if (crs_hist_table.Visible == false)
                crs_hist_table.Visible = true;
            else
            {
                crs_hist_table.Visible = false;
                credits.Visible = false; gpa.Visible = false;
            }
                
        }

        private void addCrsClickStd(object sender, EventArgs e)
        {
            credits.Visible = false;
            gpa.Visible = false;
            if (crsLstTable.SelectedRows.Count == 1)
            {
                validityResult = usrDB.getStudent(username).isValidAdd(currentSemester, crsDB.getCourse(crsLstTable.SelectedRows[0].Cells["Course"].FormattedValue.ToString()));
                if (validityResult.valid)
                {
                    if(validityResult.warning)
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

                    // THINGS TO DO

                    // Actually add course to student account DONE

                    // -> Add it to RegisteredCourse List under the student class DONE

                    // -> Add it to course history with X as status under the student class DONE

                    // Decrement number of seats for the class DONE

                    // All the above should be done with pass by reference to mitigate data-overwrite every course addition/deletion

                    // For Admin account, probably pass by reference the student instance into AdminStudentSelect form DONE
                    student currentStd = usrDB.getStudent(username);
                    usrDB.addCrsToStd(crsLstTable.SelectedRows[0].Cells["Course"].FormattedValue.ToString().Trim(), currentSemester, ref crsDB, currentStd);

                    new addedCourse(crsLstTable.SelectedRows[0].Cells["Course"].FormattedValue.ToString()).Show();
                    DataGridViewRow row = crsLstTable.SelectedRows[0];
                    course crs = crsDB.getCourse(row.Cells["Course"].Value.ToString());
                    row.Cells["Seats"].Value = crs.seats + " / " + crs.maxSeats;
                    //createCrsLstTable(crsLstTable);
                    createCrsHistTable(crs_hist_table);}
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
                        stdSchTable.Visible = false;
                    crsLstTable.Visible = true;
                }
            }
        }

        private void delCrsClickStd(object sender, EventArgs e)
        {
            credits.Visible = false;
            gpa.Visible = false;
            if (crs_hist_table.Visible == true)
                crs_hist_table.Visible = false;
            if (crsLstTable.Visible == true)
                crsLstTable.Visible = false;

            if (stdSchTable.Visible == false)
            {
                student currentStd = usrDB.getStudent(username);
                List<course> stdCrsLst = currentStd.registeredCrs;
                createStdSchTable(stdSchTable, stdCrsLst);
                stdSchTable.Visible = true;
            }

            if (stdSchTable.SelectedRows.Count == 1)
            {
                student curStd = usrDB.getStudent(username);
                usrDB.dropCrsFromStd(stdSchTable.SelectedRows[0].Cells["Course ID"].FormattedValue.ToString().Trim(), currentSemester, ref crsDB,curStd);
                DataGridViewRow row = crsLstTable.SelectedRows[0];
                course crs = crsDB.getCourse(row.Cells["Course"].Value.ToString());
                row.Cells["Seats"].Value = crs.seats + " / " + crs.maxSeats;
                //createCrsLstTable();
                createCrsHistTable(crs_hist_table);
                List<course> studentCrsLst = curStd.registeredCrs;
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

        private void dropDownValueChanged(object sender, EventArgs e)
        {
            string course = facDropDown.SelectedItem.ToString();
            if (course == "")
                enrolledStdTable.Visible = false;
            createEnrolledStdTable(enrolledStdTable, course);
            enrolledStdTable.Visible = true;
        }
    }
}
