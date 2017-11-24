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
    public partial class chaixiedaoju : Form
    {
        public chaixiedaoju()
        {
            InitializeComponent();
        }

        #region 全局变量
        MySql SQL = new MySql();
        BaseAlex Alex = new BaseAlex();

        string Sqlstr = "";
        string Sqlstr1 = "";

        string DJLX = "";
        string DJGG = "";
        string DJID = "";
        string DJXH = "";
        string DaoJuLiuShui = "daojuliushui";
        #endregion 全局变量结束

        /// <summary>
        /// 窗体构造函数
        /// </summary>
        /// <param name="daojulx"></param>
        /// <param name="daojugg"></param>
        public chaixiedaoju(string daojulx, string daojugg, string daojuid,string daojuxh)
        {
            InitializeComponent();

            DJLX = daojulx;
            DJGG = daojugg;
            DJID = daojuid;
            DJXH = daojuxh;
           
        }

        private void chaixiedaoju_Load(object sender, EventArgs e)
        {
            daojuleixing.Text = DJLX;
            daojuguige.Text = DJGG;
            daojuid.Text = DJID;
            daojuxinghao.Text = DJXH;

            Sqlstr = string.Format("SELECT gl.lbjmc, gl.lbjxh, gl.lbjgg, gl.sl, gl.dw, lbj.kcsl FROM daojulingbujian gl LEFT JOIN jichuxinxi lbj ON gl.lbjxh = lbj.daojuxinghao WHERE gl.djxh = '{0}'", DJXH);
            DataSet ds = SQL.getDataSet1(Sqlstr);
            lbjmx.AutoGenerateColumns = false;
            lbjmx.DataSource = ds.Tables[0].DefaultView;

            if (lbjmx.Rows.Count > 0)
            {
                for (int i = 0; i < lbjmx.Rows.Count; i++)
                {
                    if (lbjmx.Rows[i].Cells["kcsl"].Value.ToString() == null || lbjmx.Rows[i].Cells["kcsl"].Value.ToString() == "")
                    {
                        continue;
                    }
                    else if (Convert.ToInt16(lbjmx.Rows[i].Cells["kcsl"].Value.ToString()) < Convert.ToInt16(lbjmx.Rows[i].Cells["sl"].Value.ToString()))
                    {
                        lbjmx.Rows[i].DefaultCellStyle.BackColor = Color.OrangeRed;
                        //ZP = false;
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //删除刀具temp表中的刀具
            Sqlstr = string.Format("DELETE FROM daojutemp WHERE daojuid = '" + daojuid.Text.ToString() + "'");
            int row = SQL.ExecuteNonQuery(Sqlstr);

            string dskysl = "";//此类型刀具的当时可用数量！！！当时可用数量为单据操作后的刀具可用数量
            
            //查询此类型刀具当时可用数量, 刀具拆卸可用数量不变，直接为daojutemp表查出来的数量，因为先删除后查询
            dskysl = Alex.Count_djsl(daojuleixing.Text.ToString().Trim(), "kysl").ToString();

            //存入刀具流水表
            Sqlstr = string.Format("INSERT INTO {0}(dhlx, djlx, djgg, djid, zsl, fsl, dskysl, czsj) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", DaoJuLiuShui, "刀具拆卸", daojuleixing.Text, daojuguige.Text, daojuid.Text, "0", "1", dskysl, DateTime.Now);
            row = SQL.ExecuteNonQuery(Sqlstr);

            //更新相应零部件库存信息并存入零部件流水表
            if (lbjmx.Rows.Count > 0)
            {
                for (int i = 0; i < lbjmx.Rows.Count; i++)
                {
                    int xsl = Convert.ToInt16(lbjmx.Rows[i].Cells["kcsl"].Value.ToString()) + Convert.ToInt16(lbjmx.Rows[i].Cells["sl"].Value.ToString());
                    Sqlstr = string.Format("UPDATE jichuxinxi SET kcsl = '{0}' WHERE daojuxinghao = '{1}'", xsl.ToString(), lbjmx.Rows[i].Cells["lbjxh"].Value.ToString());
                    row = SQL.ExecuteNonQuery(Sqlstr);

                }
            }
            if (lbjmx.Rows.Count > 0)
            {
                for (int i = 0; i < lbjmx.Rows.Count; i++)
                {

                    int sl = Convert.ToInt16(lbjmx.Rows[i].Cells["sl"].Value.ToString());
                    Sqlstr1 = "INSERT INTO lbj_liushui(dhlx, lbjmc, lbjgg, lbjxh, zsl, fsl, czsj) VALUES( '拆卸退还' , '" + lbjmx.Rows[i].Cells["lbjmc"].Value.ToString() + "' , '" + lbjmx.Rows[i].Cells["lbjgg"].Value.ToString() + "' , '" + lbjmx.Rows[i].Cells["lbjxh"].Value.ToString() + "' , '" + sl.ToString() + "','0','" + DateTime.Now + "')";
                    SQL.ExecuteNonQuery(Sqlstr1);
                }
            }



            MessageBox.Show("拆卸成功！", "提示");
            this.Close();
            this.DialogResult = DialogResult.OK;
      
    }
    }
}
