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

using System.Xml;
using MySql.Data.MySqlClient;
using kucunTest.BaseClasses;

namespace kucunTest.quanxianguanli
{
    public partial class qxguanli : Form
    {
        #region 全局变量
        private MySql Sql = new MySql();//MySQL类
        BaseAlex Alex = new BaseAlex();

        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private XmlDocument doc = new XmlDocument();//存放权限列表（从xml文件读取）
                
        private string SqlStr = "";
        private string LogType = "权限管理";
        private string LogMessage = "";

        string yhcyUpdateStr = "";//用户成员更新sql语句
        string xzqxStr = "";//小组权限更新或插入语句
        bool yhglEditFlag = false;//是否有修改用户管理信息
        bool xzglInfoFlag = false;//是否有修改小组管理的基本信息
        bool xzglUserFlag = false;//是否有修改小组管理的成员信息
        bool xzglAuthorityFlage = false;//是否有小组管理的权限信息

        private string xzyhstr = "";
        private string xzyhstr1 = "";
        private string groupqx = "";
        private string groupqx1 = "";
        //private int nodenum;
        //private int nodenum1;
        //private int nodenum2;
        private TreeNode node = new TreeNode();//类型树的根节点。
        private TreeNode node1 = new TreeNode();//类型树的根节点。
        private TreeNode node2 = new TreeNode();//类型树的根节点。
        private TreeNode node3 = new TreeNode();//类型树的根节点。
        private TreeNode node4 = new TreeNode();//类型树的根节点。
        private TreeNode node5 = new TreeNode();//类型树的根节点。
        List<string> list1 = new List<string>();
        List<string> list = new List<string>();
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public qxguanli()
        {
            InitializeComponent();

            //加载权限列表
            LoadAuthortyList();
            treeViewAuthorityList.Nodes[0].Expand();//默认展开第一层节点
        }


        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void qxguanli_Load(object sender, EventArgs e)
        {
            //加载用户列表
            LoadUserList();
            treeViewUserList.Nodes[0].Expand();//默认展开第一层节点

            //加载小组列表
            LoadGroupList();
            treeviewGroupList.Nodes[0].Expand();//默认展开第一层节点

            //修改标识为false
            yhglEditFlag = false;
            xzglInfoFlag = false;
            xzglUserFlag = false;
            xzglAuthorityFlage = false;

            //禁用修改密码按钮
            btnEditPwd.Enabled = false;
            btnConfirmEditPwd.Enabled = false;
            btnSaveInfo.Enabled = false;
            bntResetPwd.Enabled = false;
            btnDeleteUser.Enabled = false;

            //隐藏密码框，用于显示密码
            ycysmm.Visible = false;
            ycxmm.Visible = false;
            ycqrxmm.Visible = false;

            //小组管理界面禁用
            //treeViewAuthorityList.Nodes[0].Expand();

            asc.controllInitializeSize(this);
        }



        /// <summary>
        /// 加载用户列表函数
        /// </summary>
        private void LoadUserList()
        {
            treeViewUserList.Nodes.Clear();

            //加载根节点
            TreeNode root = new TreeNode();
            root.Text = "全部用户";
            root.Name = "AllUser";
            treeViewUserList.Nodes.Add(root);

            //加载子节点
            SqlStr = "";
            SqlStr = string.Format("SELECT DISTINCT {1} FROM {0} ORDER BY {2}", User.TableName, User.name, User.xh);
            Alex.BindRoot(SqlStr, treeViewUserList.Nodes[0], false);
        }



        /// <summary>
        /// 加载小组列表函数
        /// </summary>
        private void LoadGroupList()
        {
            treeviewGroupList.Nodes.Clear();

            //加载根节点
            TreeNode root = new TreeNode();
            root.Text = "全部小组";
            root.Name = "AllGroup";
            treeviewGroupList.Nodes.Add(root);

            //加载子节点
            SqlStr = "";
            SqlStr = string.Format("SELECT DISTINCT {1} FROM {0} ORDER BY {2}", UserGroup.TableName, UserGroup.groupName, UserGroup.xh);
            Alex.BindRoot(SqlStr, treeviewGroupList.Nodes[0], false);
        }


        /// <summary>
        /// 从xml文件加载权限列表函数
        /// </summary>
        private void LoadAuthortyList()
        {
            //添加“全部模块”根节点
            TreeNode root = new TreeNode();
            node.Text = "全部模块";
            node.Name = "AllAuthorities";
            treeViewAuthorityList.Nodes.Add(node);

            //从xml文件中加载权限列表
            string xmlPath = @"../../XiTongGuanLi/Authority.xml";
            doc.Load(xmlPath);
            RecursionTreeControl(doc.DocumentElement, treeViewAuthorityList.Nodes[0].Nodes);//将加载完成的XML文件显示在TreeView控件中
            //treeViewAuthorityList.ExpandAll();//展开TreeView控件中的所有项
        }

