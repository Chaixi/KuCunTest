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
        /*--------------------------------------------全局变量-------------------------------------------------------------------------------------------------------*/
        #region 全局变量
        private static MySql SQL = new MySql();//MySQL类
        private AutoSizeFormClass asc = new AutoSizeFormClass();
        private BaseAlex Alex = new BaseAlex();

        private static string SqlStr = "";
        private string tishi = "";//提示内容

        private DataTable gx_db = new DataTable();//存放工序表数据
        private DataTable pd_db = new DataTable();//存放所有工序的配刀表数据
        private DataTable display_pd_db = new DataTable();//存放用于显示的配刀表数据

        bool flag = false;//工艺卡是否修改，默认为false没有修改

        #endregion

        /*--------------------------------------------窗体构造与加载-------------------------------------------------------------------------------------------------------*/
        #region 窗体构造与加载函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public gyk()
        {
            InitializeComponent();

            //生成工艺卡树
            BindRoot();//生成树的第一层

            //禁止表格自动生成列
            gxxx.AutoGenerateColumns = false;
            pdxx.AutoGenerateColumns = false;

            //设置表格数据源结构
            AddColumns();

            //加载工序信息和配刀信息的机床编号列表
            SqlStr = string.Format("SELECT DISTINCT {1} FROM {0}", JiChuangBiao.TableName, JiChuangBiao.jcbm);
            List<string> l1 = SQL.DataReadList(SqlStr);
            JCBH.DataSource = l1;
            JCBH.SelectedIndex = -1;
            SqlStr = "";

            //加载配刀信息的机床编号列表:二者不可共用一个数据源，否则会同步变化
            List<string> l2 = new List<string>(l1.ToArray());
            JCBM.DataSource = l2;
            JCBM.SelectedIndex = -1;
        }
        
        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gyk_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);            
        }

        #endregion 窗体构造与加载函数结束

        /*-----------------------------------------------------------------树相关----------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// 生成树之生成第一层名称节点[构造类型（所有类型-->名称-->型号）树]
        /// </summary>
        private void BindRoot()
        {
            //刷新时重新建立节点
            if (treeView1.Nodes.Count != 0)
            {
                treeView1.Nodes.Clear();//清空树节点
                //treeView1.Nodes.Remove(treeView1.Nodes[0]);//清空树节点
            }

            TreeNode node = new TreeNode();//类型树的根节点
            treeView1.Nodes.Add(node);
            node.Text = "工艺卡编号";

            SqlStr = string.Format("SELECT DISTINCT {1} FROM {0}", GongYiKa.TableName, GongYiKa.gykbh);
            MySqlDataReader scx = SQL.getcom(SqlStr);
            //node.Nodes[0].Remove();//移除刚开始建立的第一个空节点
            while (scx.Read())
            {
                TreeNode t1 = new TreeNode();
                t1.Text = scx[0].ToString();
                node.Nodes.Add(t1);
                AddChild(t1);
            }

            treeView1.Nodes[0].Expand();//默认展开第一层节点
        }

        /// <summary>
        /// 生成子节点
        /// </summary>
        /// <param name="t1"></param>
        private void AddChild(TreeNode t1)
        {
            SqlStr = string.Format("SELECT {1} FROM {0} WHERE {2} ='{3}'", GongXu.TableName, GongXu.gxbh, GongXu.gykbh, t1.Text.ToString().Trim());
            MySqlDataReader jcbm = SQL.getcom(SqlStr);
            while (jcbm.Read())
            {
                TreeNode t2 = new TreeNode();
                t2.Text = jcbm[0].ToString();
                t1.Nodes.Add(t2);
            }
        }
        
        /// <summary>
        /// 根据选择的树节点进行工艺卡查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">当前节点</param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tishi = "";
            string gyk = "";

            //判断是否对上一个做了修改的工艺卡进行保存，提示保存再加载新数据
            if(flag)
            {
                tishi = "工艺卡‘" + GYKBH.Text + "’已修改，是否保存？";
                DialogResult dr = MessageBox.Show(tishi, "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    btn_gyk_Save_Click(null, null);

                    return;
                }
            }

            if (treeView1.SelectedNode.Level == 0)//当前选中节点为根节点：所有工艺卡
            {
                return;
            }
            else if (treeView1.SelectedNode.Level == 1)//当前选中节点为第二层节点：工艺卡编号
            {
                gyk = e.Node.Text.ToString();
            }
            else if (treeView1.SelectedNode.Level == 2)//当前选中节点为第三层节点：工序号
            {
                gyk = e.Node.Parent.Text.ToString();//父节点为工艺卡编号

                //SqlStr = "select * from gongxu where gykbh =  '" + GYKBH.Text.ToString() + "' and gxh = '" + e.Node.Text.ToString() + "'";
                //string SqlStr1 = "select * from gongxupeidao where gykbh =  '" + GYKBH.Text.ToString() + "' and gxh = '" + e.Node.Text.ToString() + "'";
                //gxxx.DataSource = SQL.getDataSet1(SqlStr).Tables[0].DefaultView;
                //pdxx.DataSource = SQL.getDataSet1(SqlStr1).Tables[0].DefaultView;
            }

            //填充工艺卡基本信息
            SqlStr = string.Format("SELECT {1} AS gykbh, {2} AS jgljlx, {3} AS cjsj, {4} AS shuoming FROM {0} WHERE {5} = '{6}'", GongYiKa.TableName, GongYiKa.gykbh, GongYiKa.jgljlx, GongYiKa.cjsj, GongYiKa.gyksm, GongYiKa.gykbh, gyk);
            DataTable db1 = SQL.getDataSet(SqlStr, GongYiKa.TableName).Tables[0];
            SqlStr = "";

            GYKBH.Text = db1.Rows[0]["gykbh"].ToString();
            JGLJLX.Text = db1.Rows[0]["jgljlx"].ToString();
            GYKSM.Text = db1.Rows[0]["shuoming"].ToString();
            CJSJ.Value = Convert.ToDateTime(db1.Rows[0]["cjsj"].ToString());

            //填充工序表信息
            SqlStr = string.Format("SELECT {9} AS xh, {8} AS gykbh, {1} AS gxh, {2} AS jgljh, {3} AS jgljmc, {4} AS jcbm, {5} AS gxnr FROM {0} WHERE {6} =  '{7}' ORDER BY {1} ASC", GongXu.TableName, GongXu.gxbh, GongXu.jgljh, GongXu.jgljmc, GongXu.jcbm, GongXu.gxnr, GongXu.gykbh, gyk, GongXu.gykbh, GongXu.xh);
            gx_db.Clear();//清除历史数据
            gx_db = SQL.getDataSet(SqlStr, GongXu.TableName).Tables[0];
            gxxx.DataSource = gx_db.DefaultView;//重新绑定，刷新显示
            SqlStr = "";

            //填充配刀表信息：第一次加载盘【配刀表数据，需要查询数据库将所有配刀数据加载到pd_db表中，再根据需要显示
            SqlStr = string.Format("SELECT {13} AS xh, {1} AS gykbh, {2} AS gxh, {3} AS gjlx, {4} AS gjmc, {5} AS gjgg, {6} AS gjxh, {7} AS sl, {12} AS dw, {8} AS jcbm, {9} AS dth, {10} AS gjsm FROM {0} WHERE {1} = '{11}' ORDER BY {2} ASC", GongxuPeiDao.TableName, GongxuPeiDao.gykbh, GongxuPeiDao.gxh, GongxuPeiDao.gjlx, GongxuPeiDao.gjmc, GongxuPeiDao.gjgg, GongxuPeiDao.gjxh, GongxuPeiDao.sl, GongxuPeiDao.jcbm, GongxuPeiDao.dth, GongxuPeiDao.gjsm, gyk, GongxuPeiDao.dw, GongxuPeiDao.xh);
            pd_db.Clear();
            pd_db = SQL.getDataSet(SqlStr, GongxuPeiDao.TableName).Tables[0];
            pdxx.DataSource = pd_db.DefaultView;
            //DisplayPDList();//显示所有配刀数据
            SqlStr = "";
        }

        /*--------------------------------------------------------------工艺卡基本信息-------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// 工艺卡新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_gyk_New_Click(object sender, EventArgs e)
        {
            tishi = "";

            //检查工艺卡基本信息：工艺卡编号不可为空
            if (GYKBH.Text == "" || GYKBH == null)
            {
                tishi = "请填写工艺卡编号！";
                MessageBox.Show(tishi);
                GYKBH.Focus();

                return;
            }

            //新增确认
            if (MessageBox.Show("确认新增工艺卡？", "保存确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //判断工艺卡编号(文本框中的内容)是否已经存在，若存在，提示并返回，若不存在则保存为新工艺卡
                string conditions = string.Format("{0} = '{1}'", GongYiKa.gykbh, GYKBH.Text);
                if (Alex.CunZai(table: GongYiKa.TableName, conditions: conditions) == 0)
                {
                    //保存为新的工艺卡
                    InsertGyk();
                    //重新生成树节点
                    BindRoot();
                }
                else//修改后的工艺卡编号已存在，提示并返回
                {
                    tishi = "工艺卡编号已存在，请重新修改工艺卡编号！";
                    MessageBox.Show(tishi);
                    GYKBH.Focus();
                    GYKBH.SelectAll();
                }
            }
        }

        /// <summary>
        /// 工艺卡保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_gyk_Save_Click(object sender, EventArgs e)
        {
            string tishi = "";
            string crtGykbh = "";//选中的当前树节点的工艺卡编号

            if(treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Level == 1)//选中的是第一层树节点：工艺卡编号
                {
                    crtGykbh = treeView1.SelectedNode.Text.ToString();
                }
                else if (treeView1.SelectedNode.Level == 2)//选中的是第二层树节点：工序号，其父节点为工艺卡编号
                {
                    crtGykbh = treeView1.SelectedNode.Parent.Text.ToString();
                }
                else
                {
                    if (MessageBox.Show("未选择要保存的工艺卡编号，是否保存为新的工艺卡！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //保存为新的工艺卡
                        InsertGyk();
                        //重新生成树节点
                        BindRoot();
                    }

                    return;
                }
            }
            else
            {
                if(MessageBox.Show("未选择要保存的工艺卡编号，是否保存为新的工艺卡！", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //保存为新的工艺卡
                    InsertGyk();
                    //重新生成树节点
                    BindRoot();
                }

                return;
            }

            //检查工艺卡基本信息：工艺卡编号不可为空
            if(GYKBH.Text == "" || GYKBH == null)
            {
                tishi = "请填写工艺卡编号！";
                MessageBox.Show(tishi);
                GYKBH.Focus();
                return;
            }

            //保存确认
            if(MessageBox.Show("确认修改并保存？", "修改确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //判断文本框中的工艺卡编号是否修改，无修改直接更新，有修改，则判断修改后编号是否已经存在,若存在则提示已存在，不存在则提示是否需要保存为新工艺卡，是则保存为新的，否则直接更新
                //判断工艺卡编号是否有修改，有修改则继续判断修改的工艺卡编号是否存在
                #region
                if (GYKBH.Text != crtGykbh)
                {
                    //判断修改后的工艺卡编号(文本框中的内容)是否已经存在，若存在，提示并返回，若不存在则提示是否保存为新卡
                    #region
                    string conditions = string.Format("{0} = '{1}'", GongYiKa.gykbh, GYKBH.Text);
                    if (Alex.CunZai(table: GongYiKa.TableName, conditions: conditions) == 0)
                    {
                        //提示是否保存为新工艺卡，是则用INSERT， 否则直接更新
                        #region 

                        DialogResult dr = MessageBox.Show("当前工艺卡编号不存在，是否保存为新的工艺卡？\n点击‘是’则保存为新工艺卡，点击‘否’则更新当前工艺卡。", "提示", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes)
                        {
                            //保存为新的工艺卡
                            InsertGyk();
                            //重新生成树节点
                            BindRoot();
                        }
                        else if(dr == DialogResult.No)//直接更新当前工艺卡
                        {
                            //更新三表：参数用crtGykbh，更新条件中要用旧的工艺卡编号crtGykbh
                            UpdateGyk(oldGykbh: crtGykbh);
                            //重新生成树
                            BindRoot();
                        }

                        #endregion
                    }
                    else//修改后的工艺卡编号已存在，提示并返回
                    {
                        tishi = "工艺卡编号已存在，请重新修改工艺卡编号！";
                        MessageBox.Show(tishi);
                        GYKBH.Focus();
                        GYKBH.SelectAll();
                    }
                    #endregion
                }
                else//没有修改，则直接update
                {
                    //更新三表:参数用crtGykbh或GYKBH.Text均可，二者一致
                    UpdateGyk(oldGykbh: crtGykbh);
                    //重新生成树
                    BindRoot();
                }

                #endregion
            }
        }

        /// <summary>
        /// 数据直接当做新行插入工艺卡表、工序表、配刀表
        /// </summary>
        /// <param name="gykbh"></param>
        private void InsertGyk()
        {
            int row = 0;
            string gykbh = GYKBH.Text.Trim();

            #region 插入配刀表
            //数据检查
            if (pd_db.Rows.Count == 0)
            {
                MessageBox.Show("当前配刀表为空，请填写配刀信息！");
                GJLX.Focus();

                return;
            }

            //先删除已存在的配刀表
            SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", GongxuPeiDao.TableName, GongxuPeiDao.gykbh, gykbh);
            row = SQL.ExecuteNonQuery(SqlStr);

            //后插入所有配刀数据行
            string pd_gxh = "";//工序号
            string pd_gjlx = "";//工具类型
            string pd_gjmc = "";//工具名称
            string pd_gjgg = "";//工具规格
            string pd_gjxh = "";//工具型号
            string pd_jcbm = "";//机床编码
            string pd_dth = "";//刀套号
            string pd_sl = "";//数量
            string pd_dw = "";//单位
            string pd_gjsm = "";//工具说明
            for (int i = 0; i < pd_db.Rows.Count; i++)
            {
                //数据预处理
                pd_gxh = pd_db.Rows[i]["gxh"].ToString();
                pd_gjlx = pd_db.Rows[i]["gjlx"].ToString();
                pd_gjmc = pd_db.Rows[i]["gjmc"].ToString();
                pd_gjgg = pd_db.Rows[i]["gjgg"].ToString();
                pd_gjxh = pd_db.Rows[i]["gjxh"].ToString();
                pd_jcbm = pd_db.Rows[i]["jcbm"].ToString();
                pd_dth = pd_db.Rows[i]["dth"].ToString();
                pd_sl = pd_db.Rows[i]["sl"].ToString();
                pd_dw = pd_db.Rows[i]["dw"].ToString();
                pd_gjsm = pd_db.Rows[i]["gjsm"].ToString();

                //插入数据表
                SqlStr = string.Format("INSERT INTO {0}({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}) VALUES('{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}')", GongxuPeiDao.TableName, GongxuPeiDao.gykbh, GongxuPeiDao.gxh, GongxuPeiDao.gjlx, GongxuPeiDao.gjmc, GongxuPeiDao.gjgg, GongxuPeiDao.gjxh, GongxuPeiDao.jcbm, GongxuPeiDao.dth, GongxuPeiDao.sl, GongxuPeiDao.dw, GongxuPeiDao.gjsm, gykbh, pd_gxh, pd_gjlx, pd_gjmc, pd_gjgg, pd_gjxh, pd_jcbm, pd_dth, pd_sl, pd_dw, pd_gjsm);
                row = SQL.ExecuteNonQuery(SqlStr);
                SqlStr = "";
            }
            #endregion 插入配刀表结束

            #region 插入工序表
            //数据检查
            if (gx_db.Rows.Count == 0)
            {
                MessageBox.Show("当前工序表为空，请填写工序信息！");
                GXBH.Focus();

                return;
            }

            //先删除已存在的工序
            SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", GongXu.TableName, GongXu.gykbh, gykbh);
            row = SQL.ExecuteNonQuery(SqlStr);

            //后插入所有工序
            string gx_gxh = "";//工序号
            string gx_jgljh = "";//加工零件号
            string gx_jgljmc = "";//加工零件名称
            string gx_jcbm = "";//机床编码
            string gx_gxnr = "";//工序内容
            for (int i = 0; i < gx_db.Rows.Count; i++)
            {
                //数据预处理
                gx_gxh = gx_db.Rows[i]["gxh"].ToString();
                gx_jgljh = gx_db.Rows[i]["jgljh"].ToString();
                gx_jgljmc = gx_db.Rows[i]["jgljmc"].ToString();
                gx_jcbm = gx_db.Rows[i]["jcbm"].ToString();
                gx_gxnr = gx_db.Rows[i]["gxnr"].ToString();

                //插入数据表
                SqlStr = string.Format("INSERT INTO {0}({1}, {2}, {3}, {4}, {5}, {6}) VALUES('{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", GongXu.TableName, GongXu.gykbh, GongXu.gxbh, GongXu.jgljh, GongXu.jgljmc, GongXu.jcbm, GongXu.gxnr, gykbh, gx_gxh, gx_jgljh, gx_jgljmc, gx_jcbm, gx_gxnr);
                row = SQL.ExecuteNonQuery(SqlStr);
                SqlStr = "";
            }
            #endregion 插入工序表结束

            #region 插入工艺卡表
            //数据预处理
            string jgljlx = JGLJLX.Text.ToString();
            string cjsj = CJSJ.Value.ToString();
            string gyksm = GYKSM.Text.ToString();

            SqlStr = string.Format("INSERT INTO {0}({1}, {2}, {3}, {4}) VALUES('{5}', '{6}', '{7}', '{8}')", GongYiKa.TableName, GongYiKa.gykbh, GongYiKa.jgljlx, GongYiKa.cjsj, GongYiKa.gyksm, gykbh, jgljlx, cjsj, gyksm);
            row = SQL.ExecuteNonQuery(SqlStr);
            SqlStr = "";
            #endregion 插入工艺卡表结束
        }

        /// <summary>
        /// 更新工艺卡表
        /// </summary>
        /// <param name="gykbh"></param>
        private void UpdateGyk(string oldGykbh)
        {
            int row = 0;
            string newGykbh = GYKBH.Text.Trim();

            #region 更新配刀表：先删除，后插入
            //数据检查
            if (pd_db.Rows.Count == 0)
            {
                MessageBox.Show("当前配刀表为空，请填写配刀信息！");
                GJLX.Focus();

                return;
            }

            //先删除已存在的配刀表
            SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", GongxuPeiDao.TableName, GongxuPeiDao.gykbh, oldGykbh);
            row = SQL.ExecuteNonQuery(SqlStr);

            //后插入所有配刀数据行
            string pd_gxh = "";//工序号
            string pd_gjlx = "";//工具类型
            string pd_gjmc = "";//工具名称
            string pd_gjgg = "";//工具规格
            string pd_gjxh = "";//工具型号
            string pd_jcbm = "";//机床编码
            string pd_dth = "";//刀套号
            string pd_sl = "";//数量
            string pd_dw = "";//单位
            string pd_gjsm = "";//工具说明
            for (int i = 0; i < pd_db.Rows.Count; i++)
            {
                //数据预处理
                pd_gxh = pd_db.Rows[i]["gxh"].ToString();
                pd_gjlx = pd_db.Rows[i]["gjlx"].ToString();
                pd_gjmc = pd_db.Rows[i]["gjmc"].ToString();
                pd_gjgg = pd_db.Rows[i]["gjgg"].ToString();
                pd_gjxh = pd_db.Rows[i]["gjxh"].ToString();
                pd_jcbm = pd_db.Rows[i]["jcbm"].ToString();
                pd_dth = pd_db.Rows[i]["dth"].ToString();
                pd_sl = pd_db.Rows[i]["sl"].ToString();
                pd_dw = pd_db.Rows[i]["dw"].ToString();
                pd_gjsm = pd_db.Rows[i]["gjsm"].ToString();

                //插入数据表
                SqlStr = string.Format("INSERT INTO {0}({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}) VALUES('{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}')", GongxuPeiDao.TableName, GongxuPeiDao.gykbh, GongxuPeiDao.gxh, GongxuPeiDao.gjlx, GongxuPeiDao.gjmc, GongxuPeiDao.gjgg, GongxuPeiDao.gjxh, GongxuPeiDao.jcbm, GongxuPeiDao.dth, GongxuPeiDao.sl, GongxuPeiDao.dw, GongxuPeiDao.gjsm, newGykbh, pd_gxh, pd_gjlx, pd_gjmc, pd_gjgg, pd_gjxh, pd_jcbm, pd_dth, pd_sl, pd_dw, pd_gjsm);
                row = SQL.ExecuteNonQuery(SqlStr);
                SqlStr = "";
            }
            #endregion 更新配刀表结束

            #region 更新工序表
            //数据检查
            if (gx_db.Rows.Count == 0)
            {
                MessageBox.Show("当前工序表为空，请填写工序信息！");
                GXBH.Focus();

                return;
            }

            //先删除已存在的工序
            SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", GongXu.TableName, GongXu.gykbh, oldGykbh);
            row = SQL.ExecuteNonQuery(SqlStr);

            //后插入所有工序
            string gx_gxh = "";//工序号
            string gx_jgljh = "";//加工零件号
            string gx_jgljmc = "";//加工零件名称
            string gx_jcbm = "";//机床编码
            string gx_gxnr = "";//工序内容
            for (int i = 0; i < gx_db.Rows.Count; i++)
            {
                //数据预处理
                gx_gxh = gx_db.Rows[i]["gxh"].ToString();
                gx_jgljh = gx_db.Rows[i]["jgljh"].ToString();
                gx_jgljmc = gx_db.Rows[i]["jgljmc"].ToString();
                gx_jcbm = gx_db.Rows[i]["jcbm"].ToString();
                gx_gxnr = gx_db.Rows[i]["gxnr"].ToString();

                //插入数据表
                SqlStr = string.Format("INSERT INTO {0}({1}, {2}, {3}, {4}, {5}, {6}) VALUES('{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", GongXu.TableName, GongXu.gykbh, GongXu.gxbh, GongXu.jgljh, GongXu.jgljmc, GongXu.jcbm, GongXu.gxnr, newGykbh, gx_gxh, gx_jgljh, gx_jgljmc, gx_jcbm, gx_gxnr);
                row = SQL.ExecuteNonQuery(SqlStr);
                SqlStr = "";
            }
            #endregion 更新工序表结束

            #region 更新工艺卡表
            //数据预处理
            string jgljlx = JGLJLX.Text.ToString();
            string cjsj = CJSJ.Value.ToString();
            string gyksm = GYKSM.Text.ToString();

            SqlStr = string.Format("UPDATE {0} SET {1} = '{5}', {2} =  '{6}', {3} = '{7}', {4} = '{8}' WHERE {1} = '{9}'", GongYiKa.TableName, GongYiKa.gykbh, GongYiKa.jgljlx, GongYiKa.cjsj, GongYiKa.gyksm, newGykbh, jgljlx, cjsj, gyksm, oldGykbh);
            row = SQL.ExecuteNonQuery(SqlStr);
            SqlStr = "";
            #endregion 更新工艺卡表结束
        }

        /// <summary>
        /// 工艺卡删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_gyk_Delete_Click(object sender, EventArgs e)
        {
            string gykbh = "";

            if(treeView1.SelectedNode == null)
            {
                MessageBox.Show("请先选择要删除的工艺卡编号！");

                return;
            }

            if(treeView1.SelectedNode.Level == 1)//选中的是第一层树节点：工艺卡编号
            {
                gykbh = treeView1.SelectedNode.Text.ToString();
            }
            else if(treeView1.SelectedNode.Level == 2)//选中的是第二层树节点：工序号，其父节点为工艺卡编号
            {
                gykbh = treeView1.SelectedNode.Parent.Text.ToString();
            }
            else
            {
                MessageBox.Show("请先选择要删除的工艺卡编号！");

                return;
            }

            if (MessageBox.Show("不可撤销！\n是否删除工艺卡‘" + gykbh + "’及其下所有工序和配刀清单？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //从配刀表中删除
                SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", GongxuPeiDao.TableName, GongxuPeiDao.gykbh, gykbh);
                int row = SQL.ExecuteNonQuery(SqlStr);

                //从工序表中删除
                SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", GongXu.TableName, GongXu.gykbh, gykbh);
                row = SQL.ExecuteNonQuery(SqlStr);

                //从工艺卡表中删除
                SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", GongYiKa.TableName, GongYiKa.gykbh, gykbh);
                row = SQL.ExecuteNonQuery(SqlStr);
            }

            //刷新树节点
            BindRoot();
        }

        /*------------------------------------------------------------------工序信息-------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// 选择一行工序信息数据，填充工序信息文本框，并加载配刀信息表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gxxx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //排除点击表头
            if (e.RowIndex >= 0)
            {
                //填充工序信息文本框
                string gyk = gx_db.Rows[e.RowIndex]["gykbh"].ToString();//工艺卡编号
                string gx = gx_db.Rows[e.RowIndex]["gxh"].ToString();//工序号
                GXBH.Text = gx;
                JGLJH.Text = gx_db.Rows[e.RowIndex]["jgljh"].ToString();//加工零件号
                JGLJMC.Text = gx_db.Rows[e.RowIndex]["jgljmc"].ToString();//加工零件名称
                JCBH.SelectedItem = gx_db.Rows[e.RowIndex]["jcbm"].ToString();//机床编码
                GXNR.Text = gx_db.Rows[e.RowIndex]["gxnr"].ToString();//工序内容

                //取消联动
                //加载配刀表:从所有配刀表pd_db表中根据工序号加载要显示的配刀数据display_pd_db
                //DisplayPDList();

                //加载配刀表:直接数据库查询加载
                //SqlStr = string.Format("SELECT {14} AS xh, {1} AS gykbh, {2} AS gxh, {3} AS gjlx, {4} AS gjmc, {5} AS gjgg, {6} AS gjxh, {7} AS sl, {13} AS dw, {8} AS jcbm, {9} AS dth, {10} AS gjsm FROM {0} WHERE {1} = '{11}' AND {2} = '{12}'", GongxuPeiDao.TableName, GongxuPeiDao.gykbh, GongxuPeiDao.gxh, GongxuPeiDao.gjlx, GongxuPeiDao.gjmc, GongxuPeiDao.gjgg, GongxuPeiDao.gjxh, GongxuPeiDao.sl, GongxuPeiDao.jcbm, GongxuPeiDao.dth, GongxuPeiDao.gjsm, gyk, gx, GongxuPeiDao.dw, GongxuPeiDao.xh);
                //pd_db = SQL.getDataSet(SqlStr, GongxuPeiDao.TableName).Tables[0];
                //pdxx.DataSource = SQL.getDataSet1(SqlStr).Tables[0].DefaultView;
                //SqlStr = "";

                //判断是否点击了删除按钮
                if (e.ColumnIndex == 10)
                {
                    if(MessageBox.Show("确认移除‘" + gx + "’及其配刀清单？", "移除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //删除此工序对应的配刀数据:从下往上删，因为删除一行索引就会变化
                        for(int i = pd_db.Rows.Count - 1; i >= 0;)
                        {
                            if(pd_db.Rows[i]["gxh"].ToString() == gx)
                            {
                                pd_db.Rows.Remove(pd_db.Rows[i]);
                                i = pd_db.Rows.Count - 1;
                            }
                            else
                            {
                                i--;
                            }
                        }
                        pdxx.DataSource = pd_db.DefaultView;//重新绑定，刷新显示

                        //删除此工序
                        gx_db.Rows.Remove(gx_db.Rows[e.RowIndex]);
                        gxxx.DataSource = gx_db.DefaultView;//重新绑定，刷新显示
                    }
                }
            }
        }

        /// <summary>
        /// 工序信息新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_gx_New_Click(object sender, EventArgs e)
        {
            tishi = "";

            if(GYKBH.Text == "" || GYKBH.Text == null)
            {
                tishi = "请先填写工艺卡号！";
                MessageBox.Show(tishi);
                GYKBH.Focus();

                return;
            }

            //数据检查
            if (GXBH.Text == "" || GXBH.Text == null)
            {
                tishi = "请填写工序号！";
                MessageBox.Show(tishi);
                GXBH.Focus();

                return;
            }

            if (JGLJH.Text == "" && JGLJMC.Text == "")
            {
                tishi = "加工零件号和加工零件名称不可同时为空！";
                MessageBox.Show(tishi);
                JGLJH.Focus();

                return;
            }
            
            //注意是JCBH，JCBM是配刀表中的变量
            if (JCBH.SelectedIndex < 0 || JCBH.Text == "")
            {
                tishi = "请选择机床编码！";
                MessageBox.Show(tishi);
                JCBH.Focus();

                return;
            }

            if (GXNR.Text == "" || GXNR.Text == null)
            {
                tishi = "请填写工序内容！";
                MessageBox.Show(tishi);
                GXNR.Focus();

                return;
            }

            //判断工序号是否重复
            for (int i = 0; i < gxxx.Rows.Count; i++)
            {
                if (GXBH.Text.ToString().Trim() == gxxx.Rows[i].Cells["gx_gxh"].Value.ToString())
                {
                    tishi = "工序号已存在，请修改工序号后重试！";
                    MessageBox.Show(tishi);
                    GXBH.Focus();
                    GXBH.SelectAll();

                    return;
                }
            }

            //数据预处理
            string gykbh = GYKBH.Text;//工艺卡编号
            string gxh = GXBH.Text.ToString().Trim();//工序号
            string jgljh = JGLJH.Text.ToString();//加工零件号
            string jgljmc = JGLJMC.Text.ToString();//加工零件名称
            string jcbm = JCBH.SelectedItem.ToString();//机床编码
            string gxnr = GXNR.Text.ToString();//工序内容

            DataRow row = gx_db.NewRow();
            row["gykbh"] = gykbh;
            row["gxh"] = gxh;
            row["jgljh"] = jgljh;
            row["jgljmc"] = jgljmc;
            row["jcbm"] = jcbm;
            row["gxnr"] = gxnr;
            gx_db.Rows.Add(row);

            gxxx.DataSource = gx_db.DefaultView;//重新绑定，刷新显示
        }

        /// <summary>
        /// 工序信息修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_gx_Edit_Click(object sender, EventArgs e)
        {
            tishi = "";

            if(gxxx.CurrentRow == null || gxxx.CurrentRow.Index < 0)
            {
                tishi = "前先选择要修改的数据行！";
                MessageBox.Show(tishi);

                return;
            }

            //选中行的索引
            int rowindex = gxxx.CurrentRow.Index;

            //数据检查
            if (GXBH.Text == "" || GXBH.Text == null)
            {
                tishi = "请填写工序号！";
                MessageBox.Show(tishi);
                GXBH.Focus();

                return;
            }

            if (JGLJH.Text == "" && JGLJMC.Text == "")
            {
                tishi = "加工零件号和加工零件名称不可同时为空！";
                MessageBox.Show(tishi);
                JGLJH.Focus();

                return;
            }

            //注意是JCBH，JCBM是配刀表中的变量
            if (JCBH.SelectedIndex < 0 || JCBH.Text == "")
            {
                tishi = "请选择机床编码！";
                MessageBox.Show(tishi);
                JCBH.Focus();

                return;
            }

            if (GXNR.Text == "" || GXNR.Text == null)
            {
                tishi = "请填写工序内容！";
                MessageBox.Show(tishi);
                GXNR.Focus();

                return;
            }

            //判断工序号是否与其他行重复
            for (int i = 0; i < gxxx.Rows.Count; i++)
            {
                if (i != rowindex && GXBH.Text.ToString().Trim() == gxxx.Rows[i].Cells["gx_gxh"].Value.ToString())
                {
                    tishi = "工序号已存在，请修改工序号后重试！";
                    MessageBox.Show(tishi);
                    GXBH.Focus();
                    GXBH.SelectAll();

                    return;
                }
            }

            //数据预处理
            string gxh = GXBH.Text.ToString().Trim();//工序号
            string jgljh = JGLJH.Text.ToString();//加工零件号
            string jgljmc = JGLJMC.Text.ToString();//加工零件名称
            string jcbm = JCBH.SelectedItem.ToString();//机床编码
            string gxnr = GXNR.Text.ToString();//工序内容

            //修改索引为rowindex的数据行
            gx_db.Rows[rowindex]["gxh"] = gxh;
            gx_db.Rows[rowindex]["jgljh"] = jgljh;
            gx_db.Rows[rowindex]["jgljmc"] = jgljmc;
            gx_db.Rows[rowindex]["jcbm"] = jcbm;
            gx_db.Rows[rowindex]["gxnr"] = gxnr;
            
            //重新绑定，刷新显示
            gxxx.DataSource = gx_db.DefaultView;
        }

        /*----------------------------------------------------------------配刀信息-------------------------------------------------------------------------------------------------------*/
        #region 配刀信息块联动部分
        /// <summary>
        /// 工具类型选择变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GJLX_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlStr = "";

            if (GJLX.SelectedIndex < 0)
            {
                GJMC.DataSource = null;

                return;
            }

            if (GJLX.SelectedItem.ToString() == "刀具")
            {
                SqlStr = string.Format("SELECT DISTINCT {1} FROM {0}", DaoJuTemp.TableName, DaoJuTemp.leixing);
            }
            else if (GJLX.SelectedItem.ToString() == "零部件")
            {
                SqlStr = string.Format("SELECT DISTINCT {1} FROM {0}", LingBuJianBiao.TableName, LingBuJianBiao.mc);
            }
            else
            {
                GJMC.DataSource = null;
            }

            if (SqlStr != "")
            {
                GJMC.DataSource = SQL.DataReadList(SqlStr);
                GJMC.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// 工具名称选择变化，加载相应规格和型号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GJMC_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlStr = "";
            string sqlstr1 = "";

            if (GJMC.SelectedIndex < 0)
            {
                GJGG.DataSource = null;
                GJXH.DataSource = null;

                return;
            }

            if (GJLX.SelectedItem.ToString() == "刀具")
            {
                SqlStr = string.Format("SELECT DISTINCT {1} FROM {0} WHERE {2} = '{3}'", DaoJuTemp.TableName, DaoJuTemp.xinghao, DaoJuTemp.leixing, GJMC.SelectedItem.ToString());//型号
                sqlstr1 = string.Format("SELECT DISTINCT {1} FROM {0} WHERE {2} = '{3}'", DaoJuTemp.TableName, DaoJuTemp.guige, DaoJuTemp.leixing, GJMC.SelectedItem.ToString());//规格
            }
            else if (GJLX.SelectedItem.ToString() == "零部件")
            {
                SqlStr = string.Format("SELECT DISTINCT {1} FROM {0} WHERE {2} = '{3}'", LingBuJianBiao.TableName, LingBuJianBiao.xinghao, LingBuJianBiao.mc, GJMC.SelectedItem.ToString());//型号
                sqlstr1 = string.Format("SELECT DISTINCT {1} FROM {0} WHERE {2} = '{3}'", LingBuJianBiao.TableName, LingBuJianBiao.gg, LingBuJianBiao.mc, GJMC.SelectedItem.ToString());//规格
            }
            else
            {
                GJGG.DataSource = null;
                GJXH.DataSource = null;
            }

            if (SqlStr != "")
            {
                GJGG.DataSource = SQL.DataReadList(sqlstr1);
                GJXH.DataSource = SQL.DataReadList(SqlStr);
                GJGG.SelectedIndex = -1;
                GJGG.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// 选中具体型号，更新工具单位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GJXH_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlStr = "";

            if (GJXH.SelectedIndex < 0)
            {
                DW.Text = "";

                return;
            }

            if (GJLX.SelectedItem.ToString() == "刀具")
            {
                //SqlStr = string.Format("SELECT {1} AS dw FROM {0} WHERE {2} = '{3}' AND {4} = '{5}'", DaoJuTemp.TableName, DaoJuTemp.leixing);
                DW.Text = "套";

                return;
            }
            else if (GJLX.SelectedItem.ToString() == "零部件")
            {
                SqlStr = string.Format("SELECT {1} AS dw FROM {0} WHERE {2} = '{3}' AND {4} = '{5}'", LingBuJianBiao.TableName, LingBuJianBiao.dw, LingBuJianBiao.mc, GJMC.SelectedItem.ToString(), LingBuJianBiao.xinghao, GJXH.SelectedItem.ToString());
            }
            else
            {
                DW.Text = "";

                return;
            }

            if (SqlStr != "")
            {
                DW.Text = SQL.getDataSet(SqlStr, LingBuJianBiao.TableName).Tables[0].Rows[0]["dw"].ToString();
            }
        }

        /// <summary>
        /// 机床编号选择变化，加载相应刀套号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JCBM_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlStr = "";

            if (JCBM.SelectedIndex < 0)
            {
                DTH.DataSource = null;

                return;
            }

            SqlStr = string.Format("SELECT DISTINCT {1} FROM {0} WHERE {2} = '{3}'", JiChuangDaoJuKu.TableName, JiChuangDaoJuKu.dth, JiChuangDaoJuKu.jcbm, JCBM.SelectedItem.ToString());//刀套号
            DTH.DataSource = SQL.DataReadList(SqlStr);
            DTH.SelectedIndex = -1;
        }

        #endregion 配刀信息块联动部分结束

        /// <summary>
        /// 选中配刀信息数据行，填充配刀信息文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pdxx_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string gxh = pd_db.Rows[e.RowIndex]["gxh"].ToString();//记录当前工序号

                //填充配刀信息内容块
                GJLX.SelectedItem = pd_db.Rows[e.RowIndex]["gjlx"].ToString();//工具类型
                GJMC.SelectedItem = pd_db.Rows[e.RowIndex]["gjmc"].ToString();//工具名称
                GJGG.SelectedItem = pd_db.Rows[e.RowIndex]["gjgg"].ToString();//工具规格
                GJXH.SelectedItem = pd_db.Rows[e.RowIndex]["gjxh"].ToString();//工具型号
                JCBM.SelectedItem = pd_db.Rows[e.RowIndex]["jcbm"].ToString();//机床编码
                DTH.SelectedItem = pd_db.Rows[e.RowIndex]["dth"].ToString();//刀套号
                SXSL.Text = pd_db.Rows[e.RowIndex]["sl"].ToString();//数量
                DW.Text = pd_db.Rows[e.RowIndex]["dw"].ToString();//单位
                GJShuoMing.Text = pd_db.Rows[e.RowIndex]["gjsm"].ToString();//工具说明

                //判断是否点击了删除按钮
                if (e.ColumnIndex == 12)
                {
                    //删除此配刀数据行
                    pd_db.Rows.Remove(pd_db.Rows[e.RowIndex]);
                    pdxx.DataSource = pd_db.DefaultView;//重新绑定，刷新显示
                }
            }
            
        }

        /// <summary>
        /// 配刀信息新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_pd_New_Click(object sender, EventArgs e)
        {
            tishi = "";

            if(gxxx.CurrentRow == null || gxxx.CurrentRow.Index < 0)
            {
                tishi = "请先选择要添加工具数据的工序！";
                MessageBox.Show(tishi);
                gxxx.Focus();

                return;
            }

            //数据检查
            if (GJLX.SelectedItem == null || GJLX.SelectedIndex < 0)
            {
                tishi = "请选择工具类型！";
                MessageBox.Show(tishi);
                GJLX.Focus();

                return;
            }

            if (GJMC.SelectedItem == null || GJMC.SelectedIndex < 0)
            {
                tishi = "请选择工具名称！";
                MessageBox.Show(tishi);
                GJMC.Focus();

                return;
            }

            if (GJXH.SelectedItem == null || GJXH.SelectedIndex < 0)
            {
                tishi = "请选择工具型号！";
                MessageBox.Show(tishi);
                GJXH.Focus();

                return;
            }

            //注意是JCBM，JCBH是工序表中的变量
            if (JCBM.SelectedItem == null || JCBM.SelectedIndex < 0)
            {
                tishi = "请选择机床编码！";
                MessageBox.Show(tishi);
                JCBM.Focus();

                return;
            }

            if (DTH.SelectedItem == null || DTH.SelectedIndex < 0)
            {
                tishi = "请选择刀套号！";
                MessageBox.Show(tishi);
                DTH.Focus();

                return;
            }

            if (SXSL.Text == "" || SXSL.Text == null)
            {
                tishi = "请填写所需数量！";
                MessageBox.Show(tishi);
                SXSL.Focus();

                return;
            }

            if (GJShuoMing.Text == "" || GJShuoMing.Text == null)
            {
                tishi = "请填写工具说明！";
                MessageBox.Show(tishi);
                GJShuoMing.Focus();

                return;
            }

            //数据预处理
            string gykbh = gxxx.Rows[gxxx.CurrentRow.Index].Cells["gx_gykbh"].Value.ToString();//工艺卡编号
            string gxh = gxxx.Rows[gxxx.CurrentRow.Index].Cells["gx_gxh"].Value.ToString();//工序号
            string gjlx = GJLX.SelectedItem.ToString();//工具类型
            string gjmc = GJMC.SelectedItem.ToString();//工具名称
            string gjgg = GJGG.Text;//工具规格
            string gjxh = GJXH.SelectedItem.ToString();//工具型号
            string jcbm = JCBM.SelectedItem.ToString();//机床编码
            string dth = DTH.SelectedItem.ToString();//刀套号
            string sxsl = SXSL.Text;//所需数量
            string dw = DW.Text;//单位
            string gjsm = GJShuoMing.Text;//工具说明

            DataRow row = pd_db.NewRow();
            row["gykbh"] = gykbh;
            row["gxh"] = gxh;
            row["gjlx"] = gjlx;
            row["gjmc"] = gjmc;
            row["gjgg"] = gjgg;
            row["gjxh"] = gjxh;
            row["jcbm"] = jcbm;
            row["dth"] = dth;
            row["sl"] = sxsl;
            row["dw"] = dw;
            row["gjsm"] = gjsm;

            pd_db.Rows.Add(row);

            pdxx.DataSource = pd_db.DefaultView;//重新绑定，刷新显示
        }

        /// <summary>
        /// 配刀信息修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_pd_Edit_Click(object sender, EventArgs e)
        {
            tishi = "";

            if(pdxx.CurrentRow == null || pdxx.CurrentRow.Index < 0)
            {
                tishi = "前先选择要修改的数据行！";
                MessageBox.Show(tishi);

                return;
            }

            //选中行的索引
            int rowindex = pdxx.CurrentRow.Index;

            //数据检查
            if (GJLX.SelectedItem == null || GJLX.SelectedIndex < 0)
            {
                tishi = "请选择工具类型！";
                MessageBox.Show(tishi);
                GJLX.Focus();

                return;
            }

            if (GJMC.SelectedItem == null || GJMC.SelectedIndex < 0)
            {
                tishi = "请选择工具名称！";
                MessageBox.Show(tishi);
                GJMC.Focus();

                return;
            }

            if (GJXH.SelectedItem == null || GJXH.SelectedIndex < 0)
            {
                tishi = "请选择工具型号！";
                MessageBox.Show(tishi);
                GJXH.Focus();

                return;
            }

            //注意是JCBM，JCBH是工序表中的变量
            if (JCBM.SelectedItem == null || JCBM.SelectedIndex < 0)
            {
                tishi = "请选择机床编码！";
                MessageBox.Show(tishi);
                JCBM.Focus();

                return;
            }

            if (DTH.SelectedItem == null || DTH.SelectedIndex < 0)
            {
                tishi = "请选择刀套号！";
                MessageBox.Show(tishi);
                DTH.Focus();

                return;
            }

            if (SXSL.Text == "" || SXSL.Text == null)
            {
                tishi = "请填写所需数量！";
                MessageBox.Show(tishi);
                SXSL.Focus();

                return;
            }

            if (GJShuoMing.Text == "" || GJShuoMing.Text == null)
            {
                tishi = "请填写工具说明！";
                MessageBox.Show(tishi);
                GJShuoMing.Focus();

                return;
            }

            //数据预处理
            string gjlx = GJLX.SelectedItem.ToString();//工具类型
            string gjmc = GJMC.SelectedItem.ToString();//工具名称
            string gjgg = GJGG.Text;//工具规格
            string gjxh = GJXH.SelectedItem.ToString();//工具型号
            string jcbm = JCBM.SelectedItem.ToString();//机床编码
            string dth = DTH.SelectedItem.ToString();//刀套号
            string sxsl = SXSL.Text;//所需数量
            string dw = DW.Text;//单位
            string gjsm = GJShuoMing.Text;//工具说明

            //修改索引为rowindex的数据行
            pd_db.Rows[rowindex]["gjlx"] = gjlx;
            pd_db.Rows[rowindex]["gjmc"] = gjmc;
            pd_db.Rows[rowindex]["gjgg"] = gjgg;
            pd_db.Rows[rowindex]["gjxh"] = gjxh;
            pd_db.Rows[rowindex]["jcbm"] = jcbm;
            pd_db.Rows[rowindex]["dth"] = dth;
            pd_db.Rows[rowindex]["sl"] = sxsl;
            pd_db.Rows[rowindex]["dw"] = dw;
            pd_db.Rows[rowindex]["gjsm"] = gjsm;

            pdxx.DataSource = pd_db.DefaultView;//重新绑定，刷新显示
        }

        /*------------------------------------------------------------------其他方法-------------------------------------------------------------------------------------------------------*/
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

        /// <summary>
        /// 窗口自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gyk_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        /// <summary>
        /// 表格序号绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gxxx_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(gxxx, e);
        }

        /// <summary>
        /// 表格序号绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pdxx_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(pdxx, e);
        }

        #region 鼠标样式变化
        /// <summary>
        /// 鼠标移过datagridview的索引为columnIndex的列时，鼠标样式变为手型
        /// </summary>
        /// <param name="e"></param>
        /// <param name="columnIndex"></param>
        public void CellMouseMove(DataGridViewCellMouseEventArgs e, int columnIndex)
        {
            if (e.ColumnIndex == columnIndex)
            {
                try
                {
                    this.Cursor = Cursors.Hand;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
        
        /// <summary>
        /// 鼠标离开单元格，样式变为默认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void gxxx_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            CellMouseMove(e, 10);
        }

        private void pdxx_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            CellMouseMove(e, 12);
        }

        #endregion 鼠标样式变化结束

        /// <summary>
        /// 为datatable添加列
        /// </summary>
        private void AddColumns()
        {
            //工序表添加列
            gx_db.Columns.Add("xh", System.Type.GetType("System.Int32"));
            gx_db.Columns[0].AutoIncrement = true;//序号自增长
            gx_db.Columns[0].AutoIncrementSeed = 1;
            gx_db.Columns[0].AutoIncrementStep = 1;
            gx_db.Columns.Add("gykbh", System.Type.GetType("System.String"));
            gx_db.Columns.Add("gxh", System.Type.GetType("System.String"));
            gx_db.Columns.Add("jgljh", System.Type.GetType("System.String"));
            gx_db.Columns.Add("jgljmc", System.Type.GetType("System.String"));
            gx_db.Columns.Add("jcbm", System.Type.GetType("System.String"));
            gx_db.Columns.Add("gxnr", System.Type.GetType("System.String"));

            //配刀表添加列
            pd_db.Columns.Add("xh", System.Type.GetType("System.Int32"));
            pd_db.Columns[0].AutoIncrement = true;//序号自增长
            pd_db.Columns[0].AutoIncrementSeed = 1;
            pd_db.Columns[0].AutoIncrementStep = 1;
            pd_db.Columns.Add("gykbh", System.Type.GetType("System.String"));
            pd_db.Columns.Add("gxh", System.Type.GetType("System.String"));
            pd_db.Columns.Add("gjlx", System.Type.GetType("System.String"));
            pd_db.Columns.Add("gjmc", System.Type.GetType("System.String"));
            pd_db.Columns.Add("gjgg", System.Type.GetType("System.String"));
            pd_db.Columns.Add("gjxh", System.Type.GetType("System.String"));
            pd_db.Columns.Add("jcbm", System.Type.GetType("System.String"));
            pd_db.Columns.Add("dth", System.Type.GetType("System.String"));
            pd_db.Columns.Add("sl", System.Type.GetType("System.Int32"));
            pd_db.Columns.Add("dw", System.Type.GetType("System.String"));
            pd_db.Columns.Add("gjsm", System.Type.GetType("System.String"));

            //用于显示的配刀表与配刀表一致
            display_pd_db = pd_db.Clone();
        }        

        /// <summary>
        /// 从所有工序配刀表pd_db中过滤出要显示的配刀表
        /// </summary>
        /// <param name="gxh">要显示配刀表所对应的工序号，默认值为空，显示所有配刀表</param>
        private void DisplayPDList(string gxh = "")
        {
            //清空显示的历史数据
            display_pd_db.Clear();

            //默认为空，显示所有配刀表
            if (gxh == "")
            {
                display_pd_db = pd_db.Copy();
                pdxx.DataSource = display_pd_db.DefaultView;

                return;
            }

            //根据工序号显示配刀表:先整合全部信息，后移除无效数据行
            //display_pd_db.Merge(pd_db);
            for (int i = 0; i < pd_db.Rows.Count; i++)
            {
                if(pd_db.Rows[i]["gxh"].ToString() == gxh)
                {
                    //不可直接用display_pd_db.Rows.Add(pd_db.Rows[i]);提示错误：该行已经属于另一个表
                    display_pd_db.Rows.Add(pd_db.Rows[i].ItemArray);
                }
            }

            pdxx.DataSource = display_pd_db.DefaultView;
        }        

    }

}
