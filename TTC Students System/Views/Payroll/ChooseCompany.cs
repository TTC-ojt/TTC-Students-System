using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Payroll
{
    public partial class ChooseCompany : Form
    {
        public ChooseCompany()
        {
            InitializeComponent();
        }

        List<Models.Company> companies;
        internal Models.Company company = new Models.Company();

        private void ChooseProgram_Load(object sender, EventArgs e)
        {
            companies = Models.Company.getAll();
            dgvChooseCompanies.Rows.Clear();
            foreach (var company in companies)
            {
                dgvChooseCompanies.Rows.Add(company.ID, company.Name, company.Address);
            }
            dgvChooseCompanies.ClearSelection();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvChooseCompanies.SelectedRows[0].Cells[0].Value);
            company = companies.Find(p => p.ID == id);
            this.Close();
        }

        private void dgvChooseProgram_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvChooseCompanies.SelectedRows.Count > 0)
            {
                btnSelect.Enabled = true;
            }
            else
            {
                btnSelect.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
