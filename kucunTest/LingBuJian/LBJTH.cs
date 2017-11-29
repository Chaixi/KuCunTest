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
    public partial class LBJTH : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string SqlStr = "";

        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();//窗口自适应类

        DataTable thmx_db = new DataTable();//退还明细数据源

        string TYPE = "LBJTH";
        int HJ = 0;//合计刀具数量

        bool zancun = false;//是否是暂存单据
        bool queren = false;//是否是已确认单据
        string tishi = "";//提示文本

        string LogType = "零部件退还";
        string LogMessage = "";

        //和数据库查询有关的表名、字段名
        //string DanJuBiao = "lbj_tuihuan";
        //string MingXiBiao = "lbj_tuihuanmingxi";
        //string DanHaoZD = "danhao";
        //string LiuShuiBiao = "lbj_liushui";

        //零部件表
        //string lbjbiao = "jichuxinxi";
        //string lbjbiao_lbjmc = "daojuid";
        //string lbjbiao_lbjgg = "daojuguige";
        //string lbjbiao_lbjxh = "daojuxinghao";
        //string lbjbiao_djgbm = "weizhi";
        //string lbjbiao_jtwz = "cengshu";
        //string lbjbiao_kcsl = "kcsl";
        //string lbjbiao_dw = "danwei";

        #endregion

