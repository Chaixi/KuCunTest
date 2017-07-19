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
            this.THR = new System.Windows.Forms.TextBox();
            this.DH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MingXi = new System.Windows.Forms.DataGridView();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_new = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.heji = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.JBR = new System.Windows.Forms.ComboBox();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_print = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.button_history = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CJ = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.JBRQ = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.THYY = new System.Windows.Forms.TextBox();
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
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MingXi)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(218, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "机一车间数控刀具机床退还单";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(558, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "退还日期：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(826, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "退还信息";
            // 
            // THRQ
            // 
            this.THRQ.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.THRQ.Location = new System.Drawing.Point(624, 21);
            this.THRQ.Name = "THRQ";
            this.THRQ.Size = new System.Drawing.Size(166, 21);
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
            this.THBZ.Items.AddRange(new object[] {
            "先锋一班",
            "胜利二班",
            "机动科"});
            this.THBZ.Location = new System.Drawing.Point(100, 24);
            this.THBZ.Name = "THBZ";
            this.THBZ.Size = new System.Drawing.Size(121, 20);
            this.THBZ.TabIndex = 2;
            // 
            // THR
            // 
            this.THR.Location = new System.Drawing.Point(367, 24);
            this.THR.Name = "THR";
            this.THR.Size = new System.Drawing.Size(121, 21);
            this.THR.TabIndex = 1;
            // 
            // DH
            // 
            this.DH.Location = new System.Drawing.Point(681, 59);
            this.DH.Name = "DH";
            this.DH.Size = new System.Drawing.Size(121, 21);
            this.DH.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "退还班组：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(305, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "退 还 人：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MingXi);
            this.groupBox2.Controls.Add(this.button_delete);
            this.groupBox2.Controls.Add(this.button_new);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.heji);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(12, 179);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(826, 251);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "退还明细";
            // 
            // MingXi
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            this.MingXi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.MingXi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MingXi.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MingXi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.MingXi.Location = new System.Drawing.Point(11, 20);
            this.MingXi.Name = "MingXi";
            this.MingXi.RowHeadersWidth = 30;
            this.MingXi.RowTemplate.Height = 23;
            this.MingXi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MingXi.Size = new System.Drawing.Size(810, 184);
            this.MingXi.TabIndex = 0;
            this.MingXi.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.MingXi_RowPostPaint);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(91, 214);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(63, 23);
            this.button_delete.TabIndex = 5;
            this.button_delete.Text = "删除";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_new
            // 
            this.button_new.Location = new System.Drawing.Point(11, 213);
            this.button_new.Name = "button_new";
            this.button_new.Size = new System.Drawing.Size(62, 23);
            this.button_new.TabIndex = 5;
            this.button_new.Text = "新增";
            this.button_new.UseVisualStyleBackColor = true;
            this.button_new.Click += new System.EventHandler(this.button2_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(802, 219);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "把";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(677, 219);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "本次共退还刀具";
            // 
            // heji
            // 
            this.heji.Enabled = false;
            this.heji.Location = new System.Drawing.Point(767, 215);
            this.heji.Name = "heji";
            this.heji.Size = new System.Drawing.Size(29, 21);
            this.heji.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(606, 219);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "合    计：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.JBRQ);
            this.groupBox3.Controls.Add(this.JBR);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(12, 436);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(826, 62);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作信息";
            // 
            // JBR
            // 
            this.JBR.FormattingEnabled = true;
            this.JBR.Items.AddRange(new object[] {
            "赵经手",
            "钱刀管",
            "孙大帐"});
            this.JBR.Location = new System.Drawing.Point(104, 28);
            this.JBR.Name = "JBR";
            this.JBR.Size = new System.Drawing.Size(121, 20);
            this.JBR.TabIndex = 2;
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(519, 516);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 3;
            this.button_cancel.Text = "取消单据";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_print
            // 
            this.button_print.Location = new System.Drawing.Point(330, 516);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(75, 23);
            this.button_print.TabIndex = 3;
            this.button_print.Text = "打印单据";
            this.button_print.UseVisualStyleBackColor = true;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(235, 516);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 5;
            this.button_save.Text = "保存单据";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_history
            // 
            this.button_history.Location = new System.Drawing.Point(425, 516);
            this.button_history.Name = "button_history";
            this.button_history.Size = new System.Drawing.Size(75, 23);
            this.button_history.TabIndex = 3;
            this.button_history.Text = "退还历史";
            this.button_history.UseVisualStyleBackColor = true;
            this.button_history.Click += new System.EventHandler(this.button_history_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(641, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "车间：";
            // 
            // CJ
            // 
            this.CJ.FormattingEnabled = true;
            this.CJ.Items.AddRange(new object[] {
            "机一车间"});
            this.CJ.Location = new System.Drawing.Point(681, 33);
            this.CJ.Name = "CJ";
            this.CJ.Size = new System.Drawing.Size(121, 20);
            this.CJ.TabIndex = 2;
            this.CJ.Text = "机一车间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(641, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "单号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(558, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "经办日期：";
            // 
            // JBRQ
            // 
            this.JBRQ.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.JBRQ.Location = new System.Drawing.Point(624, 25);
            this.JBRQ.Name = "JBRQ";
            this.JBRQ.Size = new System.Drawing.Size(166, 21);
            this.JBRQ.TabIndex = 4;
            this.JBRQ.Value = new System.DateTime(2017, 5, 2, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "退还原因或备注：";
            // 
            // THYY
            // 
            this.THYY.Location = new System.Drawing.Point(136, 59);
            this.THYY.Name = "THYY";
            this.THYY.Size = new System.Drawing.Size(352, 21);
            this.THYY.TabIndex = 1;
            // 
            // mx_djlx
            // 
            this.mx_djlx.DataPropertyName = "djlx";
            this.mx_djlx.FillWeight = 136.9102F;
            this.mx_djlx.HeaderText = "刀具类型";
            this.mx_djlx.Name = "mx_djlx";
            this.mx_djlx.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // mx_djgg
            // 
            this.mx_djgg.DataPropertyName = "djgg";
            this.mx_djgg.FillWeight = 137.475F;
            this.mx_djgg.HeaderText = "刀具规格";
            this.mx_djgg.Name = "mx_djgg";
            this.mx_djgg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // mx_djcd
            // 
            this.mx_djcd.DataPropertyName = "djcd";
            this.mx_djcd.FillWeight = 82.66118F;
            this.mx_djcd.HeaderText = "刀具长度";
            this.mx_djcd.Name = "mx_djcd";
            // 
            // mx_djid
            // 
            this.mx_djid.DataPropertyName = "djid";
            this.mx_djid.FillWeight = 110.0969F;
            this.mx_djid.HeaderText = "刀具ID";
            this.mx_djid.Name = "mx_djid";
            // 
            // mx_djzt
            // 
            this.mx_djzt.DataPropertyName = "djzt";
            this.mx_djzt.FillWeight = 82.3261F;
            this.mx_djzt.HeaderText = "刀具状态";
            this.mx_djzt.Name = "mx_djzt";
            // 
            // mx_sl
            // 
            this.mx_sl.DataPropertyName = "sl";
            this.mx_sl.FillWeight = 48.55925F;
            this.mx_sl.HeaderText = "数量";
            this.mx_sl.Name = "mx_sl";
            // 
            // mx_jcbm
            // 
            this.mx_jcbm.DataPropertyName = "jcbm";
            this.mx_jcbm.FillWeight = 108.7819F;
            this.mx_jcbm.HeaderText = "机床编码";
            this.mx_jcbm.Name = "mx_jcbm";
            this.mx_jcbm.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // mx_dth
            // 
            this.mx_dth.DataPropertyName = "dth";
            this.mx_dth.FillWeight = 65.58608F;
            this.mx_dth.HeaderText = "刀套号";
            this.mx_dth.Name = "mx_dth";
            this.mx_dth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // mx_djgbm
            // 
            this.mx_djgbm.DataPropertyName = "djgbm";
            this.mx_djgbm.FillWeight = 102.3477F;
            this.mx_djgbm.HeaderText = "刀具柜编码";
            this.mx_djgbm.Name = "mx_djgbm";
            // 
            // mx_cfwz
            // 
            this.mx_cfwz.DataPropertyName = "cfwz";
            this.mx_cfwz.FillWeight = 88.69971F;
            this.mx_cfwz.HeaderText = "存放位置";
            this.mx_cfwz.Name = "mx_cfwz";
            // 
            // mx_bz
            // 
            this.mx_bz.DataPropertyName = "bz";
            this.mx_bz.FillWeight = 115.4083F;
            this.mx_bz.HeaderText = "备注";
            this.mx_bz.Name = "mx_bz";
            // 
            // DJTH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(849, 554);
            this.Controls.Add(this.CJ);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.DH);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_history);
            this.Controls.Add(this.button_print);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Name = "DJTH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "刀具退还单";
            this.Load += new System.EventHandler(this.DJTH_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MingXi)).EndInit();
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
        private System.Windows.Forms.DataGridView MingXi;
        private System.Windows.Forms.TextBox DH;
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn djID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox heji;
        private System.Windows.Forms.Label label14;
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
    }
}