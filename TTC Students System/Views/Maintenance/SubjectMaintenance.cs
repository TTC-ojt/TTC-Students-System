using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Maintenance
{
    public partial class SubjectMaintenance : Form
    {
        internal SubjectMaintenance(Controllers.Maintenance cMaintenance)
        {
            InitializeComponent();
            this.cMaintenance = cMaintenance;
        }

        private Controllers.Maintenance cMaintenance;

        private Models.Program program;
        List<Models.Subject> subjects = new List<Models.Subject>();
        Models.Subject subject = new Models.Subject();
        private Bitmap img;

        private void loadSubjects()
        {
            subjects = Models.Subject.getAllByProgram(program.ID);
            dgvSubjects.Rows.Clear();
            int c = 1;
            foreach(Models.Subject subject in subjects)
            {
                Models.Program program = Models.Program.getByID(subject.ProgramID);
                subject.ProgramID = program.ID;
                dgvSubjects.Rows.Add(subject.ID, c, subject.Code, subject.Title, subject.Hours);
                c++;
            }
            dgvSubjects.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            subject.ProgramID = program.ID;
            if (rbtnInSchool.Checked) subject.Type = rbtnInSchool.Text;
            if (rbtnInPlant.Checked) subject.Type = rbtnInPlant.Text;
            subject.Code = txtSubjectCode.Text;
            subject.Title = txtTitle.Text;
            subject.Description = txtDescription.Text;
            subject.Hours = Convert.ToInt16(nudNumberOfHours.Value);
            subject.Save();
            loadSubjects();
        }

        private void btnChangeCourse_Click(object sender, EventArgs e)
        {
            ChooseProgram cp = new ChooseProgram();
            cp.ShowDialog();
            ChangeProgram(cp.program);
            loadSubjects();
        }

        private void ChangeProgram(Models.Program program)
        {
            this.program = program;
            txtCopr.Text = program.Copr;
            txtProgramTitle.Text = program.Title;
        }

        private void dgvSubjects_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvSubjects.SelectedRows.Count>0)
            {
                int id = Convert.ToInt32(dgvSubjects.SelectedRows[0].Cells[0].Value);
                subject = subjects.Find(p => p.ID == id);
            }
            else
            {
                subject = new Models.Subject();
            }
            rbtnInSchool.Checked = subject.Type == "In School";
            rbtnInPlant.Checked = subject.Type == "In Plant";
            txtSubjectCode.Text = subject.Code;
            txtTitle.Text = subject.Title;
            txtDescription.Text = subject.Description;
            nudNumberOfHours.Value = subject.Hours;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cMaintenance.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            dgvSubjects.ClearSelection();
            int height = dgvSubjects.Height;
            dgvSubjects.Height = dgvSubjects.RowCount * dgvSubjects.RowTemplate.Height + dgvSubjects.Columns[0].HeaderCell.Size.Height;
            dgvSubjects.ScrollBars = ScrollBars.None;
            img = new Bitmap(dgvSubjects.Width, dgvSubjects.Height);
            dgvSubjects.DrawToBitmap(img, new Rectangle(0, 0, dgvSubjects.Width, dgvSubjects.Height));
            dgvSubjects.Height = height;
            dgvSubjects.ScrollBars = ScrollBars.Vertical;
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

        private void SubjectMaintenance_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgvSubjects.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
