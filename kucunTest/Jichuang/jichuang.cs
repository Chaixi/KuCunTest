using MySql.Data.MySqlClient;
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

namespace kucunTest.Jichuang
{
    public partial class jichuang : Form
    {
        public jichuang()
        {
            InitializeComponent();
        }

        #region 全局变量
        private MySql Sql = new MySql();//MySQL类
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private string SqlStr = "";
        string jcbmmc = "";
        private TreeNode node = new TreeNode();//类型树的根节点。
        #endregion

       
        #region BindeRoot()方法和AddChild()方法：构造类型（所有类型-->名称-->型号）树
        ///<summary>生成树之生成第一层名称节点</summary>
        private void BindRoot()
        {
            //treeView1.Nodes.Clear();//清空树节点
          
            MySqlDataReader scx = Sql.getcom("select distinct shengchanxian from jichuang");
            //node.Nodes[0].Remove();//移除刚开始建立的第一个空节点
            while (scx.Read())
            {
                TreeNode t1 = new TreeNode();
                t1.Text = scx[0].ToString();
                node.Nodes.Add(t1);
                AddChild(t1);
            }
      

        }

        private void AddChild(TreeNode t1)
        {
            MySqlDataReader jcbm = Sql.getcom("select jichuangbianma from jichuang where shengchanxian ='" + t1.Text.ToString().Trim() + "'");
            while (jcbm.Read())
            {
                TreeNode t2 = new TreeNode();
                t2.Text = jcbm[0].ToString();
                t1.Nodes.Add(t2);
            }
         
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


        private void jichuang_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);

            node.Nodes.Clear();
            node.Remove();
            treeView1.Nodes.Add(node);
            node.Text = "所有生产线";
            BindRoot();//生成树的第一层
            treeView1.Nodes[0].Expand();//默认展开第一层节点

            jcdth.AutoGenerateColumns = false;
        }



        #region treeView1_AfterSelect()方法：根据选择的树节点进行库存明细查询
        /// <summary>
        /// 根据选择的树节点进行库存明细查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">当前节点</param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            List<string> list1 = new List<string>();
            if (treeView1.SelectedNode.Level == 2)//当前选中节点为第三层节点：机床编码
            {
                string str = "select shengchanxian,jichuangleixing from jichuang where jichuangbianma = '" + e.Node.Text.ToString() + "'";
                list1 = Sql.DataReadList2(str);
                ssscx.Text = list1[0];
                jclx.Text = list1[1];
                jcmc.Text = e.Node.Text.ToString();
                jcbmmc = jcmc.Text + ".jpg";

                SqlStr = "SELECT djtp.daojuleixing,djtp.daojuid,djtp.daojuguige,jcdjk.jichuangbianma,jcdjk.daotaohao FROM jcdaojuku jcdjk LEFT JOIN daojutemp djtp ON concat(djtp.weizhi,'-', djtp.cengshu ) = concat(jcdjk.jichuangbianma,'-', jcdjk.daotaohao ) where jcdjk.jichuangbianma =  '" + e.Node.Text.ToString() + "'";
                
                jcdth.DataSource = Sql.getDataSet1(SqlStr).Tables[0].DefaultView;

                string FileUrl = System.Windows.Forms.Application.StartupPath + "\\Images\\";
                if (File.Exists(FileUrl+jcbmmc) == false)
                {
                    jichuangtupian.Image = null;
                    //MessageBox.Show("请导入机床图片！", "信息提示");
                    return;
                }
                else
                {
                    jichuangtupian.Image = Image.FromFile(FileUrl+jcbmmc);
                }

            }

            }
        #endregion

        private void xzjc_Click(object sender, EventArgs e)
        {
            xinzengjichuang jcxz = new xinzengjichuang();

            jcxz.ShowDialog();
            if(jcxz.DialogResult == DialogResult.OK)
            {
                jichuang_Load(null, null);
            }
        }

        private void jichuang_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        private void jichuang_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Parent != null)
            {
                MainForm mfr = (MainForm)this.Parent.FindForm();
                mfr.CloseTab(this.Name);
            }
        }

        //导入图片
        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog lvse = new OpenFileDialog())
            {
                lvse.Title = "请选择机床图片";
                lvse.InitialDirectory = "";
                lvse.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
                lvse.FilterIndex = 1;

                if (lvse.ShowDialog() == DialogResult.OK)
                {
                    //MySQL_Helper mysql = new MySQL_Helper();
                    //mysql.Record_Insert(MySQL_Helper.base_mode, this.Tag.ToString(), MySQL_Helper.type_operate, "36", "");
                    if (jichuangtupian.Image != null)
                    {
                        Image img = jichuangtupian.Image;
                        jichuangtupian.Image = null;
                        img.Dispose();
                    }
                    Thread.Sleep(200);
                    jichuangtupian.Image = Image.FromFile(lvse.FileName);
                    Picture_Save(jcbmmc);
                }
            }
        }
        //保存图片
        string str_iniFileUrl = System.Windows.Forms.Application.StartupPath + "\\Images\\";
        private void Picture_Save(string filename)
        {
            
            Bitmap bit = new Bitmap(jichuangtupian.ClientRectangle.Width, jichuangtupian.ClientRectangle.Height);
            jichuangtupian.DrawToBitmap(bit, jichuangtupian.ClientRectangle);
            if (Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Images") == false)
            {
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Images");
            }           
            bit.Save(str_iniFileUrl + filename);
          
        }


    }

}
