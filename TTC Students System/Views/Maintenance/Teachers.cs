using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Maintenance
{
    public partial class Teachers : Form
    {
        internal Teachers(Controllers.Maintenance cMaintenance)
        {
            InitializeComponent();
            this.cMaintenance = cMaintenance;
        }

        private Controllers.Maintenance cMaintenance;
        
        List<Models.Teacher> teachers = new List<Models.Teacher>();
        Models.Teacher teacher = new Models.Teacher();
        private Bitmap img;

        internal void loadAllTeachers()
        {
            teachers = Models.Teacher.getAll();
            dgvTeachers.Rows.Clear();
            foreach(Models.Teacher teacher in teachers)
            {
                dgvTeachers.Rows.Add(teacher.ID, teacher.Code, teacher.Name);
            }
            dgvTeachers.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            teacher.Code = txtCode.Text;
            teacher.Name = txtName.Text;
            teacher.Save();
            loadAllTeachers();
        }

        private void Teachers_Load(object sender, EventArgs e)
        {
            loadAllTeachers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cMaintenance.Close();
        }

        private void dgvTeachers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvTeachers.SelectedRows[0].Cells[0].Value);
                teacher = teachers.Find(t => t.ID == id);
            }
            else
            {
                teacher = new Models.Teacher();
            }
            txtCode.Text = teacher.Code;
            txtName.Text = teacher.Name;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            dgvTeachers.ClearSelection();
            int height = dgvTeachers.Height;
            dgvTeachers.Height = dgvTeachers.RowCount * dgvTeachers.RowTemplate.Height + dgvTeachers.Columns[0].HeaderCell.Size.Height;
            dgvTeachers.ScrollBars = ScrollBars.None;
            img = new Bitmap(dgvTeachers.Width, dgvTeachers.Height);
            dgvTeachers.DrawToBitmap(img, new Rectangle(0, 0, dgvTeachers.Width, dgvTeachers.Height));
            dgvTeachers.Height = height;
            dgvTeachers.ScrollBars = ScrollBars.Vertical;
            printDocument.DefaultPageSettings.Landscape = true;
            printPreviewDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.Bicubic;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.DrawImage(img, e.PageBounds.Width / 2 - img.Width / 2, 50);
        }
    }
}