        /// <summary>
        /// RecursionTreeControl:表示将XML文件的内容显示在TreeView控件中
        /// </summary>
        /// <param name="xmlNode">将要加载的XML文件中的节点元素</param>
        /// <param name="nodes">将要加载的XML文件中的节点集合</param>
        private void RecursionTreeControl(XmlNode xmlNode, TreeNodeCollection nodes)
        {
            foreach (XmlNode node in xmlNode.ChildNodes)//循环遍历当前元素的子元素集合
            {
                TreeNode new_child = new TreeNode();//定义一个TreeNode节点对象
                new_child.Name = node.Attributes["Name"].Value;
                new_child.Text = node.Attributes["Text"].Value;
                nodes.Add(new_child);//向当前TreeNodeCollection集合中添加当前节点

                //如果该节点有子节点则调用本方法进行递归
                if (node.ChildNodes.Count > 0)
                {
                    RecursionTreeControl(node, new_child.Nodes);
                }
            }
        }



        /// <summary>
        /// 加载小组成员函数
        /// </summary>
        private void LoadUserofGroup(string crtGroupName)
        {
            //先清除历史数据
            treeViewUserinGroup.Nodes.Clear();
            treeViewUsernotinGroup.Nodes.Clear();

            //加载根节点
            TreeNode root1 = new TreeNode();
            root1.Text = "已有用户成员";
            treeViewUserinGroup.Nodes.Add(root1);

            TreeNode root2 = new TreeNode();
            root2.Text = "未分配小组用户";
            treeViewUsernotinGroup.Nodes.Add(root2);

            //加载子节点
            SqlStr = "";
            SqlStr = string.Format("SELECT {1}, {2} FROM {0}", User.TableName, User.name, User.groupName);
            DataTable db = Sql.getDataSet(SqlStr, User.TableName).Tables[0];
            foreach(DataRow row in db.Rows)
            {
                TreeNode tempNode = new TreeNode();
                if (row[User.groupName] == null || row[User.groupName].ToString() == "")
                {
                    tempNode.Text = row[User.name].ToString();
                    treeViewUsernotinGroup.Nodes[0].Nodes.Add(tempNode);
                    continue;
                }

                if (row[User.groupName].ToString() == crtGroupName)
                {
                    tempNode.Text = row[User.name].ToString();
                    treeViewUserinGroup.Nodes[0].Nodes.Add(tempNode);
                    continue;
                }                
            }
        }




        /// <summary>
        /// 加载当前小组的权限
        /// </summary>
        private void LoadUserAuthorities(string crtGroupName)
        {
            //清空权限
            ClearAuthorities(treeViewAuthorityList.Nodes[0]);

            //加载权限表
            SqlStr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", QuanXian.TableName, QuanXian.qxgroup, crtGroupName);
            DataTable db = Sql.getDataSet(SqlStr, QuanXian.TableName).Tables[0];

            if(db.Rows.Count <= 0)
            {
                return;
            }

            foreach (DataRow row in db.Rows)
            {
                //findornot = false;
                NodeCheck(treeViewAuthorityList.Nodes, row[QuanXian.dm].ToString(), Convert.ToBoolean(row[QuanXian.zt]));                
            }
        }

        /// <summary>
        /// 清空权限列表
        /// </summary>
        /// <param name="ParentNode"></param>
        private void ClearAuthorities(TreeNode ParentNode)
        {
            foreach (TreeNode n in ParentNode.Nodes)
            {
                n.Checked = false;
                n.ForeColor = Color.Black;

                if(n.Nodes.Count > 0)
                {
                    ClearAuthorities(n);
                }
            }
        }

        /// <summary>
        /// 循环遍历权限树的叶子节点，根据数据库的权限代码和权限状态选中相应权限
        /// </summary>
        /// <param name="nodes">待遍历的树节点集合，可能存在子节点</param>
        /// <param name="nodeName">数据库中的权限代码，用于与树节点的Name比较</param>
        /// <param name="check">数据库中的权限状态，用于设置树的叶子节点是否选中</param>
        /// <returns></returns>
        private bool NodeCheck(TreeNodeCollection nodes, string nodeName, bool check)
        {            
            bool findornot = false;//是否找到的标志

            foreach (TreeNode n in nodes)
            {
                if (n.Name == nodeName)
                {
                    n.Checked = check;
                    findornot = true;
                }
                else
                {
                    //如果该节点有子节点（说明不是叶子节点），则继续遍历，否则已经是叶子节点
                    if (n.Nodes.Count > 0)
                    {
                        findornot = NodeCheck(n.Nodes, nodeName, check);

                    }
                }

                //已经找到,立即返回
                if (findornot)
                {
                    return findornot;
                }

            }

            //循环结束还未返回说明没找到，则返回false
            return findornot;
        }



