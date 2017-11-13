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

        private DataTable gx_db = new DataTable();//存放工序表数据
        private DataTable pd_db = new DataTable();//存放配刀表数据

        #endregion

        /*--------------------------------------------窗体构造与加载-------------------------------------------------------------------------------------------------------*/
        #region 窗体构造与加载函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public gyk()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gyk_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);

            //生成工艺卡树
            BindRoot();//生成树的第一层
            
            //禁止表格自动生成列
            gxxx.AutoGenerateColumns = false;
            pdxx.AutoGenerateColumns = false;

            //表格设置数据源，并加载默认值为空
            //gx_db = null;
            //pd_db = null;
            //gxxx.DataSource = gx_db.DefaultView;
            //pdxx.DataSource = pd_db.DefaultView;            
        }

        #endregion 窗体构造与加载函数结束

        /*-----------------------------------------------------------------树相关----------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// 生成树之生成第一层名称节点[构造类型（所有类型-->名称-->型号）树]
        /// </summary>
        private void BindRoot()
        {
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
            List<string> list1 = new List<string>();

            if (treeView1.SelectedNode.Level == 1)//当前选中节点为第二层节点：工艺卡编号
            {
                string gyk = e.Node.Text.ToString();

                //填充工艺卡基本信息
                SqlStr = string.Format("SELECT {1} AS gykbh, {2} AS jgljlx, {3} AS cjsj, {4} AS shuoming FROM {0} WHERE {5} = '{6}'", GongYiKa.TableName, GongYiKa.gykbh, GongYiKa.jgljlx, GongYiKa.cjsj, GongYiKa.gyksm, GongYiKa.gykbh, gyk);
                DataTable db1 = SQL.getDataSet(SqlStr, GongYiKa.TableName).Tables[0];
                GYKBH.Text = db1.Rows[0]["gykbh"].ToString();
                JGLJLX.Text = db1.Rows[0]["jgljlx"].ToString();
                GYKSM.Text = db1.Rows[0]["shuoming"].ToString();
                CJSJ.Value = Convert.ToDateTime(db1.Rows[0]["cjsj"].ToString());
                SqlStr = "";

                //填充工序表信息
                SqlStr = string.Format("SELECT {9} AS xh, {8} AS gykbh, {1} AS gxh, {2} AS jgljh, {3} AS jgljmc, {4} AS jcbm, {5} AS gxnr FROM {0} WHERE {6} =  '{7}'", GongXu.TableName, GongXu.gxbh, GongXu.jgljh, GongXu.jgljmc, GongXu.jcbm, GongXu.gxnr, GongXu.gykbh, gyk, GongXu.gykbh, GongXu.xh);
                gx_db = SQL.getDataSet(SqlStr, GongXu.TableName).Tables[0];
                gxxx.DataSource = SQL.getDataSet1(SqlStr).Tables[0].DefaultView;
                SqlStr = "";

                //加载工序信息的机床编号列表
                SqlStr = string.Format("SELECT DISTINCT {1} FROM {0}", JiChuangBiao.TableName, JiChuangBiao.jcbm);
                JCBH.DataSource = SQL.DataReadList(SqlStr);
                JCBH.SelectedIndex = -1;
                SqlStr = "";

                //填充配刀表信息
                SqlStr = string.Format("SELECT {13} AS xh, {1} AS gykbh, {2} AS gxh, {3} AS gjlx, {4} AS gjmc, {5} AS gjgg, {6} AS gjxh, {7} AS sl, {12} AS dw, {8} AS jcbm, {9} AS dth, {10} AS gjsm FROM {0} WHERE {1} = '{11}'", GongxuPeiDao.TableName, GongxuPeiDao.gykbh, GongxuPeiDao.gxh, GongxuPeiDao.gjlx, GongxuPeiDao.gjmc, GongxuPeiDao.gjgg, GongxuPeiDao.gjxh, GongxuPeiDao.sl, GongxuPeiDao.jcbm, GongxuPeiDao.dth, GongxuPeiDao.gjsm, gyk, GongxuPeiDao.dw, GongxuPeiDao.xh);
                pd_db = SQL.getDataSet(SqlStr, GongxuPeiDao.TableName).Tables[0];
                pdxx.DataSource = SQL.getDataSet1(SqlStr).Tables[0].DefaultView;
                SqlStr = "";

            }
            if (treeView1.SelectedNode.Level == 2)//当前选中节点为第三层节点：工序号
            {
                SqlStr = "select * from gongxu where gykbh =  '" + GYKBH.Text.ToString() + "' and gxh = '" + e.Node.Text.ToString() + "'";
                string SqlStr1 = "select * from gongxupeidao where gykbh =  '" + GYKBH.Text.ToString() + "' and gxh = '" + e.Node.Text.ToString() + "'";
                gxxx.DataSource = SQL.getDataSet1(SqlStr).Tables[0].DefaultView;
                pdxx.DataSource = SQL.getDataSet1(SqlStr1).Tables[0].DefaultView;

            }
        }

        /*--------------------------------------------------------------工艺卡基本信息-------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// 工艺卡新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_gyk_New_Click(object sender, EventArgs e)
        {
            string tishi = "";

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

                //加载配刀表
                SqlStr = string.Format("SELECT {14} AS xh, {1} AS gykbh, {2} AS gxh, {3} AS gjlx, {4} AS gjmc, {5} AS gjgg, {6} AS gjxh, {7} AS sl, {13} AS dw, {8} AS jcbm, {9} AS dth, {10} AS gjsm FROM {0} WHERE {1} = '{11}' AND {2} = '{12}'", GongxuPeiDao.TableName, GongxuPeiDao.gykbh, GongxuPeiDao.gxh, GongxuPeiDao.gjlx, GongxuPeiDao.gjmc, GongxuPeiDao.gjgg, GongxuPeiDao.gjxh, GongxuPeiDao.sl, GongxuPeiDao.jcbm, GongxuPeiDao.dth, GongxuPeiDao.gjsm, gyk, gx, GongxuPeiDao.dw, GongxuPeiDao.xh);
                pd_db = SQL.getDataSet(SqlStr, GongxuPeiDao.TableName).Tables[0];
                pdxx.DataSource = SQL.getDataSet1(SqlStr).Tables[0].DefaultView;
                SqlStr = "";

                //加载机床列表
                SqlStr = string.Format("SELECT DISTINCT {1} FROM {0}", JiChuangBiao.TableName, JiChuangBiao.jcbm);
                JCBM.DataSource = SQL.DataReadList(SqlStr);
                JCBM.SelectedIndex = -1;
                SqlStr = "";
            }
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
            GJLX.SelectedItem = pd_db.Rows[e.RowIndex]["gjlx"].ToString();//工具类型
            GJMC.SelectedItem = pd_db.Rows[e.RowIndex]["gjmc"].ToString();//工具名称
            GJGG.SelectedItem = pd_db.Rows[e.RowIndex]["gjgg"].ToString();//工具规格
            GJXH.SelectedItem = pd_db.Rows[e.RowIndex]["gjxh"].ToString();//工具型号
            JCBM.SelectedItem = pd_db.Rows[e.RowIndex]["jcbm"].ToString();//机床编码
            DTH.SelectedItem = pd_db.Rows[e.RowIndex]["dth"].ToString();//刀套号
            SXSL.Text = pd_db.Rows[e.RowIndex]["sl"].ToString();//数量
            GJShuoMing.Text = pd_db.Rows[e.RowIndex]["gjsm"].ToString();//工具说明
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

    }
    
}
