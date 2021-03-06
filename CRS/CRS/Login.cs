﻿using System;
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
        private string uname;
        private string utype;
        bool flag = false;  // Flag to check if at least one mainpage was open

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
            uname = username.Text.Trim().ToLower();
            utype = "student";
            string password = this.password.Text.Trim();

            if (usrDB.isValidUser(uname, password, ref utype))
            {
                Hide();
                if (utype == "admin" || utype == "manager")
                {
                    if (!flag)
                    {
                        var form = new admMainpage(usrDB, @"..\..\historyDB.in", utype);
                        form.ShowDialog();
                        usrDB = form.usrDB;
                        crsDB = form.crsDB;
                        usrDB.updateDatabase();
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
                    if (utype == "faculty")
                    {
                        if (!flag)
                        {
                            var form = new facMainpage(uname, usrDB);
                            form.ShowDialog();
                            usrDB = form.usrDB;
                            crsDB = form.crsDB;
                        }
                        else
                        {
                            var form = new facMainpage(uname, usrDB, crsDB);
                            form.ShowDialog();
                            usrDB = form.usrDB;
                            crsDB = form.crsDB;
                        }
                    }
                    else
                    {
                        if (!flag)
                        {
                            var form = new stdMainpage(uname, usrDB);
                            form.ShowDialog();
                            usrDB = form.usrDB;
                            crsDB = form.crsDB;
                        }
                        else
                        {
                            var form = new stdMainpage(uname, usrDB, crsDB);
                            form.ShowDialog();
                            usrDB = form.usrDB;
                            crsDB = form.crsDB;
                        }
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
                usrDB.updateDatabase();
                crsDB.updateDatabase();
            }
        }
    }
}
