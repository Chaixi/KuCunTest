using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kucunTest.BaseClasses;

namespace kucunTest.LingBuJian
{
    public partial class lbjkcmx : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";

        string tishi = "";//提示文本

        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();//窗口自适应类

        //零部件表
        string lbjbiao = "jichuxinxi";
        string lbjbiao_lbjmc = "daojuid";
        string lbjbiao_lbjgg = "daojuguige";
        string lbjbiao_lbjxh = "daojuxinghao";
        string lbjbiao_djgbm = "weizhi";
        string lbjbiao_jtwz = "cengshu";
        string lbjbiao_kcsl = "kcsl";
        string lbjbiao_dw = "danwei";

        //流水表
        string liushuibiao = "lbj_liushui";
        string DHZD = "danhao";

        string TYPE = "LBJLY";
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public lbjkcmx()
        {
            InitializeComponent();

            //加载零部件名称
            Sqlstr = string.Format("SELECT DISTINCT {1} FROM {0} ORDER BY {1} ASC", lbjbiao, lbjbiao_lbjmc);
            cbx_lbjmc.DataSource = SQL.DataReadList(Sqlstr);
            cbx_lbjmc.SelectedIndex = -1;
            Sqlstr = "";

            //加载刀具柜名称
            Sqlstr = string.Format("SELECT djgmc FROM daojugui ORDER BY djgmc ASC");
            cbx_djgmc.DataSource = SQL.DataReadList(Sqlstr);
            cbx_djgmc.SelectedIndex = -1;
            Sqlstr = "";

            //加载库存明细
            Sqlstr = string.Format("SELECT {1} AS lbjmc, {2} AS lbjgg, {3} AS lbjxh, {4} AS djgbm, {5} AS jtwz, {6} AS kcsl, {7} AS dw FROM {0}", lbjbiao, lbjbiao_lbjmc, lbjbiao_lbjgg, lbjbiao_lbjxh, lbjbiao_djgbm, lbjbiao_jtwz, lbjbiao_kcsl, lbjbiao_dw);
            kcmx.AutoGenerateColumns = false;
            kcmx.DataSource = SQL.getDataSet(Sqlstr, lbjbiao).Tables[0].DefaultView;
            Sqlstr = "";
        }

        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbjkcmx_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        /// <summary>
        /// 刀具柜编码选择改变，加载相应刀具柜层数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void djgbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_djgmc.SelectedIndex < 0)
            {
                cbx_cs.DataSource = null;
            }
            else
            {
                Sqlstr = string.Format("SELECT djgcs FROM daojuguicengshu where djgmc = '{0}'", cbx_djgmc.SelectedValue.ToString());
                cbx_cs.DataSource = SQL.DataReadList(Sqlstr);
                cbx_cs.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            tishi = "";

            if(cbx_lbjmc.Text != "" || cbx_djgmc.Text != "" || cbx_cs.Text != "")
            {
                string conditions = string.Format("{0} LIKE '%{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%'", lbjbiao_lbjmc, cbx_lbjmc.Text.ToString(), lbjbiao_djgbm, cbx_djgmc.Text.ToString(), lbjbiao_jtwz, cbx_cs.Text.ToString());
                //加载库存明细
                Sqlstr = string.Format("SELECT {1} AS lbjmc, {2} AS lbjgg, {3} AS lbjxh, {4} AS djgbm, {5} AS jtwz, {6} AS kcsl, {7} AS dw FROM {0} WHERE {8}", lbjbiao, lbjbiao_lbjmc, lbjbiao_lbjgg, lbjbiao_lbjxh, lbjbiao_djgbm, lbjbiao_jtwz, lbjbiao_kcsl, lbjbiao_dw, conditions);
                DataTable db_search = SQL.getDataSet1(Sqlstr).Tables[0];

                //判断是否查询到数据
                if (db_search.Rows.Count > 0)
                {
                    kcmx.DataSource = db_search.DefaultView;
                    Sqlstr = "";
                }
                else
                {
                    tishi = "没有符合条件的数据，请修改查询条件后重试！";
                }
            }
            else
            {
                tishi = "请输出组合查询条件";
            }

            if (tishi != "")
            {
                MessageBox.Show(tishi);
                cbx_lbjmc.Focus();
            }
            
        }

        /// <summary>
        /// 点击库存明细加载操作记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kcmx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = kcmx.CurrentRow.Index;
            DataRow dr = ((kcmx.Rows[rowindex]).DataBoundItem as DataRowView).Row;//微软提供的唯一的从DataGridViewRow转换DataRow

            Sqlstr = string.Format("SELECT * FROM {0} WHERE lbjmc = '{1}' AND lbjxh = '{2}' AND djgbm = '{3}' AND jtwz = '{4}' ORDER BY czsj ASC", liushuibiao, dr["lbjmc"].ToString(), dr["lbjxh"].ToString(), dr["djgbm"].ToString(), dr["jtwz"].ToString());
            czjl.AutoGenerateColumns = false;
            czjl.DataSource = SQL.getDataSet(Sqlstr, liushuibiao).Tables[0].DefaultView;
        }

        private void lbjkcmx_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
