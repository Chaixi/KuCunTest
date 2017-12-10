using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

using kucunTest.BaseClasses;
using kucunTest.DaoJu;
using kucunTest.Daojugui;
using kucunTest.LingBuJian;
using kucunTest.Jichuang;
using kucunTest.gongyika;
using kucunTest.JiChuZiLiao;
using kucunTest.XiTongGuanLi;

namespace kucunTest.quanxianguanli
{
    class Authorize
    {
        #region 全局变量
        private MySql SQL = new MySql();
        private string SqlStr = "";

        private BaseAlex Alex = new BaseAlex();
        private string username = "";//当前登录用户名
        private string crtUserGroup = "";//当前用户名所属权限小组

        #endregion 全局变量结束

        public void setAuthority(object frm, string frmName)
        {
            username = MySql.Login_Name;

            //SqlStr = string.Format("SELECT u.{1} FROM `{0}` u WHERE u.`{2}` = '{3}'", User.TableName, User.groupName, User.name, username);
            //crtUserGroup = SQL.getDataSet(SqlStr, User.TableName).Tables[0].Rows[0][User.groupName].ToString();

            //根据窗体名进行相应的权限设置
            switch(frmName)
            {
                case "MainForm":
                    MainForm mainFrm = (MainForm)frm;
                    setMainForm(mainFrm);
                    break;
                case "DaoJuGuanLi":
                    DaoJuGuanLi djglFrm = (DaoJuGuanLi)frm;
                    setDaoJuGuanLiForm(djglFrm);
                    break;
                case "djly":
                    DJLY djlyFrm = (DJLY)frm;
                    setDJLYForm(djlyFrm);
                    break;
                case "djxy":
                    DJXY djxyFrm = (DJXY)frm;
                    setDJXYForm(djxyFrm);
                    break;
                case "djgh":
                    DJGH djghFrm = (DJGH)frm;
                    setDJGHForm(djghFrm);
                    break;
                case "djwj":
                    DJWJ djwjFrm = (DJWJ)frm;
                    setDJWJForm(djwjFrm);
                    break;
                case "djth":
                    DJTH djthFrm = (DJTH)frm;
                    setDJTHForm(djthFrm);
                    break;
                case "djbf":
                    DJBF djbfFrm = (DJBF)frm;
                    setDJBFForm(djbfFrm);
                    break;
                case "dj_djbf_djlsjl":
                    DJBFHistory djbfHistoryFrm = (DJBFHistory)frm;
                    setDJBFHistoryForm(djbfHistoryFrm);
                    break;
                case "djcl":
                    DaoJuCanShuXinXi djclFrm = (DaoJuCanShuXinXi)frm;
                    setDJCLForm(djclFrm);
                    break;
                case "lbjgl"://零部件管理
                    lbj_GuanLi lbjglFrm = (lbj_GuanLi)frm;
                    setLBJGLForm(lbjglFrm);
                    break;
                case "lbjly"://零部件零用单据
                    LBJLY lbjlyFrm = (LBJLY)frm;
                    setLBJLYForm(lbjlyFrm);
                    break;
                case "lbjth"://零部件退还单据
                    LBJTH lbjthFrm = (LBJTH)frm;
                    setLBJTHForm(lbjthFrm);
                    break;

                case "djg"://刀具柜
                    daojugui djgFrm =(daojugui)frm;
                    setDJGForm(djgFrm);
                    break;
                case "jc"://机床
                    jichuang jcFrm = (jichuang)frm;
                    setJCForm(jcFrm);
                    break;
                case "gyk"://工艺卡
                    gyk gykFrm = (gyk)frm;
                    setGYKForm(gykFrm);
                    break;
                case "sjdrdc"://数据导入导出
                    shujudaorudaochu sjdrdcFrm = (shujudaorudaochu)frm;
                    setSJDRDCForm(sjdrdcFrm);
                    break;
                case "qxgl"://权限管理
                    qxguanli qxglFrm = (qxguanli)frm;
                    setQXGLForm(qxglFrm);
                    break;
                case "xtrz"://系统日志
                    Log logFrm = (Log)frm;
                    setXTRZForm(logFrm);
                    break;
            }
        }

