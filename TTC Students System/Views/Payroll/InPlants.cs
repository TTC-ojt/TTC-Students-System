using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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

        private Models.Student student = new Models.Student();
        private List<Models.Student> students = new List<Models.Student>();

        private Controllers.Payroll cPayroll;

        List<Models.InPlant> inplants = new List<Models.InPlant>();
        Models.InPlant inplant = new Models.InPlant();
        Models.Company company = new Models.Company();
        private Bitmap img;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (student.ID > 0)
            {
                status = student.Status;
                if (inplant.ID == 0) inplant = Models.InPlant.getByStudent(student.ID);
                inplant.CompanyID = company.ID;
                inplant.StartDate = dtpStartDate.Value;
                inplant.EndDate = dtpEndDate.Value;
                inplant.StudentID = student.ID;
                inplant.Save();
                student.Status = "IN-PLANT";
                student.Save();
                LoadInPlants(sender, e);
            }
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

        private void LoadInPlants(object sender, EventArgs e)
        {
            inplants = Models.InPlant.getAllByCompany(company.ID);
            dgvCompanyOfEmployment.Rows.Clear();
            int c = 1;
            foreach (Models.InPlant inplant in inplants)
            {
                Models.Student student = Models.Student.getByID(inplant.StudentID);
                dgvCompanyOfEmployment.Rows.Add(inplant.ID,c,student.GetFullName(), inplant.StartDate.ToShortDateString(), inplant.EndDate.ToShortDateString());
                c++;
            }
            dgvCompanyOfEmployment.ClearSelection();
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

        private void btnDelete_Click(object sender, EventArgs e)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.TextLength > 2)
            {
                students = Models.Student.Find(txtSearch.Text, 0, 0);
                lbxStudents.Items.Clear();
                foreach (Models.Student student in students)
                {
                    if (txtSearch.Text.Any(char.IsDigit))
                    {
                        lbxStudents.Items.Add(student.Number);
                    }
                    else
                    {
                        lbxStudents.Items.Add(student.GetFullName());
                    }
                }
                lbxStudents.Show();
            }
            else
            {
                lbxStudents.Hide();
            }
        }

        private void LoadStudent()
        {
            lblStudentNumber.Text = student.Number;
            lblStudentName.Text = student.GetFullName();
        }

        private void lbxStudents_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && lbxStudents.SelectedIndex > -1)
            {
                txtSearch.Clear();
                student = students[lbxStudents.SelectedIndex];
                lbxStudents.Hide();
                LoadStudent();
            }
        }

        private void dgvCompanyOfEmployment_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCompanyOfEmployment.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCompanyOfEmployment.SelectedRows[0].Cells[0].Value);
                inplant = inplants.Find(i => i.ID == id);
                student = Models.Student.getByID(inplant.StudentID);
                txtSearch.Enabled = false;
            } else
            {
                inplant = new Models.InPlant();
                student = new Models.Student();
                txtSearch.Enabled = true;
            }
            lblStudentNumber.Text = "Student #: " + student.Number;
            lblStudentName.Text = "Student Name: " + student.GetFullName();
            dtpStartDate.Value = inplant.StartDate;
            dtpEndDate.Value = inplant.EndDate;
        }

        private void lbxStudents_MouseClick(object sender, MouseEventArgs e)
        {
            if (lbxStudents.SelectedIndex > -1)
            {
                txtSearch.Clear();
                student = students[lbxStudents.SelectedIndex];
                lbxStudents.Hide();
                LoadStudent();
            }
        }

        private void InPlants_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgvCompanyOfEmployment.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
