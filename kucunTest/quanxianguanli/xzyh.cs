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
    public partial class xzyh : Form
    {
        public xzyh()
        {
            InitializeComponent();
        }

        #region 全局变量
        private MySql Sql = new MySql();//MySQL类
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private string SqlStr = "";
        #endregion

        private void xzyh_Load(object sender, EventArgs e)
        {

        }

        //取消添加
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认取消添加用户？", "取消确认", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }

        //确认添加
        private void button1_Click(object sender, EventArgs e)
        {
            int row = 0;
            if ( yhm.Text == "" || xingming.Text == "" || pwd.Text == "" || juese.SelectedItem.ToString() == "" || bumen.SelectedItem.ToString() == "")
            {
                MessageBox.Show("请输入完整的信息！", "提示");
                return;
            }
            if (pwd.Text.Length < 6)
            {
                MessageBox.Show("密码长度需为6到10位！", "提示");
                return;
            }
            if (yhm.Text != "" && xingming.Text != "" && pwd.Text != "" && juese.SelectedItem.ToString() != "" && bumen.SelectedItem.ToString() != "" && pwd.Text.Length >5 && pwd.Text != "")
            {
                SqlStr = "insert into user (name,pwd,xingming,type,bumen,beizhu) VALUES ('" + yhm.Text + "','" + pwd.Text + "','" + xingming.Text + "','" + juese.Text + "','" + bumen.Text + "','" + beizhu.Text + "')";
                row = Sql.ExecuteNonQuery(SqlStr);
            }
            if (row != 0)
            {
                MessageBox.Show("添加用户完成！", "提示", MessageBoxButtons.OK);
                this.Close();
                this.DialogResult = DialogResult.OK;
            }

        }

        private void pwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z')
               || (e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8))
            {
                e.Handled = false;
                
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("请输入字母或者数字！", "提示");
            }
        }
    }
}
