namespace CRS
{
    partial class facMainpage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(facMainpage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.header = new System.Windows.Forms.TableLayoutPanel();
            this.welcome = new System.Windows.Forms.Label();
            this.logout = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.facSchContainer = new System.Windows.Forms.Panel();
            this.facSchHeader = new System.Windows.Forms.Panel();
            this.facSchLabel = new System.Windows.Forms.Label();
            this.facSch = new System.Windows.Forms.DataGridView();
            this.viewEnrolledStds = new System.Windows.Forms.Button();
            this.adviseeLstContainer = new System.Windows.Forms.Panel();
            this.curAdviseeSch = new System.Windows.Forms.Button();
            this.adviseeLstHeader = new System.Windows.Forms.Panel();
            this.adviseeLstLabel = new System.Windows.Forms.Label();
            this.adviseeLst = new System.Windows.Forms.DataGridView();
            this.checkAdviseeSchedule = new System.Windows.Forms.Button();
            this.facActions = new System.Windows.Forms.Panel();
            this.facScrollToTop = new System.Windows.Forms.Button();
            this.facViewCrsLst = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.facViewSch = new System.Windows.Forms.Button();
            this.facViewAdvisees = new System.Windows.Forms.Button();
            this.crsLstContainer = new System.Windows.Forms.Panel();
            this.crsSearch = new System.Windows.Forms.Button();
            this.crsIDBox = new System.Windows.Forms.TextBox();
            this.crsIDLabel = new System.Windows.Forms.Label();
            this.crsLstHeader = new System.Windows.Forms.Panel();
            this.crsLstLabel = new System.Windows.Forms.Label();
            this.crsLst = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.facSchContainer.SuspendLayout();
            this.facSchHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facSch)).BeginInit();
            this.adviseeLstContainer.SuspendLayout();
            this.adviseeLstHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adviseeLst)).BeginInit();
            this.facActions.SuspendLayout();
            this.crsLstContainer.SuspendLayout();
            this.crsLstHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crsLst)).BeginInit();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.header.ColumnCount = 3;
            this.header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.header.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.header.Controls.Add(this.welcome, 0, 0);
            this.header.Controls.Add(this.logout, 2, 0);
            this.header.Location = new System.Drawing.Point(5, 0);
            this.header.Margin = new System.Windows.Forms.Padding(0);
            this.header.Name = "header";
            this.header.RowCount = 1;
            this.header.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.header.Size = new System.Drawing.Size(1888, 100);
            this.header.TabIndex = 24;
            // 
            // welcome
            // 
            this.welcome.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.welcome.AutoSize = true;
            this.welcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome.ForeColor = System.Drawing.Color.White;
            this.welcome.Location = new System.Drawing.Point(3, 31);
            this.welcome.Name = "welcome";
            this.welcome.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.welcome.Size = new System.Drawing.Size(265, 37);
            this.welcome.TabIndex = 6;
            this.welcome.Text = "Welcome back, ";
            // 
            // logout
            // 
            this.logout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.logout.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.logout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout.ForeColor = System.Drawing.Color.White;
            this.logout.Location = new System.Drawing.Point(1634, 0);
            this.logout.Margin = new System.Windows.Forms.Padding(0);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(254, 100);
            this.logout.TabIndex = 5;
            this.logout.Text = "Log Out";
            this.logout.UseVisualStyleBackColor = false;
            this.logout.Click += new System.EventHandler(this.logoutClick);
            // 
            // logo
            // 
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(5, 100);
            this.logo.Margin = new System.Windows.Forms.Padding(0);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(284, 284);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 40;
            this.logo.TabStop = false;
            // 
            // facSchContainer
            // 
            this.facSchContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.facSchContainer.Controls.Add(this.facSchHeader);
            this.facSchContainer.Controls.Add(this.facSch);
            this.facSchContainer.Controls.Add(this.viewEnrolledStds);
            this.facSchContainer.Location = new System.Drawing.Point(320, 370);
            this.facSchContainer.Name = "facSchContainer";
            this.facSchContainer.Size = new System.Drawing.Size(658, 530);
            this.facSchContainer.TabIndex = 48;
            // 
            // facSchHeader
            // 
            this.facSchHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.facSchHeader.Controls.Add(this.facSchLabel);
            this.facSchHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.facSchHeader.Location = new System.Drawing.Point(0, 0);
            this.facSchHeader.Name = "facSchHeader";
            this.facSchHeader.Size = new System.Drawing.Size(656, 61);
            this.facSchHeader.TabIndex = 17;
            // 
            // facSchLabel
            // 
            this.facSchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.facSchLabel.AutoSize = true;
            this.facSchLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facSchLabel.ForeColor = System.Drawing.Color.White;
            this.facSchLabel.Location = new System.Drawing.Point(0, 12);
            this.facSchLabel.Name = "facSchLabel";
            this.facSchLabel.Size = new System.Drawing.Size(263, 33);
            this.facSchLabel.TabIndex = 18;
            this.facSchLabel.Text = "Schedule for SP15";
            // 
            // facSch
            // 
            this.facSch.AllowUserToAddRows = false;
            this.facSch.AllowUserToDeleteRows = false;
            this.facSch.AllowUserToOrderColumns = true;
            this.facSch.AllowUserToResizeColumns = false;
            this.facSch.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            this.facSch.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.facSch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.facSch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.facSch.BackgroundColor = System.Drawing.Color.White;
            this.facSch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.facSch.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.facSch.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.facSch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.facSch.DefaultCellStyle = dataGridViewCellStyle3;
            this.facSch.EnableHeadersVisualStyles = false;
            this.facSch.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.facSch.Location = new System.Drawing.Point(10, 149);
            this.facSch.Margin = new System.Windows.Forms.Padding(0);
            this.facSch.MultiSelect = false;
            this.facSch.Name = "facSch";
            this.facSch.RowHeadersVisible = false;
            this.facSch.RowHeadersWidth = 30;
            this.facSch.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.facSch.RowTemplate.Height = 28;
            this.facSch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.facSch.Size = new System.Drawing.Size(637, 362);
            this.facSch.TabIndex = 26;
            this.facSch.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.facSchCellClick);
            this.facSch.CurrentCellDirtyStateChanged += new System.EventHandler(this.facSchCurrentCellDirtyStateChanged);
            // 
            // viewEnrolledStds
            // 
            this.viewEnrolledStds.AutoSize = true;
            this.viewEnrolledStds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.viewEnrolledStds.Cursor = System.Windows.Forms.Cursors.Hand;
            this.viewEnrolledStds.FlatAppearance.BorderSize = 0;
            this.viewEnrolledStds.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.viewEnrolledStds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewEnrolledStds.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewEnrolledStds.ForeColor = System.Drawing.Color.White;
            this.viewEnrolledStds.Location = new System.Drawing.Point(422, 86);
            this.viewEnrolledStds.Margin = new System.Windows.Forms.Padding(0);
            this.viewEnrolledStds.Name = "viewEnrolledStds";
            this.viewEnrolledStds.Size = new System.Drawing.Size(213, 33);
            this.viewEnrolledStds.TabIndex = 21;
            this.viewEnrolledStds.Text = "Enrolled Students";
            this.viewEnrolledStds.UseVisualStyleBackColor = false;
            this.viewEnrolledStds.Click += new System.EventHandler(this.viewEnrolledStdsClick);
            // 
            // adviseeLstContainer
            // 
            this.adviseeLstContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.adviseeLstContainer.Controls.Add(this.curAdviseeSch);
            this.adviseeLstContainer.Controls.Add(this.adviseeLstHeader);
            this.adviseeLstContainer.Controls.Add(this.adviseeLst);
            this.adviseeLstContainer.Controls.Add(this.checkAdviseeSchedule);
            this.adviseeLstContainer.Location = new System.Drawing.Point(321, 966);
            this.adviseeLstContainer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.adviseeLstContainer.Name = "adviseeLstContainer";
            this.adviseeLstContainer.Size = new System.Drawing.Size(658, 530);
            this.adviseeLstContainer.TabIndex = 49;
            // 
            // curAdviseeSch
            // 
            this.curAdviseeSch.AutoSize = true;
            this.curAdviseeSch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.curAdviseeSch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.curAdviseeSch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.curAdviseeSch.FlatAppearance.BorderSize = 0;
            this.curAdviseeSch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.curAdviseeSch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.curAdviseeSch.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curAdviseeSch.ForeColor = System.Drawing.Color.White;
            this.curAdviseeSch.Location = new System.Drawing.Point(216, 87);
            this.curAdviseeSch.Margin = new System.Windows.Forms.Padding(0);
            this.curAdviseeSch.Name = "curAdviseeSch";
            this.curAdviseeSch.Size = new System.Drawing.Size(182, 42);
            this.curAdviseeSch.TabIndex = 25;
            this.curAdviseeSch.Text = "Current Schedule";
            this.curAdviseeSch.UseVisualStyleBackColor = false;
            this.curAdviseeSch.Click += new System.EventHandler(this.curAdviseeSchClick);
            // 
            // adviseeLstHeader
            // 
            this.adviseeLstHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.adviseeLstHeader.Controls.Add(this.adviseeLstLabel);
            this.adviseeLstHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.adviseeLstHeader.Location = new System.Drawing.Point(0, 0);
            this.adviseeLstHeader.Name = "adviseeLstHeader";
            this.adviseeLstHeader.Size = new System.Drawing.Size(656, 61);
            this.adviseeLstHeader.TabIndex = 21;
            // 
            // adviseeLstLabel
            // 
            this.adviseeLstLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.adviseeLstLabel.AutoSize = true;
            this.adviseeLstLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adviseeLstLabel.ForeColor = System.Drawing.Color.White;
            this.adviseeLstLabel.Location = new System.Drawing.Point(0, 14);
            this.adviseeLstLabel.Name = "adviseeLstLabel";
            this.adviseeLstLabel.Size = new System.Drawing.Size(193, 33);
            this.adviseeLstLabel.TabIndex = 21;
            this.adviseeLstLabel.Text = "Advisees List";
            // 
            // adviseeLst
            // 
            this.adviseeLst.AllowUserToAddRows = false;
            this.adviseeLst.AllowUserToDeleteRows = false;
            this.adviseeLst.AllowUserToOrderColumns = true;
            this.adviseeLst.AllowUserToResizeColumns = false;
            this.adviseeLst.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            this.adviseeLst.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.adviseeLst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adviseeLst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.adviseeLst.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.adviseeLst.BackgroundColor = System.Drawing.Color.White;
            this.adviseeLst.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.adviseeLst.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.adviseeLst.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.adviseeLst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.adviseeLst.DefaultCellStyle = dataGridViewCellStyle6;
            this.adviseeLst.EnableHeadersVisualStyles = false;
            this.adviseeLst.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.adviseeLst.Location = new System.Drawing.Point(10, 150);
            this.adviseeLst.MultiSelect = false;
            this.adviseeLst.Name = "adviseeLst";
            this.adviseeLst.RowHeadersVisible = false;
            this.adviseeLst.RowHeadersWidth = 30;
            this.adviseeLst.RowTemplate.Height = 28;
            this.adviseeLst.Size = new System.Drawing.Size(637, 363);
            this.adviseeLst.TabIndex = 19;
            this.adviseeLst.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.adviseeLstCellClick);
            this.adviseeLst.CurrentCellDirtyStateChanged += new System.EventHandler(this.adviseeLstCurrentCellDirtyStateChanged);
            // 
            // checkAdviseeSchedule
            // 
            this.checkAdviseeSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.checkAdviseeSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkAdviseeSchedule.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.checkAdviseeSchedule.FlatAppearance.BorderSize = 0;
            this.checkAdviseeSchedule.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.checkAdviseeSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkAdviseeSchedule.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAdviseeSchedule.ForeColor = System.Drawing.Color.White;
            this.checkAdviseeSchedule.Location = new System.Drawing.Point(425, 87);
            this.checkAdviseeSchedule.Margin = new System.Windows.Forms.Padding(0);
            this.checkAdviseeSchedule.Name = "checkAdviseeSchedule";
            this.checkAdviseeSchedule.Size = new System.Drawing.Size(182, 42);
            this.checkAdviseeSchedule.TabIndex = 24;
            this.checkAdviseeSchedule.Text = "Check Schedule";
            this.checkAdviseeSchedule.UseVisualStyleBackColor = false;
            this.checkAdviseeSchedule.Click += new System.EventHandler(this.checkAdviseeScheduleClick);
            // 
            // facActions
            // 
            this.facActions.AutoSize = true;
            this.facActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.facActions.Controls.Add(this.facScrollToTop);
            this.facActions.Controls.Add(this.facViewCrsLst);
            this.facActions.Controls.Add(this.label2);
            this.facActions.Controls.Add(this.facViewSch);
            this.facActions.Controls.Add(this.facViewAdvisees);
            this.facActions.Location = new System.Drawing.Point(5, 429);
            this.facActions.Margin = new System.Windows.Forms.Padding(0);
            this.facActions.Name = "facActions";
            this.facActions.Size = new System.Drawing.Size(254, 400);
            this.facActions.TabIndex = 50;
            // 
            // facScrollToTop
            // 
            this.facScrollToTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.facScrollToTop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.facScrollToTop.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.facScrollToTop.FlatAppearance.BorderSize = 0;
            this.facScrollToTop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.facScrollToTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.facScrollToTop.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facScrollToTop.ForeColor = System.Drawing.Color.White;
            this.facScrollToTop.Location = new System.Drawing.Point(0, 320);
            this.facScrollToTop.Margin = new System.Windows.Forms.Padding(0);
            this.facScrollToTop.Name = "facScrollToTop";
            this.facScrollToTop.Size = new System.Drawing.Size(254, 80);
            this.facScrollToTop.TabIndex = 29;
            this.facScrollToTop.Text = "Scroll To Top";
            this.facScrollToTop.UseVisualStyleBackColor = false;
            this.facScrollToTop.Click += new System.EventHandler(this.facScrollToTopClick);
            // 
            // facViewCrsLst
            // 
            this.facViewCrsLst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.facViewCrsLst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.facViewCrsLst.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.facViewCrsLst.FlatAppearance.BorderSize = 0;
            this.facViewCrsLst.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.facViewCrsLst.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.facViewCrsLst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.facViewCrsLst.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facViewCrsLst.ForeColor = System.Drawing.Color.White;
            this.facViewCrsLst.Location = new System.Drawing.Point(0, 80);
            this.facViewCrsLst.Margin = new System.Windows.Forms.Padding(0);
            this.facViewCrsLst.Name = "facViewCrsLst";
            this.facViewCrsLst.Size = new System.Drawing.Size(254, 80);
            this.facViewCrsLst.TabIndex = 28;
            this.facViewCrsLst.Text = "View Course Offering";
            this.facViewCrsLst.UseVisualStyleBackColor = false;
            this.facViewCrsLst.Click += new System.EventHandler(this.facViewCrsLstClick);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 80);
            this.label2.TabIndex = 0;
            this.label2.Text = "Quick Commands";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // facViewSch
            // 
            this.facViewSch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.facViewSch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.facViewSch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.facViewSch.FlatAppearance.BorderSize = 0;
            this.facViewSch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.facViewSch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.facViewSch.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facViewSch.ForeColor = System.Drawing.Color.White;
            this.facViewSch.Location = new System.Drawing.Point(0, 160);
            this.facViewSch.Margin = new System.Windows.Forms.Padding(0);
            this.facViewSch.Name = "facViewSch";
            this.facViewSch.Size = new System.Drawing.Size(254, 80);
            this.facViewSch.TabIndex = 15;
            this.facViewSch.Text = "View Schedule";
            this.facViewSch.UseVisualStyleBackColor = false;
            this.facViewSch.Click += new System.EventHandler(this.facViewSchClick);
            // 
            // facViewAdvisees
            // 
            this.facViewAdvisees.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.facViewAdvisees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.facViewAdvisees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.facViewAdvisees.FlatAppearance.BorderSize = 0;
            this.facViewAdvisees.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.facViewAdvisees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.facViewAdvisees.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facViewAdvisees.ForeColor = System.Drawing.Color.White;
            this.facViewAdvisees.Location = new System.Drawing.Point(0, 240);
            this.facViewAdvisees.Margin = new System.Windows.Forms.Padding(0);
            this.facViewAdvisees.Name = "facViewAdvisees";
            this.facViewAdvisees.Size = new System.Drawing.Size(254, 80);
            this.facViewAdvisees.TabIndex = 21;
            this.facViewAdvisees.Text = "View Advisees";
            this.facViewAdvisees.UseVisualStyleBackColor = false;
            this.facViewAdvisees.Click += new System.EventHandler(this.facViewAdviseesClick);
            // 
            // crsLstContainer
            // 
            this.crsLstContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crsLstContainer.Controls.Add(this.crsSearch);
            this.crsLstContainer.Controls.Add(this.crsIDBox);
            this.crsLstContainer.Controls.Add(this.crsIDLabel);
            this.crsLstContainer.Controls.Add(this.crsLstHeader);
            this.crsLstContainer.Controls.Add(this.crsLst);
            this.crsLstContainer.Location = new System.Drawing.Point(1028, 370);
            this.crsLstContainer.Name = "crsLstContainer";
            this.crsLstContainer.Size = new System.Drawing.Size(821, 1126);
            this.crsLstContainer.TabIndex = 51;
            // 
            // crsSearch
            // 
            this.crsSearch.AutoSize = true;
            this.crsSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.crsSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.crsSearch.FlatAppearance.BorderSize = 0;
            this.crsSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.crsSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.crsSearch.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crsSearch.ForeColor = System.Drawing.Color.White;
            this.crsSearch.Location = new System.Drawing.Point(17, 129);
            this.crsSearch.Margin = new System.Windows.Forms.Padding(0);
            this.crsSearch.Name = "crsSearch";
            this.crsSearch.Size = new System.Drawing.Size(152, 42);
            this.crsSearch.TabIndex = 20;
            this.crsSearch.Text = "Search";
            this.crsSearch.UseVisualStyleBackColor = false;
            this.crsSearch.Click += new System.EventHandler(this.crsSearchClick);
            // 
            // crsIDBox
            // 
            this.crsIDBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.crsIDBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.crsIDBox.BackColor = System.Drawing.Color.White;
            this.crsIDBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crsIDBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.crsIDBox.Location = new System.Drawing.Point(196, 73);
            this.crsIDBox.Margin = new System.Windows.Forms.Padding(0);
            this.crsIDBox.Name = "crsIDBox";
            this.crsIDBox.Size = new System.Drawing.Size(283, 30);
            this.crsIDBox.TabIndex = 19;
            // 
            // crsIDLabel
            // 
            this.crsIDLabel.AutoSize = true;
            this.crsIDLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crsIDLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.crsIDLabel.Location = new System.Drawing.Point(16, 77);
            this.crsIDLabel.Name = "crsIDLabel";
            this.crsIDLabel.Size = new System.Drawing.Size(140, 29);
            this.crsIDLabel.TabIndex = 18;
            this.crsIDLabel.Text = "Course ID :";
            // 
            // crsLstHeader
            // 
            this.crsLstHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.crsLstHeader.Controls.Add(this.crsLstLabel);
            this.crsLstHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.crsLstHeader.Location = new System.Drawing.Point(0, 0);
            this.crsLstHeader.Name = "crsLstHeader";
            this.crsLstHeader.Size = new System.Drawing.Size(819, 60);
            this.crsLstHeader.TabIndex = 17;
            // 
            // crsLstLabel
            // 
            this.crsLstLabel.AutoSize = true;
            this.crsLstLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crsLstLabel.ForeColor = System.Drawing.Color.White;
            this.crsLstLabel.Location = new System.Drawing.Point(3, 12);
            this.crsLstLabel.Name = "crsLstLabel";
            this.crsLstLabel.Size = new System.Drawing.Size(290, 33);
            this.crsLstLabel.TabIndex = 16;
            this.crsLstLabel.Text = "Course List for SP15";
            // 
            // crsLst
            // 
            this.crsLst.AllowUserToAddRows = false;
            this.crsLst.AllowUserToDeleteRows = false;
            this.crsLst.AllowUserToResizeColumns = false;
            this.crsLst.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            this.crsLst.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.crsLst.BackgroundColor = System.Drawing.Color.White;
            this.crsLst.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.crsLst.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.crsLst.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.crsLst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.crsLst.DefaultCellStyle = dataGridViewCellStyle9;
            this.crsLst.EnableHeadersVisualStyles = false;
            this.crsLst.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.crsLst.Location = new System.Drawing.Point(12, 209);
            this.crsLst.Margin = new System.Windows.Forms.Padding(0);
            this.crsLst.Name = "crsLst";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.crsLst.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.crsLst.RowHeadersVisible = false;
            this.crsLst.RowHeadersWidth = 30;
            this.crsLst.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.crsLst.RowTemplate.Height = 28;
            this.crsLst.Size = new System.Drawing.Size(795, 872);
            this.crsLst.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.label1.Location = new System.Drawing.Point(5, 1600);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1742, 100);
            this.label1.TabIndex = 52;
            // 
            // facMainpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1924, 1049);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.crsLstContainer);
            this.Controls.Add(this.facActions);
            this.Controls.Add(this.adviseeLstContainer);
            this.Controls.Add(this.facSchContainer);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "facMainpage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faculty Mainpage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.facSchContainer.ResumeLayout(false);
            this.facSchContainer.PerformLayout();
            this.facSchHeader.ResumeLayout(false);
            this.facSchHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facSch)).EndInit();
            this.adviseeLstContainer.ResumeLayout(false);
            this.adviseeLstContainer.PerformLayout();
            this.adviseeLstHeader.ResumeLayout(false);
            this.adviseeLstHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adviseeLst)).EndInit();
            this.facActions.ResumeLayout(false);
            this.crsLstContainer.ResumeLayout(false);
            this.crsLstContainer.PerformLayout();
            this.crsLstHeader.ResumeLayout(false);
            this.crsLstHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crsLst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel header;
        private System.Windows.Forms.Label welcome;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Panel facSchContainer;
        private System.Windows.Forms.Panel facSchHeader;
        private System.Windows.Forms.Label facSchLabel;
        private System.Windows.Forms.DataGridView facSch;
        private System.Windows.Forms.Button viewEnrolledStds;
        private System.Windows.Forms.Panel adviseeLstContainer;
        private System.Windows.Forms.Button curAdviseeSch;
        private System.Windows.Forms.Panel adviseeLstHeader;
        private System.Windows.Forms.Label adviseeLstLabel;
        private System.Windows.Forms.DataGridView adviseeLst;
        private System.Windows.Forms.Button checkAdviseeSchedule;
        private System.Windows.Forms.Panel facActions;
        private System.Windows.Forms.Button facScrollToTop;
        private System.Windows.Forms.Button facViewCrsLst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button facViewSch;
        private System.Windows.Forms.Button facViewAdvisees;
        private System.Windows.Forms.Panel crsLstContainer;
        private System.Windows.Forms.Button crsSearch;
        private System.Windows.Forms.TextBox crsIDBox;
        private System.Windows.Forms.Label crsIDLabel;
        private System.Windows.Forms.Panel crsLstHeader;
        private System.Windows.Forms.Label crsLstLabel;
        private System.Windows.Forms.DataGridView crsLst;
        private System.Windows.Forms.Label label1;
    }
}