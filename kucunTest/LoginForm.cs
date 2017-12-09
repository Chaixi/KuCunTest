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
using MySql.Data.MySqlClient;

namespace kucunTest
{
    public partial class LoginForm : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";

        BaseAlex Alex = new BaseAlex();
        private MyOpaqueLayer.MyOpaqueLayer m_OpaqueLayer = null;//半透明蒙板层

        MsgForm tishi;

        private static MainForm MFrm;

        //string userTable = "user";//用户表
        //string userTb_name = "name";//用户名字段
        //string userTb_type = "type";//用户类型字段
        //string userTb_pwd = "pwd";//密码字段

        private string crt_username = "";
        //private string crt_pwd = "";

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public LoginForm()
        {
            InitializeComponent();

            chejian.SelectedIndex = 0;
            UserType.Text = "";

            panel2.BackColor = Color.FromArgb(128, Color.WhiteSmoke);
        }

        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            UserName.Select();
            //UserName.Text = "xmu";
            UserName.Text = "admin";
            pwd.Text = "123";
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
            //if(UserName.Text != "")
            //{
            //    Sqlstr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", User.TableName, User.name, UserName.Text.Trim());
            //    DataTable db = (SQL.getDataSet1(Sqlstr)).Tables[0];

            //    if(db.Rows.Count == 0)
            //    {
            //        UserType.Text = "用户名不存在！";
            //        UserName.Focus();
            //        UserName.SelectAll();
            //    }
            //    else
            //    {
            //        UserType.Text = "（" + db.Rows[0][User.type].ToString() + "）";
            //    }
            //}
            //else
            //{
            //    UserType.Text = "";
            //}
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

                Sqlstr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}' AND {3} = '{4}'", User.TableName, User.name, UserName.Text.Trim(), User.pwd, pwd.Text.Trim());
                DataTable db = (SQL.getDataSet1(Sqlstr)).Tables[0];

                //登录成功
                if (db.Rows.Count != 0)
                {
                    //设置用户名全局变量
                    MySql.CurrentUserName = UserName.Text.ToString();

                    MainForm mainfrm = Program.MainFormInstance;
                    mainfrm.Show();

                    this.HideOpaqueLayer();//隐藏遮罩层
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("密码错误，请重试！", "提示");
                    this.HideOpaqueLayer();//隐藏遮罩层
                    return;
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
            //if(MessageBox.Show("确认取消登录？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    this.Close();
            //}
            this.Close();
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

        private void linkLabel1_MouseLeave(object sender, EventArgs e)
        {
            linkLabel1.Text = "忘记密码？";
        }

        private void linkLabel1_MouseHover(object sender, EventArgs e)
        {
            linkLabel1.Text = "默认账户admin，密码为123";
        }

        /// <summary>
        /// 数据库设置按妞
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_setDatabase_Click(object sender, EventArgs e)
        {
            db_DataSource.Text = "localhost";
            db_userid.Text = "root";
            db_userpwd.Text = "root";
            panel_SetDatabase.Visible = true;
        }

        /// <summary>
        /// 数据库连接测试按妞
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sqlConTest_Click(object sender, EventArgs e)
        {
            if(CheckDatabseData())
            {
                mysqlConTest();
            }
        }

        /// <summary>
        /// 连接测试方法
        /// </summary>
        /// <returns>返回字符串，如果连接成功，返回字符串true，否则返回错误消息字符串</returns>
        private bool mysqlConTest()
        {
            string message = "连接中...";
            if(!Alex.ActivateForm(tishi))
            {
                tishi = new MsgForm("");
                tishi.Show();
            }
            tishi.TopMost = true;
            tishi.SetContent(message, "连接状态");
            //tishi.Show();

            string connStr = string.Format("Data Source={0}; Database=kucuntest; Userid={1}; PWD={2}; Charset=utf8;", db_DataSource.Text.ToString().Trim(), db_userid.Text.ToString().Trim(), db_userpwd.Text.ToString().Trim());

            if (db_Port.Text != "系统默认端口")
            {
                connStr += string.Format("port={0}", db_Port.Text.ToString().Trim());
            }

            MySqlConnection conn = new MySqlConnection(connStr);
            
            try
            {
                conn.Open();
                message = "连接成功！";
                tishi.SetContent(message, "成功");
                return true;
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                tishi.SetContent(message, "出错了");
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// 更新数据库设置按妞
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_UpdateSetting_Click(object sender, EventArgs e)
        {
            if(CheckDatabseData())
            {
                if (mysqlConTest())
                {
                    string connStr = string.Format("Data Source={0}; Database=kucuntest; Userid={1}; PWD={2}; Charset=utf8;", db_DataSource.Text.ToString().Trim(), db_userid.Text.ToString().Trim(), db_userpwd.Text.ToString().Trim());

                    if (db_Port.Text != "系统默认端口")
                    {
                        connStr += string.Format("port={0}", db_Port.Text.ToString().Trim());
                    }

                    MySql.SetMysqlConStr = connStr;

                    tishi.SetContent("数据库设置保存成功！", "成功");
                }
            }            
        }

        /// <summary>
        /// 返回登录按妞
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_returnLogin_Click(object sender, EventArgs e)
        {
            panel_SetDatabase.Visible = false;
        }

        /// <summary>
        /// 检查输入的数据库设置数据
        /// </summary>
        /// <returns></returns>
        private bool CheckDatabseData()
        {
            if (db_DataSource.Text == "" || db_DataSource.Text == "请输入数据库地址")
            {
                db_DataSource.Text = "请输入数据库地址";
                db_DataSource.Focus();
                db_DataSource.SelectAll();
                return false;
            }

            if (db_userid.Text == "" || db_userid.Text == "请输入连接用户名")
            {
                db_userid.Text = "请输入连接用户名";
                db_userid.Focus();
                db_userid.SelectAll();
                return false;
            }

            if (db_userpwd.Text == "")
            {
                label_pwdwarning.Visible = true;
                return false;
            }
            else
            {
                label_pwdwarning.Visible = false;
            }

            return true;
        }

        private void TextBoxClickandSelect(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.SelectAll();
        }
    }
}
