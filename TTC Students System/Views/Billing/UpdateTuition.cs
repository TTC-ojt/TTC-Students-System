using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Billing
{
    public partial class UpdateTuition : Form
    {
        public UpdateTuition()
        {
            InitializeComponent();
        }

        internal Models.Student student = new Models.Student();

        private void btnSave_Click(object sender, EventArgs e)
        {
            student.Tuition = nudTuition.Value;
            student.Save();
            this.Close();
        }

        private void UpdateGraduate_Load(object sender, EventArgs e)
        {
            lblStudentNumber.Text = student.Number;
            lblFullName.Text = student.GetFullName();
            lblTuition.Text = student.Tuition.ToString("N");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
