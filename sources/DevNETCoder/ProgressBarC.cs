using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevNETCoder.Static;
using StringLayer;
using System.Text.RegularExpressions;
using DevExpress.XtraGrid.Columns;
using Tools;
using System.IO;

namespace DevNETCoder
{
    public partial class ProgressBarC : DevExpress.XtraEditors.XtraForm
    {
        public static DataTable _listP;
        public static bool _kiped = true;
        public static string _path ="";
        public ProgressBarC()
        {
            InitializeComponent();
        }

        public DataTable listP
        {
            set { _listP = value; }
        }
        public bool Kiped
        {
            set { _kiped = value; }
        }
        public string path
        {
            set { _path = value; }
        }

        private void ProgressBar_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private string ResultExecuting(string Proc,bool kip)
        {
           
            string script = "", result = "", cmd = "", tbname ="";
             tbname = Proc.Substring(Proc.LastIndexOf(":") + 1);
             cmd = Proc.Substring(0,Proc.LastIndexOf(":")).ToLower();
            switch (cmd)
            {
                case "entities": script = Entities.Info(RunSave.DatabaseC.Tables[tbname]); break;
                case "business": script = Business.Info(RunSave.DatabaseC.Tables[tbname]); break;
                case "dataaccess":
                    {
                        if (tbname == "DataAccess") script = DataAccess.Info();
                        else script = ConnectionString.Info();
                    }break;
            }

            if (script == " Can not create object !") return "Errol";
            script =  SForm.MainForm.returnQC() + script;
            string pathcs = _path + @"\Data\" + Proc.Replace(":", @"\") + ".cs";
            if (File.Exists(pathcs))
                if (kip)
                    result = "Skip";
                else
                {
                    Folder.CreateFile(pathcs, script);
                    result = "Replace";
                }
            else
            {
                Folder.CreateFile(pathcs, script);
                result = "Success";
            }
               
            return  result;
        }
        private void ProgressBar_Load(object sender, EventArgs e)
        {
            gri.Visible = false;
            this.Height = 95;
           // gri.DataSource = _listP;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_listP == null) { this.Close(); return; }

                Folder.CreateFolder(_path + @"\Data");
                Folder.CreateFolder(_path + @"\Data\Business");
                Folder.CreateFolder(_path + @"\Data\DataAccess");
                Folder.CreateFolder(_path + @"\Data\Entities");

                loading.Properties.Maximum = _listP.Rows.Count;
                loading.Properties.Minimum = 0;
                loading.Properties.Step = 1;
                loading.Properties.PercentView = true;
                gri.DataSource = _listP;

                for (int i = 0; i < _listP.Rows.Count; i++)
                {
                    if (_listP.Rows[i]["Result"].ToString() == "Action")
                    {
                        _listP.Rows[i]["Result"] = ResultExecuting(_listP.Rows[i]["Name"].ToString(), _kiped);

                    }
                    lbPro.Text = _listP.Rows[i]["Name"].ToString();
                    lbPro.Update();
                    loading.PerformStep();
                    loading.Update();
                }

                lbPro.Text = "Result";
                btF.Enabled = true;
                gri.Visible = true;
                this.Height = 270;
                timer1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            
        }

        private void btF_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                SForm.ProgressBarCForm = new ProgressBarC();
                System.Diagnostics.Process.Start("explorer.exe", _path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
        }
    }
}