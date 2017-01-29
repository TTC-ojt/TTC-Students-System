using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Status
{
    public partial class UpdateDropped : Form
    {
        public UpdateDropped()
        {
            InitializeComponent();
        }

        internal Models.Student student = new Models.Student();
        internal Models.Drop drop = new Models.Drop();

        private void btnSave_Click(object sender, EventArgs e)
        {
            drop.StudentID = student.ID;
            drop.Reason = txtReason.Text;
            drop.Save();
            student.Status = "DROPPED";
            student.Save();
            this.Close();
        }

        private void UpdateGraduate_Load(object sender, EventArgs e)
        {
            lblStudentNumber.Text = student.Number;
            lblFullName.Text = student.GetFullName();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
