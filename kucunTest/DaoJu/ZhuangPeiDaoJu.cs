using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kucunTest.DaoJu
{
    public partial class zhuangpeidaoju : Form
    {
        public zhuangpeidaoju()
        {
            InitializeComponent();
        }

        #region 全局变量
        MySql SQL = new MySql();
        String sqlstr = "";
        String daojulingbujian = "daojulingbujian";
        #endregion

        private void zhuangpeidaoju_Load(object sender, EventArgs e)
        {
            sqlstr = "select distinct  xinghao from daojulingbujian";
            djxh.DataSource = SQL.DataReadList(sqlstr);
            djxh.SelectedIndex = 0;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }




        private void djxh_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlstr = "select * from daojulingbujian where xinghao = '" + djxh.SelectedItem.ToString().Trim() + "'";
            DataSet ds = SQL.getDataSet(sqlstr, daojulingbujian);
            lbjmx.AutoGenerateColumns = false;
            lbjmx.ReadOnly = true;
            lbjmx.DataSource = ds.Tables[0].DefaultView;
        }

        private void lbjmx_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, lbjmx.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), lbjmx.RowHeadersDefaultCellStyle.Font, rectangle, lbjmx.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
}
