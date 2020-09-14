using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main()
        {
            string[] users = System.IO.File.ReadAllLines("input.txt");
            foreach(string user in users)
            {
                string username = user.Substring(0, 10);
                username.Trim();
                string password = user.Substring(11, 10);
                string firstName = user.Substring(22, 15);
                string middleName = user.Substring(38, 15);
                string lastName = user.Substring(54, 15);
                string status = user.Substring(70);
                password.Trim();
                firstName.Trim();
                middleName.Trim();
                lastName.Trim();
                status.Trim();
                string[] userArr = {username,password,firstName,lastName,status };
                foreach(string item in userArr)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
