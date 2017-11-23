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
using System.IO;
using System.Threading;

namespace kucunTest.DaoJu
{
    public partial class DaoJuLeiXingGuanLi : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        String Sqlstr = "";

        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();
        TreeNode root = new TreeNode();
        TreeNode CrtNode = new TreeNode();

        DataTable lbjmx = new DataTable();//存放零部件明细数据

        string DaoJuBiao = "daoju";//数据表
        string lbj = "lbj_temp";
        string CanShuBiao = "jichucanshu";
        string GuanLianBiao = "daojulingbujian";
        string JiChuCanShu = "jichucanshu";
        string djxhzd = "djxh";//DaoJuBiao数据表字段
        string djlxzd = "djlx";
        string djggzd = "djgg";
        string djtpzd = "djtp";

        string DJPIC = "";
        string picmc = "";
        string str_iniFileUrl = System.Windows.Forms.Application.StartupPath + "\\Images\\DaoJuLeiXing\\";

        string conditions = "";//数据库查询条件，用于Alex.CunZai()
        bool HaveNewNode = false;

        #endregion

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public DaoJuLeiXingGuanLi()
        {
            InitializeComponent();

            //加载前都先清空,避免重复加载
            treeView1.Nodes.Clear();

            root.Text = "所有类型";
            treeView1.Nodes.Add(root);

            Sqlstr = string.Format("SELECT DISTINCT {0} FROM {1}", djlxzd, DaoJuBiao);
            Alex.BindRoot(Sqlstr, root, true);

            treeView1.Nodes[0].Expand();

            //所有单位加载默认值
            foreach (Control c in grp_cs.Controls)
            {
                if (c is ComboBox)
                {
                    ComboBox cb = (ComboBox)c;
                    cb.SelectedIndex = 0;
                }
                else
                {
                    continue;
                }
            }

            //加载零部件列表
            cbx_lbjmc.DataSource = Alex.GetList("lbjmc");
            cbx_lbjmc.SelectedIndex = -1;

            //为lbjmx表添加列
            lbjmx.Columns.Add("lbjmc", System.Type.GetType("System.String"));
            lbjmx.Columns.Add("lbjgg", System.Type.GetType("System.String"));
            lbjmx.Columns.Add("lbjxh", System.Type.GetType("System.String"));
            lbjmx.Columns.Add("sl", System.Type.GetType("System.Int32"));
            lbjmx.Columns.Add("dw", System.Type.GetType("System.String"));
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DaoJuLeiXingGuanLi_Load(object sender, EventArgs e)
        {         
            asc.controllInitializeSize(this);          
        }

        /// <summary>
        /// 在展开类型节点之前查询所有规格的子节点，按需查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //只对第一层节点“刀具类型”生成子节点
            if(e.Node.Level == 1)
            {
                if (e.Node.Nodes[0].Text == "")
                {
                    TreeNode currentNode = e.Node;
                    currentNode.Nodes[0].Remove();
                    Sqlstr = string.Format("SELECT {0} FROM {1} WHERE {2} = '{3}'", djxhzd, DaoJuBiao, djlxzd, currentNode.Text);
                    Alex.BindRoot(Sqlstr, currentNode, false);
                }
            }
        }

        /// <summary>
        /// 选中具体规格后加载刀具信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //清空历史值以加载新数据或空白数据
            Alex.ClearText(this);
            ZuChengMingXi.DataSource = null;

