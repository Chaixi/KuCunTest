namespace kucunTest.Jichuang
{
    partial class jichuang
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.jcxx = new System.Windows.Forms.GroupBox();
            this.ssscx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.jclx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.jcmc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.jichuangtupian = new System.Windows.Forms.PictureBox();
            this.jcdth = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xzjc = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.jcxx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jichuangtupian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jcdth)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 513);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "机床名称";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 28);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(169, 479);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // jcxx
            // 
            this.jcxx.Controls.Add(this.groupBox3);
            this.jcxx.Controls.Add(this.ssscx);
            this.jcxx.Controls.Add(this.label4);
            this.jcxx.Controls.Add(this.jclx);
            this.jcxx.Controls.Add(this.label3);
            this.jcxx.Controls.Add(this.jcmc);
            this.jcxx.Controls.Add(this.label2);
            this.jcxx.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jcxx.Location = new System.Drawing.Point(199, 12);
            this.jcxx.Name = "jcxx";
            this.jcxx.Size = new System.Drawing.Size(781, 194);
            this.jcxx.TabIndex = 2;
            this.jcxx.TabStop = false;
            this.jcxx.Text = "机床信息";
            // 
            // ssscx
            // 
            this.ssscx.Location = new System.Drawing.Point(455, 134);
            this.ssscx.Name = "ssscx";
            this.ssscx.Size = new System.Drawing.Size(122, 29);
            this.ssscx.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(360, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "所属生产线";
            // 
            // jclx
            // 
            this.jclx.Location = new System.Drawing.Point(455, 93);
            this.jclx.Name = "jclx";
            this.jclx.Size = new System.Drawing.Size(122, 29);
            this.jclx.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "机床类型";
            // 
            // jcmc
            // 
            this.jcmc.Location = new System.Drawing.Point(455, 56);
            this.jcmc.Name = "jcmc";
            this.jcmc.Size = new System.Drawing.Size(122, 29);
            this.jcmc.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "机床名称";
            // 
            // jichuangtupian
            // 
            this.jichuangtupian.Location = new System.Drawing.Point(24, 26);
            this.jichuangtupian.Name = "jichuangtupian";
            this.jichuangtupian.Size = new System.Drawing.Size(161, 138);
            this.jichuangtupian.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.jichuangtupian.TabIndex = 2;
            this.jichuangtupian.TabStop = false;
            // 
            // jcdth
            // 
            this.jcdth.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.jcdth.BackgroundColor = System.Drawing.SystemColors.Control;
            this.jcdth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jcdth.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            this.jcdth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jcdth.Location = new System.Drawing.Point(3, 25);
            this.jcdth.Name = "jcdth";
            this.jcdth.ReadOnly = true;
            this.jcdth.RowTemplate.Height = 23;
            this.jcdth.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jcdth.Size = new System.Drawing.Size(775, 285);
            this.jcdth.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "daotaohao";
            this.Column1.HeaderText = "T编码";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "daojuleixing";
            this.Column2.HeaderText = "刀具类型";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "daojuguige";
            this.Column4.HeaderText = "刀具规格";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "daojuid";
            this.Column3.HeaderText = "刀具ID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // xzjc
            // 
            this.xzjc.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xzjc.Location = new System.Drawing.Point(376, 539);
            this.xzjc.Name = "xzjc";
            this.xzjc.Size = new System.Drawing.Size(96, 29);
            this.xzjc.TabIndex = 3;
            this.xzjc.Text = "新增机床";
            this.xzjc.UseVisualStyleBackColor = true;
            this.xzjc.Click += new System.EventHandler(this.xzjc_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.jcdth);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(199, 212);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(781, 313);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "机床刀具库";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(488, 539);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "删除机床";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.xzjc_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(610, 539);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 29);
            this.button2.TabIndex = 5;
            this.button2.Text = "导入图片";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.jichuangtupian);
            this.groupBox3.Location = new System.Drawing.Point(102, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 172);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "机床图片";
            // 
            // jichuang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 580);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.xzjc);
            this.Controls.Add(this.jcxx);
            this.Controls.Add(this.groupBox1);
            this.Name = "jichuang";
            this.Text = "机床管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.jichuang_FormClosed);
            this.Load += new System.EventHandler(this.jichuang_Load);
            this.SizeChanged += new System.EventHandler(this.jichuang_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.jcxx.ResumeLayout(false);
            this.jcxx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jichuangtupian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jcdth)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox jcxx;
        private System.Windows.Forms.Button xzjc;
        private System.Windows.Forms.DataGridView jcdth;
        private System.Windows.Forms.PictureBox jichuangtupian;
        private System.Windows.Forms.TextBox jcmc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ssscx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox jclx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}