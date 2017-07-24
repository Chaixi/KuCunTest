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

namespace kucunTest.LingBuJian
{
    public partial class LBJLY : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";
        int HJ = 0;

        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();//窗口自适应类
        
        //DataSet lymx_ds = new DataSet();
        DataTable lymx_db = new DataTable();

        string danjubiao = "lbj_lingyong";
        string mingxibiao = "lbj_lingyongmingxi";
        string liushuibiao = "lbj_liushui";
        string DHZD = "danhao";
        #endregion

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public LBJLY()
        {
            InitializeComponent();

            danhao.Text = Alex.DanHao("LBJLY");//自动生成单号
            LYRQ.Value = DateTime.Now;
            LYBZ.SelectedIndex = 0;
            JBR.SelectedIndex = 0;
            heji.Text = HJ.ToString();

            lingyongmingxi.AutoGenerateColumns = false;//禁止自动生成行
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LBJLY_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);//记录窗体及控件初始大小，以便自适应

        }

        #region 明细部分
        ///<summary>
        ///datagridview每一行自动生成序号
        /// </summary>
        private void lingyongmingxi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(lingyongmingxi, e);
        }

        /// <summary>
        /// 出仓明细新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMXNew_Click(object sender, EventArgs e)
        {
            lbj_xzlymx xz = new lbj_xzlymx();
            xz.Owner = this;

            xz.Left = (this.Parent.Width - this.Width) / 2 - this.Width;


            xz.ShowDialog();
        }

        /// <summary>
        /// 出仓明细的删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMXDelete_Click(object sender, EventArgs e)
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
                if (result == DialogResult.Yes)
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
                    for (int i = k; i >= 1; i--)//从下往上删，避免沙漏效应
                    {
                        lingyongmingxi.Rows.RemoveAt(lingyongmingxi.SelectedRows[i - 1].Index);
                        HJ--;  //合计数量减一
                    }
                }
            }

            heji.Text = HJ.ToString();//更新合计数量
        }

        /// <summary>
        /// AddData函数，向datagridview中增加一行数据
        /// </summary>
        /// <param name="list">子窗体传输过来的list值</param>
        public void AddData(List<string> list)
        {
            if (lingyongmingxi.DataSource == null)//新单据，未绑定数据源
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(lingyongmingxi);

                row.Cells[0].Value = list[0];//零部件名称
                row.Cells[1].Value = list[1];//零部件规格
                row.Cells[2].Value = list[2];//零部件型号
                row.Cells[3].Value = list[3];//数量
                row.Cells[4].Value = list[4];//单位
                row.Cells[5].Value = list[5];//机床编码
                row.Cells[6].Value = list[6];//工序
                row.Cells[7].Value = list[7];//备注

                lingyongmingxi.Rows.Add(row);
            }
            else//暂存的单据，领用明细datagridview已经绑定数据源
            {
                //lingyongmingxi.DataSource = null;
                //lingyongmingxi.Rows.Add(row);

                DataRow rowrow = lymx_db.NewRow();

                rowrow["lbjmc"] = list[0];//零部件名称
                rowrow["lbjgg"] = list[1];//零部件规格
                rowrow["lbjxh"] = list[2];//零部件型号
                rowrow["sl"] = list[3];//数量
                rowrow["dw"] = list[4];//单位
                rowrow["jcbm"] = list[5];//机床编码
                rowrow["gx"] = list[6];//工序
                rowrow["bz"] = list[7];//备注

                lymx_db.Rows.Add(rowrow);
            }

            HJ++;//合计数量加一
            heji.Text = HJ.ToString();//更新合计数量
        }

        #endregion 明细部分结束

        #region 按钮部分
        /// <summary>
        /// 保存单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (LYBZ.Text == "" && LYR.Text == "" && LYSB.Text == "" && JBR.Text == "" && ZJGX.Text == "" && lingyongmingxi.Rows.Count == 1)//未填写任何内容，提示取消填写单据
            {
                if (MessageBox.Show("当前单据为空，要直接取消填写单据？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                //将领用和操作数据存入数据库lbj_lingyong表
                //数据预处理
                string dh = danhao.Text.ToString().Trim();
                string djzt = "0";//单据状态
                string lybz = LYBZ.Text.ToString().Trim();//领用班组
                string lysb = LYSB.Text.ToString().Trim();//领用设备
                string lyr = LYR.Text.ToString().Trim();//领用人
                string zjgx = ZJGX.Text.ToString().Trim();//制件工序
                string lyrq = LYRQ.Value.ToString();//领用日期
                string bz = beizhu.Text.ToString().Trim();//备注
                string jbr = JBR.Text.ToString().Trim();//经办人

                if (Alex.CunZai(danhao.Text.ToString(), DHZD, danjubiao) != 0)//判断此单号在单据表中是否已存在
                {
                    //使用update语句
                    Sqlstr = string.Format("UPDATE {0} SET lybz = '{1}', lysb = '{2}', lyr = '{3}', zjgx = '{4}', lyrq = '{5}', beizhu = '{6}', jbr = '{7}', djzt = '{8}' WHERE {9} = '{10}'", danjubiao, lybz, lysb, lyr, zjgx, lyrq, bz, jbr, djzt, DHZD, dh);
                }
                else
                {
                    //直接使用insert语句
                    Sqlstr = string.Format("INSERT INTO {0}(danhao, lybz, lysb, lyr, zjgx, lyrq, beizhu, jbr, djzt) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", danjubiao, dh, lybz, lysb, lyr, zjgx, lyrq, bz, jbr, djzt);
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
                        Sqlstr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", mingxibiao, DHZD, dh);
                        row2 = SQL.ExecuteNonQuery(Sqlstr);
                    }
                    //出仓明细数据格式化
                    for (int rowindex = 0; rowindex < lingyongmingxi.Rows.Count - 1; rowindex++)
                    {
                        string lbjmc = lingyongmingxi.Rows[rowindex].Cells["lbjmc"].Value.ToString();
                        string lbjgg = lingyongmingxi.Rows[rowindex].Cells["lbjgg"].Value.ToString();
                        string lbjxh = lingyongmingxi.Rows[rowindex].Cells["lbjxh"].Value.ToString();
                        string sl = lingyongmingxi.Rows[rowindex].Cells["sl"].Value.ToString();
                        string dw = lingyongmingxi.Rows[rowindex].Cells["dw"].Value.ToString();
                        string jcbm = lingyongmingxi.Rows[rowindex].Cells["jcbm"].Value.ToString();
                        string gx = lingyongmingxi.Rows[rowindex].Cells["gx"].Value.ToString();
                        string beizhu = lingyongmingxi.Rows[rowindex].Cells["bz"].Value.ToString();

                        Sqlstr = string.Format("INSERT INTO {0}(danhao, lbjmc, lbjgg, lbjxh, sl, dw, jcbm, gx, bz) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", mingxibiao, dh, lbjmc, lbjgg, lbjxh, sl, dw, jcbm, gx, beizhu);
                        row2 = SQL.ExecuteNonQuery(Sqlstr);//执行sql语句,row2为受影响的行数
                    }

                    //出仓明细数据存入数据库
                    if (row2 != 0)
                    {
                        MessageBox.Show("单据保存成功，可再次修改确认！", "提示", MessageBoxButtons.OK);
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
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否确认领用？确认后单据不可修改！", "领用确认", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //数据验证
                if (CheckData() == 0)
                {
                    return;//数据输入有误
                }
                else
                {
                    //将领用和操作数据存入数据库lbj_lingyong表
                    //数据预处理
                    string dh = danhao.Text.ToString().Trim();
                    string djzt = "1";//单据状态
                    string lybz = LYBZ.Text.ToString().Trim();//领用班组
                    string lysb = LYSB.Text.ToString().Trim();//领用设备
                    string lyr = LYR.Text.ToString().Trim();//领用人
                    string zjgx = ZJGX.Text.ToString().Trim();//制件工序
                    string lyrq = LYRQ.Value.ToString();//领用日期
                    string bz = beizhu.Text.ToString().Trim();//备注
                    string jbr = JBR.Text.ToString().Trim();//经办人

                    if (Alex.CunZai(danhao.Text.ToString(), DHZD, danjubiao) != 0)//判断此单号在单据表中是否已存在
                    {
                        //使用update语句
                        Sqlstr = string.Format("UPDATE {0} SET lybz = '{1}', lysb = '{2}', lyr = '{3}', zjgx = '{4}', lyrq = '{5}', beizhu = '{6}', jbr = '{7}', djzt = '{8}' WHERE {9} = '{10}'", danjubiao, lybz, lysb, lyr, zjgx, lyrq, bz, jbr, djzt, DHZD, dh);
                    }
                    else
                    {
                        //直接使用insert语句
                        Sqlstr = string.Format("INSERT INTO {0}(danhao, lybz, lysb, lyr, zjgx, lyrq, beizhu, jbr, djzt) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", danjubiao, dh, lybz, lysb, lyr, zjgx, lyrq, bz, jbr, djzt);
                    }

                    int row1 = SQL.ExecuteNonQuery(Sqlstr);

                    //将领用明细数据存入数据库lbj_lingyongmingxi表
                    int row2 = 0;//记录插入明细表数据
                    int row3 = 0;//记录插入流水表数据
                    if (row1 != 0)
                    {
                        if (Alex.CunZai(danhao.Text.ToString(), DHZD, mingxibiao) != 0)//判断此单号在明细表中是否已存在
                        {
                            //使用delete语句删除已存在的明细
                            Sqlstr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", mingxibiao, DHZD, dh);
                            row2 = SQL.ExecuteNonQuery(Sqlstr);
                        }
                        //明细数据格式化
                        for (int rowindex = 0; rowindex < lingyongmingxi.Rows.Count - 1; rowindex++)
                        {
                            string lbjmc = lingyongmingxi.Rows[rowindex].Cells["lbjmc"].Value.ToString();
                            string lbjgg = lingyongmingxi.Rows[rowindex].Cells["lbjgg"].Value.ToString();
                            string lbjxh = lingyongmingxi.Rows[rowindex].Cells["lbjxh"].Value.ToString();
                            string sl = lingyongmingxi.Rows[rowindex].Cells["sl"].Value.ToString();
                            string dw = lingyongmingxi.Rows[rowindex].Cells["dw"].Value.ToString();
                            string jcbm = lingyongmingxi.Rows[rowindex].Cells["jcbm"].Value.ToString();
                            string gx = lingyongmingxi.Rows[rowindex].Cells["gx"].Value.ToString();
                            string beizhu = lingyongmingxi.Rows[rowindex].Cells["bz"].Value.ToString();

                            //明细数据存入数据库明细表
                            Sqlstr = string.Format("INSERT INTO {0}(danhao, lbjmc, lbjgg, lbjxh, sl, dw, jcbm, gx, bz) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", mingxibiao, dh, lbjmc, lbjgg, lbjxh, sl, dw, jcbm, gx, beizhu);
                            row2 = SQL.ExecuteNonQuery(Sqlstr);//执行sql语句,row2为受影响的行数

                            //明细信息存入流水表
                            Sqlstr = string.Format("INSERT INTO {0}(danhao, dhlx, lbjmc, lbjgg, lbjxh, zsl, fsl, czsj, jbr, bz) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}' ,'{8}', '{9}', '{10}')", liushuibiao, dh, "常规领用", lbjmc, lbjgg, lbjxh, "0", sl, lyrq, jbr, beizhu);
                            row3 = SQL.ExecuteNonQuery(Sqlstr);
                        }

                        if (row2 != 0)
                        {
                            MessageBox.Show("单据确认成功！", "提示", MessageBoxButtons.OK);
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
        }

        /// <summary>
        /// 打印单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 删除单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        #endregion 按钮部分结束

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
        /// 窗体大小自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LBJLY_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
