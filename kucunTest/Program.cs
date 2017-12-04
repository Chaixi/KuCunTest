using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using kucunTest.JiChuZiLiao;
using System.IO;

namespace kucunTest
{
    static class Program
    {
        //static string logFileName = string.Format("{0}-{1}-{2}", DateTime.Now.Year.ToString("yyyy"), DateTime.Now.Month.ToString("mm"), DateTime.Now.Day.ToString("dd"));
        static string logFileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";
        public static string _PATH = System.Windows.Forms.Application.StartupPath.ToString();

        public static string tishiTitle = "刀具管理系统提示";

        private static string crtusername;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Program.WriteLog("登录", "用户"+ "厦门大学（超级管理员）" +"登录成功，打开主窗体。");
            //Application.Run(new MainForm());
            Application.Run(new LoginForm());
            //Application.Run(new test());
            //Application.Run(new shujudaorudaochu());
            Program.WriteLog("退出", "关闭主窗体。");            
        }

        /// <summary>
        /// 用户名全局变量
        /// </summary>
        public static string CurrentUserName
        {
            get
            {
                return crtusername;
            }
            set
            {
                crtusername = value;
            }
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public static void WriteLog(string type, string message)
        {
            //判断日志文件夹是否存在，若不存在则新建
            string logFilePath = _PATH;
            if (Directory.Exists(logFilePath + "\\LogFile") == false)
            {
                Directory.CreateDirectory(logFilePath + "\\LogFile");
            }

            logFilePath += "\\LogFile\\";

            if (Directory.Exists(logFilePath + DateTime.Now.ToString("yyyy")) == false)
            {
                Directory.CreateDirectory(logFilePath + DateTime.Now.ToString("yyyy"));
            }

            logFilePath += DateTime.Now.ToString("yyyy") + "\\";

            //判断文件是否存在
            if (File.Exists(logFilePath+logFileName) == false)
            {
                File.AppendAllText(logFilePath + logFileName, "[操作时间]\t\t\t操作用户(角色)\t\t操作类型\t\t操作详情\r\n", System.Text.Encoding.Default);
            }

            string text = string.Format("\r\n[{0}]\t{1}\t\t{2}\t\t{3} ", DateTime.Now, "厦门大学(超级管理员)", type, message); // 用制表符 \t 分隔字段
            File.AppendAllText(logFilePath + logFileName, text, System.Text.Encoding.Default);
        }

    }
}