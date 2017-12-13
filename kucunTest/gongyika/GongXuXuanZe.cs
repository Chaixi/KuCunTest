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
using kucunTest.DaoJu;
using kucunTest.LingBuJian;

namespace kucunTest.gongyika
{
    public partial class GongXuXuanZe : Form
    {
        #region 全局变量
        private MySql SQL = new MySql();
        private string SqlStr = "";

        private BaseAlex Alex = new BaseAlex();

        DataSet ds = new DataSet();//存放不同工艺卡对应的工序表
        List<string> jgljlx_list = new List<string>();//存放不同工艺卡对应的加工零件类型

        #endregion 全局变量结束

        public GongXuXuanZe()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GongXuXuanZe_Load(object sender, EventArgs e)
        {
            gyk.DataSource = Alex.GetList("gyk");

            gyk.SelectedIndex = -1;
        }

        private void gyk_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = gyk.SelectedIndex;
            if(index >= 0)
            {
                //加载加工零件类型
                if (index < jgljlx_list.Count())
                {
                    jgljlx.Text = jgljlx_list[index];
                }
                else
                {
                    SqlStr = string.Format("SELECT * FROM {0} WHERE {1} = '{2}'", GongYiKa.TableName, GongYiKa.gykbh, gyk.SelectedItem.ToString());
                    DataTable db = SQL.getDataSet(SqlStr, GongYiKa.TableName).Tables[0];
                    jgljlx.Text = db.Rows[0][GongYiKa.jgljlx].ToString();
                    jgljlx_list.Add(db.Rows[0][GongYiKa.jgljlx].ToString());
                }

                //加载工序信息
                if (ds.Tables.Contains(gyk.SelectedItem.ToString()))
                {
                    gx.DataSource = ds.Tables[gyk.SelectedItem.ToString()].AsEnumerable().Select(d => d.Field<string>(GongXu.gxbh)).ToList<string>();
                }
                else
                {
                    SqlStr = string.Format("SELECT DISTINCT {1}, {2}, {3} FROM {0} WHERE {4} = '{5}' ORDER BY {1} ASC", GongXu.TableName, GongXu.gxbh, GongXu.jgljh, GongXu.jgljmc, GongXu.gykbh, gyk.SelectedItem.ToString());
                    DataTable db1 = SQL.getDataSet(SqlStr, GongXu.TableName).Tables[0];
                    db1.TableName = gyk.SelectedItem.ToString();
                    gx.DataSource = db1.AsEnumerable().Select(d => d.Field<string>(GongXu.gxbh)).ToList<string>();
                    ds.Tables.Add(db1.Copy());
                }
            }
            else
            {
                gx.DataSource = null;
                jgljlx.Text = "";
            }
        }

        private void gx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gx.DataSource != null && gx.SelectedIndex >= 0)
            {
                jgljh.Text = ds.Tables[gyk.SelectedItem.ToString()].Select(string.Format("{0} = '{1}'", GongXu.gxbh, gx.SelectedItem.ToString()))[0][GongXu.jgljh].ToString();
                jgljm.Text = ds.Tables[gyk.SelectedItem.ToString()].Select(string.Format("{0} = '{1}'", GongXu.gxbh, gx.SelectedItem.ToString()))[0][GongXu.jgljmc].ToString();
            }
            else
            {
                jgljh.Text = "";
                jgljm.Text = "";
            }
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            DJLY djly = (DJLY)this.Owner;
            djly.ZJGX.Text = string.Format("{0}-{1}", gyk.Text, gx.Text); 
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
