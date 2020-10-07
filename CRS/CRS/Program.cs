using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            PreviousCourseDB PrevCourseDB = new PreviousCourseDB(@"C:\Users\Coe\Downloads\historyDB.in");
            userDatabase usrDB = new userDatabase();
            List < student > studentLst = usrDB.getStudentList();
            foreach(student currentStudent in studentLst)
            {
                foreach(PreviousCourse currentCourse in PrevCourseDB.AllPreviousCourses)
                {
                    if (currentCourse.student == currentStudent.username)
                    {
                        currentStudent.AddPreviousCourse(currentCourse);
                    }
                }
            }

            usrDB.readInData(@"C:\Users\mikit\Downloads\userDB.in");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(usrDB)); // An instance of LoginForm class
        }
    }
}
