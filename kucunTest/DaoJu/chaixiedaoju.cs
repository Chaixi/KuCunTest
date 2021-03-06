﻿using System;
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
        #region 全局变量
        MySql SQL = new MySql();
        BaseAlex Alex = new BaseAlex();

        string Sqlstr = "";
        string Sqlstr1 = "";

        //全局刀具信息
        string DJLX = "";
        string DJGG = "";
        string DJID = "";
        string DJXH = "";
        string DaoJuLiuShui = "daojuliushui";
        #endregion 全局变量结束

        /// <summary>
        /// 构造函数
        /// </summary>
        public chaixiedaoju()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体构造函数，根据刀具类型、刀具规格、刀具ID和刀具型号
        /// </summary>
        /// <param name="daojulx">刀具类型</param>
        /// <param name="daojugg">刀具规格</param>
        /// <param name="daojuid">刀具ID</param>
        /// <param name="daojuxh">刀具型号</param>
        public chaixiedaoju(string daojulx, string daojugg, string daojuid, string daojuxh)
        {
            InitializeComponent();

            //填充数据
            DJLX = daojulx;
            DJGG = daojugg;
            DJID = daojuid;
            DJXH = daojuxh;
        }

        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chaixiedaoju_Load(object sender, EventArgs e)
        {
            daojuleixing.Text = DJLX;
            daojuguige.Text = DJGG;
            daojuid.Text = DJID;
            daojuxinghao.Text = DJXH;

            Sqlstr = string.Format("SELECT gl.lbjmc, gl.lbjxh, gl.lbjgg, gl.sl, gl.dw, lbj.kcsl, CONCAT(lbj.weizhi,'--',lbj.cengshu) AS kcwz FROM daojulingbujian gl LEFT JOIN jichuxinxi lbj ON gl.lbjxh = lbj.daojuxinghao WHERE gl.djxh = '{0}'", DJXH);
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

        /// <summary>
        /// 取消拆卸按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 拆卸刀具按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //删除刀具temp表中的刀具
            Sqlstr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", DaoJuTemp.TableName, DaoJuTemp.id, daojuid.Text.ToString());
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
                    Sqlstr = string.Format("UPDATE jichuxinxi SET kcsl = '{0}' WHERE daojuxinghao = '{1}' AND CONCAT(weizhi,'--',cengshu) = '{2}'", xsl.ToString(), lbjmx.Rows[i].Cells["lbjxh"].Value.ToString(), lbjmx.Rows[i].Cells["kcwz"].Value.ToString());
                    row = SQL.ExecuteNonQuery(Sqlstr);
                }
            }
            if (lbjmx.Rows.Count > 0)
            {
                for (int i = 0; i < lbjmx.Rows.Count; i++)
                {
                    //数据预处理
                    string lbjkcwz = lbjmx.Rows[i].Cells["kcwz"].Value.ToString();
                    string lbjwz = lbjkcwz.Substring(0, lbjkcwz.Length - 4);
                    string lbjcs = lbjkcwz.Substring(lbjkcwz.Length - 2);

                    int sl = Convert.ToInt16(lbjmx.Rows[i].Cells["sl"].Value.ToString());
                    Sqlstr1 = "INSERT INTO lbj_liushui(dhlx, lbjmc, lbjgg, lbjxh, djgbm, jtwz, zsl, fsl, dskykc, dw, czsj, bz) VALUES( '拆卸退还' , '" + lbjmx.Rows[i].Cells["lbjmc"].Value.ToString() + "' , '" + lbjmx.Rows[i].Cells["lbjgg"].Value.ToString() + "' , '" + lbjmx.Rows[i].Cells["lbjxh"].Value.ToString() + "' , '" + lbjwz + "' , '" + lbjcs + "' , '" + sl.ToString() + "','0','" + lbjmx.Rows[i].Cells["kcsl"].Value.ToString() + "','" + lbjmx.Rows[i].Cells["dw"].Value.ToString() + "','" + DateTime.Now + "' , '" + daojuid.Text + "')";
                    SQL.ExecuteNonQuery(Sqlstr1);
                }
            }

            MessageBox.Show("拆卸成功！", "提示");

            //记录系统日志
            Program.WriteLog("拆卸刀具", string.Format("成功拆卸刀具ID为{0}的刀具。", daojuid.Text.ToString()));

            this.Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
