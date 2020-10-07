﻿using System;
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
            foreach(PreviousCourse PrevCourse in PrevCourseDB.AllPreviousCourses){
                PrevCourse.ListCourse();
            }
            /*userDatabase usrDB = new userDatabase();
            usrDB.readInData(@"C:\Users\mikit\Downloads\userDB.in");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(usrDB)); // An instance of LoginForm class*/
        }
    }
}
