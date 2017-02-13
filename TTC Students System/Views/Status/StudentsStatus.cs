using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace GN.TTC.Students.Views.Status
{
    public partial class StudentsStatus : Form
    {
        internal StudentsStatus(Controllers.StudentsStatus cStudentsStatus)
        {
            InitializeComponent();
            this.cStudentsStatus = cStudentsStatus;
        }

        private Controllers.StudentsStatus cStudentsStatus;

        private Models.Program program = new Models.Program();
        private Models.Batch batch = new Models.Batch();
        private List<Models.Student> students = new List<Models.Student>();
        private Bitmap img;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cStudentsStatus.Close();
        }

        private void LoadStudents()
        {
            if (rbtnAll.Checked) rbtnAll_CheckedChanged(null, null);
            if (rbtnDropped.Checked) rbtnDropped_CheckedChanged(null, null);
            if (rbtnFloaters.Checked) rbtnFloaters_CheckedChanged(null, null);
            if (rbtnGraduate.Checked) rbtnGraduate_CheckedChanged(null, null);
            if (rbtnInplant.Checked) rbtnInplant_CheckedChanged(null, null);
            if (rbtnInschool.Checked) rbtnInschool_CheckedChanged(null, null);
            if (rbtnStopped.Checked) rbtnStopped_CheckedChanged(null, null);
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

        private void btnGraduate_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells[0].Value);
                UpdateGraduate ug = new UpdateGraduate();
                ug.student = Models.Student.getByID(id);
                ug.ShowDialog();
            }
            rbtnGraduate.Checked = true;
        }

        private void btnFloaters_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStudents.SelectedRows)
            {
                int id = Convert.ToInt32(row.Cells[0].Value);
                Models.Student student = students.Find(s => s.ID == id);
                student.Status = "FLOATER";
                student.Save();
            }
            rbtnFloaters.Checked = true;
        }

        private void btnDropped_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells[0].Value);
                UpdateDropped ud = new UpdateDropped();
                ud.student = Models.Student.getByID(id);
                ud.ShowDialog();
            }
            rbtnDropped.Checked = true;
        }

        private void btnStopped_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells[0].Value);
                UpdateStopped us = new UpdateStopped();
                us.student = Models.Student.getByID(id);
                us.ShowDialog();
            }
            rbtnStopped.Checked = true;
        }

        private void btnInplant_Click(object sender, EventArgs e)
        {
            cStudentsStatus.cMain.StartPayroll().ShowInPlants();
            this.Close();
        }

        private void btnInSchool_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStudents.SelectedRows)
            {
                int id = Convert.ToInt32(row.Cells[0].Value);
                Models.Student student = students.Find(s => s.ID == id);
                student.Status = "IN-SCHOOL";
                student.Save();
            }
            LoadStudents();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.TextLength > 2)
            {
                LoadStudents();
            }
            else
            {
                dgvStudents.Rows.Clear();
            }
        }

        private void rbtnInschool_CheckedChanged(object sender, EventArgs e)
        {
            resetColumns();
            students = Models.Student.FindWithStatus(txtSearch.Text, program.ID, batch.ID, rbtnInschool.Text);
            dgvStudents.Rows.Clear();
            int c = 1;
            foreach (Models.Student student in students)
            {
                Models.Batch batch = Models.Batch.GetByID(student.BatchID);
                Models.Program program = Models.Program.getByID(batch.ProgramID);
                dgvStudents.Rows.Add(student.ID, c, student.GetFullName(), program.Title, batch.Number);
                c++;
            }
        }

        private void rbtnFloaters_CheckedChanged(object sender, EventArgs e)
        {
            resetColumns();
            students = Models.Student.FindWithStatus(txtSearch.Text, program.ID, batch.ID, rbtnFloaters.Text);
            dgvStudents.Rows.Clear();
            int c = 1;
            foreach (Models.Student student in students)
            {
                Models.Batch batch = Models.Batch.GetByID(student.BatchID);
                Models.Program program = Models.Program.getByID(batch.ProgramID);
                dgvStudents.Rows.Add(student.ID, c, student.GetFullName(), program.Title, batch.Number);
                c++;
            }
        }

        private void rbtnInplant_CheckedChanged(object sender, EventArgs e)
        {
            resetColumns();
            var dgc = new DataGridViewTextBoxColumn();
            dgc.Name = "dgcCompany";
            dgc.HeaderText = "Company";
            dgvStudents.Columns.Add(dgc);
            students = Models.Student.FindWithStatus(txtSearch.Text, program.ID, batch.ID, rbtnInplant.Text);
            dgvStudents.Rows.Clear();
            int c = 1;
            foreach (Models.Student student in students)
            {
                Models.InPlant inplant = Models.InPlant.getByStudent(student.ID);
                Models.Company company = Models.Company.getbyCompanyId(inplant.CompanyID);
                Models.Batch batch = Models.Batch.GetByID(student.BatchID);
                Models.Program program = Models.Program.getByID(batch.ProgramID);
                dgvStudents.Rows.Add(student.ID, c, student.GetFullName(), program.Title, batch.Number, company.Name);
                c++;
            }
        }

        private void rbtnGraduate_CheckedChanged(object sender, EventArgs e)
        {
            resetColumns();
            var dgc = new DataGridViewTextBoxColumn();
            dgc.Name = "dgcSO";
            dgc.HeaderText = "SO #";
            dgvStudents.Columns.Add(dgc);
            var dgc2 = new DataGridViewTextBoxColumn();
            dgc2.Name = "dgcIssued";
            dgc2.HeaderText = "SO #";
            dgvStudents.Columns.Add(dgc2);
            students = Models.Student.FindWithStatus(txtSearch.Text, program.ID, batch.ID, rbtnGraduate.Text);
            dgvStudents.Rows.Clear();
            int c = 1;
            foreach (Models.Student student in students)
            {
                Models.Batch batch = Models.Batch.GetByID(student.BatchID);
                Models.Program program = Models.Program.getByID(batch.ProgramID);
                Models.Graduate graduate = Models.Graduate.getByStudent(student.ID);
                dgvStudents.Rows.Add(student.ID, c, student.GetFullName(), program.Title, batch.Number, graduate.SpecialOrder, graduate.DateIssued.ToShortDateString());
                c++;
            }
        }

        private void rbtnDropped_CheckedChanged(object sender, EventArgs e)
        {
            resetColumns();
            var dgc = new DataGridViewTextBoxColumn();
            dgc.Name = "dgcReason";
            dgc.HeaderText = "Reason";
            dgvStudents.Columns.Add(dgc);
            students = Models.Student.FindWithStatus(txtSearch.Text, program.ID, batch.ID, rbtnDropped.Text);
            dgvStudents.Rows.Clear();
            int c = 1;
            foreach (Models.Student student in students)
            {
                Models.Batch batch = Models.Batch.GetByID(student.BatchID);
                Models.Program program = Models.Program.getByID(batch.ProgramID);
                Models.Drop drop = Models.Drop.getByStudent(student.ID);
                dgvStudents.Rows.Add(student.ID, c, student.GetFullName(), program.Title, batch.Number, drop.Reason);
                c++;
            }
        }

        private void rbtnStopped_CheckedChanged(object sender, EventArgs e)
        {
            resetColumns();
            var dgc = new DataGridViewTextBoxColumn();
            dgc.Name = "dgcReason";
            dgc.HeaderText = "Reason";
            dgvStudents.Columns.Add(dgc);
            students = Models.Student.FindWithStatus(txtSearch.Text, program.ID, batch.ID, rbtnStopped.Text);
            dgvStudents.Rows.Clear();
            int c = 1;
            foreach (Models.Student student in students)
            {
                Models.Batch batch = Models.Batch.GetByID(student.BatchID);
                Models.Program program = Models.Program.getByID(batch.ProgramID);
                Models.Stop stop = Models.Stop.getByStudent(student.ID);
                dgvStudents.Rows.Add(student.ID, c, student.GetFullName(), program.Title, batch.Number, stop.Reason);
                c++;
            }
        }

        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            resetColumns();
            var dgc = new DataGridViewTextBoxColumn();
            dgc.Name = "dgcStatus";
            dgc.HeaderText = "STATUS";
            dgvStudents.Columns.Add(dgc);
            students = Models.Student.Find(txtSearch.Text, program.ID, batch.ID);
            dgvStudents.Rows.Clear();
            int c = 1;
            foreach (Models.Student student in students)
            {
                Models.Batch batch = Models.Batch.GetByID(student.BatchID);
                Models.Program program = Models.Program.getByID(batch.ProgramID);
                dgvStudents.Rows.Add(student.ID, c, student.GetFullName(), program.Title, batch.Number, student.Status);
                c++;
            }
        }

        private void resetColumns()
        {
            if (dgvStudents.Columns.Count > 5)
            {
                int cols = dgvStudents.Columns.Count;
                for (int i = 5; i < cols; i++)
                {
                    dgvStudents.Columns.RemoveAt(5);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            dgvStudents.ClearSelection();
            int height = dgvStudents.Height;
            dgvStudents.Height = dgvStudents.RowCount * dgvStudents.RowTemplate.Height + dgvStudents.Columns[0].HeaderCell.Size.Height;
            dgvStudents.ScrollBars = ScrollBars.None;
            img = new Bitmap(dgvStudents.Width, dgvStudents.Height);
            dgvStudents.DrawToBitmap(img, new Rectangle(0, 0, dgvStudents.Width, dgvStudents.Height));
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
            e.Graphics.DrawImage(img, e.PageBounds.Width / 2 - img.Width / 2, 50);
        }

        private void dgvStudents_Sorted(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStudents.Rows)
            {
                row.Cells[dgcNumber.Name].Value = row.Index + 1;
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                dgvStudents.SelectAll();
                DataObject dataObj = dgvStudents.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);

                object misValue = System.Reflection.Missing.Value;
                Excel.Application xlexcel = new Excel.Application();

                xlexcel.DisplayAlerts = false; // Without this you will get two confirm overwrite prompts
                Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                // Paste clipboard results to worksheet range
                Excel.Range CR = (Excel.Range)xlWorkSheet.Cells[1, 1];
                CR.Select();
                xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                // Save the excel file under the captured location from the SaveFileDialog
                xlWorkBook.SaveAs(sfd.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlexcel.DisplayAlerts = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();

                // Clear Clipboard and DataGridView selection
                Clipboard.Clear();

                // Open the newly saved excel file
                if (File.Exists(sfd.FileName))
                    System.Diagnostics.Process.Start(sfd.FileName);
            }
            dgvStudents.ClearSelection();
        }
    }
}
