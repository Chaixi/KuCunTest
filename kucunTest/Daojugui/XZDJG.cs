using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

using kucunTest.BaseClasses;
using NPinyin;

namespace kucunTest.Daojugui
{
    public partial class XZDJG : Form
    {
        #region 全局变量
        private MySql SQL = new MySql();//MySQL类
        private BaseAlex Alex = new BaseAlex();
        private string SqlStr = "";
        int j;

        private string tishi = "";

        //是否选择刀具柜图片
        bool flag = false;

        string LogType = "刀具柜";
        string LogMessage = "";
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public XZDJG()
        {
            InitializeComponent();

            //加载已有刀具柜类型
            SqlStr = string.Format("SELECT DISTINCT {1} FROM {0}", DaoJuGui.TableName, DaoJuGui.djglx);
            djglx.DataSource = SQL.DataReadList(SqlStr);
            djglx.SelectedIndex = -1;
        }

        /// <summary>
        /// 取消按妞
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认取消新增刀具柜？", "取消确认", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 确认按妞
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            int row = 0;
            tishi = "";

            //数据检查
            if(djgmc.Text == "")
            {
                tishi = "请填写刀具柜名称！";
                MessageBox.Show(tishi);
                djgmc.Focus();

                return;
            }

            if(djglx.SelectedIndex < 0)
            {
                tishi = "请选择刀具柜类型！";
                MessageBox.Show(tishi);
                djglx.Focus();

                return;
            }

            if(djgbm.Text == "")
            {
                tishi = "请填写刀具柜编码！";
                MessageBox.Show(tishi);
                djgbm.Focus();

                return;
            }

            if(djgcs.Text == "")
            {
                tishi = "请填写刀具柜层数！";
                MessageBox.Show(tishi);
                djgcs.Focus();

                return;
            }

            //判断刀具柜名称是否存在
            string conditions = string.Format("{0} = '{1}'", DaoJuGui.djgmc, djgmc.Text.ToString());
            if(Alex.CunZai(DaoJuGui.TableName, conditions) != 0)
            {
                tishi = djgmc.Text + "已存在！请修改刀具柜名称！";
                MessageBox.Show(tishi);
                djgmc.Focus();
                djgmc.SelectAll();

                return;
            }

            //数据预处理
            string mc = djgmc.Text.ToString();
            string lx = djglx.SelectedItem.ToString();
            string bm = djgbm.Text;
            int cs = Convert.ToInt16(djgcs.Text.ToString());
            string cfsm = beizhu.Text.ToString();

            if(cs < 0 || cs > 50)
            {
                tishi = "请填写正确的刀具柜层数！\n注：刀具柜层数为大于0，小于50的整数。";
                MessageBox.Show(tishi);
                djgcs.Focus();
                djgcs.SelectAll();

                return;
            }

            //存入刀具柜表
            SqlStr = string.Format("INSERT INTO {0}({1}, {2}, {3}, {4}) VALUES('{5}', '{6}', '{7}', '{8}')", DaoJuGui.TableName, DaoJuGui.djgmc, DaoJuGui.djglx, DaoJuGui.djgbm, DaoJuGui.cfsm, mc, lx, bm, cfsm);
            //Str = "INSERT INTO daojugui(djgbm, djgmc, djglx) VALUES('" + djgbm.Text.ToString().Trim() + "', '" + djgmc.Text.ToString().Trim() + "', '" + djglx.Text.ToString().Trim() + "')";
            row = SQL.ExecuteNonQuery(SqlStr);
            SqlStr = "";

            //存储刀具柜层数表
            string tempsqlstr = "";
            for (j = 1; j <= cs; j++)
            {
                tempsqlstr = string.Format("INSERT INTO {0}({1}, {2}) VALUES('{3}', '{4}层');", DaoJuGuiCengShu.TableName, DaoJuGuiCengShu.djgmc, DaoJuGuiCengShu.djgcs, mc, j);
                //SqlStr = "insert into daojuguicengshu(djgmc, djgcs) values('" + djgmc.Text.ToString().Trim() + "', '"  + j.ToString("00") + "层" + "');";
                SqlStr += tempsqlstr;
            }
            row = SQL.ExecuteNonQuery(SqlStr);
            SqlStr = "";

            //保存刀具柜图片
            if(flag)
            {
                Picture_Save(djgmc.Text.ToString() + ".jpg");
            }

            if (row != 0)
            {
                MessageBox.Show("新增刀具柜完成！", "提示", MessageBoxButtons.OK);

                //日志记录
                LogMessage = string.Format("成功新增刀具柜层数为{0}层的{1}。", cs, mc);
                Program.WriteLog(LogType, LogMessage);
                LogMessage = "";

                //this.Close();
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// 选择刀具柜图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog lvse = new OpenFileDialog())
            {
                lvse.Title = "请选择刀具柜图片";
                lvse.InitialDirectory = "";
                lvse.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
                lvse.FilterIndex = 1;

                if (lvse.ShowDialog() == DialogResult.OK)
                {
                    Thread.Sleep(200);
                    djgtp.Image = Image.FromFile(lvse.FileName);
                    flag = true;

                    //日志记录
                    LogMessage = string.Format("成功加载{0}的刀具柜图片。", djgmc.Text);
                    Program.WriteLog(LogType, LogMessage);
                    LogMessage = "";
                }
            }
        }

        /// <summary>
        /// 图片保存
        /// </summary>
        /// <param name="filename"></param>
        private void Picture_Save(string filename)
        {
            Bitmap bit = new Bitmap(djgtp.ClientRectangle.Width, djgtp.ClientRectangle.Height);
            djgtp.DrawToBitmap(bit, djgtp.ClientRectangle);

            //没有文件夹，新建文件夹
            if (Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Images\\DaoJuGui") == false)
            {
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Images\\DaoJuGui");
            }

            string str_iniFileUrl = System.Windows.Forms.Application.StartupPath + "\\Images\\DaoJuGui\\";

            //图片保存：若已存在此命名图片则先删除
            if (System.IO.File.Exists(str_iniFileUrl + filename))
            {
                System.IO.File.Delete(filename);
            }
            bit.Save(str_iniFileUrl + filename);

            //日志记录
            LogMessage = string.Format("成功保存{0}的刀具柜图片到{1}", djgmc.Text, str_iniFileUrl + filename);
            Program.WriteLog(LogType, LogMessage);
            LogMessage = "";
        }

        /// <summary>
        /// 刀具柜层数只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void djgcs_KeyPress(object sender, KeyPressEventArgs e)
        {
            Alex.KeyPress_OnlyNum(e);
        }

        /// <summary>
        /// 刀具柜类型选择变化，自动生成刀具柜编码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void djglx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(djglx.SelectedIndex < 0)
            {
                djgmc.Text = "";
                djgbm.Text = "";

                return;
            }

            //刀具类型拼音首字母
            string newid_djglx = Pinyin.ConvertEncoding(djglx.SelectedItem.ToString(), Encoding.UTF8, Encoding.GetEncoding("GB2312"));
            string lx = Pinyin.GetInitials(newid_djglx);
            int count;//记录已有刀具柜数量

            SqlStr = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = '{2}'", DaoJuGui.TableName, DaoJuGui.djglx, djglx.Text);
            count = Convert.ToInt32(SQL.ExecuteScalar(SqlStr));

            string mc = djglx.SelectedItem.ToString() + "-" + (count + 1).ToString("000");
            string bm = lx + "-" + (count + 1).ToString("000");

            djgbm.Text = bm;

            djgmc.Text = mc;
            djgmc.Focus();
        }
    }
}
