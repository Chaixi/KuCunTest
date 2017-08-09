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
    public partial class DJZZLY : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";
        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();//窗口自适应类

        int dj_HJ = 0;//刀具合计数量
        int lbj_HJ = 0;//零部件合计数量

        DataSet lymx_ds = new DataSet();
        DataTable lymx_db = new DataTable();

        string danjubiao = "daojulingyong";
        string mingxibiao = "daojulingyongmingxi";
        string liushuibiao = "daojuliushui";
        string DHZD = "chucangdanhao";
        #endregion

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DJZZLY()
        {
            InitializeComponent();

            danhao.Text = Alex.DanHao("DJCC");//自动生成单号,按领用单据生成单号
            LYRQ.Value = DateTime.Now;
            LYBZ.SelectedIndex = 0;
            JBR.SelectedIndex = 0;
            djslhj.Text = dj_HJ.ToString();
            lbjslhj.Text = lbj_HJ.ToString();

            lingyongmingxi.AutoGenerateColumns = false;//禁止自动生成列
            lbjqd.AutoGenerateColumns = false;//禁止自动生成列
        }

        /// <summary>
        /// 构造函数重写,加载历史记录
        /// </summary>
        /// <param name="dh">单号</param>
        public DJZZLY(string dh)
        {

        }
        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJZZLY_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);//记录窗体及控件初始大小，以便自适应
        }

        #region 明细部分
        /// <summary>
        /// 列表绘制序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lingyongmingxi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(lingyongmingxi, e);
        }

        /// <summary>
        /// 列表绘制序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbjqd_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(lbjqd, e);
        }

        /// <summary>
        /// 明细新增刀具按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// AddData函数，向datagridview中增加一行数据
        /// </summary>
        /// <param name="list">子窗体传输过来的list值</param>
        public void AddData(List<string> list)
        {
            if (lingyongmingxi.DataSource == null)//新单据，未绑定数据源
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(lingyongmingxi);

                row.Cells[0].Value = list[0];//刀具类型
                row.Cells[1].Value = list[1];//刀具规格
                row.Cells[2].Value = list[2];//刀具长度
                row.Cells[3].Value = list[3];//刀具id
                row.Cells[4].Value = "1";//数量
                row.Cells[5].Value = list[4];//机床编码
                row.Cells[6].Value = list[5];//刀套号
                row.Cells[7].Value = list[6];//备注

                lingyongmingxi.Rows.Add(row);
            }
            else//暂存的单据，领用明细datagridview已经绑定数据源
            {
                //lingyongmingxi.DataSource = null;
                //lingyongmingxi.Rows.Add(row);

                DataRow rowrow = lymx_db.NewRow();

                rowrow["daojuleixing"] = list[0];//刀具类型
                rowrow["daojuguige"] = list[1];//刀具规格
                rowrow["changdu"] = list[2];//刀具长度
                rowrow["daojuid"] = list[3];//刀具id
                rowrow["shuliang"] = "1";//数量
                rowrow["jichuangbianma"] = list[4];//机床编码
                rowrow["daotaohao"] = list[5];//刀套号
                rowrow["beizhu"] = list[6];//备注

                lymx_db.Rows.Add(rowrow);
            }

            dj_HJ++;//合计数量加一
            djslhj.Text = dj_HJ.ToString();//更新合计数量
        }

        /// <summary>
        /// 明细删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

        }

        #endregion 明细部分结束

        #region 按钮部分                
        /// <summary>
        /// 保存单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 确认单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 打印单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void print_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 删除单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion 按钮部分结束

        /// <summary>
        /// 当窗体在选项卡中打开时，关闭窗体则关闭相应的选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJZZLY_FormClosed(object sender, FormClosedEventArgs e)
        {            
            if(this.Parent != null)
            {
                MainForm mfr = (MainForm)this.Parent.FindForm();
                mfr.CloseTab(this.Name);
            }
        }
    }
}
