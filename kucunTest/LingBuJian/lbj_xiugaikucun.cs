using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kucunTest.LingBuJian
{
    public partial class lbj_xiugaikucun : Form
    {
        #region 全局变量

        string SqlStr_ls = "";
        string SqlStr_kc = "";
        MySql SQL = new MySql();

        //零部件表
        string lbjbiao = "jichuxinxi";
        string lbjbiao_lbjmc = "daojuid";
        string lbjbiao_lbjgg = "daojuguige";
        string lbjbiao_lbjxh = "daojuxinghao";
        string lbjbiao_djgbm = "weizhi";
        string lbjbiao_jtwz = "cengshu";
        string lbjbiao_kcsl = "kcsl";
        string lbjbiao_dw = "danwei";

        string liushuibiao = "lbj_liushui";
        string DHZD = "danhao";

        #endregion 全局变量结束

        public lbj_xiugaikucun(DataRow dr)
        {
            InitializeComponent();

            LBJMC.Text = dr["lbjmc"].ToString();
            LBJGG.Text = dr["lbjgg"].ToString();
            LBJXH.Text = dr["lbjxh"].ToString();
            KCWZ.Text = dr["kcwz"].ToString();
            KCSL.Text = dr["kcsl"].ToString();
            DW1.Text = dr["dw"].ToString();
            DW2.Text = DW1.Text;

            XGSL.Focus();
        }

        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_comfirm_Click(object sender, EventArgs e)
        {
            string tishi = "";

            if (XGSL.Text != "" && XGSL != null)
            {
                //数据预处理
                string lbjmc = LBJMC.Text;
                string lbjgg = LBJGG.Text;
                string lbjxh = LBJXH.Text;
                string kcwz = KCWZ.Text;
                string kcwz_wz = kcwz.Substring(0, kcwz.Length - 4);//还原库存位置
                string kcwz_cs = kcwz.Substring(kcwz.Length - 2);
                int kcsl = Convert.ToInt16(KCSL.Text);
                string dw = DW1.Text;
                string beizhu = BZ.Text;
                string jbr = JBR.Text;
                int xgsl = Convert.ToInt16(XGSL.Text);

                if (rb_add.Checked)//库存增加
                {
                    //存入流水表
                    SqlStr_ls = string.Format("INSERT INTO {0}(danhao, dhlx, lbjmc, lbjgg, lbjxh, djgbm, jtwz, zsl, fsl, dskykc, dw, czsj, jbr, bz) VALUES('{1}', '库存修改', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '0', '{8}', '{9}', '{10}', '{11}', '{12}')", liushuibiao, "", lbjmc, lbjgg, lbjxh, kcwz_wz, kcwz_cs, xgsl, kcsl, dw, DateTime.Now, jbr, beizhu);

                    //更新库存表（jichuxinxi）
                    SqlStr_kc = string.Format("UPDATE {0} SET {1} = {1} + {2} WHERE {3}='{4}' AND {5}='{6}' AND {7}='{8}' AND {9}='{10}'", lbjbiao, lbjbiao_kcsl, xgsl, lbjbiao_lbjmc, lbjmc, lbjbiao_lbjxh, lbjxh, lbjbiao_djgbm, kcwz_wz, lbjbiao_jtwz, kcwz_cs);
                }
                else//库存减少
                {
                    //存入流水表
                    SqlStr_ls = string.Format("INSERT INTO {0}(danhao, dhlx, lbjmc, lbjgg, lbjxh, djgbm, jtwz, zsl, fsl, dskykc, dw, czsj, jbr, bz) VALUES('{1}', '库存修改', '{2}', '{3}', '{4}', '{5}', '{6}', '0', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", liushuibiao, "", lbjmc, lbjgg, lbjxh, kcwz_wz, kcwz_cs, xgsl, kcsl, dw, DateTime.Now, jbr, beizhu);

                    //更新库存表（jichuxinxi）
                    SqlStr_kc = string.Format("UPDATE {0} SET {1} = {1} - {2} WHERE {3}='{4}' AND {5}='{6}' AND {7}='{8}' AND {9}='{10}'", lbjbiao, lbjbiao_kcsl, xgsl, lbjbiao_lbjmc, lbjmc, lbjbiao_lbjxh, lbjxh, lbjbiao_djgbm, kcwz_wz, lbjbiao_jtwz, kcwz_cs);
                }

                //数据库操作
                int row = 0;
                row = SQL.ExecuteNonQuery(SqlStr_ls);
                row = SQL.ExecuteNonQuery(SqlStr_kc);                
            }
            else
            {
                tishi = "请填写要修改的数量！";
                MessageBox.Show(tishi, "提示");
                XGSL.Focus();
            }

            if (tishi == "")
            {
                tishi = "更新成功！";
                MessageBox.Show(tishi, "提示");
                this.Close();
            }

        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 数据验证，只能输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XGSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }
        }
    }
}
