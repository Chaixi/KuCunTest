using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kucunTest.BaseClasses
{
    /// <summary>
    /// 刀具类型表：所有刀具类型
    /// </summary>
    public static class DaoJuLeiXing
    {
        public static string TableName = "daoju";//表名
        public static string xh = "xh";//序号主键
        public static string djlx = "djlx";//刀具类型
        public static string djgg = "djgg";//刀具规格
        public static string djxh = "djxh";//刀具型号
        public static string djtp = "djtp";//刀具图片
    }

    /// <summary>
    /// 刀具temp表:所有已装配刀具的状态表
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
    /// 刀具基础参数表
    /// </summary>
    public static class DaoJuCanShu
    {
        public static string TableName = "jichucanshu";//表名
        public static string xh = "xh";//序号主键
        public static string csm = "csm";//参数名
        public static string csdm = "csdm";//参数代码
        public static string csz = "csz";//参数值
        public static string ssfm = "ssfm";//所属父母
    }

    /// <summary>
    /// 刀具操作流水表
    /// </summary>
    public static class DaoJuLiuShui
    {
        public static string TableName = "daojuliushui";//表名
        public static string xh = "xh";//序号主键
        public static string danhao = "danhao";//单号
        public static string dhlx = "dhlx";//单号类型
        public static string djlx = "djlx";//刀具类型
        public static string djgg = "djgg";//刀具规格
        public static string djid = "djid";//刀具id
        public static string zsl = "zsl";//库存增加数量
        public static string fsl = "fsl";//库存减少数量
        public static string dskykc = "dskykc";//当时可用库存
        public static string wzbm = "wzbm";//刀具位置编码
        public static string jtwz = "jtwz";//刀具具体位置，刀具柜层数或机床刀套号
        public static string czsj = "czsj";//操作时间
        public static string jbr = "jbr";//经办人
        public static string bz = "bz";//备注
    }

    /// <summary>
    /// 刀具报废单据表
    /// </summary>
    public static class DaoJuBaoFei
    {
        public static string TableName = "daojubaofei";//表名
        public static string xh = "xh";//序号主键
        public static string danhao = "danhao";//单号
        public static string djzt = "djzt";//单据状态
        public static string sqbz = "sqbz";//申请班组
        public static string sqr = "sqr";//申请人
        public static string sqsb = "sqsb";//申请设备
        public static string sqsj = "sqsj";//申请时间
        public static string jglj = "jglj";//加工零件
        public static string gx = "gx";//工序
        public static string djlx = "djlx";//刀具类型
        public static string djgg = "djgg";//刀具规格
        public static string djcd = "djcd";//刀具长度
        public static string djid = "djid";//刀具ID
        public static string bfyy = "bfyy";//报废原因
        public static string spld = "spld";//审批领导
        public static string spyj = "spyj";//审批意见
        public static string spsj = "spsj";//审批时间
        public static string jbr = "jbr";//经办人
        public static string bfzcwz = "bfzcwz";//报废暂存位置
        public static string jtwz = "jtwz";//具体位置
    }
    
    /// <summary>
    /// 刀具领用单据表
    /// </summary>
    public static class DaoJuLingYong
    {
        public static string TableName = "daojulingyong";//表名
        public static string xh = "xh";//序号主键
        public static string danhao = "chucangdanhao";//单号
        public static string djzt = "danjuzhuangtai";//单据状态
        public static string lylx = "chucangleixing";//领用类型
        public static string lybz = "lingyongbanzu";//领用班组
        public static string lysb = "lingyongshebei";//领用设备
        public static string lyr = "lingyongren";//领用人
        public static string jggy = "jiagonggongyi";//加工工艺
        public static string lysj = "chucangriqi";//领用时间
        public static string jbr = "caozuoyuan";//经办人
        public static string bz = "beizhu";//备注
    }

    /// <summary>
    /// 刀具领用单据明细表
    /// </summary>
    public static class DaoJuLingYongMingXi
    {
        public static string TableName = "daojulingyongmingxi";//表名
        public static string xh = "xh";//序号主键
        public static string danhao = "chucangdanhao";//单号
        public static string djlx = "daojuleixing";//刀具类型
        public static string djgg = "daojuguige";//刀具规格
        public static string djcd = "changdu";//刀具长度
        public static string djid = "daojuid";//刀具ID
        public static string sl = "shuliang";//数量
        public static string dw = "jiliangdanwei";//单位
        public static string wzbs = "weizhibiaoshi";//位置标识
        public static string jcbm = "jichuangbianma";//机床编码
        public static string dth = "daotaohao";//刀套号
        public static string bz = "beizhu";//备注
    }

    /// <summary>
    /// 刀具更换单据表
    /// </summary>
    public static class DaoJuGengHuan
    {
        public static string TableName = "daojugenghuan";//表名
        public static string xh = "xh";//序号主键
        public static string danhao = "danhao";//单号
        public static string djzt = "djzt";//单据状态
        public static string sqbz = "sqbz";//申请班组
        public static string sqr = "sqr";//申请人
        public static string sqsb = "sqsb";//申请设备
        public static string sqsj = "sqsj";//申请时间
        public static string jglj = "jglj";//加工零件
        public static string gx = "gx";//工序
        public static string ydjlx = "ydjlx";//原刀具类型
        public static string ydjgg = "ydjgg";//原刀具规格
        public static string ydjcd = "ydjcd";//原刀具长度
        public static string ydjid = "ydjid";//原刀具ID
        public static string xdjlx = "xdjlx";//新刀具类型
        public static string xdjgg = "xdjgg";//新刀具规格
        public static string xdjcd = "xdjcd";//新刀具长度
        public static string xdjid = "xdjid";//新刀具ID
        public static string ghly = "ghly";//更换理由
        public static string spld = "spld";//审批领导
        public static string spyj = "spyj";//审批意见
        public static string spsj = "spsj";//审批时间
        public static string jbr = "jbr";//经办人
    }

    /// <summary>
    /// 刀具退还单据表
    /// </summary>
    public static class DaoJuTuiHuan
    {
        public static string TableName = "daojutuihuan";//表名
        public static string xh = "xh";//序号主键
        public static string danhao = "danhao";//单号
        public static string djzt = "djzt";//单据状态
        public static string thbz = "thbz";//退还班组
        public static string thr = "thr";//退还人
        public static string thrq = "thrq";//退还日期
        public static string thyy = "thyy";//退还原因
        public static string jbr = "jbr";//经办人
        public static string jbrq = "jbrq";//经办日期
    }

    /// <summary>
    /// 刀具领用单据明细表
    /// </summary>
    public static class DaoJuTuiHuanMingXi
    {
        public static string TableName = "daojutuihuanmingxi";//表名
        public static string xh = "xh";//序号主键
        public static string danhao = "danhao";//单号
        public static string djlx = "djlx";//刀具类型
        public static string djgg = "djgg";//刀具规格
        public static string djcd = "djcd";//刀具长度
        public static string djid = "djid";//刀具ID
        public static string djzt = "djzt";//刀具状态
        public static string sl = "sl";//数量
        public static string jcbm = "jcbm";//机床编码
        public static string dth = "dth";//刀套号
        public static string djgbm = "djgbm";//刀具柜编码
        public static string cfwz = "cfwz";//存放位置
        public static string bz = "bz";//备注
    }

    /// <summary>
    /// 刀具外借单据表
    /// </summary>
    public static class DaoJuWaiJie
    {
        public static string TableName = "daojuwaijie";//表名
        public static string xh = "xh";//序号主键
        public static string danhao = "danhao";//单号
        public static string djzt = "djzt";//单据状态
        public static string jydw = "jydw";//借用单位
        public static string dwld = "dwld";//单位领导
        public static string jyr = "jyr";//借用人
        public static string lxdh = "lxdh";//联系电话
        public static string jyyy = "jyyy";//借用原因
        public static string spld = "spld";//审批领导
        public static string spyj = "spyj";//审批意见
        public static string jbr = "jbr";//经办人
        public static string jcsj = "jcsj";//借出时间
        public static string ydghsj = "ydghsj";//约定归还时间
    }

    /// <summary>
    /// 刀具外借单据明细表
    /// </summary>
    public static class DaoJuWaiJieMingXi
    {
        public static string TableName = "daojuwaijiemingxi";//表名
        public static string xh = "xh";//序号主键
        public static string danhao = "danhao";//单号
        public static string djlx = "djlx";//刀具类型
        public static string djgg = "djgg";//刀具规格
        public static string djid = "djid";//刀具ID
        public static string djzt = "djzt";//刀具状态
        public static string sl = "sl";//数量
        public static string jcbm = "jcbm";//机床编码
        public static string dth = "dth";//刀套号
        public static string bz = "bz";//备注
    }

    /// <summary>
    /// 刀具续用单据表
    /// </summary>
    public static class DaoJuXuYong
    {
        public static string TableName = "daojuxuyong";//表名
        public static string xh = "xh";//序号主键
        public static string danhao = "xydh";//单号
        public static string djzt = "djzt";//单据状态
        public static string xybz = "xybz";//续用班组
        public static string xyr = "xyr";//续用人
        public static string xyrq = "xyrq";//续用日期
        public static string spr = "spr";//审批人
        public static string jbr = "jbr";//经办人
        public static string bz = "beizhu";//备注
    }

    /// <summary>
    /// 刀具续用单据明细表
    /// </summary>
    public static class DaoJuXuYongMingXi
    {
        public static string TableName = "daojuxuyongmingxi";//表名
        public static string xh = "xh";//序号主键
        public static string danhao = "xydh";//单号
        public static string djlx = "djlx";//刀具类型
        public static string djgg = "djgg";//刀具规格
        public static string djid = "djid";//刀具ID
        public static string sl = "sl";//数量
        public static string jggx = "jggx";//加工工序
        public static string jcbm = "jcbm";//机床编码
        public static string dth = "dth";//刀套号
        public static string xygx = "xygx";//续用工序
        public static string xyjcbm = "xyjcbm";//续用机床编码
        public static string xydth = "xydth";//续用刀套号
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
    /// 零部件领用单据表
    /// </summary>
    public static class lbjLingYong
    {
        public static string TableName = "lbj_lingyong";//表名
        public static string xh = "xh";//序号主键
        public static string danhao = "danhao";//单号
        public static string djzt = "djzt";//单据状态
        public static string lybz = "lybz";//领用班组
        public static string lysb = "lysb";//领用设备
        public static string lyr = "lyr";//领用人
        public static string zjgx = "zjgx";//制件工序
        public static string lyrq = "lyrq";//领用日期
        public static string jbr = "jbr";//经办人
        public static string bz = "beizhu";//备注
    }

    /// <summary>
    /// 零部件领用单据明细表
    /// </summary>
    public static class lbjLingYongMingXi
    {
        public static string TableName = "lbj_lingyongmingxi";//表名
        public static string xh = "xh";//序号主键
        public static string danhao = "danhao";//单号
        public static string lbjmc = "lbjmc";//零部件名称
        public static string lbjgg = "lbjgg";//零部件规格
        public static string lbjxh = "lbjxh";//零部件型号
        public static string djgbm = "djgbm";//刀具柜编码
        public static string jtwz = "jtwz";//具体位置
        public static string lysl = "lysl";//领用数量
        public static string dw = "dw";//单位
        public static string wzbs = "wzbs";//位置标识
        public static string jcbm = "jcbm";//机床编码
        public static string gx = "gx";//工序
        public static string bz = "bz";//备注
    }

    /// <summary>
    /// 零部件退还单据表
    /// </summary>
    public static class lbjTuiHuan
    {
        public static string TableName = "lbj_tuihuan";//表名
        public static string xh = "xh";//序号主键
        public static string danhao = "danhao";//单号
        public static string djzt = "djzt";//单据状态
        public static string thbz = "thbz";//退还班组
        public static string thr = "thr";//退还人
        public static string thrq = "thrq";//退还日期
        public static string thyy = "thyy";//退还原因
        public static string jbr = "jbr";//经办人
        public static string jbrq = "jbrq";//经办日期
    }

    /// <summary>
    /// 零部件退还单据明细表
    /// </summary>
    public static class lbjTuiHuanMingXi
    {
        public static string TableName = "lbj_tuihuanmingxi";//表名
        public static string xh = "xh";//序号主键
        public static string danhao = "danhao";//单号
        public static string lbjmc = "lbjmc";//零部件名称
        public static string lbjgg = "lbjgg";//零部件规格
        public static string lbjxh = "lbjxh";//零部件型号
        public static string djgbm = "djgbm";//刀具柜编码
        public static string cfwz = "cfwz";//存放位置
        public static string sl = "sl";//退还数量
        public static string dw = "dw";//单位
        public static string jcbm = "jcbm";//机床编码
        public static string gx = "gx";//工序
        public static string bz = "bz";//备注
    }

    /// <summary>
    /// 零部件流水表
    /// </summary>
    public static class lbjLiuShui
    {
        public static string TableName = "lbj_liushui";//表名
        public static string xh = "xh";//序号主键
        public static string danhao = "danhao";//单号
        public static string dhlx = "dhlx";//单号类型
        public static string lbjmc = "lbjmc";//零部件名称
        public static string lbjgg = "lbjgg";//零部件规格
        public static string lbjxh = "lbjxh";//零部件型号
        public static string djgbm = "djgbm";//刀具柜编码
        public static string jtwz = "jtwz";//具体位置
        public static string zsl = "zsl";//库存增加数量
        public static string fsl = "fsl";//库存减少数量
        public static string dskykc = "dskykc";//当时可用库存
        public static string dw = "dw";//单位
        public static string czsj = "czsj";//操作时间
        public static string jbr = "jbr";//经办人
        public static string bz = "bz";//备注
    }

    /// <summary>
    /// 刀具零部件关联表
    /// </summary>
    public static class DaoJuLingBuJian
    {
        public static string TableName = "daojulingbujian";//表名
        public static string xh = "xh";//序号主键
        public static string djlx = "daojuleixing";//刀具类型
        public static string djxh = "djxh";//刀具型号
        public static string lbjmc = "lbjmc";//零部件名称
        public static string lbjgg = "lbjgg";//零部件规格
        public static string lbjxh = "lbjxh";//零部件型号
        public static string sl = "sl";//数量
        public static string dw = "dw";//单位
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
        public static string ssbz = "suoshubanzu";//所属班组
        public static string zcbh = "zichanbianhao";//资产编号
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

    /// <summary>
    /// 班组表
    /// </summary>
    public static class BanZu
    {
        public static string TableName = "banzu";//表名
        public static string xh = "xh";//主键序号
        public static string bzmc = "banzumingcheng";//班组名称
        public static string scxmc = "shengchanxianmingcheng";//生产线名称
    }

    
}
