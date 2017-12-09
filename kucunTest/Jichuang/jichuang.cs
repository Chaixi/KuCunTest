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
        #region 全局变量
        private MySql SQL = new MySql();//MySQL类
        private BaseAlex Alex = new BaseAlex();
        private AutoSizeFormClass asc = new AutoSizeFormClass();

        private string SqlStr = "";
        string jctp = "";//机床图片名称
        string tishi = "";

        string LogType = "机床";
        string LogMessage = "";
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        public jichuang()
        {
            InitializeComponent();

            BindRoot();//生成树的第一层

            //关闭自动生成列
            jichuangdaoku.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jichuang_Load(object sender, EventArgs e)
        {
            //记录窗体初始大小
            asc.controllInitializeSize(this);
        }

        #region BindeRoot()方法和AddChild()方法：构造类型（所有类型-->名称-->型号）树
        ///<summary>生成树之生成第一层名称节点</summary>
        private void BindRoot()
        {
            //刷新时重新建立节点
            if (treeView1.Nodes.Count != 0)
            {
                treeView1.Nodes.Clear();//清空树节点
            }

            TreeNode node = new TreeNode();//类型树的根节点。

            treeView1.Nodes.Add(node);
            node.Text = "机床列表";

            MySqlDataReader scx = SQL.getcom(string.Format("SELECT DISTINCT {1} FROM {0}", JiChuangBiao.TableName, JiChuangBiao.scx));
            //node.Nodes[0].Remove();//移除刚开始建立的第一个空节点

            //lab_progbar.Visible = true;
            //progressBar1.Visible = true;

            //progressBar1.Maximum = scx.Depth;
            //progressBar1.Value = 0;

            while (scx.Read())
            {
                TreeNode t1 = new TreeNode();
                t1.Text = scx[0].ToString();
                node.Nodes.Add(t1);
                AddChild(t1);

                //lab_progbar.Text = (progressBar1.Value * 100 / progressBar1.Maximum).ToString() + "%";//显示百分比
                //progressBar1.Value = progressBar1.Value + 1;
            }

            //lab_progbar.Visible = false;
            //progressBar1.Visible = false;

            //默认展开第一层节点
            treeView1.Nodes[0].Expand();
        }

        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="t1"></param>
        private void AddChild(TreeNode t1)
        {
            MySqlDataReader jcbm = SQL.getcom(string.Format("SELECT {1} FROM {0} WHERE {2} ='{3}'", JiChuangBiao.TableName, JiChuangBiao.jcbm, JiChuangBiao.scx, t1.Text.ToString().Trim()));
            while (jcbm.Read())
            {
                TreeNode t2 = new TreeNode();
                t2.Text = jcbm[0].ToString();
                t1.Nodes.Add(t2);
            }         
        }
        #endregion

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

        #region treeView1_AfterSelect()方法：根据选择的树节点进行库存明细查询
        /// <summary>
        /// 根据选择的树节点进行库存明细查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">当前节点</param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode crtNode = treeView1.SelectedNode;

            if(crtNode.Level == 1)
            {
                crtNode.Expand();
                treeView1.SelectedNode = crtNode.Nodes[0];

                return;
            }

            if (treeView1.SelectedNode.Level == 2)//当前选中节点为第三层节点：机床编码
            {
                SqlStr = string.Format("SELECT {1} AS ssbz, {2} AS ssscx, {3} AS jclx, {4} AS jcmc, {5} AS zcbh FROM {0} WHERE {4} = '{6}'", JiChuangBiao.TableName, JiChuangBiao.ssbz, JiChuangBiao.scx, JiChuangBiao.jclx, JiChuangBiao.jcbm, JiChuangBiao.zcbh, treeView1.SelectedNode.Text.ToString());
                //string str = "select shengchanxian,jichuangleixing from jichuang where jichuangbianma = '" + e.Node.Text.ToString() + "'";
                DataTable db = SQL.getDataSet(SqlStr, JiChuangBiao.TableName).Tables[0];
                SSBZ.Text = db.Rows[0]["ssbz"].ToString();
                SSSCX.Text = db.Rows[0]["ssscx"].ToString();
                JCLX.Text = db.Rows[0]["jclx"].ToString();
                JCMC.Text = db.Rows[0]["jcmc"].ToString();
                ZCBH.Text = db.Rows[0]["zcbh"].ToString();

                jctp = JCMC.Text + ".jpg";

                //加载机床刀具库
                SqlStr = "SELECT djtp.daojuleixing,djtp.daojuid,djtp.daojuguige,jcdjk.jichuangbianma,jcdjk.daotaohao FROM jcdaojuku jcdjk LEFT JOIN daojutemp djtp ON concat(djtp.weizhi,'-', djtp.cengshu ) = concat(jcdjk.jichuangbianma,'-', jcdjk.daotaohao ) where jcdjk.jichuangbianma =  '" + treeView1.SelectedNode.Text.ToString() + "'";

                jichuangdaoku.DataSource = SQL.getDataSet1(SqlStr).Tables[0].DefaultView;

                //加载机床图片
                string FileUrl = System.Windows.Forms.Application.StartupPath + "\\Images\\JiChuang\\";
                if (File.Exists(FileUrl + jctp) == false)
                {
                    jichuangtupian.Image = null;
                    //MessageBox.Show("请导入机床图片！", "信息提示");
                    return;
                }
                else
                {
                    jichuangtupian.Image = Image.FromFile(FileUrl + jctp);
                }
            }

        }
        #endregion

        /// <summary>
        /// 新增机床按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xzjc_Click(object sender, EventArgs e)
        {
            xinzengjichuang jcxz = new xinzengjichuang();

            jcxz.ShowDialog();
            if(jcxz.DialogResult == DialogResult.OK)
            {
                BindRoot();
            }
        }

        /// <summary>
        /// 窗体大小变化自适应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jichuang_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }

        /// <summary>
        /// 在tabpage页中打开则关闭相应tabpage页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jichuang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Alex.CloseFormFromTabpages(this);
        }

        /// <summary>
        /// 导入图片按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if(JCMC.Text == "")
            {
                tishi = "请先选择要删除的机床！";
                MessageBox.Show(tishi);
                return;
            }

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

                    //日志记录
                    LogMessage = string.Format("成功加载{0}的机床图片。", JCMC.Text);
                    Program.WriteLog(LogType, LogMessage);
                    LogMessage = "";

                    Picture_Save(jctp);
                }
            }
        }

        /// <summary>
        /// 保存图片
        /// </summary>      
        private void Picture_Save(string filename)
        {
            Bitmap bit = new Bitmap(jichuangtupian.ClientRectangle.Width, jichuangtupian.ClientRectangle.Height);
            jichuangtupian.DrawToBitmap(bit, jichuangtupian.ClientRectangle);

            //没有文件夹，新建文件夹
            if (Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\Images\\JiChuang") == false)
            {
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\Images\\JiChuang");
            }

            //图片保存：若已存在此命名图片则先删除
            string str_iniFileUrl = System.Windows.Forms.Application.StartupPath + "\\Images\\JiChuang\\";
            if (System.IO.File.Exists(str_iniFileUrl + filename))
            {
                System.IO.File.Delete(str_iniFileUrl + filename);
            }
            bit.Save(str_iniFileUrl + filename);

            //日志记录
            LogMessage = string.Format("成功保存{0}的机床图片到{1}", JCMC.Text, str_iniFileUrl + filename);
            Program.WriteLog(LogType, LogMessage);
            LogMessage = "";
        }

        /// <summary>
        /// 删除机床按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
        {
            tishi = "";

            if(JCMC.Text == "")
            {
                tishi = "请先选择要删除的机床！";
                MessageBox.Show(tishi);
                return;
            }

            tishi = string.Format("确定删除机床：“{0}”？", JCMC.Text);

            string mc = JCMC.Text.ToString();
            int row = 0;

            if (MessageBox.Show(tishi, "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //判断刀具柜是否有存刀具或零部件
                //if(Alex.CunZai(DaoJuGuiCengShu.TableName, string.Format("{0} = '{1}'", DaoJuGuiCengShu.djgmc, mc)) != 0)
                //{
                //从机床刀具库表中删除
                SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", JiChuangDaoJuKu.TableName, JiChuangDaoJuKu.jcbm, mc);
                row = SQL.ExecuteNonQuery(SqlStr);
                //}                

                //从机床表中删除
                SqlStr = string.Format("DELETE FROM {0} WHERE {1} = '{2}'", JiChuangBiao.TableName, JiChuangBiao.jcbm, mc);
                row = SQL.ExecuteNonQuery(SqlStr);

                //删除机床图片
                string str_iniFileUrl = System.Windows.Forms.Application.StartupPath + "\\Images\\JiChuang\\";
                if (System.IO.File.Exists(str_iniFileUrl + mc + ".jpg"))
                {
                    System.IO.File.Delete(mc + ".jpg");
                }

                tishi = "删除成功！";
                
                //日志记录
                LogMessage = string.Format("成功删除机床：{0}", mc);
                Program.WriteLog(LogType, LogMessage);
                LogMessage = "";

                MessageBox.Show(tishi);

                BindRoot();
            }
        }

        /// <summary>
        /// 表格绘制行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void jichuangdaoku_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(jichuangdaoku, e);
        }
    }

}
