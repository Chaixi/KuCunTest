using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using MySql.Data;

using FastReport;
using FastReport.Editor;
using FastReport.Data;

namespace kucunTest.FastReport
{
    public partial class FastReport测试 : Form
    {
        #region 全局变量
        private MySql SQL = new MySql();
        private string SqlStr = "";
        private DataSet ds;
        #endregion

        public FastReport测试()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlStr = "select * from daojuchucangmingxi";
            ds = SQL.getDataSet(SqlStr, "daojuchucangmingxi");

            MessageBox.Show("加载数据成功！");

            grid1.DataSource = ds.Tables[0].DefaultView;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Report re = new Report();
            //string filename = @"C:\Users\workstation\Desktop\test1.frx";

            //re.Load(filename);
            //re.RegisterData(ds);
            ////re.GetDataSource(ds.Tables[0].TableName).Enabled = true;
            //re.Show();

            //DataSet ds1 = new DataSet();
            //DataTable table1 = new DataTable();

            //table1.TableName = "Table1"; // 一定要设置表名称
            //ds1.Tables.Add(table1); // 添加表中的列

            //table1.Columns.Add("xh", typeof(string));
            //table1.Columns.Add("chucangdanhao", typeof(string));
            //table1.Columns.Add("daojuleixing", typeof(string));
            //table1.Columns.Add("daojuguige", typeof(string));
            //table1.Columns.Add("daojuid", typeof(string));
            //table1.Columns.Add("shuliang", typeof(string));
            //table1.Columns.Add("jichuangbianma", typeof(string));
            //table1.Columns.Add("daotaohao", typeof(string));
            //table1.Columns.Add("beizhu", typeof(string));

            //// 任意添加一些数据
            //for (int i = 0, maxI = 3; i < maxI; i++)
            //{
            //    DataRow row = table1.NewRow();
            //    row["xh"] = "我是" + i.ToString();
            //    row["chucangdanhao"] = i.ToString();
            //    row["daojuleixing"] = i.ToString();
            //    row["daojuguige"] = i.ToString();
            //    row["daojuid"] = i.ToString();
            //    row["shuliang"] = i.ToString();
            //    row["jichuangbianma"] = i.ToString();
            //    row["daotaohao"] = i.ToString();
            //    row["beizhu"] = i.ToString();
            //    table1.Rows.Add(row);
            //}

            ds.Tables[0].TableName = "Table1";

            Report FReport = new Report();
            string sPath = @"C:\Users\workstation\Desktop\test2.frx";
            FReport.Load(sPath);  // 将DataSet对象注册到FastReport控件中
            //FReport.RegisterData(ds1);
            FReport.RegisterData(ds);

            FReport.SetParameterValue("danhao", danhao.Text);
            FReport.SetParameterValue("lybz", LYBZ.Text);
            FReport.SetParameterValue("ZJGX", ZJGX.Text);
            FReport.SetParameterValue("LYRQ", LYRQ.Text.ToString());
            FReport.SetParameterValue("LYSB", LYSB.Text);
            FReport.SetParameterValue("beizhu", beizhu.Text);
            FReport.SetParameterValue("spr", SPR.Text);
            FReport.SetParameterValue("JBR", JBR.Text);
            FReport.SetParameterValue("LYR", LYR.Text);


            //显示报表
            FReport.Prepare();
            FReport.ShowPrepared();
            //FReport.Show();
        }
    }
}
