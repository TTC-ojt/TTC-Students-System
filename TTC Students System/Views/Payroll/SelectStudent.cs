using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Payroll
{
    public partial class SelectStudent : Form
    {
        internal SelectStudent()
        {
            InitializeComponent();
        }
        
        internal Models.Student student = new Models.Student();
        private Models.Batch batch = new Models.Batch();
        private Models.Program program = new Models.Program();
        private List<Models.Student> students = new List<Models.Student>();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStudent();
        }

        private void LoadStudent()
        {
            lblStudentNumber.Text = student.Number;
            string studentname = student.LastName + ", " + student.FirstName + " " + student.MiddleName;
            lblStudentName.Text = studentname;
            batch = Models.Batch.GetByID(student.BatchID);
            program = Models.Program.getByID(batch.ProgramID);
            lblCOPR.Text = program.Copr;
            lblProgramTitle.Text = program.Title;
            lblBatch.Text = batch.Number.ToString();
        }

        private void lbxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxStudents.SelectedIndex > -1)
            {
                txtSearch.Clear();
                student = students[lbxStudents.SelectedIndex];
                lbxStudents.Hide();
                LoadStudent();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.TextLength > 2)
            {
                students = Models.Student.Find(txtSearch.Text, 0, 0);
                lbxStudents.Items.Clear();
                foreach (Models.Student student in students)
                {
                    if (txtSearch.Text.Any(char.IsDigit))
                    {
                        lbxStudents.Items.Add(student.Number);
                    }
                    else
                    {
                        lbxStudents.Items.Add(student.GetFullName());
                    }
                }
                lbxStudents.Show();
            }
            else
            {
                lbxStudents.Hide();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (student.ID > 0)
            {
                this.Close();
            }
        }
    }
}
