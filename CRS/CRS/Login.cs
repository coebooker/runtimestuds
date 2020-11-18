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
        private courseDatabase crsDB;
        string cpath;
        string ppath;
        bool flag = false;

        public LoginForm(string upath, string cpath, string ppath)
        {
            InitializeComponent();
            this.cpath = cpath;
            this.ppath = ppath;
            usrDB = new userDatabase(upath);

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
            string password = this.password.Text.ToLower();

            if (usrDB.isValidUser(username, password, ref usertype))
            {
                this.Hide();
                if (usertype == "admin" || usertype == "manager")
                {
                    if (!flag)
                    {
                        var form = new admMainpage(usrDB, ppath);
                        form.ShowDialog();
                        this.usrDB = form.usrDB;
                        this.crsDB = form.crsDB;
                    }
                    else
                    {
                        var form = new admMainpage(usrDB, crsDB);
                        form.ShowDialog();
                        this.usrDB = form.usrDB;
                        this.crsDB = form.crsDB;
                    }    
                }
                else
                {
                    if (!flag)
                    {
                        var form = new mainpage(usertype, username, usrDB, cpath, ppath);
                        form.ShowDialog();
                        this.usrDB = form.usrDB;
                        this.crsDB = form.crsDB;
                    }
                    else
                    {
                        var form = new mainpage(usertype, username, usrDB, crsDB);
                        form.ShowDialog();
                        this.usrDB = form.usrDB;
                        this.crsDB = form.crsDB;
                    }
                }
                this.username.Text = "Username";
                this.username.ForeColor = Color.Silver;
                this.password.Text = "Password";
                this.password.PasswordChar = '\0';
                this.password.ForeColor = Color.Silver;

                flag = true;
                this.ShowDialog();
            }
            else
            {
                MessageBox.Show("Your username or password is incorrect.",
                    "Invalid Credential",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
                this.password.Text = "";
                this.password.PasswordChar = '*';
                this.password.ForeColor = Color.White;
            }
        }

        private void close_click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
