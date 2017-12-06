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
            public static string mainFrm = "Mainform";//主界面
            public static string djglFrm = "DaoJuGuanLi";//刀具管理窗体
            public static string djlyFrm = "djly";//刀具领用单据窗体
            public static string djxyFrm = "djxy";//刀具续用单据窗体
            public static string djghFrm = "djgh";//刀具更换单据窗体
            public static string djwjFrm = "djwj";//刀具外借单据窗体
            public static string djthFrm = "djth";//刀具退还单据窗体
            public static string djbfFrm = "djbf";//刀具报废单据窗体
            public static string djclFrm = "djcl";//刀具测量窗体

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
    }
}
