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
    public partial class PersonalInformation : Form
    {
        internal PersonalInformation(Controllers.Registration cRegistration)
        {
            InitializeComponent();
            this.cRegistration = cRegistration;
        }

        private Controllers.Registration cRegistration;

        private void btnBack_Click(object sender, EventArgs e)
        {
            Save();
            cRegistration.ShowManPower();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Save();
            cRegistration.ShowLearnerClassification();
        }

        private void Save()
        {
            //gender
            if (rbtnMale.Checked) cRegistration.mProfile.Gender = rbtnMale.Text;
            else cRegistration.mProfile.Gender = rbtnFemale.Text;
            //civil status
            if (rbtnSingle.Checked) cRegistration.mProfile.CivilStatus = rbtnSingle.Text;
            else if (rbtnMarried.Checked) cRegistration.mProfile.CivilStatus = rbtnMarried.Text;
            else if (rbtnWidow.Checked) cRegistration.mProfile.CivilStatus = rbtnWidow.Text;
            else if (rbtnSeparated.Checked) cRegistration.mProfile.CivilStatus = rbtnSeparated.Text;
            //employment status
            if (rbtnEmployed.Checked)
            {
                cRegistration.mEmployment.DateEmployed = dtpDateEmployed.Value;
                cRegistration.mEmployment.Occupation = txtOccupation.Text;
                cRegistration.mEmployment.Employer = txtEmployer.Text;
                cRegistration.mEmployment.Address = txtEmployerAddress.Text;
                cRegistration.mEmployment.Classification = txtEmploymentClassification.Text;
                cRegistration.mEmployment.Income = nudIncome.Value;
            } 
            else
            {
                cRegistration.mEmployment = new Models.Employment();
            }
            //birth
            DateTime bdate = new DateTime(Convert.ToInt32(nudByear.Value), Convert.ToInt32(nudBmonth.Value), Convert.ToInt32(nudBday.Value));
            cRegistration.mProfile.Birthdate = bdate;
            cRegistration.mProfile.Birthplace = txtBirthplace.Text;
            //education
            if (rbtnHighSchoolGraduate.Checked) cRegistration.mProfile.Education = rbtnHighSchoolGraduate.Text;
            else if (rbtnPostSecondary.Checked) cRegistration.mProfile.Education = rbtnPostSecondary.Text;
            else if (rbtnCollegeUndergraduate.Checked) cRegistration.mProfile.Education = rbtnCollegeUndergraduate.Text;
            else if (rbtnCollegeGraduate.Checked) cRegistration.mProfile.Education = rbtnCollegeGraduate.Text;
            cRegistration.mProfile.Guardian = txtGuardian.Text;
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
    }
}
