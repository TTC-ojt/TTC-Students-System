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
    public partial class ManPowerProfile : Form
    {
        internal ManPowerProfile(Controllers.Registration cRegistration)
        {
            InitializeComponent();
            this.cRegistration = cRegistration;
        }

        private Controllers.Registration cRegistration;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cRegistration.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Save();
            cRegistration.ShowPersonalInfo();
        }
        private void Save()
        {
            cRegistration.mStudent.Number = txtSystemStudentNumber.Text;
            cRegistration.mStudent.LastName = txtLastName.Text;
            cRegistration.mStudent.FirstName = txtFirstName.Text;
            cRegistration.mStudent.MiddleName = txtMiddleName.Text;
            cRegistration.mStudent.ExtName = txtExtName.Text;
            cRegistration.mContact.Street = txtStreet.Text;
            cRegistration.mContact.Barangay = txtBarangay.Text;
            cRegistration.mContact.District = txtCity.Text;
            cRegistration.mContact.City = txtDistrict.Text;
            cRegistration.mContact.Province = txtProvince.Text;
            cRegistration.mContact.Email = txtEmail.Text;
            cRegistration.mContact.Phone = txtPhone.Text;
            cRegistration.mProfile.Nationality = txtNationality.Text;
        }

        private void btnChangeCourse_Click(object sender, EventArgs e)
        {
            ChooseProgram vCProgram = new ChooseProgram();
            vCProgram.ShowDialog();
            cRegistration.mProgram = vCProgram.program;
            if (cRegistration.mProgram != null) LoadProgram();
        }

        private void LoadProgram()
        {
            cRegistration.mStudent.Tuition = cRegistration.mProgram.GetFullTuition();
            txtCopr.Text = cRegistration.mProgram.Copr;
            txtProgramTitle.Text = cRegistration.mProgram.Title;
            LoadBatches();
        }
        private void LoadBatches()
        {
            List<Models.Batch> batches = Models.Batch.GetAllByProgram(cRegistration.mProgram.ID);
            cbxBatch.Items.Clear();
            foreach (Models.Batch batch in batches)
            {
                cbxBatch.Items.Add(batch.Number);
            }
            cbxBatch.SelectedIndex = cbxBatch.Items.Count - 1;
        }

        private void btnNewBatch_Click(object sender, EventArgs e)
        {
            if (cRegistration.mProgram.ID > 0)
            {
                Models.Batch batch = new Models.Batch();
                batch.ProgramID = cRegistration.mProgram.ID;
                batch.Number = Convert.ToInt16(cbxBatch.Text);
                batch.Save();
                if (batch.ID > 0)
                {
                    cbxBatch.Items.Add(batch.Number);
                    cbxBatch.SelectedIndex = cbxBatch.Items.Count - 1;
                }
            } else
            {
                MessageBox.Show("Please select program.");
            }
        }

        private void cbxBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            short Number = Convert.ToInt16(cbxBatch.SelectedItem);
            cRegistration.mBatch = Models.Batch.GetByProgramAndNumber(cRegistration.mProgram.ID, Number);
            txtSystemStudentNumber.Text = DateTime.Today.ToString("yy") + "-" + Number.ToString("D2") + "-" + Models.Student.GetNextNumber();
        }
    }
}
