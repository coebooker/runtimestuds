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
    
    public partial class AdminStudentSelect : Form
    {
        validity validityResult;
        string coursePass;
        userDatabase usrDB;
        courseDatabase crsDB;
        string currentSemester;
        string courseAdding;
        public AdminStudentSelect(string crsAdding, ref userDatabase userDB, ref courseDatabase courseDB, string crntSmst)
        {
            InitializeComponent();

            usrDB = userDB;
            crsDB = courseDB;
            currentSemester = crntSmst;
            courseAdding = crsAdding;

            coursePass = courseAdding;

            DataTable table = new DataTable();
            List<student> studentDBInstance = usrDB.getStudentList();
            table.Columns.Add("Username", typeof(string));
            table.Columns.Add("First name", typeof(string));
            table.Columns.Add("Middle name", typeof(string));
            table.Columns.Add("Last name", typeof(string));

            foreach (student usr in studentDBInstance)
            {
                 table.Rows.Add(usr.username, usr.fname, usr.mname, usr.lname);
            }

            dataGridView1.DataSource = table;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(225)))));
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void AdminStudentSelect_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentPass = dataGridView1.SelectedRows[0].Cells["First Name"].FormattedValue.ToString() +" "+ dataGridView1.SelectedRows[0].Cells["Middle Name"].FormattedValue.ToString() +" "+ dataGridView1.SelectedRows[0].Cells["Last Name"].FormattedValue.ToString();




            validityResult = usrDB.getStudent(dataGridView1.SelectedRows[0].Cells["Username"].FormattedValue.ToString()).isValidAdd(currentSemester, crsDB.getCourse(courseAdding));
            if (validityResult.valid)
            {
                if (validityResult.warning)
                {
                    //Pop up warning message
                    MessageBox.Show(validityResult.message,
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                    if (dataGridView1.Visible == false)
                    {
                        dataGridView1.Visible = true;
                    }
                }

                // THINGS TO DO

                // Actually add course to student account DONE

                // -> Add it to RegisteredCourse List under the student class DONE

                // -> Add it to course history with X as status under the student class DONE

                // Decrement number of seats for the class DONE

                // All the above should be done with pass by reference to mitigate data-overwrite every course addition/deletion

                // For Admin account, probably pass by reference the student instance into AdminStudentSelect form

                usrDB.addCourseToStudent(dataGridView1.SelectedRows[0].Cells["Username"].FormattedValue.ToString(), courseAdding.Trim(), currentSemester, ref crsDB);


                new AdminStudentCourse(coursePass, studentPass).Show();
            }
            else
            {
                // Display that it's a invalid add
                MessageBox.Show(validityResult.message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                if (dataGridView1.Visible == false)
                {
                    dataGridView1.Visible = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
