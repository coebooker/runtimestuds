namespace CRS
{
    partial class admAdvisees
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
            this.advissesLst = new System.Windows.Forms.DataGridView();
            this.timeConflict = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.advissesLst)).BeginInit();
            this.SuspendLayout();
            // 
            // advissesLst
            // 
            this.advissesLst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advissesLst.Location = new System.Drawing.Point(47, 124);
            this.advissesLst.Name = "advissesLst";
            this.advissesLst.RowHeadersWidth = 62;
            this.advissesLst.RowTemplate.Height = 28;
            this.advissesLst.Size = new System.Drawing.Size(601, 238);
            this.advissesLst.TabIndex = 0;
            // 
            // timeConflict
            // 
            this.timeConflict.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeConflict.Location = new System.Drawing.Point(446, 36);
            this.timeConflict.Name = "timeConflict";
            this.timeConflict.Size = new System.Drawing.Size(293, 58);
            this.timeConflict.TabIndex = 1;
            this.timeConflict.Text = "Check for Time Conflicts";
            this.timeConflict.UseVisualStyleBackColor = true;
            this.timeConflict.Click += new System.EventHandler(this.timeConflictClick);
            // 
            // admAdvisees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.timeConflict);
            this.Controls.Add(this.advissesLst);
            this.Name = "admAdvisees";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advisees";
            ((System.ComponentModel.ISupportInitialize)(this.advissesLst)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView advissesLst;
        private System.Windows.Forms.Button timeConflict;
    }
}