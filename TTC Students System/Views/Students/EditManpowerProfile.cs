using System;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Status
{
    public partial class EditManpowerProfile : Form
    {
        public EditManpowerProfile()
        {
            InitializeComponent();
        }

        internal Models.Student student = new Models.Student();
        internal Models.Profile profile = new Models.Profile();
        internal Models.Contact contact = new Models.Contact();

        private void btnSave_Click(object sender, EventArgs e)
        {
            student.LastName = txtLastName.Text;
            student.FirstName = txtFirstName.Text;
            student.MiddleName = txtMiddleName.Text;
            student.ExtName = txtExtName.Text;
            student.Save();
            profile.Nationality = txtNationality.Text;
            profile.Save();
            contact.Street = txtStreet.Text;
            contact.Barangay = txtBarangay.Text;
            contact.City = txtCity.Text;
            contact.District = txtDistrict.Text;
            contact.Province = txtProvince.Text;
            contact.Region = txtRegion.Text;
            contact.Email = txtEmail.Text;
            contact.Phone = txtPhone.Text;
            contact.Save();
            this.Close();
        }

        private void EditManpowerProfile_Load(object sender, EventArgs e)
        {
            profile = Models.Profile.getByStudent(student.ID);
            contact = Models.Contact.getContactByStudent(student.ID);

            txtLastName.Text = student.LastName;
            txtFirstName.Text = student.FirstName;
            txtMiddleName.Text = student.MiddleName;

            txtStreet.Text = contact.Street;
            txtBarangay.Text = contact.Barangay;
            txtCity.Text = contact.City;
            txtDistrict.Text = contact.District;
            txtProvince.Text = contact.Province;
            txtRegion.Text = contact.Region;

            txtEmail.Text = contact.Email;
            txtPhone.Text = contact.Phone;
            txtNationality.Text = profile.Nationality;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
