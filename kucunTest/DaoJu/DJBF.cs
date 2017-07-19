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
    public partial class DJBF : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";
        BaseAlex Alex = new BaseAlex();
        #endregion

        public DJBF()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJBF_Load(object sender, EventArgs e)
        {
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
        /// 审批时间默认与申请时间保持一致
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SQSJ_ValueChanged(object sender, EventArgs e)
        {
            SPSJ.Value = SQSJ.Value;
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

        /// <summary>
        /// 取消单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否取消填写刀具报废申请单？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 保存单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认保存刀具报废申请表？", "保存确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //数据验证
                if (CheckData() == 0)
                {
                    return;//数据输入有误
                }
                else
                {
                    //数据预处理
                    string dh = BFDH.Text.ToString().Trim();//更换单号
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

                    Sqlstr = "insert into daojubaofei(danhao, sqbz, sqr, sqsb, sqsj, jglj, gx, djlx, djgg, djcd, djid, bfyy, spld, spyj, spsj, jbr) values('" + dh + "', '" + sqbz + "', '" + sqr + "', '" + sqsb + "', '" + sqsj + "', '" + jglj + "', '" + gx + "', '" + djlx + "', '" + djgg + "', '" + djcd + "', '" + djid + "', '" + bfyy + "', '" + spld + "', '" + spyj + "', '" + spsj + "', '" + jbr + "')";

                    int row = SQL.ExecuteNonQuery(Sqlstr);
                    if (row != 0)
                    {
                        MessageBox.Show("刀具报废申请单保存成功！", "提示", MessageBoxButtons.OK);
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
            else if (DJLX.Text.ToString().Trim() == "" || DJGG.Text.ToString().Trim() == "" || DJCD.Text.ToString().Trim() == "" || DJID.Text.ToString().Trim() == "" )
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
    }
}
