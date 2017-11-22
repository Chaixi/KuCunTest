namespace kucunTest.JiChuZiLiao
{
    partial class shujudaorudaochu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(shujudaorudaochu));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.checkColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chx_selected = new System.Windows.Forms.CheckBox();
            this.chx_all = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SXTJ = new System.Windows.Forms.ComboBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.lab_tjmc = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.page_output = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_output = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SJLX = new System.Windows.Forms.ComboBox();
            this.page_input = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_input = new System.Windows.Forms.Button();
            this.btn_open = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.filePath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool_label_record = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Btn_First = new System.Windows.Forms.ToolStripButton();
            this.Btn_Prev = new System.Windows.Forms.ToolStripButton();
            this.tool_label1 = new System.Windows.Forms.ToolStripLabel();
            this.Btn_Next = new System.Windows.Forms.ToolStripButton();
            this.Btn_Last = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_label_page = new System.Windows.Forms.ToolStripLabel();
            this.tool_Text_page = new System.Windows.Forms.ToolStripTextBox();
            this.Btn_goto = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_export = new System.Windows.Forms.ToolStripButton();
            this.tool_print = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.page_output.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.page_input.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersHeight = 35;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkColumn});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(4, 75);
            this.dgv.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1013, 458);
            this.dgv.TabIndex = 0;
            this.dgv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_RowPostPaint);
            // 
            // checkColumn
            // 
            this.checkColumn.FalseValue = "false";
            this.checkColumn.HeaderText = "选择";
            this.checkColumn.IndeterminateValue = "false";
            this.checkColumn.Name = "checkColumn";
            this.checkColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.checkColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.checkColumn.TrueValue = "true";
            this.checkColumn.Width = 67;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.groupBox1.Controls.Add(this.chx_selected);
            this.groupBox1.Controls.Add(this.chx_all);
            this.groupBox1.Location = new System.Drawing.Point(419, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(327, 59);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // chx_selected
            // 
            this.chx_selected.AutoSize = true;
            this.chx_selected.Location = new System.Drawing.Point(184, 25);
            this.chx_selected.Name = "chx_selected";
            this.chx_selected.Size = new System.Drawing.Size(125, 25);
            this.chx_selected.TabIndex = 2;
            this.chx_selected.Text = "导出所选数据";
            this.chx_selected.UseVisualStyleBackColor = true;
            this.chx_selected.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chx_all
            // 
            this.chx_all.AutoSize = true;
            this.chx_all.Checked = true;
            this.chx_all.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chx_all.Location = new System.Drawing.Point(26, 24);
            this.chx_all.Name = "chx_all";
            this.chx_all.Size = new System.Drawing.Size(125, 25);
            this.chx_all.TabIndex = 2;
            this.chx_all.Text = "导出全部数据";
            this.chx_all.UseVisualStyleBackColor = true;
            this.chx_all.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.76697F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.23303F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1037, 781);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 175);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1029, 601);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据预览";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.dgv, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 27);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.10592F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.89408F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1021, 569);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SXTJ);
            this.groupBox3.Controls.Add(this.lab_tjmc);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1015, 64);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "筛选条件";
            // 
            // SXTJ
            // 
            this.SXTJ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SXTJ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SXTJ.FormattingEnabled = true;
            this.SXTJ.Location = new System.Drawing.Point(114, 27);
            this.SXTJ.Name = "SXTJ";
            this.SXTJ.Size = new System.Drawing.Size(217, 29);
            this.SXTJ.TabIndex = 1;
            this.SXTJ.SelectedIndexChanged += new System.EventHandler(this.SXTJ_SelectedIndexChanged);
            // 
            // btn_save
            // 
            this.btn_save.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_save.Location = new System.Drawing.Point(931, 21);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(83, 34);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "保    存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lab_tjmc
            // 
            this.lab_tjmc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lab_tjmc.AutoSize = true;
            this.lab_tjmc.Location = new System.Drawing.Point(50, 30);
            this.lab_tjmc.Name = "lab_tjmc";
            this.lab_tjmc.Size = new System.Drawing.Size(58, 21);
            this.lab_tjmc.TabIndex = 0;
            this.lab_tjmc.Text = "请选择";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.page_output);
            this.tabControl1.Controls.Add(this.page_input);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1031, 164);
            this.tabControl1.TabIndex = 3;
            // 
            // page_output
            // 
            this.page_output.Controls.Add(this.tableLayoutPanel3);
            this.page_output.Location = new System.Drawing.Point(4, 30);
            this.page_output.Name = "page_output";
            this.page_output.Padding = new System.Windows.Forms.Padding(3);
            this.page_output.Size = new System.Drawing.Size(1023, 130);
            this.page_output.TabIndex = 0;
            this.page_output.Text = "数据导出";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.btn_output, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.SJLX, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox1, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1017, 124);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // btn_output
            // 
            this.btn_output.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_output.Location = new System.Drawing.Point(753, 20);
            this.btn_output.Name = "btn_output";
            this.btn_output.Size = new System.Drawing.Size(102, 34);
            this.btn_output.TabIndex = 3;
            this.btn_output.Text = "导    出";
            this.btn_output.UseVisualStyleBackColor = true;
            this.btn_output.Click += new System.EventHandler(this.btn_output_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "导出数据类型";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(338, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "导出设置";
            // 
            // SJLX
            // 
            this.SJLX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SJLX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SJLX.FormattingEnabled = true;
            this.SJLX.Items.AddRange(new object[] {
            "刀具信息",
            "零部件信息",
            "刀具柜信息",
            "机床信息"});
            this.SJLX.Location = new System.Drawing.Point(115, 23);
            this.SJLX.Name = "SJLX";
            this.SJLX.Size = new System.Drawing.Size(217, 29);
            this.SJLX.TabIndex = 1;
            this.SJLX.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // page_input
            // 
            this.page_input.BackColor = System.Drawing.Color.Transparent;
            this.page_input.Controls.Add(this.tableLayoutPanel4);
            this.page_input.Location = new System.Drawing.Point(4, 30);
            this.page_input.Name = "page_input";
            this.page_input.Padding = new System.Windows.Forms.Padding(3);
            this.page_input.Size = new System.Drawing.Size(1023, 130);
            this.page_input.TabIndex = 1;
            this.page_input.Text = "数据导入";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 10;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_save, 9, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_input, 8, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_open, 7, 0);
            this.tableLayoutPanel4.Controls.Add(this.comboBox3, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.filePath, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.label5, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.comboBox1, 2, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1017, 124);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "导入数据类型";
            // 
            // btn_input
            // 
            this.btn_input.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_input.Location = new System.Drawing.Point(842, 21);
            this.btn_input.Name = "btn_input";
            this.btn_input.Size = new System.Drawing.Size(83, 34);
            this.btn_input.TabIndex = 4;
            this.btn_input.Text = "导    入";
            this.btn_input.UseVisualStyleBackColor = true;
            this.btn_input.Click += new System.EventHandler(this.btn_input_Click);
            // 
            // btn_open
            // 
            this.btn_open.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_open.Location = new System.Drawing.Point(755, 21);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(81, 34);
            this.btn_open.TabIndex = 7;
            this.btn_open.Text = "浏    览";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(115, 28);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(217, 29);
            this.comboBox3.TabIndex = 3;
            // 
            // filePath
            // 
            this.filePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.filePath.Location = new System.Drawing.Point(418, 23);
            this.filePath.Name = "filePath";
            this.filePath.ReadOnly = true;
            this.filePath.Size = new System.Drawing.Size(331, 29);
            this.filePath.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "选择文件";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "选择工作表";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(115, 90);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(217, 29);
            this.comboBox1.TabIndex = 8;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_label_record,
            this.toolStripSeparator1,
            this.Btn_First,
            this.Btn_Prev,
            this.tool_label1,
            this.Btn_Next,
            this.Btn_Last,
            this.toolStripSeparator2,
            this.tool_label_page,
            this.tool_Text_page,
            this.Btn_goto,
            this.toolStripLabel1,
            this.tool_export,
            this.tool_print,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.toolStripSeparator5});
            this.toolStrip1.Location = new System.Drawing.Point(203, 541);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(615, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool_label_record
            // 
            this.tool_label_record.Name = "tool_label_record";
            this.tool_label_record.Size = new System.Drawing.Size(276, 22);
            this.tool_label_record.Text = "共0条记录，每页30条记录，当前第1页，共第一页";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Btn_First
            // 
            this.Btn_First.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Btn_First.Image = ((System.Drawing.Image)(resources.GetObject("Btn_First.Image")));
            this.Btn_First.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_First.Name = "Btn_First";
            this.Btn_First.Size = new System.Drawing.Size(23, 22);
            this.Btn_First.Tag = "8";
            this.Btn_First.Text = "First";
            this.Btn_First.ToolTipText = "首页";
            // 
            // Btn_Prev
            // 
            this.Btn_Prev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Btn_Prev.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Prev.Image")));
            this.Btn_Prev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_Prev.Name = "Btn_Prev";
            this.Btn_Prev.Size = new System.Drawing.Size(23, 22);
            this.Btn_Prev.Tag = "9";
            this.Btn_Prev.Text = "Previous";
            this.Btn_Prev.ToolTipText = "上一页";
            // 
            // tool_label1
            // 
            this.tool_label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tool_label1.Name = "tool_label1";
            this.tool_label1.Size = new System.Drawing.Size(22, 22);
            this.tool_label1.Text = " 1 ";
            // 
            // Btn_Next
            // 
            this.Btn_Next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Btn_Next.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Next.Image")));
            this.Btn_Next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_Next.Name = "Btn_Next";
            this.Btn_Next.Size = new System.Drawing.Size(23, 22);
            this.Btn_Next.Tag = "10";
            this.Btn_Next.Text = "Next";
            this.Btn_Next.ToolTipText = "下一页";
            // 
            // Btn_Last
            // 
            this.Btn_Last.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Btn_Last.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Last.Image")));
            this.Btn_Last.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_Last.Name = "Btn_Last";
            this.Btn_Last.Size = new System.Drawing.Size(23, 22);
            this.Btn_Last.Tag = "11";
            this.Btn_Last.Text = "Last";
            this.Btn_Last.ToolTipText = "尾页";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tool_label_page
            // 
            this.tool_label_page.Name = "tool_label_page";
            this.tool_label_page.Size = new System.Drawing.Size(44, 22);
            this.tool_label_page.Text = "当前页";
            // 
            // tool_Text_page
            // 
            this.tool_Text_page.Name = "tool_Text_page";
            this.tool_Text_page.Size = new System.Drawing.Size(40, 25);
            this.tool_Text_page.Text = "1";
            // 
            // Btn_goto
            // 
            this.Btn_goto.Image = ((System.Drawing.Image)(resources.GetObject("Btn_goto.Image")));
            this.Btn_goto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Btn_goto.Name = "Btn_goto";
            this.Btn_goto.Size = new System.Drawing.Size(45, 22);
            this.Btn_goto.Tag = "12";
            this.Btn_goto.Text = "Go";
            this.Btn_goto.ToolTipText = "跳转";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(6, 25);
            // 
            // tool_export
            // 
            this.tool_export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_export.Image = ((System.Drawing.Image)(resources.GetObject("tool_export.Image")));
            this.tool_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_export.Name = "tool_export";
            this.tool_export.Size = new System.Drawing.Size(23, 22);
            this.tool_export.Tag = "13";
            this.tool_export.Text = "toolStripButton1";
            this.tool_export.ToolTipText = "导出\r\n";
            // 
            // tool_print
            // 
            this.tool_print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tool_print.Image = ((System.Drawing.Image)(resources.GetObject("tool_print.Image")));
            this.tool_print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_print.Name = "tool_print";
            this.tool_print.Size = new System.Drawing.Size(23, 22);
            this.tool_print.Tag = "16";
            this.tool_print.Text = "toolStripButton2";
            this.tool_print.ToolTipText = "打印\r\n";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // shujudaorudaochu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 781);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "shujudaorudaochu";
            this.Text = "数据导入/导出";
            this.Load += new System.EventHandler(this.shujudaorudaochu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.page_output.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.page_input.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chx_selected;
        private System.Windows.Forms.CheckBox chx_all;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage page_output;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SJLX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage page_input;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_output;
        private System.Windows.Forms.Button btn_input;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox SXTJ;
        private System.Windows.Forms.Label lab_tjmc;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tool_label_record;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton Btn_First;
        private System.Windows.Forms.ToolStripButton Btn_Prev;
        private System.Windows.Forms.ToolStripLabel tool_label1;
        private System.Windows.Forms.ToolStripButton Btn_Next;
        private System.Windows.Forms.ToolStripButton Btn_Last;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel tool_label_page;
        private System.Windows.Forms.ToolStripTextBox tool_Text_page;
        private System.Windows.Forms.ToolStripButton Btn_goto;
        private System.Windows.Forms.ToolStripSeparator toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tool_export;
        private System.Windows.Forms.ToolStripButton tool_print;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}