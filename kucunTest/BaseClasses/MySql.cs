using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace kucunTest
{
    class MySql
    {
        #region 全局变量
        public static string Login_ID = "";  //定义全局变量，记录当前登录的用户编号
        public static string Login_Name = "";    //定义全局变量，记录当前登陆的用户名

        //定义静态全局变量，记录“基础信息”各窗体中的表名、SQL语句以及要添加和修改的字段名
        public static string Mean_SQL = "", Mean_Table = "", Mean_Field = "";

        //定义一个MySqlConnection类型的静态公共变量My_con，用于判断数据库是否连接成功
        public static MySqlConnection My_con;

        //定义数据库连接字符串
        public static string M_str_sqlcon = "Data Source=localhost; Database=kucuntest; Userid=root; PWD=root; port=3036; Charset=utf8";//PC
        //public static string M_str_sqlcon = "Data Source=localhost; Database=kucuntest; Userid=root; PWD=root; Charset=utf8";//LAB-PC
        //public static string M_str_sqlcon = "Data Source=192.168.1.130; Database=kucuntest; Userid=root; PWD=root; Charset=utf8";//同一局域网内实验室电脑
        public static int Login_n = 0;

        //存储职工基本信息表中的SQL语句
        //public static string AllSql = "select * from tb_Staffbasic";
        #endregion

        #region getcon方法：建立并打开数据库连接
        /// <summary>
        /// 建立并打开数据库连接
        /// </summary>
        /// <returns>返回MySqlConnection对象的信息</returns>
        public static MySqlConnection getcon()
        {
            My_con = new MySqlConnection(M_str_sqlcon);  //用MySqlConnection对象与制定的数据库相连接
            My_con.Open();
            return My_con;
        }
        #endregion

        #region con_close方法：判断是否与数据库连接，若连接则关闭数据库连接
        /// <summary>
        /// 判断是否与数据库连接，若连接则关闭数据库连接
        /// </summary>
        public void con_close()
        {
            if(My_con.State == ConnectionState.Open)
            {
                My_con.Close();     //关闭数据库连接
                My_con.Dispose();   //释放My_con变量的所有空间
            }
        }
        #endregion

        #region ExecuteNonQuery方法：执行SQL语句，返回受影响的行数
        ///<summary>对于 UPDATE、INSERT 和 DELETE 语句，返回值为该命令所影响的行数。对于其他所有类型的语句，返回值为 -1。</summary>
        ///<param name="SQLstr">SQL语句</param>
        ///<returns>返回受影响的行数</returns>
        public int ExecuteNonQuery(string SQLstr)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = getcon();
            cmd.CommandText = SQLstr;
            cmd.CommandType = CommandType.Text;
            int rows = Convert.ToInt32(cmd.ExecuteNonQuery());
            return rows;
        }
        #endregion

        #region ExecuteScalar方法：执行SQL语句，返回结果集中第一行的第一列或空引用，结果集为空
        ///<summary>执行SQL语句，返回结果集中第一行的第一列或空引用，结果集为空</summary>
        ///<param name="SQLstr">SQL语句</param>
        ///<returns>结果集中第一行的第一列或空引用</returns>
        public Object ExecuteScalar(string SQLstr)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = getcon();
            cmd.CommandText = SQLstr;
            cmd.CommandType = CommandType.Text;
            object val = cmd.ExecuteScalar();
            return val;
        }
        #endregion

        #region getcom方法：读取数据库中的信息，返回SqlDataReader对象
        /// <summary>
        /// 读取数据库中的信息
        /// </summary>
        /// <param name="SQmLstr">SQL语句</param>
        /// <returns>返回SqlDataReader对象</returns>
        public MySqlDataReader getcom(string SQLstr)
        {
            getcon();  //打开与数据库的连接

            //创建一个SqlCommand对象，用于执行SQL语句
            MySqlCommand My_com = My_con.CreateCommand();
            My_com.CommandText = SQLstr;
            MySqlDataReader My_read = My_com.ExecuteReader();  //执行SQL语句，生成一个SqlDataReader对象
            return My_read;
        }
        #endregion

        #region getsqlcom方法：执行数据库增、删、改操作，无返回值。（但是可以返回受影响的行数）
        /// <summary>
        /// 执行数据库增、删、改操作
        /// </summary>
        /// <param name="SQLstr">SQL语句</param>
        public void getsqlcom(string SQLstr)
        {
            getcon();
            MySqlCommand SQLcom = new MySqlCommand(SQLstr, My_con);
            SQLcom.ExecuteNonQuery();
            SQLcom.Dispose();  //释放所有空间
            con_close();  //调用con_close方法，关闭数据库连接

            //int i = SQLcom.ExecuteNonQuery();//返回受影响的行数，根据需要
            //return i;
        }
        #endregion

        #region getsqlcom1方法：执行数据库增、删、改操作，返回值为1说明SQL语句执行成功
        /// <summary>
        /// 执行数据库增、删、改操作
        /// </summary>
        /// <param name="SQLstr">SQL语句</param>
        /// <returns>返回值为1说明SQL语句执行成功</returns>
        public int getsqlcom1(string SQLstr)
        {
            getcon();
            MySqlCommand SQLcom = new MySqlCommand(SQLstr, My_con);
            SQLcom.ExecuteNonQuery();
            SQLcom.Dispose();  //释放所有空间
            con_close();  //调用con_close方法，关闭数据库连接
            return 1;
        }
        #endregion

        #region getDataSet()方法：单表查询读取数据库中的信息，返回DataSet对象
        /// <summary>
        /// 单表查询读取数据库中的信息
        /// </summary>
        /// <param name="SQLstr">SQL语句</param>
        /// <returns>返回DataSet对象</returns>
        public DataSet getDataSet(string SQLstr, string tableName)
        {
            getcon();
            MySqlDataAdapter SQLda = new MySqlDataAdapter(SQLstr, My_con);
            DataSet My_DataSet = new DataSet();
            SQLda.Fill(My_DataSet, tableName);
            con_close();
            return My_DataSet;  //返回DataSet对象的信息
        }
        #endregion

        #region getDataSet1()方法：多表查询读取数据库中的信息，返回DataSet对象
        /// <summary>
        /// 多表查询读取数据库中的信息
        /// </summary>
        /// <param name="SQLstr">SQL语句</param>
        /// <returns>返回DataSet对象</returns>
        public DataSet getDataSet1(string SQLstr)
        {
            getcon();
            MySqlDataAdapter SQLda = new MySqlDataAdapter(SQLstr, My_con);
            DataSet My_DataSet = new DataSet();
            SQLda.Fill(My_DataSet);  //未知表结构，直接fill Dataset
            con_close();
            return My_DataSet;  //返回DataSet对象的信息
        }
        #endregion

        /// <summary>
        /// 对于 SELECT 语句，返回值为该命令所影响的行数。
        /// </summary>
        /// <param name="SQLstr">sql语句</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public int getCounts(string SQLstr, string tableName)
        {
            getcon();
            MySqlDataAdapter SQLda = new MySqlDataAdapter(SQLstr, My_con);
            DataSet My_DataSet = new DataSet();
            SQLda.Fill(My_DataSet, tableName);
            con_close();
            return My_DataSet.Tables[0].Rows.Count;  //返回查询到的数据的行数
        }

        #region 返回list
        public List<string> DataReadList(string SQLstr)
        {
            List<string> list = new List<string>();
            getcon();
            //创建一个SqlCommand对象，用于执行SQL语句
            MySqlCommand My_com = My_con.CreateCommand();
            My_com.CommandText = SQLstr;
            MySqlDataReader My_read = My_com.ExecuteReader();  //执行SQL语句，生成一个SqlDataReader对象
            while(My_read.Read())
            {
                list.Add(My_read[0].ToString());
            }
            con_close();
            return list;
        }
        #endregion

        #region 返回list
        public List<string> DataReadList2(string SQLstr)
        {
            List<string> list = new List<string>();
            getcon();
            //创建一个SqlCommand对象，用于执行SQL语句
            MySqlCommand My_com = My_con.CreateCommand();
            My_com.CommandText = SQLstr;
            MySqlDataReader My_read = My_com.ExecuteReader();  //执行SQL语句，生成一个SqlDataReader对象
            while (My_read.Read())
            {
                list.Add(My_read[0].ToString());
                list.Add(My_read[1].ToString());
            }
            con_close();
            return list;
        }
        #endregion

        #region 返回list
        public List<string> DataReadList3(string SQLstr)
        {
            List<string> list = new List<string>();
            getcon();
            //创建一个SqlCommand对象，用于执行SQL语句
            MySqlCommand My_com = My_con.CreateCommand();
            My_com.CommandText = SQLstr;
            MySqlDataReader My_read = My_com.ExecuteReader();  //执行SQL语句，生成一个SqlDataReader对象
            while (My_read.Read())
            {
                list.Add(My_read[0].ToString());
                list.Add(My_read[1].ToString());
                list.Add(My_read[2].ToString());
            }
            con_close();
            return list;
        }
        #endregion
    }
}
