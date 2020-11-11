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
            string userfile_path = @"C:\Users\cmbooker\Downloads\userDB.in";
            string coursefile_path = @"C:\Users\cmbooker\downloads\courseDB.in";
            string prevcoursefile_path = @"C:\Users\cmbooker\Downloads\historyDB.in";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(userfile_path, coursefile_path, prevcoursefile_path));
        }
    }
}
