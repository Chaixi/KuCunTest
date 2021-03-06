﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using kucunTest.BaseClasses;

namespace kucunTest.LingBuJian
{
    public partial class lbj_xzlymx : Form
    {
        #region 全局变量
        MySql SQL = new MySql();
        String Sqlstr = "";

        TreeNode root = new TreeNode();
        string lbj = "lbj_temp";

        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();

        string TYPE = "";

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="type"></param>
        public lbj_xzlymx(string type)
        {
            InitializeComponent();

            TYPE = type;

            switch(type)
            {
                case "LBJLY":
                    break;
                case "LBJTH":
                    break;
            }
        }

        /// <summary>
        /// 重写构造函数，从单据界面到明细编辑界面
        /// </summary>
        /// <param name="type">单据类型，"LBJLY"领用，"LBJTH"退还</param>
        /// <param name="list">需要修改的list数组</param>
        public lbj_xzlymx(string type, DataRow row)
        {

        }

        private void lbj_xzlymx_Load(object sender, EventArgs e)
        {
            root.Text = "所有类型";
            treeView1.Nodes.Add(root);

            Sqlstr = string.Format("SELECT DISTINCT lbjmc FROM {0}", lbj);
            Alex.BindRoot(Sqlstr, root, true);
            treeView1.Nodes[0].Expand();

            asc.controllInitializeSize(this);

            //记载机床编码
            jcbm.DataSource = Alex.GetList("jc");
            //string sqlstr2 = "SELECT jichuangbianma FROM jichuang";
            //jcbm.DataSource = SQL.DataReadList(sqlstr2);
            jcbm.SelectedIndex = -1;

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
                    Sqlstr = string.Format("SELECT lbjxh FROM {0} WHERE lbjmc = '{1}'", lbj, currentNode.Text);
                    Alex.BindRoot(Sqlstr, currentNode, false);
                }
            }
            
        }

        /// <summary>
        /// 选中具体规格，填充到右方文本框中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Level == 2)//当前选中节点为第二层节点：刀具规格
            {
                lbjmc.Text = e.Node.Parent.Text;
                lbjxh.Text = e.Node.Text;

                Sqlstr = string.Format("SELECT * FROM {0} WHERE lbjmc = '{1}' AND lbjxh = '{2}'", lbj, e.Node.Parent.Text.ToString(), e.Node.Text.ToString());
                DataSet ds = SQL.getDataSet(Sqlstr, lbj);

                lbjgg.Text = ds.Tables[0].Rows[0]["lbjgg"].ToString();
                dw.Text = ds.Tables[0].Rows[0]["dw"].ToString();

                string sql = "SELECT kcsl,weizhi,cengshu FROM jichuxinxi where daojuid = '" + lbjmc.Text.ToString() + "' and daojuxinghao = '" + lbjxh.Text.ToString() + "' ";
                MySqlDataReader my = SQL.getcom(sql);
                List<string> list = new List<string>();
                while (my.Read())
                {
                    list.Add(my[0].ToString());
                    list.Add(my[1].ToString());
                    list.Add(my[2].ToString());
                }
                kcsl.Text = list[0];
                djgbm.Text = list[1];
                cfwz.Text = list[2];
            }
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string t1 = "";
            string t2 = "";
            t1 = sl.Text.ToString();
            t2 = kcsl.Text.ToString();
            if (t1 == "")
            {
                MessageBox.Show("请填写需领用零部件的数量！", "警告", MessageBoxButtons.OK);
                return;
            }
            if(Int32.Parse(t1) > Int32.Parse(t2))
            {
                MessageBox.Show("领用零部件的数量大于库存数量，请重新填写！", "警告", MessageBoxButtons.OK);
                return;
            }
            if(Int32.Parse(t1) <= 0)
            {
                MessageBox.Show("请填写正确的领用数量！", "警告", MessageBoxButtons.OK);
                return;
            }


            if (CheckData() == 0)
            {
                return;
            }
            else
            {
                List<string> list = new List<string>();
                list.Add(lbjmc.Text.ToString().Trim());//list[0] 零部件名称
                list.Add(lbjgg.Text.ToString().Trim());//list[1] 零部件规格
                list.Add(lbjxh.Text.ToString().Trim());//list[2] 零部件型号
                list.Add(sl.Text.ToString().Trim());//list[3] 数量
                list.Add(dw.Text.ToString().Trim());//list[3] 单位

                list.Add(jcbm.Text.ToString().Trim());//list[4] 机床编码
                list.Add(gx.Text.ToString().Trim());//list[5] 工序

                if(TYPE == "LBJTH")
                {
                    list.Add(djgbm.Text.ToString().Trim());
                    list.Add(cfwz.Text.ToString().Trim());
                }

                list.Add(bz.Text.ToString().Trim());//list[6] 备注

                switch(TYPE)
                {
                    case "LBJLY":
                        LBJLY ly = new LBJLY();
                        ly = (LBJLY)this.Owner;
                        ly.AddData(list);
                        break;
                    case "LBJTH":
                        LBJTH th = new LBJTH();
                        th = (LBJTH)this.Owner;
                        th.AddData(list);
                        break;
                }
                

                //this.Close();
            }
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 数据验证
        /// </summary>
        /// <returns></returns>
        private int CheckData()
        {
            string tishi = "";
            string t1 = "";
            string t2 = "";
            string t3 = "";

            if (lbjmc.Text.ToString() == "" || lbjxh.Text.ToString() == "")
            {
                tishi = "请将零部件信息填写完整！";
            }
            else
            {
                switch(TYPE)
                {
                    case "LBJLY":
                        t1 = jcbm.Text.ToString();
                        t2 = gx.Text.ToString();
                        t3 = "请将使用信息填写完整！";
                        break;
                    case "LBJTH":
                        t1 = djgbm.Text.ToString();
                        t2 = gx.Text.ToString();
                        t3 = "请将存储信息填写完整！";
                        break;
                }

                if (t1 == "" || t2 == "")
                {
                    tishi = t3;
                }
            }

            if (tishi != "")
            {
                MessageBox.Show(tishi, "警告", MessageBoxButtons.OK);
                return 0;
            }
            else
                return 1;
        }

        private void lbj_xzlymx_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
