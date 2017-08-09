﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using kucunTest.LingBuJian;
using kucunTest.RuCang;
using kucunTest.ChuCang;
using kucunTest.KuCun;
using kucunTest.DaoJu;
using kucunTest.CaiGou;
using kucunTest.FastReport;
using kucunTest.BaseClasses;
using kucunTest.Daojugui;
using kucunTest.Jichuang;


namespace kucunTest
{
    public partial class MainForm : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";

        private AutoSizeFormClass asc = new AutoSizeFormClass();
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            asc.controllInitializeSize(this);

            //this.WindowState = FormWindowState.Maximized;//窗口默认最大化

            Sqlstr = "SELECT COUNT(DISTINCT dt.daojuleixing) FROM daojutemp dt";
            djzlsl.Text = SQL.ExecuteScalar(Sqlstr).ToString();//刀具种类

            Sqlstr = "SELECT COUNT(DISTINCT dt.daojuid) FROM daojutemp dt";
            djsl.Text = SQL.ExecuteScalar(Sqlstr).ToString();//刀具数量

            Sqlstr = "SELECT COUNT(DISTINCT dt.daojuleixing) FROM daojutemp dt WHERE dt.weizhibiaoshi = 'M'";
            jczydjzl.Text = SQL.ExecuteScalar(Sqlstr).ToString();//机床在用刀具种类

            Sqlstr = "SELECT COUNT(DISTINCT dt.daojuid) FROM daojutemp dt WHERE dt.weizhibiaoshi = 'M'";
            jczydjsl.Text = SQL.ExecuteScalar(Sqlstr).ToString();//机床在用刀具数量

            Sqlstr = "SELECT COUNT(DISTINCT dt.daojuleixing) FROM daojutemp dt WHERE dt.weizhibiaoshi = 'S'";
            djgdjzlsl.Text = SQL.ExecuteScalar(Sqlstr).ToString();//刀具柜刀具种类

