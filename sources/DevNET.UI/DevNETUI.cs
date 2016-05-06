using System;
using System.Collections;
using System.Linq;
using System.Text;
using ConvertType;
using Microsoft.SqlServer.Management.Smo;

namespace DevNETUI
{
    public static class WebUI
    {
        
        public static string DefaultPage(Table table)
        {
            StringBuilder resurt = new StringBuilder();
            StringBuilder val = new StringBuilder();
            
            
            try
            {
                resurt.Append("\r\nusing System;");
                resurt.Append("\r\nusing System.Collections.Generic;");
                resurt.Append("\r\nusing System.Web;");
                resurt.Append("\r\nusing System.Web.UI;");
                resurt.Append("\r\nusing System.Web.UI.WebControls;");
                resurt.Append("\r\nusing DevNET.Data.Business;\r\n");
                resurt.Append("\r\npublic partial class _Default : System.Web.UI.Page");
                resurt.Append("\r\n{");
                resurt.Append("\r\n    private void BindGridView()");
                resurt.Append("\r\n    {");
                resurt.AppendFormat("\r\n        gridView.DataSource = B{0}.SelectAll();",table.Name);
                resurt.Append("\r\n        gridView.DataBind();");
                resurt.Append("\r\n    }");
                resurt.Append("\r\n    protected void Page_Load(object sender, EventArgs e)");
                resurt.Append("\r\n    {");
                resurt.Append("\r\n        if (!IsPostBack)");
                resurt.Append("\r\n        {");
                resurt.Append("\r\n            BindGridView();");
                resurt.Append("\r\n        }");
                resurt.Append("\r\n    }");
                resurt.Append("\r\n    protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)");
                resurt.Append("\r\n    {");
                foreach (Column col in table.Columns)
                {
                    if (col.InPrimaryKey)
                    {
                        string typec = ConvertTypeSQL.TypeC(col.DataType.SqlDataType.ToString());
                        if(typec == "string")
                        resurt.AppendFormat("\r\n        {0} {1} = gridView.DataKeys[e.RowIndex].Values[\"{1}\"].ToString();",typec,col.Name.ToString());
                        else
                            resurt.AppendFormat("\r\n        {0} {1} = ({0})gridView.DataKeys[e.RowIndex].Values[\"{1}\"].ToString();", typec, col.Name.ToString());
                        val.AppendFormat(",{0}", col.Name.ToString());
                    }
                }
                resurt.AppendFormat("\r\n        B{0}.Delete({1});",table.Name,val.ToString().Substring(1));
                resurt.Append("\r\n        BindGridView();");
                resurt.Append("\r\n    }");
                resurt.Append("\r\n    protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)");
                resurt.Append("\r\n    {");
                resurt.Append("\r\n        gridView.PageIndex = e.NewPageIndex;");
                resurt.Append("\r\n        BindGridView();");
                resurt.Append("\r\n    }");
                resurt.Append("\r\n}");

                return resurt.ToString();
                
            }
            catch 
            {

                return " Can not create object";
            }
        }
        public static string UpdatePage(Table table)
        {
            StringBuilder resurt = new StringBuilder();
            StringBuilder key = new StringBuilder();
            StringBuilder nokey = new StringBuilder();
            StringBuilder isnokey = new StringBuilder();
            StringBuilder iskey = new StringBuilder();
            StringBuilder val = new StringBuilder();
            StringBuilder idup = new StringBuilder();

            try
            {
                resurt.Append("\r\nusing System;");
                resurt.Append("\r\nusing System.Collections.Generic;");
                resurt.Append("\r\nusing System.Web;");
                resurt.Append("\r\nusing System.Web.UI;");
                resurt.Append("\r\nusing System.Web.UI.WebControls;");
                resurt.Append("\r\nusing DevNET.Data.Business;");
                resurt.Append("\r\nusing DevNET.Data.Entities;\r\n");

                resurt.Append("\r\npublic partial class Update : System.Web.UI.Page");
                resurt.Append("\r\n{");
                resurt.Append("\r\n    protected void Page_Load(object sender, EventArgs e)");
                resurt.Append("\r\n    {");
                resurt.Append("\r\n        if (!IsPostBack)");
                resurt.Append("\r\n        {");

                foreach (Column col in table.Columns)
                {
                     string typec = ConvertTypeSQL.TypeC(col.DataType.SqlDataType.ToString());
                    if (col.InPrimaryKey)
                    {
                        key.AppendFormat("|| string.IsNullOrEmpty(Request[\"{0}\"]) ", col.Name);
                        if(typec != "string")
                            iskey.AppendFormat("\r\n                {1} {0} = {1}.Parse(Request[\"{0}\"].ToString());", col.Name, typec);
                        else
                            iskey.AppendFormat("\r\n                {1} {0} = Request[\"{0}\"].ToString();", col.Name, typec);

                        val.AppendFormat(",{0}", col.Name.ToString());
                        idup.AppendFormat("\r\n                O{0}.{1} = {1};",table.Name,col.Name);
                    }
                    else
                    {
                        nokey.AppendFormat("\r\n                {0};", ConvertTypeControl.GetControl(col.DataType.SqlDataType.ToString(), string.Format("O{0}.{1}", table.Name, col.Name), col.Name, false));
                        isnokey.AppendFormat("\r\n            {0};", ConvertTypeControl.GetControl(col.DataType.SqlDataType.ToString(), string.Format("O{0}.{1}", table.Name, col.Name), col.Name, true));


                    }
                }

                resurt.AppendFormat("\r\n            if ({0})",key.ToString().Substring(3));
                resurt.Append("\r\n            {");
                resurt.Append("\r\n                return;");
                resurt.Append("\r\n            }");
                resurt.Append("\r\n            else");
                resurt.Append("\r\n            {");

                resurt.Append(iskey.ToString());
                resurt.Append("\r\n");
                resurt.AppendFormat("\r\n                if(!B{0}.IsTest({1})) Response.Redirect(\"Update.aspx\");", table.Name, val.ToString().Substring(1));
                resurt.AppendFormat("\r\n                E{0} O{0} = B{0}.SelectByID({1});\r\n", table.Name, val.ToString().Substring(1));
                resurt.Append(nokey.ToString());
                resurt.Append("\r\n            }");
                resurt.Append("\r\n        }");
                resurt.Append("\r\n    }");
                resurt.Append("\r\n    protected void buttonUpdate_Click(object sender, EventArgs e)");
                resurt.Append("\r\n    {");
                resurt.Append("\r\n        try");
                resurt.Append("\r\n        {");
                resurt.AppendFormat("\r\n            E{0} O{0} = new E{0}();\r\n", table.Name);
                resurt.Append(isnokey.ToString());
                resurt.Append("\r\n");
                resurt.AppendFormat("\r\n            if ({0})", key.ToString().Substring(3));
                resurt.Append("\r\n            {");
                resurt.AppendFormat("\r\n                B{0}.Insert(O{0});",table.Name);
                resurt.Append("\r\n            }");
                resurt.Append("\r\n            else");
                resurt.Append("\r\n            {"); 
                resurt.Append(iskey.ToString());
                resurt.Append(idup);
                resurt.AppendFormat("\r\n                B{0}.Update(O{0});",table.Name);
                resurt.Append("\r\n            }");
                resurt.Append("\r\n        }");
                resurt.Append("\r\n        catch");
                resurt.Append("\r\n        {");
                resurt.Append("\r\n            throw;");
                resurt.Append("\r\n        }");
                resurt.Append("\r\n    }");
                resurt.Append("\r\n}");

                return resurt.ToString();
            }
            catch 
            {

                return " Can not create object";
            }
            
        }
    }
}




