using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kucunTest.LingBuJian
{
    public partial class lbj_xiugaikucun : Form
    {
        string SqlStr = "";
        MySql SQL = new MySql();

        public lbj_xiugaikucun()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_comfirm_Click(object sender, EventArgs e)
        {
            string tishi = "";
            string liushui_sqlstr = "";

            if (XGSL.Text != "" && XGSL != null)
            {
                if(rb_add.Checked)
                {
                    SqlStr = string.Format("UPDATE {0} SET WHERE ");
                    liushui_sqlstr = string.Format("INSERT INTO {0}() VALUES('{1}')");
                }
                else
                {

                }
            }
            else
            {
                tishi = "请填写要操作的数量！";
            }

            if(tishi != "")
            {
                SQL.ExecuteNonQuery(SqlStr);
                SQL.ExecuteNonQuery(liushui_sqlstr);
                tishi = "更新成功！";
            }

            MessageBox.Show(tishi, "提示");
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void rb_add_CheckedChanged(object sender, EventArgs e)
        {
            if(rb_add.Checked)
            {
                rb_sub.Checked = false;
            }
        }

        private void rb_sub_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_sub.Checked)
            {
                rb_add.Checked = false;
            }
        }
    }
}
