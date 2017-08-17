using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kucunTest.Daojugui
{
    public partial class XZDJG : Form
    {
        public XZDJG()
        {
            InitializeComponent();
        }

        #region 全局变量
        private MySql Sql = new MySql();//MySQL类
        private string SqlStr = "";
        private string SqlStr1 = "";
        private string Str = "";
        int j;
        #endregion



        private void XZDJG_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认取消新增刀具柜？", "取消确认", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int row = 0;
            Str = "insert into daojugui(djgbm, djgmc, djglx) values('" + djgbm.Text.ToString().Trim() + "', '" + djgmc.Text.ToString().Trim() + "', '" + djglx.Text.ToString().Trim() + "')";
            string i = djgcs.Text.ToString().Trim();
            int x = Int32.Parse(i);
            for (j = 1; j <= x; j++)
            {
                SqlStr = "insert into daojuguicengshu(djgmc, djgcs) values('" + djgmc.Text.ToString().Trim() + "', '"  + j.ToString("00") + "层" + "');";
                SqlStr1 += SqlStr;
            }
            Sql.ExecuteNonQuery(SqlStr1);
            row = Sql.ExecuteNonQuery(Str);
            if (row != 0)
            {
                MessageBox.Show("新增刀具柜完成！", "提示", MessageBoxButtons.OK);
                this.Close();
                this.DialogResult = DialogResult.OK;


            }
        }
    }
}
