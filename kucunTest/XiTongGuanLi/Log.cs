using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace kucunTest.XiTongGuanLi
{
    public partial class Log : Form
    {
        #region 全局变量
        string LogFilePath = string.Format("{0}\\LogFile\\{1}", Program._PATH, DateTime.Now.ToString("yyyy"));//系统日志文件夹路径
        #endregion 全局变量结束

        /// <summary>
        /// 构造函数
        /// </summary>
        public Log()
        {
            InitializeComponent();

            //设置可选择的最大最小日期
            dtp_dateChose.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            dtp_dateChose.MaxDate = DateTime.Now;
        }

        /// <summary>
        /// 窗体加载函数，默认加载当前日期的日志
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Log_Load(object sender, EventArgs e)
        {
            btn_loadLog_Click(null, null);
        }

        /// <summary>
        /// 加载日志按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_loadLog_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string LogFileName = dtp_dateChose.Value.ToString("yyyyMMdd") + ".txt";

            if(File.Exists(LogFilePath + "\\" + LogFileName) == false)
            {
                MessageBox.Show("日志文件不存在，请重新选择日期", Program.tishiTitle);
                return;
            }

            LoadLogFile(LogFilePath + "\\" + LogFileName);
        }

        /// <summary>
        /// 加载文本文件
        /// </summary>
        /// <param name="path"></param>
        private void LoadLogFile(string path)
        {
            string[] log = File.ReadAllLines(path, System.Text.Encoding.Default);

            foreach(string l in log)
            {
                if(l != "")
                {
                    listBox1.Items.Add(l);
                }
            }

            //滚动到底部
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            listBox1.SelectedIndex = -1;

            //StreamReader sR = new StreamReader(path, Encoding.UTF8);

            ////FileStream fS = new FileStream(@"C:\temp\a.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            ////StreamReader sR3 = new StreamReader(fS);
            ////StreamReader sR4 = new StreamReader(fS, Encoding.UTF8);

            ////FileInfo myFile = new FileInfo(@"C:\temp\a.txt");
            ////// OpenText 创建一个UTF-8 编码的StreamReader对象 
            ////StreamReader sR5 = myFile.OpenText();
            ////// OpenText 创建一个UTF-8 编码的StreamReader对象 
            ////StreamReader sR6 = File.OpenText(@"C:\temp\a.txt");

            ////一行一行读取
            //string nextLine = sR.ReadLine();


            ////关闭流
            //StreamReader sR = File.OpenText(@"C:\temp\a.txt");
            //string nextLine;
            //while ((nextLine = sR.ReadLine()) != null)
            //{
            //    Console.WriteLine(nextLine);
            //}
            //sR.Close();
        }

        /// <summary>
        /// 打开系统日志文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_openExplorer_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("ExpLorer.exe", LogFilePath);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 当窗体在选项卡中打开时，关闭窗体则关闭相应的选项卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Log_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Parent != null)
            {
                MainForm mfr = (MainForm)this.Parent.FindForm();
                mfr.CloseTab(this.Name);
            }
        }

        
    }
}
