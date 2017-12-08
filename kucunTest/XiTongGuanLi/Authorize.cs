using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

using kucunTest.BaseClasses;
using kucunTest.DaoJu;
using kucunTest.LingBuJian;

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
                case "djcl":
                    DaoJuCanShuXinXi djclFrm = (DaoJuCanShuXinXi)frm;
                    setDJCLForm(djclFrm);
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
            if (!AuthorityState(db, AuthoritiesString.MainMenu.jczl, AuthoritiesString.MainMenu.AllAuthorities, true))
            {
                frm.tsmi_jczl.Enabled = false;
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
        /// 刀具领用窗体权限设置
        /// </summary>
        /// <param name="frm"></param>
        private void setDJLYForm(DJLY frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.DJLYForm.AllAuthorities, AuthoritiesString.DJGLForm.AllAuthorities))
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

        private void setDJXYForm(DJXY frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.DJXYForm.AllAuthorities, AuthoritiesString.DJGLForm.AllAuthorities))
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

        private void setDJGHForm(DJGH frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.DJGHForm.AllAuthorities, AuthoritiesString.DJGLForm.AllAuthorities))
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

        private void setDJWJForm(DJWJ frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.DJWJForm.AllAuthorities, AuthoritiesString.DJGLForm.AllAuthorities))
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

        private void setDJTHForm(DJTH frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.DJTHForm.AllAuthorities, AuthoritiesString.DJGLForm.AllAuthorities))
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

        private void setDJBFForm(DJBF frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.DJBFForm.AllAuthorities, AuthoritiesString.DJGLForm.AllAuthorities))
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

        private void setDJCLForm(DaoJuCanShuXinXi frm)
        {
            SqlStr = string.Format("SELECT qxdm, qxzt, qxfm FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXian.TableName, QuanXian.qxgroup, User.groupName, User.TableName, User.name, username);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            if (AuthorityState(db, AuthoritiesString.DJCLForm.AllAuthorities, AuthoritiesString.DJGLForm.AllAuthorities))
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
    }
}
