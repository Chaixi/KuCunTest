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

namespace kucunTest.LingBuJian
{
    public partial class lbj_GuanLi : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        String Sqlstr = "";

        //提示文本
        string tishi = "";

        TreeNode root = new TreeNode();

        //零部件表
        string lbjbiao = "jichuxinxi";
        string lbjbiao_lbjmc = "daojuid";
        string lbjbiao_lbjgg = "daojuguige";
        string lbjbiao_lbjxh = "daojuxinghao";
        string lbjbiao_djgbm = "weizhi";
        string lbjbiao_jtwz = "cengshu";
        string lbjbiao_kcsl = "kcsl";
        string lbjbiao_dw = "danwei";
        string lbjbiao_zxkc = "zuixiaokucun";
        string lbjbiao_zdkc = "zuidakucun";

        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();

        #endregion

        public lbj_GuanLi()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbj_GuanLi_Load(object sender, EventArgs e)
        {
            root.Text = "所有类型";
            treeView1.Nodes.Add(root);

            Sqlstr = string.Format("SELECT DISTINCT daojuid FROM {0} ORDER BY CONVERT(daojuid USING gbk) ASC", lbjbiao);
            Alex.BindRoot(Sqlstr, root, true);
            treeView1.Nodes[0].Expand();
            treeView1.SelectedNode = treeView1.Nodes[0];//默认选中所有类型

            asc.controllInitializeSize(this);
            lbjxinxi.AutoGenerateColumns = false;

            //加载所有刀具柜
            string sqlstr1 = "SELECT djgmc FROM daojugui";
            search_djgbm.DataSource = SQL.DataReadList(sqlstr1);
            search_djgbm.SelectedIndex = -1;

            //库存表取得焦点
            lbjxinxi.Focus();
        }

