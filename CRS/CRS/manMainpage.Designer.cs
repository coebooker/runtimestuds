namespace CRS
{
    partial class manMainpage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.stdSelect = new System.Windows.Forms.Button();
            this.manSelect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.crsLst = new System.Windows.Forms.DataGridView();
            this.stdActions = new System.Windows.Forms.Panel();
            this.conflictCheck = new System.Windows.Forms.Button();
            this.crsHist = new System.Windows.Forms.Button();
            this.crsLstLabel = new System.Windows.Forms.Label();
            this.addCrs = new System.Windows.Forms.Button();
            this.stdLstLabel = new System.Windows.Forms.Label();
            this.stdLst = new System.Windows.Forms.DataGridView();
            this.registeredCrsLstLabel = new System.Windows.Forms.Label();
            this.registeredCrsLst = new System.Windows.Forms.DataGridView();
            this.dropCrs = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crsLst)).BeginInit();
            this.stdActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stdLst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registeredCrsLst)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.stdSelect, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.manSelect, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1638, 47);
            this.tableLayoutPanel1.TabIndex = 23;
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
            this.stdSelect.Size = new System.Drawing.Size(204, 47);
            this.stdSelect.TabIndex = 1;
            this.stdSelect.Text = "Student";
            this.stdSelect.UseVisualStyleBackColor = false;
            // 
            // manSelect
            // 
            this.manSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.manSelect.FlatAppearance.BorderSize = 0;
            this.manSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manSelect.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manSelect.ForeColor = System.Drawing.Color.White;
            this.manSelect.Location = new System.Drawing.Point(408, 0);
            this.manSelect.Margin = new System.Windows.Forms.Padding(0);
            this.manSelect.Name = "manSelect";
            this.manSelect.Size = new System.Drawing.Size(204, 47);
            this.manSelect.TabIndex = 3;
            this.manSelect.Text = "Manager";
            this.manSelect.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(204, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 47);
            this.button1.TabIndex = 4;
            this.button1.Text = "Faculty";
            this.button1.UseVisualStyleBackColor = false;
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
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.crsLst.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.crsLst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.crsLst.EnableHeadersVisualStyles = false;
            this.crsLst.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.crsLst.Location = new System.Drawing.Point(333, 180);
            this.crsLst.Margin = new System.Windows.Forms.Padding(0);
            this.crsLst.MultiSelect = false;
            this.crsLst.Name = "crsLst";
            this.crsLst.ReadOnly = true;
            this.crsLst.RowHeadersWidth = 30;
            this.crsLst.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.crsLst.RowTemplate.Height = 28;
            this.crsLst.Size = new System.Drawing.Size(704, 482);
            this.crsLst.TabIndex = 24;
            // 
            // stdActions
            // 
            this.stdActions.AutoSize = true;
            this.stdActions.Controls.Add(this.conflictCheck);
            this.stdActions.Controls.Add(this.crsHist);
            this.stdActions.Location = new System.Drawing.Point(0, 138);
            this.stdActions.Margin = new System.Windows.Forms.Padding(0);
            this.stdActions.Name = "stdActions";
            this.stdActions.Size = new System.Drawing.Size(254, 160);
            this.stdActions.TabIndex = 25;
            // 
            // conflictCheck
            // 
            this.conflictCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.conflictCheck.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.conflictCheck.FlatAppearance.BorderSize = 0;
            this.conflictCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conflictCheck.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conflictCheck.ForeColor = System.Drawing.Color.White;
            this.conflictCheck.Location = new System.Drawing.Point(0, 80);
            this.conflictCheck.Margin = new System.Windows.Forms.Padding(0);
            this.conflictCheck.Name = "conflictCheck";
            this.conflictCheck.Size = new System.Drawing.Size(254, 80);
            this.conflictCheck.TabIndex = 24;
            this.conflictCheck.Text = "Check for Time Conflict";
            this.conflictCheck.UseVisualStyleBackColor = false;
            this.conflictCheck.Visible = false;
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
            this.crsHist.Size = new System.Drawing.Size(254, 80);
            this.crsHist.TabIndex = 24;
            this.crsHist.Text = "Course History";
            this.crsHist.UseVisualStyleBackColor = false;
            this.crsHist.Visible = false;
            // 
            // crsLstLabel
            // 
            this.crsLstLabel.AutoSize = true;
            this.crsLstLabel.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crsLstLabel.Location = new System.Drawing.Point(337, 138);
            this.crsLstLabel.Name = "crsLstLabel";
            this.crsLstLabel.Size = new System.Drawing.Size(268, 30);
            this.crsLstLabel.TabIndex = 26;
            this.crsLstLabel.Text = "Course List for SP15";
            // 
            // addCrs
            // 
            this.addCrs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addCrs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.addCrs.FlatAppearance.BorderSize = 0;
            this.addCrs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCrs.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCrs.ForeColor = System.Drawing.Color.White;
            this.addCrs.Location = new System.Drawing.Point(783, 679);
            this.addCrs.Margin = new System.Windows.Forms.Padding(0);
            this.addCrs.Name = "addCrs";
            this.addCrs.Size = new System.Drawing.Size(254, 50);
            this.addCrs.TabIndex = 27;
            this.addCrs.Text = "Add Course";
            this.addCrs.UseVisualStyleBackColor = false;
            this.addCrs.Visible = false;
            // 
            // stdLstLabel
            // 
            this.stdLstLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stdLstLabel.AutoSize = true;
            this.stdLstLabel.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stdLstLabel.Location = new System.Drawing.Point(1086, 138);
            this.stdLstLabel.Name = "stdLstLabel";
            this.stdLstLabel.Size = new System.Drawing.Size(178, 30);
            this.stdLstLabel.TabIndex = 28;
            this.stdLstLabel.Text = "Students List";
            this.stdLstLabel.Visible = false;
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
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stdLst.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.stdLst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stdLst.EnableHeadersVisualStyles = false;
            this.stdLst.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.stdLst.Location = new System.Drawing.Point(1082, 180);
            this.stdLst.Margin = new System.Windows.Forms.Padding(0);
            this.stdLst.MultiSelect = false;
            this.stdLst.Name = "stdLst";
            this.stdLst.ReadOnly = true;
            this.stdLst.RowHeadersWidth = 30;
            this.stdLst.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.stdLst.RowTemplate.Height = 28;
            this.stdLst.Size = new System.Drawing.Size(502, 220);
            this.stdLst.TabIndex = 29;
            this.stdLst.Visible = false;
            // 
            // registeredCrsLstLabel
            // 
            this.registeredCrsLstLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.registeredCrsLstLabel.AutoSize = true;
            this.registeredCrsLstLabel.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registeredCrsLstLabel.Location = new System.Drawing.Point(1086, 462);
            this.registeredCrsLstLabel.Name = "registeredCrsLstLabel";
            this.registeredCrsLstLabel.Size = new System.Drawing.Size(198, 30);
            this.registeredCrsLstLabel.TabIndex = 30;
            this.registeredCrsLstLabel.Text = "Schedule SP15";
            this.registeredCrsLstLabel.Visible = false;
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
            this.registeredCrsLst.Location = new System.Drawing.Point(1082, 509);
            this.registeredCrsLst.Name = "registeredCrsLst";
            this.registeredCrsLst.RowHeadersWidth = 30;
            this.registeredCrsLst.RowTemplate.Height = 28;
            this.registeredCrsLst.Size = new System.Drawing.Size(502, 220);
            this.registeredCrsLst.TabIndex = 31;
            this.registeredCrsLst.Visible = false;
            // 
            // dropCrs
            // 
            this.dropCrs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dropCrs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.dropCrs.FlatAppearance.BorderSize = 0;
            this.dropCrs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropCrs.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropCrs.ForeColor = System.Drawing.Color.White;
            this.dropCrs.Location = new System.Drawing.Point(1330, 451);
            this.dropCrs.Margin = new System.Windows.Forms.Padding(0);
            this.dropCrs.Name = "dropCrs";
            this.dropCrs.Size = new System.Drawing.Size(254, 50);
            this.dropCrs.TabIndex = 32;
            this.dropCrs.Text = "Drop Course";
            this.dropCrs.UseVisualStyleBackColor = false;
            this.dropCrs.Visible = false;
            // 
            // manMainpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1616, 796);
            this.Controls.Add(this.dropCrs);
            this.Controls.Add(this.registeredCrsLst);
            this.Controls.Add(this.registeredCrsLstLabel);
            this.Controls.Add(this.stdLst);
            this.Controls.Add(this.stdLstLabel);
            this.Controls.Add(this.addCrs);
            this.Controls.Add(this.crsLstLabel);
            this.Controls.Add(this.stdActions);
            this.Controls.Add(this.crsLst);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "manMainpage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "manMainpage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.crsLst)).EndInit();
            this.stdActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stdLst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registeredCrsLst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button stdSelect;
        private System.Windows.Forms.Button manSelect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView crsLst;
        private System.Windows.Forms.Panel stdActions;
        private System.Windows.Forms.Button conflictCheck;
        private System.Windows.Forms.Button crsHist;
        private System.Windows.Forms.Label crsLstLabel;
        private System.Windows.Forms.Button addCrs;
        private System.Windows.Forms.Label stdLstLabel;
        private System.Windows.Forms.DataGridView stdLst;
        private System.Windows.Forms.Label registeredCrsLstLabel;
        private System.Windows.Forms.DataGridView registeredCrsLst;
        private System.Windows.Forms.Button dropCrs;
    }
}