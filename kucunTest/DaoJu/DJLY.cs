using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using kucunTest.BaseClasses;
using FastReport;
using kucunTest.quanxianguanli;
using kucunTest.gongyika;

namespace kucunTest.DaoJu
{
    public partial class DJLY : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";
        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();//窗口自适应类
        private Authorize Authorise = new Authorize();

        int HJ = 0;

        DataSet lymx_ds = new DataSet();
        DataTable lymx_db = new DataTable();

        string LogType = "刀具领用";
        string LogMessage = "";
        //string danjubiao = "daojulingyong";
        //string mingxibiao = "daojulingyongmingxi";
        //string liushuibiao = "daojuliushui";
        //string daojutemp = "daojutemp";
        //string DHZD = "chucangdanhao";

        bool Edit = true;//单据是否可以编辑
        #endregion

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DJLY()
        {
            InitializeComponent();

            lymx_db.Columns.Add("daojuleixing", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("daojuguige", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("changdu", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("daojuid", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("shuliang", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("jichuangbianma", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("daotaohao", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("beizhu", System.Type.GetType("System.String"));

            danhao.Text = Alex.DanHao("DJCC");//自动生成单号

            LYBZ.DataSource = Alex.GetList("bz");
            LYBZ.SelectedIndex = -1;
            //string sqlstr2 = "select jichuangbianma from jichuang";
            LYSB.DataSource = Alex.GetList("jc");
            LYSB.SelectedIndex = -1;

            LYRQ.Value = DateTime.Now;
            LYBZ.SelectedIndex = 0;
            JBR.SelectedIndex = 0;
            heji.Text = HJ.ToString();

            //加载所有刀具类型
            cbx_lymx_djlx.DataSource = Alex.GetList("djlx");
            //加载所有机床编码/名称
            cbx_lymx_jcbm.DataSource = Alex.GetList("jc");

            cbx_lymx_djlx.SelectedIndex = -1;
            cbx_lymx_jcbm.SelectedIndex = -1;

            lingyongmingxi.AutoGenerateColumns = false;//禁止自动生成行
        }

        /// <summary>
        /// 重写构造函数，用于从历史记录窗体加载数据
        /// </summary>
        /// <param name="list">从历史记录传过来的值</param>
        public DJLY(List<string> list)
        {
            InitializeComponent();//

            lymx_db.Columns.Add("daojuleixing", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("daojuguige", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("changdu", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("daojuid", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("shuliang", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("jichuangbianma", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("daotaohao", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("beizhu", System.Type.GetType("System.String"));

            //班组和机床设置数据源
            LYBZ.DataSource = Alex.GetList("bz");
            LYSB.DataSource = Alex.GetList("jc");

            //加载所有刀具类型
            cbx_lymx_djlx.DataSource = Alex.GetList("djlx");
            //加载所有机床编码/名称
            cbx_lymx_jcbm.DataSource = Alex.GetList("jc");

            cbx_lymx_djlx.SelectedIndex = -1;
            cbx_lymx_djgg.SelectedIndex = -1;
            cbx_lymx_djcd.SelectedIndex = -1;
            cbx_lymx_djid.SelectedIndex = -1;
            cbx_lymx_jcbm.SelectedIndex = -1;

            lingyongmingxi.AutoGenerateColumns = false;//禁止自动生成行

            //danhao.Text = dh;

            danhao.Text = list[0];//list[0] 领用单号

            Sqlstr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", DaoJuLingYong.TableName, DaoJuLingYong.danhao, list[0].ToString());
            DataTable dbinfo = SQL.getDataSet(Sqlstr, DaoJuLingYong.TableName).Tables[0];
            ZJGX.Text = dbinfo.Rows[0][DaoJuLingYong.jggy].ToString();
            LYBZ.Text = dbinfo.Rows[0][DaoJuLingYong.lybz].ToString();
            LYSB.Text = dbinfo.Rows[0][DaoJuLingYong.lysb].ToString();
            LYR.Text = dbinfo.Rows[0][DaoJuLingYong.lyr].ToString();
            LYRQ.Value = Convert.ToDateTime(dbinfo.Rows[0][DaoJuLingYong.lysj].ToString());
            JBR.Text = dbinfo.Rows[0][DaoJuLingYong.jbr].ToString();
            beizhu.Text = dbinfo.Rows[0][DaoJuLingYong.bz].ToString();
            string danjuzhuangtai = dbinfo.Rows[0][DaoJuLingYong.djzt].ToString();
            Sqlstr = "";

            //ZJGX.Text = list[1];//list[1] 制件工序
            //LYBZ.Text = list[2];//list[2] 领用班组
            //LYSB.Text = list[3];//list[3] 领用设备
            //LYR.Text = list[4];//list[4] 领用人
            //LYRQ.Value = Convert.ToDateTime(list[5]);//list[5] 领用日期
            //JBR.Text = list[6];//list[6] 经办人
            //beizhu.Text = list[7];//list[7] 备注
            //string danjuzhuangtai = list[8]; //list[8] 单据状态

            Sqlstr = string.Format("SELECT {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}  FROM {0} WHERE {9} = '{10}'", DaoJuLingYongMingXi.TableName, DaoJuLingYongMingXi.djlx, DaoJuLingYongMingXi.djgg, DaoJuLingYongMingXi.djcd, DaoJuLingYongMingXi.djid, DaoJuLingYongMingXi.sl, DaoJuLingYongMingXi.jcbm, DaoJuLingYongMingXi.dth, DaoJuLingYongMingXi.bz, DaoJuLingYongMingXi.danhao, danhao.Text.ToString().Trim());
            //Sqlstr = "select daojuleixing, daojuguige, changdu, daojuid, shuliang, jichuangbianma, daotaohao, beizhu  from " + DaoJuLingYongMingXi.TableName + " where chucangdanhao = '" +danhao.Text.ToString().Trim() +  "'";
            lymx_ds = SQL.getDataSet(Sqlstr, DaoJuLingYongMingXi.TableName);
            lymx_db = lymx_ds.Tables[0];
            lingyongmingxi.DataSource = lymx_db.DefaultView;

            HJ = lingyongmingxi.Rows.Count - 1;//同步全局变量
            heji.Text = HJ.ToString();

            //若是已完成的单据，则只允许查看，不许修改。
            if (danjuzhuangtai == "1")
            {
                Edit = false;
                Alex.DisableAllControl(this);
                btn_print.Enabled = true;
            }
        }

        /// <summary>
        /// 窗体加载，设置相关默认值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJCCD_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);//记录窗体及控件初始大小，以便自适应

            //设置权限
            this.Authorise.setAuthority(this, AuthoritiesString.FormName.djlyFrm);
        }

        #region 明细部分
        ///<summary>
        ///datagridview每一行自动生成序号
        /// </summary>
        private void ChuCangMingXi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(lingyongmingxi, e);
        }

        /// <summary>
        /// 出仓明细新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            #region 弹出添加框
            //xzlymx xzccmx = new xzlymx();
            //xzccmx.Owner = this;
            //xzccmx.ShowDialog();
            #endregion 弹出框部分结束

            if (AddDataCheck())//进行数据验证
            {
                //暂存单据，领用明细datagridview已经绑定数据源
                //if (zancun)
                //{
                DataRow rowrow = lymx_db.NewRow();

                rowrow["daojuleixing"] = cbx_lymx_djlx.Text.ToString();//刀具类型
                rowrow["daojuguige"] = cbx_lymx_djgg.Text.ToString();//刀具规格
                rowrow["changdu"] = cbx_lymx_djcd.Text.ToString();//刀具长度
                rowrow["daojuid"] = cbx_lymx_djid.Text.ToString();//刀具id
                rowrow["shuliang"] = "1";//数量
                rowrow["jichuangbianma"] = cbx_lymx_jcbm.Text.ToString();//机床编码
                rowrow["daotaohao"] = cbx_lymx_dth.Text.ToString();//刀套号
                rowrow["beizhu"] = txt_lymx_bz.Text.ToString();//备注

                lymx_db.Rows.Add(rowrow);
                lingyongmingxi.DataSource = lymx_db.DefaultView;

                HJ++;//合计数量增加
                heji.Text = HJ.ToString();//更新合计数量
            }

            lingyongmingxi.CurrentCell = null;//取消选中任何行
        }

        /// <summary>
        /// 新增明细时的数据验证
        /// </summary>
        /// <returns></returns>
        private bool AddDataCheck()
        {
            string tishi = "";

            //刀具类型
            if (cbx_lymx_djlx.SelectedIndex < 0 || cbx_lymx_djlx.Text == null || cbx_lymx_djlx.Text == "")
            {
                tishi = "请选择刀具类型！";
                MessageBox.Show(tishi, "提示");
                cbx_lymx_djlx.Focus();
                return false;
            }
            //刀具规格
            if (cbx_lymx_djgg.SelectedIndex < 0 || cbx_lymx_djgg.Text == "" || cbx_lymx_djgg.Text == null)
            {
                tishi = "请选择刀具规格！";
                MessageBox.Show(tishi, "提示");
                cbx_lymx_djgg.Focus();
                return false;
            }
            //刀具长度
            if (cbx_lymx_djcd.Text == null || cbx_lymx_djcd.Text == "")
            {
                tishi = "请填写刀具长度！";
                MessageBox.Show(tishi, "提示");
                cbx_lymx_djcd.Focus();
                return false;
            }
            //刀具ID
            if (cbx_lymx_djid.Text == "" || cbx_lymx_djid.Text == null)
            {
                tishi = "请选择刀具ID！";
                MessageBox.Show(tishi, "提示");
                cbx_lymx_djid.Focus();
                return false;
            }
            //机床编码
            if (cbx_lymx_jcbm.SelectedIndex < 0 || cbx_lymx_jcbm.Text == null || cbx_lymx_jcbm.Text == "")
            {
                tishi = "请选择要领用刀具的机床编码！";
                MessageBox.Show(tishi, "提示");
                cbx_lymx_jcbm.Focus();
                return false;
            }
            //刀套号
            if (cbx_lymx_dth.SelectedIndex < 0 || cbx_lymx_dth.Text == null || cbx_lymx_dth.Text == "")
            {
                tishi = "请选择要领用刀具的刀套号！";
                MessageBox.Show(tishi, "提示");
                cbx_lymx_dth.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// AddData函数，向datagridview中增加一行数据
        /// </summary>
        /// <param name="list">子窗体传输过来的list值</param>
        public void AddData(List<string> list)
        {        
            if(lingyongmingxi.DataSource == null)//新单据，未绑定数据源
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(lingyongmingxi);

                row.Cells[0].Value = list[0];//刀具类型
                row.Cells[1].Value = list[1];//刀具规格
                row.Cells[2].Value = list[2];//刀具长度
                row.Cells[3].Value = list[3];//刀具id
                row.Cells[4].Value = "1";//数量
                row.Cells[5].Value = list[4];//机床编码
                row.Cells[6].Value = list[5];//刀套号
                row.Cells[7].Value = list[6];//备注

                lingyongmingxi.Rows.Add(row);
            }
            else//暂存的单据，领用明细datagridview已经绑定数据源
            {
                //lingyongmingxi.DataSource = null;
                //lingyongmingxi.Rows.Add(row);

                DataRow rowrow = lymx_db.NewRow();

                rowrow["daojuleixing"] = list[0];//刀具类型
                rowrow["daojuguige"] = list[1];//刀具规格
                rowrow["changdu"] = list[2];//刀具长度
                rowrow["daojuid"] = list[3];//刀具id
                rowrow["shuliang"] = "1";//数量
                rowrow["jichuangbianma"] = list[4];//机床编码
                rowrow["daotaohao"] = list[5];//刀套号
                rowrow["beizhu"] = list[6];//备注

                lymx_db.Rows.Add(rowrow);
            }

            HJ++;//合计数量加一
            heji.Text = HJ.ToString();//更新合计数量
        }

        /// <summary>
        /// 出仓明细的删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            int k = lingyongmingxi.SelectedRows.Count;
            if (k == 0)
            {
                MessageBox.Show("请先选择至少一行数据！", "提示", MessageBoxButtons.OK);
            }
            else if (lingyongmingxi.CurrentRow.Index == lingyongmingxi.Rows.Count - 1 || k == lingyongmingxi.Rows.Count)//选中的是最后一行
            {
                MessageBox.Show("不能删除空白行！", "警告", MessageBoxButtons.OK);
            }
            else if (k == 1)
            {
                DialogResult result = MessageBox.Show("确定删除" + k + "行数据？", "提示", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    lingyongmingxi.Rows.RemoveAt(lingyongmingxi.CurrentRow.Index);
                    HJ--;
                }                
            }
            else
            {                
                DialogResult result = MessageBox.Show("确定删除" + k + "行数据？", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    for(int i = k; i >= 1; i--)//从下往上删，避免沙漏效应
                    {
                        lingyongmingxi.Rows.RemoveAt(lingyongmingxi.SelectedRows[i - 1].Index);
                        HJ--;  //合计数量减一
                    }
                }
            }

            heji.Text = HJ.ToString();//更新合计数量                      
        }
        #endregion 明细部分结束

        #region 按钮部分
        /// <summary>
        /// 保存单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_Click(object sender, EventArgs e)
        {
            if (LYBZ.Text == "" && LYR.Text == "" && LYSB.Text == "" && JBR.Text == "" && SPR.Text == "" && ZJGX.Text == "" && lingyongmingxi.Rows.Count == 1)//未填写任何内容，提示取消填写单据
            {
                if (MessageBox.Show("当前单据为空，要直接取消填写单据？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                //将领用和操作数据存入数据库daojuchucang表
                if (Alex.CunZai(danhao.Text.ToString(), DaoJuLingYong.danhao, DaoJuLingYong.TableName) != 0)//判断此单号在单据表中是否已存在
                {
                    //使用update语句
                    //Sqlstr = "UPDATE daojuchucang SET (chucangdanhao, chucangleixing, danjuzhuangtai, lingyongbanzu, lingyongren, jiagonggongyi, chucangriqi, beizhu, caozuoyuan) values('" + danhao.Text.ToString().Trim() + "', '" + "常规领用" + "', '" + "0" + "', '" + LYBZ.Text.ToString().Trim() + "', '" + LYR.Text.ToString().Trim() + "', '" + ZJGX.Text.ToString().Trim() + "', '" + LYRQ.Text + "', '" + beizhu.Text.ToString().Trim() + "', '" + JBR.Text.ToString().Trim() + "')";
                    Sqlstr = string.Format("UPDATE {0} SET lingyongbanzu = '{1}', lingyongren = '{2}', lingyongshebei = '{3}', jiagonggongyi = '{4}', chucangriqi = '{5}', beizhu = '{6}', caozuoyuan = '{7}' where chucangdanhao = '{8}'", DaoJuLingYong.TableName, LYBZ.Text.ToString().Trim(), LYR.Text.ToString().Trim(), LYSB.Text.ToString().Trim(), ZJGX.Text.ToString().Trim(), LYRQ.Text, beizhu.Text.ToString().Trim(), JBR.Text.ToString().Trim(), danhao.Text.ToString().Trim());
                }
                else
                {
                    //直接使用insert语句
                    Sqlstr = "insert into " + DaoJuLingYong.TableName + "(chucangdanhao, chucangleixing, danjuzhuangtai, lingyongbanzu, lingyongren, lingyongshebei, jiagonggongyi, chucangriqi, beizhu, caozuoyuan) values('" + danhao.Text.ToString().Trim() + "', '" + "常规领用" + "', '" + "0" + "', '" + LYBZ.Text.ToString().Trim() + "', '" + LYR.Text.ToString().Trim() + "', '" + LYSB.Text.ToString().Trim() + "', '" + ZJGX.Text.ToString().Trim() + "', '" + LYRQ.Text + "', '" + beizhu.Text.ToString().Trim() + "', '" + JBR.Text.ToString().Trim() + "')";
                }

                //执行sql语句,row1为受影响的行数
                int row1 = SQL.ExecuteNonQuery(Sqlstr);

                //将领用明细数据存入数据库daojuchucangmingxi表
                int row2 = 0;
                if (row1 != 0)
                {
                    if (Alex.CunZai(danhao.Text.ToString(), DaoJuLingYongMingXi.danhao, DaoJuLingYongMingXi.TableName) != 0)//判断此单号在明细表中是否已存在
                    {
                        //使用delete语句删除已存在的明细
                        Sqlstr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", DaoJuLingYongMingXi.TableName, DaoJuLingYongMingXi.danhao, danhao.Text.ToString().Trim());
                        row2 = SQL.ExecuteNonQuery(Sqlstr);
                    }
                    //出仓明细数据格式化
                    for (int rowindex = 0; rowindex < lingyongmingxi.Rows.Count - 1; rowindex++)
                    {
                        string djlx = lingyongmingxi.Rows[rowindex].Cells["djlx"].Value.ToString();
                        string djgg = lingyongmingxi.Rows[rowindex].Cells["djgg"].Value.ToString();
                        string djcd = lingyongmingxi.Rows[rowindex].Cells["djcd"].Value.ToString();
                        string djid = lingyongmingxi.Rows[rowindex].Cells["djid"].Value.ToString();
                        string sl = lingyongmingxi.Rows[rowindex].Cells["sl"].Value.ToString();
                        string jcbm = lingyongmingxi.Rows[rowindex].Cells["jcbm"].Value.ToString();
                        string dth = lingyongmingxi.Rows[rowindex].Cells["dth"].Value.ToString();
                        string bz = lingyongmingxi.Rows[rowindex].Cells["bz"].Value.ToString();

                        Sqlstr = "insert into " + DaoJuLingYongMingXi.TableName + "(chucangdanhao, daojuleixing, daojuguige, changdu, daojuid, shuliang, jichuangbianma, daotaohao, beizhu) values('" + danhao.Text.ToString().Trim() + "', '" + djlx + "', '" + djgg + "', '" + djcd + "','" + djid + "', '" + sl + "', '" + jcbm + "', '" + dth + "', '" + bz + "')";
                        row2 = SQL.ExecuteNonQuery(Sqlstr);//执行sql语句,row2为受影响的行数
                    }

                    //出仓明细数据存入数据库
                    if (row2 != 0)
                    {
                        MessageBox.Show("单据保存成功，可再次修改确认！", "提示", MessageBoxButtons.OK);

                        //日志记录
                        LogMessage = string.Format("成功保存1张单据编号为{0}的刀具领用暂存单据。", danhao.Text);
                        Program.WriteLog(LogType, LogMessage);
                        LogMessage = "";

                        //this.InitializeComponent();
                        //this.OnLoad(null);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("领用明细数据填写有误，请检查并重试！", "警告", MessageBoxButtons.OK);
                    }
                }
            }

        }

        /// <summary>
        /// 确认单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否确认对刀具进行领用？确认后单据不可修改！", "领用确认", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                //数据验证
                if(CheckData() == 0)
                {
                    return;//数据输入有误
                }
                else
                {
                    //将出仓和操作数据存入数据库daojuchucang表
                    if (Alex.CunZai(danhao.Text.ToString(), DaoJuLingYong.TableName, DaoJuLingYong.TableName) != 0)//判断此单号在单据表中是否已存在
                    {
                        //使用update语句
                        //Sqlstr = "UPDATE daojuchucang SET (chucangdanhao, chucangleixing, danjuzhuangtai, lingyongbanzu, lingyongren, jiagonggongyi, chucangriqi, beizhu, caozuoyuan) values('" + danhao.Text.ToString().Trim() + "', '" + "常规领用" + "', '" + "0" + "', '" + LYBZ.Text.ToString().Trim() + "', '" + LYR.Text.ToString().Trim() + "', '" + ZJGX.Text.ToString().Trim() + "', '" + LYRQ.Text + "', '" + beizhu.Text.ToString().Trim() + "', '" + JBR.Text.ToString().Trim() + "')";
                        Sqlstr = string.Format("UPDATE {0} SET lingyongbanzu = '{1}', lingyongren = '{2}', lingyongshebei = '{3}', jiagonggongyi = '{4}', chucangriqi = '{5}', beizhu = '{6}', caozuoyuan = '{7}', danjuzhuangtai = '{8}' where chucangdanhao = '{9}'", DaoJuLingYong.TableName, LYBZ.Text.ToString().Trim(), LYR.Text.ToString().Trim(), LYSB.Text.ToString().Trim(), ZJGX.Text.ToString().Trim(), LYRQ.Text, beizhu.Text.ToString().Trim(), JBR.Text.ToString().Trim(), "1",  danhao.Text.ToString().Trim());
                    }
                    else
                    {
                        //直接使用insert语句
                        Sqlstr = "insert into " + DaoJuLingYong.TableName + "(chucangdanhao, chucangleixing, danjuzhuangtai, lingyongbanzu, lingyongren, lingyongshebei, jiagonggongyi, chucangriqi, beizhu, caozuoyuan) values('" + danhao.Text.ToString().Trim() + "', '" + "常规领用" + "', '" + "1" + "', '" + LYBZ.Text.ToString().Trim() + "', '" + LYR.Text.ToString().Trim() + "', '" + LYSB.Text.ToString().Trim() + "', '" + ZJGX.Text.ToString().Trim() + "', '" + LYRQ.Text + "', '" + beizhu.Text.ToString().Trim() + "', '" + JBR.Text.ToString().Trim() + "')";
                    }

                    int row1 = SQL.ExecuteNonQuery(Sqlstr);

                    //将出仓明细数据存入数据库daojuchucangmingxi表和刀具流水总表
                    int row2 = 0;//记录插入明细表数据
                    int row3 = 0;//记录插入流水表数据
                    int row4 = 0;//记录更新刀具监测表数据
                    string dskysl = "";//此类型刀具的当时可用数量！！！当时可用数量为单据操作后的刀具可用数量

                    if (row1 != 0)
                    {
                        if (Alex.CunZai(danhao.Text.ToString(), DaoJuLingYongMingXi.danhao, DaoJuLingYongMingXi.TableName) != 0)//判断此单号在明细表中是否已存在
                        {
                            //使用delete语句删除已存在的明细
                            Sqlstr = string.Format("DELETE FROM {0} WHERE chucangdanhao = '{1}'", DaoJuLingYongMingXi.TableName, danhao.Text.ToString().Trim());
                            row2 = SQL.ExecuteNonQuery(Sqlstr);
                        }

                        for (int rowindex = 0; rowindex < lingyongmingxi.Rows.Count - 1; rowindex++)
                        {
                            //出仓明细数据格式化
                            string djlx = lingyongmingxi.Rows[rowindex].Cells["djlx"].Value.ToString();
                            string djgg = lingyongmingxi.Rows[rowindex].Cells["djgg"].Value.ToString();
                            string djcd = lingyongmingxi.Rows[rowindex].Cells["djcd"].Value.ToString();
                            string djid = lingyongmingxi.Rows[rowindex].Cells["djid"].Value.ToString();
                            string sl = lingyongmingxi.Rows[rowindex].Cells["sl"].Value.ToString();
                            string jcbm = lingyongmingxi.Rows[rowindex].Cells["jcbm"].Value.ToString();
                            string dth = lingyongmingxi.Rows[rowindex].Cells["dth"].Value.ToString();
                            string bz = lingyongmingxi.Rows[rowindex].Cells["bz"].Value.ToString();

                            //查询此类型刀具当时可用数量, 刀具领用可用数量减一
                            dskysl = (Alex.Count_djsl(djlx, "kysl") - 1).ToString();

                            //明细数据存入数据库明细表
                            Sqlstr = "insert into " + DaoJuLingYongMingXi.TableName + "(chucangdanhao, daojuleixing, daojuguige, changdu, daojuid, shuliang, jichuangbianma, daotaohao, beizhu) values('" + danhao.Text.ToString().Trim() + "', '" + djlx + "', '" + djgg + "', '" + djcd + "','" + djid + "', '" + sl + "', '" + jcbm + "', '" + dth + "', '" + bz + "')";
                            row2 = SQL.ExecuteNonQuery(Sqlstr);

                            //明细信息存入流水表
                            Sqlstr = string.Format("INSERT INTO {0}(danhao, dhlx, djlx, djgg, djid, zsl, fsl, dskysl, wzbm, jtwz ,czsj, jbr, bz) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}' ,'{8}', '{9}', '{10}', '{11}', '{12}', '{13}')", DaoJuLiuShui.TableName, danhao.Text.ToString().Trim(), "常规领用", djlx, djgg, djid, "0", sl, dskysl, jcbm, dth, LYRQ.Value.ToString().Trim(), JBR.Text.ToString().Trim() ,bz);
                            row3 = SQL.ExecuteNonQuery(Sqlstr);

                            //更新刀具位置寿命监测表
                            Sqlstr = string.Format("UPDATE {0} dj SET dj.weizhibiaoshi = 'M', dj.weizhi = '{1}', dj.cengshu = '{2}' WHERE dj.daojuid = '{3}'", DaoJuTemp.TableName, jcbm, dth, djid);
                            row4 = SQL.ExecuteNonQuery(Sqlstr);
                        }

                        
                        //int row2 = SQL.ExecuteNonQuery(Sqlstr);
                        if (row2 != 0)
                        {
                            MessageBox.Show("刀具领用完成！", "提示", MessageBoxButtons.OK);

                            //日志记录
                            LogMessage = string.Format("成功确认1张单据编号为{0}的刀具领用单据。", danhao.Text);
                            Program.WriteLog(LogType, LogMessage);
                            LogMessage = "";

                            //this.InitializeComponent();
                            //this.OnLoad(null);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("领用明细数据填写有误，请检查并重试！", "警告", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("领用信息或操作信息填写有误，请检查并重试！", "警告", MessageBoxButtons.OK);
                    }
                }                
            }
        }

        /// <summary>
        /// 打印单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void print_Click(object sender, EventArgs e)
        {
            //数据验证
            if (CheckData() == 0)
            {
                return;//数据输入有误
            }
            else
            {
                DataSet FRds = new DataSet();
                DataTable table1 = new DataTable();//存放领用明细数据
                table1.TableName = "Table1"; // 一定要设置表名称

                // 添加表中的列
                table1.Columns.Add("xh", typeof(string));
                table1.Columns.Add("daojuleixing", typeof(string));
                table1.Columns.Add("daojuguige", typeof(string));
                table1.Columns.Add("daojuchangdu", typeof(string));
                table1.Columns.Add("daojuid", typeof(string));
                table1.Columns.Add("shuliang", typeof(string));
                table1.Columns.Add("jichuangbianma", typeof(string));
                table1.Columns.Add("daotaohao", typeof(string));
                table1.Columns.Add("beizhu", typeof(string));

                //添加明细数据
                for (int rowindex = 0; rowindex < lingyongmingxi.Rows.Count - 1; rowindex++)
                {
                    //格式化刀具数据
                    string djlx = lingyongmingxi.Rows[rowindex].Cells["djlx"].Value.ToString();
                    string djgg = lingyongmingxi.Rows[rowindex].Cells["djgg"].Value.ToString();
                    string djcd = lingyongmingxi.Rows[rowindex].Cells["djcd"].Value.ToString();
                    string djid = lingyongmingxi.Rows[rowindex].Cells["djid"].Value.ToString();
                    string sl = lingyongmingxi.Rows[rowindex].Cells["sl"].Value.ToString();
                    string jcbm = lingyongmingxi.Rows[rowindex].Cells["jcbm"].Value.ToString();
                    string dth = lingyongmingxi.Rows[rowindex].Cells["dth"].Value.ToString();
                    string bz = lingyongmingxi.Rows[rowindex].Cells["bz"].Value.ToString();

                    DataRow row = table1.NewRow();
                    row["xh"] = rowindex + 1;
                    row["daojuleixing"] = djlx;
                    row["daojuguige"] = djgg;
                    row["daojuchangdu"] = djcd;
                    row["daojuid"] = djid;
                    row["shuliang"] = sl;
                    row["jichuangbianma"] = jcbm;
                    row["daotaohao"] = dth;
                    row["beizhu"] = bz;

                    table1.Rows.Add(row);
                }

                FRds.Tables.Add(table1);

                Report FReport = new Report();
                //string sPath = @"C:\Users\workstation\Desktop\Alex\kucunTest\kucunTest\File";
                //string sPath = @"C:\Users\workstation\Desktop\Alex\kucunTest\kucunTest\File" + @"\刀具领用单" + ".frx";
                string sPath = @"../../File/刀具领用单.frx";
                FReport.Load(sPath);  // 将DataSet对象注册到FastReport控件中
                                      //FReport.RegisterData(ds1);
                FReport.RegisterData(FRds);

                FReport.SetParameterValue("danhao", danhao.Text);
                FReport.SetParameterValue("lybz", LYBZ.Text);
                FReport.SetParameterValue("ZJGX", ZJGX.Text);
                FReport.SetParameterValue("LYRQ", LYRQ.Text.ToString());
                FReport.SetParameterValue("LYSB", LYSB.Text);
                FReport.SetParameterValue("beizhu", beizhu.Text);
                FReport.SetParameterValue("spr", SPR.Text);
                FReport.SetParameterValue("JBR", JBR.Text);
                FReport.SetParameterValue("LYR", LYR.Text);

                //显示报表
                FReport.Prepare();
                FReport.ShowPrepared();
                //FReport.Show();

                //日志记录
                LogMessage = string.Format("成功打印1张单据编号为{0}的刀具领用单据。", danhao.Text);
                Program.WriteLog(LogType, LogMessage);
                LogMessage = "";
            }
        }

        /// <summary>
        /// 出仓历史按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确认打开领用历史记录并关闭此窗口？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                History djccls = new History("DJCCD");
                djccls.Show();
                this.Close();
            }            
        }

        /// <summary>
        /// 删除单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_Click(object sender, EventArgs e)
        {
            if(Alex.CunZai(danhao.Text.ToString().Trim(), DaoJuLingYong.danhao ,DaoJuLingYong.TableName) != 0 )
            {
                DialogResult dr = MessageBox.Show("确认删除此单据？", "删除确认", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //删除刀具领用表中的数据
                    Sqlstr = string.Format("DELETE FROM {0} WHERE chucangdanhao = '{1}'", DaoJuLingYong.TableName, danhao.Text.ToString().Trim());
                    int row1 = SQL.ExecuteNonQuery(Sqlstr);

                    Sqlstr = string.Format("DELETE FROM {0} WHERE chucangdanhao = '{1}'", DaoJuLingYongMingXi.TableName, danhao.Text.ToString().Trim());
                    int row2 = SQL.ExecuteNonQuery(Sqlstr);
                    MessageBox.Show("成功删除一张单据和" + row2 + "条明细记录！");

                    //日志记录
                    LogMessage = "成功删除1张刀具领用单据和" + row2 + "条明细记录！";
                    Program.WriteLog(LogType, LogMessage);
                    LogMessage = "";

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else//数据库不存在
            {
                MessageBox.Show("单据还未保存，不可删除！", "提示", MessageBoxButtons.OK);
            }
            
        }

        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion 按钮部分结束

        #region 其他方法
        /// <summary>
        /// 出仓备注文本框设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CCBZ_MouseClick(object sender, MouseEventArgs e)
        {
            if(beizhu.Text.ToString() == "请填写领用原因")
            {
                beizhu.SelectAll();
            }            
        }

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        private int CheckData()
        {
            string tishi = "";
            if (LYBZ.Text == "" || LYR.Text == "" || JBR.Text == "")
            {
                if (LYBZ.Text.ToString() == "")
                {
                    tishi = "请填写领用班组！";
                }
                else if (LYR.Text.ToString() == "")
                {
                    tishi = "请填写领用人！";
                }
                else if (JBR.Text.ToString() == "")
                {
                    tishi = "请填写经办人！";
                }
                //MessageBox.Show(tishi, "警告", MessageBoxButtons.OK);
            }
            else if (ZJGX.Text == "")
            {
                tishi = "请选择与之相关的制件工序！";
            }

            if (lingyongmingxi.Rows.Count == 1)
            {
                tishi = "领用明细不能为空！";
            }

            if (tishi != "")
            {
                MessageBox.Show(tishi, "警告", MessageBoxButtons.OK);
                return 0;
            }
            else
                return 1;
        }
        
        /// <summary>
        /// 窗体大小发生变化时自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJCCD_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
                
        /// <summary>
        /// 当窗体在选项卡中打开时，关闭窗体则关闭相应的选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJCCD_FormClosed(object sender, FormClosedEventArgs e)
        {
            Alex.CloseFormFromTabpages(this);
        }

        #endregion 其他方法结束

        /// <summary>
        /// 从表增加明细，即可以通过选择多条记录一并新增明细
        /// </summary>
        /// <param name="tb">要新增的明细表部分内容</param>
        public void AddDataFromTable(DataTable tb)
        {
            //lymx_db.Columns.Add("daojuleixing", System.Type.GetType("System.String"));
            //lymx_db.Columns.Add("daojuguige", System.Type.GetType("System.String"));
            //lymx_db.Columns.Add("changdu", System.Type.GetType("System.String"));
            //lymx_db.Columns.Add("daojuid", System.Type.GetType("System.String"));
            //lymx_db.Columns.Add("shuliang", System.Type.GetType("System.String"));
            //lymx_db.Columns.Add("jichuangbianma", System.Type.GetType("System.String"));
            //lymx_db.Columns.Add("daotaohao", System.Type.GetType("System.String"));
            //lymx_db.Columns.Add("beizhu", System.Type.GetType("System.String"));

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                DataRow rowrow = lymx_db.NewRow();

                rowrow["daojuleixing"] = tb.Rows[i]["djlx"];//刀具类型
                rowrow["daojuguige"] = tb.Rows[i]["djgg"];//刀具规格
                rowrow["changdu"] = "";//刀具长度
                rowrow["daojuid"] = tb.Rows[i]["djid"];//刀具id
                rowrow["shuliang"] = "1";//数量
                rowrow["jichuangbianma"] = "";//机床编码
                rowrow["daotaohao"] = "";//刀套号
                rowrow["beizhu"] = "";//备注

                lymx_db.Rows.Add(rowrow);
                HJ++;
            }

            lingyongmingxi.DataSource = lymx_db.DefaultView;
            heji.Text = HJ.ToString();
        }

        /// 领用班组变化，领用设备数据源相应变化
        private void LYBZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(LYBZ.SelectedIndex < 0)
            {
                LYSB.DataSource = null;
                return;
            }

            LYSB.DataSource = Alex.GetJCofBZ(LYBZ.Text);
        }

        /// 双击单元格，填充历史数据进行更改
        private void lingyongmingxi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.RowIndex >= 0 && e.RowIndex < lingyongmingxi.Rows.Count - 1)
            //{
            //    if(lingyongmingxi.Rows[e.RowIndex].DataBoundItem == null)
            //    {
            //        MessageBox.Show("如需修改请移除此条数据后重新添加。", Program.tishiTitle);
            //        return;
            //    }
            //    DataRow row = ((lingyongmingxi.Rows[e.RowIndex].DataBoundItem) as DataRowView).Row;
            //    xzlymx xzlymx = new xzlymx(row, e.RowIndex);
            //    xzlymx.Owner = this;
            //    xzlymx.ShowDialog();
            //}
        }

        public void EditLingYongMXbyRowinde(int rowindex, List<string> list)
        {
            if (rowindex >= 0)
            {
                DataRow rowrow = lymx_db.NewRow();

                rowrow["daojuleixing"] = list[0];//刀具类型
                rowrow["daojuguige"] = list[1];//刀具规格
                rowrow["changdu"] = list[2];//刀具长度
                rowrow["daojuid"] = list[3];//刀具id
                rowrow["shuliang"] = "1";//数量
                rowrow["jichuangbianma"] = list[4];//机床编码
                rowrow["daotaohao"] = list[5];//刀套号
                rowrow["beizhu"] = list[6];//备注

                lymx_db.Rows.RemoveAt(rowindex);
                lymx_db.Rows.InsertAt(rowrow, rowindex);

                //HJ++;//合计数量加一
                //heji.Text = HJ.ToString();//更新合计数量
            }
        }

        private void ZJGX_Click(object sender, EventArgs e)
        {
            GongXuXuanZe xzzjgx = new GongXuXuanZe();
            xzzjgx.Owner = this;
            xzzjgx.ShowDialog();
        }

        #region 明细信息联动部分
        /// <summary>刀具类型变化加载刀具规格</summary>
        private void cbx_lymx_djlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_lymx_djlx.SelectedIndex < 0)
            {
                cbx_lymx_djgg.DataSource = null;
                return;
            }
            else
            {
                Sqlstr = string.Format("SELECT DISTINCT {1} FROM {0} WHERE {2} = '{3}'", DaoJuTemp.TableName, DaoJuTemp.guige, DaoJuTemp.leixing, cbx_lymx_djlx.SelectedItem.ToString().Trim());
                cbx_lymx_djgg.DataSource = SQL.DataReadList(Sqlstr);
                cbx_lymx_djgg.SelectedIndex = -1;//默认为空
            }
        }

        /// <summary>刀具规格变化加载相应刀具id</summary>
        private void cbx_lymx_djgg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_lymx_djgg.SelectedIndex < 0)
            {
                cbx_lymx_djid.DataSource = null;
                return;
            }
            else
            {
                cbx_lymx_djid.DataSource = null;

                Sqlstr = string.Format("SELECT dj.{1} FROM {0} dj WHERE dj.{2} = 'S' AND dj.{3} = '{4}' AND dj.{5} = '{6}'", DaoJuTemp.TableName, DaoJuTemp.id, DaoJuTemp.weizhibiaoshi, DaoJuTemp.leixing, cbx_lymx_djlx.SelectedItem.ToString().Trim(), DaoJuTemp.guige, cbx_lymx_djgg.SelectedItem.ToString().Trim());

                List<string> list = new List<string>();
                list = SQL.DataReadList(Sqlstr);
                if (list.Count == 0)
                {
                    MessageBox.Show("该规格下没有空闲刀具，请装配刀具？", "提示");//是否进行刀具装配
                }
                else
                {
                    cbx_lymx_djid.DataSource = list;
                }
            }
        }

        //机床编码变化加载相应刀套号
        private void cbx_lymx_jcbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_lymx_jcbm.SelectedIndex < 0)
            {
                cbx_lymx_dth.DataSource = null;
                return;
            }

            Sqlstr = string.Format("SELECT jcdjk.{2} FROM {0} jcdjk LEFT JOIN {1} djtp ON CONCAT(djtp.{3},'-', djtp.{4} ) = CONCAT(jcdjk.{5},'-', jcdjk.{2} ) WHERE djtp.{6} IS NULL AND jcdjk.{5} = '{7}'", JiChuangDaoJuKu.TableName, DaoJuTemp.TableName, JiChuangDaoJuKu.dth, DaoJuTemp.weizhibianma, DaoJuTemp.csordth, JiChuangDaoJuKu.jcbm, DaoJuTemp.id, cbx_lymx_jcbm.SelectedItem.ToString().Trim());
            cbx_lymx_dth.DataSource = SQL.DataReadList(Sqlstr);
            cbx_lymx_dth.SelectedIndex = -1;
        }
        #endregion

        /// <summary>选中明细数据行填充明细数据</summary>
        private void lingyongmingxi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
            {
                return;
            }

            //选中最后一行
            if(e.RowIndex == lingyongmingxi.Rows.Count - 1)
            {
                cbx_lymx_djlx.SelectedIndex = -1;
                cbx_lymx_djgg.SelectedIndex = -1;
                cbx_lymx_djcd.SelectedIndex = -1;
                cbx_lymx_djid.SelectedIndex = -1;
                cbx_lymx_jcbm.SelectedIndex = -1;
                cbx_lymx_dth.SelectedIndex = -1;
                txt_lymx_bz.Text = "";
                txt_lymx_sl.Text = "";

                btn_lymx_sc.Enabled = false;
                btn_lymx_xg.Enabled = false;

                return;
            }

            if(Edit)
            {
                btn_lymx_sc.Enabled = true;
                btn_lymx_xg.Enabled = true;
            }

            //数据填充
            cbx_lymx_djlx.SelectedItem = lingyongmingxi.Rows[e.RowIndex].Cells["djlx"].Value.ToString();
            cbx_lymx_djgg.SelectedItem = lingyongmingxi.Rows[e.RowIndex].Cells["djgg"].Value.ToString();
            cbx_lymx_djcd.SelectedItem = lingyongmingxi.Rows[e.RowIndex].Cells["djcd"].Value.ToString();
            cbx_lymx_djid.SelectedItem = lingyongmingxi.Rows[e.RowIndex].Cells["djID"].Value.ToString();
            cbx_lymx_jcbm.SelectedItem = lingyongmingxi.Rows[e.RowIndex].Cells["jcbm"].Value.ToString();
            cbx_lymx_dth.SelectedItem = lingyongmingxi.Rows[e.RowIndex].Cells["dth"].Value.ToString();
            txt_lymx_bz.Text = lingyongmingxi.Rows[e.RowIndex].Cells["bz"].Value.ToString();
            txt_lymx_sl.Text = lingyongmingxi.Rows[e.RowIndex].Cells["sl"].Value.ToString();
        }

        /// <summary>明细修改按钮</summary>
        private void btn_lymx_xg_Click(object sender, EventArgs e)
        {
            //为选中行或者选中的是最后一行
            if (lingyongmingxi.SelectedRows.Count <= 0 || lingyongmingxi.CurrentRow.Index == lingyongmingxi.Rows.Count - 1)
            {
                MessageBox.Show("请先选中一行非空白的明细数据！", "提示");
                return;
            }

            if (AddDataCheck())
            {
                int crtrowindex = lingyongmingxi.CurrentRow.Index;

                //排除从总表勾选得到的明细数据因没有领用数量、机床编码、工序、备注而出错的情况
                if (lingyongmingxi.Rows[crtrowindex].Cells["sl"].Value.ToString() != "" && lingyongmingxi.Rows[crtrowindex].Cells["sl"] != null)
                {
                    HJ--;
                }

                lingyongmingxi.Rows[crtrowindex].Cells["djlx"].Value = cbx_lymx_djlx.SelectedItem.ToString();//刀具类型
                lingyongmingxi.Rows[crtrowindex].Cells["djgg"].Value = cbx_lymx_djgg.SelectedItem.ToString();//刀具规格
                lingyongmingxi.Rows[crtrowindex].Cells["djcd"].Value = cbx_lymx_djcd.Text;//刀具长度
                lingyongmingxi.Rows[crtrowindex].Cells["djID"].Value = cbx_lymx_djid.SelectedItem.ToString();//刀具ID
                lingyongmingxi.Rows[crtrowindex].Cells["jcbm"].Value = cbx_lymx_jcbm.SelectedItem.ToString();//领用机床编码
                lingyongmingxi.Rows[crtrowindex].Cells["dth"].Value = cbx_lymx_dth.SelectedItem.ToString();//刀套号
                lingyongmingxi.Rows[crtrowindex].Cells["sl"].Value = txt_lymx_sl.Text;//领用数量
                lingyongmingxi.Rows[crtrowindex].Cells["bz"].Value = txt_lymx_bz.Text;//备注

                HJ = HJ + Convert.ToInt16(txt_lymx_sl.Text);
                heji.Text = HJ.ToString();

                //修改完清除选中行，避免误操作
                lingyongmingxi.CurrentCell = null;
            }
        }
    }
}
