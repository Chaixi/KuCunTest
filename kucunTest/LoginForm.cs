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


namespace kucunTest
{
    public partial class LoginForm : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";

        BaseAlex Alex = new BaseAlex();
        private MyOpaqueLayer.MyOpaqueLayer m_OpaqueLayer = null;//半透明蒙板层

        string userTable = "user";//用户表
        string userTb_name = "name";//用户名字段
        string userTb_type = "type";//用户类型字段
        string userTb_pwd = "pwd";//密码字段

        string crt_username = "";
        string crt_pwd = "";

        #endregion

        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            chejian.SelectedIndex = 0;
            UserType.Text = "";

            panel2.BackColor = Color.FromArgb(128, Color.WhiteSmoke);

            UserName.Select();
        }

        /// <summary>
        /// 厦门大学技术支持链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.xmu.edu.cn");
            //System.Diagnostics.Process.Start("http://jwc.xmu.edu.cn/");
        }

        /// <summary>
        /// 判断用户类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserName_Leave(object sender, EventArgs e)
        {
            if(UserName.Text != "")
            {
                Sqlstr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", userTable, userTb_name, UserName.Text.Trim());
                DataTable db = (SQL.getDataSet1(Sqlstr)).Tables[0];

                if(db.Rows.Count == 0)
                {
                    UserType.Text = "用户名不存在！";
                    UserName.Select();
                    UserName.SelectAll();
                }
                else
                {
                    UserType.Text = "（" + db.Rows[0][userTb_type].ToString() + "）";
                }
            }
            else
            {
                UserType.Text = "";
            }
        }

        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void login_Click(object sender, EventArgs e)
        {
            if(UserName.Text == "" || pwd.Text == "")
            {
                MessageBox.Show("用户名和密码不能为空！", "提示");
            }
            else
            {
                this.ShowOpaqueLayer(this.panel1, 125, true);//显示遮罩层

                Sqlstr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}' AND {3} = '{4}'", userTable, userTb_name, UserName.Text.Trim(), userTb_pwd, pwd.Text.Trim());
                DataTable db = (SQL.getDataSet1(Sqlstr)).Tables[0];

                if (db.Rows.Count != 0)
                {
                    MainForm mainfrm = new MainForm();
                    mainfrm.Show();

                    this.HideOpaqueLayer();//隐藏遮罩层
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("密码错误，请重试！", "提示");
                }
            }
            
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确认取消登录？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 显示遮罩层
        /// </summary>
        /// <param name="control"></param>
        /// <param name="alpha"></param>
        /// <param name="showLoadingImage"></param>
        protected void ShowOpaqueLayer(Control control, int alpha, bool showLoadingImage)
        {
            if (this.m_OpaqueLayer == null)
            {
                this.m_OpaqueLayer = new MyOpaqueLayer.MyOpaqueLayer(alpha, showLoadingImage);
                control.Controls.Add(this.m_OpaqueLayer);
                this.m_OpaqueLayer.Dock = DockStyle.Fill;
                this.m_OpaqueLayer.BringToFront();
            }
            this.m_OpaqueLayer.Enabled = true;
            this.m_OpaqueLayer.Visible = true;


        }

        /// <summary>
        /// 隐藏遮罩层
        /// </summary>
        protected void HideOpaqueLayer()
        {
            if (this.m_OpaqueLayer != null)
            {
                this.m_OpaqueLayer.Enabled = false;
                this.m_OpaqueLayer.Visible = false;
            }
        }
    }
}
