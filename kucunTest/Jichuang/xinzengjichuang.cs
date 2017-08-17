using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kucunTest.Jichuang
{
    public partial class xinzengjichuang : Form
    {
        public xinzengjichuang()
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


        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认取消新增机床？", "取消确认", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int row = 0;
            Str = "insert into jichuang(shengchanxian, jichuangbianma, jichuangleixing) values('" + scx.Text.ToString().Trim() + "', '" + jcmc.Text.ToString().Trim() + "', '" + jclx.Text.ToString().Trim() + "')";
            string i = dkcc.Text.ToString().Trim();
            int x = Int32.Parse(i);
            for (j = 1; j <= x; j++)
            {
                SqlStr = "insert into jcdaojuku(jichuangbianma, daotaohao) values('" + jcmc.Text.ToString().Trim() + "', '" + "T" + j.ToString("00") +"');";
                SqlStr1 += SqlStr;
            }
            Sql.ExecuteNonQuery(SqlStr1);
            row = Sql.ExecuteNonQuery(Str);
            if(row != 0)
            {
                MessageBox.Show("新增机床完成！", "提示", MessageBoxButtons.OK);
                this.Close();
                this.DialogResult = DialogResult.OK; 
            }

        }

        private void xinzengjichuang_Load(object sender, EventArgs e)
        {

        }
    }
}
