using System;
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
using kucunTest.gongyika;
using kucunTest.quanxianguanli;

using System.Runtime.InteropServices;

namespace kucunTest
{
    public partial class MainForm : Form
    {
        #region 全局变量
        public static MainForm MF = new MainForm();

        MySql SQL = new MySql();
        string Sqlstr = "";

        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private string nongli = "";//农历日期

        bool Collapsed = false;
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);//记录窗体大小，以便进行窗口自适应
            this.WindowState = FormWindowState.Maximized;//窗口默认最大化
            Win32.AnimateWindow(this.Handle, 2000, Win32.AW_BLEND);//窗体淡入效果

            menu_treeView.ExpandAll();
            menu_treeView.SelectedNode = null;

            //加载系统提示数据
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

            //加载系统时间
            nongli = ChinaDate.GetChinaDate(DateTime.Now);
            //toolStripStatusLabel_TimeNow.Text =DateTime.Now.ToString("yyyy年M月d日 dddd HH:mm:ss") + nongli;//日期格式形如：2017年8月10日 星期四 14:17:20 农历 
            toolStripStatusLabel_TimeNow.Text = DateTime.Now.ToString("yyyy年M月d日 dddd [") + nongli + DateTime.Now.ToString("] HH:mm:ss");//日期格式形如：2017年8月10日 星期四 14:17:20

            this.timer1.Start();//计时器开始计时，每秒更新时间
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

        #endregion 刀具单据部分结束

        #region 选项卡操作部分
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

        #endregion 选项卡操作部分结束

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

        private void linkLabel_lbjgl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            零部件库存管理ToolStripMenuItem_Click(null, null);
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

        #region 主菜单部分

        #region 主菜单——刀具
        /// <summary>
        /// 刀具管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刀具管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DaoJuGuanLi djgl = new DaoJuGuanLi();
            djgl.MdiParent = this;

            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == djgl.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if (!have)
            {
                TabPage tb = new TabPage();
                tb.Name = djgl.Name;
                djgl.Parent = tb;
                tb.Text = djgl.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                //djgl.Left = (tabControl1.Width - djgl.Width) / 2;
                //djgl.Top = (tb.Height - djgl.Height) / 4;

                //djgl.Width = tb.Width;
                //djgl.Height = tb.Height;
                djgl.Size = tb.Size;
                //djgl.WindowState = FormWindowState.Maximized;

                //djgl.Dock = DockStyle.Fill;
                djgl.Show();
                djgl.Refresh_color();
                //djgl.WindowState = FormWindowState.Maximized;
            }
            //djgl.Parent = panel1;

            //TabPage tb_djgl = new TabPage();
            //djgl.Parent = tb_djgl;
            //tb_djgl.Text = djgl.Text;

            //this.tabControl1.TabPages.Add(tb_djgl);
            //tabControl1.SelectedTab = tb_djgl;
            //tabControl1.Visible = true;

