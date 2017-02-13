namespace GN.TTC.Students.Views.Maintenance
{
    partial class ProgramProfile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramProfile));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtProgramTitle = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIndustrySector = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnOneYear = new System.Windows.Forms.RadioButton();
            this.rbtnShortCourse = new System.Windows.Forms.RadioButton();
            this.nudNumberOfHours = new System.Windows.Forms.NumericUpDown();
            this.txtTVETRegStatus = new System.Windows.Forms.TextBox();
            this.nudTuition = new System.Windows.Forms.NumericUpDown();
            this.txtCOPR = new System.Windows.Forms.TextBox();
            this.txtTrainingCalendarCode = new System.Windows.Forms.TextBox();
            this.txtDelivery = new System.Windows.Forms.TextBox();
            this.dgvProgramTitle = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coprNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courseTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tuitionFee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTuition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgramTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtProgramTitle);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtIndustrySector);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rbtnOneYear);
            this.panel1.Controls.Add(this.rbtnShortCourse);
            this.panel1.Controls.Add(this.nudNumberOfHours);
            this.panel1.Controls.Add(this.txtTVETRegStatus);
            this.panel1.Controls.Add(this.nudTuition);
            this.panel1.Controls.Add(this.txtCOPR);
            this.panel1.Controls.Add(this.txtTrainingCalendarCode);
            this.panel1.Controls.Add(this.txtDelivery);
            this.panel1.Controls.Add(this.dgvProgramTitle);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 602);
            this.panel1.TabIndex = 0;
            // 
            // txtProgramTitle
            // 
            this.txtProgramTitle.BackColor = System.Drawing.Color.White;
            this.txtProgramTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgramTitle.Location = new System.Drawing.Point(93, 324);
            this.txtProgramTitle.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.txtProgramTitle.Name = "txtProgramTitle";
            this.txtProgramTitle.Size = new System.Drawing.Size(362, 23);
            this.txtProgramTitle.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(3, 537);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 61);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Silver;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnPrint.FlatAppearance.BorderSize = 2;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(457, 537);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(68, 61);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "PRINT";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Silver;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(528, 537);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(68, 61);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "SAVE";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 52;
            this.label6.Text = "Program Title:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIndustrySector
            // 
            this.txtIndustrySector.BackColor = System.Drawing.Color.White;
            this.txtIndustrySector.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndustrySector.Location = new System.Drawing.Point(191, 355);
            this.txtIndustrySector.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.txtIndustrySector.Name = "txtIndustrySector";
            this.txtIndustrySector.Size = new System.Drawing.Size(405, 23);
            this.txtIndustrySector.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 16);
            this.label2.TabIndex = 37;
            this.label2.Text = "Industry Sector of Qualification:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkGreen;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 4);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(591, 30);
            this.label5.TabIndex = 34;
            this.label5.Text = "PROGRAM PROFILE";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 35;
            this.label1.Text = "Duration:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbtnOneYear
            // 
            this.rbtnOneYear.AutoSize = true;
            this.rbtnOneYear.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnOneYear.Location = new System.Drawing.Point(76, 283);
            this.rbtnOneYear.Name = "rbtnOneYear";
            this.rbtnOneYear.Size = new System.Drawing.Size(73, 21);
            this.rbtnOneYear.TabIndex = 1;
            this.rbtnOneYear.TabStop = true;
            this.rbtnOneYear.Text = "1 Year";
            this.rbtnOneYear.UseVisualStyleBackColor = true;
            // 
            // rbtnShortCourse
            // 
            this.rbtnShortCourse.AutoSize = true;
            this.rbtnShortCourse.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnShortCourse.Location = new System.Drawing.Point(193, 282);
            this.rbtnShortCourse.Name = "rbtnShortCourse";
            this.rbtnShortCourse.Size = new System.Drawing.Size(123, 21);
            this.rbtnShortCourse.TabIndex = 2;
            this.rbtnShortCourse.TabStop = true;
            this.rbtnShortCourse.Text = "Short Course";
            this.rbtnShortCourse.UseVisualStyleBackColor = true;
            // 
            // nudNumberOfHours
            // 
            this.nudNumberOfHours.BackColor = System.Drawing.Color.White;
            this.nudNumberOfHours.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudNumberOfHours.Location = new System.Drawing.Point(537, 324);
            this.nudNumberOfHours.Margin = new System.Windows.Forms.Padding(3, 5, 5, 3);
            this.nudNumberOfHours.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudNumberOfHours.Name = "nudNumberOfHours";
            this.nudNumberOfHours.Size = new System.Drawing.Size(59, 23);
            this.nudNumberOfHours.TabIndex = 4;
            // 
            // txtTVETRegStatus
            // 
            this.txtTVETRegStatus.BackColor = System.Drawing.Color.White;
            this.txtTVETRegStatus.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTVETRegStatus.Location = new System.Drawing.Point(191, 386);
            this.txtTVETRegStatus.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.txtTVETRegStatus.Name = "txtTVETRegStatus";
            this.txtTVETRegStatus.Size = new System.Drawing.Size(216, 23);
            this.txtTVETRegStatus.TabIndex = 6;
            // 
            // nudTuition
            // 
            this.nudTuition.BackColor = System.Drawing.Color.White;
            this.nudTuition.DecimalPlaces = 2;
            this.nudTuition.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTuition.Location = new System.Drawing.Point(191, 502);
            this.nudTuition.Margin = new System.Windows.Forms.Padding(3, 5, 5, 3);
            this.nudTuition.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.nudTuition.Name = "nudTuition";
            this.nudTuition.Size = new System.Drawing.Size(153, 26);
            this.nudTuition.TabIndex = 10;
            // 
            // txtCOPR
            // 
            this.txtCOPR.BackColor = System.Drawing.Color.White;
            this.txtCOPR.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCOPR.Location = new System.Drawing.Point(191, 416);
            this.txtCOPR.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.txtCOPR.Name = "txtCOPR";
            this.txtCOPR.Size = new System.Drawing.Size(216, 23);
            this.txtCOPR.TabIndex = 7;
            // 
            // txtTrainingCalendarCode
            // 
            this.txtTrainingCalendarCode.BackColor = System.Drawing.Color.White;
            this.txtTrainingCalendarCode.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrainingCalendarCode.Location = new System.Drawing.Point(191, 445);
            this.txtTrainingCalendarCode.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.txtTrainingCalendarCode.Name = "txtTrainingCalendarCode";
            this.txtTrainingCalendarCode.Size = new System.Drawing.Size(216, 23);
            this.txtTrainingCalendarCode.TabIndex = 8;
            // 
            // txtDelivery
            // 
            this.txtDelivery.BackColor = System.Drawing.Color.White;
            this.txtDelivery.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelivery.Location = new System.Drawing.Point(191, 473);
            this.txtDelivery.Margin = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.txtDelivery.Name = "txtDelivery";
            this.txtDelivery.Size = new System.Drawing.Size(94, 23);
            this.txtDelivery.TabIndex = 9;
            // 
            // dgvProgramTitle
            // 
            this.dgvProgramTitle.AllowUserToAddRows = false;
            this.dgvProgramTitle.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProgramTitle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProgramTitle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProgramTitle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Column1,
            this.coprNumber,
            this.courseTitle,
            this.tuitionFee});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProgramTitle.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProgramTitle.Location = new System.Drawing.Point(5, 45);
            this.dgvProgramTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.dgvProgramTitle.MultiSelect = false;
            this.dgvProgramTitle.Name = "dgvProgramTitle";
            this.dgvProgramTitle.ReadOnly = true;
            this.dgvProgramTitle.RowHeadersVisible = false;
            this.dgvProgramTitle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProgramTitle.Size = new System.Drawing.Size(591, 229);
            this.dgvProgramTitle.TabIndex = 0;
            this.dgvProgramTitle.SelectionChanged += new System.EventHandler(this.dgvProgramTitle_SelectionChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(464, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "# of Hours:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 388);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "TVET Program Reg. Status:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 419);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(181, 16);
            this.label9.TabIndex = 39;
            this.label9.Text = "coPR Number (for WTR/NTR):";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(45, 448);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 16);
            this.label10.TabIndex = 42;
            this.label10.Text = "Training Calendar Code:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(100, 476);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 16);
            this.label11.TabIndex = 41;
            this.label11.Text = "Delivery Mode:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(140, 507);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 40;
            this.label7.Text = "Tuition:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // coprNumber
            // 
            this.coprNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.coprNumber.FillWeight = 20F;
            this.coprNumber.HeaderText = "CoPR NUMBER";
            this.coprNumber.Name = "coprNumber";
            this.coprNumber.ReadOnly = true;
            // 
            // courseTitle
            // 
            this.courseTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.courseTitle.FillWeight = 45F;
            this.courseTitle.HeaderText = "TITLE";
            this.courseTitle.Name = "courseTitle";
            this.courseTitle.ReadOnly = true;
            // 
            // tuitionFee
            // 
            this.tuitionFee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tuitionFee.FillWeight = 15F;
            this.tuitionFee.HeaderText = "TUITION";
            this.tuitionFee.Name = "tuitionFee";
            this.tuitionFee.ReadOnly = true;
            // 
            // ProgramProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(612, 612);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgramProfile";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProgramProfile";
            this.Load += new System.EventHandler(this.ProgramProfile_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTuition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProgramTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtProgramTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIndustrySector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnOneYear;
        private System.Windows.Forms.RadioButton rbtnShortCourse;
        private System.Windows.Forms.NumericUpDown nudNumberOfHours;
        private System.Windows.Forms.TextBox txtTVETRegStatus;
        private System.Windows.Forms.NumericUpDown nudTuition;
        private System.Windows.Forms.TextBox txtCOPR;
        private System.Windows.Forms.TextBox txtTrainingCalendarCode;
        private System.Windows.Forms.TextBox txtDelivery;
        private System.Windows.Forms.DataGridView dgvProgramTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn coprNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn courseTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn tuitionFee;
    }
}