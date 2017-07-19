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
    public partial class xzthmx : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        String sqlstr = "";
        #endregion

        public xzthmx()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xzthmx_Load(object sender, EventArgs e)
        {
            //加载所有刀具，并选择第一条数据
            sqlstr = "select distinct daojuleixing from daojutemp";
            djlx.DataSource = SQL.DataReadList(sqlstr);
            djlx.SelectedIndex = 0;
            djcd.SelectedIndex = 0;
            djzt.SelectedIndex = 0;
        }

        #region 刀具信息三级联动
        private void djlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlstr = "select distinct daojuguige from daojutemp where daojuleixing = '" + djlx.SelectedItem.ToString().Trim() + "'";
            djgg.DataSource = SQL.DataReadList(sqlstr);
            //djgg.SelectedIndex = 0;//默认选择第一项
        }

        private void djgg_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                list.Add(djlx.Text.ToString().Trim());//list[0] 刀具类型
                list.Add(djgg.Text.ToString().Trim());//list[1] 刀具规格
                list.Add(djcd.Text.ToString().Trim());//list[2] 刀具长度
                list.Add(djid.Text.ToString().Trim());//list[3] 刀具id
                list.Add(djzt.Text.ToString().Trim());//list[4] 刀具状态
                list.Add(jcbm.Text.ToString().Trim());//list[5] 机床编码
                list.Add(dth.Text.ToString().Trim());//list[6] 刀套号
                list.Add(djgbm.Text.ToString().Trim());//list[7] 刀具柜编码
                list.Add(cfwz.Text.ToString().Trim());//list[8] 存放位置
                list.Add(bz.Text.ToString().Trim());//list[9] 备注

                DJTH djth = new DJTH();
                djth = (DJTH)this.Owner;
                djth.AddData(list);

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
            if (MessageBox.Show("是否停止添加刀具？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
            else if (jcbm.Text.ToString() == "" || dth.Text.ToString() == "" || djgbm.Text == "" || cfwz.Text == "")
            {
                tishi = "请将位置信息填写完整！";
            }

            if (tishi != "")
            {
                MessageBox.Show(tishi, "警告", MessageBoxButtons.OK);
                return 0;
            }
            else
                return 1;
        }
    }
}
