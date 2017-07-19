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

namespace kucunTest.DaoJu
{
    public partial class DJTH : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string SqlStr = "";
        BaseAlex Alex = new BaseAlex();
        int HJ = 0;//合计刀具数量
        #endregion

        public DJTH()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJTH_Load(object sender, EventArgs e)
        {
            DH.Text = Alex.DanHao("DJTH");//自动生成单号

            THBZ.SelectedIndex = 0;
            JBR.SelectedIndex = 0;
            THYY.Text = "机床常规退还。";//默认退还原因为"机床常规退还。"
            heji.Text = HJ.ToString();
            THRQ.Value = DateTime.Now;//退还日期为当前日期
        }

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
        /// 退还明细删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            int k = MingXi.SelectedRows.Count;
            if (k == 0)
            {
                MessageBox.Show("请先选择至少一行数据！", "提示", MessageBoxButtons.OK);
            }
            else if (MingXi.CurrentRow.Index == MingXi.Rows.Count - 1 || k == MingXi.Rows.Count)//选中的是最后一行
            {
                MessageBox.Show("不能删除空白行！", "警告", MessageBoxButtons.OK);
            }
            else if (k == 1)
            {
                DialogResult result = MessageBox.Show("确定删除" + k + "行数据？", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MingXi.Rows.RemoveAt(MingXi.CurrentRow.Index);
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
                        MingXi.Rows.RemoveAt(MingXi.SelectedRows[i - 1].Index);
                        HJ--;  //合计数量减一
                    }
                }
            }

            heji.Text = HJ.ToString();//更新合计数量
        }

        /// <summary>
        /// 保存单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否确认保存单据？", "领用确认", MessageBoxButtons.YesNo);
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
                    SqlStr = "insert into daojutuihuan(danhao, thbz, thr, thrq, thyy, jbr, jbrq) values('" + DH.Text.ToString().Trim() + "', '" + THBZ.Text.ToString().Trim() + "', '" + THR.Text.ToString().Trim() + "', '" + THRQ.Text.ToString().Trim() + "', '" + THYY.Text.ToString().Trim() + "', '" + JBR.Text + "', '" + JBRQ.Text.ToString().Trim() + "')";

                    int row1 = SQL.ExecuteNonQuery(SqlStr);

                    //将借用明细数据存入数据库daojuwaijiemingxi表
                    int row2 = 0;
                    if (row1 != 0)
                    {
                        //明细数据格式化
                        for (int rowindex = 0; rowindex < MingXi.Rows.Count - 1; rowindex++)
                        {
                            string djlx = MingXi.Rows[rowindex].Cells["mx_djlx"].Value.ToString();//刀具类型
                            string djgg = MingXi.Rows[rowindex].Cells["mx_djgg"].Value.ToString();//刀具规格
                            string djcd = MingXi.Rows[rowindex].Cells["mx_djcd"].Value.ToString();//刀具长度
                            string djid = MingXi.Rows[rowindex].Cells["mx_djid"].Value.ToString();//刀具id
                            string djzt = MingXi.Rows[rowindex].Cells["mx_djzt"].Value.ToString();//刀具状态
                            string sl = MingXi.Rows[rowindex].Cells["mx_sl"].Value.ToString();//数量
                            string jcbm = MingXi.Rows[rowindex].Cells["mx_jcbm"].Value.ToString();//机床编码
                            string dth = MingXi.Rows[rowindex].Cells["mx_dth"].Value.ToString();//刀套号
                            string djgbm = MingXi.Rows[rowindex].Cells["mx_djgbm"].Value.ToString();//刀具柜编码
                            string cfwz = MingXi.Rows[rowindex].Cells["mx_cfwz"].Value.ToString();//存放位置
                            string bz = MingXi.Rows[rowindex].Cells["mx_bz"].Value.ToString();//备注

                            SqlStr = "insert into daojutuihuanmingxi(danhao, djlx, djgg, djcd, djid, djzt, sl, jcbm, dth, djgbm, cfwz, bz) values('" + DH.Text.ToString().Trim() + "', '" + djlx + "', '" + djgg + "', '" + djcd + "','" + djid + "','" + djzt + "', '" + sl + "', '" + jcbm + "', '" + dth + "', '" + djgbm + "', '" + cfwz + "', '" + bz + "')";
                            row2 = SQL.ExecuteNonQuery(SqlStr);
                        }

                        //明细数据存入数据库
                        //int row2 = SQL.ExecuteNonQuery(Sqlstr);
                        if (row2 != 0)
                        {
                            MessageBox.Show("单据保存成功！", "提示", MessageBoxButtons.OK);
                            this.InitializeComponent();
                            this.OnLoad(null);
                            //this.Close();
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
        /// 取消单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_cancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确认取消填写刀具退还单？", "取消确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

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
        /// AddData函数，向datagridview中增加一行数据
        /// </summary>
        /// <param name="list">子窗体传输过来的list值</param>
        public void AddData(List<string> list)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(MingXi);

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

            MingXi.Rows.Add(row);

            HJ++;//合计数量加一
            heji.Text = HJ.ToString();//更新合计数量
        }

        /// <summary>
        /// datagridview每一行自动生成序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MingXi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, MingXi.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), MingXi.RowHeadersDefaultCellStyle.Font, rectangle, MingXi.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
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
            else if (MingXi.Rows.Count == 1)
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
    }
}
