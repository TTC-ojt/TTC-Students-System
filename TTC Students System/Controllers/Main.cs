namespace GN.TTC.Students.Controllers
{
    class Main
    {

        internal Registration cRegistration;
        internal StudentsList cStudentsList;
        internal StudentsStatus cStudentsStatus;
        internal Billing cBilling;
        internal Records cRecords;
        internal Maintenance cMaintenance;
        internal Payroll cPayroll;

        internal Views.Main vMain;
        internal Views.Home vHome;

        internal Main(Views.Main vMain)
        {
            this.vMain = vMain;
            vHome = new Views.Home(this);
        }

        internal void StartSystem()
        {
            vHome.MdiParent = vMain;
            vHome.Show();
        }

        internal void StartRegistration()
        {
            cRegistration = new Registration(this);
            cRegistration.ShowManPower();
            vHome.Hide();
        }

        internal void StartStudentsList()
        {
            cStudentsList = new StudentsList(this);
            cStudentsList.ShowListOfStudents();
            vHome.Hide();
        }

        internal void StartStudentStatus()
        {
            cStudentsStatus = new StudentsStatus(this);
            cStudentsStatus.ShowStudentsStatus();
            vHome.Hide();
        }

        internal Billing StartBilling()
        {
            cBilling = new Billing(this);
            vHome.Hide();
            return cBilling;
        }

        internal Records StartRecords()
        {
            cRecords = new Records(this);
            vHome.Hide();
            return cRecords;
        }

        internal Maintenance StartMaintenance()
        {
            cMaintenance = new Maintenance(this);
            vHome.Hide();
            return cMaintenance;
        }

        internal Payroll StartPayroll()
        {
            cPayroll = new Payroll(this);
            return cPayroll;
        }

    }
}
