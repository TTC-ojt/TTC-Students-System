using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Payroll
{
    public partial class ComputeTime : Form
    {
        internal ComputeTime()
        {
            InitializeComponent();
        }

        internal decimal Hours = 0;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Hours = Convert.ToDecimal(txtHours.Text);
            Close();
        }

        private void CountTime(object sender, EventArgs e)
        {
            TimeSpan diff = dtpTimeOut.Value.TimeOfDay - dtpTimeIn.Value.TimeOfDay;
            Hours = Convert.ToDecimal(diff.TotalHours);
            DateTime lunch = DateTime.Today;
            lunch.AddHours(11.75);
            if (!chbLunch.Checked && dtpTimeOut.Value.Hour > 12)
            {
                Hours -= 1;
            }
            txtHours.Text = Hours.ToString("N");
        }

        private void ComputeTime_Load(object sender, EventArgs e)
        {
            dtpTimeIn.Value = DateTime.Today.AddHours(7);
            dtpTimeOut.Value = DateTime.Today.AddHours(16);
        }
    }
}
