using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Billing
{
    public partial class TransactionHistory : Form
    {
        internal TransactionHistory(Controllers.Billing cBilling)
        {
            InitializeComponent();

            this.cBilling = cBilling;
        }

        private Controllers.Billing cBilling;
        private Models.Program program;
        private Models.Batch batch;
        private List<Models.Student> students = new List<Models.Student>();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cBilling.Close();
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
            students = Models.Student.Find("", program.ID, batch.ID);
            dgvStudents.Rows.Clear();
            foreach (Models.Student student in students)
            {
                string studentname = "";
                studentname = student.LastName + ", " + student.FirstName + " " + student.MiddleName;
                dgvStudents.Rows.Add(student.ID, student.Number, studentname, student.Tuition.ToString("N"), Models.Transaction.GetBalance(student.ID).ToString("N"));
            }
        }

        private void btnEditTuition_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells[0].Value);
                UpdateTuition ut = new UpdateTuition();
                ut.student = students.Find(s => s.ID == id);
                ut.ShowDialog();
                LoadStudents();
            }
        }

        Bitmap image;
        private void btnPrintGrp_Click(object sender, EventArgs e)
        {
            psPrint = false;
            dgvStudents.ClearSelection();
            int height = dgvStudents.Height;
            dgvStudents.Height = dgvStudents.RowCount * dgvStudents.RowTemplate.Height + dgvStudents.Columns[0].HeaderCell.Size.Height;
            dgvStudents.ScrollBars = ScrollBars.None;
            image = new Bitmap(dgvStudents.Width, dgvStudents.Height);
            dgvStudents.DrawToBitmap(image, new Rectangle(0, 0, dgvStudents.Width, dgvStudents.Height));
            dgvStudents.Height = height;
            dgvStudents.ScrollBars = ScrollBars.Vertical;
            printPreviewDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.Bicubic;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            if (psPrint)
            {
                if (psIndex < images.Count)
                {
                    Bitmap bitmap = new Bitmap(images[0].Width * 3, images[0].Height);

                    for (int i = 0; i < 3; i++)
                    {
                        if (psIndex == images.Count) break;
                        Graphics g = Graphics.FromImage(bitmap);
                        g.DrawImage(images[psIndex], i * images[0].Width, 0);
                        psIndex++;
                    }
                    e.Graphics.DrawImage(bitmap, 30, 50);
                    if (psIndex == images.Count)
                    {
                        e.HasMorePages = false;
                        psIndex = 0;
                    }
                    else
                    {
                        e.HasMorePages = true;
                    }
                }
            }
            else
            {
                e.Graphics.DrawImage(image, 30, 50);
            }
        }


        List<Bitmap> images = new List<Bitmap>();
        bool psPrint = false;
        int psIndex = 0;
        
        private void btnPrintIndividual_Click(object sender, EventArgs e)
        {
            images.Clear();
            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) > 0)
                {
                    Print.StatementOfAccount statement = new Print.StatementOfAccount();
                    int id = Convert.ToInt32(row.Cells[0].Value);
                    Models.Student student = students.Find(s => s.ID == id);
                    Models.Batch batch = Models.Batch.GetByID(student.BatchID);
                    Models.Program program = Models.Program.getByID(batch.ProgramID);
                    statement.lblDate.Text = DateTime.Today.ToShortDateString();
                    statement.lblStudentNumber.Text = student.Number;
                    statement.lblStudentName.Text = student.GetFullName();
                    statement.lblStudentProgram.Text = program.Title + " b." + batch.Number.ToString();
                    statement.lblTuitionFee.Text = student.Tuition.ToString("N");
                    List<Models.Transaction> trans = Models.Transaction.getTransactionsByStudent(student.ID);
                    foreach (Models.Transaction tr in trans)
                    {
                        statement.lblPayments.Text += tr.DateTime.ToShortDateString() + " " + tr.Amount.ToString("N") + Environment.NewLine;
                    }
                    statement.lblBalance.Text = Models.Transaction.GetBalance(student.ID).ToString("N");
                    statement.Show();
                    image = new Bitmap(statement.Width, statement.Height);
                    statement.DrawToBitmap(image, new Rectangle(0, 0, statement.Width, statement.Height));
                    statement.Close();
                    images.Add(image);
                }
            }
            psPrint = true;
            printDocument.DefaultPageSettings.Landscape = true;
            printPreviewDialog.ShowDialog();
        }
    }
}
