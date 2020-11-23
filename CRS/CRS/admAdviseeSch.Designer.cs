namespace CRS
{
    partial class admAdviseeSch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lst = new System.Windows.Forms.DataGridView();
            this.checkAdviseeSchedule = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lst)).BeginInit();
            this.SuspendLayout();
            // 
            // lst
            // 
            this.lst.AllowUserToAddRows = false;
            this.lst.AllowUserToDeleteRows = false;
            this.lst.AllowUserToResizeColumns = false;
            this.lst.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            this.lst.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.lst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.lst.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.lst.BackgroundColor = System.Drawing.Color.White;
            this.lst.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lst.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.lst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lst.DefaultCellStyle = dataGridViewCellStyle6;
            this.lst.EnableHeadersVisualStyles = false;
            this.lst.Location = new System.Drawing.Point(59, 64);
            this.lst.Margin = new System.Windows.Forms.Padding(0);
            this.lst.MultiSelect = false;
            this.lst.Name = "lst";
            this.lst.ReadOnly = true;
            this.lst.RowHeadersVisible = false;
            this.lst.RowHeadersWidth = 62;
            this.lst.RowTemplate.Height = 28;
            this.lst.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lst.Size = new System.Drawing.Size(683, 266);
            this.lst.TabIndex = 1;
            // 
            // checkAdviseeSchedule
            // 
            this.checkAdviseeSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.checkAdviseeSchedule.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.checkAdviseeSchedule.FlatAppearance.BorderSize = 0;
            this.checkAdviseeSchedule.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(165)))), ((int)(((byte)(142)))));
            this.checkAdviseeSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkAdviseeSchedule.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAdviseeSchedule.ForeColor = System.Drawing.Color.White;
            this.checkAdviseeSchedule.Location = new System.Drawing.Point(271, 358);
            this.checkAdviseeSchedule.Margin = new System.Windows.Forms.Padding(0);
            this.checkAdviseeSchedule.Name = "checkAdviseeSchedule";
            this.checkAdviseeSchedule.Size = new System.Drawing.Size(259, 42);
            this.checkAdviseeSchedule.TabIndex = 25;
            this.checkAdviseeSchedule.Text = "Check for Time Conflicts";
            this.checkAdviseeSchedule.UseVisualStyleBackColor = false;
            this.checkAdviseeSchedule.Click += new System.EventHandler(this.butClick);
            // 
            // admAdviseeSch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkAdviseeSchedule);
            this.Controls.Add(this.lst);
            this.Name = "admAdviseeSch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "admAdviseeSch";
            ((System.ComponentModel.ISupportInitialize)(this.lst)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView lst;
        private System.Windows.Forms.Button checkAdviseeSchedule;
    }
}