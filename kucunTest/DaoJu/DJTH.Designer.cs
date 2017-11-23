namespace kucunTest.DaoJu
{
    partial class DJTH
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.THRQ = new System.Windows.Forms.DateTimePicker();
            this.THBZ = new System.Windows.Forms.ComboBox();
            this.THYY = new System.Windows.Forms.TextBox();
            this.THR = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.THDH = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TuiHuanMingXi = new System.Windows.Forms.DataGridView();
            this.mx_djlx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mx_djgg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mx_djcd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mx_djid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mx_djzt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mx_sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mx_jcbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mx_dth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mx_djgbm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mx_cfwz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mx_bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_new = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.heji = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.JBRQ = new System.Windows.Forms.DateTimePicker();
            this.JBR = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_print = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.button_history = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TuiHuanMingXi)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 22F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(986, 76);
            this.label1.TabIndex = 2;
            this.label1.Text = "机一车间数控刀具机床退还单";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(503, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "退还日期：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "经 办 人：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.THRQ);
            this.groupBox1.Controls.Add(this.THBZ);
            this.groupBox1.Controls.Add(this.THYY);
            this.groupBox1.Controls.Add(this.THR);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(962, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "退还信息";
            // 
            // THRQ
            // 
            this.THRQ.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.THRQ.Location = new System.Drawing.Point(599, 21);
            this.THRQ.Name = "THRQ";
            this.THRQ.Size = new System.Drawing.Size(200, 29);
            this.THRQ.TabIndex = 4;
            this.THRQ.Value = new System.DateTime(2017, 5, 2, 0, 0, 0, 0);
            this.THRQ.ValueChanged += new System.EventHandler(this.THRQ_ValueChanged);
            // 
            // THBZ
            // 
            this.THBZ.AutoCompleteCustomSource.AddRange(new string[] {
            "先锋一班",
            "胜利二班",
            "机动科"});
            this.THBZ.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.THBZ.FormattingEnabled = true;
            this.THBZ.Location = new System.Drawing.Point(136, 24);
            this.THBZ.Name = "THBZ";
            this.THBZ.Size = new System.Drawing.Size(199, 29);
            this.THBZ.TabIndex = 2;
            // 
            // THYY
            // 
            this.THYY.Location = new System.Drawing.Point(599, 71);
            this.THYY.Name = "THYY";
            this.THYY.Size = new System.Drawing.Size(349, 29);
            this.THYY.TabIndex = 1;
            // 
            // THR
            // 
            this.THR.Location = new System.Drawing.Point(136, 71);
            this.THR.Name = "THR";
            this.THR.Size = new System.Drawing.Size(199, 29);
            this.THR.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(455, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "退还原因或备注：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "退还班组：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(46, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 21);
            this.label10.TabIndex = 0;
            this.label10.Text = "退 还 人：";
            // 
            // THDH
            // 
            this.THDH.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.THDH.Location = new System.Drawing.Point(809, 44);
            this.THDH.Name = "THDH";
            this.THDH.Size = new System.Drawing.Size(151, 29);
            this.THDH.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TuiHuanMingXi);
            this.groupBox2.Controls.Add(this.button_delete);
            this.groupBox2.Controls.Add(this.button_new);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.heji);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(962, 280);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "退还明细";
            // 
            // TuiHuanMingXi
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            this.TuiHuanMingXi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.TuiHuanMingXi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.TuiHuanMingXi.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TuiHuanMingXi.ColumnHeadersHeight = 30;
            this.TuiHuanMingXi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mx_djlx,
            this.mx_djgg,
            this.mx_djcd,
            this.mx_djid,
            this.mx_djzt,
            this.mx_sl,
            this.mx_jcbm,
            this.mx_dth,
            this.mx_djgbm,
            this.mx_cfwz,
            this.mx_bz});
            this.TuiHuanMingXi.Dock = System.Windows.Forms.DockStyle.Top;
            this.TuiHuanMingXi.Location = new System.Drawing.Point(3, 25);
            this.TuiHuanMingXi.Name = "TuiHuanMingXi";
            this.TuiHuanMingXi.RowHeadersWidth = 30;
            this.TuiHuanMingXi.RowTemplate.Height = 23;
            this.TuiHuanMingXi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TuiHuanMingXi.Size = new System.Drawing.Size(956, 214);
            this.TuiHuanMingXi.TabIndex = 0;
            this.TuiHuanMingXi.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.MingXi_RowPostPaint);
            // 
            // mx_djlx
            // 
            this.mx_djlx.DataPropertyName = "djlx";
            this.mx_djlx.FillWeight = 136.9102F;
            this.mx_djlx.HeaderText = "刀具类型";
            this.mx_djlx.Name = "mx_djlx";
            this.mx_djlx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.mx_djlx.Width = 99;
            // 
            // mx_djgg
            // 
            this.mx_djgg.DataPropertyName = "djgg";
            this.mx_djgg.FillWeight = 137.475F;
            this.mx_djgg.HeaderText = "刀具规格";
            this.mx_djgg.Name = "mx_djgg";
            this.mx_djgg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.mx_djgg.Width = 99;
            // 
            // mx_djcd
            // 
            this.mx_djcd.DataPropertyName = "djcd";
            this.mx_djcd.FillWeight = 82.66118F;
            this.mx_djcd.HeaderText = "刀具长度";
            this.mx_djcd.Name = "mx_djcd";
            this.mx_djcd.Width = 99;
            // 
            // mx_djid
            // 
            this.mx_djid.DataPropertyName = "djid";
            this.mx_djid.FillWeight = 110.0969F;
            this.mx_djid.HeaderText = "刀具ID";
            this.mx_djid.Name = "mx_djid";
            this.mx_djid.Width = 84;
            // 
            // mx_djzt
            // 
            this.mx_djzt.DataPropertyName = "djzt";
            this.mx_djzt.FillWeight = 82.3261F;
            this.mx_djzt.HeaderText = "刀具状态";
            this.mx_djzt.Name = "mx_djzt";
            this.mx_djzt.Width = 99;
            // 
            // mx_sl
            // 
            this.mx_sl.DataPropertyName = "sl";
            this.mx_sl.FillWeight = 48.55925F;
            this.mx_sl.HeaderText = "数量";
            this.mx_sl.Name = "mx_sl";
            this.mx_sl.Width = 67;
            // 
            // mx_jcbm
            // 
            this.mx_jcbm.DataPropertyName = "jcbm";
            this.mx_jcbm.FillWeight = 108.7819F;
            this.mx_jcbm.HeaderText = "机床编码";
            this.mx_jcbm.Name = "mx_jcbm";
            this.mx_jcbm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.mx_jcbm.Width = 99;
            // 
            // mx_dth
            // 
            this.mx_dth.DataPropertyName = "dth";
            this.mx_dth.FillWeight = 65.58608F;
            this.mx_dth.HeaderText = "刀套号";
            this.mx_dth.Name = "mx_dth";
            this.mx_dth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.mx_dth.Width = 83;
            // 
            // mx_djgbm
            // 
            this.mx_djgbm.DataPropertyName = "djgbm";
            this.mx_djgbm.FillWeight = 102.3477F;
            this.mx_djgbm.HeaderText = "刀具柜编码";
            this.mx_djgbm.Name = "mx_djgbm";
            this.mx_djgbm.Width = 115;
            // 
            // mx_cfwz
            // 
            this.mx_cfwz.DataPropertyName = "cfwz";
            this.mx_cfwz.FillWeight = 88.69971F;
            this.mx_cfwz.HeaderText = "存放位置";
            this.mx_cfwz.Name = "mx_cfwz";
            this.mx_cfwz.Width = 99;
            // 
            // mx_bz
            // 
            this.mx_bz.DataPropertyName = "bz";
            this.mx_bz.FillWeight = 115.4083F;
            this.mx_bz.HeaderText = "备注";
            this.mx_bz.Name = "mx_bz";
            this.mx_bz.Width = 67;
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(91, 246);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(66, 28);
            this.button_delete.TabIndex = 5;
            this.button_delete.Text = "删除";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_new
            // 
            this.button_new.Location = new System.Drawing.Point(11, 245);
            this.button_new.Name = "button_new";
            this.button_new.Size = new System.Drawing.Size(65, 28);
            this.button_new.TabIndex = 5;
            this.button_new.Text = "新增";
            this.button_new.UseVisualStyleBackColor = true;
            this.button_new.Click += new System.EventHandler(this.button2_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(708, 253);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(202, 21);
            this.label15.TabIndex = 0;
            this.label15.Text = "合计：本次共退还刀具数量";
            // 
            // heji
            // 
            this.heji.Enabled = false;
            this.heji.Location = new System.Drawing.Point(916, 250);
            this.heji.Name = "heji";
            this.heji.Size = new System.Drawing.Size(32, 29);
            this.heji.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.JBRQ);
            this.groupBox3.Controls.Add(this.JBR);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(12, 492);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(962, 74);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作信息";
            // 
            // JBRQ
            // 
            this.JBRQ.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.JBRQ.Location = new System.Drawing.Point(633, 25);
            this.JBRQ.Name = "JBRQ";
            this.JBRQ.Size = new System.Drawing.Size(166, 29);
            this.JBRQ.TabIndex = 4;
            this.JBRQ.Value = new System.DateTime(2017, 5, 2, 0, 0, 0, 0);
            // 
            // JBR
            // 
            this.JBR.FormattingEnabled = true;
            this.JBR.Items.AddRange(new object[] {
            "赵经手",
            "钱刀管",
            "孙大帐"});
            this.JBR.Location = new System.Drawing.Point(134, 28);
            this.JBR.Name = "JBR";
            this.JBR.Size = new System.Drawing.Size(186, 29);
            this.JBR.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(537, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "经办日期：";
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_cancel.Location = new System.Drawing.Point(501, 592);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(87, 36);
            this.button_cancel.TabIndex = 3;
            this.button_cancel.Text = "删除单据";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_print
            // 
            this.button_print.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_print.Location = new System.Drawing.Point(408, 592);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(87, 36);
            this.button_print.TabIndex = 3;
            this.button_print.Text = "打印单据";
            this.button_print.UseVisualStyleBackColor = true;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // button_save
            // 
            this.button_save.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_save.Location = new System.Drawing.Point(313, 592);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(87, 36);
            this.button_save.TabIndex = 5;
            this.button_save.Text = "确认单据";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_history
            // 
            this.button_history.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_history.Location = new System.Drawing.Point(688, 592);
            this.button_history.Name = "button_history";
            this.button_history.Size = new System.Drawing.Size(87, 36);
            this.button_history.TabIndex = 3;
            this.button_history.Text = "退还历史";
            this.button_history.UseVisualStyleBackColor = true;
            this.button_history.Visible = false;
            this.button_history.Click += new System.EventHandler(this.button_history_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(745, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "单号：";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(220, 592);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "保存单据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(597, 592);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 36);
            this.button3.TabIndex = 7;
            this.button3.Text = "退    出";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // DJTH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(986, 641);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.THDH);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_history);
            this.Controls.Add(this.button_print);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "DJTH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "刀具退还单";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DJTH_FormClosed);
            this.Load += new System.EventHandler(this.DJTH_Load);
            this.SizeChanged += new System.EventHandler(this.DJTH_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TuiHuanMingXi)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region 声明变量
        //标签：Label
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        //区域划分：groupBox
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_print;
        private System.Windows.Forms.Button button_cancel;
        //表格：DataGridView
        private System.Windows.Forms.DataGridView TuiHuanMingXi;
        private System.Windows.Forms.TextBox THDH;
        private System.Windows.Forms.ComboBox JBR;
        private System.Windows.Forms.DateTimePicker THRQ;

        #endregion 声明变量结束
        private System.Windows.Forms.TextBox THR;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_new;
        private System.Windows.Forms.Button button_history;
        private System.Windows.Forms.ComboBox THBZ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn djID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox heji;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox THYY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn mx_djlx;
        private System.Windows.Forms.DataGridViewTextBoxColumn mx_djgg;
        private System.Windows.Forms.DataGridViewTextBoxColumn mx_djcd;
        private System.Windows.Forms.DataGridViewTextBoxColumn mx_djid;
        private System.Windows.Forms.DataGridViewTextBoxColumn mx_djzt;
        private System.Windows.Forms.DataGridViewTextBoxColumn mx_sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn mx_jcbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn mx_dth;
        private System.Windows.Forms.DataGridViewTextBoxColumn mx_djgbm;
        private System.Windows.Forms.DataGridViewTextBoxColumn mx_cfwz;
        private System.Windows.Forms.DataGridViewTextBoxColumn mx_bz;
        private System.Windows.Forms.DateTimePicker JBRQ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}