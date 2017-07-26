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
        string lbj = "lbj_temp";

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

            Sqlstr = string.Format("SELECT DISTINCT lbjmc FROM {0}", lbj);
            Alex.BindRoot(Sqlstr, root, true);
            root.Expand();

            asc.controllInitializeSize(this);
        }

        /// <summary>
        /// 在展开类型节点之前查询所有规格的子节点，按需查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "")
            {
                TreeNode currentNode = e.Node;
                currentNode.Nodes[0].Remove();
                Sqlstr = string.Format("SELECT lbjxh FROM {0} WHERE lbjmc = '{1}'", lbj, currentNode.Text);
                Alex.BindRoot(Sqlstr, currentNode, false);
            }
        }

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

        }


        #endregion 按钮部分结束

        
    }
}
