using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

using kucunTest.BaseClasses;

namespace kucunTest.quanxianguanli
{
    class Authorize
    {
        private MySql SQL = new MySql();
        private string SqlStr = "";

        private BaseAlex Alex = new BaseAlex();
        private string username = "";

        public void setAuthority(object frm, string frmName)
        {
            //username = Alex.CurrentUserName;
            username = Program.CurrentUserName;

            switch(frmName)
            {
                case "MainForm":
                    MainForm crtFrm = (MainForm)frm;
                    setMainForm(crtFrm);
                    break;
            }
        }

        private void setMainForm(MainForm frm)
        {
            //SqlStr = string.Format("SELECT * FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' )", QuanXianGroup.TableName, QuanXianGroup.groupName, User.groupName, User.TableName, User.name, username);
            SqlStr = string.Format("SELECT * FROM {0} g WHERE g.{1} = (SELECT u.{2} FROM `{3}` u WHERE u.`{4}` = '{5}' ) AND g.{6} = '{7}'", "quanxian", "qxgroup", User.groupName, User.TableName, User.name, username, "qxfm", frm.Name);
            DataTable db = SQL.getDataSet1(SqlStr).Tables[0];

            for(int j = 0; j < db.Rows.Count; j++)
            {
                switch (db.Rows[j]["qxdm"].ToString())
                {
                    case "ToolStripMenuItem_dj":
                        frm.ToolStripMenuItem_dj.Enabled = Convert.ToBoolean(db.Rows[j]["qxzt"]);
                        break;
                    case "ToolStripMenuItem_lbj":
                        frm.ToolStripMenuItem_lbj.Enabled = Convert.ToBoolean(db.Rows[j]["qxzt"]);
                        break;
                    case "ToolStripMenuItem_djg":
                        frm.ToolStripMenuItem_djg.Enabled = Convert.ToBoolean(db.Rows[j]["qxzt"]);
                        break;
                    case "ToolStripMenuItem_jc":
                        frm.ToolStripMenuItem_jc.Enabled = Convert.ToBoolean(db.Rows[j]["qxzt"]);
                        break;
                    case "ToolStripMenuItem_gyk":
                        frm.ToolStripMenuItem_gyk.Enabled = Convert.ToBoolean(db.Rows[j]["qxzt"]);
                        break;
                    case "ToolStripMenuItem_jczl":
                        frm.ToolStripMenuItem_jczl.Enabled = Convert.ToBoolean(db.Rows[j]["qxzt"]);
                        break;
                    case "ToolStripMenuItem_xtgl":
                        frm.ToolStripMenuItem_xtgl.Enabled = Convert.ToBoolean(db.Rows[j]["qxzt"]);
                        break;
                }
            }

            //foreach(Control c in frm.Controls)
            //{
            //    if(c is ToolStripMenuItem)
            //    {
            //        for(int i = 0; i < db.Rows.Count; i++)
            //        {
            //            if(c.Name == db.Rows[i]["qxdm"].ToString())
            //            {
            //                switch (Convert.ToInt32(db.Rows[i]["qxzt"].ToString()))
            //                {
            //                    case 0:
            //                        c.Enabled = false;
            //                        break;
            //                    case 1:
            //                        c.Enabled = true;
            //                        break;
            //                }

            //                break;
            //            }
            //        }
            //    }
            //}

            //frm.ToolStripMenuItem_dj.Enabled = false;
            //frm.ToolStripMenuItem_lbj.Enabled = false;
            //frm.ToolStripMenuItem_djg.Enabled = true;
            //frm.ToolStripMenuItem_jc.Enabled = true;
            //frm.ToolStripMenuItem_gyk.Enabled = true;
            //frm.ToolStripMenuItem_jczl.Enabled = false;
            //frm.ToolStripMenuItem_xtgl.Enabled = false;

        }
    }
}
