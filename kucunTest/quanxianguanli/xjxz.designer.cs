namespace kucunTest.quanxianguanli
{
    partial class xjxz
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
            this.xzbeizhu = new System.Windows.Forms.TextBox();
            this.labelbeizhu = new System.Windows.Forms.Label();
            this.btn_qxxj = new System.Windows.Forms.Button();
            this.btn_xjxz = new System.Windows.Forms.Button();
            this.xzxx = new System.Windows.Forms.TextBox();
            this.xzm = new System.Windows.Forms.TextBox();
            this.labelxzxx = new System.Windows.Forms.Label();
            this.labelxzm = new System.Windows.Forms.Label();
            this.labelxz = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // xzbeizhu
            // 
            this.xzbeizhu.Location = new System.Drawing.Point(138, 172);
            this.xzbeizhu.Multiline = true;
            this.xzbeizhu.Name = "xzbeizhu";
            this.xzbeizhu.Size = new System.Drawing.Size(141, 49);
            this.xzbeizhu.TabIndex = 29;
            // 
            // labelbeizhu
            // 
            this.labelbeizhu.AutoSize = true;
            this.labelbeizhu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelbeizhu.Location = new System.Drawing.Point(65, 186);
            this.labelbeizhu.Name = "labelbeizhu";
            this.labelbeizhu.Size = new System.Drawing.Size(73, 21);
            this.labelbeizhu.TabIndex = 28;
            this.labelbeizhu.Text = "备   注：";
            // 
            // btn_qxxj
            // 
            this.btn_qxxj.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_qxxj.Location = new System.Drawing.Point(188, 259);
            this.btn_qxxj.Name = "btn_qxxj";
            this.btn_qxxj.Size = new System.Drawing.Size(84, 35);
            this.btn_qxxj.TabIndex = 27;
            this.btn_qxxj.Text = "取消新建";
            this.btn_qxxj.UseVisualStyleBackColor = true;
            this.btn_qxxj.Click += new System.EventHandler(this.btn_qxxj_Click);
            // 
            // btn_xjxz
            // 
            this.btn_xjxz.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_xjxz.Location = new System.Drawing.Point(69, 259);
            this.btn_xjxz.Name = "btn_xjxz";
            this.btn_xjxz.Size = new System.Drawing.Size(82, 35);
            this.btn_xjxz.TabIndex = 26;
            this.btn_xjxz.Text = "确认新建";
            this.btn_xjxz.UseVisualStyleBackColor = true;
            this.btn_xjxz.Click += new System.EventHandler(this.btn_xjxz_Click);
            // 
            // xzxx
            // 
            this.xzxx.Location = new System.Drawing.Point(138, 113);
            this.xzxx.Multiline = true;
            this.xzxx.Name = "xzxx";
            this.xzxx.Size = new System.Drawing.Size(141, 43);
            this.xzxx.TabIndex = 22;
            // 
            // xzm
            // 
            this.xzm.Location = new System.Drawing.Point(138, 71);
            this.xzm.MaxLength = 20;
            this.xzm.Name = "xzm";
            this.xzm.Size = new System.Drawing.Size(141, 21);
            this.xzm.TabIndex = 21;
            // 
            // labelxzxx
            // 
            this.labelxzxx.AutoSize = true;
            this.labelxzxx.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.labelxzxx.Location = new System.Drawing.Point(48, 123);
            this.labelxzxx.Name = "labelxzxx";
            this.labelxzxx.Size = new System.Drawing.Size(90, 21);
            this.labelxzxx.TabIndex = 17;
            this.labelxzxx.Text = "小组信息：";
            // 
            // labelxzm
            // 
            this.labelxzm.AutoSize = true;
            this.labelxzm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelxzm.Location = new System.Drawing.Point(64, 71);
            this.labelxzm.Name = "labelxzm";
            this.labelxzm.Size = new System.Drawing.Size(74, 21);
            this.labelxzm.TabIndex = 16;
            this.labelxzm.Text = "小组名：";
            // 
            // labelxz
            // 
            this.labelxz.AutoSize = true;
            this.labelxz.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelxz.Location = new System.Drawing.Point(116, 9);
            this.labelxz.Name = "labelxz";
            this.labelxz.Size = new System.Drawing.Size(110, 31);
            this.labelxz.TabIndex = 15;
            this.labelxz.Text = "新建小组";
            // 
            // xjxz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 325);
            this.Controls.Add(this.xzbeizhu);
            this.Controls.Add(this.labelbeizhu);
            this.Controls.Add(this.btn_qxxj);
            this.Controls.Add(this.btn_xjxz);
            this.Controls.Add(this.xzxx);
            this.Controls.Add(this.xzm);
            this.Controls.Add(this.labelxzxx);
            this.Controls.Add(this.labelxzm);
            this.Controls.Add(this.labelxz);
            this.Name = "xjxz";
            this.Text = "新建小组";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox xzbeizhu;
        private System.Windows.Forms.Label labelbeizhu;
        private System.Windows.Forms.Button btn_qxxj;
        private System.Windows.Forms.Button btn_xjxz;
        private System.Windows.Forms.TextBox xzxx;
        private System.Windows.Forms.TextBox xzm;
        private System.Windows.Forms.Label labelxzxx;
        private System.Windows.Forms.Label labelxzm;
        private System.Windows.Forms.Label labelxz;
    }
}