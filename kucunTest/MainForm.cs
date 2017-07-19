using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using kucunTest;
using kucunTest.RuCang;
using kucunTest.ChuCang;
using kucunTest.KuCun;
using kucunTest.DaoJu;
using kucunTest.CaiGou;
using kucunTest.FastReport;

namespace kucunTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;//窗口默认最大化
            //panel1.BackColor = Color.FromArgb(0, 255, 0, 0);
        }

        /// <summary>
        /// 库存管理--库存明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 库存明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KCMingXi kcmx = new KCMingXi();
            kcmx.MdiParent = this;
            kcmx.Parent = this.panel1;
            this.panel1.Visible = true;
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
            ccFrm.Parent = this.panel1;
            this.panel1.Visible = true;
            ccFrm.Show();
        }

        private void 出仓历史ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CCHistory cchistory = new CCHistory();
            cchistory.MdiParent = this;
            cchistory.Parent = this.panel1;
            this.panel1.Visible = true;
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
            rcFrm.Parent = this.panel1;
            this.panel1.Visible = true;
            //rcFrm.Location = CenterToParent;
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
            rchistory.Parent = this.panel1;
            this.panel1.Visible = true;
            rchistory.Show();
        }

        #endregion 库存管理模块结束

        private void 临时ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 刀具测量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJCL djclFrm = new DJCL();
            djclFrm.MdiParent = this;
            djclFrm.Parent = this.panel1;
            this.panel1.Visible = true;
            djclFrm.Show();
        }

        private void 刀具监测ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJJC djjcFrm = new DJJC();
            djjcFrm.MdiParent = this;
            djjcFrm.Parent = this.panel1;
            this.panel1.Visible = true;
            djjcFrm.Show();
        }

        private void 配刀清单管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PDQDGL pdqdglFrm = new PDQDGL();
            pdqdglFrm.MdiParent = this;
            pdqdglFrm.Parent = this.panel1;
            this.panel1.Visible = true;
            pdqdglFrm.Show();
        }

        private void 刀具装配ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJZPCC djccFrm = new DJZPCC();
            djccFrm.MdiParent = this;
            djccFrm.Parent = this.panel1;
            this.panel1.Visible = true;
            djccFrm.Show();
        }

        private void 刀具拆卸入仓ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJCCRC djccrcFrm = new DJCCRC();
            djccrcFrm.MdiParent = this;
            djccrcFrm.Parent = this.panel1;
            this.panel1.Visible = true;
            djccrcFrm.Show();
        }

        private void 新建采购需求ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CGXQ cgxqFrm = new CGXQ();
            cgxqFrm.MdiParent = this;
            cgxqFrm.Parent = this.panel1;
            this.panel1.Visible = true;
            cgxqFrm.Show();
        }

        private void fR测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FastReport.FastReport测试 fr = new FastReport测试();
            fr.Show();
        }

        private void 刀具领用单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DJGL djglFrm = new DJGL();
            //djglFrm.MdiParent = this;
            //djglFrm.Parent = panel1;
            //this.panel1.Visible = true;
            //djglFrm.Show();

            DJCCD djccd = new DJCCD();
            djccd.MdiParent = this;
            djccd.Show();
        }

        private void 刀具外借单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJWJ djwj = new DJWJ();
            //djwj.MdiParent = this;
            djwj.Show();
        }

        private void 刀具更换单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJGH djgh = new DJGH();
            djgh.MdiParent = this;
            djgh.Show();
        }

        private void 刀具报废单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJBF djbf = new DJBF();
            djbf.MdiParent = this;
            djbf.Show();
        }

        private void 刀具退还单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DJTH djth = new DJTH();
            djth.MdiParent = this;
            djth.Show();
        }

        private void 刀具管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DaoJuGuanLi djgl = new DaoJuGuanLi();
            //djgl.MdiParent = this;
            //djgl.Parent = panel1;
            djgl.Show();
        }
    }
}
