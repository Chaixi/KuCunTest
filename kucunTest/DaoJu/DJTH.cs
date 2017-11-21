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
    public partial class DJTH : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string SqlStr = "";

        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();

        DataTable thmx_db = new DataTable();

        string DanJuBiao = "daojutuihuan";//和数据库查询有关的表名、字段名
        string MingXiBiao = "daojutuihuanmingxi";
        string DanHaoZD = "danhao";
        string LiuShuiBiao = "daojuliushui";
        string daojutemp = "daojutemp";

        int HJ = 0;//合计刀具数量
        #endregion

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DJTH()
        {
            InitializeComponent();

            THDH.Text = Alex.DanHao("DJTH");//自动生成单号

            THBZ.DataSource = Alex.GetList("bz");
            THBZ.SelectedIndex = -1;
            JBR.SelectedIndex = 0;
            THYY.Text = "机床常规退还。";//默认退还原因为"机床常规退还。"
            heji.Text = HJ.ToString();
            THRQ.Value = DateTime.Now;//退还日期为当前日期
        }

        /// <summary>
        /// 重写构造函数，用于从历史记录窗体加载数据
        /// </summary>
        /// <param name="dh">退还单号</param>
        public DJTH(string dh)
        {
            InitializeComponent();

            //根据单号查询数据库退还和操作信息
            SqlStr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", DanJuBiao, DanHaoZD, dh);
            DataSet ds = SQL.getDataSet(SqlStr, DanJuBiao);

            //给借用信息和操作信息赋值
            THDH.Text = dh;//单号
            THBZ.Text = ds.Tables[0].Rows[0]["thbz"].ToString();//退还班组
            THR.Text = ds.Tables[0].Rows[0]["thr"].ToString();//退还人
            THRQ.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["thrq"].ToString());//退还日期
            THYY.Text = ds.Tables[0].Rows[0]["thyy"].ToString();//退还原因
            JBR.Text = ds.Tables[0].Rows[0]["jbr"].ToString();//经办人
            JBRQ.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["jbrq"].ToString());//经办日期
            string djzt = ds.Tables[0].Rows[0]["djzt"].ToString();//单据状态

            //根据单号查询明细信息
            SqlStr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", MingXiBiao, DanHaoZD, dh);
            thmx_db = (SQL.getDataSet(SqlStr, MingXiBiao)).Tables[0];//用全局变量保存查询出来的明细，方便后续可以继续添加
            TuiHuanMingXi.AutoGenerateColumns = false;
            TuiHuanMingXi.DataSource = thmx_db.DefaultView;

            HJ = TuiHuanMingXi.Rows.Count - 1;//更新合计数量
            heji.Text = HJ.ToString();

            //若是已完成的单据，则只允许查看，不许修改。
            if (djzt == "1")
            {
                Alex.DisableAllControl(this);
                button_print.Enabled = true;
            }
        }

        /// <summary>
        /// 窗体加载 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJTH_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        #region 明细部分
        /// <summary>
        /// 退还明细新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            xzthmx xzthmx = new xzthmx();
            xzthmx.Owner = this;
            xzthmx.ShowDialog();
        }

        /// <summary>
        /// AddData函数，向datagridview中增加一行数据
        /// </summary>
        /// <param name="list">子窗体传输过来的list值</param>
        public void AddData(List<string> list)
        {
            //新的空白单据，未绑定数据源
            if (TuiHuanMingXi.DataSource == null)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(TuiHuanMingXi);

                row.Cells[0].Value = list[0];//刀具类型
                row.Cells[1].Value = list[1];//刀具规格
                row.Cells[2].Value = list[2];//刀具长度
                row.Cells[3].Value = list[3];//刀具id
                row.Cells[4].Value = list[4];//刀具状态
                row.Cells[5].Value = "1";//数量
                row.Cells[6].Value = list[5];//机床编码
                row.Cells[7].Value = list[6];//刀套号
                row.Cells[8].Value = list[7];//刀具柜编码
                row.Cells[9].Value = list[8];//存放位置
                row.Cells[10].Value = list[9];//备注

                TuiHuanMingXi.Rows.Add(row);
            }
            else//暂时保存的单据，已经绑定了数据源
            {
                DataRow row = thmx_db.NewRow();

                row["djlx"] = list[0];//刀具类型
                row["djgg"] = list[1];//刀具规格
                row["djcd"] = list[2];//刀具长度
                row["djid"] = list[3];//刀具id
                row["djzt"] = list[4];//刀具状态
                row["sl"] = "1";//数量
                row["jcbm"] = list[5];//机床编码
                row["dth"] = list[6];//刀套号
                row["djgbm"] = list[7];//刀具柜编码
                row["cfwz"] = list[8];//存放位置
                row["bz"] = list[9];//备注

                thmx_db.Rows.Add(row);
            }

            HJ++;//合计数量加一
            heji.Text = HJ.ToString();//更新合计数量
        }

        /// <summary>
        /// 退还明细删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            int k = TuiHuanMingXi.SelectedRows.Count;
            if (k == 0)
            {
                MessageBox.Show("请先选择至少一行数据！", "提示", MessageBoxButtons.OK);
            }
            else if (TuiHuanMingXi.CurrentRow.Index == TuiHuanMingXi.Rows.Count - 1 || k == TuiHuanMingXi.Rows.Count)//选中的是最后一行
            {
                MessageBox.Show("不能删除空白行！", "警告", MessageBoxButtons.OK);
            }
            else if (k == 1)
            {
                DialogResult result = MessageBox.Show("确定删除" + k + "行数据？", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    TuiHuanMingXi.Rows.RemoveAt(TuiHuanMingXi.CurrentRow.Index);
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
                        TuiHuanMingXi.Rows.RemoveAt(TuiHuanMingXi.SelectedRows[i - 1].Index);
                        HJ--;  //合计数量减一
                    }
                }
            }

            heji.Text = HJ.ToString();//更新合计数量
        }

        /// <summary>
        /// datagridview每一行自动生成序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MingXi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(TuiHuanMingXi, e);
        }

        #endregion 明细部分结束

        #region 按钮部分
        /// <summary>
        /// 保存单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (THBZ.Text == "" && THR.Text == "")//未填写任何内容，提示取消填写单据
            {
                if (MessageBox.Show("单据未填写退换信息，要直接取消填写单据？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                if (TuiHuanMingXi.Rows.Count <= 1)
                {
                    if (MessageBox.Show("当前单据退还明细为空，确定要保存单据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        //this.Close();
                        return;
                    }
                }

                //将退还和操作数据存入数据库daojutuihuan表
                //数据预处理
                string danjuzhuangtai = "0";//单据状态
                string dh = THDH.Text.ToString().Trim();//单号
                string thbz = THBZ.Text.ToString().Trim();//退还班组
                string thr = THR.Text.ToString().Trim();//退还人
                string thrq = THRQ.Value.ToString().Trim();//退还日期
                string thyy = THYY.Text.ToString().Trim();//退还原因
                string jbr = JBR.Text.ToString().Trim();//经办人
                string jbrq = JBRQ.Value.ToString();//经办日期

                //判断是否是暂存单据，存入刀具退还数据库daojutuihuan
                if (Alex.CunZai(dh, DanHaoZD, DanJuBiao) != 0)
                {
                    SqlStr = string.Format("UPDATE {0} SET djzt = '{1}', thbz = '{2}', thr = '{3}', thrq = '{4}', thyy = '{5}', jbr = '{6}', jbrq = '{7}' WHERE {8} = '{9}'", DanJuBiao, danjuzhuangtai, thbz, thr, thrq, thyy, jbr, jbrq, DanHaoZD, dh);
                }
                else
                {
                    SqlStr = string.Format("INSERT INTO {0}(danhao, djzt, thbz, thr, thrq, thyy, jbr, jbrq) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", DanJuBiao, dh, danjuzhuangtai, thbz, thr, thrq, thyy, jbr, jbrq);
                }
                int row1 = SQL.ExecuteNonQuery(SqlStr);

                //将退还明细数据存入数据库daojutuihuanmingxi表
                int row2 = 0;

                //判断此单号在明细表中是否已存在,如果存在则一并删除，重新保存
                if (Alex.CunZai(THDH.Text.ToString().Trim(), DanHaoZD, MingXiBiao) != 0)
                {
                    //delete语句删除已经存在的明细记录
                    SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", MingXiBiao, DanHaoZD, THDH.Text.ToString().Trim());
                    row2 = SQL.ExecuteNonQuery(SqlStr);
                }

                if (TuiHuanMingXi.Rows.Count > 1)
                {
                    if (row1 != 0)
                    {
                        //明细数据格式化,一行一行存入数据库
                        for (int rowindex = 0; rowindex < TuiHuanMingXi.Rows.Count - 1; rowindex++)
                        {
                            string djlx = TuiHuanMingXi.Rows[rowindex].Cells["mx_djlx"].Value.ToString();//刀具类型
                            string djgg = TuiHuanMingXi.Rows[rowindex].Cells["mx_djgg"].Value.ToString();//刀具规格
                            string djcd = TuiHuanMingXi.Rows[rowindex].Cells["mx_djcd"].Value.ToString();//刀具长度
                            string djid = TuiHuanMingXi.Rows[rowindex].Cells["mx_djid"].Value.ToString();//刀具id
                            string djzt = TuiHuanMingXi.Rows[rowindex].Cells["mx_djzt"].Value.ToString();//刀具状态
                            string sl = TuiHuanMingXi.Rows[rowindex].Cells["mx_sl"].Value.ToString();//数量
                            string jcbm = TuiHuanMingXi.Rows[rowindex].Cells["mx_jcbm"].Value.ToString();//机床编码
                            string dth = TuiHuanMingXi.Rows[rowindex].Cells["mx_dth"].Value.ToString();//刀套号
                            string djgbm = TuiHuanMingXi.Rows[rowindex].Cells["mx_djgbm"].Value.ToString();//刀具柜编码
                            string cfwz = TuiHuanMingXi.Rows[rowindex].Cells["mx_cfwz"].Value.ToString();//存放位置
                            string bz = TuiHuanMingXi.Rows[rowindex].Cells["mx_bz"].Value.ToString();//备注

                            //退还明细数据存入数据库退还明细表
                            SqlStr = "INSERT INTO daojutuihuanmingxi(danhao, djlx, djgg, djcd, djid, djzt, sl, jcbm, dth, djgbm, cfwz, bz) values('" + dh + "', '" + djlx + "', '" + djgg + "', '" + djcd + "','" + djid + "','" + djzt + "', '" + sl + "', '" + jcbm + "', '" + dth + "', '" + djgbm + "', '" + cfwz + "', '" + bz + "')";
                            row2 = SQL.ExecuteNonQuery(SqlStr);
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
            DialogResult result = MessageBox.Show("是否对单据进行确认？确认之后将不可修改！", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //数据验证
                if (CheckData() == 0)
                {
                    return;//数据输入有误
                }
                else
                {
                    //将退还和操作数据存入数据库daojutuihuan表
                    //数据预处理
                    string danjuzhuangtai = "1";//单据状态
                    string dh = THDH.Text.ToString().Trim();//单号
                    string thbz = THBZ.Text.ToString().Trim();//退还班组
                    string thr = THR.Text.ToString().Trim();//退还人
                    string thrq = THRQ.Value.ToString().Trim();//退还日期
                    string thyy = THYY.Text.ToString().Trim();//退还原因
                    string jbr = JBR.Text.ToString().Trim();//经办人
                    string jbrq = JBRQ.Text.ToString();//经办日期

                    //判断是否是暂存单据，存入刀具退还数据库daojutuihuan
                    if (Alex.CunZai(dh, DanHaoZD, DanJuBiao) != 0)
                    {
                        SqlStr = string.Format("UPDATE {0} SET djzt = '{1}', thbz = '{2}', thr = '{3}', thrq = '{4}', thyy = '{5}', jbr = '{6}', jbrq = '{7}' WHERE {8} = '{9}'", DanJuBiao, danjuzhuangtai, thbz, thr, thrq, thyy, jbr, jbrq, DanHaoZD, dh);
                    }
                    else
                    {
                        SqlStr = string.Format("INSERT INTO {0}(danhao, djzt, thbz, thr, thrq, thyy, jbr, jbrq) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", DanJuBiao, dh, danjuzhuangtai, thbz, thr, thrq, thyy, jbr, jbrq);
                    }
                    //SqlStr = "insert into daojutuihuan(danhao, thbz, thr, thrq, thyy, jbr, jbrq) values('" + THDH.Text.ToString().Trim() + "', '" + THBZ.Text.ToString().Trim() + "', '" + THR.Text.ToString().Trim() + "', '" + THRQ.Text.ToString().Trim() + "', '" + THYY.Text.ToString().Trim() + "', '" + JBR.Text + "', '" + JBRQ.Text.ToString().Trim() + "')";
                    int row1 = SQL.ExecuteNonQuery(SqlStr);

                    //将退还明细数据存入数据库daojutuihuanmingxi表
                    int row2 = 0;//记录插入明细表数据
                    int row3 = 0;//记录插入流水表数据
                    int row4 = 0;//记录更新刀具监测表数据
                    string dskysl = "";//此类型刀具的当时可用数量！！！当时可用数量为单据操作后的刀具可用数量

                    if (row1 != 0)
                    {
                        //判断此单号在明细表中是否已存在,如果存在则一并删除，重新保存
                        if (Alex.CunZai(THDH.Text.ToString().Trim(), DanHaoZD, MingXiBiao) != 0)
                        {
                            //delete语句删除已经存在的明细记录
                            SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", MingXiBiao, DanHaoZD, THDH.Text.ToString().Trim());
                            row2 = SQL.ExecuteNonQuery(SqlStr);
                        }

                        //明细数据格式化
                        for (int rowindex = 0; rowindex < TuiHuanMingXi.Rows.Count - 1; rowindex++)
                        {
                            string djlx = TuiHuanMingXi.Rows[rowindex].Cells["mx_djlx"].Value.ToString();//刀具类型
                            string djgg = TuiHuanMingXi.Rows[rowindex].Cells["mx_djgg"].Value.ToString();//刀具规格
                            string djcd = TuiHuanMingXi.Rows[rowindex].Cells["mx_djcd"].Value.ToString();//刀具长度
                            string djid = TuiHuanMingXi.Rows[rowindex].Cells["mx_djid"].Value.ToString();//刀具id
                            string djzt = TuiHuanMingXi.Rows[rowindex].Cells["mx_djzt"].Value.ToString();//刀具状态
                            string sl = TuiHuanMingXi.Rows[rowindex].Cells["mx_sl"].Value.ToString();//数量
                            string jcbm = TuiHuanMingXi.Rows[rowindex].Cells["mx_jcbm"].Value.ToString();//机床编码
                            string dth = TuiHuanMingXi.Rows[rowindex].Cells["mx_dth"].Value.ToString();//刀套号
                            string djgbm = TuiHuanMingXi.Rows[rowindex].Cells["mx_djgbm"].Value.ToString();//刀具柜编码
                            string cfwz = TuiHuanMingXi.Rows[rowindex].Cells["mx_cfwz"].Value.ToString();//存放位置
                            string bz = TuiHuanMingXi.Rows[rowindex].Cells["mx_bz"].Value.ToString();//备注

                            //查询此类型刀具当时可用数量, 刀具退还可用数量加一
                            dskysl = (Alex.Count_djsl(djlx, "kysl") + 1).ToString();

                            //退还明细数据存入数据库退还明细表
                            SqlStr = "INSERT INTO daojutuihuanmingxi(danhao, djlx, djgg, djcd, djid, djzt, sl, jcbm, dth, djgbm, cfwz, bz) values('" + dh + "', '" + djlx + "', '" + djgg + "', '" + djcd + "','" + djid + "','" + djzt + "', '" + sl + "', '" + jcbm + "', '" + dth + "', '" + djgbm + "', '" + cfwz + "', '" + bz + "')";
                            row2 = SQL.ExecuteNonQuery(SqlStr);

                            //明细信息存入流水表
                            SqlStr = string.Format("INSERT INTO {0}(danhao, dhlx, djlx, djgg, djid, zsl, fsl, dskysl, wzbm, jtwz ,czsj, jbr, bz) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}' ,'{8}', '{9}', '{10}', '{11}', '{12}', '{13}')", LiuShuiBiao, dh, "刀具退还", djlx, djgg, djid, sl, "0", dskysl, djgbm, cfwz, jbrq, jbr, bz);
                            row3 = SQL.ExecuteNonQuery(SqlStr);

                            //更新刀具位置寿命监测表
                            SqlStr = string.Format("UPDATE {0} dj SET dj.weizhibiaoshi = 'S', dj.weizhi = '{1}', dj.cengshu = '{2}' WHERE dj.daojuid = '{3}'", daojutemp, djgbm, cfwz, djid);
                            row4 = SQL.ExecuteNonQuery(SqlStr);
                        }

                        //明细数据存入数据库
                        //int row2 = SQL.ExecuteNonQuery(Sqlstr);
                        if (row2 != 0)
                        {
                            MessageBox.Show("单据确认成功！", "提示", MessageBoxButtons.OK);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("刀具明细数据填写有误，请检查并重试！", "警告", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("退还信息或操作信息填写有误，请检查并重试！", "警告", MessageBoxButtons.OK);
                    }
                }
            }
        }

        /// <summary>
        /// 打印单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_print_Click(object sender, EventArgs e)
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
                table1.Columns.Add("djlx", typeof(string));
                table1.Columns.Add("djgg", typeof(string));
                table1.Columns.Add("djcd", typeof(string));
                table1.Columns.Add("djid", typeof(string));
                table1.Columns.Add("djzt", typeof(string));
                table1.Columns.Add("sl", typeof(string));
                table1.Columns.Add("jcbm", typeof(string));
                table1.Columns.Add("dth", typeof(string));
                table1.Columns.Add("djgbm", typeof(string));
                table1.Columns.Add("cfwz", typeof(string));
                table1.Columns.Add("bz", typeof(string));

                //添加明细数据
                for (int rowindex = 0; rowindex < TuiHuanMingXi.Rows.Count - 1; rowindex++)
                {
                    //格式化刀具数据
                    string djlx = TuiHuanMingXi.Rows[rowindex].Cells["mx_djlx"].Value.ToString();
                    string djgg = TuiHuanMingXi.Rows[rowindex].Cells["mx_djgg"].Value.ToString();
                    string djcd = TuiHuanMingXi.Rows[rowindex].Cells["mx_djcd"].Value.ToString();
                    string djid = TuiHuanMingXi.Rows[rowindex].Cells["mx_djid"].Value.ToString();
                    string djzt = TuiHuanMingXi.Rows[rowindex].Cells["mx_djzt"].Value.ToString();
                    string sl = TuiHuanMingXi.Rows[rowindex].Cells["mx_sl"].Value.ToString();
                    string jcbm = TuiHuanMingXi.Rows[rowindex].Cells["mx_jcbm"].Value.ToString();
                    string dth = TuiHuanMingXi.Rows[rowindex].Cells["mx_dth"].Value.ToString();
                    string djgbm = TuiHuanMingXi.Rows[rowindex].Cells["mx_djgbm"].Value.ToString();
                    string cfwz = TuiHuanMingXi.Rows[rowindex].Cells["mx_cfwz"].Value.ToString();
                    string bz = TuiHuanMingXi.Rows[rowindex].Cells["mx_bz"].Value.ToString();

                    DataRow row = table1.NewRow();
                    row["xh"] = rowindex + 1;
                    row["djlx"] = djlx;
                    row["djgg"] = djgg;
                    row["djcd"] = djcd;
                    row["djid"] = djid;
                    row["djzt"] = djzt;
                    row["sl"] = sl;
                    row["jcbm"] = jcbm;
                    row["dth"] = dth;
                    row["djgbm"] = djgbm;
                    row["cfwz"] = cfwz;
                    row["bz"] = bz;

                    table1.Rows.Add(row);
                }

                FRds.Tables.Add(table1);

                Report FReport = new Report();
                //string sPath = @"C:\Users\workstation\Desktop\Alex\kucunTest\kucunTest\File";
                //string sPath = @"C:\Users\workstation\Desktop\Alex\kucunTest\kucunTest\File" + @"\刀具领用单" + ".frx";
                string sPath = @"../../File/刀具退还单.frx";
                FReport.Load(sPath);  // 将DataSet对象注册到FastReport控件中
                                      //FReport.RegisterData(ds1);
                FReport.RegisterData(FRds);

                FReport.SetParameterValue("danhao", THDH.Text);
                FReport.SetParameterValue("thbz", THBZ.Text);
                FReport.SetParameterValue("thr", THR.Text);
                FReport.SetParameterValue("thrq", THRQ.Text.ToString());
                FReport.SetParameterValue("thyy", THYY.Text);
                FReport.SetParameterValue("jbr", JBR.Text);
                FReport.SetParameterValue("jbrq", JBRQ.Text);

                //显示报表
                FReport.Prepare();
                FReport.ShowPrepared();
                //FReport.Show();
            }
        }

        /// <summary>
        /// 退还历史按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_history_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确认打开报废历史记录并关闭此窗口？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                History thlishi = new History("DJTH");
                thlishi.Show();
                this.Close();
            }
        }

        /// <summary>
        /// 删除单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_cancel_Click(object sender, EventArgs e)
        {
            if(Alex.CunZai(THDH.Text.ToString().Trim(), DanHaoZD, DanJuBiao) != 0)
            {
                DialogResult dr = MessageBox.Show("确认删除此单据？", "删除确认", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //删除刀具领用表中的数据
                    SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", DanJuBiao, DanHaoZD, THDH.Text.ToString().Trim());
                    int row1 = SQL.ExecuteNonQuery(SqlStr);

                    //删除明细
                    SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", MingXiBiao, DanHaoZD, THDH.Text.ToString().Trim());
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
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion 按钮部分结束

        #region 其他部分
        /// <summary>
        /// 经办日期默认和退换日期一致
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void THRQ_ValueChanged(object sender, EventArgs e)
        {
            JBRQ.Value = THRQ.Value;
        }

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        private int CheckData()
        {
            string tishi = "";
            if (THBZ.Text == "" || THR.Text == "" || THRQ.Text == "" || JBR.Text == "" || JBRQ.Text == "")
            {
                if (THBZ.Text.ToString() == "")
                {
                    tishi = "请选择退还班组！";
                }
                else if (THR.Text.ToString() == "")
                {
                    tishi = "请填写退还人！";
                }
                else if (THRQ.Text.ToString() == "")
                {
                    tishi = "请选择退还日期！";
                }
                else if (JBR.Text.ToString() == "")
                {
                    tishi = "请填写经办人！";
                }
                else if (JBRQ.Text.ToString() == "")
                {
                    tishi = "请选择经办日期！";
                }
            }
            else if (TuiHuanMingXi.Rows.Count == 1)
            {
                tishi = "退还刀具明细不能为空！";
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
        private void DJTH_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        /// <summary>
        /// 当窗体在选项卡中打开时，关闭窗体则关闭相应的选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJTH_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Parent != null)
            {
                MainForm mfr = (MainForm)this.Parent.FindForm();
                mfr.CloseTab(this.Name);
            }
        }
        #endregion 其他部分结束

        /// <summary>
        /// 从表增加明细，即可以通过选择多条记录一并新增明细
        /// </summary>
        /// <param name="tb">要新增的明细表部分内容</param>
        public void AddDataFromTable(DataTable tb)
        {
            thmx_db.Columns.Add("djlx", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("djgg", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("djcd", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("djid", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("djzt", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("sl", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("jcbm", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("dth", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("djgbm", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("cfwz", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("bz", System.Type.GetType("System.String"));

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                DataRow rowrow = thmx_db.NewRow();

                rowrow["djlx"] = tb.Rows[i]["djlx"];//刀具类型
                rowrow["djgg"] = tb.Rows[i]["djgg"];//刀具规格
                rowrow["djcd"] = "";//刀具长度
                rowrow["djid"] = tb.Rows[i]["djid"];//刀具id
                rowrow["djzt"] = "";//刀具状态
                rowrow["sl"] = "1";//数量

                string djwz = tb.Rows[0]["djwz"].ToString().Trim();
                rowrow["jcbm"] = djwz.Substring(2, djwz.Length - 6);//截取机床编码，去掉2位位置标识前缀和4位具体位置标识
                rowrow["dth"] = djwz.Substring(djwz.Length - 3);//刀套号

                rowrow["djgbm"] = "";//刀具柜编码
                rowrow["cfwz"] = "";//存放位置
                rowrow["bz"] = "";//备注

                thmx_db.Rows.Add(rowrow);
                HJ++;
            }

            TuiHuanMingXi.DataSource = thmx_db.DefaultView;
            heji.Text = HJ.ToString();
        }
    }
}
