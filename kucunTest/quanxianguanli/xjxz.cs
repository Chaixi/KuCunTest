using kucunTest.BaseClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kucunTest.quanxianguanli
{
    public partial class xjxz : Form
    {
        public xjxz()
        {
            InitializeComponent();
        }


        #region 全局变量
        private MySql Sql = new MySql();//MySQL类
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private string SqlStr = "";
        #endregion



        //取消新建
        private void btn_qxxj_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认取消新建小组？", "取消确认", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btn_xjxz_Click(object sender, EventArgs e)
        {
            int row = 0;
            if (xzm.Text == "" || xzxx.Text == "" )
            {
                MessageBox.Show("请输入完整的小组信息！", "提示");
            }
            if (xzm.Text != "" && xzxx.Text != "")
            {
                SqlStr = "insert into groupbiao (groupname,groupinfo,time,beizhu) VALUES ('"+ xzm.Text +"','"+ xzxx.Text +"','"+ DateTime.Now +"','"+ xzbeizhu.Text +"')";
                row = Sql.ExecuteNonQuery(SqlStr);
            }
            if (row != 0)
            {
                MessageBox.Show("新建小组完成！", "提示", MessageBoxButtons.OK);
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
        }

        //确认新建

    }
}
