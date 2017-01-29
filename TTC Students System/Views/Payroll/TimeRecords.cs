using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Payroll
{
    public partial class TimeRecords : Form
    {
        internal TimeRecords(Controllers.Payroll cPayroll)
        {
            InitializeComponent();
            this.cPayroll = cPayroll;
        }

        private Controllers.Payroll cPayroll;
        List<Models.DTR> dtrs = new List<Models.DTR>();
        Models.DTR dtr = new Models.DTR();
        Models.Company company = new Models.Company();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cPayroll.Close();
        }

        private void btnSelectCompany_Click(object sender, EventArgs e)
        {
            ChooseCompany cc = new ChooseCompany();
            cc.ShowDialog();
            company = cc.company;
            txtNameofCompny.Text = company.Name;
            txtCompanyAddress.Text = company.Address;
            LoadInPlants(sender, e);
        }

        private void btnAddTrainee_Click(object sender, EventArgs e)
        {
            LoadInPlants(sender, e);
        }

        private void GenerateColumns()
        {
            if (dgvCompanyOfEmployment.Columns.Count > 2)
            {
                int cols = dgvCompanyOfEmployment.Columns.Count;
                for (int i = 2; i < cols; i++)
                {
                    dgvCompanyOfEmployment.Columns.RemoveAt(2);
                }
            }
            if (company.RegularHour > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgc.FillWeight = 5;
                dgc.Name = "dgcRegularHour";
                dgc.HeaderText = "Regular Hours";
                dgvCompanyOfEmployment.Columns.AddRange(new DataGridViewColumn[] { dgc });
            }
            if (company.RegularDay > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgc.FillWeight = 5;
                dgc.Name = "dgcRegularDay";
                dgc.HeaderText = "Regular Days";
                dgvCompanyOfEmployment.Columns.AddRange(new DataGridViewColumn[] { dgc });
            }
            if (company.SaturdayHour > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgc.FillWeight = 5;
                dgc.Name = "dgcSaturdayHour";
                dgc.HeaderText = "Saturday Hours";
                dgvCompanyOfEmployment.Columns.AddRange(new DataGridViewColumn[] { dgc });
            }
            if (company.SaturdayDay > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgc.FillWeight = 5;
                dgc.Name = "dgcSaturdayDay";
                dgc.HeaderText = "Saturday Days";
                dgvCompanyOfEmployment.Columns.AddRange(new DataGridViewColumn[] { dgc });
            }
            if (company.HolidayHour > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgc.FillWeight = 5;
                dgc.Name = "dgcHolidayHour";
                dgc.HeaderText = "Holiday Hours";
                dgvCompanyOfEmployment.Columns.AddRange(new DataGridViewColumn[] { dgc });
            }
            if (company.HolidayDay > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgc.FillWeight = 5;
                dgc.Name = "dgcHolidayDay";
                dgc.HeaderText = "Holiday Days";
                dgvCompanyOfEmployment.Columns.AddRange(new DataGridViewColumn[] { dgc });
            }
            if (company.LegalHolidayHour > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgc.FillWeight = 5;
                dgc.Name = "dgcLegalHolidayHour";
                dgc.HeaderText = "Legal Holiday Hours";
                dgvCompanyOfEmployment.Columns.AddRange(new DataGridViewColumn[] { dgc });
            }
            if (company.LegalHolidayDay > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgc.FillWeight = 5;
                dgc.Name = "dgcLegalHolidayDay";
                dgc.HeaderText = "Legal Holiday Days";
                dgvCompanyOfEmployment.Columns.AddRange(new DataGridViewColumn[] { dgc });
            }
            if (company.GuaranteeHour > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgc.FillWeight = 5;
                dgc.Name = "dgcGuaranteeHour";
                dgc.HeaderText = "Guarantee Hours";
                dgvCompanyOfEmployment.Columns.AddRange(new DataGridViewColumn[] { dgc });
            }
            if (company.GuaranteeDay > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgc.FillWeight = 5;
                dgc.Name = "dgcGuaranteeDay";
                dgc.HeaderText = "Guarantee Days";
                dgvCompanyOfEmployment.Columns.AddRange(new DataGridViewColumn[] { dgc });
            }
            if (company.ExtendedTime > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgc.FillWeight = 5;
                dgc.Name = "dgcExtendedTime";
                dgc.HeaderText = "Extended Time";
                dgvCompanyOfEmployment.Columns.AddRange(new DataGridViewColumn[] { dgc });
            }
            if (company.NightPremiumHour > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgc.FillWeight = 5;
                dgc.Name = "dgcNightPremiumHour";
                dgc.HeaderText = "Night Premium Hours";
                dgvCompanyOfEmployment.Columns.AddRange(new DataGridViewColumn[] { dgc });
            }
            if (company.NightPremiumDay > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgc.FillWeight = 5;
                dgc.Name = "dgcNightPremiumDay";
                dgc.HeaderText = "Night Premium Days";
                dgvCompanyOfEmployment.Columns.AddRange(new DataGridViewColumn[] { dgc });
            }
            if (company.TransportationAllowance>0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgc.FillWeight = 5;
                dgc.Name = "dgcTransportationAllowance";
                dgc.HeaderText = "Transportation Allowance";
                dgvCompanyOfEmployment.Columns.AddRange(new DataGridViewColumn[] { dgc });
            }
        }

        private void LoadInPlants(object sender, EventArgs e)
        {
            dtrs = Models.DTR.getAllByCompanyAndDate(company.ID, dtpDate.Value, dtpDate.Value);
            List<Models.InPlant> inplants = Models.InPlant.getAllByCompanyAndDate(company.ID, dtpDate.Value, dtpDate.Value);
            if (dtrs.Count != inplants.Count)
            {
                foreach (Models.InPlant inplant in inplants)
                {
                    Models.DTR dtr = new Models.DTR();
                    dtr.CompanyID = company.ID;
                    dtr.StudentID = inplant.StudentID;
                    dtr.Date = dtpDate.Value;
                    dtr.Save();
                }
                dtrs = Models.DTR.getAllByCompanyAndDate(company.ID, dtpDate.Value, dtpDate.Value);
            }
            dgvCompanyOfEmployment.Rows.Clear();
            GenerateColumns();
            foreach (Models.DTR dtr in dtrs)
            {
                Models.Student student = Models.Student.getByID(dtr.StudentID);
                List<Object> values = new List<Object>();
                values.Add(dtr.ID);
                values.Add(student.GetFullName());
                if (company.RegularHour > 0)
                {
                    values.Add(dtr.RegularHour.ToString("N"));
                }
                if (company.RegularDay > 0)
                {
                    values.Add(dtr.RegularDay.ToString("N"));
                }
                if (company.SaturdayHour > 0)
                {
                    values.Add(dtr.SaturdayHour.ToString("N"));
                }
                if (company.SaturdayDay > 0)
                {
                    values.Add(dtr.SaturdayDay.ToString("N"));
                }
                if (company.HolidayHour > 0)
                {
                    values.Add(dtr.HolidayHour.ToString("N"));
                }
                if (company.HolidayDay > 0)
                {
                    values.Add(dtr.HolidayDay.ToString("N"));
                }
                if (company.LegalHolidayHour > 0)
                {
                    values.Add(dtr.LegalHolidayHour.ToString("N"));
                }
                if (company.LegalHolidayDay > 0)
                {
                    values.Add(dtr.LegalHolidayDay.ToString("N"));
                }
                if (company.GuaranteeHour > 0)
                {
                    values.Add(dtr.GuaranteeHour.ToString("N"));
                }
                if (company.GuaranteeDay > 0)
                {
                    values.Add(dtr.GuaranteeDay.ToString("N"));
                }
                if (company.ExtendedTime > 0)
                {
                    values.Add(dtr.ExtendedTime.ToString("N"));
                }
                if (company.NightPremiumHour > 0)
                {
                    values.Add(dtr.NightPremiumHour.ToString("N"));
                }
                if (company.NightPremiumDay > 0)
                {
                    values.Add(dtr.NightPremiumDay.ToString("N"));
                }
                if (company.TransportationAllowance>0)
                {
                    values.Add(dtr.TransportationAllowance.ToString("N"));
                }
                dgvCompanyOfEmployment.Rows.Add(values.ToArray());
            }
            dgvCompanyOfEmployment.ClearSelection();
        }

        private void CheckDataGrid()
        {
            foreach (DataGridViewRow row in dgvCompanyOfEmployment.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                        cell.Value = (0m).ToString("N");
                    if (string.IsNullOrWhiteSpace(cell.Value.ToString()))
                        cell.Value = (0m).ToString("N");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckDataGrid();
            foreach (DataGridViewRow row in dgvCompanyOfEmployment.Rows)
            {
                int id = Convert.ToInt32(row.Cells[0].Value);
                
                dtr = dtrs.Find(c => c.ID == id);
                if (company.RegularHour > 0)
                {
                    dtr.RegularHour = Convert.ToDecimal(row.Cells["dgcRegularHour"].Value);
                }
                if (company.RegularDay > 0)
                {
                    dtr.RegularDay = Convert.ToDecimal(row.Cells["dgcRegularDay"].Value);
                }
                if (company.SaturdayHour > 0)
                {
                    dtr.SaturdayHour = Convert.ToDecimal(row.Cells["dgcSaturdayHour"].Value);
                }
                if (company.SaturdayDay > 0)
                {
                    dtr.SaturdayDay = Convert.ToDecimal(row.Cells["dgcSaturdayDay"].Value);
                }
                if (company.HolidayHour > 0)
                {
                    dtr.HolidayHour = Convert.ToDecimal(row.Cells["dgcHolidayHour"].Value);
                }
                if (company.HolidayDay > 0)
                {
                    dtr.HolidayDay = Convert.ToDecimal(row.Cells["dgcHolidayDay"].Value);
                }
                if (company.LegalHolidayHour > 0)
                {
                    dtr.LegalHolidayHour = Convert.ToDecimal(row.Cells["dgcLegalHolidayHour"].Value);
                }
                if (company.LegalHolidayDay > 0)
                {
                    dtr.LegalHolidayDay = Convert.ToDecimal(row.Cells["dgcLegalHolidayDay"].Value);
                }
                if (company.GuaranteeHour > 0)
                {
                    dtr.GuaranteeHour = Convert.ToDecimal(row.Cells["dgcGuaranteeHour"].Value);
                }
                if (company.GuaranteeDay > 0)
                {
                    dtr.GuaranteeDay = Convert.ToDecimal(row.Cells["dgcGuaranteeDay"].Value);
                }
                if (company.ExtendedTime > 0)
                {
                    dtr.ExtendedTime = Convert.ToDecimal(row.Cells["dgcExtendedTime"].Value);
                }
                if (company.NightPremiumHour > 0)
                {
                    dtr.NightPremiumHour = Convert.ToDecimal(row.Cells["dgcNightPremiumHour"].Value);
                }
                if (company.NightPremiumDay > 0)
                {
                    dtr.NightPremiumDay = Convert.ToDecimal(row.Cells["dgcNightPremiumDay"].Value);
                }
                if (company.TransportationAllowance > 0)
                {
                    dtr.TransportationAllowance = Convert.ToDecimal(row.Cells["dgcTransportationAllowance"].Value);
                }
                dtr.Save();
            }
            LoadInPlants(sender, e);
        }

        private void dgvCompanyOfEmployment_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCompanyOfEmployment.SelectedRows.Count>0 && company.RegularHour > 0)
            {
                btnComputeTime.Enabled = true;
            }
            else
            {
                btnComputeTime.Enabled = false;
            }
        }

        private void btnComputeTime_Click(object sender, EventArgs e)
        {
            ComputeTime ct = new ComputeTime();
            ct.ShowDialog();
            decimal Hours = ct.Hours;
            decimal ext = Hours - 8;
            
            dgvCompanyOfEmployment.SelectedRows[0].Cells["dgcRegularHour"].Value = Hours.ToString("N");
            if (Hours > 0 && company.TransportationAllowance > 0)
            {
                dgvCompanyOfEmployment.SelectedRows[0].Cells["dgcTransportationAllowance"].Value = company.TransportationAllowance;
            }
            if (company.ExtendedTime > 0)
            {
                if (ext > 0)
                {
                    dgvCompanyOfEmployment.SelectedRows[0].Cells["dgcExtendedTime"].Value = ext.ToString("N");
                    dgvCompanyOfEmployment.SelectedRows[0].Cells["dgcRegularHour"].Value = 8.ToString("N");
                    Hours = Hours - ext;
                }
            }
            dgvCompanyOfEmployment.SelectedRows[0].Cells["dgcRegularHour"].Value = Hours.ToString("N");
        }

        private void dgvCompanyOfEmployment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dgvCompanyOfEmployment.Columns[e.ColumnIndex].Name;
            if (columnName == "dgcRegularDay" || columnName == "dgcRegularHour")
            {
                string value = dgvCompanyOfEmployment[e.ColumnIndex, e.RowIndex].Value.ToString();
                decimal v = 0m;
                bool converted = decimal.TryParse(value, out v);
                if (converted && company.TransportationAllowance > 0)
                {
                    if (v > 0) dgvCompanyOfEmployment.Rows[e.RowIndex].Cells["dgcTransportationAllowance"].Value = company.TransportationAllowance;
                    else dgvCompanyOfEmployment.Rows[e.RowIndex].Cells["dgcTransportationAllowance"].Value = 0.ToString("N");
                }
            }
        }
    }
}
