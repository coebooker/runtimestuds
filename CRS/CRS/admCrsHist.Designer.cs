namespace CRS
{
    partial class admCrsHist
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
            this.crsHist = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.crsHist)).BeginInit();
            this.SuspendLayout();
            // 
            // crsHist
            // 
            this.crsHist.BackgroundColor = System.Drawing.Color.White;
            this.crsHist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.crsHist.Location = new System.Drawing.Point(12, 123);
            this.crsHist.Name = "crsHist";
            this.crsHist.RowHeadersWidth = 62;
            this.crsHist.RowTemplate.Height = 28;
            this.crsHist.Size = new System.Drawing.Size(776, 150);
            this.crsHist.TabIndex = 0;
            // 
            // admCrsHist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crsHist);
            this.Name = "admCrsHist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "admCrsHist";
            ((System.ComponentModel.ISupportInitialize)(this.crsHist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView crsHist;
    }
}