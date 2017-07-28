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
using FastReport;

namespace kucunTest.DaoJu
{
    public partial class DJWJ : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string SqlStr = "";

        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();

        DataTable wjmx_db = new DataTable();

        string DanJuBiao = "daojuwaijie";//和数据库查询有关的表名、字段名
        string MingXiBiao = "daojuwaijiemingxi";
        string DanHaoZD = "danhao";
        string LiuShuiBiao = "daojuliushui";

        int HJ = 0;
        #endregion

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DJWJ()
        {
            InitializeComponent();

            JYDW.SelectedIndex = 0;
            DWLD.SelectedIndex = 0;
            JBR.SelectedIndex = 0;

            heji.Text = HJ.ToString();

            YDGHSJ.Text = DateTime.Now.AddDays(3).ToString();//默认三天后为归还时间
            JCSJ.Text = DateTime.Now.ToString();//借出时间为当前日期

            SPLD.SelectedIndex = 0;
            SPYJ.Text = "同意外借。";

            WJDH.Text = Alex.DanHao("DJWJ");//自动生成单号
        }

        /// <summary>
        /// 重写构造函数，用于从历史记录窗体加载数据
        /// </summary>
        /// <param name="dh">从历史数据传过来的外借单号</param>
        public DJWJ(string dh)
        {
            InitializeComponent();

            //根据单号查询数据库借用和操作信息
            SqlStr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", DanJuBiao, DanHaoZD, dh);
            DataSet ds = SQL.getDataSet(SqlStr, DanJuBiao);

            //给借用信息和操作信息赋值
            WJDH.Text = dh;//单号
            JYDW.Text = ds.Tables[0].Rows[0]["jydw"].ToString();//借用单位
            DWLD.Text = ds.Tables[0].Rows[0]["dwld"].ToString();//单位领导
            YDGHSJ.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["ydghsj"].ToString());//约定归还时间
            JYR.Text = ds.Tables[0].Rows[0]["jyr"].ToString();//借用人
            LXDH.Text = ds.Tables[0].Rows[0]["lxdh"].ToString();//联系电话
            JYYY.Text = ds.Tables[0].Rows[0]["jyyy"].ToString();//借用原因
            SPLD.Text = ds.Tables[0].Rows[0]["spld"].ToString();//审批领导
            SPYJ.Text = ds.Tables[0].Rows[0]["spyj"].ToString();//审批意见
            JBR.Text = ds.Tables[0].Rows[0]["jbr"].ToString();//经办人
            JCSJ.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["jcsj"].ToString());//借出时间
            string djzt = ds.Tables[0].Rows[0]["djzt"].ToString();//单据状态

            //根据单号查询明细信息
            SqlStr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", MingXiBiao, DanHaoZD, dh);
            wjmx_db = (SQL.getDataSet(SqlStr, MingXiBiao)).Tables[0];//用全局变量保存查询出来的明细，方便后续可以继续添加
            WaiJieMingXi.AutoGenerateColumns = false;
            WaiJieMingXi.DataSource = wjmx_db.DefaultView;

            HJ = WaiJieMingXi.Rows.Count - 1;//更新合计数量
            heji.Text = HJ.ToString();

            //若是已完成的单据，则只允许查看，不许修改。
            if (djzt == "1")
            {
                Alex.DisableAllControl(this);
                print.Enabled = true;
            }
        }


        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJWJ_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);            
        }

        #region 明细部分
        /// <summary>
        /// 新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            xzwjmx xzwjmx = new xzwjmx();
            xzwjmx.Owner = this;
            xzwjmx.ShowDialog();
        }

        /// <summary>
        /// AddData函数，向datagridview中增加一行数据
        /// </summary>
        /// <param name="list">子窗体传输过来的list值</param>
        public void AddData(List<string> list)
        {
            //新的空白单据，未绑定数据源
            if(WaiJieMingXi.DataSource == null)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(WaiJieMingXi);

                row.Cells[0].Value = list[0];//刀具类型
                row.Cells[1].Value = list[1];//刀具规格
                row.Cells[2].Value = list[2];//刀具id
                row.Cells[3].Value = list[3];//刀具状态
                row.Cells[4].Value = "1";//数量
                row.Cells[5].Value = list[4];//机床编码
                row.Cells[6].Value = list[5];//刀套号
                row.Cells[7].Value = list[6];//备注

                WaiJieMingXi.Rows.Add(row);
            }
            else//暂时保存的单据，已经绑定了数据源
            {
                DataRow row1 = wjmx_db.NewRow();

                row1["djlx"] = list[0];//刀具类型
                row1["djgg"] = list[1];//刀具规格
                row1["djid"] = list[2];//刀具id
                row1["djzt"] = list[3];//刀具状态
                row1["sl"] = "1";//数量
                row1["jcbm"] = list[4];//机床编码
                row1["dth"] = list[5];//刀套号
                row1["bz"] = list[6];//备注

                wjmx_db.Rows.Add(row1);
            }

            HJ++;//合计数量加一
            heji.Text = HJ.ToString();//更新合计数量
        }

        /// <summary>
        /// datagridview每一行自动生成序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WaiJieMingXi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(WaiJieMingXi, e);
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            int k = WaiJieMingXi.SelectedRows.Count;
            if (k == 0)
            {
                MessageBox.Show("请先选择至少一行数据！", "提示", MessageBoxButtons.OK);
            }
            else if (WaiJieMingXi.CurrentRow.Index == WaiJieMingXi.Rows.Count - 1 || k == WaiJieMingXi.Rows.Count)//选中的是最后一行
            {
                MessageBox.Show("不能删除空白行！", "警告", MessageBoxButtons.OK);
            }
            else if (k == 1)
            {
                DialogResult result = MessageBox.Show("确定删除" + k + "行数据？", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    WaiJieMingXi.Rows.RemoveAt(WaiJieMingXi.CurrentRow.Index);
                    HJ--;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("确定删除" + k + "行数据？", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    for (int i = k; i >= 1; i--)//从下往上删，避免沙漏效应
                    {
                        WaiJieMingXi.Rows.RemoveAt(WaiJieMingXi.SelectedRows[i - 1].Index);
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
        private void button6_Click(object sender, EventArgs e)
        {
            if (JYDW.Text == "" && JYR.Text == "" && JYYY.Text == "" && WaiJieMingXi.Rows.Count == 1)//未填写任何内容，提示取消填写单据
            {
                if (MessageBox.Show("当前单据借用信息和借用明细为空，要直接取消填写单据？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                if(WaiJieMingXi.Rows.Count <= 1)
                {
                    if (MessageBox.Show("当前单据借用明细为空，确定要保存单据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        //this.Close();
                        return;
                    }
                }
                //将借用和操作数据存入数据库daojuwaijie表
                //数据预处理
                string dh = WJDH.Text.ToString().Trim();//外借单号
                string jydw = JYDW.Text.ToString().Trim();//借用单位
                string dwld = DWLD.Text.ToString().Trim();//单位领导
                string jyr = JYR.Text.ToString().Trim();//借用人
                string lxdh = LXDH.Text.ToString().Trim();//联系电话
                string jyyy = JYYY.Text.ToString().Trim();//借用原因
                string spld = SPLD.Text.ToString().Trim();//审批领导
                string spyj = SPYJ.Text.ToString().Trim();//审批意见
                string jbr = JBR.Text.ToString().Trim();//经办人
                string jcsj = JCSJ.Text.ToString();//借出时间
                string ydghsj = YDGHSJ.Value.ToString();//约定归还时间
                string danjuzhuangtai = "0";//单据状态

                if (Alex.CunZai(WJDH.Text.ToString().Trim(), DanHaoZD, DanJuBiao) != 0)//已经存在的暂时保存的单据，用update语句
                {
                    //SqlStr = string.Format("UPDATE {0} SET jydw = '{1}', dwld = '{2}', jyr = '{3}', lxdh = '{4}', jyyy = '{5}', spld = '{6}', spyj = '{7}', jbr = '{8}', jcsj = '{9}', ydghsj = '{10}' WHERE {11} = '{12}'", DanJuBiao, JYDW.Text.ToString().Trim(), DWLD.Text.ToString().Trim(), JYR.Text.ToString().Trim(), LXDH.Text.ToString().Trim(), JYYY.Text.ToString().Trim(), SPLD.Text.ToString().Trim(), SPYJ.Text.ToString().Trim(), JBR.Text.ToString().Trim(), JCSJ.Text.ToString(), YDGHSJ.Text.ToString(), DanHaoZD, WJDH.Text.ToString().Trim());
                    SqlStr = string.Format("UPDATE {0} SET jydw = '{1}', dwld = '{2}', jyr = '{3}', lxdh = '{4}', jyyy = '{5}', spld = '{6}', spyj = '{7}', jbr = '{8}', jcsj = '{9}', ydghsj = '{10}', djzt = '{11}' WHERE {12} = '{13}'", DanJuBiao, jydw, dwld, jyr, lxdh, jyyy, spld, spyj, jbr, jcsj, ydghsj, danjuzhuangtai, DanHaoZD, dh);
                }
                else//新单据，直接用插入语句insert
                {
                    //SqlStr = "INSERT INTO daojuwaijie(danhao, jydw, dwld, jyr, lxdh, jyyy, spld, spyj, jbr, jcsj, ydghsj) VALUES('" + WJDH.Text.ToString().Trim() + "', '" + JYDW.Text.ToString().Trim() + "', '" + DWLD.Text.ToString().Trim() + "', '" + JYR.Text.ToString().Trim() + "', '" + LXDH.Text.ToString().Trim() + "', '" + JYYY.Text.ToString().Trim() + "', '" + SPLD.Text.ToString().Trim() + "', '" + SPYJ.Text.ToString().Trim() + "', '" + JBR.Text.ToString().Trim() + "', '" + JCSJ.Text.ToString() + "', '" + YDGHSJ.Text.ToString() + "')";
                    SqlStr = "INSERT INTO daojuwaijie(danhao, jydw, dwld, jyr, lxdh, jyyy, spld, spyj, jbr, jcsj, ydghsj, djzt) VALUES('" + dh + "', '" + jydw + "', '" + dwld + "', '" + jyr + "', '" + lxdh + "', '" + jyyy + "', '" + spld + "', '" + spyj + "', '" + jbr + "', '" + jcsj + "', '" + ydghsj + "', '" + danjuzhuangtai + "')";
                }
                //SqlStr = "INSERT INTO daojuwaijie(danhao, jydw, dwld, jyr, lxdh, jyyy, spld, spyj, jbr, jcsj, ydghsj) VALUES('" + WJDH.Text.ToString().Trim() + "', '" + JYDW.Text.ToString().Trim() + "', '" + DWLD.Text.ToString().Trim() + "', '" + JYR.Text.ToString().Trim() + "', '" + LXDH.Text.ToString().Trim() + "', '" + JYYY.Text + "', '" + SPLD.Text.ToString().Trim() + "', '" + SPYJ.Text.ToString().Trim() + "', '" + JBR.Text.ToString().Trim() + "', '" + JCSJ.Text.ToString() + "', '" + YDGHSJ.Text.ToString() + "')";
                int row1 = SQL.ExecuteNonQuery(SqlStr);

                //将借用明细数据存入数据库daojuwaijiemingxi表

                //判断此单号在明细表中是否已存在,如果存在则一并删除，重新保存
                if (Alex.CunZai(WJDH.Text.ToString().Trim(), DanHaoZD, MingXiBiao) != 0)
                {
                    //delete语句删除已经存在的明细记录
                    SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", MingXiBiao, DanHaoZD, WJDH.Text.ToString().Trim());
                    int row2 = SQL.ExecuteNonQuery(SqlStr);
                }

                if (WaiJieMingXi.Rows.Count > 1)
                {
                    int row3 = 0;//明细数据存入外借明细表
                    if (row1 != 0)
                    {
                        //将明细数据一行一行存入数据库
                        for (int rowindex = 0; rowindex < WaiJieMingXi.Rows.Count - 1; rowindex++)
                        {
                            //借用明细数据格式化
                            string djlx = WaiJieMingXi.Rows[rowindex].Cells["djlx"].Value.ToString();//刀具类型
                            string djgg = WaiJieMingXi.Rows[rowindex].Cells["djgg"].Value.ToString();//刀具规格
                            string djid = WaiJieMingXi.Rows[rowindex].Cells["djID"].Value.ToString();//刀具id
                            string djzt = WaiJieMingXi.Rows[rowindex].Cells["djzt"].Value.ToString();//刀具状态
                            string sl = WaiJieMingXi.Rows[rowindex].Cells["sl"].Value.ToString();//数量
                            string jcbm = WaiJieMingXi.Rows[rowindex].Cells["jcbm"].Value.ToString();//机床编码
                            string dth = WaiJieMingXi.Rows[rowindex].Cells["dth"].Value.ToString();//刀套号
                            string bz = WaiJieMingXi.Rows[rowindex].Cells["bz"].Value.ToString();//备注

                            //借用明细数据存入数据库外借明细表
                            SqlStr = "INSERT INTO daojuwaijiemingxi(danhao, djlx, djgg, djid, djzt, sl, jcbm, dth, bz) VALUES('" + WJDH.Text.ToString().Trim() + "', '" + djlx + "', '" + djgg + "', '" + djid + "','" + djzt + "', '" + sl + "', '" + jcbm + "', '" + dth + "', '" + bz + "')";
                            row3 = SQL.ExecuteNonQuery(SqlStr);
                        }
                    }                    
                }

                MessageBox.Show("单据保存成功！可再次修改确认。", "提示", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// 确认单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否对单据进行确认？确认之后将不可修改！", "单据确认", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //数据验证
                if (CheckData() == 0)
                {
                    return;//数据输入有误
                }
                else
                {
                    //将借用和操作数据存入数据库daojuwaijie表
                    //数据预处理
                    string dh = WJDH.Text.ToString().Trim();//外借单号
                    string jydw = JYDW.Text.ToString().Trim();//借用单位
                    string dwld = DWLD.Text.ToString().Trim();//单位领导
                    string jyr = JYR.Text.ToString().Trim();//借用人
                    string lxdh = LXDH.Text.ToString().Trim();//联系电话
                    string jyyy = JYYY.Text.ToString().Trim();//借用原因
                    string spld = SPLD.Text.ToString().Trim();//审批领导
                    string spyj = SPYJ.Text.ToString().Trim();//审批意见
                    string jbr = JBR.Text.ToString().Trim();//经办人
                    string jcsj = JCSJ.Text.ToString();//借出时间
                    string ydghsj = YDGHSJ.Text.ToString();//约定归还时间
                    string danjuzhuangtai = "1";//单据状态

                    if (Alex.CunZai(WJDH.Text.ToString().Trim(), DanHaoZD, DanJuBiao) !=0 )//已经存在的暂时保存的单据，用update语句
                    {
                        //SqlStr = string.Format("UPDATE {0} SET jydw = '{1}', dwld = '{2}', jyr = '{3}', lxdh = '{4}', jyyy = '{5}', spld = '{6}', spyj = '{7}', jbr = '{8}', jcsj = '{9}', ydghsj = '{10}' WHERE {11} = '{12}'", DanJuBiao, JYDW.Text.ToString().Trim(), DWLD.Text.ToString().Trim(), JYR.Text.ToString().Trim(), LXDH.Text.ToString().Trim(), JYYY.Text.ToString().Trim(), SPLD.Text.ToString().Trim(), SPYJ.Text.ToString().Trim(), JBR.Text.ToString().Trim(), JCSJ.Text.ToString(), YDGHSJ.Text.ToString(), DanHaoZD, WJDH.Text.ToString().Trim());
                        SqlStr = string.Format("UPDATE {0} SET jydw = '{1}', dwld = '{2}', jyr = '{3}', lxdh = '{4}', jyyy = '{5}', spld = '{6}', spyj = '{7}', jbr = '{8}', jcsj = '{9}', ydghsj = '{10}', djzt = '{11}' WHERE {12} = '{13}'", DanJuBiao, jydw, dwld, jyr, lxdh, jyyy, spld, spyj, jbr, jcsj, ydghsj, danjuzhuangtai, DanHaoZD, dh);
                    }
                    else//新单据，直接用插入语句insert
                    {
                        //SqlStr = "INSERT INTO daojuwaijie(danhao, jydw, dwld, jyr, lxdh, jyyy, spld, spyj, jbr, jcsj, ydghsj) VALUES('" + WJDH.Text.ToString().Trim() + "', '" + JYDW.Text.ToString().Trim() + "', '" + DWLD.Text.ToString().Trim() + "', '" + JYR.Text.ToString().Trim() + "', '" + LXDH.Text.ToString().Trim() + "', '" + JYYY.Text.ToString().Trim() + "', '" + SPLD.Text.ToString().Trim() + "', '" + SPYJ.Text.ToString().Trim() + "', '" + JBR.Text.ToString().Trim() + "', '" + JCSJ.Text.ToString() + "', '" + YDGHSJ.Text.ToString() + "')";
                        SqlStr = "INSERT INTO daojuwaijie(danhao, jydw, dwld, jyr, lxdh, jyyy, spld, spyj, jbr, jcsj, ydghsj, djzt) VALUES('" + dh + "', '" + jydw + "', '" + dwld + "', '" + jyr + "', '" + lxdh + "', '" + jyyy + "', '" + spld + "', '" + spyj + "', '" + jbr + "', '" + jcsj + "', '" + ydghsj + "', '" + danjuzhuangtai + "')";
                    }
                    //SqlStr = "INSERT INTO daojuwaijie(danhao, jydw, dwld, jyr, lxdh, jyyy, spld, spyj, jbr, jcsj, ydghsj) VALUES('" + WJDH.Text.ToString().Trim() + "', '" + JYDW.Text.ToString().Trim() + "', '" + DWLD.Text.ToString().Trim() + "', '" + JYR.Text.ToString().Trim() + "', '" + LXDH.Text.ToString().Trim() + "', '" + JYYY.Text + "', '" + SPLD.Text.ToString().Trim() + "', '" + SPYJ.Text.ToString().Trim() + "', '" + JBR.Text.ToString().Trim() + "', '" + JCSJ.Text.ToString() + "', '" + YDGHSJ.Text.ToString() + "')";
                    int row1 = SQL.ExecuteNonQuery(SqlStr);

                    //将借用明细数据存入数据库daojuwaijiemingxi表和流水表
                    int row2 = 0;//明细数据存入外借明细表
                    int row3 = 0;//明细数据存入流水表
                    if (row1 != 0)
                    {
                        //判断此单号在明细表中是否已存在,如果存在则一并删除，重新保存
                        if (Alex.CunZai(WJDH.Text.ToString().Trim(), DanHaoZD, MingXiBiao) != 0)
                        {
                            //delete语句删除已经存在的明细记录
                            SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", MingXiBiao, DanHaoZD, WJDH.Text.ToString().Trim());
                            row2 = SQL.ExecuteNonQuery(SqlStr);
                        }

                        //将明细数据一行一行存入数据库
                        for (int rowindex = 0; rowindex < WaiJieMingXi.Rows.Count - 1; rowindex++)
                        {
                            //借用明细数据格式化
                            string djlx = WaiJieMingXi.Rows[rowindex].Cells["djlx"].Value.ToString();//刀具类型
                            string djgg = WaiJieMingXi.Rows[rowindex].Cells["djgg"].Value.ToString();//刀具规格
                            string djid = WaiJieMingXi.Rows[rowindex].Cells["djID"].Value.ToString();//刀具id
                            string djzt = WaiJieMingXi.Rows[rowindex].Cells["djzt"].Value.ToString();//刀具状态
                            string sl = WaiJieMingXi.Rows[rowindex].Cells["sl"].Value.ToString();//数量
                            string jcbm = WaiJieMingXi.Rows[rowindex].Cells["jcbm"].Value.ToString();//机床编码
                            string dth = WaiJieMingXi.Rows[rowindex].Cells["dth"].Value.ToString();//刀套号
                            string bz = WaiJieMingXi.Rows[rowindex].Cells["bz"].Value.ToString();//备注
                            
                            //借用明细数据存入数据库外借明细表
                            SqlStr = "INSERT INTO daojuwaijiemingxi(danhao, djlx, djgg, djid, djzt, sl, jcbm, dth, bz) VALUES('" + WJDH.Text.ToString().Trim() + "', '" + djlx + "', '" + djgg + "', '" + djid + "','" + djzt + "', '" + sl + "', '" + jcbm + "', '" + dth + "', '" + bz + "')";
                            row2 = SQL.ExecuteNonQuery(SqlStr);

                            //明细信息存入流水表
                            SqlStr = string.Format("INSERT INTO {0}(danhao, dhlx, djlx, djgg, djid, zsl, fsl, wzbm, jtwz ,czsj, jbr, bz) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}' ,'{8}', '{9}', '{10}', '{11}', '{12}')", LiuShuiBiao, dh, "刀具外借", djlx, djgg, djid, "0", sl, jydw, jyr, jcsj, jbr, bz);
                            row3 = SQL.ExecuteNonQuery(SqlStr);
                        }

                        if (row2 != 0)
                        {
                            MessageBox.Show("单据确认成功！", "提示", MessageBoxButtons.OK);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("借用明细数据填写有误，请检查并重试！", "警告", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("借用信息或操作信息填写有误，请检查并重试！", "警告", MessageBoxButtons.OK);
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
                DataTable table1 = new DataTable();//存放明细数据
                table1.TableName = "Table1"; // 一定要设置表名称

                // 添加表中的列
                table1.Columns.Add("xh", typeof(string));
                table1.Columns.Add("djlx", typeof(string));
                table1.Columns.Add("djgg", typeof(string));
                //table1.Columns.Add("djcd", typeof(string));
                table1.Columns.Add("djid", typeof(string));
                table1.Columns.Add("sl", typeof(string));
                table1.Columns.Add("jcbm", typeof(string));
                table1.Columns.Add("dth", typeof(string));
                table1.Columns.Add("bz", typeof(string));

                //添加明细数据
                for (int rowindex = 0; rowindex < WaiJieMingXi.Rows.Count; rowindex++)
                {
                    //格式化刀具数据
                    string djlx = WaiJieMingXi.Rows[rowindex].Cells["djlx"].Value.ToString();
                    string djgg = WaiJieMingXi.Rows[rowindex].Cells["djgg"].Value.ToString();
                    //string djcd = WaiJieMingXi.Rows[rowindex].Cells["djcd"].Value.ToString();
                    string djid = WaiJieMingXi.Rows[rowindex].Cells["djid"].Value.ToString();
                    string sl = WaiJieMingXi.Rows[rowindex].Cells["sl"].Value.ToString();
                    string jcbm = WaiJieMingXi.Rows[rowindex].Cells["jcbm"].Value.ToString();
                    string dth = WaiJieMingXi.Rows[rowindex].Cells["dth"].Value.ToString();
                    string bz = WaiJieMingXi.Rows[rowindex].Cells["bz"].Value.ToString();

                    DataRow row = table1.NewRow();
                    row["xh"] = rowindex + 1;
                    row["djlx"] = djlx;
                    row["djgg"] = djgg;
                    //row["daojuchangdu"] = djcd;
                    row["djid"] = djid;
                    row["sl"] = sl;
                    row["jcbm"] = jcbm;
                    row["dth"] = dth;
                    row["bz"] = bz;

                    table1.Rows.Add(row);
                }

                FRds.Tables.Add(table1);

                Report FReport = new Report();
                //string sPath = @"C:\Users\workstation\Desktop\Alex\kucunTest\kucunTest\File";
                //string sPath = @"C:\Users\workstation\Desktop\Alex\kucunTest\kucunTest\File" + @"\刀具领用单" + ".frx";
                string sPath = @"../../File/刀具外借单.frx";
                FReport.Load(sPath);  // 将DataSet对象注册到FastReport控件中
                FReport.RegisterData(FRds);

                FReport.SetParameterValue("danhao", WJDH.Text);
                FReport.SetParameterValue("jydw", JYDW.Text);
                FReport.SetParameterValue("jyr", JYR.Text);
                FReport.SetParameterValue("ydghsj", YDGHSJ.Text.ToString());
                FReport.SetParameterValue("lxdh", LXDH.Text);
                FReport.SetParameterValue("jyyy", JYYY.Text);
                FReport.SetParameterValue("dwld", DWLD.Text);
                FReport.SetParameterValue("jbr", JBR.Text);
                FReport.SetParameterValue("spld", SPLD.Text);
                FReport.SetParameterValue("spyj", SPYJ.Text);
                FReport.SetParameterValue("jcsj", JCSJ.Text.ToString());

                //显示报表
                FReport.Prepare();
                FReport.ShowPrepared();
                //FReport.Show();
            }
        }

        /// <summary>
        /// 删除单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_Click(object sender, EventArgs e)
        {
            if(Alex.CunZai(WJDH.Text.ToString().Trim(), DanHaoZD, DanJuBiao) != 0)
            {
                DialogResult dr = MessageBox.Show("确认删除此单据？", "删除确认", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //删除刀具领用表中的数据
                    SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", DanJuBiao, DanHaoZD, WJDH.Text.ToString().Trim());
                    int row1 = SQL.ExecuteNonQuery(SqlStr);

                    //删除明细
                    SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", MingXiBiao, DanHaoZD, WJDH.Text.ToString().Trim());
                    int row2 = SQL.ExecuteNonQuery(SqlStr);
                    MessageBox.Show("成功删除一张单据和" + row2 + "条明细记录！");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("单据还未保存，不可删除！", "提示", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// 外界历史按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认打开借用历史记录并关闭此窗口？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                History wjlishi = new History("DJWJ");
                wjlishi.Show();
                this.Close();
            }
        }

        /// <summary>
        /// 单据设置按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            DanJuSheZhi djsz = new DanJuSheZhi();
            djsz.ShowDialog();
        }

        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion 按钮部分结束

        #region 其他方法
        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        private int CheckData()
        {
            string tishi = "";
            if (JYDW.Text == "" || JYR.Text == "" || JYYY.Text == "" || SPLD.Text == "" || SPYJ.Text == "" || JBR.Text == "")
            {
                if (JYDW.Text.ToString() == "")
                {
                    tishi = "请填写借用单位！";
                }
                else if (JYR.Text.ToString() == "")
                {
                    tishi = "请填写借用人！";
                }
                else if (JYYY.Text.ToString() == "")
                {
                    tishi = "请填写借用原因！";
                }
                else if (SPLD.Text.ToString() == "")
                {
                    tishi = "请填写审批领导！";
                }
                else if (SPYJ.Text.ToString() == "")
                {
                    tishi = "请填写审批意见！";
                }
                else if (JBR.Text.ToString() == "")
                {
                    tishi = "请填写经办人！";
                }
            }
            else if (WaiJieMingXi.Rows.Count == 1)
            {
                tishi = "外借刀具明细不能为空！";
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
        /// 窗体自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJWJ_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        #endregion 其他方法结束
        
    }
}
