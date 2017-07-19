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

namespace kucunTest.DaoJu
{
    public partial class DJCCRC : Form
    {
        private MySql SQL = new MySql();
        private TreeNode node = new TreeNode();

        public DJCCRC()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void RCRQ_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DJCCRC_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add(node);
            node.Text = "所有类型";
            BindRoot();//生成树的第一层
            treeView1.Nodes[0].Expand();//默认展开第一层节点
        }

        private void BindRoot()
        {
            label5.Text = "正在加载……";
            label5.Visible = true;

            //把数据库中取出所有所在设备名称
            MySqlDataReader szsb = SQL.getcom("select distinct szsb from daoju order by szsb desc");
            //node.Nodes[0].Remove();//移除刚开始建立的第一个空节点
            while (szsb.Read())
            {
                if (szsb[0] == null)
                {
                    continue;
                }
                TreeNode t1 = new TreeNode();
                t1.Text = szsb[0].ToString();
                node.Nodes.Add(t1);
                t1.Nodes.Add("");//添加一个空的子节点，才会出现折叠+号
            }
            label5.Text = "加载完成！";
        }
        /// <summary>
        /// 生成树之构造子节点
        /// </summary>
        ///<param name="t1">为t1节点添加子节点</param>
        private void AddChild(TreeNode t1)
        {
            label5.Text = "正在加载……";
            label5.Visible = true;

            MySqlDataReader xinghao = SQL.getcom("select xinghao from daoju where szsb='" + t1.Text.ToString().Trim() + "'");
            while (xinghao.Read())
            {
                TreeNode t2 = new TreeNode();
                t2.Text = xinghao[0].ToString();
                t1.Nodes.Add(t2);
            }

            //更改进度条并隐藏
            label5.Text = "加载完成！";
        }

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
    }
}