/*---------------------------------------------------------构造函数与窗体加载部分---------------------------------------------------------------------------------------------------------*/
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public LBJTH()
        {
            InitializeComponent();

            THDH.Text = Alex.DanHao("LBJTH");//自动生成单号

            //加载班组
            THBZ.DataSource = Alex.GetList("bz");
            THBZ.SelectedIndex = -1;

            JBR.SelectedIndex = 0;
            THYY.Text = "机床退还。";//默认退还原因为"机床常规退还。"
            heji.Text = HJ.ToString();
            THRQ.Value = DateTime.Now;//退还日期为当前日期

            loadData();
            cbx_lbjmc.SelectedIndex = -1;

            AddColumns();
            TuiHuanMingXi.AutoGenerateColumns = false;//禁止自动生成列
            TuiHuanMingXi.DataSource = thmx_db.DefaultView;
            TuiHuanMingXi.CurrentCell = null;
        }

        /// <summary>
        /// 重写构造函数，用于从历史记录窗体加载数据
        /// </summary>
        /// <param name="dh"></param>
        public LBJTH(string dh)
        {
            InitializeComponent();

            loadData();
            cbx_lbjmc.SelectedIndex = -1;

            //根据单号查询数据库退还和操作信息
            SqlStr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", lbjTuiHuan.TableName, lbjTuiHuan.danhao, dh);
            DataSet ds = SQL.getDataSet(SqlStr, lbjTuiHuan.TableName);

            //给退还信息和操作信息赋值
            THDH.Text = dh;//单号
            THBZ.Text = ds.Tables[0].Rows[0]["thbz"].ToString();//退还班组
            THR.Text = ds.Tables[0].Rows[0]["thr"].ToString();//退还人
            THRQ.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["thrq"].ToString());//退还日期
            THYY.Text = ds.Tables[0].Rows[0]["thyy"].ToString();//退还原因
            JBR.Text = ds.Tables[0].Rows[0]["jbr"].ToString();//经办人
            JBRQ.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["jbrq"].ToString());//经办日期
            string djzt = ds.Tables[0].Rows[0]["djzt"].ToString();//单据状态

            //根据单号查询明细信息
            SqlStr = string.Format("SELECT t.lbjmc, t.lbjgg, t.lbjxh, t.jcbm, t.gx, CONCAT(t.djgbm, '--', t.cfwz) AS kcwz, j.kcsl AS kcsl, t.sl AS thsl, t.dw, t.bz FROM {0} t INNER JOIN {3} j ON t.lbjmc = j.daojuid AND t.lbjxh = j.daojuxinghao AND t.djgbm = j.weizhi AND t.cfwz = j.cengshu WHERE {1} = '{2}'", lbjTuiHuanMingXi.TableName, lbjTuiHuanMingXi.danhao, dh, LingBuJianBiao.TableName);
            //SqlStr = string.Format("SELECT lbjmc, lbjgg, lbjxh, CONCAT(djgbm, '--', cfwz) AS kcwz, sl AS thsl, dw, jcbm, gx, bz FROM {0} WHERE {1} = '{2}'", MingXiBiao, DanHaoZD, dh);
            //SqlStr = string.Format("SELECT mx.lbjmc AS lbjmc, mx.lbjgg AS lbjgg, mx.lbjxh AS lbjxh, CONCAT(mx.djgbm, '--', mx.cfwz) AS kcwz, ls.dskykc AS kcsl, mx.sl AS thsl, mx.dw AS dw, mx.jcbm AS jcbm, mx.gx AS gx, mx.bz AS bz FROM {0} mx LEFT JOIN {1} ls ON mx.danhao=ls.danhao WHERE mx.lbjxh=ls.lbjxh AND mx.djgbm = ls.djgbm AND mx.cfwz=ls.jtwz AND mx.{2}='{3}'", MingXiBiao, LiuShuiBiao, DanHaoZD, dh);

            thmx_db.Reset();//重置数据表
            thmx_db = (SQL.getDataSet(SqlStr, lbjTuiHuanMingXi.TableName)).Tables[0];//用全局变量保存查询出来的明细，方便后续可以继续添加
            TuiHuanMingXi.AutoGenerateColumns = false;
            TuiHuanMingXi.DataSource = thmx_db.DefaultView;

            //更新合计数量
            for (int i = 0; i < thmx_db.Rows.Count; i++)
            {
                HJ = HJ + Convert.ToInt16(thmx_db.Rows[i]["thsl"].ToString());
            }
            heji.Text = HJ.ToString();

            //若是已完成的单据，则只允许查看，不许修改。
            if (djzt == "1")
            {
                Alex.DisableAllControl(this);
                button_print.Enabled = true;
                button_delete.Enabled = true;
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
        private void LBJTH_Load(object sender, EventArgs e)
        {
            //asc.controllInitializeSize(this);
        }

        /*----------------------------------------------------------------明细部分-----------------------------------------------------------------------------------------------------------------*/
        #region 明细部分
        /// <summary>
        /// datagridview每一行自动生成序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TuiHuanMingXi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(TuiHuanMingXi, e);
        }

        /// <summary>
        /// 明细--新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMXNew_Click(object sender, EventArgs e)
        {
            if (AddDataCheck())//进行数据验证
            {
                //暂存单据，领用明细datagridview已经绑定数据源
                //if (zancun)
                //{
                    DataRow rowrow = thmx_db.NewRow();

                    rowrow["lbjmc"] = cbx_lbjmc.Text.ToString();//零部件名称
                    rowrow["lbjgg"] = cbx_lbjgg.Text.ToString();//零部件规格
                    rowrow["lbjxh"] = cbx_lbjxh.Text.ToString();//零部件型号
                    rowrow["kcwz"] = (cbx_djgbm.Text + "--" + cbx_cfwz.Text).ToString();//库存位置
                    rowrow["kcsl"] = Convert.ToInt16(txt_kcsl.Text);//库存数量
                    rowrow["thsl"] = Convert.ToInt16(txt_thsl.Text);//领用数量
                    rowrow["dw"] = txt_dw1.Text;//单位
                    rowrow["jcbm"] = cbx_ssjc.Text.ToString();//领用机床编码
                    rowrow["gx"] = cbx_xggx.Text.ToString();//相关工序
                    rowrow["bz"] = txt_bz.Text.ToString();//备注

                    thmx_db.Rows.Add(rowrow);
                //}
                //else
                //{
                //    DataGridViewRow row = new DataGridViewRow();
                //    row.CreateCells(TuiHuanMingXi);

                //    row.Cells[0].Value = cbx_lbjmc.Text;//零部件名称
                //    row.Cells[1].Value = cbx_lbjgg.Text;//零部件规格
                //    row.Cells[2].Value = cbx_lbjxh.Text;//零部件型号
                //    row.Cells[3].Value = cbx_djgbm.Text + "--" + cbx_cfwz.Text;//库存位置
                //    row.Cells[4].Value = txt_kcsl.Text;//库存数量
                //    row.Cells[5].Value = txt_dw1.Text;//单位
                //    row.Cells[6].Value = txt_thsl.Text;//领用数量
                //    row.Cells[7].Value = cbx_ssjc.Text;//领用机床编码
                //    row.Cells[8].Value = cbx_xggx.Text;//相关工序
                //    row.Cells[9].Value = txt_bz.Text;//备注

                //    TuiHuanMingXi.Rows.Add(row);
                //}

                HJ = HJ + Convert.ToInt16(txt_thsl.Text);//合计数量增加
                heji.Text = HJ.ToString();//更新合计数量
            }

            TuiHuanMingXi.CurrentCell = null;//取消选中任何行
        }

        /// <summary>
        /// 明细--修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMXEdit_Click(object sender, EventArgs e)
        {
            //为选中行或者选中的是最后一行
            if (TuiHuanMingXi.SelectedRows.Count <= 0 || TuiHuanMingXi.CurrentRow.Index == TuiHuanMingXi.Rows.Count - 1)
            {
                tishi = "请先选中一行非空白的明细数据！";
                MessageBox.Show(tishi, "提示");
                return;
            }

            if (AddDataCheck())
            {
                int crtrowindex = TuiHuanMingXi.CurrentRow.Index;

                //排除从总表勾选得到的明细数据因没有数量、机床编码、工序、备注而出错的情况
                if (TuiHuanMingXi.Rows[crtrowindex].Cells["mx_thsl"].Value.ToString() != "" && TuiHuanMingXi.Rows[crtrowindex].Cells["mx_thsl"] != null)
                {
                    HJ = HJ - Convert.ToInt16(TuiHuanMingXi.Rows[crtrowindex].Cells["mx_thsl"].Value.ToString());
                }

                TuiHuanMingXi.Rows[crtrowindex].Cells["mx_lbjmc"].Value = cbx_lbjmc.Text;//零部件名称
                TuiHuanMingXi.Rows[crtrowindex].Cells["mx_lbjgg"].Value = cbx_lbjgg.Text;//零部件规格
                TuiHuanMingXi.Rows[crtrowindex].Cells["mx_lbjxh"].Value = cbx_lbjxh.Text;//零部件型号
                TuiHuanMingXi.Rows[crtrowindex].Cells["mx_jcbm"].Value = cbx_ssjc.Text;//退还机床编码
                TuiHuanMingXi.Rows[crtrowindex].Cells["mx_gx"].Value = cbx_xggx.Text;//相关工序
                TuiHuanMingXi.Rows[crtrowindex].Cells["mx_thsl"].Value = txt_thsl.Text;//退还数量
                TuiHuanMingXi.Rows[crtrowindex].Cells["mx_dw"].Value = txt_dw1.Text;//单位
                TuiHuanMingXi.Rows[crtrowindex].Cells["mx_kcwz"].Value = cbx_djgbm.Text + "--" + cbx_cfwz.Text;//库存位置
                TuiHuanMingXi.Rows[crtrowindex].Cells["mx_kcsl"].Value = txt_kcsl.Text;//库存数量
                TuiHuanMingXi.Rows[crtrowindex].Cells["mx_bz"].Value = txt_bz.Text;//备注

                HJ = HJ + Convert.ToInt16(txt_thsl.Text);
                heji.Text = HJ.ToString();

                //修改完清除选中行，避免误操作
                TuiHuanMingXi.CurrentCell = null;
            }
        }

        /// <summary>
        /// 明细--删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMXDelete_Click(object sender, EventArgs e)
        {
            int k = TuiHuanMingXi.SelectedRows.Count;
            if (k == 0)
            {
                MessageBox.Show("请先选择至少一行数据！", "提示", MessageBoxButtons.OK);
            }
            else if (TuiHuanMingXi.CurrentRow.Index == TuiHuanMingXi.Rows.Count - 1 || k == TuiHuanMingXi.Rows.Count)//选中的是最后一行
            {
                MessageBox.Show("不能删除空白行！", "警告", MessageBoxButtons.OK);
            }
            else if (k == 1)
            {
                DialogResult result = MessageBox.Show("确定删除" + k + "行数据？", "提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    //排除从总表添加暂未修改领用数量的情况
                    if (TuiHuanMingXi.Rows[TuiHuanMingXi.CurrentRow.Index].Cells["mx_thsl"].Value.ToString() != "" && TuiHuanMingXi.Rows[TuiHuanMingXi.CurrentRow.Index].Cells["mx_thsl"].Value.ToString() != null)
                    {
                        HJ = HJ - Convert.ToInt16(TuiHuanMingXi.Rows[TuiHuanMingXi.CurrentRow.Index].Cells["mx_thsl"].Value.ToString());//合计数量减去本行退还数量
                    }
                    TuiHuanMingXi.Rows.RemoveAt(TuiHuanMingXi.CurrentRow.Index);
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
                        if (TuiHuanMingXi.Rows[TuiHuanMingXi.SelectedRows[i - 1].Index].Cells["mx_thsl"].Value.ToString() != "" && TuiHuanMingXi.Rows[TuiHuanMingXi.SelectedRows[i - 1].Index].Cells["mx_thsl"].Value.ToString() != null)
                        {
                            HJ = HJ - Convert.ToInt16(TuiHuanMingXi.Rows[TuiHuanMingXi.SelectedRows[i - 1].Index].Cells["mx_thsl"].Value.ToString());//合计数量减去本行退还数量
                        }
                        TuiHuanMingXi.Rows.RemoveAt(TuiHuanMingXi.SelectedRows[i - 1].Index);
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
            //string sqlstr2 = "SELECT jichuangbianma FROM jichuang";
            //List<string> list_sb = SQL.DataReadList(sqlstr2);
            cbx_ssjc.DataSource = Alex.GetList("jc");
            cbx_ssjc.SelectedIndex = -1;

            //加载所有零部件名称
            cbx_lbjmc.DataSource = Alex.GetList("lbjmc");
            //sqlstr2 = string.Format("SELECT DISTINCT {0} FROM {1} ORDER BY CONVERT({2} USING gbk) ASC", lbjbiao_lbjmc, lbjbiao, lbjbiao_lbjmc);
            //cbx_lbjmc.DataSource = SQL.DataReadList(sqlstr2);
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
                SqlStr = string.Format("SELECT DISTINCT {0} FROM {1} WHERE {2}='{3}'", LingBuJianBiao.gg, LingBuJianBiao.TableName, LingBuJianBiao.mc, cbx_lbjmc.Text);
                cbx_lbjgg.DataSource = SQL.DataReadList(SqlStr);

                //加载所有型号
                SqlStr = string.Format("SELECT DISTINCT {0} FROM {1} WHERE {2}='{3}'", LingBuJianBiao.xinghao, LingBuJianBiao.TableName, LingBuJianBiao.mc, cbx_lbjmc.Text);
                cbx_lbjxh.DataSource = SQL.DataReadList(SqlStr);

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
                SqlStr = string.Format("SELECT DISTINCT {0} FROM {1} WHERE {2}='{3}' AND {4} = '{5}'", LingBuJianBiao.weizhibianma, LingBuJianBiao.TableName, LingBuJianBiao.mc, cbx_lbjmc.Text, LingBuJianBiao.xinghao, cbx_lbjxh.Text);
                cbx_djgbm.DataSource = SQL.DataReadList(SqlStr);
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
                SqlStr = string.Format("SELECT DISTINCT {0} FROM {1} WHERE {2}='{3}' AND {4} = '{5}' AND {6}='{7}'", LingBuJianBiao.cengshu, LingBuJianBiao.TableName, LingBuJianBiao.mc, cbx_lbjmc.Text, LingBuJianBiao.xinghao, cbx_lbjxh.Text, LingBuJianBiao.weizhibianma, cbx_djgbm.Text);
                cbx_cfwz.DataSource = SQL.DataReadList(SqlStr);
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
                SqlStr = string.Format("SELECT {0} AS kcsl, {1} AS dw FROM {2} WHERE {3}='{4}' AND {5}='{6}' AND {7}='{8}' AND {9}='{10}'", LingBuJianBiao.kcsl, LingBuJianBiao.dw, LingBuJianBiao.TableName, LingBuJianBiao.mc, cbx_lbjmc.Text, LingBuJianBiao.xinghao, cbx_lbjxh.Text, LingBuJianBiao.weizhibianma, cbx_djgbm.Text, LingBuJianBiao.cengshu, cbx_cfwz.Text);
                DataTable db = (SQL.getDataSet(SqlStr, LingBuJianBiao.TableName)).Tables[0];
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
        private void TuiHuanMingXi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = TuiHuanMingXi.CurrentRow.Index;

            //选中表头和最后一行不进行填充
            if (rowindex >= 0 && rowindex < TuiHuanMingXi.Rows.Count - 1)
            {
                //选中的行数据格式化
                string row_mc = TuiHuanMingXi.Rows[rowindex].Cells["mx_lbjmc"].Value.ToString();//零部件名称
                string row_gg = TuiHuanMingXi.Rows[rowindex].Cells["mx_lbjgg"].Value.ToString();//零部件规格
                string row_xh = TuiHuanMingXi.Rows[rowindex].Cells["mx_lbjxh"].Value.ToString();//零部件型号
                string row_kcwz = TuiHuanMingXi.Rows[rowindex].Cells["mx_kcwz"].Value.ToString();//库存位置
                string row_djgbm = row_kcwz.Substring(0, row_kcwz.Length - 4);//还原库存位置的刀具柜编码
                string row_cfwz = row_kcwz.Substring(row_kcwz.Length - 2);//还原库存位置的具体层数
                string row_kcsl = TuiHuanMingXi.Rows[rowindex].Cells["mx_kcsl"].Value.ToString();//库存数量
                string row_dw = TuiHuanMingXi.Rows[rowindex].Cells["mx_dw"].Value.ToString();//单位
                string row_sl = TuiHuanMingXi.Rows[rowindex].Cells["mx_thsl"].Value.ToString();//领用数量
                string row_jc = TuiHuanMingXi.Rows[rowindex].Cells["mx_jcbm"].Value.ToString();//领用机床
                string row_gx = TuiHuanMingXi.Rows[rowindex].Cells["mx_gx"].Value.ToString();//相关工序
                string row_bz = TuiHuanMingXi.Rows[rowindex].Cells["mx_bz"].Value.ToString();//备注

                //数据填充
                cbx_lbjmc.Text = row_mc;
                cbx_lbjgg.Text = row_gg;
                cbx_lbjxh.Text = row_xh;
                cbx_djgbm.Text = row_djgbm;
                cbx_cfwz.Text = row_cfwz;
                txt_kcsl.Text = row_kcsl;
                txt_dw1.Text = row_dw;
                txt_dw2.Text = row_dw;
                txt_thsl.Text = row_sl;
                cbx_ssjc.Text = row_jc;
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
            tishi = "";

            //零部件名称
            if (cbx_lbjmc.Text == "" || cbx_lbjmc.Text == null || cbx_lbjxh.Text == "" || cbx_lbjxh.Text == null)
            {
                tishi = "请选择要退还的零部件名称和具体型号！";
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
                tishi = "请选择要退还零部件的存储位置！";
                MessageBox.Show(tishi, "提示");
                cbx_djgbm.Focus();
                return false;
            }

            //退还数量判断
            if (txt_thsl.Text == "" || txt_thsl.Text == null)
            {
                tishi = "请填写退还数量！";
                MessageBox.Show(tishi, "提示");
                txt_thsl.Focus();
                return false;
            }

            //领用数量判断
            //if (Convert.ToInt16(txt_kcsl.Text.ToString().Trim()) < Convert.ToInt16(txt_lysl.Text.ToString().Trim()))
            //{
            //    tishi = "领用数量必须低于库存数量！";
            //    MessageBox.Show(tishi, "提示");
            //    txt_lysl.Focus();
            //    return false;
            //}

            //领用机床
            //if (cbx_lyjc.Text == "" || cbx_lyjc.Text == null)
            //{
            //    tishi = "请选择领用机床！";
            //    MessageBox.Show(tishi, "提示");
            //    cbx_lyjc.Focus();
            //    return false;
            //}

            //加工工序
            //if (cbx_xggx.Text == "" || cbx_xggx.Text == null)
            //{
            //    tishi = "请选择相关工序！";
            //    MessageBox.Show(tishi, "提示");
            //    cbx_xggx.Focus();
            //    return false;
            //}

            return true;
        }

        /// <summary>
        /// AddData函数，向datagridview中增加一行数据,.之前的弹窗设计，已弃用！
        /// </summary>
        /// <param name="list">子窗体传输过来的list值</param>
        public void AddData(List<string> list)
        {
            //新的空白单据，未绑定数据源
            if (TuiHuanMingXi.DataSource == null)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(TuiHuanMingXi);

                row.Cells[0].Value = list[0];//零部件名称
                row.Cells[1].Value = list[1];//零部件规格
                row.Cells[2].Value = list[2];//零部件型号
                row.Cells[3].Value = list[3];//数量
                row.Cells[4].Value = list[4];//单位

                row.Cells[5].Value = list[5];//机床编码
                row.Cells[6].Value = list[6];//工序

                row.Cells[7].Value = list[7];//刀具柜编码
                row.Cells[8].Value = list[8];//存放位置
                row.Cells[9].Value = list[9];//备注

                TuiHuanMingXi.Rows.Add(row);
            }
            else//暂时保存的单据，已经绑定了数据源
            {
                DataRow row = thmx_db.NewRow();

                row["lbjmc"] = list[0];//零部件名称
                row["lbjgg"] = list[1];//零部件规格
                row["lbjxh"] = list[2];//零部件型号
                row["sl"] = list[3];//数量
                row["dw"] = list[4];//单位

                row["jcbm"] = list[5];//机床编码
                row["gx"] = list[6];//工序

                row["djgbm"] = list[7];//刀具柜编码
                row["cfwz"] = list[8];//存放位置
                row["bz"] = list[9];//备注

                thmx_db.Rows.Add(row);
            }

            HJ++;//合计数量加一
            heji.Text = HJ.ToString();//更新合计数量
        }

        #endregion 明细部分结束

        /*--------------------------------------------单据按钮部分------------------------------------------------------------------------------------------------------*/

        #region 单据按钮部分
        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_2(object sender, EventArgs e)
        {
            if (THBZ.Text == "" && THR.Text == "")//未填写任何内容，提示取消填写单据
            {
                if (MessageBox.Show("单据未填写退换信息，要直接取消填写单据？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                if (TuiHuanMingXi.Rows.Count <= 1)
                {
                    if (MessageBox.Show("当前单据退还明细为空，确定要保存单据？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        //this.Close();
                        return;
                    }
                }

                //将退还和操作数据存入数据库lbj_tuihuan表
                //数据预处理
                string danjuzhuangtai = "0";//单据状态
                string dh = THDH.Text.ToString().Trim();//单号
                string thbz = THBZ.Text.ToString().Trim();//退还班组
                string thr = THR.Text.ToString().Trim();//退还人
                string thrq = THRQ.Value.ToString().Trim();//退还日期
                string thyy = THYY.Text.ToString().Trim();//退还原因
                string jbr = JBR.Text.ToString().Trim();//经办人
                string jbrq = JBRQ.Value.ToString();//经办日期

                //判断是否是暂存单据，存入刀具退还数据库daojutuihuan
                if (Alex.CunZai(dh, lbjTuiHuan.danhao, lbjTuiHuan.TableName) != 0)
                {
                    SqlStr = string.Format("UPDATE {0} SET djzt = '{1}', thbz = '{2}', thr = '{3}', thrq = '{4}', thyy = '{5}', jbr = '{6}', jbrq = '{7}' WHERE {8} = '{9}'", lbjTuiHuan.TableName, danjuzhuangtai, thbz, thr, thrq, thyy, jbr, jbrq, lbjTuiHuan.danhao, dh);

                    LogMessage = string.Format("成功更新1张单据编号为{0}的零部件退还暂存单据。", dh);
                }
                else
                {
                    SqlStr = string.Format("INSERT INTO {0}(danhao, djzt, thbz, thr, thrq, thyy, jbr, jbrq) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", lbjTuiHuan.TableName, dh, danjuzhuangtai, thbz, thr, thrq, thyy, jbr, jbrq);

                    LogMessage = string.Format("成功保存1张单据编号为{0}的零部件退还新单据。", dh);
                }
                int row1 = SQL.ExecuteNonQuery(SqlStr);

                //将退还明细数据存入数据库lbj_tuihuanmingxi表
                int row2 = 0;

                //判断此单号在明细表中是否已存在,如果存在则一并删除，重新保存
                if (Alex.CunZai(THDH.Text.ToString().Trim(), lbjTuiHuanMingXi.danhao, lbjTuiHuanMingXi.TableName) != 0)
                {
                    //delete语句删除已经存在的明细记录
                    SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", lbjTuiHuanMingXi.TableName, lbjTuiHuanMingXi.danhao, THDH.Text.ToString().Trim());
                    row2 = SQL.ExecuteNonQuery(SqlStr);
                }

                if (TuiHuanMingXi.Rows.Count > 1)
                {
                    if (row1 != 0)
                    {
                        //明细数据格式化,一行一行存入数据库
                        for (int rowindex = 0; rowindex < TuiHuanMingXi.Rows.Count - 1; rowindex++)
                        {
                            string lbjmc = TuiHuanMingXi.Rows[rowindex].Cells["mx_lbjmc"].Value.ToString();//零部件名称
                            string lbjgg = TuiHuanMingXi.Rows[rowindex].Cells["mx_lbjgg"].Value.ToString();//零部件规格
                            string lbjxh = TuiHuanMingXi.Rows[rowindex].Cells["mx_lbjxh"].Value.ToString();//零部件型号
                            string jcbm = TuiHuanMingXi.Rows[rowindex].Cells["mx_jcbm"].Value.ToString();//机床编码
                            string gx = TuiHuanMingXi.Rows[rowindex].Cells["mx_gx"].Value.ToString();//工序
                            string sl = TuiHuanMingXi.Rows[rowindex].Cells["mx_thsl"].Value.ToString();//数量
                            string dw = TuiHuanMingXi.Rows[rowindex].Cells["mx_dw"].Value.ToString();//单位
                            string kcwz = TuiHuanMingXi.Rows[rowindex].Cells["mx_kcwz"].Value.ToString();//库存位置
                            string djgbm = kcwz.Substring(0, kcwz.Length - 4);//还原库存位置的刀具柜编码
                            string cfwz = kcwz.Substring(kcwz.Length - 2);//还原库存位置的具体层数
                            string bz = TuiHuanMingXi.Rows[rowindex].Cells["mx_bz"].Value.ToString();//备注

                            //退还明细数据存入数据库退还明细表
                            SqlStr = string.Format("INSERT INTO {0}(danhao, lbjmc, lbjgg, lbjxh, dw, sl, jcbm, gx, djgbm, cfwz, bz) values('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')", lbjTuiHuanMingXi.TableName, dh, lbjmc, lbjgg, lbjxh, dw, sl, jcbm, gx, djgbm, cfwz, bz);
                            //SqlStr = "INSERT INTO lbj_tuihuanmingxi(danhao, lbjmc, lbjgg, lbjxh, dw, sl, jcbm, gx, djgbm, cfwz, bz) values('" + dh + "', '" + lbjmc + "', '" + lbjgg + "', '" + lbjxh + "','" + dw + "','" + sl + "', '" + jcbm + "', '" + gx + "', '" + djgbm + "', '" + cfwz + "', '" + bz + "')";
                            row2 = SQL.ExecuteNonQuery(SqlStr);
                        }
                    }
                }

                MessageBox.Show("单据保存成功！可再次修改确认。", "提示", MessageBoxButtons.OK);

                //日志记录
                Program.WriteLog(LogType, LogMessage);
                LogMessage = "";

                this.DialogResult = DialogResult.OK;
                //this.Close();
            }
        }

        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否对单据进行确认？确认之后将不可修改！", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //数据验证
                if (CheckData() == 0)
                {
                    return;//数据输入有误
                }
                else
                {
                    //将退还和操作数据存入数据库daojutuihuan表
                    //数据预处理
                    string danjuzhuangtai = "1";//单据状态
                    string dh = THDH.Text.ToString().Trim();//单号
                    string thbz = THBZ.Text.ToString().Trim();//退还班组
                    string thr = THR.Text.ToString().Trim();//退还人
                    string thrq = THRQ.Value.ToString().Trim();//退还日期
                    string thyy = THYY.Text.ToString().Trim();//退还原因
                    string jbr = JBR.Text.ToString().Trim();//经办人
                    string jbrq = JBRQ.Value.ToString();//经办日期

                    //判断是否是暂存单据，存入刀具退还数据库lbj_tuihuan
                    if (Alex.CunZai(dh, lbjTuiHuan.danhao, lbjTuiHuan.TableName) != 0)
                    {
                        SqlStr = string.Format("UPDATE {0} SET djzt = '{1}', thbz = '{2}', thr = '{3}', thrq = '{4}', thyy = '{5}', jbr = '{6}', jbrq = '{7}' WHERE {8} = '{9}'", lbjTuiHuan.TableName, danjuzhuangtai, thbz, thr, thrq, thyy, jbr, jbrq, lbjTuiHuan.danhao, dh);

                        LogMessage = string.Format("成功确认1张单据编号为{0}的零部件退还暂存单据。", dh);
                    }
                    else
                    {
                        SqlStr = string.Format("INSERT INTO {0}(danhao, djzt, thbz, thr, thrq, thyy, jbr, jbrq) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", lbjTuiHuan.TableName, dh, danjuzhuangtai, thbz, thr, thrq, thyy, jbr, jbrq);

                        LogMessage = string.Format("成功确认1张单据编号为{0}的零部件退还新单据。", dh);

                    }
                    int row1 = SQL.ExecuteNonQuery(SqlStr);

                    //将退还明细数据存入数据库lbj_tuihuanmingxi表
                    int row2 = 0;
                    if (row1 != 0)
                    {
                        //判断此单号在明细表中是否已存在,如果存在则一并删除，重新保存
                        if (Alex.CunZai(THDH.Text.ToString().Trim(), lbjTuiHuanMingXi.danhao, lbjTuiHuanMingXi.TableName) != 0)
                        {
                            //delete语句删除已经存在的明细记录
                            SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", lbjTuiHuanMingXi.TableName, lbjTuiHuanMingXi.danhao, THDH.Text.ToString().Trim());
                            row2 = SQL.ExecuteNonQuery(SqlStr);
                        }

                        //明细数据格式化
                        for (int rowindex = 0; rowindex < TuiHuanMingXi.Rows.Count - 1; rowindex++)
                        {
                            string lbjmc = TuiHuanMingXi.Rows[rowindex].Cells["mx_lbjmc"].Value.ToString();//零部件名称
                            string lbjgg = TuiHuanMingXi.Rows[rowindex].Cells["mx_lbjgg"].Value.ToString();//零部件规格
                            string lbjxh = TuiHuanMingXi.Rows[rowindex].Cells["mx_lbjxh"].Value.ToString();//零部件型号
                            string dw = TuiHuanMingXi.Rows[rowindex].Cells["mx_dw"].Value.ToString();//单位
                            string sl = TuiHuanMingXi.Rows[rowindex].Cells["mx_thsl"].Value.ToString();//数量
                            string jcbm = TuiHuanMingXi.Rows[rowindex].Cells["mx_jcbm"].Value.ToString();//机床编码
                            string gx = TuiHuanMingXi.Rows[rowindex].Cells["mx_gx"].Value.ToString();//工序
                            string kcwz = TuiHuanMingXi.Rows[rowindex].Cells["mx_kcwz"].Value.ToString();//库存位置
                            string djgbm = kcwz.Substring(0, kcwz.Length - 4);//还原库存位置的刀具柜编码
                            string cfwz = kcwz.Substring(kcwz.Length - 2);//还原库存位置的具体层数
                            string dskykc = TuiHuanMingXi.Rows[rowindex].Cells["mx_kcsl"].Value.ToString();//当时可用库存，即库存数量
                            string bz = TuiHuanMingXi.Rows[rowindex].Cells["mx_bz"].Value.ToString();//备注

                            //退还明细数据存入数据库退还明细表
                            SqlStr = string.Format("INSERT INTO {0}(danhao, lbjmc, lbjgg, lbjxh, dw, sl, jcbm, gx, djgbm, cfwz, bz) values('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')", lbjTuiHuanMingXi.TableName, dh, lbjmc, lbjgg, lbjxh, dw, sl, jcbm, gx, djgbm, cfwz, bz);
                            row2 = SQL.ExecuteNonQuery(SqlStr);

                            //明细信息存入流水表
                            SqlStr = string.Format("INSERT INTO {0}(danhao, dhlx, lbjmc, lbjgg, lbjxh, djgbm, jtwz, zsl, fsl, dskykc, dw, czsj, jbr, bz) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}' ,'{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}')", lbjLiuShui.TableName, dh, "零部件退还", lbjmc, lbjgg, lbjxh, djgbm, cfwz, sl, "0", dskykc, dw, jbrq, jbr, bz);
                            int row3 = SQL.ExecuteNonQuery(SqlStr);

                            //更新库存表
                            SqlStr = string.Format("UPDATE {0} j SET j.{1} = j.{1} + {2}  WHERE j.{3} = '{4}' AND j.{5} = '{6}' AND j.{7} = '{8}' AND j.{9} = '{10}'", LingBuJianBiao.TableName, LingBuJianBiao.kcsl, Convert.ToInt16(sl), LingBuJianBiao.mc, lbjmc, LingBuJianBiao.xinghao, lbjxh, LingBuJianBiao.weizhibianma, djgbm, LingBuJianBiao.cengshu, cfwz);
                            int row4 = SQL.ExecuteNonQuery(SqlStr);
                        }

                        if (row2 != 0)
                        {
                            MessageBox.Show("单据确认成功！", "提示", MessageBoxButtons.OK);

                            //日志记录
                            Program.WriteLog(LogType, LogMessage);
                            LogMessage = "";

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("刀具明细数据填写有误，请检查并重试！", "警告", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("退还信息或操作信息填写有误，请检查并重试！", "警告", MessageBoxButtons.OK);
                    }
                }
            }
        }

        /// <summary>
        /// 打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_print_Click_1(object sender, EventArgs e)
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
                table1.Columns.Add("xh", typeof(string));
                table1.Columns.Add("lbjmc", typeof(string));
                table1.Columns.Add("lbjgg", typeof(string));
                table1.Columns.Add("lbjxh", typeof(string));
                table1.Columns.Add("dw", typeof(string));
                table1.Columns.Add("thsl", typeof(string));
                table1.Columns.Add("jcbm", typeof(string));
                table1.Columns.Add("gx", typeof(string));
                table1.Columns.Add("kcwz", typeof(string));
                //table1.Columns.Add("djgbm", typeof(string));
                //table1.Columns.Add("cfwz", typeof(string));
                table1.Columns.Add("bz", typeof(string));

                //添加明细数据
                for (int rowindex = 0; rowindex < TuiHuanMingXi.Rows.Count - 1; rowindex++)
                {
                    //格式化刀具数据
                    string lbjmc = TuiHuanMingXi.Rows[rowindex].Cells["mx_lbjmc"].Value.ToString();//零部件名称
                    string lbjgg = TuiHuanMingXi.Rows[rowindex].Cells["mx_lbjgg"].Value.ToString();//零部件规格
                    string lbjxh = TuiHuanMingXi.Rows[rowindex].Cells["mx_lbjxh"].Value.ToString();//零部件型号
                    string dw = TuiHuanMingXi.Rows[rowindex].Cells["mx_dw"].Value.ToString();//单位
                    string sl = TuiHuanMingXi.Rows[rowindex].Cells["mx_thsl"].Value.ToString();//数量
                    string jcbm = TuiHuanMingXi.Rows[rowindex].Cells["mx_jcbm"].Value.ToString();//机床编码
                    string gx = TuiHuanMingXi.Rows[rowindex].Cells["mx_gx"].Value.ToString();//工序
                    //string djgbm = TuiHuanMingXi.Rows[rowindex].Cells["mx_djgbm"].Value.ToString();//刀具柜编码
                    //string cfwz = TuiHuanMingXi.Rows[rowindex].Cells["mx_cfwz"].Value.ToString();//存放位置
                    //string kcwz = djgbm + "--" + cfwz;//库存位置
                    string kcwz = TuiHuanMingXi.Rows[rowindex].Cells["mx_kcwz"].Value.ToString();//库存位置
                    string bz = TuiHuanMingXi.Rows[rowindex].Cells["mx_bz"].Value.ToString();//备注

                    DataRow row = table1.NewRow();
                    row["xh"] = rowindex + 1;
                    row["lbjmc"] = lbjmc;
                    row["lbjgg"] = lbjgg;
                    row["lbjxh"] = lbjxh;
                    row["dw"] = dw;
                    row["thsl"] = sl;
                    row["jcbm"] = jcbm;
                    row["gx"] = gx;
                    row["kcwz"] = kcwz;
                    //row["djgbm"] = djgbm;
                    //row["cfwz"] = cfwz;
                    row["bz"] = bz;

                    table1.Rows.Add(row);
                }

                FRds.Tables.Add(table1);

                Report FReport = new Report();
                string sPath = @"../../File/零部件退还单.frx";
                FReport.Load(sPath);  // 将DataSet对象注册到FastReport控件中
                FReport.RegisterData(FRds);//FReport.RegisterData(ds1);

                FReport.SetParameterValue("danhao", THDH.Text);
                FReport.SetParameterValue("thbz", THBZ.Text);
                FReport.SetParameterValue("thr", THR.Text);
                FReport.SetParameterValue("thrq", THRQ.Text.ToString());
                FReport.SetParameterValue("thyy", THYY.Text);
                FReport.SetParameterValue("jbr", JBR.Text);
                FReport.SetParameterValue("jbrq", JBRQ.Text);

                //显示报表
                FReport.Prepare();
                FReport.ShowPrepared();
                //FReport.Show();

                //日志记录
                LogMessage = string.Format("成功打印1张单据编号为{0}的零部件退还单据。", THDH.Text);
                Program.WriteLog(LogType, LogMessage);
                LogMessage = "";
            }
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_delete_Click(object sender, EventArgs e)
        {
            if (Alex.CunZai(THDH.Text.ToString().Trim(), lbjTuiHuan.danhao, lbjTuiHuan.TableName) != 0)
            {
                DialogResult dr = MessageBox.Show("确认删除此单据？", "删除确认", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //删除刀具退还表中的数据
                    SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", lbjTuiHuan.TableName, lbjTuiHuan.danhao, THDH.Text.ToString().Trim());
                    int row1 = SQL.ExecuteNonQuery(SqlStr);

                    //删除明细
                    SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", lbjTuiHuanMingXi.TableName, lbjTuiHuanMingXi.danhao, THDH.Text.ToString().Trim());
                    int row2 = SQL.ExecuteNonQuery(SqlStr);
                    MessageBox.Show("成功删除一张单据和" + row2 + "条明细记录！");

                    //日志记录
                    LogMessage = string.Format("成功删除一张单据和" + row2 + "条明细记录！");
                    Program.WriteLog(LogType, LogMessage);
                    LogMessage = "";

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
        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion 单据按钮部分结束

        /*--------------------------------------------其他方法部分------------------------------------------------------------------------------------------------------*/
        #region 其他部分
        /// <summary>
        /// 经办日期默认和退换日期一致
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void THRQ_ValueChanged_1(object sender, EventArgs e)
        {
            JBRQ.Value = THRQ.Value;
        }

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        private int CheckData()
        {
            tishi = "";

            if (THBZ.Text == "" || THR.Text == "" || THRQ.Text == "" || JBR.Text == "" || JBRQ.Text == "")
            {
                if (THBZ.Text.ToString() == "")
                {
                    tishi = "请选择退还班组！";
                    THBZ.Focus();
                }
                else if (THR.Text.ToString() == "")
                {
                    tishi = "请填写退还人！";
                    THR.Focus();
                }
                else if (THRQ.Text.ToString() == "")
                {
                    tishi = "请选择退还日期！";
                }
                else if (JBR.Text.ToString() == "")
                {
                    tishi = "请填写经办人！";
                    JBR.Focus();
                }
                else if (JBRQ.Text.ToString() == "")
                {
                    tishi = "请选择经办日期！";
                }
            }
            else if (TuiHuanMingXi.Rows.Count == 1)
            {
                tishi = "退还刀具明细不能为空！";
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
        /// 通过总表勾选名称增加明细，即可以通过选择多条记录一并新增明细
        /// </summary>
        /// <param name="tb">要新增的明细表部分内容</param>
        public void AddDataFromTable(DataTable tb)
        {
            //thmx_db.Columns.Add("lbjmc", System.Type.GetType("System.String"));
            //thmx_db.Columns.Add("lbjgg", System.Type.GetType("System.String"));
            //thmx_db.Columns.Add("lbjxh", System.Type.GetType("System.String"));
            //thmx_db.Columns.Add("jcbm", System.Type.GetType("System.String"));
            //thmx_db.Columns.Add("gx", System.Type.GetType("System.String"));
            //thmx_db.Columns.Add("thsl", System.Type.GetType("System.String"));
            //thmx_db.Columns.Add("dw", System.Type.GetType("System.String"));
            //thmx_db.Columns.Add("kcwz", System.Type.GetType("System.String"));
            //thmx_db.Columns.Add("kcsl", System.Type.GetType("System.String"));
            //thmx_db.Columns.Add("bz", System.Type.GetType("System.String"));

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                DataRow rowrow = thmx_db.NewRow();

                rowrow["lbjmc"] = tb.Rows[i]["lbjmc"].ToString();//零部件名称
                rowrow["lbjgg"] = tb.Rows[i]["lbjgg"].ToString();//零部件规格
                rowrow["lbjxh"] = tb.Rows[i]["lbjxh"].ToString();//零部件型号
                rowrow["kcwz"] = tb.Rows[i]["kcwz"].ToString();//库存位置
                rowrow["kcsl"] = tb.Rows[i]["kcsl"].ToString();//库存数量
                rowrow["dw"] = tb.Rows[i]["dw"].ToString();//单位
                rowrow["thsl"] = "";//领用数量
                rowrow["jcbm"] = "";//机床编码
                rowrow["gx"] = "";//工序
                rowrow["bz"] = "";//备注

                thmx_db.Rows.Add(rowrow);
            }

            TuiHuanMingXi.DataSource = thmx_db.DefaultView;
            heji.Text = HJ.ToString();
        }

        /// <summary>
        /// 窗体自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LBJTH_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);
        }

        /// <summary>
        /// 当窗体在选项卡中打开时，关闭窗体则关闭相应的选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LBJTH_FormClosed(object sender, FormClosedEventArgs e)
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
            thmx_db.Columns.Add("lbjmc", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("lbjgg", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("lbjxh", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("jcbm", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("gx", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("kcwz", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("kcsl", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("thsl", System.Type.GetType("System.String"));
            thmx_db.Columns.Add("dw", System.Type.GetType("System.String"));            
            thmx_db.Columns.Add("bz", System.Type.GetType("System.String"));
        }

        #endregion 其他部分结束
    }
}
