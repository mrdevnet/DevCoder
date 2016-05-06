using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevNETCoder.Static;
using Microsoft.SqlServer.Management.Smo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using Tools;

namespace DevNETCoder
{
    public partial class CreateAllClass : DevExpress.XtraEditors.XtraForm
    {
        public CreateAllClass()
        {
            InitializeComponent();
        }

        public static DataTable tbP;
        public static string desktop;

        private void btC_Click(object sender, EventArgs e)
        {
            this.Close();
            SForm.CreateAllClassForm = new CreateAllClass();
        }

        private void CreateAllClass_Load(object sender, EventArgs e)
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
                txtPath.Text = desktop;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
        }

        public void Loadlist(Database db )
        {
            DataTable listClass = new DataTable();
            listClass.Columns.Add("Cid");
            listClass.Columns.Add("name");
            listClass.Columns.Add("folderID");

            DataRow row = listClass.NewRow();
            row["Cid"] = "DataAccess"; row["name"] = "DataAccess"; row["folderID"] = ""; listClass.Rows.Add(row);//-
            row = listClass.NewRow(); row["Cid"] = "DataAccess:DataAccess"; row["name"] = "DataAccess.cs"; row["folderID"] = "DataAccess"; listClass.Rows.Add(row);
            row = listClass.NewRow(); row["Cid"] = "DataAccess:Connect"; row["name"] = "Connect.cs"; row["folderID"] = "DataAccess"; listClass.Rows.Add(row);

            row = listClass.NewRow(); row["Cid"] = "Entities"; row["name"] = "Entities"; row["folderID"] = ""; listClass.Rows.Add(row);//-
            row = listClass.NewRow(); row["Cid"] = "Business"; row["name"] = "Business"; row["folderID"] = ""; listClass.Rows.Add(row);//-

            for(int i =0;i< db.Tables.Count;i++)
            {
                if (!db.Tables[i].IsSystemObject)
                {
                    row = listClass.NewRow(); row["Cid"] = "Entities:" + db.Tables[i].Name; row["name"] = string.Format("{0}.cs", db.Tables[i].Name); row["folderID"] = "Entities"; listClass.Rows.Add(row);

                    row = listClass.NewRow(); row["Cid"] = "Business:" + db.Tables[i].Name; row["name"] = string.Format("{0}.cs", db.Tables[i].Name); row["folderID"] = "Business"; listClass.Rows.Add(row);
                }
            }

            tbP = listClass;
             desktop = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            desktop += @"\DevNETCoder\" + db.Name;
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

        private void btBr_Click(object sender, EventArgs e)
        {
            if (onpenFolder.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = onpenFolder.SelectedPath;
            }
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
                    for (int j = 0; j < tlP.Nodes[i].Nodes.Count; j++)
                    {                       
                        row = table.NewRow();
                        row["Name"] = tlP.Nodes[i].Nodes[j].GetDisplayText("Cid");
                        if (tlP.Nodes[i].Nodes[j].CheckState == CheckState.Checked)
                            row["Result"] = "Action";
                        else
                            row["Result"] = "No Action";
                        table.Rows.Add(row);
                    }
                }
                this.Hide();
                SForm.ProgressBarCForm.listP = table;
                SForm.ProgressBarCForm.Kiped = (rd.SelectedIndex == 0) ? false : true;
                SForm.ProgressBarCForm.path = txtPath.Text.EndsWith(@"\") ? txtPath.Text.Substring(0, txtPath.Text.Length - 1) : txtPath.Text;
                SForm.MainForm.LoadCreateAllClass();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
           
        }

       
    }
}
