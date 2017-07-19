using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kucunTest.DaoJu
{
    public partial class xzccmx : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        String sqlstr = "";
        #endregion

        public xzccmx()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xzccmx_Load(object sender, EventArgs e)
        {
            sqlstr = "select distinct daojuleixing from daojutemp";
            djlx.DataSource = SQL.DataReadList(sqlstr);
            djlx.SelectedIndex = 0;
        }

        #region 刀具信息三级联动
        private void djxh_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlstr = "select distinct daojuguige from daojutemp where daojuleixing = '" + djlx.SelectedItem.ToString().Trim() + "'";
            djgg.DataSource = SQL.DataReadList(sqlstr);
            //djgg.SelectedIndex = 0;//默认选择第一项
        }

        private void djgg_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sqlstr = "select daojuid from daojutemp where daojuleixing = '" + djlx.SelectedItem.ToString().Trim() + "'" + " and daojuguige = '" + djgg.SelectedItem.ToString().Trim() + "'";
            //djid.DataSource = SQL.DataReadList(sqlstr);
            //djid.SelectedIndex = 0;//默认选择第一项

            sqlstr = "SELECT dj.daojuid, dj.daojuxinghao, dj.daojuguige, dj.daojuleixing, dj.daojushouming, djmx.jichuangbianma FROM daojutemp dj LEFT JOIN daojulingyongmingxi djmx ON dj.daojuid = djmx.daojuid WHERE dj.daojuleixing = '" + djlx.SelectedItem.ToString().Trim() + "'" + " and dj.daojuguige = '" + djgg.SelectedItem.ToString().Trim() + "'";
            djid.Text = "";
            List<string> list1 = new List<string>();//机床位置信息
            List<string> list2 = new List<string>();//刀具ID信息
            List<string> list3 = new List<string>();
            list1 = SQL.DataReadList1(sqlstr);//机床位置信息
            list2 = SQL.DataReadList(sqlstr);//刀具ID信息
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] == "")
                {
                    list3.Add(list2[i]);
                }
                else
                {
                    continue;
                }

            }
            if (list3.Count == 0)
            {
                MessageBox.Show("该规格下没有空闲刀具，是否现在进行装配刀具？", "提示", MessageBoxButtons.YesNo);//是否进行刀具装配
            }
            else
            {
                djid.DataSource = list3;
            }
        }
        #endregion

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认停止添加出仓刀具？", "取消确认", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(CheckData() == 0)
            {
                return;
            }
            else
            {
                List<string> list = new List<string>();
                list.Add(djlx.SelectedItem.ToString().Trim());//list[0] 刀具类型
                list.Add(djgg.SelectedItem.ToString().Trim());//list[1] 刀具规格
                list.Add(djcd.Text.ToString().Trim());//list[2] 刀具长度
                list.Add(djid.SelectedItem.ToString().Trim());//list[3] 刀具id
                list.Add(jcbm.Text.ToString().Trim());//list[4] 机床编码
                list.Add(dth.Text.ToString().Trim());//list[5] 刀套号
                list.Add(bz.Text.ToString().Trim());//list[6] 备注

                DJCCD form_djccd = new DJCCD();
                form_djccd = (DJCCD)this.Owner;
                form_djccd.AddData(list);

                //this.Close();
            }
        }

        /// <summary>
        /// 出仓明细数据验证
        /// </summary>
        /// <returns></returns>
        private int CheckData()
        {
            string tishi = "";
            if(djlx.Text.ToString() == "" || djgg.Text.ToString() == "" || djid.Text.ToString() == "")
            {
                tishi = "请将刀具信息填写完整！";
            }
            else if(jcbm.Text.ToString() == "" || dth.Text.ToString() == "")
            {
                tishi = "请将机床编号与刀套号填写完整！";
            }

            if(tishi != "")
            {
                MessageBox.Show(tishi, "警告", MessageBoxButtons.OK);
                return 0;
            }
            else
                return 1;
        }
    }
}
