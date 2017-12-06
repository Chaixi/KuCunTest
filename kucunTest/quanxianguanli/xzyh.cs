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
        private BaseAlex Alex = new BaseAlex();

        private string SqlStr = "";

        private string LogType = "权限管理";
        private string LogMessage = "";
        #endregion

        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xzyh_Load(object sender, EventArgs e)
        {
            //加载已有小组
            SqlStr = string.Format("SELECT DISTINCT {1} FROM {0}", UserGroup.TableName, UserGroup.groupName);
            ssxz.DataSource = Sql.DataReadList(SqlStr);
            ssxz.SelectedIndex = -1;
        }

        /// <summary>
        /// 确认添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int row = 0;
            if (yhm.Text == "" || xingming.Text == "" || pwd1.Text == "" || pwd2.Text == "" || ssxz.Text == "" || bumen.Text == "")
            {
                MessageBox.Show("请输入完整的用户信息！", Program.tishiTitle);
                return;
            }

            if (pwd1.Text.Length < 6)
            {
                MessageBox.Show("密码长度需为6到10位！", Program.tishiTitle);
                return;
            }

            if (pwd1.Text != pwd2.Text)
            {
                MessageBox.Show("两次密码输入不一致！", Program.tishiTitle);
                return;
            }

            if(Alex.CunZai(User.TableName, string.Format("{0} = '{1}'", User.name, yhm.Text)) != 0)
            {
                MessageBox.Show(string.Format("用户名：{0}已存在！", yhm.Text), Program.tishiTitle);
                yhm.Focus();
                return;
            }

            SqlStr = string.Format("INSERT INTO `{0}`({1}, {2}, {3}, {4}, {5}, {6}, {7}) VALUES ('{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}')", User.TableName, User.name, User.pwd, User.xingming, User.type, User.groupName, User.bumen, User.bz, yhm.Text, pwd1.Text, xingming.Text, ssxz.Text, ssxz.Text, bumen.Text, beizhu.Text);
            row = Sql.ExecuteNonQuery(SqlStr);

            //日志记录
            LogMessage = string.Format("成功添加用户：{0}！", yhm.Text);
            Program.WriteLog(LogType, LogMessage);
            LogMessage = "";

            MessageBox.Show(string.Format("成功添加用户：{0}！", yhm.Text), Program.tishiTitle, MessageBoxButtons.OK);
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 取消添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认取消添加用户？", Program.tishiTitle, MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 密码输入判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                MessageBox.Show("请输入字母或者数字！", Program.tishiTitle);
            }
        }
    }
}
