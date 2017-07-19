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

/// <summary>
/// 当前的库存数量仅统计入仓数量，未统计出仓数量，不是真正的当前库存
/// </summary>
namespace kucunTest.KuCun
{
    public partial class KCMingXi : Form
    {
        public KCMingXi()
        {
            InitializeComponent();
        }

        #region 全局变量
        private MySql SelectSql = new MySql();//MySQL类
        private string SqlStr = "";
        private TreeNode node = new TreeNode();//类型树的根节点。
        #endregion

        #region KCMingXi_Load()方法：窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KCMingXi_Load(object sender, EventArgs e)
        {
            //初始化其他数据,刀具柜选择框中的数据源
            comboBox1.Items.Add("全部");
            SqlStr = "select djgmc from  daojugui";
            MySqlDataReader djg_dr = SelectSql.getcom(SqlStr);
            while (djg_dr.Read())
            {
                comboBox1.Items.Add(djg_dr[0].ToString());
            }
            comboBox1.SelectedIndex = 0;

            //初始化datagridview库存明细数据
            //string sql = "select rcmx.xinghao, rcmx.mc, sum(rcmx.sl) as dangqiankucunliang, djg.djgmc, rcmx.cfwz, rcmx.bz from rucangmingxi rcmx inner join daojugui djg on rcmx.djgbm = djg.djgbm group by rcmx.xinghao, rcmx.djgbm, rcmx.cfwz";
            //DataSet ds = new DataSet();
            //ds = select.getDataSet1(sql);
            //KCMX.DataSource = ds.Tables[0].DefaultView;

            //添加并设置根节点           
            treeView1.Nodes.Add(node);
            node.Text = "所有类型";
            BindRoot();//生成树的第一层
            treeView1.Nodes[0].Expand();//默认展开第一层节点
        }
        #endregion

        #region KCMX_RowPostPaint()方法：datagridview设置
        /// <summary>
        /// datagridview事件设置之为每一行生成序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KCMX_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, KCMX.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), KCMX.RowHeadersDefaultCellStyle.Font, rectangle, KCMX.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
        #endregion

        #region comboBox1_SelectedIndexChanged()方法：根据刀具柜名称显示库存明细
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = comboBox1.SelectedItem.ToString();
            string where = "";
            if(item != "全部")
            {
                where = "where djg.djgmc = '" + item.Trim() + "'";
            }
            SqlStr = "select rcmx.xinghao, rcmx.mc, sum(rcmx.sl) as dangqiankucunliang, djg.djgmc, rcmx.cfwz, rcmx.bz from rucangmingxi rcmx inner join daojugui djg on rcmx.djgbm = djg.djgbm " + where.Trim() + " group by rcmx.xinghao, rcmx.djgbm, rcmx.cfwz";
            DataSet ds = new DataSet();
            ds = SelectSql.getDataSet1(SqlStr);
            KCMX.DataSource = ds.Tables[0].DefaultView;
        }
        #endregion

        //private void XHCHBtn_TextChanged(object sender, EventArgs e)
        //{
        // List<string> source = new List<string>();

        //string sql = "select xinghao from lingbujian";

        //DataSet ds = Select.getDataSet(sql, "lingbujian");
        //var source = new AutoCompleteStringCollection();
        //source.Add(ds.Tables.ToString());
        //foreach(DataRow dr in ds.Tables[0].Rows)
        //{
        //    source.Add(dr[0].ToString());
        //}
        //XHCHBtn.AutoCompleteCustomSource = source.;
        //}

