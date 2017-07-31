namespace kucunTest.Daojugui
{
    partial class daojugui
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kcmx = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.djgmmc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.djgbm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.djglx = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbjsl = new System.Windows.Forms.TextBox();
            this.djsl = new System.Windows.Forms.TextBox();
            this.djgccs = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.xzdjg = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lxcx = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.查询条件 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmx)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.查询条件.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(16, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 598);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "刀具柜名称";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 24);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(199, 567);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 22F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1173, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "刀具柜管理";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.kcmx);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(233, 294);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(932, 349);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "刀具柜库存";
            // 
            // kcmx
            // 
            this.kcmx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.kcmx.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.kcmx.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.kcmx.ColumnHeadersHeight = 30;
            this.kcmx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column9,
            this.Column3,
            this.Column8,
            this.Column5,
            this.Column6,
            this.Column1,
            this.Column7});
            this.kcmx.Location = new System.Drawing.Point(19, 28);
            this.kcmx.Name = "kcmx";
            this.kcmx.ReadOnly = true;
            this.kcmx.RowTemplate.Height = 23;
            this.kcmx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kcmx.Size = new System.Drawing.Size(894, 314);
            this.kcmx.TabIndex = 0;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "daojuid";
            this.Column2.HeaderText = "名称";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "daojuxinghao";
            this.Column9.HeaderText = "型号规格";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "type";
            this.Column3.HeaderText = "类型";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "daojuweizhi";
            this.Column8.HeaderText = "库存位置";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "kcsl";
            this.Column5.HeaderText = "库存数量";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "zuixiaokucun";
            this.Column6.HeaderText = "最小库存";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "zuidakucun";
            this.Column1.HeaderText = "最大库存";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "beizhu";
            this.Column7.HeaderText = "备注";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox3.Controls.Add(this.djgmmc);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.djgbm);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.djglx);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lbjsl);
            this.groupBox3.Controls.Add(this.djsl);
            this.groupBox3.Controls.Add(this.djgccs);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(233, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(722, 243);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "刀具柜信息";
            // 
            // djgmmc
            // 
            this.djgmmc.Location = new System.Drawing.Point(283, 60);
            this.djgmmc.Name = "djgmmc";
            this.djgmmc.ReadOnly = true;
            this.djgmmc.Size = new System.Drawing.Size(103, 29);
            this.djgmmc.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(187, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 21);
            this.label10.TabIndex = 10;
            this.label10.Text = "刀具柜名称";
            // 
            // djgbm
            // 
            this.djgbm.Location = new System.Drawing.Point(283, 101);
            this.djgbm.Name = "djgbm";
            this.djgbm.ReadOnly = true;
            this.djgbm.Size = new System.Drawing.Size(103, 29);
            this.djgbm.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(187, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 21);
            this.label8.TabIndex = 8;
            this.label8.Text = "刀具柜编码";
            // 
            // djglx
            // 
            this.djglx.Location = new System.Drawing.Point(283, 142);
            this.djglx.Name = "djglx";
            this.djglx.ReadOnly = true;
            this.djglx.Size = new System.Drawing.Size(103, 29);
            this.djglx.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(187, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "刀具柜类型";
            // 
            // lbjsl
            // 
            this.lbjsl.Location = new System.Drawing.Point(631, 184);
            this.lbjsl.Name = "lbjsl";
            this.lbjsl.ReadOnly = true;
            this.lbjsl.Size = new System.Drawing.Size(34, 29);
            this.lbjsl.TabIndex = 5;
            // 
            // djsl
            // 
            this.djsl.Location = new System.Drawing.Point(452, 184);
            this.djsl.Name = "djsl";
            this.djsl.ReadOnly = true;
            this.djsl.Size = new System.Drawing.Size(36, 29);
            this.djsl.TabIndex = 4;
            // 
            // djgccs
            // 
            this.djgccs.Location = new System.Drawing.Point(294, 184);
            this.djgccs.Name = "djgccs";
            this.djgccs.ReadOnly = true;
            this.djgccs.Size = new System.Drawing.Size(42, 29);
            this.djgccs.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(671, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "种。";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(494, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "把，存有零部件共";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(334, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "层，存有刀具共";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "本刀具柜总共";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::kucunTest.Properties.Resources.刀具柜;
            this.pictureBox1.Location = new System.Drawing.Point(19, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 182);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "刀具柜图片";
            // 
            // xzdjg
            // 
            this.xzdjg.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xzdjg.Location = new System.Drawing.Point(460, 659);
            this.xzdjg.Name = "xzdjg";
            this.xzdjg.Size = new System.Drawing.Size(94, 29);
            this.xzdjg.TabIndex = 4;
            this.xzdjg.Text = "新增刀具柜";
            this.xzdjg.UseVisualStyleBackColor = true;
            this.xzdjg.Click += new System.EventHandler(this.xzdjg_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(591, 659);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "库存明细";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lxcx
            // 
            this.lxcx.FormattingEnabled = true;
            this.lxcx.Items.AddRange(new object[] {
            "全部",
            "刀具",
            "零部件"});
            this.lxcx.Location = new System.Drawing.Point(112, 36);
            this.lxcx.Name = "lxcx";
            this.lxcx.Size = new System.Drawing.Size(78, 29);
            this.lxcx.TabIndex = 3;
            this.lxcx.SelectedIndexChanged += new System.EventHandler(this.lxcx_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 21);
            this.label11.TabIndex = 2;
            this.label11.Text = "按类型查询";
            // 
            // 查询条件
            // 
            this.查询条件.Controls.Add(this.lxcx);
            this.查询条件.Controls.Add(this.label11);
            this.查询条件.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.查询条件.Location = new System.Drawing.Point(961, 45);
            this.查询条件.Name = "查询条件";
            this.查询条件.Size = new System.Drawing.Size(204, 243);
            this.查询条件.TabIndex = 6;
            this.查询条件.TabStop = false;
            this.查询条件.Text = "查询条件";
            // 
            // daojugui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 700);
            this.Controls.Add(this.查询条件);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.xzdjg);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "daojugui";
            this.Text = "刀具柜管理";
            this.Load += new System.EventHandler(this.daojugui_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmx)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.查询条件.ResumeLayout(false);
            this.查询条件.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView kcmx;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lbjsl;
        private System.Windows.Forms.TextBox djsl;
        private System.Windows.Forms.TextBox djgccs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button xzdjg;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox djglx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox djgbm;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox djgmmc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox lxcx;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.GroupBox 查询条件;
    }
}