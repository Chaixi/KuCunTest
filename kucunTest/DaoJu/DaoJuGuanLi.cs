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

using kucunTest.KuCun;
using kucunTest.BaseClasses;

namespace kucunTest.DaoJu
{
    public partial class DaoJuGuanLi : Form
    {
        public DaoJuGuanLi()
        {
            InitializeComponent();
        }

        #region 全局变量
        private MySql SelectSql = new MySql();//MySQL类
        private string SqlStr = "";//sql语句
        private BaseAlex Alex = new BaseAlex();//自定义公共方法类
        private TreeNode node = new TreeNode();//类型树的根节点。
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        //沫
        private string SqlStr1 = "";
        private int i;
        #endregion

        #region BindeRoot()方法和AddChild()方法：构造类型（所有类型-->名称-->型号）树
        ///<summary>生成树之生成第一层名称节点</summary>
        private void BindRoot()
        {
            //查询有多少不重复名称，以设置进度条
            //label5.Text = "正在加载……";
            //label5.Visible = true;
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
            MySqlDataReader djlx = SelectSql.getcom("select distinct daojuleixing from daojutemp");
            //node.Nodes[0].Remove();//移除刚开始建立的第一个空节点
            while (djlx.Read())
            {
                TreeNode t1 = new TreeNode();
                t1.Text = djlx[0].ToString();
                node.Nodes.Add(t1);
                //t1.Nodes.Add("");//添加一个空的子节点，才会出现折叠+号
                                 // AddChild(t1);

                //进度条增加
                //progressBar1.Value++;
            }

            //更改进度条并隐藏
            label5.Text = "加载完成！";

        }
        private void AddChild(TreeNode t1)
        {
            label5.Text = "正在加载……";
            label5.Visible = true;
            //progressBar1.Visible = true;           
            //progressBar1.Value = 0;//重置进度条

            MySqlDataReader djid = SelectSql.getcom("select daojuid from daojutemp where daojuleixing='" + t1.Text.ToString().Trim() + "'");
            while (djid.Read())
            {
                TreeNode t2 = new TreeNode();
                t2.Text = djid[0].ToString();
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

        #region treeView1_AfterSelect()方法：根据选择的树节点进行查询
        /// <summary>
        /// 根据选择的树节点进行库存明细查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">当前节点</param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string where = "";//SQL语句条件。默认为空，即第一层节点：所有类型
            if (treeView1.SelectedNode.Level == 1)//当前选中节点为第二层节点：刀具类型
            {
                where = "where dj.daojuleixing = '" + e.Node.Text.ToString() + "'";
                SqlStr = "SELECT COUNT(*) from daojutemp where daojuleixing = '" + e.Node.Text.ToString() + "'";//查询所有刀具数量
                SqlStr1 = "SELECT COUNT(djmx.weizhibiaoshi) FROM daojutemp dj LEFT JOIN daojulingyongmingxi djmx ON dj.daojuid = djmx.daojuid where dj.daojuleixing =  '" + e.Node.Text.ToString() + "'";//查询领用到机床的刀具数量
                Object a = SelectSql.ExecuteScalar(SqlStr);
                Object b = SelectSql.ExecuteScalar(SqlStr1);
                string x = a.ToString();
                string y = b.ToString();
                int c = Int32.Parse(x) - Int32.Parse(y);//计算出刀具柜中的刀具数量
                string z = c.ToString();
                djzs.Text = x;
                jcsl.Text = y;
                djgsl.Text = z;
            }
            
            //查询出选种类型的刀具
            SqlStr = "SELECT dj.daojuid,dj.daojuxinghao,dj.daojuguige,dj.daojuleixing,dj.daojushouming,CONCAT(djmx.jichuangbianma,'--', djmx.daotaohao ) AS daojuweizhi,djcc.chucangdanhao,djcc.chucangriqi FROM daojutemp dj LEFT JOIN daojulingyongmingxi djmx ON dj.daojuid = djmx.daojuid LEFT JOIN daojulingyong  djcc ON  djcc.chucangdanhao = djmx.chucangdanhao " + where + " group by dj.daojuid";
            daojuxinxi.DataSource = SelectSql.getDataSet1(SqlStr).Tables[0].DefaultView;
            daojuxinxi.AutoGenerateColumns = false;

            for (i = 0; i < daojuxinxi.Rows.Count - 1; i++)
            {
                //对刀具寿命值进行判断，以对需要提醒的数据突出显示

               // this.daojuxinxi.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                string sm = daojuxinxi.Rows[i].Cells["djsm"].Value.ToString();
                int shouming = int.Parse(sm);
                if (shouming <= 30)
                {
                    //this.daojuxinxi.Columns[3].DefaultCellStyle.BackColor = Color.Red;
                    daojuxinxi.Rows[i].Cells["djsm"].Style.BackColor = Color.Red;

                }
                if (shouming > 30 && shouming <=100)
                {
                    //this.daojuxinxi.Columns[3].DefaultCellStyle.BackColor = Color.Red;
                    daojuxinxi.Rows[i].Cells["djsm"].Style.BackColor = Color.Yellow;
                }
            }
        }
        #endregion


        /// <summary>
        /// 装配刀具按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            zhuangpeidaoju zpdj = new zhuangpeidaoju();
            zpdj.Show();
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daojuguanli_Load(object sender, EventArgs e)
        {
            treeView1.Nodes.Add(node);
            node.Text = "所有类型";
            BindRoot();//生成树的第一层
            treeView1.Nodes[0].Expand();//默认展开第一层节点
            //treeView1.SelectedNode = treeView1.Nodes[0];//默认选中顶层节点
            treeView1.SelectedNode = treeView1.Nodes[0].FirstNode;
            daojuxinxi.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 刀具领用按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            History djly = new History("DJCCD");
            djly.Show();
            //DJCCD DJCCD = new DJCCD();
            //DJCCD.Show();
        }

        /// <summary>
        /// 库存明细按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kccx_Click(object sender, EventArgs e)
        {
            DJKCMX djczjl = new DJKCMX();
            djczjl.Show();
        }

        /// <summary>
        /// 表格序号显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daojuxinxi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(daojuxinxi, e);
        }

        /// <summary>
        /// 窗口自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DaoJuGuanLi_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        /// <summary>
        /// 刀具更换按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_djgh_Click(object sender, EventArgs e)
        {
            History djgh = new History("DJGH");
            djgh.Show();
        }
        /// <summary>
        /// 刀具外借按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_djwj_Click(object sender, EventArgs e)
        {
            History djwj = new History("DJWJ");
            djwj.Show();
        }
    }
}