        #region SearchBtn_Click()方法：根据零部件型号进行库存明细查询
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string item = XHCH.Text.ToString().Trim();
            if(item == "")
            {
                MessageBox.Show("请输入要查询的零部件型号！", "提示", MessageBoxButtons.OK);           
            }
            else
            {
                item = "where rcmx.xinghao='" + item + "'";
            }
            SqlStr = "select rcmx.xinghao, rcmx.mc, sum(rcmx.sl) as dangqiankucunliang, djg.djgmc, rcmx.cfwz, rcmx.bz from rucangmingxi rcmx inner join daojugui djg on rcmx.djgbm = djg.djgbm " + item + " group by rcmx.xinghao, rcmx.djgbm, rcmx.cfwz";
            DataSet ds = SelectSql.getDataSet1(SqlStr);
            KCMX.DataSource = ds.Tables[0].DefaultView;
        }
        #endregion

        #region BindeRoot()方法和AddChild()方法：构造类型（所有类型-->名称-->型号）树
        ///<summary>生成树之生成第一层名称节点</summary>
        private void BindRoot()
        {
            //查询有多少不重复名称，以设置进度条
            //string getRows = "select count(xinghao) from lingbujian";
            //string getRows = "select count(distinct mc) from lingbujian";
            label5.Text = "正在加载……";
            label5.Visible = true;
            //progressBar1.Value = 0;
            //progressBar1.Minimum = 0;
            //进度条最大值为所有名称条数
            //progressBar1.Maximum = Convert.ToInt32(SelectSql.ExecuteScalar(getRows));

            //treeView1.LabelEdit = true; //可编辑状态
            
            //添加一个节点，这个节点是根节点
            //TreeNode node = new TreeNode();
           // node.Text = "所有类型";
            //treeView1.Nodes.Add(node);

            //把数据库中取出所有零部件名称
            MySqlDataReader mc = SelectSql.getcom("select distinct mc from lingbujian");
            //node.Nodes[0].Remove();//移除刚开始建立的第一个空节点
            while(mc.Read())
            {
                TreeNode t1 = new TreeNode();
                t1.Text = mc[0].ToString();
                node.Nodes.Add(t1);
                t1.Nodes.Add("");//添加一个空的子节点，才会出现折叠+号
               // AddChild(t1);

                //进度条增加
                //progressBar1.Value++;
            }

            //更改进度条并隐藏
            label5.Text = "加载完成！";
            //label5.Visible = false;
            //progressBar1.Visible = false;
        }

        /// <summary>
        /// 生成树之构造子节点
        /// </summary>
        ///<param name="t1">为t1节点添加子节点</param>
        private void AddChild(TreeNode t1)
        {
            label5.Text = "正在加载……";
            label5.Visible = true;
            //progressBar1.Visible = true;           
            //progressBar1.Value = 0;//重置进度条

            //查询当前名称下的型号数量的SQL语句
            //string getRowsSql = "select count(xinghao) from lingbujian where mc='" + t1.Text.ToString().Trim() + "'";

            //进度条最大值为所有型号条数
            //progressBar1.Maximum = Convert.ToInt32(SelectSql.ExecuteScalar(getRowsSql)) * 10;
             
            MySqlDataReader xh = SelectSql.getcom("select xinghao from lingbujian where mc='" + t1.Text.ToString().Trim() + "'");
            while(xh.Read())
            {
                TreeNode t2 = new TreeNode();
                t2.Text = xh[0].ToString();
                t1.Nodes.Add(t2);                
                //progressBar1.Value++;//进度条增加
            }

            //更改进度条并隐藏
            label5.Text = "加载完成！";
            //label5.Visible = false;
            //progressBar1.Visible = false;
        }
        #endregion

        #region treeView1_BeforeExpand()方法：按需展开节点查询并创建子节点
        /// <summary>
        /// 按需展开节点查询并创建子节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //判断第一个子节点是否为空，若为空代表还未生成则生成子节点，否则避免重复执行代码
            if (e.Node.Nodes[0].Text == "")
            {
                TreeNode currentNode = e.Node;
                currentNode.Nodes[0].Remove();
                AddChild(currentNode);
            }
            else
                return;
        }
        #endregion

        #region treeView1_AfterSelect()方法：根据选择的树节点进行库存明细查询
        /// <summary>
        /// 根据选择的树节点进行库存明细查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">当前节点</param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string where = "";//SQL语句条件。默认为空，即第一层节点：所有类型
            if(treeView1.SelectedNode.Level == 1)//当前选中节点为第二层节点：名称
            {
                where = "where rcmx.mc = '" + e.Node.Text.ToString() + "'";
            }
            else if(treeView1.SelectedNode.Level == 2)//当前选中节点为第三层节点：型号
            {
                where = "where rcmx.xinghao = '" + e.Node.Text.ToString() + "'";
            }
            SqlStr = "select rcmx.xinghao, rcmx.mc, sum(rcmx.sl) as dangqiankucunliang, djg.djgmc, rcmx.cfwz, rcmx.bz from rucangmingxi rcmx inner join daojugui djg on rcmx.djgbm = djg.djgbm " + where + " group by rcmx.xinghao, rcmx.djgbm, rcmx.cfwz";
            KCMX.DataSource = SelectSql.getDataSet1(SqlStr).Tables[0].DefaultView;
        }
        #endregion
    }
}
