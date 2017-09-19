namespace kucunTest.DaoJu
{
    partial class zhuangpeidaoju
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbjmx = new System.Windows.Forms.DataGridView();
            this.lbjmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbjxh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbjgg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kcsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.djid = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.djlx = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.djgg = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.jtwz = new System.Windows.Forms.ComboBox();
            this.djgbm = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbjmx)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 22F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(583, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "组装刀具";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "刀具类型";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbjmx);
            this.groupBox1.Location = new System.Drawing.Point(14, 194);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(550, 246);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "零部件信息";
            // 
            // lbjmx
            // 
            this.lbjmx.AllowUserToAddRows = false;
            this.lbjmx.AllowUserToDeleteRows = false;
            this.lbjmx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lbjmx.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lbjmx.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.lbjmx.ColumnHeadersHeight = 32;
            this.lbjmx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lbjmc,
            this.lbjxh,
            this.lbjgg,
            this.sl,
            this.dw,
            this.kcsl});
            this.lbjmx.Location = new System.Drawing.Point(10, 35);
            this.lbjmx.Margin = new System.Windows.Forms.Padding(5);
            this.lbjmx.Name = "lbjmx";
            this.lbjmx.ReadOnly = true;
            this.lbjmx.RowTemplate.Height = 23;
            this.lbjmx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lbjmx.Size = new System.Drawing.Size(528, 201);
            this.lbjmx.TabIndex = 0;
            this.lbjmx.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.lbjmx_RowPostPaint);
            // 
            // lbjmc
            // 
            this.lbjmc.DataPropertyName = "lbjmc";
            this.lbjmc.FillWeight = 107.9076F;
            this.lbjmc.HeaderText = "零部件名称";
            this.lbjmc.Name = "lbjmc";
            this.lbjmc.ReadOnly = true;
            // 
            // lbjxh
            // 
            this.lbjxh.DataPropertyName = "lbjxh";
            this.lbjxh.FillWeight = 128.4288F;
            this.lbjxh.HeaderText = "零部件型号";
            this.lbjxh.Name = "lbjxh";
            this.lbjxh.ReadOnly = true;
            // 
            // lbjgg
            // 
            this.lbjgg.DataPropertyName = "lbjgg";
            this.lbjgg.FillWeight = 121.3444F;
            this.lbjgg.HeaderText = "规格";
            this.lbjgg.Name = "lbjgg";
            this.lbjgg.ReadOnly = true;
            // 
            // sl
            // 
            this.sl.DataPropertyName = "sl";
            this.sl.FillWeight = 97.40771F;
            this.sl.HeaderText = "数量";
            this.sl.Name = "sl";
            this.sl.ReadOnly = true;
            // 
            // dw
            // 
            this.dw.DataPropertyName = "dw";
            this.dw.HeaderText = "单位";
            this.dw.Name = "dw";
            this.dw.ReadOnly = true;
            // 
            // kcsl
            // 
            this.kcsl.DataPropertyName = "kcsl";
            this.kcsl.HeaderText = "库存数量";
            this.kcsl.Name = "kcsl";
            this.kcsl.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 157);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "刀具 ID";
            // 
            // djid
            // 
            this.djid.Enabled = false;
            this.djid.Location = new System.Drawing.Point(116, 154);
            this.djid.Margin = new System.Windows.Forms.Padding(5);
            this.djid.Name = "djid";
            this.djid.Size = new System.Drawing.Size(139, 29);
            this.djid.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 450);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 40);
            this.button1.TabIndex = 7;
            this.button1.Text = "组装刀具";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(305, 450);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 40);
            this.button2.TabIndex = 8;
            this.button2.Text = "取消组装";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // djlx
            // 
            this.djlx.FormattingEnabled = true;
            this.djlx.Location = new System.Drawing.Point(116, 57);
            this.djlx.Margin = new System.Windows.Forms.Padding(5);
            this.djlx.Name = "djlx";
            this.djlx.Size = new System.Drawing.Size(139, 29);
            this.djlx.TabIndex = 9;
            this.djlx.SelectedIndexChanged += new System.EventHandler(this.djxh_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "刀具规格";
            // 
            // djgg
            // 
            this.djgg.FormattingEnabled = true;
            this.djgg.Location = new System.Drawing.Point(385, 57);
            this.djgg.Margin = new System.Windows.Forms.Padding(5);
            this.djgg.Name = "djgg";
            this.djgg.Size = new System.Drawing.Size(139, 29);
            this.djgg.TabIndex = 9;
            this.djgg.SelectedIndexChanged += new System.EventHandler(this.djgg_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(305, 150);
            this.button3.Margin = new System.Windows.Forms.Padding(5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 34);
            this.button3.TabIndex = 8;
            this.button3.Text = "生成刀具ID";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 106);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "刀柜编码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(301, 106);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "具体位置";
            // 
            // jtwz
            // 
            this.jtwz.FormattingEnabled = true;
            this.jtwz.Location = new System.Drawing.Point(385, 103);
            this.jtwz.Margin = new System.Windows.Forms.Padding(5);
            this.jtwz.Name = "jtwz";
            this.jtwz.Size = new System.Drawing.Size(139, 29);
            this.jtwz.TabIndex = 9;
            this.jtwz.SelectedIndexChanged += new System.EventHandler(this.djgg_SelectedIndexChanged);
            // 
            // djgbm
            // 
            this.djgbm.FormattingEnabled = true;
            this.djgbm.Location = new System.Drawing.Point(116, 106);
            this.djgbm.Name = "djgbm";
            this.djgbm.Size = new System.Drawing.Size(139, 29);
            this.djgbm.TabIndex = 10;
            this.djgbm.SelectedIndexChanged += new System.EventHandler(this.djgbm_SelectedIndexChanged);
            // 
            // zhuangpeidaoju
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 504);
            this.Controls.Add(this.djgbm);
            this.Controls.Add(this.jtwz);
            this.Controls.Add(this.djgg);
            this.Controls.Add(this.djlx);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.djid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "zhuangpeidaoju";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "装配刀具";
            this.Load += new System.EventHandler(this.zhuangpeidaoju_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbjmx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView lbjmx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox djid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox djlx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox djgg;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox jtwz;
        private System.Windows.Forms.DataGridViewTextBoxColumn lbjmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn lbjxh;
        private System.Windows.Forms.DataGridViewTextBoxColumn lbjgg;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dw;
        private System.Windows.Forms.DataGridViewTextBoxColumn kcsl;
        private System.Windows.Forms.ComboBox dgbm;
        private System.Windows.Forms.ComboBox djgbm;
    }
}