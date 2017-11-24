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
using System.Threading;
using System.IO;

namespace kucunTest.Jichuang
{
    public partial class xinzengjichuang : Form
    {
        #region 全局变量
        private MySql SQL = new MySql();//MySQL类
        private string SqlStr = "";

        BaseAlex Alex = new BaseAlex();

        string tishi = "";

        //是否选择刀具柜图片
        bool flag = false;
        
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public xinzengjichuang()
        {
            InitializeComponent();

            //加载班组名称
            SqlStr = string.Format("SELECT {1} AS bzmc, {2} AS scxmc FROM {0} ", BanZu.TableName, BanZu.bzmc, BanZu.scxmc);
            DataTable db = SQL.getDataSet(SqlStr, BanZu.TableName).Tables[0];
            SSBZ.DataSource = db;
            SSBZ.DisplayMember = "bzmc";
            //SSBZ.ValueMember = "bzmc";
            //SSSCX.DataSource = db;
            //SSSCX.DisplayMember = "scxmc";
            //SSBZ.DataSource = SQL.DataReadList(SqlStr);
            //SSBZ.SelectedIndex = -1;
        }

        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xinzengjichuang_Load(object sender, EventArgs e)
        {
            SSBZ.SelectedIndex = -1;
            SSSCX.SelectedIndex = -1;
            JCLX.SelectedIndex = -1;
        }

        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int row = 0;
            tishi = "";

            //数据检查
            if (SSBZ.SelectedIndex < 0)
            {
                tishi = "请选择机床所属班组！";
                MessageBox.Show(tishi);
                //SSBZ.Focus();
                SSBZ.DroppedDown = true;

                return;
            }

            if (SSSCX.Text == "")
            {
                tishi = "请填写机床所属生产线！";
                MessageBox.Show(tishi);
                SSSCX.Focus();
                //SSSCX.DroppedDown = true;

                return;
            }

            if (JCLX.SelectedIndex < 0)
            {
                tishi = "请选择机床类型！";
                MessageBox.Show(tishi);
                //JCLX.Focus();
                JCLX.DroppedDown = true;

                return;
            }

            if (ZCBH.Text == "")
            {
                tishi = "请填写资产编号！";
                MessageBox.Show(tishi);
                ZCBH.Focus();

                return;
            }

            if (JCMC.Text == "")
            {
                tishi = "请填写机床名称！";
                MessageBox.Show(tishi);
                JCMC.Focus();

                return;
            }

            if (DKRL.Text == "")
            {
                tishi = "请填写刀库容量！";
                MessageBox.Show(tishi);
                DKRL.Focus();

                return;
            }

            //数据预处理
            string ssbz = SSBZ.Text.ToString();//所属班组
            string ssscx = SSSCX.Text;//所属生产线
            string jclx = JCLX.Text.ToString();//机床类型
            string zcbh = ZCBH.Text.ToString();//资产编号
            string jcmc = JCMC.Text.ToString().Trim();//机床名称/编码
            int dkrl = Convert.ToInt32(DKRL.Text.ToString().Trim());//刀库容量

            //判断机床名称是否已经存在
            if (Alex.CunZai(JiChuangBiao.TableName, string.Format("{0} = '{1}'", JiChuangBiao.jcbm, jcmc)) != 0)
            {
                tishi = "机床名称已存在，请修改机床名称！";
                MessageBox.Show(tishi);
                JCMC.Focus();
                JCMC.SelectAll();

                return;
            }

            if (dkrl < 0 || dkrl > 1000)
            {
                tishi = "刀库容量输入有误！\n注：刀库容量为0-1000的整数。";
                MessageBox.Show(tishi);
                DKRL.Focus();

                return;
            }

