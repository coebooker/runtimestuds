﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRS
{
    public partial class admAdviseeSch : Form
    {
        student std;
        public admAdviseeSch(student std)
        {
            InitializeComponent();

            DataTable table = new DataTable();
            table.Columns.Add("Course ID");
            table.Columns.Add("Title");
            table.Columns.Add("Instructor");
            table.Columns.Add("Credits");
            table.Columns.Add("Schedule");

            foreach (course crs in std.registeredCrs)
                table.Rows.Add(crs.crsID, crs.title, crs.instructor, crs.credit, crs.getBlocks());

            adviseeSch.DataSource = table;
            this.std = std;

            adviseeSch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            adviseeSch.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            int width = adviseeSch.Columns["Schedule"].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            adviseeSch.Columns["Schedule"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            adviseeSch.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            adviseeSch.Columns["Schedule"].Width = width;
        }

        private void butClick(object sender, EventArgs e)
        {
            MessageBox.Show(std.timeCheck(), "Conflict Check", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
