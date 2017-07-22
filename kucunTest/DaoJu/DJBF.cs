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
            SQBZ.SelectedIndex = 0;
            SQSB.SelectedIndex = 0;
            JGLJ.SelectedIndex = 0;
            SQSJ.Text = DateTime.Now.ToString();

            //刀具信息默认值
            string Sqlstr1 = "select distinct daojuleixing from daojutemp";
            DJLX.DataSource = SQL.DataReadList(Sqlstr1);
            DJLX.SelectedIndex = 0;
            DJCD.SelectedIndex = 0;

            //操作信息默认值
            SPLD.SelectedIndex = 0;
            SPYJ.Text = "情况属实。";
            JBR.SelectedIndex = 0;
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
            DJGG.SelectedIndex = 0;//选择第一项作为默认值
        }

        private void DJGG_SelectedIndexChanged(object sender, EventArgs e)
        {
            DJID.DataSource = Djgg_Changed(DJLX.Text.ToString().Trim(), DJGG.Text.ToString().Trim());
            DJID.SelectedIndex = 0;
        }

        /// <summary>
        /// 刀具信息三级联动之刀具类型更改，刀具规格相应变化的公有函数
        /// </summary>
        /// <param name="djlx">要查询的刀具类型</param>
        /// <returns></returns>
        public List<string> Djlx_Changed(string djlx)
        {
            Sqlstr = "select distinct daojuguige from daojutemp where daojuleixing = '" + djlx + "'";
            return SQL.DataReadList(Sqlstr);
        }

        /// <summary>
        /// 刀具信息三级联动之刀具规格更改，刀具id相应变化的公有函数
        /// </summary>
        /// <param name="djlx">要查询的刀具类型</param>
        /// <param name="djgg">要查询的刀具规格</param>
        /// <returns></returns>
        public List<string> Djgg_Changed(string djlx, string djgg)
        {
            Sqlstr = "select daojuid from daojutemp where daojuleixing = '" + djlx + "'" + " and daojuguige = '" + djgg + "'";
            return SQL.DataReadList(Sqlstr);
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
                string bfyy = BFYY.Text.ToString().Trim();//更换理由
                string spld = SPLD.Text.ToString().Trim();//审批领导
                string spyj = SPYJ.Text.ToString().Trim();//审批意见
                string spsj = SPSJ.Text.ToString().Trim();//审批时间
                string jbr = JBR.Text.ToString().Trim();//经办人

                //判断是否是暂存单据，存入刀具报废数据库
                if (Alex.CunZai(BFDH.Text.ToString().Trim(), DanHaoZD, DanJuBiao) != 0)
                {
                    Sqlstr = string.Format("UPDATE {0} SET djzt = '{1}', sqbz = '{2}', sqr = '{3}', sqsb = '{4}', sqsj = '{5}', jglj = '{6}', gx = '{7}', djlx = '{8}', djgg = '{9}', djcd = '{10}', djid = '{11}', bfyy = '{12}', spld = '{13}', spyj = '{14}', spsj = '{15}', jbr = '{16}' WHERE {17} = '{18}'", DanJuBiao, djzt, sqbz, sqr, sqsb, sqsj, jglj, gx, djlx, djgg, djcd, djid, bfyy, spld, spyj, spsj, jbr, DanHaoZD, dh);
                }
                else
                {
                    Sqlstr = "INSERT INTO daojubaofei(danhao, djzt, sqbz, sqr, sqsb, sqsj, jglj, gx, djlx, djgg, djcd, djid, bfyy, spld, spyj, spsj, jbr) values('" + dh + "', '" + djzt + "', '" + sqbz + "', '" + sqr + "', '" + sqsb + "', '" + sqsj + "', '" + jglj + "', '" + gx + "', '" + djlx + "', '" + djgg + "', '" + djcd + "', '" + djid + "', '" + bfyy + "', '" + spld + "', '" + spyj + "', '" + spsj + "', '" + jbr + "')";
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
                    string bfyy = BFYY.Text.ToString().Trim();//更换理由
                    string spld = SPLD.Text.ToString().Trim();//审批领导
                    string spyj = SPYJ.Text.ToString().Trim();//审批意见
                    string spsj = SPSJ.Text.ToString().Trim();//审批时间
                    string jbr = JBR.Text.ToString().Trim();//经办人

                    //判断是否是暂存单据，存入刀具报废数据库
                    if(Alex.CunZai(BFDH.Text.ToString().Trim(), DanHaoZD, DanJuBiao) != 0 )
                    {
                        Sqlstr = string.Format("UPDATE {0} SET djzt = '{1}', sqbz = '{2}', sqr = '{3}', sqsb = '{4}', sqsj = '{5}', jglj = '{6}', gx = '{7}', djlx = '{8}', djgg = '{9}', djcd = '{10}', djid = '{11}', bfyy = '{12}', spld = '{13}', spyj = '{14}', spsj = '{15}', jbr = '{16}' WHERE {17} = '{18}'", DanJuBiao, djzt, sqbz, sqr, sqsb, sqsj, jglj, gx, djlx, djgg, djcd, djid, bfyy, spld, spyj, spsj, jbr, DanHaoZD, dh);
                    }
                    else
                    {
                        Sqlstr = "INSERT INTO daojubaofei(danhao, djzt, sqbz, sqr, sqsb, sqsj, jglj, gx, djlx, djgg, djcd, djid, bfyy, spld, spyj, spsj, jbr) values('" + dh + "', '" + djzt + "', '" + sqbz + "', '" + sqr + "', '" + sqsb + "', '" + sqsj + "', '" + jglj + "', '" + gx + "', '" + djlx + "', '" + djgg + "', '" + djcd + "', '" + djid + "', '" + bfyy + "', '" + spld + "', '" + spyj + "', '" + spsj + "', '" + jbr + "')";
                    }
                    int row = SQL.ExecuteNonQuery(Sqlstr);

                    //刀具信息存入流水表
                    Sqlstr = string.Format("INSERT INTO {0}(danhao, dhlx, djlx, djgg, djid, zsl, fsl, wzbm, jtwz ,czsj, jbr, bz) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}' ,'{8}', '{9}', '{10}', '{11}', '{12}')", LiuShuiBiao, dh, "刀具报废", djlx, djgg, djid, "0", "1", sqsb, "", spsj, jbr, "");
                    int row2 = SQL.ExecuteNonQuery(Sqlstr);

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

        #endregion

    }
}
