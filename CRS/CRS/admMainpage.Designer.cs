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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.checkAdviseeSchedule = new System.Windows.Forms.Button();
            this.showAdvisees = new System.Windows.Forms.Button();
            this.facLstLabel = new System.Windows.Forms.Label();
            this.facLst = new System.Windows.Forms.DataGridView();
            this.facSch = new System.Windows.Forms.DataGridView();
            this.showEnrolledStd = new System.Windows.Forms.Button();
            this.crrSch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.crsLst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stdLst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registeredCrsLst)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.stdActions.SuspendLayout();
            this.facActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facLst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facSch)).BeginInit();
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
            this.crsLst.Size = new System.Drawing.Size(704, 505);
            this.crsLst.TabIndex = 13;
            // 
            // stdSelect
            // 
            this.stdSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.stdSelect.FlatAppearance.BorderSize = 0;
            this.stdSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.stdSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stdSelect.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stdSelect.ForeColor = System.Drawing.Color.White;
            this.stdSelect.Location = new System.Drawing.Point(0, 0);
            this.stdSelect.Margin = new System.Windows.Forms.Padding(0);
            this.stdSelect.Name = "stdSelect";
            this.stdSelect.Size = new System.Drawing.Size(204, 46);
            this.stdSelect.TabIndex = 1;
            this.stdSelect.Text = "Student";
            this.stdSelect.UseVisualStyleBackColor = false;
            this.stdSelect.Click += new System.EventHandler(this.stdSelectClick);
            // 
            // facSelect
            // 
            this.facSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.facSelect.FlatAppearance.BorderSize = 0;
            this.facSelect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.facSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.facSelect.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facSelect.ForeColor = System.Drawing.Color.White;
            this.facSelect.Location = new System.Drawing.Point(204, 0);
            this.facSelect.Margin = new System.Windows.Forms.Padding(0);
            this.facSelect.Name = "facSelect";
            this.facSelect.Size = new System.Drawing.Size(204, 46);
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
            this.addCrs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.addCrs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCrs.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCrs.ForeColor = System.Drawing.Color.White;
            this.addCrs.Location = new System.Drawing.Point(783, 699);
            this.addCrs.Margin = new System.Windows.Forms.Padding(0);
            this.addCrs.Name = "addCrs";
            this.addCrs.Size = new System.Drawing.Size(254, 50);
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
            this.crsLstLabel.Location = new System.Drawing.Point(338, 138);
            this.crsLstLabel.Name = "crsLstLabel";
            this.crsLstLabel.Size = new System.Drawing.Size(268, 30);
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
            this.stdLst.Size = new System.Drawing.Size(502, 249);
            this.stdLst.TabIndex = 17;
            this.stdLst.Visible = false;
            this.stdLst.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.rowSelected);
            // 
            // stdLstLabel
            // 
            this.stdLstLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stdLstLabel.AutoSize = true;
            this.stdLstLabel.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stdLstLabel.Location = new System.Drawing.Point(1086, 138);
            this.stdLstLabel.Name = "stdLstLabel";
            this.stdLstLabel.Size = new System.Drawing.Size(178, 30);
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
            this.registeredCrsLst.Location = new System.Drawing.Point(1082, 529);
            this.registeredCrsLst.Name = "registeredCrsLst";
            this.registeredCrsLst.RowHeadersWidth = 30;
            this.registeredCrsLst.RowTemplate.Height = 28;
            this.registeredCrsLst.Size = new System.Drawing.Size(502, 220);
            this.registeredCrsLst.TabIndex = 19;
            this.registeredCrsLst.Visible = false;
            // 
            // registeredCrsLstLabel
            // 
            this.registeredCrsLstLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.registeredCrsLstLabel.AutoSize = true;
            this.registeredCrsLstLabel.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registeredCrsLstLabel.Location = new System.Drawing.Point(1086, 489);
            this.registeredCrsLstLabel.Name = "registeredCrsLstLabel";
            this.registeredCrsLstLabel.Size = new System.Drawing.Size(198, 30);
            this.registeredCrsLstLabel.TabIndex = 20;
            this.registeredCrsLstLabel.Text = "Schedule SP15";
            this.registeredCrsLstLabel.Visible = false;
            // 
            // dropCrs
            // 
            this.dropCrs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dropCrs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.dropCrs.FlatAppearance.BorderSize = 0;
            this.dropCrs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.dropCrs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dropCrs.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropCrs.ForeColor = System.Drawing.Color.White;
            this.dropCrs.Location = new System.Drawing.Point(1330, 475);
            this.dropCrs.Margin = new System.Windows.Forms.Padding(0);
            this.dropCrs.Name = "dropCrs";
            this.dropCrs.Size = new System.Drawing.Size(254, 50);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.stdSelect, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.facSelect, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1638, 46);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // stdActions
            // 
            this.stdActions.AutoSize = true;
            this.stdActions.Controls.Add(this.crrSch);
            this.stdActions.Controls.Add(this.crsHist);
            this.stdActions.Controls.Add(this.conflictCheck);
            this.stdActions.Location = new System.Drawing.Point(0, 270);
            this.stdActions.Margin = new System.Windows.Forms.Padding(0);
            this.stdActions.Name = "stdActions";
            this.stdActions.Size = new System.Drawing.Size(254, 240);
            this.stdActions.TabIndex = 23;
            // 
            // conflictCheck
            // 
            this.conflictCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.conflictCheck.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.conflictCheck.FlatAppearance.BorderSize = 0;
            this.conflictCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.conflictCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conflictCheck.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conflictCheck.ForeColor = System.Drawing.Color.White;
            this.conflictCheck.Location = new System.Drawing.Point(0, 79);
            this.conflictCheck.Margin = new System.Windows.Forms.Padding(0);
            this.conflictCheck.Name = "conflictCheck";
            this.conflictCheck.Size = new System.Drawing.Size(254, 80);
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
            this.crsHist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
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
            this.crsHist.Click += new System.EventHandler(this.crsHistClick);
            // 
            // facActions
            // 
            this.facActions.AutoSize = true;
            this.facActions.Controls.Add(this.checkAdviseeSchedule);
            this.facActions.Location = new System.Drawing.Point(47, 574);
            this.facActions.Margin = new System.Windows.Forms.Padding(0);
            this.facActions.Name = "facActions";
            this.facActions.Size = new System.Drawing.Size(254, 80);
            this.facActions.TabIndex = 24;
            this.facActions.Visible = false;
            // 
            // checkAdviseeSchedule
            // 
            this.checkAdviseeSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.checkAdviseeSchedule.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.checkAdviseeSchedule.FlatAppearance.BorderSize = 0;
            this.checkAdviseeSchedule.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.checkAdviseeSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkAdviseeSchedule.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAdviseeSchedule.ForeColor = System.Drawing.Color.White;
            this.checkAdviseeSchedule.Location = new System.Drawing.Point(0, 0);
            this.checkAdviseeSchedule.Margin = new System.Windows.Forms.Padding(0);
            this.checkAdviseeSchedule.Name = "checkAdviseeSchedule";
            this.checkAdviseeSchedule.Size = new System.Drawing.Size(254, 80);
            this.checkAdviseeSchedule.TabIndex = 24;
            this.checkAdviseeSchedule.Text = "Check Advisee Schedule";
            this.checkAdviseeSchedule.UseVisualStyleBackColor = false;
            this.checkAdviseeSchedule.Visible = false;
            this.checkAdviseeSchedule.Click += new System.EventHandler(this.checkAdviseeScheduleClick);
            // 
            // showAdvisees
            // 
            this.showAdvisees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.showAdvisees.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.showAdvisees.FlatAppearance.BorderSize = 0;
            this.showAdvisees.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.showAdvisees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showAdvisees.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showAdvisees.ForeColor = System.Drawing.Color.White;
            this.showAdvisees.Location = new System.Drawing.Point(1330, 127);
            this.showAdvisees.Margin = new System.Windows.Forms.Padding(0);
            this.showAdvisees.Name = "showAdvisees";
            this.showAdvisees.Size = new System.Drawing.Size(254, 50);
            this.showAdvisees.TabIndex = 24;
            this.showAdvisees.Text = "Show Advisees";
            this.showAdvisees.UseVisualStyleBackColor = false;
            this.showAdvisees.Visible = false;
            this.showAdvisees.Click += new System.EventHandler(this.showAdviseesClick);
            // 
            // facLstLabel
            // 
            this.facLstLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.facLstLabel.AutoSize = true;
            this.facLstLabel.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facLstLabel.Location = new System.Drawing.Point(1086, 138);
            this.facLstLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.facLstLabel.Name = "facLstLabel";
            this.facLstLabel.Size = new System.Drawing.Size(180, 30);
            this.facLstLabel.TabIndex = 25;
            this.facLstLabel.Text = "Faculties List";
            this.facLstLabel.Visible = false;
            // 
            // facLst
            // 
            this.facLst.AllowUserToAddRows = false;
            this.facLst.AllowUserToDeleteRows = false;
            this.facLst.AllowUserToOrderColumns = true;
            this.facLst.AllowUserToResizeColumns = false;
            this.facLst.AllowUserToResizeRows = false;
            this.facLst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.facLst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.facLst.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.facLst.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.facLst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.facLst.EnableHeadersVisualStyles = false;
            this.facLst.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.facLst.Location = new System.Drawing.Point(1082, 180);
            this.facLst.Margin = new System.Windows.Forms.Padding(0);
            this.facLst.MultiSelect = false;
            this.facLst.Name = "facLst";
            this.facLst.ReadOnly = true;
            this.facLst.RowHeadersWidth = 30;
            this.facLst.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.facLst.RowTemplate.Height = 28;
            this.facLst.Size = new System.Drawing.Size(502, 249);
            this.facLst.TabIndex = 26;
            this.facLst.Visible = false;
            this.facLst.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.facSelected);
            // 
            // facSch
            // 
            this.facSch.AllowUserToAddRows = false;
            this.facSch.AllowUserToDeleteRows = false;
            this.facSch.AllowUserToOrderColumns = true;
            this.facSch.AllowUserToResizeColumns = false;
            this.facSch.AllowUserToResizeRows = false;
            this.facSch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.facSch.BackgroundColor = System.Drawing.Color.White;
            this.facSch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.facSch.EnableHeadersVisualStyles = false;
            this.facSch.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.facSch.Location = new System.Drawing.Point(1082, 529);
            this.facSch.Margin = new System.Windows.Forms.Padding(4);
            this.facSch.Name = "facSch";
            this.facSch.RowHeadersWidth = 30;
            this.facSch.RowTemplate.Height = 28;
            this.facSch.Size = new System.Drawing.Size(502, 220);
            this.facSch.TabIndex = 27;
            this.facSch.Visible = false;
            // 
            // showEnrolledStd
            // 
            this.showEnrolledStd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.showEnrolledStd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.showEnrolledStd.FlatAppearance.BorderSize = 0;
            this.showEnrolledStd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showEnrolledStd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showEnrolledStd.ForeColor = System.Drawing.Color.White;
            this.showEnrolledStd.Location = new System.Drawing.Point(1995, 429);
            this.showEnrolledStd.Margin = new System.Windows.Forms.Padding(0);
            this.showEnrolledStd.Name = "showEnrolledStd";
            this.showEnrolledStd.Size = new System.Drawing.Size(381, 75);
            this.showEnrolledStd.TabIndex = 28;
            this.showEnrolledStd.Text = "View Students";
            this.showEnrolledStd.UseVisualStyleBackColor = false;
            this.showEnrolledStd.Visible = false;
            this.showEnrolledStd.Click += new System.EventHandler(this.showEnrolledStdClick);
            // 
            // crrSch
            // 
            this.crrSch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.crrSch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.crrSch.FlatAppearance.BorderSize = 0;
            this.crrSch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.crrSch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crrSch.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crrSch.ForeColor = System.Drawing.Color.White;
            this.crrSch.Location = new System.Drawing.Point(0, 159);
            this.crrSch.Margin = new System.Windows.Forms.Padding(0);
            this.crrSch.Name = "crrSch";
            this.crrSch.Size = new System.Drawing.Size(254, 80);
            this.crrSch.TabIndex = 25;
            this.crrSch.Text = "Current Schedule";
            this.crrSch.UseVisualStyleBackColor = false;
            this.crrSch.Visible = false;
            this.crrSch.Click += new System.EventHandler(this.crrSchClick);
            // 
            // admMainpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 803);
            this.Controls.Add(this.showEnrolledStd);
            this.Controls.Add(this.showAdvisees);
            this.Controls.Add(this.facSch);
            this.Controls.Add(this.facLst);
            this.Controls.Add(this.facLstLabel);
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
            ((System.ComponentModel.ISupportInitialize)(this.facLst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facSch)).EndInit();
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
        private System.Windows.Forms.Button checkAdviseeSchedule;
        private System.Windows.Forms.Button showAdvisees;
        private System.Windows.Forms.Label facLstLabel;
        private System.Windows.Forms.DataGridView facLst;
        private System.Windows.Forms.DataGridView facSch;
        private System.Windows.Forms.Button showEnrolledStd;
        private System.Windows.Forms.Button crrSch;
    }
}