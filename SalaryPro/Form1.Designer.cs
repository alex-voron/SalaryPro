namespace SalaryPro
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dtpStart = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            dgvVendors = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            col55 = new DataGridViewTextBoxColumn();
            col30 = new DataGridViewTextBoxColumn();
            col15 = new DataGridViewTextBoxColumn();
            col5 = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            btnEditVendors = new Button();
            groupExtra = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label = new Label();
            txtPriceBot = new TextBox();
            btnAddActualization = new Button();
            lblActCount = new Label();
            rtbReport = new RichTextBox();
            btnGenerate = new Button();
            btnCopy = new Button();
            btnClear = new Button();
            comboLang = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvVendors).BeginInit();
            groupExtra.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // dtpStart
            // 
            dtpStart.Location = new Point(102, 41);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(155, 23);
            dtpStart.TabIndex = 0;
            dtpStart.Value = new DateTime(2026, 4, 25, 14, 30, 32, 0);
            // 
            // dtpEnd
            // 
            dtpEnd.Location = new Point(292, 41);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(150, 23);
            dtpEnd.TabIndex = 1;
            // 
            // dgvVendors
            // 
            dgvVendors.AccessibleName = "(ReadOnly)";
            dgvVendors.AllowUserToAddRows = false;
            dgvVendors.AllowUserToDeleteRows = false;
            dgvVendors.AllowUserToResizeColumns = false;
            dgvVendors.AllowUserToResizeRows = false;
            dgvVendors.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvVendors.BackgroundColor = Color.White;
            dgvVendors.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvVendors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvVendors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVendors.Columns.AddRange(new DataGridViewColumn[] { colName, col55, col30, col15, col5, colTotal });
            dgvVendors.GridColor = SystemColors.ControlLight;
            dgvVendors.Location = new Point(44, 100);
            dgvVendors.Name = "dgvVendors";
            dgvVendors.RowHeadersVisible = false;
            dgvVendors.ScrollBars = ScrollBars.Vertical;
            dgvVendors.Size = new Size(491, 228);
            dgvVendors.TabIndex = 2;
            dgvVendors.CellValueChanged += dgvVendors_CellValueChanged;
            dgvVendors.CurrentCellDirtyStateChanged += dgvVendors_CurrentCellDirtyStateChanged;
            dgvVendors.EditingControlShowing += dgvVendors_EditingControlShowing;
            // 
            // colName
            // 
            colName.HeaderText = "Постачальник";
            colName.Name = "colName";
            colName.Width = 101;
            // 
            // col55
            // 
            col55.HeaderText = "55 грн";
            col55.Name = "col55";
            col55.Width = 101;
            // 
            // col30
            // 
            col30.HeaderText = "30 грн";
            col30.Name = "col30";
            col30.Width = 101;
            // 
            // col15
            // 
            col15.HeaderText = "15 грн";
            col15.Name = "col15";
            col15.Width = 102;
            // 
            // col5
            // 
            col5.HeaderText = "5 грн";
            col5.Name = "col5";
            col5.Width = 101;
            // 
            // colTotal
            // 
            colTotal.HeaderText = "Сума";
            colTotal.Name = "colTotal";
            colTotal.Width = 101;
            // 
            // btnEditVendors
            // 
            btnEditVendors.BackColor = Color.LightSkyBlue;
            btnEditVendors.Location = new Point(165, 70);
            btnEditVendors.Name = "btnEditVendors";
            btnEditVendors.Size = new Size(248, 24);
            btnEditVendors.TabIndex = 4;
            btnEditVendors.Text = "Редагувати список постачальників";
            btnEditVendors.UseVisualStyleBackColor = false;
            btnEditVendors.Click += btnEditVendors_Click;
            // 
            // groupExtra
            // 
            groupExtra.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupExtra.Controls.Add(flowLayoutPanel1);
            groupExtra.Location = new Point(26, 334);
            groupExtra.Name = "groupExtra";
            groupExtra.Size = new Size(525, 86);
            groupExtra.TabIndex = 6;
            groupExtra.TabStop = false;
            groupExtra.Text = "Додаткові звіти";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(label);
            flowLayoutPanel1.Controls.Add(txtPriceBot);
            flowLayoutPanel1.Controls.Add(btnAddActualization);
            flowLayoutPanel1.Controls.Add(lblActCount);
            flowLayoutPanel1.Location = new Point(18, 13);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(20);
            flowLayoutPanel1.Size = new Size(491, 67);
            flowLayoutPanel1.TabIndex = 4;
            flowLayoutPanel1.WrapContents = false;
            // 
            // label
            // 
            label.Anchor = AnchorStyles.None;
            label.AutoSize = true;
            label.Location = new Point(23, 34);
            label.Name = "label";
            label.Size = new Size(144, 15);
            label.TabIndex = 0;
            label.Text = "Перевірка цін бот (к-сть)";
            // 
            // txtPriceBot
            // 
            txtPriceBot.Anchor = AnchorStyles.None;
            txtPriceBot.Location = new Point(173, 30);
            txtPriceBot.Name = "txtPriceBot";
            txtPriceBot.Size = new Size(58, 23);
            txtPriceBot.TabIndex = 1;
            txtPriceBot.Text = "0";
            txtPriceBot.TextAlign = HorizontalAlignment.Center;
            // 
            // btnAddActualization
            // 
            btnAddActualization.Anchor = AnchorStyles.None;
            btnAddActualization.BackColor = Color.LightSkyBlue;
            btnAddActualization.Location = new Point(237, 23);
            btnAddActualization.Name = "btnAddActualization";
            btnAddActualization.Size = new Size(113, 38);
            btnAddActualization.TabIndex = 2;
            btnAddActualization.Text = "+ Додати актуалізацію";
            btnAddActualization.UseVisualStyleBackColor = false;
            btnAddActualization.Click += btnAddActualization_Click;
            // 
            // lblActCount
            // 
            lblActCount.Anchor = AnchorStyles.None;
            lblActCount.AutoSize = true;
            lblActCount.ForeColor = Color.DeepSkyBlue;
            lblActCount.Location = new Point(356, 34);
            lblActCount.Name = "lblActCount";
            lblActCount.Size = new Size(130, 15);
            lblActCount.TabIndex = 3;
            lblActCount.Text = "Актуалізацій додано: 0";
            // 
            // rtbReport
            // 
            rtbReport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            rtbReport.BackColor = SystemColors.ControlLight;
            rtbReport.Font = new Font("Arial", 10F);
            rtbReport.Location = new Point(87, 453);
            rtbReport.Name = "rtbReport";
            rtbReport.Size = new Size(405, 216);
            rtbReport.TabIndex = 7;
            rtbReport.Text = "";
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.LightSkyBlue;
            btnGenerate.Location = new Point(87, 690);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(113, 23);
            btnGenerate.TabIndex = 8;
            btnGenerate.Text = "Згенерувати звіт";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnCopy
            // 
            btnCopy.BackColor = Color.LightSkyBlue;
            btnCopy.Location = new Point(233, 690);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(113, 23);
            btnCopy.TabIndex = 9;
            btnCopy.Text = "Копіювати все";
            btnCopy.UseVisualStyleBackColor = false;
            btnCopy.Click += btnCopy_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.LightCoral;
            btnClear.Location = new Point(379, 690);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(113, 23);
            btnClear.TabIndex = 10;
            btnClear.Text = "Очистити все";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // comboLang
            // 
            comboLang.FormattingEnabled = true;
            comboLang.Location = new Point(526, 41);
            comboLang.Name = "comboLang";
            comboLang.Size = new Size(41, 23);
            comboLang.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(579, 732);
            Controls.Add(comboLang);
            Controls.Add(btnClear);
            Controls.Add(btnCopy);
            Controls.Add(btnGenerate);
            Controls.Add(rtbReport);
            Controls.Add(groupExtra);
            Controls.Add(btnEditVendors);
            Controls.Add(dgvVendors);
            Controls.Add(dtpEnd);
            Controls.Add(dtpStart);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvVendors).EndInit();
            groupExtra.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
        private DataGridView dgvVendors;
        private Button btnEditVendors;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn col55;
        private DataGridViewTextBoxColumn col30;
        private DataGridViewTextBoxColumn col15;
        private DataGridViewTextBoxColumn col5;
        private DataGridViewTextBoxColumn colTotal;
        private GroupBox groupExtra;
        private Button btnAddActualization;
        private TextBox txtPriceBot;
        private Label label;
        private Label lblActCount;
        private RichTextBox rtbReport;
        private Button btnGenerate;
        private Button btnCopy;
        private Button btnClear;
        private ComboBox comboLang;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
