﻿namespace kucunTest.DaoJu
{
    partial class xzlymx
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
            this.label7 = new System.Windows.Forms.Label();
            this.bz = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.djcd = new System.Windows.Forms.ComboBox();
            this.djgg = new System.Windows.Forms.ComboBox();
            this.djid = new System.Windows.Forms.ComboBox();
            this.djlx = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dth = new System.Windows.Forms.ComboBox();
            this.jcbm = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_xiugai = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(129, 321);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 32);
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
            this.label2.Location = new System.Drawing.Point(289, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "刀 具 ID：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 33);
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
            this.label5.Location = new System.Drawing.Point(292, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "刀 套 号：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "特殊要求及备注：";
            // 
            // bz
            // 
            this.bz.Location = new System.Drawing.Point(162, 75);
            this.bz.Name = "bz";
            this.bz.Size = new System.Drawing.Size(375, 29);
            this.bz.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.djcd);
            this.groupBox1.Controls.Add(this.djgg);
            this.groupBox1.Controls.Add(this.djid);
            this.groupBox1.Controls.Add(this.djlx);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 115);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "刀具信息";
            // 
            // djcd
            // 
            this.djcd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.djcd.FormattingEnabled = true;
            this.djcd.Items.AddRange(new object[] {
            "50",
            "100",
            "150",
            "200"});
            this.djcd.Location = new System.Drawing.Point(111, 71);
            this.djcd.Name = "djcd";
            this.djcd.Size = new System.Drawing.Size(147, 29);
            this.djcd.TabIndex = 3;
            this.djcd.SelectedIndexChanged += new System.EventHandler(this.djgg_SelectedIndexChanged);
            // 
            // djgg
            // 
            this.djgg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.djgg.FormattingEnabled = true;
            this.djgg.Location = new System.Drawing.Point(382, 30);
            this.djgg.Name = "djgg";
            this.djgg.Size = new System.Drawing.Size(155, 29);
            this.djgg.TabIndex = 3;
            this.djgg.SelectedIndexChanged += new System.EventHandler(this.djgg_SelectedIndexChanged);
            // 
            // djid
            // 
            this.djid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.djid.FormattingEnabled = true;
            this.djid.Location = new System.Drawing.Point(382, 71);
            this.djid.Name = "djid";
            this.djid.Size = new System.Drawing.Size(155, 29);
            this.djid.TabIndex = 3;
            // 
            // djlx
            // 
            this.djlx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.djlx.FormattingEnabled = true;
            this.djlx.Location = new System.Drawing.Point(111, 30);
            this.djlx.Name = "djlx";
            this.djlx.Size = new System.Drawing.Size(147, 29);
            this.djlx.TabIndex = 3;
            this.djlx.SelectedIndexChanged += new System.EventHandler(this.djxh_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 21);
            this.label8.TabIndex = 2;
            this.label8.Text = "刀具长度：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dth);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.jcbm);
            this.groupBox2.Controls.Add(this.bz);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(12, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(567, 124);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "位置信息";
            // 
            // dth
            // 
            this.dth.AutoCompleteCustomSource.AddRange(new string[] {
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
            this.dth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dth.FormattingEnabled = true;
            this.dth.Items.AddRange(new object[] {
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
            this.dth.Location = new System.Drawing.Point(382, 31);
            this.dth.Name = "dth";
            this.dth.Size = new System.Drawing.Size(155, 29);
            this.dth.TabIndex = 3;
            // 
            // jcbm
            // 
            this.jcbm.AutoCompleteCustomSource.AddRange(new string[] {
            "FMS-1#机",
            "FMS-2#机",
            "FMS-3#机",
            "南车床线",
            "北车床线",
            "OP20T01",
            "OP20T40",
            "OP20T238"});
            this.jcbm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jcbm.FormattingEnabled = true;
            this.jcbm.Items.AddRange(new object[] {
            "FMS-1#机",
            "FMS-2#机",
            "FMS-3#机",
            "南车床线",
            "北车床线",
            "OP20T01",
            "OP20T40",
            "OP20T238"});
            this.jcbm.Location = new System.Drawing.Point(111, 31);
            this.jcbm.Name = "jcbm";
            this.jcbm.Size = new System.Drawing.Size(147, 29);
            this.jcbm.TabIndex = 3;
            this.jcbm.SelectedIndexChanged += new System.EventHandler(this.jcbm_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(341, 320);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 32);
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
            this.label6.Size = new System.Drawing.Size(591, 49);
            this.label6.TabIndex = 6;
            this.label6.Text = "添加领用刀具";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_xiugai
            // 
            this.btn_xiugai.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_xiugai.Location = new System.Drawing.Point(234, 319);
            this.btn_xiugai.Name = "btn_xiugai";
            this.btn_xiugai.Size = new System.Drawing.Size(88, 33);
            this.btn_xiugai.TabIndex = 7;
            this.btn_xiugai.Text = "修改";
            this.btn_xiugai.UseVisualStyleBackColor = true;
            this.btn_xiugai.Visible = false;
            this.btn_xiugai.Click += new System.EventHandler(this.btn_xiugai_Click);
            // 
            // xzlymx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 364);
            this.Controls.Add(this.btn_xiugai);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "xzlymx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加领用刀具";
            this.Load += new System.EventHandler(this.xzccmx_Load);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox bz;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox djgg;
        private System.Windows.Forms.ComboBox djid;
        private System.Windows.Forms.ComboBox djlx;
        private System.Windows.Forms.ComboBox dth;
        private System.Windows.Forms.ComboBox jcbm;
        private System.Windows.Forms.ComboBox djcd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_xiugai;
    }
}