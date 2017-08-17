using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using kucunTest.BaseClasses;
using FastReport;

namespace kucunTest.DaoJu
{
    public partial class DJCCD : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";
        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();//窗口自适应类
        int HJ = 0;

        DataSet lymx_ds = new DataSet();
        DataTable lymx_db = new DataTable();

        string danjubiao = "daojulingyong";
        string mingxibiao = "daojulingyongmingxi";
        string liushuibiao = "daojuliushui";
        string DHZD = "chucangdanhao";
        #endregion

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DJCCD()
        {
            InitializeComponent();

            danhao.Text = Alex.DanHao("DJCC");//自动生成单号
            LYRQ.Value = DateTime.Now;
            LYBZ.SelectedIndex = 0;
            JBR.SelectedIndex = 0;
            heji.Text = HJ.ToString();

            lingyongmingxi.AutoGenerateColumns = false;//禁止自动生成行
        }

        /// <summary>
        /// 重写构造函数，用于从历史记录窗体加载数据
        /// </summary>
        /// <param name="list">从历史记录传过来的值</param>
        public DJCCD(List<string> list)
        {
            InitializeComponent();//

            lingyongmingxi.AutoGenerateColumns = false;//禁止自动生成行

            //danhao.Text = dh;

            danhao.Text = list[0];//list[0] 领用单号
            ZJGX.Text = list[1];//list[1] 制件工序
            LYBZ.Text = list[2];//list[2] 领用班组
            LYSB.Text = list[3];//list[3] 领用设备
            LYR.Text = list[4];//list[4] 领用人
            LYRQ.Value = Convert.ToDateTime(list[5]);//list[5] 领用日期
            JBR.Text = list[6];//list[6] 经办人
            beizhu.Text = list[7];//list[7] 备注
            string danjuzhuangtai = list[8]; //list[8] 单据状态

            Sqlstr = "select daojuleixing, daojuguige, changdu, daojuid, shuliang, jichuangbianma, daotaohao, beizhu  from " + mingxibiao + " where chucangdanhao = '" +danhao.Text.ToString().Trim() +  "'";
            lymx_ds = SQL.getDataSet(Sqlstr, mingxibiao);
            lymx_db = lymx_ds.Tables[0];
            lingyongmingxi.DataSource = lymx_db.DefaultView;

            HJ = lingyongmingxi.Rows.Count - 1;//同步全局变量
            heji.Text = HJ.ToString();

            //若是已完成的单据，则只允许查看，不许修改。
            if (danjuzhuangtai == "1")
            {
                Alex.DisableAllControl(this);
                print.Enabled = true;
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
            xzccmx xzccmx = new xzccmx();
            xzccmx.Owner = this;
            xzccmx.ShowDialog();
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
                if (Alex.CunZai(danhao.Text.ToString(), DHZD, danjubiao) != 0)//判断此单号在单据表中是否已存在
                {
                    //使用update语句
                    //Sqlstr = "UPDATE daojuchucang SET (chucangdanhao, chucangleixing, danjuzhuangtai, lingyongbanzu, lingyongren, jiagonggongyi, chucangriqi, beizhu, caozuoyuan) values('" + danhao.Text.ToString().Trim() + "', '" + "常规领用" + "', '" + "0" + "', '" + LYBZ.Text.ToString().Trim() + "', '" + LYR.Text.ToString().Trim() + "', '" + ZJGX.Text.ToString().Trim() + "', '" + LYRQ.Text + "', '" + beizhu.Text.ToString().Trim() + "', '" + JBR.Text.ToString().Trim() + "')";
                    Sqlstr = string.Format("UPDATE {0} SET lingyongbanzu = '{1}', lingyongren = '{2}', lingyongshebei = '{3}', jiagonggongyi = '{4}', chucangriqi = '{5}', beizhu = '{6}', caozuoyuan = '{7}' where chucangdanhao = '{8}'", danjubiao, LYBZ.Text.ToString().Trim(), LYR.Text.ToString().Trim(), LYSB.Text.ToString().Trim(), ZJGX.Text.ToString().Trim(), LYRQ.Text, beizhu.Text.ToString().Trim(), JBR.Text.ToString().Trim(), danhao.Text.ToString().Trim());
                }
                else
                {
                    //直接使用insert语句
                    Sqlstr = "insert into " + danjubiao + "(chucangdanhao, chucangleixing, danjuzhuangtai, lingyongbanzu, lingyongren, lingyongshebei, jiagonggongyi, chucangriqi, beizhu, caozuoyuan) values('" + danhao.Text.ToString().Trim() + "', '" + "常规领用" + "', '" + "0" + "', '" + LYBZ.Text.ToString().Trim() + "', '" + LYR.Text.ToString().Trim() + "', '" + LYSB.Text.ToString().Trim() + "', '" + ZJGX.Text.ToString().Trim() + "', '" + LYRQ.Text + "', '" + beizhu.Text.ToString().Trim() + "', '" + JBR.Text.ToString().Trim() + "')";
                }

                //执行sql语句,row1为受影响的行数
                int row1 = SQL.ExecuteNonQuery(Sqlstr);

                //将领用明细数据存入数据库daojuchucangmingxi表
                int row2 = 0;
                if (row1 != 0)
                {
                    if (Alex.CunZai(danhao.Text.ToString(), DHZD, mingxibiao) != 0)//判断此单号在明细表中是否已存在
                    {
                        //使用delete语句删除已存在的明细
                        Sqlstr = string.Format("DELETE FROM {0} WHERE chucangdanhao = '{1}'", mingxibiao, danhao.Text.ToString().Trim());
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

                        Sqlstr = "insert into " + mingxibiao + "(chucangdanhao, daojuleixing, daojuguige, changdu, daojuid, shuliang, jichuangbianma, daotaohao, beizhu) values('" + danhao.Text.ToString().Trim() + "', '" + djlx + "', '" + djgg + "', '" + djcd + "','" + djid + "', '" + sl + "', '" + jcbm + "', '" + dth + "', '" + bz + "')";
                        row2 = SQL.ExecuteNonQuery(Sqlstr);//执行sql语句,row2为受影响的行数
                    }

                    //出仓明细数据存入数据库
                    if (row2 != 0)
                    {
                        MessageBox.Show("单据保存成功，可再次修改确认！", "提示", MessageBoxButtons.OK);
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
                    if (Alex.CunZai(danhao.Text.ToString(), DHZD, danjubiao) != 0)//判断此单号在单据表中是否已存在
                    {
                        //使用update语句
                        //Sqlstr = "UPDATE daojuchucang SET (chucangdanhao, chucangleixing, danjuzhuangtai, lingyongbanzu, lingyongren, jiagonggongyi, chucangriqi, beizhu, caozuoyuan) values('" + danhao.Text.ToString().Trim() + "', '" + "常规领用" + "', '" + "0" + "', '" + LYBZ.Text.ToString().Trim() + "', '" + LYR.Text.ToString().Trim() + "', '" + ZJGX.Text.ToString().Trim() + "', '" + LYRQ.Text + "', '" + beizhu.Text.ToString().Trim() + "', '" + JBR.Text.ToString().Trim() + "')";
                        Sqlstr = string.Format("UPDATE {0} SET lingyongbanzu = '{1}', lingyongren = '{2}', lingyongshebei = '{3}', jiagonggongyi = '{4}', chucangriqi = '{5}', beizhu = '{6}', caozuoyuan = '{7}', danjuzhuangtai = '{8}' where chucangdanhao = '{9}'", danjubiao, LYBZ.Text.ToString().Trim(), LYR.Text.ToString().Trim(), LYSB.Text.ToString().Trim(), ZJGX.Text.ToString().Trim(), LYRQ.Text, beizhu.Text.ToString().Trim(), JBR.Text.ToString().Trim(), "1",  danhao.Text.ToString().Trim());
                    }
                    else
                    {
                        //直接使用insert语句
                        Sqlstr = "insert into " + danjubiao + "(chucangdanhao, chucangleixing, danjuzhuangtai, lingyongbanzu, lingyongren, lingyongshebei, jiagonggongyi, chucangriqi, beizhu, caozuoyuan) values('" + danhao.Text.ToString().Trim() + "', '" + "常规领用" + "', '" + "1" + "', '" + LYBZ.Text.ToString().Trim() + "', '" + LYR.Text.ToString().Trim() + "', '" + LYSB.Text.ToString().Trim() + "', '" + ZJGX.Text.ToString().Trim() + "', '" + LYRQ.Text + "', '" + beizhu.Text.ToString().Trim() + "', '" + JBR.Text.ToString().Trim() + "')";
                    }

                    int row1 = SQL.ExecuteNonQuery(Sqlstr);

                    //将出仓明细数据存入数据库daojuchucangmingxi表和刀具流水总表
                    int row2 = 0;//记录插入明细表数据
                    int row3 = 0;//记录插入流水表数据
                    if (row1 != 0)
                    {
                        if (Alex.CunZai(danhao.Text.ToString(), DHZD, mingxibiao) != 0)//判断此单号在明细表中是否已存在
                        {
                            //使用delete语句删除已存在的明细
                            Sqlstr = string.Format("DELETE FROM {0} WHERE chucangdanhao = '{1}'", mingxibiao, danhao.Text.ToString().Trim());
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
                            
                            //明细数据存入数据库明细表
                            Sqlstr = "insert into " + mingxibiao + "(chucangdanhao, daojuleixing, daojuguige, changdu, daojuid, shuliang, jichuangbianma, daotaohao, beizhu) values('" + danhao.Text.ToString().Trim() + "', '" + djlx + "', '" + djgg + "', '" + djcd + "','" + djid + "', '" + sl + "', '" + jcbm + "', '" + dth + "', '" + bz + "')";
                            row2 = SQL.ExecuteNonQuery(Sqlstr);

                            //明细信息存入流水表
                            Sqlstr = string.Format("INSERT INTO {0}(danhao, dhlx, djlx, djgg, djid, zsl, fsl, wzbm, jtwz ,czsj, jbr, bz) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}' ,'{8}', '{9}', '{10}', '{11}', '{12}')", liushuibiao, danhao.Text.ToString().Trim(), "常规领用", djlx, djgg, djid, "0", sl, jcbm, dth, LYRQ.Value.ToString().Trim(), JBR.Text.ToString().Trim() ,bz);
                            row3 = SQL.ExecuteNonQuery(Sqlstr);
                        }

                        
                        //int row2 = SQL.ExecuteNonQuery(Sqlstr);
                        if (row2 != 0)
                        {
                            MessageBox.Show("刀具领用完成！", "提示", MessageBoxButtons.OK);
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
            if(Alex.CunZai(danhao.Text.ToString().Trim(), DHZD ,danjubiao) != 0 )
            {
                DialogResult dr = MessageBox.Show("确认删除此单据？", "删除确认", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //删除刀具领用表中的数据
                    Sqlstr = string.Format("DELETE FROM {0} WHERE chucangdanhao = '{1}'", danjubiao, danhao.Text.ToString().Trim());
                    int row1 = SQL.ExecuteNonQuery(Sqlstr);

                    Sqlstr = string.Format("DELETE FROM {0} WHERE chucangdanhao = '{1}'", mingxibiao, danhao.Text.ToString().Trim());
                    int row2 = SQL.ExecuteNonQuery(Sqlstr);
                    MessageBox.Show("成功删除一张单据和" + row2 + "条明细记录！");

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
            if (this.Parent != null)
            {
                MainForm mfr = (MainForm)this.Parent.FindForm();
                mfr.CloseTab(this.Name);
            }
        }

        #endregion 其他方法结束

        /// <summary>
        /// 从表增加明细，即可以通过选择多条记录一并新增明细
        /// </summary>
        /// <param name="tb">要新增的明细表部分内容</param>
        public void AddDataFromTable(DataTable tb)
        {
            lymx_db.Columns.Add("daojuleixing", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("daojuguige", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("changdu", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("daojuid", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("shuliang", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("jichuangbianma", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("daotaohao", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("beizhu", System.Type.GetType("System.String"));

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
    }
}
