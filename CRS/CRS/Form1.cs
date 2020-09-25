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
    public partial class LoginForm : Form
    {
        // Class Constructor
        public LoginForm(userDatabase userDB)
        {
            InitializeComponent(); // Initialize components
            usrDB = userDB;
        }

        // When entering the username box
        private void UsernameEnter(object sender, EventArgs e)
        {
            if (Username.Text == "Username")
            {
                Username.Text = "";
                Username.ForeColor = Color.Black;
            }
        }

        // When leaving the username box
        private void UsernameLeave(object sender, EventArgs e)
        {
            if (Username.Text == "")
            {
                Username.Text = "Username";
                Username.ForeColor = Color.Silver;
            }
        }
        
        // When entering the password box
        private void PasswordEnter(object sender, EventArgs e)
        {
            if (Password.Text == "Password")
            {
                Password.Text = "";
                Password.PasswordChar = '*';
                Password.ForeColor = Color.Black;
            }
        }

        // When leaving the password box
        private void PasswordLeave(object sender, EventArgs e)
        {
            if (Password.Text == "")
            {
                Password.Text = "Password";
                Password.PasswordChar = '\0';
                Password.ForeColor = Color.Silver;
            }
        }

        private void ExitClick(object sender, EventArgs e)
        {
            // Add some notification telling the program about to terminate
            this.Close();
        }

        // When Login button is clicked
        private void LoginClick(object sender, EventArgs e)
        {
            string usertype;
            // Change the order especially else part
            if (StudentButton.Checked)
                usertype = "student";
            else if (FacultyButton.Checked)
                usertype = "faculty";
            else
                usertype = "admin";

            if (usrDB.isValidUser(Username.Text, Password.Text, usertype))
            {
                string userPassIn = Username.Text;
                this.Hide();
                courseDatabase crsDB = new courseDatabase();
                crsDB.readInCourse(@"C:\Users\81802\Desktop\courseDB.in");
                new Mainpage(crsDB,usertype,userPassIn).Show();
            }
            else // Invalid credential
            {
                MessageBox.Show("Your username or password is incorrect.",
                    "Invalid Credential",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
                Password.Text = "Password";
                Password.PasswordChar = '\0';
                Password.ForeColor = Color.Silver;
            }
        }

        private userDatabase usrDB;
    }
}
