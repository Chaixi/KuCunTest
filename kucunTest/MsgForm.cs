using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kucunTest
{
    public partial class MsgForm : Form
    {
        private string TitleText = "";
        private string ContentText = "";

        public MsgForm(string content, string title = "提示")
        {
            InitializeComponent();

            this.Text = "刀具管理系统提示";
            //label_title.Text = title;
            //label_title.Text = "";
            //label_content.Text = ContentText;
            SetContent(content, title);
        }

        public void SetContent(string text, string title = "提示")
        {
            label_title.Text = title;
            label_content.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
