using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevNETCoder.Static;
using System.Data.SqlClient;
using StringLayer;

namespace DevNETCoder
{
    public partial class CreateList : DevExpress.XtraEditors.XtraForm
    {
        public CreateList()
        {
            InitializeComponent();
        }

        private void CreateList_Load(object sender, EventArgs e)
        {
            try
            {
                loading.Properties.Minimum = 0;
                loading.Update();
                if (RunSave.TableRun != null)
                {
                    string name = RunSave.TableRun.Name;
                    checkEdit1.Text = string.Format("{0}_Insert", name);
                    checkEdit2.Text = string.Format("{0}_Update", name);
                    checkEdit3.Text = string.Format("{0}_Delete", name);
                    checkEdit4.Text = string.Format("{0}_SelectAll", name);
                    checkEdit5.Text = string.Format("{0}_Paging", name);
                    checkEdit6.Text = string.Format("{0}_SelectTop", name);
                    checkEdit7.Text = string.Format("{0}_SelectById", name);
                    checkEdit8.Text = string.Format("{0}_TestById", name);

                    gr1.Text = string.Format("Procedures of {0}", name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            try
            {
                btOK.Text = "Loading...";
                btOK.Enabled = false;
                btC.Enabled = false;


                loading.Properties.Maximum = 8;
                loading.Properties.Minimum = 0;
                loading.Properties.Step = 1;
                loading.Properties.PercentView = true;

                //DevExpress.XtraEditors.CheckEdit cbe = (DevExpress.XtraEditors.CheckEdit)this.Controls.Find("checkEdit1",true)[0];
                //cbe.Checked = false;
                EXEcute(Procedures.Insert(RunSave.TableRun), rd.SelectedIndex, checkEdit1.Text, checkEdit1.Checked);
                loading.PerformStep();
                EXEcute(Procedures.Update(RunSave.TableRun), rd.SelectedIndex, checkEdit2.Text, checkEdit2.Checked);
                loading.PerformStep();
                EXEcute(Procedures.Delete(RunSave.TableRun), rd.SelectedIndex, checkEdit3.Text, checkEdit3.Checked);
                loading.PerformStep();
                EXEcute(Procedures.SelectAll(RunSave.TableRun), rd.SelectedIndex, checkEdit4.Text, checkEdit4.Checked);
                loading.PerformStep();
                EXEcute(Procedures.SelectPage(RunSave.TableRun), rd.SelectedIndex, checkEdit5.Text, checkEdit5.Checked);
                loading.PerformStep();
                EXEcute(Procedures.SelectTop(RunSave.TableRun), rd.SelectedIndex, checkEdit6.Text, checkEdit6.Checked);
                loading.PerformStep();
                EXEcute(Procedures.SelectByID(RunSave.TableRun), rd.SelectedIndex, checkEdit7.Text, checkEdit7.Checked);
                loading.PerformStep();
                EXEcute(Procedures.TestByID(RunSave.TableRun), rd.SelectedIndex, checkEdit8.Text, checkEdit8.Checked);
                loading.PerformStep();

                btOK.Text = "Execute";
                btOK.Enabled = true;
                btC.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            
            
        }
        private void EXEcute(string cmd,int indexErr,string prod,bool run)
        {
            if (!run) return;

            cmd =  SForm.MainForm.returnQW() + cmd;
            
            SqlConnection objConnection = new SqlConnection(Save.DBConnect);
            SqlCommand command = new SqlCommand(cmd, objConnection);
            command.CommandType = CommandType.Text;
            try
            {
                objConnection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                string resurt = "Cannot Create StoredProcedure \r\n Details: " + ex.ToString();

                if (ex.Number == 2714)
                {
                    switch (indexErr)
                    {
                        case 0: 
                            {
                                string pattern ;//= "There is already an object named '(.*)' in the database";
                                Regex myRegex ;//= new Regex(pattern);
                                Match m; //= myRegex.Match(resurt);

                                string[] line = cmd.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                                cmd = "";
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
                                    cmd += line[i] + "\r\n";
                                }

                                EXEcute(cmd, indexErr, prod, true);

                               // DialogResult yn = MessageBox.Show(string.Format("{0}\r\nDo you like to replace the existing procedure ?", m.Value), "Create Procedures", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                               // if (yn == DialogResult.Yes)
                               // {
                              //      pattern = "create";
                              //      myRegex = new Regex(pattern);
                              //      m = myRegex.Match(cmd.ToLower());
                              //      string cmds = cmd.Remove(m.Index, m.Value.Length);
                              //      cmds = cmds.Insert(m.Index, "Alter");
                              //      EXEcute(cmds, indexErr,prod,true);
                              ////  }
                            } break;
                        case 2:
                                {
                                    string pattern = "There is already an object named '(.*)' in the database";
                                    Regex myRegex = new Regex(pattern);
                                    Match m = myRegex.Match(resurt);

                                     DialogResult yn = MessageBox.Show(string.Format("{0}\r\nDo you like to replace the existing procedure ?", m.Value), "Create Procedures", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                     if (yn == DialogResult.Yes)
                                     {
                                         string[] line = cmd.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                                         cmd = "";
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
                                             cmd += line[i] + "\r\n";
                                         }

                                         EXEcute(cmd, indexErr, prod, true);
                                     }
                                }break;
                    }
                    

                }
                else
                    MessageBox.Show(resurt);

            }
            finally
            {
                objConnection.Close();
            }

        }

        private void CreateList_FormClosed(object sender, FormClosedEventArgs e)
        {
            RunSave.TableRun = null;
        }

        private void btC_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

       
    }
}
