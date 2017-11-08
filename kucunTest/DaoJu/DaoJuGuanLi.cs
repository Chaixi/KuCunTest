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
        private MySql SQL = new MySql();//MySQL类
        private string SqlStr = "";//sql语句
        private BaseAlex Alex = new BaseAlex();//自定义公共方法类
        private TreeNode node = new TreeNode();//类型树的根节点。
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private string canshubiao = "jichucanshu";
        private string jichuangdaojuku = "jcdaojuku";
        private string daojubiao = "daojutemp";
        Panel scx_panel = new Panel();//生产线机床排布全局变量

        //沫
        private string SqlStr1 = "";
        private int i;
        #endregion

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daojuguanli_Load(object sender, EventArgs e)
        {
            //asc.controllInitializeSize(this);

            treeView1.Nodes.Clear();

            treeView1.Nodes.Add(node);
            node.Text = "所有类型";
            BindRoot();//生成树的第一层
            treeView1.Nodes[0].Expand();//默认展开第一层节点
            //treeView1.SelectedNode = treeView1.Nodes[0];//默认选中顶层节点
            treeView1.SelectedNode = treeView1.Nodes[0].FirstNode;
            daojuxinxi.AutoGenerateColumns = false;

            //默认选择第一条生产线
            comboBox2.SelectedIndex = 0;

            //加载所有刀具柜
            string sqlstr1 = "select djgmc from daojugui";
            cxdjgmc.DataSource = SQL.DataReadList(sqlstr1);
            cxdjgmc.SelectedIndex = -1;

        }

        #region 树有关的方法
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
            MySqlDataReader djlx = SQL.getcom("select distinct daojuleixing from daojutemp");
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

            MySqlDataReader djid = SQL.getcom("select daojuid from daojutemp where daojuleixing='" + t1.Text.ToString().Trim() + "'");
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
                where = "WHERE dj.daojuleixing = '" + e.Node.Text.ToString() + "'";
                SqlStr = "SELECT COUNT(*) FROM daojutemp dj WHERE dj.daojuleixing = '" + e.Node.Text.ToString() + "'";//查询所有刀具数量
                //SqlStr1 = "SELECT COUNT(djmx.weizhibiaoshi) FROM daojutemp dj LEFT JOIN daojulingyongmingxi djmx ON dj.daojuid = djmx.daojuid where dj.daojuleixing =  '" + e.Node.Text.ToString() + "'";//查询领用到机床的刀具数量
                SqlStr1 = string.Format("SELECT COUNT(*) FROM {0} dj WHERE dj.daojuleixing = '{1}' AND dj.weizhibiaoshi = 'M'", daojubiao, e.Node.Text.ToString());
                Object a = SQL.ExecuteScalar(SqlStr);
                Object b = SQL.ExecuteScalar(SqlStr1);
                string x = a.ToString();
                string y = b.ToString();
                int c = Int32.Parse(x) - Int32.Parse(y);//计算出刀具柜中的刀具数量
                string z = c.ToString();
                djzs.Text = x;
                jcsl.Text = y;
                djgsl.Text = z;
            }
            
            //查询出选中类型的刀具
            //SqlStr = "SELECT dj.daojuid, dj.daojuxinghao, dj.daojuguige, dj.daojuleixing, dj.daojushouming, CONCAT(djmx.jichuangbianma,'--', djmx.daotaohao ) AS daojuweizhi,djcc.chucangdanhao,djcc.chucangriqi FROM daojutemp dj LEFT JOIN daojulingyongmingxi djmx ON dj.daojuid = djmx.daojuid LEFT JOIN daojulingyong  djcc ON  djcc.chucangdanhao = djmx.chucangdanhao " + where + " group by dj.daojuid";
            //SqlStr = "SELECT dj.daojuid, dj.daojuxinghao, dj.daojuguige, dj.daojuleixing, dj.daojushouming, CONCAT(dj.weizhibiaoshi, '-', dj.weizhi,'-', dj.cengshu) AS daojuweizhi, dj.weizhibiaoshi, djcc.chucangdanhao, djcc.chucangriqi FROM daojutemp dj LEFT JOIN daojulingyongmingxi djmx ON dj.daojuid = djmx.daojuid LEFT JOIN daojulingyong djcc ON djcc.chucangdanhao = djmx.chucangdanhao " + where + " ORDER BY daojuweizhi";
			SqlStr = "SELECT dj.daojuid,dj.daojuxinghao,dj.daojuguige,dj.daojuleixing,dj.daojushouming,CONCAT(dj.weizhibiaoshi, '-', dj.weizhi,'-', dj.cengshu) AS daojuweizhi,dj.zzdj,dj.weizhibiaoshi,djcc.chucangdanhao,djcc.chucangriqi FROM daojutemp dj LEFT JOIN daojulingyongmingxi djmx ON dj.daojuid = djmx.daojuid LEFT JOIN daojulingyong  djcc ON  djcc.chucangdanhao = djmx.chucangdanhao " + where + " group by dj.daojuid";

            daojuxinxi.DataSource = SQL.getDataSet1(SqlStr).Tables[0].DefaultView;
            daojuxinxi.AutoGenerateColumns = false;

            Refresh_color();
        }
        #endregion
        #endregion 树有关的方法结束

        #region 按钮部分
        /// <summary>
        /// 装配刀具按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string daojuleixing = daojuxinxi.CurrentRow.Cells["djlx"].Value.ToString();
            string daojuguige = daojuxinxi.CurrentRow.Cells["djgg"].Value.ToString();
            string daojuxinghao = daojuxinxi.CurrentRow.Cells["djxh"].Value.ToString();

            zhuangpeidaoju zpdj = new zhuangpeidaoju(daojuleixing, daojuguige, daojuxinghao);
            zpdj.ShowDialog();
            TreeNode crtNode = treeView1.SelectedNode;
            if(zpdj.DialogResult == DialogResult.OK)
            {
                daojuguanli_Load(null, null);
                treeView1.SelectedNode = crtNode;
            }
        }

        /// <summary>
        /// 刀具测量按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (daojuxinxi.CurrentCell.RowIndex >= 0)
            {
                string id = daojuxinxi.Rows[daojuxinxi.CurrentCell.RowIndex].Cells["djid"].Value.ToString();
                DaoJuCanShuXinXi djcs = new DaoJuCanShuXinXi(id);
                djcs.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择一把刀具！", "提示");
            }
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
        /// 拆卸刀具按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cxdj_Click(object sender, EventArgs e)
        {
            bool flag = true;//是否可以拆卸
            int rowCheckedCount = 0;//选中行数量
            string str = "";
            string daojuleixing = "";
            string daojuguige = "";
            string daojuid = "";
            string daojuxinghao = "";
            DataTable tb = new DataTable();//存放选中的数据
            DataTable dgv_tb = Alex.GetDgvToTable(daojuxinxi);
            tb = dgv_tb.Copy();
            tb.Clear();

            daojuxinxi.EndEdit();//如果DataGridView是可编辑的，将数据提交，否则处于编辑状态的行无法取到 

            //循环遍历选中的行
            for (int i = 0; i < dgv_tb.Rows.Count; i++)
            {
                if (dgv_tb.Rows[i]["check"].ToString() == "true")//该行是否选中
                {
                    rowCheckedCount++;//选中行+1
                    if (dgv_tb.Rows[i]["zzdj"].ToString() == null || dgv_tb.Rows[i]["zzdj"].ToString() == "") //判断是否是组装的刀具
                    {
                        str = daojuxinxi.Rows[i].Cells["djid"].Value.ToString() + "不是可拆卸刀具！请重新选择可拆卸刀具。";
                        flag = false;
                    }
                    else
                    {
                        daojuleixing = daojuxinxi.Rows[i].Cells["djlx"].Value.ToString();
                        daojuguige = daojuxinxi.Rows[i].Cells["djgg"].Value.ToString();
                        daojuid = daojuxinxi.Rows[i].Cells["djid"].Value.ToString();
                        daojuxinghao = daojuxinxi.Rows[i].Cells["djxh"].Value.ToString();
                        chaixiedaoju cxdj = new chaixiedaoju(daojuleixing, daojuguige, daojuid, daojuxinghao);
                        cxdj.ShowDialog();
                        TreeNode crtNode = treeView1.SelectedNode;
                        if (cxdj.DialogResult == DialogResult.OK)
                        {
                            daojuguanli_Load(null, null);
                            treeView1.SelectedNode = crtNode;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }

            if (rowCheckedCount == 0)
            {
                str = "请先选择要拆卸的刀具！";
                flag = false;

            }
            if (rowCheckedCount > 1)
            {

                str = "每次只能拆卸一把刀具！";
                flag = false;
            }
            if (flag == false)//可以领用
            {
                MessageBox.Show(str, "提示");
            }


        }

        /// <summary>
        /// 快捷操作，刀具信息表格双击弹出刀具测量界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daojuxinxi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = daojuxinxi.Rows[e.RowIndex].Cells["djid"].Value.ToString();
                DaoJuCanShuXinXi djcs = new DaoJuCanShuXinXi(id);
                djcs.ShowDialog();
            }
        }

        /// <summary>
        /// 刀具领用按钮，只能对未被领用刀具进行领用，位置标识为S的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //History djly = new History("DJCCD");
            //djly.Show();

            //把当前选择的数据行添加到新的表中作为参数调用刀具领用中的AddDataFromTable()方法
            bool flag = true;//是否可以领用
            int rowCheckedCount = 0;//选中行数量
            string str = "";
            string djwz = "";//存放刀具位置
            DataTable tb = new DataTable();//存放选中的数据
            //DataTable dgv_tb = (DataTable)daojuxinxi.DataSource;//获取dataview 转换成 datatable
            DataTable dgv_tb = Alex.GetDgvToTable(daojuxinxi);
            tb = dgv_tb.Copy();
            tb.Clear();

            daojuxinxi.EndEdit();//如果DataGridView是可编辑的，将数据提交，否则处于编辑状态的行无法取到 

            //循环遍历选中的行
            for (int i = 0; i < dgv_tb.Rows.Count; i++)
            {
                if(dgv_tb.Rows[i]["check"].ToString() == "true")//该行是否选中
                {
                    rowCheckedCount++;//选中行+1

                    //截取还原刀具位置
                    djwz = dgv_tb.Rows[i]["djwz"].ToString();
                    
                    //判断刀具是否已经被领用
                    //if (dgv_tb.Rows[i]["djwz"].ToString() == null || dgv_tb.Rows[i]["djwz"].ToString() == "")
                    if(djwz.Substring(0, 1) == "S")//截取一位标识符，S表示在库，可领用
                    {
                        tb.Rows.Add(dgv_tb.Rows[i].ItemArray);//也可以是tb.ImportRow(dgv_tb.Rows[i]);但不能直接tb.Rows.Add(row);出错：改行已经在另一个表中
                        //DataRow row = ((daojuxinxi.Rows[i]).DataBoundItem as DataRowView).Row;//微软提供的唯一的从DataGridViewRow转换DataRow
                    }
                    else//M表示在机床
                    {
                        str = daojuxinxi.Rows[i].Cells["djid"].Value.ToString() + "已被领用！请重新选择或装配新刀具。";
                        flag = false;
                        break;
                    }                    
                }
                else
                {
                    continue;
                }
            }

            if(rowCheckedCount == 0)
            {
                str = "请先选择要领用的刀具！";
                flag = false;
            }

            if(flag)//可以领用
            {
                DJCCD djly = new DJCCD();
                djly.AddDataFromTable(tb);
                djly.ShowDialog();
            }
            else
            {
                MessageBox.Show(str, "提示");
            }            
        }

        /// <summary>
        /// 刀具续用按钮，只能对已领用刀具进行续用，位置标识为M的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void djxy_Click(object sender, EventArgs e)
        {
            bool flag = true;//是否可以领用
            int rowCheckedCount = 0;//选中行数量
            string str = "";//存放报错or提示信息
            string djwz = "";//存放刀具位置

            DataTable tb = new DataTable();//存放选中的数据
            DataTable dgv_tb = Alex.GetDgvToTable(daojuxinxi);//datagridview 转换成 datatable
            tb = dgv_tb.Copy();//tb与datagridview中表结构相同
            tb.Clear();

            daojuxinxi.EndEdit();//如果DataGridView是可编辑的，将数据提交，否则处于编辑状态的行无法取到 

            //循环遍历选中的行
            for (int i = 0; i < dgv_tb.Rows.Count; i++)
            {
                if (dgv_tb.Rows[i]["check"].ToString() == "true")//该行是否选中
                {
                    rowCheckedCount++;//选中行+1

                    //截取还原刀具位置
                    djwz = dgv_tb.Rows[i]["djwz"].ToString();

                    //判断刀具是否已经被领用
                    if (djwz.Substring(0, 1) == "M")//截取一位标识符，M表示已被领用，可续用
                    {
                        tb.Rows.Add(dgv_tb.Rows[i].ItemArray);//也可以是tb.ImportRow(dgv_tb.Rows[i]);但不能直接tb.Rows.Add(row);出错：该行已经在另一个表中
                        //DataRow row = ((daojuxinxi.Rows[i]).DataBoundItem as DataRowView).Row;//微软提供的唯一的从DataGridViewRow转换DataRow
                    }
                    else
                    {
                        //存在不能续用的刀具，直接跳出循环，flag置false
                        str = daojuxinxi.Rows[i].Cells["djid"].Value.ToString() + "未被领用，不能进行续用！";
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
                str = "请先选择要续用的刀具！";
                flag = false;
            }

            if (flag)//可以领用
            {
                DJXY djxy = new DJXY();
                djxy.AddDataFromTable(tb);//传输选中的刀具信息
                djxy.ShowDialog();
            }
            else
            {
                MessageBox.Show(str, "提示");
            }
        }

        /// <summary>
        /// 刀具更换按钮，只能对已被领用刀具进行更换，位置标识为M的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_djgh_Click(object sender, EventArgs e)
        {
            //History djgh = new History("DJGH");
            //djgh.Show();

            //把当前选择的数据行添加到新的表中作为参数调用刀具领用中的AddDataFromTable()方法
            bool flag = true;//是否可以更换
            int rowCheckedCount = 0;//选中行数量
            string str = "";
            string djwz = "";//存放刀具位置
            DataTable tb = new DataTable();//存放选中的数据
            DataTable dgv_tb = Alex.GetDgvToTable(daojuxinxi);
            tb = dgv_tb.Copy();
            tb.Clear();

            daojuxinxi.EndEdit();//如果DataGridView是可编辑的，将数据提交，否则处于编辑状态的行无法取到 

            //循环遍历选中的行
            for (int i = 0; i < dgv_tb.Rows.Count; i++)
            {
                if (dgv_tb.Rows[i]["check"].ToString() == "true")//该行是否选中
                {
                    rowCheckedCount++;//选中行+1

                    //截取还原刀具位置
                    djwz = dgv_tb.Rows[i]["djwz"].ToString();

                    //判断刀具是否已经被领用
                    //if (dgv_tb.Rows[i]["djwz"].ToString() == null || dgv_tb.Rows[i]["djwz"].ToString() == "")
                    if(djwz.Substring(0, 1) == "S")
                    {
                        str = daojuxinxi.Rows[i].Cells["djid"].Value.ToString() + "未被领用！无需更换。";
                        flag = false;
                        break;
                    }
                    else
                    {
                        tb.Rows.Add(dgv_tb.Rows[i].ItemArray);                        
                    }
                }
                else
                {
                    continue;
                }
            }

            if (rowCheckedCount == 0)
            {
                str = "请先选择要领用的刀具！";
                flag = false;
            }
            else if(rowCheckedCount > 1)
            {
                str = "不可以对多把刀具同时进行更换！";
                flag = false;
            }

            if (flag)//可以领用
            {
                DJGH djgh = new DJGH();
                djgh.AddDataFromTable(tb);
                djgh.ShowDialog();
            }
            else
            {
                MessageBox.Show(str, "提示");
            }
        }

        /// <summary>
        /// 刀具外借按钮，所有刀具均可外借
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_djwj_Click(object sender, EventArgs e)
        {
            //History djwj = new History("DJWJ");
            //djwj.Show();

            //把当前选择的数据行添加到新的表中作为参数调用刀具领用中的AddDataFromTable()方法
            bool flag = true;//是否可以领用
            int rowCheckedCount = 0;//选中行数量
            string str = "";
            DataTable tb = new DataTable();//存放选中的数据
            DataTable dgv_tb = Alex.GetDgvToTable(daojuxinxi);
            tb = dgv_tb.Copy();
            tb.Clear();

            daojuxinxi.EndEdit();//如果DataGridView是可编辑的，将数据提交，否则处于编辑状态的行无法取到 

            //循环遍历选中的行
            for (int i = 0; i < dgv_tb.Rows.Count; i++)
            {
                if (dgv_tb.Rows[i]["check"].ToString() == "true")//该行是否选中
                {
                    rowCheckedCount++;//选中行+1

                    tb.Rows.Add(dgv_tb.Rows[i].ItemArray);//也可以是tb.ImportRow(dgv_tb.Rows[i]);但不能直接tb.Rows.Add(row);出错：改行已经在另一个表中
                }
                else
                {
                    continue;
                }
            }

            if (rowCheckedCount == 0)
            {
                str = "请先选择要借用的刀具！";
                flag = false;
            }

            if (flag)//可以领用
            {
                DJWJ djwj = new DJWJ();
                djwj.AddDataFromTable(tb);
                djwj.ShowDialog();
            }
            else
            {
                MessageBox.Show(str, "提示");
            }
        }

        /// <summary>
        /// 刀具报废按钮，只能对已被领用刀具进行报废单据填写，位置标识为M的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            //History djbf = new History("DJBF");
            //djbf.Show();

            //把当前选择的数据行添加到新的表中作为参数调用刀具领用中的AddDataFromTable()方法
            bool flag = true;//是否可以更换
            int rowCheckedCount = 0;//选中行数量
            string str = "";
            string djwz = "";//存放刀具位置
            DataTable tb = new DataTable();//存放选中的数据
            DataTable dgv_tb = Alex.GetDgvToTable(daojuxinxi);
            tb = dgv_tb.Copy();
            tb.Clear();

            daojuxinxi.EndEdit();//如果DataGridView是可编辑的，将数据提交，否则处于编辑状态的行无法取到 

            //循环遍历选中的行
            for (int i = 0; i < dgv_tb.Rows.Count; i++)
            {
                if (dgv_tb.Rows[i]["check"].ToString() == "true")//该行是否选中
                {
                    rowCheckedCount++;//选中行+1

                    //截取还原刀具位置
                    djwz = dgv_tb.Rows[i]["djwz"].ToString();

                    //判断刀具是否已经被领用
                    //if (dgv_tb.Rows[i]["djwz"].ToString() == null || dgv_tb.Rows[i]["djwz"].ToString() == "")
                    if(djwz.Substring(0, 1) == "S")
                    {
                        str = daojuxinxi.Rows[i].Cells["djid"].Value.ToString() + "未被领用！";
                        flag = false;
                        break;
                    }
                    else
                    {
                        tb.Rows.Add(dgv_tb.Rows[i].ItemArray);
                    }
                }
                else
                {
                    continue;
                }
            }

            if (rowCheckedCount == 0)
            {
                str = "请先选择要报废的刀具！";
                flag = false;
            }
            else if (rowCheckedCount > 1)
            {
                str = "请选择单把刀具！";
                flag = false;
            }

            if (flag)//可以领用
            {
                DJBF djbf = new DJBF();
                djbf.AddDataFromTable(tb);
                djbf.ShowDialog();
            }
            else
            {
                MessageBox.Show(str, "提示");
            }
        }

        /// <summary>
        /// 刀具退还按钮，只能对已被领用刀具进行更换，位置标识为M的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            //History djth = new History("DJTH");
            //djth.Show();

            //把当前选择的数据行添加到新的表中作为参数调用刀具领用中的AddDataFromTable()方法
            bool flag = true;//是否可以退还
            int rowCheckedCount = 0;//选中行数量
            string str = "";
            string djwz = "";//存放刀具位置
            DataTable tb = new DataTable();//存放选中的数据
            DataTable dgv_tb = Alex.GetDgvToTable(daojuxinxi);
            tb = dgv_tb.Copy();
            tb.Clear();

            daojuxinxi.EndEdit();//如果DataGridView是可编辑的，将数据提交，否则处于编辑状态的行无法取到 

            //循环遍历选中的行
            for (int i = 0; i < dgv_tb.Rows.Count; i++)
            {
                if (dgv_tb.Rows[i]["check"].ToString() == "true")//该行是否选中
                {
                    rowCheckedCount++;//选中行+1

                    //截取还原刀具位置
                    djwz = dgv_tb.Rows[i]["djwz"].ToString();

                    //判断刀具是否已经被领用
                    //if (dgv_tb.Rows[i]["djwz"].ToString() == null || dgv_tb.Rows[i]["djwz"].ToString() == "")
                    if(djwz.Substring(0, 1) == "S")
                    {
                        str = daojuxinxi.Rows[i].Cells["djid"].Value.ToString() + "还未被领用！";
                        flag = false;
                        break;
                    }
                    else
                    {
                        tb.Rows.Add(dgv_tb.Rows[i].ItemArray);//也可以是tb.ImportRow(dgv_tb.Rows[i]);但不能直接tb.Rows.Add(row);出错：改行已经在另一个表中
                    }
                }
                else
                {
                    continue;
                }
            }

            if (rowCheckedCount == 0)
            {
                str = "请先选择要退还的刀具！";
                flag = false;
            }

            if (flag)//可以退还
            {
                DJTH djth = new DJTH();
                djth.AddDataFromTable(tb);
                djth.ShowDialog();
            }
            else
            {
                MessageBox.Show(str, "提示");
            }
        }

        /// <summary>
        /// 刷新按钮,对刀具寿命值进行判断，以对需要提醒的数据突出显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Refresh_color();
        }

        /// <summary>
        /// checkbox值发生改变时，改变该行背景色。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daojuxinxi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)//表头不发生验证
            {
                if (daojuxinxi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "true")//选中该行
                {
                    daojuxinxi.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;//背景色高亮
                }
                else if (daojuxinxi.CurrentCell.Value.ToString() == "false")//取消选中该行
                {
                    //根据奇偶行判断表格底色
                    //if (Convert.ToInt16(e.RowIndex) % 2 == 0)//偶数行
                    //{
                    //    daojuxinxi.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                    //}
                    //else//奇数行
                    //{
                    //    daojuxinxi.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gainsboro;
                    //}
                    
                    //取消选中表格颜色更换，根据寿命和刀具位置判断显示颜色
                    string sm = daojuxinxi.Rows[e.RowIndex].Cells["djsm"].Value.ToString();
                    string djwz = daojuxinxi.Rows[e.RowIndex].Cells["djwz"].Value.ToString();

                    //对刀具位置进行判断，对刀具柜刀具和机床刀具库刀具区分显示
                    switch (djwz.Substring(0, 1))
                    {
                        case "M":
                            this.daojuxinxi.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
                            break;
                        case "S":
                            this.daojuxinxi.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                            break;
                        case "T":
                            this.daojuxinxi.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.HotPink;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 通过对选中的行进行处理，判断是否可以对刀具进行操作
        /// </summary>
        /// <returns></returns>
        //private bool DaoJuCaoZu()
        //{
        //    bool flag = false;
        //    return flag;
        //} 

        #endregion 按钮部分结束

        #region 其他方法
        /// <summary>
        /// daojuxinxi和dgv_jcdk的表格序号绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(sender as DataGridView, e);
        }

        /// <summary>
        /// 窗口自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DaoJuGuanLi_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);
        }

        /// <summary>
        /// 当窗体在选项卡中打开时，关闭窗体则关闭相应的选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DaoJuGuanLi_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Parent != null)
            {
                MainForm mfr = (MainForm)this.Parent.FindForm();
                mfr.CloseTab(this.Name);
            }
        }

        /// <summary>
        /// 选中单元格刀具，加载刀具参数数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daojuxinxi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.RowIndex >= 0)//判断点击的是否是表头
            //{
            //    SqlStr = string.Format("SELECT * FROM {0} WHERE ssfm = '{1}'", canshubiao, daojuxinxi.Rows[e.RowIndex].Cells["djid"].Value.ToString());
            //    DataTable db = SelectSql.getDataSet(SqlStr, canshubiao).Tables[0];

            //    foreach (Control c in grpBox_parameter.Controls)
            //    {
            //        if (c is TextBox)
            //        {
            //            if (db.Rows.Count <= 0)
            //            {
            //                c.Text = "";
            //            }
            //            else
            //            {
            //                for (int i = 0; i < db.Rows.Count; i++)
            //                {
            //                    if (db.Rows[i]["csdm"].ToString() == c.Name)
            //                    {
            //                        c.Text = db.Rows[i]["csz"].ToString();
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

        }

        #endregion 其他方法结束

        #region 位置信息部分
        /// <summary>
        /// 选择不同生产线，生产线标题和机床排布相应变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //生产线标题变化
            scxmc.Text = comboBox2.SelectedItem.ToString();

            //机床排布和机床名称变化,全部隐藏，再用全局变量显示
            scx_panel1.Visible = false;
            scx_panel2.Visible = false;
            scx_panel3.Visible = false;

            //全局变量赋值
            switch (comboBox2.SelectedItem.ToString().Substring(0, 1))
            {
                case "1":
                    scx_panel = scx_panel1;
                    break;
                case "2":
                    scx_panel = scx_panel2;
                    break;
                case "3":
                    scx_panel = scx_panel3;
                    break;
            }

            //清除之前的选择
            foreach (Control c in scx_panel.Controls)
            {
                if(c is PictureBox)
                {
                    c.BackColor = Color.Transparent;
                }
            }

            //清空机床刀具库
            dgv_jcdk.DataSource = null;

            //显示当前机床排布
            scx_panel.Visible = true;
            scx_panel.Dock = DockStyle.Bottom;
        }

        /// <summary>
        /// 点击机床加载相应刀具库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            //GetChildAtPoint(Cursor.Position).BackColor = Color.Blue;

            //改变picturebox背景色
            PictureBox crt_pb = (PictureBox)sender;//当前点击的图片

            foreach(Control c in scx_panel.Controls)
            {
                if(c is PictureBox)
                {
                    if(c.Name == crt_pb.Name)
                    {
                        crt_pb.BackColor = Color.DarkSeaGreen;
                    }
                    else
                    {
                        c.BackColor = Color.FromKnownColor(KnownColor.Control);
                    }
                }
            }

            //加载机床刀具库
            dgv_jcdk.DataSource = null;
            if(crt_pb.Tag != null)
            {
                SqlStr = string.Format("SELECT j.daotaohao AS daotaohao, d.daojuid AS daojuid FROM {0} j LEFT JOIN {1} d ON j.jichuangbianma = d.weizhi AND j.daotaohao = d.cengshu WHERE j.jichuangbianma = '{2}' ORDER BY j.daotaohao ", jichuangdaojuku, daojubiao, crt_pb.Tag.ToString());
                DataSet ds = SQL.getDataSet1(SqlStr);

                dgv_jcdk.AutoGenerateColumns = false;
                dgv_jcdk.DataSource = ds.Tables[0].DefaultView;
            }
        }


        #endregion 位置信息部分结束

        /// <summary>
        /// 对刀具寿命值进行判断，以对需要提醒的数据突出显示
        /// </summary>
        public void Refresh_color()
        {
            string sm = "";
            int shouming = 0;
            string djwz = "";
            for (i = 0; i < daojuxinxi.Rows.Count; i++)
            {
                sm = daojuxinxi.Rows[i].Cells["djsm"].Value.ToString();
                djwz = daojuxinxi.Rows[i].Cells["djwz"].Value.ToString();

                //对刀具位置进行判断，对刀具柜刀具和机床刀具库刀具区分显示
                switch(djwz.Substring(0, 1))
                {
                    case "M":
                        this.daojuxinxi.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                        break;
                    case "S":
                        this.daojuxinxi.Rows[i].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                        break;
                    case "T"://位置特殊刀具，如外借
                        this.daojuxinxi.Rows[i].DefaultCellStyle.BackColor = Color.HotPink;
                        break;
                }

                //对刀具寿命值进行判断，以对需要提醒的数据突出显示
                shouming = int.Parse(sm);
                if (shouming <= 30)
                {
                    //this.daojuxinxi.Columns[3].DefaultCellStyle.BackColor = Color.Red;
                    daojuxinxi.Rows[i].Cells["djsm"].Style.BackColor = Color.Red;

                }
                if (shouming > 30 && shouming <= 100)
                {
                    //this.daojuxinxi.Columns[3].DefaultCellStyle.BackColor = Color.Red;
                    daojuxinxi.Rows[i].Cells["djsm"].Style.BackColor = Color.Yellow;
                }
            }
        }

        //查询条件
        private void button1_Click(object sender, EventArgs e)
        {
            string lxcx = cxdjlx.Text.ToString();
            string idcx = cxdjid.Text.ToString();
            string smcx = cxdjsm.Text.ToString();
            string djgcx = cxdjgmc.SelectedItem.ToString();

            if (lxcx == "" && idcx == "" && smcx == "" && djgcx == "")
            {
                MessageBox.Show("请输入查询条件！", "提示");
            }
            if (lxcx != "" || idcx != "" || smcx != "" || djgcx != "")
            {
                MessageBox.Show("查询成功!", "提示");
            }

        }


    }
}
