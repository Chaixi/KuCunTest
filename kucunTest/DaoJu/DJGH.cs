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
using kucunTest.quanxianguanli;


namespace kucunTest.DaoJu
{
    public partial class DJGH : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";

        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();
        private Authorize Authorise = new Authorize();

        string LogType = "刀具更换";
        string LogMessage = "";

        #endregion

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DJGH()
        {
            InitializeComponent();

            GHDH.Text = Alex.DanHao("DJGH");//自动生成单号

            //申请信息默认值
            //SQBZ.SelectedIndex = 0;
            //SQSB.SelectedIndex = 0;
            //JGLJ.SelectedIndex = 0;
            SQSJ.Text = DateTime.Now.ToString();

            //刀具信息默认值
            Y_DJLX.DataSource = Alex.GetList("djlx");
            //string Sqlstr1 = "select distinct daojuleixing from daojutemp";
            //Y_DJLX.DataSource = SQL.DataReadList(Sqlstr1);
            Y_DJLX.SelectedIndex = -1;
            //Y_DJCD.SelectedIndex = 0;

            //X_DJLX.DataSource = Y_DJLX.DataSource;//此处会让新刀具类型与原刀具类型同步更改
            X_DJLX.DataSource = Alex.GetList("djlx");//此处会让新刀具类型与原刀具类型独立更改
            X_DJLX.SelectedIndex = -1;
            //X_DJCD.SelectedIndex = 0;

            //操作信息默认值
            SPLD.SelectedIndex = 0;
            SPYJ.Text = "同意。";
            JBR.SelectedIndex = 0;

            //加载申请班组
            SQBZ.DataSource = Alex.GetList("bz");
            SQBZ.SelectedIndex = -1;
        }

