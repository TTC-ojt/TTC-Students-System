using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Maintenance
{
    public partial class ProgramProfile : Form
    {
        internal ProgramProfile(Controllers.Maintenance cMaintenance)
        {
            InitializeComponent();
            this.cMaintenance = cMaintenance;
        }

        private Controllers.Maintenance cMaintenance;

       List<Models.Program> programs = new List<Models.Program>();
       Models.Program program = new Models.Program();
        private Bitmap img;

        private void loadProgramProfile()
        {
            programs = Models.Program.getAll();
            dgvProgramTitle.Rows.Clear();
            int c = 1;
            foreach(Models.Program program in programs)
            {
                string duration = "";
                if(program.OneYear) duration = "One Year";
                if(program.ShortCourse) duration = "Short Course";
                dgvProgramTitle.Rows.Add(program.ID, c, program.Copr, program.Title, duration, program.Tuition);
                c++;
            }
            dgvProgramTitle.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            program.OneYear = rbtnOneYear.Checked;
            program.ShortCourse = rbtnShortCourse.Checked;
            program.Title = txtProgramTitle.Text;
            program.Industry = txtIndustrySector.Text;
            program.Status = txtTVETRegStatus.Text;
            program.Copr = txtCOPR.Text;
            program.Calendar = txtTrainingCalendarCode.Text;
            program.Delivery = txtDelivery.Text;
            program.Tuition = nudTuition.Value;
            program.Hours = Convert.ToInt16(nudNumberOfHours.Value);
            program.Save();
            loadProgramProfile();
        }

        private void ProgramProfile_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgvProgramTitle.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            loadProgramProfile();
        }

        private void dgvProgramTitle_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvProgramTitle.SelectedRows.Count>0)
            {
                int id = Convert.ToInt32(dgvProgramTitle.SelectedRows[0].Cells[0].Value);
                program = programs.Find(p => p.ID == id);
            }
            else
            {
                program = new Models.Program();
            }
            rbtnOneYear.Checked = program.OneYear;
            rbtnShortCourse.Checked = program.ShortCourse;
            txtProgramTitle.Text = program.Title;
            nudNumberOfHours.Value = program.Hours;
            txtIndustrySector.Text = program.Industry;
            txtTVETRegStatus.Text = program.Status;
            txtCOPR.Text = program.Copr;
            txtTrainingCalendarCode.Text = program.Calendar;
            txtDelivery.Text = program.Delivery;
            nudTuition.Value = program.Tuition;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cMaintenance.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            dgvProgramTitle.ClearSelection();
            int height = dgvProgramTitle.Height;
            dgvProgramTitle.Height = dgvProgramTitle.RowCount * dgvProgramTitle.RowTemplate.Height + dgvProgramTitle.Columns[0].HeaderCell.Size.Height;
            dgvProgramTitle.ScrollBars = ScrollBars.None;
            img = new Bitmap(dgvProgramTitle.Width, dgvProgramTitle.Height);
            dgvProgramTitle.DrawToBitmap(img, new Rectangle(0, 0, dgvProgramTitle.Width, dgvProgramTitle.Height));
            dgvProgramTitle.Height = height;
            dgvProgramTitle.ScrollBars = ScrollBars.Vertical;
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
