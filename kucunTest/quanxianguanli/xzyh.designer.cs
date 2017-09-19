namespace kucunTest.quanxianguanli
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
            this.pwd = new System.Windows.Forms.TextBox();
            this.juese = new System.Windows.Forms.ComboBox();
            this.bumen = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.beizhu = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(134, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "添加用户";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(81, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(82, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "姓   名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label4.Location = new System.Drawing.Point(81, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "密   码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label5.Location = new System.Drawing.Point(81, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "角   色：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label6.Location = new System.Drawing.Point(81, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "部   门：";
            // 
            // yhm
            // 
            this.yhm.Location = new System.Drawing.Point(155, 66);
            this.yhm.MaxLength = 20;
            this.yhm.Name = "yhm";
            this.yhm.Size = new System.Drawing.Size(121, 21);
            this.yhm.TabIndex = 6;
            // 
            // xingming
            // 
            this.xingming.Location = new System.Drawing.Point(156, 100);
            this.xingming.Name = "xingming";
            this.xingming.Size = new System.Drawing.Size(121, 21);
            this.xingming.TabIndex = 7;
            // 
            // pwd
            // 
            this.pwd.Location = new System.Drawing.Point(155, 138);
            this.pwd.MaxLength = 10;
            this.pwd.Name = "pwd";
            this.pwd.Size = new System.Drawing.Size(121, 21);
            this.pwd.TabIndex = 8;
            this.pwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pwd_KeyPress);
            // 
            // juese
            // 
            this.juese.FormattingEnabled = true;
            this.juese.Items.AddRange(new object[] {
            "管理员",
            "工人"});
            this.juese.Location = new System.Drawing.Point(155, 177);
            this.juese.Name = "juese";
            this.juese.Size = new System.Drawing.Size(121, 20);
            this.juese.TabIndex = 9;
            // 
            // bumen
            // 
            this.bumen.FormattingEnabled = true;
            this.bumen.Items.AddRange(new object[] {
            "刀管中心",
            "工艺部"});
            this.bumen.Location = new System.Drawing.Point(155, 219);
            this.bumen.Name = "bumen";
            this.bumen.Size = new System.Drawing.Size(121, 20);
            this.bumen.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(72, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "确认添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(220, 336);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 35);
            this.button2.TabIndex = 12;
            this.button2.Text = "取消添加";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(82, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "备   注：";
            // 
            // beizhu
            // 
            this.beizhu.Location = new System.Drawing.Point(156, 258);
            this.beizhu.Multiline = true;
            this.beizhu.Name = "beizhu";
            this.beizhu.Size = new System.Drawing.Size(120, 49);
            this.beizhu.TabIndex = 14;
            // 
            // xzyh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 394);
            this.Controls.Add(this.beizhu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bumen);
            this.Controls.Add(this.juese);
            this.Controls.Add(this.pwd);
            this.Controls.Add(this.xingming);
            this.Controls.Add(this.yhm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "xzyh";
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
        private System.Windows.Forms.TextBox pwd;
        private System.Windows.Forms.ComboBox juese;
        private System.Windows.Forms.ComboBox bumen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox beizhu;
    }
}