namespace UIProject
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnShow = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.monthPicker1 = new System.Windows.Forms.DateTimePicker();
            this.monthPicker2 = new System.Windows.Forms.DateTimePicker();
            this.cbSelectSalaryParam = new System.Windows.Forms.ComboBox();
            this.flgShowAll = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNameFilter = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuEditDb = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPayments = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvResults, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(652, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResults.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(6, 209);
            this.dgvResults.Margin = new System.Windows.Forms.Padding(6);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(640, 235);
            this.dgvResults.TabIndex = 1;
            this.dgvResults.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvResults_DataBindingComplete);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 28);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(646, 142);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnShow);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(6, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 50);
            this.panel2.TabIndex = 3;
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnShow.Location = new System.Drawing.Point(492, 9);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(142, 31);
            this.btnShow.TabIndex = 3;
            this.btnShow.Text = "Показать";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.cbSelectSalaryParam);
            this.flowLayoutPanel1.Controls.Add(this.flgShowAll);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(325, 80);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(634, 80);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.monthPicker1);
            this.groupBox2.Controls.Add(this.monthPicker2);
            this.groupBox2.Location = new System.Drawing.Point(13, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 58);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Диапазон дат";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(138, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "—";
            // 
            // monthPicker1
            // 
            this.monthPicker1.Location = new System.Drawing.Point(6, 19);
            this.monthPicker1.Name = "monthPicker1";
            this.monthPicker1.Size = new System.Drawing.Size(115, 20);
            this.monthPicker1.TabIndex = 0;
            // 
            // monthPicker2
            // 
            this.monthPicker2.Location = new System.Drawing.Point(186, 19);
            this.monthPicker2.Margin = new System.Windows.Forms.Padding(6);
            this.monthPicker2.Name = "monthPicker2";
            this.monthPicker2.Size = new System.Drawing.Size(115, 20);
            this.monthPicker2.TabIndex = 1;
            // 
            // cbSelectSalaryParam
            // 
            this.cbSelectSalaryParam.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSelectSalaryParam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectSalaryParam.FormattingEnabled = true;
            this.cbSelectSalaryParam.Items.AddRange(new object[] {
            "Средняя за месяц",
            "Максимальная за месяц"});
            this.cbSelectSalaryParam.Location = new System.Drawing.Point(329, 26);
            this.cbSelectSalaryParam.Margin = new System.Windows.Forms.Padding(6);
            this.cbSelectSalaryParam.Name = "cbSelectSalaryParam";
            this.cbSelectSalaryParam.Size = new System.Drawing.Size(153, 21);
            this.cbSelectSalaryParam.TabIndex = 2;
            // 
            // flgShowAll
            // 
            this.flgShowAll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flgShowAll.AutoSize = true;
            this.flgShowAll.Location = new System.Drawing.Point(494, 28);
            this.flgShowAll.Margin = new System.Windows.Forms.Padding(6);
            this.flgShowAll.Name = "flgShowAll";
            this.flgShowAll.Size = new System.Drawing.Size(132, 17);
            this.flgShowAll.TabIndex = 3;
            this.flgShowAll.Text = "Показать уволенных";
            this.flgShowAll.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtNameFilter);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 176);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(646, 24);
            this.panel3.TabIndex = 4;
            // 
            // txtNameFilter
            // 
            this.txtNameFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtNameFilter.ForeColor = System.Drawing.Color.Silver;
            this.txtNameFilter.Location = new System.Drawing.Point(4, 3);
            this.txtNameFilter.Margin = new System.Windows.Forms.Padding(6);
            this.txtNameFilter.Name = "txtNameFilter";
            this.txtNameFilter.Size = new System.Drawing.Size(203, 20);
            this.txtNameFilter.TabIndex = 0;
            this.txtNameFilter.Tag = "";
            this.txtNameFilter.Text = "Имя сотрудника для поиска";
            this.txtNameFilter.TextChanged += new System.EventHandler(this.txtNameFilter_TextChanged);
            this.txtNameFilter.Enter += new System.EventHandler(this.txtNameFilter_Enter);
            this.txtNameFilter.Leave += new System.EventHandler(this.txtNameFilter_Leave);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightYellow;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEditDb,
            this.menuPayments,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(652, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuEditDb
            // 
            this.menuEditDb.Name = "menuEditDb";
            this.menuEditDb.Size = new System.Drawing.Size(117, 20);
            this.menuEditDb.Text = "Редактировать БД";
            this.menuEditDb.Click += new System.EventHandler(this.menuEditDb_Click);
            // 
            // menuPayments
            // 
            this.menuPayments.Name = "menuPayments";
            this.menuPayments.Size = new System.Drawing.Size(109, 20);
            this.menuPayments.Text = "История выплат";
            this.menuPayments.Click += new System.EventHandler(this.menuPayments_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(65, 20);
            this.menuHelp.Text = "Справка";
            this.menuHelp.Click += new System.EventHandler(this.menuHelp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(355, 489);
            this.Name = "MainForm";
            this.Text = "EmployeePayments";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker monthPicker1;
        private System.Windows.Forms.DateTimePicker monthPicker2;
        private System.Windows.Forms.ComboBox cbSelectSalaryParam;
        private System.Windows.Forms.CheckBox flgShowAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.TextBox txtNameFilter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuEditDb;
        private System.Windows.Forms.ToolStripMenuItem menuPayments;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
    }
}

