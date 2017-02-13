using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

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
            int c = 1;
            foreach (Models.Student student in students)
            {
                Models.Batch batch = Models.Batch.GetByID(student.BatchID);
                Models.Program program = Models.Program.getByID(batch.ProgramID);
                dgvStudentsLists.Rows.Add(student.ID, c, student.GetFullName(), program.Title, batch.Number);
                c++;
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
            vGrades.FromStudentsList = true;
            vGrades.cStudentsList = cStudentsList;
            vGrades.LoadProgramAndBatch(program, batch);
            vGrades.Show();
            if (vGrades.Visible)
            {
                this.Hide();
            }
        }

        private void ListOfStudents_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgvStudentsLists.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dgvStudentsLists_Sorted(object sender, EventArgs e)
        {
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                dgvStudentsLists.SelectAll();
                DataObject dataObj = dgvStudentsLists.GetClipboardContent();
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
            dgvStudentsLists.ClearSelection();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
