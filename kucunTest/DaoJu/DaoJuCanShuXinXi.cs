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
    public partial class DaoJuCanShuXinXi : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";

        string ID = "";//刀具ID
        string daojubiao = "daojutemp";
        string jichucanshubiao = "jichucanshu";
        string celiangcanshubiao = "celiangcanshu";
        string guanlianbiao = "daojulingbujian";

        bool TextChanged = false;
        #endregion

        public DaoJuCanShuXinXi(string id)
        {
            InitializeComponent();

            ID = id;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DaoJuCanShuXinXi_Load(object sender, EventArgs e)
        {
            TextChanged = false;

            //查询刀具表中对应刀具类型和刀具规格
            Sqlstr = string.Format("SELECT daojuleixing, daojuguige FROM {0} WHERE daojuid = '{1}'", daojubiao, ID);
            DataTable db1 = SQL.getDataSet(Sqlstr, daojubiao).Tables[0];
            //赋值
            djlx.Text = db1.Rows[0]["daojuleixing"].ToString();
            djgg.Text = db1.Rows[0]["daojuguige"].ToString();
            djid.Text = ID;

            //查询基础参数表中刀具基础信息
            Sqlstr = string.Format("SELECT csdm, csz FROM {0} WHERE ssfm = '{1}'", jichucanshubiao , ID);
            DataTable db2 = SQL.getDataSet(Sqlstr, jichucanshubiao).Tables[0];
            //遍历基础参数
            foreach (Control c in grp_jc.Controls)
            {
                if (c is TextBox)
                {
                    if (db2.Rows.Count <= 0)
                    {
                        c.Text = "";
                    }
                    else
                    {
                        for (int i = 0; i < db2.Rows.Count; i++)
                        {
                            if (db2.Rows[i]["csdm"].ToString() == c.Name)
                            {
                                c.Text = db2.Rows[i]["csz"].ToString();
                                break;
                            }
                        }
                    }
                }
            }

            //查询刀具测量信息
            Sqlstr = string.Format("SELECT * FROM {0} WHERE djid = '{1}' ORDER BY clsj ASC", celiangcanshubiao, ID);
            DataTable db3 = SQL.getDataSet(Sqlstr, celiangcanshubiao).Tables[0];
            //赋值
            cp1.Text = db3.Rows[0]["djzjxddsl"].ToString();
            cp2.Text = db3.Rows[0]["dqgjbmccd"].ToString();
            cp3.Text = db3.Rows[0]["yqgjbmccd"].ToString();
            cp4.Text = db3.Rows[0]["djsysm"].ToString();
            cp5.Text = db3.Rows[0]["djbjsjz"].ToString();
            cp6.Text = db3.Rows[0]["djcdsjz"].ToString();
            cp7.Text = db3.Rows[0]["djzpj"].ToString();
            cp8.Text = db3.Rows[0]["djfpj"].ToString();
            cp9.Text = db3.Rows[0]["djyhbj"].ToString();
            cp10.Text = db3.Rows[0]["djdmtd"].ToString();
            cp11.Text = db3.Rows[0]["djjxtd"].ToString();

            //查询刀具组成零部件信息
            //Sqlstr = string.Format("SELECT lbjmc, lbjxh, lbjgg, sl, dw FROM {0} t1 LEFT JOIN {1} t2 ON t1.djxh = t2.daojuxinghao WHERE t2.daojuid = '{2}'", guanlianbiao, daojubiao, ID);
            //lingbujianzucheng.AutoGenerateColumns = false;
            //lingbujianzucheng.DataSource = SQL.getDataSet1(Sqlstr).Tables[0].DefaultView;

        }

        /// <summary>
        /// 保存数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(TextChanged)
            {
                Sqlstr = string.Format("INSERT INTO {0}(djid, clsj, djzjxddsl, dqgjbmccd, yqgjbmccd, djsysm, djbjsjz, djcdsjz, djzpj, djfpj, djyhbj, djdmtd, djjxtd) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}')", celiangcanshubiao, ID, DateTime.Now, cp1.Text, cp2.Text, cp3.Text, cp4.Text, cp5.Text, cp6.Text, cp7.Text, cp8.Text, cp9.Text, cp10.Text, cp11.Text);
                int row1 = SQL.ExecuteNonQuery(Sqlstr);
                if (row1 == 1)
                {
                    MessageBox.Show("测量数据保存成功！");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("还未对测量数据做任何更改！");
            }
            
        }

        /// <summary>
        /// 获取测量数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 判断测量数据是否有过更改，所有textbox的textchanged关联到此函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextChanged = true;
        }
    }
}
