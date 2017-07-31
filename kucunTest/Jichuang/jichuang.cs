using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kucunTest.Jichuang
{
    public partial class jichuang : Form
    {
        public jichuang()
        {
            InitializeComponent();
        }

        #region 全局变量
        private MySql Sql = new MySql();//MySQL类
        private string SqlStr = "";
        private TreeNode node = new TreeNode();//类型树的根节点。
        #endregion

       
        #region BindeRoot()方法和AddChild()方法：构造类型（所有类型-->名称-->型号）树
        ///<summary>生成树之生成第一层名称节点</summary>
        private void BindRoot()
        {
            //treeView1.Nodes.Clear();//清空树节点
          
            MySqlDataReader scx = Sql.getcom("select distinct shengchanxian from jichuang");
            //node.Nodes[0].Remove();//移除刚开始建立的第一个空节点
            while (scx.Read())
            {
                TreeNode t1 = new TreeNode();
                t1.Text = scx[0].ToString();
                node.Nodes.Add(t1);
                AddChild(t1);
            }
      

        }

        private void AddChild(TreeNode t1)
        {

     
            MySqlDataReader jcbm = Sql.getcom("select jichuangbianma from jichuang where shengchanxian ='" + t1.Text.ToString().Trim() + "'");
            while (jcbm.Read())
            {
                TreeNode t2 = new TreeNode();
                t2.Text = jcbm[0].ToString();
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


        private void jichuang_Load(object sender, EventArgs e)
        {
           
            treeView1.Nodes.Add(node);
            node.Text = "所有生产线";
            BindRoot();//生成树的第一层
            treeView1.Nodes[0].Expand();//默认展开第一层节点

            jcdth.AutoGenerateColumns = false;
        }



        #region treeView1_AfterSelect()方法：根据选择的树节点进行库存明细查询
        /// <summary>
        /// 根据选择的树节点进行库存明细查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">当前节点</param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<string> list1 = new List<string>();
            if (treeView1.SelectedNode.Level == 2)//当前选中节点为第三层节点：机床编码
            {
                string str = "select shengchanxian,jichuangleixing from jichuang where jichuangbianma = '" + e.Node.Text.ToString() + "'";
                list1 = Sql.DataReadList2(str);
                ssscx.Text = list1[0];
                jclx.Text = list1[1];
                jcmc.Text = e.Node.Text.ToString();

                SqlStr = "SELECT djmx.daojuleixing,djmx.daojuid,djmx.daojuguige,jcdjk.jichuangbianma,jcdjk.daotaohao FROM jcdaojukun jcdjk LEFT JOIN daojulingyongmingxi djmx ON concat(djmx.jichuangbianma,'-', djmx.daotaohao ) = concat(jcdjk.jichuangbianma,'-', jcdjk.daotaohao ) where jcdjk.jichuangbianma =  '" + e.Node.Text.ToString() + "'";
                //SqlStr = "SELECT djtp.daojuleixing,djtp.daojuid,djtp.daojuguige,djtp.daojushouming,jcdjk.jichuangbianma,jcdjk.daotaohao FROM daojutemp djtp LEFT JOIN jcdaojukun jcdjk ON concat(djtp.weizhi,'-', djtp.cengshu ) = concat(jcdjk.jichuangbianma,'-', jcdjk.daotaohao ) where jcdjk.jichuangbianma =  '" + e.Node.Text.ToString() + "'";
                jcdth.DataSource = Sql.getDataSet1(SqlStr).Tables[0].DefaultView;
            }

            }
        #endregion

        private void xzjc_Click(object sender, EventArgs e)
        {
            xinzengjichuang jcxz = new xinzengjichuang();

            jcxz.ShowDialog();
            if(jcxz.DialogResult == DialogResult.OK)
            {
                jichuang_Load(null, null);
            }
        }
    }
}
