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
    public partial class DJXY : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";
        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();//窗口自适应类
        int HJ = 0;

        DataSet lymx_ds = new DataSet();
        DataTable lymx_db = new DataTable();

        string danjubiao = "daojulingyong";
        string mingxibiao = "daojulingyongmingxi";
        string liushuibiao = "daojuliushui";
        string daojutemp = "daojutemp";
        string DHZD = "chucangdanhao";
        #endregion

        public DJXY()
        {
            InitializeComponent();
        }

        private void DJXY_Load(object sender, EventArgs e)
        {

        }
    }
}
