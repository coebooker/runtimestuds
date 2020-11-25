namespace CRS
{
    partial class admChangeAdvisor
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
            this.facDropDown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currentAdvisor = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // facLst
            // 
            this.facDropDown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.facDropDown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.facDropDown.FormattingEnabled = true;
            this.facDropDown.Location = new System.Drawing.Point(302, 160);
            this.facDropDown.Name = "facLst";
            this.facDropDown.Size = new System.Drawing.Size(121, 28);
            this.facDropDown.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Advisor :";
            // 
            // curAdv
            // 
            this.currentAdvisor.AutoSize = true;
            this.currentAdvisor.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentAdvisor.Location = new System.Drawing.Point(99, 100);
            this.currentAdvisor.Name = "curAdv";
            this.currentAdvisor.Size = new System.Drawing.Size(178, 24);
            this.currentAdvisor.TabIndex = 2;
            this.currentAdvisor.Text = "Current Advisor : ";
            // 
            // confirm
            // 
            this.confirm.AutoSize = true;
            this.confirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(49)))), ((int)(((byte)(63)))));
            this.confirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirm.FlatAppearance.BorderSize = 0;
            this.confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirm.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm.ForeColor = System.Drawing.Color.White;
            this.confirm.Location = new System.Drawing.Point(199, 262);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(124, 35);
            this.confirm.TabIndex = 3;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.confirmClick);
            // 
            // admChangeAdvisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(522, 354);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.currentAdvisor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.facDropDown);
            this.Name = "admChangeAdvisor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Advisor Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox facDropDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentAdvisor;
        private System.Windows.Forms.Button confirm;
    }
}