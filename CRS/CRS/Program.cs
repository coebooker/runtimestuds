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
            userDatabase usrDB = new userDatabase();
            usrDB.readInData(@"C:\Users\81802\Desktop\userDB.in");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm(usrDB)); // An instance of LoginForm class
        }
    }
}
