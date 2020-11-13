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
            this.adviseeLst = new System.Windows.Forms.DataGridView();
            this.checkAdviseeSchedule = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.adviseeLst)).BeginInit();
            this.SuspendLayout();
            // 
            // adviseeLst
            // 
            this.adviseeLst.BackgroundColor = System.Drawing.Color.White;
            this.adviseeLst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adviseeLst.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.adviseeLst.Location = new System.Drawing.Point(75, 108);
            this.adviseeLst.Name = "adviseeLst";
            this.adviseeLst.RowHeadersWidth = 62;
            this.adviseeLst.RowTemplate.Height = 28;
            this.adviseeLst.Size = new System.Drawing.Size(607, 150);
            this.adviseeLst.TabIndex = 0;
            // 
            // checkAdviseeSchedule
            // 
            this.checkAdviseeSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.checkAdviseeSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAdviseeSchedule.ForeColor = System.Drawing.Color.White;
            this.checkAdviseeSchedule.Location = new System.Drawing.Point(186, 322);
            this.checkAdviseeSchedule.Margin = new System.Windows.Forms.Padding(0);
            this.checkAdviseeSchedule.Name = "checkAdviseeSchedule";
            this.checkAdviseeSchedule.Size = new System.Drawing.Size(358, 58);
            this.checkAdviseeSchedule.TabIndex = 1;
            this.checkAdviseeSchedule.Text = "Check Advisee Schedule";
            this.checkAdviseeSchedule.UseVisualStyleBackColor = false;
            this.checkAdviseeSchedule.Click += new System.EventHandler(this.checkAdviseeScheduleClick);
            // 
            // admAdvisees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkAdviseeSchedule);
            this.Controls.Add(this.adviseeLst);
            this.Name = "admAdvisees";
            this.Text = "Advisees";
            ((System.ComponentModel.ISupportInitialize)(this.adviseeLst)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView adviseeLst;
        private System.Windows.Forms.Button checkAdviseeSchedule;
    }
}