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
            this.cbx_gyk = new System.Windows.Forms.CheckBox();
            this.cbx_gx = new System.Windows.Forms.CheckBox();
            this.cbx_jgljh = new System.Windows.Forms.CheckBox();
            this.cbx_jgljlx = new System.Windows.Forms.CheckBox();
            this.cbx_jgljm = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.jgljlx = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.jgljm = new System.Windows.Forms.TextBox();
            this.jgljh = new System.Windows.Forms.TextBox();
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
            // cbx_gyk
            // 
            this.cbx_gyk.AutoSize = true;
            this.cbx_gyk.Checked = true;
            this.cbx_gyk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_gyk.Location = new System.Drawing.Point(11, 55);
            this.cbx_gyk.Name = "cbx_gyk";
            this.cbx_gyk.Size = new System.Drawing.Size(77, 25);
            this.cbx_gyk.TabIndex = 3;
            this.cbx_gyk.Text = "工艺卡";
            this.cbx_gyk.UseVisualStyleBackColor = true;
            // 
            // cbx_gx
            // 
            this.cbx_gx.AutoSize = true;
            this.cbx_gx.Checked = true;
            this.cbx_gx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_gx.Location = new System.Drawing.Point(23, 40);
            this.cbx_gx.Name = "cbx_gx";
            this.cbx_gx.Size = new System.Drawing.Size(61, 25);
            this.cbx_gx.TabIndex = 3;
            this.cbx_gx.Text = "工序";
            this.cbx_gx.UseVisualStyleBackColor = true;
            // 
            // cbx_jgljh
            // 
            this.cbx_jgljh.AutoSize = true;
            this.cbx_jgljh.Location = new System.Drawing.Point(23, 121);
            this.cbx_jgljh.Name = "cbx_jgljh";
            this.cbx_jgljh.Size = new System.Drawing.Size(109, 25);
            this.cbx_jgljh.TabIndex = 3;
            this.cbx_jgljh.Text = "加工零件号";
            this.cbx_jgljh.UseVisualStyleBackColor = true;
            // 
            // cbx_jgljlx
            // 
            this.cbx_jgljlx.AutoSize = true;
            this.cbx_jgljlx.Location = new System.Drawing.Point(11, 111);
            this.cbx_jgljlx.Name = "cbx_jgljlx";
            this.cbx_jgljlx.Size = new System.Drawing.Size(125, 25);
            this.cbx_jgljlx.TabIndex = 3;
            this.cbx_jgljlx.Text = "加工零件类型";
            this.cbx_jgljlx.UseVisualStyleBackColor = true;
            // 
            // cbx_jgljm
            // 
            this.cbx_jgljm.AutoSize = true;
            this.cbx_jgljm.Location = new System.Drawing.Point(23, 81);
            this.cbx_jgljm.Name = "cbx_jgljm";
            this.cbx_jgljm.Size = new System.Drawing.Size(109, 25);
            this.cbx_jgljm.TabIndex = 3;
            this.cbx_jgljm.Text = "加工零件名";
            this.cbx_jgljm.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.jgljlx);
            this.groupBox1.Controls.Add(this.cbx_jgljlx);
            this.groupBox1.Controls.Add(this.gyk);
            this.groupBox1.Controls.Add(this.cbx_gyk);
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 171);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工艺卡信息";
            // 
            // jgljlx
            // 
            this.jgljlx.Location = new System.Drawing.Point(137, 109);
            this.jgljlx.Name = "jgljlx";
            this.jgljlx.ReadOnly = true;
            this.jgljlx.Size = new System.Drawing.Size(193, 29);
            this.jgljlx.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.jgljm);
            this.groupBox2.Controls.Add(this.jgljh);
            this.groupBox2.Controls.Add(this.cbx_jgljh);
            this.groupBox2.Controls.Add(this.gx);
            this.groupBox2.Controls.Add(this.cbx_gx);
            this.groupBox2.Controls.Add(this.cbx_jgljm);
            this.groupBox2.Location = new System.Drawing.Point(367, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 171);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工序信息";
            // 
            // jgljm
            // 
            this.jgljm.Location = new System.Drawing.Point(135, 79);
            this.jgljm.Name = "jgljm";
            this.jgljm.ReadOnly = true;
            this.jgljm.Size = new System.Drawing.Size(193, 29);
            this.jgljm.TabIndex = 4;
            // 
            // jgljh
            // 
            this.jgljh.Location = new System.Drawing.Point(135, 119);
            this.jgljh.Name = "jgljh";
            this.jgljh.ReadOnly = true;
            this.jgljh.Size = new System.Drawing.Size(193, 29);
            this.jgljh.TabIndex = 4;
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
            this.Margin = new System.Windows.Forms.Padding(5);
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
        private System.Windows.Forms.CheckBox cbx_gyk;
        private System.Windows.Forms.CheckBox cbx_gx;
        private System.Windows.Forms.CheckBox cbx_jgljh;
        private System.Windows.Forms.CheckBox cbx_jgljlx;
        private System.Windows.Forms.CheckBox cbx_jgljm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox jgljlx;
        private System.Windows.Forms.TextBox jgljm;
        private System.Windows.Forms.TextBox jgljh;
    }
}