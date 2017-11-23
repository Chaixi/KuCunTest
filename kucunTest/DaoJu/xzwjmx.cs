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

namespace kucunTest.DaoJu
{
    public partial class xzwjmx : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        BaseAlex Alex = new BaseAlex();
        String sqlstr = "";
        String sqlstr1 = "";
        #endregion

        public xzwjmx()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xzwjmx_Load(object sender, EventArgs e)
        {
            //加载所有刀具，并选择第一条数据
            djlx.DataSource = Alex.GetList("djlx");
            djlx.SelectedIndex = -1;

            djzt.SelectedIndex = -1;

            //加载所有机床
            jcbm.DataSource = Alex.GetList("jc");
            jcbm.SelectedIndex = -1;
        }

        #region 刀具信息三级联动
        private void djlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(djlx.SelectedIndex < 0)
            {
                djgg.DataSource = null;
                return;
            }

            sqlstr = "select distinct daojuguige from daojutemp where daojuleixing = '" + djlx.SelectedItem.ToString().Trim() + "'";
            djgg.DataSource = SQL.DataReadList(sqlstr);
            djgg.SelectedIndex = -1;//默认选择第一项
        }

        private void djgg_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(djgg.SelectedIndex < 0)
            {
                djid.DataSource = null;
                return;
            }

            djid.DataSource = null;

            sqlstr = "select daojuid from daojutemp where daojuleixing = '" + djlx.SelectedItem.ToString().Trim() + "'" + " and daojuguige = '" + djgg.SelectedItem.ToString().Trim() + "'";
            djid.DataSource = SQL.DataReadList(sqlstr);
            //djid.SelectedIndex = 0;//默认选择第一项
        }
        #endregion

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckData() == 0)
            {
                return;
            }
            else
            {
                List<string> list = new List<string>();
                list.Add(djlx.SelectedItem.ToString().Trim());//list[0] 刀具类型
                list.Add(djgg.SelectedItem.ToString().Trim());//list[1] 刀具规格
                list.Add(djid.SelectedItem.ToString().Trim());//list[2] 刀具id
                list.Add(djzt.SelectedItem.ToString().Trim());//list[3] 刀具状态
                list.Add(jcbm.Text.ToString().Trim());//list[4] 机床编码
                list.Add(dth.Text.ToString().Trim());//list[5] 刀套号
                list.Add(bz.Text.ToString().Trim());//list[6] 备注

                DJWJ djwj = new DJWJ();
                djwj = (DJWJ)this.Owner;
                djwj.AddData(list);

                //this.Close();
            }
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("是否停止添加外借刀具？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 明细数据验证
        /// </summary>
        /// <returns></returns>
        private int CheckData()
        {
            string tishi = "";
            if (djlx.Text.ToString() == "" || djgg.Text.ToString() == "" || djid.Text.ToString() == "")
            {
                tishi = "请将刀具信息填写完整！";
            }
            else if (jcbm.Text.ToString() == "" || dth.Text.ToString() == "")
            {
                tishi = "请将机床编号与刀套号填写完整！";
            }

            if (tishi != "")
            {
                MessageBox.Show(tishi, "警告", MessageBoxButtons.OK);
                return 0;
            }
            else
                return 1;
        }

        private void jcbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(jcbm.SelectedIndex < 0)
            {
                dth.DataSource = null;
                return;
            }

            sqlstr = "SELECT jcdjk.daotaohao FROM jcdaojuku jcdjk LEFT JOIN daojutemp djtp ON concat(djtp.weizhi,'-', djtp.cengshu ) = concat(jcdjk.jichuangbianma,'-', jcdjk.daotaohao ) where djtp.daojuid is NULL and jcdjk.jichuangbianma = '" + jcbm.SelectedItem.ToString().Trim() + "'";
            dth.DataSource = SQL.DataReadList(sqlstr);
            dth.SelectedIndex = 0;
        }
    }
}