            if(e.Node.Tag != null && e.Node.Tag.ToString() == "new")
            {
                if(e.Node.Level == 2)
                {
                    DJLX.Text = e.Node.Parent.Text;
                    DJLX.Enabled = false;
                }
                return;
            }
            else
            {
                if(e.Node.Level == 1)
                {
                    DJLX.Text = e.Node.Text;                   
                    pic_dj.Image = null;               
                }
                else if (e.Node.Level == 2)
                {
                    //加载刀具基础信息:刀具类型，刀具规格，刀具型号/工装编号
                    Sqlstr = string.Format("SELECT {0}, {1}, {2}, {3} FROM {4} WHERE {5} = '{6}'", djlxzd, djggzd, djxhzd, djtpzd, DaoJuBiao, djxhzd, e.Node.Text);
                    DataTable db1 = SQL.getDataSet(Sqlstr, DaoJuBiao).Tables[0];
                    DJLX.Text = db1.Rows[0][djlxzd].ToString();
                    DJGG.Text = db1.Rows[0][djggzd].ToString();
                    DJXH.Text = db1.Rows[0][djxhzd].ToString();

                    //加载图片
                    picmc = DJXH.Text + ".jpg";
                    if (File.Exists(str_iniFileUrl + picmc) == false)
                    {
                        pic_dj.Image = null;
                        //MessageBox.Show("请导入机床图片！", "信息提示");
                    }
                    else
                    {
                        pic_dj.Image = Image.FromFile(str_iniFileUrl + picmc);
                    }

                    //加载刀具参数信息
                    Sqlstr = string.Format("SELECT csdm, csz FROM {0} WHERE ssfm = '{1}'", CanShuBiao, DJXH.Text);
                    DataTable db2 = SQL.getDataSet(Sqlstr, CanShuBiao).Tables[0];

                    //赋值
                    if (db2.Rows.Count > 0)
                    {
                        //基础信息中的部分参数
                        foreach (Control tb in grp_jc.Controls)
                        {
                            if (tb is TextBox)
                            {
                                for (int i = 0; i < db2.Rows.Count; i++)
                                {
                                    if (db2.Rows[i]["csdm"].ToString() == tb.Name)
                                    {
                                        tb.Text = db2.Rows[i]["csz"].ToString();
                                        //db2.Rows.Remove(db2.Rows[i]);
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        //参数信息中的部分参数
                        foreach (Control tb in grp_cs.Controls)
                        {
                            if (tb is TextBox)
                            {
                                for (int i = 0; i < db2.Rows.Count; i++)
                                {
                                    if (db2.Rows[i]["csdm"].ToString() == tb.Name)
                                    {
                                        tb.Text = db2.Rows[i]["csz"].ToString();
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }

                    //加载零部件信息
                    Sqlstr = string.Format("SELECT gl.lbjmc, gl.lbjxh, gl.lbjgg, gl.sl, gl.dw FROM daojulingbujian gl WHERE gl.djxh = '{0}'", DJXH.Text.ToString());
                    //Sqlstr = string.Format("SELECT * FROM {0} WHERE djxh = '{1}'", GuanLianBiao, DJXH.Text);
                    lbjmx = SQL.getDataSet(Sqlstr, GuanLianBiao).Tables[0].Copy();
                    ZuChengMingXi.AutoGenerateColumns = false;
                    ZuChengMingXi.DataSource = lbjmx.DefaultView;
                }
            }
        }

        /// <summary>
        /// 为datagridview生成行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZuChengMingXi_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(ZuChengMingXi, e);
        }

        #region 树右键菜单部分
        /// <summary>
        /// 鼠标右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if(e.Node.Level < 2)
                {
                    添加ToolStripMenuItem.Visible = true;
                    e.Node.ContextMenuStrip = contextMenuStrip1;
                }
                else
                {
                    添加ToolStripMenuItem.Visible = false;
                    e.Node.ContextMenuStrip = contextMenuStrip1;
                }
            }
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrtNode = treeView1.SelectedNode;
            TreeNode NewNode = new TreeNode();

            if(CrtNode.Level == 0)
            {
                NewNode.Text = "新类型";
                NewNode.Tag = "new";
            }
            else if(CrtNode.Level == 1)
            {
                NewNode.Text = "新规格";
                NewNode.Tag = "new";
            }
            NewNode.BackColor = Color.AntiqueWhite;
            CrtNode.Nodes.Add(NewNode);

            DJLX.Enabled = true;
            DJGG.Enabled = true;
            DJXH.Enabled = true;

            treeView1.SelectedNode = NewNode;
        }

        /// <summary>
        /// 展开全部菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 展开全部类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }

        /// <summary>
        /// 收起全部菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 收起全部类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CrtNode = treeView1.SelectedNode;

            string tishi = "";
            string Sqlstr1 = "";
            int row = 0;
            switch (CrtNode.Level.ToString())
            {
                case "1"://删除整个类型
                    tishi = "确定要删除" + CrtNode.Text.ToString() + "以及" + CrtNode.Text.ToString() + "下所有规格？";
                    Sqlstr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", DaoJuBiao, djlxzd, CrtNode.Text);
                    break;
                case "2"://删除某一规格
                    tishi = "确定要删除" + CrtNode.Text.ToString() + "？";
                    Sqlstr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", DaoJuBiao, djxhzd, CrtNode.Text);
                    break;
            }

            if (MessageBox.Show(tishi, "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //要先删除已存在的基础参数表中记录
                switch(CrtNode.Level.ToString())
                {
                    case "1":
                        if (SQL.ExecuteScalar(string.Format("SELECT COUNT(*) FROM {0} jccs LEFT JOIN {1} dj ON jccs.ssfm = dj.djxh WHERE dj.djlx = '{2}'", JiChuCanShu, DaoJuBiao, CrtNode.Text)).ToString() != "0")
                        {
                            Sqlstr1 = string.Format("DELETE jccs FROM {0} jccs LEFT JOIN {1} dj ON jccs.ssfm = dj.djxh WHERE dj.djlx = '{2}'", JiChuCanShu, DaoJuBiao, CrtNode.Text);
                            row = SQL.ExecuteNonQuery(Sqlstr1);
                        }
                        break;
                    case "2":
                        if (SQL.ExecuteScalar(string.Format("SELECT COUNT(*) FROM {0} WHERE ssfm = '{1}'", JiChuCanShu, CrtNode.Text)).ToString() != "0")
                        {
                            Sqlstr1 = string.Format("DELETE FROM {0} WHERE ssfm = '{1}'", JiChuCanShu, CrtNode.Text);
                            row = SQL.ExecuteNonQuery(Sqlstr1);
                        }
                        break;
                }

                //再从刀具类型数据库表中删除
                int rows = SQL.ExecuteNonQuery(Sqlstr);
                Sqlstr = "";

                //树中移除
                treeView1.Nodes.Remove(CrtNode);
            }
        }

        #endregion 树右键菜单部分结束

        #region 按钮部分
        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            //判断是否是新类型OR新规格,若是，则先保存新类型

            //数据格式化        
            string djlx = DJLX.Text.ToString();
            string djgg = DJGG.Text.ToString();
            string djxh = DJXH.Text.ToString();
            conditions = string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'", djlxzd, djlx, djggzd, djgg, djxhzd, djxh);
            if (djlx != "" && djgg != "" && djxh != "")
            {
                if (Alex.CunZai(DaoJuBiao, conditions) == 0)//新类型OR新规格
                {
                    //存入数据库
                    Sqlstr = string.Format("INSERT INTO {0}({1}, {2}, {3}, {4}) VALUES('{5}', '{6}', '{7}', '{8}')", DaoJuBiao, djlxzd, djggzd, djxhzd, djtpzd, djlx, djgg, djxh, DJPIC);
                    int row1 = SQL.ExecuteNonQuery(Sqlstr);
                    HaveNewNode = true;
                }
                //else
                //{
                //    //更新图片
                //    Sqlstr = string.Format("UPDATE {0} SET {1} = '{2}' WHERE {3} = '{4}'", DaoJuBiao, djtpzd, DJPIC, djxhzd, djxh);
                //    int row1 = SQL.ExecuteNonQuery(Sqlstr);

                //    HaveNewNode = true;
                //}
            }
            else
            {
                MessageBox.Show("请将刀具类型、刀具规格、刀具型号填写完整！", "提示");
                return;
            }

            //数据格式化，存入datatable
            DataTable tb = new DataTable();
            tb.Columns.Add("csdm", Type.GetType("System.String"));
            tb.Columns.Add("csz", Type.GetType("System.String"));
            tb.Columns.Add("ssfm", Type.GetType("System.String"));

            //基础信息中的部分参数
            foreach (Control cp1 in grp_jc.Controls)
            {
                if (cp1 is TextBox)
                {
                    if(cp1.Name == DJLX.Name || cp1.Name == DJGG.Name || cp1.Name == DJXH.Name)
                    {
                        continue;
                    }
                    else
                    {
                        DataRow row = tb.NewRow();
                        row["csdm"] = cp1.Name.ToString();
                        row["csz"] = cp1.Text.ToString();
                        row["ssfm"] = DJXH.Text.ToString();
                        tb.Rows.Add(row);
                    }
                }
                else
                {
                    continue;
                }
            }
            //参数信息中的部分参数
            foreach (Control cp2 in grp_cs.Controls)
            {
                if (cp2 is TextBox)
                {
                    if (cp2.Name == "djlx" || cp2.Name == "djgg" || cp2.Name == "djxh")
                    {
                        continue;
                    }
                    else
                    {
                        DataRow row = tb.NewRow();
                        row["csdm"] = cp2.Name.ToString();
                        row["csz"] = cp2.Text.ToString();
                        row["ssfm"] = DJXH.Text.ToString();
                        tb.Rows.Add(row);
                    }
                }
                else
                {
                    continue;
                }
            }

            //将整个datatable存入数据库
            for(int i = 0; i < tb.Rows.Count; i++)
            {
                string csdm = tb.Rows[i]["csdm"].ToString();
                string csz = tb.Rows[i]["csz"].ToString();
                string ssfm = tb.Rows[i]["ssfm"].ToString();
                string conditions = string.Format("ssfm = '{0}' AND csdm = '{1}'", ssfm, csdm);
                if (Alex.CunZai(JiChuCanShu, conditions) != 0)
                {
                    Sqlstr = string.Format("UPDATE {0} SET csz = '{1}' WHERE " + conditions, JiChuCanShu, csz);
                }
                else
                {
                    Sqlstr = string.Format("INSERT INTO {0}(csdm, csz, ssfm) VALUES('{1}', '{2}', '{3}')", JiChuCanShu, csdm, csz, ssfm);
                }
                int rows = SQL.ExecuteNonQuery(Sqlstr);
            }

            //零部件明细表存入数据库
            for(int rowindex = 0; rowindex < ZuChengMingXi.Rows.Count; rowindex++)
            {
                //数据预处理
                string lbjmc = ZuChengMingXi.Rows[rowindex].Cells["lbjmc"].Value.ToString();
                string lbjgg = ZuChengMingXi.Rows[rowindex].Cells["lbjgg"].Value.ToString();
                string lbjxh = ZuChengMingXi.Rows[rowindex].Cells["lbjxh"].Value.ToString();
                string sl = ZuChengMingXi.Rows[rowindex].Cells["sl"].Value.ToString();
                string dw = ZuChengMingXi.Rows[rowindex].Cells["dw"].Value.ToString();

                //存入数据库
                Sqlstr = string.Format("INSERT INTO {0}({1}, {2}, {3}, {4}, {5}, {6}, {7}) VALUES({8}, {9}, {10}, {11}, {12}, {13}, {14})", DaoJuLingBuJian.TableName, DaoJuLingBuJian.djlx, DaoJuLingBuJian.djxh, DaoJuLingBuJian.lbjmc, DaoJuLingBuJian.lbjgg, DaoJuLingBuJian.lbjxh, DaoJuLingBuJian.sl, DaoJuLingBuJian.dw, djlx, djxh, lbjmc, lbjgg, lbjxh, sl, dw);

                int rows = SQL.ExecuteNonQuery(Sqlstr);
            }

            MessageBox.Show("保存成功！");
            CrtNode = treeView1.SelectedNode;

            if(HaveNewNode)
            {
                if(CrtNode.Level == 1)
                {
                    CrtNode.Text = DJLX.Text;
                    TreeNode NewGG = new TreeNode(DJXH.Text);
                    CrtNode.Nodes.Add(NewGG);
                }
                else if(CrtNode.Level == 2)
                {
                    CrtNode.Text = DJXH.Text;
                }
                CrtNode.BackColor = treeView1.Nodes[0].BackColor;
                CrtNode.Tag = null;
                HaveNewNode = false;

                DJLX.Enabled = false;
                DJGG.Enabled = false;
                DJXH.Enabled = false;
            }
            treeView1.SelectedNode = CrtNode;
        }

        /// <summary>
        /// 保存为新类型按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cansel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 选择刀具图片按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       // private void button1_Click(object sender, EventArgs e)
       // {
            //OpenFileDialog openfile = new OpenFileDialog();
           // openfile.Title = " 请选择刀具图片";
           // openfile.Filter = "图片格式 (*.jpg;*.bmp;*png)|*.jpeg;*.jpg;*.bmp;*.png|AllFiles(*.*)|*.*";
           // openfile.Multiselect = false;
           // if (openfile.ShowDialog() == DialogResult.OK)
           // {
               // try
               // {
                   // Bitmap bmp = new Bitmap(openfile.FileName);
                   // pic_dj.Image = bmp;
                   // MemoryStream ms = new MemoryStream();
                   // bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                   // byte[] arr = new byte[ms.Length];
                   // ms.Position = 0;
                   // ms.Read(arr, 0, (int)ms.Length);
                   // ms.Close();
                    // 直接返这个值放到数据就行了
                  //  DJPIC  = Convert.ToBase64String(arr);
              //  }
                //catch { }
          //  }

           // button1.Visible = false;
       // }


        #endregion 按钮部分结束

        private void DaoJuLeiXingGuanLi_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);
        }

        /// <summary>
        /// 当窗体在选项卡中打开时，关闭窗体则关闭相应的选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DaoJuLeiXingGuanLi_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Parent != null)
            {
                MainForm mfr = (MainForm)this.Parent.FindForm();
                mfr.CloseTab(this.Name);
            }
        }

