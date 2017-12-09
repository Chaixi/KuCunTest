using kucunTest.BaseClasses;
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
    public partial class DJGHHistory : Form
    {
        #region 全局变量
        private MySql SQL = new MySql();
        private string SqlStr = "";

        private BaseAlex Alex = new BaseAlex();
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private string danjubiao = "";//要查询的单据表
        private string mingxibiao = "";//对应的明细表

        private string TYPE = "";//记录单据类型
        private string DH = "";//记录单据的单号字段
        private string RQ = "";//记录操作日期字段
        private string BZ = "";//记录班组字段,自定义查询1
        private string SB = "";//记录设备字段，自定义查询2
        private string GX = "";//记录工序字段，自定义查询3
        private string Cells = "";//记录单据状态

        private DataGridView LS_dgv = new DataGridView();//历史记录表
        private DataGridView MX_dgv = new DataGridView();//明细表

        #endregion

        public DJGHHistory()
        {
            InitializeComponent();

            string type = "DJGH";
            TYPE = type;
            danjubiao = DaoJuGengHuan.TableName;
            mingxibiao = DaoJuGengHuan.TableName;//在点击更换单号时可用到
            LS_dgv = LS_djgh;
            DH = "danhao";
            RQ = "sqsj";
            BZ = "sqbz";
            SB = "sqsb";
            GX = "jglj";
            Cells = "LS_djgh_djzt";

            Init();//窗体初始化
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <param name="type"></param>
        private void Init()
        {
            this.Name = "DJGH";//界面显示字段名称更新
            this.Text = "刀具更换单据记录";
            label1.Text = "刀具更换记录";

            label2.Text = "更换单号：";//查询部分
            label7.Text = "申请班组：";
            label8.Text = "申请设备：";
            label9.Text = "加工零件：";

            NewBtn.Text = "新建更换";
            groupBox1.Text = "历史更换单";
            groupBox2.Text = "更换刀具信息";

            LS_djgh.Visible = true;//单据和明细信息的更新
            Panel_djgh.Visible = true;

            AllBtn.Visible = false;//查看全部按钮状态更新

        }

        /// <summary>
        /// 窗体加载历史出仓单和所有明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJCCHistory_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);

            //筛选条件的起始和截止日期控件
            //QSSJCX.Checked = true;
            QSSJCX.MinDate = new DateTime(1995, 12, 24);
            QSSJCX.MaxDate = DateTime.Today;
            JZSJCX.MinDate = new DateTime(1995, 12, 24);
            JZSJCX.MaxDate = DateTime.Today;

            //设置单号自动补全
            //SqlStr = "select " + DH + " from " + danjubiao;
            //comboBox1.DataSource = SQL.DataReadList(SqlStr);
            //comboBox1.AutoCompleteSource =

            //加载历史单据表
            SqlStr = "SELECT * FROM " + danjubiao + " ORDER BY " + RQ + " DESC ";
            DataSet ds = SQL.getDataSet(SqlStr, danjubiao);
            LS_dgv.AutoGenerateColumns = false;//关闭自动生成列，只显示datagridview中有定义的列
            LS_dgv.DataSource = ds.Tables[0].DefaultView;

            //根据单据状态字段设置历史单号表单元格背景色
            Refresh();

            //加载单据明细，若是“刀具更换单”、“刀具报废单”等没有明细表的情况，则不加载明细表
            djgh_y_djlx.Text = "请选择更换单号。";
            djgh_x_djlx.Text = "请选择更换单号。";
            
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            LS_dgv.DataSource = null;
            SqlStr = string.Format("SELECT * FROM {0} WHERE {1} LIKE '%{2}%' AND {3} LIKE '%{4}%' AND {5} LIKE '%{6}%' AND {7} LIKE '%{8}%' ORDER BY {9} DESC", danjubiao, DH, DHCX.Text.ToString().Trim(), BZ, BZCX.Text.ToString().Trim(), GX, GXCX.Text.ToString().Trim(), SB, SBCX.Text.ToString().Trim(), RQ);
            DataSet ds = SQL.getDataSet(SqlStr, danjubiao);
            LS_dgv.DataSource = ds.Tables[0].DefaultView;

            //根据单据状态字段设置单元格背景色
            Refresh();
        }

        /// <summary>
        /// 新建单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewBtn_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            DJGH djgh = new DJGH();
            frm = djgh;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                DJCCHistory_Load(null, null);
            }

            //this.Close();
        }

        #region datagridview事件设置
        ///<summary>
        ///datagridview每一行自动生成序号
        /// </summary>
        private void LiShi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(LS_dgv, e);
        }

       
        #endregion

        #region 点击单号查看明细
        /// <summary>
        /// 判断当前点击的是否是第一列：入仓单号，若是，则查看其明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LiShi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int RowIndex = LiShi.CurrentCell.RowIndex;
            int ColumnIndex = LS_dgv.CurrentCell.ColumnIndex;
            if (ColumnIndex == 0)
            {
                string dh = LS_dgv.CurrentCell.Value.ToString();
                SqlStr = "SELECT * FROM " + mingxibiao + " WHERE " + DH + " = '" + dh + "'";
                DataSet ds = SQL.getDataSet(SqlStr, mingxibiao);

                djgh_y_djlx.Text = ds.Tables[0].Rows[0]["ydjlx"].ToString();
                djgh_y_djgg.Text = ds.Tables[0].Rows[0]["ydjgg"].ToString();
                djgh_y_djcd.Text = ds.Tables[0].Rows[0]["ydjcd"].ToString();
                djgh_y_djid.Text = ds.Tables[0].Rows[0]["ydjid"].ToString();

                djgh_x_djlx.Text = ds.Tables[0].Rows[0]["xdjlx"].ToString();
                djgh_x_djgg.Text = ds.Tables[0].Rows[0]["xdjgg"].ToString();
                djgh_x_djcd.Text = ds.Tables[0].Rows[0]["xdjcd"].ToString();
                djgh_x_djid.Text = ds.Tables[0].Rows[0]["xdjid"].ToString();

                djgh_ghly.Text = ds.Tables[0].Rows[0]["ghly"].ToString();
            }
        }
        #endregion

        #region 双击单元格事件部分
        /// <summary>
        /// 更换单据历史表--双击单元格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LS_djgh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string dh = LS_dgv.Rows[e.RowIndex].Cells["LS_djgh_dh"].Value.ToString();
            DJGH djgh = new DJGH(dh);
            djgh.ShowDialog();

            if (djgh.DialogResult == DialogResult.OK)
            {
                DJCCHistory_Load(null, null);
            }
        }
                
        #endregion 双击单元格事件部分结束

        /// <summary>
        /// 查看全部按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AllBtn_Click(object sender, EventArgs e)
        {
            SqlStr = "select * from " + mingxibiao;
            DataSet ds = SQL.getDataSet(SqlStr, mingxibiao);
            MX_dgv.DataSource = ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 窗体自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void History_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        /// <summary>
        /// 刷新表格数据背景,根据单据状态字段设置历史单号表单元格背景色
        /// </summary>
        public void Refresh()
        {
            //临时测试，根据单据状态字段设置单元格背景色
            for (int row = 0; row < LS_dgv.RowCount; row++)
            {
                if (LS_dgv.Rows[row].Cells[Cells].Value.ToString() == "1")
                {
                    //LS_dgv.Rows[row].Cells[0].Style.BackColor = Color.Gray;
                    //LS_dgv.Rows[row].DefaultCellStyle.BackColor = Color.Gray;
                    //LS_dgv.Rows[row].DefaultCellStyle.BackColor = Color.LightBlue;
                    continue;
                }
                else
                {
                    LS_dgv.Rows[row].DefaultCellStyle.BackColor = Color.AntiqueWhite;
                }
            }
        }

        private void DJGHHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Alex.CloseFormFromTabpages(this);

        }
    }
}
