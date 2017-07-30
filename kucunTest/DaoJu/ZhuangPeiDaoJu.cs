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
using NPinyin;

namespace kucunTest.DaoJu
{
    public partial class zhuangpeidaoju : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";

        BaseAlex Alex = new BaseAlex();

        string daojulingbujian = "daojulingbujian";//刀具零部件关联表
        string djlbj_djxh = "djxh";
        string djlbj_lbjmc = "lbjmc";
        string djlbj_lbjxh = "lbjxh";
        string djlbj_lbjgg = "lbjgg";
        string djlbj_sl = "sl";
        string djlbj_dw = "dw";

        string DaoJuIDBiao = "daojutemp";//刀具id表
        string djidb_djlx = "daojuleixing";
        string djidb_djgg = "daojuguige";
        string djidb_djxh = "daojuxinghao";
        string djidb_djid = "daojuid";

        string DaoJuBiao = "daoju";//刀具类型表
        string djb_djlx = "djlx";
        string djb_djgg = "djgg";
        string djb_djxh = "djxh";

        string DaoJuLiuShui = "daojuliushui";
        //string djls_dhlx = "dhlx";
        //string djls_djlx = "djlx";
        //string djls_djgg = "djgg";
        //string djls_djid = "djid";
        //string djls_zsl = "zsl";

        string DJLX = "";
        string DJGG = "";
        string DJXH = "";

        bool ZP = true;
        #endregion 全局变量结束

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        /// <param name="daojulx"></param>
        /// <param name="daojugg"></param>
        public zhuangpeidaoju(string daojulx, string daojugg, string daojuxh)
        {
            InitializeComponent();

            DJLX = daojulx;
            DJGG = daojugg;
            DJXH = daojuxh;

            //加载所有刀具类型
            Sqlstr = string.Format("SELECT DISTINCT {0} FROM {1}", djb_djlx, DaoJuBiao);
            djlx.DataSource = SQL.DataReadList(Sqlstr);

        }
        
        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zhuangpeidaoju_Load(object sender, EventArgs e)
        {
            djlx.SelectedItem = DJLX;
            djgg.SelectedItem = DJGG;
        }

