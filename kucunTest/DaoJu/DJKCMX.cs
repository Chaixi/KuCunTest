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

        private string DanJuBiao = "daojuliushui";
        private string DJID = "";
        private DataGridView dgv = new DataGridView();
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

            Sqlstr = "SELECT dt.daojuleixing AS djlx, COUNT(DISTINCT dt.daojuid) AS sysl FROM daojutemp dt GROUP BY dt.daojuleixing";
            KCTJ.AutoGenerateColumns = false;
            DataSet ds = SQL.getDataSet1(Sqlstr);
            KCTJ.DataSource = ds.Tables[0].DefaultView;

            //对可用数量等于所有数量，但是显示为空的行，进行遍历
            for(int rowindex = 0; rowindex < KCTJ.Rows.Count; rowindex++)
            {
                Sqlstr = "SELECT COUNT(dt.daojuid) FROM daojutemp dt WHERE dt.daojuleixing = '" + KCTJ.Rows[rowindex].Cells["kctj_djlx"].Value.ToString() + "'" + " AND dt.weizhibiaoshi = 'S' ";
                int kysl = Convert.ToInt32(SQL.ExecuteScalar(Sqlstr).ToString());//可用数量

                KCTJ.Rows[rowindex].Cells["kctj_kysl"].Value = kysl.ToString();//赋值

                int sysl = Convert.ToInt32(KCTJ.Rows[rowindex].Cells["kctj_sysl"].Value.ToString());//所有数量

                if (kysl == sysl)//可用数量等于所有数量
                {
                    //KCTJ.Rows[rowindex].Cells["kctj_kysl"].Value = KCTJ.Rows[rowindex].Cells["kctj_sysl"].Value;
                    KCTJ.Rows[rowindex].DefaultCellStyle.BackColor = Color.AliceBlue;
                }
                else if(kysl == 0 )//可用数量为0的情况下，底色变红色警告
                {
                    KCTJ.Rows[rowindex].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    KCTJ.Rows[rowindex].DefaultCellStyle.BackColor = Color.AntiqueWhite;
                }
            }
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
            Sqlstr = string.Format("SELECT * FROM {0} WHERE djlx = '{1}' ORDER BY czsj ASC", DanJuBiao, KCTJ.Rows[e.RowIndex].Cells["kctj_djlx"].Value.ToString());
            CRMX.AutoGenerateColumns = false;
            CRMX.DataSource = (SQL.getDataSet(Sqlstr, DanJuBiao)).Tables[0].DefaultView;

            //int sskysl = 0;//实时可用数量
            int sskysl = Convert.ToInt32(KCTJ.Rows[e.RowIndex].Cells["kctj_sysl"].Value);//实时可用数量,默认数量为车间中所有数量
            
            for (int i = 0; i < CRMX.Rows.Count; i++)
            {
                sskysl = sskysl + Convert.ToInt32(CRMX.Rows[i].Cells["zsl"].Value) - Convert.ToInt32(CRMX.Rows[i].Cells["fsl"].Value);
                CRMX.Rows[i].Cells["crmx_kysl"].Value = sskysl.ToString();
            }
        }

        private void CRMX_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DJCZJL djczjl = new DJCZJL(CRMX.Rows[e.RowIndex].Cells["crmx_djid"].Value.ToString());
            djczjl.ShowDialog();
        }
    }
}
