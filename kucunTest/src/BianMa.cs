using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kucunTest.src
{
    public class BianMa
    {
        #region 全局变量
        private MySql SQL = new MySql();
        private string SqlStr = "";
        private string dt = DateTime.Now.ToString("yyMMdd");//注意月份是大写M，小写m表示分钟
        private string BH = "";//存放新编号
        private int count;//记录数据库当天已有单号数量
        #endregion

        #region newBianHao方法
        /// <summary>
        /// 根据请求单据类型获取单据的自动编号
        /// </summary>
        /// <param name="type">单号前缀1，请求单据类型，如出仓单则type='CC'</param>
        /// <returns></returns>
        public string newBianHao(string type)
        {
            string where = "chucang where rcdh like 'CC_";
            switch (type)
            {
                case "RC"://入仓
                    where = "rucang where rcdh like 'RC_";
                    break;
                //case "CG"://采购
                //    where = "rucang where rcdh like 'CG_";
                //    break;
                //case "RM"://刃磨
                //    where = "rucang where rcdh like 'RM_";
                //    break;
            }
            SqlStr = "select count(*) from " + where + dt + "%'";
            count = Convert.ToInt32(SQL.ExecuteScalar(SqlStr));
            BH = type + '_' + dt + (count+1).ToString("0000");
            return BH;
        }
        #endregion
    }
}
