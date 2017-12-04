using kucunTest.BaseClasses;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kucunTest.quanxianguanli
{
    public partial class qxguanli : Form
    {

        #region 全局变量
        private MySql Sql = new MySql();//MySQL类
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private string SqlStr = "";
        private string xzyhstr = "";
        private string xzyhstr1 = "";
        private string groupqx = "";
        private string groupqx1 = "";
        private int nodenum;
        private int nodenum1;
        private int nodenum2;
        private TreeNode node = new TreeNode();//类型树的根节点。
        private TreeNode node1 = new TreeNode();//类型树的根节点。
        private TreeNode node2 = new TreeNode();//类型树的根节点。
        private TreeNode node3 = new TreeNode();//类型树的根节点。
        private TreeNode node4 = new TreeNode();//类型树的根节点。
        private TreeNode node5 = new TreeNode();//类型树的根节点。
        List<string> list1 = new List<string>();
        List<string> list = new List<string>();
        #endregion

        public qxguanli()
        {
            InitializeComponent();
        }
                
        private void qxguanli_Load(object sender, EventArgs e)
        {
            node.Nodes.Clear();
            node.Remove();
            treeView1.Nodes.Add(node);
            node.Text = "全部用户";
            BindRoot();//生成树的第一层
            treeView1.Nodes[0].Expand();//默认展开第一层节点

            node1.Nodes.Clear();
            node1.Remove();
            treeView4.Nodes.Add(node1);
            node1.Text = "全部小组";
            BindRoot1();//生成树的第一层
            treeView4.Nodes[0].Expand();//默认展开第一层节点

            node5.Nodes.Clear();
            node5.Remove();
            treeView_quanxian.Nodes.Add(node5);
            node5.Text = "全部选择";
            BindRoot5();//生成树的第一层
            treeView_quanxian.Nodes[0].Expand();//默认展开第一层节点    


            //禁用修改密码按钮
            btn_xgmm.Enabled = false;
            btn_qrxg.Enabled = false;
            btn_bcxx.Enabled = false;
            bnt_czmm.Enabled = false;
            button2.Enabled = false;
            //隐藏密码框，用于显示密码
            ycysmm.Visible = false;
            ycxmm.Visible = false;
            ycqrxmm.Visible = false;


            //小组管理界面禁用
            treeView_quanxian.Nodes[0].Expand();

            asc.controllInitializeSize(this);

        }


        #region BindeRoot()方法和AddChild()方法：构造类型（所有类型-->名称-->型号）树
        ///<summary>生成树之生成第一层名称节点</summary>
        private void BindRoot()
        {
            MySqlDataReader scx = Sql.getcom("select name from user order by xh");
            while (scx.Read())
            {
                TreeNode t1 = new TreeNode();
                t1.Text = scx[0].ToString();
                node.Nodes.Add(t1);
                //AddChild(t1);
            }


        }
        
        #endregion

      
        #region BindeRoot1()方法和AddChild()方法：构造类型（所有类型-->名称-->型号）树
        ///<summary>生成树之生成第一层名称节点</summary>
        private void BindRoot1()
        {
            MySqlDataReader scx1 = Sql.getcom("select groupname from groupbiao order by xh");
            while (scx1.Read())
            {
                TreeNode t2 = new TreeNode();
                t2.Text = scx1[0].ToString();
                node1.Nodes.Add(t2);
                //AddChild(t1);
            }

        }


        #endregion


        #region BindeRoot2()方法和AddChild()方法：构造类型（所有类型-->名称-->型号）树
        ///<summary>生成树之生成第一层名称节点</summary>
        private void BindRoot2()
        {
            MySqlDataReader scx2 = Sql.getcom("select name from user order by xh ASC");
            while (scx2.Read())
            {
                TreeNode t2 = new TreeNode();
                t2.Text = scx2[0].ToString();
                node2.Nodes.Add(t2);
            }
        }
        #endregion

        #region treeView1_AfterSelect()方法：根据选择的树节点进行用户信息查询
        /// <summary>
        /// 根据选择的树节点进行库存明细查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">当前节点</param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<string> list1 = new List<string>();
            if (treeView1.SelectedNode.Level == 1)
            {
                string str = "select xh,xingming,type,bumen,beizhu,pwd, groupname from user where name = '" + e.Node.Text.ToString() + "'";
                MySqlDataReader My_read = Sql.getcom(str);  
                while (My_read.Read())
                {
                    list1.Add(My_read[0].ToString());
                    list1.Add(My_read[1].ToString());
                    list1.Add(My_read[2].ToString());
                    list1.Add(My_read[3].ToString());
                    list1.Add(My_read[4].ToString());
                    list1.Add(My_read[5].ToString());
                    list1.Add(My_read[6].ToString());
                }
                xh.Text = list1[0];
                yhm.Text = e.Node.Text.ToString();
                yhxm.Text = list1[1];
                ssjs.Text = list1[2];
                ssbm.Text = list1[3];
                beizhu.Text = list1[4];
                pwd.Text = list1[5];
                ssxiaozu.Text = list1[6];

                //切换用户时重新禁止编辑
                yhm.ReadOnly = true;
                yhxm.ReadOnly = true;
                ssjs.ReadOnly = true;
                ssbm.ReadOnly = true;
                beizhu.ReadOnly = true;

                xsmm.Enabled = false;
                ysmm.ReadOnly = true;
                xmm.ReadOnly = true;
                qrxmm.ReadOnly = true;
                btn_xgmm.Enabled = false;
                btn_qrxg.Enabled = false;
                btn_bcxx.Enabled = false;
                bnt_czmm.Enabled = false;
                button2.Enabled = false;
                ysmm.Text = "";
                xmm.Text = "";
                qrxmm.Text = "";
                ycysmm.Text = "";
                ycxmm.Text = "";
                ycqrxmm.Text = "";
                xsmm.Checked = false;

            }
              
        }
        #endregion


        #region 用户管理界面按钮操作
        //编辑用户按钮
        private void btn_bjyh_Click(object sender, EventArgs e)
        {
            if (yhm.Text == "" || yhm.Text == null)
            {
                MessageBox.Show("请选择一个用户进行编辑！", "消息");
            }
            else
            {
                btn_xgmm.Enabled = true;
                btn_qrxg.Enabled = true;
                btn_bcxx.Enabled = true;
                bnt_czmm.Enabled = true;
                button2.Enabled = true;
                yhm.ReadOnly = false;
                yhxm.ReadOnly = false;
                ssjs.ReadOnly = false;
                ssbm.ReadOnly = false;
                beizhu.ReadOnly = false;
            }
        }

        //删除用户
        private void button2_Click(object sender, EventArgs e)
        {
            if (yhm.Text == "" || yhm.Text == null)
            {
                MessageBox.Show("请选择一个需要删除的用户！", "消息");
            }
            else
            {
                if(MessageBox.Show("确定删除'"+ yhm.Text + "'用户？", "消息", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    int i = 0;
                    SqlStr = "delete from user where name = '" + yhm.Text + "'";
                    string str = "delete from usergroup where name = '" + yhm.Text + "'";
                    Sql.ExecuteNonQuery(str);
                    i = Sql.ExecuteNonQuery(SqlStr);
                    if(i != 0)
                    {
                        if(MessageBox.Show("删除用户完成！", "提示", MessageBoxButtons.OK) ==  DialogResult.OK)
                            {
                                yhm.Text = "";
                                yhxm.Text = "";
                                ssjs.Text = "";
                                ssbm.Text = "";
                                beizhu.Text = "";
                                yhm.ReadOnly = true;
                                yhxm.ReadOnly = true;
                                ssjs.ReadOnly = true;
                                ssbm.ReadOnly = true;
                                beizhu.ReadOnly = true;
                                qxguanli_Load(null, null);
                            }
                    }


                }
            }
        }

        //修改密码
        private void btn_xgmm_Click(object sender, EventArgs e)
        {
             ysmm.ReadOnly = false;
             xmm.ReadOnly = false;
             qrxmm.ReadOnly = false;
             xsmm.Enabled = true;
             //MessageBox.Show("修改'" + yhm.Text + "'用户密码成功！", "消息");
          
        }

        //确认修改密码
        private void btn_czmm_Click(object sender, EventArgs e)
        {
            int row = 0;
            if (ysmm.Text == "" || xmm.Text == "" || qrxmm.Text == "")
            {
                MessageBox.Show("密码不能为空！", "消息");
                return;
            }
            if(xmm.Text == ysmm.Text )
            {
                MessageBox.Show("新密码不能与原密码相同！", "消息");
                return;
            }
            if(xmm.Text != qrxmm.Text)
            {
                MessageBox.Show("新密码和确认密码不一样!", "消息");
                return;
            }
            if(xmm.Text.Length < 6 || qrxmm.Text.Length < 6 )
            {
                MessageBox.Show("输入的新密码应为6到10位数!", "消息");
                return;
            }
            if(ysmm.Text != pwd.Text)
            {
                MessageBox.Show("原密码错误！");
                return;
            }
            else
            {
                SqlStr = "update user set pwd = '" + xmm.Text + "' where xh = '" + xh.Text + "'";
                row = Sql.ExecuteNonQuery(SqlStr);
            }

            if (row != 0)
            {
                MessageBox.Show("修改'"+ yhm.Text +"'用户密码成功！", "提示", MessageBoxButtons.OK);

            }


        }

        //显示密码
        private void xsmm_CheckedChanged(object sender, EventArgs e)
        {
            if (ycysmm.Visible)
            {
                ysmm.Text = ycysmm.Text;
            }
            else
            {
                ycysmm.Text = ysmm.Text;
            }

            if (ycxmm.Visible)
            {
                xmm.Text = ycxmm.Text;
            }
            else
            {
                ycxmm.Text = xmm.Text;
            }

            if (ycqrxmm.Visible)
            {
                qrxmm.Text = ycqrxmm.Text;
            }
            else
            {
                ycqrxmm.Text = qrxmm.Text;
            }
            ycysmm.Visible = xsmm.Checked;
            ycxmm.Visible = xsmm.Checked;
            ycqrxmm.Visible = xsmm.Checked;
        }

        //添加用户
        private void button1_Click(object sender, EventArgs e)
        {
            xzyh tjyh = new xzyh();
            tjyh.ShowDialog();
            if (tjyh.DialogResult == DialogResult.OK)
            {
                qxguanli_Load(null, null);
            }
  

        }


        //保存编辑信息
        private void btn_bcxx_Click(object sender, EventArgs e)
        {
            int j = 0;
            if(yhm.Text == "" || yhxm.Text == "" || ssbm.Text == "" || ssjs.Text == "")
            {
                MessageBox.Show("请填写完整的用户信息！", "消息");
                return;
            }
            SqlStr = "update `user` set name = '" + yhm.Text + "',xingming = '" + yhxm.Text + "',type = '" + ssjs.Text + "',bumen = '" + ssbm.Text + "',beizhu = '"+ beizhu.Text+"' where xh = '"+ xh.Text +"'";
            j = Sql.ExecuteNonQuery(SqlStr);
            if (j != 0)
            {
                MessageBox.Show("保存用户信息成功！", "提示", MessageBoxButtons.OK);

            }
        }

        //重置密码
        private void bnt_czmm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定重置'" + yhm.Text + "'用户的密码？", "消息", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                int ii = 0;
                SqlStr = "update user set pwd = '123456' where xh = '" + xh.Text + "'";
                ii = Sql.ExecuteNonQuery(SqlStr);
                if (ii != 0)
                {
                    MessageBox.Show("重置密码成功！", "提示", MessageBoxButtons.OK);

                }


            }
        }
        
        #endregion


        #region 小组管理界面按钮操作
        //新建小组按钮
        private void btn_xjxz_Click(object sender, EventArgs e)
        {
            xjxz tjxz = new xjxz();
            tjxz.ShowDialog();
            if (tjxz.DialogResult == DialogResult.OK)
            {
                qxguanli_Load(null, null);
            }
        }

        //删除小组按钮
        private void btn_scxz_Click(object sender, EventArgs e)
        {
            if (xiaozuming.Text == "" || xiaozuming.Text == null)
            {
                MessageBox.Show("请选择一个需要删除的小组！", "消息");
            }
            else
            {
                if (MessageBox.Show("确定删除'" + xiaozuming.Text + "'小组？", "消息", MessageBoxButtons.YesNo) != DialogResult.No)
                {
                    int i = 0;
                    SqlStr = "delete from groupbiao where groupname = '" + xiaozuming.Text + "'; delete from usergroup where groupname = '" + xiaozuming.Text + "'";
                    i = Sql.ExecuteNonQuery(SqlStr);
                    if (i != 0)
                    {
                        if(MessageBox.Show("删除小组完成！", "提示", MessageBoxButtons.OK) == DialogResult.OK)
                        {
                            xiaozuming.Text = "";
                            xiaozujj.Text = "";
                            xiaozubeizhu.Text = "";
                            treeView2.Nodes.Clear();
                            treeView5.Nodes.Clear();
                            qxguanli_Load(null, null);
                        }

                    }


                }
            }
        }

        //编辑小组按钮
        private void btn_bjxz_Click(object sender, EventArgs e)
        {
            if (xiaozuming.Text == "" || xiaozuming.Text == null)
            {
                MessageBox.Show("请选择一个需要编辑的小组！", "消息");
            }
            else
            {
                btn_yhtj.Enabled = true;
                btn_yhsc.Enabled = true;
                btn_bcqxsz.Enabled = true;
                btn_scxz.Enabled = true;
                xiaozuming.ReadOnly = false;
                xiaozujj.ReadOnly = false;
                xiaozubeizhu.ReadOnly = false;
                treeView2.Enabled = true;
                treeView_quanxian.Enabled = true;
                treeView5.Enabled = true;

            }
        }


        //小组中添加用户
        private void btn_yhtj_Click(object sender, EventArgs e)
        {
            int row1 = 0;
            if (treeView5.Nodes[0].Nodes == null || treeView5.Nodes[0].Nodes.Count < 1) return;
            foreach (TreeNode node in treeView5.Nodes[0].Nodes)
            {
                if (node.Checked == true)
                {
                    TreeNode new_node = node.Clone() as TreeNode;
                    treeView2.Nodes[0].Nodes.Add(new_node);
                    treeView2.Nodes[0].Expand();//默认展开第一层节点
                    xzyhstr = "insert into usergroup(name, groupname) values('" + new_node.Text.ToString() + "', '" + xiaozuming.Text.ToString() + "');";
                    xzyhstr1 += xzyhstr;
                }
            }
            for (int i = treeView5.Nodes[0].Nodes.Count - 1; i >= 0; i--)
            {
                if (treeView5.Nodes[0].Nodes[i].Checked == true)
                {
                    treeView5.Nodes[0].Nodes.RemoveAt(i);
                }
         
            }
            row1 = Sql.ExecuteNonQuery(xzyhstr1);
            if (row1 != 0)
            {
                xzyhstr1 = "";  //需要清空里面的sql语句，否则会重复记录数据
                MessageBox.Show("添加小组用户完成！", "提示");
            }
            //nodenum2 = treeView2.Nodes[0].Nodes.Count;
        }


        //删除小组中用户
        private void btn_yhsc_Click(object sender, EventArgs e)
        {
            if (treeView2.SelectedNode == null)
            {
                MessageBox.Show("请选择需要移除的小组用户！", "提示");
                return;
            }
            else{
                int scxz = 0;
                string sczxyh = "DELETE FROM usergroup where name = '" + treeView2.SelectedNode.Text.ToString() + "'";
                scxz = Sql.ExecuteNonQuery(sczxyh);
                TreeNode new_node = treeView2.SelectedNode.Clone() as TreeNode;
                new_node.Checked = false;

                treeView5.Nodes[0].Nodes.Add(new_node);
                treeView2.Nodes[0].Nodes.Remove(treeView2.SelectedNode);
                treeView5.Nodes[0].Expand();//默认展开第一层节点
                if (scxz != 0)
                {
                    MessageBox.Show("移除小组用户完成！", "提示");
                }
            }
                   
            //TreeNode new_node = treeView2.SelectedNode.Clone() as TreeNode;
            //new_node.Checked = false;

            //treeView5.Nodes[0].Nodes.Add(new_node);
            //treeView2.Nodes[0].Nodes.Remove(treeView2.SelectedNode);

            //nodenum1 = treeView2.Nodes[0].Nodes.Count;
        }



        //保存小组设置，组内成员与小组权限设置
        private void btn_bcqxsz_Click(object sender, EventArgs e)
        {
            int qx = 0;
            foreach (TreeNode node in treeView_quanxian.Nodes[0].Nodes)
            {
                
                    if (node.Checked == true)
                    {
                     TreeNode new_node = node.Clone() as TreeNode;
                     list.Add(new_node.Text); //注意这个位置加上Text，如果写成tnSub.ToString(),那存储的就不是名字了，而是"TreeNode:名字",多了一个TreeNode:字符  
                    }

            }
            if(list1.Count > list.Count)
            {
                 List<string> list2 = list1.Except(list).ToList<string>();
                 for (int m = 0; m < list2.Count; m++)
                 {
                    groupqx = " DELETE FROM qxgroup where quanxianmc = '" + list2[m].ToString() + "' and groupname = '" + xiaozuming.Text.ToString() + "';";
                    groupqx1 += groupqx;
                 }
                list.Clear();
            }
            else
            {
                List<string> list2 = list.Except(list1).ToList<string>();
                for (int m = 0; m < list2.Count; m++)
                {
                    groupqx = " insert into qxgroup(quanxianmc, groupname) values('" + list2[m].ToString() + "', '" + xiaozuming.Text.ToString() + "');";
                    groupqx1 += groupqx;
                }
                list.Clear();
            }
            qx = Sql.ExecuteNonQuery(groupqx1);
            if (qx != 0)
            {
              groupqx1 = "";  //需要清空里面的sql语句，否则会重复记录数据
              MessageBox.Show("'"+ xiaozuming.Text.ToString()  + "'小组添加权限完成！", "提示");
            }
        }






        #endregion


        #region BindeRoot3()方法
        ///<summary>生成树之生成第一层名称节点</summary>
        private void BindRoot3()
        {
            MySqlDataReader scx3 = Sql.getcom("select name from usergroup where groupname = '"+ xiaozuming.Text + "' order by xh ASC ");
            while (scx3.Read())
            {
                TreeNode t3 = new TreeNode();
                t3.Text = scx3[0].ToString();
                node3.Nodes.Add(t3);
            }
        }

        #endregion

        #region BindeRoot4()方法
        ///<summary>生成树之生成第一层名称节点</summary>
        private void BindRoot4()
        {
            MySqlDataReader scx4 = Sql.getcom("SELECT us.`name` FROM `user` us LEFT JOIN  usergroup usg on us.`name` = usg.`name` where us.groupname is NULL");
            while (scx4.Read())
            {
                TreeNode t4 = new TreeNode();
                t4.Text = scx4[0].ToString();
                node4.Nodes.Add(t4);
            }
        }

        #endregion

        #region treeView4_AfterSelect()方法：根据选择的树节点进行小组信息查询
        /// <summary>
        /// 根据选择的树节点进行库存明细查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">当前节点</param>
        private void treeView4_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<string> list = new List<string>();
            if (treeView4.SelectedNode.Level == 1)
            {

                string str = "select xh,groupinfo,beizhu from groupbiao where groupname = '" + e.Node.Text.ToString() + "'";
                DataTable db = Sql.getDataSet1(str).Tables[0];
                //MySqlDataReader My_read = Sql.getcom(str);
                //while (My_read.Read())
                //{
                //    list.Add(My_read[0].ToString());
                //    list.Add(My_read[1].ToString());
                //    list.Add(My_read[2].ToString());
          
                //}
                //xh.Text = list[0];
                xiaozuming.Text = e.Node.Text.ToString();
                xiaozujj.Text = db.Rows[0]["groupinfo"].ToString();
                xiaozubeizhu.Text = db.Rows[0]["beizhu"].ToString();

                //小组成员的树结构
                node3.Nodes.Clear();
                node3.Remove();
                treeView2.Nodes.Add(node3);
                node3.Text = "小组成员";
                BindRoot3();//生成树的第一层
                treeView2.Nodes[0].Expand();//默认展开第一层节点
                nodenum = treeView2.Nodes[0].Nodes.Count;
                
                //用户树结构，需要判断
                if (nodenum == 0)
                {
                    node2.Nodes.Clear();
                    node2.Remove();
                    node4.Nodes.Clear();
                    node4.Remove();
                    treeView5.Nodes.Add(node2);
                    node2.Text = "用户";
                    BindRoot2();//生成树的第一层
                    treeView5.Nodes[0].Expand();//默认展开第一层节点
                }
                else
                {
                    node2.Nodes.Clear();
                    node2.Remove();
                    node4.Nodes.Clear();
                    node4.Remove();
                    treeView5.Nodes.Add(node4);
                    node4.Text = "用户";
                    BindRoot4();//生成树的第一层
                    treeView5.Nodes[0].Expand();//默认展开第一层节点
                }


                //切换小组时重新禁止编辑
                btn_yhtj.Enabled = false;
                btn_yhsc.Enabled = false;
                btn_bcqxsz.Enabled = false;
                btn_scxz.Enabled = false;
                xiaozuming.ReadOnly = true;
                xiaozujj.ReadOnly = true;
                xiaozubeizhu.ReadOnly = true;
                treeView2.Enabled = false;
                treeView_quanxian.Enabled = false;
                treeView5.Enabled = false;


                //切换小组时权限树中节点根据数据库显示
                string qxs = "select quanxianmc from qxgroup where groupname = '"+ xiaozuming.Text.ToString() + "'";
                list1 = Sql.DataReadList(qxs);
                if (list1.Count == 0)
                {
                    node5.Nodes.Clear();
                    node5.Remove();
                    treeView_quanxian.Nodes.Add(node5);
                    node5.Text = "全部选择";
                    BindRoot5();//生成树的第一层
                    treeView_quanxian.Nodes[0].Expand();//默认展开第一层节点
                }
                else
                {
                    foreach (TreeNode node in treeView_quanxian.Nodes[0].Nodes)
                    {
                        node.Checked = false;
                        TreeNode new_node = node.Clone() as TreeNode;
                        for (int j = 0; j < list1.Count; j++)
                        {
                            if (list1[j] == new_node.Text)
                            {
                                node.Checked = true;
                            }
                  
                        }

                    }
                }




            }
        }





        #endregion


        #region BindeRoot5()方法
        ///<summary>生成树之生成第一层名称节点</summary>
        private void BindRoot5()
        {
            MySqlDataReader scx5 = Sql.getcom("SELECT quanxianmc FROM quanxianbiao order by xh ASC");
            while (scx5.Read())
            {
                TreeNode t5 = new TreeNode();
                t5.Text = scx5[0].ToString();
                node5.Nodes.Add(t5);
            }
        }


        #endregion

        //tab切换事件
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                
                case 1:
               
                    break;
            }
        }

        private void qxguanli_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
