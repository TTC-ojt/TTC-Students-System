namespace GN.TTC.Students.Controllers
{
    class StudentsStatus
    {

        internal Main cMain;

        internal Views.Status.StudentsStatus vStudentsStatus;

        internal StudentsStatus(Main cMain)
        {
            this.cMain = cMain;
        }

        internal void ShowStudentsStatus()
        {
            vStudentsStatus = new Views.Status.StudentsStatus(this);
            vStudentsStatus.MdiParent = cMain.vMain;
            vStudentsStatus.Show();
        }

        internal void Close()
        {
            cMain.vHome.Show();
        }
    }
}
