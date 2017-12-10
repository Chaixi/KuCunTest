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
    public partial class xzlymx : Form
    {
        #region 全局变量
        MySql SQL = new MySql();

        BaseAlex Alex = new BaseAlex();
        String sqlstr = "";
        String sqlstr1 = "";
        int index = -1;
        #endregion

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public xzlymx()
        {
            InitializeComponent();

            //加载所有刀具类型
            djlx.DataSource = Alex.GetList("djlx");
            //加载所有机床编码/名称
            jcbm.DataSource = Alex.GetList("jc");

            djlx.SelectedIndex = -1;
            jcbm.SelectedIndex = -1;

            btn_xiugai.Visible = false;
        }

        public xzlymx(DataRow row, int rowindex)
        {
            InitializeComponent();

            //加载所有刀具类型
            djlx.DataSource = Alex.GetList("djlx");
            //加载所有机床编码/名称
            jcbm.DataSource = Alex.GetList("jc");

            djlx.SelectedIndex = -1;
            djgg.SelectedIndex = -1;
            djcd.SelectedIndex = -1;
            djid.SelectedIndex = -1;
            jcbm.SelectedIndex = -1;

            btn_xiugai.Visible = true;

            index = rowindex;

            if (row[DaoJuLingYongMingXi.djlx] != null && row[DaoJuLingYongMingXi.djlx].ToString() != "")
            {
                djlx.SelectedItem = row[DaoJuLingYongMingXi.djlx].ToString();
            }
            if (row[DaoJuLingYongMingXi.djgg] != null && row[DaoJuLingYongMingXi.djgg].ToString() != "")
            {
                djgg.SelectedItem = row[DaoJuLingYongMingXi.djgg].ToString();
            }
            if (row[DaoJuLingYongMingXi.djcd] != null && row[DaoJuLingYongMingXi.djcd].ToString() != "")
            {
                djcd.SelectedItem = row[DaoJuLingYongMingXi.djcd].ToString();
            }
            if (row[DaoJuLingYongMingXi.djid] != null && row[DaoJuLingYongMingXi.djid].ToString() != "")
            {
                djid.SelectedItem = row[DaoJuLingYongMingXi.djid].ToString();
            }

            
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xzccmx_Load(object sender, EventArgs e)
        {
            //加载所有刀具类型
            //djlx.DataSource = Alex.GetList("djlx");
            //sqlstr = "select distinct daojuleixing from daojutemp";
            //djlx.DataSource = SQL.DataReadList(sqlstr);
            //djlx.SelectedIndex = -1;

            //加载所有机床编码/名称
            //jcbm.DataSource = Alex.GetList("jc");
            //sqlstr1 = "select jichuangbianma from jichuang";
            //jcbm.DataSource = SQL.DataReadList(sqlstr1);
            //jcbm.SelectedIndex = -1;
        }

        #region 刀具信息三级联动
        private void djxh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(djlx.SelectedIndex < 0)
            {
                djgg.DataSource = null;
                return;
            }
            else
            {
                sqlstr = string.Format("SELECT DISTINCT {1} FROM {0} WHERE {2} = '{3}'", DaoJuTemp.TableName, DaoJuTemp.guige, DaoJuTemp.leixing, djlx.SelectedItem.ToString().Trim());
                djgg.DataSource = SQL.DataReadList(sqlstr);
                djgg.SelectedIndex = -1;//默认为空
            }            
        }

        private void djgg_SelectedIndexChanged(object sender, EventArgs e)
        {
            //sqlstr = "select daojuid from daojutemp where daojuleixing = '" + djlx.SelectedItem.ToString().Trim() + "'" + " and daojuguige = '" + djgg.SelectedItem.ToString().Trim() + "'";
            //djid.DataSource = SQL.DataReadList(sqlstr);
            //djid.SelectedIndex = 0;//默认选择第一项
            if(djgg.SelectedIndex < 0)
            {
                djid.DataSource = null;
                return;
            }
            else
            {
                djid.DataSource = null;

                sqlstr = string.Format("SELECT dj.{1} FROM {0} dj WHERE dj.{2} = 'S' AND dj.{3} = '{4}' AND dj.{5} = '{6}'", DaoJuTemp.TableName, DaoJuTemp.id, DaoJuTemp.weizhibiaoshi, DaoJuTemp.leixing, djlx.SelectedItem.ToString().Trim(), DaoJuTemp.guige, djgg.SelectedItem.ToString().Trim());

                List<string> list = new List<string>();
                list = SQL.DataReadList(sqlstr);
                if (list.Count == 0)
                {
                    MessageBox.Show("该规格下没有空闲刀具，请装配刀具？", "提示");//是否进行刀具装配
                }
                else
                {
                    djid.DataSource = list;
                }
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

                DJLY form_djccd = (DJLY)this.Owner;
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

        private void jcbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(jcbm.SelectedIndex < 0)
            {
                dth.DataSource = null;
                return;
            }

            sqlstr = string.Format("SELECT jcdjk.{2} FROM {0} jcdjk LEFT JOIN {1} djtp ON CONCAT(djtp.{3},'-', djtp.{4} ) = CONCAT(jcdjk.{5},'-', jcdjk.{2} ) WHERE djtp.{6} IS NULL AND jcdjk.{5} = '{7}'", JiChuangDaoJuKu.TableName, DaoJuTemp.TableName, JiChuangDaoJuKu.dth, DaoJuTemp.weizhibianma, DaoJuTemp.csordth, JiChuangDaoJuKu.jcbm, DaoJuTemp.id, jcbm.SelectedItem.ToString().Trim());
            dth.DataSource = SQL.DataReadList(sqlstr);
            dth.SelectedIndex = -1;
        }

        /// <summary>
        /// 修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xiugai_Click(object sender, EventArgs e)
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
                list.Add(djcd.Text.ToString().Trim());//list[2] 刀具长度
                list.Add(djid.SelectedItem.ToString().Trim());//list[3] 刀具id
                list.Add(jcbm.Text.ToString().Trim());//list[4] 机床编码
                list.Add(dth.Text.ToString().Trim());//list[5] 刀套号
                list.Add(bz.Text.ToString().Trim());//list[6] 备注

                DJLY form_djccd = (DJLY)this.Owner;
                form_djccd.EditLingYongMXbyRowinde(index, list);

                //this.Close();
            }
        }
    }
}
