using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Registration
{
    public partial class Examinations : Form
    {
        internal Examinations(Controllers.Registration cRegistration)
        {
            InitializeComponent();
            this.cRegistration = cRegistration;
        }

        private Controllers.Registration cRegistration;

        private void Examinations_FormClosing(object sender, FormClosingEventArgs e)
        {
            //matb
            cRegistration.mMATB.Reading = txtMATB_reading.Text;
            cRegistration.mMATB.eReading = txtMATB_ereading.Text;
            cRegistration.mMATB.Mechanical = txtMATB_mechanical.Text;
            cRegistration.mMATB.eMechanical = txtMATB_emechanical.Text;
            cRegistration.mMATB.Math = txtMATB_math.Text;
            cRegistration.mMATB.eMath = txtMATB_emath.Text;
            //ncae
            cRegistration.mNCAE.General = txtNCAE_general.Text;
            cRegistration.mNCAE.Technical = txtNCAE_technical.Text;
            cRegistration.mNCAE.NonVerbal = txtNCAE_nonverbal.Text;
            cRegistration.mNCAE.FirstField = cbxNCAE_1stfield.SelectedItem.ToString();
            cRegistration.mNCAE.SecondField = cbxNCAE_2ndfield.SelectedItem.ToString();
            //yp4sc
            cRegistration.mYP4SC.Enterprising = txtYP4SC_enterprising.Text;
            cRegistration.mYP4SC.Investigative = txtYP4SC_investigative.Text;
            cRegistration.mYP4SC.Social = txtYP4SC_social.Text;
            cRegistration.mYP4SC.Realistic = txtYP4SC_realistic.Text;
            cRegistration.mYP4SC.Conventional = txtYP4SC_conventional.Text;
            cRegistration.mYP4SC.Artistic = txtYP4SC_artistic.Text;
            cRegistration.mYP4SC.FirstLevel = cbxYP4SC_1stlevel.SelectedItem.ToString();
            cRegistration.mYP4SC.SecondLevel = cbxYP4SC_2ndlevel.SelectedItem.ToString();
            cRegistration.mYP4SC.ThirdLevel = cbxYP4SC_3rdlevel.SelectedItem.ToString();
        }

        private void Examinations_Load(object sender, EventArgs e)
        {
            cbxNCAE_1stfield.SelectedIndex = 0;
            cbxNCAE_2ndfield.SelectedIndex = 0;
            cbxYP4SC_1stlevel.SelectedIndex = 0;
            cbxYP4SC_2ndlevel.SelectedIndex = 0;
            cbxYP4SC_3rdlevel.SelectedIndex = 0;
        }
    }
}
