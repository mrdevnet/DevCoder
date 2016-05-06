using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Smo;
using DevNETCoder.Static;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;

namespace DevNETCoder
{
    public partial class CreateAll : DevExpress.XtraEditors.XtraForm
    {
        public CreateAll()
        {
            InitializeComponent();
        }

        public static DataTable tbP;

        private void CreateAllQuery_Load(object sender, EventArgs e)
        {
            try
            {
                tlP.DataSource = tbP;
                if (tlP.Nodes.Count == 0)
                {
                    MessageBox.Show("Can not loading all procedule");
                    this.Close();
                }

                for (int i = 0; i < tlP.Nodes.Count; i++)
                {
                    tlP.Nodes[i].CheckState = CheckState.Checked;
                    tlP.Nodes[i].Expanded = true;
                    SetCheckedChildNodes(tlP.Nodes[i], CheckState.Checked);
                }
                totalP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            
        }
        public void LoadProc(Database db)
        {
           
            DataTable listPro = new DataTable();
            listPro.Columns.Add("ID");
            listPro.Columns.Add("Name");
            listPro.Columns.Add("TableID");
            DataRow row;
            string[] strP = new string[] { "{0}_Insert", "{0}_Update", "{0}_Delete", "{0}_SelectAll", "{0}_SelectPage", "{0}_SelectTop", "{0}_SelectById", "{0}_TestById" };

          ArrayList tb =   Save.GetTable(db.Name);
          
          for (int i = 0; i < tb.Count; i++)
          {
              if (!db.Tables[i].IsSystemObject)
              {
                  row = listPro.NewRow();
                  row["ID"] = i;
                  row["Name"] = tb[i];
                  row["TableID"] = "";
                  listPro.Rows.Add(row);
                  for (int j = 0; j < 8; j++)
                  {
                      row = listPro.NewRow();
                      row["ID"] = string.Format("{0}:{1}", tb[i].ToString(), j);
                      row["Name"] = string.Format(strP[j], tb[i].ToString());
                      row["TableID"] = i;
                      listPro.Rows.Add(row);
                  }
              }
          }
          tbP = listPro;
          
        }
        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            try
            {
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    node.Nodes[i].CheckState = check;
                    SetCheckedChildNodes(node.Nodes[i], check);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
        }
        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            try
            {
                if (node.ParentNode != null)
                {

                    CheckState parentCheckState = node.ParentNode.CheckState;
                    CheckState nodeCheckState;
                    for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                    {
                        nodeCheckState = (CheckState)node.ParentNode.Nodes[i].CheckState;
                        if (!check.Equals(nodeCheckState))
                        {
                            parentCheckState = CheckState.Unchecked;
                            break;
                        }
                        parentCheckState = check;
                    }

                    node.ParentNode.CheckState = parentCheckState;
                    SetCheckedParentNodes(node.ParentNode, check);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
        }

        private void tlP_AfterCheckNode(object sender, NodeEventArgs e)
        {
            try
            {
                SetCheckedChildNodes(e.Node, e.Node.CheckState);
                SetCheckedParentNodes(e.Node, e.Node.CheckState);
                totalP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            
        }

        private void btC_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ckbP_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            try
            {
                string strpro = ckbP.Items[e.Index].ToString();
                for (int i = 0; i < tlP.Nodes.Count; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {

                        if (tlP.Nodes[i].Nodes[j].GetDisplayText("Name").ToLower().EndsWith(strpro.ToLower()))
                        {
                            tlP.Nodes[i].Nodes[j].CheckState = e.State;
                            SetCheckedParentNodes(tlP.Nodes[i].Nodes[j], e.State);
                        }
                    }
                }
                totalP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            
        }
        private void totalP()
        {
            int countP =0;
            for (int i = 0; i < tlP.Nodes.Count; i++)
            {
                for (int j = 0; j < 8; j++)
                    if (tlP.Nodes[i].Nodes[j].CheckState == CheckState.Checked) countP++;
            }
            lbT.Text = string.Format("Total : {0}", countP);
        }

        private void btF_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new DataTable();

                table.Columns.Add("Name");
                table.Columns.Add("Result");
                DataRow row;
                for (int i = 0; i < tlP.Nodes.Count; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        row = table.NewRow();
                        row["Name"] = tlP.Nodes[i].Nodes[j].GetDisplayText("Name");
                        if (tlP.Nodes[i].Nodes[j].CheckState == CheckState.Checked)
                            row["Result"] = "Action";
                        else
                            row["Result"] = "No Action";
                        table.Rows.Add(row);
                    }
                }
                this.Hide();
                SForm.ProgressBarForm.listP = table;
                SForm.ProgressBarForm.Kiped = (rd.SelectedIndex == 0) ? false : true;
                SForm.MainForm.LoadCreateALL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            
            
        }
    }
}