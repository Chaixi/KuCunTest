﻿namespace kucunTest.quanxianguanli
{
    partial class xzyh
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.yhm = new System.Windows.Forms.TextBox();
            this.xingming = new System.Windows.Forms.TextBox();
            this.pwd1 = new System.Windows.Forms.TextBox();
            this.ssxz = new System.Windows.Forms.ComboBox();
            this.bumen = new System.Windows.Forms.ComboBox();
            this.btn_qr = new System.Windows.Forms.Button();
            this.btn_qx = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.beizhu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pwd2 = new System.Windows.Forms.TextBox();
            this.label_yhmcz = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "添加用户";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(31, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(32, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "姓   名";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label4.Location = new System.Drawing.Point(32, 151);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "密   码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label5.Location = new System.Drawing.Point(15, 229);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "所属小组";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label6.Location = new System.Drawing.Point(15, 268);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "所属部门";
            // 
            // yhm
            // 
            this.yhm.Location = new System.Drawing.Point(99, 70);
            this.yhm.Margin = new System.Windows.Forms.Padding(5);
            this.yhm.MaxLength = 20;
            this.yhm.Name = "yhm";
            this.yhm.Size = new System.Drawing.Size(226, 29);
            this.yhm.TabIndex = 0;
            this.yhm.Leave += new System.EventHandler(this.yhm_Leave);
            // 
            // xingming
            // 
            this.xingming.Location = new System.Drawing.Point(99, 109);
            this.xingming.Margin = new System.Windows.Forms.Padding(5);
            this.xingming.Name = "xingming";
            this.xingming.Size = new System.Drawing.Size(226, 29);
            this.xingming.TabIndex = 1;
            // 
            // pwd1
            // 
            this.pwd1.Location = new System.Drawing.Point(99, 148);
            this.pwd1.Margin = new System.Windows.Forms.Padding(5);
            this.pwd1.MaxLength = 10;
            this.pwd1.Name = "pwd1";
            this.pwd1.Size = new System.Drawing.Size(226, 29);
            this.pwd1.TabIndex = 2;
            this.pwd1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pwd_KeyPress);
            // 
            // ssxz
            // 
            this.ssxz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ssxz.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ssxz.FormattingEnabled = true;
            this.ssxz.Location = new System.Drawing.Point(99, 226);
            this.ssxz.Margin = new System.Windows.Forms.Padding(5);
            this.ssxz.Name = "ssxz";
            this.ssxz.Size = new System.Drawing.Size(226, 29);
            this.ssxz.TabIndex = 4;
            // 
            // bumen
            // 
            this.bumen.FormattingEnabled = true;
            this.bumen.Items.AddRange(new object[] {
            "刀管中心",
            "工艺部"});
            this.bumen.Location = new System.Drawing.Point(99, 265);
            this.bumen.Margin = new System.Windows.Forms.Padding(5);
            this.bumen.Name = "bumen";
            this.bumen.Size = new System.Drawing.Size(226, 29);
            this.bumen.TabIndex = 5;
            // 
            // btn_qr
            // 
            this.btn_qr.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_qr.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_qr.Location = new System.Drawing.Point(50, 423);
            this.btn_qr.Margin = new System.Windows.Forms.Padding(5);
            this.btn_qr.Name = "btn_qr";
            this.btn_qr.Size = new System.Drawing.Size(108, 42);
            this.btn_qr.TabIndex = 7;
            this.btn_qr.Text = "确认添加";
            this.btn_qr.UseVisualStyleBackColor = true;
            this.btn_qr.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_qx
            // 
            this.btn_qx.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_qx.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_qx.Location = new System.Drawing.Point(184, 423);
            this.btn_qx.Margin = new System.Windows.Forms.Padding(5);
            this.btn_qx.Name = "btn_qx";
            this.btn_qx.Size = new System.Drawing.Size(108, 42);
            this.btn_qx.TabIndex = 8;
            this.btn_qx.Text = "取消添加";
            this.btn_qx.UseVisualStyleBackColor = true;
            this.btn_qx.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(15, 307);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "用户备注";
            // 
            // beizhu
            // 
            this.beizhu.Location = new System.Drawing.Point(99, 304);
            this.beizhu.Margin = new System.Windows.Forms.Padding(5);
            this.beizhu.Multiline = true;
            this.beizhu.Name = "beizhu";
            this.beizhu.Size = new System.Drawing.Size(226, 96);
            this.beizhu.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label8.Location = new System.Drawing.Point(15, 190);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 21);
            this.label8.TabIndex = 3;
            this.label8.Text = "确认密码";
            // 
            // pwd2
            // 
            this.pwd2.Location = new System.Drawing.Point(99, 187);
            this.pwd2.Margin = new System.Windows.Forms.Padding(5);
            this.pwd2.MaxLength = 10;
            this.pwd2.Name = "pwd2";
            this.pwd2.Size = new System.Drawing.Size(226, 29);
            this.pwd2.TabIndex = 3;
            this.pwd2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pwd_KeyPress);
            // 
            // label_yhmcz
            // 
            this.label_yhmcz.AutoSize = true;
            this.label_yhmcz.ForeColor = System.Drawing.Color.Red;
            this.label_yhmcz.Location = new System.Drawing.Point(327, 73);
            this.label_yhmcz.Name = "label_yhmcz";
            this.label_yhmcz.Size = new System.Drawing.Size(90, 21);
            this.label_yhmcz.TabIndex = 15;
            this.label_yhmcz.Text = "（已存在）";
            this.label_yhmcz.Visible = false;
            // 
            // xzyh
            // 
            this.AcceptButton = this.btn_qr;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btn_qx;
            this.ClientSize = new System.Drawing.Size(417, 483);
            this.Controls.Add(this.beizhu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_qx);
            this.Controls.Add(this.btn_qr);
            this.Controls.Add(this.bumen);
            this.Controls.Add(this.ssxz);
            this.Controls.Add(this.pwd2);
            this.Controls.Add(this.pwd1);
            this.Controls.Add(this.xingming);
            this.Controls.Add(this.yhm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_yhmcz);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "xzyh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加用户";
            this.Load += new System.EventHandler(this.xzyh_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox yhm;
        private System.Windows.Forms.TextBox xingming;
        private System.Windows.Forms.TextBox pwd1;
        private System.Windows.Forms.ComboBox ssxz;
        private System.Windows.Forms.ComboBox bumen;
        private System.Windows.Forms.Button btn_qr;
        private System.Windows.Forms.Button btn_qx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox beizhu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox pwd2;
        private System.Windows.Forms.Label label_yhmcz;
    }
}