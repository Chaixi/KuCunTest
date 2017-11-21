namespace kucunTest.Jichuang
{
    partial class xinzengjichuang
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
            this.JCMC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DKRL = new System.Windows.Forms.TextBox();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_cansel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SSBZ = new System.Windows.Forms.ComboBox();
            this.SSSCX = new System.Windows.Forms.ComboBox();
            this.JCLX = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.JCTP = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ZCBH = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JCTP)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 22F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(627, 69);
            this.label1.TabIndex = 0;
            this.label1.Text = "新增机床";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 251);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "机床名称";
            // 
            // JCMC
            // 
            this.JCMC.Location = new System.Drawing.Point(118, 248);
            this.JCMC.Margin = new System.Windows.Forms.Padding(5);
            this.JCMC.Name = "JCMC";
            this.JCMC.Size = new System.Drawing.Size(228, 29);
            this.JCMC.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 163);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 1;
            this.label3.Text = "机床类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "所属生产线";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 295);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "刀库容量";
            // 
            // DKRL
            // 
            this.DKRL.Location = new System.Drawing.Point(118, 292);
            this.DKRL.Margin = new System.Windows.Forms.Padding(5);
            this.DKRL.Name = "DKRL";
            this.DKRL.Size = new System.Drawing.Size(228, 29);
            this.DKRL.TabIndex = 7;
            this.DKRL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DKRL_KeyPress);
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(207, 346);
            this.btn_confirm.Margin = new System.Windows.Forms.Padding(5);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(99, 34);
            this.btn_confirm.TabIndex = 8;
            this.btn_confirm.Text = "确定";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_cansel
            // 
            this.btn_cansel.Location = new System.Drawing.Point(337, 346);
            this.btn_cansel.Margin = new System.Windows.Forms.Padding(5);
            this.btn_cansel.Name = "btn_cansel";
            this.btn_cansel.Size = new System.Drawing.Size(99, 34);
            this.btn_cansel.TabIndex = 9;
            this.btn_cansel.Text = "取消";
            this.btn_cansel.UseVisualStyleBackColor = true;
            this.btn_cansel.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 72);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "所属班组";
            // 
            // SSBZ
            // 
            this.SSBZ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SSBZ.FormattingEnabled = true;
            this.SSBZ.Location = new System.Drawing.Point(118, 72);
            this.SSBZ.Name = "SSBZ";
            this.SSBZ.Size = new System.Drawing.Size(228, 29);
            this.SSBZ.TabIndex = 10;
            this.SSBZ.SelectedIndexChanged += new System.EventHandler(this.SSBZ_SelectedIndexChanged);
            // 
            // SSSCX
            // 
            this.SSSCX.FormattingEnabled = true;
            this.SSSCX.Location = new System.Drawing.Point(118, 117);
            this.SSSCX.Name = "SSSCX";
            this.SSSCX.Size = new System.Drawing.Size(228, 29);
            this.SSSCX.TabIndex = 10;
            // 
            // JCLX
            // 
            this.JCLX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.JCLX.FormattingEnabled = true;
            this.JCLX.Items.AddRange(new object[] {
            "10序组 机",
            "5序组 机",
            "大 宇",
            "惠乐喜乐",
            "鲁 南",
            "数控磨",
            "辛辛那提",
            "铱 镏",
            "东 BW",
            "西 BW",
            "东 德",
            "西 德",
            "东 曼",
            "西 曼",
            "东 森",
            "西 森",
            "汉 川",
            "东汉川",
            "西汉川",
            "东摇臂钻",
            "西摇臂钻",
            "南车",
            "北车",
            "桁 架",
            "南桁架",
            "北桁架",
            "南开创",
            "北开创",
            "南齐二",
            "北齐二",
            "森 一",
            "森 二",
            "森 三",
            "森 四",
            "森 五",
            "森 六"});
            this.JCLX.Location = new System.Drawing.Point(118, 163);
            this.JCLX.Name = "JCLX";
            this.JCLX.Size = new System.Drawing.Size(228, 29);
            this.JCLX.TabIndex = 10;
            this.JCLX.SelectedIndexChanged += new System.EventHandler(this.JCLX_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.JCTP);
            this.groupBox1.Location = new System.Drawing.Point(361, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 249);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "机床图片";
            // 
            // JCTP
            // 
            this.JCTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JCTP.Image = global::kucunTest.Properties.Resources.选择刀具柜图片提示;
            this.JCTP.Location = new System.Drawing.Point(3, 25);
            this.JCTP.Name = "JCTP";
            this.JCTP.Size = new System.Drawing.Size(246, 221);
            this.JCTP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.JCTP.TabIndex = 0;
            this.JCTP.TabStop = false;
            this.JCTP.Click += new System.EventHandler(this.JCTP_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "资产编号";
            // 
            // ZCBH
            // 
            this.ZCBH.Location = new System.Drawing.Point(118, 208);
            this.ZCBH.Name = "ZCBH";
            this.ZCBH.Size = new System.Drawing.Size(228, 29);
            this.ZCBH.TabIndex = 13;
            // 
            // xinzengjichuang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 398);
            this.Controls.Add(this.ZCBH);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.JCLX);
            this.Controls.Add(this.SSSCX);
            this.Controls.Add(this.SSBZ);
            this.Controls.Add(this.btn_cansel);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.DKRL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.JCMC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "xinzengjichuang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增机床";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.xinzengjichuang_FormClosed);
            this.Load += new System.EventHandler(this.xinzengjichuang_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.JCTP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox JCMC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DKRL;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Button btn_cansel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox SSBZ;
        private System.Windows.Forms.ComboBox SSSCX;
        private System.Windows.Forms.ComboBox JCLX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox JCTP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ZCBH;
    }
}