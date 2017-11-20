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
using System.IO;
using System.Threading;

namespace kucunTest.Daojugui
{
    public partial class daojugui : Form
    {
        #region 全局变量
        private MySql Sql = new MySql();//MySQL类
        private BaseAlex Alex = new BaseAlex();
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private string SqlStr = "";
        private string SqlStr1 = "";
        private string cengshu = "";
        private string cengshu2 = "";
        string djgtp = "";

        string tishi = "";
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public daojugui()
        {
            InitializeComponent();
                       
            //生成刀具柜树 
            BindRoot();

            //关闭表格自动生成列
            kcmx.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daojugui_Load(object sender, EventArgs e)
        {
            //记录窗体初始大小值
            asc.controllInitializeSize(this);
        }

        /// <summary>
        /// 新增刀具柜按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xzdjg_Click(object sender, EventArgs e)
        {
            XZDJG xzd = new XZDJG();
            xzd.ShowDialog();

            if(xzd.DialogResult == DialogResult.OK)
            {
                BindRoot();
            }
        }

        #region BindeRoot()方法和AddChild()方法：构造类型（所有类型-->名称-->型号）树
        ///<summary>生成树之生成第一层名称节点</summary>
        private void BindRoot()
        {
            //刷新时重新建立节点
            if (treeView1.Nodes.Count != 0)
            {
                treeView1.Nodes.Clear();//清空树节点
            }

            TreeNode node = new TreeNode();//类型树的根节点。

            treeView1.Nodes.Add(node);
            node.Text = "刀具柜";

            //把数据库中取出所有刀具柜名称
            MySqlDataReader djgmc = Sql.getcom(string.Format("SELECT DISTINCT {1} FROM {0} ORDER BY {1} ASC", DaoJuGui.TableName, DaoJuGui.djgmc));
            //node.Nodes[0].Remove();//移除刚开始建立的第一个空节点
            while (djgmc.Read())
            {
                TreeNode t1 = new TreeNode();
                t1.Text = djgmc[0].ToString();
                node.Nodes.Add(t1);
                AddChild(t1);
            }

            treeView1.Nodes[0].Expand();//默认展开第一层节点
        }

        private void AddChild(TreeNode t1)
        {
            SqlStr = string.Format("SELECT {1} FROM {0} WHERE {2} = '{3}' ORDER BY {1}", DaoJuGuiCengShu.TableName, DaoJuGuiCengShu.djgcs, DaoJuGuiCengShu.djgmc, t1.Text.ToString().Trim());
            MySqlDataReader djgcs = Sql.getcom(SqlStr);
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

        #region treeView1_AfterSelect()方法：根据选择的树节点进行查询
        /// <summary>
        /// 根据选择的树节点进行库存明细查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">当前节点</param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string where = "WHERE weizhibiaoshi = 'S'";//SQL语句条件。默认为空，即第一层节点：所有类型
            string where1 = "WHERE weizhibiaoshi = 'S'";

            if (treeView1.SelectedNode.Level == 1)//当前选中节点为第二层节点：
            {
                DJGMC.Text = e.Node.Text.ToString();
                djgtp = DJGMC.Text + ".jpg";

                where = "WHERE weizhi = '" + e.Node.Text.ToString() + "' AND weizhibiaoshi = 'S'";
                where1 = "WHERE weizhi = '" + e.Node.Text.ToString() + "' AND weizhibiaoshi = 'S'";

                //查询刀具柜基础信息
                SqlStr =  string.Format("SELECT {1} AS djgbm, {2} AS djglx, {3} AS cfsm FROM {0} WHERE {4} = '{5}'", DaoJuGui.TableName, DaoJuGui.djgbm, DaoJuGui.djglx, DaoJuGui.cfsm, DaoJuGui.djgmc, e.Node.Text.ToString());

                //查询当前刀具柜所有层数
                string str = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = '{2}'", DaoJuGuiCengShu.TableName, DaoJuGuiCengShu.djgmc, e.Node.Text.ToString());
                
                //查询存放于此刀具柜的刀具和零部件
                string str1 = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = '{2}'", DaoJuTemp.TableName, DaoJuTemp.weizhibianma, e.Node.Text.ToString());
                string str2 = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = '{2}'", LingBuJianBiao.TableName, LingBuJianBiao.weizhibianma, e.Node.Text.ToString());

                DataTable db = Sql.getDataSet(SqlStr, DaoJuGui.TableName).Tables[0];
                DJGBM.Text = db.Rows[0]["djgbm"].ToString();//刀具柜基础信息--刀具柜编码
                DJGLX.Text = db.Rows[0]["djglx"].ToString();//刀具柜基础信息--刀具柜类型
                CFSM.Text = db.Rows[0]["cfsm"].ToString();//刀具柜基础信息--刀具柜存放说明

                Object a = Sql.ExecuteScalar(str);
                Object b = Sql.ExecuteScalar(str1);
                Object c = Sql.ExecuteScalar(str2);
                string x = a.ToString();
                string y = b.ToString();
                string z = c.ToString();
                DJGZCS.Text = x;
                DJZSL.Text = y;
                LBJZSL.Text = z;

                cengshu = "";
                cengshu2 = "";

                GJLX.SelectedIndex = 0;

                //刀具柜图片
                string FileUrl = System.Windows.Forms.Application.StartupPath + "\\Images\\DaoJuGui\\";
                if (File.Exists(FileUrl + djgtp) == false)
                {
                    daojuguitupian.Image = null;
                    //MessageBox.Show("请导入图片！", "信息提示");
                    return;
                }
                else
                {
                    daojuguitupian.Image = Image.FromFile(FileUrl + djgtp);
                }
            }

            if (treeView1.SelectedNode.Level == 2)//当前选中节点为第三层节点：层数
            {
                cengshu = e.Node.Text.ToString();
                cengshu2 = cengshu.Substring(1);
                where = "WHERE cengshu = '" + e.Node.Text.ToString() + "' AND weizhibiaoshi = 'S' AND weizhi = '" + DJGMC.Text.ToString() + "'";
                where1 = "WHERE cengshu = '" + e.Node.Text.ToString() + "' AND weizhibiaoshi = 'S' AND weizhi = '" + DJGMC.Text.ToString() + "'";

                GJLX.SelectedIndex = 0;
            }

            SqlStr = string.Format("SELECT {1} AS xh, {2} AS daojuid, {3} AS daojuxinghao, {4} AS daojuguige, {5} AS daojuleixing, {6} AS weizhi, CONCAT({6},'--', {7} ) AS daojuweizhi, {8} AS weizhibiaoshi, {9} AS type, {10} AS kcsl, {11} AS zuixiaokucun, {12} AS zuidakucun, {13} AS beizhu FROM {0} {14}", DaoJuTemp.TableName, DaoJuTemp.xh, DaoJuTemp.id, DaoJuTemp.xinghao, DaoJuTemp.guige, DaoJuTemp.leixing, DaoJuTemp.weizhibianma, DaoJuTemp.csordth, DaoJuTemp.weizhibiaoshi, DaoJuTemp.type, DaoJuTemp.kcsl, DaoJuTemp.zxkc, DaoJuTemp.zdkc, DaoJuTemp.bz, where);

            SqlStr1 = String.Format("SELECT {1} AS xh, {2} AS daojuid, {3} AS daojuxinghao, {4} AS daojuguige, {5} AS weizhi, CONCAT({5},'--', {6}) AS daojuweizhi, {7} AS weizhibiaoshi, {8} AS type, {9} AS kcsl, {10} AS zuixiaokucun, {11} AS zuidakucun, {12} AS beizhu FROM {0} {13}",LingBuJianBiao.TableName, LingBuJianBiao.xh, LingBuJianBiao.mc, LingBuJianBiao.xinghao, LingBuJianBiao.gg, LingBuJianBiao.weizhibianma, LingBuJianBiao.cengshu, LingBuJianBiao.weizhibiaoshi, LingBuJianBiao.type, LingBuJianBiao.kcsl, LingBuJianBiao.zxkc, LingBuJianBiao.zdkc, LingBuJianBiao.bz, where1);

            //SqlStr = "SELECT xh, daojuid, daojuxinghao, daojuguige, daojuleixing, weizhi, CONCAT(weizhi,'--', cengshu ) AS daojuweizhi, weizhibiaoshi, type, kcsl, zuixiaokucun, zuidakucun, beizhu FROM daojutemp " + where;
            //SqlStr1 = "SELECT xh, daojuid, daojuxinghao, daojuguige, daojuleixing, weizhi, CONCAT(weizhi,'--', cengshu ) AS daojuweizhi, weizhibiaoshi, type, kcsl, zuixiaokucun, zuidakucun, beizhu FROM jichuxinxi " + where1;
            DataTable db1 = Sql.getDataSet(SqlStr, DaoJuTemp.TableName).Tables[0];
            DataTable db2 = Sql.getDataSet(SqlStr1, LingBuJianBiao.TableName).Tables[0];

            //刀具表和零部件表合并
            db1.Merge(db2);
            kcmx.DataSource = db1.DefaultView;

            //刷新表格颜色
            RefreshColor();
        }

        #endregion

        /// <summary>
        /// 工具类型改变，加载相应的工具名称值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lxcx_SelectedIndexChanged(object sender, EventArgs e)
        {
            tishi = "";

            string cengshu1 = "层";

            if(DJGMC.Text.ToString() == "")
            {
                tishi = "请先选择要查询的刀具柜！";
                MessageBox.Show(tishi);

                return;
            }

            switch(GJLX.SelectedItem.ToString())
            {
                case "全部":
                    GJMC.DataSource = null;
                    break;
                case "刀具":
                    //加载全部刀具名称
                    SqlStr = string.Format("SELECT DISTINCT {1} FROM {0}", DaoJuTemp.TableName, DaoJuTemp.leixing);
                    GJMC.DataSource = Sql.DataReadList(SqlStr);
                    GJMC.SelectedIndex = -1;
                    break;
                case "零部件":
                    //加载全部零部件名称
                    SqlStr = string.Format("SELECT DISTINCT {1} FROM {0}", LingBuJianBiao.TableName, LingBuJianBiao.mc);
                    GJMC.DataSource = Sql.DataReadList(SqlStr);
                    GJMC.SelectedIndex = -1;
                    break;
            }
            
            if (cengshu1 != cengshu2)
            {
                if (GJLX.SelectedItem.ToString() == "全部")
                {
                    SqlStr = string.Format("SELECT {1} AS xh, {2} AS daojuid, {3} AS daojuxinghao, {4} AS daojuguige, {5} AS daojuleixing, {6} AS weizhi, CONCAT({6},'--', {7} ) AS daojuweizhi, {8} AS weizhibiaoshi, {9} AS type, {10} AS kcsl, {11} AS zuixiaokucun, {12} AS zuidakucun, {13} AS beizhu FROM {0} WHERE {6} = '{14}' AND {8} = 'S'", DaoJuTemp.TableName, DaoJuTemp.xh, DaoJuTemp.id, DaoJuTemp.xinghao, DaoJuTemp.guige, DaoJuTemp.leixing, DaoJuTemp.weizhibianma, DaoJuTemp.csordth, DaoJuTemp.weizhibiaoshi, DaoJuTemp.type, DaoJuTemp.kcsl, DaoJuTemp.zxkc, DaoJuTemp.zdkc, DaoJuTemp.bz, DJGMC.Text.ToString());

                    SqlStr1 = String.Format("SELECT {1} AS xh, {2} AS daojuid, {3} AS daojuxinghao, {4} AS daojuguige, {5} AS weizhi, CONCAT({5},'--', {6}) AS daojuweizhi, {7} AS weizhibiaoshi, {8} AS type, {9} AS kcsl, {10} AS zuixiaokucun, {11} AS zuidakucun, {12} AS beizhu FROM {0} WHERE {5} = '{13}' AND {7} = 'S'", LingBuJianBiao.TableName, LingBuJianBiao.xh, LingBuJianBiao.mc, LingBuJianBiao.xinghao, LingBuJianBiao.gg, LingBuJianBiao.weizhibianma, LingBuJianBiao.cengshu, LingBuJianBiao.weizhibiaoshi, LingBuJianBiao.type, LingBuJianBiao.kcsl, LingBuJianBiao.zxkc, LingBuJianBiao.zdkc, LingBuJianBiao.bz, DJGMC.Text.ToString());

                    //SqlStr = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM daojutemp  where weizhi = '" + DJGMC.Text.ToString() + "' AND weizhibiaoshi = 'S'";
                    //SqlStr1 = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM jichuxinxi  where weizhi = '" + DJGMC.Text.ToString() + "' AND weizhibiaoshi = 'S'";
                    DataTable db1 = Sql.getDataSet1(SqlStr).Tables[0];
                    DataTable db2 = Sql.getDataSet1(SqlStr1).Tables[0];
                    db1.Merge(db2);
                    kcmx.DataSource = db1.DefaultView;

                    RefreshColor();

                }
                if (GJLX.SelectedItem.ToString() == "刀具")
                {
                    SqlStr = string.Format("SELECT {1} AS xh, {2} AS daojuid, {3} AS daojuxinghao, {4} AS daojuguige, {5} AS daojuleixing, {6} AS weizhi, CONCAT({6},'--', {7} ) AS daojuweizhi, {8} AS weizhibiaoshi, {9} AS type, {10} AS kcsl, {11} AS zuixiaokucun, {12} AS zuidakucun, {13} AS beizhu FROM {0} WHERE {6} = '{14}' AND {8} = 'S'", DaoJuTemp.TableName, DaoJuTemp.xh, DaoJuTemp.id, DaoJuTemp.xinghao, DaoJuTemp.guige, DaoJuTemp.leixing, DaoJuTemp.weizhibianma, DaoJuTemp.csordth, DaoJuTemp.weizhibiaoshi, DaoJuTemp.type, DaoJuTemp.kcsl, DaoJuTemp.zxkc, DaoJuTemp.zdkc, DaoJuTemp.bz, DJGMC.Text.ToString());

                    //SqlStr = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM daojutemp  where weizhi = '" + DJGMC.Text.ToString() + "' AND weizhibiaoshi = 'S'";
                    kcmx.DataSource = Sql.getDataSet1(SqlStr).Tables[0].DefaultView;

                    RefreshColor();                  
                }
                if (GJLX.SelectedItem.ToString() == "零部件")
                {
                    SqlStr = String.Format("SELECT {1} AS xh, {2} AS daojuid, {3} AS daojuxinghao, {4} AS daojuguige, {5} AS weizhi, CONCAT({5},'--', {6}) AS daojuweizhi, {7} AS weizhibiaoshi, {8} AS type, {9} AS kcsl, {10} AS zuixiaokucun, {11} AS zuidakucun, {12} AS beizhu FROM {0} WHERE {5} = '{13}' AND {7} = 'S'", LingBuJianBiao.TableName, LingBuJianBiao.xh, LingBuJianBiao.mc, LingBuJianBiao.xinghao, LingBuJianBiao.gg, LingBuJianBiao.weizhibianma, LingBuJianBiao.cengshu, LingBuJianBiao.weizhibiaoshi, LingBuJianBiao.type, LingBuJianBiao.kcsl, LingBuJianBiao.zxkc, LingBuJianBiao.zdkc, LingBuJianBiao.bz, DJGMC.Text.ToString());

                    //SqlStr = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM jichuxinxi  where weizhi = '" + DJGMC.Text.ToString() + "' AND weizhibiaoshi = 'S'";
                    kcmx.DataSource = Sql.getDataSet1(SqlStr).Tables[0].DefaultView;

                    RefreshColor();
                }
            }
            else
            {
                if (GJLX.SelectedItem.ToString() == "全部")
                {
                    SqlStr = string.Format("SELECT {1} AS xh, {2} AS daojuid, {3} AS daojuxinghao, {4} AS daojuguige, {5} AS daojuleixing, {6} AS weizhi, CONCAT({6},'--', {7} ) AS daojuweizhi, {8} AS weizhibiaoshi, {9} AS type, {10} AS kcsl, {11} AS zuixiaokucun, {12} AS zuidakucun, {13} AS beizhu FROM {0} WHERE {6} = '{14}' AND {8} = 'S'", DaoJuTemp.TableName, DaoJuTemp.xh, DaoJuTemp.id, DaoJuTemp.xinghao, DaoJuTemp.guige, DaoJuTemp.leixing, DaoJuTemp.weizhibianma, DaoJuTemp.csordth, DaoJuTemp.weizhibiaoshi, DaoJuTemp.type, DaoJuTemp.kcsl, DaoJuTemp.zxkc, DaoJuTemp.zdkc, DaoJuTemp.bz, DJGMC.Text.ToString());

                    SqlStr1 = String.Format("SELECT {1} AS xh, {2} AS daojuid, {3} AS daojuxinghao, {4} AS daojuguige, {5} AS weizhi, CONCAT({5},'--', {6}) AS daojuweizhi, {7} AS weizhibiaoshi, {8} AS type, {9} AS kcsl, {10} AS zuixiaokucun, {11} AS zuidakucun, {12} AS beizhu FROM {0} WHERE {5} = '{13}' AND {7} = 'S'", LingBuJianBiao.TableName, LingBuJianBiao.xh, LingBuJianBiao.mc, LingBuJianBiao.xinghao, LingBuJianBiao.gg, LingBuJianBiao.weizhibianma, LingBuJianBiao.cengshu, LingBuJianBiao.weizhibiaoshi, LingBuJianBiao.type, LingBuJianBiao.kcsl, LingBuJianBiao.zxkc, LingBuJianBiao.zdkc, LingBuJianBiao.bz, DJGMC.Text.ToString());

                    //SqlStr = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM daojutemp  where weizhi = '" + DJGMC.Text.ToString() + "' and weizhibiaoshi = 'S' and cengshu = '" + cengshu.ToString() + "'";
                    //SqlStr1 = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM jichuxinxi  where weizhi = '" + DJGMC.Text.ToString() + "' and weizhibiaoshi = 'S' and cengshu = '" + cengshu.ToString() + "'";
                    DataTable db1 = Sql.getDataSet1(SqlStr).Tables[0];
                    DataTable db2 = Sql.getDataSet1(SqlStr1).Tables[0];
                    db1.Merge(db2);
                    kcmx.DataSource = db1.DefaultView;

                    RefreshColor();

                }
                if (GJLX.SelectedItem.ToString() == "刀具")
                {
                    SqlStr = string.Format("SELECT {1} AS xh, {2} AS daojuid, {3} AS daojuxinghao, {4} AS daojuguige, {5} AS daojuleixing, {6} AS weizhi, CONCAT({6},'--', {7} ) AS daojuweizhi, {8} AS weizhibiaoshi, {9} AS type, {10} AS kcsl, {11} AS zuixiaokucun, {12} AS zuidakucun, {13} AS beizhu FROM {0} WHERE {6} = '{14}' AND {8} = 'S'", DaoJuTemp.TableName, DaoJuTemp.xh, DaoJuTemp.id, DaoJuTemp.xinghao, DaoJuTemp.guige, DaoJuTemp.leixing, DaoJuTemp.weizhibianma, DaoJuTemp.csordth, DaoJuTemp.weizhibiaoshi, DaoJuTemp.type, DaoJuTemp.kcsl, DaoJuTemp.zxkc, DaoJuTemp.zdkc, DaoJuTemp.bz, DJGMC.Text.ToString());

                    //SqlStr = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM daojutemp  where weizhi = '" + DJGMC.Text.ToString() + "' and weizhibiaoshi = 'S' and cengshu = '" + cengshu.ToString() + "'";
                    kcmx.DataSource = Sql.getDataSet1(SqlStr).Tables[0].DefaultView;

                    RefreshColor();
                }
                if (GJLX.SelectedItem.ToString() == "零部件")
                {
                    SqlStr = String.Format("SELECT {1} AS xh, {2} AS daojuid, {3} AS daojuxinghao, {4} AS daojuguige, {5} AS weizhi, CONCAT({5},'--', {6}) AS daojuweizhi, {7} AS weizhibiaoshi, {8} AS type, {9} AS kcsl, {10} AS zuixiaokucun, {11} AS zuidakucun, {12} AS beizhu FROM {0} WHERE {5} = '{13}' AND {7} = 'S'", LingBuJianBiao.TableName, LingBuJianBiao.xh, LingBuJianBiao.mc, LingBuJianBiao.xinghao, LingBuJianBiao.gg, LingBuJianBiao.weizhibianma, LingBuJianBiao.cengshu, LingBuJianBiao.weizhibiaoshi, LingBuJianBiao.type, LingBuJianBiao.kcsl, LingBuJianBiao.zxkc, LingBuJianBiao.zdkc, LingBuJianBiao.bz, DJGMC.Text.ToString());

                    //SqlStr = "SELECT xh,daojuid,daojuxinghao,daojuguige,daojuleixing,weizhi,concat(weizhi,'--', cengshu ) as daojuweizhi,weizhibiaoshi,type,kcsl,zuixiaokucun,zuidakucun,beizhu FROM jichuxinxi  where weizhi = '" + DJGMC.Text.ToString() + "' and weizhibiaoshi = 'S' and cengshu = '" + cengshu.ToString() + "'";
                    kcmx.DataSource = Sql.getDataSet1(SqlStr).Tables[0].DefaultView;
                    
                    RefreshColor();
                }

            }
        }

        /// <summary>
        /// 窗体在tabpage页中打开则一并关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daojugui_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Parent != null)
            {
                MainForm mfr = (MainForm)this.Parent.FindForm();
                mfr.CloseTab(this.Name);
            }
        }

