namespace kucunTest.DaoJu
{
    partial class DJGL
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
            this.PrintBtn = new System.Windows.Forms.Button();
            this.DJLX = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.XHCH = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.刀具ID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.刀具型号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.用途 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ZCMX = new System.Windows.Forms.DataGridView();
            this.组件型号 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.组件名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.组成数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DJLX)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZCMX)).BeginInit();
            this.SuspendLayout();
            // 
            // PrintBtn
            // 
            this.PrintBtn.Location = new System.Drawing.Point(878, 56);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(75, 23);
            this.PrintBtn.TabIndex = 0;
            this.PrintBtn.Text = "打印";
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
            this.DJLX.Size = new System.Drawing.Size(753, 223);
            this.DJLX.TabIndex = 1;
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
            this.label1.Size = new System.Drawing.Size(174, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "刀具概览信息";
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
            this.label2.Text = "选择类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "刀具柜：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(664, 60);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 16);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "只显示预警";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(797, 56);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 0;
            this.SaveBtn.Text = "导出";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(388, 61);
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
            this.XHCH.Location = new System.Drawing.Point(459, 58);
            this.XHCH.Name = "XHCH";
            this.XHCH.Size = new System.Drawing.Size(100, 21);
            this.XHCH.TabIndex = 6;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(571, 56);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchBtn.TabIndex = 0;
            this.SearchBtn.Text = "查询";
            this.SearchBtn.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(82, 525);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(103, 17);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DJLX);
            this.groupBox1.Location = new System.Drawing.Point(191, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 249);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "刀具类型";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ZCMX);
            this.groupBox2.Location = new System.Drawing.Point(190, 340);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 179);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "组成明细";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 153);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Location = new System.Drawing.Point(681, 340);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 179);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "图形概览";
            // 
            // ZCMX
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ZCMX.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.ZCMX.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ZCMX.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ZCMX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ZCMX.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.组件型号,
            this.组件名称,
            this.组成数量});
            this.ZCMX.Location = new System.Drawing.Point(7, 21);
            this.ZCMX.Name = "ZCMX";
            this.ZCMX.RowTemplate.Height = 23;
            this.ZCMX.Size = new System.Drawing.Size(470, 152);
            this.ZCMX.TabIndex = 0;
            // 
            // 组件型号
            // 
            this.组件型号.HeaderText = "组件型号";
            this.组件型号.Name = "组件型号";
            this.组件型号.ReadOnly = true;
            this.组件型号.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.组件型号.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 组件名称
            // 
            this.组件名称.HeaderText = "组件名称";
            this.组件名称.Name = "组件名称";
            this.组件名称.ReadOnly = true;
            // 
            // 组成数量
            // 
            this.组成数量.HeaderText = "组成数量";
            this.组成数量.Name = "组成数量";
            this.组成数量.ReadOnly = true;
            // 
            // DJGL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 547);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.XHCH);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.PrintBtn);
            this.Name = "DJGL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "刀具概览信息";
            this.Load += new System.EventHandler(this.DJGL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DJLX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ZCMX)).EndInit();
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
        private System.Windows.Forms.CheckBox checkBox1;
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
        private System.Windows.Forms.DataGridView ZCMX;
        private System.Windows.Forms.DataGridViewLinkColumn 组件型号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 组件名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 组成数量;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}