namespace kucunTest.RuCang
{
    partial class NewRC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RCRQ = new System.Windows.Forms.DateTimePicker();
            this.XQDH = new System.Windows.Forms.ComboBox();
            this.RCLX = new System.Windows.Forms.ComboBox();
            this.RCDH = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ruCangMingXi = new System.Windows.Forms.DataGridView();
            this.xh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mc = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.xinghao = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gg = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.djgbm = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cfwz = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CZY = new System.Windows.Forms.ComboBox();
            this.BM = new System.Windows.Forms.ComboBox();
            this.CJ = new System.Windows.Forms.ComboBox();
            this.comments = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.print = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.daochu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ruCangMingXi)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RCRQ);
            this.groupBox1.Controls.Add(this.XQDH);
            this.groupBox1.Controls.Add(this.RCLX);
            this.groupBox1.Controls.Add(this.RCDH);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "入仓信息";
            // 
            // RCRQ
            // 
            this.RCRQ.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.RCRQ.Location = new System.Drawing.Point(530, 30);
            this.RCRQ.Name = "RCRQ";
            this.RCRQ.Size = new System.Drawing.Size(135, 21);
            this.RCRQ.TabIndex = 4;
            this.RCRQ.Value = new System.DateTime(2017, 5, 2, 0, 0, 0, 0);
            // 
            // XQDH
            // 
            this.XQDH.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.XQDH.FormattingEnabled = true;
            this.XQDH.Items.AddRange(new object[] {
            "采购入仓",
            "已刃磨入仓",
            "机床退还入仓"});
            this.XQDH.Location = new System.Drawing.Point(79, 60);
            this.XQDH.Name = "XQDH";
            this.XQDH.Size = new System.Drawing.Size(121, 20);
            this.XQDH.TabIndex = 2;
            this.XQDH.Visible = false;
            // 
            // RCLX
            // 
            this.RCLX.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.RCLX.FormattingEnabled = true;
            this.RCLX.Items.AddRange(new object[] {
            "采购入仓",
            "已刃磨入仓",
            "机床退还入仓"});
            this.RCLX.Location = new System.Drawing.Point(79, 30);
            this.RCLX.Name = "RCLX";
            this.RCLX.Size = new System.Drawing.Size(121, 20);
            this.RCLX.TabIndex = 2;
            this.RCLX.SelectedIndexChanged += new System.EventHandler(this.RCLX_SelectedIndexChanged_1);
            // 
            // RCDH
            // 
            this.RCDH.Location = new System.Drawing.Point(302, 30);
            this.RCDH.Name = "RCDH";
            this.RCDH.ReadOnly = true;
            this.RCDH.Size = new System.Drawing.Size(121, 21);
            this.RCDH.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(464, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "入仓日期：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(241, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "入仓单号：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "需求/刃磨单号：";
            this.label9.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "入仓类型：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ruCangMingXi);
            this.groupBox2.Location = new System.Drawing.Point(13, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(778, 242);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "入仓明细";
            // 
            // ruCangMingXi
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            this.ruCangMingXi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.ruCangMingXi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ruCangMingXi.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ruCangMingXi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xh,
            this.mc,
            this.xinghao,
            this.gg,
            this.sl,
            this.djgbm,
            this.cfwz,
            this.bz});
            this.ruCangMingXi.Location = new System.Drawing.Point(7, 21);
            this.ruCangMingXi.Name = "ruCangMingXi";
            this.ruCangMingXi.RowTemplate.Height = 23;
            this.ruCangMingXi.Size = new System.Drawing.Size(765, 208);
            this.ruCangMingXi.TabIndex = 0;
            this.ruCangMingXi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ruCangMingXi_CellClick);
            this.ruCangMingXi.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ruCangMingXi_CellValueChanged);
            this.ruCangMingXi.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.ruCangMingXi_DefaultValuesNeeded_1);
            this.ruCangMingXi.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ruCangMingXi_RowPostPaint);
            // 
            // xh
            // 
            this.xh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.xh.HeaderText = "序号";
            this.xh.Name = "xh";
            this.xh.ReadOnly = true;
            this.xh.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.xh.Visible = false;
            // 
            // mc
            // 
            this.mc.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.mc.FillWeight = 127.8159F;
            this.mc.HeaderText = "名称";
            this.mc.Name = "mc";
            this.mc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.mc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // xinghao
            // 
            this.xinghao.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.xinghao.FillWeight = 127.8159F;
            this.xinghao.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.xinghao.HeaderText = "型号";
            this.xinghao.Name = "xinghao";
            this.xinghao.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.xinghao.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gg
            // 
            this.gg.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.gg.FillWeight = 86.65488F;
            this.gg.HeaderText = "规格";
            this.gg.Items.AddRange(new object[] {
            "件",
            "盒",
            "把"});
            this.gg.Name = "gg";
            this.gg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // sl
            // 
            this.sl.FillWeight = 82.00391F;
            this.sl.HeaderText = "数量";
            this.sl.Name = "sl";
            // 
            // djgbm
            // 
            this.djgbm.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.djgbm.FillWeight = 76.8274F;
            this.djgbm.HeaderText = "刀具柜编码";
            this.djgbm.Name = "djgbm";
            this.djgbm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.djgbm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cfwz
            // 
            this.cfwz.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cfwz.FillWeight = 71.06599F;
            this.cfwz.HeaderText = "存放位置";
            this.cfwz.Name = "cfwz";
            this.cfwz.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cfwz.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // bz
            // 
            this.bz.FillWeight = 127.8159F;
            this.bz.HeaderText = "备注";
            this.bz.Name = "bz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(352, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "入仓单";
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(710, 513);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CZY);
            this.groupBox3.Controls.Add(this.BM);
            this.groupBox3.Controls.Add(this.CJ);
            this.groupBox3.Controls.Add(this.comments);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(13, 410);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(778, 94);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作信息";
            // 
            // CZY
            // 
            this.CZY.FormattingEnabled = true;
            this.CZY.Items.AddRange(new object[] {
            "Jack",
            "Blue",
            "Tom",
            "二狗"});
            this.CZY.Location = new System.Drawing.Point(530, 23);
            this.CZY.Name = "CZY";
            this.CZY.Size = new System.Drawing.Size(121, 20);
            this.CZY.TabIndex = 2;
            // 
            // BM
            // 
            this.BM.FormattingEnabled = true;
            this.BM.Items.AddRange(new object[] {
            "刀管中心",
            "其他"});
            this.BM.Location = new System.Drawing.Point(302, 23);
            this.BM.Name = "BM";
            this.BM.Size = new System.Drawing.Size(121, 20);
            this.BM.TabIndex = 2;
            // 
            // CJ
            // 
            this.CJ.FormattingEnabled = true;
            this.CJ.Items.AddRange(new object[] {
            "机一车间",
            "其他车间"});
            this.CJ.Location = new System.Drawing.Point(79, 23);
            this.CJ.Name = "CJ";
            this.CJ.Size = new System.Drawing.Size(121, 20);
            this.CJ.TabIndex = 2;
            // 
            // comments
            // 
            this.comments.Location = new System.Drawing.Point(79, 53);
            this.comments.Multiline = true;
            this.comments.Name = "comments";
            this.comments.Size = new System.Drawing.Size(344, 35);
            this.comments.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "备    注：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "操 作 员：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "部    门：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "车    间：";
            // 
            // print
            // 
            this.print.Location = new System.Drawing.Point(618, 513);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(75, 23);
            this.print.TabIndex = 3;
            this.print.Text = "打印";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(433, 513);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 3;
            this.save.Text = "保存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(343, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "入仓完成";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // daochu
            // 
            this.daochu.Location = new System.Drawing.Point(523, 513);
            this.daochu.Name = "daochu";
            this.daochu.Size = new System.Drawing.Size(75, 23);
            this.daochu.TabIndex = 3;
            this.daochu.Text = "导出";
            this.daochu.UseVisualStyleBackColor = true;
            this.daochu.Click += new System.EventHandler(this.daochu_Click);
            // 
            // NewRC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.daochu);
            this.Controls.Add(this.save);
            this.Controls.Add(this.print);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NewRC";
            this.Text = "入仓单";
            this.Load += new System.EventHandler(this.RuCang_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ruCangMingXi)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox RCDH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView ruCangMingXi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ComboBox RCLX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CZY;
        private System.Windows.Forms.ComboBox BM;
        private System.Windows.Forms.ComboBox CJ;
        private System.Windows.Forms.TextBox comments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.DateTimePicker RCRQ;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button daochu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox XQDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn xh;
        private System.Windows.Forms.DataGridViewComboBoxColumn mc;
        private System.Windows.Forms.DataGridViewComboBoxColumn xinghao;
        private System.Windows.Forms.DataGridViewComboBoxColumn gg;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl;
        private System.Windows.Forms.DataGridViewComboBoxColumn djgbm;
        private System.Windows.Forms.DataGridViewComboBoxColumn cfwz;
        private System.Windows.Forms.DataGridViewTextBoxColumn bz;
    }
}