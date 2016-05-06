using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using ConvertType;

namespace StringLayer
{
    public static class Business
    {
        public static string Info(Table table)
        {
            try
            {
            string nt = table.Name.ToString();
            StringBuilder kb = new StringBuilder();
            kb.Append("\r\nusing System;" );
            kb.Append("\r\nusing System.Data;" );
            kb.Append("\r\nusing System.Data.SqlClient;" );
            kb.Append("\r\nusing System.Collections.Generic;" );
            kb.Append("\r\nusing DevNET.Data.Entities;" );
            kb.Append("\r\nusing DevNET.Data.DataAccess;" );
            kb.Append("\r\n " );
            kb.Append("\r\nnamespace DevNET.Data.Business");
            kb.Append("\r\n{");
            kb.AppendFormat("\r\n    public class B{0}", nt );
            kb.Append("\r\n    {");
            StringBuilder sl = new StringBuilder();

             sl.Append("\r\n        public static DataTable SelectAll()");
             sl.Append("\r\n        {");
             sl.AppendFormat("\r\n            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, \"{0}_SelectAll\", null);",nt);
             sl.Append("\r\n            return all;");
             sl.Append("\r\n        }");
             sl.Append("\r\n        public static DataTable SelectTop(string Top ,string Where,string Order)");
             sl.Append("\r\n        {");
             sl.Append("\r\n            SqlParameter[] pr = new SqlParameter[3];");
             sl.Append("\r\n            pr[0] = new SqlParameter(@\"Top\", Top);");
             sl.Append("\r\n            pr[1] = new SqlParameter(@\"Where\", Where);");
             sl.Append("\r\n            pr[2] = new SqlParameter(@\"Order\", Order);");
             sl.AppendFormat("\r\n            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, \"{0}_SelectTop\", pr);",nt);
             sl.Append("\r\n            return all;");
             sl.Append("\r\n        }");
             sl.Append("\r\n        public static DataTable SelectPage(int CurrentPage, int PageSize, out int RowCount)");
             sl.Append("\r\n        {");
             sl.Append("\r\n            SqlParameter[] pr = new SqlParameter[3];");
             sl.Append("\r\n            pr[0] = new SqlParameter(@\"CurrentPage\", CurrentPage);");
             sl.Append("\r\n            pr[1] = new SqlParameter(@\"PageSize\", PageSize);");
             sl.Append("\r\n            pr[2] = new SqlParameter(@\"RowCount\", SqlDbType.Int);");
             sl.Append("\r\n            pr[2].Direction = ParameterDirection.Output;");
             sl.AppendFormat("\r\n            DataTable all = SqlHelper.ExecuteData(CommandType.StoredProcedure, \"{0}_SelectPage\", pr);", nt);
             sl.Append("\r\n            RowCount = Convert.ToInt32(pr[2].Value);");
             sl.Append("\r\n            return all;");
             sl.Append("\r\n        }");
             

            StringBuilder iub = new StringBuilder();
            iub.AppendFormat("\r\n        {{\r\n            SqlParameter[] pr = new SqlParameter[{0}];", table.Columns.Count.ToString());
            StringBuilder rb = new StringBuilder();
                for(int i =0;i<table.Columns.Count;i++)
                {
                    iub.AppendFormat("\r\n            pr[{0}] = new SqlParameter(@\"{1}\", O{2}.{1});",i,table.Columns[i].Name.ToString(),nt);
                    rb.AppendFormat("\r\n                if (idr[\"{0}\"] != DBNull.Value)\r\n                    O{1}.{0} = ({2})idr[\"{0}\"];", table.Columns[i].Name.ToString(), nt, ConvertTypeSQL.TypeC(table.Columns[i].DataType.SqlDataType.ToString()));                        
                }

                StringBuilder iiub = new StringBuilder();
                iiub.AppendFormat("\r\n        {{\r\n            SqlParameter[] pr = new SqlParameter[{0}];", ((table.Columns[0].Identity == true) ? (table.Columns.Count - 1).ToString() : (table.Columns.Count.ToString())));
                int idd = 0;
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    if (!table.Columns[i].Identity)
                    {
                        iiub.AppendFormat("\r\n            pr[{0}] = new SqlParameter(@\"{1}\", O{2}.{1});", idd, table.Columns[i].Name.ToString(), nt);
                        idd++;
                    }
                }
                string r = rb.ToString();
                string iu = iub.ToString();
                string iiu = iiub.ToString();
               int j=0;
               StringBuilder kdb = new StringBuilder();
               StringBuilder kib = new StringBuilder();
            
            foreach(Column col in table.Columns)
            {
                if (col.InPrimaryKey)
                {
                    kib.AppendFormat(",{0} {1}",ConvertTypeSQL.TypeC(col.DataType.SqlDataType.ToString()),col.Name.ToString());
                    kdb.AppendFormat("\r\n            pr[{0}] = new SqlParameter(@\"{1}\",{1});",j,table.Columns[j].Name.ToString());
                    j++;
                }
                    
            }
            string kd, ki;
            kd = kdb.ToString();
            ki = kib.ToString();

            StringBuilder dl = new StringBuilder();
            dl.AppendFormat("\r\n        public static void Delete({0})", ki.Substring(1, ki.Length - 1));
                dl.Append("\r\n        {");
                dl.AppendFormat("\r\n            SqlParameter[] pr = new SqlParameter[{0}];",j);
                dl.Append(kd);
                dl.AppendFormat("\r\n            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, \"{0}_Delete\", pr);",nt);
                dl.Append("\r\n        }");

           StringBuilder id = new StringBuilder();

           id.AppendFormat("\r\n        public static E{0} SelectByID({1})", nt, ki.Substring(1, ki.Length - 1));
                id.Append("\r\n        {");
                id.AppendFormat("\r\n            E{0} O{0} = new E{0}();",nt);
                id.AppendFormat("\r\n            SqlParameter[] pr = new SqlParameter[{0}];",j);
                id.Append(kd );
                id.AppendFormat("\r\n            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure,\"{0}_SelectByID\", pr);" ,nt);
                id.Append("\r\n            if (idr.Read())" );
                id.AppendFormat("\r\n              O{0} = GetOne{0}(idr);" ,nt);
                id.Append("\r\n            idr.Close();");
                id.Append("\r\n            idr.Dispose();");
                id.AppendFormat("\r\n            return O{0};",nt);
                id.Append("\r\n        }");

           StringBuilder test = new StringBuilder();
           test.AppendFormat("\r\n        public static bool TestByID({0})", ki.Substring(1, ki.Length - 1));
                test.Append("\r\n        {" );
                test.AppendFormat("\r\n            SqlParameter[] pr = new SqlParameter[{0}];", j + 1);
                test.Append(kd);
                test.AppendFormat("\r\n            pr[{0}] = new SqlParameter(@\"TestID\",SqlDbType.Bit);",j);
                test.AppendFormat("\r\n            pr[{0}].Direction = ParameterDirection.Output;",j);
                test.AppendFormat("\r\n            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,\"{0}_TestByID\", pr);",nt);
                test.AppendFormat("\r\n            return Convert.ToBoolean(pr[{0}].Value);",j);
                test.Append("\r\n        }");

           StringBuilder g = new StringBuilder();
                g.AppendFormat("\r\n        private static E{0} GetOne{0}(IDataReader idr)",nt);
                g.Append("\r\n       {");
                g.AppendFormat("\r\n            E{0} O{0} = new E{0}();",nt );
                g.Append(r);
                g.AppendFormat("\r\n            return O{0};",nt );
                g.Append("\r\n       }");

           StringBuilder lis = new StringBuilder();
                lis.AppendFormat("\r\n        public static List<E{0}> ListAll()",nt );
                lis.Append("\r\n        {");
                lis.AppendFormat("\r\n            List<E{0}> list = new List<E{0}>();",nt);
                lis.AppendFormat("\r\n            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, \"{0}_SelectAll\", null);",nt);
                lis.Append("\r\n            while (idr.Read())");
                lis.AppendFormat("\r\n              list.Add(GetOne{0}(idr));",nt);
                lis.Append("\r\n            if (idr.IsClosed == false)");
                lis.Append("\r\n            {");
                lis.Append("\r\n               idr.Close();");
                lis.Append("\r\n               idr.Dispose();");
                lis.Append("\r\n            }" );
                lis.Append("\r\n            return list;");
                lis.Append("\r\n        }");

                lis.AppendFormat("\r\n        public static List<E{0}> ListTop(string Top ,string Where,string Order)", nt);
                lis.Append("\r\n        {");
                lis.Append("\r\n            SqlParameter[] pr = new SqlParameter[3];");
                lis.Append("\r\n            pr[0] = new SqlParameter(@\"Top\", Top);");
                lis.Append("\r\n            pr[1] = new SqlParameter(@\"Where\", Where);");
                lis.Append("\r\n            pr[2] = new SqlParameter(@\"Order\", Order);");
                lis.AppendFormat("\r\n            List<E{0}> list = new List<E{0}>();",nt);
                lis.AppendFormat("\r\n            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, \"{0}_SelectTop\", pr);", nt);
                lis.Append("\r\n            while (idr.Read())");
                lis.AppendFormat("\r\n              list.Add(GetOne{0}(idr));",nt);
                lis.Append("\r\n            if (idr.IsClosed == false)");
                lis.Append("\r\n            {");
                lis.Append("\r\n               idr.Close();");
                lis.Append("\r\n               idr.Dispose();");
                lis.Append("\r\n            }");
                lis.Append("\r\n            return list;");
                lis.Append("\r\n        }");

                lis.AppendFormat("\r\n        public static List<E{0}> ListPage(int CurrentPage, int PageSize, out int RowCount)", nt);
                lis.Append("\r\n        {");
                lis.Append("\r\n            SqlParameter[] pr = new SqlParameter[3];");
                lis.Append("\r\n            pr[0] = new SqlParameter(@\"CurrentPage\", CurrentPage);");
                lis.Append("\r\n            pr[1] = new SqlParameter(@\"PageSize\", PageSize);");
                lis.Append("\r\n            pr[2] = new SqlParameter(@\"RowCount\", SqlDbType.Int);");
                lis.Append("\r\n            pr[2].Direction = ParameterDirection.Output;");
                lis.AppendFormat("\r\n            List<E{0}> list = new List<E{0}>();", nt);
                lis.AppendFormat("\r\n            IDataReader idr = SqlHelper.ExecuteReader(CommandType.StoredProcedure, \"{0}_SelectPage\", pr);", nt);
                lis.Append("\r\n            while (idr.Read())");
                lis.AppendFormat("\r\n              list.Add(GetOne{0}(idr));", nt);
                lis.Append("\r\n            if (idr.IsClosed == false)");
                lis.Append("\r\n            {");
                lis.Append("\r\n               idr.Close();");
                lis.Append("\r\n               idr.Dispose();");
                lis.Append("\r\n            }");
                lis.Append("\r\n            RowCount = Convert.ToInt32(pr[2].Value);");
                lis.Append("\r\n            return list;");
                lis.Append("\r\n        }");

          StringBuilder S = new StringBuilder();            
                S.Append(kb.ToString());
                S.Append("\r\n//-------------------------------------------------------------------------------------------//");
                S.Append(sl.ToString());
                S.Append("\r\n//-------------------------------------------------------------------------------------------//");
                S.AppendFormat("\r\n        public static void Insert(E{0} O{0})",nt);
                S.Append(iiu);
                S.AppendFormat("\r\n            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,\"{0}_Insert\", pr);",nt);
                S.Append("\r\n        }");
                S.Append("\r\n//-------------------------------------------------------------------------------------------//");
                S.AppendFormat("\r\n        public static void Update(E{0} O{0})",nt);
                S.Append(iu);
                S.AppendFormat("\r\n            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,\"{0}_Update\", pr);",nt);
                S.Append("\r\n        }");
                S.Append("\r\n//-------------------------------------------------------------------------------------------//");
                S.Append(dl.ToString());
                S.Append("\r\n//-------------------------------------------------------------------------------------------//");
                S.Append(id.ToString());
                S.Append("\r\n//-------------------------------------------------------------------------------------------//");
                S.Append(g.ToString());
                S.Append("\r\n//-------------------------------------------------------------------------------------------//");
                S.Append(test.ToString());
                S.Append("\r\n//-------------------------------------------------------------------------------------------//");
                S.Append(lis.ToString());
                S.Append("\r\n    }");
                S.Append("\r\n ");
                S.Append("\r\n}");
            return  S.ToString();
            }
            catch
            {
                return " Can not create object !";

            }  
        }
        
    }
}