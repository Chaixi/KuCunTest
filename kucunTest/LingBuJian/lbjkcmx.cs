using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kucunTest.LingBuJian
{
    public partial class lbjkcmx : Form
    {
        public lbjkcmx()
        {
            InitializeComponent();
        }

        #region 全局变量
        MySql SQL = new MySql();
        String Sqlstr = "";

        #endregion

        private void lbjkcmx_Load(object sender, EventArgs e)
        {



            string sqlstr1 = "select djgmc from daojugui";
            djgmc.DataSource = SQL.DataReadList(sqlstr1);
            djgmc.SelectedIndex = 0;
            kcmx.AutoGenerateColumns = false;
            czjl.AutoGenerateColumns = false;

        }

        private void jcbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sqlstr = "SELECT daojuid,daojuxinghao,daojuguige,daojuleixing,kcsl FROM jichuxinxi where weizhi = '" + djgmc.SelectedValue.ToString() + "'";
            DataSet ds = SQL.getDataSet1(Sqlstr);
            kcmx.DataSource = ds.Tables[0].DefaultView;
        }

        private void kcmx_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Sqlstr1 = "SELECT * FROM lbj_liushui where lbjmc = '" + kcmx.Rows[e.RowIndex].Cells["Column5"].Value.ToString() + "' and lbjxh = '" + kcmx.Rows[e.RowIndex].Cells["Column1"].Value.ToString() + "'";
            DataSet ds1 = SQL.getDataSet1(Sqlstr1);
            czjl.DataSource = ds1.Tables[0].DefaultView;
        }
    }
}
