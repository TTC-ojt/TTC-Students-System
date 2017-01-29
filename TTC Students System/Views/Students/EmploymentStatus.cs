using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Status
{
    public partial class EmploymentStatus : Form
    {
        internal EmploymentStatus(Controllers.StudentsList cStudentsList)
        {
            InitializeComponent();

            this.cStudentsList = cStudentsList;
        }

        private Controllers.StudentsList cStudentsList;

        internal Models.Employment employment = new Models.Employment();

        private void btnSave_Click(object sender, EventArgs e)
        {
            employment.Occupation = txtOccupation.Text;
            employment.Employer = txtEmployer.Text;
            employment.Address = txtEmployerAddress.Text;
            employment.Classification = txtClassWorker.Text;
            employment.DateEmployed = dtpDateEmployed.Value;
            employment.Income = nudIncome.Value;
            employment.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cStudentsList.ShowListOfStudents();
        }

        private void EmploymentStatus_Load(object sender, EventArgs e)
        {
            Models.Student student = cStudentsList.mStudent;
            Models.Batch batch = Models.Batch.GetByID(student.BatchID);
            Models.Program program = Models.Program.getByID(batch.ProgramID);

            lblStudentNumber.Text = student.Number;
            lblStudentName.Text = student.GetFullName();
            lblCourse.Text = program.Title;

            employment = Models.Employment.getEmploymentByStudent(student.ID, "After");
            dtpDateEmployed.Value = employment.DateEmployed;
            txtOccupation.Text = employment.Occupation;
            txtEmployer.Text = employment.Employer;
            txtEmployerAddress.Text = employment.Address;
            txtClassWorker.Text = employment.Classification;
            nudIncome.Value = employment.Income;
        }
    }
}
