namespace kucunTest.gongyika
{
    partial class GongXuXuanZe
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
            this.gyk = new System.Windows.Forms.ComboBox();
            this.gx = new System.Windows.Forms.ComboBox();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.jgljlx = new System.Windows.Forms.TextBox();
            this.jgljh = new System.Windows.Forms.TextBox();
            this.jgljm = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gyk
            // 
            this.gyk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gyk.FormattingEnabled = true;
            this.gyk.Location = new System.Drawing.Point(137, 53);
            this.gyk.Name = "gyk";
            this.gyk.Size = new System.Drawing.Size(193, 29);
            this.gyk.TabIndex = 1;
            this.gyk.SelectedIndexChanged += new System.EventHandler(this.gyk_SelectedIndexChanged);
            // 
            // gx
            // 
            this.gx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gx.FormattingEnabled = true;
            this.gx.Location = new System.Drawing.Point(135, 38);
            this.gx.Name = "gx";
            this.gx.Size = new System.Drawing.Size(193, 29);
            this.gx.TabIndex = 1;
            this.gx.SelectedIndexChanged += new System.EventHandler(this.gx_SelectedIndexChanged);
            // 
            // btn_confirm
            // 
            this.btn_confirm.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_confirm.Location = new System.Drawing.Point(731, 52);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(75, 37);
            this.btn_confirm.TabIndex = 2;
            this.btn_confirm.Text = "确定";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(731, 123);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 37);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(11, 55);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(77, 25);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "工艺卡";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(23, 40);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(61, 25);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "工序";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(23, 121);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(109, 25);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Text = "加工零件号";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(11, 111);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(125, 25);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "加工零件类型";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(23, 81);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(109, 25);
            this.checkBox5.TabIndex = 3;
            this.checkBox5.Text = "加工零件名";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.jgljlx);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.gyk);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 171);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工艺卡信息";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.jgljm);
            this.groupBox2.Controls.Add(this.jgljh);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.gx);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Location = new System.Drawing.Point(367, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 171);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工序信息";
            // 
            // jgljlx
            // 
            this.jgljlx.Location = new System.Drawing.Point(137, 109);
            this.jgljlx.Name = "jgljlx";
            this.jgljlx.ReadOnly = true;
            this.jgljlx.Size = new System.Drawing.Size(193, 29);
            this.jgljlx.TabIndex = 4;
            // 
            // jgljh
            // 
            this.jgljh.Location = new System.Drawing.Point(135, 119);
            this.jgljh.Name = "jgljh";
            this.jgljh.ReadOnly = true;
            this.jgljh.Size = new System.Drawing.Size(193, 29);
            this.jgljh.TabIndex = 4;
            // 
            // jgljm
            // 
            this.jgljm.Location = new System.Drawing.Point(135, 79);
            this.jgljm.Name = "jgljm";
            this.jgljm.ReadOnly = true;
            this.jgljm.Size = new System.Drawing.Size(193, 29);
            this.jgljm.TabIndex = 4;
            // 
            // GongXuXuanZe
            // 
            this.AcceptButton = this.btn_confirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(826, 194);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_confirm);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GongXuXuanZe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择制件工序";
            this.Load += new System.EventHandler(this.GongXuXuanZe_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox gyk;
        private System.Windows.Forms.ComboBox gx;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox jgljlx;
        private System.Windows.Forms.TextBox jgljm;
        private System.Windows.Forms.TextBox jgljh;
    }
}