            Sqlstr = "SELECT COUNT(DISTINCT dt.daojuid) FROM daojutemp dt WHERE dt.weizhibiaoshi = 'S'";
            djgdjsl.Text = SQL.ExecuteScalar(Sqlstr).ToString();//刀具柜刀具数量
        }

        #region 其他

        /// <summary>
        /// 库存管理--库存明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 库存明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KCMingXi kcmx = new KCMingXi();
            kcmx.MdiParent = this;
            kcmx.Show();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 需求管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 需求历史ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 出仓管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #region 库存管理模块
        /// <summary>
        /// 库存管理之出仓--新建出仓单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新建出仓单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewCC ccFrm = new NewCC();
            ccFrm.MdiParent = this;
            ccFrm.Show();
        }

        private void 出仓历史ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CCHistory cchistory = new CCHistory();
            cchistory.MdiParent = this;
            cchistory.Show();
        }

        /// <summary>
        /// 库存管理之出仓--新建入仓单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新建入仓单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewRC rcFrm = new NewRC();
            rcFrm.MdiParent = this;
            rcFrm.Show();
        }

        /// <summary>
        /// 库存管理之出仓--入仓历史
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 入仓历史ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RCHistory rchistory = new RCHistory();
            rchistory.MdiParent = this;
            rchistory.Show();
        }

        #endregion 库存管理模块结束

        private void 刀具测量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJCL djclFrm = new DJCL();
            djclFrm.MdiParent = this;
            djclFrm.Show();
        }

        private void 刀具监测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJJC djjcFrm = new DJJC();
            djjcFrm.MdiParent = this;
            djjcFrm.Show();
        }

        private void 配刀清单管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PDQDGL pdqdglFrm = new PDQDGL();
            pdqdglFrm.MdiParent = this;
            pdqdglFrm.Show();
        }

        private void 刀具装配ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJZPCC djccFrm = new DJZPCC();
            djccFrm.MdiParent = this;
            djccFrm.Show();
        }

        private void 刀具拆卸入仓ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJCCRC djccrcFrm = new DJCCRC();
            djccrcFrm.MdiParent = this;
            djccrcFrm.Show();
        }

        private void 新建采购需求ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CGXQ cgxqFrm = new CGXQ();
            cgxqFrm.MdiParent = this;
            cgxqFrm.Show();
        }

        private void fR测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastReport.FastReport测试 fr = new FastReport测试();
            fr.Show();
        }

        #endregion 其他部分结束

        #region 刀具单据部分
        /// <summary>
        /// 刀具领用单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刀具领用单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJCCD djccd = new DJCCD();
            djccd.MdiParent = this;
            //tabControl1.Dock = DockStyle.Fill;

            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == djccd.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if (!have)
            {
                TabPage tb = new TabPage();
                tb.Name = djccd.Name;
                djccd.Parent = tb;
                tb.Text = djccd.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                djccd.Left = (tabControl1.Width - djccd.Width) / 2;
                djccd.Top = (tb.Height - djccd.Height) / 4;

                djccd.Show();
            }
        }

        /// <summary>
        /// 刀具外借单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刀具外借单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJWJ djwj = new DJWJ();
            djwj.MdiParent = this;

            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == djwj.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if(!have)
            {
                TabPage tb = new TabPage();
                tb.Name = djwj.Name;
                djwj.Parent = tb;
                tb.Text = djwj.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                djwj.Left = (tabControl1.Width - djwj.Width) / 2;
                djwj.Top = (tb.Height - djwj.Height) / 4;

                djwj.Show();
            }
            
        }

        /// <summary>
        /// 刀具更换单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刀具更换单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJGH djgh = new DJGH();
            djgh.MdiParent = this;

            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == djgh.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if(!have)
            {
                TabPage tb = new TabPage();
                tb.Name = djgh.Name;
                djgh.Parent = tb;
                tb.Text = djgh.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                djgh.Left = (tabControl1.Width - djgh.Width) / 2;
                djgh.Top = (tb.Height - djgh.Height) / 4;

                djgh.Show();
            }
            
        }

        /// <summary>
        /// 刀具报废单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刀具报废单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJBF djbf = new DJBF();
            djbf.MdiParent = this;

            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == djbf.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if(!have)
            {
                TabPage tb = new TabPage();
                tb.Name = djbf.Name;
                djbf.Parent = tb;
                tb.Text = djbf.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                djbf.Left = (tabControl1.Width - djbf.Width) / 2;
                djbf.Top = (tb.Height - djbf.Height) / 4;

                djbf.Show();
            }
        }

        /// <summary>
        /// 刀具退还单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刀具退还单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJTH djth = new DJTH();
            djth.MdiParent = this;

            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == djth.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if(!have)
            {
                TabPage tb = new TabPage();
                tb.Name = djth.Name;
                djth.Parent = tb;
                tb.Text = djth.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                djth.Left = (tabControl1.Width - djth.Width) / 2;
                djth.Top = (tb.Height - djth.Height) / 4;

                djth.Show();
            }
        }

        /// <summary>
        /// 组和领用单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 组合领用单据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJZZLY djzzly = new DJZZLY();
            djzzly.MdiParent = this;
            //djzzly.Owner = this;
            //djzzly.Show();

            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == djzzly.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if (!have)
            {
                TabPage tb = new TabPage();
                tb.Name = djzzly.Name;
                djzzly.Parent = tb;
                tb.Text = djzzly.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                djzzly.Left = (tabControl1.Width - djzzly.Width) / 2;
                djzzly.Top = (tb.Height - djzzly.Height) / 4;

                djzzly.Show();
            }
        }

        /// <summary>
        /// 刀具管理界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刀具管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DaoJuGuanLi djgl = new DaoJuGuanLi();
            //djgl.MdiParent = this;
            //djgl.Parent = panel1;

            //TabPage tb_djgl = new TabPage();
            //djgl.Parent = tb_djgl;
            //tb_djgl.Text = djgl.Text;

            //this.tabControl1.TabPages.Add(tb_djgl);
            //tabControl1.SelectedTab = tb_djgl;
            //tabControl1.Visible = true;

            djgl.Show();
        }

        #endregion 刀具单据部分结束

        /// <summary>
        /// 窗口自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        /// <summary>
        /// 关闭选中的选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_Click(object sender, EventArgs e)
        {
            if(this.tabControl1.SelectedTab == TabIndex )
            {
                MessageBox.Show("首页不可关闭！", "提示");
            }
            else
            {
                this.tabControl1.SelectedTab.Dispose();//关闭当前选项卡
            }
        }

        /// <summary>
        /// 关闭窗体时调用关闭选项卡
        /// </summary>
        /// <param name="tab_name"></param>
        public void CloseTab(string tab_name)
        {
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Name == tab_name)
                {
                    tp.Dispose();
                    return;
                }
            }
        }
        
        /// <summary>
        /// 关闭全部选项卡，除了首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeAll_Click(object sender, EventArgs e)
        {
            foreach(TabPage tp in tabControl1.TabPages)
            {
                if(tp.Text != "首页")
                {
                    tp.Dispose();
                }
            }
        }

        /// <summary>
        /// 鼠标在选项卡右击弹出菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < tabControl1.TabPages.Count; i++)
                {
                    TabPage tp = tabControl1.TabPages[i];
                    if(tp.Text != "首页")
                    {
                        if (tabControl1.GetTabRect(i).Contains(new Point(e.X, e.Y)))
                        {
                            tabControl1.SelectedTab = tp;
                            break;
                        }
                    }                    
                }
                this.tabControl1.ContextMenuStrip = this.contextMenuStrip1;//弹出菜单
            }
        }

        /// <summary>
        /// 鼠标移开选项卡，取消菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_MouseLeave(object sender, EventArgs e)
        {
            this.tabControl1.ContextMenuStrip = null;
        }

        #region 首页linklabel部分
        /// <summary>
        /// 刀具管理linklabel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            刀具管理ToolStripMenuItem_Click(null, null);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            刀具领用单ToolStripMenuItem_Click(null, null);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            零部件领用单ToolStripMenuItem_Click(null, null);
        }
        #endregion 首页linklabel部分结束

        #region 零部件单据
        /// <summary>
        /// 零部件领用单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 零部件领用单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LBJLY lbjly = new LBJLY();
            lbjly.MdiParent = this;

            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == lbjly.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if (!have)
            {
                TabPage tb_djccd = new TabPage();
                lbjly.Parent = tb_djccd;
                tb_djccd.Text = lbjly.Text;
                tb_djccd.BackgroundImage = kucunTest.Properties.Resources.background;
                tb_djccd.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb_djccd);
                tabControl1.SelectedTab = tb_djccd;
                tabControl1.Visible = true;

                lbjly.StartPosition = FormStartPosition.Manual;
                lbjly.Left = (tabControl1.Width - lbjly.Width) / 4;
                lbjly.Top = (tb_djccd.Height - lbjly.Height) / 4;

                lbjly.Show();
            }
        }

        /// <summary>
        /// 零部件退还单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 零部件退还单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LBJTH lbjth = new LBJTH();
            lbjth.MdiParent = this;

            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == lbjth.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if (!have)
            {
                TabPage tb_djccd = new TabPage();
                lbjth.Parent = tb_djccd;
                tb_djccd.Text = lbjth.Text;
                tb_djccd.BackgroundImage = kucunTest.Properties.Resources.background;
                tb_djccd.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb_djccd);
                tabControl1.SelectedTab = tb_djccd;
                tabControl1.Visible = true;

                lbjth.StartPosition = FormStartPosition.Manual;
                lbjth.Left = (tabControl1.Width - lbjth.Width) / 4;
                lbjth.Top = (tb_djccd.Height - lbjth.Height) / 4;

                lbjth.Show();
            }
        }


        #endregion 零部件单据结束

        private void 零部件库存管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbj_GuanLi lbjgl = new lbj_GuanLi();
            lbjgl.Show();
        }

        private void 刀具类型管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DaoJuLeiXingGuanLi djlxgl = new DaoJuLeiXingGuanLi();
            djlxgl.Show();
        }

        private void 刀具柜管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            daojugui djg = new daojugui();
            //djg.MdiParent = this;
            djg.Show();
        }

        private void 机床管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jichuang jc = new jichuang();
            //jc.MdiParent = this;
            jc.Show();
        }

    }
}
