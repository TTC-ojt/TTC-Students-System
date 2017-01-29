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
    public partial class ChooseProgram : Form
    {
        public ChooseProgram()
        {
            InitializeComponent();
        }

        List<Models.Program> programs;
        internal Models.Program program = new Models.Program();

        private void ChooseProgram_Load(object sender, EventArgs e)
        {
            programs = Models.Program.getAll();
            dgvChooseProgram.Rows.Clear();
            foreach (var program in programs)
            {
                string duration = "";
                if(program.OneYear)
                {
                    duration = "One Year";
                }
                if(program.ShortCourse)
                {
                    duration = "Short Course";
                }
                dgvChooseProgram.Rows.Add(program.ID, program.Copr, program.Title, duration);
            }
            dgvChooseProgram.ClearSelection();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvChooseProgram.SelectedRows[0].Cells[0].Value);
            program = programs.Find(p => p.ID == id);
            this.Close();
        }

        private void dgvChooseProgram_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvChooseProgram.SelectedRows.Count > 0)
            {
                btnSelect.Enabled = true;
            }
            else
            {
                btnSelect.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
