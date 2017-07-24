using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using kucunTest.BaseClasses;

namespace kucunTest.LingBuJian
{
    public partial class lbj_xzlymx : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        String Sqlstr = "";

        TreeNode root = new TreeNode();
        string lbj = "lbj_temp";

        BaseAlex Alex = new BaseAlex();

        #endregion

        public lbj_xzlymx()
        {
            InitializeComponent();
        }

        private void lbj_xzlymx_Load(object sender, EventArgs e)
        {
            root.Text = "所有类型";
            treeView1.Nodes.Add(root);

            Sqlstr = string.Format("SELECT DISTINCT lbjmc FROM {0}", lbj);
            Alex.BindRoot(Sqlstr, root, true);
            root.Expand();

        }

        /// <summary>
        /// 在展开类型节点之前查询所有规格的子节点，按需查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "")
            {
                TreeNode currentNode = e.Node;
                currentNode.Nodes[0].Remove();
                Sqlstr = string.Format("SELECT lbjxh FROM {0} WHERE lbjmc = '{1}'", lbj, currentNode.Text);
                Alex.BindRoot(Sqlstr, currentNode, false);
            }
        }

        /// <summary>
        /// 选中具体规格，填充到右方文本框中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Level == 2)//当前选中节点为第二层节点：刀具规格
            {
                lbjmc.Text = e.Node.Parent.Text;
                lbjxh.Text = e.Node.Text;

                Sqlstr = string.Format("SELECT * FROM {0} WHERE lbjmc = '{1}' AND lbjxh = '{2}'", lbj, e.Node.Parent.Text.ToString(), e.Node.Text.ToString());
                DataSet ds = SQL.getDataSet(Sqlstr, lbj);

                lbjgg.Text = ds.Tables[0].Rows[0]["lbjgg"].ToString();
                dw.Text = ds.Tables[0].Rows[0]["dw"].ToString();
            }
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckData() == 0)
            {
                return;
            }
            else
            {
                List<string> list = new List<string>();
                list.Add(lbjmc.Text.ToString().Trim());//list[0] 零部件名称
                list.Add(lbjgg.Text.ToString().Trim());//list[1] 零部件规格
                list.Add(lbjxh.Text.ToString().Trim());//list[2] 零部件型号
                list.Add(sl.Text.ToString().Trim());//list[3] 数量
                list.Add(dw.Text.ToString().Trim());//list[3] 单位
                list.Add(jcbm.Text.ToString().Trim());//list[4] 机床编码
                list.Add(gx.Text.ToString().Trim());//list[5] 工序
                list.Add(bz.Text.ToString().Trim());//list[6] 备注

                LBJLY ly = new LBJLY();
                ly = (LBJLY)this.Owner;
                ly.AddData(list);

                //this.Close();
            }
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        private int CheckData()
        {
            string tishi = "";
            if (lbjmc.Text.ToString() == "" || lbjxh.Text.ToString() == "")
            {
                tishi = "请将零部件信息填写完整！";
            }
            else if (jcbm.Text.ToString() == "" || gx.Text.ToString() == "")
            {
                tishi = "请将使用信息填写完整！";
            }

            if (tishi != "")
            {
                MessageBox.Show(tishi, "警告", MessageBoxButtons.OK);
                return 0;
            }
            else
                return 1;
        }
    }
}
