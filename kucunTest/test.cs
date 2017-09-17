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

namespace kucunTest
{
    public partial class test : Form
    {
        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();

        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            //asc.controllInitializeSize(this);

            //加载所有数据库
            button1_Click(null, null);
        }

        private void test_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);
        }

        #region 按钮部分
        /// <summary>
        /// 加载数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //连接并打开数据库
            string source = "server = .; database = master; uid = sa; pwd = 123456";
            SqlConnection conn = new SqlConnection(source);
            conn.Open();

            string SqlStr = "SELECT name FROM master..sysdatabases ";
            SqlDataAdapter da = new SqlDataAdapter(SqlStr, conn);
            conn.Close();

            DataSet ds = new DataSet();
            da.Fill(ds, "master..sysdatabases");

            comboBox1.DisplayMember = "name";
            comboBox1.DataSource = ds.Tables[0];
        }

        /// <summary>
        /// 加载数据表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //连接并打开数据库
            string source = string.Format("server = .; database = {0}; uid = sa; pwd = 123456", comboBox1.Text.ToString());
            SqlConnection conn = new SqlConnection(source);
            conn.Open();

            string SqlStr = string.Format("USE {0} SELECT Name FROM SysObjects Where XType = 'U' ORDER BY Name", comboBox1.Text.ToString());
            SqlDataAdapter da = new SqlDataAdapter(SqlStr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "SysObjects");

            comboBox2.DisplayMember = "Name";
            comboBox2.DataSource = ds.Tables[0];
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //连接并打开数据库
            string source = string.Format("server = .; database = {0}; uid = sa; pwd = 123456", comboBox1.Text.ToString());
            SqlConnection conn = new SqlConnection(source);
            conn.Open();

            string SqlStr = string.Format("USE {0} SELECT * FROM {1}", comboBox1.Text.ToString(), comboBox2.Text.ToString());
            SqlDataAdapter da = new SqlDataAdapter(SqlStr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "SysObjects");

            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        #endregion 按钮部分结束

        #region 数据库数据表下拉框联动部分
        /// <summary>
        /// 选择数据库发生变化，则加载相应数据表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //加载数据表
            //连接并打开数据库
            string source = string.Format("server = .; database = {0}; uid = sa; pwd = 123456", comboBox1.Text.ToString());
            SqlConnection conn = new SqlConnection(source);
            conn.Open();

            string SqlStr = string.Format("USE {0} SELECT Name FROM SysObjects Where XType = 'U' ORDER BY Name", comboBox1.Text.ToString());
            SqlDataAdapter da = new SqlDataAdapter(SqlStr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "SysObjects");

            comboBox2.DisplayMember = "Name";
            comboBox2.DataSource = ds.Tables[0];
        }

        /// <summary>
        /// 选择数据表发生变化则加载相应数据表数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            //加载数据
            //连接并打开数据库
            string source = string.Format("server = .; database = {0}; uid = sa; pwd = 123456", comboBox1.Text.ToString());
            SqlConnection conn = new SqlConnection(source);
            conn.Open();

            string SqlStr = string.Format("USE {0} SELECT * FROM {1}", comboBox1.Text.ToString(), comboBox2.Text.ToString());
            SqlDataAdapter da = new SqlDataAdapter(SqlStr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "SysObjects");

            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
        #endregion 数据库数据表下拉框联动部分结束
    }
}
