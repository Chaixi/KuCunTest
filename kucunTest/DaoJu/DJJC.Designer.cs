namespace kucunTest.DaoJu
{
    partial class DJJC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PrintBtn = new System.Windows.Forms.Button();
            this.DJLX = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.刀套号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.刀具型号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.刀具ID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.材质 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.原始寿命 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.已用寿命 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.公称直径 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.实际直径 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.长度 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.直径补偿 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.长度补偿 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLinkColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.XHCH = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DJLX)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // PrintBtn
            // 
            this.PrintBtn.Location = new System.Drawing.Point(377, 56);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(75, 23);
            this.PrintBtn.TabIndex = 0;
            this.PrintBtn.Text = "立即更新";
            this.PrintBtn.UseVisualStyleBackColor = true;
            // 
            // DJLX
            // 
            this.DJLX.AllowUserToAddRows = false;
            this.DJLX.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.DJLX.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DJLX.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DJLX.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DJLX.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DJLX.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.刀套号,
            this.名称,
            this.刀具型号,
            this.刀具ID,
            this.材质,
            this.原始寿命,
            this.已用寿命,
            this.公称直径,
            this.实际直径,
            this.长度,
            this.直径补偿,
            this.长度补偿});
            this.DJLX.Location = new System.Drawing.Point(6, 20);
            this.DJLX.Name = "DJLX";
            this.DJLX.ReadOnly = true;
            this.DJLX.RowTemplate.Height = 23;
            this.DJLX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DJLX.Size = new System.Drawing.Size(753, 185);
            this.DJLX.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(426, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "刀具监测";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 85);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(172, 434);
            this.treeView1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "选择设备：";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(337, 188);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 0;
            this.SaveBtn.Text = "保存";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(94, 526);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(90, 17);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 526);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "正在加载……";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DJLX);
            this.groupBox1.Location = new System.Drawing.Point(191, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 211);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "刀具类型";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(192, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 217);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "机床刀具库";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "更新时间：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(240, 117);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 3;
            this.label15.Text = "预警寿命：";
            // 
            // textBox11
            // 
            this.textBox11.AutoCompleteCustomSource.AddRange(new string[] {
            "BT16",
            "BT50",
            "BT520",
            "BT80",
            "Colorman8080",
            "GS39032",
            "HSK100",
            "HSK20",
            "HSK212",
            "HSK40",
            "HSK52212",
            "HSK60",
            "HSK80",
            "lab212",
            "S1608032",
            " R331.32-080Q27EM10.00",
            " N331.1A-084508E-KL3220",
            " SCLCR2020K12",
            "SOMT120408PDER-GACK200",
            " C4-391.01-40080A",
            " R390-044C4-45M",
            "R390-11T316M-KM1020",
            " C3-391.01-32060A",
            " 870-2500-25-Pm4234",
            " C4-391.27-25*077",
            "870-2500-25L32-8",
            " 4736 308.100",
            " 3Z6070-18.5",
            "3Z750-19.70L",
            " 3Z1025-20.05SL",
            " C5-390.410-100-100A",
            "C8-390.410-100120A",
            " 5692022-06",
            " TXP20-D24.7A30P72",
            " C3-390.410-100 080A",
            "C6-390.410-100110A",
            " C4-390.410-100090A"});
            this.textBox11.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox11.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox11.Location = new System.Drawing.Point(312, 114);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 21);
            this.textBox11.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(240, 41);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 3;
            this.label17.Text = "刀具位置：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pictureBox2);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.textBox11);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.comboBox3);
            this.groupBox4.Controls.Add(this.comboBox2);
            this.groupBox4.Controls.Add(this.SaveBtn);
            this.groupBox4.Location = new System.Drawing.Point(538, 302);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(424, 217);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "更改设置";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(311, 77);
            this.comboBox3.MaxDropDownItems = 20;
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(101, 20);
            this.comboBox3.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(311, 38);
            this.comboBox2.MaxDropDownItems = 20;
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(101, 20);
            this.comboBox2.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(240, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "预警类型：";
            // 
            // 刀套号
            // 
            this.刀套号.HeaderText = "刀套号";
            this.刀套号.Name = "刀套号";
            this.刀套号.ReadOnly = true;
            // 
            // 名称
            // 
            this.名称.DataPropertyName = "mc";
            this.名称.HeaderText = "名称";
            this.名称.Name = "名称";
            this.名称.ReadOnly = true;
            // 
            // 刀具型号
            // 
            this.刀具型号.HeaderText = "型号";
            this.刀具型号.Name = "刀具型号";
            this.刀具型号.ReadOnly = true;
            // 
            // 刀具ID
            // 
            this.刀具ID.HeaderText = "刀具ID";
            this.刀具ID.Name = "刀具ID";
            this.刀具ID.ReadOnly = true;
            // 
            // 材质
            // 
            this.材质.HeaderText = "材质";
            this.材质.Name = "材质";
            this.材质.ReadOnly = true;
            // 
            // 原始寿命
            // 
            this.原始寿命.HeaderText = "原始寿命";
            this.原始寿命.Name = "原始寿命";
            this.原始寿命.ReadOnly = true;
            // 
            // 已用寿命
            // 
            this.已用寿命.HeaderText = "已用寿命";
            this.已用寿命.Name = "已用寿命";
            this.已用寿命.ReadOnly = true;
            // 
            // 公称直径
            // 
            this.公称直径.HeaderText = "公称直径";
            this.公称直径.Name = "公称直径";
            this.公称直径.ReadOnly = true;
            // 
            // 实际直径
            // 
            this.实际直径.HeaderText = "实际直径";
            this.实际直径.Name = "实际直径";
            this.实际直径.ReadOnly = true;
            // 
            // 长度
            // 
            this.长度.HeaderText = "实际长度";
            this.长度.Name = "长度";
            this.长度.ReadOnly = true;
            // 
            // 直径补偿
            // 
            this.直径补偿.HeaderText = "直径补偿";
            this.直径补偿.Name = "直径补偿";
            this.直径补偿.ReadOnly = true;
            // 
            // 长度补偿
            // 
            this.长度补偿.HeaderText = "长度补偿";
            this.长度补偿.Name = "长度补偿";
            this.长度补偿.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "刀具状态：";
            // 
            // textBox1
            // 
            this.textBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "BT16",
            "BT50",
            "BT520",
            "BT80",
            "Colorman8080",
            "GS39032",
            "HSK100",
            "HSK20",
            "HSK212",
            "HSK40",
            "HSK52212",
            "HSK60",
            "HSK80",
            "lab212",
            "S1608032",
            " R331.32-080Q27EM10.00",
            " N331.1A-084508E-KL3220",
            " SCLCR2020K12",
            "SOMT120408PDER-GACK200",
            " C4-391.01-40080A",
            " R390-044C4-45M",
            "R390-11T316M-KM1020",
            " C3-391.01-32060A",
            " 870-2500-25-Pm4234",
            " C4-391.27-25*077",
            "870-2500-25L32-8",
            " 4736 308.100",
            " 3Z6070-18.5",
            "3Z750-19.70L",
            " 3Z1025-20.05SL",
            " C5-390.410-100-100A",
            "C8-390.410-100120A",
            " 5692022-06",
            " TXP20-D24.7A30P72",
            " C3-390.410-100 080A",
            "C6-390.410-100110A",
            " C4-390.410-100090A"});
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox1.Location = new System.Drawing.Point(311, 148);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewLinkColumn1});
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(328, 192);
            this.dataGridView1.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "刀套号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "mc";
            this.dataGridViewTextBoxColumn2.HeaderText = "刀具名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "刀具型号";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewLinkColumn1
            // 
            this.dataGridViewLinkColumn1.HeaderText = "刀具状态";
            this.dataGridViewLinkColumn1.Name = "dataGridViewLinkColumn1";
            this.dataGridViewLinkColumn1.ReadOnly = true;
            this.dataGridViewLinkColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewLinkColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(881, 55);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchBtn.TabIndex = 0;
            this.SearchBtn.Text = "查询";
            this.SearchBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(695, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "型号查询：";
            // 
            // XHCH
            // 
            this.XHCH.AutoCompleteCustomSource.AddRange(new string[] {
            "BT16",
            "BT50",
            "BT520",
            "BT80",
            "Colorman8080",
            "GS39032",
            "HSK100",
            "HSK20",
            "HSK212",
            "HSK40",
            "HSK52212",
            "HSK60",
            "HSK80",
            "lab212",
            "S1608032",
            " R331.32-080Q27EM10.00",
            " N331.1A-084508E-KL3220",
            " SCLCR2020K12",
            "SOMT120408PDER-GACK200",
            " C4-391.01-40080A",
            " R390-044C4-45M",
            "R390-11T316M-KM1020",
            " C3-391.01-32060A",
            " 870-2500-25-Pm4234",
            " C4-391.27-25*077",
            "870-2500-25L32-8",
            " 4736 308.100",
            " 3Z6070-18.5",
            "3Z750-19.70L",
            " 3Z1025-20.05SL",
            " C5-390.410-100-100A",
            "C8-390.410-100120A",
            " 5692022-06",
            " TXP20-D24.7A30P72",
            " C3-390.410-100 080A",
            "C6-390.410-100110A",
            " C4-390.410-100090A"});
            this.XHCH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.XHCH.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.XHCH.Location = new System.Drawing.Point(766, 57);
            this.XHCH.Name = "XHCH";
            this.XHCH.Size = new System.Drawing.Size(100, 21);
            this.XHCH.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.AutoCompleteCustomSource.AddRange(new string[] {
            "BT16",
            "BT50",
            "BT520",
            "BT80",
            "Colorman8080",
            "GS39032",
            "HSK100",
            "HSK20",
            "HSK212",
            "HSK40",
            "HSK52212",
            "HSK60",
            "HSK80",
            "lab212",
            "S1608032",
            " R331.32-080Q27EM10.00",
            " N331.1A-084508E-KL3220",
            " SCLCR2020K12",
            "SOMT120408PDER-GACK200",
            " C4-391.01-40080A",
            " R390-044C4-45M",
            "R390-11T316M-KM1020",
            " C3-391.01-32060A",
            " 870-2500-25-Pm4234",
            " C4-391.27-25*077",
            "870-2500-25L32-8",
            " 4736 308.100",
            " 3Z6070-18.5",
            "3Z750-19.70L",
            " 3Z1025-20.05SL",
            " C5-390.410-100-100A",
            "C8-390.410-100120A",
            " 5692022-06",
            " TXP20-D24.7A30P72",
            " C3-390.410-100 080A",
            "C6-390.410-100110A",
            " C4-390.410-100090A"});
            this.textBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox2.Location = new System.Drawing.Point(259, 58);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 21);
            this.textBox2.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::kucunTest.Properties.Resources.立铣刀;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(7, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(227, 192);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // DJJC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 547);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.XHCH);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.PrintBtn);
            this.Name = "DJJC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "刀具监测";
            ((System.ComponentModel.ISupportInitialize)(this.DJLX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PrintBtn;
        private System.Windows.Forms.DataGridView DJLX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 刀套号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 刀具型号;
        private System.Windows.Forms.DataGridViewLinkColumn 刀具ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 材质;
        private System.Windows.Forms.DataGridViewTextBoxColumn 原始寿命;
        private System.Windows.Forms.DataGridViewTextBoxColumn 已用寿命;
        private System.Windows.Forms.DataGridViewTextBoxColumn 公称直径;
        private System.Windows.Forms.DataGridViewTextBoxColumn 实际直径;
        private System.Windows.Forms.DataGridViewTextBoxColumn 长度;
        private System.Windows.Forms.DataGridViewTextBoxColumn 直径补偿;
        private System.Windows.Forms.DataGridViewTextBoxColumn 长度补偿;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewLinkColumn1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox XHCH;
        private System.Windows.Forms.TextBox textBox2;
    }
}