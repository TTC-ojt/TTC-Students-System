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
    public partial class Documents : Form
    {
        internal Documents(Controllers.Records cRecords)
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
                Models.Document document = Models.Document.getByStudent(student.ID);
                if (rbtnComplete.Checked && document.IsComplete())
                {
                    dgvChecklist.Rows.Add(student.ID, student.GetFullName(), document.C137, document.C138, document.GoodMoral, document.BirthCert, document.Pictures, document.Diploma, document.BrgyClearance, document.Envelope, document.Remarks);
                }
                else if (rbtnIncomplete.Checked && !document.IsComplete())
                {
                    dgvChecklist.Rows.Add(student.ID, student.GetFullName(), document.C137, document.C138, document.GoodMoral, document.BirthCert, document.Pictures, document.Diploma, document.BrgyClearance, document.Envelope, document.Remarks);
                }
                else if (rbtnALL.Checked)
                {
                    dgvChecklist.Rows.Add(student.ID, student.GetFullName(), document.C137, document.C138, document.GoodMoral, document.BirthCert, document.Pictures, document.Diploma, document.BrgyClearance, document.Envelope, document.Remarks);
                }
            }
        }

        private void Filter(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvChecklist.Rows)
            {
                int id = Convert.ToInt32(row.Cells[0].Value);
                Models.Document document = Models.Document.getByStudent(id);
                document.C137 = Convert.ToBoolean(row.Cells["dgc137"].Value);
                document.C138 = Convert.ToBoolean(row.Cells["dgc138"].Value);
                document.GoodMoral = Convert.ToBoolean(row.Cells["dgcGoodMoral"].Value);
                document.BirthCert = Convert.ToBoolean(row.Cells["dgcBirthCert"].Value);
                document.Pictures = Convert.ToBoolean(row.Cells["dgcPictures"].Value);
                document.Diploma = Convert.ToBoolean(row.Cells["dgcDiploma"].Value);
                document.BrgyClearance = Convert.ToBoolean(row.Cells["dgcClearance"].Value);
                document.Envelope = Convert.ToBoolean(row.Cells["dgcEnvelope"].Value);
                document.Remarks = row.Cells["dgcRemarks"].Value.ToString();
                document.Save();
            }
            LoadStudents();
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
            e.Graphics.DrawImage(img, 0,50);
        }
    }
}
