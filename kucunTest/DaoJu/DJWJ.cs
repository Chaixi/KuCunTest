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
    public partial class DJWJ : Form
    {
        public DJWJ()
        {
            InitializeComponent();
            //this.OnLoad(null);
        }

        #region 全局变量
        MySql SQL = new MySql();
        string SqlStr = "";
        BaseAlex Alex = new BaseAlex();
        int HJ = 0;
        #endregion

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJWJ_Load(object sender, EventArgs e)
        {
            jydw.SelectedIndex = 0;
            dwld.SelectedIndex = 0;
            jbr.SelectedIndex = 0;

            heji.Text = HJ.ToString();

            jy_ghsj.Text = DateTime.Now.AddDays(3).ToString();//默认三天后为归还时间
            jcsj.Text = DateTime.Now.ToString();//借出时间为当前日期

            spld.SelectedIndex = 0;
            spyj.Text = "同意外借。";

            dh.Text = Alex.DanHao("DJWJ");//自动生成单号
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
        /// 取消刀具外借按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认取消刀具外借？", "取消确认", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

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
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, WaiJieMingXi.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), WaiJieMingXi.RowHeadersDefaultCellStyle.Font, rectangle, WaiJieMingXi.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
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

        /// <summary>
        /// 确认外借按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否确认对刀具进行领用？", "领用确认", MessageBoxButtons.YesNo);
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
                    SqlStr = "insert into daojuwaijie(danhao, jydw, dwld, jyr, lxdh, jyyy, spld, spyj, jbr, jcsj, ydghsj) values('" + dh.Text.ToString().Trim() + "', '" + jydw.Text.ToString().Trim() + "', '" + dwld.Text.ToString().Trim() + "', '" + jyr.Text.ToString().Trim() + "', '" + lxdh.Text.ToString().Trim() + "', '" + jyyy.Text + "', '" + spld.Text.ToString().Trim() + "', '" + spyj.Text.ToString().Trim() + "', '" + jbr.Text.ToString().Trim() + "', '" + jcsj.Text.ToString() + "', '" + jy_ghsj.Text.ToString() + "')";
                    
                    int row1 = SQL.ExecuteNonQuery(SqlStr);

                    //将借用明细数据存入数据库daojuwaijiemingxi表
                    int row2 = 0;
                    if (row1 != 0)
                    {
                        //借用明细数据格式化
                        for (int rowindex = 0; rowindex < WaiJieMingXi.Rows.Count - 1; rowindex++)
                        {
                            string djlx = WaiJieMingXi.Rows[rowindex].Cells["djlx"].Value.ToString();//刀具类型
                            string djgg = WaiJieMingXi.Rows[rowindex].Cells["djgg"].Value.ToString();//刀具规格
                            string djid = WaiJieMingXi.Rows[rowindex].Cells["djID"].Value.ToString();//刀具id
                            string djzt = WaiJieMingXi.Rows[rowindex].Cells["djzt"].Value.ToString();//刀具状态
                            string sl = WaiJieMingXi.Rows[rowindex].Cells["sl"].Value.ToString();//数量
                            string jcbm = WaiJieMingXi.Rows[rowindex].Cells["jcbm"].Value.ToString();//机床编码
                            string dth = WaiJieMingXi.Rows[rowindex].Cells["dth"].Value.ToString();//刀套号
                            string bz = WaiJieMingXi.Rows[rowindex].Cells["bz"].Value.ToString();//备注

                            SqlStr = "insert into daojuwaijiemingxi(danhao, djlx, djgg, djid, djzt, sl, jcbm, dth, bz) values('" + dh.Text.ToString().Trim() + "', '" + djlx + "', '" + djgg + "', '" + djid + "','" + djzt + "', '" + sl + "', '" + jcbm + "', '" + dth + "', '" + bz + "')";
                            row2 = SQL.ExecuteNonQuery(SqlStr);
                        }

                        //借用明细数据存入数据库
                        //int row2 = SQL.ExecuteNonQuery(Sqlstr);
                        if (row2 != 0)
                        {
                            MessageBox.Show("刀具借用完成！", "提示", MessageBoxButtons.OK);
                            this.InitializeComponent();
                            this.OnLoad(null);
                            //this.Close();
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
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        private int CheckData()
        {
            string tishi = "";
            if (jydw.Text == "" || jyr.Text == "" || jyyy.Text == "" || spld.Text == "" || spyj.Text == "" || jbr.Text == "")
            {
                if (jydw.Text.ToString() == "")
                {
                    tishi = "请填写借用单位！";
                }
                else if (jyr.Text.ToString() == "")
                {
                    tishi = "请填写借用人！";
                }
                else if (jyyy.Text.ToString() == "")
                {
                    tishi = "请填写借用原因！";
                }
                else if (spld.Text.ToString() == "")
                {
                    tishi = "请填写审批领导！";
                }
                else if (spyj.Text.ToString() == "")
                {
                    tishi = "请填写审批意见！";
                }
                else if (jbr.Text.ToString() == "")
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
        /// 外界历史按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确认打开借用历史记录并关闭此窗口？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                History wjlishi = new History("DJWJ");
                wjlishi.Show();
                this.Close();
            }
        }
    }
}
