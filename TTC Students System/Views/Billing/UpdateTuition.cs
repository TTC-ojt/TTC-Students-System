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

        internal decimal tuition = 0m;

        private void btnSave_Click(object sender, EventArgs e)
        {
            tuition = nudTuition.Value;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
