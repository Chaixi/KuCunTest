using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace kucunTest.CaiGou
{
    public partial class CGXQ : Form
    {
        #region 全局变量
        private MySql SelectSql = new MySql();//MySQL类
        private TreeNode node = new TreeNode();//类型树的根节点。
        #endregion

        public CGXQ()
        {
            InitializeComponent();
        }

        private void CGXQ_Load(object sender, EventArgs e)
        {
            TCRQ.Value = System.DateTime.Now;

            //添加并设置根节点           
            treeView1.Nodes.Add(node);
            node.Text = "所有类型";
            BindRoot();//生成树的第一层
            treeView1.Nodes[0].Expand();//默认展开第一层节点
        }

        #region BindeRoot()方法和AddChild()方法：构造类型（所有类型-->名称-->型号）树
        ///<summary>生成树之生成第一层名称节点</summary>
        private void BindRoot()
        {
            MySqlDataReader mc = SelectSql.getcom("select distinct mc from lingbujian");
            while (mc.Read())
            {
                TreeNode t1 = new TreeNode();
                t1.Text = mc[0].ToString();
                node.Nodes.Add(t1);
                t1.Nodes.Add("");
            }
        }

        /// <summary>
        /// 生成树之构造子节点
        /// </summary>
        ///<param name="t1">为t1节点添加子节点</param>
        private void AddChild(TreeNode t1)
        {
            MySqlDataReader xh = SelectSql.getcom("select xinghao from lingbujian where mc='" + t1.Text.ToString().Trim() + "'");
            while (xh.Read())
            {
                TreeNode t2 = new TreeNode();
                t2.Text = xh[0].ToString();
                t1.Nodes.Add(t2);
            }
        }
        #endregion

        #region treeView1_BeforeExpand()方法：按需展开节点查询并创建子节点
        /// <summary>
        /// 按需展开节点查询并创建子节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //判断第一个子节点是否为空，若为空代表还未生成则生成子节点，否则避免重复执行代码
            if (e.Node.Nodes[0].Text == "")
            {
                TreeNode currentNode = e.Node;
                currentNode.Nodes[0].Remove();
                AddChild(currentNode);
            }
            else
                return;
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
