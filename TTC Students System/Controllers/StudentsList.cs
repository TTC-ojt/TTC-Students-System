namespace GN.TTC.Students.Controllers
{
    class StudentsList
    {
        internal Main cMain;

        internal Models.Student mStudent;

        internal Views.Status.ListOfStudents vListOfStudents;
        internal Views.Status.AssessmentAndCertification vAssessmentAndCert;
        internal Views.Status.EmploymentStatus vEmploymentStatus;
        internal Views.Status.StudentsProfile vStudentsProfile;

        internal StudentsList(Main cMain)
        {
            this.cMain = cMain;
            mStudent = new Models.Student();
            vListOfStudents = new Views.Status.ListOfStudents(this);
            vListOfStudents.MdiParent = cMain.vMain;
        }

        internal void ShowListOfStudents()
        {
            vListOfStudents.Show();
        }

        internal void ShowAssessmentAndCert()
        {
            vAssessmentAndCert = new Views.Status.AssessmentAndCertification(this);
            vAssessmentAndCert.MdiParent = cMain.vMain;
            vAssessmentAndCert.Show();
            vListOfStudents.Hide();
        }

        internal void ShowEmploymentStatus()
        {
            vEmploymentStatus = new Views.Status.EmploymentStatus(this);
            vEmploymentStatus.MdiParent = cMain.vMain;
            vEmploymentStatus.Show();
            vListOfStudents.Hide();
        }

        internal void ShowStudentsProfile()
        {
            vStudentsProfile = new Views.Status.StudentsProfile(this);
            vStudentsProfile.MdiParent = cMain.vMain;
            vStudentsProfile.Show();
            vListOfStudents.Hide();
        }

        internal void Close()
        {
            cMain.vHome.Show();
        }
    }
}
