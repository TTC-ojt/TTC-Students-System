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
    public partial class Grades : Form
    {
        internal Grades(Controllers.Records cRecords)
        {
            InitializeComponent();
            this.cRecords = cRecords;
        }

        private Models.Program program;
        private Models.Batch batch;
        private List<Models.Student> students = new List<Models.Student>();
        private List<Models.Subject> subjects = new List<Models.Subject>();

        private Controllers.Records cRecords;
        private Bitmap img;

        internal bool FromStudentsList = false;
        internal Controllers.StudentsList cStudentsList;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            if (FromStudentsList)
            {
                cStudentsList.ShowListOfStudents();
                return;
            }
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
            LoadSubjects();
            LoadBatches();
        }

        internal void LoadProgramAndBatch(Models.Program program, Models.Batch batch)
        {
            this.program = program;
            txtCopr.Text = program.Copr;
            txtProgramTitle.Text = program.Title;
            LoadSubjects();
            LoadBatches();
            cbxBatch.SelectedIndex = cbxBatch.FindStringExact(batch.Number.ToString());
            LoadStudents();
        }

        private void LoadSubjects()
        {
            subjects = Models.Subject.getAllByProgram(program.ID);
            if (dgvGrades.Columns.Count > 3)
            {
                int cols = dgvGrades.Columns.Count;
                for (int i = 3; i < cols; i++)
                {
                    dgvGrades.Columns.RemoveAt(3);
                }
            }
            foreach (Models.Subject subject in subjects)
            {
                var dgcSubject = new DataGridViewTextBoxColumn();
                dgcSubject.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgcSubject.FillWeight = 7;
                dgcSubject.Name = "dgc" + subject.Code;
                dgcSubject.HeaderText = subject.Code;
                dgcSubject.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgvGrades.Columns.AddRange(new DataGridViewColumn[] { dgcSubject });
            }
            var dgc = new DataGridViewTextBoxColumn();
            dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgc.FillWeight = 15;
            dgc.Name = "dgcRemarks";
            dgc.HeaderText = "Remarks";
            dgvGrades.Columns.AddRange(new DataGridViewColumn[] { dgc });
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
            dgvGrades.Rows.Clear();
            int c = 1;
            foreach (Models.Student student in students)
            {
                string[] grades = new string[subjects.Count + 4];
                grades[0] = student.ID.ToString();
                grades[1] = c.ToString();
                grades[2] = student.GetFullName();
                int i = 3;
                decimal sum = 0m;
                int count = 0;
                foreach (Models.Subject subject in subjects)
                {
                    grades[i] = Models.Grade.getBySubjectAndStudent(subject.ID, student.ID).Score;
                    if (!string.IsNullOrWhiteSpace(grades[i]) && grades[i].All(char.IsDigit))
                    {
                        sum += Convert.ToDecimal(grades[i]);
                        count += 1;
                    }
                    i++;
                }
                if (count > 0) grades[i] = (sum / count).ToString("N");
                else grades[i] = 0m.ToString("N");
                dgvGrades.Rows.Add(grades);
                c++;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvGrades.Rows)
            {
                int student_id = Convert.ToInt32(row.Cells[0].Value);
                foreach (Models.Subject subject in subjects)
                {
                    string score = row.Cells["dgc" + subject.Code].Value.ToString();
                    Models.Grade grade = Models.Grade.getBySubjectAndStudent(subject.ID, student_id);
                    grade.StudentID = student_id;
                    grade.SubjectID = subject.ID;
                    grade.Score = score;
                    grade.Save();
                }
            }
        }

        private void dgvGrades_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvGrades.Rows[e.RowIndex];
            decimal sum = 0m;
            int count = 0;
            foreach (Models.Subject subject in subjects)
            {
                string grade = Convert.ToString(row.Cells["dgc" + subject.Code].Value);
                if (!string.IsNullOrWhiteSpace(grade) && grade.All(char.IsDigit))
                {
                    sum += Convert.ToDecimal(grade);
                    count += 1;
                }
            }
            if (count > 0) row.Cells["dgcRemarks"].Value = (sum / count).ToString("N");
            else row.Cells["Remarks"].Value = 0m.ToString("N");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            dgvGrades.ClearSelection();
            int height = dgvGrades.Height;
            dgvGrades.Height = dgvGrades.RowCount * dgvGrades.RowTemplate.Height + dgvGrades.Columns[0].HeaderCell.Size.Height;
            dgvGrades.ScrollBars = ScrollBars.None;
            img = new Bitmap(dgvGrades.Width, dgvGrades.Height);
            dgvGrades.DrawToBitmap(img, new Rectangle(0, 0, dgvGrades.Width, dgvGrades.Height));
            dgvGrades.Height = height;
            dgvGrades.ScrollBars = ScrollBars.Vertical;
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

        private void Grades_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgvGrades.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
