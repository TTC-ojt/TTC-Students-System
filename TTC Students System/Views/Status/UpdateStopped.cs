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
    public partial class UpdateStopped : Form
    {
        public UpdateStopped()
        {
            InitializeComponent();
        }

        internal Models.Student student = new Models.Student();
        internal Models.Stop stop = new Models.Stop();

        private void btnSave_Click(object sender, EventArgs e)
        {
            stop.StudentID = student.ID;
            stop.Reason = txtReason.Text;
            stop.Save();
            student.Status = "STOPPED";
            student.Save();
            this.Close();
        }

        private void UpdateGraduate_Load(object sender, EventArgs e)
        {
            stop = Models.Stop.getByStudent(student.ID);
            txtReason.Text = stop.Reason;
            lblStudentNumber.Text = student.Number;
            lblFullName.Text = student.GetFullName();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
