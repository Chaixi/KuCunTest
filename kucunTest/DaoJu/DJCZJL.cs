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
    public partial class DJCZJL : Form
    {
        #region 全局变量
        private string Sqlstr = "";
        private MySql SQL = new MySql();

        private string djid = "";
        #endregion

        public DJCZJL( string id)
        {
            InitializeComponent();
            djid = id;
        }

        private void DJCZJL_Load(object sender, EventArgs e)
        {
            Sqlstr = string.Format("SELECT danhao, dhlx, djlx, djgg, djid, CONCAT(wzbm, '-', jtwz) AS djwz, czsj, jbr, bz FROM {0} WHERE djid = '{1}' ORDER BY czsj DESC", "daojuliushui", djid);
            djsymx.DataSource = (SQL.getDataSet(Sqlstr, "daojuliushui")).Tables[0].DefaultView;
            djsymx.AutoGenerateColumns = false;
        }

        private void DJCZJL_FormClosed(object sender, FormClosedEventArgs e)
        {
            Alex.CloseFormFromTabpages(this);

        }
    }
}