            //存入机床表
            SqlStr = string.Format("INSERT INTO {0}({1}, {2}, {3}, {4}, {5}) VALUES('{6}', '{7}', '{8}', '{9}', '{10}')", JiChuangBiao.TableName, JiChuangBiao.ssbz, JiChuangBiao.scx, JiChuangBiao.jclx, JiChuangBiao.jcbm, JiChuangBiao.zcbh, ssbz, ssscx, jclx, jcmc, zcbh);
            //Str = "insert into jichuang(shengchanxian, jichuangbianma, jichuangleixing) values('" + SSSCX.Text.ToString().Trim() + "', '" + JCMC.Text.ToString().Trim() + "', '" + jclx.Text.ToString().Trim() + "')";
            row = SQL.ExecuteNonQuery(SqlStr);
            SqlStr = "";

            //存入机床层数表
            SqlStr = string.Format("");
            string tempsqlstr = "";
            for (int j = 1; j <= dkrl; j++)
            {
                tempsqlstr = string.Format("INSERT INTO {0}({1}, {2}) VALUES('{3}', 'T{4}');", JiChuangDaoJuKu.TableName, JiChuangDaoJuKu.jcbm, JiChuangDaoJuKu.dth, jcmc, j.ToString("00"));
                SqlStr += tempsqlstr;
            }
            row = SQL.ExecuteNonQuery(SqlStr);
            SqlStr = "";

            //保存机床图片
            if (flag)
            {
                Picture_Save(jcmc + ".jpg");
            }

            tishi = "新增机床完成。";
            MessageBox.Show(tishi);
            //this.DialogResult = DialogResult.OK;
            //this.Close();

        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认取消新增机床？", "取消确认", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }        

        /// <summary>
        /// 刀库容量只能让输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DKRL_KeyPress(object sender, KeyPressEventArgs e)
        {
            Alex.KeyPress_OnlyNum(e);
        }

        /// <summary>
        /// 选择机床类型自动生成机床名称，“类型名 #1号机”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JCLX_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(JCLX.SelectedIndex < 0)
            {
                JCMC.Text = "";

                return;
            }

            int counts = Alex.CunZai(JiChuangBiao.TableName, string.Format("{0} LIKE '{1}%'", JiChuangBiao.jcbm, JCLX.Text.ToString())) + 1;//若数量为0，从1开始
            JCMC.Text = JCLX.Text.ToString() + " #" + counts + "号机";
        }

        /// <summary>
        /// 窗口关闭设置窗口dialogResult
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xinzengjichuang_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 所属班组选择变化，填充机床所属生产线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SSBZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SSBZ.SelectedIndex < 0)
            {
                SSSCX.Text = "";

                return;
            }

            string bz = SSBZ.Text.ToString();
            SSSCX.Text = bz.Substring(5) + "生产线";
        }

        /// <summary>
        /// 点击加载图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JCTP_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog lvse = new OpenFileDialog())
            {
                lvse.Title = "请选择机床图片";
                lvse.InitialDirectory = "";
                lvse.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
                lvse.FilterIndex = 1;

                if (lvse.ShowDialog() == DialogResult.OK)
                {
                    Thread.Sleep(200);
                    JCTP.Image = Image.FromFile(lvse.FileName);
                    flag = true;
                }
            }
        }

        /// <summary>
        /// 图片保存
        /// </summary>
        /// <param name="filename"></param>
        private void Picture_Save(string filename)
        {
            Bitmap bit = new Bitmap(JCTP.ClientRectangle.Width, JCTP.ClientRectangle.Height);
            JCTP.DrawToBitmap(bit, JCTP.ClientRectangle);

            //没有文件夹，新建文件夹
            if (Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Images\\JiChuang") == false)
            {
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Images\\JiChuang");
            }

            string str_iniFileUrl = System.Windows.Forms.Application.StartupPath + "\\Images\\JiChuang\\";

            //图片保存：若已存在此命名图片则先删除
            if (System.IO.File.Exists(str_iniFileUrl + filename))
            {
                System.IO.File.Delete(filename);
            }
            bit.Save(str_iniFileUrl + filename);
        }
    }
}
