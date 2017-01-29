using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Status
{
    public partial class ListOfStudents : Form
    {
        internal ListOfStudents(Controllers.StudentsList cStudentsList)
        {
            InitializeComponent();
            this.cStudentsList = cStudentsList;
        }

        private Controllers.StudentsList cStudentsList;
        
        private Models.Batch batch = new Models.Batch();
        private Models.Program program = new Models.Program();
        private List<Models.Student> students = new List<Models.Student>();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cStudentsList.Close();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            if (cStudentsList.mStudent.ID > 0)
            cStudentsList.ShowStudentsProfile();
        }

        private void btnAssessment_Click(object sender, EventArgs e)
        {
            if (cStudentsList.mStudent.ID > 0)
                cStudentsList.ShowAssessmentAndCert();
        }

        private void btnEmployment_Click(object sender, EventArgs e)
        {
            if (cStudentsList.mStudent.ID > 0)
                cStudentsList.ShowEmploymentStatus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            students = Models.Student.Find(txtSearch.Text, program.ID, batch.ID);
            dgvStudentsLists.Rows.Clear();
            foreach (Models.Student student in students)
            {
                Models.Batch batch = Models.Batch.GetByID(student.BatchID);
                Models.Program program = Models.Program.getByID(batch.ProgramID);
                dgvStudentsLists.Rows.Add(student.ID, student.Number, student.GetFullName(), program.ShortName + " " + batch.Number);
            }
        }

        private void dgvStudentsLists_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudentsLists.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvStudentsLists.SelectedRows[0].Cells[0].Value);
                cStudentsList.mStudent = students.Find(s => s.ID == id);
            }
            else
            {
                cStudentsList.mStudent = new Models.Student();
            }
        }

        private void btnChangeCourse_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
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

        Bitmap img;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            dgvStudentsLists.ClearSelection();
            int height = dgvStudentsLists.Height;
            dgvStudentsLists.Height = dgvStudentsLists.RowCount * dgvStudentsLists.RowTemplate.Height + dgvStudentsLists.Columns[0].HeaderCell.Size.Height;
            dgvStudentsLists.ScrollBars = ScrollBars.None;
            img = new Bitmap(dgvStudentsLists.Width, dgvStudentsLists.Height);
            dgvStudentsLists.DrawToBitmap(img, new Rectangle(0, 0, dgvStudentsLists.Width, dgvStudentsLists.Height));
            dgvStudentsLists.Height = height;
            dgvStudentsLists.ScrollBars = ScrollBars.Vertical;
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.TextLength > 2)
            {
                LoadStudents();
            }
            else
            {
                dgvStudentsLists.Rows.Clear();
            }
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            if (program.ID == 0)
            {
                if (cStudentsList.mStudent.ID > 0)
                {
                    batch = Models.Batch.GetByID(cStudentsList.mStudent.BatchID);
                    program = Models.Program.getByID(batch.ProgramID);
                }
                else
                {
                    return;
                }
            }
            Records.Grades vGrades = new Records.Grades(cStudentsList.cMain.StartRecords());
            vGrades.LoadProgramAndBatch(program, batch);
            vGrades.Show();
            if (vGrades.Visible)
            {
                this.Close();
            }
        }
    }
}
