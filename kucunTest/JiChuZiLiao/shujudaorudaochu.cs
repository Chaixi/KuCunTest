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

using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace kucunTest.JiChuZiLiao
{
    public partial class shujudaorudaochu : Form
    {
        #region 全局变量
        private MySql SQL = new MySql();//MySQL类
        private string SqlStr = "";//sql语句字符串

        private BaseAlex Alex = new BaseAlex();//自定义方法类
        private AutoSizeFormClass asc = new AutoSizeFormClass();//窗口自适应类

        private string tishi = "";//提示文本

        private bool AutoCheckFlag = true;

        //不同数据类型对应不同筛选条件列表
        private List<string> djlist = new List<string>();//刀具信息——刀具类型列表
        private List<string> lbjlist = new List<string>();//零部件信息——零部件名称列表
        private List<string> djglist = new List<string>();//刀具柜信息——刀具柜列表
        private List<string> jclist = new List<string>();//机床信息——班组列表

        //不同数据类型对应不同dgv数据源
        private DataTable djdb = new DataTable();//刀具信息——daojutemp表
        private DataTable lbjdb = new DataTable();//零部件信息——jichuxinxi表
        private DataTable djgdb = new DataTable();//刀具柜信息——doajugui & daojuguicengshu表
        private DataTable jcdb = new DataTable();//机床信息——jichuang表

        List<string> table_name = new List<string>();

        private int Page_Size = 25;//每页有多少条记录
        private int Record_Total = 0;//总共有多少条记录
        private int Current_Page = 0;//当前页数
        private int Total_Page = 0;//总页数

        #endregion 全局变量结束

        /// <summary>
        /// 构造函数
        /// </summary>
        public shujudaorudaochu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shujudaorudaochu_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 数据类型改变，加载相应筛选条件和表格属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SJLX.SelectedIndex < 0)
            {
                SXTJ.DataSource = null;
                return;
            }

            SqlStr = "";
            string dataType = "";

            //根据选择的数据类型设置dataType变量
            switch(SJLX.Text)
            {
                case "刀具信息":
                    dataType = "dj";
                    break;
                case "零部件信息":
                    dataType = "lbj";
                    break;
                case "刀具柜信息":
                    dataType = "djg";
                    break;
                case "机床信息":
                    dataType = "jc";
                    break;
            }

            //加载筛选条件列表
            SXTJ.DataSource = GetSXTJList(dataType);

            //加载dgv数据源
            dgv.DataSource = GetData(dataType).DefaultView;
            dgv_ColumnsReadOnly();
        }

        /// <summary>
        /// 根据数据类型获取筛选条件list
        /// </summary>
        /// <param name="type">数据类型：刀具信息--dj， 零部件信息--lbj，刀具柜信息--djg， 机床信息--jc</param>
        /// <returns>筛选条件list，如果从未加载则从数据库加载，否则使用已加载值</returns>
        private List<string> GetSXTJList(string type)
        {
            SqlStr = "";
            List<string> l = new List<string>();

            switch (type)
            {
                case "dj"://筛选条件列表为刀具类型
                    if (djlist.Count != 0)
                    {
                        return djlist;
                    }
                    djlist = Alex.GetList("djlx");
                    l = djlist;
                    break;
                case "lbj"://筛选条件列表为零部件名称
                    if (lbjlist.Count != 0)
                    {
                        return lbjlist;
                    }
                    lbjlist = Alex.GetList("lbjmc");
                    l = lbjlist;
                    break;
                case "djg"://筛选条件列表为刀具柜列表
                    if (djglist.Count != 0)
                    {
                        return djglist;
                    }
                    djglist = Alex.GetList("djg");
                    l = djglist;
                    break;
                case "jc"://筛选条件列表为班组列表
                    if (jclist.Count != 0)
                    {
                        return jclist;
                    }
                    jclist = Alex.GetList("bz");
                    l = jclist;
                    break;
            }

            SqlStr = "";

            l.Insert(0, "全部");
            return l;
        }

        /// <summary>
        /// 根据数据类型获取dgv内容datatable
        /// </summary>
        /// <param name="type">数据类型：刀具信息--dj， 零部件信息--lbj，刀具柜信息--djg， 机床信息--jc</param>
        /// <returns>返回表格数据源datatable：如果从未加载则从数据库加载，否则使用已加载值</returns>
        private DataTable GetData(string type)
        {
            SqlStr = "";
            DataTable d = new DataTable();

            switch (type)
            {
                case "dj":
                    if (djdb.Rows.Count != 0)
                    {
                        return djdb;
                    }
                    SqlStr = string.Format("SELECT d.{1} AS `刀具ID`, d.{2} AS `刀具类型`, d.{3} AS `刀具规格`, d.{4} AS `刀具型号`, d.{5} AS `刀具寿命`, d.{6} AS `位置标识`, d.{7} AS `刀具位置`, d.{8} AS `具体位置`, d.{9} AS `数量`, d.{10} AS `刀具说明` FROM {0} d", DaoJuTemp.TableName, DaoJuTemp.id, DaoJuTemp.leixing, DaoJuTemp.guige, DaoJuTemp.xinghao, DaoJuTemp.shouming, DaoJuTemp.weizhibiaoshi, DaoJuTemp.weizhibianma, DaoJuTemp.csordth, DaoJuTemp.kcsl, DaoJuTemp.bz);
                    break;
                case "lbj":
                    if (lbjdb.Rows.Count != 0)
                    {
                        return lbjdb;
                    }
                    SqlStr = string.Format("SELECT j.{1} AS `零部件类型`, j.{2} AS `零部件规格`, j.{3} AS `零部件型号`, j.{4} AS `零部件寿命`, j.{5} AS `存放刀具柜`, j.{6} AS `层号`, j.{7} AS `库存数量`, j.{8} AS `最小库存`, j.{9} AS `最大库存`, j.{10} AS `单位`, j.{11} AS `备注` FROM {0} j", LingBuJianBiao.TableName, LingBuJianBiao.mc, LingBuJianBiao.gg, LingBuJianBiao.xinghao, LingBuJianBiao.shouming, LingBuJianBiao.weizhibianma, LingBuJianBiao.cengshu, LingBuJianBiao.kcsl, LingBuJianBiao.zxkc, LingBuJianBiao.zdkc, LingBuJianBiao.dw, LingBuJianBiao.bz);
                    break;
                case "djg":
                    if (djgdb.Rows.Count != 0)
                    {
                        return djgdb;
                    }
                    SqlStr = string.Format("SELECT djg.{2} AS 刀具柜名称, djg.{3} AS 刀具柜类型, COUNT(cs.{4}) AS 刀具柜层数 FROM {0} djg LEFT JOIN {1} cs ON cs.{5} = djg.{2} GROUP BY djg.{2}", DaoJuGui.TableName, DaoJuGuiCengShu.TableName, DaoJuGui.djgmc, DaoJuGui.djglx, DaoJuGuiCengShu.djgcs, DaoJuGuiCengShu.djgmc);
                    break;
                case "jc":
                    if (jcdb.Rows.Count != 0)
                    {
                        return jcdb;
                    }
                    SqlStr = string.Format("SELECT {1} AS 资产编号, {2} AS 机床名称, {3} AS 机床类型, {4} AS 所属班组, {5} AS 所属生产线 FROM {0}", JiChuangBiao.TableName, JiChuangBiao.zcbh, JiChuangBiao.jcbm, JiChuangBiao.jclx, JiChuangBiao.ssbz, JiChuangBiao.scx);
                    break;
            }

            d = SQL.getDataSet1(SqlStr).Tables[0];
            SqlStr = "";

            return d;
        }

        /// <summary>
        /// 筛选条件选择变化，数据相应变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SXTJ_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SXTJ.SelectedIndex < 0)
            {
                return;
            }

            string dataType = "";
            string select = "";
            switch (SJLX.Text)
            {
                case "刀具信息"://筛选条件列表为刀具类型
                    dataType = "dj";
                    select = string.Format("刀具类型='{0}'", SXTJ.Text.ToString());
                    break;
                case "零部件信息"://筛选条件列表为零部件名称
                    dataType = "lbj";
                    select = string.Format("零部件类型='{0}'", SXTJ.Text.ToString());
                    break;
                case "刀具柜信息"://筛选条件列表为刀具柜列表
                    dataType = "djg";
                    select = string.Format("刀具柜名称='{0}'", SXTJ.Text.ToString());
                    break;
                case "机床信息"://筛选条件列表为班组列表
                    dataType = "jc";
                    select = string.Format("所属班组='{0}'", SXTJ.Text.ToString());
                    break;
            }

            if (SXTJ.SelectedIndex == 0)//选择全部
            {
                dgv.DataSource = GetData(dataType);
            }
            else
            {
                dgv.DataSource = Alex.DataRowToDataTable(GetData(dataType).Select(select));
            }

            dgv_ColumnsReadOnly();
        }

        /// <summary>
        /// 指定表格列除首列外其他列不可编辑
        /// </summary>
        private void dgv_ColumnsReadOnly()
        {
            for (int i = 1; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].ReadOnly = true;
            }
        }

        /// <summary>
        /// 导出设置必须且只能选中一个
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckedChanged(object sender, EventArgs e)
        {
            if (AutoCheckFlag)
            {
                CheckBox crtbox = sender as CheckBox;//获取当前checkbox控件

                AutoCheckFlag = false;//避免switch语句中的代码重复调用CheckedChanged方法
                switch (crtbox.Name)
                {
                    case "chx_all":
                        chx_selected.Checked = !(chx_selected.Checked);
                        break;
                    case "chx_selected":
                        chx_all.Checked = !(chx_all.Checked);
                        break;
                }
                AutoCheckFlag = true;//switch语句中的代码执行完毕，可以重新调用此方法
            }
        }             

        /// <summary>
        /// 导出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_output_Click(object sender, EventArgs e)
        {
            dgv.EndEdit();

            //数据检查
            if(dgv.Rows.Count <= 0)
            {
                MessageBox.Show("没有数据可供保存！请选择数据类型。");
                return;
            }

            if(SaveAs())
            {
                MessageBox.Show("导出数据成功！");
            }
        }

        /// <summary>
        /// 另存新档按钮,导出Excel
        /// </summary>
        private bool SaveAs()
        {
            //string saveFileName = "";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export Excel File To导出Excel表格";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //saveFileName = saveFileDialog.FileName;
                //if (saveFileName.IndexOf(":") < 0) return false; //被点了取消
                Stream myStream;
                myStream = saveFileDialog.OpenFile();
                //StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
                StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
                string str = "";
                try
                {
                    //写标题
                    for (int i = 1; i < dgv.ColumnCount; i++)
                    {
                        if (i > 1)
                        {
                            str += "\t";
                        }
                        str += dgv.Columns[i].HeaderText;
                    }
                    sw.WriteLine(str);

                    //写内容:行循环内列循环
                    for (int j = 0; j < dgv.Rows.Count; j++)
                    {
                        //要么选择导出全部数据——导出每一行数据；要么选择导出选中数据——导出第一列值不为空且值为“true”（选中）的数据行
                        if (chx_all.Checked || (dgv.Rows[j].Cells[0].Value != null && dgv.Rows[j].Cells[0].Value.ToString() == "true"))
                        {
                            string tempStr = "";

                            //循环写入每一列
                            for (int k = 1; k < dgv.Columns.Count; k++)
                            {
                                if (k > 1)
                                {
                                    tempStr += "\t";
                                }
                                tempStr += dgv.Rows[j].Cells[k].Value.ToString();
                            }

                            sw.WriteLine(tempStr);
                        }
                    }
                    sw.Close();
                    myStream.Close();

                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return false;
                }
                finally
                {
                    sw.Close();
                    myStream.Close();
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 浏览按钮，加载excel文件路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            openFD.DefaultExt = "xls";
            openFD.Filter = "Excel 文件 xlsx|*.xlsx|xls|*.xls;";
            openFD.FilterIndex = 0;
            openFD.Title = "选择excel文件";
            if(openFD.ShowDialog() == DialogResult.OK)
            {
                if(openFD.FileName != "")
                {
                    filePath.Text = openFD.FileName;
                }
            }
            
        }

        /// <summary>
        /// 导入按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_input_Click(object sender, EventArgs e)
        {
            if(filePath.Text == "")
            {
                MessageBox.Show("请先选择要导入的数据文件！");
                btn_open.Focus();
                return;
            }

            choseSheet.Items.Clear();
            table_name.Clear();

            string FileName = filePath.Text.ToString();
            dgv.DataSource = null;
            DateTime f_time = DateTime.Now;

            DataSet ds = ExcelToSet(FileName);
            if (ds.Tables.Count == 0) return;
            try
            {
                foreach (string str in table_name)
                {
                    choseSheet.Items.Add(str);
                }

                choseSheet.SelectedIndex = 0;

                dgv.DataSource = ds.Tables[0].DefaultView;
            }
            catch
            {

            }

        }

        /// <summary>
        /// excel转换成dataset，来自Excel_Operate
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public DataSet ExcelToSet(string file)
        {
            DataSet dataset = new DataSet();

            try
            {
                IWorkbook workbook;
                string fileExt = Path.GetExtension(file).ToLower();
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    //XSSFWorkbook 适用XLSX格式，HSSFWorkbook 适用XLS格式
                    if (fileExt == ".xlsx")
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    else if (fileExt == ".xls")
                    {
                        workbook = new HSSFWorkbook(fs);
                    }
                    else
                    {
                        workbook = null;
                    }

                    if (workbook == null)
                    {
                        return null;
                    }

                    for (int count = 0; count < workbook.NumberOfSheets; count++)
                    {
                        DataTable dt = new DataTable();
                        ISheet sheet = workbook.GetSheetAt(count);
                        string name = sheet.SheetName;
                        table_name.Add(name);
                        dt.TableName = name;

                        //表头  
                        IRow header = sheet.GetRow(sheet.FirstRowNum);
                        List<int> columns = new List<int>();
                        if (header != null)
                        {
                            for (int i = 0; i < header.LastCellNum; i++)
                            {
                                object obj = GetValueType(header.GetCell(i));

                                if (obj == null || obj.ToString() == string.Empty)
                                {
                                    dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                                }
                                else
                                    dt.Columns.Add(new DataColumn(obj.ToString()));

                                columns.Add(i);
                            }
                        }

                        //数据  
                        for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                        {
                            DataRow dr = dt.NewRow();
                            bool hasValue = false;
                            IRow row = sheet.GetRow(i);
                            if (row != null)
                            {
                                foreach (int j in columns)
                                {
                                    if (GetValueType(sheet.GetRow(i).GetCell(j)) == null) dr[j] = "";
                                    else dr[j] = GetValueType(sheet.GetRow(i).GetCell(j));
                                    dr[j] = GetValueType(sheet.GetRow(i).GetCell(j));
                                    if (dr[j] != null && dr[j].ToString() != string.Empty)
                                    {
                                        hasValue = true;
                                    }
                                }
                                if (hasValue)
                                {
                                    dt.Rows.Add(dr);
                                }
                            }
                        }
                        dataset.Tables.Add(dt);
                    }
                }
            }
            catch
            {
                MessageBox.Show("该文件是否处于打开状态？");
            }
            return dataset;
        }

        /// <summary>
        /// 获取单元格类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object GetValueType(ICell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank: //BLANK:  
                    return null;
                case CellType.Boolean: //BOOLEAN:  
                    return cell.BooleanCellValue;
                case CellType.Numeric: //NUMERIC:  
                    return cell.NumericCellValue;
                case CellType.String: //STRING:  
                    return cell.StringCellValue;
                case CellType.Error: //ERROR:  
                    return cell.ErrorCellValue;
                case CellType.Formula: //FORMULA:  
                default:
                    return "=" + cell.CellFormula;
            }
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            if(cbx_inputDataType.SelectedItem == null || cbx_inputDataType.Text == "")
            {
                MessageBox.Show("请先选择要导入的数据类型！");
                cbx_inputDataType.DroppedDown = true;
                return;
            }

            string inputDataType = "";
            switch(cbx_inputDataType.SelectedItem.ToString())
            {
                case "刀具信息"://导入数据为刀具信息
                    inputDataType = "dj";
                    break;
                case "零部件信息"://导入数据为零部件信息
                    inputDataType = "lbj";
                    break;
                case "刀具柜信息"://导入数据为刀具柜信息
                    inputDataType = "djg";
                    break;
                case "机床信息"://导入数据为班组列表
                    inputDataType = "jc";
                    break;
            }
        }

        private void SaveToDatabase(string dataType)
        {
            if(dgv.Rows.Count <= 0)
            {
                MessageBox.Show("导入数据不可为空！");
                return;
            }

            string tablename = "";
            string columns = "";
            string values = "";
            int i = 1;
            switch (dataType)
            {
                case "dj"://导入数据为刀具信息
                    tablename = DaoJuTemp.TableName;
                    if (dgvAddColumnName("刀具ID", "djid"))
                    {
                        columns += DaoJuTemp.id;
                        values += "'{" + i.ToString() + "}'";
                        i++;
                    }
                    if (dgvAddColumnName("刀具型号", "djxh"))
                    {
                        columns += DaoJuTemp.xinghao;
                        values += "'{" + i.ToString() + "}'";
                        i++;
                    }
                    if (dgvAddColumnName("刀具规格", "djgg"))
                    {
                        columns += DaoJuTemp.guige;
                        values += "'{" + i.ToString() + "}'";
                        i++;
                    }
                    if (dgvAddColumnName("刀具类型", "djlx"))
                    {
                        columns += DaoJuTemp.leixing;
                        values += "'{" + i.ToString() + "}'";
                        i++;
                    }
                    if (dgvAddColumnName("刀具寿命", "djsm"))
                    {
                        columns += DaoJuTemp.shouming;
                        values += "'{" + i.ToString() + "}'";
                        i++;
                    }
                    if (dgvAddColumnName("刀具位置", "djwz"))
                    {
                        columns += DaoJuTemp.weizhibianma;
                        values += "'{" + i.ToString() + "}'";
                        i++;
                    }
                    if (dgvAddColumnName("层数或者刀套号", "cs"))
                    {
                        columns += DaoJuTemp.csordth;
                        values += "'{" + i.ToString() + "}'";
                        i++;
                    }
                    if (dgvAddColumnName("位置标识", "wzbs"))
                    {
                        columns += DaoJuTemp.weizhibiaoshi;
                        values += "'{" + i.ToString() + "}'";
                        i++;
                    }
                    if (dgvAddColumnName("类型", "lx"))
                    {
                        columns += DaoJuTemp.type;
                        values += "'{" + i.ToString() + "}'";
                        i++;
                    }
                    if (dgvAddColumnName("库存数量", "kcsl"))
                    {
                        columns += DaoJuTemp.kcsl;
                        values += "'{" + i.ToString() + "}'";
                        i++;
                    }
                    if (dgvAddColumnName("最小库存", "zxkc"))
                    {
                        columns += DaoJuTemp.zxkc;
                        values += "'{" + i.ToString() + "}'";
                        i++;
                    }
                    if (dgvAddColumnName("最大库存", "zdkc"))
                    {
                        columns += DaoJuTemp.zdkc;
                        values += "'{" + i.ToString() + "}'";
                        i++;
                    }
                    if (dgvAddColumnName("备注", "beizhu"))
                    {
                        columns += DaoJuTemp.bz;
                        values += "'{" + i.ToString() + "}'";
                        i++;
                    }
                    //columns = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}", DaoJuTemp.id, DaoJuTemp.xinghao, DaoJuTemp.guige, DaoJuTemp.leixing, DaoJuTemp.shouming, DaoJuTemp.weizhibianma, DaoJuTemp.csordth, DaoJuTemp.weizhibiaoshi, DaoJuTemp.type, DaoJuTemp.kcsl, DaoJuTemp.zxkc, DaoJuTemp.zdkc, DaoJuTemp.bz);
                    //values = "'{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}'";
                    break;
                case "lbj"://导入数据为零部件信息
                    tablename = LingBuJianBiao.TableName;
                    columns = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}", LingBuJianBiao.mc, LingBuJianBiao.xinghao, LingBuJianBiao.gg, LingBuJianBiao.shouming, LingBuJianBiao.weizhibianma, LingBuJianBiao.cengshu, LingBuJianBiao.weizhibiaoshi, LingBuJianBiao.type, LingBuJianBiao.kcsl, LingBuJianBiao.dw, LingBuJianBiao.zxkc, LingBuJianBiao.zdkc, LingBuJianBiao.bz);
                    values = "'{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}'";
                    break;
                case "djg"://导入数据为刀具柜信息
                    tablename = DaoJuGui.TableName;

                    if (dgvAddColumnName("刀具柜名称", "djgmc"))
                    {
                        columns += DaoJuGui.djgmc;
                        values += "'{" + i.ToString() + "}'";
                        i++;
                    }
                    if (dgvAddColumnName("刀具柜类型", "djglx"))
                    {
                        columns += DaoJuGui.djglx;
                        values += "'{" + i.ToString() + "}'";
                        i++;
                    }
                    //columns = string.Format("{0}, {1}", DaoJuGui.djgmc, DaoJuGui.djglx);
                    //values = "'{1}', '{2}'";
                    break;
                case "jc"://导入数据为班组列表
                    tablename = JiChuangBiao.TableName;
                    columns = string.Format("{0}, {1}, {2}, {3}, {4}", JiChuangBiao.ssbz, JiChuangBiao.scx, JiChuangBiao.jcbm, JiChuangBiao.jclx, JiChuangBiao.zcbh);
                    values = "'{1}', '{2}', '{3}', '{4}', '{5}'";
                    break;
            }

            SqlStr = "";
            string value = "";
            for (int j = 0; j < dgv.Rows.Count; j++)
            {
                value = "";

                SqlStr += string.Format("INSERT INTO {0}(" + columns + ") VALUES(" + values + ");", tablename);
            }
        }

        /// <summary>
        /// 判断datagridview是否存在表头名为headertext的列，若存在，则将其名字改为name
        /// </summary>
        /// <param name="headertext">表头名称</param>
        /// <param name="name">要修改的列名</param>
        /// <returns>存在且修改成功返回true，否则返回false</returns>
        private bool dgvAddColumnName(string headertext, string name)
        {
            for(int i = 0; i < dgv.Columns.Count; i++)
            {
                if(dgv.Columns[i].HeaderText == headertext)
                {
                    dgv.Columns[i].Name = name;
                    return true;
                }
            }

            return false;
        }
               

        /// <summary>
        /// 表格绘制行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Alex.RowPostPaint(dgv, e);
        }

        /// <summary>
        /// 工作表选择变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void choseSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txt_index.Text = "";
            //try
            //{
            //    DataTable d_table = Get_Table(ds.Tables[choseSheet.SelectedIndex], txt_index.Text);
            //    info_refresh(d_table);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
        }

        /// <summary>
        /// tabpage页选择变化，还原上一次选择状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //表格数据源清空
            dgv.DataSource = null;

            if(tabControl1.SelectedTab.Text == "数据导出")
            {
                groupBox3.Visible = true;
                if(SJLX.Text != "")
                {
                    string sxtj = SXTJ.Text;

                    //加载数据
                    comboBox1_SelectedIndexChanged(null, null);

                    //还原筛选状态
                    if(sxtj != "全部")
                    {
                        SXTJ.SelectedItem = sxtj;
                        SXTJ_SelectedIndexChanged(null, null);
                    }
                }
            }
            else if(tabControl1.SelectedTab.Text == "数据导入")
            {
                groupBox3.Visible = false;

            }
        }
    }
}
