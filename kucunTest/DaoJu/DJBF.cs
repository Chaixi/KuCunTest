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

namespace kucunTest.DaoJu
{
    public partial class DJBF : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";

        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();

        string DanJuBiao = "daojubaofei";
        string DanHaoZD = "danhao";
        string LiuShuiBiao = "daojuliushui";

        #endregion

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DJBF()
        {
            InitializeComponent();

            BFDH.Text = Alex.DanHao("DJBF");//自动生成单号

            //申请信息默认值
            //SQBZ.SelectedIndex = 0;
            //SQSB.SelectedIndex = 0;
            //JGLJ.SelectedIndex = 0;
            SQSJ.Text = DateTime.Now.ToString();

            //刀具信息默认值
            string Sqlstr1 = "select distinct daojuleixing from daojutemp";
            DJLX.DataSource = SQL.DataReadList(Sqlstr1);
            DJLX.SelectedIndex = -1;
            DJCD.SelectedIndex = -1;

            //操作信息默认值
            SPLD.SelectedIndex = 0;
            SPYJ.Text = "情况属实。";
            JBR.SelectedIndex = 0;

            //加载所有设备
            Sqlstr = string.Format("SELECT jichuangbianma FROM jichuang");
            SQSB.DataSource = SQL.DataReadList(Sqlstr);
            SQSB.SelectedIndex = -1;

            //加载所有刀具柜，刀具报废后暂存位置和具体位置
            Sqlstr = string.Format("SELECT djgmc FROM daojugui");
            BFZCWZ.DataSource = SQL.DataReadList(Sqlstr);
            BFZCWZ.SelectedIndex = -1;
        }

        /// <summary>
        /// 重写构造函数，用于从历史记录窗体加载数据
        /// </summary>
        /// <param name="dh">报废单号</param>
        public DJBF(string dh)
        {
            InitializeComponent();

            //根据单号查询数据库
            Sqlstr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", DanJuBiao, DanHaoZD, dh);
            DataSet ds = SQL.getDataSet(Sqlstr, DanJuBiao);

            //赋值
            BFDH.Text = dh.ToString();
            SQBZ.Text = ds.Tables[0].Rows[0]["sqbz"].ToString();//申请班组
            SQSB.Text = ds.Tables[0].Rows[0]["sqsb"].ToString();//申请设备
            SQR.Text = ds.Tables[0].Rows[0]["sqr"].ToString();//申请人
            JGLJ.Text = ds.Tables[0].Rows[0]["jglj"].ToString();//加工零件
            SQSJ.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["sqsj"].ToString());//申请时间
            GX.Text = ds.Tables[0].Rows[0]["gx"].ToString();//工序

            DJLX.Text = ds.Tables[0].Rows[0]["djlx"].ToString();//刀具类型
            DJGG.Text = ds.Tables[0].Rows[0]["djgg"].ToString();//刀具规格
            DJCD.Text = ds.Tables[0].Rows[0]["djcd"].ToString();//刀具长度
            DJID.Text = ds.Tables[0].Rows[0]["djid"].ToString();//刀具id            
            BFYY.Text = ds.Tables[0].Rows[0]["bfyy"].ToString();//报废原因

