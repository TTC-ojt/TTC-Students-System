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
    public partial class AssessmentAndCertification : Form
    {
        internal AssessmentAndCertification(Controllers.StudentsList cStudentsList)
        {
            InitializeComponent();

            this.cStudentsList = cStudentsList;
        }

        private Controllers.StudentsList cStudentsList;
        private Models.Assessment assessment;

        private void linkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditAssessment es = new EditAssessment();
            es.assessment = assessment;
            es.ShowDialog();
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cStudentsList.ShowListOfStudents();
        }

        private void AssessmentAndCertification_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Models.Student student = cStudentsList.mStudent;
            assessment = Models.Assessment.getByStudent(student.ID);
            Models.Batch batch = Models.Batch.GetByID(student.BatchID);
            Models.Program program = Models.Program.getByID(batch.ProgramID);

            lblStudentNumber.Text = student.Number;
            lblStudentName.Text = student.LastName + ", " + student.FirstName + " " + student.MiddleName;

            if (program.OneYear) lblCourse.Text = "One Year";
            if (program.ShortCourse) lblCourse.Text = "Short Course";
            lblCourse.Text += " " + program.Title;

            lblAssessmentDate.Text = assessment.Date.ToString("MMM dd yyyy");
            lblResult.Text = assessment.Result;
        }
    }
}
