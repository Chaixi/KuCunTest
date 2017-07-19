using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using kucunTest.src;

namespace kucunTest.RuCang
{
    public partial class NewRC : Form
    {
        private BianMa BianHao = new BianMa();

        public NewRC()
        {
            InitializeComponent();
        }

        #region 全局变量
        private MySql SelectSql = new MySql(); //mysql类
        private string Sql = "";//SQL语句
        #endregion

        #region 窗体加载
        /// <summary>
        /// 包括默认选项初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RuCang_Load(object sender, EventArgs e)
        {
            RCDH.Text = BianHao.newBianHao("RC");
            RCDH.SelectionLength = 0;
            RCLX.SelectedIndex = 0;
            CJ.SelectedIndex = 0;
            BM.SelectedIndex = 0;
            CZY.SelectedIndex = 0;
            RCRQ.Value = DateTime.Now;
        }
        #endregion

        #region 入仓明细datagridview事件设置
        ///<summary>
        ///每一行规格的默认值
        ///</summary>
        private void ruCangMingXi_DefaultValuesNeeded_1(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["gg"].Value = "件";
            e.Row.Cells["bz"].Value = "";
        }

        ///<summary>
        ///datagridview每一行自动生成序号
        /// </summary>
        private void ruCangMingXi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //SolidBrush b = new SolidBrush(this.ruCangMingXi.RowHeadersDefaultCellStyle.ForeColor);
            //e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.ruCangMingXi.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, ruCangMingXi.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), ruCangMingXi.RowHeadersDefaultCellStyle.Font, rectangle, ruCangMingXi.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        #endregion

        #region 入仓完成按钮
        private void button1_Click(object sender, EventArgs e)
        {
            //添加入仓明细是否为空的判断


            DialogResult dr = MessageBox.Show("确认入仓并关闭？", "入仓确认", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                //分两部分进行数据库保存，一部分insert到入仓表中，另一部分直接insert到入仓明细表中        
                //数据预处理
                string rcdh = RCDH.Text.Trim();
                string rclx = RCLX.Text.Trim();
                string rcrq = RCRQ.Value.Date.ToShortDateString();
                string cj = CJ.Text.Trim();
                string bm = BM.Text.Trim();
                string czy = CZY.Text.Trim();
                string bz = comments.Text.Trim();

                //入仓单信息insert到入仓表中
                //string sql = "insert into rucang(rcdh,rclx,rcrq,cj,bm,czy,bz) values('" + RCDH.Text.Trim() + "', '" + RCLX.Text.Trim() + "', '" + RCRQ;
                Sql = string.Format("insert into rucang(rcdh,rclx,rcrq,cj,bm,czy,bz) values('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", rcdh, rclx, rcrq, cj, bm, czy, bz);
                MySql insert = new MySql();
                int r = 0;
                r = insert.getsqlcom1(Sql);
                if (r == 1)
                {
                    MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK);
                    r = 0;
                    //this.Close();
                }

                //入仓明细insert到入仓明细表中
                string sql2;
                for (int i = 0; i < this.ruCangMingXi.Rows.Count; i++)
                {
                    if (ruCangMingXi.Rows[i].Cells["xinghao"].Value == null)
                    {
                        break;
                    }
                    string mx_xinghao = ruCangMingXi.Rows[i].Cells["xinghao"].Value.ToString().Trim();
                    string mx_mc = ruCangMingXi.Rows[i].Cells["mc"].Value.ToString().Trim();
                    string mx_gg = ruCangMingXi.Rows[i].Cells["gg"].Value.ToString().Trim();
                    string mx_sl = ruCangMingXi.Rows[i].Cells["sl"].Value.ToString().Trim();
                    string mx_djgbm = ruCangMingXi.Rows[i].Cells["djgbm"].Value.ToString().Trim();
                    string mx_cfwz = ruCangMingXi.Rows[i].Cells["cfwz"].Value.ToString().Trim();
                    string mx_bz = ruCangMingXi.Rows[i].Cells["bz"].Value.ToString().Trim();

                    sql2 = string.Format("insert into rucangmingxi(xinghao, mc, gg, sl, djgbm, cfwz, bz, rcdh) values('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", mx_xinghao, mx_mc, mx_gg, mx_sl, mx_djgbm, mx_cfwz, mx_bz, rcdh);
                    r = insert.getsqlcom1(sql2);
                }
                if (r == 1)
                {
                    MessageBox.Show("入仓完成！", "消息", MessageBoxButtons.OK);
                    this.Close();
                }
            }
        }
        #endregion

