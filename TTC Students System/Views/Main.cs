using System.Windows.Forms;
using System.Drawing;
using System;
using MySql.Connection;

namespace GN.TTC.Students.Views
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            cMain = new Controllers.Main(this);
        }

        internal Controllers.Main cMain;
        
        private void Main_Load(object sender, System.EventArgs e)
        {
            Builder.UserID = Properties.Settings.Default.UserID;
            Builder.Password = Properties.Settings.Default.Password;
            Builder.Database = Properties.Settings.Default.Database;
            Builder.Server = Properties.Settings.Default.Server;
            Builder.Port = Properties.Settings.Default.Port;
            MdiClient control = null;
            foreach (var ctrl in this.Controls)
            {
                try
                {
                    control = (MdiClient)ctrl;
                    control.BackColor = Color.Silver;
                }
                catch {}
            }
            lblDateTime.Text = DateTime.Now.ToString("MMMM dd, yyyy   hh:mm:ss tt");
            cMain.StartSystem();
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("MMMM dd, yyyy   hh:mm:ss tt");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            foreach (Form form in MdiChildren)
            {
                if (form.Name != "Home")
                {
                    form.Close();
                }
            }
            cMain.StartSystem();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
