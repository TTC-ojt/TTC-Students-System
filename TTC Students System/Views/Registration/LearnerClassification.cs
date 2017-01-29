using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Registration
{
    public partial class LearnerClassification : Form
    {
        internal LearnerClassification(Controllers.Registration cRegistration)
        {
            InitializeComponent();
            this.cRegistration = cRegistration;
        }

        private Controllers.Registration cRegistration;

        private void btnFinish_Click(object sender, EventArgs e)
        {
            cRegistration.Save();
            cRegistration.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Save();
            cRegistration.ShowPersonalInfo();
        }

        private void Save()
        {
            cRegistration.mProfile.Classification = txtClassification.Text;
            cRegistration.mTraining.Scholarship = txtScholarshipPackage.Text;
            cRegistration.mTraining.Voucher = txtVoucherNumber.Text;
            cRegistration.mStudent.Tuition = nudTuition.Value;
        }

        private void btnShowExaminations_Click(object sender, EventArgs e)
        {
            cRegistration.ShowExaminations();
        }

        private void LearnerClassification_Load(object sender, EventArgs e)
        {
            nudTuition.Value = cRegistration.mProgram.GetFullTuition();
        }
    }
}
