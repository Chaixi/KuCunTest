namespace kucunTest.FastReport
{
    partial class FastReport测试
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.grid1 = new FlexCell.Grid();
            this.label1 = new System.Windows.Forms.Label();
            this.danhao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.beizhu = new System.Windows.Forms.TextBox();
            this.LYRQ = new System.Windows.Forms.DateTimePicker();
            this.LYSB = new System.Windows.Forms.ComboBox();
            this.LYBZ = new System.Windows.Forms.ComboBox();
            this.LYR = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ZJGX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SPR = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.JBR = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 457);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "加载数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(440, 457);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "显示报表";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // grid1
            // 
            this.grid1.CheckedImage = null;
            this.grid1.Cols = 9;
            this.grid1.DefaultFont = new System.Drawing.Font("宋体", 9F);
            this.grid1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.grid1.Location = new System.Drawing.Point(93, 165);
            this.grid1.Name = "grid1";
            this.grid1.Size = new System.Drawing.Size(744, 273);
            this.grid1.TabIndex = 1;
            this.grid1.UncheckedImage = null;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(300, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "机一车间刀具领用明细";
            // 
            // danhao
            // 
            this.danhao.Location = new System.Drawing.Point(671, 22);
            this.danhao.Name = "danhao";
            this.danhao.Size = new System.Drawing.Size(121, 21);
            this.danhao.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(631, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "单号：";
            // 
            // beizhu
            // 
            this.beizhu.Location = new System.Drawing.Point(671, 99);
            this.beizhu.Multiline = true;
            this.beizhu.Name = "beizhu";
            this.beizhu.Size = new System.Drawing.Size(166, 53);
            this.beizhu.TabIndex = 20;
            // 
            // LYRQ
            // 
            this.LYRQ.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.LYRQ.Location = new System.Drawing.Point(671, 66);
            this.LYRQ.Name = "LYRQ";
            this.LYRQ.Size = new System.Drawing.Size(166, 21);
            this.LYRQ.TabIndex = 18;
            this.LYRQ.Value = new System.DateTime(2017, 5, 2, 0, 0, 0, 0);
            // 
            // LYSB
            // 
            this.LYSB.AutoCompleteCustomSource.AddRange(new string[] {
            "先锋一班",
            "胜利二班",
            "机动科"});
            this.LYSB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.LYSB.FormattingEnabled = true;
            this.LYSB.Items.AddRange(new object[] {
            "FMS-1#机",
            "FMS-2#机",
            "FMS-3#机",
            "南车床线",
            "北车床线",
            "OP20T01",
            "OP20T40",
            "OP20T238"});
            this.LYSB.Location = new System.Drawing.Point(147, 117);
            this.LYSB.Name = "LYSB";
            this.LYSB.Size = new System.Drawing.Size(121, 20);
            this.LYSB.TabIndex = 16;
            // 
            // LYBZ
            // 
            this.LYBZ.AutoCompleteCustomSource.AddRange(new string[] {
            "先锋一班",
            "胜利二班",
            "机动科"});
            this.LYBZ.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.LYBZ.FormattingEnabled = true;
            this.LYBZ.Items.AddRange(new object[] {
            "先锋一班",
            "胜利二班",
            "机动科"});
            this.LYBZ.Location = new System.Drawing.Point(147, 69);
            this.LYBZ.Name = "LYBZ";
            this.LYBZ.Size = new System.Drawing.Size(121, 20);
            this.LYBZ.TabIndex = 17;
            // 
            // LYR
            // 
            this.LYR.Location = new System.Drawing.Point(414, 69);
            this.LYR.Name = "LYR";
            this.LYR.Size = new System.Drawing.Size(121, 21);
            this.LYR.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(352, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 7;
            this.label12.Text = "领 用 人：";
            // 
            // ZJGX
            // 
            this.ZJGX.Location = new System.Drawing.Point(414, 117);
            this.ZJGX.Name = "ZJGX";
            this.ZJGX.Size = new System.Drawing.Size(121, 21);
            this.ZJGX.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "领用班组：";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(605, 120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 9;
            this.label13.Text = "领用备注：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(85, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "设    备：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(352, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "制件工序：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(605, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "领用日期：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SPR);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.JBR);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(87, 512);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(750, 62);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作信息";
            // 
            // SPR
            // 
            this.SPR.FormattingEnabled = true;
            this.SPR.Items.AddRange(new object[] {
            "赵经手",
            "钱刀管",
            "孙大帐"});
            this.SPR.Location = new System.Drawing.Point(100, 28);
            this.SPR.Name = "SPR";
            this.SPR.Size = new System.Drawing.Size(121, 20);
            this.SPR.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "审 批 人：";
            // 
            // JBR
            // 
            this.JBR.FormattingEnabled = true;
            this.JBR.Items.AddRange(new object[] {
            "赵经手",
            "钱刀管",
            "孙大帐"});
            this.JBR.Location = new System.Drawing.Point(507, 28);
            this.JBR.Name = "JBR";
            this.JBR.Size = new System.Drawing.Size(121, 20);
            this.JBR.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(441, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "经 办 人：";
            // 
            // FastReport测试
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 631);
            this.Controls.Add(this.danhao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.beizhu);
            this.Controls.Add(this.LYRQ);
            this.Controls.Add(this.LYSB);
            this.Controls.Add(this.LYBZ);
            this.Controls.Add(this.LYR);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ZJGX);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "FastReport测试";
            this.Text = "FastReport测试";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private FlexCell.Grid grid1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox danhao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox beizhu;
        private System.Windows.Forms.DateTimePicker LYRQ;
        private System.Windows.Forms.ComboBox LYSB;
        private System.Windows.Forms.ComboBox LYBZ;
        private System.Windows.Forms.TextBox LYR;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox ZJGX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox SPR;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox JBR;
        private System.Windows.Forms.Label label8;
        //private FastReport.Report report1;
    }
}