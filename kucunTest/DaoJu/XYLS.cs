using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kucunTest.DaoJu
{
    public partial class XYLS : Form
    {
        public XYLS()
        {
            InitializeComponent();
        }


        #region 全局变量
        MySql SQL = new MySql();
        String Sqlstr = "";

        #endregion


        private void XYLS_Load(object sender, EventArgs e)
        {
            string sqlstr1 = "select xuyongdanhao,xuyongbanzu,xuyongren,xuyongriqi,caozuoyuan from daojuxuyong";
            DataSet ds = SQL.getDataSet1(sqlstr1);
            xuyonglishi.DataSource = ds.Tables[0].DefaultView;

            xuyonglishi.AutoGenerateColumns = false;
            xuyongmingxi.AutoGenerateColumns = false;
        }

        private void xuyonglishi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Sqlstr1 = "SELECT daojuleixing,daojuguige,daojuid,shuliang,jiagonggongxu,jichuangbianma,daotaohao FROM daojuxuyongmingxi where xuyongdanhao = '" + xuyonglishi.Rows[e.RowIndex].Cells["xydh"].Value.ToString() + "'";
            DataSet ds1 = SQL.getDataSet1(Sqlstr1);
            xuyongmingxi.DataSource = ds1.Tables[0].DefaultView;
        }
    }
}
