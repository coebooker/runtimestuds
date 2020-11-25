namespace CRS
{
    partial class admCreateUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.unameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.fname = new System.Windows.Forms.TextBox();
            this.mname = new System.Windows.Forms.TextBox();
            this.lname = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userType = new System.Windows.Forms.ComboBox();
            this.confirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.advisorLabel = new System.Windows.Forms.Label();
            this.advisor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // unameLabel
            // 
            this.unameLabel.AutoSize = true;
            this.unameLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unameLabel.ForeColor = System.Drawing.Color.White;
            this.unameLabel.Location = new System.Drawing.Point(164, 177);
            this.unameLabel.Name = "unameLabel";
            this.unameLabel.Size = new System.Drawing.Size(167, 32);
            this.unameLabel.TabIndex = 0;
            this.unameLabel.Text = "Username : ";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.ForeColor = System.Drawing.Color.White;
            this.passwordLabel.Location = new System.Drawing.Point(164, 238);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(152, 32);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(164, 421);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "First Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(164, 543);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Last Name :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(164, 482);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(195, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Middle Name :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(164, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 32);
            this.label6.TabIndex = 5;
            this.label6.Text = "User Type :";
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.Silver;
            this.username.Location = new System.Drawing.Point(382, 174);
            this.username.MaxLength = 10;
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(255, 39);
            this.username.TabIndex = 0;
            this.username.Text = "Username";
            this.username.Enter += new System.EventHandler(this.usernameEnter);
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.Silver;
            this.password.Location = new System.Drawing.Point(382, 235);
            this.password.MaxLength = 10;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(255, 39);
            this.password.TabIndex = 1;
            this.password.Text = "Password";
            this.password.Enter += new System.EventHandler(this.passwordEnter);
            // 
            // fname
            // 
            this.fname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.fname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fname.ForeColor = System.Drawing.Color.Silver;
            this.fname.Location = new System.Drawing.Point(382, 419);
            this.fname.MaxLength = 15;
            this.fname.Name = "fname";
            this.fname.Size = new System.Drawing.Size(255, 39);
            this.fname.TabIndex = 4;
            this.fname.Text = "First Name";
            this.fname.Enter += new System.EventHandler(this.fnameEnter);
            // 
            // mname
            // 
            this.mname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.mname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mname.ForeColor = System.Drawing.Color.Silver;
            this.mname.Location = new System.Drawing.Point(382, 480);
            this.mname.MaxLength = 15;
            this.mname.Name = "mname";
            this.mname.Size = new System.Drawing.Size(255, 39);
            this.mname.TabIndex = 5;
            this.mname.Text = "Middle Name";
            this.mname.Enter += new System.EventHandler(this.mnameEnter);
            // 
            // lname
            // 
            this.lname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.lname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lname.ForeColor = System.Drawing.Color.Silver;
            this.lname.Location = new System.Drawing.Point(382, 541);
            this.lname.MaxLength = 15;
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(255, 39);
            this.lname.TabIndex = 6;
            this.lname.Text = "Last Name";
            this.lname.Enter += new System.EventHandler(this.lnameEnter);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 90);
            this.panel1.TabIndex = 12;
            // 
            // userType
            // 
            this.userType.AutoCompleteCustomSource.AddRange(new string[] {
            "Student",
            "Faculty",
            "Admin",
            "Manager"});
            this.userType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.userType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.userType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.userType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userType.ForeColor = System.Drawing.Color.White;
            this.userType.FormattingEnabled = true;
            this.userType.Items.AddRange(new object[] {
            "Student",
            "Faculty",
            "Admin",
            "Manager"});
            this.userType.Location = new System.Drawing.Point(382, 296);
            this.userType.Margin = new System.Windows.Forms.Padding(0);
            this.userType.Name = "userType";
            this.userType.Size = new System.Drawing.Size(255, 40);
            this.userType.TabIndex = 2;
            // 
            // confirm
            // 
            this.confirm.AutoSize = true;
            this.confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirm.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.confirm.FlatAppearance.BorderSize = 0;
            this.confirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm.ForeColor = System.Drawing.Color.White;
            this.confirm.Location = new System.Drawing.Point(277, 612);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(246, 44);
            this.confirm.TabIndex = 7;
            this.confirm.Text = "Register the User";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.confirmClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(35, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 29);
            this.label1.TabIndex = 14;
            this.label1.Text = "* : Required field";
            // 
            // advisorLabel
            // 
            this.advisorLabel.AutoSize = true;
            this.advisorLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advisorLabel.ForeColor = System.Drawing.Color.White;
            this.advisorLabel.Location = new System.Drawing.Point(164, 360);
            this.advisorLabel.Name = "advisorLabel";
            this.advisorLabel.Size = new System.Drawing.Size(131, 32);
            this.advisorLabel.TabIndex = 15;
            this.advisorLabel.Text = "Advisor : ";
            // 
            // advisor
            // 
            this.advisor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.advisor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.advisor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.advisor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.advisor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.advisor.ForeColor = System.Drawing.Color.White;
            this.advisor.FormattingEnabled = true;
            this.advisor.Location = new System.Drawing.Point(382, 357);
            this.advisor.Margin = new System.Windows.Forms.Padding(0);
            this.advisor.Name = "advisor";
            this.advisor.Size = new System.Drawing.Size(255, 40);
            this.advisor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(142, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 32);
            this.label2.TabIndex = 17;
            this.label2.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(142, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 32);
            this.label7.TabIndex = 18;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(142, 299);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 32);
            this.label8.TabIndex = 19;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(142, 421);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 32);
            this.label9.TabIndex = 20;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(142, 543);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 32);
            this.label10.TabIndex = 21;
            this.label10.Text = "*";
            // 
            // admCreateUser
            // 
            this.AcceptButton = this.confirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(800, 694);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.advisor);
            this.Controls.Add(this.advisorLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.userType);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lname);
            this.Controls.Add(this.mname);
            this.Controls.Add(this.fname);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.unameLabel);
            this.Name = "admCreateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "admAddUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label unameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox fname;
        private System.Windows.Forms.TextBox mname;
        private System.Windows.Forms.TextBox lname;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox userType;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label advisorLabel;
        private System.Windows.Forms.ComboBox advisor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}