        /// <summary>
        /// 从数据库加载权限列表后仅根据节点的选中状态设置节点颜色
        /// </summary>
        private void LoadNodesColor(TreeNodeCollection parentNodes)
        {
            foreach (TreeNode n in parentNodes)
            {
                if (n.Checked)
                {
                    n.ForeColor = Color.Blue;
                }
                else
                {
                    n.ForeColor = Color.Black;
                }

                //有子节点
                if (n.Nodes.Count > 0)
                {
                    LoadNodesColor(n.Nodes);
                }
                else if (n.Parent != null)
                {
                    SetParentNodeColor(n);
                }
            }
        }

        /// <summary>
        /// 从数据库加载权限列表的选中状态后根据子节点的选中状态更新父节点的颜色
        /// </summary>
        /// <param name="childNode">待更新父节点的子节点，即当前节点</param>
        private void SetParentNodeColor(TreeNode childNode)
        {
            TreeNode parentNode = childNode.Parent;

            //已经设置父节点的颜色
            if (parentNode.ForeColor == Color.Blue)
            {
                parentNode.Expand();
                return;
            }

            foreach (TreeNode n in parentNode.Nodes)
            {
                if (n.Checked || n.ForeColor == Color.Blue)
                {
                    parentNode.ForeColor = Color.Blue;
                    parentNode.Expand();
                    break;
                }
            }

            if (parentNode.Parent != null)
            {
                SetParentNodeColor(parentNode);
            }
        }



        /// <summary>
        /// 选中用户，加载用户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">当前节点</param>
        private void treeViewUserList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SqlStr = "";

            if (treeViewUserList.SelectedNode.Level == 1)
            {
                //加载用户信息
                SqlStr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", User.TableName, User.name, e.Node.Text.ToString());
                DataTable db = Sql.getDataSet(SqlStr, User.TableName).Tables[0];
                xh.Text = db.Rows[0][User.xh].ToString();
                yhm.Text = e.Node.Text.ToString();
                yhxm.Text = db.Rows[0][User.xingming].ToString();
                ssjs.Text = db.Rows[0][User.type].ToString();
                ssbm.Text = db.Rows[0][User.bumen].ToString();
                beizhu.Text = db.Rows[0][User.bz].ToString();
                pwd.Text = db.Rows[0][User.pwd].ToString();
                ssxiaozu.Text = db.Rows[0][User.groupName].ToString();

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
                btnEditPwd.Enabled = false;
                btnConfirmEditPwd.Enabled = false;
                btnSaveInfo.Enabled = false;
                bntResetPwd.Enabled = false;
                btnDeleteUser.Enabled = false;
                ysmm.Text = "";
                xmm.Text = "";
                qrxmm.Text = "";
                ycysmm.Text = "";
                ycxmm.Text = "";
                ycqrxmm.Text = "";
                xsmm.Checked = false;
            }
        }



        /// <summary>
        /// 选中小组名，加载小组信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeviewGroupList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SqlStr = "";