        /// <summary>
        /// 导入图片按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {

            if (DJXH.Text == "")
            {
                MessageBox.Show("请先填写刀具型号");
                return;
            }

            using (OpenFileDialog lvse = new OpenFileDialog())
            {
                lvse.Title = "请选择刀具图片";
                lvse.InitialDirectory = "";
                lvse.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
                lvse.FilterIndex = 1;

                if (lvse.ShowDialog() == DialogResult.OK)
                {
                    //MySQL_Helper mysql = new MySQL_Helper();
                    //mysql.Record_Insert(MySQL_Helper.base_mode, this.Tag.ToString(), MySQL_Helper.type_operate, "36", "");
                    if (pic_dj.Image != null)
                    {
                        Image img = pic_dj.Image;
                        pic_dj.Image = null;
                        img.Dispose();
                    }
                    Thread.Sleep(200);
                    pic_dj.Image = Image.FromFile(lvse.FileName);
                    Picture_Save(picmc);
                }
            }
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="filename"></param>
        private void Picture_Save(string filename)
        {
            Bitmap bit = new Bitmap(pic_dj.ClientRectangle.Width, pic_dj.ClientRectangle.Height);
            pic_dj.DrawToBitmap(bit, pic_dj.ClientRectangle);

            //没有文件夹，新建文件夹
            if (Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Images\\DaoJuLeiXing") == false)
            {
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Images\\DaoJuLeiXing");
            }

            //图片保存：若已存在此命名图片则先删除
            if (System.IO.File.Exists(str_iniFileUrl + filename))
            {
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Images\\daojuleixing");
            }

            bit.Save(str_iniFileUrl + filename);

        }

        /// <summary>
        /// 刀具组成明细新增按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (DJLX.Text == "" && DJXH.Text == "")
            {
                MessageBox.Show("请填写刀具类型或刀具型号！");
                DJLX.Focus();

                return;
            }
            if (cbx_lbjmc.Text == "")
            {
                MessageBox.Show("请先选择要添加的零部件名称！");
                cbx_lbjmc.DroppedDown = true;

                return;
            }

            if (cbx_lbjxh.Text == "")
            {
                MessageBox.Show("请先选择要添加的零部件型号！");
                cbx_lbjxh.DroppedDown = true;

                return;
            }

            if (sxsl.Text == "" || Convert.ToInt32(sxsl.Text) < 0 || Convert.ToInt32(sxsl.Text) > 50)
            {
                MessageBox.Show("请填写装配刀具“" + DJXH.Text + "”所需要的“" + cbx_lbjxh.Text + "”的数量！\n注：填写数量为1-50的整数。");
                sxsl.Focus();
                sxsl.SelectAll();

                return;
            }

            DataRow row = lbjmx.NewRow();

            row["lbjmc"] = cbx_lbjmc.Text;
            row["lbjgg"] = cbx_lbjgg.Text;
            row["lbjxh"] = cbx_lbjxh.Text;
            row["sl"] = Convert.ToInt32(sxsl.Text);
            row["dw"] = textbox_dw.Text;

            lbjmx.Rows.Add(row);
            ZuChengMingXi.DataSource = lbjmx.DefaultView;

            //DataGridViewRow row = new DataGridViewRow();
            //row.CreateCells(ZuChengMingXi);

            //row.Cells[0].Value = cbx_lbjmc.Text;
            //row.Cells[1].Value = cbx_lbjgg.Text;
            //row.Cells[2].Value = cbx_lbjxh.Text;
            //row.Cells[3].Value = sxsl.Text;
            //row.Cells[4].Value = textbox_dw.Text;

            //ZuChengMingXi.Rows.Add(row);
        }

