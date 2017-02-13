using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GN.TTC.Students.Views
{
    public partial class ExportToExcel : Form
    {
        internal ExportToExcel(Controllers.Maintenance cMaintenance)
        {
            InitializeComponent();
            this.cMaintenance = cMaintenance;
        }

        Controllers.Maintenance cMaintenance;
        
        DataTable table = new DataTable();
        BindingSource source = new BindingSource();
        MySqlDataAdapter adapter = new MySqlDataAdapter();

        internal Models.Program program = new Models.Program();
        internal Models.Batch batch = new Models.Batch();

        private void ChooseProgram_Load(object sender, EventArgs e)
        {
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (batch.ID > 0)
            {
                table = new DataTable();
                Print.ExcelExport ex = new Print.ExcelExport();
                ex.dgvExport.DataSource = source;
                adapter = Models.Student.GetDataAdapter(batch.ID);
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.Fill(table);
                source.DataSource = table;
                ex.Show();
                ex.Close();
            }
        }

        private void dgvChooseProgram_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            cMaintenance.Close();
        }

        private void btnChangeCourse_Click(object sender, EventArgs e)
        {
            ChooseProgram vCProgram = new ChooseProgram();
            vCProgram.ShowDialog();
            program = vCProgram.program;
            if (program != null) LoadProgram();
        }

        private void LoadProgram()
        {
            txtCopr.Text = program.Copr;
            txtProgramTitle.Text = program.Title;
            LoadBatches();
        }
        private void LoadBatches()
        {
            List<Models.Batch> batches = Models.Batch.GetAllByProgram(program.ID);
            cbxBatch.Items.Clear();
            foreach (Models.Batch batch in batches)
            {
                cbxBatch.Items.Add(batch.Number);
            }
            cbxBatch.SelectedIndex = cbxBatch.Items.Count - 1;
        }
        private void cbxBatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            short Number = Convert.ToInt16(cbxBatch.SelectedItem);
            batch = Models.Batch.GetByProgramAndNumber(program.ID, Number);
            btnSelect.Enabled = true;
        }

        private void btnBatchesSummary_Click(object sender, EventArgs e)
        {

        }

        private void btnInPlantSummary_Click(object sender, EventArgs e)
        {
            table = new DataTable();
            Print.ExcelExport ex = new Print.ExcelExport();
            ex.dgvExport.DataSource = source;
            adapter = Models.InPlant.GetDataAdapter();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);
            source.DataSource = table;
            ex.Show();
            ex.Close();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void txtProgramTitle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
