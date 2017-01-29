using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Records
{
    public partial class Insurances : Form
    {
        internal Insurances(Controllers.Records cRecords)
        {
            InitializeComponent();
            this.cRecords = cRecords;
        }

        private Controllers.Records cRecords;

        private Models.Program program = new Models.Program();
        private Models.Batch batch = new Models.Batch();
        private List<Models.Student> students = new List<Models.Student>();
        private Bitmap img;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cRecords.Close();
        }

        private void btnChangeCourse_Click(object sender, EventArgs e)
        {
            ChooseProgram vCProgram = new ChooseProgram();
            vCProgram.ShowDialog();
            program = vCProgram.program;
            if (program != null) LoadProgram();
        }

        private void LoadProgram()
        {
            txtCopr.Text = program.Copr;
            txtProgramTitle.Text = program.Title;
            LoadBatches();
        }
        private void LoadBatches()
        {
            List<Models.Batch> batches = Models.Batch.GetAllByProgram(program.ID);
            cbxBatch.Items.Clear();
            foreach (Models.Batch batch in batches)
            {
                cbxBatch.Items.Add(batch.Number);
            }
            cbxBatch.SelectedIndex = cbxBatch.Items.Count - 1;
        }
        private void cbxBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            short Number = Convert.ToInt16(cbxBatch.SelectedItem);
            batch = Models.Batch.GetByProgramAndNumber(program.ID, Number);
            LoadStudents();
        }

        private void LoadStudents()
        {
            students = Models.Student.getByBatch(batch.ID);
            dgvChecklist.Rows.Clear();
            foreach (Models.Student student in students)
            {
                Models.Insurance insurance = Models.Insurance.getByStudent(student.ID);
                dgvChecklist.Rows.Add(student.ID, student.GetFullName(), insurance.Beneficiary, insurance.Relationship, insurance.Amount.ToString("N"));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvChecklist.Rows)
            {
                int id = Convert.ToInt32(row.Cells[0].Value);
                Models.Insurance insurance = Models.Insurance.getByStudent(id);
                insurance.Company = txtCompany.Text;
                insurance.Beneficiary = row.Cells["dgcBeneficiary"].Value.ToString();
                insurance.Relationship = row.Cells["dgcRelationship"].Value.ToString();
                insurance.Amount = nudAmount.Value;
                insurance.Save();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            dgvChecklist.ClearSelection();
            int height = dgvChecklist.Height;
            dgvChecklist.Height = dgvChecklist.RowCount * dgvChecklist.RowTemplate.Height + dgvChecklist.Columns[0].HeaderCell.Size.Height;
            dgvChecklist.ScrollBars = ScrollBars.None;
            img = new Bitmap(dgvChecklist.Width, dgvChecklist.Height);
            dgvChecklist.DrawToBitmap(img, new Rectangle(0, 0, dgvChecklist.Width, dgvChecklist.Height));
            dgvChecklist.Height = height;
            dgvChecklist.ScrollBars = ScrollBars.Vertical;
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
