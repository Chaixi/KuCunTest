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

using kucunTest.BaseClasses;

namespace kucunTest.gongyika
{
    public partial class gyk : Form
    {
        public gyk()
        {
            InitializeComponent();
        }

        #region 全局变量
        private MySql Sql = new MySql();//MySQL类
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private string SqlStr = "";
        private TreeNode node = new TreeNode();//类型树的根节点。
        #endregion

        private void gyk_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);

            treeView1.Nodes.Add(node);
            node.Text = "工艺卡编号";
            BindRoot();//生成树的第一层
            treeView1.Nodes[0].Expand();//默认展开第一层节点

            gxxx.AutoGenerateColumns = false;
            pdxx.AutoGenerateColumns = false;
        }

        #region BindeRoot()方法和AddChild()方法：构造类型（所有类型-->名称-->型号）树
        ///<summary>生成树之生成第一层名称节点</summary>
        private void BindRoot()
        {
            //treeView1.Nodes.Clear();//清空树节点

            MySqlDataReader scx = Sql.getcom("select distinct gykbh from gongyika");
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
            MySqlDataReader jcbm = Sql.getcom("select gxh from gongxu where gykbh ='" + t1.Text.ToString().Trim() + "'");
            while (jcbm.Read())
            {
                TreeNode t2 = new TreeNode();
                t2.Text = jcbm[0].ToString();
                t1.Nodes.Add(t2);
            }

        }



        #endregion

        #region treeView1_AfterSelect()方法：根据选择的树节点进行库存明细查询
        /// <summary>
        /// 根据选择的树节点进行库存明细查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">当前节点</param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<string> list1 = new List<string>();
            if (treeView1.SelectedNode.Level == 1)//当前选中节点为第三层节点：机床编码
            {
               
                gykbh.Text = e.Node.Text.ToString();

                SqlStr = "select * from gongxu where gykbh =  '" + e.Node.Text.ToString() + "'";
                string SqlStr1 = "select * from gongxupeidao where gykbh =  '" + e.Node.Text.ToString() + "'";
                gxxx.DataSource = Sql.getDataSet1(SqlStr).Tables[0].DefaultView;
                pdxx.DataSource = Sql.getDataSet1(SqlStr1).Tables[0].DefaultView;

                string gxstr = "select jglx,scgl,fbsj from gongyika where gykbh =  '" + e.Node.Text.ToString() + "'";
                list1 = Sql.DataReadList3(gxstr);
                jglx.Text = list1[0];
                scgl.Text = list1[1];
                fbsj.Text = list1[2];

            }
            if (treeView1.SelectedNode.Level == 2)//当前选中节点为第三层节点：机床编码
            {


                SqlStr = "select * from gongxu where gykbh =  '" + gykbh.Text.ToString() + "' and gxh = '" + e.Node.Text.ToString() + "'";
                string SqlStr1 = "select * from gongxupeidao where gykbh =  '" + gykbh.Text.ToString() + "' and gxh = '" + e.Node.Text.ToString() + "'";
                gxxx.DataSource = Sql.getDataSet1(SqlStr).Tables[0].DefaultView;
                pdxx.DataSource = Sql.getDataSet1(SqlStr1).Tables[0].DefaultView;

            }
        }
        #endregion

        /// <summary>
        /// 当窗体在选项卡中打开时，关闭窗体则关闭相应的选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gyk_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Parent != null)
            {
                MainForm mfr = (MainForm)this.Parent.FindForm();
                mfr.CloseTab(this.Name);
            }
        }

        private void gyk_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
