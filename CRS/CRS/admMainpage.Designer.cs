namespace CRS
{
    partial class admMainpage
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
            this.crsLst = new System.Windows.Forms.DataGridView();
            this.stdSelect = new System.Windows.Forms.Button();
            this.facSelect = new System.Windows.Forms.Button();
            this.addCrs = new System.Windows.Forms.Button();
            this.crsLstLabel = new System.Windows.Forms.Label();
            this.stdLst = new System.Windows.Forms.DataGridView();
            this.stdLstLabel = new System.Windows.Forms.Label();
            this.registeredCrsLst = new System.Windows.Forms.DataGridView();
            this.registeredCrsLstLabel = new System.Windows.Forms.Label();
            this.dropCrs = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.stdActions = new System.Windows.Forms.Panel();
            this.conflictCheck = new System.Windows.Forms.Button();
            this.crsHist = new System.Windows.Forms.Button();
            this.facActions = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.crsLst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdLst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registeredCrsLst)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.stdActions.SuspendLayout();
            this.facActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // crsLst
            // 
            this.crsLst.AllowUserToAddRows = false;
            this.crsLst.AllowUserToDeleteRows = false;
            this.crsLst.AllowUserToOrderColumns = true;
            this.crsLst.AllowUserToResizeColumns = false;
            this.crsLst.AllowUserToResizeRows = false;
            this.crsLst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.crsLst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.crsLst.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.crsLst.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.crsLst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.crsLst.EnableHeadersVisualStyles = false;
            this.crsLst.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.crsLst.Location = new System.Drawing.Point(222, 120);
            this.crsLst.Margin = new System.Windows.Forms.Padding(0);
            this.crsLst.MultiSelect = false;
            this.crsLst.Name = "crsLst";
            this.crsLst.ReadOnly = true;
            this.crsLst.RowHeadersWidth = 30;
            this.crsLst.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.crsLst.RowTemplate.Height = 28;
            this.crsLst.Size = new System.Drawing.Size(469, 321);
            this.crsLst.TabIndex = 13;
            // 
            // stdSelect
            // 
            this.stdSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.stdSelect.FlatAppearance.BorderSize = 0;
            this.stdSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stdSelect.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stdSelect.ForeColor = System.Drawing.Color.White;
            this.stdSelect.Location = new System.Drawing.Point(0, 0);
            this.stdSelect.Margin = new System.Windows.Forms.Padding(0);
            this.stdSelect.Name = "stdSelect";
            this.stdSelect.Size = new System.Drawing.Size(136, 31);
            this.stdSelect.TabIndex = 1;
            this.stdSelect.Text = "Student";
            this.stdSelect.UseVisualStyleBackColor = false;
            this.stdSelect.Click += new System.EventHandler(this.stdSelectClick);
            // 
            // facSelect
            // 
            this.facSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.facSelect.FlatAppearance.BorderSize = 0;
            this.facSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.facSelect.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facSelect.ForeColor = System.Drawing.Color.White;
            this.facSelect.Location = new System.Drawing.Point(136, 0);
            this.facSelect.Margin = new System.Windows.Forms.Padding(0);
            this.facSelect.Name = "facSelect";
            this.facSelect.Size = new System.Drawing.Size(136, 31);
            this.facSelect.TabIndex = 3;
            this.facSelect.Text = "Faculty";
            this.facSelect.UseVisualStyleBackColor = false;
            this.facSelect.Click += new System.EventHandler(this.facSelectClick);
            // 
            // addCrs
            // 
            this.addCrs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addCrs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.addCrs.FlatAppearance.BorderSize = 0;
            this.addCrs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCrs.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCrs.ForeColor = System.Drawing.Color.White;
            this.addCrs.Location = new System.Drawing.Point(522, 453);
            this.addCrs.Margin = new System.Windows.Forms.Padding(0);
            this.addCrs.Name = "addCrs";
            this.addCrs.Size = new System.Drawing.Size(169, 33);
            this.addCrs.TabIndex = 15;
            this.addCrs.Text = "Add Course";
            this.addCrs.UseVisualStyleBackColor = false;
            this.addCrs.Visible = false;
            this.addCrs.Click += new System.EventHandler(this.addCrsClick);
            // 
            // crsLstLabel
            // 
            this.crsLstLabel.AutoSize = true;
            this.crsLstLabel.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crsLstLabel.Location = new System.Drawing.Point(225, 92);
            this.crsLstLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.crsLstLabel.Name = "crsLstLabel";
            this.crsLstLabel.Size = new System.Drawing.Size(188, 21);
            this.crsLstLabel.TabIndex = 16;
            this.crsLstLabel.Text = "Course List for SP15";
            // 
            // stdLst
            // 
            this.stdLst.AllowUserToAddRows = false;
            this.stdLst.AllowUserToDeleteRows = false;
            this.stdLst.AllowUserToOrderColumns = true;
            this.stdLst.AllowUserToResizeColumns = false;
            this.stdLst.AllowUserToResizeRows = false;
            this.stdLst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stdLst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.stdLst.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stdLst.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.stdLst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stdLst.EnableHeadersVisualStyles = false;
            this.stdLst.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.stdLst.Location = new System.Drawing.Point(721, 120);
            this.stdLst.Margin = new System.Windows.Forms.Padding(0);
            this.stdLst.MultiSelect = false;
            this.stdLst.Name = "stdLst";
            this.stdLst.ReadOnly = true;
            this.stdLst.RowHeadersWidth = 30;
            this.stdLst.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.stdLst.RowTemplate.Height = 28;
            this.stdLst.Size = new System.Drawing.Size(335, 147);
            this.stdLst.TabIndex = 17;
            this.stdLst.Visible = false;
            this.stdLst.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.rowSelected);
            // 
            // stdLstLabel
            // 
            this.stdLstLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stdLstLabel.AutoSize = true;
            this.stdLstLabel.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stdLstLabel.Location = new System.Drawing.Point(724, 92);
            this.stdLstLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.stdLstLabel.Name = "stdLstLabel";
            this.stdLstLabel.Size = new System.Drawing.Size(125, 21);
            this.stdLstLabel.TabIndex = 18;
            this.stdLstLabel.Text = "Students List";
            this.stdLstLabel.Visible = false;
            // 
            // registeredCrsLst
            // 
            this.registeredCrsLst.AllowUserToAddRows = false;
            this.registeredCrsLst.AllowUserToDeleteRows = false;
            this.registeredCrsLst.AllowUserToOrderColumns = true;
            this.registeredCrsLst.AllowUserToResizeColumns = false;
            this.registeredCrsLst.AllowUserToResizeRows = false;
            this.registeredCrsLst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.registeredCrsLst.BackgroundColor = System.Drawing.Color.White;
            this.registeredCrsLst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.registeredCrsLst.EnableHeadersVisualStyles = false;
            this.registeredCrsLst.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.registeredCrsLst.Location = new System.Drawing.Point(721, 339);
            this.registeredCrsLst.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registeredCrsLst.Name = "registeredCrsLst";
            this.registeredCrsLst.RowHeadersWidth = 30;
            this.registeredCrsLst.RowTemplate.Height = 28;
            this.registeredCrsLst.Size = new System.Drawing.Size(335, 147);
            this.registeredCrsLst.TabIndex = 19;
            this.registeredCrsLst.Visible = false;
            // 
            // registeredCrsLstLabel
            // 
            this.registeredCrsLstLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.registeredCrsLstLabel.AutoSize = true;
            this.registeredCrsLstLabel.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registeredCrsLstLabel.Location = new System.Drawing.Point(724, 308);
            this.registeredCrsLstLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.registeredCrsLstLabel.Name = "registeredCrsLstLabel";
            this.registeredCrsLstLabel.Size = new System.Drawing.Size(141, 21);
            this.registeredCrsLstLabel.TabIndex = 20;
            this.registeredCrsLstLabel.Text = "Schedule SP15";
            this.registeredCrsLstLabel.Visible = false;
            // 
            // dropCrs
            // 
            this.dropCrs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dropCrs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.dropCrs.FlatAppearance.BorderSize = 0;
            this.dropCrs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropCrs.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropCrs.ForeColor = System.Drawing.Color.White;
            this.dropCrs.Location = new System.Drawing.Point(887, 301);
            this.dropCrs.Margin = new System.Windows.Forms.Padding(0);
            this.dropCrs.Name = "dropCrs";
            this.dropCrs.Size = new System.Drawing.Size(169, 33);
            this.dropCrs.TabIndex = 21;
            this.dropCrs.Text = "Drop Course";
            this.dropCrs.UseVisualStyleBackColor = false;
            this.dropCrs.Visible = false;
            this.dropCrs.Click += new System.EventHandler(this.dropCrsClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.Controls.Add(this.stdSelect, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.facSelect, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 33);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1092, 31);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // stdActions
            // 
            this.stdActions.AutoSize = true;
            this.stdActions.Controls.Add(this.conflictCheck);
            this.stdActions.Controls.Add(this.crsHist);
            this.stdActions.Location = new System.Drawing.Point(0, 92);
            this.stdActions.Margin = new System.Windows.Forms.Padding(0);
            this.stdActions.Name = "stdActions";
            this.stdActions.Size = new System.Drawing.Size(169, 107);
            this.stdActions.TabIndex = 23;
            // 
            // conflictCheck
            // 
            this.conflictCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.conflictCheck.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.conflictCheck.FlatAppearance.BorderSize = 0;
            this.conflictCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conflictCheck.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conflictCheck.ForeColor = System.Drawing.Color.White;
            this.conflictCheck.Location = new System.Drawing.Point(0, 53);
            this.conflictCheck.Margin = new System.Windows.Forms.Padding(0);
            this.conflictCheck.Name = "conflictCheck";
            this.conflictCheck.Size = new System.Drawing.Size(169, 53);
            this.conflictCheck.TabIndex = 24;
            this.conflictCheck.Text = "Check for Time Conflict";
            this.conflictCheck.UseVisualStyleBackColor = false;
            this.conflictCheck.Visible = false;
            this.conflictCheck.Click += new System.EventHandler(this.conflictCheckClick);
            // 
            // crsHist
            // 
            this.crsHist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.crsHist.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.crsHist.FlatAppearance.BorderSize = 0;
            this.crsHist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crsHist.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crsHist.ForeColor = System.Drawing.Color.White;
            this.crsHist.Location = new System.Drawing.Point(0, 0);
            this.crsHist.Margin = new System.Windows.Forms.Padding(0);
            this.crsHist.Name = "crsHist";
            this.crsHist.Size = new System.Drawing.Size(169, 53);
            this.crsHist.TabIndex = 24;
            this.crsHist.Text = "Course History";
            this.crsHist.UseVisualStyleBackColor = false;
            this.crsHist.Visible = false;
            this.crsHist.Click += new System.EventHandler(this.crsHistClick);
            // 
            // facActions
            // 
            this.facActions.AutoSize = true;
            this.facActions.Controls.Add(this.button1);
            this.facActions.Controls.Add(this.button2);
            this.facActions.Location = new System.Drawing.Point(9, 213);
            this.facActions.Margin = new System.Windows.Forms.Padding(0);
            this.facActions.Name = "facActions";
            this.facActions.Size = new System.Drawing.Size(169, 107);
            this.facActions.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 53);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 53);
            this.button1.TabIndex = 24;
            this.button1.Text = "Check for Time Conflict";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(0, 2);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 53);
            this.button2.TabIndex = 24;
            this.button2.Text = "Course History";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            // 
            // admMainpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(913, 499);
            this.Controls.Add(this.facActions);
            this.Controls.Add(this.stdActions);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dropCrs);
            this.Controls.Add(this.registeredCrsLstLabel);
            this.Controls.Add(this.registeredCrsLst);
            this.Controls.Add(this.stdLstLabel);
            this.Controls.Add(this.stdLst);
            this.Controls.Add(this.crsLstLabel);
            this.Controls.Add(this.addCrs);
            this.Controls.Add(this.crsLst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "admMainpage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "admMainpage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.crsLst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdLst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registeredCrsLst)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.stdActions.ResumeLayout(false);
            this.facActions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView crsLst;
        private System.Windows.Forms.Button stdSelect;
        private System.Windows.Forms.Button facSelect;
        private System.Windows.Forms.Button addCrs;
        private System.Windows.Forms.Label crsLstLabel;
        private System.Windows.Forms.DataGridView stdLst;
        private System.Windows.Forms.Label stdLstLabel;
        private System.Windows.Forms.DataGridView registeredCrsLst;
        private System.Windows.Forms.Label registeredCrsLstLabel;
        private System.Windows.Forms.Button dropCrs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel stdActions;
        private System.Windows.Forms.Button conflictCheck;
        private System.Windows.Forms.Button crsHist;
        private System.Windows.Forms.Panel facActions;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}