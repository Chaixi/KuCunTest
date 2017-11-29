using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using kucunTest.BaseClasses;

namespace kucunTest.DaoJu
{
    public partial class DaoJuCanShuXinXi : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";

        AutoSizeFormClass asc = new AutoSizeFormClass();

        string ID = "";//刀具ID
        string daojubiao = "daojutemp";
        string jichucanshubiao = "jichucanshu";
        string celiangcanshubiao = "celiangcanshu";
        string guanlianbiao = "daojulingbujian";
        
        string[] CP = new string[11];//全局变量，存储初始从数据库加载的测量值，用于与新数据对比,也是已经保存的最新测量数据
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id"></param>
        public DaoJuCanShuXinXi(string id)
        {
            InitializeComponent();

            ID = id;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DaoJuCanShuXinXi_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);

            //查询刀具表中对应刀具类型和刀具规格
            Sqlstr = string.Format("SELECT {1}, {2}, {3} FROM {0} WHERE {4} = '{5}'", DaoJuTemp.TableName, DaoJuTemp.leixing, DaoJuTemp.guige, DaoJuTemp.xinghao, DaoJuTemp.id, ID);
            DataTable db1 = SQL.getDataSet(Sqlstr, DaoJuTemp.TableName).Tables[0];

            //赋值
            djlx.Text = db1.Rows[0]["daojuleixing"].ToString();
            djgg.Text = db1.Rows[0]["daojuguige"].ToString();
            string djxh = db1.Rows[0]["daojuxinghao"].ToString();
            djid.Text = ID;

            //查询基础参数表中刀具基础信息
            Sqlstr = string.Format("SELECT {1}, {2} FROM {0} WHERE {3} = '{4}'", DaoJuCanShu.TableName, DaoJuCanShu.csdm, DaoJuCanShu.csz, DaoJuCanShu.ssfm, djxh);
            DataTable db2 = SQL.getDataSet(Sqlstr, DaoJuCanShu.TableName).Tables[0];

