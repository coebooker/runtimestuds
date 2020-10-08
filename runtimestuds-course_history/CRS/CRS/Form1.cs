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
        private userDatabase usrDB;
        string usrf_path;
        string crsf_path;
        string prevcrsf_path;
        public LoginForm(string upath, string cpath, string pcpath)
        {
            InitializeComponent();
            usrf_path = upath;
            crsf_path = cpath;
            prevcrsf_path = pcpath;

            userDatabase userDB = new userDatabase(usrf_path);
            usrDB = userDB;
            Bitmap bmp = ((Bitmap)close.BackgroundImage);
            bmp.MakeTransparent();
        }

        private void UsernameEnter(object sender, EventArgs e)
        {
            if (username.Text == "Username")
            {
                username.Text = "";
                username.ForeColor = Color.White;
            }
        }

        private void UsernameLeave(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                username.Text = "Username";
                username.ForeColor = Color.Silver;
            }
        }

        private void PasswordEnter(object sender, EventArgs e)
        {
            if (password.Text == "Password")
            {
                password.Text = "";
                password.PasswordChar = '*';
                password.ForeColor = Color.White;
            }
        }

        private void PasswordLeave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.Text = "Password";
                password.PasswordChar = '\0';
                password.ForeColor = Color.Silver;
            }
        }

        private void LoginClick(object sender, EventArgs e)
        {
            string usertype = "student";    //Default
            string username = this.username.Text.ToLower();
            string pswd = password.Text.ToLower();

            if (usrDB.isValidUser(username, pswd, ref usertype))
            {
                this.Hide();
                new mainpage(usertype, username, usrDB, usrf_path, crsf_path, prevcrsf_path).ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Your username or password is incorrect.",
                    "Invalid Credential",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
                password.Text = "";
                password.PasswordChar = '*';
                password.ForeColor = Color.White;
            }
        }

        private void close_click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
