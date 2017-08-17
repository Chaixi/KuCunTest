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
            treeView1.Nodes.Clear();

            treeView1.Nodes.Add(node);
            node.Text = "所有类型";
            BindRoot();//生成树的第一层
            treeView1.Nodes[0].Expand();//默认展开第一层节点
            //treeView1.SelectedNode = treeView1.Nodes[0];//默认选中顶层节点
            treeView1.SelectedNode = treeView1.Nodes[0].FirstNode;
            daojuxinxi.AutoGenerateColumns = false;

            treeView2.SelectedNode = treeView2.Nodes[0];

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
                where = "where dj.daojuleixing = '" + e.Node.Text.ToString() + "'";
                SqlStr = "SELECT COUNT(*) from daojutemp where daojuleixing = '" + e.Node.Text.ToString() + "'";//查询所有刀具数量
                SqlStr1 = "SELECT COUNT(djmx.weizhibiaoshi) FROM daojutemp dj LEFT JOIN daojulingyongmingxi djmx ON dj.daojuid = djmx.daojuid where dj.daojuleixing =  '" + e.Node.Text.ToString() + "'";//查询领用到机床的刀具数量
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
            
            //查询出选种类型的刀具
            SqlStr = "SELECT dj.daojuid,dj.daojuxinghao,dj.daojuguige,dj.daojuleixing,dj.daojushouming,CONCAT(djmx.jichuangbianma,'--', djmx.daotaohao ) AS daojuweizhi,djcc.chucangdanhao,djcc.chucangriqi FROM daojutemp dj LEFT JOIN daojulingyongmingxi djmx ON dj.daojuid = djmx.daojuid LEFT JOIN daojulingyong  djcc ON  djcc.chucangdanhao = djmx.chucangdanhao " + where + " group by dj.daojuid";
            daojuxinxi.DataSource = SQL.getDataSet1(SqlStr).Tables[0].DefaultView;
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
        /// 刀具领用按钮
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

                    //判断刀具是否已经被领用
                    if(dgv_tb.Rows[i]["djwz"].ToString() == null || dgv_tb.Rows[i]["djwz"].ToString() == "")
                    {
                        tb.Rows.Add(dgv_tb.Rows[i].ItemArray);//也可以是tb.ImportRow(dgv_tb.Rows[i]);但不能直接tb.Rows.Add(row);出错：改行已经在另一个表中
                        //DataRow row = ((daojuxinxi.Rows[i]).DataBoundItem as DataRowView).Row;//微软提供的唯一的从DataGridViewRow转换DataRow
                    }
                    else
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
        /// 刀具更换按钮
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

                    //判断刀具是否已经被领用
                    if (dgv_tb.Rows[i]["djwz"].ToString() == null || dgv_tb.Rows[i]["djwz"].ToString() == "")
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
        /// 刀具外借按钮
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
        /// 刀具报废按钮
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

                    //判断刀具是否已经被领用
                    if (dgv_tb.Rows[i]["djwz"].ToString() == null || dgv_tb.Rows[i]["djwz"].ToString() == "")
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
                str = "请先选择要领用的刀具！";
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
        /// 刀具退还按钮
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

                    //判断刀具是否已经被领用
                    if (dgv_tb.Rows[i]["djwz"].ToString() == null || dgv_tb.Rows[i]["djwz"].ToString() == "")
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
            asc.controlAutoSize(this);
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
        #endregion 其他方法结束

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

        /// <summary>
        /// 快捷操作，刀具信息表格双击弹出刀具测量界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daojuxinxi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string id = daojuxinxi.Rows[e.RowIndex].Cells["djid"].Value.ToString();
                DaoJuCanShuXinXi djcs = new DaoJuCanShuXinXi(id);
                djcs.ShowDialog();
            }
        }
        
        /// <summary>
        /// 选择不同生产线，生产线标题和机床排布相应变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //生产线标题变化
            scxmc.Text = treeView2.SelectedNode.Text;

            //机床排布和机床名称变化

        }

        /// <summary>
        /// 刷新按钮,对刀具寿命值进行判断，以对需要提醒的数据突出显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button5_Click(object sender, EventArgs e)
        {
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
                if (shouming > 30 && shouming <= 100)
                {
                    //this.daojuxinxi.Columns[3].DefaultCellStyle.BackColor = Color.Red;
                    daojuxinxi.Rows[i].Cells["djsm"].Style.BackColor = Color.Yellow;
                }
            }
        }

        /// <summary>
        /// 机床点击函数
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

        /// <summary>
        /// checkbox值发生改变时，改变该行背景色。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daojuxinxi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)//表头不发生验证
            {
                if (daojuxinxi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "true")//选中该行
                {
                    daojuxinxi.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Highlight;//背景色高亮
                }
                else if (daojuxinxi.CurrentCell.Value.ToString() == "false")//取消选中该行
                {
                    if(Convert.ToInt16(e.RowIndex) % 2 == 0)//偶数行
                    {
                        daojuxinxi.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.Window;
                    }
                    else//奇数行
                    {
                        daojuxinxi.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gainsboro;
                    }
                }
            }
        }
    }
}
