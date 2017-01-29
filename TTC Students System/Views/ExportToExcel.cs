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
        public ExportToExcel()
        {
            InitializeComponent();
        }
        
        DataTable table = new DataTable();
        DataSet source = new DataSet();
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
                adapter = Models.Student.GetDataAdapter(batch.ID);
                source.Locale = System.Globalization.CultureInfo.CurrentCulture;
                adapter.Fill(table);
                source.Tables.Add(table);
                
                ExcelLibrary.DataSetHelper.CreateWorkbook(AppDomain.CurrentDomain.BaseDirectory + "/mis.xls", source);
            }
        }

        private void dgvChooseProgram_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            source = new DataSet();
            adapter = Models.InPlant.GetDataAdapter();
            source.Locale = System.Globalization.CultureInfo.CurrentCulture;
            adapter.Fill(table);
            source.Tables.Add(table);

            ExcelLibrary.DataSetHelper.CreateWorkbook(AppDomain.CurrentDomain.BaseDirectory + "/inplants.xls", source);
        }
    }
}
