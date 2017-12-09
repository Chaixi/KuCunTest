namespace kucunTest.LingBuJian
{
    partial class lbjkcmx
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_lbjmc = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbx_cs = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_djgmc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kcmx = new System.Windows.Forms.DataGridView();
            this.kcmx_lbjmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kcmx_lbjgg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kcmx_lbjxh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kcmx_djgbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kcmx_jtwz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kcmx_kcsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kcmx_dw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.czjl = new System.Windows.Forms.DataGridView();
            this.czjl_dh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.czjl_dskykc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.czjl_zsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.czjl_fsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.czjl_jbr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.czjl_bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.czjl_czsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmx)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.czjl)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 22F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1015, 63);
            this.label1.TabIndex = 1;
            this.label1.Text = "零部件库存明细";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_lbjmc);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cbx_cs);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbx_djgmc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(991, 78);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "筛选条件";
            // 
            // cbx_lbjmc
            // 
            this.cbx_lbjmc.FormattingEnabled = true;
            this.cbx_lbjmc.Location = new System.Drawing.Point(135, 28);
            this.cbx_lbjmc.Name = "cbx_lbjmc";
            this.cbx_lbjmc.Size = new System.Drawing.Size(199, 29);
            this.cbx_lbjmc.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(888, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbx_cs
            // 
            this.cbx_cs.FormattingEnabled = true;
            this.cbx_cs.Location = new System.Drawing.Point(738, 28);
            this.cbx_cs.Name = "cbx_cs";
            this.cbx_cs.Size = new System.Drawing.Size(123, 29);
            this.cbx_cs.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label4.Location = new System.Drawing.Point(690, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "层数";
            // 
            // cbx_djgmc
            // 
            this.cbx_djgmc.FormattingEnabled = true;
            this.cbx_djgmc.Location = new System.Drawing.Point(478, 28);
            this.cbx_djgmc.Name = "cbx_djgmc";
            this.cbx_djgmc.Size = new System.Drawing.Size(166, 29);
            this.cbx_djgmc.TabIndex = 3;
            this.cbx_djgmc.SelectedIndexChanged += new System.EventHandler(this.djgbm_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(382, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "刀具柜名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(39, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "零部件名称";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.kcmx);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(991, 319);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "库存明细";
            // 
            // kcmx
            // 
            this.kcmx.AllowUserToAddRows = false;
            this.kcmx.AllowUserToDeleteRows = false;
            this.kcmx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.kcmx.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.kcmx.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.kcmx.ColumnHeadersHeight = 30;
            this.kcmx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kcmx_lbjmc,
            this.kcmx_lbjgg,
            this.kcmx_lbjxh,
            this.kcmx_djgbm,
            this.kcmx_jtwz,
            this.kcmx_kcsl,
            this.kcmx_dw});
            this.kcmx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kcmx.Location = new System.Drawing.Point(3, 25);
            this.kcmx.MultiSelect = false;
            this.kcmx.Name = "kcmx";
            this.kcmx.ReadOnly = true;
            this.kcmx.RowTemplate.Height = 23;
            this.kcmx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kcmx.Size = new System.Drawing.Size(985, 291);
            this.kcmx.TabIndex = 0;
            this.kcmx.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kcmx_CellClick);
            // 
            // kcmx_lbjmc
            // 
            this.kcmx_lbjmc.DataPropertyName = "lbjmc";
            this.kcmx_lbjmc.HeaderText = "零部件名称";
            this.kcmx_lbjmc.Name = "kcmx_lbjmc";
            this.kcmx_lbjmc.ReadOnly = true;
            this.kcmx_lbjmc.Width = 115;
            // 
            // kcmx_lbjgg
            // 
            this.kcmx_lbjgg.DataPropertyName = "lbjgg";
            this.kcmx_lbjgg.HeaderText = "零部件规格";
            this.kcmx_lbjgg.Name = "kcmx_lbjgg";
            this.kcmx_lbjgg.ReadOnly = true;
            this.kcmx_lbjgg.Width = 115;
            // 
            // kcmx_lbjxh
            // 
            this.kcmx_lbjxh.DataPropertyName = "lbjxh";
            this.kcmx_lbjxh.HeaderText = "零部件型号";
            this.kcmx_lbjxh.Name = "kcmx_lbjxh";
            this.kcmx_lbjxh.ReadOnly = true;
            this.kcmx_lbjxh.Width = 115;
            // 
            // kcmx_djgbm
            // 
            this.kcmx_djgbm.DataPropertyName = "djgbm";
            this.kcmx_djgbm.HeaderText = "所在刀柜";
            this.kcmx_djgbm.Name = "kcmx_djgbm";
            this.kcmx_djgbm.ReadOnly = true;
            this.kcmx_djgbm.Width = 99;
            // 
            // kcmx_jtwz
            // 
            this.kcmx_jtwz.DataPropertyName = "jtwz";
            this.kcmx_jtwz.HeaderText = "所在层数";
            this.kcmx_jtwz.Name = "kcmx_jtwz";
            this.kcmx_jtwz.ReadOnly = true;
            this.kcmx_jtwz.Width = 99;
            // 
            // kcmx_kcsl
            // 
            this.kcmx_kcsl.DataPropertyName = "kcsl";
            this.kcmx_kcsl.HeaderText = "库存数量";
            this.kcmx_kcsl.Name = "kcmx_kcsl";
            this.kcmx_kcsl.ReadOnly = true;
            this.kcmx_kcsl.Width = 99;
            // 
            // kcmx_dw
            // 
            this.kcmx_dw.DataPropertyName = "dw";
            this.kcmx_dw.HeaderText = "单位";
            this.kcmx_dw.Name = "kcmx_dw";
            this.kcmx_dw.ReadOnly = true;
            this.kcmx_dw.Width = 67;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.czjl);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(12, 475);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(991, 260);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作记录";
            // 
            // czjl
            // 
            this.czjl.AllowUserToAddRows = false;
            this.czjl.AllowUserToDeleteRows = false;
            this.czjl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.czjl.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.czjl.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.czjl.ColumnHeadersHeight = 30;
            this.czjl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.czjl_dh,
            this.Column7,
            this.czjl_dskykc,
            this.czjl_zsl,
            this.czjl_fsl,
            this.czjl_jbr,
            this.czjl_bz,
            this.czjl_czsj});
            this.czjl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.czjl.Location = new System.Drawing.Point(3, 25);
            this.czjl.Name = "czjl";
            this.czjl.ReadOnly = true;
            this.czjl.RowTemplate.Height = 23;
            this.czjl.Size = new System.Drawing.Size(985, 232);
            this.czjl.TabIndex = 1;
            // 
            // czjl_dh
            // 
            this.czjl_dh.DataPropertyName = "danhao";
            this.czjl_dh.HeaderText = "操作单号";
            this.czjl_dh.Name = "czjl_dh";
            this.czjl_dh.ReadOnly = true;
            this.czjl_dh.Width = 99;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "dhlx";
            this.Column7.HeaderText = "操作类型";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 99;
            // 
            // czjl_dskykc
            // 
            this.czjl_dskykc.DataPropertyName = "dskykc";
            this.czjl_dskykc.HeaderText = "当时可用库存";
            this.czjl_dskykc.Name = "czjl_dskykc";
            this.czjl_dskykc.ReadOnly = true;
            this.czjl_dskykc.Width = 131;
            // 
            // czjl_zsl
            // 
            this.czjl_zsl.DataPropertyName = "zsl";
            this.czjl_zsl.HeaderText = "库存增加";
            this.czjl_zsl.Name = "czjl_zsl";
            this.czjl_zsl.ReadOnly = true;
            this.czjl_zsl.Width = 99;
            // 
            // czjl_fsl
            // 
            this.czjl_fsl.DataPropertyName = "fsl";
            this.czjl_fsl.HeaderText = "库存减少";
            this.czjl_fsl.Name = "czjl_fsl";
            this.czjl_fsl.ReadOnly = true;
            this.czjl_fsl.Width = 99;
            // 
            // czjl_jbr
            // 
            this.czjl_jbr.DataPropertyName = "jbr";
            this.czjl_jbr.HeaderText = "经办人";
            this.czjl_jbr.Name = "czjl_jbr";
            this.czjl_jbr.ReadOnly = true;
            this.czjl_jbr.Width = 83;
            // 
            // czjl_bz
            // 
            this.czjl_bz.DataPropertyName = "bz";
            this.czjl_bz.HeaderText = "备注";
            this.czjl_bz.Name = "czjl_bz";
            this.czjl_bz.ReadOnly = true;
            this.czjl_bz.Width = 67;
            // 
            // czjl_czsj
            // 
            this.czjl_czsj.DataPropertyName = "czsj";
            this.czjl_czsj.HeaderText = "操作时间";
            this.czjl_czsj.Name = "czjl_czsj";
            this.czjl_czsj.ReadOnly = true;
            this.czjl_czsj.Width = 99;
            // 
            // lbjkcmx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1015, 742);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "lbjkcmx";
            this.Text = "零部件库存明细";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.lbjkcmx_FormClosed);
            this.Load += new System.EventHandler(this.lbjkcmx_Load);
            this.SizeChanged += new System.EventHandler(this.lbjkcmx_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmx)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.czjl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_djgmc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView kcmx;
        private System.Windows.Forms.DataGridView czjl;
        private System.Windows.Forms.DataGridViewTextBoxColumn kcmx_lbjmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn kcmx_lbjgg;
        private System.Windows.Forms.DataGridViewTextBoxColumn kcmx_lbjxh;
        private System.Windows.Forms.DataGridViewTextBoxColumn kcmx_djgbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn kcmx_jtwz;
        private System.Windows.Forms.DataGridViewTextBoxColumn kcmx_kcsl;
        private System.Windows.Forms.DataGridViewTextBoxColumn kcmx_dw;
        private System.Windows.Forms.ComboBox cbx_lbjmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn czjl_dh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn czjl_dskykc;
        private System.Windows.Forms.DataGridViewTextBoxColumn czjl_zsl;
        private System.Windows.Forms.DataGridViewTextBoxColumn czjl_fsl;
        private System.Windows.Forms.DataGridViewTextBoxColumn czjl_jbr;
        private System.Windows.Forms.DataGridViewTextBoxColumn czjl_bz;
        private System.Windows.Forms.DataGridViewTextBoxColumn czjl_czsj;
        private System.Windows.Forms.ComboBox cbx_cs;
        private System.Windows.Forms.Label label4;
    }
}