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

namespace kucunTest.DaoJu
{
    public partial class DaoJuLeiXingGuanLi : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        String Sqlstr = "";

        TreeNode root = new TreeNode();
        string lbj = "lbj_temp";

        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();

        string TYPE = "";

        string DaoJuBiao = "daojutemp";

        #endregion

        public DaoJuLeiXingGuanLi()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DaoJuLeiXingGuanLi_Load(object sender, EventArgs e)
        {
            root.Text = "所有类型";
            treeView1.Nodes.Add(root);

            Sqlstr = string.Format("SELECT DISTINCT daojuleixing FROM {0}", DaoJuBiao);
            Alex.BindRoot(Sqlstr, root, true);

            treeView1.Nodes[0].Expand();

            asc.controllInitializeSize(this);
        }

        /// <summary>
        /// 在展开类型节点之前查询所有规格的子节点，按需查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if(e.Node.Level == 1)
            {
                if (e.Node.Nodes[0].Text == "")
                {
                    TreeNode currentNode = e.Node;
                    currentNode.Nodes[0].Remove();
                    Sqlstr = string.Format("SELECT daojuxinghao FROM {0} WHERE daojuleixing = '{1}'", DaoJuBiao, currentNode.Text);
                    Alex.BindRoot(Sqlstr, currentNode, false);
                }
            }
            //else
            //{
            //    return;
            //}
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Level == 2)
            {
                //加载刀具基础信息
                Sqlstr = string.Format("SELECT daojuleixing, daojuguige, daojuxinghao FROM {0} WHERE daojuxinghao = '{1}'", DaoJuBiao, e.Node.Text);
                DataTable db1 = SQL.getDataSet(Sqlstr, DaoJuBiao).Tables[0];



            }
        }
    }
}
