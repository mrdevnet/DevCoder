using System;
using System.Collections.Generic;
using System.Text;

namespace StringLayer
{
    public static class ConnectionString
    {
        public static string Info()
        {
            StringBuilder con = new StringBuilder();

            con.Append("\r\nusing System;\r\n");
            con.Append("using System.Data;\r\n");
            con.Append("using System.Data.SqlClient;\r\n");
            con.Append("using System.Configuration;\r\n");
            con.Append("using System.Web;\r\n");
            con.Append("using System.Web.Security;\r\n");
            con.Append(" \r\n");
            con.Append("namespace DevNET.Data.Connection\r\n");
            con.Append("{\r\n");
            con.Append("\t public static class ConnectionString\r\n");
            con.Append("\t {\r\n");
            con.Append("\t    private static string strconnection =  ConfigurationManager.ConnectionStrings[\"DevNETConnectionString\"].ToString();\r\n");
            con.Append("\t    public static string Text\r\n");
            con.Append("\t    {\r\n");
            con.Append("\t      get { return strconnection; }\r\n");
            con.Append("\t      set { strconnection = value; }\r\n");
            con.Append("\t    }\r\n");
            con.Append("\t }\r\n");
            con.Append("}");
            return con.ToString();
       }
    }
}
