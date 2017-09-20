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
    public partial class DJKCMX : Form
    {
        #region 全局变量
        private MySql SQL = new MySql();
        private string Sqlstr = "";
        private BaseAlex Alex = new BaseAlex();
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private string DanJuBiao = "daojuliushui";
        private string DJID = "";
        private DataGridView dgv = new DataGridView();

        private DataTable kcmx_db = new DataTable();

        private int time_count;
        #endregion

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DJKCMX()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载，默认值和流水记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJCZJL_Load(object sender, EventArgs e)
        {
            //加载表1，库存统计表
            //Sqlstr = "SELECT dt.daojuleixing AS djlx, COUNT(DISTINCT dt.daojuid) AS sysl, COUNT(dt.daojuleixing) + SUM(d.zsl) - SUM(d.fsl) AS kysl FROM daojutemp dt LEFT JOIN daojuliushui d ON dt.daojuid = d.djid GROUP BY dt.daojuleixing";

            //窗体自适应
            asc.controllInitializeSize(this);

            //计时归零
            time_count = 0;

            //刀具类型下所有刀具数量
            Sqlstr = "SELECT dt.daojuleixing AS djlx, COUNT(DISTINCT dt.daojuid) AS sysl FROM daojutemp dt GROUP BY dt.daojuleixing";
            dgv_KCTJ.AutoGenerateColumns = false;
            DataSet ds = SQL.getDataSet1(Sqlstr);
            kcmx_db = ds.Tables[0];
            dgv_KCTJ.DataSource = kcmx_db.DefaultView;
            
            //计算当前可用数量
            kcmx_db.Columns.Add("kysl", typeof(string));
            kysl_Calculation();
            Refresh_kcmxTable();
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            //Sqlstr = string.Format("SELECT * FROM {0} WHERE djlx LIKE '%{1}%' AND djgg LIKE '%{2}%' AND djid LIKE '%{3}%' ORDER BY czsj DESC", DanJuBiao, djlxCX.Text.ToString().Trim(), kyslCX.Text.ToString().Trim(), djidCX.Text.ToString().Trim());
            //DataSet ds = SQL.getDataSet(Sqlstr, DanJuBiao);

            //liushuibiao.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 点击刀具类型可查看此类刀具的出入明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KCTJ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                //加载流水表中此类型所有刀具操作记录
                Sqlstr = string.Format("SELECT * FROM {0} WHERE djlx = '{1}' ORDER BY czsj ASC", DanJuBiao, dgv_KCTJ.Rows[e.RowIndex].Cells["kctj_djlx"].Value.ToString());
                dgv_CRMX.AutoGenerateColumns = false;
                dgv_CRMX.DataSource = (SQL.getDataSet(Sqlstr, DanJuBiao)).Tables[0].DefaultView;

                //int sskysl = 0;//当时可用数量
                //int sskysl = Convert.ToInt32(dgv_KCTJ.Rows[e.RowIndex].Cells["kctj_sysl"].Value);//当时可用数量,默认数量为车间中所有数量。问题在于这是当前可用数量不是！当时！可用数量

                //for (int i = 0; i < dgv_CRMX.Rows.Count; i++)
                //{
                //    sskysl = sskysl + Convert.ToInt32(dgv_CRMX.Rows[i].Cells["zsl"].Value) - Convert.ToInt32(dgv_CRMX.Rows[i].Cells["fsl"].Value);
                //    dgv_CRMX.Rows[i].Cells["crmx_kysl"].Value = sskysl.ToString();
                //}
            }            
        }

        /// <summary>
        /// 出入明细双击查看具体单把刀具的操作记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CRMX_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            DJCZJL djczjl = new DJCZJL(dgv_CRMX.Rows[e.RowIndex].Cells["crmx_djid"].Value.ToString());
            djczjl.ShowDialog();
        }

        /// <summary>
        /// 窗口自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJKCMX_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);   
        }

        /// <summary>
        /// 当窗体在选项卡中打开时，关闭窗体则关闭相应的选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJKCMX_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Parent != null)
            {
                MainForm mfr = (MainForm)this.Parent.FindForm();
                mfr.CloseTab(this.Name);
            }
        }

        /// <summary>
        /// 计算该类型刀具的可用数量
        /// </summary>
        private void kysl_Calculation()
        {
            for (int rowindex = 0; rowindex < dgv_KCTJ.Rows.Count; rowindex++)
            {
                //当前可用数量
                Sqlstr = "SELECT COUNT(dt.daojuid) FROM daojutemp dt WHERE dt.daojuleixing = '" + dgv_KCTJ.Rows[rowindex].Cells["kctj_djlx"].Value.ToString().Trim() + "'" + " AND dt.weizhibiaoshi = 'S' ";
                int kysl = Convert.ToInt32(SQL.ExecuteScalar(Sqlstr).ToString());

                kcmx_db.Rows[rowindex]["kysl"] = kysl.ToString();
            }
        }

        /// <summary>
        /// 刷新库存明细表,颜色的突出显示
        /// </summary>
        public void Refresh_kcmxTable()
        {
            //对可用数量等于所有数量，但是显示为空的行，进行遍历
            for (int rowindex = 0; rowindex < dgv_KCTJ.Rows.Count; rowindex++)
            {
                int sysl = Convert.ToInt32(dgv_KCTJ.Rows[rowindex].Cells["kctj_sysl"].Value.ToString());//所有数量
                int kysl = Convert.ToInt32(dgv_KCTJ.Rows[rowindex].Cells["kctj_kysl"].Value.ToString());//可用数量

                if (kysl == sysl)//可用数量等于所有数量
                {
                    //KCTJ.Rows[rowindex].Cells["kctj_kysl"].Value = KCTJ.Rows[rowindex].Cells["kctj_sysl"].Value;
                    dgv_KCTJ.Rows[rowindex].DefaultCellStyle.BackColor = Color.AliceBlue;
                }
                else if (kysl == 0)//可用数量为0的情况下，底色变红色警告
                {
                    dgv_KCTJ.Rows[rowindex].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    dgv_KCTJ.Rows[rowindex].DefaultCellStyle.BackColor = Color.AntiqueWhite;
                }

                time_count = 0;//重置时间值
                timer1.Start();
            }
        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            if(time_count >= 3)
            {
                timer1.Stop();
                Refresh_kcmxTable();               
            }
            else
            {
                MessageBox.Show("禁止重复刷新，请稍后重试！");
            }
        }

        /// <summary>
        /// 计时器每过一秒，计数值+1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            time_count++;
        }
    }
}
