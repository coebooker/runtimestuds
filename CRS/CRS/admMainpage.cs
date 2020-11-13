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
        private userDatabase usrDB;
        private courseDatabase crsDB;
        string nextSemester = "S15";

        public admMainpage(userDatabase usrDB, string cpath, string ppath)
        {
            // Initialization
            crsDB = new courseDatabase(cpath);
            usrDB.addPrevCourses(ppath, ref crsDB, nextSemester);
            this.usrDB = usrDB;
            InitializeComponent();

            createCrsLst();
        }

        public void createCrsLst()
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
        }


        // Create tables for students' interactions
        public void createStdLst()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Username");
            table.Columns.Add("First Name");
            table.Columns.Add("Last Name");
            table.Columns.Add("Advisor");
            table.Columns.Add("GPA");
            table.Columns.Add("Credits");

            foreach (student std in usrDB.getStudentList())
                table.Rows.Add(std.username, std.fname, std.lname, std.advisor, std.calculateGPA(), std.getCredits());

            stdLst.DataSource = table;
            stdLst.Columns["Username"].Visible = false;
        }
        public void createRegisteredCrsLst()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course ID", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("Instructor", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Seats", typeof(string));
            table.Columns.Add("Schedule", typeof(string));

            registeredCrsLst.DataSource = table;
        } // Create the frame of the table


        // Create tables for faculties' interactions
        public void createFacLst()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Username");
            table.Columns.Add("First Name");
            table.Columns.Add("Last Name");
            //table.Columns.Add("Number of Courses teaching");

            foreach (faculty fac in usrDB.getFacultyList())
                table.Rows.Add(fac.username, fac.fname, fac.lname);

            facLst.DataSource = table;
            facLst.Columns["Username"].Visible = false;
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
        //--------------------------------
        private void stdSelectClick(object sender, System.EventArgs e)
        {
            createStdLst();
            createRegisteredCrsLst();

            // Display tables for students' interactions
            stdLst.Visible = true;
            stdLstLabel.Visible = true;

            registeredCrsLst.Visible = true;
            registeredCrsLstLabel.Visible = true;

            dropCrs.Visible = true;
            addCrs.Visible = true;
            stdActions.Visible = true;
            crsHist.Visible = true;
            conflictCheck.Visible = true;
        }
        private void facSelectClick(object sender, System.EventArgs e)
        {
            createFacLst();
            createFacSch();

            // Hide everything of students' interactions
            stdLst.Visible = false;
            stdLstLabel.Visible = false;

            registeredCrsLst.Visible = false;
            registeredCrsLstLabel.Visible = false;

            dropCrs.Visible = false;
            addCrs.Visible = false;
            stdActions.Visible = false;
            crsHist.Visible = false;
            conflictCheck.Visible = false;

            // Show everything of faculties' interactions
            facLst.Visible = true;
            facLstLabel.Visible = true;

            facSch.Visible = true;
            registeredCrsLstLabel.Visible = true;

            showEnrolledStd.Visible = true;
            showAdvisees.Visible = true;
        }


        // Student interactions
        //---------------------------------------------------------
        private void dropCrsClick(object sender, System.EventArgs e)
        {
            if (registeredCrsLst.SelectedRows.Count == 1)
            {
                string crsID = registeredCrsLst.SelectedRows[0].Cells["Course ID"].Value.ToString();
                string username = stdLst.SelectedRows[0].Cells["Username"].Value.ToString();

                student std = usrDB.getStudent(username);
                usrDB.dropCrsFromStd(crsID, nextSemester, ref crsDB, std);

                // Update the course list table
                DataGridViewRow row = crsLst.SelectedRows[0];
                course crs = crsDB.getCourse(row.Cells["Course ID"].Value.ToString());
                row.Cells["Seats"].Value = crs.seats + " / " + crs.maxSeats;

                // Update the student schedule table for the next semester
                DataTable table = (DataTable)registeredCrsLst.DataSource;
                foreach (DataRow dr in table.Rows)
                    if (dr["Course ID"].ToString().Trim() == crsID.Trim())
                    {
                        table.Rows.Remove(dr);
                        break;
                    }
            }
            else
                MessageBox.Show("Select a class in the student's schedule table.",
                    "No Class Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
        private void addCrsClick(object sender, System.EventArgs e)
        {
            if (crsLst.SelectedRows.Count == 1)
            {
                if (stdLst.SelectedRows.Count == 1)
                {
                    string crsID = crsLst.SelectedRows[0].Cells["Course ID"].Value.ToString().Trim();
                    string username = stdLst.SelectedRows[0].Cells["Username"].Value.ToString().Trim();

                    student std = usrDB.getStudent(username);
                    usrDB.addCrsToStd(crsID, nextSemester, ref crsDB, std);

                    // Update the course list table
                    DataGridViewRow row = crsLst.SelectedRows[0];
                    course crs = crsDB.getCourse(crsID);
                    row.Cells["Seats"].Value = crs.seats + " / " + crs.maxSeats;

                    // Update the student schedule table for the next semester
                    DataTable table = (DataTable)registeredCrsLst.DataSource;
                    table.Rows.Add(crsID, crs.title, crs.instructor, crs.credit, crs.seats, crs.getBlocks());

                    new addedCourse(crsID).Show();
                }
                else
                    MessageBox.Show("Select a student in the student list.",
                    "No Student Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Select a class in the course list.",
                    "No Class Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
        private void crsHistClick(object sender, System.EventArgs e)
        {
            if (stdLst.SelectedRows.Count == 1)
            {
                string username = stdLst.SelectedRows[0].Cells["Username"].Value.ToString().Trim();
                student std = usrDB.getStudent(username);
                new admCrsHist(std).Show();
            }
            else
                MessageBox.Show("Select a student from the student list",
                    "No student selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
        private void rowSelected(object sender, DataGridViewCellEventArgs e)
        {
            if (stdLst.SelectedRows.Count == 1)
            {
                string username = stdLst.SelectedRows[0].Cells["Username"].Value.ToString().Trim();
                student std = usrDB.getStudent(username);

                // Update the registered courses list
                DataTable table = (DataTable)registeredCrsLst.DataSource;
                table.Rows.Clear();
                foreach (course crs in std.getRegisteredCrs())
                    table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.seats, crs.getBlocks());
            }
        }
        private void conflictCheckClick(object sender, System.EventArgs e)
        {
            if (stdLst.SelectedRows.Count == 1)
            {
                string username = stdLst.SelectedRows[0].Cells["Username"].Value.ToString();
                MessageBox.Show(usrDB.getStudent(username).timeCheck(),
                    "Time Check",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Select a student from the student list",
                    "No student selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }


        // Faculty interactions
        //----------------------------------------------------------------------
        private void facSelected(object sender, DataGridViewCellEventArgs e)
        {
            if (facLst.SelectedRows.Count == 1)
            {
                string username = facLst.SelectedRows[0].Cells["Username"].Value.ToString().Trim();

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
            if (facLst.SelectedRows.Count == 1)
            {
                string username = facLst.SelectedRows[0].Cells["Username"].Value.ToString();
                faculty fac = usrDB.getFaculty(username);
                new admAdvisees(fac);
            }
            else
                MessageBox.Show("Select a faculty from the faculties list",
                    "No faculty selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        private void checkAdviseeScheduleClick(object sender, EventArgs e)
        {
            if (facLst.SelectedRows.Count == 1)
            {
                string username = facLst.SelectedRows[0].Cells["Username"].Value.ToString();
                faculty fac = usrDB.getFaculty(username);
                new admAdvisees(fac);
            }
            else
                MessageBox.Show("Select a faculty from the faculties list",
                    "No faculty selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
    }
}