        /// <summary>
        /// 重写构造函数，用于从历史记录窗体加载数据
        /// </summary>
        /// <param name="dh">更换单号</param>
        public DJGH(string dh)
        {
            InitializeComponent();

            //根据单号查询数据库
            Sqlstr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", DaoJuGengHuan.TableName, DaoJuGengHuan.danhao, dh);
            DataSet ds = SQL.getDataSet(Sqlstr, DaoJuGengHuan.TableName);

            //赋值
            GHDH.Text = dh.ToString();
            SQBZ.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.sqbz].ToString();//申请班组
            SQSB.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.sqsb].ToString();//申请设备
            SQR.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.sqr].ToString();//申请人
            JGLJ.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.jglj].ToString();//加工零件
            SQSJ.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][DaoJuGengHuan.sqsj].ToString());//申请时间
            GX.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.gx].ToString();//工序
            Y_DJLX.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.ydjlx].ToString();//原刀具类型
            Y_DJGG.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.ydjgg].ToString();//原刀具规格
            Y_DJCD.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.ydjcd].ToString();//原刀具长度
            Y_DJID.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.ydjid].ToString();//原刀具id
            X_DJLX.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.xdjlx].ToString();//新刀具类型
            X_DJGG.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.xdjgg].ToString();//新刀具规格
            X_DJCD.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.xdjcd].ToString();//新刀具长度
            X_DJID.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.xdjid].ToString();//新刀具id
            GHLY.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.ghly].ToString();//更换理由
            SPLD.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.spld].ToString();//审批领导
            SPYJ.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.spyj].ToString();//审批意见
            SPSJ.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][DaoJuGengHuan.spsj].ToString());//审批时间
            JBR.Text = ds.Tables[0].Rows[0][DaoJuGengHuan.jbr].ToString();//经办人
            string djzt = ds.Tables[0].Rows[0][DaoJuGengHuan.djzt].ToString();//单据状态

            //若是已完成的单据，则只允许查看，不许修改。
            if (djzt == "1")
            {
                Alex.DisableAllControl(this);
                btn_print.Enabled = true;
            }            
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJGH_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);

            //设置权限
            this.Authorise.setAuthority(this, AuthoritiesString.FormName.djghFrm);
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
            Y_DJGG.SelectedIndex = -1;//选择第一项作为默认值
        }

        private void Y_DJGG_SelectedIndexChanged(object sender, EventArgs e)
        {
            Y_DJID.DataSource = Djgg_Changed(Y_DJLX.Text.ToString().Trim(), Y_DJGG.Text.ToString().Trim());
            Y_DJID.SelectedIndex = -1;
        }

        private void X_DJLX_SelectedIndexChanged(object sender, EventArgs e)
        {
            X_DJGG.DataSource = Djlx_Changed(X_DJLX.Text.ToString().Trim());
            X_DJGG.SelectedIndex = -1;
        }

        private void X_DJGG_SelectedIndexChanged(object sender, EventArgs e)
        {
            //X_DJID.DataSource = Djgg_Changed(X_DJLX.Text.ToString().Trim(), X_DJGG.Text.ToString().Trim());
            //X_DJID.SelectedIndex = -1;

            //X_DJID.DataSource = Djgg_Changed(X_DJLX.Text.ToString().Trim(), X_DJGG.Text.ToString().Trim());
            string sql = string.Format("SELECT {1} FROM {0} WHERE {2} = 'S' AND {3} = '{4}' AND {5} = '{6}'", DaoJuTemp.TableName, DaoJuTemp.id, DaoJuTemp.weizhibiaoshi, DaoJuTemp.leixing, X_DJLX.Text.ToString(), DaoJuTemp.guige, X_DJGG.Text.ToString());
            X_DJID.DataSource = SQL.DataReadList(sql);
            X_DJID.SelectedIndex = -1;

            string sqlstr = string.Format("SELECT jcdjk.{2} FROM {0} jcdjk LEFT JOIN {1} djtp ON concat(djtp.{3},'-', djtp.{4} ) = concat(jcdjk.{5},'-', jcdjk.{6}) WHERE djtp.{7} IS NULL AND jcdjk.{5} = '{8}'", JiChuangDaoJuKu.TableName, DaoJuTemp.TableName, JiChuangDaoJuKu.dth, DaoJuTemp.weizhibianma, DaoJuTemp.csordth, JiChuangDaoJuKu.jcbm, JiChuangDaoJuKu.dth, DaoJuTemp.id, SQSB.Text.ToString());
            //string sqlstr = "SELECT jcdjk.daotaohao FROM jcdaojuku jcdjk LEFT JOIN daojutemp djtp ON concat(djtp.weizhi,'-', djtp.cengshu ) = concat(jcdjk.jichuangbianma,'-', jcdjk.daotaohao ) where djtp.daojuid is NULL and jcdjk.jichuangbianma = '" + SQSB.Text.ToString() + "'";
            X_DTH.DataSource = SQL.DataReadList(sqlstr);
            X_DTH.SelectedIndex = -1;
        }

        /// <summary>
        /// 刀具信息三级联动之刀具类型更改，刀具规格相应变化的公有函数
        /// </summary>
        /// <param name="djlx">要查询的刀具类型</param>
        /// <returns></returns>
        public List<string> Djlx_Changed(string djlx)
        {
            if(djlx == null || djlx == "")
            {
                return null;
            }
            else
            {
                Sqlstr = string.Format("SELECT DISTINCT {1} FROM {0} WHERE {2} = '{3}'", DaoJuTemp.TableName, DaoJuTemp.guige, DaoJuTemp.leixing, djlx);
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
            else if(djgg == null || djgg == "")
            {
                return null;
            }
            else
            {
                Sqlstr = string.Format("SELECT {1} FROM {0} WHERE {2} = '{3}' AND {4} = '{5}'", DaoJuTemp.TableName, DaoJuTemp.id, DaoJuTemp.leixing, djlx, DaoJuTemp.guige, djgg);
                return SQL.DataReadList(Sqlstr);
            }
        }
        #endregion 刀具信息三级联动部分结束

        #region 按钮部分
        /// <summary>
        /// 保存单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (SQBZ.Text == "" && SQR.Text == "" && SQSB.Text == "" && JGLJ.Text == "" && SPLD.Text == "" && SPYJ.Text == "" && JBR.Text == "")//未填写申请信息和操作信息，提示取消填写单据
            {
                if (MessageBox.Show("单据申请信息和操作信息均为空，取消填写单据？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                //数据预处理
                string djzt = "0";//单据状态
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

                //存入数据库前判断此单号是否存在
                if (Alex.CunZai(dh, DaoJuGengHuan.danhao, DaoJuGengHuan.TableName) != 0)
                {
                    //已存在， 使用UPDATE语句
                    Sqlstr = string.Format("UPDATE {0} SET djzt = '{1}', sqbz = '{2}', sqsb = '{3}', sqr = '{4}', sqsj = '{5}', jglj = '{6}', gx = '{7}', ydjlx = '{8}', ydjgg = '{9}', ydjcd = '{10}', ydjid = '{11}', xdjlx = '{12}', xdjgg = '{13}', xdjcd = '{14}', xdjid = '{15}', ghly = '{16}', spld = '{17}', spyj = '{18}', spsj = '{19}', jbr = '{20}' WHERE danhao = '{21}'", DaoJuGengHuan.TableName, djzt, sqbz, sqsb, sqr, sqsj, jglj, gx, ydjlx, ydjgg, ydjcd, ydjid, xdjlx, xdjgg, xdjcd, xdjid, ghly, spld, spyj, spsj, jbr, dh);
                    LogMessage = string.Format("成功更新1张单据编号为{0}的刀具更换暂存单据。", dh);

                }
                else
                {
                    //不存在，直接使用INSERT语句
                    Sqlstr = "INSERT INTO daojugenghuan(danhao, djzt, sqbz, sqr, sqsb, sqsj, jglj, gx, ydjlx, ydjgg, ydjcd, ydjid, xdjlx, xdjgg, xdjcd, xdjid, ghly, spld, spyj, spsj, jbr) values('" + dh + "', '" + djzt + "', '" + sqbz + "', '" + sqr + "', '" + sqsb + "', '" + sqsj + "', '" + jglj + "', '" + gx + "', '" + ydjlx + "', '" + ydjgg + "', '" + ydjcd + "', '" + ydjid + "', '" + xdjlx + "', '" + xdjgg + "', '" + xdjcd + "', '" + xdjid + "', '" + ghly + "', '" + spld + "', '" + spyj + "', '" + spsj + "', '" + jbr + "')";
                    LogMessage = string.Format("成功保存1张单据编号为{0}的刀具更换新单据。", dh);

                }

                int row = SQL.ExecuteNonQuery(Sqlstr);
                if (row != 0)
                {
                    MessageBox.Show("单据保存成功！可再次修改。", "提示", MessageBoxButtons.OK);

                    //日志记录
                    Program.WriteLog(LogType, LogMessage);
                    LogMessage = "";

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
        private void button2_Click(object sender, EventArgs e)
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
                    string djzt = "1";//单据状态
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

                    string dskysl1 = "";//原刀具类型的当时可用数量！！！当时可用数量为单据操作后的刀具可用数量
                    string dskysl2 = "";//新刀具类型的当时可用数量！！！当时可用数量为单据操作后的刀具可用数量

                    //查询此类型刀具当时可用数量, 原刀具可用数量减一，新刀具可用数量加一
                    dskysl1 = (Alex.Count_djsl(ydjlx, "kysl") + 1).ToString();
                    dskysl2 = (Alex.Count_djsl(xdjlx, "kysl") - 1).ToString();

                    //存入数据库前判断此单号是否存在
                    if (Alex.CunZai(dh, DaoJuGengHuan.danhao, DaoJuGengHuan.TableName) != 0)
                    {
                        //已存在， 使用UPDATE语句
                        //Sqlstr = "UPDATE daojugenghuan(danhao, djzt, sqbz, sqr, sqsb, sqsj, jglj, gx, ydjlx, ydjgg, ydjcd, ydjid, xdjlx, xdjgg, xdjcd, xdjid, ghly, spld, spyj, spsj, jbr) values('" + dh + "', '" + "1', '" + sqbz + "', '" + sqr + "', '" + sqsb + "', '" + sqsj + "', '" + jglj + "', '" + gx + "', '" + ydjlx + "', '" + ydjgg + "', '" + ydjcd + "', '" + ydjid + "', '" + xdjlx + "', '" + xdjgg + "', '" + xdjcd + "', '" + xdjid + "', '" + ghly + "', '" + spld + "', '" + spyj + "', '" + spsj + "', '" + jbr + "')";
                        Sqlstr = string.Format("UPDATE {0} SET djzt = '{1}', sqbz = '{2}', sqsb = '{3}', sqr = '{4}', sqsj = '{5}', jglj = '{6}', gx = '{7}', ydjlx = '{8}', ydjgg = '{9}', ydjcd = '{10}', ydjid = '{11}', xdjlx = '{12}', xdjgg = '{13}', xdjcd = '{14}', xdjid = '{15}', ghly = '{16}', spld = '{17}', spyj = '{18}', spsj = '{19}', jbr = '{20}' WHERE danhao = '{21}'", DaoJuGengHuan.TableName, djzt, sqbz, sqsb, sqr, sqsj, jglj, gx, ydjlx, ydjgg, ydjcd, ydjid, xdjlx, xdjgg, xdjcd, xdjid, ghly, spld, spyj, spsj, jbr, dh);
                    }
                    else
                    {
                        //不存在，直接使用INSERT语句
                        Sqlstr = "INSERT INTO daojugenghuan(danhao, djzt, sqbz, sqr, sqsb, sqsj, jglj, gx, ydjlx, ydjgg, ydjcd, ydjid, xdjlx, xdjgg, xdjcd, xdjid, ghly, spld, spyj, spsj, jbr) values('" + dh + "', '" + "1', '" + sqbz + "', '" + sqr + "', '" + sqsb + "', '" + sqsj + "', '" + jglj + "', '" + gx + "', '" + ydjlx + "', '" + ydjgg + "', '" + ydjcd + "', '" + ydjid + "', '" + xdjlx + "', '" + xdjgg + "', '" + xdjcd + "', '" + xdjid + "', '" + ghly + "', '" + spld + "', '" + spyj + "', '" + spsj + "', '" + jbr + "')";
                    }

                    int row1 = SQL.ExecuteNonQuery(Sqlstr);

                    //刀具信息存入流水表
                    Sqlstr = string.Format("INSERT INTO {0}(danhao, dhlx, djlx, djgg, djid, zsl, fsl, dskysl, wzbm, jtwz ,czsj, jbr, bz) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}' ,'{8}', '{9}', '{10}', '{11}', '{12}', '{13}')", DaoJuLiuShui.TableName, dh, "刀具更换", ydjlx, ydjgg, ydjid, "1", "0", dskysl1, "", "", spsj, jbr, "");
                    int row2 = SQL.ExecuteNonQuery(Sqlstr);//原刀具
                    Sqlstr = string.Format("INSERT INTO {0}(danhao, dhlx, djlx, djgg, djid, zsl, fsl, dskysl, wzbm, jtwz ,czsj, jbr, bz) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}' ,'{8}', '{9}', '{10}', '{11}', '{12}', '{13}')", DaoJuLiuShui.TableName, dh, "刀具更换", xdjlx, xdjgg, xdjid, "0", "1", dskysl2, sqsb, "", spsj, jbr, "");
                    int row3 = SQL.ExecuteNonQuery(Sqlstr);//新刀具

                    if (row1 != 0)
                    {
                        MessageBox.Show("刀具更换单据确认成功！", "提示", MessageBoxButtons.OK);

                        //日志记录
                        LogMessage = string.Format("成功确认1张单据编号为{0}的刀具更换单据。", GHDH.Text);
                        Program.WriteLog(LogType, LogMessage);
                        LogMessage = "";

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
        private void btn_print_Click(object sender, EventArgs e)
        {
            //数据验证
            if (CheckData() == 0)
            {
                return;//数据输入有误
            }
            else
            {
                Report FReport = new Report();
                string sPath = @"../../File/刀具更换申请单.frx";
                FReport.Load(sPath);

                FReport.SetParameterValue("danhao", GHDH.Text);
                FReport.SetParameterValue("sqbz", SQBZ.Text);
                FReport.SetParameterValue("sqr", SQR.Text);
                FReport.SetParameterValue("sqsb", SQSB.Text.ToString());
                FReport.SetParameterValue("jglj", JGLJ.Text);
                FReport.SetParameterValue("gx", GX.Text);
                FReport.SetParameterValue("sqsj", SQSJ.Text);
                FReport.SetParameterValue("jbr", JBR.Text);
                FReport.SetParameterValue("spld", SPLD.Text);
                FReport.SetParameterValue("spyj", SPYJ.Text);
                FReport.SetParameterValue("spsj", SPSJ.Text.ToString());
                FReport.SetParameterValue("ydjlx", Y_DJLX.Text.ToString());
                FReport.SetParameterValue("ydjgg", Y_DJGG.Text.ToString());
                FReport.SetParameterValue("ydjcd", Y_DJCD.Text.ToString());
                FReport.SetParameterValue("ydjid", Y_DJID.Text.ToString());
                FReport.SetParameterValue("xdjlx", X_DJLX.Text.ToString());
                FReport.SetParameterValue("xdjgg", X_DJGG.Text.ToString());
                FReport.SetParameterValue("xdjcd", X_DJCD.Text.ToString());
                FReport.SetParameterValue("xdjid", X_DJID.Text.ToString());
                FReport.SetParameterValue("ghly", GHLY.Text.ToString());

                //显示报表
                FReport.Prepare();
                FReport.ShowPrepared();

                //日志记录
                LogMessage = string.Format("成功打印1张单据编号为{0}的刀具更换单据。", GHDH.Text);
                Program.WriteLog(LogType, LogMessage);
                LogMessage = "";
            }
        }

        /// <summary>
        /// 更换历史按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认打开更换历史记录并关闭此窗口？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                History djgh = new History("DJGH");
                djgh.Show();
                this.Close();
            }
        }

        /// <summary>
        /// 删除单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_Click(object sender, EventArgs e)
        {
            if (Alex.CunZai(GHDH.Text.ToString().Trim(), DaoJuGengHuan.danhao, DaoJuGengHuan.TableName) != 0)//单据已保存，数据库存在
            {
                if (MessageBox.Show("确认删除此单据？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //删除刀具更换表中的数据
                    Sqlstr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", DaoJuGengHuan.TableName, DaoJuGengHuan.danhao, GHDH.Text.ToString().Trim());
                    int row1 = SQL.ExecuteNonQuery(Sqlstr);
                    MessageBox.Show("成功删除" + row1 + "张单据!");

                    //日志记录
                    LogMessage = "成功删除" + row1 + "张单据!";
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
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion 按钮部分结束

        #region 其他部分
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
                    //SQBZ.DroppedDown = true;
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
            else if (GHLY.Text.Trim() == "")
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

        /// <summary>
        /// 窗口自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJGH_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        /// <summary>
        /// 当窗体在选项卡中打开时，关闭窗体则关闭相应的选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJGH_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Parent != null)
            {
                MainForm mfr = (MainForm)this.Parent.FindForm();
                mfr.CloseTab(this.Name);
            }
        }
        #endregion 其他部分结束

        /// <summary>
        /// 从刀具管理界面进行刀具更换
        /// </summary>
        /// <param name="tb">要进行更换的刀具</param>
        public void AddDataFromTable(DataTable tb)
        {
            Y_DJLX.Text = tb.Rows[0]["djlx"].ToString();
            Y_DJLX.Enabled = false;
            Y_DJGG.Text = tb.Rows[0]["djgg"].ToString();
            Y_DJGG.Enabled = false;
            Y_DJID.Text = tb.Rows[0]["djid"].ToString();
            Y_DJID.Enabled = false;

            string djwz = tb.Rows[0]["djwz"].ToString().Trim();
            //string[] sArray = djwz.Split('-');
            SQSB.Text = djwz.Substring(2, djwz.Length - 6);//截取机床编码，去掉2位位置标识前缀和4位具体位置标识
            SQSB.Enabled = false;
            Y_DTH.Text = djwz.Substring(djwz.Length - 3);
            Y_DTH.Enabled = false;
        }

        /// <summary>
        /// 新原刀具刀套号保持一致
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Y_DTH_SelectedIndexChanged(object sender, EventArgs e)
        {
            X_DTH.Text = Y_DTH.Text;
        }

        /// <summary>
        /// 申请班组变化加载相应机床数据源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SQBZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SQBZ.SelectedIndex < 0)
            {
                SQSB.DataSource = null;
                return;
            }

            SQSB.DataSource = Alex.GetJCofBZ(SQBZ.Text);
        }
    }
}
