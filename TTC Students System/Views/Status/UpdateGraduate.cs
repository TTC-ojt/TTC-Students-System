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
    public partial class UpdateGraduate : Form
    {
        public UpdateGraduate()
        {
            InitializeComponent();
        }

        internal Models.Student student = new Models.Student();
        Models.Training training = new Models.Training();
        Models.Graduate graduate = new Models.Graduate();

        private void btnSave_Click(object sender, EventArgs e)
        {
            student.Status = "GRADUATE";
            student.Save();

            training.DateFinished = dtpDate.Value;
            training.Result = "COMPETENT";
            training.Save();

            graduate.StudentID = student.ID;
            graduate.SpecialOrder = txtSpecialOrder.Text;
            graduate.DateIssued = dtpIssued.Value;
            graduate.Save();
            
            this.Close();
        }

        private void UpdateGraduate_Load(object sender, EventArgs e)
        {
            graduate = Models.Graduate.getByStudent(student.ID);
            training = Models.Training.getTrainingByStudent(student.ID);

            txtSpecialOrder.Text = graduate.SpecialOrder;
            dtpDate.Value = training.DateFinished;
            dtpIssued.Value = graduate.DateIssued;

            dtpDate.Value = DateTime.Today;
            lblStudentNumber.Text = student.Number;
            lblFullName.Text = student.GetFullName();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
