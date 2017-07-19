namespace kucunTest.CaiGou
{
    partial class CGXQ
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.TCRQ = new System.Windows.Forms.DateTimePicker();
            this.RCDH = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ruCangMingXi = new System.Windows.Forms.DataGridView();
            this.xinghao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.类别 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.需求数量 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.到货日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CZY = new System.Windows.Forms.ComboBox();
            this.BM = new System.Windows.Forms.ComboBox();
            this.CJ = new System.Windows.Forms.ComboBox();
            this.comments = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.print = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.daochu = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ruCangMingXi)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.TCRQ);
            this.groupBox1.Controls.Add(this.RCDH);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(195, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "单据信息";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(525, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "紧急！";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // TCRQ
            // 
            this.TCRQ.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TCRQ.Location = new System.Drawing.Point(332, 27);
            this.TCRQ.Name = "TCRQ";
            this.TCRQ.Size = new System.Drawing.Size(135, 21);
            this.TCRQ.TabIndex = 4;
            this.TCRQ.Value = new System.DateTime(2017, 5, 2, 0, 0, 0, 0);
            // 
            // RCDH
            // 
            this.RCDH.Location = new System.Drawing.Point(90, 27);
            this.RCDH.Name = "RCDH";
            this.RCDH.Size = new System.Drawing.Size(121, 21);
            this.RCDH.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(261, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "提出日期：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "需求单号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ruCangMingXi);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(195, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(726, 279);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "需求明细";
            // 
            // ruCangMingXi
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.ruCangMingXi.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ruCangMingXi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ruCangMingXi.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ruCangMingXi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.xinghao,
            this.名称,
            this.类别,
            this.gg,
            this.需求数量,
            this.到货日期,
            this.bz});
            this.ruCangMingXi.Location = new System.Drawing.Point(7, 21);
            this.ruCangMingXi.Name = "ruCangMingXi";
            this.ruCangMingXi.RowTemplate.Height = 23;
            this.ruCangMingXi.Size = new System.Drawing.Size(713, 223);
            this.ruCangMingXi.TabIndex = 0;
            // 
            // xinghao
            // 
            this.xinghao.FillWeight = 127.8159F;
            this.xinghao.HeaderText = "型号";
            this.xinghao.Name = "xinghao";
            this.xinghao.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // 名称
            // 
            this.名称.FillWeight = 127.8159F;
            this.名称.HeaderText = "名称";
            this.名称.Name = "名称";
            this.名称.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // 类别
            // 
            this.类别.HeaderText = "类别";
            this.类别.Name = "类别";
            // 
            // gg
            // 
            this.gg.FillWeight = 86.65488F;
            this.gg.HeaderText = "规格";
            this.gg.Name = "gg";
            this.gg.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // 需求数量
            // 
            this.需求数量.FillWeight = 82.00391F;
            this.需求数量.HeaderText = "需求数量";
            this.需求数量.Name = "需求数量";
            // 
            // 到货日期
            // 
            this.到货日期.FillWeight = 76.8274F;
            this.到货日期.HeaderText = "到货日期";
            this.到货日期.Name = "到货日期";
            this.到货日期.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // bz
            // 
            this.bz.FillWeight = 127.8159F;
            this.bz.HeaderText = "备注";
            this.bz.Name = "bz";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(645, 250);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(393, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "采购需求清单";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(846, 526);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CZY);
            this.groupBox3.Controls.Add(this.BM);
            this.groupBox3.Controls.Add(this.CJ);
            this.groupBox3.Controls.Add(this.comments);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(195, 415);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(726, 94);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作信息";
            // 
            // CZY
            // 
            this.CZY.FormattingEnabled = true;
            this.CZY.Items.AddRange(new object[] {
            "Jack",
            "Blue",
            "Tom",
            "二狗"});
            this.CZY.Location = new System.Drawing.Point(530, 23);
            this.CZY.Name = "CZY";
            this.CZY.Size = new System.Drawing.Size(121, 20);
            this.CZY.TabIndex = 2;
            // 
            // BM
            // 
            this.BM.FormattingEnabled = true;
            this.BM.Items.AddRange(new object[] {
            "刀管中心",
            "其他"});
            this.BM.Location = new System.Drawing.Point(302, 23);
            this.BM.Name = "BM";
            this.BM.Size = new System.Drawing.Size(121, 20);
            this.BM.TabIndex = 2;
            // 
            // CJ
            // 
            this.CJ.FormattingEnabled = true;
            this.CJ.Items.AddRange(new object[] {
            "机一车间",
            "其他车间"});
            this.CJ.Location = new System.Drawing.Point(79, 23);
            this.CJ.Name = "CJ";
            this.CJ.Size = new System.Drawing.Size(121, 20);
            this.CJ.TabIndex = 2;
            // 
            // comments
            // 
            this.comments.Location = new System.Drawing.Point(79, 53);
            this.comments.Multiline = true;
            this.comments.Name = "comments";
            this.comments.Size = new System.Drawing.Size(344, 35);
            this.comments.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "备    注：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "操 作 员：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "部    门：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "车    间：";
            // 
            // print
            // 
            this.print.Location = new System.Drawing.Point(754, 526);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(75, 23);
            this.print.TabIndex = 3;
            this.print.Text = "打印";
            this.print.UseVisualStyleBackColor = true;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(559, 526);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 3;
            this.save.Text = "保存";
            this.save.UseVisualStyleBackColor = true;
            // 
            // daochu
            // 
            this.daochu.Location = new System.Drawing.Point(659, 526);
            this.daochu.Name = "daochu";
            this.daochu.Size = new System.Drawing.Size(75, 23);
            this.daochu.TabIndex = 3;
            this.daochu.Text = "导出";
            this.daochu.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(6, 20);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(165, 422);
            this.treeView1.TabIndex = 6;
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.treeView1);
            this.groupBox4.Location = new System.Drawing.Point(12, 61);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(177, 448);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "刀具及零部件";
            // 
            // CGXQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 561);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.daochu);
            this.Controls.Add(this.save);
            this.Controls.Add(this.print);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CGXQ";
            this.Text = "采购需求清单";
            this.Load += new System.EventHandler(this.CGXQ_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ruCangMingXi)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox RCDH;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView ruCangMingXi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CZY;
        private System.Windows.Forms.ComboBox BM;
        private System.Windows.Forms.ComboBox CJ;
        private System.Windows.Forms.TextBox comments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.DateTimePicker TCRQ;
        private System.Windows.Forms.Button daochu;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn xinghao;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 类别;
        private System.Windows.Forms.DataGridViewTextBoxColumn gg;
        private System.Windows.Forms.DataGridViewTextBoxColumn 需求数量;
        private System.Windows.Forms.DataGridViewTextBoxColumn 到货日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn bz;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}