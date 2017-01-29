using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace GN.TTC.Students.Views.Billing
{
    public partial class Pay : Form
    {
        internal Pay(Controllers.Billing cBilling)
        {
            InitializeComponent();
            this.cBilling = cBilling;
        }

        private Controllers.Billing cBilling;

        private Models.Student student = new Models.Student();
        private Models.Batch batch = new Models.Batch();
        private Models.Program program = new Models.Program();
        private List<Models.Student> students = new List<Models.Student>();
        private List<Models.Transaction> transactions = new List<Models.Transaction>();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cBilling.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //LoadStudent();
        }

        private void LoadStudent()
        {
            lblStudentNumber.Text = student.Number;
            lblStudentName.Text = student.GetFullName();
            batch = Models.Batch.GetByID(student.BatchID);
            program = Models.Program.getByID(batch.ProgramID);
            lblCOPR.Text = program.Copr;
            lblProgramTitle.Text = program.Title;
            lblBatch.Text = batch.Number.ToString();
            LoadTransactions();
        }

        private void LoadTransactions()
        {
            lblCurrentBalance.Text = Models.Transaction.GetBalance(student.ID).ToString("N");
            transactions = Models.Transaction.getTransactionsByStudent(student.ID);
            dgvPaymentHistory.Rows.Clear();
            foreach (Models.Transaction transaction in transactions)
            {
                dgvPaymentHistory.Rows.Add(transaction.Code, transaction.DateTime, transaction.Amount);
            }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Models.Transaction transaction = new Models.Transaction();
            transaction.StudentID = student.ID;
            transaction.Code = txtORNumber.Text;
            transaction.Amount = nudAmount.Value;
            transaction.Save();
            LoadTransactions();
            nudAmount.Value = 0m;
            txtCash.Clear();
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal cash = Convert.ToDecimal(txtCash.Text);
                txtChange.Text = (cash - nudAmount.Value).ToString("N");
            }
            catch (Exception ex)
            {
                ex = null;
                txtChange.Text = (0m).ToString("N");
            }
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
    }
}
