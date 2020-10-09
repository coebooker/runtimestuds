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
    public partial class mainpage : Form
    {
        private userDatabase usrDB;
        private List<course> crsLst;
        private courseDatabase crsDB;
        private string username;
        string upath;
        string cpath;
        string ppath;
        string currentSemester = "F20";
        validity validityResult;

        public mainpage(string userType, string userName, userDatabase userDB, string userpath, string coursepath, string prevpath)
        {
            upath = userpath;
            cpath = coursepath;
            ppath = prevpath;

            crsDB = new courseDatabase(cpath);
            userDB.add_prev_courses(ppath);
            InitializeComponent();

            username = userName;
            usrDB = userDB;
  
            crsLst = crsDB.GetCourseList();

            create_crs_lst_table(crs_lst_table);
            create_crs_hist_table(crs_hist_table);
            alignButtons(userType, 53);
        }

        private void create_crs_lst_table(DataGridView data_grid_view)
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
                table.Rows.Add(crs.getCode(), crs.getTitle(), crs.getInstructor(), crs.getCredit(), crs.getSeats(), crs.getBlocks());
            }

            data_grid_view.DataSource = table;
            crs_hist_table.EnableHeadersVisualStyles = false;
        }

        private void create_crs_hist_table(DataGridView dgv)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Course Name", typeof(string));
            table.Columns.Add("Semester", typeof(string));
            table.Columns.Add("Credits", typeof(string));
            table.Columns.Add("Grade", typeof(string));

            student std = usrDB.getStudent(username);
            List<PreviousCourse> crsHist = std.getCrsHist();

            foreach (PreviousCourse pcrs in crsHist)
            {
                table.Rows.Add(pcrs.name, pcrs.semester, pcrs.credit, pcrs.grade);
            }

            crs_hist_table.DataSource = table;
            crs_hist_table.EnableHeadersVisualStyles = false;
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
                view_sch_fac.Visible = true;
                view_sch_fac.Location = sec_btn;
            }
            else if (userType == "admin")
            {
                add_crs_adm.Visible = true;
                add_crs_adm.Location = sec_btn;
                view_sch_admin.Visible = true;
                view_sch_admin.Location = trd_btn;
            }
        }


        // Event handlers
        private void LogoutClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddCourseStudentClick(object sender, EventArgs e)
        {
            if (crs_lst_table.SelectedRows.Count == 1)
            {
                validityResult = usrDB.getStudent(username).isValidAdd(currentSemester, crsDB.getCourse(crs_lst_table.SelectedRows[0].Cells["Course ID"].FormattedValue.ToString()));
                if (validityResult.valid)
                {
                    if(validityResult.warning)
                    {
                        //Pop up warning message
                        MessageBox.Show(validityResult.message,
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                        if (crs_lst_table.Visible == false)
                        {
                            crs_lst_table.Visible = true;
                        }
                    }

                    // THINGS TO DO

                    // Actually add course to student account DONE

                    // -> Add it to RegisteredCourse List under the student class DONE

                    // -> Add it to course history with X as status under the student class DONE

                    // Decrement number of seats for the class DONE

                    // All the above should be done with pass by reference to mitigate data-overwrite every course addition/deletion

                    // For Admin account, probably pass by reference the student instance into AdminStudentSelect form DONE

                    usrDB.addCourseToStudent(username, crs_lst_table.SelectedRows[0].Cells["Course ID"].FormattedValue.ToString().Trim(), currentSemester, ref crsDB);

                    new addedCourse(crs_lst_table.SelectedRows[0].Cells["Course ID"].FormattedValue.ToString()).Show();
                    create_crs_lst_table(crs_lst_table);
                    create_crs_hist_table(crs_hist_table);
                    
                }
                else
                {
                    // Display that it's a invalid add
                    MessageBox.Show(validityResult.message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    if (crs_lst_table.Visible == false)
                    {
                        crs_lst_table.Visible = true;
                    }
                }
            }        
            else
            {
                MessageBox.Show("Select a class",
                    "No Class",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                if (crs_lst_table.Visible == false)
                {
                    crs_lst_table.Visible = true;
                }
            }
        }

        private void ViewScheduleAdminClick(object sender, EventArgs e)
        {
            new AdminFacultyList(usrDB, crsDB).Show();
        }

        private void ViewCourseListClick(object sender, EventArgs e)
        {
            if (crs_hist_table.Visible == true)
            {
                crs_hist_table.Visible = false;
            }
            if (crs_lst_table.Visible == false)
                crs_lst_table.Visible = true;
            else
                crs_lst_table.Visible = false;

        }

        private void crs_hist_click(object sender, EventArgs e)
        {
            if (crs_lst_table.Visible == true)
                crs_lst_table.Visible = false;
            if (crs_hist_table.Visible == false)
                crs_hist_table.Visible = true;
            else
                crs_hist_table.Visible = false;
        }

        private void del_crs_click(object sender, EventArgs e)
        {
            student currentStd = usrDB.getStudent(username);
            List<course> stdCrsLst = currentStd.getRegisteredCrs();

            new StudentCourses(stdCrsLst).Show();
        }

        private void view_sch_fac_click(object sender, EventArgs e)
        {
            new FacultyCourses(crsLst, username).Show();
        }

        private void add_crs_adm_click(object sender, EventArgs e)
        {
            if (crs_lst_table.SelectedRows.Count == 1)
            {
                new AdminStudentSelect(crs_lst_table.SelectedRows[0].Cells["Course ID"].FormattedValue.ToString(), ref usrDB, ref crsDB, currentSemester).Show();
            }
            else
            {
                MessageBox.Show("Select a class",
                    "No Class",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                if (crs_lst_table.Visible == false)
                {
                    crs_lst_table.Visible = true;
                }
            }
            create_crs_lst_table(crs_lst_table);
            create_crs_hist_table(crs_hist_table);
        }

        private void view_sch_std_click(object sender, EventArgs e)
        {
            student currentStd = usrDB.getStudent(username);
            List<course> stdCrsLst = currentStd.getRegisteredCrs();

            new StudentCourses(stdCrsLst).Show();
        }
    }
}
