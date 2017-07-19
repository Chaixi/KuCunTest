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
    public partial class CCHistory : Form
    {
        #region 全局变量
        private MySql SQL = new MySql();
        private string SqlStr = "";
        #endregion

        public CCHistory()
        {
            InitializeComponent();
        }

        #region 窗体加载
        /// <summary>
        /// 刷新出仓历史表，从数据库提取历史出仓单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CCHistory_Load(object sender, EventArgs e)
        {
            SqlStr = "select ccdh, cclx, ccrq, czy, bz from chucang";
            DataSet ds = SQL.getDataSet(SqlStr, "chucang");
            LiShi.DataSource = ds.Tables[0].DefaultView;
        }
        #endregion

        #region datagridview事件设置
        ///<summary>
        ///datagridview每一行自动生成序号
        /// </summary>
        private void LiShi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, LiShi.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), LiShi.RowHeadersDefaultCellStyle.Font, rectangle, LiShi.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void MingXi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, MingXi.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), MingXi.RowHeadersDefaultCellStyle.Font, rectangle, MingXi.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        #endregion

        #region 新建出仓单按钮
        private void NewBtn_Click(object sender, EventArgs e)
        {
            
            NewCC cc = new NewCC();
            // rc.MdiParent = new MainForm();
            // rc.Parent = rc.MdiParent.p
            //cc.Show();
            cc.ShowDialog();
        }
        #endregion

        #region 点击出仓单号查看出仓明细
        /// <summary>
        /// 判断当前点击的是否是第一列：入仓单号，若是，则查看其明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LiShi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int RowIndex = LiShi.CurrentCell.RowIndex;
            int ColumnIndex = LiShi.CurrentCell.ColumnIndex;
            if (ColumnIndex == 0)
            {
                string LS_rcdh = LiShi.CurrentCell.Value.ToString();
                SqlStr = string.Format("select xinghao, mc, gg, sl, djgbm, cfwz, bz from chucangmingxi where ccdh = '{0}'", LS_rcdh);
                DataSet ds = SQL.getDataSet(SqlStr, "chucangmingxi");
                MingXi.DataSource = ds.Tables[0].DefaultView;
            }
        }
        #endregion

        private void AllBtn_Click(object sender, EventArgs e)
        {
            SqlStr = "select ccdh as 出仓单号, xinghao, mc, gg, sl, djgbm, cfwz, bz from chucangmingxi";
            DataSet ds = SQL.getDataSet(SqlStr, "chucangmingxi");
            MingXi.DataSource = ds.Tables[0].DefaultView;
        }
    }
}
