using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Students
{
    public partial class Examinations : Form
    {
        internal Examinations()
        {
            InitializeComponent();
        }

        internal Models.Student student;

        Models.MATB MATB = new Models.MATB();
        Models.NCAE NCAE = new Models.NCAE();
        Models.YP4SC YP4SC = new Models.YP4SC();

        private void Examinations_Load(object sender, EventArgs e)
        {
            MATB = Models.MATB.getByStudent(student.ID);
            txtMATB_reading.Text = MATB.Reading;
            txtMATB_ereading.Text = MATB.eReading;
            txtMATB_mechanical.Text = MATB.Mechanical;
            txtMATB_emechanical.Text = MATB.eMechanical;
            txtMATB_math.Text = MATB.Math;
            txtMATB_emath.Text = MATB.eMath;

            NCAE = Models.NCAE.getByStudent(student.ID);
            txtNCAE_general.Text = NCAE.General;
            txtNCAE_technical.Text = NCAE.Technical;
            txtNCAE_nonverbal.Text = NCAE.NonVerbal;
            cbxNCAE_1stfield.SelectedIndex = cbxNCAE_1stfield.FindStringExact(NCAE.FirstField);
            cbxNCAE_2ndfield.SelectedIndex = cbxNCAE_2ndfield.FindStringExact(NCAE.SecondField);

            YP4SC = Models.YP4SC.getByStudent(student.ID);
            txtYP4SC_enterprising.Text = YP4SC.Enterprising;
            txtYP4SC_investigative.Text = YP4SC.Investigative;
            txtYP4SC_social.Text = YP4SC.Social;
            txtYP4SC_realistic.Text = YP4SC.Realistic;
            txtYP4SC_conventional.Text = YP4SC.Conventional;
            txtYP4SC_artistic.Text = YP4SC.Artistic;
            cbxYP4SC_1stlevel.SelectedIndex = cbxYP4SC_1stlevel.FindStringExact(YP4SC.FirstLevel);
            cbxYP4SC_2ndlevel.SelectedIndex = cbxYP4SC_2ndlevel.FindStringExact(YP4SC.SecondLevel);
            cbxYP4SC_3rdlevel.SelectedIndex = cbxYP4SC_3rdlevel.FindStringExact(YP4SC.ThirdLevel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //matb
            MATB.Reading = txtMATB_reading.Text;
            MATB.eReading = txtMATB_ereading.Text;
            MATB.Mechanical = txtMATB_mechanical.Text;
            MATB.eMechanical = txtMATB_emechanical.Text;
            MATB.Math = txtMATB_math.Text;
            MATB.eMath = txtMATB_emath.Text;
            MATB.Save();
            //ncae
            NCAE.General = txtNCAE_general.Text;
            NCAE.Technical = txtNCAE_technical.Text;
            NCAE.NonVerbal = txtNCAE_nonverbal.Text;
            NCAE.FirstField = cbxNCAE_1stfield.SelectedItem.ToString();
            NCAE.SecondField = cbxNCAE_2ndfield.SelectedItem.ToString();
            NCAE.Save();
            //yp4sc
            YP4SC.Enterprising = txtYP4SC_enterprising.Text;
            YP4SC.Investigative = txtYP4SC_investigative.Text;
            YP4SC.Social = txtYP4SC_social.Text;
            YP4SC.Realistic = txtYP4SC_realistic.Text;
            YP4SC.Conventional = txtYP4SC_conventional.Text;
            YP4SC.Artistic = txtYP4SC_artistic.Text;
            YP4SC.FirstLevel = cbxYP4SC_1stlevel.SelectedItem.ToString();
            YP4SC.SecondLevel = cbxYP4SC_2ndlevel.SelectedItem.ToString();
            YP4SC.ThirdLevel = cbxYP4SC_3rdlevel.SelectedItem.ToString();
            YP4SC.Save();
        }
    }
}
