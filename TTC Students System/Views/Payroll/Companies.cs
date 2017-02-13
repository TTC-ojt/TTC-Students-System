using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Payroll
{
    public partial class Companies : Form
    {
        internal Companies(Controllers.Payroll cPayroll)
        {
            InitializeComponent();
            this.cPayroll = cPayroll;
        }

        private Controllers.Payroll cPayroll;
        List<Models.Company> companies = new List<Models.Company>();
        Models.Company company = new Models.Company();

        private void showData()
        {
            companies = Models.Company.getAll();
            dgvCompanyOfEmployment.Rows.Clear();
            int c = 1;
            foreach(Models.Company company in companies)
            {
                dgvCompanyOfEmployment.Rows.Add(company.ID, c, company.Name);
                c++;
            }
            dgvCompanyOfEmployment.ClearSelection();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            company.Name = txtNameofCompny.Text;
            company.Address = txtCompanyAddress.Text;
            company.RegularHour = nudRegularHour.Value;
            company.RegularDay = nudRegularDay.Value;
            company.HolidayHour = nudHolidayHour.Value;
            company.HolidayHour = nudHolidayHour.Value;
            company.LegalHolidayHour = nudLegalHolodayHour.Value;
            company.LegalHolidayDay = nudLegalHolidayDay.Value;
            company.GuaranteeHour = nudGuaranteeHour.Value;
            company.GuaranteeDay = nudGuaranteeDay.Value;
            company.ExtendedTime = nudExtendedTime.Value;
            company.NightPremiumHour = nudNightPremiumHour.Value;
            company.NightPremiumDay = nudNightPremiumDay.Value;
            company.TransportationAllowance = nudTransportation.Value;
            company.SaturdayHour = nudSaturdayHour.Value;
            company.SaturdayDay = nudSaturdayDay.Value;
            company.Save();
            showData();
        }

        private void CompanyOfEmployment_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgvCompanyOfEmployment.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            showData();
        }

        private void dgvCompanyOfEmployment_SelectionChanged(object sender, EventArgs e)
        {

            if(dgvCompanyOfEmployment.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCompanyOfEmployment.SelectedRows[0].Cells[0].Value);
                company = companies.Find(c => c.ID == id);
            }
            else
            {
                company = new Models.Company();
            }
            txtNameofCompny.Text = company.Name;
            txtCompanyAddress.Text = company.Address;
            nudRegularHour.Value = company.RegularHour;
            nudRegularDay.Value = company.RegularDay;
            nudHolidayHour.Value = company.HolidayHour;
            nudHolidayDay.Value = company.HolidayDay;
            nudLegalHolodayHour.Value = company.LegalHolidayHour;
            nudLegalHolidayDay.Value = company.LegalHolidayDay;
            nudGuaranteeHour.Value = company.GuaranteeHour;
            nudGuaranteeDay.Value = company.GuaranteeDay;
            nudExtendedTime.Value = company.ExtendedTime;
            nudNightPremiumHour.Value = company.NightPremiumHour;
            nudNightPremiumDay.Value = company.NightPremiumDay;
            nudTransportation.Value = company.TransportationAllowance;
            nudSaturdayHour.Value = company.SaturdayHour;
            nudSaturdayDay.Value = company.SaturdayDay;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cPayroll.Close();
        }

        Bitmap img;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            dgvCompanyOfEmployment.ClearSelection();
            int height = dgvCompanyOfEmployment.Height;
            dgvCompanyOfEmployment.Height = dgvCompanyOfEmployment.RowCount * dgvCompanyOfEmployment.RowTemplate.Height + dgvCompanyOfEmployment.Columns[0].HeaderCell.Size.Height;
            dgvCompanyOfEmployment.ScrollBars = ScrollBars.None;
            img = new Bitmap(dgvCompanyOfEmployment.Width, dgvCompanyOfEmployment.Height);
            dgvCompanyOfEmployment.DrawToBitmap(img, new Rectangle(0, 0, dgvCompanyOfEmployment.Width, dgvCompanyOfEmployment.Height));
            dgvCompanyOfEmployment.Height = height;
            dgvCompanyOfEmployment.ScrollBars = ScrollBars.Vertical;
            printPreviewDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.Bicubic;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.DrawImage(img, e.PageBounds.Width / 2 - img.Width / 2, 50);
        }
    }
}
