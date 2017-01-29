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
    public partial class EditAssessment : Form
    {
        public EditAssessment()
        {
            InitializeComponent();
        }

        internal Models.Assessment assessment = new Models.Assessment();

        private void btnSave_Click(object sender, EventArgs e)
        {
            assessment.Date = dtpDate.Value;
            assessment.Result = txtResult.Text;
            assessment.Save();
            this.Close();
        }

        private void EditAssessment_Load(object sender, EventArgs e)
        {
            dtpDate.Value = assessment.Date;
            txtResult.Text = assessment.Result;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
