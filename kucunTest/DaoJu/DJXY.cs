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
    public partial class DJXY : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        string Sqlstr = "";
        string djxx = "";
        int HJ = 0;
        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();//窗口自适应类

        DataSet lymx_ds = new DataSet();
        DataTable xymx_db = new DataTable();
        List<string> list1 = new List<string>();
        List<string> list = new List<string>();

        string danjubiao = "daojuxuyong";
        string mingxibiao = "daojuxuyongmingxi";
        string liushuibiao = "daojuliushui";
        string DHZD = "xuyongdanhao";

        #endregion

        public DJXY()
        {
            InitializeComponent();
            danhao.Text = Alex.DanHao("DJXY");//自动生成单号
            XYRQ.Value = DateTime.Now;
            XYBZ.SelectedIndex = 0;
            //XYR.SelectedIndex = 0;
            heji.Text = HJ.ToString();

            xuyongmingxi.AutoGenerateColumns = false;//禁止自动生成行
        }

        private void DJXY_Load(object sender, EventArgs e)
        {
            //xuyongmingxi.Rows[0].Selected = true;
            ydjid.Text = xuyongmingxi.Rows[0].Cells["djID"].Value.ToString();
            xdjid.Text = ydjid.Text;
            string str = "select  djmx.jichuangbianma,djmx.daotaohao,djly.jiagonggongyi from daojulingyongmingxi djmx LEFT JOIN daojulingyong djly ON djmx.chucangdanhao = djly.chucangdanhao where djmx.daojuid = '" + ydjid.Text.ToString()+ "' ";
            list1 = SQL.DataReadList3(str);
            yjcbm.Text = list1[0];
            ydth.Text = list1[1];
            ygx.Text = list1[2];

            string sqlstr1 = "select jichuangbianma from jichuang";
            xjcbm.DataSource = SQL.DataReadList(sqlstr1);
            xjcbm.SelectedItem = yjcbm.Text;

            xgx.Text = ygx.Text;
        }



        /// <summary>
        /// 从表增加明细，即可以通过选择多条记录一并新增明细
        /// </summary>
        /// <param name="tb">要新增的明细表部分内容</param>
        public void AddDataFromTable(DataTable tb)
        {
            xymx_db.Columns.Add("daojuleixing", System.Type.GetType("System.String"));
            xymx_db.Columns.Add("daojuguige", System.Type.GetType("System.String"));
            xymx_db.Columns.Add("daojuid", System.Type.GetType("System.String"));
            xymx_db.Columns.Add("shuliang", System.Type.GetType("System.String"));

      

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                DataRow rowrow = xymx_db.NewRow();

                rowrow["daojuleixing"] = tb.Rows[i]["djlx"];//刀具类型
                rowrow["daojuguige"] = tb.Rows[i]["djgg"];//刀具规格
  
                rowrow["daojuid"] = tb.Rows[i]["djid"];//刀具id
                rowrow["shuliang"] = "1";//数量
        

                xymx_db.Rows.Add(rowrow);
                HJ++;
            }

            xuyongmingxi.DataSource = xymx_db.DefaultView;
            heji.Text = HJ.ToString();
        }

        //将续用信息加入续用明细中
        private void button3_Click(object sender, EventArgs e)
        {
           
            if (xgx.Text.ToString().Trim() == null || xgx.Text.ToString().Trim() == "")
            {
                MessageBox.Show("请填写续用刀具的工艺号！", "信息提示");
                return;
            }
            if (xdth.SelectedItem.ToString().Trim() == null || xdth.SelectedItem.ToString().Trim() == "")
            {
                MessageBox.Show("请选择机床刀套号！", "信息提示");
                return;
            }
 
            list.Add(xjcbm.SelectedItem.ToString().Trim());//list[0] 机床编码
            list.Add(xdth.SelectedItem.ToString().Trim());//list[1] 刀套号
            list.Add(xgx.Text.ToString().Trim());//list[2] 工序号
        }

        private void xuyongmingxi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            ydjid.Text = xuyongmingxi.Rows[e.RowIndex].Cells["djID"].Value.ToString();
            xdjid.Text = ydjid.Text;
            djxx = ydjid.Text;
            string str1 = "select  djmx.jichuangbianma,djmx.daotaohao,djly.jiagonggongyi from daojulingyongmingxi djmx LEFT JOIN daojulingyong djly ON djmx.chucangdanhao = djly.chucangdanhao where djmx.daojuid = '" + ydjid.Text.ToString() + "' ";
            list1 = SQL.DataReadList3(str1);
            yjcbm.Text = list1[0];
            ydth.Text = list1[1];
            ygx.Text = list1[2];

            xjcbm.SelectedItem = yjcbm.Text;

            xgx.Text = ygx.Text;
            xdth.SelectedIndex = -1;
            
        }

        private void xjcbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "SELECT jcdjk.daotaohao FROM jcdaojuku jcdjk LEFT JOIN daojutemp djtp ON concat(djtp.weizhi,'-', djtp.cengshu ) = concat(jcdjk.jichuangbianma,'-', jcdjk.daotaohao ) where djtp.daojuid is NULL and jcdjk.jichuangbianma = '" + xjcbm.SelectedItem.ToString().Trim() + "'";
            xdth.DataSource = SQL.DataReadList(sql);
            xdth.SelectedIndex = -1;
        }

        private void xdth_SelectedIndexChanged(object sender, EventArgs e)
        {
        
      
        }

        /// <summary>
        /// 保存单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_Click(object sender, EventArgs e)
        {
            if (XYBZ.Text == "" ||  XYR.Text == "" || JBR.Text == "" || SPR.Text == "" )//未填写任何内容，提示取消填写单据
            {
                MessageBox.Show("请填写完整的信息！", "警告", MessageBoxButtons.OK);
            }
            else
            {
                //将领用和操作数据存入数据库daojuchucang表
                if (Alex.CunZai(danhao.Text.ToString(), DHZD, danjubiao) != 0)//判断此单号在单据表中是否已存在
                {
                    //使用update语句
                    //Sqlstr = "UPDATE daojuchucang SET (chucangdanhao, chucangleixing, danjuzhuangtai, lingyongbanzu, lingyongren, jiagonggongyi, chucangriqi, beizhu, caozuoyuan) values('" + danhao.Text.ToString().Trim() + "', '" + "常规领用" + "', '" + "0" + "', '" + LYBZ.Text.ToString().Trim() + "', '" + LYR.Text.ToString().Trim() + "', '" + ZJGX.Text.ToString().Trim() + "', '" + LYRQ.Text + "', '" + beizhu.Text.ToString().Trim() + "', '" + JBR.Text.ToString().Trim() + "')";
                    Sqlstr = string.Format("UPDATE {0} SET xuyongbanzu = '{1}', xuyongren = '{2}',jiagonggongxu = '{3}', xuyongriqi = '{4}', beizhu = '{5}', caozuoyuan = '{6}' where chucangdanhao = '{7}'", danjubiao, XYBZ.Text.ToString().Trim(), XYR.Text.ToString().Trim(), xgx.Text.ToString().Trim(), XYRQ.Text, beizhu.Text.ToString().Trim(), JBR.Text.ToString().Trim(), danhao.Text.ToString().Trim());
                }
                else
                {
                    //直接使用insert语句
                    Sqlstr = "insert into " + danjubiao + "(xuyongdanhao, danjuzhuangtai, xuyongbanzu, xuyongren,jiagonggongxu, xuyongriqi, beizhu, caozuoyuan) values('" + danhao.Text.ToString().Trim() + "',  '" + "0" + "', '" + XYBZ.Text.ToString().Trim() + "', '" + XYR.Text.ToString().Trim() + "', '" + xgx.Text.ToString().Trim() + "', '" + XYRQ.Text + "', '" + beizhu.Text.ToString().Trim() + "', '" + JBR.Text.ToString().Trim() + "')";
                }

                //执行sql语句,row1为受影响的行数
                int row1 = SQL.ExecuteNonQuery(Sqlstr);

            
            }
        }


        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XYLS xyls = new XYLS();
            xyls.Show();
        }


        /// <summary>
        /// AddData函数，向datagridview中增加一行数据
        /// </summary>
        /// <param name="list">子窗体传输过来的list值</param>
        public void AddData(List<string> list)
        {
            xymx_db.Columns.Add("jiagonggongxu", typeof(string));
            xymx_db.Columns.Add("jcbm", typeof(string));
            xymx_db.Columns.Add("dth", typeof(string));
  

            if (djxx == xdjid.Text)
            {
                DataRow rowrow = xymx_db.NewRow();

                rowrow["jiagonggongxu"] = list[0];//刀具类型
                rowrow["jiagonggongxu"] = list[1];//刀具规格

                rowrow["jiagonggongxu"] = list[2];//刀具id
               


                xuyongmingxi.Rows.Add(rowrow);
            }
            else
            {
                MessageBox.Show("请选择刀具！", "信息提示");
                return;
            }


            HJ++;//合计数量加一
            heji.Text = HJ.ToString();//更新合计数量
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
