using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Payroll
{
    public partial class InPlants : Form
    {
        internal InPlants(Controllers.Payroll cPayroll)
        {
            InitializeComponent();
            this.cPayroll = cPayroll;
        }

        string status = "";
        private Controllers.Payroll cPayroll;
        List<Models.InPlant> inplants = new List<Models.InPlant>();
        Models.InPlant inplant = new Models.InPlant();
        Models.Company company = new Models.Company();
        private Bitmap img;

        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckDataGrid();
            foreach (DataGridViewRow row in dgvCompanyOfEmployment.Rows)
            {
                int id = Convert.ToInt32(row.Cells[0].Value);
                inplant = inplants.Find(c => c.ID == id);
                if (company.TransportationAllowance>0)
                {
                    //inplant.TransportationAllowance = Convert.ToDecimal(row.Cells["dgcTransportationAllowance"].Value);
                }
                inplant.Save();
            }
            LoadInPlants(sender, e);
        }

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
            SelectStudent ss = new SelectStudent();
            ss.ShowDialog();
            Models.Student student = ss.student;
            status = student.Status;
            Models.InPlant inplant = Models.InPlant.getByStudent(student.ID);
            inplant.CompanyID = company.ID;
            inplant.StartDate = dtpStartDate.Value;
            inplant.EndDate = dtpEndDate.Value;
            inplant.StudentID = student.ID;
            inplant.Save();
            student.Status = "IN-PLANT";
            student.Save();
            LoadInPlants(sender, e);
        }

        private void LoadInPlants(object sender, EventArgs e)
        {
            inplants = Models.InPlant.getAllByCompanyAndDate(company.ID, dtpStartDate.Value, dtpEndDate.Value);
            dgvCompanyOfEmployment.Rows.Clear();
            foreach (Models.InPlant inplant in inplants)
            {
                Models.Student student = Models.Student.getByID(inplant.StudentID);
                dgvCompanyOfEmployment.Rows.Add(inplant.ID,student.Number,student.GetFullName());
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

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (dgvCompanyOfEmployment.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCompanyOfEmployment.SelectedRows[0].Cells[0].Value);
                inplant = inplants.Find(i => i.ID == id);
                Models.Student student = Models.Student.getByID(inplant.StudentID);
                if (status.Length > 0)
                {
                    student.Status = status;
                    
                } else
                {
                    student.Status = "FLOATER";
                }
                student.Save();
                inplant.Delete();
            }
            LoadInPlants(sender, e);
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
