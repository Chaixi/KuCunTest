using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using kucunTest.DaoJu;

namespace kucunTest.quanxianguanli
{
    /// <summary>
    /// 公共类，存放与权限列表、数据库权限代码一致的字符串
    /// </summary>
    class AuthoritiesString
    {
        /// <summary>
        /// 所有窗体名
        /// </summary>
        public static class FormName
        {
            public static string mainFrm = "MainForm";//主界面
            public static string djglFrm = "DaoJuGuanLi";//刀具管理窗体
            public static string djlyFrm = "djly";//刀具领用单据窗体
            public static string djxyFrm = "djxy";//刀具续用单据窗体
            public static string djghFrm = "djgh";//刀具更换单据窗体
            public static string djwjFrm = "djwj";//刀具外借单据窗体
            public static string djthFrm = "djth";//刀具退还单据窗体
            public static string djbfFrm = "djbf";//刀具报废单据窗体
            public static string djclFrm = "djcl";//刀具测量窗体

            public static string djgFrm = "djg";//刀具柜窗体
            public static string jcFrm = "jc";//机床窗体
            public static string gykFrm = "gyk";//工艺卡窗体


        }

        /// <summary>
        /// 主菜单界面
        /// </summary>
        public static class MainMenu
        {
            public static string AllAuthorities = "AllAuthorities";//全部模块代码
            public static string dj = "dj";//刀具
            public static string lbj = "lbj";//零部件
            public static string djg = "djg";//刀具柜
            public static string jc = "jc";//机床
            public static string gyk = "gyk";//工艺卡
            public static string jczl = "jczl";//基础资料
            public static string xtgl = "xtgl";//系统管理

        }

        #region 刀具
        /// <summary>
        /// 刀具管理界面
        /// </summary>
        public static class DJGLForm
        {
            public static string AllAuthorities = "dj";//
            public static string lxgl = "dj_lxgl";//
            public static string kcmx = "dj_kcmx";//
            public static string zpdj = "dj_zpdj";//
            public static string cxdj = "dj_cxdj";//
            public static string djcl = "dj_djcl";//
            public static string djly = "dj_djly";//
            public static string djxy = "dj_djxy";//
            public static string djgh = "dj_djgh";//
            public static string djwj = "dj_djwj";//
            public static string djth = "dj_djth";//
            public static string djbf = "dj_djbf";//
        }

        /// <summary>
        /// 刀具领用单据界面
        /// </summary>
        public static class DJLYForm
        {
            public static string AllAuthorities = "dj_djly";//全部权限：刀具领用
            public static string lsjl = "dj_djly_djlsjl";//单据历史记录
            public static string bc = "dj_djly_bc";//保存
            public static string qr = "dj_djly_qr";//确认
            public static string dy = "dj_djly_dy";//打印
            public static string sc = "dj_djly_sc";//删除
        }

        /// <summary>
        /// 刀具续用单据界面
        /// </summary>
        public static class DJXYForm
        {
            public static string AllAuthorities = "dj_djxy";//全部权限：刀具领用
            public static string lsjl = "dj_djxy_djlsjl";//单据历史记录
            public static string bc = "dj_djxy_bc";//保存
            public static string qr = "dj_djxy_qr";//确认
            public static string dy = "dj_djxy_dy";//打印
            public static string sc = "dj_djxy_sc";//删除
        }

        /// <summary>
        /// 刀具更换单据界面
        /// </summary>
        public static class DJGHForm
        {
            public static string AllAuthorities = "dj_djgh";//全部权限：刀具领用
            public static string lsjl = "dj_djgh_djlsjl";//单据历史记录
            public static string bc = "dj_djgh_bc";//保存
            public static string qr = "dj_djgh_qr";//确认
            public static string dy = "dj_djgh_dy";//打印
            public static string sc = "dj_djgh_sc";//删除
        }

        /// <summary>
        /// 刀具外借单据界面
        /// </summary>
        public static class DJWJForm
        {
            public static string AllAuthorities = "dj_djwj";//全部权限：刀具领用
            public static string lsjl = "dj_djwj_djlsjl";//单据历史记录
            public static string bc = "dj_djwj_bc";//保存
            public static string qr = "dj_djwj_qr";//确认
            public static string dy = "dj_djwj_dy";//打印
            public static string sc = "dj_djwj_sc";//删除
        }

        /// <summary>
        /// 刀具退还单据界面
        /// </summary>
        public static class DJTHForm
        {
            public static string AllAuthorities = "dj_djth";//全部权限：刀具领用
            public static string lsjl = "dj_djth_djlsjl";//单据历史记录
            public static string bc = "dj_djth_bc";//保存
            public static string qr = "dj_djth_qr";//确认
            public static string dy = "dj_djth_dy";//打印
            public static string sc = "dj_djth_sc";//删除
        }

        /// <summary>
        /// 刀具报废单据界面
        /// </summary>
        public static class DJBFForm
        {
            public static string AllAuthorities = "dj_djbf";//全部权限：刀具领用
            public static string lsjl = "dj_djbf_djlsjl";//单据历史记录
            public static string bc = "dj_djbf_bc";//保存
            public static string qr = "dj_djbf_qr";//确认
            public static string dy = "dj_djbf_dy";//打印
            public static string sc = "dj_djbf_sc";//删除
        }

