using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Maintenance
{
    public partial class TuitionFee : Form
    {
        internal TuitionFee(Controllers.Maintenance cMaintenance)
        {
            InitializeComponent();
            this.cMaintenance = cMaintenance;
        }
        private Controllers.Maintenance cMaintenance;

        private Models.Program program;
        List<Models.Program> programs = new List<Models.Program>();
        Models.Fee fee = new Models.Fee();
        private Bitmap img;

        private void loadPrograms()
        {
            programs = Models.Program.getAll();
            dgvProgramFees.Rows.Clear();
            foreach(Models.Program program in programs)
            {
                dgvProgramFees.Rows.Add(program.ID, program.Title, program.GetFullTuition());
            }
            dgvProgramFees.ClearSelection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cMaintenance.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            fee.Assessment = nudAssessment.Value;
            fee.ID_Card = nudID.Value;
            fee.Insurance = nudInsurance.Value;
            fee.TShirt = nudTShirt.Value;
            fee.Special = nudSpecialOrder.Value;
            fee.Save();
            loadPrograms();
        }

        private void TuitionFee_Load(object sender, EventArgs e)
        {
            loadPrograms();
        }

        private void dgvSchoolFees_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvProgramFees.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvProgramFees.SelectedRows[0].Cells[0].Value);
                program = programs.Find(p => p.ID == id);
                fee = Models.Fee.getByProgram(id);
            }
            else
            {
                program = new Models.Program();
                fee = new Models.Fee();
            }
            txtCopr.Text = program.Copr;
            txtProgramTitle.Text = program.Title;
            nudTuitionFee.Value = program.Tuition;
            nudMiscellaneous.Value = fee.Assessment + fee.ID_Card + fee.Insurance + fee.TShirt + fee.Special;
            nudAssessment.Value = fee.Assessment;
            nudID.Value = fee.ID_Card;
            nudInsurance.Value = fee.Insurance;
            nudTShirt.Value = fee.TShirt;
            nudSpecialOrder.Value = fee.Special;
            nudTotal.Value = nudTuitionFee.Value + nudMiscellaneous.Value;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            dgvProgramFees.ClearSelection();
            int height = dgvProgramFees.Height;
            dgvProgramFees.Height = dgvProgramFees.RowCount * dgvProgramFees.RowTemplate.Height + dgvProgramFees.Columns[0].HeaderCell.Size.Height;
            dgvProgramFees.ScrollBars = ScrollBars.None;
            img = new Bitmap(dgvProgramFees.Width, dgvProgramFees.Height);
            dgvProgramFees.DrawToBitmap(img, new Rectangle(0, 0, dgvProgramFees.Width, dgvProgramFees.Height));
            dgvProgramFees.Height = height;
            dgvProgramFees.ScrollBars = ScrollBars.Vertical;
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
