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

namespace kucunTest.Daojugui
{
    public partial class daojugui : Form
    {
        public daojugui()
        {
            InitializeComponent();
        }


        #region 全局变量
        private MySql Sql = new MySql();//MySQL类
        private string SqlStr = "";
        private string SqlStr1 = "";
        private string cengshu = "";
        private string cengshu2 = "";
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        private TreeNode node = new TreeNode();//类型树的根节点。
        int i;
        #endregion

        private void xzdjg_Click(object sender, EventArgs e)
        {
            XZDJG xzd = new XZDJG();
            xzd.Show();
        }

        #region BindeRoot()方法和AddChild()方法：构造类型（所有类型-->名称-->型号）树
        ///<summary>生成树之生成第一层名称节点</summary>
        private void BindRoot()
        {

            //把数据库中取出所有零部件名称
            MySqlDataReader djgmc = Sql.getcom("select distinct djgmc from daojugui");
            //node.Nodes[0].Remove();//移除刚开始建立的第一个空节点
            while (djgmc.Read())
            {
                TreeNode t1 = new TreeNode();
                t1.Text = djgmc[0].ToString();
                node.Nodes.Add(t1);
                AddChild(t1);
            }
        }

         private void AddChild(TreeNode t1)
        {


        MySqlDataReader djgcs = Sql.getcom("select djgcs from daojuguicengshu where djgmc ='" + t1.Text.ToString().Trim() + "'");
        while (djgcs.Read())
         {
         TreeNode t2 = new TreeNode();
         t2.Text = djgcs[0].ToString();
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
        
        private void daojugui_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add(node);
            node.Text = "刀具柜";
            BindRoot();//生成树的第一层
            treeView1.Nodes[0].Expand();//默认展开第一层节点

            kcmx.AutoGenerateColumns = false;
           
        }

       #region treeView1_AfterSelect()方法：根据选择的树节点进行查询
            /// <summary>
            /// 根据选择的树节点进行库存明细查询
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e">当前节点</param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            string where = "where weizhibiaoshi = 'S'";//SQL语句条件。默认为空，即第一层节点：所有类型
            string where1 = "where weizhibiaoshi = 'S'";
            
            List<string> list1 = new List<string>();
            if (treeView1.SelectedNode.Level == 1)//当前选中节点为第二层节点：
            {
                djgmmc.Text = e.Node.Text.ToString();
                where = "where weizhi = '" + e.Node.Text.ToString() + "' and weizhibiaoshi = 'S'";
                where1 = "where weizhi = '" + e.Node.Text.ToString() + "' and weizhibiaoshi = 'S'";
                SqlStr = "SELECT djgbm,djglx FROM  daojugui where djgmc = '" + e.Node.Text.ToString() +  "'";
                string str = "select COUNT(*) from daojuguicengshu where djgmc = '" + e.Node.Text.ToString() + "'";
                string str1 = "select COUNT(*) from daojutemp where weizhi = '" + e.Node.Text.ToString() + "'";
                string str2 = "select COUNT(*) from jichuxinxi where weizhi = '" + e.Node.Text.ToString() + "'";
                list1 = Sql.DataReadList2(SqlStr);
                djgbm.Text = list1[0];
                djglx.Text = list1[1];
                Object a = Sql.ExecuteScalar(str);
                Object b = Sql.ExecuteScalar(str1);
                Object c = Sql.ExecuteScalar(str2);
                string x = a.ToString();
                string y = b.ToString();
                string z = c.ToString();
                djgccs.Text = x;
                djsl.Text = y;
                lbjsl.Text = z;

                //string sqlstr = "select djgcs from daojuguicengshu where djgmc = '" + e.Node.Text.ToString() + "'";
                //cscx.DataSource = Sql.DataReadList(sqlstr);

                cengshu = "";
                cengshu2 = "";
                lxcx.SelectedIndex = 0;

            }
            if (treeView1.SelectedNode.Level == 2)//当前选中节点为第三层节点：层数
            {
                cengshu = e.Node.Text.ToString();
                cengshu2 = cengshu.Substring(1);
                where = "where cengshu = '" + e.Node.Text.ToString() + "' and weizhibiaoshi = 'S' and weizhi = '" + djgmmc.Text.ToString() + "'";
                where1 = "where cengshu = '" + e.Node.Text.ToString() + "' and weizhibiaoshi = 'S' and weizhi = '" + djgmmc.Text.ToString() + "'";

                lxcx.SelectedIndex = 0;
            }
             //SqlStr = "SELECT * FROM  daojutemp " + where;
             SqlStr = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM daojutemp  " + where;
             SqlStr1 = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM jichuxinxi " + where1;
             ds1 = Sql.getDataSet1(SqlStr);
             ds2 = Sql.getDataSet1(SqlStr1);
             ds1.Merge(ds2, true);
             kcmx.DataSource = ds1.Tables[0].DefaultView;

            for (i = 0; i < kcmx.Rows.Count - 1; i++)
            {
                // this.daojuxinxi.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                string sl = kcmx.Rows[i].Cells["Column5"].Value.ToString();
                string zxsl = kcmx.Rows[i].Cells["Column6"].Value.ToString();
                int shuliang = int.Parse(sl);
                int zxshuliang = int.Parse(zxsl);
                if (shuliang < zxshuliang)
                {
                    //this.daojuxinxi.Columns[3].DefaultCellStyle.BackColor = Color.Red;
                    kcmx.Rows[i].Cells["Column5"].Style.BackColor = Color.Red;

                }

            }

        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cscx_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //按刀具/零部件进行查询
        private void lxcx_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lxcxqb = "全部";
            string lxcxdj = "刀具";
            string lxcxlbj = "零部件";
            string cengshu1 = "层";
           

            if(cengshu1 != cengshu2)
            {
                if (lxcx.Text == lxcxqb)
                {
                    SqlStr = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM daojutemp  where weizhi = '" + djgmmc.Text.ToString() + "' and weizhibiaoshi = 'S'";
                    SqlStr1 = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM jichuxinxi  where weizhi = '" + djgmmc.Text.ToString() + "' and weizhibiaoshi = 'S'";
                    ds1 = Sql.getDataSet1(SqlStr);
                    ds2 = Sql.getDataSet1(SqlStr1);
                    ds1.Merge(ds2, true);
                    kcmx.DataSource = ds1.Tables[0].DefaultView;

                    for (i = 0; i < kcmx.Rows.Count - 1; i++)
                    {
                        // this.daojuxinxi.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        string sl = kcmx.Rows[i].Cells["Column5"].Value.ToString();
                        string zxsl = kcmx.Rows[i].Cells["Column6"].Value.ToString();
                        int shuliang = int.Parse(sl);
                        int zxshuliang = int.Parse(zxsl);
                        if (shuliang < zxshuliang)
                        {
                            //this.daojuxinxi.Columns[3].DefaultCellStyle.BackColor = Color.Red;
                            kcmx.Rows[i].Cells["Column5"].Style.BackColor = Color.Red;

                        }

                    }
                }
                if (lxcx.Text == lxcxdj)
                {
                    SqlStr = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM daojutemp  where weizhi = '" + djgmmc.Text.ToString() + "' and weizhibiaoshi = 'S'";
                    kcmx.DataSource = Sql.getDataSet1(SqlStr).Tables[0].DefaultView;

                    for (i = 0; i < kcmx.Rows.Count - 1; i++)
                    {
                        // this.daojuxinxi.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        string sl = kcmx.Rows[i].Cells["Column5"].Value.ToString();
                        string zxsl = kcmx.Rows[i].Cells["Column6"].Value.ToString();
                        int shuliang = int.Parse(sl);
                        int zxshuliang = int.Parse(zxsl);
                        if (shuliang < zxshuliang)
                        {
                            //this.daojuxinxi.Columns[3].DefaultCellStyle.BackColor = Color.Red;
                            kcmx.Rows[i].Cells["Column5"].Style.BackColor = Color.Red;

                        }

                    }
                }
                if (lxcx.Text == lxcxlbj)
                {
                    SqlStr = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM jichuxinxi  where weizhi = '" + djgmmc.Text.ToString() + "' and weizhibiaoshi = 'S'";
                    kcmx.DataSource = Sql.getDataSet1(SqlStr).Tables[0].DefaultView;

                    for (i = 0; i < kcmx.Rows.Count - 1; i++)
                    {
                        // this.daojuxinxi.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        string sl = kcmx.Rows[i].Cells["Column5"].Value.ToString();
                        string zxsl = kcmx.Rows[i].Cells["Column6"].Value.ToString();
                        int shuliang = int.Parse(sl);
                        int zxshuliang = int.Parse(zxsl);
                        if (shuliang < zxshuliang)
                        {
                            //this.daojuxinxi.Columns[3].DefaultCellStyle.BackColor = Color.Red;
                            kcmx.Rows[i].Cells["Column5"].Style.BackColor = Color.Red;

                        }

                    }
                }
            }else
            {
                if (lxcx.Text == lxcxqb)
                {
                    SqlStr = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM daojutemp  where weizhi = '" + djgmmc.Text.ToString() + "' and weizhibiaoshi = 'S' and cengshu = '" + cengshu.ToString() + "'";
                    SqlStr1 = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM jichuxinxi  where weizhi = '" + djgmmc.Text.ToString() + "' and weizhibiaoshi = 'S' and cengshu = '" + cengshu.ToString() + "'";
                    ds1 = Sql.getDataSet1(SqlStr);
                    ds2 = Sql.getDataSet1(SqlStr1);
                    ds1.Merge(ds2, true);
                    kcmx.DataSource = ds1.Tables[0].DefaultView;
                    
                    for (i = 0; i < kcmx.Rows.Count - 1; i++)
                    {
                      // this.daojuxinxi.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                      string sl = kcmx.Rows[i].Cells["Column5"].Value.ToString();
                      string zxsl = kcmx.Rows[i].Cells["Column6"].Value.ToString();
                      int shuliang = int.Parse(sl);
                      int zxshuliang = int.Parse(zxsl);
                     if (shuliang < zxshuliang)
                      {
                       //this.daojuxinxi.Columns[3].DefaultCellStyle.BackColor = Color.Red;
                        kcmx.Rows[i].Cells["Column5"].Style.BackColor = Color.Red;

                      }

                     }
                }
                if (lxcx.Text == lxcxdj)
                {
                    SqlStr = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM daojutemp  where weizhi = '" + djgmmc.Text.ToString() + "' and weizhibiaoshi = 'S' and cengshu = '" + cengshu.ToString() + "'";
                    kcmx.DataSource = Sql.getDataSet1(SqlStr).Tables[0].DefaultView;
                    for (i = 0; i < kcmx.Rows.Count - 1; i++)
                    {
                        // this.daojuxinxi.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        string sl = kcmx.Rows[i].Cells["Column5"].Value.ToString();
                        string zxsl = kcmx.Rows[i].Cells["Column6"].Value.ToString();
                        int shuliang = int.Parse(sl);
                        int zxshuliang = int.Parse(zxsl);
                        if (shuliang < zxshuliang)
                        {
                            //this.daojuxinxi.Columns[3].DefaultCellStyle.BackColor = Color.Red;
                            kcmx.Rows[i].Cells["Column5"].Style.BackColor = Color.Red;

                        }

                    }
                }
                if (lxcx.Text == lxcxlbj)
                {
                    SqlStr = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM jichuxinxi  where weizhi = '" + djgmmc.Text.ToString() + "' and weizhibiaoshi = 'S' and cengshu = '" + cengshu.ToString() + "'";
                    kcmx.DataSource = Sql.getDataSet1(SqlStr).Tables[0].DefaultView;
                    for (i = 0; i < kcmx.Rows.Count - 1; i++)
                    {
                        // this.daojuxinxi.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        string sl = kcmx.Rows[i].Cells["Column5"].Value.ToString();
                        string zxsl = kcmx.Rows[i].Cells["Column6"].Value.ToString();
                        int shuliang = int.Parse(sl);
                        int zxshuliang = int.Parse(zxsl);
                        if (shuliang < zxshuliang)
                        {
                            //this.daojuxinxi.Columns[3].DefaultCellStyle.BackColor = Color.Red;
                            kcmx.Rows[i].Cells["Column5"].Style.BackColor = Color.Red;

                        }

                    }
                }
            }


        
        }
    }
}