        /// <summary>
        /// 从已加载的权限表中判断制定权限代码的相应状态
        /// </summary>
        /// <param name="qxdb">已加载的权限表</param>
        /// <param name="qxdm">要查找的权限代码</param>
        /// <param name="like">是否启用LIKE关键字，若启用，只要有以qxdm开头的数据存在则返回true，适用于子节点为全部选中但也要启用的状态，默认不启用</param>
        /// <returns></returns>
        private bool AuthorityState(DataTable qxdb, string qxdm, string qxfm, bool like = false)
        {
            //判断是否有启用以权限代码开头的项
            if(like)
            {
                string str = string.Format("{0} LIKE '{1}%'  AND {2} LIKE '{3}%' AND {4} = '{5}'", QuanXian.dm, qxdm, QuanXian.fm, qxfm, QuanXian.zt, '1');
                if (qxdm == "dj")
                {
                    str += string.Format(" AND {0} NOT LIKE '{1}%'", QuanXian.dm, "djg");
                }
                if (qxdm == "jc")
                {
                    str += string.Format(" AND {0} NOT LIKE '{1}%'", QuanXian.dm, "jczl");
                }

                if (qxdb.Select(str).Count<DataRow>() != 0)
                    return true;
                else
                {
                    return false;
                }
            }

            //判断此权限代码是否存在
            if (qxdb.Select(string.Format("{0} = '{1}' AND {2} = '{3}'", QuanXian.dm, qxdm, QuanXian.fm, qxfm)).Count<DataRow>() == 0)
            {
                return true;
            }
            else
            {
                return Convert.ToBoolean(qxdb.Select(string.Format("{0} = '{1}'  AND {2} = '{3}'", QuanXian.dm, qxdm, QuanXian.fm, qxfm))[0][1]);
            }
        }