        /// <summary>
        /// 刀具参数测量界面
        /// </summary>
        public static class DJCLForm
        {
            public static string AllAuthorities = "dj_djcl";//全部权限：刀具测量
            public static string bcsj = "dj_djcl_bcsj";//保存数据
            public static string hqclsj = "dj_djcl_hqclsj";//获取测量数据
        }

        #endregion 刀具结束



        #region 零部件
        /// <summary>
        /// 零部件管理界面
        /// </summary>
        public static class LBJGLForm
        {
            public static string AllAuthorities = "lbj";//零部件
            public static string lxgl = "lbj_lxgl";//
            public static string kcmx = "lbj_kcmx";//
            public static string lbjly = "lbj_lbjly";//
            public static string lbjth = "lbj_lbjth";//
            public static string xgkcl = "lbj_xgkcl";//

        }

        /// <summary>
        /// 零部件领用单据界面
        /// </summary>
        public static class LBJLYForm
        {
            public static string AllAuthorities = "lbj_lbjly";//全部权限：零部件领用
            public static string lsjl = "lbj_lbjly_djlsjl";//单据历史记录
            public static string bc = "lbj_lbjly_bc";//保存
            public static string qr = "lbj_lbjly_qr";//确认
            public static string dy = "lbj_lbjly_dy";//打印
            public static string sc = "lbj_lbjly__sc";//删除
        }

        /// <summary>
        /// 零部件退还单据界面
        /// </summary>
        public static class LBJTHForm
        {
            public static string AllAuthorities = "lbj_lbjth";//全部权限：零部件退还
            public static string lsjl = "lbj_lbjth_djlsjl";//单据历史记录
            public static string bc = "lbj_lbjth_bc";//保存
            public static string qr = "lbj_lbjth_qr";//确认
            public static string dy = "lbj_lbjth_dy";//打印
            public static string sc = "lbj_lbjth_sc";//删除
        }
        #endregion 零部件结束



        #region 刀具柜
        /// <summary>
        /// 刀具柜界面
        /// </summary>
        public static class DJGForm
        {
            public static string AllAuthorities = "djg";//全部权限：刀具柜
            public static string djg_xzdjg = "djg_xzdjg";//新增刀具柜
            public static string djg_scdjg = "djg_scdjg";//删除刀具柜
            public static string djg_drtp = "djg_drtp";//导入图片
        }
        #endregion 刀具柜结束



        #region 机床
        /// <summary>
        /// 机床界面
        /// </summary>
        public static class JCForm
        {
            public static string AllAuthorities = "jc";//全部权限：机床
            public static string jc_xzjc = "jc_xzjc";//新增机床
            public static string jc_scjc = "jc_scjc";//删除机床
            public static string jc_drtp = "jc_drtp";//导入图片
        }
        #endregion 机床结束



        #region 工艺卡
        /// <summary>
        /// 工艺卡界面
        /// </summary>
        public static class GYKForm
        {
            public static string AllAuthorities = "gyk";//全部权限：工艺卡
            public static string gyk_xz = "gyk_xz";//工艺卡新增
            public static string gyk_bc = "gyk_bc";//工艺卡保存
            public static string gyk_sc = "gyk_sc";//工艺卡删除
            public static string gyk_gxxz = "gyk_gxxz";//工艺卡——工序新增
            public static string gyk_gxxg = "gyk_gxxg";//工艺卡——工序修改
            public static string gyk_pdxz = "gyk_pdxz";//工艺卡——配刀新增
            public static string gyk_pdxg = "gyk_pdxg";//工艺卡——配刀删除

        }
        #endregion 工艺卡结束



        #region 基础资料
        #endregion 基础资料结束



        #region 系统管理
        /// <summary>
        /// 权限管理界面
        /// </summary>
        public static class QXGLForm
        {
            public static string AllAuthorities = "xtgl";//系统管理
            public static string qxgl = "xtgl_qxgl";//权限管理
            public static string yhgl = "xtgl_qxgl_yhgl";//用户管理
            public static string xgmm = "xtgl_qxgl_yhgl_xgmm";//修改密码
            public static string tjyh = "xtgl_qxgl_yhgl_tjyh";//添加用户
            public static string scyh = "xtgl_qxgl_yhgl_scyh";//删除用户
            public static string bjyh = "xtgl_qxgl_yhgl_bjyh";//编辑用户
            public static string bcxx = "xtgl_qxgl_yhgl_bcxx";//保存信息
            public static string czmm = "xtgl_qxgl_yhgl_czmm";//重置密码

            public static string xzgl = "xtgl_qxgl_xzgl";//小组管理
            public static string tjxzty = "xtgl_qxgl_xzgl_tjxzcy";//添加小组成员
            public static string ycxzcy = "xtgl_qxgl_xzgl_ycxzcy";//移除小组成员
            public static string xjxz = "xtgl_qxgl_xzgl_xjxz";//新建小组
            public static string scxz = "xtgl_qxgl_xzgl_scxz";//删除小组
            public static string bjxz = "xtgl_qxgl_xzgl_bjxz";//编辑小组
            public static string bcsz = "xtgl_qxgl_xzgl_bcsz";//保存设置
        }

        /// <summary>
        /// 系统日志界面
        /// </summary>
        public static class XTRZYForm
        {
            public static string AllAuthorities = "xtgl_xtrz";//系统日志
            public static string jzrz = "xtgl_xtrz_jzrz";//加载系统日志
            public static string zwjjzck = "xtgl_xtrz_zwjjzck";//在文件夹中查看
        }

        #endregion 系统管理结束

    }
}
