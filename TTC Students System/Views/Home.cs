using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GN.TTC.Students.Views
{
    public partial class Home : Form
    {
        internal Home(Controllers.Main cMain)
        {
            InitializeComponent();
            this.cMain = cMain;
        }

        private Controllers.Main cMain;

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            cMain.StartRegistration();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            cMain.StartStudentsList();
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            cMain.StartStudentStatus();
        }
        private void btnPayment_Click(object sender, EventArgs e)
        {
            cMain.StartBilling().ShowPay();
        }
        private void btnTransactionHistory_Click(object sender, EventArgs e)
        {
            cMain.StartBilling().ShowTransactionHistory();
        }

        private void btnChecklist_Click(object sender, EventArgs e)
        {
            cMain.StartRecords().ShowDocumentsChecklist();
        }

        private void btnProvidersProfile_Click(object sender, EventArgs e)
        {
            cMain.StartMaintenance().ShowProvidersProfile();
        }

        private void btnProgramProfile_Click(object sender, EventArgs e)
        {
            cMain.StartMaintenance().ShowProgramProfile();
        }

        private void btnTuitionFee_Click(object sender, EventArgs e)
        {
            cMain.StartMaintenance().ShowTuitionFee();
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            cMain.StartMaintenance().ShowSubject();
        }

        private void btnTeachers_Click(object sender, EventArgs e)
        {
            cMain.StartMaintenance().ShowTeachersSubjects();
        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            cMain.StartRecords().ShowGrades();
        }

        private void btnInsurances_Click(object sender, EventArgs e)
        {
            cMain.StartRecords().ShowInsurances();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel ex = new ExportToExcel();
            ex.ShowDialog();
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            cMain.StartPayroll().ShowCompanies();
        }

        private void btnCompanyInplants_Click(object sender, EventArgs e)
        {
            cMain.StartPayroll().ShowInPlants();
        }

        private void btnDTR_Click(object sender, EventArgs e)
        {
            cMain.StartPayroll().ShowDTR();
        }

        private void btnStudentsPayroll_Click(object sender, EventArgs e)
        {
            cMain.StartPayroll().ShowSummary();
        }
    }
}
