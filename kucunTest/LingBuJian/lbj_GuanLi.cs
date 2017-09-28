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
    public partial class lbj_GuanLi : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        String Sqlstr = "";

        TreeNode root = new TreeNode();
        string lbj = "jichuxinxi";

        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();

        #endregion

        public lbj_GuanLi()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbj_GuanLi_Load(object sender, EventArgs e)
        {
            root.Text = "所有类型";
            treeView1.Nodes.Add(root);

            Sqlstr = string.Format("SELECT DISTINCT daojuid FROM {0}", lbj);
            Alex.BindRoot(Sqlstr, root, true);
            treeView1.Nodes[0].Expand();

            asc.controllInitializeSize(this);
            lbjxinxi.AutoGenerateColumns = false;


            string sqlstr1 = "select djgmc from daojugui";
            djg.DataSource = SQL.DataReadList(sqlstr1);
            djg.SelectedIndex = -1;

            string sqlstr2 = "select jichuangbianma from jichuang";
            jichuang.DataSource = SQL.DataReadList(sqlstr2);
            jichuang.SelectedIndex = -1;
        }

        /// <summary>
        /// 在展开类型节点之前查询所有规格的子节点，按需查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if(e.Node.Level == 1)
            {
                if (e.Node.Nodes[0].Text == "")
                {
                    TreeNode currentNode = e.Node;
                    currentNode.Nodes[0].Remove();
                    Sqlstr = string.Format("SELECT daojuxinghao FROM {0} WHERE daojuid = '{1}'", lbj, currentNode.Text);
                    Alex.BindRoot(Sqlstr, currentNode, false);
                }
            }            
        }

        #region treeView1_AfterSelect()方法：根据选择的树节点进行查询
        /// <summary>
        /// 根据选择的树节点进行库存明细查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">当前节点</param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string where = "";//SQL语句条件。默认为空，即第一层节点：所有类型
            if (treeView1.SelectedNode.Level == 1)//当前选中节点为第二层节点：刀具类型
            {
                where = "where daojuid = '" + e.Node.Text.ToString() + "'";
                
            }
            Sqlstr = "SELECT daojuid,daojuxinghao,daojuguige,daojuleixing,CONCAT(weizhi,'--', cengshu) AS daojuweizhi,kcsl from jichuxinxi " + where;
            lbjxinxi.DataSource = SQL.getDataSet1(Sqlstr).Tables[0].DefaultView;
            
        }
        #endregion

        #region 按钮部分
        /// <summary>
        /// 零部件领用按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_lbjly_Click(object sender, EventArgs e)
        {
            lbj_History lbjly = new lbj_History("LBJLY");
            lbjly.Show();
        }

        /// <summary>
        /// 零部件退还按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_lbjth_Click(object sender, EventArgs e)
        {
            lbj_History lbjth = new lbj_History("LBJTH");
            lbjth.Show();
        }

        /// <summary>
        /// 新增零部件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xzlbj_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 库存盘点按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_kcpd_Click(object sender, EventArgs e)
        {
            lbjkcmx lbjkc = new lbjkcmx();
            lbjkc.Show();
        }





        #endregion 按钮部分结束

        private void djg_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
        }

        private void jichuang_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
