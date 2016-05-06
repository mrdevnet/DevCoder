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

namespace DevNETCoder
{
    public partial class ProgressBar : DevExpress.XtraEditors.XtraForm
    {
        public static DataTable _listP;
        public static bool _kiped = true;
        public ProgressBar()
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

        private void ProgressBar_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
        private string ResultExecuting(string Proc,bool kip)
        {
           
            string script = "", result = "", cmd = "", tbname ="";
             cmd = Proc.Substring(Proc.LastIndexOf("_") + 1).ToLower();
             tbname = Proc.Substring(0,Proc.LastIndexOf("_"));
            switch (cmd)
            {
                case "insert": script = Procedures.Insert(RunSave.DatabaseQ.Tables[tbname]); break;
                case "update": script = Procedures.Update(RunSave.DatabaseQ.Tables[tbname]); break;
                case "selectall": script = Procedures.SelectAll(RunSave.DatabaseQ.Tables[tbname]); break;
                case "delete": script = Procedures.Delete(RunSave.DatabaseQ.Tables[tbname]); break;
                case "selectpage": script = Procedures.SelectPage(RunSave.DatabaseQ.Tables[tbname]); break;
                case "selecttop": script = Procedures.SelectTop(RunSave.DatabaseQ.Tables[tbname]); break;
                case "selectbyid": script = Procedures.SelectByID(RunSave.DatabaseQ.Tables[tbname]); break;
                case "testbyid": script = Procedures.TestByID(RunSave.DatabaseQ.Tables[tbname]); break;
            }
          
           script =  SForm.MainForm.returnQW() + script;
          
            SqlConnection objConnection = new SqlConnection(RunSave.DBConnect);
            SqlCommand command = new SqlCommand(script, objConnection);
            command.CommandType = CommandType.Text;
            try// tạo mới
            {
                objConnection.Open();
                command.ExecuteNonQuery();
                result = "Create";
                objConnection.Close();
            }
            catch (SqlException ex)
            {
                if(ex.Number == 2714)//nếu lỗi lập lại
                {
                    if(!kip)//cho phép ghi đè
                    {
                            string pattern ;//= "There is already an object named '(.*)' in the database";
                                        Regex myRegex ;//= new Regex(pattern);
                                        Match m; //= myRegex.Match(resurt);

                                        string[] line = script.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                                        script = "";
                                        bool kt = false;
                                        for (int i = 0; i < line.Length; i++)
                                        {
                                            if (line[i].Trim().StartsWith("--") == false && kt == false && line[i].Length > 0)
                                            {
                                                pattern = "[Cc]reate";
                                                myRegex = new Regex(pattern);
                                                m = myRegex.Match(line[i]);
                                                if (m.Index > -1)
                                                {
                                                    line[i] = line[i].Remove(m.Index, m.Value.Length);
                                                    line[i] = line[i].Insert(m.Index, "Alter");
                                                    kt = true;
                                                }
                                            }
                                            script += line[i] + "\r\n";
                                        }
                                         objConnection = new SqlConnection(RunSave.DBConnect);
                                         command = new SqlCommand(script, objConnection);
                                         command.CommandType = CommandType.Text;
                            try 
	                        {
                                    objConnection.Open();
		                            command.ExecuteNonQuery();
                                    result = "Replace";
                                    objConnection.Close();
	                        }
                            catch 
	                        {
		                         result = "Error";
	                        }
                    }//không cho phép ghi đè
                    else result = "Skip";
                }
                else// không phai lỗi lặp lại
                    result = "Error";
            }

            return  result;
        }
        private void ProgressBar_Load(object sender, EventArgs e)
        {
            gri.Visible = false;
            this.Height = 95;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_listP == null) { this.Close(); return; }

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
            this.Close();
            SForm.ProgressBarForm = new ProgressBar();
        }
    }
}