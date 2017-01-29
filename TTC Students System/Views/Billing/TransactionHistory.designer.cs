namespace GN.TTC.Students.Views.Billing
{
    partial class TransactionHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionHistory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.colStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printData = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.lastPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCopr = new System.Windows.Forms.TextBox();
            this.txtProgramTitle = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbxBatch = new System.Windows.Forms.ComboBox();
            this.btnEditTuition = new System.Windows.Forms.Button();
            this.btnPrintIndividual = new System.Windows.Forms.Button();
            this.btnPrintGrp = new System.Windows.Forms.Button();
            this.btnChangeCourse = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // colStudentID
            // 
            this.colStudentID.HeaderText = "ID";
            this.colStudentID.Name = "colStudentID";
            this.colStudentID.ReadOnly = true;
            this.colStudentID.Visible = false;
            // 
            // studentNumber
            // 
            this.studentNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.studentNumber.FillWeight = 15F;
            this.studentNumber.HeaderText = "ULI";
            this.studentNumber.Name = "studentNumber";
            this.studentNumber.ReadOnly = true;
            // 
            // studentName
            // 
            this.studentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.studentName.FillWeight = 29F;
            this.studentName.HeaderText = "NAME";
            this.studentName.Name = "studentName";
            this.studentName.ReadOnly = true;
            // 
            // currentBalance
            // 
            this.currentBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.currentBalance.FillWeight = 14F;
            this.currentBalance.HeaderText = "BALANCE";
            this.currentBalance.Name = "currentBalance";
            this.currentBalance.ReadOnly = true;
            // 
            // dateOfPayment
            // 
            this.dateOfPayment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateOfPayment.FillWeight = 14F;
            this.dateOfPayment.HeaderText = "DATE OF LAST PAYMENT";
            this.dateOfPayment.Name = "dateOfPayment";
            this.dateOfPayment.ReadOnly = true;
            // 
            // printData
            // 
            this.printData.FillWeight = 4F;
            this.printData.HeaderText = "PRINT";
            this.printData.Name = "printData";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dgvStudents);
            this.panel1.Controls.Add(this.txtCopr);
            this.panel1.Controls.Add(this.txtProgramTitle);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.cbxBatch);
            this.panel1.Controls.Add(this.btnEditTuition);
            this.panel1.Controls.Add(this.btnPrintIndividual);
            this.panel1.Controls.Add(this.btnPrintGrp);
            this.panel1.Controls.Add(this.btnChangeCourse);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 589);
            this.panel1.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(236, 57);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 16);
            this.label19.TabIndex = 70;
            this.label19.Text = "Program Title:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.Silver;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(5, 544);
            this.btnClose.Margin = new System.Windows.Forms.Padding(5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 40);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "CLOSE";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkGreen;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5);
            this.label5.Size = new System.Drawing.Size(783, 33);
            this.label5.TabIndex = 63;
            this.label5.Text = "PAYMENT AND HISTORY OF TRANSACTIONS";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.AllowUserToResizeColumns = false;
            this.dgvStudents.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lastPayment,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Bookman Old Style", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStudents.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvStudents.Location = new System.Drawing.Point(5, 149);
            this.dgvStudents.Margin = new System.Windows.Forms.Padding(5);
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(784, 350);
            this.dgvStudents.TabIndex = 2;
            // 
            // lastPayment
            // 
            this.lastPayment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lastPayment.FillWeight = 14F;
            this.lastPayment.HeaderText = "ID";
            this.lastPayment.Name = "lastPayment";
            this.lastPayment.ReadOnly = true;
            this.lastPayment.Visible = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.FillWeight = 20F;
            this.Column1.HeaderText = "STUDENT #";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.FillWeight = 40F;
            this.Column2.HeaderText = "NAME";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.FillWeight = 20F;
            this.Column4.HeaderText = "TUITION";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.FillWeight = 20F;
            this.Column3.HeaderText = "BALANCE";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // txtCopr
            // 
            this.txtCopr.BackColor = System.Drawing.Color.White;
            this.txtCopr.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCopr.Location = new System.Drawing.Point(9, 73);
            this.txtCopr.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.txtCopr.Name = "txtCopr";
            this.txtCopr.ReadOnly = true;
            this.txtCopr.Size = new System.Drawing.Size(225, 25);
            this.txtCopr.TabIndex = 69;
            // 
            // txtProgramTitle
            // 
            this.txtProgramTitle.BackColor = System.Drawing.Color.White;
            this.txtProgramTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgramTitle.Location = new System.Drawing.Point(237, 73);
            this.txtProgramTitle.Margin = new System.Windows.Forms.Padding(0, 6, 0, 5);
            this.txtProgramTitle.Name = "txtProgramTitle";
            this.txtProgramTitle.ReadOnly = true;
            this.txtProgramTitle.Size = new System.Drawing.Size(396, 25);
            this.txtProgramTitle.TabIndex = 71;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 57);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 16);
            this.label18.TabIndex = 68;
            this.label18.Text = "CoPR #:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxBatch
            // 
            this.cbxBatch.BackColor = System.Drawing.Color.White;
            this.cbxBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBatch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBatch.FormattingEnabled = true;
            this.cbxBatch.Location = new System.Drawing.Point(62, 116);
            this.cbxBatch.Margin = new System.Windows.Forms.Padding(3, 6, 0, 3);
            this.cbxBatch.Name = "cbxBatch";
            this.cbxBatch.Size = new System.Drawing.Size(102, 25);
            this.cbxBatch.TabIndex = 1;
            this.cbxBatch.SelectedIndexChanged += new System.EventHandler(this.cbxBatch_SelectedIndexChanged);
            // 
            // btnEditTuition
            // 
            this.btnEditTuition.AutoSize = true;
            this.btnEditTuition.BackColor = System.Drawing.Color.Silver;
            this.btnEditTuition.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnEditTuition.FlatAppearance.BorderSize = 2;
            this.btnEditTuition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTuition.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditTuition.Location = new System.Drawing.Point(703, 502);
            this.btnEditTuition.Name = "btnEditTuition";
            this.btnEditTuition.Size = new System.Drawing.Size(86, 28);
            this.btnEditTuition.TabIndex = 3;
            this.btnEditTuition.Text = "Edit Tuition";
            this.btnEditTuition.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEditTuition.UseVisualStyleBackColor = false;
            this.btnEditTuition.Click += new System.EventHandler(this.btnEditTuition_Click);
            // 
            // btnPrintIndividual
            // 
            this.btnPrintIndividual.AutoSize = true;
            this.btnPrintIndividual.BackColor = System.Drawing.Color.Silver;
            this.btnPrintIndividual.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnPrintIndividual.FlatAppearance.BorderSize = 2;
            this.btnPrintIndividual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintIndividual.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintIndividual.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintIndividual.Image")));
            this.btnPrintIndividual.Location = new System.Drawing.Point(436, 544);
            this.btnPrintIndividual.Margin = new System.Windows.Forms.Padding(5);
            this.btnPrintIndividual.Name = "btnPrintIndividual";
            this.btnPrintIndividual.Size = new System.Drawing.Size(212, 40);
            this.btnPrintIndividual.TabIndex = 4;
            this.btnPrintIndividual.Text = "Print Statements of Account";
            this.btnPrintIndividual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintIndividual.UseVisualStyleBackColor = false;
            this.btnPrintIndividual.Click += new System.EventHandler(this.btnPrintIndividual_Click);
            // 
            // btnPrintGrp
            // 
            this.btnPrintGrp.AutoSize = true;
            this.btnPrintGrp.BackColor = System.Drawing.Color.Silver;
            this.btnPrintGrp.FlatAppearance.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnPrintGrp.FlatAppearance.BorderSize = 2;
            this.btnPrintGrp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintGrp.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintGrp.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintGrp.Image")));
            this.btnPrintGrp.Location = new System.Drawing.Point(652, 544);
            this.btnPrintGrp.Margin = new System.Windows.Forms.Padding(5);
            this.btnPrintGrp.Name = "btnPrintGrp";
            this.btnPrintGrp.Size = new System.Drawing.Size(137, 40);
            this.btnPrintGrp.TabIndex = 5;
            this.btnPrintGrp.Text = "Print Summary";
            this.btnPrintGrp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintGrp.UseVisualStyleBackColor = false;
            this.btnPrintGrp.Click += new System.EventHandler(this.btnPrintGrp_Click);
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
            this.btnChangeCourse.Location = new System.Drawing.Point(636, 73);
            this.btnChangeCourse.Margin = new System.Windows.Forms.Padding(0, 5, 3, 3);
            this.btnChangeCourse.Name = "btnChangeCourse";
            this.btnChangeCourse.Size = new System.Drawing.Size(80, 25);
            this.btnChangeCourse.TabIndex = 0;
            this.btnChangeCourse.Text = "SELECT";
            this.btnChangeCourse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangeCourse.UseVisualStyleBackColor = false;
            this.btnChangeCourse.Click += new System.EventHandler(this.btnChangeCourse_Click);
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 120);
            this.label20.Margin = new System.Windows.Forms.Padding(0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 16);
            this.label20.TabIndex = 73;
            this.label20.Text = "Batch #:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // TransactionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(804, 599);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TransactionHistory";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaymentAndHistory";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfPayment;
        private System.Windows.Forms.DataGridViewCheckBoxColumn printData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.TextBox txtCopr;
        private System.Windows.Forms.TextBox txtProgramTitle;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbxBatch;
        private System.Windows.Forms.Button btnPrintIndividual;
        private System.Windows.Forms.Button btnPrintGrp;
        private System.Windows.Forms.Button btnChangeCourse;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnEditTuition;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog;
    }
}