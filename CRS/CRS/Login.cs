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
        private ComboBox cb;
        private TextBox tb;
        private string uname;
        private string utype;
        bool flag = false;

        public LoginForm()
        {
            InitializeComponent();
            usrDB = new userDatabase(@"..\..\userDB.in");

            // Make the close button transparent
            Bitmap bmp = ((Bitmap)close.BackgroundImage);
            bmp.MakeTransparent();
            bmp = ((Bitmap)pictureBox2.BackgroundImage);
            bmp.MakeTransparent();
        }

        private void usernameEnter(object sender, EventArgs e)
        {
            if (username.Text == "Username")
            {
                username.Text = "";
                username.ForeColor = Color.White;
            }
        }
        private void usernameLeave(object sender, EventArgs e)
        {
            if (username.Text == "")
            {
                username.Text = "Username";
                username.ForeColor = Color.Silver;
            }
        }
        private void passwordEnter(object sender, EventArgs e)
        {
            if (password.Text == "Password")
            {
                password.Text = "";
                password.PasswordChar = '*';
                password.ForeColor = Color.White;
            }
        }
        private void passwordLeave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.Text = "Password";
                password.PasswordChar = '\0';
                password.ForeColor = Color.Silver;
            }
        }
        private void loginClick(object sender, EventArgs e)
        {
            uname = username.Text.ToLower();
            utype = "student";
            string password = this.password.Text;

            if (usrDB.isValidUser(uname, password, ref utype))
            {
                Hide();
                if (utype == "admin" || utype == "manager")
                {
                    if (!flag)
                    {
                        var form = new admMainpage(usrDB, @"..\..\courseDB.in", @"..\..\historyDB.in", utype);
                        form.ShowDialog();
                        usrDB = form.usrDB;
                        crsDB = form.crsDB;
                    }
                    else
                    {
                        var form = new admMainpage(usrDB, crsDB, utype);
                        form.ShowDialog();
                        usrDB = form.usrDB;
                        crsDB = form.crsDB;
                    }    
                }
                else
                {
                    if (!flag)
                    {
                        var form = new mainpage(utype, uname, usrDB);
                        form.ShowDialog();
                        usrDB = form.usrDB;
                        crsDB = form.crsDB;
                    }
                    else
                    {
                        var form = new mainpage(utype, uname, usrDB, crsDB, cb, tb);
                        form.ShowDialog();
                        usrDB = form.usrDB;
                        crsDB = form.crsDB;
                    }
                }
                username.Text = "Username";
                username.ForeColor = Color.Silver;
                this.password.Text = "Password";
                this.password.PasswordChar = '\0';
                this.password.ForeColor = Color.Silver;

                flag = true;
                Show();
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
            Close();
        }

        private void loginClosing(object sender, FormClosingEventArgs e)
        {
            if (flag)
            {
                if (utype == "student")
                {
                    student std = usrDB.getStudent(uname);
                    std.updateHistoryFile(@"..\..\historyDB.in");
                }
                else if (utype == "admin" || utype == "manager")
                {
                    return;
                }
            }
        }
    }
}