        /// <summary>
        /// 刀具组成明细删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if(ZuChengMingXi.CurrentRow == null || ZuChengMingXi.CurrentRow.Index < 0)
            {
                MessageBox.Show("请先选择要删除的数据行！");

                return;
            }

            //移除选中行
            ZuChengMingXi.Rows.RemoveAt(ZuChengMingXi.CurrentRow.Index);
        }

        /// <summary>
        /// 选中零部件数据行加载零部件图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZuChengMingXi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //加载零部件图片，如果存在的话
                string lbjxh = ZuChengMingXi.Rows[e.RowIndex].Cells["lbjxh"].Value.ToString();
                LoadLBJPic(lbjxh);                

                //填充右侧数据块
                cbx_lbjmc.Text = ZuChengMingXi.Rows[e.RowIndex].Cells["lbjmc"].Value.ToString();
                cbx_lbjgg.Text = ZuChengMingXi.Rows[e.RowIndex].Cells["lbjgg"].Value.ToString();
                cbx_lbjxh.Text = ZuChengMingXi.Rows[e.RowIndex].Cells["lbjxh"].Value.ToString();
                sxsl.Text = ZuChengMingXi.Rows[e.RowIndex].Cells["sl"].Value.ToString();
                textbox_dw.Text = ZuChengMingXi.Rows[e.RowIndex].Cells["dw"].Value.ToString();
            }
        }

        /// <summary>
        /// 根据零部件型号加载零部件图片，如果存在的话
        /// </summary>
        /// <param name="lbjxh">要加载图片的零部件型号</param>
        private void LoadLBJPic(string lbjxh)
        {
            string filename = lbjxh + ".jpg";
            string FileUrl = System.Windows.Forms.Application.StartupPath + "\\Images\\LingBuJian\\";

            if (File.Exists(FileUrl + filename))
            {
                pic_lbj.Image = Image.FromFile(FileUrl + filename);
            }
            else
            {
                pic_lbj.Image = null;
            }
        }

        /// <summary>
        /// 零部件名称选择变化，加载相应的零部件规格和型号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_lbjmc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbx_lbjmc.SelectedIndex < 0)
            {
                cbx_lbjgg.DataSource = null;
                cbx_lbjxh.DataSource = null;

                return;
            }

            Sqlstr = string.Format("SELECT {1} AS lbjgg, {2} AS lbjxh, {3} AS dw FROM {0} WHERE {4} = '{5}'", LingBuJianBiao.TableName, LingBuJianBiao.gg, LingBuJianBiao.xinghao, LingBuJianBiao.dw, LingBuJianBiao.mc, cbx_lbjmc.Text);
            DataTable db = SQL.getDataSet(Sqlstr, LingBuJianBiao.TableName).Tables[0];
            DataTable db1 = db.Copy();

            cbx_lbjgg.DataSource = db;
            cbx_lbjgg.DisplayMember = "lbjgg";
            cbx_lbjgg.SelectedIndex = -1;

            cbx_lbjxh.DataSource = db1;
            cbx_lbjxh.DisplayMember = "lbjxh";
            cbx_lbjxh.ValueMember = "dw";
            cbx_lbjxh.SelectedIndex = -1;
        }

        /// <summary>
        /// 零部件型号选择变化加载相应图片和单位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_lbjxh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbx_lbjxh.SelectedIndex < 0)
            {
                pic_lbj.Image = null;
                textbox_dw.Text = "";

                return;
            }

            string xh = cbx_lbjxh.Text.ToString();
            textbox_dw.Text = cbx_lbjxh.SelectedValue.ToString();

            LoadLBJPic(xh);
        }
    }
}
