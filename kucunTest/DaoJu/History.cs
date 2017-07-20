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
using Newtonsoft.Json;

namespace kucunTest.DaoJu
{
    public partial class History : Form
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

        /// <summary>
        /// 构造函数，根据单据类型初始化
        /// </summary>
        /// <param name="type"></param>
        public History(string type)
        {
            InitializeComponent();
            TYPE = type;
            switch(type)
            {
                case "DJCCD"://刀具领用单
                    danjubiao = "daojulingyong";
                    mingxibiao = "daojulingyongmingxi";
                    LS_dgv = LS_djccd;
                    MX_dgv = MX_djccd;
                    DH = "chucangdanhao";
                    RQ = "chucangriqi";
                    BZ = "lingyongbanzu";
                    SB = "lingyongshebei";
                    GX = "jiagonggongyi";
                    Cells = "LS_djzt";
                    break;
                case "DJWJ"://刀具外借申请单
                    danjubiao = "daojuwaijie";
                    mingxibiao = "daojuwaijiemingxi";
                    LS_dgv = LS_djwj;
                    MX_dgv = MX_djwj;
                    DH = "danhao";
                    RQ = "jcsj";
                    BZ = "jydw";//自定义查询1，借用单位
                    SB = "spld";//自定义查询2，审批领导
                    GX = "jbr";//自定义查询3，经办人
                    Cells = "LS_djwj_djzt";
                    break;
                case "DJGH"://刀具更换申请单，明细表为空
                    danjubiao = "daojugenghuan";
                    mingxibiao = "daojugenghuan";//在点击更换单号时可用到
                    LS_dgv = LS_djgh;
                    DH = "danhao";
                    RQ = "sqsj";
                    BZ = "sqbz";
                    SB = "sqsb";
                    GX = "jglj";
                    Cells = "LS_djgh_djzt";
                    break;
                case "DJBF"://刀具报废申请单，明细表为空
                    danjubiao = "daojubaofei";
                    mingxibiao = "daojubaofei";
                    LS_dgv = LS_djbf;
                    DH = "danhao";
                    break;
                case "DJTH"://刀具退还单
                    danjubiao = "daojutuihuan";
                    mingxibiao = "daojutuihuanmingxi";
                    LS_dgv = LS_djth;
                    MX_dgv = MX_djth;
                    DH = "danhao";
                    break;
            }

            Init(type);//窗体初始化
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

            //加载单据明细，若是“刀具更换单”、“刀具报废单”等没有明细表的情况，则不加载明细表
            if(TYPE == "DJGH" || TYPE == "DJBF")
            {
                if (TYPE == "DJGH")//加载刀具更换单的刀具更换信息。
                {
                    djgh_y_djlx.Text = "请选择更换单号。";
                    djgh_x_djlx.Text = "请选择更换单号。";
                }
                else if (TYPE == "DJBF")//加载刀具报废单的刀具报废信息。
                {
                    djbf_djlx.Text = "请选择更换单号。";
                }
            }
            else//直接加载明细表
            {
                SqlStr = "select * from " + mingxibiao;
                ds = SQL.getDataSet(SqlStr, mingxibiao);
                MX_dgv.AutoGenerateColumns = false;//关闭自动生成列
                MX_dgv.DataSource = ds.Tables[0].DefaultView;
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
            switch(TYPE)
            {
                case "DJCCD"://刀具领用单
                    DJCCD djccd = new DJCCD();
                    frm = djccd;
                    break;
                case "DJWJ"://刀具外借申请单
                    DJWJ djwj = new DJWJ();
                    frm = djwj;
                    break;
                case "DJGH"://刀具更换申请单
                    DJGH djgh = new DJGH();
                    frm = djgh;
                    break;
                case "DJBF"://刀具报废申请单
                    DJBF djbf = new DJBF();
                    frm = djbf;
                    break;
                case "DJTH"://刀具退还单
                    DJTH djth = new DJTH();
                    frm = djth;
                    break;
            }

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
            //int RowIndex = LiShi.CurrentCell.RowIndex;
            int ColumnIndex = LS_dgv.CurrentCell.ColumnIndex;
            if (ColumnIndex == 0)
            {
                string dh = LS_dgv.CurrentCell.Value.ToString();

                if(TYPE == "DJGH" || TYPE == "DJBF")
                {
                    if (TYPE == "DJGH")//若是“刀具更换单”、“刀具报废申请单”等没有明细表的情况，则加载单据详细信息
                    {
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
                    else if(TYPE == "DJBF")//刀具报废申请单
                    {
                        SqlStr = "select * from " + mingxibiao + " where " + DH + " = '" + dh + "'";
                        DataSet ds = SQL.getDataSet(SqlStr, mingxibiao);

                        djbf_djlx.Text = ds.Tables[0].Rows[0]["djlx"].ToString();
                        djbf_djgg.Text = ds.Tables[0].Rows[0]["djgg"].ToString();
                        djbf_djcd.Text = ds.Tables[0].Rows[0]["djcd"].ToString();
                        djbf_djid.Text = ds.Tables[0].Rows[0]["djid"].ToString();

                        djbf_bfyy.Text = ds.Tables[0].Rows[0]["bfyy"].ToString();
                    }
                }
                else//直接加载明细表
                {
                    SqlStr = "SELECT * FROM " + mingxibiao + " WHERE " + DH + " = '" + dh + "'";
                    DataSet ds = SQL.getDataSet(SqlStr, mingxibiao);
                    MX_dgv.DataSource = ds.Tables[0].DefaultView;
                }                
            }
        }
        #endregion

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
        /// 初始化界面
        /// </summary>
        /// <param name="type"></param>
        private void Init(string type)
        {
            if(type == "DJCCD")//刀具领用单
            {
                this.Name = "DJCCDHistory";//界面显示字段名称更新
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

                LS_djwj.Visible = false;
                MX_djwj.Visible = false;

                LS_djgh.Visible = false;
                Panel_djgh.Visible = false;

                LS_djbf.Visible = false;
                Panel_djbf.Visible = false;

                LS_djth.Visible = false;
                MX_djth.Visible = false;

                AllBtn.Visible = false;//查看全部按钮状态更新

            }
            else if(type == "DJWJ")//刀具外借申请单
            {
                this.Name = "DJWJHistory";//界面显示字段名称更新
                this.Text = "刀具外借单据记录";
                label1.Text = "刀具外借记录";

                label2.Text = "外借单号：";//查询部分
                label7.Text = "借用单位：";
                label8.Text = "审批领导：";
                label9.Text = "经 办 人：";

                NewBtn.Text = "新建外借";
                groupBox1.Text = "历史外借单";
                groupBox2.Text = "外借单明细";

                LS_djwj.Visible = true;//单据和明细信息的更新
                MX_djwj.Visible = true;

                MX_djccd.Visible = false;
                LS_djccd.Visible = false;

                LS_djgh.Visible = false;
                Panel_djgh.Visible = false;

                LS_djbf.Visible = false;
                Panel_djbf.Visible = false;

                LS_djth.Visible = false;
                MX_djth.Visible = false;

                AllBtn.Visible = true;//查看全部按钮状态更新

            }
            else if(type == "DJGH")//刀具更换申请单
            {
                this.Name = "DJGHHistory";//界面显示字段名称更新
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

                LS_djccd.Visible = false;
                MX_djccd.Visible = false;

                LS_djwj.Visible = false;
                MX_djwj.Visible = false;

                LS_djbf.Visible = false;
                Panel_djbf.Visible = false;

                LS_djth.Visible = false;
                MX_djth.Visible = false;

                AllBtn.Visible = false;//查看全部按钮状态更新
            }
            else if (type == "DJBF")//刀具报废申请单
            {
                this.Name = "DJBFHistory";//界面显示字段名称更新
                this.Text = "刀具报废历史";
                label1.Text = "刀具报废历史记录";
                NewBtn.Text = "新建刀具报废单";
                groupBox1.Text = "历史报废单";
                groupBox2.Text = "报废刀具信息";

                LS_djbf.Visible = true;
                Panel_djbf.Visible = true;

                LS_djgh.Visible = false;//单据和明细信息的更新
                Panel_djgh.Visible = false;

                LS_djccd.Visible = false;
                MX_djccd.Visible = false;

                LS_djwj.Visible = false;
                MX_djwj.Visible = false;

                LS_djth.Visible = false;
                MX_djth.Visible = false;

                AllBtn.Visible = false;//查看全部按钮状态更新
            }
            else if (type == "DJTH")//刀具退还单
            {
                this.Name = "DJTHHistory";//界面显示字段名称更新
                this.Text = "刀具退还历史";
                label1.Text = "刀具退还历史记录";
                NewBtn.Text = "新建刀具退还单";
                groupBox1.Text = "历史退还单";
                groupBox2.Text = "退还刀具信息";

                LS_djth.Visible = true;
                MX_djth.Visible = true;

                LS_djbf.Visible = false;
                Panel_djbf.Visible = false;

                LS_djgh.Visible = false;//单据和明细信息的更新
                Panel_djgh.Visible = false;

                LS_djccd.Visible = false;
                MX_djccd.Visible = false;

                LS_djwj.Visible = false;
                MX_djwj.Visible = false;

                AllBtn.Visible = true;//查看全部按钮状态更新
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
        /// 窗体自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void History_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        /// <summary>
        /// 领用单据历史表--双击单元格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LS_djccd_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

            DJCCD djccd = new DJCCD(list);

            djccd.ShowDialog();

            if (djccd.DialogResult == DialogResult.OK)
            {
                DJCCHistory_Load(null, null);
            }
        }

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

        /// <summary>
        /// 外借单据历史表--双击单元格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LS_djwj_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string dh = LS_dgv.Rows[e.RowIndex].Cells["LS_djwj_dh"].Value.ToString();
            DJWJ djwj = new DJWJ(dh);
            djwj.ShowDialog();

            if(djwj.DialogResult == DialogResult.OK)
            {
                DJCCHistory_Load(null, null);
            }

        }
    }
}
