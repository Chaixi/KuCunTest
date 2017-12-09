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
    public partial class DJLYHistory : Form
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

        public DJLYHistory()
        {
            InitializeComponent();

            danjubiao = DaoJuLingYong.TableName;
            mingxibiao = DaoJuLingYongMingXi.TableName;
            LS_dgv = LS_djccd;
            MX_dgv = MX_djccd;
            DH = "chucangdanhao";
            RQ = "chucangriqi";
            BZ = "lingyongbanzu";
            SB = "lingyongshebei";
            GX = "jiagonggongyi";
            Cells = "LS_djzt";
            
            Init();//窗体初始化

        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <param name="type"></param>
        private void Init()
        {
            this.Name = "DJLY";//界面显示字段名称更新
            this.Text = "刀具领用单据记录";
            label1.Text = "刀具领用记录";

            label2.Text = "领用单号：";//查询部分
            label7.Text = "领用班组：";
            label8.Text = "领用设备：";
            label9.Text = "加工工序：";
            //label1.Font.Size = ;
            NewBtn.Text = "新建领用";
            groupBox1.Text = "刀具领用单";
            groupBox2.Text = "领用单明细";

            MX_djccd.Visible = true;//单据和明细信息的更新
            LS_djccd.Visible = true;

            AllBtn.Visible = false;//查看全部按钮状态更新
        }

        /// <summary>
        /// 窗体加载历史出仓单和所有明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJLYHistory_Load(object sender, EventArgs e)
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
            DJLY djccd = new DJLY();
            frm = djccd;

            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                DJLYHistory_Load(null, null);
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

        private void MingXi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(MX_dgv, e);
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
            if(e.RowIndex >= 0)
            {
                //int RowIndex = LiShi.CurrentCell.RowIndex;
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
        private void LS_djccd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                //MessageBox.Show("celldoubleclick!");
                //DJCCD djccd = new DJCCD(LS_dgv.Rows[e.RowIndex].Cells["LS_ccdh"].Value.ToString());
                //djccd.Owner = this;

                List<string> list = new List<string>();
                list.Add(LS_dgv.Rows[e.RowIndex].Cells["LS_lydh"].Value.ToString());//list[0] 领用单号
                list.Add(LS_dgv.Rows[e.RowIndex].Cells["LS_zjgx"].Value.ToString());//list[1] 制件工序
                list.Add(LS_dgv.Rows[e.RowIndex].Cells["LS_lybz"].Value.ToString());//list[2] 领用班组
                list.Add(LS_dgv.Rows[e.RowIndex].Cells["LS_lysb"].Value.ToString());//list[3] 领用设备
                list.Add(LS_dgv.Rows[e.RowIndex].Cells["LS_lyr"].Value.ToString());//list[4] 领用人
                list.Add(LS_dgv.Rows[e.RowIndex].Cells["LS_lyrq"].Value.ToString());//list[5] 领用日期
                list.Add(LS_dgv.Rows[e.RowIndex].Cells["LS_jbr"].Value.ToString());//list[6] 经办人
                list.Add(LS_dgv.Rows[e.RowIndex].Cells["LS_bz"].Value.ToString());//list[7] 备注
                list.Add(LS_dgv.Rows[e.RowIndex].Cells["LS_djzt"].Value.ToString());//list[8] 单据状态

                DJLY djccd = new DJLY(list);

                djccd.ShowDialog();

                if (djccd.DialogResult == DialogResult.OK)
                {
                    DJLYHistory_Load(null, null);
                }
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

        private void DJLYHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Alex.CloseFormFromTabpages(this);
        }
    }
}
