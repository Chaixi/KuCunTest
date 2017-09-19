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
            this.label2 = new System.Windows.Forms.Label();
            this.lbjlx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.djgmc = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.kcmx = new System.Windows.Forms.DataGridView();
            this.czjl = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.czjl)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 22F);
            this.label1.Location = new System.Drawing.Point(309, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "零部件库存明细";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.djgmc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbjlx);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(847, 78);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "筛选条件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(40, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "零部件类型";
            // 
            // lbjlx
            // 
            this.lbjlx.Location = new System.Drawing.Point(136, 28);
            this.lbjlx.Name = "lbjlx";
            this.lbjlx.Size = new System.Drawing.Size(137, 29);
            this.lbjlx.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(320, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "刀具柜名称";
            // 
            // djgmc
            // 
            this.djgmc.FormattingEnabled = true;
            this.djgmc.Location = new System.Drawing.Point(408, 27);
            this.djgmc.Name = "djgmc";
            this.djgmc.Size = new System.Drawing.Size(146, 29);
            this.djgmc.TabIndex = 3;
            this.djgmc.SelectedIndexChanged += new System.EventHandler(this.jcbm_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(630, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.kcmx);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(847, 237);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "库存明细";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.czjl);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(12, 369);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(847, 260);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作记录";
            // 
            // kcmx
            // 
            this.kcmx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.kcmx.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.kcmx.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.kcmx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.kcmx.Location = new System.Drawing.Point(6, 28);
            this.kcmx.Name = "kcmx";
            this.kcmx.ReadOnly = true;
            this.kcmx.RowTemplate.Height = 23;
            this.kcmx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.kcmx.Size = new System.Drawing.Size(835, 203);
            this.kcmx.TabIndex = 0;
            this.kcmx.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.kcmx_CellContentClick);
            // 
            // czjl
            // 
            this.czjl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.czjl.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.czjl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.czjl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11});
            this.czjl.Location = new System.Drawing.Point(6, 28);
            this.czjl.Name = "czjl";
            this.czjl.RowTemplate.Height = 23;
            this.czjl.Size = new System.Drawing.Size(835, 226);
            this.czjl.TabIndex = 1;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "daojuid";
            this.Column5.HeaderText = "零部件名称";
            this.Column5.Name = "Column5";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "daojuxinghao";
            this.Column1.HeaderText = "零部件型号";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "daojuguige";
            this.Column2.HeaderText = "零部件规格";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "daojuleixing";
            this.Column3.HeaderText = "零部件类型";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "kcsl";
            this.Column4.HeaderText = "可用数量";
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "danhao";
            this.Column6.HeaderText = "操作单号";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "dhlx";
            this.Column7.HeaderText = "操作类型";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "fsl";
            this.Column8.HeaderText = "领用数量";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "zsl";
            this.Column9.HeaderText = "退还数量";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "czsj";
            this.Column10.HeaderText = "操作时间";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "jbr";
            this.Column11.HeaderText = "经办人";
            this.Column11.Name = "Column11";
            // 
            // lbjkcmx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 641);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "lbjkcmx";
            this.Text = "零部件库存明细";
            this.Load += new System.EventHandler(this.lbjkcmx_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.czjl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lbjlx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox djgmc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView kcmx;
        private System.Windows.Forms.DataGridView czjl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
    }
}