using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GN.TTC.Students.Controllers
{
    class Payroll
    {

        internal Main cMain;
        
        internal Views.Payroll.Companies vCompanies;
        internal Views.Payroll.InPlants vInPlants;
        internal Views.Payroll.TimeRecords vDTR;
        internal Views.Payroll.CompanyPayrollSummary vSummary;

        internal Payroll(Main cMain)
        {
            this.cMain = cMain;
        }

        internal void ShowCompanies()
        {
            vCompanies = new Views.Payroll.Companies(this);
            vCompanies.MdiParent = cMain.vMain;
            vCompanies.Show();
            cMain.vHome.Hide();
        }

        internal void ShowInPlants()
        {
            vInPlants = new Views.Payroll.InPlants(this);
            vInPlants.MdiParent = cMain.vMain;
            vInPlants.Show();
            cMain.vHome.Hide();
        }

        internal void ShowDTR()
        {
            vDTR = new Views.Payroll.TimeRecords(this);
            vDTR.MdiParent = cMain.vMain;
            vDTR.Show();
            cMain.vHome.Hide();
        }

        internal void ShowSummary()
        {
            vSummary = new Views.Payroll.CompanyPayrollSummary(this);
            vSummary.MdiParent = cMain.vMain;
            vSummary.Show();
            cMain.vHome.Hide();
        }

        internal void Close()
        {
            cMain.vHome.Show();
        }

    }
}
