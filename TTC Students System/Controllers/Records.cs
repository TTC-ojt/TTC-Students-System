namespace GN.TTC.Students.Controllers
{
    class Records
    {
        internal Main cMain;

        internal Views.Records.Documents vDocumentsChecklist;
        internal Views.Records.Grades vGrades;
        internal Views.Records.Insurances vInsurances;

        internal Records(Main cMain)
        {
            this.cMain = cMain;
        }

        internal void ShowDocumentsChecklist()
        {
            vDocumentsChecklist = new Views.Records.Documents(this);
            vDocumentsChecklist.MdiParent = this.cMain.vMain;
            vDocumentsChecklist.Show();
        }

        internal void ShowGrades()
        {
            vGrades = new Views.Records.Grades(this);
            vGrades.MdiParent = this.cMain.vMain;
            vGrades.Show();
        }

        internal void ShowInsurances()
        {
            vInsurances = new Views.Records.Insurances(this);
            vInsurances.MdiParent = cMain.vMain;
            vInsurances.Show();
        }

        internal void Close()
        {
            cMain.vHome.Show();
        }
    }
}
