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
    public partial class admCreateUser : Form
    {
        public string uname;
        public string pword;
        public string uType;
        public string fName;
        public string mName;
        public string lName;
        private userDatabase usrDB;

        public admCreateUser(userDatabase usrDB)
        {
            InitializeComponent();
            this.usrDB = usrDB;
            confirm.FlatAppearance.CheckedBackColor = Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));

            foreach (faculty fac in usrDB.getFacultyList())
            {
                advisor.Items.Add(fac.fname + " " + fac.lname);
                advisor.AutoCompleteCustomSource.Add(fac.fname + " " + fac.lname);
            }
        }

        private void confirmClick(object sender, EventArgs e)
        {
            // Required fields check
            if (username.Text == "" || password.Text == "" || userType.Text == "" || fname.Text == "" || lname.Text == "")
            {
                MessageBox.Show("Required field missing.",
                    "Invalid Form.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // If student, the presence of an advisor
            if (userType.Text == "Student" && advisor.Text == "")
            {
                MessageBox.Show("Specify an advisor.",
                    "Invalid Form.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Duplicate check: same user username is invalid
            foreach (student std in usrDB.getStudentList())
                if (std.username.Trim().ToLower() == username.Text.Trim().ToLower())
                {
                    MessageBox.Show("The username is already taken.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            foreach (faculty fac in usrDB.getFacultyList())
                if (fac.username.Trim().ToLower() == username.Text.Trim().ToLower())
                {
                    MessageBox.Show("The username is already taken.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            foreach (admin adm in usrDB.getAdminList())
                if (adm.username.Trim().ToLower() == username.Text.Trim().ToLower())
                {
                    MessageBox.Show("The username is already taken.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            foreach (manager man in usrDB.getManagerList())
                if (man.username.Trim().ToLower() == username.Text.Trim().ToLower())
                {
                    MessageBox.Show("The username is already taken.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            this.uname = username.Text;
            this.pword = password.Text;
            if (userType.Text == "Student")
            {
                foreach (faculty fac in usrDB.getFacultyList())
                    if (fac.fname + " " + fac.lname == advisor.Text)
                    {
                        uType = fac.username;
                        break;
                    }
            }
            else
                this.uType = userType.Text.ToLower();

            this.fName = fname.Text;
            if (mname.Text == "Middle Name")
                this.mName = "";
            else
                this.mName = mname.Text;
            this.lName = lname.Text;
            this.DialogResult = DialogResult.OK;
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
                password.ForeColor = Color.White;
                password.PasswordChar = '*';
            }
        }
        private void passwordLeave(object sender, EventArgs e)
        {
            if (password.Text == "")
            {
                password.PasswordChar = '\0';
                password.Text = "Password";
                password.ForeColor = Color.Silver;
            }
        }
        private void fnameEnter(object sender, EventArgs e)
        {
            if (fname.Text=="First Name")
            {
                fname.Text = "";
                fname.ForeColor = Color.White;
            }
        }
        private void fnameLeave(object sender, EventArgs e)
        {
            if (fname.Text == "")
            {
                fname.Text = "First Name";
                fname.ForeColor = Color.Silver;
            }
        }
        private void mnameEnter(object sender, EventArgs e)
        {
            if (mname.Text == "Middle Name")
            {
                mname.Text = "";
                mname.ForeColor = Color.White;
            }
        }
        private void mnameLeave(object sender, EventArgs e)
        {
            if (mname.Text == "")
            {
                mname.Text = "Middle Name";
                mname.ForeColor = Color.White;
            }
        }
        private void lnameEnter(object sender, EventArgs e)
        {
            if (lname.Text == "Last Name")
            {
                lname.Text = "";
                lname.ForeColor = Color.White;
            }
        }
        private void lnameLeave(object sender, EventArgs e)
        {
            if (lname.Text == "")
            {
                lname.Text = "Last Name";
                lname.ForeColor = Color.Silver;
            }
        }
    }
}
