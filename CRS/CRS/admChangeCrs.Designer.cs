namespace CRS
{
    partial class admChangeCrs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.schedule = new System.Windows.Forms.DataGridView();
            this.label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.endingTimeA = new System.Windows.Forms.ComboBox();
            this.startingTimeA = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FA = new System.Windows.Forms.CheckBox();
            this.RA = new System.Windows.Forms.CheckBox();
            this.WA = new System.Windows.Forms.CheckBox();
            this.TA = new System.Windows.Forms.CheckBox();
            this.MA = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.facLst = new System.Windows.Forms.ComboBox();
            this.confirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.schedule)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1405, 90);
            this.panel1.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label12.Location = new System.Drawing.Point(0, 799);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1405, 155);
            this.label12.TabIndex = 88;
            // 
            // schedule
            // 
            this.schedule.AllowUserToAddRows = false;
            this.schedule.AllowUserToDeleteRows = false;
            this.schedule.AllowUserToResizeColumns = false;
            this.schedule.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            this.schedule.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.schedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.schedule.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.schedule.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.schedule.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.schedule.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.schedule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.schedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.schedule.DefaultCellStyle = dataGridViewCellStyle3;
            this.schedule.EnableHeadersVisualStyles = false;
            this.schedule.Location = new System.Drawing.Point(206, 210);
            this.schedule.Name = "schedule";
            this.schedule.RowHeadersVisible = false;
            this.schedule.RowHeadersWidth = 62;
            this.schedule.RowTemplate.Height = 28;
            this.schedule.Size = new System.Drawing.Size(424, 174);
            this.schedule.TabIndex = 89;
            this.schedule.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.scheduleCellValueChanged);
            this.schedule.CurrentCellDirtyStateChanged += new System.EventHandler(this.schduleCurrentCellDirtyStateChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(149, 154);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(250, 33);
            this.label.TabIndex = 90;
            this.label.Text = "Current Schedule";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(903, 539);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 33);
            this.label8.TabIndex = 102;
            this.label8.Text = "To";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(489, 539);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 33);
            this.label7.TabIndex = 101;
            this.label7.Text = "From";
            // 
            // endingTimeA
            // 
            this.endingTimeA.FormattingEnabled = true;
            this.endingTimeA.Items.AddRange(new object[] {
            "8:00 AM",
            "8:30 AM",
            "9:00 AM",
            "9:30 AM",
            "10:00 AM",
            "10:30 AM",
            "11:00 AM",
            "11:30 AM",
            "12:00 PM",
            "12:30 PM",
            "1:00 PM",
            "1:30 PM",
            "2:00 PM",
            "2:30 PM",
            "3:00 PM",
            "3:30 PM",
            "4:00 PM"});
            this.endingTimeA.Location = new System.Drawing.Point(1000, 541);
            this.endingTimeA.Name = "endingTimeA";
            this.endingTimeA.Size = new System.Drawing.Size(230, 28);
            this.endingTimeA.TabIndex = 97;
            // 
            // startingTimeA
            // 
            this.startingTimeA.FormattingEnabled = true;
            this.startingTimeA.Items.AddRange(new object[] {
            "8:00 AM",
            "8:30 AM",
            "9:00 AM",
            "9:30 AM",
            "10:00 AM",
            "10:30 AM",
            "11:00 AM",
            "11:30 AM",
            "12:00 PM",
            "12:30 PM",
            "1:00 PM",
            "1:30 PM",
            "2:00 PM",
            "2:30 PM",
            "3:00 PM",
            "3:30 PM",
            "4:00 PM"});
            this.startingTimeA.Location = new System.Drawing.Point(624, 541);
            this.startingTimeA.Name = "startingTimeA";
            this.startingTimeA.Size = new System.Drawing.Size(230, 28);
            this.startingTimeA.TabIndex = 96;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(213, 539);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(215, 33);
            this.label6.TabIndex = 100;
            this.label6.Text = "Session Time :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(149, 402);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(228, 33);
            this.label5.TabIndex = 99;
            this.label5.Text = "New Time Slot :";
            // 
            // FA
            // 
            this.FA.AutoSize = true;
            this.FA.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FA.ForeColor = System.Drawing.Color.White;
            this.FA.Location = new System.Drawing.Point(1136, 473);
            this.FA.Name = "FA";
            this.FA.Size = new System.Drawing.Size(91, 27);
            this.FA.TabIndex = 95;
            this.FA.Text = "Friday";
            this.FA.UseVisualStyleBackColor = true;
            // 
            // RA
            // 
            this.RA.AutoSize = true;
            this.RA.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RA.ForeColor = System.Drawing.Color.White;
            this.RA.Location = new System.Drawing.Point(977, 473);
            this.RA.Name = "RA";
            this.RA.Size = new System.Drawing.Size(117, 27);
            this.RA.TabIndex = 94;
            this.RA.Text = "Thursday";
            this.RA.UseVisualStyleBackColor = true;
            // 
            // WA
            // 
            this.WA.AutoSize = true;
            this.WA.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WA.ForeColor = System.Drawing.Color.White;
            this.WA.Location = new System.Drawing.Point(795, 473);
            this.WA.Name = "WA";
            this.WA.Size = new System.Drawing.Size(140, 27);
            this.WA.TabIndex = 93;
            this.WA.Text = "Wednesday";
            this.WA.UseVisualStyleBackColor = true;
            // 
            // TA
            // 
            this.TA.AutoSize = true;
            this.TA.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TA.ForeColor = System.Drawing.Color.White;
            this.TA.Location = new System.Drawing.Point(643, 473);
            this.TA.Name = "TA";
            this.TA.Size = new System.Drawing.Size(110, 27);
            this.TA.TabIndex = 92;
            this.TA.Text = "Tuesday";
            this.TA.UseVisualStyleBackColor = true;
            // 
            // MA
            // 
            this.MA.AutoSize = true;
            this.MA.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MA.ForeColor = System.Drawing.Color.White;
            this.MA.Location = new System.Drawing.Point(495, 473);
            this.MA.Name = "MA";
            this.MA.Size = new System.Drawing.Size(106, 27);
            this.MA.TabIndex = 91;
            this.MA.Text = "Monday";
            this.MA.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(213, 470);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 33);
            this.label4.TabIndex = 98;
            this.label4.Text = "Meeting Day(s) :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(149, 661);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 33);
            this.label1.TabIndex = 103;
            this.label1.Text = "Instructor :";
            // 
            // facLst
            // 
            this.facLst.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facLst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.facLst.FormattingEnabled = true;
            this.facLst.Location = new System.Drawing.Point(384, 662);
            this.facLst.Name = "facLst";
            this.facLst.Size = new System.Drawing.Size(284, 31);
            this.facLst.TabIndex = 104;
            // 
            // confirm
            // 
            this.confirm.AutoSize = true;
            this.confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.confirm.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.confirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm.ForeColor = System.Drawing.Color.White;
            this.confirm.Location = new System.Drawing.Point(584, 755);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(210, 44);
            this.confirm.TabIndex = 105;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.confirmClick);
            // 
            // admChangeCrs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(1431, 712);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.facLst);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.endingTimeA);
            this.Controls.Add(this.startingTimeA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FA);
            this.Controls.Add(this.RA);
            this.Controls.Add(this.WA);
            this.Controls.Add(this.TA);
            this.Controls.Add(this.MA);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label);
            this.Controls.Add(this.schedule);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel1);
            this.Name = "admChangeCrs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Course";
            ((System.ComponentModel.ISupportInitialize)(this.schedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView schedule;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox endingTimeA;
        private System.Windows.Forms.ComboBox startingTimeA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox FA;
        private System.Windows.Forms.CheckBox RA;
        private System.Windows.Forms.CheckBox WA;
        private System.Windows.Forms.CheckBox TA;
        private System.Windows.Forms.CheckBox MA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox facLst;
        private System.Windows.Forms.Button confirm;
    }
}