            if (treeviewGroupList.SelectedNode.Level == 1)
            {
                //加载小组基本信息
                SqlStr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", UserGroup.TableName, UserGroup.groupName, e.Node.Text.ToString());
                DataTable db = Sql.getDataSet(SqlStr, UserGroup.TableName).Tables[0];
                xiaozuming.Text = e.Node.Text.ToString();
                xiaozujj.Text = db.Rows[0][UserGroup.groupInfo].ToString();
                xiaozubeizhu.Text = db.Rows[0][UserGroup.bz].ToString();

                //加载小组成员和未分配小组成员
                LoadUserofGroup(crtGroupName: e.Node.Text.ToString());
                treeViewUserinGroup.Nodes[0].Expand();
                treeViewUsernotinGroup.Nodes[0].Expand();

                yhcyUpdateStr = "";

                //加载选中小组的权限并更新节点颜色
                LoadUserAuthorities(crtGroupName: e.Node.Text.ToString());
                LoadNodesColor(treeViewAuthorityList.Nodes);
                xzqxStr = "";

                //切换小组时重新禁止编辑
                btnAddUsertoGroup.Enabled = false;
                btnDeleteUserfromGroup.Enabled = false;
                btnSaveSettings.Enabled = false;
                btnDeleteGroup.Enabled = false;
                xiaozuming.ReadOnly = true;
                xiaozujj.ReadOnly = true;
                xiaozubeizhu.ReadOnly = true;
                treeViewUserinGroup.Enabled = false;
                //treeViewAuthorityList.Enabled = false;
                treeViewUsernotinGroup.Enabled = false;

            }
        }



        /// <summary>
        /// 鼠标选中或取消选中树节点后，更新其父节点或子节点的状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewAuthorityList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //通过鼠标改变checkbox状态
            if (e.Action == TreeViewAction.ByMouse)
            {
                //根据选中状态改变当前节点颜色
                if (e.Node.Checked)
                {
                    e.Node.ForeColor = Color.Blue;
                }
                else if (e.Node.Checked == false)
                {
                    e.Node.ForeColor = Color.Black;
                }

                //如果有子节点设置子节点状态
                if (e.Node.Nodes.Count > 0)
                {
                    SetChildChecked(e.Node);
                    e.Node.Expand();
                }

                //设置父节点状态
                if (e.Node.Parent != null)
                {
                    SetParentChecked(e.Node);
                }

                xzglAuthorityFlage = true;
            }
        }

        /// <summary>
        /// 根据父节点状态设置子节点的状态
        /// </summary>
        /// <param name="parentNode"></param>
        private void SetChildChecked(TreeNode parentNode)
        {
            foreach (TreeNode node in parentNode.Nodes)
            {
                //子节点选中状态与父节点一致
                node.Checked = parentNode.Checked;

                //设置子节点颜色
                if (node.Checked)
                {
                    node.ForeColor = Color.Blue;
                }
                else
                {
                    node.ForeColor = Color.Black;
                }

                //如果子节点还有子节点，递归
                if (node.Nodes.Count > 0)
                {
                    SetChildChecked(node);
                }
            }
        }

        /// <summary>
        /// 根据子节点状态设置父节点的状态
        /// </summary>
        /// <param name="childNode"></param>
        private void SetParentChecked(TreeNode childNode)
        {
            TreeNode parentNode = childNode.Parent;

            //选中子节点
            if (childNode.Checked)
            {
                int ichecks = 0;
                foreach (TreeNode node in parentNode.Nodes)
                {
                    if (node.Checked)
                    {
                        ichecks++;
                    }
                }

                //该父节点的所有子节点均选中
                if (ichecks == parentNode.Nodes.Count)
                {
                    parentNode.Checked = true;
                    parentNode.ForeColor = Color.Blue;

                }
                //部分选中
                else if (ichecks > 0 && ichecks < parentNode.Nodes.Count)
                {
                    parentNode.Checked = false;
                    parentNode.ForeColor = Color.Blue;
                }
            }

            //取消选中子节点
            else if (!childNode.Checked)
            {
                parentNode.Checked = false;

                int ichecks = 0;
                int colorchecks = 0;
                foreach (TreeNode node in parentNode.Nodes)
                {
                    if (node.Checked)
                    {
                        ichecks++;
                    }

                    if (node.ForeColor == Color.Blue)
                    {
                        colorchecks++;
                    }
                }

                //该父节点的所有子节点及孙子节点均未选中
                if (ichecks == 0 && colorchecks == 0)
                {
                    //parentNode.Checked = false;
                    parentNode.ForeColor = Color.Black;
                }
                //部分未选中
                else
                {
                    //parentNode.Checked = false;
                    parentNode.ForeColor = Color.Blue;
                }
            }

            //该父节点如有父节点，递归
            if (parentNode.Parent != null)
            {
                SetParentChecked(parentNode);
            }
        }



        #region 用户管理界面按钮操作
        /// <summary>
        /// 编辑用户按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_bjyh_Click(object sender, EventArgs e)
        {
            if (yhm.Text == "" || yhm.Text == null)
            {
                MessageBox.Show("请先从用户列表中选择用户！", Program.tishiTitle);
                return;
            }

            btnEditPwd.Enabled = true;
            btnConfirmEditPwd.Enabled = true;
            btnSaveInfo.Enabled = true;
            bntResetPwd.Enabled = true;
            btnDeleteUser.Enabled = true;
            yhm.ReadOnly = false;
            yhxm.ReadOnly = false;
            ssjs.ReadOnly = false;
            ssbm.ReadOnly = false;
            beizhu.ReadOnly = false;

        }

        /// <summary>
        /// 删除用户按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string selectedUserName = yhm.Text.ToString();

            if (yhm.Text == "" || yhm.Text == null)
            {
                MessageBox.Show("请选择一个需要删除的用户！", Program.tishiTitle);
                return;
            }

            if (MessageBox.Show(string.Format("确定删除用户：{0}？\n注：删除操作不可撤销。", selectedUserName), Program.tishiTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //从用户表中删除当前用户
                SqlStr = string.Format("DELETE FROM `{0}` WHERE {1} = '{2}'", User.TableName, User.name, selectedUserName);
                Sql.ExecuteNonQuery(SqlStr);

                //日志记录
                LogMessage = string.Format("成功删除用户：{0}！", selectedUserName);
                Program.WriteLog(LogType, LogMessage);
                LogMessage = "";

                if (MessageBox.Show(string.Format("成功删除用户：{0}！", selectedUserName), Program.tishiTitle, MessageBoxButtons.OK) == DialogResult.OK)
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
                    //qxguanli_Load(null, null);
                    LoadUserList();
                }
            }            
        }

        /// <summary>
        /// 修改密码按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xgmm_Click(object sender, EventArgs e)
        {
             ysmm.ReadOnly = false;
             xmm.ReadOnly = false;
             qrxmm.ReadOnly = false;
             xsmm.Enabled = true;
             //MessageBox.Show("修改'" + yhm.Text + "'用户密码成功！", "消息");
        }

        /// <summary>
        /// 确认修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_czmm_Click(object sender, EventArgs e)
        {
            string selectedUserName = yhm.Text.ToString();
            SqlStr = "";
            LogMessage = "";

            int row = 0;
            if (ysmm.Text == "" || xmm.Text == "" || qrxmm.Text == "")
            {
                MessageBox.Show("输入密码不能为空！", Program.tishiTitle);
                return;
            }
            if (xmm.Text == ysmm.Text)
            {
                MessageBox.Show("新密码不能与原密码相同！", Program.tishiTitle);
                return;
            }
            if (xmm.Text != qrxmm.Text)
            {
                MessageBox.Show("密码输入不一致！", Program.tishiTitle);
                return;
            }
            if (xmm.Text.Length < 6 || qrxmm.Text.Length < 6)
            {
                MessageBox.Show("密码长度应为6到10位!", Program.tishiTitle);
                return;
            }
            if (ysmm.Text != pwd.Text)
            {
                MessageBox.Show("原密码错误, 密码修改失败！", Program.tishiTitle);
                return;
            }

            SqlStr = string.Format("UPDATE `{0}` SET {1} = '{2}' WHERE {3} = '{4}'", User.TableName, User.pwd, xmm.Text, User.name, selectedUserName);
            //SqlStr = "update user set pwd = '" + xmm.Text + "' where xh = '" + xh.Text + "'";
            row = Sql.ExecuteNonQuery(SqlStr);

            //日志记录
            LogMessage = string.Format("用户{0}修改密码成功！", selectedUserName);
            Program.WriteLog(LogType, LogMessage);
            LogMessage = "";

            MessageBox.Show(string.Format("用户{0}修改密码成功！", selectedUserName), Program.tishiTitle);
        }

        /// <summary>
        /// 显示密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            xzyh tjyh = new xzyh();
            tjyh.ShowDialog();
            if (tjyh.DialogResult == DialogResult.OK)
            {
                //qxguanli_Load(null, null);
                LoadUserList();
                treeViewUserList.ExpandAll();
            }
        }

        /// <summary>
        /// 保存更改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_bcxx_Click(object sender, EventArgs e)
        {
            int j = 0;
            if (yhm.Text == "" || yhxm.Text == "" || ssbm.Text == "" || ssjs.Text == "")
            {
                MessageBox.Show("请填写完整的用户信息！", Program.tishiTitle);
                return;
            }

            //如果修改了用户名，则先判断用户名是否已经存在
            if (treeViewUserList.SelectedNode.Text != yhm.Text)
            {
                if (Alex.CunZai(User.TableName, string.Format("{0} = '{1}'", User.name, yhm.Text)) != 0)
                {
                    MessageBox.Show(string.Format("用户名：{0}已存在！", yhm.Text), Program.tishiTitle);
                    yhm.Focus();
                    return;
                }
                else
                {
                    LogMessage = string.Format("成功更新用户：{0}的信息！并修改其用户名为{1}", treeViewUserList.SelectedNode.Text, yhm.Text);
                }
            }

            SqlStr = string.Format("UPDATE `{0}` SET `{1}` = '{2}', {3} = '{4}', {5} = '{6}', {7} = '{6}', {8} = '{9}', {10} = '{11}' WHERE `{1}` = '{12}'", User.TableName, User.name, yhm.Text, User.xingming, yhxm.Text, User.type, ssjs.Text, User.groupName, User.bumen, ssbm.Text, User.bz, beizhu.Text, treeViewUserList.SelectedNode.Text);
            Sql.ExecuteNonQuery(SqlStr);

            //日志记录
            if (LogMessage == "")
            {
                LogMessage = string.Format("成功更新用户：{0}的信息！", yhm.Text);
            }
            Program.WriteLog(LogType, LogMessage);

            MessageBox.Show(LogMessage, Program.tishiTitle);
        }

        /// <summary>
        /// 重置密码按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnt_czmm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("确定重置用户：{0} 的密码？", yhm.Text), Program.tishiTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlStr = string.Format("UPDATE `{0}` SET {1} = '123456' WHERE {2} = '{3}' ", User.TableName, User.pwd, User.name, yhm.Text);
                Sql.ExecuteNonQuery(SqlStr);

                //日志记录
                LogMessage = string.Format("成功重置用户：{0} 的密码！", yhm.Text);
                Program.WriteLog(LogType, LogMessage);
                LogMessage = "";

                MessageBox.Show(string.Format("成功重置用户：{0} 的密码！", yhm.Text), Program.tishiTitle, MessageBoxButtons.OK);
            }
        }
        #endregion


        #region 小组管理界面按钮操作
        /// <summary>
        /// 添加小组按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xjxz_Click(object sender, EventArgs e)
        {
            xjxz tjxz = new xjxz();
            tjxz.ShowDialog();
            if (tjxz.DialogResult == DialogResult.OK)
            {
                //qxguanli_Load(null, null);
                LoadGroupList();
                treeviewGroupList.ExpandAll();
            }
        }

        /// <summary>
        /// 删除小组按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_scxz_Click(object sender, EventArgs e)
        {
            if (xiaozuming.Text == "" || xiaozuming.Text == null)
            {
                MessageBox.Show("请从小组列表中选择一个需要删除的小组！", Program.tishiTitle);
                return;
            }

            if (MessageBox.Show(string.Format("确定删除小组：{0}？\n注：删除小组后，该小组下的用户变为未分配小组用户。", xiaozuming.Text), Program.tishiTitle, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'; UPDATE `{3}` SET {4} = '' WHERE {4} = '{2}';", UserGroup.TableName, UserGroup.groupName, xiaozuming.Text, User.TableName, User.groupName);
                int row = Sql.ExecuteNonQuery(SqlStr);

                LogMessage = string.Format("成功删除小组：{}，并将该小组下{}个用户更改未分配小组用户。", xiaozuming.Text, row - 1);

                //日志记录
                Program.WriteLog(LogType, LogMessage);

                if (MessageBox.Show(LogMessage, Program.tishiTitle, MessageBoxButtons.OK) == DialogResult.OK)
                {
                    xiaozuming.Text = "";
                    xiaozujj.Text = "";
                    xiaozubeizhu.Text = "";
                    treeViewUserinGroup.Nodes.Clear();
                    treeViewUsernotinGroup.Nodes.Clear();
                    //qxguanli_Load(null, null);
                    LoadGroupList();
                }
            }
        }

        /// <summary>
        /// 编辑小组按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_bjxz_Click(object sender, EventArgs e)
        {
            if (xiaozuming.Text == "" || xiaozuming.Text == null)
            {
                MessageBox.Show("请选择一个需要编辑的小组！", Program.tishiTitle);
                return;
            }

            btnAddUsertoGroup.Enabled = true;
            btnDeleteUserfromGroup.Enabled = true;
            btnSaveSettings.Enabled = true;
            btnDeleteGroup.Enabled = true;
            xiaozuming.ReadOnly = false;
            xiaozujj.ReadOnly = false;
            xiaozubeizhu.ReadOnly = false;
            treeViewUserinGroup.Enabled = true;
            treeViewAuthorityList.Enabled = true;
            treeViewUsernotinGroup.Enabled = true;

        }


        /// <summary>
        /// 向小组中添加用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_yhtj_Click(object sender, EventArgs e)
        {
            //没有未分配小组用户
            if (treeViewUsernotinGroup.Nodes[0].Nodes == null || treeViewUsernotinGroup.Nodes[0].Nodes.Count < 1)
            {
                MessageBox.Show("当前没有未分配小组的用户成员，请添加新用户或将用户从其他小组移除！", Program.tishiTitle);
                return;
            }

            //添加至当前小组列表
            foreach (TreeNode node in treeViewUsernotinGroup.Nodes[0].Nodes)
            {
                if (node.Checked)
                {
                    TreeNode new_node = node.Clone() as TreeNode;
                    treeViewUserinGroup.Nodes[0].Nodes.Add(new_node);
                    //node.Remove();

                    //treeViewUserinGroup.Nodes[0].Expand();//默认展开第一层节点
                    //yhcyUpdateStr += string.Format("UPDATE `{0}` SET {1} = '{2}' WHERE `{3}` = '{4}';", User.TableName, User.groupName, xiaozuming.Text.ToString(), User.name, new_node.Text.ToString());
                    //xzyhstr1 += xzyhstr;
                }
            }

            //从未分配列表中移除
            //foreach (TreeNode node in treeViewUsernotinGroup.Nodes[0].Nodes)
            //{
            //    if (node.Checked)
            //    {
            //        node.Remove();
            //    }
            //}

            for (int i = treeViewUsernotinGroup.Nodes[0].Nodes.Count - 1; i >= 0; i--)
            {
                if (treeViewUsernotinGroup.Nodes[0].Nodes[i].Checked == true)
                {
                    treeViewUsernotinGroup.Nodes[0].Nodes.RemoveAt(i);
                }
            }
            treeViewUserinGroup.ExpandAll();
            xzglUserFlag = true;
        }


        /// <summary>
        /// 移除小组中用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_yhsc_Click(object sender, EventArgs e)
        {
            //当前小组没有用户
            if (treeViewUserinGroup.Nodes[0].Nodes == null || treeViewUserinGroup.Nodes[0].Nodes.Count < 1)
            {
                MessageBox.Show("当前小组没有用户成员，不可移除！", Program.tishiTitle);
                return;
            }

            //添加至未分配小组列表
            foreach (TreeNode node in treeViewUserinGroup.Nodes[0].Nodes)
            {
                if (node.Checked)
                {
                    TreeNode new_node = node.Clone() as TreeNode;
                    treeViewUsernotinGroup.Nodes[0].Nodes.Add(new_node);
                    //node.Remove();
                    //treeViewUserinGroup.Nodes[0].Expand();//默认展开第一层节点
                    //yhcyUpdateStr += string.Format("UPDATE `{0}` SET {1} = '' WHERE `{2}` = '{3}';", User.TableName, User.groupName, User.name, new_node.Text.ToString());
                    //xzyhstr1 += xzyhstr;
                }
            }

            //从小组成员列表中移除
            for (int i = treeViewUserinGroup.Nodes[0].Nodes.Count - 1; i >= 0; i--)
            {
                if (treeViewUserinGroup.Nodes[0].Nodes[i].Checked == true)
                {
                    treeViewUserinGroup.Nodes[0].Nodes.RemoveAt(i);
                }

            }
            treeViewUsernotinGroup.ExpandAll();
            xzglUserFlag = true;

            //TreeNodeCollection tc = treeViewUserinGroup.Nodes[0].Nodes;
            //foreach (TreeNode node in tc)
            //{
            //    if (node.Checked == true)
            //    {
            //        node.Remove();
            //        tc = treeViewUserinGroup.Nodes[0].Nodes;
            //    }
            //}




            //if (treeViewUserinGroup.SelectedNode == null)
            //{
            //    MessageBox.Show("请选择需要移除的小组用户！", "提示");
            //    return;
            //}
            //else{
            //    int scxz = 0;
            //    string sczxyh = "DELETE FROM usergroup where name = '" + treeViewUserinGroup.SelectedNode.Text.ToString() + "'";
            //    scxz = Sql.ExecuteNonQuery(sczxyh);
            //    TreeNode new_node = treeViewUserinGroup.SelectedNode.Clone() as TreeNode;
            //    new_node.Checked = false;

            //    treeViewUsernotinGroup.Nodes[0].Nodes.Add(new_node);
            //    treeViewUserinGroup.Nodes[0].Nodes.Remove(treeViewUserinGroup.SelectedNode);
            //    treeViewUsernotinGroup.Nodes[0].Expand();//默认展开第一层节点
            //    if (scxz != 0)
            //    {
            //        MessageBox.Show("移除小组用户完成！", "提示");
            //    }
            //}

            //TreeNode new_node = treeView2.SelectedNode.Clone() as TreeNode;
            //new_node.Checked = false;

            //treeView5.Nodes[0].Nodes.Add(new_node);
            //treeView2.Nodes[0].Nodes.Remove(treeView2.SelectedNode);

            //nodenum1 = treeView2.Nodes[0].Nodes.Count;
        }


        /// <summary>
        /// 保存更改按钮，保存小组信息，小组成员与小组权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_bcqxsz_Click(object sender, EventArgs e)
        {
            //保存小组信息
            if(!SaveGroupInfo())
            {
                return;
            }

            //保存小组成员
            if(xzglUserFlag)
            {
                SaveGroupUser();
                //日志保存
                LogMessage = string.Format("成功更新小组：{0}的用户成员列表！", xiaozuming.Text.ToString());
                Program.WriteLog(LogType, LogMessage);
            }            

            //保存小组权限:先删除后插入
            if(xzglAuthorityFlage)
            {
                SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", QuanXian.TableName, QuanXian.qxgroup, xiaozuming.Text.ToString());
                Sql.ExecuteNonQuery(SqlStr);
                SaveGroupAuthorities(treeViewAuthorityList.Nodes);
                Sql.ExecuteNonQuery(xzqxStr);
                //日志保存
                LogMessage = string.Format("成功更新小组：{0}的权限！", xiaozuming.Text.ToString());
                Program.WriteLog(LogType, LogMessage);
            }
            
            //日志保存
            LogMessage = string.Format("成功更新小组：{0}完毕！", xiaozuming.Text.ToString());
            Program.WriteLog(LogType, LogMessage);

            MessageBox.Show(LogMessage, Program.tishiTitle);

            qxguanli_Load(null, null);
        }

        /// <summary>
        /// 保存小组基本信息
        /// </summary>
        /// <returns>保存成功返回true</returns>
        private bool SaveGroupInfo()
        {
            if (xiaozuming.Text == "" || xiaozujj.Text == "" || xiaozubeizhu.Text == "")
            {
                MessageBox.Show("请填写完整的小组信息！", Program.tishiTitle);
                return false;
            }

            //如果修改了小组名，则先判断小组名是否已经存在
            if (treeviewGroupList.SelectedNode.Text != xiaozuming.Text)
            {
                if (Alex.CunZai(UserGroup.TableName, string.Format("{0} = '{1}'", UserGroup.groupName, xiaozuming.Text)) != 0)
                {
                    MessageBox.Show(string.Format("小组名：{0}已存在！", xiaozuming.Text), Program.tishiTitle);
                    xiaozuming.Focus();
                    return false;
                }
                else
                {
                    LogMessage = string.Format("成功更新小组：{0}的信息！并修改其小组名为{1}", treeviewGroupList.SelectedNode.Text, xiaozuming.Text);
                }
            }

            SqlStr = string.Format("UPDATE `{0}` SET `{1}` = '{2}', {3} = '{4}', {5} = '{6}' WHERE {1} = '{7}'", UserGroup.TableName, UserGroup.groupName, xiaozuming.Text, UserGroup.groupInfo, xiaozujj.Text, UserGroup.bz, xiaozubeizhu.Text, treeviewGroupList.SelectedNode.Text);
            Sql.ExecuteNonQuery(SqlStr);

            //日志记录
            if(LogMessage == "")
            {
                LogMessage = string.Format("成功更新小组：{0}的信息！", xiaozuming.Text);
            }
            Program.WriteLog(LogType, LogMessage);

            return true;

            //MessageBox.Show(LogMessage, Program.tishiTitle);
        }

        /// <summary>
        /// 保存小组成员信息
        /// </summary>
        private void SaveGroupUser()
        {
            SqlStr = "";

            if(treeViewUserinGroup.Nodes[0].Nodes.Count > 0)
            {
                foreach(TreeNode n in treeViewUserinGroup.Nodes[0].Nodes)
                {
                    SqlStr += string.Format("UPDATE `{0}` SET {1} = '{2}' WHERE `{3}` = '{4}';", User.TableName, User.groupName, xiaozuming.Text.ToString(), User.name, n.Text.ToString());
                }
            }
            if(treeViewUsernotinGroup.Nodes[0].Nodes.Count > 0)
            {
                foreach (TreeNode n in treeViewUsernotinGroup.Nodes[0].Nodes)
                {
                    SqlStr += string.Format("UPDATE `{0}` SET {1} = '' WHERE `{2}` = '{3}';", User.TableName, User.groupName, User.name, n.Text.ToString());
                }
            }

            if(SqlStr != "")
            {
                Sql.ExecuteNonQuery(SqlStr);
                SqlStr = "";
            }
        }

        /// <summary>
        /// 保存小组权限
        /// </summary>
        /// <param name="ParentNode"></param>
        private void SaveGroupAuthorities(TreeNodeCollection tc)
        {
            foreach(TreeNode node in tc)
            {
                string fm = "";
                if(node.Parent == null)
                {
                    fm = node.Name;
                }
                else
                {
                    fm = node.Parent.Name;
                }

                xzqxStr += string.Format("INSERT INTO {0}({1}, {2}, {3}, {4}, {5}) VALUES('{6}', '{7}', '{8}', '{9}', '{10}');", QuanXian.TableName, QuanXian.mc, QuanXian.dm, QuanXian.fm, QuanXian.zt, QuanXian.qxgroup, node.Text, node.Name, fm, Convert.ToInt32(node.Checked), xiaozuming.Text.ToString());
                if(node.Nodes.Count > 0)
                {
                    SaveGroupAuthorities(node.Nodes);
                }
            }
        }
        #endregion

        #region 其他方法
        //tab切换事件
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {

                case 1:

                    break;
            }
        }

        //窗体大小变化自适应
        private void qxguanli_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        #endregion


        #region 师兄的bindroot()
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

        private void BindRoot3()
        {
            MySqlDataReader scx3 = Sql.getcom("select name from usergroup where groupname = '" + xiaozuming.Text + "' order by xh ASC ");
            while (scx3.Read())
            {
                TreeNode t3 = new TreeNode();
                t3.Text = scx3[0].ToString();
                node3.Nodes.Add(t3);
            }
        }

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
    }
}
