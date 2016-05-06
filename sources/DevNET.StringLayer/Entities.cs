using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using ConvertType;

namespace StringLayer
{
    public static class Entities
    {
        public static string Info(Table table)
        {
            try
            { 
            string g,n,t,k,k2 ;
           
           
            StringBuilder gb = new StringBuilder();
            StringBuilder kb = new StringBuilder();
            StringBuilder kb2 = new StringBuilder();
            StringBuilder vl = new StringBuilder();
            StringBuilder vl2 = new StringBuilder();

                
            foreach(Column cl in table.Columns)
            {
                n=cl.Name.ToString();
                
                t= ConvertTypeSQL.TypeC(cl.DataType.SqlDataType.ToString());
                if (cl.InPrimaryKey)
                {
                    kb.AppendFormat("{0} v{1},", t, cl.Name);
                    kb2.AppendFormat("v{0},", cl.Name);
                   
                }
                vl.AppendFormat("\r\n            this.{0} = O{1}.{0};",cl.Name,table.Name);
                vl2.AppendFormat("{0} v{1},", t, cl.Name);
               
                gb.AppendFormat("\r\n     public {0} {1}" ,t, n);
                gb.Append("\r\n     { get;set; }");
            }
          
            g = gb.ToString();
            k = kb.ToString().Substring(0, kb.Length - 1);
            k2 = kb2.ToString().Substring(0, kb2.Length - 1);
            StringBuilder va = new StringBuilder();
                va.Append("\r\n using System;");
                va.Append("\r\n using System.Text; \r\n using DevNET.Data.Business;\r\n");
                va.Append("\r\n namespace DevNET.Data.Entities \r\n{");
                va.AppendFormat("\r\n   public class E{0}",table.Name.ToString());
                va.Append("\r\n   {");
                va.AppendFormat("\r\n     public E{0}()", table.Name.ToString());
                va.Append("\r\n     {");
                va.Append("\r\n     }");
                va.AppendFormat("\r\n     public E{0}({1})", table.Name.ToString(),k);
                va.Append("\r\n     {");
                va.AppendFormat("\r\n            E{0} O{0} = B{0}.SelectByID({1});",table.Name,k2);
                va.Append(vl.ToString());
                va.Append("\r\n     }");
                va.AppendFormat("\r\n     public E{0}({1})", table.Name.ToString(), vl2.ToString().Substring(0, vl2.Length - 1));
                va.Append("\r\n     {");
                va.Append(vl.ToString().Replace(string.Format("O{0}.",table.Name),"v"));
                va.Append("\r\n     }");
                va.Append("\r\n");
                va.Append(g);
                va.Append("\r\n   }");
                va.Append("\r\n }");

            return va.ToString();
            }
            catch
            {
                return " Can not create object !";

            } 
        }      
    }
}
