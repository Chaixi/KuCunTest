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
using FastReport;

namespace kucunTest.LingBuJian
{
    public partial class LBJLY : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";
        int HJ = 0;
        bool zancun = false;
        bool queren = false;
        string tishi = "";//提示文本

        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();//窗口自适应类
        
        DataTable lymx_db = new DataTable();

        //零部件表
        string lbjbiao = "jichuxinxi";
        string lbjbiao_lbjmc = "daojuid";
        string lbjbiao_lbjgg = "daojuguige";
        string lbjbiao_lbjxh = "daojuxinghao";
        string lbjbiao_djgbm = "weizhi";
        string lbjbiao_jtwz = "cengshu";
        string lbjbiao_kcsl = "kcsl";
        string lbjbiao_dw = "danwei";

        string danjubiao = "lbj_lingyong";
        string mingxibiao = "lbj_lingyongmingxi";
        string liushuibiao = "lbj_liushui";
        string DHZD = "danhao";

        string TYPE = "LBJLY";
        #endregion

/*--------------------------------------------构造函数与窗体加载部分-------------------------------------------------------------------------------------------------------*/
        #region 构造函数与窗体加载部分
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public LBJLY()
        {
            InitializeComponent();

            danhao.Text = Alex.DanHao("LBJLY");//自动生成单号
            LYRQ.Value = DateTime.Now;
            LYBZ.SelectedIndex = 0;
            JBR.SelectedIndex = 0;
            heji.Text = HJ.ToString();

            loadData();
            cbx_lbjmc.SelectedIndex = -1;

            AddColumns();
            lingyongmingxi.AutoGenerateColumns = false;//禁止自动生成列
            lingyongmingxi.DataSource = lymx_db.DefaultView;
            lingyongmingxi.CurrentCell = null;
        }

        /// <summary>
        /// 重写构造函数，用于从历史记录窗体加载数据
        /// </summary>
        /// <param name="dh">从历史记录传过来的值</param>
        public LBJLY(string dh)
        {
            InitializeComponent();

            loadData();
            cbx_lbjmc.SelectedIndex = -1;

            //根据单号查询数据库退还和操作信息
            Sqlstr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", danjubiao, DHZD, dh);
            DataSet ds = SQL.getDataSet(Sqlstr, danjubiao);

            //给借用信息和操作信息赋值
            danhao.Text = dh;//单号
            LYBZ.Text = ds.Tables[0].Rows[0]["lybz"].ToString();//领用班组
            LYSB.Text = ds.Tables[0].Rows[0]["lysb"].ToString();//领用设备
            LYR.Text = ds.Tables[0].Rows[0]["lyr"].ToString();//领用人
            LYRQ.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["lyrq"].ToString());//领用日期
            ZJGX.Text = ds.Tables[0].Rows[0]["zjgx"].ToString();//制件工序
            beizhu.Text = ds.Tables[0].Rows[0]["beizhu"].ToString();//领用备注
            JBR.Text = ds.Tables[0].Rows[0]["jbr"].ToString();//经办人
            string djzt = ds.Tables[0].Rows[0]["djzt"].ToString();//单据状态

            //根据单号查询明细信息
            Sqlstr = string.Format("SELECT l.lbjmc, l.lbjgg, l.lbjxh, CONCAT(l.djgbm, '--', l.jtwz) AS kcwz, j.kcsl AS kcsl, l.lysl, l.dw, l.jcbm, l.gx, l.bz FROM {0} l INNER JOIN {3} j ON l.lbjmc = j.daojuid AND l.lbjxh = j.daojuxinghao AND l.djgbm = j.weizhi AND l.jtwz = j.cengshu WHERE {1} = '{2}'", mingxibiao, DHZD, dh, lbjbiao);
            //Sqlstr = string.Format("SELECT mx.lbjmc AS lbjmc, mx.lbjgg AS lbjgg, mx.lbjxh AS lbjxh, CONCAT(mx.djgbm, '--', mx.jtwz) AS kcwz, ls.dskykc AS kcsl, mx.lysl AS lysl, mx.dw AS dw, mx.jcbm AS jcbm, mx.gx AS gx, mx.bz AS bz FROM {0} mx LEFT JOIN {1} ls ON mx.danhao=ls.danhao WHERE mx.lbjxh=ls.lbjxh AND mx.djgbm = ls.djgbm AND mx.jtwz=ls.jtwz AND mx.{2}='{3}'", mingxibiao, liushuibiao, DHZD, dh);
            lymx_db.Reset();//重置数据表
            lymx_db = (SQL.getDataSet(Sqlstr, mingxibiao)).Tables[0];//用全局变量保存查询出来的明细，方便后续可以继续添加
            lingyongmingxi.AutoGenerateColumns = false;
            lingyongmingxi.DataSource = lymx_db.DefaultView;
            
            //更新合计数量
            for(int i = 0; i<lymx_db.Rows.Count; i++)
            {
                HJ = HJ + Convert.ToInt16(lymx_db.Rows[i]["lysl"].ToString());
            }
            heji.Text = HJ.ToString();

            //若是已完成的单据，则只允许查看，不许修改。
            if (djzt == "1")
            {
                Alex.DisableAllControl(this);
                btnPrint.Enabled = true;
                btnexit.Enabled = true;
                queren = true;//是已确认单据
            }
            else
            {
                zancun = true;//是暂存单据
            }
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LBJLY_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);//记录窗体及控件初始大小，以便自适应
        }

        #endregion 构造函数与窗体加载部分结束

