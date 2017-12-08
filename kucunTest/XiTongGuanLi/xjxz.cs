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
        private BaseAlex Alex = new BaseAlex();

        private string SqlStr = "";

        private string LogType = "权限管理";
        private string LogMessage = "";
        #endregion

        /// <summary>
        /// 确认添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xjxz_Click(object sender, EventArgs e)
        {
            if (xzm.Text == "" || xzxx.Text == "")
            {
                MessageBox.Show("请输入完整的小组信息！", Program.tishiTitle);
            }

            if(Alex.CunZai(UserGroup.TableName, string.Format("{0} = '{1}'", UserGroup.groupName, xzm.Text.ToString())) != 0)
            {
                MessageBox.Show(string.Format("小组名：{0} 已存在！请修改后重新添加。", xzm.Text.ToString()), Program.tishiTitle);
                xzm.Focus();
                return;
            }

            SqlStr = string.Format("INSERT INTO {0}({1}, {2}, {3}, {4}) VALUES ('{5}', '{6}', '{7}', '{8}')", UserGroup.TableName, UserGroup.groupName, UserGroup.groupInfo, UserGroup.time, UserGroup.bz, xzm.Text, xzxx.Text, DateTime.Now.ToString(), xzbeizhu.Text);
            Sql.ExecuteNonQuery(SqlStr);

            //日志记录
            LogMessage = string.Format("成功添加小组：{0}！", xzm.Text);
            Program.WriteLog(LogType, LogMessage);
            LogMessage = "";

            MessageBox.Show(string.Format("成功添加小组：{0}！", xzm.Text), Program.tishiTitle, MessageBoxButtons.OK);
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 取消添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_qxxj_Click(object sender, EventArgs e)
        {
            //DialogResult dr = MessageBox.Show("确认取消添加小组？", Program.tishiTitle);
            //if (dr == DialogResult.OK)
            //{
            //    this.Close();
            //}
            this.Close();
        }

        /// <summary>
        /// 小组名文本框是去焦点判断小组名是否已经存在
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xzm_Leave(object sender, EventArgs e)
        {
            if (xzm.Text == null || xzm.Text == "")
            {
                label_xzmcz.Visible = false;
                return;
            }

            if (Alex.CunZai(UserGroup.TableName, string.Format("{0} = '{1}'", UserGroup.groupName, xzm.Text.ToString())) != 0)
            {
                label_xzmcz.Visible = true;
                xzm.Focus();
                xzm.SelectAll();
                return;
            }
            else
            {
                label_xzmcz.Visible = false;
            }
        }
    }
}