            SPLD.Text = ds.Tables[0].Rows[0]["spld"].ToString();//审批领导
            SPYJ.Text = ds.Tables[0].Rows[0]["spyj"].ToString();//审批意见
            SPSJ.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["spsj"].ToString());//审批时间
            JBR.Text = ds.Tables[0].Rows[0]["jbr"].ToString();//经办人
            string djzt = ds.Tables[0].Rows[0]["djzt"].ToString();//单据状态

            //若是已完成的单据，则只允许查看，不许修改。
            if (djzt == "1")
            {
                Alex.DisableAllControl(this);
                BtnPrint.Enabled = true;
            }
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJBF_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
        }

        #region 刀具信息三级联动
        /// <summary>
        /// 保证刀具信息的选择处于联动状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJLX_SelectedIndexChanged(object sender, EventArgs e)
        {
            DJGG.DataSource = Djlx_Changed(DJLX.Text.ToString().Trim());
            DJGG.SelectedIndex = -1;//选择第一项作为默认值
        }

        private void DJGG_SelectedIndexChanged(object sender, EventArgs e)
        {
            DJID.DataSource = Djgg_Changed(DJLX.Text.ToString().Trim(), DJGG.Text.ToString().Trim());
            DJID.SelectedIndex = -1;
        }

        /// <summary>
        /// 刀具信息三级联动之刀具类型更改，刀具规格相应变化的公有函数
        /// </summary>
        /// <param name="djlx">要查询的刀具类型</param>
        /// <returns></returns>
        public List<string> Djlx_Changed(string djlx)
        {
            if(djlx == "")
            {
                return null;
            }
            else
            {
                Sqlstr = "select distinct daojuguige from daojutemp where daojuleixing = '" + djlx + "'";
                return SQL.DataReadList(Sqlstr);
            }
            
        }

        /// <summary>
        /// 刀具信息三级联动之刀具规格更改，刀具id相应变化的公有函数
        /// </summary>
        /// <param name="djlx">要查询的刀具类型</param>
        /// <param name="djgg">要查询的刀具规格</param>
        /// <returns></returns>
        public List<string> Djgg_Changed(string djlx, string djgg)
        {
            if (djlx == null || djlx == "")
            {
                return null;
            }
            else if (djgg == null || djgg == "")
            {
                return null;
            }
            else
            {
                Sqlstr = "select daojuid from daojutemp where daojuleixing = '" + djlx + "'" + " and daojuguige = '" + djgg + "'";
                return SQL.DataReadList(Sqlstr);
            }
        }
        #endregion

        #region 按钮部分

        /// <summary>
        /// 保存单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (SQBZ.Text == "" && SQR.Text == "" && SQSB.Text == "" && JGLJ.Text == "")//未填写申请信息，提示取消填写单据
            {
                if (MessageBox.Show("单据未填写申请信息，要取消填写单据？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                //数据预处理
                string djzt = "0";
                string dh = BFDH.Text.ToString().Trim();//报废单号
                string sqbz = SQBZ.Text.ToString().Trim();//申请班组
                string sqr = SQR.Text.ToString().Trim();//申请人
                string sqsb = SQSB.Text.ToString().Trim();//申请设备
                string sqsj = SQSJ.Text.ToString().Trim();//申请时间
                string jglj = JGLJ.Text.ToString().Trim();//加工零件
                string gx = GX.Text.ToString().Trim();//工序
                string djlx = DJLX.Text.ToString().Trim();//刀具类型
                string djgg = DJGG.Text.ToString().Trim();//刀具规格
                string djcd = DJCD.Text.ToString().Trim();//刀具长度
                string djid = DJID.Text.ToString().Trim();//刀具ID
                string bfzcwz = BFZCWZ.Text.ToString().Trim();//刀具报废后暂存位置
                string jtwz = JTWZ.Text.ToString().Trim();//报废后具体位置
                string bfyy = BFYY.Text.ToString().Trim();//更换理由
                string spld = SPLD.Text.ToString().Trim();//审批领导
                string spyj = SPYJ.Text.ToString().Trim();//审批意见
                string spsj = SPSJ.Text.ToString().Trim();//审批时间
                string jbr = JBR.Text.ToString().Trim();//经办人

                //判断是否是暂存单据，存入刀具报废数据库
                if (Alex.CunZai(BFDH.Text.ToString().Trim(), DanHaoZD, DanJuBiao) != 0)
                {
                    Sqlstr = string.Format("UPDATE {0} SET djzt = '{1}', sqbz = '{2}', sqr = '{3}', sqsb = '{4}', sqsj = '{5}', jglj = '{6}', gx = '{7}', djlx = '{8}', djgg = '{9}', djcd = '{10}', djid = '{11}', bfyy = '{12}', spld = '{13}', spyj = '{14}', spsj = '{15}', jbr = '{16}', bfzcwz = '{17}', jtwz = '{18}' WHERE {19} = '{20}'", DanJuBiao, djzt, sqbz, sqr, sqsb, sqsj, jglj, gx, djlx, djgg, djcd, djid, bfyy, spld, spyj, spsj, jbr, bfzcwz, jtwz, DanHaoZD, dh);
                }
                else
                {
                    Sqlstr = "INSERT INTO daojubaofei(danhao, djzt, sqbz, sqr, sqsb, sqsj, jglj, gx, djlx, djgg, djcd, djid, bfyy, spld, spyj, spsj, jbr, bfzcwz, jtwz) values('" + dh + "', '" + djzt + "', '" + sqbz + "', '" + sqr + "', '" + sqsb + "', '" + sqsj + "', '" + jglj + "', '" + gx + "', '" + djlx + "', '" + djgg + "', '" + djcd + "', '" + djid + "', '" + bfyy + "', '" + spld + "', '" + spyj + "', '" + spsj + "', '" + jbr + "', '" + bfzcwz + "', '" + jtwz + "')";
                }
                int row = SQL.ExecuteNonQuery(Sqlstr);

                if (row != 0)
                {
                    MessageBox.Show("单据保存成功！可再次修改。", "提示", MessageBoxButtons.OK);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 确认单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("单据确认后不可修改，是否确认？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //数据验证
                if (CheckData() == 0)
                {
                    return;//数据输入有误
                }
                else
                {
                    //数据预处理
                    string djzt = "1";
                    string dh = BFDH.Text.ToString().Trim();//报废单号
                    string sqbz = SQBZ.Text.ToString().Trim();//申请班组
                    string sqr = SQR.Text.ToString().Trim();//申请人
                    string sqsb = SQSB.Text.ToString().Trim();//申请设备
                    string sqsj = SQSJ.Text.ToString().Trim();//申请时间
                    string jglj = JGLJ.Text.ToString().Trim();//加工零件
                    string gx = GX.Text.ToString().Trim();//工序
                    string djlx = DJLX.Text.ToString().Trim();//刀具类型
                    string djgg = DJGG.Text.ToString().Trim();//刀具规格
                    string djcd = DJCD.Text.ToString().Trim();//刀具长度
                    string djid = DJID.Text.ToString().Trim();//刀具ID
                    string bfzcwz = BFZCWZ.Text.ToString().Trim();//刀具报废后暂存位置
                    string jtwz = JTWZ.Text.ToString().Trim();//报废后具体位置
                    string bfyy = BFYY.Text.ToString().Trim();//更换理由
                    string spld = SPLD.Text.ToString().Trim();//审批领导
                    string spyj = SPYJ.Text.ToString().Trim();//审批意见
                    string spsj = SPSJ.Text.ToString().Trim();//审批时间
                    string jbr = JBR.Text.ToString().Trim();//经办人

                    string dskysl = "";//此类型刀具的当时可用数量！！！当时可用数量为单据操作后的刀具可用数量
         
                    //查询此类型刀具当时可用数量, 刀具报废可用数量减一
                    dskysl = Alex.Count_djsl(djlx, "kysl").ToString();

                    //判断是否是暂存单据，存入刀具报废数据库
                    if (Alex.CunZai(BFDH.Text.ToString().Trim(), DanHaoZD, DanJuBiao) != 0 )
                    {
                        Sqlstr = string.Format("UPDATE {0} SET djzt = '{1}', sqbz = '{2}', sqr = '{3}', sqsb = '{4}', sqsj = '{5}', jglj = '{6}', gx = '{7}', djlx = '{8}', djgg = '{9}', djcd = '{10}', djid = '{11}', bfyy = '{12}', spld = '{13}', spyj = '{14}', spsj = '{15}', jbr = '{16}', bfzcwz = '{17}', jtwz = '{18}' WHERE {19} = '{20}'", DanJuBiao, djzt, sqbz, sqr, sqsb, sqsj, jglj, gx, djlx, djgg, djcd, djid, bfyy, spld, spyj, spsj, jbr, bfzcwz, jtwz, DanHaoZD, dh);
                    }
                    else
                    {
                        Sqlstr = "INSERT INTO daojubaofei(danhao, djzt, sqbz, sqr, sqsb, sqsj, jglj, gx, djlx, djgg, djcd, djid, bfyy, spld, spyj, spsj, jbr, bfzcwz, jtwz) values('" + dh + "', '" + djzt + "', '" + sqbz + "', '" + sqr + "', '" + sqsb + "', '" + sqsj + "', '" + jglj + "', '" + gx + "', '" + djlx + "', '" + djgg + "', '" + djcd + "', '" + djid + "', '" + bfyy + "', '" + spld + "', '" + spyj + "', '" + spsj + "', '" + jbr + "', '" + bfzcwz + "', '" + jtwz + "')";
                    }
                    int row = SQL.ExecuteNonQuery(Sqlstr);

                    //刀具信息存入流水表
                    Sqlstr = string.Format("INSERT INTO {0}(danhao, dhlx, djlx, djgg, djid, zsl, fsl, dskysl, wzbm, jtwz ,czsj, jbr, bz) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}' ,'{8}', '{9}', '{10}', '{11}', '{12}', '{13}')", LiuShuiBiao, dh, "刀具报废", djlx, djgg, djid, "0", "0", dskysl, sqsb, "", spsj, jbr, "");
                    int row2 = SQL.ExecuteNonQuery(Sqlstr);

                    //更新刀具位置寿命监测表
                    Sqlstr = string.Format("UPDATE daojutemp dj SET dj.weizhibiaoshi = 'T', dj.weizhi = '{0}', dj.cengshu = '{1}' WHERE dj.daojuid = '{2}'", bfzcwz, jtwz, djid);
                    int row4 = SQL.ExecuteNonQuery(Sqlstr);

                    if (row != 0 && row2 != 0)
                    {
                        MessageBox.Show("刀具报废申请单保存成功！", "提示", MessageBoxButtons.OK);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 打印单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            //数据验证
            if (CheckData() == 0)
            {
                return;//数据输入有误
            }
            else
            {
                Report FReport = new Report();
                string sPath = @"../../File/刀具报废单.frx";
                FReport.Load(sPath);  // 将DataSet对象注册到FastReport控件中

                FReport.SetParameterValue("danhao", BFDH.Text);
                FReport.SetParameterValue("sqbz", SQBZ.Text);
                FReport.SetParameterValue("sqr", SQR.Text);
                FReport.SetParameterValue("sqsj", SQSJ.Text.ToString());
                FReport.SetParameterValue("sqsb", SQSB.Text);
                FReport.SetParameterValue("jglj", JGLJ.Text);
                FReport.SetParameterValue("gx", GX.Text);
                FReport.SetParameterValue("djlx", DJLX.Text);
                FReport.SetParameterValue("djgg", DJGG.Text);
                FReport.SetParameterValue("djcd", DJCD.Text);
                FReport.SetParameterValue("djid", DJID.Text);
                FReport.SetParameterValue("bfyy", BFYY.Text);
                FReport.SetParameterValue("spld", SPLD.Text);
                FReport.SetParameterValue("spyj", SPYJ.Text);
                FReport.SetParameterValue("jbr", JBR.Text);
                FReport.SetParameterValue("jbrq", SPSJ.Text);

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
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (Alex.CunZai(BFDH.Text.ToString().Trim(), DanHaoZD, DanJuBiao) != 0)//单据已保存，数据库存在
            {
                if (MessageBox.Show("确认删除此单据？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //删除刀具更换表中的数据
                    Sqlstr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", DanJuBiao, DanHaoZD, BFDH.Text.ToString().Trim());
                    int row1 = SQL.ExecuteNonQuery(Sqlstr);
                    MessageBox.Show("成功删除" + row1 + "张单据!");
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
        /// 更换历史按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHistory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认打开报废历史记录并关闭此窗口？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                History djbf = new History("DJBF");
                djbf.Show();
                this.Close();
            }
        }

        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion 按钮部分结束

        #region 其他方法部分
        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        private int CheckData()
        {
            string tishi = "";
            if (SQBZ.Text == "" || SQR.Text == "" || SQSB.Text == "" || JGLJ.Text == "" || GX.Text == "序")
            {
                if (SQBZ.Text.ToString() == "")
                {
                    tishi = "请选择申请班组！";
                }
                else if (SQR.Text.ToString() == "")
                {
                    tishi = "请填写申请人！";
                }
                else if (SQSB.Text.ToString() == "")
                {
                    tishi = "请填写申请设备！";
                }
                else if (JGLJ.Text.ToString() == "")
                {
                    tishi = "请填写加工零件！";
                }
                else if (GX.Text.ToString() == "序")
                {
                    tishi = "请填写工序！";
                }
            }
            else if (SPLD.Text.ToString() == "" || SPYJ.Text.ToString() == "" || JBR.Text == "")
            {
                if (SPLD.Text.ToString() == "")
                {
                    tishi = "请填写审批领导！";
                }
                else if (SPYJ.Text.ToString() == "")
                {
                    tishi = "请填写审批意见！";
                }
                else if (JBR.Text.ToString() == "")
                {
                    tishi = "请填写经办人！";
                }
            }
            else if (DJLX.Text.ToString().Trim() == "" || DJGG.Text.ToString().Trim() == "" || DJCD.Text.ToString().Trim() == "" || DJID.Text.ToString().Trim() == "")
            {
                tishi = "请将刀具信息填写完整！";
            }
            else if (BFYY.Text.Trim() == "")
            {
                tishi = "刀具报废原因不能为空！";
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
        /// 审批时间默认与申请时间保持一致
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SQSJ_ValueChanged(object sender, EventArgs e)
        {
            SPSJ.Value = SQSJ.Value;
        }

        /// <summary>
        /// 窗口自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJBF_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        /// <summary>
        /// 当窗体在选项卡中打开时，关闭窗体则关闭相应的选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJBF_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Parent != null)
            {
                MainForm mfr = (MainForm)this.Parent.FindForm();
                mfr.CloseTab(this.Name);
            }
        }

        #endregion 其他方法部分结束

        /// <summary>
        /// 从表增加明细，即可以通过选择多条记录一并新增明细
        /// </summary>
        /// <param name="tb">要新增的明细表部分内容</param>
        public void AddDataFromTable(DataTable tb)
        {
            DJLX.Text = tb.Rows[0]["djlx"].ToString();
            DJLX.Enabled = false;
            DJGG.Text = tb.Rows[0]["djgg"].ToString();
            DJGG.Enabled = false;
            DJID.Text = tb.Rows[0]["djid"].ToString();
            DJID.Enabled = false;

            string djwz = tb.Rows[0]["djwz"].ToString().Trim();
            SQSB.Text = djwz.Substring(2, djwz.Length - 6);//截取机床编码，去掉2位位置标识前缀和4位具体位置标识
            SQSB.Enabled = false;
            DTH.Text = djwz.Substring(djwz.Length - 3);
            DTH.Enabled = false;
        }

        /// <summary>
        /// 设备变化，刀套号相应变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SQSB_SelectedValueChanged(object sender, EventArgs e)
        {
            if(SQSB.Text != "")
            {
                //加载已占用的刀套号
                Sqlstr = string.Format("SELECT cengshu FROM daojutemp WHERE weizhi = '{0}' ORDER BY cengshu ASC", SQSB.Text.ToString().Trim());
                DTH.DataSource = SQL.DataReadList(Sqlstr);
                DTH.SelectedIndex = -1;

                //加载此设备上的刀具类型
                //Sqlstr = string.Format("SELECT DISTINCT daojuleixing FROM daojutemp WHERE weizhi = '{0}'", SQSB.Text.ToString().Trim());
                //DJLX.DataSource = SQL.DataReadList(Sqlstr);
                //DJLX.SelectedIndex = -1;
            }

        }

        /// <summary>
        /// 刀套号变化直接确定单把刀具
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DTH_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectTool();
        }

        /// <summary>
        /// 根据设备和刀套号加载刀具信息
        /// </summary>
        public void SelectTool()
        {
            //设备和刀套号均不为空，则可以确定刀具
            if(SQSB.Text != "" && DTH.Text != "")
            {
                Sqlstr = string.Format("SELECT * FROM daojutemp WHERE weizhi = '{0}' AND cengshu = '{1}'", SQSB.Text.ToString().Trim(), DTH.Text.ToString().Trim());
                DataTable db_SelectTool = SQL.getDataSet(Sqlstr, "daojutemp").Tables[0];
                DJLX.SelectedItem = db_SelectTool.Rows[0]["daojuleixing"].ToString();
                DJGG.SelectedItem = db_SelectTool.Rows[0]["daojuguige"].ToString();
                DJID.SelectedItem = db_SelectTool.Rows[0]["daojuid"].ToString();

                //DJLX.Enabled = false;
                //DJGG.Enabled = false;
                //DJID.Enabled = false;
            }            
            else
            {
                DJLX.SelectedIndex = -1;
                DJGG.SelectedIndex = -1;
                DJID.SelectedIndex = -1;
            }

            //刀具类型、规格、id均不为空，则可以确定位置
            //if (DJLX.Text != "" && DJGG.Text != "" && DJID.Text != "")
            //{
            //    Sqlstr = string.Format("SELECT * FROM daojutemp WHERE daojuid = '{0}'", DJID.Text.ToString().Trim());
            //    DataTable db_SelectTool = SQL.getDataSet(Sqlstr, "daojutemp").Tables[0];
            //    SQSB.SelectedItem = db_SelectTool.Rows[0]["weizhi"].ToString();
            //    DTH.SelectedItem = db_SelectTool.Rows[0]["cengshu"].ToString();
            //}
        }

        /// <summary>
        /// 选择报废暂存位置（刀具柜）加载具体位置（刀具柜层数）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BFZCWZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            //有选择刀具柜名称并且此刀具柜存在具体层数
            int djgcs = Alex.CunZai("daojuguicengshu", string.Format("djgmc = '{0}'", BFZCWZ.Text.ToString().Trim()));
            if(BFZCWZ.SelectedIndex >= 0 &&  djgcs > 0)
            {
                Sqlstr = string.Format("SELECT cs.djgcs FROM daojuguicengshu cs WHERE cs.djgmc = '{0}'", BFZCWZ.Text.ToString().Trim());
                JTWZ.DataSource = SQL.DataReadList(Sqlstr);
                JTWZ.SelectedIndex = -1;
            }
            else
            {
                JTWZ.DataSource = null;
            }
        }
    }
}
