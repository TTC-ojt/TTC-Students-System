using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Maintenance
{
    public partial class TVETProvidersProfile : Form
    {
        internal TVETProvidersProfile(Controllers.Maintenance cMaintenance)
        {
            InitializeComponent();
            this.cMaintenance = cMaintenance;
        }

        private Controllers.Maintenance cMaintenance;

        Models.Provider mProvider = new Models.Provider();
        
        private void TVETProvidersProfile_Load(object sender, EventArgs e)
        {
            mProvider = Models.Provider.GetDefault();
            txtRegion.Text = mProvider.Region;
            txtProvince.Text = mProvider.Province;
            txtDistrict.Text = mProvider.District;
            txtMunicipality.Text = mProvider.City;
            txtProvider.Text = mProvider.Name;
            txtProviderAddress.Text = mProvider.Address;
            txtTypeOfProvider.Text = mProvider.Type;
            txtClassification.Text = mProvider.Classification;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mProvider.Region = txtRegion.Text;
            mProvider.Province = txtProvince.Text;
            mProvider.District = txtDistrict.Text;
            mProvider.City = txtMunicipality.Text;
            mProvider.Name = txtProvider.Text;
            mProvider.Address = txtProviderAddress.Text;
            mProvider.Type = txtTypeOfProvider.Text;
            mProvider.Classification = txtClassification.Text;
            mProvider.Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cMaintenance.Close();
        }
    }
}
