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

        string daojutemp = "daojutemp";
        string danjubiao = "daojuxuyong";
        string mingxibiao = "daojuxuyongmingxi";
        string liushuibiao = "daojuliushui";
        string DHZD = "xydh";

        #endregion

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DJXY()
        {
            InitializeComponent();

            danhao.Text = Alex.DanHao("DJXY");//自动生成单号
            XYRQ.Value = DateTime.Now;
            XYBZ.SelectedIndex = 0;
            //XYR.SelectedIndex = 0;
            heji.Text = HJ.ToString();

            //禁止自动生成列
            xuyongmingxi.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DJXY_Load(object sender, EventArgs e)
        {
            //加载要续用的刀具信息
            //ydjid.Text = xuyongmingxi.Rows[0].Cells["djID"].Value.ToString();
            //xdjid.Text = ydjid.Text;
            //string str = "SELECT djmx.jichuangbianma,djmx.daotaohao,djly.jiagonggongyi FROM daojulingyongmingxi djmx LEFT JOIN daojulingyong djly ON djmx.chucangdanhao = djly.chucangdanhao WHERE djmx.daojuid = '" + ydjid.Text.ToString()+ "' ";
            //list1 = SQL.DataReadList3(str);

            //yjcbm.Text = list1[0];//要续用刀具原机床编码
            //ydth.Text = list1[1];//要续用刀具原刀套号
            //ygx.Text = list1[2];//要续用刀具原加工工序

            //加载所有机床名称以供选择要续用的设备，并默认选择原设备
            string sqlstr1 = "SELECT jichuangbianma FROM jichuang";
            xyinfo_xyjcbm.DataSource = SQL.DataReadList(sqlstr1);
            xyinfo_xyjcbm.SelectedIndex = -1;

            //加载所有在机床上的刀具ID（位置标识为M）
            Sqlstr = string.Format("SELECT dj.daojuid FROM {0} dj WHERE dj.weizhibiaoshi = 'M'", daojutemp);
            xyinfo_djid.DataSource = SQL.DataReadList(Sqlstr);
            xyinfo_djid.SelectedIndex = -1;

            //xjcbm.SelectedItem = yjcbm.Text.Trim();

            //默认选择原刀套号
            //xdth.SelectedItem = ydth.Text.Trim();

            //新工序默认为原工序，不变
            //xgx.Text = ygx.Text;
        }

        #region 续用明细部分
        /// <summary>
        /// 从表增加明细，即可以通过选择多条记录一并新增明细
        /// </summary>
        /// <param name="tb">要新增的明细表部分内容</param>
        public void AddDataFromTable(DataTable tb)
        {
            xymx_db.Columns.Add("djlx", System.Type.GetType("System.String"));
            xymx_db.Columns.Add("djgg", System.Type.GetType("System.String"));
            xymx_db.Columns.Add("djid", System.Type.GetType("System.String"));
            xymx_db.Columns.Add("sl", System.Type.GetType("System.String"));
            xymx_db.Columns.Add("jggx", System.Type.GetType("System.String"));
            xymx_db.Columns.Add("jcbm", System.Type.GetType("System.String"));
            xymx_db.Columns.Add("dth", System.Type.GetType("System.String"));

            for (int i = 0; i < tb.Rows.Count; i++)
            {
                DataRow rowrow = xymx_db.NewRow();

                rowrow["djlx"] = tb.Rows[i]["djlx"];//刀具类型
                rowrow["djgg"] = tb.Rows[i]["djgg"];//刀具规格
                rowrow["djid"] = tb.Rows[i]["djid"];//刀具id
                rowrow["sl"] = "1";//数量

                rowrow["jggx"] = "";//加工工序

                string djwz = tb.Rows[i]["djwz"].ToString();
                rowrow["jcbm"] = djwz.Substring(2, djwz.Length - 6);//截取机床编码，第一位位置标识（M），后三位具体位置（T01），两位符号位（-）
                rowrow["dth"] = djwz.Substring(djwz.Length - 3);//截取刀套号

                xymx_db.Rows.Add(rowrow);
                HJ++;
            }

            xuyongmingxi.DataSource = xymx_db.DefaultView;
            heji.Text = HJ.ToString();

            this.xuyongmingxi.CurrentCell = null;//默认不要选中
        }

        


        /// <summary>
        /// 选中行发生,加载具体刀具信息和续用信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xuyongmingxi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //刀具信息
                //ydjid.Text = this.xuyongmingxi.Rows[e.RowIndex].Cells["djID"].Value.ToString().Trim();
                xyinfo_djid.SelectedItem = this.xuyongmingxi.Rows[e.RowIndex].Cells["djID"].Value.ToString().Trim();
                xyinfo_djid.Enabled = false;
                xyinfo_gx.Text = this.xuyongmingxi.Rows[e.RowIndex].Cells["jiagonggongxu"].Value.ToString().Trim();
                xyinfo_gx.Enabled = false;
                xyinfo_jcbm.Text = this.xuyongmingxi.Rows[e.RowIndex].Cells["jcbm"].Value.ToString().Trim();
                xyinfo_jcbm.Enabled = false;
                xyinfo_dth.Text = this.xuyongmingxi.Rows[e.RowIndex].Cells["dth"].Value.ToString().Trim();
                xyinfo_dth.Enabled = false;

                //未修改续用信息前，默认与原刀具信息一致
                if (this.xuyongmingxi.Rows[e.RowIndex].Cells["xygx"].Value == null || this.xuyongmingxi.Rows[e.RowIndex].Cells["xygx"].Value.ToString() == "")
                {
                    xyinfo_xygx.Text = xyinfo_gx.Text;
                }
                else
                {
                    xyinfo_xygx.Text = this.xuyongmingxi.Rows[e.RowIndex].Cells["xygx"].Value.ToString().Trim();
                }

                if (this.xuyongmingxi.Rows[e.RowIndex].Cells["xyjcbm"].Value == null || this.xuyongmingxi.Rows[e.RowIndex].Cells["xyjcbm"].Value.ToString() == "")
                {
                    xyinfo_xyjcbm.SelectedItem = xyinfo_jcbm.Text;
                }
                else
                {
                    xyinfo_xyjcbm.SelectedItem = this.xuyongmingxi.Rows[e.RowIndex].Cells["xyjcbm"].Value.ToString().Trim();
                }

                if (this.xuyongmingxi.Rows[e.RowIndex].Cells["xydth"].Value == null || this.xuyongmingxi.Rows[e.RowIndex].Cells["xydth"].Value.ToString() == "")
                {
                    xyinfo_xydth.SelectedItem = xyinfo_dth.Text;
                }
                else
                {
                    xyinfo_xydth.SelectedItem = this.xuyongmingxi.Rows[e.RowIndex].Cells["xydth"].Value.ToString().Trim();
                }
                
            }

            //沫
            //ydjid.Text = xuyongmingxi.Rows[e.RowIndex].Cells["djID"].Value.ToString();
            //xdjid.Text = ydjid.Text;
            //djxx = ydjid.Text;
            //string str1 = "SELECT djmx.jichuangbianma,djmx.daotaohao,djly.jiagonggongyi FROM daojulingyongmingxi djmx LEFT JOIN daojulingyong djly ON djmx.chucangdanhao = djly.chucangdanhao WHERE djmx.daojuid = '" + ydjid.Text.ToString() + "' ";
            //list1 = SQL.DataReadList3(str1);
            //yjcbm.Text = list1[0];
            //ydth.Text = list1[1];
            //ygx.Text = list1[2];

            //xjcbm.SelectedItem = yjcbm.Text;

            //xgx.Text = ygx.Text;
            //xdth.SelectedIndex = -1;
        }

        /// <summary>
        /// 新机床名称选择变化，则加载相应机床的所有刀套号？or空闲刀套号？
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xjcbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            //加载空闲刀套号
            //string sql = "SELECT jcdjk.daotaohao FROM jcdaojuku jcdjk LEFT JOIN daojutemp djtp ON concat(djtp.weizhi,'-', djtp.cengshu ) = concat(jcdjk.jichuangbianma,'-', jcdjk.daotaohao ) where djtp.daojuid is NULL and jcdjk.jichuangbianma = '" + xjcbm.SelectedItem.ToString().Trim() + "'";

            //加载所有刀套号
            Sqlstr = string.Format("SELECT jcdjk.daotaohao FROM jcdaojuku jcdjk WHERE jcdjk.jichuangbianma = '{0}'", xyinfo_xyjcbm.Text.Trim());
            xyinfo_xydth.DataSource = SQL.DataReadList(Sqlstr);
            xyinfo_xydth.SelectedIndex = -1;
        }

        #endregion 续用明细部分结束

        #region 按钮部分
        /// <summary>
        /// 新增续用明细按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_new_xymx_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 修改续用明细按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_edit_xymx_Click(object sender, EventArgs e)
        {
            int crtrowindex = this.xuyongmingxi.CurrentRow.Index;

            if(crtrowindex < 0)
            {
                MessageBox.Show("请选择一条续用明细数据！", "提示");
                return;
            }
            //if (xyinfo_xygx.Text.ToString().Trim() == null || xyinfo_xygx.Text.ToString().Trim() == "")
            //{
            //    MessageBox.Show("请填写续用工序！", "提示");
            //    return;
            //}
            if(xyinfo_xyjcbm.Text.ToString().Trim() == null || xyinfo_xydth.Text.ToString().Trim() == "")
            {
                MessageBox.Show("请选择续用机床和续用刀套号！", "提示");
                return;
            }

            this.xuyongmingxi.Rows[crtrowindex].Cells["xygx"].Value = xyinfo_xygx.Text.ToString().Trim();
            this.xuyongmingxi.Rows[crtrowindex].Cells["xyjcbm"].Value = xyinfo_xyjcbm.SelectedItem.ToString().Trim();
            this.xuyongmingxi.Rows[crtrowindex].Cells["xydth"].Value = xyinfo_xydth.SelectedItem.ToString().Trim();

        }

        /// <summary>
        /// 删除选中续用明细按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_xymx_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 保存单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_save_Click(object sender, EventArgs e)
        {
            if (XYBZ.Text == "" || XYR.Text == "" || JBR.Text == "" || SPR.Text == "")//未填写任何内容，提示取消填写单据
            {
                MessageBox.Show("请填写完整的信息！", "警告", MessageBoxButtons.OK);
            }
            else
            {
                //daojuxuyong表数据预处理
                string xydh = danhao.Text.Trim();
                string xybz = XYBZ.Text.Trim();
                string xyr = XYR.Text.Trim();
                string xyrq = XYRQ.Value.ToString();
                string xysm = beizhu.Text.Trim();
                string spr = SPR.Text.Trim();
                string jbr = JBR.Text.Trim();

                //将续用信息存入数据库daojuxuyong表，单据状态为0，可再次更改
                if (Alex.CunZai(danhao.Text.ToString(), DHZD, danjubiao) != 0)//判断此单号在单据表中是否已存在
                {
                    //使用UPDATE语句
                    Sqlstr = string.Format("UPDATE {0} SET xydh='{1}', xybz='{2}', xyr='{3}', xyrq='{4}', beizhu='{5}', spr='{6}', jbr='{7}', djzt='{8}'", danjubiao, xydh, xybz, xyr, xyrq, xysm, spr, jbr, '0');
                }
                else
                {
                    //直接使用INSERT语句
                    Sqlstr = string.Format("INSERT INTO {0}(xydh, xybz, xyr, xyrq, beizhu, spr, jbr, djzt) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '0')", danjubiao, xydh, xybz, xyr, xyrq, xysm, spr, jbr);
                }

                //执行sql语句,row1为受影响的行数
                int row1 = SQL.ExecuteNonQuery(Sqlstr);

                //将续用明细存入续用明细表daojuxuyongmingxi
                int row2 = 0;
                if (row1 != 0)
                {
                    if (Alex.CunZai(danhao.Text.ToString(), DHZD, mingxibiao) != 0)//判断此单号在明细表中是否已存在
                    {
                        //使用DELETE语句删除已存在的明细
                        Sqlstr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", mingxibiao, DHZD, xydh);
                        row2 = SQL.ExecuteNonQuery(Sqlstr);
                    }

                    //明细数据格式化
                    string djlx = string.Empty;
                    string djgg = string.Empty;
                    string djid = string.Empty;
                    string sl = string.Empty;
                    string jggx = string.Empty;
                    string jcbm = string.Empty;
                    string dth = string.Empty;

                    for (int rowindex = 0; rowindex < xuyongmingxi.Rows.Count; rowindex++)
                    {
                        djlx = this.xuyongmingxi.Rows[rowindex].Cells["djlx"].Value.ToString();
                        djgg = this.xuyongmingxi.Rows[rowindex].Cells["djgg"].Value.ToString();
                        djid = this.xuyongmingxi.Rows[rowindex].Cells["djID"].Value.ToString();
                        sl = this.xuyongmingxi.Rows[rowindex].Cells["sl"].Value.ToString();
                        jggx = this.xuyongmingxi.Rows[rowindex].Cells["jiagonggongxu"].Value.ToString();
                        jcbm = this.xuyongmingxi.Rows[rowindex].Cells["jcbm"].Value.ToString();
                        dth = this.xuyongmingxi.Rows[rowindex].Cells["dth"].Value.ToString();

                        Sqlstr = string.Format("INSERT INTO {0}(xydh, djlx, djgg, djid, sl, jggx, jcbm, dth) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", mingxibiao, xydh, djlx, djgg, djid, sl, jggx, jcbm, dth);
                        row2 = SQL.ExecuteNonQuery(Sqlstr);//执行sql语句,row2为受影响的行数
                    }

                    if (row2 != 0)
                    {
                        MessageBox.Show("单据保存成功，可再次修改确认！", "提示", MessageBoxButtons.OK);
                        //this.InitializeComponent();
                        //this.OnLoad(null);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("领用明细数据填写有误，请检查并重试！", "警告", MessageBoxButtons.OK);
                    }
                }
            }
        }

        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_confirm_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否确认对刀具进行领用？确认后单据不可修改！", "领用确认", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                if (XYBZ.Text == "" || XYR.Text == "" || JBR.Text == "" || SPR.Text == "")//未填写任何内容，提示取消填写单据
                {
                    MessageBox.Show("请填写完整的信息！", "警告", MessageBoxButtons.OK);
                }
                else
                {
                    //daojuxuyong表数据预处理
                    string xydh = danhao.Text.Trim();
                    string xybz = XYBZ.Text.Trim();
                    string xyr = XYR.Text.Trim();
                    string xyrq = XYRQ.Value.ToString();
                    string xysm = beizhu.Text.Trim();
                    string spr = SPR.Text.Trim();
                    string jbr = JBR.Text.Trim();

                    //将续用信息存入数据库daojuxuyong表，单据状态为1，不可更改
                    if (Alex.CunZai(danhao.Text.ToString(), DHZD, danjubiao) != 0)//判断此单号在单据表中是否已存在
                    {
                        //使用UPDATE语句
                        Sqlstr = string.Format("UPDATE {0} SET xydh='{1}', xybz='{2}', xyr='{3}', xyrq='{4}', beizhu='{5}', spr='{6}', jbr='{7}', djzt='{8}'", danjubiao, xydh, xybz, xyr, xyrq, xysm, spr, jbr, '1');
                    }
                    else
                    {
                        //直接使用INSERT语句
                        Sqlstr = string.Format("INSERT INTO {0}(xydh, xybz, xyr, xyrq, beizhu, spr, jbr, djzt) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '1')", danjubiao, xydh, xybz, xyr, xyrq, xysm, spr, jbr);
                    }

                    //执行sql语句,row1为受影响的行数
                    int row1 = SQL.ExecuteNonQuery(Sqlstr);

                    //存储明细数据
                    int row2 = 0;//记录插入明细表数据
                    int row3 = 0;//记录插入流水表数据
                    int row4 = 0;//记录更新刀具监测表数据
                    string dskysl = "";//此类型刀具的当时可用数量！！！当时可用数量为单据操作后的刀具可用数量

                    if (row1 != 0)
                    {
                        if (Alex.CunZai(danhao.Text.ToString(), DHZD, mingxibiao) != 0)//判断此单号在明细表中是否已存在
                        {
                            //使用DELETE语句删除已存在的明细
                            Sqlstr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", mingxibiao, DHZD, xydh);
                            row2 = SQL.ExecuteNonQuery(Sqlstr);
                        }

                        //明细数据格式化
                        string djlx = string.Empty;
                        string djgg = string.Empty;
                        string djid = string.Empty;
                        string sl = string.Empty;
                        string jggx = string.Empty;
                        string jcbm = string.Empty;
                        string dth = string.Empty;

                        for (int rowindex = 0; rowindex < xuyongmingxi.Rows.Count; rowindex++)
                        {
                            djlx = this.xuyongmingxi.Rows[rowindex].Cells["djlx"].Value.ToString();
                            djgg = this.xuyongmingxi.Rows[rowindex].Cells["djgg"].Value.ToString();
                            djid = this.xuyongmingxi.Rows[rowindex].Cells["djID"].Value.ToString();
                            sl = this.xuyongmingxi.Rows[rowindex].Cells["sl"].Value.ToString();
                            jggx = this.xuyongmingxi.Rows[rowindex].Cells["jiagonggongxu"].Value.ToString();
                            jcbm = this.xuyongmingxi.Rows[rowindex].Cells["jcbm"].Value.ToString();
                            dth = this.xuyongmingxi.Rows[rowindex].Cells["dth"].Value.ToString();

                            //查询此类型刀具当时可用数量, 刀具续用可用数量不变
                            dskysl = (Alex.Count_djsl(djlx, "kysl")).ToString();

                            //明细数据存入明细表
                            Sqlstr = string.Format("INSERT INTO {0}(xydh, djlx, djgg, djid, sl, jggx, jcbm, dth) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", mingxibiao, xydh, djlx, djgg, djid, sl, jggx, jcbm, dth);
                            row2 = SQL.ExecuteNonQuery(Sqlstr);//执行sql语句,row2为受影响的行数

                            //明细信息存入流水表
                            Sqlstr = string.Format("INSERT INTO {0}(danhao, dhlx, djlx, djgg, djid, zsl, fsl, dskysl, wzbm, jtwz ,czsj, jbr, bz) VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}' ,'{8}', '{9}', '{10}', '{11}', '{12}', '{13}')", liushuibiao, xydh, "刀具续用", djlx, djgg, djid, "0", "0", dskysl, jcbm, dth, xyrq, jbr, xysm);
                            row3 = SQL.ExecuteNonQuery(Sqlstr);

                            //更新刀具位置寿命监测表
                            Sqlstr = string.Format("UPDATE {0} dj SET dj.weizhibiaoshi = 'M', dj.weizhi = '{1}', dj.cengshu = '{2}' WHERE dj.daojuid = '{3}'", daojutemp, jcbm, dth, djid);
                            row4 = SQL.ExecuteNonQuery(Sqlstr);
                        }

                        if (row2 != 0)
                        {
                            MessageBox.Show("刀具续用单据已确认，不可修改！", "提示", MessageBoxButtons.OK);
                            //this.InitializeComponent();
                            //this.OnLoad(null);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("续用明细数据填写有误，请检查并重试！", "警告", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("领用信息或操作信息填写有误，请检查并重试！", "警告", MessageBoxButtons.OK);
                    }
                }
            }
        }

        /// <summary>
        /// 打印单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void print_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 删除单据按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancel_Click(object sender, EventArgs e)
        {
            if (Alex.CunZai(danhao.Text.ToString().Trim(), DHZD, danjubiao) != 0)
            {
                DialogResult dr = MessageBox.Show("确认删除此单据？", "删除确认", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    //删除续用表daojuxuyong中的数据
                    Sqlstr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", danjubiao, DHZD, danhao.Text.ToString().Trim());
                    int row1 = SQL.ExecuteNonQuery(Sqlstr);

                    //删除续用明细表djxuyongmingxi中的数据
                    Sqlstr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", mingxibiao, DHZD, danhao.Text.ToString().Trim());
                    int row2 = SQL.ExecuteNonQuery(Sqlstr);
                    MessageBox.Show("成功删除一张单据和" + row2 + "条明细记录！");

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
        /// 续用历史按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_history_Click(object sender, EventArgs e)
        {
            XYLS xyls = new XYLS();
            xyls.Show();
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

        #endregion 按钮部分结束

        #region 其他方法部分

        /// <summary>
        /// AddData函数，向datagridview中增加一行数据
        /// </summary>
        /// <param name="list">子窗体传输过来的list值</param>
        public void AddData(List<string> list)
        {
            //xymx_db.Columns.Add("jiagonggongxu", typeof(string));
            //xymx_db.Columns.Add("jcbm", typeof(string));
            //xymx_db.Columns.Add("dth", typeof(string));

            //if (djxx == xdjid.Text)
            //{
            //    DataRow rowrow = xymx_db.NewRow();

            //    rowrow["jiagonggongxu"] = list[0];//刀具类型
            //    rowrow["jiagonggongxu"] = list[1];//刀具规格

            //    rowrow["jiagonggongxu"] = list[2];//刀具id

            //    xuyongmingxi.Rows.Add(rowrow);
            //}
            //else
            //{
            //    MessageBox.Show("请选择刀具！", "信息提示");
            //    return;
            //}


            //HJ++;//合计数量加一
            //heji.Text = HJ.ToString();//更新合计数量
        }

        /// <summary>
        /// datagridview绘制行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xuyongmingxi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(xuyongmingxi, e);
        }

        #endregion 其他方法部分结束

        
    }
}