            //djgl.Show();
        }

        /// <summary>
        /// 刀具类型管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刀具类型管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DaoJuLeiXingGuanLi djlxgl = new DaoJuLeiXingGuanLi();
            djlxgl.MdiParent = this;

            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == djlxgl.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if (!have)
            {
                TabPage tb = new TabPage();
                tb.Name = djlxgl.Name;
                djlxgl.Parent = tb;
                tb.Text = djlxgl.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                //djlxgl.Left = (tabControl1.Width - djlxgl.Width) / 2;
                //djlxgl.Top = (tb.Height - djlxgl.Height) / 4;
                djlxgl.Size = tb.Size;

                djlxgl.Show();
                //djlxgl.Dock = DockStyle.Fill;
            }

            //djlxgl.Show();
        }
        #endregion 主菜单——刀具结束

        #region 主菜单——零部件
        /// <summary>
        /// 零部件库存管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 零部件库存管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbj_GuanLi lbjgl = new lbj_GuanLi();
            lbjgl.MdiParent = this;

            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == lbjgl.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if (!have)
            {
                TabPage tb = new TabPage();
                tb.Name = lbjgl.Name;
                lbjgl.Parent = tb;
                tb.Text = lbjgl.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                lbjgl.Left = (tabControl1.Width - lbjgl.Width) / 2;
                lbjgl.Top = (tb.Height - lbjgl.Height) / 4;

                lbjgl.Dock = DockStyle.Fill;
                lbjgl.Show();

            }
        }

        /// <summary>
        /// 零部件领用单
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
                TabPage tb = new TabPage();
                tb.Name = lbjly.Name;
                lbjly.Parent = tb;
                tb.Text = lbjly.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                lbjly.StartPosition = FormStartPosition.Manual;
                lbjly.Left = (tabControl1.Width - lbjly.Width) / 4;
                lbjly.Top = (tb.Height - lbjly.Height) / 4;

                lbjly.Show();
            }
        }

        /// <summary>
        /// 零部件退还单
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
                TabPage tb = new TabPage();
                tb.Name = lbjth.Name;
                lbjth.Parent = tb;
                tb.Text = lbjth.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                lbjth.StartPosition = FormStartPosition.Manual;
                lbjth.Left = (tabControl1.Width - lbjth.Width) / 4;
                lbjth.Top = (tb.Height - lbjth.Height) / 4;

                lbjth.Show();
            }
        }
        #endregion 主菜单——零部件结束

        #region 主菜单——刀具柜

        /// <summary>
        /// 刀具柜管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刀具柜管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            daojugui djg = new daojugui();
            djg.MdiParent = this;

            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == djg.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if (!have)
            {
                TabPage tb = new TabPage();
                tb.Name = djg.Name;
                djg.Parent = tb;
                tb.Text = djg.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                //djg.Left = (tabControl1.Width - djg.Width) / 2;
                //djg.Top = (tb.Height - djg.Height) / 4;
                djg.Size = tb.Size;

                djg.Show();
                //djg.Dock = DockStyle.Fill;
            }
        }

        #endregion 主菜单——刀具柜结束

        #region 主菜单——机床
        /// <summary>
        /// 机床管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 机床管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jichuang jc = new jichuang();
            jc.MdiParent = this;
            
            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == jc.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if (!have)
            {
                TabPage tb = new TabPage();
                tb.Name = jc.Name;
                jc.Parent = tb;
                tb.Text = jc.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                //jc.Left = (tabControl1.Width - jc.Width) / 2;
                //jc.Top = (tb.Height - jc.Height) / 4;
                jc.Size = tb.Size;

                jc.Show();
                //jc.Dock = DockStyle.Fill;
            }
        }
        #endregion 主菜单——机床结束

        #region 主菜单——工艺卡

        /// <summary>
        /// 工艺卡管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 工艺卡管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gyk gyka = new gyk();
            gyka.MdiParent = this;

            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == gyka.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if (!have)
            {
                TabPage tb = new TabPage();
                tb.Name = gyka.Name;
                gyka.Parent = tb;
                tb.Text = gyka.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                //gyka.Left = (tabControl1.Width - gyka.Width) / 2;
                //gyka.Top = (tb.Height - gyka.Height) / 4;
                gyka.Size = tb.Size;

                gyka.Show();
                //gyka.Dock = DockStyle.Fill;
            }

            //gyk gyka = new gyk();
            //gyka.Show();
            /*
            gyka.MdiParent = this;

            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == gyka.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if (!have)
            {
                TabPage tb = new TabPage();
                tb.Name = gyka.Name;
                gyka.Parent = tb;
                tb.Text = gyka.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                gyka.Left = (tabControl1.Width - gyka.Width) / 2;
                gyka.Top = (tb.Height - gyka.Height) / 4;

                gyka.Dock = DockStyle.Fill;
                }
                */
                //gyka.Show();
        }

        #endregion 主菜单——工艺卡结束

        #region 主菜单——基础资料

        #endregion 主菜单——基础资料结束

        #region 主菜单——系统管理

        /// <summary>
        /// 系统管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 系统管理ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            qxguanli qxgl = new qxguanli();
            qxgl.Show();
        }

        /// <summary>
        /// 权限管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 权限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 系统日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 系统日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 其他设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 其他设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion 主菜单——系统管理结束
        #endregion 主菜单部分结束


        #region 其他方法部分

        /// <summary>
        /// 窗口自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);
        }

        /// <summary>
        /// 计时器每秒更新当前时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //toolStripStatusLabel_TimeNow.Text = "当前时间：" + DateTime.Now.ToString("yyyy年M月d日 dddd [") + nongli + DateTime.Now.ToString("] HH:mm:ss");//日期格式形如：2017年8月10日 星期四 14:17:20
            toolStripStatusLabel_TimeNow.Text = DateTime.Now.ToString("yyyy年M月d日 dddd ") + nongli + DateTime.Now.ToString(" HH:mm:ss");//日期格式形如：2017年8月10日 星期四 14:17:20

            toolStripStatusLabel_TimeNow.ToolTipText = toolStripStatusLabel_TimeNow.Text;
        }

        /// <summary>
        /// 窗体淡入淡出效果
        /// </summary>
        public class Win32
        {
            public const Int32 AW_HOR_POSITIVE = 0x00000001;    // 从左到右打开窗口
            public const Int32 AW_HOR_NEGATIVE = 0x00000002;    // 从右到左打开窗口
            public const Int32 AW_VER_POSITIVE = 0x00000004;    // 从上到下打开窗口
            public const Int32 AW_VER_NEGATIVE = 0x00000008;    // 从下到上打开窗口
            public const Int32 AW_CENTER = 0x00000010;
            public const Int32 AW_HIDE = 0x00010000;        // 在窗体卸载时若想使用本函数就得加上此常量
            public const Int32 AW_ACTIVATE = 0x00020000;    //在窗体通过本函数打开后，默认情况下会失去焦点，除非加上本常量
            public const Int32 AW_SLIDE = 0x00040000;
            public const Int32 AW_BLEND = 0x00080000;       // 淡入淡出效果
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern bool AnimateWindow(
                IntPtr hwnd,  //  handle  to  window    
                int dwTime,  //  duration  of  animation    
                int dwFlags  //  animation  type    
                );
        }

        /// <summary>
        /// 窗体淡出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Win32.AnimateWindow(this.Handle, 2000, Win32.AW_SLIDE | Win32.AW_HIDE | Win32.AW_BLEND);
        }

        /// <summary>
        /// 拆分器更改大小后刷新tabpage界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            foreach (TabPage tp in tabControl1.TabPages)
            {
                tp.Refresh();
            }
        }

        /// <summary>
        /// 显示/隐藏菜单面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (Collapsed)
            {
                this.splitContainer1.Panel1Collapsed = false;
                Collapsed = false;
            }
            else
            {
                this.splitContainer1.Panel1Collapsed = true;
                Collapsed = true;
            }
        }

        /// <summary>
        /// 树状菜单选定后打开新选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (menu_treeView.SelectedNode.Level == 0)
            {
                switch (menu_treeView.SelectedNode.Tag.ToString())
                {
                    case "DJJC":
                        刀具管理ToolStripMenuItem_Click(null, null);
                        break;
                    case "KCMX":
                        DJKCMX_ShowTabPage();
                        break;
                    case "LXGL":
                        刀具类型管理ToolStripMenuItem1_Click(null, null);
                        break;
                }
            }
            else if (menu_treeView.SelectedNode.Level == 1)
            {
                //刀具续用单据暂时不作操作
                if (menu_treeView.SelectedNode.Tag.ToString() == "DJXY")
                {
                    return;
                }

                else
                {
                    History historyPage = new History(menu_treeView.SelectedNode.Tag.ToString());
                    historyPage.MdiParent = this;

                    bool have = false;
                    foreach (TabPage tp in tabControl1.TabPages)
                    {
                        if (tp.Text == historyPage.Text)
                        {
                            tabControl1.SelectedTab = tp;
                            have = true;
                            return;
                        }
                    }

                    if (!have)
                    {
                        TabPage tb = new TabPage();
                        tb.Name = historyPage.Name;
                        historyPage.Parent = tb;
                        tb.Text = historyPage.Text;
                        tb.BackgroundImage = kucunTest.Properties.Resources.background;
                        tb.BackgroundImageLayout = ImageLayout.Stretch;

                        this.tabControl1.TabPages.Add(tb);
                        tabControl1.SelectedTab = tb;
                        tabControl1.Visible = true;

                        historyPage.Left = (tabControl1.Width - historyPage.Width) / 2;
                        historyPage.Top = (tb.Height - historyPage.Height) / 4;

                        historyPage.Show();
                        historyPage.Dock = DockStyle.Fill;
                        historyPage.Refresh();
                    }

                    //historyPage.Show();
                }
            }
        }

        /// <summary>
        /// 刀具库存明细用tabpage展开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJKCMX_ShowTabPage()
        {
            DJKCMX djkcmx = new DJKCMX();
            djkcmx.MdiParent = this;

            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == djkcmx.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if (!have)
            {
                TabPage tb = new TabPage();
                tb.Name = djkcmx.Name;
                djkcmx.Parent = tb;
                tb.Text = djkcmx.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                djkcmx.Left = (tabControl1.Width - djkcmx.Width) / 2;
                djkcmx.Top = (tb.Height - djkcmx.Height) / 4;

                djkcmx.Dock = DockStyle.Fill;
                djkcmx.Show();
                djkcmx.Refresh_kcmxTable();
            }
        }

        /// <summary>
        /// 默认不选择任何的节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            //Unknown,引发操作未知, 一般非
            //①ByMouse--由鼠标操作引发
            //②ByKeyboard--由按键操作引发, 比如上下方向箭选择
            //③Collaspe--由折叠操作引发
            //④Expand--由展开操作引发
            //以上四种状态时, 就都属于这种, 窗体Show()时, TreeViewAction就是这种状态, 只要把这种状态的操作取消, 就能达到想要的效果
            if (e.Action == TreeViewAction.Unknown)
            {
                e.Cancel = true;
            }

        }

        #endregion 其他方法部分结束

        #region 公用方法部分
        public void showInTabPage(Form fr)
        {
            fr.MdiParent = this;

            bool have = false;
            foreach (TabPage tp in tabControl1.TabPages)
            {
                if (tp.Text == fr.Text)
                {
                    tabControl1.SelectedTab = tp;
                    have = true;
                    return;
                }
            }

            if (!have)
            {
                TabPage tb = new TabPage();
                tb.Name = fr.Name;
                fr.Parent = tb;
                tb.Text = fr.Text;
                tb.BackgroundImage = kucunTest.Properties.Resources.background;
                tb.BackgroundImageLayout = ImageLayout.Stretch;

                this.tabControl1.TabPages.Add(tb);
                tabControl1.SelectedTab = tb;
                tabControl1.Visible = true;

                //fr.Left = (tabControl1.Width - fr.Width) / 2;
                //fr.Top = (tb.Height - fr.Height) / 4;
                fr.Size = tb.Size;

                //fr.Dock = DockStyle.Fill;
                fr.Show();
            }
        }
        #endregion 公用方法部分结束


    }
}
