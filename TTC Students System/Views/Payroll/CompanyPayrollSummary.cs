using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Payroll
{
    public partial class CompanyPayrollSummary : Form
    {
        internal CompanyPayrollSummary(Controllers.Payroll cPayroll)
        {
            InitializeComponent();
            this.cPayroll = cPayroll;
        }

        private Controllers.Payroll cPayroll;
        List<Models.DTR> dtrs = new List<Models.DTR>();
        Models.DTR dtr = new Models.DTR();
        Models.Company company = new Models.Company();

        decimal allowance = 0m;

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
            List<DataGridViewColumn> columns = new List<DataGridViewColumn>();
            if (company.RegularHour > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.Name = "dgcRegularHour";
                dgc.HeaderText = "Regular Hours";
                columns.Add(dgc);
                var dgcAmount = new DataGridViewTextBoxColumn();
                dgcAmount.Name = "dgcRegularHourAmount";
                dgcAmount.HeaderText = "Amount *" + company.RegularHour.ToString("N");
                columns.Add(dgcAmount);
            }
            if (company.RegularDay > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.Name = "dgcRegularDay";
                dgc.HeaderText = "Regular Days";
                columns.Add(dgc);
                var dgcAmount = new DataGridViewTextBoxColumn();
                dgcAmount.Name = "dgcRegularDayAmount";
                dgcAmount.HeaderText = "Amount *" + company.RegularDay.ToString("N");
                columns.Add(dgcAmount);
            }
            if (company.SaturdayHour > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.Name = "dgcSaturdayHour";
                dgc.HeaderText = "Saturday Hours";
                columns.Add(dgc);
                var dgcAmount = new DataGridViewTextBoxColumn();
                dgcAmount.Name = "dgcSaturdayHourAmount";
                dgcAmount.HeaderText = "Amount *" + company.SaturdayHour.ToString("N");
                columns.Add(dgcAmount);
            }
            if (company.SaturdayDay > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.Name = "dgcSaturdayDay";
                dgc.HeaderText = "Saturday Days";
                columns.Add(dgc);
                var dgcAmount = new DataGridViewTextBoxColumn();
                dgcAmount.Name = "dgcSaturdayDayAmount";
                dgcAmount.HeaderText = "Amount *" + company.SaturdayDay.ToString("N");
                columns.Add(dgcAmount);
            }
            if (company.HolidayHour > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.Name = "dgcHolidayHour";
                dgc.HeaderText = "Holiday Hours";
                columns.Add(dgc);
                var dgcAmount = new DataGridViewTextBoxColumn();
                dgcAmount.Name = "dgcHolidayHourAmount";
                dgcAmount.HeaderText = "Amount *" + company.HolidayHour.ToString("N");
                columns.Add(dgcAmount);
            }
            if (company.HolidayDay > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.Name = "dgcHolidayDay";
                dgc.HeaderText = "Holiday Days";
                columns.Add(dgc);
                var dgcAmount = new DataGridViewTextBoxColumn();
                dgcAmount.Name = "dgcHolidayDayAmount";
                dgcAmount.HeaderText = "Amount *" + company.HolidayDay.ToString("N");
                columns.Add(dgcAmount);
            }
            if (company.LegalHolidayHour > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.Name = "dgcLegalHolidayHour";
                dgc.HeaderText = "Legal Holiday Hours";
                columns.Add(dgc);
                var dgcAmount = new DataGridViewTextBoxColumn();
                dgcAmount.Name = "dgcLegalHolidayHourAmount";
                dgcAmount.HeaderText = "Amount *" + company.LegalHolidayHour.ToString("N");
                columns.Add(dgcAmount);
            }
            if (company.LegalHolidayDay > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.Name = "dgcLegalHolidayDay";
                dgc.HeaderText = "Legal Holiday Days";
                columns.Add(dgc);
                var dgcAmount = new DataGridViewTextBoxColumn();
                dgcAmount.Name = "dgcLegalHolidayDayAmount";
                dgcAmount.HeaderText = "Amount *" + company.LegalHolidayDay.ToString("N");
                columns.Add(dgcAmount);
            }
            if (company.GuaranteeHour > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.Name = "dgcGuaranteeHour";
                dgc.HeaderText = "Guarantee Hours";
                columns.Add(dgc);
                var dgcAmount = new DataGridViewTextBoxColumn();
                dgcAmount.Name = "dgcGuaranteeHourAmount";
                dgcAmount.HeaderText = "Amount *" + company.GuaranteeHour.ToString("N");
                columns.Add(dgcAmount);
            }
            if (company.GuaranteeDay > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.Name = "dgcGuaranteeDay";
                dgc.HeaderText = "Guarantee Days";
                columns.Add(dgc);
                var dgcAmount = new DataGridViewTextBoxColumn();
                dgcAmount.Name = "dgcGuaranteeDayAmount";
                dgcAmount.HeaderText = "Amount *" + company.GuaranteeDay.ToString("N");
                columns.Add(dgcAmount);
            }
            if (company.ExtendedTime > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.Name = "dgcExtendedTime";
                dgc.HeaderText = "Extended Time";
                columns.Add(dgc);
                var dgcAmount = new DataGridViewTextBoxColumn();
                dgcAmount.Name = "dgcExtendedTimeAmount";
                dgcAmount.HeaderText = "Amount *" + company.ExtendedTime.ToString("N");
                columns.Add(dgcAmount);
            }
            if (company.NightPremiumHour > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.Name = "dgcNightPremiumHour";
                dgc.HeaderText = "Night Premium Hours";
                columns.Add(dgc);
                var dgcAmount = new DataGridViewTextBoxColumn();
                dgcAmount.Name = "dgcNightPremiumHourAmount";
                dgcAmount.HeaderText = "Amount *" + company.NightPremiumHour.ToString("N");
                columns.Add(dgcAmount);
            }
            if (company.NightPremiumDay > 0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.Name = "dgcNightPremiumDay";
                dgc.HeaderText = "Night Premium Days";
                columns.Add(dgc);
                var dgcAmount = new DataGridViewTextBoxColumn();
                dgcAmount.Name = "dgcNightPremiumDayAmount";
                dgcAmount.HeaderText = "Amount *" + company.NightPremiumDay.ToString("N");
                columns.Add(dgcAmount);
            }
            if (company.TransportationAllowance >0)
            {
                var dgc = new DataGridViewTextBoxColumn();
                dgc.Name = "dgcTransportationAllowance";
                dgc.HeaderText = "Transportation Allowance";
                columns.Add(dgc);
            }
            var dgcGross = new DataGridViewTextBoxColumn();
            dgcGross.Name = "dgcGross";
            dgcGross.HeaderText = "Gross Amount";
            dgcGross.ReadOnly = true;
            columns.Add(dgcGross);
            var dgcGradFee = new DataGridViewTextBoxColumn();
            dgcGradFee.Name = "dgcGradFee";
            dgcGradFee.HeaderText = "Grad Fee";
            columns.Add(dgcGradFee);
            var dgcTuitionFee = new DataGridViewTextBoxColumn();
            dgcTuitionFee.Name = "dgcTuitionFee";
            dgcTuitionFee.HeaderText = "Tuition Fee";
            columns.Add(dgcTuitionFee);
            var dgcNet = new DataGridViewTextBoxColumn();
            dgcNet.Name = "dgcNet";
            dgcNet.HeaderText = "Net Amount";
            dgcNet.ReadOnly = true;
            columns.Add(dgcNet);
            dgvCompanyOfEmployment.Columns.AddRange(columns.ToArray());
        }

        decimal total_regHours = 0m;
        decimal total_regDays = 0m;
        decimal total_satHours = 0m;
        decimal total_satDays = 0m;
        decimal total_holHours = 0m;
        decimal total_holDays = 0m;
        decimal total_legHours = 0m;
        decimal total_legDays = 0m;
        decimal total_guaHours = 0m;
        decimal total_guaDays = 0m;
        decimal total_nigHours = 0m;
        decimal total_nigDays = 0m;
        decimal total_tra = 0m;
        decimal total_ext = 0m;
        decimal total_gross = 0m;
        decimal total_grad = 0m;
        decimal total_tuition = 0m;
        decimal total_net = 0m;
        private void LoadInPlants(object sender, EventArgs e)
        {
            dtrs = Models.DTR.getAllByCompanyAndDateForSummary(company.ID, dtpStartDate.Value, dtpEndDate.Value);
            dgvCompanyOfEmployment.Rows.Clear();
            GenerateColumns();
            total_regHours = 0m;
            total_regDays = 0m;
            total_satHours = 0m;
            total_satDays = 0m;
            total_holHours = 0m;
            total_holDays = 0m;
            total_legHours = 0m;
            total_legDays = 0m;
            total_guaHours = 0m;
            total_guaDays = 0m;
            total_nigHours = 0m;
            total_nigDays = 0m;
            total_tra = 0m;
            total_ext = 0m;
            total_gross = 0m;
            total_grad = 0m;
            total_tuition = 0m;
            total_net = 0m;
            foreach (Models.DTR dtr in dtrs)
            {
                Models.Student student = Models.Student.getByID(dtr.StudentID);
                List<Object> values = new List<Object>();
                values.Add(dtr.ID);
                values.Add(student.GetFullName());
                decimal gross = 0m;
                if (company.RegularHour > 0)
                {
                    gross += dtr.RegularHour * company.RegularHour;
                    values.Add(dtr.RegularHour.ToString("N"));
                    values.Add((dtr.RegularHour * company.RegularHour).ToString("N"));
                    total_regHours += dtr.RegularHour * company.RegularHour;
                }
                if (company.RegularDay > 0)
                {
                    gross += dtr.RegularDay * company.RegularDay;
                    values.Add(dtr.RegularDay.ToString("N"));
                    values.Add((dtr.RegularDay * company.RegularDay).ToString("N"));
                    total_regDays += dtr.RegularDay* company.RegularDay;
                }
                if (company.SaturdayHour > 0)
                {
                    gross += dtr.SaturdayHour * company.SaturdayHour;
                    values.Add(dtr.SaturdayHour.ToString("N"));
                    values.Add((dtr.SaturdayHour * company.SaturdayHour).ToString("N"));
                    total_satHours += dtr.SaturdayHour * company.SaturdayHour;
                }
                if (company.SaturdayDay > 0)
                {
                    gross += dtr.SaturdayDay * company.SaturdayDay;
                    values.Add(dtr.SaturdayDay.ToString("N"));
                    values.Add((dtr.SaturdayDay * company.SaturdayDay).ToString("N"));
                    total_satDays += dtr.SaturdayDay * company.SaturdayDay;
                }
                if (company.HolidayHour > 0)
                {
                    gross += dtr.HolidayHour * company.HolidayHour;
                    values.Add(dtr.HolidayHour.ToString("N"));
                    values.Add((dtr.HolidayHour * company.HolidayDay).ToString("N"));
                    total_holHours += dtr.HolidayHour * company.HolidayHour;
                }
                if (company.HolidayDay > 0)
                {
                    gross += dtr.HolidayDay * company.HolidayDay;
                    values.Add(dtr.HolidayDay.ToString("N"));
                    values.Add((dtr.HolidayDay * company.HolidayDay).ToString("N"));
                    total_holDays += dtr.HolidayDay * company.HolidayDay;
                }
                if (company.LegalHolidayHour > 0)
                {
                    gross += dtr.LegalHolidayHour * company.LegalHolidayHour;
                    values.Add(dtr.LegalHolidayHour.ToString("N"));
                    values.Add((dtr.LegalHolidayHour * company.LegalHolidayHour).ToString("N"));
                    total_legHours += dtr.LegalHolidayHour * company.LegalHolidayHour;
                }
                if (company.LegalHolidayDay > 0)
                {
                    gross += dtr.LegalHolidayDay * company.LegalHolidayDay;
                    values.Add(dtr.LegalHolidayDay.ToString("N"));
                    values.Add((dtr.LegalHolidayDay * company.LegalHolidayDay).ToString("N"));
                    total_legDays += dtr.LegalHolidayDay * company.LegalHolidayDay;
                }
                if (company.GuaranteeHour > 0)
                {
                    gross += dtr.GuaranteeHour * company.GuaranteeHour;
                    values.Add(dtr.GuaranteeHour.ToString("N"));
                    values.Add((dtr.GuaranteeHour * company.GuaranteeHour).ToString("N"));
                    total_guaHours += dtr.GuaranteeHour * company.GuaranteeHour;
                }
                if (company.GuaranteeDay > 0)
                {
                    gross += dtr.GuaranteeDay * company.GuaranteeDay;
                    values.Add(dtr.GuaranteeDay.ToString("N"));
                    values.Add((dtr.GuaranteeDay * company.GuaranteeDay).ToString("N"));
                    total_guaDays += dtr.GuaranteeDay * company.GuaranteeDay;
                }
                if (company.ExtendedTime > 0)
                {
                    gross += dtr.ExtendedTime * company.ExtendedTime;
                    values.Add(dtr.ExtendedTime.ToString("N"));
                    values.Add((dtr.ExtendedTime * company.ExtendedTime).ToString("N"));
                    total_ext += dtr.ExtendedTime * company.ExtendedTime;
                }
                if (company.NightPremiumHour > 0)
                {
                    gross += dtr.NightPremiumHour * company.NightPremiumHour;
                    values.Add(dtr.NightPremiumHour.ToString("N"));
                    values.Add((dtr.NightPremiumHour * company.NightPremiumDay).ToString("N"));
                    total_nigHours += dtr.NightPremiumHour * company.NightPremiumHour;
                }
                if (company.NightPremiumDay > 0)
                {
                    gross += dtr.NightPremiumDay * company.NightPremiumDay;
                    values.Add(dtr.NightPremiumDay.ToString("N"));
                    values.Add((dtr.NightPremiumDay * company.NightPremiumDay).ToString("N"));
                    total_nigDays += dtr.NightPremiumDay * company.NightPremiumDay;
                }
                if (company.TransportationAllowance>0)
                {
                    gross += dtr.TransportationAllowance;
                    values.Add(dtr.TransportationAllowance.ToString("N"));
                    total_tra += dtr.TransportationAllowance;
                }
                //gross
                values.Add(gross.ToString("N"));
                total_gross += gross;
                //gradfee
                values.Add(0.ToString("N"));
                total_grad += 0;
                //tuitionfee
                values.Add(0.ToString("N"));
                total_tuition += 0;
                //net
                values.Add(gross.ToString("N"));
                total_net += gross;
                dgvCompanyOfEmployment.Rows.Add(values.ToArray());
            }
            List<Object> val = new List<Object>();
            val.Add(0);
            val.Add("TOTAL");
            if (company.RegularHour > 0)
            {
                val.Add("");
                val.Add(total_regHours.ToString("N"));
            }
            if (company.RegularDay > 0)
            {
                val.Add("");
                val.Add(total_regDays.ToString("N"));
            }
            if (company.SaturdayHour > 0)
            {
                val.Add("");
                val.Add(total_satHours.ToString("N"));
            }
            if (company.SaturdayDay > 0)
            {
                val.Add("");
                val.Add(total_satDays.ToString("N"));
            }
            if (company.HolidayHour > 0)
            {
                val.Add("");
                val.Add(total_holHours.ToString("N"));
            }
            if (company.HolidayDay > 0)
            {
                val.Add("");
                val.Add(total_holDays.ToString("N"));
            }
            if (company.LegalHolidayHour > 0)
            {
                val.Add("");
                val.Add(total_legHours.ToString("N"));
            }
            if (company.LegalHolidayDay > 0)
            {
                val.Add("");
                val.Add(total_legDays.ToString("N"));
            }
            if (company.GuaranteeHour > 0)
            {
                val.Add("");
                val.Add(total_guaHours.ToString("N"));
            }
            if (company.GuaranteeDay > 0)
            {
                val.Add("");
                val.Add(total_guaDays.ToString("N"));
            }
            if (company.ExtendedTime > 0)
            {
                val.Add("");
                val.Add(total_ext.ToString("N"));
            }
            if (company.NightPremiumHour > 0)
            {
                val.Add("");
                val.Add(total_nigHours.ToString("N"));
            }
            if (company.NightPremiumDay > 0)
            {
                val.Add("");
                val.Add(total_nigDays.ToString("N"));
            }
            if (company.TransportationAllowance > 0)
            {
                val.Add(total_tra.ToString("N"));
            }
            val.Add(total_gross.ToString("N"));
            val.Add(total_grad.ToString("N"));
            val.Add(total_tuition.ToString("N"));
            val.Add(total_net.ToString("N"));

            dgvCompanyOfEmployment.Rows.Add(val.ToArray());
            dgvCompanyOfEmployment.ClearSelection();
            txtAllowance.Text = total_gross.ToString("N");
            dgvCompanyOfEmployment.Rows[dgvCompanyOfEmployment.RowCount - 1].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
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

        Bitmap image;
        private void dgvCompanyOfEmployment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = dgvCompanyOfEmployment.Columns[e.ColumnIndex].Name;
            if (columnName == "dgcGradFee" || columnName == "dgcTuitionFee")
            {
                decimal gradfee = Convert.ToDecimal(dgvCompanyOfEmployment.Rows[e.RowIndex].Cells["dgcGradFee"].Value);
                decimal tuitionfee = Convert.ToDecimal(dgvCompanyOfEmployment.Rows[e.RowIndex].Cells["dgcTuitionFee"].Value);
                decimal gross = Convert.ToDecimal(dgvCompanyOfEmployment.Rows[e.RowIndex].Cells["dgcGross"].Value);
                dgvCompanyOfEmployment.Rows[e.RowIndex].Cells["dgcGradFee"].Value = gradfee.ToString("N");
                dgvCompanyOfEmployment.Rows[e.RowIndex].Cells["dgcTuitionFee"].Value = tuitionfee.ToString("N");
                dgvCompanyOfEmployment.Rows[e.RowIndex].Cells["dgcNet"].Value = (gross - (gradfee + tuitionfee)).ToString("N");
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            psPrint = false;
            btnClose.Hide();
            btnPrint.Hide();
            btnSelectCompany.Hide();
            btnPayslip.Hide();
            pnlPrint2.Show();

            dgvCompanyOfEmployment.ClearSelection();
            image = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(image, new Rectangle(0, 0, panel1.Width, panel1.Height));

            btnClose.Show();
            btnPrint.Show();
            btnSelectCompany.Show();
            btnPayslip.Show();
            pnlPrint2.Hide();

            printDocument.DefaultPageSettings.Landscape = true;
            printPreviewDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.Bicubic;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            if (psPrint)
            {
                if (psIndex < images.Count)
                {
                    Bitmap bitmap = new Bitmap(images[0].Width * 3, images[0].Height);

                    for (int i = 0; i < 3; i++)
                    {
                        if (psIndex == images.Count) break;
                        Graphics g = Graphics.FromImage(bitmap);
                        g.DrawImage(images[psIndex], i * images[0].Width, 0);
                        psIndex++;
                    }
                    e.Graphics.DrawImage(bitmap, 30, 50);
                    if (psIndex == images.Count)
                    {
                        e.HasMorePages = false;
                        psIndex = 0;
                    }
                    else
                    {
                        e.HasMorePages = true;
                    }
                }
            }
            else
            {
                e.Graphics.DrawImage(image, 30, 50);
            }
        }

        List<Bitmap> images = new List<Bitmap>();
        bool psPrint = false;
        int psIndex = 0;
        private void btnPayslip_Click(object sender, EventArgs e)
        {
            images.Clear();
            foreach (DataGridViewRow row in dgvCompanyOfEmployment.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) > 0)
                {
                    Print.Payroll statement = new Print.Payroll();
                    int id = Convert.ToInt32(row.Cells[0].Value);
                    Models.Student student = Models.Student.getByID(dtrs.Find(d => d.ID == id).StudentID);
                    Models.Batch batch = Models.Batch.GetByID(student.BatchID);
                    Models.Program program = Models.Program.getByID(batch.ProgramID);
                    statement.lblPayrollDate.Text = dtpStartDate.Value.ToShortDateString() + " - " + dtpEndDate.Value.ToShortDateString();
                    statement.lblStudentNumber.Text = student.Number;
                    statement.lblStudentName.Text = student.GetFullName();
                    statement.lblProgram.Text = program.Title + " b." + batch.Number.ToString();
                    statement.lblGross.Text = Convert.ToDecimal(row.Cells["dgcGross"].Value).ToString("N");
                    statement.lblGradFee.Text = Convert.ToDecimal(row.Cells["dgcGradFee"].Value).ToString("N");
                    statement.lblTuitionFee.Text = Convert.ToDecimal(row.Cells["dgcTuitionFee"].Value).ToString("N");
                    statement.lblNet.Text = Convert.ToDecimal(row.Cells["dgcNet"].Value).ToString("N");
                    statement.Show();
                    image = new Bitmap(statement.Width, statement.Height);
                    statement.DrawToBitmap(image, new Rectangle(0, 0, statement.Width, statement.Height));
                    statement.Close();
                    images.Add(image);
                }
            }
            psPrint = true;
            printDocument.DefaultPageSettings.Landscape = true;
            printPreviewDialog.ShowDialog();
        }

        private void txtSubsidy_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal subsidy = Convert.ToDecimal(txtSubsidy.Text);
                decimal share = subsidy - total_net;
                txtShare.Text = share.ToString("N");
            }
            catch (Exception ex) { ex = null; txtShare.Text = "0.00"; }
        }

        private void CompanyPayrollSummary_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