            //遍历基础参数
            if(db2.Rows.Count > 0)
            {
                foreach (Control c in grp_jc.Controls)
                {
                    if (c is TextBox)
                    {
                        if (db2.Rows.Count <= 0)
                        {
                            c.Text = "";
                        }
                        else
                        {
                            for (int i = 0; i < db2.Rows.Count; i++)
                            {
                                if (db2.Rows[i]["csdm"].ToString() == c.Name)
                                {
                                    c.Text = db2.Rows[i]["csz"].ToString();
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            //查询刀具测量信息
            Sqlstr = string.Format("SELECT * FROM {0} WHERE djid = '{1}' ORDER BY clsj DESC", celiangcanshubiao, ID);//最新的测量数据
            DataTable db3 = SQL.getDataSet(Sqlstr, celiangcanshubiao).Tables[0];
            //赋值前判断是否为空
            if(db3.Rows.Count > 0)
            {
                cp1.Text = db3.Rows[0]["djzjxddsl"].ToString();
                CP[0] = cp1.Text;

                cp2.Text = db3.Rows[0]["dqgjbmccd"].ToString();
                CP[1] = cp2.Text;

                cp3.Text = db3.Rows[0]["yqgjbmccd"].ToString();
                CP[2] = cp3.Text;

                cp4.Text = db3.Rows[0]["djsysm"].ToString();
                CP[3] = cp4.Text;

                cp5.Text = db3.Rows[0]["djbjsjz"].ToString();
                CP[4] = cp5.Text;

                cp6.Text = db3.Rows[0]["djcdsjz"].ToString();
                CP[5] = cp6.Text;

                cp7.Text = db3.Rows[0]["djzpj"].ToString();
                CP[6] = cp7.Text;

                cp8.Text = db3.Rows[0]["djfpj"].ToString();
                CP[7] = cp8.Text;

                cp9.Text = db3.Rows[0]["djyhbj"].ToString();
                CP[8] = cp9.Text;

                cp10.Text = db3.Rows[0]["djdmtd"].ToString();
                CP[9] = cp10.Text;

                cp11.Text = db3.Rows[0]["djjxtd"].ToString();
                CP[10] = cp11.Text;
            }
            else
            {
                CP = null;
            }

            //查询刀具组成零部件信息
            //Sqlstr = string.Format("SELECT lbjmc, lbjxh, lbjgg, sl, dw FROM {0} t1 LEFT JOIN {1} t2 ON t1.djxh = t2.daojuxinghao WHERE t2.daojuid = '{2}'", guanlianbiao, daojubiao, ID);
            //lingbujianzucheng.AutoGenerateColumns = false;
            //lingbujianzucheng.DataSource = SQL.getDataSet1(Sqlstr).Tables[0].DefaultView;

        }

        /// <summary>
        /// 保存数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //格式化数据
            string[] str = { cp1.Text, cp2.Text, cp3.Text, cp4.Text, cp5.Text, cp6.Text, cp7.Text, cp8.Text, cp9.Text, cp10.Text, cp11.Text };

            if (CheckData(str))//检查测量数据是否为空
            {
                if (CP == null || CompareData(str))//判断textbox值是否有改变
                {
                    Sqlstr = string.Format("INSERT INTO {0}(djid, clsj, djzjxddsl, dqgjbmccd, yqgjbmccd, djsysm, djbjsjz, djcdsjz, djzpj, djfpj, djyhbj, djdmtd, djjxtd) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}')", celiangcanshubiao, ID, DateTime.Now, cp1.Text, cp2.Text, cp3.Text, cp4.Text, cp5.Text, cp6.Text, cp7.Text, cp8.Text, cp9.Text, cp10.Text, cp11.Text);
                    int row1 = SQL.ExecuteNonQuery(Sqlstr);
                    if (row1 == 1)
                    {
                        MessageBox.Show("测量数据保存成功！");
                        CP = str;//更新最新测量值
                        //this.Close();

                        //日志记录
                        Program.WriteLog("刀具测量", string.Format("刀具ID为{0}的{1}测量参数更新成功。", ID, djlx.Text.ToString()));
                    }
                }
                else
                {
                    MessageBox.Show("还未对测量数据做任何更改！");
                }
            }
            else
            {
                MessageBox.Show("测量数据为空！");
            }                        
        }

        /// <summary>
        /// 获取测量数据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            /*
            //刀具的objId和StepId ? 用于查找测量数据
            string ObjId = "";//刀具ID?
            string StepId = "";//刀段号?

            //连接并打开zoller数据库
            string source = "server = .; database = ZOLLERDB3; uid = sa; pwd = 123456;";
            SqlConnection conn = new SqlConnection(source);
            conn.Open();

            //从数据库把数据表取出
            //sql语句需要重写，可能需要联合表
            string SqlStr = string.Format("SELECT TOP 10 [ObjId], [StepId], [MeasureHistoryDate], [ZActual], [XActual], [RadiusActual], [Angle1Actual], [Angle2Actual], [UserTxt], [MeasureTimeInSeconds] FROM [ZOLLERDB3].[dbo].[BasicMeasureHistory]");
            SqlDataAdapter da = new SqlDataAdapter(SqlStr, conn);

            //关闭数据库
            conn.Close();

            DataSet ds = new DataSet();
            da.Fill(ds, "[ZOLLERDB3].[dbo].[BasicMeasureHistory]");

            //测量数据填补进系统界面中
            DataTable db = ds.Tables[0].Copy();
            */

            MessageBox.Show("暂时不支持从ZOLLER对刀仪获取刀具测量数据，请手动输入。", Program.tishiTitle);

            //日志记录
            Program.WriteLog("刀具测量", "获取测量数据失败：暂不支持从ZOLLER对刀仪获取刀具测量数据。");
            
        }

        #region 数据检查和对比方法
        /// <summary>
        /// 判断textbox值是否有改变
        /// </summary>
        /// <param name="str">要有初始数据库测量数据CP对比的测量数据数组</param>
        /// <returns></returns>
        private bool CompareData(string[] str)
        {
            for(int i = 0; i < str.Count(); i++)
            {
                if(CP[i].CompareTo(str[i]) != 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 判断测量数据是否全为空
        /// </summary>
        /// <param name="str">要检查的测量数据数组</param>
        /// <returns></returns>
        private bool CheckData(string[] str)
        {
            for(int i = 0; i < str.Count(); i++)
            {
                if(str[i] != "" || str[i].Length != 0 || str[i] != null)
                {
                    return true;//只要有一个不为空就返回true
                }
            }

            return false;//全都为空
        }

        #endregion 数据检查和对比方法结束

        /// <summary>
        /// 窗口自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label33_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
