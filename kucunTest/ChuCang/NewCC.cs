using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kucunTest.ChuCang
{
    public partial class NewCC : Form
    {
        public NewCC()
        {
            InitializeComponent();
        }

        #region 全局变量
        private MySql SelectSql = new MySql(); //mysql类
        private string Sql = "";//SQL语句
        #endregion 全局变量结束

        #region 窗体加载
        /// <summary>
        /// 包括默认选项初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCC_Load(object sender, EventArgs e)
        {
            CCLX.SelectedIndex = 0;
            CJ.SelectedIndex = 0;
            BM.SelectedIndex = 0;
            CZY.SelectedIndex = 0;
            CCRQ.Value = DateTime.Now;
        }
        #endregion 窗体加载结束

        #region 入仓明细datagridview事件设置
        ///<summary>
        ///每一行规格的默认值
        ///</summary>
        private void ChuCangMingXi_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["gg"].Value = "件";
            e.Row.Cells["bz"].Value = "";
        }
        ///<summary>
        ///datagridview每一行自动生成序号
        /// </summary>
        private void ChuCangMingXi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(this.ChuCangMingXi.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.ChuCangMingXi.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
        #endregion

        #region 入仓完成按钮
        private void button1_Click(object sender, EventArgs e)
        {
            //添加入仓明细是否为空的判断


            DialogResult dr = MessageBox.Show("确认出仓并关闭？", "出仓确认", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                string rmzt = "刃磨中";     
                if (CCLX.Text != "刃磨出仓")
                {
                    RMDH.Text = "NO";
                    rmzt = "NO";
                } 
                //分两部分进行数据库保存，一部分insert到出仓表中，另一部分直接insert到出仓明细表中        
                //数据预处理
                string cclx = CCLX.Text.Trim();
                string ccdh = CCDH.Text.Trim();
                string rmdh = RMDH.Text.Trim();
                string jggy = JGGY.Text.Trim();
                string lybz = LYBZ.Text.Trim();
                string lyr = LYR.Text.Trim();
                string ccrq = CCRQ.Value.Date.ToShortDateString();
                string cj = CJ.Text.Trim();
                string bm = BM.Text.Trim();
                string czy = CZY.Text.Trim();
                string bz = comments.Text.Trim();

                //出仓单信息insert到出仓表中
                //string sql = "insert into rucang(rcdh,rclx,rcrq,cj,bm,czy,bz) values('" + RCDH.Text.Trim() + "', '" + RCLX.Text.Trim() + "', '" + RCRQ;
                Sql = string.Format("insert into chucang(cclx,ccdh,rmdh,rmzt,jggy,lybz,lyr,ccrq,cj,bm,czy,bz) values('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')", cclx, ccdh, rmdh, rmzt, jggy, lybz, lyr, ccrq, cj, bm, czy, bz);
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
                for (int i = 0; i < this.ChuCangMingXi.Rows.Count; i++)
                {
                    if (ChuCangMingXi.Rows[i].Cells["xinghao"].Value == null)
                    {
                        break;
                    }
                    string mx_xinghao = ChuCangMingXi.Rows[i].Cells["xinghao"].Value.ToString().Trim();
                    string mx_mc = ChuCangMingXi.Rows[i].Cells["mc"].Value.ToString().Trim();
                    string mx_gg = ChuCangMingXi.Rows[i].Cells["gg"].Value.ToString().Trim();
                    string mx_sl = ChuCangMingXi.Rows[i].Cells["sl"].Value.ToString().Trim();
                    string mx_djgbm = ChuCangMingXi.Rows[i].Cells["djgbm"].Value.ToString().Trim();
                    string mx_cfwz = ChuCangMingXi.Rows[i].Cells["cfwz"].Value.ToString().Trim();
                    string mx_bz = ChuCangMingXi.Rows[i].Cells["bz"].Value.ToString().Trim();

                    Sql = string.Format("insert into chucangmingxi(ccdh,xinghao, mc, gg, sl, djgbm, cfwz, bz) values('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", ccdh, mx_xinghao, mx_mc, mx_gg, mx_sl, mx_djgbm, mx_cfwz, mx_bz);
                    r = insert.getsqlcom1(Sql);
                }
                if (r == 1)
                {
                    MessageBox.Show("入仓完成！", "消息", MessageBoxButtons.OK);
                    this.Close();
                }
            }
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
        private void ChuCangMingXi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ChuCangMingXi.CurrentCell.RowIndex == 0 & ChuCangMingXi.CurrentCell.ColumnIndex == mc.Index)
            {
                Sql = "select distinct mc from lingbujian";
                mc.DataSource = SelectSql.getDataSet(Sql, "lingbujian").Tables[0];
                mc.DisplayMember = "mc";
                mc.ValueMember = "mc";
                //mc.DataPropertyName = "mc";
            }
        }

        ///<summary>二级联动，每次更改名称列，则相应更改此行的型号列下拉内容</summary>
        ///很重要！！！
        private void ChuCangMingXi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (ChuCangMingXi.CurrentCell == null)
            {
                return;
            }
            if (ChuCangMingXi.CurrentCell.ColumnIndex == mc.Index)//名称列改变，则后面的型号列相应改变
            {
                Sql = "select xinghao from lingbujian where mc='" + ChuCangMingXi.CurrentCell.Value.ToString().Trim() + "'";
                //只更改这一行！！！的型号选项
                DataGridViewComboBoxCell cell = ChuCangMingXi.Rows[e.RowIndex].Cells["xinghao"] as DataGridViewComboBoxCell;
                cell.DataSource = SelectSql.getDataSet(Sql, "lingbujian").Tables[0];
                cell.DisplayMember = "xinghao";
                cell.ValueMember = "xinghao";
            }
            else if (ChuCangMingXi.CurrentCell.ColumnIndex == xinghao.Index & ChuCangMingXi.Rows[e.RowIndex].Cells["xinghao"].Value != null)//型号列改变，则对应的刀具柜编码改变
            {
                Sql = "select distinct djgbm from rucangmingxi where xinghao='" + ChuCangMingXi.Rows[e.RowIndex].Cells["xinghao"].Value.ToString().Trim() + "'";
                //MySqlDataReader dr = SelectSql.getcom(Sql);
                //if (SelectSql.getDataSet(Sql, "rucangmingxi").Tables[0] == null)
                //{
                //    //全新刀具应该可以输入刀具柜编码和存放位置！暂未设置
                //    return;
                //}
                //else
                //{
                    DataGridViewComboBoxCell cell = ChuCangMingXi.Rows[e.RowIndex].Cells["djgbm"] as DataGridViewComboBoxCell;
                    cell.DataSource = SelectSql.getDataSet(Sql, "lingbujian").Tables[0];
                    cell.DisplayMember = "djgbm";
                    cell.ValueMember = "djgbm";
                //}
            }
            else if (ChuCangMingXi.CurrentCell.ColumnIndex == djgbm.Index)//型号改变导致对应的刀具柜编码改变，则相应的存放位置岁刀具柜编码改变
            {
                Sql = string.Format("select distinct cfwz from rucangmingxi where xinghao='{0}' and djgbm='{1}'", ChuCangMingXi.Rows[e.RowIndex].Cells["xinghao"].Value.ToString().Trim(), ChuCangMingXi.Rows[e.RowIndex].Cells["djgbm"].Value.ToString().Trim());
                //if (SelectSql.getDataSet(Sql, "ruCangMingXi").Tables[0] == null)
                //{
                //    //全新刀具应该可以输入刀具柜编码和存放位置！暂未设置
                //    return;
                //}
                //else
                //{
                    DataGridViewComboBoxCell cell = ChuCangMingXi.Rows[e.RowIndex].Cells["cfwz"] as DataGridViewComboBoxCell;
                    cell.DataSource = SelectSql.getDataSet(Sql, "rucangmingxi").Tables[0];
                    cell.DisplayMember = "cfwz";
                    cell.ValueMember = "cfwz";
                //}
            }
        }
        #endregion

        #region 根据入仓类型调整采购需求/刃磨单号下拉框的属性和内容
        private void CCLX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CCLX.SelectedItem.ToString().Trim() == "领用出仓")
            {
                JGGY.Enabled = true;
                LYBZ.Enabled = true;
                RMDH.Enabled = false;//改变下拉框状态

                //增加采购需求单号数据源
                //XQDH.DataSource = SelectSql.getDataSet("select rcdh from rucang", "rucang").Tables[0];//暂未设置为需求单号，而采用入仓单号测试！
                //XQDH.DisplayMember = "rcdh";
                //XQDH.ValueMember = "rcdh";
                //XQDH.Text = "";//默认值为空，以供选择
            }
            else if (CCLX.SelectedItem.ToString().Trim() == "刃磨出仓")
            {
                RMDH.Enabled = true;
                JGGY.Enabled = false;
                LYBZ.Enabled = false;//改变下拉框状态

                //增加刃磨单号数据源
                //XQDH.DataSource = SelectSql.getDataSet("select rcdh from rucang", "rucang").Tables[0];//暂未设置为需求单号，而采用入仓单号测试！
                //XQDH.DisplayMember = "rcdh";
                //XQDH.ValueMember = "rcdh";
                //XQDH.Text = "";//默认值为空，以供选择
            }
            else//其他出仓
            {
                RMDH.Enabled = false;
                JGGY.Enabled = false;
                LYBZ.Enabled = false;//改变下拉框状态
            }
        }
        #endregion

    }
}