        #region 保存按钮
        private void save_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 导出按钮
        private void daochu_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 打印按钮
        private void print_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 取消按钮
        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定不进行保存就取消入仓单吗？", "取消确认", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region datagridview名称列、型号列以及刀具柜和库存位置列多级联动设置
        private void ruCangMingXi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ruCangMingXi.CurrentCell.RowIndex == 0 & ruCangMingXi.CurrentCell.ColumnIndex == mc.Index)
            {
                Sql = "select distinct mc from lingbujian";
                mc.DataSource = SelectSql.getDataSet(Sql, "lingbujian").Tables[0];
                mc.DisplayMember = "mc";
                mc.ValueMember = "mc";
                mc.DataPropertyName = "mc";
            }
        }

        ///<summary>二级联动，每次更改名称列，则相应更改此行的型号列下拉内容</summary>
        ///很重要！！！
        private void ruCangMingXi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (ruCangMingXi.CurrentCell == null)
            {
                return;
            }
            if (ruCangMingXi.CurrentCell.ColumnIndex == mc.Index)//名称列改变，则后面的型号列相应改变
            {
                Sql = "select xinghao from lingbujian where mc='" + ruCangMingXi.CurrentCell.Value.ToString().Trim() + "'";
                //只更改这一行！！！的型号选项
                DataGridViewComboBoxCell cell = ruCangMingXi.Rows[e.RowIndex].Cells["xinghao"] as DataGridViewComboBoxCell;
                cell.DataSource = SelectSql.getDataSet(Sql, "lingbujian").Tables[0];
                cell.DisplayMember = "xinghao";
                cell.ValueMember = "xinghao";
            }
            else if (ruCangMingXi.CurrentCell.ColumnIndex == xinghao.Index & ruCangMingXi.Rows[e.RowIndex].Cells["xinghao"].Value != null)//型号列改变，则对应的刀具柜编码改变
            {
                Sql = "select distinct djgbm from rucangmingxi where xinghao='" + ruCangMingXi.Rows[e.RowIndex].Cells["xinghao"].Value.ToString().Trim() + "'";
                //MySqlDataReader dr = SelectSql.getcom(Sql);
                if (SelectSql.getDataSet(Sql, "rucangmingxi").Tables[0] == null)
                {
                    //全新刀具应该可以输入刀具柜编码和存放位置！暂未设置
                    return;
                }
                else
                {
                    DataGridViewComboBoxCell cell = ruCangMingXi.Rows[e.RowIndex].Cells["djgbm"] as DataGridViewComboBoxCell;
                    cell.DataSource = SelectSql.getDataSet(Sql, "lingbujian").Tables[0];
                    cell.DisplayMember = "djgbm";
                    cell.ValueMember = "djgbm";
                }
            }else if(ruCangMingXi.CurrentCell.ColumnIndex == djgbm.Index)//型号改变导致对应的刀具柜编码改变，则相应的存放位置岁刀具柜编码改变
            {
                Sql = string.Format("select distinct cfwz from rucangmingxi where xinghao='{0}' and djgbm='{1}'", ruCangMingXi.Rows[e.RowIndex].Cells["xinghao"].Value.ToString().Trim(), ruCangMingXi.Rows[e.RowIndex].Cells["djgbm"].Value.ToString().Trim());
                if(SelectSql.getDataSet(Sql, "ruCangMingXi").Tables[0] == null)
                {
                    //全新刀具应该可以输入刀具柜编码和存放位置！暂未设置
                    return;
                }
                else
                {
                    DataGridViewComboBoxCell cell = ruCangMingXi.Rows[e.RowIndex].Cells["cfwz"] as DataGridViewComboBoxCell;
                    cell.DataSource = SelectSql.getDataSet(Sql, "rucangmingxi").Tables[0];
                    cell.DisplayMember = "cfwz";
                    cell.ValueMember = "cfwz";
                }
            }
        }
        #endregion

        #region 根据入仓类型调整采购需求/刃磨单号下拉框的属性和内容
        private void RCLX_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (RCLX.SelectedItem.ToString().Trim() == "采购入仓")
            {
                label9.Text = "需求单号：";
                label9.Visible = true;
                XQDH.Visible = true;

                XQDH.Enabled = true;//改变下拉框状态

                //增加采购需求单号数据源
                XQDH.DataSource = SelectSql.getDataSet("select rcdh from rucang", "rucang").Tables[0];//暂未设置为需求单号，而采用入仓单号测试！
                XQDH.DisplayMember = "rcdh";
                XQDH.ValueMember = "rcdh";

                XQDH.Text = "";//默认值为空，以供选择
            }
            else if (RCLX.SelectedItem.ToString().Trim() == "已刃磨入仓")
            {
                label9.Text = "刃磨单号：";
                label9.Visible = true;
                XQDH.Visible = true;

                XQDH.Enabled = true;//改变下拉框状态

                //增加刃磨单号数据源
                XQDH.DataSource = SelectSql.getDataSet("select rcdh from rucang", "rucang").Tables[0];//暂未设置为需求单号，而采用入仓单号测试！
                XQDH.DisplayMember = "rcdh";
                XQDH.ValueMember = "rcdh";

                XQDH.Text = "";//默认值为空，以供选择
            }
            else
            {
                label9.Text = "刃磨单号：";
                label9.Visible = true;
                XQDH.Visible = true;

                XQDH.Enabled = false;//改变下拉框状态
            }
        }
       #endregion
    }
}
