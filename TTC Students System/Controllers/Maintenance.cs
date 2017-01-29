namespace GN.TTC.Students.Controllers
{
    class Maintenance
    {
        internal Main cMain;
        
        internal Views.Maintenance.ProgramProfile vProgramProfile;
        internal Views.Maintenance.SubjectMaintenance vSubject;
        internal Views.Maintenance.Teachers vTeachers;
        internal Views.Maintenance.TuitionFee vTuitionFee;
        internal Views.Maintenance.TVETProvidersProfile vTVETProvidersProfile;

        internal Maintenance(Main cMain)
        {
            this.cMain = cMain;
        }

        internal void ShowProgramProfile()
        {
            vProgramProfile = new Views.Maintenance.ProgramProfile(this);
            vProgramProfile.MdiParent = this.cMain.vMain;
            vProgramProfile.Show();
        }

        internal void ShowSubject()
        {
            vSubject = new Views.Maintenance.SubjectMaintenance(this);
            vSubject.MdiParent = this.cMain.vMain;
            vSubject.Show();
        }

        internal void ShowTeachersSubjects()
        {
            vTeachers = new Views.Maintenance.Teachers(this);
            vTeachers.MdiParent = this.cMain.vMain;
            vTeachers.Show();
        }

        internal void ShowTuitionFee()
        {
            vTuitionFee = new Views.Maintenance.TuitionFee(this);
            vTuitionFee.MdiParent = this.cMain.vMain;
            vTuitionFee.Show();
        }

        internal void ShowProvidersProfile()
        {
            vTVETProvidersProfile = new Views.Maintenance.TVETProvidersProfile(this);
            vTVETProvidersProfile.MdiParent = this.cMain.vMain;
            vTVETProvidersProfile.Show();
        }

        internal void Close()
        {
            cMain.vHome.Show();
        }
    }
}
