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
    public partial class EditLearnerClassification : Form
    {
        public EditLearnerClassification()
        {
            InitializeComponent();
        }

        internal Models.Student student;
        internal Models.Profile profile;
        internal Models.Training training;

        private void btnSave_Click(object sender, EventArgs e)
        {
            profile.Classification = txtClassification.Text;
            profile.Save();

            training.Scholarship = txtScholarshipPackage.Text;
            training.Voucher = txtVoucherNumber.Text;
            training.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowExaminations_Click(object sender, EventArgs e)
        {
            Students.Examinations ex = new Students.Examinations();
            ex.student = student;
            ex.ShowDialog();
        }

        private void EditLearnerClassification_Load(object sender, EventArgs e)
        {
            txtClassification.Text = profile.Classification;
            txtScholarshipPackage.Text = training.Scholarship;
            txtVoucherNumber.Text = training.Voucher;
        }
    }
}
