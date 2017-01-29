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
    public partial class EditPersonalInformation : Form
    {
        public EditPersonalInformation()
        {
            InitializeComponent();
        }
        
        internal Models.Profile profile;
        internal Models.Employment employment;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (rbtnMale.Checked) profile.Gender = rbtnMale.Text; else profile.Gender = rbtnFemale.Text;
            if (rbtnSingle.Checked) profile.CivilStatus = rbtnSingle.Text;
            if (rbtnMarried.Checked) profile.CivilStatus = rbtnMarried.Text;
            if (rbtnWidow.Checked) profile.CivilStatus = rbtnWidow.Text;
            if (rbtnSeparated.Checked) profile.CivilStatus = rbtnSeparated.Text;
            if (rbtnUnemployed.Checked)
            {
                employment.Occupation = "";
                employment.Employer = "";
                employment.Address = "";
                employment.Classification = "";
                employment.DateEmployed = new DateTime(2000, 01, 01);
                employment.Income = 0m;
            }
            else
            {
                employment.Occupation = txtOccupation.Text;
                employment.Employer = txtEmployer.Text;
                employment.Address = txtEmployerAddress.Text;
                employment.Classification = txtEmploymentClassification.Text;
                employment.DateEmployed = dtpDateEmployed.Value;
                employment.Income = nudIncome.Value;
            }
            DateTime bdate = new DateTime(Convert.ToInt32(nudByear.Value), Convert.ToInt32(nudBmonth.Value), Convert.ToInt32(nudBday.Value));
            profile.Birthdate = bdate;
            profile.Birthplace = txtBirthplace.Text;
            if (rbtnALS.Checked) profile.Education = rbtnALS.Text;
            if (rbtnHighSchoolGraduate.Checked) profile.Education = rbtnHighSchoolGraduate.Text;
            if (rbtnPostSecondary.Checked) profile.Education = rbtnPostSecondary.Text;
            if (rbtnCollegeUndergraduate.Checked) profile.Education = rbtnCollegeUndergraduate.Text;
            if (rbtnCollegeGraduate.Checked) profile.Education = rbtnCollegeGraduate.Text;
            profile.Save();
            employment.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalculateAge(object sender, EventArgs e)
        {
            DateTime bdate = new DateTime(Convert.ToInt32(nudByear.Value), Convert.ToInt32(nudBmonth.Value), Convert.ToInt32(nudBday.Value));
            int age = DateTime.Today.Year - bdate.Year;
            if (DateTime.Today.DayOfYear < bdate.DayOfYear)
            {
                age--;
            }
            txtAge.Text = age.ToString();
        }

        private void rbtnEmployed_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnEmployed.Checked)
            {
                grpEmployment.Visible = true;
            }
            else
            {
                grpEmployment.Visible = false;
            }
        }

        private void EditPersonalInformation_Load(object sender, EventArgs e)
        {
            if (profile.Gender == rbtnMale.Text) rbtnMale.Checked = true; else rbtnFemale.Checked = true;
            if (profile.CivilStatus == rbtnSingle.Text) rbtnSingle.Checked = true;
            if (profile.CivilStatus == rbtnMarried.Text) rbtnMarried.Checked = true;
            if (profile.CivilStatus == rbtnWidow.Text) rbtnWidow.Checked = true;
            if (profile.CivilStatus == rbtnSeparated.Text) rbtnSeparated.Checked = true;
            if (!string.IsNullOrWhiteSpace(employment.Occupation)) rbtnEmployed.Checked = true;
            txtOccupation.Text = employment.Occupation;
            txtEmployer.Text = employment.Employer;
            txtEmployerAddress.Text = employment.Address;
            txtEmploymentClassification.Text = employment.Classification;
            dtpDateEmployed.Value = employment.DateEmployed;
            nudIncome.Value = employment.Income;
            nudBmonth.Value = profile.Birthdate.Month;
            nudBday.Value = profile.Birthdate.Day;
            nudByear.Value = profile.Birthdate.Year;
            CalculateAge(sender, e);
            txtBirthplace.Text = profile.Birthplace;
            if (profile.Education == rbtnALS.Text) rbtnALS.Checked = true;
            if (profile.Education == rbtnHighSchoolGraduate.Text) rbtnHighSchoolGraduate.Checked = true;
            if (profile.Education == rbtnPostSecondary.Text) rbtnPostSecondary.Checked = true;
            if (profile.Education == rbtnCollegeUndergraduate.Text) rbtnCollegeUndergraduate.Checked = true;
            if (profile.Education == rbtnCollegeGraduate.Text) rbtnCollegeGraduate.Checked = true;
        }
    }
}
