namespace kucunTest.DaoJu
{
    partial class DJCZJL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.djsymx = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_czdh = new System.Windows.Forms.DataGridViewLinkColumn();
            this.dgv_czlx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_djlx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_djgg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_djid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_djwz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_czsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_jbr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.djsymx)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // djsymx
            // 
            this.djsymx.AllowUserToAddRows = false;
            this.djsymx.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.djsymx.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.djsymx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.djsymx.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.djsymx.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.djsymx.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.djsymx.ColumnHeadersHeight = 30;
            this.djsymx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_czdh,
            this.dgv_czlx,
            this.dgv_djlx,
            this.dgv_djgg,
            this.dgv_djid,
            this.dgv_djwz,
            this.dgv_czsj,
            this.dgv_jbr,
            this.dgv_bz});
            this.djsymx.Location = new System.Drawing.Point(10, 32);
            this.djsymx.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.djsymx.MultiSelect = false;
            this.djsymx.Name = "djsymx";
            this.djsymx.ReadOnly = true;
            this.djsymx.RowTemplate.Height = 30;
            this.djsymx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.djsymx.Size = new System.Drawing.Size(963, 221);
            this.djsymx.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.djsymx);
            this.groupBox1.Location = new System.Drawing.Point(14, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(981, 264);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "刀具使用明细";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 22F);
            this.label1.Location = new System.Drawing.Point(406, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "刀具操作记录";
            // 
            // dgv_czdh
            // 
            this.dgv_czdh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgv_czdh.DataPropertyName = "danhao";
            this.dgv_czdh.HeaderText = "操作单号";
            this.dgv_czdh.Name = "dgv_czdh";
            this.dgv_czdh.ReadOnly = true;
            this.dgv_czdh.Width = 180;
            // 
            // dgv_czlx
            // 
            this.dgv_czlx.DataPropertyName = "dhlx";
            this.dgv_czlx.HeaderText = "操作类型";
            this.dgv_czlx.Name = "dgv_czlx";
            this.dgv_czlx.ReadOnly = true;
            this.dgv_czlx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgv_djlx
            // 
            this.dgv_djlx.DataPropertyName = "djlx";
            this.dgv_djlx.HeaderText = "刀具类型";
            this.dgv_djlx.Name = "dgv_djlx";
            this.dgv_djlx.ReadOnly = true;
            // 
            // dgv_djgg
            // 
            this.dgv_djgg.DataPropertyName = "djgg";
            this.dgv_djgg.HeaderText = "刀具规格";
            this.dgv_djgg.Name = "dgv_djgg";
            this.dgv_djgg.ReadOnly = true;
            // 
            // dgv_djid
            // 
            this.dgv_djid.DataPropertyName = "djid";
            this.dgv_djid.HeaderText = "刀具ID";
            this.dgv_djid.Name = "dgv_djid";
            this.dgv_djid.ReadOnly = true;
            // 
            // dgv_djwz
            // 
            this.dgv_djwz.DataPropertyName = "djwz";
            this.dgv_djwz.HeaderText = "刀具位置";
            this.dgv_djwz.Name = "dgv_djwz";
            this.dgv_djwz.ReadOnly = true;
            // 
            // dgv_czsj
            // 
            this.dgv_czsj.DataPropertyName = "czsj";
            this.dgv_czsj.HeaderText = "操作时间";
            this.dgv_czsj.Name = "dgv_czsj";
            this.dgv_czsj.ReadOnly = true;
            this.dgv_czsj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgv_jbr
            // 
            this.dgv_jbr.DataPropertyName = "jbr";
            this.dgv_jbr.HeaderText = "经办人";
            this.dgv_jbr.Name = "dgv_jbr";
            this.dgv_jbr.ReadOnly = true;
            this.dgv_jbr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgv_bz
            // 
            this.dgv_bz.DataPropertyName = "bz";
            this.dgv_bz.HeaderText = "备注";
            this.dgv_bz.Name = "dgv_bz";
            this.dgv_bz.ReadOnly = true;
            this.dgv_bz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DJCZJL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 319);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "DJCZJL";
            this.Text = "刀具操作记录";
            this.Load += new System.EventHandler(this.DJCZJL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.djsymx)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView djsymx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewLinkColumn dgv_czdh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_czlx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_djlx;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_djgg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_djid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_djwz;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_czsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_jbr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_bz;
    }
}