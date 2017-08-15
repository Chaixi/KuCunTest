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

namespace kucunTest
{
    public partial class test : Form
    {
        BaseAlex Alex = new BaseAlex();
        AutoSizeFormClass asc = new AutoSizeFormClass();

        public test()
        {
            InitializeComponent();
        }

        private void test_Load(object sender, EventArgs e)
        {
            //asc.controllInitializeSize(this);
        }

        private void test_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);
        }


    }
}
