﻿namespace kucunTest.DaoJu
{
    partial class chaixiedaoju
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
            this.daojuid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbjmx = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.daojuleixing = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.daojuguige = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.daojuxinghao = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbjmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbjxh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbjgg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kcsl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kcwz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lbjmx)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // daojuid
            // 
            this.daojuid.Enabled = false;
            this.daojuid.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daojuid.Location = new System.Drawing.Point(473, 80);
            this.daojuid.Margin = new System.Windows.Forms.Padding(5);
            this.daojuid.Name = "daojuid";
            this.daojuid.ReadOnly = true;
            this.daojuid.Size = new System.Drawing.Size(201, 29);
            this.daojuid.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(389, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "刀具 ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(24, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "刀具类型";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("宋体", 22F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(742, 52);
            this.label1.TabIndex = 11;
            this.label1.Text = "拆卸刀具";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbjmx
            // 
            this.lbjmx.AllowUserToAddRows = false;
            this.lbjmx.AllowUserToDeleteRows = false;
            this.lbjmx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.lbjmx.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lbjmx.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.lbjmx.ColumnHeadersHeight = 32;
            this.lbjmx.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lbjmc,
            this.lbjxh,
            this.lbjgg,
            this.sl,
            this.dw,
            this.kcsl,
            this.kcwz});
            this.lbjmx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbjmx.Location = new System.Drawing.Point(5, 27);
            this.lbjmx.Margin = new System.Windows.Forms.Padding(5);
            this.lbjmx.Name = "lbjmx";
            this.lbjmx.ReadOnly = true;
            this.lbjmx.RowTemplate.Height = 23;
            this.lbjmx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.lbjmx.Size = new System.Drawing.Size(704, 214);
            this.lbjmx.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(391, 453);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 40);
            this.button2.TabIndex = 17;
            this.button2.Text = "取消拆卸";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(232, 453);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 40);
            this.button1.TabIndex = 16;
            this.button1.Text = "拆卸刀具";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbjmx);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(14, 193);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(714, 246);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "零部件信息";
            // 
            // daojuleixing
            // 
            this.daojuleixing.Enabled = false;
            this.daojuleixing.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daojuleixing.Location = new System.Drawing.Point(108, 33);
            this.daojuleixing.Margin = new System.Windows.Forms.Padding(5);
            this.daojuleixing.Name = "daojuleixing";
            this.daojuleixing.ReadOnly = true;
            this.daojuleixing.Size = new System.Drawing.Size(183, 29);
            this.daojuleixing.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label4.Location = new System.Drawing.Point(389, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 19;
            this.label4.Text = "刀具规格";
            // 
            // daojuguige
            // 
            this.daojuguige.Enabled = false;
            this.daojuguige.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daojuguige.Location = new System.Drawing.Point(473, 33);
            this.daojuguige.Margin = new System.Windows.Forms.Padding(5);
            this.daojuguige.Name = "daojuguige";
            this.daojuguige.ReadOnly = true;
            this.daojuguige.Size = new System.Drawing.Size(201, 29);
            this.daojuguige.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label5.Location = new System.Drawing.Point(24, 83);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 21;
            this.label5.Text = "刀具型号";
            // 
            // daojuxinghao
            // 
            this.daojuxinghao.Enabled = false;
            this.daojuxinghao.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.daojuxinghao.Location = new System.Drawing.Point(108, 80);
            this.daojuxinghao.Margin = new System.Windows.Forms.Padding(5);
            this.daojuxinghao.Name = "daojuxinghao";
            this.daojuxinghao.ReadOnly = true;
            this.daojuxinghao.Size = new System.Drawing.Size(183, 29);
            this.daojuxinghao.TabIndex = 22;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.daojuxinghao);
            this.groupBox2.Controls.Add(this.daojuid);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.daojuleixing);
            this.groupBox2.Controls.Add(this.daojuguige);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(14, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(714, 121);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "刀具信息";
            // 
            // lbjmc
            // 
            this.lbjmc.DataPropertyName = "lbjmc";
            this.lbjmc.FillWeight = 107.9076F;
            this.lbjmc.HeaderText = "零部件名称";
            this.lbjmc.Name = "lbjmc";
            this.lbjmc.ReadOnly = true;
            this.lbjmc.Width = 115;
            // 
            // lbjxh
            // 
            this.lbjxh.DataPropertyName = "lbjxh";
            this.lbjxh.FillWeight = 128.4288F;
            this.lbjxh.HeaderText = "零部件型号";
            this.lbjxh.Name = "lbjxh";
            this.lbjxh.ReadOnly = true;
            this.lbjxh.Width = 115;
            // 
            // lbjgg
            // 
            this.lbjgg.DataPropertyName = "lbjgg";
            this.lbjgg.FillWeight = 121.3444F;
            this.lbjgg.HeaderText = "零部件规格";
            this.lbjgg.Name = "lbjgg";
            this.lbjgg.ReadOnly = true;
            this.lbjgg.Width = 115;
            // 
            // sl
            // 
            this.sl.DataPropertyName = "sl";
            this.sl.FillWeight = 97.40771F;
            this.sl.HeaderText = "数量";
            this.sl.Name = "sl";
            this.sl.ReadOnly = true;
            this.sl.Width = 67;
            // 
            // dw
            // 
            this.dw.DataPropertyName = "dw";
            this.dw.HeaderText = "单位";
            this.dw.Name = "dw";
            this.dw.ReadOnly = true;
            this.dw.Width = 67;
            // 
            // kcsl
            // 
            this.kcsl.DataPropertyName = "kcsl";
            this.kcsl.HeaderText = "库存数量";
            this.kcsl.Name = "kcsl";
            this.kcsl.ReadOnly = true;
            this.kcsl.Width = 99;
            // 
            // kcwz
            // 
            this.kcwz.DataPropertyName = "kcwz";
            this.kcwz.HeaderText = "库存位置";
            this.kcwz.Name = "kcwz";
            this.kcwz.ReadOnly = true;
            this.kcwz.Width = 99;
            // 
            // chaixiedaoju
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 507);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "chaixiedaoju";
            this.Text = "拆卸刀具";
            this.Load += new System.EventHandler(this.chaixiedaoju_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lbjmx)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox daojuid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView lbjmx;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox daojuleixing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox daojuguige;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox daojuxinghao;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn lbjmc;
        private System.Windows.Forms.DataGridViewTextBoxColumn lbjxh;
        private System.Windows.Forms.DataGridViewTextBoxColumn lbjgg;
        private System.Windows.Forms.DataGridViewTextBoxColumn sl;
        private System.Windows.Forms.DataGridViewTextBoxColumn dw;
        private System.Windows.Forms.DataGridViewTextBoxColumn kcsl;
        private System.Windows.Forms.DataGridViewTextBoxColumn kcwz;
    }
}