namespace GN.TTC.Students.Views.Maintenance
{
    partial class TuitionFee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TuitionFee));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxCopies = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCopr = new System.Windows.Forms.TextBox();
            this.txtProgramTitle = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.dgvProgramFees = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.nudDownPayment = new System.Windows.Forms.NumericUpDown();
            this.nud1stPayment = new System.Windows.Forms.NumericUpDown();
            this.nud2ndPayment = new System.Windows.Forms.NumericUpDown();
            this.nud3rdPayment = new System.Windows.Forms.NumericUpDown();
            this.nud4thPayment = new System.Windows.Forms.NumericUpDown();
            this.nudTuition = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgramFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDownPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud1stPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud2ndPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud3rdPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud4thPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTuition)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.cbxCopies);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.txtCopr);
            this.panel1.Controls.Add(this.txtProgramTitle);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.dgvProgramFees);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.nudDownPayment);
            this.panel1.Controls.Add(this.nud1stPayment);
            this.panel1.Controls.Add(this.nud2ndPayment);
            this.panel1.Controls.Add(this.nud3rdPayment);
            this.panel1.Controls.Add(this.nud4thPayment);
            this.panel1.Controls.Add(this.nudTuition);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(696, 590);
            this.panel1.TabIndex = 0;
            // 
            // cbxCopies
            // 
            this.cbxCopies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCopies.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.cbxCopies.FormattingEnabled = true;
            this.cbxCopies.Items.AddRange(new object[] {
            "3",
            "6",
            "9",
            "12",
            "15",
            "18",
            "21",
            "24",
            "27",
            "30"});
            this.cbxCopies.Location = new System.Drawing.Point(620, 390);
            this.cbxCopies.Name = "cbxCopies";
            this.cbxCopies.Size = new System.Drawing.Size(67, 24);
            this.cbxCopies.TabIndex = 81;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Silver;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnPrint.FlatAppearance.BorderSize = 2;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(620, 420);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(67, 57);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(252, 253);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 16);
            this.label19.TabIndex = 79;
            this.label19.Text = "Program Title:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCopr
            // 
            this.txtCopr.BackColor = System.Drawing.Color.White;
            this.txtCopr.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCopr.Location = new System.Drawing.Point(14, 272);
            this.txtCopr.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.txtCopr.Name = "txtCopr";
            this.txtCopr.ReadOnly = true;
            this.txtCopr.Size = new System.Drawing.Size(236, 25);
            this.txtCopr.TabIndex = 78;
            // 
            // txtProgramTitle
            // 
            this.txtProgramTitle.BackColor = System.Drawing.Color.White;
            this.txtProgramTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgramTitle.Location = new System.Drawing.Point(254, 272);
            this.txtProgramTitle.Margin = new System.Windows.Forms.Padding(0, 6, 0, 5);
            this.txtProgramTitle.Name = "txtProgramTitle";
            this.txtProgramTitle.ReadOnly = true;
            this.txtProgramTitle.Size = new System.Drawing.Size(433, 25);
            this.txtProgramTitle.TabIndex = 80;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(11, 253);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 16);
            this.label18.TabIndex = 77;
            this.label18.Text = "CoPR #:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvProgramFees
            // 
            this.dgvProgramFees.AllowUserToAddRows = false;
            this.dgvProgramFees.AllowUserToDeleteRows = false;
            this.dgvProgramFees.AllowUserToResizeColumns = false;
            this.dgvProgramFees.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProgramFees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProgramFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProgramFees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Column1,
            this.Column2,
            this.courseName,
            this.totalFee});
            this.dgvProgramFees.Location = new System.Drawing.Point(5, 49);
            this.dgvProgramFees.MultiSelect = false;
            this.dgvProgramFees.Name = "dgvProgramFees";
            this.dgvProgramFees.ReadOnly = true;
            this.dgvProgramFees.RowHeadersVisible = false;
            this.dgvProgramFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProgramFees.Size = new System.Drawing.Size(686, 200);
            this.dgvProgramFees.TabIndex = 0;
            this.dgvProgramFees.SelectionChanged += new System.EventHandler(this.dgvSchoolFees_SelectionChanged);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.FillWeight = 5F;
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 20F;
            this.Column2.HeaderText = "COPR";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // courseName
            // 
            this.courseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.courseName.FillWeight = 40F;
            this.courseName.HeaderText = "COURSE";
            this.courseName.Name = "courseName";
            this.courseName.ReadOnly = true;
            // 
            // totalFee
            // 
            this.totalFee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.totalFee.FillWeight = 15F;
            this.totalFee.HeaderText = "TUITION FEE";
            this.totalFee.Name = "totalFee";
            this.totalFee.ReadOnly = true;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(5, 529);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(67, 57);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(626, 529);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 57);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkGreen;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(686, 36);
            this.label5.TabIndex = 36;
            this.label5.Text = "SCHOOL FEES";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudDownPayment
            // 
            this.nudDownPayment.BackColor = System.Drawing.Color.White;
            this.nudDownPayment.DecimalPlaces = 2;
            this.nudDownPayment.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDownPayment.Location = new System.Drawing.Point(389, 327);
            this.nudDownPayment.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudDownPayment.Name = "nudDownPayment";
            this.nudDownPayment.Size = new System.Drawing.Size(136, 23);
            this.nudDownPayment.TabIndex = 2;
            this.nudDownPayment.ValueChanged += new System.EventHandler(this.nudDownPayment_ValueChanged);
            // 
            // nud1stPayment
            // 
            this.nud1stPayment.BackColor = System.Drawing.Color.White;
            this.nud1stPayment.DecimalPlaces = 2;
            this.nud1stPayment.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud1stPayment.Location = new System.Drawing.Point(389, 370);
            this.nud1stPayment.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nud1stPayment.Name = "nud1stPayment";
            this.nud1stPayment.ReadOnly = true;
            this.nud1stPayment.Size = new System.Drawing.Size(136, 23);
            this.nud1stPayment.TabIndex = 3;
            // 
            // nud2ndPayment
            // 
            this.nud2ndPayment.BackColor = System.Drawing.Color.White;
            this.nud2ndPayment.DecimalPlaces = 2;
            this.nud2ndPayment.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud2ndPayment.Location = new System.Drawing.Point(389, 399);
            this.nud2ndPayment.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nud2ndPayment.Name = "nud2ndPayment";
            this.nud2ndPayment.ReadOnly = true;
            this.nud2ndPayment.Size = new System.Drawing.Size(136, 23);
            this.nud2ndPayment.TabIndex = 4;
            // 
            // nud3rdPayment
            // 
            this.nud3rdPayment.BackColor = System.Drawing.Color.White;
            this.nud3rdPayment.DecimalPlaces = 2;
            this.nud3rdPayment.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud3rdPayment.Location = new System.Drawing.Point(389, 428);
            this.nud3rdPayment.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nud3rdPayment.Name = "nud3rdPayment";
            this.nud3rdPayment.ReadOnly = true;
            this.nud3rdPayment.Size = new System.Drawing.Size(136, 23);
            this.nud3rdPayment.TabIndex = 5;
            // 
            // nud4thPayment
            // 
            this.nud4thPayment.BackColor = System.Drawing.Color.White;
            this.nud4thPayment.DecimalPlaces = 2;
            this.nud4thPayment.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud4thPayment.Location = new System.Drawing.Point(389, 457);
            this.nud4thPayment.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nud4thPayment.Name = "nud4thPayment";
            this.nud4thPayment.ReadOnly = true;
            this.nud4thPayment.Size = new System.Drawing.Size(136, 23);
            this.nud4thPayment.TabIndex = 6;
            // 
            // nudTuition
            // 
            this.nudTuition.BackColor = System.Drawing.Color.White;
            this.nudTuition.DecimalPlaces = 2;
            this.nudTuition.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTuition.Location = new System.Drawing.Point(27, 375);
            this.nudTuition.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.nudTuition.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudTuition.Name = "nudTuition";
            this.nudTuition.Size = new System.Drawing.Size(191, 32);
            this.nudTuition.TabIndex = 39;
            this.nudTuition.ValueChanged += new System.EventHandler(this.nudTuition_ValueChanged);
            this.nudTuition.Leave += new System.EventHandler(this.nudTuition_ValueChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(620, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 44;
            this.label2.Text = "COPIES:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(289, 331);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 44;
            this.label6.Text = "Downpayment:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(299, 460);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "4th Payment:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(298, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 16);
            this.label3.TabIndex = 41;
            this.label3.Text = "3rd Payment:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(296, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 41;
            this.label1.Text = "2nd Payment:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(300, 374);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 41;
            this.label7.Text = "1st Payment:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(24, 352);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 16);
            this.label11.TabIndex = 42;
            this.label11.Text = "TUITION FEE";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
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
            // TuitionFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(706, 600);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TuitionFee";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TuitionFee";
            this.Load += new System.EventHandler(this.TuitionFee_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgramFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDownPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud1stPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud2ndPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud3rdPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud4thPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTuition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvProgramFees;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudDownPayment;
        private System.Windows.Forms.NumericUpDown nud1stPayment;
        private System.Windows.Forms.NumericUpDown nud2ndPayment;
        private System.Windows.Forms.NumericUpDown nud3rdPayment;
        private System.Windows.Forms.NumericUpDown nud4thPayment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudTuition;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtCopr;
        private System.Windows.Forms.TextBox txtProgramTitle;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalFee;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCopies;
        private System.Windows.Forms.Label label2;
    }
}