        /// <summary>
        /// 刀具类型更改，刀具规格相应更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void djxh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sqlstr = string.Format("SELECT {0} FROM {1} WHERE {2} = '{3}'", djb_djgg, DaoJuBiao, djb_djlx, djlx.Text);
            djgg.DataSource = SQL.DataReadList(Sqlstr);
        }

        /// <summary>
        /// datagridview事件，绘制行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbjmx_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(lbjmx, e);
        }

        /// <summary>
        /// 刀具规格更改，加载相应组成零部件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void djgg_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sqlstr = string.Format("SELECT {0} FROM {1} WHERE {2} = '{3}' AND {4} = '{5}'", djb_djxh, DaoJuBiao, djb_djlx, djlx.Text, djb_djgg, djgg.Text);
            DJXH = SQL.ExecuteScalar(Sqlstr).ToString();
            //DJXH = SQL.getDataSet(Sqlstr, DaoJuBiao).Tables[0].Rows[0][djb_djxh].ToString();

            Sqlstr = string.Format("SELECT gl.lbjmc, gl.lbjxh, gl.lbjgg, gl.sl, gl.dw, lbj.sl AS kcsl FROM daojulingbujian gl LEFT JOIN lbj_temp lbj ON gl.lbjxh = lbj.lbjxh WHERE gl.djxh = '{0}'", DJXH);
            DataSet ds = SQL.getDataSet1(Sqlstr);
            lbjmx.AutoGenerateColumns = false;
            lbjmx.DataSource = ds.Tables[0].DefaultView;

            if(lbjmx.Rows.Count > 0)
            {
                for (int i = 0; i < lbjmx.Rows.Count; i++)
                {
                    if(lbjmx.Rows[i].Cells["kcsl"].Value.ToString() == null || lbjmx.Rows[i].Cells["kcsl"].Value.ToString() == "")
                    {
                        continue;
                    }
                    else if(Convert.ToInt16(lbjmx.Rows[i].Cells["kcsl"].Value.ToString()) < Convert.ToInt16(lbjmx.Rows[i].Cells["sl"].Value.ToString()))
                    {
                        lbjmx.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                        ZP = false;
                    }
                }
            }
            
        }

        /// <summary>
        /// 生成刀具ID按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            djid.Text = NewDJID(djlx.Text);
        }

        /// <summary>
        /// 装配刀具按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(ZP)
            {
                if (CheckData() == 1)
                {
                    //查询原始寿命
                    string djyssm = "";
                    Sqlstr = string.Format("SELECT csz FROM jichucanshu WHERE ssfm = '{0}' AND csdm = 'djyssm'", DJXH);
                    if (Alex.CunZai("jichucanshu", " ssfm = '" + DJXH + "' AND csdm = 'djyssm'") != 0)
                    {
                        djyssm = SQL.ExecuteScalar(Sqlstr).ToString();
                    }
                    else
                    {
                        MessageBox.Show("请先在刀具类型管理界面为" + DJXH + "设置刀具原始寿命！");
                        return;
                    }

                    //新刀具id存入刀具ID表,并更新刀具寿命和位置信息
                    Sqlstr = string.Format("INSERT INTO {0}({1}, {2}, {3}, {4}, weizhi, cengshu, weizhibiaoshi, type, kcsl, daojushouming) VALUES('{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}')", DaoJuIDBiao, djidb_djid, djidb_djlx, djidb_djgg, djidb_djxh, djid.Text, djlx.Text, djgg.Text, DJXH, dgbm.Text, jtwz.Text, "S", "刀具", "1", djyssm);
                    int row = SQL.ExecuteNonQuery(Sqlstr);

                    //存入刀具流水表
                    Sqlstr = string.Format("INSERT INTO {0}(dhlx, djlx, djgg, djid, zsl, fsl, wzbm, jtwz, czsj) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", DaoJuLiuShui, "刀具装配", djlx.Text, djgg.Text, djid.Text, "1", "0", dgbm.Text, jtwz.Text, DateTime.Now);
                    row = SQL.ExecuteNonQuery(Sqlstr);

                    //更新相应零部件库存信息
                    if (lbjmx.Rows.Count > 0)
                    {
                        for (int i = 0; i < lbjmx.Rows.Count; i++)
                        {
                            int xsl = Convert.ToInt16(lbjmx.Rows[i].Cells["kcsl"].Value.ToString()) - Convert.ToInt16(lbjmx.Rows[i].Cells["sl"].Value.ToString());
                            Sqlstr = string.Format("UPDATE lbj_temp SET sl = '{0}' WHERE lbjxh = '{1}'", xsl.ToString(), lbjmx.Rows[i].Cells["lbjxh"].Value.ToString());
                            row = SQL.ExecuteNonQuery(Sqlstr);
                        }
                    }

                    MessageBox.Show("装配成功！", "提示");
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("零部件库存不足，无法装配！", "警告");

            }       
        }

        /// <summary>
        /// 取消装配按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 自动生成刀具ID
        /// </summary>
        /// <param name="djxh"></param>
        /// <returns></returns>
        private string NewDJID(string newid_djlx)
        {
            //刀具类型拼音首字母
            newid_djlx = Pinyin.ConvertEncoding(newid_djlx, Encoding.UTF8, Encoding.GetEncoding("GB2312"));
            string lx = Pinyin.GetInitials(newid_djlx);
            int count;//记录数据库当天已有单号数量

            Sqlstr = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} = '{2}'", DaoJuIDBiao, djidb_djlx, djlx.Text);
            count = Convert.ToInt32(SQL.ExecuteScalar(Sqlstr));

            string id = lx + "-" + (count + 1).ToString("0000");

            return id;
        }

        /// <summary>
        /// 数据检查
        /// </summary>
        /// <returns></returns>
        private int CheckData()
        {
            int i = 1;
            string tishi = "";

            if(djid.Text == "")
            {
                tishi = "请先生成刀具ID！";
                i = 0;
            }
            else if(dgbm.Text == "" || jtwz.Text == "")
            {
                tishi = "请选择刀具位置！";
                i = 0;
            }

            if(i == 0)
            {
                MessageBox.Show(tishi, "提示");
            }
            return i;
        }
    }
}
