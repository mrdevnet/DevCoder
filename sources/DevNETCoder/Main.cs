using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Microsoft.SqlServer.Management.Smo;
using System.Collections;
using System.Data.SqlClient;
using DevNETCoder.Static;
using StringLayer;
using ConvertType;
using Tools;
using DevNETUI;

namespace DevNETCoder
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Database db ; 
        public Main()
        {        
            InitializeComponent();
            
        }
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            
           
        }

        public void LoadDatabase()
        {
            if (Save.Servers == null) return;
            cbDB.Properties.Items.Clear();
            listDB.Items.Clear();
            listDBC.Items.Clear();
            foreach (Database db in Save.SVName.Databases)
            {
                if (!db.IsSystemObject)
                {
                    cbDB.Properties.Items.Add(db.Name);
                    listDB.Items.Add(db.Name);
                    listDBC.Items.Add(db.Name);
                }

            }
            cbDB.SelectedIndex = 0;
        }

       

        public string returnQW()
        {
            if (txtSW.EditValue.ToString() == "") return "";
            string[] lines = Regex.Split(txtSW.EditValue.ToString(), "\r\n");
            string resurt = "--============================\r\n";
            foreach (string line in lines)
            {
                resurt += string.Format("-- {0}\r\n", line);
            }
            resurt += "--============================\r\n";

            return resurt;
        }
        public string returnQC()
        {
            if (txtSC.EditValue.ToString() == "") return "";
            string[] lines = Regex.Split(txtSC.EditValue.ToString(), "\r\n");
            string resurt = "//============================\r\n";
            foreach (string line in lines)
            {
                resurt += string.Format("// {0}\r\n", line);
            }
            resurt += "//============================\r\n";

            return resurt;
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            SForm.LoginForm.Hide();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void cbDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTable();
                string copyright = string.Format("Author: DevNETCoder @ {0:yyyy}\r\nCreate date: {0:dd/MM/yyy}\r\nProject: {1}\r\nDescription: Auto-code", DateTime.Now, cbDB.Text);
                txtSC.EditValue = txtSQ.EditValue = txtSW.EditValue = copyright;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            
        }
        void LoadTable()
        {
            listTable.SelectedIndex = -1;
            Save.DBName = cbDB.Text;
            db = Save.SVName.Databases[Save.DBName];
            Save.DBConnect = Save.Connection + ";database=" + cbDB.Text;

            ArrayList table = Save.GetTable(Save.DBName);

            loading.Properties.Maximum = table.Count;
            loading.Properties.Minimum = 0;
            loading.Properties.Step = 1;
            loading.Properties.PercentView = true;

            listTable.Items.Clear();
            
            for (int i = 0; i < table.Count; i++)
            {
                listTable.Items.Add(table[i].ToString());
                loading.PerformStep();
                loading.Update();
            }
            listTable.SelectedIndex = 0;
            lbTable.Text = "Tables : " + table.Count.ToString();
            
            
        }
        private void btI_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
             txtE.EditValue = txtC.EditValue ="";
             SetSQ();
          
             txtC.EditValue += Procedures.Insert(db.Tables[listTable.Text]);
            }
            catch
            {

                txtE.EditValue = "Cannot create Procedures";
                
            }
        }
        private void btU_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
             txtE.EditValue = txtC.EditValue ="";
             SetSQ();
            
                txtC.EditValue += Procedures.Update(db.Tables[listTable.Text]);

            }
            catch
            {

                txtE.EditValue = "Cannot create Procedures";
            }
        }

        private void btD_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
             txtE.EditValue = txtC.EditValue ="";
             SetSQ();
            
                txtC.EditValue += Procedures.Delete(db.Tables[listTable.Text]);

            }
            catch
            {

                txtE.EditValue = "Cannot create Procedures";
            }
        }

        private void btSA_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
             txtE.EditValue = txtC.EditValue ="";
             SetSQ();
            
                txtC.EditValue += Procedures.SelectAll(db.Tables[listTable.Text]);

            }
            catch
            {

                txtE.EditValue = "Cannot create Procedures";
            }
        }
        private void btP_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
            txtE.EditValue = txtC.EditValue = "";
            SetSQ();
            
                txtC.EditValue += Procedures.SelectPage(db.Tables[listTable.Text]);

            }
            catch
            {

                txtE.EditValue = "Cannot create Procedures";
            }
        }

        private void btST_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
             txtE.EditValue = txtC.EditValue ="";
             SetSQ();
            
                txtC.EditValue += Procedures.SelectTop(db.Tables[listTable.Text]);

            }
            catch
            {

                txtE.EditValue = "Cannot create Procedures";
            }
        }

        private void btSB_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
             txtE.EditValue = txtC.EditValue ="";
             SetSQ();
            
                txtC.EditValue += Procedures.SelectByID(db.Tables[listTable.Text]);

            }
            catch
            {

                txtE.EditValue = "Cannot create Procedures";
            }
        }

        private void btTB_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
             txtE.EditValue = txtC.EditValue ="";
             SetSQ();
           
                txtC.EditValue += Procedures.TestByID(db.Tables[listTable.Text]);

            }
            catch
            {

                txtE.EditValue = "Cannot create Procedures";
            }
        }

        private void btE_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtC.Text)) { MessageBox.Show("Please insert content ! ", "Execute Procedures", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                EXEcute(txtC.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            
        }
        private void EXEcute(string cmd)
        {
            SqlConnection objConnection = new SqlConnection(Save.DBConnect);
            SqlCommand command = new SqlCommand(cmd, objConnection);
            command.CommandType = CommandType.Text;
            try
            {
                objConnection.Open();
                command.ExecuteNonQuery();
               txtE.EditValue =  "Completed successfully!";
            }
            catch (SqlException ex)
            {
                string resurt = "Cannot Create StoredProcedure \r\n Details: " + ex.ToString();

                if (ex.Number == 2714)
                {
                    txtE.EditValue = resurt;
                    string pattern = "There is already an object named '(.*)' in the database";
                    Regex myRegex = new Regex(pattern);
                    Match m = myRegex.Match(resurt);

                    DialogResult yn = MessageBox.Show(string.Format("{0}\r\nDo you like to replace the existing procedure ?", m.Value), "Create Procedures", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (yn == DialogResult.Yes)
                    {
                        string[] line = cmd.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                        cmd = "";
                        bool kt = false;
                        for (int i = 0; i < line.Length; i++ )
                        {
                            if (line[i].Trim().StartsWith("--") == false && kt == false && line[i].Length >0)
                            {
                                pattern = "[Cc][Rr][Ee][Aa][Tt][Ee]";
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

                        txtC.Text = cmd;
                        EXEcute(cmd);
                    }

                }
                else
                    txtE.EditValue = resurt;

            }
            finally
            {
                objConnection.Close();
            }

        }

        private void btEA_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                RunSave.TableRun = db.Tables[listTable.Text];
                SForm.CreateListForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
        }

        private void btCE_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
            txtE.EditValue = txtC.EditValue ="";
            SetSC();
            
                txtC.EditValue += Entities.Info(db.Tables[listTable.Text]);

            }
            catch
            {

                txtE.EditValue = "Cannot Create Class";
            }
        }

        private void btCB_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
             txtE.EditValue = txtC.EditValue ="";
             SetSC();
           
                txtC.EditValue += Business.Info(db.Tables[listTable.Text]);

            }
            catch
            {

                txtE.EditValue = "Cannot Create Class";
            }
        }

        private void btCA_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
             txtE.EditValue = txtC.EditValue ="";
             SetSC();
            
                txtC.EditValue +=  DataAccess.Info();

            }
            catch
            {

                txtE.EditValue = "Cannot Create Class";
            }
        }

        private void btCC_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
             txtE.EditValue = txtC.EditValue ="";
             SetSC();
            
                txtC.EditValue += ConnectionString.Info();

            }
            catch
            {

                txtE.EditValue = "Cannot Create Class";
            }
        }

        private void btCS_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                saveFile.Title = "Specify Destination Filename";
                saveFile.Filter = "Class File(*.cs)|*.cs";
                saveFile.FilterIndex = 1;
                saveFile.OverwritePrompt = true;

                if (saveFile.ShowDialog() != DialogResult.Cancel)
                {
                    Folder.CreateFile(saveFile.FileName, txtC.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
        }

        private void listTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listTable.Text == "") return;
                int key = 0;
                loading.Properties.Maximum = db.Tables[listTable.Text].Columns.Count;
                loading.Properties.Minimum = 0;
                loading.Properties.Step = 1;
                loading.Properties.PercentView = true;

                foreach (Column cl in db.Tables[listTable.Text].Columns)
                {
                    loading.PerformStep();
                    loading.Update();
                    if (cl.InPrimaryKey) key++;
                }
                lbCL.Text = string.Format("{0} : {1} column({2} key)", listTable.Text, db.Tables[listTable.Text].Columns.Count.ToString(), key);
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
        }

        private void btSAS_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                saveFile.Title = "Specify Destination Filename";
                saveFile.Filter = "SQL File(*.sql)|*.sql";
                saveFile.FilterIndex = 1;
                saveFile.OverwritePrompt = true;

                if (saveFile.ShowDialog() != DialogResult.Cancel)
                {
                    Folder.CreateFile(saveFile.FileName, txtC.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
        }

        private void btSACP_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                saveFile.Title = "Specify Destination Filename";
                saveFile.Filter = "Class File(*.cs)|*.cs";
                saveFile.FilterIndex = 1;
                saveFile.OverwritePrompt = true;

                if (saveFile.ShowDialog() != DialogResult.Cancel)
                {
                    Folder.CreateFile(saveFile.FileName, txtC.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
        }

        private void btDP_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
            txtE.EditValue = txtC.EditValue = "";
            SetSW();
            
                txtC.EditValue += WebUI.DefaultPage(db.Tables[listTable.Text]);

            }
            catch
            {

                txtE.EditValue = "Cannot Create Class";
            }
        }

        private void btUP_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
            txtE.EditValue = txtC.EditValue = "";
            SetSW();
           
                txtC.EditValue += WebUI.UpdatePage(db.Tables[listTable.Text]);

            }
            catch
            {

                txtE.EditValue = "Cannot Create Class";
            }
        }

        private void SetSQ()
        {
            if (txtSQ.EditValue.ToString() == "") return;
            string[] lines = Regex.Split(txtSQ.EditValue.ToString(), "\r\n");
            txtC.EditValue = "--============================\r\n";
            foreach (string line in lines)
            {
                txtC.EditValue +=  string.Format("-- {0}\r\n", line);
            }
            txtC.EditValue +="--============================\r\n";
        }
        private void SetSC()
        {
            if (txtSC.EditValue.ToString() == "") return;
            string[] lines = Regex.Split(txtSC.EditValue.ToString(), "\r\n");
            txtC.EditValue = "//============================\r\n";
            foreach (string line in lines)
            {
                txtC.EditValue += string.Format("// {0}\r\n", line);
            }
            txtC.EditValue += "//============================\r\n";
        }
        private void SetSW()
        {
            if (txtSW.EditValue.ToString() == "") return;
            string[] lines = Regex.Split(txtSW.EditValue.ToString(), "\r\n");
            txtC.EditValue = "//============================\r\n";
            foreach (string line in lines)
            {
                txtC.EditValue += string.Format("// {0}\r\n", line);
            }
            txtC.EditValue += "//============================\r\n";
        }

        private void btNCN_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                SForm.MainForm = new Main();
                SForm.LoginForm = new Login();
                SForm.LoginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            SForm.MainForm = new Main();
            this.Hide();
            SForm.LoginForm.LoginClick();
        }

        private void listDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
        }

        private void LoadTotal()
        {
            RunSave.DBConnect = Save.Connection + ";database=" + listDB.Text;
            int tb = Save.GetTable(listDB.Text).Count;
            RunSave.DatabaseQ = Save.SVName.Databases[listDB.Text];
            int pc = 0;
            for (int i = 0; i < 8; i++)
                if (ckbP.Items[i].CheckState == CheckState.Checked) pc++;
            lbTP.Text = string.Format("Procedure (Total : {0})", tb * pc);
        }

        private void ckbP_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                LoadTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btsetup_Click(object sender, EventArgs e)
        {
            try
            {
                Database dbl = Save.SVName.Databases[listDB.Text];
                SForm.CreateAllQueryForm.LoadProc(dbl);
                SForm.CreateAllQueryForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
        }

        public void LoadCreateALL()
        {
            SForm.ProgressBarForm.ShowDialog(this);
        }
        public void LoadCreateAllClass()
        {
            SForm.ProgressBarCForm.ShowDialog(this);
        }

        private void btEF_Click(object sender, EventArgs e)
        {
            DialogResult yn = MessageBox.Show("Do you want to create all a stored procedures", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (yn == DialogResult.OK)
            {
                try
                {
                    Database dbl = Save.SVName.Databases[listDB.Text];

                    DataTable listPro = new DataTable();
                    listPro.Columns.Add("Name");
                    listPro.Columns.Add("Result");
                    DataRow row;

                    string[] strP = new string[] { "{0}_Insert", "{0}_Update", "{0}_Delete", "{0}_SelectAll", "{0}_SelectPage", "{0}_SelectTop", "{0}_SelectById", "{0}_TestById" };

                    foreach (Table tb in dbl.Tables)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (!tb.IsSystemObject)
                            {
                                row = listPro.NewRow();
                                row["Name"] = string.Format(strP[i], tb.Name);

                                row["Result"] = (ckbP.Items[i].CheckState == CheckState.Checked) ? "Action" : "No Action";
                                listPro.Rows.Add(row);
                            }
                        }


                    }

                    SForm.ProgressBarForm.listP = listPro;
                    SForm.ProgressBarForm.Kiped = true;
                    SForm.ProgressBarForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btOC_Click(object sender, EventArgs e)
        {
            try
            {
                Database dbl = Save.SVName.Databases[listDBC.Text];
                SForm.CreateAllClassForm.Loadlist(dbl);
                SForm.CreateAllClassForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
        }

        private void btFC_Click(object sender, EventArgs e)
        {
            DialogResult yn = MessageBox.Show("Do you want to create all a class file", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (yn == DialogResult.OK)
            {
                try
                {
                    Database dbl = Save.SVName.Databases[listDBC.Text];

                    DataTable listClass = new DataTable();
                    listClass.Columns.Add("Name");
                    listClass.Columns.Add("Result");

                    DataRow row = listClass.NewRow();
                    row = listClass.NewRow(); row["Name"] = "DataAccess:DataAccess"; row["Result"] = "Action"; listClass.Rows.Add(row);
                    row = listClass.NewRow(); row["Name"] = "DataAccess:Connect"; row["Result"] = "Action"; listClass.Rows.Add(row);


                    for (int i = 0; i < dbl.Tables.Count; i++)
                    {
                        if (!dbl.Tables[i].IsSystemObject)
                        {
                            row = listClass.NewRow(); row["Name"] = "Entities:" + dbl.Tables[i].Name; row["Result"] = "Action"; listClass.Rows.Add(row);

                            row = listClass.NewRow(); row["Name"] = "Business:" + dbl.Tables[i].Name; row["Result"] = "Action"; listClass.Rows.Add(row);
                        }
                    }

                    SForm.ProgressBarCForm.listP = listClass;
                    SForm.ProgressBarCForm.Kiped = true;
                    SForm.ProgressBarCForm.path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DevNETCoder\" + dbl.Name;
                    SForm.ProgressBarCForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        private void listDBC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RunSave.DatabaseC = Save.SVName.Databases[listDBC.Text];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
        }

      

      
       
   
    }
}