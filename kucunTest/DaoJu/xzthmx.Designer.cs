﻿namespace kucunTest.DaoJu
{
    partial class xzthmx
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.djzt = new System.Windows.Forms.ComboBox();
            this.djgg = new System.Windows.Forms.ComboBox();
            this.djid = new System.Windows.Forms.ComboBox();
            this.djcd = new System.Windows.Forms.ComboBox();
            this.djlx = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cfwz = new System.Windows.Forms.ComboBox();
            this.dth = new System.Windows.Forms.TextBox();
            this.djgbm = new System.Windows.Forms.ComboBox();
            this.bz = new System.Windows.Forms.TextBox();
            this.jcbm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(207, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "刀具类型：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "刀具长度：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "刀具规格：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "机床编码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "刀 套 号：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.djzt);
            this.groupBox1.Controls.Add(this.djgg);
            this.groupBox1.Controls.Add(this.djid);
            this.groupBox1.Controls.Add(this.djcd);
            this.groupBox1.Controls.Add(this.djlx);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 162);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "刀具信息";
            // 
            // djzt
            // 
            this.djzt.FormattingEnabled = true;
            this.djzt.Items.AddRange(new object[] {
            "旧",
            "新"});
            this.djzt.Location = new System.Drawing.Point(394, 118);
            this.djzt.Name = "djzt";
            this.djzt.Size = new System.Drawing.Size(161, 29);
            this.djzt.TabIndex = 3;
            // 
            // djgg
            // 
            this.djgg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.djgg.FormattingEnabled = true;
            this.djgg.Location = new System.Drawing.Point(104, 75);
            this.djgg.Name = "djgg";
            this.djgg.Size = new System.Drawing.Size(170, 29);
            this.djgg.TabIndex = 3;
            this.djgg.SelectedIndexChanged += new System.EventHandler(this.djgg_SelectedIndexChanged);
            // 
            // djid
            // 
            this.djid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.djid.FormattingEnabled = true;
            this.djid.Location = new System.Drawing.Point(104, 118);
            this.djid.Name = "djid";
            this.djid.Size = new System.Drawing.Size(170, 29);
            this.djid.TabIndex = 3;
            this.djid.SelectedIndexChanged += new System.EventHandler(this.djid_SelectedIndexChanged);
            // 
            // djcd
            // 
            this.djcd.FormattingEnabled = true;
            this.djcd.Items.AddRange(new object[] {
            "50",
            "100",
            "150",
            "200"});
            this.djcd.Location = new System.Drawing.Point(394, 75);
            this.djcd.Name = "djcd";
            this.djcd.Size = new System.Drawing.Size(161, 29);
            this.djcd.TabIndex = 3;
            // 
            // djlx
            // 
            this.djlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.djlx.FormattingEnabled = true;
            this.djlx.Location = new System.Drawing.Point(104, 30);
            this.djlx.Name = "djlx";
            this.djlx.Size = new System.Drawing.Size(451, 29);
            this.djlx.TabIndex = 3;
            this.djlx.SelectedIndexChanged += new System.EventHandler(this.djlx_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(308, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 21);
            this.label8.TabIndex = 2;
            this.label8.Text = "刀具状态：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 21);
            this.label12.TabIndex = 2;
            this.label12.Text = "刀 具 ID：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cfwz);
            this.groupBox2.Controls.Add(this.dth);
            this.groupBox2.Controls.Add(this.djgbm);
            this.groupBox2.Controls.Add(this.bz);
            this.groupBox2.Controls.Add(this.jcbm);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 220);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(561, 163);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "位置信息";
            // 
            // cfwz
            // 
            this.cfwz.AutoCompleteCustomSource.AddRange(new string[] {
            "T1",
            "T2",
            "T3",
            "T4",
            "T5",
            "T6",
            "T7",
            "T8",
            "T9",
            "T10",
            "T11",
            "T12",
            "T13",
            "T14",
            "T15",
            "T16",
            "T17",
            "T18",
            "T19",
            "T20"});
            this.cfwz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cfwz.FormattingEnabled = true;
            this.cfwz.Location = new System.Drawing.Point(394, 71);
            this.cfwz.Name = "cfwz";
            this.cfwz.Size = new System.Drawing.Size(161, 29);
            this.cfwz.TabIndex = 3;
            // 
            // dth
            // 
            this.dth.Location = new System.Drawing.Point(394, 31);
            this.dth.Name = "dth";
            this.dth.ReadOnly = true;
            this.dth.Size = new System.Drawing.Size(161, 29);
            this.dth.TabIndex = 5;
            // 
            // djgbm
            // 
            this.djgbm.AutoCompleteCustomSource.AddRange(new string[] {
            "FMS-1#机",
            "FMS-2#机",
            "FMS-3#机",
            "南车床线",
            "北车床线",
            "OP20T01",
            "OP20T40",
            "OP20T238"});
            this.djgbm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.djgbm.FormattingEnabled = true;
            this.djgbm.Location = new System.Drawing.Point(104, 71);
            this.djgbm.Name = "djgbm";
            this.djgbm.Size = new System.Drawing.Size(170, 29);
            this.djgbm.TabIndex = 3;
            this.djgbm.SelectedIndexChanged += new System.EventHandler(this.djgbm_SelectedIndexChanged);
            // 
            // bz
            // 
            this.bz.Location = new System.Drawing.Point(102, 118);
            this.bz.Name = "bz";
            this.bz.Size = new System.Drawing.Size(453, 29);
            this.bz.TabIndex = 3;
            // 
            // jcbm
            // 
            this.jcbm.Location = new System.Drawing.Point(104, 31);
            this.jcbm.Name = "jcbm";
            this.jcbm.ReadOnly = true;
            this.jcbm.Size = new System.Drawing.Size(170, 29);
            this.jcbm.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 121);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 21);
            this.label10.TabIndex = 2;
            this.label10.Text = "备    注：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 21);
            this.label11.TabIndex = 2;
            this.label11.Text = "刀柜编码：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(308, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 21);
            this.label9.TabIndex = 2;
            this.label9.Text = "存放位置：";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(324, 402);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("宋体", 20F);
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(585, 58);
            this.label6.TabIndex = 6;
            this.label6.Text = "添加退还刀具";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xzthmx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Name = "xzthmx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加退还刀具";
            this.Load += new System.EventHandler(this.xzthmx_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox djgg;
        private System.Windows.Forms.ComboBox djcd;
        private System.Windows.Forms.ComboBox djlx;
        private System.Windows.Forms.TextBox dth;
        private System.Windows.Forms.TextBox jcbm;
        private System.Windows.Forms.ComboBox djzt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cfwz;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox djgbm;
        private System.Windows.Forms.TextBox bz;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox djid;
        private System.Windows.Forms.Label label12;
    }
}