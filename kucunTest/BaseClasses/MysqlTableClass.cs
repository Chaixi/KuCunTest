using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kucunTest.BaseClasses
{
    /// <summary>
    /// 刀具temp表
    /// </summary>
    public static class DaoJuTemp
    {
        public static string TableName = "daojutemp";//表名
        public static string xh = "xh";//序号主键
        public static string id = "daojuid";//刀具ID
        public static string leixing = "daojuleixing";//刀具类型
        public static string guige = "daojuguige";//刀具规格
        public static string xinghao = "daojuxinghao";//刀具型号
        public static string shouming = "daojushouming";//刀具寿命
        public static string weizhibiaoshi = "weizhibiaoshi";//位置标识
        public static string weizhibianma = "weizhi";//刀具位置编码
        public static string csordth = "cengshu";//刀具具体位置，刀具柜层数或机床刀套号
        public static string type = "type";//类型，刀具
        public static string kcsl = "kcsl";//库存数量
        public static string zxkc = "zuixiaokucun";//最小库存
        public static string zdkc = "zuidakucun";//最大库存
        public static string zzdj = "zzdj";//
        public static string bz = "beizhu";//备注
    }

    /// <summary>
    /// 零部件表[jichuxinxi]
    /// </summary>
    public static class LingBuJianBiao
    {
        public static string TableName = "jichuxinxi";//表名
        public static string xh = "xh";//序号主键
        public static string mc = "daojuid";//零部件名称
        public static string gg = "daojuguige";//零部件规格
        public static string xinghao = "daojuxinghao";//零部件型号
        public static string shouming = "daojushouming";//寿命
        public static string weizhibianma = "weizhi";//存放位置，刀具柜编码
        public static string cengshu = "cengshu";//具体层数
        public static string weizhibiaoshi = "weizhibiaoshi";//位置标识
        public static string type = "type";//类型，零部件
        public static string kcsl = "kcsl";//库存数量
        public static string dw = "danwei";//单位
        public static string zxkc = "zuixiaokucun";//最小库存
        public static string zdkc = "zuidakucun";//最大库存
        public static string bz = "beizhu";//备注

    }

    /// <summary>
    /// 刀具柜表
    /// </summary>
    public static class DaoJuGui
    {
        public static string TableName = "daojugui";//表名
        public static string xh = "xh";//序号主键
        public static string djgbm = "djgbm";//刀具柜编码
        public static string djgmc = "djgmc";//刀具柜名称
        public static string djglx = "djglx";//刀具柜类型
        public static string cfsm = "bz";//备注
    }

    /// <summary>
    /// 刀具柜层数表
    /// </summary>
    public static class DaoJuGuiCengShu
    {
        public static string TableName = "daojuguicengshu";//表名
        public static string xh = "xh";//序号主键
        public static string djgmc = "djgmc";//刀具柜名称
        public static string djgcs = "djgcs";//刀具柜层数
    }

    /// <summary>
    /// 机床表
    /// </summary>
    public static class JiChuangBiao
    {
        public static string TableName = "jichuang";//表名
        public static string xh = "xh";//序号主键
        public static string scx = "shengchanxian";//生产线
        public static string jcbm = "jichuangbianma";//机床编码
        public static string jclx = "jichuangleixing";//机床类型
    }

    /// <summary>
    /// 机床刀具库表
    /// </summary>
    public static class JiChuangDaoJuKu
    {
        public static string TableName = "jcdaojuku";//表名
        public static string xh = "xh";//序号主键
        public static string jcbm = "jichuangbianma";//机床编码
        public static string dth = "daotaohao";//刀套号
    }

    /// <summary>
    /// 工艺卡表
    /// </summary>
    public static class GongYiKa
    {
        public static string TableName = "gongyika";//表名
        public static string gykbh = "gykbh";//工艺卡编号
        public static string jgljlx = "jglx";//加工零件类型
        public static string cjsj = "fbsj";//创建时间
        public static string gyksm = "beizhu";//工艺卡说明
    }

    /// <summary>
    /// 工序表
    /// </summary>
    public static class GongXu
    {
        public static string TableName = "gongxu";//表名
        public static string xh = "xh";//序号主键
        public static string gykbh = "gykbh";//工艺卡编号
        public static string gxbh = "gxh";//工序号
        public static string jgljh = "jgljh";//加工零件号
        public static string jgljmc = "jgljmc";//加工零件名称
        public static string jcbm = "jichuangbianma";//机床编码
        public static string gxnr = "gxnr";//工序内容
    }

    /// <summary>
    /// 工序配刀表
    /// </summary>
    public static class GongxuPeiDao
    {        
        public static string TableName = "gongxupeidao";//表名
        public static string xh = "xh";//序号主键
        public static string gykbh = "gykbh";//工艺卡编号
        public static string gxh = "gxh";//工序号
        public static string gjlx = "gjlx";//工具类型
        public static string gjmc = "gongjumingcheng";//工具名称
        public static string gjgg = "gongjuguige";//工具规格
        public static string gjxh = "gongjuxinghao";//工具型号
        public static string jcbm = "jichuangbianma";//机床编码
        public static string dth = "daotaohao";//刀套号
        public static string sl = "sl";//数量
        public static string dw = "dw";//单位
        public static string gjsm = "gongjushuoming";//工具说明
    }
}
