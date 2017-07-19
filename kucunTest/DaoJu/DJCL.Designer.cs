namespace kucunTest.DaoJu
{
    partial class DJCL
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
            this.PrintBtn = new System.Windows.Forms.Button();
            this.DJLX = new System.Windows.Forms.DataGridView();
            this.刀具ID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.刀具型号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.用途 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.XHCH = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DJLX)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrintBtn
            // 
            this.PrintBtn.Location = new System.Drawing.Point(535, 515);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(75, 23);
            this.PrintBtn.TabIndex = 0;
            this.PrintBtn.Text = "数据库获取";
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
            this.刀具ID,
            this.刀具型号,
            this.名称,
            this.用途,
            this.备注});
            this.DJLX.Location = new System.Drawing.Point(6, 20);
            this.DJLX.Name = "DJLX";
            this.DJLX.ReadOnly = true;
            this.DJLX.RowTemplate.Height = 23;
            this.DJLX.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DJLX.Size = new System.Drawing.Size(478, 185);
            this.DJLX.TabIndex = 1;
            // 
            // 刀具ID
            // 
            this.刀具ID.HeaderText = "刀具ID";
            this.刀具ID.Name = "刀具ID";
            this.刀具ID.ReadOnly = true;
            // 
            // 刀具型号
            // 
            this.刀具型号.HeaderText = "型号";
            this.刀具型号.Name = "刀具型号";
            this.刀具型号.ReadOnly = true;
            // 
            // 名称
            // 
            this.名称.DataPropertyName = "mc";
            this.名称.HeaderText = "名称";
            this.名称.Name = "名称";
            this.名称.ReadOnly = true;
            // 
            // 用途
            // 
            this.用途.HeaderText = "用途";
            this.用途.Name = "用途";
            this.用途.ReadOnly = true;
            // 
            // 备注
            // 
            this.备注.DataPropertyName = "bz";
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            this.备注.ReadOnly = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(251, 58);
            this.comboBox1.MaxDropDownItems = 20;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(426, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "刀具测量";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 85);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(172, 434);
            this.treeView1.TabIndex = 4;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "选择刀具：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "工艺卡：";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(431, 515);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 0;
            this.SaveBtn.Text = "保存";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(400, 61);
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
            this.XHCH.Location = new System.Drawing.Point(471, 58);
            this.XHCH.Name = "XHCH";
            this.XHCH.Size = new System.Drawing.Size(100, 21);
            this.XHCH.TabIndex = 6;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(583, 56);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchBtn.TabIndex = 0;
            this.SearchBtn.Text = "查询";
            this.SearchBtn.UseVisualStyleBackColor = true;
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
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.DJLX);
            this.groupBox1.Location = new System.Drawing.Point(191, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 211);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "刀具类型";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Location = new System.Drawing.Point(493, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 191);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "图形概览";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 165);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.textBox6);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(192, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 190);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "测量数据";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(265, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 12);
            this.label14.TabIndex = 3;
            this.label14.Text = "刀具副偏角A2：";
            // 
            // textBox8
            // 
            this.textBox8.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.textBox8.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox8.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox8.Location = new System.Drawing.Point(360, 148);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 21);
            this.textBox8.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(265, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 3;
            this.label13.Text = "刀具主偏角A1：";
            // 
            // textBox7
            // 
            this.textBox7.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.textBox7.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox7.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox7.Location = new System.Drawing.Point(360, 106);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 21);
            this.textBox7.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(39, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "刀具长度实际值L：";
            // 
            // textBox6
            // 
            this.textBox6.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.textBox6.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox6.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox6.Location = new System.Drawing.Point(360, 69);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 21);
            this.textBox6.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "刀具半径实际值R：";
            // 
            // textBox5
            // 
            this.textBox5.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.textBox5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox5.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox5.Location = new System.Drawing.Point(360, 30);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 21);
            this.textBox5.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(289, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "径向跳动：";
            // 
            // textBox4
            // 
            this.textBox4.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.textBox4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox4.Location = new System.Drawing.Point(146, 148);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 21);
            this.textBox4.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(289, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "端面跳动：";
            // 
            // textBox3
            // 
            this.textBox3.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.textBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox3.Location = new System.Drawing.Point(146, 106);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(51, 151);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "刀尖圆弧半径R：";
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
            this.textBox2.Location = new System.Drawing.Point(146, 69);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "刀具轴截形刀段数量：";
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
            this.textBox1.Location = new System.Drawing.Point(146, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(643, 515);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "测量历史";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(759, 55);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(156, 21);
            this.dateTimePicker1.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(688, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "更新时间：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 33);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(125, 12);
            this.label15.TabIndex = 3;
            this.label15.Text = "当前工件表面粗糙度：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 72);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 12);
            this.label16.TabIndex = 3;
            this.label16.Text = "要求工件表面粗糙度：";
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
            this.textBox11.Location = new System.Drawing.Point(143, 106);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 21);
            this.textBox11.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(48, 109);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 12);
            this.label17.TabIndex = 3;
            this.label17.Text = "刀具存储位置：";
            // 
            // textBox12
            // 
            this.textBox12.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.textBox12.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox12.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox12.Location = new System.Drawing.Point(143, 148);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(100, 21);
            this.textBox12.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(48, 151);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 12);
            this.label18.TabIndex = 3;
            this.label18.Text = "刀具剩余寿命：";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.textBox12);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.textBox11);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.comboBox3);
            this.groupBox4.Controls.Add(this.comboBox2);
            this.groupBox4.Location = new System.Drawing.Point(690, 302);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(272, 190);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "其他参数";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(142, 66);
            this.comboBox3.MaxDropDownItems = 20;
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(101, 20);
            this.comboBox3.TabIndex = 2;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(142, 30);
            this.comboBox2.MaxDropDownItems = 20;
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(101, 20);
            this.comboBox2.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(750, 514);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "刀具出仓历史";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DJCL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 547);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.XHCH);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PrintBtn);
            this.Name = "DJCL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "刀具测量";
            this.Load += new System.EventHandler(this.DJCL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DJLX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PrintBtn;
        private System.Windows.Forms.DataGridView DJLX;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox XHCH;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewLinkColumn 刀具ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 刀具型号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 用途;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button2;
    }
}