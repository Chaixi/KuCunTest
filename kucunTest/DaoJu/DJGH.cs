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
    public partial class DJGH : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";
        BaseAlex Alex = new BaseAlex();
        #endregion

        public DJGH()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJGH_Load(object sender, EventArgs e)
        {
            GHDH.Text = Alex.DanHao("DJGH");//自动生成单号

            //申请信息默认值
            SQBZ.SelectedIndex = 0;
            SQSB.SelectedIndex = 0;
            JGLJ.SelectedIndex = 0;
            SQSJ.Text = DateTime.Now.ToString();

            //刀具信息默认值
            string Sqlstr1 = "select distinct daojuleixing from daojutemp";
            Y_DJLX.DataSource = SQL.DataReadList(Sqlstr1);
            Y_DJLX.SelectedIndex = 0;
            Y_DJCD.SelectedIndex = 0;

            X_DJLX.DataSource = Y_DJLX.DataSource;//此处会让新刀具类型与原刀具类型同步更改
            //X_DJLX.DataSource = SQL.DataReadList(Sqlstr1);//此处会让新刀具类型与原刀具类型独立更改
            X_DJLX.SelectedIndex = 0;
            X_DJCD.SelectedIndex = 0;

            //操作信息默认值
            SPLD.SelectedIndex = 0;
            SPYJ.Text = "同意。";
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
        /// 保证原刀具和新刀具的分级选择各自处于联动状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Y_DJLX_SelectedIndexChanged(object sender, EventArgs e)
        {
            Y_DJGG.DataSource = Djlx_Changed(Y_DJLX.Text.ToString().Trim());
            Y_DJGG.SelectedIndex = 0;//选择第一项作为默认值
        }

        private void Y_DJGG_SelectedIndexChanged(object sender, EventArgs e)
        {
            Y_DJID.DataSource = Djgg_Changed(Y_DJLX.Text.ToString().Trim(), Y_DJGG.Text.ToString().Trim());
            Y_DJID.SelectedIndex = 0;
        }

        private void X_DJLX_SelectedIndexChanged(object sender, EventArgs e)
        {
            X_DJGG.DataSource = Djlx_Changed(X_DJLX.Text.ToString().Trim());
            X_DJGG.SelectedIndex = 0;
        }

        private void X_DJGG_SelectedIndexChanged(object sender, EventArgs e)
        {
            X_DJID.DataSource = Djgg_Changed(X_DJLX.Text.ToString().Trim(), X_DJGG.Text.ToString().Trim());
            X_DJID.SelectedIndex = 0;
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
        /// 保存单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确认保存刀具更换申请表？", "保存确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //数据验证
                if (CheckData() == 0)
                {
                    return;//数据输入有误
                }
                else
                {
                    //数据预处理
                    string dh = GHDH.Text.ToString().Trim();//更换单号
                    string sqbz = SQBZ.Text.ToString().Trim();//申请班组
                    string sqr = SQR.Text.ToString().Trim();//申请人
                    string sqsb = SQSB.Text.ToString().Trim();//申请设备
                    string sqsj = SQSJ.Text.ToString().Trim();//申请时间
                    string jglj = JGLJ.Text.ToString().Trim();//加工零件
                    string gx = GX.Text.ToString().Trim();//工序
                    string ydjlx = Y_DJLX.Text.ToString().Trim();//原刀具类型
                    string ydjgg = Y_DJGG.Text.ToString().Trim();//原刀具规格
                    string ydjcd = Y_DJCD.Text.ToString().Trim();//原刀具长度
                    string ydjid = Y_DJID.Text.ToString().Trim();//原刀具ID
                    string xdjlx = X_DJLX.Text.ToString().Trim();//新刀具类型
                    string xdjgg = X_DJGG.Text.ToString().Trim();//新刀具规格
                    string xdjcd = X_DJCD.Text.ToString().Trim();//新刀具长度
                    string xdjid = X_DJID.Text.ToString().Trim();//新刀具ID
                    string ghly = GHLY.Text.ToString().Trim();//更换理由
                    string spld = SPLD.Text.ToString().Trim();//审批领导
                    string spyj = SPYJ.Text.ToString().Trim();//审批意见
                    string spsj = SPSJ.Text.ToString().Trim();//审批时间
                    string jbr = JBR.Text.ToString().Trim();//经办人

                    Sqlstr = "insert into daojugenghuan(danhao, sqbz, sqr, sqsb, sqsj, jglj, gx, ydjlx, ydjgg, ydjcd, ydjid, xdjlx, xdjgg, xdjcd, xdjid, ghly, spld, spyj, spsj, jbr) values('" + dh + "', '" + sqbz + "', '" + sqr + "', '" + sqsb + "', '" + sqsj + "', '" + jglj + "', '" + gx + "', '" + ydjlx + "', '" + ydjgg + "', '" + ydjcd + "', '" + ydjid + "', '" + xdjlx + "', '" + xdjgg + "', '" + xdjcd + "', '" + xdjid + "', '" + ghly + "', '" + spld + "', '" + spyj + "', '" + spsj + "', '" + jbr + "')";
                    //Sqlstr = "insert into daojuchucang(chucangdanhao, chucangleixing, renmodanhao, renmozhuangtai, lingyongbanzu, lingyongren, chucangriqi, beizhu, caozuoyuan) values('" + CCDH.Text.ToString().Trim() + "', '" + CCLX.Text.ToString().Trim() + "', '" + RMDH.Text.ToString().Trim() + "', '0', '" + LYBZ.Text.ToString().Trim() + LYR.Text.ToString().Trim() + "', '" + CCRQ.Text + "', '" + CCBZ.Text.ToString().Trim() + "', '" + CZY.Text.ToString().Trim() + "')";

                    int row = SQL.ExecuteNonQuery(Sqlstr);
                    if (row != 0)
                    {
                        MessageBox.Show("刀具更换单保存成功！", "提示", MessageBoxButtons.OK);
                        //this.InitializeComponent();
                        //this.OnLoad(null);
                        //this.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 更换历史按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确认打开更换历史记录并关闭此窗口？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                History djgh = new History("DJGH");
                djgh.Show();
                this.Close();
            }
        }

        /// <summary>
        /// 取消单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("是否取消填写刀具更换申请单？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
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
            else if (X_DJLX.Text.ToString().Trim() == Y_DJLX.Text.ToString().Trim() && X_DJGG.Text.ToString().Trim() == Y_DJGG.Text.ToString().Trim() && X_DJCD.Text.ToString().Trim() == Y_DJCD.Text.ToString().Trim() && X_DJID.Text.ToString().Trim() == Y_DJID.Text.ToString().Trim())
            {
                tishi = "原刀具与新刀具信息一致！";
            }
            else if(GHLY.Text.Trim() == "")
            {
                tishi = "刀具更换理由不能为空！";
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