/*--------------------------------------------明细部分-------------------------------------------------------------------------------------------------------*/
        #region 明细部分
        ///<summary>
        ///datagridview每一行自动生成序号
        /// </summary>
        private void lingyongmingxi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(lingyongmingxi, e);
        }

        /// <summary>
        /// 明细新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMXNew_Click(object sender, EventArgs e)
        {
            #region 弹出添加框
            //lbj_xzlymx xz = new lbj_xzlymx(TYPE);
            //xz.Owner = this;

            //xz.StartPosition = FormStartPosition.Manual;
            ////this.Left = this.Left / 2;
            //xz.Left = this.Left + this.Width;
            //xz.Top = this.Top * 2;

            //xz.ShowDialog();
            #endregion 弹出框部分结束

            if(AddDataCheck())//进行数据验证
            {
                //暂存单据，领用明细datagridview已经绑定数据源
                //if (zancun)
                //{
                    DataRow rowrow = lymx_db.NewRow();

                    rowrow["lbjmc"] = cbx_lbjmc.Text.ToString();//零部件名称
                    rowrow["lbjgg"] = cbx_lbjgg.Text.ToString();//零部件规格
                    rowrow["lbjxh"] = cbx_lbjxh.Text.ToString();//零部件型号
                    rowrow["kcwz"] = (cbx_djgbm.Text + "--" + cbx_cfwz.Text).ToString();//库存位置
                    rowrow["kcsl"] = Convert.ToInt16(txt_kcsl.Text);//库存数量
                    rowrow["lysl"] = Convert.ToInt16(txt_lysl.Text);//领用数量
                    rowrow["dw"] = txt_dw1.Text;//单位
                    rowrow["jcbm"] = cbx_lyjc.Text.ToString();//领用机床编码
                    rowrow["gx"] = cbx_xggx.Text.ToString();//相关工序
                    rowrow["bz"] = txt_bz.Text.ToString();//备注

                    lymx_db.Rows.Add(rowrow);
                //}
                //else
                //{
                //    DataGridViewRow row = new DataGridViewRow();
                //    row.CreateCells(lingyongmingxi);

                //    row.Cells[0].Value = cbx_lbjmc.Text;//零部件名称
                //    row.Cells[1].Value = cbx_lbjgg.Text;//零部件规格
                //    row.Cells[2].Value = cbx_lbjxh.Text;//零部件型号
                //    row.Cells[3].Value = cbx_djgbm.Text + "--" + cbx_cfwz.Text;//库存位置
                //    row.Cells[4].Value = txt_kcsl.Text;//库存数量
                //    row.Cells[5].Value = txt_dw1.Text;//单位
                //    row.Cells[6].Value = txt_lysl.Text;//领用数量
                //    row.Cells[7].Value = cbx_lyjc.Text;//领用机床编码
                //    row.Cells[8].Value = cbx_xggx.Text;//相关工序
                //    row.Cells[9].Value = txt_bz.Text;//备注

                //    lingyongmingxi.Rows.Add(row);
                //}

                HJ = HJ + Convert.ToInt16(txt_lysl.Text);//合计数量增加
                heji.Text = HJ.ToString();//更新合计数量
            }

            lingyongmingxi.CurrentCell = null;//取消选中任何行
            
        }

        /// <summary>
        /// 明细内容修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMXEdit_Click(object sender, EventArgs e)
        {
            //为选中行或者选中的是最后一行
            if(lingyongmingxi.SelectedRows.Count <= 0 || lingyongmingxi.CurrentRow.Index == lingyongmingxi.Rows.Count - 1)
            {
                tishi = "请先选中一行非空白的明细数据！";
                MessageBox.Show(tishi, "提示");
                return;
            }

            if(AddDataCheck())
            {
                int crtrowindex = lingyongmingxi.CurrentRow.Index;

                //排除从总表勾选得到的明细数据因没有领用数量、机床编码、工序、备注而出错的情况
                if(lingyongmingxi.Rows[crtrowindex].Cells["lysl"].Value.ToString() != "" && lingyongmingxi.Rows[crtrowindex].Cells["lysl"] != null)
                {
                    HJ = HJ - Convert.ToInt16(lingyongmingxi.Rows[crtrowindex].Cells["lysl"].Value.ToString());
                }

                lingyongmingxi.Rows[crtrowindex].Cells["lbjmc"].Value = cbx_lbjmc.Text;//零部件名称
                lingyongmingxi.Rows[crtrowindex].Cells["lbjgg"].Value = cbx_lbjgg.Text;//零部件规格
                lingyongmingxi.Rows[crtrowindex].Cells["lbjxh"].Value = cbx_lbjxh.Text;//零部件型号
                lingyongmingxi.Rows[crtrowindex].Cells["kcwz"].Value = cbx_djgbm.Text + "--" + cbx_cfwz.Text;//库存位置
                lingyongmingxi.Rows[crtrowindex].Cells["kcsl"].Value = txt_kcsl.Text;//库存数量
                lingyongmingxi.Rows[crtrowindex].Cells["dw"].Value = txt_dw1.Text;//单位
                lingyongmingxi.Rows[crtrowindex].Cells["lysl"].Value = txt_lysl.Text;//领用数量
                lingyongmingxi.Rows[crtrowindex].Cells["jcbm"].Value = cbx_lyjc.Text;//领用机床编码
                lingyongmingxi.Rows[crtrowindex].Cells["gx"].Value = cbx_xggx.Text;//相关工序
                lingyongmingxi.Rows[crtrowindex].Cells["bz"].Value = txt_bz.Text;//备注

                HJ = HJ + Convert.ToInt16(txt_lysl.Text);
                heji.Text = HJ.ToString();

                //修改完清除选中行，避免误操作
                lingyongmingxi.CurrentCell = null;
            }          

        }

        /// <summary>
        /// 明细删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMXDelete_Click(object sender, EventArgs e)
        {
            int k = lingyongmingxi.SelectedRows.Count;
            if (k == 0)
            {
                MessageBox.Show("请先选择至少一行数据！", "提示", MessageBoxButtons.OK);
            }
            else if (lingyongmingxi.CurrentRow.Index == lingyongmingxi.Rows.Count - 1 || k == lingyongmingxi.Rows.Count)//选中的是最后一行
            {
                MessageBox.Show("不能删除空白行！", "警告", MessageBoxButtons.OK);
            }
            else if (k == 1)
            {
                DialogResult result = MessageBox.Show("确定删除" + k + "行数据？", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //排除从总表添加暂未修改领用数量的情况
                    if (lingyongmingxi.Rows[lingyongmingxi.CurrentRow.Index].Cells["lysl"].Value.ToString() != "" && lingyongmingxi.Rows[lingyongmingxi.CurrentRow.Index].Cells["lysl"].Value.ToString() != null)
                    {
                        HJ = HJ - Convert.ToInt16(lingyongmingxi.Rows[lingyongmingxi.CurrentRow.Index].Cells["lysl"].Value.ToString());//合计数量减去本行领用数量
                    }
                    lingyongmingxi.Rows.RemoveAt(lingyongmingxi.CurrentRow.Index);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("确定删除" + k + "行数据？", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    for (int i = k; i >= 1; i--)//从下往上删，避免沙漏效应
                    {
                        //排除从总表添加暂未修改领用数量的情况
                        if(lingyongmingxi.Rows[lingyongmingxi.SelectedRows[i - 1].Index].Cells["lysl"].Value.ToString() != "" && lingyongmingxi.Rows[lingyongmingxi.SelectedRows[i - 1].Index].Cells["lysl"].Value.ToString() != null)
                        {
                            HJ = HJ - Convert.ToInt16(lingyongmingxi.Rows[lingyongmingxi.SelectedRows[i - 1].Index].Cells["lysl"].Value.ToString());//合计数量减去本行领用数量
                        }                        
                        lingyongmingxi.Rows.RemoveAt(lingyongmingxi.SelectedRows[i - 1].Index);
                    }
                }
            }

            heji.Text = HJ.ToString();//更新合计数量
        }

        #region 明细内容编辑--联动部分
        /// <summary>
        /// 加载明细选择的数据
        /// </summary>
        private void loadData()
        {
            //加载所有设备
            string sqlstr2 = "SELECT jichuangbianma FROM jichuang";
            List<string> list_sb = SQL.DataReadList(sqlstr2);
            LYSB.DataSource = list_sb;
            cbx_lyjc.DataSource = new List<string>(list_sb.ToArray());//复制上一个list，不然两个combobox会同时变化
            LYSB.SelectedIndex = -1;

            //加载所有零部件名称
            Sqlstr = string.Format("SELECT DISTINCT {0} FROM {1} ORDER BY CONVERT({2} USING gbk) ASC", lbjbiao_lbjmc, lbjbiao, lbjbiao_lbjmc);
            cbx_lbjmc.DataSource = SQL.DataReadList(Sqlstr);
        }

        /// <summary>
        /// 零部件名称选择变化，规格or型号相应变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_lbjmc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_lbjmc.SelectedIndex >= 0)
            {
                //加载所有规格
                Sqlstr = string.Format("SELECT DISTINCT {0} FROM {1} WHERE {2}='{3}'", lbjbiao_lbjgg, lbjbiao, lbjbiao_lbjmc, cbx_lbjmc.Text);
                cbx_lbjgg.DataSource = SQL.DataReadList(Sqlstr);

                //加载所有型号
                Sqlstr = string.Format("SELECT DISTINCT {0} FROM {1} WHERE {2}='{3}'", lbjbiao_lbjxh, lbjbiao, lbjbiao_lbjmc, cbx_lbjmc.Text);
                cbx_lbjxh.DataSource = SQL.DataReadList(Sqlstr);

                //默认选择上方的的领用设备
                cbx_lyjc.SelectedItem = LYSB.SelectedItem;
            }
            else
            {
                //规格与型号选择为空
                //cbx_lbjgg.SelectedIndex = -1;
                //cbx_lbjxh.SelectedIndex = -1;
                cbx_lbjgg.DataSource = null;
                cbx_lbjxh.DataSource = null;
            }

        }

        /// <summary>
        /// 型号选择变化，加载位置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_lbjxh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_lbjxh.SelectedIndex >= 0)
            {
                Sqlstr = string.Format("SELECT DISTINCT {0} FROM {1} WHERE {2}='{3}' AND {4} = '{5}'", lbjbiao_djgbm, lbjbiao, lbjbiao_lbjmc, cbx_lbjmc.Text, lbjbiao_lbjxh, cbx_lbjxh.Text);
                cbx_djgbm.DataSource = SQL.DataReadList(Sqlstr);
            }
            else
            {
                cbx_djgbm.DataSource = null;
            }

        }

        /// <summary>
        /// 刀具柜编码选择变化，加载具体位置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_djgbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_djgbm.SelectedIndex >= 0)
            {
                Sqlstr = string.Format("SELECT DISTINCT {0} FROM {1} WHERE {2}='{3}' AND {4} = '{5}' AND {6}='{7}'", lbjbiao_jtwz, lbjbiao, lbjbiao_lbjmc, cbx_lbjmc.Text, lbjbiao_lbjxh, cbx_lbjxh.Text, lbjbiao_djgbm, cbx_djgbm.Text);
                cbx_cfwz.DataSource = SQL.DataReadList(Sqlstr);
            }
            else
            {
                cbx_cfwz.DataSource = null;
            }
        }

        /// <summary>
        /// 零部件具体存放位置选择变化，加载相应库存数量和单位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_cfwz_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_cfwz.SelectedIndex >= 0)
            {
                Sqlstr = string.Format("SELECT {0} AS kcsl, {1} AS dw FROM {2} WHERE {3}='{4}' AND {5}='{6}' AND {7}='{8}' AND {9}='{10}'", lbjbiao_kcsl, lbjbiao_dw, lbjbiao, lbjbiao_lbjmc, cbx_lbjmc.Text, lbjbiao_lbjxh, cbx_lbjxh.Text, lbjbiao_djgbm, cbx_djgbm.Text, lbjbiao_jtwz, cbx_cfwz.Text);
                DataTable db = (SQL.getDataSet(Sqlstr, lbjbiao)).Tables[0];
                txt_kcsl.Text = db.Rows[0]["kcsl"].ToString();
                txt_dw1.Text = db.Rows[0]["dw"].ToString();
                txt_dw2.Text = txt_dw1.Text;
            }
            else
            {
                txt_kcsl.Text = "";
                txt_dw1.Text = "";
                txt_dw2.Text = "";
            }
        }

        #endregion 明细内容编辑--联动部分结束

        /// <summary>
        /// 选中行数据填充明细可编辑部分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lingyongmingxi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = lingyongmingxi.CurrentRow.Index;

            //选中表头和最后一行不进行填充
            if (rowindex >= 0 && rowindex < lingyongmingxi.Rows.Count - 1)
            {
                //选中的行数据格式化
                string row_mc = lingyongmingxi.Rows[rowindex].Cells["lbjmc"].Value.ToString();//零部件名称
                string row_gg = lingyongmingxi.Rows[rowindex].Cells["lbjgg"].Value.ToString();//零部件规格
                string row_xh = lingyongmingxi.Rows[rowindex].Cells["lbjxh"].Value.ToString();//零部件型号
                string row_kcwz = lingyongmingxi.Rows[rowindex].Cells["kcwz"].Value.ToString();//库存位置
                string row_djgbm = row_kcwz.Substring(0, row_kcwz.Length - 4);//还原库存位置的刀具柜编码
                string row_cfwz = row_kcwz.Substring(row_kcwz.Length - 2);//还原库存位置的具体层数
                string row_kcsl = lingyongmingxi.Rows[rowindex].Cells["kcsl"].Value.ToString();//库存数量
                string row_dw = lingyongmingxi.Rows[rowindex].Cells["dw"].Value.ToString();//单位
                string row_sl = lingyongmingxi.Rows[rowindex].Cells["lysl"].Value.ToString();//领用数量
                string row_jc = lingyongmingxi.Rows[rowindex].Cells["jcbm"].Value.ToString();//领用机床
                string row_gx = lingyongmingxi.Rows[rowindex].Cells["gx"].Value.ToString();//相关工序
                string row_bz = lingyongmingxi.Rows[rowindex].Cells["bz"].Value.ToString();//备注

                //如果选中行的领用设备和相关工序为空，则默认填充领用信息中的机床和工序信息
                if (row_jc == "" || row_jc == null)
                {
                    row_jc = LYSB.Text;
                }
                if (row_gx == "" || row_gx == null)
                {
                    row_gx = ZJGX.Text;
                }
                if(row_bz == "" || row_bz == null)
                {
                    row_bz = beizhu.Text;
                }

                //数据填充
                cbx_lbjmc.Text = row_mc;
                cbx_lbjgg.Text = row_gg;
                cbx_lbjxh.Text = row_xh;
                cbx_djgbm.Text = row_djgbm;
                cbx_cfwz.Text = row_cfwz;
                txt_kcsl.Text = row_kcsl;
                txt_dw1.Text = row_dw;
                txt_dw2.Text = row_dw;
                txt_lysl.Text = row_sl;
                cbx_lyjc.Text = row_jc;
                cbx_xggx.Text = row_gx;
                txt_bz.Text = row_bz;
                
            }
        }

        /// <summary>
        /// 新增明细时的数据验证
        /// </summary>
        /// <returns></returns>
        private bool AddDataCheck()
        {
            string tishi = "";

            //零部件名称
            if (cbx_lbjmc.Text == "" || cbx_lbjmc.Text == null || cbx_lbjxh.Text == "" || cbx_lbjxh.Text == null)
            {
                tishi = "请选择要领用的零部件名称和具体型号！";
                MessageBox.Show(tishi, "提示");
                cbx_lbjmc.Focus();
                return false;
            }

            ////零部件规格
            //if (cbx_lbjgg.Text == "" || cbx_lbjgg.Text == null)
            //{
            //    tishi = "请选择领用机床！";
            //    MessageBox.Show(tishi, "提示");
            //    return false;
            //}
            ////零部件型号
            //if (cbx_lbjxh.Text == "" || cbx_lbjxh.Text == null)
            //{
            //    tishi = "请选择领用机床！";
            //    MessageBox.Show(tishi, "提示");
            //    return false;
            //}

            //位置信息
            if (cbx_djgbm.Text == "" || cbx_djgbm.Text == null || cbx_cfwz.Text == "" || cbx_cfwz.Text == null)
            {
                tishi = "请选择要领用的零部件的存储位置！";
                MessageBox.Show(tishi, "提示");
                cbx_djgbm.Focus();
                return false;
            }

            //领用数量判断
            if (txt_lysl.Text == "" || txt_lysl.Text == null)
            {
                tishi = "请填写领用数量！";
                MessageBox.Show(tishi, "提示");
                txt_lysl.Focus();
                return false;
            }

            //领用数量判断
            if (Convert.ToInt16(txt_kcsl.Text.ToString().Trim()) < Convert.ToInt16(txt_lysl.Text.ToString().Trim()))
            {
                tishi = "领用数量必须低于库存数量！";
                MessageBox.Show(tishi, "提示");
                txt_lysl.Focus();
                return false;
            }

            //领用机床
            if (cbx_lyjc.Text == "" || cbx_lyjc.Text == null)
            {
                tishi = "请选择领用机床！";
                MessageBox.Show(tishi, "提示");
                cbx_lyjc.Focus();
                return false;
            }

            //加工工序
            if (cbx_xggx.Text == "" || cbx_xggx.Text == null)
            {
                tishi = "请选择相关工序！";
                MessageBox.Show(tishi, "提示");
                cbx_xggx.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// AddData函数，向datagridview中增加一行数据,.之前的弹窗设计，已弃用！
        /// </summary>
        /// <param name="list">子窗体传输过来的list值</param>
        public void AddData(List<string> list)
        {
            //if (lingyongmingxi.DataSource == null)//新单据，未绑定数据源
            //{
            //    DataGridViewRow row = new DataGridViewRow();
            //    row.CreateCells(lingyongmingxi);

            //    row.Cells[0].Value = list[0];//零部件名称
            //    row.Cells[1].Value = list[1];//零部件规格
            //    row.Cells[2].Value = list[2];//零部件型号
            //    row.Cells[3].Value = list[3];//数量
            //    row.Cells[4].Value = list[4];//单位
            //    row.Cells[5].Value = list[5];//机床编码
            //    row.Cells[6].Value = list[6];//工序
            //    row.Cells[7].Value = list[7];//备注

            //    lingyongmingxi.Rows.Add(row);
            //}
            //else//暂存的单据，领用明细datagridview已经绑定数据源
            //{
            //    //lingyongmingxi.DataSource = null;
            //    //lingyongmingxi.Rows.Add(row);

            //    DataRow rowrow = lymx_db.NewRow();

            //    rowrow["lbjmc"] = list[0];//零部件名称
            //    rowrow["lbjgg"] = list[1];//零部件规格
            //    rowrow["lbjxh"] = list[2];//零部件型号
            //    rowrow["sl"] = list[3];//数量
            //    rowrow["dw"] = list[4];//单位
            //    rowrow["jcbm"] = list[5];//机床编码
            //    rowrow["gx"] = list[6];//工序
            //    rowrow["bz"] = list[7];//备注

            //    lymx_db.Rows.Add(rowrow);
            //}

            //HJ++;//合计数量加一
            //heji.Text = HJ.ToString();//更新合计数量
        }

        #endregion 明细部分结束

/*--------------------------------------------单据按钮部分------------------------------------------------------------------------------------------------------*/
        #region 单据按钮部分
        /// <summary>
        /// 保存单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (LYBZ.Text == "" && LYR.Text == "" && LYSB.Text == "" && JBR.Text == "" && ZJGX.Text == "" && lingyongmingxi.Rows.Count == 1)//未填写任何内容，提示取消填写单据
            {
                if (MessageBox.Show("当前单据为空，要直接取消填写单据？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                //将领用和操作数据存入数据库lbj_lingyong表
                //数据预处理
                string dh = danhao.Text.ToString().Trim();
                string djzt = "0";//单据状态,可再次修改
                string lybz = LYBZ.Text.ToString().Trim();//领用班组
                string lysb = LYSB.Text.ToString().Trim();//领用设备
                string lyr = LYR.Text.ToString().Trim();//领用人
                string zjgx = ZJGX.Text.ToString().Trim();//制件工序
                string lyrq = LYRQ.Value.ToString();//领用日期
                string bz = beizhu.Text.ToString().Trim();//备注
                string jbr = JBR.Text.ToString().Trim();//经办人

                if (Alex.CunZai(danhao.Text.ToString(), DHZD, danjubiao) != 0)//判断此单号在单据表中是否已存在
                {
                    //使用update语句
                    Sqlstr = string.Format("UPDATE {0} SET lybz = '{1}', lysb = '{2}', lyr = '{3}', zjgx = '{4}', lyrq = '{5}', beizhu = '{6}', jbr = '{7}', djzt = '{8}' WHERE {9} = '{10}'", danjubiao, lybz, lysb, lyr, zjgx, lyrq, bz, jbr, djzt, DHZD, dh);
                }
                else
                {
                    //直接使用insert语句
                    Sqlstr = string.Format("INSERT INTO {0}(danhao, lybz, lysb, lyr, zjgx, lyrq, beizhu, jbr, djzt) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", danjubiao, dh, lybz, lysb, lyr, zjgx, lyrq, bz, jbr, djzt);
                }

                //执行sql语句,row1为受影响的行数
                int row1 = SQL.ExecuteNonQuery(Sqlstr);

                //将领用明细数据存入数据库daojuchucangmingxi表
                int row2 = 0;
                if (row1 != 0)
                {
                    if (Alex.CunZai(danhao.Text.ToString(), DHZD, mingxibiao) != 0)//判断此单号在明细表中是否已存在
                    {
                        //使用delete语句删除已存在的明细
                        Sqlstr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", mingxibiao, DHZD, dh);
                        row2 = SQL.ExecuteNonQuery(Sqlstr);
                    }
                    //出仓明细数据格式化
                    for (int rowindex = 0; rowindex < lingyongmingxi.Rows.Count - 1; rowindex++)
                    {
                        string lbjmc = lingyongmingxi.Rows[rowindex].Cells["lbjmc"].Value.ToString();
                        string lbjgg = lingyongmingxi.Rows[rowindex].Cells["lbjgg"].Value.ToString();
                        string lbjxh = lingyongmingxi.Rows[rowindex].Cells["lbjxh"].Value.ToString();

                        string kcwz = lingyongmingxi.Rows[rowindex].Cells["kcwz"].Value.ToString();
                        string kcwz_wz = kcwz.Substring(0, kcwz.Length - 4);
                        string kcwz_cs = kcwz.Substring(kcwz.Length - 2);

                        string kcsl = lingyongmingxi.Rows[rowindex].Cells["kcsl"].Value.ToString();
                        string dw = lingyongmingxi.Rows[rowindex].Cells["dw"].Value.ToString();
                        string lysl = lingyongmingxi.Rows[rowindex].Cells["lysl"].Value.ToString();
                        string jcbm = lingyongmingxi.Rows[rowindex].Cells["jcbm"].Value.ToString();
                        string gx = lingyongmingxi.Rows[rowindex].Cells["gx"].Value.ToString();
                        string beizhu = lingyongmingxi.Rows[rowindex].Cells["bz"].Value.ToString();

                        //存入流水表
                        //Sqlstr = string.Format("INSERT INTO {0}(danhao, dhlx, lbjmc, lbjgg, lbjxh, djgbm, jtwz, zsl, fsl, dskykc, dw, czsj, jbr, bz) VALUES('{1}', '零部件领用', '{2}', '{3}', '{4}', '{5}', '{6}', '0', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", liushuibiao, dh, lbjmc, lbjgg, lbjxh, kcwz_wz, kcwz_cs, lysl, kcsl, dw, DateTime.Now, jbr, beizhu);
                        //row2 = SQL.ExecuteNonQuery(Sqlstr);//执行sql语句,row2为受影响的行数

                        //存入明细表
                        Sqlstr = string.Format("INSERT INTO {0}(danhao, lbjmc, lbjgg, lbjxh, djgbm, jtwz, lysl, dw, wzbs, jcbm, gx, bz) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", mingxibiao, dh, lbjmc, lbjgg, lbjxh, kcwz_wz, kcwz_cs, lysl, dw, 'M', jcbm, gx, beizhu);
                        row2 = SQL.ExecuteNonQuery(Sqlstr);//执行sql语句,row2为受影响的行数

                        //更新库存表
                        //Sqlstr = string.Format("UPDATE {0} SET {1} = {1} - {2} WHERE {3}='{4}' AND {5}='{6}' AND {7}='{8}' AND {9}='{10}'", lbjbiao, lbjbiao_kcsl, Convert.ToInt16(lysl), lbjbiao_lbjmc, lbjmc, lbjbiao_lbjxh, lbjxh, lbjbiao_djgbm, kcwz_wz, lbjbiao_jtwz, kcwz_cs);
                        //row2 = SQL.ExecuteNonQuery(Sqlstr);//执行sql语句,row2为受影响的行数
                    }

                    
                    if (row2 != 0)
                    {
                        MessageBox.Show("单据保存成功，可再次修改确认！", "提示", MessageBoxButtons.OK);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("领用明细数据填写有误，请检查并重试！", "警告", MessageBoxButtons.OK);
                    }
                }
            }
        }

        /// <summary>
        /// 确认单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否确认领用？确认后单据不可修改！", "领用确认", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //数据验证
                if (CheckData() == 0)
                {
                    return;//数据输入有误
                }
                else
                {
                    //将领用和操作数据存入数据库lbj_lingyong表
                    //数据预处理
                    string dh = danhao.Text.ToString().Trim();
                    string djzt = "1";//单据状态
                    string lybz = LYBZ.Text.ToString().Trim();//领用班组
                    string lysb = LYSB.Text.ToString().Trim();//领用设备
                    string lyr = LYR.Text.ToString().Trim();//领用人
                    string zjgx = ZJGX.Text.ToString().Trim();//制件工序
                    string lyrq = LYRQ.Value.ToString();//领用日期
                    string bz = beizhu.Text.ToString().Trim();//备注
                    string jbr = JBR.Text.ToString().Trim();//经办人

                    if (Alex.CunZai(danhao.Text.ToString(), DHZD, danjubiao) != 0)//判断此单号在单据表中是否已存在
                    {
                        //使用update语句
                        Sqlstr = string.Format("UPDATE {0} SET lybz = '{1}', lysb = '{2}', lyr = '{3}', zjgx = '{4}', lyrq = '{5}', beizhu = '{6}', jbr = '{7}', djzt = '{8}' WHERE {9} = '{10}'", danjubiao, lybz, lysb, lyr, zjgx, lyrq, bz, jbr, djzt, DHZD, dh);
                    }
                    else
                    {
                        //直接使用insert语句
                        Sqlstr = string.Format("INSERT INTO {0}(danhao, lybz, lysb, lyr, zjgx, lyrq, beizhu, jbr, djzt) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')", danjubiao, dh, lybz, lysb, lyr, zjgx, lyrq, bz, jbr, djzt);
                    }

                    int row1 = SQL.ExecuteNonQuery(Sqlstr);

                    //将领用明细数据存入数据库lbj_lingyongmingxi表
                    int row2 = 0;//记录插入明细表数据
                    int row3 = 0;//记录插入流水表数据
                    if (row1 != 0)
                    {
                        if (Alex.CunZai(danhao.Text.ToString(), DHZD, mingxibiao) != 0)//判断此单号在明细表中是否已存在
                        {
                            //使用delete语句删除已存在的明细
                            Sqlstr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", mingxibiao, DHZD, dh);
                            row2 = SQL.ExecuteNonQuery(Sqlstr);
                        }
                        //明细数据格式化
                        for (int rowindex = 0; rowindex < lingyongmingxi.Rows.Count - 1; rowindex++)
                        {
                            string lbjmc = lingyongmingxi.Rows[rowindex].Cells["lbjmc"].Value.ToString();
                            string lbjgg = lingyongmingxi.Rows[rowindex].Cells["lbjgg"].Value.ToString();
                            string lbjxh = lingyongmingxi.Rows[rowindex].Cells["lbjxh"].Value.ToString();

                            string kcwz = lingyongmingxi.Rows[rowindex].Cells["kcwz"].Value.ToString();
                            string kcwz_wz = kcwz.Substring(0, kcwz.Length - 4);
                            string kcwz_cs = kcwz.Substring(kcwz.Length - 2);

                            string kcsl = lingyongmingxi.Rows[rowindex].Cells["kcsl"].Value.ToString();
                            string dw = lingyongmingxi.Rows[rowindex].Cells["dw"].Value.ToString();
                            string lysl = lingyongmingxi.Rows[rowindex].Cells["lysl"].Value.ToString();
                            string jcbm = lingyongmingxi.Rows[rowindex].Cells["jcbm"].Value.ToString();
                            string gx = lingyongmingxi.Rows[rowindex].Cells["gx"].Value.ToString();
                            string beizhu = lingyongmingxi.Rows[rowindex].Cells["bz"].Value.ToString();

                            //存入流水表
                            Sqlstr = string.Format("INSERT INTO {0}(danhao, dhlx, lbjmc, lbjgg, lbjxh, djgbm, jtwz, zsl, fsl, dskykc, dw, czsj, jbr, bz) VALUES('{1}', '零部件领用', '{2}', '{3}', '{4}', '{5}', '{6}', '0', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", liushuibiao, dh, lbjmc, lbjgg, lbjxh, kcwz_wz, kcwz_cs, lysl, kcsl, dw, DateTime.Now, jbr, beizhu);
                            row3 = SQL.ExecuteNonQuery(Sqlstr);//执行sql语句,row2为受影响的行数

                            //存入明细表
                            Sqlstr = string.Format("INSERT INTO {0}(danhao, lbjmc, lbjgg, lbjxh, djgbm, jtwz, lysl, dw, wzbs, jcbm, gx, bz) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", mingxibiao, dh, lbjmc, lbjgg, lbjxh, kcwz_wz, kcwz_cs, lysl, dw, 'M', jcbm, gx, beizhu);
                            row2 = SQL.ExecuteNonQuery(Sqlstr);//执行sql语句,row2为受影响的行数

                            //更新库存表
                            Sqlstr = string.Format("UPDATE {0} SET {1} = {1} - {2} WHERE {3}='{4}' AND {5}='{6}' AND {7}='{8}' AND {9}='{10}'", lbjbiao, lbjbiao_kcsl, Convert.ToInt16(lysl), lbjbiao_lbjmc, lbjmc, lbjbiao_lbjxh, lbjxh, lbjbiao_djgbm, kcwz_wz, lbjbiao_jtwz, kcwz_cs);
                            row2 = SQL.ExecuteNonQuery(Sqlstr);//执行sql语句,row2为受影响的行数
                        }

                        if (row2 != 0)
                        {
                            MessageBox.Show("单据确认成功！", "提示", MessageBoxButtons.OK);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("领用明细数据填写有误，请检查并重试！", "警告", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 打印单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //数据验证
            if (CheckData() == 0)
            {
                return;//数据输入有误
            }
            else
            {
                DataSet FRds = new DataSet();
                DataTable table1 = new DataTable();//存放领用明细数据
                table1.TableName = "Table1"; // 一定要设置表名称

                // 添加表中的列
                table1.Columns.Add("xh", typeof(string));//序号
                table1.Columns.Add("lbjmc", typeof(string));//零部件名称
                table1.Columns.Add("lbjgg", typeof(string));//零部件规格
                table1.Columns.Add("lbjxh", typeof(string));//零部件型号
                table1.Columns.Add("kcwz", typeof(string));//库存位置
                table1.Columns.Add("lysl", typeof(string));//领用数量
                table1.Columns.Add("dw", typeof(string));//单位
                table1.Columns.Add("jcbm", typeof(string));//机床编码
                table1.Columns.Add("gx", typeof(string));//工序
                table1.Columns.Add("bz", typeof(string));//备注

                //添加明细数据
                for (int rowindex = 0; rowindex < lingyongmingxi.Rows.Count - 1; rowindex++)
                {
                    //格式化刀具数据
                    string lbjmc = lingyongmingxi.Rows[rowindex].Cells["lbjmc"].Value.ToString();
                    string lbjgg = lingyongmingxi.Rows[rowindex].Cells["lbjgg"].Value.ToString();
                    string lbjxh = lingyongmingxi.Rows[rowindex].Cells["lbjxh"].Value.ToString();
                    string kcwz = lingyongmingxi.Rows[rowindex].Cells["kcwz"].Value.ToString();
                    string lysl = lingyongmingxi.Rows[rowindex].Cells["lysl"].Value.ToString();
                    string dw = lingyongmingxi.Rows[rowindex].Cells["dw"].Value.ToString();
                    string jcbm = lingyongmingxi.Rows[rowindex].Cells["jcbm"].Value.ToString();
                    string gx = lingyongmingxi.Rows[rowindex].Cells["gx"].Value.ToString();
                    string bz = lingyongmingxi.Rows[rowindex].Cells["bz"].Value.ToString();

                    DataRow row = table1.NewRow();
                    row["xh"] = rowindex + 1;
                    row["lbjmc"] = lbjmc;
                    row["lbjgg"] = lbjgg;
                    row["lbjxh"] = lbjxh;
                    row["kcwz"] = kcwz;
                    row["lysl"] = lysl;
                    row["dw"] = dw;
                    row["jcbm"] = jcbm;
                    row["gx"] = gx;
                    row["bz"] = bz;

                    table1.Rows.Add(row);
                }

                FRds.Tables.Add(table1);

                Report FReport = new Report();
                string sPath = @"../../File/零部件领用单.frx";
                FReport.Load(sPath);  // 将DataSet对象注册到FastReport控件中
                FReport.RegisterData(FRds);//FReport.RegisterData(ds1);

                FReport.SetParameterValue("danhao", danhao.Text);
                FReport.SetParameterValue("lybz", LYBZ.Text);
                FReport.SetParameterValue("lysb", LYSB.Text);
                FReport.SetParameterValue("lyr", LYR.Text);
                FReport.SetParameterValue("zjgx", ZJGX.Text);
                FReport.SetParameterValue("beizhu", beizhu.Text);
                FReport.SetParameterValue("jbr", JBR.Text);
                FReport.SetParameterValue("lyrq", LYRQ.Text);

                //显示报表
                FReport.Prepare();
                FReport.ShowPrepared();
                //FReport.Show();
            }
        }

        /// <summary>
        /// 删除单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(Alex.CunZai(danhao.Text.ToString().Trim(), DHZD, danjubiao) != 0)
            {
                DialogResult dr = MessageBox.Show("确认删除此单据？", "删除确认", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //删除领用表中的数据
                    Sqlstr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", danjubiao, DHZD, danhao.Text.ToString().Trim());
                    int row1 = SQL.ExecuteNonQuery(Sqlstr);

                    Sqlstr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", mingxibiao, mingxibiao, danhao.Text.ToString().Trim());
                    int row2 = SQL.ExecuteNonQuery(Sqlstr);
                    MessageBox.Show("成功删除一张单据和" + row2 + "条明细记录！");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else//数据库不存在
            {
                MessageBox.Show("单据还未保存，不可删除！", "提示", MessageBoxButtons.OK);
            }
            
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

        #endregion 单据按钮部分结束

/*--------------------------------------------其他方法部分------------------------------------------------------------------------------------------------------*/
        #region 其他方法
        /// <summary>
        /// 单据数据验证
        /// </summary>
        /// <returns></returns>
        private int CheckData()
        {
            //提示内容清空
            tishi = "";
            if (LYBZ.Text == "" || LYR.Text == "" || JBR.Text == "")
            {
                if (LYBZ.Text.ToString() == "")
                {
                    tishi = "请填写领用班组！";
                }
                else if (LYR.Text.ToString() == "")
                {
                    tishi = "请填写领用人！";
                }
                else if (JBR.Text.ToString() == "")
                {
                    tishi = "请填写经办人！";
                }
                //MessageBox.Show(tishi, "警告", MessageBoxButtons.OK);
            }
            else if (ZJGX.Text == "")
            {
                tishi = "请选择与之相关的制件工序！";
            }

            if (lingyongmingxi.Rows.Count == 1)
            {
                tishi = "领用明细不能为空！";
            }

            for(int i = 0; i < lingyongmingxi.Rows.Count - 1; i++)//有一行空白行
            {
                if(lingyongmingxi.Rows[i].Cells["lysl"].Value.ToString() == "" || lingyongmingxi.Rows[i].Cells["jcbm"].Value.ToString() == "" || lingyongmingxi.Rows[i].Cells["gx"].Value.ToString() == "")
                {
                    tishi = "请将明细内容补充完整！";
                    lingyongmingxi.Rows[i].Selected = true;
                    lingyongmingxi.CurrentCell = lingyongmingxi.Rows[i].Cells[0];
                    lingyongmingxi_CellClick(null, null);
                    break;
                }
            }

            if (tishi != "")
            {
                MessageBox.Show(tishi, "警告", MessageBoxButtons.OK);
                return 0;
            }
            else
                return 1;
        }

        /// <summary>
        /// 窗体大小自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LBJLY_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        /// <summary>
        /// 通过总表勾选名称增加明细，即可以通过选择多条记录一并新增明细
        /// </summary>
        /// <param name="tb">要新增的明细表部分内容</param>
        public void AddDataFromTable(DataTable tb)
        {
            //lymx_db.Columns.Add("lbjmc", System.Type.GetType("System.String"));
            //lymx_db.Columns.Add("lbjgg", System.Type.GetType("System.String"));
            //lymx_db.Columns.Add("lbjxh", System.Type.GetType("System.String"));
            //lymx_db.Columns.Add("kcwz", System.Type.GetType("System.String"));
            //lymx_db.Columns.Add("kcsl", System.Type.GetType("System.String"));
            //lymx_db.Columns.Add("dw", System.Type.GetType("System.String"));
            //lymx_db.Columns.Add("lysl", System.Type.GetType("System.String"));
            //lymx_db.Columns.Add("jcbm", System.Type.GetType("System.String"));
            //lymx_db.Columns.Add("gx", System.Type.GetType("System.String"));
            //lymx_db.Columns.Add("bz", System.Type.GetType("System.String"));

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                DataRow rowrow = lymx_db.NewRow();

                rowrow["lbjmc"] = tb.Rows[i]["lbjmc"];//零部件名称
                rowrow["lbjgg"] = tb.Rows[i]["lbjgg"];//零部件规格
                rowrow["lbjxh"] = tb.Rows[i]["lbjxh"];//零部件型号
                rowrow["kcwz"] = tb.Rows[i]["kcwz"];//库存位置
                rowrow["kcsl"] = tb.Rows[i]["kcsl"];//库存数量
                rowrow["dw"] = tb.Rows[i]["dw"];//单位
                rowrow["lysl"] = "";//领用数量
                rowrow["jcbm"] = "";//机床编码
                rowrow["gx"] = "";//工序
                rowrow["bz"] = "";//备注
                
                lymx_db.Rows.Add(rowrow);
            }

            lingyongmingxi.DataSource = lymx_db.DefaultView;
            heji.Text = HJ.ToString();
        }

        /// <summary>
        /// 当窗体在选项卡中打开时，关闭窗体则关闭相应的选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LBJLY_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Parent != null)
            {
                MainForm mfr = (MainForm)this.Parent.FindForm();
                mfr.CloseTab(this.Name);
            }
        }

        /// <summary>
        /// 为明细表塑造数据源
        /// </summary>
        private void AddColumns()
        {
            lymx_db.Columns.Add("lbjmc", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("lbjgg", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("lbjxh", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("kcwz", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("kcsl", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("dw", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("lysl", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("jcbm", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("gx", System.Type.GetType("System.String"));
            lymx_db.Columns.Add("bz", System.Type.GetType("System.String"));
        }

        #endregion 其他方法结束
    }
}