        /// <summary>
        /// 窗体大小变化自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daojugui_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        /// <summary>
        /// 导入图片按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (DJGMC.Text == "")
            {
                tishi = "请先选择要删除的刀具柜！";
                MessageBox.Show(tishi);
                return;
            }

            using (OpenFileDialog lvse = new OpenFileDialog())
            {
                lvse.Title = "请选择刀具柜图片";
                lvse.InitialDirectory = "";
                lvse.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
                lvse.FilterIndex = 1;

                if (lvse.ShowDialog() == DialogResult.OK)
                {
                    //MySQL_Helper mysql = new MySQL_Helper();
                    //mysql.Record_Insert(MySQL_Helper.base_mode, this.Tag.ToString(), MySQL_Helper.type_operate, "36", "");
                    if (daojuguitupian.Image != null)
                    {
                        Image img = daojuguitupian.Image;
                        daojuguitupian.Image = null;
                        img.Dispose();
                    }
                    Thread.Sleep(200);
                    daojuguitupian.Image = Image.FromFile(lvse.FileName);
                    Picture_Save(djgtp);
                }
            }
        }

        /// <summary>
        /// 图片保存
        /// </summary>
        /// <param name="filename"></param>
        private void Picture_Save(string filename)
        {

            Bitmap bit = new Bitmap(daojuguitupian.ClientRectangle.Width, daojuguitupian.ClientRectangle.Height);
            daojuguitupian.DrawToBitmap(bit, daojuguitupian.ClientRectangle);

            //没有文件夹，新建文件夹
            if (Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Images\\DaoJuGui") == false)
            {
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Images\\DaoJuGui");
            }

            string str_iniFileUrl = System.Windows.Forms.Application.StartupPath + "\\Images\\DaoJuGui\\";

            //图片保存：若已存在此命名图片则先删除
            if (System.IO.File.Exists(str_iniFileUrl + filename))
            {
                System.IO.File.Delete(filename);
            }
            bit.Save(str_iniFileUrl + filename);

        }

        /// <summary>
        /// 根据库存数量显示不同颜色:低于最小库存的以红色突出显示
        /// </summary>
        private void RefreshColor()
        {
            for (int i = 0; i < kcmx.Rows.Count; i++)
            {
                // this.daojuxinxi.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                string sl = kcmx.Rows[i].Cells["kcsl"].Value.ToString();
                string zxkc = kcmx.Rows[i].Cells["zxkc"].Value.ToString();
                int shuliang = Convert.ToInt32(sl);
                int zxshuliang = Convert.ToInt32(zxkc);
                if (shuliang < zxshuliang)
                {
                    //this.daojuxinxi.Columns[3].DefaultCellStyle.BackColor = Color.Red;
                    kcmx.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        /// <summary>
        /// 删除刀具柜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
        {
            tishi = "";

            if (DJGMC.Text == "")
            {
                tishi = "请先选择要删除的刀具柜！";
                MessageBox.Show(tishi);
                return;
            }

            tishi = string.Format("确定删除刀具柜：“{0}”？", DJGMC.Text);

            string mc = DJGMC.Text.ToString();
            int row = 0;

            if(MessageBox.Show(tishi, "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //判断刀具柜是否有存刀具或零部件
                //if(Alex.CunZai(DaoJuGuiCengShu.TableName, string.Format("{0} = '{1}'", DaoJuGuiCengShu.djgmc, mc)) != 0)
                //{
                    //从刀具柜层数表中删除
                    SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", DaoJuGuiCengShu.TableName, DaoJuGuiCengShu.djgmc, mc);
                    row = Sql.ExecuteNonQuery(SqlStr);
                //}                

                //从刀具柜表中删除
                SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", DaoJuGui.TableName, DaoJuGui.djgmc, mc);
                row = Sql.ExecuteNonQuery(SqlStr);

                //删除图片：若已存在此图片则先删除
                string str_iniFileUrl = System.Windows.Forms.Application.StartupPath + "\\Images\\DaoJuGui\\";
                if (System.IO.File.Exists(str_iniFileUrl + mc + ".jpg"))
                {
                    System.IO.File.Delete(mc + ".jpg");
                }

                tishi = "删除成功！";
                MessageBox.Show(tishi);

                BindRoot();
            }
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_search_Click(object sender, EventArgs e)
        {
            if(GJLX.SelectedIndex < 0)
            {
                GJLX.SelectedIndex = 0;
            }

            string gjlx = GJLX.SelectedItem.ToString();
            switch(gjlx)
            {
                case "全部":
                    GJXH.Text = "";

                    SqlStr = string.Format("SELECT {1} AS xh, {2} AS daojuid, {3} AS daojuxinghao, {4} AS daojuguige, {5} AS daojuleixing, {6} AS weizhi, CONCAT({6},'--', {7} ) AS daojuweizhi, {8} AS weizhibiaoshi, {9} AS type, {10} AS kcsl, {11} AS zuixiaokucun, {12} AS zuidakucun, {13} AS beizhu FROM {0} WHERE {6} = '{14}' AND {8} = 'S'", DaoJuTemp.TableName, DaoJuTemp.xh, DaoJuTemp.id, DaoJuTemp.xinghao, DaoJuTemp.guige, DaoJuTemp.leixing, DaoJuTemp.weizhibianma, DaoJuTemp.csordth, DaoJuTemp.weizhibiaoshi, DaoJuTemp.type, DaoJuTemp.kcsl, DaoJuTemp.zxkc, DaoJuTemp.zdkc, DaoJuTemp.bz, DJGMC.Text.ToString());

                    SqlStr1 = String.Format("SELECT {1} AS xh, {2} AS daojuid, {3} AS daojuxinghao, {4} AS daojuguige, {5} AS weizhi, CONCAT({5},'--', {6}) AS daojuweizhi, {7} AS weizhibiaoshi, {8} AS type, {9} AS kcsl, {10} AS zuixiaokucun, {11} AS zuidakucun, {12} AS beizhu FROM {0} WHERE {5} = '{13}' AND {7} = 'S'", LingBuJianBiao.TableName, LingBuJianBiao.xh, LingBuJianBiao.mc, LingBuJianBiao.xinghao, LingBuJianBiao.gg, LingBuJianBiao.weizhibianma, LingBuJianBiao.cengshu, LingBuJianBiao.weizhibiaoshi, LingBuJianBiao.type, LingBuJianBiao.kcsl, LingBuJianBiao.zxkc, LingBuJianBiao.zdkc, LingBuJianBiao.bz, DJGMC.Text.ToString());

                    DataTable db1 = Sql.getDataSet1(SqlStr).Tables[0];
                    DataTable db2 = Sql.getDataSet1(SqlStr1).Tables[0];
                    db1.Merge(db2);
                    kcmx.DataSource = db1.DefaultView;
                    break;
                case "刀具":
                    SqlStr = string.Format("SELECT {1} AS xh, {2} AS daojuid, {3} AS daojuxinghao, {4} AS daojuguige, {5} AS daojuleixing, {6} AS weizhi, CONCAT({6},'--', {7} ) AS daojuweizhi, {8} AS weizhibiaoshi, {9} AS type, {10} AS kcsl, {11} AS zuixiaokucun, {12} AS zuidakucun, {13} AS beizhu FROM {0} WHERE {6} = '{14}' AND {8} = 'S' AND {5} LIKE '%{15}%' AND {3} LIKE '%{16}%'", DaoJuTemp.TableName, DaoJuTemp.xh, DaoJuTemp.id, DaoJuTemp.xinghao, DaoJuTemp.guige, DaoJuTemp.leixing, DaoJuTemp.weizhibianma, DaoJuTemp.csordth, DaoJuTemp.weizhibiaoshi, DaoJuTemp.type, DaoJuTemp.kcsl, DaoJuTemp.zxkc, DaoJuTemp.zdkc, DaoJuTemp.bz, DJGMC.Text.ToString(), GJMC.Text, GJXH.Text);
                    kcmx.DataSource = Sql.getDataSet1(SqlStr).Tables[0].DefaultView;
                    break;
                case "零部件":
                    SqlStr = String.Format("SELECT {1} AS xh, {2} AS daojuid, {3} AS daojuxinghao, {4} AS daojuguige, {5} AS weizhi, CONCAT({5},'--', {6}) AS daojuweizhi, {7} AS weizhibiaoshi, {8} AS type, {9} AS kcsl, {10} AS zuixiaokucun, {11} AS zuidakucun, {12} AS beizhu FROM {0} WHERE {5} = '{13}' AND {7} = 'S' AND {2} LIKE '%{14}%' AND {3} LIKE '%{15}%'", LingBuJianBiao.TableName, LingBuJianBiao.xh, LingBuJianBiao.mc, LingBuJianBiao.xinghao, LingBuJianBiao.gg, LingBuJianBiao.weizhibianma, LingBuJianBiao.cengshu, LingBuJianBiao.weizhibiaoshi, LingBuJianBiao.type, LingBuJianBiao.kcsl, LingBuJianBiao.zxkc, LingBuJianBiao.zdkc, LingBuJianBiao.bz, DJGMC.Text.ToString(), GJMC.Text, GJXH.Text);
                    kcmx.DataSource = Sql.getDataSet1(SqlStr).Tables[0].DefaultView;
                    break;
            }

            RefreshColor();
        }
    }
}