        /// <summary>
        /// 主窗体权限设置
        /// </summary>
        /// <param name="frm"></param>
        private void setMainForm(MainForm frm)
        {
            //SqlStr = string.Format("SELECT qxdm, qxzt FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' ) AND g.{6} = '{7}'", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username, QuanXian.fm, AuthoritiesString.MainMenu.AllAuthorities);
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if(AuthorityState(db, AuthoritiesString.MainMenu.AllAuthorities, AuthoritiesString.MainMenu.AllAuthorities))
            {
                return;
            }

            #region 刀具：8项子菜单，其中刀具类型管理直接判断，刀具管理根据单据状态判断，单据根据单据下按钮判断
            if (!AuthorityState(db, AuthoritiesString.MainMenu.dj, AuthoritiesString.MainMenu.AllAuthorities))
            {
                int i = 0;

                if(!AuthorityState(db, AuthoritiesString.DJGLForm.djly, AuthoritiesString.MainMenu.dj, true))
                {
                    frm.tsmi_dj_djlyd.Enabled = false;
                    frm.linkLabel_djly.Enabled = false;
                    i++;
                }
                if (!AuthorityState(db, AuthoritiesString.DJGLForm.djxy, AuthoritiesString.MainMenu.dj, true))
                {
                    frm.tsmi_dj_djxyd.Enabled = false;
                    i++;
                }
                if (!AuthorityState(db, AuthoritiesString.DJGLForm.djgh, AuthoritiesString.MainMenu.dj, true))
                {
                    frm.tsmi_dj_djghd.Enabled = false;
                    i++;
                }
                if (!AuthorityState(db, AuthoritiesString.DJGLForm.djwj, AuthoritiesString.MainMenu.dj, true))
                {
                    frm.tsmi_dj_djwjd.Enabled = false;
                    i++;
                }
                if (!AuthorityState(db, AuthoritiesString.DJGLForm.djth, AuthoritiesString.MainMenu.dj, true))
                {
                    frm.tsmi_dj_djthd.Enabled = false;
                    i++;
                }
                if (!AuthorityState(db, AuthoritiesString.DJGLForm.djbf, AuthoritiesString.MainMenu.dj, true))
                {
                    frm.tsmi_dj_djbfd.Enabled = false;
                    i++;
                }
                if(!AuthorityState(db, AuthoritiesString.DJGLForm.lxgl, AuthoritiesString.MainMenu.dj))
                {
                    frm.tsmi_dj_djlxgl.Enabled = false;
                    i++;
                }

                if (i == 7)
                {
                    frm.tsmi_dj.Enabled = false;
                    frm.linkLabel_djgl.Enabled = false;
                    frm.linkLabel_djly.Enabled = false;
                }
            }
            #endregion 刀具菜单结束



            #region 零部件：4项子菜单，其中零部件类型管理直接判断，单据管理根据单据状态判断，单据根据单据下按钮判断
            if (!AuthorityState(db, AuthoritiesString.MainMenu.lbj, AuthoritiesString.MainMenu.AllAuthorities))
            {
                int i = 0;

                if (!AuthorityState(db, AuthoritiesString.LBJGLForm.lbjly, AuthoritiesString.MainMenu.lbj, true))
                {
                    frm.tsmi_lbj_lbjyld.Enabled = false;
                    frm.linkLabel_xhply.Enabled = false;
                    i++;
                }
                if (!AuthorityState(db, AuthoritiesString.LBJGLForm.lbjth, AuthoritiesString.MainMenu.lbj, true))
                {
                    frm.tsmi_lbj_lbjthd.Enabled = false;
                    i++;
                }
                if (!AuthorityState(db, AuthoritiesString.LBJGLForm.lxgl, AuthoritiesString.MainMenu.lbj, true))
                {
                    frm.tsmi_lbj_lbjlxgl.Enabled = false;
                    i++;
                }
                
                if(i == 3)
                {
                    frm.tsmi_lbj.Enabled = false;
                    frm.linkLabel_lbjgl.Enabled = false;
                    frm.linkLabel_xhply.Enabled = false;
                }
            }
            #endregion 零部件菜单结束



            #region 刀具柜：4项子菜单，其中零部件类型管理直接判断，单据管理根据单据状态判断，单据根据单据下按钮判断
            if (!AuthorityState(db, AuthoritiesString.MainMenu.djg, AuthoritiesString.MainMenu.AllAuthorities, true))
            {
                if(!AuthorityState(db, AuthoritiesString.MainMenu.djg, AuthoritiesString.MainMenu.djg, true))
                {
                    frm.tsmi_djg.Enabled = false;
                }
            }
            #endregion 刀具柜菜单结束



            #region 机床：4项子菜单，其中零部件类型管理直接判断，单据管理根据单据状态判断，单据根据单据下按钮判断
            if (!AuthorityState(db, AuthoritiesString.MainMenu.jc, AuthoritiesString.MainMenu.AllAuthorities, true))
            {
                if (!AuthorityState(db, AuthoritiesString.MainMenu.jc, AuthoritiesString.MainMenu.jc, true))
                {
                    frm.tsmi_jc.Enabled = false;
                }
            }
            #endregion 机床菜单结束



            #region 工艺卡：4项子菜单，其中零部件类型管理直接判断，单据管理根据单据状态判断，单据根据单据下按钮判断
            if (!AuthorityState(db, AuthoritiesString.MainMenu.gyk, AuthoritiesString.MainMenu.AllAuthorities, true))
            {
                if (!AuthorityState(db, AuthoritiesString.MainMenu.gyk, AuthoritiesString.MainMenu.gyk, true))
                {
                    frm.tsmi_gyk.Enabled = false;
                }
            }
            #endregion 工艺卡菜单结束



            #region 基础资料：4项子菜单，其中零部件类型管理直接判断，单据管理根据单据状态判断，单据根据单据下按钮判断
            if (!AuthorityState(db, AuthoritiesString.MainMenu.jczl, AuthoritiesString.MainMenu.AllAuthorities))
            {
                if (!AuthorityState(db, AuthoritiesString.SJDRDCForm.AllAuthorities, AuthoritiesString.SJDRDCForm.AllAuthorities, true))
                {
                    frm.tsmi_jczl.Enabled = false;
                }
            }
            #endregion 基础资料菜单结束



            #region 系统管理：4项子菜单，其中零部件类型管理直接判断，单据管理根据单据状态判断，单据根据单据下按钮判断
            if (!AuthorityState(db, AuthoritiesString.MainMenu.xtgl, AuthoritiesString.MainMenu.AllAuthorities))
            {
                int i = 0;

                if (!AuthorityState(db, AuthoritiesString.QXGLForm.AllAuthorities, AuthoritiesString.MainMenu.xtgl, true))
                {
                    frm.tsmi_xtgl_qxgl.Enabled = false;
                    i++;
                }
                if (!AuthorityState(db, AuthoritiesString.XTRZYForm.AllAuthorities, AuthoritiesString.MainMenu.xtgl, true))
                {
                    frm.tsmi_xtgl_xtrz.Enabled = false;
                    i++;
                }

                if(i == 2)
                {
                    frm.tsmi_xtgl.Enabled = false;
                }
            }
            #endregion 系统管理菜单结束

        }


