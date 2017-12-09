using kucunTest.BaseClasses;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace kucunTest.LingBuJian
{
    public partial class LBJLYHistory : Form
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

        public LBJLYHistory()
        {
            InitializeComponent();

            string type = "LBJLY";
            TYPE = type;

            danjubiao = "lbj_lingyong";
            mingxibiao = "lbj_lingyongmingxi";
            LS_dgv = LS_lbjly;
            MX_dgv = MX_lbjly;
            DH = "danhao";
            RQ = "lyrq";
            BZ = "lybz";
            SB = "lysb";
            GX = "zjgx";
            Cells = "LS_lbjly_djzt";

            Init();//窗体初始化
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <param name="type"></param>
        private void Init()
        {
            this.Name = "LBJLYHistory";//界面显示字段名称更新
            this.Text = "零部件领用单据记录";
            label1.Text = "零部件领用记录";

            label2.Text = "领用单号：";//查询部分
            label7.Text = "领用班组：";
            label8.Text = "领用设备：";
            label9.Text = "制件工序：";

            NewBtn.Text = "新建领用";
            LS.Text = "零部件领用单";
            MX.Text = "领用单明细";

            LS_lbjly.Visible = true;//单据和明细信息的更新
            MX_lbjly.Visible = true;

            AllBtn.Visible = false;//查看全部按钮状态更新
        }

        private void lbj_History_Load(object sender, EventArgs e)
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
            RefreshColor();            

            //直接加载单据明细
            SqlStr = "SELECT * FROM " + mingxibiao;
            ds = SQL.getDataSet(SqlStr, mingxibiao);
            MX_dgv.AutoGenerateColumns = false;//关闭自动生成列
            MX_dgv.DataSource = ds.Tables[0].DefaultView;
        }

        public void RefreshColor()
        {
            //根据单据状态字段设置历史单号表单元格背景色
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

            //临时测试，根据单据状态字段设置单元格背景色
            for (int row = 0; row < LS_dgv.RowCount; row++)
            {
                if (LS_dgv.Rows[row].Cells["LS_lbjly_djzt"].Value.ToString() == "1")
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

        /// <summary>
        /// 新建单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewBtn_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            LBJLY lbjly = new LBJLY();
            frm = lbjly;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                lbj_History_Load(null, null);
            }

            //this.Close();
        }

        #region datagridview事件设置
        /// <summary>
        /// datagridview每一行自动生成序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LS_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(LS_dgv, e);
        }

        private void MX_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(MX_dgv, e);
        }

        #endregion

        #region 点击单号查看明细
        /// <summary>
        /// 判断当前点击的是否是第一列：单号，若是，则查看其明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                int ColumnIndex = LS_dgv.CurrentCell.ColumnIndex;
                if (ColumnIndex == 0)
                {
                    string dh = LS_dgv.CurrentCell.Value.ToString();

                    //直接加载明细表
                    SqlStr = "SELECT * FROM " + mingxibiao + " WHERE " + DH + " = '" + dh + "'";
                    DataSet ds = SQL.getDataSet(SqlStr, mingxibiao);
                    MX_dgv.DataSource = ds.Tables[0].DefaultView;
                }
            }
            
        }
        #endregion

        #region 双击单元格事件部分
        /// <summary>
        /// 领用单据历史表--双击单元格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LS_lbjly_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string dh = LS_dgv.Rows[e.RowIndex].Cells["LS_lbjly_lydh"].Value.ToString();
                LBJLY djccd = new LBJLY(dh);
                djccd.ShowDialog();

                if (djccd.DialogResult == DialogResult.OK)
                {
                    lbj_History_Load(null, null);
                }
            }
            
        }

        #endregion 双击单元格事件部分结束

        /// <summary>
        /// 窗口自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbj_History_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
            RefreshColor();
        }

        private void LBJLYHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Alex.CloseFormFromTabpages(this);

        }
    }
}