        /// <summary>
        /// 在展开类型节点之前查询所有规格的子节点，按需查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if(e.Node.Level == 1)
            {
                if (e.Node.Nodes[0].Text == "")
                {
                    TreeNode currentNode = e.Node;
                    currentNode.Nodes[0].Remove();
                    Sqlstr = string.Format("SELECT DISTINCT daojuxinghao FROM {0} WHERE daojuid = '{1}'", lbjbiao, currentNode.Text);
                    Alex.BindRoot(Sqlstr, currentNode, false);
                }
            }            
        }

        /// <summary>
        /// 根据选择的树节点进行库存明细查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">当前节点</param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tishi = "";

            string where = "";//SQL语句条件。默认为空，即第一层节点：所有类型
            if (treeView1.SelectedNode.Level == 1)//当前选中节点为第二层节点：刀具类型
            {
                where = "WHERE daojuid = '" + e.Node.Text.ToString() + "'";

                //查该类型下规格数和总数量
                string sqlstr1 = string.Format("SELECT COUNT(DISTINCT {2}) AS xhs, SUM({3}) AS zsl FROM {0} {1}", lbjbiao, where, lbjbiao_lbjxh, lbjbiao_kcsl);
                DataTable db = SQL.getDataSet1(sqlstr1).Tables[0];
                LBJGGS.Text = db.Rows[0]["xhs"].ToString();
                LBJZSL.Text = db.Rows[0]["zsl"].ToString();
            }
            else if(treeView1.SelectedNode.Level == 2)//当前选中节点为第三层节点：刀具具体型号
            {
                where = string.Format("WHERE daojuid = '{0}' AND daojuxinghao = '{1}'", e.Node.Parent.Text.ToString(), e.Node.Text.ToString());
            }
            Sqlstr = "SELECT daojuid AS lbjmc, daojuxinghao AS lbjxh, daojuguige AS lbjgg, CONCAT(weizhi,'--', cengshu) AS kcwz, kcsl, danwei AS dw, zuixiaokucun AS zxkc, zuidakucun AS zdkc FROM jichuxinxi " + where;
            lbjxinxi.DataSource = SQL.getDataSet1(Sqlstr).Tables[0].DefaultView;
            RefreshColor();            
              
        }

        /*--------------------------------------------------------------------------------操作按钮部分--------------------------------------------------------------------------------------------------*/
        #region 操作按钮部分
        /// <summary>
        /// 搜索查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_btn_Click(object sender, EventArgs e)
        {
            tishi = "";

            if(search_lbjxh.Text != "" || search_djgbm.Text != "" || search_jtwz.Text != "")
            {
                string conditions = string.Format("{0} LIKE '%{1}%' AND {2} LIKE '%{3}%' AND {4} LIKE '%{5}%'", lbjbiao_lbjxh, search_lbjxh.Text.ToString(), lbjbiao_djgbm, search_djgbm.Text.ToString(), lbjbiao_jtwz, search_jtwz.Text.ToString());
                Sqlstr = string.Format("SELECT {0} AS lbjmc, {1} AS lbjxh, {2} AS lbjgg, CONCAT({3},'--', {4}) AS kcwz, {5} AS kcsl, {6} AS dw, {7} AS zxkc, {8} AS zdkc FROM {9} WHERE {10}", lbjbiao_lbjmc, lbjbiao_lbjxh, lbjbiao_lbjgg, lbjbiao_djgbm, lbjbiao_jtwz, lbjbiao_kcsl, lbjbiao_dw, lbjbiao_zxkc, lbjbiao_zdkc, lbjbiao, conditions);
                DataTable db_search = SQL.getDataSet1(Sqlstr).Tables[0];

                //判断是否查询到数据
                if(db_search.Rows.Count > 0 )
                {
                    lbjxinxi.DataSource = db_search.DefaultView;
                    RefreshColor();
                }
                else
                {
                    tishi = "没有符合条件的数据，请修改查询条件后重试！";
                }
            }
            else
            {
                tishi = "请输出组合查询条件";                
            }

            if(tishi != "")
            {
                MessageBox.Show(tishi);
                search_lbjxh.Focus();
            }
        }

        /// <summary>
        /// 刷新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            //记住刷新前选中的树节点和数据行
            TreeNode crtnode = treeView1.SelectedNode;
            int rowindex = lbjxinxi.CurrentRow.Index;

            //清空树节点的选择
            treeView1.SelectedNode = null;
            //重新选择节点
            treeView1.SelectedNode = crtnode;

            //清除默认选择首行
            lbjxinxi.ClearSelection();
            //重新选择数据行
            lbjxinxi.Rows[rowindex].Selected = true;
        }

        /// <summary>
        /// 零部件领用按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //把当前选择的数据行添加到新的表中作为参数调用刀具领用中的AddDataFromTable()方法
            bool flag = true;//是否可以领用
            int rowCheckedCount = 0;//选中行数量
            string str = "";
            //string djwz = "";//零部件存放位置
            string lbjkcsl = "";//零部件库存数量
            DataTable tb = new DataTable();//存放选中的数据
            //DataTable dgv_tb = (DataTable)daojuxinxi.DataSource;//获取dataview 转换成 datatable
            DataTable dgv_tb = Alex.GetDgvToTable(lbjxinxi);
            tb = dgv_tb.Copy();
            tb.Clear();

            lbjxinxi.EndEdit();//如果DataGridView是可编辑的，将数据提交，否则处于编辑状态的行无法取到 

            //循环遍历选中的行
            for (int i = 0; i < dgv_tb.Rows.Count; i++)
            {
                if (dgv_tb.Rows[i]["check"].ToString() == "true")//该行是否选中
                {
                    rowCheckedCount++;//选中行+1

                    //截取还原刀具位置
                    //djwz = dgv_tb.Rows[i]["djwz"].ToString();

                    //取出零部件库存数量
                    lbjkcsl = dgv_tb.Rows[i]["kcsl"].ToString();

                    //判断库存数量是否为0
                    if (Convert.ToInt32(lbjkcsl) > 0 )
                    {
                        tb.Rows.Add(dgv_tb.Rows[i].ItemArray);//也可以是tb.ImportRow(dgv_tb.Rows[i]);但不能直接tb.Rows.Add(row);出错：改行已经在另一个表中
                        //DataRow row = ((daojuxinxi.Rows[i]).DataBoundItem as DataRowView).Row;//微软提供的唯一的从DataGridViewRow转换DataRow
                    }
                    else//没有库存
                    {
                        str = lbjxinxi.Rows[i].Cells["djid"].Value.ToString() + "库存不足！";
                        flag = false;
                        break;
                    }
                }
                else
                {
                    continue;
                }
            }

            if (rowCheckedCount == 0)
            {
                str = "未选择要领用的零部件，是否新建空白零部件领用单据？";
                flag = false;
            }

            if (flag)//可以领用
            {
                LBJLY lbjly = new LBJLY();
                lbjly.AddDataFromTable(tb);
                lbjly.ShowDialog();
            }
            else
            {
                DialogResult dr = MessageBox.Show(str, "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    LBJLY lbjly = new LBJLY();
                    lbjly.ShowDialog();
                }
            }
        }

        /// <summary>
        /// 零部件退还按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //把当前选择的数据行添加到新的表中作为参数调用刀具退还中的AddDataFromTable()方法
            bool flag = true;//是否可以领用
            int rowCheckedCount = 0;//选中行数量
            string str = "";
            //string djwz = "";//零部件存放位置
            //string lbjkcsl = "";//零部件库存数量
            DataTable tb = new DataTable();//存放选中的数据
            //DataTable dgv_tb = (DataTable)daojuxinxi.DataSource;//获取dataview 转换成 datatable
            DataTable dgv_tb = Alex.GetDgvToTable(lbjxinxi);
            tb = dgv_tb.Copy();
            tb.Clear();

            lbjxinxi.EndEdit();//如果DataGridView是可编辑的，将数据提交，否则处于编辑状态的行无法取到 

            //循环遍历选中的行
            for (int i = 0; i < dgv_tb.Rows.Count; i++)
            {
                if (dgv_tb.Rows[i]["check"].ToString() == "true")//该行是否选中
                {
                    rowCheckedCount++;//选中行+1
                    tb.Rows.Add(dgv_tb.Rows[i].ItemArray);//也可以是tb.ImportRow(dgv_tb.Rows[i]);但不能直接tb.Rows.Add(row);出错：改行已经在另一个表中
                    
                    //截取还原刀具位置
                    //djwz = dgv_tb.Rows[i]["djwz"].ToString();

                    //取出零部件库存数量
                    //lbjkcsl = dgv_tb.Rows[i]["kcsl"].ToString();

                    //判断库存数量是否为0
                    //if (Convert.ToInt32(lbjkcsl) > 0)
                    //{
                    //    tb.Rows.Add(dgv_tb.Rows[i].ItemArray);//也可以是tb.ImportRow(dgv_tb.Rows[i]);但不能直接tb.Rows.Add(row);出错：改行已经在另一个表中
                    //    //DataRow row = ((daojuxinxi.Rows[i]).DataBoundItem as DataRowView).Row;//微软提供的唯一的从DataGridViewRow转换DataRow
                    //}
                    //else//没有库存
                    //{
                    //    str = lbjxinxi.Rows[i].Cells["djid"].Value.ToString() + "库存不足！";
                    //    flag = false;
                    //    break;
                    //}
                }
                else
                {
                    continue;
                }
            }

            if (rowCheckedCount == 0)
            {
                str = "未选择要退还的零部件，是否新建空白零部件退还单据？";
                flag = false;
            }

            if (flag)//可以退还
            {
                LBJTH lbjth = new LBJTH();
                lbjth.AddDataFromTable(tb);
                lbjth.ShowDialog();
            }
            else
            {
                DialogResult dr = MessageBox.Show(str, "提示", MessageBoxButtons.YesNo);
                if(dr == DialogResult.Yes)
                {
                    LBJTH lbjth = new LBJTH();
                    lbjth.ShowDialog();
                }
            }
        }

        /// <summary>
        /// 修改库存量按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xgkxl_Click(object sender, EventArgs e)
        {
            string str = "";          

            if(lbjxinxi.SelectedRows.Count != 1)
            {
                str = "请先选择一行要修改库存量的零部件数据！";
            }
            else
            {
                DataRow dr = ((lbjxinxi.CurrentRow).DataBoundItem as DataRowView).Row;
                lbj_xiugaikucun xgkc = new lbj_xiugaikucun(dr);
                xgkc.ShowDialog();
            }

            if(str != "")
            {
                DialogResult dr = MessageBox.Show(str, "提示");
            }
        }

        /// <summary>
        /// 零部件库存明细按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            lbjkcmx lbjkc = new lbjkcmx();
            lbjkc.Show();
        }

        /// <summary>
        /// 领用记录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_lbjly_Click(object sender, EventArgs e)
        {
            lbj_History lbjly = new lbj_History("LBJLY");
            lbjly.Show();
        }

        /// <summary>
        /// 退还记录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_lbjth_Click(object sender, EventArgs e)
        {
            lbj_History lbjth = new lbj_History("LBJTH");
            //MainForm mf = (MainForm)this.MdiParent;
            //mf.showInTabPage(lbjth);
            lbjth.Show();
        }
        #endregion 按钮部分结束

        /*--------------------------------------------------------------------------------筛选查询&刷新部分----------------------------------------------------------------------------------------*/
        /// <summary>
        /// 刀具柜选择变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_djgbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(search_djgbm.SelectedIndex >= 0)
            {
                Sqlstr = string.Format("SELECT djgcs FROM daojuguicengshu WHERE djgmc = '{0}' ", search_djgbm.Text);
                search_jtwz.DataSource = SQL.DataReadList(Sqlstr);
            }
            else
            {
                search_jtwz.DataSource = null;
            }

            search_jtwz.SelectedIndex = -1;
            
        }

        /// <summary>
        /// 刷新表格，根据库存数量和最小最大库存以不同颜色突出显示
        /// </summary>
        public void RefreshColor()
        {
            for (int i = 0; i < lbjxinxi.Rows.Count; i++)
            {
                int tb_kcsl = Convert.ToInt16(lbjxinxi.Rows[i].Cells["kcsl"].Value.ToString());
                int tb_zxkc = Convert.ToInt16(lbjxinxi.Rows[i].Cells["zxkc"].Value.ToString());
                int tb_zdkc = Convert.ToInt16(lbjxinxi.Rows[i].Cells["zdkc"].Value.ToString());

                if (tb_kcsl < tb_zxkc)
                {
                    lbjxinxi.Rows[i].DefaultCellStyle.BackColor = Color.HotPink;
                }
                else if (tb_kcsl > tb_zdkc)
                {
                    lbjxinxi.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
        }

        /*--------------------------------------------------------------------------------其他方法部分----------------------------------------------------------------------------------------*/
        /// <summary>
        /// 窗体自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbj_GuanLi_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        /// <summary>
        /// 表格绘制行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbjxinxi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(lbjxinxi, e);
        }

        /// <summary>
        /// checkbox值发生改变时，改变该行背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbjxinxi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)//表头不发生验证
            {
                if (lbjxinxi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "true")//选中该行
                {
                    lbjxinxi.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;//背景色高亮
                }
                else if (lbjxinxi.CurrentCell.Value.ToString() == "false")//取消选中该行
                {                   
                    //取消选中表格颜色更换，根据库存数量判断显示颜色
                    int kcsl = Convert.ToInt16(lbjxinxi.Rows[e.RowIndex].Cells["kcsl"].Value.ToString());
                    if(kcsl > 0 )
                    {
                        //根据奇偶行判断表格底色
                        if (Convert.ToInt16(e.RowIndex) % 2 == 0)//偶数行
                        {
                            lbjxinxi.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                        }
                        else//奇数行
                        {
                            lbjxinxi.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gainsboro;
                        }
                    }
                    else
                    {
                        lbjxinxi.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        /// <summary>
        /// 每次表格绑定数据发生变化，重新绘制底色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbjxinxi_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            RefreshColor();
        }

        /// <summary>
        /// 点击单元格，加载刀具图片和相关参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbjxinxi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow crtrow = lbjxinxi.CurrentRow;

            if(crtrow.Index >= 0)
            {
                string lbjmc = crtrow.Cells["lbjmc"].Value.ToString();

                //判断选中行的零部件类型以加载相应参数
                if(lbjmc.Contains("刀片"))
                {
                    //加载图片
                    LBJTP.Image = kucunTest.Properties.Resources.qxdp1;

                    //加载参数
                    sjcs_panel_db.Visible = false;
                    sjcs_panel_dp.Visible = true;
                }
                else if (lbjmc.Contains("刀柄"))
                {
                    //加载图片
                    LBJTP.Image = kucunTest.Properties.Resources.hsk;

                    //加载参数
                    sjcs_panel_db.Visible = true;
                    sjcs_panel_dp.Visible = false;

                }
                else if (lbjmc.Contains("铰刀"))
                {
                    //加载图片
                    LBJTP.Image = kucunTest.Properties.Resources.jiaodao;

                    //加载参数
                    sjcs_panel_db.Visible = false;
                    sjcs_panel_dp.Visible = true;

                }
                else if (lbjmc.Contains("丝锥"))
                {
                    //加载图片
                    LBJTP.Image = kucunTest.Properties.Resources.sizhui;

                    //加载参数
                    sjcs_panel_db.Visible = false;
                    sjcs_panel_dp.Visible = true;

                }
                else if (lbjmc.Contains("钻头"))
                {
                    //加载图片
                    LBJTP.Image = kucunTest.Properties.Resources.zuantou;

                    //加载参数
                    sjcs_panel_db.Visible = false;
                    sjcs_panel_dp.Visible = true;

                }
                else
                {
                    //加载图片
                    LBJTP.Image = kucunTest.Properties.Resources.weishezhitupian;

                    //加载参数
                    sjcs_panel_db.Visible = false;
                    sjcs_panel_dp.Visible = true;
                }
            }
        }

    }
}
