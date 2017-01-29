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
    public partial class StudentsProfile : Form
    {
        internal StudentsProfile(Controllers.StudentsList cStudentsList)
        {
            InitializeComponent();
            this.cStudentsList = cStudentsList;
        }

        Models.Student student = new Models.Student();
        Models.Profile profile = new Models.Profile();
        Models.Contact contact = new Models.Contact();
        Models.Training training = new Models.Training();
        Models.Employment employment = new Models.Employment();
        Models.Batch batch = new Models.Batch();
        Models.Program program = new Models.Program();

        private Controllers.StudentsList cStudentsList;

        private void linkEditManpowerProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditManpowerProfile em = new EditManpowerProfile();
            em.student = student;
            em.profile = profile;
            em.contact = contact;
            em.ShowDialog();
            LoadData();
        }

        private void linkEditClassificatoion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditLearnerClassification ec = new EditLearnerClassification();
            ec.student = student;
            ec.profile = profile;
            ec.training = training;
            ec.ShowDialog();
            LoadData();
        }

        private void linkEditPersonalInformation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditPersonalInformation ep = new EditPersonalInformation();
            ep.profile = profile;
            ep.employment = employment;
            ep.ShowDialog();
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cStudentsList.ShowListOfStudents();
        }

        private void StudentsProfile_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            student = cStudentsList.mStudent;
            profile = Models.Profile.getByStudent(student.ID);
            contact = Models.Contact.getContactByStudent(student.ID);
            training = Models.Training.getTrainingByStudent(student.ID);
            employment = Models.Employment.getEmploymentByStudent(student.ID, "Before");
            batch = Models.Batch.GetByID(student.BatchID);
            program = Models.Program.getByID(batch.ProgramID);

            lblStudentNumber.Text = student.Number;
            lblStudentName.Text = student.GetFullName();

            lblBatch.Text = batch.Number.ToString("D2");

            lblProgramCopr.Text = program.Copr;
            lblProgramTitle.Text = program.Title;
            if (program.OneYear) lblProgramDuration.Text = "One Year";
            if (program.ShortCourse) lblProgramDuration.Text = "Short Course";

            lblEmail.Text = contact.Email;
            lblPhone.Text = contact.Phone;
            lblAddress.Text = string.Format("{0}, {1}, {2}, {3}", contact.Street, contact.Barangay, contact.City, contact.Province);

            lblNationality.Text = profile.Nationality;
            lblGender.Text = profile.Gender;
            lblBirthdate.Text = profile.Birthdate.ToString("MMM dd, yyyy");
            lblBirthplace.Text = profile.Birthplace;
            lblCivilStatus.Text = profile.CivilStatus;
            lblEducationalAttainment.Text = profile.Education;
            int age = DateTime.Today.Year - profile.Birthdate.Year;
            if (DateTime.Today.DayOfYear < profile.Birthdate.DayOfYear) age--;
            lblAge.Text = age.ToString();

            lblEmploymentStatus.Text = employment.Occupation;

            lblStudentClassification.Text = profile.Classification;
            lblScholarshipPackage.Text = training.Scholarship;
            lblVoucherNumber.Text = training.Voucher;
        }

        private void btnShowExaminations_Click(object sender, EventArgs e)
        {
            Students.Examinations ex = new Students.Examinations();
            ex.student = student;
            ex.ShowDialog();
        }
    }
}
