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
            string userfile_path = @"..\..\userDB.in";
            string coursefile_path = @"..\..\courseDB.in";
            string prevcoursefile_path = @"..\..\historyDB.in";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(userfile_path, coursefile_path, prevcoursefile_path));
        }
    }
}
