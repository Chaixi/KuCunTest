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
    public partial class XYLS : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        String Sqlstr = "";

        BaseAlex Alex = new BaseAlex();
        #endregion

        public XYLS()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载，加载所有续用单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XYLS_Load(object sender, EventArgs e)
        {
            xuyonglishi.AutoGenerateColumns = false;
            xuyongmingxi.AutoGenerateColumns = false;

            string Sqlstr = "SELECT * FROM daojuxuyong";
            DataSet ds = SQL.getDataSet1(Sqlstr);
            xuyonglishi.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 点击续用单据查看续用明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xuyonglishi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string Sqlstr = "SELECT * FROM daojuxuyongmingxi WHERE xydh = '" + xuyonglishi.Rows[e.RowIndex].Cells["xydh"].Value.ToString() + "'";
            DataSet ds1 = SQL.getDataSet1(Sqlstr);
            xuyongmingxi.DataSource = ds1.Tables[0].DefaultView;
        }

        #region 表格绘制行号
        private void xuyonglishi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(xuyonglishi, e);
        }

        private void xuyongmingxi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(xuyongmingxi, e);
        }
        #endregion
    }
}
