﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace kucunTest.BaseClasses
{
    class BaseAlex
    {
        #region 全局变量
        private MySql SQL = new MySql();
        private string Sqlstr = "";
        
        #endregion

        /// <summary>
        /// kong函数，用于数据是否为空
        /// </summary>
        /// <param name="str">需要验证的字符串</param>
        /// <returns></returns>
        public Boolean kong(string str)
        {
            if (str == "" || str == null)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 自动生成单据号
        /// </summary>
        /// <param name="type">单号前缀1，请求单据类型，如出仓单则type='CC'</param>
        /// <returns></returns>
        public string DanHao (string type)
        {
            string dt = DateTime.Now.ToString("yyMMdd");//注意月份是大写M，小写m表示分钟
            string dh = "";//存放新编号
            int count;//记录数据库当天已有单号数量
            string tjb = "";//记录要查询的数据表
            string tjzd = "";//记录要查询数据库的字段

            switch (type)
            {
                case "DJCC"://入仓
                    tjb = "daojulingyong";
                    tjzd = "chucangdanhao";
                    break;
                case "DJWJ"://刀具外借
                    tjb = "daojuwaijie";
                    tjzd = "danhao";
                    break;
                case "DJGH"://刀具更换
                    tjb = "daojugenghuan";
                    tjzd = "danhao";
                    break;
                case "DJBF":
                    tjb = "daojubaofei";
                    tjzd = "danhao";
                    break;
                case "DJTH"://刀具退还单
                    tjb = "daojutuihuan";
                    tjzd = "danhao";
                    break;
                case "LBJLY"://零部件领用单
                    tjb = "lbj_lingyong";
                    tjzd = "danhao";
                    break;
                case "LBJTH"://零部件退还单
                    tjb = "lbj_tuihuan";
                    tjzd = "danhao";
                    break;
            }

            string where = " WHERE " + tjzd + " LIKE '" + type.Trim() + "_" + dt + "%'";
            Sqlstr = "SELECT COUNT(*) FROM " + tjb + where;
            count = Convert.ToInt32(SQL.ExecuteScalar(Sqlstr));
            dh = type + '_' + dt + (count + 1).ToString("000");

            return dh;
        }

        /// <summary>
        /// 页面上所有控件不可用
        /// </summary>
        /// <param name="c">页面名</param>
        public void DisableAllControl(Control c)
        {
            if (c is TextBox || c is Button || c is ComboBox || c is DateTimePicker)
            {
                c.Enabled = false;
            }
            if (c.HasChildren)
            {
                foreach (Control child in c.Controls)
                {
                    DisableAllControl(child);
                }
            }
        }

        ///<summary>
        ///datagridview每一行自动生成序号
        /// </summary>
        public void RowPostPaint(DataGridView dgv, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgv.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgv.RowHeadersDefaultCellStyle.Font, rectangle, dgv.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        /// 检验单号是否已经存在
        /// </summary>
        /// <param name="dh">要查询的单号</param>
        /// <param name="djb">要查询的单据表</param>
        /// <returns></returns>
        public int CunZai(string dh, string dhzd, string djb)
        {
            Sqlstr = "SELECT * FROM " + djb + " WHERE " + dhzd + " = '" + dh + "'";
            int i = 0;
            i = SQL.getCounts(Sqlstr, djb);
            return i;
        }

        /// <summary>
        /// 条件查询，判断记录是否在数据库中已存在
        /// </summary>
        /// <param name="table">要查询的数据表</param>
        /// <param name="conditions">要查询的SQL语句条件，如djl = 'XXX'</param>
        /// <returns></returns>
        public int CunZai(string table, string conditions)
        {
            Sqlstr = string.Format("SELECT * FROM {0} WHERE {1}", table, conditions);
            int row = SQL.getCounts(Sqlstr, table);
            return row;
        }

        /// <summary>
        /// 生成树
        /// </summary>
        /// <param name="str">SQL语句，其查询结果作为传入节点的子节点</param>
        /// <param name="treeParent">传入要生成子节点的父节点</param>
        /// <param name="haveChild">是否为子节点生成空白子节点，产生加好</param>
        public void BindRoot(string str, TreeNode treeParent, bool haveChild)
        {
            MySqlDataReader dr = SQL.getcom(str);

            while(dr.Read())
            {
                TreeNode t = new TreeNode();
                t.Text = dr[0].ToString();
                treeParent.Nodes.Add(t);
                if(haveChild)
                {
                    t.Nodes.Add("");
                }
            }
        }

        /// <summary>
        /// 清空界面上所有的textbox值
        /// </summary>
        /// <param name="ctrlTop"></param>
        public void ClearText(Control ctrlTop)
        {
            if (ctrlTop.GetType() == typeof(TextBox))
                ctrlTop.Text = "";
            else
            {
                foreach (Control ctrl in ctrlTop.Controls)
                {
                    ClearText(ctrl); //循环调用  
                }
            }
        }
    }
}
