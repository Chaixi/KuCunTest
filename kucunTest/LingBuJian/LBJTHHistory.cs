using kucunTest.BaseClasses;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace kucunTest.LingBuJian
{
    public partial class LBJTHHistory : Form
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

        public LBJTHHistory()
        {
            InitializeComponent();

            string type = "LBJTH";
            TYPE = type;

            danjubiao = "lbj_tuihuan";
            mingxibiao = "lbj_tuihuanmingxi";
            LS_dgv = LS_lbjth;
            MX_dgv = MX_lbjth;
            DH = "danhao";
            RQ = "thrq";
            BZ = "thbz";//自定义查询1
            SB = "thyy";//自定义查询2，
            GX = "jbr";//自定义查询3，经办人
            Cells = "LS_lbjth_djzt";
            Init();//窗体初始化
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <param name="type"></param>
        private void Init()
        {
            label2.Text = "退还单号：";//查询部分
            label7.Text = "退还班组：";
            label8.Text = "退还原因：";
            label9.Text = "经 办 人：";

            NewBtn.Text = "新建退还";
            LS.Text = "历史退还单据";
            MX.Text = "退还刀具信息";

            LS_lbjth.Visible = true;
            MX_lbjth.Visible = true;

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

            
        }

        public void RefreshColor()
        {
            //临时测试，根据单据状态字段设置单元格背景色
            for (int row = 0; row < LS_dgv.RowCount; row++)
            {
                if (LS_dgv.Rows[row].Cells["LS_lbjth_djzt"].Value.ToString() == "1")
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
            LBJTH lbjth = new LBJTH();
            frm = lbjth;
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


        /// <summary>
        /// 退还单据历史表--双击单元格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LS_lbjth_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string dh = LS_dgv.Rows[e.RowIndex].Cells["LS_lbjth_thdh"].Value.ToString();
                LBJTH lbjth = new LBJTH(dh);
                lbjth.ShowDialog();

                if (lbjth.DialogResult == DialogResult.OK)
                {
                    lbj_History_Load(null, null);
                }
            }
        }


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

        private void LBJTHHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Alex.CloseFormFromTabpages(this);

        }
    }
}
