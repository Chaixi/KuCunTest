namespace kucunTest.ChuCang
{
    partial class CCHistory
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LiShi = new System.Windows.Forms.DataGridView();
            this.LS_ccdh = new System.Windows.Forms.DataGridViewLinkColumn();
            this.LS_cclx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LS_ccrq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LS_czy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LS_bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MingXi = new System.Windows.Forms.DataGridView();
            this.MX_xinghao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MX_mc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MX_gg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MX_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MX_djgbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MX_cfwz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MX_bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewBtn = new System.Windows.Forms.Button();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CCDH_Txt = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.PrintBtn = new System.Windows.Forms.Button();
            this.AllBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LiShi)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MingXi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(117, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "出仓历史";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LiShi);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 215);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "历史出仓单";
            // 
            // LiShi
            // 
            this.LiShi.AllowUserToAddRows = false;
            this.LiShi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LiShi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.LiShi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LiShi.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LiShi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.LiShi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LS_ccdh,
            this.LS_cclx,
            this.LS_ccrq,
            this.LS_czy,
            this.LS_bz});
            this.LiShi.Location = new System.Drawing.Point(6, 20);
            this.LiShi.Name = "LiShi";
            this.LiShi.ReadOnly = true;
            this.LiShi.RowTemplate.Height = 23;
            this.LiShi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LiShi.Size = new System.Drawing.Size(657, 187);
            this.LiShi.TabIndex = 0;
            this.LiShi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LiShi_CellContentClick);
            this.LiShi.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.LiShi_RowPostPaint);
            // 
            // LS_ccdh
            // 
            this.LS_ccdh.DataPropertyName = "ccdh";
            this.LS_ccdh.HeaderText = "出仓单号";
            this.LS_ccdh.Name = "LS_ccdh";
            this.LS_ccdh.ReadOnly = true;
            this.LS_ccdh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // LS_cclx
            // 
            this.LS_cclx.DataPropertyName = "cclx";
            this.LS_cclx.HeaderText = "出仓类型";
            this.LS_cclx.Name = "LS_cclx";
            this.LS_cclx.ReadOnly = true;
            // 
            // LS_ccrq
            // 
            this.LS_ccrq.DataPropertyName = "ccrq";
            this.LS_ccrq.HeaderText = "出仓日期";
            this.LS_ccrq.Name = "LS_ccrq";
            this.LS_ccrq.ReadOnly = true;
            // 
            // LS_czy
            // 
            this.LS_czy.DataPropertyName = "czy";
            this.LS_czy.HeaderText = "操作员";
            this.LS_czy.Name = "LS_czy";
            this.LS_czy.ReadOnly = true;
            // 
            // LS_bz
            // 
            this.LS_bz.DataPropertyName = "bz";
            this.LS_bz.HeaderText = "备注";
            this.LS_bz.Name = "LS_bz";
            this.LS_bz.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MingXi);
            this.groupBox2.Location = new System.Drawing.Point(12, 297);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(669, 168);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "出仓单明细";
            // 
            // MingXi
            // 
            this.MingXi.AllowUserToAddRows = false;
            this.MingXi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MingXi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.MingXi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MingXi.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MingXi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.MingXi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MX_xinghao,
            this.MX_mc,
            this.MX_gg,
            this.MX_sl,
            this.MX_djgbm,
            this.MX_cfwz,
            this.MX_bz});
            this.MingXi.Location = new System.Drawing.Point(0, 20);
            this.MingXi.Name = "MingXi";
            this.MingXi.ReadOnly = true;
            this.MingXi.RowTemplate.Height = 23;
            this.MingXi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MingXi.Size = new System.Drawing.Size(663, 142);
            this.MingXi.TabIndex = 0;
            this.MingXi.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.MingXi_RowPostPaint);
            // 
            // MX_xinghao
            // 
            this.MX_xinghao.DataPropertyName = "xinghao";
            this.MX_xinghao.HeaderText = "型号";
            this.MX_xinghao.Name = "MX_xinghao";
            this.MX_xinghao.ReadOnly = true;
            // 
            // MX_mc
            // 
            this.MX_mc.DataPropertyName = "mc";
            this.MX_mc.HeaderText = "名称";
            this.MX_mc.Name = "MX_mc";
            this.MX_mc.ReadOnly = true;
            // 
            // MX_gg
            // 
            this.MX_gg.DataPropertyName = "gg";
            this.MX_gg.HeaderText = "规格";
            this.MX_gg.Name = "MX_gg";
            this.MX_gg.ReadOnly = true;
            // 
            // MX_sl
            // 
            this.MX_sl.DataPropertyName = "sl";
            this.MX_sl.HeaderText = "数量";
            this.MX_sl.Name = "MX_sl";
            this.MX_sl.ReadOnly = true;
            // 
            // MX_djgbm
            // 
            this.MX_djgbm.DataPropertyName = "djgbm";
            this.MX_djgbm.HeaderText = "刀具柜编码";
            this.MX_djgbm.Name = "MX_djgbm";
            this.MX_djgbm.ReadOnly = true;
            // 
            // MX_cfwz
            // 
            this.MX_cfwz.DataPropertyName = "cfwz";
            this.MX_cfwz.HeaderText = "存放位置";
            this.MX_cfwz.Name = "MX_cfwz";
            this.MX_cfwz.ReadOnly = true;
            // 
            // MX_bz
            // 
            this.MX_bz.DataPropertyName = "bz";
            this.MX_bz.HeaderText = "备注";
            this.MX_bz.Name = "MX_bz";
            this.MX_bz.ReadOnly = true;
            // 
            // NewBtn
            // 
            this.NewBtn.Location = new System.Drawing.Point(600, 30);
            this.NewBtn.Name = "NewBtn";
            this.NewBtn.Size = new System.Drawing.Size(75, 23);
            this.NewBtn.TabIndex = 2;
            this.NewBtn.Text = "新建出仓单";
            this.NewBtn.UseVisualStyleBackColor = true;
            this.NewBtn.Click += new System.EventHandler(this.NewBtn_Click);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(519, 30);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 23);
            this.SearchBtn.TabIndex = 3;
            this.SearchBtn.Text = "查询";
            this.SearchBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "单号查询：";
            // 
            // CCDH_Txt
            // 
            this.CCDH_Txt.Location = new System.Drawing.Point(407, 32);
            this.CCDH_Txt.Name = "CCDH_Txt";
            this.CCDH_Txt.Size = new System.Drawing.Size(100, 21);
            this.CCDH_Txt.TabIndex = 5;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(513, 473);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 1;
            this.SaveBtn.Text = "导出";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // PrintBtn
            // 
            this.PrintBtn.Location = new System.Drawing.Point(600, 473);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(75, 23);
            this.PrintBtn.TabIndex = 1;
            this.PrintBtn.Text = "打印";
            this.PrintBtn.UseVisualStyleBackColor = true;
            // 
            // AllBtn
            // 
            this.AllBtn.Location = new System.Drawing.Point(423, 473);
            this.AllBtn.Name = "AllBtn";
            this.AllBtn.Size = new System.Drawing.Size(75, 23);
            this.AllBtn.TabIndex = 1;
            this.AllBtn.Text = "查看全部";
            this.AllBtn.UseVisualStyleBackColor = true;
            this.AllBtn.Click += new System.EventHandler(this.AllBtn_Click);
            // 
            // CCHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 521);
            this.Controls.Add(this.AllBtn);
            this.Controls.Add(this.PrintBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.CCDH_Txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.NewBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "CCHistory";
            this.Text = "出仓历史";
            this.Load += new System.EventHandler(this.CCHistory_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LiShi)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MingXi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView MingXi;
        private System.Windows.Forms.DataGridView LiShi;
        private System.Windows.Forms.Button NewBtn;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CCDH_Txt;
        private System.Windows.Forms.DataGridViewLinkColumn LS_ccdh;
        private System.Windows.Forms.DataGridViewTextBoxColumn LS_cclx;
        private System.Windows.Forms.DataGridViewTextBoxColumn LS_ccrq;
        private System.Windows.Forms.DataGridViewTextBoxColumn LS_czy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LS_bz;
        private System.Windows.Forms.DataGridViewTextBoxColumn MX_xinghao;
        private System.Windows.Forms.DataGridViewTextBoxColumn MX_mc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MX_gg;
        private System.Windows.Forms.DataGridViewTextBoxColumn MX_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn MX_djgbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn MX_cfwz;
        private System.Windows.Forms.DataGridViewTextBoxColumn MX_bz;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button PrintBtn;
        private System.Windows.Forms.Button AllBtn;
    }
}