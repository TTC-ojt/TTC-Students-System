namespace GN.TTC.Students.Views.Status
{
    partial class StudentsStatus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentsStatus));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxBatch = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCopr = new System.Windows.Forms.TextBox();
            this.txtProgramTitle = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnChangeCourse = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInplant = new System.Windows.Forms.Button();
            this.btnInSchool = new System.Windows.Forms.Button();
            this.btnFloaters = new System.Windows.Forms.Button();
            this.btnStopped = new System.Windows.Forms.Button();
            this.btnGraduate = new System.Windows.Forms.Button();
            this.btnDropped = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.rbtnStopped = new System.Windows.Forms.RadioButton();
            this.rbtnDropped = new System.Windows.Forms.RadioButton();
            this.rbtnGraduate = new System.Windows.Forms.RadioButton();
            this.rbtnInplant = new System.Windows.Forms.RadioButton();
            this.rbtnFloaters = new System.Windows.Forms.RadioButton();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.rbtnInschool = new System.Windows.Forms.RadioButton();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.colStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ULI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cbxBatch);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.txtCopr);
            this.panel1.Controls.Add(this.txtProgramTitle);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.btnChangeCourse);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnInplant);
            this.panel1.Controls.Add(this.btnInSchool);
            this.panel1.Controls.Add(this.btnFloaters);
            this.panel1.Controls.Add(this.btnStopped);
            this.panel1.Controls.Add(this.btnGraduate);
            this.panel1.Controls.Add(this.btnDropped);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.dgvStudents);
            this.panel1.Controls.Add(this.grpFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 623);
            this.panel1.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(62, 47);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(271, 25);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(333, 47);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(37, 25);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 99;
            this.label7.Text = "Student:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbxBatch
            // 
            this.cbxBatch.BackColor = System.Drawing.Color.White;
            this.cbxBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBatch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBatch.FormattingEnabled = true;
            this.cbxBatch.Location = new System.Drawing.Point(652, 109);
            this.cbxBatch.Margin = new System.Windows.Forms.Padding(3, 6, 0, 3);
            this.cbxBatch.Name = "cbxBatch";
            this.cbxBatch.Size = new System.Drawing.Size(99, 25);
            this.cbxBatch.TabIndex = 3;
            this.cbxBatch.SelectedIndexChanged += new System.EventHandler(this.cbxBatch_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(649, 87);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 16);
            this.label20.TabIndex = 97;
            this.label20.Text = "Batch #:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(165, 88);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 16);
            this.label19.TabIndex = 94;
            this.label19.Text = "Program Title:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCopr
            // 
            this.txtCopr.BackColor = System.Drawing.Color.White;
            this.txtCopr.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCopr.Location = new System.Drawing.Point(6, 109);
            this.txtCopr.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.txtCopr.Name = "txtCopr";
            this.txtCopr.ReadOnly = true;
            this.txtCopr.Size = new System.Drawing.Size(162, 25);
            this.txtCopr.TabIndex = 93;
            // 
            // txtProgramTitle
            // 
            this.txtProgramTitle.BackColor = System.Drawing.Color.White;
            this.txtProgramTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgramTitle.Location = new System.Drawing.Point(168, 109);
            this.txtProgramTitle.Margin = new System.Windows.Forms.Padding(0, 6, 0, 5);
            this.txtProgramTitle.Name = "txtProgramTitle";
            this.txtProgramTitle.ReadOnly = true;
            this.txtProgramTitle.Size = new System.Drawing.Size(372, 25);
            this.txtProgramTitle.TabIndex = 95;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(7, 88);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 16);
            this.label18.TabIndex = 92;
            this.label18.Text = "CoPR #:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChangeCourse
            // 
            this.btnChangeCourse.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnChangeCourse.AutoSize = true;
            this.btnChangeCourse.BackColor = System.Drawing.Color.Silver;
            this.btnChangeCourse.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnChangeCourse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.btnChangeCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeCourse.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeCourse.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeCourse.Image")));
            this.btnChangeCourse.Location = new System.Drawing.Point(543, 109);
            this.btnChangeCourse.Margin = new System.Windows.Forms.Padding(0, 5, 3, 3);
            this.btnChangeCourse.Name = "btnChangeCourse";
            this.btnChangeCourse.Size = new System.Drawing.Size(77, 25);
            this.btnChangeCourse.TabIndex = 2;
            this.btnChangeCourse.Text = "SELECT";
            this.btnChangeCourse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangeCourse.UseVisualStyleBackColor = false;
            this.btnChangeCourse.Click += new System.EventHandler(this.btnChangeCourse_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkGreen;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(753, 37);
            this.label5.TabIndex = 54;
            this.label5.Text = "STUDENT STATUS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(3, 558);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 59);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInplant
            // 
            this.btnInplant.BackColor = System.Drawing.Color.Silver;
            this.btnInplant.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnInplant.FlatAppearance.BorderSize = 2;
            this.btnInplant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInplant.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInplant.Location = new System.Drawing.Point(644, 306);
            this.btnInplant.Name = "btnInplant";
            this.btnInplant.Size = new System.Drawing.Size(114, 45);
            this.btnInplant.TabIndex = 7;
            this.btnInplant.Text = "In Plant";
            this.btnInplant.UseVisualStyleBackColor = false;
            this.btnInplant.Click += new System.EventHandler(this.btnInplant_Click);
            // 
            // btnInSchool
            // 
            this.btnInSchool.BackColor = System.Drawing.Color.Silver;
            this.btnInSchool.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnInSchool.FlatAppearance.BorderSize = 2;
            this.btnInSchool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInSchool.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInSchool.Location = new System.Drawing.Point(644, 204);
            this.btnInSchool.Name = "btnInSchool";
            this.btnInSchool.Size = new System.Drawing.Size(114, 45);
            this.btnInSchool.TabIndex = 5;
            this.btnInSchool.Text = "In School";
            this.btnInSchool.UseVisualStyleBackColor = false;
            this.btnInSchool.Click += new System.EventHandler(this.btnInSchool_Click);
            // 
            // btnFloaters
            // 
            this.btnFloaters.BackColor = System.Drawing.Color.Silver;
            this.btnFloaters.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnFloaters.FlatAppearance.BorderSize = 2;
            this.btnFloaters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFloaters.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFloaters.Location = new System.Drawing.Point(644, 255);
            this.btnFloaters.Name = "btnFloaters";
            this.btnFloaters.Size = new System.Drawing.Size(114, 45);
            this.btnFloaters.TabIndex = 6;
            this.btnFloaters.Text = "Floaters";
            this.btnFloaters.UseVisualStyleBackColor = false;
            this.btnFloaters.Click += new System.EventHandler(this.btnFloaters_Click);
            // 
            // btnStopped
            // 
            this.btnStopped.BackColor = System.Drawing.Color.Silver;
            this.btnStopped.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnStopped.FlatAppearance.BorderSize = 2;
            this.btnStopped.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopped.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopped.Location = new System.Drawing.Point(644, 507);
            this.btnStopped.Name = "btnStopped";
            this.btnStopped.Size = new System.Drawing.Size(114, 45);
            this.btnStopped.TabIndex = 10;
            this.btnStopped.Text = "Stopped";
            this.btnStopped.UseVisualStyleBackColor = false;
            this.btnStopped.Click += new System.EventHandler(this.btnStopped_Click);
            // 
            // btnGraduate
            // 
            this.btnGraduate.BackColor = System.Drawing.Color.Silver;
            this.btnGraduate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnGraduate.FlatAppearance.BorderSize = 2;
            this.btnGraduate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraduate.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraduate.Location = new System.Drawing.Point(644, 357);
            this.btnGraduate.Name = "btnGraduate";
            this.btnGraduate.Size = new System.Drawing.Size(114, 45);
            this.btnGraduate.TabIndex = 8;
            this.btnGraduate.Text = "Graduate";
            this.btnGraduate.UseVisualStyleBackColor = false;
            this.btnGraduate.Click += new System.EventHandler(this.btnGraduate_Click);
            // 
            // btnDropped
            // 
            this.btnDropped.BackColor = System.Drawing.Color.Silver;
            this.btnDropped.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDropped.FlatAppearance.BorderSize = 2;
            this.btnDropped.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDropped.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDropped.Location = new System.Drawing.Point(644, 456);
            this.btnDropped.Name = "btnDropped";
            this.btnDropped.Size = new System.Drawing.Size(114, 45);
            this.btnDropped.TabIndex = 9;
            this.btnDropped.Text = "Dropped";
            this.btnDropped.UseVisualStyleBackColor = false;
            this.btnDropped.Click += new System.EventHandler(this.btnDropped_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Silver;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnPrint.FlatAppearance.BorderSize = 2;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(697, 558);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(61, 59);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.AllowUserToResizeColumns = false;
            this.dgvStudents.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStudentID,
            this.ULI,
            this.studentName,
            this.Column1,
            this.status});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStudents.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStudents.Location = new System.Drawing.Point(3, 204);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(637, 348);
            this.dgvStudents.TabIndex = 4;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.rbtnStopped);
            this.grpFilter.Controls.Add(this.rbtnDropped);
            this.grpFilter.Controls.Add(this.rbtnGraduate);
            this.grpFilter.Controls.Add(this.rbtnInplant);
            this.grpFilter.Controls.Add(this.rbtnFloaters);
            this.grpFilter.Controls.Add(this.rbtnAll);
            this.grpFilter.Controls.Add(this.rbtnInschool);
            this.grpFilter.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFilter.Location = new System.Drawing.Point(3, 142);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(757, 56);
            this.grpFilter.TabIndex = 71;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "FILTER BY";
            // 
            // rbtnStopped
            // 
            this.rbtnStopped.AutoSize = true;
            this.rbtnStopped.Location = new System.Drawing.Point(617, 23);
            this.rbtnStopped.Name = "rbtnStopped";
            this.rbtnStopped.Size = new System.Drawing.Size(89, 19);
            this.rbtnStopped.TabIndex = 6;
            this.rbtnStopped.Text = "STOPPED";
            this.rbtnStopped.UseVisualStyleBackColor = true;
            this.rbtnStopped.CheckedChanged += new System.EventHandler(this.rbtnStopped_CheckedChanged);
            // 
            // rbtnDropped
            // 
            this.rbtnDropped.AutoSize = true;
            this.rbtnDropped.Location = new System.Drawing.Point(517, 23);
            this.rbtnDropped.Name = "rbtnDropped";
            this.rbtnDropped.Size = new System.Drawing.Size(91, 19);
            this.rbtnDropped.TabIndex = 5;
            this.rbtnDropped.Text = "DROPPED";
            this.rbtnDropped.UseVisualStyleBackColor = true;
            this.rbtnDropped.CheckedChanged += new System.EventHandler(this.rbtnDropped_CheckedChanged);
            // 
            // rbtnGraduate
            // 
            this.rbtnGraduate.AutoSize = true;
            this.rbtnGraduate.Location = new System.Drawing.Point(405, 23);
            this.rbtnGraduate.Name = "rbtnGraduate";
            this.rbtnGraduate.Size = new System.Drawing.Size(99, 19);
            this.rbtnGraduate.TabIndex = 4;
            this.rbtnGraduate.Text = "GRADUATE";
            this.rbtnGraduate.UseVisualStyleBackColor = true;
            this.rbtnGraduate.CheckedChanged += new System.EventHandler(this.rbtnGraduate_CheckedChanged);
            // 
            // rbtnInplant
            // 
            this.rbtnInplant.AutoSize = true;
            this.rbtnInplant.Location = new System.Drawing.Point(297, 23);
            this.rbtnInplant.Name = "rbtnInplant";
            this.rbtnInplant.Size = new System.Drawing.Size(87, 19);
            this.rbtnInplant.TabIndex = 3;
            this.rbtnInplant.Text = "IN-PLANT";
            this.rbtnInplant.UseVisualStyleBackColor = true;
            this.rbtnInplant.CheckedChanged += new System.EventHandler(this.rbtnInplant_CheckedChanged);
            // 
            // rbtnFloaters
            // 
            this.rbtnFloaters.AutoSize = true;
            this.rbtnFloaters.Location = new System.Drawing.Point(194, 23);
            this.rbtnFloaters.Name = "rbtnFloaters";
            this.rbtnFloaters.Size = new System.Drawing.Size(86, 19);
            this.rbtnFloaters.TabIndex = 2;
            this.rbtnFloaters.Text = "FLOATER";
            this.rbtnFloaters.UseVisualStyleBackColor = true;
            this.rbtnFloaters.CheckedChanged += new System.EventHandler(this.rbtnFloaters_CheckedChanged);
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Checked = true;
            this.rbtnAll.Location = new System.Drawing.Point(16, 23);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(42, 19);
            this.rbtnAll.TabIndex = 0;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.Text = "All";
            this.rbtnAll.UseVisualStyleBackColor = true;
            this.rbtnAll.CheckedChanged += new System.EventHandler(this.rbtnAll_CheckedChanged);
            // 
            // rbtnInschool
            // 
            this.rbtnInschool.AutoSize = true;
            this.rbtnInschool.Location = new System.Drawing.Point(77, 23);
            this.rbtnInschool.Name = "rbtnInschool";
            this.rbtnInschool.Size = new System.Drawing.Size(100, 19);
            this.rbtnInschool.TabIndex = 1;
            this.rbtnInschool.Text = "IN-SCHOOL";
            this.rbtnInschool.UseVisualStyleBackColor = true;
            this.rbtnInschool.CheckedChanged += new System.EventHandler(this.rbtnInschool_CheckedChanged);
            // 
            // printPreviewDialog
            // 
            this.printPreviewDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog.Document = this.printDocument;
            this.printPreviewDialog.Enabled = true;
            this.printPreviewDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog.Icon")));
            this.printPreviewDialog.Name = "printPreviewDialog";
            this.printPreviewDialog.Visible = false;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // colStudentID
            // 
            this.colStudentID.HeaderText = "ID";
            this.colStudentID.Name = "colStudentID";
            this.colStudentID.ReadOnly = true;
            this.colStudentID.Visible = false;
            // 
            // ULI
            // 
            this.ULI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ULI.FillWeight = 5F;
            this.ULI.HeaderText = "#";
            this.ULI.Name = "ULI";
            this.ULI.ReadOnly = true;
            // 
            // studentName
            // 
            this.studentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.studentName.FillWeight = 25F;
            this.studentName.HeaderText = "NAME";
            this.studentName.Name = "studentName";
            this.studentName.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.FillWeight = 10F;
            this.Column1.HeaderText = "PROGRAM";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.status.FillWeight = 15F;
            this.status.HeaderText = "STATUS";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // StudentsStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(773, 633);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentsStatus";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StudentStatus";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnInplant;
        private System.Windows.Forms.Button btnInSchool;
        private System.Windows.Forms.Button btnFloaters;
        private System.Windows.Forms.Button btnStopped;
        private System.Windows.Forms.Button btnGraduate;
        private System.Windows.Forms.Button btnDropped;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.RadioButton rbtnStopped;
        private System.Windows.Forms.RadioButton rbtnDropped;
        private System.Windows.Forms.RadioButton rbtnGraduate;
        private System.Windows.Forms.RadioButton rbtnInplant;
        private System.Windows.Forms.RadioButton rbtnFloaters;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.RadioButton rbtnInschool;
        private System.Windows.Forms.ComboBox cbxBatch;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtCopr;
        private System.Windows.Forms.TextBox txtProgramTitle;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnChangeCourse;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ULI;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
    }
}