        #region 刀具菜单
        /// <summary>
        /// 刀具管理窗体权限设置
        /// </summary>
        /// <param name="frm"></param>
        private void setDaoJuGuanLiForm(DaoJuGuanLi frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.DJGLForm.AllAuthorities, AuthoritiesString.MainMenu.AllAuthorities))
            {
                return;
            }
            //if (!AuthorityState(db, AuthoritiesString.DJGLForm.lxgl, AuthoritiesString.DJGLForm.AllAuthorities))
            //{
            //    MainForm mdiParentFrm = (MainForm)frm.MdiParent;
            //    mdiParentFrm.tsmi_dj_djlxgl.Visible = false;
            //}
            if (!AuthorityState(db, AuthoritiesString.DJGLForm.kcmx, AuthoritiesString.DJGLForm.AllAuthorities))
            {
                frm.btn_kcmx.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJGLForm.zpdj, AuthoritiesString.DJGLForm.AllAuthorities))
            {
                frm.btn_zpdj.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJGLForm.cxdj, AuthoritiesString.DJGLForm.AllAuthorities))
            {
                frm.btn_cxdj.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJGLForm.djcl, AuthoritiesString.DJGLForm.AllAuthorities, true))
            {
                frm.btn_djcl.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJGLForm.djly, AuthoritiesString.DJGLForm.AllAuthorities, true))
            {
                frm.btn_djly.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJGLForm.djxy, AuthoritiesString.DJGLForm.AllAuthorities, true))
            {
                frm.btn_djxy.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJGLForm.djgh, AuthoritiesString.DJGLForm.AllAuthorities, true))
            {
                frm.btn_djgh.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJGLForm.djwj, AuthoritiesString.DJGLForm.AllAuthorities, true))
            {
                frm.btn_djwj.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJGLForm.djth, AuthoritiesString.DJGLForm.AllAuthorities, true))
            {
                frm.btn_djth.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJGLForm.djbf, AuthoritiesString.DJGLForm.AllAuthorities, true))
            {
                frm.btn_djbf.Enabled = false;
            }
        }        

        /// <summary>
        /// 刀具领用
        /// </summary>
        /// <param name="frm"></param>
        private void setDJLYForm(DJLY frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.DJLYForm.AllAuthorities, AuthoritiesString.MainMenu.dj))
            {
                return;
            }
            if (!AuthorityState(db, AuthoritiesString.DJLYForm.bc, AuthoritiesString.DJLYForm.AllAuthorities))
            {
                frm.btn_save.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJLYForm.qr, AuthoritiesString.DJLYForm.AllAuthorities))
            {
                frm.btn_confirm.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJLYForm.dy, AuthoritiesString.DJLYForm.AllAuthorities))
            {
                frm.btn_print.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJLYForm.sc, AuthoritiesString.DJLYForm.AllAuthorities))
            {
                frm.btn_delete.Enabled = false;
            }
        }

        /// <summary>
        /// 刀具续用
        /// </summary>
        /// <param name="frm"></param>
        private void setDJXYForm(DJXY frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.DJXYForm.AllAuthorities, AuthoritiesString.MainMenu.dj))
            {
                return;
            }
            if (!AuthorityState(db, AuthoritiesString.DJXYForm.bc, AuthoritiesString.DJXYForm.AllAuthorities))
            {
                frm.btn_save.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJXYForm.qr, AuthoritiesString.DJXYForm.AllAuthorities))
            {
                frm.btn_confirm.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJXYForm.dy, AuthoritiesString.DJXYForm.AllAuthorities))
            {
                frm.btn_print.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJXYForm.sc, AuthoritiesString.DJXYForm.AllAuthorities))
            {
                frm.btn_delete.Enabled = false;
            }
        }

        /// <summary>
        /// 刀具更换
        /// </summary>
        /// <param name="frm"></param>
        private void setDJGHForm(DJGH frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.DJGHForm.AllAuthorities, AuthoritiesString.MainMenu.dj))
            {
                return;
            }
            if (!AuthorityState(db, AuthoritiesString.DJGHForm.bc, AuthoritiesString.DJGHForm.AllAuthorities))
            {
                frm.btn_save.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJGHForm.qr, AuthoritiesString.DJGHForm.AllAuthorities))
            {
                frm.btn_confirm.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJGHForm.dy, AuthoritiesString.DJGHForm.AllAuthorities))
            {
                frm.btn_print.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJGHForm.sc, AuthoritiesString.DJGHForm.AllAuthorities))
            {
                frm.btn_delete.Enabled = false;
            }
        }

        /// <summary>
        /// 刀具外借
        /// </summary>
        /// <param name="frm"></param>
        private void setDJWJForm(DJWJ frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.DJWJForm.AllAuthorities, AuthoritiesString.MainMenu.dj))
            {
                return;
            }
            if (!AuthorityState(db, AuthoritiesString.DJWJForm.bc, AuthoritiesString.DJWJForm.AllAuthorities))
            {
                frm.btn_save.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJWJForm.qr, AuthoritiesString.DJWJForm.AllAuthorities))
            {
                frm.btn_confirm.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJWJForm.dy, AuthoritiesString.DJWJForm.AllAuthorities))
            {
                frm.btn_print.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJWJForm.sc, AuthoritiesString.DJWJForm.AllAuthorities))
            {
                frm.btn_delete.Enabled = false;
            }
        }

        /// <summary>
        /// 刀具退还
        /// </summary>
        /// <param name="frm"></param>
        private void setDJTHForm(DJTH frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.DJTHForm.AllAuthorities, AuthoritiesString.MainMenu.dj))
            {
                return;
            }
            if (!AuthorityState(db, AuthoritiesString.DJTHForm.bc, AuthoritiesString.DJTHForm.AllAuthorities))
            {
                frm.btn_save.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJTHForm.qr, AuthoritiesString.DJTHForm.AllAuthorities))
            {
                frm.btn_confirm.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJTHForm.dy, AuthoritiesString.DJTHForm.AllAuthorities))
            {
                frm.btn_print.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJTHForm.sc, AuthoritiesString.DJTHForm.AllAuthorities))
            {
                frm.btn_delete.Enabled = false;
            }
        }

        /// <summary>
        /// 刀具报废
        /// </summary>
        /// <param name="frm"></param>
        private void setDJBFForm(DJBF frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.DJBFForm.AllAuthorities, AuthoritiesString.MainMenu.dj))
            {
                return;
            }
            if (!AuthorityState(db, AuthoritiesString.DJBFForm.bc, AuthoritiesString.DJBFForm.AllAuthorities))
            {
                frm.btn_save.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJBFForm.qr, AuthoritiesString.DJBFForm.AllAuthorities))
            {
                frm.btn_confirm.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJBFForm.dy, AuthoritiesString.DJBFForm.AllAuthorities))
            {
                frm.btn_print.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJBFForm.sc, AuthoritiesString.DJBFForm.AllAuthorities))
            {
                frm.btn_delete.Enabled = false;
            }
        }

        private void setDJBFHistoryForm(DJBFHistory frm)
        {

        }

        /// <summary>
        /// 刀具测量
        /// </summary>
        /// <param name="frm"></param>
        private void setDJCLForm(DaoJuCanShuXinXi frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.DJCLForm.AllAuthorities, AuthoritiesString.MainMenu.dj))
            {
                return;
            }
            if (!AuthorityState(db, AuthoritiesString.DJCLForm.bcsj, AuthoritiesString.DJCLForm.AllAuthorities))
            {
                frm.btn_bcsj.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.DJCLForm.hqclsj, AuthoritiesString.DJCLForm.AllAuthorities))
            {
                frm.btn_hqclsj.Enabled = false;
            }           
        }

        #endregion 刀具菜单结束



        #region 零部件菜单
        /// <summary>
        /// 零部件管理窗体权限设置
        /// </summary>
        /// <param name="frm"></param>
        private void setLBJGLForm(lbj_GuanLi frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.LBJGLForm.AllAuthorities, AuthoritiesString.MainMenu.AllAuthorities))
            {
                return;
            }
            //if (!AuthorityState(db, AuthoritiesString.DJGLForm.lxgl, AuthoritiesString.DJGLForm.AllAuthorities))
            //{
            //    MainForm mdiParentFrm = (MainForm)frm.MdiParent;
            //    mdiParentFrm.tsmi_dj_djlxgl.Visible = false;
            //}
            if (!AuthorityState(db, AuthoritiesString.LBJGLForm.lbjly, AuthoritiesString.LBJGLForm.AllAuthorities, true))
            {
                frm.btn_lbjly.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.LBJGLForm.lbjth, AuthoritiesString.LBJGLForm.AllAuthorities, true))
            {
                frm.btn_lbjth.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.LBJGLForm.kcmx, AuthoritiesString.LBJGLForm.AllAuthorities))
            {
                frm.btn_kcmx.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.LBJGLForm.xgkcl, AuthoritiesString.LBJGLForm.AllAuthorities))
            {
                frm.btn_xgkxl.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.LBJGLForm.lbjlyjl, AuthoritiesString.LBJGLForm.lbjly))
            {
                frm.btn_lbjlyjl.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.LBJGLForm.lbjthjl, AuthoritiesString.LBJGLForm.lbjth))
            {
                frm.btn_lbjthjl.Enabled = false;
            }
        }

        /// <summary>
        /// 零部件领用单据窗体权限设置
        /// </summary>
        /// <param name="frm"></param>
        private void setLBJLYForm(LBJLY frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.LBJLYForm.AllAuthorities, AuthoritiesString.MainMenu.lbj))
            {
                return;
            }
            if (!AuthorityState(db, AuthoritiesString.LBJLYForm.bc, AuthoritiesString.LBJLYForm.AllAuthorities))
            {
                frm.btn_save.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.LBJLYForm.qr, AuthoritiesString.LBJLYForm.AllAuthorities))
            {
                frm.btn_confirm.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.LBJLYForm.dy, AuthoritiesString.LBJLYForm.AllAuthorities))
            {
                frm.btn_print.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.LBJLYForm.sc, AuthoritiesString.LBJLYForm.AllAuthorities))
            {
                frm.btn_delete.Enabled = false;
            }
        }

        /// <summary>
        /// 零部件退还单据窗体权限设置
        /// </summary>
        /// <param name="frm"></param>
        private void setLBJTHForm(LBJTH frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.LBJTHForm.AllAuthorities, AuthoritiesString.MainMenu.lbj))
            {
                return;
            }
            if (!AuthorityState(db, AuthoritiesString.LBJTHForm.bc, AuthoritiesString.LBJTHForm.AllAuthorities))
            {
                frm.btn_save.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.LBJTHForm.qr, AuthoritiesString.LBJTHForm.AllAuthorities))
            {
                frm.btn_confirm.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.LBJTHForm.dy, AuthoritiesString.LBJTHForm.AllAuthorities))
            {
                frm.btn_print.Enabled = false;
            }
            if (!AuthorityState(db, AuthoritiesString.LBJTHForm.sc, AuthoritiesString.LBJTHForm.AllAuthorities))
            {
                frm.btn_delete.Enabled = false;
            }
        }

        #endregion 零部件菜单结束



        #region 刀具柜菜单
        /// <summary>
        /// 刀具柜窗体权限设置
        /// </summary>
        /// <param name="frm"></param>
        private void setDJGForm(daojugui frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (!AuthorityState(db, AuthoritiesString.DJGForm.AllAuthorities, AuthoritiesString.MainMenu.AllAuthorities, true))
            {
                if (!AuthorityState(db, AuthoritiesString.DJGForm.djg_xzdjg, AuthoritiesString.DJGForm.AllAuthorities))
                {
                    frm.btn_xzdjg.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.DJGForm.djg_scdjg, AuthoritiesString.DJGForm.AllAuthorities))
                {
                    frm.btn_scdjg.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.DJGForm.djg_drtp, AuthoritiesString.DJGForm.AllAuthorities))
                {
                    frm.btn_drtp.Enabled = false;
                }
            }
        }
        #endregion 刀具柜菜单结束



        #region 机床菜单
        /// <summary>
        /// 机床管理窗体权限设置
        /// </summary>
        /// <param name="frm"></param>
        private void setJCForm(jichuang frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (!AuthorityState(db, AuthoritiesString.JCForm.AllAuthorities, AuthoritiesString.MainMenu.AllAuthorities))
            {
                if (!AuthorityState(db, AuthoritiesString.JCForm.jc_xzjc, AuthoritiesString.JCForm.AllAuthorities))
                {
                    frm.btn_xzjc.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.JCForm.jc_scjc, AuthoritiesString.JCForm.AllAuthorities))
                {
                    frm.btn_scjc.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.JCForm.jc_drtp, AuthoritiesString.JCForm.AllAuthorities))
                {
                    frm.btn_drtp.Enabled = false;
                }
            }
        }
        #endregion 机床菜单结束
        


        #region 工艺卡菜单
        /// <summary>
        /// 工艺卡窗体权限设置
        /// </summary>
        /// <param name="frm"></param>
        private void setGYKForm(gyk frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (!AuthorityState(db, AuthoritiesString.GYKForm.AllAuthorities, AuthoritiesString.MainMenu.AllAuthorities, true))
            {
                if (!AuthorityState(db, AuthoritiesString.GYKForm.gyk_xz, AuthoritiesString.GYKForm.AllAuthorities))
                {
                    frm.btn_gyk_New.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.GYKForm.gyk_bc, AuthoritiesString.GYKForm.AllAuthorities))
                {
                    frm.btn_gyk_Save.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.GYKForm.gyk_sc, AuthoritiesString.GYKForm.AllAuthorities))
                {
                    frm.btn_gyk_Delete.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.GYKForm.gyk_gxxz, AuthoritiesString.GYKForm.AllAuthorities))
                {
                    frm.btn_gx_New.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.GYKForm.gyk_gxxg, AuthoritiesString.GYKForm.AllAuthorities))
                {
                    frm.btn_gx_Edit.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.GYKForm.gyk_pdxz, AuthoritiesString.GYKForm.AllAuthorities))
                {
                    frm.btn_pd_New.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.GYKForm.gyk_pdxg, AuthoritiesString.GYKForm.AllAuthorities))
                {
                    frm.btn_pd_Edit.Enabled = false;
                }
            }
        }
        #endregion 工艺卡菜单结束



        #region 基础资料菜单
        /// <summary>
        /// 数据导入导出窗体权限设置
        /// </summary>
        /// <param name="frm"></param>
        private void setSJDRDCForm(shujudaorudaochu frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (!AuthorityState(db, AuthoritiesString.SJDRDCForm.AllAuthorities, AuthoritiesString.MainMenu.AllAuthorities, true))
            {
                if (!AuthorityState(db, AuthoritiesString.SJDRDCForm.jczl_sjdc, AuthoritiesString.SJDRDCForm.AllAuthorities))
                {
                    frm.btn_output.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.SJDRDCForm.jczl_sjdr, AuthoritiesString.SJDRDCForm.AllAuthorities))
                {
                    frm.btn_save.Enabled = false;
                }
            }
        }
        #endregion 基础资料菜单结束



        #region 系统管理菜单
        /// <summary>
        /// 权限管理窗体权限设置
        /// </summary>
        /// <param name="frm"></param>
        private void setQXGLForm(qxguanli frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (!AuthorityState(db, AuthoritiesString.QXGLForm.AllAuthorities, AuthoritiesString.MainMenu.AllAuthorities, true))
            {
                if (!AuthorityState(db, AuthoritiesString.QXGLForm.tjyh, AuthoritiesString.QXGLForm.AllAuthorities, true))
                {
                    frm.btn_AddUser.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.QXGLForm.scyh, AuthoritiesString.QXGLForm.AllAuthorities, true))
                {
                    frm.btn_DeleteUser.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.QXGLForm.bjyh, AuthoritiesString.QXGLForm.AllAuthorities, true))
                {
                    frm.btn_EditUser.Enabled = false;
                    frm.btn_SaveInfo.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.QXGLForm.xgmm, AuthoritiesString.QXGLForm.AllAuthorities, true))
                {
                    frm.btn_EditPwd.Enabled = false;
                    frm.btn_ConfirmEditPwd.Enabled = false;
                }
                //if (!AuthorityState(db, AuthoritiesString.QXGLForm.bcxx, AuthoritiesString.QXGLForm.AllAuthorities))
                //{
                //    frm.btn_SaveInfo.Enabled = false;
                //}
                if (!AuthorityState(db, AuthoritiesString.QXGLForm.czmm, AuthoritiesString.QXGLForm.AllAuthorities, true))
                {
                    frm.bnt_ResetPwd.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.QXGLForm.xjxz, AuthoritiesString.QXGLForm.AllAuthorities, true))
                {
                    frm.btn_AddGroup.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.QXGLForm.scxz, AuthoritiesString.QXGLForm.AllAuthorities, true))
                {
                    frm.btn_DeleteGroup.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.QXGLForm.bjxz, AuthoritiesString.QXGLForm.AllAuthorities, true))
                {
                    frm.btn_EditGroup.Enabled = false;
                    frm.btn_AddUsertoGroup.Enabled = false;
                    frm.btn_DeleteUserfromGroup.Enabled = false;
                    frm.btn_SaveSettings.Enabled = false;
                }
                //if (!AuthorityState(db, AuthoritiesString.QXGLForm.bcsz, AuthoritiesString.QXGLForm.AllAuthorities))
                //{
                //    frm.btn_save.Enabled = false;
                //}
            }
        }

        /// <summary>
        /// 系统日志窗体权限设置
        /// </summary>
        /// <param name="frm"></param>
        private void setXTRZForm(Log frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (!AuthorityState(db, AuthoritiesString.XTRZYForm.AllAuthorities, AuthoritiesString.MainMenu.AllAuthorities, true))
            {
                if (!AuthorityState(db, AuthoritiesString.XTRZYForm.jzrz, AuthoritiesString.XTRZYForm.AllAuthorities, true))
                {
                    frm.btn_loadLog.Enabled = false;
                }
                if (!AuthorityState(db, AuthoritiesString.XTRZYForm.zwjjzck, AuthoritiesString.XTRZYForm.AllAuthorities, true))
                {
                    frm.btn_openExplorer.Enabled = false;
                }
            }
        }
        #endregion 系统管理菜单结束
    }
}
