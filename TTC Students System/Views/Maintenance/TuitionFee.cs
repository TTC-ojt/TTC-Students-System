using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GN.TTC.Students.Views.Maintenance
{
    public partial class TuitionFee : Form
    {
        internal TuitionFee(Controllers.Maintenance cMaintenance)
        {
            InitializeComponent();
            this.cMaintenance = cMaintenance;
        }
        private Controllers.Maintenance cMaintenance;

        private Models.Program program;
        List<Models.Program> programs = new List<Models.Program>();
        private Bitmap image;

        private void loadPrograms()
        {
            programs = Models.Program.getAll();
            dgvProgramFees.Rows.Clear();
            int c = 1;
            foreach(Models.Program program in programs)
            {
                dgvProgramFees.Rows.Add(program.ID, c, program.Copr, program.Title, program.Tuition);
                c++;
            }
            dgvProgramFees.ClearSelection();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cMaintenance.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            program.Tuition = nudTuition.Value;
            program.DownPayment = nudDownPayment.Value;
            program.FirstPayment = nud1stPayment.Value;
            program.SecondPayment = nud2ndPayment.Value;
            program.ThirdPayment = nud3rdPayment.Value;
            program.FourthPayment = nud4thPayment.Value;
            program.Save();
            loadPrograms();
        }

        private void TuitionFee_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dgvProgramFees.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            cbxCopies.SelectedIndex = 0;
            loadPrograms();
        }

        private void dgvSchoolFees_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvProgramFees.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvProgramFees.SelectedRows[0].Cells[0].Value);
                program = programs.Find(p => p.ID == id);
            }
            else
            {
                program = new Models.Program();
            }
            txtCopr.Text = program.Copr;
            txtProgramTitle.Text = program.Title;
            nudTuition.Value = program.Tuition;
            nudDownPayment.Value = program.DownPayment;
            nud1stPayment.Value = program.FirstPayment;
            nud2ndPayment.Value = program.SecondPayment;
            nud3rdPayment.Value = program.ThirdPayment;
            nud4thPayment.Value = program.FourthPayment;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            program.Tuition = nudTuition.Value;
            program.DownPayment = nudDownPayment.Value;
            program.FirstPayment = nud1stPayment.Value;
            program.SecondPayment = nud2ndPayment.Value;
            program.ThirdPayment = nud3rdPayment.Value;
            program.FourthPayment = nud4thPayment.Value;
            program.Save();
            images.Clear();
            int copies = Convert.ToInt32(cbxCopies.SelectedItem);
            for (int i = 0; i < copies; i++)
            {
                Print.TuitionBreakdown breakdown = new Print.TuitionBreakdown();
                breakdown.lblProgramTitle.Text = program.Title;
                breakdown.lblDownpayment.Text = program.DownPayment.ToString("N");
                breakdown.lbl1stPayment.Text = program.FirstPayment.ToString("N");
                breakdown.lbl2ndPayment.Text = program.SecondPayment.ToString("N");
                breakdown.lbl3rdPayment.Text = program.ThirdPayment.ToString("N");
                breakdown.lbl4thPayment.Text = program.FourthPayment.ToString("N");
                breakdown.lblTotalTuition.Text = program.Tuition.ToString("N");
                breakdown.Show();
                image = new Bitmap(breakdown.Width, breakdown.Height);
                breakdown.DrawToBitmap(image, new Rectangle(0, 0, breakdown.Width, breakdown.Height));
                breakdown.Close();
                images.Add(image);
            }
            psPrint = true;
            printDocument.DefaultPageSettings.Landscape = true;
            printPreviewDialog.ShowDialog();
        }

        List<Bitmap> images = new List<Bitmap>();
        bool psPrint = false;
        int psIndex = 0;
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.Bicubic;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            if (psPrint)
            {
                if (psIndex < images.Count)
                {
                    Bitmap bitmap = new Bitmap(images[0].Width * 3, images[0].Height);

                    for (int i = 0; i < 3; i++)
                    {
                        if (psIndex == images.Count) break;
                        Graphics g = Graphics.FromImage(bitmap);
                        g.DrawImage(images[psIndex], i * images[0].Width, 0);
                        psIndex++;
                    }
                    e.Graphics.DrawImage(bitmap, 30, 50);
                    if (psIndex == images.Count)
                    {
                        e.HasMorePages = false;
                        psIndex = 0;
                    }
                    else
                    {
                        e.HasMorePages = true;
                    }
                }
            }
            else
            {
                e.Graphics.DrawImage(image, 30, 50);
            }
        }

        private void nudTuition_ValueChanged(object sender, EventArgs e)
        {
            nudDownPayment.Value = nudTuition.Value - (nudTuition.Value * 0.65m);
        }

        private void nudDownPayment_ValueChanged(object sender, EventArgs e)
        {
            nud1stPayment.Value = (nudTuition.Value - nudDownPayment.Value) / 4;
            nud4thPayment.Value = nud3rdPayment.Value = nud2ndPayment.Value = nud1stPayment.Value;
        }
    }
}
